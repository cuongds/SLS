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
    public partial class DienTichCBNV : Form
    {
        private DataSet gridDataSource;
        static DienTichCBNV _DienTichCBNV;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public DienTichCBNV OneInstanceFrm
        {
            get
            {
                if (null == _DienTichCBNV || _DienTichCBNV.IsDisposed)
                {
                    _DienTichCBNV = new DienTichCBNV();
                }

                return _DienTichCBNV;
            }
        }
        public DienTichCBNV()
        {
            InitializeComponent();
        }
        public void LoadData()
        {

            string sql = "sp_RP_HopDongDienTichTrong_From   " + ComboVuTrong.SelectedValue.ToString();
            this.gridDataSource = DBModule.ExecuteQuery(sql, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gdChiTietDauTu.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");

            }

        }

        public void LoadData1()
        {

            string sql = "sp_RP_HopDongDienTichTrong   NULL," + ComboVuTrong.SelectedValue.ToString()+",NULL";
            this.gridDataSource = DBModule.ExecuteQuery(sql, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gridEX1.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");

            }

        }


        private void cmdAddHD_Click(object sender, EventArgs e)
        {
            LoadData();
            LoadData1();
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

        private void DienTichCBNV_Load(object sender, EventArgs e)
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

        private void gdChiTietDauTu_CellEdited(object sender, ColumnActionEventArgs e)
        {

        }

        private void gdChiTietDauTu_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void gdChiTietDauTu_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }

        private void btn_xuatchitiet_Click(object sender, EventArgs e)
        {
           
        }

        private void uiButton1_Click(object sender, EventArgs e)
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
                        exporter.GridEX = gridEX1;
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
