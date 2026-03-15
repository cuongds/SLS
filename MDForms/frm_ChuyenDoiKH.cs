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
    public partial class frm_ChuyenDoiKH : Form
    {
        public long LenhDonID = -1;
        public long HopDongID = -1;
        public string SoHD = "";
        public string HoTen = "";
       
        public frm_ChuyenDoiKH()
        {
            InitializeComponent();
        }
        private void Load_CHD()
        {
            string sql = "SELECT dbo.tbl_LenhChatMia.ID, dbo.tbl_LenhChatMia.SoLenh, dbo.tbl_LenhChatMia.HopDongID, dbo.tbl_LenhChatMia.VuTrongID, dbo.tbl_HopDong.HoTen, dbo.tbl_HopDong.MaHopDong,"+
                          " dbo.tbl_HopDong.SoCMT, dbo.tbl_LenhChatMia.DaCan FROM  dbo.tbl_LenhChatMia INNER JOIN dbo.tbl_HopDong ON dbo.tbl_LenhChatMia.HopDongID = dbo.tbl_HopDong.ID Where VuTrongID="+MDSolutionApp.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                this.gdDSKH.SetDataBinding(ds.Tables[0], "");
            }
            else
            {
                this.gdDSKH.DataSource = null;
            }
        }

   
        private void gdCHD_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                LenhDonID = long.Parse(gdDSKH.GetRow().Cells["ID"].Value.ToString());
                HopDongID = long.Parse(gdDSKH.GetRow().Cells["HopDongID"].Value.ToString());
                SoHD = gdDSKH.GetRow().Cells["MaHopDong"].Value.ToString();
                HoTen = gdDSKH.GetRow().Cells["HoTen"].Value.ToString();
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
                LenhDonID = long.Parse(gdDSKH.GetRow().Cells["ID"].Value.ToString());
                HopDongID = long.Parse(gdDSKH.GetRow().Cells["HopDongID"].Value.ToString());
                SoHD = gdDSKH.GetRow().Cells["MaHopDong"].Value.ToString();
                HoTen = gdDSKH.GetRow().Cells["HoTen"].Value.ToString();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Đã có lỗi khi  lấy thông tin hợp đồng!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LenhDonID = -1;
            HopDongID = -1;
            SoHD = "";
            HoTen = "";
            this.Close();

        }

        private void txtMaHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    LenhDonID = long.Parse(gdDSKH.GetRow().Cells["ID"].Value.ToString());
                    HopDongID = long.Parse(gdDSKH.GetRow().Cells["HopDongID"].Value.ToString());
                    SoHD = gdDSKH.GetRow().Cells["MaHopDong"].Value.ToString();
                    HoTen = gdDSKH.GetRow().Cells["HoTen"].Value.ToString();
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
            try
            {
                LenhDonID = long.Parse(gdDSKH.GetRow().Cells["ID"].Value.ToString());
                HopDongID = long.Parse(gdDSKH.GetRow().Cells["HopDongID"].Value.ToString());
                SoHD = gdDSKH.GetRow().Cells["MaHopDong"].Value.ToString();
                HoTen = gdDSKH.GetRow().Cells["HoTen"].Value.ToString();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Đã có lỗi khi  lấy thông tin hợp đồng!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
       
    }
}
