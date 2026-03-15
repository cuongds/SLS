
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsGiaVatTu
    {
        public long ID = -1;
        public long VatTuID = -1;       
        public decimal DonGia = 0;
        public DateTime NgayApDung = DateTime.Now;
        public long IsActive = 0;
        public long VuTrongID = -1;
        public long CreateBy = -1;
        public long ModifyBy = -1;
        public DateTime DateModify = DateTime.Now;
        public string GhiChu = "";
        public clsGiaVatTu()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsGiaVatTu(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {

                strSQL = "Insert into tbl_GiaVatTu" +
                "(VatTuID,DonGia,NgayApDung,IsActive,VuTrongID,CreateBy) Values(" +
                     VatTuID.ToString() + "," + DonGia.ToString() + "," + DBModule.RefineDatetime(NgayApDung) + "," + IsActive.ToString() + "," + VuTrongID.ToString() + 
                    "," + MDSolutionApp.User.ID.ToString() + ")";
            }
            else // edit object, we update old record in database
            {
               strSQL = "Update tbl_GiaVatTu set " +
                    "VatTuID=" + VatTuID.ToString() + "," + "DonGia=" + DonGia.ToString() + "," + "NgayApDung =" + DBModule.RefineDatetime(NgayApDung) + "," + "IsActive=" + IsActive.ToString() + "," + "VuTrongID=" + VuTrongID.ToString() + 
                    ", ModifyBy = " + MDSolutionApp.User.ID.ToString() +
                ", DateModify = getdate() " +
                "," + "GhiChu=" + "N'" + DBModule.RefineString(GhiChu) + "'" +
                " Where ID = " + ID.ToString();
            }
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryForOneResult("SELECT Max(ID) FROM tbl_GiaVatTu", cn, trans));
       }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            strSQL = "Delete from tbl_GiaVatTu where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);

        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "Delete from tbl_GiaVatTu where VatTuID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
    
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_GiaVatTu where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("VatTuID"))
                    VatTuID = long.Parse(dr["VatTuID"].ToString());
                if (!dr.IsNull("DonGia"))
                    DonGia = decimal.Parse(dr["DonGia"].ToString());
                if (!dr.IsNull("NgayApDung"))
                    NgayApDung = DateTime.Parse(dr["NgayApDung"].ToString());
                if (!dr.IsNull("IsActive"))
                    IsActive = long.Parse(dr["IsActive"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();

            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_GiaVatTu ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_GiaVatTu WHERE 1=1";
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
            strSQL = "Select Distinct DotDauTu from tbl_GiaVatTu ORDER BY DotDauTu ASC";
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