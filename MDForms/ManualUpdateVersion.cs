using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using ICSharpCode.SharpZipLib.Zip;

namespace MDSolution.MDForms
{
    public partial class ManualUpdateVersion : Form
    {
        public ManualUpdateVersion()
        {
            InitializeComponent();
        }

        private void lNewVer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("IEXPLORE.EXE", txtUrl.Text);
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            string sum = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(openFileDialog1.OpenFile()));
            sum = sum.Replace("-", "");
            if (sum != MD5Code)
            {
                MessageBox.Show("File bạn chọn không đúng, vui lòng chọn lại file.");
                txtFile.Text = "";
                return;
            }
            try
            {
                DBModule.UpdateVersion(lbNewVer.Text);
                
                FastZip fastZip = new FastZip();
                string fileFilter = null;
                fastZip.ExtractZip(openFileDialog1.FileName, Application.StartupPath + "\\NewVersion", fileFilter);
                // Console.WriteLine("Bam Enter de cap nhat.");
                //Console.ReadLine();
              
              
                System.Diagnostics.Process.Start(Application.StartupPath + "\\updateVerManual.bat");
            }
            catch (ZipException ex2)
            {
                MessageBox.Show("Lỗi khi cập nhật:"+ex2.Message + ex2.Source);
                System.IO.File.AppendAllText("log.txt", "\r\n" + DateTime.Now + ":" + ex2.Message + ex2.Source);


            }
            txtFile.Text = openFileDialog1.FileName;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFile.Text))
            {
                MessageBox.Show("File bạn chưa chọn file cập nhật.");

                return;
            }

            System.IO.File.Copy(txtFile.Text, Application.StartupPath + "\\" + lbNewVer.Text + ".zip", true);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void ManualUpdateVersion_Load(object sender, EventArgs e)
        {

        }
        public string MD5Code;
    }
}
