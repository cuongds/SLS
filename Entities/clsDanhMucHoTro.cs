
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsDanhMucHoTro
    {
        public long ID = -1;
        public string Ten = "";
        public string GhiChu = "";
        public long LoaiHoTro = 0;
        public long TuongUngDanhMucDauTu = 0;
        public long TinhTheo = 0;
        public string DonViTinh = "";
        public clsDanhMucHoTro()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsDanhMucHoTro(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(long DT_ID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                //id = lddata.DBModule.GetNewID(typeof(DanhMucHoTro), "tbl_DanhMucHoTro", cn, trans);
                //ID = DBModule.GetNewID(typeof(clsDanhMucHoTro), "tbl_DanhMucHoTro", cn, trans);
                ID = DT_ID;
                //NgayTao = DateTime.Now;        
                //NgaySua = DateTime.Now;        
                // build SQL statement
                strSQL = "Insert into tbl_DanhMucHoTro" +
                "(ID,Ten,GhiChu,LoaiHoTro,TuongUngDanhMucDauTu,TinhTheo) Values(" +
                    ID.ToString() + "," + "N'" + DBModule.RefineString(Ten) + "'" + "," + "N'" + DBModule.RefineString(GhiChu) + "'" + "," + LoaiHoTro.ToString() + "," + TuongUngDanhMucDauTu.ToString() + "," + TinhTheo.ToString() + ")";
            }
            else // edit object, we update old record in database
            {
                // build SQL statement				    
                //NgaySua = DateTime.Now;        
                strSQL = "Update tbl_DanhMucHoTro set " +
                    "Ten=" + "N'" + DBModule.RefineString(Ten) + "'" + "," + "GhiChu=" + "N'" + DBModule.RefineString(GhiChu) + "'" + "," + "LoaiHoTro=" + LoaiHoTro.ToString() + "," + "TuongUngDanhMucDauTu=" + TuongUngDanhMucDauTu.ToString() + "," + "TinhTheo=" + TinhTheo.ToString() +
                    " Where ID = " + ID.ToString();
            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_DanhMucHoTro", cn, trans));
                */
        }
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                //id = lddata.DBModule.GetNewID(typeof(DanhMucHoTro), "tbl_DanhMucHoTro", cn, trans);
                //ID = DBModule.GetNewID(typeof(clsDanhMucHoTro), "tbl_DanhMucHoTro", cn, trans);
                ID = DBModule.GetNewID(typeof(clsDanhMucHoTro), "tbl_DanhMucHoTro", cn, trans);
                //NgayTao = DateTime.Now;        
                //NgaySua = DateTime.Now;        
                // build SQL statement
                strSQL = "Insert into tbl_DanhMucHoTro" +
                "(ID,Ten,GhiChu,LoaiHoTro,TuongUngDanhMucDauTu,TinhTheo,DonViTinh) Values(" +
                    ID.ToString() + "," + "N'" + DBModule.RefineString(Ten) + "'" + "," + "N'" + DBModule.RefineString(GhiChu) + "'" + "," + LoaiHoTro.ToString() + "," + TuongUngDanhMucDauTu.ToString() + "," + TinhTheo.ToString() +  "," + "N'" + DBModule.RefineString(DonViTinh) + "'"+")";
            }
            else // edit object, we update old record in database
            {
                // build SQL statement				    
                //NgaySua = DateTime.Now;        
                strSQL = "Update tbl_DanhMucHoTro set " +
                    "Ten=" + "N'" + DBModule.RefineString(Ten) + "'" + "," + "GhiChu=" + "N'" + DBModule.RefineString(GhiChu) + "'" + "," + "LoaiHoTro=" + LoaiHoTro.ToString() + "," + "TuongUngDanhMucDauTu=" + TuongUngDanhMucDauTu.ToString() + "," + "TinhTheo=" + TinhTheo.ToString() +  ", DonViTinh=" + "N'" + DBModule.RefineString(DonViTinh) + "'"+
                    " Where ID = " + ID.ToString();
            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_DanhMucHoTro", cn, trans));
                */
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_DanhMucHoTro where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_DanhMucHoTro where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_DanhMucHoTro where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("Ten"))
                    Ten = dr["Ten"].ToString();
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("LoaiHoTro"))
                    LoaiHoTro = long.Parse(dr["LoaiHoTro"].ToString());
                if (!dr.IsNull("TuongUngDanhMucDauTu"))
                    TuongUngDanhMucDauTu = long.Parse(dr["TuongUngDanhMucDauTu"].ToString());
                if (!dr.IsNull("TinhTheo"))
                    TinhTheo = long.Parse(dr["TinhTheo"].ToString());
                if (!dr.IsNull("DonViTinh"))
                    DonViTinh = dr["DonViTinh"].ToString();
            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_DanhMucHoTro ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static void GetListDanhMuc(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_DanhMucHoTro WHERE TuongUngDanhMucDauTu <> 1";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_DanhMucHoTro WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        #endregion
    }
}