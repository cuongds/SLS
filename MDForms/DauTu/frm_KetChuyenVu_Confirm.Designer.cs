namespace MDSolution.MDForms.DauTu
{
    partial class frm_KetChuyenVu_Confirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_KetChuyenVu_Confirm));
            this.officeFormAdorner1 = new Janus.Windows.Ribbon.OfficeFormAdorner(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnOK = new Janus.Windows.EditControls.UIButton();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.ComboVuTrong = new Janus.Windows.EditControls.UIComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboDMGoc = new Janus.Windows.EditControls.UIComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboDMLai = new Janus.Windows.EditControls.UIComboBox();
            this.dtNgayTinhLai = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label5 = new System.Windows.Forms.Label();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.pnChoice = new System.Windows.Forms.Panel();
            this.grChoice = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).BeginInit();
            this.pnBottom.SuspendLayout();
            this.pnChoice.SuspendLayout();
            this.grChoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // officeFormAdorner1
            // 
            this.officeFormAdorner1.Form = this;
            this.officeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(686, 30);
            this.lblTitle.TabIndex = 173;
            this.lblTitle.Text = "THAM SỐ CHUYỂN VỤ ĐẦU TƯ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Icon = ((System.Drawing.Icon)(resources.GetObject("btnOK.Icon")));
            this.btnOK.Location = new System.Drawing.Point(580, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 30);
            this.btnOK.TabIndex = 175;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.ToolTipText = "Chi tiết lịch sử thanh toán cho khoản đầu tư được chọn";
            this.btnOK.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(11, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 30);
            this.btnCancel.TabIndex = 174;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.ToolTipText = "Chi tiết lịch sử thanh toán cho khoản đầu tư được chọn";
            this.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ComboVuTrong
            // 
            this.ComboVuTrong.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.ComboVuTrong.ForeColor = System.Drawing.Color.Black;
            this.ComboVuTrong.Location = new System.Drawing.Point(176, 27);
            this.ComboVuTrong.Name = "ComboVuTrong";
            this.ComboVuTrong.Size = new System.Drawing.Size(223, 22);
            this.ComboVuTrong.TabIndex = 177;
            this.ComboVuTrong.Text = "Chọn vụ trồng";
            this.ComboVuTrong.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 16);
            this.label3.TabIndex = 176;
            this.label3.Text = "Kết chuyển sang vụ trồng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(39, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 176;
            this.label2.Text = "Kết chuyển gốc sang:";
            // 
            // comboDMGoc
            // 
            this.comboDMGoc.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.comboDMGoc.ForeColor = System.Drawing.Color.Black;
            this.comboDMGoc.Location = new System.Drawing.Point(176, 66);
            this.comboDMGoc.Name = "comboDMGoc";
            this.comboDMGoc.Size = new System.Drawing.Size(223, 22);
            this.comboDMGoc.TabIndex = 177;
            this.comboDMGoc.Text = "Chọn danh mục đt";
            this.comboDMGoc.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(47, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 16);
            this.label4.TabIndex = 176;
            this.label4.Text = "Kết chuyển lãi sang:";
            // 
            // comboDMLai
            // 
            this.comboDMLai.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.comboDMLai.ForeColor = System.Drawing.Color.Black;
            this.comboDMLai.Location = new System.Drawing.Point(176, 105);
            this.comboDMLai.Name = "comboDMLai";
            this.comboDMLai.Size = new System.Drawing.Size(223, 22);
            this.comboDMLai.TabIndex = 177;
            this.comboDMLai.Text = "Chọn danh mục đt";
            this.comboDMLai.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // dtNgayTinhLai
            // 
            this.dtNgayTinhLai.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.dtNgayTinhLai.CustomFormat = "dd/MM/yyyy";
            this.dtNgayTinhLai.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtNgayTinhLai.DropDownCalendar.FirstMonth = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtNgayTinhLai.DropDownCalendar.Name = "";
            this.dtNgayTinhLai.DropDownCalendar.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtNgayTinhLai.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            this.dtNgayTinhLai.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayTinhLai.ForeColor = System.Drawing.Color.Black;
            this.dtNgayTinhLai.Location = new System.Drawing.Point(176, 145);
            this.dtNgayTinhLai.MinDate = new System.DateTime(2000, 2, 1, 0, 0, 0, 0);
            this.dtNgayTinhLai.Name = "dtNgayTinhLai";
            this.dtNgayTinhLai.Office2007CustomColor = System.Drawing.Color.Black;
            this.dtNgayTinhLai.Size = new System.Drawing.Size(223, 22);
            this.dtNgayTinhLai.TabIndex = 179;
            this.dtNgayTinhLai.Value = new System.DateTime(2017, 1, 1, 0, 5, 0, 0);
            this.dtNgayTinhLai.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2005;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(43, 148);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 16);
            this.label5.TabIndex = 178;
            this.label5.Text = "Ngày bắt đầu tính lãi:";
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.btnOK);
            this.pnBottom.Controls.Add(this.btnCancel);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 480);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(686, 41);
            this.pnBottom.TabIndex = 180;
            // 
            // pnChoice
            // 
            this.pnChoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnChoice.Controls.Add(this.grChoice);
            this.pnChoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnChoice.Location = new System.Drawing.Point(0, 30);
            this.pnChoice.Name = "pnChoice";
            this.pnChoice.Size = new System.Drawing.Size(686, 450);
            this.pnChoice.TabIndex = 181;
            // 
            // grChoice
            // 
            this.grChoice.Controls.Add(this.dtNgayTinhLai);
            this.grChoice.Controls.Add(this.label5);
            this.grChoice.Controls.Add(this.comboDMLai);
            this.grChoice.Controls.Add(this.label4);
            this.grChoice.Controls.Add(this.comboDMGoc);
            this.grChoice.Controls.Add(this.label2);
            this.grChoice.Controls.Add(this.ComboVuTrong);
            this.grChoice.Controls.Add(this.label3);
            this.grChoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grChoice.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grChoice.ForeColor = System.Drawing.Color.Maroon;
            this.grChoice.Location = new System.Drawing.Point(0, 0);
            this.grChoice.Name = "grChoice";
            this.grChoice.Size = new System.Drawing.Size(682, 446);
            this.grChoice.TabIndex = 180;
            this.grChoice.TabStop = false;
            this.grChoice.Text = "Lựa chọn";
            // 
            // frm_KetChuyenVu_Confirm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 521);
            this.Controls.Add(this.pnChoice);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnBottom);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_KetChuyenVu_Confirm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển vụ đầu tư";
            this.Load += new System.EventHandler(this.frm_KetChuyenVu_Confirm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).EndInit();
            this.pnBottom.ResumeLayout(false);
            this.pnChoice.ResumeLayout(false);
            this.grChoice.ResumeLayout(false);
            this.grChoice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.Ribbon.OfficeFormAdorner officeFormAdorner1;
        private System.Windows.Forms.Label lblTitle;
        private Janus.Windows.EditControls.UIButton btnOK;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        public Janus.Windows.EditControls.UIComboBox ComboVuTrong;
        public Janus.Windows.EditControls.UIComboBox comboDMLai;
        public Janus.Windows.EditControls.UIComboBox comboDMGoc;
        public Janus.Windows.CalendarCombo.CalendarCombo dtNgayTinhLai;
        private System.Windows.Forms.Panel pnChoice;
        private System.Windows.Forms.Panel pnBottom;
        private System.Windows.Forms.GroupBox grChoice;
    }
}