using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
namespace MDSolution.MDFoms.CapVatTu
{
    public partial class frmConfirm : Form
    {
        public long OK = 0;
        public frmConfirm()
        {
            InitializeComponent();
        }
        public frmConfirm(string TenVT, string CoTinhCuoc, decimal PhanTram, string SoHDVC, string SoXe,bool Add)
        {
            InitializeComponent();
            lblTenVT.Text = TenVT;
            lblCoTinhCuoc.Text = CoTinhCuoc;
            lblHDVC.Text = SoHDVC;
            nPhanTram.Value = PhanTram;
            lblSoXe.Text = SoXe;
            if (Add == false)
            {
                lblTitle.Text = "Bạn chắc chắn sửa phiếu cấp vật tư có thông tin dưới đây?";
            }
          
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            OK = 0;
            this.Close();
        }

        private void frmConfirm_Load(object sender, EventArgs e)
        {
            Timer tmr = new Timer();
            tmr.Interval = 500;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
            lblTitle.ForeColor = Color.Red; //Set The Default Color As Re
        }
     
        void tmr_Tick(object sender, EventArgs e)
        {
            if (lblTitle.ForeColor == Color.Red)
            {
                lblTitle.ForeColor = Color.Green;
            }
            else if (lblTitle.ForeColor == Color.Green)
            {
                lblTitle.ForeColor = Color.Red;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            OK = 1;
            this.Close();
        }
    }       
}
