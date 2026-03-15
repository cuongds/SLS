namespace MDSolution
{
    partial class frmCanBoNongVu
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
            Janus.Windows.GridEX.GridEXLayout gdDSCBNV_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference gdDSCBNV_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column5.ButtonImage");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCanBoNongVu));
            Janus.Windows.GridEX.GridEXLayout gdDiaBan_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference gdDiaBan_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column4.ButtonImage");
            this.gdDSCBNV = new Janus.Windows.GridEX.GridEX();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.grDSCBNV = new System.Windows.Forms.GroupBox();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.cmdPrint = new Janus.Windows.EditControls.UIButton();
            this.cmdClose = new Janus.Windows.EditControls.UIButton();
            this.pnRight = new System.Windows.Forms.Panel();
            this.grDB = new System.Windows.Forms.GroupBox();
            this.gdDiaBan = new Janus.Windows.GridEX.GridEX();
            this.pnCenter = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gdDSCBNV)).BeginInit();
            this.pnTop.SuspendLayout();
            this.pnLeft.SuspendLayout();
            this.grDSCBNV.SuspendLayout();
            this.pnBottom.SuspendLayout();
            this.pnRight.SuspendLayout();
            this.grDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdDiaBan)).BeginInit();
            this.pnCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdDSCBNV
            // 
            this.gdDSCBNV.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdDSCBNV.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdDSCBNV.AlternatingColors = true;
            this.gdDSCBNV.AutoEdit = true;
            this.gdDSCBNV.AutomaticSort = false;
            this.gdDSCBNV.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
    "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            this.gdDSCBNV.ColumnAutoResize = true;
            gdDSCBNV_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("gdDSCBNV_DesignTimeLayout_Reference_0.Instance")));
            gdDSCBNV_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            gdDSCBNV_DesignTimeLayout_Reference_0});
            gdDSCBNV_DesignTimeLayout.LayoutString = resources.GetString("gdDSCBNV_DesignTimeLayout.LayoutString");
            this.gdDSCBNV.DesignTimeLayout = gdDSCBNV_DesignTimeLayout;
            this.gdDSCBNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdDSCBNV.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdDSCBNV.Font = new System.Drawing.Font("Arial", 9F);
            this.gdDSCBNV.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdDSCBNV.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdDSCBNV.GroupByBoxVisible = false;
            this.gdDSCBNV.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSCBNV.HeaderFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDSCBNV.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdDSCBNV.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdDSCBNV.Location = new System.Drawing.Point(3, 18);
            this.gdDSCBNV.Name = "gdDSCBNV";
            this.gdDSCBNV.NewRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdDSCBNV.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSCBNV.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdDSCBNV.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdDSCBNV.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdDSCBNV.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdDSCBNV.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdDSCBNV.ScrollBarWidth = 17;
            this.gdDSCBNV.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gdDSCBNV.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSCBNV.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDSCBNV.Size = new System.Drawing.Size(659, 378);
            this.gdDSCBNV.TabIndex = 6;
            this.gdDSCBNV.UpdateOnLeave = false;
            this.gdDSCBNV.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.gdVLVDauTu_DeletingRecord);
            this.gdDSCBNV.RecordsDeleted += new System.EventHandler(this.gdVLVDauTu_RecordsDeleted);
            this.gdDSCBNV.RecordAdded += new System.EventHandler(this.gdVLVDauTu_RecordAdded);
            this.gdDSCBNV.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gdVLVDauTu_UpdatingRecord);
            this.gdDSCBNV.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gdVLVDauTu_AddingRecord);
            this.gdDSCBNV.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdDSCBNV_ColumnButtonClick);
            this.gdDSCBNV.SelectionChanged += new System.EventHandler(this.gdDSCBNV_SelectionChanged);
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lblTitle);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1152, 42);
            this.pnTop.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1152, 42);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ CÁN BỘ ĐỊA BÀN SLS";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnLeft
            // 
            this.pnLeft.Controls.Add(this.grDSCBNV);
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnLeft.Location = new System.Drawing.Point(0, 0);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(665, 399);
            this.pnLeft.TabIndex = 9;
            // 
            // grDSCBNV
            // 
            this.grDSCBNV.Controls.Add(this.gdDSCBNV);
            this.grDSCBNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDSCBNV.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grDSCBNV.ForeColor = System.Drawing.Color.Maroon;
            this.grDSCBNV.Location = new System.Drawing.Point(0, 0);
            this.grDSCBNV.Name = "grDSCBNV";
            this.grDSCBNV.Size = new System.Drawing.Size(665, 399);
            this.grDSCBNV.TabIndex = 7;
            this.grDSCBNV.TabStop = false;
            this.grDSCBNV.Text = "Danh sách cán bộ địa bàn";
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.cmdPrint);
            this.pnBottom.Controls.Add(this.cmdClose);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 445);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(1152, 46);
            this.pnBottom.TabIndex = 10;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrint.Icon = ((System.Drawing.Icon)(resources.GetObject("cmdPrint.Icon")));
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.Location = new System.Drawing.Point(36, 6);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(112, 32);
            this.cmdPrint.TabIndex = 82;
            this.cmdPrint.Text = "In DM quản lý";
            this.cmdPrint.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.Location = new System.Drawing.Point(1014, 6);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(112, 32);
            this.cmdClose.TabIndex = 81;
            this.cmdClose.Text = "Đóng";
            this.cmdClose.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // pnRight
            // 
            this.pnRight.Controls.Add(this.grDB);
            this.pnRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnRight.Location = new System.Drawing.Point(665, 0);
            this.pnRight.Name = "pnRight";
            this.pnRight.Size = new System.Drawing.Size(483, 399);
            this.pnRight.TabIndex = 11;
            // 
            // grDB
            // 
            this.grDB.Controls.Add(this.gdDiaBan);
            this.grDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDB.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grDB.ForeColor = System.Drawing.Color.Navy;
            this.grDB.Location = new System.Drawing.Point(0, 0);
            this.grDB.Name = "grDB";
            this.grDB.Size = new System.Drawing.Size(483, 399);
            this.grDB.TabIndex = 8;
            this.grDB.TabStop = false;
            this.grDB.Text = "Địa bàn được phân công";
            // 
            // gdDiaBan
            // 
            this.gdDiaBan.AlternatingColors = true;
            this.gdDiaBan.AutoEdit = true;
            this.gdDiaBan.BuiltInTextsData = resources.GetString("gdDiaBan.BuiltInTextsData");
            this.gdDiaBan.ColumnAutoResize = true;
            gdDiaBan_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("gdDiaBan_DesignTimeLayout_Reference_0.Instance")));
            gdDiaBan_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            gdDiaBan_DesignTimeLayout_Reference_0});
            gdDiaBan_DesignTimeLayout.LayoutString = resources.GetString("gdDiaBan_DesignTimeLayout.LayoutString");
            this.gdDiaBan.DesignTimeLayout = gdDiaBan_DesignTimeLayout;
            this.gdDiaBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdDiaBan.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdDiaBan.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdDiaBan.Font = new System.Drawing.Font("Arial", 9F);
            this.gdDiaBan.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdDiaBan.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdDiaBan.GroupByBoxVisible = false;
            this.gdDiaBan.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDiaBan.HeaderFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDiaBan.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdDiaBan.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdDiaBan.Location = new System.Drawing.Point(3, 18);
            this.gdDiaBan.Name = "gdDiaBan";
            this.gdDiaBan.NewRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdDiaBan.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDiaBan.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdDiaBan.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdDiaBan.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdDiaBan.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdDiaBan.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdDiaBan.ScrollBarWidth = 17;
            this.gdDiaBan.SelectedFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Flat;
            this.gdDiaBan.SelectedFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gdDiaBan.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDiaBan.SelectedInactiveFormatStyle.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gdDiaBan.SelectedInactiveFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDiaBan.Size = new System.Drawing.Size(477, 378);
            this.gdDiaBan.TabIndex = 6;
            this.gdDiaBan.UpdateOnLeave = false;
            this.gdDiaBan.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdDiaBan_ColumnButtonClick);
            // 
            // pnCenter
            // 
            this.pnCenter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnCenter.Controls.Add(this.pnLeft);
            this.pnCenter.Controls.Add(this.pnRight);
            this.pnCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCenter.Location = new System.Drawing.Point(0, 42);
            this.pnCenter.Name = "pnCenter";
            this.pnCenter.Size = new System.Drawing.Size(1152, 403);
            this.pnCenter.TabIndex = 12;
            // 
            // frmCanBoNongVu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1152, 491);
            this.Controls.Add(this.pnCenter);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.pnTop);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmCanBoNongVu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục cán bộ  địa bàn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCanBoNongVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdDSCBNV)).EndInit();
            this.pnTop.ResumeLayout(false);
            this.pnLeft.ResumeLayout(false);
            this.grDSCBNV.ResumeLayout(false);
            this.pnBottom.ResumeLayout(false);
            this.pnRight.ResumeLayout(false);
            this.grDB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdDiaBan)).EndInit();
            this.pnCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gdDSCBNV;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.GroupBox grDSCBNV;
        private System.Windows.Forms.Panel pnBottom;
        private System.Windows.Forms.Panel pnRight;
        private System.Windows.Forms.GroupBox grDB;
        internal Janus.Windows.GridEX.GridEX gdDiaBan;
        private System.Windows.Forms.Panel pnCenter;
        private Janus.Windows.EditControls.UIButton cmdClose;
        private Janus.Windows.EditControls.UIButton cmdPrint;

    }
}