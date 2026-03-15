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
    public partial class frm_ChonCBDB : Form
    {
        private long VUNGNL_ID = -1;
        private long LA_NHOM_TRUONG = 0;
        private string TEN_VUNG = "";
        public long OK = -1;
        clsCacVungNguyenLieu_CBDB oCBDB_VNL = new clsCacVungNguyenLieu_CBDB();
        public frm_ChonCBDB()
        {
            InitializeComponent();
        }

        public frm_ChonCBDB(long VungID,string TenVung)
        {
            InitializeComponent();
            VUNGNL_ID = VungID;
            TEN_VUNG = TenVung;
            this.lblVung.Text = TenVung;
            LoadCBDB();
        }
        private void LoadCBDB()
        {
            string sql = "Select ID,Ten From tbl_DanhMucCanBoNongVu Where ID!=22 AND ID Not In(Select CBDBID From tbl_CacVungNguyenLieu_CBDB Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + ")";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cboCBNV.DataSource = ds.Tables[0];
                cboCBNV.ValueMember = "ID";
                cboCBNV.DisplayMember = "Ten";
            }
            else
            {
                cboCBNV.DataSource = null;
                cboCBNV.Text = "";
            }
        }
      
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool VerifyData()
        {
            if (cboCBNV.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn CBĐB!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                cboCBNV.Focus();
                return false;
            }
            if (LA_NHOM_TRUONG > 0)
            {
                if (clsCacVungNguyenLieu.CheckTruongVung(VUNGNL_ID, null, null))
                {
                    MessageBox.Show("Vùng nguyên liệu: " + TEN_VUNG + " đã có trưởng vùng!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            return true;
        }
        private void cmdLuu_Click(object sender, EventArgs e)
        {
            if (VerifyData())
            {
                try
                {
                    oCBDB_VNL.CBDBID = long.Parse(cboCBNV.SelectedValue.ToString());
                    oCBDB_VNL.VungNguyenLieuID = VUNGNL_ID;
                    oCBDB_VNL.NhomTruong = LA_NHOM_TRUONG;
                    oCBDB_VNL.Save(null, null);
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

     
        private void chkLaTruongNhom_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLaTruongNhom.Checked)
            {
                LA_NHOM_TRUONG = 1;
            }
            else
            {
                LA_NHOM_TRUONG = 0;
            }
        }

    
    }
}