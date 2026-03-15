using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using System.Globalization;
using System.Threading;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using MDSolution.MDForms;

namespace MDSolution.MDForms.VanChuyen
{
    public partial class frm_TongHopVanChuyen : Form
    {
        static frm_TongHopVanChuyen _frmTongHopVanChuyen;
        private string IDgdDL_VCselected = "";
       
        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_TongHopVanChuyen OneInstanceFrm
        {
            get
            {
                if (null == _frmTongHopVanChuyen || _frmTongHopVanChuyen.IsDisposed)
                {
                    _frmTongHopVanChuyen = new frm_TongHopVanChuyen();
                }

                return _frmTongHopVanChuyen;
            }
        }
  
        public frm_TongHopVanChuyen()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Load_DL_VanChuyen()
        {
            string sql = "sp_TongHop_Cuoc_Ung_VanChuyen_HopDong " + MDSolutionApp.VuTrongID.ToString() + ",'" + dtTuNgay.Value.ToString("yyyy-MM-dd") + "','" + dtDenNgay.Value.ToString("yyyy-MM-dd 23:59:59") + "'";           
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (IDgdDL_VCselected != "")
                {
                    DataTable reportHopDong = ds.Tables[0];
                    IEnumerable<DataRow> query = from reports in reportHopDong.AsEnumerable()                                                
                                                 where IDgdDL_VCselected.Contains(reports.Field<int>("HopDongVanChuyenID").ToString())
                                                 select reports;
                    DataTable boundTable = query.CopyToDataTable<DataRow>();                    
                    this.gdDL_VC.SetDataBinding(boundTable, "RootTable");
                }
                else {
                    this.gdDL_VC.SetDataBinding(ds.Tables[0], "RootTable");
                }
            }
            else
            {
                this.gdDL_VC.DataSource = null;
            }
        }
       
