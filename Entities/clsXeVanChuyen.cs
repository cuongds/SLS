
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsXeVanChuyen
    {
        public long ID = -1;
        public string SoXe = "";
        public string TenLaiXe = "";
        public string LoaiXe = "";
        public decimal TrongTai = 0;
        public string GhiChu = "";
        public long HopDongVanChuyenID = -1;
        public string MaSoXe = "";
        public long VuTrongID =-1;
        public string NoteModify = "";

        public clsXeVanChuyen()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsXeVanChuyen(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                strSQL = "Insert into tbl_XeVanChuyen" +
                "(SoXe,TenLaiXe,LoaiXe,TrongTai,GhiChu,HopDongVanChuyenID,MaSoXe,CreatedBy,DateAdd,VuTrongID) Values(" +
                  "N'" + DBModule.RefineString(SoXe) + "'" + "," +
                  "N'" + DBModule.RefineString(TenLaiXe) + "'" + "," + 
                  "N'" + DBModule.RefineString(LoaiXe) + "'" + "," + TrongTai.ToString() + "," +
                  "N'" + DBModule.RefineString(GhiChu) + "'" + "," + HopDongVanChuyenID.ToString() + "," +
                  "N'" + DBModule.RefineString(MaSoXe) + "'" +
                  "," + MDSolutionApp.User.ID.ToString() +
                  ", getdate()" +
                   "," + MDSolutionApp.VuTrongID.ToString() +
                  ")";                
            }
            else // edit object, we update old record in database
            {
               strSQL = "Update tbl_XeVanChuyen set " +
                    "SoXe=" + "N'" + DBModule.RefineString(SoXe) + "'" + "," +
                    "TenLaiXe=N'" + DBModule.RefineString(TenLaiXe) + "'" + "," + 
                    "LoaiXe=N'" + DBModule.RefineString(LoaiXe) + "'" + "," + 
                    "TrongTai=" + TrongTai.ToString() + "," + 
                    "GhiChu=N'" + DBModule.RefineString(GhiChu) + "'" + "," + 
                    "HopDongVanChuyenID=" + HopDongVanChuyenID.ToString() + "," + 
                    "MaSoXe=N'" + DBModule.RefineString(MaSoXe) + "'" +
                    ", ModifyBy = " + MDSolutionApp.User.ID.ToString() +
                    ", DataModify = getdate() " +
                    ", NoteModify = N'" + DBModule.RefineString(NoteModify) +"'"+
                    " Where ID = " + ID.ToString();
            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_XeVanChuyen", cn, trans));
                */
        }
        public void ChuyenVu(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                strSQL = "Insert into tbl_XeVanChuyen" +
                "(SoXe,TenLaiXe,LoaiXe,TrongTai,GhiChu,HopDongVanChuyenID,MaSoXe,CreatedBy,DateAdd,VuTrongID) Values(" +
                  "N'" + DBModule.RefineString(SoXe) + "'" + "," +
                  "N'" + DBModule.RefineString(TenLaiXe) + "'" + "," +
                  "N'" + DBModule.RefineString(LoaiXe) + "'" + "," + TrongTai.ToString() + "," +
                  "N'" + DBModule.RefineString(GhiChu) + "'" + "," + HopDongVanChuyenID.ToString() + "," +
                  "N'" + DBModule.RefineString(MaSoXe) + "'" +
                  "," + MDSolutionApp.User.ID.ToString() +
                  ", getdate()" +
                   "," + VuTrongID.ToString() +
                  ")";
            }
           
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_XeVanChuyen", cn, trans));
                */
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_XeVanChuyen where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_XeVanChuyen where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static long GetXeVuTrong(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            long VTID=-1;
            // build SQL statement
            strSQL = "Select VuTrongID from tbl_XeVanChuyen where ID=" + iID.ToString();
            // run SQL statement
            try
            {
                VTID = long.Parse(DBModule.ExecuteQueryForOneResult(strSQL, cn, trans));
            }
            catch { }
            return VTID;
        }
        public static long GetXeHopDong(long iID, OleDbConnection cn, OleDbTransaction trans)
        {        
            string strSQL = "";
            long HDVCID=-1;
            // build SQL statement
            strSQL = "Select HopDongVanChuyenID from tbl_XeVanChuyen where ID=" + iID.ToString();
            // run SQL statement
            try
            {
                HDVCID = long.Parse(DBModule.ExecuteQueryForOneResult(strSQL, cn, trans));
            }
            catch { }
            return HDVCID;
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_XeVanChuyen where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("SoXe"))
                    SoXe = dr["SoXe"].ToString();
                if (!dr.IsNull("TenLaiXe"))
                    TenLaiXe = dr["TenLaiXe"].ToString();
                if (!dr.IsNull("LoaiXe"))
                    LoaiXe = dr["LoaiXe"].ToString();
                if (!dr.IsNull("TrongTai"))
                    TrongTai = decimal.Parse(dr["TrongTai"].ToString());
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("HopDongVanChuyenID"))
                    HopDongVanChuyenID = long.Parse(dr["HopDongVanChuyenID"].ToString());
                if (!dr.IsNull("MaSoXe"))
                    MaSoXe = dr["MaSoXe"].ToString();
                   if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
            }

        }
        public void Load(long HopDongVanChuyenID, OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_XeVanChuyen where HopDongVanChuyenID=" + HopDongVanChuyenID.ToString();
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("SoXe"))
                    SoXe = dr["SoXe"].ToString();
                if (!dr.IsNull("TenLaiXe"))
                    TenLaiXe = dr["TenLaiXe"].ToString();
                if (!dr.IsNull("LoaiXe"))
                    LoaiXe = dr["LoaiXe"].ToString();
                if (!dr.IsNull("TrongTai"))
                    TrongTai = decimal.Parse(dr["TrongTai"].ToString());
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("HopDongVanChuyenID"))
                    HopDongVanChuyenID = long.Parse(dr["HopDongVanChuyenID"].ToString());
                if (!dr.IsNull("MaSoXe"))
                    MaSoXe = dr["MaSoXe"].ToString();
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_XeVanChuyen ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + ",(TrongTai/1000)AS TrongTai1 FROM tbl_XeVanChuyen WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }

        public static DataSet GetListXeVanChuyenByHopDongVanChuyenID(long mHDID, string OrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Select * from tbl_XeVanChuyen ";
            strSQL += "Where HopDongVanChuyenID = " + mHDID.ToString();
            // strSQL += "AND VuTrongID = " + VuTrongID.ToString();
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        #endregion
    }
}