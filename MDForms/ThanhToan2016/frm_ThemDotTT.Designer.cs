namespace MDSolution.MDForms.ThanhToan2016
{
    partial class frm_ThemDotTT
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
            Janus.Windows.GridEX.GridEXLayout grvDotTT_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ThemDotTT));
            this.grvDotTT = new Janus.Windows.GridEX.GridEX();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.dtNgayChot = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.dtNgayBatDau = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grvDotTT)).BeginInit();
            this.SuspendLayout();
            // 
            // grvDotTT
            // 
            this.grvDotTT.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grvDotTT.AlternatingColors = true;
            this.grvDotTT.AutomaticSort = false;
            this.grvDotTT.ColumnAutoResize = true;
            this.grvDotTT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grvDotTT.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.grvDotTT.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grvDotTT.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.grvDotTT.Font = new System.Drawing.Font("Arial", 9F);
            this.grvDotTT.FrozenColumns = 4;
            this.grvDotTT.GridLineColor = System.Drawing.Color.Black;
            this.grvDotTT.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grvDotTT.GroupByBoxVisible = false;
            this.grvDotTT.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            grvDotTT_Layout_0.IsCurrentLayout = true;
            grvDotTT_Layout_0.Key = "tbl_DauTu";
            grvDotTT_Layout_0.LayoutString = resources.GetString("grvDotTT_Layout_0.LayoutString");
            this.grvDotTT.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            grvDotTT_Layout_0});
            this.grvDotTT.Location = new System.Drawing.Point(0, 225);
            this.grvDotTT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grvDotTT.Name = "grvDotTT";
            this.grvDotTT.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grvDotTT.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.grvDotTT.RowFormatStyle.BackColorGradient = System.Drawing.Color.White;
            this.grvDotTT.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.grvDotTT.ScrollBarWidth = 17;
            this.grvDotTT.SelectedFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.grvDotTT.Size = new System.Drawing.Size(854, 368);
            this.grvDotTT.TabIndex = 181;
            this.grvDotTT.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grvDotTT.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grvDotTT.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grvDotTT_ColumnButtonClick);
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(114, 15);
            this.txtTen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(697, 22);
            this.txtTen.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(13, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 182;
            this.label4.Text = "Tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(10, 139);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 182;
            this.label1.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(114, 136);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(697, 22);
            this.txtGhiChu.TabIndex = 2;
            // 
            // dtNgayChot
            // 
            this.dtNgayChot.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.dtNgayChot.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtNgayChot.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtNgayChot.DropDownCalendar.FirstMonth = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtNgayChot.DropDownCalendar.Name = "";
            this.dtNgayChot.DropDownCalendar.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtNgayChot.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Standard;
            this.dtNgayChot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayChot.ForeColor = System.Drawing.Color.Black;
            this.dtNgayChot.IsNullDate = true;
            this.dtNgayChot.Location = new System.Drawing.Point(114, 98);
            this.dtNgayChot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtNgayChot.MinDate = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtNgayChot.Name = "dtNgayChot";
            this.dtNgayChot.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtNgayChot.Size = new System.Drawing.Size(353, 25);
            this.dtNgayChot.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(13, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 185;
            this.label3.Text = "Ngày chốt";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(6, 186);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 28);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dtNgayBatDau
            // 
            this.dtNgayBatDau.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.dtNgayBatDau.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtNgayBatDau.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtNgayBatDau.DropDownCalendar.FirstMonth = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtNgayBatDau.DropDownCalendar.Name = "";
            this.dtNgayBatDau.DropDownCalendar.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtNgayBatDau.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Standard;
            this.dtNgayBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayBatDau.ForeColor = System.Drawing.Color.Black;
            this.dtNgayBatDau.IsNullDate = true;
            this.dtNgayBatDau.Location = new System.Drawing.Point(114, 53);
            this.dtNgayBatDau.Margin = new System.Windows.Forms.Padding(4);
            this.dtNgayBatDau.MinDate = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtNgayBatDau.Name = "dtNgayBatDau";
            this.dtNgayBatDau.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtNgayBatDau.Size = new System.Drawing.Size(353, 25);
            this.dtNgayBatDau.TabIndex = 186;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 187;
            this.label2.Text = "Ngày bắt đầu";
            // 
            // frm_ThemDotTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 593);
            this.Controls.Add(this.dtNgayBatDau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dtNgayChot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grvDotTT);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_ThemDotTT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm đợt thanh toán";
            this.Load += new System.EventHandler(this.frm_ThemDotTT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvDotTT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.GridEX.GridEX grvDotTT;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGhiChu;
        private Janus.Windows.CalendarCombo.CalendarCombo dtNgayChot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThem;
        private Janus.Windows.CalendarCombo.CalendarCombo dtNgayBatDau;
        private System.Windows.Forms.Label label2;
    }
}