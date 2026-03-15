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
    public partial class frmConfirm : Form
    {
        public bool OK = false;
        public decimal TangPhanTram = 0;
        public frmConfirm()
        {
            InitializeComponent();
        }
        public frmConfirm(bool Add)
        {
            InitializeComponent();                     
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            OK = false;
            this.Close();
        }

        private void frmConfirm_Load(object sender, EventArgs e)
        {
            
        }            
        private void cmdOK_Click(object sender, EventArgs e)
        {
            OK = true;
            TangPhanTram = decimal.Parse(nDonGia.Value.ToString());
            this.Close();
        }
    }       
}
