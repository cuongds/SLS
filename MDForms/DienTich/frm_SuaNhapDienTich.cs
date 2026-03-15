using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms.DienTich
{
    public partial class frm_SuaNhapDienTich : Form
    {
        public int OK = 0;
        private long _ID = -1;
        private long _CBNVID = -1;
        private long _HOPDONGID = -1;
        private string MaHD = "";
        private string TenCBDB = "";
        public frm_SuaNhapDienTich()
        {
            InitializeComponent();
        }
        public frm_SuaNhapDienTich(long CBNVID, string CBDB_Name,long ID_Import)//Sửa
        {
            InitializeComponent();
            _CBNVID = CBNVID;
            _ID = ID_Import;
            TenCBDB = CBDB_Name;
        }
        private void LoadKieuTrong()
        {
            string sql = "SELECT  ID,Ten FROM dbo.tbl_KieuTrong";
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
                cboKieuTrong.Text = "";
            }
        }
        private void LoadLoaiDat()
        {
            string sql = "SELECT  ID,Ten FROM dbo.tbl_LoaiDat";
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
                cboLoaiDat.Text = "";
            }
        }
        private void LoadLoaiGiong()
        {
            string sql = "SELECT  ID,Ten FROM dbo.tbl_GiongMia Where (ID>=10 And ID!=27) Order By Ten";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboLoaiGiong.DataSource = ds.Tables[0];
                cboLoaiGiong.ValueMember = "ID";
                cboLoaiGiong.DisplayMember = "Ten";
            }
            else
            {
                cboLoaiGiong.DataSource = null;
                cboLoaiGiong.Text = "";
            }
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
                cboBTK.DataSource = ds.Tables[0];
                cboBTK.ValueMember = "ID";
                cboBTK.DisplayMember = "TenBai";
            }
            else
            {
                cboBTK.DataSource = null;
                cboBTK.Text = "";
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
            if (cboThon.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn thôn/bản!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBTK.Focus();
                return false;
            }
            if (cboBTK.SelectedIndex< 0)
            {
                MessageBox.Show("Chưa chọn bãi tập kết!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBTK.Focus();
                return false;
            }
            if (cboLoaiDat.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn loại đất!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboLoaiDat.Focus();
                return false;
            }
            if (cboLoaiGiong.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn loại giống!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboLoaiGiong.Focus();
                return false;
            }
            if (cboKieuTrong.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn kiểu trồng - lưu gốc!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboKieuTrong.Focus();
                return false;
            }
            if (nDienTich.Value<=0)
            {
                MessageBox.Show("Số liệu diện tích chưa đúng!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nDienTich.Focus();
                return false;
            }
            if (dtNgayTrong.IsNullDate==true)
            {
                MessageBox.Show("Ngày trồng chưa hợp lệ!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgayTrong.Focus();
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
       
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (Verify())
            {
                if (MessageBox.Show("Bạn chắc chắn sửa dữ liệu như lựa chọn", "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                try
                {
                    Entities.clsImportDienTich oSua = new Entities.clsImportDienTich(_ID);
                    oSua.Load(null, null);
                    oSua.HopDongID = _HOPDONGID;
                    oSua.BaiTapKetID = long.Parse(cboBTK.SelectedValue.ToString());
                    oSua.ThonID = long.Parse(cboThon.SelectedValue.ToString());
                    oSua.LoaiGiongID = long.Parse(cboLoaiGiong.SelectedValue.ToString());
                    oSua.LoaiDatID = long.Parse(cboLoaiDat.SelectedValue.ToString());
                    oSua.KieuTrongID = long.Parse(cboKieuTrong.SelectedValue.ToString());
                    oSua.MaHopDong = MaHD;
                    oSua.HoTen = txtHoTen.Text;
                    oSua.TenBai = cboBTK.Text;
                    oSua.TenThon = cboThon.Text;
                    oSua.KieuTrong = cboKieuTrong.Text;
                    oSua.LoaiDat = cboLoaiDat.Text;
                    oSua.LoaiGiong = cboLoaiGiong.Text;
                    oSua.DienTich = nDienTich.Value;
                    oSua.SanLuongDuKien = nSLDK.Value;
                    oSua.NgayTrong = dtNgayTrong.Value;
                    oSua.MaHopDong = txtMaThuaRuong.Text;
                    oSua.TenXaMoi = txtTenXa.Text;
                    oSua.TenThonMoi = txtTenThon.Text;
                    oSua.Save(null, null);
                    OK = 1;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi khi sửa\n"+ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
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

        

        private void nSoLuongVatTu_ValueChanged(object sender, EventArgs e)
        {
            if (nDienTich.Value > nDienTich.Maximum)
            {
                nDienTich.Value = nDienTich.Maximum;
            }
        }

        private void frm_SuaNhapDienTich_Load(object sender, EventArgs e)
        {
            lblCBDB.Text = TenCBDB;
            LoadCBThon(_CBNVID);
            LoadKieuTrong();
            LoadLoaiDat();
            LoadLoaiGiong();
            MDSolution.Entities.clsImportDienTich oTR = new Entities.clsImportDienTich(_ID);
            oTR.Load(null, null);
            if (oTR.HopDongID > 0)
            {
                txtHoTen.Text = oTR.HoTen;
                txtMaHD.Text = oTR.MaHopDong;
                _HOPDONGID = oTR.HopDongID;
                MaHD = oTR.MaHopDong;
            }
            if (oTR.ThonID > 0)
            {
                cboThon.SelectedValue = oTR.ThonID;
            }
            if (oTR.BaiTapKetID > 0)
            {
                cboBTK.SelectedValue = oTR.BaiTapKetID;
            }
            if (oTR.LoaiDatID > 0)
            {
                cboLoaiDat.SelectedValue = oTR.LoaiDatID;
            }
            if (oTR.LoaiGiongID > 0)
            {
                cboLoaiGiong.SelectedValue = oTR.LoaiGiongID;
            }
            if (oTR.KieuTrongID > 0)
            {
                cboKieuTrong.SelectedValue = oTR.KieuTrongID;
            }
            if (oTR.DienTich > 0)
            {
                nDienTich.Value = oTR.DienTich/10000;
            }
            else
            {
                nDienTich.Value = 0;
            }
            if (oTR.SanLuongDuKien > 0)
            {
                nSLDK.Value = oTR.SanLuongDuKien;
            }
            else
            {
                nSLDK.Value = 0;
            }
            if (oTR.NgayTrong == DateTime.MinValue)
            {
                dtNgayTrong.Value = DateTime.MinValue;
                dtNgayTrong.IsNullDate = true;
            }
            else
            {
                dtNgayTrong.Value = oTR.NgayTrong;
            }
        }

        private void cmdThemNongHo_Click(object sender, EventArgs e)
        {
            MDForms.CapVatTu.frm_ChonHD frm = new MDForms.CapVatTu.frm_ChonHD(_CBNVID);
            frm.ShowDialog();
            if (frm.OK > 0)
            {
                txtHoTen.Text = frm.HoTen;
                _HOPDONGID = frm.HopDongID;
                MaHD = frm.MaHopDong;
                txtMaHD.Text = MaHD;
            }
        }


    
     }
}
