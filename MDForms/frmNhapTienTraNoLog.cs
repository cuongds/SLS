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
    public partial class frmNhapTienTraNoLog : Form
    {
        public frmNhapTienTraNoLog()
        {
            InitializeComponent();
        }
        public DateTime DateView;
        private void btnDaXem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đã đọc và không muốn hiển thị các thông tin này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                string sql = "update sys_User set DateReadNotify={0} where ID={1}";
                DBModule.ExecuteNonQuery(string.Format(sql, DBModule.RefineDatetime(DateView), MDSolutionApp.User.ID), null, null);
                this.Close();
            }
        }

        private void frmNhapTienTraNoLog_Load(object sender, EventArgs e)
        {

        }

        private void gdHopDongLog_SelectionChanged(object sender, EventArgs e)
        {
           // ribNoiDung.Text = gdHopDongLog.GetValue("NoiDung").ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdexcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = gdHopDongLog;
                        exporter.Export(fs);
                        fs.Close();
                        MessageBox.Show("Đã xuất dữ liệu ra Excel!", "SLS", MessageBoxButtons.OK);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
