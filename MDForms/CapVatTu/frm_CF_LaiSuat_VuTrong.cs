using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms.CapVatTu
{
    public partial class frm_CF_LaiSuat_VuTrong : Form
    {
        public long OK = 0;
        public long VuTrongID=-1;
        public decimal LaiSuat = 0;
        public DateTime NgayTinhLai = DateTime.MinValue;
        public frm_CF_LaiSuat_VuTrong()
        {
            InitializeComponent();
            LoadVuTrong();
            dtNgayTinhLai.Value = NgayHienHanh();
        }
        private void LoadVuTrong()
        {
            string sql = "Select * From tbl_VuTrong Where ID>"+MDSolutionApp.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboVuTrong.DataSource = ds.Tables[0];
                cboVuTrong.ValueMember = "ID";
                cboVuTrong.DisplayMember = "Ten";
            }
            else
            {
                cboVuTrong.DataSource = null;
                cboVuTrong.Text = "";
            }

        }
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool Verify()
        {
            if (cboVuTrong.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn vụ trồng", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboVuTrong.Focus();
                return false;
            }
            return true;
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (Verify())
            {
                VuTrongID = long.Parse(cboVuTrong.SelectedValue.ToString());
                LaiSuat = nLaiSuat.Value;
                if (rdNgayNhanDauTu.Checked)
                {
                    NgayTinhLai = DateTime.MinValue;
                }
                else
                {
                    NgayTinhLai = dtNgayTinhLai.Value;
                }
                OK = 1;
                this.Close();
            }
        }

        private void rdNgayNhanDauTu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNgayNhanDauTu.Checked)
            {
                NgayTinhLai = DateTime.MinValue;
                dtNgayTinhLai.Visible = false;
            }
            else
            {
                NgayTinhLai = dtNgayTinhLai.Value;
                dtNgayTinhLai.Visible = true;
            }
        }
        private DateTime NgayHienHanh()
        {
            DateTime dt = DateTime.Now;
            try
            {
                dt = DateTime.Parse(DBModule.ExecuteQueryForOneResult("Select Getdate()", null, null).ToString());
            }
            catch { }
            return dt;

        }
     }
}
