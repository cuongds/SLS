using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.SCREventLog;
using CrystalDecisions.Shared;
using System.Globalization;
using System.Threading;
using MDSolution.MDForms;
namespace MDSolution
{
    public partial class frmThuHoach : Form
    {

        static frmThuHoach _theformThuHoach;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmThuHoach OneInstanceFrm
        {
            get
            {
                if (null == _theformThuHoach || _theformThuHoach.IsDisposed)
                {
                    _theformThuHoach = new frmThuHoach();
                }

                return _theformThuHoach;
            }
        }
        //string[] arr_list = { "Vụ trồng", "Giống mía", "Tuổi ruộng mía", "Loại đất", "Đường vận chuyển" };
        //string[] arr_u_list = { "ut_VuTrong", "ut_GiongMia", "NgayTrong", "ut_LoaiDat", "ut_DuongVanChuyen" };



        DateTime NgayGio = DateTime.Now;
        string[] arr_list = { "Gốc mía", "Giống mía", "Loại đất", "Vụ trồng" };
        string[] arr_u_list = { "ut_GocMia", "ut_GiongMia", "ut_LoaiDat", "ut_VuTrong" };

        string VuTrongID = MDSolutionApp.VuTrongID.ToString();

        // Dieu kien uu tien----------------
        //string ThonID = "";
        string XaID = "";
        string TramID = "";

        string PhanQuyen_CacTramID = "";

        DataSet ds = null;
        //DataTable  rpt_dt = new DataTable();


        //----------------------------------
        public frmThuHoach()
        {
            InitializeComponent();
            LoadTramID_ForUserTram(); // phan quyen theo tram


        }

