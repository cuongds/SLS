
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsCacVungNguyenLieu
    {
			public long ID = -1;
            public string TenVung = "";
            public long XaID = 0;
            public clsCacVungNguyenLieu()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsCacVungNguyenLieu(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{

                strSQL = "Insert Into tbl_CacVungNguyenLieu(TenVung,XaID) Values(N'" + DBModule.RefineString(TenVung) + "',"+XaID.ToString()+")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_CacVungNguyenLieu Set TenVung=N'"+DBModule.RefineString(TenVung)+"',XaID="+XaID.ToString()+" Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			DBModule.ExecuteNonQuery(strSQL, cn, trans);
			
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
            strSQL = "Delete from tbl_CacVungNguyenLieu Where ID=" + ID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
            strSQL = "Delete from tbl_CacVungNguyenLieu Where ID=" + iID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}
        public static bool CheckTruongVung(long lID, OleDbConnection cn, OleDbTransaction trans)
        {
            bool DaCoTruongVung = false;
            string strSQL = "";
            // build SQL statement
            strSQL = "Select NhomTruong From tbl_CacVungNguyenLieu INNER JOIN tbl_CacVungNguyenLieu_CBDB ON tbl_CacVungNguyenLieu.ID= tbl_CacVungNguyenLieu_CBDB.VungNguyenLieuID "+
                     "Where NhomTruong>0 And VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " And VungNguyenLieuID=" + lID.ToString();
            // run SQL statement
            string ret = DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
            if (string.IsNullOrEmpty(ret))
            {
                DaCoTruongVung = false;
            }
            else
            {
                DaCoTruongVung = true;
            }
            return DaCoTruongVung;
        }	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
            strSQL = "Select * from tbl_CacVungNguyenLieu Where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                        ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("TenVung"))
                    TenVung = dr["TenVung"].ToString();
                if (!dr.IsNull("XaID"))
                    XaID = long.Parse(dr["XaID"].ToString());
        	}
	
		}
      
		
		#endregion
    }
}