namespace MDSolution.MDForms
{
    partial class frm_DienTich
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Janus.Windows.GridEX.GridEXLayout gridEX1_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DienTich));
            Janus.Windows.GridEX.GridEXLayout gridEX1_Layout_1 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gdChiTietDauTu_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout gdChiTietDauTu_Layout_1 = new Janus.Windows.GridEX.GridEXLayout();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.gdChiTietDauTu = new Janus.Windows.GridEX.GridEX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rd2 = new System.Windows.Forms.RadioButton();
            this.ComboCBNV = new Janus.Windows.EditControls.UIComboBox();
            this.rd1 = new System.Windows.Forms.RadioButton();
            this.lblWaite = new System.Windows.Forms.Label();
            this.cmdAddFromExcel = new Janus.Windows.EditControls.UIButton();
            this.btn_Xoa = new Janus.Windows.EditControls.UIButton();
            this.bt_sua = new Janus.Windows.EditControls.UIButton();
            this.bt_them = new Janus.Windows.EditControls.UIButton();
            this.ComboVuTrong = new Janus.Windows.EditControls.UIComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXuatExcelHopDong = new Janus.Windows.EditControls.UIButton();
            this.cmdAddHD = new Janus.Windows.EditControls.UIButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog_Excel = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.gridEXExporter = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.contextRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolChitiethopdong = new System.Windows.Forms.ToolStripMenuItem();
            this.toolThietlapdientich = new System.Windows.Forms.ToolStripMenuItem();
            this.toolQuanlydautu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolQuanlyhotro = new System.Windows.Forms.ToolStripMenuItem();
            this.toolLamthanhtoan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChitiettrunodautu = new System.Windows.Forms.ToolStripMenuItem();
            this.chitiencoTruNo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemChuyenHDChinhKhac = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemChuyenThanhHD = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemThemChuHoDaCo = new System.Windows.Forms.ToolStripMenuItem();
            this.rd3 = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdChiTietDauTu)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gridEX1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.gdChiTietDauTu, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1813, 693);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gridEX1
            // 
            this.gridEX1.AllowColumnDrag = false;
            this.gridEX1.AlternatingColors = true;
            this.gridEX1.AutoEdit = true;
            this.gridEX1.AutomaticSort = false;
            this.gridEX1.BorderStyle = Janus.Windows.GridEX.BorderStyle.RaisedLight3D;
            this.gridEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEX1.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gridEX1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gridEX1.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gridEX1.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gridEX1.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gridEX1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.gridEX1.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gridEX1.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gridEX1.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gridEX1.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            gridEX1_Layout_0.Key = "ex";
            gridEX1_Layout_0.LayoutString = resources.GetString("gridEX1_Layout_0.LayoutString");
            gridEX1_Layout_1.IsCurrentLayout = true;
            gridEX1_Layout_1.Key = "CopyOfex";
            gridEX1_Layout_1.LayoutString = resources.GetString("gridEX1_Layout_1.LayoutString");
            this.gridEX1.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gridEX1_Layout_0,
            gridEX1_Layout_1});
            this.gridEX1.LinkFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gridEX1.Location = new System.Drawing.Point(2, 682);
            this.gridEX1.Margin = new System.Windows.Forms.Padding(2);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridEX1.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gridEX1.PreviewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.gridEX1.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gridEX1.RowFormatStyle.Font = new System.Drawing.Font("Arial", 9F);
            this.gridEX1.RowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.gridEX1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridEX1.RowHeaderFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gridEX1.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both;
            this.gridEX1.SelectedFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gridEX1.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gridEX1.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gridEX1.Size = new System.Drawing.Size(1809, 9);
            this.gridEX1.TabIndex = 33;
            this.gridEX1.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gridEX1.UpdateOnLeave = false;
            this.gridEX1.Visible = false;
            // 
            // gdChiTietDauTu
            // 
            this.gdChiTietDauTu.AllowColumnDrag = false;
            this.gdChiTietDauTu.AlternatingColors = true;
            this.gdChiTietDauTu.AutoEdit = true;
            this.gdChiTietDauTu.AutomaticSort = false;
            this.gdChiTietDauTu.BorderStyle = Janus.Windows.GridEX.BorderStyle.RaisedLight3D;
            this.gdChiTietDauTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdChiTietDauTu.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gdChiTietDauTu.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gdChiTietDauTu.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gdChiTietDauTu.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gdChiTietDauTu.Font = new System.Drawing.Font("Arial", 8.25F);
            this.gdChiTietDauTu.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdChiTietDauTu.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdChiTietDauTu.GroupByBoxVisible = false;
            this.gdChiTietDauTu.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdChiTietDauTu.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdChiTietDauTu.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            gdChiTietDauTu_Layout_0.Key = "ex";
            gdChiTietDauTu_Layout_0.LayoutString = resources.GetString("gdChiTietDauTu_Layout_0.LayoutString");
            gdChiTietDauTu_Layout_1.IsCurrentLayout = true;
            gdChiTietDauTu_Layout_1.Key = "CopyOfex";
            gdChiTietDauTu_Layout_1.LayoutString = resources.GetString("gdChiTietDauTu_Layout_1.LayoutString");
            this.gdChiTietDauTu.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            gdChiTietDauTu_Layout_0,
            gdChiTietDauTu_Layout_1});
            this.gdChiTietDauTu.LinkFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdChiTietDauTu.Location = new System.Drawing.Point(2, 80);
            this.gdChiTietDauTu.Margin = new System.Windows.Forms.Padding(2);
            this.gdChiTietDauTu.Name = "gdChiTietDauTu";
            this.gdChiTietDauTu.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdChiTietDauTu.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdChiTietDauTu.PreviewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.gdChiTietDauTu.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdChiTietDauTu.RowFormatStyle.Font = new System.Drawing.Font("Arial", 9F);
            this.gdChiTietDauTu.RowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.gdChiTietDauTu.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdChiTietDauTu.RowHeaderFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdChiTietDauTu.SelectedFormatStyle.BackColor = System.Drawing.Color.SkyBlue;
            this.gdChiTietDauTu.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdChiTietDauTu.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdChiTietDauTu.Size = new System.Drawing.Size(1809, 598);
            this.gdChiTietDauTu.TabIndex = 32;
            this.gdChiTietDauTu.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdChiTietDauTu.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.gdChiTietDauTu.UpdateOnLeave = false;
            this.gdChiTietDauTu.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gdChiTietDauTu_FormattingRow);
            this.gdChiTietDauTu.CellEdited += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gdChiTietDauTu_CellEdited);
            this.gdChiTietDauTu.EditingCell += new Janus.Windows.GridEX.EditingCellEventHandler(this.gdChiTietDauTu_EditingCell);
            this.gdChiTietDauTu.UpdatingCell += new Janus.Windows.GridEX.UpdatingCellEventHandler(this.gdChiTietDauTu_UpdatingCell);
            this.gdChiTietDauTu.TextChanged += new System.EventHandler(this.gdChiTietDauTu_TextChanged);
            this.gdChiTietDauTu.Enter += new System.EventHandler(this.gdChiTietDauTu_Enter);
            this.gdChiTietDauTu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gdChiTietDauTu_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1809, 74);
            this.panel1.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btn_Xoa);
            this.groupBox1.Controls.Add(this.bt_sua);
            this.groupBox1.Controls.Add(this.bt_them);
            this.groupBox1.Controls.Add(this.ComboVuTrong);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnXuatExcelHopDong);
            this.groupBox1.Controls.Add(this.cmdAddHD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1809, 74);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rd3);
            this.groupBox2.Controls.Add(this.rd2);
            this.groupBox2.Controls.Add(this.ComboCBNV);
            this.groupBox2.Controls.Add(this.rd1);
            this.groupBox2.Controls.Add(this.lblWaite);
            this.groupBox2.Controls.Add(this.cmdAddFromExcel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(947, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(860, 52);
            this.groupBox2.TabIndex = 92;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Để làm Import";
            // 
            // rd2
            // 
            this.rd2.AutoSize = true;
            this.rd2.Location = new System.Drawing.Point(72, 25);
            this.rd2.Name = "rd2";
            this.rd2.Size = new System.Drawing.Size(65, 21);
            this.rd2.TabIndex = 94;
            this.rd2.TabStop = true;
            this.rd2.Text = "Lần 2";
            this.rd2.UseVisualStyleBackColor = true;
            // 
            // ComboCBNV
            // 
            this.ComboCBNV.Location = new System.Drawing.Point(249, 24);
            this.ComboCBNV.Name = "ComboCBNV";
            this.ComboCBNV.Size = new System.Drawing.Size(192, 25);
            this.ComboCBNV.TabIndex = 91;
            this.ComboCBNV.Text = "Chọn CBNV";
            // 
            // rd1
            // 
            this.rd1.AutoSize = true;
            this.rd1.Checked = true;
            this.rd1.Location = new System.Drawing.Point(6, 24);
            this.rd1.Name = "rd1";
            this.rd1.Size = new System.Drawing.Size(65, 21);
            this.rd1.TabIndex = 93;
            this.rd1.TabStop = true;
            this.rd1.Text = "Lần 1";
            this.rd1.UseVisualStyleBackColor = true;
            // 
            // lblWaite
            // 
            this.lblWaite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWaite.AutoSize = true;
            this.lblWaite.CausesValidation = false;
            this.lblWaite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblWaite.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaite.ForeColor = System.Drawing.Color.Red;
            this.lblWaite.Location = new System.Drawing.Point(595, 30);
            this.lblWaite.Name = "lblWaite";
            this.lblWaite.Size = new System.Drawing.Size(118, 19);
            this.lblWaite.TabIndex = 89;
            this.lblWaite.Text = "Vui lòng đợi...";
            this.lblWaite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWaite.Visible = false;
            // 
            // cmdAddFromExcel
            // 
            this.cmdAddFromExcel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAddFromExcel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddFromExcel.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddFromExcel.Image")));
            this.cmdAddFromExcel.Location = new System.Drawing.Point(464, 22);
            this.cmdAddFromExcel.Name = "cmdAddFromExcel";
            this.cmdAddFromExcel.Size = new System.Drawing.Size(125, 26);
            this.cmdAddFromExcel.TabIndex = 87;
            this.cmdAddFromExcel.Text = "Nhập từ file Excel";
            this.cmdAddFromExcel.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.cmdAddFromExcel.Click += new System.EventHandler(this.cmdAddFromExcel_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Xoa.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Icon = ((System.Drawing.Icon)(resources.GetObject("btn_Xoa.Icon")));
            this.btn_Xoa.Image = ((System.Drawing.Image)(resources.GetObject("btn_Xoa.Image")));
            this.btn_Xoa.Location = new System.Drawing.Point(517, 31);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(79, 29);
            this.btn_Xoa.TabIndex = 79;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // bt_sua
            // 
            this.bt_sua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_sua.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_sua.Icon = ((System.Drawing.Icon)(resources.GetObject("bt_sua.Icon")));
            this.bt_sua.Image = ((System.Drawing.Image)(resources.GetObject("bt_sua.Image")));
            this.bt_sua.Location = new System.Drawing.Point(433, 31);
            this.bt_sua.Name = "bt_sua";
            this.bt_sua.Size = new System.Drawing.Size(79, 29);
            this.bt_sua.TabIndex = 78;
            this.bt_sua.Text = "Sửa";
            this.bt_sua.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            this.bt_sua.Click += new System.EventHandler(this.bt_sua_Click);
            // 
            // bt_them
            // 
            this.bt_them.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_them.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_them.Icon = ((System.Drawing.Icon)(resources.GetObject("bt_them.Icon")));
            this.bt_them.Image = ((System.Drawing.Image)(resources.GetObject("bt_them.Image")));
            this.bt_them.Location = new System.Drawing.Point(348, 31);
            this.bt_them.Name = "bt_them";
            this.bt_them.Size = new System.Drawing.Size(79, 29);
            this.bt_them.TabIndex = 77;
            this.bt_them.Text = "Thêm";
            this.bt_them.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            this.bt_them.Click += new System.EventHandler(this.bt_them_Click);
            // 
            // ComboVuTrong
            // 
            this.ComboVuTrong.Location = new System.Drawing.Point(63, 32);
            this.ComboVuTrong.Name = "ComboVuTrong";
            this.ComboVuTrong.Size = new System.Drawing.Size(113, 25);
            this.ComboVuTrong.TabIndex = 76;
            this.ComboVuTrong.Text = "Chọn vụ trồng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(10, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 75;
            this.label3.Text = "Vụ trồng:";
            // 
            // btnXuatExcelHopDong
            // 
            this.btnXuatExcelHopDong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXuatExcelHopDong.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcelHopDong.Icon = ((System.Drawing.Icon)(resources.GetObject("btnXuatExcelHopDong.Icon")));
            this.btnXuatExcelHopDong.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcelHopDong.Image")));
            this.btnXuatExcelHopDong.Location = new System.Drawing.Point(263, 31);
            this.btnXuatExcelHopDong.Name = "btnXuatExcelHopDong";
            this.btnXuatExcelHopDong.Size = new System.Drawing.Size(79, 29);
            this.btnXuatExcelHopDong.TabIndex = 74;
            this.btnXuatExcelHopDong.Text = "Xuất Excel";
            this.btnXuatExcelHopDong.Click += new System.EventHandler(this.btnXuatExcelHopDong_Click);
            // 
            // cmdAddHD
            // 
            this.cmdAddHD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAddHD.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddHD.Icon = ((System.Drawing.Icon)(resources.GetObject("cmdAddHD.Icon")));
            this.cmdAddHD.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddHD.Image")));
            this.cmdAddHD.Location = new System.Drawing.Point(180, 31);
            this.cmdAddHD.Name = "cmdAddHD";
            this.cmdAddHD.Size = new System.Drawing.Size(79, 29);
            this.cmdAddHD.TabIndex = 73;
            this.cmdAddHD.Text = "Tìm kiếm";
            this.cmdAddHD.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            this.cmdAddHD.Click += new System.EventHandler(this.cmdAddHD_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.Filter = " Excel files (*.xls)|*.xls";
            // 
            // openFileDialog_Excel
            // 
            this.openFileDialog_Excel.Filter = " Excel 97-2003 files (*.xls)|*.xls|Excel 2007 files (*.xlsx)|*.xlsx|All files (*." +
    "*)|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = " Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            // 
            // contextRight
            // 
            this.contextRight.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolChitiethopdong,
            this.toolThietlapdientich,
            this.toolQuanlydautu,
            this.toolQuanlyhotro,
            this.toolLamthanhtoan,
            this.mnuChitiettrunodautu,
            this.chitiencoTruNo,
            this.toolStripMenuItem1,
            this.ToolStripMenuItemChuyenHDChinhKhac,
            this.ToolStripMenuItemChuyenThanhHD,
            this.ToolStripMenuItemThemChuHoDaCo});
            this.contextRight.Name = "contextRight";
            this.contextRight.Size = new System.Drawing.Size(368, 250);
            // 
            // toolChitiethopdong
            // 
            this.toolChitiethopdong.Name = "toolChitiethopdong";
            this.toolChitiethopdong.Size = new System.Drawing.Size(367, 24);
            this.toolChitiethopdong.Text = "Xem chi tiết hợp đồng";
            // 
            // toolThietlapdientich
            // 
            this.toolThietlapdientich.Name = "toolThietlapdientich";
            this.toolThietlapdientich.Size = new System.Drawing.Size(367, 24);
            this.toolThietlapdientich.Text = "Thiết lập diện tích";
            // 
            // toolQuanlydautu
            // 
            this.toolQuanlydautu.Name = "toolQuanlydautu";
            this.toolQuanlydautu.Size = new System.Drawing.Size(367, 24);
            this.toolQuanlydautu.Text = "Quản lý đầu tư";
            // 
            // toolQuanlyhotro
            // 
            this.toolQuanlyhotro.Name = "toolQuanlyhotro";
            this.toolQuanlyhotro.Size = new System.Drawing.Size(367, 24);
            this.toolQuanlyhotro.Text = "Quản lý hỗ trợ";
            // 
            // toolLamthanhtoan
            // 
            this.toolLamthanhtoan.Name = "toolLamthanhtoan";
            this.toolLamthanhtoan.Size = new System.Drawing.Size(367, 24);
            this.toolLamthanhtoan.Text = "Làm thanh toán, nhập tiền trả nợ";
            // 
            // mnuChitiettrunodautu
            // 
            this.mnuChitiettrunodautu.Name = "mnuChitiettrunodautu";
            this.mnuChitiettrunodautu.Size = new System.Drawing.Size(367, 24);
            this.mnuChitiettrunodautu.Text = "Xem chi tiết các khỏan đầu tư được trừ nợ";
            // 
            // chitiencoTruNo
            // 
            this.chitiencoTruNo.Name = "chitiencoTruNo";
            this.chitiencoTruNo.Size = new System.Drawing.Size(367, 24);
            this.chitiencoTruNo.Text = "Xem chi tiết các khỏan tiền có trừ nợ đầu tư";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(364, 6);
            // 
            // ToolStripMenuItemChuyenHDChinhKhac
            // 
            this.ToolStripMenuItemChuyenHDChinhKhac.Name = "ToolStripMenuItemChuyenHDChinhKhac";
            this.ToolStripMenuItemChuyenHDChinhKhac.Size = new System.Drawing.Size(367, 24);
            this.ToolStripMenuItemChuyenHDChinhKhac.Text = "Chuyển sang HĐ chính khác";
            // 
            // ToolStripMenuItemChuyenThanhHD
            // 
            this.ToolStripMenuItemChuyenThanhHD.Name = "ToolStripMenuItemChuyenThanhHD";
            this.ToolStripMenuItemChuyenThanhHD.Size = new System.Drawing.Size(367, 24);
            this.ToolStripMenuItemChuyenThanhHD.Text = "Chuyển chủ hộ thành hợp đồng";
            // 
            // ToolStripMenuItemThemChuHoDaCo
            // 
            this.ToolStripMenuItemThemChuHoDaCo.Name = "ToolStripMenuItemThemChuHoDaCo";
            this.ToolStripMenuItemThemChuHoDaCo.Size = new System.Drawing.Size(367, 24);
            this.ToolStripMenuItemThemChuHoDaCo.Text = "Thêm chủ hộ đã khai báo";
            // 
            // rd3
            // 
            this.rd3.AutoSize = true;
            this.rd3.Location = new System.Drawing.Point(143, 24);
            this.rd3.Name = "rd3";
            this.rd3.Size = new System.Drawing.Size(102, 21);
            this.rd3.TabIndex = 95;
            this.rd3.Text = "Mã TR_ĐC";
            this.rd3.UseVisualStyleBackColor = true;
            // 
            // frm_DienTich
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1813, 693);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_DienTich";
            this.Text = "Diện tích theo cán bộ địa bàn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_DienTich_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdChiTietDauTu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Janus.Windows.EditControls.UIButton cmdAddHD;
        private Janus.Windows.EditControls.UIButton btnXuatExcelHopDong;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Janus.Windows.EditControls.UIComboBox ComboVuTrong;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private Janus.Windows.GridEX.GridEX gdChiTietDauTu;
        private Janus.Windows.EditControls.UIButton bt_sua;
        private Janus.Windows.EditControls.UIButton bt_them;
        private Janus.Windows.EditControls.UIButton btn_Xoa;
        private Janus.Windows.EditControls.UIButton cmdAddFromExcel;
        private System.Windows.Forms.Label lblWaite;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Excel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter;
        private System.Windows.Forms.ContextMenuStrip contextRight;
        private System.Windows.Forms.ToolStripMenuItem toolChitiethopdong;
        private System.Windows.Forms.ToolStripMenuItem toolThietlapdientich;
        private System.Windows.Forms.ToolStripMenuItem toolQuanlydautu;
        private System.Windows.Forms.ToolStripMenuItem toolQuanlyhotro;
        private System.Windows.Forms.ToolStripMenuItem toolLamthanhtoan;
        private System.Windows.Forms.ToolStripMenuItem mnuChitiettrunodautu;
        private System.Windows.Forms.ToolStripMenuItem chitiencoTruNo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemChuyenHDChinhKhac;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemChuyenThanhHD;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemThemChuHoDaCo;
        private Janus.Windows.EditControls.UIComboBox ComboCBNV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rd2;
        private System.Windows.Forms.RadioButton rd1;
        private System.Windows.Forms.RadioButton rd3;
    }
}