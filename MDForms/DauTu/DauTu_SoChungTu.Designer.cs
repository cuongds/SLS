namespace MDSolution.MDForms.DauTu
{
    partial class DauTu_SoChungTu
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
            Janus.Windows.GridEX.GridEXLayout gdChiTietDauTu_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DauTu_SoChungTu));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gdChiTietDauTu = new Janus.Windows.GridEX.GridEX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdAddHD = new Janus.Windows.EditControls.UIButton();
            this.btnXuatExcelHopDong = new Janus.Windows.EditControls.UIButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdChiTietDauTu)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gdChiTietDauTu, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1284, 688);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gdChiTietDauTu
            // 
            this.gdChiTietDauTu.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdChiTietDauTu.AlternatingColors = true;
            this.gdChiTietDauTu.AutoEdit = true;
            this.gdChiTietDauTu.AutomaticSort = false;
            this.gdChiTietDauTu.BorderStyle = Janus.Windows.GridEX.BorderStyle.RaisedLight3D;
            this.gdChiTietDauTu.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
    "êu đề vào đây để nhóm theo cộ</GroupByBoxInfo></LocalizableData>";
            gdChiTietDauTu_DesignTimeLayout.LayoutString = resources.GetString("gdChiTietDauTu_DesignTimeLayout.LayoutString");
            this.gdChiTietDauTu.DesignTimeLayout = gdChiTietDauTu_DesignTimeLayout;
            this.gdChiTietDauTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdChiTietDauTu.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdChiTietDauTu.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdChiTietDauTu.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gdChiTietDauTu.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdChiTietDauTu.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdChiTietDauTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdChiTietDauTu.FrozenColumns = 7;
            this.gdChiTietDauTu.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdChiTietDauTu.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdChiTietDauTu.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdChiTietDauTu.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdChiTietDauTu.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdChiTietDauTu.LinkFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdChiTietDauTu.Location = new System.Drawing.Point(3, 103);
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
            this.gdChiTietDauTu.Size = new System.Drawing.Size(1278, 582);
            this.gdChiTietDauTu.TabIndex = 32;
            this.gdChiTietDauTu.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdChiTietDauTu.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdChiTietDauTu.UpdateOnLeave = false;
            this.gdChiTietDauTu.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gdChiTietDauTu_FormattingRow);
            this.gdChiTietDauTu.CellUpdated += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdChiTietDauTu_CellUpdated);
            this.gdChiTietDauTu.UpdatingCell += new Janus.Windows.GridEX.UpdatingCellEventHandler(this.gdChiTietDauTu_UpdatingCell);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdAddHD);
            this.panel1.Controls.Add(this.btnXuatExcelHopDong);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1278, 94);
            this.panel1.TabIndex = 31;
            // 
            // cmdAddHD
            // 
            this.cmdAddHD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAddHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddHD.Icon = ((System.Drawing.Icon)(resources.GetObject("cmdAddHD.Icon")));
            this.cmdAddHD.Image = global::MDSolution.Properties.Resources.Home;
            this.cmdAddHD.Location = new System.Drawing.Point(540, 26);
            this.cmdAddHD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdAddHD.Name = "cmdAddHD";
            this.cmdAddHD.Size = new System.Drawing.Size(168, 46);
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
            this.btnXuatExcelHopDong.Image = global::MDSolution.Properties.Resources.Home;
            this.btnXuatExcelHopDong.Location = new System.Drawing.Point(716, 26);
            this.btnXuatExcelHopDong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnXuatExcelHopDong.Name = "btnXuatExcelHopDong";
            this.btnXuatExcelHopDong.Size = new System.Drawing.Size(160, 46);
            this.btnXuatExcelHopDong.TabIndex = 74;
            this.btnXuatExcelHopDong.Text = "Xuất Excel";
            this.btnXuatExcelHopDong.Click += new System.EventHandler(this.btnXuatExcelHopDong_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtTuNgay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtDenNgay);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 69);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thời gian đầu tư";
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTuNgay.Location = new System.Drawing.Point(42, 28);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Size = new System.Drawing.Size(200, 26);
            this.dtTuNgay.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Đến ";
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenNgay.Location = new System.Drawing.Point(302, 28);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Size = new System.Drawing.Size(200, 26);
            this.dtDenNgay.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Từ ";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.Filter = " Excel files (*.xls)|*.xls";
            // 
            // DauTu_SoChungTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 688);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DauTu_SoChungTu";
            this.Text = "Quản lý chứng từ đầu tư";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdChiTietDauTu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtTuNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDenNgay;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton cmdAddHD;
        private Janus.Windows.EditControls.UIButton btnXuatExcelHopDong;
        private Janus.Windows.GridEX.GridEX gdChiTietDauTu;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}