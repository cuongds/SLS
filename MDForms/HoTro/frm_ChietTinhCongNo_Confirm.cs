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
    public partial class frm_ChietTinhCongNo_Confirm : Form
    {
        public string ID;
        public long ThanhToanNhanh = 0;
        public frm_ChietTinhCongNo_Confirm()
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
            //string sql = string.Format("sp_tbl_HoTro_ChietTinhDauTu N'{0}', N'{1}', {2},{3},{4}", MDSolutionApp.User.UserName, txtGhiChu.Text, MDSolutionApp.VuTrongID,0,0);          
            //this.ID = DBModule.ExecuteQueryForOneResult(sql, null, null);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;            
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        
    }
}
