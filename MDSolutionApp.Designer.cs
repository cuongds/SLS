using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace MDSolution
{
	public partial class MDSolutionApp : System.ComponentModel.Component
	{

		[System.Diagnostics.DebuggerNonUserCode()]
		public MDSolutionApp(System.ComponentModel.IContainer Container)
		{

			//Required for Windows.Forms Class Composition Designer support
			Container.Add(this);

		}

		[System.Diagnostics.DebuggerNonUserCode()]
		public MDSolutionApp() : base()
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
        }	


	}

} //end of root namespace