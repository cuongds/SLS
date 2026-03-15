using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using MDSolution.MDForms;
using MDSolution.MDReport;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.SCREventLog;
using CrystalDecisions.Shared;


namespace MDSolution
{
    public partial class frmThanhToanVanChuyen : Form
    {
        long TienChu;
        private NodeHopDongVanChuyen nHDVC;//= new NodeHopDongVanChuyen();
        private clsHopDongVanChuyen oHDVC = new clsHopDongVanChuyen();
        private string strid = "";
        private bool isxe;
        public frmThanhToanVanChuyen()
        {
            InitializeComponent();
            // loadHDVC("0");
            //this.CreateGridEX2ThuaRuongColumn();          
            //CommonClass.loadTreeHopDongVanChuyen(treeDonVi);
        }
        public frmThanhToanVanChuyen(string HopDongVCID)
        {
            InitializeComponent();
            // CommonClass.loadTreeHopDongVanChuyen(treeDonVi);

            //            DoLoadUngVatTuInFo_Xe(HopDongVCID);
        }
        void loadHDVC(string DotTT)
        {
            string DotTT2 = "";
            GHDVC.SetDataBinding(null, "");
            gdvChitiettamung.SetDataBinding(null, "");
            gdvChitietvanchuyen.SetDataBinding(null, "");
            gdvChiTienUng.SetDataBinding(null, "");
            if (DotTT != "0") DotTT2 = DotTT;
            string strWhere = "(ID in(select HopDongVanChuyenID from tbl_nhapmia where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() +
                " and DaThanhToan=" + DotTT + ") or ID in(select HopDongVanChuyenID from tbl_ungvattuvanchuyen where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() +
                "and DaThanhToan='" + DotTT2 + "'))";
            GHDVC.SetDataBinding(clsHopDongVanChuyen.GetListbyWhere2("", strWhere, "", null, null).Tables[0], "");


        }
        private void treeDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                // this.LoadChildrenNode(treeDonVi.SelectedNode);
            }
        }

        private void treeDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.LoadChildrenNode(e.Node);
        }
        private void LoadChildrenNode(TreeNode tn)
        {
            nHDVC = (NodeHopDongVanChuyen)tn.Tag;
            if (nHDVC.HopDongType == HDVCType.HDVC)
            {
                this.DoLoadUngVatTuInFo(nHDVC.HopDongID, "");
                //loadCbDotTT(nHDVC.HopDongID);
                //Load ra thong tin tam ung va van chuyen cua tat ca cac xe
                //if (!nHDVC.HasLoadChildren)
                //{
                //    CommonClass.LoadChildrenXe(tn);
                //    nHDVC.HasLoadChildren = true;
                //    tn.Tag = nHDVC;
                //}
            }
            //if (nHDVC.HopDongType == HDVCType.XeVC)
            //{
            //    //Load ra thong tin chi tiet tam ung cua tung xe
            //    //this.DoLoadHopDongInFo(nDonVi.DonViID);
            //    this.DoLoadUngVatTuInFo_Xe(nHDVC.HopDongID);
            //}
        }
        private void DoLoadgdvChiTiettamung(string strID, bool is1Xe, string DotTT)
        {//DotTT=""=> Chua Thanh toan
            try
            {
                DataSet ds;
                //string DotTT = "";
                if (DotTT == "0") DotTT = "";
                string strSQL = "";
                if (is1Xe)
                {
                    strSQL = "SELECT * FROM V_UngVatTuVanChuyen WHERE DaThanhToan ='" + DotTT + "' AND XeID = " + strID + " AND VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
                }
                else
                {
                    strSQL = "SELECT * FROM V_UngVatTuVanChuyen WHERE DaThanhToan ='" + DotTT + "' AND HopDongVanChuyenID = " + strID + " AND VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
                }
                ds = DBModule.ExecuteQuery(strSQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.gdvChitiettamung.SetDataBinding(ds.Tables[0], "");
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi load danh sách tạm ứng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DoLoadgdvChiTietvanchuyen(string strID, bool is1Xe, string DotTT)
        {//DotTT=0=>Chua thanh toan
            try
            {
                strid = strID;
                isxe = is1Xe;
                DataSet ds;
                string strSQL = "";
                if (is1Xe)
                {
                    strSQL = "SELECT * FROM V_VanChuyenMia WHERE  DaThanhToanVC =" + DotTT + " AND  XeID = " + strID + " AND VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
                }
                else
                {
                    strSQL = "SELECT * FROM V_VanChuyenMia WHERE  DaThanhToanVC =" + DotTT + " AND  HopDongVanChuyenID = " + strID + " AND VuTrongID =" + MDSolutionApp.VuTrongID.ToString();
                }

                ds = DBModule.ExecuteQuery(strSQL, null, null);
                //if (ds.Tables[0].Rows.Count > 0)
                {
                    int i = ds.Tables[0].Rows.Count;
                    this.gdvChitietvanchuyen.SetDataBinding(ds.Tables[0], "");
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi load danh sách vận chuyển mía", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // load HoanUng
        private void DoLoadgdvChiTienUng(string strID, bool is1Xe, string DotTT)
        {//DotTT=0=>Chua thanh toan
            try
            {
                strid = strID;
                isxe = is1Xe;
                DataSet ds;
                string strSQL = "";
                if (is1Xe)
                {
                    strSQL = "SELECT tbl_HoanUngVanChuyen.*, dbo.sys_User.HoTen AS NguoiNhap FROM     dbo.tbl_HoanUngVanChuyen INNER JOIN dbo.sys_User ON dbo.tbl_HoanUngVanChuyen.CreatedBy = dbo.sys_User.ID WHERE   XeID = " + strID + " AND VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
                }
                else
                {
                    strSQL = "SELECT tbl_HoanUngVanChuyen.*, dbo.sys_User.HoTen AS NguoiNhap FROM     dbo.tbl_HoanUngVanChuyen INNER JOIN dbo.sys_User ON dbo.tbl_HoanUngVanChuyen.CreatedBy = dbo.sys_User.ID WHERE   HopDongVanChuyenID = " + strID + " AND VuTrongID =" + MDSolutionApp.VuTrongID.ToString();
                }

                ds = DBModule.ExecuteQuery(strSQL, null, null);
                {
                    int i = ds.Tables[0].Rows.Count;
                    if (i > 0)
                    {
                        this.gdvChiTienUng.SetDataBinding(ds.Tables[0], "");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi load danh sách hoàn ứng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DoLoadUngVatTuInFo(string HopDongVCID, string DotTT)
        {
            try
            {
                this.oHDVC.ID = long.Parse(HopDongVCID);
                this.oHDVC.Load(null, null);
                this.lblChuHopDong.Text = oHDVC.MaHopDong + " - " + oHDVC.TenChuHopDong;
                this.DoLoadgdvChiTiettamung(HopDongVCID, false, DotTT);
                if (DotTT == "") DotTT = "0";
                this.DoLoadgdvChiTietvanchuyen(HopDongVCID, false, DotTT);
                this.DoLoadgdvChiTienUng(HopDongVCID, false, "");
                GridEXRow gexr = this.gdvChitiettamung.GetTotalRow();
                GridEXRow gexr1 = this.gdvChitietvanchuyen.GetTotalRow();
                GridEXRow gexr2 = this.gdvChiTienUng.GetTotalRow();
                long vSotienvanchuyen = 0;
                long vSotientamung = 0;
                long vSotienhoanung = 0;
                if (gexr1 != null && !string.IsNullOrEmpty(gexr1.Cells["SoTienVC"].Value.ToString()))
                    vSotienvanchuyen = long.Parse(gexr1.Cells["SoTienVC"].Value.ToString());
                if (gexr != null && !string.IsNullOrEmpty(gexr.Cells["SoTienTinh"].Value.ToString()))
                    vSotientamung = long.Parse(gexr.Cells["SoTienTinh"].Value.ToString());
                if (gexr2 != null && !string.IsNullOrEmpty(gexr2.Cells["SoTien"].Value.ToString()))
                    vSotienhoanung = long.Parse(gexr2.Cells["SoTien"].Value.ToString());

                long vSotiendu = vSotienvanchuyen - vSotientamung - vSotienhoanung;
                editBoxTamung.Text = vSotientamung.ToString("### ### ### ##0");
                editBoxVanchuyen.Text = vSotienvanchuyen.ToString("### ### ### ##0");
                editBoxTiendu.Text = vSotiendu.ToString("### ### ### ##0");
                editBoxHoanUng.Text = vSotienhoanung.ToString("### ### ### ##0");
                TienChu = vSotiendu;

                this.uibInThanhToan.Enabled = true;
            }
            catch
            {

                this.uibInThanhToan.Enabled = false;

                MessageBox.Show("Có lỗi khi lấy thông tin chủ hợp đồng", "Lỗi", MessageBoxButtons.OK);
            }

        }

        /*Khong Dung voi xe VC
        private void DoLoadUngVatTuInFo_Xe(string XeID)
        {
            try
            {
                clsXeVanChuyen oXe = new clsXeVanChuyen(long.Parse(XeID));
                oXe.Load(null, null);
                this.lblChuHopDong.Text = oXe.SoXe + " - " + oXe.TenLaiXe;
                this.DoLoadgdvChiTiettamung(XeID, true);
                this.DoLoadgdvChiTietvanchuyen(XeID, true);
                //this.DoloadSoxevanchuyen(HopDongVCID);
                //GridEXRow gEXR = this.gdvChitiettamung.GetTotalRow();
                GridEXRow gexr = this.gdvChitiettamung.GetTotalRow();
                GridEXRow gexr1 = this.gdvChitietvanchuyen.GetTotalRow();
                long vSotienvanchuyen = 0;
                long vSotientamung = 0;
                if (gexr1 != null && !string.IsNullOrEmpty(gexr1.Cells["SoTienVC"].Value.ToString()))
                    vSotienvanchuyen = long.Parse(gexr1.Cells["SoTienVC"].Value.ToString());
                if (gexr != null && !string.IsNullOrEmpty(gexr.Cells["SoTienTinh"].Value.ToString()))
                    vSotientamung = long.Parse(gexr.Cells["SoTienTinh"].Value.ToString());
                long vSotiendu = vSotienvanchuyen - vSotientamung;
                editBoxTamung.Text = vSotientamung.ToString("### ### ### ##0");
                editBoxVanchuyen.Text = vSotienvanchuyen.ToString("### ### ### ##0");
                editBoxTiendu.Text = vSotiendu.ToString("### ### ### ##0");                
                
                this.uibInThanhToan.Enabled = true;
              

            }
            catch
            {
                
                MessageBox.Show("Có lỗi khi lấy về xe", "Lỗi", MessageBoxButtons.OK);
            }

        }
     
        */

        public void GetHopDongID(string value)
        {
            //oHD.ID = long.Parse(value);
            //DoLoadHopDongInFo(oHD.ThonID.ToString());
            oHDVC.ID = long.Parse(value);
        }

        private void uiTinhlaidautu_Click(object sender, EventArgs e)
        {

        }

        private void uiPanel5Container_Click(object sender, EventArgs e)
        {

        }



        private void gdvChitiettamung_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }

        private void uibNhaptientamung_Click(object sender, EventArgs e)
        {
            try
            {
                frmTamUngVatTu frm = new frmTamUngVatTu();
                frm.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void uibInPhieuChi_Click(object sender, EventArgs e)
        {

        }

        private void uibInThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                string[] paramNames = new string[] { "@HopDongVCID", "@VuTrongID", "@DotTT" };
                string[] paraValues = new string[] { GHDVC.GetValue("ID").ToString(), MDSolutionApp.VuTrongID.ToString(), DotTT };
                CommonClass.ShowReport("vanchuyen\\RP_T_ThanhToanVC.rpt", "", paramNames, paraValues, null);
                //frmShowRP2 frm = new frmShowRP2();
                //rpt_MoiThanhToanChuHopDongVanChuyen rp = new rpt_MoiThanhToanChuHopDongVanChuyen();
                //if (isxe)
                //{
                //    rp.RecordSelectionFormula = "{MoiThanhToanChuHopDongVanChuyen.XeID}=" + strid.ToString() + " AND {MoiThanhToanChuHopDongVanChuyen.VuTrongID }=" + MDSolutionApp.VuTrongID;
                //}
                //else
                //{
                //    rp.RecordSelectionFormula = "{MoiThanhToanChuHopDongVanChuyen.HopDongVanChuyenID}=" + strid.ToString() + " AND {MoiThanhToanChuHopDongVanChuyen.VuTrongID }=" + MDSolutionApp.VuTrongID;
                //}
                //string abc = rp.RecordSelectionFormula;
                //frm.RP = rp;
                //frm.TongTien = TienChu;
                ////frm.VuTrongIDName = "{MoiThanhToanChuHopDongVanChuyen.VuTrongID}";
                //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                //frm.RPtitle = "Thanh toán chủ hợp đồng vận chuyển";               
                //frm.Show();

            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
            }


        }



        private void frmThanhToanVanChuyen_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            loadCbDotTT();
            try
            {
                loadHDVC(CbDotTT.Text);
            }
            catch { }
        }


        void loadCbDotTT()
        {
            try
            {
                string sql = "sp_GetDotTTVC " + MDSolutionApp.VuTrongID.ToString();
                CbDotTT.DataSource = DBModule.ExecuteQuery(sql, null, null).Tables[0];
                CbDotTT.DisplayMember = "DotTT";
                CbDotTT.ValueMember = "Ngay";
                try
                {
                    CbDotTT.SelectedIndex = CbDotTT.Items.Count - 1;
                }
                catch { }
            }
            catch
            {
                CbDotTT.Items.Clear();
            }
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            //foreach (GridEXRow jr in this.GHDVC.GetDataRows())
            //{
            //    MessageBox.Show(jr.Cells["ID"].Value.ToString());
            try
            {

                string MaxDotTT = "Select isnull(max(DotTT),0)+1 from tbl_DotTTVanChuyen where VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
                MaxDotTT = DBModule.ExecuteQueryForOneResult(MaxDotTT, null, null);
                if (MaxDotTT == "") MaxDotTT = "1";
                if (MessageBox.Show("Bạn muốn xác nhận thanh toán đợt " + MaxDotTT + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                string sql = "sp_XacNhanTTVC " + MDSolutionApp.VuTrongID.ToString() +
                    "," + MaxDotTT + ",'" + dtNgayTT.Value.ToString("yyy-MM-dd") + "'";
                DBModule.ExecuteNoneBackup(sql, null, null);
                MessageBox.Show("Đã xác nhận thành công đợt " + MaxDotTT, "Thông báo thành công");
                loadCbDotTT();
                btThanhToan.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Lỗi khi làm thành toán", "Lỗi");
            }
            //}

        }

        private void btHuyTT_Click(object sender, EventArgs e)
        {

        }

        private void cmdHuyTT_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn muốn hủy thanh toán đợt " + CbDotTT.Text + "này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                string sql = "sp_HuyTTVC " + MDSolutionApp.VuTrongID.ToString() +
                    "," + CbDotTT.Text;// +",'" + dtNgayTT.Value.ToString("yyy-MM-dd") + "'";
                DBModule.ExecuteNoneBackup(sql, null, null);
                MessageBox.Show("Đã hủy thành công đợt " + CbDotTT.Text, "Thông báo thành công");
                CbDotTT.Text = "";
                loadCbDotTT();
                GHDVC.SetDataBinding(null, "");
                gdvChitiettamung.SetDataBinding(null, "");
                gdvChitietvanchuyen.SetDataBinding(null, "");
                //CbDotTT.DataSource = null;
            }
            catch
            {
                MessageBox.Show("Lỗi khi hủy thành toán", "Lỗi");
            }
        }

        private void CbDotTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GHDVC.SetDataBinding(null, "");
                dtNgayTT.Text = CbDotTT.SelectedValue.ToString();
                loadHDVC(CbDotTT.Text);
                lbTitleTable.Text = "Đợt " + CbDotTT.Text + " ngày " + dtNgayTT.Text;
                DotTT = CbDotTT.Text;
            }
            catch { }
        }

        private void cmdLamTTMoi_Click(object sender, EventArgs e)
        {
            DotTT = "0";
            loadHDVC("0");
            lbTitleTable.Text = "Làm thanh toán mới";
            if (GHDVC.GetRows().Length > 0)
            {
                btThanhToan.Enabled = true;
            }
            else
            {
                MessageBox.Show("Không có hợp đồng nào có khả năng thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btThanhToan.Enabled = false;
            }
        }
        string DotTT = "0";
        private void GHDVC_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void GHDVC_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }

        private void GHDVC_Click(object sender, EventArgs e)
        {
            if (GHDVC.GetRows().Length > 0)
                try
                {
                    DoLoadUngVatTuInFo(GHDVC.GetValue("ID").ToString(), DotTT);
                }
                catch { }
        }

        private void btHoanUng_Click(object sender, EventArgs e)
        {
            if (GHDVC.GetRows().Length > 0)
            {
                try
                {
                    int IDHopDong = int.Parse(GHDVC.GetValue("ID").ToString());
                    if (IDHopDong > 0)
                    {
                        frm_NhapHoanUngVC frm = new frm_NhapHoanUngVC(IDHopDong, true);
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Bạn chư chọn hợp đồng");
                    }
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn hợp đồng hoàn ứng.");
            }

        }

        private void gdvChiTienUng_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (MDSolutionApp.User.ID == 1 || MDSolutionApp.User.ID == 83067)
            {
                int HoanUngID = int.Parse(gdvChiTienUng.GetValue("ID").ToString());
                try
                {
                    clsHoanUngVanChuyen objXoa = new clsHoanUngVanChuyen(HoanUngID);
                    objXoa.Load(null, null);
                    objXoa.Delete(null, null);
                    MessageBox.Show("Xóa thành công");
                    this.Refresh();
                }
                catch
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
            else
            {
                MessageBox.Show("Không có quyền xóa");
            }

        }
    }
}