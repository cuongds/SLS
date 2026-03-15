using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SLSCCSEntities;

namespace MDSolution.MDForms.HoTro
{
    public partial class frm_ChietTinhCongNo_TienTruNo : Form
    {
        public string ID;


        public frm_ChietTinhCongNo_TienTruNo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            decimal tientru = 0;
            if (decimal.TryParse(txtTienTru.Text, out tientru))
            {

                string sql = string.Format("sp_tbl_HoTro_ChietTinhDauTu N'{0}', N'{1}', {2},{3},{4},N'{5}'", MDSolutionApp.User.UserName, txtGhiChu.Text,DBModule.RefineNumber(MDSolutionApp.VuTrongID),DBModule.RefineNumber(tientru),this.ID,txtSoPhieu.Text);
                this.ID = DBModule.ExecuteQueryForOneResult(sql, null, null);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
                //string sqlcap = string.Format("Update tbl_HoTro SET TienTruNoDauTu ={0} where ID={1}", tientru, this.ID);
                //DBModule.ExecuteNonQuery(sql, null, null);
                //this.DialogResult = System.Windows.Forms.DialogResult.OK;
                //this.Close();
            }
            else
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ.", "Thông báo");
                txtTienTru.Focus();
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
            decimal.TryParse(txtTienTru.Text, out tientru);
            decimal TienCo=decimal.Parse(txtTienCo.Text);
            if (tientru == 0 || tientru > TienCo)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ.", "Thông báo");
                txtTienTru.Focus();
            }
            else
            {
                txtConLai.Text = (TienCo - tientru).ToString("###");
            }
        }


    }
}
