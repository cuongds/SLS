
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsThuaRuong
    {
        public long ID = -1;
        public string SoBanDieuTra = "";
        public string MaThuaRuong = "";
        public long HopDongID = -1;
        public long ThonID = -1;
        public long HienTrangGiaoThong = 0;
        public decimal DienTich = 0;
        public long LoaiDatID = -1;
        public long TramNongVuID = -1;
        public string SoHieuKeUoc = "";
        public string XuDong = "";
        public long DuongVanChuyenID = -1;
        public long RaiVuID = -1;
        public long VuTrongID = -1;
        public long GiongMiaID = -1;
        public DateTime NgayTrong = DateTime.MinValue;
        public DateTime NgayThuHoachDuKien = DateTime.MinValue;
        public decimal NangSuatDuKien = 0;
        public decimal SanLuongDuKien = 0;
        public decimal NangSuatDuKien1 = 0;
        public decimal SanLuongDuKien1 = 0;
        public long MucDichID = -1;
        public long KieuTrongID = -1;
        public long PheCanhID = -1;
        public long TrangThai = 1;
        public long TinhTrang = 0;
        public long CanBoNongVuID = -1;

        //phan them moi dien tich dang ky
       public string XuDongDangKy ="";
       public long LoaiDatDangKyID =0;
       public long GiongMiaDangKyID =0;
       public long KieuTrongDangKyID =0;
       public DateTime ThoiGianDangKy = DateTime.MinValue;
       public float DienTichDangKy =0;
       public float NangSuatDangKy =0;
       public float SanLuongDangKy =0;
        //
        //phan them moi dien tich du kien chat giong,phe canh, chat giong
        public decimal DienTichDuKienChatGiong = 0;
        public decimal DienTichPheCanh = 0;
        public decimal DienTichChatGiong = 0;

        public decimal NangSuatChatgiong = 0;
        public decimal SanLuongChatGiong = 0;
        public long BaiTapKetID = -1;
        public string NguyenNhanPheCanh = "";

        //De quan ly nguoi sua, ngay gio sua thong tin 
        public string NoteModify = "";
        public long TrangThaiDangKy = 1;
        public clsThuaRuong()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsThuaRuong(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                //id = lddata.DBModule.GetNewID(typeof(ThuaRuong), "tbl_ThuaRuong", cn, trans);
                //ID = DBModule.GetNewID(typeof(clsThuaRuong), "tbl_ThuaRuong", cn, trans);
                //NgayTao = DateTime.Now;        
                //NgaySua = DateTime.Now;        
                // build SQL statement
                strSQL = "Insert into tbl_ThuaRuong" +
                "(SoBanDieuTra,MaThuaRuong,CanBoNongVuID,BaiTapKetID,HopDongID,ThonID,HienTrangGiaoThong,DienTich,LoaiDatID,TramNongVuID,SoHieuKeUoc,XuDong,DuongVanChuyenID,RaiVuID,VuTrongID,GiongMiaID,NgayTrong,NgayThuHoachDuKien,NangSuatDuKien,SanLuongDuKien,NangSuatDuKien1,SanLuongDuKien1,MucDichID,PheCanhID,TrangThai,TinhTrang ,XuDongDangKy ,LoaiDatDangKyID ,GiongMiaDangKyID ,KieuTrongID,ThoiGianDangKy ,DienTichDangKy ,NangSuatDangKy ,SanLuongDangKy ,DienTichDuKienChatGiong,DienTichPheCanh,DienTichChatGiong,NangSuatChatGiong,SanLuongChatGiong,NguyenNhanPheCanh ,CreatedBy, ModifyBy, DateAdd, DataModify, NoteModify,TrangThaiDangKy  ) Values(" +
                    "N'" + DBModule.RefineString(SoBanDieuTra) + "'" + "," + "N'" + DBModule.RefineString(MaThuaRuong) + "'" + ","+CanBoNongVuID.ToString()+","+BaiTapKetID.ToString()+"," + HopDongID.ToString() + "," + ThonID.ToString() + "," + HienTrangGiaoThong.ToString() + "," +DBModule.RefineNumber(DienTich) + "," + LoaiDatID.ToString() + "," + TramNongVuID.ToString() + "," + "N'" + DBModule.RefineString(SoHieuKeUoc) + "'" + "," + "N'" + DBModule.RefineString(XuDong) + "'" + "," + DuongVanChuyenID.ToString() + "," + RaiVuID.ToString() + "," + VuTrongID.ToString() + "," + GiongMiaID.ToString() + "," + DBModule.RefineDatetime(NgayTrong,true) + "," + DBModule.RefineDatetime(NgayThuHoachDuKien,true) + "," +DBModule.RefineNumber(NangSuatDuKien) + "," + DBModule.RefineNumber(SanLuongDuKien) + "," + DBModule.RefineNumber(NangSuatDuKien1) + "," + SanLuongDuKien1.ToString() + "," + MucDichID.ToString() + "," + PheCanhID.ToString() + "," + TrangThai.ToString() + "," + TinhTrang.ToString() + "," + "N'" + DBModule.RefineString(XuDongDangKy) + "'," + LoaiDatDangKyID.ToString() + "," + GiongMiaDangKyID.ToString() + "," + KieuTrongID.ToString() + "," + DBModule.RefineDatetime(ThoiGianDangKy,true) + "," + DienTichDangKy.ToString() + "," + NangSuatDangKy.ToString() + "," + SanLuongDangKy.ToString() + "," + DienTichDuKienChatGiong.ToString() + "," + DienTichPheCanh.ToString() + "," + DienTichChatGiong.ToString() + "," + NangSuatChatgiong.ToString() + "," + SanLuongChatGiong.ToString() + ",N'" + NguyenNhanPheCanh + "'," + TrangThaiDangKy.ToString() +
                    ", " + MDSolutionApp.User.ID.ToString() +
                    ", " + MDSolutionApp.User.ID.ToString() +
                    ", getdate()" +
                    ", getdate() " +
                    ", N'" + DBModule.RefineString(NoteModify) + "')";
            }
            else // edit object, we update old record in database
            {
                // build SQL statement				    
                //NgaySua = DateTime.Now;        
                strSQL = "Update tbl_ThuaRuong set BaiTapKetID=" +BaiTapKetID.ToString()+","+
                    "SoBanDieuTra=" + "N'" + DBModule.RefineString(SoBanDieuTra) + "'" + "," + "MaThuaRuong=" + "N'" + DBModule.RefineString(MaThuaRuong) + "'" + "," + "HopDongID=" + HopDongID.ToString() + "," + "ThonID=" + ThonID.ToString() + "," + "CanBoNongVuID=" + CanBoNongVuID.ToString() + "," + "DienTich=" +DBModule.RefineNumber(DienTich) + "," + "LoaiDatID=" + LoaiDatID.ToString() + "," + "TramNongVuID=" + TramNongVuID.ToString() + "," + "SoHieuKeUoc=" + "N'" + DBModule.RefineString(SoHieuKeUoc) + "'" + "," + "XuDong=" + "N'" + DBModule.RefineString(XuDong) + "'" + "," + "DuongVanChuyenID=" + DuongVanChuyenID.ToString() + "," + "RaiVuID=" + RaiVuID.ToString() + "," + "VuTrongID=" + VuTrongID.ToString() + "," + "GiongMiaID=" + GiongMiaID.ToString() + "," + "NgayTrong=" + DBModule.RefineDatetime(NgayTrong, true) + "," + "NgayThuHoachDuKien=" + DBModule.RefineDatetime(NgayThuHoachDuKien, true) + "," + "NangSuatDuKien=" + DBModule.RefineNumber(NangSuatDuKien) + "," + "SanLuongDuKien=" + DBModule.RefineNumber(SanLuongDuKien) + "," + "NangSuatDuKien1=" + DBModule.RefineNumber(NangSuatDuKien1) + "," + "SanLuongDuKien1=" + DBModule.RefineNumber(SanLuongDuKien1) + "," + "MucDichID=" + MucDichID.ToString() + "," + "PheCanhID=" + PheCanhID.ToString() + "," + "TrangThai=" + TrangThai.ToString() + "," + "TinhTrang=" + TinhTrang.ToString() + "," + "XuDongDangKy=" + "N'" + DBModule.RefineString(XuDongDangKy) + "'," + "LoaiDatDangKyID=" + LoaiDatDangKyID.ToString() + "," + "GiongMiaDangKyID=" + GiongMiaDangKyID.ToString() + "," + "KieuTrongID=" + KieuTrongID.ToString() + "," + "ThoiGianDangKy=" + DBModule.RefineDatetime(ThoiGianDangKy, true) + "," + "DienTichDangKy=" + DienTichDangKy.ToString() + "," + "NangSuatDangKy=" + NangSuatDangKy.ToString() + "," + "SanLuongDangKy=" + SanLuongDangKy.ToString() + "," + "DienTichDuKienChatGiong =" + DienTichDuKienChatGiong.ToString() + "," + "DienTichPheCanh=" + DienTichPheCanh.ToString() + "," + "DienTichChatGiong=" + DienTichChatGiong.ToString() + "," + "NangSuatChatGiong=" + NangSuatChatgiong.ToString() + ",SanLuongChatGiong=" + SanLuongChatGiong.ToString() + ",NguyenNhanPheCanh=N'" + NguyenNhanPheCanh + "'" + ",TrangThaiDangKy=" + TrangThaiDangKy.ToString() +
                   ", ModifyBy = " + MDSolutionApp.User.ID.ToString() +
                ", DataModify = getdate() " +
                ", NoteModify = '" + DBModule.RefineString(NoteModify) + "'" +
                " Where ID = " + ID.ToString();
            }
            // run SQL statement

            //DBModule.ExecuteNonQuery(strSQL, cn, trans);
            if (ID <= 0)
            {
                strSQL += ";SELECT @@IDENTITY AS 'Identity';";
                ID = long.Parse(DBModule.ExecuteQueryForOneResult(strSQL, cn, trans));
            }
            else
                DBModule.ExecuteNonQuery(strSQL, cn, trans);
                
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_ThuaRuong where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_ThuaRuong where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }

       
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_ThuaRuong where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("SoBanDieuTra"))
                    SoBanDieuTra = dr["SoBanDieuTra"].ToString();
                if (!dr.IsNull("MaThuaRuong"))
                    MaThuaRuong = dr["MaThuaRuong"].ToString();
                if (!dr.IsNull("HopDongID"))
                    HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("ThonID"))
                    ThonID = long.Parse(dr["ThonID"].ToString());
                if (!dr.IsNull("HienTrangGiaoThong"))
                    HienTrangGiaoThong = long.Parse(dr["HienTrangGiaoThong"].ToString());
                if (!dr.IsNull("DienTich"))
                    DienTich = decimal.Parse(dr["DienTich"].ToString());
                if (!dr.IsNull("LoaiDatID"))
                    LoaiDatID = long.Parse(dr["LoaiDatID"].ToString());
                if (!dr.IsNull("TramNongVuID"))
                    TramNongVuID = long.Parse(dr["TramNongVuID"].ToString());
                if (!dr.IsNull("SoHieuKeUoc"))
                    SoHieuKeUoc = dr["SoHieuKeUoc"].ToString();
                if (!dr.IsNull("XuDong"))
                    XuDong = dr["XuDong"].ToString();
                if (!dr.IsNull("DuongVanChuyenID"))
                    DuongVanChuyenID = long.Parse(dr["DuongVanChuyenID"].ToString());
                if (!dr.IsNull("RaiVuID"))
                    RaiVuID = long.Parse(dr["RaiVuID"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("GiongMiaID"))
                    GiongMiaID = long.Parse(dr["GiongMiaID"].ToString());
                if (!dr.IsNull("NgayTrong"))
                    NgayTrong = DateTime.Parse(dr["NgayTrong"].ToString());
                if (!dr.IsNull("NgayThuHoachDuKien"))
                    NgayThuHoachDuKien = DateTime.Parse(dr["NgayThuHoachDuKien"].ToString());
                if (!dr.IsNull("NangSuatDuKien"))
                    NangSuatDuKien = decimal.Parse(dr["NangSuatDuKien"].ToString());
                if (!dr.IsNull("SanLuongDuKien"))
                    SanLuongDuKien = decimal.Parse(dr["SanLuongDuKien"].ToString());
                if (!dr.IsNull("NangSuatDuKien1"))
                    NangSuatDuKien1 = decimal.Parse(dr["NangSuatDuKien1"].ToString());
                if (!dr.IsNull("SanLuongDuKien1"))
                    SanLuongDuKien1 = decimal.Parse(dr["SanLuongDuKien1"].ToString());
                if (!dr.IsNull("MucDichID"))
                    MucDichID = long.Parse(dr["MucDichID"].ToString());
                if (!dr.IsNull("PheCanhID"))
                    PheCanhID = long.Parse(dr["PheCanhID"].ToString());
                if (!dr.IsNull("TrangThai"))
                    TrangThai = long.Parse(dr["TrangThai"].ToString());
                if (!dr.IsNull("TinhTrang"))
                    TinhTrang = long.Parse(dr["TinhTrang"].ToString());
                if (!dr.IsNull("XuDongDangKy")) 
                    XuDongDangKy = dr["XuDongDangKy"].ToString();
                if (!dr.IsNull("LoaiDatDangKyID")) 
                    LoaiDatDangKyID = long.Parse(dr["LoaiDatDangKyID"].ToString());
                if (!dr.IsNull("GiongMiaDangKyID")) 
                    GiongMiaDangKyID = long.Parse(dr["GiongMiaDangKyID"].ToString());
                if (!dr.IsNull("KieuTrongID"))
                    KieuTrongID = long.Parse(dr["KieuTrongID"].ToString());
                if (!dr.IsNull("ThoiGianDangKy"))
                    ThoiGianDangKy = DateTime.Parse(dr["ThoiGianDangKy"].ToString());
                if (!dr.IsNull("DienTichDangKy")) 
                    DienTichDangKy = float.Parse(dr["DienTichDangKy"].ToString());
                if (!dr.IsNull("NangSuatDangKy")) 
                    NangSuatDangKy = float.Parse(dr["NangSuatDangKy"].ToString());
                if (!dr.IsNull("SanLuongDangKy")) 
                    SanLuongDangKy = float.Parse(dr["SanLuongDangKy"].ToString());
                // dien tich phe canh,chat giong
                if (!dr.IsNull("DienTichPheCanh"))
                    DienTichPheCanh = decimal.Parse(dr["DienTichPheCanh"].ToString());
                if (!dr.IsNull("DienTichChatgiong"))
                    DienTichChatGiong = decimal.Parse(dr["DienTichChatgiong"].ToString());
                if (!dr.IsNull("DienTichDuKienChatgiong"))
                    DienTichDuKienChatGiong = decimal.Parse(dr["DienTichDuKienChatgiong"].ToString());
                if (!dr.IsNull("NangSuatChatGiong"))
                    NangSuatChatgiong = decimal.Parse(dr["NangSuatChatGiong"].ToString());
                if (!dr.IsNull("SanLuongChatgiong"))
                    SanLuongChatGiong = decimal.Parse(dr["SanLuongChatgiong"].ToString());
                if (!dr.IsNull("BaiTapKetID"))
                    BaiTapKetID = long.Parse(dr["BaiTapKetID"].ToString());
                if (!dr.IsNull("CanBoNongVuID"))
                    CanBoNongVuID = long.Parse(dr["CanBoNongVuID"].ToString());
                if (!dr.IsNull("NguyenNhanPheCanh"))
                    NguyenNhanPheCanh = (dr["NguyenNhanPheCanh"].ToString());
                if (!dr.IsNull("TrangThaiDangKy")) 
                     TrangThaiDangKy = long.Parse(dr["TrangThaiDangKy"].ToString());
                
            }

        }
        public void Load(string SoThua, OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_ThuaRuong where MaThuaRuong=" + SoThua;
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("SoBanDieuTra"))
                    SoBanDieuTra = dr["SoBanDieuTra"].ToString();
                if (!dr.IsNull("MaThuaRuong"))
                    MaThuaRuong = dr["MaThuaRuong"].ToString();
                if (!dr.IsNull("HopDongID"))
                    HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("ThonID"))
                    ThonID = long.Parse(dr["ThonID"].ToString());
                if (!dr.IsNull("HienTrangGiaoThong"))
                    HienTrangGiaoThong = long.Parse(dr["HienTrangGiaoThong"].ToString());
                if (!dr.IsNull("DienTich"))
                    DienTich = decimal.Parse(dr["DienTich"].ToString());
                if (!dr.IsNull("LoaiDatID"))
                    LoaiDatID = long.Parse(dr["LoaiDatID"].ToString());
                if (!dr.IsNull("TramNongVuID"))
                    TramNongVuID = long.Parse(dr["TramNongVuID"].ToString());
                if (!dr.IsNull("SoHieuKeUoc"))
                    SoHieuKeUoc = dr["SoHieuKeUoc"].ToString();
                if (!dr.IsNull("XuDong"))
                    XuDong = dr["XuDong"].ToString();
                if (!dr.IsNull("DuongVanChuyenID"))
                    DuongVanChuyenID = long.Parse(dr["DuongVanChuyenID"].ToString());
                if (!dr.IsNull("RaiVuID"))
                    RaiVuID = long.Parse(dr["RaiVuID"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("GiongMiaID"))
                    GiongMiaID = long.Parse(dr["GiongMiaID"].ToString());
                if (!dr.IsNull("NgayTrong"))
                    NgayTrong = DateTime.Parse(dr["NgayTrong"].ToString());
                if (!dr.IsNull("NgayThuHoachDuKien"))
                    NgayThuHoachDuKien = DateTime.Parse(dr["NgayThuHoachDuKien"].ToString());
                if (!dr.IsNull("NangSuatDuKien"))
                    NangSuatDuKien = decimal.Parse(dr["NangSuatDuKien"].ToString());
                if (!dr.IsNull("SanLuongDuKien"))
                    SanLuongDuKien = decimal.Parse(dr["SanLuongDuKien"].ToString());
                if (!dr.IsNull("NangSuatDuKien1"))
                    NangSuatDuKien1 = decimal.Parse(dr["NangSuatDuKien1"].ToString());
                if (!dr.IsNull("SanLuongDuKien1"))
                    SanLuongDuKien1 = decimal.Parse(dr["SanLuongDuKien1"].ToString());
                if (!dr.IsNull("MucDichID"))
                    MucDichID = long.Parse(dr["MucDichID"].ToString());
                if (!dr.IsNull("PheCanhID"))
                    PheCanhID = long.Parse(dr["PheCanhID"].ToString());
                if (!dr.IsNull("TrangThai"))
                    TrangThai = long.Parse(dr["TrangThai"].ToString());
                if (!dr.IsNull("TinhTrang"))
                    TinhTrang = long.Parse(dr["TinhTrang"].ToString());
                if (!dr.IsNull("XuDongDangKy"))
                    XuDongDangKy = dr["XuDongDangKy"].ToString();
                if (!dr.IsNull("LoaiDatDangKyID"))
                    LoaiDatDangKyID = long.Parse(dr["LoaiDatDangKyID"].ToString());
                if (!dr.IsNull("GiongMiaDangKyID"))
                    GiongMiaDangKyID = long.Parse(dr["GiongMiaDangKyID"].ToString());
                if (!dr.IsNull("KieuTrongID"))
                    KieuTrongID = long.Parse(dr["KieuTrongID"].ToString());
                if (!dr.IsNull("ThoiGianDangKy"))
                    ThoiGianDangKy = DateTime.Parse(dr["ThoiGianDangKy"].ToString());
                if (!dr.IsNull("DienTichDangKy"))
                    DienTichDangKy = float.Parse(dr["DienTichDangKy"].ToString());
                if (!dr.IsNull("NangSuatDangKy"))
                    NangSuatDangKy = float.Parse(dr["NangSuatDangKy"].ToString());
                if (!dr.IsNull("SanLuongDangKy"))
                    SanLuongDangKy = float.Parse(dr["SanLuongDangKy"].ToString());
                // dien tich phe canh,chat giong
                if (!dr.IsNull("DienTichPheCanh"))
                    DienTichPheCanh = decimal.Parse(dr["DienTichPheCanh"].ToString());
                if (!dr.IsNull("DienTichChatgiong"))
                    DienTichChatGiong = decimal.Parse(dr["DienTichChatgiong"].ToString());
                if (!dr.IsNull("DienTichDuKienChatgiong"))
                    DienTichDuKienChatGiong = decimal.Parse(dr["DienTichDuKienChatgiong"].ToString());
                if (!dr.IsNull("NangSuatChatGiong"))
                    NangSuatChatgiong = decimal.Parse(dr["NangSuatChatGiong"].ToString());
                if (!dr.IsNull("SanLuongChatgiong"))
                    SanLuongChatGiong = decimal.Parse(dr["SanLuongChatgiong"].ToString());
                if (!dr.IsNull("BaiTapKetID"))
                    BaiTapKetID = long.Parse(dr["BaiTapKetID"].ToString());
                if (!dr.IsNull("CanBoNongVuID"))
                    CanBoNongVuID = long.Parse(dr["CanBoNongVuID"].ToString());
                if (!dr.IsNull("NguyenNhanPheCanh"))
                    NguyenNhanPheCanh = (dr["NguyenNhanPheCanh"].ToString());
                if (!dr.IsNull("TrangThaiDangKy"))
                    TrangThaiDangKy = long.Parse(dr["TrangThaiDangKy"].ToString());
            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_ThuaRuong ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_ThuaRuong WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }

        #endregion
        #region extention functions
        public static DataSet GetListForDienTichCoCauTrong(string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {

            string strSQL = "SELECT a.*,(convert(decimal,a.DienTich)/10000)AS DienTich1,(convert(decimal,a.DienTichDuKienChatGiong)/10000)AS DienTichDuKienChatGiong1,(convert(decimal,a.DienTichPheCanh)/10000)AS DienTichPheCanh1, (convert(decimal,a.DienTichChatGiong)/10000)AS DienTichChatGiong1,(Select Ten from tbl_loaiDat where ID=a.LoaiDatDangKyID) as LoaiDatDangKy,(Select Ten from tbl_GiongMia where ID=a.GiongMiaDangKyID) as GiongMiaDangKy,(select Ten from tbl_kieutrong where ID=a.KieuTrongDangKyID) as KieuTrongDangKy, b.Ten as TenThon FROM tbl_ThuaRuong as a LEFT JOIN tbl_Thon as b ON a.ThonID = b.ID WHERE 1=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        public static string GetSumForDienTichCoCauTrong(string strWhere, OleDbConnection cn, OleDbTransaction trans)
        {

            string strSQL = "SELECT ISNULL(SUM(convert(decimal,a.DienTich)/10000),0) FROM tbl_ThuaRuong as a LEFT JOIN tbl_Thon as b ON a.ThonID = b.ID WHERE 1=1 AND TrangThai=1";
            if (strWhere != "") strSQL += " AND " + strWhere;
            return DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
        }

        public static long TongDienTichTrong(string VuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            long temp = 0;
            // build SQL statement
            strSQL = "select sum(DienTich) as tong from tbl_ThuaRuong Where TrangThai=1 AND VuTrongID=" + VuTrongID;
            // run SQL statement
            DataSet ds = null;
            ds = DBModule.ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows[0][0].ToString() != null)
            {

                try
                {
                    temp = long.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    temp = 0;
                }
            }
            return temp;
        }
        public static long TongDienTichConLai(string VuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            long temp = 0;
            // build SQL statement
            strSQL = "select sum(DienTich) as tong from tbl_ThuaRuong Where VuTrongID=" + VuTrongID + " AND TrangThai=1 AND TinhTrang=3";
            // run SQL statement
            DataSet ds = null;
            ds = DBModule.ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows[0][0].ToString() != null)
            {
                try
                {
                    temp = long.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    temp = 0;
                }
            }
            return temp;
        }
        public static long TongSanLuong(string VuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            long temp = 0;
            // build SQL statement
            strSQL = "select sum(SanLuongDuKien) from tbl_ThuaRuong Where TrangThai=1 AND TinhTrang>=3 AND VuTrongID=" + VuTrongID;
            // run SQL statement
            DataSet ds = null;
            ds = DBModule.ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows[0][0].ToString() != null)
            {
                try
                {
                    temp = long.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    temp = 0;
                }
            }
            return temp;
        }

        public static long TongSanLuong1(string VuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            long temp = 0;
            // build SQL statement
            strSQL = "select sum(SanLuongDuKien1) from tbl_ThuaRuong Where TrangThai=1 AND TinhTrang>=3 AND VuTrongID=" + VuTrongID;
            // run SQL statement
            DataSet ds = null;
            ds = DBModule.ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows[0][0].ToString() != null)
            {
                try
                {
                    temp = long.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    temp = 0;
                }
            }
            return temp;
        }

        public static long TongSanLuongConLai(string VuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            long temp = 0;
            // build SQL statement
            strSQL = "select sum(SanLuongDuKien) from tbl_ThuaRuong Where TrangThai=1 AND VuTrongID=" + VuTrongID + " AND TinhTrang=3";
            // run SQL statement
            DataSet ds = null;
            ds = DBModule.ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows[0][0].ToString() != null)
            {
                try
                {
                    temp = long.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    temp = 0;
                }
            }
            return temp;
        }
        public static long TongSanLuongConLai1(string VuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            long temp = 0;
            // build SQL statement
            strSQL = "select sum(SanLuongDuKien1) from tbl_ThuaRuong Where TrangThai=1 AND VuTrongID=" + VuTrongID + " AND TinhTrang=3";
            // run SQL statement
            DataSet ds = null;
            ds = DBModule.ExecuteQuery(strSQL, cn, trans);
            if (ds.Tables[0].Rows[0][0].ToString() != null)
            {
                try
                {
                    temp = long.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    temp = 0;
                }
            }
            return temp;
        }

        #endregion
    }
}