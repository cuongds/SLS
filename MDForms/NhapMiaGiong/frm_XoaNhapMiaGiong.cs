using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms.NhapMiaGiong
{
    public partial class frm_XoaNhapMiaGiong : Form
    {
        public string ID;
        
        public frm_XoaNhapMiaGiong()
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
            if (string.IsNullOrEmpty(txtGhiChu.Text))
            {
                MessageBox.Show("Vui lòng nhập lý do hủy");
                return;
            }
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
