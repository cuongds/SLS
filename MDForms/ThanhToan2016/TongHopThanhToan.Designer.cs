namespace MDSolution.MDForms.ThanhToan2016
{
    partial class TongHopThanhToan
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
            Janus.Windows.GridEX.GridEXLayout gdChiTietDauTu_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TongHopThanhToan));
            this.gdChiTietDauTu = new Janus.Windows.GridEX.GridEX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdXuatExcel = new Janus.Windows.EditControls.UIButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gdChiTietDauTu)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdChiTietDauTu
            // 
            this.gdChiTietDauTu.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdChiTietDauTu.CellToolTip = Janus.Windows.GridEX.CellToolTip.UseHeaderToolTip;
            this.gdChiTietDauTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdChiTietDauTu.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdChiTietDauTu.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdChiTietDauTu.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gdChiTietDauTu.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdChiTietDauTu.Font = new System.Drawing.Font("Arial", 9.75F);
            this.gdChiTietDauTu.FrozenColumns = -1;
            this.gdChiTietDauTu.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdChiTietDauTu.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdChiTietDauTu.GroupByBoxVisible = false;
            this.gdChiTietDauTu.GroupRowFormatStyle.BackColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gdChiTietDauTu.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdChiTietDauTu.GroupTotalRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gdChiTietDauTu.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            this.gdChiTietDauTu.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            gdChiTietDauTu_Layout_0.IsCurrentLayout = true;
            gdChiTietDauTu_Layout_0.Key = "HopDong";
            gdChiTietDauTu_Layout_0.LayoutString = resources.GetString("gdChiTietDauTu_Layout_0.LayoutString");
            this.gdChiTietDauTu.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdChiTietDauTu_Layout_0});
            this.gdChiTietDauTu.Location = new System.Drawing.Point(0, 0);
            this.gdChiTietDauTu.Margin = new System.Windows.Forms.Padding(4);
            this.gdChiTietDauTu.Name = "gdChiTietDauTu";
            this.gdChiTietDauTu.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdChiTietDauTu.NewRowFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gdChiTietDauTu.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdChiTietDauTu.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdChiTietDauTu.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdChiTietDauTu.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.gdChiTietDauTu.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdChiTietDauTu.RowHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdChiTietDauTu.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdChiTietDauTu.ScrollBarWidth = 17;
            this.gdChiTietDauTu.SelectedFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdChiTietDauTu.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdChiTietDauTu.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdChiTietDauTu.Size = new System.Drawing.Size(1671, 551);
            this.gdChiTietDauTu.TabIndex = 2;
            this.gdChiTietDauTu.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdChiTietDauTu.UpdateOnLeave = false;
            this.gdChiTietDauTu.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.GridEX1_RowDoubleClick);
            this.gdChiTietDauTu.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gdChiTietDauTu_FormattingRow);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gdChiTietDauTu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1671, 551);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdXuatExcel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1671, 48);
            this.panel2.TabIndex = 0;
            // 
            // cmdXuatExcel
            // 
            this.cmdXuatExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdXuatExcel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdXuatExcel.Icon = ((System.Drawing.Icon)(resources.GetObject("cmdXuatExcel.Icon")));
            this.cmdXuatExcel.Image = ((System.Drawing.Image)(resources.GetObject("cmdXuatExcel.Image")));
            this.cmdXuatExcel.Location = new System.Drawing.Point(1533, 4);
            this.cmdXuatExcel.Margin = new System.Windows.Forms.Padding(4);
            this.cmdXuatExcel.Name = "cmdXuatExcel";
            this.cmdXuatExcel.Size = new System.Drawing.Size(133, 41);
            this.cmdXuatExcel.TabIndex = 78;
            this.cmdXuatExcel.Text = "Xuất Excel";
            this.cmdXuatExcel.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdXuatExcel.Click += new System.EventHandler(this.cmdXuatExcel_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = ".xls";
            // 
            // TongHopThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1671, 599);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TongHopThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tìm kiếm";
            this.Load += new System.EventHandler(this.TongHopThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdChiTietDauTu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX gdChiTietDauTu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Janus.Windows.EditControls.UIButton cmdXuatExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;

    }
}