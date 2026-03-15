
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsUngVatTuVanChuyen
    {
        public long ID = -1;
        public long HopDongVanChuyenID = -1;
        public long XeID = -1;
        public long VatTuID = -1;
        public decimal SoLuong = 0;
        public decimal DonGia = 0;
        public DateTime NgayUng = DateTime.MinValue;
        public string SoChungTu = "";
        public string DaThanhToan = "";
        public long VuTrongID = -1;
        public decimal SoTien = 0;
        public string GhiChu = "";
        public string BangChu = "";
        public long NoiTamUngVatTuID = -1;
        public long Xoa = 0;

        //De quan ly nguoi sua, ngay gio sua thong tin 
      
        public string NoteModify = "";
        public clsUngVatTuVanChuyen()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsUngVatTuVanChuyen(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                          
                strSQL = " Insert into tbl_UngVatTuVanChuyen" +
          "(HopDongVanChuyenID,XeID,VatTuID,SoLuong,DonGia,NgayUng,SoChungTu,DaThanhToan,VuTrongID,SoTien,GhiChu,BangChu,CreatedBy,DateAdd,Xoa) Values("
               + HopDongVanChuyenID.ToString() + "," + XeID.ToString() + "," + VatTuID.ToString() + "," + SoLuong.ToString() + "," + DonGia.ToString() + "," + DBModule.RefineDatetime(NgayUng) + "," + "N'" + DBModule.RefineString(SoChungTu) + "'" + "," + "N'" + DBModule.RefineString(DaThanhToan) + "'" + "," + VuTrongID.ToString() + "," + SoTien.ToString() + "," + "N'" + DBModule.RefineString(GhiChu) + "'" + "," + "N'" + DBModule.RefineString(BangChu) + "'"+
               ", " + MDSolutionApp.User.ID.ToString() + ", getdate()" + "," + Xoa.ToString() + ")";                

            }
            else // edit object, we update old record in database
            {
                strSQL = "Update tbl_UngVatTuVanChuyen Set " +
                    "HopDongVanChuyenID=" + HopDongVanChuyenID.ToString() + "," + "XeID=" + XeID.ToString() + "," + "VatTuID=" + VatTuID.ToString() + "," + "SoLuong=" + SoLuong.ToString() + "," + "DonGia=" + DonGia.ToString() + "," + "NgayUng=" + DBModule.RefineDatetime(NgayUng) + "," + "SoChungTu=" + "N'" + DBModule.RefineString(SoChungTu) + "'" + "," + "DaThanhToan=" + "N'" + DBModule.RefineString(DaThanhToan) + "'" + "," + "VuTrongID=" + VuTrongID.ToString() + "," + "SoTien=" + SoTien.ToString() + "," + "GhiChu=" + "N'" + DBModule.RefineString(GhiChu) + "'" + "," + "BangChu=" + "N'" + DBModule.RefineString(BangChu) + "'" + "," + "NoiTamUngVatTuID=" + NoiTamUngVatTuID.ToString() +
                    ", ModifyBy = " + MDSolutionApp.User.ID.ToString() +
                ", DataModify = getdate() " +
                ", NoteModify = '" + DBModule.RefineString(NoteModify) + "'" +
                " Where ID = " + ID.ToString();

            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            if( ID <= 0 )ID = long.Parse(DBModule.ExecuteQueryForOneResult("SELECT Max(ID) FROM tbl_UngVatTuVanChuyen", cn, trans));
                
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_UngVatTuVanChuyen where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_UngVatTuVanChuyen where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void UpdateDelete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Update tbl_UngVatTuVanChuyen Set Xoa=1 Where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_UngVatTuVanChuyen where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("HopDongVanChuyenID"))
                    HopDongVanChuyenID = long.Parse(dr["HopDongVanChuyenID"].ToString());
                if (!dr.IsNull("XeID"))
                    XeID = long.Parse(dr["XeID"].ToString());
                if (!dr.IsNull("VatTuID"))
                    VatTuID = long.Parse(dr["VatTuID"].ToString());
                if (!dr.IsNull("SoLuong"))
                    SoLuong = decimal.Parse(dr["SoLuong"].ToString());
                if (!dr.IsNull("DonGia"))
                    DonGia = decimal.Parse(dr["DonGia"].ToString());
                if (!dr.IsNull("NgayUng"))
                    NgayUng = DateTime.Parse(dr["NgayUng"].ToString());
                if (!dr.IsNull("SoChungTu"))
                    SoChungTu = dr["SoChungTu"].ToString();
                if (!dr.IsNull("DaThanhToan"))
                    DaThanhToan = dr["DaThanhToan"].ToString();
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("SoTien"))
                    SoTien = decimal.Parse(dr["SoTien"].ToString());
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("BangChu"))
                    BangChu = dr["BangChu"].ToString();
                if (!dr.IsNull("NoiTamUngVatTuID"))
                {
                    NoiTamUngVatTuID = long.Parse(dr["NoiTamUngVatTuID"].ToString());
                }
                else { NoiTamUngVatTuID = 0; }
            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_UngVatTuVanChuyen ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_UngVatTuVanChuyen WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        #endregion
        #region Extend Functions
        public static DataSet GetListThongTinTUByHopDongVanChuyenID(long VuTrongID, long mHDID, string OrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Select * from V_UngVatTuVanChuyen ";
            strSQL += "Where HopDongVanChuyenID = " + mHDID.ToString();
            strSQL += "AND VuTrongID = " + VuTrongID.ToString();
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        #endregion
    }
}