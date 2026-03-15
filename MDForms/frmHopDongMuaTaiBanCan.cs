using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using MDSolution.MDForms;
namespace MDSolution
{
    public partial class frmHopDongMuaTaiBanCan : Form
    {

        private DataSet dsHopDongMuaTaiBanCan;
        public frmHopDongMuaTaiBanCan()
        {
            InitializeComponent();

        }
        public void LoadHopDong()
        {
            string strSQL = @"SELECT TOP (100) PERCENT dbo.tbl_HopDong.SoCMT, dbo.tbl_HopDong.NguoiThuaKe1Ten, dbo.tbl_HopDong.HoTen, dbo.tbl_HopDong.NgayNhapMuaTaiBanCan, dbo.sys_User.UserName, dbo.tbl_HopDong.MaHopDong, 
                  dbo.tbl_HopDong.MuaTaiBanCan AS NguoiNhap, dbo.tbl_HopDong.ID, CASE 
                  WHEN ISNULL(dbo.tbl_HopDongVuTrong.ChuyenKeToan,0) =  0 THEN N' '
	              else N'Không chuyển' END AS ChuyenKeToan,dbo.tbl_HopDongVuTrong.HopDongID
                  FROM     dbo.tbl_HopDong INNER JOIN
                  dbo.sys_User ON dbo.tbl_HopDong.NguoiNhapMuaTaiBanCanID = dbo.sys_User.ID INNER JOIN
                  dbo.tbl_HopDongVuTrong ON dbo.tbl_HopDong.ID = dbo.tbl_HopDongVuTrong.HopDongID
                  WHERE  (dbo.tbl_HopDongVuTrong.MuaTaiBanCan = 1) AND dbo.tbl_HopDongVuTrong.VuTrongID =" + MDSolutionApp.VuTrongID + "ORDER BY dbo.tbl_HopDong.MaHopDong";
            this.dsHopDongMuaTaiBanCan = DBModule.ExecuteQuery(strSQL, null, null);
            if (this.dsHopDongMuaTaiBanCan.Tables.Count > 0)
            {
                this.gdVHopDongMuaTaiBanCan.SetDataBinding(this.dsHopDongMuaTaiBanCan.Tables[0], "RootTable");
            }
            if (MDSolutionApp.User.ID == 1)
            {
                btChuyenKeToan.Enabled = true;
            }
        }
        private void frmHopDongMuaTaiBanCan_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            lblTitleHDVC.Text = lblTitleHDVC.Text + MDSolutionApp.VuTrongTen;
            this.LoadHopDong();
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            long IDHD = 0;
            MDSolution.dlgHopDong frm = new dlgHopDong();
            frm.ShowDialog();

            try
            {
                IDHD = frm.HopDongID;
                // IDHD = int.Parse(frm.passID.ToString());
            }
            catch { }
            if (IDHD > 0)
            {
                try
                {
                    string sql = " Update tbl_HopDong set MuaTaiBanCan=1, NguoiNhapMuaTaiBanCanID=" + int.Parse(MDSolutionApp.User.ID.ToString()) + ",NgayNhapMuaTaiBanCan= " + DBModule.RefineDatetime(DateTime.Now) + " Where ID =" + IDHD;
                    DBModule.ExecuteNonQuery(sql, null, null);
                    string sqlHDVT = "update tbl_HopDongVuTrong set MuaTaiBanCan=1,NgayApDungMua= GETDATE() where VuTrongID=" + MDSolutionApp.VuTrongID + " and HopDongID= " + IDHD;
                    DBModule.ExecuteNonQuery(sqlHDVT, null, null);
                    MessageBox.Show("Bạn thêm mới thành công", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHopDong();
                }
                catch
                {
                    MessageBox.Show("Bạn thêm mới không thành công", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn thêm mới chưa thành công", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {

        }



        private void cmd2Excel_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.FileName = "Danhsach_HopdongMuaTaiBanCan_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = gdVHopDongMuaTaiBanCan;
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


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdChuyenVu_Click(object sender, EventArgs e)
        {
            if (MDSolutionApp.User.ID == 83063 || MDSolutionApp.User.ID == 1)
            {
                long HD_ID = -1;
                try
                {
                    HD_ID = long.Parse(this.gdVHopDongMuaTaiBanCan.GetValue("ID").ToString());
                }
                catch { }
                if ((HD_ID > 0))
                {
                    try
                    {
                        string sql = " Update tbl_HopDong set MuaTaiBanCan=NULL, NguoiNhapMuaTaiBanCanID=" + int.Parse(MDSolutionApp.User.ID.ToString()) + ",NgayNhapMuaTaiBanCan= " + DBModule.RefineDatetime(DateTime.Now) + " Where ID =" + HD_ID;
                        DBModule.ExecuteNonQuery(sql, null, null);
                        string sqlHDVT = "update tbl_HopDongVuTrong set MuaTaiBanCan=NULL,NgayApDungMua=NULL where VuTrongID=" + MDSolutionApp.VuTrongID + " and HopDongID= " + HD_ID;
                        DBModule.ExecuteNonQuery(sqlHDVT, null, null);
                        MessageBox.Show("Đã xóa bỏ hợp đồng mua bán tại bàn cân", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHopDong();
                    }
                    catch
                    {
                        MessageBox.Show("Không xóa được hợp đồng mua bán tại bàn cân", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền xóa", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }       

        private void btChuyenKeToan_Click(object sender, EventArgs e)
        {
            long IDHD = 0;
            string CoChuyen = " ";
            IDHD = long.Parse(this.gdVHopDongMuaTaiBanCan.GetValue("HopDongID").ToString());
            try
            {
                CoChuyen = this.gdVHopDongMuaTaiBanCan.GetValue("ChuyenKeToan").ToString();
            }
            catch { }
            if (IDHD > 0)
            {
                if (CoChuyen == " ")
                {
                    try
                    {
                        string sqlChuyenKT = "update tbl_HopDongVuTrong set ChuyenKeToan=1 where VuTrongID=" + MDSolutionApp.VuTrongID + " and HopDongID= " + IDHD;
                        DBModule.ExecuteNonQuery(sqlChuyenKT, null, null);
                    }
                    catch
                    {
                    }
                    MessageBox.Show("Đã cập nhật thành công", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        string sqlChuyenKT = "update tbl_HopDongVuTrong set ChuyenKeToan=NULL where VuTrongID=" + MDSolutionApp.VuTrongID + " and HopDongID= " + IDHD;
                        DBModule.ExecuteNonQuery(sqlChuyenKT, null, null);
                    }
                    catch
                    {
                    }
                    MessageBox.Show("Đã cập nhật thành công", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LoadHopDong();
        }
    }
}