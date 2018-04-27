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
using Iadeptmain.GlobalClasess;
using Iadeptmain.GlobalClasses;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Menu;
using System.Data.Odbc;
using Iadeptmain.Classes;
using trial6;
namespace Iadeptmain.Mainforms
{
    public partial class rproute : DevExpress.XtraEditors.XtraForm
    {
        TreeListNode Node_Parent = null;
        TreeListHitInfo objRouteInfo = null;
        TreeListNode Node_Plant = null;
        TreeListNode Node_Area = null;
        TreeListNode Node_Train = null;
        TreeListNode Node_Machine = null;
        TreeListNode Node_Point = null;
        frmIAdeptMain _objMain;
        string IDVAlue = "";
        DataTable dtPlant = new DataTable();
        DataTable dtArea = new DataTable();
        DataTable dtTrain = new DataTable();
        DataTable dtMachine = new DataTable();
        DataTable dtPoint = new DataTable();
        Boolean addition, deletion, modification, Preivew, updd;
        
        frmupdownload updown = null;
        public rproute()
        {
            InitializeComponent();            
            Create_TreeListColumn();
            PublicClass.SeteUserSettings(ref addition, ref deletion, ref modification, ref Preivew, ref updd, "Route");
            setUserSetting();
            
        }


        private void setUserSetting()
        {
            try
            {
                if(updd)
                {
                    BtnTransfer.Enabled = true;
                }
                else
                {
                    BtnTransfer.Enabled = false;
                }

                if (modification)
                {
                    TxtRouteName.Enabled = true;
                }
                else
                {
                    TxtRouteName.Enabled = false;
                }

              
            }
            catch
            {

            }
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

        public void Create_TreeListColumn()
        {
            try
            {

                trlFactoriesPrsnt11.Columns.Add();
                trlFactoriesPrsnt11.Columns[0].Caption = "Id";
                trlFactoriesPrsnt11.Columns[0].VisibleIndex = -1;

                trlFactoriesPrsnt11.Columns.Add();
                trlFactoriesPrsnt11.Columns[1].Caption = "";
                trlFactoriesPrsnt11.Columns[1].VisibleIndex = 0;

                trlFactoriesPrsnt11.Columns.Add();
                trlFactoriesPrsnt11.Columns[2].Caption = "Description";
                trlFactoriesPrsnt11.Columns[2].VisibleIndex = -1;

                ////trlFactoriesPrsnt11.Columns.Add();
                ////trlFactoriesPrsnt11.Columns[2].Caption = "ParentID";
                ////trlFactoriesPrsnt11.Columns[2].VisibleIndex = -1;
            
                trlRoute11.Columns.Add();
                trlRoute11.Columns[0].Caption = "Id";
                trlRoute11.Columns[0].VisibleIndex = -1;
              
                trlRoute11.Columns.Add();
                trlRoute11.Columns[1].Caption = "";
                trlRoute11.Columns[1].VisibleIndex = 0;
                trlRoute11.Columns.Add();
                trlRoute11.Columns[2].Caption = "Type";
                trlRoute11.Columns[2].VisibleIndex = -1;
             
                trlRoute11.OptionsBehavior.DragNodes = true;
          
            }
            catch { }

        }
        public void FillPlantwise()
        {
            try
            {
               
                dtPlant = DbClass.getdata(CommandType.Text, "select Factory_ID,Name,Description from  factory_info");
                foreach (DataRow dr in dtPlant.Rows )
                {
                    trlFactoriesPrsnt11.AppendNode(new object[] { Convert.ToString(dr["Factory_ID"]), Convert.ToString(dr["Name"]), Convert.ToString(dr["Description"]) }, null);

                }

            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }
        public void FillAreawise()
        {
            try
            {            
                dtArea = DbClass.getdata(CommandType.Text, "select Area_ID,name,Description from Area_info");
                foreach (DataRow dr in dtArea.Rows)
                {
                    trlFactoriesPrsnt11.AppendNode(new object[] { Convert.ToString(dr["Area_ID"]), Convert.ToString(dr["Name"]), Convert.ToString(dr["Description"]) }, null);

                }

            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }
        public void FillTrainwise()
        {
            try
            {
             
                dtTrain = DbClass.getdata(CommandType.Text, "select Train_ID,name,Description from train_info");
                foreach (DataRow dr in dtTrain.Rows)
                {
                    trlFactoriesPrsnt11.AppendNode(new object[] { Convert.ToString(dr["Train_ID"]), Convert.ToString(dr["Name"]), Convert.ToString(dr["Description"]) }, null);

                }

            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }
        public void FillMachinewise()
        {
            try
            {
               
                dtMachine = DbClass.getdata(CommandType.Text, "select Machine_ID,name,Description from machine_info");
                foreach (DataRow dr in dtMachine.Rows)
                {
                    trlFactoriesPrsnt11.AppendNode(new object[] { Convert.ToString(dr["Machine_ID"]), Convert.ToString(dr["Name"]), Convert.ToString(dr["Description"]) }, null);

                }
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }
        public void FillPointwise()
        {
            try
            {
                
                dtPoint = DbClass.getdata(CommandType.Text, "select distinct pt.point_ID,pt.PointName,pt.PointDesc from point pt inner join type_point tp on pt.PointType_ID=tp.id where pt.PointType_ID !='0'");
                foreach (DataRow dr in dtPoint.Rows)
                {
                    trlFactoriesPrsnt11.AppendNode(new object[] { Convert.ToString(dr["point_id"]), Convert.ToString(dr["PointName"]), Convert.ToString(dr["PointDesc"]) }, null);
                }

            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }
       public void FillTreeNode(string Level_Name)
        {
          try
          {
              trlFactoriesPrsnt11.Nodes.Clear();
              TxtRouteName.Text = String.Empty;
              TxtRouteID.Text = string.Empty;
                  switch (Level_Name)
                  {
                      case "--Select--":
                          {
                              trlFactoriesPrsnt11.Nodes.Clear();
                              trlRoute11.Nodes.Clear();                            
                              break;
                          }
                      case "Plant":
                          {
                              trlFactoriesPrsnt11.Nodes.Clear();
                              trlRoute11.Nodes.Clear();
                              FillPlantwise();
                              Fill_TrlRoute_PlantWise();
                              
                              _objMain.lblStatus.Caption = "Status: Selecting Plant";
                              break;
                          }
                      case "Area":
                          {
                              trlFactoriesPrsnt11.Nodes.Clear();
                              trlRoute11.Nodes.Clear();
                              FillAreawise();
                              Fill_TrlRoute_AreaWise();
                              _objMain.lblStatus.Caption = "Status: Selecting Area";
                              break;
                          }
                      case "Train":
                          {
                              trlFactoriesPrsnt11.Nodes.Clear();
                              trlRoute11.Nodes.Clear();
                              FillTrainwise();
                              Fill_TrlRoute_TrainWise();
                              _objMain.lblStatus.Caption = "Status: Selecting Train";
                              break;
                          }
                      case "Machine":
                          {
                              trlFactoriesPrsnt11.Nodes.Clear();
                              trlRoute11.Nodes.Clear();
                              FillMachinewise();
                              Fill_TrlRoute_MachineWise();
                              _objMain.lblStatus.Caption = "Status: Selecting Machine";
                              break;
                          }
                      case "Point":
                          {
                              trlFactoriesPrsnt11.Nodes.Clear();
                              trlRoute11.Nodes.Clear();
                              FillPointwise();
                              Fill_TrlRoute_PointWise();
                              _objMain.lblStatus.Caption = "Status: Selecting Point";
                              break;
                          }

                  }
              }
              catch (Exception ex)
              {
                  Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
              }
      
           //route_data

        }
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillTreeNode(Convert .ToString (CmbLevel.Text).Trim ());
                PublicClass.LevelName = Convert.ToString(CmbLevel.Text).Trim();

            }
              catch (Exception ex)
              {
                  Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
              }      
        }

        public void Retrive_Plant_for_trlRoute11()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select distinct a.Id,a.Route_Name,a.Route_Level,b.Type_ID  from route_data a left join route_data1 b on a.id=b.ID ");

            }
            catch { }

        }
        public void Insert_Plant(string Z)
        {
            _objMain.lblStatus.Caption = "Status: Inserting Plant";
            try
            {

                 //Node_Parent = trlRoute11.FocusedNode.ParentNode ; 
                string V_Name = (string)trlRoute11.FocusedNode.GetDisplayText(2);
                DataTable Factorydt = new DataTable();
                DataTable AreaDT = new DataTable();
                DataTable TrainDt = new DataTable();
                DataTable MachineDt = new DataTable();
                DataTable PointDt = new DataTable();
             
                Factorydt = DbClass.getdata(CommandType.Text, "select  FACTORY_ID ,NAME,Description  from factory_info  ");
                AreaDT = DbClass.getdata(CommandType.Text, "select Area_ID,NAME,DESCRIPTION,FactoryID  from area_info ");
                TrainDt = DbClass.getdata(CommandType.Text, "select Train_ID,NAME,Description ,Area_ID from train_info ");
                MachineDt = DbClass.getdata(CommandType.Text, "select  Machine_ID ,NAME ,Description,TrainID  from machine_info  ");
                PointDt = DbClass.getdata(CommandType.Text, "SELECT  Point_ID ,POINTNAME ,PointDesc,Machine_ID  FROM POINT  ");
                Node_Parent = trlRoute11.FocusedNode; 
                Node_Plant = null;
                Node_Area = null;
                Node_Train = null;
                Node_Machine = null;
                Node_Point = null;
                foreach (DataRow FactoryRow in Factorydt.Select("Factory_ID = '" + Z.Trim() + "' "))
                {
                   

                    Node_Plant = trlRoute11.AppendNode(new object[] { Convert.ToString(FactoryRow["Factory_ID"]), Convert.ToString(FactoryRow["Name"]), "Plant" }, Node_Parent);
                    //*******************************Area***********************************
                    foreach (DataRow AreaRow in AreaDT.Select("FactoryID = '" + Convert.ToString(FactoryRow["Factory_ID"]) + "'"))
                    {
                        Node_Area = trlRoute11.AppendNode(new object[] { Convert.ToString(AreaRow["Area_ID"]), Convert.ToString(AreaRow["Name"]), "Area" }, Node_Plant);
                        //************************Train********************************************
                        foreach (DataRow TrainRow in TrainDt.Select("Area_ID = '" + Convert.ToString(AreaRow["Area_ID"]) + "' "))
                        {
                            Node_Train = trlRoute11.AppendNode(new object[] { Convert.ToString(TrainRow["Train_ID"]), Convert.ToString(TrainRow["name"]), "Train" }, Node_Area);

                            // **********************Machine ***********************
                            foreach (DataRow MachineRow in MachineDt.Select("TrainID = '" + Convert.ToString(TrainRow["Train_ID"]) + "'  "))
                            {

                                Node_Machine = trlRoute11.AppendNode(new object[] { Convert.ToString(MachineRow["Machine_ID"]), Convert.ToString(MachineRow["name"]), "Point" }, Node_Train);


                                // ************************ 
                                foreach (DataRow PointRow in PointDt.Select(" Machine_ID = '" + Convert.ToString(MachineRow["Machine_ID"]) + "' "))
                                {

                                    Node_Point = trlRoute11.AppendNode(new object[] { Convert.ToString(PointRow["Point_ID"]), Convert.ToString(PointRow["POINTNAME"]), "Machine" }, Node_Machine);

                                }//****************end of point

                            }//********************end of Machine

                        }//****************************end of Train

                    }//****************************end of Area

                }//**********************************end of Factory
              

            }
            catch { }

        }
        public void Insert_Area(string Z)
        {
            _objMain.lblStatus.Caption = "Status: Inserting Area";
            try
            {

                //Node_Parent = trlRoute11.FocusedNode.ParentNode ; 
                string V_Name = (string)trlRoute11.FocusedNode.GetDisplayText(2);
                DataTable Factorydt = new DataTable();
                DataTable AreaDT = new DataTable();
                DataTable TrainDt = new DataTable();
                DataTable MachineDt = new DataTable();
                DataTable PointDt = new DataTable();

              //  Factorydt = DbClass.getdata(CommandType.Text, "select  FACTORY_ID ,NAME,Description  from factory_info  ");
                AreaDT = DbClass.getdata(CommandType.Text, "select Area_ID,NAME,DESCRIPTION,FactoryID  from area_info ");
                TrainDt = DbClass.getdata(CommandType.Text, "select Train_ID,NAME,Description ,Area_ID from train_info ");
                MachineDt = DbClass.getdata(CommandType.Text, "select  Machine_ID ,NAME ,Description,TrainID  from machine_info  ");
                PointDt = DbClass.getdata(CommandType.Text, "SELECT  Point_ID ,POINTNAME ,PointDesc,Machine_ID  FROM POINT  ");
              //  Node_Parent = trlRoute11.FocusedNode;
                Node_Plant = trlRoute11.FocusedNode; ;
                Node_Area = null;
                Node_Train = null;
                Node_Machine = null;
                Node_Point = null;
                //foreach (DataRow FactoryRow in Factorydt.Select("Factory_ID = '" + Z.Trim() + "' "))
                //{
                //    Node_Plant = trlRoute11.AppendNode(new object[] { Convert.ToString(FactoryRow["Factory_ID"]), Convert.ToString(FactoryRow["Name"]), "Plant" }, Node_Parent);
                    //*******************************Area***********************************
                foreach (DataRow AreaRow in AreaDT.Select("Area_ID = '" + Z.Trim()+ "'"))
                    {
                        Node_Area = trlRoute11.AppendNode(new object[] { Convert.ToString(AreaRow["Area_ID"]), Convert.ToString(AreaRow["Name"]), "Area" }, Node_Plant);
                        //************************Train********************************************
                        foreach (DataRow TrainRow in TrainDt.Select("Area_ID = '" + Convert.ToString(AreaRow["Area_ID"]) + "' "))
                        {
                            Node_Train = trlRoute11.AppendNode(new object[] { Convert.ToString(TrainRow["Train_ID"]), Convert.ToString(TrainRow["name"]), "Train" }, Node_Area);

                            // **********************Machine ***********************
                            foreach (DataRow MachineRow in MachineDt.Select("TrainID = '" + Convert.ToString(TrainRow["Train_ID"]) + "'  "))
                            {

                                Node_Machine = trlRoute11.AppendNode(new object[] { Convert.ToString(MachineRow["Machine_ID"]), Convert.ToString(MachineRow["name"]), "Point" }, Node_Train);


                                // ************************ 
                                foreach (DataRow PointRow in PointDt.Select(" Machine_ID = '" + Convert.ToString(MachineRow["Machine_ID"]) + "' "))
                                {

                                    Node_Point = trlRoute11.AppendNode(new object[] { Convert.ToString(PointRow["Point_ID"]), Convert.ToString(PointRow["POINTNAME"]), "Machine" }, Node_Machine);

                                }//****************end of point

                            }//********************end of Machine

                        }//****************************end of Train

                    }//****************************end of Area

                //}//**********************************end of Factory


            }
            catch { }
        }
        public void Insert_Train(string Z)
        {

            try
            {
                _objMain.lblStatus.Caption = "Status: Inserting Train";
                //Node_Parent = trlRoute11.FocusedNode.ParentNode ; 
                string V_Name = (string)trlRoute11.FocusedNode.GetDisplayText(2);
                DataTable Factorydt = new DataTable();
                DataTable AreaDT = new DataTable();
                DataTable TrainDt = new DataTable();
                DataTable MachineDt = new DataTable();
                DataTable PointDt = new DataTable();

                Factorydt = DbClass.getdata(CommandType.Text, "select  FACTORY_ID ,NAME,Description  from factory_info  ");
                AreaDT = DbClass.getdata(CommandType.Text, "select Area_ID,NAME,DESCRIPTION,FactoryID  from area_info ");
                TrainDt = DbClass.getdata(CommandType.Text, "select Train_ID,NAME,Description ,Area_ID from train_info ");
                MachineDt = DbClass.getdata(CommandType.Text, "select  Machine_ID ,NAME ,Description,TrainID  from machine_info  ");
                PointDt = DbClass.getdata(CommandType.Text, "SELECT  Point_ID ,POINTNAME ,PointDesc,Machine_ID  FROM POINT  ");
                //Node_Parent = trlRoute11.FocusedNode;
                //Node_Plant = null;
                Node_Area = trlRoute11.FocusedNode; ;
                Node_Train = null;
                Node_Machine = null;
                Node_Point = null;
                //foreach (DataRow FactoryRow in Factorydt.Select("Factory_ID = '" + Z.Trim() + "' "))
                //{
                //    Node_Plant = trlRoute11.AppendNode(new object[] { Convert.ToString(FactoryRow["Factory_ID"]), Convert.ToString(FactoryRow["Name"]), "Plant" }, Node_Parent);
                //*******************************Area***********************************
                //foreach (DataRow AreaRow in AreaDT.Select("Area_ID = '" + Z.Trim() + "'"))
                //{
                //    Node_Area = trlRoute11.AppendNode(new object[] { Convert.ToString(AreaRow["Area_ID"]), Convert.ToString(AreaRow["Name"]), "Area" }, Node_Plant);
                //    //************************Train********************************************
                foreach (DataRow TrainRow in TrainDt.Select("Train_ID = '" +Z.Trim()+ "' "))
                    {
                        Node_Train = trlRoute11.AppendNode(new object[] { Convert.ToString(TrainRow["Train_ID"]), Convert.ToString(TrainRow["name"]), "Train" }, Node_Area);

                        // **********************Machine ***********************
                        foreach (DataRow MachineRow in MachineDt.Select("TrainID = '" + Convert.ToString(TrainRow["Train_ID"]) + "'  "))
                        {

                            Node_Machine = trlRoute11.AppendNode(new object[] { Convert.ToString(MachineRow["Machine_ID"]), Convert.ToString(MachineRow["name"]), "Point" }, Node_Train);


                            // ************************ 
                            foreach (DataRow PointRow in PointDt.Select(" Machine_ID = '" + Convert.ToString(MachineRow["Machine_ID"]) + "' "))
                            {

                                Node_Point = trlRoute11.AppendNode(new object[] { Convert.ToString(PointRow["Point_ID"]), Convert.ToString(PointRow["POINTNAME"]), "Machine" }, Node_Machine);

                            }//****************end of point

                        }//********************end of Machine

                    }//****************************end of Train

               // }//****************************end of Area

                //}//**********************************end of Factory


            }
            catch { }
        }

        public void Insert_Machine(string Z)
        {

            try
            {
                _objMain.lblStatus.Caption = "Status: Inserting Machine";
                //Node_Parent = trlRoute11.FocusedNode.ParentNode ; 
                string V_Name = (string)trlRoute11.FocusedNode.GetDisplayText(2);
                DataTable Factorydt = new DataTable();
                DataTable AreaDT = new DataTable();
                DataTable TrainDt = new DataTable();
                DataTable MachineDt = new DataTable();
                DataTable PointDt = new DataTable();

                Factorydt = DbClass.getdata(CommandType.Text, "select  FACTORY_ID ,NAME,Description  from factory_info  ");
                AreaDT = DbClass.getdata(CommandType.Text, "select Area_ID,NAME,DESCRIPTION,FactoryID  from area_info ");
                TrainDt = DbClass.getdata(CommandType.Text, "select Train_ID,NAME,Description ,Area_ID from train_info ");
                MachineDt = DbClass.getdata(CommandType.Text, "select  Machine_ID ,NAME ,Description,TrainID  from machine_info  ");
                PointDt = DbClass.getdata(CommandType.Text, "SELECT  Point_ID ,POINTNAME ,PointDesc,Machine_ID  FROM POINT  ");
                //Node_Parent = trlRoute11.FocusedNode;
                //Node_Plant = null;
                //Node_Area = null;
                Node_Train = trlRoute11.FocusedNode; ;
                Node_Machine = null;
                Node_Point = null;
                //foreach (DataRow FactoryRow in Factorydt.Select("Factory_ID = '" + Z.Trim() + "' "))
                //{
                //    Node_Plant = trlRoute11.AppendNode(new object[] { Convert.ToString(FactoryRow["Factory_ID"]), Convert.ToString(FactoryRow["Name"]), "Plant" }, Node_Parent);
                //*******************************Area***********************************
                //foreach (DataRow AreaRow in AreaDT.Select("Area_ID = '" + Z.Trim() + "'"))
                //{
                //    Node_Area = trlRoute11.AppendNode(new object[] { Convert.ToString(AreaRow["Area_ID"]), Convert.ToString(AreaRow["Name"]), "Area" }, Node_Plant);
                //    //************************Train********************************************
                //foreach (DataRow TrainRow in TrainDt.Select("Train_ID = '" + Z.Trim() + "' "))
                //{
                //    Node_Train = trlRoute11.AppendNode(new object[] { Convert.ToString(TrainRow["Train_ID"]), Convert.ToString(TrainRow["name"]), "Train" }, Node_Area);

                    // **********************Machine ***********************
                foreach (DataRow MachineRow in MachineDt.Select("Machine_ID = '" + Z.Trim() + "'  "))
                    {

                        Node_Machine = trlRoute11.AppendNode(new object[] { Convert.ToString(MachineRow["Machine_ID"]), Convert.ToString(MachineRow["name"]), "Point" }, Node_Train);


                        // ************************ 
                        foreach (DataRow PointRow in PointDt.Select(" Machine_ID = '" + Convert.ToString(MachineRow["Machine_ID"]) + "' "))
                        {

                            Node_Point = trlRoute11.AppendNode(new object[] { Convert.ToString(PointRow["Point_ID"]), Convert.ToString(PointRow["POINTNAME"]), "Machine" }, Node_Machine);

                        }//****************end of point

                    }//********************end of Machine

               // }//****************************end of Train

                // }//****************************end of Area

                //}//**********************************end of Factory


            }
            catch { }
        }
        public void Insert_Point(string Z)
        {

            try
            {
                _objMain.lblStatus.Caption = "Status: Inserting Point";
                //Node_Parent = trlRoute11.FocusedNode.ParentNode ; 
                string V_Name = (string)trlRoute11.FocusedNode.GetDisplayText(2);
                DataTable Factorydt = new DataTable();
                DataTable AreaDT = new DataTable();
                DataTable TrainDt = new DataTable();
                DataTable MachineDt = new DataTable();
                DataTable PointDt = new DataTable();

                Factorydt = DbClass.getdata(CommandType.Text, "select  FACTORY_ID ,NAME,Description  from factory_info  ");
                AreaDT = DbClass.getdata(CommandType.Text, "select Area_ID,NAME,DESCRIPTION,FactoryID  from area_info ");
                TrainDt = DbClass.getdata(CommandType.Text, "select Train_ID,NAME,Description ,Area_ID from train_info ");
                MachineDt = DbClass.getdata(CommandType.Text, "select  Machine_ID ,NAME ,Description,TrainID  from machine_info  ");
                PointDt = DbClass.getdata(CommandType.Text, "SELECT Point_ID ,POINTNAME ,PointDesc,Machine_ID  FROM POINT  ");
                //Node_Parent = trlRoute11.FocusedNode;
                //Node_Plant = null;
                //Node_Area = null;
                //Node_Train = null;
                Node_Machine = trlRoute11.FocusedNode;
                Node_Point = null;
                //foreach (DataRow FactoryRow in Factorydt.Select("Factory_ID = '" + Z.Trim() + "' "))
                //{
                //    Node_Plant = trlRoute11.AppendNode(new object[] { Convert.ToString(FactoryRow["Factory_ID"]), Convert.ToString(FactoryRow["Name"]), "Plant" }, Node_Parent);
                //*******************************Area***********************************
                //foreach (DataRow AreaRow in AreaDT.Select("Area_ID = '" + Z.Trim() + "'"))
                //{
                //    Node_Area = trlRoute11.AppendNode(new object[] { Convert.ToString(AreaRow["Area_ID"]), Convert.ToString(AreaRow["Name"]), "Area" }, Node_Plant);
                //    //************************Train********************************************
                //foreach (DataRow TrainRow in TrainDt.Select("Train_ID = '" + Z.Trim() + "' "))
                //{
                //    Node_Train = trlRoute11.AppendNode(new object[] { Convert.ToString(TrainRow["Train_ID"]), Convert.ToString(TrainRow["name"]), "Train" }, Node_Area);

                // **********************Machine ***********************
                //foreach (DataRow MachineRow in MachineDt.Select("Machine_ID = '" + Z.Trim() + "'  "))
                //{

                //    Node_Machine = trlRoute11.AppendNode(new object[] { Convert.ToString(MachineRow["Machine_ID"]), Convert.ToString(MachineRow["name"]), "Point" }, Node_Train);


                    // ************************ 
                foreach (DataRow PointRow in PointDt.Select(" Point_ID = '" + Z.Trim() + "' "))
                    {

                        Node_Point = trlRoute11.AppendNode(new object[] { Convert.ToString(PointRow["Point_ID"]), Convert.ToString(PointRow["POINTNAME"]), "Machine" }, Node_Machine);

                    }//****************end of point

                //}//********************end of Machine

                // }//****************************end of Train

                // }//****************************end of Area

                //}//**********************************end of Factory


            }
            catch { }
        }



        public void FillTreeNodeValue(string Level_Name)
        {
            try
            {
               
                switch (Level_Name)
                {
                    case " --Select--":
                        {
                            break;
                        }
                    case "Plant":
                        {
                            Insert_Plant(IDVAlue );                           
                            break;
                        }
                    case "Area":
                        {
                            Insert_Area(IDVAlue);
                            break;
                        }
                    case "Train":
                        {
                            Insert_Train(IDVAlue);
                            break;
                        }
                    case "Machine":
                        {
                            Insert_Machine(IDVAlue);
                            break;
                        }
                    case "Point":
                        {
                            Insert_Point(IDVAlue);
                            break;
                        }

                }
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }          

        }
        
        public void Fill_TrlRoute_PlantWise()
        {
            try
            {
                DataTable dt = new DataTable();
                DataTable dtt = new DataTable();
               
                dtt = RouteConn.getdata(CommandType.Text, "select distinct a.Id ,a.Route_Name from route_data a left join route_data1 b on a.id=b.ID where Route_Level='" + CmbLevel.Text.Trim().ToString() + "' and databasename='"+PublicClass.User_DataBase+"' ");
                dt = RouteConn.getdata(CommandType.Text, "select distinct a.Id,a.Route_Name,a.Route_Level,b.Type_ID  from route_data a left join route_data1 b on a.id=b.ID where Route_Level='" + CmbLevel.Text.Trim().ToString() + "' and databasename='" + PublicClass.User_DataBase + "' ");


                foreach (DataRow drr in dtt.Rows)
                {
                    TreeListNode node = null;
                    node = trlRoute11.AppendNode(new object[] { Convert.ToString(drr["Id"]), Convert.ToString(drr["Route_Name"]), "Route" }, node);
                    trlRoute11.SetFocusedNode(node);
                    foreach (DataRow dr in dt.Select("Id ='" + Convert.ToString(drr["Id"]).Trim() + "' "))
                    {
                        Insert_Plant(PublicClass.DefVal(Convert.ToString(dr["Type_ID"]), "0"));
                    }

                }

            }
            catch { }


        }


        public void Fill_TrlRoute_AreaWise()
        {
            try
            {
                DataTable dt = new DataTable();
                DataTable dtt = new DataTable();

                dtt = RouteConn.getdata(CommandType.Text, "select distinct a.Id ,a.Route_Name from route_data a left join route_data1 b on a.id=b.ID where Route_Level='" + CmbLevel.Text.Trim().ToString() + "' and databasename='" + PublicClass.User_DataBase + "' ");
                dt = RouteConn.getdata(CommandType.Text, "select distinct a.Id,a.Route_Name,a.Route_Level,b.Type_ID  from route_data a left join route_data1 b on a.id=b.ID where Route_Level='" + CmbLevel.Text.Trim().ToString() + "' and databasename='" + PublicClass.User_DataBase + "' ");
                foreach (DataRow drr in dtt.Rows)
                {
                    TreeListNode node = null;
                    node = trlRoute11.AppendNode(new object[] { Convert.ToString(drr["Id"]), Convert.ToString(drr["Route_Name"]), "Route" }, node);
                    trlRoute11.SetFocusedNode(node);

                    foreach (DataRow dr in dt.Select("Id ='" + Convert.ToString(drr["Id"]).Trim() + "' "))
                    {
                        Insert_Area(PublicClass.DefVal(Convert.ToString(dr["Type_ID"]), "0"));
                    }
                }
            }
            catch { }
        }
        public void Fill_TrlRoute_TrainWise()
        {
            try
            {
                DataTable dt = new DataTable();
                DataTable dtt = new DataTable();

                dtt = RouteConn.getdata(CommandType.Text, "select distinct a.Id ,a.Route_Name from route_data a left join route_data1 b on a.id=b.ID where Route_Level='" + CmbLevel.Text.Trim().ToString() + "' and databasename='" + PublicClass.User_DataBase + "' ");
                dt = RouteConn.getdata(CommandType.Text, "select distinct a.Id,a.Route_Name,a.Route_Level,b.Type_ID  from route_data a left join route_data1 b on a.id=b.ID where Route_Level='" + CmbLevel.Text.Trim().ToString() + "' and databasename='" + PublicClass.User_DataBase + "' ");

                foreach (DataRow drr in dtt.Rows)
                {
                    TreeListNode node = null;
                    node = trlRoute11.AppendNode(new object[] { Convert.ToString(drr["Id"]), Convert.ToString(drr["Route_Name"]), "Route" }, node);
                    trlRoute11.SetFocusedNode(node);
                    foreach (DataRow dr in dt.Select("Id ='" + Convert.ToString(drr["Id"]).Trim() + "' "))
                    {

                        Insert_Train(PublicClass.DefVal(Convert.ToString(dr["Type_ID"]), "0"));
                    }

                }

            }
            catch { }


        }
        public void Fill_TrlRoute_MachineWise()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = RouteConn.getdata(CommandType.Text, "select distinct a.Id,a.Route_Name,a.Route_Level,b.Type_ID  from route_data a left join route_data1 b on a.id=b.ID where Route_Level='" + CmbLevel.Text.Trim().ToString() + "' and databasename='" + PublicClass.User_DataBase + "' ");
                DataTable dtt = new DataTable();
                dtt = RouteConn.getdata(CommandType.Text, "select distinct a.Id ,a.Route_Name from route_data a left join route_data1 b on a.id=b.ID where Route_Level='" + CmbLevel.Text.Trim().ToString() + "' and databasename='" + PublicClass.User_DataBase + "' ");
                foreach (DataRow drr in dtt.Rows)
                {
                    TreeListNode node = null;
                    node = trlRoute11.AppendNode(new object[] { Convert.ToString(drr["Id"]), Convert.ToString(drr["Route_Name"]), "Route" }, node);
                    trlRoute11.SetFocusedNode(node);

                    foreach (DataRow dr in dt.Select("Id ='" + Convert.ToString(drr["Id"]).Trim() + "' "))
                    {
                        Insert_Machine(PublicClass.DefVal(Convert.ToString(dr["Type_ID"]), "0"));


                    }
                }

            }
            catch { }


        }
        public void Fill_TrlRoute_PointWise()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = RouteConn.getdata(CommandType.Text, "select distinct a.Id,a.Route_Name,a.Route_Level,b.Type_ID  from route_data a left join route_data1 b on a.id=b.ID where Route_Level='" + CmbLevel.Text.Trim().ToString() + "' and databasename='" + PublicClass.User_DataBase + "' ");
                DataTable dtt = new DataTable();
                dtt = RouteConn.getdata(CommandType.Text, "select distinct a.Id ,a.Route_Name from route_data a left join route_data1 b on a.id=b.ID where Route_Level='" + CmbLevel.Text.Trim().ToString() + "' and databasename='" + PublicClass.User_DataBase + "' ");
                foreach (DataRow drr in dtt.Rows)
                {
                    TreeListNode node = null;
                    node = trlRoute11.AppendNode(new object[] { Convert.ToString(drr["Id"]), Convert.ToString(drr["Route_Name"]), "Route" }, node);
                    trlRoute11.SetFocusedNode(node);


                    foreach (DataRow dr in dt.Select("Id ='" + Convert.ToString(drr["Id"]).Trim() + "' "))
                    {                        
                        Insert_Point(PublicClass.DefVal(Convert.ToString(dr["Type_ID"]), "0"));
                    }
                }
            }
            catch { }


        }
        private void trlFactoriesPrsnt11_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                try
                {
                    string rr = (string)trlFactoriesPrsnt11.FocusedNode.GetDisplayText(0);                  
                }
                catch { }
            }           
        }
        private TreeListNode objNodeClked = null;
        public TreeListNode ObjCurrentNodeClked
        {
            get
            {
                if (objNodeClked == null)
                {
                    if (trlRoute11.FocusedNode != null)
                    {
                        objNodeClked = trlRoute11.FocusedNode;
                    }
                }
                return objNodeClked;
            }
            set
            {
                objNodeClked = value;
            }
        }

        Control count;
        private void trlRoute11_MouseDown(object sender, MouseEventArgs e)
        {
            count = trlRoute11;
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        contextMenuStrip1.Show(count, new Point(e.X, e.Y));

                        if(addition)
                        {
                            insertRouteToolStripMenuItem.Enabled = true;
                            if(modification == false)
                            {
                                TxtRouteName.Enabled = true;
                            }
                        }
                        else
                        {
                            insertRouteToolStripMenuItem.Enabled = false;
                        }
                        if (deletion)
                        {
                            deleteToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            deleteToolStripMenuItem.Enabled = false;
                        }

                    }
                    break;
                case MouseButtons.Left:
                    {
                        objRouteInfo = trlRoute11.CalcHitInfo(e.Location);
                        ObjCurrentNodeClked=objRouteInfo.Node;
                    }
                    break;
            }

        }
        public void InsertRouteName()
        {
               try
                {                   
                   if (CmbLevel.SelectedIndex==0)
                   {
                       MessageBox.Show(this, "Please select the Level", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       return;
                   }
                    
                    RouteConn.executequery(CommandType.Text, "insert route_data (Route_Name ,Route_Level,Date,DatabaseName) values ( '" + Convert.ToString(TxtRouteName.Text) + "','" + Convert.ToString(CmbLevel.Text) + "' ,'" + PublicClass.GetDatetime() + "' ,'" + PublicClass.User_DataBase + "' ) ");

                    DataTable dt = new DataTable();
                    dt = RouteConn.getdata(CommandType.Text, "select  max(Id)  from route_data");
                    string SId = PublicClass.DefVal(Convert.ToString(dt.Rows[0][0]), "0");
                    Node_Parent = null;
                    TxtRouteID.Text = Convert.ToString(Convert.ToInt32(SId));
                    TxtRouteName.Text = "Route" + TxtRouteID.Text;
                    TxtRouteName.Properties.ReadOnly = false;
                    Node_Parent = trlRoute11.AppendNode(new object[] { Convert.ToString(TxtRouteID.Text).Trim(), Convert.ToString(TxtRouteName.Text).Trim(), "Route" }, Node_Parent);

                   trlRoute11.SetFocusedNode(Node_Parent);
                   TxtRouteName.Focus();
                   _objMain.lblStatus.Caption = "Status: Creating Route";
                }
               catch { }
           
        }
  

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text.Trim () == "Insert Route")
            {
                InsertRouteName();
            }
            else if (e.ClickedItem.Text.Trim() == "Delete")
            {
                if (TxtRouteName.Text == "")
                {
                    MessageBox.Show("Please select Route first");
                }
                else
                {
                    try
                    {
                        RouteConn.executequery(CommandType.Text, "call deleteroute ('" + (string)trlRoute11.FocusedNode.GetDisplayText(0) + "')");
                        MessageBox.Show("Route Deleted Successfully");
                        FillTreeNode(Convert.ToString(CmbLevel.Text).Trim());
                        TxtRouteName.Text = "";
                        TxtRouteID.Text = "";
                        _objMain.lblStatus.Caption = "Status: Route Deleted Successfully";
                    }
                    catch { }
                }
            }
        }

        private void TxtRouteName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (TxtRouteName.Text == "" || TxtRouteName.Text == null)
                {
                    MessageBox.Show(this,"Route Name Can not blank", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {                   
                    DataTable dt = DbClass.getdata(CommandType.Text, "select * from route.route_data where route_name='" + TxtRouteName.Text.Trim() + "'");
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "Route Name Already Exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        trlRoute11.FocusedNode.SetValue(1, TxtRouteName.Text);
                        RouteConn.executequery(CommandType.Text, "update route_data set  Route_Name = '" + Convert.ToString(TxtRouteName.Text).Trim() + "' where id='" + Convert.ToString(TxtRouteID.Text).Trim() + "' ");
                    }
                }
                if(modification == false)
                {
                    TxtRouteName.Enabled = false;
                }
                else
                {
                    TxtRouteName.Enabled = true;
                }
            }
            catch { }
        }

        private void trlRoute11_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((string)trlRoute11.FocusedNode.GetDisplayText(2).Trim() == "Route")
                {
                    TxtRouteID.Text = (string)trlRoute11.FocusedNode.GetDisplayText(0);
                    TxtRouteName.Text = (string)trlRoute11.FocusedNode.GetDisplayText(1);
                }
                try
                {
                    Node_Parent = trlRoute11.FocusedNode;
                }
                catch { }
            }
            catch { }
        }
               
        private void trlRoute11_DragLeave(object sender, EventArgs e)
        {
            try
            {
                trlRoute11.SetFocusedNode(Node_Parent);
                Node_Parent=  trlRoute11.FocusedNode;
                
                string st = (string)trlRoute11.FocusedNode.GetDisplayText(0);
                IDVAlue = (string)trlFactoriesPrsnt11.FocusedNode.GetDisplayText(0);
                DataTable dt = new DataTable();                
                dt = RouteConn.getdata(CommandType.Text, "select distinct distinct type_id  from route_data1  where id= '" + Convert.ToString(TxtRouteID.Text).Trim() + "' and type_id = '" + Convert.ToString(IDVAlue).Trim() + "'");
                if (dt.Rows.Count - 1 >= 0)
                {
                    MessageBox.Show(this, "On this Route Data is already Exist ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                    {
                        FillTreeNodeValue(Convert.ToString(CmbLevel.Text).Trim());
                        RouteConn.executequery(CommandType.Text, "Insert into route_data1 (id,type_id ) values ( '" + Convert.ToString(TxtRouteID.Text).Trim() + "' , '" + IDVAlue + "'  )");
                    }
                    else
                    {
                        DataTable dt1 = RouteConn.getdata(CommandType.Text, "select * from route_data1 where ID='" + Convert.ToString(TxtRouteID.Text).Trim() + "'");
                        if (dt1.Rows.Count <= 0)
                        {
                            FillTreeNodeValue(Convert.ToString(CmbLevel.Text).Trim());
                            RouteConn.executequery(CommandType.Text, "Insert into route_data1 (id,type_id ) values ( '" + Convert.ToString(TxtRouteID.Text).Trim() + "' , '" + IDVAlue + "'  )");
                        }
                        else
                        {
                            MessageBox.Show(this, "Load Only One level", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            catch { }
        }

        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtRouteName.Text == "")
                {
                    MessageBox.Show(this, "Select Any Route First", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DataTable dt = DbClass.getdata(CommandType.Text, "select * from route.route_data1 where ID='"+TxtRouteID.Text+"'");
                    if (dt.Rows.Count > 0)
                    {
                        TreeListNode ss = trlRoute11.FocusedNode;
                        PublicClass.routename = TxtRouteName.Text;
                        PublicClass.RouteId = TxtRouteID.Text.Trim();
                        updown = new frmupdownload();
                        if(updown.check==null)
                        {
                            MessageBox.Show(this, "Connect Instrument First", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (updown.check=="true")
                        {
                            updown.MainForm = _objMain;
                            updown.tsSerial.Text = "Instrument S.No= " + PublicClass.InstrumentSerial;
                            updown.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show(this, "Connected Wrong Instrument", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }                       
                    }
                    else
                    {
                        MessageBox.Show(this, "Load Any Level in Route First", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch { }
        }


       

      

   
    }
}