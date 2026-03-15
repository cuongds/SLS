using Janus.Windows.GridEX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace MDSolution.MDForms.UngTien
{
    public partial class frmQuanLyUngTien : Form
    {
        private clsHopDong oHD = new clsHopDong();
        private DataSet gridDataSourceMoi;
        private DataSet gridDataSourceDuyet;
        private DataSet gridDataSourceChuyen;
        public frmQuanLyUngTien()
        {
            InitializeComponent();
            dt_XNNL_Duyet_Tu.Value = DateTime.Now.AddYears(-1);
            dt_XNNL_Duyet_Den.Value = DateTime.Now;
            dt_TaiChinh_Duyet_Tu.Value = DateTime.Now.AddYears(-1);
            dt_TaiChinh_Duyet_Den.Value = DateTime.Now;
            dt_XNNL_DuyetTu.Value = DateTime.Now.AddYears(-1);
            dt_DenNgay_DuyetDen.Value = DateTime.Now;
            lbl_TaiChinh_XN.Text = "";
            lbl_XNNL_Duyet.Text = "";
            lbl_XNNL_XN.Text = "";
            lbl_TaiChinh_Duyet.Text = "";
            Load_gdDSUngTienMoi();
            Load_gdDSUngTienDuyet();
            Load_gdDSUngTienChuyen();
        }
        public frmQuanLyUngTien(string ID)
        {
            InitializeComponent();
        }
        private void frmQuanLyUngTien_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }
        private void cmd_Add_News_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlDelete = "Delete From tbl_Temp_Import_Excel_KeHoachUngTienMat Where  VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
                DBModule.ExecuteNonQuery(sqlDelete, null, null);
                if (openFileDialog_Excel.ShowDialog() == DialogResult.OK)////Mở file excel nguồn
                {
                    string TenFile = openFileDialog_Excel.FileName;
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
                        string MaHopDong = "";
                        string HoTen = "";
                        string TenDot = "";
                        string GhiChu = "";
                        string Errors = "";
                        string ErrorsIn = "";
                        Decimal ST = 0;
                        string HopDongID = "-1";
                        Object element = new Object();
                        string sqlValue = "Values(" + MDSolutionApp.VuTrongID.ToString() + ",";
                        for (int b = 1; b <= 6; b++)//Với mỗi cột
                        {
                            try
                            {
                                element = myValues.GetValue(a, b);//Lấy dữ liệu ô excel
                            }
                            catch
                            {
                                element = DBNull.Value;
                            }
                            if (b == 1)//Tên đợt ứng
                            {
                                try
                                {
                                    TenDot = element.ToString();
                                }
                                catch
                                {
                                    TenDot = "";
                                }
                                sqlValue = sqlValue + "N'" + TenDot + "',";
                            }
                            if (b == 2)//Mã hợp đồng
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
                            if (b == 3)//Họ tên nông hộ
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
                            if (b == 4)//Số tiền
                            {
                                try
                                {
                                    ST = decimal.Parse(element.ToString().Replace(" ", ""));
                                    if (ST <= 0)
                                    {
                                        ST = 0;
                                        ErrorsIn = ErrorsIn + "Sai dữ liệu số tiền. ";
                                    }
                                }
                                catch
                                {
                                    ErrorsIn = ErrorsIn + "Sai dữ liệu số tiền. ";
                                }
                                sqlValue = sqlValue + DBModule.RefineNumber(ST) + ",";
                            }
                            if (b == 5)//Ngày ứng
                            {
                                var dateTime = DateTime.FromOADate(0).ToString();
                                try
                                {
                                    double date = double.Parse(element.ToString());
                                    dateTime = DateTime.FromOADate(date).ToString("yyyy-MM-dd");
                                }
                                catch
                                {
                                    dateTime = "1900-01-01";
                                    ErrorsIn += "Sai ngày ứng. ";
                                }
                                if (dateTime != "1900-01-01")
                                {
                                    sqlValue = sqlValue + "'" + dateTime + "',";
                                }
                                else
                                {
                                    ErrorsIn = ErrorsIn + "Sai ngày ứng.";
                                }
                            }
                            if (b == 6)// Ghi chú
                            {
                                try
                                {
                                    GhiChu = element.ToString();
                                }
                                catch
                                {
                                    GhiChu = " ";
                                }
                                sqlValue = sqlValue + "N'" + GhiChu + "'";
                            }

                        }
                        if ((string.IsNullOrEmpty(HoTen)) && (string.IsNullOrEmpty(MaHopDong)))
                        {
                            continue;
                        }
                        //string sqlCheck = " sp_Check_Import_DienTich " + _CBNVID + ",N'" + MaHopDong + "',N'" + TenThon + "',N'" + TenBai + "',N'" + LoaiDat + "',N'" + LoaiGiong + "',N'" + KieuTrong + "'";
                        string sqlCheck = " select * from tbl_HopDong inner join  tbl_HopDongVuTrong On tbl_HopDong.ID = tbl_HopDongvuTrong.HopDongID where mahopdong like " + MaHopDong + " AND VutrongID =" + MDSolutionApp.VuTrongID.ToString();
                        DataSet ret = null;
                        try
                        {
                            ret = DBModule.ExecuteQuery(sqlCheck, null, null);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("lỗi không có mã hợp đông : " + MaHopDong);
                        }
                        if (ret.Tables[0].Rows.Count > 0)
                        {

                            if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["HopDongID"].ToString()))
                            {
                                HopDongID = ret.Tables[0].Rows[0]["HopDongID"].ToString();

                            }
                            else
                            {
                                HopDongID = "-1";
                                Errors = Errors + "Sai dữ liệu Mã/Tên nông hộ. ";
                            }
                            if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["HoTen"].ToString()))
                            {
                                if (ret.Tables[0].Rows[0]["HoTen"].ToString().Replace(" ", "") != HoTen.Replace(" ", ""))
                                {
                                    Errors = Errors + "Sai dữ liệu Mã/Tên nông hộ. ";
                                }
                            }
                            else
                            {
                                Errors = Errors + "Sai dữ liệu Mã/Tên nông hộ. ";
                            }
                        }
                        else
                        {
                            Errors = "Chưa đủ dữ liệu để đối sánh. ";
                        }
                        /////Ghi dữ liệu vào bảng tạm

                        string sqlInsert = @"INSERT INTO [dbo].[tbl_Temp_Import_Excel_KeHoachUngTienMat] ([VuTrongID],[TenDot],[MaHopDong],[HoTen],[Sotien],[NgayUng],[GhiChu],[CreatedByUserID],[DateAdd],[Status],[HopDongID],Errors) "
                            + sqlValue + "," + MDSolutionApp.User.ID.ToString() + ",GetDate(),1," + HopDongID + ",N'" + Errors + ErrorsIn + "')";
                        try
                        {
                            DBModule.ExecuteNonQuery(sqlInsert, null, null);
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                        }
                    }

                    xlWorkBook.Close(true, missing, missing);
                    xlApp.Quit();
                    MDSolution.MDForms.UngTien.frm_Temp_Import_UngTien frm = new MDForms.UngTien.frm_Temp_Import_UngTien(TenFile);
                    frm.ShowDialog();
                    if (frm.OK > 0)
                    {
                        Load_gdDSUngTienMoi();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi ngoại lệ xảy ra!\nBạn cần xem lại dữ liệu file Excel\n" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btn_DSKHMoi_Click(object sender, EventArgs e)
        {
            Load_gdDSUngTienMoi(); // Call the method to load data
        }

        private void btn_Load_ChoXN_Click(object sender, EventArgs e)
        {
            Load_gdDSUngTienDuyet();
        }
        private void Load_gdDSUngTienMoi()
        {
            string sql = @"SELECT  *  FROM V_UngTienMat              
                  Where V_UngTienMat.VuTrongID= " + MDSolutionApp.VuTrongID.ToString() + " AND V_UngTienMat.Status= 1  AND V_UngTienMat.NgayUng Between " + DBModule.RefineDatetime(dt_XNNL_Duyet_Tu.Value, true) + " AND " + DBModule.RefineDatetime(dt_XNNL_Duyet_Den.Value, true);
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDS_XNNL_Duyet.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdDS_XNNL_Duyet.DataSource = null;
            }
        }
        private void Load_gdDSUngTienDuyet()
        {
            string sql = @"SELECT *  FROM V_UngTienMat               
                         Where V_UngTienMat.VuTrongID= " + MDSolutionApp.VuTrongID.ToString() + " AND (V_UngTienMat.Status= 2)  AND V_UngTienMat.NgayUng Between " + DBModule.RefineDatetime(dt_XNNL_DuyetTu.Value, true) + " AND " + DBModule.RefineDatetime(dt_DenNgay_DuyetDen.Value, true);
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDS_XNNL_XN.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdDS_XNNL_XN.DataSource = null;
            }
        }

        private void Load_gdDSUngTienChuyen()
        {
            string sql = @"SELECT *  FROM V_UngTienMat
                         Where V_UngTienMat.VuTrongID= " + MDSolutionApp.VuTrongID.ToString() + " AND V_UngTienMat.Status= 3  AND V_UngTienMat.NgayUng Between " + DBModule.RefineDatetime(dt_TaiChinh_Duyet_Tu.Value, true) + " AND " + DBModule.RefineDatetime(dt_TaiChinh_Duyet_Den.Value, true);
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDS_TC_Duyet.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdDS_TC_Duyet.DataSource = null;
            }
        }

        private void btnLoadDS_ChoChuyen_Click(object sender, EventArgs e)
        {
            Load_gdDSUngTienChuyen();
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xác nhận các phiếu này.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sids = "";
                foreach (Janus.Windows.GridEX.GridEXRow r in gdDS_XNNL_XN.GetCheckedRows())
                {
                    if (!string.IsNullOrEmpty(sids)) sids += ",";
                    sids += r.Cells["ID"].Value;
                }
                string sql = @"UPDATE [tbl_KeHoachUngTienMat]
                               SET 
                                 [Status] = 3,
                                 [CheckedByUserID] = {1},
                                 [DateChecked] = GETDATE()                                
                                 WHERE ID in ({0});";
                DBModule.ExecuteNonQuery(string.Format(sql, sids, MDSolutionApp.User.ID), null, null);
                MessageBox.Show("Đã xác nhận thành công các phiếu:" + sids, "Thông báo");
                Load_gdDSUngTienDuyet();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdExit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gdDSUngTienMoi_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            long IDUngTien = -1;
            long NguoiNhapID = 0;
            try
            {
                IDUngTien = long.Parse(this.gdDS_XNNL_Duyet.GetValue("ID").ToString());
                NguoiNhapID = long.Parse(this.gdDS_XNNL_Duyet.GetValue("NguoiNhapID").ToString());
            }
            catch
            {
                return;
            }
            if (e.Column.Key == "Modify")
            {
                try
                {
                    if (this.gdDS_XNNL_Duyet.GetValue("ID").ToString() != "" && (MDSolutionApp.User.ID == 1 || MDSolutionApp.User.ID == NguoiNhapID))
                    {
                        MDSolution.MDForms.UngTien.frm_NhapUngTien frm = new MDForms.UngTien.frm_NhapUngTien(IDUngTien, 1);
                        frm.ShowDialog();
                        try
                        {
                            GridEXFilterCondition condi = new GridEXFilterCondition(gdDS_XNNL_Duyet.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._HopDongID);
                            gdDS_XNNL_Duyet.Find(condi, 0, 1);
                        }
                        catch { }
                    }
                    else
                    {
                        MessageBox.Show("Bạn phải chọn một mục ứng để sửa hay bạn không có quyền", "Thông báo");
                    }
                }
                catch
                {
                    MessageBox.Show("Bạn phải chọn một mục ứng để sửa", "Thông báo");
                }
            }
            if (e.Column.Key == "Delete")
            {
                if (this.gdDS_XNNL_Duyet.GetValue("ID").ToString() != "" && (MDSolutionApp.User.ID == 1 || MDSolutionApp.User.ID == NguoiNhapID))
                {
                    try
                    {

                        string message;
                        message = String.Format("Bạn muốn xóa bản ghi này?");
                        if (MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string strSQL = "Delete from tbl_KeHoachUngTienMat Where ID =" + IDUngTien;
                            DBModule.ExecuteNoneBackup(strSQL, null, null);
                            Load_gdDSUngTienMoi();
                            //  LoadGrdTienUng(); update tbl_log
                        }
                        else
                        {
                            //LoadGrdTienUng();
                            //e.Cancel = true;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Bạn phải chọn một bản ghi để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền", "Thông báo");
                }

            }

        }

        private void cmd_ChuyenKT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn chuyển phiếu này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sids = "";
                foreach (Janus.Windows.GridEX.GridEXRow r in gdDS_XNNL_Duyet.GetCheckedRows())
                {
                    if (!string.IsNullOrEmpty(sids)) sids += ",";
                    sids += r.Cells["ID"].Value;
                }
                string sql = @"UPDATE [tbl_KeHoachUngTienMat]
                               SET 
                                 [Status] = 2,
                                 [CheckedByUserID] = {1},
                                 [DateChecked] = GETDATE()                                
                                 WHERE ID in ({0});";
                DBModule.ExecuteNonQuery(string.Format(sql, sids, MDSolutionApp.User.ID), null, null);
                MessageBox.Show("Phiếu đã được chuyển thành công", "Thông báo");
                Load_gdDSUngTienMoi();
            }
        }

        private void btn_HuyXN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn chuyển các phiếu này sang chở.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sids = "";
                foreach (Janus.Windows.GridEX.GridEXRow r in gdDS_TC_Duyet.GetCheckedRows())
                {
                    if (!string.IsNullOrEmpty(sids)) sids += ",";
                    sids += r.Cells["ID"].Value;
                }
                string sql = @"UPDATE [tbl_KeHoachUngTienMat]
                               SET 
                                 [Status] = 2                                 
                                 WHERE ID in ({0});";
                DBModule.ExecuteNonQuery(string.Format(sql, sids, MDSolutionApp.User.ID), null, null);
                MessageBox.Show("Đã xác chuyển thành công các phiếu:" + sids, "Thông báo");
                Load_gdDSUngTienChuyen();
            }
        }

        private void cmdXuatExcel_KHMoi_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "UngTien_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = gdDS_XNNL_Duyet;
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

        private void btn_Duyet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn duyệt các phiếu này.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sids = "";
                foreach (Janus.Windows.GridEX.GridEXRow r in gdDS_XNNL_XN.GetCheckedRows())
                {
                    if (!string.IsNullOrEmpty(sids)) sids += ",";
                    sids += r.Cells["ID"].Value;
                }
                string sql = @"UPDATE [tbl_KeHoachUngTienMat]
                               SET 
                                 [Status] = 3,
                                 [NguoiDuyet] = {1},
                                 [NgayDuyet] = GETDATE()                                
                                 WHERE ID in ({0});";
                DBModule.ExecuteNonQuery(string.Format(sql, sids, MDSolutionApp.User.ID), null, null);
                MessageBox.Show("Đã xác duyệt thành công các phiếu:" + sids, "Thông báo");
                Load_gdDSUngTienDuyet();
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn hủy các phiếu này.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sids = "";
                foreach (Janus.Windows.GridEX.GridEXRow r in gdDS_XNNL_XN.GetCheckedRows())
                {
                    if (!string.IsNullOrEmpty(sids)) sids += ",";
                    sids += r.Cells["ID"].Value;
                }
                string sql = @"UPDATE [tbl_KeHoachUngTienMat]
                               SET 
                                 [Status] = 1
                                 WHERE ID in ({0});";
                DBModule.ExecuteNonQuery(string.Format(sql, sids, MDSolutionApp.User.ID), null, null);
                MessageBox.Show("Đã chuyển lại các phiếu:" + sids, "Thông báo");
                Load_gdDSUngTienDuyet();
            }
        }

        private void btn_ChuyenTT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn chuyển các phiếu này.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sids = "";
                foreach (Janus.Windows.GridEX.GridEXRow r in gdDS_TC_Duyet.GetCheckedRows())
                {
                    if (!string.IsNullOrEmpty(sids)) sids += ",";
                    sids += r.Cells["ID"].Value;
                }
                string sql = @"INSERT INTO [dbo].[tbl_DauTu] ([HopDongID],[DanhMucDauTuID] ,[SoTien],[NgayDauTu],[GhiChu],[VuTrongID],[CreatedBy],[DateAdd])    
                             (SELECT [HopDongID],286,[Sotien],[NgayUng]  ,[GhiChu],[VuTrongID],{1},[DateApproved]   
                             FROM [dbo].[tbl_KeHoachUngTienMat] where id in ({0}))";
                DBModule.ExecuteNonQuery(string.Format(sql, sids, MDSolutionApp.User.ID), null, null);
                MessageBox.Show("Đã xác chuyển thành công các phiếu:" + sids, "Thông báo");
                Load_gdDSUngTienChuyen();
            }
        }

        private void btn_XNNL_Duyet_Duyet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn chuyển phiếu này? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sids = "";
                foreach (Janus.Windows.GridEX.GridEXRow r in gdDS_XNNL_Duyet.GetCheckedRows())
                {
                    if (!string.IsNullOrEmpty(sids)) sids += ",";
                    sids += r.Cells["ID"].Value;
                }
                string sql = @"UPDATE [tbl_KeHoachUngTienMat]
                               SET 
                                 [Status] = 2,
                                 [ApprovedByUserID] = {1},
                                 [DateApproved] = GETDATE()                                
                                 WHERE ID in ({0});";
                DBModule.ExecuteNonQuery(string.Format(sql, sids, MDSolutionApp.User.ID), null, null);
                MessageBox.Show("Phiếu đã được chuyển thành công", "Thông báo");
                Load_gdDSUngTienMoi();
            }
        }

        private void Tab_TamUngTien_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (e.Page.Index == 0)
            {
                Load_gdDSUngTienMoi();
                lbl_XNNL_Duyet.Text = "";
                string sqltab1 = @"select MIN(NgayUng) as NgayUng from  tbl_KeHoachUngTienMat where Status=1 and NgayUng<GETDATE();";
                try
                {
                    DataSet tb1 = DBModule.ExecuteQuery(sqltab1, null, null);
                    if (tb1 != null && tb1.Tables[0].Rows.Count >= 1)
                    {
                        DateTime datetime = (DateTime)tb1.Tables[0].Rows[0]["NgayUng"];
                        lbl_XNNL_Duyet.Text = " Kiểm tra từ ngày " + datetime.ToString("dd/MM/yyyy") + "\ncó phiếu chưa làm";
                    }
                }
                catch { }
            }
            else if (e.Page.Index == 1)
            {
                Load_gdDSUngTienDuyet();
                lbl_XNNL_XN.Text = "";
                string sqltab1 = @"select MIN(NgayUng) as NgayUng from  tbl_KeHoachUngTienMat where Status=2 and NgayUng<GETDATE();";
                try
                {
                    DataSet tb1 = DBModule.ExecuteQuery(sqltab1, null, null);
                    if (tb1 != null && tb1.Tables[0].Rows.Count >= 1)
                    {
                        DateTime datetime = (DateTime)tb1.Tables[0].Rows[0]["NgayUng"];
                        lbl_XNNL_XN.Text = " Kiểm tra từ ngày " + datetime.ToString("dd/MM/yyyy") + "\ncó phiếu chưa làm";
                    }
                }
                catch { }

            }
            else if (e.Page.Index == 2)
            {
                Load_gdDSUngTienChuyen();
                lbl_TaiChinh_Duyet.Text = "";
                string sqltab1 = @"select MIN(NgayUng) as NgayUng from  tbl_KeHoachUngTienMat where Status=3 and NgayUng < GETDATE();";
                try
                {
                    DataSet tb1 = DBModule.ExecuteQuery(sqltab1, null, null);
                    if (tb1 != null && tb1.Tables[0].Rows.Count >= 1)
                    {
                        DateTime datetime = (DateTime)tb1.Tables[0].Rows[0]["NgayUng"];
                        lbl_TaiChinh_Duyet.Text = " Kiểm tra từ ngày " + datetime.ToString("dd/MM/yyyy") + "\ncó phiếu chưa làm";
                    }
                }
                catch { }

            }
            else if (e.Page.Index == 3)
            {
                lbl_TaiChinh_XN.Text = "";
                Load_gdDS_TC_XN();
                string sqltab1 = @"select MIN(NgayUng) as NgayUng from  tbl_KeHoachUngTienMat where Status=4 and NgayUng<GETDATE();";
                try
                {
                    DataSet tb1 = DBModule.ExecuteQuery(sqltab1, null, null);
                    if (tb1 != null && tb1.Tables[0].Rows.Count >= 1)
                    {
                        DateTime datetime = (DateTime)tb1.Tables[0].Rows[0]["NgayUng"];
                        lbl_TaiChinh_XN.Text = " Kiểm tra từ ngày " + datetime.ToString("dd/MM/yyyy") + "\ncó phiếu chưa làm";
                    }
                }
                catch { }

            }
        }
        private void Load_gdDS_TC_XN()
        {
            string sql = @"SELECT *  FROM V_UngTienMat
                         Where V_UngTienMat.VuTrongID= " + MDSolutionApp.VuTrongID.ToString() + " AND (V_UngTienMat.Status= 4) AND V_UngTienMat.NgayUng Between " + DBModule.RefineDatetime(dt_TaiChinh_XN_Tu.Value, true) + " AND " + DBModule.RefineDatetime(dt_TaiChinh_XN_Den.Value, true);
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDS_TC_XN.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdDS_TC_XN.DataSource = null;
            }
        }

        private void btn_TaiChinh_XN_Tim_Click(object sender, EventArgs e)
        {
            Load_gdDS_TC_XN();

        }

        private void btn_TaiChinh_XN_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn chuyển các phiếu này sang chở.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sids = "";
                foreach (Janus.Windows.GridEX.GridEXRow r in gdDS_TC_XN.GetCheckedRows())
                {
                    if (!string.IsNullOrEmpty(sids)) sids += ",";
                    sids += r.Cells["ID"].Value;
                }
                string sql = @"UPDATE [tbl_KeHoachUngTienMat]
                               SET 
                                 [Status] = 3,
                                 [ApprovedByUserID] = {1},
                                 [DateApproved] = GETDATE()                                
                                 WHERE ID in ({0});";
                DBModule.ExecuteNonQuery(string.Format(sql, sids, MDSolutionApp.User.ID), null, null);
                MessageBox.Show("Đã xác chuyển thành công các phiếu:" + sids, "Thông báo");
                Load_gdDS_TC_XN();
            }
        }

        private void btn_TaiChinh_Duyet_Duyet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn duyệt các phiếu này.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sids = "";
                foreach (Janus.Windows.GridEX.GridEXRow r in gdDS_TC_Duyet.GetCheckedRows())
                {
                    if (!string.IsNullOrEmpty(sids)) sids += ",";
                    sids += r.Cells["ID"].Value;
                }
                string sql = @"UPDATE [tbl_KeHoachUngTienMat]
                               SET 
                                 [Status] = 4,
                                 [Nguoi_TC_Duyet] = {1},
                                 [Ngay_TC_Duyet] = GETDATE()                                
                                 WHERE ID in ({0});";
                DBModule.ExecuteNonQuery(string.Format(sql, sids, MDSolutionApp.User.ID), null, null);
                MessageBox.Show("Đã xác duyệt thành công các phiếu:" + sids, "Thông báo");
                Load_gdDSUngTienChuyen();
            }
        }

        private void btn_TaiChinh_XN_Duyet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn duyệt các phiếu này.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sids = "";
                foreach (Janus.Windows.GridEX.GridEXRow r in gdDS_TC_XN.GetCheckedRows())
                {
                    if (!string.IsNullOrEmpty(sids)) sids += ",";
                    sids += r.Cells["ID"].Value;
                }
                string sql = @"UPDATE [tbl_KeHoachUngTienMat]
                               SET 
                                 [Status] = 5,
                                 [Nguoi_TC_XN] = {1},
                                 [Ngay_TC_XN] = GETDATE()                                
                                 WHERE ID in ({0});";

                string sql_insert_datu = @"INSERT INTO [dbo].[tbl_DauTu]
		        ([HopDongID],[DanhMucDauTuID],[SoTien],[NgayDauTu],[GhiChu],[DotDauTu],[VuTrongID],[CreatedBy],[DateAdd],[DonViCungUngVatTuID],[SoChungTu],[LoaiHinhDauTuID])
                SELECT [HopDongID],286,[Sotien],[NgayUng],[GhiChu],'',[VuTrongID],[CreatedByUserID],[DateAdd],1,[TenDot],9      
		        FROM [dbo].[tbl_KeHoachUngTienMat] where ID in ({0})";
                try
                {
                    DBModule.ExecuteNonQuery(string.Format(sql, sids, MDSolutionApp.User.ID), null, null);
                    DBModule.ExecuteNonQuery(string.Format(sql_insert_datu, sids), null, null);
                    MessageBox.Show("Đã xác duyệt thành công các phiếu:" + sids, "Thông báo");
                    Load_gdDS_TC_XN();
                }
                catch
                {
                    MessageBox.Show("Thực hiện không thành công:" + sids, "Thông báo");
                }
            }
        }

        private void btn_TaiChinh_XN_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "UngTien_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = gdDS_TC_XN;
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

        private void cmd_XNNL_XN_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "UngTien_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = gdDS_XNNL_XN;
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

        private void cmd_TaiChinh_Duyet_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "UngTien_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;// fiSelectedRows;//
                        exporter.GridEX = gdDS_TC_Duyet;
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

        private void btn_TaiChinh_XN_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}