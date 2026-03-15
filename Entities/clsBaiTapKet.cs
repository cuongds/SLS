
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsBaiTapKet
    {
			public long ID = -1;        
			public string TenBai = "";        
			public long ThonID = -1;
            public long XaID = -1;  
			public decimal KhoangCach = 0;        
			public decimal DonGia = 0;        
			public string GhiChu = "";
            public long CanBoNongVuID = -1;
            public DateTime NgayApDung = DateTime.Now;
           

        public clsBaiTapKet()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsBaiTapKet(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                strSQL = "Insert into tbl_BaiTapKet" +
                         "(TenBai,ThonID,KhoangCach,DonGia,GhiChu,XaID,CanBoNongVuID,NgayApDung) Values(" +
                   "N'" + DBModule.RefineString(TenBai) + "'" + "," + ThonID.ToString() + "," + KhoangCach.ToString() + "," + DonGia.ToString() + "," + "N'" + DBModule.RefineString(GhiChu) + "'" + "," + XaID.ToString() + "," + CanBoNongVuID.ToString() + "," + DBModule.RefineDatetime(NgayApDung) + ")";
			}
			else // edit object, we update old record in database
			{
				    strSQL = "Update tbl_BaiTapKet set " +
                    "TenBai=" + "N'" + DBModule.RefineString(TenBai) + "'" + "," + "ThonID=" + ThonID.ToString() + "," + "KhoangCach=" + KhoangCach.ToString() + "," + "DonGia=" + DonGia.ToString() + "," + "GhiChu=" + "N'" + DBModule.RefineString(GhiChu) + "'" + "," + "XaID=" + XaID.ToString() + "," + "CanBoNongVuID=" + CanBoNongVuID.ToString() + "," + "NgayApDung=" + DBModule.RefineDatetime(NgayApDung) +
                    " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			DBModule.ExecuteNonQuery(strSQL, cn, trans);
            
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryForOneResult("SELECT Max(ID) FROM tbl_BaiTapKet", cn, trans));
                
        }

        ////////////////////////////////////////////////////////////////////////////
        /////////////Hàm lấy giá cước vận chuyển của BTK
        public static decimal GetGiaVanChuyen(long BTKID, OleDbConnection cn, OleDbTransaction trans)
        {
            decimal DonGiaVanChuyen = 0;
            string sql = "Select Top 1 * From tbl_BaiTapKet_GiaCuoc Where NgayApDung<=GetDate() AND BaiTapKetID=" + BTKID.ToString() + " And VuTrongID=" + MDSolutionApp.VuTrongID.ToString()+ " Order By NgayApDung DESC";
            try
            {
                DataSet ds = DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow drGiaVC = ds.Tables[0].Rows[0];
                    DonGiaVanChuyen = Math.Round(decimal.Parse(drGiaVC["DonGia"].ToString()), 0);
                }
            }
            catch
            {
                DonGiaVanChuyen = 0;
            }
            return DonGiaVanChuyen;
        }
       /////////////////////////////////////////////////////////////////////////////
   
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_BaiTapKet where ID=" + ID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_BaiTapKet where ID=" + iID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}
        public static long CheckToDelete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            string ret = "";
            long Result = -1;
            // Kiểm tra trong diện tích
            strSQL = "Select BaiTapKetID From tbl_ThuaRuong Where BaiTapKetID=" + iID.ToString();
            ret= DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
            if (!string.IsNullOrEmpty(ret)) Result=0;
            // Kiểm tra trong thu hoạch
            strSQL = "Select BaiTapKetID From tbl_NhapMia Where BaiTapKetID=" + iID.ToString();
            ret = DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
            if (!string.IsNullOrEmpty(ret)) Result = 1;
            // Kiểm tra trong cấp vật tư
            strSQL = "Select BaiTapKetID From tbl_NhanVatTu Where BaiTapKetID=" + iID.ToString();
            ret = DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
            if (!string.IsNullOrEmpty(ret)) Result = 2;
            return Result;
        }	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_BaiTapKet where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
					if(!dr.IsNull("TenBai"))
                    TenBai = dr["TenBai"].ToString();
					if(!dr.IsNull("ThonID"))
                    ThonID = long.Parse(dr["ThonID"].ToString());
                    if (!dr.IsNull("XaID"))
                    XaID = long.Parse(dr["XaID"].ToString());

					if(!dr.IsNull("KhoangCach"))
                        KhoangCach = decimal.Parse(dr["KhoangCach"].ToString());

					if(!dr.IsNull("DonGia"))
                    DonGia = decimal.Parse(dr["DonGia"].ToString());

					if(!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();

                    if (!dr.IsNull("CanBoNongVuID"))
                    CanBoNongVuID = long.Parse(dr["CanBoNongVuID"].ToString());
                    if (!dr.IsNull("NgayApDung"))
                        NgayApDung = DateTime.Parse(dr["NgayApDung"].ToString());
                  
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_BaiTapKet ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);
            
            ds = DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_BaiTapKet WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
    }
}