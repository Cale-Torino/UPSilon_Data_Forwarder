namespace UPSilon_Data_Forwarder
{
    partial class TelegramForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelegramForm));
            LogsTextBox = new RichTextBox();
            Token_textBox = new TextBox();
            Chatid_textBox = new TextBox();
            Test_button = new Button();
            Save_button = new Button();
            HTTPWorker = new System.ComponentModel.BackgroundWorker();
            label1 = new Label();
            label2 = new Label();
            Enable_checkBox = new CheckBox();
            SuspendLayout();
            // 
            // LogsTextBox
            // 
            LogsTextBox.BackColor = Color.Black;
            LogsTextBox.ForeColor = Color.White;
            LogsTextBox.HideSelection = false;
            LogsTextBox.Location = new Point(12, 126);
            LogsTextBox.Name = "LogsTextBox";
            LogsTextBox.ReadOnly = true;
            LogsTextBox.Size = new Size(498, 238);
            LogsTextBox.TabIndex = 0;
            LogsTextBox.Text = "";
            // 
            // Token_textBox
            // 
            Token_textBox.Location = new Point(102, 52);
            Token_textBox.Name = "Token_textBox";
            Token_textBox.Size = new Size(408, 31);
            Token_textBox.TabIndex = 1;
            // 
            // Chatid_textBox
            // 
            Chatid_textBox.Location = new Point(102, 89);
            Chatid_textBox.Name = "Chatid_textBox";
            Chatid_textBox.Size = new Size(408, 31);
            Chatid_textBox.TabIndex = 2;
            // 
            // Test_button
            // 
            Test_button.Location = new Point(12, 12);
            Test_button.Name = "Test_button";
            Test_button.Size = new Size(112, 34);
            Test_button.TabIndex = 3;
            Test_button.Text = "Test";
            Test_button.UseVisualStyleBackColor = true;
            Test_button.Click += Test_button_Click;
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
            // HTTPWorker
            // 
            HTTPWorker.WorkerReportsProgress = true;
            HTTPWorker.WorkerSupportsCancellation = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 55);
            label1.Name = "label1";
            label1.Size = new Size(67, 25);
            label1.TabIndex = 5;
            label1.Text = "Token :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 92);
            label2.Name = "label2";
            label2.Size = new Size(75, 25);
            label2.TabIndex = 6;
            label2.Text = "ChatID :";
            // 
            // Enable_checkBox
            // 
            Enable_checkBox.AutoSize = true;
            Enable_checkBox.Location = new Point(248, 16);
            Enable_checkBox.Name = "Enable_checkBox";
            Enable_checkBox.Size = new Size(90, 29);
            Enable_checkBox.TabIndex = 7;
            Enable_checkBox.Text = "Enable";
            Enable_checkBox.UseVisualStyleBackColor = true;
            // 
            // TelegramForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(522, 376);
            Controls.Add(Enable_checkBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Save_button);
            Controls.Add(Test_button);
            Controls.Add(Chatid_textBox);
            Controls.Add(Token_textBox);
            Controls.Add(LogsTextBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelegramForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "TelegramForm";
            FormClosing += TelegramForm_FormClosing;
            Load += TelegramForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox LogsTextBox;
        private TextBox Token_textBox;
        private TextBox Chatid_textBox;
        private Button Test_button;
        private Button Save_button;
        private System.ComponentModel.BackgroundWorker HTTPWorker;
        private Label label1;
        private Label label2;
        private CheckBox Enable_checkBox;
    }
}