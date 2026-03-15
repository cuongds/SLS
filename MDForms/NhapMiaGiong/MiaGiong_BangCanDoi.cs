using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using MDSolution.MDReport;
using System.IO;
using System.Xml.Xsl;
using System.Xml;

namespace MDSolution.MDForms.NhapMiaGiong
{
    public partial class MiaGiong_BangCanDoi : Form
    {
        private DataSet gridDataSource;
        static MiaGiong_BangCanDoi _MiaGiong_BangCanDoi;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public MiaGiong_BangCanDoi OneInstanceFrm
        {
            get
            {
                if (null == _MiaGiong_BangCanDoi || _MiaGiong_BangCanDoi.IsDisposed)
                {
                    _MiaGiong_BangCanDoi = new MiaGiong_BangCanDoi();
                }

                return _MiaGiong_BangCanDoi;
            }
        }
        public MiaGiong_BangCanDoi()
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
        //public void LoadData()
        //{
        //    if (cboCanBoNV.SelectedIndex < 0)
        //    {
        //        cboCanBoNV.SelectedValue = -1;
        //    }
        //    string strWhere = " VuTrongID=" + MDSolutionApp.VuTrongID ;
        //    if (cboCanBoNV.SelectedValue.ToString() != "-1") strWhere += " AND CanBoNongVuID =" + cboCanBoNV.SelectedValue.ToString();
        //    if (!this.dtTuNgay.IsNullDate) strWhere += " AND NgayLap>=" + DBModule.RefineDatetime(this.dtTuNgay.Value);
        //    if (!this.dtDenNgay.IsNullDate) strWhere += " AND NgayLap<='" + this.dtDenNgay.Value.ToString("MM/dd/yyyy") + " 23:59:59'";

        //    string strSQL = "select * from V2016_NhapMiaGiong "         
        //    + " WHERE " + strWhere ;
        //    //MessageBox.Show(strSQL);
        //    this.gridDataSource = DBModule.ExecuteQuery(strSQL, null, null);
        //    if (this.gridDataSource.Tables.Count > 0)
        //    {
        //        this.grdMiaGiong.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");

        //    }



        //}
        private DataSet _ds;
        public void LoadHTML(DataSet ds, string fileTemp)
        {
            try
            {
                _ds = ds;
                //                string sql = @"SELECT *
                //                          FROM V2016_ChietTinhTruNoDauTu_NhapMia where (DaThanhToan >0) ";
                //                DataSet ds = DBModule.ExecuteQuery(sql, null, null);

                StringWriter sw1 = new StringWriter();
                ds.WriteXml(sw1);

                string inputXML = sw1.ToString();
                string transformXSL = System.IO.File.ReadAllText(fileTemp);

                XslCompiledTransform proc = new XslCompiledTransform();

                using (StringReader sr = new StringReader(transformXSL))
                {
                    using (XmlReader xr = XmlReader.Create(sr))
                    {
                        proc.Load(xr);
                    }
                }

                string resultXML;

                using (StringReader sr = new StringReader(inputXML))
                {
                    using (XmlReader xr = XmlReader.Create(sr))
                    {
                        using (StringWriter sw = new StringWriter())
                        {
                            proc.Transform(xr, null, sw);
                            resultXML = sw.ToString();
                        }
                    }
                }
                wvMain.DocumentText = resultXML;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show(ex.InnerException.Message);
            }
        }
        private void cmdAddHD_Click(object sender, EventArgs e)
        {
            string msg = "";
            DateTime dts = DateTime.Now;
            string sql = @"SELECT   (select COUNT(*) from tbl_DauTu where SoChungTu=Giao_MaPhieu) as SoLuongPhieu ,
                                    [Giao_TenCBDB]
                                  ,[Giao_Ban]
                                  ,[Giao_MaHD]
                                  ,[Giao_TenHD]
                                  ,[Giao_MaPhieu]
                                  ,[Giao_SL]
                                  ,[Giao_Gia]
                                  ,[Giao_Tien]
                                  ,[TenCBNV]
                                  ,[MaHopDong]
                                  ,[HoTen]
                                  ,isnull([SoLuong],0)as [SoLuong]
                                  ,isnull([DonGia],0) as [DonGia]
                                  ,isnull([SoTien],0) as [SoTien]
                                  ,[TenThonBan]
                                  ,[VuTrongID]
                                  ,[VuTrong]
                                  ,[NgayLap]
                                  ,[CanBoNongVuID] 
                            FROM  [V2016_CanDoiMiaGiong] where ";
            if (cboCanBoNV.SelectedIndex < 0)
            {
                cboCanBoNV.SelectedValue = -1;
            }
            string strWhere = " VuTrongID=" + MDSolutionApp.VuTrongID;
            if (cboCanBoNV.SelectedValue.ToString() != "-1") strWhere += " AND CanBoNongVuID =" + cboCanBoNV.SelectedValue.ToString();
            if (!this.dtTuNgay.IsNullDate) strWhere += " AND NgayLap>=" + DBModule.RefineDatetime(this.dtTuNgay.Value);
            if (!this.dtDenNgay.IsNullDate) strWhere += " AND NgayLap<='" + this.dtDenNgay.Value.ToString("MM/dd/yyyy") + " 23:59:59'";

            DataSet ds = DBModule.ExecuteQuery(sql + strWhere + " order by Giao_MaPhieu", null, null);
            ds.Tables[0].Columns.Add("Giao_index");
            //Test:
            msg += "EXE Qry:" + (DateTime.Now - dts);
            dts = DateTime.Now;
            for (int i = 0; i < ds.Tables[0].Rows.Count; )
            {
                DataRow dr = ds.Tables[0].Rows[i];
                ds.Tables[0].Rows[i]["Giao_index"] = i + 1;
                int SoLuongPhieu = (int)dr["SoLuongPhieu"];
                if (SoLuongPhieu == 0) SoLuongPhieu = 1;
                i += SoLuongPhieu;
                if (SoLuongPhieu > 1)
                    ds.Tables[0].Rows[i - 1]["Giao_index"] = -1;//dòng cuối
            }
            msg += "For:" + (DateTime.Now - dts);
            dts = DateTime.Now;
            LoadHTML(ds, Application.StartupPath + "\\temps\\BangCanDoiGiong_html.xls");
            msg += "Load:" + (DateTime.Now - dts);
            MessageBox.Show(msg);
            //LoadData();
        }

        private void btnXuatExcelHopDong_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.ShowDialog();
                //saveFileDialog1.Filter = "xls";
                System.IO.File.WriteAllText(saveFileDialog1.FileName, wvMain.DocumentText);

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void MiaGiong_BangCanDoi_Load(object sender, EventArgs e)
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



        private void btnInPhieu_Click(object sender, EventArgs e)
        {
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
