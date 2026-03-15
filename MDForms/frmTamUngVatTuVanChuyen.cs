using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using MDSolution.MDReport;
using MDSolution.MDForms;
using Excel = Microsoft.Office.Interop.Excel;
namespace MDSolution.MDForms
{
    public partial class frmTamUngVatTuVanChuyen : Form
    {
        static frmTamUngVatTuVanChuyen _frmTamUngVatTuVanChuyen;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmTamUngVatTuVanChuyen OneInstanceFrm
        {
            get
            {
                if (null == _frmTamUngVatTuVanChuyen || _frmTamUngVatTuVanChuyen.IsDisposed)
                {
                    _frmTamUngVatTuVanChuyen = new frmTamUngVatTuVanChuyen();
                }

                return _frmTamUngVatTuVanChuyen;
            }
        }
        private long _HDVCID = -1;
        private long _XEID = -1;
        private long _UNGVTID = -1;
        private string _SOXE = "";
        public frmTamUngVatTuVanChuyen()
        {
            InitializeComponent();
            dtNgayLap.Value = DateTime.Now;
            dtNgayUngDen.Value = DateTime.Now.AddDays(1);
            Load_gdDSUngTienVanChuyenDuyet();

        }
        private void frmTamUngVatTuVanChuyen_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "DỮ LIỆU ỨNG VẬN CHUYỂN SLS NIÊN VỤ  " + MDSolutionApp.VuTrongTen;
            LoadDS_HDVC();
            string sqlNgay = "Select GetDate()";
            DateTime dt = Convert.ToDateTime(DBModule.ExecuteQueryForOneResult(sqlNgay, null, null));
            dtNgayUng.Value = DateTime.Now;
        }


