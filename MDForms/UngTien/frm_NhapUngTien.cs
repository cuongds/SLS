using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDSolution;
using MDSolution.MDDialoge;

namespace MDSolution.MDForms.UngTien
{
    public partial class frm_NhapUngTien : Form
    {
        public long OK = 0;
        public long _HopDongID = -1;
        private decimal Sotien = -1;
        public long Status = -1;
        public long IDUngTien = -1;
        public frm_NhapUngTien()
        {
            InitializeComponent();

        }
        public frm_NhapUngTien(long HopDong_ID, bool Add = true)//Nhập mới
        {
            InitializeComponent();
            clsHopDong objHD = new clsHopDong(HopDong_ID);
            objHD.Load(null, null);
            lblMaHopDong.Text = objHD.MaHopDong.ToString();
            lblHoTen.Text = objHD.HoTen.ToString();
            lblCMT.Text = objHD.SoCMT.ToString();
            lblNguoiKeThua.Text = objHD.NguoiThuaKe1Ten.ToString();

        }

        public frm_NhapUngTien(long UngTienID, long status = 1)//Sửa
        {
            Status = status;
            IDUngTien = UngTienID;
            InitializeComponent();
            clsKeHoachUngTienMat objKHUT = new clsKeHoachUngTienMat(UngTienID);
            objKHUT.LoadStatus(UngTienID, status, MDSolutionApp.VuTrongID, DateTime.MinValue, DateTime.MinValue, null, null);
            txt_TenDot.Text = objKHUT.TenDot.ToString();
            dtNgayUng.Text = objKHUT.NgayUng.ToShortDateString();
            nSoTien.Value = objKHUT.Sotien;
            clsHopDong objHD = new clsHopDong(objKHUT.HopDongID);
            objHD.Load(null, null);
            _HopDongID = objHD.ID;
            lblMaHopDong.Text = objHD.MaHopDong.ToString();
            lblHoTen.Text = objHD.HoTen.ToString();
            lblCMT.Text = objHD.SoCMT.ToString();
            lblNguoiKeThua.Text = objHD.NguoiThuaKe1Ten.ToString();
            btnSave.Text = "Lưu sửa";
        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Valid_Form())
            {
                if (Status == -1)//Nếu là nhập mới
                {
                    try
                    {
                        clsKeHoachUngTienMat objKHUT = new clsKeHoachUngTienMat();
                        objKHUT.NgayUng = dtNgayUng.Value;
                        objKHUT.DateAdd = DateTime.Now;
                        objKHUT.VuTrongID = MDSolutionApp.VuTrongID;
                        objKHUT.Sotien = nSoTien.Value;
                        objKHUT.TenDot = txt_TenDot.Text.Trim();
                        objKHUT.HopDongID = _HopDongID;
                        objKHUT.CreatedByUserID = MDSolutionApp.User.ID;
                        objKHUT.Status = 1;
                        objKHUT.Save(null, null);
                        MessageBox.Show("Bạn đã thêm mới thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OK = 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi thêm mới!\n" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else
                {
                    try
                    {
                        clsKeHoachUngTienMat objKHUTM = new clsKeHoachUngTienMat(IDUngTien);
                        objKHUTM.LoadStatus(IDUngTien,1,MDSolutionApp.VuTrongID, DateTime.MinValue, DateTime.MinValue, null, null);
                        objKHUTM.NgayUng = dtNgayUng.Value;                        
                        objKHUTM.Sotien = nSoTien.Value;
                        objKHUTM.TenDot = txt_TenDot.Text.Trim();
                        objKHUTM.VuTrongID = MDSolutionApp.VuTrongID;
                        objKHUTM.Status = 1;
                        objKHUTM.ModifyByUserID = MDSolutionApp.User.ID;
                        objKHUTM.DateModify = DateTime.Now;
                        objKHUTM.Save(null, null);
                        MessageBox.Show("Bạn đã sửa thông tin mục hỗ trợ  thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OK = 1;
                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi khi sửa!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                this.Close();
            }

        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
        private bool Valid_Form()
        {
            return true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txt_SoTien_Leave(object sender, EventArgs e)
        {
            if (!Decimal.TryParse(nSoTien.Text.Replace(",", ""), out Sotien)) ;
            Sotien = (long)(Sotien);
            nSoTien.Text = Sotien.ToString("### ### ###");
        }
    }
}
