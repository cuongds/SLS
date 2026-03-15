using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using MDSolutionEntities;
using SLSCCSEntities;
using Janus.Windows.GridEX;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Globalization;
using MDSolution.MDReport.HoTro;
namespace MDSolution.MDForms.HoTro
{

    public partial class frm_ChietTinhHoTroDauTu : Form
    {
        public long ThanhToanNhanh = 0;
        public string strMaPhieu = "";
        public long trangthai = 0;
        # region
        decimal SoTienTru_HoTro_DauTu(string HopDongID, string VuTrongID)
        {
            string sqltruhotro = @"SELECT  SUM(dbo.tbl_HoTro_ChiTiet_TienLai.TongTra) AS TongTra, dbo.tbl_DauTu.HopDongID, 
                         dbo.tbl_DauTu.VuTrongID
                FROM            dbo.tbl_HoTro_ChiTiet_TienLai INNER JOIN
                                         dbo.tbl_DauTu ON dbo.tbl_HoTro_ChiTiet_TienLai.DauTuID = dbo.tbl_DauTu.ID
                GROUP BY dbo.tbl_DauTu.HopDongID, dbo.tbl_DauTu.VuTrongID  HAVING        (dbo.tbl_DauTu.VuTrongID =" + VuTrongID + ") AND (dbo.tbl_DauTu.HopDongID =" + HopDongID + ")";
            return decimal.Parse(DBModule.ExecuteQueryForOneResult(sqltruhotro, null, null));
        }
        decimal TinhLaiCoBan(decimal SoTien, DateTime NgayTra, DateTime NgayTinhLai, decimal LaiSuat)
        {
            if (LaiSuat == 0) return 0;
            int songay = (int)(NgayTra.Date - NgayTinhLai.Date).TotalDays;
            return Math.Round(SoTien * songay * LaiSuat / 30 / 100, 0, MidpointRounding.AwayFromZero);
        }
        void SonLa_HoTroDauTu(int HoTroID, DateTime NgayTT, long ThanhToanNhanh, bool isTruNoDauTu = true)
        {
            //1.Lấy thông tin hỗ trợ:
            string sql = "select HopDongID, MaHopDong,TenChuHo,SoCMT,NguoiThuaKe1Ten,Sum(ISNULL(SoLuong,0)) AS SoLuong, sum(ISNULL(SoTien,0)) AS SoTien,DiaChi,TenCBNV,KhauTru from V_DanhSach_HoTro  WHERE HopDongID= " + HoTroID + " AND VuTrongID= " + MDSolutionApp.VuTrongID.ToString() + " AND KhauTru <>1  Group by HopDongID, MaHopDong,TenChuHo,SoCMT,NguoiThuaKe1Ten,DiaChi,TenCBNV,KhauTru";
            DataTable dtNhaMia = DBModule.ExecuteQuery(sql, null, null).Tables[0];
            if (dtNhaMia.Rows.Count == 1)
            {
                DataRow drNhaMia = dtNhaMia.Rows[0];
                string HopDongID = drNhaMia["HopDongID"].ToString();
                //decimal SoLuongHT = decimal.Parse(drNhaMia["SoLuong"].ToString());
                decimal SoTienHT = 0;
                decimal SoTTHet = 0;
                if (ThanhToanNhanh == 1)
                {

                    SoTienHT = decimal.Parse(drNhaMia["SoTien"].ToString());
                    SoTTHet = decimal.Parse(drNhaMia["SoTien"].ToString());
                }
                else
                {
                    SoTienHT = decimal.Parse(frmEditTienTruNo.txtTienTru.Text);

                }
                //SoTienTruHoTro_Goc,SoTienTruHoTro_Lai

                sql = @"SELECT        dbo.tbl_HoTro_TruLai.ID AS HoTroID, dbo.V2016_DuNoDauTu.*
                         FROM            dbo.V2016_DuNoDauTu LEFT OUTER JOIN
                         dbo.tbl_HoTro_TruLai ON dbo.V2016_DuNoDauTu.ID = dbo.tbl_HoTro_TruLai.DauTuID where V2016_DuNoDauTu.SoTienTruHoTro_Goc>0 
                        AND V2016_DuNoDauTu.HopDongID={0}   AND V2016_DuNoDauTu.VuTrongID= " + MDSolutionApp.VuTrongID.ToString() + " ORDER BY  ThuTu, NgayDauTu";
                DataSet dsDauTu = DBModule.ExecuteQuery(string.Format(sql, HopDongID), null, null);
                //2.Lặp trên ds dư nợ để trừ nợ
                //Tong_TruDT += TienTruGoc;
                //Tong_TruDT_Lai += TienTruLai;
                //Tong_TienTruNo += TienTruLai + TienTruGoc;
                if (isTruNoDauTu)
                    foreach (DataRow dr in dsDauTu.Tables[0].Rows)
                    {
                        if (SoTienHT > 0)//Còn tiền trừ nợ
                        {
                            int DauTuID = (int)dr["ID"];

                            decimal SoTienTruHoTro_Goc = 0;

                            //if( dr["SoTienTruHoTro_Goc"].ToString != 'NULL' )

                            if (string.IsNullOrEmpty(dr["SoTienTruHoTro_Goc"].ToString()))
                            {

                            }
                            else
                            {
                                SoTienTruHoTro_Goc = decimal.Parse(dr["SoTienTruHoTro_Goc"].ToString());
                            }

                            decimal SoTienTruHoTro_Lai = 0;
                            if (string.IsNullOrEmpty(dr["SoTienTruHoTro_Lai"].ToString()))
                            {

                            }
                            else
                            {
                                SoTienTruHoTro_Lai = decimal.Parse(dr["SoTienTruHoTro_Lai"].ToString());
                            }

                            // cần tính trừ lãi phần này.

                            //  DateTime NgayDauTu = DateTime.Parse(dr["NgayDauTu"].ToString());

                            string dateTime = dr["NgayDauTu"].ToString();
                            string createddate = Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd");
                            //DateTime NgayDauTu = DateTime.ParseExact(createddate, "yyyy-MM-dd HH:mm tt", CultureInfo.InvariantCulture);

                            DateTime NgayDauTu = DateTime.ParseExact(createddate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            // kiểm tra date

                            DateTime NgayDauTuTruHoTro = DateTime.Parse(dt_NgayChotLaiHoTro.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                            TimeSpan Time = NgayDauTuTruHoTro - NgayDauTu;
                            int SoNgayTinhLai = Time.Days;
                            decimal LaiSuat = decimal.Parse(dr["LaiSuat"].ToString());
                            decimal TienHoTroTruNo = 0;
                            decimal TienCapNhatDauTu = 0;


                            //Trừ lãi trước:
                            decimal TienTruLai = 0;
                            if (SoTienHT >= SoTienTruHoTro_Lai)
                            {

                                TienTruLai = SoTienTruHoTro_Lai;
                            }
                            else
                            {
                                continue;
                               // TienTruLai = SoTienHT;
                            }
                            TienHoTroTruNo = SoTienHT - TienTruLai;

                            //Còn để trừ gốc
                            decimal TienTruGoc = 0;
                            if (TienHoTroTruNo > 0)
                            {
                                if (TienHoTroTruNo >= SoTienTruHoTro_Goc)
                                {
                                    TienTruGoc = SoTienTruHoTro_Goc;
                                }
                                else
                                {
                                    TienTruGoc = TienHoTroTruNo;
                                }
                            }
                            TienHoTroTruNo = TienTruGoc + TienTruLai;
                            // chỉnh
                            // kiểm tra số tiền lãi



                            SoTienHT -= TienHoTroTruNo;
                            sql = @"INSERT INTO [tbl_HoTro_ChiTiet_TienLai]
                                               ([DauTuID]
                                               ,[TuNgay]
                                               ,[DenNgay]
                                               ,[GocTinhLai]
                                               ,[LaiSuat]
                                               ,[TienLai]
                                               ,[TongTra],HoTroNhapTienID,NhapTienHoTro,SoNgayTinhLai,VuTrongID)
                                         VALUES
                                               ({0}
                                               ,{1}
                                               ,'{2}'
                                               ,{3}
                                               ,{4}
                                               ,{5}
                                               ,{6},{7},{8},{9},{10})";
                            DBModule.ExecuteNonQuery(string.Format(sql, DBModule.RefineNumber(DauTuID), DBModule.RefineDatetime(NgayDauTu)
                                , dt_NgayChotLaiHoTro.Value.ToString("yyyy-MM-dd HH:mm:ss"), DBModule.RefineNumber(TienTruGoc), DBModule.RefineNumber(LaiSuat), DBModule.RefineNumber(TienTruLai)
                                , TienHoTroTruNo, 0, 0, DBModule.RefineNumber(SoNgayTinhLai), MDSolutionApp.VuTrongID), null, null);
                            // cập nhật lại bảng đâu tư

                            if (SoTienHT == 0)
                            {
                                TienCapNhatDauTu = (SoTienTruHoTro_Goc + SoTienTruHoTro_Lai) - TienHoTroTruNo;
                            }
                            string sqlCapNhaLaiDauTu = @"UPDATE [dbo].[tbl_DauTu]
                                                                           SET 
                                                                              [SoTien] = {0}
                                                                              ,[NgayDauTu] = '{1}'
                                                                              ,[GhiChuHoTro] = {2}                                                                                                                                                           
                                                                              ,[NgayDauTuTruHoTro] = {3}
                                                                              ,[DaLamHoTro] = {4} 
                                                                                Where ID={5};";
                          trangthai = DBModule.ExecuteNonQuery(string.Format(sqlCapNhaLaiDauTu, DBModule.RefineNumber(TienCapNhatDauTu), dt_NgayChotLaiHoTro.Value.ToString("yyyy-MM-dd HH:mm:ss"), "N'Đã trừ hỗ trợ'", "getdate()", ChietTinhID, DBModule.RefineNumber(DauTuID)), null, null);
                            // cập nhật lại bảng hỗ trợ.

                            string sqlCapNhatHoTro = @"Update [dbo].[tbl_HoTro] SET KhauTru=1,HoTroID=" + ChietTinhID + " where HopDongID=" + HopDongID;
                            DBModule.ExecuteNonQuery(sqlCapNhatHoTro, null, null);
                        }
                        else
                        {
                            break;
                        }                      
                    }
                /// cập nhật số phiếu và người làm
                if (ThanhToanNhanh == 1 && trangthai > 0 && frm.DialogResult   == System.Windows.Forms.DialogResult.OK)
                {
                    // thêm vào số phiếu 
                    string stt = DBModule.ExecuteQueryForOneResult("Get_MaPhieu 'tbl_HoTro_ChietTinhCongNo', " + MDSolutionApp.VuTrongID, null, null);
                    DateTime dt = (DateTime)DBModule.ExecuteQuery("Select NgayBatDau from tbl_VuTrong where ID=" + MDSolutionApp.VuTrongID, null, null).Tables[0].Rows[0][0];
                    strMaPhieu = "DTHT" + dt.Year.ToString("###") + "_";
                    strMaPhieu = strMaPhieu + stt.PadLeft(6, '0');
                    //kêt thúc số phiếu
                    try
                    {

                        string sqldoitru = string.Format("sp_tbl_HoTro_ChietTinhDauTu N'{0}', N'{1}', {2},{3},{4},N'{5}'", MDSolutionApp.User.UserName, frm.txtGhiChu.Text, DBModule.RefineNumber(MDSolutionApp.VuTrongID), DBModule.RefineNumber(SoTTHet), HopDongID, strMaPhieu);
                       DBModule.ExecuteQueryForOneResult(sqldoitru, null, null);
                        // chưa làm
                       string maxma = @"select ID from tbl_HoTro_ChietTinhCongNo where HopDongID=" + HopDongID + "and  VuTrongID=" + MDSolutionApp.VuTrongID;
                       string Chiettinh = DBModule.ExecuteQueryForOneResult(maxma, null, null);

                       string sqlCapNhatHoTro = @"Update [dbo].[tbl_HoTro] SET KhauTru=1,HoTroID=" + Chiettinh + " where HopDongID=" + HopDongID;
                       DBModule.ExecuteNonQuery(sqlCapNhatHoTro, null, null);
                        //string sqlcap = string.Format("Update tbl_HoTro SET TienTruNoDauTu ={0} where ID={1}", tientru, this.ID);
                        //DBModule.ExecuteNonQuery(sql, null, null);
                        //this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        //this.Close();
                    }
                    catch { }

                }
               
            }
        }

        #endregion

        static frm_ChietTinhHoTroDauTu _frm_ChietTinhHoTroDauTu;
        private void Load_Cb_cboCBNV()
        {
            string sql = "select * from tbl_DanhMucCanBoNongVu";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboCBNV.DataSource = ds.Tables[0];
                cboCBNV.ValueMember = "ID";
                cboCBNV.DisplayMember = "Ten";
            }
            else
            {
                cboCBNV.DataSource = null;
            }
        }
        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_ChietTinhHoTroDauTu OneInstanceFrm
        {
            get
            {
                if (null == _frm_ChietTinhHoTroDauTu || _frm_ChietTinhHoTroDauTu.IsDisposed)
                {
                    _frm_ChietTinhHoTroDauTu = new frm_ChietTinhHoTroDauTu();
                }

                return _frm_ChietTinhHoTroDauTu;
            }
        }

        public frm_ChietTinhHoTroDauTu()
        {
            InitializeComponent();
            Load_Cb_cboCBNV();
            try
            {
                NgayChotTinhLaiHoTro();
            }
            catch { MessageBox.Show("Chưa nhập ngày chốt lãi hỗ trợ"); }
        }

        DataSet HotroCols;

        void NgayChotTinhLaiHoTro()
        {
            clsVuTrong oVT = new clsVuTrong(MDSolutionApp.VuTrongID);
            oVT.Load(null, null);
            dt_NgayChotLaiHoTro.Value = oVT.NgayChotHoTro;


        }
        void CreateHoTroCols()
        {
            int hotroColIndex = grvNhapMia.RootTable.Columns["HoTro"].Index;
            string sql = "SELECT distinct [SoTB]FROM [tbl_NhapMia_HoTro] where PhanNhomID=0 ";
            HotroCols = DBModule.ExecuteQuery(sql, null, null);
            foreach (DataRow dr in HotroCols.Tables[0].Rows)
            {
                GridEXColumn col = new GridEXColumn(dr[0].ToString());
                col.Caption = dr[0].ToString();
                col.EditType = EditType.NoEdit;
                col.FormatString = grvNhapMia.RootTable.Columns["HoTro"].FormatString;
                col.TextAlignment = grvNhapMia.RootTable.Columns["HoTro"].TextAlignment;
                col.BoundMode = ColumnBoundMode.Unbound;
                col.AggregateFunction = AggregateFunction.Sum;
                col.TotalFormatString = grvNhapMia.RootTable.Columns["HoTro"].TotalFormatString;

                grvNhapMia.RootTable.Columns.Insert(hotroColIndex, col);

            }
        }
        void CreateHoTroColsDaChietTinh()
        {
            int hotroColIndex = grvDaChietTinh.RootTable.Columns["HoTro"].Index;
            string sql = "SELECT distinct [SoTB]FROM [tbl_NhapMia_HoTro] where PhanNhomID=0 ";
            HotroCols = DBModule.ExecuteQuery(sql, null, null);
            foreach (DataRow dr in HotroCols.Tables[0].Rows)
            {
                GridEXColumn col = new GridEXColumn(dr[0].ToString());
                col.Caption = dr[0].ToString();
                col.EditType = EditType.NoEdit;
                col.FormatString = grvDaChietTinh.RootTable.Columns["HoTro"].FormatString;
                col.TextAlignment = grvDaChietTinh.RootTable.Columns["HoTro"].TextAlignment;
                col.BoundMode = ColumnBoundMode.Unbound;
                col.AggregateFunction = AggregateFunction.Sum;
                col.TotalFormatString = grvDaChietTinh.RootTable.Columns["HoTro"].TotalFormatString;

                grvDaChietTinh.RootTable.Columns.Insert(hotroColIndex, col);

            }
        }

        string sqlGetHoTro = @"SELECT SUM(SoTien) AS SoTien
                                                FROM         dbo.tbl_NhapMia_HoTro
                                                GROUP BY SoTB, NhapMiaID,PhanNhomID
                                                HAVING      (PhanNhomID=0 and NhapMiaID = {0} and SoTB='{1}');";
        void LoadHoTro()
        {
            // load hỗ trợ
            //string sql = "select HopDongID, MaHopDong,TenChuHo,SoCMT,NguoiThuaKe1Ten,Sum(ISNULL(SoLuong,0)) AS SoLuong, sum(ISNULL(SoTien,0)) AS SoTien,DiaChi,TenCBNV,KhauTru from V_DanhSach_HoTro  WHERE ngaylamhotro BETWEEN " + DBModule.RefineDatetime(this.dtTuNgay.Value) + " AND " + DBModule.RefineDatetime(this.dtChotChietTinh.Value) + " AND VuTrongID= " + MDSolutionApp.VuTrongID.ToString() + " AND KhauTru<>1  Group by HopDongID, MaHopDong,TenChuHo,SoCMT,NguoiThuaKe1Ten,DiaChi,TenCBNV,KhauTru";
            //sql = string.Format(sql, this.dtTuNgay.IsNullDate ? "Null" : DBModule.RefineDatetime(this.dtTuNgay.Value), this.dtChotChietTinh.IsNullDate ? "Null" : DBModule.RefineDatetime(this.dtChotChietTinh.Value), MDSolutionApp.VuTrongID.ToString());

            string sql = "select HopDongID, MaHopDong,TenChuHo,SoCMT,NguoiThuaKe1Ten,Sum(ISNULL(SoLuong,0)) AS SoLuong, sum(ISNULL(SoTien,0)) AS SoTien,DiaChi,TenCBNV,KhauTru from V_DanhSach_HoTro  WHERE  VuTrongID= " + MDSolutionApp.VuTrongID.ToString() + " AND KhauTru<>1  Group by HopDongID, MaHopDong,TenChuHo,SoCMT,NguoiThuaKe1Ten,DiaChi,TenCBNV,KhauTru";
            sql = string.Format(sql, MDSolutionApp.VuTrongID.ToString());

            grvNhapMia.SetDataBinding(DBModule.ExecuteQuery(sql, null, null).Tables[0], "");

        }
        void LoadHoTro_DaChietTinh()
        {
            //isDaChietTinhLoaded = true;
            //Tìm kiếm tất cả nhập mía của hđ đầu tư./
            //            string sql = @"SELECT   dbo.tbl_HopDong.ID AS HopDongID, tbl_HoTro_ChietTinhCongNo.ID,  dbo.tbl_HopDong.SoCMT,   dbo.tbl_HoTro_ChietTinhCongNo.SoTienTru, dbo.tbl_HopDong.MaHopDong, dbo.tbl_HopDong.NguoiThuaKe1Ten, dbo.tbl_HopDong.HoTen, dbo.tbl_HopDong.Diachi, SUM(dbo.tbl_HoTro.SoLuong) AS SoLuong, 
            //                         SUM(dbo.tbl_HoTro.SoTien) AS SoTien, dbo.tbl_HoTro_ChietTinhCongNo.Ngay_Lam, dbo.tbl_HoTro_ChietTinhCongNo.Nguoi_Lam, dbo.tbl_HoTro_ChietTinhCongNo.Ghi_Chu, ISNULL(dbo.tbl_HoTro_ChietTinhCongNo.XacNhanTT, 0) AS XacNhanTT
            //            FROM            dbo.tbl_HoTro INNER JOIN
            //                                     dbo.tbl_HoTro_ChietTinhCongNo ON dbo.tbl_HoTro.HoTroID = dbo.tbl_HoTro_ChietTinhCongNo.ID INNER JOIN
            //                                     dbo.tbl_HopDong ON dbo.tbl_HoTro.HopDongID = dbo.tbl_HopDong.ID
            //              WHERE  AND dbo.tbl_HoTro_ChietTinhCongNo.VuTrongID= " + MDSolutionApp.VuTrongID.ToString() + " GROUP BY dbo.tbl_HoTro_ChietTinhCongNo.SoTienTru, dbo.tbl_HopDong.MaHopDong, dbo.tbl_HopDong.NguoiThuaKe1Ten, dbo.tbl_HopDong.HoTen, dbo.tbl_HopDong.Diachi,tbl_HoTro_ChietTinhCongNo.ID, dbo.tbl_HopDong.SoCMT,dbo.tbl_HopDong.ID, dbo.tbl_HoTro_ChietTinhCongNo.Ngay_Lam, dbo.tbl_HoTro_ChietTinhCongNo.Nguoi_Lam, dbo.tbl_HoTro_ChietTinhCongNo.Ghi_Chu,dbo.tbl_HoTro_ChietTinhCongNo.XacNhanTT";

            string sql = @"SELECT   dbo.tbl_HopDong.ID AS HopDongID, tbl_HoTro_ChietTinhCongNo.ID,  dbo.tbl_HopDong.SoCMT,   dbo.tbl_HoTro_ChietTinhCongNo.SoTienTru, dbo.tbl_HopDong.MaHopDong, dbo.tbl_HopDong.NguoiThuaKe1Ten, dbo.tbl_HopDong.HoTen, dbo.tbl_HopDong.Diachi, SUM(dbo.tbl_HoTro.SoLuong) AS SoLuong, 
                         SUM(dbo.tbl_HoTro.SoTien) AS SoTien, dbo.tbl_HoTro_ChietTinhCongNo.Ngay_Lam, dbo.tbl_HoTro_ChietTinhCongNo.Nguoi_Lam, dbo.tbl_HoTro_ChietTinhCongNo.Ghi_Chu, ISNULL(dbo.tbl_HoTro_ChietTinhCongNo.XacNhanTT, 0) AS XacNhanTT, dbo.tbl_DanhMucCanBoNongVu.Ten AS TenCBNV, dbo.tbl_HoTro_ChietTinhCongNo.SoPhieu
            FROM            dbo.tbl_HoTro INNER JOIN
                         dbo.tbl_HoTro_ChietTinhCongNo ON dbo.tbl_HoTro.HoTroID = dbo.tbl_HoTro_ChietTinhCongNo.ID INNER JOIN
                         dbo.tbl_HopDong ON dbo.tbl_HoTro.HopDongID = dbo.tbl_HopDong.ID INNER JOIN
                         dbo.tbl_Thon ON dbo.tbl_HopDong.ThonID = dbo.tbl_Thon.ID INNER JOIN
                         dbo.tbl_DanhMucCanBoNongVu ON dbo.tbl_Thon.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.ID
              WHERE dbo.tbl_HoTro_ChietTinhCongNo.VuTrongID= " + MDSolutionApp.VuTrongID.ToString() + " AND  dbo.tbl_HoTro.VuTrongID = " + MDSolutionApp.VuTrongID.ToString() + " GROUP BY dbo.tbl_HoTro_ChietTinhCongNo.SoTienTru, dbo.tbl_HopDong.MaHopDong, dbo.tbl_HopDong.NguoiThuaKe1Ten, dbo.tbl_HopDong.HoTen, dbo.tbl_HopDong.Diachi,tbl_HoTro_ChietTinhCongNo.ID, dbo.tbl_HopDong.SoCMT,dbo.tbl_HopDong.ID, dbo.tbl_HoTro_ChietTinhCongNo.Ngay_Lam, dbo.tbl_HoTro_ChietTinhCongNo.Nguoi_Lam, dbo.tbl_HoTro_ChietTinhCongNo.Ghi_Chu,dbo.tbl_HoTro_ChietTinhCongNo.XacNhanTT, dbo.tbl_DanhMucCanBoNongVu.Ten, dbo.tbl_HoTro_ChietTinhCongNo.SoPhieu ";

            //            string sql2 = @"; SELECT *
            //                            FROM  tbl_HoTro_ChiTiet_TienLai; ";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            grvDaChietTinh.SetDataBinding(ds, "Table");

        }
        void LoadHoTro_DaDoiTru()
        {
            // isDaChietTinhLoaded = true;
            //string sql = @"SELECT * FROM V_HoTroDoiTruNo WHERE NgayThanhToan BETWEEN " + DBModule.RefineDatetime(this.dtCT_TuNgay.Value) + " AND " + DBModule.RefineDatetime(this.dtDa_DenNgay.Value);
            string sql = @"SELECT * FROM V_HoTroDoiTruNo Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            grvDaDoiTru.SetDataBinding(ds, "Table");

        }
        void LoadNhapTien()
        {
            //Tìm kiếm tất cả nhập mía của hđ đầu tư./
            long HDDTID = 0;
            try
            {
                HDDTID = long.Parse(this.gdHD.GetValue("ID").ToString());
            }
            catch
            {
                HDDTID = 0;
            }
            string sql = @"SELECT *
                          FROM V2016_ChietTinhTruNoDauTu_NhapMia where (NhapTienTraNo=1) ";
            sql += " and HDDauTuID=" + HDDTID;
            sql += " and HopDongID=" + gdHoCon.GetRow().Cells["ID"].Value;
            grvNhapTien.SetDataBinding(DBModule.ExecuteQuery(sql, null, null).Tables[0], "");


        }
        DateTime NgayQuaHanTinhLai = DateTime.MaxValue;
        private void frm_ChietTinhHoTroDauTu_Load(object sender, EventArgs e)
        {
            dtDaCT_TuNgay.Value = DateTime.Now.Date.AddDays(-1).AddHours(2);
            dtDaCT_DenNgay.Value = dtDaCT_TuNgay.Value.AddDays(1).AddHours(21);
            string sql = "select NgayQuaHanTinhLai from tbl_VuTrong where ID=" + MDSolutionApp.VuTrongID;
            try
            {
                NgayQuaHanTinhLai = (DateTime)DBModule.ExecuteQuery(sql, null, null).Tables[0].Rows[0][0];
            }
            catch (Exception exx)
            {

            }

            //if (MDSolutionApp.User.ID != 1)
            //{
            //   SLSCCSEntities.clsComFunctions.checkControlsPermission(this, this.Name.ToString());
            //}
            //CreateHoTroCols();
            //CreateHoTroColsDaChietTinh();
            dtTuNgay.Value = DateTime.ParseExact(DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd") + " 02:00:00", "yyyy-MM-dd HH:mm:ss", null);

            dtChotChietTinh.Value = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd") + " 02:00:00", "yyyy-MM-dd HH:mm:ss", null);
            Load_Tab_DMHD();
            LoadHoTro();
            //LoadChietTinh();
            //clsNhapMiaHoTroConfig.doAllChinhSach();
        }


        private void dtChotChietTinh_ValueChanged(object sender, EventArgs e)
        {
            LoadHoTro();
        }

        frm_ChietTinhCongNo_Confirm frm = new frm_ChietTinhCongNo_Confirm();
        frm_ChietTinhCongNo_NhapTienTraNo frmNhapTienTraNo = new frm_ChietTinhCongNo_NhapTienTraNo();
        frm_ChietTinhCongNo_TienTruNo frmEditTienTruNo = new frm_ChietTinhCongNo_TienTruNo();
        private string ChietTinhID;
        private void btnChietTinhCongNo_Click(object sender, EventArgs e)
        {

            //1. Duyet qua cac phieu can lua chon:
            GridEXRow gr = grvNhapMia.GetRow();
            if (grvNhapMia.GetCheckedRows().Length < 1)
            {
                if (MessageBox.Show("Bạn chưa hộ nào để chiết tính, bạn muốn tiếp tục?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    grvNhapMia.Focus();
                    return;
                }
            }
            frm.ID = gr.Cells["HopDongID"].Value.ToString();
            //frm.txtDen.Text = dtChotChietTinh.Value.ToString("dd/MM/yyyy HH:mm");
            frm.txtGhiChu.Text = "";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            if (!string.IsNullOrEmpty(frm.ID) && frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.ChietTinhID = frm.ID;
                int isChayTruNo = 0;
                foreach (GridEXRow jr in this.grvNhapMia.GetCheckedRows())
                {
                    int HopDongID = (int)jr.Cells["HopDongID"].Value;
                    decimal SoHoTro = (decimal)jr.Cells["SoTien"].Value;
                    // bổ sung ngay làm hỗ trợ
                    DateTime NgayLamHoTro = DateTime.Now;
                    SonLa_HoTroDauTu(HopDongID, NgayLamHoTro, 1, true);
                    // tạm dừng
                    string srest = "";
                    if (!string.IsNullOrWhiteSpace(srest))
                    {
                        MessageBox.Show(srest);
                        LoadHoTro();
                        LoadHoTro_DaChietTinh();
                        return;
                    }
                    isChayTruNo = 1;
                }
                if (isChayTruNo > 0)
                {

                    LoadHoTro();
                    LoadHoTro_DaChietTinh();
                }
            }

        }



        private void uiButton1_Click(object sender, EventArgs e)
        {
            HoTro.frm_ChietTinhCongNo_DanhSach frmds = new frm_ChietTinhCongNo_DanhSach();
            frmds.ShowDialog();
            frmds.StartPosition = FormStartPosition.CenterParent;
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            string[] paramNames = new string[] { };
            string[] paraValues = new string[] { };
            CommonClass.ShowReport("ThanhToan2016\\BangKeMuaHang_Mau06.rpt", "Bảng kê mua hàng", paramNames, paraValues, null);

        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            string[] paramNames = new string[] { };
            string[] paraValues = new string[] { };
            CommonClass.ShowReport("ThanhToan2016\\BangKeMuaHang_Mau01.rpt", "Bảng kê mua hàng", paramNames, paraValues, null);
        }

        private void grvNhapMia_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            if (e.Row.RowType == RowType.Record)
            {
                frmEditTienTruNo.ID = e.Row.Cells["ID"].Value.ToString();
                frmEditTienTruNo.txtTienCo.Text = ((decimal)e.Row.Cells["ThanhTien"].Value + (decimal)e.Row.Cells["HoTro"].Value - ((decimal)e.Row.Cells["SoTienThuNo"].Value + (decimal)e.Row.Cells["TienLai"].Value)).ToString("###");
                frmEditTienTruNo.txtTienTru.Text = frmEditTienTruNo.txtTienCo.Text;
                frmEditTienTruNo.txtConLai.Text = "0";
                frmEditTienTruNo.StartPosition = FormStartPosition.CenterParent;
                frmEditTienTruNo.ShowDialog();
                if (frmEditTienTruNo.DialogResult == System.Windows.Forms.DialogResult.OK)
                    LoadHoTro();
            }
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_NhapTienTraNo_Click(object sender, EventArgs e)
        {

        }

        private void grvNhapMia_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "EditTienTruNo")
            {

            }
        }


        private void tabChietTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            //chkChietTinh.Checked = (tabChietTinh.SelectedIndex == 1);
        }

