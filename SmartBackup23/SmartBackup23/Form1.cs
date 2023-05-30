using System.Diagnostics;
using System.Xml;

namespace SmartBackup23
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initial the form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the backups and starts the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            String exepath = System.Reflection.Assembly.GetEntryAssembly().Location;
            String backupsDir = new FileInfo(exepath).DirectoryName + "/Backups";
            if (!Directory.Exists(backupsDir))
            {
                Directory.CreateDirectory(backupsDir);
            }
            LoadBackups();
            this.timer1.Start();
        }

        /// <summary>
        /// Delete the given directory recursive
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteDirectory(String path)
        {
            String[] files = Directory.GetFiles(path);
            String[] dirs = Directory.GetDirectories(path);

            foreach (var file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (var dir in dirs)
            {
                DeleteDirectory(dir);
            }
            try
            {
                Directory.Delete(path, false);
            }
            catch
            {
                MessageBox.Show($"Unable to delete directory {path}");
            }
        }

        /// <summary>
        /// Copy files recursive
        /// </summary>
        /// <param name="path"></param>
        /// <param name="destination"></param>
        public static void CopyDirectory(string path, string destination)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            FileInfo[] files = directoryInfo.GetFiles();
            foreach (var item in files)
            {
                String destFile = Path.Combine(destination, item.Name);
                File.Copy(item.FullName, destFile);
            }

            DirectoryInfo[] dirs = directoryInfo.GetDirectories();
            foreach (DirectoryInfo directory in dirs)
            {
                String destDir = Path.Combine(destination, directory.Name);
                CopyDirectory(directory.FullName, destDir);
            }
        }

        /// <summary>
        /// Restores the given backup archive
        /// </summary>
        /// <param name="backupFilePath"></param>
        /// <param name="extractDir"></param>
        public static void RestoreBackup(String backupFilePath, String extractDir)
        {
            FileInfo fileInfo = new FileInfo(backupFilePath);
            String workingDir = fileInfo.DirectoryName + @"\tmp";

            if (Directory.Exists(workingDir))
            {
                Directory.Delete(workingDir, true);
            }
            System.IO.Compression.ZipFile.ExtractToDirectory(backupFilePath, workingDir);

            if (!File.Exists(workingDir + "/backup.plan"))
            {
                Directory.Delete(workingDir, true);
                MessageBox.Show("Backup dont contains a valid backup plan");
                return;
            }

            XmlDocument xml = new XmlDocument();
            xml.Load(workingDir + "/backup.plan");
            XmlNode backupNode = xml.ChildNodes[0];

            // Move files
            foreach (XmlNode node in backupNode.ChildNodes[0].ChildNodes)
            {
                String name = node.Attributes["Name"].Value.ToString();
                String path = node.Attributes["Path"].Value.ToString();
                if (extractDir != null)
                {
                    path = extractDir + "/" + name;
                }
                String type = node.Attributes["Type"].Value.ToString();

                if (type == "directory")
                {
                    if (Directory.Exists(workingDir + "/" + name))
                    {
                        if (Directory.Exists(path))
                        {
                            Form1.DeleteDirectory(path);
                        }
                        Form1.CopyDirectory(workingDir + "/" + name, path);
                    }

                }
                else if (type == "file")
                {
                    if (File.Exists(workingDir + "/" + name))
                    {
                        File.Copy(workingDir + "/" + name, path);
                    }
                }
            }

            // Delete working dir
            Directory.Delete(workingDir, true);
        }

        /// <summary>
        /// Creates a new backup for the given plan
        /// </summary>
        /// <param name="plan"></param>
        public static void CreateBackup(String plan)
        {
            String exepath = System.Reflection.Assembly.GetEntryAssembly().Location;
            String planDir = Path.Combine(new FileInfo(exepath).DirectoryName, "Backups", plan);

            if (!File.Exists(planDir + "/backup.plan"))
            {
                MessageBox.Show("Backup plan file dont exist");
                return;
            }

            System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
            xml.Load(planDir + "/backup.plan");
            System.Xml.XmlNode backupNode = xml.ChildNodes[0];

            String backupName = "_" + plan + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            String backupDir = Path.Combine(planDir, backupName);
            if (!Directory.Exists(backupDir))
            {
                Directory.CreateDirectory(backupDir);
            }

            foreach (XmlNode node in backupNode.ChildNodes[0].ChildNodes)
            {
                String name = node.Attributes["Name"].Value.ToString();
                String path = node.Attributes["Path"].Value.ToString();
                String type = node.Attributes["Type"].Value.ToString();

                String filePath = Path.Combine(backupDir, name);
                if (type == "directory")
                {
                    Form1.CopyDirectory(path, filePath);
                }
                else if (type == "file")
                {
                    File.Copy(path, filePath);
                }
            }
            File.Copy(planDir + "/backup.plan", backupDir + "/backup.plan");

            System.IO.Compression.ZipFile.CreateFromDirectory(backupDir, backupDir + ".smlb");
            Form1.DeleteDirectory(backupDir);

            String now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff");
            backupNode.Attributes["LastBackup"].Value = now;
            backupNode.Attributes["LastBackupName"].Value = backupName;
            xml.Save(planDir + "/backup.plan");
        }

        /// <summary>
        /// Loads all backups in the listview
        /// </summary>
        public void LoadBackups()
        {
            this.listView1.Items.Clear();
            String exepath = System.Reflection.Assembly.GetEntryAssembly().Location;
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(new FileInfo(exepath).DirectoryName, "Backups"));
            DateTime now = DateTime.Now;
            bool needBackup = false;

            foreach (var dir in directoryInfo.GetDirectories())
            {
                if (File.Exists(dir.FullName + "/backup.plan"))
                {
                    // Load the plan
                    System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
                    xml.Load(dir.FullName + "/backup.plan");
                    System.Xml.XmlNode backupNode = xml.ChildNodes[0];

                    String planName = backupNode.Attributes["Name"].Value;
                    String schedule = backupNode.Attributes["Schedule"].Value;
                    String lastBackupDate = backupNode.Attributes["LastBackup"].Value;
                    String lastBackupName = backupNode.Attributes["LastBackupName"].Value;

                    ListViewItem item = new ListViewItem(planName);
                    item.SubItems.Add(schedule);
                    item.SubItems.Add(lastBackupDate);
                    item.SubItems.Add(lastBackupName);
                    item.ImageIndex = 0;

                    if (lastBackupDate != "")
                    {
                        DateTime lastBackupDT = DateTime.ParseExact(lastBackupDate, "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
                        if (schedule != null)
                        {
                            if (schedule == "24 Hours")
                            {
                                if ((now - lastBackupDT).TotalDays >= 1)
                                {
                                    item.ForeColor = Color.Red;
                                    item.SubItems.Add("Backup Schedule Expired");
                                    needBackup = true;
                                    item.ImageIndex = 1;
                                }
                            }
                            else if (schedule == "2 Days")
                            {
                                if ((now - lastBackupDT).TotalDays >= 2)
                                {
                                    item.ForeColor = Color.Red;
                                    item.SubItems.Add("Backup Schedule Expired");
                                    needBackup = true;
                                    item.ImageIndex = 1;
                                }
                            }
                            else if (schedule == "3 Days")
                            {
                                if ((now - lastBackupDT).TotalDays >= 3)
                                {
                                    item.ForeColor = Color.Red;
                                    item.SubItems.Add("Backup Schedule Expired");
                                    needBackup = true;
                                    item.ImageIndex = 1;
                                }
                            }
                            else if (schedule == "4 Days")
                            {
                                if ((now - lastBackupDT).TotalDays >= 4)
                                {
                                    item.ForeColor = Color.Red;
                                    item.SubItems.Add("Backup Schedule Expired");
                                    needBackup = true;
                                    item.ImageIndex = 1;
                                }
                            }
                            else if (schedule == "5 Days")
                            {
                                if ((now - lastBackupDT).TotalDays >= 5)
                                {
                                    item.ForeColor = Color.Red;
                                    item.SubItems.Add("Backup Schedule Expired");
                                    needBackup = true;
                                    item.ImageIndex = 1;
                                }
                            }
                            else if (schedule == "6 Days")
                            {
                                if ((now - lastBackupDT).TotalDays >= 6)
                                {
                                    item.ForeColor = Color.Red;
                                    item.SubItems.Add("Backup Schedule Expired");
                                    needBackup = true;
                                    item.ImageIndex = 1;
                                }
                            }
                            else if (schedule == "7 Days")
                            {
                                if ((now - lastBackupDT).TotalDays >= 7)
                                {
                                    item.ForeColor = Color.Red;
                                    item.SubItems.Add("Backup Schedule Expired");
                                    needBackup = true;
                                    item.ImageIndex = 1;
                                }
                            }
                        }
                        else
                        {
                            item.SubItems.Add("No Schedule");
                        }
                    }
                    this.listView1.Items.Add(item);

                }
            }

            if (needBackup)
            {
                if (MessageBox.Show("One or more plans need to create a backup. Would you like to create them now?", "Backup Schedule Expired", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<String> list = new List<String>();
                    foreach (ListViewItem item in this.listView1.Items)
                    {
                        if (item.SubItems.Count > 4)
                        {
                            if (item.SubItems[4].Text == "Backup Schedule Expired")
                            {
                                list.Add(item.Text);
                            }
                        }
                    }

                    BackupExpiredPlans backupExpired = new BackupExpiredPlans(this);
                    backupExpired.Show();
                    backupExpired.StartBackupPlans(list.ToArray());
                }
            }
        }

        /// <summary>
        /// Refresh List button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            LoadBackups();
        }

        /// <summary>
        /// Backup the selected plans
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            List<String> list = new List<String>();
            foreach (ListViewItem item in this.listView1.SelectedItems)
            {
                list.Add(item.Text);
            }

            if (list.Count > 0)
            {
                BackupExpiredPlans backupExpired = new BackupExpiredPlans(this);
                backupExpired.Show();
                backupExpired.StartBackupPlans(list.ToArray());
            }
        }

        /// <summary>
        /// Create Plan Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            CreateBackupPlan createBackup = new CreateBackupPlan(this);
            createBackup.Show();
        }

        /// <summary>
        /// Restore Backup button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count >= 1)
            {
                RestoreBackup restore = new RestoreBackup(this, this.listView1.SelectedItems[0].Text, this.listView1.SelectedItems[0].SubItems[3].Text + ".smlb");
                restore.Show();
            }
            else
            {
                MessageBox.Show("No plan selected!");
            }
        }

        /// <summary>
        /// Restore Expired Backups button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            List<String> list = new List<String>();
            foreach (ListViewItem item in this.listView1.Items)
            {
                if (item.SubItems.Count > 4)
                {
                    if (item.SubItems[4].Text == "Backup Schedule Expired")
                    {
                        list.Add(item.Text);
                    }
                }
            }

            if (list.Count > 0)
            {
                BackupExpiredPlans backupExpired = new BackupExpiredPlans(this);
                backupExpired.Show();
                backupExpired.StartBackupPlans(list.ToArray());
            }
        }

        /// <summary>
        /// Create Backup from the selected plan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<String> list = new List<String>();
            if (this.listView1.SelectedItems.Count >= 1)
            {
                list.Add(this.listView1.SelectedItems[0].Text);
                BackupExpiredPlans backupExpired = new BackupExpiredPlans(this);
                backupExpired.Show();
                backupExpired.StartBackupPlans(list.ToArray());
            }
        }

        /// <summary>
        /// Restore the selected backup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restoreBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count >= 1)
            {
                RestoreBackup restor = new RestoreBackup(this, this.listView1.SelectedItems[0].Text, this.listView1.SelectedItems[0].SubItems[3].Text + ".smlb");
                restor.Show();
            }
            else
            {
                MessageBox.Show("No plan selected!");
            }
        }

        /// <summary>
        /// Delete the selected backup plan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deletePlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count >= 1)
            {
                String planName = this.listView1.SelectedItems[0].Text;
                if (MessageBox.Show("Are you sure you want to delete the plan " + planName + "? This stepp cant be undone", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    String exepath = System.Reflection.Assembly.GetEntryAssembly().Location;
                    String planPath = Path.Combine(new FileInfo(exepath).DirectoryName, "Backups", planName);
                    if (Directory.Exists(planPath))
                    {
                        Directory.Delete(planPath, true);
                        LoadBackups();
                        MessageBox.Show("Done");
                    }
                }
            }
            else
            {
                MessageBox.Show("No plan selected!");
            }
        }

        /// <summary>
        /// Opens the explore in the selected backup plan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showBackupFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count >= 1)
            {
                String exepath = System.Reflection.Assembly.GetEntryAssembly().Location;
                String planPath = Path.Combine(new FileInfo(exepath).DirectoryName, "Backups", this.listView1.SelectedItems[0].Text);
                Process.Start("explorer.exe", "/open, \"" + planPath + "\"");
            }
            else
            {
                MessageBox.Show("No plan selected!");
            }
        }

        /// <summary>
        /// Export the backups from the selected plan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportBackupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count >= 1)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Smartli Backup Archieve | *.smlav";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    String exepath = System.Reflection.Assembly.GetEntryAssembly().Location;
                    String planPath = Path.Combine(new FileInfo(exepath).DirectoryName, "Backups", this.listView1.SelectedItems[0].Text);
                    MessageBox.Show("Starting to export the archive. This may take a while. Please wait untill the export is finished");
                    System.Threading.Thread thread = new System.Threading.Thread(() =>
                    {
                        exportPlanAsynch(saveFileDialog.FileName, planPath);
                    });
                    thread.Start();
                }
            }
            else
            {
                MessageBox.Show("No plan selected!");
            }
        }

        /// <summary>
        /// Export the plans
        /// </summary>
        /// <param name="archiveName"></param>
        /// <param name="planPath"></param>
        private void exportPlanAsynch(String archiveName, String planPath)
        {
            this.Invoke(new Action(() =>
            {
                this.progressBar1.Visible = true;
                this.progressBar1.Style = ProgressBarStyle.Marquee;
                this.progressBar1.MarqueeAnimationSpeed = 10;
            }));

            if (File.Exists(archiveName))
            {
                File.Delete(archiveName);
            }
            System.IO.Compression.ZipFile.CreateFromDirectory(planPath, archiveName);

            this.Invoke(new Action(() =>
            {
                LoadBackups();
                this.progressBar1.Style = ProgressBarStyle.Continuous;
                this.progressBar1.Visible = false;
            }));

            MessageBox.Show("Export Done.");
        }

        /// <summary>
        /// Import plan archives
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importBackupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Smartli Backup Archieve | *.smlav";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.Threading.Thread thread = new System.Threading.Thread(() =>
                {
                    this.Invoke(new Action(() =>
                    {
                        this.progressBar1.Visible = true;
                        this.progressBar1.Style = ProgressBarStyle.Marquee;
                        this.progressBar1.MarqueeAnimationSpeed = 10;
                    }));

                    ImportBackupPlanArchiveAsync(openFileDialog.FileName);

                    this.Invoke(new Action(() =>
                    {
                        LoadBackups();
                        this.progressBar1.Style = ProgressBarStyle.Continuous;
                        this.progressBar1.Visible = true;
                    }));
                });
                thread.Start();
            }
        }

        /// <summary>
        /// Import the given archive
        /// </summary>
        /// <param name="archiveName"></param>
        public static void ImportBackupPlanArchiveAsync(string archiveName)
        {
            // Get File info and pathes
            FileInfo fileInfo = new FileInfo(archiveName);
            String filename = Path.GetFileNameWithoutExtension(fileInfo.FullName);
            String exepath = System.Reflection.Assembly.GetEntryAssembly().Location;
            String workingDir = new FileInfo(exepath).DirectoryName + "/import";

            // Unzip archive into the working directory
            if (Directory.Exists(workingDir))
            {
                Directory.Delete(workingDir, true);
            }
            System.IO.Compression.ZipFile.ExtractToDirectory(archiveName, workingDir);

            // Check if plan exist
            if (!File.Exists(workingDir + "/backup.plan"))
            {
                Directory.Delete(workingDir);
                MessageBox.Show("The selectet archive dont contains a backup.plan file");
                return;
            }

            // Check if the plan allredy exist
            System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
            xml.Load(workingDir + "/backup.plan");
            System.Xml.XmlNode backupNode = xml.ChildNodes[0];
            String planName = backupNode.Attributes["Name"].Value;
            String planPath = Path.Combine(new FileInfo(exepath).DirectoryName, "Backups", planName);

            if (Directory.Exists(planPath))
            {
                Directory.Delete(workingDir, true);
                MessageBox.Show("There exist a plan allready with the name " + filename);
                return;
            }

            // Move working dir to backups
            Directory.Move(workingDir, planPath);
            MessageBox.Show("Plan imported");
        }

        /// <summary>
        /// Timer action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.LoadBackups();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                String plan = this.listView1.SelectedItems[0].Text;
                ExportEncryptedArchive export = new ExportEncryptedArchive(plan);
                export.Show();
            }
            else
            {
                MessageBox.Show("Please select the plan to export");
            }
        }

        private void importDecryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportEncryptedArchive import = new ImportEncryptedArchive(this);
            import.Show();
        }
    }
}