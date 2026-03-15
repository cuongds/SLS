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
    public partial class SoChiTietCongNoTheoHo : Form
    {
        public SoChiTietCongNoTheoHo()
        {
            InitializeComponent();
        }

       

        private void btXem_Click(object sender, EventArgs e)
        {
            //In báo cáo   
            
            if (HopDongID == -1)
            {
                labelLoi.Text = "Bạn phải chọn hợp đồng";
            }
            else
            {
            labelLoi.Text = "";
            MDReport.Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paramNames = new string[] { "@VuTrongID", "@HopDongID","@TuNgay","@DenNgay" };
            string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString(),HopDongID.ToString(),dtTuNgay.Value.ToString("yyyy-MM-dd"),dtDenNgay.Value.ToString("yyyy-MM-dd")

            };
            CommonClass.ShowReport("\\ThanhToan2016\\rpt_SoChiTietCongNoTheoHo.rpt", "Chi tiết công nợ", paramNames, paraValues, null);
            }
          
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            HopDongID = -1;
            LoadHD(txtMaHD.Text);
        }
        private long HopDongID = -1;
        void LoadHD(string MaHD)
        {
            string sql = "select * from V2016_HopDongVuTrong where VuTrongID={0} and MaHopDong=N'{1}'";
            DataSet ds = DBModule.ExecuteQuery(string.Format(sql, MDSolutionApp.VuTrongID, MaHD), null, null);
            try
            {
                if (ds.Tables[0].Rows.Count == 1)
                {
                    DataRow dr = ds.Tables[0].Rows[0];

                    long.TryParse(dr["ID"].ToString(), out HopDongID);

                    txtTenHD.Text = dr["HoTen"].ToString();
                  
                }
                else
                {
                    HopDongID = -1;
                    txtTenHD.Text = "(Không tìm thấy hợp đồng)";
                  
                }
            }
            catch (Exception ex)
            {
                txtTenHD.Text = "(Không tìm thấy hợp đồng)";
              


            }
        }

        private void btnTimHD_Click(object sender, EventArgs e)
        {
            frmTimKiemHopDong frm = new frmTimKiemHopDong();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtMaHD.Text = frm.Ma_HD;
            }
        }

        private void SoChiTietCongNoTheoHo_Load(object sender, EventArgs e)
        {
            dtDenNgay.Value = DateTime.Now;
            dtTuNgay.Value = DateTime.Now.AddDays(-12 * 30);
            DataSet ds = new DataSet();
            clsVuTrong.GetList("", out ds, null, null);
            ComboVuTrong.DataSource = ds.Tables[0];
            ComboVuTrong.DisplayMember = "Ten";
            ComboVuTrong.ValueMember = "ID";
            ComboVuTrong.SelectedValue = MDSolutionApp.VuTrongID;
        }

       
    }
}