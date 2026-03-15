
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsHoanUngVanChuyen
    {
        public long ID = -1;
        public long HopDongVanChuyenID = -1;
        public long XeID = -1;
        public decimal SoTien = 0;
        public DateTime NgayNhap = DateTime.MinValue;
        public string SoChungTu = "";
        public long VuTrongID = -1;
        public string GhiChu = "";
        public long  CreatedBy =-1;
	    public long ModifyBy =-1;
	    public DateTime DateAdded = DateTime.Now;
        public DateTime DataModify = DateTime.Now;
        public string NoteModify = "";
        public long Status = -1;
        public clsHoanUngVanChuyen()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsHoanUngVanChuyen(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                //id = lddata.DBModule.GetNewID(typeof(HoTro), "tbl_HoanUngVanChuyen", cn, trans);
                ID = DBModule.GetNewID(typeof(clsHoanUngVanChuyen), "tbl_HoanUngVanChuyen", cn, trans);
                //NgayTao = DateTime.Now;        
                //NgaySua = DateTime.Now;        
                // build SQL statement
                strSQL = "Insert into tbl_HoanUngVanChuyen" +
                "(ID,HopDongVanChuyenID,XeID,SoTien,NgayNhap,SoChungTu,VuTrongID,GhiChu,CreatedBy,ModifyBy,DateAdded,DataModify,NoteModify,Status) Values(" +
                    ID.ToString() + "," + HopDongVanChuyenID.ToString() + "," + XeID.ToString() + "," + SoTien.ToString() + "," + DBModule.RefineDatetime(NgayNhap) + "," + "N'" + DBModule.RefineString(SoChungTu) + "'" + "," + VuTrongID.ToString() + ",N'" + DBModule.RefineString(GhiChu) + "'" +                     
                    ", " + MDSolutionApp.User.ID.ToString() +
                    ", " + MDSolutionApp.User.ID.ToString() +
                    ", getdate()" +
                    ", getdate() " +
                    ", N'" + DBModule.RefineString(NoteModify) + "'" +                    
                     "," + Status.ToString() + 
                    ")";
            }
            else // edit object, we update old record in database
            {
                // build SQL statement				    
                //NgaySua = DateTime.Now;        
                strSQL = "Update tbl_HoanUngVanChuyen set " +
                    "HopDongVanChuyenID=" + HopDongVanChuyenID.ToString() + "," + "XeID=" + XeID.ToString() + "," + "SoTien=" + SoTien.ToString() + "," + "NgayNhap=" + DBModule.RefineDatetime(NgayNhap) + "," 
                    + "GhiChu=" + "N'" + DBModule.RefineString(GhiChu) + "'" + 
                    ", ModifyBy = " + MDSolutionApp.User.ID.ToString() +
                    ", DataModify = getdate() " +
                    ", NoteModify = '" + DBModule.RefineString(NoteModify) + "'" +
                    ", SoChungTu = '" + DBModule.RefineString(SoChungTu) + "'" +
                    ", Status = " + Status.ToString() +
                    " Where ID = " + ID.ToString();
            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_HoanUngVanChuyen", cn, trans));
                */
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_HoanUngVanChuyen where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_HoanUngVanChuyen where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void DeleteLoaiHinh(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_HoanUngVanChuyen where HoTroTheoLoaiHinhID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_HoanUngVanChuyen where ID=" + ID.ToString();            
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("HopDongVanChuyenID"))
                    HopDongVanChuyenID = long.Parse(dr["HopDongVanChuyenID"].ToString());
                if (!dr.IsNull("XeID"))
                    XeID = long.Parse(dr["XeID"].ToString());
                if (!dr.IsNull("SoTien"))
                    SoTien = long.Parse(dr["SoTien"].ToString());
                if (!dr.IsNull("NgayNhap"))
                    NgayNhap = DateTime.Parse(dr["NgayNhap"].ToString());                                                                                                       
                if (!dr.IsNull("SoChungTu"))
                    SoChungTu = dr["SoChungTu"].ToString();
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("CreatedBy"))
                    CreatedBy = long.Parse(dr["CreatedBy"].ToString());
                if (!dr.IsNull("ModifyBy"))
                    ModifyBy = long.Parse(dr["ModifyBy"].ToString());
                if (!dr.IsNull("DataModify"))
                    DataModify = DateTime.Parse(dr["DataModify"].ToString());
                if (!dr.IsNull("DateAdded"))
                    DateAdded = DateTime.Parse(dr["DateAdded"].ToString());
                if (!dr.IsNull("NoteModify"))
                    NoteModify = dr["NoteModify"].ToString();
                if (!dr.IsNull("Status"))
                    Status = long.Parse(dr["Status"].ToString());
            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_HoanUngVanChuyen ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_HoanUngVanChuyen WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        #endregion        
    }
}