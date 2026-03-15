using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.SCREventLog;
using CrystalDecisions.Shared;
namespace MDSolution.MDForms
{

    public partial class frmShowRP_TheoCBNVSL : Form
    {
        void getFoodter()
        {

            for (int i = 1; i < 5; i++)
                try
                {

                    string text = RP.DataDefinition.FormulaFields["A" + i.ToString()].Text;

                    dgvChanTrang.Rows.Add();
                    dgvChanTrang.Rows[i - 1].Cells["ViTri"].Value = text.Replace("\"", "");// RP.DataDefinition.FormulaFields["A" + i.ToString()].Text;
                    RP.DataDefinition.FormulaFields["A" + i.ToString()].Text = "";

                }
                catch { }

        }

        void SetFoodter()
        {
            if (dgvChanTrang.Rows.Count > 0)
                for (int i = 1; i <= dgvChanTrang.Rows.Count; i++)
                {
                    try
                    {
                        RP.DataDefinition.FormulaFields["A" + i.ToString()].Text = "";
                        string s = dgvChanTrang.Rows[i - 1].Cells[1].Value.ToString();
                        if (s == null)
                            s = " ";

                        RP.DataDefinition.FormulaFields["A" + i.ToString()].Text = "'" + s + "'";

                    }
                    catch
                    {
                        //break;
                    }

                }
        }

        private NodeCanBoNongVu nDonVi = new NodeCanBoNongVu();

        private NodeCanBoNongVu nCBNVID;
        private string TitleParent;
        public int ParameterOn = 0;
        public int SecssionSuppress;
        public frmShowRP_TheoCBNVSL()
        {
            #region set auto logon:
            ConnectionInfo ci = new ConnectionInfo();
            ci.ServerName = DBModule.ServerName;
            ci.UserID = DBModule.UserID;
            ci.Password = DBModule.Password;
            ci.DatabaseName = DBModule.DatabaseName;
            TableLogOnInfo ti = new TableLogOnInfo();
            ti.ConnectionInfo = ci;
            tblogon = ti;
            #endregion

            

            InitializeComponent();
            //CommonClass.loadTreeXa(tvDonVi);
            
        }
        /// <summary>
        /// Thiết lập reportsoure của crystalviewer
        /// </summary>
        /// 
        public MDReport.VanChuyenTheoCanBoNongVu RP = new MDReport.VanChuyenTheoCanBoNongVu();
        //public ReportClass RP;
        /// <summary>
        /// Thiết lập tiêu đề báo cáo
        /// </summary>
        public string RPtitle;
        /// <summary>
        /// Lấy thông tin logon vào database
        /// </summary>
        public TableLogOnInfo tblogon;
        /// <summary>
        /// Thiết lập tên của trường XaID
        /// </summary>
        public string XaIDName;
        //cưa hàng vận chuyển CuaHangID
        public string CuaHangIDName;


        /// <summary>
        /// Thiết lập tên của trường Thôn ID
        /// </summary>
        /// 
        //static public string strReportDir = Application.StartupPath + "\\Reports\\DienTich\\DTKTMDG\\";

        //public MDReport.rp_DSKH RP = new MDSolution.MDReport.rp_DSKH();  

        //DienTichKTMDG.rpt

       

