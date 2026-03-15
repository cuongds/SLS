
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsNhapMia
    {
        public long ID = -1;
        public long XeID = -1;
        public long BaiTapKetID = -1;
        public long HopDongID = -1;
        public decimal TongTrongLuong = 0;
        public decimal TrongLuongXe = 0;
        public decimal TyLeTapVat = 0;
        public decimal TrongLuongTapVat = 0;
        public decimal DonGiaMia = 0;
        public DateTime NgayVanChuyen = DateTime.Now;
        public long HopDongVanChuyenID = -1;
        public long SoPhieuNhap = 0;
        public long DaThanhToan = 0;
        public long VuTrongID = -1;
        public long CaNhap = 0;
        public long KhoID = 0;
        public long DaThanhToanVC = 0;
        public string GioNhap = "";
        public string GioRa = "";
        public DateTime NgayRa = DateTime.Now;
        public long ThuaRuongID = -1;
        public long MaCanGhepID = -1;
        public decimal DonGiaVanChuyen = 0;
        public decimal TienMia = 0;
        public decimal TienVanChuyen = 0;
        public string Soxe = "";
        public decimal tylecanghep = 0;
        public long maHoTrongMia = -1;
        public decimal PhatHD = 0;
        public string LyDoPhatHD = "";
        public decimal PhatXeMia = 0;
        public string LyDoPhatXeMia = "";
        public string SoBanDieuTra = "";
        public int GiongMiaID = 0;
        public DateTime NgayMia = DateTime.Now;
        public long MaCan = 0;

        public int VuotQuaTrongLuong = 0; // kieu bool : 0,1
        public int VuotQuaThoiGian = 0; // kieu bool : 0,1
        public decimal TienMiaMuaTaiBanCan = 0; 

        public clsNhapMia()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsNhapMia(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                //id = lddata.DBModule.GetNewID(typeof(NhapMia), "tbl_NhapMia", cn, trans);
                ID = DBModule.GetNewID(typeof(clsNhapMia), "tbl_NhapMia", cn, trans);
                //NgayTao = DateTime.Now;
                //NgaySua = DateTime.Now;
                // build SQL statement
                strSQL = "Insert into tbl_NhapMia" +
                "(ID,XeID,BaiTapKetID,HopDongID,TongTrongLuong,TrongLuongXe,TyLeTapVat,TrongLuongTapVat,DonGiaMia,NgayVanChuyen,NgayMia,MaCan,HopDongVanChuyenID,SoPhieuNhap,DaThanhToan,VuTrongID,CaNhap,KhoID,DaThanhToanVC,GioNhap,GioRa,NgayRa,ThuaRuongID,MaCanGhepID,DonGiaVanChuyen,TienMia,TienVanChuyen,SoXe,TiLeCanGhep,MahoTrongMiaID,PhatHD,LyDoPhatHD,PhatXeMia,LyDoPhatXeMia,SoBanDieuTra,GiongMiaID,VuotQuaTrongLuong,VuotQuaThoiGian) Values(" +
                    ID.ToString() + "," + XeID.ToString() + "," + BaiTapKetID.ToString() + "," + HopDongID.ToString() + "," + TongTrongLuong.ToString() + "," + TrongLuongXe.ToString() + "," + TyLeTapVat.ToString() + "," + TrongLuongTapVat.ToString() + "," + DonGiaMia.ToString() + "," + DBModule.RefineDatetime(NgayVanChuyen) + "," + DBModule.RefineDatetime(NgayMia) + "," + MaCan.ToString() + "," + HopDongVanChuyenID.ToString() + "," + SoPhieuNhap.ToString() + "," + DaThanhToan.ToString() + "," + VuTrongID.ToString() + "," + CaNhap.ToString() + "," + KhoID.ToString() + "," + DaThanhToanVC.ToString() + "," + "N'" + DBModule.RefineString(GioNhap) + "'" + "," + "N'" + DBModule.RefineString(GioRa) + "'" + "," + DBModule.RefineDatetime(NgayRa) + "," + ThuaRuongID.ToString() + "," + MaCanGhepID.ToString() + "," + DonGiaVanChuyen.ToString() + "," + TienMia.ToString() + "," + TienVanChuyen.ToString() + ",'" + Soxe + "'," + tylecanghep.ToString() + "," + maHoTrongMia.ToString() + "," + PhatHD.ToString() + ",N'" + LyDoPhatHD + "'," + PhatXeMia.ToString() + ",N'" + LyDoPhatXeMia + "',N'" + SoBanDieuTra + "'" + "," + GiongMiaID.ToString() + "," + VuotQuaTrongLuong.ToString() + "," + VuotQuaThoiGian.ToString() + ")";
            }
            else // edit object, we update old record in database
            {
                // build SQL statement
                //NgaySua = DateTime.Now;
                strSQL = "Update tbl_NhapMia set " +
                    "XeID=" + XeID.ToString() + "," + "BaiTapKetID=" + BaiTapKetID.ToString() + "," + "HopDongID=" + HopDongID.ToString() + "," + "TongTrongLuong=" + TongTrongLuong.ToString() + "," + "TrongLuongXe=" + TrongLuongXe.ToString() + "," + "TyLeTapVat=" + TyLeTapVat.ToString() + "," + "TrongLuongTapVat=" + TrongLuongTapVat.ToString() + "," + "DonGiaMia=" + DonGiaMia.ToString() + "," + "NgayVanChuyen=" + DBModule.RefineDatetime(NgayVanChuyen) + "," + "NgayMia=" + DBModule.RefineDatetime(NgayMia) + "," + "HopDongVanChuyenID=" + HopDongVanChuyenID.ToString() + " ," + "SoPhieuNhap=" + SoPhieuNhap.ToString() + "," + "MaCan=" + MaCan.ToString() + "," + "DaThanhToan=" + DaThanhToan.ToString() + "," + "VuTrongID=" + VuTrongID.ToString() + "," + "CaNhap=" + CaNhap.ToString() + "," + "KhoID=" + KhoID.ToString() + "," + "DaThanhToanVC=" + DaThanhToanVC.ToString() + "," + "GioNhap=" + "N'" + DBModule.RefineString(GioNhap) + "'" + "," + "GioRa=" + "N'" + DBModule.RefineString(GioRa) + "'" + "," + "NgayRa=" + DBModule.RefineDatetime(NgayRa) + "," + "ThuaRuongID=" + ThuaRuongID.ToString() + "," + "MaCanGhepID=" + MaCanGhepID.ToString() + "," + "DonGiaVanChuyen=" + DonGiaVanChuyen.ToString() + "," + "TienMia=" + TienMia.ToString() + "," + "TienVanChuyen=" + TienVanChuyen.ToString() +
                    ",SoXe='" + Soxe + "'" + ",TiLeCanGhep=" + tylecanghep.ToString() + ",MaHoTrongMiaID=" + maHoTrongMia.ToString() + ",PhatHD=" + PhatHD.ToString() + ",LyDoPhatHD=N'" + LyDoPhatHD + "'" + ",PhatXeMia=" + PhatXeMia.ToString() + ",LyDoPhatXeMia = N'" + LyDoPhatXeMia + "'" + ",SoBanDieuTra = N'" + SoBanDieuTra + "',GiongMiaID =" + GiongMiaID.ToString() +
                    ", VuotQuaTrongLuong=" + VuotQuaTrongLuong.ToString() + ",VuotQuaThoiGian=" + VuotQuaThoiGian.ToString() +
                    " Where ID = " + ID.ToString();
            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_NhapMia", cn, trans));
                */
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_NhapMia where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_NhapMia where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_NhapMia where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("XeID"))
                    XeID = long.Parse(dr["XeID"].ToString());
                if (!dr.IsNull("BaiTapKetID"))
                    BaiTapKetID = long.Parse(dr["BaiTapKetID"].ToString());
                if (!dr.IsNull("HopDongID"))
                    HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("TongTrongLuong"))
                    TongTrongLuong = decimal.Parse(dr["TongTrongLuong"].ToString());
                if (!dr.IsNull("TrongLuongXe"))
                    TrongLuongXe = decimal.Parse(dr["TrongLuongXe"].ToString());
                if (!dr.IsNull("TyLeTapVat"))
                    TyLeTapVat = decimal.Parse(dr["TyLeTapVat"].ToString());
                if (!dr.IsNull("TrongLuongTapVat"))
                    TrongLuongTapVat = decimal.Parse(dr["TrongLuongTapVat"].ToString());
                if (!dr.IsNull("DonGiaMia"))
                    DonGiaMia = decimal.Parse(dr["DonGiaMia"].ToString());
                if (!dr.IsNull("NgayVanChuyen"))
                    NgayVanChuyen = DateTime.Parse(dr["NgayVanChuyen"].ToString());
                if (!dr.IsNull("HopDongVanChuyenID"))
                    HopDongVanChuyenID = long.Parse(dr["HopDongVanChuyenID"].ToString());
                if (!dr.IsNull("SoPhieuNhap"))
                    SoPhieuNhap = long.Parse(dr["SoPhieuNhap"].ToString());
                if (!dr.IsNull("DaThanhToan"))
                    DaThanhToan = long.Parse(dr["DaThanhToan"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                //if(!dr.IsNull("CaNhap"))
                //CaNhap = long.Parse(dr["CaNhap"].ToString());
                //if(!dr.IsNull("KhoID"))
                //KhoID = long.Parse(dr["KhoID"].ToString());
                if (!dr.IsNull("DaThanhToanVC"))
                    DaThanhToanVC = long.Parse(dr["DaThanhToanVC"].ToString());
                if (!dr.IsNull("GioNhap"))
                    GioNhap = dr["GioNhap"].ToString();
                if (!dr.IsNull("GioRa"))
                    GioRa = dr["GioRa"].ToString();
                if (!dr.IsNull("NgayRa"))
                    NgayRa = DateTime.Parse(dr["NgayRa"].ToString());
                if (!dr.IsNull("ThuaRuongID"))
                    ThuaRuongID = long.Parse(dr["ThuaRuongID"].ToString());
                //if(!dr.IsNull("MaCanGhepID"))
                //MaCanGhepID = long.Parse(dr["MaCanGhepID"].ToString());
                if (!dr.IsNull("DonGiaVanChuyen"))
                    DonGiaVanChuyen = decimal.Parse(dr["DonGiaVanChuyen"].ToString());
                if (!dr.IsNull("TienMia"))
                    TienMia = decimal.Parse(dr["TienMia"].ToString());
                if (!dr.IsNull("TienVanChuyen"))
                    TienVanChuyen = decimal.Parse(dr["TienVanChuyen"].ToString());
                if (!dr.IsNull("Soxe"))
                    Soxe = dr["Soxe"].ToString();
                //if (!dr.IsNull("TiLeCanGhep"))
                //    tylecanghep = decimal.Parse(dr["TiLeCanGhep"].ToString());
                //if (!dr.IsNull("MaHoTrongMiaID"))
                //    maHoTrongMia = int.Parse(dr["MaHoTrongMiaID"].ToString());
                //if (!dr.IsNull("PhatHD"))
                //    PhatHD = decimal.Parse(dr["PhatHD"].ToString());
                //if (!dr.IsNull("LyDoPhatHD"))
                //    LyDoPhatHD = dr["LyDoPhatHD"].ToString();
                //if (!dr.IsNull("PhatXeMia"))
                //    PhatXeMia = decimal.Parse(dr["PhatXeMia"].ToString());
                //if (!dr.IsNull("LyDoPhatXeMia"))
                //    LyDoPhatXeMia = dr["LyDoPhatXeMia"].ToString();
                //if (!dr.IsNull("SoBanDieuTra"))
                //    SoBanDieuTra = dr["SoBanDieuTra"].ToString();
                if (!dr.IsNull("GiongMiaID"))
                    GiongMiaID = int.Parse(dr["GiongMiaID"].ToString());
                //if (!dr.IsNull("NgayMia"))
                //    NgayMia = DateTime.Parse(dr["NgayMia"].ToString());
                //if (!dr.IsNull("MaCan"))
                //    MaCan = long.Parse(dr["MaCan"].ToString());

                if (!dr.IsNull("VuotQuaTrongLuong"))
                    VuotQuaTrongLuong = int.Parse(dr["VuotQuaTrongLuong"].ToString());
                if (!dr.IsNull("VuotQuaThoiGian"))
                    VuotQuaThoiGian = int.Parse(dr["VuotQuaThoiGian"].ToString());
                if (!dr.IsNull("TienMiaMuaTaiBanCan"))
                    TienMiaMuaTaiBanCan = decimal.Parse(dr["TienMiaMuaTaiBanCan"].ToString());
            }

        }
        public void Load(string strXeID, OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_NhapMia where TrongLuongXe=0 AND (MaCanGhepID=0 OR MaCanGhepID=-1) AND XeID=" + strXeID;
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("XeID"))
                    XeID = long.Parse(dr["XeID"].ToString());
                if (!dr.IsNull("BaiTapKetID"))
                    BaiTapKetID = long.Parse(dr["BaiTapKetID"].ToString());
                if (!dr.IsNull("HopDongID"))
                    HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("TongTrongLuong"))
                    TongTrongLuong = decimal.Parse(dr["TongTrongLuong"].ToString());
                if (!dr.IsNull("TrongLuongXe"))
                    TrongLuongXe = decimal.Parse(dr["TrongLuongXe"].ToString());
                if (!dr.IsNull("TyLeTapVat"))
                    TyLeTapVat = decimal.Parse(dr["TyLeTapVat"].ToString());
                if (!dr.IsNull("TrongLuongTapVat"))
                    TrongLuongTapVat = decimal.Parse(dr["TrongLuongTapVat"].ToString());
                if (!dr.IsNull("DonGiaMia"))
                    DonGiaMia = decimal.Parse(dr["DonGiaMia"].ToString());
                if (!dr.IsNull("NgayVanChuyen"))
                    NgayVanChuyen = DateTime.Parse(dr["NgayVanChuyen"].ToString());
                if (!dr.IsNull("HopDongVanChuyenID"))
                    HopDongVanChuyenID = long.Parse(dr["HopDongVanChuyenID"].ToString());
                if (!dr.IsNull("SoPhieuNhap"))
                    SoPhieuNhap = long.Parse(dr["SoPhieuNhap"].ToString());
                if (!dr.IsNull("DaThanhToan"))
                    DaThanhToan = long.Parse(dr["DaThanhToan"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("CaNhap"))
                    CaNhap = long.Parse(dr["CaNhap"].ToString());
                if (!dr.IsNull("KhoID"))
                    KhoID = long.Parse(dr["KhoID"].ToString());
                if (!dr.IsNull("DaThanhToanVC"))
                    DaThanhToanVC = long.Parse(dr["DaThanhToanVC"].ToString());
                if (!dr.IsNull("GioNhap"))
                    GioNhap = dr["GioNhap"].ToString();
                if (!dr.IsNull("GioRa"))
                    GioRa = dr["GioRa"].ToString();
                if (!dr.IsNull("NgayRa"))
                    NgayRa = DateTime.Parse(dr["NgayRa"].ToString());
                if (!dr.IsNull("ThuaRuongID"))
                    ThuaRuongID = long.Parse(dr["ThuaRuongID"].ToString());
                if (!dr.IsNull("MaCanGhepID"))
                    MaCanGhepID = long.Parse(dr["MaCanGhepID"].ToString());
                if (!dr.IsNull("DonGiaVanChuyen"))
                    DonGiaVanChuyen = decimal.Parse(dr["DonGiaVanChuyen"].ToString());
                if (!dr.IsNull("TienMia"))
                    TienMia = decimal.Parse(dr["TienMia"].ToString());
                if (!dr.IsNull("TienVanChuyen"))
                    TienVanChuyen = decimal.Parse(dr["TienVanChuyen"].ToString());
                if (!dr.IsNull("Soxe"))
                    Soxe = dr["Soxe"].ToString();
                if (!dr.IsNull("TiLeCanGhep"))
                    tylecanghep = decimal.Parse(dr["TiLeCanGhep"].ToString());
                if (!dr.IsNull("MaHoTrongMiaID"))
                    maHoTrongMia = int.Parse(dr["MaHoTrongMiaID"].ToString());
                if (!dr.IsNull("PhatHD"))
                    PhatHD = decimal.Parse(dr["PhatHD"].ToString());
                if (!dr.IsNull("LyDoPhatHD"))
                    LyDoPhatHD = dr["LyDoPhatHD"].ToString();
                if (!dr.IsNull("PhatXeMia"))
                    PhatXeMia = decimal.Parse(dr["PhatXeMia"].ToString());
                if (!dr.IsNull("LyDoPhatXeMia"))
                    LyDoPhatXeMia = dr["LyDoPhatXeMia"].ToString();
                if (!dr.IsNull("SoBanDieuTra"))
                    SoBanDieuTra = dr["SoBanDieuTra"].ToString();
                if (!dr.IsNull("GiongMiaID"))
                    GiongMiaID = int.Parse(dr["GiongMiaID"].ToString());
                if (!dr.IsNull("NgayMia"))
                    NgayMia = DateTime.Parse(dr["NgayMia"].ToString());
                if (!dr.IsNull("MaCan"))
                    MaCan = long.Parse(dr["MaCan"].ToString());

                if (!dr.IsNull("VuotQuaTrongLuong"))
                    MaCan = int.Parse(dr["VuotQuaTrongLuong"].ToString());
                if (!dr.IsNull("VuotQuaThoiGian"))
                    MaCan = int.Parse(dr["VuotQuaThoiGian"].ToString());
                if (!dr.IsNull("TienMiaMuaTaiBanCan"))
                    TienMiaMuaTaiBanCan = decimal.Parse(dr["TienMiaMuaTaiBanCan"].ToString());
            }

        }

        public void LoadBySoPhieu_SoXe(string Sophieu, string Soxe, OleDbConnection cn, OleDbTransaction trans)
        {
            string StrSQL = "";
            StrSQL = "Select * from tbl_NhapMia Where SoPhieuNhap=" + Sophieu + " and SoXe='" + Soxe + "'";
            DataSet ds = DBModule.ExecuteQuery(StrSQL, cn, trans);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("XeID"))
                    XeID = long.Parse(dr["XeID"].ToString());
                if (!dr.IsNull("BaiTapKetID"))
                    BaiTapKetID = long.Parse(dr["BaiTapKetID"].ToString());
                if (!dr.IsNull("HopDongID"))
                    HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("TongTrongLuong"))
                    TongTrongLuong = decimal.Parse(dr["TongTrongLuong"].ToString());
                if (!dr.IsNull("TrongLuongXe"))
                    TrongLuongXe = decimal.Parse(dr["TrongLuongXe"].ToString());
                if (!dr.IsNull("TyLeTapVat"))
                    TyLeTapVat = decimal.Parse(dr["TyLeTapVat"].ToString());
                if (!dr.IsNull("TrongLuongTapVat"))
                    TrongLuongTapVat = decimal.Parse(dr["TrongLuongTapVat"].ToString());
                if (!dr.IsNull("DonGiaMia"))
                    DonGiaMia = decimal.Parse(dr["DonGiaMia"].ToString());
                if (!dr.IsNull("NgayVanChuyen"))
                    NgayVanChuyen = DateTime.Parse(dr["NgayVanChuyen"].ToString());
                if (!dr.IsNull("HopDongVanChuyenID"))
                    HopDongVanChuyenID = long.Parse(dr["HopDongVanChuyenID"].ToString());
                if (!dr.IsNull("SoPhieuNhap"))
                    SoPhieuNhap = long.Parse(dr["SoPhieuNhap"].ToString());
                if (!dr.IsNull("DaThanhToan"))
                    DaThanhToan = long.Parse(dr["DaThanhToan"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("CaNhap"))
                    CaNhap = long.Parse(dr["CaNhap"].ToString());
                if (!dr.IsNull("KhoID"))
                    KhoID = long.Parse(dr["KhoID"].ToString());
                if (!dr.IsNull("DaThanhToanVC"))
                    DaThanhToanVC = long.Parse(dr["DaThanhToanVC"].ToString());
                if (!dr.IsNull("GioNhap"))
                    GioNhap = dr["GioNhap"].ToString();
                if (!dr.IsNull("GioRa"))
                    GioRa = dr["GioRa"].ToString();
                if (!dr.IsNull("NgayRa"))
                    NgayRa = DateTime.Parse(dr["NgayRa"].ToString());
                if (!dr.IsNull("ThuaRuongID"))
                    ThuaRuongID = long.Parse(dr["ThuaRuongID"].ToString());
                if (!dr.IsNull("MaCanGhepID"))
                    MaCanGhepID = long.Parse(dr["MaCanGhepID"].ToString());
                if (!dr.IsNull("DonGiaVanChuyen"))
                    DonGiaVanChuyen = decimal.Parse(dr["DonGiaVanChuyen"].ToString());
                if (!dr.IsNull("TienMia"))
                    TienMia = decimal.Parse(dr["TienMia"].ToString());
                if (!dr.IsNull("TienVanChuyen"))
                    TienVanChuyen = decimal.Parse(dr["TienVanChuyen"].ToString());
                if (!dr.IsNull("Soxe"))
                    Soxe = dr["Soxe"].ToString();
                if (!dr.IsNull("TiLeCanGhep"))
                    tylecanghep = decimal.Parse(dr["TiLeCanGhep"].ToString());
                if (!dr.IsNull("MaHoTrongMiaID"))
                    maHoTrongMia = int.Parse(dr["MaHoTrongMiaID"].ToString());
                if (!dr.IsNull("PhatHD"))
                    PhatHD = decimal.Parse(dr["PhatHD"].ToString());
                if (!dr.IsNull("LyDoPhatHD"))
                    LyDoPhatHD = dr["LyDoPhatHD"].ToString();
                if (!dr.IsNull("PhatXeMia"))
                    PhatXeMia = decimal.Parse(dr["PhatXeMia"].ToString());
                if (!dr.IsNull("LyDoPhatXeMia"))
                    LyDoPhatXeMia = dr["LyDoPhatXeMia"].ToString();
                if (!dr.IsNull("SoBanDieuTra"))
                    SoBanDieuTra = dr["SoBanDieuTra"].ToString();
                if (!dr.IsNull("GiongMiaID"))
                    GiongMiaID = int.Parse(dr["GiongMiaID"].ToString());
                if (!dr.IsNull("NgayMia"))
                    NgayMia = DateTime.Parse(dr["NgayMia"].ToString());
                if (!dr.IsNull("MaCan"))
                    MaCan = long.Parse(dr["MaCan"].ToString());

                if (!dr.IsNull("VuotQuaTrongLuong"))
                    VuotQuaTrongLuong = int.Parse(dr["VuotQuaTrongLuong"].ToString());
                if (!dr.IsNull("VuotQuaThoiGian"))
                    VuotQuaThoiGian = int.Parse(dr["VuotQuaThoiGian"].ToString());
            }
        }

        public void LoadByMaHD(string HDID, OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_NhapMia where TrongLuongXe=0 AND HopDongID=" + HDID;
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("XeID"))
                    XeID = long.Parse(dr["XeID"].ToString());
                if (!dr.IsNull("BaiTapKetID"))
                    BaiTapKetID = long.Parse(dr["BaiTapKetID"].ToString());
                if (!dr.IsNull("HopDongID"))
                    HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("TongTrongLuong"))
                    TongTrongLuong = decimal.Parse(dr["TongTrongLuong"].ToString());
                if (!dr.IsNull("TrongLuongXe"))
                    TrongLuongXe = decimal.Parse(dr["TrongLuongXe"].ToString());
                if (!dr.IsNull("TyLeTapVat"))
                    TyLeTapVat = decimal.Parse(dr["TyLeTapVat"].ToString());
                if (!dr.IsNull("TrongLuongTapVat"))
                    TrongLuongTapVat = decimal.Parse(dr["TrongLuongTapVat"].ToString());
                if (!dr.IsNull("DonGiaMia"))
                    DonGiaMia = decimal.Parse(dr["DonGiaMia"].ToString());
                if (!dr.IsNull("NgayVanChuyen"))
                    NgayVanChuyen = DateTime.Parse(dr["NgayVanChuyen"].ToString());
                if (!dr.IsNull("HopDongVanChuyenID"))
                    HopDongVanChuyenID = long.Parse(dr["HopDongVanChuyenID"].ToString());
                if (!dr.IsNull("SoPhieuNhap"))
                    SoPhieuNhap = long.Parse(dr["SoPhieuNhap"].ToString());
                if (!dr.IsNull("DaThanhToan"))
                    DaThanhToan = long.Parse(dr["DaThanhToan"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("CaNhap"))
                    CaNhap = long.Parse(dr["CaNhap"].ToString());
                if (!dr.IsNull("KhoID"))
                    KhoID = long.Parse(dr["KhoID"].ToString());
                if (!dr.IsNull("DaThanhToanVC"))
                    DaThanhToanVC = long.Parse(dr["DaThanhToanVC"].ToString());
                if (!dr.IsNull("GioNhap"))
                    GioNhap = dr["GioNhap"].ToString();
                if (!dr.IsNull("GioRa"))
                    GioRa = dr["GioRa"].ToString();
                if (!dr.IsNull("NgayRa"))
                    NgayRa = DateTime.Parse(dr["NgayRa"].ToString());
                if (!dr.IsNull("ThuaRuongID"))
                    ThuaRuongID = long.Parse(dr["ThuaRuongID"].ToString());
                if (!dr.IsNull("MaCanGhepID"))
                    MaCanGhepID = long.Parse(dr["MaCanGhepID"].ToString());
                if (!dr.IsNull("DonGiaVanChuyen"))
                    DonGiaVanChuyen = decimal.Parse(dr["DonGiaVanChuyen"].ToString());
                if (!dr.IsNull("TienMia"))
                    TienMia = decimal.Parse(dr["TienMia"].ToString());
                if (!dr.IsNull("TienVanChuyen"))
                    TienVanChuyen = decimal.Parse(dr["TienVanChuyen"].ToString());
                if (!dr.IsNull("Soxe"))
                    Soxe = dr["Soxe"].ToString();
                if (!dr.IsNull("TiLeCanGhep"))
                    tylecanghep = decimal.Parse(dr["TiLeCanGhep"].ToString());
                if (!dr.IsNull("MaHoTrongMiaID"))
                    maHoTrongMia = int.Parse(dr["MaHoTrongMiaID"].ToString());
                if (!dr.IsNull("PhatHD"))
                    PhatHD = decimal.Parse(dr["PhatHD"].ToString());
                if (!dr.IsNull("LyDoPhatHD"))
                    LyDoPhatHD = dr["LyDoPhatHD"].ToString();
                if (!dr.IsNull("PhatXeMia"))
                    PhatXeMia = decimal.Parse(dr["PhatXeMia"].ToString());
                if (!dr.IsNull("LyDoPhatXeMia"))
                    LyDoPhatXeMia = dr["LyDoPhatXeMia"].ToString();
                if (!dr.IsNull("SoBanDieuTra"))
                    SoBanDieuTra = dr["SoBanDieuTra"].ToString();
                if (!dr.IsNull("GiongMiaID"))
                    GiongMiaID = int.Parse(dr["GiongMiaID"].ToString());
                if (!dr.IsNull("NgayMia"))
                    NgayMia = DateTime.Parse(dr["NgayMia"].ToString());
                if (!dr.IsNull("MaCan"))
                    MaCan = long.Parse(dr["MaCan"].ToString());

                if (!dr.IsNull("VuotQuaTrongLuong"))
                    MaCan = int.Parse(dr["VuotQuaTrongLuong"].ToString());
                if (!dr.IsNull("VuotQuaThoiGian"))
                    MaCan = int.Parse(dr["VuotQuaThoiGian"].ToString());

            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_NhapMia ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_NhapMia WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }

        public static void GetListSoXe(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select Distinct SoXe from tbl_NhapMia ORDER BY SoXe ASC";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static void GetListHopDong(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select ID ,MaHopDong from tbl_Hopdong where ID in (Select Distinct HopDongID from tbl_NhapMia ) order by MaHopDong ASC";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }

        public static DataSet GetListThongTinVCByHopDongID(long VuTrongID, long mHDID, string OrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Select * from V_VanChuyenMia ";
            strSQL += "Where HopDongVanChuyenID = " + mHDID.ToString();
            strSQL += "AND VuTrongID = " + VuTrongID.ToString();
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }



        #endregion
    }
}
