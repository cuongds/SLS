using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using MDSolution.MDForms;


namespace MDSolution.MDForms.CapVatTu
{
    public partial class frmDanhMucVatTu : Form
    {
       
        public frmDanhMucVatTu()
        {
            InitializeComponent();
            LoadDMDT();
            LoadDMVT();
        }
        private void LoadDMDT()
        {
            string strSQL = "SELECT  dbo.tbl_DanhMucDauTu.ID, dbo.tbl_DanhMucDauTu.Ten, dbo.tbl_LoaiHinhDauTu.Ten AS LoaiHinhDauTu, dbo.tbl_DanhMucDauTu.DonViTinh " +
                            "FROM   dbo.tbl_DanhMucDauTu INNER JOIN  dbo.tbl_LoaiHinhDauTu ON dbo.tbl_DanhMucDauTu.LoaiHinhDauTuID = dbo.tbl_LoaiHinhDauTu.ID Order By dbo.tbl_DanhMucDauTu.LoaiHinhDauTuID";
           DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
           if (ds.Tables[0].Rows.Count> 0)
            {
                this.gdDMDT.SetDataBinding(ds.Tables[0], "RootTable");
            }
        }
        private void LoadDMVT()
        {
            string strSQL = "SELECT * FROM   dbo.tbl_DanhMucVatTu";
            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDMCapVT.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdDMCapVT.DataSource = null;
            }
        }
        private void LoadGiaVatTu(long VTID)
        {
            string strSQL = "SELECT * FROM dbo.tbl_GiaVatTu Where VatTuID="+VTID.ToString();
            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdGia.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdGia.DataSource = null;
            }
        }
   
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool CheckChuyen(long ID)
        {
            long DanhMucVatTuID = -1;
            string sql = "Select DanhMucDauTuID From tbl_DanhMucVatTu Where DanhMucDauTuID=" + ID.ToString();
            try
            {
                DanhMucVatTuID=long.Parse(DBModule.ExecuteQueryForOneResult(sql,null,null));
            }
            catch { }
            if (DanhMucVatTuID > 0) return false; else return true;
        }
        private void cmdChuyen_Click(object sender, EventArgs e)
        {
            long ID_DMVT = -1;
            string TenVT = "";
            try
            {
            ID_DMVT=long.Parse(this.gdDMDT.GetValue("ID").ToString());
            TenVT = this.gdDMDT.GetValue("Ten").ToString();
            }
            catch { }
            if (ID_DMVT > 0)
            {
                if (MessageBox.Show("Bạn chắc chắn tạo mới danh mục vật tư \ntừ danh mục đầu tư: " + TenVT.ToUpper(), "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                if (CheckChuyen(ID_DMVT))
                {
                    try
                    {
                        clsDanhMucDauTu oDMDT = new clsDanhMucDauTu(ID_DMVT);
                        oDMDT.Load(null, null);
                        clsDanhMucVatTu oDMVT = new clsDanhMucVatTu();
                        oDMVT.DanhMucDauTuID = ID_DMVT;
                        oDMVT.DonViTinh = oDMDT.DonViTinh;
                        oDMVT.Ten = oDMDT.Ten;
                        oDMVT.Save(null, null);
                        LoadDMVT();
                        GridEXFilterCondition condi = new GridEXFilterCondition(this.gdDMCapVT.RootTable.Columns["DanhMucDauTuID"], ConditionOperator.Equal, ID_DMVT);
                        this.gdDMCapVT.Find(condi, 0, 1);
                    }
                    catch
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Đã tồn tại danh mục vật tư: "+TenVT.ToUpper(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        private void cmdKhongChuyen_Click(object sender, EventArgs e)
        {
            long ID_DMVT = -1;
            string TenVT = "";
            try
            {
                ID_DMVT = long.Parse(this.gdDMCapVT.GetValue("DanhMucDauTuID").ToString());
                TenVT = this.gdDMCapVT.GetValue("Ten").ToString();
            }
            catch { }
            if (ID_DMVT > 0)
            {
                if (MessageBox.Show("Bạn chắc chắn hủy danh mục: "+TenVT.ToUpper()+"\ncùng các thiết lập đơn giá (nếu có)", "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
             clsDanhMucVatTu.Delete(ID_DMVT,null,null);
             clsGiaVatTu.Delete(ID_DMVT, null, null);
             LoadDMVT();
             LoadGiaVatTu(ID_DMVT);
            }
        }

        private void gdDMCapVT_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "Add")
            {
                long ID_DMVT = -1;
                string TenVT = "";
                string DVT = "";
                try
                {
                    ID_DMVT = long.Parse(this.gdDMCapVT.GetValue("DanhMucDauTuID").ToString());
                    TenVT = this.gdDMCapVT.GetValue("Ten").ToString();
                    DVT = this.gdDMCapVT.GetValue("DonViTinh").ToString();
                }
                catch { }
                if (ID_DMVT > 0)
                {
                    MDForms.CapVatTu.frm_ThemSuaGiaVatTu frm = new MDForms.CapVatTu.frm_ThemSuaGiaVatTu(ID_DMVT, TenVT,DVT);
                    frm.ShowDialog();
                    if (frm.OK > 0)
                    {
                        LoadGiaVatTu(ID_DMVT);
                        GridEXFilterCondition condi = new GridEXFilterCondition(this.gdGia.RootTable.Columns["ID"], ConditionOperator.Equal, frm._IDVATU);
                        this.gdGia.Find(condi, 0, 1);
                    }
                }
            }
        }

        private void gdDMCapVT_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gdDMCapVT.CurrentRow.RowType == RowType.Record)
            {
                long ID_DMVT = -1;
                string TenVT = "";
                try
                {
                    ID_DMVT = long.Parse(this.gdDMCapVT.GetValue("DanhMucDauTuID").ToString());
                    TenVT = this.gdDMCapVT.GetValue("Ten").ToString();
                }
                catch { }
                if (ID_DMVT > 0)
                {
                    LoadGiaVatTu(ID_DMVT);
                    cmdKhongChuyen.Enabled = true;
                    grTBGia.Text = "Đơn giá: " + TenVT.ToUpper();
                }
                else
                {
                    cmdKhongChuyen.Enabled = false;
                }
            }
            else
            {
                cmdKhongChuyen.Enabled = false;
            }
        }

        private void gdGia_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "Modify")
            {
                long ID_Gia = -1;
                long ID_VatTu = -1;
                try
                {
                    ID_Gia = long.Parse(this.gdGia.GetValue("ID").ToString());
                    ID_VatTu = long.Parse(this.gdGia.GetValue("VatTuID").ToString());
                }
                catch { }
                if ((ID_Gia > 0)&&(ID_VatTu>0))
                {
                    frm_ThemSuaGiaVatTu frm = new frm_ThemSuaGiaVatTu(ID_Gia);
                    frm.ShowDialog();
                    if (frm.OK > 0)
                    {
                        LoadGiaVatTu(ID_VatTu);
                        GridEXFilterCondition condi = new GridEXFilterCondition(this.gdGia.RootTable.Columns["ID"], ConditionOperator.Equal, ID_Gia);
                        this.gdGia.Find(condi, 0, 1);
                    }
                }
            }
        }

        private void gdDMDT_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gdDMDT.CurrentRow.RowType == RowType.Record)
            {
                long ID_DMDT = -1;
                try
                {
                    ID_DMDT = long.Parse(this.gdDMDT.GetValue("ID").ToString());
                }
                catch { }
                if (ID_DMDT > 0)
                {
                    cmdChuyen.Enabled = true;
                }
                else
                {
                    cmdChuyen.Enabled = false;
                }
            }
            else
            {
                cmdChuyen.Enabled = false;
            }
        }

    }
}