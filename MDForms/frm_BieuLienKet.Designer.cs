namespace MDSolution.MDForms
{
    partial class frm_BieuLienKet
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
            Janus.Windows.GridEX.GridEXLayout gdChiTietDauTu_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BieuLienKet));
            Janus.Windows.GridEX.GridEXLayout gdChiTietDauTu_Layout_1 = new Janus.Windows.GridEX.GridEXLayout();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabBieuLienKet = new System.Windows.Forms.TabPage();
            this.pnDuLieu = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gdChiTietDauTu = new Janus.Windows.GridEX.GridEX();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.cmdClose = new Janus.Windows.EditControls.UIButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXuatExcelHopDong = new Janus.Windows.EditControls.UIButton();
            this.ComboVuTrong = new Janus.Windows.EditControls.UIComboBox();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBieuLienKet.SuspendLayout();
            this.pnDuLieu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdChiTietDauTu)).BeginInit();
            this.pnBottom.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.Filter = " Excel files (*.xls)|*.xls";
            // 
            // tabBieuLienKet
            // 
            this.tabBieuLienKet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabBieuLienKet.Controls.Add(this.pnDuLieu);
            this.tabBieuLienKet.Controls.Add(this.pnBottom);
            this.tabBieuLienKet.Controls.Add(this.pnTop);
            this.tabBieuLienKet.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabBieuLienKet.ForeColor = System.Drawing.Color.Black;
            this.tabBieuLienKet.Location = new System.Drawing.Point(4, 33);
            this.tabBieuLienKet.Name = "tabBieuLienKet";
            this.tabBieuLienKet.Padding = new System.Windows.Forms.Padding(3);
            this.tabBieuLienKet.Size = new System.Drawing.Size(1260, 656);
            this.tabBieuLienKet.TabIndex = 0;
            this.tabBieuLienKet.Text = "Biểu liên kết";
            this.tabBieuLienKet.UseVisualStyleBackColor = true;
            // 
            // pnDuLieu
            // 
            this.pnDuLieu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnDuLieu.Controls.Add(this.groupBox1);
            this.pnDuLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDuLieu.Location = new System.Drawing.Point(3, 41);
            this.pnDuLieu.Name = "pnDuLieu";
            this.pnDuLieu.Size = new System.Drawing.Size(1250, 563);
            this.pnDuLieu.TabIndex = 78;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gdChiTietDauTu);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1246, 559);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dữ liệu";
            // 
            // gdChiTietDauTu
            // 
            this.gdChiTietDauTu.AllowColumnDrag = false;
            this.gdChiTietDauTu.AlternatingColors = true;
            this.gdChiTietDauTu.AutoEdit = true;
            this.gdChiTietDauTu.AutomaticSort = false;
            this.gdChiTietDauTu.BorderStyle = Janus.Windows.GridEX.BorderStyle.RaisedLight3D;
            this.gdChiTietDauTu.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            this.gdChiTietDauTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdChiTietDauTu.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdChiTietDauTu.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdChiTietDauTu.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gdChiTietDauTu.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdChiTietDauTu.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdChiTietDauTu.Font = new System.Drawing.Font("Arial", 8.25F);
            this.gdChiTietDauTu.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdChiTietDauTu.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdChiTietDauTu.GroupByBoxVisible = false;
            this.gdChiTietDauTu.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdChiTietDauTu.HeaderFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdChiTietDauTu.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdChiTietDauTu.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            gdChiTietDauTu_Layout_0.Key = "ex";
            gdChiTietDauTu_Layout_0.LayoutString = resources.GetString("gdChiTietDauTu_Layout_0.LayoutString");
            gdChiTietDauTu_Layout_1.IsCurrentLayout = true;
            gdChiTietDauTu_Layout_1.Key = "CopyOfex";
            gdChiTietDauTu_Layout_1.LayoutString = resources.GetString("gdChiTietDauTu_Layout_1.LayoutString");
            this.gdChiTietDauTu.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdChiTietDauTu_Layout_0,
            gdChiTietDauTu_Layout_1});
            this.gdChiTietDauTu.LinkFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdChiTietDauTu.Location = new System.Drawing.Point(3, 22);
            this.gdChiTietDauTu.Margin = new System.Windows.Forms.Padding(2);
            this.gdChiTietDauTu.Name = "gdChiTietDauTu";
            this.gdChiTietDauTu.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdChiTietDauTu.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdChiTietDauTu.PreviewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.gdChiTietDauTu.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdChiTietDauTu.RowFormatStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            this.gdChiTietDauTu.RowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.gdChiTietDauTu.RowFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdChiTietDauTu.RowHeaderFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdChiTietDauTu.SelectedFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdChiTietDauTu.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdChiTietDauTu.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdChiTietDauTu.Size = new System.Drawing.Size(1240, 534);
            this.gdChiTietDauTu.TabIndex = 32;
            this.gdChiTietDauTu.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdChiTietDauTu.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdChiTietDauTu.TotalRowFormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.gdChiTietDauTu.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdChiTietDauTu.UpdateOnLeave = false;
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.cmdClose);
            this.pnBottom.Controls.Add(this.label3);
            this.pnBottom.Controls.Add(this.btnXuatExcelHopDong);
            this.pnBottom.Controls.Add(this.ComboVuTrong);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(3, 604);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(1250, 45);
            this.pnBottom.TabIndex = 79;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.Location = new System.Drawing.Point(1122, 6);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(112, 32);
            this.cmdClose.TabIndex = 80;
            this.cmdClose.Text = "Đóng";
            this.cmdClose.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(17, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 19);
            this.label3.TabIndex = 78;
            this.label3.Text = "Chọn niên vụ:";
            // 
            // btnXuatExcelHopDong
            // 
            this.btnXuatExcelHopDong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXuatExcelHopDong.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcelHopDong.Icon = ((System.Drawing.Icon)(resources.GetObject("btnXuatExcelHopDong.Icon")));
            this.btnXuatExcelHopDong.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcelHopDong.Image")));
            this.btnXuatExcelHopDong.Location = new System.Drawing.Point(574, 6);
            this.btnXuatExcelHopDong.Name = "btnXuatExcelHopDong";
            this.btnXuatExcelHopDong.Size = new System.Drawing.Size(112, 32);
            this.btnXuatExcelHopDong.TabIndex = 77;
            this.btnXuatExcelHopDong.Text = "Xuất Excel";
            this.btnXuatExcelHopDong.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.btnXuatExcelHopDong.Click += new System.EventHandler(this.btnXuatExcelHopDong_Click);
            // 
            // ComboVuTrong
            // 
            this.ComboVuTrong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ComboVuTrong.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.ComboVuTrong.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboVuTrong.ForeColor = System.Drawing.Color.Maroon;
            this.ComboVuTrong.Location = new System.Drawing.Point(115, 10);
            this.ComboVuTrong.Name = "ComboVuTrong";
            this.ComboVuTrong.Size = new System.Drawing.Size(137, 29);
            this.ComboVuTrong.TabIndex = 79;
            this.ComboVuTrong.Text = "Chọn vụ trồng";
            this.ComboVuTrong.SelectedIndexChanged += new System.EventHandler(this.ComboVuTrong_SelectedIndexChanged);
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
            this.lblTitle.Text = "BIỂU LIÊN KẾT DỮ LIỆU SLS";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBieuLienKet);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1268, 693);
            this.tabControl1.TabIndex = 0;
            // 
            // frm_BieuLienKet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1268, 693);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_BieuLienKet";
            this.Text = "Biêu liên kết";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_BieuLienKet_Load);
            this.tabBieuLienKet.ResumeLayout(false);
            this.pnDuLieu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdChiTietDauTu)).EndInit();
            this.pnBottom.ResumeLayout(false);
            this.pnBottom.PerformLayout();
            this.pnTop.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabBieuLienKet;
        private System.Windows.Forms.Panel pnDuLieu;
        private Janus.Windows.GridEX.GridEX gdChiTietDauTu;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnBottom;
        private Janus.Windows.EditControls.UIButton cmdClose;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.EditControls.UIButton btnXuatExcelHopDong;
        private Janus.Windows.EditControls.UIComboBox ComboVuTrong;
        private System.Windows.Forms.Label lblTitle;
    }
}