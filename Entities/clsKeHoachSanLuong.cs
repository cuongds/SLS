
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsKeHoachSanLuong
    {
			public long ID = -1;
            public long VuTrongID = MDSolutionApp.VuTrongID;
            public DateTime NgayKeHoach = DateTime.Now;
            public DateTime ThoiGianBatDau = DateTime.Now;
            public DateTime ThoiGianKetThuc = DateTime.Now;
            public long KhongChe = 1;
          
        public clsKeHoachSanLuong()
		{
			//
			// TODO: Add constructor logic here
			//
		}
            public clsKeHoachSanLuong(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{

                strSQL = "Insert Into tbl_KeHoachSanLuong(VuTrongID,NgayKeHoach,ThoiGianBatDau,ThoiGianKetThuc,AddBy,DateAdd,KhongChe) Values(" +
                           VuTrongID.ToString() + "," +DBModule.RefineDatetime(NgayKeHoach) + "," + DBModule.RefineDatetime(ThoiGianBatDau) +"," +
                           DBModule.RefineDatetime(ThoiGianKetThuc) + ",N'" + DBModule.RefineString(MDSolutionApp.User.HoTen)+"',GetDate()" + "," + KhongChe.ToString() + ")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_KeHoachSanLuong Set KhongChe="+KhongChe.ToString()+",ThoiGianBatDau=" + DBModule.RefineDatetime(ThoiGianBatDau) + ",ThoiGianKetThuc=" + DBModule.RefineDatetime(ThoiGianKetThuc) +
                         ",ModifyBy=N'" + DBModule.RefineString(MDSolutionApp.User.HoTen) + "',DateModify=GetDate() Where ID = " + ID.ToString();
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
            strSQL = "Delete from tbl_KeHoachSanLuong Where ID=" + ID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
            strSQL = "Delete from tbl_KeHoachSanLuong Where ID=" + iID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}
        public static bool CheckKeHoach(string NgayKH, OleDbConnection cn, OleDbTransaction trans)
        {
            bool DaCo = false;
            string strSQL = "";
            // build SQL statement
            strSQL = "Select NgayKeHoach From tbl_KeHoachSanLuong Where ConVert(char(10),NgayKeHoach,121)='" + NgayKH + "' and VuTrongID = " + +MDSolutionApp.VuTrongID ;
            // run SQL statement
            string ret = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
            if (string.IsNullOrEmpty(ret))
            {
                DaCo = false;
            }
            else
            {
                DaCo = true;
            }
            return DaCo;
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
            strSQL = "Select * from tbl_KeHoachSanLuong Where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                        ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("NgayKeHoach"))
                    NgayKeHoach = DateTime.Parse(dr["NgayKeHoach"].ToString());
                if (!dr.IsNull("ThoiGianBatDau"))
                    ThoiGianBatDau = DateTime.Parse(dr["ThoiGianBatDau"].ToString());
                if (!dr.IsNull("ThoiGianKetThuc"))
                    ThoiGianKetThuc = DateTime.Parse(dr["ThoiGianKetThuc"].ToString());
                if (!dr.IsNull("KhongChe"))
                    KhongChe = long.Parse(dr["KhongChe"].ToString());
          	}
	
		}
      
		
		#endregion
    }
}