        private void LoadDS_HDVC()
        {
            string sql = "Select HD.ID AS HDVCID,XE.ID AS XeID,HD.MaHopDong,HD.TenChuHopDong,XE.SoXe" +
                         " FROM tbl_HopDongVanChuyen AS HD INNER JOIN tbl_XeVanChuyen AS XE ON HD.ID=XE.HopDongVanChuyenID WHERE HD.VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " Order By dbo.LPAD(MaHopDong,'4','0')";
            DataSet dataSource = DBModule.ExecuteQuery(sql, null, null);
            if (dataSource.Tables[0].Rows.Count > 0)
            {
                this.gdDSHDVC.SetDataBinding(dataSource.Tables[0], "RootTable");
            }
            else
            {
                this.gdDSHDVC.DataSource = null;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gdDSHDVC_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.gdChiTietUngVatTu.RemoveFilters();
                if (this.gdDSHDVC.CurrentRow.RowType == RowType.Record)
                {
                    try
                    {
                        _HDVCID = long.Parse(this.gdDSHDVC.GetValue("HDVCID").ToString());
                        _XEID = long.Parse(this.gdDSHDVC.GetValue("XeID").ToString());
                        _SOXE = this.gdDSHDVC.GetValue("SoXe").ToString();
                    }
                    catch
                    {
                        _HDVCID = -1;
                        _XEID = -1;
                        _SOXE = "";
                    }
                    if (_XEID > 0)
                    {
                        grDuLieuVC.Text = "Dữ liệu vận chuyển " + _SOXE;
                        grUngVC.Text = "Dữ liệu ứng vận chuyển " + _SOXE;
                        DataSet ds = DuLieuVanChuyen(_XEID);
                        try
                        {
                            lblNgayCuoiVC.Text = ds.Tables[0].Rows[0]["Ngay"].ToString();
                        }
                        catch
                        {
                            lblNgayCuoiVC.Text = "Chưa có dữ liệu vận chuyển";
                        }
                        try
                        {
                            lbl_TienVC.Text = decimal.Parse(ds.Tables[0].Rows[0]["TienVC"].ToString()).ToString("### ### ### ###");
                        }
                        catch
                        {
                            lbl_TienVC.Text = "0";
                        }
                        decimal TienVanChuyenVatTu = 0;
                        string sql = "SELECT SUM(dbo.tbl_NhanVatTu.TienVanChuyen) AS TienVC_VT FROM dbo.tbl_XuatVatTu INNER JOIN  dbo.tbl_NhanVatTu ON dbo.tbl_XuatVatTu.ID = dbo.tbl_NhanVatTu.XuatVatTuID" +
                        "  WHERE XeID=" + _XEID.ToString() + " GROUP BY dbo.tbl_XuatVatTu.XeID";
                        decimal.TryParse(DBModule.ExecuteQueryForOneResult(sql, null, null), out TienVanChuyenVatTu);
                        lbl_TienVCVT.Text = TienVanChuyenVatTu.ToString("### ### ##0");
                        LoadDuLieuUng(_XEID);
                    }
                }
                else
                {
                    this.gdChiTietUngVatTu.DataSource = null;
                    _HDVCID = -1;
                    _XEID = -1;
                    _SOXE = "";
                    lblNgayCuoiVC.Text = "";
                    lbl_TienVC.Text = "0";
                }
            }
            catch { }
        }
        private DataSet DuLieuVanChuyen(long XeVCID)
        {
            string sql = "Select MAX(NgayVanChuyen) AS Ngay,SUM(TienVanChuyen) AS TienVC From tbl_NhapMia Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() +
                       " AND XeID=" + XeVCID.ToString();
            return DBModule.ExecuteQuery(sql, null, null);
        }
        private void LoadDuLieuUng(long XeVCID)
        {
            string sql = "Select   dbo.tbl_UngVatTuVanChuyen.SoChungTu, dbo.tbl_UngVatTuVanChuyen.ID AS ID,dbo.tbl_UngVatTuVanChuyen.HopDongVanChuyenID, dbo.tbl_UngVatTuVanChuyen.XeID," +
                         "dbo.tbl_VatTuVanChuyen.Ten AS TenVatTu, dbo.tbl_UngVatTuVanChuyen.SoLuong, dbo.tbl_UngVatTuVanChuyen.DonGia,NguoiNhap.HoTen AS NguoiNhap,NguoiSua.HoTen AS NguoiSua,tbl_UngVatTuVanChuyen.DateAdd AS NgayNhap,tbl_UngVatTuVanChuyen.DataModify AS NgaySua," +
                         "dbo.tbl_UngVatTuVanChuyen.SoTien,dbo.tbl_UngVatTuVanChuyen.NgayUng From dbo.tbl_UngVatTuVanChuyen INNER JOIN" +
                         " dbo.tbl_XeVanChuyen ON dbo.tbl_UngVatTuVanChuyen.XeID = dbo.tbl_XeVanChuyen.ID INNER JOIN " +
                         " dbo.tbl_VatTuVanChuyen ON dbo.tbl_UngVatTuVanChuyen.VatTuID = dbo.tbl_VatTuVanChuyen.ID INNER JOIN sys_USer AS NguoiNhap ON NguoiNhap.ID=tbl_UngVatTuVanChuyen.CreatedBy" +
                         " LEFT OUTER JOIN sys_USer AS NguoiSua  ON NguoiSua.ID=tbl_UngVatTuVanChuyen.ModifyBy" +
                         " Where ISNULL(tbl_UngVatTuVanChuyen.Xoa,0)<=0 AND tbl_UngVatTuVanChuyen.VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " AND tbl_UngVatTuVanChuyen.XeID=" + XeVCID.ToString() +
                         " ORDER By dbo.tbl_UngVatTuVanChuyen.ID DESC";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdChiTietUngVatTu.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdChiTietUngVatTu.DataSource = null;
            }
        }

        private void gdVChiTietUngVatTu_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "Print")
            {
                try
                {
                    string ID = gdChiTietUngVatTu.GetValue("ID").ToString();
                    string sql = " Select  * From VC_ungvattuvanchuyen Where ID=" + ID;
                    DataSet ds = null;
                    ds = DBModule.ExecuteQuery(sql, null, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MDSolution.MDForms.frmShowRP2 frm2 = new MDSolution.MDForms.frmShowRP2();
                        MDSolution.MDReport.UngVatTuVanChuyen rp = new MDSolution.MDReport.UngVatTuVanChuyen();
                        rp.SetDataSource(ds.Tables[0]);
                        frm2.RP = rp;
                        frm2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Không có phiếu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra! Bạn thực hiện lại lệnh In phiếu!" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            if (e.Column.Key == "Modify")
            {
                if ((_HDVCID > 0) && (_XEID > 0))
                {
                    try
                    {
                        _UNGVTID = long.Parse(this.gdChiTietUngVatTu.GetValue("ID").ToString());
                    }
                    catch
                    {
                        _UNGVTID = -1;
                    }
                    if (_UNGVTID > 0)
                    {
                        MDForms.VanChuyen.frm_ThemSuaUngVanChuyen frm = new VanChuyen.frm_ThemSuaUngVanChuyen(_UNGVTID, _SOXE);
                        frm.ShowDialog();
                        if (frm.OK > 0)
                        {
                            LoadDuLieuUng(_XEID);
                            GridEXFilterCondition condi = new GridEXFilterCondition(this.gdChiTietUngVatTu.RootTable.Columns["ID"], ConditionOperator.Equal, _UNGVTID);
                            this.gdChiTietUngVatTu.FindAll(condi);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn phiếu ứng để sửa!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.Column.Key == "Delete")
            {
                if ((_HDVCID > 0) && (_XEID > 0))
                {
                    string SCT = "";
                    try
                    {
                        _UNGVTID = long.Parse(this.gdChiTietUngVatTu.GetValue("ID").ToString());
                        SCT = this.gdChiTietUngVatTu.GetValue("SoChungTu").ToString();
                    }
                    catch
                    {
                        _UNGVTID = -1;
                    }
                    if (_UNGVTID > 0)
                    {
                        if (MessageBox.Show("Bạn chắc chắn xóa phiếu ứng " + SCT, "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        clsUngVatTuVanChuyen.UpdateDelete(_UNGVTID, null, null);
                        LoadDuLieuUng(_XEID);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn phiếu ứng để xóa!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            if ((_HDVCID > 0) && (_XEID > 0))
            {
                MDForms.VanChuyen.frm_ThemSuaUngVanChuyen frm = new VanChuyen.frm_ThemSuaUngVanChuyen(_HDVCID, _XEID, _SOXE, dtNgayUng.Value);
                frm.ShowDialog();
                if (frm.UVTID > 0)
                {
                    LoadDuLieuUng(_XEID);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn được xe để thêm phiếu ứng!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmd_Add_News_Click(object sender, EventArgs e)
        {


        }

        private void btn_DSKHMoi_Click(object sender, EventArgs e)
        {
            Load_gdDSUngTienVanChuyenMoi();
        }
        // load dữ liệu mới, đã kiểm tra , đã duyện
        private void Load_gdDSUngTienVanChuyenMoi()
        {
            string sql = @"             
                  Where KHTM.VuTrongID= " + MDSolutionApp.VuTrongID.ToString() + " AND KHTM.Status= 1  AND KHTM.NgayUng Between " + DBModule.RefineDatetime(dtNgayUngTu.Value, true) + " AND " + DBModule.RefineDatetime(dtNgayUngDen.Value, true) + " order by KHTM.ID DESC"; 
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdThietLapUngVanChuyen.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdThietLapUngVanChuyen.DataSource = null;
            }
        }

        // Duyet tiếp tục
        private void Load_gdDSUngTienVanChuyenDuyet()
        {
            string sql = @" SELECT * 
                  FROM     V_QuyTrinhUngVanChuyen             
                  Where V_QuyTrinhUngVanChuyen.VuTrongID= " + MDSolutionApp.VuTrongID.ToString() + " AND V_QuyTrinhUngVanChuyen.Status= 1 AND V_QuyTrinhUngVanChuyen.Xoa=0  AND V_QuyTrinhUngVanChuyen.NgayUng Between " + DBModule.RefineDatetime(dtNgayUngTu.Value, true) + " AND " + DBModule.RefineDatetime(dtNgayUngDen.Value, true) + " order by V_QuyTrinhUngVanChuyen.ID DESC";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdThietLapUngVanChuyen.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdThietLapUngVanChuyen.DataSource = null;
            }
        }

        private void Load_gdDuyetUngVanChuyen()
        {
            string sql = @" SELECT * 
                  FROM     V_QuyTrinhUngVanChuyen             
                  Where V_QuyTrinhUngVanChuyen.VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " AND V_QuyTrinhUngVanChuyen.Status= 2 AND V_QuyTrinhUngVanChuyen.Xoa=0  AND V_QuyTrinhUngVanChuyen.NgayUng Between " + DBModule.RefineDatetime(dtNgayUngTu_Duyet.Value, true) + " AND " + DBModule.RefineDatetime(dtNgayUngDen_Duyet.Value, true);
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDuyetUngVanChuyen.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdDuyetUngVanChuyen.DataSource = null;
            }
        }
        private void Load_gdTaiChinhDuyetUngVanChuyen()
        {
            string sql = @" SELECT * 
                  FROM     V_QuyTrinhUngVanChuyen             
                  Where V_QuyTrinhUngVanChuyen.VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " AND V_QuyTrinhUngVanChuyen.Status= 3 AND V_QuyTrinhUngVanChuyen.Xoa=0  AND V_QuyTrinhUngVanChuyen.NgayUng Between " + DBModule.RefineDatetime(dtNgayUngTu_TCDuyet.Value, true) + " AND " + DBModule.RefineDatetime(dtNgayUngDen_TCDuyet.Value, true) + " order by V_QuyTrinhUngVanChuyen.ID DESC";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdTaiChinhDuyetUngVanChuyen.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdTaiChinhDuyetUngVanChuyen.DataSource = null;
            }
        }
        private void Load_gdTaiChinhXacNhanUngVanChuyen()
        {
            string sql = @" SELECT * 
                  FROM     V_QuyTrinhUngVanChuyen             
                  Where V_QuyTrinhUngVanChuyen.VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " AND V_QuyTrinhUngVanChuyen.Status= 4 AND V_QuyTrinhUngVanChuyen.Xoa=0  AND V_QuyTrinhUngVanChuyen.NgayUng Between " + DBModule.RefineDatetime(dtNgayUngTu_TCXN.Value, true) + " AND " + DBModule.RefineDatetime(dtNgayUngDen_TCXN.Value, true) + " order by V_QuyTrinhUngVanChuyen.ID DESC";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdTaiChinhXacNhanUngVanChuyen.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdTaiChinhXacNhanUngVanChuyen.DataSource = null;
            }
        }

        private void cmd_TimTL_Click(object sender, EventArgs e)
        {
            Load_gdDSUngTienVanChuyenDuyet();
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlDelete = "Delete From tbl_Temp_Import_Excel_KeHoachUngVanChuyen Where  VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
                DBModule.ExecuteNonQuery(sqlDelete, null, null);
                if (openFileDialog_Excel.ShowDialog() == DialogResult.OK)////Mở file excel nguồn
                {
                    string TenFile = openFileDialog_Excel.FileName;
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
                        string LoaiVatTu = "";
                        string SoChungTu = "";
                        string MaHopDong = "";
                        string HoTen = "";
                        string TenDot = "";
                        string GhiChu = "";
                        string Errors = "";
                        string ErrorsIn = "";
                        Decimal SL = 0;
                        Decimal DG = 0;
                        Decimal ST = 0;
                        string HopDongID = "-1";
                        string LoaiVatTuID = "-1";
                        string BangChu = "";
                        Object element = new Object();
                        string sqlValue = "Values(" + MDSolutionApp.VuTrongID.ToString() + ",";
                        for (int b = 1; b <= 10; b++)//Với mỗi cột
                        {
                            try
                            {
                                element = myValues.GetValue(a, b);//Lấy dữ liệu ô excel
                            }
                            catch
                            {
                                element = DBNull.Value;
                            }
                            if (b == 1)//Loại vật tư
                            {
                                try
                                {
                                    LoaiVatTu = element.ToString();
                                }
                                catch
                                {
                                    LoaiVatTu = "";
                                }
                                sqlValue = sqlValue + "N'" + LoaiVatTu + "',";
                            }
                            if (b == 2)//Số chứng từ
                            {
                                try
                                {
                                    SoChungTu = element.ToString();
                                }
                                catch
                                {
                                    SoChungTu = "";
                                }
                                sqlValue = sqlValue + "N'" + SoChungTu + "',";
                            }
                            if (b == 3)//Tên đợt ứng
                            {
                                try
                                {
                                    TenDot = element.ToString();
                                }
                                catch
                                {
                                    TenDot = "";
                                }
                                sqlValue = sqlValue + "N'" + TenDot + "',";
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
                            if (b == 5)//Họ tên hợp đồng
                            {
                                try
                                {
                                    HoTen = element.ToString();
                                }
                                catch
                                {
                                    HoTen = "";
                                }
                                sqlValue = sqlValue + "N'" + HoTen + "',";
                            }
                            if (b == 6)//Số lượng
                            {
                                try
                                {
                                    SL = decimal.Parse(element.ToString().Replace(" ", ""));
                                    if (SL < 0)
                                    {
                                        SL = 0;
                                        ErrorsIn = ErrorsIn + "Sai dữ liệu số lượng. ";
                                    }
                                }
                                catch
                                {
                                    ErrorsIn = ErrorsIn + "Sai dữ liệu số lượng. ";
                                }
                                sqlValue = sqlValue + DBModule.RefineNumber(SL) + ",";
                            }
                            if (b == 7)//Đơn giá
                            {
                                try
                                {
                                    DG = decimal.Parse(element.ToString().Replace(" ", ""));
                                    if (DG < 0)
                                    {
                                        DG = 0;
                                        ErrorsIn = ErrorsIn + "Sai dữ liệu đơn giá. ";
                                    }
                                }
                                catch
                                {
                                    ErrorsIn = ErrorsIn + "Sai dữ liệu số đơn giá. ";
                                }
                                sqlValue = sqlValue + DBModule.RefineNumber(DG) + ",";
                            }
                            if (b == 8)//Số tiền
                            {
                                try
                                {
                                    ST = decimal.Parse(element.ToString().Replace(" ", ""));
                                    if (ST <= 0)
                                    {
                                        ST = 0;
                                        ErrorsIn = ErrorsIn + "Sai dữ liệu số tiền. ";
                                    }
                                    else
                                    {
                                        BangChu = Utils.DocSo(double.Parse(ST.ToString()));
                                    }
                                }
                                catch
                                {
                                    ErrorsIn = ErrorsIn + "Sai dữ liệu số tiền. ";
                                }
                                sqlValue = sqlValue + DBModule.RefineNumber(ST) + "," + "N'" + BangChu + "',";
                            }
                            if (b == 9)//Ngày ứng
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
                                    ErrorsIn += "Sai ngày ứng. ";
                                }
                                if (dateTime != "1900-01-01")
                                {
                                    sqlValue = sqlValue + "'" + dateTime + "',";
                                }
                                else
                                {
                                    ErrorsIn = ErrorsIn + "Sai ngày ứng.";
                                }
                            }
                            if (b == 10)// Ghi chú
                            {
                                try
                                {
                                    GhiChu = element.ToString();
                                }
                                catch
                                {
                                    GhiChu = " ";
                                }
                                sqlValue = sqlValue + "N'" + GhiChu + "'";
                            }

                        }
                        if ((string.IsNullOrEmpty(HoTen)) && (string.IsNullOrEmpty(MaHopDong)))
                        {
                            continue;
                        }
                        //string sqlCheck = " sp_Check_Import_DienTich " + _CBNVID + ",N'" + MaHopDong + "',N'" + TenThon + "',N'" + TenBai + "',N'" + LoaiDat + "',N'" + LoaiGiong + "',N'" + KieuTrong + "'";
                        string sqlCheck = " select * from tbl_HopDongVanChuyen where MaHopDong like '" + MaHopDong + "' AND VutrongID =" + MDSolutionApp.VuTrongID.ToString();
                        DataSet ret = null;
                        try
                        {
                            ret = DBModule.ExecuteQuery(sqlCheck, null, null);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("lỗi không có mã hợp đông : " + MaHopDong);
                        }
                        if (ret.Tables[0].Rows.Count > 0)
                        {

                            if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["ID"].ToString()))
                            {
                                HopDongID = ret.Tables[0].Rows[0]["ID"].ToString();

                            }
                            else
                            {
                                HopDongID = "-1";
                                Errors = Errors + "Sai dữ liệu Mã/Tên hợp đồng. ";
                            }
                            if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["TenChuHopDong"].ToString()))
                            {
                                if (ret.Tables[0].Rows[0]["TenChuHopDong"].ToString().Replace(" ", "") != HoTen.Replace(" ", ""))
                                {
                                    Errors = Errors + "Sai dữ liệu Mã/Tên hợp đồng. ";
                                }
                            }
                            else
                            {
                                Errors = Errors + "Sai dữ liệu Mã/Tên hợp đồng. ";
                            }
                        }
                        else
                        {
                            Errors = "Chưa đủ dữ liệu để đối sánh. ";
                        }
                        // kiêm tra loại vật tư
                        string sqlCheckVatTu = " select * from tbl_VatTuVanChuyen where Ten like N'%" + LoaiVatTu.Trim() + "%'";
                        DataSet retVatTu = null;
                        try
                        {
                            retVatTu = DBModule.ExecuteQuery(sqlCheckVatTu, null, null);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("lỗi không có mã hợp đông : " + LoaiVatTu);
                        }
                        if (retVatTu.Tables[0].Rows.Count > 0)
                        {

                            if (!string.IsNullOrEmpty(retVatTu.Tables[0].Rows[0]["ID"].ToString()))
                            {
                                LoaiVatTuID = retVatTu.Tables[0].Rows[0]["ID"].ToString();
                            }
                            else
                            {
                                LoaiVatTuID = "-1";
                                Errors = Errors + "Sai dữ liệu vật tư ";
                            }
                            if (!string.IsNullOrEmpty(retVatTu.Tables[0].Rows[0]["Ten"].ToString()))
                            {
                                if (retVatTu.Tables[0].Rows[0]["Ten"].ToString().Replace(" ", "") != LoaiVatTu.Replace(" ", ""))
                                {
                                    Errors = Errors + "Sai dữ liệu vật tư ";
                                }
                            }
                            else
                            {
                                Errors = Errors + "Sai dữ liệu vật tư ";
                            }
                        }
                        else
                        {
                            Errors = "Chưa đủ dữ liệu để đối sánh. ";
                        }
                        /////Ghi dữ liệu vào bảng tạm

                        string sqlInsert = @"INSERT INTO [dbo].[tbl_Temp_Import_Excel_KeHoachUngVanChuyen] (VuTrongID,LoaiVatTu,SoChungTu,[TenDot],[MaHopDong],HoTen,SoLuong,[DonGia],[Sotien],BangChu,[NgayUng],[GhiChu],[CreatedByUserID],[DateAdd], [HopDongID],Errors,LoaiVatTuID,Status) "
                            + sqlValue + "," + MDSolutionApp.User.ID.ToString() + ",GetDate()," + HopDongID + ",N'" + Errors + ErrorsIn + "'," + LoaiVatTuID + ",1)";
                        try
                        {
                            DBModule.ExecuteNonQuery(sqlInsert, null, null);
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                        }
                    }

                    xlWorkBook.Close(true, missing, missing);
                    xlApp.Quit();
                    MDSolution.MDForms.UngTien.frm_Temp_Import_UngVanChuyen frm = new MDForms.UngTien.frm_Temp_Import_UngVanChuyen(TenFile);
                    frm.ShowDialog();
                    if (frm.OK > 0)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi ngoại lệ xảy ra!\nBạn cần xem lại dữ liệu file Excel\n" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cmd_TimDuyet_Click(object sender, EventArgs e)
        {
            Load_gdDuyetUngVanChuyen();
        }

        private void cmd_Tim_TCDuyet_Click(object sender, EventArgs e)
        {
            Load_gdTaiChinhDuyetUngVanChuyen();
        }

        private void cmd_Tim_XacNhan_Click(object sender, EventArgs e)
        {
            Load_gdTaiChinhXacNhanUngVanChuyen();
        }

        private void cmd_DuyetTL_Click(object sender, EventArgs e)
        {
            string sids = "";
            foreach (Janus.Windows.GridEX.GridEXRow r in gdThietLapUngVanChuyen.GetCheckedRows())
            {
                if (!string.IsNullOrEmpty(sids)) sids += ",";
                sids += r.Cells["ID"].Value;
            }
            if (sids != "")
            {
                string sql = @"UPDATE [tbl_KeHoachUngVanChuyen]
                               SET 
                             Status = 3,
                             DateChecked     =GETDATE(),
                             CheckedByUserID  ={1}
                             WHERE ID in ({0});";
                DBModule.ExecuteNonQuery(string.Format(sql, sids, MDSolutionApp.User.ID.ToString()), null, null);
                MessageBox.Show("Đã duyệt các phiếu thành công", "Thông báo");
                Load_gdDSUngTienVanChuyenDuyet();
            }
            else
            {
                MessageBox.Show("Bạn cần phải chọn", "Thông báo");
            }
        }

        private void gdThietLapUngVanChuyen_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "Print")
            {
                try
                {
                    string ID = gdThietLapUngVanChuyen.GetValue("ID").ToString();
                    string sql = " Select  * From V_QuyTrinhUngVanChuyen Where ID=" + ID;
                    DataSet ds = null;
                    ds = DBModule.ExecuteQuery(sql, null, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MDSolution.MDForms.frmShowRP2 frm2 = new MDSolution.MDForms.frmShowRP2();
                        MDSolution.MDReport.KeHoachUngVatTuVanChuyen rp = new MDSolution.MDReport.KeHoachUngVatTuVanChuyen();
                        rp.SetDataSource(ds.Tables[0]);
                        frm2.RP = rp;
                        frm2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Không có phiếu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra! Bạn thực hiện lại lệnh In phiếu!" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            if (e.Column.Key == "Modify")
            {
                if ((_HDVCID > 0) && (_XEID > 0))
                {
                    long NguoiNhapID=0;
                    try
                    {
                        _UNGVTID = long.Parse(this.gdThietLapUngVanChuyen.GetValue("ID").ToString());
                        NguoiNhapID = long.Parse(this.gdThietLapUngVanChuyen.GetValue("NguoiNhapID").ToString());
                    }
                    catch
                    {
                        _UNGVTID = -1;
                    }
                    if (_UNGVTID > 0 && (MDSolutionApp.User.ID==1 || MDSolutionApp.User.ID==NguoiNhapID) )
                    {
                        MDForms.UngTien.frm_ThemSuaUngVanChuyen frm = new UngTien.frm_ThemSuaUngVanChuyen(_UNGVTID, "");
                        frm.ShowDialog();
                        if (frm.OK > 0)
                        {
                            Load_gdDSUngTienVanChuyenDuyet();
                            GridEXFilterCondition condi = new GridEXFilterCondition(this.gdThietLapUngVanChuyen.RootTable.Columns["ID"], ConditionOperator.Equal, _UNGVTID);
                            this.gdThietLapUngVanChuyen.FindAll(condi);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn phiếu ứng để sửa!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.Column.Key == "Delete")
            {
                if ((_HDVCID > 0) && (_XEID > 0))
                {
                    long NguoiNhapID = 0;
                    string SCT = "";
                    try
                    {
                        _UNGVTID = long.Parse(this.gdThietLapUngVanChuyen.GetValue("ID").ToString());
                        SCT = this.gdThietLapUngVanChuyen.GetValue("SoChungTu").ToString();
                        NguoiNhapID = long.Parse(this.gdThietLapUngVanChuyen.GetValue("NguoiNhapID").ToString());
                    }
                    catch
                    {
                        _UNGVTID = -1;
                    }
                    if (_UNGVTID > 0 && (MDSolutionApp.User.ID == 1 || MDSolutionApp.User.ID == NguoiNhapID))
                    {
                        if (MessageBox.Show("Bạn chắc chắn xóa phiếu ứng " + SCT, "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        string sql = @"UPDATE tbl_KeHoachUngVanChuyen SET Xoa=1  WHERE ID =" + _UNGVTID;                             
                        DBModule.ExecuteNonQuery(sql, null, null);
                        //clsKeHoachUngVanChuyen.Delete(_UNGVTID, null, null);
                        //Load_gdDSUngTienVanChuyenDuyet();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn phiếu ứng để xóa!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmd_DongTL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmd_ExcelTL_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = gdThietLapUngVanChuyen;
                        exporter.Export(fs);
                        fs.Close();
                        MessageBox.Show("Đã export ra file excel!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi khi export!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_XacNhanDuyet_Click(object sender, EventArgs e)
        {

        }

        private void btn_BackDuyet_Click(object sender, EventArgs e)
        {
            string sids = "";
            foreach (Janus.Windows.GridEX.GridEXRow r in gdDuyetUngVanChuyen.GetCheckedRows())
            {
                if (!string.IsNullOrEmpty(sids)) sids += ",";
                sids += r.Cells["ID"].Value;
            }
            if (sids != "")
            {
                string sql = @"UPDATE [tbl_KeHoachUngVanChuyen]
                               SET 
                             Status = 1,
                             DateModify =GETDATE(),
                             ModifyByUserID  ={1}
                             WHERE ID in ({0});";
                string xx = string.Format(sql, sids, MDSolutionApp.User.ID.ToString());
                DBModule.ExecuteNonQuery(string.Format(sql, sids, MDSolutionApp.User.ID.ToString()), null, null);
                MessageBox.Show("Đã duyệt các phiếu thành công", "Thông báo");
                Load_gdDuyetUngVanChuyen();
            }
            else
            {
                MessageBox.Show("Bạn cần phải chọn", "Thông báo");
            }
        }

        private void btn_DuyetDuyet_Click(object sender, EventArgs e)
        {
            string sids = "";
            foreach (Janus.Windows.GridEX.GridEXRow r in gdDuyetUngVanChuyen.GetCheckedRows())
            {
                if (!string.IsNullOrEmpty(sids)) sids += ",";
                sids += r.Cells["ID"].Value;
            }
            if (sids != "")
            {
                string sql = @"UPDATE [tbl_KeHoachUngVanChuyen]
                               SET 
                             Status = 3,
                             NgayDuyet =GETDATE(),
                             NguoiDuyet={1}
                             WHERE ID in ({0});";
                DBModule.ExecuteNonQuery(string.Format(sql, sids, MDSolutionApp.User.ID.ToString()), null, null);
                MessageBox.Show("Đã duyệt các phiếu thành công", "Thông báo");
                Load_gdDuyetUngVanChuyen();
            }
            else
            {
                MessageBox.Show("Bạn cần phải chọn", "Thông báo");
            }
        }

        private void cmd_ExcelDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                using (var fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                {
                    var exporter = new Janus.Windows.GridEX.Export.GridEXExporter
                    {
                        ExportMode = Janus.Windows.GridEX.ExportMode.AllRows,
                        GridEX = gdThietLapUngVanChuyen
                    };
                    exporter.Export(fs);
                }
                MessageBox.Show("Đã export ra file excel!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi export:", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmd_DongDuyet_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmd_TC_BackDuyet_Click(object sender, EventArgs e)
        {
            string sids = "";
            foreach (Janus.Windows.GridEX.GridEXRow r in gdTaiChinhDuyetUngVanChuyen.GetCheckedRows())
            {
                if (!string.IsNullOrEmpty(sids)) sids += ",";
                sids += r.Cells["ID"].Value;
            }
            if (sids != "")
            {
                string sql = @"UPDATE [tbl_KeHoachUngVanChuyen]
                               SET 
                             Status = 1,
                             DateModify     =GETDATE(),
                             ModifyByUserID  ={1}
                             WHERE ID in ({0});";
                DBModule.ExecuteNonQuery(string.Format(sql, sids, MDSolutionApp.User.ID.ToString()), null, null);
                MessageBox.Show("Đã duyệt các phiếu thành công", "Thông báo");
                Load_gdTaiChinhDuyetUngVanChuyen();
            }
            else
            {
                MessageBox.Show("Bạn cần phải chọn", "Thông báo");
            }
        }

        private void cmd_TCDuyet_Click(object sender, EventArgs e)
        {
            string sids = "";
            foreach (Janus.Windows.GridEX.GridEXRow r in gdTaiChinhDuyetUngVanChuyen.GetCheckedRows())
            {
                if (!string.IsNullOrEmpty(sids)) sids += ",";
                sids += r.Cells["ID"].Value;
            }
            if (sids != "")
            {
                string sql = @"UPDATE [tbl_KeHoachUngVanChuyen]
                               SET 
                             Status = 4,
                             Ngay_TC_Duyet =GETDATE(),
                             Nguoi_TC_Duyet={1}
                             WHERE ID in ({0});";
                DBModule.ExecuteNonQuery(string.Format(sql, sids, MDSolutionApp.User.ID.ToString()), null, null);
                MessageBox.Show("Đã duyệt các phiếu thành công", "Thông báo");
                Load_gdTaiChinhDuyetUngVanChuyen();
            }
            else
            {
                MessageBox.Show("Bạn cần phải chọn", "Thông báo");
            }
        }

        private void cmd_ExcelTC_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                using (var fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                {
                    var exporter = new Janus.Windows.GridEX.Export.GridEXExporter
                    {
                        ExportMode = Janus.Windows.GridEX.ExportMode.AllRows,
                        GridEX = gdTaiChinhDuyetUngVanChuyen
                    };
                    exporter.Export(fs);
                }
                MessageBox.Show("Đã export ra file excel!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi export:", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmd_TCDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmd_TCBack_Click(object sender, EventArgs e)
        {

            string sids = "";
            foreach (Janus.Windows.GridEX.GridEXRow r in gdTaiChinhXacNhanUngVanChuyen.GetCheckedRows())
            {
                if (!string.IsNullOrEmpty(sids)) sids += ",";
                sids += r.Cells["ID"].Value;
            }
            if (sids != "")
            {
                string sql = @"UPDATE [tbl_KeHoachUngVanChuyen]
                               SET 
                             Status = 3,
                             DateModify     =GETDATE(),
                             ModifyByUserID  ={1}
                             WHERE ID in ({0});";
                DBModule.ExecuteNonQuery(string.Format(sql, sids, MDSolutionApp.User.ID.ToString()), null, null);
                MessageBox.Show("Đã duyệt các phiếu thành công", "Thông báo");
                Load_gdTaiChinhXacNhanUngVanChuyen();
            }
            else
            {
                MessageBox.Show("Bạn cần phải chọn", "Thông báo");
            }
        }

        private void cmd_TCXacNhan_Click(object sender, EventArgs e)
        {
            string sids = "";
            foreach (Janus.Windows.GridEX.GridEXRow r in gdTaiChinhXacNhanUngVanChuyen.GetCheckedRows())
            {
                if (!string.IsNullOrEmpty(sids)) sids += ",";
                sids += r.Cells["ID"].Value;
            }
            if (sids != "")
            {
                try
                {
                    // export to tbl_UngVatTuVanChuyen
                    string sql = @"Update tbl_KeHoachUngVanChuyen set
                             Ngay_TC_XN = GETDATE(),
                             Status = 5,
                             Nguoi_TC_XN={1}
                             WHERE ID in ({0});";
                    DBModule.ExecuteNonQuery(string.Format(sql, sids, MDSolutionApp.User.ID.ToString()), null, null);
                    string sqlinsert = @"INSERT INTO [dbo].[tbl_UngVatTuVanChuyen]
                           ([HopDongVanChuyenID]
                           ,[XeID]
                           ,[VatTuID]
                           ,[SoLuong]
                           ,[DonGia]
                           ,[NgayUng]
                           ,[SoChungTu]
                           ,[DaThanhToan]
                           ,[VuTrongID]
                           ,[SoTien]
                           ,[GhiChu]
                           ,[NoiTamUngVatTuID]
                           ,[CreatedBy]
                           ,[ModifyBy]
                           ,[DateAdd]
                           ,[DataModify]
                           ,[NoteModify]
                           ,[Status]
                           ,[BangChu]
                           ,[Xoa])  
                   select HopDongID,(select ID from tbl_XeVanChuyen where HopDongVanChuyenID=HopDongID AND tbl_XeVanChuyen.VuTrongID=tbl_XeVanChuyen.VuTrongID) AS XeID,
                    LoaiVatTuID AS VatTuID,
                          SoLuong,
                          DonGia,
                          NgayUng,
                          SoChungTu,
                          0 AS DaThanhToan,
                          VuTrongID,
                          Sotien,
                          GhiChu,
                          0 AS NoiTamUngVatTuID,
                          Nguoi_TC_XN AS CreatedBy,
                          0 AS ModifyBy,
                          DateAdd,
                          NULL AS DataModify,
                          NoteModify,
                          NULL AS  Status,
                          BangChu,
                          0 AS Xoa
                   from tbl_KeHoachUngVanChuyen  WHERE ID in ({0}); ";
                    DBModule.ExecuteNonQuery(string.Format(sqlinsert, sids), null, null);
                    MessageBox.Show("Đã xác nhận các phiếu thành công", "Thông báo");
                    Load_gdTaiChinhXacNhanUngVanChuyen();
                }
                catch
                {
                    MessageBox.Show("Xác nhận các phiếu không thành công", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Bạn cần phải chọn", "Thông báo");
            }
        }

        private void cmd_TCExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                using (var fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                {
                    var exporter = new Janus.Windows.GridEX.Export.GridEXExporter
                    {
                        ExportMode = Janus.Windows.GridEX.ExportMode.AllRows,
                        GridEX = gdTaiChinhXacNhanUngVanChuyen
                    };
                    exporter.Export(fs);
                }
                MessageBox.Show("Đã export ra file excel!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi export:", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmd_TCXNDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tab_TamUngVanChuyen_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (e.Page.Index == 0)
            {
                dtNgayLap.Value = DateTime.Now;
                Load_gdDSUngTienVanChuyenDuyet();
                lbl_XNNL_Nhap.Text = "";
                string sqltab1 = @"select MIN(NgayUng) as NgayUng from  tbl_KeHoachUngVanChuyen where Status=1 and NgayUng<GETDATE();";
                try
                {
                    DataSet tb1 = DBModule.ExecuteQuery(sqltab1, null, null);
                    if (tb1 != null && tb1.Tables[0].Rows.Count >= 1)
                    {
                        DateTime datetime = (DateTime)tb1.Tables[0].Rows[0]["NgayUng"];
                        lbl_XNNL_Nhap.Text = " Kiểm tra từ ngày " + datetime.ToString("dd/MM/yyyy") + "\ncó phiếu chưa làm";
                    }
                }
                catch { }
            }
            else if (e.Page.Index == 1)
            {
                Load_gdDuyetUngVanChuyen();
                lbl_XNNL_ChuaDuyet.Text = "";
                string sqltab1 = @"select MIN(NgayUng) as NgayUng from  tbl_KeHoachUngVanChuyen where Status=2 and NgayUng<GETDATE();";
                try
                {
                    DataSet tb1 = DBModule.ExecuteQuery(sqltab1, null, null);
                    if (tb1 != null && tb1.Tables[0].Rows.Count >= 1)
                    {
                        DateTime datetime = (DateTime)tb1.Tables[0].Rows[0]["NgayUng"];
                        lbl_XNNL_ChuaDuyet.Text = " Kiểm tra từ ngày " + datetime.ToString("dd/MM/yyyy") + "\ncó phiếu chưa làm";
                    }
                }
                catch { }

            }
            else if (e.Page.Index == 2)
            {
                Load_gdTaiChinhDuyetUngVanChuyen();
                lbl_TaiChinh_ChuaDuyet.Text = "";
                string sqltab1 = @"select MIN(NgayUng) as NgayUng from  tbl_KeHoachUngVanChuyen where Status=3 and NgayUng < GETDATE();";
                try
                {
                    DataSet tb1 = DBModule.ExecuteQuery(sqltab1, null, null);
                    if (tb1 != null && tb1.Tables[0].Rows.Count >= 1)
                    {
                        DateTime datetime = (DateTime)tb1.Tables[0].Rows[0]["NgayUng"];
                        lbl_TaiChinh_ChuaDuyet.Text = " Kiểm tra từ ngày " + datetime.ToString("dd/MM/yyyy") + "\ncó phiếu chưa làm";
                    }
                }
                catch { }

            }
            else if (e.Page.Index == 3)
            {
                lbl_TaiChinh_ChuaXacNhan.Text = "";
                Load_gdTaiChinhXacNhanUngVanChuyen();
                string sqltab1 = @"select MIN(NgayUng) as NgayUng from  tbl_KeHoachUngVanChuyen where Status=4 and NgayUng<GETDATE();";
                try
                {
                    DataSet tb1 = DBModule.ExecuteQuery(sqltab1, null, null);
                    if (tb1 != null && tb1.Tables[0].Rows.Count >= 1)
                    {
                        DateTime datetime = (DateTime)tb1.Tables[0].Rows[0]["NgayUng"];
                        lbl_TaiChinh_ChuaXacNhan.Text = " Kiểm tra từ ngày " + datetime.ToString("dd/MM/yyyy") + "\ncó phiếu chưa làm";
                    }
                }
                catch { }

            }
            else if (e.Page.Index == 4)
            {
            }
        }

        private void cmdAddNew_Click(object sender, EventArgs e)
        {
            MDForms.UngTien.frm_KeHoachNhapUngVanChuyen frm = new UngTien.frm_KeHoachNhapUngVanChuyen(dtNgayLap.Value); //frm_NhapUngVanChuyenTemp(dtNgayUng.Value)
            frm.ShowDialog();
            if (frm.OK > 0)
            {
                Load_gdDSUngTienVanChuyenDuyet();               
            }
        }
    }
}