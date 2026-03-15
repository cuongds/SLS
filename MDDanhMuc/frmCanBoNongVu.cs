using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using MDSolution.MDForms;


namespace MDSolution
{
    public partial class frmCanBoNongVu : Form
    {
        static frmCanBoNongVu _frmCanBoNongVu;
        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmCanBoNongVu OneInstanceFrm
        {
            get
            {
                if (null == _frmCanBoNongVu || _frmCanBoNongVu.IsDisposed)
                {
                    _frmCanBoNongVu = new frmCanBoNongVu();
                }

                return _frmCanBoNongVu;
            }
        }
        private DataSet gridDataSource;
        public frmCanBoNongVu()
        {
            InitializeComponent();
        }
        private void Loadgd_DSCBNV()
        {
            string strSQL = "SELECT * FROM tbl_DanhMucCanBoNongVu";
            this.gridDataSource = DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gdDSCBNV.SetDataBinding(this.gridDataSource.Tables[0], "");
            }
        }
       
        private void gdVLVDauTu_RecordAdded(object sender, EventArgs e)
        {
            this.gdDSCBNV.Refetch();
            
        }

        private void gdVLVDauTu_AddingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                clsDanhMucCanBoNongVu oCBNongVu = new clsDanhMucCanBoNongVu();
                if (string.IsNullOrEmpty(this.gdDSCBNV.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên cán bộ");
                if (string.IsNullOrEmpty(this.gdDSCBNV.GetValue("Ma").ToString())) throw new Exception("Bạn chưa nhập Mã cán bộ");
                if (string.IsNullOrEmpty(this.gdDSCBNV.GetValue("DienThoai").ToString())) throw new Exception("Bạn chưa nhập điện thoại cán bộ");
                oCBNongVu.Ma = this.gdDSCBNV.GetValue("Ma").ToString();
                oCBNongVu.Ten = this.gdDSCBNV.GetValue("Ten").ToString();
                oCBNongVu.DienThoai = this.gdDSCBNV.GetValue("DienThoai").ToString();
                oCBNongVu.IsActive = 1;
                oCBNongVu.Save(null, null);
                this.gdDSCBNV.SetValue("ID", oCBNongVu.ID);
                Loadgd_DSCBNV();
           
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
        }
        }

        private void gdVLVDauTu_RecordUpdated(object sender, EventArgs e)
        {
            this.gdDSCBNV.Refetch();
        }

