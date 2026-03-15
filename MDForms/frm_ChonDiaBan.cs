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
    public partial class frm_ChonDiaBan : Form
    {
        public long ThonID = -1;
        public long OK = 0;
        public frm_ChonDiaBan()
        {
            InitializeComponent();
        }
     
        private void Load_DiaBan()
        {
            string sql = "SELECT     dbo.tbl_Thon.CanBoNongVuID,dbo.tbl_Thon.ID, dbo.tbl_DanhMucCanBoNongVu.Ten AS HoTen, dbo.tbl_Thon.Ten AS Ban, dbo.tbl_Xa.Ten AS Xa, dbo.tbl_Huyen.Ten AS Huyen " +
                        "FROM      dbo.tbl_Thon INNER JOIN dbo.tbl_Xa ON dbo.tbl_Thon.XaID = dbo.tbl_Xa.ID INNER JOIN dbo.tbl_Huyen ON dbo.tbl_Xa.HuyenID = dbo.tbl_Huyen.ID " +
                       " LEFT OUTER JOIN dbo.tbl_DanhMucCanBoNongVu ON dbo.tbl_Thon.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.id";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                this.gdDiaBan.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdDiaBan.DataSource = null;
            }
        }
             
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ThonID = -1;
            OK = 0;
            this.Close();

        }


        private void frm_ChonDiaBan_Load(object sender, EventArgs e)
        {
            Load_DiaBan();
        }

        private void gdDiaBan_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ThonID = long.Parse(gdDiaBan.GetRow().Cells["ID"].Value.ToString());
                OK = 1;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Đã có lỗi khi  lấy thông tin địa bàn!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gdDiaBan_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
           if(e.Column.Key=="Choice")
           {
            try
            {
                ThonID = long.Parse(gdDiaBan.GetRow().Cells["ID"].Value.ToString());
                OK = 1;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Đã có lỗi khi  lấy thông tin địa bàn!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           }
        }

      
       
    }
}
