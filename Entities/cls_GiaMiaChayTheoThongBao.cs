using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;

namespace MDSolution
{
    public class cls_GiaMiaChayTheoThongBao
    {
        
            public long ID = -1;		
            public long ThongBaoID = -1;        
			public decimal TuGio = 0;
            public decimal DenGio = 24;
            public decimal DonGiaMiaChay = 0;
            public long MaxID = 0;
        public cls_GiaMiaChayTheoThongBao()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public cls_GiaMiaChayTheoThongBao(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                strSQL = "Insert into tbl_GiaMiaChay(ThongBaoID,TuGio,DenGio,DonGiaMiaChay) Values(" +
                    ThongBaoID.ToString() + "," + DBModule.RefineNumber(TuGio) + "," + DBModule.RefineNumber(DenGio) + "," + DBModule.RefineNumber(DonGiaMiaChay)+")";
			}
			else // edit object, we update old record in database
			{
                strSQL = "Update tbl_GiaMiaChay set " +
                    "ThongBaoID=" + ThongBaoID.ToString() + ",TuGio=" + DBModule.RefineNumber(TuGio) + ",DenGio=" + DBModule.RefineNumber(DenGio) +
                    ",DonGiaMiaChay=" + DBModule.RefineNumber(DonGiaMiaChay) + " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			DBModule.ExecuteNonQuery(strSQL, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_Thon", cn, trans));
				*/
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
            strSQL = "Delete from tbl_GiaMiaChay where ID=" + ID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
            strSQL = "Delete from tbl_GiaMiaChay where ID=" + iID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}
        public long FindMaxID()
        {
            string strSQL = "Select Max(ID) as MaxID from tbl_GiaMiaChay";
			// run SQL statement
			DataSet ds = DBModule.ExecuteQuery(strSQL,null,null);

			// fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("MaxID"))
                    MaxID = long.Parse(dr["MaxID"].ToString());
            }
            return MaxID;
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
            strSQL = "Select * from tbl_GiaMiaChay where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);
           			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
					if(!dr.IsNull("ThongBaoID"))
                        ThongBaoID = long.Parse(dr["ThongBaoID"].ToString());
                    if (!dr.IsNull("TuGio"))
                        TuGio = decimal.Parse(dr["TuGio"].ToString());
                 if (!dr.IsNull("DenGio"))
                     DenGio = decimal.Parse(dr["DenGio"].ToString());
                 if (!dr.IsNull("DonGiaMiaChay"))
                     DonGiaMiaChay = decimal.Parse(dr["DonGiaMiaChay"].ToString());
             }
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_GiaMiaChay ";                 
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
