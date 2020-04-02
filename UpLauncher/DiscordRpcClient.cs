using DiscordRPC.Message;
using System;
using System.Text;
using System.Threading;
using DiscordRPC;

namespace DiscordRPC.TDUWorld
{
    public class Discord
    {
        private static Logging.LogLevel logLevel = Logging.LogLevel.Trace;
        private static int discordPipe = -1;

        private static RichPresence start = new RichPresence()
        {
            Details = "Launcher Run",
            State = "Playing TDU World",
            Assets = new Assets()
            {
                LargeImageKey = "logo-bg",
                LargeImageText = "TDU World",
                SmallImageKey = ""
            }
        };

        private static DiscordRpcClient client;
        private static bool isRunning = true;
        private static StringBuilder word = new StringBuilder();

       public static void run(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-pipe":
                        discordPipe = int.Parse(args[++i]);
                        break;

                    default: break;
                }
            }
            EnableRPC();
        }

        //Main Loop
        static void EnableRPC()
        {
            var client = new DiscordRpcClient("qrwjV3iEScjqcY3MCA5y4rk9YpvCJeOb", pipe: discordPipe)
            {
                Logger = new Logging.ConsoleLogger(logLevel, true)
            };

            client.OnReady += (sender, msg) =>
            {
            };

            client.OnPresenceUpdate += (sender, msg) =>
            {
            };

            client.Initialize();

            client.SetPresence(new RichPresence()
            {
                Details = "test",
                State = "In Game",
                Timestamps = Timestamps.FromTimeSpan(10)
            });
            client.Dispose();
        }
    }
}