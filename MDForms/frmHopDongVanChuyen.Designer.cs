namespace MDSolution
{
    partial class frmHopDongVanChuyen
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
            Janus.Windows.GridEX.GridEXLayout gdVHopDongVanChuyen_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHopDongVanChuyen));
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.uiPanel0 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel0Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.gdVHopDongVanChuyen = new Janus.Windows.GridEX.GridEX();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.cmdChuyenVu = new Janus.Windows.EditControls.UIButton();
            this.cmdClose = new Janus.Windows.EditControls.UIButton();
            this.cmd2Excel = new Janus.Windows.EditControls.UIButton();
            this.btSua = new Janus.Windows.EditControls.UIButton();
            this.btThem = new Janus.Windows.EditControls.UIButton();
            this.lblTitleHDVC = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pnTop = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).BeginInit();
            this.uiPanel0.SuspendLayout();
            this.uiPanel0Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdVHopDongVanChuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Standard;
            this.uiPanel0.Id = new System.Guid("c6565334-2ba0-4b03-b30c-d04c5f6a809b");
            this.uiPanelManager1.Panels.Add(this.uiPanel0);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("c6565334-2ba0-4b03-b30c-d04c5f6a809b"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(1583, 714), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c6565334-2ba0-4b03-b30c-d04c5f6a809b"), new System.Drawing.Point(317, 197), new System.Drawing.Size(200, 200), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("0e386f4d-0f55-4383-af7e-ab9f00c848f6"), new System.Drawing.Point(350, 483), new System.Drawing.Size(200, 200), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // uiPanel0
            // 
            this.uiPanel0.ActiveCaptionFormatStyle.ForeColor = System.Drawing.Color.Maroon;
            this.uiPanel0.AutoHideButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel0.BorderCaption = Janus.Windows.UI.InheritableBoolean.True;
            this.uiPanel0.BorderPanel = Janus.Windows.UI.InheritableBoolean.True;
            this.uiPanel0.CaptionFormatStyle.Alpha = 0;
            this.uiPanel0.CaptionFormatStyle.BackColor = System.Drawing.Color.White;
            this.uiPanel0.CaptionFormatStyle.BackColorAlphaMode = Janus.Windows.UI.AlphaMode.Opaque;
            this.uiPanel0.CaptionFormatStyle.BackColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uiPanel0.CaptionFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Solid;
            this.uiPanel0.CaptionFormatStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiPanel0.CaptionFormatStyle.ForeColor = System.Drawing.Color.Maroon;
            this.uiPanel0.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.uiPanel0.CaptionVisible = Janus.Windows.UI.InheritableBoolean.True;
            this.uiPanel0.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel0.FloatingLocation = new System.Drawing.Point(317, 197);
            this.uiPanel0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiPanel0.InnerContainer = this.uiPanel0Container;
            this.uiPanel0.Location = new System.Drawing.Point(3, 40);
            this.uiPanel0.Margin = new System.Windows.Forms.Padding(4);
            this.uiPanel0.Name = "uiPanel0";
            this.uiPanel0.Size = new System.Drawing.Size(1583, 714);
            this.uiPanel0.TabIndex = 4;
            this.uiPanel0.Text = "Danh sách hợp đồng vận chuyển";
            // 
            // uiPanel0Container
            // 
            this.uiPanel0Container.Controls.Add(this.gdVHopDongVanChuyen);
            this.uiPanel0Container.Location = new System.Drawing.Point(1, 25);
            this.uiPanel0Container.Margin = new System.Windows.Forms.Padding(4);
            this.uiPanel0Container.Name = "uiPanel0Container";
            this.uiPanel0Container.Size = new System.Drawing.Size(1581, 688);
            this.uiPanel0Container.TabIndex = 0;
            this.uiPanel0Container.Text = "Danh sách hợp đồng vận chuyển";
            // 
            // gdVHopDongVanChuyen
            // 
            this.gdVHopDongVanChuyen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdVHopDongVanChuyen.AlternatingColors = true;
            this.gdVHopDongVanChuyen.AutoEdit = true;
            this.gdVHopDongVanChuyen.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
    "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            this.gdVHopDongVanChuyen.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            gdVHopDongVanChuyen_DesignTimeLayout.LayoutString = resources.GetString("gdVHopDongVanChuyen_DesignTimeLayout.LayoutString");
            this.gdVHopDongVanChuyen.DesignTimeLayout = gdVHopDongVanChuyen_DesignTimeLayout;
            this.gdVHopDongVanChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdVHopDongVanChuyen.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdVHopDongVanChuyen.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdVHopDongVanChuyen.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gdVHopDongVanChuyen.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdVHopDongVanChuyen.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdVHopDongVanChuyen.Font = new System.Drawing.Font("Arial", 9F);
            this.gdVHopDongVanChuyen.FrozenColumns = 6;
            this.gdVHopDongVanChuyen.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVHopDongVanChuyen.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVHopDongVanChuyen.GroupByBoxVisible = false;
            this.gdVHopDongVanChuyen.HeaderFormatStyle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gdVHopDongVanChuyen.HeaderFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVHopDongVanChuyen.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdVHopDongVanChuyen.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdVHopDongVanChuyen.Location = new System.Drawing.Point(0, 0);
            this.gdVHopDongVanChuyen.Margin = new System.Windows.Forms.Padding(4);
            this.gdVHopDongVanChuyen.Name = "gdVHopDongVanChuyen";
            this.gdVHopDongVanChuyen.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdVHopDongVanChuyen.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdVHopDongVanChuyen.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVHopDongVanChuyen.RowFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVHopDongVanChuyen.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdVHopDongVanChuyen.RowHeaderFormatStyle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gdVHopDongVanChuyen.RowHeaderFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVHopDongVanChuyen.RowHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdVHopDongVanChuyen.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVHopDongVanChuyen.ScrollBarWidth = 17;
            this.gdVHopDongVanChuyen.SelectedFormatStyle.BackColor = System.Drawing.Color.CadetBlue;
            this.gdVHopDongVanChuyen.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVHopDongVanChuyen.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVHopDongVanChuyen.SelectedInactiveFormatStyle.BackColor = System.Drawing.Color.Red;
            this.gdVHopDongVanChuyen.Size = new System.Drawing.Size(1581, 688);
            this.gdVHopDongVanChuyen.TabIndex = 9;
            this.gdVHopDongVanChuyen.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVHopDongVanChuyen.TotalRowFormatStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.gdVHopDongVanChuyen.TotalRowFormatStyle.ForeColor = System.Drawing.Color.DarkRed;
            this.gdVHopDongVanChuyen.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdVHopDongVanChuyen.UpdateOnLeave = false;
            this.gdVHopDongVanChuyen.SelectionChanged += new System.EventHandler(this.gdVHopDongVanChuyen_SelectionChanged);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel;
            this.uiGroupBox1.BorderColor = System.Drawing.SystemColors.Highlight;
            this.uiGroupBox1.Controls.Add(this.cmdChuyenVu);
            this.uiGroupBox1.Controls.Add(this.cmdClose);
            this.uiGroupBox1.Controls.Add(this.cmd2Excel);
            this.uiGroupBox1.Controls.Add(this.btSua);
            this.uiGroupBox1.Controls.Add(this.btThem);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiGroupBox1.FormatStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGroupBox1.FormatStyle.ForeColor = System.Drawing.Color.Maroon;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 757);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(1589, 73);
            this.uiGroupBox1.TabIndex = 10;
            this.uiGroupBox1.Text = "Thao tác xử lý dữ liệu";
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // cmdChuyenVu
            // 
            this.cmdChuyenVu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdChuyenVu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdChuyenVu.Image = ((System.Drawing.Image)(resources.GetObject("cmdChuyenVu.Image")));
            this.cmdChuyenVu.Location = new System.Drawing.Point(735, 26);
            this.cmdChuyenVu.Margin = new System.Windows.Forms.Padding(4);
            this.cmdChuyenVu.Name = "cmdChuyenVu";
            this.cmdChuyenVu.Size = new System.Drawing.Size(147, 37);
            this.cmdChuyenVu.TabIndex = 24;
            this.cmdChuyenVu.Text = "Chuyển vụ ";
            this.cmdChuyenVu.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdChuyenVu.Click += new System.EventHandler(this.cmdChuyenVu_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.Location = new System.Drawing.Point(1413, 23);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(4);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(147, 37);
            this.cmdClose.TabIndex = 23;
            this.cmdClose.Text = "Thoát";
            this.cmdClose.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmd2Excel
            // 
            this.cmd2Excel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd2Excel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd2Excel.Image = ((System.Drawing.Image)(resources.GetObject("cmd2Excel.Image")));
            this.cmd2Excel.Location = new System.Drawing.Point(1235, 23);
            this.cmd2Excel.Margin = new System.Windows.Forms.Padding(4);
            this.cmd2Excel.Name = "cmd2Excel";
            this.cmd2Excel.Size = new System.Drawing.Size(147, 37);
            this.cmd2Excel.TabIndex = 22;
            this.cmd2Excel.Text = "Xuất Excel";
            this.cmd2Excel.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmd2Excel.Click += new System.EventHandler(this.cmd2Excel_Click);
            // 
            // btSua
            // 
            this.btSua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btSua.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.Icon = ((System.Drawing.Icon)(resources.GetObject("btSua.Icon")));
            this.btSua.Image = global::MDSolution.Properties.Resources.prev;
            this.btSua.Location = new System.Drawing.Point(236, 25);
            this.btSua.Margin = new System.Windows.Forms.Padding(4);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(147, 37);
            this.btSua.TabIndex = 11;
            this.btSua.Text = "Sửa HĐ";
            this.btSua.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btThem
            // 
            this.btThem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btThem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.Icon = ((System.Drawing.Icon)(resources.GetObject("btThem.Icon")));
            this.btThem.Image = global::MDSolution.Properties.Resources.Home;
            this.btThem.Location = new System.Drawing.Point(65, 25);
            this.btThem.Margin = new System.Windows.Forms.Padding(4);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(147, 37);
            this.btThem.TabIndex = 12;
            this.btThem.Text = "Thêm mới HĐ";
            this.btThem.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // lblTitleHDVC
            // 
            this.lblTitleHDVC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleHDVC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleHDVC.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleHDVC.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitleHDVC.Location = new System.Drawing.Point(0, 0);
            this.lblTitleHDVC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleHDVC.Name = "lblTitleHDVC";
            this.lblTitleHDVC.Size = new System.Drawing.Size(1589, 37);
            this.lblTitleHDVC.TabIndex = 15;
            this.lblTitleHDVC.Text = "QUẢN LÝ HỢP ĐỒNG VẬN CHUYỂN NIÊN VỤ ";
            this.lblTitleHDVC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = " Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lblTitleHDVC);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1589, 37);
            this.pnTop.TabIndex = 11;
            // 
            // frmHopDongVanChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1589, 830);
            this.Controls.Add(this.uiPanel0);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.pnTop);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHopDongVanChuyen";
            this.ShowIcon = false;
            this.Text = "Hợp đồng vận chuyển";
            this.Load += new System.EventHandler(this.frmHopDongVanChuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).EndInit();
            this.uiPanel0.ResumeLayout(false);
            this.uiPanel0Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdVHopDongVanChuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel uiPanel0;
        internal Janus.Windows.GridEX.GridEX gdVHopDongVanChuyen;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.EditControls.UIButton btThem;
        private System.Windows.Forms.Label lblTitleHDVC;
        private Janus.Windows.EditControls.UIButton cmd2Excel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel0Container;
        private System.Windows.Forms.Panel pnTop;
        private Janus.Windows.EditControls.UIButton cmdClose;
        private Janus.Windows.EditControls.UIButton btSua;
        private Janus.Windows.EditControls.UIButton cmdChuyenVu;

    }
}