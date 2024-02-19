using log4net;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using XH1.Util;

namespace XH1
{
    public partial class Box : Form
    {
        public Bitmap[] Resource =
        {
            Properties.Resources.XH0,
            Properties.Resources.XH1,
            Properties.Resources.XH2
    };
        private bool IsMouseDown = false;
        private Point MousePoint;
        private bool hide = false;
        Process appProcess = null;

        public Box()
        {
            Rectangle rect = Screen.GetWorkingArea(this);
            Point p = new Point(rect.Width, rect.Height);
            this.Location = new Point(p.X - this.Size.Width - rect.Width / 20, p.Y - this.Size.Height - rect.Height / 15);
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int random = new Random().Next(0, 2);
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject($"XH{random}");
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            appProcess = new Process();

            appProcess.StartInfo.FileName = ConfigHelper.GetConfiguaration("WordAddress")/*"C:\\Program Files\\Microsoft Office\\root\\Office16\\WINWORD.EXE"*/;

            appProcess.Start();
        }

        private void myPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            appProcess = new Process();

            appProcess.StartInfo.FileName = "Explorer.exe";

            appProcess.Start();
        }

        private void weChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartEXE("WeChatAddress");
        }

        private void qyWeChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartEXE("WXWorkAddress");
        }

        private void Box_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                Point snap = Cursor.Position;
                this.Location = new Point(Location.X + (snap.X - MousePoint.X), Location.Y + (snap.Y - MousePoint.Y));
                MousePoint = Cursor.Position;
            }
        }

        private void Box_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            MousePoint = Cursor.Position;
        }

        private void Box_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Box_Load(object sender, EventArgs e)
        {
            NotifyIcon notifyIcon = new NotifyIcon();

            notifyIcon.Icon = new Icon(@"D:\\Personal\\Pet\\XH1\Resource\\image\\backimg1.ico");

            notifyIcon.Text = "系统托盘";

            notifyIcon.DoubleClick += new EventHandler(notifyIcon_DoubleClick);

            notifyIcon.ContextMenuStrip = contextMenuStrip1;

            //显示托盘

            notifyIcon.Visible = true;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Normal;

            this.ShowInTaskbar = true;

            this.backWorkToolStripMenuItem.Enabled = true;

            this.Activate();
            this.Show();
        }

        private void backWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.backWorkToolStripMenuItem.Enabled = false;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void steamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartEXE("SteamAddress");
        }

        private bool StartEXE(string exeName)
        {
            try
            {
                appProcess = new Process();

                appProcess.StartInfo.FileName = ConfigHelper.GetConfiguaration(exeName);/*"C:\\Program Files (x86)\\Tencent\\WeChat\\WeChat.exe"*/;

                appProcess.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"{exeName}路径无效，请检查软件是否安装或路径是否维护正确！");
                return false;
            }
            return true;
        }
    }
}
