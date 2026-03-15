using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.OleDb;

//using SerialPortTerminal.Properties;

namespace MDSolution
{
    public partial class frmNhapMia : Form
    {
        # region Local Variables
        private SerialPort comport = new SerialPort();
        bool kieu_can = true; // Can xe mia; can bi xe
        string VuTrongID = MDSolutionApp.VuTrongID.ToString();
        long TongTL = 0;
        #endregion

        # region Public Variables
        public  string MaKVC = "";
        public  string MaKhach = "";
        public  long KhoiLuongCanGep = 0; // Khoi luong can ghep
        public  long SoHDCanGhep = 0;
        public  long MaCanID = -1; // Ma can #-1 neu la can bi xe
        public string SoXe = "";
        # endregion

        public frmNhapMia()
        {
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {

            if (comport.IsOpen) comport.Close();

            base.OnClosed(e);
        }

        private void frmNhapMia_Load(object sender, EventArgs e)
        {
         

            // Dat ngay gio nhap mia

            lblNgayNhap.Text = "Ngày nhập:" + DateTime.Now.Day +"/"+ DateTime.Now.Month +"/"+ DateTime.Now.Year+ " ";
            lblGioNhap.Text = "Giờ nhập:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + " ";

            //Load Gia Mia
            load_cbo_gianhapmia("0", VuTrongID);

            try
            {
                if (comport.IsOpen) comport.Close();
                else
                {
                    // Set the port's settings
                    comport.BaudRate = 4800;
                    comport.DataBits = 7;
                    comport.StopBits = StopBits.One;
                    comport.Parity = Parity.Even;
                    comport.PortName = "COM1";
                    // Open the port
                    comport.Open();
                }
            }
            catch
            {
                MessageBox.Show("Không thể kết nối tới thiết bị cân","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            if (kieu_can)
            {
                InitControl("Cân mía");
            }
            else
            {
                InitControl("Cân bì");
            }

            cmdXeChuaCan.Text = XeChuaCanBi().ToString() + "-Thiếu bì(F4)";
        }

       
        # region User Function
        // Load bai tap ket ID
        private void load_cbo_baibocxep(string SelectedID, string ThonID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("TEN");
            DataSet ds = null;
            string[] strInits = new string[] { "0", "--Chọn--" };
            dt.Rows.Add(strInits);
            ds = clsBaiTapKet.GetListbyWhere("ID,TenBai", "ThonID=" + ThonID, "TenBai", null, null);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string strID = dr["ID"].ToString();
                string strTEN = dr["TenBai"].ToString();
                string[] strValues = new string[] { strID, strTEN };
                dt.Rows.Add(strValues);
            }
            cboBaiBocXep.DataSource = dt;
            cboBaiBocXep.SelectedValue = SelectedID;

        }
        //End  Load bai tap ket ID
        // Load gia nhap mia
        private void load_cbo_gianhapmia(string SelectedID, string VuTrongID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("TEN");
            DataSet ds = null;
            string[] strInits = new string[] { "0", "--Chọn--" };
            dt.Rows.Add(strInits);
            ds = clsGiaNhapMia.GetListbyWhere("ID,DonGia", "VuTrongID=" + VuTrongID, "DonGia", null, null);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string strID = dr["ID"].ToString();
                string strTEN = dr["DonGia"].ToString();
                string[] strValues = new string[] { strID, strTEN };
                dt.Rows.Add(strValues);
            }
            cboGiaMia.DataSource = dt;
            //cboGiaMia.SelectedValue = SelectedID;
            cboGiaMia.Text = SelectedID;
            //cboGiaMia.SelectedText = SelectedID;

        }
        //End  Load gia nhap mia
        
        // Load xe van chuyen
        private void load_cbo_xe(string SelectedID, string HopDongCVCID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("TEN");
            DataSet ds = null;
            string[] strInits = new string[] { "0", "--Chọn--" };
            dt.Rows.Add(strInits);
            ds = clsXeVanChuyen.GetListbyWhere("ID, SoXe", "HopDongVanChuyenID=" + HopDongCVCID, "", null, null);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string strID = dr["ID"].ToString();
                string strTEN = dr["SoXe"].ToString().ToUpper();
                string[] strValues = new string[] { strID, strTEN };
                dt.Rows.Add(strValues);
            }
            cboSoXe.ValueMember = "ID";
            cboSoXe.DisplayMember = "SoXe";
            cboSoXe.DataSource = dt;
            cboSoXe.SelectedValue = SelectedID;

        }
        
       
        //End  Load gia nhap mia
        private void Get_KhachVanChuyen(string MaKVC)
        {
            if (MaKVC != "")
            {
                clsHopDongVanChuyen objHDVC = new clsHopDongVanChuyen();
                objHDVC.Load(MaKVC, null, null);
                if (objHDVC.ID > 0)
                {
                    txtHoTenKHVC.Text = clsComFunctions.HoTen_Format(objHDVC.TenChuHopDong);
                    txtMaKhachVC.Text = objHDVC.ID.ToString();

                    load_cbo_xe("0", objHDVC.ID.ToString());
                }
                else
                {
                    txtHoTenKHVC.Text = "";
                    txtMaKhachVC.Text = "";
                    DataSet ds = null;
                    cboSoXe.DataSource = ds;
                }

            }
        }
        private void Get_KhachVanChuyen_ByID(string MaKVC)
        {
            if (MaKVC != "")
            {
                clsHopDongVanChuyen objHDVC = new clsHopDongVanChuyen(long.Parse(MaKVC));
                objHDVC.Load(null, null);
                if (objHDVC.ID > 0)
                {
                    txtHoTenKHVC.Text = clsComFunctions.HoTen_Format(objHDVC.TenChuHopDong);
                    txtMaKhachVC.Text = objHDVC.ID.ToString();
                    txtHopDongVC.Text = objHDVC.MaHopDong;
                    load_cbo_xe("0", objHDVC.ID.ToString());
                }
                else
                {
                    txtHoTenKHVC.Text = "";
                    txtMaKhachVC.Text = "";
                    DataSet ds = null;
                    cboSoXe.DataSource = ds;
                }

            }
        }
        private void Get_Khach(string MaKhach)
        {
            if (MaKhach != "")
            {
                clsHopDong objHD = new clsHopDong();
                objHD.Load(MaKhach, null, null);
                if (objHD.ID > 0)
                {
                    txtMaKhach.Text = objHD.ID.ToString();
                    txtHoTen.Text = clsComFunctions.HoTen_Format(objHD.HoTen);

                    //Load CBO Bai boc xep
                    load_cbo_baibocxep("0", objHD.ThonID.ToString());

                }
                else
                {
                    txtMaKhach.Text = "";
                    txtHoTen.Text = "";
                }
            }
        }
        // 
        private void Get_Khach_By_ID(string MaKhach)
        {
            if (MaKhach != "")
            {
                clsHopDong objHD = new clsHopDong(long.Parse(MaKhach));
                objHD.Load(null, null);
                if (objHD.ID > 0)
                {
                    txtMaKhach.Text = objHD.ID.ToString();
                    txtHoTen.Text = clsComFunctions.HoTen_Format(objHD.HoTen);
                    txtSoHopDong.Text = objHD.MaHopDong;
                    //Load CBO Bai boc xep
                    load_cbo_baibocxep("0", objHD.ThonID.ToString());

                }
                else
                {
                    txtMaKhach.Text = "";
                    txtHoTen.Text = "";
                }
            }
        }

