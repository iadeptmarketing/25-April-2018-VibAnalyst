using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using DevComponents.DotNetBar;
using System.Drawing.Imaging;
using System.Xml;
using System.IO;
using DevComponents.DotNetBar.Controls;
using Iadeptmain.GlobalClasses;
using Iadeptmain.Classes;

namespace Iadeptmain.Mainforms
{
    public partial class frmmachine : DevExpress.XtraBars.Ribbon.RibbonForm// Form
    {
        Hashtable hashClass = new Hashtable();
        ArrayList Subclass = new ArrayList();
        XmlDocument MachineXML = null;

        int xlocation = 0;
        int ylocation = 0;
        int xctr = 0;
        int totalcount = 0;

        Icomponents _ButtonComponents = new buttonComponents();
        ImageList componentImagelist = new ImageList();
        string xPath = null;
        string CurrentDatabaseinUse = null;
        public string DatabaseName
        {
            get
            {
                return CurrentDatabaseinUse;
            }
            set
            {
                CurrentDatabaseinUse = value;
            }
        }
        public frmmachine()
        {
            InitializeComponent();
            filltreelist();
            _ButtonComponents._MainForm = this;
        }


        private void LoadHierarchyFromXml(string xpath)
        {
            // _xmlinterface.LoadDatafromXML(xPath, trlPlantMangerComponents);
        }

        private void closeapplication()
        {
            Environment.Exit(1);
        }

        private void CalcGeneralPageVariables2(string Target)
        {
            int Target2 = 0;
            try
            {
                Target2 = Convert.ToInt32(Target);
                if (Target2 == 10 || Target2 == 2 || Target2 == 18 || Target2 == 26)
                {
                    _CBHorizontal = true;
                    _CBAxial = false;
                    _CBVertical = false;

                }
                if (Target2 == 12 || Target2 == 20 | Target2 == 28 || Target2 == 4)
                {
                    _CBVertical = true;
                    _CBAxial = false;
                    _CBHorizontal = false;

                }
                if (Target2 == 7 || Target2 == 15 || Target2 == 31 || Target2 == 23 || Target2 == 0)
                {
                    _CBHorizontal = true;
                    _CBVertical = true;
                    _CBAxial = true;

                }
                if (Target2 == 6 || Target2 == 14 || Target2 == 30 || Target2 == 22)
                {
                    _CBHorizontal = true;
                    _CBVertical = true;
                    _CBAxial = false;

                }
                if (Target2 == 5 || Target2 == 13 || Target2 == 21 || Target2 == 29)
                {
                    _CBAxial = true;
                    _CBVertical = true;
                    _CBHorizontal = false;
                }
                if (Target2 == 3 || Target2 == 27 || Target2 == 11 || Target2 == 19)
                {
                    _CBAxial = true;
                    _CBHorizontal = true;
                    _CBVertical = false;


                }
                if (Target2 == 1 || Target2 == 25 || Target2 == 17 || Target2 == 9)
                {
                    _CBAxial = true;
                    _CBHorizontal = false;
                    _CBVertical = false;

                }


            }
            catch (Exception ex)
            {
            }
        }




        void _ButtonDiagram_Click(object sender, EventArgs e)
        {
            ButtonX _button = (ButtonX)sender;
            string button = _button.Tag.ToString();
            if (buttontype != null)
            {
                Areaid = trlPlantMangerComponents.FocusedNode.ParentNode.GetDisplayText(0);
                macid = trlPlantMangerComponents.FocusedNode.GetDisplayText(0);
                DataTable dt = DbClass.getdata(CommandType.Text, "select * from machine_type where Area_Id='" + Areaid + "' && Mac_Id='" + macid + "' && Mac_Tag='" + button + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    _TxtBoxName = Convert.ToString(dr["Mac_Name"]);
                    _TxtBoxRPM = Convert.ToString(dr["Mac_RPM"]);
                    _TxtBoxSerial = Convert.ToString(dr["Mac_SerialNo"]);
                    _TxtBoxMake = Convert.ToString(dr["Mac_Make"]);
                    _TxtBoxSenX = Convert.ToString(dr["Sen_X"]);
                    _TxtBoxSenY = Convert.ToString(dr["Sen_Y"]);
                    _TxtBoxSenZ = Convert.ToString(dr["Sen_Z"]);
                    CalcGeneralPageVariables2(Convert.ToString(dr["Sen_Cal"]));
                    _CMBDirection = Convert.ToString(dr["sen_dir"]);
                    _CMBSensorUnit = Convert.ToString(dr["sen_unit"]);
                    _CMBSensorType = Convert.ToString(dr["Sen_type"]);
                }
            }
        }

