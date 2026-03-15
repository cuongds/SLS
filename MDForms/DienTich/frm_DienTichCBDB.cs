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


namespace MDSolution.MDForms.DienTich
{
    public partial class frm_DienTichCBDB : Form
    {
        static frm_DienTichCBDB _frm_DienTichCBDB;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_DienTichCBDB OneInstanceFrm
        {
            get
            {
                if (null == _frm_DienTichCBDB || _frm_DienTichCBDB.IsDisposed)
                {
                    _frm_DienTichCBDB = new frm_DienTichCBDB();
                }

                return _frm_DienTichCBDB;
            }
        }
        private NodeCanBoNongVu nCBDB = new NodeCanBoNongVu();
        public long _CBNVID = 0;
        private string TenCBNV = "";
        private long _SL = 0;
        public frm_DienTichCBDB()
        {
            InitializeComponent();
            CommonClass.LoadTreeCBNV(tvCBDB);
        }

        private void treeDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nCBDB = (NodeCanBoNongVu)tvCBDB.SelectedNode.Tag;
            }
        }



        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void tvCBDB_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (tvCBDB.SelectedNode != null)
            {
                nCBDB = (NodeCanBoNongVu)tvCBDB.SelectedNode.Tag;
            }
        }

        private void tvCBDB_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (tvCBDB.SelectedNode != null)
            {
                nCBDB = (NodeCanBoNongVu)tvCBDB.SelectedNode.Tag;
                if (nCBDB.CBNVType == CBNVType.Root)
                {
                    grDSDT.Text = "Danh sách các thửa ruộng tất cả CBĐB";
                    _CBNVID = 0;
                }
                else //if (nCBDB.CBNVType == CBNVType.CBNV)
                {
                    grDSDT.Text = "Danh sách các thửa ruộng của CBĐB " + tvCBDB.SelectedNode.Text;
                    _CBNVID = long.Parse(nCBDB.CBNVID.ToString());
                    TenCBNV = tvCBDB.SelectedNode.Text;
                }
                this.Load_DL_DienTich(_CBNVID);
            }
        }
        private void Load_DL_DienTich(long CBDBID)
        {
            string sql = "sp_CBDB_DienTich " + MDSolutionApp.VuTrongID.ToString() + "," + CBDBID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdChiTietDienTichCBDB.SetDataBinding(ds.Tables[0], "RootTable");
            }
            else
            {
                this.gdChiTietDienTichCBDB.DataSource = null;
            }
        }


        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAddFromExcel_Click(object sender, EventArgs e)
        {
            if (_CBNVID > 0)
            {
                try
                {
                    string sqlDelete = "Delete From tbl_Temp_Import_Excel_NhapDienTich Where CanBoNongVuID=" + _CBNVID.ToString() + " And VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
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
                            string HopDongID = "-1";
                            string ThonID = "-1";
                            string BaiTapKetID = "-1";
                            string LoaiDatID = "-1";
                            string LoaiGiongID = "-1";
                            string KieuTrongID = "-1";
                            string MaHopDong = "";
                            string TenThon = "";
                            string TenBai = "";
                            string HoTen = "";
                            string LoaiDat = "";
                            string LoaiGiong = "";
                            string KieuTrong = "";
                            string Errors = "";
                            string ErrorsIn = "";
                            decimal SLDK = 0;
                            decimal DT = 0;
                            decimal NSDK = 0;
                            Object element = new Object();
                            string sqlValue = "Values(" + MDSolutionApp.VuTrongID.ToString() + "," + _CBNVID.ToString() + ",";
                            for (int b = 1; b <= 11; b++)//Với mỗi cột
                            {
                                try
                                {
                                    element = myValues.GetValue(a, b);//Lấy dữ liệu ô excel
                                }
                                catch
                                {
                                    element = DBNull.Value;
                                }
                                if (b == 1)//Mã hợp đồng
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
                                if (b == 2)//Họ tên nông hộ
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
                                if (b == 3)//Tên danh mục bãi tập kết
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
                                if (b == 4)//Tên danh mục Thôn/bản
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
                                if (b == 5)//Diện tích
                                {
                                    try
                                    {
                                        DT = decimal.Parse(element.ToString().Replace(" ", ""));
                                        DT = DT * 10000;
                                        if (DT <= 0)
                                        {
                                            DT = 0;
                                            ErrorsIn = ErrorsIn + "Sai dữ liệu diện tích. ";
                                        }
                                    }
                                    catch
                                    {
                                        ErrorsIn = ErrorsIn + "Sai dữ liệu diện tích. ";
                                    }
                                    sqlValue = sqlValue + DBModule.RefineNumber(DT) + ",";
                                }

                                if (b == 6)//Ngày trồng
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
                                        ErrorsIn = ErrorsIn + "Sai ngày trồng. ";
                                    }
                                    if (dateTime != "1900-01-01")
                                    {
                                        sqlValue = sqlValue + "'" + dateTime + "',";
                                    }
                                    else
                                    {
                                        sqlValue = sqlValue + "NULL,";
                                    }
                                }


                                if (b == 7)//Loại đất
                                {
                                    try
                                    {
                                        LoaiDat = element.ToString();
                                    }
                                    catch
                                    {
                                        LoaiDat = "";
                                    }
                                    sqlValue = sqlValue + "N'" + LoaiDat + "',";
                                }
                                if (b == 8)//Loại giống
                                {
                                    try
                                    {
                                        LoaiGiong = element.ToString();
                                    }
                                    catch
                                    {
                                        LoaiGiong = "";
                                    }
                                    sqlValue = sqlValue + "N'" + LoaiGiong + "',";
                                }
                                if (b == 9)//Lưu gốc-kiểu trồng
                                {
                                    try
                                    {
                                        KieuTrong = element.ToString();
                                    }
                                    catch
                                    {
                                        KieuTrong = "";
                                    }
                                    sqlValue = sqlValue + "N'" + KieuTrong + "',";
                                }

                                if (b == 10)//SLDK
                                {
                                    try
                                    {
                                        SLDK = decimal.Parse(element.ToString().Replace(" ", ""));

                                        if (SLDK <= 0)
                                        {
                                            SLDK = 0;
                                        }
                                    }
                                    catch
                                    {
                                        ErrorsIn = ErrorsIn + "Sai dữ liệu sản lượng dự kiến. ";
                                    }
                                    sqlValue = sqlValue + DBModule.RefineNumber(SLDK);
                                }

                            }
                            ////Khi không có đủ thông tin thì bỏ qua
                            if ((string.IsNullOrEmpty(TenThon)) && (string.IsNullOrEmpty(TenBai)) && (string.IsNullOrEmpty(HoTen)) && (string.IsNullOrEmpty(MaHopDong)))
                            {
                                continue;
                            }
                            ////Khi có đầy đủ thông tin thì đối sánh dữ liệu, nếu sai ghi lỗi
                            //if ((!string.IsNullOrEmpty(TenThon)) && (!string.IsNullOrEmpty(TenBai)) && (!string.IsNullOrEmpty(MaHopDong))&&(!string.IsNullOrEmpty(HoTen)))
                            //{
                            string sqlCheck = "sp_Check_Import_DienTich " + _CBNVID + ",N'" + MaHopDong + "',N'" + TenThon + "',N'" + TenBai + "',N'" + LoaiDat + "',N'" + LoaiGiong + "',N'" + KieuTrong + "'";
                            DataSet ret = null;
                            try { 
                                ret = DBModule.ExecuteQuery(sqlCheck, null, null);
                                }
                            catch (Exception ex)
                            {
                                MessageBox.Show("lỗi ở chưa phân lại hợp đồng: " + MaHopDong + "  ở thôn: " + TenThon + " ở bãi: " + TenBai);
                            }
                            if (ret.Tables[0].Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["ThonID"].ToString()))
                                {
                                    ThonID = ret.Tables[0].Rows[0]["ThonID"].ToString();
                                }
                                else
                                {
                                    ThonID = "-1";
                                    Errors = Errors + "Sai dữ liệu Tên thôn/bản. ";
                                }
                                if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["BaiTapKetID"].ToString()))
                                {
                                    BaiTapKetID = ret.Tables[0].Rows[0]["BaiTapKetID"].ToString();
                                }
                                else
                                {
                                    BaiTapKetID = "-1";
                                    Errors = Errors + "Sai dữ liệu Tên bãi tập kết. ";
                                }
                                if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["HopDongID"].ToString()))
                                {
                                    HopDongID = ret.Tables[0].Rows[0]["HopDongID"].ToString();
                                }
                                else
                                {
                                    HopDongID = "-1";
                                    Errors = Errors + "Sai dữ liệu Mã/Tên nông hộ. ";
                                }
                                if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["LoaiDatID"].ToString()))
                                {
                                    LoaiDatID = ret.Tables[0].Rows[0]["LoaiDatID"].ToString();
                                }
                                else
                                {
                                    LoaiDatID = "-1";
                                    Errors = Errors + "Sai dữ liệu Tên loại đất. ";
                                }
                                if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["LoaiGiongID"].ToString()))
                                {
                                    LoaiGiongID = ret.Tables[0].Rows[0]["LoaiGiongID"].ToString();
                                }
                                else
                                {
                                    LoaiGiongID = "-1";
                                    Errors = Errors + "Sai dữ liệu Tên loại giống. ";
                                }
                                if (!string.IsNullOrEmpty(ret.Tables[0].Rows[0]["KieuTrongID"].ToString()))
                                {
                                    KieuTrongID = ret.Tables[0].Rows[0]["KieuTrongID"].ToString();
                                }
                                else
                                {
                                    KieuTrongID = "-1";
                                    Errors = Errors + "Sai dữ liệu Tên lưu gốc-kiểu trồng. ";
                                }
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

                            string sqlInsert = "Insert Into tbl_Temp_Import_Excel_NhapDienTich(VuTrongID,CanBoNongVuID,MaHopDong,HoTen,TenBai,TenThon,DienTich,NgayTrong,LoaiDat,LoaiGiong,KieuTrong," +
                                               "SanLuongDuKien,HopDongID,ThonID,BaiTapKetID,LoaiDatID,LoaiGiongID,KieuTrongID,Importer,DateImport,Errors) "
                                          + sqlValue + "," + HopDongID + "," + ThonID + "," + BaiTapKetID + "," + LoaiDatID + "," + LoaiGiongID + "," + KieuTrongID + "," + MDSolutionApp.User.ID.ToString() + ",GetDate(),N'" + Errors + ErrorsIn + "')";
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
                        releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlApp);
                        lblWaite.Visible = false;
                        ////Tải dữ liệu từ bảng tạm lên form
                        MDForms.DienTich.frm_Temp_Import_DienTich frm = new MDForms.DienTich.frm_Temp_Import_DienTich(_CBNVID, TenCBNV, TenFile);
                        frm.ShowDialog();
                        if (frm.OK > 0)
                        {
                            Load_DL_DienTich(_CBNVID);
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
            else
            {
                lblWaite.Visible = false;
                MessageBox.Show("Bạn chưa chọn cán bộ địa bàn!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cmdXuatExcel_Click(object sender, EventArgs e)
        {
            if (this.gdChiTietDienTichCBDB.RowCount > 0)
            {
                try
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                        {
                            Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                            exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                            exporter.GridEX = gdChiTietDienTichCBDB;
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

        private void frm_DienTichCBDB_Load(object sender, EventArgs e)
        {
            lblTitle.Text = lblTitle.Text + MDSolutionApp.VuTrongTen;
            if (MDSolutionApp.ChotDuLieuDienTich > 0)
            {
                cmdAddFromExcel.Enabled = false;
            }
        }



    }
}