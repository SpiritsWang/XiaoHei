﻿namespace XH1
{
    partial class Box
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.wordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qyWeChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backWorkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Image = global::XH1.Properties.Resources.XH1;
            this.pictureBox1.Location = new System.Drawing.Point(8, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 336);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordToolStripMenuItem,
            this.myPCToolStripMenuItem,
            this.qyWeChatToolStripMenuItem,
            this.weChatToolStripMenuItem,
            this.cancelToolStripMenuItem,
            this.backWorkToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 136);
            // 
            // wordToolStripMenuItem
            // 
            this.wordToolStripMenuItem.Name = "wordToolStripMenuItem";
            this.wordToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.wordToolStripMenuItem.Text = "Word";
            this.wordToolStripMenuItem.Click += new System.EventHandler(this.wordToolStripMenuItem_Click);
            // 
            // myPCToolStripMenuItem
            // 
            this.myPCToolStripMenuItem.Name = "myPCToolStripMenuItem";
            this.myPCToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.myPCToolStripMenuItem.Text = "此电脑";
            this.myPCToolStripMenuItem.Click += new System.EventHandler(this.myPCToolStripMenuItem_Click);
            // 
            // qyWeChatToolStripMenuItem
            // 
            this.qyWeChatToolStripMenuItem.Name = "qyWeChatToolStripMenuItem";
            this.qyWeChatToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.qyWeChatToolStripMenuItem.Text = "企业微信";
            this.qyWeChatToolStripMenuItem.Click += new System.EventHandler(this.qyWeChatToolStripMenuItem_Click);
            // 
            // weChatToolStripMenuItem
            // 
            this.weChatToolStripMenuItem.Name = "weChatToolStripMenuItem";
            this.weChatToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.weChatToolStripMenuItem.Text = "微信";
            this.weChatToolStripMenuItem.Click += new System.EventHandler(this.weChatToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.cancelToolStripMenuItem.Text = "退出";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // backWorkToolStripMenuItem
            // 
            this.backWorkToolStripMenuItem.Name = "backWorkToolStripMenuItem";
            this.backWorkToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.backWorkToolStripMenuItem.Text = "后台";
            this.backWorkToolStripMenuItem.Click += new System.EventHandler(this.backWorkToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(291, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 19);
            this.button1.TabIndex = 1;
            this.button1.Text = "设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Box
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 366);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Box";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Box_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Box_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Box_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Box_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem wordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myPCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qyWeChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backWorkToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

