namespace SmartBackup23
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tableLayoutPanel1 = new TableLayoutPanel();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            contextMenuStrip1 = new ContextMenuStrip(components);
            createBackupToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            restoreBackupToolStripMenuItem = new ToolStripMenuItem();
            deletePlanToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            showBackupFilesToolStripMenuItem = new ToolStripMenuItem();
            exportBackupsToolStripMenuItem = new ToolStripMenuItem();
            importBackupsToolStripMenuItem = new ToolStripMenuItem();
            imageList1 = new ImageList(components);
            tableLayoutPanel2 = new TableLayoutPanel();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            progressBar1 = new ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(listView1, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.Location = new Point(3, 70);
            listView1.Name = "listView1";
            listView1.Size = new Size(794, 309);
            listView1.SmallImageList = imageList1;
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Backup Name";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Schedule";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Last Backup";
            columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Last Backup Name";
            columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Status";
            columnHeader5.Width = 150;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { createBackupToolStripMenuItem, toolStripSeparator1, restoreBackupToolStripMenuItem, deletePlanToolStripMenuItem, toolStripSeparator2, showBackupFilesToolStripMenuItem, exportBackupsToolStripMenuItem, importBackupsToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(172, 148);
            // 
            // createBackupToolStripMenuItem
            // 
            createBackupToolStripMenuItem.Name = "createBackupToolStripMenuItem";
            createBackupToolStripMenuItem.Size = new Size(171, 22);
            createBackupToolStripMenuItem.Text = "Create Backup";
            createBackupToolStripMenuItem.Click += createBackupToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(168, 6);
            // 
            // restoreBackupToolStripMenuItem
            // 
            restoreBackupToolStripMenuItem.Name = "restoreBackupToolStripMenuItem";
            restoreBackupToolStripMenuItem.Size = new Size(171, 22);
            restoreBackupToolStripMenuItem.Text = "Restore Backup";
            restoreBackupToolStripMenuItem.Click += restoreBackupToolStripMenuItem_Click;
            // 
            // deletePlanToolStripMenuItem
            // 
            deletePlanToolStripMenuItem.Name = "deletePlanToolStripMenuItem";
            deletePlanToolStripMenuItem.Size = new Size(171, 22);
            deletePlanToolStripMenuItem.Text = "Delete Plan";
            deletePlanToolStripMenuItem.Click += deletePlanToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(168, 6);
            // 
            // showBackupFilesToolStripMenuItem
            // 
            showBackupFilesToolStripMenuItem.Name = "showBackupFilesToolStripMenuItem";
            showBackupFilesToolStripMenuItem.Size = new Size(171, 22);
            showBackupFilesToolStripMenuItem.Text = "Show Backup Files";
            showBackupFilesToolStripMenuItem.Click += showBackupFilesToolStripMenuItem_Click;
            // 
            // exportBackupsToolStripMenuItem
            // 
            exportBackupsToolStripMenuItem.Name = "exportBackupsToolStripMenuItem";
            exportBackupsToolStripMenuItem.Size = new Size(171, 22);
            exportBackupsToolStripMenuItem.Text = "Export Backups";
            exportBackupsToolStripMenuItem.Click += exportBackupsToolStripMenuItem_Click;
            // 
            // importBackupsToolStripMenuItem
            // 
            importBackupsToolStripMenuItem.Name = "importBackupsToolStripMenuItem";
            importBackupsToolStripMenuItem.Size = new Size(171, 22);
            importBackupsToolStripMenuItem.Text = "Import Backups";
            importBackupsToolStripMenuItem.Click += importBackupsToolStripMenuItem_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "cloud_ok.png");
            imageList1.Images.SetKeyName(1, "cloud_error.png");
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 5;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Controls.Add(button5, 4, 0);
            tableLayoutPanel2.Controls.Add(button4, 3, 0);
            tableLayoutPanel2.Controls.Add(button3, 2, 0);
            tableLayoutPanel2.Controls.Add(button2, 1, 0);
            tableLayoutPanel2.Controls.Add(button1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 385);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(794, 62);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(13, 110, 235);
            button5.Dock = DockStyle.Fill;
            button5.FlatStyle = FlatStyle.Popup;
            button5.ForeColor = Color.White;
            button5.Location = new Point(635, 3);
            button5.Name = "button5";
            button5.Size = new Size(156, 56);
            button5.TabIndex = 4;
            button5.Text = "Refresh List";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(13, 110, 235);
            button4.Dock = DockStyle.Fill;
            button4.FlatStyle = FlatStyle.Popup;
            button4.ForeColor = Color.White;
            button4.Location = new Point(477, 3);
            button4.Name = "button4";
            button4.Size = new Size(152, 56);
            button4.TabIndex = 3;
            button4.Text = "Backup Selection";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(13, 110, 235);
            button3.Dock = DockStyle.Fill;
            button3.FlatStyle = FlatStyle.Popup;
            button3.ForeColor = Color.White;
            button3.Location = new Point(319, 3);
            button3.Name = "button3";
            button3.Size = new Size(152, 56);
            button3.TabIndex = 2;
            button3.Text = "Backup Expired Plans";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(13, 110, 235);
            button2.Dock = DockStyle.Fill;
            button2.FlatStyle = FlatStyle.Popup;
            button2.ForeColor = Color.White;
            button2.Location = new Point(161, 3);
            button2.Name = "button2";
            button2.Size = new Size(152, 56);
            button2.TabIndex = 1;
            button2.Text = "Restore Backup";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(13, 110, 235);
            button1.Dock = DockStyle.Fill;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = Color.White;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(152, 56);
            button1.TabIndex = 0;
            button1.Text = "New Backup Plan";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel3.Controls.Add(progressBar1, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(794, 61);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.smartli_with_padding;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(194, 55);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Fill;
            progressBar1.Location = new Point(203, 3);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(588, 55);
            progressBar1.TabIndex = 1;
            progressBar1.Visible = false;
            // 
            // timer1
            // 
            timer1.Interval = 900000;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 37, 41);
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Smartli Backup";
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private TableLayoutPanel tableLayoutPanel2;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private TableLayoutPanel tableLayoutPanel3;
        private PictureBox pictureBox1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem createBackupToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem restoreBackupToolStripMenuItem;
        private ToolStripMenuItem deletePlanToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem showBackupFilesToolStripMenuItem;
        private ToolStripMenuItem exportBackupsToolStripMenuItem;
        private ToolStripMenuItem importBackupsToolStripMenuItem;
        private ProgressBar progressBar1;
        private ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
    }
}