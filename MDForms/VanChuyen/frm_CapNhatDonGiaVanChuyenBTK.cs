using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms.VanChuyen
{
    public partial class frm_CapNhatDonGiaVanChuyenBTK : Form
    {
        public long OK = 0;
        public frm_CapNhatDonGiaVanChuyenBTK()
        {
            InitializeComponent();
            string sqlNgay = "Select Convert(Char(10),GetDate(),121)";
            DateTime dt = Convert.ToDateTime(DBModule.ExecuteQueryForOneResult(sqlNgay, null, null));
            dtNgayApDung.Value = dt;
        }
    
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chương trình sẽ cập nhật đơn giá vận chuyển cho tất cả các bãi tập kết\ndựa vào đơn giá mới nhất có từ trước ứng với mỗi bãi tập kết\nBạn chắc chắn cập nhật theo như các thiết lập đã chọn?", "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            string sql = "sp_CapNhatCuocVanChuyen " + MDSolutionApp.VuTrongID.ToString() + "," + DBModule.RefineDatetime(dtNgayApDung.Value) + "," + DBModule.RefineNumber(nDonGia.Value);
            try
            {
                DBModule.ExecuteNonQuery(sql, null, null);
                MessageBox.Show("Đã cập nhật thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OK = 1;
              
            }
            catch 
            {
                MessageBox.Show("Đã có lỗi xảy ra\nCập nhật không thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }
     }
}
