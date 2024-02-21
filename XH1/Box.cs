using log4net;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using XH1.Dialog;
using XH1.Entity;
using XH1.Properties;
using XH1.Util;

namespace XH1
{
    public partial class Box : Form
    {
        private bool IsMouseDown = false;
        private Point MousePoint;
        private bool hide = false;
        Process appProcess = null;
        private NameValueCollection AllSettings;
        private List<AppAddressInfo> AddressList = null;

        public Box()
        {
            Rectangle rect = Screen.GetWorkingArea(this);
            Point p = new Point(rect.Width, rect.Height);
            this.Location = new Point(p.X - this.Size.Width - rect.Width / 20, p.Y - this.Size.Height - rect.Height / 15);
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Box_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            InitBackIcon();
            InitToolStripMenuItem();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int random = new Random().Next(0, 8);
            pictureBox1.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject($"XH{random}");
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

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                Point snap = Cursor.Position;
                this.Location = new Point(Location.X + (snap.X - MousePoint.X), Location.Y + (snap.Y - MousePoint.Y));
                MousePoint = Cursor.Position;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            MousePoint = Cursor.Position;
        }

        private void InitBackIcon()
        {
            NotifyIcon notifyIcon = new NotifyIcon();
            string currentPath = Directory.GetCurrentDirectory();
            notifyIcon.Icon = new Icon($@"{currentPath}\\Resource\\image\\backimg1.ico");

            notifyIcon.Text = "系统托盘";

            notifyIcon.DoubleClick += new EventHandler(notifyIcon_DoubleClick);

            notifyIcon.ContextMenuStrip = contextMenuStrip1;

            //显示托盘
            notifyIcon.Visible = true;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;

            this.ShowInTaskbar = false;

            this.backWorkToolStripMenuItem.Enabled = true;

            this.Activate();
            this.Show();
        }
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting dlgSetting = new Setting(AddressList);

            if (dlgSetting.ShowDialog() == DialogResult.OK)
            {
                Dictionary<string, string> needUpdateAddresInfoDic = new Dictionary<string, string>();
                AddressList = dlgSetting.AllAddressList;
                foreach (var address in AddressList)
                {
                    needUpdateAddresInfoDic.Add($"{address.DisplayName}-{address.IDName}-{address.Index}-{address.Visible}", address.Value);
                }
                if (ConfigHelper.BatchAddUpdateAppAddressSettings(needUpdateAddresInfoDic))
                {
                    if (MessageBox.Show("设置成功,重启应用后生效,是否现在重启？", "提示",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Process.Start(Application.StartupPath + "\\XH1.exe");
                        Process.GetCurrentProcess().Kill();
                    }
                }
                else
                    MessageBox.Show("失败！请联系管理员。");
            }
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
        /// <summary>
        /// 后台
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.backWorkToolStripMenuItem.Enabled = false;
            this.Hide();
        }

        private bool StartEXE(string name, string address)
        {
            try
            {
                appProcess = new Process();

                appProcess.StartInfo.FileName = address;/*"C:\\Program Files (x86)\\Tencent\\WeChat\\WeChat.exe"*/;

                appProcess.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"{name}配置路径{address}无效，请检查软件是否安装或路径是否维护正确！");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 初始化右键菜单内容
        /// </summary>
        private void InitToolStripMenuItem()
        {
            this.contextMenuStrip1.Items.Clear();
            AddressList = new List<AppAddressInfo>();
            //取所有的setting
            AllSettings = ConfigHelper.GetAllSetting();
            var keys = AllSettings.Keys;
            foreach (var key in keys)
            {
                //取到单个VALUE
                var setting = AllSettings[key.ToString()];

                var address = new AppAddressInfo();

                var addressInfoArray = key.ToString().Split('-');

                if (addressInfoArray.Length >= 2)
                {
                    address.DisplayName = addressInfoArray[0];
                    address.IDName = addressInfoArray[1];

                    if (addressInfoArray.Length == 3)
                        address.Index = addressInfoArray[2];
                    else if (addressInfoArray.Length == 4)
                        address.Visible = addressInfoArray[3];
                }
                else
                {
                    MessageBox.Show("配置文件错误，请联系管理员。");
                    return;
                }

                address.Key = key.ToString();
                address.Value = setting;

                if (string.IsNullOrEmpty(address.Index))
                    address.Index = "0";
                if (string.IsNullOrEmpty(address.Visible))
                    address.Visible = "1";

                AddressList.Add(address);
            }
            InitContextMenuStrip(AddressList);
        }
        /// <summary>
        /// 初始化右键菜单顺序
        /// </summary>
        /// <param name="appAddresseList"></param>
        private void InitContextMenuStrip(List<AppAddressInfo> appAddresseList)
        {
            AddressList = appAddresseList.OrderBy(x => int.Parse(x.Index)).ToList();

            ToolStripMenuItem menuItem = null;
            foreach (var addressInfo in AddressList.Where(x => x.Visible == "1").ToList())
            {
                menuItem = new ToolStripMenuItem();
                menuItem.Text = addressInfo.DisplayName;
                menuItem.Name = addressInfo.IDName;
                menuItem.Tag = addressInfo.Value;
                menuItem.Click += ClickEvent;
                this.contextMenuStrip1.Items.Add(menuItem);
            }
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.settingToolStripMenuItem,
            this.backWorkToolStripMenuItem,
            this.cancelToolStripMenuItem});

        }

        private void ClickEvent(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item.Name.Contains("Address"))
            {
                StartEXE(item.Text, item.Tag.ToString());
            }
        }
    }
}
