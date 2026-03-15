using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms.ThanhToan2016
{
    public partial class frm_NhapMiaGiong : Form
    {
        public const string strMiaGiongNgon = "Mía ngọn";
        public const string strMiaGiongCaCay = "Mía cả cây";
        public frm_NhapMiaGiong()
        {
            InitializeComponent();
        }
        private long HopDongID;
        public frm_NhapMiaGiong(long ID)
        {
            InitializeComponent();
            HopDongID = ID;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public class PhieuNhapMia
        {
            public string MaPhieu { get; set; }
            public decimal MiaNgon_SoLuong { get; set; }
            public decimal MiaNgon_DonGia { get; set; }
            public decimal MiaNgon_TienMia { get; set; }
            public decimal MiaCC_SoLuong { get; set; }
            public decimal MiaCC_DonGia { get; set; }
            public decimal MiaCC_TienMia { get; set; }
        }
        PhieuNhapMia getValue()
        {
            PhieuNhapMia p = new PhieuNhapMia();
            p.MaPhieu = txtSoCT.Text;
            decimal _MiaNgon_SoLuong = 0;
            decimal _MiaNgon_DonGia = 0;
            decimal _MiaNgon_TienMia = 0;
            decimal _MiaCC_SoLuong = 0;
            decimal _MiaCC_DonGia = 0;
            decimal _MiaCC_TienMia = 0;
            if (!decimal.TryParse(txtMiaNgonSL.Text, out _MiaNgon_SoLuong)) txtMiaNgonSL.Focus();
            if (!decimal.TryParse(txtMiaNgonDonGia.Text, out _MiaNgon_DonGia)) txtMiaNgonDonGia.Focus();
            _MiaNgon_TienMia = _MiaNgon_SoLuong * _MiaNgon_DonGia;
            if (!decimal.TryParse(txtMiaCCSL.Text, out _MiaCC_SoLuong)) txtMiaCCSL.Focus();
            if (!decimal.TryParse(txtMiaCCDonGia.Text, out _MiaCC_DonGia)) txtMiaCCDonGia.Focus();
            _MiaCC_TienMia = _MiaCC_DonGia * _MiaCC_SoLuong;

            if (_MiaNgon_TienMia > 0)
            {
                p.MiaNgon_DonGia = _MiaNgon_DonGia;
                p.MiaNgon_SoLuong = _MiaNgon_SoLuong;
                p.MiaNgon_TienMia = _MiaNgon_TienMia;
            }
            if (_MiaCC_TienMia > 0)
            {
                p.MiaCC_DonGia = _MiaCC_DonGia;
                p.MiaCC_SoLuong = _MiaCC_SoLuong;
                p.MiaCC_TienMia = _MiaCC_TienMia;
            }
            return p;
        }
        void SetValue(PhieuNhapMia p)
        {
            txtMiaNgonDonGia.Text = p.MiaNgon_DonGia.ToString();
            txtMiaNgonSL.Text = p.MiaNgon_SoLuong.ToString();
            txtMiaNgonThanhTien.Text = p.MiaNgon_TienMia.ToString();

            txtMiaNgonDonGia.Text = p.MiaNgon_DonGia.ToString();
            txtMiaNgonSL.Text = p.MiaNgon_SoLuong.ToString();
            txtMiaNgonThanhTien.Text = p.MiaNgon_TienMia.ToString();
            txtSoCT.Text = p.MaPhieu;

        }
        public void LoadMiaGiong()
        {
            txtMiaNgonSL.Text = "";
            txtMiaNgonDonGia.Text = "";
            txtMiaNgonThanhTien.Text = "";
            txtMiaCCSL.Text = "";
            txtMiaCCDonGia.Text = "";
            txtMiaCCThanhTien.Text = "";
            if (!string.IsNullOrEmpty(txtSoCT.Text))
            {
                string sql = "select *,isnull(DaThanhToan,0) as DaTT from tbl_NhapMia_Giong where Ma_PhieuNhap=N'" + txtSoCT.Text + "' ";
                DataSet ds = DBModule.ExecuteQuery(sql, null, null);
                try
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        btnSave.Enabled = dr["DaTT"].ToString() == "0";
                        btnHuy.Enabled = dr["DaTT"].ToString() == "0";
                        if (dr["LoaiGiong"].ToString() == strMiaGiongNgon)
                        {
                            txtMiaNgonSL.Text = dr["SoLuong"].ToString();
                            txtMiaNgonDonGia.Text = dr["DonGia"].ToString();
                            txtMiaNgonThanhTien.Text = dr["ThanhTien"].ToString();
                        }
                        else if (dr["LoaiGiong"].ToString() == strMiaGiongCaCay)
                        {
                            txtMiaCCSL.Text = dr["SoLuong"].ToString();
                            txtMiaCCDonGia.Text = dr["DonGia"].ToString();
                            txtMiaCCThanhTien.Text = dr["ThanhTien"].ToString();
                        }
                    }
                    TinhTong();
                }
                catch (Exception ex)
                {


                }
            }          
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            PhieuNhapMia p = getValue();
            if (p.MiaCC_TienMia + p.MiaNgon_TienMia == 0)
            {
                MessageBox.Show("Dữ liệu không hợp lệ, vui lòng nhập lại.");
                return;
            }
            try
            {

                bool isAdd = false;
                if (string.IsNullOrEmpty(p.MaPhieu))
                {//1.Chưa có phiếu 
                    // Tạo mã phiếu:
                    isAdd = true;
                    string stt = DBModule.ExecuteQueryForOneResult("Get_MaPhieu 'tbl_NhapMia_Giong', " + MDSolutionApp.VuTrongID, null, null);

                    DateTime dt = (DateTime)DBModule.ExecuteQuery("Select NgayBatDau from tbl_VuTrong where ID=" + MDSolutionApp.VuTrongID, null, null).Tables[0].Rows[0][0];

                    string strMaPhieu = "NMG" + dt.Year.ToString("###") + ".";
                    strMaPhieu = strMaPhieu + stt.PadLeft(6, '0');
                    txtSoCT.Text = strMaPhieu;
                }
                else
                {
                    //Xóa nội dung phiếu:
                    string sqldelete = @"Delete tbl_NhapMia_Giong where Ma_PhieuNhap=N'{0}' and VuTrongID={1} and HopDongID={2}";
                    DBModule.ExecuteNonQuery(string.Format(sqldelete, txtSoCT.Text, MDSolutionApp.VuTrongID, HopDongID), null, null);

                }
                string sql = @"INSERT INTO tbl_NhapMia_Giong
                                   ([VuTrongID]
                                   ,[HopDongID]
                                   ,[SoLuong]
                                   ,[DonGia]
                                   ,[ThanhTien]
                                   ,[LoaiGiong]
                                   ,[Ma_PhieuNhap]
                                   ,[Ngay_Lap]
                                   ,[DaThanhToan]," + (isAdd ? "CreatedBy,DateAdd" : "ModifyBy,DataModify") + @")
                             VALUES                                   
                                   ({0}
                                   ,{1}
                                   ,{2}
                                   ,{3}
                                   ,{4}
                                   ,N'{5}'
                                   ,N'{6}'
                                   ,'{7}'
                                   ,0,{8},getdate());";
                if (p.MiaCC_TienMia > 0) DBModule.ExecuteNonQuery(string.Format(sql, MDSolutionApp.VuTrongID, HopDongID,
                        p.MiaCC_SoLuong, p.MiaCC_DonGia, p.MiaCC_TienMia, strMiaGiongCaCay, txtSoCT.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), MDSolutionApp.User.ID), null, null);
                if (p.MiaNgon_TienMia > 0) DBModule.ExecuteNonQuery(string.Format(sql, MDSolutionApp.VuTrongID, HopDongID,
                    p.MiaNgon_SoLuong, p.MiaNgon_DonGia, p.MiaNgon_TienMia, strMiaGiongNgon, txtSoCT.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), MDSolutionApp.User.ID), null, null);
                MessageBox.Show("Cập nhật thành công");
                LoadMiaGiong();
                LoadGrdDauTu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi cập nhật dữ liệu. Chi tiết:" + ex.Message);
            }
        }
        private DataSet gridDataSourceGridEX2;
        public void LoadGrdDauTu()
        {

            this.grdDauTu.SetDataBinding(null, "");
            //string strSQL = "SELECT a.*, ISNULL(b.SoTien,0) as TienHoTro FROM tbl_DauTu as a LEFT JOIN tbl_HoTro as b ON b.DauTuID = a.[ID] Where a.HopDongID=" + this.grdHopDong.GetValue("ID").ToString() + " AND a.VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
            string strSQL = "SELECT * FROM V2016_NhapMiaGiong_DauTu  Where SoChungTu=N'" + txtSoCT.Text + "'";
            this.gridDataSourceGridEX2 = DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridDataSourceGridEX2.Tables.Count > 0)
            {
                this.grdDauTu.SetDataBinding(this.gridDataSourceGridEX2.Tables[0], "");

            }

        }

        private void txtMiaNgonSL_TextChanged(object sender, EventArgs e)
        {
            TinhTong();
        }
        public void TinhTong()
        {
            decimal _MiaNgon_SoLuong = 0;
            decimal _MiaNgon_DonGia = 0;
            decimal _MiaNgon_TienMia = 0;
            decimal _MiaCC_SoLuong = 0;
            decimal _MiaCC_DonGia = 0;
            decimal _MiaCC_TienMia = 0;
            decimal.TryParse(txtMiaNgonSL.Text, out _MiaNgon_SoLuong);
            decimal.TryParse(txtMiaNgonDonGia.Text, out _MiaNgon_DonGia);
            _MiaNgon_TienMia = _MiaNgon_SoLuong * _MiaNgon_DonGia;
            decimal.TryParse(txtMiaCCSL.Text, out _MiaCC_SoLuong);
            decimal.TryParse(txtMiaCCDonGia.Text, out _MiaCC_DonGia);
            _MiaCC_TienMia = _MiaCC_DonGia * _MiaCC_SoLuong;
            txtMiaCCThanhTien.Text = _MiaCC_TienMia.ToString();
            txtMiaNgonThanhTien.Text = _MiaNgon_TienMia.ToString();
            txtTongSL.Text = (_MiaNgon_SoLuong + _MiaCC_SoLuong).ToString();
            txtTongTT.Text = (_MiaNgon_TienMia + _MiaCC_TienMia).ToString();
        }
        private void uiButtonThem_Click(object sender, EventArgs e)
        {
            //MDDataSetForms.frmDauTu frm = new MDSolution.MDDataSetForms.frmDauTu(HopDongID, txtSoCT.Text, long.Parse(txtTongTT.Text));
            //frm.ngayDauTuCalendarCombo.Value = DateTime.Now;

            frm_NhapDauTuTuMiaGiong frm = new frm_NhapDauTuTuMiaGiong(HopDongID, txtSoCT.Text, long.Parse(txtTongTT.Text), true);
            frm.ShowDialog();
            LoadGrdDauTu();
        }
        private bool Chek_SuaDLGoc()
        {
            string _DotThanhToan = "";
            string _NhapTienTraNoID = "";

            try
            {
                string strSQL = "SELECT tbl_DauTu.DonViCungUngVatTuID, tbl_DanhMucDauTu.LoaiHinhDauTuID"
                    + " FROM  tbl_DanhMucDauTu INNER JOIN "
                    + " tbl_DauTu ON tbl_DanhMucDauTu.ID = tbl_DauTu.DanhMucDauTuID Where tbl_DauTu.ID=" + grdDauTu.GetValue("ID").ToString();
                DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);

                string donvi;
                string LoaiDauTu;
                donvi = ds.Tables[0].Rows[0]["DonViCungUngVatTuID"].ToString();
                LoaiDauTu = ds.Tables[0].Rows[0]["LoaiHinhDauTuID"].ToString();

                long ThuTu;
                if (donvi == "1")
                {
                    ThuTu = 1;
                }
                else
                {
                    switch (LoaiDauTu)
                    {
                        case "1":
                            ThuTu = 7;
                            break;
                        case "4":
                            ThuTu = 8;
                            break;
                        case "2":
                            ThuTu = 9;
                            break;
                        case "5":
                            ThuTu = 10;
                            break;
                        case "3":
                            ThuTu = 11;
                            break;
                        default:
                            ThuTu = 11;
                            break;
                    }

                }
                if (ThuTu != 10 && ThuTu != 11)
                    strSQL = "Select ID, DotThanhToan, NhapTienTraNoID From tbl_TruNo_DauTu Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString() + " and DauTuID=" + grdDauTu.GetValue("ID").ToString() + " and substring(LoaiHinhTruNo,1,1) ='" + ThuTu.ToString() + "'";
                else
                    strSQL = "Select ID, DotThanhToan, NhapTienTraNoID From tbl_TruNo_DauTu Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString() + " and DauTuID=" + grdDauTu.GetValue("ID").ToString() + " and substring(LoaiHinhTruNo,1,2) ='" + ThuTu.ToString() + "'";

                DataSet ds1 = DBModule.ExecuteQuery(strSQL, null, null);
                if (ds1.Tables[0].Rows.Count == 0) return true;
                if (ds1.Tables[0].Rows[0].IsNull("ID")) // khoan dau tu chua dc load vao
                {
                    return true;
                }
                else
                {
                    if (ds1.Tables[0].Rows[0].IsNull("DotThanhToan")) // co khoan dtu va dot thanh toan = null
                    {
                        strSQL = "sp_ThanhToan_SuaDLGoc " + MDSolutionApp.VuTrongID.ToString() + "," + grdDauTu.GetValue("ID").ToString() + ",'" + ThuTu.ToString() + "'";
                        DBModule.ExecuteNoneBackup(strSQL, null, null);
                        return true;
                    }
                    else // khoan dau tu da dc thanh toan
                    {
                        _DotThanhToan = ds1.Tables[0].Rows[0]["DotThanhToan"].ToString();
                        if (!ds1.Tables[0].Rows[0].IsNull("NhapTienTraNoID"))
                        {
                            _NhapTienTraNoID = ds1.Tables[0].Rows[0]["NhapTienTraNoID"].ToString();
                            string sql = "Select NgayTra,SoTien From tbl_NhapTienTraNo Where ID=" + _NhapTienTraNoID;
                            ds = DBModule.ExecuteQuery(sql, null, null);
                            DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["NgayTra"].ToString());
                            string sotien = ds.Tables[0].Rows[0]["SoTien"].ToString();
                            MessageBox.Show("Khoản đầu tư này đã được trừ nợ bằng nhập tiền trả nợ. \nNgày nhập tiền: " + dt.ToString("dd/MM/yyyy") + " \n Số tiền: " + sotien, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Khoản đầu tư này đã được thanh toán trong đợt " + _DotThanhToan + ".\nNếu muốn sửa phải thực hiện huỷ đợt thanh toán thứ " + _DotThanhToan, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void uiButtonSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdDauTu.GetValue("ID").ToString() != "")
                {
                    if (Chek_SuaDLGoc())
                    { }
                    else
                    {
                        return;
                    }
                    // object objid = grdDauTu.GetValue("ID");
                    //frm_NhapDauTu frm = new frm_NhapDauTu(long.Parse(this.grdDauTu.GetValue("ID").ToString()));
                    //frm.ShowDialog();

                    frm_NhapDauTuTuMiaGiong frm = new frm_NhapDauTuTuMiaGiong(long.Parse(this.grdDauTu.GetValue("ID").ToString()));
                    //MDDataSetForms.frmDauTu frm = new MDSolution.MDDataSetForms.frmDauTu(long.Parse(this.grdDauTu.GetValue("ID").ToString()), false);
                    frm.ShowDialog();
                    LoadGrdDauTu();

                }
                else { MessageBox.Show("Bạn phải chọn một mục đầu tư để sửa", "Thông báo"); }
            }
            catch { MessageBox.Show("Bạn phải chọn một mục đầu tư để sửa", "Thông báo"); }
        }

        private void uiButtonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string message;
                message = String.Format("Bạn muốn xóa bản ghi này?");

                if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //DataRowView dr = (DataRowView).Row.DataRow;
                    if (Chek_SuaDLGoc())
                    { }
                    else
                    {
                        return;
                    }
                    clsDauTu oDT = new clsDauTu(long.Parse(this.grdDauTu.GetValue("ID").ToString()));
                    oDT.Delete(null, null);

                    LoadGrdDauTu();
                }
                else
                {
                    LoadGrdDauTu();
                    //e.Cancel = true;
                }
            }
            catch { MessageBox.Show("Bạn phải chọn một mục đầu tư để xóa", "Thông báo"); }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hủy phiếu này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (DBModule.ExecuteQueryForOneResult("select count(*) FROM dbo.tbl_DauTu  Where SoChungTu=N'" + txtSoCT.Text + "'", null, null) != "0")
                {
                    MessageBox.Show("Vẫn còn khoản đầu tư trong phiếu, không thể xóa.");
                    return;
                }
                string sqldelete = @"Delete [tbl_NhapMia_Giong] where Ma_PhieuNhap=N'{0}' and VuTrongID={1} and HopDongID={2}";
                DBModule.ExecuteNonQuery(string.Format(sqldelete, txtSoCT.Text, MDSolutionApp.VuTrongID, HopDongID), null, null);
            }
        }

        private void frm_NhapMiaGiong_Load(object sender, EventArgs e)
        {

        }
    }
}
