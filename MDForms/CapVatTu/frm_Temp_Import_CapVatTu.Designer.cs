namespace MDSolution.MDForms.CapVatTu
{
    partial class frm_Temp_Import_CapVatTu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Temp_Import_CapVatTu));
            Janus.Windows.GridEX.GridEXLayout gdDSNhanVatTu_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference gdDSNhanVatTu_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column7.ButtonImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference gdDSNhanVatTu_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column8.ButtonImage");
            this.pnBottom = new System.Windows.Forms.Panel();
            this.lblWaite = new System.Windows.Forms.Label();
            this.cmdXuatExcel = new Janus.Windows.EditControls.UIButton();
            this.cmdSave = new Janus.Windows.EditControls.UIButton();
            this.cmdClose = new Janus.Windows.EditControls.UIButton();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grCapVT = new System.Windows.Forms.GroupBox();
            this.gdDSNhanVatTu = new Janus.Windows.GridEX.GridEX();
            this.pnCenter = new System.Windows.Forms.Panel();
            this.pnData = new System.Windows.Forms.Panel();
            this.pnSoPhieu = new System.Windows.Forms.Panel();
            this.lblTenFile = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTenVT = new System.Windows.Forms.Label();
            this.lblCBNV = new System.Windows.Forms.Label();
            this.lblSoPhieu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog_Excel = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_Excel = new System.Windows.Forms.SaveFileDialog();
            this.pnBottom.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.grCapVT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdDSNhanVatTu)).BeginInit();
            this.pnCenter.SuspendLayout();
            this.pnData.SuspendLayout();
            this.pnSoPhieu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.lblWaite);
            this.pnBottom.Controls.Add(this.cmdXuatExcel);
            this.pnBottom.Controls.Add(this.cmdSave);
            this.pnBottom.Controls.Add(this.cmdClose);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 589);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(1270, 45);
            this.pnBottom.TabIndex = 80;
            this.pnBottom.TabStop = true;
            // 
            // lblWaite
            // 
            this.lblWaite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWaite.AutoSize = true;
            this.lblWaite.CausesValidation = false;
            this.lblWaite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWaite.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaite.ForeColor = System.Drawing.Color.Red;
            this.lblWaite.Location = new System.Drawing.Point(152, 15);
            this.lblWaite.Name = "lblWaite";
            this.lblWaite.Size = new System.Drawing.Size(98, 16);
            this.lblWaite.TabIndex = 88;
            this.lblWaite.Text = "Vui lòng đợi...";
            this.lblWaite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWaite.Visible = false;
            // 
            // cmdXuatExcel
            // 
            this.cmdXuatExcel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdXuatExcel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdXuatExcel.Icon = ((System.Drawing.Icon)(resources.GetObject("cmdXuatExcel.Icon")));
            this.cmdXuatExcel.Location = new System.Drawing.Point(999, 7);
            this.cmdXuatExcel.Name = "cmdXuatExcel";
            this.cmdXuatExcel.Size = new System.Drawing.Size(100, 30);
            this.cmdXuatExcel.TabIndex = 82;
            this.cmdXuatExcel.Text = "Xuất Excel";
            this.cmdXuatExcel.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdXuatExcel.Click += new System.EventHandler(this.cmdXuatExcel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.Location = new System.Drawing.Point(27, 7);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 30);
            this.cmdSave.TabIndex = 81;
            this.cmdSave.Text = "Ghi lại";
            this.cmdSave.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.Location = new System.Drawing.Point(1142, 7);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 30);
            this.cmdClose.TabIndex = 83;
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
            this.pnTop.Size = new System.Drawing.Size(1270, 38);
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
            this.lblTitle.Size = new System.Drawing.Size(1270, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DỮ LIỆU NHẬN VẬT TƯ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grCapVT
            // 
            this.grCapVT.Controls.Add(this.gdDSNhanVatTu);
            this.grCapVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grCapVT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grCapVT.ForeColor = System.Drawing.Color.Purple;
            this.grCapVT.Location = new System.Drawing.Point(0, 0);
            this.grCapVT.Name = "grCapVT";
            this.grCapVT.Size = new System.Drawing.Size(1262, 473);
            this.grCapVT.TabIndex = 1;
            this.grCapVT.TabStop = false;
            this.grCapVT.Text = "Danh sách hộ nhận vật tư";
            // 
            // gdDSNhanVatTu
            // 
            this.gdDSNhanVatTu.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdDSNhanVatTu.AlternatingColors = true;
            this.gdDSNhanVatTu.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
                "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo><EmptyGridInfo>Chưa có dữ liệ" +
                "u</EmptyGridInfo></LocalizableData>";
            this.gdDSNhanVatTu.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            gdDSNhanVatTu_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("gdDSNhanVatTu_DesignTimeLayout_Reference_0.Instance")));
            gdDSNhanVatTu_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("gdDSNhanVatTu_DesignTimeLayout_Reference_1.Instance")));
            gdDSNhanVatTu_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            gdDSNhanVatTu_DesignTimeLayout_Reference_0,
            gdDSNhanVatTu_DesignTimeLayout_Reference_1});
            gdDSNhanVatTu_DesignTimeLayout.LayoutString = resources.GetString("gdDSNhanVatTu_DesignTimeLayout.LayoutString");
            this.gdDSNhanVatTu.DesignTimeLayout = gdDSNhanVatTu_DesignTimeLayout;
            this.gdDSNhanVatTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdDSNhanVatTu.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdDSNhanVatTu.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdDSNhanVatTu.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdDSNhanVatTu.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdDSNhanVatTu.Font = new System.Drawing.Font("Arial", 9F);
            this.gdDSNhanVatTu.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdDSNhanVatTu.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdDSNhanVatTu.GroupByBoxVisible = false;
            this.gdDSNhanVatTu.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSNhanVatTu.GroupRowFormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.gdDSNhanVatTu.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSNhanVatTu.HeaderFormatStyle.LineAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdDSNhanVatTu.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdDSNhanVatTu.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdDSNhanVatTu.Location = new System.Drawing.Point(3, 18);
            this.gdDSNhanVatTu.Name = "gdDSNhanVatTu";
            this.gdDSNhanVatTu.NewRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdDSNhanVatTu.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSNhanVatTu.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdDSNhanVatTu.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdDSNhanVatTu.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdDSNhanVatTu.RowFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDSNhanVatTu.RowHeaderFormatStyle.BackColor = System.Drawing.SystemColors.Highlight;
            this.gdDSNhanVatTu.RowHeaderFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gdDSNhanVatTu.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdDSNhanVatTu.ScrollBarWidth = 17;
            this.gdDSNhanVatTu.SelectedFormatStyle.BackColor = System.Drawing.Color.Bisque;
            this.gdDSNhanVatTu.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSNhanVatTu.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDSNhanVatTu.Size = new System.Drawing.Size(1256, 452);
            this.gdDSNhanVatTu.TabIndex = 12;
            this.gdDSNhanVatTu.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.gdDSNhanVatTu.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdDSNhanVatTu.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSNhanVatTu.TotalRowFormatStyle.ForeColor = System.Drawing.Color.Maroon;
            this.gdDSNhanVatTu.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdDSNhanVatTu.UpdateOnLeave = false;
            this.gdDSNhanVatTu.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gdDSNhanVatTu_FormattingRow);
            this.gdDSNhanVatTu.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdDSNhanVatTu_ColumnButtonClick);
            // 
            // pnCenter
            // 
            this.pnCenter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnCenter.Controls.Add(this.pnData);
            this.pnCenter.Controls.Add(this.pnSoPhieu);
            this.pnCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCenter.Location = new System.Drawing.Point(0, 38);
            this.pnCenter.Name = "pnCenter";
            this.pnCenter.Size = new System.Drawing.Size(1270, 551);
            this.pnCenter.TabIndex = 82;
            // 
            // pnData
            // 
            this.pnData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnData.Controls.Add(this.grCapVT);
            this.pnData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnData.Location = new System.Drawing.Point(0, 70);
            this.pnData.Name = "pnData";
            this.pnData.Size = new System.Drawing.Size(1266, 477);
            this.pnData.TabIndex = 84;
            // 
            // pnSoPhieu
            // 
            this.pnSoPhieu.Controls.Add(this.lblTenFile);
            this.pnSoPhieu.Controls.Add(this.label5);
            this.pnSoPhieu.Controls.Add(this.lblTenVT);
            this.pnSoPhieu.Controls.Add(this.lblCBNV);
            this.pnSoPhieu.Controls.Add(this.lblSoPhieu);
            this.pnSoPhieu.Controls.Add(this.label3);
            this.pnSoPhieu.Controls.Add(this.label2);
            this.pnSoPhieu.Controls.Add(this.label1);
            this.pnSoPhieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnSoPhieu.Location = new System.Drawing.Point(0, 0);
            this.pnSoPhieu.Name = "pnSoPhieu";
            this.pnSoPhieu.Size = new System.Drawing.Size(1266, 70);
            this.pnSoPhieu.TabIndex = 83;
            // 
            // lblTenFile
            // 
            this.lblTenFile.AutoSize = true;
            this.lblTenFile.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenFile.Location = new System.Drawing.Point(532, 40);
            this.lblTenFile.Name = "lblTenFile";
            this.lblTenFile.Size = new System.Drawing.Size(61, 18);
            this.lblTenFile.TabIndex = 7;
            this.lblTenFile.Text = "TenFile";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(450, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tên file excel:";
            // 
            // lblTenVT
            // 
            this.lblTenVT.AutoSize = true;
            this.lblTenVT.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenVT.Location = new System.Drawing.Point(532, 11);
            this.lblTenVT.Name = "lblTenVT";
            this.lblTenVT.Size = new System.Drawing.Size(54, 18);
            this.lblTenVT.TabIndex = 5;
            this.lblTenVT.Text = "TenVT";
            // 
            // lblCBNV
            // 
            this.lblCBNV.AutoSize = true;
            this.lblCBNV.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCBNV.Location = new System.Drawing.Point(145, 39);
            this.lblCBNV.Name = "lblCBNV";
            this.lblCBNV.Size = new System.Drawing.Size(50, 18);
            this.lblCBNV.TabIndex = 4;
            this.lblCBNV.Text = "CBNV";
            // 
            // lblSoPhieu
            // 
            this.lblSoPhieu.AutoSize = true;
            this.lblSoPhieu.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoPhieu.ForeColor = System.Drawing.Color.Red;
            this.lblSoPhieu.Location = new System.Drawing.Point(145, 11);
            this.lblSoPhieu.Name = "lblSoPhieu";
            this.lblSoPhieu.Size = new System.Drawing.Size(68, 18);
            this.lblSoPhieu.TabIndex = 3;
            this.lblSoPhieu.Text = "SoPhieu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(468, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên vật tư:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số phiếu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cán bộ nông vụ:";
            // 
            // openFileDialog_Excel
            // 
            this.openFileDialog_Excel.FileName = "openFileDialog_Excel";
            // 
            // saveFileDialog_Excel
            // 
            this.saveFileDialog_Excel.Filter = " Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            // 
            // frm_Temp_Import_CapVatTu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1270, 634);
            this.Controls.Add(this.pnCenter);
            this.Controls.Add(this.pnTop);
            this.Controls.Add(this.pnBottom);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Temp_Import_CapVatTu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhận vật tư";
            this.Load += new System.EventHandler(this.frm_Temp_Import_CapVatTu_Load);
            this.pnBottom.ResumeLayout(false);
            this.pnBottom.PerformLayout();
            this.pnTop.ResumeLayout(false);
            this.grCapVT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdDSNhanVatTu)).EndInit();
            this.pnCenter.ResumeLayout(false);
            this.pnData.ResumeLayout(false);
            this.pnSoPhieu.ResumeLayout(false);
            this.pnSoPhieu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBottom;
        private Janus.Windows.EditControls.UIButton cmdClose;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grCapVT;
        internal Janus.Windows.GridEX.GridEX gdDSNhanVatTu;
        private System.Windows.Forms.Panel pnCenter;
        private Janus.Windows.EditControls.UIButton cmdSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Excel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_Excel;
        private System.Windows.Forms.Panel pnSoPhieu;
        private System.Windows.Forms.Label lblTenVT;
        private System.Windows.Forms.Label lblCBNV;
        private System.Windows.Forms.Label lblSoPhieu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnData;
        private Janus.Windows.EditControls.UIButton cmdXuatExcel;
        private System.Windows.Forms.Label lblWaite;
        private System.Windows.Forms.Label lblTenFile;
        private System.Windows.Forms.Label label5;

    }
}