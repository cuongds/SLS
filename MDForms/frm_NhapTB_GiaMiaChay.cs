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
    public partial class frm_NhapTB_GiaMiaChay : Form
    {
        public int OK=0;
        public long ID_TB = -1;
        public long ID_Gia=-1;
        public long MaxID=-1;
        public frm_NhapTB_GiaMiaChay(long ThongBaoID, string TenThongBao)
        {
            InitializeComponent();
            ID_TB = ThongBaoID;
            lblTenTB.Text = TenThongBao;
        }

        public frm_NhapTB_GiaMiaChay(long ID, long ThongBaoID)
        {
            InitializeComponent();
            lblTitle.Text = "SỬA CHI TIẾT GIÁ MÍA CHÁY";
            grTT.Text = "Sửa dữ liệu";
            cmdOK.Text = "Sửa";
            ID_TB = ThongBaoID;
            ID_Gia = ID;
            cls_GiaMia_ThongBao oGM_TB = new cls_GiaMia_ThongBao(ID_TB);
            oGM_TB.Load(null, null);
            lblTenTB.Text = oGM_TB.TenThongBao;
            cls_GiaMiaChayTheoThongBao oGM = new cls_GiaMiaChayTheoThongBao(ID_Gia);
            oGM.Load(null, null);
            nTuGio.Value = oGM.TuGio;
            nDenGio.Value = oGM.DenGio;
            nGiaMiaChay.Value = oGM.DonGiaMiaChay;
           

        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            OK = 1;
            if (ID_Gia < 0)
            {
                try
                {
                    cls_GiaMiaChayTheoThongBao oCTGM = new cls_GiaMiaChayTheoThongBao();
                    oCTGM.TuGio= nTuGio.Value;
                    oCTGM.DenGio = nDenGio.Value;
                    oCTGM.DonGiaMiaChay = nGiaMiaChay.Value;
                    oCTGM.ThongBaoID = ID_TB;
                    oCTGM.Save(null, null);
                    MaxID = oCTGM.FindMaxID();
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
                this.Close();
            }
            else
            {
            try
            {
                cls_GiaMiaChayTheoThongBao oCTGM = new cls_GiaMiaChayTheoThongBao(ID_Gia);
                oCTGM.Load(null, null);
                oCTGM.TuGio = nTuGio.Value;
                oCTGM.DenGio = nDenGio.Value;
                oCTGM.DonGiaMiaChay = nGiaMiaChay.Value;
                oCTGM.ThongBaoID = ID_TB;
                oCTGM.Save(null, null);
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
            }
          
        }

       
    }
}
