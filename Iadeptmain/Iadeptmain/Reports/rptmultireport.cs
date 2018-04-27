using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Iadeptmain.GlobalClasses;

namespace Iadeptmain.Reports
{
    public partial class rptmultireport : DevExpress.XtraReports.UI.XtraReport
    {
        public rptmultireport()
        {
            InitializeComponent();
        }

        private void xrTableCell2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