        private void Tinh_Toan()
        {
            // Trong luong xe cho mia
            long TongTrongLuong = 0;
            if (txtCanMia.Text != "")
            {
                try
                {
                    TongTrongLuong = long.Parse(txtCanMia.Text);
                }
                catch
                {
                    TongTrongLuong = 0;
                }
            }
            // Trong luong xe
            long TrongLuongXe = 0;
            if (txtCanXe.Text != "")
            {
                try
                {
                    TrongLuongXe = long.Parse(txtCanXe.Text);
                }
                catch
                {
                    TrongLuongXe = 0;
                }
            }
            if (TongTrongLuong-TrongLuongXe  <0)
            {
                MessageBox.Show("Kiểm tra lại trọng lượng cân ghép hoặc cân bì", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // trong luong qua can
                long TrongLuongCan = TongTrongLuong - TrongLuongXe;
                txtTrongLuongCan.Text = TrongLuongCan.ToString();

                double TiLeTapVat = 0;
                try
                {
                    TiLeTapVat = double.Parse(txtTiLeTapVat.Text);
                }
                catch
                {
                    TiLeTapVat = 0;
                }
                double TLTapVat = Math.Round(TrongLuongCan * TiLeTapVat / 100);
                txtTrongLuongTapVat.Text = TLTapVat.ToString();
                
                if (txtTrongLuongTapVat.Text != "")
                {
                    long TrongLuongTapVat =0;
                    try
                    {
                        TrongLuongTapVat = long.Parse(txtTrongLuongTapVat.Text);
                    }
                    catch
                    {
                        TrongLuongTapVat = 0;
                    }

                    long TrongLuongMia = TrongLuongCan - TrongLuongTapVat;
                    try
                    {
                        txtTrongLuongMia.Text = TrongLuongMia.ToString();
                    }
                    catch 
                    { 
                       // txtTrongLuongMia.Text = "0"; 
                    }
                }
            }
        }

        private bool Check_Error(int Type)
        {
            string strError = "";

            if ((cboBaiBocXep.SelectedValue==null) || (cboBaiBocXep.SelectedValue.ToString() == "0"))
                strError = "Bạn chưa chọn bãi bốc xếp! \n";

            if ((cboSoXe.SelectedValue == null) || (cboSoXe.SelectedValue.ToString() == "0"))
                strError = "Bạn chưa chọn xe vận chuyển! \n";

            if ((cboGiaMia.SelectedValue == null) || (cboGiaMia.SelectedValue.ToString() == "0"))
                strError = "Bạn chưa chọn đơn giá nhập mía! \n";

            if (txtSoHopDong.Text == "")
                strError = "Bạn chưa nhập số hợp đồng trồng mía! \n";

            
            if (txtHopDongVC.Text =="")
                strError = "Bạn chưa nhập số hợp đồng trồng mía! \n";

            long TLMia = 0;
            if (txtCanMia.Text == "")
                strError = "Bạn chưa nhập khối lượng xe mía! \n";
            else
            {
                try { TLMia = long.Parse(txtCanMia.Text); }
                catch { TLMia = 0; }
                if (TLMia <= 0)
                    strError = "Trọng lượng xe mía phải lớn hơn 0!\n";
            }

            if (Type > 0)
            {
                if (txtTiLeTapVat.Text == "")
                    strError = "Bạn chưa nhập tỉ lệ tạp vật! \n";

                long TLXe = 0;
                if (txtCanXe.Text == "")
                    strError = "Bạn chưa nhập khối lượng bì xe! \n";
                else
                {
                    try { TLXe = long.Parse(txtCanXe.Text); }
                    catch { TLXe = 0; }
                    if (TLXe <= 0)
                        strError = "Trọng lượng xe phải lớn hơn 0!\n";
                    else
                        if (TLXe > TLMia)
                            strError = "Trọng lượng bì xe lớn hơn trọng lượng xe mía 0!\n";
                }
            }

            if (strError == "")
                return true;
            else
            {
                MessageBox.Show(strError,"Lỗi nhập dữ liệu",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }

        private void InitControl(string type)
        { 
            switch (type)
            {
                case  "Cân mía":
                    txtCan.ReadOnly = false;
                    txtCanMia.ReadOnly = true;
                    txtCanXe.ReadOnly = true;
                    cmdCanXe.Visible = false;
                    cmdCanMia.Visible = true;
                    cboBaiBocXep.Enabled = true;
                    cboSoXe.Enabled = true;
                    cboGiaMia.Enabled = true;
                    txtSoHopDong.ReadOnly = false;
                    txtHopDongVC.ReadOnly = false;
                    cmdAddHopDong.Visible = false;
                    cmdInPhieu.Visible = false;
                    cmdFindHopDong.Visible = true;
                    cmdFindHDVC.Visible = true;
                    cmdNext.Visible = false;
                    lbl_kieucan.Text = "CÂN XE MÍA";
                    break;
                case "Cân bì":
                    cmdFindHopDong.Visible = false;
                    cmdFindHDVC.Visible = false;
                    txtSoHopDong.ReadOnly = true;
                    txtHopDongVC.ReadOnly = true;
                    cmdAddHopDong.Visible = true;
                    txtCan.ReadOnly = false;
                    txtCanMia.ReadOnly = true;
                    txtCanXe.ReadOnly = true;
                    cboBaiBocXep.Enabled = false;
                    cboSoXe.Enabled = false;
                    cboGiaMia.Enabled = false;
                    cmdCanMia.Visible = false;
                    cmdCanXe.Visible = true;
                    cmdInPhieu.Visible = false;
                    cmdNext.Visible = true;
                    lbl_kieucan.Text = "CÂN BÌ XE";
                    break;
                case "admin":
                    cmdFindHopDong.Visible = true;
                    cmdFindHDVC.Visible = true;
                    txtSoHopDong.ReadOnly = false;
                    txtHopDongVC.ReadOnly = false;
                    cmdAddHopDong.Visible = false;
                    txtCan.ReadOnly = false;
                    txtCanMia.ReadOnly = false;
                    txtCanXe.ReadOnly = false;
                    cboBaiBocXep.Enabled = false;
                    cboSoXe.Enabled = true;
                    cboGiaMia.Enabled = true;
                    cmdCanMia.Visible = true;
                    cmdCanXe.Visible = true;
                    cmdInPhieu.Enabled = false;
                    cmdNext.Visible = true;
                    break;
                case "print":
                    cmdFindHopDong.Visible = false;
                    cmdFindHDVC.Visible = false;
                    txtSoHopDong.ReadOnly = true;
                    txtHopDongVC.ReadOnly = true;
                    cmdAddHopDong.Visible = false;
                    txtCan.ReadOnly = true;
                    txtCanMia.ReadOnly = true;
                    txtCanXe.ReadOnly = true;
                    cboBaiBocXep.Enabled = false;
                    cboSoXe.Enabled = false;
                    cboGiaMia.Enabled = false;
                    cmdCanMia.Visible = false;
                    cmdCanXe.Visible = false;
                    cmdInPhieu.Visible = true;
                    cmdNext.Visible = true;
                    lbl_kieucan.Text = "IN PHIẾU CÂN";
                    break;               
            }


        }
        private void SetNullControl()
        {
            txtSoHopDong.Text = "";
            txtHopDongVC.Text = "";
            txtHoTen.Text = "";
            txtHoTenKHVC.Text = "";
            txtMaKhach.Text = "";
            txtMaKhachVC.Text = "";
            txtThanhTien.Text = "";
          

            load_cbo_baibocxep("0", "0");
            load_cbo_gianhapmia("0", VuTrongID);
            load_cbo_xe("0", "0");

            txtCanXe.Text = "0";
            txtTiLeTapVat.Text = "";
            txtCan.Text = "0";
            txtCanMia.Text = "0";
          
            txtTrongLuongMia.Text = "0";
            txtTrongLuongCan.Text = "0";
        }

        private int XeChuaCanBi()
        {
            int iResult = 0;
            DataSet ds = null;
            ds = clsNhapMia.GetListbyWhere("Count(*) as TongXe", "MaCanGhepID=-1 AND TrongLuongXe<=0 AND VuTrongID=" + VuTrongID, "", null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    iResult = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                    iResult = 0;
                }
            }
            return iResult;
        }

        private void Load_PhieuCan()
        { 
             clsNhapMia objNhapMia = new clsNhapMia(MaCanID);
             if (MaCanID >0)
             {
                 objNhapMia.Load( null, null);
                 if (objNhapMia.ID > 0)
                 {
                     kieu_can = false;
                     MaCanID = objNhapMia.ID;
                     txtCanMia.Text = objNhapMia.TongTrongLuong.ToString();
                     txtCanMia.ReadOnly = true;
                     txtCanXe.Text = txtCan.Text;
                     clsHopDong objHD = new clsHopDong(objNhapMia.HopDongID);
                     objHD.Load(null, null);
                     txtMaKhach.Text = objHD.ID.ToString();
                     txtSoHopDong.Text = objHD.MaHopDong;
                     txtHoTen.Text = objHD.HoTen;

                     //Load CBO Bai boc xep
                     load_cbo_baibocxep(objNhapMia.BaiTapKetID.ToString(), objHD.ThonID.ToString());

                     //Load CBO gia nhap mia
                     load_cbo_gianhapmia(objNhapMia.DonGiaMia.ToString(), VuTrongID);
                     InitControl("Cân bì");
                     KhoiLuongCanGep = frmGhepMaCan.TongCanGhep(MaCanID.ToString());
                     SoHDCanGhep = frmGhepMaCan.SoHDCanGhep(MaCanID.ToString());
                 }
             }
        }

        private void Load_XeChuaCanBi(string SoXe)
        {
             clsNhapMia objNhapMia = new clsNhapMia();
                objNhapMia.Load(SoXe, null, null);
                if (objNhapMia.ID > 0)
                {
                    kieu_can = false;
                    MaCanID = objNhapMia.ID;
                   

                    //Load thong tin chu van chuyen
                    clsHopDongVanChuyen objVC = new clsHopDongVanChuyen();
                    objVC.ID = objNhapMia.HopDongVanChuyenID;
                    objVC.Load(null, null);
                    txtHopDongVC.Text = objVC.MaHopDong;
                    txtHoTenKHVC.Text = objVC.TenChuHopDong;
                    //load_cbo_xe(SoXe, objVC.ID.ToString());
                    clsXeVanChuyen objXe = new clsXeVanChuyen(long.Parse(SoXe));
                    objXe.Load(null, null);
                    cboSoXe.Text = objXe.SoXe;

                    //Load thong tin can
                    txtCanMia.Text = objNhapMia.TongTrongLuong.ToString();
                    txtCanMia.ReadOnly = true;
                    txtCanXe.Text = txtCan.Text;
                    
                    //Load thong tin Hop dong
                    clsHopDong objHD = new clsHopDong(objNhapMia.HopDongID);
                    objHD.Load(null, null);
                    txtMaKhach.Text = objHD.ID.ToString();
                    txtSoHopDong.Text = objHD.MaHopDong;
                    txtHoTen.Text = objHD.HoTen;
                    //Load CBO Bai boc xep
                    load_cbo_baibocxep(objNhapMia.BaiTapKetID.ToString(), objHD.ThonID.ToString());
                    
                    //Load CBO gia nhap mia
                    load_cbo_gianhapmia(objNhapMia.DonGiaMia.ToString(), VuTrongID);

                    //Set control
                    InitControl("Cân bì");
                    KhoiLuongCanGep = frmGhepMaCan.TongCanGhep(MaCanID.ToString());
                    SoHDCanGhep = frmGhepMaCan.SoHDCanGhep(MaCanID.ToString());
                    lblTongTL.Text = "Tổng TL ghép:" + KhoiLuongCanGep.ToString();
                    lblSoHDGhep.Text = "Số HĐ ghép:" + SoHDCanGhep.ToString();
                }
        }

        
        # endregion


        # region EventArgs
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.F2:
                        //Code cho F1
                        //dlgHopDongVanChuyen frm = new dlgHopDongVanChuyen();
                        //frm.ShowDialog();
                        dlgHopDongVanChuyen dlg = new dlgHopDongVanChuyen();
                        dlg.passID = new dlgHopDongVanChuyen.PassID(GetHopDongVC_ID);
                        dlg.ShowDialog();
                        if (dlg.DialogResult == DialogResult.OK)
                        {
                            Get_KhachVanChuyen_ByID(MaKVC);
                            dlg.Dispose();
                        }
                        else
                        {
                            //MessageBox.Show("Cancel" + oHD.ID.ToString());
                            dlg.Dispose();
                        }
                        break;

                    case Keys.F4:
                        //Code cho F4
                        dlgXeChuaCanBi dlg1 = new dlgXeChuaCanBi();
                        dlg1.passID = new dlgXeChuaCanBi.PassID(Get_XeChuaCanBi);
                        dlg1.ShowDialog();
                        if (dlg1.DialogResult == DialogResult.OK)
                        {

                            Load_XeChuaCanBi(SoXe);
                            dlg1.Dispose();
                        }
                        else
                        {
                            //MessageBox.Show("Cancel" + oHD.ID.ToString());
                            dlg1.Dispose();
                        }
                        break;
                    case Keys.F3:
                        // Code cho phim F3
                        dlgHopDong dlg2 = new dlgHopDong();
                        dlg2.passID = new dlgHopDong.PassID(GetHopDongID);
                        dlg2.ShowDialog();
                        if (dlg2.DialogResult == DialogResult.OK)
                        {
                            //MessageBox.Show("OK"+oHD.ID.ToString());
                            Get_Khach_By_ID(MaKhach);
                            dlg2.Dispose();
                        }
                        else
                        {
                            //MessageBox.Show("Cancel" + oHD.ID.ToString());
                            dlg2.Dispose();
                        }
                        break;
                    case Keys.F10:
                        // Code cho phim F5
                        frmGhepMaCan dlg3 = new frmGhepMaCan();
                        dlg3.MaCanGhep = MaCanID;
                        dlg3.ShowDialog();
                        if (dlg3.DialogResult == DialogResult.OK)
                        {
                            KhoiLuongCanGep = frmGhepMaCan.TongCanGhep(MaCanID.ToString());
                            SoHDCanGhep = frmGhepMaCan.SoHDCanGhep(MaCanID.ToString());
                            if (KhoiLuongCanGep > 0)
                            {
                                lblTongTL.Text = "Tổng TL ghép:" + KhoiLuongCanGep.ToString();
                                lblSoHDGhep.Text = "Số HĐ ghép:" + SoHDCanGhep.ToString();
                                clsNhapMia obj = new clsNhapMia(MaCanID);
                                obj.Load(null, null);
                                txtCanMia.Text = obj.TongTrongLuong.ToString();
                                long TongTL = 0;
                                try
                                {
                                    TongTL = long.Parse(txtCanMia.Text);
                                }
                                catch
                                {
                                    TongTL = 0;
                                }
                                if (TongTL > 0) TongTL = TongTL - KhoiLuongCanGep;
                                txtCanMia.Text = TongTL.ToString();
                                Tinh_Toan();
                            }
                        }
                        else
                        {
                            dlg3.Dispose();
                        }
                        break;
                    case Keys.F8:
                        // Code cho phim F8
                        clsNhapMia objNhapMia = new clsNhapMia();
                        if (MaCanID > 0)
                        {
                            objNhapMia.ID = MaCanID;
                            objNhapMia.Load(null, null);
                        }

                        if (Check_Error(0))
                        {
                            objNhapMia.HopDongID = long.Parse(txtMaKhach.Text);
                            objNhapMia.HopDongVanChuyenID = long.Parse(txtMaKhachVC.Text);
                            objNhapMia.TongTrongLuong = long.Parse(txtCanMia.Text);
                            TongTL = Convert.ToInt64(Math.Round(objNhapMia.TongTrongLuong));
                            objNhapMia.XeID = long.Parse(cboSoXe.SelectedValue.ToString());
                            objNhapMia.NgayVanChuyen = DateTime.Now;
                            objNhapMia.GioNhap = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                            objNhapMia.BaiTapKetID = long.Parse(cboBaiBocXep.SelectedValue.ToString());
                            objNhapMia.DonGiaMia = long.Parse(cboGiaMia.Text);
                            objNhapMia.VuTrongID = long.Parse(VuTrongID);
                            objNhapMia.Save(null, null);
                            MaCanID = objNhapMia.ID;
                            MessageBox.Show("Đã cập nhật số lượng cân xe chở mía", "Thông báo", MessageBoxButtons.OK);
                            //kieu_can = false;
                            //txtCan.Text = "0";
                            //InitControl("Cân bì");
                            //Cap nhat xe chua can bi

                            kieu_can = true;
                            MaCanID = 0;
                            KhoiLuongCanGep = 0;
                            SoHDCanGhep = 0;

                            lbl_kieucan.Text = "CÂN XE MÍA";
                            SetNullControl();
                            InitControl("Cân mía");
                            txtHopDongVC.Focus();

                            cmdXeChuaCan.Text = XeChuaCanBi().ToString() + "-Thiếu bì(F4)";
                        }
                        break;
                    case Keys.F9:
                        // Code cho phim F9
                        if (Check_Error(1))
                        {
                            clsNhapMia objNhapMia1 = new clsNhapMia(MaCanID);
                            objNhapMia1.Load(null, null);
                            //txtCanMia.Text = objNhapMia.TongTrongLuong.ToString();
                            objNhapMia1.NgayRa = DateTime.Now;
                            objNhapMia1.GioRa = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                            objNhapMia1.TrongLuongXe = long.Parse(txtCanXe.Text);
                            objNhapMia1.DonGiaMia = long.Parse(cboGiaMia.Text);
                            objNhapMia1.TyLeTapVat = decimal.Parse(txtTiLeTapVat.Text);
                            objNhapMia1.TongTrongLuong = long.Parse(txtCanMia.Text);
                            objNhapMia1.TrongLuongTapVat = Convert.ToDecimal((objNhapMia1.TongTrongLuong - objNhapMia1.TrongLuongXe) * objNhapMia1.TyLeTapVat / 100);

                            clsBaiTapKet objBTK = new clsBaiTapKet(objNhapMia1.BaiTapKetID);
                            objBTK.Load(null, null);
                            objNhapMia1.DonGiaVanChuyen = objBTK.DonGia;

                            objNhapMia1.TienMia = (objNhapMia1.TongTrongLuong - objNhapMia1.TrongLuongXe - objNhapMia1.TrongLuongTapVat) * objNhapMia1.DonGiaMia;
                            objNhapMia1.TienVanChuyen = (objNhapMia1.TongTrongLuong - objNhapMia1.TrongLuongXe - objNhapMia1.TrongLuongTapVat) * objNhapMia1.DonGiaVanChuyen;
                    
                            OleDbConnection cn = DBModule.CreateDBConnection();
                            OleDbTransaction trans = cn.BeginTransaction();
                            try
                            {
                                objNhapMia1.Save(null, null);
                                if (SoHDCanGhep > 0)
                                {
                                    DataSet ds = clsNhapMia.GetListbyWhere("ID", "MaCanGhepID=" + objNhapMia1.ID.ToString(), "", cn, trans);
                                    foreach (DataRow dr in ds.Tables[0].Rows)
                                    {
                                        long MaCan = -1;
                                        try
                                        {
                                            MaCan = long.Parse(dr[0].ToString());
                                        }
                                        catch { MaCan = -1; };
                                        if (MaCan > 0)
                                        {
                                            clsNhapMia obj = new clsNhapMia(MaCan);
                                            obj.Load(cn, trans);
                                            obj.TyLeTapVat = objNhapMia1.TyLeTapVat;
                                            obj.TrongLuongTapVat = Convert.ToInt32(obj.TongTrongLuong * obj.TyLeTapVat / 100);
                                            obj.DonGiaMia = objNhapMia1.DonGiaMia;
                                            obj.VuTrongID = long.Parse(VuTrongID);
                                            obj.MaCanGhepID = objNhapMia1.ID;
                                            obj.HopDongVanChuyenID = objNhapMia1.HopDongVanChuyenID;
                                            obj.BaiTapKetID = objNhapMia1.BaiTapKetID;
                                            obj.XeID = objNhapMia1.XeID;
                                            obj.DonGiaVanChuyen = objNhapMia1.DonGiaVanChuyen;
                                            obj.TienMia = (obj.TongTrongLuong - obj.TrongLuongXe - obj.TrongLuongTapVat) * obj.DonGiaMia;
                                            obj.TienVanChuyen = (obj.TongTrongLuong - obj.TrongLuongXe - obj.TrongLuongTapVat) * obj.DonGiaVanChuyen;
                                            obj.Save(cn, trans);
                                        }
                                    }
                                }
                                if (trans != null) trans.Commit();
                                MessageBox.Show("Đã cập nhật số lượng cân bì xe", "Thông báo", MessageBoxButtons.OK);
                                //txtCan.Text = "0";
                                InitControl("print");
                            }
                            catch
                            {
                                if (trans != null) trans.Rollback();
                            }
                            finally
                            {
                                DBModule.CloseDBConnection(cn);
                            }
                        }
                        break;
                    case Keys.F11:
                        // Code cho phim F11
                        MDSolution.MDForms.frmShowRP2 frm = new MDSolution.MDForms.frmShowRP2();
                        MDSolution.MDReport.rp_PhieuNhapMia rp = new MDSolution.MDReport.rp_PhieuNhapMia();

                        //rp.RecordSelectionFormula = "{V_VanChuyenMia.ID} = " + MaCanID.ToString();
                        string strSQL = "";
                        strSQL = "Select * from V_VanChuyenMia Where ID = " + MaCanID.ToString() + " OR MaCanGhepID=" + MaCanID.ToString();
                        DataSet ds1 = DBModule.ExecuteQuery(strSQL, null, null);
                        //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                        rp.Database.Tables[0].SetDataSource(ds1.Tables[0]);
                        frm.RP = rp;
                        frm.RPtitle = "In phiếu nhập mía nguyên liệu";
                        frm.Show();
                        break;
                    case Keys.F12:
                        // Code cho phim F12
                        kieu_can = true;
                        MaCanID = 0;
                        KhoiLuongCanGep = 0;
                        SoHDCanGhep = 0;

                        lbl_kieucan.Text = "CÂN XE MÍA";
                        lblTongTL.Text = "Tổng TL ghép:";
                        lblSoHDGhep.Text = "Số HĐ ghép:";
                        SetNullControl();
                        InitControl("Cân mía");
                        cmdXeChuaCan.Text = XeChuaCanBi().ToString() + "-Thiếu bì(F4)";
                        txtHopDongVC.Focus();
                        break;
                    case Keys.F6:
                        // Code cho phim F6
                        txtTiLeTapVat.Focus();
                        break;
                    case Keys.F7:
                        // Code cho phim F7
                        cboGiaMia.Focus();
                        break;
                    case Keys.F1:
                        // Code cho phim F6
                        txtHopDongVC.Focus();
                        break;
                    case Keys.F5:
                        // Code cho phim F7
                        txtSoHopDong.Focus();
                        break;    
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        } 


        private void cmdAddHopDong_Click(object sender, EventArgs e)
        {
                //frmGhepMaCan frm = new frmGhepMaCan();
                //frmGhepMaCan.MaCanGhep = MaCanID;
                //frm.ShowDialog();
            frmGhepMaCan dlg = new frmGhepMaCan();
            dlg.MaCanGhep = MaCanID;
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                KhoiLuongCanGep = frmGhepMaCan.TongCanGhep(MaCanID.ToString());
                SoHDCanGhep = frmGhepMaCan.SoHDCanGhep(MaCanID.ToString());
                if (KhoiLuongCanGep > 0)
                {
                    lblTongTL.Text = "Tổng TL ghép:" + KhoiLuongCanGep.ToString();
                    lblSoHDGhep.Text = "Số HĐ ghép:" + SoHDCanGhep.ToString();
                    clsNhapMia obj = new clsNhapMia(MaCanID);
                    obj.Load(null, null);
                    txtCanMia.Text = obj.TongTrongLuong.ToString();
                    long TongTL=0;
                    try
                    {
                        TongTL = long.Parse(txtCanMia.Text);
                    }
                    catch
                    {
                        TongTL = 0;
                    }
                    if (TongTL > 0) TongTL = TongTL - KhoiLuongCanGep;
                    txtCanMia.Text = TongTL.ToString();
                    Tinh_Toan();
                }
            }
            else
            {
                dlg.Dispose();
            }
        }
       
