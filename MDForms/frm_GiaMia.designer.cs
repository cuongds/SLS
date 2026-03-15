namespace MDSolution
{
    partial class frm_GiaMia
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
            Janus.Windows.GridEX.GridEXLayout gdThongBaoGia_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_GiaMia));
            Janus.Windows.GridEX.GridEXLayout gdGiaMiaChay_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            this.grTB = new System.Windows.Forms.GroupBox();
            this.gdThongBaoGia = new Janus.Windows.GridEX.GridEX();
            this.grChitietTB_Gia = new System.Windows.Forms.GroupBox();
            this.gdGiaMiaChay = new Janus.Windows.GridEX.GridEX();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.pnMedium = new System.Windows.Forms.Panel();
            this.tabGiaMia = new System.Windows.Forms.TabControl();
            this.tabMiaTuoi = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmdChiTetTB = new System.Windows.Forms.Button();
            this.cmdThem = new System.Windows.Forms.Button();
            this.grTB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdThongBaoGia)).BeginInit();
            this.grChitietTB_Gia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdGiaMiaChay)).BeginInit();
            this.pnTop.SuspendLayout();
            this.pnMedium.SuspendLayout();
            this.tabGiaMia.SuspendLayout();
            this.tabMiaTuoi.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // grTB
            // 
            this.grTB.Controls.Add(this.gdThongBaoGia);
            this.grTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grTB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grTB.ForeColor = System.Drawing.Color.Green;
            this.grTB.Location = new System.Drawing.Point(0, 0);
            this.grTB.Name = "grTB";
            this.grTB.Size = new System.Drawing.Size(562, 324);
            this.grTB.TabIndex = 12;
            this.grTB.TabStop = false;
            this.grTB.Text = "Thông báo giá";
            // 
            // gdThongBaoGia
            // 
            this.gdThongBaoGia.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdThongBaoGia.AutoEdit = true;
            this.gdThongBaoGia.CardColumnHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdThongBaoGia.ColumnAutoResize = true;
            this.gdThongBaoGia.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader;
            this.gdThongBaoGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdThongBaoGia.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdThongBaoGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdThongBaoGia.FrozenColumns = 2;
            this.gdThongBaoGia.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdThongBaoGia.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdThongBaoGia.GroupByBoxVisible = false;
            this.gdThongBaoGia.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            gdThongBaoGia_Layout_0.IsCurrentLayout = true;
            gdThongBaoGia_Layout_0.Key = "tbl_NhapMia";
            gdThongBaoGia_Layout_0.LayoutString = resources.GetString("gdThongBaoGia_Layout_0.LayoutString");
            this.gdThongBaoGia.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdThongBaoGia_Layout_0});
            this.gdThongBaoGia.Location = new System.Drawing.Point(3, 18);
            this.gdThongBaoGia.Name = "gdThongBaoGia";
            this.gdThongBaoGia.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdThongBaoGia.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdThongBaoGia.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdThongBaoGia.ScrollBarWidth = 17;
            this.gdThongBaoGia.SelectedFormatStyle.BackColor = System.Drawing.Color.MediumAquamarine;
            this.gdThongBaoGia.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdThongBaoGia.Size = new System.Drawing.Size(556, 303);
            this.gdThongBaoGia.TabIndex = 7;
            this.gdThongBaoGia.TotalRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdThongBaoGia.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdThongBaoGia.TotalRowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
            this.gdThongBaoGia.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdThongBaoGia.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2005;
            this.gdThongBaoGia.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdMainGrid_ColumnButtonClick);
            this.gdThongBaoGia.SelectionChanged += new System.EventHandler(this.gdThongBaoGia_SelectionChanged);
            // 
            // grChitietTB_Gia
            // 
            this.grChitietTB_Gia.BackColor = System.Drawing.Color.Transparent;
            this.grChitietTB_Gia.Controls.Add(this.gdGiaMiaChay);
            this.grChitietTB_Gia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grChitietTB_Gia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grChitietTB_Gia.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grChitietTB_Gia.ForeColor = System.Drawing.Color.Green;
            this.grChitietTB_Gia.Location = new System.Drawing.Point(0, 0);
            this.grChitietTB_Gia.Name = "grChitietTB_Gia";
            this.grChitietTB_Gia.Size = new System.Drawing.Size(352, 324);
            this.grChitietTB_Gia.TabIndex = 17;
            this.grChitietTB_Gia.TabStop = false;
            this.grChitietTB_Gia.Text = "Thang giá mía cháy";
            // 
            // gdGiaMiaChay
            // 
            this.gdGiaMiaChay.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdGiaMiaChay.AutoEdit = true;
            this.gdGiaMiaChay.CardColumnHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdGiaMiaChay.ColumnAutoResize = true;
            this.gdGiaMiaChay.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader;
            this.gdGiaMiaChay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdGiaMiaChay.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdGiaMiaChay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdGiaMiaChay.FrozenColumns = 2;
            this.gdGiaMiaChay.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdGiaMiaChay.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdGiaMiaChay.GroupByBoxVisible = false;
            this.gdGiaMiaChay.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            gdGiaMiaChay_Layout_0.IsCurrentLayout = true;
            gdGiaMiaChay_Layout_0.Key = "tbl_NhapMia";
            gdGiaMiaChay_Layout_0.LayoutString = resources.GetString("gdGiaMiaChay_Layout_0.LayoutString");
            this.gdGiaMiaChay.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdGiaMiaChay_Layout_0});
            this.gdGiaMiaChay.Location = new System.Drawing.Point(3, 19);
            this.gdGiaMiaChay.Name = "gdGiaMiaChay";
            this.gdGiaMiaChay.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdGiaMiaChay.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.gdGiaMiaChay.ScrollBarWidth = 17;
            this.gdGiaMiaChay.SelectedFormatStyle.BackColor = System.Drawing.Color.DarkKhaki;
            this.gdGiaMiaChay.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdGiaMiaChay.Size = new System.Drawing.Size(346, 302);
            this.gdGiaMiaChay.TabIndex = 8;
            this.gdGiaMiaChay.TotalRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdGiaMiaChay.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdGiaMiaChay.TotalRowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
            this.gdGiaMiaChay.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdGiaMiaChay.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2005;
            this.gdGiaMiaChay.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdChiThietThongBaoGia_ColumnButtonClick);
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lblTitle);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(944, 41);
            this.pnTop.TabIndex = 21;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(944, 41);
            this.lblTitle.TabIndex = 148;
            this.lblTitle.Text = "THIẾT LẬP GIÁ NHẬP MÍA VỤ ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(461, 8);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 35);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Close (Esc)";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // pnMedium
            // 
            this.pnMedium.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnMedium.Controls.Add(this.tabGiaMia);
            this.pnMedium.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMedium.Location = new System.Drawing.Point(0, 41);
            this.pnMedium.Name = "pnMedium";
            this.pnMedium.Size = new System.Drawing.Size(944, 459);
            this.pnMedium.TabIndex = 23;
            // 
            // tabGiaMia
            // 
            this.tabGiaMia.Controls.Add(this.tabMiaTuoi);
            this.tabGiaMia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGiaMia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabGiaMia.Location = new System.Drawing.Point(0, 0);
            this.tabGiaMia.Name = "tabGiaMia";
            this.tabGiaMia.SelectedIndex = 0;
            this.tabGiaMia.Size = new System.Drawing.Size(940, 455);
            this.tabGiaMia.TabIndex = 0;
            this.tabGiaMia.SelectedIndexChanged += new System.EventHandler(this.tabGiaMia_SelectedIndexChanged);
            // 
            // tabMiaTuoi
            // 
            this.tabMiaTuoi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabMiaTuoi.Controls.Add(this.panel2);
            this.tabMiaTuoi.Controls.Add(this.panel1);
            this.tabMiaTuoi.Controls.Add(this.panel6);
            this.tabMiaTuoi.Controls.Add(this.panel5);
            this.tabMiaTuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMiaTuoi.ForeColor = System.Drawing.SystemColors.Desktop;
            this.tabMiaTuoi.Location = new System.Drawing.Point(4, 28);
            this.tabMiaTuoi.Name = "tabMiaTuoi";
            this.tabMiaTuoi.Padding = new System.Windows.Forms.Padding(3);
            this.tabMiaTuoi.Size = new System.Drawing.Size(932, 423);
            this.tabMiaTuoi.TabIndex = 0;
            this.tabMiaTuoi.Text = "Thiết lập giá nhập mía";
            this.tabMiaTuoi.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.grChitietTB_Gia);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(569, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(356, 328);
            this.panel2.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.grTB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 328);
            this.panel1.TabIndex = 19;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(922, 34);
            this.panel6.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(922, 34);
            this.label1.TabIndex = 149;
            this.label1.Text = "THIẾT LẬP GIÁ NHẬP MÍA THEO THÔNG BÁO GIÁ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cmdChiTetTB);
            this.panel5.Controls.Add(this.cmdThem);
            this.panel5.Controls.Add(this.cmdCancel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 365);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(922, 51);
            this.panel5.TabIndex = 13;
            // 
            // cmdChiTetTB
            // 
            this.cmdChiTetTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdChiTetTB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdChiTetTB.Image = ((System.Drawing.Image)(resources.GetObject("cmdChiTetTB.Image")));
            this.cmdChiTetTB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdChiTetTB.Location = new System.Drawing.Point(680, 7);
            this.cmdChiTetTB.Name = "cmdChiTetTB";
            this.cmdChiTetTB.Size = new System.Drawing.Size(144, 35);
            this.cmdChiTetTB.TabIndex = 19;
            this.cmdChiTetTB.Text = "Thêm giá mía cháy";
            this.cmdChiTetTB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdChiTetTB.UseVisualStyleBackColor = true;
            this.cmdChiTetTB.Click += new System.EventHandler(this.cmdChiTetTB_Click);
            // 
            // cmdThem
            // 
            this.cmdThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdThem.Image = ((System.Drawing.Image)(resources.GetObject("cmdThem.Image")));
            this.cmdThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdThem.Location = new System.Drawing.Point(130, 7);
            this.cmdThem.Name = "cmdThem";
            this.cmdThem.Size = new System.Drawing.Size(110, 35);
            this.cmdThem.TabIndex = 18;
            this.cmdThem.Text = "Thêm TB Giá";
            this.cmdThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdThem.UseVisualStyleBackColor = true;
            this.cmdThem.Click += new System.EventHandler(this.cmdThem_Click);
            // 
            // frm_GiaMia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(944, 500);
            this.Controls.Add(this.pnMedium);
            this.Controls.Add(this.pnTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_GiaMia";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Giá nhập mía";
            this.Load += new System.EventHandler(this.frm_GiaMia_Load);
            this.grTB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdThongBaoGia)).EndInit();
            this.grChitietTB_Gia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdGiaMiaChay)).EndInit();
            this.pnTop.ResumeLayout(false);
            this.pnMedium.ResumeLayout(false);
            this.tabGiaMia.ResumeLayout(false);
            this.tabMiaTuoi.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.GroupBox grTB;
        private System.Windows.Forms.GroupBox grChitietTB_Gia;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel pnMedium;
        private System.Windows.Forms.TabControl tabGiaMia;
        private System.Windows.Forms.TabPage tabMiaTuoi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button cmdThem;
        internal Janus.Windows.GridEX.GridEX gdThongBaoGia;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        internal Janus.Windows.GridEX.GridEX gdGiaMiaChay;
        private System.Windows.Forms.Button cmdChiTetTB;
    }
}