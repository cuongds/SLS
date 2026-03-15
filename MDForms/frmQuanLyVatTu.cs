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
using MDSolution.MDForms;

namespace MDSolution
{
    public partial class frmQuanLyVatTu : Form
    {
        private NodeCanBoNongVu nDonVi = new NodeCanBoNongVu();
        private clsHopDong oHopDong = new clsHopDong();
        private clsDanhMucCanBoNongVu objCBNV = new clsDanhMucCanBoNongVu();
       
        private string strBaiTapKet = null;
        private string strVatuID = null;
        private string strPass = "";
        private string VuTrongVC = "";
        private string ThonID = "";
        public string CanBoNongVu_ID = "";
        public string CBNVIDBan = "";
        public string XeVanChuyen_ID = "";
        public string BaiTapKet_ID = "";
        public string SoPhieu = "";
        public long lSoPhieu = 0;
        public string SoPhieuBan = "";
        public long XeID = -1;
        private long IDS = -1;
        private bool sua = false;
        public DateTime NgayLapPhieu_ID = DateTime.Now;
        private DataSet gridDataSource;
       // frm_LapPhieuVatTu frmLapPhieu;
        public frmQuanLyVatTu()
        {
            InitializeComponent();
            CommonClass.loadTreeHopDongCanBoNongVu(treeDonVi);
            loadxevanchuyen();
            loadbaitapket(null);
            loadvattu(null);
            loadThon();
            LoadTongVatTuThon();
            loadXeNgoai();
            loadDanhSachLap();
            LoadVuTrong();
            //LoadThonSource();
        }
        private DataSet LoadHopDong()
        {

            //LoadDDLCanBoNongVu();
            string strSQL = "";
            strSQL = @"SELECT a.*,b.Ten as TenThon, c.Ten as TenXa,dbo.tbl_DanhMucCanBoNongVu.ID as CanBoID ,dbo.tbl_DanhMucCanBoNongVu.Ten as TenCanBoNongVu
                FROM            dbo.tbl_HopDong AS a INNER JOIN dbo.tbl_Thon AS b ON a.ThonID = b.ID INNER JOIN dbo.tbl_Xa AS c ON c.ID = b.XaID INNER JOIN dbo.tbl_DanhMucCanBoNongVu ON b.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.id                       
                        WHERE a.parentid=0 AND TrangThai = 1 AND a.ID IN (SELECT HopDongID From tbl_HopDongVuTrong Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString() + ")";
            //string strCacTramID = Load_PhanQuyen_CacTramID();
            switch (nDonVi.CBNVType)
            {
                case CBNVType.ThonID: strSQL += " AND (b.ID =" + nDonVi.CBNVID + ")"; break;
                case CBNVType.CBNV: strSQL += " AND dbo.tbl_DanhMucCanBoNongVu.id=" + nDonVi.CBNVID; lbl_CBDB.Text = nDonVi.CBNVName; break;
                default: break;
            }

            return DBModule.ExecuteQuery(strSQL, null, null);

        }
        private void loadVatTuThon()
        {
            string sqlvattuthon = @"SELECT        dbo.tbl_Thon.Ten AS TenThon, dbo.tbl_DanhMucVatTu.Ten AS VatTu, dbo.tbl_NhanVatTuThon.SoLuong, dbo.tbl_NhanVatTuThon.DonGia AS GiaVatTu, 
                         dbo.tbl_NhanVatTuThon.SoTien, dbo.tbl_NhanVatTuThon.DonGiaVanChuyen, dbo.tbl_NhanVatTuThon.TienVanChuyen, 
                         dbo.tbl_DanhMucCanBoNongVu.Ten AS CanBoNongVu, dbo.tbl_NhanVatTuThon.ID
FROM            dbo.tbl_NhanVatTuThon INNER JOIN
                         dbo.tbl_DanhMucVatTu ON dbo.tbl_NhanVatTuThon.VatTuID = dbo.tbl_DanhMucVatTu.ID INNER JOIN
                         dbo.tbl_Thon ON dbo.tbl_NhanVatTuThon.ThonID = dbo.tbl_Thon.ID INNER JOIN
                         dbo.tbl_XuatVatTu ON dbo.tbl_NhanVatTuThon.XuatVatTuID = dbo.tbl_XuatVatTu.ID INNER JOIN
                         dbo.tbl_DanhMucCanBoNongVu ON dbo.tbl_XuatVatTu.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.id  WHERE dbo.tbl_XuatVatTu.SoPhieu= " + txt_sophieuban.Text;
            try{
            DataSet DSCapThon = DBModule.ExecuteQuery(sqlvattuthon,null,null);

            if (DSCapThon.Tables.Count > 0)
            {
                this.gridEXCapBan.SetDataBinding(DSCapThon.Tables[0], "");
            }
           
            }
            catch{}
        
        
        }
        private void loadXeNgoai()

        {
            if (check_XeNgoai.Checked == false)
            {
                this.groupBoxXe.Visible = false;
            
            }
        
        
        }
        private void LoadTongVatTuThon()
        {

            string sqlvattutongthon = @"SELECT        dbo.tbl_Thon.Ten AS TenThon, dbo.tbl_DanhMucVatTu.Ten AS VatTu, dbo.tbl_NhanVatTuThon.SoLuong, dbo.tbl_NhanVatTuThon.DonGia AS GiaVatTu, 
                         dbo.tbl_NhanVatTuThon.SoTien, dbo.tbl_NhanVatTuThon.DonGiaVanChuyen, dbo.tbl_NhanVatTuThon.TienVanChuyen, 
                         dbo.tbl_DanhMucCanBoNongVu.Ten AS CanBoNongVu, dbo.tbl_NhanVatTuThon.ID,dbo.tbl_XuatVatTu.SoPhieu
FROM            dbo.tbl_NhanVatTuThon INNER JOIN
                         dbo.tbl_DanhMucVatTu ON dbo.tbl_NhanVatTuThon.VatTuID = dbo.tbl_DanhMucVatTu.ID INNER JOIN
                         dbo.tbl_Thon ON dbo.tbl_NhanVatTuThon.ThonID = dbo.tbl_Thon.ID INNER JOIN
                         dbo.tbl_XuatVatTu ON dbo.tbl_NhanVatTuThon.XuatVatTuID = dbo.tbl_XuatVatTu.ID INNER JOIN
                         dbo.tbl_DanhMucCanBoNongVu ON dbo.tbl_XuatVatTu.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.id";
            try
            {
                DataSet DSCapTongThon = DBModule.ExecuteQuery(sqlvattutongthon, null, null);

                if (DSCapTongThon.Tables.Count > 0)
                {
                    this.gridEX4.SetDataBinding(DSCapTongThon.Tables[0], "");
                }

            }
            catch { }
        
        }



        private void LoadThonSource()
        {
            //            string strSQL = @"SELECT a.*,b.Ten as TenThon, c.Ten as TenXa,dbo.tbl_DanhMucCanBoNongVu.ID as CanBoID ,dbo.tbl_DanhMucCanBoNongVu.Ten as TenCanBoNongVu
            //FROM            dbo.tbl_HopDong AS a INNER JOIN dbo.tbl_Thon AS b ON a.ThonID = b.ID INNER JOIN dbo.tbl_Xa AS c ON c.ID = b.XaID INNER JOIN dbo.tbl_DanhMucCanBoNongVu ON b.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.id                       
            //                        WHERE a.parentid=0 AND TrangThai = 1 AND a.ID IN (SELECT HopDongID From tbl_HopDongVuTrong Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString() + ")";
            //            nDonVi.CBNVType.ToString();
            //            switch (nDonVi.CBNVType)
            //            {
            //                case CBNVType.ThonID: strSQL += " AND ID IN (SELECT ID FROM tbl_Thon WHERE ID=" + nDonVi.HasLoadChildren + ")"; break;
            //                case CBNVType.CBNV: strSQL += " AND dbo.tbl_DanhMucCanBoNongVu.id=" + nDonVi.CBNVID; break;            
            //                default: break;
            //            }
            //            this.gridThonSource = DBModule.ExecuteQuery(strSQL, null, null);

            //            if (this.gridThonSource.Tables.Count > 0 && this.gridThonSource.Tables[0].Rows.Count > 0)
            //            {
            //                this.GridEX1.DropDowns["Thon"].SetDataBinding(this.gridThonSource.Tables[0], "");
            //                this.GridEX1.Tables[0].Columns["ThonID"].DefaultValue = this.gridThonSource.Tables[0].Rows[0]["ID"];

        }

        private void LoadVuTrong()
        {

            uiComboVuTrong.DataSource = DBModule.ExecuteQuery("SELECT * FROM tbl_VuTrong", null, null).Tables[0];
            uiComboVuTrong.DisplayMember = "Ten";
            uiComboVuTrong.ValueMember = "ID";
        }

        private void loadxevanchuyen()
        {
            try
            {
                ui_SoXe.DataSource = DBModule.ExecuteQuery("SELECT * FROM tbl_HopDongVanChuyen WHERE VuTrongID = " + VuTrongVC, null, null).Tables[0];
                ui_SoXe.DisplayMember = "MaHopDong";
                ui_SoXe.ValueMember = "ID";

            }
            catch { }


        }

        private void loadThon()
        {
            try
            {
                DataSet dsthon = new DataSet();
                if (ThonID != "")
                {
                    ThonID = "ThonID=" + ThonID;
                }

                string sqlthon = "SELECT * FROM [dbo].[tbl_Thon] WHERE 1=1 ";
                switch (nDonVi.CBNVType)
                {
                    case CBNVType.ThonID: sqlthon += " AND (ID=" + nDonVi.CBNVID + ")"; break;
                    case CBNVType.CBNV: sqlthon += " AND dbo.tbl_Thon.CanBoNongVuID=" + nDonVi.CBNVID; lbl_CBDB.Text = nDonVi.CBNVName; break;
                    default: break;
                }
                dsthon = DBModule.ExecuteQuery(sqlthon, null, null);
                ui_Thon.DataSource = dsthon.Tables[0];
                ui_Thon.DisplayMember = "Ten";
                ui_Thon.ValueMember = "ID";

            }
            catch { }


        }


        private void loadbaitapket( string strBaiTapKet)
        {
            try
            {
                DataSet dsbtk = new DataSet();
                if (ThonID != "")
                {
                    ThonID = "ThonID=" + ThonID;
                }

                string sqlBaiTapKet = "SELECT dbo.tbl_BaiTapKetVatTu.ID, dbo.tbl_BaiTapKetVatTu.TenBai FROM  dbo.tbl_BaiTapKetVatTu INNER JOIN  dbo.tbl_Thon ON dbo.tbl_BaiTapKetVatTu.ThonID = dbo.tbl_Thon.ID WHERE 1=1 ";
                if (strBaiTapKet != null)
                { 
                
                sqlBaiTapKet+= " AND dbo.tbl_BaiTapKetVatTu.ID = " + strBaiTapKet;
                }

                switch (nDonVi.CBNVType)
                {
                    case CBNVType.ThonID: sqlBaiTapKet += " AND (dbo.tbl_BaiTapKetVatTu.ThonID =" + nDonVi.CBNVID + ")"; break;
                    case CBNVType.CBNV: sqlBaiTapKet += " AND dbo.tbl_Thon.CanBoNongVuID=" + nDonVi.CBNVID; lbl_CBDB.Text = nDonVi.CBNVName; break;
                    default: break;
                }
                dsbtk = DBModule.ExecuteQuery(sqlBaiTapKet, null, null);
                ui_BaiTapket.DataSource = dsbtk.Tables[0];
                ui_BaiTapket.DisplayMember = "TenBai";
                ui_BaiTapket.ValueMember = "ID";
            }
            catch { }

        }
        private void loadvattu(string strVatTuID)
        {
            try
            {
                DataSet dsvt = new DataSet();

                string IDVatut = "";
                if (strVatTuID != null)
                {
                    IDVatut = "  ID= "+ strVatTuID;
                }


                dsvt = clsDanhMucVatTu.GetListbyWhere("", IDVatut, "", null, null);
                uiVatTu.DataSource = dsvt.Tables[0];
                uiVatTu.DisplayMember = "Ten";
                uiVatTu.ValueMember = "ID";
            }
            catch { }

        }
        private void CreateDataSourceAndBindGrid()
        {
            gridDataSource = this.LoadHopDong();
            if (gridDataSource.Tables.Count > 0)
            {
                //this.GridEX1.SetDataBinding(gridDataSource.Tables[0], "");
            }
        }
        private void CreateDataSourceAndBindGrid1()
        {
            gridDataSource = this.LoadHopDong();
            if (gridDataSource.Tables.Count > 0)
            {
                this.gridEX3.SetDataBinding(gridDataSource.Tables[0], "");
            }
        }

        private void treeDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {

                nDonVi = (NodeCanBoNongVu)treeDonVi.SelectedNode.Tag;
                this.DoLoadGridHopDong();
                ////uiPanel2.Text = "Đơn vị: " + treeDonVi.SelectedNode.Text.ToUpper() + "/Số HĐ: " + GridEX1.RowCount.ToString();
            }
        }