        string Areaid = null;
        string macid = null;
        string buttontype = null;
        private void buttonX_Click(object sender, EventArgs e)
        {
            TreeListNode objResourceNode = trlPlantMangerComponents.FocusedNode;
            if (objResourceNode != null)
            {
                if (objResourceNode.Tag.ToString() == "TRAIN")
                {
                    Areaid = trlPlantMangerComponents.FocusedNode.ParentNode.GetDisplayText(0);
                    macid = trlPlantMangerComponents.FocusedNode.GetDisplayText(0);
                    ButtonX _button = (ButtonX)sender;
                    classbuttonclick(_button);
                }
                else
                {
                    MessageBoxEx.Show("Select a Machine to add component");
                }
            }
            else
            {
                MessageBoxEx.Show("To add a component add Machine Node first");
            }
        }

        private void classbuttonclick(ButtonX _button)
        {
            ArrayList description = _ButtonComponents.AddComponentsForButton(_button.Text);
            if (description != null)
            {
                buttontype = _button.Text;
                AddImageButtonOnMain(_button, description);
            }
        }

        public void retrieveimage(string machinetype)
        {
            try
            {
                ButtonX _ButtonDiagram = new ButtonX();
                _ButtonDiagram.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
                _ButtonDiagram.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
                _ButtonDiagram.Click += new EventHandler(_ButtonDiagram_Click);
                _ButtonDiagram.KeyDown += new KeyEventHandler(_ButtonDiagram_KeyDown);
                if (xctr * totalcount > panelEx2.Controls.Count) //if (xctr * totalcount > panelDockContainerMainWindow.Controls.Count)
                {
                    xctr = CheckForCorrectLocation(xctr, totalcount, panelEx2.Controls.Count);// panelDockContainerMainWindow.Controls.Count);
                }
                xlocation = Math.Abs((panelEx2.Controls.Count - (xctr * totalcount)) * 80);//xlocation = Math.Abs((panelDockContainerMainWindow.Controls.Count - (xctr * totalcount)) * 80);

                if (xlocation >= (panelEx2.Width - 70))// (panelDockContainerMainWindow.Width - 70))
                {
                    ylocation += 80;
                    xlocation = 0;
                    xctr += 1;
                    if (totalcount < 1)
                    {
                        totalcount = panelEx2.Controls.Count;// panelDockContainerMainWindow.Controls.Count;
                    }
                }
                _ButtonDiagram.Location = new System.Drawing.Point(xlocation, ylocation);

                _ButtonDiagram.Name = machinetype;//"button" + panelDockContainerMainWindow.Controls.Count;//button name
                _ButtonDiagram.Size = new System.Drawing.Size(80, 80);
                _ButtonDiagram.TabIndex = panelEx2.Controls.Count;// panelDockContainerMainWindow.Controls.Count;

                _ButtonDiagram.Tag = panelEx2.Controls.Count;// panelDockContainerMainWindow.Controls.Count;  //_button.Text.ToString(); // button item(eg.motor, fan etc)

                //_xmlinterface.AddComponentNode(_button.Text, xPath, trlPlantMangerComponents.FocusedNode,panelEx2.Controls.Count,description);// panelDockContainerMainWindow.Controls.Count);

                SetimagesonButton(_ButtonDiagram, machinetype);

                panelEx2.Controls.Add(_ButtonDiagram);//panelDockContainerMainWindow.Controls.Add(_ButtonDiagram);
                _ButtonDiagram_Click(_ButtonDiagram, null);
            }
            catch { }
        }




