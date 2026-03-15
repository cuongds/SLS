
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsBaiTapKet_GiaCuoc
    {
			public long ID = -1;
            public DateTime NgayApDung = DateTime.Now;
            public decimal DonGia = 0;    			       
			public long DotApDung = -1;
            public long VuTrongID = MDSolutionApp.VuTrongID;  
			public long BaiTapKetID = -1;        			   
			public string GhiChu = "";
            public decimal DonGiaVanChuyenVatTu;
            public DateTime NgayAD_GiaVC_VT = DateTime.Now;
             
        public clsBaiTapKet_GiaCuoc()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsBaiTapKet_GiaCuoc(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                strSQL = "Insert into tbl_BaiTapKet_GiaCuoc" +
                        "(NgayApDung,DonGia,DotApDung,VuTrongID,BaiTapKetID,GhiChu,DonGiaVanChuyenVatTu,NgayAD_GiaVC_VT) Values(" +
                         DBModule.RefineDatetime(NgayApDung) + "," + DBModule.RefineNumber(DonGia) + "," + DotApDung.ToString() + "," + VuTrongID.ToString() + "," +
                         BaiTapKetID.ToString() + ",N'" + DBModule.RefineString(GhiChu) + "'," + DBModule.RefineNumber(DonGiaVanChuyenVatTu)+"," + DBModule.RefineDatetime(NgayAD_GiaVC_VT)+")";
			}
			else // edit object, we update old record in database
			{   
                strSQL = "Update tbl_BaiTapKet_GiaCuoc Set NgayApDung=" + DBModule.RefineDatetime(NgayApDung) +  "," + "DonGia=" + DonGia.ToString() + "," 
                         + "DotApDung=" + DotApDung.ToString() + "," + "VuTrongID=" + VuTrongID.ToString() + "," + "GhiChu=" + "N'" + DBModule.RefineString(GhiChu) +"',"
                         + "DonGiaVanChuyenVatTu=" + DBModule.RefineNumber(DonGiaVanChuyenVatTu) + ",NgayAD_GiaVC_VT=" + DBModule.RefineDatetime(NgayAD_GiaVC_VT)
                         + " Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			DBModule.ExecuteNonQuery(strSQL, cn, trans);
		
		}
        public static void Add_DotGia(long BTKID,long MaxDot,decimal DG)
        {
            string sql = "sp_CapNhatCuocVanChuyen_Dot " + MDSolutionApp.VuTrongID.ToString() + "," + BTKID.ToString() + "," + MaxDot.ToString() + "," + DG.ToString();
           
            try
            {
                DBModule.ExecuteNonQuery(sql, null, null);
            }
            catch
            {

            }
         
        }
        public static long DotApDungMax(long VuTrongID)
        {
            long MaxDotAD = 1;
            string sql="Select MAX(DotApDung) From tbl_BaiTapKet_GiaCuoc Where VuTrongID="+VuTrongID.ToString();
            try
            {
                MaxDotAD=long.Parse(DBModule.ExecuteQueryForOneResult(sql,null,null));
            }
            catch
            {
            }
            return MaxDotAD;
        }

        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_BaiTapKet_GiaCuoc where ID=" + ID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_BaiTapKet_GiaCuoc where ID=" + iID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_BaiTapKet_GiaCuoc where ID=" + ID.ToString();
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
                        DonGia = decimal.Parse(dr["DonGia"].ToString());
                    if (!dr.IsNull("DotApDung"))
                        DotApDung = long.Parse(dr["DotApDung"].ToString());
					if(!dr.IsNull("VuTrongID"))
                        VuTrongID = long.Parse(dr["VuTrongID"].ToString());
					if(!dr.IsNull("BaiTapKetID"))
                        BaiTapKetID = long.Parse(dr["BaiTapKetID"].ToString());
					if(!dr.IsNull("GhiChu"))
                        GhiChu = dr["GhiChu"].ToString();
                    if (!dr.IsNull("DonGiaVanChuyenVatTu"))
                        DonGiaVanChuyenVatTu = decimal.Parse(dr["DonGiaVanChuyenVatTu"].ToString());
                    if (!dr.IsNull("NgayAD_GiaVC_VT"))
                        NgayAD_GiaVC_VT = DateTime.Parse(dr["NgayAD_GiaVC_VT"].ToString());
			}
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_BaiTapKet_GiaCuoc ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);
            
            ds = DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = "*";
				string strSQL = "SELECT "+strFields+" FROM tbl_BaiTapKet_GiaCuoc WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  DBModule.ExecuteQuery(strSQL, cn, trans);           
        }        
		#endregion
    }
}