using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Windows.Forms;
using System.Collections;
using System.Drawing; 
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;

namespace MDSolution
{
    public class CommonClass
    {
        public static object DotTTSelected ;
        public static string FormatSqlNumber(string TienFomat)
        {

            NumberFormatInfo numberFormatInfo = Thread.CurrentThread.CurrentCulture.NumberFormat;
            return TienFomat.Replace(numberFormatInfo.NumberGroupSeparator, "").Replace(numberFormatInfo.NumberDecimalSeparator, ".");
        }
        public static void loadTreeDonVi(System.Windows.Forms.TreeView tv)
        {
            Font fnt = new Font("Arial", 12, FontStyle.Bold);
            TreeNode node, node1, node2,node3;
            node = tv.Nodes.Add("Root", "SLS");
            NodeDonVi RootNode = new NodeDonVi("0", "SLS", DonviType.Root);
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            node.ForeColor = Color.DarkGreen;
            node.NodeFont = fnt;
            node.Tag = RootNode; 
            node.ExpandAll();
            DataSet ds, ds1,ds2;
            string strSQL = "Select * from tbl_Cum order by Ten";
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                fnt = new Font("Arial", 11, FontStyle.Bold);
                node1 = node.Nodes.Add(dr["ID"].ToString(), dr["Ten"].ToString());
                node1.ForeColor = Color.DarkViolet;
                node1.NodeFont = fnt;
                node1.ImageIndex = 1;
                node1.SelectedImageIndex = 4;
                NodeDonVi nDonVi = new NodeDonVi(dr["ID"].ToString(), dr["Ten"].ToString(),DonviType.Tram);
                
                string strSQL1 = "Select * from tbl_Xa Where CumID=" + dr["ID"].ToString()+"Order by MaXa";
                ds1 = DBModule.ExecuteQuery(strSQL1, null, null);
                foreach (DataRow dr1 in ds1.Tables[0].Rows)
                {
                    fnt = new Font("Arial", 10, FontStyle.Bold);
                    node2 = node1.Nodes.Add(dr1["ID"].ToString(), dr1["Ten"].ToString());
                    node2.ForeColor = Color.DarkBlue;
                    node2.NodeFont = fnt;
                    node2.ImageIndex = 2;
                    node2.SelectedImageIndex = 5;
                    NodeDonVi nDonVi1 = new NodeDonVi(dr1["ID"].ToString(), dr1["Ten"].ToString(), DonviType.Xa);     
                    // them ban
                    string strSQL2 = "Select * from tbl_Thon Where XaID=" + dr1["ID"].ToString() + "Order by ID";
                    ds2 = DBModule.ExecuteQuery(strSQL2, null, null);
                    foreach (DataRow dr2 in ds2.Tables[0].Rows)
                    {
                        fnt = new Font("Arial", 9, FontStyle.Regular);
                        node3 = node2.Nodes.Add(dr2["ID"].ToString(), dr2["Ten"].ToString());
                        node3.ForeColor = Color.Red;
                        node3.NodeFont = fnt;
                        node3.ImageIndex = 2;
                        node3.SelectedImageIndex = 5;
                        NodeDonVi nDonVi2 = new NodeDonVi(dr2["ID"].ToString(), dr2["Ten"].ToString(), DonviType.Thon);
                        node3.Tag = nDonVi2;
                    }
                    // ban
                    node2.Tag = nDonVi1;                    
                }
                node1.Tag = nDonVi;
            }
        }