        private void DoLoadGridHopDong()
        {
            if (uiTabPage5.Selected == true)
            {
                try
                {
                    this.CreateDataSourceAndBindGrid1();
                    this.gridEX3.Focus();
                    gridEX3.MoveFirst();
                    this.gridEX3.Refresh();
                }
                catch { }

            }
            if (uiTabPage1.Selected == true)
            {
                try
                {
                    this.LoadThonSource();
                    //this.LoadDDLCanBoNongVu();
                    this.CreateDataSourceAndBindGrid();
                    //this.GridEX1.Focus();
                    //GridEX1.MoveFirst();
                    //this.GridEX1.Refresh();
                }
                catch { }
            }
            if (uiTabPage6.Selected == true)
            {
                try
                {
                    this.loadThon();
                    this.CreateDataSourceAndBindGrid();
                    this.gridEXCapBan.Focus();
                    gridEXCapBan.MoveFirst();
                    this.gridEXCapBan.Refresh();
                }
                catch { }
            }
            if (uiTabPage7.Selected == true)
            {
                try {
                    this.LoadTongVatTuThon();
                }
                catch { }
            }

        }
        private void treeDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (uiTabPage1.Selected == true)
            {
                try
                {
                    nDonVi = (NodeCanBoNongVu)e.Node.Tag;
                    this.DoLoadGridHopDong();
                    this.loadbaitapket(null);
                }
                catch { }

            }
            if (uiTabPage6.Selected == true)
            {
                try
                {
                    nDonVi = (NodeCanBoNongVu)e.Node.Tag;
                    this.loadThon();
                }
                catch { }

            }
            if (uiTabPage5.Selected == true)
            {
                try
                {
                    nDonVi = (NodeCanBoNongVu)e.Node.Tag;
                    this.DoLoadGridHopDong();
                    this.loadbaitapket(null);
                }
                catch { }

            }

