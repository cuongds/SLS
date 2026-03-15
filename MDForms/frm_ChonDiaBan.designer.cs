namespace MDSolution.MDForms
{
    partial class frm_ChonDiaBan
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
            Janus.Windows.GridEX.GridEXLayout gdDiaBan_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChonDiaBan));
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnMain = new System.Windows.Forms.Panel();
            this.pnCenter = new System.Windows.Forms.Panel();
            this.grDVTM = new System.Windows.Forms.GroupBox();
            this.gdDiaBan = new Janus.Windows.GridEX.GridEX();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.pnMain.SuspendLayout();
            this.pnCenter.SuspendLayout();
            this.grDVTM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdDiaBan)).BeginInit();
            this.pnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(734, 28);
            this.lblTitle.TabIndex = 154;
            this.lblTitle.Text = "LỰA CHỌN ĐỊA BÀN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnMain
            // 
            this.pnMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnMain.Controls.Add(this.pnCenter);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 28);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(734, 323);
            this.pnMain.TabIndex = 155;
            // 
            // pnCenter
            // 
            this.pnCenter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnCenter.Controls.Add(this.grDVTM);
            this.pnCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCenter.Location = new System.Drawing.Point(0, 0);
            this.pnCenter.Name = "pnCenter";
            this.pnCenter.Size = new System.Drawing.Size(730, 319);
            this.pnCenter.TabIndex = 65;
            // 
            // grDVTM
            // 
            this.grDVTM.Controls.Add(this.gdDiaBan);
            this.grDVTM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDVTM.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grDVTM.ForeColor = System.Drawing.Color.Maroon;
            this.grDVTM.Location = new System.Drawing.Point(0, 0);
            this.grDVTM.Name = "grDVTM";
            this.grDVTM.Size = new System.Drawing.Size(726, 315);
            this.grDVTM.TabIndex = 0;
            this.grDVTM.TabStop = false;
            this.grDVTM.Text = "Danh sách Địa bàn";
            // 
            // gdDiaBan
            // 
            this.gdDiaBan.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdDiaBan.AlternatingColors = true;
            this.gdDiaBan.CardColumnHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdDiaBan.CellToolTip = Janus.Windows.GridEX.CellToolTip.UseHeaderToolTip;
            this.gdDiaBan.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            this.gdDiaBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdDiaBan.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdDiaBan.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdDiaBan.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdDiaBan.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdDiaBan.Font = new System.Drawing.Font("Arial", 9F);
            this.gdDiaBan.FrozenColumns = 5;
            this.gdDiaBan.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdDiaBan.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdDiaBan.GroupByBoxVisible = false;
            this.gdDiaBan.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdDiaBan.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            gdDiaBan_Layout_0.IsCurrentLayout = true;
            gdDiaBan_Layout_0.Key = "HopDong";
            gdDiaBan_Layout_0.LayoutString = resources.GetString("gdDiaBan_Layout_0.LayoutString");
            this.gdDiaBan.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdDiaBan_Layout_0});
            this.gdDiaBan.Location = new System.Drawing.Point(3, 18);
            this.gdDiaBan.Name = "gdDiaBan";
            this.gdDiaBan.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdDiaBan.NewRowFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gdDiaBan.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDiaBan.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdDiaBan.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdDiaBan.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.gdDiaBan.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdDiaBan.RowHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDiaBan.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdDiaBan.ScrollBarWidth = 17;
            this.gdDiaBan.SelectedFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdDiaBan.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdDiaBan.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdDiaBan.Size = new System.Drawing.Size(720, 294);
            this.gdDiaBan.TabIndex = 3;
            this.gdDiaBan.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdDiaBan.UpdateOnLeave = false;
            this.gdDiaBan.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdDiaBan_ColumnButtonClick);
            this.gdDiaBan.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gdDiaBan_MouseDoubleClick);
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.btnCancel);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 351);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(734, 45);
            this.pnBottom.TabIndex = 156;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            this.btnCancel.Location = new System.Drawing.Point(629, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frm_ChonDiaBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(734, 396);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChonDiaBan";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Địa bàn";
            this.Load += new System.EventHandler(this.frm_ChonDiaBan_Load);
            this.pnMain.ResumeLayout(false);
            this.pnCenter.ResumeLayout(false);
            this.grDVTM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdDiaBan)).EndInit();
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
        private Janus.Windows.GridEX.GridEX gdDiaBan;
    }
}