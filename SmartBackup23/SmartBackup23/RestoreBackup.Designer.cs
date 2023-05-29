namespace SmartBackup23
{
    partial class RestoreBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestoreBackup));
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label1 = new Label();
            button1 = new Button();
            checkBox1 = new CheckBox();
            comboBox1 = new ComboBox();
            progressBar1 = new ProgressBar();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(progressBar1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.Size = new Size(324, 285);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.smartli_with_padding;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(318, 93);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(comboBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 102);
            panel1.Name = "panel1";
            panel1.Size = new Size(318, 136);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(9, 11);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 10;
            label1.Text = "Backup File";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(13, 110, 235);
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = Color.White;
            button1.Location = new Point(9, 89);
            button1.Name = "button1";
            button1.Size = new Size(141, 31);
            button1.TabIndex = 9;
            button1.Text = "Restore Backup";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = Color.White;
            checkBox1.Location = new Point(9, 58);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(169, 19);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Extract to custom directory";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(9, 29);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(300, 23);
            comboBox1.TabIndex = 1;
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Fill;
            progressBar1.Location = new Point(3, 244);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(318, 38);
            progressBar1.TabIndex = 2;
            // 
            // RestoreBackup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 37, 41);
            ClientSize = new Size(324, 285);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RestoreBackup";
            Text = "RestoreBackup";
            Load += RestoreBackup_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private Panel panel1;
        private CheckBox checkBox1;
        private ComboBox comboBox1;
        private Label label1;
        private Button button1;
        private ProgressBar progressBar1;
    }
}