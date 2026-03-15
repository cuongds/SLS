using Janus.Windows.EditControls;
using MDSolution;
using MDSolution.MDDialoge;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace MDSolution.MDForms.UngTien
{
    public partial class frm_KeHoachNhapUngVanChuyen : Form
    {
        public long OK = 0;
        public long _HopDongID = -1;
        private decimal Sotien = -1;
        public long Status = -1;
        public long IDUngTien = -1;
        public frm_KeHoachNhapUngVanChuyen()
        {
            InitializeComponent();

        }
        public frm_KeHoachNhapUngVanChuyen(long HopDong_ID, bool Add = true)//Nhập mới
        {
            InitializeComponent();
            clsHopDongVanChuyen objHD = new clsHopDongVanChuyen(HopDong_ID);            
            objHD.Load(null, null);
            txt_MaHopDong.Text = objHD.MaHopDong.ToString();
            lblHoTen.Text = objHD.TenChuHopDong.ToString();
            lblDiaChi.Text = objHD.DiaChi.ToString();
            lblDT.Text = objHD.DienThoai.ToString();
            LoadCBLoaiVatTu();
            txt_MaHopDong.Focus();

        }
        public frm_KeHoachNhapUngVanChuyen(DateTime NgayUng)//Nhập mới
        {
            InitializeComponent();            
            LoadCBLoaiVatTu();
            dtNgayUng.Value = NgayUng;
            txt_MaHopDong.Focus();            
        }

        public frm_KeHoachNhapUngVanChuyen(long UngTienID, long status = 1)//Sửa
        {
            Status = status;
            IDUngTien = UngTienID;
            InitializeComponent();
            LoadCBLoaiVatTu();
            clsKeHoachUngVanChuyen objKHUT = new clsKeHoachUngVanChuyen(UngTienID);
            objKHUT.Load(UngTienID,null,null);            
            txt_TenDot.Text = objKHUT.TenDot.ToString();
            dtNgayUng.Text = objKHUT.NgayUng.ToShortDateString();
            nSoTien.Value = objKHUT.Sotien;            
            cboLoaiVT.SelectedValue = objKHUT.LoaiVatTuID;
            clsHopDongVanChuyen objHD = new clsHopDongVanChuyen(objKHUT.HopDongID);
            objHD.Load(null, null);
            _HopDongID = objHD.ID;
            txt_MaHopDong.Text = objHD.MaHopDong.ToString();
            lblHoTen.Text = objHD.TenChuHopDong.ToString();
            lblDT.Text = objHD.DienThoai.ToString();
            lblDiaChi.Text = objHD.DiaChi.ToString();
            btnSave.Text = "Lưu sửa";
            txt_MaHopDong.Focus();
        }

        private string GetSoCT()
        {
            string sql = "Select ISNULL(MAX(CAST(SoChungTu AS INT)),0)+1 FROM tbl_KeHoachUngVanChuyen Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
            return DBModule.ExecuteQueryForOneResult(sql, null, null);
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Valid_Form())
            {
                if (Status == -1)//Nếu là nhập mới
                {
                    try
                    {
                        clsKeHoachUngVanChuyen objKHUT = new clsKeHoachUngVanChuyen();
                        objKHUT.NgayUng = dtNgayUng.Value;
                        objKHUT.DateAdd = DateTime.Now;
                        objKHUT.VuTrongID = MDSolutionApp.VuTrongID;
                        objKHUT.SoLuong = nSoLuong.Value;
                        objKHUT.DonGia = nDonGia.Value;
                        objKHUT.Sotien = nSoTien.Value;
                        objKHUT.TenDot = txt_TenDot.Text.Trim();
                        objKHUT.HopDongID = _HopDongID;
                        objKHUT.SoChungTu = GetSoCT();
                        objKHUT.CreatedByUserID = MDSolutionApp.User.ID;
                        objKHUT.Status = 1;                        
                        objKHUT.LoaiVatTuID = long.Parse(cboLoaiVT.SelectedValue.ToString());
                        double ST = Convert.ToDouble(nSoTien.Value);
                        objKHUT.BangChu = Utils.DocSo(ST);
                        objKHUT.GhiChu = txtGhiChu.Text;
                        objKHUT.Save(null, null);
                        MessageBox.Show("Bạn đã thêm mới thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OK = 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi thêm mới!\n" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else
                {
                    try
                    {
                        clsKeHoachUngVanChuyen objKHUVCS = new clsKeHoachUngVanChuyen(IDUngTien);
                        objKHUVCS.Load(IDUngTien, null, null);
                        objKHUVCS.HopDongID = _HopDongID;                        
                        objKHUVCS.NgayUng = dtNgayUng.Value;
                        objKHUVCS.VuTrongID = MDSolutionApp.VuTrongID;
                        objKHUVCS.DonGia = nDonGia.Value;
                        objKHUVCS.Sotien = nSoTien.Value;
                        objKHUVCS.Sotien = nSoTien.Value;
                        objKHUVCS.TenDot = txt_TenDot.Text.Trim();                        
                        objKHUVCS.DateModify = DateTime.Now;                        
                        objKHUVCS.LoaiVatTuID = long.Parse(cboLoaiVT.SelectedValue.ToString());
                        double ST = Convert.ToDouble(nSoTien.Value);
                        objKHUVCS.BangChu = Utils.DocSo(ST);
                        objKHUVCS.GhiChu = txtGhiChu.Text;
                        objKHUVCS.Save(null, null);
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
        private bool Valid_Form()
        {
            return true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txt_SoTien_Leave(object sender, EventArgs e)
        {
            if (!Decimal.TryParse(nSoTien.Text.Replace(",", ""), out Sotien)) ;
            Sotien = (long)(Sotien);
            nSoTien.Text = Sotien.ToString("### ### ###");
        }

        private void LoadHopDong(string MaHopDong)
        {
            clsHopDongVanChuyen objHD = new clsHopDongVanChuyen();
            objHD.Load(MaHopDong, null, null);
            if (objHD.ID > 0)
            {
                _HopDongID = objHD.ID;
                lblHoTen.Text = objHD.TenChuHopDong.ToString();
                lblDT.Text = objHD.DienThoai.ToString();
                lblDiaChi.Text = objHD.DiaChi.ToString();
                clsXeVanChuyen objXe = new clsXeVanChuyen();
                objXe.Load(_HopDongID,null,null);
                lbl_SoXe.Text = objXe.SoXe;
                lbl_TenLaiXe.Text = objXe.TenLaiXe;
            }
            else
            {
                MessageBox.Show("Mã hợp đồng không tồn tại!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                _HopDongID = -1;
                lblHoTen.Text = "";
                lblDT.Text = "";
                lblDiaChi.Text = "";
                txt_MaHopDong.Focus();
            }
        }

        private void txt_MaHopDong_KeyDown(object sender, KeyEventArgs e)
        {
           //if (e.KeyCode == Keys.Enter)
           // {
           //     txt_MaHopDong.Focus();
           //     LoadHopDong(txt_MaHopDong.Text.Trim());
           // }
        }

        private void txt_MaHopDong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                LoadHopDong(txt_MaHopDong.Text.Trim());
                txt_MaHopDong.Focus();
            }
        }
        private void LoadCBLoaiVatTu()
        {
            string sql = "Select * From tbl_VatTuVanChuyen";
            DataSet comboSoure = DBModule.ExecuteQuery(sql, null, null);           
            if (comboSoure.Tables[0].Rows.Count > 0)
            {
                cboLoaiVT.DataSource = comboSoure.Tables[0];
                cboLoaiVT.ValueMember = "ID";
                cboLoaiVT.DisplayMember = "Ten";
                cboLoaiVT.SelectedValue = 5;
            }
            else
            {
                cboLoaiVT.DataSource = null;
            }
        }

        private void pnCommand_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
