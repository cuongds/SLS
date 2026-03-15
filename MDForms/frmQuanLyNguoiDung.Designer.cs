namespace MDSolution
{
    partial class frmQuanLyNguoiDung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyNguoiDung));
            Janus.Windows.GridEX.GridEXLayout gdVUser_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.gdVUser = new Janus.Windows.GridEX.GridEX();
            this.grPhanQuyen = new System.Windows.Forms.GroupBox();
            this.chk_DanhMuc = new System.Windows.Forms.CheckBox();
            this.chk_QuanTriHeThong = new System.Windows.Forms.CheckBox();
            this.chk_QuanLyVanChuyen = new System.Windows.Forms.CheckBox();
            this.chkThanhToanHuy = new System.Windows.Forms.CheckBox();
            this.chkThanhtoanXacNhan = new System.Windows.Forms.CheckBox();
            this.chk_ThanhToan = new System.Windows.Forms.CheckBox();
            this.chk_TheoDoiNhapMia = new System.Windows.Forms.CheckBox();
            this.chk_QuanLyDauTu = new System.Windows.Forms.CheckBox();
            this.chk_QuanLyDienTich = new System.Windows.Forms.CheckBox();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.cmdClose = new Janus.Windows.EditControls.UIButton();
            this.btGhiNhan = new Janus.Windows.EditControls.UIButton();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnPhanQuyen = new System.Windows.Forms.Panel();
            this.pnData = new System.Windows.Forms.Panel();
            this.grDSUser = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gdVUser)).BeginInit();
            this.grPhanQuyen.SuspendLayout();
            this.pnBottom.SuspendLayout();
            this.pnTitle.SuspendLayout();
            this.pnPhanQuyen.SuspendLayout();
            this.pnData.SuspendLayout();
            this.grDSUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdVUser
            // 
            this.gdVUser.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVUser.AutoEdit = true;
            resources.ApplyResources(this.gdVUser, "gdVUser");
            this.gdVUser.ColumnAutoResize = true;
            resources.ApplyResources(gdVUser_DesignTimeLayout, "gdVUser_DesignTimeLayout");
            this.gdVUser.DesignTimeLayout = gdVUser_DesignTimeLayout;
            this.gdVUser.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdVUser.GridLineColor = System.Drawing.SystemColors.ControlLightLight;
            this.gdVUser.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVUser.GroupByBoxVisible = false;
            this.gdVUser.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVUser.HeaderFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVUser.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdVUser.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdVUser.Name = "gdVUser";
            this.gdVUser.NewRowFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Flat;
            this.gdVUser.NewRowFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdVUser.NewRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Solid;
            this.gdVUser.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVUser.NewRowFormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.gdVUser.NewRowFormatStyle.ImageHorizontalAlignment = Janus.Windows.GridEX.ImageHorizontalAlignment.Center;
            this.gdVUser.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdVUser.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVUser.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdVUser.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVUser.ScrollBarWidth = 17;
            this.gdVUser.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVUser.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVUser.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdVUser.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.gdVUser_DeletingRecord);
            this.gdVUser.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gdVUser_UpdatingRecord);
            this.gdVUser.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gdVUser_AddingRecord);
            this.gdVUser.SelectionChanged += new System.EventHandler(this.gdVUser_SelectionChanged);
            // 
            // grPhanQuyen
            // 
            this.grPhanQuyen.Controls.Add(this.chk_DanhMuc);
            this.grPhanQuyen.Controls.Add(this.chk_QuanTriHeThong);
            this.grPhanQuyen.Controls.Add(this.chk_QuanLyVanChuyen);
            this.grPhanQuyen.Controls.Add(this.chkThanhToanHuy);
            this.grPhanQuyen.Controls.Add(this.chkThanhtoanXacNhan);
            this.grPhanQuyen.Controls.Add(this.chk_ThanhToan);
            this.grPhanQuyen.Controls.Add(this.chk_TheoDoiNhapMia);
            this.grPhanQuyen.Controls.Add(this.chk_QuanLyDauTu);
            this.grPhanQuyen.Controls.Add(this.chk_QuanLyDienTich);
            resources.ApplyResources(this.grPhanQuyen, "grPhanQuyen");
            this.grPhanQuyen.ForeColor = System.Drawing.Color.Maroon;
            this.grPhanQuyen.Name = "grPhanQuyen";
            this.grPhanQuyen.TabStop = false;
            // 
            // chk_DanhMuc
            // 
            resources.ApplyResources(this.chk_DanhMuc, "chk_DanhMuc");
            this.chk_DanhMuc.ForeColor = System.Drawing.Color.Black;
            this.chk_DanhMuc.Name = "chk_DanhMuc";
            this.chk_DanhMuc.UseVisualStyleBackColor = true;
            // 
            // chk_QuanTriHeThong
            // 
            resources.ApplyResources(this.chk_QuanTriHeThong, "chk_QuanTriHeThong");
            this.chk_QuanTriHeThong.ForeColor = System.Drawing.Color.Black;
            this.chk_QuanTriHeThong.Name = "chk_QuanTriHeThong";
            this.chk_QuanTriHeThong.UseVisualStyleBackColor = true;
            // 
            // chk_QuanLyVanChuyen
            // 
            resources.ApplyResources(this.chk_QuanLyVanChuyen, "chk_QuanLyVanChuyen");
            this.chk_QuanLyVanChuyen.ForeColor = System.Drawing.Color.Black;
            this.chk_QuanLyVanChuyen.Name = "chk_QuanLyVanChuyen";
            this.chk_QuanLyVanChuyen.UseVisualStyleBackColor = true;
            // 
            // chkThanhToanHuy
            // 
            resources.ApplyResources(this.chkThanhToanHuy, "chkThanhToanHuy");
            this.chkThanhToanHuy.ForeColor = System.Drawing.Color.Black;
            this.chkThanhToanHuy.Name = "chkThanhToanHuy";
            this.chkThanhToanHuy.UseVisualStyleBackColor = true;
            // 
            // chkThanhtoanXacNhan
            // 
            resources.ApplyResources(this.chkThanhtoanXacNhan, "chkThanhtoanXacNhan");
            this.chkThanhtoanXacNhan.ForeColor = System.Drawing.Color.Black;
            this.chkThanhtoanXacNhan.Name = "chkThanhtoanXacNhan";
            this.chkThanhtoanXacNhan.UseVisualStyleBackColor = true;
            // 
            // chk_ThanhToan
            // 
            resources.ApplyResources(this.chk_ThanhToan, "chk_ThanhToan");
            this.chk_ThanhToan.ForeColor = System.Drawing.Color.Black;
            this.chk_ThanhToan.Name = "chk_ThanhToan";
            this.chk_ThanhToan.UseVisualStyleBackColor = true;
            // 
            // chk_TheoDoiNhapMia
            // 
            resources.ApplyResources(this.chk_TheoDoiNhapMia, "chk_TheoDoiNhapMia");
            this.chk_TheoDoiNhapMia.ForeColor = System.Drawing.Color.Black;
            this.chk_TheoDoiNhapMia.Name = "chk_TheoDoiNhapMia";
            this.chk_TheoDoiNhapMia.UseVisualStyleBackColor = true;
            // 
            // chk_QuanLyDauTu
            // 
            resources.ApplyResources(this.chk_QuanLyDauTu, "chk_QuanLyDauTu");
            this.chk_QuanLyDauTu.ForeColor = System.Drawing.Color.Black;
            this.chk_QuanLyDauTu.Name = "chk_QuanLyDauTu";
            this.chk_QuanLyDauTu.UseVisualStyleBackColor = true;
            // 
            // chk_QuanLyDienTich
            // 
            resources.ApplyResources(this.chk_QuanLyDienTich, "chk_QuanLyDienTich");
            this.chk_QuanLyDienTich.ForeColor = System.Drawing.Color.Black;
            this.chk_QuanLyDienTich.Name = "chk_QuanLyDienTich";
            this.chk_QuanLyDienTich.UseVisualStyleBackColor = true;
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.cmdClose);
            this.pnBottom.Controls.Add(this.btGhiNhan);
            resources.ApplyResources(this.pnBottom, "pnBottom");
            this.pnBottom.Name = "pnBottom";
            // 
            // cmdClose
            // 
            resources.ApplyResources(this.cmdClose, "cmdClose");
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // btGhiNhan
            // 
            resources.ApplyResources(this.btGhiNhan, "btGhiNhan");
            this.btGhiNhan.Icon = ((System.Drawing.Icon)(resources.GetObject("btGhiNhan.Icon")));
            this.btGhiNhan.Image = global::MDSolution.Properties.Resources.end;
            this.btGhiNhan.Name = "btGhiNhan";
            this.btGhiNhan.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.btGhiNhan.Click += new System.EventHandler(this.btGhiNhan_Click);
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.lblTitle);
            resources.ApplyResources(this.pnTitle, "pnTitle");
            this.pnTitle.Name = "pnTitle";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Name = "lblTitle";
            // 
            // pnPhanQuyen
            // 
            this.pnPhanQuyen.Controls.Add(this.grPhanQuyen);
            resources.ApplyResources(this.pnPhanQuyen, "pnPhanQuyen");
            this.pnPhanQuyen.Name = "pnPhanQuyen";
            // 
            // pnData
            // 
            this.pnData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnData.Controls.Add(this.grDSUser);
            resources.ApplyResources(this.pnData, "pnData");
            this.pnData.Name = "pnData";
            // 
            // grDSUser
            // 
            this.grDSUser.Controls.Add(this.gdVUser);
            resources.ApplyResources(this.grDSUser, "grDSUser");
            this.grDSUser.ForeColor = System.Drawing.Color.Maroon;
            this.grDSUser.Name = "grDSUser";
            this.grDSUser.TabStop = false;
            // 
            // frmQuanLyNguoiDung
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnData);
            this.Controls.Add(this.pnPhanQuyen);
            this.Controls.Add(this.pnTitle);
            this.Controls.Add(this.pnBottom);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuanLyNguoiDung";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmQuanLyNguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdVUser)).EndInit();
            this.grPhanQuyen.ResumeLayout(false);
            this.grPhanQuyen.PerformLayout();
            this.pnBottom.ResumeLayout(false);
            this.pnTitle.ResumeLayout(false);
            this.pnPhanQuyen.ResumeLayout(false);
            this.pnData.ResumeLayout(false);
            this.grDSUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gdVUser;
        private System.Windows.Forms.GroupBox grPhanQuyen;
        private System.Windows.Forms.CheckBox chk_QuanLyDienTich;
        private System.Windows.Forms.CheckBox chk_TheoDoiNhapMia;
        private System.Windows.Forms.CheckBox chk_QuanLyDauTu;
        private System.Windows.Forms.CheckBox chk_QuanLyVanChuyen;
        private System.Windows.Forms.CheckBox chk_ThanhToan;
        private System.Windows.Forms.CheckBox chk_QuanTriHeThong;
        private System.Windows.Forms.CheckBox chkThanhToanHuy;
        private System.Windows.Forms.CheckBox chkThanhtoanXacNhan;
        private System.Windows.Forms.CheckBox chk_DanhMuc;
        private System.Windows.Forms.Panel pnBottom;
        private Janus.Windows.EditControls.UIButton cmdClose;
        private Janus.Windows.EditControls.UIButton btGhiNhan;
        private System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnPhanQuyen;
        private System.Windows.Forms.Panel pnData;
        private System.Windows.Forms.GroupBox grDSUser;
        //private CrystalReport1 CrystalReport11;
        //private CrystalReport1 CrystalReport12;
        //private CrystalReport1 CrystalReport13;
        //private CrystalReport1 CrystalReport14;
        //private CrystalReport1 CrystalReport15;
    }
}