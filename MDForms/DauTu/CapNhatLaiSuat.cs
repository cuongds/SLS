using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Janus.Windows.GridEX;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using MDSolution.MDForms.NhapMia;
namespace MDSolution.MDForms.DauTu
{
    public partial class CapNhatLaiSuat : Form
    {
        private DataSet gridDataSource;
        static CapNhatLaiSuat _CapNhatLaiSuat;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public CapNhatLaiSuat OneInstanceFrm
        {
            get
            {
                if (null == _CapNhatLaiSuat || _CapNhatLaiSuat.IsDisposed)
                {
                    _CapNhatLaiSuat = new CapNhatLaiSuat();
                }

                return _CapNhatLaiSuat;
            }
        }
        public CapNhatLaiSuat()
        {
            InitializeComponent();
        }

      
        public void LoadData()
        {
            string strSQL = "select t.*,c.HoTen as HCT_HoTen, c.MaHopDong as HCT_Ma,c.Diachi, hd.HoTen as CHD_HoTen, hd.MaHDDT,hd.NQL,hd.LoaiHD from V_DauTu t "
            + " left join tbl_HopDong c on c.ID = t.HopDongID"
            + " left join V_HDDT hd on t.HDDTID=hd.ID  WHERE hd.VuTrongID="+MDSolutionApp.VuTrongID.ToString()+"  ORDER BY HopDongID";

            this.gridDataSource = DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gdChiTietDauTu.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");
                foreach (Janus.Windows.GridEX.GridEXRow row in gdChiTietDauTu.GetDataRows())
                {
                    if (row.RowType == RowType.Record)
                    {
                        row.BeginEdit();
                        if ((!Convert.IsDBNull(row.Cells["SoTien"].Value)) && (!Convert.IsDBNull(row.Cells["TraGoc"].Value)))
                        {
                            row.Cells["GocConLai"].Value = (decimal)row.Cells["SoTien"].Value - (decimal)row.Cells["TraGoc"].Value;
                        }

                        row.EndEdit();
                    }
                }
            }

        }



        private void btnXuatExcelHopDong_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.FileName = "SLS_bang_laisuat_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = gdChiTietDauTu;
                        exporter.Export(fs);
                        fs.Close();
                        Excel.Application xlApp;
                        Excel.Workbook xlWorkBook;
                        xlApp = Export2Excel.TryGetExistingExcelApplication();
                        if (xlApp == null)
                        {
                            xlApp = new Excel.Application();
                        }
                        xlWorkBook = xlApp.Workbooks.Open(saveFileDialog.FileName);
                        xlApp.Visible = true;
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnChuyenNgay_Click(object sender, EventArgs e)
        {
            dlgThayDoiLaiSuat dlg = new dlgThayDoiLaiSuat();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    decimal laiSuat = dlg.laiSuat;
                    DateTime ngayTinhLai = dlg.ngayTinh;
                    foreach (Janus.Windows.GridEX.GridEXRow dr in gdChiTietDauTu.GetCheckedRows())
                    {
                        long ID = long.Parse(dr.Cells["ID"].Value.ToString());

                        clsDauTu.ThayDoiLaiSuat(ID, laiSuat, ngayTinhLai, null, null);

                    }
                   // clsThuaRuong.UpdateKeHoach("", null, null);
                }
                catch { }
                LoadData();
            };
        }

        private void cmdAddHD_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CapNhatLaiSuat_Load(object sender, EventArgs e)
        {
            lblTitle.Text = lblTitle.Text + MDSolutionApp.VuTrongTen;
            if (MDSolutionApp.User.ID != 1)
            {
                btnChuyenNgay.Enabled = false;
            }
            LoadData();
        }
    }
}