            if (uiTabPage4.Selected == true)
            {
                nDonVi = (NodeCanBoNongVu)e.Node.Tag;
                LoadData();
            }
        }
        private void GridEX1_RecordAdded(object sender, EventArgs e)
        {
            this.DoLoadGridHopDong();
            //this.GridEX1.Refetch();
            //this.GridEX1.Tables[0].Columns["MaHopDong"].DefaultValue = this.GetMaHopDong();
        }

        private void treeDonVi_AfterSelect(object sender, TreeViewEventArgs e)
        {

            this.DoLoadGridHopDong();

            NodeCanBoNongVu ndv = (NodeCanBoNongVu)treeDonVi.SelectedNode.Tag;
            string TenDonvi = "";
            switch (ndv.CBNVType)
            {
                case CBNVType.Root:
                    TenDonvi = "Đơn vị"; break;
                case CBNVType.CBNV:
                    TenDonvi = "CBDB: " + treeDonVi.SelectedNode.Text.ToUpper().Replace("CBĐB", "").Trim(); break;
                case CBNVType.ThonID:
                    TenDonvi = "Thôn: " + treeDonVi.SelectedNode.Parent.Text.ToUpper().Replace("CBĐB", "").Trim() + "  Thôn: " + treeDonVi.SelectedNode.Text.ToUpper().Replace("THÔN", "").Trim(); ThonID = treeDonVi.SelectedNode.Name.ToString(); loadbaitapket(null);
                    break;

            }
            uiPanel2.Text = TenDonvi + "    ";


            //uiPanel0.Hide();
        }