        private void gdVLVDauTu_DeletingRecord(object sender, RowActionCancelEventArgs e)
        {
            try
            {
                long CBNV_ID = -1;
                long.TryParse(this.gdDSCBNV.GetValue("ID").ToString(), out CBNV_ID);
                string NguoiDung = this.gdDSCBNV.GetValue("Ten").ToString();
                if (CBNV_ID > 0)
                {
                    if (MessageBox.Show("Bạn chắc chắn xóa " + NguoiDung, "Sơn La", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        clsDanhMucCanBoNongVu.Delete(CBNV_ID, null, null);
                    }
                    else
                    {
                        e.Cancel = true;
                    }

                }
            }
            catch { }
        }

        private void gdVLVDauTu_RecordsDeleted(object sender, EventArgs e)
        {
           MessageBox.Show("Đã xóa thành công", "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Information);
   
        }
      
        private void gdVLVDauTu_UpdatingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                long CBNV_ID = -1;
                long.TryParse(this.gdDSCBNV.GetValue("ID").ToString(), out CBNV_ID);
                if (CBNV_ID > 0)
                {
                    if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", "Sơn La", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        clsDanhMucCanBoNongVu oCB = new clsDanhMucCanBoNongVu(CBNV_ID);
                        oCB.Load(null, null);
                        if (string.IsNullOrEmpty(this.gdDSCBNV.GetValue("Ten").ToString())) throw new Exception("Bạn chưa nhập tên cán bộ");
                        if (string.IsNullOrEmpty(this.gdDSCBNV.GetValue("Ma").ToString())) throw new Exception("Bạn chưa nhập Mã cán bộ");
                        if (string.IsNullOrEmpty(this.gdDSCBNV.GetValue("DienThoai").ToString())) throw new Exception("Bạn chưa nhập điện thoại cán bộ");
                        oCB.Ma = this.gdDSCBNV.GetValue("Ma").ToString();
                        oCB.Ten = this.gdDSCBNV.GetValue("Ten").ToString();
                        oCB.DienThoai = this.gdDSCBNV.GetValue("DienThoai").ToString();
                        oCB.IsActive = 1;
                        oCB.Save(null, null);
                        MessageBox.Show("Bạn đã sửa lại thành công", "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Loadgd_DSCBNV();
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }      
        
        }

   
        private void Load_DiaBanCBNV(long CBID)
        {
            string sql = "SELECT     dbo.tbl_Thon.CanBoNongVuID,dbo.tbl_Thon.ID, dbo.tbl_DanhMucCanBoNongVu.Ten AS HoTen, dbo.tbl_Thon.Ten AS Ban, dbo.tbl_Xa.Ten AS Xa, dbo.tbl_Huyen.Ten AS Huyen " +
                        "FROM      dbo.tbl_Thon INNER JOIN dbo.tbl_Xa ON dbo.tbl_Thon.XaID = dbo.tbl_Xa.ID INNER JOIN dbo.tbl_Huyen ON dbo.tbl_Xa.HuyenID = dbo.tbl_Huyen.ID " +
                       " INNER JOIN dbo.tbl_DanhMucCanBoNongVu ON dbo.tbl_Thon.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.id" +
                       " WHERE dbo.tbl_Thon.CanBoNongVuID=" + CBID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDiaBan.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdDiaBan.DataSource = DBNull.Value;
            }
        }
       

       

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            string sql = "select * from View_QuanLyCBNV";

            DataSet ds = null;
            ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                frmShowRP2 frm = new frmShowRP2();
                MDReport.FRM_Report.HopDongCBNV rp = new MDReport.FRM_Report.HopDongCBNV();
                rp.SetDataSource(ds.Tables[0]);
                frm.RP = rp;
                //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.RPtitle = "Báo cáo CBNV - Địa bàn";
                frm.Show();
            }   
        }

        private void frmCanBoNongVu_Load(object sender, EventArgs e)
        {
            Loadgd_DSCBNV();
        }

        private void gdDSCBNV_SelectionChanged(object sender, EventArgs e)
        {
            long ID_CBNV = -1;
            string TenCBDB = "";
            try
            {
                ID_CBNV = long.Parse(this.gdDSCBNV.GetValue("ID").ToString());
                TenCBDB = this.gdDSCBNV.GetValue("Ten").ToString();
            }
            catch
            {
                ID_CBNV = -1;
            }
            if (ID_CBNV > 0)
            {
                Load_DiaBanCBNV(ID_CBNV);
                grDB.Text = "Địa bàn được phân công của "+TenCBDB;
            }

        }

        private void gdDiaBan_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key == "Delete")
                {
                    long Ban_ID = -1;
                    long.TryParse(this.gdDiaBan.GetValue("ID").ToString(), out Ban_ID);
                    string TenBan = this.gdDiaBan.GetValue("Ban").ToString();
                    string TenCBNV = this.gdDiaBan.GetValue("HoTen").ToString();
                    long CanBoNongVuID = long.Parse(this.gdDiaBan.GetValue("CanBoNongVuID").ToString());
                    if (Ban_ID > 0)
                    {
                        if (MessageBox.Show("Bạn sẽ xóa bản " + TenBan + "\nkhỏi địa bàn của " + TenCBNV, "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        clsThon.Update_DiaBanCBNV(-1, Ban_ID, null, null);
                        Load_DiaBanCBNV(CanBoNongVuID);
                    }
                }
            }
            catch { }
        }

        private void gdDSCBNV_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (this.gdDSCBNV.CurrentRow.RowType == Janus.Windows.GridEX.RowType.NewRecord)
            {
                return;
            }
            if (e.Column.Key == "Add")
            {
                long CanBoID=-1;
                long.TryParse(this.gdDSCBNV.GetValue("ID").ToString(), out CanBoID);
                if(CanBoID>0)
                {
                    frm_ChonDiaBan frm = new frm_ChonDiaBan();
                    frm.ShowDialog();
                    long Thon_ID=frm.ThonID;
                    if (Thon_ID > 0)
                    {
                        clsThon.Update_DiaBanCBNV(CanBoID, Thon_ID, null, null);
                        string sqlupdate = "UPDATE [dbo].[tbl_ThuaRuong]   SET [CanBoNongVuID] = " + CanBoID + "  WHERE ThonID =" + Thon_ID + " AND VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
                        DBModule.ExecuteNoneBackup(sqlupdate, null, null);
                        Load_DiaBanCBNV(CanBoID);
                    }
                }
            }
        }
      
    }
}