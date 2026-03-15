using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using SQL = System.Data;
using Janus.Windows.GridEX;

namespace MDSolution.MDForms
{
    public partial class frmTheoDoiNhapMia : Form
    {
        static frmTheoDoiNhapMia _theformQuanLyMiaNhap;
        private string IDselected = "";
        private decimal TongTien = 0, ConLaiThanhToan = 0;
        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmTheoDoiNhapMia OneInstanceFrm
        {
            get
            {
                if (null == _theformQuanLyMiaNhap || _theformQuanLyMiaNhap.IsDisposed)
                {
                    _theformQuanLyMiaNhap = new frmTheoDoiNhapMia();
                }

                return _theformQuanLyMiaNhap;
            }
        }
        private NodeDonVi nDonVi = new NodeDonVi();
        public frmTheoDoiNhapMia()
        {
            InitializeComponent();
            CommonClass.loadTreeDonVi(treeDonVi);
            foreach (TreeNode n in treeDonVi.Nodes)
            {
                n.Toggle();
            }
            nDonVi = (NodeDonVi)treeDonVi.Nodes[0].Tag;
        }



        private void frmQuanLyMiaNhap_Load(object sender, EventArgs e)
        {
            if (MDSolutionApp.User.ID != 1)
            {
                cmdIn.Enabled = false;
            }
            if (MDSolutionApp.User.ID == 414531)
            {
                cmdIn.Enabled = true;
            }
            if (MDSolutionApp.User.ID == 1)
            {
                cmdSuaPhieuCan.Enabled = true;
                cmdCapNhaGiaCuoc.Enabled = true;

                cmdCapNhaGiaCuoc.Visible = true;
                cmdSuaPhieuCan.Visible = true;
            }
            //if (MDSolutionApp.User.ID == 1 || MDSolutionApp.User.ID == 83067 || MDSolutionApp.User.ID == 414531)
            //{
            //    btn_mau01.Visible = true;
            //    btn_mau06.Visible = true;
            //}
            DataSet ds = DBModule.ExecuteQuery("select YEAR(GETDATE()) as Nam, MONTH(GETDATE()) as Thang, DAY(GETDATE()) as Ngay", null, null);
            int Nam = int.Parse(ds.Tables[0].Rows[0]["Nam"].ToString());
            int Thang = int.Parse(ds.Tables[0].Rows[0]["Thang"].ToString());
            int Ngay = int.Parse(ds.Tables[0].Rows[0]["Ngay"].ToString());
            dtDenNgay.Value = new DateTime(Nam, Thang, Ngay, 23, 59, 59);
            dtTuNgay.Value = new DateTime(Nam, Thang, Ngay, 0, 0, 0);
            //dtTuNgay.Value = dtDenNgay.Value.AddDays(-1);
            dtTuNgayXe.Value = new DateTime(Nam, Thang, Ngay, 0, 0, 0);
            dtDenNgayXe.Value = new DateTime(Nam, Thang, Ngay, 23, 59, 59);
            dtTuNgayCBNV.Value = dtTuNgay.Value;
            dtDenNgayCBNV.Value = dtDenNgay.Value;
            lblTitle.Text = lblTitle.Text + " " + MDSolutionApp.VuTrongTen;
            LoadDS();
        }
        void LoadDS()
        {
            if (nDonVi.Type == DonviType.Root)
            {
                LoadDS_NhapMia_ToanVung();
            }
            if (nDonVi.Type == DonviType.Tram)
            {
                LoadDS_NhapMia_ToanVung();
            }
            if (nDonVi.Type == DonviType.Xa)
            {
                LoadDS_NhapMia_Xa();
            }
            if (nDonVi.Type == DonviType.Thon)
            {
                LoadDS_NhapMia_Thon();
            }
        }
        void LoadDS_NhapMia_Thon()
        {
            string Tu = dtTuNgay.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string Den = dtDenNgay.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "Select * from V_VanChuyenMia_Can Where NgayRa>= '" + Tu + "' And NgayRa<='" + Den + "' And VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
            sql += " And ThonID=" + nDonVi.DonViID.ToString() + " Order by NgayRa DESC";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdMia.SetDataBinding(ds.Tables[0], "");
            }
            else
            {
                this.gdMia.DataSource = null;
            }
        }
        void LoadDS_NhapMia_Xa()
        {
            string Tu = dtTuNgay.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string Den = dtDenNgay.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "Select * from V_VanChuyenMia_Can Where NgayRa>= '" + Tu + "' And NgayRa<='" + Den + "' And VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
            sql += " And XaID=" + nDonVi.DonViID.ToString() + " Order by NgayRa DESC";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdMia.SetDataBinding(ds.Tables[0], "");
            }
            else
            {
                this.gdMia.DataSource = null;
            }
        }
        void LoadDS_NhapMia_ToanVung()
        {
            string Tu = dtTuNgay.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string Den = dtDenNgay.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "Select * from V_VanChuyenMia_Can Where NgayRa>= '" + Tu + "' And NgayRa<='" + Den + "' And VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
            sql += " Order by NgayRa DESC";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdMia.SetDataBinding(ds.Tables[0], "");
            }
            else
            {
                this.gdMia.DataSource = null;
            }
        }
        private void cmdIn_Click(object sender, EventArgs e)
        {
            long IDMia = 0;
            long TienMia = 0;
            long HopDongID = 0;
            long HopDongMuaTaiBanCanID = 0;
            long TienMiaMuaTaiBanCan = 0;
            try
            {
                IDMia = long.Parse(this.gdMia.GetValue("ID").ToString());
                TienMia = long.Parse(this.gdMia.GetValue("TienMia").ToString());
                TienMiaMuaTaiBanCan = long.Parse(this.gdMia.GetValue("TienMiaMuaTaiBanCan").ToString());  
            }
            catch
            {
                IDMia = 0;
            }
            clsNhapMia objNM = new clsNhapMia(IDMia);
            objNM.Load(null, null);
            HopDongID = objNM.HopDongID;
           


            clsHopDong objHopDong = new clsHopDong(HopDongID);
            objHopDong.Load(null, null);
            HopDongMuaTaiBanCanID = objHopDong.MuaTaiBanCan;

            if (IDMia > 0)
            {
                if (objHopDong.MuaTaiBanCan == 1)
                {
                    try
                    {
                        frmShowRP2 frm = new frmShowRP2();
                        MDReport.rp_PhieuNhapMia_TaiBanCan rp = new MDSolution.MDReport.rp_PhieuNhapMia_TaiBanCan();
                        DataSet ds = DBModule.ExecuteQuery("Select * from V_VanChuyenMia_Can Where ID=" + IDMia.ToString(), null, null);
                        rp.SetDataSource(ds.Tables[0]);
                        rp.SetParameterValue("TenNguoi", MDSolutionApp.User.HoTen);
                        rp.SetParameterValue("TienBangChu", frmShowRP3.DocSo(TienMiaMuaTaiBanCan));
                        rp.SetParameterValue("InLai", "(In lại)");
                        rp.SetParameterValue("NguoiIn", "NGƯỜI IN");
                        // rp.PrintToPrinter(1, false, 0, 1);
                        frm.RP = rp;
                        frm.Show();
                    }
                    catch
                    {
                        MessageBox.Show("Kiểm tra lại kết nối với máy in", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    try
                    {
                        frmShowRP2 frm = new frmShowRP2();
                        MDReport.rp_PhieuNhapMia rp = new MDSolution.MDReport.rp_PhieuNhapMia();
                        DataSet ds = DBModule.ExecuteQuery("Select * from V_VanChuyenMia_Can Where ID=" + IDMia.ToString(), null, null);
                        rp.SetDataSource(ds.Tables[0]);
                        rp.SetParameterValue("TenNguoi", MDSolutionApp.User.HoTen);
                        rp.SetParameterValue("TienBangChu", frmShowRP3.DocSo(TienMia));
                        rp.SetParameterValue("InLai", "(In lại)");
                        rp.SetParameterValue("NguoiIn", "NGƯỜI IN");
                        frm.RP = rp;
                        frm.Show();
                    }
                    catch
                    {
                        MessageBox.Show("Kiểm tra kết nối tới máy in", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn được phiếu cân để in", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool Chek_DaThanhToan(long IDNhapMia)
        {
            string sql = "Select DaThanhToan From tbl_NhapMia Where ID=" + IDNhapMia.ToString();
            sql = DBModule.ExecuteQueryForOneResult(sql, null, null);

            if (string.IsNullOrEmpty(sql) || sql == "0")
                return true;
            else
                return false;
        }


        private void treeDonVi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (treeDonVi.SelectedNode != null)
            {
                nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                LoadDS();
            }

        }

        private void tabNM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabNM.SelectedIndex == 1)
            {
                LoadMiaVung();
            }
            if (tabNM.SelectedIndex == 2)
            {
                LoadMiaVungBan();
            }
            if (tabNM.SelectedIndex == 4)
            {
                LoadDSXe();
            }
            if (tabNM.SelectedIndex == 3)
            {
                Load_SL_CBNV();
            }
            if (tabNM.SelectedIndex == 0)
            {
                LoadDS();
            }
        }
        private void LoadMiaVung()
        {
            string sql = "sp_RP_TongHopSanLuongMiaTheoXa  " + MDSolutionApp.VuTrongID.ToString() + ",'" + dtTu_XemXa.Value.ToString("yyyy-MM-dd") + "','" + dtDen_XemXa.Value.ToString("yyyy-MM-dd") + "'";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdMiaVung.SetDataBinding(ds.Tables[0], "");
                gdMiaVung.RootTable.Columns.GetColumnInPosition(4).Caption = "Mía thuần ngày " + dtDen_XemXa.Value.ToString("dd-MM-yyyy");
                gdMiaVung.RootTable.Columns.GetColumnInPosition(5).Caption = "Tạp chất ngày " + dtDen_XemXa.Value.ToString("dd-MM-yyyy");
                gdMiaVung.RootTable.Columns.GetColumnInPosition(6).Caption = "Mía sạch ngày " + dtDen_XemXa.Value.ToString("dd-MM-yyyy");
                gdMiaVung.RootTable.Columns.GetColumnInPosition(7).Caption = "LK M.Thuần cuối ngày " + dtDen_XemXa.Value.AddDays(-1).ToString("dd-MM-yyyy");
                gdMiaVung.RootTable.Columns.GetColumnInPosition(8).Caption = "LK M.Thuần cuối ngày " + dtDen_XemXa.Value.ToString("dd-MM-yyyy");
                gdMiaVung.RootTable.Columns.GetColumnInPosition(10).Caption = "Mía sạch cuối ngày " + dtDen_XemXa.Value.AddDays(-1).ToString("dd-MM-yyyy");
                gdMiaVung.RootTable.Columns.GetColumnInPosition(11).Caption = "Mía sạch cuối ngày " + dtDen_XemXa.Value.ToString("dd-MM-yyyy");
            }
            else
            {
                gdMiaVung.DataSource = null;
            }
            lblLKTruocNgay.Text = "Lũy kế cuối ngày " + dtDen_XemXa.Value.AddDays(-1).ToString("dd-MM-yyyy");
            lblTrongNgay.Text = "Tổng cộng ngày " + dtDen_XemXa.Value.ToString("dd-MM-yyyy");
            lblToanVu.Text = "Lũy kế cuối ngày " + dtDen_XemXa.Value.ToString("dd-MM-yyyy");
            lblSoXe.Text = "Số xe nhập ngày " + dtDen_XemXa.Value.ToString("dd-MM-yyyy");
            TinhSLLK();
        }
        private void TinhSLLK()
        {
            DataSet ds = null;
            string NgayGio = DBModule.ExecuteQueryForOneResult("select Convert(char(19),GETDATE(),121) as Ngay", null, null);
            DateTime NgayGioHT = DateTime.Parse(NgayGio);//Ngày giờ trên máy chủ
            DateTime NgayHH = NgayGioHT.Date;//Ngày trên máy chủ
            int GioHH = NgayGioHT.Hour;//Giờ trên máy chủ
            DateTime NgayXem = dtDen_XemXa.Value.Date;//Ngày xem chọn trên form
            DateTime Tu = NgayGioHT;//Khởi tạo
            DateTime Den = NgayGioHT;//Khởi tạo
            if (NgayXem == NgayHH)
            {
                if (GioHH >= 7)
                {
                    Tu = NgayXem.AddHours(7);
                }
                else
                {
                    Tu = NgayXem.AddHours(-17);
                }
                Den = NgayGioHT;
            }
            if (NgayXem < NgayHH)
            {
                Tu = NgayXem.AddHours(-17);
                Den = NgayXem.AddHours(7);
            }
            if (NgayXem > NgayHH)
            {
                Tu = NgayXem.AddHours(7);
                Den = Tu.AddDays(1);
            }
            decimal TLMSTruoc = 0;
            decimal TLMSNgay = 0;
            long SLPhieuNgay = 0;
            decimal TLMSVu = 0;

            string sql = "Select SUM(TongTrongLuong-TrongLuongXe-TrongLuongTapVat) as TLMSTruoc From tbl_NhapMia " +
            " Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " And TrongLuongTapVat>0 And NgayRa <" + DBModule.RefineDatetime(Tu);
            try
            {
                TLMSTruoc = Math.Round(decimal.Parse(DBModule.ExecuteQueryForOneResult(sql, null, null)) / 1000, 0);
            }
            catch
            {
                TLMSTruoc = 0;
            }

            sql = "Select COUNT(SoPhieuNhap) as SLPNgay, SUM(TongTrongLuong-TrongLuongXe-TrongLuongTapVat) as TLMS From tbl_NhapMia " +
            " Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " And TrongLuongTapVat>0 And NgayRa >=" + DBModule.RefineDatetime(Tu) + " And NgayRa<" + DBModule.RefineDatetime(Den);
            ds = DBModule.ExecuteQuery(sql, null, null);

            try
            {
                TLMSNgay = Math.Round(decimal.Parse(ds.Tables[0].Rows[0]["TLMS"].ToString()) / 1000, 0);
            }
            catch
            {
                TLMSNgay = 0;
            }
            try
            {
                SLPhieuNgay = long.Parse(ds.Tables[0].Rows[0]["SLPNgay"].ToString());
            }
            catch
            {
                SLPhieuNgay = 0;
            }
            sql = "Select SUM(TongTrongLuong-TrongLuongXe-TrongLuongTapVat) as TLMSVu From tbl_NhapMia " +
                " Where  VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " And TrongLuongTapVat>0 And NgayRa <=" + DBModule.RefineDatetime(Den);
            try
            {
                TLMSVu = Math.Round(decimal.Parse(DBModule.ExecuteQueryForOneResult(sql, null, null)) / 1000, 0);
            }
            catch
            {
                TLMSVu = 0;
            }
            txtLuyKeMSTruoc.Text = TLMSTruoc.ToString("### ### ##0");
            txtMSTrongNgay.Text = TLMSNgay.ToString("### ### ##0");
            txtLKMSSau.Text = TLMSVu.ToString("### ### ##0");
            txtSLXe.Text = SLPhieuNgay.ToString("### ### ##0");
            txtLKBanTruoc.Text = TLMSTruoc.ToString("### ### ##0");
            txtTongCongBan.Text = TLMSNgay.ToString("### ### ##0");
            txtLKBanSau.Text = TLMSVu.ToString("### ### ##0");
            txtSoXeBan.Text = SLPhieuNgay.ToString("### ### ##0");
        }
        private void dtNgayXem_ValueChanged(object sender, EventArgs e)
        {

            DateTime NgayHeThong = DateTime.Parse(CommonClass.getServerTime());
            if (dtDen_XemXa.Value > NgayHeThong)
            {
                dtDen_XemXa.Value = NgayHeThong;
            }
            LoadMiaVung();
        }

        private void cmd2Excel_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = gdMiaVung;
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

        private void cmd2Exel_Click(object sender, EventArgs e)
        {
            try
            {

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = gdMia;
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
        private void LoadDSXe()
        {
            string Tu = dtTuNgayXe.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string Den = dtDenNgayXe.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "Select * from V_VanChuyenMia_Can Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " And NgayRa>='" + Tu + "' And NgayRa<'" + Den + "' And TrongLuongXe>0 Order By SoPhieuNhap DESC";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdXeVC.SetDataBinding(ds.Tables[0], "");
            }
            else
            {
                gdXeVC.DataSource = null;
            }

        }

        private void cmd2XeExcel_Click(object sender, EventArgs e)
        {
            try
            {

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = gdXeVC;
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

        private void cmdXemDL_Click(object sender, EventArgs e)
        {
            LoadDSXe();
        }

        private void Load_SL_CBNV()
        {
            string sql = "sp_RP_TongHopSanLuongMiaTheoCBNV   " + MDSolutionApp.VuTrongID.ToString() + ",'" + dtTuNgayCBNV.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + dtDenNgayCBNV.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdSLCBNV.SetDataBinding(ds.Tables[0], "");

            }
            else
            {
                gdSLCBNV.DataSource = null;
            }
        }

        private void cmdLoadDLCBNV_Click(object sender, EventArgs e)
        {
            Load_SL_CBNV();
        }

        private void cmd2ExcelCBNV_Click(object sender, EventArgs e)
        {
            try
            {

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = gdSLCBNV;
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
        private void LoadMiaVungBan()
        {
            string sql = "sp_RP_TongHopSanLuongMiaTheoBan  " + MDSolutionApp.VuTrongID.ToString() + ",'" + dtTu_XemBan.Value.ToString("yyyy-MM-dd") + "','" + dtDen_XemBan.Value.ToString("yyyy-MM-dd") + "'";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gdBan.SetDataBinding(ds.Tables[0], "");
                gdBan.RootTable.Columns.GetColumnInPosition(4).Caption = "Mía thuần ngày " + dtDen_XemBan.Value.ToString("dd-MM-yyyy");
                gdBan.RootTable.Columns.GetColumnInPosition(5).Caption = "Tạp chất ngày " + dtDen_XemBan.Value.ToString("dd-MM-yyyy");
                gdBan.RootTable.Columns.GetColumnInPosition(6).Caption = "Mía sạch ngày " + dtDen_XemBan.Value.ToString("dd-MM-yyyy");
                gdBan.RootTable.Columns.GetColumnInPosition(7).Caption = "LK M.Thuần cuối ngày " + dtDen_XemBan.Value.AddDays(-1).ToString("dd-MM-yyyy");
                gdBan.RootTable.Columns.GetColumnInPosition(8).Caption = "LK M.Thuần cuối ngày " + dtDen_XemBan.Value.ToString("dd-MM-yyyy");
                gdBan.RootTable.Columns.GetColumnInPosition(10).Caption = "Mía sạch cuối ngày " + dtDen_XemBan.Value.AddDays(-1).ToString("dd-MM-yyyy");
                gdBan.RootTable.Columns.GetColumnInPosition(11).Caption = "Mía sạch cuối ngày " + dtDen_XemBan.Value.ToString("dd-MM-yyyy");
            }
            else
            {
                gdBan.DataSource = null;
            }
            lblLKBanCuoiNgayTruoc.Text = "Lũy kế cuối ngày " + dtDen_XemBan.Value.AddDays(-1).ToString("dd-MM-yyyy");
            lblTongCongBanNgay.Text = "Tổng cộng ngày " + dtDen_XemBan.Value.ToString("dd-MM-yyyy");
            lblLKBanCuoiNgaySau.Text = "Lũy kế cuối ngày " + dtDen_XemBan.Value.ToString("dd-MM-yyyy");
            lblSoXeBan.Text = "Số xe nhập ngày " + dtDen_XemBan.Value.ToString("dd-MM-yyyy");
            TinhSLLK();
        }

        private void cmdBan2Excel_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = gdBan;
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

        private void cmdSuaPhieuCan_Click(object sender, EventArgs e)
        {
            long DaTT = 0;
            long DaTTVC = 0;
            long IDMia = 0;
            try
            {
                DaTT = long.Parse(this.gdMia.GetValue("DaThanhToan").ToString());
            }
            catch { }
            try
            {
                DaTTVC = long.Parse(this.gdMia.GetValue("DaThanhToanVC").ToString());
            }
            catch { }
            try
            {
                IDMia = long.Parse(this.gdMia.GetValue("ID").ToString());
            }
            catch { }
            if (IDMia > 0)
            {
                if ((DaTT > 0) && (DaTTVC > 0))
                {
                    MessageBox.Show("Phiếu cân đã được thanh toán tiền mía và cước vận chuyển!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if ((MDSolutionApp.User.ID == 1) || (MDSolutionApp.User.RolesID == 1))
                    {
                        frmSuaPhieuCanMia frm = new frmSuaPhieuCanMia(IDMia, DaTT, DaTTVC);
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa được gán quyền sửa phiếu cân!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn được phiếu cân để sửa!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btn_XemXa_Click(object sender, EventArgs e)
        {
            LoadMiaVung();
        }

        private void btnXemBan_Click(object sender, EventArgs e)
        {
            LoadMiaVungBan();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdCapNhaGiaCuoc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chương trình sẽ cập nhật đơn giá vận chuyển cho tất cả các bãi tập kết\n Ở đợt gần nhất", "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            string sqlngay = @"select top 1 DonGia from  tbl_BaiTapKet_GiaCuoc where DotApDung=( select MAX(DotApDung) from tbl_BaiTapKet_GiaCuoc where VuTrongID=" + MDSolutionApp.VuTrongID + ") and " + MDSolutionApp.VuTrongID;
            string sqlNhapMia_Dot = @"select * from tbl_NhapMia where NgayGioCanRa>= (select top 1 NgayApDung from  tbl_BaiTapKet_GiaCuoc where DotApDung=( select MAX(DotApDung) from tbl_BaiTapKet_GiaCuoc where tbl_BaiTapKet_GiaCuoc.VuTrongID=" + MDSolutionApp.VuTrongID + ")  and tbl_BaiTapKet_GiaCuoc.VuTrongID=" + MDSolutionApp.VuTrongID + ") AND  tbl_NhapMia.VuTrongID= " + MDSolutionApp.VuTrongID + "AND TrongLuongTapVat>0";
            try
            {
                DataSet dsVC = DBModule.ExecuteQuery(sqlNhapMia_Dot, null, null);
                if (dsVC.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drVC in dsVC.Tables[0].Rows)
                    {
                        long HopDongID = long.Parse(drVC["HopDongID"].ToString());
                        long ID = long.Parse(drVC["ID"].ToString());
                        long BaiTapKetID = long.Parse(drVC["BaiTapKetID"].ToString());
                        long GiaVanChuyen = long.Parse(drVC["DonGiaVanChuyen"].ToString());
                        long TienVanChuyen = long.Parse(drVC["TienVanChuyen"].ToString());
                        //clsNhapMia oNM = new clsNhapMia(ID);
                        //oNM.Load(null, null);
                        string sqlGia_VanChuyen = @"select top 1 DonGia from  tbl_BaiTapKet_GiaCuoc where DotApDung=( select MAX(DotApDung) from tbl_BaiTapKet_GiaCuoc where VuTrongID=" + MDSolutionApp.VuTrongID + ") AND BaiTapKetID= " + BaiTapKetID + " order by ID DESC";
                        string sql_MuaTaiBanCan = @"select top 1 * from tbl_hopdong where " + HopDongID + " not in ( Select ID from tbl_HopDong where MuaTaiBanCan=1)";
                        try
                        {
                            int DonGia = int.Parse(DBModule.ExecuteQueryForOneResult(sqlGia_VanChuyen, null, null));                                                       
                            if (DonGia != GiaVanChuyen)
                            {
                                string sqlUpdate_VanChuyen = @" Update tbl_NhapMia Set DonGiaVanChuyen=" + DonGia + ",TienVanChuyen = " + (long.Parse(drVC["TongTrongLuong"].ToString()) - long.Parse(drVC["TrongLuongXe"].ToString()) - long.Parse(drVC["TrongLuongTapVat"].ToString())) * DonGia / 1000 + " Where ID = " + ID;
                                DBModule.ExecuteNonQuery(sqlUpdate_VanChuyen, null, null);
                            }
                        }
                        catch { }
                    }
                }
                MessageBox.Show("Đã cập nhật thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra\nCập nhật không thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void btn_mau01_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT * FROM V_Mau_02_06 where 1=2 ";
            if (gdMia.GetCheckedRows().Length < 1)
            {
                MessageBox.Show("Bạn chưa chọn bản ghi.", "Thông báo");
                return;
            }
            decimal TongThanhToan = ConLaiThanhToan;
            sql += IDselected + " order by ID"; ;
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            string TongTienThanhToan;
            string TienBangChu;
            if (TongThanhToan < 0) TongThanhToan = 0;
            TongTienThanhToan = TongThanhToan.ToString("###,##0");
            string sTienChu = Utils.DocSo((Double.Parse(TongThanhToan.ToString("##0"))));
            sTienChu = sTienChu.Replace(" đồng", "") + " đồng";
            TienBangChu = sTienChu;
            string[] paramNames = new string[] { "TongTienThanhToan", "TienBangChu" };
            string[] paraValues = new string[] { TongTienThanhToan, TienBangChu };
            CommonClass.ShowReportWithDataSet("ThanhToan2016\\Mau01.rpt", "Bảng kê 01", paramNames, paraValues, ds);
        }

        private void btn_mau06_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT * FROM V_Mau_02_06 where 1=2 ";
            if (gdMia.GetCheckedRows().Length < 1)
            {
                MessageBox.Show("Bạn chưa chọn bản ghi.", "Thông báo");
                return;
            }
            decimal TongThanhToan = ConLaiThanhToan;
            sql += IDselected + " order by ID"; ;
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            string TongTien;
            string TienBangChu;
            if (TongThanhToan < 0) TongThanhToan = 0;
            TongTien = TongThanhToan.ToString("###,##0");
            string sTienChu = Utils.DocSo((Double.Parse(TongThanhToan.ToString("##0"))));
            sTienChu = sTienChu.Replace(" đồng", "") + " đồng";
            TienBangChu = sTienChu;
            string[] paramNames = new string[] { "TongTienThanhToan", "TienBangChu" };
            string[] paraValues = new string[] { TongTien, TienBangChu };
            CommonClass.ShowReportWithDataSet("ThanhToan2016\\Mau06.rpt", "Bảng kê 01", paramNames, paraValues, ds);
        }
        void CheckedRow()
        {
            IDselected = ""; TongTien = 0;
            foreach (GridEXRow jr in this.gdMia.GetCheckedRows())
            {
                IDselected += string.Format(" OR (ID={0} ) ", jr.Cells["ID"].Value);
                TongTien += (decimal)jr.Cells["TienMia"].Value + (decimal)jr.Cells["SoTienVC"].Value;
            }
            ConLaiThanhToan = TongTien;
            btn_mau01.Enabled = true;
            btn_mau06.Enabled = true;
        }

        private void gdMia_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
        {
            CheckedRow();
        }
    }
}