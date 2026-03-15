namespace MDSolution.MDForms
{
    partial class frm_ChuyenDoiKHVC
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
            Janus.Windows.GridEX.GridEXLayout gdHDVC_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChuyenDoiKHVC));
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnMain = new System.Windows.Forms.Panel();
            this.pnCenter = new System.Windows.Forms.Panel();
            this.grDVTM = new System.Windows.Forms.GroupBox();
            this.gdHDVC = new Janus.Windows.GridEX.GridEX();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.pnMain.SuspendLayout();
            this.pnCenter.SuspendLayout();
            this.grDVTM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdHDVC)).BeginInit();
            this.pnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(692, 27);
            this.lblTitle.TabIndex = 154;
            this.lblTitle.Text = "LỰA CHỌN HỢP ĐỒNG VẬN CHUYỂN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnMain
            // 
            this.pnMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnMain.Controls.Add(this.pnCenter);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 27);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(692, 324);
            this.pnMain.TabIndex = 155;
            // 
            // pnCenter
            // 
            this.pnCenter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnCenter.Controls.Add(this.grDVTM);
            this.pnCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCenter.Location = new System.Drawing.Point(0, 0);
            this.pnCenter.Name = "pnCenter";
            this.pnCenter.Size = new System.Drawing.Size(688, 320);
            this.pnCenter.TabIndex = 65;
            // 
            // grDVTM
            // 
            this.grDVTM.Controls.Add(this.gdHDVC);
            this.grDVTM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDVTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grDVTM.ForeColor = System.Drawing.Color.Maroon;
            this.grDVTM.Location = new System.Drawing.Point(0, 0);
            this.grDVTM.Name = "grDVTM";
            this.grDVTM.Size = new System.Drawing.Size(684, 316);
            this.grDVTM.TabIndex = 0;
            this.grDVTM.TabStop = false;
            this.grDVTM.Text = "Danh sách khách hàng";
            // 
            // gdHDVC
            // 
            this.gdHDVC.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdHDVC.AlternatingColors = true;
            this.gdHDVC.CardColumnHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdHDVC.CellToolTip = Janus.Windows.GridEX.CellToolTip.UseHeaderToolTip;
            this.gdHDVC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdHDVC.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdHDVC.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdHDVC.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdHDVC.Font = new System.Drawing.Font("Arial", 9F);
            this.gdHDVC.FrozenColumns = 5;
            this.gdHDVC.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdHDVC.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdHDVC.GroupByBoxVisible = false;
            this.gdHDVC.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdHDVC.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            gdHDVC_Layout_0.IsCurrentLayout = true;
            gdHDVC_Layout_0.Key = "HopDong";
            gdHDVC_Layout_0.LayoutString = resources.GetString("gdHDVC_Layout_0.LayoutString");
            this.gdHDVC.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdHDVC_Layout_0});
            this.gdHDVC.Location = new System.Drawing.Point(3, 17);
            this.gdHDVC.Name = "gdHDVC";
            this.gdHDVC.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdHDVC.NewRowFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gdHDVC.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdHDVC.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdHDVC.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdHDVC.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.gdHDVC.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdHDVC.RowHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdHDVC.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdHDVC.ScrollBarWidth = 17;
            this.gdHDVC.SelectedFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdHDVC.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdHDVC.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdHDVC.Size = new System.Drawing.Size(678, 296);
            this.gdHDVC.TabIndex = 3;
            this.gdHDVC.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdHDVC.UpdateOnLeave = false;
            this.gdHDVC.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.gdCHD_RowDoubleClick);
            this.gdHDVC.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdHoCon_ColumnButtonClick);
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.btnCancel);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 351);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(692, 45);
            this.pnBottom.TabIndex = 156;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            this.btnCancel.Location = new System.Drawing.Point(555, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.ToolTipText = "Chi tiết lịch sử thanh toán cho khoản đầu tư được chọn";
            this.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frm_ChuyenDoiKHVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(692, 396);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChuyenDoiKHVC";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn khách hàng";
            this.Load += new System.EventHandler(this.frm_Them_CHD_HoCon_Load);
            this.pnMain.ResumeLayout(false);
            this.pnCenter.ResumeLayout(false);
            this.grDVTM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdHDVC)).EndInit();
            this.pnBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIButton btnCancel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Panel pnCenter;
        private System.Windows.Forms.GroupBox grDVTM;
        private System.Windows.Forms.Panel pnBottom;
        private Janus.Windows.GridEX.GridEX gdHDVC;
    }
}