namespace MDSolution.MDForms
{
    partial class frmHoTroTheoLoaiHinh
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
            Janus.Windows.GridEX.GridEXLayout gdVHopDong_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoTroTheoLoaiHinh));
            Janus.Windows.GridEX.GridEXLayout gdVLoaiHinh_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            this.lblDonViTinh = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.gdVHopDong = new Janus.Windows.GridEX.GridEX();
            this.dtpNgayLam = new System.Windows.Forms.DateTimePicker();
            this.cbnNhap = new System.Windows.Forms.Button();
            this.cbXa = new System.Windows.Forms.ComboBox();
            this.cbThon = new System.Windows.Forms.ComboBox();
            this.cbbHoTro = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.chkTimkiemchinhxac = new System.Windows.Forms.CheckBox();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gdVLoaiHinh = new Janus.Windows.GridEX.GridEX();
            this.lblLoaiHinhHoTro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gdVHopDong)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdVLoaiHinh)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDonViTinh.AutoSize = true;
            this.lblDonViTinh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonViTinh.Location = new System.Drawing.Point(587, 0);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(59, 31);
            this.lblDonViTinh.TabIndex = 22;
            this.lblDonViTinh.Text = "đồng/m2";
            this.lblDonViTinh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTien.Location = new System.Drawing.Point(460, 4);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(116, 22);
            this.txtSoTien.TabIndex = 21;
            this.txtSoTien.TextChanged += new System.EventHandler(this.txtSoTien_TextChanged);
            this.txtSoTien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoTien_KeyPress);
            // 
            // gdVHopDong
            // 
            this.gdVHopDong.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdVHopDong.AlternatingColors = true;
            this.gdVHopDong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdVHopDong.AutomaticSort = false;
            this.gdVHopDong.ColumnAutoResize = true;
            this.gdVHopDong.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdVHopDong.Font = new System.Drawing.Font("Arial", 9F);
            this.gdVHopDong.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVHopDong.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVHopDong.GroupByBoxVisible = false;
            this.gdVHopDong.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            gdVHopDong_Layout_0.IsCurrentLayout = true;
            gdVHopDong_Layout_0.Key = "tbl_DauTu";
            gdVHopDong_Layout_0.LayoutString = resources.GetString("gdVHopDong_Layout_0.LayoutString");
            this.gdVHopDong.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdVHopDong_Layout_0});
            this.gdVHopDong.Location = new System.Drawing.Point(3, 46);
            this.gdVHopDong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdVHopDong.Name = "gdVHopDong";
            this.gdVHopDong.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdVHopDong.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVHopDong.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdVHopDong.ScrollBarWidth = 17;
            this.gdVHopDong.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gdVHopDong.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVHopDong.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVHopDong.ShowErrors = false;
            this.gdVHopDong.Size = new System.Drawing.Size(880, 107);
            this.gdVHopDong.TabIndex = 20;
            this.gdVHopDong.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVHopDong.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            // 
            // dtpNgayLam
            // 
            this.dtpNgayLam.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayLam.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayLam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLam.Location = new System.Drawing.Point(345, 4);
            this.dtpNgayLam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgayLam.Name = "dtpNgayLam";
            this.dtpNgayLam.Size = new System.Drawing.Size(102, 22);
            this.dtpNgayLam.TabIndex = 24;
            this.dtpNgayLam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpNgayLam_KeyPress);
            // 
            // cbnNhap
            // 
            this.cbnNhap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbnNhap.Location = new System.Drawing.Point(662, 4);
            this.cbnNhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbnNhap.Name = "cbnNhap";
            this.cbnNhap.Size = new System.Drawing.Size(85, 23);
            this.cbnNhap.TabIndex = 23;
            this.cbnNhap.Text = "Áp dụng";
            this.cbnNhap.UseVisualStyleBackColor = true;
            this.cbnNhap.Click += new System.EventHandler(this.cbnNhap_Click);
            // 
            // cbXa
            // 
            this.cbXa.DisplayMember = "Ten";
            this.cbXa.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbXa.FormattingEnabled = true;
            this.cbXa.Location = new System.Drawing.Point(102, 4);
            this.cbXa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbXa.Name = "cbXa";
            this.cbXa.Size = new System.Drawing.Size(77, 24);
            this.cbXa.TabIndex = 17;
            this.cbXa.ValueMember = "ID";
            this.cbXa.SelectedIndexChanged += new System.EventHandler(this.cbXa_SelectedIndexChanged);
            this.cbXa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbXa_KeyPress);
            // 
            // cbThon
            // 
            this.cbThon.DisplayMember = "Ten";
            this.cbThon.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThon.FormattingEnabled = true;
            this.cbThon.Location = new System.Drawing.Point(185, 4);
            this.cbThon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbThon.Name = "cbThon";
            this.cbThon.Size = new System.Drawing.Size(130, 24);
            this.cbThon.TabIndex = 19;
            this.cbThon.ValueMember = "ID";
            this.cbThon.SelectedIndexChanged += new System.EventHandler(this.cbThon_SelectedIndexChanged);
            this.cbThon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbThon_KeyPress);
            // 
            // cbbHoTro
            // 
            this.cbbHoTro.DisplayMember = "Ten";
            this.cbbHoTro.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbHoTro.FormattingEnabled = true;
            this.cbbHoTro.Location = new System.Drawing.Point(3, 4);
            this.cbbHoTro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbHoTro.Name = "cbbHoTro";
            this.cbbHoTro.Size = new System.Drawing.Size(93, 24);
            this.cbbHoTro.TabIndex = 18;
            this.cbbHoTro.ValueMember = "ID";
            this.cbbHoTro.SelectedIndexChanged += new System.EventHandler(this.cbbHoTro_SelectedIndexChanged);
            this.cbbHoTro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbHoTro_KeyPress);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.gdVHopDong, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gdVLoaiHinh, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblLoaiHinhHoTro, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 206F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(886, 457);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 274F));
            this.tableLayoutPanel3.Controls.Add(this.txtTimKiem, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkTimkiemchinhxac, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnTimkiem, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 160);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(591, 45);
            this.tableLayoutPanel3.TabIndex = 28;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(3, 4);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(143, 22);
            this.txtTimKiem.TabIndex = 21;
            this.txtTimKiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimKiem_KeyPress);
            // 
            // chkTimkiemchinhxac
            // 
            this.chkTimkiemchinhxac.AutoSize = true;
            this.chkTimkiemchinhxac.Checked = true;
            this.chkTimkiemchinhxac.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTimkiemchinhxac.Location = new System.Drawing.Point(152, 3);
            this.chkTimkiemchinhxac.Name = "chkTimkiemchinhxac";
            this.chkTimkiemchinhxac.Size = new System.Drawing.Size(140, 20);
            this.chkTimkiemchinhxac.TabIndex = 24;
            this.chkTimkiemchinhxac.Text = "Tìm kiếm chính xác";
            this.chkTimkiemchinhxac.UseVisualStyleBackColor = true;
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimkiem.Location = new System.Drawing.Point(320, 4);
            this.btnTimkiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(117, 22);
            this.btnTimkiem.TabIndex = 23;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.20876F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.79124F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel2.Controls.Add(this.cbnNhap, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbbHoTro, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbXa, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblDonViTinh, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtSoTien, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpNgayLam, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbThon, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(771, 31);
            this.tableLayoutPanel2.TabIndex = 26;
            // 
            // gdVLoaiHinh
            // 
            this.gdVLoaiHinh.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVLoaiHinh.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdVLoaiHinh.AlternatingColors = true;
            this.gdVLoaiHinh.AutoEdit = true;
            this.gdVLoaiHinh.AutomaticSort = false;
            this.gdVLoaiHinh.ColumnAutoResize = true;
            this.gdVLoaiHinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdVLoaiHinh.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdVLoaiHinh.Font = new System.Drawing.Font("Arial", 9F);
            this.gdVLoaiHinh.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVLoaiHinh.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVLoaiHinh.GroupByBoxVisible = false;
            this.gdVLoaiHinh.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            gdVLoaiHinh_Layout_0.IsCurrentLayout = true;
            gdVLoaiHinh_Layout_0.Key = "tbl_DauTu";
            gdVLoaiHinh_Layout_0.LayoutString = resources.GetString("gdVLoaiHinh_Layout_0.LayoutString");
            this.gdVLoaiHinh.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdVLoaiHinh_Layout_0});
            this.gdVLoaiHinh.Location = new System.Drawing.Point(3, 234);
            this.gdVLoaiHinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdVLoaiHinh.Name = "gdVLoaiHinh";
            this.gdVLoaiHinh.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVLoaiHinh.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdVLoaiHinh.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVLoaiHinh.ScrollBarWidth = 17;
            this.gdVLoaiHinh.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gdVLoaiHinh.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVLoaiHinh.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVLoaiHinh.Size = new System.Drawing.Size(880, 198);
            this.gdVLoaiHinh.TabIndex = 25;
            this.gdVLoaiHinh.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.gdVLoaiHinh_DeletingRecord);
            this.gdVLoaiHinh.RecordsDeleted += new System.EventHandler(this.gdVLoaiHinh_RecordsDeleted);
            this.gdVLoaiHinh.RecordUpdated += new System.EventHandler(this.gdVLoaiHinh_RecordUpdated);
            this.gdVLoaiHinh.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gdVLoaiHinh_UpdatingRecord);
            this.gdVLoaiHinh.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdVLoaiHinh_ColumnButtonClick);
            // 
            // lblLoaiHinhHoTro
            // 
            this.lblLoaiHinhHoTro.AutoSize = true;
            this.lblLoaiHinhHoTro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLoaiHinhHoTro.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiHinhHoTro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLoaiHinhHoTro.Location = new System.Drawing.Point(3, 214);
            this.lblLoaiHinhHoTro.Name = "lblLoaiHinhHoTro";
            this.lblLoaiHinhHoTro.Size = new System.Drawing.Size(880, 16);
            this.lblLoaiHinhHoTro.TabIndex = 27;
            this.lblLoaiHinhHoTro.Text = "Loại hỗ trợ";
            // 
            // frmHoTroTheoLoaiHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(804, 469);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHoTroTheoLoaiHinh";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập tiền hỗ trợ";
            ((System.ComponentModel.ISupportInitialize)(this.gdVHopDong)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdVLoaiHinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDonViTinh;
        private System.Windows.Forms.TextBox txtSoTien;
        internal Janus.Windows.GridEX.GridEX gdVHopDong;
        private System.Windows.Forms.DateTimePicker dtpNgayLam;
        private System.Windows.Forms.Button cbnNhap;
        private System.Windows.Forms.ComboBox cbXa;
        private System.Windows.Forms.ComboBox cbThon;
        private System.Windows.Forms.ComboBox cbbHoTro;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblLoaiHinhHoTro;
        private Janus.Windows.GridEX.GridEX gdVLoaiHinh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.CheckBox chkTimkiemchinhxac;
    }
}