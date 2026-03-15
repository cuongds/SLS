using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SLSCCSEntities;
using Janus.Windows.GridEX;

namespace MDSolution.MDForms.HoTro
{
    public partial class frm_ChietTinhCongNo_DanhSach : Form
    {
        public DataTable dtDataSearch { get; set; }
        public frm_ChietTinhCongNo_DanhSach()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LoadChietTinh();
        }
        void LoadChietTinh()
        {
            //Tìm kiếm tất cả nhập mía của hđ đầu tư./
            string sql = @"SELECT *
                          FROM tbl_ThanhToan_ChietTinhCongNo where 1=1";

            grvChietTinhCongNo.SetDataBinding(DBModule.ExecuteQuery(sql, null, null).Tables[0], "");

        }
        void LoadNhapMia(string CTID)
        {
            //Tìm kiếm tất cả nhập mía của hđ đầu tư./
            string sql = @"SELECT *
                          FROM V2016_ChietTinhTruNoDauTu_NhapMia where DaThanhToan=" + CTID;

            grvNhapMia.SetDataBinding(DBModule.ExecuteQuery(sql, null, null).Tables[0], "");

            foreach (Janus.Windows.GridEX.GridEXRow row in grvNhapMia.GetDataRows())
            {
                if (row.RowType == RowType.Record)
                {
                    row.BeginEdit();
                    row.Cells["ConLai"].Value = (decimal)row.Cells["ThanhTien"].Value - (decimal)row.Cells["SoTienThuNo"].Value;
                    row.EndEdit();
                }
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {


        }

        private void uiGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void grvChietTinhCongNo_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grvChietTinhCongNo_RowDoubleClick(object sender, RowActionEventArgs e)
        {

        }

        private void grvChietTinhCongNo_SelectionChanged(object sender, EventArgs e)
        {
            LoadNhapMia(grvChietTinhCongNo.GetRow().Cells["ID"].Value.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnInChietTinhCN_Click(object sender, EventArgs e)
        {
            if (grvChietTinhCongNo.GetRow() != null)
            {
                string[] paramNames = new string[] { "DaThanhToan", "VuTrongID" };
                string[] paraValues = new string[] { grvChietTinhCongNo.GetRow().Cells["ID"].Value.ToString(), MDSolutionApp.VuTrongID.ToString() };
                CommonClass.ShowReport("ThanhToan2016\\ChietTinhCongNoTheoHoChiTiet.rpt", "Chiết tính công nợ", paramNames, paraValues, null);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chiết tính công nợ", "Thông báo");
            }
        }

        private void grvChietTinhCongNo_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "EditTienTruNo")
            {

                string[] paramNames = new string[] { "DaThanhToan", "VuTrongID" };
                string[] paraValues = new string[] { grvChietTinhCongNo.GetRow().Cells["ID"].Value.ToString(), MDSolutionApp.VuTrongID.ToString() };
                CommonClass.ShowReport("ThanhToan2016\\ChietTinhCongNoTheoHoChiTiet.rpt", "Chiết tính công nợ", paramNames, paraValues, null);
                
            }
        }

        private void frm_ChietTinhCongNo_DanhSach_Load(object sender, EventArgs e)
        {

        }


    }
}
