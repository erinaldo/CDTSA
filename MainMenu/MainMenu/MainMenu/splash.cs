using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace CDTSA
{
    public partial class splash : SplashScreen
    {
        public splash()
        {
            InitializeComponent();
            this.labelControl1.Text = String.Format("{0}{1}", this.labelControl1.Text,GetYearString());
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        private int GetYearString(){
            int ret = DateTime.Now.Year;
            return (ret<2017)? 2017:ret;
        }
        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}