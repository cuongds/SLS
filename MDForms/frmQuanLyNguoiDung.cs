using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;


namespace MDSolution
{
    public partial class frmQuanLyNguoiDung : Form
    {
        private DataSet gdVUserSource;
        private clsUser ouser = new clsUser();
        
        public frmQuanLyNguoiDung()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadgdVUser()
        {
                this.gdVUserSource = clsUser.GetListbyWhere("", " ID<>1", "", null, null);
                if (this.gdVUserSource.Tables.Count > 0)
                {
                  this.gdVUser.SetDataBinding(this.gdVUserSource.Tables[0], "");
                }
        }
       
      
        private void frmQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            try
            {
                loadUS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lối!\n" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void loadUS()
        {
            LoadgdVUser();
            string Roles = gdVUser.GetValue("Roles").ToString();
            chkThanhtoanXacNhan.Checked = Roles.Contains("Thanhtoan_XacNhan");
            chkThanhToanHuy.Checked = Roles.Contains("Thanhtoan_Huy");
            

            if (Roles.Contains("MNU_DauTu"))
            {
                chk_QuanLyDauTu.Checked = true;
            }
            else
            {
                chk_QuanLyDauTu.Checked = false;
            }

            if (Roles.Contains("MNU_DienTich"))
            {
                chk_QuanLyDienTich.Checked = true;
            }
            else
            {
                chk_QuanLyDienTich.Checked = false;
            }

            if (Roles.Contains("mnu_VanChuyen"))
            {
                chk_QuanLyVanChuyen.Checked = true;
            }
            else
            {
                chk_QuanLyVanChuyen.Checked = false;
            }

            if (Roles.Contains("mnu_Thanhtoan"))
            {
                chk_ThanhToan.Checked = true;
            }
            else
            {
                chk_ThanhToan.Checked = false;
            }

            if (Roles.Contains("MNU_NhapMia"))
            {
                chk_TheoDoiNhapMia.Checked = true;
            }
            else
            {
                chk_TheoDoiNhapMia.Checked = false;
            }

            if (Roles.Contains("MNU_HeThong"))
            {

                chk_QuanTriHeThong.Checked = true;
            }
            else
            {
                chk_QuanTriHeThong.Checked = false;
            }
          
        }

     
        private void gdVUser_AddingRecord(object sender, CancelEventArgs e)
        {

            if (!this.SaveOject(true))
            {
                string message;
                message = String.Format("Có lỗi khi thêm mới bản ghi,bạn có muốn tiếp tục");
                if (MessageBox.Show(message, "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    gdVUser.CancelCurrentEdit();
                }
             }
            else
            {
                this.gdVUser.SetValue("ID", ouser.ID);
            }
   
        }
        private bool SaveOject(bool isNew)
        {
            string str = gdVUser.GetValue("DonVi").ToString();
            try
            {
                if (!isNew)
                {
                    ouser.ID = long.Parse(this.gdVUser.GetValue("ID").ToString());
                    ouser.Load(null, null);
                }
                else
                {
                    ouser = new clsUser();
                }
               
                if (string.IsNullOrEmpty(this.gdVUser.GetValue("HoTen").ToString())) throw new Exception("Họ tên không được để trống ");
                ouser.HoTen = gdVUser.GetValue("HoTen").ToString();
                ouser.Password = gdVUser.GetValue("Password").ToString();
                if (string.IsNullOrEmpty(this.gdVUser.GetValue("UserName").ToString())) throw new Exception("User name không được để trống ");
                ouser.UserName = gdVUser.GetValue("UserName").ToString();
                if (IsExistingUserName(isNew, ouser.UserName)) throw new Exception("User đã được dùng!");
                ouser.DonVi = gdVUser.GetValue("DonVi").ToString();
                ouser.Save(null, null);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private void gdVUser_DeletingRecord(object sender, RowActionCancelEventArgs e)
        {

            string message;

            message = String.Format("Bạn muốn xóa bản ghi này?");

            if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRowView dr = (DataRowView)e.Row.DataRow;
                //clsUser oHD = new clsHopDong(long.Parse(dr.Row.ItemArray[0].ToString()));
                clsUser oUS = new clsUser(long.Parse(dr.Row.ItemArray[0].ToString()));
                oUS.Delete(null, null);
            }
            else
            {
                e.Cancel = true;
            }
            loadUS();

        }
        private bool IsExistingUserName(bool isAddnew, string ContractCode)
        {
            if (isAddnew)
            {
                string SQL = " select Count(*) from sys_User where UserName = '" + ContractCode + "'";
                string ret = DBModule.ExecuteQueryForOneResult(SQL, null, null);
                if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                    return false;
                else
                    return true;
            }
            else
            {
                string SQL = " select * from sys_User where UserName = '" + ContractCode + "'";
                DataSet ds;
                ds = DBModule.ExecuteQuery(SQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow d13 = ds.Tables[0].Rows[0];

                    if (d13["ID"].ToString() != this.gdVUser.GetValue("ID").ToString())
                    { return true; }
                    else { return false; }
                }
                else { return false; }
            }
        }
        private void gdVUser_UpdatingRecord(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!SaveOject(false)) { e.Cancel = true; }
                else
                {
                    MessageBox.Show("Bạn đã sửa lại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                e.Cancel = true;

                gdVUser.CancelCurrentEdit();
                SendKeys.SendWait("{ESC}");
            }
        }

        private void btGhiNhan_Click(object sender, EventArgs e)
        {
            string Roles = "&";


            if (chkThanhtoanXacNhan.Checked)
            {
                Roles += "Thanhtoan_XacNhan&";
            }
            if (chkThanhToanHuy.Checked)
            {
                Roles += "Thanhtoan_Huy&";
            }
            if (chk_QuanLyDauTu.Checked)
            {
                Roles += "MNU_DauTu&";
            }
            if (chk_QuanLyDienTich.Checked)
            {
                Roles += "MNU_DienTich&";
            }
            
            if ( chk_QuanLyVanChuyen.Checked)
            {
                Roles += "mnu_VanChuyen&";
            }

            if (chk_ThanhToan.Checked)
            {
                Roles += "mnu_Thanhtoan&";
            }

            if (chk_TheoDoiNhapMia.Checked)
            {
                Roles += "MNU_NhapMia&";
            }

            if (chk_QuanTriHeThong.Checked)
            {
                Roles += "MNU_HeThong&";
            }

          
            if (chk_DanhMuc.Checked)
            {

                Roles += "MNU_DanhMucNV&";
            }
            int UserID = int.Parse(gdVUser.GetValue("ID").ToString());
            if (UserID > 0)
            {
                string sqlStr = "Update sys_User Set Roles =N'" + Roles + "' Where ID=" + UserID.ToString();
                DBModule.ExecuteNonQuery(sqlStr,null,null );
                MessageBox.Show("Cập nhật thành công!", "SLS", MessageBoxButtons.OK,MessageBoxIcon.Information);
                loadUS();
            }
            else
                MessageBox.Show("Bạn chưa chọn người dùng!", "SLS", MessageBoxButtons.OK,MessageBoxIcon.Information);
            
        }

      

        private void gdVUser_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                grPhanQuyen.Text = "Phân quyền người dùng: " + gdVUser.GetValue("HoTen");
                string Roles = gdVUser.GetValue("Roles").ToString();
                chkThanhtoanXacNhan.Checked = Roles.Contains("Thanhtoan_XacNhan");
                chkThanhToanHuy.Checked = Roles.Contains("Thanhtoan_Huy");
            
                if (Roles.Contains("MNU_DauTu"))
                {
                    chk_QuanLyDauTu.Checked = true;

                }
                else
                {
                    chk_QuanLyDauTu.Checked = false;
                }

                if (Roles.Contains("MNU_DienTich"))
                {
                    chk_QuanLyDienTich.Checked = true;
                }
                else
                {
                    chk_QuanLyDienTich.Checked = false;
                }

                if (Roles.Contains("mnu_VanChuyen"))
                {
                    chk_QuanLyVanChuyen.Checked = true;
                }
                else
                {
                    chk_QuanLyVanChuyen.Checked = false;
                }

                if (Roles.Contains("mnu_Thanhtoan"))
                {
                    chk_ThanhToan.Checked = true;
                }
                else
                {
                    chk_ThanhToan.Checked = false;
                }

                if (Roles.Contains("MNU_NhapMia"))
                {
                    chk_TheoDoiNhapMia.Checked = true;
                }
                else
                {
                    chk_TheoDoiNhapMia.Checked = false;
                }

                if (Roles.Contains("MNU_HeThong"))
                {

                    chk_QuanTriHeThong.Checked = true;
                }
                else
                {
                    chk_QuanTriHeThong.Checked = false;
                }
                
                if (Roles.Contains("MNU_DanhMucNV&"))
                {
                    chk_DanhMuc.Checked = true;
                }
                else 
                {
                    chk_DanhMuc.Checked = false;
                }
            }
            catch { }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}