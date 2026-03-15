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
    public partial class DauTuThuNoTheoHo : Form
    {
        private DataSet gridDataSource;
        static DauTuThuNoTheoHo _DauTuThuNoTheoHo;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public DauTuThuNoTheoHo OneInstanceFrm
        {
            get
            {
                if (null == _DauTuThuNoTheoHo || _DauTuThuNoTheoHo.IsDisposed)
                {
                    _DauTuThuNoTheoHo = new DauTuThuNoTheoHo();
                }

                return _DauTuThuNoTheoHo;
            }
        }
        public DauTuThuNoTheoHo()
        {
            InitializeComponent();
            //Load_CB_LoaiHD();
            //Load_CB_Tram();
        }
        //private void Load_CB_LoaiHD()
        //{
        //    string sql = "Select * from LoaiHopDong";
        //    DataSet ds = DBModule.ExecuteQuery(sql, null, null);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        DataRow dr = ds.Tables[0].NewRow();
        //        dr["ID"] = 0;
        //        dr["Ten"] = "------Tất cả các loại HĐ------";
        //        ds.Tables[0].Rows.InsertAt(dr, 0);
        //        cboLoaiHopDong.DataSource = ds.Tables[0];
        //        cboLoaiHopDong.ValueMember = "ID";
        //        cboLoaiHopDong.DisplayMember = "Ten";              
        //    }
        //    else
        //    {
        //        cboLoaiHopDong.DataSource = null;

        //    }
        //}
        //private void Load_CB_Tram()
        //{
        //    string sql = "";           
        //    lblTram.Text = "Tên trạm:";
        //    sql = "Select ID,Ten from tbl_TramNongVu";
        //    DataSet ds = DBModule.ExecuteQuery(sql, null, null);
        //    DataRow dr = ds.Tables[0].NewRow();
        //    dr["ID"] = 0;
        //    dr["Ten"] = "----------Tất cả---------";
        //    ds.Tables[0].Rows.InsertAt(dr, 0);
        //    cboTram.DataSource = ds.Tables[0];
        //    cboTram.ValueMember = "ID";
        //    cboTram.DisplayMember = "Ten";

        //}
        public void LoadData()
        {
            //string strWhere = "  VuTrongID=" +  ComboVuTrong.SelectedValue.ToString();
            //if (!this.dtTuNgay.IsNullDate) strWhere += " AND   NgayDauTu>=" + DBModule.RefineDatetime(this.dtTuNgay.Value);
            //if (!this.dtDenNgay.IsNullDate) strWhere += " AND  NgayDauTu<" + DBModule.RefineDatetime(this.dtDenNgay.Value);

            //string strSQL = "select * from dbo.V2016_TraCuuDauTu "
            //+ " WHERE " + strWhere + " ORDER BY HopDongID";
            //MessageBox.Show(strSQL);
            string sql = "sp_RB_DauTuCongNo {0},{1},{2}";
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

        private void btnXuatExcelHopDong_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "DautuThuNoHopDong" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
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

        private void DauTuThuNoTheoHo_Load(object sender, EventArgs e)
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
    }
}