        public static void loadTreeDonVi(System.Windows.Forms.TreeView tv,string UserID) // su dung de load tree view theo tram
        {
            string strSQL = "Select CumID From sys_Roles_User_Cum Where UserID=" + UserID;
            DataSet ds2 = DBModule.ExecuteQuery(strSQL, null, null);
            string CumID = "";
             if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                        CumID += ds2.Tables[0].Rows[i]["CumID"].ToString();
                    else
                        CumID += "," + ds2.Tables[0].Rows[i]["CumID"].ToString();
                }
            }
            else
            {
                loadTreeDonVi(tv);
                return;
            }
           
            TreeNode node, node1, node2,node3;
            node = tv.Nodes.Add("Root", "Đơn Vị");
            NodeDonVi RootNode = new NodeDonVi("0", "Đơn Vị", DonviType.Root);
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            node.Tag = RootNode;
            node.ExpandAll();
            DataSet ds, ds1, ds3;            

            strSQL = "Select * from tbl_Cum Where ID in("+ CumID +") order by Ten";
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //fnt = new Font("Arial", 11, FontStyle.Regular);
                node1 = node.Nodes.Add(dr["ID"].ToString(), dr["Ten"].ToString());
                node1.ForeColor = Color.Purple;
                //node1.NodeFont = fnt;
                node1.ImageIndex = 1;
                node1.SelectedImageIndex = 4;
                NodeDonVi nDonVi = new NodeDonVi(dr["ID"].ToString(), dr["Ten"].ToString(), DonviType.Cum);

                string strSQL1 = "Select * from tbl_Xa Where CumID=" + dr["ID"].ToString() + "Order by MaXa";
                ds1 = DBModule.ExecuteQuery(strSQL1, null, null);
                foreach (DataRow dr1 in ds1.Tables[0].Rows)
                {
                   // fnt = new Font("Arial", 10, FontStyle.Regular);
                    node2 = node1.Nodes.Add(dr1["ID"].ToString(), dr1["Ten"].ToString());
                    node1.ForeColor = Color.Purple;
                   // node1.NodeFont = fnt;
                    node2.ImageIndex = 2;
                    node2.SelectedImageIndex = 5;
                    NodeDonVi nDonVi1 = new NodeDonVi(dr1["ID"].ToString(), dr1["Ten"].ToString(), DonviType.Xa);
                    // them ban
                    string strSQL2 = "Select * from tbl_thon Where XaID=" + dr1["ID"].ToString() + "Order by ID";
                    ds3 = DBModule.ExecuteQuery(strSQL2, null, null);
                    foreach (DataRow dr3 in ds3.Tables[0].Rows)
                    {
                        node3 = node1.Nodes.Add(dr3["ID"].ToString(), dr3["Ten"].ToString());
                        node3.ImageIndex = 2;
                        node3.SelectedImageIndex = 5;
                        NodeDonVi nDonVi2 = new NodeDonVi(dr3["ID"].ToString(), dr3["Ten"].ToString(), DonviType.Xa);
                        node3.Tag = nDonVi2;
                    }
                    node2.Tag = nDonVi1;
                }
                node1.Tag = nDonVi;
            }
        }

        public static void loadTreeHopDongVanChuyen(System.Windows.Forms.TreeView tv)
        {
            TreeNode node, node1;
            node = tv.Nodes.Add("Root", "Đơn Vị");
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            NodeHopDongVanChuyen RootNode = new NodeHopDongVanChuyen("0", "Đơn Vị", HDVCType.Root);
            node.Tag = RootNode;
            node.ExpandAll();
            DataSet ds;
            string strSQL = "Select ID, MaHopDong+' '+TenChuHopDong as Ten from tbl_HopDongVanChuyen order by ID";
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                node1 = node.Nodes.Add(dr["ID"].ToString(), dr["Ten"].ToString());
                node1.ImageIndex = 1;
                node1.SelectedImageIndex = 3;
                NodeHopDongVanChuyen nHD = new NodeHopDongVanChuyen(dr["ID"].ToString(), dr["Ten"].ToString(),HDVCType.HDVC);
                node1.Tag = nHD;
            }
        }
        public static void LoadTreeCBNV(System.Windows.Forms.TreeView tv)
        {
            Font fnt = new Font("Arial", 11, FontStyle.Bold);
            TreeNode node, node1;
            node = tv.Nodes.Add("Root", "Tất cả CBĐB");
            node.ForeColor = Color.DarkGreen;
            node.NodeFont = fnt;
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            NodeCanBoNongVu RootNode = new NodeCanBoNongVu("0", "Tất cả CBĐB", CBNVType.Root);
            node.Tag = RootNode;
            node.ExpandAll();
            DataSet ds;
            string strSQL = "Select ID, Ten from tbl_DanhMucCanBoNongVu Where   IsActive=1 order by ID";
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                node1 = node.Nodes.Add(dr["ID"].ToString(), dr["Ten"].ToString());
                fnt = new Font("Arial", 9, FontStyle.Regular);
                node1.ForeColor = Color.Purple;
                node1.NodeFont = fnt;
                node1.ImageIndex = 3;
                node1.SelectedImageIndex = 6;
                NodeCanBoNongVu nDonVi = new NodeCanBoNongVu(dr["ID"].ToString(), dr["Ten"].ToString(), CBNVType.CBNV);
                node1.Tag = nDonVi;
            }
            node.Tag = RootNode;
        }
        public static void loadTreeHopDongCanBoNongVu(System.Windows.Forms.TreeView tv)
        {
            Font fnt = new Font("Arial", 12, FontStyle.Bold);
            TreeNode node, node1,node2;
            node = tv.Nodes.Add("Root", "Tất cả CBNV");
            node.ForeColor = Color.DarkGreen;
            node.NodeFont = fnt;
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            NodeCanBoNongVu RootNode = new NodeCanBoNongVu("0", "Tất cả CBNV", CBNVType.Root);
            node.Tag = RootNode;
            node.ExpandAll();
            DataSet ds,ds1;
            string strSQL = "Select ID, Ten from tbl_DanhMucCanBoNongVu Where   IsActive=1 order by ID";
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                node1 = node.Nodes.Add(dr["ID"].ToString(), dr["Ten"].ToString());
                fnt = new Font("Arial", 11, FontStyle.Bold);
                node1.ForeColor = Color.Purple;
                node1.NodeFont = fnt;
                node1.ImageIndex = 1;
                node1.SelectedImageIndex = 1;
                NodeCanBoNongVu nDonVi = new NodeCanBoNongVu(dr["ID"].ToString(), dr["Ten"].ToString(), CBNVType.CBNV);
                string strSQL2 = "Select * from tbl_Thon Where CanBoNongVuID=" + dr["ID"].ToString() + "Order by ID";
                ds1 = DBModule.ExecuteQuery(strSQL2, null, null);
                foreach (DataRow dr1 in ds1.Tables[0].Rows)
                {
                    node2 = node1.Nodes.Add(dr1["ID"].ToString(), dr1["Ten"].ToString());
                    fnt = new Font("Arial", 10, FontStyle.Regular);
                    node2.ForeColor = Color.DarkBlue;
                    node2.NodeFont = fnt;
                    node2.ImageIndex = 2;
                    node2.SelectedImageIndex = 2;
                    NodeCanBoNongVu nDonVi1 = new NodeCanBoNongVu(dr1["ID"].ToString(), dr1["Ten"].ToString(), CBNVType.ThonID);
                    node2.Tag = nDonVi1;
                }
                node1.Tag = nDonVi;
                
            }
            node.Tag = RootNode;
        }
        public static void loadTreeNoiTamUngVatTu(System.Windows.Forms.TreeView tv)
        {
            TreeNode node, node1;
            node = tv.Nodes.Add("Root", "Đơn Vị");
            NodeNoiTamUngVatTu RootNode = new NodeNoiTamUngVatTu("0", "Đơn Vị");
            node.Tag = RootNode;
            node.ExpandAll();
            DataSet ds;
            string strSQL = "Select ID, Ten from tbl_NoiTamUngVatTu order by ID";
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                node1 = node.Nodes.Add(dr["ID"].ToString(), dr["Ten"].ToString());
                node1.ImageIndex = 0;
                //node1.SelectedImageIndex = 4;
                NodeNoiTamUngVatTu nHD = new NodeNoiTamUngVatTu(dr["ID"].ToString(), dr["Ten"].ToString());
                node1.Tag = nHD;
            }
        }
        //public static void LoadChildRen(System.Windows.Forms.TreeNode tn)
        //{
        //    if((tn!=null)&&(tn.Tag!=null))
        //    {
        //        NodeDonVi nDonVi = (NodeDonVi)tn.Tag;
        //        switch (nDonVi.Type)
        //        {
        //            case DonviType.Xa: CommonClass.LoadChildrenThon(tn, nDonVi);  break;;
        //            case DonviType.Thon: CommonClass.LoadChildrenHopDong(tn, nDonVi); break;
        //            default: break;
        //        }
        //        nDonVi.HasLoadChildren = true; 
        //        tn.Tag = nDonVi;
        //    } 
        //}
        public static void loadTreeXa(System.Windows.Forms.TreeView tv)
        {
            TreeNode node, node1;
            node = tv.Nodes.Add("Root", "Đơn Vị");
            NodeDonVi RootNode = new NodeDonVi("0", "Đơn Vị", DonviType.Root);
            node.Tag = RootNode;
            node.ExpandAll();
            DataSet ds ;
            string strSQL = "Select a.*,b.ThuTu from tbl_Xa as a LEFT JOIN tbl_Cum as b ON a.CumID = b.ID order by b.ThuTu, a.ID";
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                node1 = node.Nodes.Add(dr["ID"].ToString(), dr["Ten"].ToString());
                node1.ImageIndex = 1;
                node1.SelectedImageIndex = 4;
                NodeDonVi nDonVi = new NodeDonVi(dr["ID"].ToString(), dr["Ten"].ToString(), DonviType.Xa);                
                node1.Tag = nDonVi;
            }
        }

        public static void LoadTreeTram(System.Windows.Forms.TreeView treeView_)
        {
            TreeNode node, node1;
            node = treeView_.Nodes.Add("Root", "Đơn Vị");
            NodeDonVi rootNode = new NodeDonVi("0", "Đơn vị", DonviType.Root);
            node.Tag = rootNode;

            string strSQL = "Select * from tbl_Cum Order By Ten";
            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                node1 = node.Nodes.Add(dr["ID"].ToString(), dr["Ten"].ToString());
                node1.ImageIndex = 1;
                node1.SelectedImageIndex = 4;
                NodeDonVi nDonvi = new NodeDonVi(dr["ID"].ToString(), dr["Ten"].ToString(), DonviType.Cum);
                node1.Tag = nDonvi;
            }
        }
        public static  void LoadChildrenHopDong(System.Windows.Forms.TreeNode tn)
        {
            TreeNode node2;
            NodeDonVi nDonVi = (NodeDonVi)tn.Tag;
            string strSQL1 = "Select ID, MaHopDong+' '+HoTen as Ten from tbl_HopDong Where ThonID=" + nDonVi.DonViID;
            DataSet ds1 = DBModule.ExecuteQuery(strSQL1, null, null);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                Font fnt = new Font("Arial", 8, FontStyle.Regular);
                node2 = tn.Nodes.Add(dr1["ID"].ToString(), dr1["Ten"].ToString());
                node2.ForeColor = Color.Purple;
                node2.NodeFont = fnt;
                node2.ImageIndex = 3;
                node2.SelectedImageIndex = 6;
                NodeDonVi nDonVi1 = new NodeDonVi(dr1["ID"].ToString(), dr1["Ten"].ToString(), DonviType.ChuHopDong);
                node2.Tag = nDonVi1;
            }
        }
        public static void LoadChildrenThon(System.Windows.Forms.TreeNode tn)
        {
            TreeNode node2;
            NodeDonVi nDonVi = (NodeDonVi)tn.Tag;
            string strSQL1 = "Select * from tbl_Thon Where XaID=" + nDonVi.DonViID;
            DataSet ds1 = DBModule.ExecuteQuery(strSQL1, null, null);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                node2 = tn.Nodes.Add(dr1["ID"].ToString(), dr1["Ten"].ToString());
                node2.ImageIndex = 2;
                node2.SelectedImageIndex = 5;
                NodeDonVi nDonVi1 = new NodeDonVi(dr1["ID"].ToString(), dr1["Ten"].ToString(), DonviType.Thon);                
                node2.Tag = nDonVi1;
            }             
        }
        public static void LoadChildrenXe(System.Windows.Forms.TreeNode tn)
        {
            TreeNode node2;            
            NodeHopDongVanChuyen nHDVC = (NodeHopDongVanChuyen)tn.Tag;
            string strSQL1 = "Select ID, SoXe+' - '+TenLaiXe as Ten from tbl_XeVanChuyen Where HopDongVanChuyenID=" + nHDVC.HopDongID;
            DataSet ds1 = DBModule.ExecuteQuery(strSQL1, null, null);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                node2 = tn.Nodes.Add(dr1["ID"].ToString(), dr1["Ten"].ToString());
                node2.ImageIndex = 2;
                node2.SelectedImageIndex = 4;
                NodeHopDongVanChuyen nHDVC1= new NodeHopDongVanChuyen(dr1["ID"].ToString(), dr1["Ten"].ToString(), HDVCType.XeVC);
                node2.Tag = nHDVC1;
            }
        }
        static public void ShowReport(string rptFileName, string rptTitle, string[] paraNames, string[] paraValues, Form frmParent)
        {

            MDReport.Frm_ReportViewer frm = new MDSolution.MDReport.Frm_ReportViewer();
            frm.bHasPara = true;
            frm.ParaNames = paraNames;
            frm.ParaValues = paraValues;
            frm.rptFileName = rptFileName;
            frm.rptTitle = rptTitle;
            if (frmParent != null)
            {
                frm.MdiParent = frmParent;
            }
            frm.Show();
        }
        static public void KhoiTaoReport(string rptFileName, string rptTitle, string[] paraNames, string[] paraValues, Form frmParent)
        {

            MDReport.Frm_ReportViewer frm = new MDSolution.MDReport.Frm_ReportViewer();
            frm.bHasPara = true;
            frm.ParaNames = paraNames;
            frm.ParaValues = paraValues;
            frm.rptFileName = rptFileName;
            frm.rptTitle = rptTitle;
            if (frmParent != null)
            {
                frm.MdiParent = frmParent;
            }
            frm.Show();
            frm.Close();
        }
        static public DataSet ExecuteSP(string spName, string[] spParaName, string[] spParaValue)
        {
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbConnection cn = new OleDbConnection(DBModule.strConnString);
            OleDbCommand myCom = new OleDbCommand(spName, cn);
            myCom.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < spParaName.Length; i++)
            {
                myCom.Parameters.Add(spParaName[i], spParaValue[i]);
            }

            da.SelectCommand = myCom;
            da.Fill(ds);
            cn.Close();
            cn = null;
            return ds;
        }
        public static string getServerTime()
        {
            string sql = "";
            sql = "Select GetDate()";
            string TG = DBModule.ExecuteQueryForOneResult(sql, null, null).ToString();
            return TG;
        }
        static public void ShowReportWithDataSet(string rptFileName, string rptTitle, string[] paraNames, object[] paraValues, DataSet ds)
        {

            MDReport.Frm_ReportViewer frm = new MDSolution.MDReport.Frm_ReportViewer();
            frm.bHasPara = true;
            frm.ParaNames = paraNames;
            frm.ParaValues = paraValues;
            frm.rptFileName = rptFileName;
            frm.rptTitle = rptTitle;
            frm.ds = ds;
            frm.Show();
        }
    }
}
