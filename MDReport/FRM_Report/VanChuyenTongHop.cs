using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDReport.FRM_Report
{
    public partial class VanChuyenTongHop : Form
    {
        public VanChuyenTongHop()
        {
            InitializeComponent();
        }

        private void TongHopDienTichHuyen_Load(object sender, EventArgs e)
        {
            //load comboVutrong:
            try
            {
                DataSet ds = new DataSet();
                clsVuTrong.GetList("", out ds, null, null);
                ComboVuTrong.DataSource = ds.Tables[0];
                ComboVuTrong.DisplayMember = "Ten";
                ComboVuTrong.ValueMember = "ID";
                ComboVuTrong.SelectedValue = MDSolutionApp.VuTrongID;
                //


            }
            catch { }
            //load comboVutrong:

        }

        private void btXem_Click(object sender, EventArgs e)
        {
            //In báo cáo   
            if (uiComboBoxChonBC.SelectedIndex == -1)
            {
                labelLoi.Text = "Bạn phải chọn báo cáo để xem/in";
            }
            else
            {
                labelLoi.Text = "";
                MDReport.Frm_ReportViewer frm = new Frm_ReportViewer();
                string[] paramNames = new string[] { "@VuTrongID", "@TuNgay", "@DenNgay" };
                string[] paraValues = new string[] { MDSolutionApp.VuTrongID.ToString(), dtTuNgay.Value.ToString("yyyy-MM-dd"), dtDenNgay.Value.ToString("yyyy-MM-dd") + " 23:59:59" };
                CommonClass.ShowReport(uiComboBoxChonBC.SelectedValue.ToString(), "Báo cáo vận chuyển", paramNames, paraValues, null);
            }

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}