namespace MDSolution.MDDataSetForms
{
    partial class frmHopDongChuyenVu
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label hopDongIDLabel;
            System.Windows.Forms.Label vuTrongIDLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHopDongChuyenVu));
            this.officeFormAdorner1 = new Janus.Windows.Ribbon.OfficeFormAdorner(this.components);
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.uiGroupBox3 = new Janus.Windows.EditControls.UIGroupBox();
            this.HopDongUIDCombobox = new Janus.Windows.EditControls.UIComboBox();
            this.uiGroupBox4 = new Janus.Windows.EditControls.UIGroupBox();
            this.uiButtonClose = new Janus.Windows.EditControls.UIButton();
            this.btGhiNhan = new Janus.Windows.EditControls.UIButton();
            this.label3 = new System.Windows.Forms.Label();
            this.uiGroupBox2 = new Janus.Windows.EditControls.UIGroupBox();
            this.VuTrongUIDCombobox = new Janus.Windows.EditControls.UIComboBox();
            this.lbl_HoTen = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            hopDongIDLabel = new System.Windows.Forms.Label();
            vuTrongIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).BeginInit();
            this.uiGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox4)).BeginInit();
            this.uiGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Location = new System.Drawing.Point(22, 28);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(77, 13);
            label1.TabIndex = 81;
            label1.Text = "Mã hợp đồng :";
            // 
            // hopDongIDLabel
            // 
            hopDongIDLabel.AutoSize = true;
            hopDongIDLabel.BackColor = System.Drawing.Color.Transparent;
            hopDongIDLabel.Location = new System.Drawing.Point(258, 28);
            hopDongIDLabel.Name = "hopDongIDLabel";
            hopDongIDLabel.Size = new System.Drawing.Size(81, 13);
            hopDongIDLabel.TabIndex = 50;
            hopDongIDLabel.Text = "Chủ hợp đồng :";
            // 
            // vuTrongIDLabel
            // 
            vuTrongIDLabel.AutoSize = true;
            vuTrongIDLabel.BackColor = System.Drawing.Color.Transparent;
            vuTrongIDLabel.Location = new System.Drawing.Point(22, 23);
            vuTrongIDLabel.Name = "vuTrongIDLabel";
            vuTrongIDLabel.Size = new System.Drawing.Size(57, 13);
            vuTrongIDLabel.TabIndex = 28;
            vuTrongIDLabel.Text = "Vụ Trồng :";
            // 
            // officeFormAdorner1
            // 
            this.officeFormAdorner1.Form = this;
            this.officeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.uiGroupBox1.Controls.Add(this.uiGroupBox3);
            this.uiGroupBox1.Controls.Add(this.uiGroupBox4);
            this.uiGroupBox1.Controls.Add(this.label3);
            this.uiGroupBox1.Controls.Add(this.uiGroupBox2);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(572, 252);
            this.uiGroupBox1.TabIndex = 1;
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox3.Controls.Add(this.lbl_HoTen);
            this.uiGroupBox3.Controls.Add(label1);
            this.uiGroupBox3.Controls.Add(hopDongIDLabel);
            this.uiGroupBox3.Controls.Add(this.HopDongUIDCombobox);
            this.uiGroupBox3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.uiGroupBox3.Location = new System.Drawing.Point(7, 47);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Size = new System.Drawing.Size(536, 56);
            this.uiGroupBox3.TabIndex = 81;
            this.uiGroupBox3.Text = "Thông tin chủ hợp đồng";
            // 
            // HopDongUIDCombobox
            // 
            this.HopDongUIDCombobox.Location = new System.Drawing.Point(114, 24);
            this.HopDongUIDCombobox.Name = "HopDongUIDCombobox";
            this.HopDongUIDCombobox.Size = new System.Drawing.Size(129, 20);
            this.HopDongUIDCombobox.TabIndex = 1;
            this.HopDongUIDCombobox.SelectedIndexChanged += new System.EventHandler(this.HopDongUIDCombobox_SelectedIndexChanged);
            // 
            // uiGroupBox4
            // 
            this.uiGroupBox4.Controls.Add(this.uiButtonClose);
            this.uiGroupBox4.Controls.Add(this.btGhiNhan);
            this.uiGroupBox4.Location = new System.Drawing.Point(6, 183);
            this.uiGroupBox4.Name = "uiGroupBox4";
            this.uiGroupBox4.Size = new System.Drawing.Size(537, 64);
            this.uiGroupBox4.TabIndex = 83;
            this.uiGroupBox4.Text = "Các thao tác điều khiển bản ghi";
            this.uiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // uiButtonClose
            // 
            this.uiButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiButtonClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButtonClose.Icon = ((System.Drawing.Icon)(resources.GetObject("uiButtonClose.Icon")));
            this.uiButtonClose.Location = new System.Drawing.Point(354, 19);
            this.uiButtonClose.Name = "uiButtonClose";
            this.uiButtonClose.Size = new System.Drawing.Size(75, 23);
            this.uiButtonClose.TabIndex = 10;
            this.uiButtonClose.Text = "&Quit";
            this.uiButtonClose.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.uiButtonClose.Click += new System.EventHandler(this.uiButtonClose_Click);
            // 
            // btGhiNhan
            // 
            this.btGhiNhan.Icon = ((System.Drawing.Icon)(resources.GetObject("btGhiNhan.Icon")));
            this.btGhiNhan.Image = global::MDSolution.Properties.Resources.end;
            this.btGhiNhan.Location = new System.Drawing.Point(196, 19);
            this.btGhiNhan.Name = "btGhiNhan";
            this.btGhiNhan.Size = new System.Drawing.Size(75, 23);
            this.btGhiNhan.TabIndex = 8;
            this.btGhiNhan.Text = "Lưu lại";
            this.btGhiNhan.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btGhiNhan.Click += new System.EventHandler(this.btGhiNhan_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Info;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(566, 25);
            this.label3.TabIndex = 56;
            this.label3.Text = "Chuyển vụ cho một hợp đồng";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(vuTrongIDLabel);
            this.uiGroupBox2.Controls.Add(this.VuTrongUIDCombobox);
            this.uiGroupBox2.Location = new System.Drawing.Point(6, 109);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(537, 68);
            this.uiGroupBox2.TabIndex = 82;
            this.uiGroupBox2.Text = "Thông tin nhập hỗ trợ";
            this.uiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007;
            // 
            // VuTrongUIDCombobox
            // 
            this.VuTrongUIDCombobox.DisplayMember = "Ten";
            this.VuTrongUIDCombobox.Location = new System.Drawing.Point(115, 19);
            this.VuTrongUIDCombobox.Name = "VuTrongUIDCombobox";
            this.VuTrongUIDCombobox.Size = new System.Drawing.Size(134, 20);
            this.VuTrongUIDCombobox.TabIndex = 18;
            this.VuTrongUIDCombobox.TabStop = false;
            this.VuTrongUIDCombobox.ValueMember = "ID";
            // 
            // lbl_HoTen
            // 
            this.lbl_HoTen.AutoSize = true;
            this.lbl_HoTen.Location = new System.Drawing.Point(346, 28);
            this.lbl_HoTen.Name = "lbl_HoTen";
            this.lbl_HoTen.Size = new System.Drawing.Size(96, 13);
            this.lbl_HoTen.TabIndex = 82;
            this.lbl_HoTen.Text = "Tên chủ hơp đồng";
            // 
            // frmHopDongChuyenVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 252);
            this.Controls.Add(this.uiGroupBox1);
            this.Name = "frmHopDongChuyenVu";
            this.Text = "frmHopDongChuyenVu";
            this.Load += new System.EventHandler(this.frmHopDongChuyenVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).EndInit();
            this.uiGroupBox3.ResumeLayout(false);
            this.uiGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox4)).EndInit();
            this.uiGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.Ribbon.OfficeFormAdorner officeFormAdorner1;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox3;
        private Janus.Windows.EditControls.UIComboBox HopDongUIDCombobox;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox4;
        private Janus.Windows.EditControls.UIButton uiButtonClose;
        private Janus.Windows.EditControls.UIButton btGhiNhan;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox2;
        private Janus.Windows.EditControls.UIComboBox VuTrongUIDCombobox;
        private System.Windows.Forms.Label lbl_HoTen;
    }
}