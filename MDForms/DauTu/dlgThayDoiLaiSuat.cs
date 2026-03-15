using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms.NhapMia
{
    public partial class dlgThayDoiLaiSuat : Form
    {
        public decimal laiSuat = 0;
        public DateTime ngayTinh = DateTime.Now;
        public dlgThayDoiLaiSuat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.laiSuat = nmLaiSuat.Value;
            this.ngayTinh = dtNgayTinhLai.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
