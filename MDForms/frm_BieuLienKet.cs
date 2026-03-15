using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace MDSolution.MDForms
{
    public partial class frm_BieuLienKet : Form
    {
        private DataSet gridDataSource;
        static frm_BieuLienKet _frm_BieuLienKet;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_BieuLienKet OneInstanceFrm
        {
            get
            {
                if (null == _frm_BieuLienKet || _frm_BieuLienKet.IsDisposed)
                {
                    _frm_BieuLienKet = new frm_BieuLienKet();
                }

                return _frm_BieuLienKet;
            }
        }
        public frm_BieuLienKet()
        {
            InitializeComponent();
        }
        public void LoadData(string VTID)
        {
                string sql = "sp_RP_BieuLienKet   " + VTID;
                this.gridDataSource = DBModule.ExecuteQuery(sql, null, null);
                if (this.gridDataSource.Tables.Count > 0)
                {
                    this.gdChiTietDauTu.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");
                }
                else
                {
                    this.gdChiTietDauTu.DataSource = DBNull.Value;
                }

        }
        public void LoadData1()
        {
            //if (this.dtTuNgay.Value.Date <= this.dtDenNgay.Value.Date)
            //{
            //    string strWhere = "";
            //    strWhere += " SLTT.NgayGioCanVao>=" + DBModule.RefineDatetime(this.dtTuNgay.Value.Date);
            //    strWhere += " AND SLTT.NgayGioCanVao<=" + DBModule.RefineDatetime(this.dtDenNgay.Value.Date);

            //    if (cboTram.SelectedIndex > 0)
            //    {
            //        strWhere += " AND a.TramID =" + cboTram.SelectedValue;
            //    }
            //    if (uiDaThuHoach.SelectedIndex > 0)
            //    {
            //        strWhere += " AND a.DaChat =" + uiDaThuHoach.SelectedValue.ToString();
            //    }
            //    string strSQL = "select c.HoTen, d.TenXuDong, a.TramID,a.HopDongID,a.XuDongID,SLTT.NgayGioCanVao AS ngaychat,a.ThuaRuongID, a.DaChat ,isnull(b.DienTich,0) as DienTich,b.KieuTrongID "
            //    + " ,isNull(dt.SumSoTien,0) as SoTien,ISNULL(SLTT.SanLuong,0) as so_luong from tbl_LenhChatMia a LEFT JOIN tbl_ThuaRuong b on a.ThuaRuongID=b.ID"
            //    + " LEFT JOIN tbl_HopDong c on a.HopDongID=c.ID"
            //    + " LEFT JOIN tbl_XuDong d on a.XuDongID=d.ID "
            //    + " LEFT JOIN (SELECT ThuaRuongID,sum(SoTien) as SumSoTien FROM tbl_DauTu GROUP BY ThuaRuongID) as dt on b.ID=dt.ThuaRuongID "
            //    + " Left Join (Select ThuaRuongID,Convert(Char(10),NgayGioCanVao,121) As NgayGioCanVao,SUM(TongTrongLuong-TrongLuongXe) As SanLuong From tbl_NhapMia Where TrongLuongXe>0 "
            //        //+ " And NgayGioCanVao>=" + DBModule.RefineDatetime(this.dtTuNgay.Value.Date)+" And NgayGioCanVao<="+ DBModule.RefineDatetime(this.dtDenNgay.Value.Date)
            //    + " Group By ThuaRuongID,Convert(Char(10),NgayGioCanVao,121)) as SLTT ON a.ThuaRuongID=SLTT.ThuaRuongID "
            //    + "   WHERE " + strWhere + "  ORDER BY a.HopDongID,a.XuDongID,a.TramID,a.ngaychat";

            string sql = "sp_RP_BieuLienKet   " + ComboVuTrong.SelectedValue.ToString();
            this.gridDataSource = DBModule.ExecuteQuery(sql, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gridDataSource = DBModule.ExecuteQuery(sql, null, null);
                if (this.gridDataSource.Tables.Count > 0)
                {
                    long HopDongID1, XuDongID1, HopDongID2 = -1, XuDongID2 = -1;
                    string ThuaRuongIDs = "";
                    DateTime NgayChat1, NgayChat2;
                    double dientichTong = 0, mX = 0, slX = 0, tongTien = 0;
                    //Janus.Data.
                    System.Data.DataTable dtData = new System.Data.DataTable();
                    ////Các cột thông tin chủ hợp đồng, CBNV, Diện tích
                        //Cột xã
                        DataColumn TenXa = new DataColumn("TenXa");
                        TenXa.DataType = typeof(string);
                        TenXa.Caption = "Xã";
                        dtData.Columns.Add(TenXa);
                        //Cột bản
                        DataColumn TenThon = new DataColumn("TenThon");
                        TenThon.DataType = typeof(string);
                        TenThon.Caption = "Bản";
                        dtData.Columns.Add(TenThon);
                        //Cột CBNV
                        DataColumn TenCanBoNongVu = new DataColumn("TenCanBoNongVu");
                        TenCanBoNongVu.DataType = typeof(string);
                        TenCanBoNongVu.Caption = "CBNV";
                        dtData.Columns.Add(TenCanBoNongVu);
                        //Cột Mã HĐ
                        DataColumn MaChuHopDong = new DataColumn("MaChuHopDong");
                        MaChuHopDong.DataType = typeof(string);
                        MaChuHopDong.Caption = "Mã HĐ";
                        dtData.Columns.Add(MaChuHopDong);
                        //Cột tên chủ HĐ
                        DataColumn TenChuHopDong = new DataColumn("TenChuHopDong");
                        TenChuHopDong.DataType = typeof(string);
                        TenChuHopDong.Caption = "Tên chủ HĐ";
                        dtData.Columns.Add(TenChuHopDong);
                        //Cột Tổng diện tích
                        DataColumn TongDienTichTong = new DataColumn("TongDienTichTong");
                        TongDienTichTong.Caption = "Diện tích";
                        TongDienTichTong.DataType = typeof(double);
                        dtData.Columns.Add(TongDienTichTong);
                    ///////End of thông tin hợp đồng, CBNV, tổng diện tích

                    /////Phân loại diện tích theo độc dốc, lưu gốc
                        //Cột đất dốc
                        DataColumn DatDocTong = new DataColumn("DatDocTong");
                        DatDocTong.Caption = "Đất dốc";
                        DatDocTong.DataType = typeof(double);
                        dtData.Columns.Add(DatDocTong);
                        //Cột đất bằng
                        DataColumn DatBangTong = new DataColumn("DatBangTong");
                        DatBangTong.Caption = "Đất bằng";
                        DatBangTong.DataType = typeof(double);
                        dtData.Columns.Add(DatBangTong);
                        //Cột mía tơ
                        DataColumn TrongMoiTong = new DataColumn("TrongMoiTong");
                        TrongMoiTong.Caption = "Mía tơ";
                        TrongMoiTong.DataType = typeof(double);
                        dtData.Columns.Add(TrongMoiTong);
                        //Cột mía gốc 1
                        DataColumn Goc1Tong = new DataColumn("Goc1Tong");
                        Goc1Tong.Caption = "Gốc 1";
                        Goc1Tong.DataType = typeof(double);
                        dtData.Columns.Add(Goc1Tong);
                        //Cột mía gốc 2
                        DataColumn Goc2Tong = new DataColumn("Goc2Tong");
                        Goc2Tong.Caption = "Gốc 2";
                        Goc2Tong.DataType = typeof(double);
                        dtData.Columns.Add(Goc2Tong);
                        //Cột mía gốc 2
                        DataColumn Goc3Tong = new DataColumn("Goc3Tong");
                        Goc3Tong.Caption = "Từ gốc 3 trở đi";
                        Goc3Tong.DataType = typeof(double);
                        dtData.Columns.Add(Goc3Tong);
                    ////////////End of Phân loại diện tích theo độc dốc, lưu gốc

                    ///////Phân loại diện tích theo giống
                        //Giống R22
                        DataColumn R22Tong = new DataColumn("R22Tong");
                        R22Tong.Caption = "R22";
                        R22Tong.DataType = typeof(double);
                        dtData.Columns.Add(R22Tong);
                        //Giống R579
                        DataColumn R579Tong = new DataColumn("R579Tong");
                        R579Tong.Caption = "R579";
                        R579Tong.DataType = typeof(double);
                        dtData.Columns.Add(R579Tong);
                        //Giống My-5514
                        DataColumn MyTong = new DataColumn("MyTong");
                        MyTong.Caption = "My-5514";
                        MyTong.DataType = typeof(double);
                        dtData.Columns.Add(MyTong);
                        //Giống khác còn lại
                        DataColumn KhacTong = new DataColumn("KhacTong");
                        KhacTong.Caption = "Khac";
                        KhacTong.DataType = typeof(double);
                        dtData.Columns.Add(KhacTong);
                    //////End of phân loại diện tích theo Giống

                    /////Các mục đầu tư - Hỗ trợ
                        //Nợ cũ các vụ trước
                        DataColumn NoTon = new DataColumn("NoTon");
                        NoTon.Caption = "Nợ tồn";
                        NoTon.DataType = typeof(long);
                        dtData.Columns.Add(NoTon);
                        //Đầu tư giống
                        DataColumn DauTuMiaGiongTong = new DataColumn("DauTuMiaGiongTong");
                        DauTuMiaGiongTong.Caption = "Giống mía";
                        DauTuMiaGiongTong.DataType = typeof(long);
                        dtData.Columns.Add(NoTon);
                        //Đầu tư phân hữu cơ
                        DataColumn DauTuPhanHuuCoTong = new DataColumn("DauTuPhanHuuCoTong");
                        DauTuPhanHuuCoTong.Caption = "Phân hữu cơ";
                        DauTuPhanHuuCoTong.DataType = typeof(long);
                        dtData.Columns.Add(DauTuPhanHuuCoTong);
                        //Đầu tư phân vô cơ
                        DataColumn DauTuPhanVoCoTong = new DataColumn("DauTuPhanVoCoTong");
                        DauTuPhanVoCoTong.Caption = "Phân hữu cơ";
                        DauTuPhanVoCoTong.DataType = typeof(long);
                        dtData.Columns.Add(DauTuPhanVoCoTong);
                        //Đầu tư thuốc bảo vệ thực vật
                        DataColumn DauTuThuocBaoVeTong = new DataColumn("DauTuThuocBaoVeTong");
                        DauTuThuocBaoVeTong.Caption = "Thuốc BVTV";
                        DauTuThuocBaoVeTong.DataType = typeof(long);
                        dtData.Columns.Add(DauTuThuocBaoVeTong);
                        //Đầu tư làm đất
                        DataColumn DauTuLamDatTong = new DataColumn("DauTuLamDatTong");
                        DauTuLamDatTong.Caption = "Làm đất";
                        DauTuLamDatTong.DataType = typeof(long);
                        dtData.Columns.Add(DauTuLamDatTong);
                        //Đầu tư tiền mặt
                        DataColumn DauTuTienMatTong = new DataColumn("DauTuTienMatTong");
                        DauTuTienMatTong.Caption = "Tiền mặt";
                        DauTuTienMatTong.DataType = typeof(long);
                        dtData.Columns.Add(DauTuTienMatTong);
                        //Tổng đầu tư
                        DataColumn TongDauTuTong = new DataColumn("TongDauTuTong");
                        TongDauTuTong.Caption = "Tổng đầu tư";
                        TongDauTuTong.DataType = typeof(long);
                        dtData.Columns.Add(TongDauTuTong);
                        //Tăng giảm so với định mức
                        DataColumn TangGiamSoVoiDinhMuc = new DataColumn("TangGiamSoVoiDinhMuc");
                        TangGiamSoVoiDinhMuc.Caption = "Tăng giảm so với định mức";
                        TongDauTuTong.DataType = typeof(long);
                        dtData.Columns.Add(TangGiamSoVoiDinhMuc);
                        //Số lượng hỗ trợ
                        DataColumn HoTroSoLuong = new DataColumn("HoTroSoLuong");
                        HoTroSoLuong.Caption = "Số lượng hỗ trợ";
                        HoTroSoLuong.DataType = typeof(int);
                        dtData.Columns.Add(HoTroSoLuong);
                        //Thành tiền hỗ trợ
                        DataColumn HoTroThanhTien = new DataColumn("HoTroThanhTien");
                        HoTroThanhTien.Caption = "Thành tiền";
                        HoTroThanhTien.DataType = typeof(long);
                        dtData.Columns.Add(HoTroThanhTien);
                    ////End of nợ cũCác mục đầu tư - Hỗ trợ

                    ////Quản lý sản lượng
                        //Sản lượng mía
                        DataColumn SanLuongMia = new DataColumn("SanLuongMia");
                        SanLuongMia.Caption = "Sản lượng mía";
                        SanLuongMia.DataType = typeof(long);
                        dtData.Columns.Add(SanLuongMia);
                        //Thành tiền mía
                        DataColumn ThanhTienMia = new DataColumn("ThanhTienMia");
                        ThanhTienMia.Caption = "Thành tiền mía";
                        ThanhTienMia.DataType = typeof(long);
                        dtData.Columns.Add(ThanhTienMia);
                        //Sản lượng mía giống
                        DataColumn SanLuongMiaGiong = new DataColumn("SanLuongMiaGiong");
                        SanLuongMiaGiong.Caption = "Sản lượng mía giống";
                        SanLuongMiaGiong.DataType = typeof(long);
                        dtData.Columns.Add(SanLuongMiaGiong);
                       //Sản lượng tổng
                        DataColumn TongSanLuong = new DataColumn("TongSanLuong");
                        TongSanLuong.Caption = "Tổng sản lượng";
                        TongSanLuong.DataType = typeof(long);
                        dtData.Columns.Add(TongSanLuong);
                        //Tổng thành tiền
                        DataColumn TongThanhTien = new DataColumn("TongThanhTien");
                        TongThanhTien.Caption = "Tổng thành tiền";
                        TongThanhTien.DataType = typeof(long);
                        dtData.Columns.Add(TongThanhTien);
                    ////End of Quản lý sản lượng

                    ////Quản lý công nợ
                        //Đã thu nợ đầu tư
                        DataColumn SoLuongThuNo = new DataColumn("DaThuNo");
                        SoLuongThuNo.Caption = "Đã thu nợ";
                        SoLuongThuNo.DataType = typeof(long);
                        dtData.Columns.Add(SoLuongThuNo);
                        //Còn nợ cũ
                        DataColumn SoLuongConNoCu = new DataColumn("SoLuongConNo");
                        SoLuongConNoCu.Caption = "Còn nợ cũ";
                        SoLuongConNoCu.DataType = typeof(long);
                        dtData.Columns.Add(SoLuongConNoCu);
                        //Còn nợ đầu tư
                        DataColumn SoLuongConNo = new DataColumn("SoLuongConNo");
                        SoLuongConNo.Caption = "Còn nợ đầu tư";
                        TongThanhTien.DataType = typeof(long);
                        dtData.Columns.Add(SoLuongConNo);
                  //////En of Quản lý công nợ

                    //for (var day = this.dtTuNgay.Value.Date; day.Date <= this.dtDenNgay.Value.Date; day = day.AddDays(1))
                    //{
                    //    DataColumn dc = new DataColumn(day.Date.ToString("yyyyMMdd"));
                    //    dc.Caption = day.Date.ToString("dd");
                    //    dc.DataType = typeof(double);
                    //    dtData.Columns.Add(dc);
                    //}

                    DataRow dtRow = null;//= dtData.NewRow();
                    foreach (DataRow row in this.gridDataSource.Tables[0].Rows)
                    {
                        HopDongID1 = long.Parse(row["HopDongID"].ToString());
                        XuDongID1 = long.Parse(row["XuDongID"].ToString());
                        string ThuaRuongID = "[" + row["ThuaRuongID"].ToString() + "]";

                        double dientich = double.Parse(row["DienTich"].ToString());
                        double soLuong = double.Parse(row["so_luong"].ToString());
                        double soTien = double.Parse(row["SoTien"].ToString());

                        long loaiMia = long.Parse(row["KieuTrongID"].ToString());
                        NgayChat1 = DateTime.Parse(row["NgayChat"].ToString());
                        string dd = NgayChat1.Date.ToString("yyyyMMdd");

                        if ((HopDongID1 != HopDongID2) || (XuDongID1 != XuDongID2))
                        {
                            if (dtRow != null)
                            {
                                dtData.Rows.Add(dtRow);
                                dtRow = null;

                            }
                            dtRow = dtData.NewRow();
                            mX = 0;
                            slX = 0;
                            dientichTong = 0;
                            tongTien = 0;
                            dtRow["hoten"] = row["HoTen"].ToString();
                            dtRow["xudong"] = row["TenXuDong"].ToString();
                            dtRow["tram"] = row["TramID"].ToString();
                            //dtRow["tram"] =
                            HopDongID2 = HopDongID1;
                            XuDongID2 = XuDongID1;
                            ThuaRuongIDs = "";

                        }
                        if (!ThuaRuongIDs.Contains(ThuaRuongID))
                        {
                            ThuaRuongIDs += ThuaRuongID;
                            //các cột khác
                            dientichTong += dientich;
                            tongTien += soTien;

                            dtRow["mtong"] = dientichTong;
                            dtRow["coDauTu"] = tongTien > 0 ? 1 : 0;
                            //Mía tơ
                            if (loaiMia == 3)
                            {
                                if (dtRow["m0"].ToString() != "")
                                {
                                    double.TryParse(dtRow["m0"].ToString(), out mX);
                                }
                                else
                                {
                                    mX = 0;
                                }
                                dtRow["m0"] = mX + dientich;
                            }
                            //Mía gốc 1
                            if (loaiMia == 1)
                            {

                                if (dtRow["m1"].ToString() != "")
                                {
                                    double.TryParse(dtRow["m1"].ToString(), out mX);
                                }
                                else
                                {
                                    mX = 0;
                                }
                                dtRow["m1"] = mX + dientich;
                            }
                            //Mía gốc 2
                            if (loaiMia == 2)
                            {

                                if (dtRow["m2"].ToString() != "")
                                {
                                    double.TryParse(dtRow["m2"].ToString(), out mX);
                                }
                                else
                                {
                                    mX = 0;
                                }
                                dtRow["m2"] = mX + dientich;
                            }
                            //Mía gốc 3
                            if (loaiMia == 4)
                            {

                                if (dtRow["m3"].ToString() != "")
                                {
                                    double.TryParse(dtRow["m3"].ToString(), out mX);
                                }
                                else
                                {
                                    mX = 0;
                                }
                                dtRow["m3"] = mX + dientich;
                            }
                        }

                        if (dtRow[dd].ToString() != "")
                        {
                            double.TryParse(dtRow[dd].ToString(), out slX);
                        }
                        else
                        {
                            slX = 0;
                        }
                        dtRow[dd] = slX + soLuong;
                        //Tổng Sản lượng
                        if (dtRow["sltong"].ToString() != "")
                        {
                            double.TryParse(dtRow["sltong"].ToString(), out slX);
                        }
                        else
                        {
                            slX = 0;
                        }
                        dtRow["sltong"] = slX + soLuong;
                    }


                    if (dtRow != null)
                    {
                        dtData.Rows.Add(dtRow);
                        dtRow = null;
                    }

                    CreateHoTroCols(dtData);
                    this.gdChiTietDauTu.SetDataBinding(dtData, "");
                    //this.gdChiTietDauTu.RetrieveStructure();

                }
            }
            //}

        }
        void CreateHoTroCols(System.Data.DataTable dt)
        {
            int i = 0;
            gdChiTietDauTu.RootTable.Columns.Clear();
            foreach (DataColumn dr in dt.Columns)
            {

                GridEXColumn col = new GridEXColumn();
                col.Caption = dr.Caption;
                // col.EditType = EditType.NoEdit;
                //col.FormatString = gdChiTietDauTu.RootTable.Columns["HoTro"].FormatString;
                if (dr.DataType != typeof(string))
                {
                    col.TextAlignment = TextAlignment.Far;// grvNhapMia.RootTable.Columns["HoTro"].TextAlignment;
                    col.AggregateFunction = AggregateFunction.Sum;
                    if (i > 7)
                    {
                        col.Width = 30;
                    }
                    else if (i >= 3)
                    {
                        col.Width = 60;
                    }
                }
                else if (i == 0)
                {
                    col.AggregateFunction = AggregateFunction.Count;
                }
                // else { }
                col.DataMember = dr.ColumnName;
                col.BoundMode = ColumnBoundMode.Bound;

                col.TotalFormatString = "###,##0.#0";// gdChiTietDauTu.RootTable.Columns["HoTro"].TotalFormatString;

                gdChiTietDauTu.RootTable.Columns.Insert(i, col);
                i++;

            }
        }
      
        private void btnXuatExcelHopDong_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "BieuLienKet" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
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
        private void LoadVuTrong()
        {
            DataSet ds = new DataSet();
            clsVuTrong.GetList("", out ds, null, null);
            ComboVuTrong.DataSource = ds.Tables[0];
            ComboVuTrong.DisplayMember = "Ten";
            ComboVuTrong.ValueMember = "ID";
            ComboVuTrong.SelectedValue = MDSolutionApp.VuTrongID;
        
        }
     
        private void frm_BieuLienKet_Load(object sender, EventArgs e)
        {
            LoadVuTrong();
            ComboVuTrong.SelectedValue = MDSolutionApp.VuTrongID;
        }

        private void ComboVuTrong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboVuTrong.SelectedIndex >= 0)
            {
                LoadData(ComboVuTrong.SelectedValue.ToString());
                lblTitle.Text = "BIỂU LIÊN KẾT DỮ LIỆU SLS NIÊN VỤ " + ComboVuTrong.Text;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
