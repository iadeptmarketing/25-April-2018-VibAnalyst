using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Iadeptmain.Mainforms
{
    public partial class MultigraphSelection : Form
    {
        public MultigraphSelection()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 3;

            string[] selectedstring = cbBand1.SelectedItem.ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Band1 = Convert.ToInt32(selectedstring[0].ToString());

            selectedstring = cbBand2.SelectedItem.ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Band2 = Convert.ToInt32(selectedstring[0].ToString());

            selectedstring = cbBand3.SelectedItem.ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Band3 = Convert.ToInt32(selectedstring[0].ToString());

            selectedstring = cbBand4.SelectedItem.ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Band4 = Convert.ToInt32(selectedstring[0].ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        lblBand2.Visible = false;
                        cbBand2.Visible = false;

                        lblBand3.Visible = false;
                        cbBand3.Visible = false;

                        lblBand4.Visible = false;
                        cbBand4.Visible = false;

                        Number_of_Graphs = 1;
                        break;
                    }
                case 1:
                    {
                        lblBand2.Visible = true;
                        cbBand2.Visible = true;

                        lblBand3.Visible = false;
                        cbBand3.Visible = false;

                        lblBand4.Visible = false;
                        cbBand4.Visible = false;

                        Number_of_Graphs = 2;
                        break;
                    }
                case 2:
                    {
                        lblBand2.Visible = true;
                        cbBand2.Visible = true;

                        lblBand3.Visible = true;
                        cbBand3.Visible = true;

                        lblBand4.Visible = false;
                        cbBand4.Visible = false;

                        Number_of_Graphs = 3;
                        break;
                    }
                case 3:
                    {
                        lblBand2.Visible = true;
                        cbBand2.Visible = true;

                        lblBand3.Visible = true;
                        cbBand3.Visible = true;

                        lblBand4.Visible = true;
                        cbBand4.Visible = true;

                        Number_of_Graphs = 4;
                        break;
                    }
            }
        }
        int Number_of_Graphs = 4;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            ShouldDraw = true;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShouldDraw = false;
            this.Close();
        }

        private void cbBand1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] selectedstring = cbBand1.SelectedItem.ToString().Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries);

            Band1 = Convert.ToInt32(selectedstring[0].ToString());
            if (selectedstring[1].ToString() == "KHz")
            {
                Band1 *= 1000;
            }
        }

        private void cbBand2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] selectedstring = cbBand2.SelectedItem.ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Band2 = Convert.ToInt32(selectedstring[0].ToString());
            if (selectedstring[1].ToString() == "KHz")
            {
                Band2 *= 1000;
            }
        }

        private void cbBand3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] selectedstring = cbBand3.SelectedItem.ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Band3 = Convert.ToInt32(selectedstring[0].ToString());
            if (selectedstring[1].ToString() == "KHz")
            {
                Band3 *= 1000;
            }
        }

        private void cbBand4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] selectedstring = cbBand4.SelectedItem.ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Band4 = Convert.ToInt32(selectedstring[0].ToString());
            if (selectedstring[1].ToString() == "KHz")
            {
                Band4 *= 1000;
            }
        }
    }
}
