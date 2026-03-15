using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution
{
    public partial class dlgXeChuaCanBi : Form
    {
        // Thiet lap vu trong
        string VuTrongID = MDSolutionApp.VuTrongID.ToString();
        // Thiet lap vu trong

        public delegate void PassID(string value);
        public PassID passID;

        private void SendID()
        {
            if (passID != null)
            {
                try
                {
                    passID(this.gdVHopDongVanChuyen.GetValue("ID").ToString());
                }
                catch
                {
                    passID("-1");
                }
            }
        }
        public dlgXeChuaCanBi()
        {
            InitializeComponent();
            LoadGrid();
        }
        public void LoadGrid()
        {
            string strSQL = "";
            strSQL = "Select XeID as ID, TenLaiXe, SoXe, NgayVanChuyen from V_VanChuyenMia Where MaCanGhepID=-1 AND TrongLuongXe<=0 AND VuTrongID=" + VuTrongID;

            DataSet ds = DBModule.ExecuteQuery(strSQL,null,null);
            if (ds.Tables.Count > 0)
            {
                this.gdVHopDongVanChuyen.SetDataBinding(ds.Tables[0], "");
            }
        }
       
        private void gdVHopDongVanChuyen_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            //frmNhapMia.MaKVC = this.gdVHopDongVanChuyen.GetValue("MaHopDong").ToString().Trim();
            this.SendID();
            this.DialogResult = DialogResult.OK;
            Close();           
          
        }

        private void gdVHopDongVanChuyen_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {

        }

        
    }
}