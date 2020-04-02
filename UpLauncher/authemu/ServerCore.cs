using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using UpLauncher.Properties;
using Logging;

namespace UpLauncher.authemu
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
            client.Send(Resources.initCasino1, Resources.initCasino1.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.initCasino2, Resources.initCasino2.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino1, Resources.inCasino1.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino2, Resources.inCasino2.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino3, Resources.inCasino3.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino4, Resources.inCasino4.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino5, Resources.inCasino5.Length, cSock);
            //    cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino6, Resources.inCasino6.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino7, Resources.inCasino7.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino8, Resources.inCasino8.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino9, Resources.inCasino9.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino10, Resources.inCasino10.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino11, Resources.inCasino11.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino12, Resources.inCasino12.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino13, Resources.inCasino13.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino14, Resources.inCasino14.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino15, Resources.inCasino15.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino16, Resources.inCasino16.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino17, Resources.inCasino17.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino18, Resources.inCasino18.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino19, Resources.inCasino19.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino20, Resources.inCasino20.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino21, Resources.inCasino21.Length, cSock);
            // cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.test, Resources.test.Length, cSock);
            client.Send(Resources.initCasino1, Resources.initCasino1.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.initCasino2, Resources.initCasino2.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino1, Resources.inCasino1.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino2, Resources.inCasino2.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino3, Resources.inCasino3.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino4, Resources.inCasino4.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino5, Resources.inCasino5.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino6, Resources.inCasino6.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino7, Resources.inCasino7.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino8, Resources.inCasino8.Length, cSock);
            //   cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino9, Resources.inCasino9.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino10, Resources.inCasino10.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino11, Resources.inCasino11.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino12, Resources.inCasino12.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino13, Resources.inCasino13.Length, cSock);
            // cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino14, Resources.inCasino14.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino15, Resources.inCasino15.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino16, Resources.inCasino16.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino17, Resources.inCasino17.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino18, Resources.inCasino18.Length, cSock);
            //  cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino19, Resources.inCasino19.Length, cSock);
            // cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino20, Resources.inCasino20.Length, cSock);
            //    cSock.data = client.Receive(ref cSock.endPoint);
            client.Send(Resources.inCasino21, Resources.inCasino21.Length, cSock);

            client.Send(Resources.server31, Resources.server31.Length, cSock);
            client.Send(Resources.server32, Resources.server32.Length, cSock);
            client.Send(Resources.initCasino1, Resources.initCasino1.Length, cSock);
            client.Send(Resources.initCasino2, Resources.initCasino2.Length, cSock);
            client.Send(Resources.inCasino1, Resources.inCasino1.Length, cSock);
            client.Send(Resources.inCasino2, Resources.inCasino2.Length, cSock);
            client.Send(Resources.inCasino3, Resources.inCasino3.Length, cSock);
            client.Send(Resources.inCasino4, Resources.inCasino4.Length, cSock);
            client.Send(Resources.inCasino5, Resources.inCasino5.Length, cSock);
            client.Send(Resources.inCasino6, Resources.inCasino6.Length, cSock);
            client.Send(Resources.inCasino7, Resources.inCasino7.Length, cSock);
            client.Send(Resources.inCasino8, Resources.inCasino8.Length, cSock);
            client.Send(Resources.inCasino9, Resources.inCasino9.Length, cSock);
            client.Send(Resources.inCasino10, Resources.inCasino10.Length, cSock);
            client.Send(Resources.inCasino11, Resources.inCasino11.Length, cSock);
            client.Send(Resources.inCasino12, Resources.inCasino12.Length, cSock);
            client.Send(Resources.inCasino13, Resources.inCasino13.Length, cSock);
            client.Send(Resources.inCasino14, Resources.inCasino14.Length, cSock);
            client.Send(Resources.inCasino15, Resources.inCasino15.Length, cSock);
            client.Send(Resources.inCasino16, Resources.inCasino16.Length, cSock);
            client.Send(Resources.inCasino17, Resources.inCasino17.Length, cSock);
            client.Send(Resources.inCasino18, Resources.inCasino18.Length, cSock);
            client.Send(Resources.inCasino19, Resources.inCasino19.Length, cSock);
            client.Send(Resources.inCasino20, Resources.inCasino20.Length, cSock);
            client.Send(Resources.inCasino21, Resources.inCasino21.Length, cSock);
            Thread.Sleep(20);
            count = count + 1;
            _log.print("Client is Here");
        }

        public static void SendLogin(IPEndPoint cSock, UdpClient client)
        {
                Logger _log = new Logger();
                _log.print("Client Login");
                client.Send(Resources.server1, Resources.server1.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server2, Resources.server2.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server3, Resources.server3.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server4, Resources.server4.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server5, Resources.server5.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server6, Resources.server6.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server7, Resources.server7.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server8, Resources.server8.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server9, Resources.server9.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server10, Resources.server10.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server11, Resources.server11.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server12, Resources.server12.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server13, Resources.server13.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server14, Resources.server14.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server15, Resources.server15.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server16, Resources.server16.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server17, Resources.server17.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server18, Resources.server18.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server19, Resources.server19.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server20, Resources.server20.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server21, Resources.server21.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server22, Resources.server22.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server23, Resources.server23.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server24, Resources.server24.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server25, Resources.server25.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server26, Resources.server26.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server27, Resources.server27.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server28, Resources.server28.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server29, Resources.server29.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server30, Resources.server30.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server31, Resources.server31.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.server32, Resources.server32.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.initCasino1, Resources.initCasino1.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.initCasino2, Resources.initCasino2.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino1, Resources.inCasino1.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino2, Resources.inCasino2.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino3, Resources.inCasino3.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino4, Resources.inCasino4.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino5, Resources.inCasino5.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino6, Resources.inCasino6.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino7, Resources.inCasino7.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino8, Resources.inCasino8.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino9, Resources.inCasino9.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino10, Resources.inCasino10.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino11, Resources.inCasino11.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino12, Resources.inCasino12.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino13, Resources.inCasino13.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino14, Resources.inCasino14.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino15, Resources.inCasino15.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino16, Resources.inCasino16.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino17, Resources.inCasino17.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino18, Resources.inCasino18.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino19, Resources.inCasino19.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino20, Resources.inCasino20.Length, cSock);
                Thread.Sleep(35);
                client.Send(Resources.inCasino21, Resources.inCasino21.Length, cSock);
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
