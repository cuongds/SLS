using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;

namespace MDSolution
{
   public class cls_GiaMia_ThongBao
    {
           public long ID = -1;		
           public string TenThongBao = "";        
		   public DateTime NgayGioApDung=DateTime.Now;        
		   public decimal DonGia = 0;
           public long VuTrongID = MDSolutionApp.VuTrongID;
           public decimal DonGiaMiaRep = 0;
           public long MaxID = 0;
           public decimal DonGiaHopDong = 0;
        public cls_GiaMia_ThongBao()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public cls_GiaMia_ThongBao(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{
                strSQL = "Insert into tbl_GiaNhapMia(TenThongBao,NgayGioApDung,DonGia,VuTrongID,DonGiaMiaRep,DonGiaHopDong) Values(" +
					"N'" + TenThongBao + "'"+","+DBModule.RefineDatetime(NgayGioApDung)+","+DBModule.RefineNumber(DonGia)+","+VuTrongID.ToString()+","
                    + DBModule.RefineNumber(DonGiaMiaRep) + "," + DBModule.RefineNumber(DonGiaHopDong) + ")";
			}
			else // edit object, we update old record in database
			{
                strSQL = "Update tbl_GiaNhapMia set " +
                    "TenThongBao=" + "N'" + TenThongBao + "'" + "," + "NgayGioApDung=" + DBModule.RefineDatetime(NgayGioApDung) + ",DonGia=" + DBModule.RefineNumber(DonGia) +
                    ",DonGiaMiaRep=" + DBModule.RefineNumber(DonGiaMiaRep) + ",DonGiaHopDong=" + DBModule.RefineNumber(DonGiaHopDong) + " Where ID = " + ID.ToString();
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
            strSQL = "Delete from tbl_GiaNhapMia where ID=" + ID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
            strSQL = "Delete from tbl_GiaNhapMia where ID=" + iID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}
        public long FindMaxID()
        {
            string strSQL = "Select Max(ID) as MaxID from tbl_GiaNhapMia where VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
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
            strSQL = "Select * from tbl_GiaNhapMia where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("TenThongBao"))
                    TenThongBao = dr["TenThongBao"].ToString();
                if (!dr.IsNull("NgayGioApDung"))
                    NgayGioApDung = DateTime.Parse(dr["NgayGioApDung"].ToString());
                if (!dr.IsNull("DonGia"))
                    DonGia = decimal.Parse(dr["DonGia"].ToString());
                if (!dr.IsNull("DonGiaMiaRep"))
                    DonGiaMiaRep = long.Parse(dr["DonGiaMiaRep"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("DonGiaHopDong"))
                    DonGiaHopDong = decimal.Parse(dr["DonGiaHopDong"].ToString());
            }
	
		}
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_GiaNhapMia ";                 
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
