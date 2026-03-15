using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace MDSolution
{
    public partial class frmLogin : Form        
    {
                
        public frmLogin()
        {
            InitializeComponent();
            LoadccbVuTrong();
        }
       
        private void LoadccbVuTrong()
        {
            try
            {
                DataSet ds;
                ds = clsVuTrong.GetListbyWhere(""," IsActive=1", "", null, null);
                if (ds.Tables.Count > 0)
                {
                    this.cboVuTrong.DataSource = ds.Tables[0];
                }
                string VuTrongTen = clsVuTrong.GetDefaultVuTrongTen(null,null);
                int defaultvutrong = this.cboVuTrong.FindStringExact(VuTrongTen,0);
                this.cboVuTrong.SelectedIndex = defaultvutrong;
                //this.cbXa.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private long DangNhap(string strUserName, string strPassword)
        {   
            string strSQL = "select ID from sys_User where 1=1 ";
            strSQL += "  And (rTrim(lTrim([UserName])) = rTrim(lTrim(N'" + strUserName + "')))  And (rTrim(lTrim([Password])) = rTrim(lTrim(N'" + strPassword + "')))";
            //strSQL += " and UserName='" + strUsername + "' and Password='" + strPassword + "'";
            string ret = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
            if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                return 0;
            else
                return long.Parse(ret);
 
        }
        private long Check_ChotDuLieu_DienTich(long VuTrongID)
        {
            string strSQL = "Select ChotDuLieuDienTich from tbl_VuTrong Where ID= "+MDSolutionApp.VuTrongID.ToString();
            string ret = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
            if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                return 0;
            else
                return long.Parse(ret);
        }
        private void cmdLogin_Click(object sender, EventArgs e)
        {
           clsUser oUser = new clsUser();
            oUser.UserName = txtUser.Text.Trim();
            oUser.Password = txtPass.Text.Trim();
            oUser.ID = this.DangNhap(oUser.UserName,oUser.Password);
            if (oUser.ID>0)
            {
                oUser.Load(null,null);
                MDSolutionApp.User = oUser;                
                MDIParent1.strVuTrong = cboVuTrong.Text;                
                MDSolutionApp.VuTrongID = long.Parse(cboVuTrong.SelectedValue.ToString());
                MDSolutionApp.VuTrongTen = cboVuTrong.Text;
                //MDSolutionAppN.iUser = MDSolutionApp.User;
                //MDSolutionAppN.iVuTrongID = MDSolutionApp.VuTrongID;
                MDSolutionApp.ChotDuLieuDienTich = Check_ChotDuLieu_DienTich(MDSolutionApp.VuTrongID);
                DialogResult = DialogResult.OK;                
                this.Close();
                
            }
            else
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //txtUser.Text = "admin";
            //txtPass.Text = "tckt123456";
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
           
            Close();
        }
    }
}