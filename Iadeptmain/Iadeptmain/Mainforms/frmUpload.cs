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
    public partial class frmUpload : DevExpress.XtraEditors.XtraForm
    {
        string sRouteName = null;
        string spath = null;
        bool bSelectInstrument = true;
        string sPathtosave = null;
        bool bCancel = false;

        public frmUpload()
        {
            InitializeComponent();
        }
       
        public string SelectedRouteName
        {
            get
            {
                return sRouteName;
            }
            set
            {
                sRouteName = value;
            }
        }
       
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
                else
                {
                    MessageBox.Show("Path Not Correct");
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                bCancel = true;
                this.Close();
            }
            catch { }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog saveFileDialog1 = new FolderBrowserDialog();
                saveFileDialog1.ShowDialog();
                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                {
                    spath = saveFileDialog1.SelectedPath.ToString() + "\\" + sRouteName + ".sdf";
                }
                else
                {
                    spath = saveFileDialog1.SelectedPath.ToString() + "\\" + sRouteName + ".dat";
                }
                if (!string.IsNullOrEmpty(spath))
                {
                    textBox2.Text = spath;
                }
            }
            catch (Exception ex)
            {
            }
        }

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
                }
                else
                {
                    textBox1.Enabled = false;
                    textBox2.Enabled = true;
                    btnBrowse.Enabled = true;
                    bSelectInstrument = false;
                }
            }
            catch { }
        }

        private void frmUpload_Load(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (PublicClass.routename != null)
                {
                    if (PublicClass.currentInstrument == "Impaq-Benstone")
                    {
                        //textBox1.Text = @"This PC\rohit_000's Device 2\Storage Card\impaqElite\DataCollector\Data\" + PublicClass.routename + ".sdf";
                        textBox1.Text = @"\Storage Card\impaqElite\DataCollector\Data\" + PublicClass.routename + ".sdf";
                        textBox2.Text = path + "\\" + PublicClass.routename + ".sdf";
                    }
                    else if (PublicClass.currentInstrument == "FieldPaq2")
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
                        //textBox2.Text = @"H:\" + PublicClass.routename + "";F:\
                        textBox2.Text = @"E:\" + PublicClass.routename + "";
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
    }
}