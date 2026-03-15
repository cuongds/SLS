using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using System.Data.OleDb;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using MDSolution.MDForms;
namespace MDSolution.MDForms.UngTien
{
    public partial class frm_Temp_Import_UngTien : Form
    {
        static frm_Temp_Import_UngTien _frm_Temp_Import_UngTien;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_Temp_Import_UngTien OneInstanceFrm
        {
            get
            {
                if (null == _frm_Temp_Import_UngTien || _frm_Temp_Import_UngTien.IsDisposed)
                {
                    _frm_Temp_Import_UngTien = new frm_Temp_Import_UngTien();
                }

                return _frm_Temp_Import_UngTien;
            }
        }
        private DateTime NGAYRA = DateTime.Now;                
        private string TenFile = "";
        public int OK = 0;

        public frm_Temp_Import_UngTien()
        {
            InitializeComponent();
        }
        public frm_Temp_Import_UngTien(string FileName)
        {
            InitializeComponent();
            TenFile = FileName;
        }
        private void LoadDaTa_KeHoachUng()
        {
            string strSQL = "SELECT ID,[Sotien],[NgayUng],[HopDongID],[VuTrongID],[TenDot],[GhiChu],[CreatedByUserID],[DateAdd],[Status],[Errors],[Importer],[DateImport],[Modify],[DateModify] ,Errors AS Err,MaHopDong,HoTen," +
                            "CASE WHEN Modify>0 THEN N'Đã sửa' ELSE Errors END AS Errors FROM  [tbl_Temp_Import_Excel_KeHoachUngTienMat] Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " AND Status =1";
            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDSUngTienMat.SetDataBinding(ds.Tables[0], "RootTable");
            }
        }
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            string sql = "Select Count(*) from tbl_Temp_Import_Excel_KeHoachUngTienMat Where  VuTrongID= " + MDSolutionApp.VuTrongID.ToString() + " And Errors!=''";
            long SoDongLoi = long.Parse(DBModule.ExecuteQueryForOneResult(sql, null, null).ToString());
            if (SoDongLoi > 0)
            {
                MessageBox.Show("Bạn chưa thể ghi dữ liệu vì có " + SoDongLoi.ToString() + " dòng bị lỗi!\nBạn có thể sửa trực tiếp trên grid hoặc sửa file excel nguồn và tiến hành nhập lại sau khi đã lưu sửa file nguồn", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn ghi dữ liệu ứng tiền?", "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.lblWaite.Visible = true;
                this.lblWaite.Text = "Vui lòng đợi...";
                this.cmdSave.Enabled = false;
                this.pnBottom.Refresh();
                this.lblWaite.Refresh();
                try
                {
                    string sqlInsert = @" INSERT INTO [dbo].[tbl_KeHoachUngTienMat]
                                       ([Sotien],[NgayUng],[HopDongID],[VuTrongID],[TenDot],[GhiChu],[CreatedByUserID],[DateAdd],[Status],[BangChu])
                                        SELECT [Sotien],[NgayUng],[HopDongID],[VuTrongID],[TenDot],[GhiChu],[CreatedByUserID],[DateAdd],[Status],[BangChu]
                                        from tbl_Temp_Import_Excel_KeHoachUngTienMat Where  VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " and Status=1";
                    string sqlDelete = "DELETE FROM tbl_Temp_Import_Excel_KeHoachUngTienMat ";

                    DBModule.ExecuteNonQuery(sqlInsert,null,null);
                    DBModule.ExecuteNonQuery(sqlDelete, null, null);
                    OK = 1;
                    this.lblWaite.Text = "Đã ghi dữ liệu!";
                    MessageBox.Show("Đã lưu dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    this.lblWaite.Visible = false;
                    MessageBox.Show("Có lỗi khi lưu dữ liệu!\n" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cmdXuatExcel_Click(object sender, EventArgs e)
        {
            if (this.gdDSUngTienMat.RowCount > 0)
            {
                try
                {
                    if (saveFileDialog_Excel.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog_Excel.FileName, System.IO.FileMode.Create))
                        {
                            Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                            exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                            exporter.GridEX = gdDSUngTienMat;
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


        private void gdDSThuaRuong_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e.Row.RowType == RowType.Record)
            {
                string Errors = e.Row.Cells["Err"].Value.ToString();
                if (!string.IsNullOrEmpty(Errors))
                {
                    Janus.Windows.GridEX.GridEXFormatStyle CapVT_format = new GridEXFormatStyle();
                    CapVT_format.ForeColor = Color.Red;
                    e.Row.RowStyle = CapVT_format;
                }
            }
        }

        private void gdDSThuaRuong_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {            
            long Import_ID = -1;
            try
            {                
                Import_ID = long.Parse(this.gdDSUngTienMat.GetValue("ID").ToString());
            }
            catch
            {
                return;
            }
            if (e.Column.Key == "Sua")
            {              
                MDSolution.MDForms.UngTien.frm_NhapUngTienTemp frm = new frm_NhapUngTienTemp(Import_ID,1);
                frm.ShowDialog();
                if (frm.OK > 0)
                {
                    try
                    {
                        LoadDaTa_KeHoachUng();
                        GridEXFilterCondition condi = new GridEXFilterCondition(this.gdDSUngTienMat.RootTable.Columns["ID"], ConditionOperator.Equal, Import_ID);
                        this.gdDSUngTienMat.Find(condi, 0, 1);
                    }
                    catch { }
                }

            }
            if (e.Column.Key == "Delete")
            {
                if (MessageBox.Show("Chức năng chỉ xóa dữ liệu trên form!\nBạn chắc chắn xóa dòng này", "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                try
                {
                    string strSQL = "DELETE FROM [tbl_Temp_Import_Excel_KeHoachUngTienMat] WHERE ID=" + Import_ID.ToString();                    
                    DBModule.ExecuteNonQuery(strSQL, null, null);
                    LoadDaTa_KeHoachUng();
                }
                catch { }
            }
        }

        private void frm_Temp_Import_UngTien_Load(object sender, EventArgs e)
        {
            lblTitle.Text = lblTitle.Text + MDSolutionApp.VuTrongTen;
            lblTenFile.Text = TenFile;
            LoadDaTa_KeHoachUng();
        }
    }
}