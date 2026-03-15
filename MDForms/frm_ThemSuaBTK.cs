using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDSolution
{
    public partial class frm_ThemSuaBTK : Form
    {
        public int OK = 0;
        public long ID_BTK = 0;
        public long ID_BTKGC = 0;
        public long ID_Thon = 0;
        public frm_ThemSuaBTK()
        {
            InitializeComponent();
        }
        public frm_ThemSuaBTK(long ThonID)
        {
            InitializeComponent();
            ID_Thon = ThonID;
            dtNgayApDung.Value = DateTime.Now.Date;
        }
        public frm_ThemSuaBTK(long BTKID,long BTKGCID, long ThonID)
        {
            InitializeComponent();
            ID_BTK = BTKID;
            ID_BTKGC = BTKGCID;
            ID_Thon = ThonID;
            if (ID_BTK > 0)
            {
                lblTram.Text="SỬA DANH MỤC BÃI TẬP KẾT";
                clsBaiTapKet objBTKSua = new clsBaiTapKet(ID_BTK);
                objBTKSua.Load(null, null);
                txtTenBai.Text = objBTKSua.TenBai;
                nKhoangCach.Value = objBTKSua.KhoangCach;
                txtGhiChu.Text = objBTKSua.GhiChu;
            }
            if (ID_BTKGC > 0)
            {
                clsBaiTapKet_GiaCuoc oBTKGC = new clsBaiTapKet_GiaCuoc(ID_BTKGC);
                oBTKGC.Load(null, null);
                lblDotApDung.Text = oBTKGC.DotApDung.ToString();
                nDonGiaApDung.Value = oBTKGC.DonGia;
                dtNgayApDung.Value = oBTKGC.NgayApDung;
            }
                    
         }
        private bool Verify()
        {
            if (txtTenBai.Text == "")
            {
                MessageBox.Show("Chưa có tên bãi bốc xếp!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenBai.Focus();
                return false;
            }
           
            return true;
        }
        private bool Check(string value, long ID)
        {
            string ret = "";
            if (ID > 0)
            {
                ret = DBModule.ExecuteQueryForOneResult("Select TenBai from tbl_BaiTapKet Where Lower(Replace(TenBai,' ',''))=N'" + value + "' and ThonID=" + ID_Thon.ToString(), null, null).ToString();
                if (string.IsNullOrEmpty(ret))
                {
                    return true;
                }
                else
                {
                    long lID = long.Parse(DBModule.ExecuteQueryForOneResult("Select ID from tbl_BaiTapKet Where Lower(Replace(TenBai,' ',''))=N'" + value + "' and ThonID=" + ID_Thon.ToString(), null, null).ToString());
                    if (ID == lID)
                    {
                        return true;
                    }
                    else return false;
                }

            }
            else
            {
                ret = DBModule.ExecuteQueryForOneResult("Select TenBai from tbl_BaiTapKet Where Lower(Replace(TenBai,' ',''))=N'" + value + "' and ThonID=" + ID_Thon.ToString(), null, null).ToString();
                if (string.IsNullOrEmpty(ret)) { return true; } else { return false; }
            }
        }
     
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
           if (Verify())
            {
                if (Check(txtTenBai.Text.Replace(" ", ""), ID_BTK))
                {
                    if (ID_BTK <= 0)
                    {
                        clsBaiTapKet objBTK = new clsBaiTapKet();//Thêm Bãi tập kết
                        objBTK.TenBai = txtTenBai.Text;
                        objBTK.KhoangCach = nKhoangCach.Value;
                        objBTK.DonGia = nDonGiaApDung.Value;
                        objBTK.NgayApDung = dtNgayApDung.Value;
                        objBTK.ThonID = ID_Thon;
                        objBTK.GhiChu = txtGhiChu.Text;
                        objBTK.Save(null, null);
                        ID_BTK = objBTK.ID;
                        clsBaiTapKet_GiaCuoc oBTKGC = new clsBaiTapKet_GiaCuoc();//Thêm bãi tập kết-giá cước
                        oBTKGC.BaiTapKetID = ID_BTK;
                        oBTKGC.DonGia = nDonGiaApDung.Value;
                        oBTKGC.NgayApDung = dtNgayApDung.Value;
                        oBTKGC.VuTrongID = MDSolutionApp.VuTrongID;
                        oBTKGC.DotApDung = clsBaiTapKet_GiaCuoc.DotApDungMax(MDSolutionApp.VuTrongID);
                        oBTKGC.GhiChu = txtGhiChu.Text;
                        oBTKGC.DonGiaVanChuyenVatTu = nDonGiaApDung.Value;
                        oBTKGC.NgayAD_GiaVC_VT = dtNgayApDung.Value;
                        oBTKGC.Save(null, null);
                        clsBaiTapKet_GiaCuoc.Add_DotGia(ID_BTK, oBTKGC.DotApDung, nDonGiaApDung.Value);
                        //string sql = "sp_CapNhatCuocVanChuyen_Dot " + MDSolutionApp.VuTrongID.ToString() + "," + ID_BTK.ToString() + "," + oBTKGC.DotApDung.ToString() + "," + nDonGiaApDung.Value.ToString();
                        //DBModule.ExecuteNonQuery(sql, null, null);
                    }
                    else
                    {
                        clsBaiTapKet objBTKSua = new clsBaiTapKet(ID_BTK);//update Bãi tập kết
                        objBTKSua.Load(null, null);
                        objBTKSua.TenBai = txtTenBai.Text;
                        objBTKSua.KhoangCach = nKhoangCach.Value;
                        objBTKSua.DonGia = nDonGiaApDung.Value;
                        objBTKSua.NgayApDung = dtNgayApDung.Value;
                        objBTKSua.ThonID = ID_Thon;
                        objBTKSua.GhiChu = txtGhiChu.Text;
                        objBTKSua.Save(null, null);
                        clsBaiTapKet_GiaCuoc oBTKGC = new clsBaiTapKet_GiaCuoc(ID_BTKGC);//Update bãi tập kết-giá cước
                        oBTKGC.Load(null, null);
                        oBTKGC.DonGia = nDonGiaApDung.Value;
                        oBTKGC.NgayApDung = dtNgayApDung.Value;
                        oBTKGC.GhiChu = txtGhiChu.Text;
                        oBTKGC.DonGiaVanChuyenVatTu = nDonGiaApDung.Value;
                        oBTKGC.NgayAD_GiaVC_VT = dtNgayApDung.Value;
                        oBTKGC.Save(null, null);
                    }
                    OK = 1;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đã tồn tại tên bãi bốc xếp trong bản!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
         }

    
     }
}
