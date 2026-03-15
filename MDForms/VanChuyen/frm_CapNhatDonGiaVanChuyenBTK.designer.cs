namespace MDSolution.MDForms.VanChuyen
{
    partial class frm_CapNhatDonGiaVanChuyenBTK
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtNgayApDung = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nDonGia = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.pnGiaCuoc = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grGiaCuoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nDonGia)).BeginInit();
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
            this.lblTram.Size = new System.Drawing.Size(489, 30);
            this.lblTram.TabIndex = 153;
            this.lblTram.Text = "CẬP NHẬT ĐƠN GIÁ VẬN CHUYỂN";
            this.lblTram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(26, 9);
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
            this.cmdExit.Location = new System.Drawing.Point(376, 9);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(90, 32);
            this.cmdExit.TabIndex = 7;
            this.cmdExit.Text = "Cancel";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // grGiaCuoc
            // 
            this.grGiaCuoc.Controls.Add(this.label1);
            this.grGiaCuoc.Controls.Add(this.dtNgayApDung);
            this.grGiaCuoc.Controls.Add(this.label8);
            this.grGiaCuoc.Controls.Add(this.label7);
            this.grGiaCuoc.Controls.Add(this.nDonGia);
            this.grGiaCuoc.Controls.Add(this.label3);
            this.grGiaCuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grGiaCuoc.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grGiaCuoc.ForeColor = System.Drawing.Color.Maroon;
            this.grGiaCuoc.Location = new System.Drawing.Point(0, 0);
            this.grGiaCuoc.Name = "grGiaCuoc";
            this.grGiaCuoc.Size = new System.Drawing.Size(485, 137);
            this.grGiaCuoc.TabIndex = 2;
            this.grGiaCuoc.TabStop = false;
            this.grGiaCuoc.Text = "Thông tin cập nhật";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 239;
            this.label1.Text = "(giảm nhập số âm)";
            // 
            // dtNgayApDung
            // 
            this.dtNgayApDung.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtNgayApDung.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtNgayApDung.DropDownCalendar.Name = "";
            this.dtNgayApDung.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            this.dtNgayApDung.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayApDung.ForeColor = System.Drawing.Color.Black;
            this.dtNgayApDung.Location = new System.Drawing.Point(136, 29);
            this.dtNgayApDung.Name = "dtNgayApDung";
            this.dtNgayApDung.Size = new System.Drawing.Size(312, 32);
            this.dtNgayApDung.TabIndex = 3;
            this.dtNgayApDung.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(89, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 169;
            this.label8.Text = "Tăng:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(328, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 16);
            this.label7.TabIndex = 167;
            this.label7.Text = "(%) so với giá cũ";
            // 
            // nDonGia
            // 
            this.nDonGia.DecimalPlaces = 3;
            this.nDonGia.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nDonGia.ForeColor = System.Drawing.Color.Black;
            this.nDonGia.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nDonGia.Location = new System.Drawing.Point(136, 79);
            this.nDonGia.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nDonGia.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.nDonGia.Name = "nDonGia";
            this.nDonGia.Size = new System.Drawing.Size(186, 35);
            this.nDonGia.TabIndex = 4;
            this.nDonGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nDonGia.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(39, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 161;
            this.label3.Text = "Ngày áp dụng:";
            // 
            // pnGiaCuoc
            // 
            this.pnGiaCuoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnGiaCuoc.Controls.Add(this.grGiaCuoc);
            this.pnGiaCuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGiaCuoc.Location = new System.Drawing.Point(0, 30);
            this.pnGiaCuoc.Name = "pnGiaCuoc";
            this.pnGiaCuoc.Size = new System.Drawing.Size(489, 141);
            this.pnGiaCuoc.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdOK);
            this.panel2.Controls.Add(this.cmdExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 171);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(489, 51);
            this.panel2.TabIndex = 5;
            // 
            // frm_CapNhatDonGiaVanChuyenBTK
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(489, 222);
            this.Controls.Add(this.pnGiaCuoc);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTram);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_CapNhatDonGiaVanChuyenBTK";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đơn giá vận chuyển";
            this.grGiaCuoc.ResumeLayout(false);
            this.grGiaCuoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nDonGia)).EndInit();
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
        private System.Windows.Forms.NumericUpDown nDonGia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnGiaCuoc;
        private System.Windows.Forms.Panel panel2;
        private Janus.Windows.CalendarCombo.CalendarCombo dtNgayApDung;
        private System.Windows.Forms.Label label1;
    }
}