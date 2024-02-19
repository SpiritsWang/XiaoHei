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
        private Boolean IsMouseDown = false;
        private Point MousePoint;
        private Boolean hide = false;
        public Box()
        {
            Rectangle rect = Screen.GetWorkingArea(this);
            Point p = new Point(rect.Width, rect.Height);
            this.Location = new Point(p.X - this.Size.Width - rect.Width / 20, p.Y - this.Size.Height - rect.Height / 15);
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int random = new Random().Next(0, 2);
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject($"XH{random}");
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process wordProcess = new Process();

            wordProcess.StartInfo.FileName = "C:\\Program Files\\Microsoft Office\\root\\Office16\\WINWORD.EXE";

            wordProcess.Start();
        }

        private void myPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process wordProcess = new Process();

            wordProcess.StartInfo.FileName = "Explorer.exe";

            wordProcess.Start();
        }

        private void weChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process wordProcess = new Process();

            wordProcess.StartInfo.FileName = "C:\\Program Files (x86)\\Tencent\\WeChat\\WeChat.exe";

            wordProcess.Start();
        }

        private void qyWeChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process wordProcess = new Process();

            wordProcess.StartInfo.FileName = "C:\\Program Files (x86)\\WXWork\\WXWork.exe";

            wordProcess.Start();
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
    }
}
