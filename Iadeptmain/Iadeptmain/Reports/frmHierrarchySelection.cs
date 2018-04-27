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

namespace Iadeptmain.Reports
{
    public partial class frmHierrarchySelection : DevExpress.XtraEditors.XtraForm
    {
        public frmHierrarchySelection()
        {
            InitializeComponent();
        }

        string spNode = null;
        public string Machine_id = "";

        private void chklHierarchy_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            chklSelectNode.Items.Clear();
            string cItem = chklHierarchy.SelectedItem.ToString();
            int cItemIndex = e.Index;
            try
            {
                switch (cItem)
                {
                    case "Plant":
                        {
                            DataTable dt = DbClass.getdata(CommandType.Text, "SELECT distinct fac.Factory_ID , fac.Name FROM factory_info fac inner join area_info are on are.FactoryID=fac.Factory_ID left join train_info tra on tra.Area_ID=are.Area_ID left join machine_info mac on mac.TrainID=tra.Train_ID left join point pt on pt.Machine_ID=mac.Machine_ID left join point_data pd on pd.Point_ID=pt.Point_ID where pd.Point_ID=pt.Point_ID;");
                            foreach (DataRow dr in dt.Rows)
                            {
                                chklSelectNode.DataSource = dt;
                                chklSelectNode.ValueMember = dt.Columns[0].ColumnName;
                                chklSelectNode.DisplayMember = dt.Columns[1].ColumnName;
                                spNode = "Factory_ID";
                            }
                            break;
                        }
                    case "Area":
                        {
                            DataTable dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct are.Area_ID,are.Name from area_info are inner join train_info tra on tra.Area_ID=are.Area_ID left join machine_info mac on mac.TrainID=tra.Train_ID left join point pt on pt.Machine_ID=mac.Machine_ID left join point_data pd on pd.Point_ID=pt.Point_ID where pd.Point_ID=pt.Point_ID;");
                            foreach (DataRow dr in dt1.Rows)
                            {                                
                                chklSelectNode.DataSource = dt1;
                                chklSelectNode.ValueMember = dt1.Columns[0].ColumnName;
                                chklSelectNode.DisplayMember = dt1.Columns[1].ColumnName;
                                spNode = "a.Area_ID";
                            }
                            break;

                        }

                    case "Train":
                        {
                            DataTable dt2 = DbClass.getdata(CommandType.Text, "SELECT distinct tra.Train_ID,tra.Name from train_info tra inner join machine_info mac on mac.TrainID=tra.Train_ID left join point pt on pt.Machine_ID=mac.Machine_ID left join point_data pd on pd.Point_ID=pt.Point_ID where pd.Point_ID=pt.Point_ID;");
                            foreach (DataRow dr in dt2.Rows)
                            {                                
                                chklSelectNode.DataSource = dt2;
                                chklSelectNode.ValueMember = dt2.Columns[0].ColumnName;
                                chklSelectNode.DisplayMember = dt2.Columns[1].ColumnName;
                                spNode = "Train_ID";
                            }
                            break;
                        }

                    case "Machine":
                        {
                            DataTable dt3 = DbClass.getdata(CommandType.Text, "SELECT distinct mac.Machine_ID,mac.Name from machine_info mac inner join point pt on pt.Machine_ID=mac.Machine_ID left join point_data pd on pd.Point_ID=pt.Point_ID where pd.Point_ID=pt.Point_ID;");
                            foreach (DataRow dr in dt3.Rows)
                            {                                
                                chklSelectNode.DataSource = dt3;
                                chklSelectNode.ValueMember = dt3.Columns[0].ColumnName;
                                chklSelectNode.DisplayMember = dt3.Columns[1].ColumnName;
                                spNode = "Machine_ID";
                            }
                            break;
                        }
                    case "Point":
                        {
                            DataTable dt4 = DbClass.getdata(CommandType.Text, "SELECT point_id,point_name ,COUNT( point_name ) `tot` FROM point_data GROUP BY point_name HAVING `tot` >1 ;");
                            foreach (DataRow dr in dt4.Rows)
                            {
                                chklSelectNode.DataSource = dt4;
                                chklSelectNode.ValueMember = dt4.Columns[0].ColumnName;
                                chklSelectNode.DisplayMember = dt4.Columns[1].ColumnName;
                                spNode = "point_id";
                            }
                            break;
                        }
                }

            }
            catch
            {

            }

        }
        public void checkstatus(int a)
        {
            try
            {
                bool status = false;
                for (int i = 0; i < chklHierarchy.Items.Count; i++)
                {
                    if (i != a)
                    {
                        chklHierarchy.SetItemChecked(i, false);
                    }
                    else
                    {
                        chklHierarchy.SetItemChecked(i, true);

                    }
                }

            }
            catch
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chklHierarchy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                checkstatus(chklHierarchy.SelectedIndex);

            }
            catch { }
        }
        string strArr = string.Empty;
        string strSubArr = string.Empty;
        private void btnOK_Click(object sender, EventArgs e)
        {
            string xk = string.Empty;
            strSubArr = string.Empty;
            if (chklHierarchy.CheckedItems.Count != 0 && chklSelectNode.CheckedItems.Count != 0)
            {
                if (chklSelectNode.CheckedItems.Count != 0)
                {
                    for (int k = 0; k < chklSelectNode.CheckedItems.Count; k++)
                    {
                        strSubArr = strSubArr + chklSelectNode.CheckedItems[k].ToString() + ",";
                    }
                    xk = strSubArr.Substring(0, (strSubArr.Length - 1));
                    strArr = xk.ToString();
                    char[] splitchar = { ',' };
                    string[] cnID = xk.Split(splitchar);

                    for (int i = 0; i < cnID.Length; i++)
                    {
                        DataTable dt = new DataTable();
                        if (chklHierarchy.Text == "Point")
                        {
                            Machine_id += cnID[i] + ",";
                        }
                        else
                        {
                            dt = DbClass.getdata(CommandType.Text, "SELECT f.Factory_ID as 'FactoryID',a.Area_ID as 'Area_ID' ,t.Train_ID as 'TrainID', m.Machine_ID as 'MachinID'  FROM machine_info m left join train_info t on m.TrainID = t.Train_ID left join area_info a on a.Area_ID=t.Area_ID left join factory_info f on f.Factory_ID=a.FactoryID where " + spNode + " = '" + cnID[i] + "' ");
                            foreach (DataRow dr in dt.Rows)
                            {
                                Machine_id += Convert.ToString(dr["MachinID"]) + ",";
                            }
                        }
                    }
                }
                else
                { strArr = ""; }
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Please Select atleast one Node", "VibAnalyst", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmHierrarchySelection_Load(object sender, EventArgs e)
        {
            try
            {
                chklHierarchy.Items.Clear();

                chklHierarchy.Items.Add("Plant", false);
                chklHierarchy.Items.Add("Area", false);
                chklHierarchy.Items.Add("Train", false);
                chklHierarchy.Items.Add("Machine", false);
                if (PublicClass.ReportName == "Points with Alarms")
                {

                }
                if (PublicClass.ReportName == "Point Report with Overall Trend Graph")
                {
                    chklHierarchy.Items.Clear();
                    chklHierarchy.Items.Add("Point", false);
                }

                else if (PublicClass.ReportName == "Alarm in User Selected Machine" || PublicClass.ReportName == "Single Channel Graph for User Selected Machine")
                {
                    chklHierarchy.Items.RemoveAt(0);
                    chklHierarchy.Items.RemoveAt(0);
                    chklHierarchy.Items.RemoveAt(0);
                }
                else if (PublicClass.ReportName == "Alarm in User Selected Train")
                {
                    chklHierarchy.Items.RemoveAt(0);
                    chklHierarchy.Items.RemoveAt(0);
                    chklHierarchy.Items.RemoveAt(1);
                }
                else if (PublicClass.ReportName == "Alarm in User Selected Area")
                {
                    chklHierarchy.Items.RemoveAt(0);
                    chklHierarchy.Items.RemoveAt(1);
                    chklHierarchy.Items.RemoveAt(1);
                }
                else if (PublicClass.ReportName == "Alarm in User Selected Plant" || PublicClass.ReportName == "General Report Navy")
                {
                    chklHierarchy.Items.RemoveAt(1);
                    chklHierarchy.Items.RemoveAt(1);
                    chklHierarchy.Items.RemoveAt(1);
                }
                if (PublicClass.ReportName == "Multi Overall and Multi Graph(RPM Based)" || PublicClass.ReportName=="Vibration Measurement Report")
                {
                    chklHierarchy.Items.RemoveAt(0);
                    chklHierarchy.Items.RemoveAt(0);
                    chklHierarchy.Items.RemoveAt(0);
                }
               
                else
                {     }
            }
            catch
            {  }
        }

        private void chklSelectNode_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            //try
            //{
            //    int count = chklSelectNode.ItemCount;
            //    int cItem = Convert.ToInt32(chklSelectNode.SelectedIndex);
            //    for (int i = 0; i < count; i++)
            //    {
            //        if (i == cItem)
            //        {
            //            chklSelectNode.SetItemChecked(i, true);
            //        }
            //        else
            //        {
            //            chklSelectNode.SetItemChecked(i, false);
            //        }
            //    }
            //}
            //catch
            //{
            //}
        }
    }
}