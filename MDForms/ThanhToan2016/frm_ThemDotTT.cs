using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms.ThanhToan2016
{
    public partial class frm_ThemDotTT : Form
    {
        public frm_ThemDotTT()
        {
            InitializeComponent();
        }

        private void frm_ThemDotTT_Load(object sender, EventArgs e)
        {
            dtNgayChot.Value = DateTime.Now;
            LoadDotTT();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Tên đợt không để trống.");
                txtTen.Focus();
                return;
            }
            if (dtNgayBatDau.IsNullDate)
            {
                MessageBox.Show("Ngày bắt đầu không để trống.");
                dtNgayBatDau.Focus();
                return;
            }
            if (dtNgayChot.IsNullDate)
            {
                MessageBox.Show("Ngày chốt đợt không để trống.");
                dtNgayChot.Focus();
                return;
            }
            string sql = @"INSERT INTO [tbl_DotThanhToan]
                                   ([Ten]
                                   ,[GhiChu]
                                   ,[VuTrongID]
                                   ,[NgayChotDot]
                                   ,[NgayBatDau])
                             VALUES
                                   (N'{0}'
                                   ,N'{1}'
                                   ,{2}
                                   ,N'{3}'
                                   ,N'{4}')";
            try
            {
                DBModule.ExecuteNonQuery(string.Format(sql, txtTen.Text, txtGhiChu.Text, MDSolutionApp.VuTrongID, dtNgayChot.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtNgayBatDau.Value.ToString("yyyy-MM-dd HH:mm:ss")), null, null);
                txtTen.Text = "";
                txtGhiChu.Text = "";
                dtNgayChot.Value = DateTime.Now;
                dtNgayBatDau.Value = DateTime.Now;
                LoadDotTT();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật dữ liệu:" + ex.Message);
            }

        }
        void LoadDotTT()
        {

            //Tìm kiếm tất cả nhập mía của hđ đầu tư./
            string sql = @"SELECT *
                          FROM tbl_DotThanhToan where VuTrongID={0} ";

            grvDotTT.SetDataBinding(DBModule.ExecuteQuery(string.Format(sql, MDSolutionApp.VuTrongID), null, null).Tables[0], "");

           // grvDotTT.Refresh();

        }

        private void grvDotTT_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa dữ liệu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                //check có phiếu tt?
                string id = grvDotTT.GetRow().Cells["ID"].Value.ToString();
                string sql = "select count(*) from tbl_ThanhToanMia where DotThanhToanID={0}";
                if (DBModule.ExecuteQueryForOneResult(string.Format(sql, id), null, null) != "0")
                {
                    MessageBox.Show("Đợt đã thanh toán, không xóa được.");                  
                    return;
                }
                sql = "delete tbl_DotThanhToan where id={0}";
                try
                {
                    DBModule.ExecuteNonQuery(string.Format(sql, id), null, null);
                    MessageBox.Show("Đã xóa thành công.");                      
                    LoadDotTT();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật dữ liệu:" + ex.Message);
                }
            }
        }
    }
}
