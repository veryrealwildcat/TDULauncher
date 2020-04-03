using System;
using System.Threading;
using DiscordRPC;
using TDUWorldLauncher.AuthEmu;

namespace TDUWorldLauncher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private static DiscordRpcClient _client;
        private const DiscordRPC.Logging.LogLevel LogLevel = DiscordRPC.Logging.LogLevel.Trace;
        private const int DiscordPipe = -1;

        public static readonly RichPresence Start = new RichPresence
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
        public static readonly RichPresence Online = new RichPresence
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
        public static readonly RichPresence Offline = new RichPresence
        {
            Details = "Playing TDU World",
            State = "Playing in Offline Mode",
            Assets = new Assets
            {
                LargeImageKey = "logo-bg",
                LargeImageText = "Test Drive Unlimited 2",
                SmallImageKey = ""
            }
        };

        public static readonly RichPresence Unknown = new RichPresence
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

        public static readonly RichPresence GameUpdate = new RichPresence
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
        private static void Main()
        {
            SetRpcTime();
            _client = new DiscordRpcClient("690064387993894952", pipe: DiscordPipe)
            {
                Logger = new DiscordRPC.Logging.ConsoleLogger(LogLevel, true)
            };

            var thread2 = new Thread(EnableRpc);
            thread2.Start();
            UpdateRpc(Start);
            
            //Looger
            var log = new Logger();
            log.CheckLogs();

            //Server Emu
            var thread1 = new Thread(ServerCore.StartListener);
            thread1.Start();

            //Launcher Thread
            Thread.Sleep(20);
            var app = new App();
            app.InitializeComponent();
            app.Run();
            _client.Dispose();
        }

        //Crazy this will enable the Discord RPC
        private static void EnableRpc()
        {
            _client.Initialize();
        }

        //Called on Launcher Updates Gamemode Updates etc..
        public static void UpdateRpc(RichPresence state)
        {
            _client.SetPresence(state);
        }

        //Set Starttime to Rpc
        private static void SetRpcTime()
        {
            Start.Timestamps = new Timestamps()
            {
                Start = DateTime.UtcNow,
            };
            Online.Timestamps = new Timestamps()
            {
                Start = DateTime.UtcNow,
            };
            Offline.Timestamps = new Timestamps()
            {
                Start = DateTime.UtcNow,
            };
            Unknown.Timestamps = new Timestamps()
            {
                Start = DateTime.UtcNow,
            };
            GameUpdate.Timestamps = new Timestamps()
            {
                Start = DateTime.UtcNow,
            };
        }
    }
}