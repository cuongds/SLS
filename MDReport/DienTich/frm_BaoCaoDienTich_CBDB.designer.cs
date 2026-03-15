namespace MDSolution.MDForms.DienTich
{
    partial class frm_BaoCaoDienTich_CBDB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Janus.Windows.GridEX.GridEXLayout gdTongHopDienTich_CBDB_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BaoCaoDienTich_CBDB));
            Janus.Windows.GridEX.GridEXLayout gdTongHopDienTich_CBDB_Layout_1 = new Janus.Windows.GridEX.GridEXLayout();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabBieuLienKet = new System.Windows.Forms.TabPage();
            this.pnDuLieu = new System.Windows.Forms.Panel();
            this.grDT = new System.Windows.Forms.GroupBox();
            this.gdTongHopDienTich_CBDB = new Janus.Windows.GridEX.GridEX();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.cmdClose = new Janus.Windows.EditControls.UIButton();
            this.btnXuatExcelDT_CBDB = new Janus.Windows.EditControls.UIButton();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabTraCuuDienTich = new System.Windows.Forms.TabControl();
            this.tabBieuLienKet.SuspendLayout();
            this.pnDuLieu.SuspendLayout();
            this.grDT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdTongHopDienTich_CBDB)).BeginInit();
            this.pnBottom.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.tabTraCuuDienTich.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xls";
            this.saveFileDialog.Filter = " Excel files (*.xls)|*.xls";
            // 
            // tabBieuLienKet
            // 
            this.tabBieuLienKet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabBieuLienKet.Controls.Add(this.pnDuLieu);
            this.tabBieuLienKet.Controls.Add(this.pnBottom);
            this.tabBieuLienKet.Controls.Add(this.pnTop);
            this.tabBieuLienKet.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabBieuLienKet.ForeColor = System.Drawing.Color.Black;
            this.tabBieuLienKet.Location = new System.Drawing.Point(4, 28);
            this.tabBieuLienKet.Name = "tabBieuLienKet";
            this.tabBieuLienKet.Padding = new System.Windows.Forms.Padding(3);
            this.tabBieuLienKet.Size = new System.Drawing.Size(1260, 661);
            this.tabBieuLienKet.TabIndex = 0;
            this.tabBieuLienKet.Text = "DIỆN TÍCH";
            this.tabBieuLienKet.UseVisualStyleBackColor = true;
            // 
            // pnDuLieu
            // 
            this.pnDuLieu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnDuLieu.Controls.Add(this.grDT);
            this.pnDuLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDuLieu.Location = new System.Drawing.Point(3, 41);
            this.pnDuLieu.Name = "pnDuLieu";
            this.pnDuLieu.Size = new System.Drawing.Size(1250, 562);
            this.pnDuLieu.TabIndex = 78;
            // 
            // grDT
            // 
            this.grDT.Controls.Add(this.gdTongHopDienTich_CBDB);
            this.grDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grDT.ForeColor = System.Drawing.Color.Maroon;
            this.grDT.Location = new System.Drawing.Point(0, 0);
            this.grDT.Name = "grDT";
            this.grDT.Size = new System.Drawing.Size(1246, 558);
            this.grDT.TabIndex = 33;
            this.grDT.TabStop = false;
            this.grDT.Text = "Dữ liệu";
            // 
            // gdTongHopDienTich_CBDB
            // 
            this.gdTongHopDienTich_CBDB.AllowColumnDrag = false;
            this.gdTongHopDienTich_CBDB.AlternatingColors = true;
            this.gdTongHopDienTich_CBDB.AutoEdit = true;
            this.gdTongHopDienTich_CBDB.AutomaticSort = false;
            this.gdTongHopDienTich_CBDB.BorderStyle = Janus.Windows.GridEX.BorderStyle.RaisedLight3D;
            this.gdTongHopDienTich_CBDB.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            this.gdTongHopDienTich_CBDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdTongHopDienTich_CBDB.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdTongHopDienTich_CBDB.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdTongHopDienTich_CBDB.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gdTongHopDienTich_CBDB.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdTongHopDienTich_CBDB.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdTongHopDienTich_CBDB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdTongHopDienTich_CBDB.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdTongHopDienTich_CBDB.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdTongHopDienTich_CBDB.GroupByBoxVisible = false;
            this.gdTongHopDienTich_CBDB.GroupRowFormatStyle.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.gdTongHopDienTich_CBDB.GroupRowFormatStyle.ForeColor = System.Drawing.Color.Maroon;
            this.gdTongHopDienTich_CBDB.GroupTotalRowFormatStyle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gdTongHopDienTich_CBDB.GroupTotalRowFormatStyle.ForeColor = System.Drawing.Color.DarkBlue;
            this.gdTongHopDienTich_CBDB.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            this.gdTongHopDienTich_CBDB.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdTongHopDienTich_CBDB.HeaderFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdTongHopDienTich_CBDB.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdTongHopDienTich_CBDB.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            gdTongHopDienTich_CBDB_Layout_0.Key = "ex";
            gdTongHopDienTich_CBDB_Layout_0.LayoutString = resources.GetString("gdTongHopDienTich_CBDB_Layout_0.LayoutString");
            gdTongHopDienTich_CBDB_Layout_1.IsCurrentLayout = true;
            gdTongHopDienTich_CBDB_Layout_1.Key = "CopyOfex";
            gdTongHopDienTich_CBDB_Layout_1.LayoutString = resources.GetString("gdTongHopDienTich_CBDB_Layout_1.LayoutString");
            this.gdTongHopDienTich_CBDB.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdTongHopDienTich_CBDB_Layout_0,
            gdTongHopDienTich_CBDB_Layout_1});
            this.gdTongHopDienTich_CBDB.LinkFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdTongHopDienTich_CBDB.Location = new System.Drawing.Point(3, 18);
            this.gdTongHopDienTich_CBDB.Margin = new System.Windows.Forms.Padding(2);
            this.gdTongHopDienTich_CBDB.Name = "gdTongHopDienTich_CBDB";
            this.gdTongHopDienTich_CBDB.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdTongHopDienTich_CBDB.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdTongHopDienTich_CBDB.PreviewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.gdTongHopDienTich_CBDB.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdTongHopDienTich_CBDB.RowFormatStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            this.gdTongHopDienTich_CBDB.RowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.gdTongHopDienTich_CBDB.RowFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdTongHopDienTich_CBDB.RowHeaderFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdTongHopDienTich_CBDB.SelectedFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdTongHopDienTich_CBDB.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdTongHopDienTich_CBDB.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdTongHopDienTich_CBDB.Size = new System.Drawing.Size(1240, 537);
            this.gdTongHopDienTich_CBDB.TabIndex = 32;
            this.gdTongHopDienTich_CBDB.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdTongHopDienTich_CBDB.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdTongHopDienTich_CBDB.TotalRowFormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.gdTongHopDienTich_CBDB.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdTongHopDienTich_CBDB.UpdateOnLeave = false;
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.cmdClose);
            this.pnBottom.Controls.Add(this.btnXuatExcelDT_CBDB);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnBottom.Location = new System.Drawing.Point(3, 603);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(1250, 51);
            this.pnBottom.TabIndex = 79;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.Location = new System.Drawing.Point(1122, 10);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(112, 32);
            this.cmdClose.TabIndex = 80;
            this.cmdClose.Text = "Đóng";
            this.cmdClose.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // btnXuatExcelDT_CBDB
            // 
            this.btnXuatExcelDT_CBDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatExcelDT_CBDB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcelDT_CBDB.Icon = ((System.Drawing.Icon)(resources.GetObject("btnXuatExcelDT_CBDB.Icon")));
            this.btnXuatExcelDT_CBDB.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcelDT_CBDB.Image")));
            this.btnXuatExcelDT_CBDB.Location = new System.Drawing.Point(983, 10);
            this.btnXuatExcelDT_CBDB.Name = "btnXuatExcelDT_CBDB";
            this.btnXuatExcelDT_CBDB.Size = new System.Drawing.Size(112, 32);
            this.btnXuatExcelDT_CBDB.TabIndex = 77;
            this.btnXuatExcelDT_CBDB.Text = "Xuất Excel";
            this.btnXuatExcelDT_CBDB.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.btnXuatExcelDT_CBDB.Click += new System.EventHandler(this.btnXuatExcelDT_CBDB_Click);
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lblTitle);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(3, 3);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1250, 38);
            this.pnTop.TabIndex = 77;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1250, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DỮ LIỆU DIỆN TÍCH CÁN BỘ ĐỊA BÀN SLS NIÊN VỤ ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabTraCuuDienTich
            // 
            this.tabTraCuuDienTich.Controls.Add(this.tabBieuLienKet);
            this.tabTraCuuDienTich.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTraCuuDienTich.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTraCuuDienTich.Location = new System.Drawing.Point(0, 0);
            this.tabTraCuuDienTich.Name = "tabTraCuuDienTich";
            this.tabTraCuuDienTich.SelectedIndex = 0;
            this.tabTraCuuDienTich.Size = new System.Drawing.Size(1268, 693);
            this.tabTraCuuDienTich.TabIndex = 0;
            // 
            // frm_BaoCaoDienTich_CBDB
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1268, 693);
            this.Controls.Add(this.tabTraCuuDienTich);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_BaoCaoDienTich_CBDB";
            this.ShowIcon = false;
            this.Text = "Diện tích CBĐB";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_BaoCaoDienTich_CBDB_Load);
            this.tabBieuLienKet.ResumeLayout(false);
            this.pnDuLieu.ResumeLayout(false);
            this.grDT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdTongHopDienTich_CBDB)).EndInit();
            this.pnBottom.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.tabTraCuuDienTich.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TabPage tabBieuLienKet;
        private System.Windows.Forms.Panel pnDuLieu;
        private Janus.Windows.GridEX.GridEX gdTongHopDienTich_CBDB;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.TabControl tabTraCuuDienTich;
        private System.Windows.Forms.GroupBox grDT;
        private System.Windows.Forms.Panel pnBottom;
        private Janus.Windows.EditControls.UIButton cmdClose;
        private Janus.Windows.EditControls.UIButton btnXuatExcelDT_CBDB;
        private System.Windows.Forms.Label lblTitle;
    }
}