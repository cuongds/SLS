using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDReport.FRM_Report
{
    public partial class TongHopDauTuGianTiep : Form
    {
        public TongHopDauTuGianTiep()
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

                DataSet ds1 = new DataSet();
                clsDauTu.GetListLoaiVatTu("", out ds1, null, null);
                //clsDanhMucDT_DonViCU.GetListDonVi(ds1, null, null);              
                ComboDonVi.DataSource = ds1.Tables[0];
                ComboDonVi.DisplayMember = "ten";
                ComboDonVi.ValueMember = "id";
                DataSet dsCB = DBModule.ExecuteQuery("Select ID,Ten from tbl_DanhMucCanBoNongVu union select -1,N'Tất cả'", null, null);
                cboCanBoNV.DataSource = dsCB.Tables[0];
                cboCanBoNV.DisplayMember = "Ten";
                cboCanBoNV.ValueMember = "ID";

                DataSet dsUser = DBModule.ExecuteQuery("Select UserName,HoTen from dbo.sys_User union select '',N'Tất cả'", null, null);
                cboUser.DataSource = dsUser.Tables[0];
                cboUser.DisplayMember = "HoTen";
                cboUser.ValueMember = "UserName";

            }
            catch { }
            //load comboVutrong:

        }

        private void btXem_Click(object sender, EventArgs e)
        {
            //In báo cáo   
            if (uiComboBoxChonBC.SelectedIndex == -1)
            {
                labelLoi.Text = "Bạn phải chọn báo cáo";
            }
            else
            {
                if (cboCanBoNV.SelectedIndex < 0) cboCanBoNV.SelectedIndex = 0;
                if (cboUser.SelectedIndex < 0) cboUser.SelectedIndex = 0;
                labelLoi.Text = "";
                MDReport.Frm_ReportViewer frm = new Frm_ReportViewer();
                string[] paramNames = new string[] { "@VuTrongID", "@DanhMucDTID", "@TuNgay", "@DenNgay", "@CanBoNongVuID", "@UserName" };
                string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString(),ComboDonVi.SelectedValue.ToString() ,dtTuNgay.Value.ToString("yyyy-MM-dd"),dtDenNgay.Value.ToString("yyyy-MM-dd")+" 23:59:59",cboCanBoNV.SelectedValue.ToString(),cboUser.SelectedValue.ToString()

            };
                CommonClass.ShowReport(uiComboBoxChonBC.SelectedValue.ToString(), "", paramNames, paraValues, null);
            }

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiGroupBox1_Click(object sender, EventArgs e)
        {

        }


    }
}