        // to be sent to a seperate class
        private void AddImageButtonOnMain(ButtonX _button, ArrayList description)
        {
            ButtonX _ButtonDiagram = new ButtonX();
            _ButtonDiagram.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            _ButtonDiagram.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            _ButtonDiagram.Click += new EventHandler(_ButtonDiagram_Click);
            _ButtonDiagram.KeyDown += new KeyEventHandler(_ButtonDiagram_KeyDown);
            if (xctr * totalcount > panelEx2.Controls.Count) //if (xctr * totalcount > panelDockContainerMainWindow.Controls.Count)
            {
                xctr = CheckForCorrectLocation(xctr, totalcount, panelEx2.Controls.Count);// panelDockContainerMainWindow.Controls.Count);
            }
            xlocation = Math.Abs((panelEx2.Controls.Count - (xctr * totalcount)) * 80);//xlocation = Math.Abs((panelDockContainerMainWindow.Controls.Count - (xctr * totalcount)) * 80);

            if (xlocation >= (panelEx2.Width - 70))// (panelDockContainerMainWindow.Width - 70))
            {
                ylocation += 80;
                xlocation = 0;
                xctr += 1;
                if (totalcount < 1)
                {
                    totalcount = panelEx2.Controls.Count;// panelDockContainerMainWindow.Controls.Count;
                }
            }
            _ButtonDiagram.Location = new System.Drawing.Point(xlocation, ylocation);

            _ButtonDiagram.Name = _button.Text;//"button" + panelDockContainerMainWindow.Controls.Count;//button name
            _ButtonDiagram.Size = new System.Drawing.Size(80, 80);
            _ButtonDiagram.TabIndex = panelEx2.Controls.Count;// panelDockContainerMainWindow.Controls.Count;

            _ButtonDiagram.Tag = panelEx2.Controls.Count;// panelDockContainerMainWindow.Controls.Count;  //_button.Text.ToString(); // button item(eg.motor, fan etc)

            //_xmlinterface.AddComponentNode(_button.Text, xPath, trlPlantMangerComponents.FocusedNode,panelEx2.Controls.Count,description);// panelDockContainerMainWindow.Controls.Count);
            DbClass.executequery(CommandType.Text, "insert into machine_type(Area_Id,Mac_Id,Mac_Name,Mac_type,Mac_RPM,Mac_SerialNo,Mac_Make,Sen_ID,Sen_type,sen_unit,sen_dir,Sen_X,Sen_Y,Sen_Z,Sen_cal,Mac_Tag)values('" + Areaid + "','" + macid + "','" + description[0] + "','" + buttontype + "','" + description[3] + "','" + description[1] + "','" + description[2] + "','" + description[14] + "','" + description[4] + "','" + description[5] + "','" + description[6] + "','" + description[7] + "','" + description[8] + "','" + description[9] + "','" + description[13] + "','" + _ButtonDiagram.Tag + "')");

            SetimagesonButton(_ButtonDiagram, _button.Text);



            panelEx2.Controls.Add(_ButtonDiagram);//panelDockContainerMainWindow.Controls.Add(_ButtonDiagram);
            _ButtonDiagram_Click(_ButtonDiagram, null);
        }



        // to be sent to a seperate class
        private int CheckForCorrectLocation(int xctr, int totalcount, int controlcount)
        {
            xctr -= 1;
            ylocation -= 80;
            if (xctr * totalcount > controlcount)
            {
                xctr = CheckForCorrectLocation(xctr, totalcount, controlcount);
            }
            return xctr;
        }

        void _ButtonDiagram_KeyDown(object sender, KeyEventArgs e)
        {
            ButtonX _button = (ButtonX)sender;
            if (e.KeyCode == Keys.Delete)
            {
                int _CurrentIndex = panelEx2.Controls.IndexOf(_button);
                string[] a = _button.Name.ToString().Split(new string[] { "button" }, StringSplitOptions.RemoveEmptyEntries);

                if (_CurrentIndex == panelEx2.Controls.Count - 1)//((Convert.ToInt32(a[0]) + 1) == panelEx2.Controls.Count)// panelDockContainerMainWindow.Controls.Count)
                {
                    if (DialogResult.Yes == MessageBoxEx.Show("Are you sure you want to delete this component", "Confirm Deletion", MessageBoxButtons.YesNo))
                    {
                        panelEx2.Controls.RemoveAt(_CurrentIndex);// panelDockContainerMainWindow.Controls.Remove(_button);
                        //  _xmlinterface.RemoveComponentButton(_button, trlPlantMangerComponents.FocusedNode, xPath);
                    }
                }
                else
                {
                    MessageBoxEx.Show("Cannot delete from the mid of the diagram.  Can delete only the last component of the diagram");
                }

            }
        }

