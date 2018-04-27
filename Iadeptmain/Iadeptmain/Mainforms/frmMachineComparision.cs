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
using DevExpress.XtraTreeList.Nodes;
using Iadeptmain.Images;
using Iadeptmain.BaseUserControl;
using DevExpress.XtraEditors.Repository;

namespace Iadeptmain.Mainforms
{
    public partial class frmMachineComparision : DevExpress.XtraEditors.XtraForm
    {
        frmIAdeptMain objMain = null;
        PointGeneral1 objPointGeneral = null;
        IadeptUserControl objUserControl = null;
        List<TreeListNode> chkNodes = null;
        public string sNodeType = null;
        string ids = null;
        RepositoryItem emptyEditor = null;
        public frmMachineComparision()
        {
            InitializeComponent();
            Create_TreeListColumn();
            FillMachineList();

        }
        public IadeptUserControl usercontrol
        {
            get
            {
                return objUserControl;
            }
            set
            {
                objUserControl = value;
            }
        }

        public frmIAdeptMain Main
        {
            get
            {
                return objMain;
            }
            set
            {
                objMain = value;
            }
        }

        public PointGeneral1 ptMain
        {
            get
            {
                return objPointGeneral;
            }
            set
            {
                objPointGeneral = value;
            }
        }

        public void Create_TreeListColumn()
        {
            try
            {

                trlMachine.Columns.Add();
                trlMachine.Columns[0].Caption = "Id";
                trlMachine.Columns[0].VisibleIndex = -1;

                trlMachine.OptionsView.ShowCheckBoxes = true;

                trlMachine.Columns.Add();
                trlMachine.Columns[1].Caption = "";
                trlMachine.Columns[1].VisibleIndex = 0;

                trlMachine.Columns.Add();
                trlMachine.Columns[2].Caption = "type";
                trlMachine.Columns[2].VisibleIndex = -1;
            }
            catch { }
        }

        public void FillMachineList()
        {
            DataTable MachineDt = new DataTable();
            DataTable PointDt = new DataTable();
            int r = 0;
            try
            {
                sNodeType = "";
                MachineDt = DbClass.getdata(CommandType.Text, "select  Machine_ID ,NAME ,Description,TrainID from machine_info  ");
                PointDt = DbClass.getdata(CommandType.Text, "SELECT  Point_ID ,POINTNAME ,PointDesc,Machine_ID  FROM POINT  ");
                trlMachine.ClearNodes();
                TreeListNode parentForSubelement11 = null;
                TreeListNode parentForRootPoint11 = null;

                // **********************Machine ***********************

                foreach (DataRow MachineRow in MachineDt.Rows)
                {
                    Image machineimage = ImageResources.subelement_new;
                    ids = null;
                    ids = "p.Machine_ID = " + Convert.ToString(MachineRow["Machine_ID"]);
                    //objUserControl.setflag("machine_id =" + Convert.ToString(MachineRow["Machine_ID"]));

                    parentForSubelement11 = trlMachine.AppendNode(new object[] { Convert.ToString(MachineRow["Machine_ID"]), Convert.ToString(MachineRow["name"]), "Machine" }, null);

                    // *****************Point************************************ 

                    foreach (DataRow PointRow in PointDt.Select(" Machine_ID = '" + Convert.ToString(MachineRow["Machine_ID"]) + "' "))
                    {
                        Image pointimage = Iadeptmain.Images.ImageResources.Point;
                        ids = null;
                        ids = "pd.Point_ID = " + Convert.ToString(PointRow["Point_ID"]);
                        //objUserControl.setflag("point_id =" + Convert.ToString(PointRow["Point_ID"]));
                        parentForRootPoint11 = trlMachine.AppendNode(new object[] { Convert.ToString(PointRow["Point_ID"]), Convert.ToString(PointRow["POINTNAME"]), "Point" }, parentForSubelement11);

                    }//****************end of point
                }//********************end of Machine
                trlMachine.ExpandAll();
                sNodeType = (string)trlMachine.FocusedNode.GetDisplayText(2);
                PublicClass.SMachineID = (string)trlMachine.FocusedNode.GetDisplayText(0);
                PublicClass.SPointID = (string)trlMachine.FocusedNode.GetDisplayText(0);
            }
            catch
            {
            }
        }


