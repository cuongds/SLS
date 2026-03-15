
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsKeHoachSanLuong_ChiTiet
    {
			public long ID = -1;
            public long VuTrongID = MDSolutionApp.VuTrongID;
            public long KeHoachID = -1;
            public long VungNguyenLieuID = -1;
            public long CBDBID = -1;
            public long XaID = 0;
            public decimal SoChuyen = 0;
            public decimal SanLuong = 0;
          
        public clsKeHoachSanLuong_ChiTiet()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsKeHoachSanLuong_ChiTiet(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{

                strSQL = "Insert Into tbl_KeHoachSanLuong_ChiTiet(VuTrongID,KeHoachID,VungNguyenLieuID,CBDBID,XaID,SoChuyen,SanLuong) Values(" +
                           VuTrongID.ToString() + "," + KeHoachID.ToString() + "," + VungNguyenLieuID.ToString() + "," + CBDBID.ToString() + "," +
                           XaID.ToString() + "," + SoChuyen.ToString() + "," + SanLuong.ToString() + ")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_KeHoachSanLuong_ChiTiet Set KeHoachID=" + KeHoachID.ToString() + ",VungNguyenLieuID=" + VungNguyenLieuID.ToString() +
                         ",CBDBID=" + CBDBID.ToString() + ",XaID=" + XaID.ToString() + ",SoChuyen=" + SoChuyen.ToString() + ",SanLuong=" + SanLuong.ToString() + " Where ID = " + ID.ToString();
			}
			// run SQL statement
            if (ID <= 0)
            {
                strSQL += ";SELECT @@IDENTITY AS 'Identity';";
                ID = long.Parse(DBModule.ExecuteQueryForOneResult(strSQL, cn, trans));
            }
            else
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
            strSQL = "Delete from tbl_KeHoachSanLuong_ChiTiet Where ID=" + ID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
            strSQL = "Delete from tbl_KeHoachSanLuong_ChiTiet Where ID=" + iID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}
        public static void UpdateKeHoachSanLuong(long iID,long SC,long SL, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Update tbl_KeHoachSanLuong_ChiTiet Set SoChuyen="+SC.ToString()+",SanLuong="+SL.ToString() +" Where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
            strSQL = "Select * from tbl_KeHoachSanLuong_ChiTiet Where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                        ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("KeHoachID"))
                    KeHoachID = long.Parse(dr["KeHoachID"].ToString());
                if (!dr.IsNull("VungNguyenLieuID"))
                    VungNguyenLieuID = long.Parse(dr["VungNguyenLieuID"].ToString());
                if (!dr.IsNull("CBDBID"))
                    CBDBID = long.Parse(dr["CBDBID"].ToString());
                if (!dr.IsNull("XaID"))
                    XaID = long.Parse(dr["XaID"].ToString());
                if (!dr.IsNull("SoChuyen"))
                    SoChuyen = decimal.Parse(dr["SoChuyen"].ToString());
                if (!dr.IsNull("SanLuong"))
                    SanLuong = decimal.Parse(dr["SanLuong"].ToString());
          	}
	
		}
      
		
		#endregion
    }
}