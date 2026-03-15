
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using System.Globalization;
using System.Threading;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace MDSolution.MDForms
{
    public partial class frm_DienTich : Form
    {
        private DataSet gridDataSource;
        static frm_DienTich _frm_DienTich;
        private int lan = 1;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_DienTich OneInstanceFrm
        {
            get
            {
                if (null == _frm_DienTich || _frm_DienTich.IsDisposed)
                {
                    _frm_DienTich = new frm_DienTich();

                }
                return _frm_DienTich;
            }
        }
        public frm_DienTich()
        {
            InitializeComponent();
            check_rd();
        }

        public void check_rd()
        {
            if (rd1.Checked == true)
            { 
                rd2.Checked = false;
                rd3.Checked = false;
                lan = 1;
            }
            else if (rd2.Checked == true)
            {
                rd1.Checked = false;
                rd3.Checked = false;
                lan = 2;
            }
            if (rd3.Checked == true)
            {
                rd2.Checked = false;
                rd1.Checked = false;
                lan = 3;
            }
            
        }

        public void LoadData()
        {

            string sql = "sp_RP_HopDongDienTichTrongFrom   " + ComboVuTrong.SelectedValue.ToString();
            this.gridDataSource = DBModule.ExecuteQuery(sql, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gdChiTietDauTu.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");
            }
        }

        private void Load_Cb_CBNV()
        {
            string sql = "select ID,Ten from tbl_DanhMucCanBoNongVu where IsActive=1";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ComboCBNV.DataSource = ds.Tables[0];
                ComboCBNV.ValueMember = "ID";
                ComboCBNV.DisplayMember = "Ten";
            }
            else
            {
                ComboCBNV.DataSource = null;
            }
        }

        private void cmdAddHD_Click(object sender, EventArgs e)
        {
            LoadData();

        }

        private void btnXuatExcelHopDong_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "DienTichXuDong" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = gdChiTietDauTu;
                        exporter.Export(fs);
                        fs.Close();
                        MessageBox.Show("Xuất dữ liệu xong!", "Thông báo", MessageBoxButtons.OK);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void frm_DienTich_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            clsVuTrong.GetList("", out ds, null, null);
            ComboVuTrong.DataSource = ds.Tables[0];
            ComboVuTrong.DisplayMember = "Ten";
            ComboVuTrong.ValueMember = "ID";
            ComboVuTrong.SelectedValue = MDSolutionApp.VuTrongID;
            Load_Cb_CBNV();
        }

        private void gdChiTietDauTu_EditingCell(object sender, EditingCellEventArgs e)
        {
            //e.Cancel=true;
        }

        private void gdChiTietDauTu_CellEdited(object sender, ColumnActionEventArgs e)
        {

        }

        private void gdChiTietDauTu_TextChanged(object sender, EventArgs e)
        {

        }

        private void gdChiTietDauTu_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }

        private void btn_xuatchitiet_Click(object sender, EventArgs e)
        {

        }

        private void gdChiTietDauTu_UpdatingCell(object sender, UpdatingCellEventArgs e)
        {


            string KTNhapMia = @" Select * from tbl_nhapmia where vutrongID = " + MDSolutionApp.VuTrongID;
            int MaNhap = 0;
            try
            {
                MaNhap = Int32.Parse(DBModule.ExecuteQueryForOneResult(KTNhapMia, null, null));
            }
            catch { }

            if (MaNhap > 0)
            {
                if (MDSolutionApp.User.ID == 83062)
                {

                }
                else
                {
                    MessageBox.Show("Đã vào vụ bạn không được sửa dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            try
            {
                decimal DienTichThuc = decimal.Parse(gdChiTietDauTu.GetValue("TongDienTich").ToString());
                string sqlupdate = @"UPDATE [dbo].[tbl_ThuaRuong] SET [DienTich] =" + DienTichThuc * 10000 + " WHERE ID =" + long.Parse(gdChiTietDauTu.GetValue("ThuaRuongID").ToString());
                DBModule.ExecuteNonQuery(sqlupdate, null, null);
            }
            catch { }

            try
            {
                decimal NangXuatDK = decimal.Parse(gdChiTietDauTu.GetValue("SanLuongDuKien").ToString());
                string sqlupdate = @"UPDATE [dbo].[tbl_ThuaRuong] SET [SanLuongDuKien] =" + NangXuatDK + " WHERE ID =" + long.Parse(gdChiTietDauTu.GetValue("ThuaRuongID").ToString());
                DBModule.ExecuteNonQuery(sqlupdate, null, null);
            }
            catch { }

            try
            {
                decimal NangXuatDK1 = decimal.Parse(gdChiTietDauTu.GetValue("SanLuongDuKien1").ToString());
                string sqlupdate = @"UPDATE [dbo].[tbl_ThuaRuong] SET [SanLuongDuKien1] =" + NangXuatDK1 + " WHERE ID =" + long.Parse(gdChiTietDauTu.GetValue("ThuaRuongID").ToString());
                DBModule.ExecuteNonQuery(sqlupdate, null, null);

            }
            catch { }
            this.gdChiTietDauTu.Refetch();
        }

        private void gdChiTietDauTu_Enter(object sender, EventArgs e)
        {


        }

        private void gdChiTietDauTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            int col = gdChiTietDauTu.CurrentRow.RowIndex;
            if (e.KeyChar == (char)13)
            {
                gdChiTietDauTu.MoveToRowIndex(++col);
            }
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            if (this.gdChiTietDauTu.GetValue("HopDongDienTichID").ToString() != "")
            {

                MDDataSetForms.frmDienTichDangKy frm = new MDSolution.MDDataSetForms.frmDienTichDangKy(long.Parse(this.gdChiTietDauTu.GetValue("HopDongDienTichID").ToString()), long.Parse(this.gdChiTietDauTu.GetValue("ThonID").ToString()), true);
                frm.ShowDialog();
            }
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.gdChiTietDauTu.GetValue("ThuaRuongID").ToString() != "")
                {
                    //string a = this.grdThuaRuong.
                    MDDataSetForms.frmDienTich frm = new MDSolution.MDDataSetForms.frmDienTich(long.Parse(this.gdChiTietDauTu.GetValue("ThuaRuongID").ToString()), false);
                    frm.ShowDialog();
                }
                else { MessageBox.Show("Bạn phải chọn một thửa ruộng để sửa", "Thông báo"); }
            }
            catch { }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.gdChiTietDauTu.GetValue("ThuaRuongID").ToString() != "")
                {
                    string sqldacan = " SELECT ThuaRuongID FROM [dbo].[tbl_NhapMia] WHERE ThuaRuongID=" + this.gdChiTietDauTu.GetValue("ID").ToString();
                    string dacan = " ";
                    dacan = DBModule.ExecuteQueryForOneResult(sqldacan, null, null);
                    if (dacan == null || dacan == "")
                    {
                        string strSQL = "DELETE FROM [MDSONLA].[dbo].[tbl_ThuaRuong] WHERE ID= " + gdChiTietDauTu.GetValue("ThuaRuongID").ToString();
                        DBModule.ExecuteQuery(strSQL, null, null);
                        this.gdChiTietDauTu.Refetch();
                    }
                    else
                    {
                        MessageBox.Show("Thửa ruộng đã được cân mía", "Thông báo");
                    }

                }
                else { MessageBox.Show("Bạn phải chọn một thửa ruộng để sửa", "Thông báo"); }
            }
            catch { }
        }

        private void cmdAddFromExcel_Click(object sender, EventArgs e)
        {
            check_rd();
            string KTNhapMia = @" Select * from tbl_nhapmia where vutrongID = " + MDSolutionApp.VuTrongID;
            int MaNhap = 0;
            try
            {
                MaNhap = Int32.Parse(DBModule.ExecuteQueryForOneResult(KTNhapMia, null, null));
            }
            catch { }

            if (MaNhap > 0)
            {
                MessageBox.Show("Đã vào vụ bạn không được sửa dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (ComboCBNV.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn danh mục cán bộ nông vụ!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ComboCBNV.Focus();
                return;
            }


            try
            {
                string sqlDelete = "Delete From tbl_Temp_Import_Excel_NhapSanLuong";
                DBModule.ExecuteNonQuery(sqlDelete, null, null);
                if (openFileDialog_Excel.ShowDialog() == DialogResult.OK)////Mở file excel nguồn
                {
                    string TenFile = openFileDialog_Excel.FileName;
                    lblWaite.Visible = true;
                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    var missing = System.Reflection.Missing.Value;
                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Open(TenFile, false, true, missing, missing, missing, true, Excel.XlPlatform.xlWindows, '\t', false, false, 0, false, true, 0);
                    openFileDialog_Excel.Dispose();
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    Excel.Range xlRange = xlWorkSheet.UsedRange;
                    Array myValues = (Array)xlRange.Cells.Value2;
                    int vertical = myValues.GetLength(0);
                    int horizontal = myValues.GetLength(1);
                    for (int a = 2; a <= vertical; a++)//Với mỗi hàng
                    {
                        string TenCBNV = "";
                        string MaHopDong = "";
                        string HoTen = "";
                        string TenBai = "";
                        string TenThon = "";
                        string TenXa = "";
                        string Errors = "";
                        string ErrorsIn = "";
                        decimal SanLuongDuKien = 0;
                        decimal DienTich = 0;
                        int ThuaRuongID = 0;
                        string XuDong = "";
                        string TenXaMoi = "";
                        string TenBanMoi = "";
                        string MaThuaRuong = "";
                        Object element = new Object();
                        string sqlValue = "(";
                        for (int b = 1; b <= 12; b++)//Với mỗi cột
                        {
                            try
                            {
                                element = myValues.GetValue(a, b);//Lấy dữ liệu ô excel
                            }
                            catch
                            {
                                element = DBNull.Value;
                            }

                            if (b == 1)//Họ tên CBNV
                            {
                                try
                                {
                                    TenCBNV = element.ToString();
                                }
                                catch
                                {
                                    TenCBNV = "";
                                }
                                sqlValue = sqlValue + "N'" + TenCBNV + "',";
                            }
                            if (b == 2)//Tên xã
                            {
                                try
                                {
                                    TenXa = element.ToString();
                                }
                                catch
                                {
                                    TenXa = "";
                                }
                                sqlValue = sqlValue + "N'" + TenXa + "',";
                            }
                            if (b == 3)//Tên danh mục Thôn/bản
                            {
                                try
                                {
                                    TenThon = element.ToString();
                                }
                                catch
                                {
                                    TenThon = "";
                                }
                                sqlValue = sqlValue + "N'" + TenThon + "',";
                            }
                            if (b == 4)//Mã hợp đồng
                            {
                                try
                                {
                                    MaHopDong = element.ToString().Replace(" ", "");
                                }
                                catch
                                {
                                    MaHopDong = "";
                                }
                                sqlValue = sqlValue + "N'" + MaHopDong + "',";
                            }
                            if (b == 5)//Họ tên nông hộ
                            {
                                try
                                {
                                    HoTen = element.ToString();
                                }
                                catch
                                {
                                    HoTen = "";
                                }
                                sqlValue = sqlValue + "N'" + HoTen + "',";
                            }
                            if (b == 6)//Tên danh mục bãi tập kết
                            {
                                try
                                {
                                    TenBai = element.ToString();
                                }
                                catch
                                {
                                    TenBai = "";
                                }
                                sqlValue = sqlValue + "N'" + TenBai + "',";
                            }

                            if (b == 7)//Diện tích
                            {
                                try
                                {
                                    DienTich = decimal.Parse(element.ToString().Replace(" ", ""));
                                    DienTich = DienTich * 10000;
                                    if (DienTich <= 0)
                                    {
                                        DienTich = 0;
                                        ErrorsIn = ErrorsIn + "Sai dữ liệu diện tích. ";
                                    }
                                }
                                catch
                                {
                                    ErrorsIn = ErrorsIn + "Sai dữ liệu diện tích. ";
                                }
                                sqlValue = sqlValue + DBModule.RefineNumber(DienTich) + ",";
                            }

                            if (b == 8)//SLDK
                            {
                                try
                                {
                                    SanLuongDuKien = decimal.Parse(element.ToString().Replace(" ", ""));
                                    SanLuongDuKien = SanLuongDuKien * 1;
                                    if (SanLuongDuKien <= 0)
                                    {
                                        SanLuongDuKien = 0;
                                    }
                                }
                                catch
                                {
                                    ErrorsIn = ErrorsIn + "Sai dữ liệu sản lượng dự kiến. ";
                                }
                                sqlValue = sqlValue + DBModule.RefineNumber(SanLuongDuKien) + ",";
                            }
                            
                            if (b == 9)//Tên danh mục XA
                            {
                                try
                                {
                                    TenXaMoi = element.ToString();
                                }
                                catch
                                {
                                    TenXaMoi = "";
                                }
                                sqlValue = sqlValue + "N'" + TenXaMoi + "',";
                            }
                            if (b == 10)//Tên danh mục Thôn/bản
                            {
                                try
                                {
                                    TenBanMoi = element.ToString();
                                }
                                catch
                                {
                                    TenBanMoi = "";
                                }
                                sqlValue = sqlValue + "N'" + TenBanMoi + "',";
                            }
                            if (b == 11)//Tên danh mục Thôn/bản
                            {
                                try
                                {
                                    MaThuaRuong = element.ToString();
                                }
                                catch
                                {
                                    MaThuaRuong = "";
                                }
                                sqlValue = sqlValue + "N'" + MaThuaRuong + "',";
                            }
                            if (b == 12)//SLDK
                            {
                                try
                                {
                                    ThuaRuongID = int.Parse(element.ToString().Replace(" ", ""));
                                    if (ThuaRuongID <= 0)
                                    {
                                        ThuaRuongID = 0;
                                    }
                                }
                                catch
                                {
                                    ErrorsIn = ErrorsIn + "Sai số import. ";
                                }
                                sqlValue = sqlValue + DBModule.RefineNumber(ThuaRuongID);
                            }

                        }
                        ////Khi không có đủ thông tin thì bỏ qua
                        if ((string.IsNullOrEmpty(TenThon)) && (string.IsNullOrEmpty(TenBai)) && (string.IsNullOrEmpty(HoTen)) && (string.IsNullOrEmpty(MaHopDong)) && (string.IsNullOrEmpty(ThuaRuongID.ToString())) && (string.IsNullOrEmpty(TenXaMoi)) && (string.IsNullOrEmpty(TenBanMoi)) && (string.IsNullOrEmpty(MaThuaRuong)))
                        {
                            continue;
                        }
                        ////Khi có đầy đủ thông tin thì đối sánh dữ liệu, nếu sai ghi lỗi
                        //if ((!string.IsNullOrEmpty(TenThon)) && (!string.IsNullOrEmpty(TenBai)) && (!string.IsNullOrEmpty(MaHopDong))&&(!string.IsNullOrEmpty(HoTen)))
                        //{

                        string sqlCheck = @"SELECT        dbo.tbl_DanhMucCanBoNongVu.Ten AS TenCBNV, dbo.tbl_Xa.Ten AS TenXa, dbo.tbl_Thon.Ten AS TenThon, dbo.tbl_HopDong.MaHopDong, dbo.tbl_HopDong.HoTen, dbo.tbl_ThuaRuong.XuDong, 
                         dbo.tbl_ThuaRuong.DienTich / 10000 AS DienTich, dbo.tbl_ThuaRuong.SanLuongDuKien, dbo.tbl_ThuaRuong.ID AS ThuaRuongID,dbo.tbl_ThuaRuong.TenXa AS TenXaMoi,dbo.tbl_ThuaRuong.TenBan,dbo.tbl_ThuaRuong.MaThuaRuong
                         FROM            dbo.tbl_ThuaRuong INNER JOIN
                         dbo.tbl_HopDong ON dbo.tbl_ThuaRuong.HopDongID = dbo.tbl_HopDong.ID INNER JOIN
                         dbo.tbl_DanhMucCanBoNongVu INNER JOIN
                         dbo.tbl_Thon ON dbo.tbl_DanhMucCanBoNongVu.ID = dbo.tbl_Thon.CanBoNongVuID INNER JOIN
                         dbo.tbl_Xa ON dbo.tbl_Thon.XaID = dbo.tbl_Xa.ID ON dbo.tbl_HopDong.ThonID = dbo.tbl_Thon.ID Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString() + " AND  dbo.tbl_DanhMucCanBoNongVu.ID= " + ComboCBNV.SelectedValue.ToString() + " order by dbo.tbl_ThuaRuong.ID ASC";


                        ///string sqlCheck = "sp_Check_Import_DienTich " + _CBNVID + ",N'" + MaHopDong + "',N'" + TenThon + "',N'" + TenBai + "',N'" + LoaiDat + "',N'" + LoaiGiong + "',N'" + KieuTrong + "'";
                        ///


                        DataSet ret = DBModule.ExecuteQuery(sqlCheck, null, null);
                        if (ret.Tables[0].Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["TenCBNV"].ToString()))
                            {
                                TenCBNV = ret.Tables[0].Rows[0]["TenCBNV"].ToString();
                            }
                            else
                            {
                                TenCBNV = "-1";
                                Errors = Errors + "Sai dữ liệu Tên CBNV. ";
                            }
                            if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["TenXa"].ToString()))
                            {
                                TenXa = ret.Tables[0].Rows[0]["TenXa"].ToString();
                            }
                            else
                            {
                                TenXa = "-1";
                                Errors = Errors + "Sai dữ liệu Tên Xã. ";
                            }
                            if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["TenThon"].ToString()))
                            {
                                TenThon = ret.Tables[0].Rows[0]["TenThon"].ToString();
                            }
                            else
                            {
                                TenThon = "-1";
                                Errors = Errors + "Sai dữ liệu tên thôn. ";
                            }
                            if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["MaHopDong"].ToString()))
                            {
                                MaHopDong = ret.Tables[0].Rows[0]["MaHopDong"].ToString();
                            }
                            else
                            {
                                MaHopDong = "-1";
                                Errors = Errors + "Sai dữ liệu mã hợp đồng. ";
                            }
                            if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["HoTen"].ToString()))
                            {
                                HoTen = ret.Tables[0].Rows[0]["HoTen"].ToString();
                            }
                            else
                            {
                                HoTen = "-1";
                                Errors = Errors + "Sai dữ liệu họ tên. ";
                            }
                            if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["ThuaRuongID"].ToString()))
                            {
                                ThuaRuongID = int.Parse(ret.Tables[0].Rows[0]["ThuaRuongID"].ToString());
                            }
                            else
                            {
                                XuDong = "-1";
                                Errors = Errors + "Sai dữ liệu số để import. ";
                            }
                            ////-------------
                            //if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["TenXaMoi"].ToString()))
                            //{
                            //    TenXaMoi = ret.Tables[0].Rows[0]["TenXaMoi"].ToString();
                            //}
                            //else
                            //{
                            //    TenXaMoi = "-1";
                            //    Errors = Errors + "Sai dữ liệu Tên Xã mới. ";
                            //}
                            //if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["TenBan"].ToString()))
                            //{
                            //    TenBanMoi = ret.Tables[0].Rows[0]["TenBan"].ToString();
                            //}
                            //else
                            //{
                            //    TenBanMoi = "-1";
                            //    Errors = Errors + "Sai dữ liệu Tên Bản mới. ";
                            //}
                            //if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["MaThuaRuong"].ToString()))
                            //{
                            //    MaThuaRuong = ret.Tables[0].Rows[0]["MaThuaRuong"].ToString();
                            //}
                            //else
                            //{
                            //    MaThuaRuong = "-1";
                            //    Errors = Errors + "Sai dữ liệu Tên Bản mới. ";
                            //}

                            Errors = Errors + Errors;
                            //+ TenCBNV + TenXa + TenThon + MaHopDong + HoTen + XuDong + ThuaRuongID;
                        }
                        else
                        {
                            Errors = "Chưa đủ dữ liệu để đối sánh. ";
                        }
                        //}
                        //else
                        //{
                        //    Errors = "Chưa đủ dữ liệu để đối sánh. ";
                        //}
                        /////Ghi dữ liệu vào bảng tạm
                        string sqlInsert = @"INSERT INTO [dbo].[tbl_Temp_Import_Excel_NhapSanLuong]([TenCBNV],[TenXa],[TenThon],[MaHopDong],[HoTen],[TenBai],[DienTich],[SanLuongDuKien],[TenXaMoi],[TenBanMoi],[MaThuaRuong],[ThuaRuongID],[Errors],[DateImport])VALUES "
                                      + sqlValue + ",N'" + Errors + ErrorsIn + "',GetDate())";
                        //"," + TenCBNV + "," + TenXa + "," + TenThon + "," + MaHopDong + "," + HoTen + "," + XuDong + "," + ThuaRuongID +  

                        DBModule.ExecuteNonQuery(sqlInsert, null, null);
                    }

                    xlWorkBook.Close(true, missing, missing);
                    xlApp.Quit();
                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                    lblWaite.Visible = false;
                    ////Tải dữ liệu từ bảng tạm lên form
                    MDForms.DienTich.frm_Temp_Import_SLDK frm = new MDForms.DienTich.frm_Temp_Import_SLDK(ComboCBNV.Text, long.Parse(ComboCBNV.SelectedValue.ToString()), TenFile,lan);
                    frm.ShowDialog();
                    if (frm.OK > 0)
                    {
                        LoadData();
                    }

                }
            }
            catch (Exception ex)
            {
                lblWaite.Visible = false;
                MessageBox.Show("Đã có lỗi ngoại lệ xảy ra!\nBạn cần xem lại dữ liệu file Excel\n" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }



        //private void uiButton1_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        saveFileDialog1.FileName = "DienTichXuDong" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
        //        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        //        {
        //            using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create))
        //            {
        //                Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
        //                exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
        //                exporter.GridEX = gridEX1;
        //                exporter.Export(fs);
        //                fs.Close();
        //                MessageBox.Show("Xuất dữ liệu xong!", "Thông báo", MessageBoxButtons.OK);
        //            }
        //        }

        //    }
        //    catch
        //    {
        //        MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK);
        //    }

        //}
    }
}
