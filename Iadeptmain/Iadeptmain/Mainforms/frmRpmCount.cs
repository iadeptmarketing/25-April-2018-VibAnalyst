using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using Iadeptmain.Mainforms;
using Iadeptmain.GlobalClasses;

namespace Iadeptmain.Mainforms
{
    public partial class frmRpmCount : DevExpress.XtraEditors.XtraForm
    {
        public frmRpmCount()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 2;
        }
        int RPMCount = 100;
        public int _RPMCount
        {
            get
            {
                return RPMCount;
            }
        }
        int value;
        double refValue;
        public double _refValue
        {
            get
            {
                return refValue;
            }
        }

        int count;
        int refcount;
        public int _refcount
        {
            get
            {
                return refcount;
            }
        }


        public int _Value
        {
            get
            {
                return value;
            }
        }

        string Overall = null;
        public string _overall
        {
            get
            {
                return Overall;
            }
        }


        public int GetCount()
        {
            int Count = 4;
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "Select * from RpmCount");
                foreach (DataRow dr in dt.Rows)
                {
                    Count = (int)dr["Count"];
                }
            }
            catch
            {
            }
            return Count;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ShouldDraw = true;
                RPMCount = Convert.ToInt32(comboBox1.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
            }
            this.Close();
        }
        public string _HeaderText
        {
            set
            {
                this.Text = value;
            }
        }
        public string _LabelText
        {
            set
            {
                label1.Text = value;
            }
        }

        private void btnoverall_Click(object sender, EventArgs e)
        {
            try
            {
                ShouldDraw = true;                
                Overall = cmboverall.SelectedItem.ToString();
            }
            catch { }
            this.Close();
        }

        private void frmRpmCount_Load(object sender, EventArgs e)
        {
            if (PublicClass.flag == true && PublicClass.checkname == "Gauge")
            {
                cmboverall.Visible = true;
                labelControl1.Visible = true;
                btnoverall.Visible = true;
                label2.Visible = false;
                label1.Visible = false;
                comboBox1.Visible = false;
                button1.Visible = false;
                txtvalue.Visible = false;
                btnvalue.Visible = false;
                lblvalue.Visible = false;
                lbluff.Visible = false;
                txtuff.Visible = false;
                btnuff.Visible = false;
                btnok.Visible = false;
                cmbharmonic.Visible = false;
                lblharmonic.Visible = false;
            }
            else if (PublicClass.flag == true && PublicClass.checkname == "Refrence Cursor")
            {
                cmboverall.Visible = false;
                labelControl1.Visible = false;
                btnoverall.Visible = false;
                label2.Visible = false;
                label1.Visible = false;
                comboBox1.Visible = false;
                button1.Visible = false;
                txtvalue.Visible = true;
                btnvalue.Visible = true;
                lblvalue.Visible = true;
                lbluff.Visible = false;
                txtuff.Visible = false;
                btnuff.Visible = false;
                btnok.Visible = false;
                cmbharmonic.Visible = false;
                lblharmonic.Visible = false;
            }
            else if (PublicClass.flag == true && PublicClass.checkname == "Harmonic")
            {
                cmboverall.Visible = false;
                labelControl1.Visible = false;
                btnoverall.Visible = false;
                label2.Visible = false;
                label1.Visible = false;
                comboBox1.Visible = false;
                button1.Visible = false;
                txtvalue.Visible = true;
                btnvalue.Visible = true;
                lblvalue.Visible = true;
                lbluff.Visible = false;
                txtuff.Visible = false;
                btnuff.Visible = false;
                btnok.Visible = false;
                cmbharmonic.Visible = true;
                lblharmonic.Visible = true;
            }
            else if (PublicClass.flag == true && PublicClass.checkname == "UFF OR WAV")
            {
                cmboverall.Visible = false;
                labelControl1.Visible = false;
                btnoverall.Visible = false;
                label2.Visible = false;
                label1.Visible = false;
                comboBox1.Visible = false;
                button1.Visible = false;
                txtvalue.Visible = false;
                btnvalue.Visible = false;
                lblvalue.Visible = false;
                lbluff.Visible = true;
                txtuff.Visible = true;
                btnuff.Visible = true;
                btnok.Visible = true;
                cmbharmonic.Visible = false;
                lblharmonic.Visible = false;
            }
            else
            {
                cmboverall.Visible = false;
                labelControl1.Visible = false;
                btnoverall.Visible = false;
                label2.Visible = true;
                label1.Visible = true;
                comboBox1.Visible = true;
                button1.Visible = true;
                txtvalue.Visible = false;
                btnvalue.Visible = false;
                lblvalue.Visible = false;
                lbluff.Visible = false;
                txtuff.Visible = false;
                btnuff.Visible = false;
                btnok.Visible = false;
                cmbharmonic.Visible = false;
                lblharmonic.Visible = false;
            }
            PublicClass.flag = false;
            // PublicClass.checkname = "";
        }

        private void btnvalue_Click(object sender, EventArgs e)
        {
            try
            {               
                if (PublicClass.checkname == "Harmonic")
                {
                    if (txtvalue.Text != "" && cmbharmonic.Text != "")
                    {
                        Overall = "Value" + "=" + txtvalue.Text;
                        refValue = Convert.ToDouble(txtvalue.Text);
                        refcount = Convert.ToInt32(cmbharmonic.Text);
                        this.Close();
                    }
                    else
                    {
                        if (txtvalue.Text == "")
                        {
                            MessageBox.Show(this, "Enter Refrence Value", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            MessageBox.Show(this, "Select Any Harmonic Value", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                else
                {
                    if (txtvalue.Text == "")
                    {
                        Overall = "0";
                    }
                    else
                    {
                        double aa = Convert.ToDouble(txtvalue.Text);
                        double bb = Convert.ToDouble(PublicClass.chartscale);
                        if (aa < bb)
                        {
                            Overall = "Value" + "=" + txtvalue.Text;
                            refValue = Convert.ToDouble(txtvalue.Text);
                            this.Close();
                        }
                        else
                        {
                            Overall = "";
                        }
                    }
                }
            }
            catch { }
           
        }
        
        string dbName = null;
        public string spath = null;
        private string GetFilePath()
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "UFF File (.uff)|*.uff|WAV File (.wav)|*.wav|FFT File (.fft)|*.fft";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.DefaultExt = ".uff";
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.ShowDialog();
                spath = openFileDialog1.FileName.ToString();
                string[] sfilepath = spath.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                dbName = sfilepath[sfilepath.Length - 1];
                if (!string.IsNullOrEmpty(spath))
                {
                    txtuff.Text = dbName;
                    btnok.PerformClick();
                }
            }
            catch { }
            return spath;
        }



        private void btnuff_Click(object sender, EventArgs e)
        {
            try
            {
                spath = GetFilePath();
            }
            catch
            { }
        }
        public string wavuff = null;
        private void btnok_Click(object sender, EventArgs e)
        {
            try
            {
                ShouldDraw = true;
                string[] sfilepath = dbName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                dbName = sfilepath[sfilepath.Length - 1];
                if (dbName == "wav")
                {
                    wavuff = "WAVFile";
                }
                else if (dbName == "uff")
                {
                    wavuff = "UFFFile";
                }
                else if (dbName == "ba2")
                {
                    wavuff = "BA2File";
                }
                else if (dbName == "fft")
                { wavuff = "FFTFile"; }
                else
                {
                    MessageBox.Show(this, "Selected Wrong File", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.Close();
            }
            catch
            {
                MessageBox.Show(this, "Select Uff & Wav File", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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

        private void frmRpmCount_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ShouldDraw = false;
            }
            catch { }
        }

        private void txtvalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.')
                {
                    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                    {
                        e.Handled = true;
                    }
                    else { e.Handled = false; }
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch { }
        }
      
        }
    }

