using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using System.IO;
using System.Xml.Xsl;
using System.Xml;
using MDSolution.MDReport;

namespace MDSolution.MDForms.HoTro
{

    public partial class frm_TruHoTro : Form
    {

        static frm_TruHoTro _frm_TruHoTro;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_TruHoTro OneInstanceFrm
        {
            get
            {
                if (null == _frm_TruHoTro || _frm_TruHoTro.IsDisposed)
                {
                    _frm_TruHoTro = new frm_TruHoTro();
                }

                return _frm_TruHoTro;
            }
        }

        public frm_TruHoTro()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //LoadNhapMia();
        }

        private long HopDongID = -1;
        private DateTime? NgayChotDot;
        private DateTime? NgayChotDotTD;
//        void LoadNhapMia()
//        {

//            //Tìm kiếm tất cả nhập mía của hđ đầu tư./
//            string sql = @"SELECT ID,DaThanhToan,PhanTramMiaChay,PhanTramMiaRep,TienMia, (TienMia/TrongLuongMiaSach) as DonGiaMia,TrongLuongMiaSach,SoPhieuCan
//                          FROM tbl_nhapmia where DaThanhToan is null or  DaThanhToan=0 and HopDongID={0} and NgayVanChuyen<={1} and VuTrongID={2}";

//            grvDSPhieuCan.SetDataBinding(DBModule.ExecuteQuery(string.Format(sql, HopDongID, NgayChotDot.Value.ToString("yyyy-MM-dd") + " 23:59:00", MDSolutionApp.VuTrongID), null, null), "");
//            grvDSPhieuCan.Refresh();

//        }
        void LoadDotTT()
        {

            //Tìm kiếm tất cả nhập mía của hđ đầu tư./
            string sql = @"SELECT ID,Ten
                          FROM tbl_DotThanhToan where VuTrongID={0} union (select -1,N'--(*)Tạo mới--')  order by ID desc";
            DataTable dt = DBModule.ExecuteQuery(string.Format(sql, MDSolutionApp.VuTrongID), null, null).Tables[0];

            cboDotTT.DataSource = dt;
            cboDotTT.ValueMember = "ID";
            cboDotTT.DisplayMember = "Ten";
            //LoadChonDotTT();
            //LoadDotTTTD();
            //grvDSPhieuCan.Refresh();

        }
//        void LoadDotTTTD()
//        {

//            //Tìm kiếm tất cả nhập mía của hđ đầu tư./
//            string sql = @"SELECT ID,Ten
//                          FROM tbl_DotThanhToan where VuTrongID={0} union (select -1,N'--(*)Tạo mới--')  order by ID desc";
//            DataTable dt = DBModule.ExecuteQuery(string.Format(sql, MDSolutionApp.VuTrongID), null, null).Tables[0];

//            cboDotTTTD.DataSource = dt;
//            cboDotTTTD.ValueMember = "ID";
//            cboDotTTTD.DisplayMember = "Ten";
//            sql = "select * from tbl_DotThanhToan where ID={0}";

//            try
//            {
//                DataSet ds = DBModule.ExecuteQuery(string.Format(sql, cboDotTTTD.SelectedValue), null, null);
//                if (ds.Tables[0].Rows.Count == 1)
//                {
//                    NgayChotDotTD = ((DateTime)ds.Tables[0].Rows[0]["NgayChotDot"]);
//                    lbNgayChot_TD.Text = NgayChotDotTD.Value.ToString("dd/MM/yyyy");
//                }
//            }
//            catch (Exception ex)
//            {

//                NgayChotDotTD = null;
//                lbNgayChot_TD.Text = "-";
//            }
//            //grvDSPhieuCan.Refresh();

//        }
//        void LoadChonDotTT()
//        {

//            //Tìm kiếm tất cả nhập mía của hđ đầu tư./
//            string sql = @"SELECT ID,Ten
//                          FROM tbl_DotThanhToan where VuTrongID={0} union (select -1,N'--Tất cả--')  order by ID";
//            DataTable dt = DBModule.ExecuteQuery(string.Format(sql, MDSolutionApp.VuTrongID), null, null).Tables[0];

//            cboChonDot.DataSource = dt;
//            cboChonDot.ValueMember = "ID";
//            cboChonDot.DisplayMember = "Ten";
//            cboHuyChonDot.DataSource = dt;
//            cboHuyChonDot.ValueMember = "ID";
//            cboHuyChonDot.DisplayMember = "Ten";
//            //grvDSPhieuCan.Refresh();

//        }
        private void frm_TruHoTro_Load(object sender, EventArgs e)
        {
            lbTitle.Text = lbTitle.Text + MDSolutionApp.VuTrongTen;
            this.WindowState = FormWindowState.Minimized;
            clsUser oU = new clsUser(MDSolutionApp.User.ID);
            oU.Load(null, null);
            string role = oU.Roles;

            btnXacNhanTT.Visible = (MDSolutionApp.User.ID == 1 || role.Contains("&Thanhtoan_XacNhan&"));

            btnHuy.Visible = (MDSolutionApp.User.ID == 1 || role.Contains("&Thanhtoan_Huy&"));
            lbNguoiTao.Text = MDSolutionApp.User.HoTen.ToUpper();
            dtNgayLap.Value = DateTime.Now;
            //dtNgayLapTD.Value = DateTime.Now;
            txtVuEp.Text = MDSolutionApp.VuTrongTen;
            //LoadPhieuTT();
            LoadDotTT();
            try
            {
                cboDotTT.SelectedValue = CommonClass.DotTTSelected;
            }
            catch (Exception ex)
            {


            }
            this.WindowState = FormWindowState.Maximized;

        }
        MDForms.ThanhToan2016.frm_ThemDotTT frm = new MDForms.ThanhToan2016.frm_ThemDotTT();
        private void cboDotTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDotTT.SelectedIndex > 0)
                CommonClass.DotTTSelected = cboDotTT.SelectedValue;
            if (cboDotTT.SelectedValue.ToString() == "-1")
            {//Tạo mới đợt TT
                if (null == frm || frm.IsDisposed)
                {
                    frm = new MDForms.ThanhToan2016.frm_ThemDotTT();
                }
                frm.ShowDialog();
                LoadDotTT();
            }
            else
            {
                string sql = "select * from tbl_DotThanhToan where ID={0}";

                try
                {
                    DataSet ds = DBModule.ExecuteQuery(string.Format(sql, cboDotTT.SelectedValue), null, null);
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        NgayChotDot = ((DateTime)ds.Tables[0].Rows[0]["NgayChotDot"]);
                        lbNgayChot.Text = NgayChotDot.Value.ToString("dd/MM/yyyy");
                    }
                }
                catch (Exception ex)
                {

                    NgayChotDot = null;
                    lbNgayChot.Text = "-";
                }

            }
        }
        //private void cboDotTTTD_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cboDotTTTD.SelectedValue.ToString() == "-1")
        //    {//Tạo mới đợt TT
        //        if (null == frm || frm.IsDisposed)
        //        {
        //            frm = new MDForms.ThanhToan2016.frm_ThemDotTT();
        //        }
        //        frm.ShowDialog();
        //        LoadDotTT();
        //    }
        //    else
        //    {
        //        string sql = "select * from tbl_DotThanhToan where ID={0}";

        //        try
        //        {
        //            DataSet ds = DBModule.ExecuteQuery(string.Format(sql, cboDotTTTD.SelectedValue), null, null);
        //            if (ds.Tables[0].Rows.Count == 1)
        //            {
        //                NgayChotDotTD = ((DateTime)ds.Tables[0].Rows[0]["NgayChotDot"]);
        //                lbNgayChot_TD.Text = NgayChotDotTD.Value.ToString("dd/MM/yyyy");
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            NgayChotDotTD = null;
        //            lbNgayChot_TD.Text = "-";
        //        }

        //    }
        //}
        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            LoadHD(txtMaHD.Text);
            //TinhTongCo();
            TinhTongTruNo();
        }

        void LoadHD(string MaHD)
        {
            string sql = "select * from V2016_HopDongVuTrong where VuTrongID={0} and MaHopDong=N'{1}'";
            DataSet ds = DBModule.ExecuteQuery(string.Format(sql, MDSolutionApp.VuTrongID, MaHD), null, null);
            try
            {
                if (ds.Tables[0].Rows.Count == 1)
                {
                    DataRow dr = ds.Tables[0].Rows[0];

                    long.TryParse(dr["ID"].ToString(), out HopDongID);

                    txtTenHD.Text = dr["HoTen"].ToString();
                    txtDiaChi.Text = dr["Diachi"].ToString();
                    txtXom.Text = dr["ThonTen"].ToString();
                    txtXa.Text = dr["XaTen"].ToString();
                    txtHuyen.Text = dr["HuyenTen"].ToString();
                    txtCanBoDiaBan.Text = dr["CanBoDiaBan"].ToString();
                    try
                    {
                        txtNguoiKT.Text = dr["NguoiThuaKe1Ten"].ToString();
                        txtCMTNguoiKT.Text = dr["NguoiThuaKe1CMT"].ToString();
                    }
                    catch (Exception ex)
                    {


                    }
                    btnSave.Enabled = true;
                }
                else
                {
                    HopDongID = -1;
                    txtTenHD.Text = "";
                    txtDiaChi.Text = "";
                    txtXom.Text = "";
                    txtXa.Text = "";
                    txtHuyen.Text = "";
                    txtCanBoDiaBan.Text = "";
                    txtNguoiKT.Text = "";
                    txtCMTNguoiKT.Text = "";

                }
                LoadAll();
            }
            catch (Exception ex)
            {
                HopDongID = -1;
                txtTenHD.Text = "";
                txtDiaChi.Text = "";
                txtXom.Text = "";
                txtXa.Text = "";
                txtHuyen.Text = "";
                txtCanBoDiaBan.Text = "";
                txtNguoiKT.Text = "";
                txtCMTNguoiKT.Text = "";

            }
        }
        void LoadAll()
        {
            //LoadPhieuCan();
            LoadMiaGiong();
            //LoadTienMat();
            LoadDauTu();
        }
        //void LoadPhieuTT()
        //{
        //    try
        //    {
        //        DBModule.ExecuteNonQuery("Delete From tbl_ThanhToanMia Where TongTienMia=0 And VuTrongID=" + MDSolutionApp.VuTrongID.ToString(), null, null);
        //        string sql = "select * from V2016_PhieuTT where (TrangThaiHuy is null ) and vutrongid={0} ";
        //        if (!dtTuNgay.IsNullDate) sql += " and [NgayThanhToan]>='" + dtTuNgay.Value.ToString("yyyy-MM-dd") + "' ";
        //        if (!dtDenNgay.IsNullDate) sql += " and [NgayThanhToan]<='" + dtDenNgay.Value.ToString("yyyy-MM-dd") + " 23:59:59' ";
        //        if (cboChonDot.SelectedIndex > 0) sql += " and DotThanhToanID=" + cboChonDot.SelectedValue;
        //        grvPhieuTT.SetDataBinding(DBModule.ExecuteQuery(string.Format(sql, MDSolutionApp.VuTrongID), null, null).Tables[0], "");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Đã có lỗi khi tải dữ liệu phiếu thanh toán!\n" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //}
        //void LoadPhieuTTHuy()
        //{
        //    string sql = "select * from V2016_PhieuTT where (TrangThaiHuy = 1 ) and vutrongid={0} ";
        //    if (!dtHuyTuNgay.IsNullDate) sql += " and [NgayThanhToan]>='" + dtHuyTuNgay.Value.ToString("yyyy-MM-dd") + "' ";
        //    if (!dtHuyDenNgay.IsNullDate) sql += " and [NgayThanhToan]<='" + dtHuyDenNgay.Value.ToString("yyyy-MM-dd") + " 23:59:59' ";
        //    if (cboHuyChonDot.SelectedIndex > 0) sql += " and DotThanhToanID=" + cboHuyChonDot.SelectedValue;

        //    grvPhieuTTHuy.SetDataBinding(DBModule.ExecuteQuery(string.Format(sql, MDSolutionApp.VuTrongID), null, null).Tables[0], "");
        //}
        //void LoadPhieuCan()
        //{
        //    grvDSPhieuCan.SetDataBinding(null, "");
        //    if (HopDongID < 1) return;
        //    string sql = "select * from V2016_NhapMia where vutrongid={0} and HopDongID={1} and NgayRa<='{2}'";

        //    if (PhieuID > 0) sql += " and (DaThanhToan is null or DaThanhToan=0 or DaThanhToan=" + PhieuID + ")";
        //    else sql += " and (DaThanhToan is null or DaThanhToan=0)";

        //    grvDSPhieuCan.SetDataBinding(DBModule.ExecuteQuery(string.Format(sql, MDSolutionApp.VuTrongID, HopDongID, NgayChotDot.Value.ToString("yyyy-MM-dd") + " 23:59:59"), null, null).Tables[0], "");
        //    if (PhieuID > 0)
        //    {
        //        foreach (Janus.Windows.GridEX.GridEXRow row in grvDSPhieuCan.GetRows())
        //        {
        //            if (row.RowType == RowType.Record)
        //            {
        //                if (row.Cells["DaThanhToan"].Value.ToString() == PhieuID.ToString()) row.CheckState = RowCheckState.Checked;
        //            }
        //        }
        //        grvDSPhieuCan.Refresh();
        //    }
        //}
        void LoadMiaGiong()
        {
            grvMiaGiong.SetDataBinding(null, "");
            if (HopDongID < 1) return;
            string sql = "select * from V2016_NhapMia_Giong where vutrongid={0} and HopDongID={1} and Ngay_Lap<='{2}'";

            if (PhieuID > 0) sql += " and (DaThanhToan is null or DaThanhToan=0 or DaThanhToan=" + PhieuID + ")";
            else sql += " and (DaThanhToan is null or DaThanhToan=0)";

            grvMiaGiong.SetDataBinding(DBModule.ExecuteQuery(string.Format(sql, MDSolutionApp.VuTrongID, HopDongID, NgayChotDot.Value.ToString("yyyy-MM-dd")), null, null).Tables[0], "");
            if (PhieuID > 0)
            {
                foreach (Janus.Windows.GridEX.GridEXRow row in grvMiaGiong.GetRows())
                {
                    if (row.RowType == RowType.Record)
                    {
                        if (row.Cells["DaThanhToan"].Value.ToString() == PhieuID.ToString()) row.CheckState = RowCheckState.Checked;
                    }
                }
                grvMiaGiong.Refresh();
            }
        }
        //void LoadTienMat()
        //{
        //    grvTienMat.SetDataBinding(null, "");
        //    if (HopDongID < 1) return;

        //    string sql = "select * from tbl_NhapTienTraNo where vutrongid={0} and HopDongID={1} and NgayTra<='{2}'";
        //    if (PhieuID > 0) sql += " and (DaThanhToan is null or DaThanhToan=0 or DaThanhToan=" + PhieuID + ")";
        //    else sql += " and (DaThanhToan is null or DaThanhToan=0)";

        //    grvTienMat.SetDataBinding(DBModule.ExecuteQuery(string.Format(sql, MDSolutionApp.VuTrongID, HopDongID, NgayChotDot.Value.ToString("yyyy-MM-dd")), null, null).Tables[0], "");
        //    if (PhieuID > 0)
        //    {
        //        foreach (Janus.Windows.GridEX.GridEXRow row in grvTienMat.GetRows())
        //        {
        //            if (row.RowType == RowType.Record)
        //            {
        //                if (row.Cells["DaThanhToan"].Value.ToString() == PhieuID.ToString()) row.CheckState = RowCheckState.Checked;
        //            }
        //        }
        //        grvTienMat.Refresh();
        //    }
        //}
        bool isCheckall = true;
        void LoadDauTu()
        {
            lbMsg.Text = "";
            grvTruNo.SetDataBinding(null, "");
            if (HopDongID < 1) return;
            string sql = "";
            DateTime dtNgayChotLaiVu = DateTime.Now;
            try
            {
                dtNgayChotLaiVu = (DateTime)DBModule.ExecuteQuery("select [NgayChotTinhLaiDauTu] from [tbl_VuTrong] where ID=" + MDSolutionApp.VuTrongID, null, null).Tables[0].Rows[0][0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa thiết lập ngày chốt lãi vụ."); return;
            }

            //if (dtNgayChotLaiVu > dtNgayLap.Value) dtNgayChotLaiVu = dtNgayLap.Value;
            if (PhieuID > 0)
            {
                sql = @"SELECT   CASE WHEN DanhMucDauTuID = 286 THEN 0 ELSE 1 END AS [Order],ID, ThuaRuongID, DanhMucDauTuID, DonGia, SoLuong, LaiSuat, NgayDauTu, GhiChu, DotDauTu, DuNo, NgayBatDauTinhLai, DaThanhToan, VuTruoc, LaDuNoVuTruoc,
                       QuanLyVaKhauHaoID, CreatedBy, ModifyBy, DateAdd, DataModify, NoteModify, Status, DonViCungUngVatTuID, SoChungTu, HopDongID, VuTrongID, SoTien, 
                        Ten, TienLai - TruLai +  ISNULL
                          ((SELECT     SUM(ISNULL(TruLai, 0)) AS Expr1
                              FROM         dbo.tbl_ThanhToanMia_TruNoDauTu AS a
                              WHERE     (DauTuID = dbo.V2016_DauTu.ID and ThanhToan_ID=" + PhieuID + @" )), 0) as TienLai
                            
                            , SoTien - TruGoc +  ISNULL
                          ((SELECT     SUM(ISNULL(TruGoc, 0)) AS Expr1
                              FROM         dbo.tbl_ThanhToanMia_TruNoDauTu AS a
                              WHERE     (DauTuID = dbo.V2016_DauTu.ID and ThanhToan_ID=" + PhieuID + @" )), 0) AS DuNoGoc,
                        ISNULL
                          ((SELECT     SUM(ISNULL(TruGoc, 0)) AS Expr1
                              FROM         dbo.tbl_ThanhToanMia_TruNoDauTu AS a
                              WHERE     (DauTuID = dbo.V2016_DauTu.ID and ThanhToan_ID=" + PhieuID + @" )), 0) as TruGoc,
                 ISNULL
                          ((SELECT     SUM(ISNULL(TruLai, 0)) AS Expr1
                              FROM         dbo.tbl_ThanhToanMia_TruNoDauTu AS a
                              WHERE     (DauTuID = dbo.V2016_DauTu.ID and ThanhToan_ID=" + PhieuID + @" )), 0) as TruLai
                    FROM         dbo.V2016_DauTu
                    where vutrongid={0} and HopDongID={1}";// and NgayDauTu<='{2}' ";
                //sql += " and (ID in (select DauTuID from tbl_ThanhToanMia_TruNoDauTu where ThanhToan_ID=" + PhieuID + " ) )";
                //sql += " and ((SoTien- isnull((select SUM(isnull(TruGoc,0)) from tbl_ThanhToanMia_TruNoDauTu a where a.DauTuID=V2016_DauTu.ID),0)>0 or ISNULL(TienLai, 0)  + ISNULL(DuNoLai, 0)-isnull((select SUM(isnull(TruLai,0)) from tbl_ThanhToanMia_TruNoDauTu a where a.DauTuID=V2016_DauTu.ID),0)>0) or ThanhToan_ID=" + PhieuID + ")";
            }
            else
            {
                sql = @"select CASE WHEN DanhMucDauTuID = 286 THEN 0 ELSE 1 END AS [Order], [ID]
                              ,[ThuaRuongID]
                              ,[DanhMucDauTuID]
                              ,[DonGia]
                              ,[SoLuong]
                              ,[LaiSuat]
                              ,[NgayDauTu]
                              ,[GhiChu]
                              ,[DotDauTu]
                              ,[DuNo]
                              ,[NgayBatDauTinhLai]
                              ,[DaThanhToan]
                              ,[VuTruoc]
                              ,[LaDuNoVuTruoc]
                              ,[QuanLyVaKhauHaoID]
                              ,[CreatedBy]
                              ,[ModifyBy]
                              ,[DateAdd]
                              ,[DataModify]
                              ,[NoteModify]
                              ,[Status]
                              ,[DonViCungUngVatTuID]
                              ,[SoChungTu]
                              ,[HopDongID]
                              ,[VuTrongID]
                              ,[SoTien]
                              ,0 as [TruGoc]
                              ,0 as [TruLai]
                              
                              ,[Ten]
                              
                                ,SoTien- isnull((select SUM(isnull(TruGoc,0)) from tbl_ThanhToanMia_TruNoDauTu a where a.DauTuID=V2016_DauTu.ID),0)  as DuNoGoc
                                , TienLai-isnull((select SUM(isnull(TruLai,0)) from tbl_ThanhToanMia_TruNoDauTu a where a.DauTuID=V2016_DauTu.ID),0) as [TienLai] from V2016_DauTu where vutrongid={0} and HopDongID={1}";// and NgayDauTu<='{2}' ";
                // sql += " and (SoTien- isnull((select SUM(isnull(TruGoc,0)) from tbl_ThanhToanMia_TruNoDauTu a where a.DauTuID=V2016_DauTu.ID),0)>0 or TienLai-isnull((select SUM(isnull(TruLai,0)) from tbl_ThanhToanMia_TruNoDauTu a where a.DauTuID=V2016_DauTu.ID),0)>0)";
            }
            grvTruNo.SetDataBinding(DBModule.ExecuteQuery(string.Format(sql, MDSolutionApp.VuTrongID, HopDongID, NgayChotDot.Value.ToString("yyyy-MM-dd")), null, null).Tables[0], "");
            //grvTruNo.FilterRow.BeginEdit();
            //grvTruNo.FilterRow.Cells["SoTien"].Value = 0;
            //grvTruNo.FilterRow.Cells["TienLai"].Value = 0;
            //grvTruNo.FilterRow.EndEdit();
              iTienVayKhacCount = 0;
            foreach (Janus.Windows.GridEX.GridEXRow row in grvTruNo.GetRows())
            {
                if (row.RowType == RowType.Record)
                {
                    row.BeginEdit();
                    row.Cells["TruGoc"].Value = row.Cells["DB_TruGoc"].Value;
                    row.Cells["TruLai"].Value = row.Cells["DB_TruLai"].Value;

                    row.EndEdit();
                    if (isCheckall || (row.Cells["DanhMucDauTuID"].Value.ToString() == "207196" && row.Cells["SoTien"].Value.ToString() != "0"))
                        row.CheckState = RowCheckState.Checked;
                    if (row.Cells["DanhMucDauTuID"].Value.ToString() == "207196" && row.Cells["SoTien"].Value.ToString() != "0")
                        iTienVayKhacCount += 1;
                }
            }
            if (iTienVayKhacCount > 0)
            {
                lbMsg.Text = "Hợp đồng có " + iTienVayKhacCount + " khoản mục [Tiền vay khác] bạn chú ý tính lại lãi trước khi trừ nợ.";
            }

        }
        int iTienVayKhacCount = 0;
        //private void grvDSPhieuCan_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
        //{
        //    decimal Tong = 0;
        //    foreach (Janus.Windows.GridEX.GridEXRow row in grvDSPhieuCan.GetCheckedRows())
        //    {
        //        if (row.RowType == RowType.Record)
        //        {
        //            Tong += (decimal)row.Cells["ThanhTien"].Value;
        //        }
        //    }
        //    txtTongTienMia.Text = Tong.ToString("###,##0");
        //    grvDSPhieuCan.Refresh();


        //}

        private void grvMiaGiong_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
        {
            decimal Tong = 0;
            foreach (Janus.Windows.GridEX.GridEXRow row in grvMiaGiong.GetCheckedRows())
            {
                if (row.RowType == RowType.Record)
                {
                    Tong += (decimal)row.Cells["ThanhTien"].Value;
                }
            }
            txtTongMiaGiong.Text = Tong.ToString("###,##0");
            grvMiaGiong.Refresh();
        }
        //void TinhTongCo()
        //{
        //    //TM:
        //    decimal Tong = 0;
        //    foreach (Janus.Windows.GridEX.GridEXRow row in grvTienMat.GetCheckedRows())
        //    {
        //        if (row.RowType == RowType.Record)
        //        {
        //            Tong += (decimal)row.Cells["ThanhTien"].Value;
        //        }
        //    }
        //    txtTongTienMat.Text = Tong.ToString("###,##0");
        //    //Giong
        //    Tong = 0;
        //    foreach (Janus.Windows.GridEX.GridEXRow row in grvMiaGiong.GetCheckedRows())
        //    {
        //        if (row.RowType == RowType.Record)
        //        {
        //            Tong += (decimal)row.Cells["ThanhTien"].Value;
        //        }
        //    }
        //    txtTongMiaGiong.Text = Tong.ToString("###,##0");
        //    Tong = 0;
        //    foreach (Janus.Windows.GridEX.GridEXRow row in grvDSPhieuCan.GetCheckedRows())
        //    {
        //        if (row.RowType == RowType.Record)
        //        {
        //            Tong += (decimal)row.Cells["ThanhTien"].Value;
        //        }
        //    }
        //    txtTongTienMia.Text = Tong.ToString("###,##0");
        //    grvDSPhieuCan.Refresh();
        //}
        //private void grvTienMat_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
        //{
        //    decimal Tong = 0;
        //    foreach (Janus.Windows.GridEX.GridEXRow row in grvTienMat.GetCheckedRows())
        //    {
        //        if (row.RowType == RowType.Record)
        //        {
        //            Tong += (decimal)row.Cells["ThanhTien"].Value;
        //        }
        //    }
        //    txtTongTienMat.Text = Tong.ToString("###,##0");
        //    grvTienMat.Refresh();
        //}

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtTongTienMat_TextChanged(object sender, EventArgs e)
        {
            txtTongTienCo.Text = (decimal.Parse(txtTongTienMia.Text) + decimal.Parse(txtTongMiaGiong.Text) + decimal.Parse(txtTongTienMat.Text)).ToString("###,##0");
            LoadDauTu();
            //TinhTongCo();
            TinhTongTruNo();
        }

        private void txtTongTienCo_TextChanged(object sender, EventArgs e)
        {
            txtThuVe.Text = (decimal.Parse(txtTongTienCo.Text) - decimal.Parse(txtTongThuNo.Text)).ToString("###,##0");

        }

        private void btnTruNo_Click(object sender, EventArgs e)
        {
            if (iTienVayKhacCount > 0)
            {
                if (HopDongID < 0) return;
                DateTime dtNgayChotLaiVu = dtNgayLap.Value;

                string sql = "execute sp_2016_TinhLaiKhoanVayKhac_TruTuDong {0}, '" + dtNgayChotLaiVu.ToString("yyyy-MM-dd") + @"'," + PhieuID + ";";
                string sqlExecute = "";
                foreach (Janus.Windows.GridEX.GridEXRow row in grvTruNo.GetRows())
                {

                    if (row.RowType == RowType.Record)
                    {
                        if (row.Cells["DanhMucDauTuID"].Value.ToString() == "207196")
                        {
                            sqlExecute += string.Format(sql, row.Cells["ID"].Value);
                        }
                    }
                }
                if (!string.IsNullOrEmpty(sqlExecute))
                {

                    DBModule.ExecuteNonQuery(sqlExecute, null, null);

                    LoadDauTu();
                    TinhTongTruNo();
                }
            }
            decimal TongCo = decimal.Parse(txtTongTienCo.Text);
            //Tru lai
            foreach (Janus.Windows.GridEX.GridEXRow row in grvTruNo.GetCheckedRows())
            {

                if (row.RowType == RowType.Record)
                {
                    decimal tienlai = (decimal)row.Cells["TienLai"].Value;
                    decimal tienGoc = (decimal)row.Cells["SoTien"].Value;
                    row.BeginEdit();
                    row.Cells["TruLai"].Value = 0;

                    if (TongCo > 0)
                        if (tienlai <= TongCo)
                        {
                            row.Cells["TruLai"].Value = tienlai;
                            TongCo = TongCo - tienlai;

                        }
                        else
                        {
                            row.Cells["TruLai"].Value = TongCo;
                            TongCo = 0;
                        }
                    row.EndEdit();
                }
            }
            //tru goc
            foreach (Janus.Windows.GridEX.GridEXRow row in grvTruNo.GetCheckedRows())
            {

                if (row.RowType == RowType.Record)
                {
                    decimal tienlai = (decimal)row.Cells["TienLai"].Value;
                    decimal tienGoc = (decimal)row.Cells["SoTien"].Value;
                    row.BeginEdit();

                    row.Cells["TruGoc"].Value = 0;

                    if (TongCo > 0)
                        if (TongCo > 0 && tienGoc <= TongCo)
                        {
                            row.Cells["TruGoc"].Value = tienGoc;
                            TongCo = TongCo - tienGoc;
                        }
                        else
                        {
                            row.Cells["TruGoc"].Value = TongCo;
                            TongCo = 0;
                        }
                    row.EndEdit();
                }
            }
            TinhTongTruNo();
        }

        private void txtGoc_TextChanged(object sender, EventArgs e)
        {
            txtTongThuNo.Text = (decimal.Parse(txtLai.Text) + decimal.Parse(txtGoc.Text)).ToString("###,##0");
        }

      
        private void grvTruNo_RecordUpdated(object sender, EventArgs e)
        {
            TinhTongTruNo();
        }
        void TinhTongTruNo()
        {
            decimal TongThuGoc = 0;
            decimal TongThuLai = 0;
            Janus.Windows.GridEX.GridEXRow row = grvTruNo.GetTotalRow();

            if (row != null)
            {
                TongThuGoc = decimal.Parse(row.Cells["TruGoc"].Value.ToString());
                TongThuLai = decimal.Parse(row.Cells["TruLai"].Value.ToString());
            }
            txtLai.Text = TongThuLai.ToString("###,##0");
            txtGoc.Text = TongThuGoc.ToString("###,##0");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "";
            try
            {
                if (isConfirm)
                {
                    if (dtNgayLap.Value.ToString("yyyyMMdd") != DateTime.Now.ToString("yyyyMMdd"))
                        if (MessageBox.Show("Xác nhận ngày thanh toán là ngày \r\n" + dtNgayLap.Value.ToString("dd/MM/yyyy"), "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        {
                            return;
                        }

                }
                if (dtNgayLap.IsNullDate)
                {
                    MessageBox.Show("Vui lòng chọn ngày làm thanh toán", "Chọn ngày làm thanh toán");
                    dtNgayLap.Focus();
                }
                if (HopDongID < 0)
                {
                    MessageBox.Show("Bạn chưa chọn hợp đồng");
                    return;
                }
                decimal TongTLMia = 0, SLMiaGiong = 0, TienMiaGiong = 0, TraNoBangTM = 0, TongTLMia1 = 0, TongTLMiaChay = 0, TongTLMiaRep = 0;
                //foreach (var r in grvDSPhieuCan.GetCheckedRows())
                //{
                //    decimal TrongLuongMiaSach = (decimal)r.Cells["TrongLuongMiaSach"].Value;
                //    TongTLMia += TrongLuongMiaSach;

                //    decimal PhanTramMiaChay = (decimal)r.Cells["PhanTramMiaChay"].Value;
                //    TongTLMiaChay += TrongLuongMiaSach * PhanTramMiaChay / 100;
                //    decimal PhanTramMiaRep = (decimal)r.Cells["PhanTramMiaRep"].Value;
                //    TongTLMiaRep += TrongLuongMiaSach * PhanTramMiaRep / 100;
                //    TongTLMia1 += TrongLuongMiaSach * (100 - PhanTramMiaChay - PhanTramMiaRep) / 100;
                //}

                //foreach (var r in grvMiaGiong.GetCheckedRows())
                //{
                //    SLMiaGiong += (decimal)r.Cells["SoLuong"].Value;
                //    TienMiaGiong += (decimal)r.Cells["ThanhTien"].Value;
                //}
                //foreach (var r in grvTienMat.GetCheckedRows())
                //{
                //    TraNoBangTM += (decimal)r.Cells["ThanhTien"].Value;

                //}
                decimal ConNo = (decimal)grvTruNo.GetTotalRow().Cells["SoTien"].Value - (decimal)grvTruNo.GetTotalRow().Cells["TruGoc"].Value;
                //decimal.TryParse(grvDSPhieuCan.GetTotalRow().Cells["TongTLMia"].Value.ToString(), out TongTLMia);
                //decimal.TryParse(grvDSPhieuCan.GetTotalRow().Cells["SLMiaGiong"].Value.ToString(), out SLMiaGiong);

                //decimal.TryParse(grvDSPhieuCan.GetTotalRow().Cells["TienMiaGiong"].Value.ToString(), out TienMiaGiong);
                //decimal.TryParse(grvDSPhieuCan.GetTotalRow().Cells["TraNoBangTM"].Value.ToString(), out TraNoBangTM);
                //decimal.TryParse(grvDSPhieuCan.GetTotalRow().Cells["TraGoc"].Value.ToString(), out TraGoc);
                //decimal.TryParse(grvDSPhieuCan.GetTotalRow().Cells["TraLai"].Value.ToString(), out TraLai);  
                MDForms.ThanhToan2016.frm_ChietTinhCongNo_Confirm_Huy frmcomment = new MDForms.ThanhToan2016.frm_ChietTinhCongNo_Confirm_Huy();
                string strCommnet = "";
                if (isConfirm)
                    if (!string.IsNullOrEmpty(UserCreateID) && UserCreateID != MDSolutionApp.User.ID.ToString())
                    {

                        if (frmcomment.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }
                        else
                            strCommnet =  DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " " + MDSolutionApp.User.UserName + ":" + frmcomment.txtGhiChu.Text+";\r\n" ;
                    }

                if (PhieuID <= 0)//chưa có phiếu
                {
                    //0. Tạo mã phiếu:
                    string stt = DBModule.ExecuteQueryForOneResult("Get_MaPhieu 'tbl_ThanhToanMia', " + MDSolutionApp.VuTrongID, null, null);
                    DateTime dt = (DateTime)DBModule.ExecuteQuery("Select NgayBatDau from tbl_VuTrong where ID=" + MDSolutionApp.VuTrongID, null, null).Tables[0].Rows[0][0];

                    // string strMaPhieu = "NMG" + dt.Year.ToString("###") + ".";
                    string strMaPhieu = "TT" + dt.Year.ToString("###") + "_";
                    strMaPhieu = strMaPhieu + stt.PadLeft(6, '0');
                    //1. Insert tbl_thanhtoan
                    sql = @"INSERT INTO [tbl_ThanhToanMia]
                                   ([HopDongID]
                                   ,[TongTienMia]
                                   ,[TongDauTu]
                                   ,[NgayThanhToan]
                                   ,[VuTrongID]
                                   ,[DotThanhToanID]
                                   ,[TienNhanVe]
                                   ,[TienNhanVeBangChu]
                                   ,[MaPhieuTT],UserTaoID,TongTLMia,SLMiaGiong,TienMiaGiong,TraNoBangTM,TraGoc,TraLai,TongTLMia1 ,TongTLMiaChay ,TongTLMiaRep,ConNo,CreatedBy,DateAdd)
                             VALUES
                                   ({0}
                                   ,{1}
                                   ,{2}
                                   ,'{3}'
                                   ,{4}
                                   ,{5}
                                   ,{6}
                                   ,N'{7}'
                                   ,N'{8}',{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{9},getdate());
                        select @@IDENTITY;";
                    PhieuID = int.Parse(DBModule.ExecuteQueryForOneResult(string.Format(sql, HopDongID, CommonClass.FormatSqlNumber(txtTongTienCo.Text), CommonClass.FormatSqlNumber(txtGoc.Text), dtNgayLap.Value.ToString("yyyy-MM-dd HH:mm:ss"), MDSolutionApp.VuTrongID, cboDotTT.SelectedValue, CommonClass.FormatSqlNumber(txtThuVe.Text), Utils.DocSo(Double.Parse(txtThuVe.Text)), strMaPhieu, MDSolutionApp.User.ID
                      , TongTLMia.ToString("##0"), SLMiaGiong.ToString("##0"), TienMiaGiong.ToString("##0"), TraNoBangTM.ToString("##0"), CommonClass.FormatSqlNumber(txtGoc.Text), CommonClass.FormatSqlNumber(txtLai.Text), TongTLMia1.ToString("##0"), TongTLMiaChay.ToString("##0"), TongTLMiaRep.ToString("##0"), ConNo.ToString("##0")), null, null));
                    txtSoPhieuTT.Text = strMaPhieu;
                }
                else
                {//Da co phieu(update)
                    sql = @"UPDATE [tbl_ThanhToanMia]
                               SET 
                                  [TongTienMia] = {0}
                                    ,[NoteModify] =isnull([NoteModify] ,'') +  N'{19}'
                                  ,[TongDauTu] = {1}
                                  ,[NgayThanhToan] = '{2}'
                                  ,[VuTrongID] = {3}
                                  ,[DotThanhToanID] = {4}
                                  ,[TienNhanVe] ={5}
                                  ,[TienNhanVeBangChu] =N'{6}'                                                                    
                                  ,TongTLMia={9},SLMiaGiong={10},TienMiaGiong={11},TraNoBangTM={12},TraGoc={13},TraLai={14}  ,TongTLMia1={15} ,TongTLMiaChay={16} ,TongTLMiaRep = {17},ConNo={18},ModifyBy={7},DataModify=getdate()                             
                             WHERE ID={8}";
                    DBModule.ExecuteNonQuery(string.Format(sql, CommonClass.FormatSqlNumber(txtTongTienCo.Text), CommonClass.FormatSqlNumber(txtGoc.Text), dtNgayLap.Value.ToString("yyyy-MM-dd HH:mm:ss"), MDSolutionApp.VuTrongID,
                        cboDotTT.SelectedValue, CommonClass.FormatSqlNumber(txtThuVe.Text), Utils.DocSo(Double.Parse(txtThuVe.Text)), MDSolutionApp.User.ID,
                        PhieuID, TongTLMia.ToString("##0"), SLMiaGiong.ToString("##0"), TienMiaGiong.ToString("##0"), TraNoBangTM.ToString("##0"),
                        CommonClass.FormatSqlNumber(txtGoc.Text), CommonClass.FormatSqlNumber(txtLai.Text), TongTLMia1.ToString("##0"), TongTLMiaChay.ToString("##0"),
                        TongTLMiaRep.ToString("##0"), ConNo.ToString("##0"), strCommnet), null, null);
                    //1.1 Xoa Noi dung phieu:
                    sql = "update tbl_nhapmia set DaThanhToan=0 where DaThanhToan=" + PhieuID; DBModule.ExecuteQuery(sql, null, null);
                    sql = "update tbl_NhapMia_Giong set DaThanhToan=0 where DaThanhToan=" + PhieuID; DBModule.ExecuteQuery(sql, null, null);
                    sql = "update tbl_NhapTienTraNo set DaThanhToan=0 where DaThanhToan=" + PhieuID; DBModule.ExecuteQuery(sql, null, null);
                    sql = "Delete tbl_ThanhToanMia_TruNoDauTu where ThanhToan_ID=" + PhieuID; DBModule.ExecuteQuery(sql, null, null);

                }
                //2.Update nhapmia:
                sql = "update tbl_nhapmia set DaThanhToan=" + PhieuID + " where 1=2 ";
                bool isUpdate = false;
                //foreach (Janus.Windows.GridEX.GridEXRow row in grvDSPhieuCan.GetCheckedRows())
                //{
                //    if (row.RowType == RowType.Record)
                //    {
                //        sql += " or ID=" + row.Cells["ID"].Value;
                //        isUpdate = true;
                //    }
                //}
                //if (isUpdate) DBModule.ExecuteQuery(sql, null, null);
                //3.Update nhapmia_giong:
                isUpdate = false;
                sql = "update tbl_NhapMia_Giong set DaThanhToan=" + PhieuID + " where 1=2 ";
                foreach (Janus.Windows.GridEX.GridEXRow row in grvMiaGiong.GetCheckedRows())
                {
                    if (row.RowType == RowType.Record)
                    {
                        sql += " or ID=" + row.Cells["ID"].Value;
                        isUpdate = true;
                    }
                }
                //if (isUpdate) DBModule.ExecuteQuery(sql, null, null);
                ////4.Update tienmat:
                //isUpdate = false;
                //sql = "update tbl_NhapTienTraNo set DaThanhToan=" + PhieuID + " where 1=2 ";
                //foreach (Janus.Windows.GridEX.GridEXRow row in grvTienMat.GetCheckedRows())
                //{
                //    if (row.RowType == RowType.Record)
                //    {
                //        sql += " or ID=" + row.Cells["ID"].Value;
                //        isUpdate = true;
                //    }
                //}
                if (isUpdate) DBModule.ExecuteQuery(sql, null, null);
                //5. insert thanh toan:

                sql = @"INSERT INTO [tbl_ThanhToanMia_TruNoDauTu]
                           ([HopDongID]
                           ,[DauTuID]
                           ,[SoTienDauTu]
                           ,[TruocTT_Goc]
                           ,[TruocTT_Lai]
                           ,[TruGoc]
                           ,[TruLai]
                           ,[SauTT_Goc]
                           ,[SauTT_Lai]
                           ,[ThanhToan_ID]

                           ,[TruGoc_TM]
                           ,[TruLai_TM]
                           ,[TruGoc_Giong]
                           ,[TruLai_Giong]
                           ,[TruGoc_TMia]
                           ,[TruLai_TMia],LaiDauTu,NgayTinh)
                     Select
                           {0}
                           ,{1}
                           ,{2}
                           ,{3}
                           ,{4}
                           ,{5}
                           ,{6}
                           ,{7}
                           ,{8}
                           ,{9},{10},{11},{12},{13},{14},{15},TienLai,NgayChotTinhLai
                        From tbl_DauTu where ID={1};";
                //sql += "update tbl_dautu set TienLai={10} ,NgayChotTinhLai='{11}'; ";

                //decimal TienMiaGiong_CL = TienMiaGiong, TraNoBangTM_CL = TraNoBangTM, TienMia_CL = decimal.Parse(txtTongTienMia.Text),
                //    TruGoc_TMia = 0, TruLai_TMia = 0, TruGoc_TM = 0, TruLai_TM = 0, TruGoc_Giong = 0, TruLai_Giong = 0;
                decimal TienMia = decimal.Parse(txtTongTienMia.Text);
                foreach (Janus.Windows.GridEX.GridEXRow row in grvTruNo.GetRows())
                {
                    if (row.RowType == RowType.Record)
                    {

                        row.BeginEdit();
                        row.Cells["TruGoc_TM"].Value = "0"; row.Cells["TruLai_TM"].Value = "0";
                        row.Cells["TruGoc_Giong"].Value = "0"; row.Cells["TruLai_Giong"].Value = "0";
                        row.Cells["TruGoc_TMia"].Value = "0"; row.Cells["TruLai_TMia"].Value = "0";
                        row.EndEdit();
                    }
                }
                if (TienMia > 0) Tru(TienMia, "TMia");
                if (TienMiaGiong > 0) Tru(TienMiaGiong, "Giong");
                if (TraNoBangTM > 0) Tru(TraNoBangTM, "TM");


                foreach (Janus.Windows.GridEX.GridEXRow row in grvTruNo.GetRows())
                {
                    if (row.RowType == RowType.Record)
                    {
                        decimal TruGoc = 0;
                        decimal TruLai = 0;
                        if (row.Cells["TruGoc"].Value != null) decimal.TryParse(row.Cells["TruGoc"].Value.ToString(), out TruGoc);
                        if (row.Cells["TruLai"].Value != null) decimal.TryParse(row.Cells["TruLai"].Value.ToString(), out TruLai);
                        if (!(TruGoc == 0 && TruLai == 0))
                        {
                            DBModule.ExecuteNonQuery(string.Format(sql, HopDongID, row.Cells["ID"].Value.ToString(), row.Cells["SoTien"].Value.ToString(), row.Cells["SoTien"].Value.ToString(), row.Cells["TienLai"].Value.ToString(), TruGoc, TruLai, "NULL", "NULL", PhieuID,
                                row.Cells["TruGoc_TM"].Value.ToString(), row.Cells["TruLai_TM"].Value.ToString(),
                                row.Cells["TruGoc_Giong"].Value.ToString(), row.Cells["TruLai_Giong"].Value.ToString(),
                                row.Cells["TruGoc_TMia"].Value.ToString(), row.Cells["TruLai_TMia"].Value.ToString()
                                ), null, null);
                        }
                    }
                }

                //6. Load PhieuDetail
                LoadPhieuTT_Detail(PhieuID, txtSoPhieuTT.Text, HopDongID, txtMaHD.Text, dtNgayLap.Value, (int)cboDotTT.SelectedValue, 0);
                if (isConfirm) MessageBox.Show("Lưu thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lưu." + ex.Message);
            }
        }
        void Tru(decimal SoTien, string Loai)
        {
            foreach (Janus.Windows.GridEX.GridEXRow row in grvTruNo.GetRows())
            {
                if (row.RowType == RowType.Record)
                {

                    if (SoTien > 0)
                    {
                        decimal TruLai = 0;
                        decimal TruLai_DaTru = 0;

                        if (row.Cells["TruLai"].Value != null) decimal.TryParse(row.Cells["TruLai"].Value.ToString(), out TruLai);
                        if (row.Cells["TruLai_DaTru"].Value != null) decimal.TryParse(row.Cells["TruLai_DaTru"].Value.ToString(), out TruLai_DaTru);
                        if (TruLai != 0)
                        {
                            decimal t = TruLai - TruLai_DaTru;
                            decimal t2 = 0;
                            if (SoTien > t)
                            {
                                t2 = t;
                            }
                            else
                            {
                                t2 = SoTien;
                            }
                            SoTien -= t2;
                            row.BeginEdit();
                            row.Cells["TruLai_" + Loai].Value = t2.ToString("##0");
                            row.Cells["TruLai_DaTru"].Value = TruLai_DaTru + t2;
                            row.EndEdit();
                        }
                    }

                }
            }

            foreach (Janus.Windows.GridEX.GridEXRow row in grvTruNo.GetRows())
            {
                if (row.RowType == RowType.Record)
                {

                    if (SoTien > 0)
                    {
                        decimal TruGoc = 0;
                        decimal TruGoc_DaTru = 0;
                        if (row.Cells["TruGoc"].Value != null) decimal.TryParse(row.Cells["TruGoc"].Value.ToString(), out TruGoc);
                        if (row.Cells["TruGoc_DaTru"].Value != null) decimal.TryParse(row.Cells["TruGoc_DaTru"].Value.ToString(), out TruGoc_DaTru);
                        if (TruGoc != 0)
                        {
                            decimal t = TruGoc - TruGoc_DaTru;
                            decimal t2 = 0;
                            if (SoTien > t)
                            {
                                t2 = t;
                            }
                            else
                            {
                                t2 = SoTien;
                            }
                            SoTien -= t2;
                            row.BeginEdit();
                            row.Cells["TruGoc_" + Loai].Value = t2.ToString("##0");
                            row.Cells["TruGoc_DaTru"].Value = TruGoc_DaTru + t2;
                            row.EndEdit();
                        }

                    }

                }
            }

        }
        private int PhieuID = -1;
        private void txtSoPhieuTT_TextChanged(object sender, EventArgs e)
        {
            btnHuy.Enabled = PhieuID > 0 ? true : false;
            btnInPhieu.Enabled = PhieuID > 0 ? true : false;
            dtNgayLap.Enabled = PhieuID > 0 ? false : true;
        }

      
        private void grvPhieuTT_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "ChiTiet")
            {
                //LoadPhieu();
            }
        }
        //void LoadPhieu()
        //{
        //    //PhieuID = (int)grvPhieuTT.GetRow().Cells["ID"].Value;
        //    //txtSoPhieuTT.Text = grvPhieuTT.GetRow().Cells["MaPhieuTT"].Value.ToString();
        //    //HopDongID = long.Parse(grvPhieuTT.GetRow().Cells["HopDongID"].Value.ToString());
        //    //txtMaHD.Text = grvPhieuTT.GetRow().Cells["MaHopDong"].Value.ToString();
        //    //LoadAll();
        //    //TinhTongCo();
        //    //TinhTongTruNo();
        //    bool trangthaihuy = false;
        //    btnSave.Enabled = true;
        //    btnXacNhanTT.Enabled = true;
        //    if (grvPhieuTT.GetRow().Cells["TrangThaiHuy"].Value.ToString() == "1") trangthaihuy = true;
        //    LoadPhieuTT_Detail((int)grvPhieuTT.GetRow().Cells["ID"].Value, grvPhieuTT.GetRow().Cells["MaPhieuTT"].Value.ToString(), long.Parse(grvPhieuTT.GetRow().Cells["HopDongID"].Value.ToString()), grvPhieuTT.GetRow().Cells["MaHopDong"].Value.ToString(), (DateTime)grvPhieuTT.GetRow().Cells["NgayThanhToan"].Value, (int)grvPhieuTT.GetRow().Cells["DotTTID"].Value, (int)grvPhieuTT.GetRow().Cells["XacNhanTT"].Value, trangthaihuy);
        //    TabThanhToanMia.SelectedTab = tab_LamTT;
        //}
        void LoadPhieuTT_Detail(int _PhieuTTID, string _SoPhieu, long _HopDongID, string _Ma_HopDong, DateTime _NgayLap, int _DotTTID, int XacNhanTT, bool TrangThaiHuy = false)
        {

            if (TrangThaiHuy)
            {
                PhieuID = -1;
                txtSoPhieuTT.Text = _SoPhieu;
                HopDongID = -1;
                txtMaHD.Text = _Ma_HopDong;
                txtMaHD.ReadOnly = true;

                dtNgayLap.Value = _NgayLap;
                cboDotTT.SelectedValue = _DotTTID;

                LoadAll();
                //TinhTongCo();
                TinhTongTruNo();

            }
            else
            {
                PhieuID = _PhieuTTID;
                txtSoPhieuTT.Text = _SoPhieu;
                HopDongID = _HopDongID;
                txtMaHD.Text = _Ma_HopDong;
                txtMaHD.ReadOnly = true;
                dtNgayLap.Value = _NgayLap;
                cboDotTT.SelectedValue = _DotTTID;
                LoadAll();
                //TinhTongCo();
                TinhTongTruNo();

            }
            string sql = "select isnull( CreatedBy,'') as CreatedBy,isnull(NoteModify,'') as NoteModify from tbl_ThanhToanMia where ID=" + PhieuID;
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            UserCreateID = ds.Tables[0].Rows[0]["CreatedBy"].ToString();
            lbGhiChu.Text = ds.Tables[0].Rows[0]["NoteModify"].ToString();
            sql = "select HoTen from sys_User where ID=" + UserCreateID;
            string UserCreateName = "";
            if (!string.IsNullOrEmpty(UserCreateID)) UserCreateName = DBModule.ExecuteQueryForOneResult(sql, null, null);
            lbNguoiTao.Text = UserCreateName.ToUpper();
            if (XacNhanTT == 1 || TrangThaiHuy || (MDSolutionApp.User.ID != 1 && UserCreateID != MDSolutionApp.User.ID.ToString()))
            {
                btnSave.Enabled = false;
                btnXacNhanTT.Enabled = false;
            }
        }
        string UserCreateID = "";
        bool isConfirm = true;
        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            isConfirm = true;
            PhieuID = -1;
            txtSoPhieuTT.Text = "";
            HopDongID = -1;
            txtMaHD.Text = "";
            dtNgayLap.Value = DateTime.Now;
            LoadAll();
            //TinhTongCo();
            TinhTongTruNo();
            txtMaHD.ReadOnly = false;
            dtNgayLap.Focus();
            lbNguoiTao.Text = MDSolutionApp.User.HoTen.ToUpper();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {

                MDForms.ThanhToan2016.frm_ChietTinhCongNo_Confirm_Huy frmhuy = new MDForms.ThanhToan2016.frm_ChietTinhCongNo_Confirm_Huy();
                if (frmhuy.ShowDialog() == DialogResult.OK)
                {
                    string sql = @"UPDATE [tbl_ThanhToanMia]
                               SET 
                                 TrangThaiHuy= 1                                 
                                ,LyDoHuy =N'{0}'                                   
                                ,NgayHuy =getdate()
                                ,NguoiHuy =N'{1}'
                             WHERE ID={2}";
                    DBModule.ExecuteNonQuery(string.Format(sql, frmhuy.txtGhiChu.Text, MDSolutionApp.User.HoTen, PhieuID), null, null);
                    //1.1 Xoa Noi dung phieu:
                    sql = "update tbl_nhapmia set DaThanhToan=0 where DaThanhToan=" + PhieuID; DBModule.ExecuteQuery(sql, null, null);
                    sql = "update tbl_NhapMia_Giong set DaThanhToan=0 where DaThanhToan=" + PhieuID; DBModule.ExecuteQuery(sql, null, null);
                    sql = "update tbl_NhapTienTraNo set DaThanhToan=0 where DaThanhToan=" + PhieuID; DBModule.ExecuteQuery(sql, null, null);

                    sql = "Delete tbl_ThanhToanMia_TruNoDauTu where ThanhToan_ID=" + PhieuID; DBModule.ExecuteQuery(sql, null, null);

                    MessageBox.Show("Đã hủy phiếu thành công.");
                    PhieuID = -1;
                    txtSoPhieuTT.Text = "";
                    HopDongID = -1;
                    txtMaHD.Text = "";
                    LoadAll();
                    //TinhTongCo();
                    TinhTongTruNo();
                    txtMaHD.ReadOnly = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi hủy phiếu." + ex.Message);

            }

        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (PhieuID < 1)
            {
                MessageBox.Show("Vui lòng chọn phiếu in."); return;
            }
            string[] paramNames = new string[] { "@PhieuTTID", "@VuTrongID" };
            string[] paraValues = new string[] { PhieuID.ToString(), MDSolutionApp.VuTrongID.ToString() };
            CommonClass.ShowReport("ThanhToan2016\\PhieuTT2.rpt", "Phiếu thanh toán", paramNames, paraValues, null);
        }
        //grvTruNo
        private void btnTimHD_Click(object sender, EventArgs e)
        {
            frmTimKiemHopDong frm = new frmTimKiemHopDong();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //txtMaHD.Text = frm.Ma_HD;
            }
        }

        private void btnTinhLai_Click(object sender, EventArgs e)
        {
            DateTime dtNgayChotLaiVu = dtNgayLap.Value;
            //try
            //{
            //    dtNgayChotLaiVu = (DateTime)DBModule.ExecuteQuery("select [NgayChotTinhLaiDauTu] from [tbl_VuTrong] where ID=" + MDSolutionApp.VuTrongID, null, null).Tables[0].Rows[0][0];
            //}
            //catch (Exception exx)
            //{
            //    MessageBox.Show("Chưa thiết lập ngày chốt lãi vụ."); return;
            //}

            //if (dtNgayChotLaiVu > dtNgayLap.Value) dtNgayChotLaiVu = dtNgayLap.Value;
            if (grvTruNo.GetCheckedRows().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn dòng đầu tư nào để tính lãi", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn muốn tính tiền lãi cho các khoản đầu tư đang chọn đến ngày " + dtNgayChotLaiVu.ToString("dd/MM/yyyy") + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "update tbl_dautu set TienLai=dbo.Tinh_Lai_DauTu(SoTien, ISNULL(LaiSuat, 0), NgayDauTu, '" + dtNgayChotLaiVu.ToString("yyyy-MM-dd") + @"', 
                      DanhMucDauTuID) ,NgayChotTinhLai='" + dtNgayChotLaiVu.ToString("yyyy-MM-dd") + "' where VuTrongID=" + MDSolutionApp.VuTrongID + " AND HopDongID=" + HopDongID + " ";
                string sqlDauTuIDS = "";
                string sql2 = "execute sp_2016_TinhLaiKhoanVayKhac {0}, '" + dtNgayChotLaiVu.ToString("yyyy-MM-dd") + @"';";
                string sqlExecute = "";
                foreach (Janus.Windows.GridEX.GridEXRow row in grvTruNo.GetCheckedRows())
                {

                    if (row.RowType == RowType.Record)
                    {
                        if (row.Cells["DanhMucDauTuID"].Value.ToString() == "207196")
                        {
                            sqlExecute += string.Format(sql2, row.Cells["ID"].Value);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(sqlDauTuIDS))
                                sqlDauTuIDS += row.Cells["ID"].Value;
                            else
                                sqlDauTuIDS += "," + row.Cells["ID"].Value;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(sqlDauTuIDS))
                    sql += " AND ID in (" + sqlDauTuIDS + ");" + sqlExecute;
                else
                    sql = sqlExecute;
                DBModule.ExecuteNonQuery(sql, null, null);
                MessageBox.Show("Đã cập nhật thành công tiền lãi cho toàn bộ đầu tư.", "Thông báo");
                LoadAll();
                //TinhTongCo();
                TinhTongTruNo();
            }
        }
        private void TinhLaiMacDinh()
        {
            if (HopDongID < 0) return;
            DateTime dtNgayChotLaiVu = dtNgayLap.Value;

            string sql = "execute sp_2016_TinhLaiKhoanVayKhac {0}, '" + dtNgayChotLaiVu.ToString("yyyy-MM-dd") + @"';";
            string sqlExecute = "";
            foreach (Janus.Windows.GridEX.GridEXRow row in grvTruNo.GetRows())
            {

                if (row.RowType == RowType.Record)
                {
                    if (row.Cells["DanhMucDauTuID"].Value.ToString() == "207196")
                    {
                        sqlExecute += string.Format(sql, row.Cells["ID"].Value);
                    }
                }
            }
            if (!string.IsNullOrEmpty(sqlExecute))
            {

                DBModule.ExecuteNonQuery(sqlExecute, null, null);

                LoadAll();
                //TinhTongCo();
                TinhTongTruNo();
            }
        }
        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xác nhận thanh toán cho phiếu này? Sau khi xác nhận, phiếu sẽ không thể sửa được.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = @"UPDATE [tbl_ThanhToanMia]
                               SET 
                                 [XacNhanTT] = 1                                                               
                             WHERE ID={0}";
                DBModule.ExecuteNonQuery(string.Format(sql, PhieuID), null, null);
                MessageBox.Show("Đã xác nhận thanh toán thành công, phiếu sẽ không thể sửa được.", "Thông báo");
                btnXacNhanTT.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        private void grvPhieuTT_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            //if (e.Row.RowType == RowType.Record)
                //LoadPhieu();
        }

        private void btnSave_EnabledChanged(object sender, EventArgs e)
        {
            btnHuy.Enabled = btnSave.Enabled && (PhieuID > 0);

        }

        private void cmdAddHD_Click(object sender, EventArgs e)
        {
            //LoadPhieuTT();
        }

    
        private void uiButton3_Click(object sender, EventArgs e)
        {
        //    if (cboDotTTTD.SelectedIndex < 0)
        //    {
        //        MessageBox.Show("Vui lòng chọn đợt thanh toán"); return;
        //    }
        //    string sql = "sp_2016_TT_LuDong " + MDSolutionApp.VuTrongID + ",NULL,'" + NgayChotDotTD.Value.ToString("yyyy-MM-dd") + " 23:59:59',-1";
        //    grvTTTD.SetDataBinding(DBModule.ExecuteQuery(sql, null, null).Tables[0], "");
        }

        private void btnDoiTru_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thực hiện thanh toán tự động các hộ đã chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    btnThemPhieu_Click(null, null);
                    string sids = ",";
                    //foreach (Janus.Windows.GridEX.GridEXRow r in grvTTTD.GetCheckedRows())
                    //{
                    //    btnThemPhieu_Click(null, null);
                    //    sids += r.Cells["ID"].Value + ",";
                    //    dtNgayLap.Value = dtNgayLapTD.Value;
                    //    cboDotTT.SelectedIndex = cboDotTTTD.SelectedIndex;
                    //    isConfirm = false;
                    //    isCheckall = false;
                    //    string MaHopDong = r.Cells["MaHopDong"].Value.ToString();
                    //    txtMaHD.Text = MaHopDong;
                    //    isCheckall = true;
                    //    TinhLaiMacDinh();
                    //    grvDSPhieuCan.CheckAllRecords();
                    //    grvDSPhieuCan_RowCheckStateChanged(null, null);
                    //    grvMiaGiong.CheckAllRecords();
                    //    grvMiaGiong_RowCheckStateChanged(null, null);
                    //    grvTienMat.CheckAllRecords();
                    //    grvTienMat_RowCheckStateChanged(null, null);
                    //    grvTruNo.CheckAllRecords();
                    //    btnTruNo_Click(null, null);
                    //    btnSave_Click(null, null);

                    //}
                    string sql = "sp_2016_BangKeTTMia_DuToan " + MDSolutionApp.VuTrongID + ",NULL,'" + NgayChotDotTD.Value.ToString("yyyy-MM-dd") + " 23:59:59',-1";
                    //grvTTTD.SetDataBinding(DBModule.ExecuteQuery(sql, null, null).Tables[0], "");

                    MessageBox.Show("Đã chạy thanh toán xong.", "Thông báo");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Có lỗi khi đối trừ " + ex.Message, "Thông báo");
                }


            }

        }
        void TTTudong(string HDID)
        {
            string sql = @"INSERT INTO [tbl_ThanhToanMia]
                                   ([HopDongID]                                  
                                   ,[VuTrongID],[DotThanhToanID] ,CreatedBy,DateAdd)
                             VALUES
                                   ( {0},{1},{2},getdate());
                        select @@IDENTITY;";
            sql += "update ";
            //int PhieuTDID = int.Parse(DBModule.ExecuteQueryForOneResult(string.Format(sql, HopDongID, MDSolutionApp.VuTrongID, cboDotTTTD.SelectedValue, MDSolutionApp.User.ID), null, null));
            //1.Đánh Dấu các khoản có

            //2.Tính tổng khoản có
            //3.Trừ nợ đầu tư
            //4.Cập nhật lại phiếu


            sql = @"select [ID]
                              ,[SoTien]
                              ,0 as [TruGoc]
                              ,0 as [TruLai]                              
                              ,[Ten]
                              ,NgayDauTu
                                ,SoTien- isnull((select SUM(isnull(TruGoc,0)) from tbl_ThanhToanMia_TruNoDauTu a where a.DauTuID=V2016_DauTu.ID),0)  as DuNoGoc
                                , TienLai-isnull((select SUM(isnull(TruLai,0)) from tbl_ThanhToanMia_TruNoDauTu a where a.DauTuID=V2016_DauTu.ID),0) as [TienLai] from V2016_DauTu where vutrongid={0} and HopDongID={1} and NgayDauTu<='{2}' order by NgayDauTu ";
            DataTable dt = DBModule.ExecuteQuery(string.Format(sql, MDSolutionApp.VuTrongID, HDID, NgayChotDotTD.Value.ToString("yyyy-MM-dd")), null, null).Tables[0];
            sql = "";
            decimal TongCo = decimal.Parse(txtTongTienCo.Text);
            //Tru lai
            foreach (Janus.Windows.GridEX.GridEXRow row in grvTruNo.GetCheckedRows())
            {

                if (row.RowType == RowType.Record)
                {
                    decimal tienlai = (decimal)row.Cells["TienLai"].Value;
                    decimal tienGoc = (decimal)row.Cells["SoTien"].Value;
                    row.BeginEdit();
                    row.Cells["TruLai"].Value = 0;

                    if (TongCo > 0)
                        if (tienlai <= TongCo)
                        {
                            row.Cells["TruLai"].Value = tienlai;
                            TongCo = TongCo - tienlai;

                        }
                        else
                        {
                            row.Cells["TruLai"].Value = TongCo;
                            TongCo = 0;
                        }
                    row.EndEdit();
                }
            }
            //tru goc
            foreach (Janus.Windows.GridEX.GridEXRow row in grvTruNo.GetCheckedRows())
            {

                if (row.RowType == RowType.Record)
                {
                    decimal tienlai = (decimal)row.Cells["TienLai"].Value;
                    decimal tienGoc = (decimal)row.Cells["SoTien"].Value;
                    row.BeginEdit();

                    row.Cells["TruGoc"].Value = 0;

                    if (TongCo > 0)
                        if (TongCo > 0 && tienGoc <= TongCo)
                        {
                            row.Cells["TruGoc"].Value = tienGoc;
                            TongCo = TongCo - tienGoc;
                        }
                        else
                        {
                            row.Cells["TruGoc"].Value = TongCo;
                            TongCo = 0;
                        }
                    row.EndEdit();
                }
            }

        }

        private void txtMaHD_ReadOnlyChanged(object sender, EventArgs e)
        {
            btnTimHD.Enabled = !txtMaHD.ReadOnly;
        }

        private void btnXacNhanTTDS_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xác nhận thanh toán cho phiếu này? Sau khi xác nhận, phiếu sẽ không thể sửa được.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
