using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms
{
    public partial class frmQuanLyMiaNhap : Form
    {
        private string NhapMiaID = "-1";
        private NodeDonVi nDonVi = new NodeDonVi();
        public frmQuanLyMiaNhap()
        {
            InitializeComponent();
            Load_PhanQuyen_CacTramID();
        }

        private void Load_PhanQuyen_CacTramID()
        {
            string strSQL = "Select CumID From sys_Roles_User_Cum Where UserID=" + MDSolutionApp.User.ID.ToString();
            DataSet ds = DBModule.ExecuteQuery(strSQL, null, null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                        PhanQuyen_CacTramID += ds.Tables[0].Rows[i]["CumID"].ToString();
                    else
                        PhanQuyen_CacTramID += "," + ds.Tables[0].Rows[i]["CumID"].ToString();
                }
            }
        }

        string PhanQuyen_CacTramID = "";
        private void frmQuanLyMiaNhap_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            CommonClass.loadTreeDonVi(tvDonVi,MDSolutionApp.User.ID.ToString());
            foreach (TreeNode n in tvDonVi.Nodes)
            {
                n.Toggle();
            }
            //tvDonVi.SelectedNode
            string[] strArr = MDSolutionApp.User.Roles.Split('&');
            bool BolTrCa = false;
            foreach (string str in strArr)
            {
                if (str == "MNU_TruongCa")
                {
                    BolTrCa = true;
                    break;
                }
            }

            if (BolTrCa == true)
            {
                btEdit.Visible = true;
                button1.Visible = true;
                cmd_NhapKeHoach.Visible = true;
            }
            else
            {
                btEdit.Visible = false;
                button1.Visible = false;
                cmd_NhapKeHoach.Visible = false;
            }
            
            string strSQL = "Select Max(NgayMia) from tbl_ngayMia";
            string strDT = DBModule.ExecuteQueryForOneResult(strSQL, null, null);
            DateTime dt;
            if (strDT != "")
                dt = Convert.ToDateTime(strDT);
            else
                dt = DateTime.Now;
            dtTuNgay.Value = dt;
            load_GV();
            TinhTong();            
        }
        private void tvDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nDonVi = (NodeDonVi)tvDonVi.SelectedNode.Tag;
                if(nDonVi!=null)
                load_GV();
            }
        }

        void load_GV()
        {
            Text = lbDV.Text = nDonVi.DonViName.ToString();
            
            if (nDonVi.Type == DonviType.Root)
            {
                loadRoot();
            }
            if (nDonVi.Type == DonviType.Xa)
            {
                loadXa();
            }
            if (nDonVi.Type == DonviType.Thon)
            {
                loadThon();
            }
            if (nDonVi.Type == DonviType.Cum)
            {
                loadTram();
            }

        }
        string sql;
        
        
        void TaoSTT(DataTable dt1)
        {
            int i = 0;
            dt1.Columns.Add("STT");
            //dt1.Columns.Add("TrongLuongMiaQuaCan");
            foreach (DataRow dr in dt1.Rows)
            {
                i++;
                dr["STT"] = i;
            }
        }
        void ReloadGV(DataTable dtb)
        {
            
            TaoSTT(dtb);
            dgvNhapMia.AutoGenerateColumns = false;
            dgvNhapMia.Columns["SoPhieuNhap"].DataPropertyName = "SoPhieuNhap";
            dgvNhapMia.Columns["MaCan"].DataPropertyName = "MaCan";
            dgvNhapMia.Columns["HoTen"].DataPropertyName = "HoTen";
            dgvNhapMia.Columns["MaHopDong"].DataPropertyName = "MaHopDong";
            //dgvNhapMia.Columns["TenChuHopDong"].DataPropertyName = "TenChuHopDong";
            //dgvNhapMia.Columns["MaHopDongVC"].DataPropertyName = "MaHopDongVC";
            dgvNhapMia.Columns["SoXe"].DataPropertyName = "SoXe";
            dgvNhapMia.Columns["NgayVanChuyen"].DataPropertyName = "NgayVanChuyen";
            dgvNhapMia.Columns["GioNhap"].DataPropertyName = "GioNhap";
            dgvNhapMia.Columns["NgayRa"].DataPropertyName = "NgayRa";
            dgvNhapMia.Columns["GioRa"].DataPropertyName = "GioRa";
            dgvNhapMia.Columns["TongTrongLuong"].DataPropertyName = "TongTrongLuong";
            dgvNhapMia.Columns["TrongLuongXe"].DataPropertyName = "TrongLuongXe";
            dgvNhapMia.Columns["TrongLuongMiaQC"].DataPropertyName = "TrongLuongMiaQC";
            dgvNhapMia.Columns["TyLeTapVat"].DataPropertyName = "TyLeTapVat";
            dgvNhapMia.Columns["TrongLuongTapVat"].DataPropertyName = "TrongLuongTapVat";
            dgvNhapMia.Columns["TrongLuongMiaSach"].DataPropertyName = "TrongLuongMiaSach";
            dgvNhapMia.Columns["TienMia"].DataPropertyName = "TienMia";
            dgvNhapMia.Columns["IID"].DataPropertyName = "ID";
            dgvNhapMia.Columns["ID"].DataPropertyName = "ID";

            dgvNhapMia.Columns["Tram"].DataPropertyName = "Tram";
            dgvNhapMia.Columns["Xa"].DataPropertyName = "TenXa";
            dgvNhapMia.Columns["LoaiGiong"].DataPropertyName = "GiongMia";
            dgvNhapMia.Columns["GiaMia"].DataPropertyName = "DonGiaMia";
            dgvNhapMia.Columns["SoBanDieuTra"].DataPropertyName = "SoBanDieuTra";
            dgvNhapMia.Columns["TiLeCanGhep"].DataPropertyName = "TiLeCanGhep";
            dgvNhapMia.Columns["PhatHD"].DataPropertyName = "PhatHD";
            dgvNhapMia.Columns["LyDoPhat"].DataPropertyName = "LyDoPhat";
            dgvNhapMia.Columns["BaiBocXep"].DataPropertyName = "TenBai";

            if(dgvNhapMia.Rows.Count>0)
            dgvNhapMia.Rows.RemoveAt(0);
            NhapMiaID = "-1";
            dgvNhapMia.DataSource =dtb;
            dgvNhapMia.Show();
            
            TinhTong();
        }
        void TinhTong()
        {
            double TongTL = 0;
            double TLXe = 0;
            double TLMia = 0;
            double TLMiaSach = 0;
            double TLTapVat = 0;
            double ThanhTien = 0;
            int tong_xe = 0;
            string MaCan = "";
            foreach (DataGridViewRow dr in dgvNhapMia.Rows)
            {
                //lbThanhTien.Text = dr.Cells[10].ToString();
                TongTL += double.Parse(dr.Cells["TongTrongLuong"].Value.ToString());
                TLXe += double.Parse(dr.Cells["TrongLuongXe"].Value.ToString());
                TLMia += double.Parse(dr.Cells["TrongLuongMiaQC"].Value.ToString());
                TLMiaSach += double.Parse(dr.Cells["TrongLuongMiaSach"].Value.ToString());
                TLTapVat += double.Parse(dr.Cells["TrongLuongTapVat"].Value.ToString());
                ThanhTien += double.Parse(dr.Cells["TienMia"].Value.ToString());
                if (MaCan != dr.Cells["MaCan"].Value.ToString())
                {
                    tong_xe++;
                    MaCan = dr.Cells["MaCan"].Value.ToString();
                }
            }
            lbThanhTien.Text = ThanhTien.ToString("# ### ### ##0");
            lbTlMia.Text = TLMia.ToString("# ### ### ##0");
            lbTLMiaSach.Text = TLMiaSach.ToString("# ### ### ##0");
            lbTLTapVat.Text = TLTapVat.ToString("# ### ### ##0");
            lbTongTL.Text = TongTL.ToString("# ### ### ##0");
            lbTongTLXe.Text = TLXe.ToString("# ### ### ##0");
            lbl_tongxe.Text = tong_xe.ToString();
        }
        void loadRoot()
        {
            DateTime dt = dtTuNgay.Value;
            string Ngay = dt.ToString("yyyy-MM-dd");
            sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolutionApp.VuTrongID.ToString();
            
            if(chkChonNgay.Checked==true)
            {
                sql += " and NgayMia >='" + Ngay + " 00:00:00' AND NgayMia <='" + Ngay + " 23:59:59'";
            }

            if (check_canbi.Checked)
            {
                sql += " and (TrongLuongXe >0)";
            }

            if (PhanQuyen_CacTramID != "")
            {
                sql += " And CumID in(" + PhanQuyen_CacTramID + ")";
            }

            sql += " Order by SoPhieuNhap";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            ReloadGV(ds.Tables[0]);
            //TinhTong();
        }

        void loadThon()
        {
            DateTime dt = dtTuNgay.Value;
            string Ngay = dt.ToString("yyyy-MM-dd");
            sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " and ThonID=" + nDonVi.DonViID.ToString();
            if (chkChonNgay.Checked == true)
            {
                sql += " and NgayMia >='" + Ngay + " 00:00:00' AND NgayMia <='" + Ngay + " 23:59:59'";
            }
            if (check_canbi.Checked)
            {
                sql += " and (TrongLuongXe >0)";
            }
            sql += " Order by SoPhieuNhap";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            ReloadGV(ds.Tables[0]);
            
        }

        void loadXa()
        {
            DateTime dt = dtTuNgay.Value;
            string Ngay = dt.ToString("yyyy-MM-dd");
            sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " and XaID=" + nDonVi.DonViID.ToString();
            if (chkChonNgay.Checked == true)
            {
                sql += " and NgayMia >='" + Ngay + " 00:00:00' AND NgayMia <='" + Ngay + " 23:59:59'";
            }
            if (check_canbi.Checked)
            {
                sql += " and (TrongLuongXe >0)";
            }
            sql += " Order by SoPhieuNhap";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            ReloadGV(ds.Tables[0]);
            
        }

        void loadTram()
        {
            DateTime dt = dtTuNgay.Value;
            string Ngay = dt.ToString("yyyy-MM-dd");
            sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " and CumID=" + nDonVi.DonViID.ToString();
            if (chkChonNgay.Checked == true)
            {
                sql += " and NgayMia >='" + Ngay + " 00:00:00' AND NgayMia <='" + Ngay + " 23:59:59'";
            }
            if (check_canbi.Checked)
            {
                sql += " and (TrongLuongXe >0)";
            }
            sql += " Order by SoPhieuNhap";
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            ReloadGV(ds.Tables[0]);
        }
        

        private void tvDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
            //MessageBox.Show("dclick");
            if (tvDonVi.SelectedNode != null)
            {
                nDonVi = (NodeDonVi)tvDonVi.SelectedNode.Tag;

                load_GV();
            }
        }

        private void dgvNhapMia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.RowIndex.ToString());

            //if (e.RowIndex > -1)
            //{
            //    frmShowRP2 frm = new frmShowRP2();
            //    MDReport.rp_PhieuNhapMia rp = new MDReport.rp_PhieuNhapMia();
            //    rp.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
            //    rp.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            //    rp.RecordSelectionFormula = "{V_VanChuyenMia.ID}=" + dgvNhapMia.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            //    rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            //    frm.RP = rp;
            //    frm.RPtitle = "Phiếu nhập mía";
            //    frm.Show();
            //}
        }

        private void cmdIn_Click(object sender, EventArgs e)
        {
            if (dgvNhapMia.Rows.Count > 0)
            {
                //LD.MD2008.MDForms.frmShowRP2 frm = new LD.MD2008.MDForms.frmShowRP2();
                frmShowRP2 frm = new frmShowRP2();
                //if (nDonVi.Type == DonviType.Thon)
                //{
                //    MDReport.rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXeThon rp = new MDReport.rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXeThon();
                //    frm.RP = rp;
                //    //frm.ParameterOn = 1;
                //    //frm.VuTrongIDName = "{View_KetQuaCanNhapMiaNguyenLieuXe.VuTrongID}";
                //    //frm.NgayLocName = "{View_KetQuaCanNhapMiaNguyenLieuXe.NgayVanChuyen}";
                //    DataTable dt = (DataTable)dgvNhapMia.DataSource;
                //    rp.DataDefinition.FormulaFields["DonVi"].Text ="'"+ nDonVi.DonViName.ToString()+"'";
                //    if (chkChonNgay.Checked == true)
                //        rp.DataDefinition.FormulaFields["NgayThang"].Text = "'" + dtTuNgay.Value.ToString("dd/MM/yyyy") + "'";
                //    //MessageBox.Show(dt.Rows[0][0].ToString());
                //    rp.Database.Tables[0].SetDataSource(dt);
                //    rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                //}
                //else
                {
                    MDReport.rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXeVung rp = new MDReport.rp_BaoCaoKetQuaCanNhapMiaNguyenLieuXeVung();
                    frm.RP = rp;
                    //frm.ParameterOn = 1;
                    //frm.VuTrongIDName = "{View_KetQuaCanNhapMiaNguyenLieuXe.VuTrongID}";
                    //frm.NgayLocName = "{View_KetQuaCanNhapMiaNguyenLieuXe.NgayVanChuyen}";
                    DataTable dt = (DataTable)dgvNhapMia.DataSource;
                    if(nDonVi.Type==DonviType.Xa)
                    rp.DataDefinition.FormulaFields["DonVi"].Text = "'" + nDonVi.DonViName.ToString() + "'";
                    else
                    rp.DataDefinition.FormulaFields["DonVi"].Text = "'TOÀN VÙNG NGUYÊN LIỆU'";
                    if (chkChonNgay.Checked == true)
                        rp.DataDefinition.FormulaFields["NgayThang"].Text = "'" + dtTuNgay.Value.ToString("dd/MM/yyyy") + "'";
                    //MessageBox.Show(dt.Rows[0][0].ToString());
                    rp.Database.Tables[0].SetDataSource(dt);
                    rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                }
                //frm.TrongNgay = 1;
                frm.RPtitle = "Kết quả nhập mía "+nDonVi.DonViName.ToString();
                //frm.MdiParent = this;
                frm.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tvDonVi.SelectedNode != null)
            {
                nDonVi = (NodeDonVi)tvDonVi.SelectedNode.Tag;
                if (nDonVi != null)
                    load_GV();
            }
        }

        private void dgvNhapMia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_sophieu_TextChanged(object sender, EventArgs e)
        {
            DateTime dt = dtTuNgay.Value;
            string Ngay = dt.ToString("yyyy-MM-dd");
            sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolutionApp.VuTrongID.ToString();

            switch (nDonVi.Type)
            { 
                case DonviType.Thon:
                    sql += " and ThonID=" + nDonVi.DonViID.ToString();
                    break;
                case DonviType.Xa:
                    sql += " and XaID=" + nDonVi.DonViID.ToString();
                    break;
                case DonviType.Cum:
                    sql += " And CumID =" + nDonVi.DonViID.ToString();
                    break;
                default:
                    if (PhanQuyen_CacTramID != "")
                    {
                        sql += " And CumID in (" + PhanQuyen_CacTramID + ")";
                    }
                    break;
            }

            if (chkChonNgay.Checked == true)
            {
                sql += " and NgayMia >='" + Ngay + " 00:00:00' AND ngayMia <='" + Ngay + " 23:59:59'";
            }
           long sophieu = 0;
           if (SoPhieuRB.Checked == true)
           {
               if ((txt_sophieu.Text != "") && (txt_sophieu.Text != null))
               {
                   try
                   {
                       sophieu = long.Parse(txt_sophieu.Text);
                   }
                   catch
                   {
                       sophieu = 0;
                   }
               }
               if (sophieu > 0)
               {
                   sql += " and SoPhieuNhap like '" + sophieu.ToString() + "%'";
               }
           }
           else if(ChuHDRB.Checked == true) // tim theo chu hd
           {
               if ((txt_sophieu.Text != "") && (txt_sophieu.Text != null))
               {
                   sql += " And MaHopDong like '" + txt_sophieu.Text.Trim() + "%' OR HoTen Like N'%" + txt_sophieu.Text + "%'";
               }
           }
           else // tìm theo số bản điều tra.
           {
               if ((txt_sophieu.Text != "") && (txt_sophieu.Text != null))
               {
                   sql += " And SoBanDieuTra like '" + txt_sophieu.Text + "%'";
               }
           }
           if (check_canbi.Checked)
           {
               sql += " and (TrongLuongXe >0)";
           }
           DataSet ds = DBModule.ExecuteQuery(sql, null, null);
           ReloadGV(ds.Tables[0]);
        }

        private void check_canbi_CheckedChanged(object sender, EventArgs e)
        {
            LoadGVbySoPhieu();
        }
        void LoadGVbySoPhieu()
        {
            //DateTime dt = dtTuNgay.Value;
            //string Ngay = dt.ToString("yyyy-MM-dd");
            //sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolutionApp.VuTrongID.ToString();

            //switch (nDonVi.Type)
            //{
            //    case DonviType.Thon:
            //        sql += " and ThonID=" + nDonVi.DonViID.ToString();
            //        break;
            //    case DonviType.Xa:
            //        sql += "and XaID=" + nDonVi.DonViID.ToString();
            //        break;
            //    default:
            //        break;
            //}

            //if (chkChonNgay.Checked == true)
            //{
            //    sql += " and ngayvanchuyen >'" + Ngay + " 00:00:00' AND ngayvanchuyen <'" + Ngay + " 23:59:59'";
            //}
            //long sophieu = 0;

            //if ((txt_sophieu.Text != "") && (txt_sophieu.Text != null))
            //{

            //    try
            //    {
            //        sophieu = long.Parse(txt_sophieu.Text);
            //    }
            //    catch
            //    {
            //        sophieu = 0;
            //    }
            //}
            //if (sophieu > 0)
            //{
            //    sql += " and SoPhieuNhap like '" + sophieu.ToString() + "%'";
            //}
            //if (check_canbi.Checked)
            //{
            //    sql += " and (TrongLuongXe >0)";
            //}
            //DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            //ReloadGV(ds.Tables[0]);
            DateTime dt = dtTuNgay.Value;
            string Ngay = dt.ToString("yyyy-MM-dd");
            sql = "SELECT * FROM View_KetQuaCanNhapMiaNguyenLieuXe where VuTrongID=" + MDSolutionApp.VuTrongID.ToString();

            switch (nDonVi.Type)
            {
                case DonviType.Thon:
                    sql += " and ThonID=" + nDonVi.DonViID.ToString();
                    break;
                case DonviType.Xa:
                    sql += " and XaID=" + nDonVi.DonViID.ToString();
                    break;
                case DonviType.Cum:
                    sql += " And CumID =" + nDonVi.DonViID.ToString();
                    break;
                default:
                    if (PhanQuyen_CacTramID != "")
                    {
                        sql += " And CumID in (" + PhanQuyen_CacTramID + ")";
                    }
                    break;
            }

            if (chkChonNgay.Checked == true)
            {
                sql += " and NgayMia >='" + Ngay + " 00:00:00' AND ngayMia <='" + Ngay + " 23:59:59'";
            }
            long sophieu = 0;
            if (SoPhieuRB.Checked == true)
            {
                if ((txt_sophieu.Text != "") && (txt_sophieu.Text != null))
                {
                    try
                    {
                        sophieu = long.Parse(txt_sophieu.Text);
                    }
                    catch
                    {
                        sophieu = 0;
                    }
                }
                if (sophieu > 0)
                {
                    sql += " and SoPhieuNhap like '" + sophieu.ToString() + "%'";
                }
            }
            else if (ChuHDRB.Checked == true) // tim theo chu hd
            {
                if ((txt_sophieu.Text != "") && (txt_sophieu.Text != null))
                {
                    sql += " And MaHopDong like '" + txt_sophieu.Text.Trim() + "%' OR HoTen Like N'%" + txt_sophieu.Text + "%'";
                }
            }
            else // tìm theo số bản điều tra.
            {
                if ((txt_sophieu.Text != "") && (txt_sophieu.Text != null))
                {
                    sql += " And SoBanDieuTra like '" + txt_sophieu.Text + "%'";
                }
            }
            if (check_canbi.Checked)
            {
                sql += " and (TrongLuongXe >0)";
            }
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            ReloadGV(ds.Tables[0]);
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (NhapMiaID != "-1")
            {
                if (Chek_DaThanhToan(dgvNhapMia.SelectedRows[0].Cells["ID"].Value.ToString()))
                { }
                else
                {
                    MessageBox.Show("Số phiếu này đã đc thanh toán! Bạn không thể sửa được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (chek_NgayMia_Hientai(dgvNhapMia.SelectedRows[0].Cells["ID"].Value.ToString()))
                { 
                }
                else
                {
                    if (Chek_ThanhToan())
                    { }
                    else
                    {
                        MessageBox.Show("Chỉ có người thanh toán mới có thể sửa số phiếu trong ngày khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                //MessageBox.Show(NhapMiaID);
                //MDForms.frmEdit_tbl_NhapMia frm = new LD.MD2008.MDForms.frmEdit_tbl_NhapMia();
                frmEdit_tbl_NhapMia frm = new frmEdit_tbl_NhapMia();
                frm.ID = NhapMiaID;
                frm.ShowDialog();
                if (frm.OK == 1)
                {
                    LoadGVbySoPhieu();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn phiếu cần sửa", "Thông báo");
            }
        }

        private bool chek_NgayMia_Hientai(string _IDNhapMia)
        {
            string sql = "Select NgayMia From tbl_NhapMia Where ID =" + _IDNhapMia;
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["NgayMia"].ToString());
            sql = "Select Max(NgayMia) as NgayMia From tbl_NgayMia";
            ds = DBModule.ExecuteQuery(sql, null, null);
            DateTime dt2 = Convert.ToDateTime(ds.Tables[0].Rows[0]["NgayMia"].ToString());
            if (dt != dt2)
                return false;
            else
                return true;
        }

        private bool Chek_DaThanhToan(string _IDNhapMia)
        {
            string sql = "Select DaThanhToan From tbl_NhapMia Where ID=" + _IDNhapMia;
            sql = DBModule.ExecuteQueryForOneResult(sql, null, null);

            if (string.IsNullOrEmpty(sql) || sql == "0")
                return true;
            else
                return false;
        }
        
        private void dgvNhapMia_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
            NhapMiaID = dgvNhapMia.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MDForms.frm_DatNgayMia = new LD.MD2008.MDForms.frm_DatNgayMia();
            frm_DatNgayMia frm = new frm_DatNgayMia();
            frm.ShowDialog();
        }

        private void cmd_NhapKeHoach_Click(object sender, EventArgs e)
        {
            //MDForms.frmNhapLuongMiaKeHoachNgay frm = new LD.MD2008.MDForms.frmNhapLuongMiaKeHoachNgay();
            frmNhapLuongMiaKeHoachNgay frm = new frmNhapLuongMiaKeHoachNgay();
            frm.ShowDialog();
        }

        private void SoPhieuRB_CheckedChanged(object sender, EventArgs e)
        {
            if (SoPhieuRB.Checked == true)
                txt_sophieu.Focus();
        }

        private void ChuHDRB_CheckedChanged(object sender, EventArgs e)
        {
            if (ChuHDRB.Checked == true)
                txt_sophieu.Focus();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                txt_sophieu.Focus();
        }

        private void txt_sophieu_Enter(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            text.BackColor = Color.SkyBlue;
        }

        private void txt_sophieu_Leave(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            text.BackColor = Color.White;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Delete:
                        try
                        {
                            //SendKeys.Send("{TAB}");                           
                            XoaSoPhieu();
                        }
                        catch { }
                        break;

                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool Chek_ThanhToan()
        {
            string[] strArr = MDSolutionApp.User.Roles.Split('&');
            bool BolTrCa = false;
            foreach (string str in strArr)
            {
                if (str.ToLower() == "mnu_thanhtoan")
                {
                    BolTrCa = true;
                    break;
                }
                //string a = str.ToLower();
            }
            return BolTrCa;
        }

        private bool Chek_TruongCa()
        {
            string[] strArr = MDSolutionApp.User.Roles.Split('&');
            bool BolTrCa = false;
            foreach (string str in strArr)
            {
                if (str == "MNU_TruongCa")
                {
                    BolTrCa = true;
                    break;
                }
            }
            return BolTrCa;
        }

        private void XoaSoPhieu()
        {
            
            if (Chek_ThanhToan())
            { }
            else
            {
                if (Chek_TruongCa())
                { }
                else
                {
                    MessageBox.Show("Chỉ có trưởng ca hoặc người thanh toán mới được phép xoá số phiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            try
            {
                if (Chek_DaThanhToan(dgvNhapMia.SelectedRows[0].Cells["ID"].Value.ToString()))
                { }
                else
                {
                    MessageBox.Show("Số phiếu này đã được thanh toán! Bạn không thể xoá được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Bạn muốn xoá số phiếu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string sql = "Select ID From tbl_NhapMia Where MaCan =" + dgvNhapMia.SelectedRows[0].Cells["MaCan"].Value.ToString() + " And NgayMia = (Select NgayMia From tbl_NhapMia Where ID =" + dgvNhapMia.SelectedRows[0].Cells["ID"].Value.ToString() + ")";
                    DataSet ds = DBModule.ExecuteQuery(sql, null, null);
                    if (ds.Tables[0].Rows.Count > 1)
                    {
                        if (MessageBox.Show("Đây là số phiếu được cân ghép.Nếu bạn xoá số phiếu này thì các số phiếu cân cùng xe cũng sẽ bị xoá!\nBạn có muốn tiếp tục?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            sql = "";
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                sql += " Delete From tbl_NhapMia Where ID = " + dr["ID"].ToString();
                            }
                            DBModule.ExecuteNonQuery(sql, null, null);
                            LoadGVbySoPhieu();
                        }
                    }
                    else
                    {
                        sql = "Delete From tbl_NhapMia Where ID =" + ds.Tables[0].Rows[0]["ID"].ToString();
                        DBModule.ExecuteNonQuery(sql, null, null);
                        LoadGVbySoPhieu();
                    }
                    //LoadGVbySoPhieu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Bạn phải chọn 1 số phiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}