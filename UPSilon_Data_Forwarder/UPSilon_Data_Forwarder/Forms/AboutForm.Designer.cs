namespace UPSilon_Data_Forwarder
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            panel1 = new Panel();
            Versionlabel = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            linkLabel = new LinkLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(Versionlabel);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 261);
            panel1.Name = "panel1";
            panel1.Size = new Size(536, 26);
            panel1.TabIndex = 0;
            // 
            // Versionlabel
            // 
            Versionlabel.AutoSize = true;
            Versionlabel.Dock = DockStyle.Right;
            Versionlabel.Location = new Point(462, 0);
            Versionlabel.Name = "Versionlabel";
            Versionlabel.Size = new Size(74, 25);
            Versionlabel.TabIndex = 1;
            Versionlabel.Text = "Version:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(60, 25);
            label1.TabIndex = 0;
            label1.Text = "Ready";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(512, 151);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.Location = new Point(12, 166);
            label3.Name = "label3";
            label3.Size = new Size(512, 28);
            label3.TabIndex = 2;
            label3.Text = "UPSilon Data Forwarder App";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Location = new Point(12, 194);
            label4.Name = "label4";
            label4.Size = new Size(512, 28);
            label4.TabIndex = 3;
            label4.Text = "Forwards Data To The Endpoint Of Your Choice";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // linkLabel
            // 
            linkLabel.ForeColor = Color.DodgerBlue;
            linkLabel.Location = new Point(12, 222);
            linkLabel.Name = "linkLabel";
            linkLabel.Size = new Size(512, 26);
            linkLabel.TabIndex = 4;
            linkLabel.TabStop = true;
            linkLabel.Text = "tutorials.techrad.co.za";
            linkLabel.TextAlign = ContentAlignment.MiddleCenter;
            linkLabel.LinkClicked += linkLabel_LinkClicked;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 287);
            Controls.Add(linkLabel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AboutForm";
            Load += AboutForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label Versionlabel;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label4;
        private LinkLabel linkLabel;
    }
}