//                string sids = "";
//                foreach (Janus.Windows.GridEX.GridEXRow r in grvPhieuTT.GetCheckedRows())
//                {
//                    if (!string.IsNullOrEmpty(sids)) sids += ",";
//                    sids += r.Cells["ID"].Value;
//                }
//                string sql = @"UPDATE [tbl_ThanhToanMia]
//                               SET 
//                                 [XacNhanTT] = 1,
//                                 NoteModify  =isnull(NoteModify+N',\r\n',N'')+N'{1}'
//                             WHERE ID in ({0});";
//                DBModule.ExecuteNonQuery(string.Format(sql, sids,DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "-" + MDSolutionApp.User.HoTen + ":XacNhanTT"), null, null);
//                MessageBox.Show("Đã xác nhận thanh toán thành công, phiếu sẽ không thể sửa được.", "Thông báo");
//                LoadPhieuTT();
            }
        }

        private void btnTimPhieuHuy_Click(object sender, EventArgs e)
        {
            //LoadPhieuTTHuy();
        }

        private void cmdInDSPhieuThanhToan_Click(object sender, EventArgs e)
        {
            string sids = ",";
            //foreach (Janus.Windows.GridEX.GridEXRow r in grvPhieuTT.GetCheckedRows())
            //{
            //    sids += r.Cells["ID"].Value + ",";
            //}
            //if (sids.Length < 2)
            //{
            //    MessageBox.Show("Bạn chưa chọn phiếu thanh toán để in", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            MDReport.Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paramNames = new string[] { "@strIDs" };
            string[] paraValues = new string[] { sids };

            CommonClass.ShowReport("\\ThanhToan2016\\PhieuTT_DS.rpt", "", paramNames, paraValues, null);
            //            if (grvPhieuTT.GetCheckedRows().Length == 0)
            //            {
            //                MessageBox.Show("Bạn chưa chọn phiếu cần in"); return;
            //            }
            //            string[] paramNames = new string[] {};
            //            string[] paraValues = new string[] {};

            //            string sql = @" SELECT *
            //                            FROM  tbl_ThanhToanMia  where 1=3 ";
            //            foreach (Janus.Windows.GridEX.GridEXRow r in grvPhieuTT.GetCheckedRows())
            //            {
            //                sql += " or ID=" + r.Cells["ID"].Value;
            //            }
            //            //DataSet ds = DBModule.ExecuteQuery(sql, null, null);

            //            //DataSet ds = new DataSet();
            //            //DataTable dt = new DataTable();
            //            //dt.Columns.Add("ID");
            //            //foreach (Janus.Windows.GridEX.GridEXRow r in grvPhieuTT.GetCheckedRows())
            //            //{
            //            //    DataRow dr =dt.NewRow(); dr["ID"]= r.Cells["ID"].Value;
            //            //    dt.Rows.Add(dr);
            //            //}
            //            //ds.Tables.Add(dt);
            //            MDReport.Frm_ReportViewer frm = new MDSolution.MDReport.Frm_ReportViewer();
            //            frm.bHasPara = true;
            //            frm.ParaNames = paramNames;
            //            frm.ParaValues = paraValues;
            //            frm.rptFileName = "ThanhToan2016\\PhieuTT_DS.rpt";
            //            frm.rptTitle = "";
            //            //frm.ds = DBModule.ExecuteQuery(sql, null, null);
            //            //if (frmParent != null)
            //            //{
            //            //    frm.MdiParent = frmParent;
            //            //}
            //            frm.Show();
        }

        private void TabThanhToanMia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (TabThanhToanMia.SelectedTab == tab_DsThanhToan)
            //{
            //    LoadPhieuTT();
            //}
        }

        private void cmdExitDTVT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  
    }
}