        public void GetAllCheckedNode()
        {
            var chkNodess = chkNodes;
            foreach (TreeListNode n in trlMachine.GetAllCheckedNodes())
            {
                MessageBox.Show(n.GetValue("Id").ToString());
            }
        }

        private void trlMachine_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            bool GraphStatus = false;
            List<TreeListNode> chkNodes = trlMachine.GetAllCheckedNodes();
            trlMachine.FocusedNode = e.Node;
            sNodeType = e.Node.GetValue("type").ToString();
            if (sNodeType != "Point")
            {
                trlMachine.SetNodeCheckState(e.Node, CheckState.Unchecked);
                return;
            }
            else
            {
                if (chkNodes.Count > 5)
                {
                    MessageBox.Show("Maximum allowed spectrum are 5. Please uncheked a node before next to be check !", "Wrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    trlMachine.SetNodeCheckState(e.Node, CheckState.Unchecked);
                    return;
                }
                else
                {
                    GraphStatus = CreateGraphForSelecetedPoint(e.Node.GetValue("Id").ToString());
                }
            }
        }

        private void trlMachine_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            //try {
            //    List<TreeListNode> chkNodes = trlMachine.GetAllCheckedNodes();
            //    trlMachine.FocusedNode = e.Node;
            //    if(chkNodes.Count < 5 )
            //    {
            //        //MessageBox.Show("Maximum allowed spectrum are 5. Please uncheked a node before next to be check !", "Wrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        trlMachine.SetNodeCheckState(e.Node, CheckState.Unchecked);
            //        return;
            //    }
            //}
            //catch { }
        }

        private void trlMachine_MouseClick(object sender, MouseEventArgs e)
        {

        }

