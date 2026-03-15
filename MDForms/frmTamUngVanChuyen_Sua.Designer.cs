namespace MDSolution.MDForms
{
    partial class frmTamUngVanChuyen_Sua
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbVatTu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtNgayLap = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label5 = new System.Windows.Forms.Label();
            this.numSoluong = new System.Windows.Forms.NumericUpDown();
            this.numDonGia = new System.Windows.Forms.NumericUpDown();
            this.numSoTien = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSoluong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTien)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vật tư:";
            // 
            // cbVatTu
            // 
            this.cbVatTu.FormattingEnabled = true;
            this.cbVatTu.Location = new System.Drawing.Point(98, 6);
            this.cbVatTu.Name = "cbVatTu";
            this.cbVatTu.Size = new System.Drawing.Size(196, 21);
            this.cbVatTu.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số lượng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Đơn giá:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Số tiền:";
            // 
            // dtNgayLap
            // 
            this.dtNgayLap.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.dtNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dtNgayLap.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtNgayLap.DropDownCalendar.FirstMonth = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtNgayLap.DropDownCalendar.Name = "";
            this.dtNgayLap.DropDownCalendar.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtNgayLap.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.dtNgayLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayLap.ForeColor = System.Drawing.Color.Black;
            this.dtNgayLap.Location = new System.Drawing.Point(98, 121);
            this.dtNgayLap.MinDate = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtNgayLap.Name = "dtNgayLap";
            this.dtNgayLap.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtNgayLap.Size = new System.Drawing.Size(196, 21);
            this.dtNgayLap.TabIndex = 69;
            this.dtNgayLap.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 70;
            this.label5.Text = "Ngày ứng:";
            // 
            // numSoluong
            // 
            this.numSoluong.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSoluong.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSoluong.Location = new System.Drawing.Point(98, 34);
            this.numSoluong.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.numSoluong.Name = "numSoluong";
            this.numSoluong.Size = new System.Drawing.Size(196, 22);
            this.numSoluong.TabIndex = 71;
            this.numSoluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numDonGia
            // 
            this.numDonGia.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDonGia.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numDonGia.Location = new System.Drawing.Point(98, 63);
            this.numDonGia.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.numDonGia.Name = "numDonGia";
            this.numDonGia.Size = new System.Drawing.Size(196, 22);
            this.numDonGia.TabIndex = 72;
            this.numDonGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numSoTien
            // 
            this.numSoTien.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSoTien.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSoTien.Location = new System.Drawing.Point(98, 92);
            this.numSoTien.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.numSoTien.Name = "numSoTien";
            this.numSoTien.Size = new System.Drawing.Size(196, 22);
            this.numSoTien.TabIndex = 73;
            this.numSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 74;
            this.button1.Text = "Lưu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(179, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 74;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmTamUngVanChuyen_Sua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 216);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numSoTien);
            this.Controls.Add(this.numDonGia);
            this.Controls.Add(this.numSoluong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtNgayLap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbVatTu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmTamUngVanChuyen_Sua";
            this.Text = "Sửa";
            ((System.ComponentModel.ISupportInitialize)(this.numSoluong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.ComboBox cbVatTu;
        public Janus.Windows.CalendarCombo.CalendarCombo dtNgayLap;
        public System.Windows.Forms.NumericUpDown numSoluong;
        public System.Windows.Forms.NumericUpDown numDonGia;
        public System.Windows.Forms.NumericUpDown numSoTien;
    }
}