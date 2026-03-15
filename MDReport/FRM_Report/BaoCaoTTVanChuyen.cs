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
    public partial class BaoCaoTTVanChuyen : Form
    {
        public BaoCaoTTVanChuyen()
        {
            InitializeComponent();
        }



        private void btXem_Click(object sender, EventArgs e)
        {
            //In báo cáo   

            if (uiComboBoxChonBC.SelectedIndex < 0)
            {
                labelLoi.Text = "Bạn phải chọn báo cáo.";
            }
            else
            {
                labelLoi.Text = "";
                MDReport.Frm_ReportViewer frm = new Frm_ReportViewer();
                string[] paramNames = new string[] { "@VuTrongID", "@TuNgay", "@DenNgay" };
                string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString(),dtTuNgay.Value.ToString("yyyy-MM-dd"),dtDenNgay.Value.ToString("yyyy-MM-dd") };
                CommonClass.ShowReport(uiComboBoxChonBC.SelectedValue.ToString(), uiComboBoxChonBC.Text, paramNames, paraValues, null);
            }

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void BaoCaoTTVanChuyen_Load(object sender, EventArgs e)
        {
            dtDenNgay.Value = DateTime.Now;
            dtTuNgay.Value = DateTime.Now.AddDays(-12 * 30);
            DataSet ds = new DataSet();
            clsVuTrong.GetList("", out ds, null, null);
            ComboVuTrong.DataSource = ds.Tables[0];
            ComboVuTrong.DisplayMember = "Ten";
            ComboVuTrong.ValueMember = "ID";
            ComboVuTrong.SelectedValue = MDSolutionApp.VuTrongID;

            //DataSet dsCB = DBModule.ExecuteQuery("Select * from tbl_DanhMucCanBoNongVu", null, null);
            //cboCanBoNV.DataSource = dsCB.Tables[0];
            //cboCanBoNV.DisplayMember = "Ten";
            //cboCanBoNV.ValueMember = "ID";
        }


    }
}