using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace MDSolution.MDForms
{
    public partial class frm_ChitietThuHoach : Form
    {        
        public bool Modify = false;
        private long HopDongID = -1;
        private long LenhChatMiaID = -1;
        private long ThuaRuongID = -1;
        private long XuDongID = -1;
        private long TramID = -1;  

        private float SoLuong = -1;
        private string SoThua;
        public frm_ChitietThuHoach(string SoThua)
        {
            InitializeComponent();
            this.SoThua = SoThua;
            LoadData(SoThua);
            //Load_Cb_HDVanChuyen();
            Load_grdData();
            //SLConLai();
           
            //MessageBox.Show("Số CMND đã được khai báo bởi người khác!\nVui lòng kiểm tra lại", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public frm_ChitietThuHoach(string SoThua,DateTime NgayBatDau,DateTime NgayKetThuc)
        {
            InitializeComponent();
            this.SoThua = SoThua;
            this.dtNgayChat.Value = NgayBatDau;
            dtNgayChatDenNgay.Value = NgayKetThuc;
            LoadData(SoThua);
            //Load_Cb_HDVanChuyen();
            Load_grdData();
         
        }
        private void LoadData(string sThuaRuongID)
        {

            clsThuaRuong oThuaRuong = new clsThuaRuong();           
            clsHopDong oHopDong = new clsHopDong();
            clsThon oThon = new clsThon();
            clsBaiTapKet oBaiTapKet = new clsBaiTapKet();
            clsGiongMia oGiongMia = new clsGiongMia();
            clsXa oXa = new clsXa();
            //clsXuDong oXuDong   = new clsXuDong();
            oThuaRuong.ID = long.Parse(sThuaRuongID);
            oThuaRuong.Load( null, null);
            oHopDong.ID = oThuaRuong.HopDongID;
            oHopDong.Load(null,null);

            oThon.ID = oThuaRuong.ThonID;
            oThon.Load(null, null);

            oXa.ID = oThon.XaID;
            oXa.Load(null, null);


            oBaiTapKet.ID = oThuaRuong.BaiTapKetID;
            oBaiTapKet.Load(null, null);

            oGiongMia.ID = oThuaRuong.GiongMiaID;
            oGiongMia.Load(null, null);

            //oXuDong.ID = oThuaRuong.XuDong;
            //oXuDong.Load(null,null);

            HopDongID = oHopDong.ID;
            ThuaRuongID = oThuaRuong.ID;

            lbl_SoPhieu.Text = clsLenhChatMia.GanSoLenh(oThuaRuong.TramNongVuID, null, null);
            lbl_SoHD.Text = oHopDong.MaHopDong;
            lbl_HoTen.Text = oHopDong.HoTen;
            lbl_DiaChi.Text = oThon.Ten + " - " + oXa.Ten;
            //lbl_SoThua.Text = oThuaRuong.ID.ToString();
            decimal dt = oThuaRuong.DienTich;
            lbl_DienTich.Text = dt.ToString("0.00");
            //lbl_CuLy.Text = oBaiTapKet.KhoangCach.ToString();
            lbl_SanLuong.Text = oThuaRuong.SanLuongDuKien.ToString();
            lbl_LoaiGiong.Text = oGiongMia.Ten;
            lbl_XuDong.Text = oBaiTapKet.TenBai;
            // Add SoLuon 
            SoLuong = float.Parse(oThuaRuong.SanLuongDuKien.ToString());

            //TramID = oHDDT.TramID;
            //XuDongID = oXuDong.ID;
        }
       
        public frm_ChitietThuHoach(string SoThua, bool Sua)
        {
            InitializeComponent();
            Modify = Sua;
            
            if (Modify)
            {
                clsThuaRuong objThuaRuong = new clsThuaRuong();
                objThuaRuong.Load(SoThua,null,null);
                //txtMaCHD.Text = objThuaRuong.MaHDDT;
               
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
                    case Keys.Enter:
                        try
                        {
                            SendKeys.Send("{TAB}");
                            //   btGhiNhan_Click(null, null);
                        }
                        catch { }
                        break;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Load_Cb_HDVanChuyen()
        {
            //DataSet ds = null;
            //string strFields = "ID, TenChuHopDong ";
            //string strWhere = "status=1";
            //ds = clsHopDongVanChuyen.GetListbyWhere(strFields, strWhere, "ID", null, null);
            //ds.Tables[0].Rows.Add("0", "----------Chọn-------------");
            //ds.Tables[0].DefaultView.Sort = "ID";
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    cbo_HDVanChuyen.DataSource = ds.Tables[0];
            //    cbo_HDVanChuyen.ValueMember = "ID";
            //    cbo_HDVanChuyen.DisplayMember = "TenChuHopDong";
            //}
            //else
            //{
            //    cbo_HDVanChuyen.DataSource = null;
            //}
        }

        private void Load_Cb_XeVanChuyen()
        {
            long HDVanChuyenID = 0;
            try
            {
               // HDVanChuyenID = long.Parse(cbo_HDVanChuyen.SelectedValue.ToString());
            }
            catch 
            {
                HDVanChuyenID = 0;
            }

            if (HDVanChuyenID > 0)
            {
                //DataSet ds = null;
                //string strFields = "ID, SoXe ";
                //string strWhere = "HopDongVanChuyenID=" + HDVanChuyenID;

                //ds = clsXeVanChuyen.GetListbyWhere(strFields, strWhere, "ID", null, null);
                //ds.Tables[0].Rows.Add("0", "----Chọn----");
                //ds.Tables[0].DefaultView.Sort = "ID";

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    cbo_XeVanChuyen.DataSource = ds.Tables[0];
                //    cbo_XeVanChuyen.ValueMember = "ID";
                //    cbo_XeVanChuyen.DisplayMember = "SoXe";
                //}
                //else
                //{
                //    cbo_XeVanChuyen.DataSource = null;
                //}
            }
            else
            {
                DataSet ds = new DataSet();

                DataTable dt = new DataTable("MyTable");
                dt.Columns.Add(new DataColumn("ID", typeof(int)));
                dt.Columns.Add(new DataColumn("SoXe", typeof(string)));

                DataRow dr = dt.NewRow();
                dr["ID"] = 0;
                dr["SoXe"] = "----Chọn----";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);                
                //cbo_XeVanChuyen.DataSource = ds.Tables[0];
                //cbo_XeVanChuyen.ValueMember = "ID";
                //cbo_XeVanChuyen.DisplayMember = "SoXe";
            }
            
        }
        private void Load_grdData()
        {
            try
            {
                if (ThuaRuongID > 0)
                {
                    DataSet ds = null;
                    string strFields = "ID , SoLenh, NgayChat,SoXe, NgayVanChuyen, SoLuongChat,SoChuyen ";
                    string strWhere = " isnull(is_Sub,0)=0 and ThuaRuongID='" + ThuaRuongID.ToString() + "'";
                    ds = clsLenhChatMia.GetListbyWhere(strFields, strWhere, "SoLenh", null, null);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdData.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        grdData.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc dữ liệu" + ex.ToString(), "Lỗi đọc dữ liệu", MessageBoxButtons.OK);
            }
            

        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {

            try
            {
                if (ValidData())
                {
                    clsLenhChatMia oLenhChatMia = new clsLenhChatMia();
                    oLenhChatMia.ID = LenhChatMiaID;
                    oLenhChatMia.Load(null, null);
                   
                    oLenhChatMia.ThuaRuongID = ThuaRuongID;
                    oLenhChatMia.HopDongID = HopDongID;
                    oLenhChatMia.NgayChat = dtNgayChat.Value;
                    oLenhChatMia.NgayChatDen = dtNgayChatDenNgay.Value;
                    oLenhChatMia.NgayVanChuyen = dtNgayVanChuyen.Value;
                    oLenhChatMia.SoLuongChat = long.Parse(numSoLuong.Value.ToString());
                    oLenhChatMia.SoChuyen = long.Parse(nmChuyen.Value.ToString());
                    oLenhChatMia.TramID = TramID;
                    oLenhChatMia.XuDongID = XuDongID;
                    oLenhChatMia.Created = MDSolutionApp.User.ID;                    
                    oLenhChatMia.DaCan = 0;
                    oLenhChatMia.DaIn = 0;
                    
                    // thong tin van chuyen
                    //oLenhChatMia.NgayVanChuyen = dtNgayVanChuyen.Value;
                    //if (!string.IsNullOrEmpty(cbo_HDVanChuyen.Text))
                    //{
                    //    oLenhChatMia.HDVanChuyenID = long.Parse(cbo_HDVanChuyen.SelectedValue.ToString());
                    //    if (!string.IsNullOrEmpty(cbo_HDVanChuyen.Text))
                    //    {
                    //        oLenhChatMia.XeVanChuyenID = long.Parse(cbo_XeVanChuyen.SelectedValue.ToString());
                    //    }
                    //}                                       
                    //oLenhChatMia.SoXe = cbo_XeVanChuyen.Text;
                    oLenhChatMia.SoLenh = clsLenhChatMia.GanSoLenh(oLenhChatMia.TramID, null, null);
                    if (clsLenhChatMia.CheckSoLenh(MDSolutionApp.VuTrongID, oLenhChatMia.SoLenh, null, null))
                    {
                        oLenhChatMia.Save(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Đã có một lỗi ngoại lệ xảy ra trong việc sinh số phiếu!\nBạn thực hiện lại việc lập phiếu", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    Load_grdData();
                    //SLConLai();
                    clsThuaRuong oThuaRuong = new clsThuaRuong();
                    oThuaRuong.ID = oLenhChatMia.ThuaRuongID;
                    oThuaRuong.Load(null,null);
                    lbl_SoPhieu.Text = clsLenhChatMia.GanSoLenh(oLenhChatMia.TramID, null, null);
                    lbl_SoPhieu.ForeColor = Color.Green;
                    LenhChatMiaID = -1;
                    cmdDelete.Visible = false;
                    MessageBox.Show("Đã ghi dữ liệu thành công!", "Thành công", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi dữ liệu" + ex.ToString(), "Lỗi ghi dữ liệu", MessageBoxButtons.OK);
            }
            
            
        }

        private void cbo_HDVanChuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Cb_XeVanChuyen();
        }
        private void frm_ChitietThuHoach_Load(object sender, EventArgs e)
        {
            dtNgayVanChuyen.Value = dtNgayChat.Value;
            dtNgayChat.Focus();
            dtNgayChat.Select();
          //  dtNgayChatDenNgay.Value = dtNgayChat.Value.AddDays(1);

        }
        
        private float SLConLai()
        {
            float tmp=0, value = 0;
            foreach (Janus.Windows.GridEX.GridEXRow dr in grdData.GetRows())
            {
                tmp = float.Parse(dr.Cells["SoLuongChat"].Value.ToString());
                value += tmp;
            }                        
            value = SoLuong - value;
            lbl_SLConLai.Text = value.ToString();
            return value;
        }

        private void dtNgayChat_ValueChanged(object sender, EventArgs e)
        {
            dtNgayVanChuyen.Value = dtNgayChat.Value ;
            dtNgayChatDenNgay.Value = dtNgayChat.Value;
            TinhTongTLChat();
        }
        private bool ValidData()
        {
            bool isOk = true;

            if (dtNgayVanChuyen.Value.Date < dtNgayChat.Value.Date)
            {
                MessageBox.Show("Ngày vận chuyển phải sau ngày chặt!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                isOk = false;
            }
            if (dtNgayChatDenNgay.Value.Date < dtNgayChat.Value.Date)
            {
                MessageBox.Show("Ngày chặt đến ngày sau ngày chặt tư ngày!", "Lỗi nhập liệu", MessageBoxButtons.OK);
                isOk = false;
            }
            //float soluong = SLConLai() - float.Parse(numSoLuong.Value.ToString());
            //if (Modify)
            //{
            //    float selected_value =0;
            //    try
            //    {
            //        selected_value = float.Parse(grdData.GetValue("SoLuongChat").ToString());
            //    }
            //    catch
            //    {

            //    }
            //    soluong = soluong + selected_value;
            //}
            //if (soluong < 0)
            //{
            //    MessageBox.Show("Số lượng chặt còn lại ít hơn số thiết lập!", "Lỗi nhập liệu", MessageBoxButtons.OK);
            //    isOk = false;
            //}
            return isOk;
        }

       
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                long ID = long.Parse(grdData.GetValue("ID").ToString());
                if (ID > 0)
                {
                    clsLenhChatMia oLenhChatMia = new clsLenhChatMia();
                    oLenhChatMia.ID = ID;
                    oLenhChatMia.Load(null, null);
                    long TramID = oLenhChatMia.TramID;
                    oLenhChatMia.Delete(null, null);

                    // load lai
                    //Load_Cb_HDVanChuyen();
                    //Load_grdData();
                    //

                    LoadData(SoThua);
                    //Load_Cb_HDVanChuyen();
                    Load_grdData();
                    SLConLai();

                    lbl_SoPhieu.Text = clsLenhChatMia.GanSoLenh(TramID, null, null);
                    lbl_SoPhieu.ForeColor = Color.Green;
                    LenhChatMiaID = -1;
                    cmdDelete.Visible = false;
                    MessageBox.Show("Đã xóa dữ liệu thành công!", "Thành công", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa dữ liệu" + ex.ToString(), "Lỗi xóa dữ liệu", MessageBoxButtons.OK);
            }
        }

        private void grdData_Click(object sender, EventArgs e)
        {
            try
            {
                LenhChatMiaID = long.Parse(grdData.GetValue("ID").ToString());
                if (LenhChatMiaID > 0)
                {
                    clsLenhChatMia oLenhChatMia = new clsLenhChatMia();
                    oLenhChatMia.ID = LenhChatMiaID;
                    oLenhChatMia.Load(null, null);
                   
                    lbl_SoPhieu.Text = grdData.GetValue("SoLenh").ToString();
                    if (lbl_SoPhieu.Text.Length < 6)
                    {
                        lbl_SoPhieu.Text = clsLenhChatMia.GanSoLenh(oLenhChatMia.TramID, null, null);
                    }
                    lbl_SoPhieu.ForeColor = Color.Red;

                    dtNgayChat.Value = DateTime.Parse(grdData.GetValue("NgayChat").ToString());
                    dtNgayVanChuyen.Value = DateTime.Parse(grdData.GetValue("NgayVanChuyen").ToString());

                    numSoLuong.Value = decimal.Parse(grdData.GetValue("SoLuongChat").ToString());
                    nmChuyen.Value = decimal.Parse(grdData.GetValue("SoChuyen").ToString());
                   // cbo_HDVanChuyen.SelectedValue = oLenhChatMia.HDVanChuyenID;
                   // cbo_XeVanChuyen.SelectedValue = oLenhChatMia.XeVanChuyenID;
                    cmdDelete.Visible = true;
                    Modify = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc dữ liệu", "Lỗi đọc dữ liệu", MessageBoxButtons.OK);
            }
        }

        private void numSoLuong_ValueChanged(object sender, EventArgs e)
        {
            if (LenhChatMiaID < 0)
            {
                float soluong = SLConLai() - float.Parse(numSoLuong.Value.ToString());
                lbl_SLConLai.Text = soluong.ToString();                              
            }
            

            
        }

        private void cmd_HDVC_Click(object sender, EventArgs e)
        {
            frmHopDongVanChuyen frm = new frmHopDongVanChuyen();
            frm.ShowDialog();
        }

        private void grdData_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {

        }

        private void cmdInPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = null;
                // clsThuaRuong.UpdateKeHoach("", null, null);
                string sql = " Select Distinct * From V_KH_VanChuyen Where MaHopDong ='"+ lbl_SoHD.Text +"' And NgayChat >=" + DBModule.RefineDate(this.dtNgayChat.Value);
                sql = sql + " Order By NgayChat";
                ds = DBModule.ExecuteQuery(sql, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //MDSolution.MDForms.frmShowRP2 frm2 = new MDSolution.MDForms.frmShowRP2();
                    //MDReport.rpt_PhieuBaoDonMia rp = new MDSolution.MDReport.rpt_PhieuBaoDonMia();
                    //rp.SetDataSource(ds.Tables[0]);

                    ////rp.Database.Tables[0].ApplyLogOnInfo(frm2.tblogon);
                    //frm2.RP = rp;
                    //frm2.Show();
                }
                else
                {
                    MessageBox.Show("Không có phiếu trong thời gian đã chọn!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra! Bạn thực hiện lại lệnh In phiếu!", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }  
        }

        private void nmSoLuongChatNgay_ValueChanged(object sender, EventArgs e)
        {
            //TinhTongTLChat();
        }
        void TinhTongTLChat()
        {
           // numSoLuong.Value = nmSoLuongChatNgay.Value * (decimal.Parse((dtNgayChatDenNgay.Value.Date - dtNgayChat.Value.Date).TotalDays.ToString("##0"))+1);
        }

        private void dtNgayChatDenNgay_ValueChanged(object sender, EventArgs e)
        {
           // TinhTongTLChat();
        }

        private void numSoLuong_Enter(object sender, EventArgs e)
        {
            try
            {
                string s = numSoLuong.Value.ToString();
                numSoLuong.Select(0,s.Length);
            }
            catch (Exception ex)
            {
                
                
            }
            
        }

        private void nmChuyen_Enter(object sender, EventArgs e)
        {
            try
            {
                string s = nmChuyen.Value.ToString();
                nmChuyen.Select(0, s.Length);
            }
            catch (Exception ex)
            {


            } 
        }
    }
}