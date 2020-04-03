using System;
using System.IO;

namespace TDUWorldLauncher
{
    class Statistics
    {
        public static bool CanRun = true;

        public static string GameKey;

        public static void CheckData()
        {
            if (!File.Exists("TDU_World.localdb"))
            {
                File.Create("TDU_World.localdb");
                GameKey = File.ReadAllText("key.txt");
                CanRun = true;
                File.WriteAllText("TDU_World.localdb", GameKey);

                Console.WriteLine(GameKey);
            }
            else
            {
                CanRun = true;
            }
        }
    }
}