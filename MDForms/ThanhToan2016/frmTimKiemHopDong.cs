using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDSolution.MDForms.ThanhToan2016
{
    public partial class frmTimKiemHopDong : Form
    {
        public frmTimKiemHopDong()
        {
            InitializeComponent();
        }
        private DataSet LoadHopDong()
        {
            string strSQL = "";
            strSQL = @"SELECT a.*,b.Ten as TenThon 

                        FROM tbl_HopDong as a LEFT JOIN tbl_Thon as b ON a.ThonID=b.ID 
                        WHERE a.parentid=0 AND TrangThai = 1 AND a.ID IN (SELECT HopDongID From tbl_HopDongVuTrong Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString() + ")";
        
            return DBModule.ExecuteQuery(strSQL, null, null);
        }

        private void frmTimKiemHopDong_Load(object sender, EventArgs e)
        {
            GridEX1.SetDataBinding(LoadHopDong().Tables[0],"");
        }
        public  string Ma_HD;
        private void GridEX1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if(e.Row.RowType==Janus.Windows.GridEX.RowType.Record)
            {
                Ma_HD = GridEX1.GetRow().Cells["MaHopDong"].Value.ToString();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
