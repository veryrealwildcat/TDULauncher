using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Windows;
using TDUWorldLauncher;
using Logging;

namespace TDUWorldLauncher.AuthEmu
{
    public class ServerCore
    {
        public static bool Firststart = false;
        public static int count = 0;
        public static void StartListener()
        {
            Logger _log = new Logger();
            UdpClient client = new UdpClient(8889);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 8889);
            try
            {
                _log.print("Game Connected");
                while (true)
                {
                    byte[] bytes = client.Receive(ref groupEP);
                    if(count != 1)
                    {
                        SendLogin(groupEP, client);
                        _log.print("Loggin Thred");
                    }
                    else
                    {
                        AntiTimeOut(groupEP, client);
                        _log.print("Timeout Thread");
                    }
                }
            }
            catch (SocketException e)
            {
                _log.print("Thread Crashed: " + e.ToString());
            }
        }

        public static void AntiTimeOut(IPEndPoint cSock, UdpClient client)
        {
            Logger _log = new Logger();
            client.Send(Resources.InitCasino1, Resources.InitCasino1.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InitCasino2, Resources.InitCasino2.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino1, Resources.InCasino1.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino2, Resources.InCasino2.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino3, Resources.InCasino3.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino4, Resources.InCasino4.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino5, Resources.InCasino5.Length, cSock);
            //    cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino6, Resources.InCasino6.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino7, Resources.InCasino7.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino8, Resources.InCasino8.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino9, Resources.InCasino9.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino10, Resources.InCasino10.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino11, Resources.InCasino11.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino12, Resources.InCasino12.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino13, Resources.InCasino13.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino14, Resources.InCasino14.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino15, Resources.InCasino15.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino16, Resources.InCasino16.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino17, Resources.InCasino17.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino18, Resources.InCasino18.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino19, Resources.InCasino19.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino20, Resources.InCasino20.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino21, Resources.InCasino21.Length, cSock);
            // cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.Test, Resources.Test.Length, cSock);
            client.Send(Resources.InitCasino1, Resources.InitCasino1.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InitCasino2, Resources.InitCasino2.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino1, Resources.InCasino1.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino2, Resources.InCasino2.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino3, Resources.InCasino3.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino4, Resources.InCasino4.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino5, Resources.InCasino5.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino6, Resources.InCasino6.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino7, Resources.InCasino7.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino8, Resources.InCasino8.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino9, Resources.InCasino9.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino10, Resources.InCasino10.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino11, Resources.InCasino11.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino12, Resources.InCasino12.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino13, Resources.InCasino13.Length, cSock);
            // cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino14, Resources.InCasino14.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino15, Resources.InCasino15.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino16, Resources.InCasino16.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino17, Resources.InCasino17.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino18, Resources.InCasino18.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino19, Resources.InCasino19.Length, cSock);
            // cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino20, Resources.InCasino20.Length, cSock);
            //    cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.InCasino21, Resources.InCasino21.Length, cSock);

            client.Send(Resources.Server31, Resources.Server31.Length, cSock);
            client.Send(Resources.Server32, Resources.Server32.Length, cSock);
            client.Send(Resources.InitCasino1, Resources.InitCasino1.Length, cSock);
            client.Send(Resources.InitCasino2, Resources.InitCasino2.Length, cSock);
            client.Send(Resources.InCasino1, Resources.InCasino1.Length, cSock);
            client.Send(Resources.InCasino2, Resources.InCasino2.Length, cSock);
            client.Send(Resources.InCasino3, Resources.InCasino3.Length, cSock);
            client.Send(Resources.InCasino4, Resources.InCasino4.Length, cSock);
            client.Send(Resources.InCasino5, Resources.InCasino5.Length, cSock);
            client.Send(Resources.InCasino6, Resources.InCasino6.Length, cSock);
            client.Send(Resources.InCasino7, Resources.InCasino7.Length, cSock);
            client.Send(Resources.InCasino8, Resources.InCasino8.Length, cSock);
            client.Send(Resources.InCasino9, Resources.InCasino9.Length, cSock);
            client.Send(Resources.InCasino10, Resources.InCasino10.Length, cSock);
            client.Send(Resources.InCasino11, Resources.InCasino11.Length, cSock);
            client.Send(Resources.InCasino12, Resources.InCasino12.Length, cSock);
            client.Send(Resources.InCasino13, Resources.InCasino13.Length, cSock);
            client.Send(Resources.InCasino14, Resources.InCasino14.Length, cSock);
            client.Send(Resources.InCasino15, Resources.InCasino15.Length, cSock);
            client.Send(Resources.InCasino16, Resources.InCasino16.Length, cSock);
            client.Send(Resources.InCasino17, Resources.InCasino17.Length, cSock);
            client.Send(Resources.InCasino18, Resources.InCasino18.Length, cSock);
            client.Send(Resources.InCasino19, Resources.InCasino19.Length, cSock);
            client.Send(Resources.InCasino20, Resources.InCasino20.Length, cSock);
            client.Send(Resources.InCasino21, Resources.InCasino21.Length, cSock);
            Thread.Sleep(20);
            count = count + 1;
            _log.print("Client is Here");
        }

        public static void SendLogin(IPEndPoint cSock, UdpClient client)
        {
                Logger _log = new Logger();
                _log.print("Client Login");
                client.Send(Resources.Server1, Resources.Server1.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server2, Resources.Server2.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server3, Resources.Server3.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server4, Resources.Server4.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server5, Resources.Server5.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server6, Resources.Server6.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server7, Resources.Server7.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server8, Resources.Server8.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server9, Resources.Server9.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server10, Resources.Server10.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server11, Resources.Server11.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server12, Resources.Server12.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server13, Resources.Server13.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server14, Resources.Server14.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server15, Resources.Server15.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server16, Resources.Server16.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server17, Resources.Server17.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server18, Resources.Server18.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server19, Resources.Server19.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server20, Resources.Server20.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server21, Resources.Server21.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server22, Resources.Server22.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server23, Resources.Server23.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server24, Resources.Server24.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server25, Resources.Server25.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server26, Resources.Server26.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server27, Resources.Server27.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server28, Resources.Server28.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server29, Resources.Server29.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server30, Resources.Server30.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server31, Resources.Server31.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.Server32, Resources.Server32.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InitCasino1, Resources.InitCasino1.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InitCasino2, Resources.InitCasino2.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino1, Resources.InCasino1.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino2, Resources.InCasino2.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino3, Resources.InCasino3.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino4, Resources.InCasino4.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino5, Resources.InCasino5.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino6, Resources.InCasino6.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino7, Resources.InCasino7.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino8, Resources.InCasino8.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino9, Resources.InCasino9.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino10, Resources.InCasino10.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino11, Resources.InCasino11.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino12, Resources.InCasino12.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino13, Resources.InCasino13.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino14, Resources.InCasino14.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino15, Resources.InCasino15.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino16, Resources.InCasino16.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino17, Resources.InCasino17.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino18, Resources.InCasino18.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino19, Resources.InCasino19.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino20, Resources.InCasino20.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.InCasino21, Resources.InCasino21.Length, cSock);
                Thread.Sleep(35);
                _log.print("Client Login Done");
                AntiTimeOut(cSock, client);
        }

        public static void SocketDispose()
        {
            SocketDispose();
        }
    }
}
