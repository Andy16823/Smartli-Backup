using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBackup23
{
    public partial class RestoreBackup : Form
    {
        private Form1 parent;
        private String plan;

        public RestoreBackup(Form1 form, String plan, String lastBackup)
        {
            InitializeComponent();
            this.parent = form;
            this.plan = plan;
            this.comboBox1.Text = lastBackup;
        }

        public void LoadBackups()
        {
            String exepath = System.Reflection.Assembly.GetEntryAssembly().Location;
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(new FileInfo(exepath).DirectoryName, "Backups", this.plan));
            foreach (var item in directoryInfo.GetFiles())
            {
                if (item.Extension == ".smlb")
                {
                    this.comboBox1.Items.Add(item.Name);
                }
            }
        }

        private void RestoreBackup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String exepath = System.Reflection.Assembly.GetEntryAssembly().Location;
            String backupFile = Path.Combine(new FileInfo(exepath).DirectoryName, "Backups", this.plan, this.comboBox1.Text);
            if (!File.Exists(backupFile)) return;

            String customdir = null;
            if (MessageBox.Show("This will replace all files with the files within the plugin. Are you sure you want to restor the files?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (this.checkBox1.Checked)
                {
                    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        customdir = folderBrowserDialog.SelectedPath;
                    }
                }
                System.Threading.Thread thread = new System.Threading.Thread(() =>
                {

                    this.progressBar1.Invoke(new Action(() =>
                    {
                        this.progressBar1.Style = ProgressBarStyle.Marquee;
                        this.progressBar1.MarqueeAnimationSpeed = 10;
                    }));

                    Form1.RestoreBackup(backupFile, customdir);

                    this.progressBar1.Invoke(new Action(() =>
                    {
                        this.progressBar1.Style = ProgressBarStyle.Continuous;
                        this.progressBar1.Maximum = 1;
                        this.progressBar1.Value = 1;
                        this.progressBar1.MarqueeAnimationSpeed = 0;
                    }));

                    MessageBox.Show("Files Restored");
                    this.Invoke(new Action(() =>
                    {
                        this.Close();
                    }));
                });
                thread.Start();
            }
        }
    }
}
