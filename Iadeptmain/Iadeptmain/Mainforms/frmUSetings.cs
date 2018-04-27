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
using Iadeptmain.GlobalClasses;

namespace Iadeptmain.Mainforms
{
    public partial class frmUSetings : DevExpress.XtraEditors.XtraForm
    {
        public frmUSetings()
        {
            InitializeComponent();
        }


        string utName = null;
        private void backstageViewControl1_SelectedTabChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            utName = Convert.ToString(backstageUSettings.SelectedTab.Caption);
            
           

            backstageViewClientControl1.Appearance.BackColor = Color.Blue;
            try
            {
                switch (utName)
                {
                    case "Route":
                        {
                            chkRoute.Items.Clear();
                            chkRoute.Items.Add("Addition");
                            chkRoute.Items.Add("Deletion");
                            chkRoute.Items.Add("Modification");
                            chkRoute.Items.Add("Upload/Download");
                            chkRoute.Items.Add("None");

                           break;

                        }
                    case "Alarms":
                        {
                            chklAlarms.Items.Clear();
                            chklAlarms.Items.Add("Addition");
                            chklAlarms.Items.Add("Deletion");
                            chklAlarms.Items.Add("Modification");
                            chklAlarms.Items.Add("None");
                            break;

                        }
                    case "Point Type":
                        {
                            chklPType.Items.Clear();
                            chklPType.Items.Add("Addition");
                            chklPType.Items.Add("Deletion");
                            chklPType.Items.Add("Modification");
                            chklPType.Items.Add("None");
                          break;

                        }
                    case "Sensors":
                        {
                            chklSensors.Items.Clear();
                            chklSensors.Items.Add("Addition");
                            chklSensors.Items.Add("Deletion");
                            chklSensors.Items.Add("Modification");
                            chklSensors.Items.Add("None");
                            break;

                        }
                    case "Reports":
                        {
                            chklReports.Items.Clear();
                            chklReports.Items.Add("View");
                            break;

                        }

                }
                showUserSettings();
            }
               
            catch
            {

            }
        }

        private void frmUSetings_Load(object sender, EventArgs e)
        {
            try 
            {
                txtUName.Text = Convert.ToString(PublicClass.uName.Trim());
                backstageRoutes1.Selected = true;
                chkRoute.Items.Clear();
                chkRoute.Items.Add("Addition");
                chkRoute.Items.Add("Deletion");
                chkRoute.Items.Add("Modification");
                chkRoute.Items.Add("Upload/Download");
                chkRoute.Items.Add("None");
                showUserSettings();
             

            }
            catch
            {

            }

        }