        private void cmdFindHDVC_Click(object sender, EventArgs e)
        {
            //dlgHopDongVanChuyen frm = new dlgHopDongVanChuyen();
            //frm.ShowDialog();
            dlgHopDongVanChuyen dlg = new dlgHopDongVanChuyen();
            dlg.passID = new dlgHopDongVanChuyen.PassID(GetHopDongVC_ID);
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                Get_KhachVanChuyen_ByID(MaKVC);
                dlg.Dispose();
            }
            else
            {
                //MessageBox.Show("Cancel" + oHD.ID.ToString());
                dlg.Dispose();
            }
        }
        public void GetHopDongVC_ID(string value)
        {
            MaKVC = value;
        }
        private void cmdFindHopDong_Click(object sender, EventArgs e)
        {
            dlgHopDong dlg = new dlgHopDong();
            dlg.passID = new dlgHopDong.PassID(GetHopDongID);
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                //MessageBox.Show("OK"+oHD.ID.ToString());
                Get_Khach_By_ID(MaKhach);
                dlg.Dispose();
            }
            else
            {
                //MessageBox.Show("Cancel" + oHD.ID.ToString());
                dlg.Dispose();
            }
        }
        public void GetHopDongID(string value)
        {
            MaKhach = value;            
        }

        private void cmdCanMia_Click(object sender, EventArgs e)
        {
            clsNhapMia objNhapMia = new clsNhapMia();
            if (MaCanID > 0)
            {
                objNhapMia.ID = MaCanID;
                objNhapMia.Load(null, null);
            }

            if (Check_Error(0))
            {
                objNhapMia.HopDongID = long.Parse(txtMaKhach.Text);
                objNhapMia.HopDongVanChuyenID = long.Parse(txtMaKhachVC.Text);
                objNhapMia.TongTrongLuong = long.Parse(txtCanMia.Text);
                TongTL = Convert.ToInt64(Math.Round(objNhapMia.TongTrongLuong));
                objNhapMia.XeID = long.Parse(cboSoXe.SelectedValue.ToString());
                objNhapMia.NgayVanChuyen = DateTime.Now;
                objNhapMia.GioNhap = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                objNhapMia.BaiTapKetID = long.Parse(cboBaiBocXep.SelectedValue.ToString());
                objNhapMia.DonGiaMia = long.Parse(cboGiaMia.Text);
                objNhapMia.VuTrongID = long.Parse(VuTrongID);
                objNhapMia.Save(null, null);
                MaCanID = objNhapMia.ID;
                MessageBox.Show("Đã cập nhật số lượng cân xe chở mía", "Thông báo", MessageBoxButtons.OK);
                //kieu_can = false;
                //txtCan.Text = "0";
                //InitControl("Cân bì");
                //Cap nhat xe chua can bi

                kieu_can = true;
                MaCanID = 0;
                KhoiLuongCanGep = 0;
                SoHDCanGhep = 0;

                lbl_kieucan.Text = "CÂN XE MÍA";
                SetNullControl();
                InitControl("Cân mía");
                txtHopDongVC.Focus();

                cmdXeChuaCan.Text = XeChuaCanBi().ToString() + "-Thiếu bì(F4)";
            }
        }

        private void cmdCanXe_Click(object sender, EventArgs e)
        {
             if (Check_Error(1))
                {
                    clsNhapMia objNhapMia = new clsNhapMia(MaCanID);
                    objNhapMia.Load(null, null);
                    //txtCanMia.Text = objNhapMia.TongTrongLuong.ToString();
                    objNhapMia.NgayRa = DateTime.Now;                    
                    objNhapMia.GioRa = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                    objNhapMia.TrongLuongXe = long.Parse(txtCanXe.Text);
                    objNhapMia.DonGiaMia = long.Parse(cboGiaMia.Text);
                    objNhapMia.TyLeTapVat = decimal.Parse(txtTiLeTapVat.Text);
                    objNhapMia.TongTrongLuong = long.Parse(txtCanMia.Text);
                    objNhapMia.TrongLuongTapVat = Convert.ToDecimal((objNhapMia.TongTrongLuong - objNhapMia.TrongLuongXe )* objNhapMia.TyLeTapVat / 100);

                    clsBaiTapKet objBTK = new clsBaiTapKet(objNhapMia.BaiTapKetID);
                    objBTK.Load(null, null);
                    objNhapMia.DonGiaVanChuyen = objBTK.DonGia;

                    objNhapMia.TienMia = (objNhapMia.TongTrongLuong - objNhapMia.TrongLuongXe - objNhapMia.TrongLuongTapVat) * objNhapMia.DonGiaMia;
                    objNhapMia.TienVanChuyen = (objNhapMia.TongTrongLuong - objNhapMia.TrongLuongXe - objNhapMia.TrongLuongTapVat) * objNhapMia.DonGiaVanChuyen;
                    
                    
                    OleDbConnection cn = DBModule.CreateDBConnection();
                    OleDbTransaction trans = cn.BeginTransaction();
                    try
                    {
                        objNhapMia.Save(null, null);
                        if (SoHDCanGhep > 0)
                        {
                            DataSet ds = clsNhapMia.GetListbyWhere("ID", "MaCanGhepID=" + objNhapMia.ID.ToString(), "", cn, trans);
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                long MaCan = -1;
                                try
                                {
                                    MaCan = long.Parse(dr[0].ToString());
                                }
                                catch { MaCan = -1; };
                                if (MaCan > 0)
                                {
                                    clsNhapMia obj = new clsNhapMia(MaCan);
                                    obj.Load(cn, trans);
                                    obj.TyLeTapVat = objNhapMia.TyLeTapVat;
                                    obj.TrongLuongTapVat = Convert.ToInt32(obj.TongTrongLuong * obj.TyLeTapVat / 100);                                    
                                    obj.DonGiaMia = objNhapMia.DonGiaMia;
                                    obj.VuTrongID = long.Parse(VuTrongID);
                                    obj.MaCanGhepID = objNhapMia.ID;
                                    obj.HopDongVanChuyenID = objNhapMia.HopDongVanChuyenID;
                                    obj.BaiTapKetID = objNhapMia.BaiTapKetID;
                                    obj.XeID = objNhapMia.XeID;
                                    obj.DonGiaVanChuyen = objNhapMia.DonGiaVanChuyen;
                                    obj.TienMia = (obj.TongTrongLuong - obj.TrongLuongXe - obj.TrongLuongTapVat) * obj.DonGiaMia;
                                    obj.TienVanChuyen = (obj.TongTrongLuong - obj.TrongLuongXe - obj.TrongLuongTapVat) * obj.DonGiaVanChuyen;
                                    obj.Save(cn,trans );
                                }
                            }
                        }
                        if (trans != null) trans.Commit();
                        MessageBox.Show("Đã cập nhật số lượng cân bì xe", "Thông báo", MessageBoxButtons.OK);
                        //txtCan.Text = "0";
                        InitControl("print");
                    }
                    catch
                    {
                        if (trans != null) trans.Rollback();
                    }
                    finally
                    {
                        DBModule.CloseDBConnection(cn);
                    }
                }
          }


        private void txtCan_TextChanged(object sender, EventArgs e)
        {
            if (kieu_can)
            {
                txtCanMia.Text = txtCan.Text;
            }
            else
            {
                try
                {
                    txtCanXe.Text = txtCan.Text;
                    long TrongLuong = long.Parse(txtCanMia.Text) - long.Parse(txtCanXe.Text);
                    txtTrongLuongCan.Text = TrongLuong.ToString();
                }
                catch { };
            }
        }

        private void txtCanMia_TextChanged(object sender, EventArgs e)
        {
            Tinh_Toan();
        }

        private void txtCanXe_TextChanged(object sender, EventArgs e)
        {
            Tinh_Toan();
        }

        private void txtTiLeTapVat_TextChanged(object sender, EventArgs e)
        {
            double TiLeTapVat = 0;
            try
            {
                TiLeTapVat = double.Parse(txtTiLeTapVat.Text);
            }
            catch
            {
                TiLeTapVat = 0;
            }
            if ((TiLeTapVat < 0) || (TiLeTapVat > 100))
            {
                MessageBox.Show("Kiểm tra lại tỉ lệ tạp vật","Lỗi nhập dữ liệu",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtTiLeTapVat.Text = "";
            }  
            else
            {
                Tinh_Toan();
            }
            
        }

        private void cboSoXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSoXe.SelectedValue != null)
            {
                Load_XeChuaCanBi(cboSoXe.SelectedValue.ToString());
             }
             else
                {
                    kieu_can = true;
                    InitControl("Cân mía");
                    MaCanID = -1;
                    txtCanMia.Text = txtCan.Text;
                    txtCanXe.Text = "0";
                    txtCanMia.ReadOnly = false;
                }
            }

        private void txtHopDongVC_TextChanged(object sender, EventArgs e)
        {
            Get_KhachVanChuyen(txtHopDongVC.Text.Trim());
        }

        private void txtSoHopDong_TextChanged(object sender, EventArgs e)
        {
            Get_Khach(txtSoHopDong.Text);
        }

        private void txtTrongLuongMia_TextChanged(object sender, EventArgs e)
        {
            double ThanhTien = double.Parse(txtTrongLuongMia.Text) * double.Parse(cboGiaMia.Text);
            txtThanhTien.Text = ThanhTien.ToString("### ### ###");
        }

        private void time_Tick(object sender, EventArgs e)
        {

            if (comport.IsOpen)
            {
                string dataIn = comport.ReadExisting();
                int index;
                String StringIn = "";
                if (dataIn.Length > 10)
                {
                    while (dataIn.Length > 0 && ((index = dataIn.IndexOf("\r")) > 0 || (index = dataIn.IndexOf("\n")) > 0))
                    {
                        StringIn = dataIn.Substring(0, index);
                        if (StringIn.Length >= 6)
                        {
                            StringIn = StringIn.Substring(4, 6);
                            dataIn = "0";
                        }
                        else
                            break;
                    }
                }

                if (StringIn.Length == 6)
                {
                    long TL = 0;
                    try
                    {
                        TL = long.Parse(StringIn);
                    }
                    catch
                    {
                        TL = 0;
                    }
                    txtCan.Text = TL.ToString();
                }
            }
            cmdXeChuaCan.Text = XeChuaCanBi().ToString() + "-Thiếu bì(F4)";
           // lblSoHDGhep.Text = "Số HĐ ghép:"+ SoHDCanGhep.ToString();
           // lblTongTL.Text = "Tổng TL ghép:"+ KhoiLuongCanGep.ToString();
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            kieu_can = true;
            MaCanID = 0;
            KhoiLuongCanGep = 0;
            SoHDCanGhep = 0;

            lbl_kieucan.Text = "CÂN XE MÍA";
            lblTongTL.Text = "Tổng TL ghép:";
            lblSoHDGhep.Text = "Số HĐ ghép:";
            SetNullControl();
            InitControl("Cân mía");
            txtHopDongVC.Focus();
            cmdXeChuaCan.Text = XeChuaCanBi().ToString() + "-Thiếu bì(F4)";
        }
        # endregion

        private void cmdXeChuaCan_Click(object sender, EventArgs e)
        {
            dlgXeChuaCanBi dlg = new dlgXeChuaCanBi();
            dlg.passID = new dlgXeChuaCanBi.PassID(Get_XeChuaCanBi);
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                
                Load_XeChuaCanBi(SoXe);
                dlg.Dispose();
            }
            else
            {
                //MessageBox.Show("Cancel" + oHD.ID.ToString());
                dlg.Dispose();
            }
        }

        public void Get_XeChuaCanBi(string value)
        {
            SoXe = value;
        }

        private void cmdInPhieu_Click(object sender, EventArgs e)
        {
            MDSolution.MDForms.frmShowRP2 frm = new MDSolution.MDForms.frmShowRP2();
            MDSolution.MDReport.rp_PhieuNhapMia rp = new MDSolution.MDReport.rp_PhieuNhapMia();
           
            //rp.RecordSelectionFormula = "{V_VanChuyenMia.ID} = " + MaCanID.ToString();
            string strSQL = "";
            strSQL = "Select * from V_VanChuyenMia Where ID = "+ MaCanID.ToString() +" OR MaCanGhepID="+MaCanID.ToString();
            DataSet ds = DBModule.ExecuteQuery(strSQL,null,null);            
            //rp.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
            rp.Database.Tables[0].SetDataSource(ds.Tables[0]);
            frm.RP = rp;
            frm.RPtitle = "In phiếu nhập mía nguyên liệu";
            frm.Show();
        }

        private void txtTrongLuongCan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        

    }
}