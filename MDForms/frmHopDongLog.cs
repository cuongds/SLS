using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms
{
    public partial class frmHopDongLog : Form
    {
        public frmHopDongLog()
        {
            InitializeComponent();
        }
        public DateTime DateView;
        private void btnDaXem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đã đọc và không muốn hiển thị các thông tin này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                string sql = "update sys_User set DateReadNotify={0} where ID={1}";
                DBModule.ExecuteNonQuery(string.Format(sql, DBModule.RefineDatetime(DateView), MDSolutionApp.User.ID), null, null);
                this.Close();
            }
        }

        private void frmHopDongLog_Load(object sender, EventArgs e)
        {

        }

        private void gdHopDongLog_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(gdHopDongLog.GetValue("ID").ToString()))
                {
                    int ID = Int32.Parse(gdHopDongLog.GetValue("ID").ToString());
                    string sql = "Select NoiDung from dbo.sys_HopDong_log where ID= " + ID;
                    ribNoiDung.Text = DBModule.ExecuteQueryForOneResult(sql, null, null);
                    // gdHopDongLog.GetValue("NoiDung").ToString().Trim();
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadDSTaiKhoan()
        {
            string sql = @"select * from dbo.sys_HopDong_log where NoiDung like N'%Số tài khoản%' order by ID desc";
            try {
                grvDSTK.SetDataBinding(DBModule.ExecuteQuery(sql, null, null).Tables[0], "");
            }
            catch {
                MessageBox.Show("Không có thông tin");
            }

        }

        private void tabTheoDoiSanLuong_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (tabTheoDoiSanLuong.SelectedTab == tabTaiKhoan)
            {
                LoadDSTaiKhoan();
            }
        }

        private void cmd2ExcelTheoKH_Click(object sender, EventArgs e)
        {
            if (this.grvDSTK.RowCount > 0)
            {
                try
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                        {
                            Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                            exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                            exporter.GridEX = grvDSTK;
                            exporter.Export(fs);
                            fs.Close();
                            MessageBox.Show("Đã export ra file excel!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                catch
                {
                    MessageBox.Show("Có lỗi khi lưu dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gdHopDongLog_SelectionChanged(object sender, MouseEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(gdHopDongLog.GetValue("ID").ToString()))
                {
                    int ID = Int32.Parse(gdHopDongLog.GetValue("ID").ToString());
                    string sql = "Select NoiDung from dbo.sys_HopDong_log where ID= " + ID;
                    ribNoiDung.Text = DBModule.ExecuteQueryForOneResult(sql, null, null);
                    // gdHopDongLog.GetValue("NoiDung").ToString().Trim();
                }
            }
            catch { }
        }
    }
}
