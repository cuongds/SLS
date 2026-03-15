
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsUser
    {
			public long ID = -1;        
			public string UserName = "";        
			public string Password = "";        
			public string HoTen = "";        
			public string DonVi = "";
            public string Roles = "";
            public long RolesID = -1;
            public long IsAdvance = -1;
        public clsUser()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsUser(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                try
                {
                    ID = long.Parse(DBModule.ExecuteQueryForOneResult("Select ISNULL(Max(ID),0)+1 From sys_User", null, null));
                }
                catch
                {
                    return;
                }
                strSQL = "Insert into sys_User" +
				"(ID,UserName,Password,HoTen,DonVi,Roles,RolesID) Values(" +
                    ID.ToString() + "," + "N'" + DBModule.RefineString(UserName) + "'" + "," + "N'" + DBModule.RefineString(Password) + "'" + "," + "N'" + DBModule.RefineString(HoTen) + "'" + "," + "N'" + DBModule.RefineString(DonVi) + "'" + ",N'" + Roles + "',"+RolesID.ToString()+")";
			}
			else // edit object, we update old record in database
			{
			    strSQL = "Update sys_User set " +
                    "UserName=" + "N'" + DBModule.RefineString(UserName) + "'" + "," + "Password=" + "N'" + DBModule.RefineString(Password) + "'" + "," + "HoTen=" + "N'" + DBModule.RefineString(HoTen) + "'" + "," 
                    + "DonVi=" + "N'" + DBModule.RefineString(DonVi) + "'" + "," + "Roles=N'" + Roles +"',RolesID="+RolesID.ToString()+ " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			DBModule.ExecuteNonQuery(strSQL, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM sys_User", cn, trans));
				*/
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from sys_User where ID=" + ID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from sys_User where ID=" + iID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from sys_User where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
					if(!dr.IsNull("UserName"))
                    UserName = dr["UserName"].ToString();
					if(!dr.IsNull("Password"))
                    Password = dr["Password"].ToString();
					if(!dr.IsNull("HoTen"))
                    HoTen = dr["HoTen"].ToString();
					if(!dr.IsNull("DonVi"))
                    DonVi = dr["DonVi"].ToString();
                    if (!dr.IsNull("Roles"))
                    Roles = dr["Roles"].ToString();
                    if (!dr.IsNull("RolesID"))
                    RolesID = long.Parse(dr["RolesID"].ToString());
                    if (!dr.IsNull("IsAdvance"))
                        IsAdvance = long.Parse(dr["IsAdvance"].ToString());
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from sys_User ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);
            
            ds = DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM sys_User WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
    }
}