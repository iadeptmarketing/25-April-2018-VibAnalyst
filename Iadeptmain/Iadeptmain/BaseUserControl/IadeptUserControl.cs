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
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Iadeptmain.Mainforms;
using Iadeptmain;
using DevComponents.DotNetBar;

using Iadeptmain.GlobalClasess;
using System.Data.Odbc;
using System.Xml;
using Iadeptmain.Classes;
using System.Collections;
using System.Data.SqlClient;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraEditors.Repository;

using com.iAM.chart2dnet;
using System.IO;
using Iadeptmain.Images;
using DevExpress.XtraGauges.Win;
using DevExpress.XtraGauges.Win.Gauges.Circular;
using DevExpress.XtraGauges.Core.Model;
using DevExpress.XtraGauges.Win.Base;
using DevExpress.XtraGauges.Core.Drawing;
using DevExpress.XtraCharts;
using System.Text.RegularExpressions;


namespace Iadeptmain.BaseUserControl
{
    public partial class IadeptUserControl : DevExpress.XtraEditors.XtraForm    
    {     
        public string sNodeType = "";
        frmIAdeptMain _objMain;
        bool search = false;
        TreeListNode trlnFocusedNode = null;
        TreeListNode pp = null;
        TreeListNode parentForRootForFactory = null;
        TreeListNode parentForRootForResorce = null;
        TreeListNode parentForRootForElement = null;
        TreeListNode parentForSubelement = null;
        TreeListNode parentForRootPoint = null;
        private string m_sItemType = null;
        private string m_sTextToSearch = null;        
        MCW m_objmcw = null;
        string dataschedule = null;
        string data = null; 
        string cDBName = null;
        ImageList m_imgPictures = null;
        frmCompleteImage m_objCompleteImage = null;
        PointGeneral1 graph = null;
        frmGControls _objcontrol = null;
        string selection = null;
        private frmgraphcontrol m_objGraphControl = null;
        uc3DGraphControl m_obj3DGraphControl = null;
        GraphView m_graph = null;
        bool m_bSetFlag = false;
        string fMaxID = null;
        string aMaxID = null;
        string tMaxID = null;
        string mMaxID = null;
        string pMaxID = null;
        string aFactoryID = null;
        string FactCurtMaxID = null;
        string ArCID = null;
        string TrCID = null;
        string MaCID = null;
        string PtCID = null;
        
        public IadeptUserControl()
        {
            InitializeComponent();
            activateobjects();
            Create_TreeListColumn();
            Create_tree_Node();
           filltreelist();
           settabpages();
                  
        }

        public void activateobjects()
        {
            graph = new PointGeneral1();
            m_objmcw = new MCW();
            m_objGraphControl = new frmgraphcontrol();
            m_graph = new GraphView(m_objGraphControl);

            m_obj3DGraphControl = new uc3DGraphControl();
            m_obj3DGraphControl.uc3dGraph = this;

            graph.usercontrol = this;
            m_objmcw.usercontrol1 = this;
            m_objGraphControl.usercontrol = this;
            m_graph.usercontrol = this;
           
            graph.MainForm1 = MainForm;
        }

        public ChartView testingGraph1
        {
            get
            {
                return m_objGraphControl.testGraph1;
            }
            set
            {
                m_objGraphControl.testGraph1 = value;
            }
        }

        public PointGeneral1 pg
        {
            get { return graph; }
            set { graph = value; }

        }

        public frmGControls graphcontrol1
        {
            get { return _objcontrol; }
            set { _objcontrol = value; }

        }

        public SplitGroupPanel buttonheight
        {
            get
            {
                return splitContainerControl1.Panel1;
            }
        }
        
        public bool searchClicked
        {
            get
            {
                return search;
            }
            set
            {
                search = value;
            }

        }

        public void SearchNodes(string sTextToSearch, string sItemText)
        {
            try
            {
                string ss = "";

                foreach (TreeListNode fac in trlPlantManger.Nodes)
                {
                    foreach (TreeListNode are in fac.Nodes)
                    {

                        foreach (TreeListNode mac in are.Nodes)
                        {

                            foreach (TreeListNode tra in mac.Nodes)
                            {
                                foreach (TreeListNode po in tra.Nodes)
                                {

                                    ss = po.GetValue(2).ToString();
                                    //  string ss = (string)trlPlantManger.FocusedNode.GetDisplayText(2);
                                    if ((ss.ToLower()).Trim() == sTextToSearch.ToLower().Trim())
                                    {

                                        MessageBox.Show("data is found.");

                                        trlPlantManger.SetFocusedNode(po);
                                        return;
                                    }

                                }
                                ss = tra.GetValue(2).ToString();
                                //  string ss = (string)trlPlantManger.FocusedNode.GetDisplayText(2);
                                if ((ss.ToLower()).Trim() == sTextToSearch.ToLower().Trim())
                                {                                  
                                    trlPlantManger.SetFocusedNode(tra);
                                    //return;
                                }
                            }
                            ss = mac.GetValue(2).ToString();
                            //  string ss = (string)trlPlantManger.FocusedNode.GetDisplayText(2);
                            if ((ss.ToLower()).Trim() == sTextToSearch.ToLower().Trim())
                            {
                                trlPlantManger.SetFocusedNode(mac);
                                //MessageBox.Show("data is found.");
                            }
                        }
                        ss = are.GetValue(2).ToString();

                        //  string ss = (string)trlPlantManger.FocusedNode.GetDisplayText(2);
                        if ((ss.ToLower()).Trim() == sTextToSearch.ToLower().Trim())
                        {
                            trlPlantManger.SetFocusedNode(are);
                            //MessageBox.Show("data is found.");

                        }
                    }
                    ss = fac.GetValue(2).ToString();

                    if ((ss.ToLower()).Trim() == sTextToSearch.ToLower().Trim())
                    {
                        trlPlantManger.SetFocusedNode(fac);
                       // MessageBox.Show("data is found.");
                    }
                }
            }
            catch { }


        }

        public void CloseSearch()
        {
            try
            {
                foreach (TreeListNode objNode in trlPlantManger.Nodes)
                {
                    //ReImageNodes(objNode);
                }//end( foreach (TreeListNode objNode in trlPlantMangerComponents.Nodes))
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void ReImageNodes(TreeListNode objParentNode)
        {
            try
            {
                string sNodeType = objParentNode.Tag.ToString();
                if (sNodeType == "Train")
                    objParentNode.StateImageIndex = 2;
                else if (sNodeType == "Machine")
                    objParentNode.StateImageIndex = 3;
                else if (sNodeType == "Point")
                    objParentNode.StateImageIndex = 4;
                else if (sNodeType == "Area")
                    objParentNode.StateImageIndex = 1;
                else if (sNodeType == "Plant")
                    objParentNode.StateImageIndex = 0;

                if (objParentNode.HasChildren)
                    foreach (TreeListNode objNode in objParentNode.Nodes)
                    {
                        ReImageNodes(objNode);
                    }//end(foreach (TreeListNode objNode in objParentNode.Nodes))

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }

        }

        private void RecurseNodes(TreeListNode objParentNode, string sText, string sSelectedItem)
        {

            try
            {
                string sNodeType = m_sItemType.ToString();                
                if (sNodeType == "Train")
                    objParentNode.StateImageIndex = 2;
                else if (sNodeType == "Machine")
                    objParentNode.StateImageIndex = 3;
                else if (sNodeType == "Point")
                    objParentNode.StateImageIndex = 4;
                else if (sNodeType == "Area")
                    objParentNode.StateImageIndex = 1;
                else if (sNodeType == "Plant")
                    objParentNode.StateImageIndex = 0;


                int iComparison = string.Compare(sSelectedItem, sNodeType, true);
                if (iComparison == 0)
                {
                    string sTempTolowerText = sText.ToLower();
                    string sTempToLowerValue = objParentNode.GetDisplayText(0).ToLower();
                    int iTextComparison = string.Compare(sText, objParentNode.GetDisplayText(0), true);
                    bool bContains = sTempToLowerValue.Contains(sTempTolowerText);
                    if (iComparison == 0 && iTextComparison == 0 || bContains)
                    {
                        if (sNodeType == "Train")
                            objParentNode.StateImageIndex = 7;
                        else if (sNodeType == "Machine")
                            objParentNode.StateImageIndex = 8;
                        else if (sNodeType == "Plant")
                            objParentNode.StateImageIndex = 5;
                        else if (sNodeType == "Point")
                            objParentNode.StateImageIndex = 9;
                        else if (sNodeType == "Area")
                            objParentNode.StateImageIndex = 6;
                        if (searchClicked)
                        {
                            trlPlantManger.SetFocusedNode(objParentNode);
                            searchClicked = false;
                        }
                        m_bSetFlag = true;
                    }//end(if(iComparison==0 && iTextComparison==0))

                }//end(if (iComparison == 0))

                if (objParentNode.HasChildren)
                    foreach (TreeListNode objNode in objParentNode.Nodes)
                    {
                        RecurseNodes(objNode, m_sTextToSearch, m_sItemType);
                    }//end(foreach (TreeListNode objNode in objParentNode.Nodes))
            }//end(try)
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }//end(catch (Exception ex))
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

                trlPlantManger.Columns.Add();
                trlPlantManger.Columns[0].Caption = "Id";
                trlPlantManger.Columns[0].VisibleIndex = -1;

                trlPlantManger.Columns.Add();
                trlPlantManger.Columns[1].Caption = "Count";
                trlPlantManger.Columns[1].VisibleIndex = -1;

                trlPlantManger.Columns.Add();
                trlPlantManger.Columns[2].Caption = "";
                trlPlantManger.Columns[2].VisibleIndex = 2;

                trlPlantManger.Columns.Add();
                trlPlantManger.Columns[3].Caption = "Description";
                trlPlantManger.Columns[3].VisibleIndex = -1;

                trlPlantManger.Columns.Add();
                trlPlantManger.Columns[4].Caption = "Factoryid";
                trlPlantManger.Columns[4].VisibleIndex = -1;

                trlPlantManger.Columns.Add();
                trlPlantManger.Columns[5].Caption = "Resourceid";
                trlPlantManger.Columns[5].VisibleIndex = -1;

                trlPlantManger.Columns.Add();
                trlPlantManger.Columns[6].Caption = "Elementid";
                trlPlantManger.Columns[6].VisibleIndex = -1;

                trlPlantManger.Columns.Add();
                trlPlantManger.Columns[7].Caption = "SubElementid";
                trlPlantManger.Columns[7].VisibleIndex = -1;

                trlPlantManger.Columns.Add();
                trlPlantManger.Columns[8].Caption = "Point";
                trlPlantManger.Columns[8].VisibleIndex = -1;

                trlPlantManger.Columns.Add();
                trlPlantManger.Columns[9].Caption = "";
                trlPlantManger.Columns[9].VisibleIndex = 0;
                trlPlantManger.Columns[9].Width = 20;
                trlPlantManger.Columns[9].ColumnEdit = new RepositoryItemPictureEdit();

                trlPlantManger.Columns.Add();
                trlPlantManger.Columns[10].Caption = "type";
                trlPlantManger.Columns[10].VisibleIndex = -1;
                
                trlPlantManger.Columns.Add();
                trlPlantManger.Columns[11].Caption = "";
                trlPlantManger.Columns[11].VisibleIndex = 1;
                trlPlantManger.Columns[11].Width = 20;
                trlPlantManger.Columns[11].ColumnEdit = new RepositoryItemPictureEdit();
            }
            catch { }
        }

        public void ChangeStyle(string StyleName)
        {
            try
            {
                this.BackColor = Color.Transparent;                
                trlPlantManger.Appearance.FocusedRow.BackColor = Color.Red;
                trlPlantManger.Appearance.FocusedRow.BackColor2 = Color.Goldenrod;
                trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                trlPlantManger.Appearance.HideSelectionRow.BackColor = Color.Red;
                trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.Goldenrod;
                trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;

                switch (StyleName)
                {
                    case "Caramel":
                        {                            
                            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Black, Color.Chocolate);
                            trlPlantManger.BackColor = Color.FromArgb(247, 245, 241);
                            trlPlantManger.Appearance.FocusedRow.BackColor = Color.Red;
                            trlPlantManger.Appearance.FocusedRow.BackColor2 = Color.Goldenrod;
                            trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                            trlPlantManger.Appearance.EvenRow.BackColor = Color.FromArgb(233, 225, 209);
                            trlPlantManger.Appearance.EvenRow.BackColor2 = Color.FromArgb(244, 242, 235);
                            trlPlantManger.Appearance.EvenRow.ForeColor = Color.Black;


                            trlPlantManger.Appearance.HideSelectionRow.BackColor = Color.FromArgb(255, 246, 162);
                            trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.FromArgb(254, 185, 58);
                            trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;


                            break;
                        }
                    case "Money Twins":
                        {                            
                            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Black, Color.CornflowerBlue);
                            trlPlantManger.BackColor = Color.FromArgb(227, 241, 254);
                            trlPlantManger.Appearance.FocusedRow.BackColor = Color.FromArgb(207, 238, 255);
                            trlPlantManger.Appearance.FocusedRow.BackColor2 = Color.FromArgb(174, 216, 255);
                            trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                            trlPlantManger.Appearance.EvenRow.BackColor = Color.FromArgb(186, 214, 242);
                            trlPlantManger.Appearance.EvenRow.BackColor2 = Color.FromArgb(152, 191, 235);
                            trlPlantManger.Appearance.EvenRow.ForeColor = Color.Black;


                            trlPlantManger.Appearance.HideSelectionRow.BackColor = Color.FromArgb(207, 238, 255);
                            trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.FromArgb(174, 216, 255);
                            trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;
                            break;
                        }
                    case "Lilian":
                        {                            
                            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Silver, Color.DarkBlue);
                            trlPlantManger.BackColor = Color.FromArgb(236, 237, 244);
                            trlPlantManger.Appearance.FocusedRow.BackColor = Color.FromArgb(224, 203, 223);
                            trlPlantManger.Appearance.FocusedRow.BackColor2 = Color.FromArgb(247, 242, 247);
                            trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                            trlPlantManger.Appearance.EvenRow.BackColor = Color.FromArgb(223, 246, 255);
                            trlPlantManger.Appearance.EvenRow.BackColor2 = Color.FromArgb(174, 211, 240);
                            trlPlantManger.Appearance.EvenRow.ForeColor = Color.Black;


                            trlPlantManger.Appearance.HideSelectionRow.BackColor = Color.FromArgb(224, 203, 223);
                            trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.FromArgb(247, 242, 247);
                            trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;
                            break;
                        }
                    case "The Asphalt World":
                        {
                            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Blue, Color.Khaki);

                            trlPlantManger.BackColor = Color.FromArgb(253, 253, 253);

                            trlPlantManger.Appearance.FocusedRow.BackColor = Color.FromArgb(225, 225, 225);
                            trlPlantManger.Appearance.FocusedRow.BackColor2 = Color.FromArgb(250, 250, 250);
                            trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                            trlPlantManger.Appearance.EvenRow.BackColor = Color.FromArgb(206, 221, 252);
                            trlPlantManger.Appearance.EvenRow.BackColor2 = Color.White;
                            trlPlantManger.Appearance.EvenRow.ForeColor = Color.Black;

                            trlPlantManger.Appearance.HideSelectionRow.BackColor = Color.FromArgb(225, 225, 225);
                            trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.FromArgb(250, 250, 250);
                            trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;

                            break;
                        }
                    case "iMaginary":
                        {
                            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Blue, Color.Green);

                            trlPlantManger.BackColor = Color.FromArgb(240, 240, 240);

                            trlPlantManger.Appearance.FocusedRow.BackColor = Color.FromArgb(139, 228, 98);
                            trlPlantManger.Appearance.FocusedRow.BackColor2 = Color.FromArgb(230, 247, 228);
                            trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                            trlPlantManger.Appearance.EvenRow.BackColor = Color.FromArgb(223, 246, 255);
                            trlPlantManger.Appearance.EvenRow.BackColor2 = Color.FromArgb(174, 211, 240);
                            trlPlantManger.Appearance.EvenRow.ForeColor = Color.Black;


