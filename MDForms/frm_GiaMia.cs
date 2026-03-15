using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDSolution.MDForms;
using Janus.Windows.GridEX;

namespace MDSolution
{
    public partial class frm_GiaMia : Form
    {
        private DataSet gridDataSource;
        long IDTinh = 1;
        static frm_GiaMia _thefrm_GiaMia;

        /// <summary>
        /// Gets the one and only instance of Form1.
        /// </summary>
        static public frm_GiaMia OneInstanceFrm
        {
            get
            {
                if (null == _thefrm_GiaMia || _thefrm_GiaMia.IsDisposed)
                {
                    _thefrm_GiaMia = new frm_GiaMia();
                }

                return _thefrm_GiaMia;
            }
        }
        public frm_GiaMia()
        {
            InitializeComponent();
            LoadMainGrid();
        }
      
        private void LoadMainGrid()
        {
            string strSQL = "SELECT * FROM tbl_GiaNhapMia WHERE VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " Order By NgayGioApDung DESC";
                this.gridDataSource = DBModule.ExecuteQuery(strSQL, null, null);
                if (this.gridDataSource.Tables.Count > 0)
                {
                    this.gdThongBaoGia.SetDataBinding(this.gridDataSource.Tables[0], "RootTable");
                }
                else
                {
                    this.gdThongBaoGia.DataSource = null;
                }
            
        }


        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void tabGiaMia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabGiaMia.SelectedIndex == 0)
            {
                LoadMainGrid();
            }
            if (tabGiaMia.SelectedIndex == 1)
            {

            }
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            frm_NhapTB_GiaMia frm = new frm_NhapTB_GiaMia();
            frm.ShowDialog();
            int iOK = frm.OK;
            long ID = frm.MaxID;
            if (iOK == 1)
            {
                LoadMainGrid();
                GridEXFilterCondition condi = new GridEXFilterCondition(gdThongBaoGia.Tables[0].Columns["ID"], ConditionOperator.Equal, ID);
                gdThongBaoGia.Find(condi, 0, 1);
            }
        }


        private void gdMainGrid_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            long ID = 0;
            try
            {
                ID = long.Parse(this.gdThongBaoGia.GetValue("ID").ToString());
            }
            catch
            {
                ID = 0;
            }
            if (ID > 0)
            {
                if (e.Column.Key == "Sua")
                {
                    frm_NhapTB_GiaMia frm = new frm_NhapTB_GiaMia(ID);
                    frm.ShowDialog();
                    if (frm.OK == 1)
                    {
                        LoadMainGrid();
                        GridEXFilterCondition condi = new GridEXFilterCondition(gdThongBaoGia.Tables[0].Columns["ID"], ConditionOperator.Equal, ID);
                        gdThongBaoGia.Find(condi, 0, 1);
                    }
                }
              
            }
        }

        private void cmdChiTetTB_Click(object sender, EventArgs e)
        {
            long IDThongBao = 0;
            string TenTB = "";
            try
            {
                TenTB = this.gdThongBaoGia.GetValue("TenThongBao").ToString();
                IDThongBao = long.Parse(this.gdThongBaoGia.GetValue("ID").ToString());
            }
            catch
            {
                IDThongBao = 0;
                TenTB = "";
            }
            if (IDThongBao > 0)
            {
                frm_NhapTB_GiaMiaChay frm = new frm_NhapTB_GiaMiaChay(IDThongBao, TenTB);
                frm.ShowDialog();
                if (frm.OK == 1)
                {
                    this.Load_ChiTiet_TB(IDThongBao);
                    GridEXFilterCondition condi = new GridEXFilterCondition(gdGiaMiaChay.Tables[0].Columns["ID"], ConditionOperator.Equal, frm.MaxID);
                    gdGiaMiaChay.Find(condi, 0, 1);
                }
            }
        }

        private void gdThongBaoGia_SelectionChanged(object sender, EventArgs e)
        {

            long IDThongBao = 0;
            try
            {
                IDThongBao = long.Parse(this.gdThongBaoGia.GetValue("ID").ToString());
            }
            catch
            {
                IDThongBao = 0;
                this.gdGiaMiaChay.DataSource = null;
                return;
            }
            Load_ChiTiet_TB(IDThongBao);
        }
        private void Load_ChiTiet_TB(long ID)
        {
            string sql = "Select * From V_GiaMiaChay Where VuTrongID=" + MDSolutionApp.VuTrongID.ToString() + " AND ThongBaoID=" + ID.ToString();
            DataSet ds = DBModule.ExecuteQuery(sql, null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.gdGiaMiaChay.SetDataBinding(ds.Tables[0], "");
            }
            else
            {
                gdGiaMiaChay.DataSource = null;
            }
        }

        private void frm_GiaMia_Load(object sender, EventArgs e)
        {
            lblTitle.Text = lblTitle.Text + MDSolutionApp.VuTrongTen;
        }

        private void gdChiThietThongBaoGia_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            long ID = 0;
            long TBID = 0;
            try
            {
                ID = long.Parse(this.gdGiaMiaChay.GetValue("ID").ToString());
                TBID = long.Parse(this.gdGiaMiaChay.GetValue("ThongBaoID").ToString());
            }
            catch
            {
                ID = 0;
                TBID = 0;
                return;
            }
            if (ID > 0)
            {
                if (e.Column.Key == "Sua")
                {
                    frm_NhapTB_GiaMiaChay frm = new frm_NhapTB_GiaMiaChay(ID, TBID);
                    frm.ShowDialog();
                    if (frm.OK == 1)
                    {
                        Load_ChiTiet_TB(TBID);
                        GridEXFilterCondition condi = new GridEXFilterCondition(gdGiaMiaChay.Tables[0].Columns["ID"], ConditionOperator.Equal, ID);
                        gdGiaMiaChay.Find(condi, 0, 1);
                    }
                }

            }
        }

      

    }
}
