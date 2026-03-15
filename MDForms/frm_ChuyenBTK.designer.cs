namespace MDSolution.MDForms
{
    partial class frm_ChuyenBTK
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
            Janus.Windows.GridEX.GridEXLayout gdDSBTK_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChuyenBTK));
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnMain = new System.Windows.Forms.Panel();
            this.pnCenter = new System.Windows.Forms.Panel();
            this.grDVTM = new System.Windows.Forms.GroupBox();
            this.gdDSBTK = new Janus.Windows.GridEX.GridEX();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.pnMain.SuspendLayout();
            this.pnCenter.SuspendLayout();
            this.grDVTM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdDSBTK)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(680, 27);
            this.lblTitle.TabIndex = 154;
            this.lblTitle.Text = "LỰA CHỌN BÃI TẬP KẾT";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnMain
            // 
            this.pnMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnMain.Controls.Add(this.pnCenter);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 27);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(680, 324);
            this.pnMain.TabIndex = 155;
            // 
            // pnCenter
            // 
            this.pnCenter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnCenter.Controls.Add(this.grDVTM);
            this.pnCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCenter.Location = new System.Drawing.Point(0, 0);
            this.pnCenter.Name = "pnCenter";
            this.pnCenter.Size = new System.Drawing.Size(676, 320);
            this.pnCenter.TabIndex = 65;
            // 
            // grDVTM
            // 
            this.grDVTM.Controls.Add(this.gdDSBTK);
            this.grDVTM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDVTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grDVTM.ForeColor = System.Drawing.Color.Maroon;
            this.grDVTM.Location = new System.Drawing.Point(0, 0);
            this.grDVTM.Name = "grDVTM";
            this.grDVTM.Size = new System.Drawing.Size(672, 316);
            this.grDVTM.TabIndex = 0;
            this.grDVTM.TabStop = false;
            this.grDVTM.Text = "Danh sách các bãi tập kết";
            // 
            // gdDSBTK
            // 
            this.gdDSBTK.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdDSBTK.AlternatingColors = true;
            this.gdDSBTK.CardColumnHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdDSBTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdDSBTK.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdDSBTK.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdDSBTK.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdDSBTK.Font = new System.Drawing.Font("Arial", 9F);
            this.gdDSBTK.FrozenColumns = 5;
            this.gdDSBTK.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdDSBTK.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdDSBTK.GroupByBoxVisible = false;
            this.gdDSBTK.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdDSBTK.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            gdDSBTK_Layout_0.IsCurrentLayout = true;
            gdDSBTK_Layout_0.Key = "HopDong";
            gdDSBTK_Layout_0.LayoutString = resources.GetString("gdDSBTK_Layout_0.LayoutString");
            this.gdDSBTK.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdDSBTK_Layout_0});
            this.gdDSBTK.Location = new System.Drawing.Point(3, 17);
            this.gdDSBTK.Name = "gdDSBTK";
            this.gdDSBTK.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdDSBTK.NewRowFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gdDSBTK.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSBTK.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdDSBTK.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdDSBTK.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.gdDSBTK.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdDSBTK.RowHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSBTK.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdDSBTK.ScrollBarWidth = 17;
            this.gdDSBTK.SelectedFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdDSBTK.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDSBTK.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDSBTK.Size = new System.Drawing.Size(666, 296);
            this.gdDSBTK.TabIndex = 4;
            this.gdDSBTK.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdDSBTK.UpdateOnLeave = false;
            this.gdDSBTK.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.gdDSBTK_RowDoubleClick);
            this.gdDSBTK.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdDSBTK_ColumnButtonClick);
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.btnCancel);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 351);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(680, 45);
            this.pnBottom.TabIndex = 156;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            this.btnCancel.Location = new System.Drawing.Point(570, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.ToolTipText = "Chi tiết lịch sử thanh toán cho khoản đầu tư được chọn";
            this.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frm_ChuyenBTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(680, 396);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChuyenBTK";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn khách hàng";
            this.Load += new System.EventHandler(this.frm_ChuyenBTK_Load);
            this.pnMain.ResumeLayout(false);
            this.pnCenter.ResumeLayout(false);
            this.grDVTM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdDSBTK)).EndInit();
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
        private Janus.Windows.GridEX.GridEX gdDSBTK;
    }
}