        private string GetMaHopDong()
        {
            try
            {
                string strXaID = "";
                // nDonVi = (NodeCanBoNongVu)treeDonVi.SelectedNode.Tag;
                //if (nDonVi.Type == DonviType.Xa)
                //{
                //    strXaID = nDonVi.DonViID;
                //}
                //else if (nDonVi.Type == DonviType.Thon)
                //{
                //    clsThon oThon = new clsThon(long.Parse(nDonVi.DonViID));
                //    oThon.Load(null, null);
                //    strXaID = oThon.XaID.ToString();
                //}
                string strSQL = "SELECT [MaXa] FROM tbl_Xa Where [ID]=" + strXaID;
                string maXa = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
                string strMaxID = "";
                int batdau = maXa.Trim().Length + 1;
                strSQL = "SELECT max(cast(ltrim(rtrim(substring(mahopdong," + batdau.ToString() + ", 10))) as numeric(10))) FROM tbl_HopDong WHERE ThonID in (SELECT [id] FROM tbl_Thon WHERE XaID =" + strXaID + ") ";
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

        private void frmQuanLyVatTu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }



        //private void toolChitiethopdong_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(this.GridEX1.GetValue("ID").ToString()))
        //        {
        //            long oID = long.Parse(this.GridEX1.GetValue("ID").ToString());

        //            frmViewHopDong aa = new frmViewHopDong(oID);
        //            aa.MdiParent = this.MdiParent;
        //            aa.Show();
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Chọn chính xác hợp đồng cần xem chi tiết");
        //    }
        //}



        private void ToolStripMenuItemChuyenThanhHD_Click(object sender, EventArgs e)
        {
            try
            {
                oHopDong = new clsHopDong();
                //oHopDong.ID = long.Parse(gridEX2.GetValue("ID").ToString());
                oHopDong.Load(null, null);
                oHopDong.ParentID = 0;
                oHopDong.Save(null, null);
                MessageBox.Show("Việc chuyển đổi đã thành công!", "Thông báo");
                this.DoLoadGridHopDong();
            }
            catch
            {
                MessageBox.Show("Có lỗi trong khi chuyển đổi", "Lỗi");
            }
        }

        private void ui_SoXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sqlxevanchuyen = "SELECT  [ID],[SoXe],[TenLaiXe] FROM [MDSONLA].[dbo].[tbl_XeVanChuyen] WHERE VuTrongID = " + VuTrongVC + " AND HopDongVanChuyenID= " + ui_SoXe.SelectedValue.ToString();
                DataSet dsxe = DBModule.ExecuteQuery(sqlxevanchuyen, null, null);
                if (dsxe.Tables[0].Rows.Count >= 0)
                {
                    DataRow dr = dsxe.Tables[0].Rows[0];
                    XeID = long.Parse(dr["ID"].ToString());
                    lbl_Laixe.Text = (string)dr["TenLaiXe"];
                    lblSoXe1.Text = (string)dr["SoXe"];
                }

                //string sqllaixe = " select TenLaiXe from tbl_XeVanChuyen where ID=" + ui_SoXe.SelectedValue.ToString();
                //lbl_Laixe.Text = DBModule.ExecuteQueryForOneResult(sqllaixe, null, null);
            }
            catch
            {
            }
        }

        private void ui_BaiTapket_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlgiacuoc = " select DonGia from tbl_BaiTapKet_GiaCuocVatTu where dotapdung  =( select max(dotapdung) from tbl_BaiTapKet_GiaCuocVatTu) AND BaiTapKetID= " + ui_BaiTapket.SelectedValue.ToString();

            string giacuoc = DBModule.ExecuteQueryForOneResult(sqlgiacuoc, null, null);

            if (giacuoc != "")
            {
                lbl_GiaCuoc.Text = giacuoc;
            }
            else
            {
                lbl_GiaCuoc.Text = "Nhập giá cước cho thôn";

            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            long lSoPhieu = 0;
            try
            {
                string sqlmaxsophieu = "Select Max(SoPhieu) from tbl_XuatVatTu";
                DataSet ds1 = DBModule.ExecuteQuery(sqlmaxsophieu, null, null);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    lSoPhieu = (Int32)ds1.Tables[0].Rows[0][0];
                }
            }
            catch
            { }

            try
            {
                lSoPhieu = lSoPhieu + 1;
                SoPhieu = lSoPhieu.ToString();
                clsXuatVatTu phieuxuat = new clsXuatVatTu();
                phieuxuat.SoPhieu = lSoPhieu;
                phieuxuat.XeID = long.Parse(ui_SoXe.SelectedValue.ToString());
               // phieuxuat.BaiTapKetID = long.Parse(ui_BaiTapket.SelectedValue.ToString());
                phieuxuat.CanBoNongVuID = long.Parse(treeDonVi.SelectedNode.Parent.Name.ToString());
                phieuxuat.VatTuID = long.Parse(uiVatTu.SelectedValue.ToString());
                phieuxuat.Save(null, null);


            }
            catch
            {
                MessageBox.Show("Không tạo được phiếu");

            }
            try
            {
                //clsNhanVatTu vatusophieu = new clsNhanVatTu();
                //foreach (Janus.Windows.GridEX.GridEXRow row in GridEX1.GetCheckedRows())
                //{
                //    if (row.RowType == RowType.Record)
                //    {

                //        vatusophieu.HopDongID = long.Parse(row.Cells["ID"].Value.ToString());
                //        vatusophieu.VuTrongID = MDSolutionApp.VuTrongID;
                //        long MaPhieuID = -1;
                //        string sqlvattusophieu = "Select ID from tbl_XuatVatTu where SoPhieu=" + lSoPhieu.ToString();
                //        DataSet ds2 = DBModule.ExecuteQuery(sqlvattusophieu, null, null);
                //        if (ds2.Tables[0].Rows.Count > 0)
                //        {
                //            MaPhieuID = (Int32)ds2.Tables[0].Rows[0][0];
                //        }
                //        vatusophieu.XuatVatTuID = MaPhieuID;
                //        vatusophieu.NgayNhan = calendarCombo1.Value.Date;
                //        vatusophieu.Save(null, null);
                //    }
                //}
            }
            catch
            {
                //MessageBox.Show("Không tạo được danh sách");
            }

            SoPhieu = lSoPhieu.ToString();
            //frm_LapPhieuVatTu frm = new frm_LapPhieuVatTu(SoPhieu);
            //frm.ShowDialog();

        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {


        }



        private void gridEX2_UpdatingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                string sql_soluongthuc = " UPDATE [dbo].[tbl_NhanVatTu] SET  [SoLuongThuc] = " + gridEX2.GetValue("SoLuongThuc") + " WHERE ID = " + gridEX2.GetValue("ID");
                DBModule.ExecuteNoneBackup(sql_soluongthuc, null, null);
                MessageBox.Show("Đã cập nhật");
                this.gridEX2.Refresh();
            }
            catch { }

        }

        private void uiTab1_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (uiTabPage1.Selected == true)
            {
                CreateDataSourceAndBindGrid();

            }
            if (uiTabPage4.Selected == true)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                string sqlDLVT = @"SELECT        dbo.tbl_DanhMucCanBoNongVu.Ten AS CanBoNongVu, dbo.tbl_Xa.Ten AS TenXa, dbo.tbl_Thon.Ten AS TenThon, dbo.tbl_XuatVatTu.SoPhieu, 
                         dbo.tbl_NhanVatTu.NgayNhan, dbo.tbl_NhanVatTu.SoLuongThuc, dbo.tbl_NhanVatTu.DonGia, dbo.tbl_NhanVatTu.SoTien, dbo.tbl_XeVanChuyen.SoXe, 
                         dbo.tbl_XeVanChuyen.TenLaiXe, dbo.tbl_DanhMucVatTu.Ten AS VatTu, dbo.tbl_HopDong.MaHopDong, dbo.tbl_HopDong.HoTen, 
                         dbo.tbl_NhanVatTu.DonGiaVanChuyen, dbo.tbl_NhanVatTu.TienVanChuyen
