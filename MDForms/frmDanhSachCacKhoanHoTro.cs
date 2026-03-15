using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using MDSolution.MDForms;
using MDSolution.MDReport;

namespace MDSolution
{
    public partial class frmDanhSachCacKhoanHoTro : Form
    {

        MDDataSetForms.frmNhapHoTro frmNhaphotro;
        private NodeDonVi nDonVi = new NodeDonVi();

        private DataSet gridDataSource;

        private DataSet gridDataSourceGridEX2;

        private DataSet gridThonSource;


        private DataSet DDLTram;
        private DataSet DDLGiong;
        private DataSet DDLLoaiDat;
        private DataSet DDLRaiVu;
        private DataSet DDLMucDichTrong;

        private string HopDongID_ = "";
        private clsHoTro oHT = new clsHoTro();
        private DataSet ddlDanhMucHoTroSource;
        private long HopDongID = -1;
        public frmDanhSachCacKhoanHoTro()
        {
            InitializeComponent();

            this.LoadDDLDanhMucHoTroGridHoTro();
            CommonClass.loadTreeDonVi(treeDonVi);
            LoadDDLDanhMucHoTroGridHoTro();
            LoadThonSource();
            //LoadDropDownTram();
            //loadDDLLoaiDat();
            //LoadDDLGiong();
            //LoadDDLMucDichTrong();
            //LoadDDLRaiVu();
            //LoadKieuTrong();
        }
        public frmDanhSachCacKhoanHoTro(string ID)
        {
            InitializeComponent();
            CommonClass.loadTreeDonVi(treeDonVi);
            LoadHopDong1(ID);
            LoadDDLDanhMucHoTroGridHoTro();
            LoadThonSource();
            //LoadDropDownTram();
            //loadDDLLoaiDat();
            //LoadDDLGiong();
            //LoadDDLMucDichTrong();
            //LoadDDLRaiVu();
            //LoadKieuTrong();

        }

        private void loadDDLLoaiDat()
        {
            string strSQL = "Select * from tbl_LoaiDat";
            DDLLoaiDat = DBModule.ExecuteQuery(strSQL, null, null);
            this.grdHopDong.DropDowns["DDLLoaiDat"].SetDataBinding(DDLLoaiDat.Tables[0], "");
        }

        private void LoadDropDownTram()
        {
            string strSQL = "SELECT * from tbl_TramNongVu";
            DDLTram = DBModule.ExecuteQuery(strSQL, null, null);
            this.grdHopDong.DropDowns["DDLTram"].SetDataBinding(DDLTram.Tables[0], "");
        }

        //private void LoadDDLGiong()
        //{
        //    string strSQL = "Select * from tbl_GiongMia";
        //    DDLGiong = DBModule.ExecuteQuery(strSQL, null, null);
        //    this.grdHopDong.DropDowns["DDLGiong"].SetDataBinding(DDLGiong.Tables[0], "");
        //}

        //private void LoadDDLRaiVu()
        //{
        //    //string str = "Select * from tbl_RaiVu";
        //    DataSet ds;
        //    ds = clsRaiVu.GetListbyWhere("", "", "", null, null);
        //    this.grdHopDong.DropDowns["DDLRaiVu"].SetDataBinding(ds, "");
        //}

        //private void LoadDDLMucDichTrong()
        //{
        //    DataSet ds;
        //    ds = clsMucDichTrong.GetListbyWhere("", "", "", null, null);
        //    this.grdHopDong.DropDowns["DDLMucDich"].SetDataBinding(ds.Tables[0], "");
        //}

        //private void LoadKieuTrong()
        //{
        //    DataSet ds;
        //    ds = clsKieuTrong.GetListbyWhere("", "", "", null, null);
        //    this.grdHopDong.DropDowns["DDLKieuTrong"].SetDataBinding(ds.Tables[0], "");
        //}

