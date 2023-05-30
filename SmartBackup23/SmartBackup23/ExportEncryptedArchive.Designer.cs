namespace SmartBackup23
{
    partial class ExportEncryptedArchive
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 0;
            label1.Text = "Backup Plan";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(114, 18);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 1;
            label2.Text = "Backup Plan";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 49);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(114, 46);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(227, 23);
            textBox1.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(13, 110, 235);
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = Color.White;
            button1.Location = new Point(222, 91);
            button1.Name = "button1";
            button1.Size = new Size(119, 33);
            button1.TabIndex = 4;
            button1.Text = "Export";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(0, 133);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(357, 10);
            progressBar1.TabIndex = 5;
            // 
            // ExportEncryptedArchive
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 37, 41);
            ClientSize = new Size(357, 143);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ExportEncryptedArchive";
            Text = "Export Encrypted Archive";
            Load += ExportEncryptedArchive_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private Button button1;
        private ProgressBar progressBar1;
    }
}