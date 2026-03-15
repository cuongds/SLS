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
    public partial class frm_ThemSuaUngVanChuyen : Form
    {
        public long OK = 0;
        public long UVTID = -1;
        public long HopDongVanChuyenID = -1;
        public long XeVanChuyenID = -1;
        private long NhapHoanUng = 0;
        public frm_ThemSuaUngVanChuyen()
        {
            InitializeComponent();
        }
        public frm_ThemSuaUngVanChuyen(long HDVC_ID, long Xe_ID, string SoXe, DateTime NgayUng)
        {
            InitializeComponent();
            grXe.Text = grXe.Text + SoXe;
            LoadCBLoaiVatTu();
            HopDongVanChuyenID = HDVC_ID;
            XeVanChuyenID = Xe_ID;
            txtSoCT.Text = GetSoCT();
            //string sqlNgay = "Select GetDate()";
            //DateTime dt = Convert.ToDateTime(DBModule.ExecuteQueryForOneResult(sqlNgay, null, null));
            dtNgayUng.Value = NgayUng;
        }
        public frm_ThemSuaUngVanChuyen(long UVT_ID, string SoXe)
        {
            InitializeComponent();
            grXe.Text = grXe.Text + SoXe;
            LoadCBLoaiVatTu();
            UVTID = UVT_ID;
            lblUngVT.Text = "SỬA ỨNG VẬT TƯ VẬN CHUYỂN";
            clsUngVatTuVanChuyen oUVTSua = new clsUngVatTuVanChuyen(UVT_ID);
            oUVTSua.Load(null, null);
            HopDongVanChuyenID = oUVTSua.HopDongVanChuyenID;
            XeVanChuyenID = oUVTSua.XeID;
            cboLoaiVT.SelectedValue = oUVTSua.VatTuID;
            dtNgayUng.Value = oUVTSua.NgayUng;
            txtSoCT.Text = oUVTSua.SoChungTu;
            nSoLuong.Value = oUVTSua.SoLuong;
            nDonGia.Value = oUVTSua.DonGia;
            nSoTien.Value = oUVTSua.SoTien;
        }
        private string GetSoCT()
        {
            string sql = "Select ISNULL(MAX(CAST(SoChungTu AS INT)),0)+1 FROM tbl_UngVatTuVanChuyen Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
            return DBModule.ExecuteQueryForOneResult(sql, null, null);
        }
        private void LoadCBLoaiVatTu()
        {
            string sql = "Select * From tbl_VatTuVanChuyen";
            DataSet comboSoure = DBModule.ExecuteQuery(sql, null, null);
            //DataRow dr = comboSoure.Tables[0].NewRow();
            //dr["ID"] = -1;
            //dr["Ten"] = "-------Chọn loại vật tư ứng------";
            //comboSoure.Tables[0].Rows.InsertAt(dr, 0);
            if (comboSoure.Tables[0].Rows.Count > 0)
            {
                cboLoaiVT.DataSource = comboSoure.Tables[0];
                cboLoaiVT.ValueMember = "ID";
                cboLoaiVT.DisplayMember = "Ten";
            }
            else
            {
                cboLoaiVT.DataSource = null;
            }
        }
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool Valid_Form()
        {
            if (cboLoaiVT.SelectedIndex < 0)
            {
                MessageBox.Show("Loại vật tư ứng chưa được chọn!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboLoaiVT.Focus();
                return false;
            }
            else
            {
                NhapHoanUng = long.Parse(cboLoaiVT.SelectedValue.ToString());
            }
            if (nSoTien.Value < 0 && NhapHoanUng != 629931)
            {
                MessageBox.Show("Số tiền ứng không hợp lệ!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nSoTien.Value = 0;
                nSoTien.Focus();
                return false;
            }
            return true;
        }
        private bool CheckSoChungTu(string SoChungTu)
        { 
        bool check=false;
        string sql = "Select ID from tbl_UngVatTuVanChuyen where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " AND SoChungTu="+ SoChungTu;
        try
        {
          string getID =  DBModule.ExecuteQueryForOneResult(sql,null,null);
          if (!string.IsNullOrEmpty(getID))
          {
              if (Int16.Parse(getID) > 0)
              {
                  check = false;
              }
          }
          else {
              check = true;
          }
        }
        catch{
            check = false;
        }
        return check;
        }
            

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (Valid_Form())
            {
                try
                {
                    if (UVTID < 0)//Thêm mới phiếu
                    {
                        clsUngVatTuVanChuyen oUVT = new clsUngVatTuVanChuyen();
                        oUVT.HopDongVanChuyenID = HopDongVanChuyenID;
                        oUVT.XeID = XeVanChuyenID;
                        oUVT.VatTuID = long.Parse(cboLoaiVT.SelectedValue.ToString());
                        oUVT.NgayUng = dtNgayUng.Value;
                        oUVT.SoChungTu = txtSoCT.Text;
                        oUVT.SoLuong = nSoLuong.Value;
                        oUVT.DonGia = nDonGia.Value;
                        oUVT.SoTien = nSoTien.Value;
                        oUVT.BangChu = rtbBangChu.Text;
                        oUVT.VuTrongID = MDSolutionApp.VuTrongID;
                        if (CheckSoChungTu(txtSoCT.Text))
                        {
                            oUVT.Save(null, null);
                            UVTID = oUVT.ID;
                            MessageBox.Show("Đã thêm thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            OK = 1;
                        }
                        else {
                            MessageBox.Show("Trùng số phiếu bạn làm lại!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else//Sửa phiếu ứng
                    {
                        clsUngVatTuVanChuyen oUVT = new clsUngVatTuVanChuyen(UVTID);
                        oUVT.Load(null, null);
                        oUVT.HopDongVanChuyenID = HopDongVanChuyenID;
                        oUVT.XeID = XeVanChuyenID;
                        oUVT.VatTuID = long.Parse(cboLoaiVT.SelectedValue.ToString());
                        oUVT.NgayUng = dtNgayUng.Value;
                        oUVT.SoChungTu = txtSoCT.Text;
                        oUVT.SoLuong = nSoLuong.Value;
                        oUVT.DonGia = nDonGia.Value;
                        oUVT.SoTien = nSoTien.Value;
                        oUVT.BangChu = rtbBangChu.Text;
                        oUVT.Save(null, null);
                        MessageBox.Show("Đã cập nhật thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OK = 1;
                    }
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void nSoTien_ValueChanged(object sender, EventArgs e)
        {
            if (nSoTien.Value > nSoTien.Maximum)
            {
                nSoTien.Value = nSoTien.Maximum;
            }
            double ST = Convert.ToDouble(nSoTien.Value);
            rtbBangChu.Text = Utils.DocSo(ST);
        }

        private void nSoLuong_ValueChanged(object sender, EventArgs e)
        {
            if (NhapHoanUng != 629931) nSoTien.Value = nDonGia.Value * nSoLuong.Value;
        }

        private void nDonGia_ValueChanged(object sender, EventArgs e)
        {
            if (NhapHoanUng != 629931) nSoTien.Value = nDonGia.Value * nSoLuong.Value;
        }

    }
}