        private void dtDaCT_TuNgay_ValueChanged(object sender, EventArgs e)
        {
            //LoadHoTro_DaChietTinh();
            // LoadChietTinh();
        }
        //        void LoadChietTinh()
        //        {
        //            //Tìm kiếm tất cả nhập mía của hđ đầu tư./
        //            string sql = @"SELECT *
        //                          FROM tbl_ThanhToan_ChietTinhCongNo where 1=1";
        //            if (!dtDaCT_TuNgay.IsNullDate) sql += " and Ngay_Lam>'" + dtDaCT_TuNgay.Value.ToString("yyyy-MM-dd HH:mm") + "' ";
        //            if (!dtDaCT_DenNgay.IsNullDate) sql += " and Ngay_Lam<'" + dtDaCT_DenNgay.Value.ToString("yyyy-MM-dd HH:mm") + "' ";
        //            sql += " ORDER BY Ngay_Lam DESC";
        //            grvChietTinhCongNo.SetDataBinding(DBModule.ExecuteQuery(sql, null, null).Tables[0], "");

        //        }
        private void dtDaCT_DenNgay_ValueChanged(object sender, EventArgs e)
        {
            //LoadChietTinh();
        }


        private void btnHuyCT_Click(object sender, EventArgs e)
        {
            if (grvDaChietTinh.GetCheckedRows().Length < 1)
            {
                MessageBox.Show("Bạn chưa chọn dòng chi tiết chiết tính để hủy.", "Thông báo");

                grvDaChietTinh.Focus();
                return;

            }
            foreach (Janus.Windows.GridEX.GridEXRow jr in grvDaChietTinh.GetCheckedRows())
            {
                if (jr.Cells["XacNhanTT"].Value.ToString() == "1")
                {

                    MessageBox.Show("Dòng chiết tính số [" + (jr.RowIndex + 1).ToString() + "] đã thực hiện thanh toán, không thể huy.", "Thông báo");

                    return;
                }
            }
            frm_ChietTinhCongNo_Confirm_Huy frmhuy = new frm_ChietTinhCongNo_Confirm_Huy();
            if (frmhuy.ShowDialog() == DialogResult.OK)
            {
                string sql = "sp_HoTro_HuyChietTinh {0},{1},{2},{3}";
                foreach (Janus.Windows.GridEX.GridEXRow jr in grvDaChietTinh.GetCheckedRows())
                {
                    try
                    {
                        foreach (Janus.Windows.GridEX.GridEXRow jrdt in grvTruNoChiTiet.GetDataRows())
                        {
                            long _DauTu = long.Parse(jrdt.Cells["ID"].Value.ToString());
                            string updateDauTu = @"Update tbl_DauTu set SoTien= SoTienTruHoTro_Goc,NgayDauTu=NgayDauTuGoc,tbl_DauTu.DaLamHoTro= NULL,tbl_DauTu.GhiChuHoTro = '' where ID =" + _DauTu;
                            DBModule.ExecuteNoneBackup(updateDauTu, null, null);
                            string deledautu =@"DELETE tbl_HoTro_ChiTiet_TienLai WHERE  DauTuID ="+_DauTu;
                            DBModule.ExecuteNoneBackup(deledautu,null,null);
                        }
                    }
                    catch { }
                    string id = jr.Cells["ID"].Value.ToString();
                    DBModule.ExecuteNonQuery(string.Format(sql, id, "N'" + frmhuy.txtGhiChu.Text + "'", "N'" + MDSolutionApp.User.HoTen + "'", MDSolutionApp.VuTrongID), null, null);
                }
                LoadHoTro_DaChietTinh();
            }
        }


