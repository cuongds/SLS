using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MDSolution.MDForms;
using MDSolution.MDReport;
using MDSolution.MDDanhMuc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.SCREventLog;
using CrystalDecisions.Shared;
using System.Text;
using System.Windows.Forms;

namespace MDSolution
{
    public partial class MDIParent1 : Form
    {

        public static string strVuTrong = "";
        private frmStatus statusF = new frmStatus();
        public MDIParent1()
        {
            InitializeComponent();
        }

        void nWaiting()
        {
            statusF.Show();
        }
        void nWaited()
        {
            statusF.Close();
        }
        void Waiting()
        {
            picLoading.Visible = true;
            this.Refresh();
        }
        void Waited()
        {
            picLoading.Visible = false;
        }

        private void cmdDauTu_Click(object sender, EventArgs e)
        {
            frmQuanLyDauTuNoCu frm = new frmQuanLyDauTuNoCu();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cmdHoTro_Click(object sender, EventArgs e)
        {

            frmDanhSachCacKhoanHoTro frm = new frmDanhSachCacKhoanHoTro();
            frm.MdiParent = this;
            frm.Show();

        }

        private void cmdKetThuc_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MDIParent1_MdiChildActivate(object sender, EventArgs e)
        {
            //FormCollection fc = Application.OpenForms;
            //foreach (Form frm in fc)
            //{
            //    if (frm.WindowState == FormWindowState.Minimized)
            //    {
            //        if (this.ActiveMdiChild != null)
            //        {
            //            this.pnCenter.Visible = false;
            //            break;
            //        }
            //        else
            //        {
            //            this.pnCenter.Visible = true;
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        if (this.ActiveMdiChild != null)
            //        {
            //            this.pnCenter.Visible = false;
            //            break;
            //        }
            //        else
            //        {
            //            this.pnCenter.Visible = true;
            //            break;
            //        }
            //    }
            //}
            if (this.ActiveMdiChild != null)
            {
                this.pnCenter.Visible = false;

            }
            else
            {
                this.pnCenter.Visible = true;
            }


        }

        private void cmdNhapMia_Click(object sender, EventArgs e)
        {
            frmNhapMia frm = new frmNhapMia();
            frm.ShowDialog();
        }

        //private void mnuNhapMiaQuaCan_Click(object sender, EventArgs e)
        //{
        //    frmNhapMia frm = new frmNhapMia();
        //    frm.ShowDialog();
        //}

        private void mnuMayChu_Click(object sender, EventArgs e)
        {
            frmDataConnection frm = new frmDataConnection();
            frm.ShowDialog();
        }

        private void mnuHopDongMia_Click(object sender, EventArgs e)
        {
            this.Waiting();
            frmQuanLyHopDongTrongMia frm = new frmQuanLyHopDongTrongMia();
            frm.MdiParent = this;
            frm.Show();
            this.Waited();
        }

        private void cmdHopDongMia_Click(object sender, EventArgs e)
        {
            Waiting();
            frmQuanLyHopDongTrongMia frm = new frmQuanLyHopDongTrongMia();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void cmdDienTich_Click(object sender, EventArgs e)
        {
            Waiting();
            frmDienTichCoCauTrong frm = new frmDienTichCoCauTrong();
            frm.Load_DienTichDangKy = false;
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }


        private void mnuNhapDauTu_Click(object sender, EventArgs e)
        {
            Waiting();
            frmQuanLyDauTuNoCu frm = new frmQuanLyDauTuNoCu();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void cmdThanhToanMia_Click(object sender, EventArgs e)
        {
            MDForms.ThanhToan2016.frm_ThanhToan.OneInstanceFrm.MdiParent = this;
            MDForms.ThanhToan2016.frm_ThanhToan.OneInstanceFrm.Show();
            MDForms.ThanhToan2016.frm_ThanhToan.OneInstanceFrm.WindowState = FormWindowState.Maximized;
        }

        private void mnuThanhToanMia_Click(object sender, EventArgs e)
        {
            Waiting();
            frmThanhToanGoiY frm = new frmThanhToanGoiY();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void mnuHopDongVanChuyen_Click(object sender, EventArgs e)
        {
            frmHopDongVanChuyen frm = new frmHopDongVanChuyen();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cmdHopDongVanChuyen_Click(object sender, EventArgs e)
        {
            frmHopDongVanChuyen frm = new frmHopDongVanChuyen();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cmdTamUngVanChuyen_Click(object sender, EventArgs e)
        {
            Waiting();
            //frmQuanLyUngTienMia frm = new frmQuanLyUngTienMia();
            MDForms.UngTien.frmQuanLyUngTien frm = new MDForms.UngTien.frmQuanLyUngTien();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void mnuNhapHoTro_Click(object sender, EventArgs e)
        {
            // đã làm để bổ sung phần tra cứu hỗ trợ.2021
            //Waiting();
            //MDForms.DauTu.HoTro_TuNgay_DenNgay.OneInstanceFrm.MdiParent = this;
            //MDForms.DauTu.HoTro_TuNgay_DenNgay.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            //MDForms.DauTu.HoTro_TuNgay_DenNgay.OneInstanceFrm.Show();
            //Waited();
            frmDanhSachCacKhoanHoTro frm = new frmDanhSachCacKhoanHoTro();
            frm.MdiParent = this;
            frm.Show();
            //// HoTro_ThuNo_TuNgay_DenNgay frm = new HoTro_ThuNo_TuNgay_DenNgay();
            ////// frmDanhSachCacKhoanHoTro frm = new frmDanhSachCacKhoanHoTro();
            //// frm.MdiParent = this;
            //// frm.Show();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            try
            {
                lblUser.Text = MDSolutionApp.User.HoTen + "            ";
                lblTenMayChu.Text = DBModule.ServerName.ToUpper() + "            ";
                lblTenCSDL.Text = DBModule.DatabaseName.ToUpper() + "            ";
                lblTenVu.Text = MDIParent1.strVuTrong.ToUpper();
                if (MDSolutionApp.User.ID == 1)
                {
                    mnuThietLapHeThong.Visible = true;
                    mnuUsers.Visible = true;
                    mnuDanhMuc.Visible = true;
                }
                else
                {
                    mnuThietLapHeThong.Visible = false;
                    mnuUsers.Visible = false;
                    mnuDanhMuc.Visible = false;
                    phânQuyềnToolStripMenuItem.Enabled = false;
                }
                clsUser oU = new clsUser(MDSolutionApp.User.ID);
                oU.Load(null, null);
                string[] role = oU.Roles.Trim('&').Split('&');
                //foreach (ToolStripItem mnu in menuStrip.Items)
                //{
                //    mnu.Enabled = false;
                //}
                foreach (string rol in role)
                {
                    if (rol.ToLower() == "mnu_hethong")
                        phânQuyềnToolStripMenuItem.Enabled = true;
                    try
                    {
                        menuStrip.Items[rol].Enabled = true;
                        pnCenter.Controls["G" + rol].Enabled = true;
                    }
                    catch
                    {
                        continue;
                    }
                }
                this.Text = this.Text + "-" + DBModule.Version;
                //Hiển thị thông tin hợp đồng thay đổi nếu có:
                DateTime DenNgay = DateTime.Now;
                string sql = "select isnull(DateReadNotify,'2000-01-01') as DateReadNotify from sys_User  where ID={0}";
                DateTime TuNgay = (DateTime)DBModule.ExecuteQuery(string.Format(sql, MDSolutionApp.User.ID), null, null).Tables[0].Rows[0][0];
                sql = "select * from dbo.sys_HopDong_log where CreateDate>={0} and CreateDate<={1}";
                DataSet ds = DBModule.ExecuteQuery(string.Format(sql, DBModule.RefineDatetime(TuNgay), DBModule.RefineDatetime(DenNgay)), null, null);
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        frmHopDongLog frm = new frmHopDongLog();
                        frm.DateView = DenNgay;
                        frm.gdHopDongLog.SetDataBinding(ds.Tables[0], "RootTable");
                        frm.Text += "(" + ds.Tables[0].Rows.Count + ")";
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.ShowDialog();
                    }
                }
                catch (Exception exx)
                {

                }
                if (MDSolutionApp.User.ID == 1)
                {
                    mnuChuyenVu.Enabled = true;
                }
            }
            catch
            {
            }
        }

        private void mnuDanhMucDonVi_Click(object sender, EventArgs e)
        {
            //dlgDonVi frm = new dlgDonVi();
            //frm.MdiParent = this;
            //frm.Show();
            frmDanhMucDonVi frm = new frmDanhMucDonVi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDanhMucBaiBocXep_Click(object sender, EventArgs e)
        {
            frmBaiTapKet frm = new frmBaiTapKet();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuDanhMucKieuTrong_Click(object sender, EventArgs e)
        {
            frmDanhMucKieuTrong frm = new frmDanhMucKieuTrong();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDanhMucLinhVucDauTu_Click(object sender, EventArgs e)
        {
            frmDanhMucLinhVucDauTu frm = new frmDanhMucLinhVucDauTu();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tưĐiênDanhMucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhMucTuDien frm = new frmDanhMucTuDien();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cmdBaoCao_Click(object sender, EventArgs e)
        {
            //frmTheoDoiThuHoach frm = new frmTheoDoiThuHoach();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void bangKêChiTiêtCacHĐĐaNhâpDiênTichToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void diênTichVaCơCâuGiôngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuDTTheoVuTrongVun_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoVuTrongVung rp = new BCDienTichTheoVuTrongVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo vụ trồng toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void sfsadfToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuDanhSachKhachHang_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_DSKH rp = new rp_DSKH();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.DonViEnable = 1;
            frm.ThonIDName = "{tbl_thon.id}";
            frm.XaIDName = "{tbl_Xa.id}";
            frm.VuTrongIDName = "{tbl_VuTrong.id}";
            frm.SecssionSuppress = 8;
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Danh sách khách hàng";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void mnuBCDienTichTrongMiaChiTietThon_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTrongMiaChiTietThon rp = new BCDienTichTrongMiaChiTietThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo chi tiết diện tích trồng mía.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuTongHopDienTichTrongMiaXa_Click(object sender, EventArgs e)
        {


        }

        private void mnuDienTichTheoCoCauDatThon_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauDatThon rp = new BCDienTichTheoCoCauDatThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatThon.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo chi tiết diện tích trồng mía theo cơ cấu loại đất.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDauTuVaChinhSachThon_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCChiTietDauTuVaChinhSachThon rp = new BCChiTietDauTuVaChinhSachThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{View_BCChiTietDauTuVaChinhSachThon.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo chi tiết vốn đầu tư mới và chính sách hỗ trợ.";
            frm.MdiParent = this;
            frm.Show(); Waited();


        }

        private void mnuDauTuVaChinhSachXa_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCChiTietDauTuVaChinhSachXa rp = new BCChiTietDauTuVaChinhSachXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{View_BCChiTietDauTuVaChinhSachThon.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp vốn đầu tư mới và chính sách hỗ trợ.";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void mnuDauTuVaChinhSachVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCChiTietDauTuVaChinhSachVung rp = new BCChiTietDauTuVaChinhSachVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BCChiTietDauTuVaChinhSachThon.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp vốn đầu tư mới và chính sách hỗ trợ toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDauTuTheoLaiSuatThon_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCVonDauTuTheoLaiSuatThon rp = new BCVonDauTuTheoLaiSuatThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{View_BCVonDauTuTheoLaiSuat.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp vốn đầu tư theo lãi suất vay.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDauTuTheoLaiSuatXa_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCVonDauTuTheoLaiSuatXa rp = new BCVonDauTuTheoLaiSuatXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{View_HDThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp vốn đầu tư theo lãi suất vay.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDauTuTheoLaiSuatVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCVonDauTuTheoLaiSuatVung rp = new BCVonDauTuTheoLaiSuatVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_HDThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp vốn đầu tư theo lãi suất vay toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDauTuTheoLoaiHinhThon_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDauTuTheoLoaiHinhThon rp = new BCDauTuTheoLoaiHinhThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{View_HDThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp vốn đầu tư theo loại hình đầu tư.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDauTuTheoLoaiHinhXa_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDauTuTheoLoaiHinhXa rp = new BCDauTuTheoLoaiHinhXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{View_HDThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp vốn đầu tư theo loại hình đầu tư.";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void mnuDauTuTheoLoaiHinhVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDauTuTheoLoaiHinhVung rp = new BCDauTuTheoLoaiHinhVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_HDThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp vốn đầu tư theo loại hình đầu tư toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void mnuBCThuHoiVonDuNoTheoThon_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuThon rp = new rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuThon();
            frm.RP = rp;
            frm.ThonIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDThon}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = " Tổng hớp Đầu tư vốn - Thu hồi vốn - Dư nợ vốn văy trồng mía";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuBCThuHoiVonDuNoTheoXa_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuXa rp = new rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuXa();
            frm.RP = rp;
            frm.XaIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDXa}";
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thu hồi vốn dư nợ theo xã";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuBCThuHoiVonDuNoToanVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuVung rp = new rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thu hồi vốn dư nợ toàn vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuThuHoiVonTheoGTDTVaNoThon_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopKetQuaThuHoiVonDauTuThon rp = new rp_T_BCTongHopKetQuaThuHoiVonDauTuThon();
            frm.RP = rp;
            frm.ThonIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDThon}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía theo thôn";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void toolStripSeparator13_Click(object sender, EventArgs e)
        {

        }

        private void mnuDuNoXa_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopKetQuaThuHoiVonDauTuXa rp = new rp_T_BCTongHopKetQuaThuHoiVonDauTuXa();
            frm.RP = rp;
            frm.XaIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDXa}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía theo xã";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void mnuDuNoVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_T_BCTongHopKetQuaThuHoiVonDauTuVung rp = new rp_T_BCTongHopKetQuaThuHoiVonDauTuVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía toàn vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }





        private void mnuUsers_Click(object sender, EventArgs e)
        {
            frmQuanLyNguoiDung frm = new frmQuanLyNguoiDung();
            frm.ShowDialog();
        }

        private void mnKhachVanChuyenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHopDongVanChuyen frm = new frmHopDongVanChuyen();
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDanhMucHopDong_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_DSKH rp = new rp_DSKH();
            frm.RP = rp;

            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Danh sách khách hàng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }


        private void mnuThanhToanVanChuyen_Click(object sender, EventArgs e)
        {
            frmThanhToanVanChuyen frm = new frmThanhToanVanChuyen();
            frm.MdiParent = this;
            frm.Show();

        }


        private void mnuThanhToanChuHDVanChuyen_Click(object sender, EventArgs e)
        {
            //frmShowRP2 frm = new frmShowRP2();
            //rp_BaoCaoThanhToanChuHopDongVanChuyen rp = new rp_BaoCaoThanhToanChuHopDongVanChuyen();
            //rp.RecordSelectionFormula = "{View_BaoCaoTongHopChuHopDongVanChuyen.VuTrongID}=2 AND {View_BaoCaoTongHopChuHopDongVanChuyen.}";
            //frm.RP = rp;
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            //frm.RPtitle = "Thanh toán chủ hợp đồng vận chuyển";
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void mnuTienDoThuHoachMia_Click(object sender, EventArgs e)
        {
            //frmShowRP2 frm = new frmShowRP2();
            //rp_TienDoThuHoachMiaNguyenLieu rp = new rp_TienDoThuHoachMiaNguyenLieu();
            //frm.RP = rp;

            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            //frm.RPtitle = "Tiến độ thu hoạch mía";
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void mnuKetKetQuaVCMia_Click(object sender, EventArgs e)
        {
            //frmShowRP2 frm = new frmShowRP2();
            //rp_BaoCaoKetQuaVanChuyenMiaToanVung rp = new rp_BaoCaoKetQuaVanChuyenMiaToanVung();
            ////rp.RecordSelectionFormula = "{View_KetQuaVanChuyenMia.Ten}='vu 2008'";
            //frm.RP = rp;

            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            //frm.RPtitle = "Kết quả vận chuyển mía";
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void mnuKetQuaVCTheoVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_KetQuaVanChuyenMiaToanVung rp = new rp_KetQuaVanChuyenMiaToanVung();
            frm.RP = rp;

            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả vận chuyển mía toàn vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuThanhToanChuHDVC_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rpt_ThanhToanChuHopDongVanChuyenMoi rp = new rpt_ThanhToanChuHopDongVanChuyenMoi();
            frm.RP = rp;

            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thanh toán chủ hợp đồng vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDTTheoVuTrongXa_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoVuTrongXa rp = new BCDienTichTheoVuTrongXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía theo vụ trồng.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDTTheoVuTrongThon_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoVuTrongThon rp = new BCDienTichTheoVuTrongThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích theo cơ cấu vụ trồng.";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void mnuDienTichTheoCoCauDatXa_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauDatXa rp = new BCDienTichTheoCoCauDatXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatXa.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía theo cơ cấu loại đất.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDienTichTheoCoCauDatVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoCoCauDatVung rp = new BCDienTichTheoCoCauDatVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatVung.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía theo cơ cấu loại đất toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void cmdThanhToanVanChuyen_Click(object sender, EventArgs e)
        {
            //frmThanhToanVanChuyen frm = new frmThanhToanVanChuyen();
            //frm.MdiParent = this;
            //frm.Show();
            Waiting();
            frmDanhSachMuaVatTuCty frm = new frmDanhSachMuaVatTuCty();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmThuHoach.OneInstanceFrm.MdiParent = this;
            frmThuHoach.OneInstanceFrm.Show();
            frmThuHoach.OneInstanceFrm.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmShowRP2 frm = new frmShowRP2();

            rp_DSKH rp = new rp_DSKH();
            //
            rp.SetParameterValue("XaID", 25);

            frm.RP = rp;

            frm.RPtitle = "Diện tích theo cơ cấu đất của toàn vùng";
            // rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);

            frm.MdiParent = this;
            frm.Show();
        }

        private void mnQuanLyPhiKhauHao_Click(object sender, EventArgs e)
        {
            frmQuanLyKhauHao frm = new frmQuanLyKhauHao();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnTimKiemHopDong_Click(object sender, EventArgs e)
        {
            frmTimKiemHopDong frm = new frmTimKiemHopDong();
            frm.MdiParent = this;
            frm.Show();

        }


        private void mnuTamUngVanChuyen_Click(object sender, EventArgs e)
        {
            //frmTamUngVatTu frm = new frmTamUngVatTu();
            //frm.MdiParent = this;
            //frm.Show();
            MDForms.frmTamUngVatTuVanChuyen frm = new frmTamUngVatTuVanChuyen();
            frm.MdiParent = this;
            frm.Show();

        }

        private void mnTimKiemXeVanChuyen_Click(object sender, EventArgs e)
        {
            frmTimKiemXeVanChuyen frm = new frmTimKiemXeVanChuyen();
            frm.MdiParent = this;
            frm.Show();

        }

        private void mnuDienTichTheoTieuChuan_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoTieuChuan rp = new BCDienTichTheoTieuChuan();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatVung.VuTrongID}";
            frm.DienTichToiThieu = "{View_BCDienTichTheoCoCauDatVung.DienTich}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía theo xã";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDienTichTheoCoCauDatTongHop_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauDatTongHop rp = new BCDienTichTheoCoCauDatTongHop();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatThon.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo cơ cấu loại đất.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuTongHopDienTichTrongMiaXa_Click_1(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTrongMiaChiTietThonXa rp = new BCDienTichTrongMiaChiTietThonXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuTongHopDienTichTrongMiaVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTrongMiaTongHopVung rp = new BCDienTichTrongMiaTongHopVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo chi ti?t di?n tích tr?ng mía theo co c?u lo?i d?t.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDTTheoCoCauGiongThon_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauGiongThon rp = new BCDienTichTheoCoCauGiongThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo cơ cấu giống.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDTTheoCoCauGiongXa_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauGiongXaMoi rp = new BCDienTichTheoCoCauGiongXaMoi();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo cơ cấu giống xã.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void mnuDTTheoCoCauGiongVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoCoCauGiongVung rp = new BCDienTichTheoCoCauGiongVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo cơ cấu giống.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void chuHopDongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rpt_ThanhToanChuHopDongVanChuyenMoi rp = new rpt_ThanhToanChuHopDongVanChuyenMoi();
            frm.RP = rp;
            //{View_ThanhToanChuHopDongVanChuyen.IDVuTrong}{View_ThanhToanChuHopDongVanChuyen.IDChuHopDongVanChuyen}

            frm.HopDongVC_ID_Name = "{View_ThanhToanChuHopDongVanChuyen.IDChuHopDongVanChuyen}";
            frm.VuTrongIDName = "{View_ThanhToanChuHopDongVanChuyen.IDVuTrong}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thanh toán chủ hợp đồng vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void vToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_ThanhToanChuHopDongVanChuyenVung rp = new rp_ThanhToanChuHopDongVanChuyenVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_ThanhToanChuHopDongVanChuyen.IDVuTrong}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thanh toán chủ hợp đồng vận chuyển vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void thônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_BaoCaoTienDoThuHoachMiaNguyenLieuThon rp = new rp_BaoCaoTienDoThuHoachMiaNguyenLieuThon();
            frm.RP = rp;
            frm.ThonIDName = "{View_ThuHoachMiaNguyenLieu.ThonID}";
            frm.VuTrongIDName = "{View_ThuHoachMiaNguyenLieu.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ thu hoạch mía nguyên liệu thôn";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void xãToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_BaoCaoTienDoThuHoachMiaNguyenLieuThonXa rp = new rp_BaoCaoTienDoThuHoachMiaNguyenLieuThonXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{View_ThuHoachMiaNguyenLieu.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ thu hoạch mía nguyên liệu thôn";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void vùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoTienDoThuHoachMiaNguyenLieuToanVung rp = new rp_BaoCaoTienDoThuHoachMiaNguyenLieuToanVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_ThuHoachMiaNguyenLieu.VuTrongID}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ thu hoạch mía nguyên liệu toàn vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void chủHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_KetQuaVanChuyenMiaChuVanChuyen rp = new rp_KetQuaVanChuyenMiaChuVanChuyen();
            frm.RP = rp;
            frm.HopDongVC_ID_Name = "{tbl_HopDongVanChuyen.ID}";
            frm.VuTrongIDName = "{tbl_VuTrong.ID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả vận chuyển mía Chủ hợp đồng vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void vùngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoKetQuaVanChuyenMiaToanVung rp = new rp_BaoCaoKetQuaVanChuyenMiaToanVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_VanChuyenMiaVung.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả vận chuyển mía vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void mnuKetQuaVCTheoThon_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_BaoCaoTamUngCuaChuHopDongVanChuyen rp = new rp_BaoCaoTamUngCuaChuHopDongVanChuyen();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_UngVatTuChuHopDong.IDVuTrong}";
            frm.HopDongVC_ID_Name = "{View_UngVatTuChuHopDong.HopDongVanChuyenID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tạm ứng chủ hợp đồng vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();


        }

        private void mnuKetQuaVCTheoXa_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoTamUngVanChuyenVuMia rp = new rp_BaoCaoTamUngVanChuyenVuMia();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_UngVatTuChuHopDong.IDVuTrong}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tạm ứng vận chuyển toàn vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();


        }


        private void mnuNhapMiaQuaCan_Click(object sender, EventArgs e)
        {
            frmNhapMia frm = new frmNhapMia();
            //frm.MdiParent = this;
            frm.ShowDialog();
        }

        private void tưĐiênDanhMucToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDanhMucTuDien frm = new frmDanhMucTuDien();
            frm.MdiParent = this;
            frm.Show();
        }


        private void củaHàngỨngVậnChuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoTamUngVatTuCuaHang rp = new rp_BaoCaoTamUngVatTuCuaHang();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_UngVatTuVanChuyenCuaHang.IDVuTrong}";
            //frm.NgayLocName = "{View_UngVatTuVanChuyenCuaHang.NgayUng}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Ứng vật tư của của hàng";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void xemChiTiếtTạmỨngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDForms.frmTheoDoiUngVanChuyen.OneInstanceFrm.MdiParent = this;
            MDForms.frmTheoDoiUngVanChuyen.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDForms.frmTheoDoiUngVanChuyen.OneInstanceFrm.Show();
        }

        private void kếtQủaThuHoạchMíaNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXe rp = new rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXe();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_KetQuaVanChuyenMiaNgay.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả vận chuyển mía nguyên liệu";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }


        private void cânNhậpNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Waiting();
            //frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            //rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXe rp = new rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXe();
            //frm.RP = rp;


            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXe rp = new rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXe();

            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_KetQuaCanNhapMiaNguyenLieuXe.VuTrongID}";
            //frm.ThonIDName = "{View_KetQuaCanNhapMiaNguyenLieuXe.ThonID}";
            //frm.NgayLocName = "{View_KetQuaCanNhapMiaNguyenLieuXe.NgayVanChuyen}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả vận chuyển mía Chủ hợp đồng vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void cânNhậpVùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rpt_KetQuaCanNhapMiaNguyenLieu rp = new rpt_KetQuaCanNhapMiaNguyenLieu();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_ThuHoachMiaNguyenLieu.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả cân nhập mía vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void xãToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_ChiTietTienDoDienTichTrongMiaXa rp = new rp_ChiTietTienDoDienTichTrongMiaXa();
            frm.RP = rp;
            frm.XaIDName = "{View_ChiTietTienDoTrongMia.XaID}";
            frm.VuTrongIDName = "{View_ChiTietTienDoTrongMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ trồng mía xã";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void vùngToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_ChiTietTienDoDienTichTrongMiaVung rp = new rp_ChiTietTienDoDienTichTrongMiaVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BaoCaoChiTietTienDoTrongMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ trồng mía vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void thônToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_ChiTietTienDoDienTichTrongMiaXa rp = new rp_ChiTietTienDoDienTichTrongMiaXa();
            frm.RP = rp;
            frm.ThonIDName = "{View_ChiTietTienDoTrongMia.ThonID}";
            frm.VuTrongIDName = "{View_ChiTietTienDoTrongMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ trồng mía thôn";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }

        private void cmdTimKiem_Click(object sender, EventArgs e)
        {
            frmTimKiemHopDong frm = new frmTimKiemHopDong();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTongHopDienTichTrongMiaVung_Click_1(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTrongMiaTongHopVungMoi rp = new BCDienTichTrongMiaTongHopVungMoi();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía toàn vùng.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void mnuDienTichTheoTieuChuan_Click_1(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoTieuChuan rp = new BCDienTichTheoTieuChuan();
            frm.RP = rp;
            frm.DienTichToiThieu = "co";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatVung.VuTrongID}";
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo diện tích theo tiêu chuẩn.";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void mnuDienTichTheoCoCauDatTongHop_Click_1(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauDatTongHop rp = new BCDienTichTheoCoCauDatTongHop();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatThon.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích theo cơ cấu đất.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void vânChuyênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thanhToanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_LenhThuHoachMiaNguyenLieu rp = new rp_LenhThuHoachMiaNguyenLieu();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_LamLenhThuHoachMiaNguyenLieu.VuTrongID}";
            frm.NgayLocName = "{View_LamLenhThuHoachMiaNguyenLieu.NgayChat}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Lệnh thu hoạch mía nguyên liệu";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }


        private void mnuHuongDan_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("HuongdanSudungSD.chm");
            }
            catch
            {
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapNangSuatDuKienTheoThon frm = new frmNhapNangSuatDuKienTheoThon();
            frm.MdiParent = this;
            frm.Show();
        }

        private void hooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoTroTheoLoaiHinh frm = new frmHoTroTheoLoaiHinh();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDanhMucHoTroKhongTuongUngDauTu_Click(object sender, EventArgs e)
        {
            frmDanhMucHoTro frm = new frmDanhMucHoTro();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuLamThanhToanTheoDot_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_T_DS_CacHoThanhToanMia_TheoDot rp = new rp_T_DS_CacHoThanhToanMia_TheoDot();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{tbl_VuTrong.ID}";
            frm.DotThanhToanName = "{tbl_HopDong_DaLamThanhToan.DotThanhToan}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Danh sách tổng hợp hợp đồng làm thanh tóan";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void mnuLamThanhToanTheoVu_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_T_DS_CacHoThanhToanMia_TheoVu rp = new rp_T_DS_CacHoThanhToanMia_TheoVu();
            frm.RP = rp;

            frm.VuTrongIDName = "{tbl_VuTrong.ID}";
            //frm.DotThanhToanName = "{tbl_HopDong_DaLamThanhToan.DotThanhToan}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Danh sách tổng hợp hợp đồng làm thanh tóan";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void mnuVuTrong_Click(object sender, EventArgs e)
        {
            frmVuTrong frm = new frmVuTrong();
            frm.MdiParent = this;
            frm.Show();
        }

        private void MenuTongHopDuNoDauTu_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCTongHopThuHoiDuNoDauTuMia rp = new BCTongHopThuHoiDuNoDauTuMia();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BCThuHoiDuNoDauTu.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp thu hồi dư nợ đầu tư mía.";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void MenuCacHoNoDauTu_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDSCacHoNoDauTu rp = new BCDSCacHoNoDauTu();
            frm.RP = rp;
            frm.XaIDName = "{View_BCThuHoiDuNoDauTu.XaID}";
            frm.VuTrongIDName = "{View_BCThuHoiDuNoDauTu.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void MenuTongHopDauTuVaThuHoi_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCTongHopDauTuVaThuHoiVung rp = new BCTongHopDauTuVaThuHoiVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_VuTrong.ID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp đầu tư và thu hồi theo lĩnh vực đầu tư toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void MenuDauTuVaThuHoiTheoHeSo_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDauTuVaThuHoiTheoHeSoLaiSuat rp = new BCDauTuVaThuHoiTheoHeSoLaiSuat();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_VuTrong.ID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo đầu tư và thu hồi vốn đầu tư theo hệ số lãi suất.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void MenuSoChiTietDauTu_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_SoChiTietDauTu rp = new rp_T_SoChiTietDauTu();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.DonViEnable = 1;
            frm.ThonIDName = "{View_T_SoChiTietDauTu.ThonID}";
            frm.XaIDName = "{View_T_SoChiTietDauTu.XaID}";
            frm.VuTrongIDName = "{View_T_SoChiTietDauTu.VuTrongID}";
            frm.SecssionSuppress = 8;
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Sổ chi tiết đầu tư.";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void MenuSoInChiTietDienTich_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCSoInChiTietDienTichTrongMia rp = new BCSoInChiTietDienTichTrongMia();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Sổ in chi tiết diện tích trồng mía.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void ứngDầuVậnChuyểnVàTiếnĐộToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ứngDầuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiUngDauVanChuyenVuMia rp = new rp_MoiUngDauVanChuyenVuMia();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_MoiUngDauVanChuyenMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp ứng dầu vận chuyển chủ hợp đồng vận chuyển.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void thuHoạchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiTienDoThuHoachVuMia rp = new rp_MoiTienDoThuHoachVuMia();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_MoiTienDoThuHoachMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp vận chuyển mía theo vụ";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void vậnChuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiTienDoVanChuyenMiaVuMia rp = new rp_MoiTienDoVanChuyenMiaVuMia();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_MoiTienDoVanChuyenMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp vận chuyển mía theo vụ";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void mnuTheoDoiThuHoach_Click(object sender, EventArgs e)
        {
            frmTheoDoiThuHoach frm = new frmTheoDoiThuHoach();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuLenhThuHoach_Click(object sender, EventArgs e)
        {
            frmThuHoach.OneInstanceFrm.MdiParent = this;
            frmThuHoach.OneInstanceFrm.Show();
            frmThuHoach.OneInstanceFrm.WindowState = FormWindowState.Maximized;
        }

        private void cmdTroGiup_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("HuongdanSudungSD.chm");
            }
            catch { }
        }

        private void MenuDSCacHoDauTuVuotDinhMuc_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDSCacHoDauTuVuotDinhMuc rp = new BCDSCacHoDauTuVuotDinhMuc();
            frm.RP = rp;
            frm.DinhMucToiThieu = "Co";
            //frm.DinhMucToiThieu = "co";
            frm.VuTrongIDName = "{tbl_VuTrong.ID}";
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Danh sách các hộ đầu tư vượt định mức.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void mnuThuHoiVonDuNoChiTietToanVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopKetQuaThuHoiVonDauTuVungChiTiet rp = new rp_T_BCTongHopKetQuaThuHoiVonDauTuVungChiTiet();
            frm.RP = rp;
            frm.DonViEnable = 1;
            frm.ThonIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDThon}";
            frm.XaIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDXa}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void mnuThuHoiVonChiTietToanVung_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuVungChiTiet rp = new rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuVungChiTiet();
            frm.RP = rp;
            frm.ThonIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDThon}";
            frm.XaIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDXa}";
            frm.DonViEnable = 1;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = " Tổng hớp Đầu tư vốn - Thu hồi vốn - Dư nợ vốn văy trồng mía";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void vậnChuyểnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiTienDoVanChuyenMiaNgay rp = new rp_MoiTienDoVanChuyenMiaNgay();
            frm.RP = rp;
            frm.ParameterOn = 1;
            //frm.DonViEnable = 1;
            //frm.ThonIDName = "{tbl_thon.id}";
            //frm.XaIDName = "{tbl_Xa.id}";
            frm.VuTrongIDName = "{View_MoiTienDoVanChuyenMiaNgay.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ Vận chyển mía ngày";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void thuHoạchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiTienDoThuHoachMiaNgay rp = new rp_MoiTienDoThuHoachMiaNgay();
            frm.RP = rp;
            frm.ParameterOn = 1;
            //frm.DonViEnable = 1;
            //frm.ThonIDName = "{tbl_thon.id}";
            //frm.XaIDName = "{tbl_Xa.id}";
            frm.VuTrongIDName = "{View_MoiTienDoThuHoachMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Danh sách khách hàng";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void ứngDầuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiUngDauVanChuyenTheoNgay rp = new rp_MoiUngDauVanChuyenTheoNgay();
            frm.RP = rp;
            frm.ParameterOn = 1;
            //frm.DonViEnable = 1;
            //frm.ThonIDName = "{tbl_thon.id}";
            //frm.XaIDName = "{tbl_Xa.id}";
            frm.VuTrongIDName = "{View_MoiUngDauVanChuyenMoi.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Ưng dầu vận chuyển theo ngày tới ngày";
            frm.MdiParent = this;
            frm.Show();
            Waited();


        }

        private void tônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoTongHopNhapMia rp = new rp_BaoCaoTongHopNhapMia();
            frm.RP = rp;
            frm.ParameterOn = 1;

            frm.VuTrongIDName = "{View_TongHopNhapMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp nhập mía toàn vụ";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void tToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiTienDoThuHoachMia1 rp = new rp_MoiTienDoThuHoachMia1();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_MoiTenDoThuHoachMiaNgay.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ thu hoạch mía vụ ép";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void bảngKêTổngHợpSảnLượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Waiting();
            //frmShowRP2 frm = new frmShowRP2();
            //rp_BaoCaoTongHopSanLuong rp = new rp_BaoCaoTongHopSanLuong();
            //frm.RP = rp;
            //frm.ParameterOn = 1;
            ////frm.DinhMucToiThieu = "co";
            //frm.VuTrongIDName = "{View_BangKeTongHopSanLuong.VuTrongID}";
            ////rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            //frm.RPtitle = "Bảng Kê tổng hợp sản lượng";
            //frm.MdiParent = this;
            //frm.Show();
            //Waited();



            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoTongHopSanLuong rp = new rp_BaoCaoTongHopSanLuong();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BangKeTongHopSanLuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Bảng Kê tổng hợp sản lượng";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void tongHopNhapMiaToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //Waiting();
            //frmShowRP2 frm = new frmShowRP2();
            //rp_BaoCaoTongHopNhapMia rp = new rp_BaoCaoTongHopNhapMia();
            //frm.ParameterOn = 1;
            //frm.RP = rp;
            //frm.VuTrongIDName = "{View_TongHopNhapMia.VuTrongID}";
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            //frm.RPtitle = "Tổng hợp nhập mía";
            //frm.MdiParent = this;
            //frm.Show();
            //Waited();

            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_BaoCaoTongHopNhapMia rp = new rp_BaoCaoTongHopNhapMia();
            frm.ParameterOn = 1;
            frm.RP = rp;
            frm.ThonIDName = "{View_TongHopNhapMia.ThonID}";
            frm.VuTrongIDName = "{View_TongHopNhapMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp nhập mía";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void ứngDầuToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiUngDauVanChuyenTheoNgay rp = new rp_MoiUngDauVanChuyenTheoNgay();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_MoiUngDauVanChuyenMia.VuTrongID}";
            // frm.DotThanhToanName = "{View_MoiUngDauVanChuyenMoi.DotThanhToan}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Ứng Dầu vận chuyển theo ngày";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void thuHoạchToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiTienDoThuHoachMiaNgay rp = new rp_MoiTienDoThuHoachMiaNgay();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_MoiTienDoThuHoachMia.VuTrongID}";
            // frm.DotThanhToanName = "{View_MoiUngDauVanChuyenMoi.DotThanhToan}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ thu hoạch ngày";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void vậnChuyểnToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiTienDoVanChuyenMiaNgay rp = new rp_MoiTienDoVanChuyenMiaNgay();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_MoiTienDoVanChuyenMia.VuTrongID}";
            // frm.DotThanhToanName = "{View_MoiUngDauVanChuyenMoi.DotThanhToan}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ vận chuyển mía ngày";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }



        private void phânQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhanQuyen_Cum frm = new frmPhanQuyen_Cum();
            frm.ShowDialog();
        }

        private void mnuThietLapTinhTrangChoThuaRuong_Click(object sender, EventArgs e)
        {
            frmThietLapTinhTrangThuaRuong frm = new frmThietLapTinhTrangThuaRuong();
            frm.ShowDialog();
        }


        private void dTTrồngMíaChiTiếtthônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTrongMiaChiTietThon rp = new BCDienTichTrongMiaChiTietThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo chi tiết diện tích trồng mía.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void tổngHợpDTTrồngMíaxãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTrongMiaTongHopXa rp = new BCDienTichTrongMiaTongHopXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void tổngHợpDTTrồngMíavùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTrongMiaTongHopVung rp = new BCDienTichTrongMiaTongHopVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía toàn vùng.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void dTTheoCơCấuĐấtthônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauDatThon rp = new BCDienTichTheoCoCauDatThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatThon.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo chi tiết diện tích trồng mía theo cơ cấu loại đất.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void dTTheoCơCấuĐấtxãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauDatXa rp = new BCDienTichTheoCoCauDatXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatXa.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía theo cơ cấu loại đất.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void dTTheoCơCấuĐấtvùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoCoCauDatVung rp = new BCDienTichTheoCoCauDatVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatVung.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía theo cơ cấu loại đất toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void dTTheoTiêuChuẩnvùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoTieuChuan rp = new BCDienTichTheoTieuChuan();
            frm.RP = rp;
            frm.DienTichToiThieu = "co";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatVung.VuTrongID}";
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo diện tích theo tiêu chuẩn.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void tổngHợpTheoCơCấuĐâtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauDatTongHop rp = new BCDienTichTheoCoCauDatTongHop();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{View_BCDienTichTheoCoCauDatThon.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích theo cơ cấu đất.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void dTTheoCơCấuGiốngthônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauGiongThon rp = new BCDienTichTheoCoCauGiongThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo cơ cấu giống.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void dTTheoCơCấuGiốngxãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoCoCauGiongXa rp = new BCDienTichTheoCoCauGiongXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo cơ cấu giống.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void dTTheoCơCấuGiốngvùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoCoCauGiongVung rp = new BCDienTichTheoCoCauGiongVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo cơ cấu giống.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void dTTheoVụTrồngthônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoVuTrongThon rp = new BCDienTichTheoVuTrongThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích theo cơ cấu vụ trồng.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void dTTheoVụTrồngxãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDienTichTheoVuTrongXa rp = new BCDienTichTheoVuTrongXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía theo vụ trồng.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void dTTheoVụTrồngvùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDienTichTheoVuTrongVung rp = new BCDienTichTheoVuTrongVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích trồng mía theo vụ trồng toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void sổInChiTiếtDiệnTíchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCSoInChiTietDienTichTrongMia rp = new BCSoInChiTietDienTichTrongMia();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{tbl_ThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Sổ in chi tiết diện tích trồng mía.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void sổChiTiếtĐầuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_SoChiTietDauTu rp = new rp_T_SoChiTietDauTu();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.DonViEnable = 1;
            frm.SecssionSuppress = 8;
            frm.ThonIDName = "{View_T_SoChiTietDauTu.ThonID}";
            frm.XaIDName = "{View_T_SoChiTietDauTu.XaID}";
            frm.VuTrongIDName = "{View_T_SoChiTietDauTu.VuTrongID}";

            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Sổ chi tiết đầu tư.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void dSCácHộĐầuTưVượtĐịnhMứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDSCacHoDauTuVuotDinhMuc rp = new BCDSCacHoDauTuVuotDinhMuc();
            frm.RP = rp;
            //frm.DinhMucToiThieu = "co";
            frm.VuTrongIDName = "{tbl_VuTrong.ID}";
            frm.DinhMucToiThieu = "co";
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Danh sách các hộ đầu tư vượt định mức.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void đầuTưVàCSthônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCChiTietDauTuVaChinhSachThon rp = new BCChiTietDauTuVaChinhSachThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{View_BCChiTietDauTuVaChinhSachThon.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo chi tiết vốn đầu tư mới và chính sách hỗ trợ.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void đầuTưVàCSxãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCChiTietDauTuVaChinhSachXa rp = new BCChiTietDauTuVaChinhSachXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{View_BCChiTietDauTuVaChinhSachThon.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp vốn đầu tư mới và chính sách hỗ trợ.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void đầuTưVàCSvùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCChiTietDauTuVaChinhSachVung rp = new BCChiTietDauTuVaChinhSachVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BCChiTietDauTuVaChinhSachThon.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp vốn đầu tư mới và chính sách hỗ trợ toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void dTTheoCơCấuĐấtthônToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCVonDauTuTheoLaiSuatThon rp = new BCVonDauTuTheoLaiSuatThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{View_BCVonDauTuTheoLaiSuat.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp vốn đầu tư theo lãi suất vay.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void đầuTưTheoLSxãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCVonDauTuTheoLaiSuatXa rp = new BCVonDauTuTheoLaiSuatXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{View_HDThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp vốn đầu tư theo lãi suất vay.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void đầuTưTheoLSvùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCVonDauTuTheoLaiSuatVung rp = new BCVonDauTuTheoLaiSuatVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_HDThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp vốn đầu tư theo lãi suất vay toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void đầuTưTheoLoạiHìnhthônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDauTuTheoLoaiHinhThon rp = new BCDauTuTheoLoaiHinhThon();
            frm.RP = rp;
            frm.ThonIDName = "{tbl_Thon.ID}";
            frm.VuTrongIDName = "{View_HDThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp vốn đầu tư theo loại hình đầu tư.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void đầuTưTheoLoạiHìnhxãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDauTuTheoLoaiHinhXa rp = new BCDauTuTheoLoaiHinhXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{View_HDThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp vốn đầu tư theo loại hình đầu tư.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void đầuTưTheoLoạiHìnhvùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDauTuTheoLoaiHinhVung rp = new BCDauTuTheoLoaiHinhVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_HDThuaRuong.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp vốn đầu tư theo loại hình đầu tư toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void tổngHợpDưNợĐầuTưToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCTongHopThuHoiDuNoDauTuMia rp = new BCTongHopThuHoiDuNoDauTuMia();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BCThuHoiDuNoDauTu.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp thu hồi dư nợ đầu tư mía.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void cácHộNợĐầuTưToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            BCDSCacHoNoDauTu rp = new BCDSCacHoNoDauTu();
            frm.RP = rp;
            frm.XaIDName = "{View_BCThuHoiDuNoDauTu.XaID}";
            frm.VuTrongIDName = "{View_BCThuHoiDuNoDauTu.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp diện tích trồng mía.";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void tổngHợpĐầuTưVàThuHồiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCTongHopDauTuVaThuHoiVung rp = new BCTongHopDauTuVaThuHoiVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_VuTrong.ID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo tổng hợp đầu tư và thu hồi theo lĩnh vực đầu tư toàn vùng nguyên liệu.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void đầuTưVàThuHồiTheoHệSốToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            BCDauTuVaThuHoiTheoHeSoLaiSuat rp = new BCDauTuVaThuHoiTheoHeSoLaiSuat();
            frm.RP = rp;
            frm.VuTrongIDName = "{tbl_VuTrong.ID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Báo cáo đầu tư và thu hồi vốn đầu tư theo hệ số lãi suất.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void theoThônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuThon rp = new rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuThon();
            frm.RP = rp;
            frm.ThonIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDThon}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = " Tổng hớp Đầu tư vốn - Thu hồi vốn - Dư nợ vốn văy trồng mía";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void theoXãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuXa rp = new rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuXa();
            frm.RP = rp;
            frm.XaIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDXa}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thu hồi vốn dư nợ theo xã";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void theoVùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuVung rp = new rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thu hồi vốn dư nợ toàn vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void chiTiếtToànVùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuVungChiTiet rp = new rp_T_BCTongHopDauTu_ThuHoi_DuNoVonDauTuVungChiTiet();
            frm.RP = rp;
            frm.ThonIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDThon}";
            frm.XaIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDXa}";
            frm.DonViEnable = 1;
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = " Tổng hớp Đầu tư vốn - Thu hồi vốn - Dư nợ vốn văy trồng mía";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void theoThônToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopKetQuaThuHoiVonDauTuThon rp = new rp_T_BCTongHopKetQuaThuHoiVonDauTuThon();
            frm.RP = rp;
            frm.ThonIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDThon}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía theo thôn";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void theoXãToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopKetQuaThuHoiVonDauTuXa rp = new rp_T_BCTongHopKetQuaThuHoiVonDauTuXa();
            frm.RP = rp;
            frm.XaIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDXa}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía theo xã";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void toànVùngToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_T_BCTongHopKetQuaThuHoiVonDauTuVung rp = new rp_T_BCTongHopKetQuaThuHoiVonDauTuVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";
            frm.ParameterOn = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía toàn vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void chiTiếtToànVùngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_BCTongHopKetQuaThuHoiVonDauTuVungChiTiet rp = new rp_T_BCTongHopKetQuaThuHoiVonDauTuVungChiTiet();
            frm.RP = rp;
            frm.DonViEnable = 1;
            frm.ThonIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDThon}";
            frm.XaIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDXa}";
            frm.VuTrongIDName = "{View_T_RPTongHopThuHoiVonDauTu.IDVuTrong}";

            frm.ParameterOn = 1;//rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Dư nợ trồng mía";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void thônToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_BaoCaoTienDoThuHoachMiaNguyenLieuThon rp = new rp_BaoCaoTienDoThuHoachMiaNguyenLieuThon();
            frm.RP = rp;
            frm.ThonIDName = "{View_ThuHoachMiaNguyenLieu.ThonID}";
            frm.VuTrongIDName = "{View_ThuHoachMiaNguyenLieu.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ thu hoạch mía nguyên liệu thôn";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void xãToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_BaoCaoTienDoThuHoachMiaNguyenLieuXa rp = new rp_BaoCaoTienDoThuHoachMiaNguyenLieuXa();
            frm.RP = rp;
            frm.XaIDName = "{tbl_Xa.ID}";
            frm.VuTrongIDName = "{View_ThuHoachMiaNguyenLieu.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ thu hoạch mía nguyên liệu thôn";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void vùngToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoTienDoThuHoachMiaNguyenLieuToanVung rp = new rp_BaoCaoTienDoThuHoachMiaNguyenLieuToanVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_ThuHoachMiaNguyenLieu.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ thu hoạch mía nguyên liệu toàn vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void cânNhậpNgàyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXe rp = new rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXe();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_KetQuaCanNhapMiaNguyenLieuXe.VuTrongID}";
            frm.NgayLocName = "{View_KetQuaCanNhapMiaNguyenLieuXe.NgayVanChuyen}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả vận chuyển mía Chủ hợp đồng vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void cânNhậpVùngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rpt_KetQuaCanNhapMiaNguyenLieu rp = new rpt_KetQuaCanNhapMiaNguyenLieu();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_ThuHoachMiaNguyenLieu.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả cân nhập mía vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void tổngHợpNhậpMíaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoTongHopNhapMia rp = new rp_BaoCaoTongHopNhapMia();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_TongHopNhapMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp nhập mía";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void lệnhThuHoạchMíaNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_LenhThuHoachMiaNguyenLieu rp = new rp_LenhThuHoachMiaNguyenLieu();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_LamLenhThuHoachMiaNguyenLieu.VuTrongID}";
            frm.NgayLocName = "{View_LamLenhThuHoachMiaNguyenLieu.NgayChat}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Lệnh thu hoạch mía nguyên liệu";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void thônToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_ChiTietTienDoDienTichTrongMiaXa rp = new rp_ChiTietTienDoDienTichTrongMiaXa();
            frm.RP = rp;
            frm.ThonIDName = "{View_ChiTietTienDoTrongMia.ThonID}";
            frm.VuTrongIDName = "{View_ChiTietTienDoTrongMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ trồng mía thôn";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void xãToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_ChiTietTienDoDienTichTrongMiaXa rp = new rp_ChiTietTienDoDienTichTrongMiaXa();
            frm.RP = rp;
            frm.XaIDName = "{View_ChiTietTienDoTrongMia.XaID}";
            frm.VuTrongIDName = "{View_ChiTietTienDoTrongMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ trồng mía xã";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void vùngToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_ChiTietTienDoDienTichTrongMiaVung rp = new rp_ChiTietTienDoDienTichTrongMiaVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BaoCaoChiTietTienDoTrongMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ trồng mía vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void theoĐợtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Waiting();
            //frmShowRP2 frm = new frmShowRP2();
            //rp_T_DS_CacHoThanhToanMia_TheoDot rp = new rp_T_DS_CacHoThanhToanMia_TheoDot();
            //frm.RP = rp;
            //frm.ParameterOn = 1;
            //frm.VuTrongIDName = "{tbl_VuTrong.ID}";
            //frm.DotThanhToanName = "{tbl_HopDong_DaLamThanhToan.DotThanhToan}";
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            //frm.RPtitle = "Danh sách tổng hợp hợp đồng làm thanh tóan";
            //frm.MdiParent = this;
            //frm.Show();
            //Waited();
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            ZTongHopThanhToanTienMiaNguyenLieu rp = new ZTongHopThanhToanTienMiaNguyenLieu();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{tbl_VuTrong.ID}";
            frm.DotThanhToanName = "{tbl_HopDong_DaLamThanhToan.DotThanhToan}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Danh sách tổng hợp hợp đồng làm thanh tóan";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void thaoVụTrồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_T_DS_CacHoThanhToanMia_TheoVu rp = new rp_T_DS_CacHoThanhToanMia_TheoVu();
            frm.RP = rp;

            frm.VuTrongIDName = "{tbl_VuTrong.ID}";
            //frm.DotThanhToanName = "{tbl_HopDong_DaLamThanhToan.DotThanhToan}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Danh sách tổng hợp hợp đồng làm thanh tóan";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void chủHĐVCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rpt_ThanhToanChuHopDongVanChuyenMoi rp = new rpt_ThanhToanChuHopDongVanChuyenMoi();
            frm.RP = rp;
            //{View_ThanhToanChuHopDongVanChuyen.IDVuTrong}{View_ThanhToanChuHopDongVanChuyen.IDChuHopDongVanChuyen}

            frm.HopDongVC_ID_Name = "{View_ThanhToanChuHopDongVanChuyen.IDChuHopDongVanChuyen}";
            frm.VuTrongIDName = "{View_ThanhToanChuHopDongVanChuyen.IDVuTrong}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thanh toán chủ hợp đồng vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void toànVùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoThanhToanChuHopDongVanChuyenVung rp = new rp_BaoCaoThanhToanChuHopDongVanChuyenVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_BaoCaoTongHopChuHopDongVanChuyen.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thanh toán chủ hợp đồng vận chuyển vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void chủHợpĐồngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_KetQuaVanChuyenMiaChuVanChuyen rp = new rp_KetQuaVanChuyenMiaChuVanChuyen();
            frm.RP = rp;
            frm.HopDongVC_ID_Name = "{tbl_HopDongVanChuyen.ID}";
            frm.VuTrongIDName = "{tbl_VuTrong.ID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả vận chuyển mía Chủ hợp đồng vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void toànVùngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoKetQuaVanChuyenMiaToanVung rp = new rp_BaoCaoKetQuaVanChuyenMiaToanVung();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_VanChuyenMiaVung.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kết quả vận chuyển mía vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void chủHợpĐồngToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_BaoCaoTamUngCuaChuHopDongVanChuyen rp = new rp_BaoCaoTamUngCuaChuHopDongVanChuyen();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_UngVatTuChuHopDong.IDVuTrong}";
            frm.HopDongVC_ID_Name = "{View_UngVatTuChuHopDong.HopDongVanChuyenID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tạm ứng chủ hợp đồng vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void toànVùngToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoTamUngVanChuyenVuMia rp = new rp_BaoCaoTamUngVanChuyenVuMia();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_UngVatTuChuHopDong.IDVuTrong}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tạm ứng vận chuyển toàn vùng";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void cửaHàngỨngVậnChuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_BaoCaoTamUngVatTuCuaHang rp = new rp_BaoCaoTamUngVatTuCuaHang();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_UngVatTuVanChuyenCuaHang.IDVuTrong}";
            //frm.NgayLocName = "{View_UngVatTuVanChuyenCuaHang.NgayUng}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Ứng vật tư của của hàng";
            frm.MdiParent = this;
            frm.Show(); Waited();

        }

        private void ứngDầuToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiUngDauVanChuyenVuMia rp = new rp_MoiUngDauVanChuyenVuMia();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_MoiUngDauVanChuyenMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp ứng dầu vận chuyển chủ hợp đồng vận chuyển.";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void thuHoạchToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiTienDoThuHoachVuMia rp = new rp_MoiTienDoThuHoachVuMia();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_MoiTienDoThuHoachMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp vận chuyển mía theo vụ";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void vậnChuyểnToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiTienDoVanChuyenMiaVuMia rp = new rp_MoiTienDoVanChuyenMiaVuMia();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_MoiTienDoVanChuyenMia.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp vận chuyển mía theo vụ";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void ứngDầuToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiUngDauVanChuyenTheoNgay rp = new rp_MoiUngDauVanChuyenTheoNgay();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_MoiUngDauVanChuyenMoi.VuTrongID}";
            // frm.DotThanhToanName = "{View_MoiUngDauVanChuyenMoi.DotThanhToan}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Ứng Dầu vận chuyển theo ngày";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void thuHoạchToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiTienDoThuHoachMiaNgay rp = new rp_MoiTienDoThuHoachMiaNgay();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_MoiTienDoThuHoachMia.VuTrongID}";
            // frm.DotThanhToanName = "{View_MoiUngDauVanChuyenMoi.DotThanhToan}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ thu hoạch ngày";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void vậnChuyểnToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiTienDoVanChuyenMiaNgay rp = new rp_MoiTienDoVanChuyenMiaNgay();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_MoiTienDoVanChuyenMiaNgay.VuTrongID}";
            // frm.DotThanhToanName = "{View_MoiUngDauVanChuyenMoi.DotThanhToan}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ vận chuyển mía ngày";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void danhMucKhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_DSKH rp = new rp_DSKH();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.DonViEnable = 1;
            frm.SecssionSuppress = 8;
            frm.ThonIDName = "{tbl_thon.id}";
            frm.XaIDName = "{tbl_Xa.id}";
            frm.VuTrongIDName = "{tbl_VuTrong.id}";

            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Danh sách khách hàng";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void mnuMayTinhCaNhan_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
            //System.Diagnostics.Process.Start("osk.exe");
        }

        private void mnuUniKey_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("UniKey\\UniKeyNT.exe");
        }


        private void nhậpGiáMíaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmNhapGiaMia frm = new frmNhapGiaMia();
            frm.ShowDialog();
        }

        private void chiTiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTheoDoiNhapMia.OneInstanceFrm.MdiParent = this;
            frmTheoDoiNhapMia.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            frmTheoDoiNhapMia.OneInstanceFrm.Show();
        }


        private void báoCáoTiếnĐộThuHoạchMíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiBCTienDoThuHoachMia rp = new rp_MoiBCTienDoThuHoachMia();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_BCTienDoThuHoachMia.VuTrongID}";
            // frm.DotThanhToanName = "{View_MoiUngDauVanChuyenMoi.DotThanhToan}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tiến độ vận chuyển mía ngày";
            frm.MdiParent = this;
            frm.Show();
            Waited();


        }

        private void cácHộVượtNăngSuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_MoiVuotNangSuat rp = new rp_MoiVuotNangSuat();
            frm.RP = rp;
            frm.VuTrongIDName = "{View_12.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Các hộ vượt năng suất";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }

        private void tổngHợpNhậpMíaNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            rp_NhapMiaTheoNgay rp = new rp_NhapMiaTheoNgay();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_NhapMiaTheoNgay.VuTrongID}";
            // frm.DotThanhToanName = "{View_MoiUngDauVanChuyenMoi.DotThanhToan}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tình hình nhập mía ngày";
            frm.MdiParent = this;
            frm.Show();
            Waited();




        }

        private void mnuVonDauTuTheoLoaiHinhDauTu_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rp_T_TongHopDauTuCacXaTheoLinhVucDT rp = new rp_T_TongHopDauTuCacXaTheoLinhVucDT();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.DonViEnable = 1;
            //frm.ThonIDName = "{tbl_thon.id}";
            frm.XaIDName = "{tbl_Xa.id}";
            frm.VuTrongIDName = "{tbl_VuTrong.id}";
            //frm.SecssionSuppress = 8;
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp đầu tư theo loại hình";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void chủHĐVCKhôngChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Waiting();
            frmShowRP_TheoDonVi frm = new frmShowRP_TheoDonVi();
            rpt_MoiThanhToanChuHopDongVanChuyen rp = new rpt_MoiThanhToanChuHopDongVanChuyen();
            frm.RP = rp;
            frm.HopDongVC_ID_Name = "{MoiThanhToanChuHopDongVanChuyen.HopDongVanChuyenID}";
            frm.VuTrongIDName = "{MoiThanhToanChuHopDongVanChuyen.VuTrongID}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Thanh toán chủ hợp đồng vận chuyển";
            frm.MdiParent = this;
            frm.Show(); Waited();
        }
        int iKetQuaTimHD;
        int iKetQuaTimHDVC;
        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            iKetQuaTimHD = 0;
            iKetQuaTimHDVC = 0;
            TimKiem();
            if (iKetQuaTimHDVC + iKetQuaTimHD > 0)
            {
                OpenKetQua();
            }
            else
            {
                CloseKetQua();
            }
        }
        void OpenKetQua()
        {
            grTimKiem.Height = 248;
            btKetQua.Visible = true;
        }
        void CloseKetQua()
        {

            grTimKiem.Height = 70;
            btKetQua.Visible = false;

        }
        void TimKiem()
        {
            if (tbTimKiem.Text.ToString().Trim().Length > 0)
            {
                TimKiemHopDong();
                TimKiemHopDongVC();
            }
            else
            {
                GVHopDong.DataSource = null;
                tab_HopDong.Text = "Hợp đồng(0)";
                GVHopDongVC.DataSource = null;
                tab_HopDongVC.Text = "Hợp đồng VC(0)";
            }

        }
        void TimKiemHopDong()
        {
            GVHopDong.AutoGenerateColumns = false;
            try
            {
                string Sql_where = "";
                string Sql_order = "";
                if (rdMa.Checked == true)
                {
                    Sql_where = "MaHopDong like N'%" + DBModule.RefineString(tbTimKiem.Text) + "%'";
                    Sql_order = "MaHopDong";
                }
                else
                {
                    Sql_where = "HoTen like N'%" + DBModule.RefineString(tbTimKiem.Text) + "%'";
                    Sql_order = "HoTen";
                }
                DataSet ds = clsHopDong.GetListbyWhereThon("", Sql_where, Sql_order, null, null);
                if (ds.Tables[0] != null)
                {

                    GVHopDong.DataSource = ds.Tables[0];
                    GVHopDong.Show();
                    tab_HopDong.Text = "Hợp Đồng(" + ds.Tables[0].Rows.Count + ")";
                    iKetQuaTimHD = ds.Tables[0].Rows.Count;
                }
            }
            catch { }

        }
        void TimKiemHopDongVC()
        {
            GVHopDongVC.AutoGenerateColumns = false;
            try
            {
                string Sql_where = "";
                string Sql_order = "";
                if (rdMa.Checked == true)
                {
                    Sql_where = "MaHopDong like N'%" + DBModule.RefineString(tbTimKiem.Text) + "%'";
                    Sql_order = "MaHopDong";
                }
                else
                {
                    Sql_where = "TenChuHopDong like N'%" + DBModule.RefineString(tbTimKiem.Text) + "%'";
                    Sql_order = "TenChuHopDong";
                }
                DataSet ds = clsHopDongVanChuyen.GetListbyWhere("", Sql_where, Sql_order, null, null);
                if (ds.Tables[0] != null)
                {

                    GVHopDongVC.DataSource = ds.Tables[0];
                    GVHopDongVC.Show();
                    tab_HopDongVC.Text = "Hợp Đồng VC(" + ds.Tables[0].Rows.Count + ")";
                    iKetQuaTimHDVC = ds.Tables[0].Rows.Count;
                }
            }
            catch { }
        }

        private void rdMa_CheckedChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void btThongTinNN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.GVHopDong.SelectedRows[0].ToString()))
                {
                    string s = this.GVHopDong.SelectedRows[0].Cells["ID"].Value.ToString();
                    long oID = long.Parse(s);
                    frmViewHopDong aa = new frmViewHopDong(oID);
                    aa.uiTab1.SelectedIndex = 0;
                    aa.MdiParent = this.MdiParent;
                    aa.Show();
                }
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.GVHopDong.SelectedRows[0].ToString()))
                {
                    string s = this.GVHopDong.SelectedRows[0].Cells["ID"].Value.ToString();
                    long oID = long.Parse(s);
                    frmViewHopDong aa = new frmViewHopDong(oID);
                    aa.uiTab1.SelectedIndex = 1;
                    aa.MdiParent = this.MdiParent;
                    aa.Show();
                }
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.GVHopDong.SelectedRows[0].ToString()))
                {
                    string s = this.GVHopDong.SelectedRows[0].Cells["ID"].Value.ToString();
                    long oID = long.Parse(s);
                    frmViewHopDong aa = new frmViewHopDong(oID);
                    aa.uiTab1.SelectedIndex = 2;
                    aa.MdiParent = this.MdiParent;
                    aa.Show();
                }
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.GVHopDong.SelectedRows[0].ToString()))
                {
                    string s = this.GVHopDong.SelectedRows[0].Cells["ID"].Value.ToString();
                    long oID = long.Parse(s);
                    frmViewHopDong aa = new frmViewHopDong(oID);
                    aa.uiTab1.SelectedIndex = 3;
                    aa.MdiParent = this.MdiParent;
                    aa.Show();
                }
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }

        }

        private void GVHopDong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.GVHopDong.SelectedRows[0].ToString()))
                {
                    string s = this.GVHopDong.SelectedRows[0].Cells["ID"].Value.ToString();
                    long oID = long.Parse(s);
                    frmViewHopDong aa = new frmViewHopDong(oID);

                    aa.MdiParent = this.MdiParent;
                    aa.Show();
                }
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void btUngVC_Click(object sender, EventArgs e)
        {
            try
            {
                //string ID = GVHopDongVC.SelectedRows[0].Cells["IDVC"].Value.ToString();
                //frmUngVatTuVanChuyen frm = new frmUngVatTuVanChuyen(ID);
                //frm.tvHopDongVanChuyen.SelectedNode = frm.tvHopDongVanChuyen.Nodes["Root"].Nodes[ID];
                //frm.uiPanel0.AutoHide = true;
                //frm.tvHopDongVanChuyen.Enabled = false;
                //frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void btThanhToanVC_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = GVHopDongVC.SelectedRows[0].Cells["IDVC"].Value.ToString();

                frmThanhToanVanChuyen frm = new frmThanhToanVanChuyen(ID);
                //frm.treeDonVi.SelectedNode = frm.treeDonVi.Nodes["Root"].Nodes[ID];
                //frm.treeDonVi.Enabled = false;
                //frm.uiPanel0.AutoHide = true;
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void GVHopDongVC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string ID = GVHopDongVC.SelectedRows[0].Cells["IDVC"].Value.ToString();
                frmChiTietChuVanChuyen frm = new frmChiTietChuVanChuyen(long.Parse(ID));

                frm.Show();

            }
            catch { MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết"); }
        }

        private void Menu_undo_Click(object sender, EventArgs e)
        {
            //frm_history frm = new frm_history();
            //frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbTimKiem.Text = "";

        }

        private void ngânHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDDataSetForms.frmNganHang frm = new MDSolution.MDDataSetForms.frmNganHang();
            frm.ShowDialog();
        }

        private void hooToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //MDSolution.MDDataSetForms.frmNhapHoTro frm = new MDSolution.MDDataSetForms.frmNhapHoTro();
            //frm.ShowDialog();
        }

        private void hợpĐồngVậnChuyểnVDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDDataSetForms.frmHopDongVanChuyen frm = new MDSolution.MDDataSetForms.frmHopDongVanChuyen();
            frm.ShowDialog();
        }



        private void tổngHợpDiệnTíchTrồngMíaHuyệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.THOP frm = new MDSolution.MDReport.FRM_Report.THOP();
            frm.Show();
        }

        private void đơnVịCungỨngVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDDataSetForms.frmDonViCungUngVT frm = new MDSolution.MDDataSetForms.frmDonViCungUngVT();
            frm.ShowDialog();
        }


        private void cmdTrongLai_Click_1(object sender, EventArgs e)
        {
            //MDDataSetForms.frmDangkiDienTich frm = new MDSolution.MDDataSetForms.frmDangkiDienTich();
            //frm.ShowDialog();

            // thanh sua lai
            Waiting();
            frmDienTichCoCauTrong frm = new frmDienTichCoCauTrong();
            frm.Load_DienTichDangKy = true;
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void cmdTrongMoi_Click_1(object sender, EventArgs e)
        {
            MDDataSetForms.DangKyDauTu frm = new MDSolution.MDDataSetForms.DangKyDauTu();
            frm.ShowDialog();
        }

        private void insertMenuItem()
        {
            foreach (ToolStripItem mitem in mnuHeThong.DropDownItems)
            {
                try
                {
                    string strSQL = "insert into sys_Chucnang(Tenhienthi,Tenmenu) values(N'" + mitem.Text + "','" + mitem.Name + "')";
                    DBModule.ExecuteNonQuery(strSQL, null, null);
                }
                catch { }
            }
            foreach (ToolStripItem mitem in MNU_DienTich.DropDownItems)
            {
                try
                {
                    string strSQL = "insert into sys_Chucnang(Tenhienthi,Tenmenu) values(N'" + mitem.Text + "','" + mitem.Name + "')";
                    DBModule.ExecuteNonQuery(strSQL, null, null);
                }
                catch { }
            }
            foreach (ToolStripItem mitem in MNU_DauTu.DropDownItems)
            {
                try
                {
                    string strSQL = "insert into sys_Chucnang(Tenhienthi,Tenmenu) values(N'" + mitem.Text + "','" + mitem.Name + "')";
                    DBModule.ExecuteNonQuery(strSQL, null, null);
                }
                catch { }
            }
            foreach (ToolStripItem mitem in MNU_NhapMia.DropDownItems)
            {
                try
                {
                    string strSQL = "insert into sys_Chucnang(Tenhienthi,Tenmenu) values(N'" + mitem.Text + "','" + mitem.Name + "')";
                    DBModule.ExecuteNonQuery(strSQL, null, null);
                }
                catch { }
            }
            foreach (ToolStripItem mitem in mnu_Thanhtoan.DropDownItems)
            {
                try
                {
                    string strSQL = "insert into sys_Chucnang(Tenhienthi,Tenmenu) values(N'" + mitem.Text + "','" + mitem.Name + "')";
                    DBModule.ExecuteNonQuery(strSQL, null, null);
                }
                catch { }
            }
            foreach (ToolStripItem mitem in mnu_VanChuyen.DropDownItems)
            {
                try
                {
                    string strSQL = "insert into sys_Chucnang(Tenhienthi,Tenmenu) values(N'" + mitem.Text + "','" + mitem.Name + "')";
                    DBModule.ExecuteNonQuery(strSQL, null, null);
                }
                catch { }
            }
        }

        private void caaToolStripMenuItem_Click(object sender, EventArgs e)
        {


            string strSQL = "delete from sys_Chucnang";
            DBModule.ExecuteNonQuery(strSQL, null, null);

            //this.Loadmenu();
            insertMenuItem();
            MessageBox.Show("Bạn đã cập nhật lại tên menu thành công", "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.TongHopNguyenLieu frm = new MDSolution.MDReport.FRM_Report.TongHopNguyenLieu();
            frm.Show();

        }

        private void tổngHợpVềĐầuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.BieuTongHopGiongMia frm = new MDSolution.MDReport.FRM_Report.BieuTongHopGiongMia();
            frm.Show();
        }



        private void đốiChiếuHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            VietDai_KiemTraHop rp = new VietDai_KiemTraHop();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_VietDai-DienTichNghiemThuTheBanDieuTra.VuTrongID}";
            // frm.DotThanhToanName = "{View_MoiUngDauVanChuyenMoi.DotThanhToan}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kiểm tra hợp đồng nhập vào hệ thống";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void nhậpNợCũChủHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapNoCuChuHopDong frm = new frmNhapNoCuChuHopDong();
            frm.ShowDialog();
        }

        private void đốiChiếuTrạmXãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            VietDai_DanhMucMaXaTramHuyen rp = new VietDai_DanhMucMaXaTramHuyen();
            frm.RP = rp;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kiểm tra danh muc xa tram huyen";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void đốiChiếuNợCũToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            NoCuChuHopDong rp = new NoCuChuHopDong();
            frm.RP = rp;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kiểm tra danh muc xa tram huyen";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void nợCũChủHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmDanhSachCacKhoanNoCu frm = new frmDanhSachCacKhoanNoCu();
            frm.ShowInTaskbar = false;
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void cmdChamSoc_Click_1(object sender, EventArgs e)
        {
            Waiting();
            frmQuanLyChamSoc frm = new frmQuanLyChamSoc();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void tổngHợpĐầuTưToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            MDSolution.MDReport.FRM_Report.TongHopDauTu frm = new MDSolution.MDReport.FRM_Report.TongHopDauTu();
            frm.Show();
            Waited();
        }

        private void đầuTưTheoĐợtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            MDSolution.MDReport.FRM_Report.TongHopDauTuTheoDot frm = new MDSolution.MDReport.FRM_Report.TongHopDauTuTheoDot();
            frm.Show();
            Waited();
        }

        private void nhậpTiềnMặtTrảNợCôngTyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmQuanLyTienTraNo frm = new frmQuanLyTienTraNo();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void ngàyChốtTínhLãiĐầuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmNgayChotTinhLai frm = new frmNgayChotTinhLai();
            frm.ShowDialog();
            Waited();
        }

        private void tạmỨngTiềnMíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmQuanLyUngTienMia frm = new frmQuanLyUngTienMia();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void muaVậtTưCủaCôngTyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmDanhSachMuaVatTuCty frm = new frmDanhSachMuaVatTuCty();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void biểuTổngHợpDiệnTíchTrồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.THOP frm = new MDSolution.MDReport.FRM_Report.THOP();
            frm.Show();
        }

        private void biểuTổngHợpNguyênLiệuVàMíaGiốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.TongHopNguyenLieu frm = new MDSolution.MDReport.FRM_Report.TongHopNguyenLieu();
            frm.Show();

        }

        private void biểuTổngHợpTheoCơCấuGiốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.BieuTongHopGiongMia frm = new MDSolution.MDReport.FRM_Report.BieuTongHopGiongMia();
            frm.Show();
        }

        private void biểuTổngHợpĐầuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tổngHợpDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            MDSolution.MDReport.FRM_Report.TongHopDauTu frm = new MDSolution.MDReport.FRM_Report.TongHopDauTu();
            frm.Show();
            Waited();
        }

        private void đầuTưTheoĐợtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Waiting();
            MDSolution.MDReport.FRM_Report.TongHopDauTuTheoDot frm = new MDSolution.MDReport.FRM_Report.TongHopDauTuTheoDot();
            frm.Show();
            Waited();
        }

        private void xeVậnChuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.DoiChieuXeVanChuyen frm = new MDSolution.MDReport.FRM_Report.DoiChieuXeVanChuyen();
            frm.Show();
        }

        private void chủHợpĐồngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.DoiChieuChuHopDong frm = new MDSolution.MDReport.FRM_Report.DoiChieuChuHopDong();
            frm.Show();
        }

        private void mẫuQuyếtToánNhàCânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.BieuTongHopVanChuyenNgay frm = new MDSolution.MDReport.FRM_Report.BieuTongHopVanChuyenNgay();
            frm.Show();

        }

        private void mẫuKiểuTraSốLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.BieuDoiChieuNhaCan frm = new MDSolution.MDReport.FRM_Report.BieuDoiChieuNhaCan();
            frm.Show();
        }

        private void đơnVịĐầuTưGiánTiếpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.TongHopDauTuGianTiep frm = new MDSolution.MDReport.FRM_Report.TongHopDauTuGianTiep();
            frm.Show();
        }

        private void nợCũHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            NoCuTheoVuTrong rp = new NoCuTheoVuTrong();
            frm.RP = rp;
            //frm.ParameterOn = 1;
            //frm.VuTrongIDName = "{View_MoiTienDoThuHoachMia.VuTrongID}";
            // frm.DotThanhToanName = "{View_MoiUngDauVanChuyenMoi.DotThanhToan}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kiểm tra hợp đồng nhập vào hệ thống";
            frm.MdiParent = this;
            frm.Show();
            Waited();

        }

        private void biểuChínhSáchGiốngMíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.BieuTongHopTheoGiongMia frm = new MDSolution.MDReport.FRM_Report.BieuTongHopTheoGiongMia();
            frm.Show();

        }

        private void tổngHợpThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.BieuTongHopThanhToan frm = new MDSolution.MDReport.FRM_Report.BieuTongHopThanhToan();
            frm.Show();

        }

        private void thanhToaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.BieuTongHopThanhToanTheoDot frm = new MDSolution.MDReport.FRM_Report.BieuTongHopThanhToanTheoDot();
            frm.Show();

        }

        private void biểuTổngHợpPhếCanhChặtGiốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.BieuTongHopPheCanhChatGiong frm = new MDSolution.MDReport.FRM_Report.BieuTongHopPheCanhChatGiong();
            frm.Show();
        }

        private void đốiChiếuHợpĐồngĐăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            VietDai_KiemTraHopDanhKy rp = new VietDai_KiemTraHopDanhKy();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.VuTrongIDName = "{View_VietDai-DienTichNghiemThuTheBanDieuTra.VuTrongID}";
            // frm.DotThanhToanName = "{View_MoiUngDauVanChuyenMoi.DotThanhToan}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kiểm tra hợp đồng đăng ký nhập vào hệ thống";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.TongHopThanhToan frm = new MDSolution.MDReport.FRM_Report.TongHopThanhToan();
            frm.Show();

        }

        private void biểuTrưNợĐầuTưTheoLoạiHìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.TruNoCacCongTy frm = new MDSolution.MDReport.FRM_Report.TruNoCacCongTy();
            frm.Show();

        }

        private void biểuTrừNợĐơnVịĐầuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.TruNoCacDonViGianTiep frm = new MDSolution.MDReport.FRM_Report.TruNoCacDonViGianTiep();
            frm.Show();

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.ThanhToanNganHangTheoDot frm = new MDSolution.MDReport.FRM_Report.ThanhToanNganHangTheoDot();
            frm.Show();
        }

        private void mnuVanChuyen_Click(object sender, EventArgs e)
        {

        }

        private void đốiChiếuTàiKhoảnNgânHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP2 frm = new frmShowRP2();
            VietDai_DoiChieuTaiKhoan rp = new VietDai_DoiChieuTaiKhoan();
            frm.RP = rp;
            //frm.ParameterOn = 1;
            //frm.VuTrongIDName = "{View_MoiTienDoThuHoachMia.VuTrongID}";
            // frm.DotThanhToanName = "{View_MoiUngDauVanChuyenMoi.DotThanhToan}";
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Kiểm tra tài khoản ngân hàng";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void baoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.MauChinhSachMuaVatTuVaUng frm = new MDSolution.MDReport.FRM_Report.MauChinhSachMuaVatTuVaUng();
            frm.Show();

        }

        private void biểuTổngHợpDiêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.BieuTongHopDienTichNguyenLieuMotTram frm = new MDSolution.MDReport.FRM_Report.BieuTongHopDienTichNguyenLieuMotTram();
            frm.Show();
        }

        private void biểu3QuyếtToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.BieuDoiChieuNhaCanBieu3 frm = new MDSolution.MDReport.FRM_Report.BieuDoiChieuNhaCanBieu3();
            frm.Show();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.HoTroTheoSanLuong frm = new MDSolution.MDReport.FRM_Report.HoTroTheoSanLuong();
            frm.Show();

        }


        private void đônĐốcChămSócToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.ChamSocDonDoc frm = new MDSolution.MDReport.FRM_Report.ChamSocDonDoc();
            frm.Show();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.ChamSoc frm = new MDSolution.MDReport.FRM_Report.ChamSoc();
            frm.Show();

        }

        private void biểuXemNhậpMíaNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.CanMiaNgay frm = new MDSolution.MDReport.FRM_Report.CanMiaNgay();
            frm.Show();

        }

        private void traCứuNợCũToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapNoCuChuHopDong frm = new frmNhapNoCuChuHopDong();
            frm.ShowDialog();
        }

        private void tổngHợpThanhToánToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.BieuTongHopThanhToan frm = new MDSolution.MDReport.FRM_Report.BieuTongHopThanhToan();
            frm.Show();
        }

        private void thanhToánTheoĐợtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.BieuTongHopThanhToanTheoDot frm = new MDSolution.MDReport.FRM_Report.BieuTongHopThanhToanTheoDot();
            frm.Show();
        }

        private void biểuTrừNợĐầuTưTheoLoạiHìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.TruNoCacCongTy frm = new MDSolution.MDReport.FRM_Report.TruNoCacCongTy();
            frm.Show();
        }

        private void biểuTrừNợĐơnVịĐầuTưToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.TruNoCacDonViGianTiep frm = new MDSolution.MDReport.FRM_Report.TruNoCacDonViGianTiep();
            frm.Show();
        }

        private void biểuThanhToánNgânHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDReport.FRM_Report.ThanhToanNganHangTheoDot frm = new MDSolution.MDReport.FRM_Report.ThanhToanNganHangTheoDot();
            frm.Show();
        }



        private void nơiTạmỨngVậtTưVậnChuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_NoiUngVatTu frm = new Frm_NoiUngVatTu();
            frm.ShowDialog();
        }

        private void chuyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MDDataSetForms.frmHopDongChuyenVu frm = new MDSolution.MDDataSetForms.frmHopDongChuyenVu();
            frm.ShowDialog();
        }

        private void cánBộNôngVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCanBoNongVu.OneInstanceFrm.MdiParent = this;
            frmCanBoNongVu.OneInstanceFrm.Show();

        }

        private void mnnhapmiagiong_Click(object sender, EventArgs e)
        {
            Waiting();
            //frmThanhToanGoiY frm = new frmThanhToanGoiY();
            //frm.MdiParent = this;
            //frm.Show();
            frmQuanLyNhapMiaGiong frm = new frmQuanLyNhapMiaGiong();
            frm.MdiParent = this;

            frm.Show();
            Waited();
        }

        private void tracuuDauTuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            MDForms.DauTu.DauTu_TuNgay_DenNgay.OneInstanceFrm.MdiParent = this;
            MDForms.DauTu.DauTu_TuNgay_DenNgay.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDForms.DauTu.DauTu_TuNgay_DenNgay.OneInstanceFrm.Show();
            Waited();
        }



        private void nmTraCuuNhapMiaGiong_Click(object sender, EventArgs e)
        {
            Waiting();
            MDForms.NhapMiaGiong.MiaGiong_TuNgay_DenNgay.OneInstanceFrm.MdiParent = this;
            MDForms.NhapMiaGiong.MiaGiong_TuNgay_DenNgay.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDForms.NhapMiaGiong.MiaGiong_TuNgay_DenNgay.OneInstanceFrm.Show();
            Waited();

        }

        private void mnuGiaMia_Click(object sender, EventArgs e)
        {
            frm_GiaMia frm = new frm_GiaMia();
            frm.ShowDialog();
        }

        private void cmdTheoDoiUngVC_Click(object sender, EventArgs e)
        {
            MDForms.frmTheoDoiUngVanChuyen.OneInstanceFrm.MdiParent = this;
            MDForms.frmTheoDoiUngVanChuyen.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDForms.frmTheoDoiUngVanChuyen.OneInstanceFrm.Show();
        }


        private void canbonongvuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCanBoNongVu frm = new frmCanBoNongVu();
            frm.MdiParent = this;
            frm.Show();
        }


        private void sổChiTiếtCôngNợVùngNlTheoTừngHộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            MDSolution.MDReport.FRM_Report.SoChiTietCongNoTheoHo frm = new MDReport.FRM_Report.SoChiTietCongNoTheoHo();
            frm.Show();
            Waited();
        }


        private void btn_giacuoc_Click(object sender, EventArgs e)
        {
            frmBaiTapKet frm = new frmBaiTapKet();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void phânCôngCánBộĐịaBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCanBoNongVu frm = new frmCanBoNongVu();
            frm.MdiParent = this;
            frm.Show();
        }

        private void baosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            MDSolution.MDReport.FRM_Report.BaoCaoTTVanChuyen frm = new MDReport.FRM_Report.BaoCaoTTVanChuyen();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
            Waited();
        }

        private void bảngKêThanhToánMíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            MDSolution.MDReport.FRM_Report.BangKeThanhTTMia_TheoCanBoDiaBan frm = new MDReport.FRM_Report.BangKeThanhTTMia_TheoCanBoDiaBan();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
            Waited();
        }


        private void inTổngHợpXeVậnChuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            MDSolution.MDReport.FRM_Report.VanChuyenTongHop frm = new MDReport.FRM_Report.VanChuyenTongHop();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
            Waited();
        }

        private void đầuTưTheoCánCBĐBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            MDSolution.MDReport.FRM_Report.BieuDauTuTheCBNV frm = new MDReport.FRM_Report.BieuDauTuTheCBNV();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
            Waited();
        }


        private void diệnTíchTheoCBNVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoCBNV frm = new frmShowRP_TheoCBNV();
            DienTichKTMDG rp = new DienTichKTMDG();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.DonViEnable = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích cơ cấu trồng";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void từĐiểnDanhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhMucTuDien frm = new frmDanhMucTuDien();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bãiTậpKếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaiTapKet frm = new frmBaiTapKet();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void cánBộNôngVụToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCanBoNongVu frm = new frmCanBoNongVu();
            frm.MdiParent = this;
            frm.Show();
        }


        private void ngânHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MDSolution.MDDataSetForms.frmNganHang frm = new MDSolution.MDDataSetForms.frmNganHang();
            frm.ShowDialog();
        }

        private void bảngKêHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoCBNVHD frm = new frmShowRP_TheoCBNVHD();
            DanhMucHopDong rp = new DanhMucHopDong();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.DonViEnable = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích cơ cấu trồng";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void sảnLượngTheoCBNVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoCBNVSL frm = new frmShowRP_TheoCBNVSL();
            MDSolution.MDReport.VanChuyenTheoCanBoNongVu rp = new VanChuyenTheoCanBoNongVu();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.DonViEnable = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích cơ cấu trồng";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void diệnTíchCBNVXứĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoCBNV_DD frm = new frmShowRP_TheoCBNV_DD();
            DienTichKTMDG_DD rp = new DienTichKTMDG_DD();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.DonViEnable = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích cơ cấu trồng";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void danhMụcVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDForms.CapVatTu.frmDanhMucVatTu frm = new MDSolution.MDForms.CapVatTu.frmDanhMucVatTu();
            frm.MdiParent = this;
            frm.Show();
        }


        private void chuyểnMộtHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDDataSetForms.frmHopDongChuyenVu frm = new MDSolution.MDDataSetForms.frmHopDongChuyenVu();
            frm.ShowDialog();
        }



        private void button6_Click_1(object sender, EventArgs e)
        {
            MDSolution.MDForms.CapVatTu.frmQuanLyVatTu.OneInstanceFrm.MdiParent = this;
            MDSolution.MDForms.CapVatTu.frmQuanLyVatTu.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDSolution.MDForms.CapVatTu.frmQuanLyVatTu.OneInstanceFrm.Show();
        }

        private void traCứuThuNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            MDForms.DauTu.DauTu_ThuNo_TuNgay_DenNgay.OneInstanceFrm.MdiParent = this;
            MDForms.DauTu.DauTu_ThuNo_TuNgay_DenNgay.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDForms.DauTu.DauTu_ThuNo_TuNgay_DenNgay.OneInstanceFrm.Show();
            Waited();
        }

        private void địnhMứcĐâuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Waiting();
            MDForms.frm_ShowDinhMucDauTu.OneInstanceFrm.MdiParent = this;
            MDForms.frm_ShowDinhMucDauTu.OneInstanceFrm.Show();
            //frmShowRP_TheoCBNV_DT frm = new frmShowRP_TheoCBNV_DT();
            //MDSolution.MDReport.BCHopDongDienTichDauTu rp = new BCHopDongDienTichDauTu();
            //frm.RP = rp;
            //frm.ParameterOn = 1;
            //frm.DonViEnable = 1;
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            //frm.RPtitle = "Tổng hợp diện tích cơ cấu trồng";
            //frm.MdiParent = this;
            //frm.Show();
            //Waited();
        }


        private void fromTheoDõiDiệnTíchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DienTich frm = new frm_DienTich();
            frm.MdiParent = this;
            frm.Show();
        }

        private void diệnTíchHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DienTichCBNV frm = new DienTichCBNV();
            frm.Show();
        }

        private void diênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DienTichCBNVTong frm = new DienTichCBNVTong();
            frm.Show();
        }

        private void đầuTưTheoVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DauTuVatTu frm = new frm_DauTuVatTu();
            frm.Show();
        }

        private void chiTiếtCôngNợĐầuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            MDForms.DauTu.DauTuThuNoTheoHo.OneInstanceFrm.MdiParent = this;
            MDForms.DauTu.DauTuThuNoTheoHo.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDForms.DauTu.DauTuThuNoTheoHo.OneInstanceFrm.Show();
            Waited();
        }

        private void địnhMứcĐầuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoCBNV_DT frm = new frmShowRP_TheoCBNV_DT();
            MDSolution.MDReport.BCHopDongDienTichDauTu rp = new BCHopDongDienTichDauTu();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.DonViEnable = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Tổng hợp diện tích định mức đầu tư hợp đồng";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void bảngKêHợpĐồngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Waiting();
            frmShowRP_TheoCBNVHD frm = new frmShowRP_TheoCBNVHD();
            DanhMucHopDong rp = new DanhMucHopDong();
            frm.RP = rp;
            frm.ParameterOn = 1;
            frm.DonViEnable = 1;
            rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            frm.RPtitle = "Biều kê hợp đồng trồng mía ";
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void theoDõiĐầuTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DauTuVatTu frm = new frm_DauTuVatTu();
            frm.Show();
        }

        private void biểuLiênKếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frm_BieuLienKet frm = new frm_BieuLienKet();
            //frm.MdiParent = this;
            //frm.Show();
            MDSolution.MDForms.frm_BieuLienKet.OneInstanceFrm.MdiParent = this;
            MDSolution.MDForms.frm_BieuLienKet.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDSolution.MDForms.frm_BieuLienKet.OneInstanceFrm.Show();
        }

        private void nmBangCanDoiMiaGiong_Click(object sender, EventArgs e)
        {
            Waiting();
            MDForms.NhapMiaGiong.MiaGiong_BangCanDoi.OneInstanceFrm.MdiParent = this;
            MDForms.NhapMiaGiong.MiaGiong_BangCanDoi.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDForms.NhapMiaGiong.MiaGiong_BangCanDoi.OneInstanceFrm.Show();
            Waited();
        }

        private void mnDoiChieuCongNo_Click(object sender, EventArgs e)
        {
            Waiting();
            MDSolution.MDForms.DauTu.DoiChieuCongNo.OneInstanceFrm.MdiParent = this;
            MDSolution.MDForms.DauTu.DoiChieuCongNo.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDSolution.MDForms.DauTu.DoiChieuCongNo.OneInstanceFrm.Show();
            Waited();
        }

        private void traCứuTổngHợpVậnChuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            MDSolution.frm_TraCuuTT_VanChuyen.OneInstanceFrm.MdiParent = this;
            MDSolution.frm_TraCuuTT_VanChuyen.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDSolution.frm_TraCuuTT_VanChuyen.OneInstanceFrm.Show();
            Waited();
        }

        private void mnuChuyenVuDienTich_Click(object sender, EventArgs e)
        {
            long VuTronghienTai = MDSolutionApp.VuTrongID;
            clsVuTrong oVuTrong = new clsVuTrong(VuTronghienTai);
            oVuTrong.Load(null, null);
            bool DaChuyenVuDienTich = clsVuTrong.Check_ChuyenVu_DienTich(VuTronghienTai, null, null);
            bool DaChuyenVuDauTu = clsVuTrong.Check_ChuyenVu_DauTu(VuTronghienTai, null, null);
            if (DaChuyenVuDienTich)
            {
                MessageBox.Show("Đã chuyển dữ liệu diện tích sang vụ mới!\nĐược thực hiện ngày: " + oVuTrong.NgayKetChuyenDienTich.ToString("dd/MM/yyyy HH:mm:ss"), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            frmChuyenVu frm = new frmChuyenVu(DaChuyenVuDauTu);
            frm.ShowDialog();
        }

        private void mnuChuyenVuDauTu_Click(object sender, EventArgs e)
        {
            long VuTronghienTai = MDSolutionApp.VuTrongID;
            clsVuTrong oVuTrong = new clsVuTrong(VuTronghienTai);
            oVuTrong.Load(null, null);
            bool DaChuyenVuDienTich = clsVuTrong.Check_ChuyenVu_DienTich(VuTronghienTai, null, null);
            bool DaChuyenVuDauTu = clsVuTrong.Check_ChuyenVu_DauTu(VuTronghienTai, null, null);
            if (DaChuyenVuDauTu)
            {
                MessageBox.Show("Đã chuyển dữ liệu đầu tư sang vụ mới!\nĐược thực hiện ngày: " + oVuTrong.NgayKetChuyenDauTu.ToString("dd/MM/yyyy HH:mm:ss"), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            MDSolution.MDForms.DauTu.frm_KetChuyenVu_Confirm frm = new MDSolution.MDForms.DauTu.frm_KetChuyenVu_Confirm();
            DataSet ds = new DataSet();
            string sql = "";
            string sqlVuTrong = "select ID,Ten From tbl_VuTrong Where OrderThanhToan > (Select OrderThanhToan From tbl_VuTrong Where ID=" + MDSolutionApp.VuTrongID.ToString() + ")";
            ds = DBModule.ExecuteQuery(sqlVuTrong, null, null);
            frm.ComboVuTrong.DataSource = ds.Tables[0];
            frm.ComboVuTrong.DisplayMember = "Ten";
            frm.ComboVuTrong.ValueMember = "ID";
            sql = "select ID,Ten from tbl_DanhMucDauTu Where [LoaiHinhDauTuID]=7";
            frm.comboDMGoc.DataSource = DBModule.ExecuteQuery(sql, null, null).Tables[0];
            frm.comboDMGoc.DisplayMember = "Ten";
            frm.comboDMGoc.ValueMember = "ID";
            frm.comboDMLai.DataSource = DBModule.ExecuteQuery(sql, null, null).Tables[0];
            frm.comboDMLai.DisplayMember = "Ten";
            frm.comboDMLai.ValueMember = "ID";

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!DaChuyenVuDienTich)
                {
                    string sqlCopyHopDong = "coppyHopDong " + frm.ComboVuTrong.SelectedValue.ToString();
                    DBModule.ExecuteNonQuery(sqlCopyHopDong, null, null);
                }
                sql = "sp_2017_KetChuyenVu_DauTu " + MDSolutionApp.VuTrongID.ToString() + ", " + frm.ComboVuTrong.SelectedValue.ToString() + "," + DBModule.RefineDatetime(frm.dtNgayTinhLai.Value) + "," + frm.comboDMGoc.SelectedValue.ToString() + "," + frm.comboDMLai.SelectedValue.ToString() + "," + MDSolutionApp.User.ID.ToString();
                try
                {
                    DBModule.ExecuteNonQuery(sql, null, null);
                    MessageBox.Show("Kết chuyển dữ liệu đầu tư sang vụ mới thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi!\n" + ex.Message, "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void mnuTienDoHoach_Click(object sender, EventArgs e)
        {
            frm_KeHoach_TheoDoiTienDoThuHoach.OneInstanceFrm.MdiParent = this;
            frm_KeHoach_TheoDoiTienDoThuHoach.OneInstanceFrm.Show();
        }

        private void mnuDienTichNongHo_Click(object sender, EventArgs e)
        {
            Waiting();
            MDSolution.frmDienTichCoCauTrong.OneInstanceFrm.MdiParent = this;
            MDSolution.frmDienTichCoCauTrong.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDSolution.frmDienTichCoCauTrong.OneInstanceFrm.Show();
            Waited();
        }

        private void mnuDienTichCBDB_Click(object sender, EventArgs e)
        {
            MDSolution.MDForms.DienTich.frm_DienTichCBDB.OneInstanceFrm.MdiParent = this;
            MDSolution.MDForms.DienTich.frm_DienTichCBDB.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDSolution.MDForms.DienTich.frm_DienTichCBDB.OneInstanceFrm.Show();
        }

        private void mnuCapNhatLaiSuat_Click(object sender, EventArgs e)
        {
            MDSolution.MDForms.DauTu.CapNhatLaiSuat.OneInstanceFrm.MdiParent = this;
            MDSolution.MDForms.DauTu.CapNhatLaiSuat.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDSolution.MDForms.DauTu.CapNhatLaiSuat.OneInstanceFrm.Show();
        }

        private void cmdTamUng_Click(object sender, EventArgs e)
        {
            MDForms.frmTamUngVatTuVanChuyen.OneInstanceFrm.MdiParent = this;
            MDForms.frmTamUngVatTuVanChuyen.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDForms.frmTamUngVatTuVanChuyen.OneInstanceFrm.Show();
        }


        private void mnuTongHopCuocVanChuyen_Click(object sender, EventArgs e)
        {
            //Waiting();
            //MDSolution.MDReport.FRM_Report.BaoCaoTTVanChuyen frm = new MDReport.FRM_Report.BaoCaoTTVanChuyen();
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.Show();
            //Waited();
            MDForms.VanChuyen.frm_TongHopVanChuyen.OneInstanceFrm.MdiParent = this;
            MDForms.VanChuyen.frm_TongHopVanChuyen.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDForms.VanChuyen.frm_TongHopVanChuyen.OneInstanceFrm.Show();
        }

        private void mnuThanhToanTienMia_Click(object sender, EventArgs e)
        {
            MDForms.ThanhToan2016.frm_ThanhToan.OneInstanceFrm.MdiParent = this;
            MDForms.ThanhToan2016.frm_ThanhToan.OneInstanceFrm.Show();
            MDForms.ThanhToan2016.frm_ThanhToan.OneInstanceFrm.WindowState = FormWindowState.Maximized;
        }

        private void lịchSửSửaXóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_history frm = new frm_history();
            frm.ShowDialog();

        }

        private void mnuDienTichTrong_Click(object sender, EventArgs e)
        {

        }

        private void mnuChuyenVu_Click(object sender, EventArgs e)
        {

        }

        private void mnu_hotrodanhmuc_Click(object sender, EventArgs e)
        {
            frmDanhMucHoTro frm = new frmDanhMucHoTro();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnTraCuuHoTro_Click(object sender, EventArgs e)
        {
            Waiting();
            MDForms.DauTu.HoTro_TuNgay_DenNgay.OneInstanceFrm.MdiParent = this;
            MDForms.DauTu.HoTro_TuNgay_DenNgay.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDForms.DauTu.HoTro_TuNgay_DenNgay.OneInstanceFrm.Show();
            Waited();
        }

        private void mnuTruDauTuHoTro_Click(object sender, EventArgs e)
        {

            Waiting();
            MDForms.HoTro.frm_ChietTinhHoTroDauTu.OneInstanceFrm.MdiParent = this;
            MDForms.HoTro.frm_ChietTinhHoTroDauTu.OneInstanceFrm.WindowState = FormWindowState.Maximized;
            MDForms.HoTro.frm_ChietTinhHoTroDauTu.OneInstanceFrm.Show();
            Waited();
        }

        private void mnuNgayTinhLaiHoTro_Click(object sender, EventArgs e)
        {
            Waiting();
            HoTro.frmNgayChotHoTro frm = new HoTro.frmNgayChotHoTro();
            frm.ShowDialog();
            Waited();
        }

        private void đốiTrừHỗTrợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            MDSolution.MDReport.FRM_Report.BieuHoTroTheCBNV frm = new MDReport.FRM_Report.BieuHoTroTheCBNV();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
            Waited();
        }

        private void hợpĐồngMuaTạiBànCânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHopDongMuaTaiBanCan frm = new frmHopDongMuaTaiBanCan();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            Waited();
        }

        private void toooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDSolution.MDForms.ThanhToan2016.TongHopThanhToan frm = new MDSolution.MDForms.ThanhToan2016.TongHopThanhToan();
            frm.ShowDialog();
            Waited();
        }

        private void quảnLýỨngTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting();
            MDForms.UngTien.frmQuanLyUngTien frm = new MDForms.UngTien.frmQuanLyUngTien();
            frm.MdiParent = this;
            frm.Show();
            Waited();
        }

        private void tieeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
    }
}