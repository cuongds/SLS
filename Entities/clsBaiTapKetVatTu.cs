
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsBaiTapKetVatTu
    {
			public long ID = -1;        
			public string TenBai = "";        
			public long ThonID = -1;
            public long XaID = -1;  
			public long KhoangCach = 0;        
			public long DonGia = 0;        
			public string GhiChu = "";
            public long CanBoNongVuID = -1;
            public DateTime NgayApDung = DateTime.Now;
            public string QuocLo = "";
            public string NoiDong = "";
            public string Vung = "";
            //public long DonGia1 = 0;
            //public DateTime NgayApDung2 = DateTime.Now;
            //public long DonGia2 = 0;
            //public DateTime NgayApDung3 = DateTime.Now;
            //public long DonGia3 = 0;
            //public DateTime NgayApDung4 = DateTime.Now;
            //public long DonGia4 = 0;
            //public DateTime NgayApDung5 = DateTime.Now;
            //public long DonGia5 = 0;
            //public DateTime NgayApDung6 = DateTime.Now;
            //public long DonGia6 = 0;
            //public DateTime NgayApDung7 = DateTime.Now;
            //public long DonGia7 = 0;
            //public DateTime NgayApDung8 = DateTime.Now;
            //public long DonGia8 = 0;
            //public DateTime NgayApDung9 = DateTime.Now;
            //public long DonGia9 = 0;
            //public DateTime NgayApDung10 = DateTime.Now;
            //public long DonGia10 = 0;
            //public DateTime NgayApDung11 = DateTime.Now;
            //public long DonGia11 = 0;
            //public DateTime NgayApDung12 = DateTime.Now;
            //public long DonGia12 = 0;
            //public long LanApDung = 1;
           


        public clsBaiTapKetVatTu()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsBaiTapKetVatTu(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                //id = lddata.DBModule.GetNewID(typeof(BaiTapKet), "tbl_BaiTapKetVatTu", cn, trans);
                //ID = DBModule.GetNewID(typeof(clsBaiTapKetVatTu), "tbl_BaiTapKetVatTu", cn, trans);
				//NgayTao = DateTime.Now;        
				//NgaySua = DateTime.Now;        
				// build SQL statement
                strSQL = "Insert into tbl_BaiTapKetVatTu" +
                //"(ID,TenBai,ThonID,KhoangCach,DonGia,GhiChu,XaID,NgayApDung1,DonGia1,NgayApDung2,DonGia2,NgayApDung3,DonGia3,NgayApDung4,DonGia4,NgayApDung5,DonGia5,NgayApDung6,DonGia6,NgayApDung7,DonGia7,NgayApDung8,DonGia8,NgayApDung9,DonGia9,NgayApDung10,DonGia10,NgayApDung11,DonGia11,NgayApDung12,DonGia12,LanApDung) Values(" +
                //    ID.ToString() + "," + "N'" + DBModule.RefineString(TenBai) + "'" + "," + ThonID.ToString() + "," + KhoangCach.ToString() + "," + DonGia.ToString() + "," + "N'" + DBModule.RefineString(GhiChu) + "'" + "," + XaID.ToString() + "," + DBModule.RefineDatetime(NgayApDung1) + "," + DonGia1.ToString() + "," + DBModule.RefineDatetime(NgayApDung2) + "," + DonGia2.ToString() + "," + DBModule.RefineDatetime(NgayApDung3) + "," + DonGia3.ToString() + "," + DBModule.RefineDatetime(NgayApDung4) + "," + DonGia4.ToString() + "," + DBModule.RefineDatetime(NgayApDung5) + "," + DonGia5.ToString() + "," + DBModule.RefineDatetime(NgayApDung6) + "," + DonGia6.ToString() + "," + DBModule.RefineDatetime(NgayApDung7) + "," + DonGia6.ToString() + "," + DBModule.RefineDatetime(NgayApDung8) + "," + DonGia8.ToString() + "," + DBModule.RefineDatetime(NgayApDung9) + "," + DonGia9.ToString() + "," + DBModule.RefineDatetime(NgayApDung10) + "," + DonGia10.ToString() + "," + DBModule.RefineDatetime(NgayApDung11) + "," + DonGia11.ToString() + "," + DBModule.RefineDatetime(NgayApDung12) + "," + DonGia12.ToString() + ")";
                "(TenBai,ThonID,KhoangCach,DonGia,GhiChu,XaID,CanBoNongVuID,NgayApDung) Values(" +
                   "N'" + DBModule.RefineString(TenBai) + "'" + "," + ThonID.ToString() + "," + KhoangCach.ToString() + "," + DonGia.ToString() + "," + "N'" + DBModule.RefineString(GhiChu) + "'" + "," + XaID.ToString() + "," + CanBoNongVuID.ToString() + "," + DBModule.RefineDatetime(NgayApDung) + "," + "N'" + DBModule.RefineString(QuocLo) + "'" + "," + "N'" + DBModule.RefineString(NoiDong) + "'" + "," + "N'" + DBModule.RefineString(Vung) + "'" + ")";
			}
			else // edit object, we update old record in database
			{
				// build SQL statement				    
				//NgaySua = DateTime.Now;        
                strSQL = "Update tbl_BaiTapKetVatTu set " +
                    "TenBai=" + "N'" + DBModule.RefineString(TenBai) + "'" + "," + "ThonID=" + ThonID.ToString() + "," + "KhoangCach=" + KhoangCach.ToString() + "," + "DonGia=" + DonGia.ToString() + "," + "GhiChu=" + "N'" + DBModule.RefineString(GhiChu) + "'" + "," + "XaID=" + XaID.ToString() + "," + "CanBoNongVuID=" + CanBoNongVuID.ToString() + "," + "NgayApDung=" + DBModule.RefineDatetime(NgayApDung) + "," + "QuocLo=" + "N'" + DBModule.RefineString(QuocLo) + "'" + "," + "NoiDong=" + "N'" + DBModule.RefineString(NoiDong) + "'" + "," + "Vung=" + "N'" + DBModule.RefineString(Vung) + "'" +
                    " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			DBModule.ExecuteNonQuery(strSQL, cn, trans);
			/*
			if( ID <= 0 )
				ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_BaiTapKetVatTu", cn, trans));
				*/
		}

        ////////////////////////////////////////////////////////////////////////////
        /////////////Hàm lấy giá cước vận chuyển của BTK phụ thuộc vào thời gian cân
       public static decimal GetGiaVanChuyen(long BTKID, DateTime NgayGioCan)
        {
            decimal DonGiaVanChuyen = 0;
            string sql = "Select Top 1 * From tbl_BaiTapKetVatTu_GiaCuoc Where NgayApDung<="+DBModule.RefineDatetime(NgayGioCan)+" AND BaiTapKetID=" + BTKID.ToString() + " Order By NgayApDung DESC";
            try
            {
                DataSet ds = DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow drGiaVC = ds.Tables[0].Rows[0];
                    DonGiaVanChuyen = Math.Round(decimal.Parse(drGiaVC["DonGia"].ToString()), 0);
                }
            }
            catch
            {
                DonGiaVanChuyen = 0;
            }
            return DonGiaVanChuyen;
        }
       /////////////////////////////////////////////////////////////////////////////
   
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_BaiTapKetVatTu where ID=" + ID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_BaiTapKetVatTu where ID=" + iID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_BaiTapKetVatTu where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
					if(!dr.IsNull("TenBai"))
                    TenBai = dr["TenBai"].ToString();
					if(!dr.IsNull("ThonID"))
                    ThonID = long.Parse(dr["ThonID"].ToString());
                    if (!dr.IsNull("XaID"))
                    XaID = long.Parse(dr["XaID"].ToString());

					if(!dr.IsNull("KhoangCach"))
                    KhoangCach = long.Parse(dr["KhoangCach"].ToString());

					if(!dr.IsNull("DonGia"))
                    DonGia = long.Parse(dr["DonGia"].ToString());

					if(!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();

                    if (!dr.IsNull("CanBoNongVuID"))
                    CanBoNongVuID = long.Parse(dr["CanBoNongVuID"].ToString());
                    if (!dr.IsNull("NgayApDung"))
                        NgayApDung = DateTime.Parse(dr["NgayApDung"].ToString());

                    if (!dr.IsNull("QuocLo"))
                        QuocLo = dr["QuocLo"].ToString();
                    if (!dr.IsNull("NoiDong"))
                        NoiDong = dr["NoiDong"].ToString();
                    if (!dr.IsNull("Vung"))
                        Vung = dr["Vung"].ToString();
                    //if (!dr.IsNull("DonGia"))
                    //    DonGia1 = long.Parse(dr["DonGia"].ToString());

                    //if (!dr.IsNull("NgayApDung2"))
                    //    NgayApDung2 = DateTime.Parse(dr["NgayApDung2"].ToString());
                    //if (!dr.IsNull("DonGia2"))
                    //    DonGia2 = long.Parse(dr["DonGia2"].ToString());
                    //if (!dr.IsNull("NgayApDung3"))
                    //    NgayApDung3 = DateTime.Parse(dr["NgayApDung3"].ToString());
                    //if (!dr.IsNull("DonGia3"))
                    //    DonGia3 = long.Parse(dr["DonGia3"].ToString());
                    //if (!dr.IsNull("NgayApDung4"))
                    //    NgayApDung4 = DateTime.Parse(dr["NgayApDung4"].ToString());
                    //if (!dr.IsNull("DonGia4"))
                    //    DonGia4 = long.Parse(dr["DonGia4"].ToString());
                    //if (!dr.IsNull("NgayApDung5"))
                    //    NgayApDung5 = DateTime.Parse(dr["NgayApDung5"].ToString());
                    //if (!dr.IsNull("DonGia5"))
                    //    DonGia5 = long.Parse(dr["DonGia5"].ToString());
                    //if (!dr.IsNull("NgayApDung6"))
                    //    NgayApDung6 = DateTime.Parse(dr["NgayApDung6"].ToString());
                    //if (!dr.IsNull("DonGia6"))
                    //    DonGia6 = long.Parse(dr["DonGia6"].ToString());
                    //if (!dr.IsNull("NgayApDung7"))
                    //    NgayApDung7 = DateTime.Parse(dr["NgayApDung7"].ToString());
                    //if (!dr.IsNull("DonGia7"))
                    //    DonGia7 = long.Parse(dr["DonGia7"].ToString());
                    //if (!dr.IsNull("NgayApDung8"))
                    //    NgayApDung8 = DateTime.Parse(dr["NgayApDung8"].ToString());
                    //if (!dr.IsNull("DonGia8"))
                    //    DonGia8 = long.Parse(dr["DonGia8"].ToString());
                    //if (!dr.IsNull("NgayApDung9"))
                    //    NgayApDung9 = DateTime.Parse(dr["NgayApDung9"].ToString());
                    //if (!dr.IsNull("DonGia9"))
                    //    DonGia9 = long.Parse(dr["DonGia9"].ToString());
                    //if (!dr.IsNull("NgayApDung10"))
                    //    NgayApDung10 = DateTime.Parse(dr["NgayApDung10"].ToString());
                    //if (!dr.IsNull("DonGia10"))
                    //    DonGia10 = long.Parse(dr["DonGia10"].ToString());
                    //if (!dr.IsNull("NgayApDung11"))
                    //    NgayApDung11 = DateTime.Parse(dr["NgayApDung11"].ToString());
                    //if (!dr.IsNull("DonGia11"))
                    //    DonGia11 = long.Parse(dr["DonGia11"].ToString());
                    //if (!dr.IsNull("NgayApDung12"))
                    //    NgayApDung12 = DateTime.Parse(dr["NgayApDung12"].ToString());
                    //if (!dr.IsNull("DonGia12"))
                    //    DonGia12 = long.Parse(dr["DonGia12"].ToString());
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_BaiTapKetVatTu ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);
            
            ds = DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_BaiTapKetVatTu WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
		#endregion
    }
}