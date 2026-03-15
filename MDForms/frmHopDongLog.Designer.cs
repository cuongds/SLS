namespace MDSolution.MDForms
{
    partial class frmHopDongLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHopDongLog));
            Janus.Windows.GridEX.GridEXLayout gdHopDongLog_Layout_1 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grvDSTK_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grvDSTK_Layout_1 = new Janus.Windows.GridEX.GridEXLayout();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDaXem = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabTheoDoiSanLuong = new Janus.Windows.UI.Tab.UITab();
            this.tabTheoKeHoach = new Janus.Windows.UI.Tab.UITabPage();
            this.pnMother = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ribNoiDung = new System.Windows.Forms.RichTextBox();
            this.gdHopDongLog = new Janus.Windows.GridEX.GridEX();
            this.tabTaiKhoan = new Janus.Windows.UI.Tab.UITabPage();
            this.pnSLToanVung = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.grvDSTK = new Janus.Windows.GridEX.GridEX();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmd2ExcelTheoKH = new Janus.Windows.EditControls.UIButton();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabTheoDoiSanLuong)).BeginInit();
            this.tabTheoDoiSanLuong.SuspendLayout();
            this.tabTheoKeHoach.SuspendLayout();
            this.pnMother.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdHopDongLog)).BeginInit();
            this.tabTaiKhoan.SuspendLayout();
            this.pnSLToanVung.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDSTK)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDaXem);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1362, 54);
            this.panel1.TabIndex = 0;
            // 
            // btnDaXem
            // 
            this.btnDaXem.Location = new System.Drawing.Point(4, 4);
            this.btnDaXem.Margin = new System.Windows.Forms.Padding(4);
            this.btnDaXem.Name = "btnDaXem";
            this.btnDaXem.Size = new System.Drawing.Size(255, 36);
            this.btnDaXem.TabIndex = 35;
            this.btnDaXem.Text = "Đã xem, không hiển thị lại";
            this.btnDaXem.UseVisualStyleBackColor = true;
            this.btnDaXem.Click += new System.EventHandler(this.btnDaXem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1201, 11);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 36);
            this.button2.TabIndex = 35;
            this.button2.Text = "Đóng";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(967, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 24);
            this.label1.TabIndex = 34;
            this.label1.Text = "Nội dung thay đổi";
            // 
            // tabTheoDoiSanLuong
            // 
            this.tabTheoDoiSanLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTheoDoiSanLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTheoDoiSanLuong.ForeColor = System.Drawing.Color.Black;
            this.tabTheoDoiSanLuong.Location = new System.Drawing.Point(0, 0);
            this.tabTheoDoiSanLuong.Margin = new System.Windows.Forms.Padding(4);
            this.tabTheoDoiSanLuong.Name = "tabTheoDoiSanLuong";
            this.tabTheoDoiSanLuong.Size = new System.Drawing.Size(1376, 875);
            this.tabTheoDoiSanLuong.TabIndex = 61;
            this.tabTheoDoiSanLuong.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.tabTheoKeHoach,
            this.tabTaiKhoan});
            this.tabTheoDoiSanLuong.TabsStateStyles.SelectedFormatStyle.BackColor = System.Drawing.Color.ForestGreen;
            this.tabTheoDoiSanLuong.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.tabTheoDoiSanLuong.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.VS2005;
            this.tabTheoDoiSanLuong.SelectedTabChanged += new Janus.Windows.UI.Tab.TabEventHandler(this.tabTheoDoiSanLuong_SelectedTabChanged);
            // 
            // tabTheoKeHoach
            // 
            this.tabTheoKeHoach.Controls.Add(this.pnMother);
            this.tabTheoKeHoach.Location = new System.Drawing.Point(1, 32);
            this.tabTheoKeHoach.Margin = new System.Windows.Forms.Padding(4);
            this.tabTheoKeHoach.Name = "tabTheoKeHoach";
            this.tabTheoKeHoach.Size = new System.Drawing.Size(1374, 842);
            this.tabTheoKeHoach.TabStop = true;
            this.tabTheoKeHoach.Text = "Thay đổi hợp đồng";
            // 
            // pnMother
            // 
            this.pnMother.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnMother.Controls.Add(this.tableLayoutPanel1);
            this.pnMother.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMother.Location = new System.Drawing.Point(0, 0);
            this.pnMother.Margin = new System.Windows.Forms.Padding(4);
            this.pnMother.Name = "pnMother";
            this.pnMother.Size = new System.Drawing.Size(1374, 842);
            this.pnMother.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1370, 838);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ribNoiDung);
            this.panel2.Controls.Add(this.gdHopDongLog);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 66);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1362, 768);
            this.panel2.TabIndex = 0;
            // 
            // ribNoiDung
            // 
            this.ribNoiDung.Location = new System.Drawing.Point(875, 0);
            this.ribNoiDung.Margin = new System.Windows.Forms.Padding(4);
            this.ribNoiDung.Name = "ribNoiDung";
            this.ribNoiDung.Size = new System.Drawing.Size(492, 763);
            this.ribNoiDung.TabIndex = 35;
            this.ribNoiDung.Text = "";
            // 
            // gdHopDongLog
            // 
            this.gdHopDongLog.AllowColumnDrag = false;
            this.gdHopDongLog.AlternatingColors = true;
            this.gdHopDongLog.AutoEdit = true;
            this.gdHopDongLog.AutomaticSort = false;
            this.gdHopDongLog.BorderStyle = Janus.Windows.GridEX.BorderStyle.RaisedLight3D;
            this.gdHopDongLog.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.gdHopDongLog.Size = new System.Drawing.Size(1362, 768);
            this.gdHopDongLog.TabIndex = 33;
            this.gdHopDongLog.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdHopDongLog.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdHopDongLog.UpdateOnLeave = false;
            this.gdHopDongLog.SelectionChanged += new System.EventHandler(this.gdHopDongLog_SelectionChanged);
            this.gdHopDongLog.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gdHopDongLog_SelectionChanged);
            // 
            // tabTaiKhoan
            // 
            this.tabTaiKhoan.Controls.Add(this.pnSLToanVung);
            this.tabTaiKhoan.Location = new System.Drawing.Point(1, 32);
            this.tabTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.tabTaiKhoan.Name = "tabTaiKhoan";
            this.tabTaiKhoan.Size = new System.Drawing.Size(1374, 842);
            this.tabTaiKhoan.TabStop = true;
            this.tabTaiKhoan.Text = "Danh sách tài khoản ngân hàng";
            // 
            // pnSLToanVung
            // 
            this.pnSLToanVung.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnSLToanVung.Controls.Add(this.tableLayoutPanel2);
            this.pnSLToanVung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSLToanVung.Location = new System.Drawing.Point(0, 0);
            this.pnSLToanVung.Margin = new System.Windows.Forms.Padding(4);
            this.pnSLToanVung.Name = "pnSLToanVung";
            this.pnSLToanVung.Size = new System.Drawing.Size(1374, 842);
            this.pnSLToanVung.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.Controls.Add(this.grvDSTK, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1370, 838);
            this.tableLayoutPanel2.TabIndex = 35;
            // 
            // grvDSTK
            // 
            this.grvDSTK.AllowColumnDrag = false;
            this.grvDSTK.AlternatingColors = true;
            this.grvDSTK.AutoEdit = true;
            this.grvDSTK.AutomaticSort = false;
            this.grvDSTK.BorderStyle = Janus.Windows.GridEX.BorderStyle.RaisedLight3D;
            this.grvDSTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvDSTK.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.grvDSTK.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grvDSTK.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grvDSTK.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grvDSTK.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.grvDSTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grvDSTK.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.grvDSTK.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grvDSTK.GroupByBoxVisible = false;
            this.grvDSTK.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grvDSTK.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.grvDSTK.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            grvDSTK_Layout_0.Key = "ex";
            grvDSTK_Layout_0.LayoutString = resources.GetString("grvDSTK_Layout_0.LayoutString");
            grvDSTK_Layout_1.IsCurrentLayout = true;
            grvDSTK_Layout_1.Key = "CopyOfex";
            grvDSTK_Layout_1.LayoutString = resources.GetString("grvDSTK_Layout_1.LayoutString");
            this.grvDSTK.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            grvDSTK_Layout_0,
            grvDSTK_Layout_1});
            this.grvDSTK.LinkFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.grvDSTK.Location = new System.Drawing.Point(3, 64);
            this.grvDSTK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grvDSTK.Name = "grvDSTK";
            this.grvDSTK.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grvDSTK.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.grvDSTK.PreviewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.grvDSTK.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.grvDSTK.RowFormatStyle.Font = new System.Drawing.Font("Arial", 9F);
            this.grvDSTK.RowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.grvDSTK.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.grvDSTK.RowHeaderFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.grvDSTK.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both;
            this.grvDSTK.SelectedFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.grvDSTK.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grvDSTK.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.grvDSTK.Size = new System.Drawing.Size(1364, 772);
            this.grvDSTK.TabIndex = 34;
            this.grvDSTK.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grvDSTK.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grvDSTK.UpdateOnLeave = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmd2ExcelTheoKH);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1362, 54);
            this.panel3.TabIndex = 35;
            // 
            // cmd2ExcelTheoKH
            // 
            this.cmd2ExcelTheoKH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd2ExcelTheoKH.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd2ExcelTheoKH.Icon = ((System.Drawing.Icon)(resources.GetObject("cmd2ExcelTheoKH.Icon")));
            this.cmd2ExcelTheoKH.Location = new System.Drawing.Point(1109, 5);
            this.cmd2ExcelTheoKH.Margin = new System.Windows.Forms.Padding(4);
            this.cmd2ExcelTheoKH.Name = "cmd2ExcelTheoKH";
            this.cmd2ExcelTheoKH.Size = new System.Drawing.Size(120, 34);
            this.cmd2ExcelTheoKH.TabIndex = 87;
            this.cmd2ExcelTheoKH.Text = "Xuất Excel";
            this.cmd2ExcelTheoKH.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmd2ExcelTheoKH.Click += new System.EventHandler(this.cmd2ExcelTheoKH_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1252, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 36);
            this.button1.TabIndex = 36;
            this.button1.Text = "Đóng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Excell(*.xls)|*.xls";
            // 
            // frmHopDongLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 875);
            this.Controls.Add(this.tabTheoDoiSanLuong);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHopDongLog";
            this.Text = "Thông tin hợp đồng thay đổi";
            this.Load += new System.EventHandler(this.frmHopDongLog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabTheoDoiSanLuong)).EndInit();
            this.tabTheoDoiSanLuong.ResumeLayout(false);
            this.tabTheoKeHoach.ResumeLayout(false);
            this.pnMother.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdHopDongLog)).EndInit();
            this.tabTaiKhoan.ResumeLayout(false);
            this.pnSLToanVung.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvDSTK)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDaXem;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.UI.Tab.UITab tabTheoDoiSanLuong;
        private Janus.Windows.UI.Tab.UITabPage tabTheoKeHoach;
        private System.Windows.Forms.Panel pnMother;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Janus.Windows.UI.Tab.UITabPage tabTaiKhoan;
        private System.Windows.Forms.Panel pnSLToanVung;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox ribNoiDung;
        public Janus.Windows.GridEX.GridEX gdHopDongLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public Janus.Windows.GridEX.GridEX grvDSTK;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private Janus.Windows.EditControls.UIButton cmd2ExcelTheoKH;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}