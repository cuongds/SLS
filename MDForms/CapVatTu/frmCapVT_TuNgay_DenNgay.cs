using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using MDSolution.MDReport;

namespace MDSolution.MDForms.CapVatTu
{
    public partial class frmCapVT_TuNgay_DenNgay : Form
    {
        private DataSet gridDataSource;
        static frmCapVT_TuNgay_DenNgay _frmCapVT_TuNgay_DenNgay;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmCapVT_TuNgay_DenNgay OneInstanceFrm
        {
            get
            {
                if (null == _frmCapVT_TuNgay_DenNgay || _frmCapVT_TuNgay_DenNgay.IsDisposed)
                {
                    _frmCapVT_TuNgay_DenNgay = new frmCapVT_TuNgay_DenNgay();
                }

                return _frmCapVT_TuNgay_DenNgay;
            }
        }
        public frmCapVT_TuNgay_DenNgay()
        {
            InitializeComponent();
            LoadData();
        }
        
        public void LoadData()
        {

            string strWhere = "";//" VuTrongID=" + MDSolutionApp.VuTrongID;
            if (!this.dtTuNgay.IsNullDate) strWhere += " AND dbo.tbl_XuatVatTu.NgayLapPhieu>=" + DBModule.RefineDatetime(this.dtTuNgay.Value);
            if (!this.dtDenNgay.IsNullDate) strWhere += " AND dbo.tbl_XuatVatTu.NgayLapPhieu<='" + this.dtDenNgay.Value.ToString("MM/dd/yyyy") + " 23:59:59'";
            string strSQL = @"select TenCanBo,[Thuốc sạch rầy ], [Victory], [Sạch Rày Gold], [Power], [Phân điều hòa PH], [Phân vi sinh], [Phân bùn ủ men], [Basitox], [Phân bón NPK 5.10.3-8], [Đạm URÊ], [Bùn tươi], [Phân NPK bổ sung vi lượng 16-12-8+TE SG (M1)], [Phân NPK bổ sung vi lượng 20-2-20+TE SG (M2)], [Phân NPK 18-10-8+1SiO2 Tiến Nông (M1)], [Phân NPK 16-6-18+1SiO2 Tiến Nông (M2)], [Diaza 10GR], [Đạm Xanh urê], [Trừ cỏ Wam rin 800], [Trừ cỏ Aviator 800], [Bùn tươi (bán tại công ty)], [Thuốc trừ sâu Sairifos 585EC/450cc], [Bã bùn], [Thuốc Gà nòi 95SP/20 gr] AS ganoi,[Thuốc Fenbis 25EC/450 ml] AS fenbis,[Thuốc Bifentox 30EC/450 ml] AS  bifentox ,[Thuốc sâu (TARON 250 ml)] AS TARON250,[Thuốc sâu (TARON 100 ml)] AS TARON100,[Bã bùn L1] AS BaBunL1,[Phân vi sinh ( bón lót)] AS PVSBL,[Phân vi sinh (bón thúc)] AS PVSBT ,[Bã bùn L2] AS BaBunL2,[Phân NPK 15-5-20 + TE SG (M2)] as TESGM2,[Phân NPK 15-5-20 TN (M2)] as TNM2  from " 
           + "(SELECT   dbo.tbl_DanhMucCanBoNongVu.Ten AS TenCanBo, dbo.tbl_DanhMucDauTu.Ten AS TenVatTu, dbo.tbl_XuatVatTu.TrongLuongHoaDon AS SoLuong FROM dbo.tbl_DanhMucDauTu INNER JOIN dbo.tbl_XuatVatTu ON dbo.tbl_DanhMucDauTu.ID = dbo.tbl_XuatVatTu.VatTuID INNER JOIN dbo.tbl_DanhMucCanBoNongVu ON dbo.tbl_XuatVatTu.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.ID Where tbl_XuatVatTu.VuTrongID= " + MDSolutionApp.VuTrongID + strWhere
           + ") ps PiVot (sum(SoLuong) for TenVatTu In ([Thuốc sạch rầy ], [Victory], [Sạch Rày Gold], [Power], [Phân điều hòa PH], [Phân vi sinh], [Phân bùn ủ men], [Basitox], [Phân bón NPK 5.10.3-8], [Đạm URÊ], [Bùn tươi],[Phân NPK bổ sung vi lượng 16-12-8+TE SG (M1)], [Phân NPK bổ sung vi lượng 20-2-20+TE SG (M2)], [Phân NPK 18-10-8+1SiO2 Tiến Nông (M1)], [Phân NPK 16-6-18+1SiO2 Tiến Nông (M2)], [Diaza 10GR], [Đạm Xanh urê], [Trừ cỏ Wam rin 800], [Trừ cỏ Aviator 800], [Bùn tươi (bán tại công ty)], [Thuốc trừ sâu Sairifos 585EC/450cc], [Bã bùn], [Thuốc Gà nòi 95SP/20 gr],[Thuốc Fenbis 25EC/450 ml],[Thuốc Bifentox 30EC/450 ml],[Thuốc sâu (TARON 250 ml)],[Thuốc sâu (TARON 100 ml)],[Bã bùn L1],[Phân vi sinh ( bón lót)],[Phân vi sinh (bón thúc)],[Bã bùn L2],[Phân NPK 15-5-20 + TE SG (M2)] ,[Phân NPK 15-5-20 TN (M2)])) AS pvt";
           //  + " WHERE " + strWhere;
            //MessageBox.Show(strSQL);
            this.gridDataSource = DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.grdVatTong.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");

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
                saveFileDialog1.FileName = "VatTu_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = grdVatTong;
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

        private void frmCapVT_TuNgay_DenNgay_Load(object sender, EventArgs e)
        {           
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
           
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
           
        }

        private void grdMiaGiong_ColumnHeaderClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "[Thuốc sạch rầy ]")
            {
                this.grdVatTong.RootTable.Columns["[Thuốc sạch rầy ]"].Visible = false;
            }