        private void Load_DL_VanChuyenMia()
        {
            string sql = "sp_TongHop_Cuoc_Ung_VanChuyen " + MDSolutionApp.VuTrongID.ToString() + ",'" + dtTuNgay.Value.ToString("yyyy-MM-dd") + "','" + dtDenNgay.Value.ToString("yyyy-MM-dd 23:59:59") + "',1";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (IDgdDL_VCselected != "")
                {
                    DataTable reportHopDong = ds.Tables[0];
                    IEnumerable<DataRow> query = from reports in reportHopDong.AsEnumerable()
                                                 where IDgdDL_VCselected.Contains(reports.Field<int>("HopDongVanChuyenID").ToString())
                                                 select reports;
                    DataTable boundTable = query.CopyToDataTable<DataRow>();
                    this.gdDS_VCMia.SetDataBinding(boundTable, "RootTable");
                }
                else
                {
                    this.gdDS_VCMia.SetDataBinding(ds.Tables[0], "RootTable");
                }
            }
            else
            {
                this.gdDS_VCMia.DataSource = null;
            }
        }
        private void Load_DL_VanChuyenViSinh()
        {
            string sql = "sp_TongHop_Cuoc_Ung_VanChuyen " + MDSolutionApp.VuTrongID.ToString() + ",'" + dtTuNgay.Value.ToString("yyyy-MM-dd") + "','" + dtDenNgay.Value.ToString("yyyy-MM-dd 23:59:59") + "',2";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDL_ViSinh.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdDL_ViSinh.DataSource = null;
            }
        }
        private void Load_DL_VanChuyenBun()
        {
            string sql = "sp_TongHop_Cuoc_Ung_VanChuyen " + MDSolutionApp.VuTrongID.ToString() + ",'" + dtTuNgay.Value.ToString("yyyy-MM-dd") + "','" + dtDenNgay.Value.ToString("yyyy-MM-dd 23:59:59") + "',3";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDL_Bun.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdDL_Bun.DataSource = null;
            }
        }
        private void Load_DL_VanChuyenPhan()
        {
            string sql = "sp_TongHop_Cuoc_Ung_VanChuyen " + MDSolutionApp.VuTrongID.ToString() + ",'" + dtTuNgay.Value.ToString("yyyy-MM-dd") + "','" + dtDenNgay.Value.ToString("yyyy-MM-dd 23:59:59") + "',4";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDL_PhanCacLoai.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdDL_PhanCacLoai.DataSource = null;
            }
        }
        private void cmdXemDL_Click(object sender, EventArgs e)
        {
            IDgdDL_VCselected = "";
            if (TabTongHopVanChuyen.SelectedIndex == 0)
            {
                Load_DL_VanChuyen();
            }
            if (TabTongHopVanChuyen.SelectedIndex == 1)
            {
                Load_DL_VanChuyenMia();
            }
            if (TabTongHopVanChuyen.SelectedIndex == 2)
            {
                Load_DL_VanChuyenViSinh();
            }
            if (TabTongHopVanChuyen.SelectedIndex == 3)
            {
                Load_DL_VanChuyenBun();
            }
            if (TabTongHopVanChuyen.SelectedIndex == 4)
            {
                Load_DL_VanChuyenPhan();
            }
        }

        private void cmdXuatExcel_Click(object sender, EventArgs e)
        {
            if (TabTongHopVanChuyen.SelectedIndex == 0)
            {
                if (this.gdDL_VC.RowCount > 0)
                {
                    try
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                            {
                                Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                                exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                                exporter.GridEX = gdDL_VC;
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

            if (TabTongHopVanChuyen.SelectedIndex == 1)
            {
                if (this.gdDS_VCMia.RowCount > 0)
                {
                    try
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                            {
                                Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                                exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                                exporter.GridEX = gdDS_VCMia;
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
            if (TabTongHopVanChuyen.SelectedIndex == 2)
            {
                if (this.gdDL_ViSinh.RowCount > 0)
                {
                    try
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                            {
                                Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                                exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                                exporter.GridEX = gdDL_ViSinh;
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
            if (TabTongHopVanChuyen.SelectedIndex == 3)
            {
                if (this.gdDL_Bun.RowCount > 0)
                {
                    try
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                            {
                                Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                                exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                                exporter.GridEX = gdDL_Bun;
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
            if (TabTongHopVanChuyen.SelectedIndex == 4)
            {
                if (this.gdDL_PhanCacLoai.RowCount > 0)
                {
                    try
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                            {
                                Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                                exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                                exporter.GridEX = gdDL_PhanCacLoai;
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
        }

        private void gdChiTietCapVT_ChuyenDT_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e.Row.RowType == RowType.Record)
            {
                string DaChuyenDT = e.Row.Cells["NguoiChuyen"].Value.ToString();
                if (DaChuyenDT != "")
                {
                    e.Row.CheckState = RowCheckState.Checked;
                    Janus.Windows.GridEX.GridEXFormatStyle CHD_format = new GridEXFormatStyle();
                    CHD_format.ForeColor = Color.DarkOrchid;
                    e.Row.RowStyle = CHD_format;
                }
            }
        }

       
   
        private void frm_TongHopVanChuyen_Load(object sender, EventArgs e)
        {
            lblTitle.Text = lblTitle.Text + MDSolutionApp.VuTrongTen;
            DataSet ds = DBModule.ExecuteQuery("select YEAR(GETDATE()) as Nam, MONTH(GETDATE()) as Thang, DAY(GETDATE()) as Ngay", null, null);
            int Nam = int.Parse(ds.Tables[0].Rows[0]["Nam"].ToString());
            int Thang = int.Parse(ds.Tables[0].Rows[0]["Thang"].ToString());
            int Ngay = int.Parse(ds.Tables[0].Rows[0]["Ngay"].ToString());
            dtDenNgay.Value = new DateTime(Nam, Thang, Ngay, 0, 0, 0);
            dtTuNgay.Value = dtDenNgay.Value.AddMonths(-6);
                //.AddYears(-1);
            Load_DL_VanChuyen();
        }

        private void TabTongHopVanChuyen_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (e.Page.Index == 0)
            {
                Load_DL_VanChuyen();
            }
            if (e.Page.Index == 1)
            {
                Load_DL_VanChuyenMia();
            }
            if (e.Page.Index == 2)
            {
                Load_DL_VanChuyenViSinh();
            }
            if (e.Page.Index == 3)
            {
                Load_DL_VanChuyenBun();
            }
            if (e.Page.Index == 4)
            {
                Load_DL_VanChuyenPhan();
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            frmShowRP2 frm = new frmShowRP2();
            System.Data.DataTable dt =new DataTable();
            if (TabTongHopVanChuyen.SelectedIndex == 0)
            {
                Load_DL_VanChuyen();
                if (this.gdDL_VC.RowCount > 0)
                {
                    MDSolution.MDReport.VanChuyen.rpt_BangKeThanhToanVC rp = new MDSolution.MDReport.VanChuyen.rpt_BangKeThanhToanVC();
                    dt = (System.Data.DataTable)gdDL_VC.DataSource;
                    rp.Database.Tables[0].SetDataSource(dt);
                    frm.RP = rp;
                    rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                    frm.RPtitle = "Tổng hợp vận chuyển";
                    rp.SetParameterValue("Tu", dtTuNgay.Value.ToString("dd/MM/yyyy"));
                    rp.SetParameterValue("Den", dtDenNgay.Value.ToString("dd/MM/yyyy"));
                    rp.SetParameterValue("TenVu", MDSolutionApp.VuTrongTen);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            if (TabTongHopVanChuyen.SelectedIndex == 1)
            {
                Load_DL_VanChuyenMia();
                if (this.gdDS_VCMia.RowCount > 0)
                {
                    MDSolution.MDReport.VanChuyen.rpt_BangKeThanhToanVC_Mia rp = new MDSolution.MDReport.VanChuyen.rpt_BangKeThanhToanVC_Mia();
                    dt = (System.Data.DataTable)gdDS_VCMia.DataSource;
                    rp.Database.Tables[0].SetDataSource(dt);
                    frm.RP = rp;
                    rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                    frm.RPtitle = "Tổng hợp cước vận chuyển mía";
                    rp.SetParameterValue("Tu", dtTuNgay.Value.ToString("dd/MM/yyyy"));
                    rp.SetParameterValue("Den", dtDenNgay.Value.ToString("dd/MM/yyyy"));
                    rp.SetParameterValue("TenVu", MDSolutionApp.VuTrongTen);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            if (TabTongHopVanChuyen.SelectedIndex == 2)
            {
                if (this.gdDL_ViSinh.RowCount > 0)
                {
                    MDSolution.MDReport.VanChuyen.rpt_BangKeThanhToanVC_PhanViSinh rp = new MDSolution.MDReport.VanChuyen.rpt_BangKeThanhToanVC_PhanViSinh();
                    dt = (System.Data.DataTable)gdDL_ViSinh.DataSource;
                    rp.Database.Tables[0].SetDataSource(dt);
                    frm.RP = rp;
                    rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                    frm.RPtitle = "Tổng hợp cước vận chuyển vi sinh";
                    rp.SetParameterValue("Tu", dtTuNgay.Value.ToString("dd/MM/yyyy"));
                    rp.SetParameterValue("Den", dtDenNgay.Value.ToString("dd/MM/yyyy"));
                    rp.SetParameterValue("TenVu", MDSolutionApp.VuTrongTen);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            if (TabTongHopVanChuyen.SelectedIndex == 3)
            {
                if (this.gdDL_Bun.RowCount > 0)
                {
                    MDSolution.MDReport.VanChuyen.rpt_BangKeThanhToanVC_Bun rp = new MDSolution.MDReport.VanChuyen.rpt_BangKeThanhToanVC_Bun();
                    dt = (System.Data.DataTable)gdDL_Bun.DataSource;
                    rp.Database.Tables[0].SetDataSource(dt);
                    frm.RP = rp;
                    rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                    frm.RPtitle = "Tổng hợp cước vận chuyển bùn";
                    rp.SetParameterValue("Tu", dtTuNgay.Value.ToString("dd/MM/yyyy"));
                    rp.SetParameterValue("Den", dtDenNgay.Value.ToString("dd/MM/yyyy"));
                    rp.SetParameterValue("TenVu", MDSolutionApp.VuTrongTen);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            if (TabTongHopVanChuyen.SelectedIndex == 4)
            {
                if (this.gdDL_PhanCacLoai.RowCount > 0)
                {
                    MDSolution.MDReport.VanChuyen.rpt_BangKeThanhToanVC_PhanCacLoai rp = new MDSolution.MDReport.VanChuyen.rpt_BangKeThanhToanVC_PhanCacLoai();
                    dt = (System.Data.DataTable)gdDL_PhanCacLoai.DataSource;
                    rp.Database.Tables[0].SetDataSource(dt);
                    frm.RP = rp;
                    rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                    frm.RPtitle = "Tổng hợp cước vận chuyển phân các loại";
                    rp.SetParameterValue("Tu", dtTuNgay.Value.ToString("dd/MM/yyyy"));
                    rp.SetParameterValue("Den", dtDenNgay.Value.ToString("dd/MM/yyyy"));
                    rp.SetParameterValue("TenVu", MDSolutionApp.VuTrongTen);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            IDgdDL_VCselected = "";
            Load_DL_VanChuyen();
        }

        private void gdDL_VC_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
        {
            CheckedRowgdDL_VC();            
        }
       
        private void gdDS_VCMia_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
        {
            CheckedRowgdDS_VCMia();
        }
        void CheckedRowgdDL_VC()
        {
            IDgdDL_VCselected = "";
            foreach (GridEXRow jr in this.gdDL_VC.GetCheckedRows())
            {
                IDgdDL_VCselected += string.Format("{0} ", jr.Cells["HopDongVanChuyenID"].Value);
            }
        }

        void CheckedRowgdDS_VCMia()
        {
            IDgdDL_VCselected = "";
            foreach (GridEXRow jr in this.gdDS_VCMia.GetCheckedRows())
            {
                IDgdDL_VCselected += string.Format("{0} ", jr.Cells["HopDongVanChuyenID"].Value);
            }
        }

    }
}