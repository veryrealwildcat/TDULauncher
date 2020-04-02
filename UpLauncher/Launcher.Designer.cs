using System;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Web;
using UpLauncher;
using System.Net.NetworkInformation;
using UpLauncher.authemu;
using DiscordRPC;

namespace UpLauncher
{
    partial class Launcher
    {
        public string IP;
        public string GameType = "957e4cc3";
        private bool PingChecked;
        private int State;
        private bool p;
        private System.ComponentModel.IContainer components = null;
        private string GameDir = (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/");
        public RichPresence stateRpc = Program.offline;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            
        }

        #region Vom Windows Form-Designer generierter Code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.play_BTN = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.GameVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.webControl1 = new Awesomium.Windows.Forms.WebControl(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.Button();
            this.minimize = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.update1 = new System.Windows.Forms.ProgressBar();
            this.update2 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // play_BTN
            // 
            this.play_BTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.play_BTN.BackColor = System.Drawing.Color.Transparent;
            this.play_BTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("play_BTN.BackgroundImage")));
            this.play_BTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.play_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.play_BTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.play_BTN.FlatAppearance.BorderSize = 0;
            this.play_BTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.play_BTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.play_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.play_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.play_BTN.ForeColor = System.Drawing.Color.Transparent;
            this.play_BTN.Image = ((System.Drawing.Image)(resources.GetObject("play_BTN.Image")));
            this.play_BTN.Location = new System.Drawing.Point(786, 493);
            this.play_BTN.Name = "play_BTN";
            this.play_BTN.Size = new System.Drawing.Size(214, 73);
            this.play_BTN.TabIndex = 0;
            this.play_BTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.play_BTN.UseMnemonic = false;
            this.play_BTN.UseVisualStyleBackColor = false;
            this.play_BTN.Click += new System.EventHandler(this.Play_BTN_Click);
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.Transparent;
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(64, 65);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(295, 144);
            this.logo.TabIndex = 1;
            this.logo.TabStop = false;
            // 
            // GameVersion
            // 
            this.GameVersion.AutoSize = true;
            this.GameVersion.BackColor = System.Drawing.Color.Transparent;
            this.GameVersion.Font = new System.Drawing.Font("Calibri", 12F);
            this.GameVersion.ForeColor = System.Drawing.SystemColors.GrayText;
            this.GameVersion.Image = ((System.Drawing.Image)(resources.GetObject("GameVersion.Image")));
            this.GameVersion.Location = new System.Drawing.Point(14, 552);
            this.GameVersion.Name = "GameVersion";
            this.GameVersion.Size = new System.Drawing.Size(361, 19);
            this.GameVersion.TabIndex = 4;
            this.GameVersion.Text = "TDU2 DLC2 v034 build 16 | TDU World Launcher v0.01";
            this.GameVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 13F);
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(13, 445);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Server Status:";
            // 
            // webControl1
            // 
            this.webControl1.BackColor = System.Drawing.Color.Black;
            this.webControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("webControl1.BackgroundImage")));
            this.webControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.webControl1.Location = new System.Drawing.Point(437, 141);
            this.webControl1.Size = new System.Drawing.Size(551, 287);
            this.webControl1.TabIndex = 8;
            this.webControl1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(424, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(576, 377);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 470);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1016, 115);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // close
            // 
            this.close.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.close.BackColor = System.Drawing.Color.Transparent;
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.close.FlatAppearance.BorderSize = 0;
            this.close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.White;
            this.close.Image = ((System.Drawing.Image)(resources.GetObject("close.Image")));
            this.close.Location = new System.Drawing.Point(975, 9);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(31, 31);
            this.close.TabIndex = 11;
            this.close.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.close.UseMnemonic = false;
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Btn);
            // 
            // minimize
            // 
            this.minimize.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.minimize.BackColor = System.Drawing.Color.Transparent;
            this.minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.minimize.FlatAppearance.BorderSize = 0;
            this.minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimize.ForeColor = System.Drawing.Color.White;
            this.minimize.Image = global::UpLauncher.Properties.Resources.Minimize_button;
            this.minimize.Location = new System.Drawing.Point(940, 11);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(29, 30);
            this.minimize.TabIndex = 12;
            this.minimize.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.minimize.UseMnemonic = false;
            this.minimize.UseVisualStyleBackColor = false;
            this.minimize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.minimize_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.label2.ForeColor = System.Drawing.Color.Ivory;
            this.label2.Location = new System.Drawing.Point(420, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "  TDU World Launcher";
            // 
            // update1
            // 
            this.update1.Location = new System.Drawing.Point(17, 493);
            this.update1.Name = "update1";
            this.update1.Size = new System.Drawing.Size(746, 16);
            this.update1.TabIndex = 14;
            // 
            // update2
            // 
            this.update2.Location = new System.Drawing.Point(17, 524);
            this.update2.Name = "update2";
            this.update2.Size = new System.Drawing.Size(746, 16);
            this.update2.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.minimize);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 39);
            this.panel1.TabIndex = 16;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(129, 447);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 14F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(156, 445);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "Offline";
            this.label3.UseMnemonic = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Location = new System.Drawing.Point(130, 447);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 20);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 19;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox5.Location = new System.Drawing.Point(129, 448);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 20);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox5.TabIndex = 20;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(786, 493);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(214, 73);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox6.TabIndex = 21;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Visible = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.BackgroundImage")));
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(786, 493);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(214, 73);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox7.TabIndex = 22;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Visible = false;
            // 
            // Launcher
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(71)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1016, 585);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.update2);
            this.Controls.Add(this.update1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.GameVersion);
            this.Controls.Add(this.webControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.play_BTN);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Green;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Launcher";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TDU World Launcher";
            this.TransparencyKey = System.Drawing.Color.LightPink;
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void ReadIP()
        {
            //this.VersionDate.Text = MultiplayerVersion;
            if (File.Exists(GameDir + "Server.dat"))
            {
                IP = File.ReadAllText(GameDir + "Server.dat");
            }
            else
            {
                //DEROLE - Causes file in use exceptions and not needed as WriteAllText will create the file for you if it doesnt exist
                //File.Create(GameDir + "Server.dat");
                //DEROLE - Removed unnessasary brackets round directory
                File.WriteAllText(GameDir + "Server.dat", "133.133.133.133");
                //DEROLE - Reads back file so IP address is set automatically instead of having to restart application
                IP = File.ReadAllText(GameDir + "Server.dat");
            }
        }

        private void Play_BTN_Click(object sender, System.EventArgs e)
        {
            p = true;
            run();
        }

        private void close_Btn(object sender, System.EventArgs e)
        {
            //ServerCore.SocketDispose();
            foreach (Process proc in Process.GetProcessesByName("UpLauncher"))
            {
                proc.Kill();
            }
        }

        public void run()
        {
            Program.UpdateRPC(stateRpc);
            pictureBox6.Visible = true;
            if (!string.IsNullOrEmpty(GameDir))
            {
                try
                {
                    if (System.IO.File.Exists(GameDir + "TestDrive2.exe"))
                    {
                        Mutex mutex1 = (Mutex)null;
                        if (p == true)
                        {
                            bool createdNew = false;
                            mutex1 = new Mutex(false, GameType, out createdNew);
                            if (!createdNew)
                                return;
                        }
                    }
                    pictureBox7.Visible = true;
                    Process process = new Process();
                    process.StartInfo.Arguments = GameType;
                    process.StartInfo.WorkingDirectory = GameDir;
                    process.StartInfo.FileName = "TestDrive2.exe";
                    Process.Start("TestDrive2.exe");
                    
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        void CheckServer()
        {
            PingChecked = true;
            bool pingable = false;
            Ping pinger = null;
            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(IP);
                pingable = reply.Status == IPStatus.Success;
                if(reply.Status == IPStatus.Success)
                {
                    stateRpc = Program.online;
                    GameType = "44938b8f";
                    State = 1;
                }

                if (reply.Status == IPStatus.TimedOut)
                {
                    stateRpc = Program.offline;
                    Program.start.Details = "Server Offline";
                    GameType = "957e4cc3";
                    State = 2;
                }

                if (reply.Status == IPStatus.Unknown)
                {
                    stateRpc = Program.offline;
                    Program.start.Details = "Server Unknown";
                    GameType = "957e4cc3";
                    State = 3;
                }
            }
            catch (PingException)
            {
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return;
        }

        #endregion

        public System.Windows.Forms.Button play_BTN;
        public System.Windows.Forms.PictureBox logo;
        public System.Windows.Forms.Label GameVersion;
        private Label label1;
        private Awesomium.Windows.Forms.WebControl webControl1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        public Button close;
        public Button minimize;
        private Label label2;
        private ProgressBar update1;
        private ProgressBar update2;
        private Panel panel1;
        public Label label3; //Text
        public PictureBox pictureBox3; //unbekannt
        public PictureBox pictureBox4; //online
        public PictureBox pictureBox5; //offline
        public PictureBox pictureBox6;
        public PictureBox pictureBox7;
    }
}