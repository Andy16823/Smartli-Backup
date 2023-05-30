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
    public partial class ImportEncryptedArchive : Form
    {
        private String archiveName;
        private Form1 parent;

        public ImportEncryptedArchive(Form1 form1)
        {
            InitializeComponent();
            this.parent = form1;
        }

        private void ImportEncryptedArchive_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Decrypts the file
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        /// <param name="password"></param>
        public static bool DecryptFile(string inputFile, string outputFile, string password)
        {
            using (FileStream inputFileStream = new FileStream(inputFile, FileMode.Open))
            {
                byte[] salt = new byte[16];
                inputFileStream.Read(salt, 0, salt.Length);

                using (AesManaged aes = new AesManaged())
                {
                    byte[] key = GenerateKey(password, salt, aes.KeySize / 8);
                    byte[] iv = GenerateIV(password, salt, aes.BlockSize / 8);

                    using (ICryptoTransform decryptor = aes.CreateDecryptor(key, iv))
                    {
                        using (FileStream outputFileStream = new FileStream(outputFile, FileMode.Create))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(inputFileStream, decryptor, CryptoStreamMode.Read))
                            {
                                try
                                {
                                    cryptoStream.CopyTo(outputFileStream);
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != null && this.textBox2.Text != null)
            {
                String archive = this.textBox2.Text;
                String password = this.textBox1.Text;

                System.Threading.Thread thread = new System.Threading.Thread(() =>
                {
                    this.Invoke(new Action(() =>
                    {
                        this.progressBar1.Style = ProgressBarStyle.Marquee;
                        this.progressBar1.MarqueeAnimationSpeed = 10;
                    }));

                    FileInfo fileInfo = new FileInfo(archive);
                    String outputFile = fileInfo.DirectoryName + "/dec_" + fileInfo.Name;
                    if (ImportEncryptedArchive.DecryptFile(archive, outputFile, password))
                    {
                        Form1.ImportBackupPlanArchiveAsync(outputFile);
                        File.Delete(outputFile);
                    }
                    else
                    {
                        File.Delete(outputFile);
                    }

                    

                    this.Invoke(new Action(() =>
                    {
                        parent.LoadBackups();
                        this.progressBar1.Style = ProgressBarStyle.Continuous;
                    }));
                });
                thread.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Encrypted Smartli Backup Archieve | *.esmlav";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.Text = openFileDialog.FileName;
            }
        }
    }
}
