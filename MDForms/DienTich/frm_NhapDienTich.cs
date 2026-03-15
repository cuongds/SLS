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
    public partial class frm_NhapDienTich : Form
    {
        //static frm_NhapDienTich _frm_NhapDienTich;
        public long OK=0;
        public long _HopDongID = -1;
        public long _IDThuaRuong = -1;
        public long _ThonID = -1;
        public long _CanBoNongVuID = -1;
        public string MTR = "";
        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        //static public frm_NhapDienTich OneInstanceFrm
        //{
        //    get
        //    {
        //        if (null == _frm_NhapDienTich || _frm_NhapDienTich.IsDisposed)
        //        {
        //            _frm_NhapDienTich = new frm_NhapDienTich();
        //        }

        //        return _frm_NhapDienTich;
        //    }
        //}
        public frm_NhapDienTich()
        {
            InitializeComponent();
            
        }
        private void Load_Cb_Thon(long ThonID)
        {
            string sql = "Select ID,Ten from tbl_Thon Where ID="+ThonID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboThon.DataSource = ds.Tables[0];
                cboThon.ValueMember = "ID";
                cboThon.DisplayMember = "Ten";
            }
            else
            {
                cboThon.DataSource = null;
            }
        }
        private void Load_Cb_BTK(long ThonID)
        {
            string sql = "Select ID,TenBai from tbl_BaiTapKet Where ThonID=" + ThonID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboBaiTapKet.DataSource = ds.Tables[0];
                cboBaiTapKet.ValueMember = "ID";
                cboBaiTapKet.DisplayMember = "TenBai";
            }
            else
            {
                cboBaiTapKet.DataSource = null;
            }
        }
        public frm_NhapDienTich(long Thon_ID,long HopDong_ID)//Nhập mới
        {
            InitializeComponent();
            _ThonID = Thon_ID;
            _HopDongID = HopDong_ID;
            Load_Cb_Thon(_ThonID);
            Load_Cb_BTK(_ThonID);
            Load_Cb_Giong(); Load_Cb_KieuTrong(); Load_Cb_MucDichTrong(); Load_Cb_LoaiDat(); Load_Cb_VuTrong();
            clsHopDong objHD = new clsHopDong(_HopDongID);
            objHD.Load(null, null);
            lblMaHopDong.Text = objHD.MaHopDong;
            lblHoTen.Text = objHD.HoTen;
            DataSet ds = clsThon.Get_CBNV(_ThonID, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblCBNV.Text = ds.Tables[0].Rows[0]["Ten"].ToString();
                _CanBoNongVuID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
            }
            else
            {
                lblCBNV.Text = "Chưa có CBNV";
                _CanBoNongVuID = -1;
            }
           
         
         }
        public frm_NhapDienTich(long ThuaRuongID)//Sửa
        {
            InitializeComponent();
            lblTitle.Text = "SỬA THÔNG TIN CHI TIẾT THỬA RUỘNG ";
            btnSave.Text = "Lưu sửa";
            _IDThuaRuong = ThuaRuongID;
            clsThuaRuong objTR = new clsThuaRuong(_IDThuaRuong);
            objTR.Load(null, null);
            _ThonID = objTR.ThonID;
            _HopDongID = objTR.HopDongID;
            Load_Cb_Thon(_ThonID);
            Load_Cb_BTK(_ThonID);
            Load_Cb_Giong();Load_Cb_KieuTrong(); Load_Cb_MucDichTrong(); Load_Cb_LoaiDat(); Load_Cb_VuTrong();
           
            clsHopDong objHD = new clsHopDong(_HopDongID);
            objHD.Load(null, null);
            lblMaHopDong.Text = objHD.MaHopDong;
            lblHoTen.Text = objHD.HoTen;
            DataSet ds = clsThon.Get_CBNV(_ThonID, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblCBNV.Text = ds.Tables[0].Rows[0]["Ten"].ToString();
                _CanBoNongVuID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
            }
            else
            {
                lblCBNV.Text = "Chưa có CBNV";
                _CanBoNongVuID = -1;
            }
            cboGiong.SelectedValue = objTR.GiongMiaID;//Load Giống mía
            cboLoaiDat.SelectedValue = objTR.LoaiDatID;//Load Loại đất
            cboKieuTrong.SelectedValue = objTR.KieuTrongID;//Load Loại mía
            cboMucDich.SelectedValue = objTR.MucDichID;//Load mục đích trồng
            cboVuTrong.SelectedValue = objTR.RaiVuID;//Load Rải vụ/vụ trồng
            cboBaiTapKet.SelectedValue = objTR.BaiTapKetID;//Bãi tập kết
            if (objTR.NgayTrong == DateTime.MinValue)//Load ngày trồng
            {
                dtNgayTrong.IsNullDate = true;
            }
            else
            {
                dtNgayTrong.Value = objTR.NgayTrong;
            }
            //Load_XuDong_DonGia();
            nDT.Value = objTR.DienTich/10000;//Load diện tích
            nNS.Value = objTR.NangSuatDuKien;//Load năng suất dự kiến
            nSanLuong.Value= objTR.SanLuongDuKien;//Load dản lượng dự kiến
           
        }
      
        private void Load_Cb_Giong()
        {

            string sql = "Select ID,Ten from tbl_GiongMia Where (ID>=8 And ID!=27) Order By Ten";
            
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboGiong.DataSource = ds.Tables[0];
                cboGiong.ValueMember = "ID";
                cboGiong.DisplayMember = "Ten";
            }
            else
            {
                cboGiong.DataSource = null;
            }
        }
      
      
        private void Load_Cb_LoaiDat()
        {
            string sql = "Select ID,Ten from tbl_LoaiDat";

            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboLoaiDat.DataSource = ds.Tables[0];
                cboLoaiDat.ValueMember = "ID";
                cboLoaiDat.DisplayMember = "Ten";
            }
            else
            {
                cboLoaiDat.DataSource = null;
            }
        }
        private void Load_Cb_KieuTrong()
        {
            string sql = "Select ID,Ten from tbl_KieuTrong";

            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboKieuTrong.DataSource = ds.Tables[0];
                cboKieuTrong.ValueMember = "ID";
                cboKieuTrong.DisplayMember = "Ten";
            }
            else
            {
                cboKieuTrong.DataSource = null;
            }
        }
        private void Load_Cb_MucDichTrong()
        {
            string sql = "Select ID,MucDichTrong from tbl_MucDichTrong";

            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboMucDich.DataSource = ds.Tables[0];
                cboMucDich.ValueMember = "ID";
                cboMucDich.DisplayMember = "MucDichTrong";
            }
            else
            {
                cboMucDich.DataSource = null;
            }
        }
        private void Load_Cb_VuTrong()
        {
            string sql = "Select ID,Ten from tbl_RaiVu";

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
            }
        }
        private void Load_XuDong_DonGia()
        {
            long BTKID;
            long.TryParse(cboBaiTapKet.SelectedValue.ToString(),out BTKID);
            if (BTKID>0)
            {
                lblXuDong.Text = cboBaiTapKet.Text;
                lblGiaCuoc.Text = clsBaiTapKet.GetGiaVanChuyen(BTKID, null, null).ToString("### ### ##0");
            }
        }
        private void ReSetForm_NhapDienTich()
        {
            //IDThuaRuong = -1;
            //_ThonID = -1;
            //_XuDongID = -1;
            //lblKVDM.Text = "(Chưa chọn xứ đồng cho thửa ruộng)";
            //txtMaThuaRuong.Text = "";
            //txtSoThua_ToBanDo.Text = "";
            //cbNguonGocDat.SelectedIndex = -1;
            //txtToaDo.Text = "";
            //cboGiong.SelectedIndex = -1;
            //cboKieuTrong.SelectedIndex = -1;
            //cboTram.SelectedIndex = -1;
            //cboVuTrong.SelectedIndex=-1;
            //cboMucDich.SelectedIndex = -1;
            //txtChuDat.Text = "";
            //txtCMNDChuDat.Text = "";
            //cboLoaiDat.SelectedIndex = -1;
            //nDoDoc.Value = 0;
            //nDT.Value=0;
            //nNS.Value=0;
            //nSanLuong.Value=0;
            //cbDieuKienCanhTac.SelectedIndex = -1;
        }

     
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Valid_Form())
            {
                if (_IDThuaRuong < 0)//Nếu là nhập mới
                {
                    try
                    {
                        clsThuaRuong oTR = new clsThuaRuong();
                        oTR.HopDongID = _HopDongID;
                        oTR.ThonID = _ThonID;
                        oTR.CanBoNongVuID = _CanBoNongVuID;
                        oTR.XuDong = lblXuDong.Text;
                        oTR.BaiTapKetID = long.Parse(cboBaiTapKet.SelectedValue.ToString());
                        oTR.DienTich = nDT.Value*10000;
                        oTR.NangSuatDuKien = nNS.Value;
                        oTR.SanLuongDuKien = nSanLuong.Value;
                        oTR.VuTrongID = MDSolutionApp.VuTrongID;
                        oTR.RaiVuID = long.Parse(cboVuTrong.SelectedValue.ToString());
                        oTR.MucDichID = long.Parse(cboMucDich.SelectedValue.ToString());
                        oTR.KieuTrongID = long.Parse(cboKieuTrong.SelectedValue.ToString());
                        oTR.LoaiDatID = long.Parse(cboLoaiDat.SelectedValue.ToString());
                        oTR.GiongMiaID = long.Parse(cboGiong.SelectedValue.ToString());
                        if (dtNgayTrong.IsNullDate == true)
                        {
                            oTR.NgayTrong = DateTime.MinValue;
                        }
                        else
                        {
                            oTR.NgayTrong = dtNgayTrong.Value;
                        }
                        oTR.Save(null, null);
                        _IDThuaRuong = oTR.ID;
                        MessageBox.Show("Bạn đã thêm mới thửa ruộng thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OK = 1;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi thêm mới thửa ruộng!\n"+ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else
                {
                    try
                    {
                        clsThuaRuong oTR = new clsThuaRuong(_IDThuaRuong);
                        oTR.Load(null, null);
                        oTR.HopDongID = _HopDongID;
                        oTR.ThonID = _ThonID;
                        oTR.CanBoNongVuID = _CanBoNongVuID;
                        oTR.XuDong = lblXuDong.Text;
                        oTR.BaiTapKetID = long.Parse(cboBaiTapKet.SelectedValue.ToString());
                        oTR.DienTich = nDT.Value*10000;
                        oTR.NangSuatDuKien = nNS.Value;
                        oTR.SanLuongDuKien = nSanLuong.Value;
                        oTR.VuTrongID = MDSolutionApp.VuTrongID;
                        oTR.RaiVuID = long.Parse(cboVuTrong.SelectedValue.ToString());
                        oTR.MucDichID = long.Parse(cboMucDich.SelectedValue.ToString());
                        oTR.KieuTrongID = long.Parse(cboKieuTrong.SelectedValue.ToString());
                        oTR.LoaiDatID = long.Parse(cboLoaiDat.SelectedValue.ToString());
                        oTR.GiongMiaID = long.Parse(cboGiong.SelectedValue.ToString());
                        if (dtNgayTrong.IsNullDate == true)
                        {
                            oTR.NgayTrong = DateTime.MinValue;
                        }
                        else
                        {
                            oTR.NgayTrong = dtNgayTrong.Value;
                        }
                        oTR.Save(null, null);
                        MessageBox.Show("Bạn đã sửa thông tin thửa ruộng thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OK = 1;
                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi khi sửa!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                this.Close();
                //ReSetForm_NhapDienTich();//Khởi tạo các control/biến trên form nhập để nhập tiếp
            }
           
        }
     
        private void nDT_ValueChanged(object sender, EventArgs e)
        {
            if (nDT.Value > 0)
            {
                decimal NS = Math.Round(nSanLuong.Value / nDT.Value, 0);
                nNS.Value = NS;
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
            if (nDT.Value <= 0)
            {
                MessageBox.Show("Chưa nhập diện tích cho thửa ruộng!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nDT.Focus();
                return false;
            }
            if (cboLoaiDat.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn loại đất!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboLoaiDat.Focus();
                return false;
            }
            if (cboGiong.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn loại giống!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboGiong.Focus();
                return false;
            }
            if (cboKieuTrong.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn kiểu trồng!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboKieuTrong.Focus();
                return false;
            }
            if (cboVuTrong.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn vụ trồng!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboVuTrong.Focus();
                return false;
            }
            if (cboBaiTapKet.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn Bãi tập kết cho thửa ruộng!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBaiTapKet.Focus();
                return false;
            }
         
            if (cboMucDich.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn mục đích trồng!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboMucDich.Focus();
                return false;
            }
         
          
            return true;
        }

        private void frm_NhapDienTich_Load(object sender, EventArgs e)
        {
            if (MDSolutionApp.User.ID != 1)
            {
                //clsComFunctions.checkControlsPermission(this, this.Name.ToString());              
            }
            try
            {
                cboThon.SelectedIndex = 0;
            }
            catch { }
            if (_IDThuaRuong > 0)
            {
                Load_XuDong_DonGia();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void txtCMNDChuDat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void nSanLuong_ValueChanged(object sender, EventArgs e)
        {
            decimal NS = 0;
            if (nDT.Value > 0)
            {
              NS= Math.Round(nSanLuong.Value/nDT.Value, 0);
            }
            nNS.Value = NS;
        }

     

        private void nDT_MouseClick(object sender, MouseEventArgs e)
        {
            nDT.Select();
            nDT.Select(0, nDT.Value.ToString().Length + nDT.DecimalPlaces + 2);
        }

        private void nDT_Enter(object sender, EventArgs e)
        {
            nDT.Select();
            nDT.Select(0, nDT.Value.ToString().Length + nDT.DecimalPlaces + 2);
        }

        private void nSanLuong_Enter(object sender, EventArgs e)
        {
            nSanLuong.Select();
            nSanLuong.Select(0, nSanLuong.Value.ToString().Length);
        }

        private void cboBaiTapKet_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_XuDong_DonGia();
        }

       
      
    }
}
