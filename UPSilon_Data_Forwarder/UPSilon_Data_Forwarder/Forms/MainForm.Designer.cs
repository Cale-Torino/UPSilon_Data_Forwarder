namespace UPSilon_Data_Forwarder
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            telegramToolStripMenuItem = new ToolStripMenuItem();
            hTTPAPIToolStripMenuItem = new ToolStripMenuItem();
            startToolStripMenuItem = new ToolStripMenuItem();
            stopToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar1 = new ToolStripProgressBar();
            StatusLabel = new ToolStripStatusLabel();
            groupBox1 = new GroupBox();
            LogsTextBox = new RichTextBox();
            ClientWorker = new System.ComponentModel.BackgroundWorker();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { aboutToolStripMenuItem, settingsToolStripMenuItem, startToolStripMenuItem, stopToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Image = (Image)resources.GetObject("aboutToolStripMenuItem.Image");
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(102, 29);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { telegramToolStripMenuItem, hTTPAPIToolStripMenuItem });
            settingsToolStripMenuItem.Image = (Image)resources.GetObject("settingsToolStripMenuItem.Image");
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(116, 29);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // telegramToolStripMenuItem
            // 
            telegramToolStripMenuItem.Image = (Image)resources.GetObject("telegramToolStripMenuItem.Image");
            telegramToolStripMenuItem.Name = "telegramToolStripMenuItem";
            telegramToolStripMenuItem.Size = new Size(270, 34);
            telegramToolStripMenuItem.Text = "Telegram";
            telegramToolStripMenuItem.Click += telegramToolStripMenuItem_Click;
            // 
            // hTTPAPIToolStripMenuItem
            // 
            hTTPAPIToolStripMenuItem.Image = (Image)resources.GetObject("hTTPAPIToolStripMenuItem.Image");
            hTTPAPIToolStripMenuItem.Name = "hTTPAPIToolStripMenuItem";
            hTTPAPIToolStripMenuItem.Size = new Size(270, 34);
            hTTPAPIToolStripMenuItem.Text = "HTTP API";
            hTTPAPIToolStripMenuItem.Click += hTTPAPIToolStripMenuItem_Click;
            // 
            // startToolStripMenuItem
            // 
            startToolStripMenuItem.Image = (Image)resources.GetObject("startToolStripMenuItem.Image");
            startToolStripMenuItem.Name = "startToolStripMenuItem";
            startToolStripMenuItem.Size = new Size(88, 29);
            startToolStripMenuItem.Text = "Start";
            startToolStripMenuItem.Click += startToolStripMenuItem_Click;
            // 
            // stopToolStripMenuItem
            // 
            stopToolStripMenuItem.Image = (Image)resources.GetObject("stopToolStripMenuItem.Image");
            stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            stopToolStripMenuItem.Size = new Size(89, 29);
            stopToolStripMenuItem.Text = "Stop";
            stopToolStripMenuItem.Click += stopToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1, StatusLabel });
            statusStrip1.Location = new Point(0, 418);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 32);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 24);
            // 
            // StatusLabel
            // 
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(60, 25);
            StatusLabel.Text = "Ready";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(LogsTextBox);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 33);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(800, 385);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Logs";
            // 
            // LogsTextBox
            // 
            LogsTextBox.BackColor = Color.Black;
            LogsTextBox.Dock = DockStyle.Fill;
            LogsTextBox.ForeColor = Color.White;
            LogsTextBox.HideSelection = false;
            LogsTextBox.Location = new Point(3, 27);
            LogsTextBox.Name = "LogsTextBox";
            LogsTextBox.ReadOnly = true;
            LogsTextBox.Size = new Size(794, 355);
            LogsTextBox.TabIndex = 0;
            LogsTextBox.Text = "";
            // 
            // ClientWorker
            // 
            ClientWorker.WorkerReportsProgress = true;
            ClientWorker.WorkerSupportsCancellation = true;
            ClientWorker.DoWork += ClientWorker_DoWork;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "UPSilon Data Forwarder";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripStatusLabel StatusLabel;
        private GroupBox groupBox1;
        private RichTextBox LogsTextBox;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem telegramToolStripMenuItem;
        private ToolStripMenuItem startToolStripMenuItem;
        private ToolStripMenuItem stopToolStripMenuItem;
        private ToolStripMenuItem hTTPAPIToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker ClientWorker;
    }
}