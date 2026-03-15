namespace MDSolution.MDForms.UngTien
{
    partial class frm_Temp_Import_UngVanChuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Temp_Import_UngVanChuyen));
            Janus.Windows.GridEX.GridEXLayout gdDSUngVanChuyen_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference gdDSUngVanChuyen_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column10.ButtonImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference gdDSUngVanChuyen_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column11.ButtonImage");
            this.pnBottom = new System.Windows.Forms.Panel();
            this.lblWaite = new System.Windows.Forms.Label();
            this.cmdXuatExcel = new Janus.Windows.EditControls.UIButton();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grNhapDT = new System.Windows.Forms.GroupBox();
            this.gdDSUngVanChuyen = new Janus.Windows.GridEX.GridEX();
            this.pnCenter = new System.Windows.Forms.Panel();
            this.pnData = new System.Windows.Forms.Panel();
            this.pnThongTin = new System.Windows.Forms.Panel();
            this.lblTenFile = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog_Excel = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_Excel = new System.Windows.Forms.SaveFileDialog();
            this.cmdSave = new Janus.Windows.EditControls.UIButton();
            this.cmdClose = new Janus.Windows.EditControls.UIButton();
            this.pnBottom.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.grNhapDT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdDSUngVanChuyen)).BeginInit();
            this.pnCenter.SuspendLayout();
            this.pnData.SuspendLayout();
            this.pnThongTin.SuspendLayout();
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
            this.pnBottom.Size = new System.Drawing.Size(1262, 45);
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
            this.lblWaite.Size = new System.Drawing.Size(118, 19);
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
            this.cmdXuatExcel.Location = new System.Drawing.Point(991, 7);
            this.cmdXuatExcel.Name = "cmdXuatExcel";
            this.cmdXuatExcel.Size = new System.Drawing.Size(100, 30);
            this.cmdXuatExcel.TabIndex = 82;
            this.cmdXuatExcel.Text = "Xuất Excel";
            this.cmdXuatExcel.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdXuatExcel.Click += new System.EventHandler(this.cmdXuatExcel_Click);
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lblTitle);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1262, 38);
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
            this.lblTitle.Size = new System.Drawing.Size(1262, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "NHẬP ỨNG TIỀN VẬN CHUYỂN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grNhapDT
            // 
            this.grNhapDT.Controls.Add(this.gdDSUngVanChuyen);
            this.grNhapDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grNhapDT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grNhapDT.ForeColor = System.Drawing.Color.Purple;
            this.grNhapDT.Location = new System.Drawing.Point(0, 0);
            this.grNhapDT.Name = "grNhapDT";
            this.grNhapDT.Size = new System.Drawing.Size(1254, 498);
            this.grNhapDT.TabIndex = 1;
            this.grNhapDT.TabStop = false;
            this.grNhapDT.Text = "Danh mới tạo của đợt";
            // 
            // gdDSUngVanChuyen
            // 
            this.gdDSUngVanChuyen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdDSUngVanChuyen.AlternatingColors = true;
            this.gdDSUngVanChuyen.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
    "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo><EmptyGridInfo>Chưa có dữ liệ" +
    "u</EmptyGridInfo></LocalizableData>";
            this.gdDSUngVanChuyen.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            gdDSUngVanChuyen_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("gdDSUngVanChuyen_DesignTimeLayout_Reference_0.Instance")));
            gdDSUngVanChuyen_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("gdDSUngVanChuyen_DesignTimeLayout_Reference_1.Instance")));
            gdDSUngVanChuyen_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            gdDSUngVanChuyen_DesignTimeLayout_Reference_0,
            gdDSUngVanChuyen_DesignTimeLayout_Reference_1});
            gdDSUngVanChuyen_DesignTimeLayout.LayoutString = resources.GetString("gdDSUngVanChuyen_DesignTimeLayout.LayoutString");
            this.gdDSUngVanChuyen.DesignTimeLayout = gdDSUngVanChuyen_DesignTimeLayout;
            this.gdDSUngVanChuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdDSUngVanChuyen.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdDSUngVanChuyen.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdDSUngVanChuyen.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdDSUngVanChuyen.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdDSUngVanChuyen.Font = new System.Drawing.Font("Arial", 9F);
            this.gdDSUngVanChuyen.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdDSUngVanChuyen.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdDSUngVanChuyen.GroupByBoxVisible = false;
            this.gdDSUngVanChuyen.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSUngVanChuyen.GroupRowFormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.gdDSUngVanChuyen.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSUngVanChuyen.HeaderFormatStyle.LineAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdDSUngVanChuyen.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdDSUngVanChuyen.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdDSUngVanChuyen.Location = new System.Drawing.Point(3, 22);
            this.gdDSUngVanChuyen.Name = "gdDSUngVanChuyen";
            this.gdDSUngVanChuyen.NewRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdDSUngVanChuyen.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSUngVanChuyen.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdDSUngVanChuyen.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdDSUngVanChuyen.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdDSUngVanChuyen.RowFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDSUngVanChuyen.RowHeaderFormatStyle.BackColor = System.Drawing.SystemColors.Highlight;
            this.gdDSUngVanChuyen.RowHeaderFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gdDSUngVanChuyen.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdDSUngVanChuyen.ScrollBarWidth = 17;
            this.gdDSUngVanChuyen.SelectedFormatStyle.BackColor = System.Drawing.Color.Bisque;
            this.gdDSUngVanChuyen.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSUngVanChuyen.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDSUngVanChuyen.Size = new System.Drawing.Size(1248, 473);
            this.gdDSUngVanChuyen.TabIndex = 12;
            this.gdDSUngVanChuyen.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.gdDSUngVanChuyen.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdDSUngVanChuyen.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSUngVanChuyen.TotalRowFormatStyle.ForeColor = System.Drawing.Color.Maroon;
            this.gdDSUngVanChuyen.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdDSUngVanChuyen.UpdateOnLeave = false;
            this.gdDSUngVanChuyen.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gdDSThuaRuong_FormattingRow);
            this.gdDSUngVanChuyen.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdDSThuaRuong_ColumnButtonClick);
            // 
            // pnCenter
            // 
            this.pnCenter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnCenter.Controls.Add(this.pnData);
            this.pnCenter.Controls.Add(this.pnThongTin);
            this.pnCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCenter.Location = new System.Drawing.Point(0, 38);
            this.pnCenter.Name = "pnCenter";
            this.pnCenter.Size = new System.Drawing.Size(1262, 551);
            this.pnCenter.TabIndex = 82;
            // 
            // pnData
            // 
            this.pnData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnData.Controls.Add(this.grNhapDT);
            this.pnData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnData.Location = new System.Drawing.Point(0, 45);
            this.pnData.Name = "pnData";
            this.pnData.Size = new System.Drawing.Size(1258, 502);
            this.pnData.TabIndex = 84;
            // 
            // pnThongTin
            // 
            this.pnThongTin.Controls.Add(this.lblTenFile);
            this.pnThongTin.Controls.Add(this.label5);
            this.pnThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnThongTin.Location = new System.Drawing.Point(0, 0);
            this.pnThongTin.Name = "pnThongTin";
            this.pnThongTin.Size = new System.Drawing.Size(1258, 45);
            this.pnThongTin.TabIndex = 83;
            // 
            // lblTenFile
            // 
            this.lblTenFile.AutoSize = true;
            this.lblTenFile.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenFile.Location = new System.Drawing.Point(150, 13);
            this.lblTenFile.Name = "lblTenFile";
            this.lblTenFile.Size = new System.Drawing.Size(78, 22);
            this.lblTenFile.TabIndex = 7;
            this.lblTenFile.Text = "TenFile";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tên file excel:";
            // 
            // openFileDialog_Excel
            // 
            this.openFileDialog_Excel.FileName = "openFileDialog_Excel";
            // 
            // saveFileDialog_Excel
            // 
            this.saveFileDialog_Excel.Filter = " Excel files (*.xls)|*.xls|All files (*.*)|*.*";
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
            this.cmdClose.Location = new System.Drawing.Point(1134, 7);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(100, 30);
            this.cmdClose.TabIndex = 83;
            this.cmdClose.Text = "Đóng";
            this.cmdClose.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frm_Temp_Import_UngVanChuyen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1262, 634);
            this.Controls.Add(this.pnCenter);
            this.Controls.Add(this.pnTop);
            this.Controls.Add(this.pnBottom);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Temp_Import_UngVanChuyen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhập ứng tiền vận chuyển";
            this.Load += new System.EventHandler(this.frm_Temp_Import_UngVanChuyen_Load);
            this.pnBottom.ResumeLayout(false);
            this.pnBottom.PerformLayout();
            this.pnTop.ResumeLayout(false);
            this.grNhapDT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdDSUngVanChuyen)).EndInit();
            this.pnCenter.ResumeLayout(false);
            this.pnData.ResumeLayout(false);
            this.pnThongTin.ResumeLayout(false);
            this.pnThongTin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBottom;
        private Janus.Windows.EditControls.UIButton cmdClose;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grNhapDT;
        internal Janus.Windows.GridEX.GridEX gdDSUngVanChuyen;
        private System.Windows.Forms.Panel pnCenter;
        private Janus.Windows.EditControls.UIButton cmdSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Excel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_Excel;
        private System.Windows.Forms.Panel pnThongTin;
        private System.Windows.Forms.Panel pnData;
        private Janus.Windows.EditControls.UIButton cmdXuatExcel;
        private System.Windows.Forms.Label lblWaite;
        private System.Windows.Forms.Label lblTenFile;
        private System.Windows.Forms.Label label5;

    }
}