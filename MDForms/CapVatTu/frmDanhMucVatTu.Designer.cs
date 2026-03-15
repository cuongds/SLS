namespace MDSolution.MDForms.CapVatTu
{
    partial class frmDanhMucVatTu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucVatTu));
            Janus.Windows.GridEX.GridEXLayout gdDMDT_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gdDMCapVT_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference gdDMCapVT_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column4.ButtonImage");
            Janus.Windows.GridEX.GridEXLayout gdGia_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference gdGia_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column4.ButtonImage");
            this.pnBottom = new System.Windows.Forms.Panel();
            this.cmdClose = new Janus.Windows.EditControls.UIButton();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbl_DMVT = new System.Windows.Forms.TableLayoutPanel();
            this.grVT = new System.Windows.Forms.GroupBox();
            this.gdDMDT = new Janus.Windows.GridEX.GridEX();
            this.grCapVT = new System.Windows.Forms.GroupBox();
            this.gdDMCapVT = new Janus.Windows.GridEX.GridEX();
            this.grTBGia = new System.Windows.Forms.GroupBox();
            this.gdGia = new Janus.Windows.GridEX.GridEX();
            this.grChuyen = new System.Windows.Forms.GroupBox();
            this.cmdKhongChuyen = new Janus.Windows.EditControls.UIButton();
            this.cmdChuyen = new Janus.Windows.EditControls.UIButton();
            this.pnBottom.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.tbl_DMVT.SuspendLayout();
            this.grVT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdDMDT)).BeginInit();
            this.grCapVT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdDMCapVT)).BeginInit();
            this.grTBGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdGia)).BeginInit();
            this.grChuyen.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.cmdClose);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 465);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(1122, 45);
            this.pnBottom.TabIndex = 80;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.Location = new System.Drawing.Point(994, 6);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 32);
            this.cmdClose.TabIndex = 80;
            this.cmdClose.Text = "Đóng";
            this.cmdClose.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lblTitle);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1122, 38);
            this.pnTop.TabIndex = 81;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1122, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "LẬP DANH MỤC CẤP VẬT TƯ ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbl_DMVT
            // 
            this.tbl_DMVT.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tbl_DMVT.ColumnCount = 4;
            this.tbl_DMVT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tbl_DMVT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tbl_DMVT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbl_DMVT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tbl_DMVT.Controls.Add(this.grVT, 0, 0);
            this.tbl_DMVT.Controls.Add(this.grCapVT, 2, 0);
            this.tbl_DMVT.Controls.Add(this.grTBGia, 3, 0);
            this.tbl_DMVT.Controls.Add(this.grChuyen, 1, 0);
            this.tbl_DMVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_DMVT.Location = new System.Drawing.Point(0, 38);
            this.tbl_DMVT.Name = "tbl_DMVT";
            this.tbl_DMVT.RowCount = 1;
            this.tbl_DMVT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl_DMVT.Size = new System.Drawing.Size(1122, 427);
            this.tbl_DMVT.TabIndex = 82;
            // 
            // grVT
            // 
            this.grVT.Controls.Add(this.gdDMDT);
            this.grVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grVT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grVT.ForeColor = System.Drawing.Color.Maroon;
            this.grVT.Location = new System.Drawing.Point(6, 6);
            this.grVT.Name = "grVT";
            this.grVT.Size = new System.Drawing.Size(381, 415);
            this.grVT.TabIndex = 0;
            this.grVT.TabStop = false;
            this.grVT.Text = "Danh mục đầu tư";
            // 
            // gdDMDT
            // 
            this.gdDMDT.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdDMDT.AlternatingColors = true;
            this.gdDMDT.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
                "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            this.gdDMDT.ColumnAutoResize = true;
            gdDMDT_DesignTimeLayout.LayoutString = resources.GetString("gdDMDT_DesignTimeLayout.LayoutString");
            this.gdDMDT.DesignTimeLayout = gdDMDT_DesignTimeLayout;
            this.gdDMDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdDMDT.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdDMDT.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdDMDT.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdDMDT.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdDMDT.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdDMDT.GroupByBoxVisible = false;
            this.gdDMDT.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDMDT.GroupRowFormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.gdDMDT.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDMDT.HeaderFormatStyle.LineAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdDMDT.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdDMDT.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdDMDT.Location = new System.Drawing.Point(3, 18);
            this.gdDMDT.Name = "gdDMDT";
            this.gdDMDT.NewRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdDMDT.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDMDT.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdDMDT.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdDMDT.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdDMDT.RowFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDMDT.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdDMDT.RowHeaderFormatStyle.BackColor = System.Drawing.SystemColors.Highlight;
            this.gdDMDT.RowHeaderFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gdDMDT.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdDMDT.ScrollBarWidth = 17;
            this.gdDMDT.SelectedFormatStyle.BackColor = System.Drawing.Color.CadetBlue;
            this.gdDMDT.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDMDT.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDMDT.Size = new System.Drawing.Size(375, 394);
            this.gdDMDT.TabIndex = 11;
            this.gdDMDT.UpdateOnLeave = false;
            this.gdDMDT.SelectionChanged += new System.EventHandler(this.gdDMDT_SelectionChanged);
            // 
            // grCapVT
            // 
            this.grCapVT.Controls.Add(this.gdDMCapVT);
            this.grCapVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grCapVT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grCapVT.ForeColor = System.Drawing.Color.Purple;
            this.grCapVT.Location = new System.Drawing.Point(487, 6);
            this.grCapVT.Name = "grCapVT";
            this.grCapVT.Size = new System.Drawing.Size(326, 415);
            this.grCapVT.TabIndex = 1;
            this.grCapVT.TabStop = false;
            this.grCapVT.Text = "Danh mục cấp vật tư đi địa bàn";
            // 
            // gdDMCapVT
            // 
            this.gdDMCapVT.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdDMCapVT.AlternatingColors = true;
            this.gdDMCapVT.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
                "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo><EmptyGridInfo>Chưa có dữ liệ" +
                "u</EmptyGridInfo></LocalizableData>";
            this.gdDMCapVT.ColumnAutoResize = true;
            gdDMCapVT_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("gdDMCapVT_DesignTimeLayout_Reference_0.Instance")));
            gdDMCapVT_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            gdDMCapVT_DesignTimeLayout_Reference_0});
            gdDMCapVT_DesignTimeLayout.LayoutString = resources.GetString("gdDMCapVT_DesignTimeLayout.LayoutString");
            this.gdDMCapVT.DesignTimeLayout = gdDMCapVT_DesignTimeLayout;
            this.gdDMCapVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdDMCapVT.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdDMCapVT.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdDMCapVT.Font = new System.Drawing.Font("Arial", 9F);
            this.gdDMCapVT.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdDMCapVT.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdDMCapVT.GroupByBoxVisible = false;
            this.gdDMCapVT.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDMCapVT.GroupRowFormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.gdDMCapVT.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDMCapVT.HeaderFormatStyle.LineAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdDMCapVT.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdDMCapVT.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdDMCapVT.Location = new System.Drawing.Point(3, 18);
            this.gdDMCapVT.Name = "gdDMCapVT";
            this.gdDMCapVT.NewRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdDMCapVT.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDMCapVT.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdDMCapVT.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdDMCapVT.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdDMCapVT.RowFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDMCapVT.RowHeaderFormatStyle.BackColor = System.Drawing.SystemColors.Highlight;
            this.gdDMCapVT.RowHeaderFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gdDMCapVT.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdDMCapVT.ScrollBarWidth = 17;
            this.gdDMCapVT.SelectedFormatStyle.BackColor = System.Drawing.Color.Bisque;
            this.gdDMCapVT.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDMCapVT.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDMCapVT.Size = new System.Drawing.Size(320, 394);
            this.gdDMCapVT.TabIndex = 12;
            this.gdDMCapVT.UpdateOnLeave = false;
            this.gdDMCapVT.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdDMCapVT_ColumnButtonClick);
            this.gdDMCapVT.SelectionChanged += new System.EventHandler(this.gdDMCapVT_SelectionChanged);
            // 
            // grTBGia
            // 
            this.grTBGia.Controls.Add(this.gdGia);
            this.grTBGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grTBGia.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grTBGia.ForeColor = System.Drawing.Color.Purple;
            this.grTBGia.Location = new System.Drawing.Point(822, 6);
            this.grTBGia.Name = "grTBGia";
            this.grTBGia.Size = new System.Drawing.Size(294, 415);
            this.grTBGia.TabIndex = 2;
            this.grTBGia.TabStop = false;
            this.grTBGia.Text = "Đơn giá";
            // 
            // gdGia
            // 
            this.gdGia.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdGia.AlternatingColors = true;
            this.gdGia.BuiltInTextsData = resources.GetString("gdGia.BuiltInTextsData");
            this.gdGia.ColumnAutoResize = true;
            gdGia_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("gdGia_DesignTimeLayout_Reference_0.Instance")));
            gdGia_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            gdGia_DesignTimeLayout_Reference_0});
            gdGia_DesignTimeLayout.LayoutString = resources.GetString("gdGia_DesignTimeLayout.LayoutString");
            this.gdGia.DesignTimeLayout = gdGia_DesignTimeLayout;
            this.gdGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdGia.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdGia.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdGia.Font = new System.Drawing.Font("Arial", 9F);
            this.gdGia.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdGia.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdGia.GroupByBoxVisible = false;
            this.gdGia.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdGia.GroupRowFormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.gdGia.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdGia.HeaderFormatStyle.LineAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdGia.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdGia.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdGia.Location = new System.Drawing.Point(3, 18);
            this.gdGia.Name = "gdGia";
            this.gdGia.NewRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdGia.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdGia.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdGia.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdGia.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdGia.RowFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdGia.RowHeaderFormatStyle.BackColor = System.Drawing.SystemColors.Highlight;
            this.gdGia.RowHeaderFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gdGia.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdGia.ScrollBarWidth = 17;
            this.gdGia.SelectedFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gdGia.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdGia.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdGia.Size = new System.Drawing.Size(288, 394);
            this.gdGia.TabIndex = 12;
            this.gdGia.UpdateOnLeave = false;
            this.gdGia.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdGia_ColumnButtonClick);
            // 
            // grChuyen
            // 
            this.grChuyen.Controls.Add(this.cmdKhongChuyen);
            this.grChuyen.Controls.Add(this.cmdChuyen);
            this.grChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grChuyen.Location = new System.Drawing.Point(396, 6);
            this.grChuyen.Name = "grChuyen";
            this.grChuyen.Size = new System.Drawing.Size(82, 415);
            this.grChuyen.TabIndex = 3;
            this.grChuyen.TabStop = false;
            // 
            // cmdKhongChuyen
            // 
            this.cmdKhongChuyen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdKhongChuyen.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdKhongChuyen.Image = ((System.Drawing.Image)(resources.GetObject("cmdKhongChuyen.Image")));
            this.cmdKhongChuyen.Location = new System.Drawing.Point(6, 214);
            this.cmdKhongChuyen.Name = "cmdKhongChuyen";
            this.cmdKhongChuyen.Size = new System.Drawing.Size(70, 32);
            this.cmdKhongChuyen.TabIndex = 82;
            this.cmdKhongChuyen.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdKhongChuyen.Click += new System.EventHandler(this.cmdKhongChuyen_Click);
            // 
            // cmdChuyen
            // 
            this.cmdChuyen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdChuyen.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdChuyen.Image = ((System.Drawing.Image)(resources.GetObject("cmdChuyen.Image")));
            this.cmdChuyen.Location = new System.Drawing.Point(6, 166);
            this.cmdChuyen.Name = "cmdChuyen";
            this.cmdChuyen.Size = new System.Drawing.Size(70, 32);
            this.cmdChuyen.TabIndex = 81;
            this.cmdChuyen.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdChuyen.Click += new System.EventHandler(this.cmdChuyen_Click);
            // 
            // frmDanhMucVatTu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1122, 510);
            this.Controls.Add(this.tbl_DMVT);
            this.Controls.Add(this.pnTop);
            this.Controls.Add(this.pnBottom);
            this.MinimizeBox = false;
            this.Name = "frmDanhMucVatTu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục vật tư cung cấp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnBottom.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.tbl_DMVT.ResumeLayout(false);
            this.grVT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdDMDT)).EndInit();
            this.grCapVT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdDMCapVT)).EndInit();
            this.grTBGia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdGia)).EndInit();
            this.grChuyen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBottom;
        private Janus.Windows.EditControls.UIButton cmdClose;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tbl_DMVT;
        private System.Windows.Forms.GroupBox grVT;
        private System.Windows.Forms.GroupBox grCapVT;
        internal Janus.Windows.GridEX.GridEX gdDMDT;
        internal Janus.Windows.GridEX.GridEX gdDMCapVT;
        private System.Windows.Forms.GroupBox grTBGia;
        internal Janus.Windows.GridEX.GridEX gdGia;
        private System.Windows.Forms.GroupBox grChuyen;
        private Janus.Windows.EditControls.UIButton cmdKhongChuyen;
        private Janus.Windows.EditControls.UIButton cmdChuyen;

    }
}