        public bool CreateGraphForSelecetedPoint(string SelectedPointID)
        {
            bool created = false;
            // PublicClass.checkgraphtime = "false";
            //    string T_X = null;
            //    string P_X = null;
            //    string P1_X = null;
            //    string P2_X = null; ;
            //    string P21_X = null;
            //    string P3_X = null;
            //    string P31_X = null;
            //    string CEP_X = null;
            //    string DEM_X = null;
            //try
            //{
            //    PublicClass.SPointID = SelectedPointID;
            //    {
            //        string CurrentInstName = PublicClass.currentInstrument;
            //        if (CurrentInstName == "Impaq-Benstone" || CurrentInstName == "SKF/DI" || PublicClass.currentInstrument == "FieldPaq2")
            //        {
            //            PublicClass.ssNodeType = sNodeType;
            //            PublicClass.AHVCH1 = "Horizontal";
            //        }
            //        if (objPointGeneral.IsDisposed)
            //        {
            //            objPointGeneral = new PointGeneral1();
            //            objPointGeneral.MainForm1 = objMain;
            //            objPointGeneral.grp = m_graph;
            //            DataTable dt1 = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,timeH_X,timeH_Y,PH_X,PH_Y,P1H_X,P1H_Y,P2H_X,P2H_Y,P21H_X,P21H_Y,P3H_X,P3H_Y,P31H_X,P31H_Y,CEPH_X,CEPH_Y,DEMH_X,DEMH_Y FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
            //            foreach (DataRow DR in dt1.Rows)
            //            {
            //                T_X = Convert.ToString(DR["timeH_X"]);
            //                P_X = Convert.ToString(DR["PH_X"]);
            //                P1_X = Convert.ToString(DR["P1H_X"]);
            //                P2_X = Convert.ToString(DR["P2H_X"]);
            //                P21_X = Convert.ToString(DR["P21H_X"]);
            //                P3_X = Convert.ToString(DR["P3H_X"]);
            //                P31_X = Convert.ToString(DR["P31H_X"]);
            //                CEP_X = Convert.ToString(DR["CEPH_X"]);
            //                DEM_X = Convert.ToString(DR["DEMH_X"]);

            //            }
            //            if (T_X != null || P_X != null || P1_X != null || P2_X != null || P21_X != null || P3_X != null || P31_X != null || CEP_X != null || DEM_X != null)
            //            {
            //                if (T_X != "0|" || P_X != "0|" || P1_X != "0|" || P2_X != "0|" || P21_X != "0|" || P3_X != "0|" || P31_X != "0|" || CEP_X != "0|" || DEM_X != "0|")
            //                {
            //                    if (T_X != "" || P_X != "" || P1_X != "" || P2_X != "" || P21_X != "" || P3_X != "" || P31_X != "" || CEP_X != "" || DEM_X != "")
            //                    {
            //                        objPointGeneral.TopLevel = false;
            //                        pnlGraph.Controls.Add(objPointGeneral);
            //                        if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
            //                        {
            //                            graph.Showgraphs();
            //                        }
            //                        else
            //                        { objPointGeneral.ShowgraphsforDI(); }
            //                        objPointGeneral.Dock = DockStyle.Fill;
            //                        TabGraph.PageVisible = true;
            //                        CtrTab.SelectedTabPageIndex = 12;
            //                        objPointGeneral.Show();
            //                    }
            //                    else
            //                    {
            //                        MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                        return;
            //                    }
            //                }
            //                else
            //                {
            //                    MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                    return;
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            objPointGeneral.MainForm1 = objMain;
            //            objPointGeneral.grp = m_graph;
            //            DataTable dt1 = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,timeH_X,timeH_Y,PH_X,PH_Y,P1H_X,P1H_Y,P2H_X,P2H_Y,P21H_X,P21H_Y,P3H_X,P3H_Y,P31H_X,P31H_Y,CEPH_X,CEPH_Y,DEMH_X,DEMH_Y FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
            //            foreach (DataRow DR in dt1.Rows)
            //            {
            //                T_X = Convert.ToString(DR["timeH_X"]);
            //                P_X = Convert.ToString(DR["PH_X"]);
            //                P1_X = Convert.ToString(DR["P1H_X"]);
            //                P2_X = Convert.ToString(DR["P2H_X"]);
            //                P21_X = Convert.ToString(DR["P21H_X"]);
            //                P3_X = Convert.ToString(DR["P3H_X"]);
            //                P31_X = Convert.ToString(DR["P31H_X"]);
            //                CEP_X = Convert.ToString(DR["CEPH_X"]);
            //                DEM_X = Convert.ToString(DR["DEMH_X"]);
            //            }
            //            if (T_X != null || P_X != null || P1_X != null || P2_X != null || P21_X != null || P3_X != null || P31_X != null || CEP_X != null || DEM_X != null)
            //            {
            //                if (T_X != "0|" || P_X != "0|" || P1_X != "0|" || P2_X != "0|" || P21_X != "0|" || P3_X != "0|" || P31_X != "0|" || CEP_X != "0|" || DEM_X != "0|")
            //                {
            //                    if (T_X != "" || P_X != "" || P1_X != "" || P2_X != "" || P21_X != "" || P3_X != "" || P31_X != "" || CEP_X != "" || DEM_X != "")
            //                    {
            //                        objPointGeneral.TopLevel = false;
            //                        pnlGraph.Controls.Add(objPointGeneral);
            //                        if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
            //                        {
            //                            objPointGeneral.Showgraphs();
            //                        }
            //                        else
            //                        { objPointGeneral.ShowgraphsforDI(); }
            //                        objPointGeneral.Dock = DockStyle.Fill;
            //                        TabGraph.PageVisible = true;
            //                        CtrTab.SelectedTabPageIndex = 12;
            //                        objPointGeneral.Show();
            //                    }
            //                    else
            //                    {
            //                        MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                        return;
            //                    }
            //                }
            //                else
            //                {
            //                    MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                    return;
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return;
            //            }
            //        }
            //    }
            //    catch{}
            //}
            //catch (Exception ex) { throw ex; }
            return created;
        }
    }
}