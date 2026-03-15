
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsHopDong
    {
        public long ID = -1;
        public long ParentID = 0;
        public string MaHopDong = "";
        public DateTime NgaySinh = DateTime.MinValue;
        public string SoCMT = "";
        public DateTime NgayCap = DateTime.MinValue;
        public string NoiCap = "";
        public long ThonID = -1;
        public string NguoiThuaKe1Ten = "";
        public string NguoiThuaKe1DiaChi = "";
        public string NguoiThuaKe1CMT = "";
        public string NguoiThuaKe2Ten = "";
        public string NguoiThuaKe2DiaChi = "";
        public string NguoiThuaKe2CMT = "";
        public long TrangThai = 0;
        public string HoTen = "";
        public string SoTaiKhoan = "";
        public long NganHangID = -1;
        public DateTime NgayKyHopDong = DateTime.MinValue;
        public long CanBoNongVuID = 0;
        public DateTime NgayCMTTKP = DateTime.MinValue;
        public String GhiChu = "";
        //De quan ly nguoi sua, ngay gio sua thong tin 

        public string NoteModify = "";
        public int MuaTaiBanCan = -1;
        public int NguoiNhapMuaTaiBanCanID = -1;
        public DateTime NgayNhapMuaTaiBanCan = DateTime.MinValue;
        
        public clsHopDong()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsHopDong(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                //id = lddata.DBModule.GetNewID(typeof(HopDong), "tbl_HopDong", cn, trans);
                ID = DBModule.GetNewID(typeof(clsHopDong), "tbl_HopDong", cn, trans);
                //NgayTao = DateTime.Now;        
                //NgaySua = DateTime.Now;        
                // build SQL statement


                strSQL = "Insert into tbl_HopDong" +
                "(ID,MaHopDong,NgaySinh,SoCMT,NgayCap,NoiCap,ThonID,NguoiThuaKe1Ten,NguoiThuaKe1DiaChi,NguoiThuaKe1CMT,NguoiThuaKe2Ten,NguoiThuaKe2DiaChi,NguoiThuaKe2CMT,TrangThai,HoTen,NgayKyHopDong,ParentID,SoTaiKhoan,NganHangID, CreatedBy, ModifyBy, DateAdd, DataModify, NoteModify,CanBoNongVuID,NgayCMTTKP,GhiChu,MuaTaiBanCan,NguoiNhapMuaTaiBanCanID,NgayNhapMuaTaiBanCan) Values(" +
                    ID.ToString() + "," + "N'" + DBModule.RefineString(MaHopDong) + "'" + "," + DBModule.RefineDatetime(NgaySinh, true) + "," + "N'" + DBModule.RefineString(SoCMT) + "'" + "," + DBModule.RefineDatetime(NgayCap, true) + "," + "N'" + DBModule.RefineString(NoiCap) + "'" + "," + ThonID.ToString() + "," + "N'" + DBModule.RefineString(NguoiThuaKe1Ten) + "'" + "," + "N'" + DBModule.RefineString(NguoiThuaKe1DiaChi) + "'" + "," + "N'" + DBModule.RefineString(NguoiThuaKe1CMT) + "'" + "," + "N'" + DBModule.RefineString(NguoiThuaKe2Ten) + "'" + "," + "N'" + DBModule.RefineString(NguoiThuaKe2DiaChi) + "'" + "," + "N'" + DBModule.RefineString(NguoiThuaKe2CMT) + "'" + "," + TrangThai.ToString() + "," + "N'" + DBModule.RefineString(HoTen) + "'" + "," + DBModule.RefineDatetime(NgayKyHopDong, true) + "," + ParentID.ToString() + ",N'" + SoTaiKhoan + "'," + NganHangID.ToString() + "N'" + DBModule.RefineDatetime(NgayCMTTKP) + "'" + "," + "N'" + DBModule.RefineString(HoTen) + "'" +
                    ", " + MDSolutionApp.User.ID.ToString() +
                ", " + MDSolutionApp.User.ID.ToString() +
                ", getdate()" +
                ", getdate() " +
                ", N'" + DBModule.RefineString(NoteModify) +"',"+
                 CanBoNongVuID.ToString()  +
                 "," + MuaTaiBanCan.ToString() +
                  "," + NguoiNhapMuaTaiBanCanID.ToString() +
                 "," + DBModule.RefineDatetime(NgayNhapMuaTaiBanCan, true) +
                 ")";

            }
            else // edit object, we update old record in database
            {

                strSQL = "Update tbl_HopDong set " +
                    "MaHopDong=" + "N'" + DBModule.RefineString(MaHopDong) + "'" + "," + "NgaySinh=" + DBModule.RefineDatetime(NgaySinh, true) + "," + "SoCMT=" + "N'" + DBModule.RefineString(SoCMT) + "'" + "," + "NgayCap=" + DBModule.RefineDatetime(NgayCap, true) + "," + "NoiCap=" + "N'" + DBModule.RefineString(NoiCap) + "'" + "," + "ThonID=" + ThonID.ToString() + "," + "NguoiThuaKe1Ten=" + "N'" + DBModule.RefineString(NguoiThuaKe1Ten) + "'" + "," + "NguoiThuaKe1DiaChi=" + "N'" + DBModule.RefineString(NguoiThuaKe1DiaChi) + "'" + "," + "NguoiThuaKe1CMT=" + "N'" + DBModule.RefineString(NguoiThuaKe1CMT) + "'" + "," + "NguoiThuaKe2Ten=" + "N'" + DBModule.RefineString(NguoiThuaKe2Ten) + "'" + "," + "NguoiThuaKe2DiaChi=" + "N'" + DBModule.RefineString(NguoiThuaKe2DiaChi) + "'" + "," + "NguoiThuaKe2CMT=" + "N'" + DBModule.RefineString(NguoiThuaKe2CMT) + "'" + "," + "TrangThai=" + TrangThai.ToString() + "," + "HoTen=" + "N'" + DBModule.RefineString(HoTen) + "'" + "," + "NgayKyHopDong=" + DBModule.RefineDatetime(NgayKyHopDong, true) + ", ParentID=" + ParentID.ToString() + "," + "NgayCMTTKP=" + DBModule.RefineDatetime(NgayCMTTKP, true) + "," + "GhiChu=" + "N'" + DBModule.RefineString(GhiChu) + "'" +
                    ", SoTaiKhoan=N'" + SoTaiKhoan + "' , NganHangID=" + NganHangID.ToString() + 
                    
                    ", ModifyBy = " + MDSolutionApp.User.ID.ToString() +
                ", DataModify = getdate() " +
                ", NoteModify = '" + DBModule.RefineString(NoteModify) + "'" +
                 ",CanBoNongVuID=" + CanBoNongVuID.ToString()+
                 ",MuaTaiBanCan=" + MuaTaiBanCan.ToString() +
                  ",NguoiNhapMuaTaiBanCanID=" + NguoiNhapMuaTaiBanCanID.ToString() +
                 ",NgayNhapMuaTaiBanCan=" + DBModule.RefineDatetime(NgayNhapMuaTaiBanCan, true) +
                " Where ID = " + ID.ToString();                    
            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_HopDong", cn, trans));
                */
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_HopDong where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_HopDong where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_HopDong where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("ParentID"))
                    ParentID = long.Parse(dr["ParentID"].ToString());
                if (!dr.IsNull("MaHopDong"))
                    MaHopDong = dr["MaHopDong"].ToString();
                if (!dr.IsNull("NgaySinh"))
                    NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString());
                if (!dr.IsNull("SoCMT"))
                    SoCMT = dr["SoCMT"].ToString();
                if (!dr.IsNull("NgayCap"))
                    NgayCap = DateTime.Parse(dr["NgayCap"].ToString());
                if (!dr.IsNull("NoiCap"))
                    NoiCap = dr["NoiCap"].ToString();
                if (!dr.IsNull("ThonID"))
                    ThonID = long.Parse(dr["ThonID"].ToString());
                if (!dr.IsNull("NguoiThuaKe1Ten"))
                    NguoiThuaKe1Ten = dr["NguoiThuaKe1Ten"].ToString();
                if (!dr.IsNull("NguoiThuaKe1DiaChi"))
                    NguoiThuaKe1DiaChi = dr["NguoiThuaKe1DiaChi"].ToString();
                if (!dr.IsNull("NguoiThuaKe1CMT"))
                    NguoiThuaKe1CMT = dr["NguoiThuaKe1CMT"].ToString();
                if (!dr.IsNull("NguoiThuaKe2Ten"))
                    NguoiThuaKe2Ten = dr["NguoiThuaKe2Ten"].ToString();
                if (!dr.IsNull("NguoiThuaKe2DiaChi"))
                    NguoiThuaKe2DiaChi = dr["NguoiThuaKe2DiaChi"].ToString();
                if (!dr.IsNull("NguoiThuaKe2CMT"))
                    NguoiThuaKe2CMT = dr["NguoiThuaKe2CMT"].ToString();
                if (!dr.IsNull("TrangThai"))
                    TrangThai = long.Parse(dr["TrangThai"].ToString());
                if (!dr.IsNull("HoTen"))
                    HoTen = dr["HoTen"].ToString();
                if (!dr.IsNull("SoTaiKhoan"))
                    SoTaiKhoan = dr["SoTaiKhoan"].ToString();
                if (!dr.IsNull("NganHangID"))
                    NganHangID = long.Parse(dr["NganHangID"].ToString());
                if (!dr.IsNull("NgayKyHopDong"))
                    NgayKyHopDong = DateTime.Parse(dr["NgayKyHopDong"].ToString());
                if (!dr.IsNull("CanBoNongVuID"))
                    CanBoNongVuID = long.Parse(dr["CanBoNongVuID"].ToString());
                if (!dr.IsNull("NgayCMTTKP"))
                    NgayCMTTKP = DateTime.Parse(dr["NgayCMTTKP"].ToString());
                if (!dr.IsNull("GhiChu"))
                    GhiChu = dr["GhiChu"].ToString();

                if (!dr.IsNull("MuaTaiBanCan"))
                    MuaTaiBanCan =int.Parse(dr["MuaTaiBanCan"].ToString());
                if (!dr.IsNull("NguoiNhapMuaTaiBanCanID"))
                    NguoiNhapMuaTaiBanCanID = int.Parse(dr["NguoiNhapMuaTaiBanCanID"].ToString());
                if (!dr.IsNull("NgayNhapMuaTaiBanCan"))
                    NgayNhapMuaTaiBanCan = DateTime.Parse(dr["NgayNhapMuaTaiBanCan"].ToString());
            }

        }
        public void Load(string MaHopDong, OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_HopDong where MaHopDong='" + MaHopDong + "'";
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("ParentID"))
                    ParentID = long.Parse(dr["ParentID"].ToString());
                if (!dr.IsNull("MaHopDong"))
                    MaHopDong = dr["MaHopDong"].ToString();
                if (!dr.IsNull("NgaySinh"))
                    NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString());
                if (!dr.IsNull("SoCMT"))
                    SoCMT = dr["SoCMT"].ToString();
                if (!dr.IsNull("NgayCap"))
                    NgayCap = DateTime.Parse(dr["NgayCap"].ToString());
                if (!dr.IsNull("NoiCap"))
                    NoiCap = dr["NoiCap"].ToString();
                if (!dr.IsNull("ThonID"))
                    ThonID = long.Parse(dr["ThonID"].ToString());
                if (!dr.IsNull("NguoiThuaKe1Ten"))
                    NguoiThuaKe1Ten = dr["NguoiThuaKe1Ten"].ToString();
                if (!dr.IsNull("NguoiThuaKe1DiaChi"))
                    NguoiThuaKe1DiaChi = dr["NguoiThuaKe1DiaChi"].ToString();
                if (!dr.IsNull("NguoiThuaKe1CMT"))
                    NguoiThuaKe1CMT = dr["NguoiThuaKe1CMT"].ToString();
                if (!dr.IsNull("NguoiThuaKe2Ten"))
                    NguoiThuaKe2Ten = dr["NguoiThuaKe2Ten"].ToString();
                if (!dr.IsNull("NguoiThuaKe2DiaChi"))
                    NguoiThuaKe2DiaChi = dr["NguoiThuaKe2DiaChi"].ToString();
                if (!dr.IsNull("NguoiThuaKe2CMT"))
                    NguoiThuaKe2CMT = dr["NguoiThuaKe2CMT"].ToString();
                if (!dr.IsNull("TrangThai"))
                    TrangThai = long.Parse(dr["TrangThai"].ToString());
                if (!dr.IsNull("HoTen"))
                    HoTen = dr["HoTen"].ToString();
                if (!dr.IsNull("SoTaiKhoan"))
                    SoTaiKhoan = dr["SoTaiKhoan"].ToString();
                if (!dr.IsNull("NganHangID"))
                    NganHangID = long.Parse(dr["NganHangID"].ToString());
                if (!dr.IsNull("NgayKyHopDong"))
                    NgayKyHopDong = DateTime.Parse(dr["NgayKyHopDong"].ToString());
                if (!dr.IsNull("CanBoNongVuID"))
                    CanBoNongVuID = long.Parse(dr["CanBoNongVuID"].ToString());
                if (!dr.IsNull("MuaTaiBanCan"))
                    MuaTaiBanCan = int.Parse(dr["MuaTaiBanCan"].ToString());
                if (!dr.IsNull("NguoiNhapMuaTaiBanCanID"))
                    NguoiNhapMuaTaiBanCanID = int.Parse(dr["NguoiNhapMuaTaiBanCanID"].ToString());
                if (!dr.IsNull("NgayNhapMuaTaiBanCan"))
                    NgayNhapMuaTaiBanCan = DateTime.Parse(dr["NgayNhapMuaTaiBanCan"].ToString());
                
            }

        }

        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_HopDong ";
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);

        }
        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_HopDong WHERE 1=1 AND ID IN (select HopDongID from tbl_HopDongVuTrong Where VuTrongID="+MDSolutionApp.VuTrongID.ToString()+")";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        public static DataSet GetListbyWhereThon(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*,dbo.tbl_Thon.Ten AS TenThon";
            string strSQL = "SELECT " + strFields + " FROM   dbo.tbl_HopDong INNER JOIN dbo.tbl_Thon ON dbo.tbl_HopDong.ThonID = dbo.tbl_Thon.ID  WHERE 1=1 AND dbo.tbl_HopDong.ID IN (select HopDongID from tbl_HopDongVuTrong Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + ")";
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        public string GetTinhTrangHopDongTrongVu(long VuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            try
            {
                string strSQL = "SELECT DotThanhToan FROM tbl_HopDong_DaLamThanhToan WHERE HopDongID=" + this.ID.ToString() + " AND VuTrongID=" + VuTrongID.ToString();
                string ret = DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
                if (ret != null && ret != "")
                {
                    return "2-" + ret;
                }
                else
                {
                    strSQL = "SELECT DotThanhToan FROM tbl_HopDong_ChoLamThanhToan WHERE HopDongID=" + this.ID.ToString() + " AND VuTrongID=" + VuTrongID.ToString();
                    ret = DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
                    if (ret != null && ret != "")
                    {
                        return "1-" + ret;
                    }
                    else
                    {
                        return "0";
                    }
                }
            }
            catch
            {
                return "0";
            }
        }
        public static DateTime GetNgayTinhCongNo(long iHopDongID, long iVuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            DateTime dtret = DateTime.Now;

            string strSQL = "SELECT NgayTinhCongNo FROM tbl_NgayTinhCongNo WHERE HopDongID=" + iHopDongID.ToString() + " AND VuTrongID=" + iVuTrongID.ToString();

            string ret = DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
            if (ret != null && ret != "")
            {
                dtret = DateTime.Parse(ret);
            }


            return dtret;
        }
        public static long GetTongTienDauTuConLai(long iHopDongID, long iVuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "[sp_Get_TongTien_DauTu_ConLai] " + iHopDongID.ToString() + "," + iVuTrongID.ToString();
            return long.Parse(DBModule.ExecuteQueryForOneResult(strSQL, null, null));
        }
        public static long GetTongCacKhoanTienCo(long iHopDongID, long iVuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "[sp_Get_TongTien_CacKhoan_Co] " + iHopDongID.ToString() + "," + iVuTrongID.ToString();
            return long.Parse(DBModule.ExecuteQueryForOneResult(strSQL, null, null));
        }
        #endregion
        #region extention functions
        public static long GetTongTienDauTuPhaiTra(long iHopDongID, long iVuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "[sp_Get_TongTien_DauTu_PhaiTra] " + iHopDongID.ToString() + "," + iVuTrongID.ToString();
            return long.Parse(DBModule.ExecuteQueryForOneResult(strSQL, null, null));
        }
        public static long GetTongCacKhoanTienCoThuDuoc(long iHopDongID, long iVuTrongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "[sp_Get_TongTien_CacKhoan_ThuDuoc] " + iHopDongID.ToString() + "," + iVuTrongID.ToString();
            return long.Parse(DBModule.ExecuteQueryForOneResult(strSQL, null, null));
        }
        public static DataSet GetDanhSachHopDongTheoDieuKien(long lID, string strDieuKienTimKiem, DonviType dvType, string dvID, Boolean timchinhxac)
        {

            string strSQLWhere = " trangthai = 1 AND ParentID>0";
            if (lID > 0)
            {
                strSQLWhere += "AND ID= " + lID.ToString() ;
            }
            else
            {
                switch (dvType)
                {
                    case DonviType.Cum: strSQLWhere += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID IN (SELECT ID FROM tbl_Xa WHERE CumID="+dvID+"))"; break;
                    case DonviType.Xa: strSQLWhere += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + dvID + ")"; break;
                    case DonviType.Thon: strSQLWhere += " AND ThonID=" + dvID; break;
                    case DonviType.ChuHopDong: strSQLWhere += " AND ParentID=" + dvID; break;
                    default: strSQLWhere +=" AND ID=0"; break;
                }

                if ((timchinhxac) && (strDieuKienTimKiem != ""))
                {

                    strSQLWhere += " AND (MaHopDong= N'" + DBModule.RefineString(strDieuKienTimKiem) + "' OR HoTen= N'" + DBModule.RefineString(strDieuKienTimKiem) + "' )";

                }
                else
                {

                    strSQLWhere += " AND (MaHopDong like N'%" + DBModule.RefineString(strDieuKienTimKiem) + "%' OR HoTen like N'%" + DBModule.RefineString(strDieuKienTimKiem) + "%' )";

                }
            }
            return clsHopDong.GetListbyWhere("", strSQLWhere, "", null, null);
        }

        public static DataSet GetDanhSachDenHopDong(long lID, string strDieuKienTimKiem, DonviType dvType, string dvID, Boolean timchinhxac)
        {

            string strSQLWhere = " trangthai = 1";//+ " AND ParentID=0"
            if (lID > 0)
            {
                strSQLWhere += "AND ID= " + lID.ToString();
            }
            else
            {
                switch (dvType)
                {
                    case DonviType.Cum: strSQLWhere += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID IN (SELECT ID FROM tbl_Xa WHERE CumID=" + dvID + "))"; break;
                    case DonviType.Xa: strSQLWhere += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + dvID + ")"; break;
                    case DonviType.Thon: strSQLWhere += " AND ThonID=" + dvID; break;
                    case DonviType.ChuHopDong: strSQLWhere += " AND ParentID=" + dvID; break;
                    default: break;
                }

                if ((timchinhxac) && (strDieuKienTimKiem != ""))
                {

                    strSQLWhere += " AND (MaHopDong= N'" + DBModule.RefineString(strDieuKienTimKiem) + "' OR HoTen= N'" + DBModule.RefineString(strDieuKienTimKiem) + "' )";

                }
                else
                {
                    strSQLWhere += " AND (MaHopDong like N'%" + DBModule.RefineString(strDieuKienTimKiem) + "%' OR HoTen like N'%" + DBModule.RefineString(strDieuKienTimKiem) + "%' )";
                }
            }
            return clsHopDong.GetListbyWhere("", strSQLWhere, "", null, null);
        }

        public static DataSet GetDanhSachDenHopDong(long lID, string strDieuKienTimKiem, DonviType dvType, string dvID, Boolean timchinhxac, string CacTramID)
        { // su dung cho phan quyen theo tram.

            string strSQLWhere = " trangthai = 1";//+ " AND ParentID=0"
            if (lID > 0)
            {
                strSQLWhere += "AND ID= " + lID.ToString();
            }
            else
            {
                switch (dvType)
                {
                    case DonviType.Cum: strSQLWhere += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID IN (SELECT ID FROM tbl_Xa WHERE CumID=" + dvID + "))"; break;
                    case DonviType.Xa: strSQLWhere += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + dvID + ")"; break;
                    case DonviType.Thon: strSQLWhere += " AND ThonID=" + dvID; break;
                    case DonviType.ChuHopDong: strSQLWhere += " AND ParentID=" + dvID; break;
                    default: if (CacTramID != "") strSQLWhere += "  AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID IN (SELECT ID FROM tbl_Xa WHERE CumID in(" + CacTramID + ")))"; break;
                }

                if ((timchinhxac) && (strDieuKienTimKiem != ""))
                {

                    strSQLWhere += " AND (MaHopDong= N'" + DBModule.RefineString(strDieuKienTimKiem) + "' OR HoTen= N'" + DBModule.RefineString(strDieuKienTimKiem) + "' )";
                }
                else
                {
                    strSQLWhere += " AND (MaHopDong like N'%" + DBModule.RefineString(strDieuKienTimKiem) + "%' OR HoTen like N'%" + DBModule.RefineString(strDieuKienTimKiem) + "%' )";
                }
            }
            return clsHopDong.GetListbyWhere("", strSQLWhere, "", null, null);
        }

        public static void UpdateHopDongVuTrong(long HopDongID, long VuTrongID, long trangthai, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = " DELETE FROM tbl_HopDongVuTrong WHERE HopDongID=" + HopDongID.ToString() + " AND VuTrongID=" + VuTrongID.ToString();
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            if (trangthai == 1)
            {
                strSQL = " INSERT INTO tbl_HopDongVuTrong(HopDongID, VuTrongID) VALUES(" + HopDongID.ToString() + "," + VuTrongID.ToString() + ")";
                DBModule.ExecuteNonQuery(strSQL, cn, trans);
            }
        }
        #endregion
    }
}