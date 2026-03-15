using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace MDSolution
{
    public partial class frm_KeHoach_TheoDoiTienDoThuHoach : Form
    {
        static frm_KeHoach_TheoDoiTienDoThuHoach _frm_KeHoach_TheoDoiTienDoThuHoach;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_KeHoach_TheoDoiTienDoThuHoach OneInstanceFrm
        {
            get
            {
                if (null == _frm_KeHoach_TheoDoiTienDoThuHoach || _frm_KeHoach_TheoDoiTienDoThuHoach.IsDisposed)
                {
                    _frm_KeHoach_TheoDoiTienDoThuHoach = new frm_KeHoach_TheoDoiTienDoThuHoach();
                }

                return _frm_KeHoach_TheoDoiTienDoThuHoach;
            }
        }
        DateTime NgayHomNay = DateTime.Now;
        bool AllowedModify = false;
        bool AllowedModifyVung = false;
        public frm_KeHoach_TheoDoiTienDoThuHoach()
        {
            InitializeComponent();
        }

     
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmdFind_Click(object sender, EventArgs e)
        {
           
        }

        private void gd_DSVungNguyenLieu_AddingRecord(object sender, CancelEventArgs e)
        {
            string TV = gd_DSVungNguyenLieu.GetValue("TenVung").ToString();
            if (!string.IsNullOrEmpty(TV))
            {
                if (CheckTenVung(TV.Replace(" ", ""), -1))
                {
                    try
                    {
                        clsCacVungNguyenLieu oVung = new clsCacVungNguyenLieu();
                        oVung.TenVung = TV;
                        oVung.Save(null, null);
                        Load_DS_Vung();
                        MessageBox.Show("Đã thêm mới thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi thêm mới!\n" + ex.Message, "SLS");
                    }
                }
                else
                {
                    MessageBox.Show("Đã tồn tại tên vùng nguyên liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Load_DS_Vung();
                }
            }
            else
            {
                MessageBox.Show("Tên vùng nguyên liệu không được để trống!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
        private void Load_DS_Vung()
        {
            string sql = "Select * From tbl_CacVungNguyenLieu Order By XaID,ID";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gd_DSVungNguyenLieu.SetDataBinding(ds.Tables[0], "RootTable");
                if (AllowedModify==false)
                {
                    this.gd_DSVungNguyenLieu.RootTable.Columns["Add"].Visible = false;
                    //this.gdDS_CBDB.RootTable.Columns["Delete"].Visible = false;
                }
            }
            else
            {
                this.gd_DSVungNguyenLieu.DataSource = null;
            }
        }
        private bool CheckTenVung(string value, long ID)
        {
            string ret = "";
            if (ID > 0)
            {
                ret = DBModule.ExecuteQueryForOneResult("Select TenVung from tbl_CacVungNguyenLieu Where Lower(Replace(TenVung,' ',''))=N'" + value + "'", null, null).ToString();
                if (string.IsNullOrEmpty(ret))
                {
                    return true;
                }
                else
                {
                    long lID = long.Parse(DBModule.ExecuteQueryForOneResult("Select ID from tbl_CacVungNguyenLieu Where Lower(Replace(TenVung,' ',''))=N'" + value + "'", null, null).ToString());
                    if (ID == lID)
                    {
                        return true;
                    }
                    else return false;
                }

            }
            else
            {
                ret = DBModule.ExecuteQueryForOneResult("Select TenVung from tbl_CacVungNguyenLieu Where Lower(Replace(TenVung,' ',''))=N'" + value + "'", null, null).ToString();
                if (string.IsNullOrEmpty(ret)) { return true; } else { return false; }
            }
        }

        private void gd_DSVungNguyenLieu_UpdatingRecord(object sender, CancelEventArgs e)
        {
            string TV = gd_DSVungNguyenLieu.GetValue("TenVung").ToString();
            long IDVung = long.Parse(gd_DSVungNguyenLieu.GetValue("ID").ToString());
            if (!string.IsNullOrEmpty(TV))
            {
                if (CheckTenVung(TV.Replace(" ", ""), IDVung))
                {
                    try
                    {
                        clsCacVungNguyenLieu oVung = new clsCacVungNguyenLieu(IDVung);
                        oVung.Load(null, null);
                        oVung.TenVung = TV;
                        oVung.Save(null, null);
                        Load_DS_Vung();
                        MessageBox.Show("Đã sửa thành công!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi thêm mới!\n" + ex.Message, "SLS");
                    }
                }
                else
                {
                    MessageBox.Show("Đã tồn tại tên vùng nguyên liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Load_DS_Vung();
                }
            }
            else
            {
                MessageBox.Show("Tên vùng nguyên liệu không được để trống!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void gd_DSVungNguyenLieu_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "Add")
            {
                long ID_Vung = 0;
                string TV = "";
                try
                {
                    long.TryParse(this.gd_DSVungNguyenLieu.GetValue("ID").ToString(), out ID_Vung);
                    TV = this.gd_DSVungNguyenLieu.GetValue("TenVung").ToString();
                }
                catch
                {
                    MessageBox.Show("Bạn cần chọn vùng nguyên liệu để thao tác!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ID_Vung > 0)
                {
                    MDSolution.MDForms.ThuHoach.frm_ChonCBDB frm= new MDSolution.MDForms.ThuHoach.frm_ChonCBDB(ID_Vung, TV);
                    frm.ShowDialog();
                    if (frm.OK > 0)
                    {
                        LoadCBDB(ID_Vung);
                    }
                }
             }
        }
        private void LoadThon(long Xa_ID)
        {
            string sql = "Select ID,Ten,0 AS NhomTruong From tbl_Thon Where XaID=" + Xa_ID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            this.gdDS_CBDB.SetDataBinding(ds.Tables[0], "RootTable");
        }
        private void LoadCBDB(long VNLID)
        {
            string sql = "SELECT tbl_CacVungNguyenLieu_CBDB.ID,dbo.tbl_DanhMucCanBoNongVu.id AS CBDBID, dbo.tbl_DanhMucCanBoNongVu.Ten, dbo.tbl_CacVungNguyenLieu_CBDB.NhomTruong,tbl_CacVungNguyenLieu_CBDB.VungNguyenLieuID " +
                         " FROM  dbo.tbl_CacVungNguyenLieu_CBDB INNER JOIN dbo.tbl_DanhMucCanBoNongVu ON dbo.tbl_CacVungNguyenLieu_CBDB.CBDBID = dbo.tbl_DanhMucCanBoNongVu.ID"+
                         " Where VungNguyenLieuID=" + VNLID.ToString()+" Order By NhomTruong DESC";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if(ds.Tables[0].Rows.Count>0)
            {
                this.gdDS_CBDB.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdDS_CBDB.DataSource = null;
            }
        }
        private void gd_DSVungNguyenLieu_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gd_DSVungNguyenLieu.CurrentRow.RowType == RowType.Record)
            {
                long XaID = 0;
                long VNL_ID = 0;
                string Ten_Vung=this.gd_DSVungNguyenLieu.GetValue("TenVung").ToString();
                long.TryParse(this.gd_DSVungNguyenLieu.GetValue("ID").ToString(), out VNL_ID);
                long.TryParse(this.gd_DSVungNguyenLieu.GetValue("XaID").ToString(),out XaID);
                if ((VNL_ID > 0) && (XaID <= 0))
                {
                    this.gd_DSVungNguyenLieu.RootTable.Columns["Add"].Visible = true;
                    this.gdDS_CBDB.RootTable.Columns["Delete"].Visible = true;
                    this.grDS_CBDB.Text = "Danh sách các CBĐB";
                    this.gdDS_CBDB.RootTable.Columns["Ten"].Caption = "Các cán bộ địa bàn thuộc "+Ten_Vung;
                    LoadCBDB(VNL_ID);
                }
               
                if ((XaID > 0)&&(VNL_ID>0))
                {
                    this.gd_DSVungNguyenLieu.RootTable.Columns["Add"].Visible = false;
                    this.gdDS_CBDB.RootTable.Columns["Delete"].Visible = false;
                    this.grDS_CBDB.Text = "Danh sách các thôn bản/đội sản xuất";
                    this.gdDS_CBDB.RootTable.Columns["Ten"].Caption = "Danh sách các thôn bản/đội sản xuất thuộc "+Ten_Vung;
                    LoadThon(XaID);
                }
                if (AllowedModifyVung==false)
                {
                    this.gd_DSVungNguyenLieu.RootTable.Columns["Add"].Visible = false;
                    this.gdDS_CBDB.RootTable.Columns["Delete"].Visible = false;
                }
         
            }
        }

        private void tabKeHoach_TheoDoiThuHoach_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (e.Page.Index == 0)
            {
                LoadDS_KeHoach_CoSan();
                try
                {
                    DataSet ds = DBModule.ExecuteQuery("select YEAR(GETDATE()) as Nam, MONTH(GETDATE()) as Thang, DAY(GETDATE()) as Ngay", null, null);
                    int Nam = int.Parse(ds.Tables[0].Rows[0]["Nam"].ToString());
                    int Thang = int.Parse(ds.Tables[0].Rows[0]["Thang"].ToString());
                    int Ngay = int.Parse(ds.Tables[0].Rows[0]["Ngay"].ToString());
                    DateTime NgayHomNay = new DateTime(Nam, Thang, Ngay, 0, 0, 0);
                    GridEXFilterCondition condi = new GridEXFilterCondition(this.gdCacKeHoachCoSan.RootTable.Columns["NgayKeHoach"], ConditionOperator.Equal, NgayHomNay);
                    this.gdCacKeHoachCoSan.Find(condi, 0, 1);
                }
                catch
                {
                    this.gdCacKeHoachCoSan.MoveFirst();
                }
            }
            if (e.Page.Index == 1)
            {
                Load_DSKeHoach();
                try
                {
                    DataSet ds = DBModule.ExecuteQuery("select YEAR(GETDATE()) as Nam, MONTH(GETDATE()) as Thang, DAY(GETDATE()) as Ngay", null, null);
                    int Nam = int.Parse(ds.Tables[0].Rows[0]["Nam"].ToString());
                    int Thang = int.Parse(ds.Tables[0].Rows[0]["Thang"].ToString());
                    int Ngay = int.Parse(ds.Tables[0].Rows[0]["Ngay"].ToString());
                    DateTime NgayHomNay = new DateTime(Nam, Thang, Ngay, 0, 0, 0);
                    GridEXFilterCondition condi = new GridEXFilterCondition(this.gdDSKeHoachNgay.RootTable.Columns["NgayKeHoach"], ConditionOperator.Equal, NgayHomNay);
                    this.gdDSKeHoachNgay.Find(condi, 0, 1);
                }
                catch
                {
                    this.gdDSKeHoachNgay.MoveFirst();
                }
            }
           if (e.Page.Index == 2)
           {
               Load_DS_Vung();
           }
        }

        private void gdDS_CBDB_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e.Row.RowType == RowType.Record)
            {
                long NhomTruong = 0;
                try
                {
                    NhomTruong=long.Parse(e.Row.Cells["NhomTruong"].Value.ToString());
                }
                catch
                {
                
                }
                if (NhomTruong >0)
                {
                    Janus.Windows.GridEX.GridEXFormatStyle NhomTruong_Format = new GridEXFormatStyle();
                    NhomTruong_Format.ForeColor = Color.Red;
                    e.Row.RowStyle = NhomTruong_Format;
                }
            }
        }

        private void gdDS_CBDB_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "Delete")
            {
                try
                {
                    long ID_CBDB = 0;
                    long VNL_ID = 0;
                    long.TryParse(this.gdDS_CBDB.GetValue("VungNguyenLieuID").ToString(), out VNL_ID);
                    long.TryParse(this.gdDS_CBDB.GetValue("ID").ToString(), out ID_CBDB);
                    string TenCBDB = this.gdDS_CBDB.GetValue("Ten").ToString();
                    if ((ID_CBDB > 0)&&(VNL_ID>0))
                    {
                        if (MessageBox.Show("Bạn chắc chắn xóa " + TenCBDB.Trim() + " khỏi vùng", "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        clsCacVungNguyenLieu_CBDB.Delete(ID_CBDB, null, null);
                        LoadCBDB(VNL_ID);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Đã có lỗi khi xóa\n"+ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
              }
            }

        private void frm_KeHoach_TheoDoiTienDoThuHoach_Load(object sender, EventArgs e)
        {
            lblTittle.Text = lblTittle.Text + MDSolutionApp.VuTrongTen;
            lblLapKeHoach_Title.Text = lblLapKeHoach_Title.Text + MDSolutionApp.VuTrongTen;
            lblTheoDoiThuHoach_Title.Text = lblTheoDoiThuHoach_Title.Text + MDSolutionApp.VuTrongTen;
            DataSet ds = DBModule.ExecuteQuery("select YEAR(GETDATE()) as Nam, MONTH(GETDATE()) as Thang, DAY(GETDATE()) as Ngay", null, null);
            int Nam = int.Parse(ds.Tables[0].Rows[0]["Nam"].ToString());
            int Thang = int.Parse(ds.Tables[0].Rows[0]["Thang"].ToString());
            int Ngay = int.Parse(ds.Tables[0].Rows[0]["Ngay"].ToString());
            NgayHomNay = new DateTime(Nam, Thang, Ngay, 0, 0, 0);
            dtKHDen.Value = NgayHomNay.AddDays(10);
            dtKHTu.Value = NgayHomNay.AddDays(-3);
            dtTuNgay_KHCoSan.Value = NgayHomNay.AddDays(-3);
            dtDenNgay_KHCoSan.Value = NgayHomNay.AddDays(10);
          
            if ((MDSolutionApp.User.RolesID == 0) || (MDSolutionApp.User.IsAdvance == 101))
            {
                AllowedModify = true;
                AllowedModifyVung = true;
            }
            else
            {
                AllowedModify = false;
                cmdThemKH.Enabled=false;
                this.gdDSKeHoachNgay.RootTable.Columns["KhongChe"].EditType = EditType.NoEdit;
                this.gd_DSVungNguyenLieu.RootTable.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False;
                this.gd_DSVungNguyenLieu.RootTable.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            }
            if ((MDSolutionApp.User.IsAdvance == 111)||(MDSolutionApp.User.IsAdvance==101))
            {
                this.gdDSKeHoachNgay.RootTable.Columns["KhongChe"].EditType = EditType.CheckBox;
                AllowedModify = true;
            }
            LoadDS_KeHoach_CoSan();
            try
            {
                GridEXFilterCondition condi = new GridEXFilterCondition(this.gdCacKeHoachCoSan.RootTable.Columns["NgayKeHoach"], ConditionOperator.Equal, NgayHomNay);
                this.gdCacKeHoachCoSan.Find(condi, 0, 1);
            }
            catch
            {
                this.gdCacKeHoachCoSan.MoveFirst();
            }

        }
        private void Load_DSKeHoach()
        {
            string sql = "Select ID,NgayKeHoach,N'Kế hoạch ngày '+ ConVert(char(10),NgayKeHoach,103) AS TenKeHoach,AddBy,ThoiGianKetThuc,KhongChe,"
                          + "N'Từ '+Convert(char(8),ThoiGianBatDau,108)+N' ngày '+Convert(Char(10),ThoiGianBatDau,103) +N' đến '+ Convert(Char(8),ThoiGianKetThuc,108)+N' ngày '+ Convert(Char(10),ThoiGianKetThuc,103) AS ThoiGianApDung"
                          + " From tbl_KeHoachSanLuong Where VutrongID=" + MDSolutionApp.VuTrongID.ToString()+" And NgayKeHoach>='"+dtKHTu.Value.ToString("yyyy-MM-dd")+"' And NgayKeHoach<='"+dtKHDen.Value.ToString("yyyy-MM-dd")+"' Order By NgayKeHoach DESC";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDSKeHoachNgay.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdDSKeHoachNgay.DataSource = null;
            }
        }
        private void cmdThemKH_Click(object sender, EventArgs e)
        {
            MDSolution.MDForms.ThuHoach.frm_LapKeHoach frm = new MDSolution.MDForms.ThuHoach.frm_LapKeHoach();
            frm.ShowDialog();
            if (frm.OK > 0)
            {
                long KHID = frm._ID;
                try
                {
                    DBModule.ExecuteNonQuery("sp_KeHoachSanLuong_Create " + KHID.ToString() + "," + MDSolutionApp.VuTrongID.ToString(), null, null);
                    Load_DSKeHoach();
                }
                catch
                {
                    return;
                }
                try
                {
                    GridEXFilterCondition condi = new GridEXFilterCondition(this.gdDSKeHoachNgay.RootTable.Columns["ID"], ConditionOperator.Equal, KHID);
                    this.gdDSKeHoachNgay.Find(condi, 0, 1);
                }
                catch { }
            }
        }

        private void cmdFind_KeHoach_Click(object sender, EventArgs e)
        {
            Load_DSKeHoach();
        }
        private void Load_ChiTiet_KeHoach(long KeHoach_ID)
        {
            string sql = "sp_KeHoachSanLuong "+KeHoach_ID.ToString()+","+MDSolutionApp.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdChiTietKeHoachNgay.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdChiTietKeHoachNgay.DataSource = null;
            }
        }
        private void gdDSKeHoachNgay_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gdDSKeHoachNgay.CurrentRow.RowType == RowType.Record)
            {
                long ID = 0;
                DateTime NgayGioHienHanh = DateTime.MinValue;
                DateTime NgayDenHan = DateTime.MinValue;
                DateTime.TryParse(DBModule.ExecuteQueryForOneResult("Select Convert(Char(19),GetDate(),121)", null, null), out NgayGioHienHanh);
                DateTime.TryParse(this.gdDSKeHoachNgay.GetValue("ThoiGianKetThuc").ToString(), out NgayDenHan);
                long.TryParse(this.gdDSKeHoachNgay.GetValue("ID").ToString(),out ID);
                grDSKeHoach.Text = "Dữ liệu " + this.gdDSKeHoachNgay.GetValue("TenKeHoach").ToString();
                if (ID > 0)
                {
                    Load_ChiTiet_KeHoach(ID);
                   
                    if (NgayGioHienHanh > NgayDenHan)
                    {
                        this.gdChiTietKeHoachNgay.RootTable.Columns["SoChuyen"].EditType = EditType.NoEdit;
                        this.gdChiTietKeHoachNgay.RootTable.Columns["SanLuong"].EditType = EditType.NoEdit;
                    }
                    else
                    {
                        this.gdChiTietKeHoachNgay.RootTable.Columns["SoChuyen"].EditType = EditType.TextBox;
                        this.gdChiTietKeHoachNgay.RootTable.Columns["SanLuong"].EditType = EditType.TextBox;
                    }
                    if (AllowedModify == false)
                    {
                        this.gdChiTietKeHoachNgay.RootTable.Columns["SoChuyen"].EditType = EditType.NoEdit;
                        this.gdChiTietKeHoachNgay.RootTable.Columns["SanLuong"].EditType = EditType.NoEdit;
                    }
                   
                }
            }
        }

        private void gdChiTietKeHoachNgay_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e.Row.RowType == RowType.Record)
            {
                long NhomTruong = 0;
                try
                {
                    NhomTruong = long.Parse(e.Row.Cells["NhomTruong"].Value.ToString());
                }
                catch
                {

                }
                if (NhomTruong > 0)
                {
                    Janus.Windows.GridEX.GridEXFormatStyle NhomTruong_Format = new GridEXFormatStyle();
                    NhomTruong_Format.ForeColor = Color.Red;
                    e.Row.RowStyle = NhomTruong_Format;
                }
            }
        }

        private void gdChiTietKeHoachNgay_UpdatingRecord(object sender, CancelEventArgs e)
        {
            if (this.gdChiTietKeHoachNgay.CurrentRow.RowType == RowType.Record)
            {
                long ID_SanLuong = 0;
                long SanLuong = 0;
                long SoChuyen = 0;
                long.TryParse(this.gdChiTietKeHoachNgay.GetValue("SoChuyen").ToString(), out SoChuyen);
                long.TryParse(this.gdChiTietKeHoachNgay.GetValue("SanLuong").ToString(), out SanLuong);
                long.TryParse(this.gdChiTietKeHoachNgay.GetValue("ID").ToString(), out ID_SanLuong);
                if (ID_SanLuong > 0)
                {
                    clsKeHoachSanLuong_ChiTiet.UpdateKeHoachSanLuong(ID_SanLuong, SoChuyen, SanLuong, null, null);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void LoadDS_KeHoach_CoSan()
        {
            string sql = "Select ID,NgayKeHoach,ThoiGianBatDau,ThoiGianKetThuc,N'Kế hoạch ngày '+ ConVert(char(10),NgayKeHoach,103) AS TenKeHoach,KhongChe,"
                             + "N'Từ '+Convert(char(2),ThoiGianBatDau,108)+N'h ngày '+Convert(Char(10),ThoiGianBatDau,103) +N' đến '+ Convert(Char(2),ThoiGianKetThuc,108)+N' ngày '+ Convert(Char(10),ThoiGianKetThuc,103) AS ThoiGianApDung"
                             + " From tbl_KeHoachSanLuong Where VutrongID=" + MDSolutionApp.VuTrongID.ToString() + " And NgayKeHoach>='" + dtTuNgay_KHCoSan.Value.ToString("yyyy-MM-dd") + "' And NgayKeHoach<='" + dtDenNgay_KHCoSan.Value.ToString("yyyy-MM-dd") + "' Order By NgayKeHoach DESC";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdCacKeHoachCoSan.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdCacKeHoachCoSan.DataSource = null;
            }
        }

        private void tabTheoDoiSanLuong_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (e.Page.Index == 0)
            {
                LoadDS_KeHoach_CoSan();
                try
                {
                    DataSet ds = DBModule.ExecuteQuery("select YEAR(GETDATE()) as Nam, MONTH(GETDATE()) as Thang, DAY(GETDATE()) as Ngay", null, null);
                    int Nam = int.Parse(ds.Tables[0].Rows[0]["Nam"].ToString());
                    int Thang = int.Parse(ds.Tables[0].Rows[0]["Thang"].ToString());
                    int Ngay = int.Parse(ds.Tables[0].Rows[0]["Ngay"].ToString());
                    DateTime NgayHomNay = new DateTime(Nam, Thang, Ngay, 0, 0, 0);
                    GridEXFilterCondition condi = new GridEXFilterCondition(this.gdCacKeHoachCoSan.RootTable.Columns["NgayKeHoach"], ConditionOperator.Equal, NgayHomNay);
                    this.gdCacKeHoachCoSan.Find(condi, 0, 1);
                }
                catch
                {
                    this.gdCacKeHoachCoSan.MoveFirst();
                }
            }
            if (e.Page.Index == 1)
            {
                Load_DienTich_SanLuong_Toanvung();
            }
        }
        private void Load_DienTich_SanLuong_Toanvung()
        {
            string sql = "sp_KeHoachSanLuong_ThucTeThuHoach_ToanVung " + MDSolutionApp.VuTrongID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdTheoDoiSanLuongThoiGian.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdTheoDoiSanLuongThoiGian.DataSource = null;
            }
        }
        private void cmFindKH_CoSan_Click(object sender, EventArgs e)
        {
            LoadDS_KeHoach_CoSan();
        }

        private void gdCacKeHoachCoSan_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gdCacKeHoachCoSan.CurrentRow.RowType == RowType.Record)
            {
                long ID = 0;
                DateTime NgayBatDau = DateTime.MinValue;
                DateTime NgayKetThuc = DateTime.MinValue;
                DateTime.TryParse(this.gdCacKeHoachCoSan.GetValue("ThoiGianBatDau").ToString(), out NgayBatDau);
                DateTime.TryParse(this.gdCacKeHoachCoSan.GetValue("ThoiGianKetThuc").ToString(), out NgayKetThuc);
                long.TryParse(this.gdCacKeHoachCoSan.GetValue("ID").ToString(), out ID);
                grSoSanh.Text = "Dữ liệu thực tế " + this.gdCacKeHoachCoSan.GetValue("TenKeHoach").ToString();
                if (ID > 0)
                {
                    Load_DuLieu_ThuHoach(ID,NgayBatDau,NgayKetThuc);
                }
            }
        }

        private void Load_DuLieu_ThuHoach(long KeHoach_ID,DateTime NgayBD,DateTime NgayKT)
        {
            string sql = "sp_KeHoachSanLuong_ThucTeThuHoach " + KeHoach_ID.ToString() + "," + MDSolutionApp.VuTrongID.ToString()+",'"+NgayBD.ToString("yyyy-MM-dd HH:mm:ss")+"','"+NgayKT.ToString("yyyy-MM-dd HH:mm:ss")+"'";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdSoSanhSanLuong.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdSoSanhSanLuong.DataSource = null;
            }
        }

        private void gdSoSanhSanLuong_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e.Row.RowType == RowType.Record)
            {
                long NhomTruong = 0;
                try
                {
                    NhomTruong = long.Parse(e.Row.Cells["NhomTruong"].Value.ToString());
                }
                catch
                {

                }
                if (NhomTruong > 0)
                {
                    Janus.Windows.GridEX.GridEXFormatStyle NhomTruong_Format = new GridEXFormatStyle();
                    NhomTruong_Format.ForeColor = Color.Red;
                    e.Row.RowStyle = NhomTruong_Format;
                }
            }
        }

        private void cmd2ExcelTheoKH_Click(object sender, EventArgs e)
        {
            if (this.gdSoSanhSanLuong.RowCount > 0)
            {
                try
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                        {
                            Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                            exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                            exporter.GridEX = gdSoSanhSanLuong;
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
            else
            {
                MessageBox.Show("Không có dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdXuatExcel_Click(object sender, EventArgs e)
        {
            if (this.gdTheoDoiSanLuongThoiGian.RowCount > 0)
            {
                try
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                        {
                            Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                            exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                            exporter.GridEX = gdTheoDoiSanLuongThoiGian;
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
            else
            {
                MessageBox.Show("Không có dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void gdDSKeHoachNgay_CellEdited(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "KhongChe")
            {
                try
                {
                    long ID_KeHoach = 0;
                    long KhongChe = 0;
                    string TenKH = this.gdDSKeHoachNgay.GetValue("TenKeHoach").ToString();
                    long.TryParse(this.gdDSKeHoachNgay.GetValue("ID").ToString(), out ID_KeHoach);
                    long.TryParse(this.gdDSKeHoachNgay.GetValue("KhongChe").ToString(), out KhongChe);
                    if (ID_KeHoach > 0)
                    {
                        if (MessageBox.Show("Bạn chắc chắn đặt lại khống chế lượng của " + TenKH + "\nSự thiết lập này sẽ ảnh hưởng tới việc tiếp nhận mía", "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            string sql = "Update tbl_KeHoachSanLuong Set KhongChe=" + KhongChe.ToString() + " Where ID=" + ID_KeHoach.ToString();
                            DBModule.ExecuteNonQuery(sql, null, null);
                        }
                        else
                        {
                            this.gdDSKeHoachNgay.CurrentRow.Cells["KhongChe"].DataChanged = false;
                            return;
                        }

                    }
                    else
                    {
                        this.gdDSKeHoachNgay.CurrentRow.Cells["KhongChe"].DataChanged = false;
                        return;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Đã có lỗi khi lưu dữ liệu!\n"+ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
        }

        private void gdDSKeHoachNgay_EditingCell(object sender, EditingCellEventArgs e)
        {
            try
            {
                DateTime NgayGioHienHanh = DateTime.MinValue;
                DateTime NgayDenHan = DateTime.MinValue;
                DateTime.TryParse(DBModule.ExecuteQueryForOneResult("Select Convert(Char(19),GetDate(),121)", null, null), out NgayGioHienHanh);
                DateTime.TryParse(this.gdDSKeHoachNgay.GetValue("ThoiGianKetThuc").ToString(), out NgayDenHan);

                if (NgayGioHienHanh > NgayDenHan)
                {
                    e.Cancel = true;
                }
            }
            catch
            {
                e.Cancel = true;
            }
        }
     }
}
