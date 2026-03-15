namespace MDSolution.MDForms
{
    partial class frm_ShowDinhMucDauTu
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
            Janus.Windows.GridEX.GridEXLayout gdDinhMucDauTu_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ShowDinhMucDauTu));
            Janus.Windows.GridEX.GridEXLayout gdDinhMucDauTu_Layout_1 = new Janus.Windows.GridEX.GridEXLayout();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabBieuLienKet = new System.Windows.Forms.TabPage();
            this.pnDuLieu = new System.Windows.Forms.Panel();
            this.grDL = new System.Windows.Forms.GroupBox();
            this.gdDinhMucDauTu = new Janus.Windows.GridEX.GridEX();
            this.tvDonVi = new System.Windows.Forms.TreeView();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.cmdPrint = new Janus.Windows.EditControls.UIButton();
            this.cmdClose = new Janus.Windows.EditControls.UIButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXuatExcelDinhMucDauTu = new Janus.Windows.EditControls.UIButton();
            this.ComboVuTrong = new Janus.Windows.EditControls.UIComboBox();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabDinhMucDT = new System.Windows.Forms.TabControl();
            this.tabBieuLienKet.SuspendLayout();
            this.pnDuLieu.SuspendLayout();
            this.grDL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdDinhMucDauTu)).BeginInit();
            this.pnBottom.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.tabDinhMucDT.SuspendLayout();
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
            this.tabBieuLienKet.Text = "Xem định mức";
            this.tabBieuLienKet.UseVisualStyleBackColor = true;
            // 
            // pnDuLieu
            // 
            this.pnDuLieu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnDuLieu.Controls.Add(this.grDL);
            this.pnDuLieu.Controls.Add(this.tvDonVi);
            this.pnDuLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDuLieu.Location = new System.Drawing.Point(3, 41);
            this.pnDuLieu.Name = "pnDuLieu";
            this.pnDuLieu.Size = new System.Drawing.Size(1250, 568);
            this.pnDuLieu.TabIndex = 78;
            // 
            // grDL
            // 
            this.grDL.Controls.Add(this.gdDinhMucDauTu);
            this.grDL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDL.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grDL.ForeColor = System.Drawing.Color.Maroon;
            this.grDL.Location = new System.Drawing.Point(234, 0);
            this.grDL.Name = "grDL";
            this.grDL.Size = new System.Drawing.Size(1012, 564);
            this.grDL.TabIndex = 33;
            this.grDL.TabStop = false;
            this.grDL.Text = "Tất cả CBNV";
            // 
            // gdDinhMucDauTu
            // 
            this.gdDinhMucDauTu.AllowColumnDrag = false;
            this.gdDinhMucDauTu.AlternatingColors = true;
            this.gdDinhMucDauTu.AutoEdit = true;
            this.gdDinhMucDauTu.AutomaticSort = false;
            this.gdDinhMucDauTu.BorderStyle = Janus.Windows.GridEX.BorderStyle.RaisedLight3D;
            this.gdDinhMucDauTu.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            this.gdDinhMucDauTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdDinhMucDauTu.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdDinhMucDauTu.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gdDinhMucDauTu.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdDinhMucDauTu.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdDinhMucDauTu.Font = new System.Drawing.Font("Arial", 8.25F);
            this.gdDinhMucDauTu.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdDinhMucDauTu.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdDinhMucDauTu.GroupByBoxVisible = false;
            this.gdDinhMucDauTu.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDinhMucDauTu.HeaderFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDinhMucDauTu.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdDinhMucDauTu.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            gdDinhMucDauTu_Layout_0.Key = "ex";
            gdDinhMucDauTu_Layout_0.LayoutString = resources.GetString("gdDinhMucDauTu_Layout_0.LayoutString");
            gdDinhMucDauTu_Layout_1.IsCurrentLayout = true;
            gdDinhMucDauTu_Layout_1.Key = "CopyOfex";
            gdDinhMucDauTu_Layout_1.LayoutString = resources.GetString("gdDinhMucDauTu_Layout_1.LayoutString");
            this.gdDinhMucDauTu.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdDinhMucDauTu_Layout_0,
            gdDinhMucDauTu_Layout_1});
            this.gdDinhMucDauTu.LinkFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDinhMucDauTu.Location = new System.Drawing.Point(3, 18);
            this.gdDinhMucDauTu.Margin = new System.Windows.Forms.Padding(2);
            this.gdDinhMucDauTu.Name = "gdDinhMucDauTu";
            this.gdDinhMucDauTu.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdDinhMucDauTu.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdDinhMucDauTu.PreviewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.gdDinhMucDauTu.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdDinhMucDauTu.RowFormatStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            this.gdDinhMucDauTu.RowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.gdDinhMucDauTu.RowFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDinhMucDauTu.RowHeaderFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdDinhMucDauTu.SelectedFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdDinhMucDauTu.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDinhMucDauTu.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDinhMucDauTu.Size = new System.Drawing.Size(1006, 543);
            this.gdDinhMucDauTu.TabIndex = 32;
            this.gdDinhMucDauTu.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdDinhMucDauTu.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDinhMucDauTu.TotalRowFormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.gdDinhMucDauTu.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdDinhMucDauTu.UpdateOnLeave = false;
            // 
            // tvDonVi
            // 
            this.tvDonVi.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvDonVi.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvDonVi.ForeColor = System.Drawing.Color.Black;
            this.tvDonVi.HideSelection = false;
            this.tvDonVi.Location = new System.Drawing.Point(0, 0);
            this.tvDonVi.Name = "tvDonVi";
            this.tvDonVi.Size = new System.Drawing.Size(234, 564);
            this.tvDonVi.TabIndex = 34;
            this.tvDonVi.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDonVi_AfterSelect);
            this.tvDonVi.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDonVi_NodeMouseDoubleClick);
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.cmdPrint);
            this.pnBottom.Controls.Add(this.cmdClose);
            this.pnBottom.Controls.Add(this.label3);
            this.pnBottom.Controls.Add(this.btnXuatExcelDinhMucDauTu);
            this.pnBottom.Controls.Add(this.ComboVuTrong);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(3, 609);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(1250, 45);
            this.pnBottom.TabIndex = 79;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPrint.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrint.Icon = ((System.Drawing.Icon)(resources.GetObject("cmdPrint.Icon")));
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.Location = new System.Drawing.Point(809, 6);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(112, 32);
            this.cmdPrint.TabIndex = 81;
            this.cmdPrint.Text = "In";
            this.cmdPrint.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
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
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 78;
            this.label3.Text = "Chọn niên vụ:";
            // 
            // btnXuatExcelDinhMucDauTu
            // 
            this.btnXuatExcelDinhMucDauTu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXuatExcelDinhMucDauTu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcelDinhMucDauTu.Icon = ((System.Drawing.Icon)(resources.GetObject("btnXuatExcelDinhMucDauTu.Icon")));
            this.btnXuatExcelDinhMucDauTu.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcelDinhMucDauTu.Image")));
            this.btnXuatExcelDinhMucDauTu.Location = new System.Drawing.Point(495, 6);
            this.btnXuatExcelDinhMucDauTu.Name = "btnXuatExcelDinhMucDauTu";
            this.btnXuatExcelDinhMucDauTu.Size = new System.Drawing.Size(112, 32);
            this.btnXuatExcelDinhMucDauTu.TabIndex = 77;
            this.btnXuatExcelDinhMucDauTu.Text = "Xuất Excel";
            this.btnXuatExcelDinhMucDauTu.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.btnXuatExcelDinhMucDauTu.Click += new System.EventHandler(this.btnXuatExcelDinhMucDauTu_Click);
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
            this.ComboVuTrong.Size = new System.Drawing.Size(137, 25);
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
            this.lblTitle.Text = "DỮ LIỆU ĐỊNH MỨC ĐẦU TƯ SLS";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabDinhMucDT
            // 
            this.tabDinhMucDT.Controls.Add(this.tabBieuLienKet);
            this.tabDinhMucDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDinhMucDT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDinhMucDT.Location = new System.Drawing.Point(0, 0);
            this.tabDinhMucDT.Name = "tabDinhMucDT";
            this.tabDinhMucDT.SelectedIndex = 0;
            this.tabDinhMucDT.Size = new System.Drawing.Size(1268, 693);
            this.tabDinhMucDT.TabIndex = 0;
            // 
            // frm_ShowDinhMucDauTu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1268, 693);
            this.Controls.Add(this.tabDinhMucDT);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_ShowDinhMucDauTu";
            this.ShowIcon = false;
            this.Text = "Xem định mức đầu tư";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_ShowDinhMucDauTu_Load);
            this.tabBieuLienKet.ResumeLayout(false);
            this.pnDuLieu.ResumeLayout(false);
            this.grDL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdDinhMucDauTu)).EndInit();
            this.pnBottom.ResumeLayout(false);
            this.pnBottom.PerformLayout();
            this.pnTop.ResumeLayout(false);
            this.tabDinhMucDT.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TabPage tabBieuLienKet;
        private System.Windows.Forms.Panel pnDuLieu;
        private Janus.Windows.GridEX.GridEX gdDinhMucDauTu;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.TabControl tabDinhMucDT;
        private System.Windows.Forms.GroupBox grDL;
        private System.Windows.Forms.Panel pnBottom;
        private Janus.Windows.EditControls.UIButton cmdClose;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.EditControls.UIButton btnXuatExcelDinhMucDauTu;
        private Janus.Windows.EditControls.UIComboBox ComboVuTrong;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TreeView tvDonVi;
        private Janus.Windows.EditControls.UIButton cmdPrint;
    }
}