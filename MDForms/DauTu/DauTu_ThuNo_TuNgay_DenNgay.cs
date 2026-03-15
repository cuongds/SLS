using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace MDSolution.MDForms.DauTu
{
    public partial class DauTu_ThuNo_TuNgay_DenNgay : Form
    {
        private DataSet gridDataSource;
        static DauTu_ThuNo_TuNgay_DenNgay _DauTu_ThuNo_TuNgay_DenNgay;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public DauTu_ThuNo_TuNgay_DenNgay OneInstanceFrm
        {
            get
            {
                if (null == _DauTu_ThuNo_TuNgay_DenNgay || _DauTu_ThuNo_TuNgay_DenNgay.IsDisposed)
                {
                    _DauTu_ThuNo_TuNgay_DenNgay = new DauTu_ThuNo_TuNgay_DenNgay();
                }

                return _DauTu_ThuNo_TuNgay_DenNgay;
            }
        }
        public DauTu_ThuNo_TuNgay_DenNgay()
        {
            InitializeComponent();
            //Load_CB_LoaiHD();
            //Load_CB_Tram();
        }
     
        public void LoadData()
        {
            //string strWhere = "  VuTrongID=" +  ComboVuTrong.SelectedValue.ToString();
            //if (!this.dtTuNgay.IsNullDate) strWhere += " AND   NgayDauTu>=" + DBModule.RefineDatetime(this.dtTuNgay.Value);
            //if (!this.dtDenNgay.IsNullDate) strWhere += " AND  NgayDauTu<" + DBModule.RefineDatetime(this.dtDenNgay.Value);

            //string strSQL = "select * from dbo.V2016_TraCuuDauTu "
            //+ " WHERE " + strWhere + " ORDER BY HopDongID";
            //MessageBox.Show(strSQL);
            string sql = "sp_rpt2016_BaoCaoChiTietDauTu_ThuNo_TheoHopDong {0},{1},{2}";
            sql=string.Format(sql,this.dtTuNgay.IsNullDate?"Null":DBModule.RefineDatetime(this.dtTuNgay.Value),this.dtDenNgay.IsNullDate?"Null":DBModule.RefineDatetime(this.dtDenNgay.Value),ComboVuTrong.SelectedValue.ToString());
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


        private void DauTu_ThuNo_TuNgay_DenNgay_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            clsVuTrong.GetList("", out ds, null, null);
            ComboVuTrong.DataSource = ds.Tables[0];
            ComboVuTrong.DisplayMember = "Ten";
            ComboVuTrong.ValueMember = "ID";
            ComboVuTrong.SelectedValue = MDSolutionApp.VuTrongID;
            lblTitle.Text = lblTitle.Text + MDSolutionApp.VuTrongTen;
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "Dautu_ThuNo_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
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
    }
}
