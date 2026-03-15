using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDReport.FRM_Report
{
    public partial class BieuHoTroTheCBNV : Form
    {
        public BieuHoTroTheCBNV()
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

                // CBNV
                DataSet dsCB = DBModule.ExecuteQuery("Select ID,Ten from tbl_DanhMucCanBoNongVu", null, null);
                cboCanBoNV.DataSource = dsCB.Tables[0];
                cboCanBoNV.DisplayMember = "Ten";
                cboCanBoNV.ValueMember = "ID";
                //cboCanBoNV.SelectedValue =


            }
            catch { }
            //load comboVutrong:
            
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            //In báo cáo   
            if (cboCanBoNV.SelectedIndex < 0)
            {
                cboCanBoNV.SelectedValue = -1;
            }
            //if (uiComboBoxChonBC.SelectedIndex==-1)
            //{
            //    labelLoi.Text = "Bạn phải chọn báo cáo"; 
            //}
            //else{
            //    labelLoi.Text = "";
            MDReport.Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paramNames = new string[] { "@VuTrongID","@CBNVID"};
            string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString(), cboCanBoNV.SelectedValue.ToString()};
            CommonClass.ShowReport("TienChinhSach\\BaoCao_DoiTru_HoTro.rpt", "", paramNames, paraValues, null);


//            CommonClass.ShowReport(uiComboBoxChonBC.SelectedValue.ToString(), "", paramNames, paraValues, null);


            //string CBNVID = cboCBNV.SelectedValue.ToString();
            //MDReport.Frm_ReportViewer frm = new MDReport.Frm_ReportViewer();
            //string[] paramNames = new string[] { "@CBNVID", "@VuTrongID" };
            //string[] paraValues = new string[] { CBNVID, MDSolutionApp.VuTrongID.ToString() };
            //CommonClass.ShowReport("TienChinhSach\\InTongHopHoTro.rpt", "Phiếu đối trừ đầu tư", paramNames, paraValues, null);

            //}
          
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}