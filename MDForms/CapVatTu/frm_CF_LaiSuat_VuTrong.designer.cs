namespace MDSolution.MDForms.CapVatTu
{
    partial class frm_CF_LaiSuat_VuTrong
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
            this.lblTram = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.grGiaCuoc = new System.Windows.Forms.GroupBox();
            this.grPhu = new Janus.Windows.EditControls.UIGroupBox();
            this.rdNgayKhac = new System.Windows.Forms.RadioButton();
            this.rdNgayNhanDauTu = new System.Windows.Forms.RadioButton();
            this.dtNgayTinhLai = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.cboVuTrong = new Janus.Windows.EditControls.UIComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nLaiSuat = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.pnGiaCuoc = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grGiaCuoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grPhu)).BeginInit();
            this.grPhu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nLaiSuat)).BeginInit();
            this.pnGiaCuoc.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTram
            // 
            this.lblTram.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTram.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTram.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTram.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTram.ForeColor = System.Drawing.Color.Navy;
            this.lblTram.Location = new System.Drawing.Point(0, 0);
            this.lblTram.Name = "lblTram";
            this.lblTram.Size = new System.Drawing.Size(370, 30);
            this.lblTram.TabIndex = 153;
            this.lblTram.Text = "THIẾT LẬP THAM SỐ";
            this.lblTram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(26, 8);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(90, 32);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Location = new System.Drawing.Point(257, 8);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(90, 32);
            this.cmdExit.TabIndex = 7;
            this.cmdExit.Text = "Cancel";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // grGiaCuoc
            // 
            this.grGiaCuoc.Controls.Add(this.grPhu);
            this.grGiaCuoc.Controls.Add(this.cboVuTrong);
            this.grGiaCuoc.Controls.Add(this.label8);
            this.grGiaCuoc.Controls.Add(this.label7);
            this.grGiaCuoc.Controls.Add(this.nLaiSuat);
            this.grGiaCuoc.Controls.Add(this.label3);
            this.grGiaCuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grGiaCuoc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grGiaCuoc.ForeColor = System.Drawing.Color.Maroon;
            this.grGiaCuoc.Location = new System.Drawing.Point(0, 0);
            this.grGiaCuoc.Name = "grGiaCuoc";
            this.grGiaCuoc.Size = new System.Drawing.Size(366, 174);
            this.grGiaCuoc.TabIndex = 2;
            this.grGiaCuoc.TabStop = false;
            this.grGiaCuoc.Text = "Lựa chọn";
            // 
            // grPhu
            // 
            this.grPhu.Controls.Add(this.rdNgayKhac);
            this.grPhu.Controls.Add(this.rdNgayNhanDauTu);
            this.grPhu.Controls.Add(this.dtNgayTinhLai);
            this.grPhu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grPhu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grPhu.ForeColor = System.Drawing.Color.Purple;
            this.grPhu.Location = new System.Drawing.Point(3, 91);
            this.grPhu.Name = "grPhu";
            this.grPhu.Size = new System.Drawing.Size(360, 80);
            this.grPhu.TabIndex = 5;
            this.grPhu.Text = "Ngày tính lãi";
            this.grPhu.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.grPhu.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.VS2005;
            // 
            // rdNgayKhac
            // 
            this.rdNgayKhac.AutoSize = true;
            this.rdNgayKhac.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNgayKhac.ForeColor = System.Drawing.Color.Black;
            this.rdNgayKhac.Location = new System.Drawing.Point(39, 50);
            this.rdNgayKhac.Name = "rdNgayKhac";
            this.rdNgayKhac.Size = new System.Drawing.Size(82, 19);
            this.rdNgayKhac.TabIndex = 7;
            this.rdNgayKhac.TabStop = true;
            this.rdNgayKhac.Text = "Ngày khác";
            this.rdNgayKhac.UseVisualStyleBackColor = true;
            // 
            // rdNgayNhanDauTu
            // 
            this.rdNgayNhanDauTu.AutoSize = true;
            this.rdNgayNhanDauTu.Checked = true;
            this.rdNgayNhanDauTu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNgayNhanDauTu.ForeColor = System.Drawing.Color.Black;
            this.rdNgayNhanDauTu.Location = new System.Drawing.Point(39, 18);
            this.rdNgayNhanDauTu.Name = "rdNgayNhanDauTu";
            this.rdNgayNhanDauTu.Size = new System.Drawing.Size(145, 19);
            this.rdNgayNhanDauTu.TabIndex = 6;
            this.rdNgayNhanDauTu.TabStop = true;
            this.rdNgayNhanDauTu.Text = "Theo ngày nhận vật tư";
            this.rdNgayNhanDauTu.UseVisualStyleBackColor = true;
            this.rdNgayNhanDauTu.CheckedChanged += new System.EventHandler(this.rdNgayNhanDauTu_CheckedChanged);
            // 
            // dtNgayTinhLai
            // 
            this.dtNgayTinhLai.CustomFormat = "dd/MM/yyyy";
            this.dtNgayTinhLai.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtNgayTinhLai.DropDownCalendar.ForeColor = System.Drawing.Color.Black;
            this.dtNgayTinhLai.DropDownCalendar.Name = "";
            this.dtNgayTinhLai.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            this.dtNgayTinhLai.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayTinhLai.ForeColor = System.Drawing.Color.Black;
            this.dtNgayTinhLai.Location = new System.Drawing.Point(150, 46);
            this.dtNgayTinhLai.Name = "dtNgayTinhLai";
            this.dtNgayTinhLai.Size = new System.Drawing.Size(137, 26);
            this.dtNgayTinhLai.TabIndex = 8;
            this.dtNgayTinhLai.Visible = false;
            this.dtNgayTinhLai.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            // 
            // cboVuTrong
            // 
            this.cboVuTrong.BackColor = System.Drawing.Color.White;
            this.cboVuTrong.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboVuTrong.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVuTrong.ForeColor = System.Drawing.Color.Black;
            this.cboVuTrong.Location = new System.Drawing.Point(150, 21);
            this.cboVuTrong.Name = "cboVuTrong";
            this.cboVuTrong.Size = new System.Drawing.Size(137, 26);
            this.cboVuTrong.TabIndex = 3;
            this.cboVuTrong.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(42, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 16);
            this.label8.TabIndex = 169;
            this.label8.Text = "Lãi suất đầu tư:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(250, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 16);
            this.label7.TabIndex = 167;
            this.label7.Text = "(%) ";
            // 
            // nLaiSuat
            // 
            this.nLaiSuat.DecimalPlaces = 2;
            this.nLaiSuat.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nLaiSuat.ForeColor = System.Drawing.Color.Black;
            this.nLaiSuat.Location = new System.Drawing.Point(150, 58);
            this.nLaiSuat.Name = "nLaiSuat";
            this.nLaiSuat.Size = new System.Drawing.Size(92, 26);
            this.nLaiSuat.TabIndex = 4;
            this.nLaiSuat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nLaiSuat.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(42, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 161;
            this.label3.Text = "Vụ trồng đầu tư:";
            // 
            // pnGiaCuoc
            // 
            this.pnGiaCuoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnGiaCuoc.Controls.Add(this.grGiaCuoc);
            this.pnGiaCuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGiaCuoc.Location = new System.Drawing.Point(0, 30);
            this.pnGiaCuoc.Name = "pnGiaCuoc";
            this.pnGiaCuoc.Size = new System.Drawing.Size(370, 178);
            this.pnGiaCuoc.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdOK);
            this.panel2.Controls.Add(this.cmdExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 208);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(370, 45);
            this.panel2.TabIndex = 5;
            // 
            // frm_CF_LaiSuat_VuTrong
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(370, 253);
            this.Controls.Add(this.pnGiaCuoc);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTram);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_CF_LaiSuat_VuTrong";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vật tư - đầu tư";
            this.grGiaCuoc.ResumeLayout(false);
            this.grGiaCuoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grPhu)).EndInit();
            this.grPhu.ResumeLayout(false);
            this.grPhu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nLaiSuat)).EndInit();
            this.pnGiaCuoc.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTram;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.GroupBox grGiaCuoc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nLaiSuat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnGiaCuoc;
        private System.Windows.Forms.Panel panel2;
        private Janus.Windows.EditControls.UIComboBox cboVuTrong;
        private Janus.Windows.CalendarCombo.CalendarCombo dtNgayTinhLai;
        private Janus.Windows.EditControls.UIGroupBox grPhu;
        private System.Windows.Forms.RadioButton rdNgayKhac;
        private System.Windows.Forms.RadioButton rdNgayNhanDauTu;
    }
}