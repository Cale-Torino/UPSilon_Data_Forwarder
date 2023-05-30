namespace UPSilon_Data_Forwarder
{
    partial class HTTPAPIForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HTTPAPIForm));
            Test_button = new Button();
            LogsTextBox = new RichTextBox();
            Url_textBox = new TextBox();
            Save_button = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            Enable_checkBox = new CheckBox();
            SuspendLayout();
            // 
            // Test_button
            // 
            Test_button.Location = new Point(12, 12);
            Test_button.Name = "Test_button";
            Test_button.Size = new Size(112, 34);
            Test_button.TabIndex = 0;
            Test_button.Text = "Test";
            Test_button.UseVisualStyleBackColor = true;
            Test_button.Click += Test_button_Click;
            // 
            // LogsTextBox
            // 
            LogsTextBox.BackColor = Color.Black;
            LogsTextBox.ForeColor = Color.White;
            LogsTextBox.HideSelection = false;
            LogsTextBox.Location = new Point(12, 117);
            LogsTextBox.Name = "LogsTextBox";
            LogsTextBox.ReadOnly = true;
            LogsTextBox.Size = new Size(486, 202);
            LogsTextBox.TabIndex = 1;
            LogsTextBox.Text = "";
            // 
            // Url_textBox
            // 
            Url_textBox.Location = new Point(61, 80);
            Url_textBox.Name = "Url_textBox";
            Url_textBox.Size = new Size(437, 31);
            Url_textBox.TabIndex = 2;
            // 
            // Save_button
            // 
            Save_button.Location = new Point(130, 12);
            Save_button.Name = "Save_button";
            Save_button.Size = new Size(112, 34);
            Save_button.TabIndex = 4;
            Save_button.Text = "Save";
            Save_button.UseVisualStyleBackColor = true;
            Save_button.Click += Save_button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 83);
            label1.Name = "label1";
            label1.Size = new Size(43, 25);
            label1.TabIndex = 5;
            label1.Text = "Url :";
            // 
            // label2
            // 
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(254, 25);
            label2.TabIndex = 6;
            label2.Text = "Well formated string example :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Cursor = Cursors.Hand;
            label3.Location = new Point(258, 52);
            label3.Name = "label3";
            label3.Size = new Size(186, 25);
            label3.TabIndex = 7;
            label3.Text = "http://127.0.0.1:8000/";
            label3.Click += label3_Click;
            label3.MouseEnter += label3_MouseEnter;
            label3.MouseLeave += label3_MouseLeave;
            // 
            // Enable_checkBox
            // 
            Enable_checkBox.AutoSize = true;
            Enable_checkBox.Location = new Point(248, 16);
            Enable_checkBox.Name = "Enable_checkBox";
            Enable_checkBox.Size = new Size(90, 29);
            Enable_checkBox.TabIndex = 8;
            Enable_checkBox.Text = "Enable";
            Enable_checkBox.UseVisualStyleBackColor = true;
            // 
            // HTTPAPIForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 331);
            Controls.Add(Enable_checkBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Save_button);
            Controls.Add(Url_textBox);
            Controls.Add(LogsTextBox);
            Controls.Add(Test_button);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HTTPAPIForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "HTTPAPIForm";
            FormClosing += HTTPAPIForm_FormClosing;
            Load += HTTPAPIForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Test_button;
        private RichTextBox LogsTextBox;
        private TextBox Url_textBox;
        private Button Save_button;
        private Label label1;
        private Label label2;
        private Label label3;
        private CheckBox Enable_checkBox;
    }
}