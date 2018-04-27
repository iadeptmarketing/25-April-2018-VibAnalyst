using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.IO;
using Iadeptmain.Classes;
using Iadeptmain.Images;
using Iadeptmain.GlobalClasses;

namespace Iadeptmain.Mainforms
{
    public partial class ReportSetting : DevExpress.XtraEditors.XtraForm
    {
        int initialCtr = 0; 
        public ReportSetting()
        {
            InitializeComponent();
            reportmain();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string spath = null;
        string[] path = null;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Image Files|*.BMP;*.JPG;*.JPEG";
                openFileDialog1.ShowDialog();
                spath = openFileDialog1.FileName.ToString();
                spath = openFileDialog1.FileName.Replace('\\', '-');
                //path=spath.Split('/');
                if (!string.IsNullOrEmpty(spath))
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
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
                string finalPath = null;
                if (!string.IsNullOrEmpty(textBox1.Text))
                {                 
                    DbClass.executequery(CommandType.Text, "Truncate table comp_image");                    
                    DataTable dt=new DataTable();
                    dt = DbClass.getdata(CommandType.Text, "Select * from comp_image");
                    if(dt.Rows.Count>0)
                    {
                        DbClass.executequery(CommandType.Text, "update comp_image set Company_Name='" + textBox1.Text + "' and Company_logoimage= '" + spath + "' where id='" + Convert.ToInt32(dt.Rows[0]["id"]) + "'");
                    }
                    else
                    {
                        DbClass.executequery(CommandType.Text, "insert into comp_image(Company_Name ,Company_logoimage) values('" + textBox1.Text.ToString() + "','" + spath + "')");
                       
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Company Name Cannot be Blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "VCMT";
                }                
            }
            catch (Exception ex)
            {
            }
        }
        int PointPressCtrPtd = 0;
        void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (initialCtr == 0)
            {
                textBox1.Text = "";
                initialCtr++;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (PublicClass.chkKeyEnter(e)||!(e.KeyChar=='\b'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public void reportmain()
        {
            try
            {
                DataTable dt1 = new DataTable();
                dt1 = DbClass.getdata(CommandType.Text, "Select * from comp_image");
                if (dt1.Rows.Count > 0)
                {
                    string imagename = Convert.ToString(dt1.Rows[0]["Company_logoimage"]);
                    string[] sarrSplitedName = imagename.Split(new char[] { '-' });
                    string sImageName = sarrSplitedName[sarrSplitedName.Length - 1];
                    string insertImage = Convert.ToString(dt1.Rows[0]["Company_logoimage"]).Replace('-', '\\');
                    textBox1.Text = Convert.ToString(dt1.Rows[0]["Company_Name"]);
                    pictureBox1.Image = Image.FromFile(insertImage);
                    spath = imagename;
                }

            }
            catch { }
        }
    }
}
