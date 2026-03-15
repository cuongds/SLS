namespace MDSolution.MDDialoge
{
    partial class dlgGiaVanChuyen
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
            Janus.Windows.GridEX.GridEXLayout gdGiaVatTu_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgGiaVanChuyen));
            this.gdGiaVatTu = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.gdGiaVatTu)).BeginInit();
            this.SuspendLayout();
            // 
            // gdGiaVatTu
            // 
            this.gdGiaVatTu.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdGiaVatTu.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdGiaVatTu.AlternatingColors = true;
            this.gdGiaVatTu.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
    "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            this.gdGiaVatTu.ColumnAutoResize = true;
            gdGiaVatTu_DesignTimeLayout.LayoutString = resources.GetString("gdGiaVatTu_DesignTimeLayout.LayoutString");
            this.gdGiaVatTu.DesignTimeLayout = gdGiaVatTu_DesignTimeLayout;
            this.gdGiaVatTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdGiaVatTu.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdGiaVatTu.Font = new System.Drawing.Font("Arial", 12F);
            this.gdGiaVatTu.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdGiaVatTu.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdGiaVatTu.GroupByBoxVisible = false;
            this.gdGiaVatTu.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdGiaVatTu.Location = new System.Drawing.Point(0, 0);
            this.gdGiaVatTu.Name = "gdGiaVatTu";
            this.gdGiaVatTu.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdGiaVatTu.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.gdGiaVatTu.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdGiaVatTu.ScrollBarWidth = 17;
            this.gdGiaVatTu.SelectedFormatStyle.BackColor = System.Drawing.Color.Red;
            this.gdGiaVatTu.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdGiaVatTu.SelectedInactiveFormatStyle.BackColor = System.Drawing.Color.Red;
            this.gdGiaVatTu.Size = new System.Drawing.Size(728, 488);
            this.gdGiaVatTu.TabIndex = 10;
            this.gdGiaVatTu.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.gdVHopDongVanChuyen_RowDoubleClick);
            this.gdGiaVatTu.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gdVHopDongVanChuyen_FormattingRow);
            this.gdGiaVatTu.RecordUpdated += new System.EventHandler(this.gdGiaVatTu_RecordUpdated);
            this.gdGiaVatTu.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gdGiaVatTu_AddingRecord);
            // 
            // dlgGiaVanChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 488);
            this.Controls.Add(this.gdGiaVatTu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgGiaVanChuyen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phần trăm giá vận chuyển";
            ((System.ComponentModel.ISupportInitialize)(this.gdGiaVatTu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gdGiaVatTu;
    }
}