            if (e.Column.Key == "[Victory] ")
            {
                this.grdVatTong.RootTable.Columns["[Victory] "].Visible = false;
            }

            if (e.Column.Key == "[Sạch Rày Gold]")
            {
                this.grdVatTong.RootTable.Columns["[Sạch Rày Gold]"].Visible = false;
            }

            if (e.Column.Key == "[Power]")
            {
                this.grdVatTong.RootTable.Columns["[Power]"].Visible = false;
            }

            if (e.Column.Key == "[Phân điều hòa PH]")
            {
                this.grdVatTong.RootTable.Columns["[Phân điều hòa PH]"].Visible = false;
            }

            if (e.Column.Key == "[Phân vi sinh]")
            {
                this.grdVatTong.RootTable.Columns["[Phân vi sinh]"].Visible = false;
            }

            if (e.Column.Key == "[Phân bùn ủ men]")
            {
                this.grdVatTong.RootTable.Columns["[Phân bùn ủ men]"].Visible = false;
            }

            if (e.Column.Key == "[Basitox]")
            {
                this.grdVatTong.RootTable.Columns["[Basitox]"].Visible = false;
            }

            if (e.Column.Key == "[Phân bón NPK 5.10.3-8]")
            {
                this.grdVatTong.RootTable.Columns["[Phân bón NPK 5.10.3-8]"].Visible = false;
            }

            if (e.Column.Key == "[Đạm URÊ]")
            {
                this.grdVatTong.RootTable.Columns["[Đạm URÊ]"].Visible = false;
            }
            if (e.Column.Key == "[Bùn tươi]")
            {
                this.grdVatTong.RootTable.Columns["[Bùn tươi]"].Visible = false;
            }
            if (e.Column.Key == "[Phân bón NPK 16.10.14+2.5(TN)]")
            {
                this.grdVatTong.RootTable.Columns["[Phân bón NPK 16.10.14+2.5(TN)]"].Visible = false;
            }
            if (e.Column.Key == "[Phân bón NPK15.10.15(SG)]")
            {
                this.grdVatTong.RootTable.Columns["[Phân bón NPK15.10.15(SG)]"].Visible = false;
            }
            if (e.Column.Key == "[Phân bón  NPKSI18.2.22+1.5(TN-M2)]")
            {
                this.grdVatTong.RootTable.Columns["[Phân bón  NPKSI18.2.22+1.5(TN-M2)]"].Visible = false;
            }
            if (e.Column.Key == "[Phân bón NPK 20.5.20(SG-M2)]")
            {
                this.grdVatTong.RootTable.Columns["[Phân bón NPK 20.5.20(SG-M2)]"].Visible = false;
            }
            if (e.Column.Key == "[Diaza 10GR]")
            {
                this.grdVatTong.RootTable.Columns["[Diaza 10GR]"].Visible = false;
            }
            if (e.Column.Key == "[Đạm Xanh urê]")
            {
                this.grdVatTong.RootTable.Columns["[Đạm Xanh urê]"].Visible = false;
            }
            if (e.Column.Key == "[Trừ cỏ Wam rin 800]")
            {
                this.grdVatTong.RootTable.Columns["[Trừ cỏ Wam rin 800]"].Visible = false;
            }
            if (e.Column.Key == "[Trừ cỏ Aviator 800]")
            {
                this.grdVatTong.RootTable.Columns["[Trừ cỏ Aviator 800]"].Visible = false;
            }
            if (e.Column.Key == "[Bùn tươi (bán tại công ty)]")
            {
                this.grdVatTong.RootTable.Columns["[Bùn tươi (bán tại công ty)]"].Visible = false;
            }

            if (e.Column.Key == "[Thuốc trừ sâu Sairifos 585EC/450cc]")
            {
                this.grdVatTong.RootTable.Columns["[Thuốc trừ sâu Sairifos 585EC/450cc]"].Visible = false;
            }
            if (e.Column.Key == "[Thuốc sâu (TARON 100 ml)]")
            {
                this.grdVatTong.RootTable.Columns["[Thuốc sâu (TARON 100 ml)]"].Visible = false;
            }
            if (e.Column.Key == "[Thuốc sâu (TARON 250 ml)]")
            {
                this.grdVatTong.RootTable.Columns["[Thuốc sâu (TARON 250 ml)]"].Visible = false;
            }
            if (e.Column.Key == "[Bã bùn L1]")
            {
                this.grdVatTong.RootTable.Columns["[Bã bùn L1]"].Visible = false;
            }
            if (e.Column.Key == "[Phân vi sinh ( bón lót)]")
            {
                this.grdVatTong.RootTable.Columns["[Phân vi sinh ( bón lót)]"].Visible = false;
            }
            if (e.Column.Key == "[Phân vi sinh (bón thúc)]")
            {
                this.grdVatTong.RootTable.Columns["[Phân vi sinh (bón thúc)]"].Visible = false;
            }
            if (e.Column.Key == "[Bã bùn]")
            {
                this.grdVatTong.RootTable.Columns["[Bã bùn]"].Visible = false;
            }
            LoadData();
        }
    }
}