        private void Load_Tab_DMHD()
        {
            //string strSQL = "";
            //strSQL = "SELECT * FROM V_HDDT WHERE VuTrongID= " + MDSolutionApp.VuTrongID.ToString();
            //DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            //if (ds.Tables.Count > 0)
            //{
            //    gdHD.SetDataBinding(ds.Tables[0], "");
            //}

        }

        private void Load_HoCon(long HDDT_ID)
        {
            string strSQL = "";
            strSQL = "SELECT * FROM V_HoCon WHERE VuTrongID= " + MDSolutionApp.VuTrongID.ToString() + " AND HDDTID=" + HDDT_ID.ToString();
            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables.Count > 0)
            {
                gdHoCon.SetDataBinding(ds.Tables[0], "");
            }
        }
        private void gdHD_SelectionChanged(object sender, EventArgs e)
        {
            long HDDTID = 0;
            try
            {
                HDDTID = long.Parse(this.gdHD.GetValue("ID").ToString());
            }
            catch
            {
                HDDTID = 0;
            }
            if (HDDTID > 0)
            {
                Load_HoCon(HDDTID);
            }
        }

        private void gdHoCon_SelectionChanged(object sender, EventArgs e)
        {
            if (gdHoCon.GetRow() != null && gdHoCon.GetRow().RowType == RowType.Record)
                LoadNhapTien();
        }

