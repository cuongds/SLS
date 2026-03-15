using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolution.MDForms.ThanhToan2016;

namespace MDSolution.MDReport.FRM_Report
{
    public partial class BangKeThanhTTMia_TheoCanBoDiaBan : Form
    {
        public BangKeThanhTTMia_TheoCanBoDiaBan()
        {
            InitializeComponent();
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            //In báo cáo   
            if (cboCanBoNV.SelectedIndex < 0)
            {
                cboCanBoNV.SelectedValue = -1;
            }
            if (uiComboBoxChonBC.SelectedIndex < 0)
            {

                labelLoi.Text = "Bạn phải chọn báo cáo cần xem.";
            }
            else
            {
                labelLoi.Text = "";
                if (uiComboBoxChonBC.SelectedValue.ToString() == "Frm_BangKeThanhToanMia")
                {
                    MDForms.ThanhToan2016.TongHopThanhToan frm = new MDForms.ThanhToan2016.TongHopThanhToan();
                    string strWhere = "  VuTrongID=" + ComboVuTrong.SelectedValue.ToString();
                    if (!this.dtTuNgay.IsNullDate) strWhere += " AND   NgayThanhToan>= '" + dtTuNgay.Value.ToString("yyyy-MM-dd") + " 00:00:00 '"; //DBModule.RefineDatetime(this.dtTuNgay.Value);
                    if (!this.dtDenNgay.IsNullDate) strWhere += " AND  NgayThanhToan<= '" + dtDenNgay.Value.ToString("yyyy-MM-dd") + " 23:59:59'";//DBModule.RefineDatetime(this.dtDenNgay.Value);
                    if (cboCanBoNV.SelectedValue.ToString() != "-1") strWhere += " AND  CanBoNVID=" + cboCanBoNV.SelectedValue.ToString();
                    frm.strWhere = strWhere;
                    frm.LoadData();
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                }
                else
                {
                    MDReport.Frm_ReportViewer frm = new Frm_ReportViewer();
                    string[] paramNames = new string[] { "@VuTrongID", "@CanBoNongVuID", "@TuNgay", "@DenNgay", "@UserName", "@isMiaGiong" };
                    string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString(), cboCanBoNV.SelectedValue.ToString(), dtTuNgay.Value.ToString("yyyy-MM-dd") + " 00:00:00", dtDenNgay.Value.ToString("yyyy-MM-dd") + " 23:59:59", cboUser.SelectedValue.ToString(), (rdMiaGiong.Checked ? "1" : "0") };
                    CommonClass.ShowReport(uiComboBoxChonBC.SelectedValue.ToString(), uiComboBoxChonBC.Text, paramNames, paraValues, null);
                }
            }

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void BangKeThanhTTMia_TheoCanBoDiaBan_Load(object sender, EventArgs e)
        {
            dtDenNgay.Value = DateTime.Now;
            dtTuNgay.Value = DateTime.Now.AddDays(-12 * 30);
            DataSet ds = new DataSet();
            clsVuTrong.GetList("", out ds, null, null);
            ComboVuTrong.DataSource = ds.Tables[0];
            ComboVuTrong.DisplayMember = "Ten";
            ComboVuTrong.ValueMember = "ID";
            ComboVuTrong.SelectedValue = MDSolutionApp.VuTrongID;

            DataSet dsCB = DBModule.ExecuteQuery("Select ID,Ten from tbl_DanhMucCanBoNongVu union select -1,N'Tất cả'", null, null);
            cboCanBoNV.DataSource = dsCB.Tables[0];
            cboCanBoNV.DisplayMember = "Ten";
            cboCanBoNV.ValueMember = "ID";
            DataSet dsUser = DBModule.ExecuteQuery("Select UserName,HoTen from dbo.sys_User union select '',N'Tất cả'", null, null);
            cboUser.DataSource = dsUser.Tables[0];
            cboUser.DisplayMember = "HoTen";
            cboUser.ValueMember = "UserName";
            cboUser.SelectedIndex = 0;
        }

        private void uiComboBoxChonBC_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboUser.Enabled = uiComboBoxChonBC.SelectedValue.ToString().Contains("RPT_BangKeThanhToanMia.rpt");
            pnLoaiMia.Enabled = uiComboBoxChonBC.SelectedIndex > 1;
        }


    }
}