FROM            dbo.tbl_XeVanChuyen INNER JOIN
                         dbo.tbl_DanhMucCanBoNongVu INNER JOIN
                         dbo.tbl_NhanVatTu INNER JOIN
                         dbo.tbl_XuatVatTu ON dbo.tbl_NhanVatTu.XuatVatTuID = dbo.tbl_XuatVatTu.ID ON dbo.tbl_DanhMucCanBoNongVu.id = dbo.tbl_XuatVatTu.CanBoNongVuID INNER JOIN
                         dbo.tbl_DanhMucVatTu ON dbo.tbl_XuatVatTu.VatTuID = dbo.tbl_DanhMucVatTu.ID ON dbo.tbl_XeVanChuyen.ID = dbo.tbl_XuatVatTu.XeID INNER JOIN
                         dbo.tbl_Thon INNER JOIN
                         dbo.tbl_HopDong ON dbo.tbl_Thon.ID = dbo.tbl_HopDong.ThonID INNER JOIN
                         dbo.tbl_Xa ON dbo.tbl_Thon.XaID = dbo.tbl_Xa.ID ON dbo.tbl_NhanVatTu.HopDongID = dbo.tbl_HopDong.ID  WHERE dbo.tbl_NhanVatTu.VuTrongID=" + MDSolutionApp.VuTrongID;
                switch (nDonVi.CBNVType)
                {
                    case CBNVType.ThonID: sqlDLVT += " AND (dbo.tbl_Thon.ID =" + nDonVi.CBNVID + ")"; break;
                    case CBNVType.CBNV: sqlDLVT += " AND dbo.tbl_DanhMucCanBoNongVu.id=" + nDonVi.CBNVID; break;
                    default: break;
                }

                DataSet dsvatu = new DataSet();
                dsvatu = DBModule.ExecuteQuery(sqlDLVT, null, null);
                if (dsvatu.Tables[0].Rows.Count >= 0)
                {
                    gridTongHop.DataSource = dsvatu.Tables[0];
                }

            }
            catch
            {

                MessageBox.Show("Không có dữ liệu");
            }



        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            try
            {

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = gridTongHop;
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

        private void btnTimPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlSoPhieu = @"SELECT        dbo.tbl_DanhMucCanBoNongVu.Ten, dbo.tbl_XeVanChuyen.TenLaiXe, dbo.tbl_XeVanChuyen.SoXe, dbo.tbl_XuatVatTu.SoPhieu, dbo.tbl_XuatVatTu.NgayVao
FROM            dbo.tbl_XuatVatTu INNER JOIN
                         dbo.tbl_DanhMucCanBoNongVu ON dbo.tbl_XuatVatTu.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.id LEFT OUTER JOIN
                         dbo.tbl_XeVanChuyen ON dbo.tbl_XuatVatTu.XeID = dbo.tbl_XeVanChuyen.ID  WHERE dbo.tbl_XuatVatTu.SoPhieu=" + txt_lapdanhsach.Text;



                DataSet dsXuat = DBModule.ExecuteQuery(sqlSoPhieu, null, null);

                if (dsXuat.Tables[0].Rows.Count >= 0)
                {
                    DataRow dr = dsXuat.Tables[0].Rows[0];
                    //lblBaiTapKet.Text = (string)dr["TenBai"];
                    lblCBDB.Text = (string)dr["Ten"];

                    if (!DBNull.Value.Equals(dr["SoXe"]) || !DBNull.Value.Equals(dr["TenLaiXe"]))

                    //if (dr["TenLaiXe"] != null || dr["SoXe"] != null || dr["TenLaiXe"].ToString() != null || dr["SoXe"].ToString() != null)
                    {
                        lblLaiXe.Text = (string)dr["TenLaiXe"];
                        lblSoXe.Text = (string)dr["SoXe"];
                    }
                    else {
                        lblLaiXe.Text = "Xe không có trong HĐ";
                        lblSoXe.Text = "Xe không có trong HĐ";
                    
                    }
                    lblSoPhieu.Text = dr["SoPhieu"].ToString();
                    lblNgayCap.Text = dr["NgayVao"].ToString();
                    //XuatVatTuID = long.Parse(dr["ID"].ToString());
                }

            }
            catch
            {
                MessageBox.Show("Không tìm thấy số phiếu");
            }




        }

        private void btl_LapPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                clsNhanVatTu vatusophieu = new clsNhanVatTu();
                foreach (Janus.Windows.GridEX.GridEXRow row in gridEX3.GetCheckedRows())
                {
                    if (row.RowType == RowType.Record)
                    {

                        vatusophieu.HopDongID = long.Parse(row.Cells["ID"].Value.ToString());
                        vatusophieu.VuTrongID = MDSolutionApp.VuTrongID;
                        long MaPhieuID = -1;
                        long TapKetID = -1;
                        long VatTuID = -1;
                        string sqlvattusophieu = "Select ID,BaiTapKetID,VatTuID from tbl_XuatVatTu where SoPhieu=" + txt_lapdanhsach.Text.ToString();
                        DataSet ds2 = DBModule.ExecuteQuery(sqlvattusophieu, null, null);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            MaPhieuID = (Int32)ds2.Tables[0].Rows[0][0];
                            TapKetID = (Int32)ds2.Tables[0].Rows[0][1];
                            VatTuID = (Int32)ds2.Tables[0].Rows[0][2];
                        }
                        string sqldongiavanchuyen = "SELECT DonGia FROM [dbo].[tbl_BaiTapKet_GiaCuocVatTu] where (DotApDung = (SELECT max(DotApDung) FROM tbl_BaiTapKet_GiaCuocVatTu)) AND BaiTapKetID =" + TapKetID.ToString();
                        vatusophieu.DonGiaVanChuyen = decimal.Parse(DBModule.ExecuteQueryForOneResult(sqldongiavanchuyen, null, null));
                        vatusophieu.XuatVatTuID = MaPhieuID;
                        vatusophieu.NgayNhan = calendarCombo1.Value.Date;
                        string sqldongia = @"SELECT        dbo.tbl_GiaVatTu.DonGia
FROM            dbo.tbl_DanhMucVatTu INNER JOIN
                         dbo.tbl_GiaVatTu ON dbo.tbl_DanhMucVatTu.ID = dbo.tbl_GiaVatTu.VatTuID WHERE  dbo.tbl_GiaVatTu.IsActive =1  AND VatTuID = " + VatTuID.ToString();


                        vatusophieu.DonGia = decimal.Parse(DBModule.ExecuteQueryForOneResult(sqldongia, null, null));
                        vatusophieu.BaiTapKetID = TapKetID;
                        vatusophieu.Save(null, null);
                        SoPhieu = txt_lapdanhsach.Text.ToString();

                    }
                }
                //frm_LapPhieuVatTu frm = new frm_LapPhieuVatTu(SoPhieu);
                //frm.ShowDialog();

            }
            catch
            {
                MessageBox.Show("Không tạo được danh sách kiểm tra giá cước bãi tập kết");
            }


        }

        private void btn_timban_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlSoPhieu = @"SELECT        dbo.tbl_XuatVatTu.CanBoNongVuID, dbo.tbl_XuatVatTu.SoPhieu, dbo.tbl_DanhMucCanBoNongVu.Ten, dbo.tbl_HopDongVanChuyen.MaHopDong, 
                         dbo.tbl_XeVanChuyen.TenLaiXe, dbo.tbl_XeVanChuyen.SoXe, dbo.tbl_HopDongVanChuyen.TenChuHopDong, dbo.tbl_XuatVatTu.NgayVao, 
                         dbo.tbl_PhanTramGiaVanChuyen.DonGia
