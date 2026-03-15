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
    public partial class frm_ChonUuTien : Form
    {                
        public long OK = -1;
        private long IDLenh = 0;        
        public frm_ChonUuTien()
        {
            InitializeComponent();
        }

        public frm_ChonUuTien(long LenhID, string SoLenh)
        {
            InitializeComponent();
            this.lblLenh.Text = SoLenh;
            IDLenh = LenhID;
            LoadLoaiUuTien();
        }
        private void LoadLoaiUuTien()
        {
            string sql = "select ID,TenUuTien AS Ten from tbl_LoaiXeUuTien";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboLoaiUuTien.DataSource = ds.Tables[0];
                cboLoaiUuTien.ValueMember = "ID";
                cboLoaiUuTien.DisplayMember = "Ten";
            }
            else
            {
                cboLoaiUuTien.DataSource = null;
                cboLoaiUuTien.Text = "";
            }
        }
      
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool VerifyData()
        {
            if (cboLoaiUuTien.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn CBĐB!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                cboLoaiUuTien.Focus();
                return false;
            }           
            return true;
        }
        private void cmdLuu_Click(object sender, EventArgs e)
        {
            if (VerifyData())
            {
                string sql = "update tbl_LenhChatMia set LoaiXeUuTienId=" + long.Parse(cboLoaiUuTien.SelectedValue.ToString()) + "where ID=" + IDLenh;
                try
                {
                    DBModule.ExecuteNoneBackup(sql, null, null);                                  
                    OK = 1;
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Đã có lỗi\n"+ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
             
            }
        }
    }
}