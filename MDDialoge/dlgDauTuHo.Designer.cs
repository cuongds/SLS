namespace MDSolution.MDDialoge
{
    partial class dlgDauTuHo
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
            Janus.Windows.GridEX.GridEXLayout gdVHopDongDauTu_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgDauTuHo));
            this.gdVHopDongDauTu = new Janus.Windows.GridEX.GridEX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_thongbao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gdVHopDongDauTu)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdVHopDongDauTu
            // 
            this.gdVHopDongDauTu.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gdVHopDongDauTu.AlternatingColors = true;
            this.gdVHopDongDauTu.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
    "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            this.gdVHopDongDauTu.ColumnAutoResize = true;
            gdVHopDongDauTu_DesignTimeLayout.LayoutString = resources.GetString("gdVHopDongDauTu_DesignTimeLayout.LayoutString");
            this.gdVHopDongDauTu.DesignTimeLayout = gdVHopDongDauTu_DesignTimeLayout;
            this.gdVHopDongDauTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdVHopDongDauTu.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdVHopDongDauTu.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdVHopDongDauTu.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVHopDongDauTu.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVHopDongDauTu.GroupByBoxVisible = false;
            this.gdVHopDongDauTu.Location = new System.Drawing.Point(3, 39);
            this.gdVHopDongDauTu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdVHopDongDauTu.Name = "gdVHopDongDauTu";
            this.gdVHopDongDauTu.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Transparent;
            this.gdVHopDongDauTu.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVHopDongDauTu.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both;
            this.gdVHopDongDauTu.ScrollBarWidth = 17;
            this.gdVHopDongDauTu.SelectedFormatStyle.BackColor = System.Drawing.Color.Red;
            this.gdVHopDongDauTu.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVHopDongDauTu.SelectedInactiveFormatStyle.BackColor = System.Drawing.Color.Red;
            this.gdVHopDongDauTu.Size = new System.Drawing.Size(1148, 566);
            this.gdVHopDongDauTu.TabIndex = 10;
            this.gdVHopDongDauTu.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.gdVHopDongVanChuyen_RowDoubleClick);
            this.gdVHopDongDauTu.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gdVHopDongVanChuyen_FormattingRow);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gdVHopDongDauTu, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1154, 609);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_thongbao);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1148, 29);
            this.panel1.TabIndex = 11;
            // 
            // lbl_thongbao
            // 
            this.lbl_thongbao.AutoSize = true;
            this.lbl_thongbao.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_thongbao.ForeColor = System.Drawing.Color.Red;
            this.lbl_thongbao.Location = new System.Drawing.Point(319, 0);
            this.lbl_thongbao.Name = "lbl_thongbao";
            this.lbl_thongbao.Size = new System.Drawing.Size(0, 21);
            this.lbl_thongbao.TabIndex = 0;
            // 
            // dlgDauTuHo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 609);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgDauTuHo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách đầu tư của chủ mía";
            ((System.ComponentModel.ISupportInitialize)(this.gdVHopDongDauTu)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gdVHopDongDauTu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_thongbao;
    }
}