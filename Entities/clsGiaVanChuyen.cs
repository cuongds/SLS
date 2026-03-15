using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;

namespace MDSolution
{
    class clsGiaVanChuyen
    {
        public long ID = -1;
        public string Ten = "";
        public DateTime NgayGioApDung = DateTime.Now;
        public DateTime NgayGioHetHan = DateTime.Now;
        public float DonGiaCu = 0;
        public float DonGia = 0;
        public float GiaTriTangGiam = 0;
        public long VuTrongID = 0;
        public long BaiTapKetID = 0;
        public long Dot = 0;
        public long SelectedValue=0;        
         public clsGiaVanChuyen()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsGiaVanChuyen(long lID)
        {
            ID = lID;
        }
        //#region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                //id = lddata.DBModule.GetNewID(typeof(DanhMucDauTu), "tbl_DanhMucDauTu", cn, trans);
                ID = DBModule.GetNewID(typeof(clsGiaVanChuyen), "tbl_GiaVanChuyen", cn, trans);
                //NgayTao = DateTime.Now;        
                //NgaySua = DateTime.Now;        
                // build SQL statement
                strSQL = "Insert into tbl_GiaVanChuyen" +
                "(ID,Ten,NgayGioApDung,NgayGioHetHan,DonGiaCu,DonGia,GiaTriTangGiam,VuTrongID,BaiTapKetID,Dot,SelectedValue) Values(" +
                    ID.ToString() + "," + "N'" + DBModule.RefineString(Ten) + "'" + DBModule.RefineDatetime(NgayGioApDung) + "'" + DBModule.RefineDatetime(NgayGioHetHan) + "'" + DonGiaCu.ToString() + "," + DonGia.ToString() + "," + GiaTriTangGiam.ToString() + "," + VuTrongID.ToString() + "," + BaiTapKetID.ToString() + "," + Dot.ToString() + "," + SelectedValue.ToString() + ")";
            }
            else // edit object, we update old record in database
            {
                // build SQL statement				    
                //NgaySua = DateTime.Now;        
                strSQL = "Update tbl_GiaVanChuyen set " +
                    "Ten=" + "N'" + DBModule.RefineString(Ten) + "'" + "," + "NgayGioApDung=" + "'" + DBModule.RefineDatetime(NgayGioApDung) + "'" + "NgayGioHetHan=" + "'" + DBModule.RefineDatetime(NgayGioHetHan) + "'" + "DonGiaCu=" + DonGiaCu.ToString() + "," + "DonGia=" + DonGia.ToString() + "," + "GiaTriTangGiam=" + GiaTriTangGiam.ToString() + "," + "VuTrongID=" + VuTrongID.ToString() + "," + "BaiTapKetID=" + VuTrongID.ToString() + "," + "Dot=" + Dot.ToString() + "," + "SelectedValue=" + SelectedValue.ToString() +
                    " Where ID = " + ID.ToString();
            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_DanhMucDauTu", cn, trans));
                */
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_GiaVanChuyen where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_GiaVanChuyen where ID=" + ID.ToString();
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
                if (!dr.IsNull("NgayGioApDung"))
                    NgayGioApDung = DateTime.Parse(dr["NgayGioApDung"].ToString());
                if (!dr.IsNull("NgayGioHetHan"))
                    NgayGioHetHan = DateTime.Parse(dr["NgayGioHetHan"].ToString());                
                if (!dr.IsNull("DonGiaCu"))
                    DonGiaCu = float.Parse(dr["DonGiaCu"].ToString());
                if (!dr.IsNull("DonGia"))
                    DonGia = float.Parse(dr["DonGia"].ToString());
                if (!dr.IsNull("GiaTriTangGiam"))
                    GiaTriTangGiam = float.Parse(dr["GiaTriTangGiam"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("BaiTapKetID"))
                    BaiTapKetID = long.Parse(dr["BaiTapKetID"].ToString());
                if (!dr.IsNull("Dot"))
                    Dot = long.Parse(dr["Dot"].ToString());
                if (!dr.IsNull("SelectedValue"))
                    SelectedValue = long.Parse(dr["SelectedValue"].ToString());               
            }
            

        }

        #region
        //public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        //{
        //    string strSQL = "";
        //    // build SQL statement
        //    strSQL = "Delete from tbl_DanhMucDauTu where ID=" + iID.ToString();
        //    // run SQL statement
        //    DBModule.ExecuteNonQuery(strSQL, cn, trans);
        //}
       

        //public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        //{
        //    string strSQL = "";
        //    ds = null;
        //    // build SQL statement
        //    strSQL = "Select * from tbl_DanhMucDauTu ";
        //    if ((OrderBy != null) && (OrderBy != ""))
        //        strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

        //    ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        //}
        //public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        //{
        //    if (strFields == "") strFields = "*";
        //    string strSQL = "SELECT " + strFields + " FROM tbl_DanhMucDauTu WHERE 1=1";
        //    if (strWhere != "") strSQL += " AND " + strWhere;
        //    if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
        //    return DBModule.ExecuteQuery(strSQL, cn, trans);
        //}
        #endregion
    }
}
