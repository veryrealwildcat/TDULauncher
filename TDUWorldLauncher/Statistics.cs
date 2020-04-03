using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

namespace TDUWorldLauncher
{
    class Statistics
    {
        public static bool canRun = true;

        public static string GameKey;

        public static void CheckData()
        {
            if (!File.Exists("TDU_World.localdb"))
            {
                File.Create("TDU_World.localdb");
                GameKey = File.ReadAllText("key.txt");
                canRun = true;
                File.WriteAllText("TDU_World.localdb", GameKey.ToString());

                Console.WriteLine(GameKey);
            }
            else
            {
                canRun = true;
            }
        }
    }
}