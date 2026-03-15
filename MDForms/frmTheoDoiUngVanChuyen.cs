using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms
{
    public partial class frmTheoDoiUngVanChuyen : Form
    {
        static frmTheoDoiUngVanChuyen _thefrmTheoDoiUngVanChuyen;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmTheoDoiUngVanChuyen OneInstanceFrm
        {
            get
            {
                if (null == _thefrmTheoDoiUngVanChuyen || _thefrmTheoDoiUngVanChuyen.IsDisposed)
                {
                    _thefrmTheoDoiUngVanChuyen = new frmTheoDoiUngVanChuyen();
                }

                return _thefrmTheoDoiUngVanChuyen;
            }
        }
        public frmTheoDoiUngVanChuyen()
        {
            InitializeComponent();
            Load_CB_LoaiVatTu();
            loadHDVC();
        }

        private void frmTheoDoiUngVanChuyen_Load(object sender, EventArgs e)
        {
            dtDenNgay.Value = DateTime.Now;
            dtDenNgay_TongHopVanChuyen.Value = DateTime.Now;
            dtTuNgay.Value = dtDenNgay.Value.AddDays(-7);
            dtTuNgay_TongHopVanChuyen.Value = dtDenNgay_TongHopVanChuyen.Value.AddDays(-7);
            lblTitleTHVC.Text = lblTitleTHVC.Text + MDSolutionApp.VuTrongTen;
            cboVatTu.SelectedIndex = 0;
        }
        private void LoadDuLieuVanChuyen()
        {
            string sql = "sp_RP_TongHopUngVanChuyen '" + dtTuNgay_TongHopVanChuyen.Value.ToString("yyyy-MM-dd ") + "00:00:00','" + dtDenNgay_TongHopVanChuyen.Value.ToString("yyyy-MM-dd") + " 23:59:59'," + MDSolutionApp.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdTongHopVC.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                gdTongHopVC.DataSource = null;
            }
        }

        private void LoadDuLieuVatTu(long IDVatTu)
        {
            string sql = "";
            string sqlLoaiVT = "";
            if (IDVatTu >= 0)
            {
                sqlLoaiVT = " And tbl_UngVatTuVanChuyen.VatTuID=" + IDVatTu.ToString();
            }
            sql = "SELECT  dbo.tbl_VatTuVanChuyen.Ten, dbo.tbl_UngVatTuVanChuyen.SoChungTu, dbo.tbl_HopDongVanChuyen.MaHopDong," +
                          " dbo.tbl_HopDongVanChuyen.TenChuHopDong, dbo.tbl_XeVanChuyen.TenLaiXe,dbo.tbl_XeVanChuyen.LoaiXe,dbo.tbl_XeVanChuyen.TrongTai," +
                          "dbo.tbl_XeVanChuyen.SoXe, dbo.tbl_UngVatTuVanChuyen.NgayUng, dbo.tbl_UngVatTuVanChuyen.SoTien,NguoiNhap.HoTen AS NguoiNhap,NguoiSua.HoTen AS NguoiSua,tbl_UngVatTuVanChuyen.DateAdd AS NgayNhap,tbl_UngVatTuVanChuyen.DataModify AS NgaySua,dbo.tbl_UngVatTuVanChuyen.ID,dbo.tbl_UngVatTuVanChuyen.GhiChu  " +
                  "FROM         dbo.tbl_UngVatTuVanChuyen INNER JOIN dbo.tbl_HopDongVanChuyen " +
                                 " ON dbo.tbl_UngVatTuVanChuyen.HopDongVanChuyenID = dbo.tbl_HopDongVanChuyen.ID " +
                                 " INNER JOIN dbo.tbl_VatTuVanChuyen ON dbo.tbl_UngVatTuVanChuyen.VatTuID = dbo.tbl_VatTuVanChuyen.ID " +
                                 " INNER JOIN dbo.tbl_XeVanChuyen ON dbo.tbl_UngVatTuVanChuyen.XeID = dbo.tbl_XeVanChuyen.ID INNER JOIN sys_User AS NguoiNhap ON NguoiNhap.ID=tbl_UngVatTuVanChuyen.CreatedBy " +
                                 " LEFT OUTER JOIN sys_User AS NguoiSua ON NguoiSua.ID=tbl_UngVatTuVanChuyen.ModifyBy " +
                "WHERE ISNULL(tbl_UngVatTuVanChuyen.Xoa,0)<=0 AND tbl_UngVatTuVanChuyen.VuTrongID = " + MDSolutionApp.VuTrongID.ToString() + " AND  NgayUng>=  '" + dtTuNgay.Value.ToString("yyyy-MM-dd") + "' And NgayUng<='" + dtDenNgay.Value.ToString("yyyy-MM-dd") + " 23:59:59' ";//   Order by cast(SoChungTu as int)";
            sql = sql + sqlLoaiVT + "  Order by CAST(SoChungTu As int)";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdDSUngVC.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                gdDSUngVC.DataSource = null;
            }
        }
        private void Load_CB_LoaiVatTu()
        {
            try
            {
                DataSet dsvt = new DataSet();
                dsvt = clsVatTuVanChuyen.GetListbyWhere("", "", "", null, null);
                DataRow dr = dsvt.Tables[0].NewRow();
                dr["ID"] = -1;
                dr["Ten"] = "---Tất cả các loại vật tư---";
                dsvt.Tables[0].Rows.InsertAt(dr, 0);
                cboVatTu.DataSource = dsvt.Tables[0];
                cboVatTu.DisplayMember = "Ten";
                cboVatTu.ValueMember = "ID";
            }
            catch { }

        }

        private void cmd2XeExcel_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.FileName = "UngVT_VanChuyen_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = gdDSUngVC;
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

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (this.gdDSUngVC.RecordCount > 0)
            {
                frmShowRP2 frm = new frmShowRP2();
                MDReport.VanChuyen.rpt_UngTheoVatTu rp = new MDReport.VanChuyen.rpt_UngTheoVatTu();
                System.Data.DataTable dt = (System.Data.DataTable)gdDSUngVC.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);
                rp.SetParameterValue("TN", dtTuNgay.Value.ToString("dd/MM/yyyy"));
                rp.SetParameterValue("DN", dtDenNgay.Value.ToString("dd/MM/yyyy"));
                rp.SetParameterValue("TenVatTu", cboVatTu.Text.Replace("-", ""));
                frm.RP = rp;
                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.RPtitle = "Chi tiết ứng vận chuyển mía ";
                frm.Show();
            }
            else
            {
                MessageBox.Show("Báo cáo không có dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }
        }

        private void cboVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            long IDVT = -1;
            try
            {
                IDVT = long.Parse(cboVatTu.SelectedValue.ToString());
            }
            catch { }
            LoadDuLieuVatTu(IDVT);
        }

        private void cmdExit_TongHopVanChuyen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdXuatExcel_TongHopVanChuyen_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.FileName = "TongHop_VanChuyen_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = gdTongHopVC;
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

        private void cmdIn_TongHopVanChuyen_Click(object sender, EventArgs e)
        {
            if (this.gdTongHopVC.RecordCount > 0)
            {
                frmShowRP2 frm = new frmShowRP2();
                MDReport.VanChuyen.rpt_TongHop_Ung_VanChuyen rp = new MDReport.VanChuyen.rpt_TongHop_Ung_VanChuyen();
                System.Data.DataTable dt = (System.Data.DataTable)gdTongHopVC.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);
                rp.SetParameterValue("TN", dtTuNgay.Value.ToString("dd/MM/yyyy"));
                rp.SetParameterValue("DN", dtDenNgay.Value.ToString("dd/MM/yyyy"));
                frm.RP = rp;
                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.RPtitle = "Chi tiết ứng vận chuyển mía ";
                frm.Show();
            }
            else
            {
                MessageBox.Show("Báo cáo không có dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            long IDVT = -1;
            try
            {
                IDVT = long.Parse(cboVatTu.SelectedValue.ToString());
            }
            catch { }
            LoadDuLieuVatTu(IDVT);
        }

        private void cmdFind_TongHopVanChuyen_Click(object sender, EventArgs e)
        {
            LoadDuLieuVanChuyen();
        }

        private void tabUng_VC_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (e.Page.Index == 0)
            {
                long IDVT = -1;
                try
                {
                    IDVT = long.Parse(cboVatTu.SelectedValue.ToString());
                }
                catch { }
                LoadDuLieuVatTu(IDVT);
            }
            if (e.Page.Index == 1)
            {
                LoadDuLieuVanChuyen();
            }
        }
        // xử lý phần nhập hỗ trợ vận chuyển
        private void GHDVC_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            if (GHDVC.GetRows().Length > 0)
            {
                try
                {
                    int IDHopDong = int.Parse(GHDVC.GetValue("ID").ToString());
                    if (IDHopDong > 0)
                    {
                        frm_NhapHoTroVC frm = new frm_NhapHoTroVC(IDHopDong, true);
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Bạn chư chọn hợp đồng");
                    }
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn hợp đồng hoàn ứng.");
            }
        }
        void loadHDVC()
        {
            string strWhere = "(ID in(select HopDongVanChuyenID from tbl_nhapmia where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + "))";
            GHDVC.SetDataBinding(clsHopDongVanChuyen.GetListbyWhere2("", strWhere, "", null, null).Tables[0], "");
        }
        private void DSTienHoTro(string strID)
        {
            try
            {
                DataSet ds;
                string strSQL = "";
                strSQL = "SELECT tbl_HoTroVanChuyen.*, dbo.sys_User.HoTen AS NguoiNhap FROM     dbo.tbl_HoTroVanChuyen INNER JOIN dbo.sys_User ON dbo.tbl_HoTroVanChuyen.CreatedBy = dbo.sys_User.ID WHERE   HopDongVanChuyenID = " + strID + " AND VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
                ds = DBModule.ExecuteQuery(strSQL, null, null);
                {
                    int i = ds.Tables[0].Rows.Count;
                    if (i > 0)
                    {
                        this.gdvTienHoTro.SetDataBinding(ds.Tables[0], "");
                    }
                    else {
                        this.gdvTienHoTro.SetDataBinding(null, "");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi load danh sách tiền hỗ trợ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GHDVC_Click(object sender, EventArgs e)
        {
            if (GHDVC.GetRows().Length > 0)
            {   try
                {
                    DSTienHoTro(GHDVC.GetValue("ID").ToString());
                }
                catch {
                    this.gdvTienHoTro.SetDataBinding(null, "");
                }
            }            
            else {
                this.gdvTienHoTro.SetDataBinding(null, "");
            }
        }

        private void gdvTienHoTro_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            if (MDSolutionApp.User.ID == 1 || MDSolutionApp.User.ID == 83067)
            {
                int HoTroVCID = int.Parse(gdvTienHoTro.GetValue("ID").ToString());
                try
                {
                    clsHoTroVanChuyen objXoa = new clsHoTroVanChuyen(HoTroVCID);
                    objXoa.Load(null, null);
                    objXoa.Delete(null, null);
                    MessageBox.Show("Xóa thành công");
                    this.Refresh();
                }
                catch
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
            else
            {
                MessageBox.Show("Không có quyền xóa");
            }
        }

        private void GHDVC_SelectionChanged(object sender, EventArgs e)
        {
            if (GHDVC.GetRows().Length > 0)
            {
                try
                {
                    DSTienHoTro(GHDVC.GetValue("ID").ToString());
                }
                catch {
                    this.gdvTienHoTro.SetDataBinding(null, "");
                }
            }
            else {
                this.gdvTienHoTro.SetDataBinding(null, "");
            }
        }

        private void gdDSUngVC_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {

            if (gdDSUngVC.GetRows().Length > 0)
            {
                try
                {
                    int IDUngVTVC = int.Parse(gdDSUngVC.GetValue("ID").ToString());
                    if (IDUngVTVC > 0)
                    {                      
                        frmTheoDoiUngVanChuyen_Confirm_GhiChu frm = new frmTheoDoiUngVanChuyen_Confirm_GhiChu(IDUngVTVC,true);
                        frm.ShowDialog();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            long IDVT = -1;
                            try
                            {
                                IDVT = long.Parse(cboVatTu.SelectedValue.ToString());
                            }
                            catch { }
                            LoadDuLieuVatTu(IDVT);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn chư chọn mã");
                    }
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn mã ứng.");
            }
        }
    }
}
