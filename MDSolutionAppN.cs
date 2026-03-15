using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace MDSolution
{
    public partial class MDSolutionAppN
    {
        public static string MessageCaption = "MD Solution - Hello";
        public static long iVuTrongID = 1;       
        public static clsUser iUser;      

        //Khoi tao cac form de dung 
        //private 
        private MDSolution.MDDataSetForms.frmHopDongMia_ThemMoi mfrmHopDongMia_ThemMoi;
        public static MDSolution.MDDataSetForms.frmHopDongMia_ThemMoi HopDongMia_ThemMoi
        {
            get
            {
                if (mApplication == null)
                {
                    return null;
                }
                return mApplication.mfrmHopDongMia_ThemMoi;
            }
        }
        private MainForm mMainForm;
        public static MainForm MainForm
        {
            get
            {
                if (mApplication == null)
                {
                    return null;
                }
                return mApplication.mMainForm;
            }
        }

        private static MDSolutionAppN mApplication;


        //Khoi tao cac dataset 

        public static void Initialize()
        {
            try
            {
                frmLogin frm = new frmLogin();
                DialogResult result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    frmSplashScreen splash = new frmSplashScreen();
                    splash.Show();
                    splash.Update();

                    mApplication = new MDSolutionAppN();
                    mApplication.mMainForm = new MainForm();
                    mApplication.mfrmHopDongMia_ThemMoi = new MDSolution.MDDataSetForms.frmHopDongMia_ThemMoi();

                    splash.Close();
                    splash.Dispose();

                    Application.Run(mApplication.mMainForm);

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        public static MDSolutionAppN MDSolutionApplication
        {
            get
            {
                return mApplication;
            }
        }

    }

} //end of root namespace