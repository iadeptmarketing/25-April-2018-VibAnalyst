using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Iadeptmain.Mainforms
{
    public partial class frmabout : DevExpress.XtraEditors.XtraForm
    {
        public frmabout()
        {
            InitializeComponent();
        }

        private void frmabout_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch { }
        }
    }
}