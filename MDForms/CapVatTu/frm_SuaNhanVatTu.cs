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
    public partial class frm_SuaNhanVatTu : Form
    {
        public int OK = 0;
        public long _ID = -1;
        public long _CBNVID = -1;
        public long _HOPDONGID = -1;
        public string MaHD = "";
        public frm_SuaNhanVatTu()
        {
            InitializeComponent();
        }
        public frm_SuaNhanVatTu(long CBNV,long IDNhanVT)//Sửa
        {
            InitializeComponent();
            _CBNVID = CBNV;
            _ID = IDNhanVT;
         
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
            if (cboThon.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn thôn/bản!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBTKVatTu.Focus();
                return false;
            }
            if (cboBTKVatTu.SelectedIndex< 0)
            {
                MessageBox.Show("Chưa chọn bãi tập kết!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBTKVatTu.Focus();
                return false;
            }
            if (nSoLuongVatTu.Value<=0)
            {
                MessageBox.Show("Số lượng vật tư nhận chưa đúng!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nSoLuongVatTu.Focus();
                return false;
            }
            if (dtNgayNhan.Value.Year<(NgayHienHanh().Year-1))
            {
                MessageBox.Show("Ngày nhận vật tư chưa hợp lệ!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgayNhan.Focus();
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
            //if (_IDNHANVATTU < 0)
            //{
            //    string sql = "Select HopDongID from tbl_NhanVatTu Where HopDongID=" + HopDongID.ToString() + " AND XuatVatTuID=" + _IDXUATVATU.ToString();
            //    string ret = DBModule.ExecuteQueryForOneResult(sql, null, null);
            //    if (string.IsNullOrEmpty(ret))
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //       return false;
            //    }
            //}
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
                if (MessageBox.Show("Bạn chắc chắn sửa dữ liệu như lựa chọn", "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                Entities.clsCVT oSua= new Entities.clsCVT(_ID);
                oSua.Load(null, null);
                oSua.HopDongID = _HOPDONGID;
                oSua.BaiTapKetID = long.Parse(cboBTKVatTu.SelectedValue.ToString());
                oSua.ThonID = long.Parse(cboThon.SelectedValue.ToString());
                oSua.MaHopDong = MaHD;
                oSua.HoTen = txtHoTen.Text;
                oSua.TenBai = cboBTKVatTu.Text;
                oSua.TenThon = cboThon.Text;
                oSua.SoLuong = nSoLuongVatTu.Value;
                oSua.NgayNhan = dtNgayNhan.Value;
                oSua.Save(null, null);
                OK = 1;
                this.Close();
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
                MaHD = frm.MaHopDong;
                txtMaHD.Text = MaHD;
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

        private void frm_SuaNhanVatTu_Load(object sender, EventArgs e)
        {
            LoadCBThon(_CBNVID);
            MDSolution.Entities.clsCVT oCVT = new Entities.clsCVT(_ID);
            oCVT.Load(null, null);
            if (oCVT.HopDongID > 0)
            {
                txtHoTen.Text = oCVT.HoTen;
                txtMaHD.Text = oCVT.MaHopDong;
                _HOPDONGID = oCVT.HopDongID;
                MaHD = oCVT.MaHopDong;
            }
            if (oCVT.ThonID > 0)
            {
                cboThon.SelectedValue = oCVT.ThonID;
            }
            if (oCVT.BaiTapKetID > 0)
            {
                cboBTKVatTu.SelectedValue = oCVT.BaiTapKetID;
            }
           
            if (oCVT.SoLuong > 0)
            {
                nSoLuongVatTu.Value = oCVT.SoLuong;
            }
            else
            {
                nSoLuongVatTu.Value = 0;
            }
            dtNgayNhan.Value = oCVT.NgayNhan;
        }

        private void nSoLuongVatTu_ValueChanged(object sender, EventArgs e)
        {
            if (nSoLuongVatTu.Value > nSoLuongVatTu.Maximum)
            {
                nSoLuongVatTu.Value = nSoLuongVatTu.Maximum;
            }
        }


    
     }
}
