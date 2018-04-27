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
    public partial class frmValues : DevExpress.XtraEditors.XtraForm
    {
        public frmValues()
        {
            InitializeComponent();
            this.lblValues.Text = "Values:";
        }
        public string Values
        {
            set
            {
                lblValues.Text = value;
            }

        }

        int value;
        public int _value
        {
            get
            {
                return value;
            }
        }

        bool ShouldDraw = false;
        public bool _ShouldDraw
        {
            get
            {
                return ShouldDraw;
            }
            set
            {
                ShouldDraw = value;
            }
        }


        private void btnok_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkgrp1.Checked == true)
                {
                    value = 1;
                }
                else if (chkgrp2.Checked == true)
                {
                    value = 2;
                }
                else if (chkgrp3.Checked == true)
                {
                    value = 3;
                }
                ShouldDraw = true;
            }
            catch { }
            this.Close();
        }
    }
}