        string ids = null;
        public void filltreelist()
        {
            DataTable AreaDT = new DataTable();
            DataTable TrainDT = new DataTable();
            int r = 0;
            try
            {
                AreaDT = DbClass.getdata(CommandType.Text, "select * from machine_diagram;");
                TrainDT = DbClass.getdata(CommandType.Text, "select * from machine_diagram_train;");

                trlPlantMangerComponents.ClearNodes();
                TreeListNode parentForRootForFactory11 = null;
                TreeListNode parentForRootForResorce11 = null;

                foreach (DataRow FactoryRow in AreaDT.Rows)
                {
                    ids = null;
                    ids = "a.Area_id = " + Convert.ToString(FactoryRow["Area_id"]);
                    parentForRootForFactory11 = trlPlantMangerComponents.AppendNode(new object[] { Convert.ToString(FactoryRow["Area_id"]), "Area", "1" }, null, "AREA");
                    foreach (DataRow AreaRow in TrainDT.Select("Area_id = '" + Convert.ToString(FactoryRow["Area_id"]) + "'"))
                    {
                        ids = null;
                        ids = "t.train_id = " + Convert.ToString(AreaRow["train_id"]);
                        parentForRootForResorce11 = trlPlantMangerComponents.AppendNode(new object[] { Convert.ToString(AreaRow["train_id"]), "Train", parentForRootForFactory11 }, parentForRootForFactory11, "TRAIN");
                    }
                }
                trlPlantMangerComponents.ExpandAll();

            }
            catch
            {
                trlPlantMangerComponents.ClearNodes();
                TreeListNode parentForRootForFactory11 = null;
                TreeListNode parentForRootForResorce11 = null;

                foreach (DataRow FactoryRow in AreaDT.Rows)
                {
                    ids = null;
                    ids = "a.Area_id = " + Convert.ToString(FactoryRow["Area_id"]);
                    parentForRootForFactory11 = trlPlantMangerComponents.AppendNode(new object[] { Convert.ToString(FactoryRow["Area_id"]), "Area", "1" }, null, "AREA");
                    foreach (DataRow AreaRow in TrainDT.Select("Area_id = '" + Convert.ToString(FactoryRow["Area_id"]) + "'"))
                    {
                        ids = null;
                        ids = "t.train_id = " + Convert.ToString(AreaRow["train_id"]);
                        parentForRootForResorce11 = trlPlantMangerComponents.AppendNode(new object[] { Convert.ToString(AreaRow["train_id"]), "Train", parentForRootForFactory11 }, parentForRootForFactory11, "TRAIN");
                    }
                }
                trlPlantMangerComponents.ExpandAll();
            }
        }