        private void LoadHopDong1(string HopDongID)
        {
            DataSet ds;
            string strSQL = "SELECT * FROM tbl_HopDong WHERE ParentID=0 AND ID=" + HopDongID.ToString();
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables.Count > 0)
            {
                this.grdHopDong.SetDataBinding(ds.Tables[0], "");
            }
        }
        private DataSet LoadBanDieuTra()
        {
            string strSQL = "";
            strSQL = @"SELECT * FROM tbl_HopDong  WHERE 1=1  ";
            switch (nDonVi.Type)
            {
                case DonviType.Cum: strSQL += " AND tbl_HopDong.ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID IN (SELECT ID FROM tbl_Xa WHERE CumID =" + nDonVi.DonViID + "))"; break;
                case DonviType.Xa: strSQL += " AND tbl_HopDong.ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
                case DonviType.Thon: strSQL += " AND tbl_HopDong.ThonID=" + nDonVi.DonViID; break;
                default: break;
            }
            if ((this.chkTimkiemchinhxac.Checked) && (edtTimKiem.Text != ""))
            {
                strSQL += " AND (tbl_HopDong.MaHopDong = N'" + DBModule.RefineString(edtTimKiem.Text) + "' OR tbl_HopDong.HoTen = N'" + DBModule.RefineString(edtTimKiem.Text) + "')";
            }
            else
            {
                strSQL += " AND (tbl_HopDong.MaHopDong like N'%" + DBModule.RefineString(edtTimKiem.Text) + "%' OR tbl_HopDong.HoTen like N'%" + DBModule.RefineString(edtTimKiem.Text) + "%')";
            }
            if (this.chkCoHoTro.Checked)
            {
                strSQL += "AND tbl_HopDong.ID IN (select HopDongID from tbl_HoTro where VuTrongID=" + MDSolutionApp.VuTrongID + ")"; 
            }
            if (this.chkCoHoTro_KT.Checked)
            { 
            
            strSQL+= " AND tbl_HopDong.ID not in (SELECT DISTINCT dbo.tbl_DauTu.HopDongID FROM     dbo.tbl_DauTu INNER JOIN dbo.tbl_HoTro_ChiTiet_TienLai ON dbo.tbl_DauTu.ID = dbo.tbl_HoTro_ChiTiet_TienLai.DauTuID WHERE  dbo.tbl_HoTro_ChiTiet_TienLai.VuTrongID = "+ MDSolutionApp.VuTrongID + ")"; 
            }
            
            return DBModule.ExecuteQuery(strSQL, null, null);
        }

        private void LoadDDLDanhMucHoTroGridHoTro()
        {
            string strSQL = "SELECT * FROM tbl_DanhMucHoTro";
            this.ddlDanhMucHoTroSource = DBModule.ExecuteQuery(strSQL, null, null);
            this.grdHoTro.DropDowns["ddlDanhMucHoTro"].SetDataBinding(this.ddlDanhMucHoTroSource.Tables[0], "");
        }

