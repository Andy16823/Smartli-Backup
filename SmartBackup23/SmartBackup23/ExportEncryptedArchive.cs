using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBackup23
{
    public partial class ExportEncryptedArchive : Form
    {
        private String plan;

        public ExportEncryptedArchive(string plan)
        {
            InitializeComponent();
            this.plan = plan;
            this.label2.Text = plan;
        }

        private void ExportEncryptedArchive_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Start encryption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != String.Empty)
            {
                String password = this.textBox1.Text;
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Encrypted Smartli Backup Archieve | *.esmlav";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Thread thread = new Thread(() =>
                    {
                        String exepath = System.Reflection.Assembly.GetEntryAssembly().Location;
                        String planPath = Path.Combine(new FileInfo(exepath).DirectoryName, "Backups", plan);
                        exportPlanAsynch(saveFileDialog.FileName, planPath, password);
                    });
                    thread.Start();
                }
            }
            else
            {
                MessageBox.Show("Please select a password");
            }
        }

        private void exportPlanAsynch(String archiveName, String planPath, String password)
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

            FileInfo fileInfo = new FileInfo(archiveName);
            String outputFile = fileInfo.DirectoryName + "/enc_" + fileInfo.Name;
            ExportEncryptedArchive.EncryptFile(archiveName, outputFile, password);
            File.Delete(archiveName);
            File.Move(outputFile, archiveName);

            this.Invoke(new Action(() =>
            {
                this.progressBar1.Style = ProgressBarStyle.Continuous;
                this.progressBar1.Visible = false;
            }));

            MessageBox.Show("Export Done.");
        }

        /// <summary>
        /// Encrypt the file
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        /// <param name="password"></param>
        public static void EncryptFile(string inputFile, string outputFile, string password)
        {
            byte[] salt = GenerateSalt();

            using (AesManaged aes = new AesManaged())
            {
                byte[] key = GenerateKey(password, salt, aes.KeySize / 8);
                byte[] iv = GenerateIV(password, salt, aes.BlockSize / 8);

                using (FileStream inputFileStream = new FileStream(inputFile, FileMode.Open))
                {
                    using (FileStream outputFileStream = new FileStream(outputFile, FileMode.Create))
                    {
                        using (ICryptoTransform encryptor = aes.CreateEncryptor(key, iv))
                        {
                            outputFileStream.Write(salt, 0, salt.Length);

                            using (CryptoStream cryptoStream = new CryptoStream(outputFileStream, encryptor, CryptoStreamMode.Write))
                            {
                                inputFileStream.CopyTo(cryptoStream);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Generates a salt for decription
        /// </summary>
        /// <returns></returns>
        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(salt);
            }
            return salt;
        }

        /// <summary>
        /// Generates the key
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="keySize"></param>
        /// <returns></returns>
        private static byte[] GenerateKey(string password, byte[] salt, int keySize)
        {
            using (Rfc2898DeriveBytes keyDerivationFunction = new Rfc2898DeriveBytes(password, salt))
            {
                return keyDerivationFunction.GetBytes(keySize);
            }
        }


        /// <summary>
        /// Generates the IV
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="ivSize"></param>
        /// <returns></returns>
        private static byte[] GenerateIV(string password, byte[] salt, int ivSize)
        {
            using (Rfc2898DeriveBytes ivDerivationFunction = new Rfc2898DeriveBytes(password, salt))
            {
                return ivDerivationFunction.GetBytes(ivSize);
            }
        }
    }
}
