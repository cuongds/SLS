
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsThon
    {
			public long ID = -1;
            public string MaThon = "";
			public string Ten = "";        
			public long XaID = -1;
            public long tt = -1;
            public long DinhMuc = 0;
			public long CanBoNongVuID = -1;        
        public clsThon()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsThon(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.DBModule.GetNewID(typeof(Thon), "tbl_Thon", cn, trans);
				ID = DBModule.GetNewID(typeof(clsThon), "tbl_Thon", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                strSQL = "Insert into tbl_Thon" +
                "(ID,MaThon,Ten,XaID,tt,CanBoNongVuID,DinhMuc) Values(" +
                    ID.ToString() + "," + "N'" + DBModule.RefineString(MaThon) + "'" + "," + "N'" + DBModule.RefineString(Ten) + "'" + "," + XaID.ToString() + "," + tt.ToString() + "," + CanBoNongVuID.ToString() +","+DinhMuc.ToString()+ ")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_Thon set " +
                    "MaThon=" + "N'" + DBModule.RefineString(MaThon) + "'" + "," + "Ten=" + "N'" + DBModule.RefineString(Ten) + "'" + "," + "XaID=" + XaID.ToString() + "," + "CanBoNongVuID=" + CanBoNongVuID.ToString() +
                    ",DinhMuc="+DinhMuc.ToString()+" Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			DBModule.ExecuteNonQuery(strSQL, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_Thon", cn, trans));
				*/
		}
        public static void Update_DiaBanCBNV(long CBNVID,long ThonID, OleDbConnection cn, OleDbTransaction trans)
        {
            string sql = "Update tbl_Thon Set CanBoNongVuID=" + CBNVID.ToString() + " Where ID=" + ThonID.ToString();
            DBModule.ExecuteNonQuery(sql, null, null);
        }
        public static DataSet Get_CBNV(long ThonID, OleDbConnection cn, OleDbTransaction trans)
        {
            DataSet CBNV=new DataSet();
            try
            {
                string sql = "Select ID,Ten From tbl_DanhMucCanBoNongVu Where ID=(Select CanBoNongVuID From tbl_Thon Where ID=" + ThonID.ToString() + ")";
                CBNV=DBModule.ExecuteQuery(sql, null, null);
            }
            catch{}
            return CBNV;
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_Thon where ID=" + ID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_Thon where ID=" + iID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_Thon where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                    if (!dr.IsNull("MaThon"))
                        MaThon = dr["MaThon"].ToString();
					if(!dr.IsNull("Ten"))
                    Ten = dr["Ten"].ToString();
					if(!dr.IsNull("XaID"))
                    XaID = long.Parse(dr["XaID"].ToString());
                    if (!dr.IsNull("tt"))
                        tt = long.Parse(dr["tt"].ToString());
                    if (!dr.IsNull("CanBoNongVuID"))
                        CanBoNongVuID = long.Parse(dr["CanBoNongVuID"].ToString());
                    if (!dr.IsNull("DinhMuc"))
                        DinhMuc = long.Parse(dr["DinhMuc"].ToString());
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_Thon ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);
            
            ds = DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_Thon WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
    }
}