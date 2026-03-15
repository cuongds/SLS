namespace MDSolution.MDForms.UngTien
{
    partial class frm_ThemSuaUngVanChuyen
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
            this.lblUngVT = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.grXe = new System.Windows.Forms.GroupBox();
            this.rtbBangChu = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboLoaiVT = new Janus.Windows.EditControls.UIComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoCT = new System.Windows.Forms.TextBox();
            this.nSoTien = new System.Windows.Forms.NumericUpDown();
            this.nSoLuong = new System.Windows.Forms.NumericUpDown();
            this.dtNgayUng = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label8 = new System.Windows.Forms.Label();
            this.nDonGia = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grXe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSoTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDonGia)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUngVT
            // 
            this.lblUngVT.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUngVT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUngVT.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUngVT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUngVT.ForeColor = System.Drawing.Color.Navy;
            this.lblUngVT.Location = new System.Drawing.Point(0, 0);
            this.lblUngVT.Name = "lblUngVT";
            this.lblUngVT.Size = new System.Drawing.Size(462, 30);
            this.lblUngVT.TabIndex = 153;
            this.lblUngVT.Text = "SỬA ỨNG VẬT TƯ VẬN CHUYỂN";
            this.lblUngVT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(26, 9);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(90, 30);
            this.cmdOK.TabIndex = 8;
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
            this.cmdExit.Location = new System.Drawing.Point(349, 9);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(90, 30);
            this.cmdExit.TabIndex = 9;
            this.cmdExit.Text = "Cancel";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // grXe
            // 
            this.grXe.Controls.Add(this.rtbBangChu);
            this.grXe.Controls.Add(this.label6);
            this.grXe.Controls.Add(this.cboLoaiVT);
            this.grXe.Controls.Add(this.label5);
            this.grXe.Controls.Add(this.label4);
            this.grXe.Controls.Add(this.label2);
            this.grXe.Controls.Add(this.label1);
            this.grXe.Controls.Add(this.txtSoCT);
            this.grXe.Controls.Add(this.nSoTien);
            this.grXe.Controls.Add(this.nSoLuong);
            this.grXe.Controls.Add(this.dtNgayUng);
            this.grXe.Controls.Add(this.label8);
            this.grXe.Controls.Add(this.nDonGia);
            this.grXe.Controls.Add(this.label3);
            this.grXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grXe.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grXe.ForeColor = System.Drawing.Color.Maroon;
            this.grXe.Location = new System.Drawing.Point(0, 0);
            this.grXe.Name = "grXe";
            this.grXe.Size = new System.Drawing.Size(458, 215);
            this.grXe.TabIndex = 160;
            this.grXe.TabStop = false;
            this.grXe.Text = "Phiếu ứng vật tư xe: ";
            // 
            // rtbBangChu
            // 
            this.rtbBangChu.BackColor = System.Drawing.Color.White;
            this.rtbBangChu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbBangChu.ForeColor = System.Drawing.Color.Red;
            this.rtbBangChu.Location = new System.Drawing.Point(89, 173);
            this.rtbBangChu.Name = "rtbBangChu";
            this.rtbBangChu.ReadOnly = true;
            this.rtbBangChu.Size = new System.Drawing.Size(350, 36);
            this.rtbBangChu.TabIndex = 247;
            this.rtbBangChu.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(9, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 19);
            this.label6.TabIndex = 246;
            this.label6.Text = "Bằng chữ:";
            // 
            // cboLoaiVT
            // 
            this.cboLoaiVT.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboLoaiVT.ForeColor = System.Drawing.Color.Black;
            this.cboLoaiVT.Location = new System.Drawing.Point(89, 27);
            this.cboLoaiVT.MaxDropDownItems = 20;
            this.cboLoaiVT.Name = "cboLoaiVT";
            this.cboLoaiVT.SelectedItemFormatStyle.ForeColor = System.Drawing.Color.DarkBlue;
            this.cboLoaiVT.Size = new System.Drawing.Size(351, 26);
            this.cboLoaiVT.TabIndex = 2;
            this.cboLoaiVT.Text = "Chọn loại vật tư ứng";
            this.cboLoaiVT.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.cboLoaiVT.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(23, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 19);
            this.label5.TabIndex = 245;
            this.label5.Text = "Loại VT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(25, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 19);
            this.label4.TabIndex = 244;
            this.label4.Text = "Số tiền:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 19);
            this.label2.TabIndex = 243;
            this.label2.Text = "Số lượng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(258, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 242;
            this.label1.Text = "Số CT:";
            // 
            // txtSoCT
            // 
            this.txtSoCT.BackColor = System.Drawing.SystemColors.Info;
            this.txtSoCT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoCT.ForeColor = System.Drawing.Color.Black;
            this.txtSoCT.Location = new System.Drawing.Point(311, 66);
            this.txtSoCT.Name = "txtSoCT";
            this.txtSoCT.ReadOnly = true;
            this.txtSoCT.Size = new System.Drawing.Size(128, 26);
            this.txtSoCT.TabIndex = 4;
            this.txtSoCT.TabStop = false;
            // 
            // nSoTien
            // 
            this.nSoTien.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nSoTien.ForeColor = System.Drawing.Color.Black;
            this.nSoTien.Location = new System.Drawing.Point(89, 140);
            this.nSoTien.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nSoTien.Minimum = new decimal(new int[] {
            1410065408,
            2,
            0,
            -2147483648});
            this.nSoTien.Name = "nSoTien";
            this.nSoTien.Size = new System.Drawing.Size(348, 26);
            this.nSoTien.TabIndex = 7;
            this.nSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nSoTien.ThousandsSeparator = true;
            this.nSoTien.ValueChanged += new System.EventHandler(this.nSoTien_ValueChanged);
            // 
            // nSoLuong
            // 
            this.nSoLuong.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nSoLuong.ForeColor = System.Drawing.Color.Black;
            this.nSoLuong.Location = new System.Drawing.Point(89, 106);
            this.nSoLuong.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nSoLuong.Name = "nSoLuong";
            this.nSoLuong.Size = new System.Drawing.Size(126, 26);
            this.nSoLuong.TabIndex = 5;
            this.nSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nSoLuong.ThousandsSeparator = true;
            this.nSoLuong.ValueChanged += new System.EventHandler(this.nSoLuong_ValueChanged);
            // 
            // dtNgayUng
            // 
            this.dtNgayUng.CustomFormat = "dd/MM/yyyy";
            this.dtNgayUng.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtNgayUng.DropDownCalendar.Name = "";
            this.dtNgayUng.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            this.dtNgayUng.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayUng.ForeColor = System.Drawing.Color.Black;
            this.dtNgayUng.Location = new System.Drawing.Point(89, 66);
            this.dtNgayUng.Name = "dtNgayUng";
            this.dtNgayUng.Size = new System.Drawing.Size(126, 26);
            this.dtNgayUng.TabIndex = 3;
            this.dtNgayUng.Value = new System.DateTime(2017, 8, 14, 0, 0, 0, 0);
            this.dtNgayUng.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(247, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 19);
            this.label8.TabIndex = 169;
            this.label8.Text = "Đơn giá:";
            // 
            // nDonGia
            // 
            this.nDonGia.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nDonGia.ForeColor = System.Drawing.Color.Black;
            this.nDonGia.Location = new System.Drawing.Point(311, 106);
            this.nDonGia.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nDonGia.Name = "nDonGia";
            this.nDonGia.Size = new System.Drawing.Size(126, 26);
            this.nDonGia.TabIndex = 6;
            this.nDonGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nDonGia.ThousandsSeparator = true;
            this.nDonGia.ValueChanged += new System.EventHandler(this.nDonGia_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 19);
            this.label3.TabIndex = 161;
            this.label3.Text = "Ngày ứng:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.grXe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 219);
            this.panel1.TabIndex = 161;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdOK);
            this.panel2.Controls.Add(this.cmdExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 249);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 45);
            this.panel2.TabIndex = 162;
            // 
            // frm_ThemSuaUngVanChuyen
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(462, 294);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblUngVT);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ThemSuaUngVanChuyen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sửa ứng vận chuyển";
            this.grXe.ResumeLayout(false);
            this.grXe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSoTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDonGia)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUngVT;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.GroupBox grXe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nDonGia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Janus.Windows.CalendarCombo.CalendarCombo dtNgayUng;
        private System.Windows.Forms.NumericUpDown nSoTien;
        private System.Windows.Forms.NumericUpDown nSoLuong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoCT;
        private System.Windows.Forms.Label label5;
        private Janus.Windows.EditControls.UIComboBox cboLoaiVT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtbBangChu;
    }
}