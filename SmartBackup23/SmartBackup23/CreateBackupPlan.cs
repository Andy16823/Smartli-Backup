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
    public partial class CreateBackupPlan : Form
    {
        private Form1 parent;

        public CreateBackupPlan(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void createBackupPlan(String name, String path)
        {
            // Create directory for the plan
            Directory.CreateDirectory(path);

            // Create xml
            System.Xml.XmlDocument xml = new System.Xml.XmlDocument();

            System.Xml.XmlElement rootNode = xml.CreateElement("SmartliBackup");
            rootNode.SetAttribute("Name", this.textBox1.Text);
            rootNode.SetAttribute("Schedule", this.comboBox1.Text);
            rootNode.SetAttribute("LastBackup", null);
            rootNode.SetAttribute("LastBackupName", null);

            System.Xml.XmlElement items = xml.CreateElement("Items");
            foreach (ListViewItem item in this.listView1.Items)
            {
                String itemName = item.Text;
                String itemPath = item.SubItems[1].Text;
                String itemType = item.SubItems[2].Text;

                System.Xml.XmlElement _xmlItem = xml.CreateElement("Item");
                _xmlItem.SetAttribute("Name", itemName);
                _xmlItem.SetAttribute("Path", itemPath);
                _xmlItem.SetAttribute("Type", itemType);
                items.AppendChild(_xmlItem);
            }

            rootNode.AppendChild(items);
            xml.AppendChild(rootNode);
            xml.Save(path + "/backup.plan");

            MessageBox.Show("Backup plan created");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String exepath = System.Reflection.Assembly.GetEntryAssembly().Location;
            String backupsDir = Path.Combine(new FileInfo(exepath).DirectoryName, "Backups");
            //String backupsDir = new FileInfo(exepath).DirectoryName + "/Backups";

            String backupDir = Path.Combine(backupsDir, this.textBox1.Text);
            if (Directory.Exists(backupDir))
            {
                MessageBox.Show("The plan with the name " + this.textBox1.Text + " allready exist! Please select a other name");
            }
            else
            {
                createBackupPlan(Name, backupDir);
                if (this.checkBox1.Checked)
                {
                    System.Threading.Thread thread = new System.Threading.Thread(() =>
                    {
                        this.progressBar1.Invoke(new Action(() =>
                        {
                            this.progressBar1.Style = ProgressBarStyle.Marquee;
                            this.progressBar1.MarqueeAnimationSpeed = 10;
                        }));

                        Form1.CreateBackup(this.textBox1.Text);

                        this.progressBar1.Invoke(new Action(() =>
                        {
                            this.progressBar1.Style = ProgressBarStyle.Continuous;
                            this.progressBar1.Maximum = 1;
                            this.progressBar1.Value = 1;
                            this.progressBar1.MarqueeAnimationSpeed = 0;
                        }));

                        MessageBox.Show("Backups Created");
                        this.parent.Invoke(new Action(() =>
                        {
                            this.parent.LoadBackups();
                        }));

                    });
                    thread.Start();
                    MessageBox.Show("Starting to create the backup. Please wait untill the process is done!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                String name = directoryInfo.Name;
                String path = directoryInfo.FullName;
                String type = "directory";
                ListViewItem item = new ListViewItem();
                item.Text = name;
                item.SubItems.Add(path);
                item.SubItems.Add(type);
                this.listView1.Items.Add(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(dialog.FileName);
                String name = fileInfo.Name;
                String path = fileInfo.FullName;
                String type = "file";

                ListViewItem item = new ListViewItem();
                item.Text = name;
                item.SubItems.Add(path);
                item.SubItems.Add(type);
                this.listView1.Items.Add(item);
            }
        }

        private void CreateBackupPlan_Load(object sender, EventArgs e)
        {

        }
    }
}
