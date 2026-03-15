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

namespace MDSolution
{
    public partial class frm_NhapHoTroVC : Form
    {
        public long OK = 0;
        public long _HopDongID = -1;
        private decimal Sotien = -1;
        public long HopDongVCID = -1;
        public long XeVCID = -1;
        private long HoanUngID = -1;
        public frm_NhapHoTroVC()
        {
            InitializeComponent();

        }       
        private string Gen_SCT()
        {
            string stt = DBModule.ExecuteQueryForOneResult("Get_MaPhieu 'tbl_HoTroVanChuyen', " + MDSolutionApp.VuTrongID.ToString(), null, null);
            DateTime dt = (DateTime)DBModule.ExecuteQuery("Select NgayBatDau from tbl_VuTrong where ID=" + MDSolutionApp.VuTrongID.ToString(), null, null).Tables[0].Rows[0][0];
            string strMaPhieu = "HT" + dt.Year.ToString("###") + ".";
            strMaPhieu = strMaPhieu + stt.PadLeft(6, '0');
            return strMaPhieu;
        }

       

        public frm_NhapHoTroVC(long HopDongVanChuyen_ID, bool Add = true)//Nhập mới
        {
            InitializeComponent();
            clsHopDongVanChuyen objHDVC = new clsHopDongVanChuyen(HopDongVanChuyen_ID);
            objHDVC.Load(null,null);
            lblMaHopDong.Text = objHDVC.MaHopDong.ToString();
            lblHoTen.Text = objHDVC.TenChuHopDong;
            lblDienThoai.Text = objHDVC.DienThoai.ToString();
            lblDiaChi.Text = objHDVC.DiaChi;
            HopDongVCID = objHDVC.ID;
            clsXeVanChuyen objXeVC = new clsXeVanChuyen();
            objXeVC.Load(HopDongVanChuyen_ID,null, null);            
            lbl_SoXe.Text = objXeVC.SoXe;
            XeVCID = objXeVC.ID;
        }

        public frm_NhapHoTroVC(long HopDongVanChuyen_ID)//Sửa
        {
            InitializeComponent();
            clsHopDongVanChuyen objHDVC = new clsHopDongVanChuyen(HopDongVanChuyen_ID);
            objHDVC.Load(null, null);
            lblMaHopDong.Text = objHDVC.MaHopDong.ToString();
            lblHoTen.Text = objHDVC.TenChuHopDong;
            lblDienThoai.Text = objHDVC.DienThoai.ToString();
            lblDiaChi.Text = objHDVC.DiaChi;
            clsXeVanChuyen objXeVC = new clsXeVanChuyen();
            objXeVC.Load(HopDongVanChuyen_ID,null, null);            
            lbl_SoXe.Text = objXeVC.SoXe;
            btnSave.Text = "Lưu sửa";
        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Valid_Form())
            {
                if (HoanUngID < 0)//Nếu là nhập mới
                {
                    try
                    {

                        clsHoTroVanChuyen objHUVC = new clsHoTroVanChuyen();
                        objHUVC.NgayNhap = dtNgayHoanUng.Value;
                        objHUVC.VuTrongID = MDSolutionApp.VuTrongID;
                        objHUVC.SoTien = nSoTien.Value;
                        objHUVC.SoChungTu = txt_SoChungTu.Text.Trim();
                        objHUVC.HopDongVanChuyenID = HopDongVCID;
                        objHUVC.XeID = XeVCID;
                        objHUVC.Save(null, null);                  
                        MessageBox.Show("Bạn đã thêm mới mục hỗ trợ  thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OK = 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi thêm mới mục hỗ trợ  !\n" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else
                {
                    try
                    {
                        clsHoTroVanChuyen objHUVC = new clsHoTroVanChuyen();
                        objHUVC.NgayNhap = dtNgayHoanUng.Value;
                        objHUVC.VuTrongID = MDSolutionApp.VuTrongID;
                        objHUVC.SoTien = nSoTien.Value;
                        objHUVC.SoChungTu = txt_SoChungTu.Text.Trim();
                        objHUVC.HopDongVanChuyenID = HopDongVCID;
                        objHUVC.XeID = XeVCID;
                        objHUVC.Save(null, null);   
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
        private long CheckExist(string MaTR)
        {
            long exist = 0;
            try
            {
                exist = long.Parse(DBModule.ExecuteQueryForOneResult("Select Count(MaThuaRuong) From tbl_ThuaRuong Where MaThuaRuong=N'" + MaTR + "' And VuTrongID=" + MDSolutionApp.VuTrongID.ToString(), null, null).ToString());
            }
            catch
            {
                exist = 0;
            }
            return exist;

        }
        private bool Valid_Form()
        {            
            return true;
        }


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtCMNDChuDat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frm_NhapHoTroVC_Load(object sender, EventArgs e)
        {
            if (MDSolutionApp.User.ID != 1)
            {
                //clsComFunctions.checkControlsPermission(this, this.Name.ToString());              
            }
        }

       

        
        public void GetHopDongVanChuyen_ID(string value)
        {

//            DauTuID = value;
        }
      

        private void txt_SoTien_Leave(object sender, EventArgs e)
        {


            if (!Decimal.TryParse(nSoTien.Text.Replace(",", ""), out Sotien));           
            Sotien = (long)(Sotien);
            nSoTien.Text = Sotien.ToString("### ### ###");

            // if (!Decimal.TryParse(lbl_Tiendautu.Text.Replace(",", ""), out SoTienDautuTru));
            //{
            //    lbl_SoDu.Text = (SoTienDautuTru - Sotien).ToString("### ### ###");
            //}
            //if (checed_HTK.Checked == false)
            //{
            //    SoTienKhauTru = SoTienDautu - Sotien;
            //    lbl_SoDu.Text = SoTienKhauTru.ToString("### ### ###");
            //}
            //else
            //{

            //    lbl_SoDu.Text = SoTienDautu.ToString("### ### ###");
            //}

        }
    }
}
