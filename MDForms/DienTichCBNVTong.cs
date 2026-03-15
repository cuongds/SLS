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
    public partial class DienTichCBNVTong : Form
    {
        private DataSet gridDataSource;
        static DienTichCBNVTong _DienTichCBNVTong;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public DienTichCBNVTong OneInstanceFrm
        {
            get
            {
                if (null == _DienTichCBNVTong || _DienTichCBNVTong.IsDisposed)
                {
                    _DienTichCBNVTong = new DienTichCBNVTong();
                }

                return _DienTichCBNVTong;
            }
        }
        public DienTichCBNVTong()
        {
            InitializeComponent();
        }
        public void LoadData()
        {

            string sql = "sp_RP_HopDongDienTichTrongTongThon   " + ComboVuTrong.SelectedValue.ToString();
            this.gridDataSource = DBModule.ExecuteQuery(sql, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gdChiTietDauTu.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");

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
                saveFileDialog1.FileName = "DienTichXuDong" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
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

        private void DienTichCBNVTong_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            clsVuTrong.GetList("", out ds, null, null);
            ComboVuTrong.DataSource = ds.Tables[0];
            ComboVuTrong.DisplayMember = "Ten";
            ComboVuTrong.ValueMember = "ID";
            ComboVuTrong.SelectedValue = MDSolutionApp.VuTrongID;
        }
      
    }
}
