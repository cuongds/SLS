using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using MDSolution.MDForms;
namespace MDSolution
{
    public partial class frm_TraCuuTT_VanChuyen : Form
    {
        static frm_TraCuuTT_VanChuyen _frm_TraCuuTT_VanChuyen;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_TraCuuTT_VanChuyen OneInstanceFrm
        {
            get
            {
                if (null == _frm_TraCuuTT_VanChuyen || _frm_TraCuuTT_VanChuyen.IsDisposed)
                {
                    _frm_TraCuuTT_VanChuyen = new frm_TraCuuTT_VanChuyen();
                }

                return _frm_TraCuuTT_VanChuyen;
            }
        }
        private DataSet dsHopDongVanChuyen;
        public frm_TraCuuTT_VanChuyen()
        {
            InitializeComponent();
        }
        public void LoadHopDongVanChuyen()
        {
            string strSQL = "SELECT HD.ID As HopDongVanChuyenID, HD.MaHopDong,HD.TenChuHopDong,HD.CMT,HD.NgayCapCMT,HD.NoiCap,HD.NguyenQuan,HD.DiaChi,HD.SoTKNganHang,HD.NgayHopDong,HD.DienThoai,HD.MaSoThue," +
                           "HD.DaChuyenVu, XE.ID as XeVanChuyenID, XE.SoXe, XE.TenLaiXe, XE.TrongTai,XE.LoaiXe, XE.GhiChu" +
                           " From dbo.tbl_XeVanChuyen As XE RIGHT OUTER JOIN dbo.tbl_HopDongVanChuyen As HD ON XE.HopDongVanChuyenID = HD.ID" +
                           " Where HD.VuTrongID= " + MDSolutionApp.VuTrongID.ToString() + " Order By LEN(HD.MaHopDong),HD.MaHopDong";
            this.dsHopDongVanChuyen = DBModule.ExecuteQuery(strSQL,null, null);
            if (this.dsHopDongVanChuyen.Tables.Count > 0)
            {
                this.gdVHopDongVanChuyen.SetDataBinding(this.dsHopDongVanChuyen.Tables[0], "RootTable");
            }
        }
      
    
      
        private void frm_TraCuuTT_VanChuyen_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            lblTitleHDVC.Text = lblTitleHDVC.Text +" "+ MDSolutionApp.VuTrongTen;
            DataSet ds = DBModule.ExecuteQuery("select YEAR(GETDATE()) as Nam, MONTH(GETDATE()) as Thang, DAY(GETDATE()) as Ngay", null, null);
            int Nam = int.Parse(ds.Tables[0].Rows[0]["Nam"].ToString());
            int Thang = int.Parse(ds.Tables[0].Rows[0]["Thang"].ToString());
            int Ngay = int.Parse(ds.Tables[0].Rows[0]["Ngay"].ToString());
            dtDenNgay.Value = new DateTime(Nam, Thang, Ngay, 0, 0, 0);
            dtTuNgay.Value = dtDenNgay.Value.AddYears(-1);
            LoadData();
        }        

