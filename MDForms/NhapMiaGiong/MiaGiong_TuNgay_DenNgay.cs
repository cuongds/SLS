using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using MDSolution.MDReport;

namespace MDSolution.MDForms.NhapMiaGiong
{
    public partial class MiaGiong_TuNgay_DenNgay : Form
    {
        private DataSet gridDataSource;
        static MiaGiong_TuNgay_DenNgay _MiaGiong_TuNgay_DenNgay;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public MiaGiong_TuNgay_DenNgay OneInstanceFrm
        {
            get
            {
                if (null == _MiaGiong_TuNgay_DenNgay || _MiaGiong_TuNgay_DenNgay.IsDisposed)
                {
                    _MiaGiong_TuNgay_DenNgay = new MiaGiong_TuNgay_DenNgay();
                }

                return _MiaGiong_TuNgay_DenNgay;
            }
        }
        public MiaGiong_TuNgay_DenNgay()
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
            if (cboCanBoNV.SelectedIndex < 0)
            {
                cboCanBoNV.SelectedValue = -1;
            }
            string strWhere = " VuTrongID=" + MDSolutionApp.VuTrongID ;
            if (cboCanBoNV.SelectedValue.ToString() != "-1") strWhere += " AND CanBoNongVuID =" + cboCanBoNV.SelectedValue.ToString();
            if (!this.dtTuNgay.IsNullDate) strWhere += " AND NgayLap>=" + DBModule.RefineDatetime(this.dtTuNgay.Value);
            if (!this.dtDenNgay.IsNullDate) strWhere += " AND NgayLap<='" + this.dtDenNgay.Value.ToString("MM/dd/yyyy") + " 23:59:59'";

            string strSQL = "select * from V2016_NhapMiaGiong "         
            + " WHERE " + strWhere ;
            //MessageBox.Show(strSQL);
            this.gridDataSource = DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.grdMiaGiong.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");

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
                saveFileDialog1.FileName = "Dautu_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = grdMiaGiong;
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

        private void MiaGiong_TuNgay_DenNgay_Load(object sender, EventArgs e)
        {
            DataSet dsCB = DBModule.ExecuteQuery("Select ID,Ten from tbl_DanhMucCanBoNongVu union select -1,N'Tất cả'", null, null);
            cboCanBoNV.DataSource = dsCB.Tables[0];
            cboCanBoNV.DisplayMember = "Ten";
            cboCanBoNV.ValueMember = "ID";
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

        private void grdMiaGiong_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            try
            {
                if (this.grdMiaGiong.GetValue("Ma_PhieuNhap").ToString() != "")
                {

                    // object objid = grdDauTu.GetValue("ID");
                    MDForms.ThanhToan2016.frm_NhapMiaGiong frm = new MDForms.ThanhToan2016.frm_NhapMiaGiong(long.Parse(this.grdMiaGiong.GetValue("HopDongID").ToString()));
                    frm.txtMaHD.Text = this.grdMiaGiong.GetValue("MaHopDong").ToString();
                    frm.txtTenHD.Text = this.grdMiaGiong.GetValue("HoTen").ToString();
                    frm.txtSoCT.Text = this.grdMiaGiong.GetValue("Ma_PhieuNhap").ToString();
                    frm.LoadMiaGiong();

                    frm.LoadGrdDauTu();
                    frm.ShowDialog();
                    
                }
                else { MessageBox.Show("Bạn phải chọn một mục đầu tư để sửa", "Thông báo"); }
            }
            catch { MessageBox.Show("Bạn phải chọn một mục đầu tư để sửa", "Thông báo"); }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            //MiaGiong_BangCanDoi frm = new MiaGiong_BangCanDoi();
            //frm.Show();
            if (cboCanBoNV.SelectedIndex < 0)
            {
                cboCanBoNV.SelectedValue = -1;
            }
            MDReport.Frm_ReportViewer frm = new Frm_ReportViewer();
            string[] paramNames = new string[] { "@VuTrongID", "@TuNgay", "@DenNgay", "@CanBoNongVuID" };
            string[] paraValues = new string[] { MDSolutionApp.VuTrongID.ToString(), (dtTuNgay.IsNullDate ? "1900-01-01" : dtTuNgay.Value.ToString("yyyy-MM-dd")), (dtDenNgay.IsNullDate ? "1900-01-01" : dtDenNgay.Value.ToString("yyyy-MM-dd") + " 23:59:59"), cboCanBoNV.SelectedValue.ToString() };
            CommonClass.ShowReport("\\ThanhToan2016\\rpt_CanDoiMiaGiong.rpt", "", paramNames, paraValues, null);
        }
    }
}
