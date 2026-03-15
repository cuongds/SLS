using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;


namespace MDSolution.MDReport.DakNongReport
{
    public partial class InPhieuBaoDon : Form
    {
        public InPhieuBaoDon()
        {
            InitializeComponent();
        }

        private void btnXemBC_Click(object sender, EventArgs e)
        {           
            try
            {
                DataSet ds = null;
               // clsThuaRuong.UpdateKeHoach("", null, null);
                string sql = " Select Distinct * From V_KH_ThuHoach Where NangSuatDuKien>0 and NgayBatDau >=" + DBModule.RefineDate(this.dtTuNgay.Value) + " AND NgayBatDau <= " + DBModule.RefineDate(this.dtDenNgay.Value);
                                
                if (TramUIComBo.SelectedValue.ToString()!="0")
                {
                    sql = sql + "  And TramID = " + TramUIComBo.SelectedValue.ToString();
                }

                sql = sql + " Order By TramID, NgayBatDau";
                ds = DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MDSolution.MDForms.frmShowRP2 frm2 = new MDSolution.MDForms.frmShowRP2();
                    MDSolution.MDReport.ThuHoach.rpt_PhieuBaoChatMia rp = new MDSolution.MDReport.ThuHoach.rpt_PhieuBaoChatMia();
                    rp.SetDataSource(ds.Tables[0]);

                    //rp.Database.Tables[0].ApplyLogOnInfo(frm2.tblogon);
                    frm2.RP = rp;
                    frm2.Show();
                }
                else
                {
                    MessageBox.Show("Không có phiếu trong thời gian đã chọn!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra! Bạn thực hiện lại lệnh In phiếu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
        }

        private void RPT_DT01_Load(object sender, EventArgs e)
        {

            Load_Tram();
            dtTuNgay.Value = DateTime.Now;
            dtDenNgay.Value = DateTime.Now.AddDays(5);
        }
        private void Load_Tram()
        {
            string sql = "Select ID,Ten From tbl_TramNongVu Where 1= 1";
            //if (PhanQuyen_CacTramID != "")
            //    sql += " And ID in(" + PhanQuyen_CacTramID + ")";

            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            ds.Tables[0].Rows.Add("0", "----Chọn Địa bàn-----");
            ds.Tables[0].DefaultView.Sort = "ID";

            TramUIComBo.DisplayMember = "Ten";
            TramUIComBo.ValueMember = "ID";
            TramUIComBo.DataSource = ds.Tables[0];

            TramUIComBo.SelectedIndex = 0;                      
            
        }

        private void cmdInPhieuTiepNhan_Click(object sender, EventArgs e)
        {
            try
            {

                string sql = " Select * From V_KH_VanChuyen Where NgayChat >=" + DBModule.RefineDate(this.dtTuNgay.Value) + " AND NgayChat <= " + DBModule.RefineDate(this.dtDenNgay.Value) ;

                if (TramUIComBo.SelectedValue.ToString() != "0")
                {
                    sql = sql + "  And TramID = " + TramUIComBo.SelectedValue.ToString();
                }


                sql = sql + " Order By TramID, NgayBatDau";
                DataSet ds = null;
                ds = DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //MDSolution.MDForms.frmShowRP2 frm2 = new MDSolution.MDForms.frmShowRP2();
                    //MDReport.rpt_PhieuDonMia rp = new MDSolution.MDReport.rpt_PhieuDonMia();
                    //rp.SetDataSource(ds.Tables[0]);

                    ////rp.Database.Tables[0].ApplyLogOnInfo(frm2.tblogon);
                    //frm2.RP = rp;
                    //frm2.Show();
                }
                else
                {
                    MessageBox.Show("Không có phiếu trong thời gian đã chọn!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra! Bạn thực hiện lại lệnh In phiếu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
        }

        
    }
}
