namespace MDSolution.MDForms
{
    partial class frm_DauTuVatTu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DauTuVatTu));
            Janus.Windows.GridEX.GridEXLayout gdChiTietDauTuTong_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gdChiTietDauTuTong_Layout_1 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gdChiTietDauTu_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gdChiTietDauTu_Layout_1 = new Janus.Windows.GridEX.GridEXLayout();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cmdAddHD = new Janus.Windows.EditControls.UIButton();
            this.btnXuatExcelHopDong = new Janus.Windows.EditControls.UIButton();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboVuTrong = new Janus.Windows.EditControls.UIComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gdChiTietDauTuTong = new Janus.Windows.GridEX.GridEX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gdChiTietDauTu = new Janus.Windows.GridEX.GridEX();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXuatExcelHopDong1 = new Janus.Windows.EditControls.UIButton();
            this.ComboVuTrong1 = new Janus.Windows.EditControls.UIComboBox();
            this.cmdAddHD1 = new Janus.Windows.EditControls.UIButton();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdChiTietDauTuTong)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdChiTietDauTu)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.Filter = " Excel files (*.xls)|*.xls";
            // 
            // cmdAddHD
            // 
            this.cmdAddHD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAddHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddHD.Icon = ((System.Drawing.Icon)(resources.GetObject("cmdAddHD.Icon")));
            this.cmdAddHD.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddHD.Image")));
            this.cmdAddHD.Location = new System.Drawing.Point(272, 5);
            this.cmdAddHD.Name = "cmdAddHD";
            this.cmdAddHD.Size = new System.Drawing.Size(112, 36);
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
            this.btnXuatExcelHopDong.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcelHopDong.Image")));
            this.btnXuatExcelHopDong.Location = new System.Drawing.Point(401, 5);
            this.btnXuatExcelHopDong.Name = "btnXuatExcelHopDong";
            this.btnXuatExcelHopDong.Size = new System.Drawing.Size(121, 36);
            this.btnXuatExcelHopDong.TabIndex = 74;
            this.btnXuatExcelHopDong.Text = "Xuất Excel";
            this.btnXuatExcelHopDong.Click += new System.EventHandler(this.btnXuatExcelHopDong_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(8, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 75;
            this.label3.Text = "Vụ trồng:";
            // 
            // ComboVuTrong
            // 
            this.ComboVuTrong.Location = new System.Drawing.Point(79, 12);
            this.ComboVuTrong.Name = "ComboVuTrong";
            this.ComboVuTrong.Size = new System.Drawing.Size(164, 22);
            this.ComboVuTrong.TabIndex = 76;
            this.ComboVuTrong.Text = "Chọn vụ trồng";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1363, 667);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tổng đầu tư";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gdChiTietDauTuTong);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1357, 611);
            this.panel2.TabIndex = 35;
            // 
            // gdChiTietDauTuTong
            // 
            this.gdChiTietDauTuTong.AllowColumnDrag = false;
            this.gdChiTietDauTuTong.AlternatingColors = true;
            this.gdChiTietDauTuTong.AutoEdit = true;
            this.gdChiTietDauTuTong.AutomaticSort = false;
            this.gdChiTietDauTuTong.BorderStyle = Janus.Windows.GridEX.BorderStyle.RaisedLight3D;
            this.gdChiTietDauTuTong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdChiTietDauTuTong.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdChiTietDauTuTong.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdChiTietDauTuTong.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gdChiTietDauTuTong.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdChiTietDauTuTong.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdChiTietDauTuTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdChiTietDauTuTong.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdChiTietDauTuTong.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdChiTietDauTuTong.GroupByBoxVisible = false;
            this.gdChiTietDauTuTong.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdChiTietDauTuTong.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdChiTietDauTuTong.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            gdChiTietDauTuTong_Layout_0.Key = "ex";
            gdChiTietDauTuTong_Layout_0.LayoutString = resources.GetString("gdChiTietDauTuTong_Layout_0.LayoutString");
            gdChiTietDauTuTong_Layout_1.IsCurrentLayout = true;
            gdChiTietDauTuTong_Layout_1.Key = "CopyOfex";
            gdChiTietDauTuTong_Layout_1.LayoutString = resources.GetString("gdChiTietDauTuTong_Layout_1.LayoutString");
            this.gdChiTietDauTuTong.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdChiTietDauTuTong_Layout_0,
            gdChiTietDauTuTong_Layout_1});
            this.gdChiTietDauTuTong.LinkFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdChiTietDauTuTong.Location = new System.Drawing.Point(0, 0);
            this.gdChiTietDauTuTong.Margin = new System.Windows.Forms.Padding(2);
            this.gdChiTietDauTuTong.Name = "gdChiTietDauTuTong";
            this.gdChiTietDauTuTong.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdChiTietDauTuTong.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdChiTietDauTuTong.PreviewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.gdChiTietDauTuTong.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdChiTietDauTuTong.RowFormatStyle.Font = new System.Drawing.Font("Arial", 9F);
            this.gdChiTietDauTuTong.RowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.gdChiTietDauTuTong.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdChiTietDauTuTong.RowHeaderFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdChiTietDauTuTong.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both;
            this.gdChiTietDauTuTong.SelectedFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdChiTietDauTuTong.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdChiTietDauTuTong.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdChiTietDauTuTong.Size = new System.Drawing.Size(1357, 611);
            this.gdChiTietDauTuTong.TabIndex = 33;
            this.gdChiTietDauTuTong.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdChiTietDauTuTong.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdChiTietDauTuTong.UpdateOnLeave = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnXuatExcelHopDong1);
            this.panel1.Controls.Add(this.ComboVuTrong1);
            this.panel1.Controls.Add(this.cmdAddHD1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1357, 50);
            this.panel1.TabIndex = 34;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1371, 693);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1363, 667);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chi tiết đầu tư";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gdChiTietDauTu);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1357, 611);
            this.panel4.TabIndex = 78;
            // 
            // gdChiTietDauTu
            // 
            this.gdChiTietDauTu.AllowColumnDrag = false;
            this.gdChiTietDauTu.AlternatingColors = true;
            this.gdChiTietDauTu.AutoEdit = true;
            this.gdChiTietDauTu.AutomaticSort = false;
            this.gdChiTietDauTu.BorderStyle = Janus.Windows.GridEX.BorderStyle.RaisedLight3D;
            this.gdChiTietDauTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdChiTietDauTu.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdChiTietDauTu.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdChiTietDauTu.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gdChiTietDauTu.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdChiTietDauTu.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdChiTietDauTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdChiTietDauTu.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdChiTietDauTu.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdChiTietDauTu.GroupByBoxVisible = false;
            this.gdChiTietDauTu.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
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
            this.gdChiTietDauTu.Location = new System.Drawing.Point(0, 0);
            this.gdChiTietDauTu.Margin = new System.Windows.Forms.Padding(2);
            this.gdChiTietDauTu.Name = "gdChiTietDauTu";
            this.gdChiTietDauTu.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdChiTietDauTu.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdChiTietDauTu.PreviewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.gdChiTietDauTu.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdChiTietDauTu.RowFormatStyle.Font = new System.Drawing.Font("Arial", 9F);
            this.gdChiTietDauTu.RowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.gdChiTietDauTu.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdChiTietDauTu.RowHeaderFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdChiTietDauTu.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both;
            this.gdChiTietDauTu.SelectedFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdChiTietDauTu.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdChiTietDauTu.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdChiTietDauTu.Size = new System.Drawing.Size(1357, 611);
            this.gdChiTietDauTu.TabIndex = 32;
            this.gdChiTietDauTu.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdChiTietDauTu.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdChiTietDauTu.UpdateOnLeave = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnXuatExcelHopDong);
            this.panel3.Controls.Add(this.ComboVuTrong);
            this.panel3.Controls.Add(this.cmdAddHD);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1357, 50);
            this.panel3.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 79;
            this.label1.Text = "Vụ trồng:";
            // 
            // btnXuatExcelHopDong1
            // 
            this.btnXuatExcelHopDong1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXuatExcelHopDong1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcelHopDong1.Icon = ((System.Drawing.Icon)(resources.GetObject("btnXuatExcelHopDong1.Icon")));
            this.btnXuatExcelHopDong1.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcelHopDong1.Image")));
            this.btnXuatExcelHopDong1.Location = new System.Drawing.Point(409, 3);
            this.btnXuatExcelHopDong1.Name = "btnXuatExcelHopDong1";
            this.btnXuatExcelHopDong1.Size = new System.Drawing.Size(121, 36);
            this.btnXuatExcelHopDong1.TabIndex = 78;
            this.btnXuatExcelHopDong1.Text = "Xuất Excel";
            this.btnXuatExcelHopDong1.Click += new System.EventHandler(this.btnXuatExcelHopDong1_Click);
            // 
            // ComboVuTrong1
            // 
            this.ComboVuTrong1.Location = new System.Drawing.Point(87, 10);
            this.ComboVuTrong1.Name = "ComboVuTrong1";
            this.ComboVuTrong1.Size = new System.Drawing.Size(164, 22);
            this.ComboVuTrong1.TabIndex = 80;
            this.ComboVuTrong1.Text = "Chọn vụ trồng";
            // 
            // cmdAddHD1
            // 
            this.cmdAddHD1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAddHD1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddHD1.Icon = ((System.Drawing.Icon)(resources.GetObject("cmdAddHD1.Icon")));
            this.cmdAddHD1.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddHD1.Image")));
            this.cmdAddHD1.Location = new System.Drawing.Point(280, 3);
            this.cmdAddHD1.Name = "cmdAddHD1";
            this.cmdAddHD1.Size = new System.Drawing.Size(112, 36);
            this.cmdAddHD1.TabIndex = 77;
            this.cmdAddHD1.Text = "Tìm kiếm";
            this.cmdAddHD1.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            this.cmdAddHD1.Click += new System.EventHandler(this.cmdAddHD1_Click);
            // 
            // frm_DauTuVatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 693);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_DauTuVatTu";
            this.Text = "Theo dõi đầu tư";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_DauTuVatTu_Load);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdChiTietDauTuTong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdChiTietDauTu)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Janus.Windows.EditControls.UIButton cmdAddHD;
        private Janus.Windows.EditControls.UIButton btnXuatExcelHopDong;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.EditControls.UIComboBox ComboVuTrong;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Janus.Windows.GridEX.GridEX gdChiTietDauTu;
        private System.Windows.Forms.TabPage tabPage2;
        private Janus.Windows.GridEX.GridEX gdChiTietDauTuTong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton btnXuatExcelHopDong1;
        private Janus.Windows.EditControls.UIComboBox ComboVuTrong1;
        private Janus.Windows.EditControls.UIButton cmdAddHD1;
    }
}