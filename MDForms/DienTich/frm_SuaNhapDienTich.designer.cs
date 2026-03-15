namespace MDSolution.MDForms.DienTich

{
    partial class frm_SuaNhapDienTich
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SuaNhapDienTich));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTenBai = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.grThongTin = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.nSLDK = new System.Windows.Forms.NumericUpDown();
            this.lblCBDB = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboKieuTrong = new Janus.Windows.EditControls.UIComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboLoaiGiong = new Janus.Windows.EditControls.UIComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboLoaiDat = new Janus.Windows.EditControls.UIComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtNgayTrong = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nDienTich = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.cboThon = new Janus.Windows.EditControls.UIComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmdThemNongHo = new Janus.Windows.EditControls.UIButton();
            this.cboBTK = new Janus.Windows.EditControls.UIComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnDL = new System.Windows.Forms.Panel();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.cmdOK = new Janus.Windows.EditControls.UIButton();
            this.cmdClose = new Janus.Windows.EditControls.UIButton();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTenXa = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTenThon = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtMaThuaRuong = new System.Windows.Forms.TextBox();
            this.grThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSLDK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDienTich)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(566, 30);
            this.lblTitle.TabIndex = 153;
            this.lblTitle.Text = "SỬA THÔNG TIN THỬA RUỘNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenBai
            // 
            this.lblTenBai.AutoSize = true;
            this.lblTenBai.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBai.ForeColor = System.Drawing.Color.Black;
            this.lblTenBai.Location = new System.Drawing.Point(28, 56);
            this.lblTenBai.Name = "lblTenBai";
            this.lblTenBai.Size = new System.Drawing.Size(66, 17);
            this.lblTenBai.TabIndex = 154;
            this.lblTenBai.Text = "Nông hộ:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.BackColor = System.Drawing.SystemColors.Info;
            this.txtHoTen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.ForeColor = System.Drawing.Color.Black;
            this.txtHoTen.Location = new System.Drawing.Point(90, 52);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(164, 26);
            this.txtHoTen.TabIndex = 155;
            this.txtHoTen.TabStop = false;
            // 
            // grThongTin
            // 
            this.grThongTin.Controls.Add(this.label16);
            this.grThongTin.Controls.Add(this.txtMaThuaRuong);
            this.grThongTin.Controls.Add(this.label15);
            this.grThongTin.Controls.Add(this.txtTenThon);
            this.grThongTin.Controls.Add(this.label14);
            this.grThongTin.Controls.Add(this.txtTenXa);
            this.grThongTin.Controls.Add(this.label12);
            this.grThongTin.Controls.Add(this.label13);
            this.grThongTin.Controls.Add(this.nSLDK);
            this.grThongTin.Controls.Add(this.lblCBDB);
            this.grThongTin.Controls.Add(this.label10);
            this.grThongTin.Controls.Add(this.label8);
            this.grThongTin.Controls.Add(this.cboKieuTrong);
            this.grThongTin.Controls.Add(this.label7);
            this.grThongTin.Controls.Add(this.cboLoaiGiong);
            this.grThongTin.Controls.Add(this.label4);
            this.grThongTin.Controls.Add(this.cboLoaiDat);
            this.grThongTin.Controls.Add(this.label2);
            this.grThongTin.Controls.Add(this.dtNgayTrong);
            this.grThongTin.Controls.Add(this.label6);
            this.grThongTin.Controls.Add(this.label5);
            this.grThongTin.Controls.Add(this.label3);
            this.grThongTin.Controls.Add(this.nDienTich);
            this.grThongTin.Controls.Add(this.label1);
            this.grThongTin.Controls.Add(this.txtMaHD);
            this.grThongTin.Controls.Add(this.cboThon);
            this.grThongTin.Controls.Add(this.label11);
            this.grThongTin.Controls.Add(this.cmdThemNongHo);
            this.grThongTin.Controls.Add(this.cboBTK);
            this.grThongTin.Controls.Add(this.label9);
            this.grThongTin.Controls.Add(this.txtHoTen);
            this.grThongTin.Controls.Add(this.lblTenBai);
            this.grThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grThongTin.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grThongTin.ForeColor = System.Drawing.Color.Maroon;
            this.grThongTin.Location = new System.Drawing.Point(0, 0);
            this.grThongTin.Name = "grThongTin";
            this.grThongTin.Size = new System.Drawing.Size(562, 334);
            this.grThongTin.TabIndex = 2;
            this.grThongTin.TabStop = false;
            this.grThongTin.Text = "Lựa chọn";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Maroon;
            this.label12.Location = new System.Drawing.Point(499, 277);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 20);
            this.label12.TabIndex = 204;
            this.label12.Text = "(tấn)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(324, 278);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 17);
            this.label13.TabIndex = 203;
            this.label13.Text = "SL Dự kiến:";
            // 
            // nSLDK
            // 
            this.nSLDK.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nSLDK.ForeColor = System.Drawing.Color.DarkBlue;
            this.nSLDK.Location = new System.Drawing.Point(400, 274);
            this.nSLDK.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nSLDK.Name = "nSLDK";
            this.nSLDK.Size = new System.Drawing.Size(92, 26);
            this.nSLDK.TabIndex = 13;
            this.nSLDK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nSLDK.ThousandsSeparator = true;
            // 
            // lblCBDB
            // 
            this.lblCBDB.AutoSize = true;
            this.lblCBDB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCBDB.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblCBDB.Location = new System.Drawing.Point(87, 22);
            this.lblCBDB.Name = "lblCBDB";
            this.lblCBDB.Size = new System.Drawing.Size(66, 24);
            this.lblCBDB.TabIndex = 201;
            this.lblCBDB.Text = "CBĐB";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(41, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 17);
            this.label10.TabIndex = 200;
            this.label10.Text = "CBĐB:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(340, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 17);
            this.label8.TabIndex = 199;
            this.label8.Text = "Lưu gốc:";
            // 
            // cboKieuTrong
            // 
            this.cboKieuTrong.BackColor = System.Drawing.Color.White;
            this.cboKieuTrong.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboKieuTrong.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKieuTrong.ForeColor = System.Drawing.Color.Black;
            this.cboKieuTrong.Location = new System.Drawing.Point(400, 236);
            this.cboKieuTrong.Name = "cboKieuTrong";
            this.cboKieuTrong.Size = new System.Drawing.Size(130, 26);
            this.cboKieuTrong.TabIndex = 12;
            this.cboKieuTrong.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(332, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 17);
            this.label7.TabIndex = 198;
            this.label7.Text = "Kiểu trồng";
            // 
            // cboLoaiGiong
            // 
            this.cboLoaiGiong.BackColor = System.Drawing.Color.White;
            this.cboLoaiGiong.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboLoaiGiong.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiGiong.ForeColor = System.Drawing.Color.Black;
            this.cboLoaiGiong.Location = new System.Drawing.Point(400, 198);
            this.cboLoaiGiong.Name = "cboLoaiGiong";
            this.cboLoaiGiong.Size = new System.Drawing.Size(130, 26);
            this.cboLoaiGiong.TabIndex = 11;
            this.cboLoaiGiong.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(327, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 196;
            this.label4.Text = "Loại giống:";
            // 
            // cboLoaiDat
            // 
            this.cboLoaiDat.BackColor = System.Drawing.Color.White;
            this.cboLoaiDat.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboLoaiDat.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiDat.ForeColor = System.Drawing.Color.Black;
            this.cboLoaiDat.Location = new System.Drawing.Point(400, 164);
            this.cboLoaiDat.Name = "cboLoaiDat";
            this.cboLoaiDat.Size = new System.Drawing.Size(130, 26);
            this.cboLoaiDat.TabIndex = 10;
            this.cboLoaiDat.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(341, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 194;
            this.label2.Text = "Loại đất:";
            // 
            // dtNgayTrong
            // 
            this.dtNgayTrong.CustomFormat = "dd/MM/yyyy";
            this.dtNgayTrong.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtNgayTrong.DropDownCalendar.Name = "";
            this.dtNgayTrong.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            this.dtNgayTrong.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayTrong.ForeColor = System.Drawing.Color.Black;
            this.dtNgayTrong.Location = new System.Drawing.Point(89, 274);
            this.dtNgayTrong.Name = "dtNgayTrong";
            this.dtNgayTrong.Nullable = true;
            this.dtNgayTrong.NullButtonText = "Rỗng";
            this.dtNgayTrong.ShowNullButton = true;
            this.dtNgayTrong.Size = new System.Drawing.Size(164, 26);
            this.dtNgayTrong.TabIndex = 9;
            this.dtNgayTrong.TodayButtonText = "Hôm nay";
            this.dtNgayTrong.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(15, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 192;
            this.label6.Text = "Ngày trồng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(183, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 190;
            this.label5.Text = "(ha)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(26, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 189;
            this.label3.Text = "Diện tích:";
            // 
            // nDienTich
            // 
            this.nDienTich.DecimalPlaces = 2;
            this.nDienTich.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nDienTich.ForeColor = System.Drawing.Color.DarkBlue;
            this.nDienTich.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nDienTich.Location = new System.Drawing.Point(89, 238);
            this.nDienTich.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nDienTich.Name = "nDienTich";
            this.nDienTich.Size = new System.Drawing.Size(90, 26);
            this.nDienTich.TabIndex = 8;
            this.nDienTich.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nDienTich.ThousandsSeparator = true;
            this.nDienTich.ValueChanged += new System.EventHandler(this.nSoLuongVatTu_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(38, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 187;
            this.label1.Text = "Mã HĐ:";
            // 
            // txtMaHD
            // 
            this.txtMaHD.BackColor = System.Drawing.SystemColors.Info;
            this.txtMaHD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHD.ForeColor = System.Drawing.Color.Black;
            this.txtMaHD.Location = new System.Drawing.Point(90, 88);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(164, 26);
            this.txtMaHD.TabIndex = 186;
            this.txtMaHD.TabStop = false;
            // 
            // cboThon
            // 
            this.cboThon.BackColor = System.Drawing.Color.White;
            this.cboThon.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboThon.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThon.ForeColor = System.Drawing.Color.Black;
            this.cboThon.Location = new System.Drawing.Point(89, 167);
            this.cboThon.Name = "cboThon";
            this.cboThon.Size = new System.Drawing.Size(164, 26);
            this.cboThon.TabIndex = 6;
            this.cboThon.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cboThon.SelectedIndexChanged += new System.EventHandler(this.cboThon_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(22, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 17);
            this.label11.TabIndex = 185;
            this.label11.Text = "Thôn/bản:";
            // 
            // cmdThemNongHo
            // 
            this.cmdThemNongHo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThemNongHo.Location = new System.Drawing.Point(270, 52);
            this.cmdThemNongHo.Name = "cmdThemNongHo";
            this.cmdThemNongHo.Size = new System.Drawing.Size(38, 22);
            this.cmdThemNongHo.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Black;
            this.cmdThemNongHo.TabIndex = 3;
            this.cmdThemNongHo.Text = "...";
            this.cmdThemNongHo.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdThemNongHo.Click += new System.EventHandler(this.cmdThemNongHo_Click);
            // 
            // cboBTK
            // 
            this.cboBTK.BackColor = System.Drawing.Color.White;
            this.cboBTK.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboBTK.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBTK.ForeColor = System.Drawing.Color.Black;
            this.cboBTK.Location = new System.Drawing.Point(89, 203);
            this.cboBTK.Name = "cboBTK";
            this.cboBTK.Size = new System.Drawing.Size(164, 26);
            this.cboBTK.TabIndex = 7;
            this.cboBTK.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(17, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 17);
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
            this.pnDL.Size = new System.Drawing.Size(566, 338);
            this.pnDL.TabIndex = 1;
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.cmdOK);
            this.pnBottom.Controls.Add(this.cmdClose);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 368);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(566, 36);
            this.pnBottom.TabIndex = 18;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdOK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Icon = ((System.Drawing.Icon)(resources.GetObject("cmdOK.Icon")));
            this.cmdOK.Location = new System.Drawing.Point(17, 5);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(83, 28);
            this.cmdOK.TabIndex = 19;
            this.cmdOK.Text = "Lưu";
            this.cmdOK.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.Location = new System.Drawing.Point(471, 5);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(83, 28);
            this.cmdClose.TabIndex = 20;
            this.cmdClose.Text = "Thoát";
            this.cmdClose.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdClose.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(282, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 17);
            this.label14.TabIndex = 206;
            this.label14.Text = "Tên xã";
            // 
            // txtTenXa
            // 
            this.txtTenXa.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTenXa.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenXa.ForeColor = System.Drawing.Color.Black;
            this.txtTenXa.Location = new System.Drawing.Point(334, 88);
            this.txtTenXa.Name = "txtTenXa";
            this.txtTenXa.ReadOnly = true;
            this.txtTenXa.Size = new System.Drawing.Size(218, 26);
            this.txtTenXa.TabIndex = 205;
            this.txtTenXa.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(18, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 17);
            this.label15.TabIndex = 208;
            this.label15.Text = "Tên thôn";
            // 
            // txtTenThon
            // 
            this.txtTenThon.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTenThon.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenThon.ForeColor = System.Drawing.Color.Black;
            this.txtTenThon.Location = new System.Drawing.Point(90, 126);
            this.txtTenThon.Name = "txtTenThon";
            this.txtTenThon.ReadOnly = true;
            this.txtTenThon.Size = new System.Drawing.Size(186, 26);
            this.txtTenThon.TabIndex = 207;
            this.txtTenThon.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(282, 130);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 17);
            this.label16.TabIndex = 210;
            this.label16.Text = "Mã TR";
            // 
            // txtMaThuaRuong
            // 
            this.txtMaThuaRuong.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMaThuaRuong.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaThuaRuong.ForeColor = System.Drawing.Color.Black;
            this.txtMaThuaRuong.Location = new System.Drawing.Point(334, 126);
            this.txtMaThuaRuong.Name = "txtMaThuaRuong";
            this.txtMaThuaRuong.ReadOnly = true;
            this.txtMaThuaRuong.Size = new System.Drawing.Size(218, 26);
            this.txtMaThuaRuong.TabIndex = 209;
            this.txtMaThuaRuong.TabStop = false;
            // 
            // frm_SuaNhapDienTich
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(566, 404);
            this.Controls.Add(this.pnDL);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_SuaNhapDienTich";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Diện tích";
            this.Load += new System.EventHandler(this.frm_SuaNhapDienTich_Load);
            this.grThongTin.ResumeLayout(false);
            this.grThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSLDK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDienTich)).EndInit();
            this.pnDL.ResumeLayout(false);
            this.pnBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTenBai;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.GroupBox grThongTin;
        private System.Windows.Forms.Panel pnDL;
        private System.Windows.Forms.Panel pnBottom;
        private System.Windows.Forms.Label label9;
        private Janus.Windows.EditControls.UIComboBox cboBTK;
        private Janus.Windows.EditControls.UIButton cmdThemNongHo;
        private Janus.Windows.EditControls.UIComboBox cboThon;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nDienTich;
        private Janus.Windows.CalendarCombo.CalendarCombo dtNgayTrong;
        private System.Windows.Forms.Label lblCBDB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private Janus.Windows.EditControls.UIComboBox cboKieuTrong;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.EditControls.UIComboBox cboLoaiGiong;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.EditControls.UIComboBox cboLoaiDat;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.EditControls.UIButton cmdClose;
        private Janus.Windows.EditControls.UIButton cmdOK;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nSLDK;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtMaThuaRuong;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTenThon;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTenXa;
    }
}