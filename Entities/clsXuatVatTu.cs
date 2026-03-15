
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsXuatVatTu
    {
        public long ID = -1;
        public long SoPhieu = -1;
        public long CanBoNongVuID = -1;
        public long XeID = -1;
        public string SoXeThueNgoai = "";
        public decimal TongTrongLuong = 0;
        public decimal TrongLuongXe = 0;
        public decimal TrongLuong = 0;
        public decimal DonGia = 0;
        public decimal ThanhTien = 0;
        public decimal DonGiaVanChuyen = 0;
        public decimal TienVanChuyen = 0;
        public long VatTuID = -1;
        public long VuTrongID = MDSolutionApp.VuTrongID;
        public decimal TrongLuongHoaDon = 0;
        public DateTime NgayLapPhieu = DateTime.Now;
        public long DaCan = 0;
        public long TachTuPhieu = -1;
        public string NguoiTach = "";
        public string AddBy = "";
        public DateTime DateAdd = DateTime.Now;
        public string ModifyBy = "";
        public DateTime DateModify = DateTime.Now;
        public long CoTinhCuoc = 1;
        public DateTime NgayVao = DateTime.Now;
        public DateTime NgayRa = DateTime.Now;
        public decimal TrongLuongThucTe = 0;
        public decimal PhanTramGiaVanChuyenMia = 100;
        public string GhiChu = "";
        public clsXuatVatTu()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsXuatVatTu(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                strSQL = "Insert into tbl_XuatVatTu(SoPhieu,CanBoNongVuID,XeID,TongTrongLuong,TrongLuongXe,TrongLuong,DonGia," +
                         "ThanhTien,TienVanChuyen,VatTuID,VuTrongID,TrongLuongHoaDon,NgayLapPhieu,DaCan,SoXeThueNgoai,AddBy,DateAdd,TachTuPhieu,NguoiTach,CoTinhCuoc,NgayVao,NgayRa,TrongLuongThucTe,PhanTramGiaVanChuyenMia,GhiChu)" +
                         " Values(" + SoPhieu.ToString() + "," + CanBoNongVuID.ToString() + "," + XeID.ToString() +
                         "," + DBModule.RefineNumber(TongTrongLuong) + "," + DBModule.RefineNumber(TrongLuongXe) +
                         "," + DBModule.RefineNumber(TrongLuong) + "," + DBModule.RefineNumber(DonGia) + "," + DBModule.RefineNumber(ThanhTien) + "," + DBModule.RefineNumber(TienVanChuyen) +
                         "," + VatTuID.ToString() + "," + VuTrongID.ToString() + "," + DBModule.RefineNumber(TrongLuongHoaDon) + "," + DBModule.RefineDatetime(NgayLapPhieu) +
                         "," + DaCan.ToString() + ",N'" + SoXeThueNgoai + "',N'" + AddBy + "',GetDate()," + TachTuPhieu.ToString() + ",N'" + NguoiTach + "'," + CoTinhCuoc.ToString() +
                         "," + DBModule.RefineDatetime(NgayVao, true) + "," + DBModule.RefineDatetime(NgayRa, true) + "," + DBModule.RefineNumber(TrongLuongThucTe) + "," + DBModule.RefineNumber(PhanTramGiaVanChuyenMia) + ",N'" + GhiChu + "')";
            }
            else // edit object, we update old record in database
            {
                strSQL = "Update tbl_XuatVatTu Set "
                + "SoPhieu= N'" + SoPhieu + "',"
                + "CanBoNongVuID=" + CanBoNongVuID.ToString() + ","
                + "XeID=" + XeID.ToString() + ","
                + "TongTrongLuong=" + DBModule.RefineNumber(TongTrongLuong) + ","
                + "TrongLuongXe=" + DBModule.RefineNumber(TrongLuongXe) + ","
                + "TrongLuong=" + DBModule.RefineNumber(TrongLuong) + ","
                + "DonGia=" + DBModule.RefineNumber(DonGia) + ","
                + "ThanhTien=" + DBModule.RefineNumber(ThanhTien) + ","
                + "VatTuID=" + VatTuID.ToString() + ","
                + "VuTrongID=" + VuTrongID.ToString() + ","
                + "TrongLuongHoaDon=" + DBModule.RefineNumber(TrongLuongHoaDon) + ","
                + "NgayLapPhieu=" + DBModule.RefineDatetime(NgayLapPhieu) + ","
                + "DaCan=" + DaCan.ToString() + ","
                + "SoXeThueNgoai=N'" + SoXeThueNgoai + "',"
                + "ModifyBy=N'" + ModifyBy + "',"
                + "DateModify=GetDate(),"
                + "CoTinhCuoc=" + CoTinhCuoc.ToString() + ","
                + "TrongLuongThucTe=" + DBModule.RefineNumber(TrongLuongThucTe) + ","
                + "PhanTramGiaVanChuyenMia=" + DBModule.RefineNumber(PhanTramGiaVanChuyenMia) + ","
                 + "GhiChu= N'" + GhiChu + "'"
                + " Where ID = " + ID.ToString();
            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);

            if (ID <= 0)
                ID = long.Parse(DBModule.ExecuteQueryForOneResult("SELECT Max(ID) FROM tbl_XuatVatTu", cn, trans));

        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_XuatVatTu where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static bool CheckSoPhieu(long SP, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Select SoPhieu From tbl_XuatVatTu Where SoPhieu=" + SP.ToString() + " And VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
            // run SQL statement
            string ret = DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
            if (string.IsNullOrEmpty(ret)) return true; else return false;
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_XuatVatTu where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void UpdateTinhCuoc(long iID, long CoTinh, decimal PhanTram, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            if (CoTinh > 0)
            {
                strSQL = "Update tbl_NhanVatTu Set TienVanChuyen=Round(" + DBModule.RefineNumber(PhanTram) + "*DonGiaVanChuyen*SoLuong/100000,0) Where XuatVatTuID=" + iID.ToString();
            }
            else
            {
                strSQL = "Update tbl_NhanVatTu Set TienVanChuyen=0 Where XuatVatTuID=" + iID.ToString();
            }
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_XuatVatTu where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("SoPhieu"))
                    SoPhieu = long.Parse(dr["SoPhieu"].ToString());
                if (!dr.IsNull("CanBoNongVuID"))
                    CanBoNongVuID = long.Parse(dr["CanBoNongVuID"].ToString());
                if (!dr.IsNull("XeID"))
                    XeID = long.Parse(dr["XeID"].ToString());
                if (!dr.IsNull("TongTrongLuong"))
                    TongTrongLuong = decimal.Parse(dr["TongTrongLuong"].ToString());
                if (!dr.IsNull("TrongLuongXe"))
                    TrongLuongXe = decimal.Parse(dr["TrongLuongXe"].ToString());
                if (!dr.IsNull("TrongLuong"))
                    TrongLuong = decimal.Parse(dr["TrongLuong"].ToString());
                if (!dr.IsNull("DonGia"))
                    DonGia = decimal.Parse(dr["DonGia"].ToString());
                if (!dr.IsNull("ThanhTien"))
                    ThanhTien = decimal.Parse(dr["ThanhTien"].ToString());
                if (!dr.IsNull("DonGiaVanChuyen"))
                    DonGiaVanChuyen = decimal.Parse(dr["DonGiaVanChuyen"].ToString());
                if (!dr.IsNull("TienVanChuyen"))
                    TienVanChuyen = decimal.Parse(dr["TienVanChuyen"].ToString());
                if (!dr.IsNull("VatTuID"))
                    VatTuID = long.Parse(dr["VatTuID"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("TrongLuongHoaDon"))
                    TrongLuongHoaDon = decimal.Parse(dr["TrongLuongHoaDon"].ToString());
                if (!dr.IsNull("NgayLapPhieu"))
                    NgayLapPhieu = DateTime.Parse(dr["NgayLapPhieu"].ToString());
                if (!dr.IsNull("DaCan"))
                    DaCan = long.Parse(dr["DaCan"].ToString());
                if (!dr.IsNull("SoXeThueNgoai"))
                    SoXeThueNgoai = dr["SoXeThueNgoai"].ToString();
                if (!dr.IsNull("ModifyBy"))
                    ModifyBy = dr["ModifyBy"].ToString();
                if (!dr.IsNull("AddBy"))
                    AddBy = dr["AddBy"].ToString();
                if (!dr.IsNull("DateAdd"))
                    DateAdd = DateTime.Parse(dr["DateAdd"].ToString());
                if (!dr.IsNull("DateModify"))
                    DateModify = DateTime.Parse(dr["DateModify"].ToString());
                if (!dr.IsNull("TachTuPhieu"))
                    TachTuPhieu = long.Parse(dr["TachTuPhieu"].ToString());
                if (!dr.IsNull("NguoiTach"))
                    NguoiTach = dr["NguoiTach"].ToString();
                if (!dr.IsNull("CoTinhCuoc"))
                    CoTinhCuoc = long.Parse(dr["CoTinhCuoc"].ToString());
                if (!dr.IsNull("NgayVao"))
                    NgayVao = DateTime.Parse(dr["NgayVao"].ToString());
                if (!dr.IsNull("NgayRa"))
                    NgayRa = DateTime.Parse(dr["NgayRa"].ToString());
                if (!dr.IsNull("TrongLuongThucTe"))
                    TrongLuongThucTe = decimal.Parse(dr["TrongLuongThucTe"].ToString());
                if (!dr.IsNull("PhanTramGiaVanChuyenMia"))
                    PhanTramGiaVanChuyenMia = decimal.Parse(dr["PhanTramGiaVanChuyenMia"].ToString());
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();
                
            }

        }


        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_XuatVatTu ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_XuatVatTu WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        public static int GetXuatVatTuID(long DauTuID, OleDbConnection cn, OleDbTransaction trans)
        {
           return 0;
         string sql = "select ID from tbl_NhanVatTu where DauTuID=" + DauTuID;
            try{
                return int.Parse(DBModule.ExecuteQueryForOneResult(sql, null, null));
                }
            catch{}
        }

        public static void GetListSoXe(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select Distinct SoXe from tbl_XuatVatTu ORDER BY SoXe ASC";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static void GetListHopDong(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select ID ,MaHopDong from tbl_Hopdong where ID in (Select Distinct HopDongID from tbl_XuatVatTu ) order by MaHopDong ASC";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }

        public static DataSet GetListThongTinVCByHopDongID(long VuTrongID, long mHDID, string OrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Select * from V_VanChuyenMia ";
            strSQL += "Where CanBoNongVuID = " + mHDID.ToString();
            strSQL += "AND VuTrongID = " + VuTrongID.ToString();
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }



        #endregion
    }
}
