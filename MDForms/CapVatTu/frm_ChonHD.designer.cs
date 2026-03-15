namespace MDSolution.MDForms.CapVatTu
{
    partial class frm_ChonHD
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
            Janus.Windows.GridEX.GridEXLayout gdHD_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChonHD));
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnMain = new System.Windows.Forms.Panel();
            this.pnCenter = new System.Windows.Forms.Panel();
            this.grDVTM = new System.Windows.Forms.GroupBox();
            this.gdHD = new Janus.Windows.GridEX.GridEX();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.pnMain.SuspendLayout();
            this.pnCenter.SuspendLayout();
            this.grDVTM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdHD)).BeginInit();
            this.pnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1018, 28);
            this.lblTitle.TabIndex = 154;
            this.lblTitle.Text = "LỰA CHỌN NÔNG HỘ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnMain
            // 
            this.pnMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnMain.Controls.Add(this.pnCenter);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 28);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1018, 376);
            this.pnMain.TabIndex = 155;
            // 
            // pnCenter
            // 
            this.pnCenter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnCenter.Controls.Add(this.grDVTM);
            this.pnCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCenter.Location = new System.Drawing.Point(0, 0);
            this.pnCenter.Name = "pnCenter";
            this.pnCenter.Size = new System.Drawing.Size(1014, 372);
            this.pnCenter.TabIndex = 65;
            // 
            // grDVTM
            // 
            this.grDVTM.Controls.Add(this.gdHD);
            this.grDVTM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDVTM.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grDVTM.ForeColor = System.Drawing.Color.Maroon;
            this.grDVTM.Location = new System.Drawing.Point(0, 0);
            this.grDVTM.Name = "grDVTM";
            this.grDVTM.Size = new System.Drawing.Size(1010, 368);
            this.grDVTM.TabIndex = 0;
            this.grDVTM.TabStop = false;
            this.grDVTM.Text = "Danh sách nông hộ";
            // 
            // gdHD
            // 
            this.gdHD.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdHD.AlternatingColors = true;
            this.gdHD.CardColumnHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdHD.CellToolTip = Janus.Windows.GridEX.CellToolTip.UseHeaderToolTip;
            this.gdHD.ColumnAutoResize = true;
            this.gdHD.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            this.gdHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdHD.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdHD.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdHD.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdHD.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdHD.Font = new System.Drawing.Font("Arial", 9F);
            this.gdHD.FrozenColumns = 5;
            this.gdHD.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdHD.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdHD.GroupByBoxVisible = false;
            this.gdHD.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdHD.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            gdHD_Layout_0.IsCurrentLayout = true;
            gdHD_Layout_0.Key = "HopDong";
            gdHD_Layout_0.LayoutString = resources.GetString("gdHD_Layout_0.LayoutString");
            this.gdHD.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdHD_Layout_0});
            this.gdHD.Location = new System.Drawing.Point(3, 18);
            this.gdHD.Name = "gdHD";
            this.gdHD.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdHD.NewRowFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gdHD.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdHD.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdHD.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdHD.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.gdHD.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdHD.RowHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdHD.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdHD.ScrollBarWidth = 17;
            this.gdHD.SelectedFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdHD.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdHD.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdHD.Size = new System.Drawing.Size(1004, 347);
            this.gdHD.TabIndex = 3;
            this.gdHD.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdHD.UpdateOnLeave = false;
            this.gdHD.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdDiaBan_ColumnButtonClick);
            this.gdHD.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gdDiaBan_MouseDoubleClick);
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.btnCancel);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 404);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(1018, 40);
            this.pnBottom.TabIndex = 156;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(899, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frm_ChonHD
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1018, 444);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChonHD";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Địa bàn";
            this.pnMain.ResumeLayout(false);
            this.pnCenter.ResumeLayout(false);
            this.grDVTM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdHD)).EndInit();
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
        private Janus.Windows.GridEX.GridEX gdHD;
    }
}