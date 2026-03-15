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
    public partial class frm_ChuyenBTK : Form
    {
        public long BaiTKID = -1;
        public string TenBai="";
        public frm_ChuyenBTK()
        {
            InitializeComponent();
        }
        private void Load_DSBTK()
        {
            string sql = "SELECT dbo.tbl_BaiTapKet.ID, dbo.tbl_BaiTapKet.TenBai + N' - thôn ' + dbo.tbl_Thon.Ten + N'- xã ' + dbo.tbl_Xa.Ten + N' - huyện ' + dbo.tbl_Huyen.Ten AS DiaDiem, dbo.tbl_BaiTapKet.DonGia "+
                         "FROM dbo.tbl_BaiTapKet INNER JOIN   dbo.tbl_Thon ON dbo.tbl_BaiTapKet.ThonID = dbo.tbl_Thon.ID INNER JOIN dbo.tbl_Xa ON dbo.tbl_Thon.XaID = dbo.tbl_Xa.ID INNER JOIN dbo.tbl_Huyen ON dbo.tbl_Xa.HuyenID = dbo.tbl_Huyen.ID";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                this.gdDSBTK.SetDataBinding(ds.Tables[0], "");
            }
            else
            {
                this.gdDSBTK.DataSource = null;
            }
        }

   
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                BaiTKID = long.Parse(gdDSBTK.GetRow().Cells["ID"].Value.ToString());
                string DiaDiem = gdDSBTK.GetRow().Cells["DiaDiem"].Value.ToString();
                TenBai = DiaDiem.Substring(0, DiaDiem.IndexOf("-"));
                this.Close();
            }
            catch
            {
                MessageBox.Show("Đã có lỗi khi  lấy thông tin bãi tập kết!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BaiTKID = -1; ;
            TenBai = "";
            this.Close();

        }

        private void frm_ChuyenBTK_Load(object sender, EventArgs e)
        {
            Load_DSBTK();
        }

        private void gdDSBTK_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                BaiTKID = long.Parse(gdDSBTK.GetRow().Cells["ID"].Value.ToString());
                string DiaDiem = gdDSBTK.GetRow().Cells["DiaDiem"].Value.ToString();
                TenBai = DiaDiem.Substring(0, DiaDiem.IndexOf("-"));
                this.Close();
            }
            catch
            {
                MessageBox.Show("Đã có lỗi khi  lấy thông tin bãi tập kết!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gdDSBTK_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                BaiTKID = long.Parse(gdDSBTK.GetRow().Cells["ID"].Value.ToString());
                string DiaDiem = gdDSBTK.GetRow().Cells["DiaDiem"].Value.ToString();
                TenBai = DiaDiem.Substring(0, DiaDiem.IndexOf("-"));
                this.Close();
            }
            catch
            {
                MessageBox.Show("Đã có lỗi khi  lấy thông tin bãi tập kết!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
