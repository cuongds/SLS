
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsNhanVatTuThon
    {
        public long ID = -1;
        public long XuatVatTuID = -1;
        public long VatTuID = -1;
        public long SoLuong = 0;
        public float DonGia = 0;
        public decimal SoTien = 0;
        public long VuTrongID = -1;
        public DateTime NgayNhan = DateTime.Now;
        public long BaiTapKetID = -1;
        public long ThonID = -1;
        public decimal DonGiaVanChuyen = 0;
        public decimal TienVanChuyen = 0;
        public long CreateBy = -1;
        public long ModifyBy = -1;
        public DateTime DateModify = DateTime.Now;
        public string GhiChu = "";
        public clsNhanVatTuThon()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsNhanVatTuThon(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {

                strSQL = "Insert into tbl_NhanVatTuThon" +
                "(XuatVatTuID,VatTuID,SoLuong,DonGia,SoTien,VuTrongID,NgayNhan,BaiTapKetID,ThonID,DonGiaVanChuyen,TienVanChuyen, CreateBy, ModifyBy, DateModify,GhiChu) Values(" +
                     XuatVatTuID.ToString() + "," + VatTuID.ToString() + "," + SoLuong.ToString() + "," + DonGia.ToString() + "," + SoTien.ToString() + ","  + VuTrongID.ToString() + "," + DBModule.RefineDatetime(NgayNhan) + "," + BaiTapKetID.ToString() + "," + ThonID.ToString() + "," + DonGiaVanChuyen.ToString() + "," + TienVanChuyen.ToString() +
                    ", " + MDSolutionApp.User.ID.ToString() +
                    ", " + MDSolutionApp.User.ID.ToString() +
                    ", getdate()" +
                   "," + "N'" + DBModule.RefineString(GhiChu) + "'" + ")";
            }
            else // edit object, we update old record in database
            {
                // build SQL statement				    
                //NgaySua = DateTime.Now;        
                strSQL = "Update tbl_NhanVatTuThon set " +
                    "XuatVatTuID=" + XuatVatTuID.ToString() + "," + "VatTuID=" + VatTuID.ToString() + "," + "SoLuong=" + SoLuong.ToString() + "," + "DonGia=" + DonGia.ToString() + "," + "SoTien=" + SoTien.ToString() + ","  + "VuTrongID=" + VuTrongID.ToString() + "," + "NgayNhan =" + DBModule.RefineDatetime(NgayNhan) + "," + "BaiTapKetID=" + BaiTapKetID.ToString() + "," + "ThonID=" + ThonID.ToString() + "," + "DonGiaVanChuyen=" + DonGiaVanChuyen.ToString() + "," + "TienVanChuyen=" + TienVanChuyen.ToString() +
                    ", ModifyBy = " + MDSolutionApp.User.ID.ToString() +
                ", DateModify = getdate() " +
                "," + "GhiChu=" + "N'" + DBModule.RefineString(GhiChu) + "'" +
                " Where ID = " + ID.ToString();
            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_NhanVatTuThon", cn, trans));
                */
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_HoTro where DauTuID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);

            strSQL = "Delete from tbl_NhanVatTuThon where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);

        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_HoTro where DauTuID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);

            strSQL = "Delete from tbl_NhanVatTuThon where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void DeleteQLKH(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_NhanVatTuThon where QuanLyVaKhauHaoID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }

        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_NhanVatTuThon where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("XuatVatTuID"))
                    XuatVatTuID = long.Parse(dr["XuatVatTuID"].ToString());              
                if (!dr.IsNull("VatTuID"))
                    VatTuID = long.Parse(dr["VatTuID"].ToString());
                if (!dr.IsNull("SoLuong"))
                    SoLuong = long.Parse(dr["SoLuong"].ToString());
                if (!dr.IsNull("DonGia"))
                    DonGia = float.Parse(dr["DonGia"].ToString());
                if (!dr.IsNull("SoTien"))
                    SoTien = decimal.Parse(dr["SoTien"].ToString());
                if (!dr.IsNull("NgayNhan"))
                    NgayNhan = DateTime.Parse(dr["NgayNhan"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("BaiTapKetID"))
                    BaiTapKetID = long.Parse(dr["BaiTapKetID"].ToString());
                if (!dr.IsNull("ThonID"))
                    ThonID = long.Parse(dr["ThonID"].ToString());
                if (!dr.IsNull("DonGiaVanChuyen"))
                    DonGiaVanChuyen = decimal.Parse(dr["DonGiaVanChuyen"].ToString());
                if (!dr.IsNull("TienVanChuyen"))
                    TienVanChuyen = decimal.Parse(dr["TienVanChuyen"].ToString());
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_NhanVatTuThon ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_NhanVatTuThon WHERE 1=1";
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
            strSQL = "Select Distinct DotDauTu from tbl_NhanVatTuThon ORDER BY DotDauTu ASC";
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