FROM            dbo.tbl_DanhMucVatTu INNER JOIN
                         dbo.tbl_XuatVatTu INNER JOIN
                         dbo.tbl_DanhMucCanBoNongVu ON dbo.tbl_XuatVatTu.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.id ON 
                         dbo.tbl_DanhMucVatTu.ID = dbo.tbl_XuatVatTu.VatTuID INNER JOIN
                         dbo.tbl_BaiTapKetVatTu ON dbo.tbl_XuatVatTu.BaiTapKetID = dbo.tbl_BaiTapKetVatTu.ID INNER JOIN
                         dbo.tbl_BaiTapKet_GiaCuocVatTu ON dbo.tbl_BaiTapKetVatTu.ID = dbo.tbl_BaiTapKet_GiaCuocVatTu.BaiTapKetID INNER JOIN
                         dbo.tbl_GiaVatTu ON dbo.tbl_DanhMucVatTu.ID = dbo.tbl_GiaVatTu.VatTuID INNER JOIN
                         dbo.tbl_PhanTramGiaVanChuyen ON dbo.tbl_DanhMucVatTu.ID = dbo.tbl_PhanTramGiaVanChuyen.VatTuID LEFT OUTER JOIN
                         dbo.tbl_HopDongVanChuyen INNER JOIN
                         dbo.tbl_XeVanChuyen ON dbo.tbl_HopDongVanChuyen.ID = dbo.tbl_XeVanChuyen.HopDongVanChuyenID ON 
                         dbo.tbl_XuatVatTu.XeID = dbo.tbl_XeVanChuyen.ID
