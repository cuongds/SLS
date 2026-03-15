
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution.Entities
{
    public class clsImportDienTich
    {
			public long ID = -1;
            public string MaHopDong = "";
			public long HopDongID = -1;        
			public long ThonID = -1;        
			public long BaiTapKetID = -1;
            public long LoaiGiongID = -1;
            public long LoaiDatID = -1;
            public long KieuTrongID = -1;      
            public string HoTen = "";
            public string TenThon = "";
            public string TenBai = "";
            public string LoaiGiong = "";
            public string LoaiDat = "";
            public string KieuTrong = "";
            public string Errors = "";
            public long Importer = MDSolutionApp.User.ID;
            public DateTime DateImport = DateTime.Now;
			public long Modify=1;
            public DateTime DateModify = DateTime.MinValue;
            public decimal DienTich = 0;
            public decimal SanLuongDuKien = 0;
            public DateTime NgayTrong = DateTime.MinValue;
            public string TenXaMoi = "";
            public string TenThonMoi = "";
            public string MaThuaRuong = "";
        public clsImportDienTich()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public clsImportDienTich(long lID)
        {
            ID = lID;
        }
		#region Basic function: Save, Delete, Load, GetList
		public void Save(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";			
			if( ID <= 0 ) // new object, we insert new record to database
			{

                strSQL = "Insert Into tbl_Temp_Import_Excel_NhapDienTich(HopDongID,ThonID,BaiTapKetID,HoTen,TenThon,TenBai,Importer,DateImport,Errors,MaHopDong,DienTich,NgayTrong,TenXaMoi,TenThonMoi) Values(" +
                    HopDongID.ToString() + "," + ThonID.ToString() + "," + BaiTapKetID.ToString() +",N'"+HoTen+"',N'"+TenThon+"',N'"+TenBai+"',"
                    + Importer.ToString() + ",GetDate()" + ",N'" + Errors + "'" + ",N'" + MaHopDong + "'," + DBModule.RefineNumber(10000 * DienTich) + DBModule.RefineDatetime(NgayTrong, true) + ",N'" + TenXaMoi + "',N'" + TenXaMoi + "',N'" + MaThuaRuong + "')";
			}
			else // edit object, we update old record in database
			{
		        strSQL = "Update tbl_Temp_Import_Excel_NhapDienTich Set HopDongID= " + HopDongID.ToString() + ",ThonID=" + ThonID.ToString() + ",BaiTapKetID=" + BaiTapKetID.ToString() +
					",Hoten=N'"+HoTen+"',TenThon=N'"+TenThon+"',TenBai=N'"+TenBai+"',Modify=1,DateModify=GetDate(),Errors=N'',MaHopDong=N'"+MaHopDong+"'"+
                    ",DienTich="+DBModule.RefineNumber(10000*DienTich)+",NgayTrong="+DBModule.RefineDatetime(NgayTrong,true)+",LoaiGiong=N'"+LoaiGiong+"',LoaiDat=N'"+LoaiDat+"',KieuTrong=N'"+KieuTrong+"'"+
                    ",LoaiDatID="+LoaiDatID.ToString()+",LoaiGiongID="+LoaiGiongID.ToString()+",KieuTrongID="+KieuTrongID.ToString()+
                    ",SanLuongDuKien="+DBModule.RefineNumber(SanLuongDuKien)+",TenXaMoi=N'"+TenXaMoi+"',TenThonMoi=N'"+TenThonMoi+", MaThuRuong=N'"+MaThuaRuong+"' Where ID = " + ID.ToString();
			}
			// run SQL statement
			
			DBModule.ExecuteNonQuery(strSQL, cn, trans);
			
		}
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
            strSQL = "Delete from tbl_Temp_Import_Excel_NhapDienTich where ID=" + ID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
		public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
		{
			string strSQL = "";
			// build SQL statement
            strSQL = "Delete from tbl_Temp_Import_Excel_NhapDienTich where ID=" + iID.ToString();
			// run SQL statement
			DBModule.ExecuteNonQuery(strSQL, cn, trans);            
		}	
        public void Load(OleDbConnection cn, OleDbTransaction trans)
		{			
			// build SQL statement
			string strSQL = "";
            strSQL = "Select * from tbl_Temp_Import_Excel_NhapDienTich where ID=" + ID.ToString();
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
                if (!dr.IsNull("DienTich"))
                    DienTich = decimal.Parse(dr["DienTich"].ToString());
                if (!dr.IsNull("NgayTrong"))
                    NgayTrong = DateTime.Parse(dr["NgayTrong"].ToString());
                if (!dr.IsNull("LoaiGiong"))
                    LoaiGiong = dr["LoaiGiong"].ToString();
                if (!dr.IsNull("LoaiDat"))
                    LoaiDat = dr["LoaiDat"].ToString();
                if (!dr.IsNull("KieuTrong"))
                    KieuTrong = dr["KieuTrong"].ToString();
                if (!dr.IsNull("LoaiDatID"))
                    LoaiDatID = long.Parse(dr["LoaiDatID"].ToString());
                if (!dr.IsNull("LoaiGiongID"))
                    LoaiGiongID = long.Parse(dr["LoaiGiongID"].ToString());
                if (!dr.IsNull("KieuTrongID"))
                    KieuTrongID = long.Parse(dr["KieuTrongID"].ToString());
                if (!dr.IsNull("SanLuongDuKien"))
                    SanLuongDuKien = decimal.Parse(dr["SanLuongDuKien"].ToString());
                if (!dr.IsNull("TenXaMoi"))
                    TenThonMoi = dr["TenThonMoi"].ToString();
                if (!dr.IsNull("TenThonMoi"))
                    TenThonMoi = dr["TenThonMoi"].ToString();
                if (!dr.IsNull("MaThuaRuong"))
                    MaThuaRuong = dr["MaThuaRuong"].ToString();
			}
	
		}
      
		
		#endregion
    }
}