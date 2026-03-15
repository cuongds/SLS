using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms.CapVatTu
{
    public partial class frm_ThemSuaHopDongNhanVatTu : Form
    {
        public int OK = 0;
        public long _IDXUATVATU = -1;
        public long _IDNHANVATTU = -1;
        public long _CBNVID = -1;
        public long _HOPDONGID = -1;
        private long _CO_TINH_CUOC = 1;
        private decimal _PHANTRAMGIA_VC_MIA = 100;
        private DateTime NGAYRA = DateTime.Now;
        public frm_ThemSuaHopDongNhanVatTu()
        {
            InitializeComponent();
        }
        public frm_ThemSuaHopDongNhanVatTu(long IDNhanVT,long IsModify)//Sửa
        {
            InitializeComponent();
            lblTitle.Text = "SỬA NÔNG HỘ NHẬN VẬT TƯ";
            _IDNHANVATTU = IDNhanVT;
            clsNhanVatTu oNhanVatTu = new clsNhanVatTu(_IDNHANVATTU);
            oNhanVatTu.Load(null,null);
            _CBNVID = oNhanVatTu.CanBoNongVuID;
            _HOPDONGID = oNhanVatTu.HopDongID;
            _IDXUATVATU = oNhanVatTu.XuatVatTuID;
            clsXuatVatTu oXuat = new clsXuatVatTu(_IDXUATVATU);
            oXuat.Load(null, null);
            NGAYRA = oXuat.NgayRa;
            _CO_TINH_CUOC = oXuat.CoTinhCuoc;
            _PHANTRAMGIA_VC_MIA = oXuat.PhanTramGiaVanChuyenMia;
            lblSoPhieu.Text = oXuat.SoPhieu.ToString();
            clsDanhMucVatTu oVT = new clsDanhMucVatTu(oXuat.VatTuID);
            oVT.LoadByVatTuID(null, null);
            lblTenVT.Text = oVT.Ten;
            clsHopDong oHD = new clsHopDong(_HOPDONGID);
            oHD.Load(null, null);
            txtHoTen.Text = oHD.HoTen;
            nSoLuongVatTu.Value = oNhanVatTu.SoLuong;
            LoadCBThon(_CBNVID);
            clsBaiTapKet oBTK = new clsBaiTapKet(oNhanVatTu.BaiTapKetID);
            oBTK.Load(null, null);
            cboThon.SelectedValue = oBTK.ThonID;
            LoadBTK(oBTK.ThonID);
            cboBTKVatTu.SelectedValue = oNhanVatTu.BaiTapKetID;
            nDGVC.Value= oNhanVatTu.DonGiaVanChuyen;
            if (_CO_TINH_CUOC > 0)
            {
                nTienVC.Value = oNhanVatTu.TienVanChuyen;
            }
            else
            {
                nTienVC.Value = 0;
            }
            nDGVT.Value = oNhanVatTu.DonGia;
            nSoTienVatTu.Value = oNhanVatTu.SoTien;
            if (oNhanVatTu.NgayNhan == DateTime.MinValue)
            {
                dtNgayNhan.Value = NgayHienHanh();
            }
            else
            {
                dtNgayNhan.Value = oNhanVatTu.NgayNhan;
            }
            if (IsModify > 0)
            {
                nDGVC.Enabled = true;
                nDGVC.ReadOnly = false;
                dtNgayNhan.Enabled = false;
                nSoLuongVatTu.Enabled = false;
                cmdThemHoCapVT.Enabled = false;
            }
        }
        public frm_ThemSuaHopDongNhanVatTu(long IDXuatVT,string TenVT)//Thêm mới
        {
            InitializeComponent();
            _IDXUATVATU = IDXuatVT;
            clsXuatVatTu oXVT = new clsXuatVatTu(_IDXUATVATU);
            oXVT.Load(null, null);
            NGAYRA = oXVT.NgayRa;
            _PHANTRAMGIA_VC_MIA = oXVT.PhanTramGiaVanChuyenMia;
            _CBNVID = oXVT.CanBoNongVuID;
            _CO_TINH_CUOC = oXVT.CoTinhCuoc;
            LoadCBThon(_CBNVID);
            lblSoPhieu.Text = oXVT.SoPhieu.ToString();
            lblTenVT.Text = TenVT;
            nDGVT.Value = oXVT.DonGia;
            dtNgayNhan.Value = NgayHienHanh();
        }
        private void LoadCBThon(long CBNVID)
        {
            string sql = "SELECT  dbo.tbl_Thon.Ten, dbo.tbl_Thon.ID FROM dbo.tbl_Thon WHERE tbl_Thon.CanBoNongVuID=" + CBNVID.ToString();
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
                cboThon.Text = "";
            }
        }
        private void LoadBTK(long ThonID)
        {
            string sql = "SELECT  dbo.tbl_BaiTapKet.TenBai, dbo.tbl_BaiTapKet.ID FROM  dbo.tbl_BaiTapKet WHERE dbo.tbl_BaiTapKet.ThonID=" + ThonID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboBTKVatTu.DataSource = ds.Tables[0];
                cboBTKVatTu.ValueMember = "ID";
                cboBTKVatTu.DisplayMember = "TenBai";
            }
            else
            {
                cboBTKVatTu.DataSource = null;
                cboBTKVatTu.Text = "";
            }
        }
        private bool Verify()
        {
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Chưa có tên nông hộ!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }
            if (nSoLuongVatTu.Value == 0)
            {
                MessageBox.Show("Chưa nhập số lượng vật tư!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nSoLuongVatTu.Focus();
                return false;
            }
            if (cboBTKVatTu.SelectedIndex< 0)
            {
                MessageBox.Show("Chưa chọn bãi tập kết!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBTKVatTu.Focus();
                return false;
            }
          
            return true;
        }
        private DateTime NgayHienHanh()
        {
            DateTime dt = DateTime.Now;
            try
            {
                dt = DateTime.Parse(DBModule.ExecuteQueryForOneResult("Select Getdate()", null, null).ToString());
            }
            catch { }
            return dt;

        }
        private bool CheckNongHo(long HopDongID)
        {
            if (_IDNHANVATTU < 0)
            {
                string sql = "Select HopDongID from tbl_NhanVatTu Where HopDongID=" + HopDongID.ToString() + " AND XuatVatTuID=" + _IDXUATVATU.ToString();
                string ret = DBModule.ExecuteQueryForOneResult(sql, null, null);
                if (string.IsNullOrEmpty(ret))
                {
                    return true;
                }
                else
                {
                   return false;
                }
            }
            return true;
       }
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
           if (Verify())
            {
                if (CheckNongHo(_HOPDONGID))
                {
                    if (_IDNHANVATTU < 0)
                    {
                        clsNhanVatTu oNVT = new clsNhanVatTu();
                        oNVT.BaiTapKetID = long.Parse(cboBTKVatTu.SelectedValue.ToString());
                        oNVT.CanBoNongVuID = _CBNVID;
                        oNVT.NgayNhan = dtNgayNhan.Value;
                        oNVT.HopDongID = _HOPDONGID;
                        oNVT.SoLuong = nSoLuongVatTu.Value;
                        oNVT.XuatVatTuID = _IDXUATVATU;
                        oNVT.DonGiaVanChuyen = nDGVC.Value;
                        oNVT.TienVanChuyen = nTienVC.Value;
                        oNVT.DonGia = nDGVT.Value;
                        oNVT.SoTien = nSoTienVatTu.Value;
                        oNVT.Save(null, null);
                        _IDNHANVATTU = oNVT.ID;
                    }
                    else
                    {
                        clsNhanVatTu oNVT = new clsNhanVatTu(_IDNHANVATTU);
                        oNVT.Load(null, null);
                        oNVT.BaiTapKetID = long.Parse(cboBTKVatTu.SelectedValue.ToString());
                        oNVT.CanBoNongVuID = _CBNVID;
                        oNVT.NgayNhan = dtNgayNhan.Value;
                        oNVT.HopDongID = _HOPDONGID;
                        oNVT.SoLuong = nSoLuongVatTu.Value;
                        oNVT.XuatVatTuID = _IDXUATVATU;
                        oNVT.DonGiaVanChuyen = nDGVC.Value;
                        oNVT.TienVanChuyen = nTienVC.Value;
                        oNVT.DonGia = nDGVT.Value;
                        oNVT.SoTien = nSoTienVatTu.Value;
                        oNVT.Save(null, null);
                    }
                    OK = 1;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đã tồn tại hộ nhận: "+txtHoTen.Text+"\ntrong phiếu cấp vật tư: "+lblSoPhieu.Text, "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            
         }
        private decimal GetDonGiaVanChuyen(long IDBTK)
        {
            decimal DGVCBD = 0;
            decimal DGVC = 0;
            if (IDBTK > 0)
            {
                string sql = "Select Top 1 DonGiaVanChuyenVatTu From tbl_BaiTapKet_GiaCuoc WHERE BaiTapKetID=" + IDBTK.ToString() +
                              " AND VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " ORDER BY NgayAD_GiaVC_VT";
                try
                {
                    DGVCBD = decimal.Parse(DBModule.ExecuteQueryForOneResult(sql, null, null));
                }
                catch { }
                if (NGAYRA == DateTime.MinValue)
                {
                    NGAYRA = DateTime.Now;
                }
                sql = "Select Top 1 DonGiaVanChuyenVatTu From tbl_BaiTapKet_GiaCuoc WHERE BaiTapKetID=" + IDBTK.ToString()+
                             " AND NgayAD_GiaVC_VT<="+DBModule.RefineDatetime(NGAYRA)+" AND VuTrongID="+MDSolutionApp.VuTrongID.ToString()+" ORDER BY NgayAD_GiaVC_VT DESC";
                try
                {
                    DGVC = decimal.Parse(DBModule.ExecuteQueryForOneResult(sql, null, null));
                }
                catch 
                {
                    DGVC = DGVCBD;
                }
            }
            else
            {
                DGVC = 0;
            }
            return DGVC;
        }
        private void cboBTKVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBTKVatTu.SelectedIndex >= 0)
            {
              nDGVC.Value=GetDonGiaVanChuyen(long.Parse(cboBTKVatTu.SelectedValue.ToString()))*_PHANTRAMGIA_VC_MIA/100;
            }
        }

        private void nDGVC_ValueChanged(object sender, EventArgs e)
        {
           if (nDGVC.Value>nDGVC.Maximum) nDGVC.Value=nDGVC.Maximum;
           if (_CO_TINH_CUOC > 0)
           {
               nTienVC.Value = Math.Round(nDGVC.Value * nSoLuongVatTu.Value / 1000, 0);
           }
           else
           {
               nTienVC.Value = 0;
           }
        }

        private void nSoLuongVatTu_ValueChanged(object sender, EventArgs e)
        {
            if (nSoLuongVatTu.Value > nSoLuongVatTu.Maximum) nSoLuongVatTu.Value = nSoLuongVatTu.Maximum;
            nSoTienVatTu.Value =  Math.Round(nDGVT.Value * nSoLuongVatTu.Value,0);
            if (_CO_TINH_CUOC > 0)
            {
                nTienVC.Value = Math.Round(nDGVC.Value * nSoLuongVatTu.Value / 1000, 0);
            }
            else
            {
                nTienVC.Value = 0;
            }
        }

        private void cmdThemHoCapVT_Click(object sender, EventArgs e)
        {
            MDForms.CapVatTu.frm_ChonHD frm = new frm_ChonHD(_CBNVID);
            frm.ShowDialog();
            if (frm.OK > 0)
            {
                txtHoTen.Text = frm.HoTen;
                _HOPDONGID = frm.HopDongID;
            }
        }

        private void cboThon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboThon.SelectedIndex >= 0)
            {
                long ID_Thon = long.Parse(cboThon.SelectedValue.ToString());
                LoadBTK(ID_Thon);
            }
        }


        private void cboBTKVatTu_Validated(object sender, EventArgs e)
        {
            if (cboBTKVatTu.SelectedIndex >= 0)
            {
                nDGVC.Value = GetDonGiaVanChuyen(long.Parse(cboBTKVatTu.SelectedValue.ToString())) * _PHANTRAMGIA_VC_MIA / 100;
            }
        }

        //private void cboBTKVatTu_TextChanged(object sender, EventArgs e)
        //{

        //    if (cboBTKVatTu.SelectedIndex >= 0)
        //    {
        //        nDGVC.Value = GetDonGiaVanChuyen(long.Parse(cboBTKVatTu.SelectedValue.ToString())) * _PHANTRAMGIA_VC_MIA / 100;
        //    }
        //}

    
     }
}