        private void gdHoCon_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "NhapTienTraNo")
            {
                //if (cboHopDong.SelectedIndex > 0 && cboTenHoChiTiet.SelectedIndex > 0)
                //{
                frmNhapTienTraNo.dtNgayTra.Value = DateTime.Now;
                frmNhapTienTraNo.HopDongID = gdHoCon.GetRow().Cells["ID"].Value.ToString();
                frmNhapTienTraNo.HDDTID = gdHD.GetRow().Cells["ID"].Value.ToString();
                frmNhapTienTraNo.Show();
                frmNhapTienTraNo.Visible = false;
                frmNhapTienTraNo.NgayQuaHanTinhLai = NgayQuaHanTinhLai;
                string sql = "select * from V2016_NhapTienTraNo where HopDongID={0} and HDDTID={1}";
                DataTable dt = DBModule.ExecuteQuery(string.Format(sql, frmNhapTienTraNo.HopDongID, frmNhapTienTraNo.HDDTID), null, null).Tables[0];
                frmNhapTienTraNo.grvTienDauTu.SetDataBinding(dt, "");
                decimal TongTienPhaiTra = 0;//MaHopDong                
                string srest = "";// tt.TruNoDauTu(false);
                if (!string.IsNullOrEmpty(srest))
                {
                    MessageBox.Show(srest);
                    return;
                }
                foreach (GridEXRow dr in frmNhapTienTraNo.grvTienDauTu.GetRows())
                {
                    if (dr.RowType == RowType.Record)
                    {
                        decimal GocTinhLai = (decimal)dr.Cells["SoTien"].Value - (decimal)dr.Cells["TraGoc"].Value;
                        DateTime NgayTinhLai = (DateTime)dr.Cells["NgayBatDauTinhLai"].Value;
                        int DanhMucDauTuID = (int)dr.Cells["DanhMucDauTuID"].Value;
                        int ID = (int)dr.Cells["ID"].Value;
                        dr.BeginEdit();
                        var test = dr.Cells["TienLaiPhatSinh"].Value;

                        decimal TienPhaiTra = (decimal)dr.Cells["SoTien"].Value - (decimal)dr.Cells["TraGoc"].Value + (decimal)dr.Cells["TienLaiPhatSinh"].Value + (decimal)dr.Cells["TienLaiChotNoCu"].Value;
                        TongTienPhaiTra += TienPhaiTra;
                        dr.Cells["ConLai"].Value = TienPhaiTra;
                        dr.EndEdit();
                    }
                }
                frmNhapTienTraNo.txtHDDT.Text = gdHD.GetRow().Cells["SoHD"].Value.ToString() + "-" + gdHD.GetRow().Cells["HoTen"].Value.ToString();
                frmNhapTienTraNo.txtHoChiTiet.Text = gdHoCon.GetRow().Cells["MaHopdong"].Value.ToString() + "-" + gdHoCon.GetRow().Cells["HoTen"].Value.ToString();
                frmNhapTienTraNo.txtTienCanTra.Text = TongTienPhaiTra.ToString("###");
                frmNhapTienTraNo.txtTienNhap.Text = TongTienPhaiTra.ToString("###");
                frmNhapTienTraNo.txtPhieuThu.Text = "";
                frmNhapTienTraNo.StartPosition = FormStartPosition.CenterParent;
                frmNhapTienTraNo.ShowDialog();
                if (frmNhapTienTraNo.DialogResult == System.Windows.Forms.DialogResult.OK)
                {

                    LoadNhapTien();
                }
            }
        }

        private void grvNhapTien_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "Xoa")
            {

                if ((int)grvNhapTien.GetRow().Cells["DaThanhToan"].Value > 0)
                {
                    MessageBox.Show("Số tiền đã thực hiện thanh toán không thể xóa.", "Thông báo");
                    return;
                }
                if (MessageBox.Show("Bạn chắc chắn muốn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    string sql = "Delete tbl_nhaptien where id=" + grvNhapTien.GetRow().Cells["ID"].Value.ToString();
                    DBModule.ExecuteNonQuery(sql, null, null);
                    LoadNhapTien();
                }
            }
        }

        private void grvNhapMia_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
        {
            grvNhapMia.Refresh();
        }


        private void btnXuatExcelNhapMia_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.FileName = "SOSUCO_chiettinh_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = grvNhapMia;
                        exporter.Export(fs);
                        fs.Close();
                        string text = File.ReadAllText(saveFileDialog.FileName);
                        text = text.Replace("<ss:NumberFormat ss:Format=\"Standard\" />", "<NumberFormat/>");
                        File.WriteAllText(saveFileDialog.FileName, text);

                        Excel.Application xlApp;
                        Excel.Workbook xlWorkBook;

                        xlApp = Export2Excel.TryGetExistingExcelApplication();
                        if (xlApp == null)
                        {
                            xlApp = new Excel.Application();
                        }
                        xlWorkBook = xlApp.Workbooks.Open(saveFileDialog.FileName);

                        xlApp.Visible = true;
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
        }


        private void cmdXuatExcel_ChiTietTraTienMat_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.FileName = "SOSUCO_chiettinh_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = grvNhapTien;
                        exporter.Export(fs);
                        fs.Close();
                        string text = File.ReadAllText(saveFileDialog.FileName);
                        text = text.Replace("<ss:NumberFormat ss:Format=\"Standard\" />", "<NumberFormat/>");
                        File.WriteAllText(saveFileDialog.FileName, text);

                        Excel.Application xlApp;
                        Excel.Workbook xlWorkBook;

                        xlApp = Export2Excel.TryGetExistingExcelApplication();
                        if (xlApp == null)
                        {
                            xlApp = new Excel.Application();
                        }
                        xlWorkBook = xlApp.Workbooks.Open(saveFileDialog.FileName);

                        xlApp.Visible = true;
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
        }



        private void uiDieuChinhSoTienTruNo_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime NgayLamHoTro = DateTime.Now;
                GridEXRow gr = grvNhapMia.GetRow();
                if (grvNhapMia.GetCheckedRows().Length < 1)
                {
                    if (MessageBox.Show("Bạn chưa hộ nào để chiết tính, bạn muốn tiếp tục?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        grvNhapMia.Focus();
                        return;
                    }
                }
                if (grvNhapMia.GetCheckedRows().Length > 1)
                {
                    MessageBox.Show("Bạn chọn nhiều hơn một hộ chiết tính ?", "Thông báo");
                    grvNhapMia.Focus();
                    return;
                }
                // thêm vào số phiếu 
                string stt = DBModule.ExecuteQueryForOneResult("Get_MaPhieu 'tbl_HoTro_ChietTinhCongNo', " + MDSolutionApp.VuTrongID, null, null);
                DateTime dt = (DateTime)DBModule.ExecuteQuery("Select NgayBatDau from tbl_VuTrong where ID=" + MDSolutionApp.VuTrongID, null, null).Tables[0].Rows[0][0];
                strMaPhieu = "DTHT" + dt.Year.ToString("###") + "_";
                strMaPhieu = strMaPhieu + stt.PadLeft(6, '0');
                // kêt thúc số phiếu


                frmEditTienTruNo.ID = gr.Cells["HopDongID"].Value.ToString();
                int HopDongID = int.Parse(gr.Cells["HopDongID"].Value.ToString());
                frmEditTienTruNo.txtTienCo.Text = gr.Cells["SoTien"].Value.ToString();
                frmEditTienTruNo.txtTienTru.Text = frmEditTienTruNo.txtTienCo.Text;
                frmEditTienTruNo.txtSoPhieu.Text = strMaPhieu;
                frmEditTienTruNo.StartPosition = FormStartPosition.CenterParent;
                frmEditTienTruNo.ShowDialog();
                if (frmEditTienTruNo.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    this.ChietTinhID = frmEditTienTruNo.ID;
                    SonLa_HoTroDauTu(HopDongID, NgayLamHoTro, 0, true);
                }
                LoadHoTro();
            }
            catch
            {
                MessageBox.Show("Có lỗi khi thực hiện điều chỉnh tiền trừ nợ", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private Boolean isDaChietTinhLoaded = false;

        private void btnBangChietTinh_Click(object sender, EventArgs e)
        {
            try
            {
                string[] paramNames = new string[] { };
                string[] paraValues = new string[] { };

                string sql = @" SELECT *
                            FROM  dbo.V2016_BangChietTinhThuNoDauTu  where 1=3 ";
                foreach (Janus.Windows.GridEX.GridEXRow r in grvDaChietTinh.GetCheckedRows())
                {
                    sql += " or NhapMiaTienID='" + r.Cells["NhapTienTraNo"].Value + "_" + r.Cells["ID"].Value + "'";
                }
                DataSet ds = DBModule.ExecuteQuery(sql, null, null);

                //CommonClass.ShowReportWithDataSet("ThanhToan2016\\ChietTinhCongNoTheoHoChiTiet_SelectIDs.rpt", "Chiết tính công nợ", paramNames, paraValues, ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi:" + ex.Message);

            }

        }



        private void grvDaChietTinh_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //lbChiTietTruNo.Text = " ";
                var r = grvDaChietTinh.GetRow();
                if (r != null)
                {
                    if (r.RowType == RowType.Record)
                    {
                        string sql = @"SELECT    dbo.tbl_DauTu.ID,dbo.tbl_DanhMucDauTu.Ten AS DanhMucDauTu, dbo.tbl_DauTu.SoLuong, dbo.tbl_DauTu.DonGia, dbo.tbl_DauTu.SoTien AS SoTienCon, dbo.tbl_DauTu.SoTienTruHoTro_Goc, dbo.tbl_DauTu.SoTienTruHoTro_Lai, 
                         dbo.tbl_HoTro_ChiTiet_TienLai.TongTra, dbo.tbl_HoTro_ChiTiet_TienLai.TienLai AS TraLai, dbo.tbl_HoTro_ChiTiet_TienLai.GocTinhLai AS TraGoc, dbo.tbl_HoTro_ChiTiet_TienLai.SoNgayTinhLai, dbo.tbl_DauTu.DaLamHoTro, 
                         dbo.tbl_DauTu.HopDongID, dbo.tbl_HoTro_ChiTiet_TienLai.TuNgay, dbo.tbl_HoTro_ChiTiet_TienLai.DenNgay, dbo.tbl_DauTu.LaiSuat
                        FROM            dbo.tbl_HoTro_ChiTiet_TienLai INNER JOIN
                         dbo.tbl_DauTu ON dbo.tbl_HoTro_ChiTiet_TienLai.DauTuID = dbo.tbl_DauTu.ID INNER JOIN
                         dbo.tbl_DanhMucDauTu ON dbo.tbl_DauTu.DanhMucDauTuID = dbo.tbl_DanhMucDauTu.ID WHERE dbo.tbl_DauTu.HopDongID=" + r.Cells["HopDongID"].Value + "AND dbo.tbl_DauTu.VuTrongID =" + MDSolutionApp.VuTrongID;
                        grvTruNoChiTiet.SetDataBinding(DBModule.ExecuteQuery(sql, null, null).Tables[0], "");

                        //lbChiTietTruNo.Text = " ";// +r.Cells["LoaiTien"].Value + "(" + r.Cells["SoTai"].Value + ") " + r.Cells["DaiLyHoTen"].Value + "-" + r.Cells["ChuMiaHoTen"].Value + "(" + r.Cells["ThanhTien"].Text + " đồng)";
                    }

                }
                else
                {
                    grvTruNoChiTiet.DataSource = null;
                }
            }
            catch
            {
                grvTruNoChiTiet.DataSource = null;
            }
        }


        private void cmdXuatExcel_ChiTietTruNo_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.FileName = "SOSUCO_chitietHoTro_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = grvTruNoChiTiet;
                        exporter.Export(fs);
                        fs.Close();
                        string text = File.ReadAllText(saveFileDialog.FileName);
                        text = text.Replace("<ss:NumberFormat ss:Format=\"Standard\" />", "<NumberFormat/>");
                        File.WriteAllText(saveFileDialog.FileName, text);

                        Excel.Application xlApp;
                        Excel.Workbook xlWorkBook;

                        xlApp = Export2Excel.TryGetExistingExcelApplication();
                        if (xlApp == null)
                        {
                            xlApp = new Excel.Application();
                        }
                        xlWorkBook = xlApp.Workbooks.Open(saveFileDialog.FileName);

                        xlApp.Visible = true;
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }

        }

        private void btBangChietTinhChiTietLai_Click(object sender, EventArgs e)
        {
            try
            {
                string[] paramNames = new string[] { };
                string[] paraValues = new string[] { };

                string sql = @" SELECT *
                            FROM  dbo.V2016_BangChietTinhThuNoDauTu  where 1=3 ";
                foreach (Janus.Windows.GridEX.GridEXRow r in grvDaChietTinh.GetCheckedRows())
                {
                    sql += " or NhapMiaTienID='" + r.Cells["NhapTienTraNo"].Value + "_" + r.Cells["ID"].Value + "'";
                }
                DataSet ds = DBModule.ExecuteQuery(sql, null, null);

                //CommonClass.ShowReportWithDataSet("ThanhToan2016\\ChietTinhCongNoTheoHoChiTiet_SelectIDs_ChiTietLai.rpt", "Chiết tính công nợ", paramNames, paraValues, ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi:" + ex.Message);

            }
        }

        private void TabThuNo_ThanhToan_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (TabThuNo_ThanhToan.SelectedIndex == 0)
            {
                LoadHoTro();
            }
            if (TabThuNo_ThanhToan.SelectedIndex == 1)
            {
                LoadHoTro_DaChietTinh();
            }
            if (TabThuNo_ThanhToan.SelectedIndex == 2)
            {
                LoadHoTro_DaDoiTru();
            }

        }

        private void cmdFindPhieuChuaChietTinh_Click(object sender, EventArgs e)
        {
            LoadHoTro();
        }

        private void cmdFindPhieuDaChietTinh_Click(object sender, EventArgs e)
        {
            LoadHoTro_DaChietTinh();
        }

        private void cmdXuatExcel_DaChietTinh_Click(object sender, EventArgs e)
        {
            try
            {
                grvDaChietTinh.RootTable.Columns["isChecked"].Visible = false;
                saveFileDialog.FileName = "sosuco_chiettinh_HoTro" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = grvDaChietTinh;
                        exporter.Export(fs);
                        fs.Close();
                        string text = File.ReadAllText(saveFileDialog.FileName);
                        text = text.Replace("<ss:NumberFormat ss:Format=\"Standard\" />", "<NumberFormat/>");
                        File.WriteAllText(saveFileDialog.FileName, text);

                        Excel.Application xlApp;
                        Excel.Workbook xlWorkBook;

                        xlApp = Export2Excel.TryGetExistingExcelApplication();
                        if (xlApp == null)
                        {
                            xlApp = new Excel.Application();
                        }
                        xlWorkBook = xlApp.Workbooks.Open(saveFileDialog.FileName);

                        xlApp.Visible = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
            finally
            {
                grvDaChietTinh.RootTable.Columns["isChecked"].Visible = true;
            }

        }

        private void grvDaChietTinh_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "Print")
            {
                var r = grvDaChietTinh.GetRow();
                if (r != null)
                {
                    string HopDongID = r.Cells["HopDongID"].Value.ToString();
                    string[] paramNames = new string[] { "@HopDongID", "@VuTrongID" };
                    string[] paraValues = new string[] { HopDongID, MDSolutionApp.VuTrongID.ToString() };
                    //CommonClass.ShowReport("TienChinhSach\\CrystalReport1.rpt", "Phiếu đối trừ đầu tư", paramNames, paraValues, null);
                    CommonClass.ShowReport("TienChinhSach\\rpt_HoTroDauTu.rpt", "Phiếu đối trừ đầu tư", paramNames, paraValues, null);
                }

            }
        }

        private void btnXacCT_Click(object sender, EventArgs e)
        {
            if (grvDaChietTinh.GetCheckedRows().Length < 1)
            {
                MessageBox.Show("Bạn chưa chọn chủ mía để xác nhận đối trừ.", "Thông báo");

                grvDaChietTinh.Focus();
                return;

            }
            foreach (Janus.Windows.GridEX.GridEXRow jr in grvDaChietTinh.GetCheckedRows())
            {
                if (jr.Cells["XacNhanTT"].Value.ToString() == "1")
                {
                    MessageBox.Show("Dòng xác nhận số [" + (jr.RowIndex + 1).ToString() + "] đã thực hiện xác nhận", "Thông báo");
                    return;
                }
            }
            frm_ChietTinhCongNo_Confirm_Huy frmhuy = new frm_ChietTinhCongNo_Confirm_Huy();
            if (frmhuy.ShowDialog() == DialogResult.OK)
            {
                string sqlxacnhan = @"INSERT INTO [dbo].[tbl_HoTro_TTDoiTru]
                   ([HopDongID]
                   ,[TongTienHoTro]
                   ,[TongTruDauTu]
                   ,[ConLaiHoTro]
                   ,[SoTienBangChu]
                   ,[NgayThanhToan]
                   ,[VuTrongID]                   
                   ,[NguoiLamHoTro]
                   ,[GhiChu]) VALUES ({0},{1},{2},{3},N'{4}',{5}, {6}, N'{7}', N'{8}')";

                foreach (Janus.Windows.GridEX.GridEXRow jr in grvDaChietTinh.GetCheckedRows())
                {

                    string ID = jr.Cells["HopDongID"].Value.ToString();
                    string IDXacNhan = jr.Cells["ID"].Value.ToString();
                    string TienHoTro = jr.Cells["SoTien"].Value.ToString();
                    decimal TienDoiTru = SoTienTru_HoTro_DauTu(ID, MDSolutionApp.VuTrongID.ToString());
                    decimal TienConLai = decimal.Parse(TienHoTro) - TienDoiTru;
                    string TienBangChu = frmShowRP3.DocSo((double)TienConLai);
                    string NguoiLam = MDSolutionApp.User.HoTen;
                    string VuTrongID = MDSolutionApp.VuTrongID.ToString();
                    string GhiChu = frmhuy.txtGhiChu.Text;
                    //string nhaptientrano = jr.Cells["NhapTienTraNo"].Value.ToString();
                    //string CTid = jr.Cells["DaThanhToan"].Value.ToString();
                    DBModule.ExecuteNonQuery(string.Format(sqlxacnhan, ID, TienHoTro, TienDoiTru, TienConLai, TienBangChu, "GetDate()", VuTrongID, NguoiLam, GhiChu), null, null);
                    string sqlCapNhatXacNhan = @"UpDate dbo.tbl_HoTro_ChietTinhCongNo Set XacNhanTT = 1 Where ID =" + IDXacNhan;
                    DBModule.ExecuteNonQuery(sqlCapNhatXacNhan, null, null);
                }
                LoadHoTro_DaChietTinh();
            }
        }

        private void grvDaDoiTru_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "Print")
            {
                var r = grvDaDoiTru.GetRow();
                if (r != null)
                {
                    string HopDongID = r.Cells["HopDongID"].Value.ToString();
                    string[] paramNames = new string[] { "@HopDongID", "@VuTrongID" };
                    string[] paraValues = new string[] { HopDongID, MDSolutionApp.VuTrongID.ToString() };
                    //CommonClass.ShowReport("TienChinhSach\\CrystalReport1.rpt", "Phiếu đối trừ đầu tư", paramNames, paraValues, null);
                    CommonClass.ShowReport("TienChinhSach\\rpt_HoTroDauTu.rpt", "Phiếu đối trừ đầu tư", paramNames, paraValues, null);
                }

            }
        }

        private void uiButton3_Click_1(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.FileName = "SOSUCO_DaHoTro_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = grvDaDoiTru;
                        exporter.Export(fs);
                        fs.Close();
                        string text = File.ReadAllText(saveFileDialog.FileName);
                        text = text.Replace("<ss:NumberFormat ss:Format=\"Standard\" />", "<NumberFormat/>");
                        File.WriteAllText(saveFileDialog.FileName, text);

                        Excel.Application xlApp;
                        Excel.Workbook xlWorkBook;

                        xlApp = Export2Excel.TryGetExistingExcelApplication();
                        if (xlApp == null)
                        {
                            xlApp = new Excel.Application();
                        }
                        xlWorkBook = xlApp.Workbooks.Open(saveFileDialog.FileName);

                        xlApp.Visible = true;
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void uiButton1_Click_1(object sender, EventArgs e)
        {


            if (cboCBNV.SelectedValue != null)
            {
                string CBNVID = cboCBNV.SelectedValue.ToString();
                MDReport.Frm_ReportViewer frm = new MDReport.Frm_ReportViewer();
                string[] paramNames = new string[] { "@CBNVID", "@VuTrongID" };
                string[] paraValues = new string[] { CBNVID, MDSolutionApp.VuTrongID.ToString() };
                CommonClass.ShowReport("TienChinhSach\\InTongHopHoTro.rpt", "Phiếu đối trừ đầu tư", paramNames, paraValues, null);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn Cán bộ nông vụ");
            }


            //if (HopDongID == -1)
            //{
            //    labelLoi.Text = "Bạn phải chọn hợp đồng";
            //}
            //else
            //{
            //    labelLoi.Text = "";
            //    MDReport.Frm_ReportViewer frm = new Frm_ReportViewer();
            //    string[] paramNames = new string[] { "@VuTrongID", "@HopDongID", "@TuNgay", "@DenNgay" };
            //    string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString(),HopDongID.ToString(),dtTuNgay.Value.ToString("yyyy-MM-dd"),dtDenNgay.Value.ToString("yyyy-MM-dd")

            //};
            //    CommonClass.ShowReport("\\ThanhToan2016\\rpt_SoChiTietCongNoTheoHo.rpt", "Chi tiết công nợ", paramNames, paraValues, null);
            //}


        }

        private void btn_DaDoiTruHT_Click(object sender, EventArgs e)
        {
            LoadHoTro_DaDoiTru();
        }

        private void uiButton1_Click_2(object sender, EventArgs e)
        {
            if (grvDaDoiTru.GetCheckedRows().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn phiếu cần in"); return;
            }

            foreach (Janus.Windows.GridEX.GridEXRow r in grvDaDoiTru.GetCheckedRows())
            {
                string HopDongID = r.Cells["HopDongID"].Value.ToString();
                string[] paramNames = new string[] { "@HopDongID", "@VuTrongID" };
                string[] paraValues = new string[] { HopDongID, MDSolutionApp.VuTrongID.ToString() };               
                CommonClass.ShowReport("TienChinhSach\\rpt_HoTroDauTu.rpt", "Phiếu đối trừ đầu tư", paramNames, paraValues, null);
            }
        }

        private void btnTinhLaiLaiChoHo_Click(object sender, EventArgs e)
        {
            GridEXRow gr = grvNhapMia.GetRow();
            if (grvNhapMia.GetCheckedRows().Length < 1)
            {
                if (MessageBox.Show("Bạn chưa hộ nào để chiết tính, bạn muốn tiếp tục?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    grvNhapMia.Focus();
                    return;
                }
            }
            if (grvNhapMia.GetCheckedRows().Length > 1)
            {
                MessageBox.Show("Bạn chọn nhiều hơn một hộ chiết tính ?", "Thông báo");
                grvNhapMia.Focus();
                return;
            }

            int HopDongID = int.Parse(gr.Cells["HopDongID"].Value.ToString());
            if (MessageBox.Show("Bạn muốn tính tiền lãi cho các khoản đầu tư của vụ đang chọn để trừ tính hỗ trợ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //string sql = "update tbl_dautu set SoTienTruHoTro_Lai=dbo.Tinh_Lai_DauTu(ISNULL(SoTien,0), ISNULL(LaiSuat, 0), NgayDauTu, '" + NgayChot_calendarCombo1.Value.ToString("yyyy-MM-dd") + "' WHERE VuTrongID = " + VuTrong_ComboBox1.SelectedValue.ToString();

                // Tìm các nhà có hỗ trợ cập nhật lãi đâu tư.
                string sqlHotro = @"select dbo.tbl_DauTu.ID,dbo.tbl_DauTu.HopDongID,dbo.tbl_DauTu.Sotien,NgayDauTu,LaiSuat,dbo.tbl_HoTro_TruLai.DauTuID, dbo.tbl_HoTro_TruLai.SoTien AS SoTienTinhLaiSauHT
                         FROM            dbo.tbl_DauTu LEFT OUTER JOIN
                         dbo.tbl_HoTro_TruLai ON dbo.tbl_DauTu.ID = dbo.tbl_HoTro_TruLai.DauTuID where dbo.tbl_DauTu.HopDongID in (select HopDongID from V_DanhSach_HoTro) AND dbo.tbl_DauTu.HopDongID not in (Select HopDongID from tbl_ThanhToanMia where VuTrongID =" + MDSolutionApp.VuTrongID.ToString() + " AND HopDongID = " + HopDongID + " AND TrangThaiHuy<>1) AND dbo.tbl_DauTu.DaLamHoTro IS NULL AND  dbo.tbl_DauTu.VuTrongID= " + MDSolutionApp.VuTrongID.ToString() + " AND tbl_DauTu.HopDongID = " + HopDongID;
                DataTable dtHoTro = DBModule.ExecuteQuery(sqlHotro, null, null).Tables[0];

                if (dtHoTro.Rows.Count == 0)
                {
                    MessageBox.Show("Không có khoản đầu tư nào hay đã thanh toán rồi");
                    return;
                }
                
                foreach (DataRow dr in dtHoTro.Rows)
                {
                    int DauTuID = (int)dr["ID"];


                    decimal TienGoc = 0;

                    int DanhMucDauTuID = -1;
                    if (string.IsNullOrEmpty(dr["DauTuID"].ToString()))
                    {
                    }
                    else
                    {
                        DanhMucDauTuID = (int)dr["DauTuID"];
                    }
                    decimal SoTienTinhLaiSauHT = 0;
                    if (string.IsNullOrEmpty(dr["SoTienTinhLaiSauHT"].ToString()))
                    {
                        SoTienTinhLaiSauHT = 0;
                    }
                    else
                    {
                        SoTienTinhLaiSauHT = decimal.Parse(dr["SoTienTinhLaiSauHT"].ToString());
                    }

                    DateTime NgayDauTu = (DateTime)dr["NgayDauTu"];

                    decimal LaiSuat = 0;
                    if (string.IsNullOrEmpty(dr["LaiSuat"].ToString()))
                    {
                        LaiSuat = 0;
                    }
                    else
                    {
                        LaiSuat = decimal.Parse(dr["LaiSuat"].ToString());
                    }

                    if (DanhMucDauTuID > 0 && SoTienTinhLaiSauHT > 0)
                    {
                        TienGoc = SoTienTinhLaiSauHT;
                    }
                    else
                    {
                        TienGoc = (decimal)dr["SoTien"];
                    }
                    //DateTime NgayTinhLai = DateTime.Parse(NgayChot_calendarCombo1.Value.ToString("MM/dd/yyyy HH:mm:ss"));


                    DateTime NgayTinhLai = DateTime.Parse(dt_NgayChotLaiHoTro.Value.ToString("yyyy-MM-dd"));

                    decimal TienLai = TinhLaiCoBan(TienGoc, NgayTinhLai, NgayDauTu, LaiSuat);
                    // sql cập nhật đâu tư
                    try
                    {
                        string sqlCapNhatDautu = @" UPDATE [dbo].[tbl_DauTu] SET  [SoTienTruHoTro_Lai] = " + TienLai + ",[NgayChotTruHT] = " + DBModule.RefineDatetime(NgayTinhLai) + " ,[SoTienTruHoTro_Goc] = SoTien,[NgayDauTuGoc] =  NgayDauTu  WHERE ID =" + DauTuID;
                        DBModule.ExecuteNoneBackup(sqlCapNhatDautu, null, null);
                    }
                    catch { }
                }
                //string sql = "update tbl_dautu set SoTienTruHoTro_Lai=dbo.Tinh_Lai_DauTu(ISNULL(SoTien,0), ISNULL(LaiSuat, 0), NgayDauTu, '" + NgayChot_calendarCombo1.Value.ToString("yyyy-MM-dd") + "' WHERE VuTrongID = " + VuTrong_ComboBox1.SelectedValue.ToString();

                //DBModule.ExecuteNonQuery(sql, null, null);
                MessageBox.Show("Đã cập nhật thành công tiền lãi cho toàn bộ đầu tư.", "Thông báo");
            }
        }




    }
}
