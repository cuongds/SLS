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
    public partial class frm_ChonHD : Form
    {
        public long _CBNVID = -1;
        public long HopDongID=-1;
        public string HoTen = "";
        public string MaHopDong = "";
        public long OK = 0;
        public frm_ChonHD()
        {
            InitializeComponent();
        }
        public frm_ChonHD(long CanBoNongVuID)
        {
            InitializeComponent();
            _CBNVID = CanBoNongVuID;
            Load_DiaBan(_CBNVID);
        }
     
        private void Load_DiaBan(long CBDB_ID)
        {
            string sql = "SELECT dbo.tbl_Thon.CanBoNongVuID, dbo.tbl_DanhMucCanBoNongVu.Ten AS CBNV,dbo.tbl_HopDong.ID,dbo.tbl_HopDong.HoTen,dbo.tbl_HopDong.MaHopDong,dbo.tbl_Thon.Ten AS Ban, dbo.tbl_Xa.Ten AS Xa, dbo.tbl_Huyen.Ten AS Huyen " +
                        "FROM    dbo.tbl_Thon INNER JOIN dbo.tbl_Xa ON dbo.tbl_Thon.XaID = dbo.tbl_Xa.ID INNER JOIN dbo.tbl_Huyen ON dbo.tbl_Xa.HuyenID = dbo.tbl_Huyen.ID " +
                       " LEFT OUTER JOIN dbo.tbl_DanhMucCanBoNongVu ON dbo.tbl_Thon.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.id" +
                       " INNER JOIN tbl_HopDong ON tbl_HopDong.ThonID=tbl_Thon.ID";
            string sqlWhere = "";
            if (CBDB_ID > 0)
            {
               sqlWhere= " WHERE dbo.tbl_Thon.CanBoNongVuID=" + CBDB_ID.ToString();
            }
            sql = sql + sqlWhere;
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables.Count > 0)
            {
                this.gdHD.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdHD.DataSource = null;
            }
        }
             
        private void btnCancel_Click(object sender, EventArgs e)
        {
            HopDongID = -1;
            HoTen = "";
            MaHopDong = "";
            OK = 0;
            this.Close();

        }


        private void gdDiaBan_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                HopDongID = long.Parse(gdHD.GetRow().Cells["ID"].Value.ToString());
                HoTen = gdHD.GetRow().Cells["HoTen"].Value.ToString();
                MaHopDong = gdHD.GetRow().Cells["MaHopDong"].Value.ToString();
                OK = 1;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Đã có lỗi khi  lấy thông tin nông hộ!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gdDiaBan_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
           if(e.Column.Key=="Choice")
           {
               try
               {
                   HopDongID = long.Parse(gdHD.GetRow().Cells["ID"].Value.ToString());
                   HoTen = gdHD.GetRow().Cells["HoTen"].Value.ToString();
                   MaHopDong = gdHD.GetRow().Cells["MaHopDong"].Value.ToString();
                   OK = 1;
                   this.Close();
               }
               catch
               {
                   MessageBox.Show("Đã có lỗi khi  lấy thông tin nông hộ!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }
        }

      
       
    }
}
