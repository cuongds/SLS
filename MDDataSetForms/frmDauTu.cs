using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using MDSolution.MDForms.ThanhToan2016;

namespace MDSolution.MDDataSetForms
{
    public partial class frmDauTu : Form
    {
        public long _ID = 0;
        private int ID = 0;
        private string SoCT = "";
        private decimal MaxTongTien = 0;
        private Boolean IsAdd = true;
        public frmDauTu()
        {
            InitializeComponent();

        }
        public frmDauTu(long id, string _SoCT, decimal _max)
        {

            InitializeComponent();


            ID = int.Parse(id.ToString());
            SoCT = _SoCT;
            MaxTongTien = _max;
            uiComboBoxVuTrong.ReadOnly = false;
        }
        public frmDauTu(long id, Boolean IsAddNew, string hdID = "")
        {

            InitializeComponent();


            ID = int.Parse(id.ToString());
            IsAdd = IsAddNew;
            if (IsAdd)
            {
                // this.tbl_DauTuTableAdapter.Fill(this.dauTuDataSet.tbl_DauTu);
                //this.tbl_DauTuBindingSource.AddNew();              

            }
            else
            {
                this.tbl_DauTuTableAdapter.FillByID(this.dauTuDataSet.tbl_DauTu, ID);

                SetDataSource_CboChungLoaiDT();

                string SQL = "Select LoaiHinhDauTuID from tbl_DanhMucDauTu Where ID=(Select DanhMucDauTuID from tbl_DauTu Where ID =" + id.ToString() + ")";
                string str = DBModule.ExecuteQueryForOneResult(SQL, null, null);
                if (str != "")
                    uiCboChungLoaiDauTu.SelectedValue = long.Parse(str);
                loadNguoiThuaKe(hdID);
                //editBoxSoTien
            }

        }

        private void SetDataSource_CboChungLoaiDT()
        {
            string SQL = "Select ID,Ten from tbl_LoaiHinhDauTu";
            DataSet ds = DBModule.ExecuteQuery(SQL, null, null);
            uiCboChungLoaiDauTu.DataSource = ds.Tables[0];
            uiCboChungLoaiDauTu.DisplayMember = "Ten";
            uiCboChungLoaiDauTu.ValueMember = "ID";
        }

        private void frmDauTu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dauTuDataSet.tbl_LoaiHinhDauTu' table. You can move, or remove it, as needed.
            this.tbl_LoaiHinhDauTuTableAdapter.Fill(this.dauTuDataSet.tbl_LoaiHinhDauTu);


            // TODO: This line of code loads data into the 'dauTuDataSet.tbl_HopDong' table. You can move, or remove it, as needed.
            this.tbl_HopDongTableAdapter.Fill(this.dauTuDataSet.tbl_HopDong);
            // TODO: This line of code loads data into the 'dauTuDataSet.tbl_VuTrong' table. You can move, or remove it, as needed.
            this.tbl_VuTrongTableAdapter.Fill(this.dauTuDataSet.tbl_VuTrong);
            // TODO: This line of code loads data into the 'dauTuDataSet.tbl_DonViCungUngVatTu' table. You can move, or remove it, as needed.
            this.tbl_DonViCungUngVatTuTableAdapter.Fill(this.dauTuDataSet.tbl_DonViCungUngVatTu);
            // TODO: This line of code loads data into the 'dauTuDataSet.tbl_DanhMucDauTu' table. You can move, or remove it, as needed.
            this.tbl_DanhMucDauTuTableAdapter.Fill(this.dauTuDataSet.tbl_DanhMucDauTu);
            // TODO: This line of code loads data into the 'dauTuDataSet.tbl_DauTu' table. You can move, or remove it, as needed.

            TruyenDuLieu(true);
            if (IsAdd)
            {
                uiButtonNew_Click(null, null);
                HopDongUIDCombobox.Focus();
                if (!string.IsNullOrEmpty(SoCT))
                {
                    soChungTuTextBox.Text = SoCT;
                    soChungTuTextBox.ReadOnly = true;
                }
                if (MaxTongTien > 0)
                {
                    soTienTextBox.Text = MaxTongTien.ToString();
                }
                donViCungUngVatTuUIDComboBox.SelectedIndex = 0;
            }
            else
            {
                _ID = long.Parse(iDTextBox.Text);
                uiButtonEdit_Click(null, null);
                //donViCungUngVatTuUIDComboBox.Focus();

                //SetDataSource_CboChungLoaiDT();

                //string SQL = "Select LoaiHinhDauTuID from tbl_DanhMucDauTu Where ID=(Select DanhMucDauTuID from tbl_DauTu Where ID =" + ID.ToString() + ")";
                //string str = DBModule.ExecuteQueryForOneResult(SQL, null, null);
                //uiCboChungLoaiDauTu.SelectedValue = long.Parse(str);
            }

        }

