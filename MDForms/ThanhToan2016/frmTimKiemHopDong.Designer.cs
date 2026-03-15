namespace MDSolution.MDForms.ThanhToan2016
{
    partial class frmTimKiemHopDong
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
            Janus.Windows.GridEX.GridEXLayout GridEX1_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimKiemHopDong));
            this.GridEX1 = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.GridEX1)).BeginInit();
            this.SuspendLayout();
            // 
            // GridEX1
            // 
            this.GridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.GridEX1.AlternatingColors = true;
            this.GridEX1.CellToolTip = Janus.Windows.GridEX.CellToolTip.UseHeaderToolTip;
            this.GridEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridEX1.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.GridEX1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.GridEX1.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.GridEX1.Font = new System.Drawing.Font("Arial", 9F);
            this.GridEX1.FrozenColumns = 5;
            this.GridEX1.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.GridEX1.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.GridEX1.GroupByBoxVisible = false;
            this.GridEX1.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            GridEX1_Layout_0.IsCurrentLayout = true;
            GridEX1_Layout_0.Key = "HopDong";
            GridEX1_Layout_0.LayoutString = resources.GetString("GridEX1_Layout_0.LayoutString");
            this.GridEX1.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            GridEX1_Layout_0});
            this.GridEX1.Location = new System.Drawing.Point(0, 0);
            this.GridEX1.Name = "GridEX1";
            this.GridEX1.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GridEX1.NewRowFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.GridEX1.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.GridEX1.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.GridEX1.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.GridEX1.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.GridEX1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.GridEX1.RowHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.GridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.GridEX1.ScrollBarWidth = 17;
            this.GridEX1.SelectedFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.GridEX1.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.GridEX1.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.GridEX1.Size = new System.Drawing.Size(987, 487);
            this.GridEX1.TabIndex = 2;
            this.GridEX1.UpdateOnLeave = false;
            this.GridEX1.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.GridEX1_RowDoubleClick);
            // 
            // frmTimKiemHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 487);
            this.Controls.Add(this.GridEX1);
            this.Name = "frmTimKiemHopDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tìm kiếm";
            this.Load += new System.EventHandler(this.frmTimKiemHopDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridEX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX GridEX1;

    }
}