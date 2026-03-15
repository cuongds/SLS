namespace MDSolution
{
    partial class frm_ThemSuaBTK
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
            this.lblTenBai = new System.Windows.Forms.Label();
            this.txtTenBai = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.grBBX = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nKhoangCach = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grDonGiaApDung = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtNgayApDung = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nDonGiaApDung = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDotApDung = new System.Windows.Forms.Label();
            this.grBBX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nKhoangCach)).BeginInit();
            this.panel1.SuspendLayout();
            this.grDonGiaApDung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nDonGiaApDung)).BeginInit();
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
            this.lblTram.Size = new System.Drawing.Size(559, 30);
            this.lblTram.TabIndex = 153;
            this.lblTram.Text = "THÊM DANH MỤC BÃI TẬP KẾT";
            this.lblTram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenBai
            // 
            this.lblTenBai.AutoSize = true;
            this.lblTenBai.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBai.ForeColor = System.Drawing.Color.Black;
            this.lblTenBai.Location = new System.Drawing.Point(6, 32);
            this.lblTenBai.Name = "lblTenBai";
            this.lblTenBai.Size = new System.Drawing.Size(62, 16);
            this.lblTenBai.TabIndex = 154;
            this.lblTenBai.Text = "Tên BBX:";
            // 
            // txtTenBai
            // 
            this.txtTenBai.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenBai.ForeColor = System.Drawing.Color.Black;
            this.txtTenBai.Location = new System.Drawing.Point(76, 27);
            this.txtTenBai.MaxLength = 50;
            this.txtTenBai.Name = "txtTenBai";
            this.txtTenBai.Size = new System.Drawing.Size(209, 26);
            this.txtTenBai.TabIndex = 155;
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(26, 9);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(90, 32);
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
            this.cmdExit.Location = new System.Drawing.Point(443, 9);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(90, 32);
            this.cmdExit.TabIndex = 157;
            this.cmdExit.Text = "Cancel";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // grBBX
            // 
            this.grBBX.Controls.Add(this.label9);
            this.grBBX.Controls.Add(this.txtGhiChu);
            this.grBBX.Controls.Add(this.label5);
            this.grBBX.Controls.Add(this.label3);
            this.grBBX.Controls.Add(this.nKhoangCach);
            this.grBBX.Controls.Add(this.txtTenBai);
            this.grBBX.Controls.Add(this.lblTenBai);
            this.grBBX.Dock = System.Windows.Forms.DockStyle.Top;
            this.grBBX.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grBBX.ForeColor = System.Drawing.Color.Maroon;
            this.grBBX.Location = new System.Drawing.Point(0, 0);
            this.grBBX.Name = "grBBX";
            this.grBBX.Size = new System.Drawing.Size(555, 100);
            this.grBBX.TabIndex = 160;
            this.grBBX.TabStop = false;
            this.grBBX.Text = "Thông tin Bãi bốc xếp";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(6, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 16);
            this.label9.TabIndex = 165;
            this.label9.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.ForeColor = System.Drawing.Color.Black;
            this.txtGhiChu.Location = new System.Drawing.Point(76, 66);
            this.txtGhiChu.MaxLength = 100;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(455, 26);
            this.txtGhiChu.TabIndex = 164;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(512, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 16);
            this.label5.TabIndex = 163;
            this.label5.Text = "(km)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(318, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 161;
            this.label3.Text = "Khoảng cách:";
            // 
            // nKhoangCach
            // 
            this.nKhoangCach.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nKhoangCach.ForeColor = System.Drawing.Color.Black;
            this.nKhoangCach.Location = new System.Drawing.Point(412, 27);
            this.nKhoangCach.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nKhoangCach.Name = "nKhoangCach";
            this.nKhoangCach.Size = new System.Drawing.Size(98, 26);
            this.nKhoangCach.TabIndex = 160;
            this.nKhoangCach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nKhoangCach.ThousandsSeparator = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.grDonGiaApDung);
            this.panel1.Controls.Add(this.grBBX);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 245);
            this.panel1.TabIndex = 161;
            // 
            // grDonGiaApDung
            // 
            this.grDonGiaApDung.Controls.Add(this.lblDotApDung);
            this.grDonGiaApDung.Controls.Add(this.label4);
            this.grDonGiaApDung.Controls.Add(this.label6);
            this.grDonGiaApDung.Controls.Add(this.dtNgayApDung);
            this.grDonGiaApDung.Controls.Add(this.label1);
            this.grDonGiaApDung.Controls.Add(this.label2);
            this.grDonGiaApDung.Controls.Add(this.nDonGiaApDung);
            this.grDonGiaApDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDonGiaApDung.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grDonGiaApDung.ForeColor = System.Drawing.Color.DarkBlue;
            this.grDonGiaApDung.Location = new System.Drawing.Point(0, 100);
            this.grDonGiaApDung.Name = "grDonGiaApDung";
            this.grDonGiaApDung.Size = new System.Drawing.Size(555, 141);
            this.grDonGiaApDung.TabIndex = 162;
            this.grDonGiaApDung.TabStop = false;
            this.grDonGiaApDung.Text = "Thiết lập";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(56, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 174;
            this.label6.Text = "Ngày áp dụng:";
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
            this.dtNgayApDung.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayApDung.ForeColor = System.Drawing.Color.Black;
            this.dtNgayApDung.Location = new System.Drawing.Point(160, 101);
            this.dtNgayApDung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtNgayApDung.Name = "dtNgayApDung";
            this.dtNgayApDung.Size = new System.Drawing.Size(233, 25);
            this.dtNgayApDung.TabIndex = 173;
            this.dtNgayApDung.Value = new System.DateTime(2017, 8, 14, 0, 0, 0, 0);
            this.dtNgayApDung.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(265, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 171;
            this.label1.Text = "(đ/tấn)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(21, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 16);
            this.label2.TabIndex = 172;
            this.label2.Text = "Đơn giá vận chuyển:";
            // 
            // nDonGiaApDung
            // 
            this.nDonGiaApDung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nDonGiaApDung.ForeColor = System.Drawing.Color.Black;
            this.nDonGiaApDung.Location = new System.Drawing.Point(160, 21);
            this.nDonGiaApDung.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nDonGiaApDung.Name = "nDonGiaApDung";
            this.nDonGiaApDung.Size = new System.Drawing.Size(98, 26);
            this.nDonGiaApDung.TabIndex = 170;
            this.nDonGiaApDung.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nDonGiaApDung.ThousandsSeparator = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdOK);
            this.panel2.Controls.Add(this.cmdExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 275);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(559, 51);
            this.panel2.TabIndex = 162;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(64, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 175;
            this.label4.Text = "Đợt áp dụng:";
            // 
            // lblDotApDung
            // 
            this.lblDotApDung.AutoSize = true;
            this.lblDotApDung.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDotApDung.ForeColor = System.Drawing.Color.Red;
            this.lblDotApDung.Location = new System.Drawing.Point(160, 64);
            this.lblDotApDung.Name = "lblDotApDung";
            this.lblDotApDung.Size = new System.Drawing.Size(108, 18);
            this.lblDotApDung.TabIndex = 176;
            this.lblDotApDung.Text = "Tất cả các đợt";
            // 
            // frm_ThemSuaBTK
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(559, 326);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTram);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ThemSuaBTK";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " DM Bãi bốc xếp";
            this.grBBX.ResumeLayout(false);
            this.grBBX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nKhoangCach)).EndInit();
            this.panel1.ResumeLayout(false);
            this.grDonGiaApDung.ResumeLayout(false);
            this.grDonGiaApDung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nDonGiaApDung)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTram;
        private System.Windows.Forms.Label lblTenBai;
        private System.Windows.Forms.TextBox txtTenBai;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.GroupBox grBBX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nKhoangCach;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grDonGiaApDung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nDonGiaApDung;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.CalendarCombo.CalendarCombo dtNgayApDung;
        private System.Windows.Forms.Label lblDotApDung;
        private System.Windows.Forms.Label label4;
    }
}