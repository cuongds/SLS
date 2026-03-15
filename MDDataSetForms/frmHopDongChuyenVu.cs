using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDDataSetForms
{
    public partial class frmHopDongChuyenVu : Form
    {
        public frmHopDongChuyenVu()
        {
            InitializeComponent();
        }

        private void btGhiNhan_Click(object sender, EventArgs e)
        {
            try
            {
                long HDID;
                HDID = long.Parse(HopDongUIDCombobox.SelectedValue.ToString());
                long VTID;
                VTID = long.Parse(VuTrongUIDCombobox.SelectedValue.ToString());

                string sql = "INSERT INTO dbo.tbl_HopDongVuTrong([HopDongID],[VuTrongID])VALUES (" + HDID + "," + VTID + ")";
                DBModule.ExecuteNonQuery(sql, null, null);
                MessageBox.Show("Chuyển hợp đồng thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message.ToString(), "Hợp đồng đã được chuyển rồi");
            }

        }

        private void frmHopDongChuyenVu_Load(object sender, EventArgs e)
        {
            try
            {
                //load hopdong
                string sqlHD = "select ID,MaHopDong from tbl_hopdong";
                DataSet ds1 = new DataSet();
                ds1 = DBModule.ExecuteQuery(sqlHD, null, null);
                HopDongUIDCombobox.DataSource = ds1.Tables[0];
                HopDongUIDCombobox.DisplayMember = "MaHopDong";
                HopDongUIDCombobox.ValueMember = "ID";
                // load vutrong
                string sqlVT = "select * from tbl_vutrong";
                VuTrongUIDCombobox.DataSource = DBModule.ExecuteQuery(sqlVT, null, null).Tables[0];
                VuTrongUIDCombobox.ValueMember = "ID";
                VuTrongUIDCombobox.DisplayMember = "Ten";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message.ToString(), "Không có hợp đồng này");
            }
        }

        private void uiButtonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void HopDongUIDCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql_Tenchuhopdong = "select HoTen from tbl_hopdong where ID=" + HopDongUIDCombobox.SelectedValue.ToString();
            lbl_HoTen.Text = DBModule.ExecuteQueryForOneResult(sql_Tenchuhopdong, null, null);
        }
    }
}