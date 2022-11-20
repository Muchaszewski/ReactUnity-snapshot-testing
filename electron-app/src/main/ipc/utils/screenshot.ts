import { BrowserWindow } from "electron";
import path from "path";
import fs from "fs";
import os from "os";

export function takeScreenshot(event : Electron.IpcMainEvent, arg : any){
    const win = BrowserWindow.fromWebContents(event.sender);
    if (win) {
      win.webContents.capturePage().then((image) => {
        const screenshotPath = path.join(os.tmpdir(), 'screenshot.png');
        fs.writeFileSync(screenshotPath, image.toPNG());
        event.reply('screenshot', screenshotPath);
      });
    }
  }