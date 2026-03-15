using System;
using System.Windows.Forms;
using System.Data;

namespace MDSolution
{
    public partial class MDIParent1 : Form
    {
        public static string strVuTrong = "";
        private frmStatus statusF = new frmStatus();
        
        public MDIParent1()
        {
            InitializeComponent();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = this.Text + "-" + DBModule.Version;
                
                // Hi?n th? thông tin h?p ??ng thay ??i n?u có:
                DateTime DenNgay = DateTime.Now;
                string sql = "select isnull(DateReadNotify,'2000-01-01') as DateReadNotify from core.User where ID={0}";
                try
                {
                    DataSet dsUser = DBModule.ExecuteQuery(string.Format(sql, MDSolutionApp.User.ID), null, null);
                    if (dsUser != null && dsUser.Tables.Count > 0 && dsUser.Tables[0].Rows.Count > 0)
                    {
                        DateTime TuNgay = (DateTime)dsUser.Tables[0].Rows[0][0];
                        
                        sql = "select * from dbo.sys_HopDong_log where CreateDate>={0} and CreateDate<={1}";
                        DataSet ds = DBModule.ExecuteQuery(string.Format(sql, DBModule.RefineDatetime(TuNgay), DBModule.RefineDatetime(DenNgay)), null, null);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            frmHopDongLog frm = new frmHopDongLog();
                            frm.DateView = DenNgay;
                            frm.gdHopDongLog.SetDataBinding(ds.Tables[0], "RootTable");
                            frm.Text += "(" + ds.Tables[0].Rows.Count + ")";
                            frm.StartPosition = FormStartPosition.CenterScreen;
                            frm.ShowDialog();
                        }
                    }
                }
                catch (Exception exx)
                {
                    // Log error silently
                }
            }
            catch
            {
            }
        }

        private void MDIParent1_MdiChildActivate(object sender, EventArgs e)
        {
            // MDI child activation logic
        }

        private void cmdKetThuc_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuUsers_Click(object sender, EventArgs e)
        {
            frmQuanLyNguoiDung frm = new frmQuanLyNguoiDung();
            frm.ShowDialog();
        }

        private void phânQuy?nToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhanQuyen_Cum frm = new frmPhanQuyen_Cum();
            frm.ShowDialog();
        }

        private void l?chS?S?aXóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_history frm = new frm_history();
            frm.ShowDialog();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
