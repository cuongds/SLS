using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDSolution;
using MDSolution.MDDialoge;

namespace MDSolution
{
    public partial class frm_NhapHoTro : Form
    {
        public long OK = 0;
        public long _HopDongID = -1;
        public long HopDongID = -1;
        public long _IDDauTu = -1;
        public long _LoaiHinhID = -1;
        public long _DanhMucDTID = -1;
        public long _IDHoTro = -1;
        private float Soluong = -1;
        private float Dongia = -1;
        private decimal Sotien = -1;
        private decimal SoTienDautu = -1;
        private decimal SoTienKhauTru = -1;
        public string DauTuID = "";


        public frm_NhapHoTro()
        {
            InitializeComponent();

        }
        //private void Load_Cb_DanhMucDauTu()
        //{
        //    string sql = "Select ID,Ten from tbl_DanhMucDauTu";
        //    DataSet ds = DBModule.ExecuteQuery(sql, null, null);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        cboLoaiHinhDauTu.DataSource = ds.Tables[0];
        //        cboLoaiHinhDauTu.ValueMember = "ID";
        //        cboLoaiHinhDauTu.DisplayMember = "Ten";
        //    }
        //    else
        //    {
        //        cboLoaiHinhDauTu.DataSource = null;
        //    }
        //}
        //private void Load_Cb_LoaiHinhDauTu()
        //{
        //    string sql = "Select ID,Ten from tbl_LoaiHinhDauTu";
        //    DataSet ds = DBModule.ExecuteQuery(sql, null, null);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        cboLoaiHinhDauTu.DataSource = ds.Tables[0];
        //        cboLoaiHinhDauTu.ValueMember = "ID";
        //        cboLoaiHinhDauTu.DisplayMember = "Ten";
        //    }
        //    else
        //    {
        //        cboLoaiHinhDauTu.DataSource = null;
        //    }
        //}


        private void Load_Cb_DanhMucHoTro()
        {
            string sql = "Select ID,Ten from tbl_danhmuchotro";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboHoTro.DataSource = ds.Tables[0];
                cboHoTro.ValueMember = "ID";
                cboHoTro.DisplayMember = "Ten";
            }
            else
            {
                cboHoTro.DataSource = null;
            }
        }


