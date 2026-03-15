
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsNhapMia_Can
    {
        public long ID = -1;
        public long XeID = -1;
        public long BaiTapKetID = -1;
        public long HopDongID = -1;
        public long TongTrongLuong = 0;
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
        public long GiongMiaID = -1;
        public string SoXe = "";
        public decimal ThoiGianChay = 0;
        public decimal PhanTramMiaChay = 0;
        public decimal PhanTramMiaRep = 0;
        public decimal DonGiaMiaRep = 0;
        public decimal DonGiaMiaChay = 0;
        public string SoPhieuChat = "";
        public long CreateBy = -1;
        public long ModifyBy = -1;
        public DateTime DateModify = DateTime.Now;
        public clsNhapMia_Can()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsNhapMia_Can(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                ID = DBModule.GetNewID(typeof(clsNhapMia), "tbl_NhapMia", cn, trans);
                string temp = DBModule.ExecuteQueryForOneResult("Select IsNull(Max(SoPhieuNhap),0)+1 from tbl_NhapMia Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString(), null, null);
                strSQL = "Insert into tbl_NhapMia" +
                "(ID,XeID,BaiTapKetID,HopDongID,TongTrongLuong,TrongLuongXe,TyLeTapVat,TrongLuongTapVat,DonGiaMia,NgayVanChuyen,HopDongVanChuyenID,DaThanhToan,VuTrongID,DaThanhToanVC,GioNhap,ThuaRuongID,DonGiaVanChuyen,TienMia,TienVanChuyen,SoPhieuNhap,GiongMiaID,SoXe,PhanTramMiaChay,PhanTramMiaRep,ThoiGianChay,DonGiaMiaRep,DonGiaMiaChay,SoPhieuChat,CreateBy) Values(" +
                    ID.ToString() + "," + XeID.ToString() + "," + BaiTapKetID.ToString() + "," + HopDongID.ToString() + "," 
                    + DBModule.RefineNumber(TongTrongLuong) + "," + DBModule.RefineNumber(TrongLuongXe) + "," + DBModule.RefineNumber(TyLeTapVat) + "," + DBModule.RefineNumber(TrongLuongTapVat) 
                    + "," + DBModule.RefineNumber(DonGiaMia) + "," + "getdate()" + "," + HopDongVanChuyenID.ToString() + "," + DaThanhToan.ToString() + "," 
                    + VuTrongID.ToString() + ","  + DaThanhToanVC.ToString() + ","  
                    + "Convert(Varchar(5),GetDate(),114)"  + "," + ThuaRuongID.ToString() + "," 
                    + DBModule.RefineNumber(DonGiaVanChuyen) + "," + DBModule.RefineNumber(TienMia) + "," + DBModule.RefineNumber(TienVanChuyen) + "," + temp + ","+GiongMiaID.ToString()+",N'"+SoXe+"'," + DBModule.RefineNumber(PhanTramMiaChay)+","
                    +DBModule.RefineNumber(PhanTramMiaRep)+","+DBModule.RefineNumber(ThoiGianChay)+","+DBModule.RefineNumber(DonGiaMiaRep)+","+DBModule.RefineNumber(DonGiaMiaChay)+",N'"+SoPhieuChat+"'," + MDSolutionApp.User.ID.ToString()+")";
            }
            else // edit object, we update old record in database
            {
                 strSQL = "Update tbl_NhapMia set " +
                    "XeID=" + XeID.ToString() + "," + "BaiTapKetID=" + BaiTapKetID.ToString() + "," + "HopDongID=" + HopDongID.ToString() + "," 
                    + "TongTrongLuong=" + DBModule.RefineNumber(TongTrongLuong) + "," + "TrongLuongXe=" + DBModule.RefineNumber(TrongLuongXe) 
                    + "," + "TyLeTapVat=" + DBModule.RefineNumber(TyLeTapVat) + "," + "TrongLuongTapVat=" + DBModule.RefineNumber(TrongLuongTapVat) + "," + 
                    "DonGiaMia=" + DBModule.RefineNumber(DonGiaMia) + "," + "NgayVanChuyen=" + DBModule.RefineDatetime(NgayVanChuyen) + "," + 
                    "HopDongVanChuyenID=" + HopDongVanChuyenID.ToString() + " ," + "DaThanhToan=" + DaThanhToan.ToString() + "," +
                    "VuTrongID=" + VuTrongID.ToString() + "," +
                    "DaThanhToanVC=" + DaThanhToanVC.ToString() + ","  + "GioRa=" + "Convert(Varchar(5),GetDate(),114)" + "," +
                    "NgayRa=" + "getdate()" + "," + "ThuaRuongID=" + ThuaRuongID.ToString() + "," 
                    + "DonGiaVanChuyen=" + DBModule.RefineNumber(DonGiaVanChuyen) + "," + "TienMia=" + DBModule.RefineNumber(TienMia) + "," + 
                    "TienVanChuyen=" + DBModule.RefineNumber(TienVanChuyen) + ",GiongMiaID="+GiongMiaID.ToString()+",SoXe=N'"+SoXe+"',PhanTramMiaChay="+DBModule.RefineNumber(PhanTramMiaChay)+
                    ",PhanTramMiaRep=" + DBModule.RefineNumber(PhanTramMiaRep) + ",ThoiGianChay=" + DBModule.RefineNumber(ThoiGianChay) 
                    + ",DonGiaMiaRep="+DBModule.RefineNumber(DonGiaMiaRep)+",DonGiaMiaChay="+DBModule.RefineNumber(DonGiaMiaChay)+",SoPhieuChat=N'"+SoPhieuChat+"'"+
                    " Where ID = " + ID.ToString();
            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        
        }
        public void Modify(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "Update tbl_NhapMia Set XeID=" + XeID.ToString() + "," + "BaiTapKetID=" + BaiTapKetID.ToString() + "," + "HopDongID=" + HopDongID.ToString() + ","
                      + "TongTrongLuong=" + DBModule.RefineNumber(TongTrongLuong) + "," + "TrongLuongXe=" + DBModule.RefineNumber(TrongLuongXe)
                      + "," + "TyLeTapVat=" + DBModule.RefineNumber(TyLeTapVat) + "," + "TrongLuongTapVat=" + DBModule.RefineNumber(TrongLuongTapVat) + "," +
                      "DonGiaMia=" + DBModule.RefineNumber(DonGiaMia) + "," + "NgayVanChuyen=" + DBModule.RefineDatetime(NgayVanChuyen) + "," +
                      "HopDongVanChuyenID=" + HopDongVanChuyenID.ToString() + " ," + "DaThanhToan=" + DaThanhToan.ToString() + "," +
                      "VuTrongID=" + VuTrongID.ToString() + ",DaThanhToanVC=" + DaThanhToanVC.ToString() + ",ThuaRuongID=" + ThuaRuongID.ToString() + ","
                      + "DonGiaVanChuyen=" + DBModule.RefineNumber(DonGiaVanChuyen) + "," + "TienMia=" + DBModule.RefineNumber(TienMia) + "," +
                      "TienVanChuyen=" + DBModule.RefineNumber(TienVanChuyen) + ",GiongMiaID=" + GiongMiaID.ToString() + ",SoXe=N'" + SoXe + "',PhanTramMiaChay=" + DBModule.RefineNumber(PhanTramMiaChay) +
                      ",PhanTramMiaRep=" + DBModule.RefineNumber(PhanTramMiaRep) + ",DonGiaMiaRep=" + DBModule.RefineNumber(DonGiaMiaRep) + ",DonGiaMiaChay=" + DBModule.RefineNumber(DonGiaMiaChay) + ",SoPhieuChat=N'" + SoPhieuChat + "'" + ",ModifyBy=" + MDSolutionApp.User.ID.ToString() + ",DateModify=GetDate() Where ID = " + ID.ToString();
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        private string SinhSoPhieu()
        {
            string SP = "";
            string TenVuTrong = MDSolutionApp.VuTrongTen.Replace("-", "").Replace(" ", "").Replace("20","");
            string STT = DBModule.ExecuteQueryForOneResult("Select IsNull(Count(SoPhieuNhap),0) From tbl_NhapMia Where VuTrongID="+MDSolutionApp.VuTrongID.ToString(),null,null);
            if (STT.Length == 1) { STT = "0000" + STT; }
            else if (STT.Length == 2) { STT = "000" + STT; }
            else if (STT.Length == 3) { STT = "00" + STT; }
            else { STT = "0" + STT; }
            SP = "N" + STT + "_" + "V"+ TenVuTrong;
            return SP;
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
                    TongTrongLuong = long.Parse(dr["TongTrongLuong"].ToString());
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
                //if (!dr.IsNull("CaNhap"))
                //    CaNhap = long.Parse(dr["CaNhap"].ToString());
                //if (!dr.IsNull("KhoID"))
                //    KhoID = long.Parse(dr["KhoID"].ToString());
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
                //if (!dr.IsNull("MaCanGhepID"))
                //    MaCanGhepID = long.Parse(dr["MaCanGhepID"].ToString());
                if (!dr.IsNull("DonGiaVanChuyen"))
                    DonGiaVanChuyen = decimal.Parse(dr["DonGiaVanChuyen"].ToString());
                if (!dr.IsNull("TienMia"))
                    TienMia = decimal.Parse(dr["TienMia"].ToString());
                if (!dr.IsNull("TienVanChuyen"))
                    TienVanChuyen = decimal.Parse(dr["TienVanChuyen"].ToString());
                if (!dr.IsNull("GiongMiaID"))
                    GiongMiaID = long.Parse(dr["GiongMiaID"].ToString());
                if (!dr.IsNull("SoXe"))
                    SoXe = dr["SoXe"].ToString();
                if (!dr.IsNull("ThoiGianChay"))
                    ThoiGianChay = decimal.Parse(dr["ThoiGianChay"].ToString());
                if (!dr.IsNull("PhanTramMiaChay"))
                    PhanTramMiaChay = decimal.Parse(dr["PhanTramMiaChay"].ToString());
                if (!dr.IsNull("PhanTramMiaRep"))
                    PhanTramMiaRep = decimal.Parse(dr["PhanTramMiaRep"].ToString());
                if (!dr.IsNull("DonGiaMiaRep"))
                    DonGiaMiaRep = decimal.Parse(dr["DonGiaMiaRep"].ToString());
                if (!dr.IsNull("DonGiaMiaChay"))
                    DonGiaMiaChay = decimal.Parse(dr["DonGiaMiaChay"].ToString());
                if (!dr.IsNull("SoPhieuChat"))
                    SoPhieuChat = dr["SoPhieuChat"].ToString();
            }

        }
        public void Load(long SoPN, OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_NhapMia where TrongLuongXe=0 AND SoPhieuNhap=" + SoPN.ToString()+" And VuTrongID="+MDSolutionApp.VuTrongID.ToString();
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
                    TongTrongLuong = long.Parse(dr["TongTrongLuong"].ToString());
                if (!dr.IsNull("TrongLuongXe"))
                    TrongLuongXe = long.Parse(dr["TrongLuongXe"].ToString());
                if (!dr.IsNull("TyLeTapVat"))
                    TyLeTapVat = decimal.Parse(dr["TyLeTapVat"].ToString());
                if (!dr.IsNull("TrongLuongTapVat"))
                    TrongLuongTapVat = long.Parse(dr["TrongLuongTapVat"].ToString());
                if (!dr.IsNull("DonGiaMia"))
                    DonGiaMia = long.Parse(dr["DonGiaMia"].ToString());
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
                if (!dr.IsNull("DaThanhToanVC"))
                    DaThanhToanVC = long.Parse(dr["DaThanhToanVC"].ToString());
                if (!dr.IsNull("NgayRa"))
                    NgayRa = DateTime.Parse(dr["NgayRa"].ToString());
                if (!dr.IsNull("ThuaRuongID"))
                    ThuaRuongID = long.Parse(dr["ThuaRuongID"].ToString());
                if (!dr.IsNull("DonGiaVanChuyen"))
                    DonGiaVanChuyen = decimal.Parse(dr["DonGiaVanChuyen"].ToString());
                if (!dr.IsNull("TienMia"))
                    TienMia = decimal.Parse(dr["TienMia"].ToString());
                if (!dr.IsNull("TienVanChuyen"))
                    TienVanChuyen = decimal.Parse(dr["TienVanChuyen"].ToString());
                if (!dr.IsNull("GiongMiaID"))
                    GiongMiaID = long.Parse(dr["GiongMiaID"].ToString());
                if (!dr.IsNull("SoXe"))
                    SoXe = dr["SoXe"].ToString();
                if (!dr.IsNull("ThoiGianChay"))
                    ThoiGianChay = decimal.Parse(dr["ThoiGianChay"].ToString());
                if (!dr.IsNull("PhanTramMiaChay"))
                    PhanTramMiaChay = decimal.Parse(dr["PhanTramMiaChay"].ToString());
                if (!dr.IsNull("PhanTramMiaRep"))
                    PhanTramMiaRep = decimal.Parse(dr["PhanTramMiaRep"].ToString());
                if (!dr.IsNull("DonGiaMiaRep"))
                    DonGiaMiaRep = decimal.Parse(dr["DonGiaMiaRep"].ToString());
                if (!dr.IsNull("DonGiaMiaChay"))
                    DonGiaMiaChay = decimal.Parse(dr["DonGiaMiaChay"].ToString());
                if (!dr.IsNull("SoPhieuChat"))
                    SoPhieuChat = dr["SoPhieuChat"].ToString();
                }
            }
        public void Load(string strXeID, OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_NhapMia where TrongLuongXe=0 AND XeID=" + strXeID;
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
                    TongTrongLuong = long.Parse(dr["TongTrongLuong"].ToString());
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
                //if (!dr.IsNull("CaNhap"))
                //    CaNhap = long.Parse(dr["CaNhap"].ToString());
                //if (!dr.IsNull("KhoID"))
                //    KhoID = long.Parse(dr["KhoID"].ToString());
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
                //if (!dr.IsNull("MaCanGhepID"))
                //    MaCanGhepID = long.Parse(dr["MaCanGhepID"].ToString());
                if (!dr.IsNull("DonGiaVanChuyen"))
                    DonGiaVanChuyen = decimal.Parse(dr["DonGiaVanChuyen"].ToString());
                if (!dr.IsNull("TienMia"))
                    TienMia = decimal.Parse(dr["TienMia"].ToString());
                if (!dr.IsNull("TienVanChuyen"))
                    TienVanChuyen = decimal.Parse(dr["TienVanChuyen"].ToString());
                if (!dr.IsNull("GiongMiaID"))
                    GiongMiaID = long.Parse(dr["GiongMiaID"].ToString());
                if (!dr.IsNull("SoXe"))
                    SoXe = dr["SoXe"].ToString();
                if (!dr.IsNull("ThoiGianChay"))
                    ThoiGianChay = decimal.Parse(dr["ThoiGianChay"].ToString());
                if (!dr.IsNull("PhanTramMiaChay"))
                    PhanTramMiaChay = decimal.Parse(dr["PhanTramMiaChay"].ToString());
                if (!dr.IsNull("PhanTramMiaRep"))
                    PhanTramMiaRep = decimal.Parse(dr["PhanTramMiaRep"].ToString());
                if (!dr.IsNull("DonGiaMiaRep"))
                    DonGiaMiaRep = decimal.Parse(dr["DonGiaMiaRep"].ToString());
                if (!dr.IsNull("DonGiaMiaChay"))
                    DonGiaMiaChay = decimal.Parse(dr["DonGiaMiaChay"].ToString());
                if (!dr.IsNull("SoPhieuChat"))
                    SoPhieuChat = dr["SoPhieuChat"].ToString();
            }

        }

        public void LoadByMaHD(string HopDongID, OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_NhapMia where TrongLuongXe=0 AND HopDongID=" + HopDongID;
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
                //if (!dr.IsNull("HopDongID"))
                //    HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("TongTrongLuong"))
                    TongTrongLuong = long.Parse(dr["TongTrongLuong"].ToString());
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
                //if (!dr.IsNull("CaNhap"))
                //    CaNhap = long.Parse(dr["CaNhap"].ToString());
                //if (!dr.IsNull("KhoID"))
                //    KhoID = long.Parse(dr["KhoID"].ToString());
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
                //if (!dr.IsNull("MaCanGhepID"))
                //    MaCanGhepID = long.Parse(dr["MaCanGhepID"].ToString());
                if (!dr.IsNull("DonGiaVanChuyen"))
                    DonGiaVanChuyen = decimal.Parse(dr["DonGiaVanChuyen"].ToString());
                if (!dr.IsNull("TienMia"))
                    TienMia = decimal.Parse(dr["TienMia"].ToString());
                if (!dr.IsNull("TienVanChuyen"))
                    TienVanChuyen = decimal.Parse(dr["TienVanChuyen"].ToString());
                if (!dr.IsNull("GiongMiaID"))
                    GiongMiaID = long.Parse(dr["GiongMiaID"].ToString());
                if (!dr.IsNull("SoXe"))
                    SoXe = dr["SoXe"].ToString();
                if (!dr.IsNull("ThoiGianChay"))
                    ThoiGianChay = decimal.Parse(dr["ThoiGianChay"].ToString());
                if (!dr.IsNull("PhanTramMiaChay"))
                    PhanTramMiaChay = decimal.Parse(dr["PhanTramMiaChay"].ToString());
                if (!dr.IsNull("PhanTramMiaRep"))
                    PhanTramMiaRep = decimal.Parse(dr["PhanTramMiaRep"].ToString());
                if (!dr.IsNull("DonGiaMiaRep"))
                    DonGiaMiaRep = decimal.Parse(dr["DonGiaMiaRep"].ToString());
                if (!dr.IsNull("DonGiaMiaChay"))
                    DonGiaMiaChay = decimal.Parse(dr["DonGiaMiaChay"].ToString());
                if (!dr.IsNull("SoPhieuChat"))
                    SoPhieuChat = dr["SoPhieuChat"].ToString();
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

        public static DataSet GetListbyWhereVatTu(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = " SELECT     dbo.tbl_NhapMia.SoPhieuNhap AS SoPhieuNhap, dbo.tbl_XeVanChuyen.SoXe, dbo.tbl_HopDong.HoTen, dbo.tbl_HopDongVanChuyen.TenChuHopDong,dbo.tbl_NhapMia.TrongLuongXe AS TrongLuongBiXe, dbo.tbl_NhapMia.TongTrongLuong,dbo.tbl_NhapMia.TongTrongLuong-dbo.tbl_NhapMia.TrongLuongXe AS TrongLuongVatTu, dbo.tbl_NhapMia.NgayVanChuyen AS NgayVao, dbo.tbl_NhapMia.GioNhap, dbo.tbl_NhapMia.GioRa, dbo.tbl_NhapMia.NgayRa, 'Cân Mía' AS LoaiVatTu FROM  dbo.tbl_NhapMia INNER JOIN dbo.tbl_HopDong ON dbo.tbl_NhapMia.HopDongID = dbo.tbl_HopDong.ID INNER JOIN dbo.tbl_XeVanChuyen ON dbo.tbl_NhapMia.XeID = dbo.tbl_XeVanChuyen.ID INNER JOIN dbo.tbl_HopDongVanChuyen ON dbo.tbl_NhapMia.HopDongVanChuyenID = dbo.tbl_HopDongVanChuyen.ID WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
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
