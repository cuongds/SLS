using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution
{
    public partial class dlgBaiTapKet : Form
    {
        public delegate void PassID(string value);
        public PassID passID;
        public string BaiTapKetID = "";

        private void SendID()
        {
            if (passID != null)
            {
                try
                {
                    passID(BaiTapKetID);
                }
                catch
                {
                    passID("-1");
                }
            }
        }
        public dlgBaiTapKet()
        {
            InitializeComponent();
            LoadBaiTapKet();
        }
        public void LoadBaiTapKet()
        {
            DataSet ds = clsBaiTapKet.GetListbyWhere("", "", "", null, null);
            if (ds.Tables.Count > 0)
            {
                this.gdBaiTapKet.SetDataBinding(ds.Tables[0], "");
            }
        }
       
        private void gdVHopDongVanChuyen_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {

          this.BaiTapKetID = this.gdBaiTapKet.GetValue("ID").ToString();           
            this.SendID();
            this.DialogResult = DialogResult.OK;
            Close();           
          
        }

        private void gdVHopDongVanChuyen_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {

        }

        private void gdVHopDongVanChuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //frmNhapMia.MaKVC = this.gdVHopDongVanChuyen.GetValue("MaHopDong").ToString().Trim();
                 this.BaiTapKetID = this.gdBaiTapKet.GetValue("ID").ToString();
                this.SendID();
                this.DialogResult = DialogResult.OK;
                Close();   
            }
            if (e.KeyCode == Keys.Escape)
            {                
                Close();
            }
        }

        private void dlgBaiTapKet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Escape)
            {
                Close();
            }
        }

        
    }
}