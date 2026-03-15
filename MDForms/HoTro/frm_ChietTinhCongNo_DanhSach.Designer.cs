namespace MDSolution.MDForms.HoTro
{
    partial class frm_ChietTinhCongNo_DanhSach
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
            Janus.Windows.GridEX.GridEXLayout grvChietTinhCongNo_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChietTinhCongNo_DanhSach));
            Janus.Windows.GridEX.GridEXLayout grvNhapMia_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grvChietTinhCongNo = new Janus.Windows.GridEX.GridEX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.grvNhapMia = new Janus.Windows.GridEX.GridEX();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.btnInChietTinhCN = new Janus.Windows.EditControls.UIButton();
            this.btnOK = new Janus.Windows.EditControls.UIButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvChietTinhCongNo)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvNhapMia)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.Panel;
            this.uiGroupBox1.Controls.Add(this.splitContainer1);
            this.uiGroupBox1.Controls.Add(this.panel1);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(1316, 663);
            this.uiGroupBox1.TabIndex = 64;
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            this.uiGroupBox1.Click += new System.EventHandler(this.uiGroupBox1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 95);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grvChietTinhCongNo);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grvNhapMia);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(1309, 565);
            this.splitContainer1.SplitterDistance = 508;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 69;
            // 
            // grvChietTinhCongNo
            // 
            this.grvChietTinhCongNo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grvChietTinhCongNo.AlternatingColors = true;
            this.grvChietTinhCongNo.AutomaticSort = false;
            this.grvChietTinhCongNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvChietTinhCongNo.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.grvChietTinhCongNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grvChietTinhCongNo.FrozenColumns = 4;
            this.grvChietTinhCongNo.GridLineColor = System.Drawing.Color.Black;
            this.grvChietTinhCongNo.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grvChietTinhCongNo.GroupByBoxVisible = false;
            grvChietTinhCongNo_Layout_0.IsCurrentLayout = true;
            grvChietTinhCongNo_Layout_0.Key = "tbl_DauTu";
            grvChietTinhCongNo_Layout_0.LayoutString = resources.GetString("grvChietTinhCongNo_Layout_0.LayoutString");
            this.grvChietTinhCongNo.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            grvChietTinhCongNo_Layout_0});
            this.grvChietTinhCongNo.Location = new System.Drawing.Point(0, 41);
            this.grvChietTinhCongNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grvChietTinhCongNo.Name = "grvChietTinhCongNo";
            this.grvChietTinhCongNo.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.grvChietTinhCongNo.RowFormatStyle.BackColorGradient = System.Drawing.Color.White;
            this.grvChietTinhCongNo.ScrollBarWidth = 17;
            this.grvChietTinhCongNo.SelectedFormatStyle.BackColor = System.Drawing.Color.PaleTurquoise;
            this.grvChietTinhCongNo.Size = new System.Drawing.Size(593, 524);
            this.grvChietTinhCongNo.TabIndex = 65;
            this.grvChietTinhCongNo.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grvChietTinhCongNo.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grvChietTinhCongNo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grvChietTinhCongNo.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.grvChietTinhCongNo_RowDoubleClick);
            this.grvChietTinhCongNo.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grvChietTinhCongNo_FormattingRow);
            this.grvChietTinhCongNo.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grvChietTinhCongNo_ColumnButtonClick);
            this.grvChietTinhCongNo.SelectionChanged += new System.EventHandler(this.grvChietTinhCongNo_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(593, 41);
            this.panel2.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(593, 41);
            this.label3.TabIndex = 67;
            this.label3.Text = "Danh sách chiết tính công nợ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // grvNhapMia
            // 
            this.grvNhapMia.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grvNhapMia.AlternatingColors = true;
            this.grvNhapMia.AutomaticSort = false;
            this.grvNhapMia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvNhapMia.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.grvNhapMia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grvNhapMia.FrozenColumns = 4;
            this.grvNhapMia.GridLineColor = System.Drawing.Color.Black;
            this.grvNhapMia.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grvNhapMia.GroupByBoxVisible = false;
            grvNhapMia_Layout_0.IsCurrentLayout = true;
            grvNhapMia_Layout_0.Key = "tbl_DauTu";
            grvNhapMia_Layout_0.LayoutString = resources.GetString("grvNhapMia_Layout_0.LayoutString");
            this.grvNhapMia.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            grvNhapMia_Layout_0});
            this.grvNhapMia.Location = new System.Drawing.Point(0, 41);
            this.grvNhapMia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grvNhapMia.Name = "grvNhapMia";
            this.grvNhapMia.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.grvNhapMia.RowFormatStyle.BackColorGradient = System.Drawing.Color.White;
            this.grvNhapMia.ScrollBarWidth = 17;
            this.grvNhapMia.SelectedFormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.grvNhapMia.Size = new System.Drawing.Size(712, 524);
            this.grvNhapMia.TabIndex = 68;
            this.grvNhapMia.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grvNhapMia.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grvNhapMia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(712, 41);
            this.panel3.TabIndex = 69;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(712, 41);
            this.label4.TabIndex = 68;
            this.label4.Text = "Chi tiết chiết tính công nợ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.dtTuNgay);
            this.panel1.Controls.Add(this.btnInChietTinhCN);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtDenNgay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1309, 85);
            this.panel1.TabIndex = 70;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.dtTuNgay.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtTuNgay.DropDownCalendar.FirstMonth = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtTuNgay.DropDownCalendar.Name = "";
            this.dtTuNgay.DropDownCalendar.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtTuNgay.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.dtTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTuNgay.ForeColor = System.Drawing.Color.Black;
            this.dtTuNgay.IsNullDate = true;
            this.dtTuNgay.Location = new System.Drawing.Point(87, 15);
            this.dtTuNgay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtTuNgay.MinDate = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Nullable = true;
            this.dtTuNgay.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtTuNgay.Size = new System.Drawing.Size(163, 21);
            this.dtTuNgay.TabIndex = 66;
            this.dtTuNgay.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            // 
            // btnInChietTinhCN
            // 
            this.btnInChietTinhCN.Location = new System.Drawing.Point(650, 14);
            this.btnInChietTinhCN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInChietTinhCN.Name = "btnInChietTinhCN";
            this.btnInChietTinhCN.Size = new System.Drawing.Size(170, 26);
            this.btnInChietTinhCN.TabIndex = 2;
            this.btnInChietTinhCN.Text = "In chiết tính công nợ";
            this.btnInChietTinhCN.ToolTipText = "Chi tiết lịch sử thanh toán cho khoản đầu tư được chọn";
            this.btnInChietTinhCN.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnInChietTinhCN.Click += new System.EventHandler(this.btnInChietTinhCN_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(548, 15);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 26);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Tìm kiếm";
            this.btnOK.ToolTipText = "Chi tiết lịch sử thanh toán cho khoản đầu tư được chọn";
            this.btnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(288, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 67;
            this.label2.Text = "Đến ngày:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 67;
            this.label1.Text = "Từ ngày:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtDenNgay.DropDownCalendar.FirstMonth = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtDenNgay.DropDownCalendar.Name = "";
            this.dtDenNgay.DropDownCalendar.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtDenNgay.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.dtDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDenNgay.ForeColor = System.Drawing.Color.Black;
            this.dtDenNgay.IsNullDate = true;
            this.dtDenNgay.Location = new System.Drawing.Point(371, 15);
            this.dtDenNgay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtDenNgay.MinDate = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Nullable = true;
            this.dtDenNgay.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtDenNgay.Size = new System.Drawing.Size(163, 21);
            this.dtDenNgay.TabIndex = 66;
            this.dtDenNgay.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            // 
            // frm_ChietTinhCongNo_DanhSach
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 663);
            this.Controls.Add(this.uiGroupBox1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChietTinhCongNo_DanhSach";
            this.Text = "Tìm kiếm hợp đồng";
            this.Load += new System.EventHandler(this.frm_ChietTinhCongNo_DanhSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvChietTinhCongNo)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvNhapMia)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIButton btnOK;
        private Janus.Windows.EditControls.UIButton btnInChietTinhCN;
        public Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        public Janus.Windows.GridEX.GridEX grvChietTinhCongNo;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.CalendarCombo.CalendarCombo dtTuNgay;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.CalendarCombo.CalendarCombo dtDenNgay;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Janus.Windows.GridEX.GridEX grvNhapMia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}