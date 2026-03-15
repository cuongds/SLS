
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsHoTroTien
    {
        public long ID = -1;
        public long ThuaRuongID = -1;
        public long HopDongID = -1;
        public long SoTien = 0;
        public DateTime NgayLamHoTro = DateTime.MinValue;
        public long DanhMucHoTroID = -1;
        public long VuTrongID = -1;
        public long DauTuID = -1;
        public long SoLuong = 0;
        public long DonGia = 0;
        public string GhiChu = "";
        public long HoTroTheoLoaiHinhID = -1;
        public long CreatedBy = -1;
        public long ModifyBy = -1;
        public DateTime DateAdded = DateTime.Now;
        public DateTime DataModify = DateTime.Now;
        public string NoteModify = "";
        public long Status = -1;
        public long KhauTru = -1;
        public string LyDoKhauTru = "";


        //De quan ly nguoi sua, ngay gio sua thong tin         
        public clsHoTroTien()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsHoTroTien(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                //id = lddata.DBModule.GetNewID(typeof(HoTro), "tbl_HoTroTien", cn, trans);
                ID = DBModule.GetNewID(typeof(clsHoTroTien), "tbl_HoTroTien", cn, trans);
                //NgayTao = DateTime.Now;        
                //NgaySua = DateTime.Now;        
                // build SQL statement
                strSQL = "Insert into tbl_HoTroTien" +
                "(ID,ThuaRuongID,HopDongID,SoTien,NgayLamHoTro,DanhMucHoTroID,VuTrongID,DauTuID,SoLuong,DonGia,GhiChu,HoTroTheoLoaiHinhID, CreatedBy, ModifyBy, DateAdded, DataModify, NoteModify,Status,KhauTru,LyDoKhauTru) Values(" +
                    ID.ToString() + "," + ThuaRuongID.ToString() + "," + HopDongID.ToString() + "," + SoTien.ToString() + "," + DBModule.RefineDatetime(NgayLamHoTro) + "," + DanhMucHoTroID.ToString() + "," + VuTrongID.ToString() + "," + DauTuID.ToString() + "," + SoLuong.ToString() + "," + DonGia.ToString() + "," + "N'" + DBModule.RefineString(GhiChu) + "'" + "," + HoTroTheoLoaiHinhID.ToString() +
                ", " + MDSolutionApp.User.ID.ToString() +
                    ", " + MDSolutionApp.User.ID.ToString() +
                    ", getdate()" +
                    ", getdate() " +
                    ", N'" + DBModule.RefineString(NoteModify) + "'"+
                    "," + Status.ToString() + 
                    "," + KhauTru.ToString() +
                     ", N'" + DBModule.RefineString(LyDoKhauTru) + "')"
                    ;
            }
            else // edit object, we update old record in database
            {
                // build SQL statement				    
                //NgaySua = DateTime.Now;        
                strSQL = "Update tbl_HoTroTien set " +
                    "ThuaRuongID=" + ThuaRuongID.ToString() + "," + "HopDongID=" + HopDongID.ToString() + "," + "SoTien=" + SoTien.ToString() + "," + "NgayLamHoTro=" + DBModule.RefineDatetime(NgayLamHoTro) + "," + "DanhMucHoTroID=" + DanhMucHoTroID.ToString() + "," + "VuTrongID=" + VuTrongID.ToString() + "," + "DauTuID=" + DauTuID.ToString() + "," + "SoLuong=" + SoLuong.ToString() + "," + "DonGia=" + DonGia.ToString() + "," + "GhiChu=" + "N'" + DBModule.RefineString(GhiChu) + "'" + "," + "HoTroTheoLoaiHinhID=" + HoTroTheoLoaiHinhID.ToString() +
                    ", ModifyBy = " + MDSolutionApp.User.ID.ToString() +
                    ", DataModify = getdate() " +
                    ", NoteModify = '" + DBModule.RefineString(NoteModify) + "'" +
                    " Where ID = " + ID.ToString();
            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_HoTroTien", cn, trans));
                */
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_HoTroTien where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_HoTroTien where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void DeleteLoaiHinh(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_HoTroTien where HoTroTheoLoaiHinhID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_HoTroTien where ID=" + ID.ToString();
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
                    SoLuong = long.Parse(dr["SoLuong"].ToString());
                if (!dr.IsNull("DonGia"))
                    DonGia = long.Parse(dr["DonGia"].ToString());
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
                if (!dr.IsNull("HoTroTheoLoaiHinhID"))
                    HoTroTheoLoaiHinhID = long.Parse(dr["HoTroTheoLoaiHinhID"].ToString());
            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_HoTroTien ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_HoTroTien WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        #endregion
        public static void Delete_KhoanDauTuLienQuan(long iID_DauTu, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_HoTroTien where DauTuID=" + iID_DauTu.ToString();
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