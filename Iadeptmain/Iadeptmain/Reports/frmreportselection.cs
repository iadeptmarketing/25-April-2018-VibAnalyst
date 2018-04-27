using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Iadeptmain.GlobalClasses;

namespace Iadeptmain.Reports
{
    public partial class frmreportselection : DevExpress.XtraEditors.XtraForm
    {
        public frmreportselection()
        {
            InitializeComponent();
        }
        public StringBuilder sbMulti = null;
        public string GraphType="";
        public string overalltype="";

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
             sbMulti = new StringBuilder();

            try
            {
                if (PublicClass.ReportName != "General Report Navy")
                {
                    if (chktime.Checked == false && chkdemo.Checked == false && chkcep.Checked == false && chkpower.Checked == false && chkpower1.Checked == false && chkpower2.Checked == false && chkpower21.Checked == false && chkpower31.Checked == false && chlPower3.Checked == false)
                    {
                        MessageBox.Show("Please Select one type of Graph....");
                        return;

                    }
                }
                if (chkAcc.Checked == false && chkVel.Checked == false && chkDisp.Checked == false && chkBer.Checked == false)
                {
                    MessageBox.Show("Please Select one type of Overall....");
                    return;
                }
                else
                {
                    overalltype = "";
                    GraphType = "";
                      if(chktime.Checked)
                      {
                          GraphType += Convert.ToString(chktime.Text).Trim() + "-";   
                      }
                      if (chkpower.Checked)
                      {
                          GraphType += Convert.ToString(chkpower.Text).Trim() + "-";
                      }
                       if(chkpower1.Checked)
                       {
                     
                          GraphType += Convert.ToString(chkpower1.Text).Trim() + "-";
                      }
                      if(chkpower2.Checked)
                      {
                         
                          GraphType += Convert.ToString(chkpower2.Text).Trim() + "-";
                      }
                      if(chkpower21.Checked)
                      {
                       
                          GraphType += Convert.ToString(chkpower21.Text).Trim() + "-";
                      }
                      if(chlPower3.Checked)
                      {
                          GraphType += Convert.ToString(chlPower3.Text).Trim() + "-";
                      }
                      if(chkpower31.Checked)
                      {
                        
                          GraphType += Convert.ToString(chkpower31.Text).Trim() + "-";
                      }


                      if (chkcep.Checked)
                      {

                          GraphType += Convert.ToString(chkcep.Text).Trim() + "-";
                      }
                      if (chkdemo.Checked)
                      {

                          GraphType += Convert.ToString(chkdemo.Text).Trim() + "-";
                      }
                      if (chkDisp.Checked)
                      {

                          GraphType += Convert.ToString(chkDisp.Text).Trim() + "-";
                      }


                      if (chkAcc.Checked)
                      {
                        
                          overalltype += Convert.ToString(chkAcc.Text).Trim() + "/";

                      }
                      if (chkVel.Checked)
                      {
                          overalltype += Convert.ToString(chkVel.Text).Trim() + "/";
                        
                      }
                      if (chkDisp.Checked)
                      {
                      
                          overalltype += Convert.ToString(chkDisp.Text).Trim() + "/";
                      }
                      if (chkBer.Checked)
                      {
                          overalltype += Convert.ToString(chkBer.Text).Trim() + "/";
                      }




                      this.Close();
                }

            }
            catch { }
        }

    public string sString = null;
        public string ReportString
        {
            get
            {
                return sString;
            }
        }

        private void frmreportselection_Load(object sender, EventArgs e)
        {
            try
            {
                if (PublicClass.ReportName == "Multi Overall and Multi Graph(RPM Based)" || PublicClass.ReportName == "Multi Overall and Multi Graph(Fault Frequency Based)" || PublicClass.ReportName == "Multi Overall and Multi Graph(Dominant Frequency Based)" || PublicClass.ReportName == "Multi Overall and Multi Graph(Highest Peaks Based)")
                {
                    chktime.Enabled = false;
                    chkdemo.Enabled = false;
                    chkcep.Enabled = false;
                }
                else if (PublicClass.ReportName == "RPM Report for User selected Machine")
                {
                    if (PublicClass.currentInstrument == "Kohtect-C911")
                    {
                        chktime.Enabled = false; chkpower2.Enabled = false; chkpower21.Enabled = false; chlPower3.Enabled = false; chkpower31.Enabled = false;
                        chkdemo.Enabled = false; chkcep.Enabled = false; chkBer.Visible = false;
                    }
                    else
                    {
                        chktime.Enabled = false; chkdemo.Enabled = false;
                        chkcep.Enabled = false;  chkBer.Visible = false;
                    }
                }
                else
                {
                    chktime.Enabled = true;
                    chkdemo.Enabled = true;
                    chkcep.Enabled = true;
                }
                if (PublicClass.ReportName == "General Report Navy")
                {
                    gbGraph.Visible = false;
                }
            }
            catch
            { }
        }

