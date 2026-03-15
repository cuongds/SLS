
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsDauTu
    {
        public long ID = -1;
        public long ThuaRuongID = -1;
        public long HopDongID = -1;
        public long DanhMucDauTuID = -1;
        public long LoaiHinhDauTuID = -1;
        public decimal SoLuong = 0;
        public decimal DonGia = 0;
        public decimal SoTien = 0;
        public decimal LaiSuat = 0;
        public DateTime NgayDauTu = DateTime.MinValue;
        public string GhiChu = "";
        public decimal DotDauTu = 0;
        public long DuNo = 0;
        public DateTime NgayBatDauTinhLai = DateTime.MinValue;
        public long DaThanhToan = -1;
        public long VuTrongID = MDSolutionApp.VuTrongID;
        public long VuTruoc = 0;
        public long LaDuNoVuTruoc = 0;
        public long QuanLyVaKhauHaoID = -1;
        public long DonViCungUngVatTuID = 1;
        public string SoChungTu = "";
        public string GhiChuHoTro = "";
        public decimal SoTienTinhLaiSauHT = 0;
        public long HoTroID = -1;
        public decimal SoTienTruHoTro_Goc = 0;
        public long DaLamHoTro = 0;
        //De quan ly nguoi sua, ngay gio sua thong tin 

        public string NoteModify = "";
        public clsDauTu()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsDauTu(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0)
            {
                strSQL = "Insert Into tbl_DauTu" +
                "(HopDongID,DanhMucDauTuID,SoLuong,DonGia,SoTien,LaiSuat,NgayDauTu,GhiChu,DotDauTu,DuNo,NgayBatDauTinhLai,DaThanhToan,VuTrongID,VuTruoc,LaDuNoVuTruoc," +
                "QuanLyVaKhauHaoID,DonViCungUngVatTuID,CreatedBy,DateAdd,SoChungTu,LoaiHinhDauTuID,NoteModify,GhiChuHoTro,SoTienTinhLaiSauHT,HoTroID) Values("
                    + HopDongID.ToString() + "," + DanhMucDauTuID.ToString() + "," + DBModule.RefineNumber(SoLuong) + "," + DBModule.RefineNumber(DonGia) + "," + DBModule.RefineNumber(SoTien)
                    + "," + DBModule.RefineNumber(LaiSuat) + "," + DBModule.RefineDatetime(NgayDauTu, true) + "," + "N'" + DBModule.RefineString(GhiChu) + "'" + "," + DBModule.RefineNumber(DotDauTu)
                    + "," + DBModule.RefineNumber(DuNo) + "," + DBModule.RefineDatetime(NgayBatDauTinhLai, true) + "," + DaThanhToan.ToString()
                    + "," + VuTrongID.ToString() + "," + VuTruoc.ToString() + "," + LaDuNoVuTruoc.ToString() + "," + QuanLyVaKhauHaoID.ToString() + "," + DonViCungUngVatTuID.ToString()
                    + "," + MDSolutionApp.User.ID.ToString() + ",getdate()" + ",N'" + SoChungTu + "'," + LoaiHinhDauTuID.ToString() + ",N'" + DBModule.RefineString(NoteModify) + "'" + ",N'" + DBModule.RefineString(GhiChuHoTro) + "'" + "," + DBModule.RefineNumber(SoTienTinhLaiSauHT) + "," + DBModule.RefineNumber(HoTroID) + ")";
            }
            else // edit object, we update old record in database
            {
                strSQL = "Update tbl_DauTu Set LoaiHinhDauTuID=" + LoaiHinhDauTuID.ToString() + "," + "DanhMucDauTuID=" + DanhMucDauTuID.ToString() + "," + "HopDongID=" + HopDongID.ToString() + ","
                          + "SoLuong=" + DBModule.RefineNumber(SoLuong) + ",DonGia=" + DBModule.RefineNumber(DonGia) + ",SoTien=" + DBModule.RefineNumber(SoTien)
                          + ",LaiSuat=" + DBModule.RefineNumber(LaiSuat) + ",NgayDauTu=" + DBModule.RefineDatetime(NgayDauTu, true) + ",GhiChu=" + "N'" + DBModule.RefineString(GhiChu) + "'"
                          + ",DotDauTu=" + DBModule.RefineNumber(DotDauTu) + ",DuNo=" + DBModule.RefineNumber(DuNo) + ",NgayBatDauTinhLai=" + DBModule.RefineDatetime(NgayBatDauTinhLai, true)
                          + ",DaThanhToan=" + DaThanhToan.ToString() + ",LaDuNoVuTruoc=" + LaDuNoVuTruoc.ToString() + ",QuanLyVaKhauHaoID=" + QuanLyVaKhauHaoID.ToString()
                          + ",DonViCungUngVatTuID=" + DonViCungUngVatTuID.ToString() + ",ModifyBy = " + MDSolutionApp.User.ID.ToString() + ", DataModify = getdate()"
                          + ",NoteModify = N'" + DBModule.RefineString(NoteModify) + "'" + ",GhiChuHoTro = N'" + DBModule.RefineString(GhiChuHoTro) + "'" + ",SoTienTinhLaiSauHT=" + DBModule.RefineNumber(SoTienTinhLaiSauHT) + ",HoTroID=" + DBModule.RefineNumber(HoTroID) + ",SoTienTruHoTro_Goc=" + DBModule.RefineNumber(SoTienTruHoTro_Goc) + " Where ID = " + ID.ToString();
            }
            // run SQL statement

            if (ID <= 0)
            {
                strSQL += ";SELECT @@IDENTITY AS 'Identity';";
                ID = long.Parse(DBModule.ExecuteQueryForOneResult(strSQL, cn, trans));
            }
            else
            {
                DBModule.ExecuteNonQuery(strSQL, cn, trans);
            }

        }
        public static void ChuyenNoDauTu(long iID, long iHopDongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string sql = "Update tbl_DauTu Set HopDongID=" + iHopDongID + " Where ID=" + iID.ToString();
            DBModule.ExecuteNonQuery(sql, null, null);
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            //strSQL = "Delete from tbl_HoTro where DauTuID=" + ID.ToString();
            //// run SQL statement
            //DBModule.ExecuteNonQuery(strSQL, cn, trans);

            strSQL = "Delete from tbl_DauTu where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            

        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            //strSQL = "Delete from tbl_HoTro where DauTuID=" + iID.ToString();
            //// run SQL statement
            //DBModule.ExecuteNonQuery(strSQL, cn, trans);

            strSQL = "Delete from tbl_DauTu where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void DeleteQLKH(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_DauTu where QuanLyVaKhauHaoID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }

        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_DauTu where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("ThuaRuongID"))
                    ThuaRuongID = long.Parse(dr["ThuaRuongID"].ToString());
                if (!dr.IsNull("HopDongID"))
                    HopDongID = long.Parse(dr["HopDongID"].ToString());                
                if (!dr.IsNull("DanhMucDauTuID"))
                    DanhMucDauTuID = long.Parse(dr["DanhMucDauTuID"].ToString());
                if (!dr.IsNull("SoLuong"))
                    SoLuong = decimal.Parse(dr["SoLuong"].ToString());
                if (!dr.IsNull("DonGia"))
                    DonGia = decimal.Parse(dr["DonGia"].ToString());
                if (!dr.IsNull("SoTien"))
                    SoTien = decimal.Parse(dr["SoTien"].ToString());
                if (!dr.IsNull("LaiSuat"))
                    LaiSuat = decimal.Parse(dr["LaiSuat"].ToString());
                if (!dr.IsNull("NgayDauTu"))
                    NgayDauTu = DateTime.Parse(dr["NgayDauTu"].ToString());
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();                
                if (!dr.IsNull("DotDauTu"))
                    DotDauTu = decimal.Parse(dr["DotDauTu"].ToString());
                if (!dr.IsNull("DuNo"))
                    DuNo = long.Parse(dr["DuNo"].ToString());
                if (!dr.IsNull("NgayBatDauTinhLai"))
                    NgayBatDauTinhLai = DateTime.Parse(dr["NgayBatDauTinhLai"].ToString());
                if (!dr.IsNull("DaThanhToan"))
                    DaThanhToan = long.Parse(dr["DaThanhToan"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("VuTruoc"))
                    VuTruoc = long.Parse(dr["VuTruoc"].ToString());
                if (!dr.IsNull("LaDuNoVuTruoc"))
                    LaDuNoVuTruoc = long.Parse(dr["LaDuNoVuTruoc"].ToString());
                if (!dr.IsNull("QuanLyVaKhauHaoID"))
                    QuanLyVaKhauHaoID = long.Parse(dr["QuanLyVaKhauHaoID"].ToString());
                if (!dr.IsNull("NoteModify"))
                    NoteModify = dr["NoteModify"].ToString();
                if (!dr.IsNull("DonViCungUngVatTuID"))
                    DonViCungUngVatTuID = long.Parse(dr["DonViCungUngVatTuID"].ToString());
                if (!dr.IsNull("SoChungTu"))
                    SoChungTu = dr["SoChungTu"].ToString();
                if (!dr.IsNull("LoaiHinhDauTuID"))
                    LoaiHinhDauTuID = long.Parse(dr["LoaiHinhDauTuID"].ToString());
                if (!dr.IsNull("GhiChuHoTro"))
                    GhiChuHoTro = dr["GhiChuHoTro"].ToString();
                if (!dr.IsNull("SoTienTinhLaiSauHT"))
                    SoTienTinhLaiSauHT = decimal.Parse(dr["SoTienTinhLaiSauHT"].ToString());
                if (!dr.IsNull("HoTroID"))
                    HoTroID = long.Parse(dr["HoTroID"].ToString());
                if (!dr.IsNull("SoTienTruHoTro_Goc"))
                    SoTienTruHoTro_Goc = long.Parse(dr["SoTienTruHoTro_Goc"].ToString());
                if (!dr.IsNull("DaLamHoTro"))
                    DaLamHoTro = long.Parse(dr["DaLamHoTro"].ToString());

                
            }

        }
        public void LoadWhere(long HoTroID, OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_DauTu where HoTroID = " + HoTroID + " AND VuTrongID = " + MDSolutionApp.VuTrongID;
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("ThuaRuongID"))
                    ThuaRuongID = long.Parse(dr["ThuaRuongID"].ToString());
                if (!dr.IsNull("HopDongID"))
                    HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("DanhMucDauTuID"))
                    DanhMucDauTuID = long.Parse(dr["DanhMucDauTuID"].ToString());
                if (!dr.IsNull("SoLuong"))
                    SoLuong = decimal.Parse(dr["SoLuong"].ToString());
                if (!dr.IsNull("DonGia"))
                    DonGia = decimal.Parse(dr["DonGia"].ToString());
                if (!dr.IsNull("SoTien"))
                    SoTien = decimal.Parse(dr["SoTien"].ToString());
                if (!dr.IsNull("LaiSuat"))
                    LaiSuat = decimal.Parse(dr["LaiSuat"].ToString());
                if (!dr.IsNull("NgayDauTu"))
                    NgayDauTu = DateTime.Parse(dr["NgayDauTu"].ToString());
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("DotDauTu"))
                    DotDauTu = decimal.Parse(dr["DotDauTu"].ToString());
                if (!dr.IsNull("DuNo"))
                    DuNo = long.Parse(dr["DuNo"].ToString());
                if (!dr.IsNull("NgayBatDauTinhLai"))
                    NgayBatDauTinhLai = DateTime.Parse(dr["NgayBatDauTinhLai"].ToString());
                if (!dr.IsNull("DaThanhToan"))
                    DaThanhToan = long.Parse(dr["DaThanhToan"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("VuTruoc"))
                    VuTruoc = long.Parse(dr["VuTruoc"].ToString());
                if (!dr.IsNull("LaDuNoVuTruoc"))
                    LaDuNoVuTruoc = long.Parse(dr["LaDuNoVuTruoc"].ToString());
                if (!dr.IsNull("QuanLyVaKhauHaoID"))
                    QuanLyVaKhauHaoID = long.Parse(dr["QuanLyVaKhauHaoID"].ToString());
                if (!dr.IsNull("NoteModify"))
                    NoteModify = dr["NoteModify"].ToString();
                if (!dr.IsNull("DonViCungUngVatTuID"))
                    DonViCungUngVatTuID = long.Parse(dr["DonViCungUngVatTuID"].ToString());
                if (!dr.IsNull("SoChungTu"))
                    SoChungTu = dr["SoChungTu"].ToString();
                if (!dr.IsNull("LoaiHinhDauTuID"))
                    LoaiHinhDauTuID = long.Parse(dr["LoaiHinhDauTuID"].ToString());
                if (!dr.IsNull("GhiChuHoTro"))
                    GhiChuHoTro = dr["GhiChuHoTro"].ToString();
                if (!dr.IsNull("SoTienTinhLaiSauHT"))
                    SoTienTinhLaiSauHT = decimal.Parse(dr["SoTienTinhLaiSauHT"].ToString());
                if (!dr.IsNull("HoTroID"))
                    HoTroID = long.Parse(dr["HoTroID"].ToString());
                if (!dr.IsNull("SoTienTruHoTro_Goc"))
                    SoTienTruHoTro_Goc = long.Parse(dr["SoTienTruHoTro_Goc"].ToString());
                if (!dr.IsNull("DaLamHoTro"))
                    DaLamHoTro = long.Parse(dr["DaLamHoTro"].ToString());
            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_DauTu ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_DauTu WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        #endregion

        public static void GetListDot(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select Distinct DotDauTu from tbl_DauTu ORDER BY DotDauTu ASC";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);
            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static void GetListDonVi(string OrderBy, out DataSet ds1, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds1 = null;
            // build SQL statement
            strSQL = "select id,ten from tbl_DonViCungUngVatTu where id<>1";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);
            ds1 = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static void GetListLoaiVatTu(string OrderBy, out DataSet ds1, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds1 = null;
            // build SQL statement
            strSQL = "select id,ten from tbl_DanhMucDauTu";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);
            ds1 = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static void ThayDoiLaiSuat(long dtID, decimal laiSuat, DateTime ngayBatDauTinh, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "UPDATE tbl_DauTu Set LaiSuat=" + DBModule.RefineNumber(laiSuat) + ", NgayBatDauTinhLai=" + DBModule.RefineDatetime(ngayBatDauTinh);
            strSQL += " WHERE ID=" + dtID;
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
    }
}