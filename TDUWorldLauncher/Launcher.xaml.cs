using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DiscordRPC;

namespace TDUWorldLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Launcher
    {
        private static string _multiplayerVersion;
        private int _mouseX = 0, _mouseY = 0;
        private bool _mouseDown;

        private string _ip;
        private string _gameType = "957e4cc3";
        private bool _pingChecked;
        private int _state;
        private bool _p;
        private System.ComponentModel.IContainer components = null;
        private readonly string _gameDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/";
        private RichPresence _stateRpc = App.Offline;
        public Launcher()
        {
            InitializeComponent();
            //ReadMultiplayer();
            ReadIp();
            CheckServer();

            if (_pingChecked && _state == 1)
            {
                Label3.Content = "Online";
                Label3.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#39b54a");
                ServerStatus.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#39b54a");
            }
            if (_pingChecked && _state == 2)
            {
                Label3.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000");
                Label3.Content = "Offline";
                ServerStatus.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000");
            }
            if (_pingChecked && _state == 3)
            {
                Label3.Content = "Unknown";
                Label3.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#808080");
                ServerStatus.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#808080");
            }
            if (_pingChecked && _state == 4)
            {
                Label3.Content = "Updating";
                Label3.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#f15a24");
                ServerStatus.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#f15a24");
            }
            //WebBrowser.Source = new Uri("https://tduworld.com/");
        }

        public void ReadMultiplayer()
        {
            using var client = new WebClient();
            var s = client.DownloadString("https://pastebin.com/raw/UymbytZy");
            _multiplayerVersion = s;
        }

        private void CheckServer()
        {
            _pingChecked = true;
            var pingable = false;
            Ping pinger = null;
            try
            {
                pinger = new Ping();
                var reply = pinger.Send(_ip);
                if (reply == null) return;
                pingable = reply.Status == IPStatus.Success;
                switch (reply.Status)
                {
                    case IPStatus.Success:
                        _stateRpc = App.Online;
                        _gameType = "44938b8f";
                        _state = 1;
                        break;
                    case IPStatus.TimedOut:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Offline";
                        _gameType = "957e4cc3";
                        _state = 2;
                        break;
                    case IPStatus.Unknown:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.DestinationNetworkUnreachable:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.DestinationHostUnreachable:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.DestinationProhibited:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.DestinationPortUnreachable:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.NoResources:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.BadOption:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.HardwareError:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.PacketTooBig:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.BadRoute:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.TtlExpired:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.TtlReassemblyTimeExceeded:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.ParameterProblem:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.SourceQuench:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.BadDestination:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.DestinationUnreachable:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.TimeExceeded:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.BadHeader:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.UnrecognizedNextHeader:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.IcmpError:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    case IPStatus.DestinationScopeMismatch:
                        _stateRpc = App.Offline;
                        App.Start.Details = "Server Unknown";
                        _gameType = "957e4cc3";
                        _state = 3;
                        break;
                    default:
                        _stateRpc = App.GameUpdate;
                        App.GameUpdate.Details = "Server Updating";
                        _gameType = "957e4cc3";
                        _state = 4;
                        break;
                }
            }
            catch (PingException)
            {
            }
            finally
            {
                pinger?.Dispose();
            }
        }

        private void Run()
        {
            App.UpdateRpc(_stateRpc);
            if (string.IsNullOrEmpty(_gameDir)) return;
            try
            {
                PlayBtn.IsEnabled = false;

                if (File.Exists(_gameDir + "TestDrive2.exe"))
                {
                    Mutex mutex1 = null;
                    if (_p)
                    {
                        bool createdNew;
                        mutex1 = new Mutex(false, _gameType, out createdNew);
                        if (!createdNew)
                            return;
                    }
                }

                var process = new Process
                {
                    StartInfo = {Arguments = _gameType, WorkingDirectory = _gameDir, FileName = "TestDrive2.exe"}
                };
                Process.Start("TestDrive2.exe");
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                Console.Write(ex);
                MessageBox.Show("TestDrive2.exe not found\nPlease, download the game from Steam.");
                PlayBtn.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                PlayBtn.IsEnabled = true;
            }
        }

        private void ReadIp()
        {
            //this.VersionDate.Text = MultiplayerVersion;
            if (File.Exists(_gameDir + "Server.dat"))
            {
                _ip = File.ReadAllText(_gameDir + "Server.dat");
            }
            else
            {
                //DEROLE - Causes file in use exceptions and not needed as WriteAllText will create the file for you if it doesnt exist
                //File.Create(GameDir + "Server.dat");
                //DEROLE - Removed unnessasary brackets round directory
                File.WriteAllText(_gameDir + "Server.dat", "133.133.133.133");
                //DEROLE - Reads back file so IP address is set automatically instead of having to restart application
                _ip = File.ReadAllText(_gameDir + "Server.dat");
            }
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            _p = true;
            Run();
        }

        private void Close_Btn(object sender, EventArgs e)
        {
            //ServerCore.SocketDispose();
            Application.Current.Shutdown();
        }

        private void PanelMove_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Minimize_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState =  WindowState.Minimized;
        }
    }
}