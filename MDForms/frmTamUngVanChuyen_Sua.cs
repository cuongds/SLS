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
    public partial class frmTamUngVanChuyen_Sua : Form
    {
        public frmTamUngVanChuyen_Sua()
        {
            InitializeComponent();
        }
       public string ID;
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "update tbl_UngVatTuVanChuyen set    SoLuong={0},DonGia={1},SoTien={2},NgayUng={3} where ID={4}";
            DBModule.ExecuteNonQuery(string.Format(sql, numSoluong.Value, numDonGia.Value, numSoTien.Value, DBModule.RefineDatetime(dtNgayLap.Value), ID), null, null);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