        private void gdVHopDongVanChuyen_FormattingRow(object sender, RowLoadEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Row.Cells["NgayHopDong"].Text))
                {
                    DateTime dt;
                    dt = DateTime.Parse(e.Row.Cells["NgayHopDong"].Text);
                    e.Row.Cells["NgayHopDong"].Text = dt.ToShortDateString();
                }
            }
            catch
            {
                e.Row.Cells["NgayHopDong"].Text = "";
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.F8:
                        
                        //MDSolution.MDDataSetForms.frm_TraCuuTT_VanChuyen_ThemMoi frm = new MDSolution.MDDataSetForms.frm_TraCuuTT_VanChuyen_ThemMoi("");
                        //frm.ShowDialog();
                        //LoadHopDongVanChuyen();
                        break;
                    case Keys.F4:
                    
                        try
                        {
                            if (this.gdVHopDongVanChuyen.GetValue("ID").ToString() != "")
                            {
                                frmChiTietChuVanChuyen abc = new frmChiTietChuVanChuyen(long.Parse(this.gdVHopDongVanChuyen.GetValue("ID").ToString()));
                                abc.ShowDialog();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
                        }
                        break;
                    case Keys.F9:
                        try
                        {
                            if (this.gdVHopDongVanChuyen.GetValue("ID").ToString() != "")
                            {
                                //MDSolution.MDDataSetForms.frm_TraCuuTT_VanChuyen_ThemMoi a = new MDSolution.MDDataSetForms.frm_TraCuuTT_VanChuyen_ThemMoi(this.gdVHopDongVanChuyen.GetValue("ID").ToString());
                                //a.ShowDialog();
                                //LoadHopDongVanChuyen();
                            }
                            else { MessageBox.Show("Bạn chưa chọn hợp đồng để sửa", "Thông báo"); }
                        }
                        catch { MessageBox.Show("Bạn chưa chọn hợp đồng để sửa", "Thông báo"); }
                        break;
                    ////    gdVHopDongVanChuyen.EditMode = EditMode.EditOn;
                    ////    label1.Text = "F2-Lưu / Esc-Bỏ qua";
                    ////    break;
                    ////case Keys.Escape:
                    ////    // Code cho phim Esc
                    ////    gdVHopDongVanChuyen.CancelCurrentEdit();
                    ////    label1.Text = "F8-Thêm mới / F9-Sửa / F4-Chi tiết / Delete-Xóa / F6-In danh sách";
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void btThem_Click(object sender, EventArgs e)
        {
            //MDSolution.MDForms.VanChuyen.frm_TraCuuTT_VanChuyen_ThemMoi frm = new MDSolution.MDForms.VanChuyen.frm_TraCuuTT_VanChuyen_ThemMoi();
            //frm.ShowDialog();
            //if (frm._IDHD > 0)
            //{
            //    try
            //    {
            //        LoadHopDongVanChuyen();
            //        GridEXFilterCondition condi = new GridEXFilterCondition(gdVHopDongVanChuyen.Tables[0].Columns["HopDongVanChuyenID"], ConditionOperator.Equal, frm._IDHD);
            //        gdVHopDongVanChuyen.Find(condi, 0, 1);
            //        MessageBox.Show("Đã thêm mới HĐVC", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    catch { }
            //}
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            long HDVC_ID = -1;
            long XeVC_ID = -1;
            try
            {
                HDVC_ID = long.Parse(this.gdVHopDongVanChuyen.GetValue("HopDongVanChuyenID").ToString());
                XeVC_ID = long.Parse(this.gdVHopDongVanChuyen.GetValue("XeVanChuyenID").ToString());
            }
            catch { }
            if (HDVC_ID > 0)
            {
                //MDSolution.MDForms.VanChuyen.frm_TraCuuTT_VanChuyen_ThemMoi frm = new MDSolution.MDForms.VanChuyen.frm_TraCuuTT_VanChuyen_ThemMoi(HDVC_ID, XeVC_ID);
                //frm.ShowDialog();
                //if (frm._IDHD > 0)
                //{
                //    try
                //    {
                //        LoadHopDongVanChuyen();
                //        GridEXFilterCondition condi = new GridEXFilterCondition(gdVHopDongVanChuyen.Tables[0].Columns["HopDongVanChuyenID"], ConditionOperator.Equal, frm._IDHD);
                //        gdVHopDongVanChuyen.Find(condi, 0, 1);
                //        MessageBox.Show("Đã sửa HĐVC", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    catch { }
                //}
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn hợp đồng vận chuyển để sửa", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }

      
     
        private void cmd2Excel_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.FileName = "Danhsach_Hopdongvanchuyen_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = gdVHopDongVanChuyen;
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
             
      
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdChuyenVu_Click(object sender, EventArgs e)
        {
            long HDVC_ID = -1;
            long XeVC_ID = -1;
            try
            {
                HDVC_ID = long.Parse(this.gdVHopDongVanChuyen.GetValue("HopDongVanChuyenID").ToString());
                XeVC_ID = long.Parse(this.gdVHopDongVanChuyen.GetValue("XeVanChuyenID").ToString());
            }
            catch { }
            if((HDVC_ID>0)&&(XeVC_ID>0))
            {
                MDForms.VanChuyen.frm_ChuyenVu_HDVC frm = new MDForms.VanChuyen.frm_ChuyenVu_HDVC(HDVC_ID, XeVC_ID);
                frm.ShowDialog();
                if (frm.OK > 0)
                {
                    LoadHopDongVanChuyen();
                    GridEXFilterCondition condi = new GridEXFilterCondition(gdVHopDongVanChuyen.Tables[0].Columns["HopDongVanChuyenID"], ConditionOperator.Equal, HDVC_ID);
                    gdVHopDongVanChuyen.Find(condi, 0, 1);
                    MessageBox.Show("Đã chuyển HĐVC sang vụ mới", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void gdVHopDongVanChuyen_SelectionChanged(object sender, EventArgs e)
        {
            //long DaCV = -1;
            //try
            //{
            //    DaCV = long.Parse(this.gdVHopDongVanChuyen.GetValue("DaChuyenVu").ToString());
            //}
            //catch { }
            //if (DaCV > 0)
            //{
            //    cmdChuyenVu.Enabled = false;
            //}
            //else
            //{
            //    cmdChuyenVu.Enabled = true;
            //}
        }
        private void LoadData()
        {
            string sql = "sp_RP_TongHop_VC_UNG_VCVATTU " + DBModule.RefineDate(dtTuNgay.Value) + ", " + DBModule.RefineDate(dtDenNgay.Value) + ", " + MDSolutionApp.VuTrongID;
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdVHopDongVanChuyen.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdVHopDongVanChuyen.DataSource = null;
            }
        }
        private void cmdFind_Click(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}