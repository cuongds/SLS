using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SLSCCSEntities;
using Janus.Windows.GridEX;

namespace MDSolution.MDForms.HoTro
{
    public partial class frm_ChietTinhCongNo_NhapTienTraNo : Form
    {
        public string ID;
        public string HopDongID;
        public string HDDTID;
        public DateTime NgayQuaHanTinhLai;
        public void Calc_TienPhaiTra(DateTime NgayTra)
        {
            if (HopDongID == null) return;
            decimal TongTienPhaiTra = 0;
            //TT_TruNoDauTu tt = new TT_TruNoDauTu(decimal.MaxValue, NgayTra.Date, NgayQuaHanTinhLai.Date, int.Parse(HopDongID), 0, "", "", HDDTID, 1, 0, (int)MDSolutionApp.VuTrongID);
            //TT_TruNoDauTu objTruNo = new TT_TruNoDauTu(decimal.MaxValue,NgayTra.Date, NgayQuaHanTinhLai, NongHoID, NhapMiaID, SoMaCan, Ma_TenNongHo, HDDauTuID.ToString(), NhapTienTraNo, int.Parse(ChietTinhID), (int)MDSolutionApp.VuTrongID);
            //string srest = tt.TruNoDauTu(false);
            foreach (GridEXRow dr in grvTienDauTu.GetRows())
            {
                if (dr.RowType == RowType.Record)
                {
                    decimal GocTinhLai = (decimal)dr.Cells["SoTien"].Value - (decimal)dr.Cells["TraGoc"].Value;
                    DateTime NgayTinhLai = (DateTime)dr.Cells["NgayBatDauTinhLai"].Value;
                    int DanhMucDauTuID = (int)dr.Cells["DanhMucDauTuID"].Value;
                    int ID = (int)dr.Cells["ID"].Value;
                    //TT_TruNoDauTu tt = new TT_TruNoDauTu(decimal.MaxValue,NgayTra.Date, NgayQuaHanTinhLai.Date, int.Parse(HopDongID), 0, "", "", HDDTID, 1, 0, (int)MDSolutionApp.VuTrongID);
                    //TT_DauTu objdt = tt.GetDauTuWithLai(ID);//DBModule.MDEnterpriseData.ExecuteSprocAccessor<TT_DauTu>("ThanhToan_DauTu_By_ID ", ID).ToList()[0];
                    //List<Lai_ChiTiet> lst = new List<Lai_ChiTiet>();
                    //if (objdt == null)
                    //{
                    //    //  return "Khoản đầu tư của [" + this.Ma_Ten_NongHo + "] chưa áp dụng thông báo lãi.";
                    //    MessageBox.Show("Khoản đầu tư [" + objdt.DanhMucDT + "] chưa áp dụng thông báo lãi.");
                    //    return;
                    //}
                    //decimal TienLai = 0;// TinhLai(GocTinhLai, NgayTinhLai,NgayTra, DanhMucDauTuID);
                    //if (objdt.PPTTinhLai == "LAITRENKHOANVAY")

                    //    TienLai = tt.TinhLai_TrenKhoanVay(objdt, lst);
                    //else
                    //    TienLai = tt.TinhLai_TrenKhoanTra(objdt.DuNoGoc, objdt.NgayDT,NgayTra.Date, objdt, lst, true);

                    dr.BeginEdit();
                    //dr.Cells["TienLaiPhatSinh"].Value = tt.lstDauTu.Where(x => x.ID == ID).FirstOrDefault().objTruNoDT.TienLai;
                    //ConLai=SoTien-TraGoc+TienLaiPhatSinh+TienLaiChotNoCu
                    decimal TienPhaiTra = (decimal)dr.Cells["SoTien"].Value - (decimal)dr.Cells["TraGoc"].Value + (decimal)dr.Cells["TienLaiPhatSinh"].Value + (decimal)dr.Cells["TienLaiChotNoCu"].Value;
                    TongTienPhaiTra += TienPhaiTra;
                    dr.Cells["ConLai"].Value = TienPhaiTra;
                    dr.EndEdit();
                }
            }
           
            txtTienCanTra.Text = TongTienPhaiTra.ToString("###");
            txtTienNhap.Text = TongTienPhaiTra.ToString("###");
            
        }

        public frm_ChietTinhCongNo_NhapTienTraNo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMaHoChiTiet_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            decimal tientru = 0;
            decimal tienCanTr = 0;
            decimal.TryParse(txtTienNhap.Text,out tientru);
            decimal.TryParse(txtTienCanTra.Text, out tienCanTr);
            if (tientru > 0 && tientru<=tienCanTr)
            {
                string sql = @"INSERT INTO [tbl_NhapTien]
                                                       ([NgayGioTiepNhan]
                                                       ,[TaiID]
                                                       ,[SoTai]
                                                       ,[NgoaiCong]
                                                       ,[DuongThuy]
                                                       ,[TrongVung]
                                                       ,[HDDT_ID]
                                                       ,[LoaiHDDT_ID]
                                                       ,[HopDongID]
                                                       ,[CHD_ID]
                                                       ,[NgayGioCan]
                                                       ,[SoKeo]
                                                       ,[TongTrongLuong]
                                                       ,[TienMia]
                                                       ,[TyLeTapVat]
                                                       ,[TrongLuongMiaSach]
                                                       ,[DaThanhToan]
                                                       ,[MiaChay]
                                                       ,[VuTrongID])
                                                 VALUES
                                                       (getdate()
                                                       ,0
                                                       ,N'{1}'
                                                       ,NULL
                                                       ,NULL
                                                       ,NULL
                                                       ,{2}
                                                       ,NULL
                                                       ,{3}
                                                       ,NULL
                                                       ,{0}
                                                       ,NULL
                                                       ,0
                                                       ,{4}
                                                       ,0
                                                       ,0
                                                       ,0
                                                       ,0
                                                       ,{5})";

                DBModule.ExecuteNonQuery(string.Format(sql, DBModule.RefineDatetime(dtNgayTra.Value.Date.AddHours(12)), txtPhieuThu.Text, this.HDDTID, this.HopDongID, tientru, MDSolutionApp.VuTrongID), null, null);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ.", "Thông báo");
                txtTienNhap.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void txtTienTru_TextChanged(object sender, EventArgs e)
        {
            decimal tientru = 0;
            decimal.TryParse(txtTienNhap.Text, out tientru);
            decimal TienCo = 0;
            decimal.TryParse(txtTienCanTra.Text,out TienCo);
            if (tientru == 0 || tientru > TienCo)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ.", "Thông báo");
                txtTienNhap.Focus();
            }
            else
            {
                
            }
        }

        private void txtHDDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoChiTiet_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_ChietTinhCongNo_NhapTienTraNo_Load(object sender, EventArgs e)
        {
            
        }

        private void dtNgayTra_ValueChanged(object sender, EventArgs e)
        {
            Calc_TienPhaiTra(dtNgayTra.Value);
        }


    }
}
