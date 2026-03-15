namespace MDSolution.MDForms.NhapMiaGiong
{
    partial class MiaGiong_TuNgay_DenNgay
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
            Janus.Windows.GridEX.GridEXLayout grdMiaGiong_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiaGiong_TuNgay_DenNgay));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdMiaGiong = new Janus.Windows.GridEX.GridEX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboCanBoNV = new Janus.Windows.EditControls.UIComboBox();
            this.dtDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label9 = new System.Windows.Forms.Label();
            this.dtTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnInPhieu = new Janus.Windows.EditControls.UIButton();
            this.cmdAddHD = new Janus.Windows.EditControls.UIButton();
            this.btnXuatExcelHopDong = new Janus.Windows.EditControls.UIButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMiaGiong)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grdMiaGiong, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1090, 447);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grdMiaGiong
            // 
            this.grdMiaGiong.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdMiaGiong.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdMiaGiong.AlternatingColors = true;
            this.grdMiaGiong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMiaGiong.AutoEdit = true;
            this.grdMiaGiong.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
                "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            this.grdMiaGiong.ColumnAutoResize = true;
            grdMiaGiong_DesignTimeLayout.LayoutString = resources.GetString("grdMiaGiong_DesignTimeLayout.LayoutString");
            this.grdMiaGiong.DesignTimeLayout = grdMiaGiong_DesignTimeLayout;
            this.grdMiaGiong.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.grdMiaGiong.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdMiaGiong.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdMiaGiong.FlatBorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdMiaGiong.Font = new System.Drawing.Font("Arial", 9F);
            this.grdMiaGiong.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.grdMiaGiong.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdMiaGiong.GroupByBoxVisible = false;
            this.grdMiaGiong.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdMiaGiong.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdMiaGiong.Location = new System.Drawing.Point(3, 68);
            this.grdMiaGiong.Name = "grdMiaGiong";
            this.grdMiaGiong.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdMiaGiong.NewRowFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.grdMiaGiong.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdMiaGiong.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.grdMiaGiong.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.grdMiaGiong.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.grdMiaGiong.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.grdMiaGiong.RowHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdMiaGiong.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdMiaGiong.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both;
            this.grdMiaGiong.ScrollBarWidth = 17;
            this.grdMiaGiong.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grdMiaGiong.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdMiaGiong.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.grdMiaGiong.Size = new System.Drawing.Size(1084, 376);
            this.grdMiaGiong.TabIndex = 75;
            this.grdMiaGiong.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdMiaGiong.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdMiaGiong.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdMiaGiong.UpdateOnLeave = false;
            this.grdMiaGiong.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.grdMiaGiong_RowDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnInPhieu);
            this.panel1.Controls.Add(this.cmdAddHD);
            this.panel1.Controls.Add(this.btnXuatExcelHopDong);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1086, 61);
            this.panel1.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboCanBoNV);
            this.groupBox1.Controls.Add(this.dtDenNgay);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtTuNgay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(570, 45);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thời gian đầu tư";
            // 
            // cboCanBoNV
            // 
            this.cboCanBoNV.Location = new System.Drawing.Point(408, 17);
            this.cboCanBoNV.Name = "cboCanBoNV";
            this.cboCanBoNV.Size = new System.Drawing.Size(144, 20);
            this.cboCanBoNV.TabIndex = 191;
            this.cboCanBoNV.Text = "Chọn cán bộ nông vụ";
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtDenNgay.DropDownCalendar.Name = "";
            this.dtDenNgay.DropDownCalendar.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtDenNgay.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.dtDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDenNgay.ForeColor = System.Drawing.Color.Black;
            this.dtDenNgay.IsNullDate = true;
            this.dtDenNgay.Location = new System.Drawing.Point(191, 15);
            this.dtDenNgay.MinDate = new System.DateTime(2000, 2, 1, 0, 0, 0, 0);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtDenNgay.Size = new System.Drawing.Size(119, 21);
            this.dtDenNgay.TabIndex = 69;
            this.dtDenNgay.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(316, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 190;
            this.label9.Text = "Cán bộ nông vụ:";
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.dtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtTuNgay.DropDownCalendar.Name = "";
            this.dtTuNgay.DropDownCalendar.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtTuNgay.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.dtTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTuNgay.ForeColor = System.Drawing.Color.Black;
            this.dtTuNgay.IsNullDate = true;
            this.dtTuNgay.Location = new System.Drawing.Point(35, 16);
            this.dtTuNgay.MinDate = new System.DateTime(2000, 2, 1, 0, 0, 0, 0);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtTuNgay.Size = new System.Drawing.Size(119, 21);
            this.dtTuNgay.TabIndex = 69;
            this.dtTuNgay.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Đến ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Từ ";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.Filter = " Excel files (*.xls)|*.xls";
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInPhieu.Image = global::MDSolution.Properties.Resources.print;
            this.btnInPhieu.Location = new System.Drawing.Point(832, 17);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(116, 30);
            this.btnInPhieu.TabIndex = 184;
            this.btnInPhieu.Text = "Bảng cân đối";
            this.btnInPhieu.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // cmdAddHD
            // 
            this.cmdAddHD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAddHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddHD.Icon = ((System.Drawing.Icon)(resources.GetObject("cmdAddHD.Icon")));
            this.cmdAddHD.Image = global::MDSolution.Properties.Resources.Home;
            this.cmdAddHD.Location = new System.Drawing.Point(588, 17);
            this.cmdAddHD.Name = "cmdAddHD";
            this.cmdAddHD.Size = new System.Drawing.Size(112, 30);
            this.cmdAddHD.TabIndex = 73;
            this.cmdAddHD.Text = "Tìm kiếm";
            this.cmdAddHD.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            this.cmdAddHD.Click += new System.EventHandler(this.cmdAddHD_Click);
            // 
            // btnXuatExcelHopDong
            // 
            this.btnXuatExcelHopDong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXuatExcelHopDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcelHopDong.Icon = ((System.Drawing.Icon)(resources.GetObject("btnXuatExcelHopDong.Icon")));
            this.btnXuatExcelHopDong.Image = global::MDSolution.Properties.Resources.Home;
            this.btnXuatExcelHopDong.Location = new System.Drawing.Point(705, 17);
            this.btnXuatExcelHopDong.Name = "btnXuatExcelHopDong";
            this.btnXuatExcelHopDong.Size = new System.Drawing.Size(107, 30);
            this.btnXuatExcelHopDong.TabIndex = 74;
            this.btnXuatExcelHopDong.Text = "Xuất Excel";
            this.btnXuatExcelHopDong.Click += new System.EventHandler(this.btnXuatExcelHopDong_Click);
            // 
            // MiaGiong_TuNgay_DenNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 447);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MiaGiong_TuNgay_DenNgay";
            this.Text = "Tra cứu nhập mía giống";
            this.Load += new System.EventHandler(this.MiaGiong_TuNgay_DenNgay_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMiaGiong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton cmdAddHD;
        private Janus.Windows.EditControls.UIButton btnXuatExcelHopDong;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Janus.Windows.CalendarCombo.CalendarCombo dtDenNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo dtTuNgay;
        internal Janus.Windows.GridEX.GridEX grdMiaGiong;
        private Janus.Windows.EditControls.UIButton btnInPhieu;
        private Janus.Windows.EditControls.UIComboBox cboCanBoNV;
        private System.Windows.Forms.Label label9;
    }
}