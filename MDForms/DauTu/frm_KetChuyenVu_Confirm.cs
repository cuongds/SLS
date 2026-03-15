using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms.DauTu
{
    public partial class frm_KetChuyenVu_Confirm : Form
    {
        public string ID;
        
        public frm_KetChuyenVu_Confirm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ComboVuTrong.SelectedIndex<0)
            {
                MessageBox.Show("Vui lòng chọn vụ cần chuyển!","SLS",MessageBoxButtons.OK,MessageBoxIcon.Information); 
                ComboVuTrong.Focus();
                return;
            }
            if (comboDMGoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục gốc!","SLS",MessageBoxButtons.OK,MessageBoxIcon.Information); 
                comboDMGoc.Focus();
                return;
            }
            if (comboDMLai.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục lãi!","SLS",MessageBoxButtons.OK,MessageBoxIcon.Information); 
                comboDMLai.Focus();
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

        private void frm_KetChuyenVu_Confirm_Load(object sender, EventArgs e)
        {
            string sql = "Select ID,Ten From tbl_VuTrong Where ID >" + MDSolutionApp.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            ComboVuTrong.DataSource = ds.Tables[0];
            ComboVuTrong.DisplayMember = "Ten";
            ComboVuTrong.ValueMember = "ID";
        }

        
    }
}
