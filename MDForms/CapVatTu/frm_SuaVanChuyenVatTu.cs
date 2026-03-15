using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms.CapVatTu
{
    public partial class frm_SuaVanChuyenVatTu : Form
    {
        public int OK = 0;
        public long _ID = -1;
        public frm_SuaVanChuyenVatTu()
        {
            InitializeComponent();
        }
        public frm_SuaVanChuyenVatTu(long IDVatTu)
        {
            InitializeComponent();
            _ID = IDVatTu;
            clsNhanVatTu oNVT = new clsNhanVatTu(IDVatTu);
            oNVT.Load(null, null);
            lblSoLuong.Text = oNVT.SoLuong.ToString();
           lblSoTien.Text =oNVT.TienVanChuyen.ToString();
           nDonGia.Value = oNVT.DonGiaVanChuyen;

           
        }       
       
     
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
                   if (_ID > 0)
                    {
                        string sqlcapnhat = "Update tbl_NhanVatTu set DonGiaVanChuyen=" + decimal.Parse(nDonGia.Value.ToString()) + ",TienVanChuyen =" + Math.Round(decimal.Parse(lblSoTien.Text),0) + " WHERE ID = " + _ID;
                        DBModule.ExecuteNonQuery(sqlcapnhat, null, null);
                        OK = 1;
                        this.Close();
                    }
        }

        private void nDonGia_ValueChanged(object sender, EventArgs e)
        {
            lblSoTien.Text = (decimal.Parse(lblSoLuong.Text) * nDonGia.Value/1000).ToString();
        }
             
  
    
     }
}
