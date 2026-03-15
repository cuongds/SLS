using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using MDSolution.MDForms;
using MDSolution.MDForms.DauTu;
using MDSolution.MDForms.HoTro;


namespace MDSolution
{
    public partial class frmQuanLyDauTuNoCu : Form
    {

        private clsHoTro oHT = new clsHoTro();
        private NodeDonVi nDonVi = new NodeDonVi();
        private DataSet gridDataSourceGridEX2;
        private clsHopDong oHD = new clsHopDong();
        private DataSet gridThonSource;
        private DataSet DVCUVT;
        private clsDauTu oDT = new clsDauTu();
        private clsDanhMucDauTu oDMDT = new clsDanhMucDauTu();
        private clsDanhMucHoTro oDMHT = new clsDanhMucHoTro();
        MDDataSetForms.frmDauTu frmChiTiet;
        private string hdID = "";
        //Khai bao cho phan Dau Tu
        //private DataSet ddlThuaRuongSource;        
        public frmQuanLyDauTuNoCu()
        {
            InitializeComponent();
            this.LoadDDLHinhThucDauTuGridDauTu();
            this.LoadDVCungUngVT();
            CommonClass.loadTreeDonVi(treeDonVi);
        }
        public frmQuanLyDauTuNoCu(string ID)
        {
            InitializeComponent();
            CommonClass.loadTreeDonVi(treeDonVi);
            LoadHopDong1(ID);
            LoadThonSource();
            LoadDDLHinhThucDauTuGridDauTu();

        }
        private void LoadHopDong1(string ID)
        {
            DataSet ds;
            string strSQL = "SELECT * FROM tbl_HopDong WHERE ParentID=0 AND ID=" + ID.ToString();
            ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables.Count > 0)
            {
                this.grdHopDong.SetDataBinding(ds.Tables[0], "");
            }
        }
        /*  private DataSet LoadHopDong()
          {
              string strSQL = "SELECT * FROM tbl_HopDong WHERE 1=1";
              switch (nDonVi.Type)
              {
                  case DonviType.Xa: strSQL += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
                  case DonviType.Thon: strSQL += " AND ThonID=" + nDonVi.DonViID; break;
                  default: break;
              }
              if (this.chkTimkiemchinhxac.Checked)
              {

                  strSQL += " AND (MaHopDong = N'" + DBModule.RefineString(edtTimKiem.Text) + "' OR HoTen = N'" + DBModule.RefineString(edtTimKiem.Text) + "' )";
              }
              else
              {

                  strSQL += " AND (MaHopDong like N'%" + DBModule.RefineString(edtTimKiem.Text) + "%' OR HoTen like N'%" + DBModule.RefineString(edtTimKiem.Text) + "%' )";

              }
              return DBModule.ExecuteQuery(strSQL, null, null);
          }*/
        private void LoadThonSource()
        {
            string strSQL = "SELECT * FROM tbl_Thon";
            switch (nDonVi.Type)
            {
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
        private void LoadGrdDauTu()
        {
            try
            {
                if (this.grdHopDong.GetValue("ID").ToString() != "")
                { hdID = this.grdHopDong.GetValue("ID").ToString(); }
            }
            catch { hdID = ""; }
            if (hdID != "")
            {
                this.grdDauTu.SetDataBinding(null, "");
                //string strSQL = "SELECT a.*, ISNULL(b.SoTien,0) as TienHoTro FROM tbl_DauTu as a LEFT JOIN tbl_HoTro as b ON b.DauTuID = a.[ID] Where a.HopDongID=" + this.grdHopDong.GetValue("ID").ToString() + " AND a.VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
                string strSQL = @"SELECT        dbo.tbl_DauTu.ID, dbo.tbl_DauTu.ThuaRuongID, dbo.tbl_DauTu.HopDongID, dbo.tbl_DauTu.DanhMucDauTuID, dbo.tbl_DauTu.SoLuong, dbo.tbl_DauTu.DonGia, dbo.tbl_DauTu.SoTien, dbo.tbl_DauTu.LaiSuat, 
                         dbo.tbl_DauTu.NgayDauTu, dbo.tbl_DauTu.GhiChu, dbo.tbl_DauTu.DotDauTu, dbo.tbl_DauTu.DuNo, dbo.tbl_DauTu.NgayBatDauTinhLai, dbo.tbl_DauTu.DaThanhToan, dbo.tbl_DauTu.VuTrongID, dbo.tbl_DauTu.VuTruoc, 
                         dbo.tbl_DauTu.LaDuNoVuTruoc, dbo.tbl_DauTu.QuanLyVaKhauHaoID, dbo.tbl_DauTu.CreatedBy, dbo.tbl_DauTu.ModifyBy, dbo.tbl_DauTu.DateAdd, dbo.tbl_DauTu.DataModify, dbo.tbl_DauTu.NoteModify, dbo.tbl_DauTu.Status, 
                         dbo.tbl_DauTu.DonViCungUngVatTuID, dbo.tbl_DauTu.SoChungTu, dbo.tbl_DauTu.CanBoDiaBanID, dbo.tbl_DauTu.DuNoLai, dbo.tbl_DauTu.TienLai, dbo.tbl_DauTu.NgayChotTinhLai, dbo.tbl_DauTu.LoaiHinhDauTuID, 
                         dbo.tbl_DanhMucCanBoNongVu.Ten AS CanBoNongVu, sys_User_Create.HoTen AS NguoiTao, sys_User_Edit.HoTen AS NguoiSua, dbo.tbl_DauTu.SoLuong AS SoLuong1, dbo.tbl_DanhMucDauTu.Ten, 
                         dbo.tbl_HoTro_ChiTiet_TienLai.GocTinhLai AS TruGoc, dbo.tbl_HoTro_ChiTiet_TienLai.TienLai AS TruLai, dbo.tbl_DauTu.SoTienTinhLaiSauHT, dbo.tbl_HoTro_TruLai.SoTien AS SoTienHTTL, dbo.tbl_HoTro_TruLai.ID AS IDHTTL, 
                         dbo.tbl_HoTro_TruLai.NgayLamHoTro AS NgayLamHoTroHTTL, dbo.tbl_DanhMucHoTro.Ten AS TenLoaiHTTL,dbo.tbl_HoTro_TruLai.SoTienNhap, case when ISNULL(SoTienTruHoTro_Goc,0) > 0 then SoTienTruHoTro_Goc else dbo.tbl_DauTu.SoTien end AS TienDauTu
                         FROM            dbo.tbl_DanhMucHoTro INNER JOIN
                         dbo.tbl_HoTro_TruLai ON dbo.tbl_DanhMucHoTro.ID = dbo.tbl_HoTro_TruLai.HoTroTheoLoaiHinhID RIGHT OUTER JOIN
                         dbo.tbl_DauTu INNER JOIN
                         dbo.tbl_HopDong ON dbo.tbl_DauTu.HopDongID = dbo.tbl_HopDong.ID INNER JOIN
                         dbo.tbl_Thon ON dbo.tbl_HopDong.ThonID = dbo.tbl_Thon.ID INNER JOIN
                         dbo.tbl_DanhMucDauTu ON dbo.tbl_DauTu.DanhMucDauTuID = dbo.tbl_DanhMucDauTu.ID ON dbo.tbl_HoTro_TruLai.DauTuID = dbo.tbl_DauTu.ID LEFT OUTER JOIN
                         dbo.tbl_HoTro_ChiTiet_TienLai ON dbo.tbl_DauTu.ID = dbo.tbl_HoTro_ChiTiet_TienLai.DauTuID LEFT OUTER JOIN
                         dbo.tbl_DanhMucCanBoNongVu ON dbo.tbl_Thon.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.ID LEFT OUTER JOIN
                         dbo.sys_User AS sys_User_Edit ON dbo.tbl_DauTu.ModifyBy = sys_User_Edit.ID LEFT OUTER JOIN
                         dbo.sys_User AS sys_User_Create ON dbo.tbl_DauTu.CreatedBy = sys_User_Create.ID  Where dbo.tbl_DauTu.HopDongID=" + hdID + " AND dbo.tbl_DauTu.VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
                this.gridDataSourceGridEX2 = DBModule.ExecuteQuery(strSQL, null, null);
                if (this.gridDataSourceGridEX2.Tables.Count > 0)
                {
                    this.grdDauTu.SetDataBinding(this.gridDataSourceGridEX2.Tables[0], "");

                }
            }
        }
        private void LoadDVCungUngVT()
        {
            try
            {
                string strSQL = "SELECT * FROM tbl_DonViCungUngVatTu";
                this.DVCUVT = DBModule.ExecuteQuery(strSQL, null, null);
                this.grdDauTu.DropDowns["ddlDVCungUngVT"].SetDataBinding(DVCUVT.Tables[0], "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể load đơn vị cung ứng vật tư");
            }
        }
        private void LoadDDLHinhThucDauTuGridDauTu()
        {
            //Load ddlHinhThucDauTu cho cai GridEX2
            try
            {
                DataSet ds = clsDanhMucDauTu.GetListbyWhere("", " ID in (SELECT DanhMucDauTuID FROM [tbl_DanhMucDauTu_VuTrong] WHERE VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + ")", " ThuTu", null, null);
                this.grdDauTu.DropDowns["ddlDanhMucDauTu"].SetDataBinding(ds.Tables[0], "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể load danh mục đầu tư");
            }

        }
        private void CreateDataSourceAndBindGrid(long lID)
        {
            DataSet ds;
            ds = clsHopDong.GetDanhSachDenHopDong(lID, this.edtTimKiem.Text, nDonVi.Type, nDonVi.DonViID, this.chkTimkiemchinhxac.Checked);
            if (ds.Tables.Count > 0)
            {
                this.grdHopDong.SetDataBinding(ds.Tables[0], "");
            }

        }
        private void treeDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                //if (!nDonVi.HasLoadChildren && nDonVi.Type == DonviType.Thon)
                //{
                //    CommonClass.LoadChildrenHopDong(treeDonVi.SelectedNode);
                //    nDonVi.HasLoadChildren = true;
                //}
                this.DoLoadGridHopDong(-1);
            }
        }
        private void DoLoadGridHopDong(long lID)
        {
            this.LoadThonSource();
            this.CreateDataSourceAndBindGrid(lID);
            this.grdHopDong.Focus();

        }
        private void treeDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nDonVi = (NodeDonVi)e.Node.Tag;
            //if (!nDonVi.HasLoadChildren && nDonVi.Type == DonviType.Thon)
            //{
            //    CommonClass.LoadChildrenHopDong(e.Node);
            //    nDonVi.HasLoadChildren = true;
            //}
            this.DoLoadGridHopDong(-1);
        }
        private void grdHopDong_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadGrdDauTu();
                uipDauTu.Text = "Đầu tư (" + grdHopDong.GetValue(2) + ")";

            }
            catch
            {
                //grdThuaRuong.AllowAddNew = InheritableBoolean.False;
            }
        }
        private void uiButton1_Clic(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(edtTimKiem.Text))
            {
                if (this.uiCheckBox1.Checked)
                {
                    nDonVi = new NodeDonVi();
                    //nDonVi = (NodeDonVi)treeDonVi.Nodes[0].Tag;
                }
                this.DoLoadGridHopDong(-1);
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu tìm kiếm ", "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridEX2_AddingRecord(object sender, CancelEventArgs e)
        {
            if (!SaveDauTu(true)) { e.Cancel = true; }
            else
            {
                uiPanel2.Text = "F8-Thêm mới / F9-Sửa / F4-Chi tiết / Delete-Xóa / F6-In danh sách";
                //MessageBox.Show("Bạn đã lưu lại thành công", "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.grdHopDong.SetValue("ID", oHD.ID);
            }
        }
        private void gridEX2_DeletingRecord(object sender, RowActionCancelEventArgs e)
        {
            string message;
            message = String.Format("Bạn muốn xóa bản ghi này?");

            if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRowView dr = (DataRowView)e.Row.DataRow;
                clsDauTu oDT = new clsDauTu(long.Parse(dr.Row.ItemArray[0].ToString()));
                oDT.Delete(null, null);
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void gridEX2_RecordAdded(object sender, EventArgs e)
        {
            this.LoadGrdDauTu();
            this.grdDauTu.Refetch();
        }
        private void gridEX2_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa  thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void gridEX2_RecordUpdated(object sender, EventArgs e)
        {
            this.grdDauTu.Refetch();
            this.LoadGrdDauTu();
        }
        private void gridEX2_UpdatingRecord(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!SaveDauTu(false)) { e.Cancel = true; }
                else
                {
                    uiPanel2.Text = "F8-Thêm mới / F9-Sửa / F4-Chi tiết / Delete-Xóa / F6-In danh sách";
                    MessageBox.Show("Bạn đã sửa lại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.gdVLVDauTu.SetValue("ID", oDMDT.ID);
                }
            }
            else
            {
                e.Cancel = true;
                LoadGrdDauTu();
            }
        }
        private bool SaveDauTu(bool isAddNew)
        {
            try
            {
                if (isAddNew)
                {
                    oDT = new clsDauTu();
                    oDT.HopDongID = long.Parse(this.grdHopDong.GetValue("ID").ToString());
                    oDT.VuTrongID = MDSolutionApp.VuTrongID;
                }
                else
                {
                    oDT.Load(null, null);
                }


                if (string.IsNullOrEmpty(this.grdDauTu.GetValue("LaiSuat").ToString())) throw new Exception("Bạn cho biết lãi xuất đầu tư?");
                if (float.Parse(this.grdDauTu.GetValue("LaiSuat").ToString()) < 0) throw new Exception("Lãi suất phải lớn hơn không hoặc bằng không");
                oDT.LaiSuat = decimal.Parse(this.grdDauTu.GetValue("LaiSuat").ToString());

                if (string.IsNullOrEmpty(this.grdDauTu.GetValue("NgayDauTu").ToString())) throw new Exception("Bạn cho biết ngày đầu tư?");
                oDT.NgayDauTu = (DateTime)this.grdDauTu.GetValue("NgayDauTu");
                oDT.GhiChu = this.grdDauTu.GetValue("GhiChu").ToString();
                oDT.DanhMucDauTuID = long.Parse(this.grdDauTu.GetValue("DanhMucDauTuID").ToString());

                if (!string.IsNullOrEmpty(this.grdDauTu.GetValue("DotDauTu").ToString()))
                {
                    oDT.DotDauTu = long.Parse(this.grdDauTu.GetValue("DotDauTu").ToString());
                }
                else
                {
                    oDT.DotDauTu = 0;
                }
                if (string.IsNullOrEmpty(this.grdDauTu.GetValue("SoTien").ToString()) && string.IsNullOrEmpty(this.grdDauTu.GetValue("SoLuong").ToString()) && string.IsNullOrEmpty(this.grdDauTu.GetValue("DonGia").ToString())) throw new Exception("Bạn phải nhập số lượng và đơn giá hoặc số tiền ");
                if (long.Parse(this.grdDauTu.GetValue("SoTien").ToString()) <= 0 && long.Parse(this.grdDauTu.GetValue("SoLuong").ToString()) <= 0 && long.Parse(this.grdDauTu.GetValue("DonGia").ToString()) <= 0) throw new Exception("Bạn phải nhập số lượng và đơn giá hoặc số tiền ");
                if (string.IsNullOrEmpty(this.grdDauTu.GetValue("SoTien").ToString())) throw new Exception("Kiểm tra lại số tiền nhập vào ");
                oDT.SoTien = decimal.Parse(this.grdDauTu.GetValue("SoTien").ToString());
                if (oDT.SoTien < 0) throw new Exception("Số tiền bạn nhập vào nhỏ hơn 0, kiểm tra lại");
                if (!string.IsNullOrEmpty(this.grdDauTu.GetValue("SoLuong").ToString()))
                    oDT.SoLuong = long.Parse(this.grdDauTu.GetValue("SoLuong").ToString());
                if (oDT.SoLuong < 0) throw new Exception("Số lượng bạn nhập vào nhỏ hơn 0, kiểm tra lại");
                if (!string.IsNullOrEmpty(this.grdDauTu.GetValue("DonGia").ToString()))
                    oDT.DonGia = long.Parse(this.grdDauTu.GetValue("DonGia").ToString());
                if (oDT.DonGia < 0) throw new Exception("Đơn giá bạn nhập vào nhỏ hơn 0, kiểm tra lại");
                decimal tempSoTien = oDT.SoLuong * oDT.DonGia;
                if (tempSoTien > 0 && oDT.SoTien >= 0 && oDT.SoTien != tempSoTien)
                {
                    if (MessageBox.Show("Số tiền " + oDT.SoTien.ToString("### ### ##0") + " nhập vào khác với tổng số lượng * đơn giá : " + oDT.SoLuong.ToString("### ### ##0") + "* " + oDT.DonGia.ToString("### ### ##0") + "\n Bạn muốn lưu giá trị nào? Yes để lưu số tiền được nhập vào, no để lưu tổng tính toán.", "Sơn La", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        oDT.SoTien = tempSoTien;
                    }
                }
                if (oDT.SoTien == 0)
                {
                    if (oDT.SoLuong == 0 || oDT.DonGia == 0) throw new Exception("Bạn phải nhập số tiền hoặc số lượng cùng đơn giá ");
                }
                if (string.IsNullOrEmpty(this.grdDauTu.GetValue("DonViCungUngVatTuID").ToString())) throw new Exception("Bạn chưa chọn đơn vị ứng vật tư ");
                oDT.DonViCungUngVatTuID = long.Parse(this.grdDauTu.GetValue("DonViCungUngVatTuID").ToString());

                oDT.Save(null, null);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private void gridEX2_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                if (this.grdDauTu.CurrentRow.RowType == Janus.Windows.GridEX.RowType.NewRecord)
                {
                    //lblTB.Text = "Bạn có thể nhập số tiền bằng đơn giá nhân số lượng hoặc nhập trực tiếp vào ô số tiền ";
                    oDT = new clsDauTu();
                }
                else
                {
                    oDT.ID = long.Parse(this.grdDauTu.GetValue("ID").ToString());
                }
            }
            catch
            {
                oDT = new clsDauTu();
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
        private void frmQuanLyDauTu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void grdDauTu_UpdatingCell(object sender, UpdatingCellEventArgs e)
        {
            if (e.Column.Key == "DonGia")
            {
                long soluong;
                long dongia;
                try
                {
                    soluong = long.Parse(this.grdDauTu.GetValue("SoLuong").ToString());
                }
                catch
                {
                    soluong = 0;
                }
                try
                {
                    dongia = long.Parse(this.grdDauTu.GetValue("DonGia").ToString());
                }
                catch
                {
                    dongia = 0;
                }
                long sotien = dongia * soluong;
                this.grdDauTu.SetValue("SoTien", sotien);
            }
        }

        private void grdDauTu_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            //if (e.Column.Key == "TienHoTro")
            //{
            //    try {
            //        frmNhapTienHoTro frm = new frmNhapTienHoTro();
            //        frm.ChuHopDong = this.grdHopDong.GetValue("HoTen").ToString();
            //        frm.ChuHopDongID = long.Parse(this.grdHopDong.GetValue("ID").ToString());
            //        frm.DMDTID = long.Parse(this.grdDauTu.GetValue("DanhMucDauTuID").ToString());
            //        frm.DauTuID = long.Parse(this.grdDauTu.GetValue("ID").ToString());
            //        DateTime temp = DateTime.Parse(this.grdDauTu.GetValue("NgayDauTu").ToString());
            //        frm.NgayHoTro = temp;
            //        decimal tiendautu = (decimal)this.grdDauTu.GetValue("SoTien");
            //        frm.TienDauTu = tiendautu.ToString("### ### ##0");
            //        frm.LoadInfo();
            //        int Wherex = MousePosition.X;
            //        int Wherey = MousePosition.Y;
            //        if (Wherey + frm.Height > 768) Wherey = 768 - frm.Height;
            //        frm.SetDesktopLocation(Wherex, Wherey);
            //        frm.ShowDialog();

            //        if (frm.DialogResult == DialogResult.OK)
            //        {
            //            MessageBox.Show("Tiền hỗ trợ cho khoản mục đầu tư đã được cập nhật");
            //            this.LoadGrdDauTu();
            //        }
            //    }
            //    catch {
            //        //MessageBox.Show("Có lỗi khi nhập tiền hỗ trợ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }

            //}

            if (e.Column.Key == "AddNew")
            {
                MDDataSetForms.frmDauTu frm = new MDSolution.MDDataSetForms.frmDauTu(long.Parse(this.grdHopDong.GetValue("ID").ToString()), true);
                frm.ShowDialog();
                LoadGrdDauTu();
            }
            if (e.Column.Key == "Edit")
            {
                if (this.grdDauTu.GetValue("ID").ToString() != "")
                {
                    MDDataSetForms.frmDauTu frm = new MDSolution.MDDataSetForms.frmDauTu(long.Parse(this.grdDauTu.GetValue("ID").ToString()), false);
                    frm.ShowDialog();
                    LoadGrdDauTu();
                }
            }
        }

        private void treeDonVi_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //label1.Text = treeDonVi.SelectedNode.Text;
            switch (nDonVi.Type)
            {
                case DonviType.Cum: label5.Text = "Chủ hợp đồng trong trạm : " + treeDonVi.SelectedNode.Text + ""; break;
                case DonviType.Xa: label5.Text = "Chủ hợp đồng của xã : " + treeDonVi.SelectedNode.Text + ""; break;
                case DonviType.Thon: label5.Text = "Chủ hợp đồng của thôn : " + treeDonVi.SelectedNode.Text + ""; break;
                //case DonviType.ChuHopDong: uiPanel3.Text = "Chủ hộ của hợp đồng : " + treeDonVi.SelectedNode.Text + ""; break;
                default: label5.Text = "Chủ hợp đồng"; break;
            }
            // uiPanel3.Text = "Hợp đồng (" + treeDonVi.SelectedNode.Text +")";
        }

        private void edtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (uiCheckBox1.Checked)
                {
                    nDonVi = (NodeDonVi)treeDonVi.Nodes[0].Tag;
                }
                this.DoLoadGridHopDong(-1);
            }
        }

        private void btinchitiet_Click(object sender, EventArgs e)
        {
            try
            {
                frmShowRP2 frm = new frmShowRP2();
                MDReport.rp_T_ChiTietDauTu rp = new MDSolution.MDReport.rp_T_ChiTietDauTu();

                rp.RecordSelectionFormula = "{View_ChiTietDauTu.HopDongID}=" + this.grdHopDong.GetValue("ID").ToString() + " AND {View_ChiTietDauTu.VuTrongID}=" + MDSolutionApp.VuTrongID.ToString();
                frm.RP = rp;

                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.RPtitle = "Báo cáo chi tiết đầu tư.";
                frm.Show();

            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn hợp đồng cần xem", "Thông báo");
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

        private void toolQuanlyhotro_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = this.grdHopDong.GetValue("ID").ToString();

                frmDanhSachCacKhoanHoTro frm = new frmDanhSachCacKhoanHoTro(ID);
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

                    case Keys.F2:
                        //code cho F2                        
                        grdDauTu.MoveNext();
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
                            MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết", "Lỗi");
                        }
                        break;

                    case Keys.F5:
                        // Code cho phim F5
                        edtTimKiem.Focus();
                        this.AcceptButton = uiButton1;
                        break;

                    case Keys.F6:
                        //code cho F6
                        btinchitiet_Click(null, null);
                        break;

                    case Keys.F8:
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
                            MDDataSetForms.frmDauTu frm = new MDSolution.MDDataSetForms.frmDauTu(long.Parse(this.grdHopDong.GetValue("ID").ToString()), true);
                            frm.ShowDialog();
                            LoadGrdDauTu();
                            try
                            {
                                GridEXFilterCondition condi = new GridEXFilterCondition(grdDauTu.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
                                grdDauTu.Find(condi, 0, 1);
                            }
                            catch { }
                        }
                        else
                        {
                            MDDataSetForms.frmDauTu frm = new MDSolution.MDDataSetForms.frmDauTu(0, true);
                            frm.ShowDialog();
                            LoadGrdDauTu();
                            try
                            {
                                GridEXFilterCondition condi = new GridEXFilterCondition(grdDauTu.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
                                grdDauTu.Find(condi, 0, 1);
                            }
                            catch { }
                        }
                        break;

                    case Keys.F9:
                        // Code cho phim F9
                        //grdDauTu.EditMode = EditMode.EditOn;
                        // grdDauTu.MoveFirst();
                        //grdDauTu.Focus();
                        try
                        {
                            if (this.grdDauTu.GetValue("ID").ToString() != "")
                            {
                                MDDataSetForms.frmDauTu frm = new MDSolution.MDDataSetForms.frmDauTu(long.Parse(this.grdDauTu.GetValue("ID").ToString()), false);
                                frm.ShowDialog();
                                LoadGrdDauTu();
                                try
                                {
                                    GridEXFilterCondition condi = new GridEXFilterCondition(grdDauTu.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
                                    grdDauTu.Find(condi, 0, 1);
                                }
                                catch { }
                            }
                            else { MessageBox.Show("Bạn phải chọn một mục đầu tư để sửa", "Thông báo"); }
                        }
                        catch { MessageBox.Show("Bạn phải chọn một mục đầu tư để sửa", "Thông báo"); }
                        //uiPanel2.Text = "F2-Lưu / Esc-Bỏ qua";
                        break;

                    case Keys.Escape:
                        // Code cho phim Esc
                        grdDauTu.CancelCurrentEdit();
                        // uiPanel2.Text = "F8-Thêm mới / F9-Sửa / F4-Chi tiết / Delete-Xóa / F6-In danh sách";
                        break;

                    case Keys.F12:
                        // Code cho phim F12
                        uiPanel0.Activate();
                        break;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void edtTimKiem_Click(object sender, EventArgs e)
        {
            edtTimKiem.Text = "";
        }
        private bool Chek_SuaHT()
        {
            try
            {
                string sqlcheckTT = "select count(*) from [tbl_HoTro] where [DauTuID]=" + grdDauTu.GetValue("ID").ToString();
                string res = DBModule.ExecuteQueryForOneResult(sqlcheckTT, null, null);
                if (res != "0")
                {
                    MessageBox.Show("Khoản đầu tư này đang có hỗ trợ \nNếu muốn sửa phải xóa hỗ trợ trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch
            {
            }
            return true;
        }


        private void uiButtonSua_Click(object sender, EventArgs e)
        {
            try
            {
                long ID_DauTu = -1;
                ID_DauTu = long.Parse(this.grdDauTu.GetValue("ID").ToString());
                if (ID_DauTu > 0)
                {
                    if (Chek_SuaDLGoc())
                    { }
                    else
                    {
                        return;
                    }
                    if (Chek_SuaHT())
                    {
                    }
                    else
                    {
                        return;
                    }

                    frm_NhapDauTu frm = new frm_NhapDauTu(ID_DauTu);
                    frm.ShowDialog();
                    if (frm.OK > 0)
                    {
                        LoadGrdDauTu();
                        try
                        {
                            GridEXFilterCondition condi = new GridEXFilterCondition(grdDauTu.Tables[0].Columns["ID"], ConditionOperator.Equal, ID_DauTu);
                            grdDauTu.Find(condi, 0, 1);
                        }
                        catch { }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn phải chọn một mục đầu tư để sửa", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Bạn phải chọn một mục đầu tư để sửa", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool Checked_ID(string VatTuUserID)
        {
            string sqluser = "select CreatedBy from tbl_dautu where ID = " + VatTuUserID;
            string VatTuUser = MDSolutionApp.User.ID.ToString();
            string vattuuserID = DBModule.ExecuteQueryForOneResult(sqluser, null, null);
            string sqlNameUser = "Select HoTen from sys_User where ID =" + vattuuserID;
            string NameUser = DBModule.ExecuteQueryForOneResult(sqlNameUser, null, null);
            if (VatTuUser == vattuuserID || VatTuUser == "1")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Người nhập vật tư là: " + NameUser);
                return false;
            }
        }

        private bool Chek_SuaDLGoc()
        {
            string _DotThanhToan = "";
            string _NhapTienTraNoID = "";
            string sqlcheckTT = "select count(*) from [tbl_ThanhToanMia_TruNoDauTu] where [DauTuID]=" + grdDauTu.GetValue("ID").ToString();

            //check da thanh toan
            string res = DBModule.ExecuteQueryForOneResult(sqlcheckTT, null, null);
            if (res != "0")
            {
                MessageBox.Show("Khoản đầu tư này đã được thanh toán.\nNếu muốn sửa phải thực hiện huỷ đợt thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //check createby
            string sqlcheckCreateBy = "select isnull(CreatedBy,'') as CreatedBy from tbl_DauTu where ID=" + grdDauTu.GetValue("ID").ToString();
            res = DBModule.ExecuteQueryForOneResult(sqlcheckCreateBy, null, null);
            if (MDSolutionApp.User.ID != 1 && MDSolutionApp.User.ID.ToString() != res)
            {
                MessageBox.Show("Chỉ người tạo và admin mới sửa được thông tin đầu tư.(Createby:" + res + ")", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                string strSQL = "SELECT tbl_DauTu.DonViCungUngVatTuID, tbl_DanhMucDauTu.LoaiHinhDauTuID"
                    + " FROM  tbl_DanhMucDauTu INNER JOIN "
                    + " tbl_DauTu ON tbl_DanhMucDauTu.ID = tbl_DauTu.DanhMucDauTuID Where tbl_DauTu.ID=" + grdDauTu.GetValue("ID").ToString();
                DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);

                string donvi;
                string LoaiDauTu;
                donvi = ds.Tables[0].Rows[0]["DonViCungUngVatTuID"].ToString();
                LoaiDauTu = ds.Tables[0].Rows[0]["LoaiHinhDauTuID"].ToString();

                long ThuTu;
                if (donvi == "1")
                {
                    ThuTu = 1;
                }
                else
                {
                    switch (LoaiDauTu)
                    {
                        case "1":
                            ThuTu = 7;
                            break;
                        case "4":
                            ThuTu = 8;
                            break;
                        case "2":
                            ThuTu = 9;
                            break;
                        case "5":
                            ThuTu = 10;
                            break;
                        case "3":
                            ThuTu = 11;
                            break;
                        default:
                            ThuTu = 11;
                            break;
                    }

                }
                if (ThuTu != 10 && ThuTu != 11)
                    strSQL = "Select ID, DotThanhToan, NhapTienTraNoID From tbl_TruNo_DauTu Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString() + " and DauTuID=" + grdDauTu.GetValue("ID").ToString() + " and substring(LoaiHinhTruNo,1,1) ='" + ThuTu.ToString() + "'";
                else
                    strSQL = "Select ID, DotThanhToan, NhapTienTraNoID From tbl_TruNo_DauTu Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString() + " and DauTuID=" + grdDauTu.GetValue("ID").ToString() + " and substring(LoaiHinhTruNo,1,2) ='" + ThuTu.ToString() + "'";

                DataSet ds1 = DBModule.ExecuteQuery(strSQL, null, null);
                if (ds1.Tables[0].Rows.Count == 0) return true;
                if (ds1.Tables[0].Rows[0].IsNull("ID")) // khoan dau tu chua dc load vao
                {
                    return true;
                }
                else
                {
                    if (ds1.Tables[0].Rows[0].IsNull("DotThanhToan")) // co khoan dtu va dot thanh toan = null
                    {
                        strSQL = "sp_ThanhToan_SuaDLGoc " + MDSolutionApp.VuTrongID.ToString() + "," + grdDauTu.GetValue("ID").ToString() + ",'" + ThuTu.ToString() + "'";
                        DBModule.ExecuteNoneBackup(strSQL, null, null);
                        return true;
                    }
                    else // khoan dau tu da dc thanh toan
                    {
                        _DotThanhToan = ds1.Tables[0].Rows[0]["DotThanhToan"].ToString();
                        if (!ds1.Tables[0].Rows[0].IsNull("NhapTienTraNoID"))
                        {
                            _NhapTienTraNoID = ds1.Tables[0].Rows[0]["NhapTienTraNoID"].ToString();
                            string sql = "Select NgayTra,SoTien From tbl_NhapTienTraNo Where ID=" + _NhapTienTraNoID;
                            ds = DBModule.ExecuteQuery(sql, null, null);
                            DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["NgayTra"].ToString());
                            string sotien = ds.Tables[0].Rows[0]["SoTien"].ToString();
                            MessageBox.Show("Khoản đầu tư này đã được trừ nợ bằng nhập tiền trả nợ. \nNgày nhập tiền: " + dt.ToString("dd/MM/yyyy") + " \n Số tiền: " + sotien, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Khoản đầu tư này đã được thanh toán trong đợt " + _DotThanhToan + ".\nNếu muốn sửa phải thực hiện huỷ đợt thanh toán thứ " + _DotThanhToan, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void uiButtonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                frm_XoaDauTu frmxoadautu = new frm_XoaDauTu();
                if (frmxoadautu.ShowDialog() == DialogResult.OK)
                {
                    /// DataRowView dr = (DataRowView).Row.DataRow;
                    if (Chek_SuaDLGoc())
                    { }
                    else
                    {
                        return;
                    }
                   
                  
                    clsDauTu oDT = new clsDauTu(long.Parse(this.grdDauTu.GetValue("ID").ToString()));
                    oDT.Load(null, null);
                    long XVTID = long.Parse(this.grdDauTu.GetValue("ID").ToString());
                    try
                    {

                        string sqlIDXVT = "select ID from tbl_NhanVatTu where DauTuID=   " + XVTID;
                        int IDX = Int32.Parse(DBModule.ExecuteQueryForOneResult(sqlIDXVT, null, null));
                        clsNhanVatTu oNVT = new clsNhanVatTu(IDX);
                        oNVT.Load(null, null);
                        oNVT.NguoiChuyen = "";                        
                        oNVT.DaChuyenDauTu = 0;
                        oNVT.Save(null, null);
                    }
                    catch { }
                    oDT.NoteModify = frmxoadautu.txtGhiChu.Text;
                    oDT.Save(null, null);
                    oDT.Delete(null, null);
                    /// LoadGrdDauTu();
                }
                LoadGrdDauTu();
                //e.Cancel = true;
            }
            catch
            {
                MessageBox.Show("Bạn phải chọn một mục đầu tư để xóa", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void uiButtonChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                frmShowRP2 frm = new frmShowRP2();
                MDReport.rp_T_ChiTietDauTu rp = new MDSolution.MDReport.rp_T_ChiTietDauTu();
                DataSet ds = new DataSet();
                string HDID = this.grdHopDong.GetValue("ID").ToString();
                string sql = "Select * from V_ChiTietDauTu where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " And HopDongID=" + HDID;
                ds = DBModule.ExecuteQuery(sql, null, null);
                rp.SetDataSource(ds.Tables[0]);
                //rp.RecordSelectionFormula = "{V_ChiTietDauTu.HopDongID}=" + this.grdHopDong.GetValue("ID").ToString() + " AND {V_ChiTietDauTu.VuTrongID}=" + MDSolutionApp.VuTrongID.ToString();
                rp.SetParameterValue("VuTrong", MDSolutionApp.VuTrongTen);
                frm.RP = rp;

                rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                frm.RPtitle = "Báo cáo chi tiết đầu tư.";
                frm.Show();

            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn hợp đồng cần xem", "Thông báo");
            }
        }

        private void uiButtonThem_Click(object sender, EventArgs e)
        {
            //Boolean i = false;
            long ID_HopDong = -1;
            try
            {
                ID_HopDong = long.Parse(this.grdHopDong.GetValue("ID").ToString());
                if (ID_HopDong > 0)
                {
                    frm_NhapDauTu frm = new frm_NhapDauTu(ID_HopDong, true);
                    frm.ShowDialog();
                    if (frm.OK > 0)
                    {
                        LoadGrdDauTu();
                        try
                        {
                            GridEXFilterCondition condi = new GridEXFilterCondition(grdDauTu.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._IDDauTu);
                            grdDauTu.Find(condi, 0, 1);
                        }
                        catch { }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần phải chọn một hợp đồng", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch
            {
                MessageBox.Show("Bạn cần phải chọn một hợp đồng", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //if (i)
            //{
            //    MDDataSetForms.frmDauTu frm = new MDSolution.MDDataSetForms.frmDauTu(long.Parse(this.grdHopDong.GetValue("ID").ToString()), true);
            //    frm.ShowDialog();
            //    LoadGrdDauTu();
            //    try
            //    {
            //        GridEXFilterCondition condi = new GridEXFilterCondition(grdDauTu.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
            //        grdDauTu.Find(condi, 0, 1);
            //    }
            //    catch { }
            //}
            //else
            //{
            //    MDDataSetForms.frmDauTu frm = new MDSolution.MDDataSetForms.frmDauTu(0, true);
            //    frm.ShowDialog();
            //    LoadGrdDauTu();
            //    try
            //    {
            //        GridEXFilterCondition condi = new GridEXFilterCondition(grdDauTu.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._ID);
            //        grdDauTu.Find(condi, 0, 1);
            //    }
            //    catch { }
            //}
        }

        private void uiButtonSuaXoa_Click(object sender, EventArgs e)
        {

            DateTime DenNgay = DateTime.Now;

            string sql = "select isnull(DateReadNotify,'2000-01-01') as DateReadNotify from sys_User ";
            DateTime TuNgay = (DateTime)DBModule.ExecuteQuery(string.Format(sql, MDSolutionApp.User.ID), null, null).Tables[0].Rows[0][0];
            sql = @" SELECT        TOP (100) PERCENT dbo.tbl_HopDong.MaHopDong, dbo.tbl_HopDong.HoTen, dbo.tbl_HopDong.Diachi, dbo.sys_User.HoTen AS NguoiXoa, dbo.tbl_DanhMucCanBoNongVu.Ten AS CBDB, dbo.tbl_DauTu_log.*
                    FROM            dbo.tbl_HopDong INNER JOIN
                         dbo.tbl_Thon ON dbo.tbl_HopDong.ThonID = dbo.tbl_Thon.ID INNER JOIN
                         dbo.tbl_DauTu_log ON dbo.tbl_HopDong.ID = dbo.tbl_DauTu_log.HopDongID INNER JOIN
                         dbo.sys_User ON dbo.tbl_DauTu_log.UserID = dbo.sys_User.ID LEFT OUTER JOIN
                         dbo.tbl_DanhMucCanBoNongVu ON dbo.tbl_Thon.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.ID WHERE dbo.tbl_DauTu_log.Action =2
                            ORDER BY dbo.tbl_DauTu_log.ID DESC";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    frmDauTuLog frm = new frmDauTuLog();
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

        private void uiButton1_Click(object sender, EventArgs e)
        {

        }

        private void uiButtonThemLai_Click(object sender, EventArgs e)
        {
            //Boolean i = false;



            long ID_DauTu = -1;
            long ID_HopDongID = -1;
            try
            {

                ID_DauTu = long.Parse(this.grdDauTu.GetValue("ID").ToString());
                if (ID_DauTu > 0)
                {
                    if (string.IsNullOrEmpty(this.grdDauTu.GetValue("ID").ToString()))
                    {
                        MessageBox.Show("Khoản đầu tư này không có lãi để hỗ trợ");
                        return;
                    }

                    if (string.IsNullOrEmpty(this.grdDauTu.GetValue("IDHTTL").ToString()))
                    {
                    }
                    else
                    {
                        if (long.Parse(this.grdDauTu.GetValue("IDHTTL").ToString()) > 0)
                        {
                            MessageBox.Show("Khoản đầu tư này đã nhập hỗ trợ lãi");
                            return;
                        }
                    }

                    frm_ThemSuaHoTroLai frm = new frm_ThemSuaHoTroLai(ID_DauTu, ID_HopDongID);
                    frm.ShowDialog();
                    if (frm.OK > 0)
                    {
                        LoadGrdDauTu();
                        try
                        {
                            GridEXFilterCondition condi = new GridEXFilterCondition(grdDauTu.Tables[0].Columns["ID"], ConditionOperator.Equal, frm.HTLID);
                            grdDauTu.Find(condi, 0, 1);
                        }
                        catch { }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần phải chọn một đầu tư phù hợp", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch
            {
                MessageBox.Show("Bạn cần phải chọn một đầu tư phù hợp", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void uiButtonSuaLai_Click(object sender, EventArgs e)
        {
            try
            {
                long ID_DauTu = -1;
                ID_DauTu = long.Parse(this.grdDauTu.GetValue("ID").ToString());
                long ID_HTLai = -1;
                if (string.IsNullOrEmpty(this.grdDauTu.GetValue("IDHTTL").ToString()))
                {
                    MessageBox.Show("Không có mục hỗ trợ lãi được sửa");
                    return;
                }

                ID_HTLai = long.Parse(this.grdDauTu.GetValue("IDHTTL").ToString());
                if (ID_DauTu > 0)
                {
                    if (Chek_SuaDLGoc())
                    { }
                    else
                    {
                        return;
                    }
                    if (Chek_SuaHT())
                    {
                    }
                    else
                    {
                        return;
                    }

                    frm_ThemSuaHoTroLai frm = new frm_ThemSuaHoTroLai(ID_HTLai);
                    frm.ShowDialog();
                    if (frm.OK > 0)
                    {
                        LoadGrdDauTu();
                        try
                        {
                            GridEXFilterCondition condi = new GridEXFilterCondition(grdDauTu.Tables[0].Columns["ID"], ConditionOperator.Equal, ID_DauTu);
                            grdDauTu.Find(condi, 0, 1);
                        }
                        catch { }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn phải chọn một mục đầu tư để sửa", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Bạn phải chọn một mục đầu tư để sửa", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void uiButtonXoaLai_Click(object sender, EventArgs e)
        {

            try
            {
                frm_XoaDauTu frmxoadautu = new frm_XoaDauTu();
                if (frmxoadautu.ShowDialog() == DialogResult.OK)
                {
                    /// DataRowView dr = (DataRowView).Row.DataRow;
                    if (Chek_SuaDLGoc())
                    { }
                    else
                    {
                        return;
                    }
                    clsHoTroLai oDT = new clsHoTroLai(long.Parse(this.grdDauTu.GetValue("IDHTTL").ToString()));
                    oDT.Load(null, null);
                    oDT.NoteModify = frmxoadautu.txtGhiChu.Text;
                    oDT.Save(null, null);
                    oDT.Delete(null, null);
                    /// LoadGrdDauTu();
                }
                LoadGrdDauTu();
                //e.Cancel = true;
            }
            catch
            {
                MessageBox.Show("Bạn phải chọn một mục hỗ trợ để xóa hoặc không có để xóa", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}