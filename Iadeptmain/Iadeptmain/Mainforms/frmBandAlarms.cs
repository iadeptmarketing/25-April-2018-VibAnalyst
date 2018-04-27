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
using Iadeptmain.BaseUserControl;

namespace Iadeptmain.Mainforms
{
    public partial class frmBandAlarms : DevExpress.XtraEditors.XtraForm
    {
        frmIAdeptMain _objMain = null;
        IadeptUserControl UserControl = null;

        string FName = null;
        string BAName = null;
        double FValue;
        double fCount;
        double BAValue;
        double xAxis;
        double yAxis;
        int B_Axis_type_v;
        int D_Axis_type_v;
        DataTable dt_Band = new DataTable();

        DataTable dt_Demodulate = new DataTable();

        public frmBandAlarms()
        {
            InitializeComponent();
            Fill_CmbBandAlarmGroup();
        
            dt_Band.Columns.Add("Id");
            dt_Band.Columns.Add("Name");
            dt_Band.Rows.Add(0, "Power CH1");
            dt_Band.Rows.Add(1, "Power A");
            dt_Band.Rows.Add(2, "Power H");
            dt_Band.Rows.Add(3, "Power V");

            dt_Demodulate.Columns.Add("Id");
            dt_Demodulate.Columns.Add("Name");
            dt_Demodulate.Rows.Add(4, "Demodulate Ch1");
            dt_Demodulate.Rows.Add(5, "Demodulate A");
            dt_Demodulate.Rows.Add(6, "Demodulate H");
            dt_Demodulate.Rows.Add(7, "Demodulate V");
        }

        public frmIAdeptMain MainForm
        {
            get
            {
                return _objMain;
            }

            set
            {
                _objMain = value;
            }
        }

        private void Column0_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (PublicClass.chkKeyEnter(e))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch { }
        }


