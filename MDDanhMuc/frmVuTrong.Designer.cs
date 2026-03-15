namespace MDSolution.MDDanhMuc
{
    partial class frmVuTrong
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
            Janus.Windows.GridEX.GridEXLayout gdVDMTD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVuTrong));
            this.gdVDMTD = new Janus.Windows.GridEX.GridEX();
            this.pnVuTrong = new System.Windows.Forms.Panel();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.grVuTrong = new System.Windows.Forms.GroupBox();
            this.btnOK = new Janus.Windows.EditControls.UIButton();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gdVDMTD)).BeginInit();
            this.pnVuTrong.SuspendLayout();
            this.pnTitle.SuspendLayout();
            this.pnBottom.SuspendLayout();
            this.grVuTrong.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdVDMTD
            // 
            this.gdVDMTD.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVDMTD.AlternatingColors = true;
            this.gdVDMTD.AutoEdit = true;
            this.gdVDMTD.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><GroupByBoxInfo>Kéo ti" +
                "êu đề cột vào đây để nhóm theo cột</GroupByBoxInfo></LocalizableData>";
            this.gdVDMTD.ColumnAutoResize = true;
            gdVDMTD_DesignTimeLayout.LayoutString = resources.GetString("gdVDMTD_DesignTimeLayout.LayoutString");
            this.gdVDMTD.DesignTimeLayout = gdVDMTD_DesignTimeLayout;
            this.gdVDMTD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdVDMTD.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.gdVDMTD.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdVDMTD.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.gdVDMTD.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gdVDMTD.GroupByBoxVisible = false;
            this.gdVDMTD.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVDMTD.HeaderFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVDMTD.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdVDMTD.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gdVDMTD.Location = new System.Drawing.Point(3, 18);
            this.gdVDMTD.Name = "gdVDMTD";
            this.gdVDMTD.NewRowEnterKeyBehavior = Janus.Windows.GridEX.NewRowEnterKeyBehavior.AddRowAndMoveToAddedRow;
            this.gdVDMTD.NewRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdVDMTD.NewRowFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gdVDMTD.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVDMTD.NewRowFormatStyle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gdVDMTD.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.gdVDMTD.RowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVDMTD.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gdVDMTD.RowHeaderFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            this.gdVDMTD.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gdVDMTD.ScrollBarWidth = 17;
            this.gdVDMTD.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gdVDMTD.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVDMTD.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVDMTD.Size = new System.Drawing.Size(657, 220);
            this.gdVDMTD.TabIndex = 8;
            this.gdVDMTD.TableHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.gdVDMTD.TableHeaderFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.gdVDMTD.TableHeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.gdVDMTD.UpdateOnLeave = false;
            this.gdVDMTD.RecordUpdated += new System.EventHandler(this.gdVVuTrong_RecordUpdated);
            this.gdVDMTD.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.gdVVuTrong_UpdatingRecord);
            this.gdVDMTD.AddingRecord += new System.ComponentModel.CancelEventHandler(this.gdVDMTD_AddingRecord);
            // 
            // pnVuTrong
            // 
            this.pnVuTrong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnVuTrong.Controls.Add(this.grVuTrong);
            this.pnVuTrong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnVuTrong.Location = new System.Drawing.Point(0, 32);
            this.pnVuTrong.Name = "pnVuTrong";
            this.pnVuTrong.Size = new System.Drawing.Size(667, 245);
            this.pnVuTrong.TabIndex = 9;
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(667, 32);
            this.pnTitle.TabIndex = 10;
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.btnOK);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 277);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(667, 38);
            this.pnBottom.TabIndex = 11;
            // 
            // grVuTrong
            // 
            this.grVuTrong.Controls.Add(this.gdVDMTD);
            this.grVuTrong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grVuTrong.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grVuTrong.ForeColor = System.Drawing.Color.Maroon;
            this.grVuTrong.Location = new System.Drawing.Point(0, 0);
            this.grVuTrong.Name = "grVuTrong";
            this.grVuTrong.Size = new System.Drawing.Size(663, 241);
            this.grVuTrong.TabIndex = 9;
            this.grVuTrong.TabStop = false;
            this.grVuTrong.Text = "Danh sách các niên vụ";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(572, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 28);
            this.btnOK.TabIndex = 176;
            this.btnOK.Text = "Đóng";
            this.btnOK.ToolTipText = "Chi tiết lịch sử thanh toán cho khoản đầu tư được chọn";
            this.btnOK.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(667, 32);
            this.lblTitle.TabIndex = 155;
            this.lblTitle.Text = "DANH MỤC VỤ TRỒNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmVuTrong
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(667, 315);
            this.Controls.Add(this.pnVuTrong);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.pnTitle);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVuTrong";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vụ trồng";
            this.Load += new System.EventHandler(this.frmVuTrong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdVDMTD)).EndInit();
            this.pnVuTrong.ResumeLayout(false);
            this.pnTitle.ResumeLayout(false);
            this.pnBottom.ResumeLayout(false);
            this.grVuTrong.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal Janus.Windows.GridEX.GridEX gdVDMTD;
        private System.Windows.Forms.Panel pnVuTrong;
        private System.Windows.Forms.GroupBox grVuTrong;
        private System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.Panel pnBottom;
        private Janus.Windows.EditControls.UIButton btnOK;
        private System.Windows.Forms.Label lblTitle;
    }
}