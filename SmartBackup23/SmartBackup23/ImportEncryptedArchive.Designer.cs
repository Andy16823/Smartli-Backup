namespace SmartBackup23
{
    partial class ImportEncryptedArchive
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
            button1 = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(13, 110, 235);
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = Color.White;
            button1.Location = new Point(223, 82);
            button1.Name = "button1";
            button1.Size = new Size(119, 33);
            button1.TabIndex = 7;
            button1.Text = "Import";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(115, 41);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(227, 23);
            textBox1.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(13, 44);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 5;
            label3.Text = "Password";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(115, 12);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(166, 23);
            textBox2.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(13, 15);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 8;
            label1.Text = "Archiv";
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(0, 130);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(358, 10);
            progressBar1.TabIndex = 10;
            // 
            // button2
            // 
            button2.Location = new Point(287, 12);
            button2.Name = "button2";
            button2.Size = new Size(55, 23);
            button2.TabIndex = 11;
            button2.Text = "...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ImportEncryptedArchive
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 37, 41);
            ClientSize = new Size(358, 140);
            Controls.Add(button2);
            Controls.Add(progressBar1);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Name = "ImportEncryptedArchive";
            Text = "ImportEncryptedArchive";
            Load += ImportEncryptedArchive_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Label label1;
        private ProgressBar progressBar1;
        private Button button2;
    }
}