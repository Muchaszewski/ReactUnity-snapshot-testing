import { HubConnection, IRetryPolicy } from '@microsoft/signalr';
import { BrowserWindow } from 'electron';
import path from 'path';
import * as Babel from '@babel/standalone';

interface IPerformTestRequest {
  id: string;
  html: string;
  settings: IPerformTestSettings;
}

interface IPerformTestSettings {
  width: number;
  height: number;
  captureX: number;
  captureY: number;
  captureWidth: number;
  captureHeight: number;
}

interface IPerformTestResult {
  id: string;
  appType: string;
  resultImage: any;
}

/**
 *  Start the test runner. This will connect to the SignalR hub and wait for test requests.
 */
export function start() {
  const signalR =
    require('@microsoft/signalr') as typeof import('@microsoft/signalr');
  process.env.NODE_TLS_REJECT_UNAUTHORIZED = '0';

  console.log('Starting connection');

  // Create a new connection to the SignalR hub, that will reconnect if the connection is lost
  const connection = new signalR.HubConnectionBuilder()
    .withUrl('http://localhost:5000/orchestrator')
    .withAutomaticReconnect({
      nextRetryDelayInMilliseconds(retryContext) {
        return Math.random() * 2000 + 1000;
      },
    } as IRetryPolicy)
    .build();

  console.log('Building connection');

  // Register a handler for the 'PerformTest' method
  connection.on('PerformTest', (request: IPerformTestRequest) => {
    testUnity(connection, request, false).catch((err) => {
      console.error(err);
    });
    testUnity(connection, request, true).catch((err) => {
      console.error(err);
    });
    testElectron(connection, request).catch((err) => {
      console.error(err);
    });
  });

  // Start the connection
  connection
    .start()
    .then(() => {
      console.log('connected');
      // Send a message to the hub to indicate that we are ready to receive test requests
      connection.invoke('RegisterApp', {
        type: 'electron',
      });
    })
    .catch((err: { toString: () => any }) => console.error(err.toString()));
}

/**
 *    Capture a screenshot of the provided window and return it as a byte array
 * @param browserWindow Window to capture
 * @param settings Settings to use for the capture
 * @returns Byte array of the screenshot
 */
function captureScreenshotToBytes(
  browserWindow: BrowserWindow,
  settings: IPerformTestSettings
): Promise<Buffer> {
  return new Promise((resolve, reject) => {
    browserWindow.webContents
      .capturePage({
        x: settings.captureX,
        y: settings.captureY,
        width: settings.captureWidth,
        height: settings.captureWidth,
      })
      .then((image) => {
        return resolve(image.toPNG());
      })
      .catch((err) => {
        reject(err);
      });
  });
}

/**
 *    Execute a test for Unity player. This will create a new browser window and load the HTML
 *    provided in the request. It will then wait for the Unity player to be loaded and then
 *    execute the provided HTML code.
 * @param request The request to execute
 * @param isToolkit Whether to use the Unity UI Toolkit or default UI system
 */
async function testUnity(
  connection: HubConnection,
  request: IPerformTestRequest,
  isToolkit: boolean
) {
  console.log(`Performing test using Unity ${request.id}`);
  const window = new BrowserWindow({
    show: false,
    width: request.settings.width,
    height: request.settings.height,
    webPreferences: {
      devTools: false,
    },
  });
  window.show();
  // load file assets/unity.html from disk
  if (isToolkit) {
    await window.loadURL(
      'file://' + path.join(__dirname, '../../assets/unityToolkit.html')
    );
  } else {
    await window.loadURL(
      'file://' + path.join(__dirname, '../../assets/unity.html')
    );
  }

  // check if unity is loaded as a loop
  while (true) {
    if (
      !(await window.webContents.executeJavaScript('isUnityInstanceLoaded'))
    ) {
      // wait for 100 ms
      await new Promise((resolve) => setTimeout(resolve, 100));
    } else {
      break;
    }
  }

  // Wait for 2 seconds to make sure the Unity app is loaded (skip splash screen)
  await new Promise((resolve) => setTimeout(resolve, 2100));
  const unityDataPre = `import { Renderer } from '@reactunity/renderer';

    function Method() {
      return <>`;
  const unityDataPost = `</>;
      }

      Renderer.render(<Method />);
      `;
  const unityData = unityDataPre + request.html + unityDataPost;

  type TransformFn = (x: string) => string | null | undefined;
  const identity: TransformFn = (x) => x;
  const transformJsxToES5: TransformFn = (code: string) =>
    Babel.transform(code, { presets: ['es2015', 'react'] }).code;
  const code = transformJsxToES5(unityData)
    ?.replaceAll('\n', '\\n')
    .replaceAll('"', '\\"');
  await window.webContents.executeJavaScript(
    `
      unityInstance.SendMessage("ReactCanvas", "SetJSX", "${code}"); 
      unityInstance.SendMessage("ReactCanvas", "RenderBridge");
      `
  );

  await new Promise((resolve) => setTimeout(resolve, 1000));
  captureScreenshotToBytes(window, request.settings).then((buffer) => {
    connection
      .invoke('ReportResult', {
        id: request.id,
        appType: 'unity',
        resultImage: buffer.toJSON().data,
      } as IPerformTestResult)
      .catch((error) => {
        console.log(`Test for Unity ${request.id} failed: ${error}`);
      })
      .finally(() => {
        console.log(`Test for Unity ${request.id} completed`);
        window.close();
      });
  });
}

/**
 *    Execute a test for Electron. This will create a new browser window and load the HTML
 *   provided in the request. It will then execute the provided HTML code.
 * @param request The request to execute
 */
async function testElectron(
  connection: HubConnection,
  request: IPerformTestRequest
) {
  console.log(`Performing test using Electron ${request.id}`);
  const window = new BrowserWindow({
    show: false,
    width: request.settings.width,
    height: request.settings.height,
    webPreferences: {
      devTools: false,
    },
  });
  await window.loadURL(`data:text/html,${request.html}`);
  window.show();
  const buffer = await captureScreenshotToBytes(window, request.settings);
  connection
    .invoke('ReportResult', {
      id: request.id,
      appType: 'electron',
      resultImage: buffer.toJSON().data,
    } as IPerformTestResult)
    .catch((error) => {
      console.log(`Test for Electron ${request.id} failed: ${error}`);
    })
    .finally(() => {
      console.log(`Test for Electron ${request.id} completed`);
      window.close();
    });
}

async function sendBufferData() {}
