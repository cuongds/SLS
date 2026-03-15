
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsVuTrong
    {
			public long ID = -1;        
			public string Ten = "";        
			public DateTime NgayBatDau = DateTime.Now;        
			public DateTime NgayKetThuc = DateTime.Now;        
			public long VuTruoc = 0;        
			public long IsActive = 0;        
			public long IsDefault = 0;
            public long OrderThanhToan = 0;
            public DateTime NgayKetChuyenDauTu = DateTime.MinValue;
            public DateTime NgayKetChuyenDienTich = DateTime.MinValue;
            public long NguoiKetChuyenDauTu = -1;
            public long NguoiKetChuyenDienTich = -1;
            public DateTime NgayChotHoTro = DateTime.MinValue;
        public clsVuTrong()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsVuTrong(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                strSQL = "Select ISNULL(Max(OrderThanhToan) + 1,1) From tbl_VuTrong";
                string Order = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                strSQL = "Insert into tbl_VuTrong" +
                "(Ten,NgayBatDau,NgayKetThuc,VuTruoc,IsActive,IsDefault,OrderThanhToan,NgayKetChuyenDauTu,NgayKetChuyenDienTich,NguoiKetChuyenDauTu,NguoiKetChuyenDienTich,NgayChotHoTro) Values(" +
                  "N'" + DBModule.RefineString(Ten) + "'" + "," + DBModule.RefineDatetime(NgayBatDau) + "," + DBModule.RefineDatetime(NgayKetThuc) + "," + VuTruoc.ToString() + 
                  "," + IsActive.ToString() + "," + IsDefault.ToString() + "," + Order + ","+DBModule.RefineDatetime(NgayKetChuyenDauTu,true)+","+DBModule.RefineDatetime(NgayKetChuyenDienTich,true)+
                  "," + NguoiKetChuyenDauTu.ToString() + "," + NguoiKetChuyenDienTich.ToString() + "," + DBModule.RefineDatetime(NgayChotHoTro,true) + ")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
	            strSQL = "Update tbl_VuTrong Set " +
					"Ten="+"N'" + DBModule.RefineString(Ten) + "'"+","+"NgayBatDau="+DBModule.RefineDatetime(NgayBatDau)+","+"NgayKetThuc="+DBModule.RefineDatetime(NgayKetThuc)+","+"VuTruoc="+VuTruoc.ToString()+","+"IsActive="+IsActive.ToString()+","+"IsDefault="+IsDefault.ToString()+
                    ",OrderThanhToan="+OrderThanhToan.ToString()+",NgayKetChuyenDauTu="+DBModule.RefineDatetime(NgayKetChuyenDauTu,true)+",NgayKetChuyenDienTich="+DBModule.RefineDatetime(NgayKetChuyenDienTich,true)+
                    ",NguoiKetChuyenDauTu=" + NguoiKetChuyenDauTu.ToString() + ",NguoiKetChuyenDienTich=" + NguoiKetChuyenDienTich.ToString() + "," + "NgayChotHoTro=" + DBModule.RefineDatetime(NgayChotHoTro,true) + " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			DBModule.ExecuteNonQuery(strSQL, cn, trans);
			
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_VuTrong where ID=" + ID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_VuTrong where ID=" + iID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}
        public static bool Check_ChuyenVu_DienTich(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Select NguoiKetChuyenDienTich From tbl_VuTrong Where NguoiKetChuyenDienTich>0 AND NgayKetChuyenDienTich Is Not Null And ID=" + iID.ToString();
            // run SQL statement
            string ret=DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
            if (string.IsNullOrEmpty(ret)) return false; else return true;
        }
        public static bool Check_ChuyenVu_DauTu(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Select NguoiKetChuyenDauTu From tbl_VuTrong Where NguoiKetChuyenDauTu>0 And NgayKetChuyenDauTu Is Not Null And ID=" + iID.ToString();
            // run SQL statement
            string ret = DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
            if (string.IsNullOrEmpty(ret)) return false; else return true;
        }	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_VuTrong where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                        ID = long.Parse(dr["ID"].ToString());
					if(!dr.IsNull("Ten"))
                        Ten = dr["Ten"].ToString();
					if(!dr.IsNull("NgayBatDau"))
                      NgayBatDau = DateTime.Parse(dr["NgayBatDau"].ToString());
					if(!dr.IsNull("NgayKetThuc"))
                        NgayKetThuc = DateTime.Parse(dr["NgayKetThuc"].ToString());
					if(!dr.IsNull("VuTruoc"))
                        VuTruoc = long.Parse(dr["VuTruoc"].ToString());
					if(!dr.IsNull("IsActive"))
                        IsActive = long.Parse(dr["IsActive"].ToString());
					if(!dr.IsNull("IsDefault"))
                        IsDefault = long.Parse(dr["IsDefault"].ToString());
                    if (!dr.IsNull("OrderThanhToan"))
                        OrderThanhToan = long.Parse(dr["OrderThanhToan"].ToString());
                    if (!dr.IsNull("NgayKetChuyenDauTu"))
                        NgayKetChuyenDauTu = DateTime.Parse(dr["NgayKetChuyenDauTu"].ToString());
                    if (!dr.IsNull("NgayKetChuyenDienTich"))
                        NgayKetChuyenDienTich = DateTime.Parse(dr["NgayKetChuyenDienTich"].ToString());
                    if (!dr.IsNull("NguoiKetChuyenDauTu"))
                        NguoiKetChuyenDauTu = long.Parse(dr["NguoiKetChuyenDauTu"].ToString());
                    if (!dr.IsNull("NguoiKetChuyenDienTich"))
                        NguoiKetChuyenDienTich = long.Parse(dr["NguoiKetChuyenDienTich"].ToString());
                    if (!dr.IsNull("NgayChotHoTro"))
                        NgayChotHoTro = DateTime.Parse(dr["NgayChotHoTro"].ToString());
                
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_VuTrong ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);
            
            ds = DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_VuTrong WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
        #region Extention Functions
        public void UpdateDefault(OleDbConnection cn, OleDbTransaction trans)
        {
            if (this.IsDefault == 1)
            {
                string strSQL = "Update tbl_VuTrong Set IsDefault=0 WHERE IsDefault=1 AND ID <>" + this.ID.ToString();
                DBModule.ExecuteNonQuery(strSQL, cn, trans); 
            }
        }
        public static string GetDefaultVuTrongTen(OleDbConnection cn, OleDbTransaction trans)
        {
            
                string strSQL = "SELECT TOP 1 Ten FROM tbl_VuTrong WHERE IsDefault=1";
                return DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
            
            
        }
        #endregion

    }
}