using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBackup23
{
    public partial class BackupExpiredPlans : Form
    {
        private Form1 parent;

        public BackupExpiredPlans(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        public void StartBackupPlans(String[] plans)
        {
            System.Threading.Thread thread = new System.Threading.Thread(() =>
            {
                backupHandler(plans);
            });
            thread.Start();
            MessageBox.Show("Starting to create the backups. Please wait untill the process is done!");
        }

        private void backupHandler(string[] plans)
        {
            this.progressBar1.Invoke(new Action(() =>
            {
                this.progressBar1.Style = ProgressBarStyle.Marquee;
                this.progressBar1.MarqueeAnimationSpeed = 10;
            }));

            for (int i = 0; i < plans.Length; i++)
            {
                Form1.CreateBackup(plans[i]);
            }

            this.parent.Invoke(new Action(() =>
            {
                this.parent.LoadBackups();
            }));

            this.progressBar1.Invoke(new Action(() =>
            {
                this.progressBar1.Style = ProgressBarStyle.Continuous;
                this.progressBar1.Maximum = 1;
                this.progressBar1.Value = 1;
                this.progressBar1.MarqueeAnimationSpeed = 0;
            }));

            MessageBox.Show("Backups Created");
            this.Invoke(new Action(() =>
            {
                this.Close();
            }));
        }


        private void BackupExpiredPlans_Load(object sender, EventArgs e)
        {

        }
    }
}
