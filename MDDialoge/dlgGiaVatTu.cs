using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace MDSolution.MDDialoge
{
    public partial class dlgGiaVatTu : Form
    {
        // Thiet lap vu trong
        string VuTrongID = MDSolutionApp.VuTrongID.ToString();
        // Thiet lap vu trong
        clsGiaVatTu oGVT = new clsGiaVatTu();

        public delegate void PassID(string value);
        public PassID passID;
        public string VatTuID = " ";

        //private void SendID()
        //{
        //    if (passID != null)
        //    {
        //        try
        //        {
        //            passID(this.gdGiaVatTu.GetValue("ID").ToString());
        //        }
        //        catch
        //        {
        //            passID("-1");
        //        }
        //    }
        //}
        public dlgGiaVatTu()
        {
            InitializeComponent();
            LoadGrid();
        }
        public dlgGiaVatTu(String strVatTuID)
        {

            InitializeComponent();
            VatTuID = strVatTuID;
            LoadGrid();

        }

        public void LoadGrid()
        {
            string strSQL = "";
            strSQL = "Select * FROM tbl_GiaVatTu where VatTuID = " + VatTuID + " AND VuTrongID = " + VuTrongID;

            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables.Count > 0)
            {
                this.gdGiaVatTu.SetDataBinding(ds.Tables[0], "");
            }
        }

        private void gdVHopDongVanChuyen_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            //frmNhapMia.MaKVC = this.gdVHopDongVanChuyen.GetValue("MaHopDong").ToString().Trim();
            //this.SendID();
            //this.DialogResult = DialogResult.OK;
            //Close();           

        }

        private void gdVHopDongVanChuyen_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {

        }

        private void gdGiaVatTu_AddingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                oGVT = new clsGiaVatTu();
                if (string.IsNullOrEmpty(this.gdGiaVatTu.GetValue("NgayApDung").ToString())) throw new Exception("Bạn chưa nhập áp dụng");
                if (string.IsNullOrEmpty(this.gdGiaVatTu.GetValue("DonGia").ToString())) throw new Exception("Bạn chưa nhập đơn giá");
                oGVT.DonGia = long.Parse(this.gdGiaVatTu.GetValue("DonGia").ToString());
                oGVT.NgayApDung = DateTime.Parse(this.gdGiaVatTu.GetValue("NgayApDung").ToString());
                oGVT.GhiChu = this.gdGiaVatTu.GetValue("GhiChu").ToString();
                oGVT.VatTuID = long.Parse(VatTuID);
                oGVT.VuTrongID = long.Parse(VuTrongID);
                oGVT.IsActive =long.Parse(this.gdGiaVatTu.GetValue("IsActive").ToString());
                oGVT.Save(null, null);
                MessageBox.Show("Bạn đã lưu lại thành công", "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
            }
            catch { }


        }

        private void gdGiaVatTu_RecordUpdated(object sender, EventArgs e)
        {
            try
            {
               
                oGVT = new clsGiaVatTu();
                if (string.IsNullOrEmpty(this.gdGiaVatTu.GetValue("NgayApDung").ToString())) throw new Exception("Bạn chưa nhập áp dụng");
                if (string.IsNullOrEmpty(this.gdGiaVatTu.GetValue("DonGia").ToString())) throw new Exception("Bạn chưa nhập đơn giá");
                oGVT.ID = long.Parse(this.gdGiaVatTu.GetValue("ID").ToString());
                oGVT.DonGia = long.Parse(this.gdGiaVatTu.GetValue("DonGia").ToString());
                oGVT.NgayApDung = DateTime.Parse(this.gdGiaVatTu.GetValue("NgayApDung").ToString());
                oGVT.GhiChu = this.gdGiaVatTu.GetValue("GhiChu").ToString();
                oGVT.VatTuID = long.Parse(VatTuID);
                oGVT.VuTrongID = long.Parse(VuTrongID);
                oGVT.IsActive = long.Parse(this.gdGiaVatTu.GetValue("IsActive").ToString());
                oGVT.Save(null, null);
                MessageBox.Show("Bạn đã sửa lại thành công", "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
            }
            catch { }

        }
    }
}