        public IadeptUserControl userForm
        {
            get
            {
                return UserControl;
            }

            set
            {
                UserControl = value;

            }

        }
        public void Fill_CmbBandAlarmGroup()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select distinct  Bandalarmsgroup_id ,bandalarmsgroup_Name from bandalarm_data");
                cmbBandGroup.Properties.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    cmbBandGroup.Properties.Items.Add(dr["bandalarmsgroup_Name"]);
                }
            }
            catch { }
        }
      
        public void showPowerBandData()
        {

            try
            {
                DataTable dtt = new DataTable();
                dtt = DbClass.getdata(CommandType.StoredProcedure, " call Get_PowerBand ('" + V_Band_Group_id + "')");
                int b = 0;
                dgvBAPH.Rows.Clear();
                foreach (DataRow dr in dtt.Rows)
                {
                 
                    dgvBAPH.Rows.Add();
                    dgvBAPH.Rows[b].Cells["colBANamePWR"].Value = Convert.ToString(dr["BandAlarm_Name"]);
                    dgvBAPH.Rows[b].Cells["colFrqPwr"].Value = Convert.ToString(dr["Freq"]);
                    dgvBAPH.Rows[b].Cells["colxAxisPwr"].Value = Convert.ToString(dr["X"]);
                    dgvBAPH.Rows[b].Cells["colYaxisPwr"].Value = Convert.ToString(dr["Y"]);
                    //dgvBAPH.Rows[b].Cells["ID"].Value = Convert.ToString(dr["ID"]);
                    dgvBAPH.Rows[b].Cells["colCounterPWR"].Value = b + 1;
                    b = b + 1;
                }
            }
            catch
            { }


        }

        public void showDemoBandData()
        {
            try
            {
                DataTable dtd = new DataTable();
                dtd = DbClass.getdata(CommandType.StoredProcedure, " call Get_DemoBand ( '" + V_Band_Group_id+ "')");
                int b = 0;
                dgvBADA.Rows.Clear();
                foreach (DataRow dr in dtd.Rows)
                {

                    dgvBADA.Rows.Add();
                    dgvBADA.Rows[b].Cells["colBANameDemo"].Value = Convert.ToString(dr["Demodulate_Name"]);
                    dgvBADA.Rows[b].Cells["colFrqDemo"].Value = Convert.ToString(dr["Freq"]);
                    dgvBADA.Rows[b].Cells["dgvXDemo"].Value = Convert.ToString(dr["X"]);
                    dgvBADA.Rows[b].Cells["dgvYDemo"].Value = Convert.ToString(dr["Y"]);
                    //dgvBADA.Rows[b].Cells["idDemo"].Value = Convert.ToString(dr["ID"]);
                    dgvBADA.Rows[b].Cells["colCounterDemo"].Value = b + 1;
                   // dgvBADA.Rows[b].Cells["D_Axis_Type"].Value = Convert.ToString(dr["axis_type"]);
                    b = b + 1;
                }
            }
            catch
            { }

        }

        private void frmBandAlarms_Load(object sender, EventArgs e)
        {
            lnkDelete.Enabled = false;
        }

        private void dgvBAPH_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvBAPH.IsCurrentCellDirty)
            {
                dgvBAPH.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvBADA_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvBADA.IsCurrentCellDirty)
            {
                dgvBADA.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvBAPH_Leave(object sender, EventArgs e)
        {
           
             try
            {

                if (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(V_Band_Group_id).Trim(), "0")) == 0)
                {
                    MessageBox.Show("Please Select the Group Name or Create a New Group ","Information",MessageBoxButtons.OK,MessageBoxIcon.Information );
                    dgvBAPH.Rows.Clear();
                    return;
                }


                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.StoredProcedure, " call BandData_By_ID ('" + V_Band_Group_id + "')");

                for (int a = 0; a < dgvBAPH.Rows.Count - 1; a++)
                {
                   
                        
                        BAName = Convert.ToString(dgvBAPH.Rows[a].Cells["colBANamePWR"].Value).Trim();
                        BAValue = Convert.ToDouble(PublicClass.DefVal(Convert.ToString((dgvBAPH.Rows[a].Cells["colFrqPwr"].Value)).Trim(), "0"));

                        xAxis = Convert.ToDouble(PublicClass.DefVal(Convert.ToString((dgvBAPH.Rows[a].Cells["colxAxisPwr"].Value)).Trim(), "0"));
                        yAxis = Convert.ToDouble(PublicClass.DefVal(Convert.ToString((dgvBAPH.Rows[a].Cells["colYaxisPwr"].Value)).Trim(), "0"));
                     
                     
                        if (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dgvBAPH.Rows[a].Cells["ID"].Value).Trim(), "0")) == 0 && Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dgvBAPH.Rows[a].Cells["colCounterPWR"].Value).Trim(), "0")) == 0)
                        {
                            string pba_id = Convert.ToString(a + 1);
                            for (int axisId = 0; axisId <= 3; axisId++)
                            {
                                B_Axis_type_v = axisId;
                                DbClass.executequery(CommandType.StoredProcedure, "call Insert_PowerBand('" + BAName.Trim() + "' , '" + BAValue + "' ,'" + xAxis + "' ,'" + yAxis + "' ,'" + pba_id + "' ,  '" + PublicClass.GetDatetime() + "','" + V_Band_Group_id.Trim() + "','" + B_Axis_type_v + "')");
                              
                            }
                            DataTable DT = new DataTable();
                        
                            DT = DbClass.getdata(CommandType.StoredProcedure, "call Get_MaxIDOfBandData ");
                            dgvBAPH.Rows[a].Cells["ID"].Value = Convert.ToString(Convert.ToInt32(PublicClass.DefVal(Convert.ToString(DT.Rows[0][0]), "0")));
                            dgvBAPH.Rows[a].Cells["colCounterPWR"].Value = pba_id;

                        }
                        else
                        {
                            if ((BAName != Convert.ToString(dt.Rows[0]["BandAlarm_Name"]).Trim()) || ((BAValue != Convert.ToDouble(Convert.ToString(dt.Rows[0]["Freq"]).Trim()))))
                            {
                                DbClass.executequery(CommandType.StoredProcedure, "call Update_BandData( '" + BAName + "' , '" + BAValue + "' , '" + xAxis + "' , '" + yAxis + "' ,  '" + PublicClass.GetDatetime() + "' , '" + PublicClass.DefVal(Convert.ToString(dgvBAPH.Rows[a].Cells["colCounterPWR"].Value), "0") + "' ,'" + V_Band_Group_id.Trim() + "'  )");
                            
                            }
                        }
                    }
                }
            catch
            { }
        }

        private void dgvBADA_Leave(object sender, EventArgs e)
        {
            try
            {

                if ( Convert.ToInt32  (PublicClass .DefVal( Convert.ToString(V_Band_Group_id).Trim() ,"0"))== 0)
                {
                    MessageBox.Show("Please Select the Group Name or Create a New Group ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvBADA.Rows.Clear();
                    return;
                }
               
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.StoredProcedure, " call Get_DemoDAtaByID ( '" + V_Band_Group_id + "')");


             
                    for (int a = 0; a < dgvBADA.Rows.Count - 1; a++)
                    {
                          BAName = Convert.ToString(dgvBADA.Rows[a].Cells["colBANameDemo"].Value).Trim();
                            BAValue = Convert.ToDouble(PublicClass.DefVal(Convert.ToString((dgvBADA.Rows[a].Cells["colFrqDemo"].Value)).Trim(), "0"));
                            xAxis = Convert.ToDouble(PublicClass.DefVal(Convert.ToString((dgvBADA.Rows[a].Cells["dgvXDemo"].Value)).Trim(), "0"));
                            yAxis = Convert.ToDouble(PublicClass.DefVal(Convert.ToString((dgvBADA.Rows[a].Cells["dgvYDemo"].Value)).Trim(), "0"));


                            string pba_id = Convert.ToString(a + 1);
                            if (BAName == " " || BAValue == 0 || xAxis == 0 || yAxis == 0)
                            {
                                MessageBox.Show("Please fill all the values properly");
                                return;
                            }

                            if (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dgvBADA.Rows[a].Cells["idDemo"].Value).Trim(), "0")) == 0 && Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dgvBADA.Rows[a].Cells["colCounterDemo"].Value).Trim(), "0")) == 0)
                            {
                                for (int axisId = 4; axisId <= 7; axisId++)
                                {
                                    D_Axis_type_v = axisId;
                                    DbClass.executequery(CommandType.StoredProcedure, "call Insert_DemodulateBand('" + BAName.Trim() + "' , '" + BAValue + "' ,'" + xAxis + "' ,'" + yAxis + "' ,'" + pba_id + "' ,  '" + PublicClass.GetDatetime() + "','" + V_Band_Group_id + "','" + D_Axis_type_v + "')");

                                }
                                DataTable DT = new DataTable();
                                DT = DbClass.getdata(CommandType.StoredProcedure, " call Get_MaxIdOfDemoBand ");
                                dgvBADA.Rows[a].Cells["idDemo"].Value = Convert.ToString(Convert.ToInt32(PublicClass.DefVal(Convert.ToString(DT.Rows[0][0]), "0")));
                                dgvBADA.Rows[a].Cells["colCounterDemo"].Value = pba_id;
                            }
                            else
                            {

                                if ((BAName != Convert.ToString(dt.Rows[0]["Demodulate_Name"]).Trim()) || ((BAValue != Convert.ToDouble(Convert.ToString(dt.Rows[0]["Freq"]).Trim())) || (xAxis != Convert.ToDouble(Convert.ToString(dt.Rows[0]["X"]).Trim())) || (yAxis != Convert.ToDouble(Convert.ToString(dt.Rows[0]["Y"]).Trim()))))
                                {

                                    DbClass.executequery(CommandType.StoredProcedure, "call Update_DemoData ('" + BAName + "' , '" + BAValue + "' , '" + xAxis + "' , '" + yAxis + "' , '" + PublicClass.GetDatetime() + "','" + PublicClass.DefVal(Convert.ToString(dgvBADA.Rows[a].Cells["colCounterDemo"].Value), "0") + "','" + V_Band_Group_id + "')");
                              
                                }
                            }
                        }
                       
                    }
            catch
            { }
        }

       

        private void dgvBAPH_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string cColumn = null;
                cColumn = dgvBAPH.Columns[e.ColumnIndex].HeaderText;
                xAxis = Convert.ToDouble(PublicClass.DefVal(Convert.ToString((dgvBAPH.CurrentRow.Cells["colxAxisPwr"].Value)), "0"));
                yAxis = Convert.ToDouble(PublicClass.DefVal(Convert.ToString((dgvBAPH.CurrentRow.Cells["colYaxisPwr"].Value)), "0"));
                switch (cColumn)
                {
                    case "Band Name":
                        {
                            BAName = Convert.ToString(dgvBAPH.CurrentRow.Cells["colBANamePWR"].Value).Trim();
                            if (BAName == " ")
                            {
                                MessageBox.Show("Name Can not be Balnk");
                            }

                            break;

                        }
                    case "Frequency":
                        {
                            BAValue = Convert.ToDouble(PublicClass.DefVal(Convert.ToString((dgvBAPH.CurrentRow.Cells["colFrqPwr"].Value)), "0"));
                            int fvalueIndex = dgvBAPH.CurrentRow.Index;
                            if (fvalueIndex == 0)
                            {

                                double nRowValue = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dgvBAPH.Rows[fvalueIndex + 1].Cells["colFrqPwr"].Value), "0"));
                                if (nRowValue != 0)
                                {
                                    if (nRowValue <= BAValue)
                                    {
                                        MessageBox.Show("Frequency value can not be greater than from existing Band Alarm");
                                        dgvBAPH.CurrentRow.Cells["colFrqPwr"].Value = " ";
                                    }
                                }
                            }

                            if (dgvBAPH.CurrentRow.Index != 0)
                            {
                                int BAval = dgvBAPH.CurrentRow.Index - 1;

                                fCount = Convert.ToDouble(dgvBAPH.Rows[BAval].Cells["colFrqPwr"].Value);

                                if (fCount >= BAValue)
                                {
                                    MessageBox.Show("Frequency value can not be Less than from existing Band Alarm");
                                    dgvBAPH.CurrentRow.Cells["colFrqPwr"].Value = " ";
                                    dgvBAPH.CurrentCell.Selected = true;

                                }
                            }
                            break;

                        }
                    case "High":
                        {
                            if (xAxis <= yAxis)
                            {
                                MessageBox.Show("  High value can not be less than low value ");
                                dgvBAPH.CurrentRow.Cells["colxAxisPwr"].Value = " ";

                            }

                            break;
                        }

                    case "Low":
                        {
                            if (yAxis >= xAxis)
                            {
                                MessageBox.Show(" Low value can not be greater than high value ");
                                dgvBAPH.CurrentRow.Cells["colYaxisPwr"].Value = " ";
                            }

                            break;
                        }
                }

            }
            catch
            {
            }
        }

        private void dgvBADA_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string cColumn = null;
                cColumn = dgvBADA.Columns[e.ColumnIndex].HeaderText;
                xAxis = Convert.ToDouble(PublicClass.DefVal(Convert.ToString((dgvBADA.CurrentRow.Cells["dgvXDemo"].Value)), "0"));
                yAxis = Convert.ToDouble(PublicClass.DefVal(Convert.ToString((dgvBADA.CurrentRow.Cells["dgvYDemo"].Value)), "0"));
                switch (cColumn)
                {
                    case "Band Name":
                        {
                            BAName = Convert.ToString(dgvBADA.CurrentRow.Cells["colBANameDemo"].Value).Trim();
                            if (BAName == " ")
                            {
                                MessageBox.Show("Name Can't be Blank");
                            }

                            break;

                        }
                    case "Frequency":
                        {
                            BAValue = Convert.ToDouble(PublicClass.DefVal(Convert.ToString((dgvBADA.CurrentRow.Cells["colFrqDemo"].Value)), "0"));
                            int fvalueIndex = dgvBADA.CurrentRow.Index;
                            if (fvalueIndex == 0)
                            {

                                double nRowValue = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dgvBADA.Rows[fvalueIndex + 1].Cells["colFrqDemo"].Value), "0"));
                                if (nRowValue != 0)
                                {
                                    if (nRowValue <= BAValue)
                                    {
                                        MessageBox.Show("Frequency value can not be greater than from existing Band Alarm");
                                        dgvBADA.CurrentRow.Cells["colFrqDemo"].Value = " ";
                                    }
                                }
                            }

                            if (dgvBADA.CurrentRow.Index != 0)
                            {
                                int BAval = dgvBADA.CurrentRow.Index - 1;

                                fCount = Convert.ToDouble(dgvBADA.Rows[BAval].Cells["colFrqDemo"].Value);

                                if (fCount >= BAValue)
                                {
                                    MessageBox.Show("Frequency value can not be Less than from existing Band Alarm");
                                    dgvBADA.CurrentRow.Cells["colFrqDemo"].Value = " ";
                                    dgvBADA.CurrentCell.Selected = true;

                                }
                            }
                            break;
                        }
                    case "High":
                        {
                            if (xAxis <= yAxis)
                            {
                                MessageBox.Show("High can't less than high");
                                dgvBADA.CurrentRow.Cells["dgvXDemo"].Value = " ";
                            }
                            break;
                        }
                    case "Low":
                        {
                            if (yAxis >= xAxis)
                            {
                                MessageBox.Show("Low can't greater than high");
                                dgvBADA.CurrentRow.Cells["dgvYDemo"].Value = " ";
                            }

                            break;
                        }
                }
            }
            catch
            {
            }
        }

        private void dgvBADA_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    int ee = dgvBADA.CurrentRow.Index;
                    string didd = PublicClass.DefVal(Convert.ToString(dgvBADA.CurrentRow.Cells["colCounterDemo"].Value).Trim(), "0");
                    DbClass.executequery(CommandType.StoredProcedure, "call Delete_DemoDataByID('" + PublicClass.DefVal(Convert.ToString(dgvBADA.CurrentRow.Cells["colCounterDemo"].Value).Trim(), "0") + "','" + V_Band_Group_id + "')");
                    dgvBADA.Rows.RemoveAt(ee);
                }
            }
            catch
            {
            }
        }

        private void dgvFaultFreq_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {

                    int ee = dgvBAPH.CurrentRow.Index;
                    string bidd = PublicClass.DefVal(Convert.ToString(dgvBAPH.CurrentRow.Cells["ID"].Value).Trim(), "0");
                    DbClass.executequery(CommandType.StoredProcedure, "call Delete_BandDataByID('" + bidd + "')");
                    dgvBAPH.Rows.RemoveAt(ee);
                }
            }
            catch
            {
            }
        }
       
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                _objMain.lblStatus.Caption = "Status: Existing Band Alarms";
                _objMain.fillform();
            }
            catch { }
        }
        string V_Band_Group_id = "";       
        public string GetBandGroupID(string Bandgroupname)
        {
            try
            {
                DataTable dtBandAramGroup = new DataTable();
                dtBandAramGroup = DbClass.getdata(CommandType.Text, "select distinct  Bandalarmsgroup_id  from bandalarm_data where bandalarmsgroup_Name = '" + Bandgroupname.Trim() + "' ");
                if (dtBandAramGroup.Rows.Count > 0)
                {
                    V_Band_Group_id = PublicClass.DefVal(Convert.ToString(dtBandAramGroup.Rows[0][0]), "0");

                }
                else
                {
                    V_Band_Group_id = "0";
                }
            }
            catch { }
            return V_Band_Group_id;
        }

        private void dgvBAPH_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)dgvBAPH.Rows[e.RowIndex].Cells["B_Axis_Type"].OwningColumn;
                combo.DataSource = dt_Band;
                combo.ValueMember = "Id";
                combo.DisplayMember = "Name";
            }
            catch { }
        }

        private void dgvBADA_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)dgvBADA.Rows[e.RowIndex].Cells["D_Axis_Type"].OwningColumn;
                combo.DataSource = dt_Demodulate;
                combo.ValueMember = "Id";
                combo.DisplayMember = "Name";
            }
            catch { }
        }

        private void dgvBAPH_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
            }
            catch { }
        }



        private void cmbBandGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbBandGroup.Text).Trim() != "")
                {
                    V_Band_Group_id = GetBandGroupID(Convert.ToString(cmbBandGroup.Text).Trim());
                    showPowerBandData();
                    showDemoBandData();
                    string ss = cmbBandGroup.Text.Trim();
                    Fill_CmbBandAlarmGroup();
                    cmbBandGroup.Text = ss;
                    lnkDelete.Enabled = true;
                }

            }
            catch { }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                TxtGroupName.Visible = true;
                dgvBADA.Rows.Clear();
                dgvBAPH.Rows.Clear();
                _objMain.lblStatus.Caption = "Status: Create New Group Name";
            }
            catch { }
        }

        private void TxtGroupName_Leave(object sender, EventArgs e)
        {
            if (Convert.ToString (  TxtGroupName .Text ).Trim ()!="")
            {

               DataTable dtt=new DataTable  ();
               dtt=DbClass.getdata (CommandType.Text ,"select  * from bandalarm_data where bandalarmsgroup_Name ='" +Convert.ToString (  TxtGroupName .Text ).Trim () + "' ");
               
               if (dtt.Rows.Count == 0)
               { 
                DbClass.executequery(CommandType.Text, "insert  bandalarm_data  (bandalarmsgroup_Name) values ('" + Convert.ToString(TxtGroupName.Text).Trim() + "')");
                V_Band_Group_id = GetBandGroupID(Convert.ToString(TxtGroupName.Text).Trim());
                _objMain.lblStatus.Caption = "Status: Create Group Name Successfully";
               }
               else
               {
                   MessageBox.Show(this, "This Band Group is already exist ...." ,"Inforamtion",MessageBoxButtons.OK,MessageBoxIcon.Information );
                   TxtGroupName.Text = "";
                   TxtGroupName.Focus();
                   V_Band_Group_id = "0";
                   return;
               }
            }
            Fill_CmbBandAlarmGroup();
            cmbBandGroup.Text = TxtGroupName.Text.Trim();
            TxtGroupName.Text = "";
            TxtGroupName.Visible = false;
        }

        private void dgvBAPH_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    int ee = dgvBAPH.CurrentRow.Index;                    
                    //string didd = PublicClass.DefVal(Convert.ToString(dgvBAPH.CurrentRow.Cells["colCounterDemo"].Value).Trim(), "0");
                    DbClass.executequery(CommandType.StoredProcedure, "call Delete_BandDataByID('" + PublicClass.DefVal(Convert.ToString(dgvBAPH.CurrentRow.Cells["colCounterPWR"].Value).Trim(), "0") + "','" + V_Band_Group_id + "')");
                    dgvBAPH.Rows.RemoveAt(ee);
                }
            }
            catch
            {
            }
        }

        private void lnkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string bgName = Convert.ToString(cmbBandGroup.SelectedItem);
                DataTable dtCheck = DbClass.getdata(CommandType.Text, "Select Bandalarmsgroup_id from bandalarm_data where bandalarmsgroup_Name = '" + bgName + "'");
                if (dtCheck.Rows.Count > 0)
                {
                    string bgID = Convert.ToString(dtCheck.Rows[0]["Bandalarmsgroup_id"]);
                    DataTable dtchk = DbClass.getdata(CommandType.Text, "Select pt.ID , pt.Band_ID  from bandalarm_data ba inner join type_point pt on pt.Band_ID = ba.Bandalarmsgroup_id where ba.Bandalarmsgroup_id='" + bgID + "'");
                    if (dtchk.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "Band Group Use in Point Type", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        DbClass.executequery(CommandType.Text, "Delete from band_data where Group_ID = '" + bgID + "'");
                        DbClass.executequery(CommandType.Text, "delete from bandalarm_data where Bandalarmsgroup_id='" + bgID + "'");
                        Fill_CmbBandAlarmGroup();
                        MessageBox.Show("Band Group Deleted Successfully");
                        cmbBandGroup.SelectedIndex = -1;
                        dgvBADA.Rows.Clear();
                        dgvBAPH.Rows.Clear();
                        _objMain.lblStatus.Caption = "Status: Band Group Deleted Successfully";
                    }
                }
                else
                {
                }
            }
            catch { }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch { }
        }

        private void dgvBAPH_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress -= new KeyPressEventHandler(Column0_KeyPress);
                if (dgvBAPH.CurrentCell.ColumnIndex == 0) //Desired Column
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column0_KeyPress);
                    }
                }
                e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
                if (dgvBAPH.CurrentCell.ColumnIndex == 1) //Desired Column
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    }
                }
                if (dgvBAPH.CurrentCell.ColumnIndex == 2) //Desired Column
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    }
                }
                if (dgvBAPH.CurrentCell.ColumnIndex == 3) //Desired Column
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    }
                }
            }
            catch { }
        }

        private void dgvBADA_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress -= new KeyPressEventHandler(Column0_KeyPress);
                if (dgvBADA.CurrentCell.ColumnIndex == 0) //Desired Column
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column0_KeyPress);
                    }
                }
                e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
                if (dgvBADA.CurrentCell.ColumnIndex == 1) //Desired Column
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    }
                }
                if (dgvBADA.CurrentCell.ColumnIndex == 2) //Desired Column
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    }
                }
                if (dgvBADA.CurrentCell.ColumnIndex == 3) //Desired Column
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    }
                }
            }
            catch { }
        }

        private void TxtGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (PublicClass.chkKeyEnter(e))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }      

    }
}