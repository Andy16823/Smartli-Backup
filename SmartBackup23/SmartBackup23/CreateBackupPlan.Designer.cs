namespace SmartBackup23
{
    partial class CreateBackupPlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateBackupPlan));
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            button2 = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            checkBox1 = new CheckBox();
            button1 = new Button();
            button3 = new Button();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 34);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Plan Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(93, 31);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(299, 23);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 63);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 2;
            label2.Text = "Schedule";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "24 Hours", "2 Days", "3 Days", "5 Days", "6 Days", "7 Days" });
            comboBox1.Location = new Point(93, 60);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(299, 23);
            comboBox1.TabIndex = 3;
            comboBox1.Text = "24 Hours";
            // 
            // button2
            // 
            button2.Location = new Point(290, 99);
            button2.Name = "button2";
            button2.Size = new Size(102, 23);
            button2.TabIndex = 5;
            button2.Text = "Add Directory";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView1.Location = new Point(12, 128);
            listView1.Name = "listView1";
            listView1.Size = new Size(380, 170);
            listView1.TabIndex = 6;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Path";
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Type";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.ForeColor = Color.White;
            checkBox1.Location = new Point(12, 318);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(127, 19);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Create First Backup";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(13, 110, 235);
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = Color.White;
            button1.Location = new Point(265, 343);
            button1.Name = "button1";
            button1.Size = new Size(127, 39);
            button1.TabIndex = 8;
            button1.Text = "Create Plan";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(182, 99);
            button3.Name = "button3";
            button3.Size = new Size(102, 23);
            button3.TabIndex = 9;
            button3.Text = "Add File";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 343);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(247, 39);
            progressBar1.TabIndex = 10;
            // 
            // CreateBackupPlan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 37, 41);
            ClientSize = new Size(404, 396);
            Controls.Add(progressBar1);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(checkBox1);
            Controls.Add(listView1);
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateBackupPlan";
            Text = "CreateBackupPlan";
            Load += CreateBackupPlan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private ComboBox comboBox1;
        private Button button2;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private CheckBox checkBox1;
        private Button button1;
        private Button button3;
        private ProgressBar progressBar1;
    }
}