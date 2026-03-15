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
    public partial class frmHopDongVanChuyen : Form
    {
      
        private DataSet dsHopDongVanChuyen;
        public frmHopDongVanChuyen()
        {
            InitializeComponent();
        }
        public void LoadHopDongVanChuyen()
        {
            string strSQL = @"SELECT    HD.ID AS HopDongVanChuyenID,    HD.MaHopDong,    HD.TenChuHopDong,    HD.CMT,    HD.NgayCapCMT,    HD.NoiCap,    HD.NguyenQuan,    HD.DiaChi, 
            HD.SoTKNganHang,    HD.NgayHopDong,    HD.DienThoai,    HD.MaSoThue,    HD.DaChuyenVu,    ISNULL(HD.MuaTaiBanCan, 0) AS MuaTaiBanCan,    XE.ID AS XeVanChuyenID,    XE.SoXe, 
            XE.TenLaiXe,    XE.TrongTai,    XE.LoaiXe,    XE.GhiChu,    nm.ShipmentCount, nm.TotalTienVanChuyen, nm.TotalTrongLuong FROM dbo.tbl_XeVanChuyen AS XE RIGHT OUTER JOIN 
            dbo.tbl_HopDongVanChuyen AS HD    ON XE.HopDongVanChuyenID = HD.ID LEFT JOIN (    SELECT        XeID,        COUNT(ID) AS ShipmentCount,        SUM(ISNULL(TienVanChuyen,0)) AS TotalTienVanChuyen,    
            SUM(ISNULL(TongTrongLuong,0) - ISNULL(TrongLuongXe,0) - ISNULL(TrongLuongTapVat,0)) AS TotalTrongLuong    FROM dbo.tbl_NhapMia    WHERE VuTrongID = " + MDSolutionApp.VuTrongID.ToString() + 
            " GROUP BY XeID) AS nm  ON nm.XeID = XE.ID WHERE HD.VuTrongID ="+ MDSolutionApp.VuTrongID.ToString()+
            " ORDER BY LEN(HD.MaHopDong), HD.MaHopDong";
            this.dsHopDongVanChuyen = DBModule.ExecuteQuery(strSQL,null, null);
            if (this.dsHopDongVanChuyen.Tables.Count > 0)
            {
                this.gdVHopDongVanChuyen.SetDataBinding(this.dsHopDongVanChuyen.Tables[0], "RootTable");
            }
        }
      
    
      
        private void frmHopDongVanChuyen_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            lblTitleHDVC.Text = lblTitleHDVC.Text + MDSolutionApp.VuTrongTen;
            this.LoadHopDongVanChuyen();
        }        

        private void gdVHopDongVanChuyen_FormattingRow(object sender, RowLoadEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Row.Cells["NgayHopDong"].Text))
                {
                    DateTime dt;
                    dt = DateTime.Parse(e.Row.Cells["NgayHopDong"].Text);
                    e.Row.Cells["NgayHopDong"].Text = dt.ToShortDateString();
                }
            }
            catch
            {
                e.Row.Cells["NgayHopDong"].Text = "";
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.F8:
                        
                        MDSolution.MDDataSetForms.frmHopDongVanChuyen_ThemMoi frm = new MDSolution.MDDataSetForms.frmHopDongVanChuyen_ThemMoi("");
                        frm.ShowDialog();
                        LoadHopDongVanChuyen();
                        break;
                    case Keys.F4:
                    
                        try
                        {
                            if (this.gdVHopDongVanChuyen.GetValue("ID").ToString() != "")
                            {
                                frmChiTietChuVanChuyen abc = new frmChiTietChuVanChuyen(long.Parse(this.gdVHopDongVanChuyen.GetValue("ID").ToString()));
                                abc.ShowDialog();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
                        }
                        break;
                    case Keys.F9:
                        try
                        {
                            if (this.gdVHopDongVanChuyen.GetValue("ID").ToString() != "")
                            {
                                MDSolution.MDDataSetForms.frmHopDongVanChuyen_ThemMoi a = new MDSolution.MDDataSetForms.frmHopDongVanChuyen_ThemMoi(this.gdVHopDongVanChuyen.GetValue("ID").ToString());
                                a.ShowDialog();
                                LoadHopDongVanChuyen();
                            }
                            else { MessageBox.Show("Bạn chưa chọn hợp đồng để sửa", "Thông báo"); }
                        }
                        catch { MessageBox.Show("Bạn chưa chọn hợp đồng để sửa", "Thông báo"); }
                        break;
                    ////    gdVHopDongVanChuyen.EditMode = EditMode.EditOn;
                    ////    label1.Text = "F2-Lưu / Esc-Bỏ qua";
                    ////    break;
                    ////case Keys.Escape:
                    ////    // Code cho phim Esc
                    ////    gdVHopDongVanChuyen.CancelCurrentEdit();
                    ////    label1.Text = "F8-Thêm mới / F9-Sửa / F4-Chi tiết / Delete-Xóa / F6-In danh sách";
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void btThem_Click(object sender, EventArgs e)
        {
            MDSolution.MDForms.VanChuyen.frmHopDongVanChuyen_ThemMoi frm = new MDSolution.MDForms.VanChuyen.frmHopDongVanChuyen_ThemMoi();
            frm.ShowDialog();
            if (frm._IDHD > 0)
            {
                try
                {
                    LoadHopDongVanChuyen();
                    GridEXFilterCondition condi = new GridEXFilterCondition(gdVHopDongVanChuyen.Tables[0].Columns["HopDongVanChuyenID"], ConditionOperator.Equal, frm._IDHD);
                    gdVHopDongVanChuyen.Find(condi, 0, 1);
                    MessageBox.Show("Đã thêm mới HĐVC", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch { }
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            long HDVC_ID = -1;
            long XeVC_ID = -1;
            try
            {
                HDVC_ID = long.Parse(this.gdVHopDongVanChuyen.GetValue("HopDongVanChuyenID").ToString());
                XeVC_ID = long.Parse(this.gdVHopDongVanChuyen.GetValue("XeVanChuyenID").ToString());
            }
            catch { }
            if (HDVC_ID > 0)
            {
                MDSolution.MDForms.VanChuyen.frmHopDongVanChuyen_ThemMoi frm = new MDSolution.MDForms.VanChuyen.frmHopDongVanChuyen_ThemMoi(HDVC_ID, XeVC_ID);
                frm.ShowDialog();
                if (frm._IDHD > 0)
                {
                    try
                    {
                        LoadHopDongVanChuyen();
                        GridEXFilterCondition condi = new GridEXFilterCondition(gdVHopDongVanChuyen.Tables[0].Columns["HopDongVanChuyenID"], ConditionOperator.Equal, frm._IDHD);
                        gdVHopDongVanChuyen.Find(condi, 0, 1);
                        MessageBox.Show("Đã sửa HĐVC", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch { }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn hợp đồng vận chuyển để sửa", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }

      
     
        private void cmd2Excel_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.FileName = "Danhsach_Hopdongvanchuyen_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = gdVHopDongVanChuyen;
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
            long HDVC_ID = -1;
            long XeVC_ID = -1;
            try
            {
                HDVC_ID = long.Parse(this.gdVHopDongVanChuyen.GetValue("HopDongVanChuyenID").ToString());
                XeVC_ID = long.Parse(this.gdVHopDongVanChuyen.GetValue("XeVanChuyenID").ToString());
            }
            catch { }
            if((HDVC_ID>0)&&(XeVC_ID>0))
            {
                MDForms.VanChuyen.frm_ChuyenVu_HDVC frm = new MDForms.VanChuyen.frm_ChuyenVu_HDVC(HDVC_ID, XeVC_ID);
                frm.ShowDialog();
                if (frm.OK > 0)
                {
                    LoadHopDongVanChuyen();
                    GridEXFilterCondition condi = new GridEXFilterCondition(gdVHopDongVanChuyen.Tables[0].Columns["HopDongVanChuyenID"], ConditionOperator.Equal, HDVC_ID);
                    gdVHopDongVanChuyen.Find(condi, 0, 1);
                    MessageBox.Show("Đã chuyển HĐVC sang vụ mới", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void gdVHopDongVanChuyen_SelectionChanged(object sender, EventArgs e)
        {
            long DaCV = -1;
            try
            {
                DaCV = long.Parse(this.gdVHopDongVanChuyen.GetValue("DaChuyenVu").ToString());
            }
            catch { }
            if (DaCV > 0)
            {
                cmdChuyenVu.Enabled = false;
            }
            else
            {
                cmdChuyenVu.Enabled = true;
            }
        }

    }
}