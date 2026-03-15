using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using MDSolution.MDReport;

namespace MDSolution.MDForms.DauTu
{
    public partial class HoTro_TuNgay_DenNgay : Form
    {
        private DataSet gridDataSource;
        static HoTro_TuNgay_DenNgay _HoTro_TuNgay_DenNgay;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public HoTro_TuNgay_DenNgay OneInstanceFrm
        {
            get
            {
                if (null == _HoTro_TuNgay_DenNgay || _HoTro_TuNgay_DenNgay.IsDisposed)
                {
                    _HoTro_TuNgay_DenNgay = new HoTro_TuNgay_DenNgay();
                }

                return _HoTro_TuNgay_DenNgay;
            }
        }
       

        public HoTro_TuNgay_DenNgay()
        {
            InitializeComponent();
            LoadDataLai();
           
        }
        
        public void LoadData()
        {            
            string sql = "SELECT * FROM  V_DanhSach_HoTro WHERE ngaylamhotro BETWEEN " + DBModule.RefineDatetime(this.dtTuNgay.Value) + " AND " + DBModule.RefineDatetime(this.dtDenNgay.Value) + " AND VuTrongID= " + MDSolutionApp.VuTrongID.ToString();
            sql = string.Format(sql, this.dtTuNgay.IsNullDate ? "Null" : DBModule.RefineDatetime(this.dtTuNgay.Value), this.dtDenNgay.IsNullDate ? "Null" : DBModule.RefineDatetime(this.dtDenNgay.Value), ComboVuTrong.SelectedValue.ToString());
            this.gridDataSource = DBModule.ExecuteQuery(sql, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gdChiTietDauTu.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");

            }

        }
        public void LoadDataLai()
        {
            string sql = "SELECT * FROM  V_DanhSach_HoTro_Lai WHERE  VuTrongID= " + MDSolutionApp.VuTrongID.ToString();
            sql = string.Format(sql, ComboVuTrong.SelectedValue.ToString());
            this.gridDataSource = DBModule.ExecuteQuery(sql, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gdChiTietHT_Lai.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");
            }
        }

        private void cmdAddHD_Click(object sender, EventArgs e)
        {
          
        }

        private void btnXuatExcelHopDong_Click(object sender, EventArgs e)
        {
           
        }

        private void HoTro_TuNgay_DenNgay_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            clsVuTrong.GetList("", out ds, null, null);
            ComboVuTrong.DataSource = ds.Tables[0];
            ComboVuTrong.DisplayMember = "Ten";
            ComboVuTrong.ValueMember = "ID";
            ComboVuTrong.SelectedValue = MDSolutionApp.VuTrongID;
        }

        private void gdChiTietDauTu_EditingCell(object sender, EditingCellEventArgs e)
        {
            //e.Cancel=true;
        }



        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdInTongHT_Click(object sender, EventArgs e)
        {

           


        }

        private void cmdTimLai_Click(object sender, EventArgs e)
        {
            LoadDataLai();
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
        }

        private void cmdInTongHT_Click_1(object sender, EventArgs e)
        {
            MDReport.Frm_ReportViewer frm = new MDReport.Frm_ReportViewer();
            string[] paramNames = new string[] { "@VuTrongID" };
            string[] paraValues = new string[] { ComboVuTrong.SelectedValue.ToString() };
            CommonClass.ShowReport("\\ChamSoc\\BCHopDongDienTichHoTro.rpt", "Tổng hợp hỗ trợ", paramNames, paraValues, null);
        }

        private void cmdAddHD_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXuatExcelHopDong_Click_1(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "HoTro_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = gdChiTietDauTu;
                        exporter.Export(fs);
                        fs.Close();
                        MessageBox.Show("Xuất dữ liệu xong!", "Thông báo", MessageBoxButtons.OK);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void cmdClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiButton4_Click_1(object sender, EventArgs e)
        {

            try
            {
                saveFileDialog1.FileName = "HoTro_Lai" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = gdChiTietHT_Lai;
                        exporter.Export(fs);
                        fs.Close();
                        MessageBox.Show("Xuất dữ liệu xong!", "Thông báo", MessageBoxButtons.OK);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "HoTro_DaDoiTru" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = grvDaDoiTru;
                        exporter.Export(fs);
                        fs.Close();
                        MessageBox.Show("Xuất dữ liệu xong!", "Thông báo", MessageBoxButtons.OK);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
        }
        void LoadHoTro_DaDoiTru()
        {
            // isDaChietTinhLoaded = true;
            //string sql = @"SELECT * FROM V_HoTroDoiTruNo WHERE NgayThanhToan BETWEEN " + DBModule.RefineDatetime(this.dtCT_TuNgay.Value) + " AND " + DBModule.RefineDatetime(this.dtDa_DenNgay.Value);
            string sql = @"SELECT * FROM V_HoTroDoiTruNo ";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            grvDaDoiTru.SetDataBinding(ds, "Table");

        }

        private void TabHoTro_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (TabHoTro.SelectedIndex == 0)
            {
                LoadData();
            }
            if (TabHoTro.SelectedIndex == 1)
            {
                LoadDataLai();
            }
            if (TabHoTro.SelectedIndex == 2)
            {
                LoadHoTro_DaDoiTru();
            }
        }

        private void cmdInCheck_Click(object sender, EventArgs e)
        {
            if (gdChiTietDauTu.GetCheckedRows().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn phiếu cần in"); return;
            }
            string[] paramNames = new string[] { "@VuTrongID"}; //, "@DaiDien1" };
            string[] paraValues = new string[] { MDSolutionApp.VuTrongID.ToString()};//, txtDaiDien1.Text + "};

            string sql = @" select * from tbl_HopDong where 1=3 ";
            foreach (Janus.Windows.GridEX.GridEXRow r in gdChiTietDauTu.GetCheckedRows())
            {
                sql += " or ID= " + r.Cells["HopDongID"].Value;
            }
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);

          
            MDReport.Frm_ReportViewer frm = new MDSolution.MDReport.Frm_ReportViewer();
            frm.bHasPara = true;
            frm.ParaNames = paramNames;
            frm.ParaValues = paraValues;
            frm.rptFileName = "ChinhSach\\InDanhSachHoTro.rpt";
            frm.rptTitle = "";
            frm.ds = ds;
          
            frm.Show();
        }
    }
}
