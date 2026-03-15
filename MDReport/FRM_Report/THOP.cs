using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDReport.FRM_Report
{
    public partial class THOP : Form
    {
        public THOP()
        {
            InitializeComponent();
        }

        private void THOP_Load(object sender, EventArgs e)
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

            }
            catch { }
            //load comboVutrong:
            
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            //In báo cáo   
            if (cboBaoCaoDienTich.SelectedIndex==-1)
            {
                labelLoi.Text = "Bạn phải chọn báo cáo";
            }
            else if (cboBaoCaoDienTich.SelectedIndex == 10)//Báo cáo diện tích theo CBĐB
            {
                //string sql = "sp_RP_HopDongDienTichTrong NULL," + ComboVuTrong.SelectedValue.ToString() + ",NULL";
                //DataSet ds = DBModule.ExecuteQuery(sql, null, null);
                //MDSolution.MDForms.frmShowRP2 frm = new MDSolution.MDForms.frmShowRP2();
                //MDSolution.MDReport.DienTich.BaoCaoDienTich_CBDB rp = new MDSolution.MDReport.DienTich.BaoCaoDienTich_CBDB();
                //rp.SetDataSource(ds.Tables[0]);
                //frm.RP = rp;
                //frm.Show();
                long VTID = long.Parse(ComboVuTrong.SelectedValue.ToString());
                MDForms.DienTich.frm_BaoCaoDienTich_CBDB frm = new MDForms.DienTich.frm_BaoCaoDienTich_CBDB(VTID);
                frm.Show();
             }
            else
            {
                labelLoi.Text = "";
                MDReport.Frm_ReportViewer frm = new Frm_ReportViewer();
                string[] paramNames = new string[] { "@VuTrongID" };
                string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString() };
                CommonClass.ShowReport(cboBaoCaoDienTich.SelectedValue.ToString(), "", paramNames, paraValues, null);
            }
          
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
       
    }
}