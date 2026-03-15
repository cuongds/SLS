namespace MDSolution.MDForms.DauTu
{
    partial class frmDauTuLog
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
            Janus.Windows.GridEX.GridEXLayout gdHopDongLog_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDauTuLog));
            Janus.Windows.GridEX.GridEXLayout gdHopDongLog_Layout_1 = new Janus.Windows.GridEX.GridEXLayout();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdexcel = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDaXem = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gdHopDongLog = new Janus.Windows.GridEX.GridEX();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdHopDongLog)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdexcel);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnDaXem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1332, 48);
            this.panel1.TabIndex = 0;
            // 
            // cmdexcel
            // 
            this.cmdexcel.Location = new System.Drawing.Point(1099, 4);
            this.cmdexcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdexcel.Name = "cmdexcel";
            this.cmdexcel.Size = new System.Drawing.Size(100, 28);
            this.cmdexcel.TabIndex = 36;
            this.cmdexcel.Text = "Xuất excel";
            this.cmdexcel.UseVisualStyleBackColor = true;
            this.cmdexcel.Click += new System.EventHandler(this.cmdexcel_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1228, 4);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 35;
            this.button2.Text = "Đóng";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDaXem
            // 
            this.btnDaXem.Location = new System.Drawing.Point(4, 4);
            this.btnDaXem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDaXem.Name = "btnDaXem";
            this.btnDaXem.Size = new System.Drawing.Size(232, 28);
            this.btnDaXem.TabIndex = 35;
            this.btnDaXem.Text = "Đã xem, không hiển thị lại";
            this.btnDaXem.UseVisualStyleBackColor = true;
            this.btnDaXem.Visible = false;
            this.btnDaXem.Click += new System.EventHandler(this.btnDaXem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gdHopDongLog);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 48);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1332, 615);
            this.panel2.TabIndex = 0;
            // 
            // gdHopDongLog
            // 
            this.gdHopDongLog.AllowColumnDrag = false;
            this.gdHopDongLog.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdHopDongLog.AlternatingColors = true;
            this.gdHopDongLog.AutoEdit = true;
            this.gdHopDongLog.AutomaticSort = false;
            this.gdHopDongLog.BorderStyle = Janus.Windows.GridEX.BorderStyle.RaisedLight3D;
            this.gdHopDongLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.gdHopDongLog.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdHopDongLog.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdHopDongLog.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gdHopDongLog.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdHopDongLog.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdHopDongLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdHopDongLog.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdHopDongLog.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdHopDongLog.GroupByBoxVisible = false;
            this.gdHopDongLog.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdHopDongLog.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdHopDongLog.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            gdHopDongLog_Layout_0.Key = "ex";
            gdHopDongLog_Layout_0.LayoutString = resources.GetString("gdHopDongLog_Layout_0.LayoutString");
            gdHopDongLog_Layout_1.IsCurrentLayout = true;
            gdHopDongLog_Layout_1.Key = "CopyOfex";
            gdHopDongLog_Layout_1.LayoutString = resources.GetString("gdHopDongLog_Layout_1.LayoutString");
            this.gdHopDongLog.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdHopDongLog_Layout_0,
            gdHopDongLog_Layout_1});
            this.gdHopDongLog.LinkFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdHopDongLog.Location = new System.Drawing.Point(0, 0);
            this.gdHopDongLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gdHopDongLog.Name = "gdHopDongLog";
            this.gdHopDongLog.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdHopDongLog.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdHopDongLog.PreviewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.gdHopDongLog.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdHopDongLog.RowFormatStyle.Font = new System.Drawing.Font("Arial", 9F);
            this.gdHopDongLog.RowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.gdHopDongLog.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdHopDongLog.RowHeaderFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdHopDongLog.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both;
            this.gdHopDongLog.SelectedFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdHopDongLog.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdHopDongLog.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdHopDongLog.Size = new System.Drawing.Size(1329, 615);
            this.gdHopDongLog.TabIndex = 33;
            this.gdHopDongLog.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdHopDongLog.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdHopDongLog.UpdateOnLeave = false;
            this.gdHopDongLog.SelectionChanged += new System.EventHandler(this.gdHopDongLog_SelectionChanged);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "\"Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            // 
            // frmDauTuLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 663);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDauTuLog";
            this.Text = "Thông tin xóa đầu tư";
            this.Load += new System.EventHandler(this.frmDauTuLog_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdHopDongLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDaXem;
        private System.Windows.Forms.Panel panel2;
        public Janus.Windows.GridEX.GridEX gdHopDongLog;
        private System.Windows.Forms.Button cmdexcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}