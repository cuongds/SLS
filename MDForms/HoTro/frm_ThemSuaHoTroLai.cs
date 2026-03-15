using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDSolution;
namespace MDSolution.MDForms.HoTro
{
    public partial class frm_ThemSuaHoTroLai : Form
    {
        public long OK = 0;
        public long HTLID = -1;
        public decimal LaiSuat =-1;
        public long HopDongID = -1;
        public decimal SoTienDauTu = -1;
        private decimal ST = -1;
        public long _ID_DauTu;
        public frm_ThemSuaHoTroLai()
        {
            InitializeComponent();
        }
        public frm_ThemSuaHoTroLai(long ID_DauTu, long ID_HopDong)
        {
            InitializeComponent();
            //grHTL.Text = grHTL.Text + SoXe;
            Load_DauTu(ID_DauTu);     
            LoadCBLoaiVatTu();
            string sqlNgay = "Select GetDate()";
            DateTime dt = Convert.ToDateTime(DBModule.ExecuteQueryForOneResult(sqlNgay, null, null));
            dtNgayUng.Value = dt;
        }
        public frm_ThemSuaHoTroLai(long ID_DauTu)
        {
            InitializeComponent();
                   
            //grHTL.Text = grHTL.Text;
            LoadCBLoaiVatTu();
            HTLID = ID_DauTu;
            lblUngVT.Text = "SỬA HỖ TRỢ LÃI";
            clsHoTroLai oHTLSua = new clsHoTroLai(ID_DauTu);
            oHTLSua.Load(null, null);
            //HopDongVanChuyenID = oHTLSua.HopDongID;
            cboLoaiHT.SelectedValue = oHTLSua.HoTroTheoLoaiHinhID;
            dtNgayUng.Value = oHTLSua.NgayLamHoTro;          
            HopDongID = oHTLSua.HopDongID;
            nSoTien.Value = Convert.ToDecimal(oHTLSua.SoTienNhap);
            nSoTienCon.Value = oHTLSua.SoTien;
            long ID = oHTLSua.DauTuID;
            Load_DauTu(ID);
           
        }
        //private string GetSoCT()
        //{
        //    string sql = "Select ISNULL(MAX(CAST(SoChungTu AS INT)),0)+1 FROM tbl_UngVatTuVanChuyen Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
        //    return DBModule.ExecuteQueryForOneResult(sql, null, null);
        //}
        private void LoadCBLoaiVatTu()
        {
            string sql = "SELECT * FROM tbl_DanhMucHoTro where TuongUngDanhMucDauTu=0";
            DataSet comboSoure = DBModule.ExecuteQuery(sql, null, null);
            if (comboSoure.Tables[0].Rows.Count > 0)
            {
                cboLoaiHT.DataSource = comboSoure.Tables[0];
                cboLoaiHT.ValueMember = "ID";
                cboLoaiHT.DisplayMember = "Ten";
            }
            else
            {
                cboLoaiHT.DataSource = null;
            }
        }
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool Valid_Form()
        {
            if (cboLoaiHT.SelectedIndex < 0)
            {
                MessageBox.Show("Loại hỗ trợ chưa được chọn!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboLoaiHT.Focus();
                return false;
            }
            if (nSoTien.Value < 0)
            {
                MessageBox.Show("Số tiền hỗ trợ không hợp lệ!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nSoTien.Value = 0;
                nSoTien.Focus();
                return false;
            }
          
            if (LaiSuat <= 0)
            {
                MessageBox.Show("Lãi suât không hợp lệ!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);               
                return false;
            }


            if (SoTienDauTu < nSoTien.Value)
            {
                MessageBox.Show("Số tiền lớn hơn số tiền đầu tư!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;  
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (Valid_Form())
            {
                try
                {
                    if (HTLID < 0)//Thêm mới phiếu
                    {
                        clsHoTroLai oHTL = new clsHoTroLai();
                        oHTL.HopDongID = HopDongID;
                        oHTL.HoTroTheoLoaiHinhID = long.Parse(cboLoaiHT.SelectedValue.ToString());
                        oHTL.NgayLamHoTro = dtNgayUng.Value;
                        oHTL.SoTien = nSoTienCon.Value;
                        oHTL.SoTienNhap = nSoTien.Value;
                        oHTL.VuTrongID = MDSolutionApp.VuTrongID;
                        oHTL.DauTuID = _ID_DauTu;
                        oHTL.Save(null, null);
                        HTLID = oHTL.ID;
                        MessageBox.Show("Đã thêm thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OK = 1;
                    }
                    else//Sửa phiếu ứng
                    {
                        clsHoTroLai oHTL = new clsHoTroLai(HTLID);
                        oHTL.Load(null, null);
                        //oHTL.HopDongID = HopDongID;
                        oHTL.HoTroTheoLoaiHinhID = long.Parse(cboLoaiHT.SelectedValue.ToString());
                        oHTL.HopDongID = HopDongID;
                        oHTL.NgayLamHoTro = dtNgayUng.Value;
                        oHTL.SoTien = nSoTienCon.Value;
                        oHTL.SoTienNhap = nSoTien.Value;
                        oHTL.Save(null, null);
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
        private void Load_DauTu(long ID_Dautu)
        {
            try
            {
                clsDauTu oDT = new clsDauTu(ID_Dautu);
                oDT.Load(null, null);
                lbl_tiendautu.Text = oDT.SoTien.ToString();
                SoTienDauTu = oDT.SoTien;
                lbl_ngaydautu.Text = oDT.NgayDauTu.ToString("dd/MM/yyyy");
                lbl_laisuat.Text = oDT.LaiSuat.ToString();
                _ID_DauTu = oDT.ID;
                LaiSuat = oDT.LaiSuat;
                long HDID = oDT.HopDongID;
                long LHHTID = oDT.DanhMucDauTuID;
                clsHopDong oHD = new clsHopDong(HDID);
                oHD.Load(null, null);
                HopDongID = oHD.ID;
                lbl_HoTen.Text = oHD.HoTen;
                lbl_mahopdong.Text = oHD.MaHopDong;
                clsDanhMucDauTu oDMDT = new clsDanhMucDauTu(LHHTID);
                oDMDT.Load(null, null);
                lbl_loaidautu.Text = oDMDT.Ten;
            }
            catch
            {
                MessageBox.Show("Không tìm thấy thông tin của hợp đồng đầu tư");
            }
        }

        private void nSoTien_ValueChanged(object sender, EventArgs e)
        {
            //if (nSoTienCon.Value > nSoTienCon.Maximum)
            //{
            //    nSoTienCon.Value = nSoTienCon.Maximum;
            //}
            ST = Convert.ToDecimal(nSoTien.Value);
            nSoTienCon.Value =SoTienDauTu - ST;

        }
    }
}
