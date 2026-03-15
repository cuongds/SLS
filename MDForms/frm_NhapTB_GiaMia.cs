using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MDSolution.MDForms
{
    public partial class frm_NhapTB_GiaMia : Form
    {
        public int OK=0;
        public long ID_TB = -1;
        public long MaxID=-1;
        public frm_NhapTB_GiaMia()
        {
            InitializeComponent();
            dtNgay.Value = DateTime.Now;
        }

        public frm_NhapTB_GiaMia(long ID)
        {
            InitializeComponent();
            ID_TB = ID;
            cls_GiaMia_ThongBao oGM = new cls_GiaMia_ThongBao(ID_TB);
            oGM.Load(null, null);
            txtTenThongBao.Text = oGM.TenThongBao;
            dtNgay.Value = oGM.NgayGioApDung;
            nGiaMiaLoai1.Value = oGM.DonGia;
            nGiaMiaRep.Value = oGM.DonGiaMiaRep;
            nDonGiaHopDong.Value = oGM.DonGiaHopDong;
            lblTitle.Text = "SỬA THÔNG BÁO GIÁ";
            grTT.Text = "Sửa dữ liệu";
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            OK = 1;
            if (ID_TB<0)
            {
                try
                {
                    cls_GiaMia_ThongBao oGM = new cls_GiaMia_ThongBao();
                    oGM.TenThongBao = txtTenThongBao.Text;
                    oGM.NgayGioApDung = dtNgay.Value;
                    oGM.DonGia = nGiaMiaLoai1.Value;
                    oGM.DonGiaMiaRep = nGiaMiaRep.Value;
                    oGM.DonGiaHopDong = nDonGiaHopDong.Value;
                    oGM.Save(null, null);
                    MaxID = oGM.FindMaxID();
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
                this.Close();
            }
            else
            {
            try
            {
                cls_GiaMia_ThongBao oGM = new cls_GiaMia_ThongBao(ID_TB);
                oGM.Load(null, null);
                oGM.TenThongBao = txtTenThongBao.Text;
                oGM.NgayGioApDung = dtNgay.Value;
                oGM.DonGia = nGiaMiaLoai1.Value;
                oGM.DonGiaMiaRep = nGiaMiaRep.Value;
                oGM.DonGiaHopDong = nDonGiaHopDong.Value;
                oGM.Save(null, null);
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
            }
          
        }

      
    }
}
