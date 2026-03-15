using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace MDSolution.MDForms
{
    public partial class frm_DauTuVatTu : Form
    {
        private DataSet gridDataSource;
        static frm_DauTuVatTu _frm_DauTuVatTu;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_DauTuVatTu OneInstanceFrm
        {
            get
            {
                if (null == _frm_DauTuVatTu || _frm_DauTuVatTu.IsDisposed)
                {
                    _frm_DauTuVatTu = new frm_DauTuVatTu();
                }

                return _frm_DauTuVatTu;
            }
        }
        public frm_DauTuVatTu()
        {
            InitializeComponent();
        }
        public void LoadData()
        {

            string sql = "sp_RP_DauTuHopDong   " + ComboVuTrong.SelectedValue.ToString();
            this.gridDataSource = DBModule.ExecuteQuery(sql, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gdChiTietDauTu.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");

            }

        }
        public void LoadDataTong()
        {

            string sql = "sp_RP_DauTuHopDongTong   " + ComboVuTrong.SelectedValue.ToString();
            this.gridDataSource = DBModule.ExecuteQuery(sql, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gdChiTietDauTuTong.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");
            }
        }

        private void cmdAddHD_Click(object sender, EventArgs e)
        {
           
                LoadData();
           
            
           
        }
        private void btnXuatExcelHopDong_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "ChiTietDauTu" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
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
        private void LoadVuTrong()
        {
            DataSet ds = new DataSet();
            clsVuTrong.GetList("", out ds, null, null);
            ComboVuTrong.DataSource = ds.Tables[0];
            ComboVuTrong.DisplayMember = "Ten";
            ComboVuTrong.ValueMember = "ID";
            ComboVuTrong.SelectedValue = MDSolutionApp.VuTrongID;
        
        }
        private void LoadVuTrong1()
        {
            DataSet ds = new DataSet();
            clsVuTrong.GetList("", out ds, null, null);
            ComboVuTrong1.DataSource = ds.Tables[0];
            ComboVuTrong1.DisplayMember = "Ten";
            ComboVuTrong1.ValueMember = "ID";
            ComboVuTrong1.SelectedValue = MDSolutionApp.VuTrongID;

        }
        private void frm_DauTuVatTu_Load(object sender, EventArgs e)
        {
            LoadVuTrong();
            LoadVuTrong1();
        }

        private void cmdAddHD1_Click(object sender, EventArgs e)
        {
            LoadDataTong();
        }

        private void btnXuatExcelHopDong1_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "TongDauTu" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = gdChiTietDauTuTong;
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
    }
}
