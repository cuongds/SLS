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
    public partial class frmQuanLyHopDongTrongMia : Form
    {
        static frmQuanLyHopDongTrongMia _thefrmQuanLyHopDongTrongMia;
        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frmQuanLyHopDongTrongMia OneInstanceFrm
        {
            get
            {
                if (null == _thefrmQuanLyHopDongTrongMia || _thefrmQuanLyHopDongTrongMia.IsDisposed)
                {
                    _thefrmQuanLyHopDongTrongMia = new frmQuanLyHopDongTrongMia();
                }

                return _thefrmQuanLyHopDongTrongMia;
            }
        }
        private NodeDonVi nDonVi = new NodeDonVi();
        private clsHopDong oHopDong = new clsHopDong();
        private clsDanhMucCanBoNongVu objCBNV = new clsDanhMucCanBoNongVu();
        private string strPass = "";
        private DataSet gridDataSource;
        private DataSet gridThonSource;
        //private DataSet gridNganHang;
        //private DataSet ddlCanBoNongVuSource;
        frm_HopDongTrongMiaEdit frmChiTiet;
        public frmQuanLyHopDongTrongMia()
        {
            InitializeComponent();
            //this.CreategridEX2ThuaRuongColumn();
            CommonClass.loadTreeDonVi(treeDonVi, MDSolutionApp.User.ID.ToString());
            LoadThonSource();
            //LoadDDLCanBoNongVu();
            //if (Load_PhanQuyen_CacTramID() != "")
                //uiGroupBox6.Enabled = false;
            
            //frmChiTiet = new frm_HopDongTrongMiaEdit();
        }

        private string Load_PhanQuyen_CacTramID()
        {
            string strSQL = "Select CumID From sys_Roles_User_Cum Where UserID=" + MDSolutionApp.User.ID.ToString();
            DataSet ds1 = DBModule.ExecuteQuery(strSQL, null, null);
            string str = "";
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                        str += ds1.Tables[0].Rows[i]["CumID"].ToString();
                    else
                        str += "," + ds1.Tables[0].Rows[i]["CumID"].ToString();
                }
            }
            return str;
        }

        private DataSet LoadHopDong()
        {
            //LoadDDLCanBoNongVu();
            string strSQL = "";
            strSQL = @"SELECT a.*,b.Ten as TenThon, c.Ten as TenXa,dbo.tbl_DanhMucCanBoNongVu.ID as CanBoID ,dbo.tbl_DanhMucCanBoNongVu.Ten as TenCanBoNongVu, dbo.tbl_NganHang.Ten AS TenNganHang
                FROM            dbo.tbl_HopDong AS a INNER JOIN
                         dbo.tbl_Thon AS b ON a.ThonID = b.ID INNER JOIN
                         dbo.tbl_Xa AS c ON c.ID = b.XaID INNER JOIN
                         dbo.tbl_DanhMucCanBoNongVu ON b.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.ID LEFT OUTER JOIN
                         dbo.tbl_NganHang ON a.NganHangID = dbo.tbl_NganHang.ID

                        WHERE a.parentid=0 AND TrangThai = 1 AND a.ID IN (SELECT HopDongID From tbl_HopDongVuTrong Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString() + ")";
            string strCacTramID = Load_PhanQuyen_CacTramID();
            switch (nDonVi.Type)
            {
                case DonviType.Cum: strSQL += " AND a.ThonID IN (SELECT ID FROM tbl_Thon Where XaID IN (SELECT ID From tbl_Xa Where CumID =" + nDonVi.DonViID + "))"; break;
                case DonviType.Xa: strSQL += " AND a.ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
                case DonviType.Thon: strSQL += " AND a.ThonID=" + nDonVi.DonViID; break;
                default: if (strCacTramID != "") strSQL += " And a.ThonID IN (SELECT ID FROM tbl_Thon Where XaID IN (SELECT ID From tbl_Xa Where CumID in (" + strCacTramID + ")))"; break;
            }
            if ((this.chkTimkiemchinhxac.Checked)&&(edtTimKiem.Text!=""))
            {
                strSQL += " AND (a.MaHopDong = N'" + DBModule.RefineString(edtTimKiem.Text) + "' OR a.HoTen = N'" + DBModule.RefineString(edtTimKiem.Text) + "' )";
            }
            else
            {
                strSQL += " AND (a.MaHopDong like N'%" + DBModule.RefineString(edtTimKiem.Text) + "%' OR a.HoTen like N'%" + DBModule.RefineString(edtTimKiem.Text) + "%' )";
            }
            return DBModule.ExecuteQuery(strSQL, null, null);
        }

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
                       
            if (this.gridThonSource.Tables.Count > 0 && this.gridThonSource.Tables[0].Rows.Count > 0)
            {
                this.gdHopDongTrongMia.DropDowns["Thon"].SetDataBinding(this.gridThonSource.Tables[0], "");
                this.gdHopDongTrongMia.Tables[0].Columns["ThonID"].DefaultValue = this.gridThonSource.Tables[0].Rows[0]["ID"];
              
            }
            //try
            //{
            //  string  strSQLnganhang = "Select ID,Ten From tbl_NganHang where ID=" + this.GridEX1.GetValue("NganHangID").ToString();
            //    this.gridNganHang = DBModule.ExecuteQuery(strSQLnganhang, null, null);
            //    if (gridNganHang.Tables[0].Rows.Count > 0)
            //    {
            //        this.GridEX1.DropDowns["DDLNganHang"].SetDataBinding(gridNganHang.Tables[0], "");
            //    }
            //}
            //catch { }
          

        }
        private void LoadDDLCanBoNongVu()
        {
            //string strSQL = "SELECT * FROM tbl_DanhMucCanBoNongVu";
            //this.ddlCanBoNongVuSource = DBModule.ExecuteQuery(strSQL, null, null);
            //this.GridEX1.DropDowns["ddlCanBoNongVu"].SetDataBinding(ddlCanBoNongVuSource.Tables[0], "");
        }      

        private void CreateDataSourceAndBindGrid()
        {
            gridDataSource = this.LoadHopDong();
            if (gridDataSource.Tables.Count > 0)
            {
                this.gdHopDongTrongMia.SetDataBinding(gridDataSource.Tables[0], "");
            }
        }

        private void treeDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                this.DoLoadGridHopDong();
                //uiPanel2.Text = "Đơn vị: " + treeDonVi.SelectedNode.Text.ToUpper() + "/Số HĐ: " + GridEX1.RowCount.ToString();
            }
        }

        private void DoLoadGridHopDong()
        {
            this.LoadThonSource();
           //this.LoadDDLCanBoNongVu();
            this.CreateDataSourceAndBindGrid();
            this.gdHopDongTrongMia.Focus();
            gdHopDongTrongMia.MoveFirst();
            this.gdHopDongTrongMia.Refresh();

        }
        private void treeDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                nDonVi = (NodeDonVi)e.Node.Tag;
                this.DoLoadGridHopDong();
                //uiPanel2.Text = "Đơn vị: " + nDonVi.DonViName.ToUpper() + "/Số HĐ: " + GridEX1.RowCount.ToString();
            }catch{}
        }
        private void GridEX1_RecordAdded(object sender, EventArgs e)
        {
            //MessageBox.Show("Đã thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DoLoadGridHopDong();
            this.gdHopDongTrongMia.Refetch();          
            this.gdHopDongTrongMia.Tables[0].Columns["MaHopDong"].DefaultValue = this.GetMaHopDong();
        }
        private bool IsExistingHoTen(bool isAddnew, string strHoTen, long lThonID)
        {
            if (isAddnew)
            {
                string strSQL = "SELECT Count(*) FROM tbl_HopDong WHERE 1=1 And (rTrim(lTrim([HoTen])) = rTrim(lTrim(N'" + strHoTen + "')))";
                strSQL += " AND ThonID =  " + lThonID.ToString();
                string ret = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                    return false;
                else
                    return true;
            }
            else
            {
                string strSQL = "SELECT * FROM tbl_HopDong WHERE 1=1 And (rTrim(lTrim([HoTen])) = rTrim(lTrim(N'" + strHoTen + "')))";
                strSQL += " AND ThonID =  " + lThonID.ToString();
                DataSet ds;
                ds = DBModule.ExecuteQuery(strSQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow d13 = ds.Tables[0].Rows[0];

                    if (d13["ID"].ToString() != this.gdHopDongTrongMia.GetValue("ID").ToString())
                    { return true; }
                    else { return false; }
 
                }
                    else { return false; }
                
            }
        }
        private bool IsExistingMHD(bool isAddnew, string ContractCode)
        {
            if (isAddnew)
            {
                string SQL = " select Count(*) from tbl_HopDong where MaHopDong = '" + ContractCode + "'";
                string ret = DBModule.ExecuteQueryForOneResult(SQL, null, null);
                if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                    return false;
                else
                    return true;
            }
            else
            {
                string SQL = " select * from tbl_HopDong where MaHopDong = '" + ContractCode + "'";
                DataSet ds;
                ds = DBModule.ExecuteQuery(SQL, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow d13 = ds.Tables[0].Rows[0];

                    if (d13["ID"].ToString() != this.gdHopDongTrongMia.GetValue("ID").ToString())
                    { return true; } 
                    else { return false; } 
                }
                else { return false; }
            }
        }
        private bool IsExistingCMT(string CMT)
        {
            if (!string.IsNullOrEmpty(CMT))
            {
                string SQL = " select Count(*) from tbl_HopDong where SoCMT = '" + CMT + "'";
                string ret = DBModule.ExecuteQueryForOneResult(SQL, null, null);
                if ((string.IsNullOrEmpty(ret)) || (ret == "0"))
                    return false;
                else
                    return true;
            }
            else { return false; }
        }
        private void GridEX1_AddingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                GridEX gr = (GridEX)sender;
                long pID = 0;
                if (gr.Name == "GridEX1")
                {
                    pID = 0;
                }
                else
                {
                    pID = long.Parse(gdHopDongTrongMia.GetValue("ID").ToString());
                }
                if (!this.SaveHopDong(true, pID))
                {

                    e.Cancel = true;
                    //this.GridEX1.Refetch();
                }
                else
                {
                    //if (gr.Name == "GridEX1")
                    //{
                    //    this.GridEX1.SetValue("ID", oHopDong.ID);
                    //}
                    //else
                    //{
                    //    this.gridEX2.SetValue("ID", oHopDong.ID);
                    //}
                }
            }
            catch
            {
                MessageBox.Show("Khi lưu có lỗi,kiểm tra lại");

            }
        }
        private void GridEX1_RecordUpdated(object sender, EventArgs e)
        {
            MessageBox.Show("Đã cập nhật thành công thông tin được thay đổi");
            this.gdHopDongTrongMia.Refetch();
        }

        private bool SaveHopDong(bool isAddNew,long ParentID)
        {

            try
            {
                if (isAddNew)
                {
                    oHopDong = new clsHopDong();
                }
                else
                {
                    oHopDong.ID = long.Parse(this.gdHopDongTrongMia.GetValue("ID").ToString());
                    oHopDong.Load(null, null);
                }

                if (ParentID == 0)
                {
                    //HopDong:
                    if (string.IsNullOrEmpty(this.gdHopDongTrongMia.GetValue("ThonID").ToString())) throw new Exception("Bạn chưa cho biết chủ hợp đồng thuộc thôn nào");

                    oHopDong.ThonID = long.Parse(this.gdHopDongTrongMia.GetValue("ThonID").ToString());

                    if (string.IsNullOrEmpty(this.gdHopDongTrongMia.GetValue("MaHopDong").ToString())) throw new Exception("Bạn chưa cho biết mã hợp đồng");
                    oHopDong.MaHopDong = this.gdHopDongTrongMia.GetValue("MaHopDong").ToString();
                    if (IsExistingMHD(isAddNew, oHopDong.MaHopDong)) throw new Exception("Mã hợp đồng đã có trong đơn vị");
                    if (string.IsNullOrEmpty(this.gdHopDongTrongMia.GetValue("HoTen").ToString())) throw new Exception("Bạn chưa cho biết họ tên của chủ hợp đồng");
                    oHopDong.HoTen = this.gdHopDongTrongMia.GetValue("HoTen").ToString();
                    if (this.IsExistingHoTen(isAddNew, oHopDong.HoTen, oHopDong.ThonID))
                    {
                        if (MessageBox.Show("Đã có hợp đồng có họ tên như vậy trong thôn này, bạn có muốn tiếp tục không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return false;
                        }
                    }

                    if (string.IsNullOrEmpty(this.gdHopDongTrongMia.GetValue("NgaySinh").ToString()))// throw new Exception("Bạn chưa cho biết ngày sinh của chủ hợp đồng");
                    { }
                    else
                    {
                        if (DateTime.Parse(this.gdHopDongTrongMia.GetValue("NgaySinh").ToString()) > DateTime.Now) throw new Exception("Bạn không được nhập ngày sinh lớn hơn ngày hiện tại");
                        oHopDong.NgaySinh = (DateTime)this.gdHopDongTrongMia.GetValue("NgaySinh");
                    }
                    oHopDong.SoCMT = this.gdHopDongTrongMia.GetValue("SoCMT").ToString();
                    if (isAddNew && IsExistingCMT(oHopDong.SoCMT)) throw new Exception("Số chứng minh thư đã có trong đơn vị");

                    if (string.IsNullOrEmpty(this.gdHopDongTrongMia.GetValue("NgayCap").ToString()))
                    { }
                    else
                    {// throw new Exception("Bạn chưa cho biết ngày cấp chứng minh thư của chủ hợp đồng");
                        if (DateTime.Parse(this.gdHopDongTrongMia.GetValue("NgayCap").ToString()) > DateTime.Now) throw new Exception("Bạn không được nhập ngày cấp CMT lớn hơn ngày hiện tại");
                        oHopDong.NgayCap = (DateTime)this.gdHopDongTrongMia.GetValue("NgayCap");
                    }
                    oHopDong.NoiCap = this.gdHopDongTrongMia.GetValue("NoiCap").ToString();
                    oHopDong.NguoiThuaKe1Ten = this.gdHopDongTrongMia.GetValue("NguoiThuaKe1Ten").ToString();
                    oHopDong.NguoiThuaKe1CMT = this.gdHopDongTrongMia.GetValue("NguoiThuaKe1CMT").ToString();
                    oHopDong.NguoiThuaKe1DiaChi = this.gdHopDongTrongMia.GetValue("NguoiThuaKe1DiaChi").ToString();
                    oHopDong.NguoiThuaKe2Ten = this.gdHopDongTrongMia.GetValue("NguoiThuaKe2Ten").ToString();
                    oHopDong.NguoiThuaKe2CMT = this.gdHopDongTrongMia.GetValue("NguoiThuaKe2CMT").ToString();
                    oHopDong.NguoiThuaKe2DiaChi = this.gdHopDongTrongMia.GetValue("NguoiThuaKe2DiaChi").ToString();
                    oHopDong.TrangThai = long.Parse(this.gdHopDongTrongMia.GetValue("TrangThai").ToString());
                    oHopDong.ParentID = ParentID;
                    if (string.IsNullOrEmpty(this.gdHopDongTrongMia.GetValue("NgayKyHopDong").ToString())) throw new Exception("Bạn chưa cho biết ngày ký hợp đồng");
                    oHopDong.NgayKyHopDong = (DateTime)this.gdHopDongTrongMia.GetValue("NgayKyHopDong");
                }
                else
                {
                    ////Chu ho:
                    //if (string.IsNullOrEmpty(this.gridEX2.GetValue("ThonID").ToString())) throw new Exception("Bạn chưa cho biết chủ hợp đồng thuộc thôn nào");

                    //oHopDong.ThonID = long.Parse(this.gridEX2.GetValue("ThonID").ToString());

                    //if (string.IsNullOrEmpty(this.gridEX2.GetValue("MaHopDong").ToString())) throw new Exception("Bạn chưa cho biết mã hợp đồng");
                    //oHopDong.MaHopDong = this.gridEX2.GetValue("MaHopDong").ToString();
                    //if (IsExistingMHD(isAddNew, oHopDong.MaHopDong)) throw new Exception("Mã hợp đồng đã có trong đơn vị");
                    //if (string.IsNullOrEmpty(this.gridEX2.GetValue("HoTen").ToString())) throw new Exception("Bạn chưa cho biết họ tên của chủ hợp đồng");
                    //oHopDong.HoTen = this.gridEX2.GetValue("HoTen").ToString();
                    //if (this.IsExistingHoTen(isAddNew, oHopDong.HoTen, oHopDong.ThonID))
                    //{
                    //    if (MessageBox.Show("Đã có hợp đồng có họ tên như vậy trong thôn này, bạn có muốn tiếp tục không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    //    {
                    //        return false;
                    //    }
                    //}

                    //if (string.IsNullOrEmpty(this.gridEX2.GetValue("NgaySinh").ToString()))// throw new Exception("Bạn chưa cho biết ngày sinh của chủ hợp đồng");
                    //{ }
                    //else
                    //{
                    //    if (DateTime.Parse(this.gridEX2.GetValue("NgaySinh").ToString()) > DateTime.Now) throw new Exception("Bạn không được nhập ngày sinh lớn hơn ngày hiện tại");
                    //    oHopDong.NgaySinh = (DateTime)this.gridEX2.GetValue("NgaySinh");
                    //}
                    //oHopDong.SoCMT = this.gridEX2.GetValue("SoCMT").ToString();
                    //if (isAddNew && IsExistingCMT(oHopDong.SoCMT)) throw new Exception("Số chứng minh thư đã có trong đơn vị");

                    //if (string.IsNullOrEmpty(this.gridEX2.GetValue("NgayCap").ToString()))
                    //{ }
                    //else
                    //{// throw new Exception("Bạn chưa cho biết ngày cấp chứng minh thư của chủ hợp đồng");
                    //    if (DateTime.Parse(this.gridEX2.GetValue("NgayCap").ToString()) > DateTime.Now) throw new Exception("Bạn không được nhập ngày cấp CMT lớn hơn ngày hiện tại");
                    //    oHopDong.NgayCap = (DateTime)this.gridEX2.GetValue("NgayCap");
                    //}
                    //oHopDong.NoiCap = this.gridEX2.GetValue("NoiCap").ToString();
                    //oHopDong.NguoiThuaKe1Ten = this.gridEX2.GetValue("NguoiThuaKe1Ten").ToString();
                    //oHopDong.NguoiThuaKe1CMT = this.gridEX2.GetValue("NguoiThuaKe1CMT").ToString();
                    //oHopDong.NguoiThuaKe1DiaChi = this.gridEX2.GetValue("NguoiThuaKe1DiaChi").ToString();
                    //oHopDong.NguoiThuaKe2Ten = this.gridEX2.GetValue("NguoiThuaKe2Ten").ToString();
                    //oHopDong.NguoiThuaKe2CMT = this.gridEX2.GetValue("NguoiThuaKe2CMT").ToString();
                    //oHopDong.NguoiThuaKe2DiaChi = this.gridEX2.GetValue("NguoiThuaKe2DiaChi").ToString();
                    //oHopDong.TrangThai = long.Parse(this.gridEX2.GetValue("TrangThai").ToString());
                    //oHopDong.ParentID = ParentID;
                    //if (string.IsNullOrEmpty(this.gridEX2.GetValue("NgayKyHopDong").ToString())) throw new Exception("Bạn chưa cho biết ngày ký hợp đồng");
                    //oHopDong.NgayKyHopDong = (DateTime)this.gridEX2.GetValue("NgayKyHopDong");
                }
                //----Save
                oHopDong.Save(null, null);
                clsHopDong.UpdateHopDongVuTrong(oHopDong.ID, MDSolutionApp.VuTrongID, oHopDong.TrangThai, null, null);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        //private void GridEX1_SelectionChanged(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        oHopDong.ID = long.Parse(this.GridEX1.GetValue("ID").ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        oHopDong.ID = -1;
        //    }
        //    this.LoadgridEX2();

        //}

        private void GridEX1_DeletingRecord(object sender, RowActionCancelEventArgs e)
        {
            GridEX gr = (GridEX)sender;
            long ID_ ;
            string message;
            
            if (gr.Name == "GridEX1")
            {
                ID_ = long.Parse(this.gdHopDongTrongMia.GetValue("ID").ToString());
                message = "Bạn muốn xóa HĐ chính đang chọn?";
                if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //clsHopDong oHD = new clsHopDong(long.Parse(dr.Row.ItemArray[0].ToString()));
                    clsHopDong.Delete(ID_, null, null);
                }
                else
                {
                    e.Cancel = true;
                }
            }
          
        }

        private void GridEX1_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.gdHopDongTrongMia.Refetch();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(edtTimKiem.Text))
            {
                if (uiCheckBox1.Checked)
                {
                    nDonVi = (NodeDonVi)treeDonVi.Nodes[0].Tag;
                }
                this.DoLoadGridHopDong();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu tìm kiếm ", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

      
        private void GridEX1_UpdatingRecord(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GridEX gr = (GridEX)sender;
                long pID = 0;
                if (gr.Name == "GridEX1")
                {
                    pID = 0;
                }
                else
                {
                    pID = long.Parse(gdHopDongTrongMia.GetValue("ID").ToString());
                }
                if (!this.SaveHopDong(false, pID))
                {
                    e.Cancel = true;
                    //this.GridEX1.Refetch();
                }
            }
            else
            {
                this.DoLoadGridHopDong();
                e.Cancel = true;
                //this.GridEX1.Refetch();
            }
        }
        private void treeDonVi_AfterSelect(object sender, TreeViewEventArgs e)
        {
           // lblSelectNode.Text = treeDonVi.SelectedNode.Text;
            //this.DoLoadGridHopDong();
            NodeDonVi ndv=(NodeDonVi)treeDonVi.SelectedNode.Tag;
            string TenDonvi = "";
            switch (ndv.Type)
            {
                case DonviType.Root:
                    TenDonvi = "Đơn vị"; break;
                case DonviType.Xa:
                    TenDonvi = "Xã: " + treeDonVi.SelectedNode.Text.ToUpper().Replace("XÃ","").Trim(); break;
                case DonviType.Thon:
                    TenDonvi = "Xã: " + treeDonVi.SelectedNode.Parent.Text.ToUpper().Replace("XÃ", "").Trim() + "  Thôn: " + treeDonVi.SelectedNode.Text.ToUpper().Replace("THÔN", "").Trim();
                    break;

            }
            uiPanel2.Text = TenDonvi+"    ";
            
            
            //uiPanel0.Hide();
        }

        private string GetMaHopDong()
        {
            try
            {
                string strXaID = "";
                // nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                if (nDonVi.Type == DonviType.Xa)
                {
                    strXaID = nDonVi.DonViID;
                }
                else if (nDonVi.Type == DonviType.Thon)
                {
                    clsThon oThon = new clsThon(long.Parse(nDonVi.DonViID));
                    oThon.Load(null, null);
                    strXaID = oThon.XaID.ToString();
                }
                string strSQL = "SELECT [MaXa] FROM tbl_Xa Where [ID]=" + strXaID;
                string maXa = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                string strMaxID = "";
                int batdau = maXa.Trim().Length +1;
                strSQL = "SELECT max(cast(ltrim(rtrim(substring(mahopdong,"+batdau.ToString()+", 10))) as numeric(10))) FROM tbl_HopDong WHERE ThonID in (SELECT [id] FROM tbl_Thon WHERE XaID =" + strXaID + ") ";
                strMaxID = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                if (strMaxID == "") strMaxID = "0";
                int intMaxID = int.Parse(strMaxID);
                intMaxID++;
                return maXa + intMaxID.ToString();
            }
            catch
            {
                return "";
            }


        }

        private void frmQuanLyHopDongTrongMia_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        public void GetThonID(string strPassValue)
        {
            strPass = strPassValue;
        }
        private void GridEX1_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {

            GridEX gr = (GridEX)sender;
            bool isGridEX1 = true;
            if (gr.Name == "GridEX1")
            {
                isGridEX1 = true;
            }
            else
            {
                isGridEX1 = false;
            }

            if (e.Column.Key == "TenThon")
            {

                //NodeDonVi TnDonVi  = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                
                dlgChonThonChoThuaRuong frm = new dlgChonThonChoThuaRuong(nDonVi.DonViName, nDonVi.DonViID, nDonVi.Type);
                frm.passID = new dlgChonThonChoThuaRuong.PassID(GetThonID);
                int Wherex = MousePosition.X;
                int Wherey = MousePosition.Y;
                if (Wherey + frm.Height > 768) Wherey = 768 - frm.Height;
                if (Wherex + frm.Width > 1024) Wherex = 1024 - frm.Width;
                frm.SetDesktopLocation(Wherex, Wherey);
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        int Post = strPass.IndexOf("$");
                        string str = strPass.Substring(0, Post);
                        if (isGridEX1 == true)
                        {
                            this.gdHopDongTrongMia.SetValue("ThonID", long.Parse(str));
                            this.gdHopDongTrongMia.SetValue("TenThon", strPass.Substring(Post + 1));
                        }
                        else
                        {
                            //this.gridEX2.SetValue("ThonID", long.Parse(str));
                            //this.gridEX2.SetValue("TenThon", strPass.Substring(Post + 1));
                        }

                    }
                    catch (Exception ex)
                    {
                        if (isGridEX1 == true)
                        {
                            this.gdHopDongTrongMia.SetValue("ThonID", -1);
                            this.gdHopDongTrongMia.SetValue("TenThon", "");
                        }
                        else
                        {
                            //this.gridEX2.SetValue("ThonID", -1);
                            //this.gridEX2.SetValue("TenThon", "");
                        }
                    }
                    
                }
            }
            if (e.Column.Key == "btnmenu")
            {
                if (isGridEX1 == true)
                {
                    ToolStripMenuItemThemChuHoDaCo.Enabled = true;
                    ToolStripMenuItemChuyenThanhHD.Enabled = false;
                    ToolStripMenuItemChuyenHDChinhKhac.Enabled = false;
                    if (gdHopDongTrongMia.SelectedItems[0].RowType == RowType.NewRecord) return;
                } 
                else
                {
                    ToolStripMenuItemThemChuHoDaCo.Enabled = false;
                    ToolStripMenuItemChuyenThanhHD.Enabled = true;
                    ToolStripMenuItemChuyenHDChinhKhac.Enabled = true;
                    //if (gridEX2.SelectedItems[0].RowType == RowType.NewRecord) return;
                }
               

                this.contextRight.Show(MousePosition);
            }
        }

        private void toolChitiethopdong_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.gdHopDongTrongMia.GetValue("ID").ToString()))
                {
                    long oID = long.Parse(this.gdHopDongTrongMia.GetValue("ID").ToString());

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
                string ID = this.gdHopDongTrongMia.GetValue("ID").ToString();

                frmDienTichCoCauTrong frm = new frmDienTichCoCauTrong(ID);
                frm.MdiParent = this.MdiParent;
                frm.Show();
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
                string ID = this.gdHopDongTrongMia.GetValue("ID").ToString();

                frmQuanLyDauTuNoCu frm = new frmQuanLyDauTuNoCu(ID);
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
                string ID = this.gdHopDongTrongMia.GetValue("ID").ToString();

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
                string ID = this.gdHopDongTrongMia.GetValue("ID").ToString();

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
                frmThanhToan_DauTu_TruNo frm = new frmThanhToan_DauTu_TruNo(this.gdHopDongTrongMia.GetValue("ID").ToString());
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
                frmThanhToan_TienCo_TruNo frm = new frmThanhToan_TienCo_TruNo(this.gdHopDongTrongMia.GetValue("ID").ToString());
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
                        //Code cho F1
                        //dlgHopDongVanChuyen frm = new dlgHopDongVanChuyen();
                        //frm.ShowDialog();
                        //frmChiTiet = new frm_HopDongTrongMiaEdit();
                        //frmChiTiet.Themmoi_Click = true;// Them_Click(null, null);
                        //frmChiTiet.ShowDialog();
                        //nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                        
                        
                        //this.DoLoadGridHopDong();

                        btThem_Click(null, null);
                        
                        //GridEX1.EditMode = EditMode.EditOn;
                        //GridEX1.MoveToNewRecord();
                        
                        //uiPanel3.Text = "F2-Lưu / Esc-Bỏ qua";
                        break;

                    case Keys.F4:
                        //Code cho F4
                        try
                        {
                            if (!string.IsNullOrEmpty(this.gdHopDongTrongMia.GetValue("ID").ToString()))
                            {
                                long oID = long.Parse(this.gdHopDongTrongMia.GetValue("ID").ToString());

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
                        //GridEX1.EditMode = EditMode.EditOn;
                        //uiPanel3.Text = "F2-Lưu / Esc-Bỏ qua";
                        //frmChiTiet = new frm_HopDongTrongMiaEdit();
                        //frmChiTiet.tbl_HopDongBindingSource.Filter = "ID=" + GridEX1.GetValue("ID").ToString();
                        //frmChiTiet.ShowDialog();
                        

                        //nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                        //this.DoLoadGridHopDong();
                        btSua_Click(null, null);
                        break;
                    case Keys.Escape :
                        // Code cho phim Esc
                        gdHopDongTrongMia.CancelCurrentEdit();
                        //gridEX2.CancelCurrentEdit();
                        uiPanel3.Text = "F8-Thêm mới / F9-Sửa / F4-Chi tiết / Delete-Xóa / F6-In danh sách";
                        
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
                    //Shift dùng cho các chủ hộ:
                    case Keys.Shift|Keys.F8:
                        //Code cho F1
                        //dlgHopDongVanChuyen frm = new dlgHopDongVanChuyen();
                        //frm.ShowDialog();
                        //frmChiTiet = new frm_HopDongTrongMiaEdit();
                        //frmChiTiet.Themmoi_Click = true;
                        //try
                        //{
                        //    frmChiTiet._PerentID = long.Parse(GridEX1.GetValue("ID").ToString());
                        //}
                        //catch { }
                        //frmChiTiet.ShowDialog();

                        //GridEX1_SelectionChanged(null, null);

                        uiButton4_Click(null, null);
                        //GridEX1.EditMode = EditMode.EditOn;
                        //GridEX1.MoveToNewRecord();

                        //uiPanel3.Text = "F2-Lưu / Esc-Bỏ qua";
                        break;

                    case Keys.Shift|Keys.F4:
                        //Code cho F4
                        //try
                        //{
                        //    if (!string.IsNullOrEmpty(this.gridEX2.GetValue("ID").ToString()))
                        //    {
                        //        long oID = long.Parse(this.gridEX2.GetValue("ID").ToString());

                        //        frmViewHopDong aa = new frmViewHopDong(oID);
                        //        aa.MdiParent = this.MdiParent;
                        //        aa.Show();
                        //    }
                        //}
                        //catch
                        //{
                        //    MessageBox.Show("Chọn chính xác chủ hộ cần xem chi tiết");
                        //}
                        break;
                    case Keys.Shift | Keys.F9:
                        //GridEX1.EditMode = EditMode.EditOn;
                        //uiPanel3.Text = "F2-Lưu / Esc-Bỏ qua";
                        //frmChiTiet = new frm_HopDongTrongMiaEdit();
                        //frmChiTiet.tbl_HopDongBindingSource.Filter = "ID=" + gridEX2.GetValue("ID").ToString();
                        //frmChiTiet.ShowDialog();
                        //GridEX1_SelectionChanged(null, null);
                        uiButton3_Click(null, null);
                        break;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void GridEX1_Enter(object sender, EventArgs e)
        {
            //gridEX2.SetDataBinding(null, "");
            //try
            //{
            //    gridEX2.SetDataBinding(LoadHopDong_Con().Tables[0], "");
            //}
            //catch { gridEX2.SetDataBinding(null, ""); }

        }
        private DataSet LoadHopDong_Con()
        {
            string strSQL = "";
            strSQL = @"SELECT a.*,b.Ten as TenThon FROM tbl_HopDong as a LEFT JOIN tbl_Thon as b ON a.ThonID=b.ID WHERE a.parentid= " + gdHopDongTrongMia.GetValue("ID").ToString();
            return DBModule.ExecuteQuery(strSQL, null, null);
        }

        private void GridEX1_SelectionChanged(object sender, EventArgs e)
        {
            //gridEX2.SetDataBinding(null, "");
            //try
            //{
            //    DataTable dt = LoadHopDong_Con().Tables[0];
            //    //if(dt.Rows.Count>0)//
            //    {
            //    gridEX2.SetDataBinding(dt, "");
            //    this.gridEX2.Tables[0].Columns["MaHopDong"].DefaultValue = this.GetMaHopDong();
            //    this.gridEX2.Tables[0].Columns["NgayKyHopDong"].DefaultValue = DateTime.Now;
            //    }
            //}
            //catch { gridEX2.SetDataBinding(null, ""); }
        }

        private void ToolStripMenuItemChuyenThanhHD_Click(object sender, EventArgs e)
        {
            try
            {
                //oHopDong = new clsHopDong();
                ////oHopDong.ID = long.Parse(gridEX2.GetValue("ID").ToString());
                //oHopDong.Load(null, null);
                //oHopDong.ParentID = 0;
                //oHopDong.Save(null, null);
                //MessageBox.Show("Việc chuyển đổi đã thành công!", "Thông báo");
                //this.DoLoadGridHopDong();
            }
            catch
            {
                MessageBox.Show("Có lỗi trong khi chuyển đổi", "Lỗi");
            }
        }

        //private void checkBox2_CheckedChanged(object sender, EventArgs e)
        //{
        //    uiGroupBox6.Visible = checkBox2.Checked;
        //}

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    uiGroupBox1.Visible = checkBox1.Checked;
        //}

        private void btThem_Click(object sender, EventArgs e)
        {
            frmChiTiet = new frm_HopDongTrongMiaEdit();
            frmChiTiet.Themmoi_Click = true;// Them_Click(null, null);
            try
            {
                nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                //if(nDonVi.Type == DonviType.Xa)
                //    frmChiTiet._ThonID = long.Parse(nDonVi.DonViID);

                if (nDonVi.Type == DonviType.Thon)
                    frmChiTiet._ThonID = long.Parse(nDonVi.DonViID);
                        
            }
            catch { }
            try
            {
                frmChiTiet._ThonID = long.Parse(gdHopDongTrongMia.GetValue("ThonID").ToString());
            }
            catch { }
            frmChiTiet.ShowDialog();
            try
            {
                nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                this.DoLoadGridHopDong();
            }
            catch { }
            try
            {
                GridEXFilterCondition condi = new GridEXFilterCondition(gdHopDongTrongMia.Tables[0].Columns["ID"], ConditionOperator.Equal, frmChiTiet._ID);
                gdHopDongTrongMia.Find(condi, 0, 1);
            }
            catch { }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                frmChiTiet = new frm_HopDongTrongMiaEdit();
                object objid=gdHopDongTrongMia.GetValue("ID");
                //frmChiTiet.tbl_HopDongBindingSource.Filter = "ID=" + GridEX1.GetValue("ID").ToString();
                frmChiTiet._ID= long.Parse(gdHopDongTrongMia.GetValue("ID").ToString());
                frmChiTiet.MaHD = gdHopDongTrongMia.GetValue("MaHopDong").ToString();
                frmChiTiet.HoTen = gdHopDongTrongMia.GetValue("HoTen").ToString();
                frmChiTiet.DiaChi = gdHopDongTrongMia.GetValue("DiaChi").ToString();
                frmChiTiet._PerentID = 0;
                try
                {
                    nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                    if (nDonVi.Type == DonviType.Thon)
                        frmChiTiet._ThonID = long.Parse(nDonVi.DonViID);
                }
                catch { }
                try
                {
                    frmChiTiet._ThonID = long.Parse(gdHopDongTrongMia.GetValue("ThonID").ToString());
                }
                catch { }
                try
                {
                    frmChiTiet._CanBoNongVuID = long.Parse(gdHopDongTrongMia.GetValue("CanBoID").ToString());
                }
                catch { }
              


                frmChiTiet.ShowDialog();

                try
                {
                    nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                    this.DoLoadGridHopDong();
                }
                catch { }
                GridEXFilterCondition condi=new GridEXFilterCondition(gdHopDongTrongMia.Tables[0].Columns["ID"],ConditionOperator.Equal,objid);
                gdHopDongTrongMia.Find(condi, 0, 1);
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn hđ cần sửa","Thông báo");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "Delete from tbl_hopdong where id=" + gdHopDongTrongMia.GetValue("ID").ToString();

                if (MessageBox.Show("Bạn muốn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        DBModule.ExecuteNonQuery(sql, null, null);
                        string sqllog = @"INSERT INTO [dbo].[sys_HopDong_log]
                                       ([HopDongID]
                                       ,[MaHopDong]
                                       ,[CreateDate]
                                       ,[CreateBy]
                                       ,[NoiDung]
                                       ,[Type],HoTen,DiaChi)
                                 VALUES
                                       ({0}
                                       ,N'{1}'
                                       ,getdate()
                                       ,N'{2}'
                                       ,N'{3}'
                                       ,N'{4}',N'{5}',N'{6}');";
                        DBModule.ExecuteQuery(string.Format(sqllog, gdHopDongTrongMia.GetValue("ID"), gdHopDongTrongMia.GetValue("MaHopDong"), MDSolutionApp.User.HoTen, "Mã hđ:" + gdHopDongTrongMia.GetValue("MaHopDong") + "\r\n; Họ tên:" + gdHopDongTrongMia.GetValue("HoTen"), "Xóa", gdHopDongTrongMia.GetValue("HoTen"), gdHopDongTrongMia.GetValue("DiaChi")), null, null);
                        try
                        {
                            nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                            this.DoLoadGridHopDong();
                        }
                        catch { }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi:" + ex, "Lỗi");
                    }
                }
            }
            catch { MessageBox.Show("Bạn chưa chọn bản ghi cần xóa", "Thông báo"); }
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.gdHopDongTrongMia.GetValue("ID").ToString()))
                {
                    long oID = long.Parse(this.gdHopDongTrongMia.GetValue("ID").ToString());

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

        private void uiButton4_Click(object sender, EventArgs e)
        {
            //frmChiTiet = new frm_HopDongTrongMiaEdit();
            //frmChiTiet.Themmoi_Click = true;
            //frmChiTiet.isChuHo = true;
            //try
            //{
            //    nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
            //    if (nDonVi.Type == DonviType.Thon)
            //        frmChiTiet._ThonID = long.Parse(nDonVi.DonViID);
            //}
            //catch { }
            //try
            //{
            //    frmChiTiet._ThonID = long.Parse(GridEX1.GetValue("ThonID").ToString());
            //}
            //catch { }
            //try
            //{
            //    frmChiTiet._PerentID = long.Parse(GridEX1.GetValue("ID").ToString());
            //}
            //catch { }
            //frmChiTiet.ShowDialog();
            //try
            //{
            //    GridEX1_SelectionChanged(null, null);
            //}
            //catch { }
            //try
            //{
            //    GridEXFilterCondition condi = new GridEXFilterCondition(gridEX2.Tables[0].Columns["ID"], ConditionOperator.Equal, frmChiTiet._ID);
            //    gridEX2.Find(condi, 0, 1);
            //}
            //catch { }
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmChiTiet = new frm_HopDongTrongMiaEdit();
            //    object objid = GridEX1.GetValue("ID");
            //    frmChiTiet._ID = long.Parse(gridEX2.GetValue("ID").ToString());
            //    frmChiTiet.isChuHo = true;
            //    try
            //    {
            //        nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
            //        if (nDonVi.Type == DonviType.Thon)
            //            frmChiTiet._ThonID = long.Parse(nDonVi.DonViID);
            //    }
            //    catch { }
            //    try
            //    {
            //        frmChiTiet._ThonID = long.Parse(GridEX1.GetValue("ThonID").ToString());
            //    }
            //    catch { }
            //    frmChiTiet.ShowDialog();
            //    try
            //    {
            //        GridEX1_SelectionChanged(null, null);
            //    }
            //    catch { }
            //}
            //catch 
            //{
            //    MessageBox.Show("Chưa chọn chủ hộ cần sửa","Thông báo");
            //}
            //try
            //{
            //    GridEXFilterCondition condi = new GridEXFilterCondition(gridEX2.Tables[0].Columns["ID"], ConditionOperator.Equal, frmChiTiet._ID);
            //    gridEX2.Find(condi, 0, 1);
            //}
            //catch { }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string sql = "Delete from tbl_hopdong where id=" + gridEX2.GetValue("ID").ToString();
            //    if (MessageBox.Show("Bạn muốn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        try
            //        {
                        
            //            DBModule.ExecuteNonQuery(sql, null, null);
            //            try
            //            {
            //                GridEX1_SelectionChanged(null, null);
            //            }
            //            catch { }
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Lỗi:" + ex, "Lỗi");
            //        }
            //    }
            //}
            //catch { MessageBox.Show("Chưa chọn bản ghi cần xóa", "Thông báo"); }
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!string.IsNullOrEmpty(this.gridEX2.GetValue("ID").ToString()))
            //    {
            //        long oID = long.Parse(this.gridEX2.GetValue("ID").ToString());

            //        frmViewHopDong aa = new frmViewHopDong(oID);
            //        aa.MdiParent = this.MdiParent;
            //        aa.Show();
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
            //}
        }

        private void GridEX1_DoubleClick(object sender, EventArgs e)
        {
            btSua_Click(null, null);
        }

       
        private void BtNhapNganHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdHopDongTrongMia.GetValue("ID").ToString() == "")
                {
                    frmEditNganHang frm = new frmEditNganHang();
                    frm.ShowDialog();
                }
                else
                {
                    frmEditNganHang frm = new frmEditNganHang(long.Parse(gdHopDongTrongMia.GetValue("ID").ToString()));
                    frm.ShowDialog();
                }
            }
            catch
            {
                frmEditNganHang frm = new frmEditNganHang();
                frm.ShowDialog();
            }

            try
            {
                nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                this.DoLoadGridHopDong();
            }
            catch { }
        }

        private void cmdXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = gdHopDongTrongMia;
                        exporter.Export(fs);
                        fs.Close();
                        MessageBox.Show("Đã xuất dữ liệu ra Excel!", "SLS", MessageBoxButtons.OK);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btn_MuaTaiBanCan_Click(object sender, EventArgs e)
        {
             frmChiTiet._ID= long.Parse(gdHopDongTrongMia.GetValue("ID").ToString());           
        }

      

    }
}