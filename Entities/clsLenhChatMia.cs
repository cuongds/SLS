
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Globalization;


namespace MDSolution
{
    public class clsLenhChatMia
    {
        public long ID = -1;
        public string SoLenh = "";
        public long ThuaRuongID = -1;
        public long TramID = -1;
        public long XuDongID = -1;
        public long HopDongID = -1;
        public long DotChat = -1;
        public long DaIn = -1;
        public long DaCan = -1;
        public DateTime NgayChat = DateTime.Now;
        public DateTime NgayChatDen = DateTime.Now;
        public DateTime NgayVanChuyen = DateTime.Now;
        public long XeVanChuyenID = -1;
        public long HDVanChuyenID = -1;
        public float SoLuongChat = 0;
        public float SoChuyen = 0;
        public long VuTrongID = MDSolutionApp.VuTrongID;
        public long DaChat = -1;
        public string SoXe = "";
        public string NoteModify = "";
        public long Created = -1;
        public long Modifyed = -1;
        public DateTime NgayTaoPhieu = DateTime.Now;
        public DateTime NgayInPhieu = DateTime.MinValue;
        public clsLenhChatMia()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public clsLenhChatMia(long lID)
        {
            ID = lID;
        }
        #region Basic function: Save, Delete, Load, GetList
        public void Save(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            if (ID <= 0) // new object, we insert new record to database
            {
                ID = this.NewID();

                // build SQL statement
                strSQL = "Insert into tbl_LenhChatMia(" +
                    "SoLenh " +
                    ",ThuaRuongID " +
                    ",TramID " +
                    ",XuDongID " +
                    ",HopDongID " +
                    ",DotChat " +
                    ",DaChat " +
                    ",DaIn " +
                    ",DaCan " +
                    ",NgayChat " +
                    ",NgayChatDen " +
                    ",NgayVanChuyen " +
                    ",XeVanChuyenID " +
                    ",HDVanChuyenID " +
                    ",SoLuongChat " +
                     ",SoChuyen " +
                    ",SoXe " +
                    ",VuTrongID " +
                     ",Created " +
                      ",Modifyed " +
                       ",NgayTaoPhieu " +
                        ",NgayInPhieu " +

                ") Values  (" +
                    "N'" + DBModule.RefineString(SoLenh) + "'" +
                    "," + ThuaRuongID.ToString() +
                    "," + TramID.ToString() +
                    "," + XuDongID.ToString() +
                    "," + HopDongID.ToString() +
                    "," + DotChat.ToString() +
                    "," + DaChat.ToString() +
                    "," + DaIn.ToString() +
                    "," + DaCan.ToString() +
                    "," + DBModule.RefineDatetime(NgayChat) +
                     "," + DBModule.RefineDatetime(NgayChatDen) +
                    "," + DBModule.RefineDatetime(NgayVanChuyen) +
                    "," + XeVanChuyenID.ToString() +
                    "," + HDVanChuyenID.ToString() +
                    "," + SoLuongChat.ToString() +
                     "," + SoChuyen.ToString() +
                    ", N'" + DBModule.RefineString(SoXe) + "'" +
                    "," + VuTrongID.ToString() +
                     "," + Created.ToString() +
                      "," + Modifyed.ToString() +
                       "," + DBModule.RefineDatetime(NgayTaoPhieu) +
                     "," + DBModule.RefineDatetime(NgayInPhieu,true) +
                    ");exec Create_LenhVanChuyen @@IDENTITY;";
            }
            else // edit object, we update old record in database
            {
                // build SQL statement				    
                //NgaySua = DateTime.Now;        
                strSQL = "Update tbl_LenhChatMia set " +
                    "SoLenh=" + "N'" + DBModule.RefineString(SoLenh) + "'" +
                    ", SoXe=" + "N'" + DBModule.RefineString(SoXe) + "'" +
                    ",ThuaRuongID=" + ThuaRuongID.ToString() +
                    ",XuDongID=" + XuDongID.ToString() +
                    ",TramID=" + TramID.ToString() +
                    ",HopDongID=" + HopDongID.ToString() +
                    ",DotChat=" + DotChat.ToString() +
                    ",DaChat=" + DotChat.ToString() +
                    ",DaIn=" + DotChat.ToString() +
                    ",DaCan=" + DotChat.ToString() +
                    ",NgayChat=" + DBModule.RefineDatetime(NgayChat) +
                     ",NgayChatDen=" + DBModule.RefineDatetime(NgayChatDen) +
                    ",NgayVanChuyen=" + DBModule.RefineDatetime(NgayVanChuyen) +
                    ",XeVanChuyenID=" + XeVanChuyenID.ToString() +
                    ",HDVanChuyenID=" + HDVanChuyenID.ToString() +
                    ",SoLuongChat=" + SoLuongChat.ToString() +
                      ",SoChuyen=" + SoChuyen.ToString() +
                    ",VutrongID=" + VuTrongID.ToString() +
                     ",Created=" + Created.ToString() +
                      ",Modifyed=" + Modifyed.ToString() +
                       "," + DBModule.RefineDatetime(NgayTaoPhieu) +
                     "," + DBModule.RefineDatetime(NgayInPhieu,true) +
                " Where ID = " + ID.ToString() + " ;exec Create_LenhVanChuyen " + ID.ToString() + ";";
            }
            // run SQL statement

            DBModule.ExecuteNonQuery(strSQL, cn, trans);
            /*
            if( ID <= 0 )
                ID = long.Parse(DBModule.ExecuteQueryGetOneResult("SELECT Max(ID) FROM tbl_XeVanChuyen", cn, trans));
                */
        }
        public void Delete(OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_LenhChatMia where Master_ID=" + ID.ToString();
            strSQL += "Delete from tbl_LenhChatMia_Master where ID=" + ID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        public static void Delete(long iID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Delete from tbl_LenhChatMia where Master_ID=" + iID.ToString();
            strSQL += "Delete from tbl_LenhChatMia_Master where ID=" + iID.ToString();
            // run SQL statement
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }
        private long NewID()
        {
            long ID = 0;
            string strSQL = "";
            // build SQL statement
            strSQL = "Select max(ID) as ID from tbl_LenhChatMia where VuTrongID=" + MDSolutionApp.VuTrongID;
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                {
                    ID = long.Parse(dr["ID"].ToString());
                }
                ID++;
            }
            return ID;
        }
        public static bool CheckSoLenh(long VuTrongID, string SL, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            // build SQL statement
            strSQL = "Select SoLenh from tbl_LenhChatMia_Master Where VuTrongID=" + MDSolutionApp.VuTrongID + " AND SoLenh=N'" + SL + "'";
            // run SQL statement
            string ret = DBModule.ExecuteQueryForOneResult(strSQL, cn, trans);
            if (string.IsNullOrEmpty(ret)) return true; else return false;
        }
        public static string GanSoLenh(long TramID, OleDbConnection cn, OleDbTransaction trans)
        {

            string SoLenh = "";

            string strSQL = "";
            // build SQL statement
            strSQL = "Select  max(CAST(SoLenh as int)) as SoLenh from tbl_LenhChatMia_Master where VuTrongID=" + MDSolutionApp.VuTrongID;
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);
            long tmp = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("SoLenh"))
                {
                    SoLenh = dr["SoLenh"].ToString();
                    tmp = long.Parse(SoLenh);
                }
                tmp++;
                //SoLenh = tmp.ToString("0000") + "-" +TramID.ToString("00");
                SoLenh = tmp.ToString("00000");
            }
            return SoLenh;
        }

        public void Load(OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select * from tbl_LenhChatMia where ID=" + ID.ToString();
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("SoLenh"))
                    SoLenh = dr["SoLenh"].ToString();
                if (!dr.IsNull("SoXe"))
                    SoXe = dr["SoXe"].ToString();
                if (!dr.IsNull("ThuaRuongID"))
                    ThuaRuongID = long.Parse(dr["ThuaRuongID"].ToString());
                if (!dr.IsNull("TramID"))
                    TramID = long.Parse(dr["TramID"].ToString());
                if (!dr.IsNull("XuDongID"))
                    XuDongID = long.Parse(dr["XuDongID"].ToString());
                if (!dr.IsNull("DaChat"))
                    DaChat = long.Parse(dr["DaChat"].ToString());
                if (!dr.IsNull("DaIn"))
                    DaIn = long.Parse(dr["DaIn"].ToString());
                if (!dr.IsNull("DaCan"))
                    DaCan = long.Parse(dr["DaCan"].ToString());
                if (!dr.IsNull("HopDongID"))
                    HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("NgayChat"))
                    NgayChat = DateTime.Parse(dr["NgayChat"].ToString());
                if (!dr.IsNull("NgayChatDen"))
                    NgayChatDen = DateTime.Parse(dr["NgayChatDen"].ToString());
                if (!dr.IsNull("NgayVanChuyen"))
                    NgayVanChuyen = DateTime.Parse(dr["NgayVanChuyen"].ToString());
                if (!dr.IsNull("HDVanChuyenID"))
                    HDVanChuyenID = long.Parse(dr["HDVanChuyenID"].ToString());
                if (!dr.IsNull("XeVanChuyenID"))
                    XeVanChuyenID = long.Parse(dr["XeVanChuyenID"].ToString());
                if (!dr.IsNull("SoLuongChat"))
                    SoLuongChat = float.Parse(dr["SoLuongChat"].ToString());
                if (!dr.IsNull("SoChuyen"))
                    SoChuyen = float.Parse(dr["SoChuyen"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("Created"))
                    Created = long.Parse(dr["Created"].ToString());
                if (!dr.IsNull("Modifyed"))
                    Modifyed = long.Parse(dr["Modifyed"].ToString());
                if (!dr.IsNull("NgayTaoPhieu"))
                    NgayTaoPhieu = DateTime.Parse(dr["NgayTaoPhieu"].ToString());
                if (!dr.IsNull("NgayInPhieu"))
                    NgayInPhieu = DateTime.Parse(dr["NgayInPhieu"].ToString());
            }
        }
        public void Load(string SoLenh, OleDbConnection cn, OleDbTransaction trans)
        {
            // build SQL statement
            string strSQL = "";
            strSQL = "Select top 1 * from tbl_LenhChatMia where SoLenh='" + SoLenh + "'";
            // run SQL statement
            DataSet ds = DBModule.ExecuteQuery(strSQL, cn, trans);

            // fill data into this object
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (!dr.IsNull("ID"))
                    ID = long.Parse(dr["ID"].ToString());
                if (!dr.IsNull("SoLenh"))
                    SoLenh = dr["SoLenh"].ToString();
                if (!dr.IsNull("SoXe"))
                    SoXe = dr["SoXe"].ToString();
                if (!dr.IsNull("ThuaRuongID"))
                    ThuaRuongID = long.Parse(dr["ThuaRuongID"].ToString());
                if (!dr.IsNull("TramID"))
                    TramID = long.Parse(dr["TramID"].ToString());
                if (!dr.IsNull("XuDongID"))
                    XuDongID = long.Parse(dr["XuDongID"].ToString());
                if (!dr.IsNull("DaChat"))
                    DaChat = long.Parse(dr["DaChat"].ToString());
                if (!dr.IsNull("DaCan"))
                    DaCan = long.Parse(dr["DaCan"].ToString());
                if (!dr.IsNull("DaIn"))
                    DaIn = long.Parse(dr["DaIn"].ToString());
                if (!dr.IsNull("HopDongID"))
                    HopDongID = long.Parse(dr["HopDongID"].ToString());
                if (!dr.IsNull("NgayChat"))
                    NgayChat = DateTime.Parse(dr["NgayChat"].ToString());
                if (!dr.IsNull("NgayVanChuyen"))
                    NgayVanChuyen = DateTime.Parse(dr["NgayVanChuyen"].ToString());
                if (!dr.IsNull("HDVanChuyenID"))
                    HDVanChuyenID = long.Parse(dr["HDVanChuyenID"].ToString());
                if (!dr.IsNull("XeVanChuyenID"))
                    XeVanChuyenID = long.Parse(dr["XeVanChuyenID"].ToString());
                if (!dr.IsNull("SoLuongChat"))
                    SoLuongChat = float.Parse(dr["SoLuongChat"].ToString());
                if (!dr.IsNull("VuTrongID"))
                    VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                if (!dr.IsNull("Created"))
                    Created = long.Parse(dr["Created"].ToString());
                if (!dr.IsNull("Modifyed"))
                    Modifyed = long.Parse(dr["Modifyed"].ToString());
                if (!dr.IsNull("NgayTaoPhieu"))
                    NgayTaoPhieu = DateTime.Parse(dr["NgayTaoPhieu"].ToString());
                if (!dr.IsNull("NgayInPhieu"))
                    NgayInPhieu = DateTime.Parse(dr["NgayInPhieu"].ToString());
            }
        }
        public static void GetList(string OrderBy, out DataSet ds, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            ds = null;
            // build SQL statement
            strSQL = "Select * from tbl_LenhChatMia WHERE VuTrongID=" + MDSolutionApp.VuTrongID;
            if ((OrderBy != null) && (OrderBy != ""))
                strSQL = strSQL + " Order By " + DBModule.RefineString(OrderBy);

            ds = DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        public static void ChangeDate(DateTime TuNgay, double SoNgay, long TramID, string ThuaRuongID, OleDbConnection cn, OleDbTransaction trans)
        {
            string strSQL = "";
            strSQL = "Update tbl_LenhChatMia SET NgayChat=DATEADD(day," + SoNgay.ToString() + ",NgayChat), NgayVanChuyen=DATEADD(day," + SoNgay.ToString() + ",NgayVanChuyen) " +
                " WHERE VuTrongID=" + MDSolutionApp.VuTrongID + " AND NgayChat>=" + DBModule.RefineDatetime(TuNgay);
            if (TramID > 0)
            {
                strSQL = strSQL + " AND TramID = " + TramID;
            }
            if (ThuaRuongID != "")
            {
                strSQL = strSQL + " AND ThuaRuongID = '" + ThuaRuongID + "'";
            }
            DBModule.ExecuteNonQuery(strSQL, cn, trans);
        }

        public static DataSet GetListbyWhere(string strFields, string strWhere, string strOrderBy, OleDbConnection cn, OleDbTransaction trans)
        {
            if (strFields == "") strFields = "*";
            string strSQL = "SELECT " + strFields + " FROM tbl_LenhChatMia WHERE VuTrongID=" + MDSolutionApp.VuTrongID;
            if (strWhere != "") strSQL += " AND " + strWhere;
            if (strOrderBy != "") strSQL += " Order By " + strOrderBy;
            return DBModule.ExecuteQuery(strSQL, cn, trans);
        }
        #endregion
    }
}