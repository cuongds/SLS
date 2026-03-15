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
    public partial class frmConfirmGhiChu : Form
    {
        public long OK = 0;
        public long ID = 0;
        public frmConfirmGhiChu()
        {
            InitializeComponent();
        }
        public frmConfirmGhiChu(long Id)
        {
            InitializeComponent();
            ID = Id;
            try
            {
                clsXuatVatTu objXVT = new clsXuatVatTu(ID);
                objXVT.Load(null, null);
                clsDanhMucVatTu objDMVT = new clsDanhMucVatTu(objXVT.VatTuID);
                objDMVT.LoadByVatTuID(null, null);
                lblTenVT.Text = objDMVT.Ten;
                lblSoXe.Text = objXVT.SoXeThueNgoai;
                lbl_SoPhieu.Text = objXVT.SoPhieu.ToString();
                txtGhiChu.Text = objXVT.GhiChu;
            }
            catch (Exception ex)
            { }
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            OK = 0;
            this.Close();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {

            string sqlGhiChu = "update tbl_XuatVatTu set GhiChu = N'" + txtGhiChu.Text + "' where ID=" + ID;
            try
            {
                DBModule.ExecuteNoneBackup(sqlGhiChu, null, null);
                OK = 1;
                this.Close();
            }
            catch (Exception ex) { }
        }
    }
}
