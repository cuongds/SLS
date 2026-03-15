namespace MDSolution.MDForms.ThuHoach
{
    partial class frm_LapKeHoach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_LapKeHoach));
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnCenter = new System.Windows.Forms.Panel();
            this.grThongTinPhieu = new Janus.Windows.EditControls.UIGroupBox();
            this.chkKhongChe = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.dtNgayKeHoach = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label5 = new System.Windows.Forms.Label();
            this.pnMother = new System.Windows.Forms.Panel();
            this.pnTop = new System.Windows.Forms.Panel();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.cmdLuu = new Janus.Windows.EditControls.UIButton();
            this.cmdClose = new Janus.Windows.EditControls.UIButton();
            this.dtTuNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.dtDenNgay = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.pnCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grThongTinPhieu)).BeginInit();
            this.grThongTinPhieu.SuspendLayout();
            this.pnMother.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.pnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(440, 32);
            this.lblTitle.TabIndex = 55;
            this.lblTitle.Text = "LẬP KẾ HOẠCH SẢN LƯỢNG NGÀY";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnCenter
            // 
            this.pnCenter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnCenter.Controls.Add(this.grThongTinPhieu);
            this.pnCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCenter.Location = new System.Drawing.Point(0, 0);
            this.pnCenter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnCenter.Name = "pnCenter";
            this.pnCenter.Size = new System.Drawing.Size(440, 217);
            this.pnCenter.TabIndex = 56;
            // 
            // grThongTinPhieu
            // 
            this.grThongTinPhieu.Controls.Add(this.dtDenNgay);
            this.grThongTinPhieu.Controls.Add(this.dtTuNgay);
            this.grThongTinPhieu.Controls.Add(this.chkKhongChe);
            this.grThongTinPhieu.Controls.Add(this.label2);
            this.grThongTinPhieu.Controls.Add(this.label22);
            this.grThongTinPhieu.Controls.Add(this.label21);
            this.grThongTinPhieu.Controls.Add(this.dtNgayKeHoach);
            this.grThongTinPhieu.Controls.Add(this.label5);
            this.grThongTinPhieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grThongTinPhieu.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grThongTinPhieu.ForeColor = System.Drawing.Color.Maroon;
            this.grThongTinPhieu.Location = new System.Drawing.Point(0, 0);
            this.grThongTinPhieu.Name = "grThongTinPhieu";
            this.grThongTinPhieu.Size = new System.Drawing.Size(436, 213);
            this.grThongTinPhieu.TabIndex = 9;
            this.grThongTinPhieu.Text = "Thông tin kế hoạch";
            this.grThongTinPhieu.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.VS2005;
            // 
            // chkKhongChe
            // 
            this.chkKhongChe.AutoSize = true;
            this.chkKhongChe.Checked = true;
            this.chkKhongChe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKhongChe.ForeColor = System.Drawing.Color.Red;
            this.chkKhongChe.Location = new System.Drawing.Point(144, 177);
            this.chkKhongChe.Name = "chkKhongChe";
            this.chkKhongChe.Size = new System.Drawing.Size(191, 22);
            this.chkKhongChe.TabIndex = 35;
            this.chkKhongChe.Text = "Khống chế lượng nhập";
            this.chkKhongChe.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(107, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 31;
            this.label2.Text = "đến:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(1077, 98);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(28, 18);
            this.label22.TabIndex = 26;
            this.label22.Text = "Kg";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(69, 93);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 15);
            this.label21.TabIndex = 24;
            this.label21.Text = "Áp dụng từ:";
            // 
            // dtNgayKeHoach
            // 
            this.dtNgayKeHoach.CustomFormat = "dd/MM/yyyy";
            this.dtNgayKeHoach.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtNgayKeHoach.DropDownCalendar.ForeColor = System.Drawing.Color.Black;
            this.dtNgayKeHoach.DropDownCalendar.Name = "";
            this.dtNgayKeHoach.DropDownCalendar.Visible = false;
            this.dtNgayKeHoach.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            this.dtNgayKeHoach.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayKeHoach.ForeColor = System.Drawing.Color.DarkBlue;
            this.dtNgayKeHoach.Location = new System.Drawing.Point(142, 35);
            this.dtNgayKeHoach.Name = "dtNgayKeHoach";
            this.dtNgayKeHoach.Size = new System.Drawing.Size(229, 35);
            this.dtNgayKeHoach.TabIndex = 12;
            this.dtNgayKeHoach.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            this.dtNgayKeHoach.ValueChanged += new System.EventHandler(this.dtNgayKeHoach_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(47, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ngày kế hoạch:";
            // 
            // pnMother
            // 
            this.pnMother.Controls.Add(this.pnCenter);
            this.pnMother.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMother.Location = new System.Drawing.Point(0, 32);
            this.pnMother.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnMother.Name = "pnMother";
            this.pnMother.Size = new System.Drawing.Size(440, 217);
            this.pnMother.TabIndex = 58;
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lblTitle);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(440, 32);
            this.pnTop.TabIndex = 3068;
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.cmdLuu);
            this.pnBottom.Controls.Add(this.cmdClose);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 249);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(440, 41);
            this.pnBottom.TabIndex = 3068;
            // 
            // cmdLuu
            // 
            this.cmdLuu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdLuu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLuu.Image = global::MDSolution.Properties.Resources.save16;
            this.cmdLuu.Location = new System.Drawing.Point(19, 7);
            this.cmdLuu.Name = "cmdLuu";
            this.cmdLuu.Size = new System.Drawing.Size(75, 26);
            this.cmdLuu.TabIndex = 22;
            this.cmdLuu.Text = "Lưu";
            this.cmdLuu.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdLuu.Click += new System.EventHandler(this.cmdLuu_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.Location = new System.Drawing.Point(348, 7);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 26);
            this.cmdClose.TabIndex = 23;
            this.cmdClose.Text = "Đóng";
            this.cmdClose.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtTuNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtTuNgay.DropDownCalendar.ForeColor = System.Drawing.Color.Black;
            this.dtTuNgay.DropDownCalendar.Name = "";
            this.dtTuNgay.DropDownCalendar.Visible = false;
            this.dtTuNgay.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            this.dtTuNgay.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTuNgay.ForeColor = System.Drawing.Color.Black;
            this.dtTuNgay.Location = new System.Drawing.Point(142, 88);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Size = new System.Drawing.Size(229, 25);
            this.dtTuNgay.TabIndex = 15;
            this.dtTuNgay.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            this.dtTuNgay.ValueChanged += new System.EventHandler(this.dtTuNgay_ValueChanged);
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtDenNgay.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtDenNgay.DropDownCalendar.ForeColor = System.Drawing.Color.Black;
            this.dtDenNgay.DropDownCalendar.Name = "";
            this.dtDenNgay.DropDownCalendar.Visible = false;
            this.dtDenNgay.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            this.dtDenNgay.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDenNgay.ForeColor = System.Drawing.Color.Black;
            this.dtDenNgay.Location = new System.Drawing.Point(142, 131);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.ReadOnly = true;
            this.dtDenNgay.Size = new System.Drawing.Size(229, 25);
            this.dtDenNgay.TabIndex = 16;
            this.dtDenNgay.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            // 
            // frm_LapKeHoach
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(440, 290);
            this.Controls.Add(this.pnMother);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.pnTop);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_LapKeHoach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kế hoạch sản lượng";
            this.Load += new System.EventHandler(this.frm_LapKeHoach_Load);
            this.pnCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grThongTinPhieu)).EndInit();
            this.grThongTinPhieu.ResumeLayout(false);
            this.grThongTinPhieu.PerformLayout();
            this.pnMother.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.pnBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnCenter;
        private System.Windows.Forms.Panel pnMother;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel pnBottom;
        private Janus.Windows.EditControls.UIButton cmdLuu;
        private Janus.Windows.EditControls.UIButton cmdClose;
        private Janus.Windows.EditControls.UIGroupBox grThongTinPhieu;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private Janus.Windows.CalendarCombo.CalendarCombo dtNgayKeHoach;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkKhongChe;
        private Janus.Windows.CalendarCombo.CalendarCombo dtDenNgay;
        private Janus.Windows.CalendarCombo.CalendarCombo dtTuNgay;
    }
}