namespace MDSolution.MDForms.CapVatTu

{
    partial class frm_ThemSuaHopDongNhanVatTu
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
            this.cboThon = new Janus.Windows.EditControls.UIComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtNgayNhan = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nSoTienVatTu = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nDGVT = new System.Windows.Forms.NumericUpDown();
            this.lblSoPhieu = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nTienVC = new System.Windows.Forms.NumericUpDown();
            this.nDGVC = new System.Windows.Forms.NumericUpDown();
            this.lblTenVT = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdThemHoCapVT = new Janus.Windows.EditControls.UIButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboBTKVatTu = new Janus.Windows.EditControls.UIComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nSoLuongVatTu = new System.Windows.Forms.NumericUpDown();
            this.pnDL = new System.Windows.Forms.Panel();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.grThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSoTienVatTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDGVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTienVC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDGVC)).BeginInit();
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
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(546, 30);
            this.lblTitle.TabIndex = 153;
            this.lblTitle.Text = "THÊM NÔNG HỘ NHẬN VẬT TƯ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenBai
            // 
            this.lblTenBai.AutoSize = true;
            this.lblTenBai.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBai.ForeColor = System.Drawing.Color.Black;
            this.lblTenBai.Location = new System.Drawing.Point(12, 61);
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
            this.txtHoTen.Location = new System.Drawing.Point(94, 58);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(380, 22);
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
            this.cmdExit.Location = new System.Drawing.Point(430, 4);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(90, 28);
            this.cmdExit.TabIndex = 16;
            this.cmdExit.Text = "Hủy";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // grThongTin
            // 
            this.grThongTin.Controls.Add(this.cboThon);
            this.grThongTin.Controls.Add(this.label11);
            this.grThongTin.Controls.Add(this.dtNgayNhan);
            this.grThongTin.Controls.Add(this.label6);
            this.grThongTin.Controls.Add(this.label10);
            this.grThongTin.Controls.Add(this.nSoTienVatTu);
            this.grThongTin.Controls.Add(this.label8);
            this.grThongTin.Controls.Add(this.nDGVT);
            this.grThongTin.Controls.Add(this.lblSoPhieu);
            this.grThongTin.Controls.Add(this.label7);
            this.grThongTin.Controls.Add(this.nTienVC);
            this.grThongTin.Controls.Add(this.nDGVC);
            this.grThongTin.Controls.Add(this.lblTenVT);
            this.grThongTin.Controls.Add(this.label4);
            this.grThongTin.Controls.Add(this.cmdThemHoCapVT);
            this.grThongTin.Controls.Add(this.label2);
            this.grThongTin.Controls.Add(this.label1);
            this.grThongTin.Controls.Add(this.cboBTKVatTu);
            this.grThongTin.Controls.Add(this.label9);
            this.grThongTin.Controls.Add(this.label5);
            this.grThongTin.Controls.Add(this.label3);
            this.grThongTin.Controls.Add(this.nSoLuongVatTu);
            this.grThongTin.Controls.Add(this.txtHoTen);
            this.grThongTin.Controls.Add(this.lblTenBai);
            this.grThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grThongTin.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grThongTin.ForeColor = System.Drawing.Color.Maroon;
            this.grThongTin.Location = new System.Drawing.Point(0, 0);
            this.grThongTin.Name = "grThongTin";
            this.grThongTin.Size = new System.Drawing.Size(542, 248);
            this.grThongTin.TabIndex = 2;
            this.grThongTin.TabStop = false;
            this.grThongTin.Text = "Thông tin hộ nhận vật tư";
            // 
            // cboThon
            // 
            this.cboThon.BackColor = System.Drawing.Color.White;
            this.cboThon.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboThon.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThon.ForeColor = System.Drawing.Color.Black;
            this.cboThon.Location = new System.Drawing.Point(338, 95);
            this.cboThon.Name = "cboThon";
            this.cboThon.Size = new System.Drawing.Size(190, 22);
            this.cboThon.TabIndex = 6;
            this.cboThon.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cboThon.SelectedIndexChanged += new System.EventHandler(this.cboThon_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(272, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 15);
            this.label11.TabIndex = 185;
            this.label11.Text = "Thôn/bản:";
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
            this.dtNgayNhan.Location = new System.Drawing.Point(94, 95);
            this.dtNgayNhan.Name = "dtNgayNhan";
            this.dtNgayNhan.Size = new System.Drawing.Size(137, 22);
            this.dtNgayNhan.TabIndex = 4;
            this.dtNgayNhan.Value = new System.DateTime(2017, 4, 4, 0, 0, 0, 0);
            this.dtNgayNhan.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(19, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 183;
            this.label6.Text = "Ngày nhận:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(284, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 15);
            this.label10.TabIndex = 182;
            this.label10.Text = "Tiền VT:";
            // 
            // nSoTienVatTu
            // 
            this.nSoTienVatTu.BackColor = System.Drawing.SystemColors.Info;
            this.nSoTienVatTu.Enabled = false;
            this.nSoTienVatTu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nSoTienVatTu.ForeColor = System.Drawing.Color.Black;
            this.nSoTienVatTu.Location = new System.Drawing.Point(339, 174);
            this.nSoTienVatTu.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.nSoTienVatTu.Name = "nSoTienVatTu";
            this.nSoTienVatTu.ReadOnly = true;
            this.nSoTienVatTu.Size = new System.Drawing.Size(188, 22);
            this.nSoTienVatTu.TabIndex = 9;
            this.nSoTienVatTu.TabStop = false;
            this.nSoTienVatTu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nSoTienVatTu.ThousandsSeparator = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(26, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 15);
            this.label8.TabIndex = 179;
            this.label8.Text = "ĐG Vật tư:";
            // 
            // nDGVT
            // 
            this.nDGVT.BackColor = System.Drawing.SystemColors.Info;
            this.nDGVT.Enabled = false;
            this.nDGVT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nDGVT.ForeColor = System.Drawing.Color.Black;
            this.nDGVT.Location = new System.Drawing.Point(94, 174);
            this.nDGVT.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nDGVT.Name = "nDGVT";
            this.nDGVT.ReadOnly = true;
            this.nDGVT.Size = new System.Drawing.Size(137, 22);
            this.nDGVT.TabIndex = 8;
            this.nDGVT.TabStop = false;
            this.nDGVT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nDGVT.ThousandsSeparator = true;
            // 
            // lblSoPhieu
            // 
            this.lblSoPhieu.AutoSize = true;
            this.lblSoPhieu.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoPhieu.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSoPhieu.Location = new System.Drawing.Point(94, 27);
            this.lblSoPhieu.Name = "lblSoPhieu";
            this.lblSoPhieu.Size = new System.Drawing.Size(16, 18);
            this.lblSoPhieu.TabIndex = 177;
            this.lblSoPhieu.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(29, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 15);
            this.label7.TabIndex = 176;
            this.label7.Text = "Số phiếu:";
            // 
            // nTienVC
            // 
            this.nTienVC.BackColor = System.Drawing.SystemColors.Info;
            this.nTienVC.Enabled = false;
            this.nTienVC.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nTienVC.ForeColor = System.Drawing.Color.Black;
            this.nTienVC.Location = new System.Drawing.Point(339, 212);
            this.nTienVC.Maximum = new decimal(new int[] {
            1874919424,
            2328306,
            0,
            0});
            this.nTienVC.Name = "nTienVC";
            this.nTienVC.ReadOnly = true;
            this.nTienVC.Size = new System.Drawing.Size(188, 22);
            this.nTienVC.TabIndex = 11;
            this.nTienVC.TabStop = false;
            this.nTienVC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nTienVC.ThousandsSeparator = true;
            // 
            // nDGVC
            // 
            this.nDGVC.BackColor = System.Drawing.SystemColors.Info;
            this.nDGVC.Enabled = false;
            this.nDGVC.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nDGVC.ForeColor = System.Drawing.Color.Black;
            this.nDGVC.Location = new System.Drawing.Point(94, 212);
            this.nDGVC.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nDGVC.Name = "nDGVC";
            this.nDGVC.ReadOnly = true;
            this.nDGVC.Size = new System.Drawing.Size(137, 22);
            this.nDGVC.TabIndex = 10;
            this.nDGVC.TabStop = false;
            this.nDGVC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nDGVC.ThousandsSeparator = true;
            this.nDGVC.ValueChanged += new System.EventHandler(this.nDGVC_ValueChanged);
            // 
            // lblTenVT
            // 
            this.lblTenVT.AutoSize = true;
            this.lblTenVT.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenVT.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTenVT.Location = new System.Drawing.Point(242, 28);
            this.lblTenVT.Name = "lblTenVT";
            this.lblTenVT.Size = new System.Drawing.Size(54, 18);
            this.lblTenVT.TabIndex = 173;
            this.lblTenVT.Text = "TenVT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(180, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 172;
            this.label4.Text = "Tên vật tư:";
            // 
            // cmdThemHoCapVT
            // 
            this.cmdThemHoCapVT.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThemHoCapVT.Location = new System.Drawing.Point(489, 57);
            this.cmdThemHoCapVT.Name = "cmdThemHoCapVT";
            this.cmdThemHoCapVT.Size = new System.Drawing.Size(38, 22);
            this.cmdThemHoCapVT.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Black;
            this.cmdThemHoCapVT.TabIndex = 3;
            this.cmdThemHoCapVT.Text = "...";
            this.cmdThemHoCapVT.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdThemHoCapVT.Click += new System.EventHandler(this.cmdThemHoCapVT_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(281, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 170;
            this.label2.Text = "Tiền VC:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(41, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 168;
            this.label1.Text = "ĐG VC:";
            // 
            // cboBTKVatTu
            // 
            this.cboBTKVatTu.BackColor = System.Drawing.Color.White;
            this.cboBTKVatTu.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboBTKVatTu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBTKVatTu.ForeColor = System.Drawing.Color.Black;
            this.cboBTKVatTu.Location = new System.Drawing.Point(339, 134);
            this.cboBTKVatTu.Name = "cboBTKVatTu";
            this.cboBTKVatTu.Size = new System.Drawing.Size(190, 22);
            this.cboBTKVatTu.TabIndex = 7;
            this.cboBTKVatTu.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cboBTKVatTu.SelectedIndexChanged += new System.EventHandler(this.cboBTKVatTu_SelectedIndexChanged);
            this.cboBTKVatTu.Validated += new System.EventHandler(this.cboBTKVatTu_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(267, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 165;
            this.label9.Text = "Bãi tập kết:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(198, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 16);
            this.label5.TabIndex = 163;
            this.label5.Text = "(kg)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(32, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 161;
            this.label3.Text = "SL nhận:";
            // 
            // nSoLuongVatTu
            // 
            this.nSoLuongVatTu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nSoLuongVatTu.ForeColor = System.Drawing.Color.Red;
            this.nSoLuongVatTu.Location = new System.Drawing.Point(94, 134);
            this.nSoLuongVatTu.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nSoLuongVatTu.Name = "nSoLuongVatTu";
            this.nSoLuongVatTu.Size = new System.Drawing.Size(98, 22);
            this.nSoLuongVatTu.TabIndex = 5;
            this.nSoLuongVatTu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nSoLuongVatTu.ThousandsSeparator = true;
            this.nSoLuongVatTu.ValueChanged += new System.EventHandler(this.nSoLuongVatTu_ValueChanged);
            // 
            // pnDL
            // 
            this.pnDL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnDL.Controls.Add(this.grThongTin);
            this.pnDL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDL.Location = new System.Drawing.Point(0, 30);
            this.pnDL.Name = "pnDL";
            this.pnDL.Size = new System.Drawing.Size(546, 252);
            this.pnDL.TabIndex = 1;
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.cmdOK);
            this.pnBottom.Controls.Add(this.cmdExit);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 282);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(546, 36);
            this.pnBottom.TabIndex = 180;
            // 
            // frm_ThemSuaHopDongNhanVatTu
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(546, 318);
            this.Controls.Add(this.pnDL);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ThemSuaHopDongNhanVatTu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhận vật tư";
            this.grThongTin.ResumeLayout(false);
            this.grThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSoTienVatTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDGVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTienVC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDGVC)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnDL;
        private System.Windows.Forms.Panel pnBottom;
        private System.Windows.Forms.Label label9;
        private Janus.Windows.EditControls.UIComboBox cboBTKVatTu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTenVT;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.EditControls.UIButton cmdThemHoCapVT;
        private System.Windows.Forms.NumericUpDown nTienVC;
        private System.Windows.Forms.NumericUpDown nDGVC;
        private System.Windows.Forms.Label lblSoPhieu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nSoTienVatTu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nDGVT;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.EditControls.UIComboBox cboThon;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.NumericUpDown nSoLuongVatTu;
        public Janus.Windows.CalendarCombo.CalendarCombo dtNgayNhan;
    }
}