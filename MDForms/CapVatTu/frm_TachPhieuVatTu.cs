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
    public partial class frm_TachPhieuVatTu : Form
    {
        private decimal TL_HOADON = 0;
        private decimal TL_CAN = 0;
        private decimal TL_THUCTE = 0;
        private decimal TL_THUCTE_TG = 0;
        private long CBNV_ID = -1;
        public long OK = -1;
        public long SOPHIEU_TACH = -1;
        public string TEN_CBNV = "";
        clsXuatVatTu oXuatVT = new clsXuatVatTu();
        public frm_TachPhieuVatTu()
        {
            InitializeComponent();
        }
      
        public frm_TachPhieuVatTu(long PhieuVTID)
        {
            InitializeComponent();
            LoadCBNV();
            oXuatVT.ID = PhieuVTID;
            oXuatVT.Load(null, null);
            CBNV_ID = oXuatVT.CanBoNongVuID;
            TL_HOADON = oXuatVT.TrongLuongHoaDon;
            TL_CAN = oXuatVT.TrongLuong;
            TL_THUCTE = oXuatVT.TrongLuongThucTe;
            TL_THUCTE_TG = TL_THUCTE;
            clsDanhMucCanBoNongVu oCBNV = new clsDanhMucCanBoNongVu(oXuatVT.CanBoNongVuID);
            oCBNV.Load(null, null);
            clsDanhMucVatTu oDMVT = new clsDanhMucVatTu(oXuatVT.VatTuID);
            oDMVT.LoadByVatTuID(null, null);
            lblSoPhieu.Text = oXuatVT.SoPhieu.ToString();
            lbl_CBDB.Text = oCBNV.Ten;
            lblTenVatTu.Text = oDMVT.Ten;
            if (oXuatVT.XeID < 0)
            {
                lbl_SoXe.Text = oXuatVT.SoXeThueNgoai;
            }
            else
            {
                clsXeVanChuyen oXeVC = new clsXeVanChuyen(oXuatVT.XeID);
                oXeVC.Load(null, null);
                lbl_SoXe.Text = oXeVC.SoXe;
            }
            dtNgayLapPhieu.Value = oXuatVT.NgayLapPhieu;
            nTLHD_Chinh.Value = TL_HOADON;
            nTLCan_Chinh.Value = TL_CAN;
        }
        private void LoadCBNV()
        {
            string sql = "Select ID,Ten From tbl_DanhMucCanBoNongVu";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboCBNV.DataSource = ds.Tables[0];
                cboCBNV.ValueMember = "ID";
                cboCBNV.DisplayMember = "Ten";
            }
            else
            {
                cboCBNV.DataSource = null;
                cboCBNV.Text = "";
            }
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
      
     
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool VerifyData()
        {
            if (cboCBNV.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn CBNV!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                cboCBNV.Focus();
                return false;
            }
            if (cboCBNV.SelectedIndex >= 0)
            {
                long CBID = long.Parse(cboCBNV.SelectedValue.ToString());
                if (CBID == CBNV_ID)
                {
                    MessageBox.Show("Bạn cần chọn CBNV khác "+cboCBNV.Text+" để tách phiếu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    cboCBNV.Focus();
                    return false;
                }
            }
            return true;
        }
        private void cmdLuu_Click(object sender, EventArgs e)
        {
            if (VerifyData())
            {
                if (MessageBox.Show("Bạn chắc chắn tách phiếu", "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                clsXuatVatTu oTachVT = new clsXuatVatTu();
                SOPHIEU_TACH = MaxSoPhieu();
                oTachVT.SoPhieu = SOPHIEU_TACH;
                oTachVT.CoTinhCuoc = oXuatVT.CoTinhCuoc;
                oTachVT.NguoiTach = MDSolutionApp.User.HoTen;
                oTachVT.TachTuPhieu = oXuatVT.SoPhieu;
                oTachVT.CanBoNongVuID = long.Parse(cboCBNV.SelectedValue.ToString());
                oTachVT.NgayLapPhieu = oXuatVT.NgayLapPhieu;
                oTachVT.SoXeThueNgoai = oXuatVT.SoXeThueNgoai;
                oTachVT.XeID = oXuatVT.XeID;
                oTachVT.VatTuID = oXuatVT.VatTuID;
                oTachVT.DonGia = oXuatVT.DonGia;
                oTachVT.TrongLuongHoaDon = nTLHD_Phu.Value;
                oTachVT.TrongLuong = nTLCan_Phu.Value;
                oTachVT.TrongLuongThucTe = nTLCan_Phu.Value;
                oTachVT.DaCan = oXuatVT.DaCan;
                oTachVT.AddBy = MDSolutionApp.User.HoTen;
                oTachVT.NgayVao = oXuatVT.NgayVao;
                oTachVT.NgayRa = oXuatVT.NgayRa;
                oTachVT.PhanTramGiaVanChuyenMia = oXuatVT.PhanTramGiaVanChuyenMia;
                oTachVT.Save(null, null);
                oXuatVT.TrongLuong = nTLCan_Chinh.Value;
                oXuatVT.TrongLuongHoaDon = nTLHD_Chinh.Value;
                oXuatVT.TrongLuongThucTe = TL_THUCTE;
                oXuatVT.Save(null, null);
                OK = 1;
                this.Close();
            }
        }

        private void nTLHD_Phu_ValueChanged(object sender, EventArgs e)
        {
            if (nTLHD_Phu.Value > TL_HOADON)
            {
                nTLHD_Phu.Value = 0;
            }
            nTLHD_Chinh.Value = TL_HOADON - nTLHD_Phu.Value;
        }

        private void nTLCan_Phu_ValueChanged(object sender, EventArgs e)
        {
            if (nTLCan_Phu.Value > TL_CAN)
            {
                nTLCan_Phu.Value = 0;
            }
            nTLCan_Chinh.Value = TL_CAN - nTLCan_Phu.Value;
            TL_THUCTE = TL_CAN - nTLCan_Phu.Value;
        }

        private void cboCBNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCBNV.SelectedIndex >= 0)
            {
                TEN_CBNV = cboCBNV.Text;
            }
        }

        private void chkChuyenHet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenHet.Checked == true)
            {
                nTLHD_Phu.Value = TL_HOADON;
                nTLCan_Phu.Value = TL_CAN;
                TL_THUCTE = 0;
                nTLHD_Phu.Enabled = false;
                nTLCan_Phu.Enabled = false;
                nTLHD_Chinh.Value = 0;
                nTLCan_Chinh.Value = 0;
            }
            else
            {
                TL_THUCTE = TL_THUCTE_TG;
                nTLHD_Phu.Value = 0;
                nTLCan_Phu.Value = 0;
                nTLHD_Chinh.Value = TL_HOADON;
                nTLCan_Chinh.Value = TL_CAN;
                nTLHD_Phu.Enabled = true;
                nTLCan_Phu.Enabled = true;
            }
        }

    }
}