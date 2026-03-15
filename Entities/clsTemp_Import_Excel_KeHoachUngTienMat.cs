using System;
using System.Data;
using System.Data.OleDb;

namespace MDSolution
{
    internal class clsTemp_Import_Excel_KeHoachUngTienMat
    {
        public long ID = -1;
        public decimal Sotien = 0;
        public DateTime NgayUng = DateTime.MinValue;
        public long HopDongID = -1;
        public long VuTrongID = -1;
        public string TenDot = "";
        public string GhiChu = "";
        public long CreatedByUserID = -1;
        public DateTime DateAdd = DateTime.MinValue;
        public long Status = -1;
        public string Errors = "";
        public long Importer = -1;        
        public DateTime DateImport = DateTime.MinValue;
        public long Modify = -1;
        public DateTime DateModify = DateTime.MinValue;
        public string MaHopDong = "";
        public string HoTen = "";        
        public clsTemp_Import_Excel_KeHoachUngTienMat()
        {
            // Default constructor
        }

        public clsTemp_Import_Excel_KeHoachUngTienMat(long id)
        {
            ID = id;
        }

        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0)
            {
                strSQL = "Insert Into tbl_Temp_Import_Excel_KeHoachUngTienMat" +
                "([Sotien],[NgayUng],[HopDongID],[VuTrongID],[TenDot],[GhiChu],[CreatedByUserID],[DateAdd],[Status],[Errors],[Importer],[DateImport],[Modify],[DateModify],[MaHopDong],[HoTen]) Values("
                + Sotien.ToString() + ", "
                + DBModule.RefineDatetime(NgayUng, true) + ", "
                + HopDongID.ToString() + ", "
                + VuTrongID.ToString() + ", "
                + "N'" + DBModule.RefineString(TenDot) + "', "
                + "N'" + DBModule.RefineString(GhiChu) + "', "
                + CreatedByUserID.ToString() + ", "
                + DBModule.RefineDatetime(DateAdd, true) + ", "
                + Status.ToString() + ", "
                + "N'" + DBModule.RefineString(Errors) + "', "
                + Importer.ToString() + ", "
                + DBModule.RefineDatetime(DateImport, true) + ", "
                + Modify.ToString() + ", "
                + DBModule.RefineDatetime(DateModify, true) + ", "
                + "N'" + DBModule.RefineString(MaHopDong) + "', "
                + "N'" + DBModule.RefineString(HoTen) + "')";
                strSQL += "SELECT @@IDENTITY AS 'Identity';";
                ID = int.Parse(DBModule.ExecuteQueryForOneResult(strSQL, cn, trans));
            }
            else
            {
                strSQL = "Update tbl_Temp_Import_Excel_KeHoachUngTienMat Set "
                + "Sotien=" + Sotien.ToString() + ", "
                + "NgayUng=" + DBModule.RefineDatetime(NgayUng, true) + ", "
                + "HopDongID=" + HopDongID.ToString() + ", "
                + "VuTrongID=" + VuTrongID.ToString() + ", "
                + "TenDot=N'" + DBModule.RefineString(TenDot) + "', "
                + "GhiChu=N'" + DBModule.RefineString(GhiChu) + "', "  
                + "CreatedByUserID=" + CreatedByUserID.ToString() + ", "
                + "DateAdd=" + DBModule.RefineDatetime(DateAdd, true) + ", "
                + "Status=" + Status.ToString() + ", "
                + "Errors=N'" + DBModule.RefineString(Errors) + "', "
                + "Importer=" + Importer.ToString() + ", "                    
                + "DateModify=" + DBModule.RefineDatetime(DateModify, true) + ", "
                + "Modify=" + Modify.ToString() + ", "                    
                + "MaHopDong=N'" + DBModule.RefineString(MaHopDong) + "', "
                + "HoTen=N'" + DBModule.RefineString(HoTen) + "'"
                + " Where ID=" + ID.ToString();
                DBModule.ExecuteNonQuery(strSQL, cn, trans);
            }
        }

        public static void  Delete(long ID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "Delete from tbl_Temp_Import_Excel_KeHoachUngTienMat where ID=" + ID.ToString();
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void LoadID(long ID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "Select * from tbl_Temp_Import_Excel_KeHoachUngTienMat where ID=" + ID.ToString();
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID")) ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("Sotien")) Sotien = decimal.Parse(dr["Sotien"].ToString());
                if (!dr.IsNull("NgayUng")) NgayUng = DateTime.Parse(dr["NgayUng"].ToString());
                if (!dr.IsNull("HopDongID")) HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("VuTrongID")) VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("TenDot")) TenDot = dr["TenDot"].ToString();
                if (!dr.IsNull("GhiChu")) GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("CreatedByUserID")) CreatedByUserID = long.Parse(dr["CreatedByUserID"].ToString());
                if (!dr.IsNull("DateAdd")) DateAdd = DateTime.Parse(dr["DateAdd"].ToString());
                if (!dr.IsNull("Status")) Status = long.Parse(dr["Status"].ToString());
                if (!dr.IsNull("Errors")) Errors = dr["Errors"].ToString();
                if (!dr.IsNull("Importer")) Importer = long.Parse(dr["Importer"].ToString());
                if (!dr.IsNull("DateImport")) DateImport = DateTime.Parse(dr["DateImport"].ToString());
                if (!dr.IsNull("Modify")) Modify = long.Parse(dr["Modify"].ToString());
                if (!dr.IsNull("DateModify")) DateModify = DateTime.Parse(dr["DateModify"].ToString());
                if (!dr.IsNull("MaHopDong")) MaHopDong = dr["MaHopDong"].ToString();
                if (!dr.IsNull("HoTen")) HoTen = dr["HoTen"].ToString();
            }
        }
        public void LoadHopDongID(long HopDongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "Select * from tbl_Temp_Import_Excel_KeHoachUngTienMat where HopDongID=" + HopDongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID")) ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("Sotien")) Sotien = decimal.Parse(dr["Sotien"].ToString());
                if (!dr.IsNull("NgayUng")) NgayUng = DateTime.Parse(dr["NgayUng"].ToString());
                if (!dr.IsNull("HopDongID")) HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("VuTrongID")) VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("TenDot")) TenDot = dr["TenDot"].ToString();
                if (!dr.IsNull("GhiChu")) GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("CreatedByUserID")) CreatedByUserID = long.Parse(dr["CreatedByUserID"].ToString());
                if (!dr.IsNull("DateAdd")) DateAdd = DateTime.Parse(dr["DateAdd"].ToString());
                if (!dr.IsNull("Status")) Status = long.Parse(dr["Status"].ToString());
                if (!dr.IsNull("Errors")) Errors = dr["Errors"].ToString();
                if (!dr.IsNull("Importer")) Importer = long.Parse(dr["Importer"].ToString());
                if (!dr.IsNull("DateImport")) DateImport = DateTime.Parse(dr["DateImport"].ToString());
                if (!dr.IsNull("Modify")) Modify = long.Parse(dr["Modify"].ToString());
                if (!dr.IsNull("DateModify")) DateModify = DateTime.Parse(dr["DateModify"].ToString());
                if (!dr.IsNull("MaHopDong")) MaHopDong = dr["MaHopDong"].ToString();
                if (!dr.IsNull("HoTen")) HoTen = dr["HoTen"].ToString();
            }
        }

        public void LoadStatus(long ID, long Status, long VuTrongID,DateTime TuNgayUng,DateTime DenNgayUng, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "Select * from tbl_Temp_Import_Excel_KeHoachUngTienMat where   Status=" + Status.ToString() + " AND VuTrongID =" + VuTrongID;
            if (ID > 0)
            {
                strSQL = strSQL + " AND ID=" + ID.ToString();
            }
            if (TuNgayUng > DateTime.MinValue && DenNgayUng > DateTime.MinValue)
            { 
            strSQL = strSQL + " AND NgayUng Between " + DBModule.RefineDatetime(TuNgayUng, true) + " AND " + DBModule.RefineDatetime(DenNgayUng, true);
            }
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID")) ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("Sotien")) Sotien = decimal.Parse(dr["Sotien"].ToString());
                if (!dr.IsNull("NgayUng")) NgayUng = DateTime.Parse(dr["NgayUng"].ToString());
                if (!dr.IsNull("HopDongID")) HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("VuTrongID")) VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("TenDot")) TenDot = dr["TenDot"].ToString();
                if (!dr.IsNull("GhiChu")) GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("CreatedByUserID")) CreatedByUserID = long.Parse(dr["CreatedByUserID"].ToString());
                if (!dr.IsNull("DateAdd")) DateAdd = DateTime.Parse(dr["DateAdd"].ToString());
                if (!dr.IsNull("Status")) Status = long.Parse(dr["Status"].ToString());
                if (!dr.IsNull("Errors")) Errors = dr["Errors"].ToString();
                if (!dr.IsNull("Importer")) Importer = long.Parse(dr["Importer"].ToString());
                if (!dr.IsNull("DateImport")) DateImport = DateTime.Parse(dr["DateImport"].ToString());
                if (!dr.IsNull("Modify")) Modify = long.Parse(dr["Modify"].ToString());
                if (!dr.IsNull("DateModify")) DateModify = DateTime.Parse(dr["DateModify"].ToString());
                if (!dr.IsNull("MaHopDong")) MaHopDong = dr["MaHopDong"].ToString();
                if (!dr.IsNull("HoTen")) HoTen = dr["HoTen"].ToString();

            }
        }
    }
}
