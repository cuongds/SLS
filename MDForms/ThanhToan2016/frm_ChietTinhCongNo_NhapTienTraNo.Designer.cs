namespace MDSolution.MDForms.ThanhToan2016
{
    partial class frm_ChietTinhCongNo_NhapTienTraNo
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
            Janus.Windows.GridEX.GridEXLayout grvTienDauTu_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChietTinhCongNo_NhapTienTraNo));
            this.label4 = new System.Windows.Forms.Label();
            this.officeFormAdorner1 = new Janus.Windows.Ribbon.OfficeFormAdorner(this.components);
            this.btnOK = new Janus.Windows.EditControls.UIButton();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.txtHDDT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTienNhap = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHoChiTiet = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTienCanTra = new System.Windows.Forms.TextBox();
            this.grvTienDauTu = new Janus.Windows.GridEX.GridEX();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhieuThu = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtNgayTra = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTienDauTu)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(21, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 173;
            this.label4.Text = "Hợp đồng đầu tư:";
            // 
            // officeFormAdorner1
            // 
            this.officeFormAdorner1.Form = this;
            this.officeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(254, 414);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 21);
            this.btnOK.TabIndex = 175;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.ToolTipText = "Chi tiết lịch sử thanh toán cho khoản đầu tư được chọn";
            this.btnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(119, 414);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 21);
            this.btnCancel.TabIndex = 174;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.ToolTipText = "Chi tiết lịch sử thanh toán cho khoản đầu tư được chọn";
            this.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtHDDT
            // 
            this.txtHDDT.BackColor = System.Drawing.Color.Silver;
            this.txtHDDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHDDT.Location = new System.Drawing.Point(136, 232);
            this.txtHDDT.Name = "txtHDDT";
            this.txtHDDT.ReadOnly = true;
            this.txtHDDT.Size = new System.Drawing.Size(199, 20);
            this.txtHDDT.TabIndex = 176;
            this.txtHDDT.Text = "0";
            this.txtHDDT.TextChanged += new System.EventHandler(this.txtHDDT_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(21, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 173;
            this.label3.Text = "Số tiền trả:";
            // 
            // txtTienNhap
            // 
            this.txtTienNhap.BackColor = System.Drawing.Color.White;
            this.txtTienNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTienNhap.Location = new System.Drawing.Point(136, 312);
            this.txtTienNhap.Name = "txtTienNhap";
            this.txtTienNhap.Size = new System.Drawing.Size(199, 20);
            this.txtTienNhap.TabIndex = 176;
            this.txtTienNhap.Text = "0";
            this.txtTienNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTienNhap.TextChanged += new System.EventHandler(this.txtTienTru_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(21, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 173;
            this.label5.Text = "Hộ chi tiết:";
            // 
            // txtHoChiTiet
            // 
            this.txtHoChiTiet.BackColor = System.Drawing.Color.Silver;
            this.txtHoChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoChiTiet.Location = new System.Drawing.Point(136, 258);
            this.txtHoChiTiet.Name = "txtHoChiTiet";
            this.txtHoChiTiet.ReadOnly = true;
            this.txtHoChiTiet.Size = new System.Drawing.Size(199, 20);
            this.txtHoChiTiet.TabIndex = 176;
            this.txtHoChiTiet.Text = "0";
            this.txtHoChiTiet.TextChanged += new System.EventHandler(this.txtHoChiTiet_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(21, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 173;
            this.label6.Text = "Tiền cần phải trả:";
            // 
            // txtTienCanTra
            // 
            this.txtTienCanTra.BackColor = System.Drawing.Color.Silver;
            this.txtTienCanTra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTienCanTra.Location = new System.Drawing.Point(136, 284);
            this.txtTienCanTra.Name = "txtTienCanTra";
            this.txtTienCanTra.ReadOnly = true;
            this.txtTienCanTra.Size = new System.Drawing.Size(199, 20);
            this.txtTienCanTra.TabIndex = 176;
            this.txtTienCanTra.Text = "0";
            this.txtTienCanTra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTienCanTra.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // grvTienDauTu
            // 
            this.grvTienDauTu.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grvTienDauTu.AlternatingColors = true;
            this.grvTienDauTu.AutomaticSort = false;
            this.grvTienDauTu.ColumnAutoResize = true;
            this.grvTienDauTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvTienDauTu.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.grvTienDauTu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grvTienDauTu.FrozenColumns = 4;
            this.grvTienDauTu.GridLineColor = System.Drawing.Color.Black;
            this.grvTienDauTu.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grvTienDauTu.GroupByBoxVisible = false;
            grvTienDauTu_Layout_0.IsCurrentLayout = true;
            grvTienDauTu_Layout_0.Key = "tbl_DauTu";
            grvTienDauTu_Layout_0.LayoutString = resources.GetString("grvTienDauTu_Layout_0.LayoutString");
            this.grvTienDauTu.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            grvTienDauTu_Layout_0});
            this.grvTienDauTu.Location = new System.Drawing.Point(3, 16);
            this.grvTienDauTu.Name = "grvTienDauTu";
            this.grvTienDauTu.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.grvTienDauTu.RowFormatStyle.BackColorGradient = System.Drawing.Color.White;
            this.grvTienDauTu.ScrollBarWidth = 17;
            this.grvTienDauTu.SelectedFormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.grvTienDauTu.Size = new System.Drawing.Size(1010, 207);
            this.grvTienDauTu.TabIndex = 177;
            this.grvTienDauTu.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grvTienDauTu.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grvTienDauTu.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(21, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 173;
            this.label1.Text = "Phiếu thu:";
            // 
            // txtPhieuThu
            // 
            this.txtPhieuThu.BackColor = System.Drawing.Color.White;
            this.txtPhieuThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhieuThu.Location = new System.Drawing.Point(136, 338);
            this.txtPhieuThu.Name = "txtPhieuThu";
            this.txtPhieuThu.Size = new System.Drawing.Size(199, 20);
            this.txtPhieuThu.TabIndex = 176;
            this.txtPhieuThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPhieuThu.TextChanged += new System.EventHandler(this.txtTienTru_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grvTienDauTu);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 226);
            this.groupBox1.TabIndex = 178;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách đầu tư";
            // 
            // dtNgayTra
            // 
            this.dtNgayTra.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.dtNgayTra.CustomFormat = "dd/MM/yyyy";
            this.dtNgayTra.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtNgayTra.DropDownCalendar.FirstMonth = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtNgayTra.DropDownCalendar.Name = "";
            this.dtNgayTra.DropDownCalendar.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtNgayTra.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.dtNgayTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayTra.ForeColor = System.Drawing.Color.Black;
            this.dtNgayTra.Location = new System.Drawing.Point(136, 364);
            this.dtNgayTra.MinDate = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtNgayTra.Name = "dtNgayTra";
            this.dtNgayTra.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtNgayTra.Size = new System.Drawing.Size(199, 21);
            this.dtNgayTra.TabIndex = 179;
            this.dtNgayTra.Value = new System.DateTime(2017, 11, 27, 0, 0, 0, 0);
            this.dtNgayTra.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.dtNgayTra.ValueChanged += new System.EventHandler(this.dtNgayTra_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(24, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 173;
            this.label2.Text = "Ngày trả:";
            // 
            // frm_ChietTinhCongNo_NhapTienTraNo
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 458);
            this.Controls.Add(this.dtNgayTra);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPhieuThu);
            this.Controls.Add(this.txtTienNhap);
            this.Controls.Add(this.txtTienCanTra);
            this.Controls.Add(this.txtHoChiTiet);
            this.Controls.Add(this.txtHDDT);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "frm_ChietTinhCongNo_NhapTienTraNo";
            this.Text = "Nhập tiền trả nợ";
            this.Load += new System.EventHandler(this.frm_ChietTinhCongNo_NhapTienTraNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTienDauTu)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private Janus.Windows.Ribbon.OfficeFormAdorner officeFormAdorner1;
        private Janus.Windows.EditControls.UIButton btnOK;
        private Janus.Windows.EditControls.UIButton btnCancel;
        public System.Windows.Forms.TextBox txtTienNhap;
        public System.Windows.Forms.TextBox txtHDDT;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtTienCanTra;
        public System.Windows.Forms.TextBox txtHoChiTiet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public Janus.Windows.GridEX.GridEX grvTienDauTu;
        public System.Windows.Forms.TextBox txtPhieuThu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        public Janus.Windows.CalendarCombo.CalendarCombo dtNgayTra;
    }
}