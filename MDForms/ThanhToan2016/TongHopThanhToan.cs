using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace MDSolution.MDForms.ThanhToan2016
{
    public partial class TongHopThanhToan : Form
    {
        public TongHopThanhToan()
        {
            InitializeComponent();
        }
        private DataSet LoadHopDong()
        {
            string strSQL = "";
            strSQL = @"SELECT a.*,b.Ten as TenThon 

                        FROM tbl_HopDong as a LEFT JOIN tbl_Thon as b ON a.ThonID=b.ID 
                        WHERE a.parentid=0 AND TrangThai = 1 AND a.ID IN (SELECT HopDongID From tbl_HopDongVuTrong Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString() + ")";

            return DBModule.ExecuteQuery(strSQL, null, null);
        }

        private void TongHopThanhToan_Load(object sender, EventArgs e)
        {
            //gdChiTietDauTu.SetDataBinding(LoadHopDong().Tables[0],"");
        }
        public string Ma_HD;
        private void GridEX1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
            {
                Ma_HD = gdChiTietDauTu.GetRow().Cells["MaHopDong"].Value.ToString();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void cmdXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string text = "";
                saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save text Files";
                saveFileDialog.Filter = "file xls|*.xls";
                saveFileDialog.ShowDialog();
                //  saveFileDialog.FileName = "ThanhToan" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog.FileName != "")
                {
                    System.IO.FileStream fs =(System.IO.FileStream)saveFileDialog.OpenFile();

                    {

                       // using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                        {

                            Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                            exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                            exporter.GridEX = gdChiTietDauTu;
                            exporter.Export(fs);
                            fs.Close();
                            // string 
                            text = File.ReadAllText(saveFileDialog.FileName);
                            text = text.Replace("<ss:NumberFormat ss:Format=\"Standard\" />", "<NumberFormat ss:Format=\"_(* #,##0_);_(* \\(#,##0\\);_(* &quot;-&quot;??_);_(@_)\"/>");
                            File.WriteAllText(saveFileDialog.FileName, text);
                            MessageBox.Show("Xuất dữ liệu xong!", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void cmdAddHD_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        public string strWhere = " 1=1 ";
        public void LoadData()
        {
            //string strWhere = "  VuTrongID=" + ComboVuTrong.SelectedValue.ToString();
            //if (!this.dtTuNgay.IsNullDate) strWhere += " AND   NgayThanhToan>=" + DBModule.RefineDatetime(this.dtTuNgay.Value);
            //if (!this.dtDenNgay.IsNullDate) strWhere += " AND  NgayThanhToan<=" + DBModule.RefineDatetime(this.dtDenNgay.Value);

            //string strSQL = "select * from dbo.V2016_TraCuuDauTu "
            //+ " WHERE " + strWhere + " ORDER BY HopDongID";
            //MessageBox.Show(strSQL);
            string sql = "select * from V2016_rpt_TongHopThanhToanMia where " + strWhere;

            // sql = string.Format(sql, this.dtTuNgay.IsNullDate ? "Null" : DBModule.RefineDatetime(this.dtTuNgay.Value), this.dtDenNgay.IsNullDate ? "Null" : DBModule.RefineDatetime(this.dtDenNgay.Value), ComboVuTrong.SelectedValue.ToString());
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                this.gdChiTietDauTu.SetDataBinding(ds.Tables[0], "");

            }

        }

        private void gdChiTietDauTu_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {

        }
    }
}
