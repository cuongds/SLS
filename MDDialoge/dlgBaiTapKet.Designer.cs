namespace MDSolution
{
    partial class dlgBaiTapKet
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
            Janus.Windows.GridEX.GridEXLayout gdBaiTapKet_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgBaiTapKet));
            this.gdBaiTapKet = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.gdBaiTapKet)).BeginInit();
            this.SuspendLayout();
            // 
            // gdBaiTapKet
            // 
            this.gdBaiTapKet.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdBaiTapKet.AlternatingColors = true;
            this.gdBaiTapKet.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
    "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            this.gdBaiTapKet.ColumnAutoResize = true;
            gdBaiTapKet_DesignTimeLayout.LayoutString = resources.GetString("gdBaiTapKet_DesignTimeLayout.LayoutString");
            this.gdBaiTapKet.DesignTimeLayout = gdBaiTapKet_DesignTimeLayout;
            this.gdBaiTapKet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdBaiTapKet.DynamicFiltering = true;
            this.gdBaiTapKet.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdBaiTapKet.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdBaiTapKet.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gdBaiTapKet.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdBaiTapKet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdBaiTapKet.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdBaiTapKet.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdBaiTapKet.GroupByBoxVisible = false;
            this.gdBaiTapKet.Location = new System.Drawing.Point(0, 0);
            this.gdBaiTapKet.Name = "gdBaiTapKet";
            this.gdBaiTapKet.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.gdBaiTapKet.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdBaiTapKet.ScrollBarWidth = 17;
            this.gdBaiTapKet.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gdBaiTapKet.SelectedFormatStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdBaiTapKet.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdBaiTapKet.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdBaiTapKet.SelectedInactiveFormatStyle.BackColor = System.Drawing.Color.Red;
            this.gdBaiTapKet.Size = new System.Drawing.Size(1140, 400);
            this.gdBaiTapKet.TabIndex = 10;
            this.gdBaiTapKet.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.gdVHopDongVanChuyen_RowDoubleClick);
            this.gdBaiTapKet.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gdVHopDongVanChuyen_FormattingRow);
            this.gdBaiTapKet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gdVHopDongVanChuyen_KeyDown);
            // 
            // dlgBaiTapKet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 400);
            this.Controls.Add(this.gdBaiTapKet);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgBaiTapKet";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn bãi tập kết";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dlgBaiTapKet_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gdBaiTapKet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gdBaiTapKet;
    }
}