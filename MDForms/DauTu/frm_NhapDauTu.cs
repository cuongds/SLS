using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDSolution
{
    public partial class frm_NhapDauTu : Form
    {
        public long OK=0;
        public long _HopDongID = -1;
        public long _IDDauTu = -1;
        public long _LoaiHinhID = -1;

        public frm_NhapDauTu()
        {
            InitializeComponent();
            
        }
        private void Load_Cb_LoaiHinhDauTu()
        {
            string sql = "Select ID,Ten from tbl_LoaiHinhDauTu";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboLoaiHinhDauTu.DataSource = ds.Tables[0];
                cboLoaiHinhDauTu.ValueMember = "ID";
                cboLoaiHinhDauTu.DisplayMember = "Ten";
            }
            else
            {
                cboLoaiHinhDauTu.DataSource = null;
            }
        }
        private void Load_Cb_DanhMucDauTu(long LoaiHinhID)
        {
            string sql = "Select ID,Ten from tbl_DanhMucDauTu Where IsActive=1 AND LoaiHinhDauTuID=" + LoaiHinhID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboDanhMucDauTu.DataSource = ds.Tables[0];
                cboDanhMucDauTu.ValueMember = "ID";
                cboDanhMucDauTu.DisplayMember = "Ten";
            }
            else
            {
                cboDanhMucDauTu.DataSource = null;
            }
        }
        private void Load_Cb_DanhMucDauTu()
        {
            string sql = "Select ID,Ten from tbl_DanhMucDauTu Where IsActive=1";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboDanhMucDauTu.DataSource = ds.Tables[0];
                cboDanhMucDauTu.ValueMember = "ID";
                cboDanhMucDauTu.DisplayMember = "Ten";
            }
            else
            {
                cboDanhMucDauTu.DataSource = null;
            }
        }
        public frm_NhapDauTu(long HopDong_ID,bool Add=true)//Nhập mới
        {
            InitializeComponent();
            _HopDongID = HopDong_ID;
            Load_Cb_LoaiHinhDauTu();
            clsHopDong objHD = new clsHopDong(_HopDongID);
            objHD.Load(null, null);
            lblMaHopDong.Text = objHD.MaHopDong;
            lblHoTen.Text = objHD.HoTen;
        }
        public frm_NhapDauTu(long DauTuID)//Sửa
        {
            InitializeComponent();
            lblTitle.Text = "SỬA THÔNG TIN CHI TIẾT ĐẦU TƯ";
            btnSave.Text = "Lưu sửa";
            _IDDauTu = DauTuID;
            clsDauTu objDT = new clsDauTu(_IDDauTu);
            objDT.Load(null, null);
            _HopDongID = objDT.HopDongID;
            _LoaiHinhID = objDT.LoaiHinhDauTuID;
            Load_Cb_LoaiHinhDauTu();
            cboLoaiHinhDauTu.SelectedValue = objDT.LoaiHinhDauTuID;//Loại hình đầu tư
            Load_Cb_DanhMucDauTu();
            cboDanhMucDauTu.SelectedValue = objDT.DanhMucDauTuID;//Danh mục đầu tư
            clsHopDong objHD = new clsHopDong(_HopDongID);
            objHD.Load(null, null);
            lblMaHopDong.Text = objHD.MaHopDong;//Mã hợp đồng
            lblHoTen.Text = objHD.HoTen;//Họ tên
            txtGhiChu.Text = objDT.GhiChu;//Ghi chú
            txtGhiChuSua.Text = objDT.NoteModify;//Ghi chú sửa
            nLaiSuat.Value = objDT.LaiSuat;//Lãi suất
            nDonGia.Value = objDT.DonGia;//Load đơn giá
            nSoLuong.Value = objDT.SoLuong;//Load số lượng
            nSoTien.Value = objDT.SoTien;//Số tiền
            dtNgayDauTu.Value = objDT.NgayDauTu;//Ngày đầu tư
            nDotDT.Value = objDT.DotDauTu;//Đợt đầu tư
            lblSoCT.Text = objDT.SoChungTu;//Số chứng từ
        }
        private string Gen_SCT()
        {
            string stt = DBModule.ExecuteQueryForOneResult("Get_MaPhieu 'tbl_DauTu', " + MDSolutionApp.VuTrongID.ToString(),null,null);
            DateTime dt = (DateTime)DBModule.ExecuteQuery("Select NgayBatDau from tbl_VuTrong where ID=" + MDSolutionApp.VuTrongID.ToString(), null, null).Tables[0].Rows[0][0];
            string strMaPhieu = "DT" + dt.Year.ToString("###") + ".";
            strMaPhieu = strMaPhieu + stt.PadLeft(6, '0');
            return strMaPhieu;
        }
      
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Valid_Form())
            {
                if (_IDDauTu < 0)//Nếu là nhập mới
                {
                    try
                    {
                        lblSoCT.Text = Gen_SCT();
                        clsDauTu oDT = new clsDauTu();
                        oDT.HopDongID = _HopDongID;
                        oDT.LoaiHinhDauTuID = long.Parse(cboLoaiHinhDauTu.SelectedValue.ToString());
                        oDT.DanhMucDauTuID = long.Parse(cboDanhMucDauTu.SelectedValue.ToString());
                        oDT.LaiSuat = nLaiSuat.Value;
                        oDT.DonGia = nDonGia.Value;
                        oDT.SoLuong = nSoLuong.Value;
                        oDT.SoTien = nSoTien.Value;
                        oDT.GhiChu = txtGhiChu.Text;
                        oDT.DotDauTu = nDotDT.Value;
                        oDT.NgayDauTu = dtNgayDauTu.Value;
                        oDT.SoChungTu = lblSoCT.Text;
                        oDT.NoteModify = txtGhiChuSua.Text;
                        oDT.Save(null, null);
                        _IDDauTu = oDT.ID;
                        MessageBox.Show("Bạn đã thêm mới mục đầu tư thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OK = 1;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi thêm mới mục đầu tư!\n"+ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else
                {
                    try
                    {
                        clsDauTu oDT = new clsDauTu(_IDDauTu);
                        oDT.Load(null, null);
                        oDT.LoaiHinhDauTuID = long.Parse(cboLoaiHinhDauTu.SelectedValue.ToString());
                        oDT.DanhMucDauTuID = long.Parse(cboDanhMucDauTu.SelectedValue.ToString());
                        oDT.SoChungTu = lblSoCT.Text;
                        oDT.LaiSuat = nLaiSuat.Value;
                        oDT.DonGia = nDonGia.Value;
                        oDT.SoLuong = nSoLuong.Value;
                        oDT.SoTien = nSoTien.Value;
                        oDT.GhiChu = txtGhiChu.Text;
                        oDT.NoteModify = txtGhiChuSua.Text;
                        oDT.DotDauTu = nDotDT.Value;
                        oDT.NgayDauTu = dtNgayDauTu.Value;                        
                        oDT.SoTienTruHoTro_Goc = nSoTien.Value;
                        oDT.Save(null, null);
                        MessageBox.Show("Bạn đã sửa thông tin mục đầu tư thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
         
            if (cboLoaiHinhDauTu.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn loại loại hình đầu tư!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboLoaiHinhDauTu.Focus();
                return false;
            }
            if (cboDanhMucDauTu.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn danh mục đầu tư!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboDanhMucDauTu.Focus();
                return false;
            }
            //if (nSoTien.Value <= 0)
            //{
            //    MessageBox.Show("Số tiền nhập chưa đúng!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    nSoTien.Focus();
            //    return false;
            //}
           
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

     
     

        private void nDT_MouseClick(object sender, MouseEventArgs e)
        {
            nLaiSuat.Select();
            nLaiSuat.Select(0, nLaiSuat.Value.ToString().Length + nLaiSuat.DecimalPlaces + 2);
        }

        private void nDT_Enter(object sender, EventArgs e)
        {
            nLaiSuat.Select();
            nLaiSuat.Select(0, nLaiSuat.Value.ToString().Length + nLaiSuat.DecimalPlaces + 2);
        }

        private void nSanLuong_Enter(object sender, EventArgs e)
        {
            nSoLuong.Select();
            nSoLuong.Select(0, nSoLuong.Value.ToString().Length);
        }

      
        private void frm_NhapDauTu_Load(object sender, EventArgs e)
        {
         if (MDSolutionApp.User.ID != 1)
            {
                //clsComFunctions.checkControlsPermission(this, this.Name.ToString());              
            }
        }

        private void nSoLuong_ValueChanged(object sender, EventArgs e)
        {
            if (nSoLuong.Value > nSoLuong.Maximum)
            {
                nSoLuong.Value = nSoLuong.Maximum;
            }
            nSoTien.Value = nSoLuong.Value * nDonGia.Value;
        }

        private void nDonGia_ValueChanged(object sender, EventArgs e)
        {
            if (nDonGia.Value > nDonGia.Maximum)
            {
                nDonGia.Value = nDonGia.Maximum;
            }
            nSoTien.Value = nSoLuong.Value * nDonGia.Value;
        }

        private void nSoTien_ValueChanged(object sender, EventArgs e)
        {
            if (nSoTien.Value > nSoTien.Maximum)
            {
                nSoTien.Value = nSoTien.Maximum;
            }
        }

        private void nLaiSuat_ValueChanged(object sender, EventArgs e)
        {
            if (nLaiSuat.Value > nLaiSuat.Maximum)
            {
                nLaiSuat.Value = nLaiSuat.Maximum;
            }
        }

        private void cboLoaiHinhDauTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            long LoaiHinh = -1;
            try
            {
                LoaiHinh = long.Parse(cboLoaiHinhDauTu.SelectedValue.ToString());
            }
            catch { }
            if (LoaiHinh > 0)
            {
                Load_Cb_DanhMucDauTu(LoaiHinh);
            }
        }

       
      
    }
}
