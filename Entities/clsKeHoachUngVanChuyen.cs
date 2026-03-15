using System;
using System.Data;
using System.Data.OleDb;

namespace MDSolution
{
    internal class clsKeHoachUngVanChuyen
    {
        public long ID = -1;
        public string LoaiVatTu = "";
        public string SoChungTu = "";
        public decimal DonGia = 0;
        public decimal SoLuong = 0;
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
        public long NguoiDuyet = -1;
        public DateTime NgayDuyet = DateTime.MinValue;
        public long Nguoi_TC_Duyet = -1;
        public DateTime Ngay_TC_Duyet = DateTime.MinValue;
        public long Nguoi_TC_XN = -1;
        public DateTime Ngay_TC_XN = DateTime.MinValue;
        public string NoteModify = "";
        public long LoaiVatTuID = -1;
        public string BangChu = "";
        public long Xoa = 0;

        // Status =1 chua duyet, Status = 2 da duyet, Status= 3 da xac nhan, Status=4 da chuyen thanh toan
        public clsKeHoachUngVanChuyen()
        {
            // Default constructor
        }

        public clsKeHoachUngVanChuyen(long id)
        {
            ID = id;
        }

        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0)
            {
                strSQL = "Insert Into tbl_KeHoachUngVanChuyen" +
                "(LoaiVatTu, SoChungTu, DonGia, SoLuong, Sotien, NgayUng, HopDongID, VuTrongID, TenDot, GhiChu, " +
                "CreatedByUserID, DateAdd, ModifyByUserID, DataModify, DateModify, CheckedByUserID, DateChecked, " +
                "ApprovedByUserID, DateApproved, Status, NguoiDuyet, NgayDuyet, Nguoi_TC_Duyet, Ngay_TC_Duyet, " +
                "Nguoi_TC_XN, Ngay_TC_XN, NoteModify, LoaiVatTuID,BangChu,Xoa) Values("
                 + "N'" + DBModule.RefineString(LoaiVatTu) + "', "
                 + "N'" + DBModule.RefineString(SoChungTu) + "', "
                 + DonGia.ToString() + ", "
                 + SoLuong.ToString() + ", "
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
                 + NguoiDuyet.ToString() + ", "
                 + DBModule.RefineDatetime(NgayDuyet, true) + ", "
                 + Nguoi_TC_Duyet.ToString() + ", "
                 + DBModule.RefineDatetime(Ngay_TC_Duyet, true) + ", "
                 + Nguoi_TC_XN.ToString() + ", "
                 + DBModule.RefineDatetime(Ngay_TC_XN, true) + ", "
                 + "N'" + DBModule.RefineString(NoteModify) + "', "
                 + LoaiVatTuID.ToString() + ", "
                  + "N'" + DBModule.RefineString(BangChu) + "', "
                  + Xoa.ToString() + 
                 ");";
                strSQL += "SELECT @@IDENTITY AS 'Identity';";
                ID = long.Parse(DBModule.ExecuteQueryForOneResult(strSQL, cn, trans));
            }
            else
            {
                strSQL = "Update tbl_KeHoachUngVanChuyen Set "
                + "LoaiVatTu=N'" + DBModule.RefineString(LoaiVatTu) + "', "
                + "SoChungTu=N'" + DBModule.RefineString(SoChungTu) + "', "
                + "DonGia=" + DonGia.ToString() + ", "
                + "SoLuong=" + SoLuong.ToString() + ", "
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
                + "NguoiDuyet=" + NguoiDuyet.ToString() + ", "
                + "NgayDuyet=" + DBModule.RefineDatetime(NgayDuyet, true) + ", "
                + "Nguoi_TC_Duyet=" + Nguoi_TC_Duyet.ToString() + ", "
                + "Ngay_TC_Duyet=" + DBModule.RefineDatetime(Ngay_TC_Duyet, true) + ", "
                + "Nguoi_TC_XN=" + Nguoi_TC_XN.ToString() + ", "
                + "Ngay_TC_XN=" + DBModule.RefineDatetime(Ngay_TC_XN, true) + ", "
                + "NoteModify=N'" + DBModule.RefineString(NoteModify) + "', "
                + "LoaiVatTuID=" + LoaiVatTuID.ToString() + ", "
                  + "BangChu=N'" + DBModule.RefineString(BangChu) + "',"
                + "Xoa=" + Xoa.ToString() 
                + " Where ID=" + ID.ToString();
                DBModule.ExecuteNonQuery(strSQL, cn, trans);
            }
        }

        public static void Delete(long ID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "Delete from tbl_KeHoachUngVanChuyen where ID=" + ID.ToString();
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }

        public void LoadHopDongID(long HopDongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "Select * from tbl_KeHoachUngVanChuyen where HopDongID=" + HopDongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID")) ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("LoaiVatTu")) LoaiVatTu = dr["LoaiVatTu"].ToString();
                if (!dr.IsNull("SoChungTu")) SoChungTu = dr["SoChungTu"].ToString();
                if (!dr.IsNull("DonGia")) DonGia = decimal.Parse(dr["DonGia"].ToString());
                if (!dr.IsNull("SoLuong")) SoLuong = decimal.Parse(dr["SoLuong"].ToString());
                if (!dr.IsNull("Sotien")) Sotien = decimal.Parse(dr["Sotien"].ToString());
                if (!dr.IsNull("NgayUng")) NgayUng = DateTime.Parse(dr["NgayUng"].ToString());
                if (!dr.IsNull("HopDongID")) this.HopDongID = long.Parse(dr["HopDongID"].ToString());
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
                if (!dr.IsNull("NguoiDuyet")) NguoiDuyet = long.Parse(dr["NguoiDuyet"].ToString());
                if (!dr.IsNull("NgayDuyet")) NgayDuyet = DateTime.Parse(dr["NgayDuyet"].ToString());
                if (!dr.IsNull("Nguoi_TC_Duyet")) Nguoi_TC_Duyet = long.Parse(dr["Nguoi_TC_Duyet"].ToString());
                if (!dr.IsNull("Ngay_TC_Duyet")) Ngay_TC_Duyet = DateTime.Parse(dr["Ngay_TC_Duyet"].ToString());
                if (!dr.IsNull("Nguoi_TC_XN")) Nguoi_TC_XN = long.Parse(dr["Nguoi_TC_XN"].ToString());
                if (!dr.IsNull("Ngay_TC_XN")) Ngay_TC_XN = DateTime.Parse(dr["Ngay_TC_XN"].ToString());
                if (!dr.IsNull("NoteModify")) NoteModify = dr["NoteModify"].ToString();
                if (!dr.IsNull("LoaiVatTuID")) LoaiVatTuID = long.Parse(dr["LoaiVatTuID"].ToString());
                if (!dr.IsNull("BangChu")) BangChu = dr["BangChu"].ToString();
                if (!dr.IsNull("Xoa")) Xoa = long.Parse(dr["Xoa"].ToString());
            }
        }

        public void LoadStatus(long ID, long Status, long VuTrongID, DateTime TuNgayUng, DateTime DenNgayUng, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "Select * from tbl_KeHoachUngVanChuyen where Status=" + Status.ToString() + " AND VuTrongID=" + VuTrongID;
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
                if (!dr.IsNull("ID")) this.ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("LoaiVatTu")) LoaiVatTu = dr["LoaiVatTu"].ToString();
                if (!dr.IsNull("SoChungTu")) SoChungTu = dr["SoChungTu"].ToString();
                if (!dr.IsNull("DonGia")) DonGia = decimal.Parse(dr["DonGia"].ToString());
                if (!dr.IsNull("SoLuong")) SoLuong = decimal.Parse(dr["SoLuong"].ToString());
                if (!dr.IsNull("Sotien")) Sotien = decimal.Parse(dr["Sotien"].ToString());
                if (!dr.IsNull("NgayUng")) NgayUng = DateTime.Parse(dr["NgayUng"].ToString());
                if (!dr.IsNull("HopDongID")) HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("VuTrongID")) this.VuTrongID = long.Parse(dr["VuTrongID"].ToString());
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
                if (!dr.IsNull("Status")) this.Status = long.Parse(dr["Status"].ToString());
                if (!dr.IsNull("NguoiDuyet")) NguoiDuyet = long.Parse(dr["NguoiDuyet"].ToString());
                if (!dr.IsNull("NgayDuyet")) NgayDuyet = DateTime.Parse(dr["NgayDuyet"].ToString());
                if (!dr.IsNull("Nguoi_TC_Duyet")) Nguoi_TC_Duyet = long.Parse(dr["Nguoi_TC_Duyet"].ToString());
                if (!dr.IsNull("Ngay_TC_Duyet")) Ngay_TC_Duyet = DateTime.Parse(dr["Ngay_TC_Duyet"].ToString());
                if (!dr.IsNull("Nguoi_TC_XN")) Nguoi_TC_XN = long.Parse(dr["Nguoi_TC_XN"].ToString());
                if (!dr.IsNull("Ngay_TC_XN")) Ngay_TC_XN = DateTime.Parse(dr["Ngay_TC_XN"].ToString());
                if (!dr.IsNull("NoteModify")) NoteModify = dr["NoteModify"].ToString();
                if (!dr.IsNull("LoaiVatTuID")) LoaiVatTuID = long.Parse(dr["LoaiVatTuID"].ToString());
                if (!dr.IsNull("BangChu")) BangChu = dr["BangChu"].ToString();
                if (!dr.IsNull("Xoa")) Xoa = long.Parse(dr["Xoa"].ToString());
            }
        }
        public void Load(long ID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "Select * from tbl_KeHoachUngVanChuyen where ID=" + ID.ToString() ;           
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID")) this.ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("LoaiVatTu")) LoaiVatTu = dr["LoaiVatTu"].ToString();
                if (!dr.IsNull("SoChungTu")) SoChungTu = dr["SoChungTu"].ToString();
                if (!dr.IsNull("DonGia")) DonGia = decimal.Parse(dr["DonGia"].ToString());
                if (!dr.IsNull("SoLuong")) SoLuong = decimal.Parse(dr["SoLuong"].ToString());
                if (!dr.IsNull("Sotien")) Sotien = decimal.Parse(dr["Sotien"].ToString());
                if (!dr.IsNull("NgayUng")) NgayUng = DateTime.Parse(dr["NgayUng"].ToString());
                if (!dr.IsNull("HopDongID")) HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("VuTrongID")) this.VuTrongID = long.Parse(dr["VuTrongID"].ToString());
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
                if (!dr.IsNull("Status")) this.Status = long.Parse(dr["Status"].ToString());
                if (!dr.IsNull("NguoiDuyet")) NguoiDuyet = long.Parse(dr["NguoiDuyet"].ToString());
                if (!dr.IsNull("NgayDuyet")) NgayDuyet = DateTime.Parse(dr["NgayDuyet"].ToString());
                if (!dr.IsNull("Nguoi_TC_Duyet")) Nguoi_TC_Duyet = long.Parse(dr["Nguoi_TC_Duyet"].ToString());
                if (!dr.IsNull("Ngay_TC_Duyet")) Ngay_TC_Duyet = DateTime.Parse(dr["Ngay_TC_Duyet"].ToString());
                if (!dr.IsNull("Nguoi_TC_XN")) Nguoi_TC_XN = long.Parse(dr["Nguoi_TC_XN"].ToString());
                if (!dr.IsNull("Ngay_TC_XN")) Ngay_TC_XN = DateTime.Parse(dr["Ngay_TC_XN"].ToString());
                if (!dr.IsNull("NoteModify")) NoteModify = dr["NoteModify"].ToString();
                if (!dr.IsNull("LoaiVatTuID")) LoaiVatTuID = long.Parse(dr["LoaiVatTuID"].ToString());
                if (!dr.IsNull("BangChu")) BangChu = dr["BangChu"].ToString();
                if (!dr.IsNull("Xoa")) Xoa = long.Parse(dr["Xoa"].ToString());
            }
        }
    }
}