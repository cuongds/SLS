using System;
using System.Data;
using System.Data.OleDb;

namespace MDSolution
{
    internal class clsKeHoachUngTienMat
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
        public long ModifyByUserID = -1;
        public DateTime DataModify = DateTime.MinValue;
        public DateTime DateModify = DateTime.MinValue;
        public long CheckedByUserID = -1;
        public DateTime DateChecked = DateTime.MinValue;
        public long ApprovedByUserID = -1;
        public DateTime DateApproved = DateTime.MinValue;
        public long Status = -1;
        public string NoteModify = "";
        // Status =1 chua duyet, Status = 2 da duyet, Status= 3 da xac nhan, Status=4 da chuyen thanh toan
        public clsKeHoachUngTienMat()
        {
            // Default constructor
        }

        public clsKeHoachUngTienMat(long id)
        {
            ID = id;
        }

        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0)
            {
                strSQL = "Insert Into tbl_KeHoachUngTienMat" +
                "(Sotien, NgayUng, HopDongID, VuTrongID, TenDot, GhiChu, CreatedByUserID, DateAdd, ModifyByUserID, DataModify, DateModify, CheckedByUserID, DateChecked, ApprovedByUserID, DateApproved, Status, NoteModify) Values("
                + Sotien.ToString() + ", "
                + DBModule.RefineDatetime(NgayUng, true) + ", "
                + HopDongID.ToString() + ", "
                + VuTrongID.ToString() + ", "
                + "N'" + DBModule.RefineString(TenDot) + "', "
                + "N'" + DBModule.RefineString(GhiChu) + "', "
                + CreatedByUserID.ToString() + ", "
                + DBModule.RefineDatetime(DateAdd, true) + ", "
                + ModifyByUserID.ToString() + ", "
                + DBModule.RefineDatetime(DataModify, true) + ", "
                + DBModule.RefineDatetime(DateModify, true) + ", "
                + CheckedByUserID.ToString() + ", "
                + DBModule.RefineDatetime(DateChecked, true) + ", "
                + ApprovedByUserID.ToString() + ", "
                + DBModule.RefineDatetime(DateApproved, true) + ", "
                + Status.ToString() + ", "
                + "N'" + DBModule.RefineString(NoteModify) + "');";
                strSQL += "SELECT @@IDENTITY AS 'Identity';";
                ID = int.Parse(DBModule.ExecuteQueryForOneResult(strSQL, cn, trans));
            }
            else
            {
                strSQL = "Update tbl_KeHoachUngTienMat Set "
                + "Sotien=" + Sotien.ToString() + ", "
                + "NgayUng=" + DBModule.RefineDatetime(NgayUng, true) + ", "
                + "HopDongID=" + HopDongID.ToString() + ", "
                + "VuTrongID=" + VuTrongID.ToString() + ", "
                + "TenDot=N'" + DBModule.RefineString(TenDot) + "', "
                + "GhiChu=N'" + DBModule.RefineString(GhiChu) + "', "
                + "ModifyByUserID=" + ModifyByUserID.ToString() + ", "
                + "DataModify=" + DBModule.RefineDatetime(DataModify, true) + ", "
                + "DateModify=" + DBModule.RefineDatetime(DateModify, true) + ", "
                + "CheckedByUserID=" + CheckedByUserID.ToString() + ", "
                + "DateChecked=" + DBModule.RefineDatetime(DateChecked, true) + ", "
                + "ApprovedByUserID=" + ApprovedByUserID.ToString() + ", "
                + "DateApproved=" + DBModule.RefineDatetime(DateApproved, true) + ", "
                + "Status=" + Status.ToString() + ", "
                + "NoteModify=N'" + DBModule.RefineString(NoteModify) + "'"
                + " Where ID=" + ID.ToString();
                DBModule.ExecuteNonQuery(strSQL, cn, trans);
            }
        }

        public static void  Delete(long ID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "Delete from tbl_KeHoachUngTienMat where ID=" + ID.ToString();
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
       
        public void LoadHopDongID(long HopDongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "Select * from tbl_KeHoachUngTienMat where HopDongID=" + HopDongID.ToString();
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
                if (!dr.IsNull("ModifyByUserID")) ModifyByUserID = long.Parse(dr["ModifyByUserID"].ToString());
                if (!dr.IsNull("DataModify")) DataModify = DateTime.Parse(dr["DataModify"].ToString());
                if (!dr.IsNull("DateModify")) DateModify = DateTime.Parse(dr["DateModify"].ToString());
                if (!dr.IsNull("CheckedByUserID")) CheckedByUserID = long.Parse(dr["CheckedByUserID"].ToString());
                if (!dr.IsNull("DateChecked")) DateChecked = DateTime.Parse(dr["DateChecked"].ToString());
                if (!dr.IsNull("ApprovedByUserID")) ApprovedByUserID = long.Parse(dr["ApprovedByUserID"].ToString());
                if (!dr.IsNull("DateApproved")) DateApproved = DateTime.Parse(dr["DateApproved"].ToString());
                if (!dr.IsNull("Status")) Status = int.Parse(dr["Status"].ToString());
                if (!dr.IsNull("NoteModify")) NoteModify = dr["NoteModify"].ToString();
            }
        }

        public void LoadStatus(long ID, long Status, long VuTrongID,DateTime TuNgayUng,DateTime DenNgayUng, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "Select * from tbl_KeHoachUngTienMat where   Status=" + Status.ToString() + " AND VuTrongID =" + VuTrongID;
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
                if (!dr.IsNull("ModifyByUserID")) ModifyByUserID = long.Parse(dr["ModifyByUserID"].ToString());
                if (!dr.IsNull("DataModify")) DataModify = DateTime.Parse(dr["DataModify"].ToString());
                if (!dr.IsNull("DateModify")) DateModify = DateTime.Parse(dr["DateModify"].ToString());
                if (!dr.IsNull("CheckedByUserID")) CheckedByUserID = long.Parse(dr["CheckedByUserID"].ToString());
                if (!dr.IsNull("DateChecked")) DateChecked = DateTime.Parse(dr["DateChecked"].ToString());
                if (!dr.IsNull("ApprovedByUserID")) ApprovedByUserID = long.Parse(dr["ApprovedByUserID"].ToString());
                if (!dr.IsNull("DateApproved")) DateApproved = DateTime.Parse(dr["DateApproved"].ToString());
                if (!dr.IsNull("Status")) Status = long.Parse(dr["Status"].ToString());
                if (!dr.IsNull("NoteModify")) NoteModify = dr["NoteModify"].ToString();
            }
        }
    }
}
