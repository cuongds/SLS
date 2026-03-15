
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsCanBoDiaBan
    {
        public long ID = -1;
        public string Ten = "";
        public string Ma = "";
        public string DienThoai = "";   
        public clsCanBoDiaBan()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsCanBoDiaBan(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.DBModule.GetNewID(typeof(Cum), "tbl_Cum", cn, trans);
                ID = DBModule.GetNewID(typeof(clsCum), "tbl_DanhMucCanBoNongVu", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                strSQL = "Insert into tbl_DanhMucCanBoNongVu" +
				"(ID,Ten,Ma,DienThoai) Values(" +
                    ID.ToString() + "," + "N'" + DBModule.RefineString(Ten) + "',N'" + Ma.ToString() + "',N'"+DienThoai+"')";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_DanhMucCanBoNongVu set " +
                    "Ten=" + "N'" + DBModule.RefineString(Ten) + "'" + ", Ma=N'" + Ma.ToString()+"',DienThoai=N'"+DienThoai+"' Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			DBModule.ExecuteNonQuery(strSQL, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_Cum", cn, trans));
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
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                        ID = long.Parse(dr["ID"].ToString());
					if(!dr.IsNull("Ten"))
                        Ten = dr["Ten"].ToString();
                    if (!dr.IsNull("Ma"))
                        Ma = (dr["Ma"].ToString());
                    if (!dr.IsNull("DienThoai"))
                        DienThoai = (dr["DienThoai"].ToString());
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_DanhMucCanBoNongVu ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);
            
            ds = DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
       
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
                string strSQL = "SELECT " + strFields + " FROM tbl_DanhMucCanBoNongVu WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
    }
}