        private void LoadDDLDanhMucDauTu()
        {
            DataSet ds;
            string strSQL = "SELECT a.ID, a.DanhMucDauTuID, b.Ten as DanhMucDauTu, a.SoLuong, a.DonGia, a.SoTien, a.LaiSuat, a.NgayDauTu ";
            strSQL += " FROM tbl_DauTu as a LEFT JOIN tbl_DanhMucDauTu as b ON a.DanhMucDauTuID = b.[ID]";
            strSQL += " Where HopDongID=" + this.grdHopDong.GetValue("ID").ToString() + " AND VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
            strSQL += " UNION Select -1,-1,N'Không tương ứng mục đầu tư nào',0,0,0,0,null";
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            this.grdHoTro.DropDowns["ddlDauTu"].SetDataBinding(ds.Tables[0], "");
        }
        private void LoadThonSource()
        {
            string strSQL = "SELECT * FROM tbl_Thon";
            switch (nDonVi.Type)
            {
                //case DonviType.Cum: strSQL += " Where ID IN (SELECT ID FROM tbl_Thon WHERE XaID="
                case DonviType.Xa: strSQL += " WHERE ID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
                case DonviType.Thon: strSQL += " WHERE ID=" + nDonVi.DonViID; break;
                default: break;
            }
            this.gridThonSource = DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridThonSource.Tables.Count > 0)
            {
                this.grdHopDong.DropDowns["Thon"].SetDataBinding(this.gridThonSource.Tables[0], "");
            }
        }

        private void LoadGridEX2()
        {
            try
            {
                if (this.grdHopDong.GetValue("ID").ToString() != "")
                { HopDongID_ = this.grdHopDong.GetValue("ID").ToString(); }
            }
            catch { HopDongID_ = ""; }

            if (HopDongID_ != "")
            {
                //this.LoadDDLDanhMucDauTu();
                string strSQL = @"SELECT        dbo.tbl_HoTro.ID, dbo.tbl_HoTro.ThuaRuongID, dbo.tbl_HoTro.HopDongID, dbo.tbl_HoTro.SoTien, dbo.tbl_HoTro.NgayLamHoTro, dbo.tbl_HoTro.DanhMucHoTroID, dbo.tbl_HoTro.VuTrongID, dbo.tbl_HoTro.DauTuID, 
                         dbo.tbl_HoTro.SoLuong, dbo.tbl_HoTro.DonGia, dbo.tbl_HoTro.GhiChu, dbo.tbl_HoTro.HoTroTheoLoaiHinhID, dbo.tbl_HoTro.CreatedBy, dbo.tbl_HoTro.ModifyBy, dbo.tbl_HoTro.DateAdd, dbo.tbl_HoTro.DataModify, 
                         dbo.tbl_HoTro.NoteModify, dbo.tbl_HoTro.Status, dbo.tbl_HoTro.KhauTru, dbo.tbl_HoTro.LyDoKhauTru, dbo.tbl_HoTro.HoTroID, dbo.sys_User.HoTen, dbo.tbl_DanhMucCanBoNongVu.Ten AS TenCBNV, 
                         dbo.tbl_HoTro.ID AS IDHoTro, dbo.tbl_DanhMucHoTro.Ten AS TenHoTro, dbo.tbl_HoTro.SoChungTu, dbo.tbl_HoTro.DienTich, sys_User_1.HoTen AS NguoiSua
                         FROM            dbo.tbl_HoTro INNER JOIN
                         dbo.sys_User ON dbo.tbl_HoTro.CreatedBy = dbo.sys_User.ID INNER JOIN
                         dbo.tbl_HopDong ON dbo.tbl_HoTro.HopDongID = dbo.tbl_HopDong.ID INNER JOIN
                         dbo.tbl_Thon ON dbo.tbl_HopDong.ThonID = dbo.tbl_Thon.ID INNER JOIN
                         dbo.tbl_DanhMucCanBoNongVu ON dbo.tbl_Thon.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.ID INNER JOIN
                         dbo.tbl_DanhMucHoTro ON dbo.tbl_HoTro.HoTroTheoLoaiHinhID = dbo.tbl_DanhMucHoTro.ID INNER JOIN
                         dbo.sys_User AS sys_User_1 ON dbo.tbl_HoTro.ModifyBy = sys_User_1.ID   Where dbo.tbl_HoTro.VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " AND dbo.tbl_HoTro.HopDongID = " + HopDongID_;
                this.gridDataSourceGridEX2 = DBModule.ExecuteQuery(strSQL, null, null);
                if (this.gridDataSourceGridEX2.Tables.Count > 0)
                {
                    this.grdHoTro.SetDataBinding(this.gridDataSourceGridEX2.Tables[0], "");
                }
            }
        }

        private void CreateDataSourceAndBindGrid()
        {
            gridDataSource = this.LoadBanDieuTra();
            if (gridDataSource.Tables.Count > 0)
            {
                this.grdHopDong.SetDataBinding(gridDataSource.Tables[0], "");
            }

        }

        private void treeDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                this.DoLoadGridHopDong();
            }
        }
        private void DoLoadGridHopDong()
        {
            this.LoadThonSource();
            this.CreateDataSourceAndBindGrid();
            this.grdHopDong.Focus();
        }
        private void treeDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nDonVi = (NodeDonVi)e.Node.Tag;
            this.DoLoadGridHopDong();
        }
        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(edtTimKiem.Text))
            {
                if (this.uiCheckBox1.Checked)
                {
                    nDonVi = new NodeDonVi();
                }
                this.DoLoadGridHopDong();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu tìm kiếm ", "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridEX2_AddingRecord(object sender, CancelEventArgs e)
        {
            if (!SaveHoTro(true)) { e.Cancel = true; }
            else
            {
                //MessageBox.Show("Bạn đã lưu lại thành công", "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Information);               
            }
        }

        private void gridEX2_DeletingRecord(object sender, RowActionCancelEventArgs e)
        {
            string message;

            message = String.Format("Bạn muốn xóa bản ghi này?");

            if (MessageBox.Show(message, "Sơn La", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRowView dr = (DataRowView)e.Row.DataRow;
                clsHoTro oHD = new clsHoTro(long.Parse(dr.Row.ItemArray[0].ToString()));
                oHD.Delete(null, null);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void gridEX2_RecordAdded(object sender, EventArgs e)
        {
            this.LoadGridEX2();
            this.grdHoTro.Refetch();

        }

        private void gridEX2_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa thành công", "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void gridEX2_RecordUpdated(object sender, EventArgs e)
        {
            this.LoadGridEX2();
            this.grdHoTro.Refetch();
        }

        private void frmDanhSachCacKhoanHoTro_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void gridEX2_UpdatingRecord(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", "Sơn La", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (!SaveHoTro(false)) { e.Cancel = true; }
            }
            else { e.Cancel = true; LoadGridEX2(); }
        }

        private bool SaveHoTro(bool isAddNew)
        {
            try
            {
                if (isAddNew)
                {
                    oHT = new clsHoTro();
                    oHT.HopDongID = long.Parse(this.grdHopDong.GetValue("ID").ToString());
                    oHT.VuTrongID = MDSolutionApp.VuTrongID;
                }
                else
                {
                    oHT.ID = long.Parse(this.grdHoTro.GetValue("ID").ToString());
                    oHT.Load(null, null);
                }

                if (string.IsNullOrEmpty(this.grdHoTro.GetValue("DanhMucHoTroID").ToString())) throw new Exception("Bạn chưa cho biết loại hình hỗ trợ");
                oHT.DanhMucHoTroID = long.Parse(this.grdHoTro.GetValue("DanhMucHoTroID").ToString());
                if (string.IsNullOrEmpty(this.grdHoTro.GetValue("SoTien").ToString())) throw new Exception("Bạn chưa cho biết số tiền được hỗ trợ");
                if (!decimal.TryParse(this.grdHoTro.GetValue("SoLuong").ToString(), out oHT.SoLuong)) oHT.SoLuong = 0;
                if (!decimal.TryParse(this.grdHoTro.GetValue("DonGia").ToString(), out oHT.DonGia)) oHT.DonGia = 0;
                oHT.SoTien = long.Parse(this.grdHoTro.GetValue("SoTien").ToString());
                if (string.IsNullOrEmpty(this.grdHoTro.GetValue("NgayLamHoTro").ToString())) throw new Exception("Bạn chưa cho biết ngày làm hỗ trợ");
                oHT.NgayLamHoTro = (DateTime)this.grdHoTro.GetValue("NgayLamHoTro");
                //oHT.DauTuID = long.Parse(this.grdHoTro.GetValue("DauTuID").ToString());
                oHT.Save(null, null);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        //private void grdHopDong_RowDoubleClick(object sender, RowActionEventArgs e)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(this.grdHopDong.GetValue("ID").ToString()))
        //        {
        //            long oID = long.Parse(this.grdHopDong.GetValue("ID").ToString());
        //            frmViewHopDong aa = new frmViewHopDong(oID);

        //            aa.ShowDialog();
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Không có hợp đồng nào như vậy ", "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}

        private void grdHopDong_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.grdHopDong.CurrentRow.RowType != RowType.NewRecord)
                {
                    this.LoadGridEX2();

                }

            }
            catch
            {
            }
        }

        private void tsViewHopDong_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.grdHopDong.GetValue("ID").ToString()))
                {
                    long oID = long.Parse(this.grdHopDong.GetValue("ID").ToString());
                    frmViewHopDong aa = new frmViewHopDong(oID);

                    aa.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }
        private void grdHoTro_UpdatingCell(object sender, UpdatingCellEventArgs e)
        {
            if (e.Column.Key == "DonGia" || e.Column.Key == "SoLuong")
            {
                long soluong;
                long dongia;
                try
                {
                    soluong = long.Parse(this.grdHoTro.GetValue("SoLuong").ToString());
                }
                catch
                {
                    soluong = 0;
                }
                try
                {
                    dongia = long.Parse(this.grdHoTro.GetValue("DonGia").ToString());
                }
                catch
                {
                    dongia = 0;
                }
                long sotien = dongia * soluong;
                this.grdHoTro.SetValue("SoTien", sotien);
            }
        }

        private void treeDonVi_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // label5.Text = "Đơn vị :" + treeDonVi.SelectedNode.Text;
            // uiPanel2.Text = "Đơn vị: " + treeDonVi.SelectedNode.Text.ToUpper();
            //uiPanel5Container.Text = "Đơn vị: " + treeDonVi.SelectedNode.Text.ToUpper();
            // lblSelectNode.Text = treeDonVi.SelectedNode.Text;
            NodeDonVi ndv = (NodeDonVi)treeDonVi.SelectedNode.Tag;
            string TenDonvi = "";
            switch (ndv.Type)
            {
                case DonviType.Root:
                    TenDonvi = "Đơn vị"; break;
                case DonviType.Xa:
                    TenDonvi = "Xã: " + treeDonVi.SelectedNode.Text.ToUpper().Replace("XÃ", "").Trim(); break;
                case DonviType.Thon:
                    TenDonvi = "Xã: " + treeDonVi.SelectedNode.Parent.Text.ToUpper().Replace("XÃ", "").Trim() + "  Thôn: " + treeDonVi.SelectedNode.Text.ToUpper().Replace("THÔN", "").Trim();
                    break;
                case DonviType.Cum:
                    TenDonvi = "Trạm: " + treeDonVi.SelectedNode.Text.ToUpper();
                    break;

            }
            label5.Text = TenDonvi + "    ";
        }

        private void edtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (uiCheckBox1.Checked)
                {
                    nDonVi = (NodeDonVi)treeDonVi.Nodes[0].Tag;
                }
                this.DoLoadGridHopDong();
            }
        }

        private void grdHopDong_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "btnMenu")
            {
                this.contextRight.Show(MousePosition);
            }
        }
        private void toolChitiethopdong_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.grdHopDong.GetValue("ID").ToString()))
                {
                    long oID = long.Parse(this.grdHopDong.GetValue("ID").ToString());

                    frmViewHopDong aa = new frmViewHopDong(oID);
                    aa.MdiParent = this.MdiParent;
                    aa.Show();
                }
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void toolQuanlydautu_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = this.grdHopDong.GetValue("ID").ToString();

                frmQuanLyDauTuNoCu frm = new frmQuanLyDauTuNoCu(ID);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void toolThietlapdientich_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = this.grdHopDong.GetValue("ID").ToString();

                frmDienTichCoCauTrong frm = new frmDienTichCoCauTrong(ID);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void toolLamthanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = this.grdHopDong.GetValue("ID").ToString();

                frmThanhToanCongNo frm = new frmThanhToanCongNo(ID);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void mnuChitiettrunodautu_Click(object sender, EventArgs e)
        {
            try
            {
                frmThanhToan_DauTu_TruNo frm = new frmThanhToan_DauTu_TruNo(this.grdHopDong.GetValue("ID").ToString());
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        private void chitiencoTruNo_Click(object sender, EventArgs e)
        {
            try
            {
                frmThanhToan_TienCo_TruNo frm = new frmThanhToan_TienCo_TruNo(this.grdHopDong.GetValue("ID").ToString());
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.F8:



                        //this.DoLoadGridHopDong();

                        //btThem_Click(null, null);

                        uiButtonThem_Click(null, null);
                        break;

                    case Keys.F4:
                        //Code cho F4
                        try
                        {
                            if (!string.IsNullOrEmpty(this.grdHopDong.GetValue("ID").ToString()))
                            {
                                long oID = long.Parse(this.grdHopDong.GetValue("ID").ToString());

                                frmViewHopDong aa = new frmViewHopDong(oID);
                                aa.MdiParent = this.MdiParent;
                                aa.Show();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
                        }
                        break;
                    case Keys.F9:
                        try { uiButtonSua_Click(null, null); }
                        catch { }
                        break;
                    case Keys.Escape:
                        // Code cho phim Esc
                        grdHopDong.CancelCurrentEdit();
                        //gridEX2.CancelCurrentEdit();
                        uiPanel3.Text = "F8-Cập nhật hỗ trợ cho hợp đồng / F4-Chi tiết  / F6-In danh sách";

                        break;

                    case Keys.F5:
                        // Code cho phim F6
                        edtTimKiem.Focus();
                        this.AcceptButton = uiButton1;
                        break;
                    case Keys.F12:
                        // Code cho phim F7
                        uiPanel0.Activate();
                        break;
                    //case Keys.Delete:
                    //    uiButtonXoa_Click(null, null);
                    //    break;


                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.grdHopDong.GetValue("ID").ToString()))
                {
                    long oID = long.Parse(this.grdHopDong.GetValue("ID").ToString());

                    frmViewHopDong aa = new frmViewHopDong(oID);
                    aa.MdiParent = this.MdiParent;
                    aa.Show();
                }
            }
            catch
            {
                MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            }

        }

        private void uiButtonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string message;
                message = String.Format("Bạn muốn xóa bản ghi này?");
                if (Chek_SuaDLGoc())
                {
                }
                else
                {
                    return;
                }

                if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //DataRowView dr = (DataRowView).Row.DataRow;
                    //clsHoTro oHT = new clsHoTro(long.Parse(this.grdHoTro.GetValue("HoTroID").ToString()));



                    clsHoTro oHT = new clsHoTro(long.Parse(this.grdHoTro.GetValue("ID").ToString()));
                    oHT.Load(null, null);
                    if (oHT.DauTuID < 0)
                    {
                        try
                        {
                            clsDauTu oDT = new clsDauTu();
                            string CNDautu = "select ID from tbl_DauTu where HoTroID= " + this.grdHoTro.GetValue("ID").ToString() + " AND VuTrongID =" + MDSolutionApp.VuTrongID;
                            string DauTuID = DBModule.ExecuteQueryForOneResult(CNDautu, null, null);
                            string UDDautu = "Update tbl_dautu set HotroID =-1, SoTienTinhLaiSauHT =0 where ID=" + DauTuID;
                            DBModule.ExecuteNonQuery(UDDautu, null, null);
                        }
                        catch { }
                        oHT.Delete(null, null);
                        LoadGridEX2();
                    }
                    else
                    {
                        MessageBox.Show("Hỗ trợ đã được trừ đầu tư", "Không được xóa");

                    }
                }
                else
                {
                    LoadGridEX2();
                    //e.Cancel = true;
                }
            }
            catch { MessageBox.Show("Bạn phải chọn một mục đầu tư để xóa", "Thông báo"); }
        }

        private bool Chek_SuaDLGoc()
        {
            try
            {
                string sqlcheckTT = "select count(*) from [tbl_ThanhToanMia_TruNoDauTu] where [DauTuID]=" + grdHoTro.GetValue("DauTuID").ToString();
                string res = DBModule.ExecuteQueryForOneResult(sqlcheckTT, null, null);
                if (res != "0")
                {
                    MessageBox.Show("Khoản đầu tư này đã được khấu trừ.\nNếu muốn sửa xóa phải thực hiện huỷ khấu trừ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch
            {
            }
            return true;
        }



        private void uiButtonThem_Click(object sender, EventArgs e)
        {
            Boolean i = false;
            try
            {
                if (this.grdHopDong.GetValue("ID").ToString() != "")
                {
                    i = true;
                }

            }
            catch
            {
                i = false;
            }
            if (i)
            {
                if (Chek_SuaDLGoc())
                {
                }
                else
                {
                    return;
                }


                HopDongID = long.Parse(this.grdHopDong.GetValue("ID").ToString());
                frm_NhapHoTroKDT frm1 = new frm_NhapHoTroKDT(HopDongID, true);
                frm1.ShowDialog();
                LoadGridEX2();

                //frm_NhapHoTro frm = new frm_NhapHoTro(long.Parse(this.grdHopDong.GetValue("HopDongID").ToString()), long.Parse(this.grdHopDong.GetValue("DauTuID").ToString()), true);

                //// MDDataSetForms.frmNhapHoTro frm = new MDSolution.MDDataSetForms.frmNhapHoTro(long.Parse(this.grdHopDong.GetValue("ID").ToString()), true);
                //frm.ShowDialog();
                //LoadBanDieuTra();
                //LoadGridEX2();
                ////try
                ////{
                ////    GridEXFilterCondition condi = new GridEXFilterCondition(grdHoTro.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
                ////    grdHoTro.Find(condi, 0, 1);
                ////}
                ////catch { }
            }
            else
            {
                if (Chek_SuaDLGoc())
                {
                }
                else
                {
                    return;
                }

                //frm_NhapHoTro frm = new frm_NhapHoTro(0, true);
                //// MDDataSetForms.frmNhapHoTro frm = new MDSolution.MDDataSetForms.frmNhapHoTro(0, true);
                //frm.ShowDialog();
                //LoadBanDieuTra();
                //LoadGridEX2();
                //try
                //{
                //    GridEXFilterCondition condi = new GridEXFilterCondition(grdHoTro.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
                //    grdHoTro.Find(condi, 0, 1);
                //}
                //catch { }
            }


        }

        private void uiButtonSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdHoTro.GetValue("ID").ToString() != "")
                {
                    string a = this.grdHoTro.GetValue("ID").ToString();

                    if (Chek_SuaDLGoc())
                    {
                    }
                    else
                    {
                        return;
                    }

                    if (int.Parse(this.grdHoTro.GetValue("KhauTru").ToString()) == 1)
                    {
                        MessageBox.Show("Không sửa được vì đã đối trừ đầu tư");
                        return;

                    }

                    frm_NhapHoTroKDT frm1 = new frm_NhapHoTroKDT(long.Parse(this.grdHoTro.GetValue("ID").ToString()));
                    frm1.ShowDialog();
                    LoadGridEX2();

                    //frm_NhapHoTro frm = new frm_NhapHoTro(long.Parse(this.grdHoTro.GetValue("HoTroID").ToString()));
                    //frm.ShowDialog();
                    //LoadBanDieuTra();
                    //LoadGridEX2();
                    //try
                    //{
                    //    GridEXFilterCondition condi = new GridEXFilterCondition(grdHoTro.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
                    //    grdHoTro.Find(condi, 0, 1);
                    //}
                    //catch { }
                }
                else { MessageBox.Show("Bạn phải chọn một mục hỗ trợ để sửa", "Thông báo"); }
            }
            catch { MessageBox.Show("Bạn phải chọn một mục hỗ trợ để sửa", "Thông báo"); }
        }

        private void uiButtonXemXoa_Click(object sender, EventArgs e)
        {
            DateTime DenNgay = DateTime.Now;

            string sql = "select isnull(DateReadNotify,'2000-01-01') as DateReadNotify from sys_User ";
            DateTime TuNgay = (DateTime)DBModule.ExecuteQuery(string.Format(sql, MDSolutionApp.User.ID), null, null).Tables[0].Rows[0][0];
            sql = @" SELECT        TOP (100) PERCENT dbo.tbl_HopDong.MaHopDong, dbo.tbl_HopDong.HoTen, dbo.tbl_HopDong.Diachi, dbo.sys_User.HoTen AS NguoiXoa, dbo.tbl_DanhMucCanBoNongVu.Ten AS CBDB, dbo.tbl_HoTro_log.*, 
                         dbo.tbl_HoTro_log.Action AS Expr1
                        FROM            dbo.tbl_HopDong INNER JOIN
                         dbo.tbl_Thon ON dbo.tbl_HopDong.ThonID = dbo.tbl_Thon.ID INNER JOIN
                         dbo.tbl_HoTro_log ON dbo.tbl_HopDong.ID = dbo.tbl_HoTro_log.HopDongID INNER JOIN
                         dbo.sys_User ON dbo.tbl_HoTro_log.UserID = dbo.sys_User.ID LEFT OUTER JOIN
                         dbo.tbl_DanhMucCanBoNongVu ON dbo.tbl_Thon.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.ID
                            WHERE        (dbo.tbl_HoTro_log.Action = 2)                              
                            ORDER BY dbo.tbl_HoTro_log.ID DESC";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    frm_NhapHoTroLog frm = new frm_NhapHoTroLog();
                    frm.DateView = DenNgay;
                    frm.gdHopDongLog.SetDataBinding(ds.Tables[0], "RootTable");
                    frm.Text += "(" + ds.Tables[0].Rows.Count + ")";
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
            }
            catch (Exception exx)
            {


            }
        }

        private void uiGroupBox6_Click(object sender, EventArgs e)
        {

        }

        private void grdHoTro_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            try
            {

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = grdHopDong;
                        exporter.Export(fs);
                        fs.Close();
                        MessageBox.Show("Đã export ra file excel!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiButtonThemKTDT_Click(object sender, EventArgs e)
        {
            Boolean i = false;
            try
            {
                if (this.grdHoTro.GetValue("ID").ToString() != "")
                {
                    i = true;
                }

            }
            catch
            {
                i = false;
            }
            if (i)
            {
                if (Chek_SuaDLGoc())
                {
                }
                else
                {
                    return;
                }

                frm_NhapHoTro frm1 = new frm_NhapHoTro(long.Parse(this.grdHoTro.GetValue("ID").ToString()));
                frm1.ShowDialog();
                LoadGridEX2();
            }
            else
            {
                if (Chek_SuaDLGoc())
                {
                }
                else
                {
                    return;
                }


                MessageBox.Show("Chưa có khoản hỗ trợ nào");
                //frm_NhapHoTroKDT frm = new frm_NhapHoTroKDT(0, true);

                //frm.ShowDialog();
                //LoadBanDieuTra();
                //LoadGridEX2();
            }

        }

        private void cmdIn_Click(object sender, EventArgs e)
        {

            try
            {
                frmShowRP2 frm = new frmShowRP2();
                MDReport.HoTro.rpt_HoTroChuHo rp = new MDReport.HoTro.rpt_HoTroChuHo();
                DataSet ds = new DataSet();
                string HDID = this.grdHopDong.GetValue("ID").ToString();
                string sql = "Select * from V_HoTro where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " And HopDongID= " + HDID;
                ds = DBModule.ExecuteQuery(sql, null, null);
                rp.SetDataSource(ds.Tables[0]);
                //rp.RecordSelectionFormula = "{V_ChiTietDauTu.HopDongID}=" + this.grdHopDong.GetValue("ID").ToString() + " AND {V_ChiTietDauTu.VuTrongID}=" + MDSolutionApp.VuTrongID.ToString();
                rp.SetParameterValue("VuTrong", MDSolutionApp.VuTrongTen);
                frm.RP = rp;

                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.RPtitle = "Báo cáo chi tiết hỗ trợ.";
                frm.Show();

            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn hợp đồng cần xem", "Thông báo");
            }

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (grdHopDong.GetCheckedRows().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn phiếu cần in"); return;
            }
            string[] paramNames = new string[] { "@VuTrongID" }; //, "@DaiDien1" };
            string[] paraValues = new string[] { MDSolutionApp.VuTrongID.ToString() };//, txtDaiDien1.Text + "};

            string sql = @" select * from tbl_HopDong where 1=3 ";
            foreach (Janus.Windows.GridEX.GridEXRow r in grdHopDong.GetCheckedRows())
            {
                sql += " or ID= " + r.Cells["ID"].Value;
            }
            sql += " order by MaHopDong ";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);


            MDReport.Frm_ReportViewer frm = new MDSolution.MDReport.Frm_ReportViewer();
            frm.bHasPara = true;
            frm.ParaNames = paramNames;
            frm.ParaValues = paraValues;
            frm.rptFileName = "ChinhSach\\InDanhSachHoTro.rpt";
            frm.rptTitle = "";
            frm.ds = ds;

            frm.Show();
        }



    }
}