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
    public partial class frm_LapPhieuVatTu : Form
    {
        private long _CBNVID = -1;
        public long _XUATVTID = -1;
        private long _XEID = -1;
        public long _CO_TINH_CUOC = 1;
        public long OK = -1;
        public frm_LapPhieuVatTu()
        {
            InitializeComponent();
        }
        public frm_LapPhieuVatTu(long CBNVID)
        {
            InitializeComponent();
            _CBNVID = CBNVID;
            LoadCBLoaiVatTu();
            LoadVuTrong();
            cboVuTrong.SelectedValue = MDSolutionApp.VuTrongID;
            LoadHDVC(MDSolutionApp.VuTrongID);
            txtSoPhieu.Text = MaxSoPhieu().ToString();
            dtNgayLapPhieu.Value = NgayHienHanh();
            clsDanhMucCanBoNongVu oCBNV = new clsDanhMucCanBoNongVu(_CBNVID);
            oCBNV.Load(null, null);
            lbl_CBDB.Text = oCBNV.Ten;
        }
        public frm_LapPhieuVatTu(long PhieuVTID, long CBNVID)
        {
            InitializeComponent();
            lblTitle.Text = "SỬA PHIẾU CẤP VẬT TƯ";
            _XUATVTID = PhieuVTID;
            _CBNVID = CBNVID;
            LoadCBLoaiVatTu();
            LoadVuTrong();
            clsXuatVatTu oXVT = new clsXuatVatTu(_XUATVTID);
            oXVT.Load(null, null);
            clsDanhMucCanBoNongVu oCBNV = new clsDanhMucCanBoNongVu(_CBNVID);
            oCBNV.Load(null, null);
            lbl_CBDB.Text = oCBNV.Ten;
            txtSoPhieu.Text = oXVT.SoPhieu.ToString();
            nSoLuong.Value = oXVT.TrongLuongHoaDon;
            nPhanTram.Value = oXVT.PhanTramGiaVanChuyenMia;
            if (oXVT.NgayLapPhieu == DateTime.MinValue)
            {
                dtNgayLapPhieu.Value = NgayHienHanh();
            }
            else
            {
                dtNgayLapPhieu.Value = oXVT.NgayLapPhieu;
            }
            cboVatTu.SelectedValue = oXVT.VatTuID;
            lbl_GiaVatTu.Text = oXVT.DonGia.ToString("### ### ##0");
            _XEID = oXVT.XeID;
            if (_XEID > 0)
            {
                check_XeNgoai.Checked = true;
                long VT = clsXeVanChuyen.GetXeVuTrong(_XEID, null, null);
                cboVuTrong.SelectedValue = VT;
                LoadHDVC(VT);
                long HDVCID = clsXeVanChuyen.GetXeHopDong(_XEID, null, null);
                cboHDVC.SelectedValue = HDVCID;
                GetThongTinXe(HDVCID);
            }
            else
            {
                check_XeNgoai.Checked = false;
                txtSoXe.Text = oXVT.SoXeThueNgoai;
            }
            _CO_TINH_CUOC = oXVT.CoTinhCuoc;
            if (_CO_TINH_CUOC > 0)
            {
                chkTinhCuoc.Checked = true;
            }
            else
            {
                chkTinhCuoc.Checked = false;
            }
        }
        private DateTime NgayHienHanh()
        {
            DateTime dt = DateTime.Now.Date;
            try
            {
                dt = DateTime.Parse(DBModule.ExecuteQueryForOneResult("Select Getdate()", null, null).ToString());
            }
            catch { }
            return dt;

        }
        private long MaxSoPhieu()
        {
            long Max = -1;
            string sql = "Select ISNULL(Max(SoPhieu),0)+1 From tbl_XuatVatTu Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
            try
            {
                Max = long.Parse(DBModule.ExecuteQueryForOneResult(sql, null, null));
            }
            catch { }
            return Max;
        }

        private void check_XeNgoai_CheckedChanged(object sender, EventArgs e)
        {
            if (check_XeNgoai.Checked)
            {
                grXe.Enabled = true;
                txtSoXe.Enabled = false;
                txtSoXe.Text = "";
            }
            else
            {
                grXe.Enabled = false;
                _XEID = -1;
                cboVuTrong.SelectedIndex = -1;
                cboVuTrong.Text = "";
                lbl_CHDVC.Text = "";
                lblSoXe.Text = "";
                txtSoXe.Enabled = true;
                txtSoXe.Text = "";
                txtSoXe.Focus();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool VerifyData()
        {
            if (cboVatTu.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn loại vật tư!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                cboVatTu.Focus();
                return false;
            }
            if (check_XeNgoai.Checked)
            {
                if (cboHDVC.SelectedIndex < 0)
                {
                    MessageBox.Show("Chưa chọn xe vận chuyển!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    cboHDVC.Focus();
                    return false;
                }
            }
            else
            {
                if (txtSoXe.Text.Trim() == "")
                {
                    MessageBox.Show("Chưa nhập xe vận chuyển thuê ngoài!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtSoXe.Focus();
                    return false;
                }
            }
            return true;
        }
        private void cmdLuu_Click(object sender, EventArgs e)
        {
            string Co_Tinh_Cuoc = "";
            if (chkTinhCuoc.Checked)
            {
                Co_Tinh_Cuoc = "Có tính cước";
            }
            else
            {
                Co_Tinh_Cuoc = "Không tính cước";
            }
            string HDVC = "";
            string So_Xe = "";
            if (check_XeNgoai.Checked)
            {
                HDVC = cboHDVC.Text;
                So_Xe = lblSoXe.Text;
            }
            else
            {
                HDVC = "Thuê ngoài";
                So_Xe = txtSoXe.Text;
            }
            if (VerifyData())
            {
                if (_XUATVTID <= 0)
                {
                    MDFoms.CapVatTu.frmConfirm frm = new MDFoms.CapVatTu.frmConfirm(cboVatTu.Text, Co_Tinh_Cuoc, nPhanTram.Value, HDVC, So_Xe, true);
                    frm.ShowDialog();
                    if (frm.OK <= 0)
                    {
                        return;
                    }
                    clsXuatVatTu oXVT = new clsXuatVatTu();
                    oXVT.SoPhieu = long.Parse(txtSoPhieu.Text);
                    oXVT.NgayLapPhieu = dtNgayLapPhieu.Value;
                    oXVT.VatTuID = long.Parse(cboVatTu.SelectedValue.ToString());
                    oXVT.XeID = _XEID;
                    oXVT.CanBoNongVuID = _CBNVID;
                    oXVT.TrongLuongHoaDon = nSoLuong.Value;
                    oXVT.PhanTramGiaVanChuyenMia = nPhanTram.Value;
                    oXVT.DonGia = decimal.Parse(lbl_GiaVatTu.Text.Replace(" ", ""));
                    oXVT.ThanhTien = oXVT.TrongLuongHoaDon * oXVT.DonGia;
                    oXVT.SoXeThueNgoai = txtSoXe.Text;
                    oXVT.CoTinhCuoc = _CO_TINH_CUOC;
                    oXVT.AddBy = MDSolutionApp.User.HoTen;
                    if (clsXuatVatTu.CheckSoPhieu(oXVT.SoPhieu, null, null))
                    {
                        oXVT.Save(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại số phiếu " + oXVT.SoPhieu.ToString() + "\nBạn thực hiện lại lệnh cấp phiếu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        OK = -1;
                        this.Close();
                        return;
                    }
                    _XUATVTID = oXVT.ID;
                }
                else
                {
                    MDFoms.CapVatTu.frmConfirm frm = new MDFoms.CapVatTu.frmConfirm(cboVatTu.Text, Co_Tinh_Cuoc, nPhanTram.Value, HDVC, So_Xe, false);
                    frm.ShowDialog();
                    if (frm.OK <= 0)
                    {
                        return;
                    }
                    clsXuatVatTu oXVTSua = new clsXuatVatTu(_XUATVTID);
                    oXVTSua.Load(null, null);
                    //oXVTSua.SoPhieu = long.Parse(txtSoPhieu.Text);
                    oXVTSua.NgayLapPhieu = dtNgayLapPhieu.Value;
                    oXVTSua.VatTuID = long.Parse(cboVatTu.SelectedValue.ToString());
                    oXVTSua.XeID = _XEID;
                    oXVTSua.CanBoNongVuID = _CBNVID;
                    oXVTSua.TrongLuongHoaDon = nSoLuong.Value;
                    oXVTSua.PhanTramGiaVanChuyenMia = nPhanTram.Value;
                    oXVTSua.DonGia = decimal.Parse(lbl_GiaVatTu.Text.Replace(" ", ""));
                    oXVTSua.ThanhTien = oXVTSua.TrongLuongHoaDon * oXVTSua.DonGia;
                    oXVTSua.SoXeThueNgoai = txtSoXe.Text;
                    oXVTSua.CoTinhCuoc = _CO_TINH_CUOC;
                    oXVTSua.ModifyBy = MDSolutionApp.User.HoTen;
                    oXVTSua.Save(null, null);
                }
                OK = 1;
                this.Close();
            }
        }

        private void LoadHDVC(long VTID)
        {
            if (VTID > 0)
            {
                string sql = "Select ID,(MaHopDong+' - '+TenChuHopDong) AS MaHopDong From tbl_HopDongVanChuyen Where VuTrongID=" + VTID.ToString() + " Order By dbo.LPAD(MaHopDong,'4','0')";
                DataSet ds = DBModule.ExecuteQuery(sql, null, null);
                cboHDVC.DataSource = ds.Tables[0];
                cboHDVC.ValueMember = "ID";
                cboHDVC.DisplayMember = "MaHopDong";
                

            }
            else
            {
                cboHDVC.DataSource = null;
                cboHDVC.Text = "";
            }

        }
        private void LoadVuTrong()
        {
            string sql = "Select * From tbl_VuTrong Where ID>=" + MDSolutionApp.VuTrongID.ToString();
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

        private void LoadCBLoaiVatTu()
        {
            string sql = "Select * From tbl_DanhMucVatTu";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboVatTu.DataSource = ds.Tables[0];
                cboVatTu.ValueMember = "DanhMucDauTuID";
                cboVatTu.DisplayMember = "Ten";
            }
            else
            {
                cboVatTu.DataSource = null;
                cboVatTu.Text = "";
            }
        }

        private void cboVuTrong_SelectedIndexChanged(object sender, EventArgs e)
        {
            long VT_ID = -1;
            try
            {
                VT_ID = long.Parse(cboVuTrong.SelectedValue.ToString());
            }
            catch
            {
            }
            LoadHDVC(VT_ID);
        }

        private void cboHDVC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHDVC.SelectedIndex >= 0)
            {
                long HDVC_ID = long.Parse(cboHDVC.SelectedValue.ToString());
                GetThongTinXe(HDVC_ID);
            }
        }

        private void cboVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVatTu.SelectedIndex >= 0)
            {
                long VT_ID = long.Parse(cboVatTu.SelectedValue.ToString());
                GetDonGiaVatTu(VT_ID);
            }
        }
        private void GetThongTinXe(long HDVCID)
        {
            if (HDVCID > 0)
            {
                string sql = "Select XE.ID,XE.SoXe,HD.TenChuHopDong,XE.HopDongVanChuyenID " +
                             " From tbl_XeVanChuyen AS XE INNER JOIN tbl_HopDongVanChuyen AS HD ON XE.HopDongVanChuyenID=HD.ID " +
                             " Where XE.HopDongVanChuyenID=" + HDVCID.ToString();
                DataSet ds = DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    _XEID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                    lblSoXe.Text = ds.Tables[0].Rows[0]["SoXe"].ToString();
                    lbl_CHDVC.Text = ds.Tables[0].Rows[0]["TenChuHopDong"].ToString();
                }
                else
                {
                    _XEID = -1;
                    lblSoXe.Text = "";
                    lbl_CHDVC.Text = "";
                }
            }
        }

        private void GetThongTinXeMa(string MaHDVC)
        {
            if (!string.IsNullOrEmpty(MaHDVC))
            {
                string sql = "Select XE.ID,XE.SoXe,HD.TenChuHopDong,XE.HopDongVanChuyenID " +
                             " From tbl_XeVanChuyen AS XE INNER JOIN tbl_HopDongVanChuyen AS HD ON XE.HopDongVanChuyenID=HD.ID " +
                             " Where  HD.MaHopDong = " + MaHDVC+"    AND  XE.VuTrongID=" + MDSolutionApp.VuTrongID.ToString();

                try
                {
                    DataSet ds = DBModule.ExecuteQuery(sql, null, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        _XEID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                        lblSoXe.Text = ds.Tables[0].Rows[0]["SoXe"].ToString();
                        lbl_CHDVC.Text = ds.Tables[0].Rows[0]["TenChuHopDong"].ToString();
                        string sqldropdow = "Select ID,(MaHopDong+' - '+TenChuHopDong) AS MaHopDong From tbl_HopDongVanChuyen Where ID= " + ds.Tables[0].Rows[0]["HopDongVanChuyenID"].ToString() + " Order By dbo.LPAD(MaHopDong,'4','0')";
                        try
                        {
                            DataSet dsHD = DBModule.ExecuteQuery(sqldropdow, null, null);
                            cboHDVC.DataSource = dsHD.Tables[0];
                            cboHDVC.ValueMember = "ID";
                            cboHDVC.DisplayMember = "MaHopDong";
                            cboHDVC.SelectedIndex = 1;
                        }
                        catch { }
                    }
                    else
                    {
                        _XEID = -1;
                        lblSoXe.Text = "";
                        lbl_CHDVC.Text = "";
                        //MessageBox.Show("Không tìm thấy mã hợp đồng");
                    }
                }
                catch {
                    MessageBox.Show("Không tìm thấy mã hợp đồng");
                }
                
            }
        }
        private void GetDonGiaVatTu(long IDVT)
        {
            if (IDVT > 0)
            {
                decimal DonGia = 0;
                string sql = "Select Top 1 DonGia From tbl_GiaVatTu WHERE NgayApDung<=GetDate() AND VatTuID=" + IDVT.ToString() + " Order By NgayApDung DESC";
                try
                {
                    DonGia = decimal.Parse(DBModule.ExecuteQueryForOneResult(sql, null, null));
                }
                catch { }
                lbl_GiaVatTu.Text = DonGia.ToString("### ### ##0");
            }
            else
            {
                lbl_GiaVatTu.Text = "0";
            }
        }

        private void chkTinhCuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTinhCuoc.Checked == true)
            {
                _CO_TINH_CUOC = 1;
                nPhanTram.Enabled = true;
                nPhanTram.Value = 100;
            }
            else
            {
                _CO_TINH_CUOC = 0;
                nPhanTram.Enabled = false;
                nPhanTram.Value = 100;
            }
            clsXuatVatTu.UpdateTinhCuoc(_XUATVTID, _CO_TINH_CUOC, nPhanTram.Value, null, null);
        }

        private void txt_MaHDVC_Enter(object sender, EventArgs e)
        {
            GetThongTinXeMa(txt_MaHDVC.Text.Trim());
        }

        private void txt_MaHDVC_TextChanged(object sender, EventArgs e)
        {
            GetThongTinXeMa(txt_MaHDVC.Text.Trim());
           
        }
    }
}