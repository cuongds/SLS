using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MDSolution;

namespace MDSolution.MDDialoge
{
    public partial class dlgDauTuHo : Form
    {
        // Thiet lap vu trong
        string VuTrongID = MDSolutionApp.VuTrongID.ToString();
        //long HopDongID = -1;
        long ID = -1;
        public long DauTuID = -1;
        // Thiet lap vu trong
        
        // phần chuẩn cân
        public delegate void PassID(string value);
        public PassID passID;

        private void SendID()
        {
            if (passID != null)
            {
                try
                {
                    passID(this.gdVHopDongDauTu.GetValue("ID").ToString());
                }
                catch
                {
                    passID("-1");
                }
            }
        }    
        public dlgDauTuHo(long HopDongID)
        {
            InitializeComponent();
            ID = HopDongID;
            LoadGrid();
        }
        public void LoadGrid()
        {
            string strSQL = "";
            strSQL = @"SELECT        dbo.tbl_DauTu.SoLuong, dbo.tbl_DauTu.DonGia, dbo.tbl_DauTu.SoTien, dbo.tbl_DauTu.SoChungTu, dbo.tbl_DauTu.VuTrongID, dbo.tbl_DanhMucDauTu.Ten AS DanhMuc, dbo.tbl_LoaiHinhDauTu.Ten AS LoaiHinh, 
                         dbo.tbl_HopDong.HoTen, dbo.tbl_HopDong.MaHopDong, dbo.tbl_HopDong.NguoiThuaKe1Ten, dbo.tbl_DauTu.DaThanhToan, dbo.tbl_DauTu.ID
                            FROM            dbo.tbl_DauTu INNER JOIN
                         dbo.tbl_DanhMucDauTu ON dbo.tbl_DauTu.DanhMucDauTuID = dbo.tbl_DanhMucDauTu.ID INNER JOIN
                         dbo.tbl_HopDong ON dbo.tbl_DauTu.HopDongID = dbo.tbl_HopDong.ID INNER JOIN
                         dbo.tbl_LoaiHinhDauTu ON dbo.tbl_DanhMucDauTu.LoaiHinhDauTuID = dbo.tbl_LoaiHinhDauTu.ID
                    WHERE         (dbo.tbl_DauTu.DaThanhToan<=0 AND dbo.tbl_DauTu.VuTrongID =" + VuTrongID + " AND dbo.tbl_DauTu.HopDongID=" + ID.ToString() + " AND dbo.tbl_DauTu.LaiSuat >0 AND ISNULL(dbo.tbl_DauTu.SoTienTinhLaiSauHT,0)<=0) AND (dbo.tbl_DauTu.DanhMucDauTuID= 207196 OR  dbo.tbl_DauTu.DanhMucDauTuID= 452672)";

            DataSet ds = DBModule.ExecuteQuery(strSQL,null,null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdVHopDongDauTu.SetDataBinding(ds.Tables[0], "");
            }
            else{
                lbl_thongbao.Text=("Không có khoản đầu tư nào của hợp đồng vay tiền mặt có lãi để trừ");
               // MessageBox.Show("Không có đầu tư để trừ hay đã trừ rồi");
            }
        }
       
        private void gdVHopDongVanChuyen_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {

            this.SendID();
            this.DialogResult = DialogResult.OK;
            Close();             
          
        }

        private void gdVHopDongVanChuyen_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            //this.SendID();
            //Close();    
        }

        
    }
}