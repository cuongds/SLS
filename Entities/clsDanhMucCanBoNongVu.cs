
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsDanhMucCanBoNongVu
    {
        public long ID = -1;
        public string Ma = "";
        public string Ten = "";
        public string DienThoai = "";
        public long ApDungNhieu = 0;
        public long ThuTu = 0;
        public long ThonID = 0;
        public long IsActive = 0;
        public clsDanhMucCanBoNongVu()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsDanhMucCanBoNongVu(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                try
                {
                    ID = long.Parse(DBModule.ExecuteQueryForOneResult("SELECT Max(ID) FROM tbl_DanhMucCanBoNongVu", cn, trans));
                }
                catch
                {
                    ID = 1;
                }
                ID = ID + 1;
                strSQL = "Insert into tbl_DanhMucCanBoNongVu" +
                "(ID,Ma,Ten,DienThoai,ThuTu,ThonID,IsActive) Values(" +
                 ID.ToString() +    ",N'" + DBModule.RefineString(Ma) + "'" + "," + "N'" + DBModule.RefineString(Ten) + "'" + "," + "N'" + DBModule.RefineString(DienThoai) + "'" + "," + ThuTu.ToString() + "," + ThonID.ToString() + "," + IsActive.ToString() + ")";
            }
            else // edit object, we update old record in database
            {
                    strSQL = "Update tbl_DanhMucCanBoNongVu set " +
                    "Ma=" + "N'" + DBModule.RefineString(Ma) + "'" + "," + "Ten=" + "N'" + DBModule.RefineString(Ten) + "'" + "," + "DienThoai=" + "N'" + DBModule.RefineString(DienThoai) + "'" +  "," + "ThuTu=" + ThuTu.ToString() + "," + "ThonID=" + ThonID.ToString() + "," + "IsActive=" + IsActive.ToString() +
                    " Where ID = " + ID.ToString();
            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_DanhMucCanBoNongVu", cn, trans));
                */
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_DanhMucCanBoNongVu where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_DanhMucCanBoNongVu where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_DanhMucCanBoNongVu where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("Ma"))
                    Ma = dr["Ma"].ToString();
                if (!dr.IsNull("Ten"))
                    Ten = dr["Ten"].ToString();
                if (!dr.IsNull("DienThoai"))
                    DienThoai = dr["DienThoai"].ToString();
                if (!dr.IsNull("ThuTu"))
                    ThuTu = long.Parse(dr["ThuTu"].ToString());
                if (!dr.IsNull("ThonID"))
                    ThonID = long.Parse(dr["ThonID"].ToString());
                if (!dr.IsNull("IsActive"))
                    IsActive = long.Parse(dr["IsActive"].ToString());
            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_DanhMucCanBoNongVu ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_DanhMucCanBoNongVu WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        #endregion
      }
}