WHERE        (dbo.tbl_BaiTapKet_GiaCuocVatTu.DotApDung =
                             (SELECT        MAX(DotApDung) AS Expr1
                               FROM            dbo.tbl_BaiTapKet_GiaCuocVatTu AS tbl_BaiTapKet_GiaCuocVatTu_1)) AND (dbo.tbl_PhanTramGiaVanChuyen.IsActive = 1) AND dbo.tbl_XuatVatTu.SoPhieu=" + txt_sophieuban.Text;
                DataSet dsXuat = DBModule.ExecuteQuery(sqlSoPhieu, null, null);
                if (dsXuat.Tables[0].Rows.Count >= 0)
                {
                    DataRow dr = dsXuat.Tables[0].Rows[0];
                    //lblBaiTapKet.Text = (string)dr["TenBai"];
                    lbl_CBDBban.Text = (string)dr["Ten"];
                    lblSoPhieuban.Text = dr["SoPhieu"].ToString();
                    //lblSoPhieu.Text = dr["SoPhieu"].ToString();
                    if (dr["SoXe"] != null || dr["TenChuHopDong"] != null || dr["TenLaiXe"] != null)
                    {
                        lblSoXeban.Text = (string)dr["SoXe"];
                        lblHopDongVC.Text = (string)dr["TenChuHopDong"];
                        lblLaiXeban.Text = (string)dr["TenLaiXe"];
                    }
                    else {

                        lblSoXeban.Text = "Xe Không có trong hợp đồng";
                        lblHopDongVC.Text = "Xe Không có trong hợp đồng";
                        lblLaiXeban.Text = "Xe Không có trong hợp đồng";
                    
                    }
                    lblNgayCapban.Text = dr["NgayVao"].ToString();
                   
                    CBNVIDBan = dr["CanBoNongVuID"].ToString();
                    //XuatVatTuID = long.Parse(dr["ID"].ToString());
                }
                SoPhieuBan = txt_sophieuban.Text;

            }
            catch
            {
                MessageBox.Show("Không tìm thấy số phiếu");
            }

            loadVatTuThon();
        }

        private void btnCapChoBan_Click(object sender, EventArgs e)
        {
            if (SoPhieuBan != " ")
            {
                string sqlcapnhatban = "SELECT * FROM [MDSONLA].[dbo].[tbl_XuatVatTu] WHERE SoPhieu= " + SoPhieuBan;
                DataSet dscapnhatban;
                dscapnhatban = DBModule.ExecuteQuery(sqlcapnhatban, null, null);

                if (ui_Thon.SelectedValue.ToString() == "Thôn" || ui_Thon.SelectedValue.ToString() == " ")
                {
                    try
                    {
                        clsNhanVatTuThon oVTT = new clsNhanVatTuThon();
                        if (dscapnhatban.Tables[0].Rows.Count >= 0)
                        {
                            DataRow dr = dscapnhatban.Tables[0].Rows[0];
                             oVTT.XuatVatTuID=long.Parse(dr["ID"].ToString());
                            oVTT.VatTuID = long.Parse(dr["VatTuID"].ToString());
                            oVTT.VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                            oVTT.BaiTapKetID = long.Parse(dr["BaiTapKetID"].ToString());
                            string sqlbaitapke = @"SELECT        dbo.tbl_BaiTapKetVatTu.ThonID, dbo.tbl_BaiTapKet_GiaCuocVatTu.DonGia
                                FROM   dbo.tbl_BaiTapKet_GiaCuocVatTu INNER JOIN
                                dbo.tbl_BaiTapKetVatTu ON dbo.tbl_BaiTapKet_GiaCuocVatTu.BaiTapKetID = dbo.tbl_BaiTapKetVatTu.ID
                                WHERE        (dbo.tbl_BaiTapKet_GiaCuocVatTu.DotApDung =
                                (SELECT        MAX(DotApDung) AS Expr1
                               FROM            dbo.tbl_BaiTapKet_GiaCuocVatTu AS tbl_BaiTapKet_GiaCuocVatTu_1)) AND dbo.tbl_BaiTapKetVatTu.ID= " + dr["BaiTapKetID"].ToString();

                            DataSet dsBTK_GC = DBModule.ExecuteQuery(sqlbaitapke, null, null);
                            try
                            {
                                if (dsBTK_GC.Tables[0].Rows.Count >= 0)
                                {
                                    DataRow dr_BTK_GC = dsBTK_GC.Tables[0].Rows[0];
                                    oVTT.ThonID = long.Parse(dr_BTK_GC["ThonID"].ToString());
                                    oVTT.DonGiaVanChuyen = long.Parse(dr_BTK_GC["DonGia"].ToString());
                                }
                            }
                            catch {
                                MessageBox.Show("Chưa có giá cước vận chuyển");
                            }


                            string sqlGiaVatTu = "SELECT  DonGia FROM dbo.tbl_GiaVatTu Where VatTuID= " + dr["VatTuID"].ToString();
                            DataSet dsGia = DBModule.ExecuteQuery(sqlGiaVatTu, null, null);
                            try
                            {
                                if (dsGia.Tables[0].Rows.Count >= 0)
                                {
                                    DataRow drGC = dsGia.Tables[0].Rows[0];
                                    oVTT.DonGia = long.Parse(drGC["DonGia"].ToString());
                                }
                            }
                            catch {
                                MessageBox.Show("Chưa có giá vật tư");
                            }
                 

                            oVTT.BaiTapKetID = long.Parse(dr["BaiTapKetID"].ToString());
                            oVTT.NgayNhan = (DateTime)dr["NgayVao"];
                            oVTT.Save(null, null);
                            MessageBox.Show("Đã cập nhật cho thôn");


                        }
                    }
                    catch { }
                }
                else
                {
                    clsNhanVatTuThon oVTT = new clsNhanVatTuThon();
                    DataRow dr = dscapnhatban.Tables[0].Rows[0];
                    oVTT.XuatVatTuID=long.Parse(dr["ID"].ToString());
                    oVTT.VatTuID = long.Parse(dr["VatTuID"].ToString());
                    oVTT.VuTrongID = long.Parse(dr["VuTrongID"].ToString());
                    oVTT.ThonID = long.Parse(ui_Thon.SelectedValue.ToString());

                    string sqlbaitapke = @"SELECT        dbo.tbl_BaiTapKetVatTu.ID, dbo.tbl_BaiTapKet_GiaCuocVatTu.DonGia
                        FROM            dbo.tbl_BaiTapKet_GiaCuocVatTu INNER JOIN
                         dbo.tbl_BaiTapKetVatTu ON dbo.tbl_BaiTapKet_GiaCuocVatTu.BaiTapKetID = dbo.tbl_BaiTapKetVatTu.ID
                        WHERE        (dbo.tbl_BaiTapKet_GiaCuocVatTu.DotApDung =
                             (SELECT        MAX(DotApDung) AS Expr1
                               FROM            dbo.tbl_BaiTapKet_GiaCuocVatTu AS tbl_BaiTapKet_GiaCuocVatTu_1)) AND dbo.tbl_BaiTapKetVatTu.ThonID =" + ui_Thon.SelectedValue.ToString();

                    DataSet dsBTK_GC = DBModule.ExecuteQuery(sqlbaitapke, null, null);
                    try
                    {
                        if (dsBTK_GC.Tables[0].Rows.Count >= 0)
                        {
                            DataRow dr_BTK_GC = dsBTK_GC.Tables[0].Rows[0];
                            oVTT.BaiTapKetID = long.Parse(dr_BTK_GC["ID"].ToString());
                            oVTT.DonGiaVanChuyen = long.Parse(dr_BTK_GC["DonGia"].ToString());
                        }
                    }
                    catch {
                        MessageBox.Show("Chưa có giá cước vận chuyển");
                    }


                    string sqlGiaVatTu = "SELECT  DonGia FROM dbo.tbl_GiaVatTu Where VatTuID= " + dr["VatTuID"].ToString();
                    DataSet dsGia = DBModule.ExecuteQuery(sqlGiaVatTu, null, null);
                    try
                    {
                        if (dsGia.Tables[0].Rows.Count >= 0)
                        {
                            DataRow drGC = dsGia.Tables[0].Rows[0];
                            oVTT.DonGia = long.Parse(drGC["DonGia"].ToString());
                        }
                    }
                    catch {
                        MessageBox.Show("Chưa có giá vật tư");
                    }
                 

                    oVTT.NgayNhan = (DateTime)dr["NgayVao"];
                    oVTT.Save(null, null);
                    MessageBox.Show("Đã cập nhật cho thôn");

                }
            }
            loadVatTuThon();

        }

        private void gridEXCapBan_UpdatingRecord(object sender, CancelEventArgs e)
        {
            try
            {
                long SoluongThuc = long.Parse(gridEXCapBan.GetValue("SoLuong").ToString());
                float DonGia = float.Parse(gridEXCapBan.GetValue("GiaVatTu").ToString());
                decimal DonGiaVanChuyen = decimal.Parse(gridEXCapBan.GetValue("DonGiaVanChuyen").ToString());
                string sqlupdate = @"UPDATE [dbo].[tbl_NhanVatTuThon]
                                   SET 
                                      [SoLuong] = " + SoluongThuc +
                                      ",[SoTien] = " + SoluongThuc * DonGia +
                                      ",[TienVanChuyen] = " + (SoluongThuc * DonGiaVanChuyen)/1000 +
                                 " WHERE ID = " + long.Parse(gridEXCapBan.GetValue("ID").ToString());
                DBModule.ExecuteNonQuery(sqlupdate, null, null);
                MessageBox.Show("Đã cập nhật");
                loadVatTuThon();
            }
            catch { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create))
                    {
                        Janus.Windows.GridEX.Export.GridEXExporter exporter = new Janus.Windows.GridEX.Export.GridEXExporter();
                        exporter.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        exporter.GridEX = gridEX4;
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

        private void gridEX4_DeletingRecords(object sender, CancelEventArgs e)
        {
            long ID = long.Parse(gridEX4.GetValue("ID").ToString());
            if (ID > 0)
            {
                string sqlxoaphieu = "DELETE FROM [dbo].[tbl_NhanVatTuThon] WHERE ID=" + ID;
                //string sqlxaophueuxuat="DELETE FROM [dbo].[tbl_XuatVatTu] WHERE SoPhieu =" + ;
                DBModule.ExecuteNoneBackup(sqlxoaphieu, null, null);
                MessageBox.Show("Đã xóa dữ liệu thành công!", "Thành công", MessageBoxButtons.OK);
            }
            this.gridEX4.Refresh();

        }

        private void check_XeNgoai_CheckedChanged(object sender, EventArgs e)
        {
            loadXeNgoai();
            if (check_XeNgoai.Checked == true)
            {
                groupBoxXe.Visible = true;
            }
        }
        private void loadDanhSachLap()
        {
            DataSet dslapphieu;
            try
            {
                string sqlDanhSachPhieu = @"SELECT        dbo.tbl_XuatVatTu.ID, dbo.tbl_DanhMucCanBoNongVu.Ten AS CBNV, dbo.tbl_XuatVatTu.SoPhieu, dbo.tbl_XuatVatTu.NgayLapPhieu AS NgayCap, 
                         dbo.tbl_HopDongVanChuyen.MaHopDong AS HopDongVanChuyen, dbo.tbl_XeVanChuyen.SoXe, dbo.tbl_XeVanChuyen.TenLaiXe AS Laixe, 
                         dbo.tbl_BaiTapKetVatTu.TenBai AS BaiTapKet, dbo.tbl_XuatVatTu.SoLuongCap
                         FROM            dbo.tbl_XuatVatTu INNER JOIN
                         dbo.tbl_DanhMucCanBoNongVu ON dbo.tbl_XuatVatTu.CanBoNongVuID = dbo.tbl_DanhMucCanBoNongVu.id INNER JOIN
                         dbo.tbl_BaiTapKetVatTu ON dbo.tbl_XuatVatTu.BaiTapKetID = dbo.tbl_BaiTapKetVatTu.ID LEFT OUTER JOIN
                         dbo.tbl_HopDongVanChuyen INNER JOIN
                         dbo.tbl_XeVanChuyen ON dbo.tbl_HopDongVanChuyen.ID = dbo.tbl_XeVanChuyen.HopDongVanChuyenID ON dbo.tbl_XuatVatTu.XeID = dbo.tbl_XeVanChuyen.ID   ";

                 dslapphieu = DBModule.ExecuteQuery(sqlDanhSachPhieu, null, null);

                 if (dslapphieu.Tables.Count > 0)
                {
                    this.gridEXPhieuCap.SetDataBinding(dslapphieu.Tables[0], "");
                }
            }
            catch { }

        
        }

        private void gridEXPhieuCap_DeletingRecords(object sender, CancelEventArgs e)
        {
            long ID = long.Parse(gridEXPhieuCap.GetValue("ID").ToString());
            if (ID > 0)
            {
                string sqlxoaphieu = "DELETE FROM [dbo].[tbl_XuatVatTu] WHERE ID=" + ID + " AND TongTrongLuong = 0";
                DBModule.ExecuteNoneBackup(sqlxoaphieu, null, null);
                MessageBox.Show("Đã xóa dữ liệu thành công!", "Thành công", MessageBoxButtons.OK);
            }
            else {
                MessageBox.Show("Phiếu đã cân");
            }
            this.gridEX4.Refresh();
        }


        private void gridEXCapBan_RecordUpdated(object sender, EventArgs e)
        {
            try
            {
                long SoluongThuc = long.Parse(gridEXCapBan.GetValue("SoLuongThuc").ToString());
                float DonGia = float.Parse(gridEXCapBan.GetValue("GiaVatTu").ToString());
                decimal DonGiaVanChuyen = decimal.Parse(gridEXCapBan.GetValue("DonGiaVanChuyen").ToString());
                string sqlupdate = @"UPDATE [dbo].[tbl_NhanVatTuThon]
                                   SET 
                                      [SoLuong] = " + SoluongThuc +
                                      ",[SoTien] = " + SoluongThuc * DonGia +
                                      ",[TienVanChuyen] = " + (SoluongThuc * DonGiaVanChuyen) / 1000 +
                                 " WHERE ID = " + long.Parse(gridEXCapBan.GetValue("ID").ToString());
                DBModule.ExecuteNonQuery(sqlupdate, null, null);
                MessageBox.Show("Đã cập nhật");
                loadVatTuThon();
            }
            catch { }
        }

        private void uiComboVuTrong_SelectedIndexChanged(object sender, EventArgs e)
        {
             try
            {
              VuTrongVC= uiComboVuTrong.SelectedValue.ToString();
              loadxevanchuyen();
            }
            catch
            {
            }            

        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            string[] paramNames = new string[] { "@SoPhieu" };
            string[] paraValues = new string[] { lSoPhieu.ToString() };
            CommonClass.ShowReport("ChinhSach\\PhieuNhanVatTu.rpt", "Phiếu cấp vật tư", paramNames, paraValues, null);
        }

        private void uiVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlgiacuocvattu = " select DonGia from tbl_GiaVatTu where IsActive= 1  AND VatTuID= " + uiVatTu.SelectedValue.ToString();

            string giacuoc = DBModule.ExecuteQueryForOneResult(sqlgiacuocvattu, null, null);

            if (giacuoc != "")
            {
                lbl_GiaVatTu.Text = giacuoc;
            }
            else
            {
                lbl_GiaVatTu.Text = "Nhập giá vật tư";

            }
        }


    }
}