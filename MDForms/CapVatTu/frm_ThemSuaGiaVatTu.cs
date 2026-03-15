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
    public partial class frm_ThemSuaGiaVatTu : Form
    {
        public int OK = 0;
        public long _IDVATU = 0;
        public long _ID = -1;
        public frm_ThemSuaGiaVatTu()
        {
            InitializeComponent();
        }
        public frm_ThemSuaGiaVatTu(long VatTuID,string TenVT, string DVT)
        {
            InitializeComponent();
            _IDVATU = VatTuID;
            lblTenVT.Text = TenVT;
            lblDVT.Text = "(VNĐ/" + DVT + ")";
            dtNgayApDung.Value = DateTime.Now;
        }
        public frm_ThemSuaGiaVatTu(long GiaID)
        {
            InitializeComponent();
            _ID = GiaID;
            clsGiaVatTu oGia = new clsGiaVatTu(_ID);
            oGia.Load(null, null);
            clsDanhMucVatTu oDMVT = new clsDanhMucVatTu(oGia.VatTuID);
            oDMVT.LoadByVatTuID(null, null);
            lblTitle.Text="SỬA GIÁ VẬT TƯ";
            lblTenVT.Text = oDMVT.Ten;
            lblDVT.Text = "(VNĐ/" + oDMVT.DonViTinh + ")";
            nDonGia.Value = oGia.DonGia;
            dtNgayApDung.Value = oGia.NgayApDung;
         }
       
     
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
                   if (_ID <= 0)
                    {
                        clsGiaVatTu objGiaVT = new clsGiaVatTu();//Thêm giá vật tư
                        objGiaVT.VatTuID=_IDVATU;
                        objGiaVT.DonGia = nDonGia.Value;
                        objGiaVT.NgayApDung=dtNgayApDung.Value.Date;
                        objGiaVT.Save(null,null);
                        _IDVATU=objGiaVT.ID;
                    }
                    else
                    {
                        clsGiaVatTu objGiaVT = new clsGiaVatTu(_ID);//sửa giá vật tư
                        objGiaVT.Load(null,null);
                        objGiaVT.DonGia = nDonGia.Value;
                        objGiaVT.NgayApDung=dtNgayApDung.Value.Date;
                        objGiaVT.Save(null,null);
                    }
                    OK = 1;
                    this.Close();
        }
             
  
    
     }
}
