
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsCacVungNguyenLieu_CBDB
    {
			public long ID = -1;
            public long VungNguyenLieuID = -1;
            public long CBDBID=-1;
            public long NhomTruong = 0;
            public long VutrongID = MDSolutionApp.VuTrongID;
            public long ThonID = 0;
            public clsCacVungNguyenLieu_CBDB()
		{
			//
			// TODO: Add constructor logic here
			//
		}
            public clsCacVungNguyenLieu_CBDB(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{

                strSQL = "Insert Into tbl_CacVungNguyenLieu_CBDB(VungNguyenLieuID,CBDBID,NhomTruong,VutrongID,ThonID) Values(" + VungNguyenLieuID.ToString()+","+ CBDBID.ToString() + "," + NhomTruong.ToString()
                    + "," + VutrongID.ToString()+","+ThonID.ToString()+")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_CacVungNguyenLieu_CBDB Set VungNguyenLieuID=" + VungNguyenLieuID.ToString() + ",CBDBID=" + CBDBID.ToString() + ",NhomTruong=" + NhomTruong.ToString() + ",ThonID=" + ThonID.ToString() + " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			DBModule.ExecuteNonQuery(strSQL, cn, trans);
			
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
            strSQL = "Delete from tbl_CacVungNguyenLieu_CBDB Where ID=" + ID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
            strSQL = "Delete from tbl_CacVungNguyenLieu_CBDB Where ID=" + iID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}
       
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
            strSQL = "Select * from tbl_CacVungNguyenLieu_CBDB Where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                        ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("VungNguyenLieuID"))
                    VungNguyenLieuID = long.Parse(dr["VungNguyenLieuID"].ToString());
                if (!dr.IsNull("CBDBID"))
                    CBDBID = long.Parse(dr["CBDBID"].ToString());
                if (!dr.IsNull("NhomTruong"))
                    NhomTruong = long.Parse(dr["NhomTruong"].ToString());
                if (!dr.IsNull("ThonID"))
                    ThonID = long.Parse(dr["ThonID"].ToString());
        	}
	
		}
      
		
		#endregion
    }
}