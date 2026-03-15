
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsNhanVatTu
    {
        public long ID = -1;
        public long HopDongID = -1;
        public long XuatVatTuID = -1;
        public decimal SoLuong = 0;
        public decimal SoLuongThuc = 0;
        public decimal DonGia = 0;
        public decimal SoTien = 0;
        public decimal LaiSuat = 0;
        public DateTime NgayTinhLai = DateTime.Now;
        public long Dot = 0;
        public long VuTrongID = MDSolutionApp.VuTrongID;
        public DateTime NgayNhan = DateTime.Now;
        public long CreateBy = -1;
        public long ModifyBy = -1;
        public DateTime DateModify = DateTime.Now;
        public long BaiTapKetID = -1;
        public decimal DonGiaVanChuyen = 0;
        public decimal TienVanChuyen = 0;
        public string GhiChu = "";
        public long CanBoNongVuID = -1;
        public long DaChuyenDauTu = 0;
        public string NguoiChuyen = "";
        public DateTime NgayChuyen = DateTime.MinValue;
        public long ChuyenNo = 0;
        public DateTime NgayChuyenNo = DateTime.MinValue;
        public long DauTuID = -1;
        public clsNhanVatTu()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsNhanVatTu(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {

                strSQL = "Insert into tbl_NhanVatTu" +
                "(HopDongID,XuatVatTuID,SoLuong,SoLuongThuc,DonGia,SoTien,LaiSuat,NgayTinhLai,Dot,VuTrongID,"+
                "NgayNhan,BaiTapKetID,DonGiaVanChuyen,TienVanChuyen,CreateBy,GhiChu,CanBoNongVuID,DaChuyenDauTu,NguoiChuyen) Values(" +
                     HopDongID.ToString() + "," + XuatVatTuID.ToString() + "," + DBModule.RefineNumber(SoLuong) + "," + DBModule.RefineNumber(SoLuongThuc) + "," + 
                     DBModule.RefineNumber(DonGia) + "," + DBModule.RefineNumber(SoTien) + "," + DBModule.RefineNumber(LaiSuat) + "," + DBModule.RefineDatetime(NgayTinhLai) + "," + 
                     Dot.ToString() + "," + VuTrongID.ToString() + "," + DBModule.RefineDatetime(NgayNhan) + "," + BaiTapKetID.ToString() + "," + 
                     DBModule.RefineNumber(DonGiaVanChuyen) + "," + DBModule.RefineNumber(TienVanChuyen) + ", " + MDSolutionApp.User.ID.ToString() +
                    "," + "N'" + DBModule.RefineString(GhiChu) + "'," +CanBoNongVuID.ToString()+","+DaChuyenDauTu.ToString()+",N'"+NguoiChuyen+"'"+ ")";
            }
            else // edit object, we update old record in database
            {
               strSQL = "Update tbl_NhanVatTu set " +
                        "HopDongID=" + HopDongID.ToString() + "," + "XuatVatTuID=" + XuatVatTuID.ToString() + "," + "SoLuong=" + DBModule.RefineNumber(SoLuong) + "," +
                        "SoLuongThuc=" + DBModule.RefineNumber(SoLuongThuc) + "," + "DonGia=" + DBModule.RefineNumber(DonGia) + "," + "SoTien=" + DBModule.RefineNumber(SoTien) + "," +
                        "LaiSuat=" + DBModule.RefineNumber(LaiSuat) + "," + "NgayTinhLai =" + DBModule.RefineDatetime(NgayTinhLai) + "," + "Dot=" + Dot.ToString() + "," + 
                        "VuTrongID=" + VuTrongID.ToString() + "," + "NgayNhan =" + DBModule.RefineDatetime(NgayNhan) + "," + 
                        "BaiTapKetID=" + BaiTapKetID.ToString() + "," + "DonGiaVanChuyen=" + DBModule.RefineNumber(DonGiaVanChuyen) + "," + 
                        "TienVanChuyen=" + DBModule.RefineNumber(TienVanChuyen) +
                        ", ModifyBy = " + MDSolutionApp.User.ID.ToString() +
                        ", DateModify = getdate() " +
                        "," + "GhiChu=" + "N'" + DBModule.RefineString(GhiChu) + "',CanBoNongVuID=" +CanBoNongVuID.ToString()+
                         "," + "NguoiChuyen=" + "N'" + DBModule.RefineString(NguoiChuyen) + "',DaChuyenDauTu=" + DaChuyenDauTu.ToString() +
                        " Where ID = " + ID.ToString();
            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryForOneResult("SELECT Max(ID) FROM tbl_NhanVatTu", cn, trans));
         
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_NhanVatTu where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);

        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_NhanVatTu where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static bool CheckChuyenDauTu(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Select XuatVatTuID From tbl_NhanVatTu Where DaChuyenDauTu>0 And XuatVatTuID=" + iID.ToString();
            // run SQL statement
            string ret=DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
            if (string.IsNullOrEmpty(ret)) return false; else return true;
        }
        public static void DeleteXuatVatTu(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_NhanVatTu Where XuatVatTuID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void UpDateChuyenDauTu(long iID,string NC, long ID_DauTu,OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Update tbl_NhanVatTu Set DaChuyenDauTu=1,NguoiChuyen=N'"+NC+"',NgayChuyen=GetDate(),DauTuID="+ID_DauTu.ToString()+" Where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void UpDateChuyenNo(long iID, string NC,string NguoiNhanBanDau,long iHopDongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Update tbl_NhanVatTu Set ChuyenNo=1,NguoiChuyenNo=N'" + NC + "',NguoiNhanBanDau=N'"+NguoiNhanBanDau+"',HopDongID="+iHopDongID.ToString()+", NgayChuyenNo=GetDate() Where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
      
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_NhanVatTu where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("HopDongID"))
                    HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("XuatVatTuID"))
                    XuatVatTuID = long.Parse(dr["XuatVatTuID"].ToString());
                if (!dr.IsNull("SoLuong"))
                    SoLuong = decimal.Parse(dr["SoLuong"].ToString());
                if (!dr.IsNull("SoLuongThuc"))
                    SoLuongThuc = decimal.Parse(dr["SoLuongThuc"].ToString());
                if (!dr.IsNull("DonGia"))
                    DonGia = decimal.Parse(dr["DonGia"].ToString());
                if (!dr.IsNull("SoTien"))
                    SoTien = decimal.Parse(dr["SoTien"].ToString());
                if (!dr.IsNull("LaiSuat"))
                    LaiSuat = decimal.Parse(dr["LaiSuat"].ToString());
                if (!dr.IsNull("NgayTinhLai"))
                    NgayTinhLai = DateTime.Parse(dr["NgayTinhLai"].ToString());
                if (!dr.IsNull("Dot"))
                    Dot = long.Parse(dr["Dot"].ToString());
                if (!dr.IsNull("NgayNhan"))
                    NgayNhan = DateTime.Parse(dr["NgayNhan"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("BaiTapKetID"))
                    BaiTapKetID = long.Parse(dr["BaiTapKetID"].ToString());
                if (!dr.IsNull("DonGiaVanChuyen"))
                    DonGiaVanChuyen = decimal.Parse(dr["DonGiaVanChuyen"].ToString());
                if (!dr.IsNull("TienVanChuyen"))
                    TienVanChuyen = decimal.Parse(dr["TienVanChuyen"].ToString());
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("CanBoNongVuID"))
                    CanBoNongVuID = long.Parse(dr["CanBoNongVuID"].ToString());
                if (!dr.IsNull("DaChuyenDauTu"))
                    DaChuyenDauTu = long.Parse(dr["DaChuyenDauTu"].ToString());
             }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_NhanVatTu ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_NhanVatTu WHERE 1=1";
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
            strSQL = "Select Distinct DotDauTu from tbl_NhanVatTu ORDER BY DotDauTu ASC";
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

    }
}