        private void chktime_CheckedChanged(object sender, EventArgs e)
        {
            if (PublicClass.ReportName == "1 Overall and 1 Graph")
            {
                if (chktime.Checked == true)
                {
                    chkpower.Enabled = false;
                    chkpower1.Enabled = false;
                    chkpower2.Enabled = false;
                    chkpower21.Enabled = false;
                    chlPower3.Enabled = false;
                    chkpower31.Enabled = false;
                    chkdemo.Enabled = false;
                    chkcep.Enabled = false;
                }
               else if (chkpower.Checked == true)
                {
                    chktime.Enabled = false;
                    chkpower1.Enabled = false;
                    chkpower2.Enabled = false;
                    chkpower21.Enabled = false;
                    chlPower3.Enabled = false;
                    chkpower31.Enabled = false;
                    chkdemo.Enabled = false;
                    chkcep.Enabled = false;
                }
                else if (chkpower1.Checked == true)
                {
                    chktime.Enabled = false;
                    chkpower.Enabled = false;
                    chkpower2.Enabled = false;
                    chkpower21.Enabled = false;
                    chlPower3.Enabled = false;
                    chkpower31.Enabled = false;
                    chkdemo.Enabled = false;
                    chkcep.Enabled = false;
                }
                else if (chkpower2.Checked == true)
                {
                    chktime.Enabled = false;
                    chkpower.Enabled = false;
                    chkpower1.Enabled = false;
                    chkpower21.Enabled = false;
                    chlPower3.Enabled = false;
                    chkpower31.Enabled = false;
                    chkdemo.Enabled = false;
                    chkcep.Enabled = false;
                }
                else if (chkpower21.Checked == true)
                {
                    chktime.Enabled = false;
                    chkpower.Enabled = false;
                    chkpower2.Enabled = false;
                    chkpower1.Enabled = false;
                    chlPower3.Enabled = false;
                    chkpower31.Enabled = false;
                    chkdemo.Enabled = false;
                    chkcep.Enabled = false;
                }
                else if (chlPower3.Checked == true)
                {
                    chktime.Enabled = false;
                    chkpower.Enabled = false;
                    chkpower2.Enabled = false;
                    chkpower21.Enabled = false;
                    chkpower1.Enabled = false;
                    chkpower31.Enabled = false;
                    chkdemo.Enabled = false;
                    chkcep.Enabled = false;
                }
                else if (chkpower31.Checked == true)
                {
                    chktime.Enabled = false;
                    chkpower.Enabled = false;
                    chkpower2.Enabled = false;
                    chkpower21.Enabled = false;
                    chlPower3.Enabled = false;
                    chkpower1.Enabled = false;
                    chkdemo.Enabled = false;
                    chkcep.Enabled = false;
                }
                else if (chkdemo.Checked == true)
                {
                    chktime.Enabled = false;
                    chkpower.Enabled = false;
                    chkpower2.Enabled = false;
                    chkpower21.Enabled = false;
                    chlPower3.Enabled = false;
                    chkpower1.Enabled = false;
                    chkpower31.Enabled = false;
                    chkcep.Enabled = false;
                }
                else if (chkcep.Checked == true)
                {
                    chktime.Enabled = false;
                    chkpower.Enabled = false;
                    chkpower2.Enabled = false;
                    chkpower21.Enabled = false;
                    chlPower3.Enabled = false;
                    chkpower1.Enabled = false;
                    chkpower31.Enabled = false;
                    chkdemo.Enabled = false;
                }  
                else
                {
                    chktime.Enabled = true;
                    chkpower.Enabled = true;
                    chkpower1.Enabled = true;
                    chkpower2.Enabled = true;
                    chkpower21.Enabled = true;
                    chlPower3.Enabled = true;
                    chkpower31.Enabled = true;
                    chkdemo.Enabled = true;
                    chkcep.Enabled = true;
                }
            
            }
        }

        private void chkAcc_CheckedChanged(object sender, EventArgs e)
        {
            if (PublicClass.ReportName == "1 Overall and 1 Graph" || PublicClass.ReportName == "General Report Navy")
            {
                if (chkAcc.Checked == true)
                {
                    chkVel.Enabled = false;
                    chkDisp.Enabled = false;
                    chkBer.Enabled = false;
                }
                else if (chkVel.Checked == true)
                {
                    chkAcc.Enabled = false;
                    chkDisp.Enabled = false;
                    chkBer.Enabled = false;
                }
                else if (chkDisp.Checked == true)
                {
                    chkVel.Enabled = false;
                    chkAcc.Enabled = false;
                    chkBer.Enabled = false;
                }
                else if (chkBer.Checked == true)
                {
                    chkVel.Enabled = false;
                    chkDisp.Enabled = false;
                    chkAcc.Enabled = false;
                }
                else
                {
                    chkAcc.Enabled = true;
                    chkVel.Enabled = true;
                    chkDisp.Enabled = true;
                    chkBer.Enabled = true;
                }
            }
        }

        
    }
}