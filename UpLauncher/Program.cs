using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using UpLauncher;
using UpLauncher.authemu;
using Logging;
using System.Threading;
using DiscordRPC;
using DiscordRPC.Message;
using System.Text;

namespace UpLauncher
{
    static class Program
    {
        private static DiscordRpcClient client;
        private static DiscordRPC.Logging.LogLevel logLevel = DiscordRPC.Logging.LogLevel.Trace;
        private static int discordPipe = -1;

        public static RichPresence start = new RichPresence()
        {
            Details = "Playing TDU World",
            State = " Game Launcher Started ",
            Assets = new Assets()
            {
                LargeImageKey = "logo-bg",
                LargeImageText = "Test Drive Unlimited 2",
                SmallImageKey = ""
            }
        };
        public static RichPresence online = new RichPresence()
        {
            Details = "Playing TDU World",
            State = "Playing in Online Mode",
            Assets = new Assets()
            {
                LargeImageKey = "logo-bg",
                LargeImageText = "Test Drive Unlimited 2",
                SmallImageKey = ""
            }
        };
        public static RichPresence offline = new RichPresence()
        {
            Details = "Playing TDU World",
            State = "Playing in Offline Mode",
            Assets = new Assets()
            {
                LargeImageKey = "logo-bg",
                LargeImageText = "Test Drive Unlimited 2",
                SmallImageKey = ""
            }
        };
        public static RichPresence unknown = new RichPresence()
        {
            Details = "Playing TDU World",
            State = " Unknown Gamestate ",
            Assets = new Assets()
            {
                LargeImageKey = "logo-bg",
                LargeImageText = "Test Drive Unlimited 2",
                SmallImageKey = ""
            }
        };
        public static RichPresence gameupdate = new RichPresence()
        {
            Details = "Playing TDU World",
            State = " Updating Game Files ",
            Assets = new Assets()
            {
                LargeImageKey = "logo-bg",
                LargeImageText = "Test Drive Unlimited 2",
                SmallImageKey = ""
            }
        };

        [STAThread]
        static void Main()
        {
            SetRPCTime();
            client = new DiscordRpcClient("690064387993894952", pipe: discordPipe)
            {
                Logger = new DiscordRPC.Logging.ConsoleLogger(logLevel, true)
            };

            Thread thread2 = new Thread(EnableRPC);
            thread2.Start();
            UpdateRPC(start);
            ///Looger
            Logger log = new Logger();
            log.CheckLogs();

            ///Server Emu
            Thread thread1 = new Thread(ServerCore.StartListener);
            thread1.Start();

            ///Launcher Thread
            System.Threading.Thread.Sleep(20);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Launcher());
            client.Dispose();
        }

        //Crazy this will enable the Discord RPC
        public static void EnableRPC()
        {
            client.Initialize();
        }

        //Called on Launcher Updates Gamemode Updates etc..
        public static void UpdateRPC(RichPresence state)
        {
            client.SetPresence(state);
        }

        //Set Starttime to Rpc
        public static void SetRPCTime()
        {
            start.Timestamps = new Timestamps()
            {
                Start = DateTime.UtcNow,
            };
            online.Timestamps = new Timestamps()
            {
                Start = DateTime.UtcNow,
            };
            offline.Timestamps = new Timestamps()
            {
                Start = DateTime.UtcNow,
            };
            unknown.Timestamps = new Timestamps()
            {
                Start = DateTime.UtcNow,
            };
            gameupdate.Timestamps = new Timestamps()
            {
                Start = DateTime.UtcNow,
            };
        }
    }
}