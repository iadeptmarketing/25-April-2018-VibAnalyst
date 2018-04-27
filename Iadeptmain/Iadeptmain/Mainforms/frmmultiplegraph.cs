using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Iadeptmain.GlobalClasses;

namespace Iadeptmain.Mainforms
{
    public partial class frmmultiplegraph : DevExpress.XtraEditors.XtraForm
    {
        public frmmultiplegraph()
        {
            InitializeComponent();
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

        int Number_of_Graphs = 2;
        public int _NumberofGraphs
        {
            get
            {
                return Number_of_Graphs;
            }
            set
            {
                Number_of_Graphs = value;
            }
        }

        int Band1 = 0;
        public int _Band1
        {
            get
            {
                return Band1;
            }
            set
            {
                Band1 = value;
            }
        }

        int Band2 = 0;
        public int _Band2
        {
            get
            {
                return Band2;
            }
            set
            {
                Band2 = value;
            }
        }

        int Band3 = 0;
        public int _Band3
        {
            get
            {
                return Band3;
            }
            set
            {
                Band3 = value;
            }
        }

        int Band4 = 0;
        public int _Band4
        {
            get
            {
                return Band4;
            }
            set
            {
                Band4 = value;
            }
        }


        int Band5 = 0;
        public int _Band5
        {
            get
            {
                return Band5;
            }
            set
            {
                Band5 = value;
            }
        }

        int Band6 = 0;
        public int _Band6
        {
            get
            {
                return Band6;
            }
            set
            {
                Band6 = value;
            }
        }

        int Band7 = 0;
        public int _Band7
        {
            get
            {
                return Band7;
            }
            set
            {
                Band7 = value;
            }
        }

        int Band8 = 0;
        public int _Band8
        {
            get
            {
                return Band8;
            }
            set
            {
                Band8 = value;
            }
        }
        private void btnok_Click(object sender, EventArgs e)
        {
            try
            {
                bool sstatus = chkValue();
                if (sstatus)
                {
                    ShouldDraw = true;
                    try { Band1 = Convert.ToInt32(txtHAxial.Text.Trim()); }
                    catch { }
                    try { Band2 = Convert.ToInt32(txtLAxial.Text.Trim()); ; }
                    catch { }
                    try { Band3 = Convert.ToInt32(txtHHorizontal.Text.Trim()); }
                    catch { }
                    try { Band4 = Convert.ToInt32(txtLHorizontal.Text.Trim()); }
                    catch { }
                    try { Band5 = Convert.ToInt32(txtHVertical.Text.Trim()); }
                    catch { }
                    try { Band6 = Convert.ToInt32(txtLVertical.Text.Trim()); }
                    catch { }
                    try { Band7 = Convert.ToInt32(txtHCh1.Text.Trim()); }
                    catch { }
                    try { Band8 = Convert.ToInt32(txtLCh1.Text.Trim()); }
                    catch { }
                    this.Close();
                }
                else
                {

                }

            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ShouldDraw = false;
                this.Close();
            }
            catch { }
        }
        public int val = Convert.ToInt32(PublicClass.chartscale);
        private bool chkValue()
        {
            bool status = false;
            try
            {
                string hAxial = Convert.ToString(PublicClass.DefVal(txtHAxial.Text, "0"));
                string lAxial = Convert.ToString(PublicClass.DefVal(txtLAxial.Text, "0"));
                string hHorizontal = Convert.ToString(PublicClass.DefVal(txtHHorizontal.Text, "0"));
                string lHorizontal = Convert.ToString(PublicClass.DefVal(txtLHorizontal.Text, "0"));
                string hVertical = Convert.ToString(PublicClass.DefVal(txtHVertical.Text, "0"));
                string lVertical = Convert.ToString(PublicClass.DefVal(txtLVertical.Text, "0"));
                string hCh1 = Convert.ToString(PublicClass.DefVal(txtHCh1.Text, "0"));
                string lCh1 = Convert.ToString(PublicClass.DefVal(txtLCh1.Text, "0"));
                if (hAxial == "0" && hHorizontal == "0" && hVertical == "0" && hCh1 == "0")//&& hHorizontal == "" && lHorizontal == "" && hVertical == "" && lVertical == "" && hCh1 == "" && lCh1 == "")
                {
                    MessageBox.Show(this, "Fill atleast one direction value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return status = false;
                }
                if (lAxial == "0" && lHorizontal == "0" && lVertical == "0" && lCh1 == "0")//&& hHorizontal == "" && lHorizontal == "" && hVertical == "" && lVertical == "" && hCh1 == "" && lCh1 == "")
                {
                    MessageBox.Show(this, "Fill atleast one direction value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return status = false;
                }
                if (((hAxial != "0" && lAxial == "0") || (hAxial == "0" && lAxial != "0")))
                {
                    MessageBox.Show(this, "Fill both axis values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return status = false;
                }
                else if ((hHorizontal != "0" && lHorizontal == "0") || (hHorizontal == "0" && lHorizontal != "0"))
                {
                    MessageBox.Show(this, "Fill both axis values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return status = false;
                }
                else if ((hVertical != "0" && lVertical == "0") || (hVertical == "0" && lVertical != "0"))
                {
                    MessageBox.Show(this, "Fill both axis values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return status = false;
                }
                else if ((hCh1 != "0" && lCh1 == "0") || (hCh1 == "0" && lCh1 != "0"))
                {
                    MessageBox.Show(this, "Fill both axis values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return status = false;
                }
                else
                {
                }
                try
                {
                    if ((Convert.ToInt32(hAxial) < Convert.ToInt32(lAxial)) || (Convert.ToInt32(hHorizontal) < Convert.ToInt32(lHorizontal)) || (Convert.ToInt32(hVertical) < Convert.ToInt32(lVertical)) || ((Convert.ToInt32(hAxial) < Convert.ToInt32(lAxial))))
                    {
                        MessageBox.Show(this, "High value must be greater than low value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtHCh1.Text = ""; txtHVertical.Text = ""; txtLVertical.Text = ""; txtHHorizontal.Text = ""; txtHAxial.Text = ""; txtLAxial.Text = ""; txtLHorizontal.Text = ""; txtLCh1.Text = "";
                        status = false;
                    }
                    else
                    {
                        if (((Convert.ToInt32(hAxial) == val) || (Convert.ToInt32(hAxial) < val)) && ((Convert.ToInt32(hHorizontal) == val) || (Convert.ToInt32(hHorizontal) < val)) && ((Convert.ToInt32(hVertical) == val) || (Convert.ToInt32(hVertical) < val)) && ((Convert.ToInt32(hCh1) == val) || (Convert.ToInt32(hCh1) < val)))
                        {
                            if (txtHAxial.Enabled == true)
                            {
                                try
                                {
                                    if ((Convert.ToInt32(hAxial) >= Convert.ToInt32(lAxial)))
                                    {
                                        status = true;
                                    }
                                }
                                catch { }
                            }
                            if (txtHHorizontal.Enabled == true)
                            {
                                try
                                {

                                    if ((Convert.ToInt32(hHorizontal) >= Convert.ToInt32(lHorizontal)))
                                    {
                                        status = true;
                                    }
                                }
                                catch { }
                            }
                            if (txtHVertical.Enabled == true)
                            {
                                try
                                {
                                    if ((Convert.ToInt32(hVertical) >= Convert.ToInt32(lVertical)))
                                    {
                                        status = true;
                                    }
                                }
                                catch { }
                            }
                            if (txtHCh1.Enabled == true)
                            {
                                try
                                {
                                    if ((Convert.ToInt32(hAxial) >= Convert.ToInt32(lAxial)))
                                    {
                                        status = true;
                                    }
                                }
                                catch { }
                            }
                            // status = true;
                        }
                        else
                        {
                            MessageBox.Show(this, "High value must be equals to or less than='" + val + "' ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtHCh1.Text = ""; txtHVertical.Text = ""; txtLVertical.Text = ""; txtHHorizontal.Text = ""; txtHAxial.Text = ""; txtLAxial.Text = ""; txtLHorizontal.Text = ""; txtLCh1.Text = "";
                            status = false;
                        }
                    }
                }
                catch { }
                return status;
            }
            catch { }
            return status;
        }
        private void txtHAxial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void frmmultiplegraph_Load(object sender, EventArgs e)
        {
            try
            {
                string[] sarrpath = null;
                sarrpath = PublicClass.checkdirection.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < sarrpath.Length; i++)
                {
                    string aa = sarrpath[i];
                    if (aa == "Axial")
                    {
                        txtHAxial.Enabled = true;
                        txtLAxial.Enabled = true;
                    }
                    if (aa == "Horizontal")
                    {
                        txtHHorizontal.Enabled = true;
                        txtLHorizontal.Enabled = true;
                    }
                    if (aa == "Vertical")
                    {
                        txtHVertical.Enabled = true;
                        txtLVertical.Enabled = true;
                    }
                    if (aa == "Channel1")
                    {
                        txtHCh1.Enabled = true;
                        txtLCh1.Enabled = true;
                    }
                }

            }
            catch
            { }
        }
     }
}
        
