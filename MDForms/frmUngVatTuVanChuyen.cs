
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using MDSolution.MDForms;
using MDSolution.MDReport;

namespace MDSolution
{
    public partial class frmUngVatTuVanChuyen : Form
    {
        private NodeHopDongVanChuyen nHDVC = new NodeHopDongVanChuyen("-1", "Hợp Đồng Vận Chuyển", HDVCType.Root);
        
        private clsXeVanChuyen oXVC = new clsXeVanChuyen();
        private clsUngVatTuVanChuyen oUVTVC = new clsUngVatTuVanChuyen();
        private DataSet gdVXeVanChuyenSource;
        private DataSet gdVChiTietUngVatTuSource;
        private DataSet ddlVatTuVanChuyenSource;

        public frmUngVatTuVanChuyen()
        {
            InitializeComponent();
            this.LoadDDLVatTuVanChuyen();
            this.LoadDDLNoiTamUngVatTu();
            CommonClass.loadTreeHopDongVanChuyen(tvHopDongVanChuyen);
            tvHopDongVanChuyen.Focus();
        }
        public frmUngVatTuVanChuyen(string ID)
        {
            InitializeComponent();
            
            CommonClass.loadTreeHopDongVanChuyen(tvHopDongVanChuyen);
            this.LoadDDLVatTuVanChuyen();
            this.LoadDDLNoiTamUngVatTu();
            LoadgdVXeVanChuyen1(ID);
            tvHopDongVanChuyen.Focus();
        }
        private void LoadgdVXeVanChuyen1(string ID)
        {
            DataSet ds;
            string strSQL = "SELECT * FROM tbl_XeVanChuyen Where ID = " + ID.ToString();
          ds = DBModule.ExecuteQuery(strSQL, null, null);
            if (ds.Tables.Count > 0)
            {
                this.gdVXeVanChuyen.SetDataBinding(ds.Tables[0], "");
            }
        }
        private void LoadgdVXeVanChuyen()
        {
            string strSQL = "SELECT * FROM tbl_XeVanChuyen Where HopDongVanChuyenID = " + nHDVC.HopDongID;
            this.gdVXeVanChuyenSource = DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gdVXeVanChuyenSource.Tables.Count > 0)
            {
                this.gdVXeVanChuyen.SetDataBinding(this.gdVXeVanChuyenSource.Tables[0], "");
            }
        }
        private void LoadDDLVatTuVanChuyen()
        {
            string strSQL = "SELECT * FROM tbl_VatTuVanChuyen";
            this.ddlVatTuVanChuyenSource = DBModule.ExecuteQuery(strSQL, null, null);
            this.gdVChiTietUngVatTu.DropDowns["ddlVatTuVanChuyen"].SetDataBinding(this.ddlVatTuVanChuyenSource.Tables[0], "");
        }
        private void LoadDDLNoiTamUngVatTu()
        {
            string strSQL = "SELECT * FROM tbl_NoiTamUngVatTu";
            this.ddlVatTuVanChuyenSource = DBModule.ExecuteQuery(strSQL, null, null);
            this.gdVChiTietUngVatTu.DropDowns["ddlNoiTamUngVatTu"].SetDataBinding(this.ddlVatTuVanChuyenSource.Tables[0], "");
        }
        private void LoadgdVChiTietUngVanChuyen()
        {
            string strSQL = "SELECT * FROM tbl_UngVatTuVanChuyen Where XeID = " + this.gdVXeVanChuyen.GetValue("ID").ToString();
            this.gdVChiTietUngVatTuSource = DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gdVChiTietUngVatTuSource.Tables.Count > 0)
            {
                this.gdVChiTietUngVatTu.SetDataBinding(this.gdVChiTietUngVatTuSource.Tables[0], "");
            }
        }

        private void LoadgdVChiTietUngVanChuyen_ChuHD()
        {
            string strSQL = "SELECT * FROM tbl_UngVatTuVanChuyen Where VuTrongID =" + MDSolutionApp.VuTrongID.ToString() + " And HopDongVanChuyenID =" + nHDVC.HopDongID + " And (XeID IN(Select ID From tbl_XeVanChuyen Where HopDongVanChuyenID =" + nHDVC.HopDongID + ") OR XeID = 0)";
            this.gdVChiTietUngVatTuSource = DBModule.ExecuteQuery(strSQL, null, null);
            if (this.gdVChiTietUngVatTuSource.Tables.Count > 0)
            {
                this.gdVChiTietUngVatTu.SetDataBinding(this.gdVChiTietUngVatTuSource.Tables[0], "");
            }
        }

        private void gdVXeVanChuyen_SelectionChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (this.gdVXeVanChuyen.CurrentRow.RowType == Janus.Windows.GridEX.RowType.NewRecord)
            //    {
            //        //lblTB.Text = "Bạn có thể nhập số tiền bằng đơn giá nhân số lượng hoặc nhập trực tiếp vào ô số tiền ";
            //        this.gdVChiTietUngVatTu.AllowAddNew = InheritableBoolean.False;
            //    }
            //    else
            //    {
            //        //this.gdVChiTietUngVatTu.AllowAddNew = InheritableBoolean.True;
            //        this.LoadgdVChiTietUngVanChuyen();
            //    }
            //}
            //catch
            //{
            //    this.gdVChiTietUngVatTu.AllowAddNew = InheritableBoolean.False;
            //}            
        }

        private void tvHopDongVanChuyen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nHDVC = (NodeHopDongVanChuyen)tvHopDongVanChuyen.SelectedNode.Tag;
                this.LoadgdVXeVanChuyen();
            }
        }

        private void tvHopDongVanChuyen_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if(e.Node.Tag
            nHDVC = (NodeHopDongVanChuyen)e.Node.Tag;
            this.LoadgdVXeVanChuyen();
            LoadgdVChiTietUngVanChuyen_ChuHD();
        }

        private void gdVChiTietUngVatTu_AddingRecord(object sender, CancelEventArgs e)
        {
            if (!SaveUngVatTuVanChuyen(true)) { e.Cancel = true; }
            else
            {
                //MessageBox.Show("Bạn đã lưu lại thành công", "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void gdVChiTietUngVatTu_DeletingRecord(object sender, RowActionCancelEventArgs e)
        {
            string message;

            message = String.Format("Bạn muốn xóa thông tin ứng vật tư này?");

            if (MessageBox.Show(message, "Sơn La", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                clsUngVatTuVanChuyen.Delete(long.Parse(this.gdVChiTietUngVatTu.GetValue("ID").ToString()), null, null);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void gdVChiTietUngVatTu_RecordAdded(object sender, EventArgs e)
        {
            this.LoadgdVChiTietUngVanChuyen_ChuHD();
            //this.gdVChiTietUngVatTu.SetValue("ID", oUVTVC.ID);
            this.gdVChiTietUngVatTu.Refetch();
        }

        private void gdVChiTietUngVatTu_RecordsDeleted(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa thành công", "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gdVChiTietUngVatTu_RecordUpdated(object sender, EventArgs e)
        {
            this.LoadgdVChiTietUngVanChuyen_ChuHD();
            this.gdVChiTietUngVatTu.Refetch();
        }

        private void gdVChiTietUngVatTu_UpdatingRecord(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Thông tin đã bị thay đổi, bạn có muốn lưu lại không?", "Sơn La", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!SaveUngVatTuVanChuyen(false)) { e.Cancel = true; }
                else
                {
                    MessageBox.Show("Bạn đã sửa lại thành công", "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                LoadgdVChiTietUngVanChuyen_ChuHD();
                e.Cancel = true; }
        }

        private bool SaveUngVatTuVanChuyen(bool isAddNew)
        {
            try
            {
                if (isAddNew)
                {
                    oUVTVC = new clsUngVatTuVanChuyen();
                    oUVTVC.VuTrongID = MDSolutionApp.VuTrongID;
                    oUVTVC.HopDongVanChuyenID = long.Parse(nHDVC.HopDongID);
                    oUVTVC.XeID = long.Parse(this.gdVXeVanChuyen.GetValue("ID").ToString());
                }
                else
                {
                    oUVTVC = new clsUngVatTuVanChuyen(long.Parse(this.gdVChiTietUngVatTu.GetValue("ID").ToString()));
                    oUVTVC.Load(null, null);
                }
                if (string.IsNullOrEmpty(this.gdVChiTietUngVatTu.GetValue("VatTuID").ToString())) throw new Exception("Bạn chưa nhập vật tư ");

                oUVTVC.VatTuID = long.Parse(this.gdVChiTietUngVatTu.GetValue("VatTuID").ToString());
                if (string.IsNullOrEmpty(this.gdVChiTietUngVatTu.GetValue("SoLuong").ToString()))// throw new Exception("Bạn chưa nhập số lượng ");
                { oUVTVC.SoLuong = 0; }
                else
                {
                    oUVTVC.SoLuong = long.Parse(this.gdVChiTietUngVatTu.GetValue("SoLuong").ToString());
                    if (oUVTVC.SoLuong < 0) throw new Exception("Số lượng bạn nhập vào nhỏ hơn 0, kiểm tra lại");
                }
                if (string.IsNullOrEmpty(this.gdVChiTietUngVatTu.GetValue("DonGia").ToString()))// throw new Exception("Bạn chưa nhập đơn giá ");                
                { oUVTVC.DonGia = 0; }
                else
                {
                    oUVTVC.DonGia = long.Parse(this.gdVChiTietUngVatTu.GetValue("DonGia").ToString());
                    if (oUVTVC.DonGia < 0) throw new Exception("Đơn giá bạn nhập vào nhỏ hơn 0, kiểm tra lại");
                }
                if (string.IsNullOrEmpty(this.gdVChiTietUngVatTu.GetValue("SoTien").ToString())) throw new Exception("Bạn chưa nhập số tiền");                
                    oUVTVC.SoTien = long.Parse(this.gdVChiTietUngVatTu.GetValue("SoTien").ToString());
                if (oUVTVC.SoTien<0) throw new Exception("Số tiền bạn nhập vào nhỏ hơn 0, kiểm tra lại");

                decimal tempSoTien = oUVTVC.SoLuong * oUVTVC.DonGia;
                if (tempSoTien > 0 && oUVTVC.SoTien >= 0 && oUVTVC.SoTien != tempSoTien)
                {
                    if (MessageBox.Show("Số tiền " + oUVTVC.SoTien.ToString("### ### ##0") + " nhập vào khác với tổng số lượng * đơn giá : " + oUVTVC.SoLuong.ToString("### ### ##0") + "* " + oUVTVC.DonGia.ToString("### ### ##0") + "\n Bạn muốn lưu giá trị nào? Yes để lưu số tiền được nhập vào, no để lưu tổng tính toán.", "Sơn La", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        oUVTVC.SoTien = tempSoTien;
                    }
                }

                if (string.IsNullOrEmpty(this.gdVChiTietUngVatTu.GetValue("NgayUng").ToString())) throw new Exception("Bạn chưa nhập ngày ứng ");

                oUVTVC.NoiTamUngVatTuID= long.Parse(this.gdVChiTietUngVatTu.GetValue("NoiTamUngVatTuID").ToString());
                oUVTVC.NgayUng = DateTime.Parse(this.gdVChiTietUngVatTu.GetValue("NgayUng").ToString());
                oUVTVC.SoChungTu = this.gdVChiTietUngVatTu.GetValue("SoChungTu").ToString();
                oUVTVC.GhiChu = this.gdVChiTietUngVatTu.GetValue("GhiChu").ToString();
                oUVTVC.Save(null, null);                
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void frmUngVatTuVanChuyen_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void gdVChiTietUngVatTu_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            string ID = this.gdVChiTietUngVatTu.GetValue("ID").ToString();
            if (this.gdVChiTietUngVatTu.GetValue("ID").ToString() != "")
            {
                
                clsHopDongVanChuyen oHDVC=new clsHopDongVanChuyen(long.Parse(nHDVC.HopDongID));
                oHDVC.Load(null, null);
                string CHDVC_ID = oHDVC.MaHopDong.ToString();
                string XeID = this.gdVXeVanChuyen.GetValue("ID").ToString();
                long ChungTu = long.Parse(this.gdVChiTietUngVatTu.GetValue("SoChungTu").ToString());
                frmTamUngVatTu frm = new frmTamUngVatTu(CHDVC_ID,XeID,ChungTu);
                //frm.ChuHopDongVCID = nHDVC.HopDongID;
                //frm.XeID = this.gdVXeVanChuyen.GetValue("ID").ToString();
                //frm.ChungTu = this.gdVChiTietUngVatTu.GetValue("SoChungTu").ToString();
                
                frm.ShowDialog();
            }
            else { MessageBox.Show("Bạn chọn chưa đúng vật tư để xem", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }

        private void tschitiet_Click(object sender, EventArgs e)
        {
            string ID = this.gdVChiTietUngVatTu.GetValue("ID").ToString();
            if (this.gdVChiTietUngVatTu.GetValue("ID").ToString() != "")
            {

                clsHopDongVanChuyen oHDVC = new clsHopDongVanChuyen(long.Parse(nHDVC.HopDongID));
                oHDVC.Load(null, null);
                string CHDVC_ID = oHDVC.MaHopDong.ToString();
                string XeID = this.gdVXeVanChuyen.GetValue("ID").ToString();
                long ChungTu = long.Parse(this.gdVChiTietUngVatTu.GetValue("SoChungTu").ToString());
                frmTamUngVatTu frm = new frmTamUngVatTu(CHDVC_ID, XeID, ChungTu);
                //frm.ChuHopDongVCID = nHDVC.HopDongID;
                //frm.XeID = this.gdVXeVanChuyen.GetValue("ID").ToString();
                //frm.ChungTu = this.gdVChiTietUngVatTu.GetValue("SoChungTu").ToString();

                frm.ShowDialog();
            }
            else { MessageBox.Show("Bạn chọn chưa đúng vật tư để xem", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }

        private void gdVChiTietUngVatTu_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "XemChiTiet")
            {
                try
                {
                        long tong = 0;
                        long ID = long.Parse(nHDVC.HopDongID);
                        string ii = this.gdVXeVanChuyen.GetValue("ID").ToString();
                        frmShowRP2 frm = new frmShowRP2();                        
                        rp_T_PhieuUngVatTuVanChuyen3 rp1 = new rp_T_PhieuUngVatTuVanChuyen3();
                        rp1.RecordSelectionFormula = "{tbl_HopDongVanChuyen.ID}=" + ID.ToString() + " and {tbl_XeVanChuyen.ID}=" + ii.ToString() + " and {tbl_UngVatTuVanChuyen.SoChungTu}= '" + this.gdVChiTietUngVatTu.GetValue("SoChungTu").ToString() + "'"; ;
                        rp1.Database.Tables[0].ApplyLogOnInfo(frm.tblogon);
                        frm.RP = rp1;
                        foreach (GridEXRow jr in this.gdVChiTietUngVatTu.GetRows())
                        {
                            if (jr.Cells["SoChungTu"].Value.ToString() == this.gdVChiTietUngVatTu.GetValue("SoChungTu").ToString())
                            {
                                tong = tong + long.Parse(jr.Cells["SoTien"].Value.ToString());
                            }
                        }
                        frm.TongTien = Convert.ToInt64(tong.ToString());
                        frm.RPtitle = "Phiếu tạm ứng vật tư vận chuyển";
                        frm.Show();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Sơn La", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                //if (e.Column.Key == "XemChiTiet")
                //{
                //    try
                //    {
                //        string ID = this.gdVChiTietUngVatTu.GetValue("ID").ToString();
                //        if (this.gdVChiTietUngVatTu.GetValue("ID").ToString() != "")
                //        {

                //            clsHopDongVanChuyen oHDVC = new clsHopDongVanChuyen(long.Parse(nHDVC.HopDongID));
                //            oHDVC.Load(null, null);
                //            string CHDVC_ID = oHDVC.MaHopDong.ToString();
                //            string XeID = this.gdVXeVanChuyen.GetValue("ID").ToString();
                //            long ChungTu = long.Parse(this.gdVChiTietUngVatTu.GetValue("SoChungTu").ToString());
                //            frmTamUngVatTu frm = new frmTamUngVatTu(CHDVC_ID, XeID, ChungTu);

                //            frm.ShowDialog();
                //        }
                //        else { MessageBox.Show("Bạn chọn chưa đúng vật tư để xem", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                //    }
                //    catch
                //    {
                //        MessageBox.Show("Có lỗi khi xem chi tiết", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    }
                //}
            }
        }

        private void tvHopDongVanChuyen_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //label1.Text = tvHopDongVanChuyen.SelectedNode.Text;
            nHDVC = (NodeHopDongVanChuyen)e.Node.Tag;
            this.LoadgdVXeVanChuyen();
        }

        private void gdVXeVanChuyen_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }

        private void gdVChiTietUngVatTu_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }     

    }
}
