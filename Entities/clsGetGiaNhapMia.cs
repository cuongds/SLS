
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsGetGiaNhapMia
    {
        public long ID = -1;
        public long DonGia = -1;
        public long VuTrongID = -1;
        public long SelectedValue = -1;
        public clsGetGiaNhapMia()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsGetGiaNhapMia(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                //id = lddata.DBModule.GetNewID(typeof(GiaNhapMia), "tbl_GiaNhapMia", cn, trans);
                ID = DBModule.GetNewID(typeof(clsGiaNhapMia), "tbl_GiaNhapMia", cn, trans);
                //NgayTao = DateTime.Now;        
                //NgaySua = DateTime.Now;        
                // build SQL statement
                strSQL = "Insert into tbl_GiaNhapMia" +
                "(ID,DonGia,VuTrongID,SelectedValue) Values(" +
                    ID.ToString() + "," + DonGia.ToString() + "," + VuTrongID.ToString() + "," + SelectedValue.ToString() + ")";
            }
            else // edit object, we update old record in database
            {
                // build SQL statement				    
                //NgaySua = DateTime.Now;        
                strSQL = "Update tbl_GiaNhapMia set " +
                    "DonGia=" + DonGia.ToString() + "," + "VuTrongID=" + VuTrongID.ToString() + "," + "SelectedValue=" + SelectedValue.ToString() +
                    " Where ID = " + ID.ToString();
            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_GiaNhapMia", cn, trans));
                */
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_GiaNhapMia where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_GiaNhapMia where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_GiaNhapMia where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("DonGia"))
                    DonGia = long.Parse(dr["DonGia"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("SelectedValue"))
                    SelectedValue = long.Parse(dr["SelectedValue"].ToString());
            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_GiaNhapMia ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_GiaNhapMia WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        public void updatetheoDK(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            strSQL = "Update tbl_GiaNhapMia set " +
                    "SelectedValue=" + 0 +
                   " Where DonGia != " + iID.ToString() + " AND VuTrongID=" + MDSolutionApp.VuTrongID;
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        #endregion

        public static decimal GiaMiaLoai1(long VuTrongID, DateTime ThoiGian)
        {
            string Tg_Can = ThoiGian.ToString("yyyy-MM-dd HH:mm:ss");//ToString('yyyy-MM-dd' dtCan.Value.ToString("yyyy-MM-dd") + " " + nGioCan.Value.ToString() + ":" + nPhutCan.Value.ToString() + ":" + nGiayCan.Value.ToString();            
            decimal DonGia = 0;
            long ID = 0;
            string sql = "Select top 1 * from tbl_GiaNhapMia Where NgayGioApDung<= '" + Tg_Can + "' AND VuTrongID=" + VuTrongID.ToString() +  " Order By NgayGioApDung Desc";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Lấy được thông báo giá gần nhất được sẽ được áp dụng
                DataRow drThongBao = ds.Tables[0].Rows[0];
                ID = long.Parse(drThongBao["ID"].ToString());
                DonGia = decimal.Parse(drThongBao["DonGia"].ToString());
            }
            return DonGia;
        }
        public static decimal GiaMiaRep(long VuTrongID, DateTime ThoiGian)
        {
            string Tg_Can = ThoiGian.ToString("yyyy-MM-dd HH:mm:ss");//ToString('yyyy-MM-dd' dtCan.Value.ToString("yyyy-MM-dd") + " " + nGioCan.Value.ToString() + ":" + nPhutCan.Value.ToString() + ":" + nGiayCan.Value.ToString();            
            decimal DonGiaMiaRep = 0;
            long ID = 0;
            string sql = "Select top 1 * from tbl_GiaNhapMia Where NgayGioApDung<= '" + Tg_Can + "' AND VuTrongID=" + VuTrongID.ToString() + " Order By NgayGioApDung Desc";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Lấy được thông báo giá gần nhất được sẽ được áp dụng
                DataRow drThongBao = ds.Tables[0].Rows[0];
                ID = long.Parse(drThongBao["ID"].ToString());
                DonGiaMiaRep = decimal.Parse(drThongBao["DonGiaMiaRep"].ToString());
            }
            return DonGiaMiaRep;
        }
        public static decimal GiaMiaChay(long VuTrongID, DateTime ThoiGian, decimal TG)
        {
            string Tg_Can = ThoiGian.ToString("yyyy-MM-dd HH:mm:ss");//ToString('yyyy-MM-dd' dtCan.Value.ToString("yyyy-MM-dd") + " " + nGioCan.Value.ToString() + ":" + nPhutCan.Value.ToString() + ":" + nGiayCan.Value.ToString();            
            decimal DonGiaMiaChay = 0;
            long ID = 0;
            string sql = "Select top 1 * from tbl_GiaNhapMia Where NgayGioApDung<= '" + Tg_Can + "' AND VuTrongID=" + VuTrongID.ToString() + " Order By NgayGioApDung Desc";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Lấy được thông báo giá gần nhất được sẽ được áp dụng
                DataRow drThongBao = ds.Tables[0].Rows[0];
                ID = long.Parse(drThongBao["ID"].ToString());
                sql = "Select * from tbl_GiaMiaChay Where ThongBaoID=" + ID.ToString();
                ds = ds = DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        decimal TuGio = decimal.Parse(dr["TuGio"].ToString());
                        decimal DenGio = decimal.Parse(dr["DenGio"].ToString());
                        decimal DonGiaMC = decimal.Parse(dr["DonGiaMiaChay"].ToString());
                        if ((TG > TuGio) && (TG <= DenGio))
                        {
                            DonGiaMiaChay = DonGiaMC;
                            break;
                        }
                    }
                }
            }
            return DonGiaMiaChay;
        }
    }
}