using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Iadeptmain.Mainforms;
using Iadeptmain.GlobalClasses;

namespace Iadeptmain.Reports
{
    public partial class frmReportSettings : DevExpress.XtraEditors.XtraForm
    {
        frmIAdeptMain objMain = null;
        int y = 0;
        public frmReportSettings()
        {
            InitializeComponent();
            FillListBoxForAllReport();
            fillListBoxForCurrentReports();
            fillListBoxFor_Daily();
            fillListBoxFor_Auto();
            try
            {
                lbSelectReport.SelectedIndex = -1;
                lstautoreport.SelectedIndex = -1;
                lbDaily.SelectedIndex = -1;
            }
            catch
            {
            }
        }

        public frmIAdeptMain MainForm
        {
            get { return objMain; }
             set {  objMain = value; }
        }

        private void frmReportSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            objMain.fillform();
         
        }

        private void btnForword_Click(object sender, EventArgs e)
        {
            string sReportName = null;
            string cReport = null;
            int tItems = 0;
            try
            {
                tItems = lbSelectReport.ItemCount;
                sReportName = lbAllReport.SelectedItem.ToString();                
                //if(tItems == 10)
                //{
                //    MessageBox.Show(this, "You have already selected 10 items. Please remove some items to add new...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                for(int i=0; i<= tItems ; i++)
                {
                    string cItem = lbSelectReport.GetItemText(i).ToString(); 
                    if(cItem == sReportName)
                    {
                        MessageBox.Show(this, "This report name you have already selected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                lbSelectReport.Items.Add(sReportName);
                DbClass.executequery(CommandType.Text, "Insert into allreport(ReportName,ReportStatus) values('" + sReportName.Trim() + "','Selected')");

               lbDaily.SelectedIndex = -1;
                lstautoreport.SelectedIndex = -1;
                lbAllReport.SelectedIndex = -1;
            }
            catch
            {
            }
        }

        private void btnBackword_Click(object sender, EventArgs e)
        {
          
        }

        public void fillListBoxForCurrentReports()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select distinct ReportName from allreport where reportstatus= 'Selected' ");
                lbSelectReport.Items.Clear();
                foreach(DataRow dr in dt.Rows)
                {
                    string rName = Convert.ToString(dr["ReportName"]);
                    lbSelectReport.Items.Add(rName);
                }
            }
            catch
            {
            }
        }
      
        public void fillListBoxFor_Auto()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select distinct ReportName from allreport where reportstatus= 'Auto' ");
                lstautoreport.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                  
                    lstautoreport.Items.Add(Convert.ToString(dr["ReportName"]).Trim ());
                }
            }
            catch
            {
            }
        }

        public void fillListBoxFor_Daily()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select distinct ReportName from allreport where reportstatus= 'Daily' ");
                lbDaily.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                  
                    lbDaily.Items.Add(Convert.ToString(dr["ReportName"]));
                }
            }
            catch
            {
            }
        }

        string[] arrItem = null;
        public void FillListBoxForAllReport()
        {
            try
            {
                string ListItems = null;
                lbAllReport.Items.Clear();
                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                {
                    ListItems = "OverAll Values//OverDue Points//Points with Alarms//Alarm in User Selected Machine//Alarm in User Selected Train//Alarm in User Selected Area//Alarm in User Selected Plant//Velocity with Time Graph//Velocity with Power Graph//Velocity with Demodulate Graph//Acceleration with Time Graph//Acceleration with Power Graph//Acceleration  with Demodulate Graph//Displacement  with Time Graph//Displacement with Power Graph//Displacement  with Demodulate Graph//Bearing with Time Graph//Bearing with Power Graph//Bearing with Demodulate Graph//1 Overall and 1 Graph//Acceleration with power2Graph Graph//Displacement with power2Graph Graph//Velocity with power2Graph Graph//Bearing with power2Graph Graph//Acceleration with power2Graph1 Graph//Velocity with power2Graph1 Graph//Displacement with power2Graph1 Graph//Bearing with power2Graph1 Graph//Acceleration with power3Graph Graph//Velocity with power3Graph Graph//Displacement with power3Graph Graph//Bearing with power3Graph Graph//Acceleration with power3Graph1 Graph//Velocity with power3Graph1 Graph//Displacement with power3Graph1 Graph//Bearing with power3Graph1 Graph//Acceleration with Power1 Graph//Velocity with Power1 Graph//Displacement with Power1 Graph//Bearing with Power1 Graph//Multi Overall and Multi Graph//Multi Overall and Multi Graph(RPM Based)//Multi Overall and Multi Graph(Fault Frequency Based)//Multi Overall and Multi Graph(Dominant Frequency Based)//Multi Overall and Multi Graph(Highest Peaks Based)//Notes Report//Vibration Measurement Report//General Report Navy";
                }
                else if (PublicClass.currentInstrument == "Kohtect-C911")
                {
                    ListItems = "OverAll Values//Points with Alarms//With Single Channel Time Graph//With Single Channel Power Graph//With Dual Channel Time Graph//With Dual Channel Power Graph//Report for Overall Values Of All Acceleration//Report for Overall Values Of All Velocity//Report for Overall Values Of All Displacement//Overall Values Of Acceleration with Time Graph//Overall Values Of Acceleration with Power Graph//Overall Values Of Velocity with Time Graph//Overall Values Of Velocity with Power Graph//Overall Values Of Displacement with Time Graph//Overall Values Of Displacement with Power Graph//Overall Trend Values//Overall Trend Values with Graph//Point Report with Overall Trend Graph//Alarm in User Selected Machine//Single Channel Graph for User Selected Machine//Dual Channel Graph for User Selected Machine//RPM Report for User selected Machine//Alarm Report with Graph for selected Machine";
                }
                else
                { ListItems = "OverAll Values//Points with Alarms//With Single Channel Time Graph//With Single Channel Power Graph//With Dual Channel Time Graph//With Dual Channel Power Graph//OverAll Values with Difference and Graphical Analysis//Report for Overall Values Of All Velocity//Report for Overall Values Of All Acceleration//Report for Overall Values Of All Displacement//Overall Values Of Velocity with Time Graph//Overall Values Of Velocity with Power Graph//Overall Values Of Acceleration with Time Graph//Overall Values Of Acceleration with Power Graph//Overall Values Of Displacement with Time Graph//Overall Values Of Displacement with Power Graph//Overall Trend Values//Overall Trend Values with Graph//Graph Report For User Selected Point//Alarm in User Selected Machine//Single Channel Graph for User Selected Machine//Dual Channel Graph for User Selected Machine//RPM Report for User selected Machine//Fault Diagnostic Report//Alarm Report with Graph for selected Machine//Point Report with Overall Trend Graph//Group Report//Time wave to FFT Graph"; }
                arrItem = ListItems.Split(new string[] { "//" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arrItem.Length; i++)
                {
                    lbAllReport.Items.Add(Convert.ToString(arrItem[i]).Trim());
                }
            }
            catch
            {
            }
        }
        

        private void lbSelectReport_MouseClick(object sender, MouseEventArgs e)
        {
            lbAllReport.SelectedIndex = -1;
            lstautoreport.SelectedIndex = -1;
            lbDaily.SelectedIndex = -1;
        }

        private void btnauto_Click(object sender, EventArgs e)
        {
            string sReportName = null;
            try
            {
                if (lstautoreport.ItemCount > 0)
                {
                    MessageBox.Show(this, "Please remove report for add new one.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sReportName = lbSelectReport.SelectedItem.ToString();
                    lstautoreport.Items.Add(sReportName);
                    DbClass.executequery(CommandType.Text, "insert into allreport(reportname,reportstatus)values('" + sReportName + "','Auto')");
                    lbDaily.SelectedIndex = -1;
                    lbSelectReport.SelectedIndex = -1;
                    lbAllReport.SelectedIndex = -1;
                }
            }
            catch { }
        }

        private void btnDaily_Click(object sender, EventArgs e)
        {
            string sReportName = null;
            try
            {
                if (lbDaily.ItemCount > 0)
                {
                    MessageBox.Show(this, "Please remove report for add new one.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sReportName = lbSelectReport.SelectedItem.ToString();
                    lbDaily.Items.Add(sReportName);
                    DbClass.executequery(CommandType.Text, "insert into allreport(reportname,reportstatus)values('" + sReportName + "','Daily')");

                    lbSelectReport.SelectedIndex = -1;
                    lstautoreport.SelectedIndex = -1;
                    lbAllReport.SelectedIndex = -1;
                }
            }
            catch { }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            string sReportname = null;
            string rStatus = null;
            try
            {
                if (Convert.ToString(lbSelectReport.SelectedItem).Trim() == "" && Convert.ToString(lstautoreport.SelectedItem).Trim() == ""  && Convert.ToString(lbDaily.SelectedItem).Trim() == "")
                {
                    MessageBox.Show(this, "Please select report for Remove", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (Convert.ToString(lbSelectReport.SelectedItem).Trim() != "")
                {
                    sReportname = Convert.ToString(lbSelectReport.SelectedItem).Trim();
                    lbSelectReport.Items.Remove(sReportname);
                    rStatus = "Selected";
                }
                else if (Convert.ToString(lstautoreport.SelectedItem).Trim() != "")
                {
                    sReportname = Convert.ToString(lstautoreport.SelectedItem).Trim();
                    lstautoreport.Items.Remove(sReportname);
                    rStatus = "Auto";
                }
                else if (Convert.ToString(lbDaily.SelectedItem).Trim() != "")
                {
                    sReportname = Convert.ToString(lbDaily.SelectedItem).Trim();
                    lbDaily.Items.Remove(sReportname);
                    rStatus = "Daily";
                }
                else
                {
                    return;
                }
                DbClass.executequery(CommandType.Text, "Delete from allreport where ReportName ='" + sReportname.Trim() + "'and ReportStatus = '" + rStatus.Trim () + "'");
            }
            catch { }
        }

        Control cont;
        private void lbDaily_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {

                if (Convert.ToString(lbSelectReport.SelectedItem).Trim() != "")
                {
                    cont = lbSelectReport;
                }
                else if (Convert.ToString(lstautoreport.SelectedItem).Trim() != "")
                {
                    cont = lstautoreport;
                }
                else if (Convert.ToString(lbDaily.SelectedItem).Trim() != "")
                {
                    cont = lbDaily;
                }

                else
                {
                    return;
                }

                switch (e.Button)
                {
                    case MouseButtons.Right:
                        {
                            cmsReport.Show(cont, new Point(e.X, e.Y));
                            break;
                        }
                }
            }
            catch { }
        }

        private void lbAllReport_MouseClick(object sender, MouseEventArgs e)
        {
            lbSelectReport.SelectedIndex = -1;
            lstautoreport.SelectedIndex = -1;
            lbDaily.SelectedIndex = -1;

        }

        private void lstautoreport_MouseClick(object sender, MouseEventArgs e)
        {
            lbSelectReport.SelectedIndex = -1;
            lbAllReport.SelectedIndex = -1;
            lbDaily.SelectedIndex = -1;
        }

        private void lbDaily_MouseClick(object sender, MouseEventArgs e)
        {
            lbSelectReport.SelectedIndex = -1;
            lstautoreport.SelectedIndex = -1;
            lbAllReport.SelectedIndex = -1;
        }

        private void frmReportSettings_Load(object sender, EventArgs e)
        {          
            this.panelControl1.AutoScroll = true;
        }

    }
}