
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution.Entities
{
    public class clsCVT
    {
			public long ID = -1;
            public string MaHopDong = "";
			public long HopDongID = -1;        
			public long ThonID = -1;        
			public long BaiTapKetID = -1;
            public string HoTen = "";
            public string TenThon = "";
            public string TenBai = "";
            public string Errors = "";
            public long Importer = MDSolutionApp.User.ID;
            public DateTime DateImport = DateTime.Now;
			public long Modify=1;
            public DateTime DateModify = DateTime.MinValue;
            public decimal SoLuong = 0;
            public DateTime NgayNhan = DateTime.MinValue;
        public clsCVT()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsCVT(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{

                strSQL = "Insert Into tbl_Temp_Import_Excel_CapVatTu(HopDongID,ThonID,BaiTapKetID,HoTen,TenThon,TenBai,Importer,DateImport,Errors,MaHopDong,SoLuong,NgayNhan) Values(" +
                    HopDongID.ToString() + "," + ThonID.ToString() + "," + BaiTapKetID.ToString() +",N'"+HoTen+"',N'"+TenThon+"',N'"+TenBai+"',"
                    + Importer.ToString()+",GetDate()"+",N'"+Errors+"'"+",N'"+MaHopDong+"',"+SoLuong.ToString()+DBModule.RefineDatetime(NgayNhan,true)+")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_Temp_Import_Excel_CapVatTu Set HopDongID= " +HopDongID.ToString()+",ThonID="+ThonID.ToString()+",BaiTapKetID="+BaiTapKetID.ToString()+
					",Hoten=N'"+HoTen+"',TenThon=N'"+TenThon+"',TenBai=N'"+TenBai+"',Modify=1,DateModify=GetDate(),Errors=N'',MaHopDong=N'"+MaHopDong+"'"+
                    ",SoLuong="+SoLuong.ToString()+",NgayNhan="+DBModule.RefineDatetime(NgayNhan,true)+" Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			DBModule.ExecuteNonQuery(strSQL, cn, trans);
			
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
            strSQL = "Delete from tbl_Temp_Import_Excel_CapVatTu where ID=" + ID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
            strSQL = "Delete from tbl_Temp_Import_Excel_CapVatTu where ID=" + iID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
            strSQL = "Select * from tbl_Temp_Import_Excel_CapVatTu where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("HopDongID"))
                        HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("ThonID"))
                    ThonID = long.Parse(dr["ThonID"].ToString());
                if (!dr.IsNull("BaiTapKetID"))
                    BaiTapKetID = long.Parse(dr["BaiTapKetID"].ToString());
                if (!dr.IsNull("HoTen"))
                    HoTen = dr["HoTen"].ToString();
                if (!dr.IsNull("TenThon"))
                    TenThon = dr["TenThon"].ToString();
                if (!dr.IsNull("TenBai"))
                    TenBai = dr["TenBai"].ToString();
                if (!dr.IsNull("Errors"))
                    Errors = dr["Errors"].ToString();
                if (!dr.IsNull("MaHopDong"))
                    MaHopDong = dr["MaHopDong"].ToString();
                if (!dr.IsNull("SoLuong"))
                    SoLuong = decimal.Parse(dr["SoLuong"].ToString());
                if (!dr.IsNull("NgayNhan"))
                    NgayNhan = DateTime.Parse(dr["NgayNhan"].ToString());
			}
	
		}
      
		
		#endregion
    }
}