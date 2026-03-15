namespace MDSolution.MDForms.HoTro
{
    partial class frm_ThemSuaHoTroLai
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
            this.lblUngVT = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grHTL = new System.Windows.Forms.GroupBox();
            this.nSoTienCon = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cboLoaiHT = new Janus.Windows.EditControls.UIComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nSoTien = new System.Windows.Forms.NumericUpDown();
            this.dtNgayUng = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.grDauTu = new System.Windows.Forms.GroupBox();
            this.lbl_laisuat = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_mahopdong = new System.Windows.Forms.Label();
            this.lbl_HoTen = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_tiendautu = new System.Windows.Forms.Label();
            this.lbl_ngaydautu = new System.Windows.Forms.Label();
            this.lbl_loaidautu = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grHTL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSoTienCon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSoTien)).BeginInit();
            this.grDauTu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUngVT
            // 
            this.lblUngVT.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUngVT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUngVT.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUngVT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUngVT.ForeColor = System.Drawing.Color.Navy;
            this.lblUngVT.Location = new System.Drawing.Point(0, 0);
            this.lblUngVT.Name = "lblUngVT";
            this.lblUngVT.Size = new System.Drawing.Size(625, 30);
            this.lblUngVT.TabIndex = 153;
            this.lblUngVT.Text = "NHẬP HỖ TRỢ LÃI ĐẦU TƯ";
            this.lblUngVT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(26, 9);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(90, 30);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Location = new System.Drawing.Point(512, 9);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(90, 30);
            this.cmdExit.TabIndex = 9;
            this.cmdExit.Text = "Cancel";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 314);
            this.panel1.TabIndex = 161;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grHTL, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grDauTu, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(621, 310);
            this.tableLayoutPanel1.TabIndex = 161;
            // 
            // grHTL
            // 
            this.grHTL.Controls.Add(this.nSoTienCon);
            this.grHTL.Controls.Add(this.label7);
            this.grHTL.Controls.Add(this.cboLoaiHT);
            this.grHTL.Controls.Add(this.label5);
            this.grHTL.Controls.Add(this.label4);
            this.grHTL.Controls.Add(this.nSoTien);
            this.grHTL.Controls.Add(this.dtNgayUng);
            this.grHTL.Controls.Add(this.label3);
            this.grHTL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grHTL.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grHTL.ForeColor = System.Drawing.Color.Maroon;
            this.grHTL.Location = new System.Drawing.Point(3, 158);
            this.grHTL.Name = "grHTL";
            this.grHTL.Size = new System.Drawing.Size(615, 149);
            this.grHTL.TabIndex = 160;
            this.grHTL.TabStop = false;
            this.grHTL.Text = "Nhập hỗ trợ lãi đầu cho đầu tư";
            // 
            // nSoTienCon
            // 
            this.nSoTienCon.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nSoTienCon.ForeColor = System.Drawing.Color.Black;
            this.nSoTienCon.Location = new System.Drawing.Point(409, 108);
            this.nSoTienCon.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nSoTienCon.Minimum = new decimal(new int[] {
            1410065408,
            2,
            0,
            -2147483648});
            this.nSoTienCon.Name = "nSoTienCon";
            this.nSoTienCon.ReadOnly = true;
            this.nSoTienCon.Size = new System.Drawing.Size(188, 22);
            this.nSoTienCon.TabIndex = 247;
            this.nSoTienCon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nSoTienCon.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(300, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 16);
            this.label7.TabIndex = 246;
            this.label7.Text = "Tiền còn tính lãi:";
            // 
            // cboLoaiHT
            // 
            this.cboLoaiHT.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboLoaiHT.ForeColor = System.Drawing.Color.Black;
            this.cboLoaiHT.Location = new System.Drawing.Point(88, 26);
            this.cboLoaiHT.MaxDropDownItems = 20;
            this.cboLoaiHT.Name = "cboLoaiHT";
            this.cboLoaiHT.SelectedItemFormatStyle.ForeColor = System.Drawing.Color.DarkBlue;
            this.cboLoaiHT.Size = new System.Drawing.Size(286, 22);
            this.cboLoaiHT.TabIndex = 2;
            this.cboLoaiHT.Text = "Chọn loại hỗ trợ";
            this.cboLoaiHT.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.cboLoaiHT.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(7, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 245;
            this.label5.Text = "Loại hỗ trợ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 244;
            this.label4.Text = "Số tiền:";
            // 
            // nSoTien
            // 
            this.nSoTien.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nSoTien.ForeColor = System.Drawing.Color.Black;
            this.nSoTien.Location = new System.Drawing.Point(88, 108);
            this.nSoTien.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nSoTien.Minimum = new decimal(new int[] {
            1410065408,
            2,
            0,
            -2147483648});
            this.nSoTien.Name = "nSoTien";
            this.nSoTien.Size = new System.Drawing.Size(188, 22);
            this.nSoTien.TabIndex = 7;
            this.nSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nSoTien.ThousandsSeparator = true;
            this.nSoTien.ValueChanged += new System.EventHandler(this.nSoTien_ValueChanged);
            // 
            // dtNgayUng
            // 
            this.dtNgayUng.CustomFormat = "dd/MM/yyyy";
            this.dtNgayUng.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtNgayUng.DropDownCalendar.Name = "";
            this.dtNgayUng.DropDownCalendar.Visible = false;
            this.dtNgayUng.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            this.dtNgayUng.Enabled = false;
            this.dtNgayUng.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayUng.ForeColor = System.Drawing.Color.Black;
            this.dtNgayUng.Location = new System.Drawing.Point(88, 68);
            this.dtNgayUng.Name = "dtNgayUng";
            this.dtNgayUng.ReadOnly = true;
            this.dtNgayUng.Size = new System.Drawing.Size(126, 22);
            this.dtNgayUng.TabIndex = 3;
            this.dtNgayUng.Value = new System.DateTime(2017, 8, 14, 0, 0, 0, 0);
            this.dtNgayUng.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 161;
            this.label3.Text = "Ngày nhập";
            // 
            // grDauTu
            // 
            this.grDauTu.Controls.Add(this.lbl_laisuat);
            this.grDauTu.Controls.Add(this.label8);
            this.grDauTu.Controls.Add(this.lbl_mahopdong);
            this.grDauTu.Controls.Add(this.lbl_HoTen);
            this.grDauTu.Controls.Add(this.label9);
            this.grDauTu.Controls.Add(this.label11);
            this.grDauTu.Controls.Add(this.label10);
            this.grDauTu.Controls.Add(this.lbl_tiendautu);
            this.grDauTu.Controls.Add(this.lbl_ngaydautu);
            this.grDauTu.Controls.Add(this.lbl_loaidautu);
            this.grDauTu.Controls.Add(this.label6);
            this.grDauTu.Controls.Add(this.label2);
            this.grDauTu.Controls.Add(this.label1);
            this.grDauTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDauTu.Location = new System.Drawing.Point(3, 3);
            this.grDauTu.Name = "grDauTu";
            this.grDauTu.Size = new System.Drawing.Size(615, 149);
            this.grDauTu.TabIndex = 161;
            this.grDauTu.TabStop = false;
            this.grDauTu.Text = "Thông tin đầu tư";
            // 
            // lbl_laisuat
            // 
            this.lbl_laisuat.AutoSize = true;
            this.lbl_laisuat.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_laisuat.ForeColor = System.Drawing.Color.Brown;
            this.lbl_laisuat.Location = new System.Drawing.Point(465, 104);
            this.lbl_laisuat.Name = "lbl_laisuat";
            this.lbl_laisuat.Size = new System.Drawing.Size(58, 16);
            this.lbl_laisuat.TabIndex = 258;
            this.lbl_laisuat.Text = "Lãi suất";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(362, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 16);
            this.label8.TabIndex = 257;
            this.label8.Text = "Lãi suất:";
            // 
            // lbl_mahopdong
            // 
            this.lbl_mahopdong.AutoSize = true;
            this.lbl_mahopdong.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mahopdong.ForeColor = System.Drawing.Color.Brown;
            this.lbl_mahopdong.Location = new System.Drawing.Point(465, 27);
            this.lbl_mahopdong.Name = "lbl_mahopdong";
            this.lbl_mahopdong.Size = new System.Drawing.Size(92, 16);
            this.lbl_mahopdong.TabIndex = 256;
            this.lbl_mahopdong.Text = "Mã hơp đồng";
            // 
            // lbl_HoTen
            // 
            this.lbl_HoTen.AutoSize = true;
            this.lbl_HoTen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HoTen.ForeColor = System.Drawing.Color.Brown;
            this.lbl_HoTen.Location = new System.Drawing.Point(102, 27);
            this.lbl_HoTen.Name = "lbl_HoTen";
            this.lbl_HoTen.Size = new System.Drawing.Size(49, 16);
            this.lbl_HoTen.TabIndex = 255;
            this.lbl_HoTen.Text = "Họ tên";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(362, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 16);
            this.label9.TabIndex = 254;
            this.label9.Text = "Mã hợp đồng:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(18, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 16);
            this.label11.TabIndex = 253;
            this.label11.Text = "Họ tên:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(224, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 16);
            this.label10.TabIndex = 252;
            this.label10.Text = "đồng";
            // 
            // lbl_tiendautu
            // 
            this.lbl_tiendautu.AutoSize = true;
            this.lbl_tiendautu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tiendautu.ForeColor = System.Drawing.Color.Brown;
            this.lbl_tiendautu.Location = new System.Drawing.Point(102, 104);
            this.lbl_tiendautu.Name = "lbl_tiendautu";
            this.lbl_tiendautu.Size = new System.Drawing.Size(102, 16);
            this.lbl_tiendautu.TabIndex = 251;
            this.lbl_tiendautu.Text = "Số tiền đầu tư:";
            // 
            // lbl_ngaydautu
            // 
            this.lbl_ngaydautu.AutoSize = true;
            this.lbl_ngaydautu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ngaydautu.ForeColor = System.Drawing.Color.Brown;
            this.lbl_ngaydautu.Location = new System.Drawing.Point(465, 62);
            this.lbl_ngaydautu.Name = "lbl_ngaydautu";
            this.lbl_ngaydautu.Size = new System.Drawing.Size(89, 16);
            this.lbl_ngaydautu.TabIndex = 250;
            this.lbl_ngaydautu.Text = "Ngày đầu tư:";
            // 
            // lbl_loaidautu
            // 
            this.lbl_loaidautu.AutoSize = true;
            this.lbl_loaidautu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_loaidautu.ForeColor = System.Drawing.Color.Brown;
            this.lbl_loaidautu.Location = new System.Drawing.Point(102, 62);
            this.lbl_loaidautu.Name = "lbl_loaidautu";
            this.lbl_loaidautu.Size = new System.Drawing.Size(81, 16);
            this.lbl_loaidautu.TabIndex = 249;
            this.lbl_loaidautu.Text = "Loại đầu tư";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(1, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 16);
            this.label6.TabIndex = 248;
            this.label6.Text = "Số tiền đầu tư:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(362, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 247;
            this.label2.Text = "Ngày đầu tư:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 246;
            this.label1.Text = "Loại đầu tư:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdOK);
            this.panel2.Controls.Add(this.cmdExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 344);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(625, 45);
            this.panel2.TabIndex = 162;
            // 
            // frm_ThemSuaHoTroLai
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(625, 389);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblUngVT);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ThemSuaHoTroLai";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hỗ trợ lãi đầu tư";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grHTL.ResumeLayout(false);
            this.grHTL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSoTienCon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSoTien)).EndInit();
            this.grDauTu.ResumeLayout(false);
            this.grDauTu.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUngVT;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grHTL;
        private Janus.Windows.EditControls.UIComboBox cboLoaiHT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nSoTien;
        private Janus.Windows.CalendarCombo.CalendarCombo dtNgayUng;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grDauTu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_tiendautu;
        private System.Windows.Forms.Label lbl_ngaydautu;
        private System.Windows.Forms.Label lbl_loaidautu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_mahopdong;
        private System.Windows.Forms.Label lbl_HoTen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_laisuat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nSoTienCon;
        private System.Windows.Forms.Label label7;
    }
}