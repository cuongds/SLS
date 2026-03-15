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


namespace MDSolution.MDForms.DienTich
{
    public partial class frm_Temp_Import_DienTich : Form
    {
        static frm_Temp_Import_DienTich _frm_Temp_Import_DienTich;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_Temp_Import_DienTich OneInstanceFrm
        {
            get
            {
                if (null == _frm_Temp_Import_DienTich || _frm_Temp_Import_DienTich.IsDisposed)
                {
                    _frm_Temp_Import_DienTich = new frm_Temp_Import_DienTich();
                }

                return _frm_Temp_Import_DienTich;
            }
        }
        private DateTime NGAYRA = DateTime.Now;
        private string TenCBNV = "";
        private long CBNV_ID = -1;
        private string TenFile = "";
        public int OK=0;
      
        public frm_Temp_Import_DienTich()
        {
            InitializeComponent();
        }
        public frm_Temp_Import_DienTich(long CBNVID, string CBNV, string FileName)
        {
            InitializeComponent();
            TenCBNV = CBNV;
            TenFile = FileName;
            CBNV_ID = CBNVID;
        }
        private void LoadDaTaDienTich()
        {
            string strSQL = "SELECT  ID,HopDongID,MaHopDong,ThonID,BaiTapKetID,CanBoNongVuID,HoTen,TenBai,TenThon,Modify,NgayTrong,ISNULL(DienTich,0)/10000 AS DienTich,LoaiDat,LoaiGiong,KieuTrong,SanLuongDuKien,Errors AS Err," +
                            "CASE WHEN Modify>0 THEN N'Đã sửa' ELSE Errors END AS Errors FROM  tbl_Temp_Import_Excel_NhapDienTich Where CanBoNongVuID=" + CBNV_ID.ToString() + " And VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDSThuaRuong.SetDataBinding(ds.Tables[0], "RootTable");
            }
        }
   
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private long CheckNongHo()
        {
                long HDID = -1;
                //string sql = "Select TOP 1 Count(HopDongID),HopDongID From tbl_Temp_Import_Excel_CapVatTu Where XuatVatTuID=" + XuatVTID.ToString() + " Group By HopDongID Having Count(HopDongID)>1";
                //DataSet ds = DBModule.ExecuteQuery(sql, null, null);
                //if (ds.Tables[0].Rows.Count>0)
                //{
                //   HDID=long.Parse(ds.Tables[0].Rows[0]["HopDongID"].ToString());
                //}
                return HDID;
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            //long NongHo=CheckNongHo();
            string sql = "Select Count(*) from tbl_Temp_Import_Excel_NhapDienTich Where CanBoNongVuID=" + CBNV_ID.ToString() + " And VuTrongID= "+ MDSolutionApp.VuTrongID.ToString()+ " And Errors!=''";
            long SoDongLoi = long.Parse(DBModule.ExecuteQueryForOneResult(sql, null, null).ToString());
            if (SoDongLoi > 0)
            {
                MessageBox.Show("Bạn chưa thể ghi dữ liệu vì có " + SoDongLoi.ToString() + " dòng bị lỗi!\nBạn có thể sửa trực tiếp trên grid hoặc sửa file excel nguồn và tiến hành nhập lại sau khi đã lưu sửa file nguồn", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            //if (NongHo> 0)
            //{
            //    clsHopDong oHD = new clsHopDong(NongHo);
            //    oHD.Load(null, null);
            //    MessageBox.Show("Bạn chưa thể ghi dữ liệu vì trong danh sách các hộ nhận\ntồn tại nông hộ tên: " + oHD.HoTen+" nhận nhiều hơn một lần!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (MessageBox.Show("Bạn chắc chắn ghi dữ liệu diện tích?", "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.lblWaite.Visible = true;
                this.lblWaite.Text = "Vui lòng đợi...";
                this.cmdSave.Enabled = false;
                this.pnBottom.Refresh();
                this.lblWaite.Refresh();
                try
                {
                    DBModule.ExecuteNonQuery("sp_NhapDienTichCBDB_ImportExcel " + MDSolutionApp.VuTrongID.ToString() + "," + CBNV_ID.ToString(), null, null);
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
            if (this.gdDSThuaRuong.RowCount > 0)
            {
                try
                {
                    if (saveFileDialog_Excel.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog_Excel.FileName, System.IO.FileMode.Create))
                        {
                            Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                            exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                            exporter.GridEX = gdDSThuaRuong;
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
            long CBNV_ID = -1;
            long Import_ID = -1;
            try
            {
                CBNV_ID = long.Parse(this.gdDSThuaRuong.GetValue("CanBoNongVuID").ToString());
                Import_ID = long.Parse(this.gdDSThuaRuong.GetValue("ID").ToString());
            }
            catch
            {
                return;
            }
            if (e.Column.Key == "Sua")
            {
                MDSolution.MDForms.DienTich.frm_SuaNhapDienTich frm = new frm_SuaNhapDienTich(CBNV_ID,TenCBNV,Import_ID);
                frm.ShowDialog();
                if (frm.OK > 0)
                {
                    try
                    {
                        LoadDaTaDienTich();
                        GridEXFilterCondition condi = new GridEXFilterCondition(this.gdDSThuaRuong.RootTable.Columns["ID"], ConditionOperator.Equal, Import_ID);
                        this.gdDSThuaRuong.Find(condi, 0, 1);
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
                    MDSolution.Entities.clsImportDienTich.Delete(Import_ID, null, null);
                    LoadDaTaDienTich();
                }
                catch { }

            }
        }

        private void frm_Temp_Import_DienTich_Load(object sender, EventArgs e)
        {
            lblTitle.Text = lblTitle.Text + MDSolutionApp.VuTrongTen;
            lblCBNV.Text = TenCBNV;
            lblTenFile.Text = TenFile;
            LoadDaTaDienTich();
        }

     

    }
}