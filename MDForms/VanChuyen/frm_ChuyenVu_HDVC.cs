using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms.VanChuyen
{
    public partial class frm_ChuyenVu_HDVC : Form
    {
        private long _HDVCID = -1;
        private long _XEID = -1;
        private long _VUTRONGID = -1;
        public string _TENVU = "";
        public long OK = -1;
        clsHopDongVanChuyen oHDVC = new clsHopDongVanChuyen();
        clsXeVanChuyen oXe = new clsXeVanChuyen();
        public frm_ChuyenVu_HDVC()
        {
            InitializeComponent();
        }
        public frm_ChuyenVu_HDVC(long HopDongVanChuyenID,long XeVanChuyenID)
        {
            InitializeComponent();
            _HDVCID = HopDongVanChuyenID;
            _XEID = XeVanChuyenID;
            LoadVuTrong();
            oHDVC.ID=_HDVCID;
            oHDVC.Load(null, null);
            if (oHDVC.DaChuyenVu > 0)
            {
                MessageBox.Show("Hợp đồng " + oHDVC.MaHopDong + " đã được chuyến sang vụ mới!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            lblMaHD.Text = oHDVC.MaHopDong;
            lbl_TenChuHD.Text = oHDVC.TenChuHopDong;
            dtNgayKyHD.Value = oHDVC.NgayHopDong;

            oXe.ID = _XEID;
            oXe.Load(null, null);
            lblSoXe.Text = oXe.SoXe;
        }
      
      

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool VerifyData()
        {
            if (cboVuTrong.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn vụ đích!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                cboVuTrong.Focus();
                return false;
            }
          
            return true;
        }
        private void cmdLuu_Click(object sender, EventArgs e)
        {           
            if (VerifyData())
            {
                if (MessageBox.Show("Bạn chắc chắn chuyển HĐVC " + lblMaHD.Text + "\ntừ vụ " + MDSolutionApp.VuTrongTen + " sang vụ mới " + cboVuTrong.Text, "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                clsHopDongVanChuyen oHDVC_Dich = new clsHopDongVanChuyen();
                oHDVC_Dich.VutrongID = _VUTRONGID;
                oHDVC_Dich.MaHopDong = oHDVC.MaHopDong;
                oHDVC_Dich.NgayHopDong = oHDVC.NgayHopDong;
                oHDVC_Dich.TenChuHopDong = oHDVC.TenChuHopDong;
                oHDVC_Dich.MaSoThue = oHDVC.MaSoThue;
                oHDVC_Dich.SoTKNganHang = oHDVC.SoTKNganHang;
                oHDVC_Dich.DienThoai = oHDVC.DienThoai;
                oHDVC_Dich.CMT = oHDVC.CMT;
                oHDVC_Dich.NgayCapCMT = oHDVC.NgayCapCMT;
                oHDVC_Dich.NoiCap = oHDVC.NoiCap;
                oHDVC_Dich.NguyenQuan = oHDVC.NguyenQuan;
                oHDVC_Dich.DiaChi = oHDVC.DiaChi;
                oHDVC_Dich.DaChuyenVu = 0;
                oHDVC_Dich.Save(null, null);

                if (chk_ChuyenXe.Checked)
                {
                    clsXeVanChuyen oXe_Dich = new clsXeVanChuyen();
                    oXe_Dich.VuTrongID = _VUTRONGID;
                    oXe_Dich.TrongTai = oXe.TrongTai;
                    oXe_Dich.TenLaiXe = oXe.TenLaiXe;
                    oXe_Dich.SoXe = oXe.SoXe;
                    oXe_Dich.MaSoXe = oXe.MaSoXe;
                    oXe_Dich.LoaiXe = oXe.LoaiXe;
                    oXe_Dich.HopDongVanChuyenID = oHDVC_Dich.ID;
                    oXe_Dich.ChuyenVu(null, null);
                }
                oHDVC.DaChuyenVu = 1;
                oHDVC.Save(null, null);
                OK = 1;
                this.Close();
            }
        }

      
        private void LoadVuTrong()
        {
            string sql = "Select Top 1 * From tbl_VuTrong Where ID>"+MDSolutionApp.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboVuTrong.DataSource = ds.Tables[0];
                cboVuTrong.ValueMember = "ID";
                cboVuTrong.DisplayMember = "Ten";
            }
            else
            {
                cboVuTrong.DataSource = null;
                cboVuTrong.Text = "";
            }

        }
      
       
        private void cboVuTrong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _VUTRONGID = long.Parse(cboVuTrong.SelectedValue.ToString());
                _TENVU = cboVuTrong.Text;
            }
            catch
            {
                _VUTRONGID = -1;
                _TENVU = "";
            }
          
        }

        private void frm_ChuyenVu_HDVC_Load(object sender, EventArgs e)
        {
            cboVuTrong.SelectedIndex = 0;
        }

    
     
    }
}