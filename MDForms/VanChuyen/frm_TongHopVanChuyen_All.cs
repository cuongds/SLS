using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using System.Globalization;
using System.Threading;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using MDSolution.MDForms;

namespace MDSolution.MDForms.VanChuyen
{
    public partial class frm_TongHopVanChuyen_All : Form
    {
        static frm_TongHopVanChuyen_All _frm_TongHopVanChuyen_All;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_TongHopVanChuyen_All OneInstanceFrm
        {
            get
            {
                if (null == _frm_TongHopVanChuyen_All || _frm_TongHopVanChuyen_All.IsDisposed)
                {
                    _frm_TongHopVanChuyen_All = new frm_TongHopVanChuyen_All();
                }

                return _frm_TongHopVanChuyen_All;
            }
        }

        public frm_TongHopVanChuyen_All()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Load_DL_VanChuyen()
        {
            string sql = "sp_TongHop_Cuoc_Ung_VanChuyen_HopDong " + MDSolutionApp.VuTrongID.ToString() + ",'" + dtTuNgay.Value.ToString("yyyy-MM-dd") + "','" + dtDenNgay.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDL_VC.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdDL_VC.DataSource = null;
            }
        }
      
       
        private void cmdXemDL_Click(object sender, EventArgs e)
        {
            Load_DL_VanChuyen();
        }

        private void cmdXuatExcel_Click(object sender, EventArgs e)
        {
               if (this.gdDL_VC.RowCount > 0)
                {
                    try
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                            {
                                Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                                exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                                exporter.GridEX = gdDL_VC;
                                exporter.Export(fs);
                                fs.Close();
                                MessageBox.Show("Đã export ra file excel!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi khi lưu dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
     
        }

        private void gdChiTietCapVT_ChuyenDT_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e.Row.RowType == RowType.Record)
            {
                string DaChuyenDT = e.Row.Cells["NguoiChuyen"].Value.ToString();
                if (DaChuyenDT != "")
                {
                    e.Row.CheckState = RowCheckState.Checked;
                    Janus.Windows.GridEX.GridEXFormatStyle CHD_format = new GridEXFormatStyle();
                    CHD_format.ForeColor = Color.DarkOrchid;
                    e.Row.RowStyle = CHD_format;
                }
            }
        }

       
   
        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            frmShowRP2 frm = new frmShowRP2();
            System.Data.DataTable dt =new DataTable();
            if (TabTongHopVanChuyen.SelectedIndex == 0)
            {
                if (this.gdDL_VC.RowCount > 0)
                {
                    MDSolution.MDReport.VanChuyen.rpt_BangKeThanhToanVC_Mia rp = new MDSolution.MDReport.VanChuyen.rpt_BangKeThanhToanVC_Mia();
                    dt = (System.Data.DataTable)gdDL_VC.DataSource;
                    rp.Database.Tables[0].SetDataSource(dt);
                    frm.RP = rp;
                    rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                    frm.RPtitle = "Chi tiết cước vận chuyển mía";
                    rp.SetParameterValue("Tu", dtTuNgay.Value.ToString("dd/MM/yyyy"));
                    rp.SetParameterValue("Den", dtDenNgay.Value.ToString("dd/MM/yyyy"));
                    rp.SetParameterValue("TenVu", MDSolutionApp.VuTrongTen);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
           
        }

        private void frm_TongHopVanChuyen_All_Load(object sender, EventArgs e)
        {
            lblTitle.Text = lblTitle.Text + MDSolutionApp.VuTrongTen;
            DataSet ds = DBModule.ExecuteQuery("select YEAR(GETDATE()) as Nam, MONTH(GETDATE()) as Thang, DAY(GETDATE()) as Ngay", null, null);
            int Nam = int.Parse(ds.Tables[0].Rows[0]["Nam"].ToString());
            int Thang = int.Parse(ds.Tables[0].Rows[0]["Thang"].ToString());
            int Ngay = int.Parse(ds.Tables[0].Rows[0]["Ngay"].ToString());
            dtDenNgay.Value = new DateTime(Nam, Thang, Ngay, 0, 0, 0);
            dtTuNgay.Value = dtDenNgay.Value.AddDays(-30);
            Load_DL_VanChuyen();
        }

      
       
    }
}