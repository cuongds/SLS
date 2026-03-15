using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace MDSolution
{
	public partial class MDSolutionAppN : System.ComponentModel.Component
	{

		[System.Diagnostics.DebuggerNonUserCode()]
		public MDSolutionAppN(System.ComponentModel.IContainer Container)
		{

			//Required for Windows.Forms Class Composition Designer support
			Container.Add(this);

		}

		[System.Diagnostics.DebuggerNonUserCode()]
        public MDSolutionAppN()
            : base()
		{

			//This call is required by the Component Designer.
			InitializeComponent();

		}

		//Component overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		//Required by the Component Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Component Designer
		//It can be modified using the Component Designer.
		//Do not modify it using the code editor.
		private void InitializeComponent()
		{
            this.hopDongTrongMiaDataSet1 = new MDSolution.MDDataSet.HopDongTrongMiaDataSet();
            this.hopDongVanChuyenDataSet1 = new MDSolution.MDDataSet.HopDongVanChuyenDataSet();
            this.tbl_HopDongTableAdapter1 = new MDSolution.MDDataSet.HopDongTrongMiaDataSetTableAdapters.tbl_HopDongTableAdapter();
            this.tbl_DauTuTableAdapter1 = new MDSolution.MDDataSet.HopDongTrongMiaDataSetTableAdapters.tbl_DauTuTableAdapter();
            this.tbl_HoTroTableAdapter1 = new MDSolution.MDDataSet.HopDongTrongMiaDataSetTableAdapters.tbl_HoTroTableAdapter();
            this.tbl_ThuaRuongTableAdapter1 = new MDSolution.MDDataSet.HopDongTrongMiaDataSetTableAdapters.tbl_ThuaRuongTableAdapter();
            this.tbl_HopDongVanChuyenTableAdapter1 = new MDSolution.MDDataSet.HopDongVanChuyenDataSetTableAdapters.tbl_HopDongVanChuyenTableAdapter();
            //this.tbl_XeVanChuyenTableAdapter1 = new MDSolution.MDDataSet.HopDongVanChuyenDataSetTableAdapters.tbl_XeVanChuyenTableAdapter();
            //this.tbl_UngVatTuVanChuyenTableAdapter1 = new MDSolution.MDDataSet.HopDongVanChuyenDataSetTableAdapters.tbl_UngVatTuVanChuyenTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.hopDongTrongMiaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hopDongVanChuyenDataSet1)).BeginInit();
            // 
            // hopDongTrongMiaDataSet1
            // 
            this.hopDongTrongMiaDataSet1.DataSetName = "HopDongTrongMiaDataSet";
            this.hopDongTrongMiaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hopDongVanChuyenDataSet1
            // 
            this.hopDongVanChuyenDataSet1.DataSetName = "HopDongVanChuyenDataSet";
            this.hopDongVanChuyenDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_HopDongTableAdapter1
            // 
            this.tbl_HopDongTableAdapter1.ClearBeforeFill = true;
            // 
            // tbl_DauTuTableAdapter1
            // 
            this.tbl_DauTuTableAdapter1.ClearBeforeFill = true;
            // 
            // tbl_HoTroTableAdapter1
            // 
            this.tbl_HoTroTableAdapter1.ClearBeforeFill = true;
            // 
            // tbl_ThuaRuongTableAdapter1
            // 
            this.tbl_ThuaRuongTableAdapter1.ClearBeforeFill = true;
            // 
            // tbl_HopDongVanChuyenTableAdapter1
            // 
            this.tbl_HopDongVanChuyenTableAdapter1.ClearBeforeFill = true;
            // 
            // tbl_XeVanChuyenTableAdapter1
            // 
            //this.tbl_XeVanChuyenTableAdapter1.ClearBeforeFill = true;
            // 
            // tbl_UngVatTuVanChuyenTableAdapter1
            // 
            //this.tbl_UngVatTuVanChuyenTableAdapter1.ClearBeforeFill = true;
            ((System.ComponentModel.ISupportInitialize)(this.hopDongTrongMiaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hopDongVanChuyenDataSet1)).EndInit();

        }

        private MDSolution.MDDataSet.HopDongTrongMiaDataSet hopDongTrongMiaDataSet1;
        private MDSolution.MDDataSet.HopDongVanChuyenDataSet hopDongVanChuyenDataSet1;
        private MDSolution.MDDataSet.HopDongTrongMiaDataSetTableAdapters.tbl_HopDongTableAdapter tbl_HopDongTableAdapter1;
        private MDSolution.MDDataSet.HopDongTrongMiaDataSetTableAdapters.tbl_DauTuTableAdapter tbl_DauTuTableAdapter1;
        private MDSolution.MDDataSet.HopDongTrongMiaDataSetTableAdapters.tbl_HoTroTableAdapter tbl_HoTroTableAdapter1;
        private MDSolution.MDDataSet.HopDongTrongMiaDataSetTableAdapters.tbl_ThuaRuongTableAdapter tbl_ThuaRuongTableAdapter1;
        private MDSolution.MDDataSet.HopDongVanChuyenDataSetTableAdapters.tbl_HopDongVanChuyenTableAdapter tbl_HopDongVanChuyenTableAdapter1;
        //private MDSolution.MDDataSet.HopDongVanChuyenDataSetTableAdapters.tbl_XeVanChuyenTableAdapter tbl_XeVanChuyenTableAdapter1;
        //private MDSolution.MDDataSet.HopDongVanChuyenDataSetTableAdapters.tbl_UngVatTuVanChuyenTableAdapter tbl_UngVatTuVanChuyenTableAdapter1;	


	}

} //end of root namespace