                            trlPlantManger.Appearance.HideSelectionRow.BackColor = Color.FromArgb(230, 247, 228);
                            trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.FromArgb(173, 242, 122);
                            trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;
                            break;
                        }
                    case "Black":
                        {
                            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Black, Color.Black);

                            trlPlantManger.BackColor = Color.FromArgb(221, 221, 221);

                            trlPlantManger.Appearance.FocusedRow.BackColor = Color.FromArgb(167, 166, 158);
                            trlPlantManger.Appearance.FocusedRow.BackColor2 = Color.FromArgb(218, 209, 124);
                            trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                            trlPlantManger.Appearance.EvenRow.BackColor = Color.FromArgb(190, 190, 190);
                            trlPlantManger.Appearance.EvenRow.BackColor2 = Color.FromArgb(99, 99, 99);
                            trlPlantManger.Appearance.EvenRow.ForeColor = Color.Black;


                            trlPlantManger.Appearance.HideSelectionRow.BackColor = Color.FromArgb(167, 166, 158);
                            trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.FromArgb(218, 209, 124);
                            trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;

                            break;
                        }
                    case "Blue":
                        {
                            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Blue, Color.DarkBlue);

                            trlPlantManger.Appearance.FocusedRow.BackColor = Color.FromArgb(198, 238, 253);
                            trlPlantManger.Appearance.FocusedRow.BackColor2 = Color.FromArgb(114, 153, 208);
                            trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                            trlPlantManger.Appearance.EvenRow.BackColor = Color.FromArgb(73, 119, 186);
                            trlPlantManger.Appearance.EvenRow.BackColor2 = Color.FromArgb(151, 178, 220);
                            trlPlantManger.Appearance.EvenRow.ForeColor = Color.Black;


                            trlPlantManger.Appearance.HideSelectionRow.BackColor = Color.FromArgb(198, 238, 253);
                            trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.FromArgb(114, 153, 208);
                            trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;
                            break;
                        }
                    case "Stardust":
                        {
                            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Silver, Color.Fuchsia);

                            trlPlantManger.Appearance.FocusedRow.BackColor = Color.FromArgb(198, 238, 253);
                            trlPlantManger.Appearance.FocusedRow.BackColor2 = Color.FromArgb(114, 153, 208);
                            trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                            trlPlantManger.Appearance.EvenRow.BackColor = Color.FromArgb(73, 119, 186);
                            trlPlantManger.Appearance.EvenRow.BackColor2 = Color.FromArgb(151, 178, 220);
                            trlPlantManger.Appearance.EvenRow.ForeColor = Color.Black;


                            trlPlantManger.Appearance.HideSelectionRow.BackColor = Color.FromArgb(198, 238, 253);
                            trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.FromArgb(114, 153, 208);
                            trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;
                            break;
                        }
                    case "Liquid Sky":
                        {
                            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.VistaGlass, Color.LightSkyBlue);

                            trlPlantManger.Appearance.FocusedRow.BackColor = Color.FromArgb(198, 238, 253);
                            trlPlantManger.Appearance.FocusedRow.BackColor2 = Color.FromArgb(114, 153, 208);
                            trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                            trlPlantManger.Appearance.EvenRow.BackColor = Color.FromArgb(73, 119, 186);
                            trlPlantManger.Appearance.EvenRow.BackColor2 = Color.FromArgb(151, 178, 220);
                            trlPlantManger.Appearance.EvenRow.ForeColor = Color.Black;


                            trlPlantManger.Appearance.HideSelectionRow.BackColor = Color.FromArgb(198, 238, 253);
                            trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.FromArgb(114, 153, 208);
                            trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;
                            break;
                        }                 
                    case "Office 2007 Black":
                        {
                            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Black, Color.SeaGreen);

                            trlPlantManger.Appearance.FocusedRow.BackColor = Color.FromArgb(198, 238, 253);
                            trlPlantManger.Appearance.FocusedRow.BackColor2 = Color.FromArgb(114, 153, 208);
                            trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                            trlPlantManger.Appearance.EvenRow.BackColor = Color.FromArgb(73, 119, 186);
                            trlPlantManger.Appearance.EvenRow.BackColor2 = Color.FromArgb(151, 178, 220);
                            trlPlantManger.Appearance.EvenRow.ForeColor = Color.Black;


                            trlPlantManger.Appearance.HideSelectionRow.BackColor = Color.FromArgb(198, 238, 253);
                            trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.FromArgb(114, 153, 208);
                            trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;
                            break;
                        }
                    case "Office 2007 Silver":
                        {
                            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Silver, Color.SteelBlue);

                            trlPlantManger.Appearance.FocusedRow.BackColor = Color.FromArgb(198, 238, 253);
                            trlPlantManger.Appearance.FocusedRow.BackColor2 = Color.FromArgb(114, 153, 208);
                            trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                            trlPlantManger.Appearance.EvenRow.BackColor = Color.FromArgb(73, 119, 186);
                            trlPlantManger.Appearance.EvenRow.BackColor2 = Color.FromArgb(151, 178, 220);
                            trlPlantManger.Appearance.EvenRow.ForeColor = Color.Black;


                            trlPlantManger.Appearance.HideSelectionRow.BackColor = Color.FromArgb(198, 238, 253);
                            trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.FromArgb(114, 153, 208);
                            trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;
                            break;
                        }
                    case "Glass Oceans":
                        {
                            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.VistaGlass, Color.SpringGreen);
                            
                            trlPlantManger.Appearance.FocusedRow.BackColor = Color.FromArgb(198, 238, 253);
                            trlPlantManger.Appearance.FocusedRow.BackColor2 = Color.FromArgb(114, 153, 208);
                            trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                            trlPlantManger.Appearance.EvenRow.BackColor = Color.FromArgb(73, 119, 186);
                            trlPlantManger.Appearance.EvenRow.BackColor2 = Color.FromArgb(151, 178, 220);
                            trlPlantManger.Appearance.EvenRow.ForeColor = Color.Black;


                            trlPlantManger.Appearance.HideSelectionRow.BackColor = Color.FromArgb(198, 238, 253);
                            trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.FromArgb(114, 153, 208);
                            trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;
                            break;
                        }


                    default:
                        {
                            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Blue, Color.FromName(StyleName));
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
            }

        }

        internal void ChangeColorStyle(int A, int R, int G, int B)
        {
            try
            {
                A = A / 2;
                RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Black, Color.FromArgb(A, R, G, B));
                Color LightColor = ControlPaint.LightLight(Color.FromArgb(A, R, G, B));
                Color FocusColor = ControlPaint.Light(Color.FromArgb(A, R, G, B));

                this.BackColor = LightColor;
                xtrascroll.BackColor = (LightColor);
                trlPlantManger.BackColor = (LightColor);

                if (R == 255 && G == 0 && B == 0)
                {
                    trlPlantManger.Appearance.FocusedRow.BackColor = Color.Gold;
                    trlPlantManger.Appearance.FocusedRow.BackColor2 = Color.Goldenrod;
                    trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                    trlPlantManger.Appearance.HideSelectionRow.BackColor = Color.Gold;
                    trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.Goldenrod;
                    trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;

                }
                else
                {
                    trlPlantManger.Appearance.FocusedRow.BackColor = Color.Red;
                    trlPlantManger.Appearance.FocusedRow.BackColor2 = Color.Goldenrod;
                    trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                    trlPlantManger.Appearance.HideSelectionRow.BackColor = Color.Red;
                    trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.Goldenrod;
                    trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;

                }
                trlPlantManger.Appearance.FocusedRow.BackColor = (FocusColor);
                trlPlantManger.Appearance.FocusedRow.BackColor2 = (LightColor);
                trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                trlPlantManger.Appearance.EvenRow.BackColor = (LightColor);
                trlPlantManger.Appearance.EvenRow.BackColor2 = Color.FromArgb(A, R, G, B);
                trlPlantManger.Appearance.EvenRow.ForeColor = Color.Black;


                trlPlantManger.Appearance.HideSelectionRow.BackColor = (LightColor);
                trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.FromArgb(A, R, G, B);
                trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;


            }
            catch (Exception ex)
            {
            }
        }

        internal void ChangeColorStyle(string Name)
        {
            try
            {
                RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.VistaGlass, Color.FromName(Name));
                Color LightColor = ControlPaint.LightLight(Color.FromName(Name));
                Color FocusColor = ControlPaint.Light(Color.FromName(Name));
                this.BackColor = LightColor;
                xtrascroll.BackColor = (LightColor);
                trlPlantManger.BackColor = (LightColor);

                if (Name == "Red")
                {
                    trlPlantManger.Appearance.FocusedRow.BackColor = Color.Gold;
                    trlPlantManger.Appearance.FocusedRow.BackColor2 = Color.Goldenrod;
                    trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                    trlPlantManger.Appearance.HideSelectionRow.BackColor = Color.Gold;
                    trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.Goldenrod;
                    trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;
                }
                else
                {
                    trlPlantManger.Appearance.FocusedRow.BackColor = Color.Red;
                    trlPlantManger.Appearance.FocusedRow.BackColor2 = Color.Goldenrod;
                    trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                    trlPlantManger.Appearance.HideSelectionRow.BackColor = Color.Red;
                    trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.Goldenrod;
                    trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;
                }
                trlPlantManger.Appearance.FocusedRow.BackColor = (FocusColor);
                trlPlantManger.Appearance.FocusedRow.BackColor2 = (LightColor);
                trlPlantManger.Appearance.FocusedRow.ForeColor = Color.Black;

                trlPlantManger.Appearance.EvenRow.BackColor = (LightColor);
                trlPlantManger.Appearance.EvenRow.BackColor2 = Color.FromName(Name);
                trlPlantManger.Appearance.EvenRow.ForeColor = Color.Black;

                trlPlantManger.Appearance.HideSelectionRow.BackColor = (LightColor);
                trlPlantManger.Appearance.HideSelectionRow.BackColor2 = Color.FromName(Name);
                trlPlantManger.Appearance.HideSelectionRow.ForeColor = Color.Black;

            }
            catch (Exception ex)
            {
            }
        }
        
        private void Node_Factory()
        {
            try
            {
                TxtFactoryId.Text = "";
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select  max(factory_id)  from factory_info");
                string PreviousID = PublicClass.DefVal(Convert.ToString(dt.Rows[0][0]), "0");
                TxtFactoryId.Text = Convert.ToString(Convert.ToInt32(PublicClass.DefVal(Convert.ToString(PreviousID), "0")) + 1);
                string NextId = Convert.ToString(Convert.ToInt16(TxtFactoryId.Text) + 1);
                Image facimage = Iadeptmain.Images.ImageResources.Factory;
                parentForRootForFactory = trlPlantManger.AppendNode(new object[] { Convert.ToString(TxtFactoryId.Text), trlPlantManger.Nodes.Count, " Plant", " Plant", Convert.ToString(TxtFactoryId.Text), "0", "0", "0", "0", PublicClass.FAlarmImage, "Plant", facimage }, null);
                trlPlantManger.SetFocusedNode(parentForRootForFactory);
                DbClass.executequery(CommandType.Text, "insert factory_info ( Factory_id,  name,Description,PreviousID,NextID ,DateCreated) values ( '" + Convert.ToInt32(TxtFactoryId.Text) + "',  'Plant',  'Plant' ,'" + PreviousID + "' ,'" + NextId + "' ,'" + PublicClass.GetDatetime() + "') ");
                txtfactoryname.Text = "Plant";
                TxtDetail.Text = "Plant";
            }
            catch (Exception ex)
            {
            }
        }

        private void Node_Area()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select  max(Area_id)  from Area_info");
                string PreviousID = PublicClass.DefVal(Convert.ToString(dt.Rows[0][0]), "0");
                txtareaid.Text = Convert.ToString(Convert.ToInt32(PublicClass.DefVal(Convert.ToString(PreviousID), "0")) + 1);
                string Nextid = Convert.ToString(Convert.ToInt32(txtareaid.Text) + 1);
                Image Racimage = Iadeptmain.Images.ImageResources.resource;
                string fctid = (string)trlPlantManger.FocusedNode.GetDisplayText(4);
                if (LevelModify)
                {
                    if (sNodeType == PublicClass.nodelevel)
                    {
                        parentForRootForFactory = trlPlantManger.FocusedNode.ParentNode;
                    }
                    else
                    {
                        parentForRootForFactory = trlPlantManger.FocusedNode;
                    }
                }
                else
                {
                    parentForRootForFactory = trlPlantManger.FocusedNode;
                }
                parentForRootForResorce = trlPlantManger.AppendNode(new object[] { Convert.ToString(txtareaid.Text), trlPlantManger.Nodes.Count - 1, "Area", "Area", fctid, Convert.ToString(txtareaid.Text), "0", "0", "0", PublicClass.FAlarmImage, "Area", Racimage }, parentForRootForFactory);
                trlPlantManger.SetFocusedNode(parentForRootForResorce);
                txtareaname.Text = "Area";
                txtareadetail.Text = "Area";
                DbClass.executequery(CommandType.Text, "insert Area_info ( Area_ID ,Name ,Description,FactoryID ,PreviousID,NextID,DateCreated ) values ( '" + Convert.ToInt32(txtareaid.Text) + "',  'Area',  'Area','" + fctid.Trim() + "' ,'" + PreviousID + "' ,'" + Nextid + "' ,'" + PublicClass.GetDatetime() + "') ");
                trlPlantManger.ExpandAll();
            }
            catch (Exception exe)
            {
            }
        }

        private void Node_Element()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select  max(Train_ID)  from train_info");
                string PreviousID = PublicClass.DefVal(Convert.ToString(dt.Rows[0][0]), "0");
                txttrainid.Text = Convert.ToString(Convert.ToInt32(PublicClass.DefVal(Convert.ToString(PreviousID), "0")) + 1);
                string Nextid = Convert.ToString(Convert.ToInt32(txttrainid.Text) + 1);
                string fctid = (string)trlPlantManger.FocusedNode.GetDisplayText(4);
                string rctid = (string)trlPlantManger.FocusedNode.GetDisplayText(5);
                Image Racimage = Iadeptmain.Images.ImageResources.element1;
                if (LevelModify)
                {
                    if (sNodeType == PublicClass.nodelevel)
                    {
                        parentForRootForResorce = trlPlantManger.FocusedNode.ParentNode;
                    }
                    else
                    {
                        parentForRootForResorce = trlPlantManger.FocusedNode;
                    }
                }
                else
                {
                    parentForRootForResorce = trlPlantManger.FocusedNode;
                }
                parentForRootForElement = trlPlantManger.AppendNode(new object[] { Convert.ToString(txttrainid.Text), trlPlantManger.Nodes.Count - 1, "Train", "Train", fctid, rctid, Convert.ToString(txttrainid.Text), "0", "0", PublicClass.FAlarmImage, "Train", Racimage }, parentForRootForResorce);
                trlPlantManger.SetFocusedNode(parentForRootForElement);
                txttraininfoname.Text = "Train";
                txttraindetail.Text = "Train";
                DbClass.executequery(CommandType.Text, "insert train_info ( Train_ID,Name,Description,Area_ID  ,PreviousID,NextID,Date) values ( " + Convert.ToInt32(txttrainid.Text) + ",  'Train',  'Train' ," + rctid.Trim() + ", '" + PreviousID + "' ,'" + Nextid + "' ,'" + PublicClass.GetDatetime() + "') ");
                trlPlantManger.ExpandAll();
            }
            catch (Exception exe)
            {
            }
        }

        private void Node_SubElement()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select  max(Machine_ID)  from machine_info");
                string PreviousID = PublicClass.DefVal(Convert.ToString(dt.Rows[0][0]), "0");
                txtmachineid.Text = Convert.ToString(Convert.ToInt32(PublicClass.DefVal(Convert.ToString(PreviousID), "0")) + 1);
                string Nextid = Convert.ToString(Convert.ToInt32(txtmachineid.Text) + 1);
                string fctid = (string)trlPlantManger.FocusedNode.GetDisplayText(4);
                string rctid = (string)trlPlantManger.FocusedNode.GetDisplayText(5);
                string etid = (string)trlPlantManger.FocusedNode.GetDisplayText(6);
                Image Racimage = Iadeptmain.Images.ImageResources.subelement_new;
                if (LevelModify)
                {
                    if (sNodeType == PublicClass.nodelevel)
                    {
                        parentForRootForElement = trlPlantManger.FocusedNode.ParentNode;
                    }
                    else
                    {
                        parentForRootForElement = trlPlantManger.FocusedNode;
                    }
                }
                else
                {
                    parentForRootForElement = trlPlantManger.FocusedNode;
                }
                //parentForRootForElement = trlPlantManger.FocusedNode;
                parentForSubelement = trlPlantManger.AppendNode(new object[] { Convert.ToString(txtmachineid.Text), trlPlantManger.Nodes.Count - 1, "Machine", "Machine", fctid, rctid, etid, Convert.ToString(txtmachineid.Text), "0", PublicClass.FAlarmImage, "Machine", Racimage }, parentForRootForElement);
                trlPlantManger.SetFocusedNode(parentForSubelement);
                txtmachinename.Text = "Machine";
                txtmachinedetail.Text = "Machine";
                txtRpm.Text = "1800";
                txtpulserev.Text = "1";
                DbClass.executequery(CommandType.Text, "insert machine_info ( Machine_ID,name,Description,TrainID, PreviousID,NextID,DateCreated,RPM_Driven,PulseRev) values ( '" + Convert.ToInt32(txtmachineid.Text) + "',  'Machine',  'Machine' ,'" + etid.Trim() + "' , '" + PreviousID + "' ,'" + Nextid + "' ,'" + PublicClass.GetDatetime() + "','" + txtRpm.Text + "','" + txtpulserev.Text + "' ) ");
                trlPlantManger.ExpandAll();
            }
            catch (Exception exe)
            {       }
        }

        private void Node_Point()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select  max(Point_ID)  from POINT");
                string PreviousID = PublicClass.DefVal(Convert.ToString(dt.Rows[0][0]), "0");
                txtpointid.Text = Convert.ToString(Convert.ToInt32(PublicClass.DefVal(Convert.ToString(PreviousID), "0")) + 1);
                string Nextid = Convert.ToString(Convert.ToInt32(txtpointid.Text) + 1);
                string fctid = (string)trlPlantManger.FocusedNode.GetDisplayText(4);
                string rctid = (string)trlPlantManger.FocusedNode.GetDisplayText(5);
                string etid = (string)trlPlantManger.FocusedNode.GetDisplayText(6);
                string sub_etid = (string)trlPlantManger.FocusedNode.GetDisplayText(7);
                Image Racimage = Iadeptmain.Images.ImageResources.Point;
                string s = trlPlantManger.FocusedNode.GetDisplayText("type");
                if (s == "Machine")
                {
                    trlnFocusedNode = trlPlantManger.FocusedNode;
                }
                else
                {
                    trlnFocusedNode = trlPlantManger.FocusedNode.ParentNode;
                }
                if (LevelModify)
                {
                    if (sNodeType == PublicClass.nodelevel)
                    {
                        trlnFocusedNode = trlPlantManger.FocusedNode.ParentNode;
                    }
                    else
                    {
                        trlnFocusedNode = trlPlantManger.FocusedNode;
                    }
                }
                parentForSubelement = trlPlantManger.AppendNode(new object[] { Convert.ToString(txtpointid.Text), trlPlantManger.Nodes.Count - 1, "Point", "Point", fctid, rctid, etid, sub_etid, txtpointid.Text, PublicClass.FAlarmImage, "Point", Racimage }, trlnFocusedNode);
                trlPlantManger.SetFocusedNode(parentForSubelement);
                txtpointname1.Text = "Point";
                txtpointdetail1.Text = "Point";
                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                {
                    DbClass.executequery(CommandType.Text, "insert POINT (point_id ,PointName,PointDesc,Machine_ID, PreviousID,NextID,DataCreated,PointStatus,PointSchedule) values ( " + Convert.ToInt32(txtpointid.Text) + ",  'Point',  'Point' ," + sub_etid.Trim() + " , '" + PreviousID + "' ,'" + Nextid + "' ,'" + PublicClass.GetDatetime() + "','0','1' ) ");
                }
                else
                {
                    string ppname = "Point" + txtpointid.Text;
                    DbClass.executequery(CommandType.Text, "insert POINT (point_id ,PointName,PointDesc,Machine_ID, PreviousID,NextID,DataCreated,PointStatus,PointSchedule) values ( " + Convert.ToInt32(txtpointid.Text) + ",  '" + ppname + "',  'Point' ," + sub_etid.Trim() + " , '" + PreviousID + "' ,'" + Nextid + "' ,'" + PublicClass.GetDatetime() + "','0','1' ) ");
                    txtpointname1.Text = ppname;
                }
                string sNode = "pd.Point_ID = " + Convert.ToInt32(txtpointid.Text);
                PublicClass.SPointID = sNode;
                trlPlantManger.ExpandAll();
                Fill_Cmb_Point_type();
                ShowPointDetail();
                applyallchecks(PublicClass.SPointID);
            }
            catch (Exception exe)
            {
            }
        }

        public void settabpages()
        {            
            TabData.PageVisible = false;           
            TabImages.PageVisible = false;
            TabCollection.PageVisible = false;
            TabRecord.PageVisible = false;
            TabOtherField.PageVisible = false;
            Tabbearing.PageVisible = false;
            AreaInfo.PageVisible = false;
            TabTrainInfo.PageVisible = false;
            TabMachineInfo.PageVisible = false;
            TabPointInfo.PageVisible = false;
            TabFacInfo.PageVisible = true;
            DataTable dtFact = DbClass.getdata(CommandType.Text, "Select Name , Description from factory_info where Factory_ID in(Select min(Factory_ID) from factory_info)");
            try
            {
                if (dtFact.Rows.Count > 0)
                {
                    txtfactoryname.Text = Convert.ToString(dtFact.Rows[0]["Name"]);
                    TxtDetail.Text = Convert.ToString(dtFact.Rows[0]["Description"]);
                }
                else
                {
                    txtfactoryname.Text = "Plant";
                    TxtDetail.Text = "";
                }
            }
            catch
            {    }
            CtrTab.SelectedTabPageIndex = 0;          
        
        }
        
        public void visbilty(string NodeType)
        {
            _objMain = this.MainForm;
            if (NodeType.Trim() == "Plant")
            {
                _objMain.InsertFactoryButton = true;
                _objMain.InsertResourceButton = true;
                _objMain.InsertElementButton = false;
                _objMain.InsertSubElementButton = false;
                _objMain.InsertPointButton = false;
                TabFacInfo.PageVisible = true;               
                TabData.PageVisible = false;
                TabImages.PageVisible = false;
                TabCollection.PageVisible = false;
                TabRecord.PageVisible = false;
                TabOtherField.PageVisible = false;                
                Tabbearing.PageVisible = false;               
                AreaInfo.PageVisible = false;
                TabTrainInfo.PageVisible = false;
                TabMachineInfo.PageVisible = false;
                TabPointInfo.PageVisible = false;
                TabOverAll.PageVisible = false;
                TabGraph.PageVisible = false;
                CtrTab.SelectedTabPageIndex = 0;
            }
            else if (NodeType.Trim() == "Area")
            {
                _objMain.InsertFactoryButton = false;
                _objMain.InsertResourceButton = false;
                _objMain.InsertElementButton = true;
                _objMain.InsertSubElementButton = false;
                _objMain.InsertPointButton = false;
                AreaInfo.PageVisible = true;               
                TabData.PageVisible = false;
                TabImages.PageVisible = false;
                TabCollection.PageVisible = false;
                TabRecord.PageVisible = false;
                TabOtherField.PageVisible = false;                
                TabFacInfo.PageVisible = false;               
                Tabbearing.PageVisible = false;
                TabTrainInfo.PageVisible = false;
                TabMachineInfo.PageVisible = false;
                TabPointInfo.PageVisible = false;
                TabOverAll.PageVisible = false;
                TabGraph.PageVisible = false;
                CtrTab.SelectedTabPageIndex = 1;
                sNodeType = NodeType.Trim();
            }
            else if (NodeType.Trim() == "Train")
            {
                _objMain.InsertFactoryButton = false;
                _objMain.InsertResourceButton = false;
                _objMain.InsertElementButton = false;
                _objMain.InsertSubElementButton = true;
                _objMain.InsertPointButton = false;
                
                TabTrainInfo.PageVisible = true;               
                TabData.PageVisible = false;
                TabImages.PageVisible = false;
                TabCollection.PageVisible = false;
                TabRecord.PageVisible = false;
                TabOtherField.PageVisible = false;               
                TabFacInfo.PageVisible = false;               
                AreaInfo.PageVisible = false;
                Tabbearing.PageVisible = false;
                TabMachineInfo.PageVisible = false;
                TabPointInfo.PageVisible = false;
                TabOverAll.PageVisible = false;
                TabGraph.PageVisible = false;
                CtrTab.SelectedTabPageIndex = 2;
                sNodeType = NodeType.Trim();
            }
            else if (NodeType.Trim() == "Machine")
            {
                _objMain.InsertFactoryButton = false;
                _objMain.InsertResourceButton = false;
                _objMain.InsertElementButton = false;
                _objMain.InsertSubElementButton = false;
                _objMain.InsertPointButton = true;
                TabMachineInfo.PageVisible = true;                
                TabData.PageVisible = false;
                TabImages.PageVisible = true;
                TabCollection.PageVisible = false;
                TabRecord.PageVisible = false;
                TabOtherField.PageVisible = true;               
                TabFacInfo.PageVisible = false;               
                AreaInfo.PageVisible = false;
                TabTrainInfo.PageVisible = false;
                Tabbearing.PageVisible = false;
                TabPointInfo.PageVisible = false;
                TabOverAll.PageVisible = false;
                TabGraph.PageVisible = false;
                CtrTab.SelectedTabPageIndex = 3;
                sNodeType = NodeType.Trim();
            }
            else if (NodeType.Trim() == "Point")
            {
                _objMain.InsertFactoryButton = true;
                _objMain.InsertResourceButton = false;
                _objMain.InsertElementButton = false;
                _objMain.InsertSubElementButton = false;
                _objMain.InsertPointButton = true;
                TabPointInfo.PageVisible = true;
                TabData.PageVisible = true;               
                TabOverAll.PageVisible = true;              
                TabImages.PageVisible = false;
                TabCollection.PageVisible = false;
                TabRecord.PageVisible = false;
                TabOtherField.PageVisible = false;
                TabFacInfo.PageVisible = false;
                AreaInfo.PageVisible = false;
                Tabbearing.PageVisible = true;
                TabTrainInfo.PageVisible = false;
                TabMachineInfo.PageVisible = false;
                TabGraph.PageVisible = false;
                CtrTab.SelectedTabPageIndex = 4;
                sNodeType = NodeType.Trim();
            }
            else
            {
                _objMain.InsertFactoryButton = true;
            }

        }

        void iAdeptBaseUserControl_Click(object sender, EventArgs e)
        {
            TreeListNode node = trlPlantManger.FocusedNode;
            int CurrentNodeIndex = trlPlantManger.GetNodeIndex(node);
            if (sNodeType == "Plant")
            {
                Node_Factory();
                visbilty("Plant");
            }
            else if (sNodeType == "Area")
            {
                Node_Area();
                visbilty("Area");
            }
            else if (sNodeType == "Train")
            {
                Node_Element();
                visbilty("Train");
            }
            else if (sNodeType == "Machine")
            {
                Node_SubElement();
                visbilty("Machine");
            }
            else if (sNodeType == "Point")
            {              
                Node_Point();
                visbilty("Point");
            }
        }

        internal void InsertNextLevelFB(string sNewNode)
        {
            sNodeType = sNewNode;
            TxtFactoryId.Text = "";
            PublicClass.FAlarmImage = ImageResources.gre;
            try
            {
                if (sNodeType == "Plant")
                {
                    CtrTab.SelectedTabPageIndex = 8;                 
                    iAdeptBaseUserControl_Click(sNewNode, null);
                }
                else if (sNodeType == "Area")
                {
                    CtrTab.SelectedTabPageIndex = 10;                  
                    iAdeptBaseUserControl_Click(sNewNode, null);
                }
                else if (sNodeType == "Train")
                {
                    CtrTab.SelectedTabPageIndex = 11;
                    iAdeptBaseUserControl_Click(sNewNode, null);
                }
                else if (sNodeType == "Machine")
                {                 
                    CtrTab.SelectedTabPageIndex = 12;
                    iAdeptBaseUserControl_Click(sNewNode, null);
                }
                else if (sNodeType == "Point")
                {                  
                    iAdeptBaseUserControl_Click(sNewNode, null);
                }
                    CtrTab.SelectedTabPageIndex = 12;
            }
            catch (Exception exe)
            {
                //GlobalClasess.Errorlogfile.LogFile(exe.Message, exe.ToString(), Iadeptmain.GlobalClasess.ExceptionHelper.LineNumber(exe), this.FindForm().Name);
            }
        }
   
        private void TabFacInfo_MouseLeave_1(object sender, EventArgs e)
        {            
            if (sNodeType == "Plant" && Convert.ToString(txtfactoryname.Text).Trim()!="")
            {
                DataTable dt = new DataTable();
                DbClass.executequery(CommandType.Text, "update factory_info set name = '" + txtfactoryname.Text + "' , Description = '" + TxtDetail.Text + "' where factory_id = '" + Convert.ToString(TxtFactoryId.Text).Trim() + "' ");
               
            }
            //filltreelist();
            if (trlPlantManger.Nodes.Count != 0)
            {
                trlPlantManger.FocusedNode.SetValue(2, txtfactoryname.Text);
            }
        }

        string ids = null;

        public void filltreelist()
        {
            DataTable Factorydt = new DataTable();
            DataTable AreaDT = new DataTable();
            DataTable TrainDt = new DataTable();
            DataTable MachineDt = new DataTable();
            DataTable PointDt = new DataTable();
            int r = 0;
            try
            {
                sNodeType = "";
                Factorydt = DbClass.getdata(CommandType.Text, "select FACTORY_ID ,NAME,Description  from factory_info ");

                AreaDT = DbClass.getdata(CommandType.Text, "select Area_ID,NAME,DESCRIPTION,FactoryID  from area_info ");

                TrainDt = DbClass.getdata(CommandType.Text, "select Train_ID,NAME,Description ,Area_ID from train_info ");

                MachineDt = DbClass.getdata(CommandType.Text, "select  Machine_ID ,NAME ,Description,TrainID from machine_info  ");

                PointDt = DbClass.getdata(CommandType.Text, "SELECT  Point_ID ,POINTNAME ,PointDesc,Machine_ID  FROM POINT  ");
                TreeListNode newnode = null;
                trlPlantManger.ClearNodes();
                TreeListNode parentForRootForFactory11 = null;
                TreeListNode parentForRootForResorce11 = null;
                TreeListNode parentForRootForElement11 = null;
                TreeListNode parentForSubelement11 = null;
                TreeListNode parentForRootPoint11 = null;

                foreach (DataRow FactoryRow in Factorydt.Rows)
                {
                    Image facimage = ImageResources.Factory;
                    ids = null;
                    ids = "a.FactoryID = " + Convert.ToString(FactoryRow["Factory_ID"]);
                    setflag("factory_id =" + Convert.ToString(FactoryRow["Factory_ID"]));
                    parentForRootForFactory11 = trlPlantManger.AppendNode(new object[] { Convert.ToString(FactoryRow["Factory_ID"]), trlPlantManger.Nodes.Count, Convert.ToString(FactoryRow["Name"]), Convert.ToString(FactoryRow["Description"]), Convert.ToString(FactoryRow["Factory_ID"]), "0", "0", "0", "0", PublicClass.FAlarmImage, "Plant", facimage }, null);

                    //*******************************Area***********************************
                    foreach (DataRow AreaRow in AreaDT.Select("FactoryID = '" + Convert.ToString(FactoryRow["Factory_ID"]) + "'"))
                    {
                        Image Areaimage = ImageResources.resource;
                        ids = null;
                        ids = "t.Area_ID = " + Convert.ToString(AreaRow["Area_ID"]);
                        setflag("area_id =" + Convert.ToString(AreaRow["Area_ID"]));
                        parentForRootForResorce11 = trlPlantManger.AppendNode(new object[] { Convert.ToString(AreaRow["Area_ID"]), trlPlantManger.Nodes.Count - 1, Convert.ToString(AreaRow["Name"]), Convert.ToString(AreaRow["Description"]), Convert.ToString(AreaRow["FactoryID"]), Convert.ToString(AreaRow["Area_ID"]), "0", "0", "0", PublicClass.FAlarmImage, "Area", Areaimage }, parentForRootForFactory11);

                        //************************Train********************************************

                        foreach (DataRow TrainRow in TrainDt.Select("Area_ID = '" + Convert.ToString(AreaRow["Area_ID"]) + "' "))
                        {
                            Image Trainimage = ImageResources.element1;
                            ids = null;
                            ids = "m.TrainID = " + Convert.ToString(TrainRow["Train_ID"]);
                            setflag("train_id =" + Convert.ToString(TrainRow["Train_ID"]));
                            parentForRootForElement11 = trlPlantManger.AppendNode(new object[] { Convert.ToString(TrainRow["Train_ID"]), trlPlantManger.Nodes.Count - 1, Convert.ToString(TrainRow["name"]), Convert.ToString(TrainRow["Description"]), Convert.ToString(FactoryRow["Factory_ID"]), Convert.ToString(AreaRow["Area_ID"]), Convert.ToString(TrainRow["Train_ID"]), "0", "0", PublicClass.FAlarmImage, "Train", Trainimage }, parentForRootForResorce11);

                            // **********************Machine ***********************

                            foreach (DataRow MachineRow in MachineDt.Select("TrainID = '" + Convert.ToString(TrainRow["Train_ID"]) + "'  "))
                            {
                                Image machineimage = ImageResources.subelement_new;
                                ids = null;
                                ids = "p.Machine_ID = " + Convert.ToString(MachineRow["Machine_ID"]);

                                setflag("machine_id =" + Convert.ToString(MachineRow["Machine_ID"]));
                                parentForSubelement11 = trlPlantManger.AppendNode(new object[] { Convert.ToString(MachineRow["Machine_ID"]), trlPlantManger.Nodes.Count - 1, Convert.ToString(MachineRow["name"]), Convert.ToString(MachineRow["Description"]), Convert.ToString(FactoryRow["Factory_ID"]), Convert.ToString(AreaRow["Area_ID"]), Convert.ToString(TrainRow["Train_ID"]), Convert.ToString(MachineRow["Machine_ID"]), "0", PublicClass.FAlarmImage, "Machine", machineimage }, parentForRootForElement11);


                                // *****************Point************************************ 

                                foreach (DataRow PointRow in PointDt.Select(" Machine_ID = '" + Convert.ToString(MachineRow["Machine_ID"]) + "' "))
                                {
                                    Image pointimage = Iadeptmain.Images.ImageResources.Point;
                                    ids = null;
                                    ids = "pd.Point_ID = " + Convert.ToString(PointRow["Point_ID"]);
                                    setflag("point_id =" + Convert.ToString(PointRow["Point_ID"]));
                                    parentForRootPoint11 = trlPlantManger.AppendNode(new object[] { Convert.ToString(PointRow["Point_ID"]), trlPlantManger.Nodes.Count - 1, Convert.ToString(PointRow["POINTNAME"]), Convert.ToString(PointRow["PointDesc"]), Convert.ToString(FactoryRow["Factory_ID"]), Convert.ToString(AreaRow["Area_ID"]), Convert.ToString(TrainRow["Train_ID"]), Convert.ToString(MachineRow["Machine_ID"]), Convert.ToString(PointRow["Point_ID"]), PublicClass.FAlarmImage, "Point", pointimage }, parentForSubelement11);

                                }//****************end of point

                            }//********************end of Machine

                        }//****************************end of Train

                    }//****************************end of Area

                }//**********************************end of Factory
                trlPlantManger.ExpandAll();
                sNodeType = (string)trlPlantManger.FocusedNode.GetDisplayText(10);
                PublicClass.SFactoryID = (string)trlPlantManger.FocusedNode.GetDisplayText(4);
                PublicClass.SAreaID = (string)trlPlantManger.FocusedNode.GetDisplayText(5);
                PublicClass.STrainID = (string)trlPlantManger.FocusedNode.GetDisplayText(6);
                PublicClass.SMachineID = (string)trlPlantManger.FocusedNode.GetDisplayText(7);
                PublicClass.SPointID = (string)trlPlantManger.FocusedNode.GetDisplayText(8);
                PublicClass.pointtext = txtpointname1.Text;
                if (sNodeType == "")
                {
                    settabpages();
                    _objMain.InsertFactoryButton = true;
                    _objMain.InsertResourceButton = true;
                    _objMain.InsertElementButton = false;
                    _objMain.InsertSubElementButton = false;
                    _objMain.InsertPointButton = false;
                }
                else if (sNodeType == "Plant")
                {
                    visbilty(sNodeType);
                }
            }
            catch {
                if (sNodeType == "")
                {
                    try
                    {
                        settabpages();
                        _objMain.InsertFactoryButton = true;
                        _objMain.InsertResourceButton = true;
                        _objMain.InsertElementButton = false;
                        _objMain.InsertSubElementButton = false;
                        _objMain.InsertPointButton = false;
                    }
                    catch { }
                }
            }
        }

        public void filltreelistDownload(string allID)
        {
            DataTable Factorydt = new DataTable();
            DataTable AreaDT = new DataTable();
            DataTable TrainDt = new DataTable();
            DataTable MachineDt = new DataTable();
            DataTable PointDt = new DataTable();
            int r = 0;
            try
            {
                sNodeType = "";
                string allids = allID + "0";

                Factorydt = DbClass.getdata(CommandType.Text, "select f.FACTORY_ID , f.NAME,f.Description , a.Area_ID,a.NAME,a.DESCRIPTION,a.FactoryID ,t.Train_ID,t.NAME,t.Description ,t.Area_ID as AreaID ,m.Machine_ID ,m.NAME ,m.Description,m.TrainID, p.Point_ID ,p.POINTNAME ,p.PointDesc,p.Machine_ID as MachineID  from factory_info f inner join area_info a on f.FACTORY_ID = a.FactoryID  inner join train_info t on t.Area_ID = a.Area_ID inner join machine_info m  on m.TrainID = t.Train_ID inner join POINT p on p.Machine_ID = m.Machine_ID where p.Point_ID IN(" + allids + ")");

                TreeListNode newnode = null;
                //trlPlantManger.ClearNodes();
                TreeListNode parentForRootForFactory11 = null;
                TreeListNode parentForRootForResorce11 = null;
                TreeListNode parentForRootForElement11 = null;
                TreeListNode parentForSubelement11 = null;
                TreeListNode parentForRootPoint11 = null;


                string fchk = null;
                string achk = null;
                string tchk = null;
                string mchk = null;
                string pchk = null;

                foreach (DataRow FactoryRow in Factorydt.Rows)
                {
                    string FID = Convert.ToString(FactoryRow["Factory_ID"]);
                    string AID = Convert.ToString(FactoryRow["Area_ID"]);
                    string TID = Convert.ToString(FactoryRow["Train_ID"]);
                    string MID = Convert.ToString(FactoryRow["Machine_ID"]);
                    string PID = Convert.ToString(FactoryRow["Point_ID"]);


                    if (FID != fchk)
                    {
                        Image facimage = ImageResources.Factory;
                        ids = null;
                        fchk = Convert.ToString(FactoryRow["Factory_ID"]);
                        ids = "a.FactoryID = " + Convert.ToString(FactoryRow["Factory_ID"]);
                        setflag("factory_id =" + Convert.ToString(FactoryRow["Factory_ID"]));
                        RepositoryItemPictureEdit imageEdit = new RepositoryItemPictureEdit();
                        imageEdit.Appearance.Image = PublicClass.FAlarmImage;
                        trlPlantManger.Columns[9].OptionsColumn.Reset();

                        trlPlantManger.Columns[9].ColumnEdit = imageEdit;
                       // parentForRootForFactory11 = trlPlantManger.AppendNode(new object[] { Convert.ToString(FactoryRow["Factory_ID"]), trlPlantManger.Nodes.Count, Convert.ToString(FactoryRow["Name"]), Convert.ToString(FactoryRow["Description"]), Convert.ToString(FactoryRow["Factory_ID"]), "0", "0", "0", "0", PublicClass.FAlarmImage, "Factory", facimage }, null);

                    }


                    //*******************************Area***********************************
                    if (AID != achk)
                    {
                        Image Areaimage = ImageResources.resource;
                        ids = null;
                        achk = Convert.ToString(FactoryRow["Area_ID"]);
                        ids = "t.Area_ID = " + Convert.ToString(FactoryRow["Area_ID"]);
                        setflag("area_id =" + Convert.ToString(FactoryRow["Area_ID"]));
                        RepositoryItemPictureEdit imageEdit = new RepositoryItemPictureEdit();
                        imageEdit.Appearance.Image = PublicClass.FAlarmImage;
                        trlPlantManger.Columns[9].ColumnEdit = imageEdit;
                        //parentForRootForResorce11.SetValue(imageEdit, 9);
                       // parentForRootForResorce11 = trlPlantManger.AppendNode(new object[] { Convert.ToString(FactoryRow["Area_ID"]), trlPlantManger.Nodes.Count - 1, Convert.ToString(FactoryRow["Name"]), Convert.ToString(FactoryRow["Description"]), Convert.ToString(FactoryRow["FactoryID"]), Convert.ToString(FactoryRow["Area_ID"]), "0", "0", "0",imageEdit, "Area", Areaimage }, parentForRootForFactory11);
                        
                    }

                    //************************Train********************************************

                    if (TID != tchk)
                    {
                        Image Trainimage = ImageResources.element1;
                        ids = null;
                        tchk = Convert.ToString(FactoryRow["Train_ID"]);
                        ids = "m.TrainID = " + Convert.ToString(FactoryRow["Train_ID"]);
                        setflag("train_id =" + Convert.ToString(FactoryRow["Train_ID"]));
                        RepositoryItemPictureEdit imageEdit = new RepositoryItemPictureEdit();
                        imageEdit.Appearance.Image = PublicClass.FAlarmImage;
                        trlPlantManger.Columns[9].ColumnEdit = imageEdit;
                       // parentForRootForElement11 = trlPlantManger.AppendNode(new object[] { Convert.ToString(FactoryRow["Train_ID"]), trlPlantManger.Nodes.Count - 1, Convert.ToString(FactoryRow["name"]), Convert.ToString(FactoryRow["Description"]), Convert.ToString(FactoryRow["Factory_ID"]), Convert.ToString(FactoryRow["Area_ID"]), Convert.ToString(FactoryRow["Train_ID"]), "0", "0", PublicClass.FAlarmImage, "Train", Trainimage }, parentForRootForResorce11);
                       
                    }

                    // **********************Machine ***********************

                    if (MID != mchk)
                    {
                        Image machineimage = ImageResources.machine;
                        ids = null;
                        mchk = Convert.ToString(FactoryRow["Machine_ID"]);
                        ids = "p.Machine_ID = " + Convert.ToString(FactoryRow["Machine_ID"]);
                        setflag("machine_id =" + Convert.ToString(FactoryRow["Machine_ID"]));
                        RepositoryItemPictureEdit imageEdit = new RepositoryItemPictureEdit();
                        imageEdit.Appearance.Image = PublicClass.FAlarmImage;
                        trlPlantManger.Columns[9].ColumnEdit = imageEdit;
                        //parentForSubelement11 = trlPlantManger.AppendNode(new object[] { Convert.ToString(FactoryRow["Machine_ID"]), trlPlantManger.Nodes.Count - 1, Convert.ToString(FactoryRow["name"]), Convert.ToString(FactoryRow["Description"]), Convert.ToString(FactoryRow["Factory_ID"]), Convert.ToString(FactoryRow["Area_ID"]), Convert.ToString(FactoryRow["Train_ID"]), Convert.ToString(FactoryRow["Machine_ID"]), "0", PublicClass.FAlarmImage, "Machine", machineimage }, parentForRootForElement11);

                    }

                    // *****************Point************************************ 
                    if (PID != pchk)
                    {
                        Image pointimage = Iadeptmain.Images.ImageResources.Point;
                        ids = null;
                        pchk = Convert.ToString(FactoryRow["Point_ID"]);
                        ids = "pd.Point_ID = " + Convert.ToString(FactoryRow["Point_ID"]);
                        setflag("point_id =" + Convert.ToString(FactoryRow["Point_ID"]));
                        RepositoryItemPictureEdit imageEdit = new RepositoryItemPictureEdit();
                        imageEdit.Appearance.Image = PublicClass.FAlarmImage;
                        trlPlantManger.Columns[9].ColumnEdit= imageEdit;
                       // parentForRootPoint11 = trlPlantManger.AppendNode(new object[] { Convert.ToString(FactoryRow["Point_ID"]), trlPlantManger.Nodes.Count - 1, Convert.ToString(FactoryRow["POINTNAME"]), Convert.ToString(FactoryRow["PointDesc"]), Convert.ToString(FactoryRow["Factory_ID"]), Convert.ToString(FactoryRow["Area_ID"]), Convert.ToString(FactoryRow["Train_ID"]), Convert.ToString(FactoryRow["Machine_ID"]), Convert.ToString(FactoryRow["Point_ID"]), PublicClass.FAlarmImage, "Point", pointimage }, parentForSubelement11);

                    }

                }

                trlPlantManger.ExpandAll();
                sNodeType = (string)trlPlantManger.FocusedNode.GetDisplayText(10);
                PublicClass.SFactoryID = (string)trlPlantManger.FocusedNode.GetDisplayText(4);
                PublicClass.SAreaID = (string)trlPlantManger.FocusedNode.GetDisplayText(5);
                PublicClass.STrainID = (string)trlPlantManger.FocusedNode.GetDisplayText(6);
                PublicClass.SMachineID = (string)trlPlantManger.FocusedNode.GetDisplayText(7);
                PublicClass.SPointID = (string)trlPlantManger.FocusedNode.GetDisplayText(8);
                PublicClass.pointtext = txtpointname1.Text;
                if (sNodeType == "")
                {
                    settabpages();
                    _objMain.InsertFactoryButton = true;
                    _objMain.InsertResourceButton = true;
                    _objMain.InsertElementButton = false;
                    _objMain.InsertSubElementButton = false;
                    _objMain.InsertPointButton = false;
                }
                else if (sNodeType == "Plant")
                {
                    visbilty(sNodeType);
                }
            }
            catch
            {
                if (sNodeType == "")
                {
                    settabpages();
                    _objMain.InsertFactoryButton = true;
                    _objMain.InsertResourceButton = true;
                    _objMain.InsertElementButton = false;
                    _objMain.InsertSubElementButton = false;
                    _objMain.InsertPointButton = false;
                }
            }
        }

        public int checkValueForFlagGenerate(string query, string sAlarmID, int i)
        {

            if (Convert.ToString(sAlarmID).Trim() == "" || Convert.ToString(sAlarmID).Trim() == "0")
            {
                //PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.gre;
                i = 0;
                return i;
            }
            double faccel_a1 = 0;
            double faccel_h1 = 0;
            double faccel_v1 = 0;
            double faccel_a2 = 0;
            double faccel_h2 = 0;
            double faccel_v2 = 0;
            double faccel_ch11 = 0;
            double faccel_ch12 = 0;
            double fvel_a1 = 0;
            double fvel_h1 = 0;
            double fvel_v1 = 0;
            double fvel_a2 = 0;
            double fvel_h2 = 0;
            double fvel_v2 = 0;
            double fvel_ch11 = 0;
            double fvel_ch12 = 0;
            double fdispl_a1 = 0;
            double fdispl_h1 = 0;
            double fdispl_v1 = 0;
            double fdispl_a2 = 0;
            double fdispl_h2 = 0;
            double fdispl_v2 = 0;
            double fdispl_ch11 = 0;
            double fdispl_ch12 = 0;
            double fbearing_a1 = 0;
            double fbearing_h1 = 0;
            double fbearing_v1 = 0;
            double fbearing_a2 = 0;
            double fbearing_h2 = 0;
            double fbearing_v2 = 0;
            double fbearing_ch11 = 0;
            double fbearing_ch12 = 0;
            double ftemperature_1 = 0;
            double ftemperature_2 = 0;
            double fcrestfactor_a1 = 0;
            double fcrestfactor_h1 = 0;
            double fcrestfactor_v1 = 0;
            double fcrestfactor_a2 = 0;
            double fcrestfactor_h2 = 0;
            double fcrestfactor_v2 = 0;
            double fcrestfactor_ch11 = 0;
            double fcrestfactor_ch12 = 0;
            double accel_a = 0;
            double accel_h = 0;
            double accel_v = 0;
            double accel_ch1 = 0;
            double vel_a = 0;
            double vel_h = 0;
            double vel_v = 0;
            double vel_ch1 = 0;
            double displ_a = 0;
            double displ_h = 0;
            double displ_v = 0;
            double displ_ch1 = 0;
            double bearing_a = 0;
            double bearing_h = 0;
            double bearing_v = 0;
            double bearing_ch1 = 0;
            double temperature = 0;
            double crestfactor_a = 0;
            double crestfactor_h = 0;
            double crestfactor_v = 0;
            double crestfactor_ch1 = 0;
            //string allvalue = null;
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.StoredProcedure, "select * from alarms_data where Alarm_ID ='" + sAlarmID + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        faccel_a1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["accel_a1"]), "0"));
                        faccel_a2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["accel_a2"]), "0"));
                        faccel_v1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["accel_v1"]), "0"));
                        faccel_v2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["accel_v2"]), "0"));
                        faccel_h1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["accel_h1"]), "0"));
                        faccel_h2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["accel_h2"]), "0"));
                        faccel_ch11 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["accel_ch11"]), "0"));
                        faccel_ch12 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["accel_ch12"]), "0"));

                        fvel_a1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["vel_a1"]), "0"));
                        fvel_a2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["vel_a2"]), "0"));
                        fvel_v1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["vel_v1"]), "0"));
                        fvel_v2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["vel_v2"]), "0"));
                        fvel_h1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["vel_h1"]), "0"));
                        fvel_h2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["vel_h2"]), "0"));
                        fvel_ch11 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["vel_ch11"]), "0"));
                        fvel_ch12 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["vel_ch12"]), "0"));

                        fdispl_a1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["displ_a1"]), "0"));
                        fdispl_a2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["displ_a2"]), "0"));
                        fdispl_v1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["displ_v1"]), "0"));
                        fdispl_v2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["displ_v2"]), "0"));
                        fdispl_h1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["displ_h1"]), "0"));
                        fdispl_h2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["displ_h2"]), "0"));
                        fdispl_ch11 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["displ_ch11"]), "0"));
                        fdispl_ch12 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["displ_ch12"]), "0"));

                        fbearing_a1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["bearing_a1"]), "0"));
                        fbearing_a2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["bearing_a2"]), "0"));
                        fbearing_v1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["bearing_v1"]), "0"));
                        fbearing_v2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["bearing_v2"]), "0"));
                        fbearing_h1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["bearing_h1"]), "0"));
                        fbearing_h2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["bearing_h2"]), "0"));
                        fbearing_ch11 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["bearing_ch11"]), "0"));
                        fbearing_ch12 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["bearing_ch12"]), "0"));

                        fcrestfactor_a1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["crest_factor_a1"]), "0"));
                        fcrestfactor_a2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["crest_factor_a2"]), "0"));
                        fcrestfactor_v1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["crest_factor_v1"]), "0"));
                        fcrestfactor_v2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["crest_factor_v2"]), "0"));
                        fcrestfactor_h1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["crest_factor_h1"]), "0"));
                        fcrestfactor_h2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["crest_factor_h2"]), "0"));
                        fcrestfactor_ch11 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["crest_factor_ch11"]), "0"));
                        fcrestfactor_ch12 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["crest_factor_ch12"]), "0"));

                        ftemperature_1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["temperature_1"]), "0"));
                        ftemperature_2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["temperature_2"]), "0"));

                    }
                    catch
                    {

                    }
                }

                DataTable dtt = new DataTable();
                dtt = DbClass.getdata(CommandType.Text, "Select max(pd.Data_ID) as Data_ID , pd.Point_ID,tp.Alarm_ID, p.Machine_ID,m.TrainID,t.Area_ID,a.FactoryID,max(pd.measure_time) as measure_time,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.displ_ch1,pd.crest_factor_a,pd.crest_factor_h,pd.crest_factor_v,pd.crest_factor_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.bearing_ch1 , pd.temperature from  point p inner join machine_info m on p.Machine_ID = m.Machine_ID inner join train_info t on m.TrainID = t.Train_ID inner join area_info a on t.Area_ID=a.Area_ID inner join factory_info f on a.FactoryID = f.Factory_ID left join Point_Data pd on p.Point_ID = pd.Point_ID inner join type_point tp on tp.ID=pd.Point_Type where " + query + " and tp.Alarm_ID = '" + sAlarmID + "' group by pd.Point_ID");

                double acc_a = 0;
                double acc_h = 0;
                double acc_v = 0;
                double acc_ch1 = 0;

                double ve_a = 0;
                double ve_h = 0;
                double ve_v = 0;
                double ve_ch1 = 0;

                double dis_a = 0;
                double dis_h = 0;
                double dis_v = 0;
                double dis_ch1 = 0;

                double br_a = 0;
                double br_h = 0;
                double br_v = 0;
                double br_ch1 = 0;

                double cf_a = 0;
                double cf_h = 0;
                double cf_v = 0;
                double cf_ch1 = 0;
                double tempr = 0;
                string mTime = null;
                string DataID = null;

                foreach (DataRow dr in dtt.Rows)
                {
                    try
                    {
                        mTime = Convert.ToDateTime(dr["Measure_time"]).ToString("yyyy-MM-dd HH:mm:ss");

                        DataTable dtFinal = DbClass.getdata(CommandType.Text, "Select  Point_ID,measure_time,accel_a,accel_h,accel_v,accel_ch1,vel_a,vel_h,vel_v,vel_ch1,displ_a,displ_h,displ_v,displ_ch1,crest_factor_a,crest_factor_h,crest_factor_v,crest_factor_ch1,bearing_a,bearing_h,bearing_v,bearing_ch1 , temperature from point_Data where measure_time ='" + mTime + "' and Data_ID ='" + Convert.ToString(dr["Data_ID"]) + "'");

                        foreach (DataRow dr1 in dtFinal.Rows)
                        {


                            acc_a = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["accel_a"]), "0")); ;
                            acc_h = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["accel_h"]), "0")); ;
                            acc_v = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["accel_v"]), "0")); ;
                            acc_ch1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["accel_ch1"]), "0")); ;

                            ve_a = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["vel_a"]), "0"));
                            ve_h = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["vel_h"]), "0"));
                            ve_v = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["vel_v"]), "0"));
                            ve_ch1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["vel_ch1"]), "0"));

                            dis_a = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["displ_a"]), "0"));
                            dis_h = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["displ_h"]), "0"));
                            dis_v = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["displ_v"]), "0"));
                            dis_ch1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["displ_ch1"]), "0"));

                            br_a = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["bearing_a"]), "0"));
                            br_h = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["bearing_h"]), "0"));
                            br_v = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["bearing_v"]), "0"));
                            br_ch1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["bearing_ch1"]), "0"));

                            cf_a = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["crest_factor_a"]), "0"));
                            cf_h = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["crest_factor_h"]), "0"));
                            cf_v = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["crest_factor_v"]), "0"));
                            cf_ch1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr1["crest_factor_ch1"]), "0"));
                            tempr = Convert.ToInt64(PublicClass.DefVal(Convert.ToString(dr1["temperature"]), "0"));


                            if (accel_a < acc_a)
                            {
                                accel_a = acc_a;
                            }
                            if (accel_h < acc_h)
                            {
                                accel_h = acc_h;
                            }
                            if (accel_v < acc_v)
                            {
                                accel_v = acc_v;
                            }
                            if (accel_ch1 < acc_ch1)
                            {
                                accel_ch1 = acc_ch1;
                            }
                            if (vel_a < ve_a)
                            {
                                vel_a = ve_a;
                            }
                            if (vel_h < ve_h)
                            {
                                vel_h = ve_h;
                            }
                            if (vel_v < ve_v)
                            {
                                vel_v = ve_v;
                            }
                            if (vel_ch1 < ve_ch1)
                            {
                                vel_ch1 = ve_ch1;
                            }
                            if (displ_a < dis_a)
                            {
                                displ_a = dis_a;
                            }
                            if (displ_h < dis_h)
                            {
                                displ_h = dis_h;
                            }
                            if (displ_v < dis_v)
                            {
                                displ_v = dis_v;
                            }
                            if (displ_ch1 < dis_ch1)
                            {
                                displ_ch1 = dis_ch1;
                            }
                            if (bearing_a < br_a)
                            {
                                bearing_a = br_a;
                            }
                            if (bearing_h < br_h)
                            {
                                bearing_h = br_h;
                            }
                            if (bearing_v < br_v)
                            {
                                bearing_v = br_v;
                            }
                            if (bearing_ch1 < br_ch1)
                            {
                                bearing_ch1 = br_ch1;
                            }
                            if (crestfactor_a < cf_a)
                            {
                                crestfactor_a = cf_a;
                            }
                            if (crestfactor_h < cf_h)
                            {
                                crestfactor_h = cf_h;
                            }
                            if (crestfactor_v < cf_v)
                            {
                                crestfactor_v = cf_v;
                            }
                            if (crestfactor_ch1 < cf_ch1)
                            {
                                crestfactor_ch1 = cf_ch1;
                            }
                            if (temperature < tempr)
                            {
                                temperature = tempr;
                            }
                        }
                    }
                    catch
                    {

                    }
                }

                if (dtt.Rows.Count <= 0)
                {
                    //PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.gre;
                    i = 0;
                }
                else
                {
                    //------------------ Condition For No Alarm -------------------------------------------------------//      


                    if (faccel_a1 != 0 || faccel_v1 != 0 || faccel_h1 != 0 || faccel_ch11 != 0)
                    {
                        if (accel_a < faccel_a2 && accel_v < faccel_v2 && accel_h < faccel_h2 && accel_ch1 < faccel_ch12)
                        {
                            //PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.gre;
                            i = 0;
                            PublicClass.AlarmName = "Acceleration";
                        }
                    }
                    if (fvel_a1 != 0 || fvel_v1 != 0 || fvel_h1 != 0 || fvel_ch11 != 0)
                    {
                        if (vel_a < fvel_a2 && vel_v < fvel_v2 && vel_h < fvel_h2 && vel_ch1 < fvel_ch12)
                        {
                            //PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.gre;
                            i = 0;
                            PublicClass.AlarmName = "Velocity";
                        }
                    }
                    if (fdispl_a1 != 0 || fdispl_v1 != 0 || fdispl_h1 != 0 || fdispl_ch11 != 0)
                    {
                        if (displ_a < fdispl_a2 && displ_v < fdispl_v2 && displ_h < fdispl_h2 && displ_ch1 < fdispl_ch12)
                        {
                            //PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.gre;
                            i = 0;
                            PublicClass.AlarmName = "Displacement";
                        }
                    }
                    if (fcrestfactor_a1 != 0 || fcrestfactor_v1 != 0 || fcrestfactor_h1 != 0 || fcrestfactor_ch11 != 0)
                    {
                        if (crestfactor_a < fcrestfactor_a2 && crestfactor_v < fcrestfactor_v2 && crestfactor_h < fcrestfactor_h2 && crestfactor_ch1 < fcrestfactor_ch12)
                        {
                            //PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.gre;
                            i = 0;
                            PublicClass.AlarmName = "CrestFactor";
                        }
                    }
                    if (fbearing_a1 != 0 || fbearing_v1 != 0 || fbearing_h1 != 0 || fbearing_ch11 != 0)
                    {
                        if (bearing_a < fbearing_a2 && bearing_v < fbearing_v2 && bearing_h < fbearing_h2 && bearing_ch1 < fbearing_ch12)
                        {
                            //PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.gre;
                            i = 0;
                            PublicClass.AlarmName = "Bearing";
                        }
                    }

                    //------------------ Condition For Low Alarm -------------------------------------------------------//  

                    if (faccel_a1 != 0 || faccel_v1 != 0 || faccel_h1 != 0 || faccel_ch11 != 0)
                    {

                        if ((accel_a < faccel_a1 && accel_a > faccel_a2) || (accel_v < faccel_v1 && accel_v > faccel_v2) || (accel_h < faccel_h1 && accel_h > faccel_h2) || (accel_ch1 < faccel_ch11 && accel_ch1 > faccel_ch12))
                        {
                            if (faccel_a1 != 0 || faccel_v1 != 0 || faccel_h1 != 0 || faccel_ch11 != 0)
                            {
                                //PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.yel;
                                i = 1;
                                PublicClass.AlarmName = "Acceleration";
                            }
                        }
                    }
                    if (fvel_a1 != 0 || fvel_v1 != 0 || fvel_h1 != 0 || fvel_ch11 != 0)
                    {
                        if ((vel_a < fvel_a1 && vel_a > fvel_a2) || (vel_v < fvel_v1 && vel_v > fvel_v2) || (vel_h < fvel_h1 && vel_h > fvel_ch12) || (vel_ch1 < fvel_ch11 && vel_ch1 > fvel_ch12))
                        {
                            if (fvel_a1 != 0 || fvel_v1 != 0 || fvel_h1 != 0 || fvel_ch11 != 0)
                            {
                                //PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.yel;
                                i = 1;
                                PublicClass.AlarmName = "Velocity";
                            }
                        }
                    }

                    if (fdispl_a1 != 0 || fdispl_v1 != 0 || fdispl_h1 != 0 || fdispl_ch11 != 0)
                    {
                        if ((displ_a < fdispl_a1 && displ_a > fdispl_a2) || (displ_v < fdispl_v1 && displ_v > fdispl_v2) || (displ_h < fdispl_h1 && displ_h > fdispl_h2) || (displ_ch1 < fdispl_ch11 && displ_ch1 > fdispl_ch12))
                        {
                            if (fdispl_a1 != 0 || fdispl_v1 != 0 || fdispl_h1 != 0 || fdispl_ch11 != 0)
                            {
                                //PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.yel;
                                i = 1;
                                PublicClass.AlarmName = "Displacement";
                            }
                        }
                    }

                    if (fcrestfactor_a1 != 0 || fcrestfactor_v1 != 0 || fcrestfactor_h1 != 0 || fcrestfactor_ch11 != 0)
                    {
                        if ((crestfactor_a < fcrestfactor_a1 && crestfactor_a > fcrestfactor_a2) || (crestfactor_v < fcrestfactor_v1 && crestfactor_v > fcrestfactor_v2) || (crestfactor_h < fcrestfactor_h1 && crestfactor_h > fcrestfactor_h2) || (crestfactor_ch1 < fcrestfactor_ch11 && crestfactor_ch1 > fcrestfactor_ch12))
                        {
                            if (fcrestfactor_a1 != 0 || fcrestfactor_v1 != 0 || fcrestfactor_h1 != 0 || fcrestfactor_ch11 != 0)
                            {
                                //PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.yel;
                                i = 1;
                                PublicClass.AlarmName = "CrestFactor";
                            }
                        }

                    }

                    if (fbearing_a1 != 0 || fbearing_v1 != 0 || fbearing_h1 != 0 || fbearing_ch11 != 0)
                    {
                        if ((bearing_a < fbearing_a1 && bearing_a > fbearing_a2) || (bearing_v < fbearing_v1 && bearing_v > fbearing_v2) || (bearing_h < fbearing_h1 && bearing_h > fbearing_h2) || (bearing_ch1 < fbearing_ch11 && bearing_ch1 > fbearing_ch12))
                        {
                            if (fbearing_a1 != 0 || fbearing_v1 != 0 || fbearing_h1 != 0 || fbearing_ch11 != 0)
                            {
                                //PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.yel;
                                i = 1;
                                PublicClass.AlarmName = "Bearing";
                            }
                        }
                    }
                    //else
                    //{
                    //    PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.gre;
                    //}

                    //------------------ Condition For High Alarm ---------------------------------------------//


                    if (faccel_a1 != 0 || faccel_v1 != 0 || faccel_h1 != 0 || faccel_ch11 != 0)
                    {
                        if (accel_a > faccel_a1 || accel_v > faccel_v1 || accel_h > faccel_h1 || accel_ch1 > faccel_ch11)
                        {
                            if (faccel_a1 != 0 || faccel_v1 != 0 || faccel_h1 != 0 || faccel_ch11 != 0)
                            {
                                //PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.redd;
                                i = 2;
                                PublicClass.AlarmName = "Acceleration";
                            }
                        }
                    }

                    if (fvel_a1 != 0 || fvel_v1 != 0 || fvel_h1 != 0 || fvel_ch11 != 0)
                    {
                        if (vel_a > fvel_a1 || vel_v > fvel_v1 || vel_h > fvel_h1 || vel_ch1 > fvel_ch11)
                        {
                            if (fvel_a1 != 0 || fvel_v1 != 0 || fvel_h1 != 0 || fvel_ch11 != 0)
                            {
                                //PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.redd;
                                i = 2;
                                PublicClass.AlarmName = "Velocity";
                            }

                        }
                    }

                    if (fdispl_a1 != 0 || fdispl_v1 != 0 || fdispl_h1 != 0 || fdispl_ch11 != 0)
                    {
                        if (displ_a > fdispl_a1 || displ_v > fdispl_v1 || displ_h > fdispl_h1 || displ_ch1 > fdispl_ch11)
                        {
                            if (fdispl_a1 != 0 || fdispl_v1 != 0 || fdispl_h1 != 0 || fdispl_ch11 != 0)
                            {
                                //PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.redd;
                                i = 2;
                                PublicClass.AlarmName = "Displacement";
                            }
                        }
                    }

                    if (fcrestfactor_a1 != 0 || fcrestfactor_v1 != 0 || fcrestfactor_h1 != 0 || fcrestfactor_ch11 != 0)
                    {
                        if (crestfactor_a > fcrestfactor_a1 || crestfactor_v > fcrestfactor_v1 || crestfactor_h > fcrestfactor_h1 || crestfactor_ch1 > fcrestfactor_ch11)
                        {
                            if (fcrestfactor_a1 != 0 || fcrestfactor_v1 != 0 || fcrestfactor_h1 != 0 || fcrestfactor_ch11 != 0)
                            {
                                //PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.redd;
                                i = 2;
                                PublicClass.AlarmName = "CrestFactor";
                            }
                        }

                    }

                    if (fbearing_a1 != 0 || fbearing_v1 != 0 || fbearing_h1 != 0 || fbearing_ch11 != 0)
                    {
                        if (bearing_a > fbearing_a1 || bearing_v > fbearing_v1 || bearing_h > fbearing_h1 || bearing_ch1 > fbearing_ch11)
                        {
                            if (fbearing_a1 != 0 || fbearing_v1 != 0 || fbearing_h1 != 0 || fbearing_ch11 != 0)
                            {
                                //PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.redd;
                                i = 2;
                                PublicClass.AlarmName = "Bearing";
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return i;
        }

        public Image setflag(string Query)
        {
            try
            {
                PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.gre;
                int i = 0;
                DataTable dtt = new DataTable();
                dtt = DbClass.getdata(CommandType.Text, "select distinct  alarm_id from v_AllRecord  where " + Query + " and Alarm_ID <> '' ");
                foreach (DataRow dr in dtt.Rows)
                {
                    if (i == 2)
                    {
                        PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.redd;
                    }
                    else if (i == 1)
                    {
                        PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.yel;

                        i = checkValueForFlagGenerate(ids, PublicClass.DefVal(Convert.ToString(dr["alarm_id"]), "0"), i);

                        if (i == 2)
                        {
                            PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.redd;
                        }
                        else
                        {
                            PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.yel;
                        }
                    }
                    else if (i == 0)
                    {
                        i = checkValueForFlagGenerate(ids, PublicClass.DefVal(Convert.ToString(dr["alarm_id"]), "0"), i);
                        if (i == 2)
                        {
                            PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.redd;
                        }
                        else if (i == 1)
                        {
                            PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.yel;
                        }
                        else
                        {
                            PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.gre;
                        }
                    }
                }
            }
            catch { }
            return PublicClass.FAlarmImage;
        }

        private void AreaInfo_Leave(object sender, EventArgs e)
        {
            if (sNodeType == "Area" && Convert .ToString (txtareaname.Text).Trim ()!="")
            {
                DataTable dt = new DataTable();
                DbClass.executequery(CommandType.Text, "update  area_info set name = '" + txtareaname.Text + "' , Description = '" + txtareadetail.Text + "' where area_id = '" + Convert.ToString(txtareaid.Text).Trim() + "' ");
                trlPlantManger.FocusedNode.SetValue(2, txtareaname.Text);
            }        
          
        }

        private void TabTrainInfo_Leave(object sender, EventArgs e)
        {
            if (sNodeType == "Train" && Convert.ToString(txttraininfoname.Text).Trim() != "")
            {
                DataTable dt = new DataTable();
                //Train_ID,Name,Description,Factory_ID,Area_ID from train_info
                DbClass.executequery(CommandType.Text, "update  train_info set name = '" + txttraininfoname.Text + "' , Description = '" + txttraindetail.Text + "' where Train_ID = '" + Convert.ToString(txttrainid.Text).Trim() + "' ");
                trlPlantManger.FocusedNode.SetValue(2, txttraininfoname.Text);
            }           
          
        }

        private void TabMachineInfo_Leave(object sender, EventArgs e)
        {
            if (sNodeType == "Machine" && Convert.ToString(txtmachinename.Text).Trim() != "")
            {
                DbClass.executequery(CommandType.Text, "update  machine_info set name = '" + txtmachinename.Text + "' , Description = '" + txtmachinedetail.Text + "',RPM_Driven ='" + PublicClass.DefVal(Convert.ToString(txtMRPM.Text).Trim(), "0") + "',PulseRev ='" + PublicClass.DefVal(Convert.ToString(txtpulserev.Text).Trim(), "0") + "' where Machine_ID = '" + Convert.ToString(txtmachineid.Text).Trim() + "' ");
                trlPlantManger.FocusedNode.SetValue(2, txtmachinename.Text);
            }
        }

        string MachineName="Machine";

        private void trlPlantManger_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                sNodeType = (string)trlPlantManger.FocusedNode.GetDisplayText(10);
                PublicClass.SFactoryID = (string)trlPlantManger.FocusedNode.GetDisplayText(4);
                PublicClass.SAreaID = (string)trlPlantManger.FocusedNode.GetDisplayText(5);
                PublicClass.STrainID = (string)trlPlantManger.FocusedNode.GetDisplayText(6);
                PublicClass.SMachineID = (string)trlPlantManger.FocusedNode.GetDisplayText(7);
                PublicClass.SPointID = (string)trlPlantManger.FocusedNode.GetDisplayText(8);
                PublicClass.ssNodeType = sNodeType;
                visbilty(sNodeType);
                 MachineName = (string)trlPlantManger.FocusedNode.GetDisplayText(2);
                 RecordFill(sNodeType);
                 dgv_pointname =null; dgv_pointtype = null;
                 if (PublicClass.SPointID != "0")
                 {
                     try
                     {
                         DataTable dt = DbClass.getdata(CommandType.Text, "Select Data_ID,point_name,point_type from point_data where Point_ID = '" + PublicClass.SPointID + "' and Measure_time IN( Select Max(Measure_time) from point_Data where Point_ID = '" + PublicClass.SPointID + "');");
                         PublicClass.Data_ID = Convert.ToString(dt.Rows[0]["Data_ID"]);
                         dgv_pointname = Convert.ToString(dt.Rows[0]["Point_name"]);
                         dgv_pointtype = Convert.ToString(dt.Rows[0]["Point_Type"]);
                     }
                     catch { }
                 }                
            }
            catch
            {
                filltreelist();              
            }
        }

        public void mainnode()
        {
            try
            {
                sNodeType = (string)trlPlantManger.FocusedNode.GetDisplayText(10);
                PublicClass.SFactoryID = (string)trlPlantManger.FocusedNode.GetDisplayText(4);
                PublicClass.SAreaID = (string)trlPlantManger.FocusedNode.GetDisplayText(5);
                PublicClass.STrainID = (string)trlPlantManger.FocusedNode.GetDisplayText(6);
                PublicClass.SMachineID = (string)trlPlantManger.FocusedNode.GetDisplayText(7);
                PublicClass.SPointID = (string)trlPlantManger.FocusedNode.GetDisplayText(8);
                PublicClass.ssNodeType = sNodeType;
                MachineName = (string)trlPlantManger.FocusedNode.GetDisplayText(2);
                RecordFill(sNodeType);
                visbilty(sNodeType);
                if (PublicClass.SPointID != "0")
                {
                    try
                    {
                        DataTable dt = DbClass.getdata(CommandType.Text, "Select Data_ID from point_data where Point_ID = '" + PublicClass.SPointID + "' and Measure_time IN( Select Max(Measure_time) from point_Data where Point_ID = '" + PublicClass.SPointID + "');");
                        PublicClass.Data_ID = Convert.ToString(dt.Rows[0]["Data_ID"]);                     
                    }
                    catch { }
                }

            }
            catch
            {
                filltreelist();
            }
        
        }
       
        public void RecordFill(string stype)
        {
            if (stype.Trim() == "Plant")
            {
                ShowFactoryDetail();
            }
            else if (stype.Trim() == "Area")
            {
                ShowAreaDetail();
            }
            else if (stype.Trim() == "Train")
            {
                ShowTrainDetail();
            }
            else if (stype.Trim() == "Machine")
            {
                ShowMachineDetail();
            }
            else if (stype.Trim() == "Point")
            {
                Fill_Cmb_Point_type();
                ShowPointDetail();
                string sNode = "pd.Point_ID = " + PublicClass.SPointID;
                applyallchecks(sNode);
            }
        }

        int pTypeID, pSchedule;

        public void applyallchecks(string sNodeID)
        {
            try
            {
                DataTable dt1 = new DataTable();
                dt1 = DbClass.getdata(CommandType.Text, "select distinct pd.Point_Type as PointTypeID from point p inner join Point_Data pd on p.Point_ID = pd.Point_ID left join type_point tp on tp.ID=pd.Point_Type where p.Point_ID = '" + PublicClass.SPointID + "'");
                if (dt1.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = DbClass.getdata(CommandType.Text, "Select pd.Point_ID,p.Machine_ID,m.TrainID,t.Area_ID,a.FactoryID ,pd.Point_Type as PointTypeID , p.PointSchedule as PointSchedule from  point p right join machine_info m on p.Machine_ID = m.Machine_ID right join train_info t on m.TrainID = t.Train_ID right join area_info a on t.Area_ID=a.Area_ID right join factory_info f on a.FactoryID = f.Factory_ID left join Point_Data pd on p.Point_ID = pd.Point_ID inner join type_point tp on tp.ID=pd.Point_Type  where " + sNodeID + " ");

                    foreach (DataRow dr in dt.Rows)
                    {
                        pTypeID = Convert.ToInt32(dr["PointTypeID"]);
                        pSchedule = Convert.ToInt32(dr["PointSchedule"]);
                    }
                    if (dt.Rows.Count > 0)
                    {
                        if (pTypeID != 0)
                        {
                            CmbPointType.Enabled = false;
                        }
                        else
                        {
                            CmbPointType.Enabled = true;
                        }

                    }
                    else
                    {
                        CmbPointType.Enabled = true;
                    }
                }
                else
                {
                    CmbPointType.Enabled = true;
                }
            }
            catch
            {

            }
        }

        private void ShowFactoryDetail()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select distinct factory_id,  name ,Description  from factory_info where factory_id='" + PublicClass.SFactoryID.Trim() + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    TxtFactoryId.Text = Convert.ToString(dr["factory_id"]);
                    txtfactoryname.Text = Convert.ToString(dr["name"]);
                    TxtDetail.Text = Convert.ToString(dr["Description"]);
                }
            }

            catch { }
        }

        private void ShowAreaDetail()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select Area_ID,name,Description from area_info where Area_ID='" + PublicClass.SAreaID.Trim() + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    txtareaid.Text = Convert.ToString(dr["Area_ID"]);
                    txtareaname.Text = Convert.ToString(dr["name"]);
                    txtareadetail.Text = Convert.ToString(dr["Description"]);
                }
            }

            catch { }
        }

        private void ShowTrainDetail()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select Train_ID,name,Description,area_id from train_info  where Train_ID='" + PublicClass.STrainID.Trim() + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    txttrainid.Text = Convert.ToString(dr["Train_ID"]);
                    txttraininfoname.Text = Convert.ToString(dr["name"]);
                    txttraindetail.Text = Convert.ToString(dr["Description"]);
                }
            }

            catch { }
        }

        private void ShowMachineDetail()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select Machine_ID,name,Description,RPM_Driven,PulseRev  from machine_info  where Machine_ID='" + PublicClass.SMachineID.Trim() + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    txtmachineid.Text = Convert.ToString(dr["Machine_ID"]);
                    txtmachinename.Text = Convert.ToString(dr["name"]);
                    txtmachinedetail.Text = Convert.ToString(dr["Description"]);
                    txtMRPM.Text = Convert.ToString(dr["RPM_Driven"]);
                    txtpulserev.Text = Convert.ToString(dr["PulseRev"]);
                }
            }
            catch { }
        }

        public string countdays(DateTime ToYear, DateTime FromYear)
        {
            string count = null;
            try
            {
                int Years = ToYear.Year - FromYear.Year;

                int month = ToYear.Month - FromYear.Month;

                int TotalMonths = (Years * 12) + month;

                TimeSpan objTimeSpan = ToYear - FromYear;
                //Total Hours  
                double TotalHours = objTimeSpan.TotalHours;
                //Total Minutes  
                double TotalMinutes = objTimeSpan.TotalMinutes;
                //Total Seconds  
                double TotalSeconds = objTimeSpan.TotalSeconds;
                //Total Mile Seconds  
                double TotalMileSeconds = objTimeSpan.TotalMilliseconds;

                //Assining values to td tags  
                double Days = Convert.ToDouble(objTimeSpan.TotalDays);
                count = Convert.ToString(Days);
            }
            catch { }
            return count;
        }

        string PTcheck = string.Empty;

        private void ShowPointDetail()
        {
            try
            {
                pbDataDue.BackColor = Color.Green;
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "SELECT p.Point_ID,p.pointname, p.PointDesc,p.PointType_ID , p.DataSchedule , max(pd.Measure_time) as Measure_time FROM POINT p inner join point_data pd  on p.Point_ID = pd.Point_ID where p.Point_ID='" + PublicClass.SPointID.Trim() + "' group by pd.point_id");

                DateTime currentDate = new DateTime();
                currentDate = DateTime.Today;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string dtSchedule = Convert.ToString(dr["DataSchedule"]);
                        string LastDate = Convert.ToString(dr["Measure_time"]);

                        DateTime FromYear = Convert.ToDateTime(currentDate);
                        DateTime ToYear = Convert.ToDateTime(LastDate);
                        string DueD = countdays(FromYear, ToYear);
                        double DueDays = Math.Round(Convert.ToDouble(DueD), 0);
                        int Difference = 0;
                        if (dtSchedule != "")
                        {
                            try
                            {
                                string[] ssize = dtSchedule.Split();
                                txtDataSchedule.Text = ssize[0];
                                cmbDaysSelection.Text = Convert.ToString(ssize[1]);
                                int TotalDays = 0;
                                switch (ssize[1])
                                {
                                    case "Days":
                                        TotalDays = Convert.ToInt32(ssize[0]);
                                        break;
                                    case "Weeks":
                                        TotalDays = 7 * Convert.ToInt32(ssize[0]);
                                        break;
                                    case "Months":
                                        TotalDays = 30 * Convert.ToInt32(ssize[0]);
                                        break;
                                    case "Years":
                                        TotalDays = 365 * Convert.ToInt32(ssize[0]);
                                        break;
                                }
                                if (DueDays >= TotalDays)
                                {
                                    pbDataDue.BackColor = Color.Red;
                                }
                                else
                                {
                                    pbDataDue.BackColor = Color.Green;
                                }
                            }
                            catch { }
                        }
                        else
                        {
                            txtDataSchedule.Text = "7";
                            cmbDaysSelection.Text = Convert.ToString("Days");
                            Difference = Convert.ToInt32(currentDate) - (Convert.ToInt32(LastDate) + 7);

                            if (DueDays >= 7.0)
                            {
                                pbDataDue.BackColor = Color.Red;
                            }
                            else
                            {
                                pbDataDue.BackColor = Color.Green;
                            }
                        }
                        txtpointid.Text = Convert.ToString(dr["Point_ID"]);
                        txtpointname1.Text = Convert.ToString(dr["pointname"]);
                        txtpointdetail1.Text = Convert.ToString(dr["PointDesc"]);
                        PublicClass.SPointTypeId = Convert.ToString(dr["PointType_ID"]);
                        CmbPointType.SelectedValue = Convert.ToString(dr["PointType_ID"]);

                    }
                }
                else
                {
                    dt = DbClass.getdata(CommandType.Text, "SELECT p.Point_ID,p.pointname, p.PointDesc,p.PointType_ID , p.DataSchedule FROM POINT p where p.Point_ID='"+PublicClass.SPointID+"'");
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            string dtSchedule = Convert.ToString(dr["DataSchedule"]);
                            if (dtSchedule != "")
                            {
                                try
                                {
                                    string[] ssize = dtSchedule.Split();
                                    txtDataSchedule.Text = ssize[0];
                                    cmbDaysSelection.Text = Convert.ToString(ssize[1]);
                                }
                                catch { }

                            }
                            else
                            {
                                txtDataSchedule.Text = "7";
                                cmbDaysSelection.Text = Convert.ToString("Days");
                            }
                            txtpointid.Text = Convert.ToString(dr["Point_ID"]);
                            txtpointname1.Text = Convert.ToString(dr["pointname"]);
                            txtpointdetail1.Text = Convert.ToString(dr["PointDesc"]);
                            PublicClass.SPointTypeId = Convert.ToString(dr["PointType_ID"]);
                            CmbPointType.SelectedValue = Convert.ToString(dr["PointType_ID"]);
                        }
                    }
                    else
                    {
                        txtDataSchedule.Text = "7";
                        cmbDaysSelection.Text = Convert.ToString("Days");
                    }
                }
               
            }

            catch { }
        }

        public void Blank()
        {
            TxtFactoryId.Text = "";
            txtfactoryname.Text = "";
            TxtDetail.Text = "";

            txtareaid.Text = "";
            txtareaname.Text = "";
            txtareadetail.Text = "";

            txttrainid.Text = "";
            txttraininfoname.Text = "";
            txttraindetail.Text = "";

            txtmachineid.Text = "";
            txtmachinename.Text = "";
            txtmachinedetail.Text = "";
            txtpointid.Text = "";
            txtpointname1.Text = "";
            txtpointdetail1.Text = "";
        }

        public void MoveFirst()
        {
            try
            {
                if (trlPlantManger.Nodes.Count > 0)
                    trlPlantManger.MoveFirst();
                mainnode();
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        public void MoveLast()
        {
            try
            {
                if (trlPlantManger.Nodes.Count > 0)
                    trlPlantManger.MoveLast();
                mainnode();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        public void MoveNext()
        {
            try
            {
                if (trlPlantManger.Nodes.Count > 0)
                    trlPlantManger.MoveNext();
                mainnode();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        public void MovePrevious()
        {
            try
            {
                if (trlPlantManger.Nodes.Count > 0)
                    trlPlantManger.MovePrev();
                 mainnode();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void DGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try { }
            catch { }
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void btnopen_Click(object sender, EventArgs e)
        {
            Image imgImage = null;
            string mPicID = null;
            try
            {
                using (OpenFileDialog objOpenImage = new OpenFileDialog())
                {
                    objOpenImage.Filter = "Image Files|*.BMP;*.JPG;*.JPEG";
                    objOpenImage.ShowDialog();

                    if (objOpenImage.FileName != null)
                    {
                        imgImage = Image.FromFile(objOpenImage.FileName);
                        m_imgPictures = new ImageList();
                        m_imgPictures.Images.Add(imgImage);
                        string[] sarrSplitedName = objOpenImage.FileName.Split(new char[] { '\\' });

                        string V_FullPath = objOpenImage.FileName;
                        imgImage = resizeImage(imgImage, new Size(20, 20));
                        trlImages.StateImageList = m_imgPictures;

                        //trlImages.StateImageList = m_imgPictures;


                        string sImageName = sarrSplitedName[sarrSplitedName.Length - 1];
                        if (sImageName != null)
                        {

                            // TreeListNode trlnImageNode = trlImages.AppendNode(new object[] {imgImage, sImageName} , null);
                            trlImages.AppendNode(new object[] { imgImage, sImageName, V_FullPath }, null);
                        }
                        pePictures.Image = Image.FromFile(objOpenImage.FileName);

                        string sStringToInsert = objOpenImage.FileName.Replace('\\', '-');

                        DataTable dtm = new DataTable();
                        dtm = DbClass.getdata(CommandType.Text, "Select MachineID from  machine_pic");
                        foreach (DataRow dr in dtm.Rows)
                        {
                            mPicID = Convert.ToString(dr["MachineID"]);
                            DbClass.executequery(CommandType.Text, "update machine_pic set Description='unselected' where MachineID ='" + mPicID + "'");
                        }

                        DbClass.executequery(CommandType.Text, "insert into machine_pic(picture,MachineID,Description) values('" + sStringToInsert + "','" + PublicClass.SMachineID + "','selected')");
                    }
                }

            }


            catch
            {

            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string sImagePath = null;
            string sNewImagePath = null;
            try
            {
                if (trlImages.FocusedNode != null)
                {
                    if (MessageBox.Show("Are you sure you want to delete the Image", "Delete Image", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        sImagePath = (string)trlImages.FocusedNode.GetDisplayText(2);
                        sNewImagePath = sImagePath.Replace('\\', '-');
                        DbClass.executequery(CommandType.Text, "delete from Machine_Pic where Picture='" + sNewImagePath + "' and MachineID='" + PublicClass.SMachineID + "'");

                    }

                    pePictures.Image = null;
                    RetrivetrlImages();
                }
            }

            catch
            {

            }
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            m_objCompleteImage = new frmCompleteImage();
            try
            {
                if (trlImages.Nodes.Count > 0)
                {

                    DbClass.executequery(CommandType.Text, "update Machine_Pic set Description='unselected' where MachineID ='" + PublicClass.SMachineID + "'");

                    
                    string sSelected = trlImages.FocusedNode.GetDisplayText(2).Replace('\\', '-');

                    DbClass.executequery(CommandType.Text, "update Machine_Pic set Description='selected' where MachineID='" + PublicClass.SMachineID + "' and Picture='" + sSelected + "'");

                }
                m_objCompleteImage.SetImage = Image.FromFile(trlImages.FocusedNode.GetDisplayText(2));
                string[] sarrImageName = (trlImages.FocusedNode.GetDisplayText(2)).Split(new char[] { '\\' });
                string sImageName = sarrImageName[sarrImageName.Length - 1];
                m_objCompleteImage.ImageName = sImageName;
                m_objCompleteImage.ShowDialog();
            }

            catch
            {

            }
        }

        public void RetrivetrlImages()
        {
            try
            {
                string sNode = null;
                pePictures.Image = null;
                pePictures.Invalidate();
                TreeListNode parent = null;
                DataTable dtt = new DataTable();
                dtt = DbClass.getdata(CommandType.Text, "Select Picture from machine_pic where MachineID = '" + PublicClass.SMachineID + "'");
                trlImages.Nodes.Clear();
                foreach (DataRow dr in dtt.Rows)
                {
                    string imagename = Convert.ToString(dr["Picture"]);
                    string[] sarrSplitedName = imagename.Split(new char[] { '-' });
                    string sImageName = sarrSplitedName[sarrSplitedName.Length - 1];
                    string insertImage = Convert.ToString(dr["Picture"]).Replace('-', '\\');
                    string V_FullPath = insertImage;
                    Image imgImage2 = Image.FromFile(insertImage);
                    imgImage2 = resizeImage(imgImage2, new Size(20, 20));
                    parent = trlImages.AppendNode(new object[] { imgImage2, sImageName, V_FullPath }, null);

                }
                trlImages.SetFocusedNode(parent);
            }
            catch { }
        }

        private void CtrTab_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            string stabIndex = Convert.ToString(CtrTab.SelectedTabPage.Text.Trim());
            try
            {
                switch (stabIndex)
                {
                    case "Images":
                        {
                            RetrivetrlImages();
                            break;
                        }
                    case "Bearing":
                        {                            
                            TabGraph.PageVisible = false;
                            fillDefaultData();
                            showFFreqdata();
                            break;
                        }
                    case "Data":
                        {
                            TabGraph.PageVisible = false;
                            Fill_Dgv_Data();                           
                            break;
                        }
                    case "Machine Notes":
                        {
                            if (sNodeType == "Machine")
                            {
                                Fill_DgvMachine();
                            }
                            break;
                        }
                    case "OverAll":
                        {
                            if (sNodeType == "Point")
                            {

                                CtrDir.SelectedTabPageIndex = 0;
                                ctrdir = "_a";
                                xtroverall.SelectedTabPageIndex = 0;
                                ctroverall = "accel";
                                rbbargraph.Checked = true;
                                barchrt();
                            }
                            break;
                        }
                }
            }
            catch
            {
            }
        }

        public void Fill_DgvMachine()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select * from machine_record where machine_id='" + PublicClass.SMachineID.Trim() + "' ");
                DgvMachine.Rows.Clear();
                int v = 0;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        DgvMachine.Rows.Add();
                        DgvMachine.Rows[v].Cells["col_id"].Value = Convert.ToString(dr["ID"]);
                        DgvMachine.Rows[v].Cells["G_Date"].Value = Convert.ToString(dr["date"]);
                        DgvMachine.Rows[v].Cells["G_Machine"].Value = MachineName;
                        DgvMachine.Rows[v].Cells["G_Cmb_Note"].Value = Convert.ToInt32(dr["Note_ID"]);
                        v = v + 1;
                    }
                }
            }
            catch { }
        }
               
        public void Fill_Dgv_Data()
        {
            try
            {                
                DataTable dt = new DataTable();
                int S = 0;
                Dgv_data.Rows.Clear();
                if (PublicClass.currentInstrument == "SKF/DI")
                {
                    dt = DbClass.getdata(CommandType.Text, "select  distinct  a.data_id,a.Point_ID,Measure_time ,a.Manual,di.ChannelType, a.accel_a,a.accel_h,a.accel_v,accel_ch1,vel_a,vel_h,vel_v,vel_ch1,displ_a,displ_h,displ_v,displ_ch1,crest_factor_a,crest_factor_h,crest_factor_v,crest_factor_ch1,bearing_a,bearing_h,bearing_v,bearing_ch1,ordertrace_a_real,ordertrace_h_real,ordertrace_v_real,ordertrace_ch1_real,ordertrace_a_image,ordertrace_h_image,ordertrace_v_image,ordertrace_ch1_image,ordertrace_rpm,temperature,notes1 ,notes2  ,di.Type_Unit, Counter from point_data a inner join point pp on pp.Point_ID=a.Point_ID left join type_point tp on tp.id=pp.PointType_ID left join di_point di on di.Type_ID=tp.ID  where a.Point_ID= '" + PublicClass.SPointID + "' ");
                    OnePhaseAmplitude.Visible = true; OnePhaseAngle.Visible = true; TwoPhaseAmplitude.Visible = true; TwoPhaseAngle.Visible = true; ThirdPhaseAmplitude.Visible = true; ThirdPhaseAngle.Visible = true; FourPhaseAmplitude.Visible = true; FourPhaseAngle.Visible = true; FivePhaseAmplitude.Visible = true; FivePhaseAngle.Visible = true; SixPhaseAmplitude.Visible = true; SixPhaseAngle.Visible = true; SevenPhaseAmplitude.Visible = true; SevenPhaseAngle.Visible = true; EightPhaseAmplitude.Visible = true; EightPhaseAngle.Visible = true;
                    ColAacc.Visible = true; ColHacc.Visible = true; ColVacc.Visible = true; Ch1Acc1.Visible = false;
                    ColAvel.Visible = true; ColHvel.Visible = true; ColVvel.Visible = true; Ch1Vel1.Visible = false;
                    ColAdisp.Visible = true; ColHdisp.Visible = true; ColVdisp.Visible = true; Ch1Disp1.Visible = false;
                    ColAbear.Visible = false; ColHbear.Visible = false; ColVbear.Visible = false; Ch1Bear1.Visible = false;
                    ColTemp.Visible = false; ColAcrest.Visible = false; ColHcrest.Visible = false; ColVcrest.Visible = false;
                    Ch1CF1.Visible = false; OTVR1.Visible = false; OTVI1.Visible = false; OTCH1I1.Visible = false;
                    OTCH1R1.Visible = false; OTRPM.Visible = false; OTAR1.Visible = false; OTAI1.Visible = false;
                    OTHR1.Visible = false; OTHI1.Visible = false; DGA_Phase.Visible = false; DGH_Phase.Visible = false;
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Dgv_data.Rows.Add();                            
                            Dgv_data.Rows[S].Cells["ColID"].Value = Convert.ToDateTime(dr["Measure_time"]);
                            if (Convert.ToString(dr["Type_Unit"]) == "0" || Convert.ToString(dr["Type_Unit"]) == "23")
                            {
                                Dgv_data.Rows[S].Cells["ColAacc"].Value = Convert.ToString(dr["accel_a"]);
                                Dgv_data.Rows[S].Cells["ColHacc"].Value = Convert.ToString(dr["accel_h"]);
                                Dgv_data.Rows[S].Cells["ColVacc"].Value = Convert.ToString(dr["accel_v"]);
                                if (Convert.ToString(dr["ChannelType"]) == "3" || Convert.ToString(dr["ChannelType"]) == "4" || Convert.ToString(dr["ChannelType"]) == "2")
                                {
                                    Ch1Acc1.Visible = true;
                                    Ch1Acc1.HeaderText = "CH2(acc)";
                                    Dgv_data.Rows[S].Cells["Ch1Acc1"].Value = Convert.ToString(dr["accel_ch1"]);
                                }
                                ColAvel.Visible = false; ColHvel.Visible = false; ColVvel.Visible = false;
                                ColAdisp.Visible = false; ColHdisp.Visible = false; ColVdisp.Visible = false;
                            }

                            else if (Convert.ToString(dr["Type_Unit"]) == "1" || Convert.ToString(dr["Type_Unit"]) == "2" || Convert.ToString(dr["Type_Unit"]) == "5" || Convert.ToString(dr["Type_Unit"]) == "6" || Convert.ToString(dr["Type_Unit"]) == "24" || Convert.ToString(dr["Type_Unit"]) == "26")
                            {
                                Dgv_data.Rows[S].Cells["ColAvel"].Value = Convert.ToString(dr["vel_a"]);
                                Dgv_data.Rows[S].Cells["ColHvel"].Value = Convert.ToString(dr["vel_h"]);
                                Dgv_data.Rows[S].Cells["ColVvel"].Value = Convert.ToString(dr["vel_v"]);
                                if (Convert.ToString(dr["ChannelType"]) == "3" || Convert.ToString(dr["ChannelType"]) == "4" || Convert.ToString(dr["ChannelType"]) == "2")
                                {
                                    Ch1Vel1.Visible = true;
                                    Ch1Vel1.HeaderText = "CH2(vel)";
                                    Dgv_data.Rows[S].Cells["Ch1Vel1"].Value = Convert.ToString(dr["accel_ch1"]);
                                }
                                ColAacc.Visible = false; ColHacc.Visible = false; ColVacc.Visible = false;
                                ColAdisp.Visible = false; ColHdisp.Visible = false; ColVdisp.Visible = false;
                            }

                            else if (Convert.ToString(dr["Type_Unit"]) == "3" || Convert.ToString(dr["Type_Unit"]) == "4" || Convert.ToString(dr["Type_Unit"]) == "7" || Convert.ToString(dr["Type_Unit"]) == "8" || Convert.ToString(dr["Type_Unit"]) == "9" || Convert.ToString(dr["Type_Unit"]) == "10" || Convert.ToString(dr["Type_Unit"]) == "26" || Convert.ToString(dr["Type_Unit"]) == "27")
                            {
                                Dgv_data.Rows[S].Cells["ColAdisp"].Value = Convert.ToString(dr["displ_a"]);
                                Dgv_data.Rows[S].Cells["ColHdisp"].Value = Convert.ToString(dr["displ_h"]);
                                Dgv_data.Rows[S].Cells["ColVdisp"].Value = Convert.ToString(dr["displ_v"]);
                                if (Convert.ToString(dr["ChannelType"]) == "3" || Convert.ToString(dr["ChannelType"]) == "4" || Convert.ToString(dr["ChannelType"]) == "2")
                                {
                                    Ch1Disp1.Visible = true;
                                    Ch1Disp1.HeaderText = "CH2(displ)";
                                    Dgv_data.Rows[S].Cells["Ch1Disp1"].Value = Convert.ToString(dr["accel_ch1"]);
                                }
                                ColAacc.Visible = false; ColHacc.Visible = false; ColVacc.Visible = false;
                                ColAvel.Visible = false; ColHvel.Visible = false; ColVvel.Visible = false;
                            }

                            string Manual = Convert.ToString(dr["manual"]);
                            if (Manual != null || Manual != " ")
                            {
                                try
                                {
                                    string[] manual1 = Manual.Split(new char[] { '|', ',','?'});
                                    Dgv_data.Rows[S].Cells["OnePhaseAmplitude"].Value = manual1[0] + "," + manual1[17];
                                    Dgv_data.Rows[S].Cells["OnePhaseAngle"].Value = manual1[1] + "," + manual1[18];
                                    Dgv_data.Rows[S].Cells["TwoPhaseAmplitude"].Value = manual1[2] + "," + manual1[19];
                                    Dgv_data.Rows[S].Cells["TwoPhaseAngle"].Value = manual1[3] + "," + manual1[20];
                                    Dgv_data.Rows[S].Cells["ThirdPhaseAmplitude"].Value = manual1[4] + "," + manual1[21];
                                    Dgv_data.Rows[S].Cells["ThirdPhaseAngle"].Value = manual1[5] + "," + manual1[22];
                                    Dgv_data.Rows[S].Cells["FourPhaseAmplitude"].Value = manual1[6] + "," + manual1[23];
                                    Dgv_data.Rows[S].Cells["FourPhaseAngle"].Value = manual1[7] + "," + manual1[24];
                                    Dgv_data.Rows[S].Cells["FivePhaseAmplitude"].Value = manual1[8] + "," + manual1[25];
                                    Dgv_data.Rows[S].Cells["FivePhaseAngle"].Value = manual1[9] + "," + manual1[26];
                                    Dgv_data.Rows[S].Cells["SixPhaseAmplitude"].Value = manual1[10] + "," + manual1[27];
                                    Dgv_data.Rows[S].Cells["SixPhaseAngle"].Value = manual1[11] + "," + manual1[28];
                                    Dgv_data.Rows[S].Cells["SevenPhaseAmplitude"].Value = manual1[12] + "," + manual1[29];
                                    Dgv_data.Rows[S].Cells["SevenPhaseAngle"].Value = manual1[13] + "," + manual1[30];
                                    Dgv_data.Rows[S].Cells["EightPhaseAmplitude"].Value = manual1[14] + "," + manual1[31];
                                    Dgv_data.Rows[S].Cells["EightPhaseAngle"].Value = manual1[15] + "," + manual1[32];
                                }
                                catch { }
                            }

                            Dgv_data.Rows[S].Cells["colCounter"].Value = Convert.ToInt32(dr["data_id"]);
                            Dgv_data.Rows[S].Cells["ColNote1"].Value = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["notes1"]), "0"));
                            Dgv_data.Rows[S].Cells["ColNote2"].Value = retunNote2(Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["notes2"]), "0")));
                            S = S + 1;
                        }
                    }
                }
                else
                {
                    dt = DbClass.getdata(CommandType.Text, "select  distinct  a.data_id,a.Point_ID,Measure_time , a.accel_a,a.accel_h,a.accel_v,accel_ch1,vel_a,vel_h,vel_v,vel_ch1,displ_a,displ_h,displ_v,displ_ch1,crest_factor_a,crest_factor_h,crest_factor_v,crest_factor_ch1,bearing_a,bearing_h,bearing_v,bearing_ch1,ordertrace_a_real,ordertrace_h_real,ordertrace_v_real,ordertrace_ch1_real,ordertrace_a_image,ordertrace_h_image,ordertrace_v_image,ordertrace_ch1_image,ordertrace_rpm,temperature,notes1 ,notes2  , Counter from point_data a  where a.Point_ID= '" + PublicClass.SPointID + "' ");
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Dgv_data.Rows.Add();
                            Dgv_data.Rows[S].Cells["ColID"].Value = Convert.ToDateTime(dr["Measure_time"]);
                            Dgv_data.Rows[S].Cells["ColAacc"].Value = Convert.ToString(dr["accel_a"]);
                            Dgv_data.Rows[S].Cells["ColHacc"].Value = Convert.ToString(dr["accel_h"]);
                            Dgv_data.Rows[S].Cells["ColVacc"].Value = Convert.ToString(dr["accel_v"]);
                            Dgv_data.Rows[S].Cells["Ch1Acc1"].Value = Convert.ToString(dr["accel_ch1"]);

                            Dgv_data.Rows[S].Cells["ColAvel"].Value = Convert.ToString(dr["vel_a"]);
                            Dgv_data.Rows[S].Cells["ColHvel"].Value = Convert.ToString(dr["vel_h"]);
                            Dgv_data.Rows[S].Cells["ColVvel"].Value = Convert.ToString(dr["vel_v"]);
                            Dgv_data.Rows[S].Cells["Ch1Vel1"].Value = Convert.ToString(dr["vel_ch1"]);
                            Dgv_data.Rows[S].Cells["ColAdisp"].Value = Convert.ToString(dr["displ_a"]);
                            Dgv_data.Rows[S].Cells["ColHdisp"].Value = Convert.ToString(dr["displ_h"]);
                            Dgv_data.Rows[S].Cells["ColVdisp"].Value = Convert.ToString(dr["displ_v"]);
                            Dgv_data.Rows[S].Cells["Ch1Disp1"].Value = Convert.ToString(dr["displ_ch1"]);

                            //n.Note  'Note',Note_ID ,n.Date 'NoteDate'
                            Dgv_data.Rows[S].Cells["ColAbear"].Value = Convert.ToString(dr["bearing_a"]);
                            Dgv_data.Rows[S].Cells["ColHbear"].Value = Convert.ToString(dr["bearing_h"]);
                            Dgv_data.Rows[S].Cells["ColVbear"].Value = Convert.ToString(dr["bearing_v"]);
                            Dgv_data.Rows[S].Cells["Ch1Bear1"].Value = Convert.ToString(dr["bearing_ch1"]);
                            Dgv_data.Rows[S].Cells["ColTemp"].Value = Convert.ToString(dr["temperature"]);
                            Dgv_data.Rows[S].Cells["ColAcrest"].Value = Convert.ToString(dr["crest_factor_a"]);
                            Dgv_data.Rows[S].Cells["ColHcrest"].Value = Convert.ToString(dr["crest_factor_h"]);
                            Dgv_data.Rows[S].Cells["ColVcrest"].Value = Convert.ToString(dr["crest_factor_v"]);
                            Dgv_data.Rows[S].Cells["Ch1CF1"].Value = Convert.ToString(dr["crest_factor_ch1"]);
                            Dgv_data.Rows[S].Cells["OTVR1"].Value = Convert.ToString(dr["ordertrace_v_real"]);
                            Dgv_data.Rows[S].Cells["OTVI1"].Value = Convert.ToString(dr["ordertrace_v_image"]);
                            Dgv_data.Rows[S].Cells["OTCH1I1"].Value = Convert.ToString(dr["ordertrace_ch1_image"]);
                            Dgv_data.Rows[S].Cells["OTCH1R1"].Value = Convert.ToString(dr["ordertrace_ch1_real"]);
                            Dgv_data.Rows[S].Cells["OTRPM"].Value = Convert.ToString(dr["ordertrace_rpm"]);


                            double otam = Convert.ToDouble(dr["ordertrace_a_image"]);
                            double otar = Convert.ToDouble(dr["ordertrace_a_real"]);
                            double othm = Convert.ToDouble(dr["ordertrace_h_image"]);
                            double othr = Convert.ToDouble(dr["ordertrace_h_real"]);
                            double otvm = Convert.ToDouble(dr["ordertrace_v_image"]);
                            double otvr = Convert.ToDouble(dr["ordertrace_v_real"]);
                            double otch1m = Convert.ToDouble(dr["ordertrace_ch1_image"]);
                            double otch1r = Convert.ToDouble(dr["ordertrace_ch1_real"]);

                            string[] allPhaseValue = CalculatePhaseValue(otam, otar, othm, othr, otvm, otvr, otch1m, otch1r);

                            Double sPtOrderTraceAmplitudeA = Convert.ToDouble(Math.Sqrt((Convert.ToDouble(dr["ordertrace_a_image"]) * Convert.ToDouble(dr["ordertrace_a_image"])) + (Convert.ToDouble(dr["ordertrace_a_real"]) * Convert.ToDouble(dr["ordertrace_a_real"]))));
                            Double sPtOrderTraceAmplitudeH = Convert.ToDouble(Math.Sqrt((Convert.ToDouble(dr["ordertrace_h_image"]) * Convert.ToDouble(dr["ordertrace_h_image"])) + (Convert.ToDouble(dr["ordertrace_h_real"]) * Convert.ToDouble(dr["ordertrace_h_real"]))));
                            Double sPtOrderTraceAmplitudeV = Convert.ToDouble(Math.Sqrt((Convert.ToDouble(dr["ordertrace_v_image"]) * Convert.ToDouble(dr["ordertrace_v_image"])) + (Convert.ToDouble(dr["ordertrace_v_real"]) * Convert.ToDouble(dr["ordertrace_v_real"]))));
                            Double sPtOrderTraceAmplitudeCH1 = Convert.ToDouble(Math.Sqrt((Convert.ToDouble(dr["ordertrace_ch1_image"]) * Convert.ToDouble(dr["ordertrace_ch1_image"])) + (Convert.ToDouble(dr["ordertrace_ch1_real"]) * Convert.ToDouble(dr["ordertrace_ch1_real"]))));


                            Dgv_data.Rows[S].Cells["OTAR1"].Value = Convert.ToString(Math.Round(sPtOrderTraceAmplitudeA, 5));
                            Dgv_data.Rows[S].Cells["OTAI1"].Value = Convert.ToString(Math.Round(sPtOrderTraceAmplitudeH, 5));
                            Dgv_data.Rows[S].Cells["OTHR1"].Value = Convert.ToString(Math.Round(sPtOrderTraceAmplitudeV, 5));
                            Dgv_data.Rows[S].Cells["OTHI1"].Value = Convert.ToString(Math.Round(sPtOrderTraceAmplitudeCH1, 5));

                            Dgv_data.Rows[S].Cells["DGA_Phase"].Value = Convert.ToString(allPhaseValue[0]);
                            Dgv_data.Rows[S].Cells["DGH_Phase"].Value = Convert.ToString(allPhaseValue[1]);
                            Dgv_data.Rows[S].Cells["DGV_Phase"].Value = Convert.ToString(allPhaseValue[2]);
                            Dgv_data.Rows[S].Cells["DGCH1_Phase"].Value = Convert.ToString(allPhaseValue[3]);
                            Dgv_data.Rows[S].Cells["colCounter"].Value = Convert.ToInt32(dr["data_id"]);
                            Dgv_data.Rows[S].Cells["ColNote1"].Value = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["notes1"]), "0"));
                            Dgv_data.Rows[S].Cells["ColNote2"].Value = retunNote2(Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["notes2"]), "0")));
                            S = S + 1;
                        }
                    }
                }
            }
            catch { }
        }

        public string[] CalculatePhaseValue(double aM, double aR, double hM, double hR, double vM, double vR, double ch1M, double ch1R)
        {
            string[] allPhaseValue = new string[4];
            try
            {
                string sPtOrderTracePhaseA = Convert.ToString(Math.Atan(aM / aR));
                string sPtOrderTracePhaseH = Convert.ToString(Math.Atan(hM / hR));
                string sPtOrderTracePhaseV = Convert.ToString(Math.Atan(vM / vR));
                string sPtOrderTracePhaseCH1 = Convert.ToString(Math.Atan(ch1M / ch1R));

                double anglea = Convert.ToDouble(sPtOrderTracePhaseA) * (180 / Math.PI);
                double angleh = Convert.ToDouble(sPtOrderTracePhaseH) * (180 / Math.PI);
                double anglev = Convert.ToDouble(sPtOrderTracePhaseV) * (180 / Math.PI);
                double anglech1 = Convert.ToDouble(sPtOrderTracePhaseCH1) * (180 / Math.PI);


                for (int i = 0; i < 4; i++)
                {
                    double imag = 0.0;
                    double real = 0.0;

                    //-----------------Axial Direction--------------------------//

                    if (i == 0)
                    {
                        imag = aM;
                        real = aR;

                        if (imag > 0.0 && real > 0.0)
                        {
                            if (anglea > 0.0 || anglea < 90.0)
                            {
                                sPtOrderTracePhaseA = Convert.ToString(anglea);
                            }
                            else
                            {
                                anglea = anglea + 90.0;
                                if (anglea > 0.0 || anglea < 90.0)
                                {
                                    sPtOrderTracePhaseA = Convert.ToString(anglea);
                                }
                            }
                        }
                        else if (imag > 0.0 && real < 0.0)
                        {
                            if (anglea > 90.0 && anglea < 180.0)
                            {
                                sPtOrderTracePhaseA = Convert.ToString(anglea);
                            }
                            else
                            {
                                anglea = anglea + 90.0;
                                if (anglea > 90.0 && anglea < 180.0)
                                {
                                    sPtOrderTracePhaseA = Convert.ToString(anglea);
                                }
                                else
                                {
                                    anglea = anglea + 90.0;
                                    if (anglea > 90.0 && anglea < 180.0)
                                    {
                                        sPtOrderTracePhaseA = Convert.ToString(anglea);
                                    }
                                }
                            }
                        }
                        else if (imag < 0.0 && real < 0.0)
                        {
                            if (anglea > 180.0 && anglea < 270.0)
                            {
                                sPtOrderTracePhaseA = Convert.ToString(anglea);
                            }
                            else
                            {
                                anglea = anglea + 90.0;
                                if (anglea > 180.0 && anglea < 270.0)
                                {
                                    sPtOrderTracePhaseA = Convert.ToString(anglea);
                                }
                                else
                                {
                                    anglea = anglea + 90.0;
                                    if (anglea > 180.0 && anglea < 270.0)
                                    {
                                        sPtOrderTracePhaseA = Convert.ToString(anglea);
                                    }
                                    else
                                    {
                                        anglea = anglea + 90.0;
                                        if (anglea > 180.0 && anglea < 270.0)
                                        {
                                            sPtOrderTracePhaseA = Convert.ToString(anglea);
                                        }
                                    }
                                }
                            }
                        }


                        else if (imag < 0.0 && real > 0.0)
                        {
                            if (anglea > 270.0 && anglea < 360.0)
                            {
                                sPtOrderTracePhaseA = Convert.ToString(anglea);
                            }
                            else
                            {
                                anglea = anglea + 90.0;
                                if (anglea > 270.0 && anglea < 360.0)
                                {
                                    sPtOrderTracePhaseA = Convert.ToString(anglea);
                                }
                                else
                                {
                                    anglea = anglea + 90.0;
                                    if (anglea > 270.0 && anglea < 360.0)
                                    {
                                        sPtOrderTracePhaseA = Convert.ToString(anglea);
                                    }
                                    else
                                    {
                                        anglea = anglea + 90.0;
                                        if (anglea > 270.0 && anglea < 360.0)
                                        {
                                            sPtOrderTracePhaseA = Convert.ToString(anglea);
                                        }
                                        else
                                        {
                                            anglea = anglea + 90.0;
                                            if (anglea > 270.0 && anglea < 360.0)
                                            {
                                                sPtOrderTracePhaseA = Convert.ToString(anglea);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        sPtOrderTracePhaseA = Convert.ToString(anglea);
                        if (sPtOrderTracePhaseA == "NaN")
                        {
                            sPtOrderTracePhaseA = "NA";
                        }
                    }

                         //-----------------Horizontal Direction--------------------------//

                    else if (i == 1)
                    {
                        imag = hM;
                        real = hR;

                        if (imag > 0.0 && real > 0.0)
                        {
                            if (angleh > 0.0 && angleh < 90.0)
                            {
                                sPtOrderTracePhaseH = Convert.ToString(angleh);
                            }
                            else
                            {
                                angleh = angleh + 90.0;
                                if (angleh > 0.0 && angleh < 90.0)
                                {
                                    sPtOrderTracePhaseH = Convert.ToString(angleh);
                                }

                            }
                        }
                        else if (imag > 0.0 && real < 0.0)
                        {
                            if (angleh > 90.0 && angleh < 180.0)
                            {
                                sPtOrderTracePhaseH = Convert.ToString(angleh);
                            }
                            else
                            {
                                angleh = angleh + 90.0;
                                if (angleh > 90.0 && angleh < 180.0)
                                {
                                    sPtOrderTracePhaseH = Convert.ToString(angleh);
                                }
                                else
                                {
                                    angleh = angleh + 90.0;
                                    if (angleh > 90.0 && angleh < 180.0)
                                    {
                                        sPtOrderTracePhaseH = Convert.ToString(angleh);
                                    }
                                }
                            }
                        }
                        else if (imag < 0.0 && real < 0.0)
                        {
                            if (angleh > 180.0 && angleh < 270.0)
                            {
                                sPtOrderTracePhaseH = Convert.ToString(angleh);
                            }
                            else
                            {
                                angleh = angleh + 90.0;
                                if (angleh > 180.0 && angleh < 270.0)
                                {
                                    sPtOrderTracePhaseH = Convert.ToString(angleh);
                                }
                                else
                                {
                                    angleh = angleh + 90.0;
                                    if (angleh > 180.0 && angleh < 270.0)
                                    {
                                        sPtOrderTracePhaseH = Convert.ToString(angleh);
                                    }
                                    else
                                    {
                                        angleh = angleh + 90.0;
                                        if (angleh > 180.0 && angleh < 270.0)
                                        {
                                            sPtOrderTracePhaseH = Convert.ToString(angleh);
                                        }
                                    }
                                }
                            }
                        }


                        else if (imag < 0.0 && real > 0.0)
                        {
                            if (angleh > 270.0 && angleh < 360.0)
                            {
                                sPtOrderTracePhaseH = Convert.ToString(angleh);
                            }
                            else
                            {
                                angleh = angleh + 90.0;
                                if (angleh > 270.0 && angleh < 360.0)
                                {
                                    sPtOrderTracePhaseH = Convert.ToString(angleh);
                                }
                                else
                                {
                                    angleh = angleh + 90.0;
                                    if (angleh > 270.0 && angleh < 360.0)
                                    {
                                        sPtOrderTracePhaseH = Convert.ToString(angleh);
                                    }
                                    else
                                    {
                                        angleh = angleh + 90.0;
                                        if (angleh > 270.0 && angleh < 360.0)
                                        {
                                            sPtOrderTracePhaseH = Convert.ToString(angleh);
                                        }
                                        else
                                        {
                                            angleh = angleh + 90.0;
                                            if (angleh > 270.0 && angleh < 360.0)
                                            {
                                                sPtOrderTracePhaseH = Convert.ToString(angleh);
                                            }
                                        }
                                    }

                                }
                            }
                        }
                        sPtOrderTracePhaseH = Convert.ToString(angleh);
                        if (sPtOrderTracePhaseH == "NaN")
                        {
                            sPtOrderTracePhaseH = "NA";
                        }
                    }

           //-----------------Vertical Direction--------------------------//

                    else if (i == 2)
                    {
                        imag = vM;
                        real = vR;

                        if (imag > 0.0 && real > 0.0)
                        {
                            if (anglev > 0.0 && anglev < 90.0)
                            {
                                sPtOrderTracePhaseV = Convert.ToString(anglev);
                            }
                            else
                            {
                                anglev = anglev + 90.0;
                                if (anglev > 0.0 && anglev < 90.0)
                                {
                                    sPtOrderTracePhaseV = Convert.ToString(anglev);
                                }

                            }
                        }
                        else if (imag > 0.0 && real < 0.0)
                        {
                            if (anglev > 90.0 && anglev < 180.0)
                            {
                                sPtOrderTracePhaseV = Convert.ToString(anglev);
                            }
                            else
                            {
                                anglev = anglev + 90.0;
                                if (anglev > 90.0 && anglev < 180.0)
                                {
                                    sPtOrderTracePhaseV = Convert.ToString(anglev);
                                }
                                else
                                {
                                    anglev = anglev + 90.0;
                                    if (anglev > 90.0 && anglev < 180.0)
                                    {
                                        sPtOrderTracePhaseV = Convert.ToString(anglev);
                                    }
                                }
                            }
                        }
                        else if (imag < 0.0 && real < 0.0)
                        {
                            if (anglev > 180.0 && anglev < 270.0)
                            {
                                sPtOrderTracePhaseV = Convert.ToString(anglev);
                            }
                            else
                            {
                                anglev = anglev + 90.0;
                                if (anglev > 180.0 && anglev < 270.0)
                                {
                                    sPtOrderTracePhaseV = Convert.ToString(anglev);
                                }
                                else
                                {
                                    anglev = anglev + 90.0;
                                    if (anglev > 180.0 && anglev < 270.0)
                                    {
                                        sPtOrderTracePhaseV = Convert.ToString(anglev);
                                    }
                                    else
                                    {
                                        anglev = anglev + 90.0;
                                        if (anglev > 180.0 && anglev < 270.0)
                                        {
                                            sPtOrderTracePhaseV = Convert.ToString(anglev);
                                        }
                                    }
                                }
                            }
                        }


                        else if (imag < 0.0 && real > 0.0)
                        {
                            if (anglev > 270.0 && anglev < 360.0)
                            {
                                sPtOrderTracePhaseV = Convert.ToString(anglev);
                            }
                            else
                            {
                                anglev = anglev + 90.0;
                                if (anglev > 270.0 && anglev < 360.0)
                                {
                                    sPtOrderTracePhaseV = Convert.ToString(anglev);
                                }
                                else
                                {
                                    anglev = anglev + 90.0;
                                    if (anglev > 270.0 && anglev < 360.0)
                                    {
                                        sPtOrderTracePhaseV = Convert.ToString(anglev);
                                    }
                                    else
                                    {
                                        anglev = anglev + 90.0;
                                        if (anglev > 270.0 && anglev < 360.0)
                                        {
                                            sPtOrderTracePhaseV = Convert.ToString(anglev);
                                        }
                                        else
                                        {
                                            anglev = anglev + 90.0;
                                            if (anglev > 270.0 && anglev < 360.0)
                                            {
                                                sPtOrderTracePhaseV = Convert.ToString(anglev);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        sPtOrderTracePhaseV = Convert.ToString(anglev);
                        if (sPtOrderTracePhaseV == "NaN")
                        {
                            sPtOrderTracePhaseV = "NA";
                        }
                    }

          //-----------------Channel1 Direction--------------------------//

                    else if (i == 3)
                    {
                        imag = ch1M;
                        real = ch1R;

                        if (imag > 0.0 && real > 0.0)
                        {
                            if (anglech1 > 0.0 && anglech1 < 90.0)
                            {
                                sPtOrderTracePhaseCH1 = Convert.ToString(anglech1);
                            }
                            else
                            {
                                anglech1 = anglech1 + 90.0;
                                if (anglech1 > 0.0 && anglech1 < 90.0)
                                {
                                    sPtOrderTracePhaseCH1 = Convert.ToString(anglech1);
                                }
                            
                            }
                        }
                        else if (imag > 0.0 && real < 0.0)
                        {
                            if (anglech1 > 90.0 && anglech1 < 180.0)
                            {
                                sPtOrderTracePhaseCH1 = Convert.ToString(anglech1);
                            }
                            else
                            {
                                anglech1 = anglech1 + 90.0;
                                if (anglech1 > 90.0 && anglech1 < 180.0)
                                {
                                    sPtOrderTracePhaseCH1 = Convert.ToString(anglech1);
                                }
                                else
                                {
                                    anglech1 = anglech1 + 90.0;
                                    if (anglech1 > 90.0 && anglech1 < 180.0)
                                    {
                                        sPtOrderTracePhaseCH1 = Convert.ToString(anglech1);
                                    }
                                }
                            }
                        }
                        else if (imag < 0.0 && real < 0.0)
                        {
                            if (anglech1 > 180.0 && anglech1 < 270.0)
                            {
                                sPtOrderTracePhaseCH1 = Convert.ToString(anglech1);
                            }
                            else
                            {
                                anglech1 = anglech1 + 90.0;
                                if (anglech1 > 180.0 && anglech1 < 270.0)
                                {
                                    sPtOrderTracePhaseCH1 = Convert.ToString(anglech1);
                                }
                                else
                                {
                                    anglech1 = anglech1 + 90.0;
                                    if (anglech1 > 180.0 && anglech1 < 270.0)
                                    {
                                        sPtOrderTracePhaseCH1 = Convert.ToString(anglech1);
                                    }
                                    else
                                    {
                                        anglech1 = anglech1 + 90.0;
                                        if (anglech1 > 180.0 && anglech1 < 270.0)
                                        {
                                            sPtOrderTracePhaseCH1 = Convert.ToString(anglech1);
                                        }
                                    }
                                }
                            }
                        }


                        else if (imag < 0.0 && real > 0.0)
                        {
                            if (anglech1 > 270.0 && anglech1 < 360.0)
                            {
                                sPtOrderTracePhaseCH1 = Convert.ToString(anglech1);
                            }
                            else
                            {
                                anglech1 = anglech1 + 90.0;
                                if (anglech1 > 270.0 && anglech1 < 360.0)
                                {
                                    sPtOrderTracePhaseCH1 = Convert.ToString(anglech1);
                                }
                                else
                                {

                                    double anglech11 = Convert.ToDouble(sPtOrderTracePhaseCH1) * (180 / Math.PI);
                                    anglech1 = anglech1 + 90.0;
                                    if (anglech1 > 270.0 && anglech1 < 360.0)
                                    {
                                        sPtOrderTracePhaseCH1 = Convert.ToString(anglech1);
                                    }
                                    else
                                    {
                                        anglech1 = anglech1 + 90.0;
                                        if (anglech1 > 270.0 && anglech1 < 360.0)
                                        {
                                            sPtOrderTracePhaseCH1 = Convert.ToString(anglech1);
                                        }
                                        else
                                        {
                                            anglech1 = anglech1 + 90.0;
                                            if (anglech1 > 270.0 && anglech1 < 360.0)
                                            {
                                                sPtOrderTracePhaseCH1 = Convert.ToString(anglech1);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        sPtOrderTracePhaseCH1 = Convert.ToString(anglech1);
                        if (sPtOrderTracePhaseCH1 == "NaN")
                        {
                            sPtOrderTracePhaseCH1 = "NA";
                        }
                    }
                }
                allPhaseValue[0] = sPtOrderTracePhaseA;
                allPhaseValue[1] = sPtOrderTracePhaseH;
                allPhaseValue[2] = sPtOrderTracePhaseV;
                allPhaseValue[3] = sPtOrderTracePhaseCH1;

            }
            catch { }
            return allPhaseValue;
        }

        public string retunNote2(int notesid)
        {
            string notes = "";
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select distinct note from point_note2 where note_id = '" + notesid + "' ");
                notes = PublicClass.DefVal(Convert.ToString(dt.Rows[0][0]), "");
            }
            catch
            {

            }
            return notes;
        }

        private void trlImages_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string name = (string)trlImages.FocusedNode.GetDisplayText(2);
                pePictures.Image = Image.FromFile(name);
            }
            catch { }
        }

        public void Create_tree_Node()
        {
            try
            {
                trlImages.Columns.Add();
                trlImages.Columns[0].Caption = "";
                trlImages.Columns[0].VisibleIndex = 0;
                trlImages.Columns[0].ColumnEdit = new RepositoryItemPictureEdit();
                trlImages.Columns.Add();
                trlImages.Columns[1].Caption = "Description";
                trlImages.Columns[1].VisibleIndex = 1;
                trlImages.Columns.Add();
                trlImages.Columns[2].Caption = "FullPath";
                trlImages.Columns[2].VisibleIndex = -1;
            }
            catch { }
        }

        private void SetImagefromImageBox(TreeListNode objFocusedNode)
        {
            bool bselected = false;
            try
            {
                if (objFocusedNode.Tag.ToString() != null)
                {
                    pePictures.Image = Image.FromFile(objFocusedNode.Tag.ToString());

                    string sFileName = objFocusedNode.Tag.ToString().Replace('\\', '-');

                    DataTable dtm = new DataTable();

                    dtm = DbClass.getdata(CommandType.Text, "select * from Machine_Pic where MAchineID ='" + PublicClass.SMachineID + "' and Description='" + sFileName + "'");

                    foreach (DataRow dr in dtm.Rows)
                    {
                        string sSelected = Convert.ToString(dr["Description"]);
                        if (sSelected == "selected")
                        {
                            bselected = true;
                        }
                    }
                    btndelete.Enabled = !bselected;
                }
            }
            catch
            {
            }
        }

        private void cmbbxManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string manName = Convert.ToString(cmbbxManufacturer.Text.Trim());
                cmbbxBearingNumber.DataSource = DbClass.getdata(CommandType.Text, "Select distinct BearingName , ID from route.bearing_info where ManufactureName = '" + manName + "'");
                cmbbxBearingNumber.DisplayMember = "BearingName";
                cmbbxBearingNumber.ValueMember = "ID";
                cmbbxBearingNumber.Text = "--Select--";
                tbBalls.Text = "0";
                tbBPFI.Text = "0";
                tbBPFO.Text = "0";
                tbBSF.Text = "0";
                tbFTF.Text = "0";              
            }
            catch
            {
            }
        }

        bool modify = false;              
        private void fillDefaultData()
        {
            string mID = null;
            string status = null;
            try
            {
                tbBalls.Clear();
                tbBPFI.Clear();
                tbBPFO.Clear();
                tbBSF.Clear();
                tbFTF.Clear();                
                txtxBCA.Clear();
                txtxBDIR.Clear();
                txtxBDOR.Clear();
                txtxBDRE.Clear();
                txtxBNRE.Clear();    
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "Select  * from point_bearing where Point_ID = '" + PublicClass.SPointID + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    txtxBCA.Text = Convert.ToString(dr["BCA"]);
                    txtxBDIR.Text = Convert.ToString(dr["BDIR"]);
                    txtxBDOR.Text = Convert.ToString(dr["BDOR"]);
                    txtxBDRE.Text = Convert.ToString(dr["BDRE"]);
                    txtxBNRE.Text = Convert.ToString(dr["BNRE"]);

                    cmbbxManufacturer.Text = Convert.ToString(dr["Manufacture"]).Trim();
                    cmbbxBearingNumber.Text = Convert.ToString(dr["BearingNumber"]);
                    tbBalls.Text = Convert.ToString(dr["BALLS"]);
                    tbFTF.Text = Convert.ToString(dr["FTF"]);
                    tbBSF.Text = Convert.ToString(dr["BSF"]);
                    tbBPFO.Text = Convert.ToString(dr["BPFO"]);
                    tbBPFI.Text = Convert.ToString(dr["BPFI"]);

                    mID = Convert.ToString(dr["MachineID"]);
                    status = Convert.ToString(dr["Status"]);
                }
                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        if (status == "true")
                        {
                            modify = true;
                            rbPhysicalDimensions.Checked = true;
                            txtxBCA.Enabled = true;
                            txtxBDIR.Enabled = true;
                            txtxBDOR.Enabled = true;
                            txtxBDRE.Enabled = true;
                            txtxBNRE.Enabled = true;
                            btnxCalculateFreq.Enabled = true;
                            rbBearingNumber.Checked = false;
                            tbBalls.Enabled = false;
                            tbBPFI.Enabled = false;
                            tbBPFO.Enabled = false;
                            tbBSF.Enabled = false;
                            tbFTF.Enabled = false;
                            cmbbxManufacturer.Enabled = false;
                            cmbbxBearingNumber.Enabled = false;

                        }
                        else
                        {
                            modify = true;
                            rbPhysicalDimensions.Checked = false;
                            txtxBCA.Enabled = false;
                            txtxBDIR.Enabled = false;
                            txtxBDOR.Enabled = false;
                            txtxBDRE.Enabled = false;
                            txtxBNRE.Enabled = false;
                            btnxCalculateFreq.Enabled = false;
                            rbBearingNumber.Checked = true;
                            tbBalls.Enabled = false;
                            tbBPFI.Enabled = false;
                            tbBPFO.Enabled = false;
                            tbBSF.Enabled = false;
                            tbFTF.Enabled = false;
                            cmbbxManufacturer.Enabled = true;
                            cmbbxBearingNumber.Enabled = true;
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    txtxBCA.Enabled = true;
                    txtxBDIR.Enabled = true;
                    txtxBDOR.Enabled = true;
                    txtxBDRE.Enabled = true;
                    txtxBNRE.Enabled = true;
                    rbPhysicalDimensions.Checked = true;
                    rbBearingNumber.Checked = false;
                    cmbbxManufacturer.SelectedIndex = 0;
                    cmbbxBearingNumber.Text = "--Select--";
                    txtxBCA.Text = "0";
                    txtxBDIR.Text = "1";
                    txtxBDOR.Text = "10";
                    txtxBDRE.Text = "1";
                    txtxBNRE.Text = "1";
                    tbBalls.Text = "0";
                    tbBPFI.Text = "0";
                    tbBPFO.Text = "0";
                    tbBSF.Text = "0";
                    tbFTF.Text = "0";
                }
            }
            catch
            {  }
        }

        private void cmbbxBearingNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {               
                string sBearingName = cmbbxBearingNumber.Text.ToString();
                if (sBearingName != "")
                {
                    if (sBearingName == "--Select--")
                    {
                        tbBalls.Text = "0";
                        tbBPFI.Text = "0";
                        tbBPFO.Text = "0";
                        tbBSF.Text = "0";
                        tbFTF.Text = "0";
                    }
                    else
                    {                       
                        DataTable dt1 = new DataTable();
                        dt1 = DbClass.getdata(CommandType.Text, "SELECT BearingBalls , BearingBPFI , BearingBPFO , BearingBSF , BearingFTF FROM route.bearing_info where BearingName = '" + sBearingName + "'; ");
                        if (dt1.Rows.Count > 0)
                        {
                            tbBalls.Text = Convert.ToString(dt1.Rows[0][0]);
                            tbBPFI.Text = Convert.ToString(dt1.Rows[0][1]);
                            tbBPFO.Text = Convert.ToString(dt1.Rows[0][2]);
                            tbBSF.Text = Convert.ToString(dt1.Rows[0][3]);
                            tbFTF.Text = Convert.ToString(dt1.Rows[0][2]);
                        }
                    }                   
                }
            }
            catch
            {

            }
        }

        private void rbPhysicalDimensions_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbPhysicalDimensions.Checked)
                {
                    if (modify == true)
                    { }
                    else
                    {
                        txtxBCA.Enabled = true;
                        txtxBDIR.Enabled = true;
                        txtxBDOR.Enabled = true;
                        txtxBDRE.Enabled = true;
                        txtxBNRE.Enabled = true;
                        btnxCalculateFreq.Enabled = true;
                        cmbbxManufacturer.Enabled = false;
                        cmbbxBearingNumber.Enabled = false;
                        cmbbxManufacturer.SelectedIndex = 0;
                        cmbbxBearingNumber.Text = "--Select--";
                        txtxBCA.Text = "0";
                        txtxBDIR.Text = "1";
                        txtxBDOR.Text = "10";
                        txtxBDRE.Text = "1";
                        txtxBNRE.Text = "1";
                        tbBalls.Text = "0";
                        tbBPFI.Text = "0";
                        tbBPFO.Text = "0";
                        tbBSF.Text = "0";
                        tbFTF.Text = "0";
                    }
                }
            }
            catch
            {  }
        }

        private void rbBearingNumber_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbBearingNumber.Checked)
                {
                    if (modify == true)
                    { }
                    else
                    {
                        txtxBCA.Enabled = false;
                        txtxBDIR.Enabled = false;
                        txtxBDOR.Enabled = false;
                        txtxBDRE.Enabled = false;
                        txtxBNRE.Enabled = false;
                        btnxCalculateFreq.Enabled = false;

                        cmbbxManufacturer.Enabled = true;
                        cmbbxBearingNumber.Enabled = true;
                        cmbbxManufacturer.SelectedIndex = 0;
                        cmbbxBearingNumber.Text = "--Select--";
                        txtxBCA.Text = "0";
                        txtxBDIR.Text = "1";
                        txtxBDOR.Text = "10";
                        txtxBDRE.Text = "1";
                        txtxBNRE.Text = "1";
                        tbBalls.Text = "0";
                        tbBPFI.Text = "0";
                        tbBPFO.Text = "0";
                        tbBSF.Text = "0";
                        tbFTF.Text = "0";
                    }
                }
            }
            catch
            {
            }
        }

        private void Tabbearing_MouseLeave(object sender, EventArgs e)
        {
            try
            {               
                string sStatus = null;
                string bBCA = Convert.ToString(txtxBCA.Text.Trim());
                string bBDIR = Convert.ToString(txtxBDIR.Text.Trim());
                string bBDOR = Convert.ToString(txtxBDOR.Text.Trim());
                string bBDRE = Convert.ToString(txtxBDRE.Text.Trim());
                string bBNRE = Convert.ToString(txtxBNRE.Text.Trim());

                string bBALLS = Convert.ToString(tbBalls.Text.Trim());
                string bBPFI = Convert.ToString(tbBPFI.Text.Trim());
                string bBPFO = Convert.ToString(tbBPFO.Text.Trim());
                string bBSF = Convert.ToString(tbBSF.Text.Trim());
                string bFTF = Convert.ToString(tbFTF.Text.Trim());

                string bMANU = Convert.ToString(cmbbxManufacturer.Text.Trim());
                string bBNUMBER = Convert.ToString(cmbbxBearingNumber.Text);

                if (rbBearingNumber.Checked)
                {
                    if (bMANU == "--Select--")
                    { }
                    else if (bBNUMBER == "")
                    { }
                    else
                    { sStatus = "false"; }
                }
                else
                {
                    sStatus = "true";
                }               
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "Select Point_ID,Bearing_ID  from point_bearing where Point_ID = '" + PublicClass.SPointID + "'");


                if (dt.Rows.Count > 0)
                {
                    DbClass.executequery(CommandType.Text, "Update point_bearing set Manufacture = '" + bMANU + "' , BearingNumber = '" + bBNUMBER + "', BALLS = '" + bBALLS + "' , FTF = '" + bFTF + "' , BSF ='" + bBSF + "' , BPFO = '" + bBPFO + "' , BPFI = '" + bBPFI + "', BDIR   = '" + bBDIR + "', BDOR  = '" + bBDOR + "', BCA = '" + bBCA + "', BDRE  = '" + bBDRE + "',BNRE = '" + bBNRE + "', Status  = '" + sStatus + "' where Point_ID = '" + PublicClass.SPointID + "' and Bearing_ID='"+dt.Rows[0][1]+"'");
                }
                else
                {
                    DbClass.executequery(CommandType.Text, "insert into point_bearing(Point_ID , Manufacture , BearingNumber , MachineID , BALLS , FTF , BSF , BPFO , BPFI,BDIR,BDOR,BCA,BDRE,BNRE,Status) values('" + PublicClass.SPointID + "' ,'" + bMANU + "' , '" + bBNUMBER + "','" + PublicClass.SMachineID + "', '" + bBALLS + "' ,'" + bFTF + "' , '" + bBSF + "' ,'" + bBPFO + "' , '" + bBPFI + "','" + bBDIR + "','" + bBDOR + "','" + bBCA + "', '" + bBDRE + "','" + bBNRE + "', '" + sStatus + "')");
                }
            }
            catch
            {
            }
        }
             
        string sPlantID = null;
        string sAreaID = null;
        string sTrainID = null;
        string sMachineID = null;
        string sPtID = null;
        public void deleteselected()
        {
            try
            {
                sNodeType = (string)trlPlantManger.FocusedNode.GetDisplayText(10);
                string sID = (string)trlPlantManger.FocusedNode.GetDisplayText(2);
                sPlantID = (string)trlPlantManger.FocusedNode.GetDisplayText(4);
                sAreaID = (string)trlPlantManger.FocusedNode.GetDisplayText(5);
                sTrainID = (string)trlPlantManger.FocusedNode.GetDisplayText(6);
                sMachineID = (string)trlPlantManger.FocusedNode.GetDisplayText(7);
                sPtID = (string)trlPlantManger.FocusedNode.GetDisplayText(8);
                if (MessageBox.Show("Are you Sure,You want to delete " + sNodeType, "Delete " + sNodeType, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    switch (sNodeType)
                    {
                        case "Plant":
                            {
                                DeleteFactory(sPlantID);                               
                                _objMain.lblStatus.Caption = "Status: Deleting Factory Successfully";
                                break;
                            }
                        case "Area":
                            {
                                DeleteArea(sAreaID);
                                _objMain.lblStatus.Caption = "Status: Deleting Area Successfully";
                                break;
                            }
                        case "Train":
                            {
                                DeleteTrain(sTrainID);
                                _objMain.lblStatus.Caption = "Status: Deleting Train Successfully";
                                break;
                            }
                        case "Machine":
                            {
                                DeleteMachine(sMachineID);
                                _objMain.lblStatus.Caption = "Status: Deleting Machine Successfully";
                                break;
                            }
                        case "Point":
                            {
                                DeletePoint(sPtID);
                                _objMain.lblStatus.Caption = "Status: Deleting Point Successfully";
                                break;
                            }
                    }
                    filltreelist();
                }
            }
            catch
            {
            }
        }

        public void DeleteFactory(string sFacID)
        {
            try
            {
                DataTable dtf = new DataTable();
                dtf = DbClass.getdata(CommandType.Text, "Select * from area_info where FactoryID = '" + sFacID + "'");
                foreach (DataRow dr in dtf.Rows)
                {
                    string arID = Convert.ToString(dr["Area_ID"]);
                    DeleteArea(arID);
                }
                DbClass.executequery(CommandType.Text, "Delete from factory_info where Factory_ID = '" + sFacID + "'");               
            }
            catch { }
        }

        public void DeleteArea(string sArID)
        {
            try
            {
                DataTable dta1 = new DataTable();
                dta1 = DbClass.getdata(CommandType.Text, "Select * from train_info where Area_ID = '" + sArID + "' ");

                foreach (DataRow dr in dta1.Rows)
                {
                    string trID = Convert.ToString(dr["Train_ID"]);
                    DeleteTrain(trID);
                }
                DbClass.executequery(CommandType.Text, "Delete from area_info where Area_ID = '" + sArID + "'");               
            }
            catch { }
        }

        public void DeleteTrain(string sTrID)
        {
            try
            {
                DataTable dtt1 = new DataTable();
                dtt1 = DbClass.getdata(CommandType.Text, "Select * from machine_info where TrainID = '" + sTrID + "' ");

                foreach (DataRow dr in dtt1.Rows)
                {
                    string macID = Convert.ToString(dr["Machine_ID"]);
                    DeleteMachine(macID);
                }
                DbClass.executequery(CommandType.Text, "Delete from train_info where Train_ID = '" + sTrID + "'");
               
            }
            catch { }
        }

        public void DeleteMachine(string sMacID)
        {
            try
            {                
                DataTable dtm1 = new DataTable();
                dtm1 = DbClass.getdata(CommandType.Text, "Select * from Point where Machine_ID = '" + sMacID + "' ");

                foreach (DataRow dr in dtm1.Rows)
                {
                    string ptID = Convert.ToString(dr["Point_ID"]);
                    DeletePoint(ptID);
                }
                DbClass.executequery(CommandType.Text, "Delete from Machine_Info where Machine_ID = '" + sMacID + "'");             
            }
            catch { }
        }

        public void DeletePoint(string sPID)
        {
            try
            {
                DbClass.executequery(CommandType.Text, "Delete from point where Point_ID = '" + sPID + "' ");
                DbClass.executequery(CommandType.Text, "Delete from point_data where Point_ID = '" + sPID + "' ");
                trlPlantManger.Nodes.Remove(trlPlantManger.FocusedNode);
            }
            catch
            { }
        }

        private void trlPlantManger_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                switch (e.Button)
                {
                    case MouseButtons.Right:
                        {
                            tsCopy.Visible = true; tsPaste.Visible = true; tsadd.Visible = true; tsgraph.Visible = true; tsDelete.Visible = true; tsexpand.Visible = true; tscollapse.Visible = true;
                            tsAddrows.Visible = false;
                            cmsUserControl.Show(this, new Point(e.X, e.Y));
                            break;
                        }
                }
               // visbilty(sNodeType);                    
            }
            catch { }
        }

        public void Fill_Cmb_Point_type()
        {
            try
            {
                CmbPointType.DataSource = null;
                DataTable dt = new DataTable();
                //dt = DbClass.getdata(CommandType.Text, "Select distinct ID,Point_Name from type_point order by  Point_Name");
                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                {
                    dt = DbClass.getdata(CommandType.Text, "Select distinct tp.ID,tp.Point_Name from type_point tp inner join measure_type mea on mea.Type_ID=tp.ID order by  tp.ID");
                }
                else if (PublicClass.currentInstrument == "Kohtect-C911")
                {
                    dt = DbClass.getdata(CommandType.Text, "Select distinct tp.ID,tp.Point_Name from type_point tp inner join c911_measurement mea on mea.Type_ID=tp.ID order by  tp.ID");
                }
                else
                {
                    dt = DbClass.getdata(CommandType.Text, "Select distinct tp.ID,tp.Point_Name from type_point tp inner join di_point mea on mea.Type_ID=tp.ID order by  tp.ID");
                }
                dt.Rows.Add("0", "-- Select -- ");
                DataView view = dt.DefaultView;
                view.Sort = "ID ASC";

                DataTable dtt = new DataTable();
                dtt = view.ToTable();
                CmbPointType.DataSource = dtt;
                CmbPointType.DisplayMember = "Point_Name";
                CmbPointType.ValueMember = "ID";
                CmbPointType.SelectedIndex = 0;
            }
            catch
            { }
        }

        private void cmsUserControl_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {            
            try
            {
                if (PublicClass.SFactoryID != "0" || PublicClass.SAreaID != "0" || PublicClass.STrainID != "0" || PublicClass.SMachineID != "0" || PublicClass.SPointID != "0")
                {
                    if (e.ClickedItem.Text.Trim() == "Copy")
                    {
                        try
                        {
                            CopyNode();
                        }
                        catch { }
                    }
                    else if (e.ClickedItem.Text.Trim() == "Paste")
                    {
                        try
                        {
                            PasteNode(parentNode);
                        }
                        catch { }
                    }
                    else if (e.ClickedItem.Text.Trim() == "Delete")
                    {
                        try
                        {
                            deleteselected();
                        }
                        catch { }
                    }                 
                }
                else
                {
                    MessageBox.Show("Please select Node first");
                    return;
                }

            }
            catch { }
        }
        
        private void DgvMachine_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DgvMachine.IsCurrentCellDirty)
                {
                    DgvMachine.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch { }

        }
        string notesDesc = null;
        string vLevel = null;
        string dNotes = null;
        int dId;
        int nLevel;
        int nid;
        public int SETLevel(string LevelValue)
        {
            int i = 0;
            DataTable dt = DbClass.getdata(CommandType.Text, "select Notes_ID from notes where Notes_Desc='" + LevelValue + "'");
            foreach (DataRow dr in dt.Rows)
            {
                i = Convert.ToInt32(dr["Notes_ID"]);
            }

            return i;
        }

        private void DgvMachine_Leave(object sender, EventArgs e)
        {
            try
            {
                for (int a = 0; a < DgvMachine.Rows.Count; a++)
                {
                    notesDesc = Convert.ToString(DgvMachine.Rows[a].Cells["G_Cmb_Note"].Value).Trim();
                    nid = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(DgvMachine.Rows[a].Cells["col_ID"].Value).Trim(), "0"));

                    if (notesDesc == "")
                    {
                        return;
                    }

                    DataTable cdt = new DataTable();
                    cdt = DbClass.getdata(CommandType.Text, "select distinct  date,Machine_ID,Note_ID,ID from  machine_record where ID = '" + nid + "'  ");
                    foreach (DataRow dr in cdt.Rows)
                    {
                        dNotes = Convert.ToString(dr["ID"]);
                      //  dId = Convert.ToInt32(dr["Note_type"]);
                    }

                    if (cdt.Rows.Count - 1 < 0)
                    {
                        DbClass.executequery(CommandType.Text, "insert machine_record (date,Machine_ID,Note_ID) values('" + Convert.ToDateTime(DgvMachine.Rows[a].Cells["G_Date"].Value).ToString("yyyy-MM-dd HH:mm:ss") + "' ,'" + PublicClass.SMachineID + "','" + Convert.ToString(DgvMachine.Rows[a].Cells["G_Cmb_Note"].Value) + "') ");
                        //DbClass.executequery(CommandType.StoredProcedure, "call Insert_Notes('" + notesDesc + "' , '" + SETLevel(Convert.ToString(DgvMachine.Rows[a].Cells["colLevel"].Value).Trim()) + "' , '" + PublicClass.GetDatetime() + "'  )");

                    }
                    else
                    {
                        if (dNotes != notesDesc || dId != nid)
                        {
                            DbClass.executequery(CommandType.Text, "update machine_record  set  date ='" + Convert.ToDateTime(DgvMachine.Rows[a].Cells["G_Date"].Value).ToString("yyyy-MM-dd HH:mm:ss") + "' , Note_ID='" + Convert.ToString(DgvMachine.Rows[a].Cells["G_Cmb_Note"].Value) + "' , Machine_ID ='" + PublicClass.SMachineID + "' where ID='" + nid + "'  ");
                            //DbClass.executequery(CommandType.StoredProcedure, "call Update_Notes('" + notesDesc + "'  , '" + PublicClass.GetDatetime() + "' , '" + SETLevel(Convert.ToString(DgvMachine.Rows[a].Cells["colLevel"].Value).Trim()) + "' , ' " + nid + "' )");

                        }

                    }


                }
               // MessageBox.Show("Data Saved Successfully");

            }
            catch
            {
            }
        }

        private void DgvMachine_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)DgvMachine.Rows[e.RowIndex].Cells["G_Cmb_Note"].OwningColumn;
                combo.DataSource = DbClass.getdata(CommandType.Text, "select Notes_ID,Notes_Desc from notes where Note_Type ='1' ");
                combo.ValueMember = "Notes_ID";
                combo.DisplayMember = "Notes_Desc";
                DgvMachine.Rows[e.RowIndex].Cells["G_Date"].Value = PublicClass.GetDatetime();
            }

            catch { }
        }

        private void Dgv_data_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (Dgv_data.IsCurrentCellDirty)
            {
                Dgv_data.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void Dgv_data_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                int rr = 0;
                if (sNodeType == "Point")
                {
                    rr = 2;
                }
                else
                {
                    rr = 1;
                }
                DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)Dgv_data.Rows[e.RowIndex].Cells["ColNote1"].OwningColumn;
                combo.DataSource = DbClass.getdata(CommandType.Text, "select Notes_ID,Notes_Desc from notes where Note_Type ='" + rr + "' ");
                combo.ValueMember = "Notes_ID";
                combo.DisplayMember = "Notes_Desc";

            }
            catch { }
        }

        private void Dgv_data_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch { }
        }

        string NodeName = null;
        string cID = null;
        string parentNode = null;
        public void CopyNode()
        {
            try
            {
                string NodeName = sNodeType;
                if (sNodeType == "Plant")
                {
                    cID = PublicClass.SFactoryID;
                    parentNode = "Plant";
                    tsPaste.Enabled = true;
                }
                else if (sNodeType == "Area")
                {
                    cID = PublicClass.SAreaID;
                    parentNode = "Factory";
                    tsPaste.Enabled = true;
                }
                else if (sNodeType == "Train")
                {
                    cID = PublicClass.STrainID;
                    parentNode = "Area";
                    tsPaste.Enabled = true;
                }
                else if (sNodeType == "Machine")
                {
                    cID = PublicClass.SMachineID;
                    parentNode = "Train";
                    tsPaste.Enabled = true;
                }
                else if (sNodeType == "Point")
                {
                    cID = PublicClass.SPointID;
                    parentNode = "Machine";
                    tsPaste.Enabled = true;
                }
            }
            catch { }

        }

        public void PasteNode(string pNodeType)
        {
            try
            {
                if (pNodeType == "Plant")
                {
                    if (PublicClass.ssNodeType == "Plant")
                    {
                        PasteFactory(cID);
                    }
                    else
                    {
                        MessageBox.Show(this, "Select Plant in which you want to copy..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (pNodeType == "Factory")
                {
                    if (PublicClass.ssNodeType == "Plant")
                    {
                        PasteArea(cID, Convert.ToInt32(PublicClass.SFactoryID), true);                        
                    }
                    else
                    {
                        MessageBox.Show(this, "Select Plant in which you want to copy..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else if (pNodeType == "Area")
                {
                    if (PublicClass.ssNodeType == "Area")
                    {
                        PasteTrain(cID, Convert.ToInt32(PublicClass.SAreaID), true);
                    }
                    else
                    {
                        MessageBox.Show(this, "Please Select Area in which you want to copy..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else if (pNodeType == "Train")
                {
                    if (PublicClass.ssNodeType == "Train")
                    {
                        PasteMachine(cID, Convert.ToInt32(PublicClass.STrainID), true);
                    }
                    else
                    {
                        MessageBox.Show(this, "Please Select Train in which you want to copy..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else if (pNodeType == "Machine")
                {
                    if (PublicClass.ssNodeType == "Machine")
                    {
                        PastePoint(cID, Convert.ToInt32(PublicClass.SMachineID), true);
                    }
                    else
                    {
                        MessageBox.Show(this, "Please Select Machine in which you want to copy..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else if (pNodeType == "Point")
                {
                    if (PublicClass.ssNodeType == "Machine")
                    {
                        PastePoint(cID, Convert.ToInt32(PublicClass.SMachineID), true);
                    }
                    else
                    {
                        MessageBox.Show(this, "Please Select Machine in which you want to copy..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch
            {
            }
        }

        TreeListNode parentForRootForFactory1 = null;
        TreeListNode parentForRootForResorce1 = null;
        TreeListNode parentForRootForElement1 = null;
        TreeListNode parentForSubelement1 = null;
        TreeListNode parentForRootPoint1 = null;
        bool chFac = false; TreeListNode parentForNose = null;
        public void PasteFactory(string fID)
        {
            try
            {

                DataTable dtf2 = new DataTable();
                dtf2 = DbClass.getdata(CommandType.Text, "Select Max(factory_ID)factory_ID from factory_info");
                FactCurtMaxID = dtf2.Rows[0]["factory_ID"].ToString();
                DataTable dtf = new DataTable();
                dtf = DbClass.getdata(CommandType.Text, "Select * from factory_info where factory_ID = '" + fID + "'");
                foreach (DataRow dr in dtf.Rows)
                {
                    string fName = Convert.ToString(dr["Name"]);
                    string fDescription = Convert.ToString(dr["Description"]);
                    string fAddress = Convert.ToString(dr["Address"]);
                    string fLocation = Convert.ToString(dr["Location"]);
                    int fPreviouseID = Convert.ToInt32(FactCurtMaxID);
                    int fNextID = Convert.ToInt32(FactCurtMaxID) + 2;

                    DbClass.executequery(CommandType.Text, "Insert into factory_info(Name,Description,Address,Location,DateCreated,PreviousID,NextID) values('" + fName + "','" + fDescription + "','" + fAddress + "','" + fLocation + "','" + PublicClass.GetDatetime() + "','" + fPreviouseID + "','" + fNextID + "')");
                    DataTable dtf1 = new DataTable();
                    dtf1 = DbClass.getdata(CommandType.Text, "Select Max(factory_ID)factory_ID , Max(PreviousID)PreviousID from factory_info");
                    fMaxID = dtf1.Rows[0]["factory_ID"].ToString();
                    int max = Convert.ToInt32(fMaxID);
                    int fpID = max - 1;
                    int fnID = max + 1;
                    DbClass.executequery(CommandType.Text, "Update factory_info set  PreviousID = '" + fpID + "',NextID = '" + fnID + "' where Factory_ID = '" + fMaxID + "'");

                    PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.gre;
                    Image facimage = ImageResources.Factory;
                    parentForRootForFactory1 = trlPlantManger.AppendNode(new object[] { Convert.ToString(fMaxID), trlPlantManger.Nodes.Count, Convert.ToString(fName), Convert.ToString(fDescription), Convert.ToString(fMaxID), "0", "0", "0", "0", PublicClass.FAlarmImage, "Plant", facimage }, null);
                    PasteArea(cID, max, false);
                }
            }
            catch { }
        }

        public void PasteArea(string aID, int nID, bool achk)
        {
            try
            {
                DataTable dta = new DataTable();
                if (achk)
                {
                    dta = DbClass.getdata(CommandType.Text, "Select * from area_info where Area_ID = '" + aID + "'");
                }
                else
                {
                    dta = DbClass.getdata(CommandType.Text, "Select * from area_info where factoryID = '" + aID + "'");
                }

                DataTable dta2 = new DataTable();
                dta2 = DbClass.getdata(CommandType.Text, "Select Max(Area_ID)Area_ID from area_info");
                ArCID = dta2.Rows[0]["Area_ID"].ToString();
                foreach (DataRow dr in dta.Rows)
                {
                    string aName = Convert.ToString(dr["Name"]);
                    string aDescription = Convert.ToString(dr["Description"]);
                    string aCode = Convert.ToString(dr["Code"]);
                    string aAddress = Convert.ToString(dr["Address"]);
                    string aLocation = Convert.ToString(dr["Location"]);
                    string aPosition = Convert.ToString(dr["Position"]);
                    int aPreviouseID = Convert.ToInt32(ArCID);
                    int aNextID = Convert.ToInt32(ArCID) + 2;
                    aFactoryID = Convert.ToString(dr["FactoryID"]);
                    string AreaID = Convert.ToString(dr["Area_ID"]);
                    if (achk)
                    {
                        DbClass.executequery(CommandType.Text, "Insert into area_info(Name,Description,Code,Address,Location,Position,FactoryID,PreviousID,NextID,DateCreated) values('" + aName + "','" + aDescription + "','" + aCode + "','" + aAddress + "','" + aLocation + "','" + aPosition + "','" + PublicClass.SFactoryID + "','" + aPreviouseID + "','" + aNextID + "','" + PublicClass.GetDatetime() + "')");
                        chFac = false;
                    }
                    else
                    {
                        DbClass.executequery(CommandType.Text, "Insert into area_info(Name,Description,Code,Address,Location,Position,FactoryID,PreviousID,NextID,DateCreated) values('" + aName + "','" + aDescription + "','" + aCode + "','" + aAddress + "','" + aLocation + "','" + aPosition + "','" + nID + "','" + aPreviouseID + "','" + aNextID + "','" + PublicClass.GetDatetime() + "')");
                        chFac = true;
                    }
                    DataTable dta1 = new DataTable();
                    dta1 = DbClass.getdata(CommandType.Text, "Select Max(Area_ID)Area_ID,Max(PreviousID)PreviousID from area_info");
                    aMaxID = dta1.Rows[0]["Area_ID"].ToString();
                    int amax = Convert.ToInt32(aMaxID);
                    int apID = amax - 1;
                    int anID = amax + 1;
                    DbClass.executequery(CommandType.Text, "Update area_info set PreviousID = '" + apID + "', NextID = '" + anID + "' where Area_ID = '" + aMaxID + "'");
                    PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.gre;
                    Image Areaimage = ImageResources.resource;
                    if (chFac)
                    {
                        chFac = false;
                    }
                    else
                    {
                        parentForRootForFactory1 = trlPlantManger.FocusedNode;
                    }
                    parentForRootForResorce1 = trlPlantManger.AppendNode(new object[] { Convert.ToString(aMaxID), trlPlantManger.Nodes.Count - 1, Convert.ToString(aName), Convert.ToString(aDescription), Convert.ToString(aFactoryID), Convert.ToString(aMaxID), "0", "0", "0", PublicClass.FAlarmImage, "Area", Areaimage }, parentForRootForFactory1);
                    PasteTrain(AreaID, amax, false);
                }
            }
            catch
            { }
        }

        public void PasteTrain(string tID, int nID, bool tchk)
        {
            try
            {
                DataTable dtt = new DataTable();
                if (tchk)
                {
                    dtt = DbClass.getdata(CommandType.Text, "Select * from train_info where train_ID = '" + tID + "'");
                }
                else
                {
                    dtt = DbClass.getdata(CommandType.Text, "Select * from train_info where Area_ID = '" + tID + "'");
                }

                DataTable dtt2 = new DataTable();
                dtt2 = DbClass.getdata(CommandType.Text, "Select Max(train_ID)train_ID from train_info");
                TrCID = dtt2.Rows[0]["train_ID"].ToString();
                foreach (DataRow dr in dtt.Rows)
                {
                    string aName = Convert.ToString(dr["Name"]);
                    string aDescription = Convert.ToString(dr["Description"]);
                    string aCode = Convert.ToString(dr["Code"]);
                    string aAddress = Convert.ToString(dr["Address"]);
                    string aLocation = Convert.ToString(dr["Location"]);
                    string aPosition = Convert.ToString(dr["Position"]);
                    int aPreviouseID = Convert.ToInt32(TrCID);
                    int aNextID = Convert.ToInt32(TrCID) + 2;
                    string tarinID = Convert.ToString(dr["train_ID"]);
                    if (tchk)
                    {
                        DbClass.executequery(CommandType.Text, "Insert into train_info(Name,Description,Code,Address,Location,Position,PreviousID,NextID,Area_ID,Date) values('" + aName + "','" + aDescription + "','" + aCode + "','" + aAddress + "','" + aLocation + "','" + aPosition + "','" + aPreviouseID + "','" + aNextID + "','" + PublicClass.SAreaID + "','" + PublicClass.GetDatetime() + "')");
                        chFac = false;
                    }
                    else
                    {
                        DbClass.executequery(CommandType.Text, "Insert into train_info(Name,Description,Code,Address,Location,Position,PreviousID,NextID,Area_ID,Date) values('" + aName + "','" + aDescription + "','" + aCode + "','" + aAddress + "','" + aLocation + "','" + aPosition + "','" + aPreviouseID + "','" + aNextID + "','" + nID + "','" + PublicClass.GetDatetime() + "')");
                        chFac = true;
                    }
                    DataTable dtt1 = new DataTable();
                    dtt1 = DbClass.getdata(CommandType.Text, "Select Max(train_ID)train_ID , Max(PreviousID)PreviousID from train_info");
                    tMaxID = dtt1.Rows[0]["train_ID"].ToString();
                    int tmax = Convert.ToInt32(tMaxID);
                    int tpID = tmax - 1;
                    int tnID = tmax + 1;
                    DbClass.executequery(CommandType.Text, "Update train_info set  PreviousID = '" + tpID + "' , NextID = '" + tnID + "' where train_ID = '" + tMaxID + "'");
                    PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.gre;
                    Image Trainimage = ImageResources.element1;
                    if (chFac)
                    {
                        chFac = false;
                    }
                    else
                    {
                        parentForRootForResorce1 = trlPlantManger.FocusedNode;
                    }
                    //if (sNodeType == "Plant")
                    //{
                    //    parentForRootForResorce1 = trlPlantManger.FocusedNode;
                    //}
                    //else
                    //{
                    //    parentForRootForResorce1 = trlPlantManger.FocusedNode;
                    //}

                    parentForRootForElement1 = trlPlantManger.AppendNode(new object[] { Convert.ToString(tMaxID), trlPlantManger.Nodes.Count - 1, Convert.ToString(aName), Convert.ToString(aDescription), PublicClass.SFactoryID, PublicClass.SAreaID, Convert.ToString(tMaxID), "0", "0", PublicClass.FAlarmImage, "Train", Trainimage }, parentForRootForResorce1);

                    PasteMachine(tarinID, tmax, false);
                }
            }
            catch
            {
            }
        }

        public void PasteMachine(string mID, int nID, bool mchk)
        {
            try
            {
                DataTable dtm = new DataTable();
                if (mchk)
                {
                    dtm = DbClass.getdata(CommandType.Text, "Select * from machine_info where Machine_ID = '" + mID + "'");
                }
                else
                {
                    dtm = DbClass.getdata(CommandType.Text, "Select * from machine_info where TrainID = '" + mID + "'");
                }
                DataTable dtm2 = DbClass.getdata(CommandType.Text, "Select Max(Machine_ID)Machine_ID from machine_info");
                MaCID = dtm2.Rows[0]["Machine_ID"].ToString();
                foreach (DataRow dr in dtm.Rows)
                {
                    string aName = Convert.ToString(dr["Name"]);
                    string aDescription = Convert.ToString(dr["Description"]);
                    string aPosition = Convert.ToString(PublicClass.DefVal(dr["Position"], "0"));
                    int aPreviouseID = Convert.ToInt32(MaCID);
                    int aNextID = Convert.ToInt32(MaCID) + 2;
                    string machineID = Convert.ToString(dr["Machine_ID"]);
                    string RPM = Convert.ToString(PublicClass.DefVal(dr["RPM_Driven"], "1"));
                    string PulseRev = Convert.ToString(PublicClass.DefVal(dr["PulseRev"], "1"));

                    if (mchk)
                    {
                        DbClass.executequery(CommandType.Text, "Insert into machine_info(Name,Description,TrainID,PreviousID,NextID,Position,DateCreated,RPM_Driven,PulseRev) values('" + aName + "','" + aDescription + "','" + PublicClass.STrainID + "','" + aPreviouseID + "','" + aNextID + "','" + aPosition + "','" + PublicClass.GetDatetime() + "','" + RPM + "','" + PulseRev + "')");
                        chFac = false;
                    }
                    else
                    {
                        DbClass.executequery(CommandType.Text, "Insert into machine_info(Name,Description,TrainID,PreviousID,NextID,Position,DateCreated,RPM_Driven,PulseRev) values('" + aName + "','" + aDescription + "','" + nID + "','" + aPreviouseID + "','" + aNextID + "','" + aPosition + "','" + PublicClass.GetDatetime() + "','" + RPM + "','" + PulseRev + "')");
                        chFac = true;
                    }
                    DataTable dtm1 = new DataTable();
                    dtm1 = DbClass.getdata(CommandType.Text, "Select Max(Machine_ID)Machine_ID , Max(PreviousID)PreviousID from machine_info");
                    mMaxID = dtm1.Rows[0]["Machine_ID"].ToString();
                    int mmax = Convert.ToInt32(mMaxID);
                    int mpID = mmax - 1;
                    int mnID = mmax + 1;
                    DbClass.executequery(CommandType.Text, "Update machine_info set  PreviousID = '" + mpID + "',NextID = '" + mnID + "' where Machine_ID = '" + mMaxID + "'");
                    PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.gre;
                    Image machineimage = ImageResources.subelement_new;
                    if (chFac)
                    {
                        chFac = false;
                    }
                    else
                    {
                        parentForRootForElement1 = trlPlantManger.FocusedNode;
                    }
                    parentForSubelement1 = trlPlantManger.AppendNode(new object[] { Convert.ToString(mMaxID), trlPlantManger.Nodes.Count - 1, Convert.ToString(aName), Convert.ToString(aDescription), PublicClass.SFactoryID, PublicClass.SAreaID, PublicClass.STrainID, Convert.ToString(mMaxID), "0", PublicClass.FAlarmImage, "Machine", machineimage }, parentForRootForElement1);
                    PastePoint(machineID, mmax, false);
                }
            }
            catch
            { }
        }

        public void PastePoint(string pID, int nID, bool pchk)
        {
            try
            {
                DataTable dtp = new DataTable();
                if (pchk)
                {
                    dtp = DbClass.getdata(CommandType.Text, "Select * from point where Point_ID = '" + pID + "'");
                }
                else
                {
                    dtp = DbClass.getdata(CommandType.Text, "Select * from point where Machine_ID = '" + pID + "'");
                }
                DataTable dtp2 = DbClass.getdata(CommandType.Text, "Select Max(Point_ID)Point_ID from point;");
                PtCID = dtp2.Rows[0]["Point_ID"].ToString();
                foreach (DataRow dr in dtp.Rows)
                {
                    string aName = Convert.ToString(dr["PointName"]);
                    string aDescription = Convert.ToString(dr["PointDesc"]);
                    string aPTypeID = Convert.ToString(PublicClass.DefVal(dr["PointType_ID"], "0"));
                    string aPointDispID = Convert.ToString(PublicClass.DefVal(dr["Point_DisplayID"], "0"));
                    int aPreviouseID = Convert.ToInt32(PtCID);
                    int aNextID = Convert.ToInt32(PtCID) + 2;
                    string aDShedule = Convert.ToString(dr["DataSchedule"]);
                    string aPStatus = Convert.ToString(dr["PointStatus"]);
                    string aPtSchedule = Convert.ToString(dr["PointSchedule"]);
                    if (pchk)
                    {
                        DbClass.executequery(CommandType.Text, "Insert into point(PointName,PointDesc,PointType_ID,Point_DisplayID,DataCreated,PreviousID,NextID,Machine_ID,DataSchedule,PointStatus,PointSchedule) values('" + aName + "','" + aDescription + "','" + aPTypeID + "','" + aPointDispID + "','" + PublicClass.GetDatetime() + "','" + aPreviouseID + "','" + aNextID + "','" + PublicClass.SMachineID + "','" + aDShedule + "','" + aPStatus + "','" + aPtSchedule + "')");
                        chFac = false;
                    }
                    else
                    {
                        DbClass.executequery(CommandType.Text, "Insert into point(PointName,PointDesc,PointType_ID,Point_DisplayID,DataCreated,PreviousID,NextID,Machine_ID,DataSchedule,PointStatus,PointSchedule) values('" + aName + "','" + aDescription + "','" + aPTypeID + "','" + aPointDispID + "','" + PublicClass.GetDatetime() + "','" + aPreviouseID + "','" + aNextID + "','" + nID + "','" + aDShedule + "','" + aPStatus + "','" + aPtSchedule + "')");
                        chFac = true;
                    }
                    DataTable dtp1 = new DataTable();
                    dtp1 = DbClass.getdata(CommandType.Text, "Select Max(Point_ID)Point_ID , Max(PreviousID)PreviousID from point");
                    pMaxID = dtp1.Rows[0]["Point_ID"].ToString();
                    int pmax = Convert.ToInt32(pMaxID);
                    int ppID = pmax - 1;
                    int pnID = pmax + 1;
                    DbClass.executequery(CommandType.Text, "Update point set  PreviousID = '" + ppID + "', NextID = '" + pnID + "' where Point_ID = '" + pMaxID + "'");
                    PublicClass.FAlarmImage = Iadeptmain.Images.ImageResources.gre;
                    Image pointimage = Iadeptmain.Images.ImageResources.Point;
                    if (chFac)
                    {
                        chFac = false;
                    }
                    else
                    {
                        parentForSubelement1 = trlPlantManger.FocusedNode;
                    }
                    parentForRootPoint1 = trlPlantManger.AppendNode(new object[] { Convert.ToString(pMaxID), trlPlantManger.Nodes.Count - 1, Convert.ToString(aName), Convert.ToString(aDescription), PublicClass.SFactoryID, PublicClass.SAreaID, PublicClass.STrainID, PublicClass.SMachineID, Convert.ToString(pMaxID), PublicClass.FAlarmImage, "Point", pointimage }, parentForSubelement1);
                    chFac = true;
                    trlPlantManger.ExpandAll();
                }
            }
            catch
            {
            }
        }
     
        string BDIR = null;
        string BDOR = null;
        string BCA = null;
        string BDRE = null;
        string BNRE = null;
        bool PhysicalBearingSettings = false;
        public bool _ISPhysicalBearingSettings
        {
            get
            {
                return PhysicalBearingSettings;
            }
            set
            {
                PhysicalBearingSettings = value;
            }
        }
        public string _BDIR
        {
            get
            {
                return BDIR;
            }
            set
            {
                BDIR = value;
            }
        }
        public string _BDOR
        {
            get
            {
                return BDOR;
            }
            set
            {
                BDOR = value;
            }
        }
        public string _BCA
        {
            get
            {
                return BCA;
            }
            set
            {
                BCA = value;
            }
        }
        public string _BDRE
        {
            get
            {
                return BDRE;
            }
            set
            {
                BDRE = value;
            }
        }
        public string _BNRE
        {
            get
            {
                return BNRE;
            }
            set
            {
                BNRE = value;
            }
        }
        string BrBalls = "0";
        string BrBPFI = "0";
        string BrBPFO = "0";
        string BrBSF = "0";
        string BrFTF = "0";
        public string _Balls
        {
            get
            {
                return BrBalls;
            }
            set
            {
                BrBalls = value;
            }
        }
        public string _FTF
        {
            get
            {
                return BrFTF;
            }
            set
            {
                BrFTF = value;
            }
        }
        public string _BPFI
        {
            get
            {
                return BrBPFI;
            }
            set
            {
                BrBPFI = value;
            }
        }
        public string _BPFO
        {
            get
            {
                return BrBPFO;
            }
            set
            {
                BrBPFO = value;
            }
        }
        public string _BSF
        {
            get
            {
                return BrBSF;
            }
            set
            {
                BrBSF = value;
            }
        }

        public string[] GetRPMValues(string pointID)
        {
            string Pulse = "1"; string Rpm = "1";
            string[] RPMValues = new string[2];
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "Select mac.PulseRev,pd.ordertrace_rpm from point_data pd inner join point pt on pt.point_id=pd.point_id left join machine_info  mac on mac.machine_id=pt.machine_id where pd.Data_ID in(select max(Data_ID) as Data_ID from point_data where Point_ID = '" + pointID + "')");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Pulse = Convert.ToString(dr["PulseRev"]);
                        Rpm = Convert.ToString(dr["ordertrace_rpm"]);
                        if (Rpm == "0")
                        {
                            DataTable dt1 = new DataTable();
                            dt1 = DbClass.getdata(CommandType.Text, "Select PulseRev,rpm_driven from machine_info where machine_id = '" + PublicClass.SMachineID + "'");
                            foreach (DataRow dr1 in dt1.Rows)
                            {
                                Pulse = Convert.ToString(dr1["PulseRev"]);
                                Rpm = Convert.ToString(dr1["rpm_driven"]);
                            }
                        }
                    }
                }
                else
                {
                    DataTable dt2 = new DataTable();
                    dt2 = DbClass.getdata(CommandType.Text, "Select PulseRev,rpm_driven from machine_info where machine_id = '" + PublicClass.SMachineID + "'");
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        Pulse = Convert.ToString(dr2["PulseRev"]);
                        Rpm = Convert.ToString(dr2["rpm_driven"]);
                    }
                }
                txtPulse.Text = Pulse;
                txtRpm.Text = Rpm;
            }
            catch (Exception ex)
            {
            }
            RPMValues[0] = Rpm;
            RPMValues[1] = Pulse;
            return RPMValues;
        }
       
        private void tsaxail_Click(object sender, EventArgs e)
        {
            try
            {
                PublicClass.checkgraphtime = "false";
                string T_X = null;
                string P_X = null;
                string P1_X = null;
                string P2_X = null; ;
                string P21_X = null;
                string P3_X = null;
                string P31_X = null;
                string CEP_X = null;
                string DEM_X = null;
                if (PublicClass.SPointID != "0")
                {
                    try
                    {
                        string CurrentInstName = PublicClass.currentInstrument;
                        if (CurrentInstName == "Impaq-Benstone" || CurrentInstName == "SKF/DI" || PublicClass.currentInstrument == "FieldPaq2")
                        {
                            PublicClass.ssNodeType = sNodeType;
                            PublicClass.AHVCH1 = "Axial";
                        }
                        if (graph.IsDisposed)
                        {
                            graph = new PointGeneral1();
                            graph.MainForm1 = _objMain;
                            graph.grp = m_graph;

                            DataTable dt = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,timeA_X,timeA_Y,PA_X,PA_Y,P1A_X,P1A_Y,P2A_X,P2A_Y,P21A_X,P21A_Y,P3A_X,P3A_Y,P31A_X,P31A_Y,CEPA_X,CEPA_Y,DEMA_X,DEMA_Y FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
                            foreach (DataRow DR in dt.Rows)
                            {
                                T_X = Convert.ToString(DR["timeA_X"]);
                                P_X = Convert.ToString(DR["PA_X"]);
                                P1_X = Convert.ToString(DR["P1A_X"]);
                                P2_X = Convert.ToString(DR["P2A_X"]);
                                P21_X = Convert.ToString(DR["P21A_X"]);
                                P3_X = Convert.ToString(DR["P3A_X"]);
                                P31_X = Convert.ToString(DR["P31A_X"]);
                                CEP_X = Convert.ToString(DR["CEPA_X"]);
                                DEM_X = Convert.ToString(DR["DEMA_X"]);
                            }
                            if (T_X != null || P_X != null || P1_X != null || P2_X != null || P21_X != null || P3_X != null || P31_X != null || CEP_X != null || DEM_X != null)
                            {

                                if (T_X != "0|" || P_X != "0|" || P1_X != "0|" || P2_X != "0|" || P21_X != "0|" || P3_X != "0|" || P31_X != "0|" || CEP_X != "0|" || DEM_X != "0|")
                                {
                                    if (T_X != "" || P_X != "" || P1_X != "" || P2_X != "" || P21_X != "" || P3_X != "" || P31_X != "" || CEP_X != "" || DEM_X != "")
                                    {
                                        graph.TopLevel = false;
                                        pnlGraph.Controls.Add(graph);
                                        if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                                        {
                                            graph.Showgraphs();
                                        }
                                        else
                                        { graph.ShowgraphsforDI(); }
                                        graph.Dock = DockStyle.Fill;
                                        TabGraph.PageVisible = true;
                                        CtrTab.SelectedTabPageIndex = 12;
                                        graph.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            graph.MainForm1 = _objMain;
                            graph.grp = m_graph;
                            DataTable dt = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,timeA_X,timeA_Y,PA_X,PA_Y,P1A_X,P1A_Y,P2A_X,P2A_Y,P21A_X,P21A_Y,P3A_X,P3A_Y,P31A_X,P31A_Y,CEPA_X,CEPA_Y,DEMA_X,DEMA_Y FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
                            foreach (DataRow DR in dt.Rows)
                            {
                                T_X = Convert.ToString(DR["timeA_X"]);
                                P_X = Convert.ToString(DR["PA_X"]);
                                P1_X = Convert.ToString(DR["P1A_X"]);
                                P2_X = Convert.ToString(DR["P2A_X"]);
                                P21_X = Convert.ToString(DR["P21A_X"]);
                                P3_X = Convert.ToString(DR["P3A_X"]);
                                P31_X = Convert.ToString(DR["P31A_X"]);
                                CEP_X = Convert.ToString(DR["CEPA_X"]);
                                DEM_X = Convert.ToString(DR["DEMA_X"]);
                            }
                            if (T_X != null || P_X != null || P1_X != null || P2_X != null || P21_X != null || P3_X != null || P31_X != null || CEP_X != null || DEM_X != null)
                            {

                                if (T_X != "0|" || P_X != "0|" || P1_X != "0|" || P2_X != "0|" || P21_X != "0|" || P3_X != "0|" || P31_X != "0|" || CEP_X != "0|" || DEM_X != "0|")
                                {
                                    if (T_X != "" || P_X != "" || P1_X != "" || P2_X != "" || P21_X != "" || P3_X != "" || P31_X != "" || CEP_X != "" || DEM_X != "")
                                    {
                                        graph.TopLevel = false;
                                        pnlGraph.Controls.Add(graph);
                                        if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                                        {
                                            graph.Showgraphs();
                                        }
                                        else
                                        { graph.ShowgraphsforDI(); }
                                        graph.Dock = DockStyle.Fill;
                                        TabGraph.PageVisible = true;
                                        CtrTab.SelectedTabPageIndex = 12;
                                        graph.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }
            _objMain.lblStatus.Caption = "Data Collected Date: " + PublicClass.tym + "";
        }

        public void deleteimage()
        {
            string path = Path.GetTempPath();
            string ss = path + "Time.jpg";
            if (File.Exists(ss))
            {
                File.Delete(ss);
            }
        }

        private void tshorizontal_Click(object sender, EventArgs e)
        {
            try
            {
                PublicClass.checkgraphtime = "false";
                string T_X = null;
                string P_X = null;
                string P1_X = null;
                string P2_X = null; ;
                string P21_X = null;
                string P3_X = null;
                string P31_X = null;
                string CEP_X = null;
                string DEM_X = null;
                if (PublicClass.SPointID != "0")
                {
                    try
                    {
                        string CurrentInstName = PublicClass.currentInstrument;
                        if (CurrentInstName == "Impaq-Benstone" || CurrentInstName == "SKF/DI" || PublicClass.currentInstrument == "FieldPaq2")
                        {
                            PublicClass.ssNodeType = sNodeType;
                            PublicClass.AHVCH1 = "Horizontal";
                        }
                        if (graph.IsDisposed)
                        {
                            graph = new PointGeneral1();
                            graph.MainForm1 = _objMain;
                            graph.grp = m_graph;
                            DataTable dt1 = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,timeH_X,timeH_Y,PH_X,PH_Y,P1H_X,P1H_Y,P2H_X,P2H_Y,P21H_X,P21H_Y,P3H_X,P3H_Y,P31H_X,P31H_Y,CEPH_X,CEPH_Y,DEMH_X,DEMH_Y FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
                            foreach (DataRow DR in dt1.Rows)
                            {
                                T_X = Convert.ToString(DR["timeH_X"]);
                                P_X = Convert.ToString(DR["PH_X"]);
                                P1_X = Convert.ToString(DR["P1H_X"]);
                                P2_X = Convert.ToString(DR["P2H_X"]);
                                P21_X = Convert.ToString(DR["P21H_X"]);
                                P3_X = Convert.ToString(DR["P3H_X"]);
                                P31_X = Convert.ToString(DR["P31H_X"]);
                                CEP_X = Convert.ToString(DR["CEPH_X"]);
                                DEM_X = Convert.ToString(DR["DEMH_X"]);

                            }
                            if (T_X != null || P_X != null || P1_X != null || P2_X != null || P21_X != null || P3_X != null || P31_X != null || CEP_X != null || DEM_X != null)
                            {
                                if (T_X != "0|" || P_X != "0|" || P1_X != "0|" || P2_X != "0|" || P21_X != "0|" || P3_X != "0|" || P31_X != "0|" || CEP_X != "0|" || DEM_X != "0|")
                                {
                                    if (T_X != "" || P_X != "" || P1_X != "" || P2_X != "" || P21_X != "" || P3_X != "" || P31_X != "" || CEP_X != "" || DEM_X != "")
                                    {
                                        graph.TopLevel = false;
                                        pnlGraph.Controls.Add(graph);
                                        if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                                        {
                                            graph.Showgraphs();
                                        }
                                        else
                                        { graph.ShowgraphsforDI(); }
                                        graph.Dock = DockStyle.Fill;
                                        TabGraph.PageVisible = true;
                                        CtrTab.SelectedTabPageIndex = 12;
                                        graph.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            graph.MainForm1 = _objMain;
                            graph.grp = m_graph;
                            DataTable dt1 = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,timeH_X,timeH_Y,PH_X,PH_Y,P1H_X,P1H_Y,P2H_X,P2H_Y,P21H_X,P21H_Y,P3H_X,P3H_Y,P31H_X,P31H_Y,CEPH_X,CEPH_Y,DEMH_X,DEMH_Y FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
                            foreach (DataRow DR in dt1.Rows)
                            {
                                T_X = Convert.ToString(DR["timeH_X"]);
                                P_X = Convert.ToString(DR["PH_X"]);
                                P1_X = Convert.ToString(DR["P1H_X"]);
                                P2_X = Convert.ToString(DR["P2H_X"]);
                                P21_X = Convert.ToString(DR["P21H_X"]);
                                P3_X = Convert.ToString(DR["P3H_X"]);
                                P31_X = Convert.ToString(DR["P31H_X"]);
                                CEP_X = Convert.ToString(DR["CEPH_X"]);
                                DEM_X = Convert.ToString(DR["DEMH_X"]);
                            }
                            if (T_X != null || P_X != null || P1_X != null || P2_X != null || P21_X != null || P3_X != null || P31_X != null || CEP_X != null || DEM_X != null)
                            {
                                if (T_X != "0|" || P_X != "0|" || P1_X != "0|" || P2_X != "0|" || P21_X != "0|" || P3_X != "0|" || P31_X != "0|" || CEP_X != "0|" || DEM_X != "0|")
                                {
                                    if (T_X != "" || P_X != "" || P1_X != "" || P2_X != "" || P21_X != "" || P3_X != "" || P31_X != "" || CEP_X != "" || DEM_X != "")
                                    {
                                        graph.TopLevel = false;
                                        pnlGraph.Controls.Add(graph);
                                        if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                                        {
                                            graph.Showgraphs();
                                        }
                                        else
                                        { graph.ShowgraphsforDI(); }
                                        graph.Dock = DockStyle.Fill;
                                        TabGraph.PageVisible = true;
                                        CtrTab.SelectedTabPageIndex = 12;
                                        graph.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }                        
                    }
                    catch { }
                }
            }
            catch { }
            _objMain.lblStatus.Caption = "Data Collected Date: " + PublicClass.tym + "";
        }

        private void tsvertical_Click(object sender, EventArgs e)
        {
            try
            {
                PublicClass.checkgraphtime = "false";
                string T_X = null;
                string P_X = null;
                string P1_X = null;
                string P2_X = null; ;
                string P21_X = null;
                string P3_X = null;
                string P31_X = null;
                string CEP_X = null;
                string DEM_X = null;
                if (PublicClass.SPointID != "0")
                {
                    try
                    {
                        string CurrentInstName =PublicClass.currentInstrument;
                        if (CurrentInstName == "Impaq-Benstone" || CurrentInstName == "SKF/DI" || PublicClass.currentInstrument == "FieldPaq2")
                        {
                            PublicClass.ssNodeType = sNodeType;
                            PublicClass.AHVCH1 = "Vertical";
                        }
                        if (graph.IsDisposed)
                        {
                            graph = new PointGeneral1();
                            graph.MainForm1 = _objMain;
                            graph.grp = m_graph;


                            DataTable dt2 = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,timeV_X,timeV_Y,PV_X,PV_Y,P1V_X,P1V_Y,P2V_X,P2V_Y,P21V_X,P21V_Y,P3V_X,P3V_Y,P31V_X,P31V_Y,CEPV_X,CEPV_Y,DEMV_X,DEMV_Y FROM point_data where point_ID = '" + PublicClass.SPointID + "'");
                            foreach (DataRow DR in dt2.Rows)
                            {

                                T_X = Convert.ToString(DR["timeV_X"]);
                                P_X = Convert.ToString(DR["PV_X"]);
                                P1_X = Convert.ToString(DR["P1V_X"]);
                                P2_X = Convert.ToString(DR["P2V_X"]);
                                P21_X = Convert.ToString(DR["P21V_X"]);
                                P3_X = Convert.ToString(DR["P3V_X"]);
                                P31_X = Convert.ToString(DR["P31V_X"]);
                                CEP_X = Convert.ToString(DR["CEPV_X"]);
                                DEM_X = Convert.ToString(DR["DEMV_X"]);

                               
                            }
                            if (T_X != null || P_X != null || P1_X != null || P2_X != null || P21_X != null || P3_X != null || P31_X != null || CEP_X != null || DEM_X != null)
                            {

                                if (T_X != "0|" || P_X != "0|" || P1_X != "0|" || P2_X != "0|" || P21_X != "0|" || P3_X != "0|" || P31_X != "0|" || CEP_X != "0|" || DEM_X != "0|")
                                {
                                    if (T_X != "" || P_X != "" || P1_X != "" || P2_X != "" || P21_X != "" || P3_X != "" || P31_X != "" || CEP_X != "" || DEM_X != "")
                                    {
                                        graph.TopLevel = false;
                                        pnlGraph.Controls.Add(graph);
                                        if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                                        {
                                            graph.Showgraphs();
                                        }
                                        else
                                        { graph.ShowgraphsforDI(); }
                                        graph.Dock = DockStyle.Fill;
                                        TabGraph.PageVisible = true;
                                        CtrTab.SelectedTabPageIndex = 12;
                                        graph.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            graph.MainForm1 = _objMain;
                            graph.grp = m_graph;
                            DataTable dt2 = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,timeV_X,timeV_Y,PV_X,PV_Y,P1V_X,P1V_Y,P2V_X,P2V_Y,P21V_X,P21V_Y,P3V_X,P3V_Y,P31V_X,P31V_Y,CEPV_X,CEPV_Y,DEMV_X,DEMV_Y FROM point_data where point_ID = '" + PublicClass.SPointID + "'");
                            foreach (DataRow DR in dt2.Rows)
                            {
                                T_X = Convert.ToString(DR["timeV_X"]);
                                P_X = Convert.ToString(DR["PV_X"]);
                                P1_X = Convert.ToString(DR["P1V_X"]);
                                P2_X = Convert.ToString(DR["P2V_X"]);
                                P21_X = Convert.ToString(DR["P21V_X"]);
                                P3_X = Convert.ToString(DR["P3V_X"]);
                                P31_X = Convert.ToString(DR["P31V_X"]);
                                CEP_X = Convert.ToString(DR["CEPV_X"]);
                                DEM_X = Convert.ToString(DR["DEMV_X"]);                                
                            }
                            if (T_X != null || P_X != null || P1_X != null || P2_X != null || P21_X != null || P3_X != null || P31_X != null || CEP_X != null || DEM_X != null)
                            {

                                if (T_X != "0|" || P_X != "0|" || P1_X != "0|" || P2_X != "0|" || P21_X != "0|" || P3_X != "0|" || P31_X != "0|" || CEP_X != "0|" || DEM_X != "0|")
                                {
                                    if (T_X != "" || P_X != "" || P1_X != "" || P2_X != "" || P21_X != "" || P3_X != "" || P31_X != "" || CEP_X != "" || DEM_X != "")
                                    {
                                        graph.TopLevel = false;
                                        pnlGraph.Controls.Add(graph);
                                        if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                                        {
                                            graph.Showgraphs();
                                        }
                                        else
                                        { graph.ShowgraphsforDI(); }
                                        graph.Dock = DockStyle.Fill;
                                        TabGraph.PageVisible = true;
                                        CtrTab.SelectedTabPageIndex = 12;
                                        graph.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }
            _objMain.lblStatus.Caption = "Data Collected Date: " + PublicClass.tym + "";
        }

        private void tschannel1_Click(object sender, EventArgs e)
        {
            try
            {
                PublicClass.checkgraphtime = "false";
                string T_X = null;
                string P_X = null;
                string P1_X = null;
                string P2_X = null; ;
                string P21_X = null;
                string P3_X = null;
                string P31_X = null;
                string CEP_X = null;
                string DEM_X = null;
                if (PublicClass.SPointID != "0")
                {
                    try
                    {
                        string CurrentInstName = PublicClass.currentInstrument;
                        if (CurrentInstName == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                        {
                            PublicClass.ssNodeType = sNodeType;
                            PublicClass.AHVCH1 = "Channel1";
                        }
                        if (graph.IsDisposed)
                        {
                            graph = new PointGeneral1();
                            graph.MainForm1 = _objMain;
                            graph.grp = m_graph;
                            DataTable dt3 = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,timeCH1_X,timeCH1_Y,PCH1_X,PCH1_Y,P1CH1_X,P1CH1_Y,P2CH1_X,P2CH1_Y,P21CH1_X,P21CH1_Y,P3CH1_X,P3CH1_Y,P31CH1_X,P31CH1_Y,CEPCH1_X,CEPCH1_Y,DEMCH1_X,DEMCH1_Y FROM point_data where point_ID = '" + PublicClass.SPointID + "'");
                            foreach (DataRow DR in dt3.Rows)
                            {
                                T_X = Convert.ToString(DR["timeCH1_X"]);
                                P_X = Convert.ToString(DR["PCH1_X"]);
                                P1_X = Convert.ToString(DR["P1CH1_X"]);
                                P2_X = Convert.ToString(DR["P2CH1_X"]);
                                P21_X = Convert.ToString(DR["P21CH1_X"]);
                                P3_X = Convert.ToString(DR["P3CH1_X"]);
                                P31_X = Convert.ToString(DR["P31CH1_X"]);
                                CEP_X = Convert.ToString(DR["CEPCH1_X"]);
                                DEM_X = Convert.ToString(DR["DEMCH1_X"]);

                            }
                            if (T_X != null || P_X != null || P1_X != null || P2_X != null || P21_X != null || P3_X != null || P31_X != null || CEP_X != null || DEM_X != null)
                            {

                                if (T_X != "0|" || P_X != "0|" || P1_X != "0|" || P2_X != "0|" || P21_X != "0|" || P3_X != "0|" || P31_X != "0|" || CEP_X != "0|" || DEM_X != "0|")
                                {
                                    if (T_X != "" || P_X != "" || P1_X != "" || P2_X != "" || P21_X != "" || P3_X != "" || P31_X != "" || CEP_X != "" || DEM_X != "")
                                    {
                                        graph.TopLevel = false;
                                        pnlGraph.Controls.Add(graph);
                                        graph.Showgraphs();
                                        graph.Dock = DockStyle.Fill;
                                        TabGraph.PageVisible = true;
                                        CtrTab.SelectedTabPageIndex = 12;
                                        graph.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            graph.MainForm1 = _objMain;
                            graph.grp = m_graph;
                            DataTable dt3 = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,timeCH1_X,timeCH1_Y,PCH1_X,PCH1_Y,P1CH1_X,P1CH1_Y,P2CH1_X,P2CH1_Y,P21CH1_X,P21CH1_Y,P3CH1_X,P3CH1_Y,P31CH1_X,P31CH1_Y,CEPCH1_X,CEPCH1_Y,DEMCH1_X,DEMCH1_Y FROM point_data where point_ID = '" + PublicClass.SPointID + "'");
                            foreach (DataRow DR in dt3.Rows)
                            {
                                T_X = Convert.ToString(DR["timeCH1_X"]);
                                P_X = Convert.ToString(DR["PCH1_X"]);
                                P1_X = Convert.ToString(DR["P1CH1_X"]);
                                P2_X = Convert.ToString(DR["P2CH1_X"]);
                                P21_X = Convert.ToString(DR["P21CH1_X"]);
                                P3_X = Convert.ToString(DR["P3CH1_X"]);
                                P31_X = Convert.ToString(DR["P31CH1_X"]);
                                CEP_X = Convert.ToString(DR["CEPCH1_X"]);
                                DEM_X = Convert.ToString(DR["DEMCH1_X"]);

                            }
                            if (T_X != null || P_X != null || P1_X != null || P2_X != null || P21_X != null || P3_X != null || P31_X != null || CEP_X != null || DEM_X != null)
                            {
                                if (T_X != "0|" || P_X != "0|" || P1_X != "0|" || P2_X != "0|" || P21_X != "0|" || P3_X != "0|" || P31_X != "0|" || CEP_X != "0|" || DEM_X != "0|")
                                {
                                    if (T_X != "" || P_X != "" || P1_X != "" || P2_X != "" || P21_X != "" || P3_X != "" || P31_X != "" || CEP_X != "" || DEM_X != "")
                                    {
                                        graph.TopLevel = false;
                                        pnlGraph.Controls.Add(graph);
                                        graph.Showgraphs();
                                        graph.Dock = DockStyle.Fill;
                                        TabGraph.PageVisible = true;
                                        CtrTab.SelectedTabPageIndex = 12;
                                        graph.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Data is not available on this Point at this direction", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }
            _objMain.lblStatus.Caption = "Data Collected Date: " + PublicClass.tym + "";
        }

        string FName = null;
        string BAName = null;
        double FValue;
        double fCount;
        private void dgvFaultFreq_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string cColumn = null;
            cColumn = dgvFaultFreq.Columns[e.ColumnIndex].HeaderText;
            switch (cColumn)
            {
                case "Frequency Name":
                    {
                        FName = Convert.ToString(dgvFaultFreq.CurrentRow.Cells["ColFFName"].Value).Trim();
                        if (FName.Trim() == "")
                        {
                            MessageBox.Show(this, "Name can not be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvFaultFreq.CurrentRow.Cells["ColFFName"].Value = " ";
                        }
                        break;
                    }

                case "Frequency Value":
                    {
                        FValue = Convert.ToDouble(PublicClass.DefVal(Convert.ToString((dgvFaultFreq.CurrentRow.Cells["ColFFValue"].Value)).Trim(), "0"));
                        int fvalueIndex = dgvFaultFreq.CurrentRow.Index;
                        if (fvalueIndex == 0)
                        {

                            double nRowValue = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dgvFaultFreq.Rows[fvalueIndex + 1].Cells["ColFFValue"].Value), "0"));
                            if (nRowValue != 0)
                            {
                                if (nRowValue <= FValue)
                                {
                                    MessageBox.Show("Frequency value can not be greater than from existing Band Alarm");
                                    dgvFaultFreq.CurrentRow.Cells["ColFFValue"].Value = " ";
                                }
                            }
                        }
                        else
                        {
                            int fAval = dgvFaultFreq.CurrentRow.Index - 1;

                            fCount = Convert.ToDouble(dgvFaultFreq.Rows[fAval].Cells["ColFFValue"].Value);

                            if (fCount >= FValue)
                            {
                                MessageBox.Show("Frequency value can not be Equal or Less than from existing Band Alarm");
                                dgvFaultFreq.CurrentRow.Cells["ColFFValue"].Value = " ";
                            }
                        }
                        break;
                    }
            }
        }

        private void dgvFaultFreq_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvFaultFreq.IsCurrentCellDirty)
            {
                dgvFaultFreq.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvFaultFreq_KeyDown(object sender, KeyEventArgs e)
        {   
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    int ee = dgvFaultFreq.CurrentRow.Index;
                    string fidd = PublicClass.DefVal(Convert.ToString(dgvFaultFreq.CurrentRow.Cells["PF_IDD"].Value).Trim(), "0");
                    DbClass.executequery(CommandType.StoredProcedure, "call Delete_FaultFrequencyById('" + fidd + "')");
                    dgvFaultFreq.Rows.RemoveAt(ee);
                }
            }
            catch
            {
            }
        }

        public void showFFreqdata()
        {
            try
            {
                DataTable DT = (DataTable)dgvFaultFreq.DataSource;
                if (DT != null)
                    DT.Clear();
                DataTable dtt = new DataTable();                
                dtt = DbClass.getdata(CommandType.StoredProcedure, "call Get_Faultfrequency('" + PublicClass.SPointID.Trim() + "')");
                int a = 0;
                dgvFaultFreq.Rows.Clear();
                foreach (DataRow dr in dtt.Rows)
                {
                    dgvFaultFreq.Rows.Add();
                    dgvFaultFreq.Rows[a].Cells["ColFFName"].Value = Convert.ToString(dr["pf_name"]);
                    dgvFaultFreq.Rows[a].Cells["ColFFValue"].Value = Convert.ToString(dr["pf_freq"]);
                    dgvFaultFreq.Rows[a].Cells["PF_IDD"].Value = Convert.ToString(dr["pf_id"]);                    
                    a = a + 1;
                }                
            }
            catch { }
        }

        private void dgvFaultFreq_Leave(object sender, EventArgs e)
        {
            try
            {
                if (PublicClass.SPointID == "0")
                {
                    MessageBox.Show("You should select point first");
                    return;
                }
                else
                {
                    for (int b = 0; b < dgvFaultFreq.Rows.Count - 1; b++)
                    {
                        FName = Convert.ToString(PublicClass.DefVal(Convert.ToString((dgvFaultFreq.Rows[b].Cells["ColFFName"].Value)).Trim(), "0"));
                        FValue = Convert.ToDouble(PublicClass.DefVal(Convert.ToString((dgvFaultFreq.Rows[b].Cells["ColFFValue"].Value)).Trim(), "0"));

                        string pff_id = PublicClass.DefVal(Convert.ToString(dgvFaultFreq.Rows[b].Cells["PF_IDD"].Value).Trim(), "0");

                        if (FName == " " || FValue == 0)
                        {
                            MessageBox.Show("Please Insert all Columns");
                            return;
                        }

                        DataTable dt = new DataTable();
                        dt = DbClass.getdata(CommandType.StoredProcedure, " call Get_FaultFrequencyByID ('" + PublicClass.DefVal(Convert.ToString(dgvFaultFreq.Rows[b].Cells["PF_IDD"].Value), "0") + "')");

                        if (dt.Rows.Count <= 0)
                        {
                            DbClass.executequery(CommandType.StoredProcedure, "call Insert_FaultFrequency('" + FName.Trim() + "' , '" + FValue + "' , '" + PublicClass.GetDatetime() + "','" + PublicClass.SPointID + "')");
                            DataTable DT = new DataTable();
                            DT = DbClass.getdata(CommandType.StoredProcedure, " call Get_MaxFFreqId ");
                            dgvFaultFreq.Rows[b].Cells["PF_IDD"].Value = Convert.ToString(Convert.ToInt32(PublicClass.DefVal(Convert.ToString(DT.Rows[0][0]), "0")));

                        }
                        else
                        {
                            if ((FName != Convert.ToString(dt.Rows[b]["pf_name"]).Trim()) || (FValue != Convert.ToDouble(Convert.ToString(dt.Rows[b]["pf_freq"]).Trim())))
                            {
                                DbClass.executequery(CommandType.StoredProcedure, " call Update_FaultFrequency( '" + FName + "' , '" + FValue + "' ,  '" + PublicClass.GetDatetime() + "', '" + pff_id + "')");
                            }
                        }
                    }
                }

            }
            catch { }
        }
       
        private void groupControl4_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if(PublicClass.currentInstrument=="SKF/DI")
                {
                    DataTable dt1 = DbClass.getdata(CommandType.Text, "select * from point where pointname='" + txtpointname1.Text + "' and machine_id='" + PublicClass.SMachineID + "' and point_id!='" + txtpointid.Text + "'");
                    if (dt1.Rows.Count > 0)
                    {
                        DataTable dt2 = DbClass.getdata(CommandType.Text, "select * from point where point_id='" + txtpointid.Text + "'");
                        MessageBox.Show(this, "Point Name Already Exit in this machine", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtpointname1.Text = Convert.ToString(dt2.Rows[0]["pointname"]);
                        return;
                    }
                    
                }
                if (sNodeType == "Point" && Convert.ToString(txtpointname1.Text).Trim() != "")
                {
                    data = PublicClass.DefVal(Convert.ToString(txtDataSchedule.Text).Trim(), "7");
                    selection = Convert.ToString(cmbDaysSelection.SelectedItem);
                    dataschedule = Convert.ToString(data + " " + selection);
                    DbClass.executequery(CommandType.Text, "update  point set pointname= '" + txtpointname1.Text + "' , pointdesc = '" + txtpointdetail1.Text + "' , DataSchedule ='" + dataschedule + "' ,pointtype_id = '" + Convert.ToString(CmbPointType.SelectedValue) + "' where Point_ID = '" + Convert.ToString(txtpointid.Text).Trim() + "' ");
                    //--for uff & wav only---//
                    DataTable dt = DbClass.getdata(CommandType.Text, "select * from point_data where point_type='" + Convert.ToString(CmbPointType.SelectedValue) + "'");
                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToString(dt.Rows[0]["Point_ID"]) == "0")
                        {
                            PublicClass.Data_ID = Convert.ToString(dt.Rows[0]["Data_ID"]);
                            DbClass.executequery(CommandType.Text, "update  point_data set point_id='" + PublicClass.SPointID + "',point_name='" + txtpointname1.Text + "' where point_type='" + Convert.ToString(CmbPointType.SelectedValue) + "' and data_id='" + PublicClass.Data_ID + "' ");
                        }

                    }
                    trlPlantManger.FocusedNode.SetValue(2, txtpointname1.Text);
                }
            }
            catch { }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmPointInfo frmpinfo = new frmPointInfo();
                frmpinfo.Show();
            }
            catch { }
        }
        
        BearingFF_Interface _BFFInterface = new BearingFF_Control();

        private void btnxCalculateFreq_Click(object sender, EventArgs e)
        {
            bool bError = false;
            try
            {
                double NumberOfBalls = Convert.ToDouble(txtxBNRE.Text.ToString());
                double BearingPitchDiameter = Convert.ToDouble(((Convert.ToDouble(txtxBDIR.Text.ToString()) + Convert.ToDouble(txtxBDOR.Text.ToString())) / 2));
                double RollingElementDiameter = Convert.ToDouble(txtxBDRE.Text.ToString());
                double ContactAngle = Convert.ToDouble(txtxBCA.Text.ToString());
                double ShaftSpeed = 1;

                if (NumberOfBalls <= 0)
                {
                    MessageBoxEx.Show("Number of Balls/Rolling Elements must be greater than 0", "Ball Error");
                    bError = true;
                    txtxBNRE.Focus();
                }
                else if (BearingPitchDiameter <= 0)
                {
                    MessageBoxEx.Show("Outer race and Inner race should be greater than 0 " + "\n" + "and" + "\n" + "Outer race should be greater than Inner Race", "Bearing Pitch Error");
                    txtxBDIR.Focus();
                    bError = true;
                }
                else if (RollingElementDiameter <= 0)
                {
                    MessageBoxEx.Show("Balls/Rolling Element diameter should be greater than 0", "Ball Error");
                    txtxBDRE.Focus();
                    bError = true;
                }
                else if (RollingElementDiameter >= BearingPitchDiameter)
                {
                    MessageBoxEx.Show("Ball Diameter should be less than Bearing Pitch Diameter", "Ball Error");
                    txtxBDRE.Focus();
                    bError = true;
                }

                if (!bError)
                {
                    ArrayList BearingFaultFrequencies = _BFFInterface.CalculateBearingFaultFrequencies(ShaftSpeed, NumberOfBalls, BearingPitchDiameter, RollingElementDiameter, ContactAngle);
                    tbBalls.Text = NumberOfBalls.ToString();
                    tbBPFI.Text = _BFFInterface._BPFI.ToString();
                    tbBPFO.Text = _BFFInterface._BPFO.ToString();
                    tbBSF.Text = _BFFInterface._BSF.ToString();
                    tbFTF.Text = _BFFInterface._FTF.ToString();
                }
                _Balls = tbBalls.Text;
                _BPFI = tbBPFI.Text;
                _BPFO = tbBPFO.Text;
                _BSF = tbBSF.Text;
                _FTF = tbFTF.Text;
            }
            catch (Exception ex)
            {
                txtxBNRE.Focus();
                MessageBoxEx.Show("Enter Correct data", "Wrong Data");                
            }
        }

        private void gbBearingFF_Leave(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            bool addrow = true;
            for (int a = 0; a < DgvMachine.Rows.Count; a++)
            {
                if (Convert.ToString(DgvMachine.Rows[a].Cells["G_Machine"].Value).Trim() == "")
                {
                    addrow = false;
                }

            }
            if (addrow == true)
            {
                DgvMachine.Rows.Add();
                for (int a = 0; a < DgvMachine.Rows.Count; a++)
                {
                    DgvMachine.Rows[a].Cells["G_Machine"].Value = MachineName;
                }
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            try
            {
                int ee = DgvMachine.CurrentRow.Index;
                string bidd = PublicClass.DefVal(Convert.ToString(DgvMachine.CurrentRow.Cells["col_id"].Value).Trim(), "0");
                DbClass.executequery(CommandType.Text, "delete from machine_record Where ID = '" + bidd + "'");
                DgvMachine.Rows.RemoveAt(ee);
            }
            catch
            {
            }
        }

        double acca = 0;
        double acch = 0;
        double accv = 0;
        double accch1 = 0;
        double vela = 0;
        double velh = 0;
        double velv = 0;
        double velch1 = 0;
        double disa = 0;
        double dish = 0;
        double disv = 0;
        double disch1 = 0;
        double bera = 0;
        double berh = 0;
        double berv = 0;
        double berch1 = 0;
        double cfa = 0;
        double cfh = 0;
        double cfv = 0;
        double cfch1 = 0;
        double otreala = 0;
        double otimagea = 0;
        double otrealh = 0;
        double otimageh = 0;
        double otrealv = 0;
        double otimagev = 0;
        double otrealch1 = 0;
        double otimagech1 = 0;
        double rpm = 0;
        double temp = 0;
        string note1 = null;
        string note2 = null;
        int count;

        private void Dgv_data_Leave(object sender, EventArgs e)
        {
            try
            {
                for (int a = 0; a < Dgv_data.Rows.Count; a++)
                {
                    acca = Convert.ToDouble(Dgv_data.Rows[a].Cells["ColAacc"].Value);
                    acch = Convert.ToDouble(Dgv_data.Rows[a].Cells["ColHacc"].Value);
                    accv = Convert.ToDouble(Dgv_data.Rows[a].Cells["ColVacc"].Value);
                    accch1 = Convert.ToDouble(Dgv_data.Rows[a].Cells["Ch1Acc1"].Value);

                    vela = Convert.ToDouble(Dgv_data.Rows[a].Cells["ColAvel"].Value);
                    velh = Convert.ToDouble(Dgv_data.Rows[a].Cells["ColHvel"].Value);
                    velv = Convert.ToDouble(Dgv_data.Rows[a].Cells["ColVvel"].Value);
                    velch1 = Convert.ToDouble(Dgv_data.Rows[a].Cells["Ch1Vel1"].Value);

                    disa = Convert.ToDouble(Dgv_data.Rows[a].Cells["ColAdisp"].Value);
                    dish = Convert.ToDouble(Dgv_data.Rows[a].Cells["ColHdisp"].Value);
                    disv = Convert.ToDouble(Dgv_data.Rows[a].Cells["ColVdisp"].Value);
                    disch1 = Convert.ToDouble(Dgv_data.Rows[a].Cells["Ch1Disp1"].Value);

                    bera = Convert.ToDouble(Dgv_data.Rows[a].Cells["ColAbear"].Value);
                    berh = Convert.ToDouble(Dgv_data.Rows[a].Cells["ColHbear"].Value);
                    berv = Convert.ToDouble(Dgv_data.Rows[a].Cells["ColVbear"].Value);
                    berch1 = Convert.ToDouble(Dgv_data.Rows[a].Cells["Ch1Bear1"].Value);

                    cfa = Convert.ToDouble(Dgv_data.Rows[a].Cells["ColAcrest"].Value);
                    cfh = Convert.ToDouble(Dgv_data.Rows[a].Cells["ColHcrest"].Value);
                    cfv = Convert.ToDouble(Dgv_data.Rows[a].Cells["ColVcrest"].Value);
                    cfch1 = Convert.ToDouble(Dgv_data.Rows[a].Cells["Ch1CF1"].Value);

                    otimagea = Convert.ToDouble(Dgv_data.Rows[a].Cells["OTAI1"].Value);
                    otreala = Convert.ToDouble(Dgv_data.Rows[a].Cells["OTAR1"].Value);
                    otimageh = Convert.ToDouble(Dgv_data.Rows[a].Cells["OTHI1"].Value);
                    otrealh = Convert.ToDouble(Dgv_data.Rows[a].Cells["OTHR1"].Value);
                    otimagev = Convert.ToDouble(Dgv_data.Rows[a].Cells["OTVI1"].Value);
                    otrealv = Convert.ToDouble(Dgv_data.Rows[a].Cells["OTVR1"].Value);
                    otimagech1 = Convert.ToDouble(Dgv_data.Rows[a].Cells["OTCH1I1"].Value);
                    otrealch1 = Convert.ToDouble(Dgv_data.Rows[a].Cells["OTCH1R1"].Value);

                    rpm = Convert.ToDouble(Dgv_data.Rows[a].Cells["OTRPM"].Value);
                    note1 = Convert.ToString(Dgv_data.Rows[a].Cells["ColNote1"].Value);
                    note2 = Convert.ToString(Dgv_data.Rows[a].Cells["ColNote2"].Value);
                    temp = Convert.ToDouble(Dgv_data.Rows[a].Cells["ColTemp"].Value);

                    count = Convert.ToInt32(Dgv_data.Rows[a].Cells["colCounter"].Value);
                    string dtime = Convert.ToString(Dgv_data.Rows[a].Cells["ColID"].Value);
                    string n2ID = null;
                    if(count==0)
                    {
                        DataTable dt1 = new DataTable();
                        dt1 = DbClass.getdata(CommandType.Text, "select max(data_id) from point_data");
                        count = Convert.ToInt32(dt1.Rows[0][0]) + 1;
                        DbClass.executequery(CommandType.Text, " insert into point_data (Point_ID,Point_name, Point_Type,  Measure_time,  accel_a,  accel_h,    accel_v,accel_ch1, vel_a,        vel_h, vel_v, vel_ch1,      displ_a,   displ_h,    displ_v, displ_ch1,crest_factor_a,    crest_factor_h,    crest_factor_v,   crest_factor_ch1 ,          bearing_a,       bearing_h,  bearing_v,  bearing_ch1,        ordertrace_a_real,   ordertrace_h_real,  ordertrace_v_real ,ordertrace_ch1_real ,     ordertrace_a_image,   ordertrace_h_image,    ordertrace_v_image, ordertrace_ch1_image,   ordertrace_rpm,    TimeA_X,     timeH_X,     timeV_X,timeCH1_X,       PA_X, PH_X,    PV_X,  PCH1_X,    P1A_X, P1H_X,  P1V_X,   P1CH1_X,   P2A_X,   P2H_X,   P2V_X,  P2CH1_X,     P21A_X,  P21H_X,  P21V_X,  P21CH1_X,  P3A_X,  P3H_X, P3V_X,  P3CH1_X,   P31A_X,   P31H_X,  P31V_X,  P31CH1_X,   CEPA_X,    CEPH_X,  CEPV_X, CEPCH1_X,    DEMA_X,   DEMH_X, DEMV_X, DEMCH1_X,      timeA_Y,        timeH_Y,     timeV_Y,    timeCH1_Y,     PA_Y,     PH_Y,    PV_Y,    PCH1_Y,P1A_Y,P1H_Y,P1V_Y,P1CH1_Y,P2A_Y,P2H_Y,P2V_Y,P2CH1_Y,P21A_Y,P21H_Y,P21V_Y,P21CH1_Y,P3A_Y,P3H_Y,P3V_Y,P3CH1_Y,P31A_Y,P31H_Y,P31V_Y,P31CH1_Y,CEPA_Y,CEPH_Y,CEPV_Y,CEPCH1_Y,DEMA_Y,DEMH_Y,DEMV_Y,DEMCH1_Y ,            temperature,    Process,   auto_measure,   record_status,    Notes1, Notes2,  IDateTime,   Manual) values ('" + PublicClass.SPointID + "','" + dgv_pointname + "','" + dgv_pointtype + "','" + PublicClass.GetDatetime() + "','" + acca + "','" + acch + "','" + accv + "','" + accch1 + "','" + vela + "','" + velh + "','" + velv + "','" + velch1 + "','" + disa + "','" + dish + "','" + disv + "','" + disch1 + "','" + cfa + "','" + cfh + "','" + cfv + "','" + cfch1 + "','" + bera + "','" + berh + "','" + berv + "','" + berch1 + "','" + otreala + "','" + otrealh + "','" + otrealv + "','" + otrealch1 + "','" + otimagea + "','" + otimageh + "','" + otimagev + "','" + otimagech1 + "','" + rpm + "','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','0|','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','" + temp + "','0','0','0','','','"+PublicClass.GetDatetime()+"','')");
                    }
                    else
                    {
                        DbClass.executequery(CommandType.Text, "update point_data set Point_name='" + dgv_pointname + "', Point_Type='" + dgv_pointtype + "', accel_a='" + acca + "',  accel_h='" + acch + "',    accel_v='" + accv + "',accel_ch1='" + accch1 + "', vel_a='" + vela + "',        vel_h='" + velh + "', vel_v='" + velv + "', vel_ch1='" + velch1 + "',      displ_a='" + disa + "',   displ_h='" + dish + "',    displ_v='" + disv + "', displ_ch1='" + disch1 + "',crest_factor_a='" + cfa + "',    crest_factor_h='" + cfh + "',    crest_factor_v='" + cfv + "',   crest_factor_ch1 ='" + cfch1 + "',          bearing_a='" + bera + "',       bearing_h='" + berh + "',  bearing_v='" + berv + "',  bearing_ch1='" + berch1 + "',        ordertrace_a_real='" + otreala + "',   ordertrace_h_real='" + otrealh + "',  ordertrace_v_real='" + otrealv + "' ,ordertrace_ch1_real='" + otrealch1 + "' ,     ordertrace_a_image='" + otimagea + "',   ordertrace_h_image='" + otimageh + "',    ordertrace_v_image='" + otimagev + "', ordertrace_ch1_image='" + otimagech1 + "',   ordertrace_rpm='" + rpm + "',      temperature='" + temp + "',Notes1='" + note1 + "', Notes2='" + note2 + "'where data_id='" + count + "'");
                    }
                    DataTable dtNote = DbClass.getdata(CommandType.Text, "Select * from point_note2 where Point_DataID ='" + count + "'");
                    if (dtNote.Rows.Count > 0)
                    {
                        DbClass.executequery(CommandType.Text, "Update point_note2 set Date = '" + PublicClass.GetDatetime() + "', Point_Id= '" + PublicClass.SPointID + "', Note= '" + note2 + "' where Point_DataID='" + count + "'");
                    }
                    else
                    {
                        DbClass.executequery(CommandType.Text, "insert into point_note2(Date,Point_Id,Note,Point_DataID) values('" + PublicClass.GetDatetime() + "','" + PublicClass.SPointID + "','" + note2 + "','" + count + "')");
                    }

                    DataTable dt = DbClass.getdata(CommandType.Text, "Select Note_ID from point_note2 where Point_DataID ='" + count + "'");
                    n2ID = Convert.ToString(dt.Rows[0]["Note_ID"]);
                    DbClass.executequery(CommandType.Text, "Update Point_Data set Notes1 = '" + note1 + "' , Notes2 = '" + n2ID + "' where Data_ID = '" + count + "'");
                }
            }
            catch
            {
            }
        }
              
        ArrayList sarrTime = null;
        private void Dgv_data_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string sx = null;
            string[] sarrColumn = { "A(Acc)", "H(Acc)", "V(Acc)", "Ch1(Acc)", "A(Vel)", "H(Vel)", "V(Vel)", "Ch1(Vel)", "A(Disp)", "H(Disp)", "V(Disp)", "Ch1(Disp)", "A(Bear)", "H(Bear)", "V(Bear)", "Ch1(Bear)"};
            string sColumnName = null;
            int iColumnIndex = 0;
            double[] dx = null ;
            double[] dy = null;
            string xValue = null;
            string yValue = null;
            string Yaxis = "Unit";
            try
            {
                if (sNodeType != null)
                {
                    if (sNodeType == "Point")
                    {
                        sx = PublicClass.SPointID;
                    }
                    iColumnIndex = e.ColumnIndex;
                   string sColumnName1 = Dgv_data.Columns[e.ColumnIndex].HeaderText;
                   if (sColumnName1 == "Axial_Phase" || sColumnName1 == "Horizontal_Phase" || sColumnName1 == "Vertical_Phase" || sColumnName1 == "Ch1_Phase")
                    {
                        if (sColumnName1 == "Axial_Phase")
                        {
                            PublicClass.AHVCH1 = "Axial";
                        }
                        if (sColumnName1 == "Horizontal_Phase")
                        {
                            PublicClass.AHVCH1 = "Horizontal";
                        }
                        if (sColumnName1 == "Vertical_Phase")
                        {
                            PublicClass.AHVCH1 = "Vertical";
                        }
                        if (sColumnName1 == "Ch1_Phase")
                        {
                            PublicClass.AHVCH1 = "Channel1";
                        }
                         try
                         {
                             _objcontrol.DataGridSettingForPhase(true);
                             _objMain.bboriginal();               
                         }
                         catch 
                         {                             
                         }                     
                     }
                     else
                     {
                         try
                         {
                             PublicClass.trendbool = true;
                             sarrTime = new ArrayList();
                             string stime = Dgv_data[0, 1].Value.ToString();
                             sarrTime.Add(stime);
                             if (sColumnName1 == "A(acc)")
                             {
                                 PublicClass.Gtrend = "accel_a";
                             }
                             else if (sColumnName1 == "H(acc)")
                             {
                                 PublicClass.Gtrend = "accel_h";
                             }
                             else if (sColumnName1 == "V(acc)")
                             {
                                 PublicClass.Gtrend = "accel_v";
                             }
                             else if (sColumnName1 == "Ch1(acc)")
                             {
                                 PublicClass.Gtrend = "accel_ch1";
                             }
                             else if (sColumnName1 == "CH2(acc)")
                             {
                                 PublicClass.Gtrend = "accel_ch1";
                             }

                             //-----//
                             else if (sColumnName1 == "A(vel)")
                             {
                                 PublicClass.Gtrend = "vel_a";
                             }
                             else if (sColumnName1 == "H(vel)")
                             {
                                 PublicClass.Gtrend = "vel_h";
                             }
                             else if (sColumnName1 == "V(vel)")
                             {
                                 PublicClass.Gtrend = "vel_v";
                             }
                             else if (sColumnName1 == "Ch1(vel)")
                             {
                                 PublicClass.Gtrend = "vel_ch1";
                             }
                             else if (sColumnName1 == "CH2(vel)")
                             {
                                 PublicClass.Gtrend = "vel_ch1";
                             }
                             //---//
                             else if (sColumnName1 == "A(disp)")
                             {
                                 PublicClass.Gtrend = "displ_a";
                             }
                             else if (sColumnName1 == "H(disp)")
                             {
                                 PublicClass.Gtrend = "displ_h";
                             }
                             else if (sColumnName1 == "V(disp)")
                             {
                                 PublicClass.Gtrend = "displ_v";
                             }
                             else if (sColumnName1 == "CH1(disp)")
                             {
                                 PublicClass.Gtrend = "displ_ch1";
                             }
                             else if (sColumnName1 == "CH2(displ)")
                             {
                                 PublicClass.Gtrend = "displ_ch1";
                             }
                             //--//
                             else if (sColumnName1 == "A(bear)")
                             {
                                 PublicClass.Gtrend = "bearing_a";
                             }
                             else if (sColumnName1 == "H(bear)")
                             {
                                 PublicClass.Gtrend = "bearing_h";
                             }
                             else if (sColumnName1 == "V(bear)")
                             {
                                 PublicClass.Gtrend = "bearing_v";
                             }
                             else if (sColumnName1 == "CH1(bear)")
                             {
                                 PublicClass.Gtrend = "bearing_ch1";
                             }
                             m_objmcw.Main = graph;
                             //_objcontrol.CallClearDataGridMain();
                             m_objmcw.FillTrendPanel(stime, PublicClass.SPointID, "Trend");
                             PublicClass.GraphClicked = "Trend";
                             _objcontrol.panel1.Controls.Clear();
                             if (sColumnName1 == "CH2(acc)" || sColumnName1 == "CH2(vel)" || sColumnName1 == "CH2(displ)")
                             {
                                 graph.trendGraph(PublicClass.GraphClicked, "Trend Graph(" + sColumnName1 + ")");
                             }
                             else
                             {
                                 graph.trendGraph(PublicClass.GraphClicked, "Trend Graph(" + PublicClass.Gtrend + ")");
                             }
                         }
                         catch { }
                        
                     }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void trlPlantManger_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Up)
                //{
                //    MovePrevious();
                //}
                //else if (e.KeyCode == Keys.Down)
                //{
                //    MoveNext();
                //}
            }
            catch { }
        }

        private void tsadd_MouseHover(object sender, EventArgs e)
        {           
            try
            {
                DataTable dt = DbClass.getdata(CommandType.Text, "select * from factory_info");
                if (dt.Rows.Count > 0)
                {
                    if (sNodeType == "Plant")
                    {
                        tsmFactory.Visible = true;
                        tsmArea.Visible = true;
                        tsmtrain.Visible = false;
                        tsmMachine.Visible = false;
                        tsmPoint.Visible = false;
                    }
                    else if (sNodeType == "Area")
                    {
                        tsmFactory.Visible = false;
                        tsmArea.Visible = true;
                        tsmtrain.Visible = true;
                        tsmMachine.Visible = false;
                        tsmPoint.Visible = false;
                    }
                    else if (sNodeType == "Train")
                    {
                        tsmFactory.Visible = false;
                        tsmArea.Visible = false;
                        tsmtrain.Visible = true;
                        tsmMachine.Visible = true;
                        tsmPoint.Visible = false;
                    }
                    else if (sNodeType == "Machine")
                    {
                        tsmFactory.Visible = false;
                        tsmArea.Visible = false;
                        tsmtrain.Visible = false;
                        tsmMachine.Visible = true;
                        tsmPoint.Visible = true;
                    }
                    else if (sNodeType == "Point")
                    {
                        tsmFactory.Visible = false;
                        tsmArea.Visible = false;
                        tsmtrain.Visible = false;
                        tsmMachine.Visible = false;
                        tsmPoint.Visible = true;
                    }
                }
                else
                { 
                    tsmFactory.Visible = true;
                    tsmArea.Visible = false;
                    tsmtrain.Visible = false;
                    tsmMachine.Visible = false;
                    tsmPoint.Visible = false;
                }
            }
            catch { }
        }

        public string checkdir = null; string direction = null;
        string T_X = null; string P_X = null; string P1_X = null; string P2_X = null; string P21_X = null; string P3_X = null;
        string P31_X = null; string CEP_X = null; string DEM_X = null;
        private void tsgraph_MouseHover(object sender, EventArgs e)
        {
            try
            {                
                if (PublicClass.currentInstrument == "Kohtect-C911")
                {
                    tsaxail.Visible = false;
                    tshorizontal.Visible = false;
                    tsvertical.Visible = false;
                    tschannel1.Visible = false;
                    tsAcc.Enabled = false;
                    tsvelocity.Enabled = false;
                    tsdipla.Enabled = false;
                    try
                    {
                        DataTable dt = DbClass.getdata(CommandType.Text, "select accel_h,vel_h,displ_h,accel_v,vel_v,displ_v FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
                        if (dt.Rows.Count > 0)
                        {
                            string accel_h = Convert.ToString(dt.Rows[0]["accel_h"]);
                            string accel_v = Convert.ToString(dt.Rows[0]["accel_v"]);
                            string vel_h = Convert.ToString(dt.Rows[0]["vel_h"]);
                            string vel_v = Convert.ToString(dt.Rows[0]["vel_v"]);
                            string displ_h = Convert.ToString(dt.Rows[0]["displ_h"]);   
                            string displ_v = Convert.ToString(dt.Rows[0]["displ_v"]);
                            if (accel_h != "0" || accel_v != "0")
                            {
                                tsAcc.Enabled = true;
                            }
                            if (vel_h != "0" || vel_v != "0")
                            {
                                tsvelocity.Enabled = true;
                            } 
                            if (displ_h != "0" || displ_v != "0")
                            {
                                tsdipla.Enabled = true;
                            }
                        }
                    }
                    catch { }
                }
                else
                {
                    if (PublicClass.currentInstrument == "SKF/DI")
                    {
                        tschannel1.Visible = false; tsAcc.Visible = false;
                        tsvelocity.Visible = false; tsdipla.Visible = false;
                    }
                    checkdir = null; direction = null;
                    PublicClass.checkdirection = null;
                    tsaxail.Enabled = false;
                    tshorizontal.Enabled = false;
                    tsvertical.Enabled = false;
                    tschannel1.Enabled = false;
                    tsAcc.Visible = false;
                    tsvelocity.Visible = false;
                    tsdipla.Visible = false;               
                    DataTable dt = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,timeA_X,timeA_Y,PA_X,PA_Y,P1A_X,P1A_Y,P2A_X,P2A_Y,P21A_X,P21A_Y,P3A_X,P3A_Y,P31A_X,P31A_Y,CEPA_X,CEPA_Y,DEMA_X,DEMA_Y FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
                    foreach (DataRow DR in dt.Rows)
                    {
                        T_X = Convert.ToString(DR["timeA_X"]);
                        P_X = Convert.ToString(DR["PA_X"]);
                        P1_X = Convert.ToString(DR["P1A_X"]);
                        P2_X = Convert.ToString(DR["P2A_X"]);
                        P21_X = Convert.ToString(DR["P21A_X"]);
                        P3_X = Convert.ToString(DR["P3A_X"]);
                        P31_X = Convert.ToString(DR["P31A_X"]);
                        CEP_X = Convert.ToString(DR["CEPA_X"]);
                        DEM_X = Convert.ToString(DR["DEMA_X"]);
                    }
                    if (dt.Rows.Count > 0)
                    {
                        if (T_X != "0|" && T_X != "" || P_X != "0|" && P_X != "" || P1_X != "0|" && P1_X != "" || P2_X != "0|" && P2_X != "" || P21_X != "0|" && P21_X != "" || P3_X != "0|" && P3_X != "" || P31_X != "0|" && P31_X != "" || CEP_X != "0|" && CEP_X != "" || DEM_X != "0|" && DEM_X != "")
                        {
                            tsaxail.Enabled = true;
                            direction = "Axial";
                            checkdir += direction + ",";
                        }
                        else
                        {
                            tsaxail.Enabled = false;
                        }
                    }
                    else
                    {
                        tsaxail.Enabled = false;
                    }

                    DataTable dt1 = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,timeH_X,timeH_Y,PH_X,PH_Y,P1H_X,P1H_Y,P2H_X,P2H_Y,P21H_X,P21H_Y,P3H_X,P3H_Y,P31H_X,P31H_Y,CEPH_X,CEPH_Y,DEMH_X,DEMH_Y FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
                    foreach (DataRow DR in dt1.Rows)
                    {
                        T_X = Convert.ToString(DR["timeH_X"]);
                        P_X = Convert.ToString(DR["PH_X"]);
                        P1_X = Convert.ToString(DR["P1H_X"]);
                        P2_X = Convert.ToString(DR["P2H_X"]);
                        P21_X = Convert.ToString(DR["P21H_X"]);
                        P3_X = Convert.ToString(DR["P3H_X"]);
                        P31_X = Convert.ToString(DR["P31H_X"]);
                        CEP_X = Convert.ToString(DR["CEPH_X"]);
                        DEM_X = Convert.ToString(DR["DEMH_X"]);
                    }
                    if (dt1.Rows.Count > 0)
                    {
                        if (T_X != "0|" && T_X != "" || P_X != "0|" && P_X != "" || P1_X != "0|" && P1_X != "" || P2_X != "0|" && P2_X != "" || P21_X != "0|" && P21_X != "" || P3_X != "0|" && P3_X != "" || P31_X != "0|" && P31_X != "" || CEP_X != "0|" && CEP_X != "" || DEM_X != "0|" && DEM_X != "")
                        {
                            tshorizontal.Enabled = true;
                            direction = "Horizontal";
                            checkdir += direction + ",";
                        }
                        else
                        {
                            tshorizontal.Enabled = false;
                        }
                    }
                    else
                    {
                        tshorizontal.Enabled = false;
                    }

                    DataTable dt2 = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,timeV_X,timeV_Y,PV_X,PV_Y,P1V_X,P1V_Y,P2V_X,P2V_Y,P21V_X,P21V_Y,P3V_X,P3V_Y,P31V_X,P31V_Y,CEPV_X,CEPV_Y,DEMV_X,DEMV_Y FROM point_data where point_ID = '" + PublicClass.SPointID + "'");
                    foreach (DataRow DR in dt2.Rows)
                    {

                        T_X = Convert.ToString(DR["timeV_X"]);
                        P_X = Convert.ToString(DR["PV_X"]);
                        P1_X = Convert.ToString(DR["P1V_X"]);
                        P2_X = Convert.ToString(DR["P2V_X"]);
                        P21_X = Convert.ToString(DR["P21V_X"]);
                        P3_X = Convert.ToString(DR["P3V_X"]);
                        P31_X = Convert.ToString(DR["P31V_X"]);
                        CEP_X = Convert.ToString(DR["CEPV_X"]);
                        DEM_X = Convert.ToString(DR["DEMV_X"]);
                    }
                    if (dt2.Rows.Count > 0)
                    {
                        if (T_X != "0|" && T_X != "" || P_X != "0|" && P_X != "" || P1_X != "0|" && P1_X != "" || P2_X != "0|" && P2_X != "" || P21_X != "0|" && P21_X != "" || P3_X != "0|" && P3_X != "" || P31_X != "0|" && P31_X != "" || CEP_X != "0|" && CEP_X != "" || DEM_X != "0|" && DEM_X != "")
                        {
                            tsvertical.Enabled = true;
                            direction = "Vertical";
                            checkdir += direction + ",";
                        }
                        else
                        {
                            tsvertical.Enabled = false;
                        }
                    }
                    else
                    {
                        tsvertical.Enabled = false;
                    }

                    DataTable dt3 = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,timeCH1_X,timeCH1_Y,PCH1_X,PCH1_Y,P1CH1_X,P1CH1_Y,P2CH1_X,P2CH1_Y,P21CH1_X,P21CH1_Y,P3CH1_X,P3CH1_Y,P31CH1_X,P31CH1_Y,CEPCH1_X,CEPCH1_Y,DEMCH1_X,DEMCH1_Y FROM point_data where point_ID = '" + PublicClass.SPointID + "'");
                    foreach (DataRow DR in dt3.Rows)
                    {
                        T_X = Convert.ToString(DR["timeCH1_X"]);
                        P_X = Convert.ToString(DR["PCH1_X"]);
                        P1_X = Convert.ToString(DR["P1CH1_X"]);
                        P2_X = Convert.ToString(DR["P2CH1_X"]);
                        P21_X = Convert.ToString(DR["P21CH1_X"]);
                        P3_X = Convert.ToString(DR["P3CH1_X"]);
                        P31_X = Convert.ToString(DR["P31CH1_X"]);
                        CEP_X = Convert.ToString(DR["CEPCH1_X"]);
                        DEM_X = Convert.ToString(DR["DEMCH1_X"]);
                    }
                    if (dt3.Rows.Count > 0)
                    {
                        if (T_X != "0|" && T_X != "" || P_X != "0|" && P_X != "" || P1_X != "0|" && P1_X != "" || P2_X != "0|" && P2_X != "" || P21_X != "0|" && P21_X != "" || P3_X != "0|" && P3_X != "" || P31_X != "0|" && P31_X != "" || CEP_X != "0|" && CEP_X != "" || DEM_X != "0|" && DEM_X != "")
                        {
                            tschannel1.Enabled = true;
                            direction = "Channel1";
                            checkdir += direction + ",";
                        }
                        else
                        {
                            tschannel1.Enabled = false;
                        }
                    }
                    else
                    {
                        tschannel1.Enabled = false;
                    }
                }
            }
            catch { }
            PublicClass.checkdirection = checkdir;           
        }

        private void xtroverall_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            string stabIndex = Convert.ToString(xtroverall.SelectedTabPage.Text.Trim());
            try
            {
                switch (stabIndex)
                {
                    case "Acceleration OverAll":
                        {
                            ctroverall = "accel";
                            if (rbAnalog.Checked == true)
                            {
                                gaugegraph(ctrdir, ctroverall);
                            }
                            else
                            {
                                barchrt();
                            }
                            break;
                        }
                    case "Velocity OverAll":
                        {
                            ctroverall = "vel";
                            if (rbAnalog.Checked == true)
                            {
                                gaugegraph(ctrdir, ctroverall);
                            }
                            else
                            {
                                barchrt();
                            }
                            break;
                        }
                    case "Displacement OverAll":
                        {
                            ctroverall = "displ";
                            if (rbAnalog.Checked == true)
                            {
                                gaugegraph(ctrdir, ctroverall);
                            }
                            else
                            {
                                barchrt();
                            }
                            break;
                        }
                    case "CrestFactor OverAll":
                        {
                            ctroverall = "crest_factor";
                            if (rbAnalog.Checked == true)
                            {
                                gaugegraph(ctrdir, ctroverall);
                            }
                            else
                            {
                                barchrt();
                            }
                            break;
                        }
                }
            }
            catch { }
        }

        string ctrdir = null; string ctroverall = null;
        private void CtrDir_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            string stabIndex = Convert.ToString(CtrDir.SelectedTabPage.Text.Trim());
            try
            {
                switch (stabIndex)
                {
                    case "Axial":
                        {
                            ctrdir = "_a";
                            if (rbAnalog.Checked == true)
                            {
                                gaugegraph(ctrdir, ctroverall);
                            }
                            else
                            {
                                barchrt();
                            }
                            break;
                        }
                    case "Horizontal":
                        {
                            ctrdir = "_h";
                            if (rbAnalog.Checked == true)
                            {
                                gaugegraph(ctrdir, ctroverall);
                            }
                            else
                            {
                                barchrt();
                            }                            
                            break;
                        }
                    case "Vertical":
                        {
                            ctrdir = "_v";
                            if (rbAnalog.Checked == true)
                            {
                                gaugegraph(ctrdir, ctroverall);
                            }
                            else
                            {
                                barchrt();
                            }
                            break;
                        }
                    case "Channel1":
                        {
                            ctrdir = "_ch1";
                            if (rbAnalog.Checked == true)
                            {
                                gaugegraph(ctrdir, ctroverall);
                            }
                            else
                            {
                                barchrt();
                            }
                            break;
                        }
                }
            }
            catch { }
        }

        public bool LevelModify = false;
        private void tsmFactory_Click(object sender, EventArgs e)
        {
            LevelModify = true;
            InsertNextLevelFB("Plant");   
        }

        private void tsmArea_Click(object sender, EventArgs e)
        {
            LevelModify = true;
            PublicClass.nodelevel = sNodeType;
            InsertNextLevelFB("Area");
        }

        private void tsmtrain_Click(object sender, EventArgs e)
        {
            LevelModify = true;
            PublicClass.nodelevel = sNodeType;
            InsertNextLevelFB("Train");
        }

        private void tsmMachine_Click(object sender, EventArgs e)
        {
            LevelModify = true;
            PublicClass.nodelevel = sNodeType;
            InsertNextLevelFB("Machine");
        }

        private void tsmPoint_Click(object sender, EventArgs e)
        {
            LevelModify = true;
            PublicClass.nodelevel = sNodeType;
            InsertNextLevelFB("Point");
        }

        private void rbAnalog_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbAnalog.Checked == true)
                {
                    CtrDir.SelectedTabPageIndex = 0;
                    ctrdir = "_a";
                    xtroverall.SelectedTabPageIndex = 0;
                    ctroverall = "accel";
                    gaugegraph(ctrdir, ctroverall);
                }
            }
            catch { }
        }

        private void CreateCircularGauge(int acc, int max, string unitname)
        {
            try
            {                
                GaugeControl gc = new GaugeControl();
                CircularGauge circularGauge = gc.AddCircularGauge();
                
                circularGauge.AddDefaultElements();
                ArcScaleBackgroundLayer background = circularGauge.BackgroundLayers[0];
                background.ShapeType = BackgroundLayerShapeType.CircularThreeFourth_Style17;
                
                ArcScaleComponent scale = circularGauge.Scales[0];
                scale.MinValue = 0;
                scale.MaxValue = max;
                scale.Value = acc;
                scale.MajorTickCount = 6;
                scale.MajorTickmark.FormatString = "{0:F0}";
                scale.MajorTickmark.ShapeType = TickmarkShapeType.Circular_Style17_1;
                scale.MajorTickmark.ShapeOffset = -9;
                scale.MajorTickmark.AllowTickOverlap = true;
                scale.MinorTickCount = 3;
                scale.MinorTickmark.ShapeType = TickmarkShapeType.Circular_Style17_2;
                scale.EasingMode = EasingMode.EaseIn;
                scale.EnableAnimation = true;
                ArcScaleSpindleCap cap = circularGauge.AddSpindleCap();
                cap.ShapeType = SpindleCapShapeType.CircularFull_Style2;
                ArcScaleNeedleComponent needle = circularGauge.Needles[0];
                needle.ShapeType = NeedleShapeType.CircularFull_Style3;
                gc.Size = new Size(835, 463);

                circularGauge.BeginUpdate();
                LabelComponent label5 = new LabelComponent("myLabel1");
                label5.AppearanceText.TextBrush = new SolidBrushObject(Color.Black);
                label5.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(125, 240);
                label5.ZOrder = -10000;
                label5.AllowHTMLString = true;
                label5.Text = "<color=BLUE><b>" + unitname + "</b></color>";
                circularGauge.Labels.Add(label5);
                circularGauge.EndUpdate();

                if (ctroverall == "accel")
                {
                    pnlAcc.Controls.Clear();
                    pnlAcc.Controls.Add(gc);
                }
                else if (ctroverall == "vel")
                {
                    pnlVel.Controls.Clear();
                    pnlVel.Controls.Add(gc);
                }
                else if (ctroverall == "displ")
                {
                    pnlDispl.Controls.Clear();
                    pnlDispl.Controls.Add(gc);
                }
                else if (ctroverall == "crest_factor")
                {
                    pnlCrest.Controls.Clear();
                    pnlCrest.Controls.Add(gc);
                }
                

            }
            catch { }
        
        }

        public void gaugegraph(string dir, string overall)
        {
            int acc = 0; int hor = 0; int ver = 0; int channel = 0;
            int val = 0;string unit = ""; string unname = null; int max_val = 0;
            string gaugeunit = null;
            string overdir = overall + dir;
            DataTable dt = new DataTable();
            try
            {
                GetTime(PublicClass.SPointID);
                if (overall == "accel")
                {
                    try
                    {
                        dt = DbClass.getdata(CommandType.Text, "select un.accel_unit,accel_a,accel_h,accel_v,accel_ch1 from point_data pd inner join type_point tp on tp.id=pd.Point_Type left join units un on un.Type_ID=tp.ID where pd.point_id='" + PublicClass.SPointID + "' and pd.measure_time='" + PublicClass.graphtym + "'");
                        foreach (DataRow dr in dt.Rows)
                        {
                            acc = Convert.ToInt32(dr["accel_a"]);
                            hor = Convert.ToInt32(dr["accel_h"]);
                            ver = Convert.ToInt32(dr["accel_v"]);
                            channel = Convert.ToInt32(dr["accel_ch1"]);
                            unit = Convert.ToString(dr["accel_unit"]);
                            if (unit == "0")
                            {
                                unname = "Gs";
                            }
                            else if (unit == "1")
                            {
                                unname = "gal";
                            }
                            else if (unit == "2")
                            {
                                unname = "m/s2";
                            }
                            max_val = 200;
                        }
                        if (overdir == "accel_a")
                        {
                            val = acc;
                        }
                        else if (overdir == "accel_h")
                        {
                            val = hor;
                        }
                        else if (overdir == "accel_v")
                        {
                            val = ver;
                        }
                        else if (overdir == "accel_ch1")
                        {
                            val = channel;
                        }
                    }
                    catch { }
                }
                if (overall == "vel")
                {
                    try
                    {
                        dt = DbClass.getdata(CommandType.Text, "select un.vel_unit,vel_a,vel_h,vel_v,vel_ch1 from point_data  pd inner join type_point tp on tp.id=pd.Point_Type left join units un on un.Type_ID=tp.ID where point_id='" + PublicClass.SPointID + "' and measure_time='" + PublicClass.graphtym + "'");
                        foreach (DataRow dr in dt.Rows)
                        {
                            acc = Convert.ToInt32(dr["vel_a"]);
                            hor = Convert.ToInt32(dr["vel_h"]);
                            ver = Convert.ToInt32(dr["vel_v"]);
                            channel = Convert.ToInt32(dr["vel_ch1"]);
                            unit = Convert.ToString(dr["vel_unit"]);
                            if (unit == "0")
                            {
                                unname = "mm/s";
                            }
                            else if (unit == "1")
                            {
                                unname = "in/s";
                            }
                            else if (unit == "2")
                            {
                                unname = "cm/s";
                            }
                            max_val = 200;
                        }
                        if (overdir == "vel_a")
                        {
                            val = acc;
                        }
                        else if (overdir == "vel_h")
                        {
                            val = hor;
                        }
                        else if (overdir == "vel_v")
                        {
                            val = ver;
                        }
                        else if (overdir == "vel_ch1")
                        {
                            val = channel;
                        }
                    }
                    catch
                    { }
                }
                if (overall == "displ")
                {
                    try
                    {
                        dt = DbClass.getdata(CommandType.Text, "select un.displ_unit,displ_a,displ_h,displ_v,displ_ch1 from point_data  pd inner join type_point tp on tp.id=pd.Point_Type left join units un on un.Type_ID=tp.ID where point_id='" + PublicClass.SPointID + "' and measure_time='" + PublicClass.graphtym + "'");
                        foreach (DataRow dr in dt.Rows)
                        {
                            acc = Convert.ToInt32(dr["displ_a"]);
                            hor = Convert.ToInt32(dr["displ_h"]);
                            ver = Convert.ToInt32(dr["displ_v"]);
                            channel = Convert.ToInt32(dr["displ_ch1"]);
                            unit = Convert.ToString(dr["displ_unit"]);
                            if (unit == "0")
                            {
                                unname = "mil";
                            }
                            else if (unit == "1")
                            {
                                unname = "um";
                            }
                            max_val = 2000;
                        }
                        if (overdir == "displ_a")
                        {
                            val = acc;
                        }
                        else if (overdir == "displ_h")
                        {
                            val = hor;
                        }
                        else if (overdir == "displ_v")
                        {
                            val = ver;
                        }
                        else if (overdir == "displ_ch1")
                        {
                            val = channel;
                        }
                    }
                    catch
                    { }
                }
                if (overall == "crest_factor")
                {
                    try
                    {
                        dt = DbClass.getdata(CommandType.Text, "select crest_factor_a,crest_factor_h,crest_factor_v,crest_factor_ch1 from point_data  pd inner join type_point tp on tp.id=pd.Point_Type left join units un on un.Type_ID=tp.ID where point_id='" + PublicClass.SPointID + "' and measure_time='" + PublicClass.graphtym + "'");
                        foreach (DataRow dr in dt.Rows)
                        {
                            acc = Convert.ToInt32(dr["crest_factor_a"]);
                            hor = Convert.ToInt32(dr["crest_factor_h"]);
                            ver = Convert.ToInt32(dr["crest_factor_v"]);
                            channel = Convert.ToInt32(dr["crest_factor_ch1"]);
                            max_val = 1000;
                        }
                        if (overdir == "crest_factor_a")
                        {
                            val = acc;
                        }
                        else if (overdir == "crest_factor_h")
                        {
                            val = hor;
                        }
                        else if (overdir == "crest_factor_v")
                        {
                            val = ver;
                        }
                        else if (overdir == "crest_factor_ch1")
                        {
                            val = channel;
                        }
                    }
                    catch
                    { }
                }
                CreateCircularGauge(val, max_val, unname);
            }
            catch { }
        }

        private ArrayList GetTime(string sPointID)
        {
            DataTable dt = new DataTable();
            ArrayList sarrTime = null;
            string sTime = null;
            try
            {
                sarrTime = new ArrayList();
                dt = DbClass.getdata(CommandType.Text, "select Measure_time from point_data where point_id='" + PublicClass.SPointID + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    sTime = Convert.ToDateTime(dr["Measure_time"]).ToString("yyyy-MM-dd HH:mm:ss");
                    sarrTime.Add(sTime);
                }
            }
            catch (Exception ex)
            {
            }            
            if (sarrTime.Count > 0)
            {
                sTime = (string)sarrTime[sarrTime.Count - 1];
                PublicClass.graphtym = sTime;
            }
            return sarrTime;
        }

        private void rbbargraph_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbbargraph.Checked == true)
                {
                    if (sNodeType == "Point")
                    {
                        barchrt();
                    }
                }
            }
            catch { }
        }

        private DataTable CreateChartData(int rowCount)
        {
            // Create an empty table.
            DataTable table = new DataTable("Table1");
            try
            {
                // Add two columns to the table.
                table.Columns.Add("Data and Time", typeof(DateTime));
                table.Columns.Add("Value", typeof(double));

                // Add data rows to the table.
                Random rnd = new Random();
                DataRow row = null;
                for (int i = 0; i < rowCount; i++)
                {
                    row = table.NewRow();
                    row["Data and Time"] = allTime_Data[i];
                    row["Value"] = allAccel_Data[i];
                    table.Rows.Add(row);
                }
            }
            catch { }
            return table;
        }

        double[] allAccel_Data = null;
        DateTime[] allTime_Data = null; 
        private double[] bardata(string dir, string overall)
        {
            DataTable dt = new DataTable();
            string overdir = overall + dir;            
            try
            {
                if (overall == "accel")
                {
                    dt = DbClass.getdata(CommandType.Text, "select pd.measure_time,accel_a,accel_h,accel_v,accel_ch1 from point_data pd inner join type_point tp on tp.id=pd.Point_Type left join units un on un.Type_ID=tp.ID where pd.point_id='" + PublicClass.SPointID + "'");
                    Array.Resize(ref allAccel_Data , dt.Rows.Count);
                    Array.Resize(ref allTime_Data, dt.Rows.Count);
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        allTime_Data[i] = Convert.ToDateTime(dr["measure_time"]);
                        if (overdir == "accel_a")
                        {
                            allAccel_Data[i] = Convert.ToDouble(dr["accel_a"]);
                        }
                        else if (overdir == "accel_h")
                        {
                            allAccel_Data[i] = Convert.ToDouble(dr["accel_h"]);
                        }
                        else if (overdir == "accel_v")
                        {
                            allAccel_Data[i] = Convert.ToDouble(dr["accel_v"]);
                        }
                        else if (overdir == "accel_ch1")
                        {
                            allAccel_Data[i] = Convert.ToDouble(dr["accel_ch1"]);
                        }
                        i++;
                    }                   
                }
                if (overall == "vel")
                {
                    dt = DbClass.getdata(CommandType.Text, "select pd.measure_time,vel_a,vel_h,vel_v,vel_ch1 from point_data pd inner join type_point tp on tp.id=pd.Point_Type left join units un on un.Type_ID=tp.ID where pd.point_id='" + PublicClass.SPointID + "'");
                    Array.Resize(ref allAccel_Data, dt.Rows.Count);
                    Array.Resize(ref allTime_Data, dt.Rows.Count);
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        allTime_Data[i] = Convert.ToDateTime(dr["measure_time"]);
                        if (overdir == "vel_a")
                        {
                            allAccel_Data[i] = Convert.ToDouble(dr["vel_a"]);
                        }
                        else if (overdir == "vel_h")
                        {
                            allAccel_Data[i] = Convert.ToDouble(dr["vel_h"]);
                        }
                        else if (overdir == "vel_v")
                        {
                            allAccel_Data[i] = Convert.ToDouble(dr["vel_v"]);
                        }
                        else if (overdir == "vel_ch1")
                        {
                            allAccel_Data[i] = Convert.ToDouble(dr["vel_ch1"]);
                        }
                        i++;
                    }      
                }
                if (overall == "displ")
                {
                    dt = DbClass.getdata(CommandType.Text, "select pd.measure_time,displ_a,displ_h,displ_v,displ_ch1 from point_data pd inner join type_point tp on tp.id=pd.Point_Type left join units un on un.Type_ID=tp.ID where pd.point_id='" + PublicClass.SPointID + "'");
                    Array.Resize(ref allAccel_Data, dt.Rows.Count);
                    Array.Resize(ref allTime_Data, dt.Rows.Count);
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        allTime_Data[i] = Convert.ToDateTime(dr["measure_time"]);
                        if (overdir == "displ_a")
                        {
                            allAccel_Data[i] = Convert.ToDouble(dr["displ_a"]);
                        }
                        else if (overdir == "displ_h")
                        {
                            allAccel_Data[i] = Convert.ToDouble(dr["displ_h"]);
                        }
                        else if (overdir == "displ_v")
                        {
                            allAccel_Data[i] = Convert.ToDouble(dr["displ_v"]);
                        }
                        else if (overdir == "displ_ch1")
                        {
                            allAccel_Data[i] = Convert.ToDouble(dr["displ_ch1"]);
                        }
                        i++;
                    }      
                }
                if (overall == "Crest_factor")
                {
                    dt = DbClass.getdata(CommandType.Text, "select pd.measure_time,crest_factor_a,crest_factor_h,crest_factor_v,crest_factor_ch1 from point_data pd inner join type_point tp on tp.id=pd.Point_Type left join units un on un.Type_ID=tp.ID where pd.point_id='" + PublicClass.SPointID + "'");
                    Array.Resize(ref allAccel_Data, dt.Rows.Count);
                    Array.Resize(ref allTime_Data, dt.Rows.Count);
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        allTime_Data[i] = Convert.ToDateTime(dr["measure_time"]);

                        if (overdir == "crest_factor_a")
                        {
                            allAccel_Data[i] = Convert.ToDouble(dr["crest_factor_a"]);
                        }
                        else if (overdir == "crest_factor_h")
                        {
                            allAccel_Data[i] = Convert.ToDouble(dr["crest_factor_h"]);
                        }
                        else if (overdir == "crest_factor_v")
                        {
                            allAccel_Data[i] = Convert.ToDouble(dr["crest_factor_v"]);
                        }
                        else if (overdir == "crest_factor_ch1")
                        {
                            allAccel_Data[i] = Convert.ToDouble(dr["crest_factor_ch1"]);
                        }
                        i++;
                    }      
                }
            }
            catch
            { }
            return allAccel_Data;        
        }

        public void barchrt()
        {
            ChartControl chart = new ChartControl();
            Series series = new Series("Series1", ViewType.StackedBar);
          
            chart.Series.Add(series);
            bardata(ctrdir, ctroverall);

            series.DataSource = CreateChartData(allAccel_Data.Length);

            // Specify data members to bind the series.
            series.ArgumentScaleType = ScaleType.Qualitative;
            series.ArgumentDataMember = "Data and Time";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "Value" });

            ((StackedBarSeriesView)series.View).ColorEach = true;
            ((XYDiagram)chart.Diagram).AxisY.Visible = true;
            chart.Legend.MarkerVisible = true;

            // Dock the chart into its parent and add it to the current form.
            chart.Dock = DockStyle.Fill;
            if (ctroverall == "accel")
            {
                pnlAcc.Controls.Clear();
                pnlAcc.Controls.Add(chart);
            }
            else if (ctroverall == "vel")
            {
                pnlVel.Controls.Clear();
                pnlVel.Controls.Add(chart);
            }
            else if (ctroverall == "displ")
            {
                pnlDispl.Controls.Clear();
                pnlDispl.Controls.Add(chart);
            }
            else if (ctroverall == "Crest_factor")
            {
                pnlCrest.Controls.Clear();
                pnlCrest.Controls.Add(chart);
            }

        }

        private void tscollapse_Click(object sender, EventArgs e)
        {
            try
            {
                trlPlantManger.CollapseAll();
            }
            catch { }
        }

        private void tsexpand_Click(object sender, EventArgs e)
        {
            try
            {
                trlPlantManger.ExpandAll();
            }
            catch { }
        }

        private void CmbPointType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbPointType.Text != "" || CmbPointType.Text != "Select" || CmbPointType.Text != "System.Data.DataRowView")
                {
                    string aa = CmbPointType.Text;

                    if (aa != "System.Data.DataRowView" || aa != "" || aa != "Select" || aa != null)
                    {
                        DbClass.executequery(CommandType.Text, "update point set pointschedule='1' where point_id='" + PublicClass.SPointID + "'");
                    }
                    return;
                }
            }
            catch
            { }
        }

        private void txtfactoryname_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[a-zA-Z0-9]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = false;
            }
            else if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '_')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '(')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ')')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '+')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '=')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void trlPlantManger_AfterFocusNode(object sender, NodeEventArgs e)
        {
            try
            {
                sNodeType = (string)trlPlantManger.FocusedNode.GetDisplayText(10);
                PublicClass.SFactoryID = (string)trlPlantManger.FocusedNode.GetDisplayText(4);
                PublicClass.SAreaID = (string)trlPlantManger.FocusedNode.GetDisplayText(5);
                PublicClass.STrainID = (string)trlPlantManger.FocusedNode.GetDisplayText(6);
                PublicClass.SMachineID = (string)trlPlantManger.FocusedNode.GetDisplayText(7);
                PublicClass.SPointID = (string)trlPlantManger.FocusedNode.GetDisplayText(8);
                PublicClass.ssNodeType = sNodeType;
                visbilty(sNodeType);
                MachineName = (string)trlPlantManger.FocusedNode.GetDisplayText(2);
                RecordFill(sNodeType);

                if (PublicClass.SPointID != "0")
                {
                    try
                    {
                        DataTable dt = DbClass.getdata(CommandType.Text, "Select Data_ID from point_data where Point_ID = '" + PublicClass.SPointID + "' and Measure_time IN( Select Max(Measure_time) from point_Data where Point_ID = '" + PublicClass.SPointID + "');");
                        PublicClass.Data_ID = Convert.ToString(dt.Rows[0]["Data_ID"]);
                    }
                    catch { }
                }
            }
            catch
            {
                //  filltreelist();
            }
        }

        private void Dgv_data_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (Dgv_data.RowCount >= 1)
                {
                    if (e.KeyCode == Keys.Delete)
                    {
                        DataGridViewSelectedRowCollection dgvSelectedRows = Dgv_data.SelectedRows;
                        if (dgvSelectedRows.Count > 0)
                        {
                            if (MessageBox.Show("Are you Sure You Want to Delete Data for the Selected Rows", "Data Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                foreach (DataGridViewRow DGVRow in dgvSelectedRows)
                                {
                                    string datevalue = Convert.ToDateTime(DGVRow.Cells[0].Value).ToString("yyyy-MM-dd HH:mm:ss");
                                    if (datevalue != null)
                                    {
                                        DbClass.executequery(CommandType.Text, "delete from point_data where measure_time='" + datevalue + "' and point_id='" + PublicClass.SPointID + "'");                                       
                                    }
                                }
                                filltreelist();
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void Dgv_data_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Right:
                            {
                                tsCopy.Visible = false; tsPaste.Visible = false; tsadd.Visible = false; tsgraph.Visible = false; tsDelete.Visible = false; tsexpand.Visible = false; tscollapse.Visible = false;
                                if (dgv_pointname != null)
                                {
                                    tsAddrows.Visible = true;
                                    cmsUserControl.Show(this, new Point(e.X, e.Y));                                   
                                }
                                break;
                            }
                    }
                }              
            }
            catch { }
        }

        string dgv_pointname = null; string dgv_pointtype = null;

        private void tsAddrows_Click(object sender, EventArgs e)
        {
            try
            {
                Dgv_data.Rows.Add();
                Dgv_data.Rows[Dgv_data.Rows.Count-1].Cells["ColID"].Value = PublicClass.GetDatetime();
                DataTable dt = DbClass.getdata(CommandType.Text, "select * from point where point_id='" + PublicClass.SPointID + "'");
                dgv_pointname = Convert.ToString(dt.Rows[0]["PointName"]);
                dgv_pointtype = Convert.ToString(dt.Rows[0]["PointType_ID"]);
            }
            catch { }
        }
       
        private void tsAcc_MouseHover(object sender, EventArgs e)
        {
            try
            {
                PublicClass.checkparent = "Acc";
                DataTable dt1 = DbClass.getdata(CommandType.Text, "SELECT Point_name,point_ID,PH_X,PV_X FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
                foreach (DataRow DR in dt1.Rows)
                {
                    P_X = Convert.ToString(DR["PH_X"]);
                    P1_X = Convert.ToString(DR["PV_X"]);              
                }
                if (dt1.Rows.Count > 0)
                {
                    if (P_X != "0|" && P_X != "")
                    {
                        tsaccCh1.Enabled = true;
                        tsaccCh2.Enabled = false;
                    }
                    else
                    {
                        tsaccCh1.Enabled = false;
                        tsaccCh2.Enabled = true;
                    }
                }
            }
            catch { }
        }

        private void tsvelocity_MouseHover(object sender, EventArgs e)
        {
            try
            {
                PublicClass.checkparent = "Vel";
                DataTable dt1 = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,P1H_X,P1V_X FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
                foreach (DataRow DR in dt1.Rows)
                {
                    P_X = Convert.ToString(DR["P1H_X"]);
                    P1_X = Convert.ToString(DR["P1V_X"]);
                }
                if (dt1.Rows.Count > 0)
                {
                    if (P_X != "0|" && P_X != "")
                    {
                        tsvelCh1.Enabled = true;
                        tsvelCh2.Enabled = false;
                    }
                    else
                    {
                        tsvelCh1.Enabled = false;
                        tsvelCh2.Enabled = true;
                    }
                }
            }
            catch { }
        }

        private void tsdipla_MouseHover(object sender, EventArgs e)
        {
            try
            {
                PublicClass.checkparent = "Displ";
                DataTable dt1 = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,P2H_X,P2V_X FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
                foreach (DataRow DR in dt1.Rows)
                {
                    P_X = Convert.ToString(DR["P2H_X"]);
                    P1_X = Convert.ToString(DR["P2V_X"]);
                }
                if (dt1.Rows.Count > 0)
                {
                    if (P_X != "0|" && P_X != "")
                    {
                        tsdisplCh1.Enabled = true;
                        tsdisplCh2.Enabled = false;
                    }
                    else
                    {
                        tsdisplCh1.Enabled = false;
                        tsdisplCh2.Enabled = true;
                    }
                }
            }
            catch { }
        }

        private void tsaccCh1_Click(object sender, EventArgs e)
        {
            try
            {
                PublicClass.ssNodeType = sNodeType;
                PublicClass.AHVCH1 = "Horizontal";
                if (graph.IsDisposed)
                {
                    graph = new PointGeneral1();
                }
                graph.MainForm1 = _objMain;
                graph.grp = m_graph;
                if (PublicClass.checkparent == "Acc")
                {
                    DataTable dt1 = DbClass.getdata(CommandType.Text, "SELECT Point_name,point_ID,PH_X FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
                    foreach (DataRow DR in dt1.Rows)
                    {
                        P_X = Convert.ToString(DR["PH_X"]);
                    }
                }
                else if (PublicClass.checkparent == "Vel")
                {
                    DataTable dt1 = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,P1H_X FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
                    foreach (DataRow DR in dt1.Rows)
                    {
                        P_X = Convert.ToString(DR["P1H_X"]);
                    }
                }
                else if (PublicClass.checkparent == "Displ")
                {
                    DataTable dt1 = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,P2H_X FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
                    foreach (DataRow DR in dt1.Rows)
                    {
                        P_X = Convert.ToString(DR["P2H_X"]);
                    }
                }               
                if (P_X != "0|" || P_X != "" || P_X != null)
                {
                    graph.TopLevel = false;
                    pnlGraph.Controls.Add(graph);
                    graph.ShowgraphsC911();
                    graph.Dock = DockStyle.Fill;
                    TabGraph.PageVisible = true;
                    CtrTab.SelectedTabPageIndex = 12;
                    graph.Show();
                }
                else
                {
                    MessageBox.Show(this, "Data is not available on this Point at this Channel", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch { }
        }

        private void tsaccCh2_Click(object sender, EventArgs e)
        {
            try
            {
                PublicClass.ssNodeType = sNodeType;
                PublicClass.AHVCH1 = "Vertical";
                if (graph.IsDisposed)
                {
                    graph = new PointGeneral1();
                }
                graph.MainForm1 = _objMain;
                graph.grp = m_graph;
                if (PublicClass.checkparent == "Acc")
                {    
                    DataTable dt1 = DbClass.getdata(CommandType.Text, "SELECT Point_name,point_ID,PV_X FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
                    foreach (DataRow DR in dt1.Rows)
                    {
                        P_X = Convert.ToString(DR["PV_X"]);                       
                    }                   
                }
                else if (PublicClass.checkparent == "Vel")
                {
                    DataTable dt1 = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,P1V_X FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
                    foreach (DataRow DR in dt1.Rows)
                    {
                        P_X = Convert.ToString(DR["P1V_X"]);
                    }    
                }
                else if (PublicClass.checkparent == "Displ")
                {
                    DataTable dt1 = DbClass.getdata(CommandType.Text, " SELECT Point_name,point_ID,P2V_X FROM point_data where Point_ID = '" + PublicClass.SPointID + "'");
                    foreach (DataRow DR in dt1.Rows)
                    {
                        P_X = Convert.ToString(DR["P2V_X"]);
                    }   
                }
                if (P_X != "0|" || P_X != "" || P_X != null)
                {
                    graph.TopLevel = false;
                    pnlGraph.Controls.Add(graph);
                    graph.ShowgraphsC911();
                    graph.Dock = DockStyle.Fill;
                    TabGraph.PageVisible = true;
                    CtrTab.SelectedTabPageIndex = 12;
                    graph.Show();
                }
                else
                {
                    MessageBox.Show(this, "Data is not available on this Point at this Channel", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch { }
        }       
    
    }
}