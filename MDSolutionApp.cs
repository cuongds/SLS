using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net;
using ICSharpCode.SharpZipLib.Zip;

namespace MDSolution
{
    public partial class MDSolutionApp
    {
        public class MDUpdate
        {
            public string Version;
            public string UrlUpdate;
            public string MD5Code;
        }
        public static string MessageCaption = "MD 2008 - Hello";
        public static long VuTrongID = 1;
        public static long ChotDuLieuDienTich = 0;
        public static string VuTrongTen = "";
        public static clsUser User;

        //private MainForm mMainForm;
        //private static string _vutrongid = "";
        private MDIParent1 mMDIParent;
        public static MDIParent1 MDIParent
        {
            get
            {
                if (mApplication == null)
                {
                    return null;
                }
                return mApplication.mMDIParent;
            }
        }

        private static MDSolutionApp mApplication;
        private static frmSplashScreen splash = new frmSplashScreen();
        private static bool downloadComplete = false;

        public static void Initialize()
        {
            MDUpdate mdUpdate = new MDUpdate();

            string ParthUpdate = "";
            string Version = "1.0";
            splash = new frmSplashScreen();
            splash.Show();
            splash.Update();

            //check Version:
            try
            {
                string sql = @"SELECT [Version],[UrlUpdate],isnull(MD5Code,'') as MD5Code FROM [sys_Version]
                                        WHERE [Version] =(select MAX([Version]) from [sys_Version])";
                DataSet ds = DBModule.ExecuteQuery(sql, null, null);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //update using http api
                    //System.Net.WebClient client = new System.Net.WebClient();
                    //client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    //client.BaseAddress = DBModule.ParthUpdate;
                    //string respone = client.DownloadString(DBModule.ParthUpdate + "/api/Version?appid=MDSonLa");
                    //JavaScriptSerializer ser = new JavaScriptSerializer();
                    //mdUpdate = ser.Deserialize<MDUpdate>(respone);
                    mdUpdate.Version = ds.Tables[0].Rows[0]["Version"].ToString();
                    mdUpdate.UrlUpdate = ds.Tables[0].Rows[0]["UrlUpdate"].ToString();
                    mdUpdate.MD5Code = ds.Tables[0].Rows[0]["MD5Code"].ToString();
                    Version = mdUpdate.Version;
                    //---------

                    //StreamReader f = File.OpenText(DBModule.ParthUpdate + "\\database.cfg");
                    //string s;
                    //string[] spl;

                    //while (null != (s = f.ReadLine()))
                    //{
                    //    spl = s.Split('=');
                    //    switch (spl[0].Trim().ToLower())
                    //    {
                    //        case "parthupdate": ParthUpdate = spl[1]; break;
                    //        case "version": Version = spl[1]; break;
                    //    }
                    //}
                    //f.Close();

                }
                if (Version.CompareTo(DBModule.Version) > 0)
                {
                    //Download update file: 
                    splash.progressBar.Value = 0;
                    splash.progressBar.Visible = true;
                    splash.lbMsg.Text = "Có phiên bản mới, vui lòng chờ trong giây lát để hệ thống cập nhật...";
                    splash.lbMsg.Refresh();
                    splash.progressBar.Refresh();
                    System.Net.WebClient client = new System.Net.WebClient();
                    client.Headers[HttpRequestHeader.ContentType] = "application/octet-stream";
                    client.BaseAddress = DBModule.ParthUpdate;
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                    client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    client.DownloadFileAsync(new Uri(mdUpdate.UrlUpdate), mdUpdate.Version + ".zip");
                    while (!downloadComplete)
                    {
                        Application.DoEvents();
                    }

                    downloadComplete = false;
                    splash.lbMsg.Text = "";
                    splash.lbMsg.Refresh();
                    DBModule.UpdateVersion(mdUpdate.Version);
                    //System.Threading.Thread.Sleep(20000);
                    System.Diagnostics.Process.Start("MDUpdate.exe", "\"" + Application.StartupPath + "\\" + mdUpdate.Version + ".zip\" \"" + Application.StartupPath + "\\NewVersion" + "\"");
                    Application.Exit();
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Có lỗi khi cập nhật phiên bản mới. Vui lòng cập nhật phiên bản thủ công." + ex.Message + mdUpdate.UrlUpdate, "Có lỗi khi cập nhật phiên bản mới");
                MDForms.ManualUpdateVersion frm = new MDForms.ManualUpdateVersion();
                frm.lbThisVer.Text = DBModule.Version;
                frm.lbNewVer.Text = Version;
                frm.txtUrl.Text = mdUpdate.UrlUpdate;
                frm.MD5Code = mdUpdate.MD5Code;
                frm.ShowDialog();
                //if (frm.ShowDialog() == DialogResult.OK)
                //{

                //    //try
                //    //{
                //    //    DBModule.UpdateVersion(mdUpdate.Version);

                //    //    FastZip fastZip = new FastZip();
                //    //    string fileFilter = null;
                //    //    fastZip.ExtractZip( Application.StartupPath + "\\" + mdUpdate.Version + ".zip", Application.StartupPath + "\\NewVersion" , fileFilter);
                //    //    // Console.WriteLine("Bam Enter de cap nhat.");
                //    //    //Console.ReadLine();
                //    //    System.Diagnostics.Process.Start("updateVer.bat");
                //    //}
                //    //catch (Exception ex2)
                //    //{
                //    //    System.IO.File.AppendAllText("log.txt", "\r\n" + DateTime.Now + ":" + ex2.Message + ex2.Source);


                //    //}
                //   // System.Diagnostics.Process.Start("MDUpdate.exe", "\"" + Application.StartupPath + "\\" + mdUpdate.Version + ".zip\" \"" + Application.StartupPath + "\\NewVersion" + "\"");

                //}  
                Application.Exit();
                return;
            }
            //

            mApplication = new MDSolutionApp();
            mApplication.mMDIParent = new MDIParent1();

            try
            {
                splash.Close();
                splash.Dispose();
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
                Application.Run(mApplication.mMDIParent);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        static void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            splash.lbMsg.Text = "Cập nhật xong, vui lòng chờ để hệ thống khởi động.";
            splash.lbMsg.Refresh();
            downloadComplete = true;
        }

        static void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            splash.progressBar.Value = e.ProgressPercentage;
            splash.progressBar.Refresh();
        }

        public static MDSolutionApp MDSolutionApplication
        {
            get
            {
                return mApplication;
            }
        }

    }

} //end of root namespace