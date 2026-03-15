using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms.ThuHoach
{
    public partial class frm_LapKeHoach : Form
    {
        public long _ID = -1;
        private DateTime NgayHienHanh = DateTime.Now;
        public long OK = -1;
        public frm_LapKeHoach()
        {
            InitializeComponent();
        }
    
      
        private void cmdClose_Click(object sender, EventArgs e)
        {
            OK = -1;
            this.Close();
        }
        private bool VerifyData()
        {
            return true;
        }
        private void cmdLuu_Click(object sender, EventArgs e)
        {
            if(clsKeHoachSanLuong.CheckKeHoach(dtNgayKeHoach.Value.ToString("yyyy-MM-dd"),null,null))
            {
                MessageBox.Show("Đã tồn tại kế hoạch ngày " + dtNgayKeHoach.Value.ToString("dd/MM/yyyy"), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn lập Kế hoạch ngày " + dtNgayKeHoach.Value.ToString("dd/MM/yyyy")+"\nvới khoảng thời gian như đã chọn?", "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            try
            {
                clsKeHoachSanLuong oKH = new clsKeHoachSanLuong();
                oKH.NgayKeHoach = dtNgayKeHoach.Value;
                oKH.ThoiGianBatDau = dtTuNgay.Value;
                oKH.ThoiGianKetThuc = dtDenNgay.Value;
                if (chkKhongChe.Checked)
                {
                    oKH.KhongChe = 1;
                }
                else
                {
                    oKH.KhongChe = 0;
                }
                oKH.Save(null, null);
                _ID = oKH.ID;
                OK = 1;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu kế hoạch ngày " + dtNgayKeHoach.Value.ToString("dd/MM/yyyy"), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OK = -1;
                return;
            }
        
        }

        private void dtNgayKeHoach_ValueChanged(object sender, EventArgs e)
        {
            if(dtNgayKeHoach.Value<NgayHienHanh)
            {
                dtNgayKeHoach.Value = NgayHienHanh;
            }
            dtTuNgay.Value = dtNgayKeHoach.Value;
        }

        private void frm_LapKeHoach_Load(object sender, EventArgs e)
        {
            DataSet ds = DBModule.ExecuteQuery("select YEAR(GETDATE()) as Nam, MONTH(GETDATE()) as Thang, DAY(GETDATE()) as Ngay", null, null);
            int Nam = int.Parse(ds.Tables[0].Rows[0]["Nam"].ToString());
            int Thang = int.Parse(ds.Tables[0].Rows[0]["Thang"].ToString());
            int Ngay = int.Parse(ds.Tables[0].Rows[0]["Ngay"].ToString());
            NgayHienHanh = new DateTime(Nam, Thang, Ngay, 0, 0, 0);
            dtNgayKeHoach.Value = NgayHienHanh;
            dtDenNgay.Value = dtTuNgay.Value.AddSeconds(86399);
       }

        private void dtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if ((dtTuNgay.Value < dtNgayKeHoach.Value)||(dtTuNgay.Value > dtNgayKeHoach.Value.AddSeconds(86399)))
            {
                dtTuNgay.Value = dtNgayKeHoach.Value;
            }
            dtDenNgay.Value = dtTuNgay.Value.AddSeconds(86399);
        }

   
   
    }
}