namespace MDSolution
{
    partial class frmNhapMia
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapMia));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSoXe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdXeChuaCan = new System.Windows.Forms.Button();
            this.txtHoTenKHVC = new System.Windows.Forms.TextBox();
            this.txtHopDongVC = new System.Windows.Forms.TextBox();
            this.cmdFindHDVC = new System.Windows.Forms.Button();
            this.cboBaiBocXep = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCan = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSoHopDong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdFindHopDong = new System.Windows.Forms.Button();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboGiaMia = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.txtTrongLuongTapVat = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTiLeTapVat = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTrongLuongMia = new System.Windows.Forms.TextBox();
            this.txtTrongLuongCan = new System.Windows.Forms.TextBox();
            this.txtCanXe = new System.Windows.Forms.TextBox();
            this.cmdCanXe = new System.Windows.Forms.Button();
            this.cmdCanMia = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCanMia = new System.Windows.Forms.TextBox();
            this.lblGioNhap = new System.Windows.Forms.Label();
            this.lbl_kieucan = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Timer(this.components);
            this.txtMaKhach = new System.Windows.Forms.TextBox();
            this.txtMaKhachVC = new System.Windows.Forms.TextBox();
            this.cmdThoat = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdInPhieu = new System.Windows.Forms.Button();
            this.cmdAddHopDong = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTongTL = new System.Windows.Forms.Label();
            this.lblSoHDGhep = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboSoXe);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmdXeChuaCan);
            this.groupBox1.Controls.Add(this.txtHoTenKHVC);
            this.groupBox1.Controls.Add(this.txtHopDongVC);
            this.groupBox1.Controls.Add(this.cmdFindHDVC);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khách vận chuyển";
            // 
            // cboSoXe
            // 
            this.cboSoXe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboSoXe.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSoXe.DisplayMember = "TEN";
            this.cboSoXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSoXe.FormattingEnabled = true;
            this.cboSoXe.Location = new System.Drawing.Point(82, 96);
            this.cboSoXe.Name = "cboSoXe";
            this.cboSoXe.Size = new System.Drawing.Size(144, 32);
            this.cboSoXe.TabIndex = 1;
            this.cboSoXe.ValueMember = "ID";
            this.cboSoXe.SelectedIndexChanged += new System.EventHandler(this.cboSoXe_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Họ và Tên";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Số xe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số HĐVC(F1)";
            // 
            // cmdXeChuaCan
            // 
            this.cmdXeChuaCan.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmdXeChuaCan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdXeChuaCan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdXeChuaCan.ForeColor = System.Drawing.Color.Black;
            this.cmdXeChuaCan.Image = global::MDSolution.Properties.Resources.icon_truck;
            this.cmdXeChuaCan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdXeChuaCan.Location = new System.Drawing.Point(232, 97);
            this.cmdXeChuaCan.Name = "cmdXeChuaCan";
            this.cmdXeChuaCan.Size = new System.Drawing.Size(126, 31);
            this.cmdXeChuaCan.TabIndex = 779;
            this.cmdXeChuaCan.Text = "Cân &bì(F4)";
            this.cmdXeChuaCan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdXeChuaCan.UseVisualStyleBackColor = false;
            this.cmdXeChuaCan.Click += new System.EventHandler(this.cmdXeChuaCan_Click);
            // 
            // txtHoTenKHVC
            // 
            this.txtHoTenKHVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTenKHVC.Location = new System.Drawing.Point(82, 58);
            this.txtHoTenKHVC.Name = "txtHoTenKHVC";
            this.txtHoTenKHVC.ReadOnly = true;
            this.txtHoTenKHVC.Size = new System.Drawing.Size(216, 29);
            this.txtHoTenKHVC.TabIndex = 333;
            // 
            // txtHopDongVC
            // 
            this.txtHopDongVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHopDongVC.Location = new System.Drawing.Point(82, 20);
            this.txtHopDongVC.Name = "txtHopDongVC";
            this.txtHopDongVC.ReadOnly = true;
            this.txtHopDongVC.Size = new System.Drawing.Size(144, 29);
            this.txtHopDongVC.TabIndex = 0;
            this.txtHopDongVC.TextChanged += new System.EventHandler(this.txtHopDongVC_TextChanged);
            // 
            // cmdFindHDVC
            // 
            this.cmdFindHDVC.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmdFindHDVC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFindHDVC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFindHDVC.ForeColor = System.Drawing.Color.Black;
            this.cmdFindHDVC.Image = global::MDSolution.Properties.Resources.buscar_red__10_;
            this.cmdFindHDVC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFindHDVC.Location = new System.Drawing.Point(232, 20);
            this.cmdFindHDVC.Name = "cmdFindHDVC";
            this.cmdFindHDVC.Size = new System.Drawing.Size(79, 29);
            this.cmdFindHDVC.TabIndex = 778;
            this.cmdFindHDVC.Text = "Tì&m(F2)";
            this.cmdFindHDVC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFindHDVC.UseVisualStyleBackColor = false;
            this.cmdFindHDVC.Click += new System.EventHandler(this.cmdFindHDVC_Click);
            // 
            // cboBaiBocXep
            // 
            this.cboBaiBocXep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboBaiBocXep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBaiBocXep.DisplayMember = "TEN";
            this.cboBaiBocXep.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBaiBocXep.FormattingEnabled = true;
            this.cboBaiBocXep.Location = new System.Drawing.Point(82, 90);
            this.cboBaiBocXep.Name = "cboBaiBocXep";
            this.cboBaiBocXep.Size = new System.Drawing.Size(216, 32);
            this.cboBaiBocXep.TabIndex = 3;
            this.cboBaiBocXep.ValueMember = "ID";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(7, 99);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 16;
            this.label19.Text = "Bãi tập kết";
            // 
            // txtCan
            // 
            this.txtCan.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtCan.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCan.ForeColor = System.Drawing.Color.Cyan;
            this.txtCan.Location = new System.Drawing.Point(1, 41);
            this.txtCan.Name = "txtCan";
            this.txtCan.ReadOnly = true;
            this.txtCan.Size = new System.Drawing.Size(809, 85);
            this.txtCan.TabIndex = 110;
            this.txtCan.Text = "0";
            this.txtCan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCan.TextChanged += new System.EventHandler(this.txtCan_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboBaiBocXep);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtHoTen);
            this.groupBox2.Controls.Add(this.txtSoHopDong);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmdFindHopDong);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 133);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Khách hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Họ và Tên";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(82, 54);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(216, 29);
            this.txtHoTen.TabIndex = 444;
            // 
            // txtSoHopDong
            // 
            this.txtSoHopDong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSoHopDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoHopDong.Location = new System.Drawing.Point(82, 19);
            this.txtSoHopDong.Name = "txtSoHopDong";
            this.txtSoHopDong.Size = new System.Drawing.Size(144, 29);
            this.txtSoHopDong.TabIndex = 2;
            this.txtSoHopDong.TextChanged += new System.EventHandler(this.txtSoHopDong_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số HĐ(F5)";
            // 
            // cmdFindHopDong
            // 
            this.cmdFindHopDong.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmdFindHopDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFindHopDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFindHopDong.ForeColor = System.Drawing.Color.Black;
            this.cmdFindHopDong.Image = global::MDSolution.Properties.Resources.buscar_red__10_;
            this.cmdFindHopDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFindHopDong.Location = new System.Drawing.Point(232, 19);
            this.cmdFindHopDong.Name = "cmdFindHopDong";
            this.cmdFindHopDong.Size = new System.Drawing.Size(79, 29);
            this.cmdFindHopDong.TabIndex = 678;
            this.cmdFindHopDong.Text = "&Tìm(F3)";
            this.cmdFindHopDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFindHopDong.UseVisualStyleBackColor = false;
            this.cmdFindHopDong.Click += new System.EventHandler(this.cmdFindHopDong_Click);
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayNhap.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblNgayNhap.Location = new System.Drawing.Point(526, 134);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(147, 15);
            this.lblNgayNhap.TabIndex = 5;
            this.lblNgayNhap.Text = "Ngày nhập: 20/9/2008";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboGiaMia);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtThanhTien);
            this.groupBox4.Controls.Add(this.txtTrongLuongTapVat);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtTiLeTapVat);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtTrongLuongMia);
            this.groupBox4.Controls.Add(this.txtTrongLuongCan);
            this.groupBox4.Controls.Add(this.txtCanXe);
            this.groupBox4.Controls.Add(this.cmdCanXe);
            this.groupBox4.Controls.Add(this.cmdCanMia);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtCanMia);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(392, 152);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(405, 287);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Trọng lượng";
            // 
            // cboGiaMia
            // 
            this.cboGiaMia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGiaMia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGiaMia.DisplayMember = "TEN";
            this.cboGiaMia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGiaMia.FormattingEnabled = true;
            this.cboGiaMia.Location = new System.Drawing.Point(9, 233);
            this.cboGiaMia.Name = "cboGiaMia";
            this.cboGiaMia.Size = new System.Drawing.Size(132, 32);
            this.cboGiaMia.TabIndex = 5;
            this.cboGiaMia.ValueMember = "ID";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(144, 213);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 18;
            this.label16.Text = "Thành tiền";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(8, 213);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 16;
            this.label17.Text = "Giá mía(F7)";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 186);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "Trọng lượng mía sạch";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 156);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Trọng lượng qua cân";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(144, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Trọng lượng tạp vật";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThanhTien.Location = new System.Drawing.Point(147, 236);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(229, 29);
            this.txtThanhTien.TabIndex = 16;
            this.txtThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTrongLuongTapVat
            // 
            this.txtTrongLuongTapVat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrongLuongTapVat.Location = new System.Drawing.Point(147, 107);
            this.txtTrongLuongTapVat.Name = "txtTrongLuongTapVat";
            this.txtTrongLuongTapVat.ReadOnly = true;
            this.txtTrongLuongTapVat.Size = new System.Drawing.Size(229, 29);
            this.txtTrongLuongTapVat.TabIndex = 12;
            this.txtTrongLuongTapVat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(57, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "% Tạp vật(F6)";
            // 
            // txtTiLeTapVat
            // 
            this.txtTiLeTapVat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTiLeTapVat.Location = new System.Drawing.Point(60, 107);
            this.txtTiLeTapVat.Name = "txtTiLeTapVat";
            this.txtTiLeTapVat.Size = new System.Drawing.Size(81, 29);
            this.txtTiLeTapVat.TabIndex = 4;
            this.txtTiLeTapVat.TextChanged += new System.EventHandler(this.txtTiLeTapVat_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "TL xe";
            // 
            // txtTrongLuongMia
            // 
            this.txtTrongLuongMia.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtTrongLuongMia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrongLuongMia.ForeColor = System.Drawing.Color.Cyan;
            this.txtTrongLuongMia.Location = new System.Drawing.Point(147, 177);
            this.txtTrongLuongMia.Name = "txtTrongLuongMia";
            this.txtTrongLuongMia.ReadOnly = true;
            this.txtTrongLuongMia.Size = new System.Drawing.Size(229, 29);
            this.txtTrongLuongMia.TabIndex = 14;
            this.txtTrongLuongMia.Text = "0";
            this.txtTrongLuongMia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTrongLuongMia.TextChanged += new System.EventHandler(this.txtTrongLuongMia_TextChanged);
            // 
            // txtTrongLuongCan
            // 
            this.txtTrongLuongCan.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtTrongLuongCan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrongLuongCan.ForeColor = System.Drawing.Color.Cyan;
            this.txtTrongLuongCan.Location = new System.Drawing.Point(147, 143);
            this.txtTrongLuongCan.Name = "txtTrongLuongCan";
            this.txtTrongLuongCan.ReadOnly = true;
            this.txtTrongLuongCan.Size = new System.Drawing.Size(229, 29);
            this.txtTrongLuongCan.TabIndex = 13;
            this.txtTrongLuongCan.Text = "0";
            this.txtTrongLuongCan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTrongLuongCan.TextChanged += new System.EventHandler(this.txtTrongLuongCan_TextChanged);
            // 
            // txtCanXe
            // 
            this.txtCanXe.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtCanXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCanXe.ForeColor = System.Drawing.Color.Cyan;
            this.txtCanXe.Location = new System.Drawing.Point(60, 56);
            this.txtCanXe.Name = "txtCanXe";
            this.txtCanXe.Size = new System.Drawing.Size(258, 29);
            this.txtCanXe.TabIndex = 19;
            this.txtCanXe.Text = "0";
            this.txtCanXe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCanXe.TextChanged += new System.EventHandler(this.txtCanXe_TextChanged);
            // 
            // cmdCanXe
            // 
            this.cmdCanXe.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmdCanXe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCanXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCanXe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cmdCanXe.Image = global::MDSolution.Properties.Resources.can1;
            this.cmdCanXe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCanXe.Location = new System.Drawing.Point(319, 56);
            this.cmdCanXe.Name = "cmdCanXe";
            this.cmdCanXe.Size = new System.Drawing.Size(80, 29);
            this.cmdCanXe.TabIndex = 6;
            this.cmdCanXe.Text = "Câ&n(F9)";
            this.cmdCanXe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCanXe.UseVisualStyleBackColor = false;
            this.cmdCanXe.Click += new System.EventHandler(this.cmdCanXe_Click);
            // 
            // cmdCanMia
            // 
            this.cmdCanMia.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmdCanMia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCanMia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCanMia.ForeColor = System.Drawing.Color.Red;
            this.cmdCanMia.Image = global::MDSolution.Properties.Resources.can1;
            this.cmdCanMia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCanMia.Location = new System.Drawing.Point(319, 17);
            this.cmdCanMia.Name = "cmdCanMia";
            this.cmdCanMia.Size = new System.Drawing.Size(80, 29);
            this.cmdCanMia.TabIndex = 6;
            this.cmdCanMia.Text = "&Cân(F8)";
            this.cmdCanMia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCanMia.UseVisualStyleBackColor = false;
            this.cmdCanMia.Click += new System.EventHandler(this.cmdCanMia_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Tổng TL";
            // 
            // txtCanMia
            // 
            this.txtCanMia.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtCanMia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCanMia.ForeColor = System.Drawing.Color.Cyan;
            this.txtCanMia.Location = new System.Drawing.Point(60, 17);
            this.txtCanMia.Name = "txtCanMia";
            this.txtCanMia.Size = new System.Drawing.Size(258, 29);
            this.txtCanMia.TabIndex = 9;
            this.txtCanMia.Text = "0";
            this.txtCanMia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCanMia.TextChanged += new System.EventHandler(this.txtCanMia_TextChanged);
            // 
            // lblGioNhap
            // 
            this.lblGioNhap.AutoSize = true;
            this.lblGioNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGioNhap.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblGioNhap.Location = new System.Drawing.Point(679, 134);
            this.lblGioNhap.Name = "lblGioNhap";
            this.lblGioNhap.Size = new System.Drawing.Size(125, 15);
            this.lblGioNhap.TabIndex = 5;
            this.lblGioNhap.Text = "Giờ nhập:11:24:00";
            // 
            // lbl_kieucan
            // 
            this.lbl_kieucan.AutoSize = true;
            this.lbl_kieucan.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_kieucan.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_kieucan.Location = new System.Drawing.Point(2, 9);
            this.lbl_kieucan.Name = "lbl_kieucan";
            this.lbl_kieucan.Size = new System.Drawing.Size(152, 25);
            this.lbl_kieucan.TabIndex = 1;
            this.lbl_kieucan.Text = "CÂN XE MÍA";
            // 
            // time
            // 
            this.time.Enabled = true;
            this.time.Tick += new System.EventHandler(this.time_Tick);
            // 
            // txtMaKhach
            // 
            this.txtMaKhach.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKhach.Location = new System.Drawing.Point(429, 452);
            this.txtMaKhach.Name = "txtMaKhach";
            this.txtMaKhach.ReadOnly = true;
            this.txtMaKhach.Size = new System.Drawing.Size(26, 33);
            this.txtMaKhach.TabIndex = 6;
            this.txtMaKhach.Visible = false;
            // 
            // txtMaKhachVC
            // 
            this.txtMaKhachVC.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKhachVC.Location = new System.Drawing.Point(398, 452);
            this.txtMaKhachVC.Name = "txtMaKhachVC";
            this.txtMaKhachVC.ReadOnly = true;
            this.txtMaKhachVC.Size = new System.Drawing.Size(26, 33);
            this.txtMaKhachVC.TabIndex = 1;
            this.txtMaKhachVC.Visible = false;
            // 
            // cmdThoat
            // 
            this.cmdThoat.BackColor = System.Drawing.Color.White;
            this.cmdThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThoat.Image = global::MDSolution.Properties.Resources.ICO_Symbol_Delete_06_16x16x32bit;
            this.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdThoat.Location = new System.Drawing.Point(732, 450);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(65, 32);
            this.cmdThoat.TabIndex = 19;
            this.cmdThoat.Text = "Th&oát";
            this.cmdThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdThoat.UseVisualStyleBackColor = false;
            // 
            // cmdNext
            // 
            this.cmdNext.BackColor = System.Drawing.Color.White;
            this.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNext.Image = global::MDSolution.Properties.Resources.Dumptruck;
            this.cmdNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNext.Location = new System.Drawing.Point(621, 450);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(106, 32);
            this.cmdNext.TabIndex = 17;
            this.cmdNext.Text = "&Xe tiếp(F12)";
            this.cmdNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdNext.UseVisualStyleBackColor = false;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // cmdInPhieu
            // 
            this.cmdInPhieu.BackColor = System.Drawing.Color.White;
            this.cmdInPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdInPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInPhieu.Image = global::MDSolution.Properties.Resources.impresora__10_;
            this.cmdInPhieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdInPhieu.Location = new System.Drawing.Point(508, 450);
            this.cmdInPhieu.Name = "cmdInPhieu";
            this.cmdInPhieu.Size = new System.Drawing.Size(107, 32);
            this.cmdInPhieu.TabIndex = 17;
            this.cmdInPhieu.Text = "&In phiếu(F11)";
            this.cmdInPhieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdInPhieu.UseVisualStyleBackColor = false;
            this.cmdInPhieu.Click += new System.EventHandler(this.cmdInPhieu_Click);
            // 
            // cmdAddHopDong
            // 
            this.cmdAddHopDong.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmdAddHopDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAddHopDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddHopDong.ForeColor = System.Drawing.Color.Black;
            this.cmdAddHopDong.Image = global::MDSolution.Properties.Resources.user;
            this.cmdAddHopDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAddHopDong.Location = new System.Drawing.Point(232, 14);
            this.cmdAddHopDong.Name = "cmdAddHopDong";
            this.cmdAddHopDong.Size = new System.Drawing.Size(122, 32);
            this.cmdAddHopDong.TabIndex = 33;
            this.cmdAddHopDong.Text = "Cân &ghép(F10)";
            this.cmdAddHopDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAddHopDong.UseVisualStyleBackColor = false;
            this.cmdAddHopDong.Click += new System.EventHandler(this.cmdAddHopDong_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmdAddHopDong);
            this.groupBox3.Controls.Add(this.lblTongTL);
            this.groupBox3.Controls.Add(this.lblSoHDGhep);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 431);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(364, 52);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin cân ghép";
            // 
            // lblTongTL
            // 
            this.lblTongTL.AutoSize = true;
            this.lblTongTL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTL.Location = new System.Drawing.Point(98, 24);
            this.lblTongTL.Name = "lblTongTL";
            this.lblTongTL.Size = new System.Drawing.Size(60, 13);
            this.lblTongTL.TabIndex = 16;
            this.lblTongTL.Text = "Tổng TL: 0";
            // 
            // lblSoHDGhep
            // 
            this.lblSoHDGhep.AutoSize = true;
            this.lblSoHDGhep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoHDGhep.Location = new System.Drawing.Point(7, 24);
            this.lblSoHDGhep.Name = "lblSoHDGhep";
            this.lblSoHDGhep.Size = new System.Drawing.Size(78, 13);
            this.lblSoHDGhep.TabIndex = 16;
            this.lblSoHDGhep.Text = "Số HĐ ghép: 0";
            // 
            // frmNhapMia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CancelButton = this.cmdThoat;
            this.ClientSize = new System.Drawing.Size(811, 489);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtCan);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.cmdNext);
            this.Controls.Add(this.cmdInPhieu);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblGioNhap);
            this.Controls.Add(this.txtMaKhach);
            this.Controls.Add(this.lblNgayNhap);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMaKhachVC);
            this.Controls.Add(this.lbl_kieucan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNhapMia";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập mía nguyên liệu";
            this.Load += new System.EventHandler(this.frmNhapMia_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button cmdCanMia;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCanMia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCanXe;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTrongLuongTapVat;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTiLeTapVat;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboGiaMia;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button cmdThoat;
        private System.Windows.Forms.Button cmdInPhieu;
        private System.Windows.Forms.Label lblGioNhap;
        private System.Windows.Forms.Button cmdCanXe;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.TextBox txtTrongLuongMia;
        private System.Windows.Forms.TextBox txtTrongLuongCan;
        private System.Windows.Forms.TextBox txtHoTenKHVC;
        private System.Windows.Forms.TextBox txtHopDongVC;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtSoHopDong;
        private System.Windows.Forms.Button cmdFindHDVC;
        private System.Windows.Forms.Button cmdFindHopDong;
        private System.Windows.Forms.Button cmdAddHopDong;
        private System.Windows.Forms.ComboBox cboSoXe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboBaiBocXep;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbl_kieucan;
        private System.Windows.Forms.Timer time;
        private System.Windows.Forms.TextBox txtMaKhachVC;
        private System.Windows.Forms.TextBox txtMaKhach;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdXeChuaCan;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTongTL;
        private System.Windows.Forms.Label lblSoHDGhep;
    }
}