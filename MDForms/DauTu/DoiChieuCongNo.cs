using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace MDSolution.MDForms.DauTu
{
    public partial class DoiChieuCongNo : Form
    {
        private DataSet gridDataSource;
        static DoiChieuCongNo _DoiChieuCongNo;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public DoiChieuCongNo OneInstanceFrm
        {
            get
            {
                if (null == _DoiChieuCongNo || _DoiChieuCongNo.IsDisposed)
                {
                    _DoiChieuCongNo = new DoiChieuCongNo();
                }

                return _DoiChieuCongNo;
            }
        }
        public DoiChieuCongNo()
        {
            InitializeComponent();
            //Load_CB_LoaiHD();
            //Load_CB_Tram();
        }
        //private void Load_CB_LoaiHD()
        //{
        //    string sql = "Select * from LoaiHopDong";
        //    DataSet ds = DBModule.ExecuteQuery(sql, null, null);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        DataRow dr = ds.Tables[0].NewRow();
        //        dr["ID"] = 0;
        //        dr["Ten"] = "------Tất cả các loại HĐ------";
        //        ds.Tables[0].Rows.InsertAt(dr, 0);
        //        cboLoaiHopDong.DataSource = ds.Tables[0];
        //        cboLoaiHopDong.ValueMember = "ID";
        //        cboLoaiHopDong.DisplayMember = "Ten";              
        //    }
        //    else
        //    {
        //        cboLoaiHopDong.DataSource = null;

        //    }
        //}
        //private void Load_CB_Tram()
        //{
        //    string sql = "";           
        //    lblTram.Text = "Tên trạm:";
        //    sql = "Select ID,Ten from tbl_TramNongVu";
        //    DataSet ds = DBModule.ExecuteQuery(sql, null, null);
        //    DataRow dr = ds.Tables[0].NewRow();
        //    dr["ID"] = 0;
        //    dr["Ten"] = "----------Tất cả---------";
        //    ds.Tables[0].Rows.InsertAt(dr, 0);
        //    cboTram.DataSource = ds.Tables[0];
        //    cboTram.ValueMember = "ID";
        //    cboTram.DisplayMember = "Ten";

        //}
        public void LoadData()
        {

            string strSQL = @"SELECT     * from dbo.V2016_DoiChieuCongNo where VuTrongID=" + MDSolutionApp.VuTrongID ; 
            //MessageBox.Show(strSQL);
            this.gridDataSource = DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gridDataSource.Tables.Count > 0)
            {
                this.gdChiTietDauTu.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");

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
                saveFileDialog1.FileName = "Dautu_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
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

        private void DoiChieuCongNo_Load(object sender, EventArgs e)
        {
            string sql = "select [NgayKetChuyenDauTu],[NguoiKetChuyenDauTu] from [tbl_VuTrong] Where [ID]=" + MDSolutionApp.VuTrongID;
            DataRow dr = DBModule.ExecuteQuery(sql, null, null).Tables[0].Rows[0];
            if (dr[0].ToString() != "")
            {
                btnDoiTru.Enabled = false;
            }
            btnDoiTru.Enabled = true;
            LoadData();
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

        private void btnDoiTru_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thực hiện đối trừ công nợ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    string sql = "sp_2016_DoiTruCongNo " + MDSolutionApp.VuTrongID + "," + MDSolutionApp.User.ID;
                    DBModule.ExecuteNonQuery(sql, null, null);
                    sql = "select * from dbo.tbl_DoiChieuCongNo where VuTrongID= " + MDSolutionApp.VuTrongID;
                    DataSet ds = DBModule.ExecuteQuery(sql, null, null);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        double tongtien = 0;
                        double.TryParse(((decimal)dr["TongNo"]).ToString("##0"), out tongtien);
                        string sTongTien = "";
                        if (tongtien < 0)
                        {
                            tongtien = 0 - tongtien;
                            sTongTien = "(âm) ";
                        }
                        sTongTien += Utils.DocSo(tongtien);
                        sql += "update tbl_DoiChieuCongNo set TongNo_BangChu=N'" + sTongTien + "' where HopDongID=" + dr["HopDongID"] + " and VuTrongID= " + MDSolutionApp.VuTrongID + ";";

                    }
                    DBModule.ExecuteNonQuery(sql, null, null);
                    MessageBox.Show("Đã đối trừ xong", "Thông báo");
                    LoadData();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Có lỗi khi đối trừ " + ex.Message, "Thông báo");
                }


            }


        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (gdChiTietDauTu.GetCheckedRows().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn phiếu cần in"); return;
            }
            string CBDB = "LayTrenDB";
            if (!chkSuDungDB.Checked) CBDB = txtDaiDienTen5.Text;
            string[] paramNames = new string[] { "@VuTrongID", "@DaiDien1", "@DaiDien2", "@DaiDien3", "@DaiDien4", "@DaiDien5", "@ChucVu1", "@ChucVu2", "@ChucVu3", "@ChucVu4", "@Ky1", "@Ky2", "@Ky3" };
            string[] paraValues = new string[] { MDSolutionApp.VuTrongID.ToString(), txtDaiDien1.Text + " " + txtDaiDienTen1.Text, txtDaiDien2.Text + " " + txtDaiDienTen2.Text, txtDaiDien3.Text + " " + txtDaiDienTen3.Text, txtDaiDien4.Text + " " + txtDaiDienTen4.Text,CBDB, txtChucVu1.Text, 
                txtChucVu2.Text, txtChucVu3.Text, txtChucVu4.Text, txtDaiDienTen1.Text, txtDaiDienTen2.Text, txtDaiDienTen3.Text };

            string sql = @"SELECT     dbo.tbl_HopDong.ID, dbo.tbl_HopDong.MaHopDong, dbo.tbl_HopDong.NgaySinh, dbo.tbl_HopDong.SoCMT, dbo.tbl_HopDong.NgayCap, dbo.tbl_HopDong.NoiCap, 
                      dbo.tbl_HopDong.ThonID, dbo.tbl_HopDong.NguoiThuaKe1Ten, dbo.tbl_HopDong.NguoiThuaKe1DiaChi, dbo.tbl_HopDong.NguoiThuaKe1CMT, 
                      dbo.tbl_HopDong.NguoiThuaKe2Ten, dbo.tbl_HopDong.NguoiThuaKe2DiaChi, dbo.tbl_HopDong.NguoiThuaKe2CMT, dbo.tbl_HopDong.TrangThai, 
                      dbo.tbl_HopDong.HoTen, dbo.tbl_HopDong.NgayKyHopDong, dbo.tbl_HopDong.CreatedBy, dbo.tbl_HopDong.ModifyBy, dbo.tbl_HopDong.DateAdd, 
                      dbo.tbl_HopDong.NgayCMTTKP, dbo.tbl_HopDong.NoteModify, dbo.tbl_HopDong.Status, dbo.tbl_HopDong.SoTaiKhoan, dbo.tbl_HopDong.NganHangID, 
                      dbo.tbl_HopDong.ParentID, dbo.tbl_HopDong.Diachi, dbo.tbl_HopDong.DataModify, dbo.tbl_HopDong.CanBoNongVuID, dbo.tbl_HopDong.QuanHe, 
                      dbo.V2016_DiaChiThonXaHuyen.HuyenTen + N'_' + dbo.V2016_DiaChiThonXaHuyen.XaTen + N'_' + dbo.V2016_DiaChiThonXaHuyen.ThonTen AS GhiChu
                    FROM         dbo.tbl_HopDong INNER JOIN
                      dbo.V2016_DiaChiThonXaHuyen ON dbo.tbl_HopDong.ThonID = dbo.V2016_DiaChiThonXaHuyen.ThonID where 1=3 ";
            foreach (Janus.Windows.GridEX.GridEXRow r in gdChiTietDauTu.GetCheckedRows())
            {
                sql += " or dbo.tbl_HopDong.ID=" + r.Cells["ID"].Value;
            }
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);

            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            //dt.Columns.Add("ID");
            //foreach (Janus.Windows.GridEX.GridEXRow r in gdChiTietDauTu.GetCheckedRows())
            //{
            //    DataRow dr =dt.NewRow(); dr["ID"]= r.Cells["ID"].Value;
            //    dt.Rows.Add(dr);
            //}
            //ds.Tables.Add(dt);
            MDReport.Frm_ReportViewer frm = new MDSolution.MDReport.Frm_ReportViewer();
            frm.bHasPara = true;
            frm.ParaNames = paramNames;
            frm.ParaValues = paraValues;
            frm.rptFileName = "ThanhToan2016\\DSDoiChieuCongNo.rpt";
            frm.rptTitle = "";
            frm.ds = ds;
            //frm.ds = DBModule.ExecuteQuery(sql,null,null);
            //if (frmParent != null)
            //{
            //    frm.MdiParent = frmParent;
            //}
            frm.Show();
        }

        private void btnKetChuyen_Click(object sender, EventArgs e)
        {
            string sql = "select [NgayKetChuyenDauTu],[NguoiKetChuyenDauTu] from [tbl_VuTrong] Where [ID]=" + MDSolutionApp.VuTrongID;
            DataRow dr = DBModule.ExecuteQuery(sql, null, null).Tables[0].Rows[0];
            if (dr[0].ToString() != "")
            {
                DateTime dt = DateTime.Parse(dr[0].ToString());
                MessageBox.Show("Không thể thực hiện thao tác do vụ trồng đã được kết chuyển ngày " + dt.ToString("dd/MM/yyyy HH:mm:ss") + " do [" + dr[1].ToString() + "] thực hiện.");
                return;
            }
            frm_KetChuyenVu_Confirm frm = new frm_KetChuyenVu_Confirm();
            DataSet ds = new DataSet();
            clsVuTrong.GetList("", out ds, null, null);
            frm.ComboVuTrong.DataSource = ds.Tables[0];
            frm.ComboVuTrong.DisplayMember = "Ten";
            frm.ComboVuTrong.ValueMember = "ID";
            sql = "select ID,Ten from tbl_DanhMucDauTu Where [LoaiHinhDauTuID]=7";
            frm.comboDMGoc.DataSource = DBModule.ExecuteQuery(sql, null, null).Tables[0];
            frm.comboDMGoc.DisplayMember = "Ten";
            frm.comboDMGoc.ValueMember = "ID";
            frm.comboDMLai.DataSource = DBModule.ExecuteQuery(sql, null, null).Tables[0];
            frm.comboDMLai.DisplayMember = "Ten";
            frm.comboDMLai.ValueMember = "ID";

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sql = "sp_2017_KetChuyenVu_DauTu " + MDSolutionApp.VuTrongID + ", " + frm.ComboVuTrong.SelectedValue + "," + DBModule.RefineDatetime(frm.dtNgayTinhLai.Value) + "," + frm.comboDMGoc.SelectedValue + "," + frm.comboDMLai.SelectedValue + "," + MDSolutionApp.User.ID;
                try
                {
                    DBModule.ExecuteNonQuery(sql, null, null);
                    MessageBox.Show("Kết chuyển thành công.");
                }
                catch (Exception exx)
                {
                    MessageBox.Show(exx.Message);
                }
            }

        }

        private void chkSuDungDB_CheckedChanged(object sender, EventArgs e)
        {
            txtDaiDienTen5.ReadOnly = chkSuDungDB.Checked;
        }

        private void tbl_hotro_Click(object sender, EventArgs e)
        {
            long ID_HopDong = -1;
            try
            {
                ID_HopDong = long.Parse(this.gdChiTietDauTu.GetValue("ID").ToString());
                if (ID_HopDong > 0)
                {
                    frm_NhapHoTro frm = new frm_NhapHoTro(ID_HopDong, true);
                    frm.ShowDialog();
                    if (frm.OK > 0)
                    {
                        LoadData();
                        try
                        {
                            GridEXFilterCondition condi = new GridEXFilterCondition(gdChiTietDauTu.Tables[0].Columns["ID"], ConditionOperator.Equal, frm._IDDauTu);
                            gdChiTietDauTu.Find(condi, 0, 1);
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
        }
    }
}
