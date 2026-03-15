
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsHoTro
    {
        public long ID = -1;
        public long ThuaRuongID = -1;
        public long HopDongID = -1;
        public decimal SoTien = 0;
        public DateTime NgayLamHoTro = DateTime.MinValue;
        public long DanhMucHoTroID = -1;
        public long VuTrongID = -1;
        public long DauTuID = -1;
        public decimal SoLuong = 0;
        public decimal DonGia = 0;
        public string GhiChu = "";
        public long HoTroTheoLoaiHinhID = -1;
        public long KhauTru = 0;
        public string LyDoKhauTru = "";
        public long HoTroID = -1;
        public string SoChungTu = "";
        public decimal DienTich = 0;
        public long DaLamKhauTru = -1;
        public decimal SoTienLaiTru = -1;
        public decimal SoTienGocTru = -1;
        //De quan ly nguoi sua, ngay gio sua thong tin 

        public string NoteModify = "";
        public clsHoTro()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsHoTro(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                //id = lddata.DBModule.GetNewID(typeof(HoTro), "tbl_HoTro", cn, trans);
                ID = DBModule.GetNewID(typeof(clsHoTro), "tbl_HoTro", cn, trans);
                //NgayTao = DateTime.Now;        
                //NgaySua = DateTime.Now;        
                // build SQL statement
                strSQL = "Insert into tbl_HoTro" +
                "(ID,ThuaRuongID,HopDongID,SoTien,NgayLamHoTro,DanhMucHoTroID,VuTrongID,DauTuID,SoLuong,DonGia,GhiChu,HoTroTheoLoaiHinhID,KhauTru, LyDoKhauTru, HoTroID, CreatedBy, ModifyBy, DateAdd, DataModify, NoteModify,SoChungTu,DienTich,DaLamKhauTru,SoTienLaiTru,SoTienGocTru) Values(" +
                    ID.ToString() + "," + ThuaRuongID.ToString() + "," + HopDongID.ToString() + "," + SoTien.ToString() + "," + DBModule.RefineDatetime(NgayLamHoTro) + "," + DanhMucHoTroID.ToString() + "," + VuTrongID.ToString() + "," + DauTuID.ToString() + "," + SoLuong.ToString() + "," + DonGia.ToString() + "," + "N'" + DBModule.RefineString(GhiChu) + "'" + "," + HoTroTheoLoaiHinhID.ToString() + "," + KhauTru.ToString() +
                    "," + "N'" + DBModule.RefineString(GhiChu) + "'" +
                    "," + HoTroID.ToString() +
                ", " + MDSolutionApp.User.ID.ToString() +
                    ", " + MDSolutionApp.User.ID.ToString() +
                    ", getdate()" +
                    ", getdate() " +
                    ", N'" + DBModule.RefineString(NoteModify) + "'" +
                     "," + "N'" + DBModule.RefineString(SoChungTu) + "'" +
                     "," + DienTich.ToString() +
                     "," + DaLamKhauTru.ToString() +
                     "," + SoTienLaiTru.ToString() +
                     "," + SoTienGocTru.ToString() +
                    ")";
            }
            else // edit object, we update old record in database
            {
                // build SQL statement				    
                //NgaySua = DateTime.Now;        
                strSQL = "Update tbl_HoTro set " +
                    "ThuaRuongID=" + ThuaRuongID.ToString() + "," + "HopDongID=" + HopDongID.ToString() + "," + "SoTien=" + SoTien.ToString() + "," + "NgayLamHoTro=" + DBModule.RefineDatetime(NgayLamHoTro) + "," + "DanhMucHoTroID=" + DanhMucHoTroID.ToString() + "," + "VuTrongID=" + VuTrongID.ToString() + "," + "DauTuID=" + DauTuID.ToString() + "," + "SoLuong=" + SoLuong.ToString() + "," + "DonGia=" + DonGia.ToString() + "," + "GhiChu=" + "N'" + DBModule.RefineString(GhiChu) + "'" + "," + "HoTroTheoLoaiHinhID=" + HoTroTheoLoaiHinhID.ToString() + "," + "KhauTru=" + KhauTru.ToString() +
                    "," + "LyDoKhauTru=" + "N'" + DBModule.RefineString(LyDoKhauTru) + "'" +
                    ", DienTich = " + DienTich.ToString() +
                    ", HoTroID = " + HoTroID.ToString() +
                    ", ModifyBy = " + MDSolutionApp.User.ID.ToString() +
                    ", DataModify = getdate() " +
                    ", NoteModify = '" + DBModule.RefineString(NoteModify) + "'" +
                    ", SoChungTu = '" + DBModule.RefineString(SoChungTu) + "'" +
                    ", DaLamKhauTru = " + DaLamKhauTru.ToString() +
                    ", SoTienLaiTru = " + SoTienLaiTru.ToString() +
                    ", SoTienGocTru = " + SoTienGocTru.ToString() +
                    " Where ID = " + ID.ToString();
            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_HoTro", cn, trans));
                */
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_HoTro where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_HoTro where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void DeleteLoaiHinh(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_HoTro where HoTroTheoLoaiHinhID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_HoTro where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("ThuaRuongID"))
                    ThuaRuongID = long.Parse(dr["ThuaRuongID"].ToString());
                if (!dr.IsNull("HopDongID"))
                    HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("SoTien"))
                    SoTien = long.Parse(dr["SoTien"].ToString());
                if (!dr.IsNull("NgayLamHoTro"))
                    NgayLamHoTro = DateTime.Parse(dr["NgayLamHoTro"].ToString());
                if (!dr.IsNull("DanhMucHoTroID"))
                    DanhMucHoTroID = long.Parse(dr["DanhMucHoTroID"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("DauTuID"))
                    DauTuID = long.Parse(dr["DauTuID"].ToString());
                if (!dr.IsNull("SoLuong"))
                    SoLuong = decimal.Parse(dr["SoLuong"].ToString());
                if (!dr.IsNull("DonGia"))
                    DonGia = decimal.Parse(dr["DonGia"].ToString());
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("HoTroTheoLoaiHinhID"))
                    HoTroTheoLoaiHinhID = long.Parse(dr["HoTroTheoLoaiHinhID"].ToString());
                if (!dr.IsNull("KhauTru"))
                    KhauTru = long.Parse(dr["KhauTru"].ToString());
                if (!dr.IsNull("LyDoKhauTru"))
                    LyDoKhauTru = dr["LyDoKhauTru"].ToString();
                if (!dr.IsNull("HoTroID"))
                    HoTroID = long.Parse(dr["HoTroID"].ToString());
                if (!dr.IsNull("SoChungTu"))
                    SoChungTu = dr["SoChungTu"].ToString();
                if (!dr.IsNull("DienTich"))
                    DienTich = decimal.Parse(dr["DienTich"].ToString());
                if (!dr.IsNull("DaLamKhauTru"))
                    DaLamKhauTru = long.Parse(dr["DaLamKhauTru"].ToString());
                if (!dr.IsNull("SoTienLaiTru"))
                    SoTienLaiTru = decimal.Parse(dr["SoTienLaiTru"].ToString());
                if (!dr.IsNull("SoTienGocTru"))
                    SoTienGocTru = decimal.Parse(dr["SoTienGocTru"].ToString());
            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_HoTro ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_HoTro WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        #endregion
        public static void Delete_KhoanDauTuLienQuan(long iID_DauTu, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_HoTro where DauTuID=" + iID_DauTu.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void HoTro_TheoLoaiHinh(long HopDongID, long VuTrongID, long HoTroTheoLoaiHinhID, long DanhMucHoTroID, DateTime NgayHoTro, float DonGia, long TinhTheo, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "sp_Lam_HoTro_TheoLoaiHinh " + HopDongID.ToString() + ", " + VuTrongID.ToString() + "," + HoTroTheoLoaiHinhID.ToString() + "," + DanhMucHoTroID.ToString() + "," + DBModule.RefineDatetime(NgayHoTro) + "," + DonGia.ToString() + "," + TinhTheo.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }


    }
}