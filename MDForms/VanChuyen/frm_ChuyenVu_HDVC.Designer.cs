namespace MDSolution.MDForms.VanChuyen
{
    partial class frm_ChuyenVu_HDVC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChuyenVu_HDVC));
            this.lbTitle = new System.Windows.Forms.Label();
            this.pnCenter = new System.Windows.Forms.Panel();
            this.grVuChuyen = new System.Windows.Forms.GroupBox();
            this.cboVuTrong = new Janus.Windows.EditControls.UIComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.chk_ChuyenXe = new System.Windows.Forms.CheckBox();
            this.grThongTinHDVC = new Janus.Windows.EditControls.UIGroupBox();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSoXe = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.dtNgayKyHD = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lbl_TenChuHD = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnMother = new System.Windows.Forms.Panel();
            this.pnTop = new System.Windows.Forms.Panel();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.cmdLuu = new Janus.Windows.EditControls.UIButton();
            this.cmdClose = new Janus.Windows.EditControls.UIButton();
            this.pnCenter.SuspendLayout();
            this.grVuChuyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grThongTinHDVC)).BeginInit();
            this.grThongTinHDVC.SuspendLayout();
            this.pnMother.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.pnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(469, 30);
            this.lbTitle.TabIndex = 55;
            this.lbTitle.Text = "CHUYỂN VỤ HỢP ĐỒNG VẬN CHUYỂN";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnCenter
            // 
            this.pnCenter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnCenter.Controls.Add(this.grVuChuyen);
            this.pnCenter.Controls.Add(this.grThongTinHDVC);
            this.pnCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCenter.Location = new System.Drawing.Point(0, 0);
            this.pnCenter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnCenter.Name = "pnCenter";
            this.pnCenter.Size = new System.Drawing.Size(469, 185);
            this.pnCenter.TabIndex = 56;
            // 
            // grVuChuyen
            // 
            this.grVuChuyen.Controls.Add(this.cboVuTrong);
            this.grVuChuyen.Controls.Add(this.label28);
            this.grVuChuyen.Controls.Add(this.chk_ChuyenXe);
            this.grVuChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grVuChuyen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grVuChuyen.ForeColor = System.Drawing.Color.Maroon;
            this.grVuChuyen.Location = new System.Drawing.Point(0, 93);
            this.grVuChuyen.Name = "grVuChuyen";
            this.grVuChuyen.Size = new System.Drawing.Size(465, 88);
            this.grVuChuyen.TabIndex = 22;
            this.grVuChuyen.TabStop = false;
            this.grVuChuyen.Text = "Lựa chọn";
            // 
            // cboVuTrong
            // 
            this.cboVuTrong.BackColor = System.Drawing.Color.White;
            this.cboVuTrong.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboVuTrong.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVuTrong.ForeColor = System.Drawing.Color.Black;
            this.cboVuTrong.Location = new System.Drawing.Point(92, 23);
            this.cboVuTrong.Name = "cboVuTrong";
            this.cboVuTrong.Size = new System.Drawing.Size(120, 22);
            this.cboVuTrong.TabIndex = 18;
            this.cboVuTrong.SelectedIndexChanged += new System.EventHandler(this.cboVuTrong_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(34, 29);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(50, 15);
            this.label28.TabIndex = 22;
            this.label28.Text = "Vụ đích:";
            // 
            // chk_ChuyenXe
            // 
            this.chk_ChuyenXe.AutoSize = true;
            this.chk_ChuyenXe.Checked = true;
            this.chk_ChuyenXe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ChuyenXe.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_ChuyenXe.ForeColor = System.Drawing.Color.Red;
            this.chk_ChuyenXe.Location = new System.Drawing.Point(92, 58);
            this.chk_ChuyenXe.Name = "chk_ChuyenXe";
            this.chk_ChuyenXe.Size = new System.Drawing.Size(176, 20);
            this.chk_ChuyenXe.TabIndex = 16;
            this.chk_ChuyenXe.Text = "Bao gồm xe vận chuyển";
            this.chk_ChuyenXe.UseVisualStyleBackColor = true;
            // 
            // grThongTinHDVC
            // 
            this.grThongTinHDVC.Controls.Add(this.lblMaHD);
            this.grThongTinHDVC.Controls.Add(this.label6);
            this.grThongTinHDVC.Controls.Add(this.label7);
            this.grThongTinHDVC.Controls.Add(this.lblSoXe);
            this.grThongTinHDVC.Controls.Add(this.label22);
            this.grThongTinHDVC.Controls.Add(this.dtNgayKyHD);
            this.grThongTinHDVC.Controls.Add(this.lbl_TenChuHD);
            this.grThongTinHDVC.Controls.Add(this.label5);
            this.grThongTinHDVC.Controls.Add(this.label1);
            this.grThongTinHDVC.Dock = System.Windows.Forms.DockStyle.Top;
            this.grThongTinHDVC.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grThongTinHDVC.ForeColor = System.Drawing.Color.Maroon;
            this.grThongTinHDVC.Location = new System.Drawing.Point(0, 0);
            this.grThongTinHDVC.Name = "grThongTinHDVC";
            this.grThongTinHDVC.Size = new System.Drawing.Size(465, 93);
            this.grThongTinHDVC.TabIndex = 9;
            this.grThongTinHDVC.Text = "Thông tin HĐVC - Xe VC vụ nguồn";
            this.grThongTinHDVC.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.grThongTinHDVC.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.VS2005;
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHD.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMaHD.Location = new System.Drawing.Point(94, 28);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(45, 16);
            this.lblMaHD.TabIndex = 34;
            this.lblMaHD.Text = "MaHD";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(246, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "Số xe:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(26, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
            this.label7.TabIndex = 33;
            this.label7.Text = "Số HĐVC:";
            // 
            // lblSoXe
            // 
            this.lblSoXe.AutoSize = true;
            this.lblSoXe.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoXe.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSoXe.Location = new System.Drawing.Point(287, 64);
            this.lblSoXe.Name = "lblSoXe";
            this.lblSoXe.Size = new System.Drawing.Size(42, 16);
            this.lblSoXe.TabIndex = 21;
            this.lblSoXe.Text = "SoXe";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(1077, 98);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(25, 16);
            this.label22.TabIndex = 26;
            this.label22.Text = "Kg";
            // 
            // dtNgayKyHD
            // 
            this.dtNgayKyHD.CustomFormat = "dd/MM/yyyy";
            this.dtNgayKyHD.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtNgayKyHD.DropDownCalendar.Name = "";
            this.dtNgayKyHD.Enabled = false;
            this.dtNgayKyHD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayKyHD.ForeColor = System.Drawing.Color.Black;
            this.dtNgayKyHD.Location = new System.Drawing.Point(92, 61);
            this.dtNgayKyHD.Name = "dtNgayKyHD";
            this.dtNgayKyHD.Size = new System.Drawing.Size(120, 22);
            this.dtNgayKyHD.TabIndex = 12;
            this.dtNgayKyHD.Value = new System.DateTime(2017, 4, 4, 0, 0, 0, 0);
            // 
            // lbl_TenChuHD
            // 
            this.lbl_TenChuHD.AutoSize = true;
            this.lbl_TenChuHD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenChuHD.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbl_TenChuHD.Location = new System.Drawing.Point(287, 28);
            this.lbl_TenChuHD.Name = "lbl_TenChuHD";
            this.lbl_TenChuHD.Size = new System.Drawing.Size(58, 16);
            this.lbl_TenChuHD.TabIndex = 6;
            this.lbl_TenChuHD.Text = "TenCHD";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(15, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ngày ký HĐ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(240, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Họ tên:";
            // 
            // pnMother
            // 
            this.pnMother.Controls.Add(this.pnCenter);
            this.pnMother.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMother.Location = new System.Drawing.Point(0, 30);
            this.pnMother.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnMother.Name = "pnMother";
            this.pnMother.Size = new System.Drawing.Size(469, 185);
            this.pnMother.TabIndex = 58;
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lbTitle);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(469, 30);
            this.pnTop.TabIndex = 3068;
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.cmdLuu);
            this.pnBottom.Controls.Add(this.cmdClose);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 215);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(469, 47);
            this.pnBottom.TabIndex = 3068;
            // 
            // cmdLuu
            // 
            this.cmdLuu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdLuu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLuu.Image = ((System.Drawing.Image)(resources.GetObject("cmdLuu.Image")));
            this.cmdLuu.Location = new System.Drawing.Point(22, 7);
            this.cmdLuu.Name = "cmdLuu";
            this.cmdLuu.Size = new System.Drawing.Size(90, 30);
            this.cmdLuu.TabIndex = 22;
            this.cmdLuu.Text = "Chuyển";
            this.cmdLuu.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdLuu.Click += new System.EventHandler(this.cmdLuu_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.Location = new System.Drawing.Point(367, 7);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(90, 30);
            this.cmdClose.TabIndex = 23;
            this.cmdClose.Text = "Đóng";
            this.cmdClose.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frm_ChuyenVu_HDVC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(469, 262);
            this.Controls.Add(this.pnMother);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.pnTop);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChuyenVu_HDVC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HĐVC";
            this.Load += new System.EventHandler(this.frm_ChuyenVu_HDVC_Load);
            this.pnCenter.ResumeLayout(false);
            this.grVuChuyen.ResumeLayout(false);
            this.grVuChuyen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grThongTinHDVC)).EndInit();
            this.grThongTinHDVC.ResumeLayout(false);
            this.grThongTinHDVC.PerformLayout();
            this.pnMother.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.pnBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel pnCenter;
        private System.Windows.Forms.Panel pnMother;
        private System.Windows.Forms.CheckBox chk_ChuyenXe;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel pnBottom;
        private Janus.Windows.EditControls.UIButton cmdLuu;
        private Janus.Windows.EditControls.UIButton cmdClose;
        private Janus.Windows.EditControls.UIComboBox cboVuTrong;
        private Janus.Windows.EditControls.UIGroupBox grThongTinHDVC;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox grVuChuyen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSoXe;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.CalendarCombo.CalendarCombo dtNgayKyHD;
        private System.Windows.Forms.Label lbl_TenChuHD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaHD;
    }
}