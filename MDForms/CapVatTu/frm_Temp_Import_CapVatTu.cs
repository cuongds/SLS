using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using System.Data.OleDb;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using MDSolution.MDForms;


namespace MDSolution.MDForms.CapVatTu
{
    public partial class frm_Temp_Import_CapVatTu : Form
    {
        static frm_Temp_Import_CapVatTu _frm_Temp_Import_CapVatTu;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_Temp_Import_CapVatTu OneInstanceFrm
        {
            get
            {
                if (null == _frm_Temp_Import_CapVatTu || _frm_Temp_Import_CapVatTu.IsDisposed)
                {
                    _frm_Temp_Import_CapVatTu = new frm_Temp_Import_CapVatTu();
                }

                return _frm_Temp_Import_CapVatTu;
            }
        }
        private DateTime NGAYRA = DateTime.Now;
        private string TenCBNV = "";
        private string TenVatTu = "";
        private string SoPhieu = "";
        private long XuatVTID = -1;
        private string TenFile = "";
        public int OK=0;
      
        public frm_Temp_Import_CapVatTu()
        {
            InitializeComponent();
        }
        public frm_Temp_Import_CapVatTu(long ID_XuatVT,string SP,string CBNV,string VatTu,string FileName)
        {
            InitializeComponent();
            TenCBNV = CBNV;
            TenVatTu = VatTu;
            TenFile = FileName;
            SoPhieu = SP;
            XuatVTID = ID_XuatVT;
        }
        private void LoadDaTa()
        {
            string strSQL = "SELECT  ID,HopDongID,MaHopDong,ThonID,BaiTapKetID,CanBoNongVuID,STT,HoTen,TenBai,TenThon,Modify,NgayNhan,SoLuong,Errors AS Err," +
                            "CASE WHEN Modify>0 THEN N'Đã sửa' ELSE Errors END AS Errors FROM  tbl_Temp_Import_Excel_CapVatTu Where XuatVatTuID=" + XuatVTID.ToString();
            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdDSNhanVatTu.SetDataBinding(ds.Tables[0], "RootTable");
            }
        }
   
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private decimal GiaVanChuyen(long IDBTK)
        {
            decimal DGVCBD = 0;
            decimal DGVC = 0;
            if (IDBTK > 0)
            {
                string sql = "Select Top 1 DonGiaVanChuyenVatTu From tbl_BaiTapKet_GiaCuoc WHERE BaiTapKetID=" + IDBTK.ToString() +
                              " AND VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " ORDER BY NgayAD_GiaVC_VT";
                try
                {
                    DGVCBD = decimal.Parse(DBModule.ExecuteQueryForOneResult(sql, null, null));
                }
                catch { }
                if (NGAYRA == DateTime.MinValue)
                {
                    NGAYRA = DateTime.Now;
                }
                sql = "Select Top 1 DonGiaVanChuyenVatTu From tbl_BaiTapKet_GiaCuoc WHERE BaiTapKetID=" + IDBTK.ToString()+
                             " AND NgayAD_GiaVC_VT<="+DBModule.RefineDatetime(NGAYRA)+" AND VuTrongID="+MDSolutionApp.VuTrongID.ToString()+" ORDER BY NgayAD_GiaVC_VT DESC";
                try
                {
                    DGVC = decimal.Parse(DBModule.ExecuteQueryForOneResult(sql, null, null));
                }
                catch 
                {
                    DGVC = DGVCBD;
                }
            }
            else
            {
                DGVC = 0;
            }
            return DGVC;
        }
        private long CheckNongHo()
        {
                long HDID = -1;
                string sql = "Select TOP 1 Count(HopDongID),HopDongID From tbl_Temp_Import_Excel_CapVatTu Where XuatVatTuID=" + XuatVTID.ToString() + " Group By HopDongID Having Count(HopDongID)>1";
                DataSet ds = DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count>0)
                {
                   HDID=long.Parse(ds.Tables[0].Rows[0]["HopDongID"].ToString());
                }
                return HDID;
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            long NongHo=CheckNongHo();
            string sql = "Select Count(*) from tbl_Temp_Import_Excel_CapVatTu Where XuatVatTuID=" + XuatVTID.ToString() + " And Errors!=''";
            long SoDongLoi = long.Parse(DBModule.ExecuteQueryForOneResult(sql, null, null).ToString());
            if (SoDongLoi > 0)
            {
                MessageBox.Show("Bạn chưa thể ghi dữ liệu vì có "+SoDongLoi.ToString()+" dòng bị lỗi!\nBạn có thể sửa trực tiếp trên grid hoặc sửa file excel nguồn\nvà tiến hành nhập lại sau khi đã lưu sửa file nguồn", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            if (NongHo> 0)
            {
                clsHopDong oHD = new clsHopDong(NongHo);
                oHD.Load(null, null);
                MessageBox.Show("Bạn chưa thể ghi dữ liệu vì trong danh sách các hộ nhận\ntồn tại nông hộ tên: " + oHD.HoTen+" nhận nhiều hơn một lần!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn ghi dữ liệu?", "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.lblWaite.Visible = true;
                this.lblWaite.Text = "Vui lòng đợi...";
                this.cmdSave.Enabled = false;
                this.pnBottom.Refresh();
                this.lblWaite.Refresh();
                clsNhanVatTu.DeleteXuatVatTu(XuatVTID, null, null);
                clsXuatVatTu oXVT = new clsXuatVatTu(XuatVTID);
                oXVT.Load(null, null);
                NGAYRA = oXVT.NgayRa;

                try
                {
                    foreach (GridEXRow row in gdDSNhanVatTu.GetRows())
                    {
                        long BaiTapKetID = -1;
                        long HopDongID = -1;
                        decimal SoLuong = 0;
                        DateTime NgayNhan = DateTime.MinValue;
                        //string Errors = row.Cells["Errors"].Value.ToString();
                        //if (string.IsNullOrEmpty(Errors))
                        //{
                        BaiTapKetID = long.Parse(row.Cells["BaiTapKetID"].Value.ToString());
                        HopDongID = long.Parse(row.Cells["HopDongID"].Value.ToString());
                        SoLuong = decimal.Parse(row.Cells["SoLuong"].Value.ToString());
                        NgayNhan = DateTime.Parse(row.Cells["NgayNhan"].Value.ToString());
                        clsNhanVatTu oNhanVT = new clsNhanVatTu();
                        oNhanVT.BaiTapKetID = BaiTapKetID;
                        oNhanVT.XuatVatTuID = XuatVTID;
                        oNhanVT.HopDongID = HopDongID;
                        oNhanVT.CanBoNongVuID = oXVT.CanBoNongVuID;
                        oNhanVT.SoLuong = SoLuong;
                        oNhanVT.DonGia = oXVT.DonGia;
                        oNhanVT.NgayNhan = NgayNhan;
                        oNhanVT.DonGiaVanChuyen = GiaVanChuyen(BaiTapKetID);
                        oNhanVT.TienVanChuyen = (oXVT.CoTinhCuoc * oXVT.PhanTramGiaVanChuyenMia * oNhanVT.SoLuong * oNhanVT.DonGiaVanChuyen) / 100000;
                        oNhanVT.SoTien = (oNhanVT.DonGia * oNhanVT.SoLuong);
                        oNhanVT.CreateBy = MDSolutionApp.User.ID;
                        oNhanVT.Save(null, null);
                        // }
                    }
                    OK = 1;
                    this.lblWaite.Text = "Đã ghi dữ liệu!";
                    MessageBox.Show("Đã lưu dữ liệu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    this.lblWaite.Visible = false;
                    MessageBox.Show("Có lỗi khi lưu dữ liệu!\n" + ex.ToString(), "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
         
        }

        private void frm_Temp_Import_CapVatTu_Load(object sender, EventArgs e)
        {
            lblSoPhieu.Text = SoPhieu;
            lblTenVT.Text = TenVatTu;
            lblCBNV.Text = TenCBNV;
            lblTenFile.Text = TenFile;
            LoadDaTa();
        }

        private void gdDSNhanVatTu_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e.Row.RowType == RowType.Record)
            {
                string Errors = e.Row.Cells["Err"].Value.ToString();
                if (!string.IsNullOrEmpty(Errors))
                {
                    Janus.Windows.GridEX.GridEXFormatStyle CapVT_format = new GridEXFormatStyle();
                    CapVT_format.ForeColor = Color.Red;
                    e.Row.RowStyle = CapVT_format;
                }
            }
           
        }

        private void cmdXuatExcel_Click(object sender, EventArgs e)
        {
            if (this.gdDSNhanVatTu.RowCount > 0)
            {
                try
                {
                    if (saveFileDialog_Excel.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog_Excel.FileName, System.IO.FileMode.Create))
                        {
                            Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                            exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                            exporter.GridEX = gdDSNhanVatTu;
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

        private void gdDSNhanVatTu_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
           long CBNV_ID=-1;
           long NhanVT_ID=-1;
            try
            {
                CBNV_ID = long.Parse(this.gdDSNhanVatTu.GetValue("CanBoNongVuID").ToString());
                NhanVT_ID = long.Parse(this.gdDSNhanVatTu.GetValue("ID").ToString());
            }
            catch
            {
                 return;
            }
            if (e.Column.Key == "Sua")
            {
                    MDSolution.MDForms.CapVatTu.frm_SuaNhanVatTu frm = new frm_SuaNhanVatTu(CBNV_ID, NhanVT_ID);
                    frm.ShowDialog();
                    if (frm.OK > 0)
                    {
                       try
                        {
                            LoadDaTa();
                            GridEXFilterCondition condi = new GridEXFilterCondition(this.gdDSNhanVatTu.RootTable.Columns["ID"], ConditionOperator.Equal, NhanVT_ID);
                            this.gdDSNhanVatTu.Find(condi, 0, 1);
                        }
                        catch { }
                    }
            
            }
            if (e.Column.Key == "Delete")
            {
                if (MessageBox.Show("Chức năng chỉ xóa dữ liệu trên form!\nBạn chắc chắn xóa dòng này", "SLS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                try
                {
                    MDSolution.Entities.clsCVT.Delete(NhanVT_ID, null, null);
                    LoadDaTa();
                }
                catch { }
                
            }
        }

     

    }
}