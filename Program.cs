using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
//using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Web.Script.Serialization;
using System.Data;

namespace MDSolution
{
  
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
         
            try
            {

                DBModule.PathConfig = Application.StartupPath;
                DBModule.BuildDatabaseParameters();
                int check = DBModule.ExecuteNonQuery("SELECT DB_NAME()", null, null);
                Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(true);
                MDSolutionApp.Initialize();
                //splash.Close();
                //splash.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiểm tra lại thiết lập kết nối với internet\n" + ex.Message, "SLS",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //frmDataConnection frm = new frmDataConnection();
                //frm.ShowDialog();
                //Gọi form để thực hiện lại việc kết nối với máy chủ dữ liệu
                //Kiểm tra kết quả trả về 
                //OK
                //Application.Restart();
                //ELSE
                Application.Exit();

            }
        }

    }
}