        public string ThonIDName;
        public string VuTrongIDName;
        public string HopDongVC_ID_Name;
        public string CBNV_ID_Name;
        public string CBNV_ID="";
        public int DonViEnable = 0;
        DateTime PaTuNgay = DateTime.MinValue;
        DateTime PaDenNgay = DateTime.MaxValue;
        DateTime[] PaValueDefau;
        string RP_RecordSelectFor;
        void SetParameter()
        {

            try
            {

                PaTuNgay = dtTuNgay.Value;
                PaDenNgay = dtDenNgay.Value;
                ParameterValues pr = new ParameterValues();
                pr.AddValue(PaTuNgay.ToString("dd/MM/yyyy"));
                RP.DataDefinition.ParameterFields["TuNgay"].ApplyCurrentValues(pr);
                ParameterValues pr1 = new ParameterValues();

                pr1.AddValue(PaDenNgay.ToString("dd/MM/yyyy" + " 23:59:59"));
                RP.DataDefinition.ParameterFields["DenNgay"].ApplyCurrentValues(pr1);
               


            }
            catch { }

        }
        void SetParameterDefau()
        {
            try
            {
                if (CBNV_ID != "")
                {
                    ParameterValues pr = new ParameterValues();
                    pr.AddValue(CBNV_ID);
                    RP.DataDefinition.ParameterFields["@CanBoNongVuID"].ApplyCurrentValues(pr);
                    ParameterValues pr1 = new ParameterValues();
                    pr1.AddValue(comboBox1.SelectedValue.ToString());
                    RP.DataDefinition.ParameterFields["@VuTrongID"].ApplyCurrentValues(pr1);

                    if (ThonIDName != null)
                    {

                        ParameterValues pr2 = new ParameterValues();
                        pr2.AddValue(ThonIDName);
                        RP.DataDefinition.ParameterFields["@ThonID"].ApplyCurrentValues(pr2);
                    }
                    else
                    {
                        ParameterValues pr2 = new ParameterValues();
                        pr2.AddValue(DBNull.Value);
                        RP.DataDefinition.ParameterFields["@ThonID"].ApplyCurrentValues(pr2);
                    }
                    PaTuNgay = dtTuNgay.Value;
                    PaDenNgay = dtDenNgay.Value;

                    ParameterValues pr3 = new ParameterValues();
                    pr3.AddValue(PaTuNgay.ToString("dd/MM/yyyy") + " 00:00:00 AM");
                    RP.DataDefinition.ParameterFields["@TuNgay"].ApplyCurrentValues(pr3);

                    ParameterValues pr4 = new ParameterValues();
                    pr4.AddValue(PaDenNgay.ToString("dd/MM/yyyy") + " 23:59:59 PM");
                    RP.DataDefinition.ParameterFields["@DenNgay"].ApplyCurrentValues(pr4);

                }
                else
                {
                    MessageBox.Show("Bạn Phải chọn cán bộ địa bàn");
                }
            }
            catch { }

        }
        private void frmShowRP2_Load(object sender, EventArgs e)
        {
            if (RP.RecordSelectionFormula != null && RP.RecordSelectionFormula.ToString().Trim().Length > 0)
                RP_RecordSelectFor = RP.RecordSelectionFormula.ToString();
            else
                RP_RecordSelectFor = "1=1";

            if (ParameterOn == 1)
            {
                CheckDieuKien.Visible = true;
            }
            else
                CheckDieuKien.Visible = false;

            getFoodter();
            this.Text = "Vui lòng chờ...";
            this.WindowState = FormWindowState.Maximized;
            if (CBNV_ID_Name == null)
            {
                CommonClass.loadTreeHopDongCanBoNongVu(tvDonVi);
            }
                comboBox1.DataSource = DBModule.ExecuteQuery("SELECT * FROM tbl_VuTrong", null, null).Tables[0];
                comboBox1.DisplayMember = "Ten";
                comboBox1.ValueMember = "ID";
                //comboBox1.SelectedValue = 1;// Convert.ToInt16(MDSolutionApp.VuTrongID);
         
            this.Text = "Báo cáo: ";
            if (RPtitle != null)
            {
                this.Text += RPtitle;
                label1.Text = this.Text;
            }

            foreach (TreeNode n in tvDonVi.Nodes)
            {
                n.Toggle();
            }
            crystalReportViewer1.Focus();
            

        }
        private void tvDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (CBNV_ID_Name == null)
                    nDonVi = (NodeCanBoNongVu)tvDonVi.SelectedNode.Tag;
                else
                    nCBNVID = (NodeCanBoNongVu)tvDonVi.SelectedNode.Tag;
                load_RP();              
            }

        }

        private void tvDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (tvDonVi.SelectedNode != null)
                {
                    if (CBNV_ID_Name == null)
                    {
                        CBNV_ID = tvDonVi.SelectedNode.Name.ToString();
                        if (tvDonVi.SelectedNode.Parent.Name.ToString() != "Root")
                        {

                            CBNV_ID = tvDonVi.SelectedNode.Parent.Name.ToString();
                            ThonIDName = tvDonVi.SelectedNode.Name.ToString();
                        }
                        else
                        {
                            CBNV_ID = tvDonVi.SelectedNode.Name.ToString();
                            ThonIDName = null;
                        }
                    }

                    else
                    {
                        CBNV_ID = tvDonVi.SelectedNode.Name.ToString();
                        if (ThonIDName == null)
                        {
                            CBNV_ID = tvDonVi.SelectedNode.Parent.Name.ToString();

                            ThonIDName = tvDonVi.SelectedNode.Name.ToString();
                        }
                        else
                        {
                            CBNV_ID = tvDonVi.SelectedNode.Name.ToString();
                            ThonIDName = null;
                        }

                    }

                    load_RP();
                }
            }
            catch
            {
                MessageBox.Show("Bạn cần chọn CBĐB để xem báo cáo", "SLS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        void load_RP()
        {
            string DieuKienLoc = "";
            if (tvDonVi.SelectedNode != null)
            {
                RP.Load();
                picLoading.Visible = true;
                this.Refresh();
                if (CBNV_ID_Name == null)
                {
                  
                    //load report vao viewer;
                    RP.Database.Tables[0].ApplyLogOnInfo(tblogon);

                    if (DieuKienLoc != "")
                    {
                        if (ParameterOn != 0)
                            if (CheckDieuKien.Checked == true)
                            {
                                DieuKienLoc += " and " + RP_RecordSelectFor;
                            }
                            else
                            {
                                //SetParameterDefau();
                            }
                        
                        if (VuTrongIDName != null)
                            RP.RecordSelectionFormula = DieuKienLoc + " and " + VuTrongIDName + "=" + comboBox1.SelectedValue.ToString();
                        else
                            RP.RecordSelectionFormula = DieuKienLoc;

                        if (DonViEnable == 1)
                        {
                            try
                            {
                                if (nDonVi.CBNVType != CBNVType.Root)
                                    RP.DataDefinition.FormulaFields["DonVi"].Text = "'" + nDonVi.CBNVName.ToUpper() + "'";
                                else
                                {
                                    RP.DataDefinition.FormulaFields["DonVi"].Text = "'TOÀN VÙNG'";
                                
                                }
                            }
                            catch
                            {
                            }
                            if(SecssionSuppress!=null)
                            try
                            {
                                if ((nDonVi.CBNVType == CBNVType.ThonID) && (SecssionSuppress > 0))
                                {

                                    RP.ReportDefinition.Sections[SecssionSuppress].SectionFormat.EnableSuppress=true;//FormulaFields["DonVi"].Text = "'TOÀN VÙNG'";
                                    if (VuTrongIDName != null)
                                        DieuKienLoc = VuTrongIDName + "=" + comboBox1.SelectedValue.ToString();
                                }
                            }
                            catch
                            {
                                
                            }


                        }
                    

                    }


                }
                else
                {
                   
                    LoadReportSource();
                    //}

                }
               
                LoadReportSource();
                picLoading.Visible = false;



            }

        }
        void LoadReportSource()
        {

            if (ParameterOn != 0)
                if (CheckDieuKien.Checked == true)
                {
                    SetParameter();
                }
                else
                {
                    SetParameterDefau();
                }

            //RP.Database.Tables[0].ApplyLogOnInfo(tblogon);
            try
            {
                //if (RP.Rows.Count>1)
                //{
                    SetFoodter();
                    crystalReportViewer1.ReportSource = RP;
                    crystalReportViewer1.Refresh();
                //}
            }
            catch
            {

                {
                    //MDReport.rp_T_ReportNull rpnull = new MDSolution.MDReport.rp_T_ReportNull();
                    //if (HopDongVC_ID_Name == null)
                    //    MessageBox.Show("Không tìm thấy dữ liệu trong đơn vị: " + nDonVi.CBNVName, "Thông báo");
                    //else
                    //    MessageBox.Show("Không tìm thấy thông tin về chủ hợp đồng: ", "Thông báo");

                    crystalReportViewer1.ReportSource = null;
                    crystalReportViewer1.Refresh();
                }
            }
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tvDonVi.SelectedNode != null)
            //{
            //    if (HopDongVC_ID_Name == null)
            //        nDonVi = (NodeDonVi)tvDonVi.SelectedNode.Tag;
            //    else

            //        nChuHDVCID = (NodeHopDongVanChuyen)tvDonVi.SelectedNode.Tag;

            //    //MessageBox.Show("nDonVi.DonViID.ToString()");
            //    load_RP();
            //}
        }

        private void btok_Click(object sender, EventArgs e)
        {

                load_RP();
                pnTuyChon.Visible = false;
    
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            pnTuyChon.Visible = false;
        }

        private void btTuyChonChanTrang_Click(object sender, EventArgs e)
        {
            pnTuyChon.Visible = true;
        }
        Image img;
        private void btTuyChonChanTrang_MouseEnter(object sender, EventArgs e)
        {
            img = btTuyChonChanTrang.BackgroundImage;
            btTuyChonChanTrang.BackgroundImage = button1.BackgroundImage;
            

        }

        private void btTuyChonChanTrang_MouseLeave(object sender, EventArgs e)
        {
            btTuyChonChanTrang.BackgroundImage = img;
        }

        private void CheckDieuKien_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckDieuKien.Checked == true)
            {
                pnTuNgayDenNgay.Visible = true;
                panel2.Height = 109;
            }
            else
            {
                pnTuNgayDenNgay.Visible = false;
                panel2.Height = 48;
            }
        }

        private void dtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            //dtDenNgay.MinDate = dtTuNgay.Value;
            //if (dtDenNgay.Value <= dtTuNgay.Value)
            //    dtDenNgay.Value = dtTuNgay.Value;
        }

        private void dtDenNgay_ValueChanged(object sender, EventArgs e)
        {
            //dtDenNgay.MinDate = dtDenNgay.Value;
            //if (dtDenNgay.Value <= dtDenNgay.Value)
            //    dtDenNgay.Value = dtDenNgay.Value;
        }
        
       
        

    }
}