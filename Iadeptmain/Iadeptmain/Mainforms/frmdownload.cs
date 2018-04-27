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
    public partial class frmdownload : DevExpress.XtraEditors.XtraForm
    {
        public frmdownload()
        {
            InitializeComponent();
        }
        bool bCancel = false;
        public bool IsCancelClicked
        {
            get
            {
                return bCancel;
            }
            set
            {
                bCancel = value;
            }
        }
        bool bSelectInstrument = true;
        public bool IsInstrumentSelected
        {
            get
            {
                return bSelectInstrument;
            }
            set
            {
                bSelectInstrument = value;
            }
        }

        string sPathtosave = null;
        public string PCPath
        {
            get
            {
                return sPathtosave;
            }
            set
            {
                sPathtosave = value;
            }
        }
        string spath = null;
        private void rbInst_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbInst.Checked == true)
                {
                    textBox1.Enabled = true;
                    textBox2.Enabled = false;
                    btnBrowse.Enabled = false;
                    bSelectInstrument = true;
                    btnBrowse.BackColor = Color.Gray;
                }
                else
                {
                    textBox1.Enabled = false;
                    textBox2.Enabled = true;
                    btnBrowse.Enabled = true;
                    bSelectInstrument = false;
                    btnBrowse.BackColor = SystemColors.InactiveCaptionText;
                }
            }
            catch { }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog saveFileDialog = new OpenFileDialog();
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "SqlCE File (.sdf)|*.sdf";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.DefaultExt = ".sdf";
                saveFileDialog.RestoreDirectory = true;


                saveFileDialog.ShowDialog();
                spath = saveFileDialog.FileName.ToString();
                if (!string.IsNullOrEmpty(spath))
                {
                    textBox2.Text = spath;
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                bCancel = false;
                if (!string.IsNullOrEmpty(textBox2.Text.ToString()))
                {
                    sPathtosave = textBox2.Text.ToString();
                    this.Close();
                }               
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void frmdownload_Load(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (PublicClass.routename != null)
                {
                    if (PublicClass.currentInstrument == "Impaq-Benstone")
                    {
                        textBox1.Text = @"\Storage Card\impaqElite\DataCollector\Data\" + PublicClass.routename + ".sdf";
                        textBox2.Text = path + "\\" + PublicClass.routename + ".sdf";
                    }
                    else if(PublicClass.currentInstrument=="FieldPaq2")
                    {
                        textBox1.Text = @"\Storage Card\FieldpaqII\DataCollector\Data\" + PublicClass.routename + ".sdf";
                        textBox2.Text = path + "\\" + PublicClass.routename + ".sdf";
                    }
                    else if (PublicClass.currentInstrument == "Kohtect-C911")
                    {
                        btnBrowse.Visible = false;
                        rbInst.Text = "Disk A";
                        rbPC.Text = "Disk B";
                        textBox1.Text = @"G:\" + PublicClass.routename + "";
                        textBox2.Text = @"H:\" + PublicClass.routename + "";
                    }
                    else
                    {
                        textBox1.Text = @"\Storage Card\Enpac\DataCollector\Data\" + PublicClass.routename + ".dat";
                        textBox2.Text = path + "\\" + PublicClass.routename + ".dat";
                    }
                }
                else
                { }
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bCancel = true;
            this.Close();
        }
    }
}