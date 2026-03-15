using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms
{
    public partial class frm_ChuyenDoiKHVC : Form
    {
        public long HDVCID = -1;
        public long XeID = -1;
        public frm_ChuyenDoiKHVC()
        {
            InitializeComponent();
        }
        private void Load_CHD()
        {
            string sql = "Select * from V_Dialog_VC Where VuTrongID="+MDSolutionApp.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                this.gdHDVC.SetDataBinding(ds.Tables[0], "");
            }
            else
            {
                this.gdHDVC.DataSource = null;
            }
        }

        private void gdCHD_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                HDVCID = long.Parse(gdHDVC.GetRow().Cells["ID"].Value.ToString());
                XeID = long.Parse(gdHDVC.GetRow().Cells["XeID"].Value.ToString());
                this.Close();
            }
            catch
            {
                MessageBox.Show("Đã có lỗi khi  lấy thông tin hợp đồng!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                HDVCID = long.Parse(gdHDVC.GetRow().Cells["ID"].Value.ToString());
                XeID = long.Parse(gdHDVC.GetRow().Cells["XeID"].Value.ToString());
                this.Close();
            }
            catch
            {
                MessageBox.Show("Đã có lỗi khi  lấy thông tin hợp đồng!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HDVCID = -1; ;
            XeID = -1;
            this.Close();

        }

        private void txtMaHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    HDVCID = long.Parse(gdHDVC.GetRow().Cells["ID"].Value.ToString());
                    XeID = long.Parse(gdHDVC.GetRow().Cells["XeID"].Value.ToString());
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi khi  lấy thông tin hợp đồng!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frm_Them_CHD_HoCon_Load(object sender, EventArgs e)
        {
            Load_CHD();
        }

        private void gdHoCon_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            if (e.Column.Key == "Choice")
            {
                try
                {
                    HDVCID = long.Parse(gdHDVC.GetRow().Cells["ID"].Value.ToString());
                    XeID = long.Parse(gdHDVC.GetRow().Cells["XeID"].Value.ToString());
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi khi  lấy thông tin hợp đồng!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

      
       
    }
}
