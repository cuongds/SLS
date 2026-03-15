using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
namespace MDSolution.MDForms.DienTich
{
    public partial class frm_BaoCaoDienTich_CBDB : Form
    {
        private DataSet gridDataSource;
        private long VuTrongID=-1;
        static frm_BaoCaoDienTich_CBDB _frm_BaoCaoDienTich_CBDB;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_BaoCaoDienTich_CBDB OneInstanceFrm
        {
            get
            {
                if (null == _frm_BaoCaoDienTich_CBDB || _frm_BaoCaoDienTich_CBDB.IsDisposed)
                {
                    _frm_BaoCaoDienTich_CBDB = new frm_BaoCaoDienTich_CBDB();
                }

                return _frm_BaoCaoDienTich_CBDB;
            }
        }
        public frm_BaoCaoDienTich_CBDB()
        {
            InitializeComponent();
        }
        public frm_BaoCaoDienTich_CBDB( long VTID)
        {
            InitializeComponent();
            VuTrongID = VTID;
        }
        public void LoadData()
        {
            string sql = "sp_BaoCaoDienTich_CBDB_New " + VuTrongID.ToString();
            this.gridDataSource = DBModule.ExecuteQuery(sql, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gdTongHopDienTich_CBDB.SetDataBinding(this.gridDataSource.Tables[0], "");
            }
            else
            {
                this.gdTongHopDienTich_CBDB.DataSource = DBNull.Value;
            }

        }
     
      
      
     
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
        private void frm_BaoCaoDienTich_CBDB_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "DỮ LIỆU DIỆN TÍCH CÁN BỘ ĐỊA BÀN SLS NIÊN VỤ " + MDSolutionApp.VuTrongTen;
            LoadData();
        }

        private void btnXuatExcelDT_CBDB_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.FileName = "DuLieu_DT_CBNV" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = gdTongHopDienTich_CBDB;
                        exporter.Export(fs);
                        fs.Close();
                        MessageBox.Show("Xuất dữ liệu ra định dạng excel!", "SLS", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "SLS", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        

    }
}