        private void LoadTramID_ForUserTram()
        {
            string strSQL = "Select CumID From sys_Roles_User_Cum Where UserID=" + MDSolutionApp.User.ID.ToString();
            DataSet ds2 = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                        PhanQuyen_CacTramID += ds2.Tables[0].Rows[i]["CumID"].ToString();
                    else
                        PhanQuyen_CacTramID += "," + ds2.Tables[0].Rows[i]["CumID"].ToString();
                }
            }
        }
        bool formLoaded = false;
        private void frmThuHoach_Load(object sender, EventArgs e)
        {
            lblTitle.Text = lblTitle.Text + MDSolutionApp.VuTrongTen;
            dtTuNgay.Value = DateTime.Now.AddDays(-1);
            dtDenNgay.Value = DateTime.Now.AddDays(2);
            dtLenhVCTu.Value = DateTime.Now.AddDays(-1);
            dtLenhVCDen.Value = DateTime.Now.AddDays(2);
            this.WindowState = FormWindowState.Maximized;

            LoadData();
            formLoaded = true;

        }
        private void LoadData() // sử dụng để load thửa ruộng có trạng thái khác trạg thái khai báo
        {
            if (Load2) return;
            // Built Select and Table data souce
            string strSQL = "sp_ThuHoach " + VuTrongID;
            ds = null;
            try
            {
                ds = DBModule.ExecuteQuery(strSQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //this.gdDSThuaRuong.DataSource = ds.Tables[0].DefaultView.ToTable(true, "Thon", "MaThuaRuong", "LoaiDatID", "DiaDiem", "ID", "NangSuatDuKien", "SanLuongDuKien", "TinhTrang", "TrangThai", "TramNongVuID", "VuTrongID", "NgayTrong", "MucDichID", "ThonID1", "NgayThuHoachDuKien", "XaID", "HoTen", "DienTich", "ut_LoaiDat", "TenLoaiDat", "tt", "SoPhieuChat", "ThonID", "SanLuongDuKien2", "DM_Thon", "NangSuatDuKien2", "Diachi", "Kieutrong", "SoBanDieuTra", "VuTrong", "MaHopDong", "MaXa", "DienTichPheCanh", "DienTichChatGiong", "SanLuongChatGiong", "NangSuatChatGiong", "NangSuatDuKien1", "SanLuongDuKien1", "LuongMiaThucTe", "Xa", "SoCMT", "NgayCap", "NoiCap", "Huyen", "TenBai", "KhoangCach", "TenGiongMia", "ut_GiongMia", "CanBoNongVu", "CanBoNongVuID", "DonGia"); ;
                    this.gdDSThuaRuong.SetDataBinding(ds.Tables[0], "RootTable");//Sử dụng lệnh này, dùng lệnh trên quá lâu
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiem tra:" + ex.ToString());
                ds = null;
            }
            Load2 = true;
        }

        private void Load_List() // sử dụng để load thửa ruộng có trạng thái khác trạg thái khai báo
        {

            // Built Select and Table data souce
            string strSQL = "Select distinct * FROM V_LenhChatMia ";
            string strWhere = "WHERE VuTrongID= " + VuTrongID;
            strSQL = strSQL + strWhere;

            ds = null;
            try
            {
                ds = DBModule.ExecuteQuery(strSQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.gdDSThuaRuong.DataSource = ds.Tables[0];
                }
                else
                {

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiem tra:" + ex.ToString());
                ds = null;
            }



        }

        private void cmdIn_Click(object sender, EventArgs e)
        {
            try
            {   // clsThuaRuong.UpdateKeHoach("", null, null);
                string sql = " Select Distinct * From V_KH_VanChuyen Where NgayChat >=" + DBModule.RefineDate(this.dtTuNgay.Value) + " AND NgayChat <=" + DBModule.RefineDate(this.dtDenNgay.Value);
                string MaThuaRuong_Checked = "(000000";

                //if (TramUIComBo.SelectedValue.ToString() != "0")
                //{
                //    sql = sql + "  And TramID = " + TramUIComBo.SelectedValue.ToString();
                //}

                foreach (Janus.Windows.GridEX.GridEXRow dr in gdDSThuaRuong.GetCheckedRows())
                {
                    string SoThua = dr.Cells["ID"].Value.ToString();
                    //string SoThua = this.gdDSThuaRuong.GetValue("MaHDDT").ToString() + this.gdDSThuaRuong.GetValue("SoThua").ToString();
                    if (SoThua != "")
                    {
                        MaThuaRuong_Checked = MaThuaRuong_Checked + "," + SoThua;
                    }
                }
                MaThuaRuong_Checked = MaThuaRuong_Checked + ")";
                if (MaThuaRuong_Checked != "(000000)")
                {
                    sql = sql + "  And ID in " + MaThuaRuong_Checked;
                }


                sql = sql + " Order By Huyen, Xa, Thon, NgayChat";
                DataSet ds = null;
                ds = DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MDSolution.MDForms.frmShowRP2 frm2 = new MDSolution.MDForms.frmShowRP2();
                    MDSolution.MDReport.ThuHoach.rpt_PhieuBaoChatMia rp = new MDSolution.MDReport.ThuHoach.rpt_PhieuBaoChatMia();
                    rp.SetDataSource(ds.Tables[0]);

                    //rp.Database.Tables[0].ApplyLogOnInfo(frm2.tblogon);
                    frm2.RP = rp;

                    frm2.Show();
                }
                else
                {
                    MessageBox.Show("Không có phiếu trong thời gian đã chọn!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra! Bạn thực hiện lại lệnh In phiếu!" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }



        private void Load_PhieuDon()
        {
            if (Load4) return;
            // Built Select and Table data souce
            string strSQL = "Select * FROM V_KH_VanChuyen_NEW as V_KH_VanChuyen ";

            string strWhere = "WHERE NgayChat>=" + DBModule.RefineDate(dtTuNgay.Value.Date) + " AND NgayChatDen<=" + DBModule.RefineDate(dtDenNgay.Value.Date.AddDays(1)) + " AND  VuTrongID= " + MDSolutionApp.VuTrongID;
            strSQL = strSQL + strWhere;
            strSQL = strSQL + " Order By Huyen, Xa, Thon, NgayChat, SoLenh";
            ds = null;
            try
            {
                ds = DBModule.ExecuteQuery(strSQL, null, null);
                this.grdPhieuDon.SetDataBinding(ds.Tables[0], "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiem tra:" + ex.ToString());
                ds = null;
                this.grdPhieuDon.SetDataBinding(null, "");
            }
            Load4 = true;
        }
        private void Load_LenhVC()
        {

            // Built Select and Table data souce
            string strSQL = @"Select * FROM V_KH_VanChuyen as V_KH_VanChuyen ";
            // SELECT V_KH_VanChuyen.*, ISNULL(dbo.tbl_NhapMia.TrangThaiCan,0) AS TrangThaiCan  FROM     dbo.V_KH_VanChuyen LEFT OUTER JOIN dbo.tbl_NhapMia ON dbo.V_KH_VanChuyen.VuTrongID = dbo.tbl_NhapMia.VuTrongID AND dbo.V_KH_VanChuyen.SoLenh = dbo.tbl_NhapMia.SoPhieuChat
            string strWhere = "WHERE NgayChat>=" + DBModule.RefineDate(dtLenhVCTu.Value.Date) + " AND NgayChat<" + DBModule.RefineDate(dtLenhVCDen.Value.Date.AddDays(1)) + " AND  V_KH_VanChuyen.VuTrongID= " + MDSolutionApp.VuTrongID;
            strSQL = strSQL + strWhere;
            strSQL = strSQL + " Order By Huyen, Xa, Thon, NgayChat, SoLenh";
            DataSet ds = null;
            try
            {
                ds = DBModule.ExecuteQuery(strSQL, null, null);
                this.grdLenhVC.SetDataBinding(ds.Tables[0], "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiem tra:" + ex.ToString());
                this.grdLenhVC.SetDataBinding(null, "");
            }

        }
        private void Load_PhieuDaCan()
        {
            if (Load3) return;
            // Built Select and Table data souce
            string strSQL = "Select dbo.V_KH_VanChuyen.* FROM    dbo.V_KH_VanChuyen INNER JOIN dbo.tbl_NhapMia ON dbo.V_KH_VanChuyen.VuTrongID = dbo.tbl_NhapMia.VuTrongID AND dbo.V_KH_VanChuyen.SoLenh = dbo.tbl_NhapMia.SoPhieuChat ";
            string strWhere = "WHERE  dbo.V_KH_VanChuyen.VuTrongID= " + MDSolutionApp.VuTrongID;
            strSQL = strSQL + strWhere;
            ds = null;
            try
            {
                ds = DBModule.ExecuteQuery(strSQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //this.grdDaCan.DataSource = ds.Tables[0].DefaultView.ToTable(true, "Thon", "MaThuaRuong", "LoaiDatID", "DiaDiem", "ID", "NangSuatDuKien", "SanLuongDuKien", "TinhTrang", "TrangThai", "TramNongVuID", "VuTrongID", "NgayTrong", "MucDichID", "ThonID1", "NgayThuHoachDuKien", "XaID", "HoTen", "DienTich", "ut_LoaiDat", "TenLoaiDat", "tt", "SoPhieuChat", "ThonID", "SanLuongDuKien2", "DM_Thon", "NangSuatDuKien2", "Diachi", "Kieutrong", "SoBanDieuTra", "VuTrong", "MaHopDong", "MaXa", "DienTichPheCanh", "DienTichChatGiong", "SanLuongChatGiong", "NangSuatChatGiong", "NangSuatDuKien1", "SanLuongDuKien1", "LuongMiaThucTe", "Xa", "SoCMT", "NgayCap", "NoiCap", "Huyen", "TenBai", "KhoangCach", "TenGiongMia", "ut_GiongMia", "CanBoNongVu", "CanBoNongVuID", "DonGia", "SoLenh");
                    this.gdDaCan.SetDataBinding(ds.Tables[0], "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiem tra:" + ex.ToString());
                ds = null;
            }
            Load3 = true;
        }

        private void cmdLuiKeHoach_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Chuyển kế hoạch đốn từ ngày: " + dtTuNgay.Value.ToString("dd/MM/yyyy") + " đến ngày mới: " + dtDenNgay.Value.ToString("dd/MM/yyyy") + ". Bạn có muốn tiếp tục?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            //{
            //    int SoNgay = (dtDenNgay.Value - dtTuNgay.Value).Days;

            //    if (rdThuaRuong.Checked)
            //    {
            //        foreach (Janus.Windows.GridEX.GridEXRow dr in gdDSThuaRuong.GetCheckedRows())
            //        {
            //            string MaThuaRuong = dr.Cells["ID"].Value.ToString();
            //            if (MaThuaRuong != "")
            //            {
            //                clsLenhChatMia.ChangeDate(dtTuNgay.Value, SoNgay, -1, MaThuaRuong, null, null);
            //            }
            //        }
            //    }
            //    if (rdDiaBan.Checked)
            //    {
            //        long TramID = -1;
            //        try
            //        {
            //            TramID = long.Parse(TramUIComBo.SelectedValue.ToString());
            //        }
            //        catch
            //        {
            //            TramID = -1;
            //        }
            //        clsLenhChatMia.ChangeDate(dtTuNgay.Value, SoNgay, TramID, "", null, null);
            //    }
            //    if (rdToanVung.Checked)
            //    {
            //        clsLenhChatMia.ChangeDate(dtTuNgay.Value, SoNgay, -1, "", null, null);
            //    }
            //    //clsThuaRuong.UpdateKeHoach("", null, null);
            //    MessageBox.Show("Đã chuyển kế hoạch đốn từ ngày: " + dtTuNgay.Value.ToString("dd/MM/yyyy") + " đến ngày mới: " + dtDenNgay.Value.ToString("dd/MM/yyyy") + " hoàn tất!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            //}
        }

        private void cmd_ChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                string SoThua = this.gdDSThuaRuong.GetValue("ID").ToString();

                if (SoThua != "")
                {
                    if (chekApDungNgay.Checked == false)
                    {
                        frm_ChitietThuHoach frm = new frm_ChitietThuHoach(SoThua);
                        frm.ShowDialog();
                        Load4 = false;
                        Load_PhieuDon();
                    }
                    else
                    {
                        frm_ChitietThuHoach frm = new frm_ChitietThuHoach(SoThua, dtNgayChatTu.Value, dtNgayChatDen.Value);
                        frm.ShowDialog();
                        Load4 = false;
                        Load_PhieuDon();
                    }
                }

            }
            catch
            { }

        }

        private void cmdPhieuBaoDon_Click(object sender, EventArgs e)
        {
            if (!KiemTraLenh())
            {
                MessageBox.Show("Bạn chưa chọn phiếu để in", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {

                // clsThuaRuong.UpdateKeHoach("", null, null);
                string sql = " Select * From V_KH_VanChuyen_NEW as V_KH_VanChuyen WHERE NgayChat>=" + DBModule.RefineDate(dtTuNgay.Value.Date) + " AND NgayChat<" + DBModule.RefineDate(dtDenNgay.Value.Date.AddDays(1)) + " AND  VuTrongID= " + MDSolutionApp.VuTrongID;
                string MaThuaRuong_Checked = "(000000";

                //if (TramUIComBo.SelectedValue.ToString() != "0")
                //{
                //    sql = sql + "  And TramID = " + TramUIComBo.SelectedValue.ToString();
                //}

                foreach (Janus.Windows.GridEX.GridEXRow dr in grdPhieuDon.GetCheckedRows())
                {
                    string SoThua = dr.Cells["SoLenh"].Value.ToString();
                    //string SoThua = this.gdDSThuaRuong.GetValue("MaHDDT").ToString() + this.gdDSThuaRuong.GetValue("SoThua").ToString();
                    if (SoThua != "")
                    {
                        MaThuaRuong_Checked = MaThuaRuong_Checked + "," + SoThua;
                    }
                }
                MaThuaRuong_Checked = MaThuaRuong_Checked + ")";
                if (MaThuaRuong_Checked != "(000000)")
                {
                    sql = sql + "  And SoLenh in " + MaThuaRuong_Checked;
                }


                sql = sql + " Order By Huyen, Xa, Thon, NgayChat";
                DataSet ds = null;
                ds = DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MDSolution.MDForms.frmShowRP2 frm2 = new MDSolution.MDForms.frmShowRP2();
                    MDSolution.MDReport.ThuHoach.rpt_PhieuBaoChatMia rp = new MDSolution.MDReport.ThuHoach.rpt_PhieuBaoChatMia();
                    rp.SetDataSource(ds.Tables[0]);

                    //rp.Database.Tables[0].ApplyLogOnInfo(frm2.tblogon);
                    frm2.RP = rp;

                    frm2.Show();
                }
                else
                {
                    MessageBox.Show("Không có phiếu trong thời gian đã chọn!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra! Bạn thực hiện lại lệnh In phiếu!" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cmd2XeExcel_Click(object sender, EventArgs e)
        {
            try
            {

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
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

        private void Export_Excel_PhieuDon_Click(object sender, EventArgs e)
        {
            try
            {

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = grdPhieuDon;
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

        private void dtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                Load4 = false;
                Load_PhieuDon();
            }
        }

        private void dtDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                Load4 = false;
                Load_PhieuDon();
            }
        }
        bool Load2 = false;
        bool Load3 = false;
        bool Load4 = false;
        private void uiTab1_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (uiTabPage2.Selected == true)
            {
                if (!Load2)
                    LoadData();
            }
            else if (uiTabPage3.Selected == true)
            {
                if (!Load3)
                    Load_PhieuDaCan();
            }
            else if (uiTabPage4.Selected == true)
            {
                if (!Load4)
                    Load_PhieuDon();
            }
        }

        private void btnInLenhVC_Click(object sender, EventArgs e)
        {
            if (!KiemTraLenhVanChuyen())
            {
                MessageBox.Show("Bạn chưa chọn phiếu để in", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (!KiemTraLenhVanChuyenIn())
            //{
            //    MessageBox.Show("Bạn đã chọn phiêu đã in rồi không được chọn lại", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            try
            {
                // clsThuaRuong.UpdateKeHoach("", null, null);
                string sql = " Select  * From V_KH_VanChuyen Where NgayChat >=" + DBModule.RefineDate(this.dtLenhVCTu.Value) + " AND NgayChat <" + DBModule.RefineDate(this.dtLenhVCDen.Value.AddDays(1)) + " AND  VuTrongID= " + MDSolutionApp.VuTrongID;
                string MaThuaRuong_Checked = "('000000'";

                //if (TramUIComBo.SelectedValue.ToString() != "0")
                //{
                //    sql = sql + "  And TramID = " + TramUIComBo.SelectedValue.ToString();
                //}

                foreach (Janus.Windows.GridEX.GridEXRow dr in grdLenhVC.GetCheckedRows())
                {
                    string SoThua = dr.Cells["SoLenh"].Value.ToString();
                    // string LenhChatMiaID = dr.Cells["LenhChatMiaID"].Value.ToString();
                    string LenhChatMiaID = dr.Cells["IDLenh"].Value.ToString();
                    string sqlupdatelenh = "Update  tbl_LenhChatMia set Modifyed=" + MDSolutionApp.User.ID + " ,NgayInPhieu= " + DBModule.RefineDate(DateTime.Now) + ",DaIn = 1 where ID =" + LenhChatMiaID;
                    try
                    {
                        DBModule.ExecuteNoneBackup(sqlupdatelenh, null, null);
                    }
                    catch { }
                    //string SoThua = this.gdDSThuaRuong.GetValue("MaHDDT").ToString() + this.gdDSThuaRuong.GetValue("SoThua").ToString();
                    if (SoThua != "")
                    {
                        MaThuaRuong_Checked = MaThuaRuong_Checked + ",'" + SoThua + "'";
                    }
                }
                MaThuaRuong_Checked = MaThuaRuong_Checked + ")";
                if (MaThuaRuong_Checked != "('000000')")
                {
                    sql = sql + "  And SoLenh in " + MaThuaRuong_Checked;
                }


                sql = sql + " Order By Huyen, Xa, Thon, NgayChat, SoLenh";
                DataSet ds = null;
                ds = DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MDSolution.MDForms.frmShowRP2 frm2 = new MDSolution.MDForms.frmShowRP2();
                    MDSolution.MDReport.ThuHoach.rpt_LenhVanChuyen rp = new MDSolution.MDReport.ThuHoach.rpt_LenhVanChuyen();
                    rp.SetDataSource(ds.Tables[0]);

                    //rp.Database.Tables[0].ApplyLogOnInfo(frm2.tblogon);
                    frm2.RP = rp;

                    frm2.Show();
                }
                else
                {
                    MessageBox.Show("Không có phiếu trong thời gian đã chọn!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra! Bạn thực hiện lại lệnh In phiếu!" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Load4 = false;
            Load_PhieuDon();
        }

        private void btnInitData_Click(object sender, EventArgs e)
        {
            string sql = "select * from tbl_LenhChatMia_Master  where SoChuyen>1 and VuTrongID=" + MDSolutionApp.VuTrongID;
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                sql = "";
                decimal sochuyen = (decimal)row["SoChuyen"];

                sql = "Create_LenhVanChuyenFromMaster " + row["ID"] + "," + row["SoChuyen"];
                DBModule.ExecuteNonQuery(sql, null, null);


            }

        }

        private void btnLoadLenhVC_Click(object sender, EventArgs e)
        {
            Load_LenhVC();
        }

        private void btnTangChuyen_Click(object sender, EventArgs e)
        {
            try
            {
                string SoThua = this.gdDSThuaRuong.GetValue("ID").ToString();

                if (SoThua != "")
                {
                    frm_TangSoChuyen frm = new frm_TangSoChuyen(SoThua);
                    frm.ShowDialog();
                    Load4 = false;
                    Load_PhieuDon();
                }

            }
            catch
            { }
        }


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdExit4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdXuatExcel4_Click(object sender, EventArgs e)
        {
            try
            {

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = gdDaCan;
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

        private void cmdExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdExit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdXuatExcel3_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = grdLenhVC;
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

        private bool KiemTraLenh()
        {
            bool Exist = false;
            string sids = ",";
            foreach (Janus.Windows.GridEX.GridEXRow r in grdPhieuDon.GetCheckedRows())
            {
                sids += r.Cells["ID"].Value + ",";
            }
            if (sids.Length > 2)
            {

                return true;
            }
            return Exist;
        }
        private bool KiemTraLenhVanChuyenIn()
        {
            bool Exist = false;
            if (MDSolutionApp.User.ID == 1 || MDSolutionApp.User.ID == 83062 || MDSolutionApp.User.ID == 83067)
            {
                return true;
            }
            else
            {
                foreach (Janus.Windows.GridEX.GridEXRow r in grdLenhVC.GetCheckedRows())
                {
                    if (Int32.Parse(r.Cells["DaIn"].Value.ToString()) == 1)
                        return Exist;
                }
            }
            return true;
        }

        private bool KiemTraLenhVanChuyen()
        {
            bool Exist = false;
            string sids = ",";
            foreach (Janus.Windows.GridEX.GridEXRow r in grdLenhVC.GetCheckedRows())
            {
                sids += r.Cells["ID"].Value + ",";
            }
            if (sids.Length > 2)
            {
                return true;
            }
            return Exist;
        }

        private void btn_TLUuTien_Click(object sender, EventArgs e)
        {
            if (!KiemTraLenhVanChuyen())
            {
                MessageBox.Show("Bạn chưa chọn phiếu để Thiết lập", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string SoThua = "";
                long LenhChatMiaID = 0;
                foreach (Janus.Windows.GridEX.GridEXRow dr in grdLenhVC.GetCheckedRows())
                {
                    SoThua = dr.Cells["SoLenh"].Value.ToString();
                    LenhChatMiaID = long.Parse(dr.Cells["LenhChatMiaID"].Value.ToString());
                }
                if (!string.IsNullOrEmpty(SoThua) || LenhChatMiaID != 0)
                {
                    MDSolution.MDForms.ThuHoach.frm_ChonUuTien frm = new MDSolution.MDForms.ThuHoach.frm_ChonUuTien(LenhChatMiaID, SoThua);
                    frm.ShowDialog();
                    if (frm.OK > 0)
                    {
                        Load_LenhVC();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra! Khi thiết lập" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}