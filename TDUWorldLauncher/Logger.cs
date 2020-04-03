using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class Logger
    {
        string LogPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/TDU_WORLD" + "/LOGS/";

        public void CheckLogs()
        {
            if (File.Exists(LogPath + "output.log"))
            {
                Logrotate();
            }
            else
            {
                Directory.CreateDirectory(LogPath);
            }
        }

        private void Logrotate()
        {
            if (!File.Exists(LogPath + "output.log")) return;
            File.Delete(LogPath + "last.log");
            System.Threading.Thread.Sleep(20);
            File.Copy(LogPath + "output.log", LogPath + "last.log");
            System.Threading.Thread.Sleep(20);
            File.Delete(LogPath + "output.log");
            System.Threading.Thread.Sleep(20);
        }

        public void Print(string input)
        {
            var fs = new FileStream(LogPath + "output.log", FileMode.Append, FileAccess.Write, FileShare.Write);
            fs.Close();
            var sw = new StreamWriter(LogPath + "output.log", true, Encoding.ASCII);
            sw.Write(DateTime.Now.ToString("HH:mm:ss->") + "ORB: " + input.ToString() + " \n");
            sw.Close();
        }
    }
}