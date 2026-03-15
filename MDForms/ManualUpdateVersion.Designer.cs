namespace MDSolution.MDForms
{
    partial class ManualUpdateVersion
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
            this.lNewVer = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbThisVer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbNewVer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lNewVer
            // 
            this.lNewVer.AutoSize = true;
            this.lNewVer.Location = new System.Drawing.Point(113, 87);
            this.lNewVer.Name = "lNewVer";
            this.lNewVer.Size = new System.Drawing.Size(25, 13);
            this.lNewVer.TabIndex = 0;
            this.lNewVer.TabStop = true;
            this.lNewVer.Text = "đây";
            this.lNewVer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lNewVer_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phiên bản hiện tại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phiên bản mới:";
            // 
            // lbThisVer
            // 
            this.lbThisVer.AutoSize = true;
            this.lbThisVer.Location = new System.Drawing.Point(113, 9);
            this.lbThisVer.Name = "lbThisVer";
            this.lbThisVer.Size = new System.Drawing.Size(49, 13);
            this.lbThisVer.TabIndex = 1;
            this.lbThisVer.Text = "[ThisVer]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Vui lòng nhấn vào ";
            // 
            // lbNewVer
            // 
            this.lbNewVer.AutoSize = true;
            this.lbNewVer.Location = new System.Drawing.Point(113, 31);
            this.lbNewVer.Name = "lbNewVer";
            this.lbNewVer.Size = new System.Drawing.Size(51, 13);
            this.lbNewVer.TabIndex = 1;
            this.lbNewVer.Text = "[NewVer]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "để tải về phiên bản mới.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(283, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Sau khi tải về máy vui lòng chọn file đã tải về để cập nhật";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(271, 128);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(119, 23);
            this.btnChonFile.TabIndex = 2;
            this.btnChonFile.Text = "Chọn file để cập nhật";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(15, 130);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(250, 20);
            this.txtFile.TabIndex = 3;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(15, 47);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.ReadOnly = true;
            this.txtUrl.Size = new System.Drawing.Size(373, 20);
            this.txtUrl.TabIndex = 3;
            // 
            // ManualUpdateVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 186);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnChonFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbNewVer);
            this.Controls.Add(this.lbThisVer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lNewVer);
            this.Name = "ManualUpdateVersion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật phiên bản";
            this.Load += new System.EventHandler(this.ManualUpdateVersion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.LinkLabel lNewVer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lbThisVer;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lbNewVer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.TextBox txtFile;
        public System.Windows.Forms.TextBox txtUrl;
    }
}