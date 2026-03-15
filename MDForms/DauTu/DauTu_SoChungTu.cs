using Janus.Windows.GridEX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms; 

namespace MDSolution.MDForms.DauTu
{
    public partial class DauTu_SoChungTu : Form
    {
        static DauTu_SoChungTu _DauTu_SoChungTu;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public DauTu_SoChungTu OneInstanceFrm
        {
            get
            {
                if (null == _DauTu_SoChungTu || _DauTu_SoChungTu.IsDisposed)
                {
                    _DauTu_SoChungTu = new DauTu_SoChungTu();
                }

                return _DauTu_SoChungTu;
            }
        }
        private DataSet gridDataSource;
        public DauTu_SoChungTu()
        {
            InitializeComponent();
        }
        public void LoadData(){
         string strWhere = "";
            strWhere += " t.NgayDauTu>=" + DBModule.RefineDatetime(this.dtTuNgay.Value);
            strWhere += " AND t.NgayDauTu<" + DBModule.RefineDatetime(this.dtDenNgay.Value);
            string strSQL = "select t.*,hd.SoTKKT, c.HoTen as HCT_HoTen, c.MaHopDong as HCT_Ma,hd.MaHopDong as CHD_Ma, hd.HopDongID as CHD_ID, hd.HoTen as CHD_HoTen, hd.MaHDDT,hd.NQL,hd.LoaiHD from V_DauTu t "
            + " left join tbl_HopDong c on c.ID = t.HopDongID"
            + " left join V_HDDT hd on t.HDDTID=hd.ID  WHERE " + strWhere;
            
            this.gridDataSource = DBModule.ExecuteQuery(strSQL, null, null);
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
                saveFileDialog1.FileName = "trasuco_dautu_" + DateTime.Now.ToString("yyyyMMddhhmmss")+".xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = gdChiTietDauTu;
                        exporter.Export(fs);
                        fs.Close();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void gdChiTietDauTu_UpdatingCell(object sender, Janus.Windows.GridEX.UpdatingCellEventArgs e)
        {
            try
            {
                if (e.Column.Key == "SoChungTu" || e.Column.Key == "NgayChungTu")
                {
                    long ID = long.Parse(gdChiTietDauTu.GetValue("ID").ToString());
                    clsDauTu oDT = new clsDauTu(ID);
                    oDT.Load(null, null);
                    if (e.Column.Key == "SoChungTu")
                    {
                        oDT.SoChungTu = e.Value.ToString();
                    }
                    else if (e.Column.Key == "NgayChungTu") {
                        if (e.Value is DBNull)
                        {
                            oDT.NgayChungTu = DateTime.MinValue;
                        }
                        else
                        {
                            oDT.NgayChungTu = System.Convert.ToDateTime(e.Value);
                        }
                        
                    }  
                        
                    oDT.Save(null, null);
                }
                else if (e.Column.Key == "SoTKKT")
                {
                    long CHDID = long.Parse(gdChiTietDauTu.GetValue("CHD_ID").ToString());
                    clsHopDong oHD = new clsHopDong(CHDID);
                    oHD.Load(null, null);
                    oHD.SoTKKT = gdChiTietDauTu.GetValue("SoTKKT").ToString();
                    oHD.Save(null, null);
                    
                }
            }
            catch(Exception ex)
            {
                e.Cancel = true;
                gdChiTietDauTu.CancelCurrentEdit();
                SendKeys.SendWait("{ESC}");
                MessageBox.Show("Có lỗi khi lưu dữ liệu!" + ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void gdChiTietDauTu_CellUpdated(object sender, ColumnActionEventArgs e)
        {
            
        }

        private void gdChiTietDauTu_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
            {
                string s = e.Row.Cells["SoChungTu"].Value.ToString();
                if (s.Length > 0)
                {
                    Janus.Windows.GridEX.GridEXFormatStyle rowcol = new GridEXFormatStyle();
                    rowcol.BackColor = Color.LightGreen;                 
                    e.Row.RowStyle = rowcol;
                }

            }
        }
    }
}
