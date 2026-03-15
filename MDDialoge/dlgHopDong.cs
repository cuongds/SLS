
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace MDSolution
{
    public partial class dlgHopDong : Form
    {
        private NodeDonVi nDonVi = new NodeDonVi();
        private DataSet gridDataSource;

        public delegate void PassID(string value);
        public PassID passID;
        public long HopDongID = -1;

        private void SendID()
        {
                try
                {
                    passID(this.GridEX1.GetValue("ID").ToString());
                    HopDongID = long.Parse(GridEX1.GetRow().Cells["ID"].Value.ToString());
                }
                catch
                {                   
                }
        }
        public dlgHopDong()
        {
            InitializeComponent();
            CommonClass.loadTreeDonVi(treeDonVi);
            nDonVi = (NodeDonVi)treeDonVi.Nodes[0].Tag;
        }
        private DataSet LoadHopDong()
        {
            string strSQL = "SELECT * FROM tbl_HopDong WHERE 1=1";
            switch (nDonVi.Type)
            {
                case DonviType.Xa: strSQL += " AND ThonID IN (SELECT ID FROM tbl_Thon WHERE XaID=" + nDonVi.DonViID + ")"; break;
                case DonviType.Thon: strSQL += " AND ThonID=" + nDonVi.DonViID; break;
                default: break;
            }
            if (!string.IsNullOrEmpty(edtTimKiem.Text))
            {
                strSQL += " AND (MaHopDong like N'%" + DBModule.RefineString(edtTimKiem.Text) + "%' OR HoTen like N'%" + DBModule.RefineString(edtTimKiem.Text) + "%' )";
            }
            return DBModule.ExecuteQuery(strSQL, null, null);
        }

        private void CreateDataSourceAndBindGrid()
        {
            gridDataSource = this.LoadHopDong();
            if (gridDataSource.Tables.Count > 0)
            {
                this.GridEX1.SetDataBinding(gridDataSource.Tables[0], "");
            }
        }

        private void treeDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nDonVi = (NodeDonVi)treeDonVi.SelectedNode.Tag;
                this.DoLoadGridHopDong();
            }
        }
        private void DoLoadGridHopDong()
        {
            this.CreateDataSourceAndBindGrid();
            this.GridEX1.Focus();
        }

        private void treeDonVi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            nDonVi = (NodeDonVi)e.Node.Tag;
            this.DoLoadGridHopDong();
        }
        private void uiButton1_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            if (!string.IsNullOrEmpty(edtTimKiem.Text))
            {
                if (uiCheckBox1.Checked)
                {
                    nDonVi = (NodeDonVi)treeDonVi.Nodes[0].Tag;
                }
                this.DoLoadGridHopDong();
            }
        }
        private void edtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Search();
            }
        }

        private void edtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChon_Click(object sender, EventArgs e)
        {

            //this.SendID();
            HopDongID = long.Parse(GridEX1.GetRow().Cells["ID"].Value.ToString());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void GridEX1_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.btnChon_Click(null, EventArgs.Empty);
        }

        private void GridEX1_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }
    }
}