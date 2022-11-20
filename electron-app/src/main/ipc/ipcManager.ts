import { ipcMain, BrowserWindow } from "electron";
import { takeScreenshot } from "./utils/screenshot";
import fs from 'fs';
import path from "path";
import * as Babel from "@babel/standalone";

export function registerIpcMain() {
    ipcMain.on('ipc-example', async (event, arg) => {
        // const msgTemplate = (pingPong: string) => `IPC test: ${pingPong}`;
        // console.log(msgTemplate(arg));
        // // load file from disk 
        // console.log(__dirname);
        // console.log(path.join(__dirname, '../../../assets/unity.html'))
        // let browser = new BrowserWindow({
        //   width: 1280,
        //   height: 900,
        //   webPreferences: {
        //     devTools: false
        //     }
        // });
        //  await browser.loadURL("file://"+path.join(__dirname, '../../../assets/unity.html'));
        // event.reply('ipc-example', msgTemplate('pong'));

        // // check if unity is loaded as a loop
        // while (true) {
        //     if (!await browser.webContents.executeJavaScript('isUnityInstanceLoaded')) {
        //         // wait for 100 ms
        //         await new Promise(resolve => setTimeout(resolve, 100));
        //     } else {
        //         break;
        //     }
        // }
        // await new Promise(resolve => setTimeout(resolve, 2000));
        // const unityData = `import { Renderer } from '@reactunity/renderer';

        // function Hello() {
        //   return <h1>Hello, world</h1>;
        // }

        // Renderer.render(<Hello />);
        // `
        // type TransformFn = (x: string) => string | null | undefined;
        // const identity: TransformFn = x => x;
        // const transformJsxToES5: TransformFn = (code: string) => Babel.transform(code, { presets: ['es2015', 'react'] }).code;
        // const code = transformJsxToES5(unityData)?.replaceAll("\n", "\\n").replaceAll("\"", "\\\"");
        // await browser.webContents.executeJavaScript(
        //   `
        //   console.log("${code}");
        //   unityInstance.SendMessage("ReactCanvas", "SetJSX", "${code}"); 
        //   console.log("sent message")
        //   unityInstance.SendMessage("ReactCanvas", "RenderBridge");
        //   `);


      });
    ipcMain.on('screenshot', takeScreenshot);
}