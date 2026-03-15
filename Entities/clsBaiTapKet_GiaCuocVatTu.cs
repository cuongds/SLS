
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsBaiTapKet_GiaCuocVatTu
    {
			public long ID = -1;
            public DateTime NgayApDung = DateTime.Now;
            public long DonGia = 0;    			       
			public long DotApDung = -1;
            public long VuTrongID = -1;  
			public long BaiTapKetID = -1;        			   
			public string GhiChu = "";
             
        public clsBaiTapKet_GiaCuocVatTu()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsBaiTapKet_GiaCuocVatTu(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.DBModule.GetNewID(typeof(BaiTapKet), "tbl_BaiTapKet_GiaCuocVatTu", cn, trans);
                //ID = DBModule.GetNewID(typeof(clsBaiTapKet_GiaCuocVatTu), "tbl_BaiTapKet_GiaCuocVatTu", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                strSQL = "Insert into tbl_BaiTapKet_GiaCuocVatTu" +
                //"(ID,TenBai,ThonID,KhoangCach,DonGia,GhiChu,XaID,NgayApDung1,DonGia1,NgayApDung2,DonGia2,NgayApDung3,DonGia3,NgayApDung4,DonGia4,NgayApDung5,DonGia5,NgayApDung6,DonGia6,NgayApDung7,DonGia7,NgayApDung8,DonGia8,NgayApDung9,DonGia9,NgayApDung10,DonGia10,NgayApDung11,DonGia11,NgayApDung12,DonGia12,LanApDung) Values(" +
                //    ID.ToString() + "," + "N'" + DBModule.RefineString(TenBai) + "'" + "," + ThonID.ToString() + "," + KhoangCach.ToString() + "," + DonGia.ToString() + "," + "N'" + DBModule.RefineString(GhiChu) + "'" + "," + XaID.ToString() + "," + DBModule.RefineDatetime(NgayApDung1) + "," + DonGia1.ToString() + "," + DBModule.RefineDatetime(NgayApDung2) + "," + DonGia2.ToString() + "," + DBModule.RefineDatetime(NgayApDung3) + "," + DonGia3.ToString() + "," + DBModule.RefineDatetime(NgayApDung4) + "," + DonGia4.ToString() + "," + DBModule.RefineDatetime(NgayApDung5) + "," + DonGia5.ToString() + "," + DBModule.RefineDatetime(NgayApDung6) + "," + DonGia6.ToString() + "," + DBModule.RefineDatetime(NgayApDung7) + "," + DonGia6.ToString() + "," + DBModule.RefineDatetime(NgayApDung8) + "," + DonGia8.ToString() + "," + DBModule.RefineDatetime(NgayApDung9) + "," + DonGia9.ToString() + "," + DBModule.RefineDatetime(NgayApDung10) + "," + DonGia10.ToString() + "," + DBModule.RefineDatetime(NgayApDung11) + "," + DonGia11.ToString() + "," + DBModule.RefineDatetime(NgayApDung12) + "," + DonGia12.ToString() + ")";
                "(NgayApDung,DonGia,DotApDung,VuTrongID,BaiTapKetID,GhiChu) Values(" +
               DBModule.RefineDatetime(NgayApDung) + "," + DonGia.ToString() + "," + DotApDung.ToString() + "," + VuTrongID.ToString() + "," + BaiTapKetID.ToString() + "," + "N'" + DBModule.RefineString(GhiChu) + "')";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_BaiTapKet_GiaCuocVatTu set " +
                "NgayApDung=" + DBModule.RefineDatetime(NgayApDung) +  "," + "DonGia=" + DonGia.ToString() + "," + "DotApDung=" + DotApDung.ToString() + "," + "VuTrongID=" + VuTrongID.ToString() + "," + "GhiChu=" + "N'" + DBModule.RefineString(GhiChu) +
                    " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			DBModule.ExecuteNonQuery(strSQL, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_BaiTapKet_GiaCuocVatTu", cn, trans));
				*/
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_BaiTapKet_GiaCuocVatTu where ID=" + ID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_BaiTapKet_GiaCuocVatTu where ID=" + iID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_BaiTapKet_GiaCuocVatTu where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                    if (!dr.IsNull("NgayApDung"))
                    NgayApDung = DateTime.Parse(dr["NgayApDung"].ToString());
					if(!dr.IsNull("DonGia"))
                        DonGia = long.Parse(dr["DonGia"].ToString());
                    if (!dr.IsNull("DotApDung"))
                        DotApDung = long.Parse(dr["DotApDung"].ToString());

					if(!dr.IsNull("VuTrongID"))
                        VuTrongID = long.Parse(dr["VuTrongID"].ToString());

					if(!dr.IsNull("BaiTapKetID"))
                        BaiTapKetID = long.Parse(dr["BaiTapKetID"].ToString());

					if(!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();

			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_BaiTapKet_GiaCuocVatTu ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);
            
            ds = DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_BaiTapKet_GiaCuocVatTu WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
    }
}