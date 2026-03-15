using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using System.Globalization;
using System.Threading;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using MDSolution.MDForms;

namespace MDSolution.MDForms.CapVatTu
{
    public partial class frmQuanLyVatTu : Form
    {
        static frmQuanLyVatTu _frmQuanLyVatTu;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmQuanLyVatTu OneInstanceFrm
        {
            get
            {
                if (null == _frmQuanLyVatTu || _frmQuanLyVatTu.IsDisposed)
                {
                    _frmQuanLyVatTu = new frmQuanLyVatTu();
                }

                return _frmQuanLyVatTu;
            }
        }
        private NodeCanBoNongVu nCBDB = new NodeCanBoNongVu();
        public long _CBNVID = -1;
        private long _SL = 0;
        public frmQuanLyVatTu()
        {
            InitializeComponent();
            CommonClass.LoadTreeCBNV(tvCBDB);
        }

        private void treeDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nCBDB = (NodeCanBoNongVu)tvCBDB.SelectedNode.Tag;
            }
        }

        private void frmQuanLyVatTu_Load(object sender, EventArgs e)
        {
            DataSet ds = DBModule.ExecuteQuery("select YEAR(GETDATE()) as Nam, MONTH(GETDATE()) as Thang, DAY(GETDATE()) as Ngay", null, null);
            int Nam = int.Parse(ds.Tables[0].Rows[0]["Nam"].ToString());
            int Thang = int.Parse(ds.Tables[0].Rows[0]["Thang"].ToString());
            int Ngay = int.Parse(ds.Tables[0].Rows[0]["Ngay"].ToString());
            dtDenNgay.Value = new DateTime(Nam, Thang, Ngay, 23, 59, 0);
            dtTuNgay.Value = dtDenNgay.Value.AddDays(-1);
            dtNgayDT_Den.Value = dtDenNgay.Value;
            dtNgayDT_Tu.Value = dtTuNgay.Value;
            dtDenNgay_DSPhieu.Value = dtDenNgay.Value;
            dtTuNgay_DSPhieu.Value = dtTuNgay.Value;
            Load_DL_CapVT();
            Load_DL_ChiTietCapVatTu();
            Load_DS_PhieuVT();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdThemPhieuCapVT_Click(object sender, EventArgs e)
        {
            if (_CBNVID > 0)
            {
                MDForms.CapVatTu.frm_LapPhieuVatTu frmLapPhieu = new frm_LapPhieuVatTu(_CBNVID);
                //gdDSPhieuCapVT.GetRow()
                frmLapPhieu.ShowDialog();
                if (frmLapPhieu.OK > 0)
                {
                    this.LoadDSPhieuCapVatTu();
                    GridEXFilterCondition condi = new GridEXFilterCondition(this.gdDSPhieuCapVT.RootTable.Columns["ID"], ConditionOperator.Equal, frmLapPhieu._XUATVTID);
                    this.gdDSPhieuCapVT.Find(condi, 0, 1);
                    MessageBox.Show("Đã thêm phiếu thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn được CBNV!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void tvCBDB_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (tvCBDB.SelectedNode != null)
            {
                cmdThemPhieuCapVT.Enabled = false;
                nCBDB = (NodeCanBoNongVu)tvCBDB.SelectedNode.Tag;
            }
        }

        private void tvCBDB_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (tvCBDB.SelectedNode != null)
            {
                nCBDB = (NodeCanBoNongVu)tvCBDB.SelectedNode.Tag;
                if (nCBDB.CBNVType == CBNVType.Root)
                {
                    grDSPhieu.Text = "Danh sách phiếu cấp vật tư tất cả CBĐB";
                    cmdThemPhieuCapVT.Enabled = false;
                }
                else //if (nCBDB.CBNVType == CBNVType.CBNV)
                {
                    grDSPhieu.Text = "Danh sách phiếu cấp vật tư của CBĐB " + tvCBDB.SelectedNode.Text;
                    cmdThemPhieuCapVT.Enabled = true;
                    _CBNVID = long.Parse(nCBDB.CBNVID.ToString());
                }
                this.LoadDSPhieuCapVatTu();
            }
        }
        private void Load_DS_PhieuVT()
        {
            string sqlOrder = " Order By dbo.tbl_XuatVatTu.SoPhieu";
            string sqlWhere = " WHERE  dbo.tbl_XuatVatTu.VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
            if (rdCanRa.Checked)
            {
                sqlWhere = sqlWhere + " AND tbl_XuatVatTu.NgayRa>='" + dtTuNgay_DSPhieu.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND tbl_XuatVatTu.NgayRa<='" + dtDenNgay_DSPhieu.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            if (rdCanVao.Checked)
            {
                sqlWhere = sqlWhere + " AND tbl_XuatVatTu.NgayVao>='" + dtTuNgay_DSPhieu.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND tbl_XuatVatTu.NgayVao<='" + dtDenNgay_DSPhieu.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            if (rdLapPhieu.Checked)
            {
                sqlWhere = sqlWhere + " AND tbl_XuatVatTu.NgayLapPhieu>='" + dtTuNgay_DSPhieu.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND tbl_XuatVatTu.NgayLapPhieu<='" + dtDenNgay_DSPhieu.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            string strSQL = "SELECT     dbo.tbl_XuatVatTu.ID,dbo.tbl_XuatVatTu.CanBoNongVuID, dbo.tbl_XuatVatTu.XeID, dbo.tbl_XuatVatTu.SoPhieu, dbo.tbl_DanhMucVatTu.Ten AS TenVatTu," +
                   "CASE WHEN (dbo.tbl_XuatVatTu.TachTuPhieu =-1) OR (dbo.tbl_XuatVatTu.TachTuPhieu IS NULL) THEN NULL ELSE dbo.tbl_XuatVatTu.TachTuPhieu END AS TachTuPhieu," +
                               "(CASE WHEN ISNULL(dbo.tbl_XeVanChuyen.SoXe,'')='' THEN dbo.tbl_XuatVatTu.SoXeThueNgoai ELSE dbo.tbl_XeVanChuyen.SoXe END) AS SoXe, dbo.tbl_DanhMucCanBoNongVu.Ten AS TenCBNV, dbo.tbl_XuatVatTu.TrongLuongHoaDon,dbo.tbl_XuatVatTu.TrongLuong,dbo.tbl_XuatVatTu.NgayLapPhieu," +
                               "dbo.tbl_XuatVatTu.DaCan, dbo.tbl_HopDongVanChuyen.MaHopDong,tbl_XuatVatTu.NgayVao,tbl_XuatVatTu.NgayRa," +
                               "(CASE ISNULL(dbo.tbl_HopDongVanChuyen.TenChuHopDong,'') WHEN '' THEN N'Thuê ngoài' ELSE dbo.tbl_HopDongVanChuyen.TenChuHopDong END) AS TenChuHopDong, " +
                               "CASE WHEN t.SL>0 THEN 1 ELSE 0 END AS DaCap,dbo.tbl_XuatVatTu.GhiChu  " +
                          " FROM dbo.tbl_XuatVatTu INNER JOIN dbo.tbl_DanhMucCanBoNongVu ON dbo.tbl_XuatVatTu.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.ID " +
                          " LEFT OUTER JOIN dbo.tbl_XeVanChuyen ON dbo.tbl_XuatVatTu.XeID = dbo.tbl_XeVanChuyen.ID INNER JOIN " +
                          " dbo.tbl_DanhMucVatTu ON dbo.tbl_XuatVatTu.VatTuID = dbo.tbl_DanhMucVatTu.DanhMucDauTuID LEFT OUTER JOIN " +
                          " dbo.tbl_HopDongVanChuyen ON dbo.tbl_XeVanChuyen.HopDongVanChuyenID = dbo.tbl_HopDongVanChuyen.ID " +
                          " LEFT OUTER JOIN (Select XuatVatTuID,Count(*) AS SL From tbl_NhanVatTu GROUP BY XuatVatTuID) AS t ON t.XuatVatTuID=tbl_XuatVatTu.ID";
            strSQL = strSQL + sqlWhere + sqlOrder;
            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDanhSachPhieu.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdDanhSachPhieu.DataSource = null;
            }

        }
        private void LoadDSPhieuCapVatTu()
        {
            string sqlAnd = "";
            string strSQL = "SELECT ISNULL(dbo.tbl_XuatVatTu.PhanTramGiaVanChuyenMia,0) AS PhanTramGiaVanChuyenMia,dbo.tbl_XuatVatTu.ID,dbo.tbl_XuatVatTu.CanBoNongVuID, dbo.tbl_XuatVatTu.XeID, dbo.tbl_XuatVatTu.SoPhieu, dbo.tbl_DanhMucVatTu.Ten AS TenVatTu," +
                "CASE WHEN (dbo.tbl_XuatVatTu.TachTuPhieu =-1) OR (dbo.tbl_XuatVatTu.TachTuPhieu IS NULL) THEN NULL ELSE dbo.tbl_XuatVatTu.TachTuPhieu END AS TachTuPhieu," +
                            "(CASE WHEN ISNULL(dbo.tbl_XeVanChuyen.SoXe,'')='' THEN dbo.tbl_XuatVatTu.SoXeThueNgoai ELSE dbo.tbl_XeVanChuyen.SoXe END) AS SoXe, dbo.tbl_DanhMucCanBoNongVu.Ten AS TenCBNV, dbo.tbl_XuatVatTu.TrongLuongHoaDon,dbo.tbl_XuatVatTu.TrongLuong,dbo.tbl_XuatVatTu.NgayLapPhieu,dbo.tbl_XuatVatTu.NgayRa," +
                            "dbo.tbl_XuatVatTu.DaCan, dbo.tbl_HopDongVanChuyen.MaHopDong," +
                            "(CASE ISNULL(dbo.tbl_HopDongVanChuyen.TenChuHopDong,'') WHEN '' THEN N'Thuê ngoài' ELSE dbo.tbl_HopDongVanChuyen.TenChuHopDong END) AS TenChuHopDong " +
                       " FROM dbo.tbl_XuatVatTu INNER JOIN" +
                      " dbo.tbl_DanhMucCanBoNongVu ON dbo.tbl_XuatVatTu.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.id LEFT OUTER JOIN " +
                      "dbo.tbl_XeVanChuyen ON dbo.tbl_XuatVatTu.XeID = dbo.tbl_XeVanChuyen.ID INNER JOIN " +
                      "dbo.tbl_DanhMucVatTu ON dbo.tbl_XuatVatTu.VatTuID = dbo.tbl_DanhMucVatTu.DanhMucDauTuID LEFT OUTER JOIN " +
                      "dbo.tbl_HopDongVanChuyen ON dbo.tbl_XeVanChuyen.HopDongVanChuyenID = dbo.tbl_HopDongVanChuyen.ID " +
                      "WHERE  dbo.tbl_XuatVatTu.VuTrongID=" + MDSolutionApp.VuTrongID.ToString();

            if (nCBDB.CBNVType == CBNVType.Root)//Nếu chọn Root
            {
                sqlAnd = "";
            }
            if (nCBDB.CBNVType == CBNVType.CBNV)//Nếu chọn CBĐB
            {
                sqlAnd = " AND  dbo.tbl_XuatVatTu.CanBoNongVuID=" + nCBDB.CBNVID;
            }
            strSQL = strSQL + sqlAnd + " Order By dbo.tbl_XuatVatTu.SoPhieu";
            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDSPhieuCapVT.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdDSPhieuCapVT.DataSource = null;
                this.gdDS_HoNhanVatTu.DataSource = null;
            }
        }

        private void gdDSPhieuCapVT_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            long XuatVTID = -1;
            long DaCan = -1;
            decimal TLVatTu = 0;
            long CanBoNongVuID = -1;
            string SP = "";
            try
            {
                XuatVTID = long.Parse(gdDSPhieuCapVT.GetValue("ID").ToString());
                DaCan = long.Parse(gdDSPhieuCapVT.GetValue("DaCan").ToString());
                TLVatTu = decimal.Parse(gdDSPhieuCapVT.GetValue("TrongLuong").ToString());
                CanBoNongVuID = long.Parse(gdDSPhieuCapVT.GetValue("CanBoNongVuID").ToString());
                SP = gdDSPhieuCapVT.GetValue("SoPhieu").ToString();
            }
            catch
            {
                MessageBox.Show("Chưa chọn được phiếu để sửa!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (XuatVTID > 0)
            {
                try
                {
                    if (e.Column.Key == "Delete")
                    {
                        if (DaCan <= 0)
                        {
                            if (MessageBox.Show("Bạn chắc chắn xóa phiếu " + SP, "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }
                            clsXuatVatTu.Delete(XuatVTID, null, null);
                            MessageBox.Show("Đã xóa phiếu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDSPhieuCapVatTu();
                        }
                        else
                        {
                            MessageBox.Show("Phiếu đã cân không xóa được!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                    if (e.Column.Key == "Modify")
                    {
                        if (DaCan <= 0)
                        {
                            frm_LapPhieuVatTu frmSua = new frm_LapPhieuVatTu(XuatVTID, CanBoNongVuID);
                            frmSua.ShowDialog();
                            if (frmSua.OK > 0)
                            {
                                this.LoadDSPhieuCapVatTu();
                                GridEXFilterCondition condi = new GridEXFilterCondition(this.gdDSPhieuCapVT.RootTable.Columns["ID"], ConditionOperator.Equal, XuatVTID);
                                this.gdDSPhieuCapVT.Find(condi, 0, 1);
                                MessageBox.Show("Đã sửa phiếu thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Phiếu đã cân không sửa được!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }

                    }
                    if (e.Column.Key == "Print")
                    {
                        string sqldatasource = "SELECT * FROM V_CapVatTu WHERE ID=" + XuatVTID.ToString();
                        DataSet ds = DBModule.ExecuteQuery(sqldatasource, null, null);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            double TrongLuongBangChu = 0;
                            MDSolution.MDForms.frmShowRP2 frm2 = new MDSolution.MDForms.frmShowRP2();
                            MDSolution.MDReport.CapVatTu.rpt_CapVT rp = new MDSolution.MDReport.CapVatTu.rpt_CapVT();
                            rp.SetDataSource(ds.Tables[0]);
                            try
                            {
                                TrongLuongBangChu = double.Parse(ds.Tables[0].Rows[0]["TrongLuongHoaDon"].ToString());
                            }
                            catch { }
                            rp.SetParameterValue("TrongLuongBangChu", Utils.DocSo(TrongLuongBangChu));
                            frm2.RP = rp;
                            frm2.Show();
                        }
                    }
                    if (e.Column.Key == "Split")
                    {
                        if (TLVatTu <= 0)
                        {
                            MessageBox.Show("Phiếu chưa có trọng lượng cân vật tư nên không tách được!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                        if (!KiemTraChuyenDauTu(XuatVTID))
                        {
                            MessageBox.Show("Phiếu đã chuyển đầu tư không tách được!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                        frm_TachPhieuVatTu frm = new frm_TachPhieuVatTu(XuatVTID);
                        frm.ShowDialog();
                        if (frm.OK > 0)
                        {
                            this.LoadDSPhieuCapVatTu();
                            GridEXFilterCondition condi = new GridEXFilterCondition(this.gdDSPhieuCapVT.RootTable.Columns["ID"], ConditionOperator.Equal, XuatVTID);
                            this.gdDSPhieuCapVT.Find(condi, 0, 1);
                            MessageBox.Show("Đã tách phiếu thành công!\nSố phiếu: " + frm.SOPHIEU_TACH.ToString() + "\nCBNV: " + frm.TEN_CBNV, "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra!\n" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
        }
        private bool KiemTraChuyenDauTu(long XuatVT_ID)
        {
            string sql = "Select DaChuyenDauTu From tbl_NhanVatTu Where XuatVatTuID=" + XuatVT_ID.ToString();
            long ret = -1;
            long.TryParse(DBModule.ExecuteQueryForOneResult(sql, null, null), out ret);
            if (ret > 0) return false; else return true;
        }
        private void cmdThemHoCapVT_Click(object sender, EventArgs e)
        {
            string TenVatTu = "";
            long ID_XuatVT = -1;
            try
            {
                TenVatTu = this.gdDSPhieuCapVT.GetValue("TenVatTu").ToString();
                ID_XuatVT = long.Parse(this.gdDSPhieuCapVT.GetValue("ID").ToString());

            }
            catch { }
            if (ID_XuatVT > 0)
            {
                MDForms.CapVatTu.frm_ThemSuaHopDongNhanVatTu frm = new frm_ThemSuaHopDongNhanVatTu(ID_XuatVT, TenVatTu);
                frm.nSoLuongVatTu.Value = decimal.Parse(this.gdDSPhieuCapVT.GetValue("TrongLuong").ToString());
                frm.dtNgayNhan.Value = (DateTime)this.gdDSPhieuCapVT.GetValue("NgayLapPhieu");
                frm.ShowDialog();
                if (frm.OK > 0)
                {
                    LoadDanhSachHoCapVatTu(ID_XuatVT);
                    GridEXFilterCondition condi = new GridEXFilterCondition(this.gdDS_HoNhanVatTu.RootTable.Columns["ID"], ConditionOperator.Equal, frm._IDNHANVATTU);
                    this.gdDS_HoNhanVatTu.Find(condi, 0, 1);
                    MessageBox.Show("Đã thêm thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void LoadDanhSachHoCapVatTu(long IDCapVT)
        {
            string sql = @"SELECT TOP (100) PERCENT dbo.tbl_NhanVatTu.ID, dbo.tbl_NhanVatTu.XuatVatTuID, dbo.tbl_NhanVatTu.HopDongID, dbo.tbl_NhanVatTu.NgayNhan, dbo.tbl_NhanVatTu.DaChuyenDauTu, dbo.tbl_XuatVatTu.SoPhieu, dbo.tbl_HopDong.HoTen, 
                  dbo.tbl_HopDong.MaHopDong, dbo.tbl_HopDong.SoCMT, dbo.tbl_BaiTapKet.TenBai, dbo.tbl_Thon.Ten AS TenThon, dbo.tbl_Xa.Ten AS TenXa, dbo.tbl_Huyen.Ten AS TenHuyen, dbo.tbl_NhanVatTu.SoLuong, dbo.tbl_NhanVatTu.DonGia, 
                  dbo.tbl_NhanVatTu.SoTien, dbo.tbl_NhanVatTu.DonGiaVanChuyen, dbo.tbl_NhanVatTu.TienVanChuyen, dbo.tbl_DanhMucCanBoNongVu.Ten AS CBDB, dbo.tbl_DanhMucVatTu.Ten AS TenVatTu, 
                  CASE WHEN ISNULL(tbl_XeVanChuyen.SoXe, '') = '' THEN tbl_XuatVatTu.SoXeThueNgoai ELSE tbl_XeVanChuyen.SoXe END AS SoXe, CASE WHEN ISNULL(tbl_XeVanChuyen.SoXe, '') 
                  = '' THEN N'Thuê ngoài' ELSE tbl_HopDongVanChuyen.TenChuHopDong END AS TenHDVC, sys_User_1.HoTen AS NguoiSua, dbo.sys_User.HoTen AS NguoiTao, dbo.tbl_NhanVatTu.DateModify AS NgaySua,dbo.tbl_XuatVatTu.NgayLapPhieu,dbo.tbl_XuatVatTu.NgayRa
                  FROM     dbo.tbl_XeVanChuyen RIGHT OUTER JOIN
                  dbo.tbl_Thon RIGHT OUTER JOIN
                  dbo.tbl_DanhMucCanBoNongVu INNER JOIN
                  dbo.tbl_BaiTapKet INNER JOIN
                  dbo.tbl_NhanVatTu INNER JOIN
                  dbo.tbl_HopDong ON dbo.tbl_NhanVatTu.HopDongID = dbo.tbl_HopDong.ID ON dbo.tbl_BaiTapKet.ID = dbo.tbl_NhanVatTu.BaiTapKetID INNER JOIN
                  dbo.tbl_XuatVatTu ON dbo.tbl_NhanVatTu.XuatVatTuID = dbo.tbl_XuatVatTu.ID ON dbo.tbl_DanhMucCanBoNongVu.ID = dbo.tbl_XuatVatTu.CanBoNongVuID INNER JOIN
                  dbo.tbl_DanhMucVatTu ON dbo.tbl_XuatVatTu.VatTuID = dbo.tbl_DanhMucVatTu.DanhMucDauTuID LEFT OUTER JOIN
                  dbo.sys_User AS sys_User_1 ON dbo.tbl_NhanVatTu.ModifyBy = sys_User_1.ID LEFT OUTER JOIN
                  dbo.sys_User ON dbo.tbl_NhanVatTu.CreateBy = dbo.sys_User.ID ON dbo.tbl_Thon.ID = dbo.tbl_BaiTapKet.ThonID ON dbo.tbl_XeVanChuyen.ID = dbo.tbl_XuatVatTu.XeID LEFT OUTER JOIN
                  dbo.tbl_HopDongVanChuyen ON dbo.tbl_XeVanChuyen.HopDongVanChuyenID = dbo.tbl_HopDongVanChuyen.ID LEFT OUTER JOIN
                  dbo.tbl_Xa LEFT OUTER JOIN
                  dbo.tbl_Huyen ON dbo.tbl_Xa.HuyenID = dbo.tbl_Huyen.ID ON dbo.tbl_Thon.XaID = dbo.tbl_Xa.ID" +
                      " WHERE dbo.tbl_NhanVatTu.XuatVatTuID=" + IDCapVT.ToString() + " ORDER BY tbl_HopDong.MaHopDong";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDS_HoNhanVatTu.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdDS_HoNhanVatTu.DataSource = null;
            }
        }
        private void gdDSPhieuCapVT_SelectionChanged(object sender, EventArgs e)
        {
            long XuatVTID = -1;
            string SP = "";
            try
            {
                XuatVTID = long.Parse(this.gdDSPhieuCapVT.GetValue("ID").ToString());
                SP = this.gdDSPhieuCapVT.GetValue("SoPhieu").ToString();
            }
            catch
            {
            }
            if (XuatVTID > 0)
            {
                LoadDanhSachHoCapVatTu(XuatVTID);
                grDSHoNhanVT.Text = "Danh sách hộ nhận vật tư số phiếu " + SP;
            }
            else
            {
                this.gdDS_HoNhanVatTu.DataSource = null;
                grDSHoNhanVT.Text = "Danh sách hộ nhận vật tư ";
            }
        }

        private void gdDS_HoNhanVatTu_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            long IDXuatVT = -1;
            long IDNhanVT = -1;
            long NhanVatTuID = -1;
            long DaChuyenNoDauTu = 0;
            double TienVT = 0;
            try
            {
                IDNhanVT = long.Parse(this.gdDS_HoNhanVatTu.GetValue("ID").ToString());
                IDXuatVT = long.Parse(this.gdDS_HoNhanVatTu.GetValue("XuatVatTuID").ToString());
                NhanVatTuID = long.Parse(this.gdDS_HoNhanVatTu.GetValue("ID").ToString());
                TienVT = double.Parse(this.gdDS_HoNhanVatTu.GetValue("SoTien").ToString());
                long.TryParse(this.gdDS_HoNhanVatTu.GetValue("DaChuyenDauTu").ToString(), out DaChuyenNoDauTu);
            }
            catch
            {
                return;
            }
            if (IDNhanVT > 0)
            {
                if (e.Column.Key == "Delete")
                {
                    if (DaChuyenNoDauTu > 0)
                    {
                        MessageBox.Show("Đã kết chuyển đầu tư\nBạn không thể xóa!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Bạn chắc chắn xóa hộ nhận vật tư này", "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    try
                    {
                        clsNhanVatTu.Delete(IDNhanVT, null, null);
                        LoadDanhSachHoCapVatTu(IDXuatVT);
                    }
                    catch
                    {
                        MessageBox.Show("Đã có lỗi khi xóa!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (e.Column.Key == "Modify")
                {
                    long Modify = 0;
                    string UserName = MDSolutionApp.User.UserName;

                    if (UserName.ToLower() == "batman")
                    {
                        Modify = 1;
                    }
                    else if (DaChuyenNoDauTu > 0)
                    {
                        MessageBox.Show("Đã kết chuyển đầu tư\nBạn không thể sửa!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    MDForms.CapVatTu.frm_ThemSuaHopDongNhanVatTu frmNhanVT = new frm_ThemSuaHopDongNhanVatTu(IDNhanVT, Modify);
                    frmNhanVT.ShowDialog();
                    if (frmNhanVT.OK > 0)
                    {
                        LoadDanhSachHoCapVatTu(IDXuatVT);
                        GridEXFilterCondition condi = new GridEXFilterCondition(this.gdDS_HoNhanVatTu.RootTable.Columns["ID"], ConditionOperator.Equal, IDNhanVT);
                        this.gdDS_HoNhanVatTu.Find(condi, 0, 1);
                        MessageBox.Show("Đã sửa thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (e.Column.Key == "Print")
                {
                    string sql = "sp_RP_PhieuNhanVatTu " + NhanVatTuID.ToString();
                    DataSet ds = DBModule.ExecuteQuery(sql, null, null);
                    MDSolution.MDForms.frmShowRP2 frm = new MDSolution.MDForms.frmShowRP2();
                    MDSolution.MDReport.CapVatTu.rpt_PhieuBienNhanVatTu rp = new MDSolution.MDReport.CapVatTu.rpt_PhieuBienNhanVatTu();
                    rp.SetDataSource(ds.Tables[0]);
                    rp.SetParameterValue("BangChu", Utils.DocSo(TienVT));
                    frm.RP = rp;
                    frm.Show();
                }
            }


        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (this.gdDS_HoNhanVatTu.RowCount > 0)
            {
                frmShowRP2 frm = new frmShowRP2();
                MDSolution.MDReport.CapVatTu.rpt_Cap_NhanVatTu rp = new MDSolution.MDReport.CapVatTu.rpt_Cap_NhanVatTu();
                System.Data.DataTable dt = (System.Data.DataTable)gdDS_HoNhanVatTu.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);
                frm.RP = rp;
                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.RPtitle = "Danh sách các hộ nhận vật tư";
                frm.Show();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Load_DL_CapVT()
        {
            string sql = "Select * From V_ChiTietCapVatTu Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
            if (rdCanRaBangKe.Checked)
            {
                sql = sql + " And NgayRa>='" + dtTuNgay.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' And NgayRa<='" + dtDenNgay.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' Order By SoPhieu";
            }
            if (rdNgayThemPhieu.Checked)
            {
                sql = sql + " And NgayTinhLai>='" + dtTuNgay.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' And NgayTinhLai<='" + dtDenNgay.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' Order By SoPhieu";
            }
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdChiTietCapVatTu.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdChiTietCapVatTu.DataSource = null;
            }
        }
        private void Load_DL_ChiTietCapVatTu()
        {
            string sql = "Select * From V_ChiTietCapVatTu Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString();

            if (rdCanRaKetChuyen.Checked)
            {
                sql = sql + " And NgayRa>='" + dtNgayDT_Tu.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' And NgayRa<='" + dtNgayDT_Den.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' Order By SoPhieu";
            }
            if (rdKetChuyenThemPhieu.Checked)
            {
                sql = sql + " And NgayTinhLai>='" + dtNgayDT_Tu.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' And NgayTinhLai<='" + dtNgayDT_Den.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' Order By SoPhieu";
            }
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdChiTietCapVT_ChuyenDT.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdChiTietCapVT_ChuyenDT.DataSource = null;
            }
        }

        private void cmdXemDL_Click(object sender, EventArgs e)
        {
            Load_DL_CapVT();
        }

        private void cmdXuatExcel_Click(object sender, EventArgs e)
        {
            if (this.gdChiTietCapVatTu.RowCount > 0)
            {
                try
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                        {
                            Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                            exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                            exporter.GridEX = gdChiTietCapVatTu;
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

        private void gdChiTietCapVT_ChuyenDT_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e.Row.RowType == RowType.Record)
            {
                string DaChuyenDT = e.Row.Cells["NguoiChuyen"].Value.ToString();
                if (DaChuyenDT != "")
                {
                    e.Row.CheckState = RowCheckState.Checked;
                    Janus.Windows.GridEX.GridEXFormatStyle CHD_format = new GridEXFormatStyle();
                    CHD_format.ForeColor = Color.DarkOrchid;
                    e.Row.RowStyle = CHD_format;
                }
            }
        }

        private void gdChiTietCapVT_ChuyenDT_EditingCell(object sender, EditingCellEventArgs e)
        {
            if (this.gdChiTietCapVT_ChuyenDT.CurrentRow.RowType == RowType.Record)
            {
                string NC = this.gdChiTietCapVT_ChuyenDT.GetValue("NguoiChuyen").ToString();
                if (e.Column.Key == "ChuyenDauTu")
                {
                    if (string.IsNullOrEmpty(NC))
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                    //if (e.Column.Key == "ChuyenNo")
                    //{
                    //    this.gdChiTietCapVT_ChuyenDT.RootTable.Columns["ChuyenNo"].CheckBoxFalseValue = false;
                    //}
                }

            }
        }

        private void cmdChuyen_Click(object sender, EventArgs e)
        {
            long VuTrongID = -1;
            decimal LaiSuat = 0;
            DateTime NgayTinhLai = DateTime.MinValue;
            //this.gdChiTietCapVT_ChuyenDT.Refetch();
            _SL = 0;
            foreach (GridEXRow row in gdChiTietCapVT_ChuyenDT.GetCheckedRows())
            {
                if (row.RowType == RowType.Record)
                {
                    //long DaChuyen = 0;
                    bool Chuyen = false;
                    string ret = row.Cells["NguoiChuyen"].Value.ToString();
                    //bool.TryParse(row.Cells["ChuyenDauTu"].Value, out Chuyen);
                    //if(row.Cells["ChuyenDauTu"].Value
                    if (row.Cells["ChuyenDauTu"].Row.IsChecked)
                    {
                        Chuyen = true;
                    }
                    if ((string.IsNullOrEmpty(ret)) && (Chuyen))
                    {
                        _SL = _SL + 1;
                    }
                    else
                    {
                        // row.CheckState = RowCheckState.Unchecked;
                    }
                }
            }
            if (_SL <= 0)
            {
                MessageBox.Show("Bạn chưa chọn mục vật tư nào để chuyển", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_DL_ChiTietCapVatTu();
                return;
            }
            MDForms.CapVatTu.frm_CF_LaiSuat_VuTrong frm = new MDForms.CapVatTu.frm_CF_LaiSuat_VuTrong();
            frm.ShowDialog();
            if (frm.OK > 0)
            {
                VuTrongID = frm.VuTrongID;
                LaiSuat = frm.LaiSuat;
                NgayTinhLai = frm.NgayTinhLai;
            }
            if (VuTrongID > 0)
            {
                if (MessageBox.Show("Bạn chắc chắn chuyển " + _SL.ToString() + " mục vật tư như lựa chọn\nđể chuyển thành các khoản đầu tư tương ứng của chủ hộ", "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                try
                {
                    foreach (GridEXRow row in gdChiTietCapVT_ChuyenDT.GetCheckedRows())
                    {
                        string NguoiChuyen = row.Cells["NguoiChuyen"].Value.ToString();
                        if (string.IsNullOrEmpty(NguoiChuyen))
                        {
                            //long DaChuyen = 0;
                            //long.TryParse(row.Cells["DaChuyenDauTu"].Value.ToString(), out DaChuyen);
                            //if (DaChuyen > 0)
                            //{
                            long ID_NhanVatTu = long.Parse(row.Cells["ID"].Value.ToString());
                            clsNhanVatTu oNhanVT = new clsNhanVatTu(ID_NhanVatTu);
                            oNhanVT.Load(null, null);
                            if (oNhanVT.DaChuyenDauTu > 0)//Kiểm tra xem đã chuyển chưa
                            {
                                continue;
                            }
                            clsXuatVatTu oXuatVT = new clsXuatVatTu(oNhanVT.XuatVatTuID);
                            oXuatVT.Load(null, null);
                            clsDauTu oDauTu = new clsDauTu();
                            oDauTu.HopDongID = oNhanVT.HopDongID;//đầu tư cho ai
                            oDauTu.DanhMucDauTuID = oXuatVT.VatTuID;//đầu tư cái gì
                            if (NgayTinhLai == DateTime.MinValue)//ngày đầu tư
                            {
                                oDauTu.NgayDauTu = oNhanVT.NgayNhan;
                            }
                            else
                            {
                                oDauTu.NgayDauTu = NgayTinhLai;
                            }
                            oDauTu.DonViCungUngVatTuID = 1;//Đơn vị đầu tư
                            oDauTu.SoLuong = long.Parse(oNhanVT.SoLuong.ToString());//số lượng
                            oDauTu.DonGia = long.Parse(oNhanVT.DonGia.ToString());//Đơn giá
                            oDauTu.SoTien = oNhanVT.SoTien;//Số tiền đầu tư
                            oDauTu.LaiSuat = decimal.Parse(LaiSuat.ToString());
                            oDauTu.VuTrongID = VuTrongID;
                            oDauTu.GhiChu = "Chuyển từ dữ liệu cấp vật tư địa bàn của CBNV";
                            oDauTu.SoChungTu = SinhSoChungTu(VuTrongID);
                            oDauTu.Save(null, null);
                            clsNhanVatTu.UpDateChuyenDauTu(ID_NhanVatTu, MDSolutionApp.User.HoTen, oDauTu.ID, null, null);
                            //}
                        }
                    }
                    Load_DL_ChiTietCapVatTu();
                    MessageBox.Show("Đã kết chuyển thành công ", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _SL = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra!\n" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _SL = 0;
                }


            }
        }
        private string SinhSoChungTu(long VT)
        {
            string stt = DBModule.ExecuteQueryForOneResult("Get_MaPhieu 'tbl_DauTu', " + VT.ToString(), null, null);
            DateTime dt = (DateTime)DBModule.ExecuteQuery("Select NgayBatDau from tbl_VuTrong where ID=" + VT.ToString(), null, null).Tables[0].Rows[0][0];
            string strMaPhieu = "DT" + dt.Year.ToString("###") + ".";
            strMaPhieu = strMaPhieu + stt.PadLeft(6, '0');
            return strMaPhieu;
        }
        private void gdChiTietCapVT_ChuyenDT_CellEdited(object sender, ColumnActionEventArgs e)
        {
            //if (e.Column.Key == "ChuyenDauTu")
            //{
            //    Janus.Windows.GridEX.GridEXRow row = gdChiTietCapVT_ChuyenDT.GetRow();
            //    if (long.Parse(row.Cells["DaChuyenDauTu"].Value.ToString()) > 0)
            //    {
            //        _SL = _SL + 1;
            //    }
            //    else
            //    {
            //        _SL = _SL - 1;
            //    }
            //}
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            Load_DL_ChiTietCapVatTu();
        }

        private void cmdXuatExcel_VTDT_Click(object sender, EventArgs e)
        {
            if (this.gdChiTietCapVT_ChuyenDT.RowCount > 0)
            {
                try
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                        {
                            Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                            exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                            exporter.GridEX = gdChiTietCapVT_ChuyenDT;
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

        private void cmdTimPhieu_Click(object sender, EventArgs e)
        {
            Load_DS_PhieuVT();
        }

        private void cmd2ExcelDSPhieu_Click(object sender, EventArgs e)
        {
            if (this.gdDanhSachPhieu.RowCount > 0)
            {
                try
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                        {
                            Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                            exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                            exporter.GridEX = gdDanhSachPhieu;
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

        private void cmdChuyenNo_Click(object sender, EventArgs e)
        {
            if (this.gdChiTietCapVT_ChuyenDT.CurrentRow.RowType == RowType.Record)
            {
                string NguoiChuyen = this.gdChiTietCapVT_ChuyenDT.GetValue("NguoiChuyen").ToString();
                string TenHoChuyen = this.gdChiTietCapVT_ChuyenDT.GetValue("HoTen").ToString();
                string MaHoChuyen = this.gdChiTietCapVT_ChuyenDT.GetValue("MaKH").ToString();
                long DauTuID = -1;
                long ID_NhanVatTu = -1;

                if (!string.IsNullOrEmpty(NguoiChuyen))//đã chuyển đầu tư
                {
                    long DaChuyenNo = -1;
                    long.TryParse(this.gdChiTietCapVT_ChuyenDT.GetValue("ChuyenNo").ToString(), out DaChuyenNo);
                    if (DaChuyenNo > 0)
                    {
                        return;
                    }
                    MDForms.CapVatTu.frm_ChonHD frm = new MDForms.CapVatTu.frm_ChonHD(-1);
                    frm.ShowDialog();
                    if (frm.OK > 0)
                    {
                        try
                        {
                            DauTuID = long.Parse(this.gdChiTietCapVT_ChuyenDT.GetValue("DauTuID").ToString());
                            ID_NhanVatTu = long.Parse(this.gdChiTietCapVT_ChuyenDT.GetValue("ID").ToString());
                        }
                        catch
                        {
                            return;
                        }
                        string TenHoNhan = frm.HoTen;
                        long ID_HoNhan = frm.HopDongID;
                        if (MessageBox.Show("Bạn chắc chắn chuyển nợ đầu tư \ntừ hộ " + TenHoChuyen + " sang hộ " + TenHoNhan, "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        try
                        {
                            clsDauTu.ChuyenNoDauTu(DauTuID, ID_HoNhan, null, null);
                            clsNhanVatTu.UpDateChuyenNo(ID_NhanVatTu, MDSolutionApp.User.HoTen, MaHoChuyen + "-" + TenHoChuyen, ID_HoNhan, null, null);
                            Load_DL_ChiTietCapVatTu();
                            GridEXFilterCondition condi = new GridEXFilterCondition(this.gdChiTietCapVT_ChuyenDT.RootTable.Columns["ID"], ConditionOperator.Equal, ID_NhanVatTu);
                            this.gdChiTietCapVT_ChuyenDT.Find(condi, 0, 1);
                            MessageBox.Show("Đã chuyển thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Đã có lỗi xảy ra khi chuyển nợ! ", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hộ " + TenHoChuyen + " chưa chuyển đầu tư! ", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cmdAddFromExcel_Click(object sender, EventArgs e)
        {
            string TenFile = "";
            string TenCBNV = "";
            string SoPhieu = "";
            string TenVatTu = "";
            long ID_XuatVT = -1;
            long CBNVID = -1;
            try
            {
                TenCBNV = this.gdDSPhieuCapVT.GetValue("TenCBNV").ToString();
                SoPhieu = this.gdDSPhieuCapVT.GetValue("SoPhieu").ToString();
                TenVatTu = this.gdDSPhieuCapVT.GetValue("TenVatTu").ToString();
                ID_XuatVT = long.Parse(this.gdDSPhieuCapVT.GetValue("ID").ToString());
                CBNVID = long.Parse(this.gdDSPhieuCapVT.GetValue("CanBoNongVuID").ToString());
            }
            catch
            {
                TenCBNV = "";
                SoPhieu = "";
                TenVatTu = "";
                ID_XuatVT = -1;
                CBNVID = -1;
            }
            if (ID_XuatVT > 0)
            {
                if (clsNhanVatTu.CheckChuyenDauTu(ID_XuatVT, null, null))
                {
                    MessageBox.Show("Tồn tại phiếu chi tiết đã chuyển đầu tư!\nBạn không thể nhập dữ liệu từ file excel!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    string sqlDelete = "Delete From tbl_Temp_Import_Excel_CapVatTu Where XuatVatTuID=" + ID_XuatVT.ToString();
                    DBModule.ExecuteNonQuery(sqlDelete, null, null);
                    if (openFileDialog_Excel.ShowDialog() == DialogResult.OK)////Mở file excel nguồn
                    {
                        TenFile = openFileDialog_Excel.FileName;
                        lblWaite.Visible = true;
                        Excel.Application xlApp;
                        Excel.Workbook xlWorkBook;
                        Excel.Worksheet xlWorkSheet;
                        var missing = System.Reflection.Missing.Value;
                        xlApp = new Excel.Application();
                        xlWorkBook = xlApp.Workbooks.Open(TenFile, false, true, missing, missing, missing, true, Excel.XlPlatform.xlWindows, '\t', false, false, 0, false, true, 0);
                        openFileDialog_Excel.Dispose();
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                        Excel.Range xlRange = xlWorkSheet.UsedRange;
                        Array myValues = (Array)xlRange.Cells.Value2;
                        int vertical = myValues.GetLength(0);
                        int horizontal = myValues.GetLength(1);
                        for (int a = 2; a <= vertical; a++)//Với mỗi hàng
                        {
                            string HopDongID = "-1";
                            string ThonID = "-1";
                            string BaiTapKetID = "-1";
                            string MaHopDong = "";
                            string TenThonKD = "";
                            string TenBaiKD = "";
                            string HoTenKD = "";
                            string Errors = "";
                            string ErrorsIn = "";
                            long STT = 0;
                            long SL = 0;
                            Object element = new Object();
                            string sqlValue = "Values(" + CBNVID.ToString() + "," + ID_XuatVT + ",";
                            for (int b = 1; b <= 7; b++)//Với mỗi cột
                            {
                                try
                                {
                                    element = myValues.GetValue(a, b);//Lấy dữ liệu ô excel
                                }
                                catch
                                {
                                    element = DBNull.Value;
                                }
                                if (b == 1)//Số thứ tự
                                {
                                    try
                                    {
                                        STT = long.Parse(element.ToString().Replace(" ", ""));
                                    }
                                    catch
                                    {
                                        STT = 0;
                                    }
                                    sqlValue = sqlValue + STT.ToString() + ",";
                                }
                                if (b == 4)//Mã hợp đồng
                                {
                                    try
                                    {
                                        MaHopDong = element.ToString().Replace(" ", "");
                                    }
                                    catch
                                    {
                                        MaHopDong = "";
                                    }
                                    sqlValue = sqlValue + "N'" + MaHopDong + "',";
                                }
                                if (b == 6)//Số lượng vật tư nhận
                                {
                                    try
                                    {
                                        SL = long.Parse(element.ToString().Replace(" ", ""));
                                        if (SL <= 0)
                                        {
                                            SL = 0;
                                            ErrorsIn = "Sai số lượng vật tư nhận. ";
                                        }
                                    }
                                    catch
                                    {
                                        ErrorsIn = "Sai số lượng vật tư nhận. ";
                                    }
                                    sqlValue = sqlValue + SL.ToString() + ",";
                                }

                                if (b == 2)//Tên danh mục Thôn/bản bỏ đi khoảng trắng
                                {
                                    try
                                    {
                                        TenThonKD = element.ToString().Replace(" ", "");
                                    }
                                    catch
                                    {
                                        TenThonKD = "";
                                    }
                                    sqlValue = sqlValue + "N'" + element + "',N'" + TenThonKD + "',";
                                }

                                if (b == 3)//Tên danh mục bãi tập kết bỏ đi khoảng trắng
                                {
                                    try
                                    {
                                        TenBaiKD = element.ToString().Replace(" ", "");
                                    }
                                    catch
                                    {
                                        TenBaiKD = "";
                                    }
                                    sqlValue = sqlValue + "N'" + element + "',N'" + TenBaiKD + "',";
                                }
                                if (b == 5)//Tên hộ nhận vật tư bỏ đi khoảng trắng
                                {
                                    try
                                    {
                                        HoTenKD = element.ToString().Replace(" ", "");
                                    }
                                    catch
                                    {
                                        HoTenKD = "";
                                    }
                                    sqlValue = sqlValue + "N'" + element + "',N'" + HoTenKD + "',";
                                }
                                if (b == 7)//Ngày nhận
                                {
                                    var dateTime = DateTime.FromOADate(0).ToString();
                                    try
                                    {
                                        double date = double.Parse(element.ToString());
                                        dateTime = DateTime.FromOADate(date).ToString("yyyy-MM-dd");
                                    }
                                    catch
                                    {
                                        dateTime = "1900-01-01";
                                        ErrorsIn = ErrorsIn + "Sai ngày nhận vật tư. ";
                                    }
                                    sqlValue = sqlValue + "'" + dateTime + "'";
                                }

                            }
                            ////Khi không có đủ thông tin thì bỏ qua
                            if ((string.IsNullOrEmpty(TenThonKD)) && (string.IsNullOrEmpty(TenBaiKD)) && (string.IsNullOrEmpty(HoTenKD)) && (string.IsNullOrEmpty(MaHopDong)))
                            {
                                continue;
                            }
                            ///Khi có đầy đủ thông tin thì đối sánh dữ liệu, nếu sai ghi lỗi
                            //if ((!string.IsNullOrEmpty(TenThonKD)) && (!string.IsNullOrEmpty(TenBaiKD)) && (!string.IsNullOrEmpty(MaHopDong)))
                            //{
                            string sqlCheck = "sp_Check_Import_VatTu " + CBNVID + ",N'" + MaHopDong + "',N'" + TenThonKD + "',N'" + TenBaiKD + "'";
                            DataSet ret = DBModule.ExecuteQuery(sqlCheck, null, null);
                            if (ret.Tables[0].Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["ThonID"].ToString()))
                                {
                                    ThonID = ret.Tables[0].Rows[0]["ThonID"].ToString();
                                }
                                else
                                {
                                    ThonID = "-1";
                                    Errors = Errors + "Sai dữ liệu Tên thôn/bản. ";
                                }
                                if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["BaiTapKetID"].ToString()))
                                {
                                    BaiTapKetID = ret.Tables[0].Rows[0]["BaiTapKetID"].ToString();
                                }
                                else
                                {
                                    BaiTapKetID = "-1";
                                    Errors = Errors + "Sai dữ liệu Tên bãi tập kết. ";
                                }
                                if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["HopDongID"].ToString()))
                                {
                                    HopDongID = ret.Tables[0].Rows[0]["HopDongID"].ToString();
                                }
                                else
                                {
                                    HopDongID = "-1";
                                    Errors = Errors + "Sai dữ liệu Hộ nhận vật tư. ";
                                }
                            }
                            else
                            {
                                Errors = "Chưa đủ dữ liệu để đối sánh. ";
                            }
                            //}
                            //else
                            //{
                            //    Errors = "Chưa đủ dữ liệu để đối sánh. ";
                            //}
                            /////Ghi dữ liệu vào bảng tạm
                            string sqlInsert = "Insert Into tbl_Temp_Import_Excel_CapVatTu(CanBoNongVuID,XuatVatTuID,STT,TenThon,TenThonKD,TenBai,TenBaiKD,MaHopDong,HoTen,HoTenKD,SoLuong,NgayNhan,HopDongID,ThonID,BaiTapKetID,Importer,DateImport,Errors) "
                                          + sqlValue + "," + HopDongID + "," + ThonID + "," + BaiTapKetID + "," + MDSolutionApp.User.ID.ToString() + ",GetDate(),N'" + Errors + ErrorsIn + "')";
                            DBModule.ExecuteNonQuery(sqlInsert, null, null);
                        }

                        xlWorkBook.Close(true, missing, missing);
                        xlApp.Quit();
                        releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlApp);
                        lblWaite.Visible = false;
                        ////Tải dữ liệu từ bảng tạm lên form
                        MDForms.CapVatTu.frm_Temp_Import_CapVatTu frm = new MDForms.CapVatTu.frm_Temp_Import_CapVatTu(ID_XuatVT, SoPhieu, TenCBNV, TenVatTu, TenFile);
                        frm.ShowDialog();
                        if (frm.OK > 0)
                        {
                            LoadDanhSachHoCapVatTu(ID_XuatVT);
                        }

                    }
                }
                catch (Exception ex)
                {
                    lblWaite.Visible = false;
                    MessageBox.Show("Đã có lỗi ngoại lệ xảy ra!\nBạn cần xem lại dữ liệu file Excel\n" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                lblWaite.Visible = false;
                MessageBox.Show("Bạn cần chọn một phiếu cấp vật tư!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private void Check(long ID_XuatVatTu)
        {
            DataSet ds = new DataSet();
            string sqlStr = "Select * From tbl_Temp_Import_Excel_CapVatTu Where XuatVatTuID=" + ID_XuatVatTu.ToString();
            ds = DBModule.ExecuteQuery(sqlStr, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string Errors = "";
                    string HopDongID = "-1";
                    string ThonID = "-1";
                    string BaiTapKetID = "-1";
                    string ID = dr["ID"].ToString();
                    string CBNVID = dr["CanBoNongVuID"].ToString();
                    string HoTenKD = dr["HoTenKD"].ToString();
                    string TenBaiKD = dr["TenBaiKD"].ToString();
                    string TenThonKD = dr["TenThonKD"].ToString();
                    string sql = "sp_Check_Import_VatTu " + CBNVID + ",N'" + HoTenKD + "',N'" + TenThonKD + "',N'" + TenBaiKD + "'";
                    DataSet ret = DBModule.ExecuteQuery(sql, null, null);
                    if (ret.Tables[0].Rows.Count > 0)
                    {

                        if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["ThonID"].ToString()))
                        {
                            ThonID = ret.Tables[0].Rows[0]["ThonID"].ToString();
                        }
                        else
                        {
                            ThonID = "-1";
                            Errors = Errors + "Sai dữ liệu nhập tại cell Tên thôn tương ứng trong file excel. ";
                        }
                        if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["BaiTapKetID"].ToString()))
                        {
                            BaiTapKetID = ret.Tables[0].Rows[0]["BaiTapKetID"].ToString();
                        }
                        else
                        {
                            BaiTapKetID = "-1";
                            Errors = Errors + "Sai dữ liệu nhập tại cell Tên bãi tương ứng trong file excel. ";
                        }
                        if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["HopDongID"].ToString()))
                        {
                            HopDongID = ret.Tables[0].Rows[0]["HopDongID"].ToString();
                        }
                        else
                        {
                            HopDongID = "-1";
                            Errors = Errors + "Sai dữ liệu nhập tại cell Họ tên tương ứng trong file excel. ";
                        }
                    }
                    else
                    {
                        Errors = "Sai dữ liệu nhập tại dòng tương ứng trong file excel. ";
                    }
                    string sqlUpdateErrors = "Update tbl_Temp_Import_Excel_CapVatTu Set HopDongID=" + HopDongID + ",ThonID=" + ThonID + ",BaiTapKetID=" + BaiTapKetID + ",Errors=N'" + Errors + "' Where ID=" + ID;
                    DBModule.ExecuteNonQuery(sqlUpdateErrors, null, null);
                }
            }

        }

        private void gdChiTietCapVT_ChuyenDT_ColumnHeaderClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "ChuyenDauTu")
            {
                //if(e.Column.
                foreach (GridEXRow row in gdChiTietCapVT_ChuyenDT.GetRows())
                {
                    if (row.RowType == RowType.Record)
                    {
                        long DC = 0;
                        string ret = row.Cells["NguoiChuyen"].Value.ToString();
                        if (!string.IsNullOrEmpty(ret))
                        {
                            //_SL = _SL + 1;
                            row.CheckState = RowCheckState.Checked;
                            this.gdChiTietCapVatTu.Validate();
                        }
                        else
                        {
                            //if (e.Column.CheckBoxTriState)
                            //{
                            //    row.CheckState = RowCheckState.Unchecked;
                            //};
                            // row.CheckState = RowCheckState.Unchecked;
                        }
                    }
                }
            }
        }

        private void btnXuatVatTu_Click(object sender, EventArgs e)
        {
            MDForms.CapVatTu.frmCapVT_TuNgay_DenNgay frmLapPhieu = new frmCapVT_TuNgay_DenNgay();
            frmLapPhieu.ShowDialog();
        }

        private void gdChiTietCapVatTu_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "Modify")
            {
                long IDXuat = long.Parse(this.gdChiTietCapVatTu.GetValue("ID").ToString());
                decimal SoTien = decimal.Parse(this.gdChiTietCapVatTu.GetValue("TienVanChuyen").ToString());

                if (MDSolutionApp.User.ID == 83063 || MDSolutionApp.User.ID == 1)
                {
                    frm_SuaVanChuyenVatTu frmSua = new frm_SuaVanChuyenVatTu(IDXuat);
                    frmSua.ShowDialog();
                    if (frmSua.OK > 0)
                    {
                        this.Load_DL_CapVT();
                        //GridEXFilterCondition condi = new GridEXFilterCondition(this.gdChiTietCapVatTu.RootTable.Columns["ID"], ConditionOperator.Equal);
                        //this.gdDSPhieuCapVT.Find(condi, 0, 1);
                        MessageBox.Show("Đã sửa phiếu thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        MessageBox.Show("Có lỗi khi sửa!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền sửa");
                }

            }
        }

        private void gdChiTietCapVT_ChuyenDT_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (MDSolutionApp.User.ID == 1 || MDSolutionApp.User.ID == 414531)
            {

                string sqlupdate = "update tbl_NhanVatTu set DauTuID=0,NgayChuyen=null,NguoiChuyen=null, DaChuyenDauTu=0 where ID= ";
                long IDNhan = -1;
                try
                {
                    IDNhan = long.Parse(this.gdChiTietCapVT_ChuyenDT.GetValue("ID").ToString());
                    sqlupdate = sqlupdate + IDNhan;
                    DBModule.ExecuteNonQuery(sqlupdate, null, null);
                }
                catch
                {
                    MessageBox.Show("Không thể cập nhật");

                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền hủy");
            }
        }
        private void rdNgayThemPhieu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCanRaBangKe.Checked == true)
            {
                rdNgayThemPhieu.Checked = false;
            }
        }
        private void rdCanRaBangKe_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNgayThemPhieu.Checked == true)
            {
                rdCanRaBangKe.Checked = false;
            }
        }

        private void rdCanRaKetChuyen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCanRaKetChuyen.Checked == true)
            {
                rdKetChuyenThemPhieu.Checked = false;
            }
        }
        private void rdKetChuyenThemPhieu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdKetChuyenThemPhieu.Checked == true)
            {
                rdCanRaKetChuyen.Checked = false;
            }
        }

        private void gdDanhSachPhieu_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            long IDPhieu = long.Parse(gdDanhSachPhieu.GetValue("ID").ToString());
            try
            {
                if (e.Column.Key == "Nhap")
                {
                    if (IDPhieu > 0)
                    {
                        MDSolution.MDFoms.CapVatTu.frmConfirmGhiChu frm = new MDFoms.CapVatTu.frmConfirmGhiChu(IDPhieu);
                        frm.ShowDialog();
                        LoadDSPhieuCapVatTu();
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa chọn phiếu", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
            catch(Exception ex) { 
            
            }
        }
    }
}