        private void uiButtonClose_Click(object sender, EventArgs e)
        {
            this.tbl_DauTuBindingSource.EndEdit();
            this.tbl_DauTuBindingSource.CancelEdit();
            this.Hide();
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                uiButtonNew.Enabled = false;
                uiButtonEdit.Enabled = false;
                uiButtonSave.Enabled = true;
                uiButtonCancel.Enabled = true;
                uiButtonDelete.Enabled = true;
                uiGroupBox1.Enabled = true;
                uiGroupBox2.Enabled = true;

                if (IsAdd)
                {
                    this.tbl_DauTuBindingSource.CancelEdit();
                    uiButtonNew_Click(null, null);
                }
                else
                {
                    this.tbl_DauTuBindingSource.CancelEdit();
                    this.tbl_DauTuTableAdapter.FillByID(this.dauTuDataSet.tbl_DauTu, ID);
                }


            }
            catch
            {

            }
        }

        private void uiButtonDelete_Click(object sender, EventArgs e)
        {
            string message;
            if (iDTextBox.Text != "")
            {
                message = String.Format("Bạn có chắc chắn muốn xóa đầu tư này ?");

                if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.tbl_DauTuBindingSource.RemoveCurrent();
                    DoSave();
                    //this.tbl_DauTuTableAdapter.Fill(this.dauTuDataSet.tbl_DauTu);
                }
            }
            else
            {
                MessageBox.Show("Đầu tư này chưa có nên không xóa được !");

            }
        }
        private bool SaveDauTu()
        {
            try
            {
                float Test = 0;
                long test1 = 0;
                //uiComboBoxVuTrong.SelectedValue = MDSolutionApp.VuTrongID.ToString();
                if (string.IsNullOrEmpty(HopDongUIDCombobox.Text))
                {
                    MessageBox.Show("Bạn chưa chọn chủ hợp đồng", "Thông báo");
                    HopDongUIDCombobox.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(donViCungUngVatTuUIDComboBox.Text))
                {
                    MessageBox.Show("Bạn chưa chọn đơn vị ứng vật tư ");
                    donViCungUngVatTuUIDComboBox.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(danhMucDauTuUIDComboBox.Text))
                {
                    MessageBox.Show("Bạn chưa chọn danh mục đầu tư", "Thông báo");
                    danhMucDauTuUIDComboBox.Focus();
                    return false;
                }
                else
                {
                    if (danhMucDauTuUIDComboBox.SelectedValue == null)
                    {
                        MessageBox.Show("Bạn chưa chọn danh mục đầu tư", "Thông báo");
                        danhMucDauTuUIDComboBox.Focus();
                        return false;
                    }
                }
                if (!string.IsNullOrEmpty(editBoxDotDauTu.Text))
                {
                    if (!long.TryParse(editBoxDotDauTu.Text, out test1))
                    {
                        MessageBox.Show("Đợt đầu tư phải nhập kiểu số");
                        editBoxDotDauTu.Focus();
                        return false;
                    }
                }
                else
                {
                    editBoxDotDauTu.Text = "0";
                }
                if (string.IsNullOrEmpty(ngayDauTuCalendarCombo.Text))
                {
                    MessageBox.Show("Bạn cho biết ngày đầu tư?");
                    ngayDauTuCalendarCombo.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(editBoxSoTien.Text) && string.IsNullOrEmpty(editBoxSoLuong.Text) && string.IsNullOrEmpty(editBoxDonGia.Text)) throw new Exception("Bạn phải nhập số lượng và đơn giá hoặc số tiền ");

                if (string.IsNullOrEmpty(editBoxSoTien.Text) && string.IsNullOrEmpty(editBoxSoLuong.Text) && string.IsNullOrEmpty(editBoxDonGia.Text))
                {
                    MessageBox.Show("Bạn phải nhập số lượng và đơn giá hoặc số tiền", "Thông báo");
                    editBoxSoLuong.Focus();
                    return false;
                }



                if (string.IsNullOrEmpty(editBoxSoLuong.Text))
                {
                    editBoxSoLuong.Text = "0";
                }
                if (string.IsNullOrEmpty(editBoxDonGia.Text))
                {
                    editBoxDonGia.Text = "0";
                }

                if (string.IsNullOrEmpty(editBoxSoTien.Text))
                { editBoxSoTien.Text = "0"; }
                else
                {
                    if (!float.TryParse(editBoxSoTien.Text, out Test))
                    {
                        MessageBox.Show("Số tiền phải nhập kiểu số", "Thông báo");
                        editBoxSoTien.Focus();
                        return false;
                    }
                }

                if (string.IsNullOrEmpty(editBoxSoLuong.Text))
                { editBoxSoLuong.Text = "0"; }
                else
                {
                    if (!float.TryParse(editBoxSoLuong.Text, out Test))
                    {
                        MessageBox.Show("Số lượng phải nhập kiểu số", "Thông báo");
                        editBoxSoLuong.Focus();
                        return false;
                    }
                }
                if (float.Parse(editBoxSoLuong.Text) < 0)
                {
                    MessageBox.Show("Số lượng bạn nhập vào nhỏ hơn 0, kiểm tra lại", "Thông báo");
                    editBoxSoLuong.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(editBoxDonGia.Text))
                { editBoxDonGia.Text = "0"; }
                else
                {
                    if (!float.TryParse(editBoxDonGia.Text, out Test))
                    {
                        MessageBox.Show("Đơn giá phải nhập kiểu số", "Thông báo");
                        editBoxDonGia.Focus();
                        return false;
                    }
                }
                //if (float.Parse(editBoxSoTien.Text) <= 0 && float.Parse(editBoxSoLuong.Text) <= 0 && float.Parse(editBoxDonGia.Text) <= 0)
                //{
                //    MessageBox.Show("Bạn phải nhập số lượng và đơn giá hoặc số tiền", "Thông báo");
                //    editBoxSoLuong.Focus();
                //    return false;
                //}

                if (float.Parse(editBoxDonGia.Text) < 0)
                {
                    MessageBox.Show("Đơn giá bạn nhập vào nhỏ hơn 0, kiểm tra lại", "Thông báo");
                    editBoxDonGia.Focus();
                    return false;
                }

                //if (float.Parse(editBoxSoTien.Text) < 0)
                //{
                //    MessageBox.Show("Số tiền bạn nhập vào nhỏ hơn 0, kiểm tra lại", "Thông báo");
                //    editBoxSoTien.Focus();
                //    return false;
                //}
                if (float.Parse(editBoxSoTien.Text) == 0)
                {
                    MessageBox.Show("Số tiền bạn nhập vào nhỏ bằng 0, kiểm tra lại", "Thông báo");
                    editBoxSoTien.Focus();
                    return false;
                }
                //float tempSoTien = float.Parse(editBoxSoLuong.Text) * float.Parse(editBoxDonGia.Text);
                //if (tempSoTien > 0 && float.Parse(editBoxSoLuong.Text) >= 0 && float.Parse(editBoxSoTien.Text) != tempSoTien)
                //{
                //    if (MessageBox.Show("Số tiền " + editBoxSoTien.Text + " nhập vào khác với tổng số lượng * đơn giá : " + editBoxSoLuong.Text + "* " + editBoxDonGia.Text + "\n Bạn muốn lưu giá trị nào? Yes để lưu số tiền được nhập vào, no để lưu tổng tính toán.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //    {
                //        editBoxSoTien.Text = tempSoTien.ToString();
                //    }
                //}
                if (float.Parse(editBoxSoTien.Text) == 0)
                {
                    if (float.Parse(editBoxSoLuong.Text) == 0)
                    {
                        MessageBox.Show("Bạn phải nhập số tiền hoặc số lượng cùng đơn giá");
                        editBoxSoLuong.Focus();
                        return false;
                    }
                    else
                    {
                        if (float.Parse(editBoxDonGia.Text) == 0)
                        {
                            MessageBox.Show("Bạn phải nhập số tiền hoặc số lượng cùng đơn giá");
                            editBoxDonGia.Focus();
                            return false;
                        }
                    }
                }
                if (string.IsNullOrEmpty(editBoxLaiSuat.Text))
                { editBoxLaiSuat.Text = "0"; }
                else
                {
                    if (!float.TryParse(editBoxLaiSuat.Text, out Test))
                    {
                        MessageBox.Show("Lãi suất phải nhập kiểu số");
                        editBoxLaiSuat.Focus();
                        return false;
                    }
                }
                if ((float.Parse(editBoxLaiSuat.Text) < 0) || float.Parse(editBoxLaiSuat.Text) > 100)
                {
                    MessageBox.Show("Lãi suất phải lớn hơn không hoặc bằng không");
                    editBoxLaiSuat.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(ngayDauTuCalendarCombo.Text))
                {
                    MessageBox.Show("Bạn cho biết ngày đầu tư?");
                    ngayDauTuCalendarCombo.Focus();
                    return false;
                }

                if (!string.IsNullOrEmpty(editBoxDotDauTu.Text))
                {
                    if (!long.TryParse(editBoxDotDauTu.Text, out test1))
                    {
                        MessageBox.Show("Đợt đầu tư phải nhập kiểu số");
                        editBoxDotDauTu.Focus();
                        return false;
                    }
                }
                else
                {
                    editBoxDotDauTu.Text = "0";
                }

                TruyenDuLieu(false);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private Boolean DoSave()
        {
            try
            {
                this.tbl_DauTuBindingSource.EndEdit();

                //MDDataSet.HopDongTrongMiaDataSet.tbl_HopDongDataTable changes = (MDDataSet.HopDongTrongMiaDataSet.tbl_HopDongDataTable)this.hopDongTrongMiaDataSet.tbl_HopDong.GetChanges();
                //if (changes != null)
                //{
                //    //Fill default value;
                //    foreach (MDDataSet.HopDongTrongMiaDataSet.tbl_HopDongRow detail in changes.Rows)
                //    {
                //        DataRowState dstate = detail.RowState;
                //        if (detail.RowState == DataRowState.Deleted)
                //        {
                //        }
                //        else if (detail.RowState == DataRowState.Added)
                //        {
                //            //detail.ID = System.Convert.ToInt32(DBModule.GetNewID(typeof(clsHopDong), "tbl_HopDong", null, null));                        
                //            detail.MaHopDong = maHopDongEditBox.Text;
                //            detail.CreatedBy = System.Convert.ToInt32(MDSolutionAppN.iUser.ID);
                //            detail.ModifyBy = System.Convert.ToInt32(MDSolutionAppN.iUser.ID);
                //            detail.DataModify = DateTime.Now;
                //            detail.ModifyBy = System.Convert.ToInt32(MDSolutionAppN.iUser.ID);
                //        }
                //        else if (detail.RowState == DataRowState.Modified)
                //        {
                //            if (detail.MaHopDong != maHopDongEditBox.Text)
                //                detail.MaHopDong = maHopDongEditBox.Text;
                //            detail.DataModify = DateTime.Now;
                //            detail.ModifyBy = System.Convert.ToInt32(MDSolutionAppN.iUser.ID);
                //        }
                //    }
                this.tbl_DauTuTableAdapter.Update(this.dauTuDataSet.tbl_DauTu);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Có lỗi khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return false;
        }

        private bool chek_DienTichDangKy(string mHopDongID) // neu co đăng ký dt rồi thì mới đc nhập đầu tư
        {
            string strSQL = "Select Count(ID) From tbl_ThuaRuong Where HopDongID =" + mHopDongID + " And TrangThaiDangKy = 1";
            string strKQ = DBModule.ExecuteQueryForOneResult(strSQL, null, null);

            if (string.IsNullOrEmpty(strKQ) || strKQ == "0")
            {
                MessageBox.Show("Bạn chưa nhập diện tích đăng ký cho hợp đồng này!\nYêu cầu nhập diện tích đăng ký trước khi nhập đầu tư!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool Chek_SuaDLGoc() // sử dụng để sửa tbl_truNo_DauTu khi thay doi DL goc
        {                            // = true --> cho phep sua; = false --> da dc thanh toan -->ko dc sua
            try
            {
                string _DotThanhToan = "";
                string _NhapTienTraNoID = "";

                string strSQL = "SELECT tbl_DauTu.DonViCungUngVatTuID, tbl_DanhMucDauTu.LoaiHinhDauTuID"
                    + " FROM  tbl_DanhMucDauTu INNER JOIN "
                    + " tbl_DauTu ON tbl_DanhMucDauTu.ID = tbl_DauTu.DanhMucDauTuID Where tbl_DauTu.ID=" + iDTextBox.Text;
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

                strSQL = "Select ID, DotThanhToan, NhapTienTraNoID From tbl_TruNo_DauTu Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString() + " and DauTuID=" + iDTextBox.Text + " and ThuTu =" + ThuTu.ToString();
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
                        strSQL = "sp_ThanhToan_SuaDLGoc " + MDSolutionApp.VuTrongID.ToString() + "," + iDTextBox.Text + "," + ThuTu.ToString();
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
            catch
            {
                return false;
            }
        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                try//Truyen cac thong so phu:
                {
                    //kiem tra tt
                    string sql = "";

                    if (string.IsNullOrEmpty(createdByTextBox.Text))//Them moi
                    {
                        createdByTextBox.Text = MDSolutionApp.User.ID.ToString();
                        dateAddDateTimePicker.Value = DateTime.Now;
                    }
                    else
                    {
                        frm_ChietTinhCongNo_Confirm_Huy frmcomment = new frm_ChietTinhCongNo_Confirm_Huy();
                        //string strCommnet = "";

                        if (!string.IsNullOrEmpty(createdByTextBox.Text) && createdByTextBox.Text != MDSolutionApp.User.ID.ToString())
                        {

                            if (frmcomment.ShowDialog() != DialogResult.OK)
                            {
                                return;
                            }
                            else
                                lbGhiChu.Text += DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " " + MDSolutionApp.User.UserName + ":" + frmcomment.txtGhiChu.Text + ";\r\n";
                        }
                        modifyByTextBox.Text = MDSolutionApp.User.ID.ToString();
                        dataModifyDateTimePicker.Value = DateTime.Now;
                    }
                }
                catch { }
                this.Validate();
                if (!SaveDauTu())
                {
                    return;
                }

                //if (!chek_DienTichDangKy(HopDongUIDCombobox.SelectedValue.ToString()))
                //{
                //    return;
                //}
                OleDbConnection con = DBModule.CreateDBConnection();
                OleDbTransaction tran = con.BeginTransaction();
                if (IsAdd == true)
                {

                    iDTextBox.Text = GetID();
                    if (string.IsNullOrEmpty(SoCT))
                    {
                        string stt = DBModule.ExecuteQueryForOneResult("Get_MaPhieu 'tbl_DauTu', " + uiComboBoxVuTrong.SelectedValue, con, tran);
                        DateTime dt = (DateTime)DBModule.ExecuteQuery("Select NgayBatDau from tbl_VuTrong where ID=" + uiComboBoxVuTrong.SelectedValue, null, null).Tables[0].Rows[0][0];
                        string strMaPhieu = "DT" + dt.Year.ToString("###") + ".";
                        strMaPhieu = strMaPhieu + stt.PadLeft(6, '0');
                        soChungTuTextBox.Text = strMaPhieu;
                    }
                }
                else
                {   // chek xem khoan đầu tư đã đc thanh toán chưa??
                    if (Chek_SuaDLGoc())
                    { }
                    else
                    {
                        return;
                    }
                }
                string a = danhMucDauTuUIDComboBox.Text;
                if (DoSave())
                {

                    tran.Commit();
                }
                else
                {
                    tran.Rollback();
                }
                uiButtonNew.Enabled = true;
                uiButtonEdit.Enabled = true;
                uiButtonSave.Enabled = false;
                uiButtonCancel.Enabled = false;
                uiGroupBox1.Enabled = false;
                uiGroupBox2.Enabled = false;
                uiButtonDelete.Enabled = true;
                _ID = long.Parse(iDTextBox.Text);
                if (IsAdd)
                {
                    ID = int.Parse(HopDongUIDCombobox.SelectedValue.ToString());

                    MessageBox.Show("Bạn đã lưu lại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //uiButtonNew_Click(null, null);
                    //HopDongUIDCombobox.Focus();
                    //txtMaHD.Focus();
                    //txtMaHD.Text = "";
                    //txtMaHD.SelectAll();
                    //HopDongUIDCombobox.se

                    //{
                    //    uiButtonNew_Click(null, null);
                    //    HopDongUIDCombobox.Focus();
                    //}
                    //else
                    //{
                    //    Close();// _Click(null, null);
                    //}
                    uiButtonNew.Focus();
                }
                else
                {

                    MessageBox.Show("Bạn đã sửa lại thành công !", "Thông báo");
                    this.Close();

                }


            }
            catch
            {

            }
        }

        private string GetID()
        {

            try
            {
                long MaxID = 0;
                string strMaxID = "";
                string strSQL = "select max([ID]) As Max from tbl_dautu";
                strMaxID = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (strMaxID != "")
                    MaxID = long.Parse(strMaxID) + 1;
                else
                    MaxID = 1;

                return MaxID.ToString();
            }
            catch { return ""; }
        }
        private void uiButtonNew_Click(object sender, EventArgs e)
        {

            this.tbl_DauTuBindingSource.AddNew();
            if (ID > 0)
            {
                HopDongUIDCombobox.SelectedValue = long.Parse(ID.ToString());
            }
            IsAdd = true;
            iDTextBox.Text = GetID();
            uiComboBoxVuTrong.SelectedValue = MDSolutionApp.VuTrongID.ToString();
            TruyenDuLieu(true);
            donGiaTextBox.Text = "0";
            dotDauTuTextBox.Text = "0";
            laiSuatTextBox.Text = "0";
            soLuongTextBox.Text = "0";
            soTienTextBox.Text = "0";
            uiButtonNew.Enabled = false;
            uiButtonEdit.Enabled = false;
            uiButtonSave.Enabled = true;
            uiButtonCancel.Enabled = true;
            uiButtonDelete.Enabled = false;
            uiGroupBox1.Enabled = true;
            uiGroupBox2.Enabled = true;
            HopDongUIDCombobox.Enabled = true;
            HopDongUIDCombobox.Focus();
            if (!string.IsNullOrEmpty(SoCT)) soChungTuTextBox.Text = SoCT;
            //uiCboChungLoaiDauTu.DataSource = null;
            SetDataSource_CboChungLoaiDT();
            uiCboChungLoaiDauTu.SelectedValue = null;
            try
            {
                donViCungUngVatTuUIDComboBox.SelectedIndex = 0;
            }
            catch (Exception e2)
            {


            }

        }
        private void TruyenDuLieu(Boolean Truyen)
        {
            if (Truyen)
            {
                float a = 0;
                a = 0;
                float.TryParse(donGiaTextBox.Text, out a);
                editBoxDonGia.Text = a.ToString("###");
                editBoxDotDauTu.Text = dotDauTuTextBox.Text;
                a = 0;
                float.TryParse(laiSuatTextBox.Text, out a);
                editBoxLaiSuat.Text = a.ToString("##0.##");
                a = 0;
                if (soLuongTextBox.Text != "")
                {
                    float.TryParse(soLuongTextBox.Text, out a);
                }
                editBoxSoLuong.Text = a.ToString("##0");
                a = 0;
                float.TryParse(soTienTextBox.Text, out a);
                editBoxSoTien.Text = a.ToString("###");
            }
            else
            {
                donGiaTextBox.Text = editBoxDonGia.Text;
                dotDauTuTextBox.Text = editBoxDotDauTu.Text;
                laiSuatTextBox.Text = editBoxLaiSuat.Text;
                float a = 0;
                float.TryParse(editBoxSoLuong.Text, out a);
                soLuongTextBox.Text = a.ToString("###");
                a = 0;
                float.TryParse(editBoxSoTien.Text, out a);
                soTienTextBox.Text = a.ToString("###");

            }
        }

        private void uiButtonEdit_Click(object sender, EventArgs e)
        {
            uiButtonNew.Enabled = false;
            uiButtonEdit.Enabled = false;
            uiButtonSave.Enabled = true;
            uiButtonCancel.Enabled = true;
            uiButtonDelete.Enabled = true;
            uiGroupBox1.Enabled = true;
            uiGroupBox2.Enabled = true;
            HopDongUIDCombobox.Enabled = false;
            IsAdd = false;
            danhMucDauTuUIDComboBox.Enabled = true;
            donViCungUngVatTuUIDComboBox.Focus();
        }

        private void HopDongUIDCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            uiComboBoxTenHopDong.SelectedValue = HopDongUIDCombobox.SelectedValue;
            txtMaHD.Text = HopDongUIDCombobox.Text;
            loadNguoiThuaKe();

        }
        void loadNguoiThuaKe(string _hdID = "")
        {
            try
            {
                txtNguoiThuaKe.Text = "";

                string hdID = _hdID;
                if (string.IsNullOrEmpty(hdID))
                    hdID = HopDongUIDCombobox.SelectedValue.ToString();
                //string NguoiTK = DBModule.ExecuteQueryForOneResult("select isnull( NguoiThuaKe1Ten,'')+N' - '+isnull(NguoiThuaKe1CMT,'') from dbo.tbl_HopDong where ID="+hdID, null, null);
                txtNguoiThuaKe.Text = DBModule.ExecuteQueryForOneResult("select isnull( NguoiThuaKe1Ten,'')+N' - '+isnull(NguoiThuaKe1CMT,'') from dbo.tbl_HopDong where ID=" + hdID, null, null);
            }
            catch (Exception ex)
            {

            }
        }
        private void iDTextBox_TextChanged(object sender, EventArgs e)
        {
            TruyenDuLieu(true);
            uiButtonNew.Enabled = true;
            uiButtonEdit.Enabled = true;
            uiButtonSave.Enabled = false;
            uiButtonCancel.Enabled = false;
            uiButtonDelete.Enabled = true;
            uiGroupBox1.Enabled = false;
            uiGroupBox2.Enabled = false;
            //IsAdd = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {

                    case Keys.F2:
                        //code cho F2                        
                        if (uiButtonSave.Enabled)
                        {
                            uiButtonSave_Click(null, null);
                        }
                        break;

                    case Keys.F8:
                        if (uiButtonNew.Enabled)
                        { uiButtonNew_Click(null, null); }

                        break;

                    case Keys.F9:
                        if (uiButtonEdit.Enabled)
                        { uiButtonEdit_Click(null, null); }
                        break;
                    case Keys.Enter:
                        try
                        {
                            SendKeys.Send("{TAB}");
                            //   btGhiNhan_Click(null, null);
                        }
                        catch { }
                        break;
                    case Keys.Escape:
                        if (uiButtonCancel.Enabled)
                        {
                            uiButtonCancel_Click(null, null);
                        }
                        break;
                    case Keys.Delete:
                        if (uiButtonDelete.Enabled)
                        {
                            uiButtonDelete_Click(null, null);
                        }
                        break;
                    case Keys.F10:
                        uiButtonClose_Click(null, null);
                        break;

                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void HopDongUIDCombobox_Leave(object sender, EventArgs e)
        {
            try
            {
                string strSQL;
                string strMaxID = "";
                if (HopDongUIDCombobox.Text != "")
                {
                    strSQL = "SELECT Count(ID) FROM tbl_HopDong WHERE  ParentID=0 AND MaHopDong=N'" + HopDongUIDCombobox.Text + "'";
                    strMaxID = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                    if (strMaxID == "0")
                    {
                        MessageBox.Show("Mã hợp đồng không đúng", "Thông báo");
                        HopDongUIDCombobox.Focus();
                    }
                    else
                    {
                        strSQL = "SELECT ID FROM tbl_HopDong WHERE ParentID=0 AND MaHopDong=N'" + HopDongUIDCombobox.Text + "'";
                        strMaxID = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                        uiComboBoxTenHopDong.SelectedValue = long.Parse(strMaxID);
                        HopDongUIDCombobox.SelectedValue = long.Parse(strMaxID);
                        donViCungUngVatTuUIDComboBox.Focus();
                    }
                }
            }
            catch { }
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }

        private void ghiChuTextBox_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            uiButtonSave.Focus();
        }

        private void donViCungUngVatTuUIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (donViCungUngVatTuUIDComboBox.Text != "")
            //{ LoadDanhMucDauTu(donViCungUngVatTuUIDComboBox.SelectedValue.ToString()); }
        }

        private void donViCungUngVatTuUIDComboBox_Leave(object sender, EventArgs e)
        {
            try
            {
                string strSQL;
                string strMaxID = "";
                if (donViCungUngVatTuUIDComboBox.Text != "")
                {
                    strSQL = "SELECT Count(ID) FROM tbl_DonViCungUngVatTu WHERE Ten=N'" + donViCungUngVatTuUIDComboBox.Text + "'";
                    strMaxID = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                    if (strMaxID == "0")
                    {
                        MessageBox.Show("Tên đơn vị cung ứng vật tư không đúng", "Thông báo");
                        donViCungUngVatTuUIDComboBox.Focus();
                    }
                    else
                    {
                        if (uiCboChungLoaiDauTu.Text != "")
                        {
                            uiCboChungLoaiDauTu_Leave(sender, e);
                        }
                        else
                        {
                            uiCboChungLoaiDauTu.Focus();
                        }
                        //strSQL = "SELECT ID FROM tbl_DonViCungUngVatTu WHERE Ten=N'" + donViCungUngVatTuUIDComboBox.Text + "'";
                        //strMaxID = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                        //LoadDanhMucDauTu(strMaxID);
                        //danhMucDauTuUIDComboBox.Focus();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Bạn chưa nhập đơn vị cung ứng vật tư", "Thông báo");
            }
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }

        private void LoadDanhMucDauTu(string DVDT_ID, string LoaiHinhDauTu_ID)
        {
            try
            {
                if ((!string.IsNullOrEmpty(DVDT_ID)) && (!string.IsNullOrEmpty(LoaiHinhDauTu_ID)))
                {
                    DataSet ds;
                    ds = clsDanhMucDauTu.GetListbyWhere("ID,Ten", "ID in(select DanhMucDauTuID from tbl_DanhMucDT_DonViCU where DonvicungungID=" + DVDT_ID + ") and ID in( Select ID from tbl_DanhMucDauTu Where LoaiHinhDauTuID=" + LoaiHinhDauTu_ID + ")", "", null, null);
                    if (ds.Tables.Count > 0)
                    {
                        DataRow oR = ds.Tables[0].NewRow();
                        //int i = ds.Tables[0].Rows.Count;
                        this.danhMucDauTuUIDComboBox.DataSource = ds.Tables[0];
                        danhMucDauTuUIDComboBox.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void editBoxSoTien_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;

            //Control textbox = (Control)sender;
            //textbox.BackColor = Color.White;

            try
            {
                long a = 0;
                if (long.TryParse(editBoxSoTien.Text, out a))
                {
                    editBoxSoTien.Text = a.ToString("###,###,###.0");
                }
                else
                {
                    //MessageBox.Show("Bạn đã nhập sai dữ liệu!");
                    //editBoxSoTien.Focus();
                }
            }
            catch
            {

            }
        }

        private void editBoxSoTien_Enter(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.SkyBlue;

        }

        private void editBoxSoLuong_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;

            try
            {
                float a = 0;
                if (float.TryParse(editBoxSoLuong.Text, out a))
                {
                    editBoxSoLuong.Text = a.ToString("###,###,##0.##");
                }
                else
                {
                    //MessageBox.Show("Bạn đã nhập sai dữ liệu!");
                    //editBoxSoLuong.Focus();
                }
            }
            catch
            {

            }

            try
            {
                float dongia = 0;
                float SL = 0;
                if ((float.TryParse(editBoxSoLuong.Text, out SL)) && (float.TryParse(editBoxDonGia.Text, out dongia)))
                {
                    float sotien = SL * dongia;

                    long sotienlong = long.Parse(sotien.ToString());
                    editBoxSoTien.Text = sotienlong.ToString("#,###,###.#");
                }
            }
            catch
            {
            }
        }

        private void editBoxDonGia_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;

            try
            {
                long a = 0;
                if (long.TryParse(editBoxDonGia.Text, out a))
                {
                    editBoxDonGia.Text = a.ToString("###,###,###");
                }
                else
                {
                    //MessageBox.Show("Bạn đã nhập sai dữ liệu!");
                    //editBoxDonGia.Focus();
                }
            }
            catch
            {

            }

            try
            {
                float dongia = 0;
                float SL = 0;
                if ((float.TryParse(editBoxSoLuong.Text, out SL)) && (float.TryParse(editBoxDonGia.Text, out dongia)))
                {
                    float sotien = SL * dongia;
                    long sotienlong = (long)sotien;
                    editBoxSoTien.Text = sotienlong.ToString("#,###,###.#");
                }
            }
            catch
            {
            }

        }

        private void editBoxDotDauTu_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }

        private void danhMucDauTuUIDComboBox_Leave(object sender, EventArgs e)
        {
            try
            {
                string StrSQL = "Select DonViTinh from tbl_tbl_DanhMucDauTu Where id =" + danhMucDauTuUIDComboBox.SelectedValue;
                lb_DonViTinh.Text = DBModule.ExecuteQueryForOneResult(StrSQL, null, null);
            }
            catch
            {
                lb_DonViTinh.Text = "";
            }
        }

        private void txtMaHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (txtMaHD.Text.Length != null)
                {
                    string SQL = "Select ID from tbl_hopdong Where MaHopDong=N'" + txtMaHD.Text + "'";
                    string strkq = DBModule.ExecuteQueryForOneResult(SQL, null, null);
                    if (strkq != "")
                    {
                        HopDongUIDCombobox.SelectedValue = long.Parse(strkq);
                    }
                    else
                    {
                        MessageBox.Show("Không có mã hợp đồng nào như vậy\n Hãy Kiểm tra lại mã hợp đồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã hợp đồng phải đúng 6 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void danhMucDauTuIDLabel1_Click(object sender, EventArgs e)
        {

        }

        private void uiComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //string SQL = "Select ID,Ten from tbl_DanhMucDauTu Where ID = 2";
            //DataSet ds = DBModule.ExecuteQuery(SQL,null,null);
            //tbl_DMDauTubindingSource.DataSource = ds.Tables[0];
        }

        private void uiCboChungLoaiDauTu_Leave(object sender, EventArgs e)
        {

            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }

        private void danhMucDauTuUIDComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (danhMucDauTuUIDComboBox.Text != "")
            {
                try
                {
                    string SQL = "Select DonViTinh from tbl_DanhMucDauTu Where ID =(Select ID from tbl_DanhMucDauTu Where Ten=N'" + danhMucDauTuUIDComboBox.Text + "')";

                    lb_DonViTinh.Text = DBModule.ExecuteQueryForOneResult(SQL, null, null);
                    label5.Text = "(Đồng/" + lb_DonViTinh.Text + ")";
                }
                catch
                {
                    lb_DonViTinh.Text = "";
                }
                //lb_DonViTinh.Text = str;
            }
            else
            {

            }
        }

        private void soChungTuTextBox_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }

        private void danhMucDauTuUIDComboBox_Leave_1(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            if (danhMucDauTuUIDComboBox.Text != "")
            {
                string strSQL = "Select ID from tbl_DanhMucDauTu Where Ten =N'" + danhMucDauTuUIDComboBox.Text + "'";
                string str = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (String.IsNullOrEmpty(str) || str == "")
                {
                    MessageBox.Show("Không có danh mục đầu tư nào như trên\nHãy Kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    danhMucDauTuUIDComboBox.Focus();
                }
                else
                {
                    danhMucDauTuUIDComboBox.SelectedValue = long.Parse(str);
                }
            }
        }

        private void editBoxSoLuong_Enter(object sender, EventArgs e)
        {
            editBoxSoTien_Enter(sender, e);
            if (editBoxSoLuong.Text == "0")
                editBoxSoLuong.Text = "";
        }

        private void uiCboChungLoaiDauTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSQL;
            string strMaxID = "";
            string strChungLoaiID = "";
            if (uiCboChungLoaiDauTu.Text != "")
            {
                strSQL = "SELECT Count(ID) FROM tbl_LoaiHinhDauTu WHERE Ten=N'" + uiCboChungLoaiDauTu.Text + "'";
                strMaxID = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (strMaxID == "0")
                {
                    MessageBox.Show("Tên chủng loại vật tư không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    uiCboChungLoaiDauTu.Focus();
                }
                else
                {
                    strSQL = "SELECT ID FROM tbl_DonViCungUngVatTu WHERE Ten=N'" + donViCungUngVatTuUIDComboBox.Text + "'";
                    strMaxID = DBModule.ExecuteQueryForOneResult(strSQL, null, null);

                    strSQL = "Select ID from tbl_LoaiHinhDauTu Where Ten=N'" + uiCboChungLoaiDauTu.Text + "'";
                    strChungLoaiID = DBModule.ExecuteQueryForOneResult(strSQL, null, null);

                    LoadDanhMucDauTu(strMaxID, strChungLoaiID);
                    if (IsAdd)
                        danhMucDauTuUIDComboBox.Focus();
                }
            }
            else
            {
                //MessageBox.Show("Bạn chưa nhập chủng loại vật tư", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //uiCboChungLoaiDauTu.Focus();
            }
        }




    }
}