        //private void Load_Cb_LoaiHinhDauTu(long LoaiHinhDT)
        //{
        //    string sql = "Select ID,Ten from tbl_LoaiHinhDauTu Where ID= " + LoaiHinhDT.ToString();
        //    DataSet ds = DBModule.ExecuteQuery(sql, null, null);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        cboLoaiHinhDauTu.DataSource = ds.Tables[0];
        //        cboLoaiHinhDauTu.ValueMember = "ID";
        //        cboLoaiHinhDauTu.DisplayMember = "Ten";
        //    }
        //    else
        //    {
        //        cboLoaiHinhDauTu.DataSource = null;
        //    }
        //}
        private void Load_Cb_DanhMucDauTu(long LoaiHinhID)
        {
            string sql = "Select ID,Ten from tbl_DanhMucDauTu Where ID=" + LoaiHinhID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboDanhMucDauTu.DataSource = ds.Tables[0];
                cboDanhMucDauTu.ValueMember = "ID";
                cboDanhMucDauTu.DisplayMember = "Ten";
            }
            else
            {
                cboDanhMucDauTu.DataSource = null;
            }
        }

        public frm_NhapHoTro(long HopDong_ID, long DauTu_ID, bool Add = true)//Nhập mới
        {
            InitializeComponent();

            Load_Cb_DanhMucHoTro();
            // đầu tư
            clsDauTu objDT = new clsDauTu(DauTu_ID);
            objDT.Load(null, null);
            SoTienDautu = objDT.SoTien;
            //Load_Cb_LoaiHinhDauTu();

            _LoaiHinhID = objDT.LoaiHinhDauTuID;
            //Load_Cb_LoaiHinhDauTu(_LoaiHinhID);
            //cboLoaiHinhDauTu.SelectedValue = objDT.LoaiHinhDauTuID;//Loại hình hỗ trợ

            _DanhMucDTID = objDT.DanhMucDauTuID;
            Load_Cb_DanhMucDauTu(_DanhMucDTID);
            cboDanhMucDauTu.SelectedValue = objDT.DanhMucDauTuID;//Danh mục hỗ trợ    

            lbl_Ngaydautu.Text = objDT.NgayDauTu.ToString("dd/MM/yyyy");
            lbl_Tiendautu.Text = objDT.SoTien.ToString("###,###,###,###");


            //checed_HTC.Checked = true;
            //checed_HTK.Checked = true;
            if (checed_HTK.Checked == false)
            {
                //cboLoaiHinhDauTu.Enabled = false;
                cboDanhMucDauTu.Enabled = false;
            }
            else
            {
                //cboLoaiHinhDauTu.Enabled = false;
                cboDanhMucDauTu.Enabled = false;

            }

            // hợp đồng
            _HopDongID = objDT.HopDongID;
            HopDongID = objDT.HopDongID; ;

            clsHopDong objHD = new clsHopDong(_HopDongID);
            objHD.Load(null, null);
            lblMaHopDong.Text = objHD.MaHopDong;
            lblHoTen.Text = objHD.HoTen;
            clsThon objThon = new clsThon(objHD.ThonID);
            objThon.Load(null, null);
            lbl_thon.Text = objThon.Ten;
            clsXa objXa = new clsXa(objThon.XaID);
            objXa.Load(null, null);
            lbl_xa.Text = objXa.Ten;
            clsHuyen objHuyen = new clsHuyen(objXa.HuyenID);
            objHuyen.Load(null, null);
            lbl_huyen.Text = objHuyen.Ten;
            // cập nhật lại đâu tư
            _IDDauTu = DauTu_ID;
        }
        public frm_NhapHoTro(long HopDong_ID, bool Add = true)//Nhập mới
        {
            InitializeComponent();
            _HopDongID = HopDong_ID;
            //Load_Cb_LoaiHinhDauTu();
            clsHopDong objHD = new clsHopDong(_HopDongID);
            objHD.Load(null, null);
            lblMaHopDong.Text = objHD.MaHopDong;
            lblHoTen.Text = objHD.HoTen;
        }
        public frm_NhapHoTro(long HoTroID)//Sửa
        {
            InitializeComponent();

            gb_dautu.Visible = false;
            lblTitle.Text = "TRỪ HỖ TRỢ CHO ĐẦU TƯ";
            btnSave.Text = "Lưu sửa";
            _IDHoTro = HoTroID;
            clsHoTro objHT = new clsHoTro(_IDHoTro);
            objHT.Load(null, null);
            _HopDongID = objHT.HopDongID;
            HopDongID = objHT.HopDongID;

            SoTienDautu = objHT.KhauTru;

            _LoaiHinhID = objHT.HoTroTheoLoaiHinhID;
            //Load_Cb_LoaiHinhDauTu(_LoaiHinhID);
            //cboLoaiHinhDauTu.SelectedValue = objHT.HoTroTheoLoaiHinhID;//Loại hình hỗ trợ

            _DanhMucDTID = objHT.DanhMucHoTroID;
            Load_Cb_DanhMucDauTu(_DanhMucDTID);
            cboDanhMucDauTu.SelectedValue = objHT.DanhMucHoTroID;//Danh mục hỗ trợ    

            clsHopDong objHD = new clsHopDong(_HopDongID);
            objHD.Load(null, null);
            lblMaHopDong.Text = objHD.MaHopDong;//Mã hợp đồng
            lblHoTen.Text = objHD.HoTen;//Họ tên
            txtGhiChu.Text = objHT.GhiChu;//Ghi chú
            //txtGhiChuSua.Text = objDT.NoteModify;//Ghi chú sửa            
            nDonGia.Text = objHT.DonGia.ToString();//Load đơn giá
            nSoLuong.Text = objHT.SoLuong.ToString();//Load số lượng
            nSoTien.Text = objHT.SoTien.ToString();//Số tiền
            dtNgayDauTu.Value = objHT.NgayLamHoTro;//Ngày hỗ trợ
            lbl_Tiendautu.Text = objHT.KhauTru.ToString("###,###,###,###");

            Load_Cb_DanhMucHoTro();
            cboHoTro.SelectedValue = objHT.HoTroTheoLoaiHinhID;//Loại hình hỗ trợ



            /// SoTienKhauTru = SoTienDautu - Sotien;
            /// 
            // xa huyen tinh
            clsThuaRuong objTR = new clsThuaRuong(objHT.ThuaRuongID);
            objTR.Load(null, null);
            _HopDongID = objTR.HopDongID;
            lbl_DienTich.Text = (objTR.DienTich / 10000).ToString();
            clsThon objThon = new clsThon(objTR.ThonID);
            objThon.Load(null, null);
            lbl_thon.Text = objThon.Ten;
            clsXa objXa = new clsXa(objThon.XaID);
            objXa.Load(null, null);
            lbl_xa.Text = objXa.Ten;
            clsHuyen objHuyen = new clsHuyen(objXa.HuyenID);
            objHuyen.Load(null, null);
            lbl_huyen.Text = objHuyen.Ten;


            // cập nhật lại đầu tư.
            _IDDauTu = objHT.DauTuID;
            clsDauTu objDTHT = new clsDauTu(_IDDauTu);
            objDTHT.Load(null, null);
            lbl_Ngaydautu.Text = objDTHT.NgayDauTu.ToString("dd/MM/yyyy");
            //lbl_SoDu.Text = (SoTienDautu - objDTHT.SoTien).ToString("###,###,###,###");
            lbl_SoDu.Text = objDTHT.SoTien.ToString("###,###,###,###");
            SoTienKhauTru = (SoTienDautu - objDTHT.SoTien);


            //objDTHT.Save(null, null);

        }

        private void Get_KhauTruDauTu_ByID(string DauTuID)
        {
            if (DauTuID != "")
            {
                clsDauTu objDauTu = new clsDauTu(long.Parse(DauTuID));

                objDauTu.Load(null, null);
                if (objDauTu.ID > 0)
                {
                    grb_hotro.Visible = true;

                    //Load_Cb_DanhMucHoTro();
                    //cboHoTro.SelectedValue = objHT.HoTroTheoLoaiHinhID;//Loại hình hỗ trợ

                    //Load_Cb_DanhMucDauTu();
                    //cboDanhMucDauTu.SelectedValue = objDauTu.DanhMucDauTuID;

                    //Load_Cb_LoaiHinhDauTu();
                    //cboLoaiHinhDauTu.SelectedValue = objDauTu.LoaiHinhDauTuID;

                    //cboLoaiHinhDauTu.Text=objDauTu.LoaiHinhDauTuID;
                    //cboDanhMucDauTu.Text= objDauTu.DanhMucDauTuID;
                    lbl_Tiendautu.Text = objDauTu.SoTien.ToString();
                    lbl_Ngaydautu.Text = objDauTu.NgayDauTu.ToString("dd/MM/yyyy");
                    lbl_SoDu.Text = "";


                    //txtHoTenKHVC.Text = clsComFunctions.HoTen_Format(objHDVC.TenChuHopDong);
                    //txtMaKhachVC.Text = objHDVC.ID.ToString();
                    //txtHopDongVC.Text = objHDVC.MaHopDong;
                    //load_cbo_xe("0", objHDVC.ID.ToString());
                }
                else
                {
                    grb_hotro.Visible = false;
                }

            }
        }

        private string Gen_SCT()
        {
            string stt = DBModule.ExecuteQueryForOneResult("Get_MaPhieu 'tbl_DauTu', " + MDSolutionApp.VuTrongID.ToString(), null, null);
            DateTime dt = (DateTime)DBModule.ExecuteQuery("Select NgayBatDau from tbl_VuTrong where ID=" + MDSolutionApp.VuTrongID.ToString(), null, null).Tables[0].Rows[0][0];
            string strMaPhieu = "DT" + dt.Year.ToString("###") + ".";
            strMaPhieu = strMaPhieu + stt.PadLeft(6, '0');
            return strMaPhieu;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Valid_Form())
            {
                if (_IDHoTro < 0)//Nếu là nhập mới
                {
                    try
                    {

                        clsHoTro oHT = new clsHoTro();
                        oHT.HopDongID = _HopDongID;
                        //oHT.HoTroTheoLoaiHinhID = long.Parse(cboLoaiHinhDauTu.SelectedValue.ToString());
                        oHT.DanhMucHoTroID = long.Parse(cboDanhMucDauTu.SelectedValue.ToString());
                        oHT.DonGia = nDonGia.Value;
                        oHT.SoLuong = nSoLuong.Value;
                        oHT.SoTien = nSoTien.Value;

                        oHT.GhiChu = txtGhiChu.Text;
                        oHT.NgayLamHoTro = dtNgayDauTu.Value;
                        oHT.VuTrongID = MDSolutionApp.VuTrongID;
                        oHT.DauTuID = _IDDauTu;
                        oHT.KhauTru = (long)SoTienDautu;
                        oHT.HoTroID = long.Parse(cboHoTro.SelectedValue.ToString());
                        oHT.Save(null, null);
                        _IDHoTro = oHT.ID;
                        clsDauTu oDT = new clsDauTu(_IDDauTu);
                        oDT.Load(null, null);
                        if (checed_HTK.Checked == false)
                        {
                            oDT.SoTien = SoTienDautu - oHT.SoTien;
                            oDT.Save(null, null);
                        }
                        MessageBox.Show("Bạn đã thêm mới mục hỗ trợ thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OK = 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi thêm mới mục hỗ trợ!\n" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else
                {
                    try
                    {
                        clsHoTro oHT = new clsHoTro(_IDHoTro);
                        oHT.Load(null, null);
                        //lbl_Tiendautu.Text = oHT.KhauTru.ToString("###,###,###,###");
                        //lbl_Ngaydautu.Text = oHT.NgayLamHoTro.ToString();
                        //oHT.HoTroTheoLoaiHinhID = long.Parse(cboLoaiHinhDauTu.SelectedValue.ToString());
                        //oHT.DanhMucHoTroID = long.Parse(cboDanhMucDauTu.SelectedValue.ToString());
                        //oHT.DonGia = nDonGia.Value;
                        //oHT.SoLuong = nSoLuong.Value;




                        oHT.KhauTru = (long)oHT.SoTien;
                        oHT.DauTuID = long.Parse(DauTuID);

                        //if (checed_HTK.Checked == false)
                        //{
                        //    lbl_SoDu.Text = (oHT.KhauTru - oHT.SoTien).ToString("###,###,###,###");
                        //}
                        //else
                        //{

                        //}

                        oHT.GhiChu = txtGhiChu.Text;
                        //oHT.NgayLamHoTro = dtNgayDauTu.Value;
                        //oHT.VuTrongID = MDSolutionApp.VuTrongID;
                        //oHT.HoTroID = long.Parse(cboHoTro.SelectedValue.ToString());
                        //_IDHoTro = oHT.ID;
                        oHT.Save(null, null);
                        // cập nhật lại đầu tư
                        clsDauTu oDT = new clsDauTu(long.Parse(DauTuID));
                        oDT.Load(null, null);
                        oDT.SoTien = decimal.Parse(lbl_SoDu.Text.Replace(" ", ""));

                        //if (checed_HTK.Checked == false)
                        //{
                           
                        //}
                        //else
                        //{
                        //    oDT.SoTien = SoTienDautu;
                        //}
                        //oDT.SoTien = oHT.KhauTru - oHT.SoTien;
                        oDT.Save(null, null);



                        MessageBox.Show("Bạn đã sửa thông tin mục hỗ trợ thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private long CheckExist(string MaTR)
        {
            long exist = 0;
            try
            {
                exist = long.Parse(DBModule.ExecuteQueryForOneResult("Select Count(MaThuaRuong) From tbl_ThuaRuong Where MaThuaRuong=N'" + MaTR + "' And VuTrongID=" + MDSolutionApp.VuTrongID.ToString(), null, null).ToString());
            }
            catch
            {
                exist = 0;
            }
            return exist;

        }
        private bool Valid_Form()
        {

            //if (cboLoaiHinhDauTu.SelectedIndex < 0)
            //{
            //    MessageBox.Show("Bạn chưa chọn loại loại hình hỗ trợ!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cboLoaiHinhDauTu.Focus();
            //    return false;
            //}
            if (cboDanhMucDauTu.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn danh mục hỗ trợ!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboDanhMucDauTu.Focus();
                return false;
            }

            //if (cboHoTro.SelectedIndex < 0)
            //{
            //    MessageBox.Show("Bạn chưa chọn loại loại hình hỗ trợ!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cboLoaiHinhDauTu.Focus();
            //    return false;
            //}
            if (nSoTien.Value <= 0)
            {
                MessageBox.Show("Số tiền nhập chưa đúng!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nSoTien.Focus();
                return false;
            }

            return true;
        }


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtCMNDChuDat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }




        private void nDT_MouseClick(object sender, MouseEventArgs e)
        {
            //nLaiSuat.Select();
            //nLaiSuat.Select(0, nLaiSuat.Value.ToString().Length + nLaiSuat.DecimalPlaces + 2);
        }

        private void nDT_Enter(object sender, EventArgs e)
        {
            //nLaiSuat.Select();
            //nLaiSuat.Select(0, nLaiSuat.Value.ToString().Length + nLaiSuat.DecimalPlaces + 2);
        }

        private void nSanLuong_Enter(object sender, EventArgs e)
        {
            //txt_SoLuong.Select();
            //txt_SoLuong.Select(0, txt_SoLuong.Value.ToString().Length);
        }


        private void frm_NhapHoTro_Load(object sender, EventArgs e)
        {
            if (MDSolutionApp.User.ID != 1)
            {
                //clsComFunctions.checkControlsPermission(this, this.Name.ToString());              
            }
        }

        private void txt_SoLuong_ValueChanged(object sender, EventArgs e)
        {
            //if (txt_SoLuong.Value > txt_SoLuong.Maximum)
            //{
            //    txt_SoLuong.Value = txt_SoLuong.Maximum;
            //}
            //txt_SoTien.Value = txt_SoLuong.Value * txt_DonGia.Value;
        }

        private void txt_DonGia_ValueChanged(object sender, EventArgs e)
        {
            //if (txt_DonGia.Value > txt_DonGia.Maximum)
            //{
            //    txt_DonGia.Value = txt_DonGia.Maximum;
            //}
            //txt_SoTien.Value = txt_SoLuong.Value * txt_DonGia.Value;
        }

        private void txt_SoTien_ValueChanged(object sender, EventArgs e)
        {
            //if (txt_SoTien.Value > txt_SoTien.Maximum)
            //{
            //    txt_SoTien.Value = txt_SoTien.Maximum;
            //}
        }

        private void nLaiSuat_ValueChanged(object sender, EventArgs e)
        {
            //if (nLaiSuat.Value > nLaiSuat.Maximum)
            //{
            //    nLaiSuat.Value = nLaiSuat.Maximum;
            //}
        }

        private void cboLoaiHinhDauTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            long LoaiHinh = -1;
            try
            {
                //LoaiHinh = long.Parse(cboLoaiHinhDauTu.SelectedValue.ToString());
            }
            catch { }
            if (LoaiHinh > 0)
            {
                Load_Cb_DanhMucDauTu(LoaiHinh);
            }
        }

        private void txt_SoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_DonGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_SoTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_SoLuong_Leave(object sender, EventArgs e)
        {
            //if (!float.TryParse(txt_SoLuong.Text.Replace(" ", ""), out Soluong)) MessageBox.Show("Kiểm tra số lượng hỗ trợ bạn đã nhập vào");
            ////float.TryParse(txtSoluong.Text, out soluong);
            //Soluong = (long)(Soluong);
            //txt_SoLuong.Text = Soluong.ToString("### ### ###");
        }

        private void txt_DonGia_Leave(object sender, EventArgs e)
        {
            //if (!float.TryParse(txt_DonGia.Text.Replace(" ", ""), out Dongia)) MessageBox.Show("Kiểm tra đơn giá hỗ trợ bạn đã nhập vào");
            ////float.TryParse(txtSoluong.Text, out soluong);
            //Dongia = (long)(Dongia);
            //txt_DonGia.Text = Dongia.ToString("### ### ###");
        }

        private void txt_SoTien_Leave(object sender, EventArgs e)
        {


            if (!Decimal.TryParse(nSoTien.Text.Replace(" ", ""), out Sotien)) MessageBox.Show("Kiểm tra số tiền hỗ trợ bạn đã nhập vào");
            //float.TryParse(txtSoluong.Text, out soluong);
            Sotien = (long)(Sotien);
            nSoTien.Text = Sotien.ToString("### ### ###");
            if (checed_HTK.Checked == false)
            {
                SoTienKhauTru = SoTienDautu - Sotien;
                lbl_SoDu.Text = SoTienKhauTru.ToString("### ### ###");
            }
            else
            {

                lbl_SoDu.Text = SoTienDautu.ToString("### ### ###");
            }

        }



        private void nSoLuong_Enter(object sender, EventArgs e)
        {
            //nSoLuong.Select();
            //nSoLuong.Select(0, nSoLuong.Value.ToString().Length);
        }

        private void nSoLuong_ValueChanged(object sender, EventArgs e)
        {
            if (nSoLuong.Value > nSoLuong.Maximum)
            {
                nSoLuong.Value = nSoLuong.Maximum;
            }
            nSoTien.Value = nSoLuong.Value * nDonGia.Value;
        }

        private void nDonGia_ValueChanged(object sender, EventArgs e)
        {
            if (nDonGia.Value > nDonGia.Maximum)
            {
                nDonGia.Value = nDonGia.Maximum;
            }
            nSoTien.Value = nSoLuong.Value * nDonGia.Value;

        }

        private void nSoTien_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checed_HTK_CheckStateChanged(object sender, EventArgs e)
        {
            //if (checed_HTC.Checked == true)
            //{
            //    checed_HTK.Checked = false;
            //}
            //else
            //{
            //    checed_HTK.Checked = true;
            //    checed_HTC.Checked = false;
            //}
        }

        private void checed_HTC_CheckStateChanged(object sender, EventArgs e)
        {
            //if (checed_HTK.Checked == true)
            //{

            //    checed_HTC.Checked = false;
            //}
            //else
            //{
            //    checed_HTC.Checked = true;
            //    checed_HTK.Checked = false;
            //}
        }

        private void checed_HTC_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void checed_HTK_CheckedChanged(object sender, EventArgs e)
        {
            if (checed_HTK.Checked == false)
            {

                string sqlDTT = "select DauTuID from tbl_ThanhToanMia_TruNoDauTu where DauTuID =" + _IDDauTu;
                string kiemtra = DBModule.ExecuteQueryForOneResult(sqlDTT, null, null);
                if (kiemtra != "")
                {
                    MessageBox.Show("Khoản đầu tư này đã thanh toán không trừ được đâu tư");
                    checed_HTK.Checked = true;
                }


            }
        }

        private void btn_ChonTru_Click(object sender, EventArgs e)
        {

            dlgDauTuHo dlg = new dlgDauTuHo(HopDongID);
            dlg.passID = new dlgDauTuHo.PassID(GetHopDong_ID);
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                // lấy thông tin

                gb_dautu.Visible = true;
                Get_DauTu_ByID(DauTuID);
                lbl_duocchon.Visible = false;

                //Get_KhachVanChuyen_ByID(MaKVC);
                dlg.Dispose();
            }
            else
            {
                //MessageBox.Show("Cancel" + oHD.ID.ToString());
                dlg.Dispose();
            }
        }

        public void GetHopDong_ID(string value)
        {
            
            DauTuID = value;
        }

        public void Get_DauTu_ByID(string DauTuID)
        {
            clsDauTu objDTHT = new clsDauTu(long.Parse(DauTuID));
            objDTHT.Load(null, null);            
            _DanhMucDTID = objDTHT.DanhMucDauTuID;
            Load_Cb_DanhMucDauTu(_DanhMucDTID);
            cboDanhMucDauTu.SelectedValue = objDTHT.DanhMucDauTuID;//Danh mục hỗ trợ               
            lbl_Ngaydautu.Text = objDTHT.NgayDauTu.ToString("dd/MM/yyyy");
            lbl_Tiendautu.Text = objDTHT.SoTien.ToString("###,###,###,###");
            lbl_SoDu.Text = (objDTHT.SoTien - nSoTien.Value).ToString("###,###,###,###");
           
        }

    }
}
