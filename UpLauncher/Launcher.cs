using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace UpLauncher
{
    public partial class Launcher : Form
    {
        public static string MultiplayerVersion;
        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        public Launcher()
        {
            InitializeComponent();
            //ReadMultiplayer();
            ReadIP();

            CheckServer();

            play_BTN.Click += Play_BTN_Click;

            if (PingChecked == true && State == 1)
            {
                label3.Text = "Online";
                label3.ForeColor = System.Drawing.Color.Green;
                pictureBox4.Visible = true; //Online Dot


                pictureBox3.Visible = false;
                pictureBox5.Visible = false;
            }
            if (PingChecked == true && State == 2)
            {
                label3.ForeColor = System.Drawing.Color.Red;
                label3.Text = "Offline";
                pictureBox3.Visible = true;

                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
            }
            if (PingChecked == true && State == 3)
            {
                label3.Text = "Unknown";
                label3.ForeColor = System.Drawing.Color.Silver;
                pictureBox5.Visible = true;

                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
            }
            webControl1.Source = new Uri("https://tduworld.com/");
        }

        public void ReadMultiplayer()
        {
            using (WebClient client = new WebClient())
            {
                string s = client.DownloadString("https://pastebin.com/raw/UymbytZy");
                MultiplayerVersion = s.ToString();
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 500;
                mouseY = MousePosition.Y - 10;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void minimize_MouseClick(object sender, MouseEventArgs e)
        {
            WindowState =  FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }
    }
}