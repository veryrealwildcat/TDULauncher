using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using CefSharp;
using CefSharp.Wpf;
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

        public App()
        {
            //Add Custom assembly resolver
            AppDomain.CurrentDomain.AssemblyResolve += Resolver;

            //Any CefSharp references have to be in another method with NonInlining
            // attribute so the assembly rolver has time to do it's thing.
            InitializeCefSharp();
        }
        
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
        
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void InitializeCefSharp()
        {
            var settings = new CefSettings();

            // Set BrowserSubProcessPath based on app bitness at runtime
            settings.BrowserSubprocessPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                Environment.Is64BitProcess ? "x64" : "x86",
                "CefSharp.BrowserSubprocess.exe");

            // Make sure you set performDependencyCheck false
            Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);
        }

        // Will attempt to load missing assembly from either x86 or x64 subdir
        // Required by CefSharp to load the unmanaged dependencies when running using AnyCPU
        private static Assembly Resolver(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("CefSharp"))
            {
                var assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
                var archSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                    Environment.Is64BitProcess ? "x64" : "x86",
                    assemblyName);

                return File.Exists(archSpecificPath)
                    ? Assembly.LoadFile(archSpecificPath)
                    : null;
            }

            return null;
        }
    }
}