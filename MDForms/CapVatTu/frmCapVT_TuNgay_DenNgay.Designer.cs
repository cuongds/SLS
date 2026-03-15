namespace MDSolution.MDForms.CapVatTu
{
    partial class frmCapVT_TuNgay_DenNgay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapVT_TuNgay_DenNgay));
            Janus.Windows.GridEX.GridEXLayout grdVatTong_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdAddHD = new Janus.Windows.EditControls.UIButton();
            this.btnXuatExcelHopDong = new Janus.Windows.EditControls.UIButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.dtTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdVatTong = new Janus.Windows.GridEX.GridEX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVatTong)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grdVatTong, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1453, 550);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdAddHD);
            this.panel1.Controls.Add(this.btnXuatExcelHopDong);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1447, 76);
            this.panel1.TabIndex = 31;
            // 
            // cmdAddHD
            // 
            this.cmdAddHD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAddHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddHD.Icon = ((System.Drawing.Icon)(resources.GetObject("cmdAddHD.Icon")));
            this.cmdAddHD.Image = global::MDSolution.Properties.Resources.Home;
            this.cmdAddHD.Location = new System.Drawing.Point(515, 22);
            this.cmdAddHD.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAddHD.Name = "cmdAddHD";
            this.cmdAddHD.Size = new System.Drawing.Size(149, 38);
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
            this.btnXuatExcelHopDong.Location = new System.Drawing.Point(671, 22);
            this.btnXuatExcelHopDong.Margin = new System.Windows.Forms.Padding(4);
            this.btnXuatExcelHopDong.Name = "btnXuatExcelHopDong";
            this.btnXuatExcelHopDong.Size = new System.Drawing.Size(143, 38);
            this.btnXuatExcelHopDong.TabIndex = 74;
            this.btnXuatExcelHopDong.Text = "Xuất Excel";
            this.btnXuatExcelHopDong.Click += new System.EventHandler(this.btnXuatExcelHopDong_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtDenNgay);
            this.groupBox1.Controls.Add(this.dtTuNgay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(473, 55);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thời gian lập phiếu cấp";
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
            this.dtDenNgay.Location = new System.Drawing.Point(299, 18);
            this.dtDenNgay.Margin = new System.Windows.Forms.Padding(4);
            this.dtDenNgay.MinDate = new System.DateTime(2000, 2, 1, 0, 0, 0, 0);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtDenNgay.Size = new System.Drawing.Size(159, 25);
            this.dtDenNgay.TabIndex = 69;
            this.dtDenNgay.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
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
            this.dtTuNgay.Location = new System.Drawing.Point(47, 20);
            this.dtTuNgay.Margin = new System.Windows.Forms.Padding(4);
            this.dtTuNgay.MinDate = new System.DateTime(2000, 2, 1, 0, 0, 0, 0);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtTuNgay.Size = new System.Drawing.Size(159, 25);
            this.dtTuNgay.TabIndex = 69;
            this.dtTuNgay.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Đến ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Từ ";
            // 
            // grdVatTong
            // 
            this.grdVatTong.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdVatTong.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdVatTong.AlternatingColors = true;
            this.grdVatTong.AutoEdit = true;
            this.grdVatTong.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
    "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            grdVatTong_DesignTimeLayout.LayoutString = resources.GetString("grdVatTong_DesignTimeLayout.LayoutString");
            this.grdVatTong.DesignTimeLayout = grdVatTong_DesignTimeLayout;
            this.grdVatTong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVatTong.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.grdVatTong.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdVatTong.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdVatTong.FlatBorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdVatTong.Font = new System.Drawing.Font("Arial", 9F);
            this.grdVatTong.FrozenColumns = 1;
            this.grdVatTong.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.grdVatTong.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdVatTong.GroupByBoxVisible = false;
            this.grdVatTong.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdVatTong.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdVatTong.Location = new System.Drawing.Point(4, 84);
            this.grdVatTong.Margin = new System.Windows.Forms.Padding(4);
            this.grdVatTong.Name = "grdVatTong";
            this.grdVatTong.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdVatTong.NewRowFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.grdVatTong.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdVatTong.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.grdVatTong.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.grdVatTong.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.grdVatTong.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.grdVatTong.RowHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdVatTong.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdVatTong.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both;
            this.grdVatTong.ScrollBarWidth = 17;
            this.grdVatTong.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grdVatTong.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdVatTong.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.grdVatTong.Size = new System.Drawing.Size(1445, 462);
            this.grdVatTong.TabIndex = 75;
            this.grdVatTong.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdVatTong.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdVatTong.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdVatTong.UpdateOnLeave = false;
            this.grdVatTong.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.grdMiaGiong_RowDoubleClick);
            this.grdVatTong.ColumnHeaderClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdMiaGiong_ColumnHeaderClick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.Filter = " Excel files (*.xls)|*.xls";
            // 
            // frmCapVT_TuNgay_DenNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1453, 550);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmCapVT_TuNgay_DenNgay";
            this.Text = "Cấp vật tư";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCapVT_TuNgay_DenNgay_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVatTong)).EndInit();
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
        internal Janus.Windows.GridEX.GridEX grdVatTong;
    }
}