        private void buttoncreateArea_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode objNewNode = null;
                int count = trlPlantMangerComponents.Nodes.Count;
                string AreaUid = 1 + count + "";
                objNewNode = trlPlantMangerComponents.AppendNode(new object[] { AreaUid.ToString(), "Area", "1" }, null, "AREA");
                objNewNode.Tag = "AREA";
                DbClass.executequery(CommandType.Text, "insert machine_diagram (Area_ID,datetime ) values ( '" + Convert.ToInt32(AreaUid.ToString()) + "','" + PublicClass.GetDatetime() + "') ");
            }
            catch { }
        }

        private void buttonCreateMachine_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode objNewNode = null;
                TreeListNode objResourceNode = trlPlantMangerComponents.FocusedNode;
                string snode = trlPlantMangerComponents.FocusedNode.GetDisplayText(0);
                if (objResourceNode != null)
                {
                    int i = objResourceNode.Nodes.Count;
                    string TrainUid = i + 1 + "";
                    if (objResourceNode.Tag.ToString() == "AREA")
                    {
                        objNewNode = trlPlantMangerComponents.AppendNode(new object[] { TrainUid.ToString(), "Train", objResourceNode.GetDisplayText(0) }, objResourceNode, "TRAIN");
                        objNewNode.Tag = "TRAIN";
                        DbClass.executequery(CommandType.Text, "insert machine_diagram_train (Area_ID ,train_id,datetime ) values ( '" + Convert.ToInt32(snode) + "','" + Convert.ToInt32(TrainUid.ToString()) + "','" + PublicClass.GetDatetime() + "') ");
                    }
                }
                else
                {
                    MessageBoxEx.Show("Please select an Area Node for addition of Machine Node");
                }
            }
            catch { }
        }

        public void DeleteTrain(string sTrID)
        {
            try
            {
                DataTable dtt1 = new DataTable();
                dtt1 = DbClass.getdata(CommandType.Text, "Select * from machine_diagram_train where train_ID = '" + sTrID + "' and area_id='" + Areaid + "' ");

                foreach (DataRow dr in dtt1.Rows)
                {
                    string macID = Convert.ToString(dr["train_ID"]);
                    DbClass.executequery(CommandType.Text, "Delete from machine_type where Mac_Id = '" + macID + "' and Area_id ='" + Areaid + "'");
                }
                DbClass.executequery(CommandType.Text, "Delete from machine_diagram_train where train_ID = '" + sTrID + "' and area_id='" + Areaid + "' ");

            }
            catch { }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckName == "AREA")
                {
                    if (DialogResult.Yes == MessageBoxEx.Show("Are you sure you want to delete this Area", "Confirm Deletion", MessageBoxButtons.YesNo))
                    {
                        Areaid = trlPlantMangerComponents.FocusedNode.GetDisplayText(0);
                        DataTable dtTrain = DbClass.getdata(CommandType.Text, "Select train_id from machine_diagram_train where area_id = '" + Areaid + "'");
                        foreach (DataRow dr in dtTrain.Rows)
                        {
                            DeleteTrain(Convert.ToString(dr["train_id"]));
                        }
                        DbClass.executequery(CommandType.Text, "Delete from machine_diagram where Area_id = '" + Areaid + "'");
                        filltreelist();
                        _ButtonComponents._MainForm = this;
                    }


                }
                else if (CheckName == "TRAIN")
                {
                    if (DialogResult.Yes == MessageBoxEx.Show("Are you sure you want to delete this Train", "Confirm Deletion", MessageBoxButtons.YesNo))
                    {
                        DeleteTrain(macid);
                        filltreelist();
                        _ButtonComponents._MainForm = this;
                    }
                }
            }
            catch { }

        }
        void selectChildren(TreeListNode parent, ArrayList selectedNodes)
        {
            IEnumerator en = parent.Nodes.GetEnumerator();
            TreeListNode child;
            while (en.MoveNext())
            {
                child = (TreeListNode)en.Current;
                selectedNodes.Add(child);
                if (child.HasChildren) selectChildren(child, selectedNodes);
            }
        }
        string CheckName = null;
        private void trlPlantMangerComponents_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                Areaid = null;
                macid = null;
                CheckName = e.Node.Tag.ToString();
                InitializeDescription();
                if (e.Node.Tag.ToString() == "TRAIN")
                {
                    if (!expandablePanel1.Expanded)
                    {
                        expandablePanel1.Expanded = true;
                    }
                    xlocation = 0;
                    ylocation = 0;
                    xctr = 0;
                    totalcount = 0;
                    Areaid = trlPlantMangerComponents.FocusedNode.ParentNode.GetDisplayText(0);
                    macid = trlPlantMangerComponents.FocusedNode.GetDisplayText(0);
                    panelEx2.Controls.Clear();// panelDockContainerMainWindow.Controls.Clear();
                    DataTable dt = DbClass.getdata(CommandType.Text, "select * from machine_type where Area_Id='" + Areaid + "' && Mac_Id='" + macid + "'");
                    foreach (DataRow dr in dt.Rows)
                    {
                        _TxtBoxName = Convert.ToString(dr["Mac_Name"]);
                        _TxtBoxRPM = Convert.ToString(dr["Mac_RPM"]);
                        _TxtBoxSerial = Convert.ToString(dr["Mac_Make"]);
                        _TxtBoxMake = Convert.ToString(dr["Mac_Make"]);
                        _TxtBoxSenX = Convert.ToString(dr["Sen_X"]);
                        _TxtBoxSenY = Convert.ToString(dr["Sen_Y"]);
                        _TxtBoxSenZ = Convert.ToString(dr["Sen_Z"]);
                        //_CBAxial = false;
                        //_CBHorizontal = false;
                        //_CBVertical = false;
                        _CMBDirection = Convert.ToString(dr["sen_dir"]);
                        _CMBSensorUnit = Convert.ToString(dr["sen_unit"]);
                        _CMBSensorType = Convert.ToString(dr["Sen_type"]);
                        buttontype = Convert.ToString(dr["Mac_type"]);
                        retrieveimage(buttontype);
                    }

                    // _xmlinterface.GetMachineControls(xPath, e.Node);
                }
                else
                {
                    expandablePanel1.Expanded = false;
                    panelEx2.Controls.Clear();
                }
            }
        }

        private void InitializeDescription()
        {
            _TxtBoxName = "";
            _TxtBoxRPM = "";
            _TxtBoxSerial = "";
            _TxtBoxMake = "";
            _TxtBoxSenX = "";
            _TxtBoxSenY = "";
            _TxtBoxSenZ = "";
            _CBAxial = false;
            _CBHorizontal = false;
            _CBVertical = false;
            _CMBDirection = "0";
            _CMBSensorUnit = "0";
            _CMBSensorType = "0";
        }

        // to be sent to a seperate class
        public void Addcomponents(string Name, string ID)
        {
            ButtonX _ButtonDiagram = new ButtonX();
            _ButtonDiagram.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            _ButtonDiagram.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            _ButtonDiagram.Click += new EventHandler(_ButtonDiagram_Click);
            _ButtonDiagram.KeyDown += new KeyEventHandler(_ButtonDiagram_KeyDown);
            if (xctr * totalcount > panelDockContainerMainWindow.Controls.Count)
            {
                xctr = CheckForCorrectLocation(xctr, totalcount, panelEx2.Controls.Count);// panelDockContainerMainWindow.Controls.Count);
            }
            xlocation = Math.Abs((panelEx2.Controls.Count - (xctr * totalcount)) * 80);//xlocation = Math.Abs((panelDockContainerMainWindow.Controls.Count - (xctr * totalcount)) * 80);

            if (xlocation >= (panelEx2.Width - 70))// (panelDockContainerMainWindow.Width - 70))
            {
                ylocation += 80;
                xlocation = 0;
                xctr += 1;
                if (totalcount < 1)
                {
                    totalcount = panelDockContainerMainWindow.Controls.Count;
                }
            }
            _ButtonDiagram.Location = new System.Drawing.Point(xlocation, ylocation);

            _ButtonDiagram.Name = Name;//"button" + panelEx2.Controls.Count;// panelDockContainerMainWindow.Controls.Count;
            _ButtonDiagram.Size = new System.Drawing.Size(80, 80);
            _ButtonDiagram.TabIndex = panelEx2.Controls.Count;// panelDockContainerMainWindow.Controls.Count;

            _ButtonDiagram.Tag = ID;  //Name.ToString();

            SetimagesonButton(_ButtonDiagram, Name);


            panelEx2.Controls.Add(_ButtonDiagram);
            //panelDockContainerMainWindow.Controls.Add(_ButtonDiagram);
            //_ButtonDiagram_Click(_ButtonDiagram, null);
        }

        // to be sent to a seperate class
        private void SetimagesonButton(ButtonX _ButtonDiagram, string Name)
        {
            Imageclass.SetImages(_ButtonDiagram, Name);
        }


        private void cmbSenDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSenDir.SelectedItem.ToString().ToLower() == "uniaxial")
            {
                SensorTriAxial = false;
            }
            else if (cmbSenDir.SelectedItem.ToString().ToLower() == "triaxial")
            {
                SensorTriAxial = true;
            }
        }

        #region itemproperties

        public string _TxtBoxName
        {
            get
            {
                return tbName.Text;
            }
            set
            {
                tbName.Text = value;
            }
        }
        public string _TxtBoxRPM
        {
            get
            {
                return tbRPM.Text;
            }
            set
            {
                tbRPM.Text = value;
            }
        }
        public string _TxtBoxSerial
        {
            get
            {
                return tbSerial.Text;
            }
            set
            {
                tbSerial.Text = value;
            }
        }
        public string _TxtBoxMake
        {
            get
            {
                return tbMake.Text;
            }
            set
            {
                tbMake.Text = value;
            }
        }
        public string _TxtBoxSenX
        {
            get
            {
                return tbSenX.Text;
            }
            set
            {
                tbSenX.Text = value;
            }
        }
        public string _TxtBoxSenY
        {
            get
            {
                return tbSenY.Text;
            }
            set
            {
                tbSenY.Text = value;
            }
        }
        public string _TxtBoxSenZ
        {
            get
            {
                return tbSenZ.Text;
            }
            set
            {
                tbSenZ.Text = value;
            }
        }
        public bool _CBAxial
        {
            get
            {
                return cbAxial.Checked;
            }
            set
            {
                cbAxial.Checked = value;
            }
        }
        public bool _CBHorizontal
        {
            get
            {
                return cbHori.Checked;
            }
            set
            {
                cbHori.Checked = value;
            }
        }
        public bool _CBVertical
        {
            get
            {
                return cbVert.Checked;
            }
            set
            {
                cbVert.Checked = value;
            }
        }
        public string _CMBDirection
        {
            get
            {
                return cmbSenDir.SelectedItem.ToString();
            }
            set
            {
                cmbSenDir.SelectedIndex = Convert.ToInt32(value);
            }
        }
        public string _CMBSensorUnit
        {
            get
            {
                return cmbSenUnit.SelectedItem.ToString();
            }
            set
            {

                cmbSenUnit.SelectedIndex = Convert.ToInt32(value);
            }
        }
        public string _CMBSensorType
        {
            get
            {
                return cmbSenType.SelectedItem.ToString();
            }
            set
            {

                cmbSenType.SelectedIndex = Convert.ToInt32(value);
            }
        }

        #endregion




        public bool SensorTriAxial
        {
            set
            {
                tbSenY.Visible = value;
                tbSenZ.Visible = value;
                labeluniY.Visible = value;
                labeluniZ.Visible = value;
                cbAxial.Visible = !value;
                cbHori.Visible = !value;
                cbVert.Visible = !value;
            }
        }

        private void cmbSenDir_TextChanged(object sender, EventArgs e)
        {
            if (cmbSenDir.Text.ToString().ToLower() == "uniaxial")
            {
                SensorTriAxial = false;
            }
            else if (cmbSenDir.Text.ToString().ToLower() == "triaxial")
            {
                SensorTriAxial = true;
            }
        }


        public bool fcheck = false;
        private void BBGenerate_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBoxEx.Show("Are You Sure?", "Create Hierarchy", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                chkclose = true;
                this.Close();
            }
        }

        private void cmbSenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSenUnit.Items.Clear();

            if (cmbSenType.SelectedItem.ToString() == "Acceleration")
            {
                cmbSenUnit.Items.AddRange(new object[] { ("Gs"), ("gal"), ("m/s2") });
            }
            else if (cmbSenType.SelectedItem.ToString() == "Velocity")
            {
                cmbSenUnit.Items.AddRange(new object[] { ("mm/s"), ("in/s"), ("cm/s") });
            }
            else if (cmbSenType.SelectedItem.ToString() == "Displacement")
            {
                cmbSenUnit.Items.AddRange(new object[] { ("mil"), ("um") });
            }
            cmbSenUnit.SelectedIndex = 0;
        }


        public bool chkclose = false;

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            chkclose = false;
            this.Close();
        }

    }
}
