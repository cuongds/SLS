namespace MDSolution.MDForms.ThuHoach
{
    partial class frm_ChonUuTien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChonUuTien));
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnCenter = new System.Windows.Forms.Panel();
            this.grCBDB = new Janus.Windows.EditControls.UIGroupBox();
            this.lblLenh = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLoaiUuTien = new Janus.Windows.EditControls.UIComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pnTop = new System.Windows.Forms.Panel();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.cmdLuu = new Janus.Windows.EditControls.UIButton();
            this.cmdClose = new Janus.Windows.EditControls.UIButton();
            this.pnCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grCBDB)).BeginInit();
            this.grCBDB.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.pnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(396, 28);
            this.lblTitle.TabIndex = 55;
            this.lblTitle.Text = "CHỌN ƯU TIÊN CHO LỆNH";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnCenter
            // 
            this.pnCenter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnCenter.Controls.Add(this.grCBDB);
            this.pnCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCenter.Location = new System.Drawing.Point(0, 28);
            this.pnCenter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnCenter.Name = "pnCenter";
            this.pnCenter.Size = new System.Drawing.Size(396, 162);
            this.pnCenter.TabIndex = 56;
            // 
            // grCBDB
            // 
            this.grCBDB.Controls.Add(this.lblLenh);
            this.grCBDB.Controls.Add(this.label1);
            this.grCBDB.Controls.Add(this.cboLoaiUuTien);
            this.grCBDB.Controls.Add(this.label14);
            this.grCBDB.Controls.Add(this.label10);
            this.grCBDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grCBDB.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grCBDB.ForeColor = System.Drawing.Color.Purple;
            this.grCBDB.Location = new System.Drawing.Point(0, 0);
            this.grCBDB.Name = "grCBDB";
            this.grCBDB.Size = new System.Drawing.Size(392, 158);
            this.grCBDB.TabIndex = 10;
            this.grCBDB.Text = "Lựa chọn và thiết lập";
            this.grCBDB.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.grCBDB.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.VS2005;
            // 
            // lblLenh
            // 
            this.lblLenh.AutoSize = true;
            this.lblLenh.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLenh.ForeColor = System.Drawing.Color.Maroon;
            this.lblLenh.Location = new System.Drawing.Point(120, 52);
            this.lblLenh.Name = "lblLenh";
            this.lblLenh.Size = new System.Drawing.Size(57, 24);
            this.lblLenh.TabIndex = 49;
            this.lblLenh.Text = "Lenh";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(39, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "Số lệnh:";
            // 
            // cboLoaiUuTien
            // 
            this.cboLoaiUuTien.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboLoaiUuTien.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiUuTien.ForeColor = System.Drawing.Color.Black;
            this.cboLoaiUuTien.Location = new System.Drawing.Point(120, 91);
            this.cboLoaiUuTien.Name = "cboLoaiUuTien";
            this.cboLoaiUuTien.Size = new System.Drawing.Size(240, 30);
            this.cboLoaiUuTien.TabIndex = 45;
            this.cboLoaiUuTien.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(27, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 17);
            this.label14.TabIndex = 46;
            this.label14.Text = "Loại ưu tiên :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1077, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 22);
            this.label10.TabIndex = 26;
            this.label10.Text = "Kg";
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lblTitle);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(396, 28);
            this.pnTop.TabIndex = 3068;
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.cmdLuu);
            this.pnBottom.Controls.Add(this.cmdClose);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 190);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(396, 41);
            this.pnBottom.TabIndex = 3068;
            // 
            // cmdLuu
            // 
            this.cmdLuu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdLuu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLuu.Image = global::MDSolution.Properties.Resources.ok;
            this.cmdLuu.Location = new System.Drawing.Point(22, 6);
            this.cmdLuu.Name = "cmdLuu";
            this.cmdLuu.Size = new System.Drawing.Size(90, 30);
            this.cmdLuu.TabIndex = 41;
            this.cmdLuu.Text = "Chọn";
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
            this.cmdClose.Location = new System.Drawing.Point(287, 6);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(90, 30);
            this.cmdClose.TabIndex = 42;
            this.cmdClose.Text = "Đóng";
            this.cmdClose.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frm_ChonUuTien
            // 
            this.AcceptButton = this.cmdLuu;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(396, 231);
            this.Controls.Add(this.pnCenter);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.pnTop);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChonUuTien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn chế độ ưu tiên";
            this.pnCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grCBDB)).EndInit();
            this.grCBDB.ResumeLayout(false);
            this.grCBDB.PerformLayout();
            this.pnTop.ResumeLayout(false);
            this.pnBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnCenter;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel pnBottom;
        private Janus.Windows.EditControls.UIButton cmdLuu;
        private Janus.Windows.EditControls.UIButton cmdClose;
        private Janus.Windows.EditControls.UIGroupBox grCBDB;
        private System.Windows.Forms.Label label10;
        private Janus.Windows.EditControls.UIComboBox cboLoaiUuTien;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblLenh;
        private System.Windows.Forms.Label label1;
    }
}