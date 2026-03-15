
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsDanhMucVatTu
    {
        public long ID = -1;
        public long DanhMucDauTuID = -1;
        public string Ma = "";
        public string Ten = "";       
        public string DonViTinh = "";
        public string HinhThucDauTu ="";
        public long ThuTu = 0;       
        public float LaiSuat = 0;
        public long IsActive = 0;
        public float PhanTramGiaVanChuyen = 0;
        public float DonGia = 0;
        
        public clsDanhMucVatTu()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsDanhMucVatTu(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {   strSQL = "Insert into tbl_DanhMucVatTu" +
                "(Ma,Ten,DonViTinh,HinhThucDauTu,DanhMucDauTuID,ThuTu,LaiSuat,IsActive,PhanTramGiaVanChuyen,DonGia) Values(" +
                    "N'" + DBModule.RefineString(Ma) + "'" + "," + "N'" + DBModule.RefineString(Ten) + "'" + "," + "N'" + DBModule.RefineString(DonViTinh) + "'" + "," + "N'" + DBModule.RefineString(HinhThucDauTu) + "'" + "," + DanhMucDauTuID.ToString() + "," + ThuTu.ToString() + "," + LaiSuat.ToString() + "," + IsActive.ToString() + "," + PhanTramGiaVanChuyen.ToString() + "," + DonGia.ToString() + ")";
            }
            else // edit object, we update old record in database
            {
              strSQL = "Update tbl_DanhMucVatTu set " +
                    "Ten=" + "N'" + DBModule.RefineString(Ten) + "'" + "," + "Ma=" + "N'" + DBModule.RefineString(Ma) + "'" + "," + "DonViTinh=" + "N'" + DBModule.RefineString(DonViTinh) + "'" + "," + "HinhThucDauTu=" + "N'" + DBModule.RefineString(HinhThucDauTu) + "'" + "," + "DanhMucDauTuID=" + DanhMucDauTuID.ToString() + "," + "ThuTu=" + ThuTu.ToString() + "," + "LaiSuat=" + LaiSuat.ToString() + "," + "IsActive=" + IsActive.ToString() + "," + "PhanTramGiaVanChuyen=" + PhanTramGiaVanChuyen.ToString() + "," + "DonGia=" + DonGia.ToString() +
                    " Where ID = " + ID.ToString();
            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);
           
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryForOneResult("SELECT Max(ID) FROM tbl_DanhMucVatTu", cn, trans));
            
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_DanhMucVatTu where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_DanhMucVatTu where DanhMucDauTuID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_DanhMucVatTu where ID=" + ID.ToString();
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
                if (!dr.IsNull("DonViTinh"))
                    DonViTinh = dr["DonViTinh"].ToString();
                if (!dr.IsNull("HinhThucDauTu"))
                    HinhThucDauTu = dr["HinhThucDauTu"].ToString();
                if (!dr.IsNull("DanhMucDauTuID"))
                    DanhMucDauTuID = long.Parse(dr["DanhMucDauTuID"].ToString());
                if (!dr.IsNull("ThuTu"))
                    ThuTu = long.Parse(dr["ThuTu"].ToString());               
                if (!dr.IsNull("LaiSuat"))
                    LaiSuat = float.Parse(dr["LaiSuat"].ToString());
                if (!dr.IsNull("IsActive"))
                    IsActive = long.Parse(dr["IsActive"].ToString());
                if (!dr.IsNull("PhanTramGiaVanChuyen"))
                    PhanTramGiaVanChuyen = float.Parse(dr["PhanTramGiaVanChuyen"].ToString());
                if (!dr.IsNull("DonGia"))
                    DonGia = float.Parse(dr["DonGia"].ToString());
                
            }

        }
        public void LoadByVatTuID(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_DanhMucVatTu where DanhMucDauTuID=" + ID.ToString();
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
                if (!dr.IsNull("DonViTinh"))
                    DonViTinh = dr["DonViTinh"].ToString();
                if (!dr.IsNull("HinhThucDauTu"))
                    HinhThucDauTu = dr["HinhThucDauTu"].ToString();
                if (!dr.IsNull("DanhMucDauTuID"))
                    DanhMucDauTuID = long.Parse(dr["DanhMucDauTuID"].ToString());
                if (!dr.IsNull("ThuTu"))
                    ThuTu = long.Parse(dr["ThuTu"].ToString());
                if (!dr.IsNull("LaiSuat"))
                    LaiSuat = float.Parse(dr["LaiSuat"].ToString());
                if (!dr.IsNull("IsActive"))
                    IsActive = long.Parse(dr["IsActive"].ToString());
                if (!dr.IsNull("PhanTramGiaVanChuyen"))
                    PhanTramGiaVanChuyen = float.Parse(dr["PhanTramGiaVanChuyen"].ToString());
                if (!dr.IsNull("DonGia"))
                    DonGia = float.Parse(dr["DonGia"].ToString());

            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_DanhMucVatTu ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_DanhMucVatTu WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        #endregion
   
    }
}