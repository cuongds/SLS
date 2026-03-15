
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsHopDongVanChuyen
    {
			public long ID = -1;        
			public string TenChuHopDong = "";        
			public DateTime NgayHopDong = DateTime.MinValue;
            public long VutrongID = MDSolutionApp.VuTrongID;
			public string DienThoai = "";        
			public string DiaChi = "";        
			public string GhiChu = "";
            public string MaHopDong = "";
            public string MaSoThue = "";
            public string SoTKNganHang = "";
            public string CMT = "";
            public DateTime NgayCapCMT = DateTime.MinValue;
            public string NoiCap = "";
            public string NguyenQuan = "";
            public string NoteModify = "";
            public long DaChuyenVu = 0;
            public long MuaTaiBanCan = 0;
        public clsHopDongVanChuyen()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsHopDongVanChuyen(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {           
                    strSQL = "Insert into tbl_HopDongVanChuyen" +
                    "(TenChuHopDong,NgayHopDong,DienThoai,DiaChi,GhiChu,MaHopDong,CreatedBy,DateAdd,NoteModify,VuTrongID,MaSoThue,SoTKNganHang,CMT,DaChuyenVu,NgayCapCMT,NoiCap,NguyenQuan,MuaTaiBanCan) Values(" +
                    "N'" + DBModule.RefineString(TenChuHopDong) + "'" + 
                    "," + DBModule.RefineDatetime(NgayHopDong, true) + "," +
                    "N'" + DBModule.RefineString(DienThoai) + "'" + "," + 
                    "N'" + DBModule.RefineString(DiaChi) + "'" + "," + 
                    "N'" + DBModule.RefineString(GhiChu) + "'" + "," + 
                    "N'" + DBModule.RefineString(MaHopDong) + "'" +
                    ", " + MDSolutionApp.User.ID.ToString() +
                    ", getdate() " +
                    ", N'" + DBModule.RefineString(NoteModify) +"'"+
                    ","+VutrongID.ToString()+
                    ",N'"+MaSoThue+"'"+
                    ",N'"+SoTKNganHang+"'"+
                    ",N'" + CMT + "'," + DaChuyenVu.ToString() + "," + DBModule.RefineDatetime(NgayCapCMT, true) + ",N'" + NoiCap + "',N'" + NguyenQuan + "'" + "," + MuaTaiBanCan.ToString() + ")";                
            }
            else // edit object, we update old record in database
            {
                   strSQL = "Update tbl_HopDongVanChuyen set " +
                        "TenChuHopDong=" + "N'" + DBModule.RefineString(TenChuHopDong) + "'" + "," +
                        "NgayHopDong=" + DBModule.RefineDatetime(NgayHopDong, true) + "," + 
                        "DienThoai=" + "N'" + DBModule.RefineString(DienThoai) + "'" + "," + 
                        "DiaChi=" + "N'" + DBModule.RefineString(DiaChi) + "'" + "," + 
                        "GhiChu=" + "N'" + DBModule.RefineString(GhiChu) + "'" + ","  + 
                        "MaHopDong=" + "N'" + DBModule.RefineString(MaHopDong) + "'" +
                        ",ModifyBy = " + MDSolutionApp.User.ID.ToString() +
                        ",DataModify = getdate() " +
                        ",NoteModify = '" + DBModule.RefineString(NoteModify) +"'"+
                        ",MaSoThue=N'" + MaSoThue + "'" +
                        ",SoTKNganHang=N'" + SoTKNganHang + "'" +
                        ",CMT=N'" + CMT + "',DaChuyenVu=" +DaChuyenVu.ToString()+",NgayCapCMT="+DBModule.RefineDatetime(NgayCapCMT,true)+
                        ",NoiCap=N'"+NoiCap+"',NguyenQuan=N'"+NguyenQuan+"'"+
                        ",MuaTaiBanCan = " + MuaTaiBanCan.ToString() +
                        " Where ID = " + ID.ToString();
               
            }
			// run SQL statement
			
			DBModule.ExecuteNonQuery(strSQL, cn, trans);
            if (ID <= 0)
            {
                ID = long.Parse(DBModule.ExecuteQueryForOneResult("SELECT ISNull(Max(ID),0) FROM tbl_HopDongVanChuyen", cn, trans));
            }
                
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_HopDongVanChuyen where ID=" + ID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
			strSQL = "Delete from tbl_HopDongVanChuyen where ID=" + iID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
			strSQL = "Select * from tbl_HopDongVanChuyen where ID=" + ID.ToString();
			// run SQL statement
			DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

			// fill data into this object
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
					if(!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
					if(!dr.IsNull("TenChuHopDong"))
                    TenChuHopDong = dr["TenChuHopDong"].ToString();
					if(!dr.IsNull("NgayHopDong"))
                    NgayHopDong = DateTime.Parse(dr["NgayHopDong"].ToString());
					if(!dr.IsNull("DienThoai"))
                    DienThoai = dr["DienThoai"].ToString();
					if(!dr.IsNull("DiaChi"))
                    DiaChi = dr["DiaChi"].ToString();
					if(!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
                    if(!dr.IsNull("MaHopDong"))
                    MaHopDong = dr["MaHopDong"].ToString();
                    if (!dr.IsNull("MaSoThue"))
                        MaSoThue = dr["MaSoThue"].ToString();
                    if (!dr.IsNull("SoTKNganHang"))
                        SoTKNganHang = dr["SoTKNganHang"].ToString();
                    if (!dr.IsNull("CMT"))
                        CMT = dr["CMT"].ToString();
                    if (!dr.IsNull("DaChuyenVu"))
                        DaChuyenVu = long.Parse(dr["DaChuyenVu"].ToString());
                    if (!dr.IsNull("NgayCapCMT"))
                        NgayCapCMT = DateTime.Parse(dr["NgayCapCMT"].ToString());
                    if (!dr.IsNull("NoiCap"))
                        NoiCap = dr["NoiCap"].ToString();
                    if (!dr.IsNull("NguyenQuan"))
                        NguyenQuan = dr["NguyenQuan"].ToString();
                    if (!dr.IsNull("MuaTaiBanCan"))
                    MuaTaiBanCan = long.Parse(dr["MuaTaiBanCan"].ToString());
					
                
			}
	
		}

        public void Load(string MaHopDong,OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_HopDongVanChuyen where MaHopDong='" + MaHopDong +"' AND VuTrongID = " + MDSolutionApp.VuTrongID;
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("TenChuHopDong"))
                    TenChuHopDong = dr["TenChuHopDong"].ToString();
                if (!dr.IsNull("NgayHopDong"))
                    NgayHopDong = DateTime.Parse(dr["NgayHopDong"].ToString());
                if (!dr.IsNull("DienThoai"))
                    DienThoai = dr["DienThoai"].ToString();
                if (!dr.IsNull("DiaChi"))
                    DiaChi = dr["DiaChi"].ToString();
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("MaHopDong"))
                    MaHopDong = dr["MaHopDong"].ToString();
                if (!dr.IsNull("MaSoThue"))
                    MaSoThue = dr["MaSoThue"].ToString();
                if (!dr.IsNull("SoTKNganHang"))
                    SoTKNganHang = dr["SoTKNganHang"].ToString();
                if (!dr.IsNull("CMT"))
                    CMT = dr["CMT"].ToString();
                if (!dr.IsNull("DaChuyenVu"))
                    DaChuyenVu = long.Parse(dr["DaChuyenVu"].ToString());
                if (!dr.IsNull("NgayCapCMT"))
                    NgayCapCMT = DateTime.Parse(dr["NgayCapCMT"].ToString());
                if (!dr.IsNull("NoiCap"))
                    NoiCap = dr["NoiCap"].ToString();
                if (!dr.IsNull("NguyenQuan"))
                    NguyenQuan = dr["NguyenQuan"].ToString();
                if (!dr.IsNull("MuaTaiBanCan"))
                    MuaTaiBanCan = long.Parse(dr["MuaTaiBanCan"].ToString());
            }

        }
      
		public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {           
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_HopDongVanChuyen ";                 
            if((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);
            
            ds = DBModule.ExecuteQuery(strSQL, cn, trans);
           
        }
		public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
				if (strFields=="")strFields = " tbl_XeVanChuyen.SoXe, tbl_HopDongVanChuyen.*";
				string strSQL = "SELECT "+strFields+" FROM  tbl_HopDongVanChuyen INNER JOIN tbl_XeVanChuyen ON tbl_HopDongVanChuyen.ID = tbl_XeVanChuyen.HopDongVanChuyenID WHERE 1=1"; 
				if (strWhere!="" )strSQL +=" AND "+strWhere;
				if (strOrderBy!="" )strSQL +=" Order By " + strOrderBy;
				return  DBModule.ExecuteQuery(strSQL, cn, trans);           
        }
        public static DataSet GetListbyWhere2(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_HopDongVanChuyen WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }
		#endregion
    }
}