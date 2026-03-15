namespace MDSolution.MDForms.CapVatTu
{
    partial class frm_ThemSuaGiaVatTu
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblVatTu = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grDonGiaApDung = new System.Windows.Forms.GroupBox();
            this.lblTenVT = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtNgayApDung = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblDVT = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nDonGia = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.grDonGiaApDung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nDonGia)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 30);
            this.lblTitle.TabIndex = 153;
            this.lblTitle.Text = "THIẾT LẬP GIÁ VẬT TƯ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVatTu
            // 
            this.lblVatTu.AutoSize = true;
            this.lblVatTu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVatTu.ForeColor = System.Drawing.Color.Black;
            this.lblVatTu.Location = new System.Drawing.Point(30, 29);
            this.lblVatTu.Name = "lblVatTu";
            this.lblVatTu.Size = new System.Drawing.Size(70, 16);
            this.lblVatTu.TabIndex = 154;
            this.lblVatTu.Text = "Tên vật tư:";
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(26, 9);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(90, 30);
            this.cmdOK.TabIndex = 156;
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
            this.cmdExit.Location = new System.Drawing.Point(289, 9);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(90, 30);
            this.cmdExit.TabIndex = 157;
            this.cmdExit.Text = "Cancel";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.grDonGiaApDung);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 150);
            this.panel1.TabIndex = 161;
            // 
            // grDonGiaApDung
            // 
            this.grDonGiaApDung.Controls.Add(this.lblTenVT);
            this.grDonGiaApDung.Controls.Add(this.lblVatTu);
            this.grDonGiaApDung.Controls.Add(this.label6);
            this.grDonGiaApDung.Controls.Add(this.dtNgayApDung);
            this.grDonGiaApDung.Controls.Add(this.lblDVT);
            this.grDonGiaApDung.Controls.Add(this.label2);
            this.grDonGiaApDung.Controls.Add(this.nDonGia);
            this.grDonGiaApDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDonGiaApDung.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grDonGiaApDung.ForeColor = System.Drawing.Color.DarkBlue;
            this.grDonGiaApDung.Location = new System.Drawing.Point(0, 0);
            this.grDonGiaApDung.Name = "grDonGiaApDung";
            this.grDonGiaApDung.Size = new System.Drawing.Size(401, 146);
            this.grDonGiaApDung.TabIndex = 162;
            this.grDonGiaApDung.TabStop = false;
            this.grDonGiaApDung.Text = "Đơn giá áp dụng";
            // 
            // lblTenVT
            // 
            this.lblTenVT.AutoSize = true;
            this.lblTenVT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenVT.ForeColor = System.Drawing.Color.Maroon;
            this.lblTenVT.Location = new System.Drawing.Point(102, 28);
            this.lblTenVT.Name = "lblTenVT";
            this.lblTenVT.Size = new System.Drawing.Size(58, 19);
            this.lblTenVT.TabIndex = 175;
            this.lblTenVT.Text = "TenVT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 174;
            this.label6.Text = "Ngày áp dụng:";
            // 
            // dtNgayApDung
            // 
            this.dtNgayApDung.CustomFormat = "dd/MM/yyyy";
            this.dtNgayApDung.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtNgayApDung.DropDownCalendar.Name = "";
            this.dtNgayApDung.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            this.dtNgayApDung.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayApDung.ForeColor = System.Drawing.Color.Black;
            this.dtNgayApDung.Location = new System.Drawing.Point(105, 111);
            this.dtNgayApDung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtNgayApDung.Name = "dtNgayApDung";
            this.dtNgayApDung.Size = new System.Drawing.Size(144, 25);
            this.dtNgayApDung.TabIndex = 173;
            this.dtNgayApDung.Value = new System.DateTime(2017, 8, 14, 0, 0, 0, 0);
            this.dtNgayApDung.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            // 
            // lblDVT
            // 
            this.lblDVT.AutoSize = true;
            this.lblDVT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDVT.ForeColor = System.Drawing.Color.Black;
            this.lblDVT.Location = new System.Drawing.Point(207, 72);
            this.lblDVT.Name = "lblDVT";
            this.lblDVT.Size = new System.Drawing.Size(33, 16);
            this.lblDVT.TabIndex = 171;
            this.lblDVT.Text = "DVT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(42, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 172;
            this.label2.Text = "Đơn giá:";
            // 
            // nDonGia
            // 
            this.nDonGia.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nDonGia.ForeColor = System.Drawing.Color.Black;
            this.nDonGia.Location = new System.Drawing.Point(105, 67);
            this.nDonGia.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nDonGia.Name = "nDonGia";
            this.nDonGia.Size = new System.Drawing.Size(98, 26);
            this.nDonGia.TabIndex = 170;
            this.nDonGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nDonGia.ThousandsSeparator = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdOK);
            this.panel2.Controls.Add(this.cmdExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 180);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(405, 47);
            this.panel2.TabIndex = 162;
            // 
            // frm_ThemSuaGiaVatTu
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(405, 227);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ThemSuaGiaVatTu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " DM Giá vật tư";
            this.panel1.ResumeLayout(false);
            this.grDonGiaApDung.ResumeLayout(false);
            this.grDonGiaApDung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nDonGia)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblVatTu;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grDonGiaApDung;
        private System.Windows.Forms.Label lblDVT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nDonGia;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.CalendarCombo.CalendarCombo dtNgayApDung;
        private System.Windows.Forms.Label lblTenVT;
    }
}