        private void chkRoute_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try 
            { 
                if(chkRoute.GetItemChecked(4) == true)
            {
                chkRoute.SetItemChecked(0,false);
                chkRoute.SetItemChecked(1, false);
                chkRoute.SetItemChecked(2, false);
                chkRoute.SetItemChecked(3, false);

            }
            }
            catch
            {

            }
            
        }

        private void chklAlarms_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                if (chklAlarms.GetItemChecked(3) == true)
                {
                    chklAlarms.SetItemChecked(0, false);
                    chklAlarms.SetItemChecked(1, false);
                    chklAlarms.SetItemChecked(2, false);
                   

                }
            }
            catch
            {

            }

        }

        private void chklSensors_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                if (chklSensors.GetItemChecked(3) == true)
                {
                    chklSensors.SetItemChecked(0, false);
                    chklSensors.SetItemChecked(1, false);
                    chklSensors.SetItemChecked(2, false);


                }
            }
            catch
            {

            }
        }

        private void chklPType_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                if (chklPType.GetItemChecked(3) == true)
                {
                    chklPType.SetItemChecked(0, false);
                    chklPType.SetItemChecked(1, false);
                    chklPType.SetItemChecked(2, false);


                }
            }
            catch
            {

            }
        }

        private void chkrt_MouseLeave(object sender, EventArgs e)
        {

            try
            {
                SaveData();

            }

            catch
            {

            }


        }

        private void chklAlarms_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                
                SaveData();
            }

            catch
            {

            }
        }

        private void chklSensors_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                SaveData();

            }

            catch
            {

            }
        }

        private void chklReports_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                SaveData();

            }

            catch
            {

            }   
        }

        private void chklPType_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                SaveData();

            }

            catch
            {

            }
        }

        public void SaveData()
        {
            string cutName = null;
            string tid = null;
            bool add = false;
            bool del = false;
            bool modify = false;
            bool none = false;
            bool UD = false;
            bool view = false;
            int uAdd = 0;
            int uDel = 0;
            int uModify = 0;
            int uUD = 0;
            int uView = 0;
            int uNone = 0;


            try
            {
                cutName = Convert.ToString(backstageUSettings.SelectedTab.Caption);

                switch(cutName)
                {
                    case "Route":
                        {
                            add = chkRoute.GetItemChecked(0);
                            del = chkRoute.GetItemChecked(1);
                            modify = chkRoute.GetItemChecked(2);
                            UD = chkRoute.GetItemChecked(3);
                            none = chkRoute.GetItemChecked(4);
                            break;
                        }
                    case "Alarms":
                        {
                            add = chklAlarms.GetItemChecked(0);
                            del = chklAlarms.GetItemChecked(1);
                            modify = chklAlarms.GetItemChecked(2);
                            none = chklAlarms.GetItemChecked(3);
                            break;
                        }
                    case "Sensors":
                        {
                            add = chklSensors.GetItemChecked(0);
                            del = chklSensors.GetItemChecked(1);
                            modify = chklSensors.GetItemChecked(2);
                            none = chklSensors.GetItemChecked(3);
                            break;
                        }
                    case "Point Type":
                        {
                            add = chklPType.GetItemChecked(0);
                            del = chklPType.GetItemChecked(1);
                            modify = chklPType.GetItemChecked(2);
                            none = chklPType.GetItemChecked(3);
                            break;
                        }
                    case "Reports":
                        {
                            view = chklReports.GetItemChecked(0);
                            break;
                        }
                }

                if (add == true)
                {
                    uAdd = 1;
                }
                
                if (del == true)
                {
                    uDel = 1;
                }
                

                if (modify == true)
                {
                    uModify = 1;
                }
                

                if (UD == true)
                {
                    uUD = 1;
                }
                

                if (view == true)
                {
                    uView = 1;
                }
               

                if (none == true)
                {
                    uNone = 1;
                }
                

                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "Select UsrID from usersettings where TabName = '" + cutName + "' and UserName = '" + PublicClass.uName + "' ");
                foreach (DataRow dr in dt.Rows)
                {
                    tid = Convert.ToString(dr["UsrID"]);

                }
                if (dt.Rows.Count > 0)
                {
                    DbClass.executequery(CommandType.Text, "Update usersettings set Addition = '" + uAdd + "', Deletion = '" + uDel + "', Modification = '" + uModify + "', ReportView = '" + uView + "',UpDown = '" + uUD + "', Other = '" + uNone + "' where UsrID = '" + tid + "'");
                }
                else
                {
                    DbClass.executequery(CommandType.Text, "Insert into usersettings(UserName , TabName,UserDetailID,Addition,Deletion,Modification,ReportView,UpDown,Other) values('" + txtUName.Text.Trim() + "' , '" + cutName + "' , '" + PublicClass.uID + "' , '" + uAdd + "' , '" + uDel + "', '" + uModify + "', '" + uView + "', '" + uUD + "', '" + uNone + "')");
                }
            }
            catch
            {

            }
        }

        public void showUserSettings()
        {
            int tAdd = 0;
            int tDel = 0;
            int tModify = 0;
            int tUD = 0;
            int tView = 0;
            int tNone = 0;



            try
            {
                string tName = Convert.ToString(backstageUSettings.SelectedTab.Caption);
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select distinct Addition , Deletion , Modification , ReportView , UpDown , Other from usersettings where  UserName = '" + PublicClass.uName + "' and TabName = '" + tName + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    tAdd = Convert.ToInt32(dr["Addition"]);
                    tDel = Convert.ToInt32(dr["Deletion"]);
                    tModify = Convert.ToInt32(dr["Modification"]);
                    tUD = Convert.ToInt32(dr["UpDown"]);
                    tView = Convert.ToInt32(dr["ReportView"]);
                    tNone = Convert.ToInt32(dr["Other"]);

                    if (tName == "Route")
                    {


                        if (tAdd == 1)
                        {
                            chkRoute.SetItemChecked(0, true);
                        }
                        if (tDel == 1)
                        {
                            chkRoute.SetItemChecked(1, true);
                        }
                        if (tModify == 1)
                        {
                            chkRoute.SetItemChecked(2, true);
                        }
                        if (tUD == 1)
                        {
                            chkRoute.SetItemChecked(3, true);
                        }
                        if (tNone == 1)
                        {
                            chkRoute.SetItemChecked(4, true);
                        }

                    }
                    if (tName == "Alarms")
                    {
                        if (tAdd == 1)
                        {
                            chklAlarms.SetItemChecked(0, true);
                        }

                        if (tDel == 1)
                        {
                            chklAlarms.SetItemChecked(1, true);
                        }

                        if (tModify == 1)
                        {
                            chklAlarms.SetItemChecked(2, true);
                        }

                        if (tNone == 1)
                        {
                            chklAlarms.SetItemChecked(3, true);
                        }

                    }

                    if (tName == "Sensors")
                    {
                        if (tAdd == 1)
                        {
                            chklSensors.SetItemChecked(0, true);
                        }

                        if (tDel == 1)
                        {
                            chklSensors.SetItemChecked(1, true);
                        }

                        if (tModify == 1)
                        {
                            chklSensors.SetItemChecked(2, true);
                        }

                        if (tNone == 1)
                        {
                            chklSensors.SetItemChecked(3, true);
                        }

                    }
                    if (tName == "Point Type")
                    {
                        if (tAdd == 1)
                        {
                            chklPType.SetItemChecked(0, true);
                        }

                        if (tDel == 1)
                        {
                            chklPType.SetItemChecked(1, true);
                        }

                        if (tModify == 1)
                        {
                            chklPType.SetItemChecked(2, true);
                        }

                        if (tNone == 1)
                        {
                            chklPType.SetItemChecked(3, true);
                           // chklPType.SetSelected(3, true);
                            //chklPType.SetItemCheckState(3,true);
                        }

                    }
                    if (tName == "Reports")
                    {
                        if (tView == 1)
                        {
                            chklReports.SetItemChecked(0, true);
                        }

                    }

                }

            }
            catch
            {

            }
        }

    }
}