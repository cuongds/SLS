namespace MDSolution.MDForms.CapVatTu

{
    partial class frm_SuaNhanVatTu
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTenBai = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.grThongTin = new System.Windows.Forms.GroupBox();
            this.dtNgayNhan = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nSoLuongVatTu = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.cboThon = new Janus.Windows.EditControls.UIComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmdThemHoCapVT = new Janus.Windows.EditControls.UIButton();
            this.cboBTKVatTu = new Janus.Windows.EditControls.UIComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnDL = new System.Windows.Forms.Panel();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.grThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSoLuongVatTu)).BeginInit();
            this.pnDL.SuspendLayout();
            this.pnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(417, 30);
            this.lblTitle.TabIndex = 153;
            this.lblTitle.Text = "SỬA THÔNG TIN NHẬN VẬT TƯ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenBai
            // 
            this.lblTenBai.AutoSize = true;
            this.lblTenBai.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBai.ForeColor = System.Drawing.Color.Black;
            this.lblTenBai.Location = new System.Drawing.Point(9, 24);
            this.lblTenBai.Name = "lblTenBai";
            this.lblTenBai.Size = new System.Drawing.Size(76, 15);
            this.lblTenBai.TabIndex = 154;
            this.lblTenBai.Text = "Người nhận:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.BackColor = System.Drawing.SystemColors.Info;
            this.txtHoTen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.ForeColor = System.Drawing.Color.Black;
            this.txtHoTen.Location = new System.Drawing.Point(90, 20);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(261, 22);
            this.txtHoTen.TabIndex = 155;
            this.txtHoTen.TabStop = false;
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(26, 4);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(90, 28);
            this.cmdOK.TabIndex = 15;
            this.cmdOK.Text = "Lưu";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Location = new System.Drawing.Point(301, 4);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(90, 28);
            this.cmdExit.TabIndex = 16;
            this.cmdExit.Text = "Hủy";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // grThongTin
            // 
            this.grThongTin.Controls.Add(this.dtNgayNhan);
            this.grThongTin.Controls.Add(this.label6);
            this.grThongTin.Controls.Add(this.label5);
            this.grThongTin.Controls.Add(this.label3);
            this.grThongTin.Controls.Add(this.nSoLuongVatTu);
            this.grThongTin.Controls.Add(this.label1);
            this.grThongTin.Controls.Add(this.txtMaHD);
            this.grThongTin.Controls.Add(this.cboThon);
            this.grThongTin.Controls.Add(this.label11);
            this.grThongTin.Controls.Add(this.cmdThemHoCapVT);
            this.grThongTin.Controls.Add(this.cboBTKVatTu);
            this.grThongTin.Controls.Add(this.label9);
            this.grThongTin.Controls.Add(this.txtHoTen);
            this.grThongTin.Controls.Add(this.lblTenBai);
            this.grThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grThongTin.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grThongTin.ForeColor = System.Drawing.Color.Maroon;
            this.grThongTin.Location = new System.Drawing.Point(0, 0);
            this.grThongTin.Name = "grThongTin";
            this.grThongTin.Size = new System.Drawing.Size(413, 232);
            this.grThongTin.TabIndex = 2;
            this.grThongTin.TabStop = false;
            this.grThongTin.Text = "Lựa chọn";
            // 
            // dtNgayNhan
            // 
            this.dtNgayNhan.CustomFormat = "dd/MM/yyyy";
            this.dtNgayNhan.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtNgayNhan.DropDownCalendar.Name = "";
            this.dtNgayNhan.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            this.dtNgayNhan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayNhan.ForeColor = System.Drawing.Color.Black;
            this.dtNgayNhan.Location = new System.Drawing.Point(90, 198);
            this.dtNgayNhan.Name = "dtNgayNhan";
            this.dtNgayNhan.Size = new System.Drawing.Size(130, 22);
            this.dtNgayNhan.TabIndex = 9;
            this.dtNgayNhan.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(18, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 192;
            this.label6.Text = "Ngày nhận:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(226, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 16);
            this.label5.TabIndex = 190;
            this.label5.Text = "(kg)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(29, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 189;
            this.label3.Text = "SL nhận:";
            // 
            // nSoLuongVatTu
            // 
            this.nSoLuongVatTu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nSoLuongVatTu.ForeColor = System.Drawing.Color.Red;
            this.nSoLuongVatTu.Location = new System.Drawing.Point(90, 164);
            this.nSoLuongVatTu.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nSoLuongVatTu.Name = "nSoLuongVatTu";
            this.nSoLuongVatTu.Size = new System.Drawing.Size(130, 22);
            this.nSoLuongVatTu.TabIndex = 8;
            this.nSoLuongVatTu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nSoLuongVatTu.ThousandsSeparator = true;
            this.nSoLuongVatTu.ValueChanged += new System.EventHandler(this.nSoLuongVatTu_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(38, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 187;
            this.label1.Text = "Mã HĐ:";
            // 
            // txtMaHD
            // 
            this.txtMaHD.BackColor = System.Drawing.SystemColors.Info;
            this.txtMaHD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHD.ForeColor = System.Drawing.Color.Black;
            this.txtMaHD.Location = new System.Drawing.Point(90, 54);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(261, 22);
            this.txtMaHD.TabIndex = 186;
            this.txtMaHD.TabStop = false;
            // 
            // cboThon
            // 
            this.cboThon.BackColor = System.Drawing.Color.White;
            this.cboThon.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboThon.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThon.ForeColor = System.Drawing.Color.Black;
            this.cboThon.Location = new System.Drawing.Point(90, 90);
            this.cboThon.Name = "cboThon";
            this.cboThon.Size = new System.Drawing.Size(261, 22);
            this.cboThon.TabIndex = 6;
            this.cboThon.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cboThon.SelectedIndexChanged += new System.EventHandler(this.cboThon_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(23, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 15);
            this.label11.TabIndex = 185;
            this.label11.Text = "Thôn/bản:";
            // 
            // cmdThemHoCapVT
            // 
            this.cmdThemHoCapVT.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThemHoCapVT.Location = new System.Drawing.Point(364, 20);
            this.cmdThemHoCapVT.Name = "cmdThemHoCapVT";
            this.cmdThemHoCapVT.Size = new System.Drawing.Size(38, 22);
            this.cmdThemHoCapVT.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Black;
            this.cmdThemHoCapVT.TabIndex = 3;
            this.cmdThemHoCapVT.Text = "...";
            this.cmdThemHoCapVT.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdThemHoCapVT.Click += new System.EventHandler(this.cmdThemHoCapVT_Click);
            // 
            // cboBTKVatTu
            // 
            this.cboBTKVatTu.BackColor = System.Drawing.Color.White;
            this.cboBTKVatTu.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboBTKVatTu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBTKVatTu.ForeColor = System.Drawing.Color.Black;
            this.cboBTKVatTu.Location = new System.Drawing.Point(90, 128);
            this.cboBTKVatTu.Name = "cboBTKVatTu";
            this.cboBTKVatTu.Size = new System.Drawing.Size(261, 22);
            this.cboBTKVatTu.TabIndex = 7;
            this.cboBTKVatTu.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(18, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 165;
            this.label9.Text = "Bãi tập kết:";
            // 
            // pnDL
            // 
            this.pnDL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnDL.Controls.Add(this.grThongTin);
            this.pnDL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDL.Location = new System.Drawing.Point(0, 30);
            this.pnDL.Name = "pnDL";
            this.pnDL.Size = new System.Drawing.Size(417, 236);
            this.pnDL.TabIndex = 1;
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.cmdOK);
            this.pnBottom.Controls.Add(this.cmdExit);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 266);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(417, 36);
            this.pnBottom.TabIndex = 10;
            // 
            // frm_SuaNhanVatTu
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(417, 302);
            this.Controls.Add(this.pnDL);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_SuaNhanVatTu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhận vật tư";
            this.Load += new System.EventHandler(this.frm_SuaNhanVatTu_Load);
            this.grThongTin.ResumeLayout(false);
            this.grThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSoLuongVatTu)).EndInit();
            this.pnDL.ResumeLayout(false);
            this.pnBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTenBai;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.GroupBox grThongTin;
        private System.Windows.Forms.Panel pnDL;
        private System.Windows.Forms.Panel pnBottom;
        private System.Windows.Forms.Label label9;
        private Janus.Windows.EditControls.UIComboBox cboBTKVatTu;
        private Janus.Windows.EditControls.UIButton cmdThemHoCapVT;
        private Janus.Windows.EditControls.UIComboBox cboThon;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nSoLuongVatTu;
        private Janus.Windows.CalendarCombo.CalendarCombo dtNgayNhan;
    }
}