using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace MDSolution.MDForms
{
    public partial class frm_ShowDinhMucDauTu : Form
    {
        private DataSet gridDataSource;
        static frm_ShowDinhMucDauTu _frm_ShowDinhMucDauTu;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_ShowDinhMucDauTu OneInstanceFrm
        {
            get
            {
                if (null == _frm_ShowDinhMucDauTu|| _frm_ShowDinhMucDauTu.IsDisposed)
                {
                    _frm_ShowDinhMucDauTu = new frm_ShowDinhMucDauTu();
                }

                return _frm_ShowDinhMucDauTu;
            }
        }
        private NodeCanBoNongVu nDonVi = new NodeCanBoNongVu();
        private string PhamVi = "Tất cả CBNV";
        public frm_ShowDinhMucDauTu()
        {
            InitializeComponent();
        }
        public void LoadData(string CBNVID,string VTID,string THONID)
        {
            string sql = "sp_RP_HopDongDienTichDinhMucDauTu " +CBNVID+","+ VTID + "," + THONID;
                this.gridDataSource = DBModule.ExecuteQuery(sql, null, null);
                if (this.gridDataSource.Tables.Count > 0)
                {
                    this.gdDinhMucDauTu.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");
                }
                else
                {
                    this.gdDinhMucDauTu.DataSource = DBNull.Value;
                }

        }
      
        private void btnXuatExcelHopDong_Click(object sender, EventArgs e)
        {
           
        }
        private void LoadVuTrong()
        {
            DataSet ds = new DataSet();
            clsVuTrong.GetList("", out ds, null, null);
            ComboVuTrong.DataSource = ds.Tables[0];
            ComboVuTrong.DisplayMember = "Ten";
            ComboVuTrong.ValueMember = "ID";
            ComboVuTrong.SelectedValue = MDSolutionApp.VuTrongID;
        
        }
     
     
        private void ComboVuTrong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboVuTrong.SelectedIndex >= 0)
            {
                LoadData("NULL",ComboVuTrong.SelectedValue.ToString(), "NULL");
                lblTitle.Text = "DỮ LIỆU ĐỊNH MỨC ĐẦU TƯ SLS NIÊN VỤ " + ComboVuTrong.Text;
                PhamVi= "Tất cả CBNV";
                grDL.Text = PhamVi;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_ShowDinhMucDauTu_Load(object sender, EventArgs e)
        {
            LoadVuTrong();
            ComboVuTrong.SelectedValue = MDSolutionApp.VuTrongID;
            CommonClass.loadTreeHopDongCanBoNongVu(tvDonVi);
        }

        private void tvDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           string VT=MDSolutionApp.VuTrongID.ToString();
            if (tvDonVi.SelectedNode != null)
            {
                if (nDonVi.CBNVType == CBNVType.Root)
                {
                    LoadData("NULL", VT, "NULL");
                    PhamVi = "Tất cả CBNV";
                }
                if (nDonVi.CBNVType == CBNVType.CBNV)
                {
                    LoadData(nDonVi.CBNVID, VT, "NULL");
                    PhamVi = nDonVi.CBNVName;
                }
                if (nDonVi.CBNVType == CBNVType.ThonID)
                {
                    LoadData("NULL", VT, nDonVi.CBNVID);
                    PhamVi = "Bản " + nDonVi.CBNVName;
                }
                grDL.Text = PhamVi;
            }
        }

        private void tvDonVi_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvDonVi.SelectedNode != null)
            {
                nDonVi = (NodeCanBoNongVu)tvDonVi.SelectedNode.Tag;
            }
        }

        private void btnXuatExcelDinhMucDauTu_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.FileName = "DauTuDinhMuc" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = gdDinhMucDauTu;
                        exporter.Export(fs);
                        fs.Close();
                        MessageBox.Show("Xuất dữ liệu ra Excel!", "SLS", MessageBoxButtons.OK);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "SLS", MessageBoxButtons.OK);
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (gdDinhMucDauTu.DataSource!=DBNull.Value)
            {
                frmShowRP2 frm = new frmShowRP2();
                MDReport.BCHopDongDienTichDauTu rp = new MDReport.BCHopDongDienTichDauTu();
                System.Data.DataTable dt = (System.Data.DataTable)gdDinhMucDauTu.DataSource;
                rp.Database.Tables[0].SetDataSource(dt);
                rp.SetParameterValue("PhamVi", PhamVi);
                frm.RP = rp;
                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.RPtitle = "Chi tiết đầu tư - định mức";
                frm.Show();
            }
        }

      
    }
}
