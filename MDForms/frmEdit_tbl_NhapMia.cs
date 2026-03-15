using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution
{
    public partial class frmEdit_tbl_NhapMia : Form
    {
        public string SoPhieu;
        public string ChuHD;
        public string SoXe;
        public string ID;
        public string HopDongID;
        public int OK=0;
        public frmEdit_tbl_NhapMia()
        {
            InitializeComponent();
        }

        private void frmEdit_tbl_NhapMia_Load(object sender, EventArgs e)
        {
            if (ID != null)
            {
                clsNhapMia objNhapMia = new clsNhapMia(long.Parse(ID));
                objNhapMia.Load(null, null);

                txtTongTL.Text = objNhapMia.TongTrongLuong.ToString();
                txtTLXe.Text = objNhapMia.TrongLuongXe.ToString();
                //txtLoaiGiong.Text = objNhapMia.TyLeTapVat.ToString();
                txtDonGia.Text = objNhapMia.DonGiaMia.ToString();
                txtSoXe.Text = objNhapMia.Soxe;
                txtSoBanDieuTra.Text = objNhapMia.SoBanDieuTra;                
                txtTiLeTapVat.Text = objNhapMia.TyLeTapVat.ToString();
                txtTiLeCanGhep.Text = Convert.ToString(objNhapMia.tylecanghep);
                txtPhatCHD.Text = objNhapMia.PhatHD.ToString("###,###,###");
                txtLyDo.Text = objNhapMia.LyDoPhatHD;

                string SQL = "Select Ten from tbl_GiongMia Where ID =" + objNhapMia.GiongMiaID.ToString();
                txtLoaiGiong.Text = DBModule.ExecuteQueryForOneResult(SQL, null, null);

                if (objNhapMia.tylecanghep == 1)
                {
                    txtTiLeCanGhep.Enabled = false;
                }
                
                lbMaCan.Text = "Mã cân: " + objNhapMia.MaCan;
                lbSoPhieu.Text = "Số phiếu: " + objNhapMia.SoPhieuNhap.ToString();

                clsHopDong objHD = new clsHopDong(objNhapMia.HopDongID);
                objHD.Load(null, null);
                HopDongID = objNhapMia.HopDongID.ToString();
                lbTenChuHD.Text = "Tên chủ HĐ: " + objHD.HoTen.ToString();
                txtMaHD.Text = objHD.MaHopDong;
                //lbMaHD.Text = "Mã HĐ: " + objHD.MaHopDong.ToString();
                //LD.MD2008.clsXeVanChuyen objXe = new clsXeVanChuyen(objNhapMia.XeID);
                //objXe.Load(null, null);
                //lbSoXe.Text = "Số xe: " + objNhapMia.Soxe;
            }

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Check_MaHD(string IDHD_truyen, string MaChuHD_Nhap)
        {
            clsHopDong objHD = new clsHopDong();
            objHD.Load(MaChuHD_Nhap, null, null);
            if (objHD.ID > 0)
            {                
                if (objHD.ID.ToString() == IDHD_truyen)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        private decimal LamTronLen10(decimal TrongLuong)
        {
            TrongLuong = Math.Round(TrongLuong);
            // phan lam tron len 10kg
            int sodu = Convert.ToInt16(TrongLuong % 10);
            decimal KQ;
            if (sodu != 0)
            {
                KQ = Convert.ToInt16(Math.Round(TrongLuong / 10));
                KQ = (KQ) * 10;                
            }
            else
            {
                KQ = Convert.ToInt16(TrongLuong);
            }
            return KQ;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            try
            {
                //if (long.Parse(txtTongTL.Text) > long.Parse(txtTLXe.Text))
                //{
                clsNhapMia objNhapMia = new clsNhapMia(long.Parse(ID));
                objNhapMia.Load(null, null);

                objNhapMia.HopDongID = long.Parse(HopDongID);
                objNhapMia.SoBanDieuTra = txtSoBanDieuTra.Text;
                objNhapMia.Soxe = txtSoXe.Text;
                objNhapMia.TyLeTapVat = decimal.Parse(txtTiLeTapVat.Text);
                objNhapMia.tylecanghep = decimal.Parse(txtTiLeCanGhep.Text);

                objNhapMia.TrongLuongTapVat = (objNhapMia.TongTrongLuong - objNhapMia.TrongLuongXe) * objNhapMia.tylecanghep / 100 * objNhapMia.TyLeTapVat / 100;
                objNhapMia.TrongLuongTapVat = LamTronLen10(objNhapMia.TrongLuongTapVat);
                objNhapMia.PhatHD = decimal.Parse(XuLyChuoiTien(txtPhatCHD.Text));
                objNhapMia.LyDoPhatHD = txtLyDo.Text;
                    //objNhapMia.TongTrongLuong = long.Parse(txtTongTL.Text);
                    //objNhapMia.TrongLuongXe = long.Parse(txtTLXe.Text);
                    //objNhapMia.TyLeTapVat = double.Parse(txtTiLeTV.Text);
                    //objNhapMia.DonGiaMia = double.Parse(txtDonGia.Text);
                    //objNhapMia.TrongLuongTapVat=(objNhapMia.TongTrongLuong-objNhapMia.TrongLuongXe)*objNhapMia.TyLeTapVat/100;
                    //objNhapMia.TienMia=(objNhapMia.TongTrongLuong-objNhapMia.TrongLuongXe-objNhapMia.TrongLuongTapVat)*objNhapMia.DonGiaMia;
                    //objNhapMia.KhoID = MDSolutionApp.User.ID;//lưu vết
                objNhapMia.Save(null, null);
                OK = 1;
                this.Close();
                //}
                //else
                //{
                //    MessageBox.Show("Trọng lượng xe lớn hơn tổng trọng lượng!", "Thông báo");
                //    SendKeys.Send("{Tab}");
                //}
            }
            catch
            {
                MessageBox.Show("Có lỗi trong khi lưu.Hãy kiểm tra lại dữ liệu!", "Thông báo");
                txtMaHD.Focus();
            }
        }

        private string XuLyChuoiTien(string TienFomat)
        {
            string[] str = TienFomat.Split(',');
            string strKQ = "";
            foreach (string s in str)
            {
                strKQ += s;
            }
            if (strKQ != "")
                return strKQ;
            else
                return "0";
        }

               

        //private void txtTongTL_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == '\r')
        //    {
        //        SendKeys.Send("{Tab}");
        //    }
        //}

        //private void txtTLXe_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == '\r')
        //    {
        //        SendKeys.Send("{Tab}");
        //    }
        //}

        //private void txtTiLeTV_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == '\r')
        //    {
        //        SendKeys.Send("{Tab}");
        //    }

        //}
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;
            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Enter:
                        try
                        {
                            SendKeys.Send("{TAB}");
                        }
                        catch { }
                        break;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtMaHD_Enter(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.SkyBlue;
        }

        private void txtMaHD_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;


            if(txtMaHD.Text != "" && txtSoBanDieuTra.Text !="")
            {
                string strSQL = "Select HopDongID From tbl_ThuaRuong Where SoBanDieuTra =N'" + txtSoBanDieuTra.Text + "'";
                string IDHD_Truyen = DBModule.ExecuteQueryForOneResult(strSQL,null,null);
                //clsHopDong objHopDong = new clsHopDong();
                //objHopDong.Load(txtMaHD.Text, null, null);
                if (Check_MaHD(IDHD_Truyen, txtMaHD.Text))
                {
                    clsHopDong objHD = new clsHopDong(long.Parse(IDHD_Truyen));
                    objHD.Load(null, null);
                    lbTenChuHD.Text = "Tên Chủ HĐ: " + objHD.HoTen;
                    HopDongID = IDHD_Truyen;
                }
                else
                {
                    MessageBox.Show("Mã hợp đồng và số bản điều tra không khớp!/nHãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //txtMaHD.Focus();
                    txtSoBanDieuTra.Focus();
                }
            }
        }

        private void txtTiLeTapVat_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            if (txtTiLeTapVat.Text != "")
            {
                try
                {
                    double a = double.Parse(txtTiLeTapVat.Text);
                    if (a < 0 || a > 100)
                    {
                        MessageBox.Show("tỉ lệ tạp vật không đúng!\nHãy nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTiLeTapVat.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("tỉ lệ tạp vật phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTiLeTapVat.Focus();
                }
            }

        }

        private void txtTiLeCanGhep_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            if (txtTiLeCanGhep.Text != "")
            {
                try
                {
                    double a = double.Parse(txtTiLeCanGhep.Text);
                    if (a < 0 || a > 100)
                    {
                        MessageBox.Show("tỉ lệ cân ghép không đúng!\nHãy nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTiLeCanGhep.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("tỉ lệ cân ghép phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTiLeCanGhep.Focus();
                }
            }
        }

        private void txtMaHD_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtSoXe_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }

        private void txtPhatCHD_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;

            try
            {
                if (txtPhatCHD.Text.Trim() != "")
                {
                    long a = long.Parse(XuLyChuoiTien(txtPhatCHD.Text));
                    txtPhatCHD.Text = a.ToString("###,###,###");
                }
            }
            catch
            {
                MessageBox.Show("Số tiền nhập vào phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhatCHD.Focus();
            }
        }

        private void txtLyDo_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }
        
    }
}