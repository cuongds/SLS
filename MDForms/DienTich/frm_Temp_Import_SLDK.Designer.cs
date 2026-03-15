namespace MDSolution.MDForms.DienTich
{
    partial class frm_Temp_Import_SLDK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Temp_Import_SLDK));
            Janus.Windows.GridEX.GridEXLayout gdDSThuaRuong_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference gdDSThuaRuong_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column12.ButtonImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference gdDSThuaRuong_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column13.ButtonImage");
            this.pnBottom = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWaite = new System.Windows.Forms.Label();
            this.cmdXuatExcel = new Janus.Windows.EditControls.UIButton();
            this.cmdSave = new Janus.Windows.EditControls.UIButton();
            this.cmdClose = new Janus.Windows.EditControls.UIButton();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grNhapDT = new System.Windows.Forms.GroupBox();
            this.gdDSThuaRuong = new Janus.Windows.GridEX.GridEX();
            this.pnCenter = new System.Windows.Forms.Panel();
            this.pnData = new System.Windows.Forms.Panel();
            this.pnThongTin = new System.Windows.Forms.Panel();
            this.lblTenLan = new System.Windows.Forms.Label();
            this.lblTenFile = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCBNV = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog_Excel = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_Excel = new System.Windows.Forms.SaveFileDialog();
            this.pnBottom.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.grNhapDT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdDSThuaRuong)).BeginInit();
            this.pnCenter.SuspendLayout();
            this.pnData.SuspendLayout();
            this.pnThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.label2);
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
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.CausesValidation = false;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(371, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 19);
            this.label2.TabIndex = 89;
            this.label2.Text = "Có lỗi không được cập nhật";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
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
            this.lblTitle.Text = "NHẬP DỮ LIỆU SẢN LƯỢNG THEO CÁN BỘ ĐỊA BÀN NIÊN VỤ ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grNhapDT
            // 
            this.grNhapDT.Controls.Add(this.gdDSThuaRuong);
            this.grNhapDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grNhapDT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grNhapDT.ForeColor = System.Drawing.Color.Purple;
            this.grNhapDT.Location = new System.Drawing.Point(0, 0);
            this.grNhapDT.Name = "grNhapDT";
            this.grNhapDT.Size = new System.Drawing.Size(1254, 473);
            this.grNhapDT.TabIndex = 1;
            this.grNhapDT.TabStop = false;
            this.grNhapDT.Text = "Danh sách thửa ruộng";
            // 
            // gdDSThuaRuong
            // 
            this.gdDSThuaRuong.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdDSThuaRuong.AlternatingColors = true;
            this.gdDSThuaRuong.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
    "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo><EmptyGridInfo>Chưa có dữ liệ" +
    "u</EmptyGridInfo></LocalizableData>";
            this.gdDSThuaRuong.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            gdDSThuaRuong_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("gdDSThuaRuong_DesignTimeLayout_Reference_0.Instance")));
            gdDSThuaRuong_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("gdDSThuaRuong_DesignTimeLayout_Reference_1.Instance")));
            gdDSThuaRuong_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            gdDSThuaRuong_DesignTimeLayout_Reference_0,
            gdDSThuaRuong_DesignTimeLayout_Reference_1});
            gdDSThuaRuong_DesignTimeLayout.LayoutString = resources.GetString("gdDSThuaRuong_DesignTimeLayout.LayoutString");
            this.gdDSThuaRuong.DesignTimeLayout = gdDSThuaRuong_DesignTimeLayout;
            this.gdDSThuaRuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdDSThuaRuong.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdDSThuaRuong.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdDSThuaRuong.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdDSThuaRuong.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdDSThuaRuong.Font = new System.Drawing.Font("Arial", 9F);
            this.gdDSThuaRuong.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdDSThuaRuong.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdDSThuaRuong.GroupByBoxVisible = false;
            this.gdDSThuaRuong.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSThuaRuong.GroupRowFormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.gdDSThuaRuong.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSThuaRuong.HeaderFormatStyle.LineAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdDSThuaRuong.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdDSThuaRuong.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdDSThuaRuong.Location = new System.Drawing.Point(3, 22);
            this.gdDSThuaRuong.Name = "gdDSThuaRuong";
            this.gdDSThuaRuong.NewRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdDSThuaRuong.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSThuaRuong.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdDSThuaRuong.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdDSThuaRuong.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdDSThuaRuong.RowFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDSThuaRuong.RowHeaderFormatStyle.BackColor = System.Drawing.SystemColors.Highlight;
            this.gdDSThuaRuong.RowHeaderFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gdDSThuaRuong.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdDSThuaRuong.ScrollBarWidth = 17;
            this.gdDSThuaRuong.SelectedFormatStyle.BackColor = System.Drawing.Color.Bisque;
            this.gdDSThuaRuong.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSThuaRuong.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDSThuaRuong.Size = new System.Drawing.Size(1248, 448);
            this.gdDSThuaRuong.TabIndex = 12;
            this.gdDSThuaRuong.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.gdDSThuaRuong.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdDSThuaRuong.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSThuaRuong.TotalRowFormatStyle.ForeColor = System.Drawing.Color.Maroon;
            this.gdDSThuaRuong.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdDSThuaRuong.UpdateOnLeave = false;
            this.gdDSThuaRuong.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gdDSThuaRuong_FormattingRow);
            this.gdDSThuaRuong.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdDSThuaRuong_ColumnButtonClick);
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
            this.pnData.Location = new System.Drawing.Point(0, 70);
            this.pnData.Name = "pnData";
            this.pnData.Size = new System.Drawing.Size(1258, 477);
            this.pnData.TabIndex = 84;
            // 
            // pnThongTin
            // 
            this.pnThongTin.Controls.Add(this.lblTenLan);
            this.pnThongTin.Controls.Add(this.lblTenFile);
            this.pnThongTin.Controls.Add(this.label5);
            this.pnThongTin.Controls.Add(this.lblCBNV);
            this.pnThongTin.Controls.Add(this.label1);
            this.pnThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnThongTin.Location = new System.Drawing.Point(0, 0);
            this.pnThongTin.Name = "pnThongTin";
            this.pnThongTin.Size = new System.Drawing.Size(1258, 70);
            this.pnThongTin.TabIndex = 83;
            // 
            // lblTenLan
            // 
            this.lblTenLan.AutoSize = true;
            this.lblTenLan.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenLan.Location = new System.Drawing.Point(1117, 28);
            this.lblTenLan.Name = "lblTenLan";
            this.lblTenLan.Size = new System.Drawing.Size(80, 22);
            this.lblTenLan.TabIndex = 8;
            this.lblTenLan.Text = "TenLan";
            // 
            // lblTenFile
            // 
            this.lblTenFile.AutoSize = true;
            this.lblTenFile.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenFile.Location = new System.Drawing.Point(523, 26);
            this.lblTenFile.Name = "lblTenFile";
            this.lblTenFile.Size = new System.Drawing.Size(78, 22);
            this.lblTenFile.TabIndex = 7;
            this.lblTenFile.Text = "TenFile";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(441, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tên file excel:";
            // 
            // lblCBNV
            // 
            this.lblCBNV.AutoSize = true;
            this.lblCBNV.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCBNV.Location = new System.Drawing.Point(123, 26);
            this.lblCBNV.Name = "lblCBNV";
            this.lblCBNV.Size = new System.Drawing.Size(64, 22);
            this.lblCBNV.TabIndex = 4;
            this.lblCBNV.Text = "CBNV";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cán bộ địa bàn:";
            // 
            // openFileDialog_Excel
            // 
            this.openFileDialog_Excel.FileName = "openFileDialog_Excel";
            // 
            // saveFileDialog_Excel
            // 
            this.saveFileDialog_Excel.Filter = " Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            // 
            // frm_Temp_Import_SLDK
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
            this.Name = "frm_Temp_Import_SLDK";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhập sản lượng";
            this.Load += new System.EventHandler(this.frm_Temp_Import_SLDK_Load);
            this.pnBottom.ResumeLayout(false);
            this.pnBottom.PerformLayout();
            this.pnTop.ResumeLayout(false);
            this.grNhapDT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdDSThuaRuong)).EndInit();
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
        internal Janus.Windows.GridEX.GridEX gdDSThuaRuong;
        private System.Windows.Forms.Panel pnCenter;
        private Janus.Windows.EditControls.UIButton cmdSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Excel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_Excel;
        private System.Windows.Forms.Panel pnThongTin;
        private System.Windows.Forms.Label lblCBNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnData;
        private Janus.Windows.EditControls.UIButton cmdXuatExcel;
        private System.Windows.Forms.Label lblWaite;
        private System.Windows.Forms.Label lblTenFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTenLan;

    }
}