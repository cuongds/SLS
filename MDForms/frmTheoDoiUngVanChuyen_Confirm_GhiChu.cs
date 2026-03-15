using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms
{
    public partial class frmTheoDoiUngVanChuyen_Confirm_GhiChu : Form
    {
        public int ID;
        public frmTheoDoiUngVanChuyen_Confirm_GhiChu(int IDUngVanChuyen, bool Add = true)
        {
            InitializeComponent();
            ID = IDUngVanChuyen;
            clsUngVatTuVanChuyen objUngVC = new clsUngVatTuVanChuyen(IDUngVanChuyen);
            objUngVC.Load(null, null);
            clsXeVanChuyen objXeVC = new clsXeVanChuyen(objUngVC.XeID);
            objXeVC.Load(null, null);
            clsHopDongVanChuyen objHDVC = new clsHopDongVanChuyen(objUngVC.HopDongVanChuyenID);
            objHDVC.Load(null, null);
            lbl_HopDongVC.Text = objHDVC.TenChuHopDong;
            lbl_SoXe.Text = objXeVC.SoXe;
            lbl_SoPhieu.Text = objUngVC.SoChungTu;
            lbl_LaiXe.Text = objXeVC.TenLaiXe;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            string sqlupdate_GhiChu = "Update tbl_UngVatTuVanChuyen Set GhiChu=N'" + txtGhiChu.Text + "' Where ID=" + ID;
            try
            {
                DBModule.ExecuteNoneBackup(sqlupdate_GhiChu, null, null);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


    }
}
