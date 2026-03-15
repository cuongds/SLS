using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDDataSetForms
{
    public partial class frmDienTich : Form
    {
        public long _ID = 0;
        private int ID = 0;
        private Boolean IsAdd = true;
        public frmDienTich()
        {
            InitializeComponent();
         
            //loadCboBaiBocXep(null);
        }
        public frmDienTich(long id, Boolean IsAddNew)
        {
            InitializeComponent();
            ID = int.Parse(id.ToString());
            loaduiComboBoxGiongMia();
            IsAdd = IsAddNew;
            
            if (IsAdd)
            {
               // this.tbl_ThuaRuongTableAdapter.Fill(this.dienTichDataSet.tbl_ThuaRuong);
                this.tbl_ThuaRuongBindingSource.AddNew();

            }
            else
            {
                this.tbl_ThuaRuongTableAdapter.FillByID(this.dienTichDataSet.tbl_ThuaRuong, ID);

            }
        }
        
        private void frmDienTich_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_BaiTapKet' table. You can move, or remove it, as needed.
            this.tbl_BaiTapKetTableAdapter.Fill(this.dienTichDataSet.tbl_BaiTapKet);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_KieuTrong' table. You can move, or remove it, as needed.
            //this.tbl_KieuTrongTableAdapter.Fill(this.dienTichDataSet.tbl_KieuTrong);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_HopDong' table. You can move, or remove it, as needed.
            //this.tbl_HopDongTableAdapter.Fill(this.dienTichDataSet.tbl_HopDong);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_GiongMia' table. You can move, or remove it, as needed.
            this.tbl_GiongMiaTableAdapter.Fill(this.dienTichDataSet.tbl_GiongMia);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_TinhTrangThuaRuong' table. You can move, or remove it, as needed.
            this.tbl_TinhTrangThuaRuongTableAdapter.Fill(this.dienTichDataSet.tbl_TinhTrangThuaRuong);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_PheCanh' table. You can move, or remove it, as needed.
            this.tbl_PheCanhTableAdapter.Fill(this.dienTichDataSet.tbl_PheCanh);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_MucDichTrong' table. You can move, or remove it, as needed.
            this.tbl_MucDichTrongTableAdapter.Fill(this.dienTichDataSet.tbl_MucDichTrong);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_VuTrong' table. You can move, or remove it, as needed.
            this.tbl_VuTrongTableAdapter.Fill(this.dienTichDataSet.tbl_VuTrong);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_RaiVu' table. You can move, or remove it, as needed.
            this.tbl_RaiVuTableAdapter.Fill(this.dienTichDataSet.tbl_RaiVu);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_TramNongVu' table. You can move, or remove it, as needed.
            this.tbl_TramNongVuTableAdapter.Fill(this.dienTichDataSet.tbl_TramNongVu);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_LoaiDat' table. You can move, or remove it, as needed.
            this.tbl_LoaiDatTableAdapter.Fill(this.dienTichDataSet.tbl_LoaiDat);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_Thon' table. You can move, or remove it, as needed.
            this.tbl_ThonTableAdapter.Fill(this.dienTichDataSet.tbl_Thon);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_HopDong' table. You can move, or remove it, as needed.
            this.tbl_HopDongTableAdapter.Fill(this.dienTichDataSet.tbl_HopDong);
            tbl_KieuTrongTableAdapter.Fill(this.dienTichDataSet.tbl_KieuTrong);
            // TODO: This line of code loads data into the 'dienTichDataSet.tbl_ThuaRuong' table. You can move, or remove it, as needed.
            TruyenDuLieu(true);

            if (IsAdd)
            {
                uiButtonNew_Click(null, null);
                HopDongUIDCombobox.Focus();
            }
            else
            {
                
                uiButtonEdit_Click(null, null);
                xuDongTextBox.Focus();
                _ID = long.Parse(iDTextBox.Text);
                LoadXaBan(null);              
                string strSQL = "Select ID from tbl_thon where ID In (SELECT ThonID FROM tbl_HopDong WHERE ID=" + HopDongUIDCombobox.SelectedValue + ")";
                string strThonID = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                loadBaiTapKet(long.Parse(strThonID));

              
            }


            
        }

        private void loadBaiTapKet(long ThonID)
        {
            string sqlBTK = "select ID,TenBai from tbl_BaiTapKet where ThonID= " + ThonID;
            DataSet dsBTK = DBModule.ExecuteQuery(sqlBTK, null, null);


            //BaiTapKet.Items.Clear();
            uiComboBoxBaiTapKet.DataSource = dsBTK.Tables[0];
            uiComboBoxBaiTapKet.DisplayMember = "TenBai";
            uiComboBoxBaiTapKet.ValueMember = "ID";


        }

         private void loaduiComboBoxGiongMia()
        {
            string sqlGong = "select ID,Ten from [tbl_GiongMia] where UuTien= 1";
            DataSet dsGiong = DBModule.ExecuteQuery(sqlGong, null, null);
            //BaiTapKet.Items.Clear();
            uiComboBoxGiongMia.DataSource = dsGiong.Tables[0];
            uiComboBoxGiongMia.DisplayMember = "Ten";
            uiComboBoxGiongMia.ValueMember = "ID";
        }

        private void LoadXaBan(string IDThonXa)
        {
            string sqlbaitapket = "";
            string baitapketid = "";
            if (IDThonXa == null)
            {
                try
                {
                    sqlbaitapket = "select BaiTapKetID from tbl_ThuaRuong where id=" + _ID;
                    baitapketid = DBModule.ExecuteQueryForOneResult(sqlbaitapket, null, null);



                    string sqlgiacuoc = "SELECT DonGia FROM  dbo.tbl_BaiTapKet_GiaCuoc where (BaiTapKetID=" + baitapketid + ") AND (VuTrongID = " + MDSolutionApp.VuTrongID.ToString() + ")";
                    txtGiaCuoc.Text = DBModule.ExecuteQueryForOneResult(sqlgiacuoc, null, null);

                    string sqlthon = "SELECT  dbo.tbl_Thon.Ten     FROM dbo.tbl_BaiTapKet INNER JOIN dbo.tbl_Thon ON dbo.tbl_BaiTapKet.ThonID = dbo.tbl_Thon.ID INNER JOIN dbo.tbl_Xa ON dbo.tbl_Thon.XaID = dbo.tbl_Xa.ID Where tbl_BaiTapKet.ID=" + baitapketid;
                    txtThon.Text = DBModule.ExecuteQueryForOneResult(sqlthon, null, null);

                    string sqlxa = "SELECT  dbo.tbl_Xa.Ten    FROM dbo.tbl_BaiTapKet INNER JOIN dbo.tbl_Thon ON dbo.tbl_BaiTapKet.ThonID = dbo.tbl_Thon.ID INNER JOIN dbo.tbl_Xa ON dbo.tbl_Thon.XaID = dbo.tbl_Xa.ID Where tbl_BaiTapKet.ID=" + baitapketid;
                    txtXa.Text = DBModule.ExecuteQueryForOneResult(sqlxa, null, null);
                }
                catch { }
            }
            else {
                try
                {
                    string sqlgiacuoc = "SELECT DonGia FROM  dbo.tbl_BaiTapKet_GiaCuoc where (BaiTapKetID=" + IDThonXa + ") AND (VuTrongID = " + MDSolutionApp.VuTrongID.ToString() + ")";
                    txtGiaCuoc.Text = DBModule.ExecuteQueryForOneResult(sqlgiacuoc, null, null);

                    string sqlthon = "SELECT dbo.tbl_Thon.Ten      FROM dbo.tbl_BaiTapKet INNER JOIN dbo.tbl_Thon ON dbo.tbl_BaiTapKet.ThonID = dbo.tbl_Thon.ID INNER JOIN dbo.tbl_Xa ON dbo.tbl_Thon.XaID = dbo.tbl_Xa.ID Where tbl_BaiTapKet.ID=" + IDThonXa;
                    txtThon.Text = DBModule.ExecuteQueryForOneResult(sqlthon, null, null);

                    string sqlxa = "SELECT   dbo.tbl_Xa.Ten     FROM dbo.tbl_BaiTapKet INNER JOIN dbo.tbl_Thon ON dbo.tbl_BaiTapKet.ThonID = dbo.tbl_Thon.ID INNER JOIN dbo.tbl_Xa ON dbo.tbl_Thon.XaID = dbo.tbl_Xa.ID Where tbl_BaiTapKet.ID=" + IDThonXa;
                    txtXa.Text = DBModule.ExecuteQueryForOneResult(sqlxa, null, null);
                }
                catch { }
            
            }
        
        
        }

        private void uiButtonNew_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbl_ThuaRuongBindingSource.AddNew();
                
                IsAdd = true;
                iDTextBox.Text = GetID();
                if (ID > 0)
                {
                    HopDongUIDCombobox.SelectedValue = long.Parse(ID.ToString());
                    maThuaRuongTextBox.Text = GetMaThuaRuong();
                    string strXaID = "";
                    strXaID = LayXa();
                    //loadCboBaiBocXep(strXaID
                }
                uiComboBoxVuTrong.SelectedValue = MDSolutionApp.VuTrongID.ToString();
                TruyenDuLieu(true);
                uiButtonDelete.Enabled = false;
                uiButtonNew.Enabled = false;
                uiButtonEdit.Enabled = false;
                uiButtonSave.Enabled = true;
                uiButtonCancel.Enabled = true;
                uiGroupBox1.Enabled = true;
                uiGroupBox2.Enabled = true;
                uiGroupBox3.Enabled = true;
                HopDongUIDCombobox.Enabled = true;
                
                HopDongUIDCombobox.Focus();
            }catch{}
            
        }
        private string GetID()
        {

            try
            {
                long MaxID = 0;
                string strMaxID = "";
                string strSQL = "select max([ID])+1 As Max from tbl_ThuaRuong";
                strMaxID = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (strMaxID != "")
                    MaxID = long.Parse(strMaxID);
                else
                    MaxID = 1;
                
                return MaxID.ToString();
            }
            catch { return ""; }
        }
        private void TruyenDuLieu(Boolean Truyen)
        {
            if (Truyen)
            {
                float a = 0;
                if (dienTichTextBox.Text != "")
                { 
                    a = float.Parse(dienTichTextBox.Text)/10000; 
                }
                editBoxDienTich.Text = a.ToString();
                editBoxNSDKLan1.Text = nangSuatDuKienTextBox.Text;
                editBoxNSDKLan2.Text = nangSuatDuKien1TextBox.Text;
                editBoxSLDKLan1.Text = sanLuongDuKienTextBox.Text;
                editBoxSLDKLan2.Text = sanLuongDuKien1TextBox.Text;
                // editBoxDTChatGiong.Text = dienTichChatGiongTextBox.Text;
                //editBoxDTPheCanh.Text = dienTichPheCanhTextBox.Text;
                //editBoxSLChatGiong.Text = sanLuongChatGiongTextBox.Text;
            }
            else
            {
                float a = 0;
                if (editBoxDienTich.Text != "")
                { a = float.Parse(editBoxDienTich.Text) * 10000; }

                dienTichTextBox.Text = a.ToString();
                nangSuatDuKienTextBox.Text = editBoxNSDKLan1.Text;
                nangSuatDuKien1TextBox.Text = editBoxNSDKLan2.Text;
                sanLuongDuKienTextBox.Text = editBoxSLDKLan1.Text;
                sanLuongDuKien1TextBox.Text = editBoxSLDKLan2.Text;
                //sanLuongChatGiongTextBox.Text = editBoxSLChatGiong.Text;
                //dienTichPheCanhTextBox.Text = editBoxDTPheCanh.Text;
                //dienTichChatGiongTextBox.Text = editBoxDTChatGiong.Text;

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
            uiGroupBox3.Enabled = true;
            HopDongUIDCombobox.Enabled = false;
            //soBanDieuTraTextBox.Focus();
            IsAdd = false;
        }

        private void uiButtonDelete_Click(object sender, EventArgs e)
        {
            string message;
            if (iDTextBox.Text != "")
            {
                message = String.Format("Bạn có chắc chắn muốn xóa thửa ruộng này ?");

                if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.tbl_ThuaRuongBindingSource.RemoveCurrent();
                    DoSave();
                    //this.tbl_DauTuTableAdapter.Fill(this.dauTuDataSet.tbl_DauTu);
                }
            }
            else
            {
                MessageBox.Show("Thửa ruộng này chưa có nên không xóa được !");

            }
        }
        private void DoSave()
        {
            try
            {
                //this.Validate();
                this.tbl_ThuaRuongBindingSource.EndEdit();
                string a = dienTichTextBox.Text;
                this.tbl_ThuaRuongTableAdapter.Update(this.dienTichDataSet.tbl_ThuaRuong);
            }
            catch 
            { 
                MessageBox.Show("Có lỗi khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                trangThaiDangKyTextBox.Text = "0";
                uiComboBoxTinhtrang.SelectedValue = 4;
                try
                {
                    try//Truyen cac thong so phu:
                    {
                        if (string.IsNullOrEmpty(createdByTextBox.Text))//Them moi
                        {
                            createdByTextBox.Text = MDSolutionApp.User.ID.ToString();
                            dateAddDateTimePicker.Value = DateTime.Now;

                        }
                        else
                        {
                            modifyByTextBox.Text = MDSolutionApp.User.ID.ToString();
                            dataModifyDateTimePicker.Value = DateTime.Now;
                        }
                    }
                    catch
                    {

                    }
                    //this.Validate();

                    if (tabControl1.SelectedTab == tabPage1)
                    {
                        if (!SaveThuaRuong())
                        {
                            return;
                        }

                        if (IsAdd == true) // truyen ID
                        {
                            iDTextBox.Text = GetID();
                        }
                        DoSave();

                        uiButtonNew.Enabled = true;
                        uiButtonEdit.Enabled = true;
                        uiButtonSave.Enabled = false;
                        uiButtonCancel.Enabled = false;
                        uiGroupBox1.Enabled = false;
                        uiGroupBox2.Enabled = false;
                        uiGroupBox3.Enabled = false;
                        uiButtonDelete.Enabled = true;
                        _ID = long.Parse(iDTextBox.Text);
                        if (IsAdd)
                        {
                            ID = int.Parse(HopDongUIDCombobox.SelectedValue.ToString());
                            MessageBox.Show("Bạn đã lưu lại thành công !", "Thông báo");
                            uiButtonNew_Click(null, null);
                            HopDongUIDCombobox.SelectedValue = null;
                            uiComboBox1.SelectedValue = null;
                        }
                        else
                        {
                            MessageBox.Show("Bạn đã sửa lại thành công !", "Thông báo");
                            this.Close();
                        }

                    }
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi khi lưu dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void uiButtonClose_Click(object sender, EventArgs e)
        {
            this.tbl_ThuaRuongBindingSource.CancelEdit();         
            this.Hide();
        }
        private bool SaveThuaRuong()
        {
            try
            {
                float Test = 0;                   
                    
                
                if (string.IsNullOrEmpty(HopDongUIDCombobox.Text))
                {
                    MessageBox.Show("Cho biết mã chủ hợp đồng", "Thông báo");
                    HopDongUIDCombobox.Focus();
                    return false;
                }
                //if (string.IsNullOrEmpty(soBanDieuTraTextBox.Text) && tabControl1.SelectedIndex==0)
                //{
                //    MessageBox.Show("Cho biết số bản điều tra", "Thông báo");
                //    soBanDieuTraTextBox.Focus();
                //    return false;}
                //else{
                //    if (IsExistingSBDT(IsAdd, soBanDieuTraTextBox.Text))
                //    {
                //        MessageBox.Show("Nhập trùng số bản điều tra", "Thông báo");
                //        soBanDieuTraTextBox.Focus();
                //        return false;
                //    }
                //}
               
                //if (string.IsNullOrEmpty(TramNongVu.Text) && tabControl1.SelectedIndex == 0)
                //{
                //    MessageBox.Show("Cho biết thửa ruộng thuộc trạm nông vụ nào", "Thông báo");
                //    TramNongVu.Focus();
                //    return false;
                //}
                if (string.IsNullOrEmpty(editBoxDienTich.Text) && tabControl1.SelectedIndex == 0)
                {
                    MessageBox.Show("Bạn chưa nhập diện tích", "Thông báo");
                    editBoxDienTich.Focus();
                    return false;
                }
                else
                {
                    if (!float.TryParse(editBoxDienTich.Text, out Test) && tabControl1.SelectedIndex == 0)
                    {
                        MessageBox.Show("Diện tích phải nhập kiểu số", "Thông báo");
                        editBoxDienTich.Focus();
                        return false;
                    }
                    else
                    {
                        if (float.Parse(editBoxDienTich.Text) <= 0 && tabControl1.SelectedIndex == 0)
                        {
                            MessageBox.Show("Diện tích phải lớn hơn 0", "Thông báo");
                            editBoxDienTich.Focus();
                            return false;
                        }
                    }
                }
                if (string.IsNullOrEmpty(uiComboBoxLoaiDat.Text) && tabControl1.SelectedIndex == 0)
                {
                    MessageBox.Show("Bạn chưa nhập loại đất", "Thông báo");
                    uiComboBoxLoaiDat.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(uiComboBoxGiongMia.Text) && tabControl1.SelectedIndex == 0)
                {
                    MessageBox.Show("Cho biết giống mía trồng", "Thông báo");
                    uiComboBoxGiongMia.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(uiComboBoxBaiTapKet.Text) && tabControl1.SelectedIndex == 0)
                {
                    MessageBox.Show("Cho biết bãi tập kết", "Thông báo");
                    uiComboBoxBaiTapKet.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(uiComboBoxRaiVu.Text) && tabControl1.SelectedIndex == 0)
                {
                    MessageBox.Show("Cho biết mía rải vụ nào", "Thông báo");
                    uiComboBoxRaiVu.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(uiComboBoxMucDich.Text) && tabControl1.SelectedIndex == 0)
                {
                    MessageBox.Show("Xác định rõ mục đích trồng", "Thông báo");
                    uiComboBoxMucDich.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(ngayTrongCalendarCombo.Text) && tabControl1.SelectedIndex == 0)
                {
                    MessageBox.Show("Cho biết ngày trồng", "Thông báo");
                    ngayTrongCalendarCombo.Focus();
                    return false;
                }
                //else
                //{
                  // if (DateTime.Now > DateTime.Parse(ngayTrongCalendarCombo.Value))
                //    {
                //        MessageBox.Show("Ngày trồng phải lớn hơn ngày hiện tại !", "Thông báo");
                //        ngayTrongCalendarCombo.Focus();
                //        return false;
                //    }
                //}
                if (string.IsNullOrEmpty(uiComboBoxTinhtrang.Text) && tabControl1.SelectedIndex == 0)
                {
                    MessageBox.Show("Bạn chưa nhập tình trạng thửa ruộng", "Thông báo");
                    uiComboBoxTinhtrang.Focus();
                    return false;
                }

            
                //if (string.IsNullOrEmpty(editBoxDTChatGiong.Text))
                //{
                //    editBoxDTChatGiong.Text = "0";
                //}
                //else
                //{
                //    if (!float.TryParse(editBoxDTChatGiong.Text, out Test))
                //    {
                //        MessageBox.Show("Diện tích chặt giống phải nhập kiểu số", "Thông báo");
                //        editBoxDTChatGiong.Focus();
                //        return false;
                //    }
                //    else
                //    {
                //        if (float.Parse(editBoxDTChatGiong.Text) < 0)
                //        {
                //            MessageBox.Show("Diện tích chặt giống phải nhập lớn hơn 0", "Thông báo");
                //            editBoxDTChatGiong.Focus();
                //            return false;
                //        }
                //    }
                //}
               
                //if (string.IsNullOrEmpty(editBoxSLChatGiong.Text))
                //{
                //    editBoxSLChatGiong.Text = "0";
                //}
                //else
                //{
                    //if (!float.TryParse(editBoxSLChatGiong.Text, out Test))
                    //{
                    //    MessageBox.Show("Sản lượng chặt giống phải nhập kiểu số", "Thông báo");
                    //    editBoxSLChatGiong.Focus();
                    //    return false;
                    //}
                    //else
                    //{
                    //    if (float.Parse(editBoxSLChatGiong.Text) < 0)
                    //    {
                    //        MessageBox.Show("Sản lượng chặt giống phải nhập lớn hơn 0", "Thông báo");
                    //        editBoxSLChatGiong.Focus();
                    //        return false;
                    //    }
                    //}
                //}
                //if (string.IsNullOrEmpty(editBoxDTPheCanh.Text))
                //{
                //    editBoxDTPheCanh.Text = "0";
                //}
                //else
                //{
                //    if (!float.TryParse(editBoxDTPheCanh.Text, out Test))
                //    {
                //        MessageBox.Show("Diện tích phế canh phải nhập kiểu số", "Thông báo");
                //        editBoxDTPheCanh.Focus();
                //        return false;
                //    }
                //    else
                //    {
                //        if (float.Parse(editBoxDTPheCanh.Text) < 0)
                //        {
                //            MessageBox.Show("Diện tích phế canh phải nhập lớn hơn 0", "Thông báo");
                //            editBoxDTPheCanh.Focus();
                //            return false;
                //        }
                //    }
                //}

                if (string.IsNullOrEmpty(editBoxNSDKLan1.Text))
                {
                    editBoxNSDKLan1.Text = "0";
                }
                else
                {
                    if (!float.TryParse(editBoxNSDKLan1.Text, out Test))
                    {
                        MessageBox.Show("Năng suất dự kiến lần 1 phải nhập kiểu số", "Thông báo");
                        editBoxNSDKLan1.Focus();
                        return false;
                    }
                    else
                    {
                        if (float.Parse(editBoxNSDKLan1.Text) < 0)
                        {
                            MessageBox.Show("Năng suất dự kiến lần 1 phải nhập lớn hơn 0", "Thông báo");
                            editBoxNSDKLan1.Focus();
                            return false;
                        }
                    }
                }
                float SL = float.Parse(editBoxNSDKLan1.Text) * float.Parse(editBoxDienTich.Text);
                editBoxSLDKLan1.Text = SL.ToString();    
                
                if (string.IsNullOrEmpty(editBoxNSDKLan2.Text))
                {
                    editBoxNSDKLan2.Text = "0";
                }
                else
                {
                    if (!float.TryParse(editBoxNSDKLan2.Text,out Test))
                    {
                        MessageBox.Show("Năng suất dự kiến lần 2 phải nhập kiểu số", "Thông báo");
                        editBoxNSDKLan2.Focus();
                        return false;
                    }
                    else
                    {
                        if (float.Parse(editBoxNSDKLan2.Text) < 0)
                        {
                            MessageBox.Show("Năng suất dự kiến lần 2 phải nhập lớn hơn 0", "Thông báo");
                            editBoxNSDKLan2.Focus();
                            return false;
                        }
                    }
                    
                }
                SL = float.Parse(editBoxNSDKLan2.Text) * float.Parse(editBoxDienTich.Text);
                editBoxSLDKLan2.Text = SL.ToString();
                //if (!trangThaiCheckBox.Checked)
                //{ //trangThaiCheckBox.Checked = false;
                //trangThaiCheckBox.Text = "0";
                //}
                trangThaiTextBox.Text = "1";
                TruyenDuLieu(false);                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            try
            {             
                uiButtonNew.Enabled = true;
                uiButtonEdit.Enabled = true;
                uiButtonSave.Enabled = false;
                uiButtonCancel.Enabled = false;
                uiButtonDelete.Enabled = true;
                uiGroupBox1.Enabled = false;
                uiGroupBox2.Enabled = false;
                uiGroupBox3.Enabled = false;
                
              
                if (IsAdd)
                {
                    this.tbl_ThuaRuongBindingSource.CancelEdit();
                    uiButtonNew_Click(null, null);
                }
                else
                {
                    this.tbl_ThuaRuongBindingSource.CancelEdit();
                   
                     this.tbl_ThuaRuongTableAdapter.FillByID(this.dienTichDataSet.tbl_ThuaRuong, ID); 
                }
            }
            catch
            {

            }
        }

        private void HopDongUIDCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void iDTextBox_TextChanged(object sender, EventArgs e)
        {
        //    //TruyenDuLieu(true);
        //    uiButtonNew.Enabled = true;
        //    uiButtonDelete.Enabled = true;
        //    uiButtonEdit.Enabled = true;
        //    uiButtonSave.Enabled = false;
        //    uiButtonCancel.Enabled = false;
        //    uiGroupBox1.Enabled = false;
        //    uiGroupBox2.Enabled = false;
        //    uiGroupBox3.Enabled = false;
        //    //IsAdd = false;
        //   // tbl_ThuaRuongBindingNavigator.Enabled = true;
        }
        private string GetMaThuaRuong()
        {
            try
            {
                //string strXaID = "";

                string strSQL;
                string strMaxID = "";
                if (HopDongUIDCombobox.Text != "")
                {
                    strSQL = "SELECT Count(ID) FROM tbl_ThuaRuong WHERE (HopDongID=" + HopDongUIDCombobox.SelectedValue + " AND VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + ") AND (TrangThaiDangKy =0 Or TrangThaiDangKy is Null)";
                    strMaxID = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                    if (strMaxID == "") strMaxID = "0";
                    int intMaxID = int.Parse(strMaxID);
                    intMaxID++;
                    return HopDongUIDCombobox.Text + "-" + intMaxID.ToString();
                }
                else { return ""; }
            }
            catch
            {
                return "";
            }


        }
        private bool IsExistingMTR(bool isAddnew, string ContractCode)
        {
            if (isAddnew)
            {
                string SQL = " select Count(*) from tbl_ThuaRuong where MaThuaRuong = '" + ContractCode + "'";
                string ret = DBModule.ExecuteQueryForOneResult(SQL, null, null);
                if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                    return false;
                else
                    return true;
            }
            else
            {
                string SQL = " select * from tbl_ThuaRuong where MaThuaRuong = '" + ContractCode + "'";
                DataSet ds;
                ds = DBModule.ExecuteQuery(SQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow d13 = ds.Tables[0].Rows[0];

                    if (d13["ID"].ToString() != iDTextBox.Text)
                    { return true; }
                    else { return false; }
                }
                else { return false; }
            }
        }
        private bool IsExistingSBDT(bool isAddnew, string ContractCode)
        {
            if (isAddnew)
            {
                string SQL = " select Count(*) from tbl_ThuaRuong where SoBanDieuTra = N'" + ContractCode + "' and vutrongid =" + MDSolutionApp.VuTrongID;
                string ret = DBModule.ExecuteQueryForOneResult(SQL, null, null);
                if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                    return false;
                else
                    return true;
            }
            else
            {
                string SQL = " select * from tbl_ThuaRuong where SoBanDieuTra = N'" + ContractCode + "' and vutrongid =" + MDSolutionApp.VuTrongID;
                DataSet ds;
                ds = DBModule.ExecuteQuery(SQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow d13 = ds.Tables[0].Rows[0];

                    if (d13["ID"].ToString() != iDTextBox.Text)
                    { return true; }
                    else { return false; }
                }
                else { return false; }
            }
        }

        private void editBoxNSDKLan1_TextChanged(object sender, EventArgs e)
        {
            //float Test = 0;
            //if (string.IsNullOrEmpty(editBoxNSDKLan1.Text))
            //{
            //    editBoxNSDKLan1.Text = "0";
            //}
            //else
            //{
            //    if (!float.TryParse(editBoxNSDKLan1.Text, out Test))
            //    {
            //        MessageBox.Show("Năng suất dự kiến lần 1 phải nhập kiểu số", "Thông báo");
            //        editBoxNSDKLan1.Focus();
            //        //return false;
            //    }
            //    else
            //    {
            //        if (float.Parse(editBoxNSDKLan1.Text) < 0)
            //        {
            //            MessageBox.Show("Năng suất dự kiến lần 1 phải nhập lớn hơn 0", "Thông báo");
            //            editBoxNSDKLan1.Focus();
            //            //return false;
            //        }
            //    }
            //}
            //float SL = float.Parse(editBoxNSDKLan1.Text) * float.Parse(editBoxDienTich.Text);
            //editBoxSLDKLan1.Text = SL.ToString();
        }

        private void editBoxNSDKLan2_TextChanged(object sender, EventArgs e)
        {
            //float Test = 0;
            //if (string.IsNullOrEmpty(editBoxNSDKLan2.Text))
            //{
            //    editBoxNSDKLan2.Text = "0";
            //}
            //else
            //{
            //    if (!float.TryParse(editBoxNSDKLan2.Text, out Test))
            //    {
            //        MessageBox.Show("Năng suất dự kiến lần 2 phải nhập kiểu số", "Thông báo");
            //        editBoxNSDKLan2.Focus();
            //        //return false;
            //    }
            //    else
            //    {
            //        if (float.Parse(editBoxNSDKLan2.Text) < 0)
            //        {
            //            MessageBox.Show("Năng suất dự kiến lần 2 phải nhập lớn hơn 0", "Thông báo");
            //            editBoxNSDKLan2.Focus();
            //            //return false;
            //        }
            //    }
            //}
            //float SL = float.Parse(editBoxNSDKLan2.Text) * float.Parse(editBoxDienTich.Text);
            //editBoxSLDKLan2.Text = SL.ToString();
        }

        private void HopDongUIDCombobox_TextChanged(object sender, EventArgs e)
        {
            uiComboBox1.SelectedValue = HopDongUIDCombobox.SelectedValue;
            if (IsAdd && HopDongUIDCombobox.Text != "")
            {
                maThuaRuongTextBox.Text = GetMaThuaRuong();
                string strXaID = "";
                strXaID = LayXa();

            }
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

        private string Load_PhanQuyen_CacTramID()
        {
            string strSQL = "Select CumID From sys_Roles_User_Cum Where UserID=" + MDSolutionApp.User.ID.ToString();
            DataSet ds1 = DBModule.ExecuteQuery(strSQL, null, null);
            string str = "";
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                        str += ds1.Tables[0].Rows[i]["CumID"].ToString();
                    else
                        str += "," + ds1.Tables[0].Rows[i]["CumID"].ToString();
                }
            }
            return str;
        }

        private void HopDongUIDCombobox_Leave(object sender, EventArgs e)
        {
            try
            { string strSQL;
                string strMaxID = "";
                if (HopDongUIDCombobox.Text != "")
                {
                    strSQL = "SELECT Count(ID) FROM tbl_HopDong WHERE ParentID=0 AND MaHopDong=N'" + HopDongUIDCombobox.Text + "'";
                    string strCacTramID = Load_PhanQuyen_CacTramID();
                    if (strCacTramID != "")
                        strSQL += " And ThonID in (Select ID From tbl_Thon Where XaID in(Select ID From tbl_Xa Where cumID in(" + strCacTramID + ")))";
                    strMaxID = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                    
                    if (strMaxID == "0")
                    {
                        MessageBox.Show("Mã chủ hợp đồng không đúng", "Thông báo");
                        HopDongUIDCombobox.Focus();
                    }
                    else
                    {
                        strSQL = "SELECT ID FROM tbl_HopDong WHERE ParentID=0 AND MaHopDong=N'" + HopDongUIDCombobox.Text + "'";
                        strMaxID = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                        uiComboBox1.SelectedValue = long.Parse(strMaxID);
                        HopDongUIDCombobox.SelectedValue = long.Parse(strMaxID);
                        maThuaRuongTextBox.Text = GetMaThuaRuong();
                        //soBanDieuTraTextBox.Focus(); 
                    }
                        if (IsAdd)
                        {
                            string strXaID = "";
                            strXaID = LayXa();
                            //loadCboBaiBocXep(strXaID);
                        }
                }
                
            }
            catch { }
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
        }

       

        //private void trangThaiCheckBox_Leave(object sender, EventArgs e)
        //{
        //    Control textbox = (Control)sender;
        //    textbox.BackColor = Color.White;
        //    editBoxDTChatGiong.Focus();
        //}

        private void editBoxNSDKLan2_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            uiButtonSave.Focus();
        }
        private string LayXa()
        {
            try
            {
                string strSQL;
                string strTenXa = "";
                string strTramid = "";
                string strXaID = "";
                if (HopDongUIDCombobox.Text != "")
                {
                    // load ra xứ đồng
                    strSQL = "SElECT ID,Ten from tbl_Xa where ID IN (Select XaID from tbl_thon where ID In (SELECT ThonID FROM tbl_HopDong WHERE ID=" + HopDongUIDCombobox.SelectedValue + "))";
                    DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        strTenXa = ds.Tables[0].Rows[0]["Ten"].ToString();
                        strXaID = ds.Tables[0].Rows[0]["ID"].ToString();
                    }
                    
                    if (strTenXa != "")
                    { xuDongTextBox.Text = strTenXa; }

                    // load ra trạm nông vụ
                    strSQL = "select id from tbl_tramnongvu where id in (select cumid from tbl_xa where id in (select xaid from tbl_thon where id in (select thonid from tbl_hopdong where id ="+ HopDongUIDCombobox.SelectedValue +")))";
                    strTramid = DBModule.ExecuteQueryForOneResult(strSQL, null, null);

                    //if (strTramid != "")
                    //{ TramNongVu.SelectedValue = strTramid; }
                    if (strXaID != "")
                        return strXaID;
                    else
                        return "-1";
                }
                else
                {
                    return "-1";
                }
            }
            catch 
            {
                return "-1";
            }
        
        }

        private void editBoxDienTich_Enter(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.SkyBlue;
        }

        private void editBoxDienTich_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;

            
            if (textbox.GetType().ToString() == "Janus.Windows.EditControls.UIComboBox")
            {
                long a = 0;
                bool bol = false;
                try
                {
                    bol = long.TryParse(textbox.Text, out a);
                }
                catch
                {
                    bol = false;
                }

                if (bol == true)
                {
                    MessageBox.Show("Bạn đã nhập sai dữ liệu này,hãy nhập lại!", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textbox.Focus();
                }
            }

            //if (soBanDieuTraTextBox.Text != "")
            //{
                //if (IsExistingSBDT(IsAdd, soBanDieuTraTextBox.Text))
                //{
                //    MessageBox.Show("Nhập trùng số bản điều tra", "Thông báo");
                //    soBanDieuTraTextBox.Focus();
                //    //return false;
                //}
            //}
        }
        private void editBox_Enter(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.SkyBlue;
            //textbox.Text = Color.White;
        }

        private void uiComboBoxTinhtrang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
            //   // dienTichChatGiongTextBox.Focus();
            SendKeys.Send("{TAB}");
            SendKeys.Send("{TAB}");

            //    //editBoxDTChatGiong
            }
        }

        private void kieuTrongDangKyIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kieuTrongDangKyIDUIComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void uiComboBoxKieuTrong_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;
            
            //if ((uiComboBoxKieuTrong.SelectedValue.ToString() == "0") || (uiComboBoxKieuTrong.SelectedValue == null))
            //    MessageBox.Show("");
            //long KieuTrongID = long.Parse(uiComboBoxKieuTrong.SelectedValue.ToString());
            if (uiComboBoxKieuTrong.Text != "")
            {
                string strSQL = "Select * from tbl_KieuTrong where Ten =N'" + uiComboBoxKieuTrong.Text.Trim() + "'";
                try
                {
                    DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Bạn nhập sai!", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        uiComboBoxKieuTrong.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Bạn nhập sai kiểu trồng!", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    uiComboBoxKieuTrong.Focus();
                }
            }
        }

        private void soBanDieuTraTextBox_Leave(object sender, EventArgs e)
        {
            Control textbox = (Control)sender;
            textbox.BackColor = Color.White;

            //if (soBanDieuTraTextBox.Text != "")
            //{
            //    if (IsExistingSBDT(IsAdd, soBanDieuTraTextBox.Text))
            //    {
            //        MessageBox.Show("Nhập trùng số bản điều tra", "Thông báo");
            //        soBanDieuTraTextBox.Focus();
            //        //return false;
            //    }
            //}
        }

        private void uiGroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void uiCbo_BaiBocXep_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void uiComboBoxBaiTapKet_SelectedItemChanged(object sender, EventArgs e)
        {
            string ID = uiComboBoxBaiTapKet.SelectedValue.ToString();

            LoadXaBan(ID);
            xuDongTextBox.Text = uiComboBoxBaiTapKet.Text;
            


        }

        private void chk_Tach_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Tach.Checked == true)
            {
                grpTachThua.Visible = true;
                txt_DienTich1.Focus();
                txt_DienTich1.Text = editBoxDienTich.Text;
                txt_DienTich2.Text = "0";                
            }
            else
            {
                grpTachThua.Visible = false;
                txt_DienTich1.Text = "0";
                txt_DienTich2.Text = "0";               
               
            }
        }

        private void cmdTachThua_Click(object sender, EventArgs e)
        {
            try
            {
                _ID = long.Parse(iDTextBox.Text);
                float dt1 = float.Parse(txt_DienTich1.Text) * 10000;
                float dt = float.Parse(editBoxDienTich.Text) * 10000;
                float dt2 = dt - dt1;
               
                if (ID > 0)
                {

                    string strSQLMax = "Select max(ID) FROM tbl_ThuaRuong ";
                    int New_ID = int.Parse(MDSolution.DBModule.ExecuteQueryForOneResult(strSQLMax, null, null).ToString());
                    New_ID = New_ID + 1;
                    string strSQL = "Update tbl_ThuaRuong SET DienTich=" + dt1.ToString() + " Where ID=" + _ID.ToString();
                    strSQL += " ; Insert INTO tbl_ThuaRuong([ID], [SoBanDieuTra],[MaThuaRuong],[HopDongID],[ThonID] " +
                                " ,[HienTrangGiaoThong],[DienTich],[LoaiDatID],[TramNongVuID],[SoHieuKeUoc] " +
                                " ,[XuDong],[DuongVanChuyenID],[RaiVuID],[VuTrongID],[GiongMiaID],[NgayTrong] " +
                                " ,[NgayThuHoachDuKien],[NangSuatDuKien],[SanLuongDuKien],[MucDichID],[PheCanhID] " +
                                " ,[TrangThai] ,[TinhTrang],[SoPhieuChat],[CreatedBy],[ModifyBy],[DateAdd] " +
                                " ,[DataModify],[NoteModify],[Status],[NangSuatDuKien1],[SanLuongDuKien1],[KieuTrongID] " +
                                " ,[DienTichPheCanh],[DienTichChatGiong],[SanLuongChatGiong],[XuDongDangKy] " +
                                " ,[LoaiDatDangKyID],[GiongMiaDangKyID],[KieuTrongDangKyID],[ThoiGianDangKy],[DienTichDangKy] " +
                                " ,[NangSuatDangKy],[SanLuongDangKy],[DienTichDuKienChatGiong],[TrangThaiDangKy],[NangSuatChatGiong]" +
                                " ,[BaiTapKetID] ,[NoiDungChamSocID] ,[NguyenNhanphecanh] ,[CanBoNongVuID]) " +
                                " SELECT " + New_ID .ToString() + " , [SoBanDieuTra],[MaThuaRuong],[HopDongID],[ThonID] " +
                                " ,[HienTrangGiaoThong],"+ dt2.ToString() +",[LoaiDatID],[TramNongVuID],[SoHieuKeUoc] " +
                                " ,[XuDong],[DuongVanChuyenID],[RaiVuID],[VuTrongID],[GiongMiaID],[NgayTrong] " +
                                " ,[NgayThuHoachDuKien],[NangSuatDuKien],[SanLuongDuKien],[MucDichID],[PheCanhID] " +
                                " ,[TrangThai] ,[TinhTrang],[SoPhieuChat],[CreatedBy],[ModifyBy],[DateAdd] " +
                                " ,[DataModify],[NoteModify],[Status],[NangSuatDuKien1],[SanLuongDuKien1],[KieuTrongID] " +
                                " ,[DienTichPheCanh],[DienTichChatGiong],[SanLuongChatGiong],[XuDongDangKy] " +
                                " ,[LoaiDatDangKyID],[GiongMiaDangKyID],[KieuTrongDangKyID],[ThoiGianDangKy],[DienTichDangKy] " +
                                " ,[NangSuatDangKy],[SanLuongDangKy],[DienTichDuKienChatGiong],[TrangThaiDangKy],[NangSuatChatGiong]" +
                                " ,[BaiTapKetID] ,[NoiDungChamSocID] ,[NguyenNhanphecanh] ,[CanBoNongVuID] FROM tbl_ThuaRuong Where ID=" + _ID.ToString();

                    MDSolution.DBModule.ExecuteNonQuery(strSQL, null, null);
                    MessageBox.Show("Đã tách thửa xong!", "Thông báo", MessageBoxButtons.OK);
                    editBoxDienTich.Text = (dt1/10000).ToString();
                    chk_Tach.Checked = false;
                }
            }
            catch 
            {
                MessageBox.Show("Lỗi không tách được thửa!", "Thông báo", MessageBoxButtons.OK);
            }

        }

        private void txt_DienTich1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float dt1 = float.Parse(txt_DienTich1.Text) ;
                float dt = float.Parse(editBoxDienTich.Text) ;
                float dt2 = dt - dt1;
                txt_DienTich2.Text = dt2.ToString();
            }
            catch { }

        }

     
       
    }
}