using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Drawing2D;

using System.Threading;
using Iadeptmain.GlobalClasess;

namespace Iadeptmain.Mainforms
{
    public partial class frmsplash1 : DevExpress.XtraEditors.XtraForm
    {
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        public frmsplash1()
        {
            InitializeComponent();
            SetAndStartTimer();
        }
        private void SetAndStartTimer()
        {
            t.Interval = 5000;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }
        private void t_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}