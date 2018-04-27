using Iadeptmain.BaseUserControl;
using Iadeptmain.Classes;
using Iadeptmain.Mainforms;
using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iadeptmain.GlobalClasses
{
    public class ClsCommon
    {
        LineGraphControl _LineGraph = new LineGraphControl();        
        ResizeArray_Interface _ResizeArray = new ResizeArray_Control();

        frmIAdeptMain MainForm = null;
        public frmIAdeptMain _MainForm
        {
            get
            {
                return MainForm;
            }
            set
            {
                MainForm = value;
            }
        }

        frmGControls objGcontrol = null;
        public frmGControls _Maincontrol
        {
            get
            {
                return objGcontrol;
            }
            set
            {
                objGcontrol = value;
            }
        }

        //---------------multiple graph-----------------//

        public void DrawMultiGraph(ArrayList arrXYVals, int NumberofGraphs, int Band1, int Band2, string high, string low,string dir)
        {
            try
            {
                int[] band = new int[2];
                band[0] = Band1;
                band[1] = Band2;
                double[] xData = (double[])arrXYVals[0];
                double[] yData = (double[])arrXYVals[1];

                ArrayList CutarrxVals = new ArrayList();
                ArrayList CutarryVals = new ArrayList();
                PublicClass.Chart_Footer = null;
                for (int i = 0; i < NumberofGraphs; i++)
                {
                    double[] CutxData = new double[0];
                    double[] CutyData = new double[0];

                    for (int j = 0; j < xData.Length; j++)
                    {
                        if (xData[j] <= (double)band[i])
                        {
                            _ResizeArray.IncreaseArrayDouble(ref CutxData, 1);
                            CutxData[CutxData.Length - 1] = xData[j];

                            _ResizeArray.IncreaseArrayDouble(ref CutyData, 1);
                            CutyData[CutyData.Length - 1] = yData[j];
                        }
                        else
                        {
                            break;
                        }
                    }
                    CutarrxVals.Add(CutxData);
                    CutarryVals.Add(CutyData);
                }
                switch (NumberofGraphs)
                {                   
                    case 2:
                        {
                            if (dir == "Axial")
                            {
                                DrawCutLineGraph1high(CutarrxVals, CutarryVals, high);
                                DrawCutLineGraph2low(CutarrxVals, CutarryVals, low);
                            }
                            else if (dir == "Horizontal")
                            {
                                DrawCutLineGraph1highhor(CutarrxVals, CutarryVals, high);
                                DrawCutLineGraph2lowhor(CutarrxVals, CutarryVals, low);
                            }
                            else if (dir == "Vertical")
                            {
                                DrawCutLineGraph1highver(CutarrxVals, CutarryVals, high);
                                DrawCutLineGraph2lowver(CutarrxVals, CutarryVals, low);
                            }
                            else if (dir == "Channel1")
                            {
                                DrawCutLineGraph1highchann(CutarrxVals, CutarryVals, high);
                                DrawCutLineGraph2lowchann(CutarrxVals, CutarryVals, low);
                            }
                            break;
                        }

                }
            }
            catch
            { }
        }

        //--Axial--//
        private void DrawCutLineGraph1high(ArrayList CutarrxVals, ArrayList CutarryVals, string high)
        {
            try
            {
                MainForm._LineGraph_cut1.Name = "Graph";
                PublicClass.Chart_Footer = high;
                MainForm._LineGraph_cut1.AllowDrop = false;
                MainForm._LineGraph_cut1._MainForm = MainForm;
                MainForm._LineGraph_cut1._XLabel = PublicClass.x_Unit;
                MainForm._LineGraph_cut1._YLabel = PublicClass.y_Unit;
                MainForm._LineGraph_cut1._DataGridView = objGcontrol.dataGridView1;
                MainForm._LineGraph_cut1._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut1._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut1._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut1._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut1._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut1._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut1._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut1._MainCursorColor = MainForm._MainCursorColor;

                _LineGraph.Dock = DockStyle.Top;
                _LineGraph.Height = objGcontrol.panel1.Height / 2;
                MainForm._LineGraph_cut1.Height = objGcontrol.panel1.Height / 2;
                MainForm._LineGraph_cut1.Dock = DockStyle.Top;
                MainForm._LineGraph_cut1.DrawLineGraph((double[])CutarrxVals[0], (double[])CutarryVals[0]);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut1);
                objGcontrol.panel1.AutoScroll = true;
            }
            catch
            {
            }
        }
        private void DrawCutLineGraph2low(ArrayList CutarrxVals, ArrayList CutarryVals, string low)
        {
            try
            {
               // _LineGraph_cut2 = new LineGraphControl();
                MainForm._LineGraph_cut2.Name = "Graph";
                PublicClass.Chart_Footer = low;
                MainForm._LineGraph_cut2.AllowDrop = false;
                MainForm._LineGraph_cut2._MainForm = MainForm;
                MainForm._LineGraph_cut2._XLabel = PublicClass.x_Unit;
                MainForm._LineGraph_cut2._YLabel = PublicClass.y_Unit;
                MainForm._LineGraph_cut2._DataGridView = objGcontrol.dataGridView1;
                MainForm._LineGraph_cut2._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut2._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut2._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut2._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut2._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut2._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut2._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut2._MainCursorColor = MainForm._MainCursorColor;

                _LineGraph.Dock = DockStyle.Top;
                _LineGraph.Height = objGcontrol.panel1.Height / 2;
                MainForm._LineGraph_cut2.Height = objGcontrol.panel1.Height / 2;
                MainForm._LineGraph_cut2.Dock = DockStyle.Top;
                MainForm._LineGraph_cut2.DrawLineGraph((double[])CutarrxVals[1], (double[])CutarryVals[1]);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut2);
            }
            catch
            {
            }
        }

        //--Horiz--//

        private void DrawCutLineGraph1highhor(ArrayList CutarrxVals, ArrayList CutarryVals, string high)
        {
            try
            {
                MainForm._LineGraph_cut3.Name = "Graph";
                PublicClass.Chart_Footer = high;
                MainForm._LineGraph_cut3.AllowDrop = false;
                MainForm._LineGraph_cut3._MainForm = MainForm;
                MainForm._LineGraph_cut3._XLabel = PublicClass.x_Unit;
                MainForm._LineGraph_cut3._YLabel = PublicClass.y_Unit;
                MainForm._LineGraph_cut3._DataGridView = objGcontrol.dataGridView1;
                MainForm._LineGraph_cut3._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut3._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut3._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut3._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut3._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut3._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut3._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut3._MainCursorColor = MainForm._MainCursorColor;

                _LineGraph.Dock = DockStyle.Top;
                _LineGraph.Height = objGcontrol.panel1.Height / 2;
                MainForm._LineGraph_cut3.Height = objGcontrol.panel1.Height / 2;
                MainForm._LineGraph_cut3.Dock = DockStyle.Top;

                MainForm._LineGraph_cut3.DrawLineGraph((double[])CutarrxVals[0], (double[])CutarryVals[0]);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut3);
                objGcontrol.panel1.AutoScroll = true;
            }
            catch
            {
            }
        }
        private void DrawCutLineGraph2lowhor(ArrayList CutarrxVals, ArrayList CutarryVals, string low)
        {
            try
            {
                // _LineGraph_cut2 = new LineGraphControl();
                MainForm._LineGraph_cut4.Name = "Graph";
                PublicClass.Chart_Footer = low;
                MainForm._LineGraph_cut4.AllowDrop = false;
                MainForm._LineGraph_cut4._MainForm = MainForm;
                MainForm._LineGraph_cut4._XLabel = PublicClass.x_Unit;
                MainForm._LineGraph_cut4._YLabel = PublicClass.y_Unit;
                MainForm._LineGraph_cut4._DataGridView = objGcontrol.dataGridView1;
                MainForm._LineGraph_cut4._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut4._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut4._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut4._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut4._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut4._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut4._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut4._MainCursorColor = MainForm._MainCursorColor;

                _LineGraph.Dock = DockStyle.Top;
                _LineGraph.Height = objGcontrol.panel1.Height / 2;
                MainForm._LineGraph_cut4.Height = objGcontrol.panel1.Height / 2;
                MainForm._LineGraph_cut4.Dock = DockStyle.Top;
                MainForm._LineGraph_cut4.DrawLineGraph((double[])CutarrxVals[1], (double[])CutarryVals[1]);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut4);
            }
            catch
            {
            }
        }

        //--Ver--//
        private void DrawCutLineGraph1highver(ArrayList CutarrxVals, ArrayList CutarryVals, string high)
        {
            try
            {
                MainForm._LineGraph_cut5.Name = "Graph";
                PublicClass.Chart_Footer = high;
                MainForm._LineGraph_cut5.AllowDrop = false;
                MainForm._LineGraph_cut5._MainForm = MainForm;
                MainForm._LineGraph_cut5._XLabel = PublicClass.x_Unit;
                MainForm._LineGraph_cut5._YLabel = PublicClass.y_Unit;
                MainForm._LineGraph_cut5._DataGridView = objGcontrol.dataGridView1;
                MainForm._LineGraph_cut5._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut5._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut5._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut5._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut5._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut5._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut5._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut5._MainCursorColor = MainForm._MainCursorColor;

                _LineGraph.Dock = DockStyle.Top;
                _LineGraph.Height = objGcontrol.panel1.Height / 2;
                MainForm._LineGraph_cut5.Height = objGcontrol.panel1.Height / 2;
                MainForm._LineGraph_cut5.Dock = DockStyle.Top;
                MainForm._LineGraph_cut5.DrawLineGraph((double[])CutarrxVals[0], (double[])CutarryVals[0]);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut5);
                objGcontrol.panel1.AutoScroll = true;
            }
            catch
            {
            }
        }
        private void DrawCutLineGraph2lowver(ArrayList CutarrxVals, ArrayList CutarryVals, string low)
        {
            try
            {
                // _LineGraph_cut2 = new LineGraphControl();
                MainForm._LineGraph_cut6.Name = "Graph";
                PublicClass.Chart_Footer = low;
                MainForm._LineGraph_cut6.AllowDrop = false;
                MainForm._LineGraph_cut6._MainForm = MainForm;
                MainForm._LineGraph_cut6._XLabel = PublicClass.x_Unit;
                MainForm._LineGraph_cut6._YLabel = PublicClass.y_Unit;
                MainForm._LineGraph_cut6._DataGridView = objGcontrol.dataGridView1;
                MainForm._LineGraph_cut6._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut6._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut6._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut6._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut6._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut6._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut6._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut6._MainCursorColor = MainForm._MainCursorColor;

                _LineGraph.Dock = DockStyle.Top;
                _LineGraph.Height = objGcontrol.panel1.Height / 2;
                MainForm._LineGraph_cut6.Height = objGcontrol.panel1.Height / 2;
                MainForm._LineGraph_cut6.Dock = DockStyle.Top;
                MainForm._LineGraph_cut6.DrawLineGraph((double[])CutarrxVals[1], (double[])CutarryVals[1]);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut6);
            }
            catch
            {
            }
        }

        //--Channel--//
        private void DrawCutLineGraph1highchann(ArrayList CutarrxVals, ArrayList CutarryVals, string high)
        {
            try
            {
                MainForm._LineGraph_cut7.Name = "Graph";
                PublicClass.Chart_Footer = high;
                MainForm._LineGraph_cut7.AllowDrop = false;
                MainForm._LineGraph_cut7._MainForm = MainForm;
                MainForm._LineGraph_cut7._XLabel = PublicClass.x_Unit;
                MainForm._LineGraph_cut7._YLabel = PublicClass.y_Unit;
                MainForm._LineGraph_cut7._DataGridView = objGcontrol.dataGridView1;
                MainForm._LineGraph_cut7._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut7._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut7._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut7._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut7._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut7._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut7._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut7._MainCursorColor = MainForm._MainCursorColor;

                _LineGraph.Dock = DockStyle.Top;
                _LineGraph.Height = objGcontrol.panel1.Height / 2;
                MainForm._LineGraph_cut7.Height = objGcontrol.panel1.Height / 2;
                MainForm._LineGraph_cut7.Dock = DockStyle.Top;
                MainForm._LineGraph_cut7.DrawLineGraph((double[])CutarrxVals[0], (double[])CutarryVals[0]);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut7);
                objGcontrol.panel1.AutoScroll = true;
            }
            catch
            {
            }
        }
        private void DrawCutLineGraph2lowchann(ArrayList CutarrxVals, ArrayList CutarryVals, string low)
        {
            try
            {
                // _LineGraph_cut2 = new LineGraphControl();
                MainForm._LineGraph_cut8.Name = "Graph";
                PublicClass.Chart_Footer = low;
                MainForm._LineGraph_cut8.AllowDrop = false;
                MainForm._LineGraph_cut8._MainForm = MainForm;
                MainForm._LineGraph_cut8._XLabel = PublicClass.x_Unit;
                MainForm._LineGraph_cut8._YLabel = PublicClass.y_Unit;
                MainForm._LineGraph_cut8._DataGridView = objGcontrol.dataGridView1;
                MainForm._LineGraph_cut8._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut8._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut8._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut8._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut8._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut8._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut8._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut8._MainCursorColor = MainForm._MainCursorColor;

                _LineGraph.Dock = DockStyle.Top;
                _LineGraph.Height = objGcontrol.panel1.Height / 2;
                MainForm._LineGraph_cut8.Height = objGcontrol.panel1.Height / 2;
                MainForm._LineGraph_cut8.Dock = DockStyle.Top;
                MainForm._LineGraph_cut8.DrawLineGraph((double[])CutarrxVals[1], (double[])CutarryVals[1]);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut8);
            }
            catch
            {
            }
        }

        //-- for UFF -- //
        
        public void DrawlineGraphsuff(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph.Name = "LineGraph 1";
                MainForm._LineGraph._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph._AreaFill = false;
                MainForm._LineGraph.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph);
            }
            catch (Exception ex)
            {
            }
        }

        public void DrawlineGraphsuff1(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph1.Name = "LineGraph 1";
                MainForm._LineGraph1._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph1._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph1._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph1._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph1._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph1._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph1._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph1._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph1._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph1.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph1.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph1._AreaFill = false;
                MainForm._LineGraph1.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph1);
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawlineGraphsuff2(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph2.Name = "LineGraph 1";
                MainForm._LineGraph2._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph2._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph2._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph2._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph2._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph2._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph2._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph2._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph2._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph2.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph2.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph2._AreaFill = false;
                MainForm._LineGraph2.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph2);
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawlineGraphsuff3(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph3.Name = "LineGraph 1";
                MainForm._LineGraph3._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph3._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph3._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph3._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph3._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph3._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph3._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph3._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph3._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph3.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph3.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph3._AreaFill = false;
                MainForm._LineGraph3.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph3);
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawlineGraphsuff4(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph4.Name = "LineGraph 1";
                MainForm._LineGraph4._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph4._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph4._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph4._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph4._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph4._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph4._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph4._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph4._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph4.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph4.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph4._AreaFill = false;
                MainForm._LineGraph4.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph4);
            }
            catch (Exception ex)
            {
            }
        }
       
        public void DrawlineGraphsuff5(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph5.Name = "LineGraph 1";
                MainForm._LineGraph5._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph5._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph5._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph5._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph5._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph5._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph5._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph5._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph5._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph5.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph5.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph5._AreaFill = false;
                MainForm._LineGraph5.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph5);
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawlineGraphsuff6(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph6.Name = "LineGraph 1";
                MainForm._LineGraph6._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph6._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph6._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph6._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph6._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph6._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph6._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph6._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph6._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph6.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph6.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph6._AreaFill = false;
                MainForm._LineGraph6.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph6);
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawlineGraphsuff7(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph_Dual.Name = "LineGraph 1";
                MainForm._LineGraph_Dual._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph_Dual._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_Dual._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_Dual._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_Dual._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_Dual._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_Dual._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_Dual._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_Dual._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph_Dual.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph_Dual.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph_Dual._AreaFill = false;
                MainForm._LineGraph_Dual.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_Dual);
            }
            catch (Exception ex)
            {
            }
        }
      
        public void DrawlineGraphsuff8(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph_cut1.Name = "LineGraph 1";
                MainForm._LineGraph_cut1._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph_cut1._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut1._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut1._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut1._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut1._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut1._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut1._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut1._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph_cut1.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph_cut1.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph_cut1._AreaFill = false;
                MainForm._LineGraph_cut1.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut1);
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawlineGraphsuff9(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph_cut2.Name = "LineGraph 1";
                MainForm._LineGraph_cut2._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph_cut2._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut2._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut2._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut2._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut2._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut2._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut2._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut2._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph_cut2.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph_cut2.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph_cut2._AreaFill = false;
                MainForm._LineGraph_cut2.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut2);
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawlineGraphsuff10(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph_cut3.Name = "LineGraph 1";
                MainForm._LineGraph_cut3._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph_cut3._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut3._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut3._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut3._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut3._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut3._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut3._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut3._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph_cut3.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph_cut3.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph_cut3._AreaFill = false;
                MainForm._LineGraph_cut3.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut3);
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawlineGraphsuff11(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph_cut4.Name = "LineGraph 1";
                MainForm._LineGraph_cut4._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph_cut4._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut4._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut4._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut4._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut4._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut4._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut4._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut4._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph_cut4.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph_cut4.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph_cut4._AreaFill = false;
                MainForm._LineGraph_cut4.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut4);
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawlineGraphsuff12(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph_cut5.Name = "LineGraph 1";
                MainForm._LineGraph_cut5._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph_cut5._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut5._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut5._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut5._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut5._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut5._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut5._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut5._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph_cut5.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph_cut5.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph_cut5._AreaFill = false;
                MainForm._LineGraph_cut5.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut5);
            }
            catch (Exception ex)
            {
            }
        }
       
        public void DrawlineGraphsuff13(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph_cut6.Name = "LineGraph 1";
                MainForm._LineGraph_cut6._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph_cut6._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut6._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut6._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut6._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut6._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut6._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut6._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut6._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph_cut6.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph_cut6.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph_cut6._AreaFill = false;
                MainForm._LineGraph_cut6.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut6);
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawlineGraphsuff14(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph_cut7.Name = "LineGraph 1";
                MainForm._LineGraph_cut7._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph_cut7._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut7._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut7._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut7._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut7._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut7._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut7._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut7._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph_cut7.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph_cut7.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph_cut7._AreaFill = false;
                MainForm._LineGraph_cut7.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut7);
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawlineGraphsuff15(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph_cut8.Name = "LineGraph 1";
                MainForm._LineGraph_cut8._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph_cut8._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut8._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut8._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut8._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut8._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut8._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut8._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut8._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph_cut8.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph_cut8.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph_cut8._AreaFill = false;
                MainForm._LineGraph_cut8.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut8);
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawlineGraphsuff16(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph_cut9.Name = "LineGraph 1";
                MainForm._LineGraph_cut9._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph_cut9._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut9._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut9._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut9._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut9._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut9._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut9._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut9._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph_cut9.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph_cut9.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph_cut9._AreaFill = false;
                MainForm._LineGraph_cut9.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut9);
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawlineGraphsuff17(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                MainForm._LineGraph_cut10.Name = "LineGraph 1";
                MainForm._LineGraph_cut10._MainForm = MainForm;
                //_LineGraph._XLabel = MainForm.XUnit;
                //_LineGraph._YLabel = MainForm.YUnit;
                MainForm._LineGraph_cut10._GraphBG1 = MainForm._GraphBG1;
                MainForm._LineGraph_cut10._GraphBG2 = MainForm._GraphBG2;
                MainForm._LineGraph_cut10._GraphBGDir = MainForm._GraphBGDir;
                MainForm._LineGraph_cut10._ChartBG1 = MainForm._ChartBG1;
                MainForm._LineGraph_cut10._ChartBG2 = MainForm._ChartBG2;
                MainForm._LineGraph_cut10._ChartBGDir = MainForm._ChartBGDir;
                MainForm._LineGraph_cut10._AxisColor = MainForm._AxisColor;
                MainForm._LineGraph_cut10._MainCursorColor = MainForm._MainCursorColor;
                MainForm._LineGraph_cut10.Height = objGcontrol.panel1.Height / (ictr);
                MainForm._LineGraph_cut10.Dock = System.Windows.Forms.DockStyle.Top;
                MainForm._LineGraph_cut10._AreaFill = false;
                MainForm._LineGraph_cut10.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(MainForm._LineGraph_cut10);
            }
            catch (Exception ex)
            {
            }
        }

        //-----create pointype for wav file-----//

        public string GetValueForMeasureTime(string iMeasureTime)
        {
            string m_sCurrentPointsDateTime = null;
            try
            {
                DateTime objDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);

                double sTimeTaken = Convert.ToDouble(iMeasureTime);
                objDateTime = objDateTime.AddSeconds(sTimeTaken);
                DateTime objNewDateTime = objDateTime.ToLocalTime();
                m_sCurrentPointsDateTime = objNewDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch { }

            return m_sCurrentPointsDateTime;
        }


        int PointIDUN; public int untypeid; string PointTypeName = null;
        public void ConvertPointType(string point_id)
        {
            try
            {
                string instname = PublicClass.currentInstrument;
                DataTable dtpoint = DbClass.getdata(CommandType.Text, "select max(ID)typepoint_id from Type_point");
                foreach (DataRow drsen in dtpoint.Rows)
                {
                    untypeid = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(drsen["typepoint_id"]), "0")) + 1;

                    string AlarmID = "0";
                    string sdID = "0";
                    string perID = "0";
                    if (MainForm.wavnode == "WAVFile")
                    {
                        PointTypeName = Convert.ToString("DefaultPointTypeWav-" + untypeid);
                    }
                    else
                    {
                        PointTypeName = Convert.ToString("DefaultPointTypeUFF-" + untypeid);
                    }
                    DbClass.executequery(CommandType.Text, "Insert into type_point(Point_Name,Type_ID,Instrumentname,Alarm_ID,STDDeviationAlarm_ID,Percentage_AlarmID,Band_ID) values('" + PointTypeName + "','1','"+instname+"','" + AlarmID + "','" + sdID + "','" + perID + "','0')");

                    DataTable dt1 = DbClass.getdata(CommandType.Text, "select distinct ID from type_point where Point_name='" + PointTypeName + "'");
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        untypeid = (Convert.ToInt32(dr1["ID"]));
                    }              
                }
                CalcGeneralPageVariables2(untypeid);
            }
            catch { }
        }

        public void CalcGeneralPageVariables2(int type)
        {
            try
            {
                if (MainForm.wavnode == "WAVFile")
                {
                    DbClass.executequery(CommandType.Text, "insert into  measure_type  (  OAcc, OVel, ODisp, OBear, OTWF, OPS, ODS, Temp, Process, crestfactor, Ordertrace, Cepstrum , Type_ID ,CalcMeasure  ) values('0','0','0','0','1','0','0','0','0','0','0','0','" + type + "','16')");
                }
                else
                {
                    DbClass.executequery(CommandType.Text, "insert into  measure_type  (  OAcc, OVel, ODisp, OBear, OTWF, OPS, ODS, Temp, Process, crestfactor, Ordertrace, Cepstrum , Type_ID ,CalcMeasure  ) values('0','0','0','0','0','1','0','0','0','0','0','0','" + type + "','32')");
                }
                Inser_Measuresforunschedule(type);
            }
            catch { }
        }

        public void Inser_Measuresforunschedule(int type)
        {
            try
            {
                string SensorDir = "1";
                string sensor_id = "1";
                string temperature_id = "2";
                string acc_filter = "0";
                string vel_filter = "0";
                string displ_filter = "0";
                string cfFilter = "0";
                string overallbearhp_filter = "0";
                string bearhp_filter = "0";

                string otveragetimes = "0";
                string otresolution = "0";
                string otorder = "1";
                string ottriggerslope = "0";

                string timeband = "4";
                string timeResol = "3";
                string timeoverlap = "0";

                string pwrmultiple = "1";
                string pbgroup1 = "4";
                string pwrResG1 = "3";
                string pwrB1G1 = "4";
                string pwrRes1G1 = "3";
                string pwrB2G1 = "4";
                string pwrRes2G2 = "3";
                string pwr2B1G2 = "4";
                string pwr2Res1G1 = "3";
                string pwr3BG3 = "4";
                string pwr3Res3G3 = "3";
                string pwr3B1G3 = "4";
                string pwr3Res1G3 = "3";
                string pwrWindow = "1";
                string pwrAvgTime = "1";
                string pwrOverlap = "0";
                int pwrZoom = 0;
                string pwrZoomSTF = "0";
                string cepBand = "4";
                string cepResol = "3";
                string cepWindow = "0";
                string cepAvgTime = "1";
                string cepOverlap = "0";
                int cepZoom = 0;
                string cepZoomSTF = "0";
                string demoBand = "4";
                string demoResol = "3";
                string demoWindow = "0";
                string demoAvgTime = "1";
                string demofilter = "0";

                DbClass.executequery(CommandType.Text, "Insert Into measure(acc_filter, vel_filter , displ_filter, overall_bearing_filter, crest_factor_filter,bearing_acc_hp_filter, time_band, time_resoltion, time_overlap,Date,Sensordir, sensor_id , TemperatureID, power_band  ,power_resolution   ,power_band1 ,power_resolution1  ,power2_band   ,power2_resolution, power2_band1,power2_resolution1,power3_band,power3_resolution,power3_band1,power3_resolution1, power_window,power_overlap,power_average_times,power_zoom,power_zoom_startfeq,cepstrum_band, cepstrum_resolution,cepstrum_window,cepstrum_average_times,cepstrum_overlap,cepstrum_zoom,cepstrum_zoom_startfeq,demodulate_band,demodulate_resolution,demodulate_window,demodulate_average_times ,demodulate_filter,ordertrace_average_times,ordertrace_resolution,ordertrace_order,ordertrace_trigger_slope,power_multiple,Type_ID)values(  '" + acc_filter + "' ,'" + vel_filter + "' ,'" + displ_filter + "' ,'" + overallbearhp_filter + "' ,'" + cfFilter + "' ,'" + bearhp_filter + "' ,'" + timeband + "' ,'" + timeResol + "' ,'" + timeoverlap + "' ,'" + PublicClass.GetDatetime() + "' ,'" + SensorDir + "' ,'" + sensor_id + "' ,'" + temperature_id + "' ,'" + pbgroup1 + "' ,'" + pwrResG1 + "' ,'" + pwrB1G1 + "' ,'" + pwrRes1G1 + "' ,'" + pwrB2G1 + "' ,'" + pwrRes2G2 + "' ,'" + pwr2B1G2 + "' ,'" + pwr2Res1G1 + "' ,'" + pwr3BG3 + "' ,'" + pwr3Res3G3 + "' ,'" + pwr3B1G3 + "' ,'" + pwr3Res1G3 + "' ,'" + pwrWindow + "' ,'" + pwrOverlap + "' ,'" + pwrAvgTime + "' ,'" + pwrZoom + "' ,'" + pwrZoomSTF + "' ,'" + cepBand + "' ,'" + cepResol + "' ,'" + cepWindow + "' ,'" + cepAvgTime + "' ,'" + cepOverlap + "' ,'" + cepZoom + "' ,'" + cepZoomSTF + "' ,'" + demoBand + "' ,'" + demoResol + "' ,'" + demoWindow + "' ,'" + demoAvgTime + "' ,'" + demofilter + "' ,'" + otveragetimes + "' ,'" + otresolution + "' ,'" + otorder + "' ,'" + ottriggerslope + "' ,'" + pwrmultiple + "' ,'" + type + "')");
                insert_unitsforunschedule(type);
            }
            catch { }
        }

        public void insert_unitsforunschedule(int type)
        {
            try
            {                
                string btAccel_Unit = "0";
                string btVel_Unit = "0";
                string btDispl_Unit = "1";
                string btTemperature_Unit = "0";
                string btPressureUnit = "0";
                string sProcess_Unit = "0";
                string btCurrentUnit = "0";
               
                string btAccel_Detection = "1";
                string btVel_Detection = "0";
                string btDispl_Detection = "2";
                string btCurrent_detection = "1";
                string btPressure_detection = "1";
                string btTime_Unit_Type = "0";
                string btPower_unit_type = "0";
                string btDemodulate_Unit_Type = "0";
                string btordertrace_unit_type = "0";
                string btcepstrum_unit_type = "0";
                DbClass.executequery(CommandType.Text, " insert into units(accel_unit,accel_detection,vel_unit,vel_detection,displ_unit,displ_detection,temperature_unit,process_unit,pressure_unit,pressure_detection,current_unit,current_detection,time_unit_type,power_unit_type,demodulate_unit_type,ordertrace_unit_type,cepstrum_unit_type,Date,Type_ID) values('" + btAccel_Unit + "','" + btAccel_Detection + "','" + btVel_Unit + "','" + btVel_Detection + "','" + btDispl_Unit + "','" + btDispl_Detection + "','" + btTemperature_Unit + "','" + sProcess_Unit + "','" + btPressureUnit + "','" + btPressure_detection + "','" + btCurrentUnit + "','" + btCurrent_detection + "','" + btTime_Unit_Type + "','" + btPower_unit_type + "','" + btDemodulate_Unit_Type + "','" + btordertrace_unit_type + "','" + btcepstrum_unit_type + "','" + PublicClass.GetDatetime() + "','" + type + "')");


            }
            catch { }
        }

        public void insert_pointdatawav(int type,double[] ch1_x,double[] ch1_y,double[] ch2_x,double[] ch2_y)
        {
            try
            {
                DataTable dt = new DataTable();
                string v_Point_Type = Convert.ToString(type);
                // string v_pr_id = Convert.ToString(type);
                string v_measure_time = PublicClass.GetDatetime();
                string v_accel_ch1 = "0";
                string v_accel_a = "0";
                string v_accel_h = "0";
                string v_accel_v = "0";
                string v_vel_ch1 = "0";
                string v_vel_a = "0";
                string v_vel_h = "0";
                string v_vel_v = "0";
                string v_displ_ch1 = "0";
                string v_displ_a = "0";
                string v_displ_h = "0";
                string v_displ_v = "0";
                string v_crest_factor_ch1 = "0";
                string v_crest_factor_a = "0";
                string v_crest_factor_h = "0";
                string v_crest_factor_v = "0";
                string v_bearing_ch1 = "0";
                string v_bearing_a = "0";
                string v_bearing_h = "0";
                string v_bearing_v = "0";
                string v_ordertrace_ch1_real = "0";
                string v_ordertrace_ch1_image = "0";
                string v_ordertrace_a_real = "0";
                string v_ordertrace_a_image = "0";
                string v_ordertrace_h_real = "0";
                string v_ordertrace_h_image = "0";
                string v_ordertrace_v_real = "0";
                string v_ordertrace_v_image = "0";
                string v_ordertrace_rpm = "0";
                string v_point_id = "0";
                // string v_measure_id = "0";
                string v_temperature = "0";
                string v_process = "0";
                string v_auto_measure = "0";
                string v_record_status = "0";
                //  string v_point_schedule = "0";
                string v_point_name = "";
                //string v_machine_id = "";
                string v_Notes1 = "";
                string v_Notes2 = "";
                string v_Manual = "";
                //-----variable-----//
                               
                string Time = "Time_Band,Time_resolution";
                string v_time_ch1_X = "0|"; string v_time_CH1_Y = null;
                string v_time_a_X = "0|"; string v_time_a_Y = null;
                string v_time_h_X = ""; string v_time_h_Y = "";
                string v_time_v_X = ""; string v_time_v_Y = "";

                string Power = "power_band,power_resolution";
                string v_power_ch_X = "0|"; string v_power_ch_Y = null;
                string v_power_a_X = "0|"; string v_power_a_Y = null;
                string v_power_h_X = "0|"; string v_power_h_Y = null;
                string v_power_v_X = "0|"; string v_power_v_Y = null;

                string Power1 = "power_band1,power_resolution1";
                string v_power_ch1_X = "0|"; string v_power_ch1_Y = null;
                string v_power_a1_X = "0|"; string v_power_a1_Y = null;
                string v_power_h1_X = "0|"; string v_power_h1_Y = null;
                string v_power_v1_X = "0|"; string v_power_v1_Y = null;

                string Power2 = "power2_band,power2_resolution";
                string v_power2_ch1_X = "0|"; string v_power2_ch1_Y = null;
                string v_power2_a_X = "0|"; string v_power2_a_Y = null;
                string v_power2_h_X = "0|"; string v_power2_h_Y = null;
                string v_power2_v_X = "0|"; string v_power2_v_Y = null;

                string Power2_1 = "power2_band1,power2_resolution1";
                string v_power2_ch11_X = "0|"; string v_power2_ch11_Y = null;
                string v_power2_a1_X = "0|"; string v_power2_a1_Y = null;
                string v_power2_h1_X = "0|"; string v_power2_h1_Y = null;
                string v_power2_v1_X = "0|"; string v_power2_v1_Y = null;


                string Power3 = "power3_band,power3_resolution";
                string v_power3_ch1_X = "0|"; string v_power3_ch1_Y = null;
                string v_power3_a_X = "0|"; string v_power3_a_Y = null;
                string v_power3_h_X = "0|"; string v_power3_h_Y = null;
                string v_power3_v_X = "0|"; string v_power3_v_Y = null;

                string Power3_1 = "power3_band1,power3_resolution1";
                string v_power3_ch11_X = "0|"; string v_power3_ch11_Y = null;
                string v_power3_a1_X = "0|"; string v_power3_a1_Y = null;
                string v_power3_h1_X = "0|"; string v_power3_h1_Y = null;
                string v_power3_v1_X = "0|"; string v_power3_v1_Y = null;


                string cepstrum = "cepstrum_band,cepstrum_resolution";
                string v_cepstrum_ch1_X = "0|"; string v_cepstrum_ch1_Y = null;
                string v_cepstrum_a_X = "0|"; string v_cepstrum_a_Y = null;
                string v_cepstrum_h_X = "0|"; string v_cepstrum_h_Y = null;
                string v_cepstrum_v_X = "0|"; string v_cepstrum_v_Y = null;


                string demodulate = "demodulate_band,demodulate_resolution";
                string v_demodulate_ch1_X = "0|"; string v_demodulate_ch1_Y = null;
                string v_demodulate_a_X = "0|"; string v_demodulate_a_Y = null;
                string v_demodulate_h_X = "0|"; string v_demodulate_h_Y = null;
                string v_demodulate_v_X = "0|"; string v_demodulate_v_Y = null;


                try
                {
                    DbClass.executequery(CommandType.Text, " insert into point_data (Point_ID,Point_name, Point_Type,  Measure_time,  accel_a,  accel_h, accel_v,accel_ch1, vel_a,        vel_h, vel_v, vel_ch1,      displ_a,   displ_h,    displ_v, displ_ch1,crest_factor_a,    crest_factor_h,    crest_factor_v,   crest_factor_ch1 ,          bearing_a,       bearing_h,  bearing_v,  bearing_ch1,        ordertrace_a_real,   ordertrace_h_real,  ordertrace_v_real ,ordertrace_ch1_real ,     ordertrace_a_image,   ordertrace_h_image,    ordertrace_v_image, ordertrace_ch1_image,   ordertrace_rpm,    TimeA_X,     timeH_X,     timeV_X,timeCH1_X,       PA_X, PH_X,    PV_X,  PCH1_X,    P1A_X, P1H_X,  P1V_X,   P1CH1_X,   P2A_X,   P2H_X,   P2V_X,  P2CH1_X,     P21A_X,  P21H_X,  P21V_X,  P21CH1_X,  P3A_X,  P3H_X, P3V_X,  P3CH1_X,   P31A_X,   P31H_X,  P31V_X,  P31CH1_X,   CEPA_X,    CEPH_X,  CEPV_X, CEPCH1_X,    DEMA_X,   DEMH_X, DEMV_X, DEMCH1_X,      timeA_Y,        timeH_Y,     timeV_Y,    timeCH1_Y,     PA_Y,     PH_Y,    PV_Y,    PCH1_Y,P1A_Y,P1H_Y,P1V_Y,P1CH1_Y,P2A_Y,P2H_Y,P2V_Y,P2CH1_Y,P21A_Y,P21H_Y,P21V_Y,P21CH1_Y,P3A_Y,P3H_Y,P3V_Y,P3CH1_Y,P31A_Y,P31H_Y,P31V_Y,P31CH1_Y,CEPA_Y,CEPH_Y,CEPV_Y,CEPCH1_Y,DEMA_Y,DEMH_Y,DEMV_Y,DEMCH1_Y ,            temperature,    Process,   auto_measure,   record_status,    Notes1, Notes2,  IDateTime,   Manual) values       ( '" + v_point_id + "' ,'" + v_point_name + "', '" + v_Point_Type + "', '" + v_measure_time + "' , '" + v_accel_a + "' ,'" + v_accel_h + "','" + v_accel_v + "' ,'" + v_accel_ch1 + "' , '" + v_vel_a + "'   ,'" + v_vel_h + "' ,'" + v_vel_v + "'  ,'" + v_vel_ch1 + "' ,'" + v_displ_a + "' ,  '" + v_displ_h + "' , '" + v_displ_v + "' ,'" + v_displ_ch1 + "'  ,'" + v_crest_factor_a + "', '" + v_crest_factor_h + "'  ,'" + v_crest_factor_v + "' , '" + v_crest_factor_ch1 + "',  '" + v_bearing_a + "' ,'" + v_bearing_h + "', '" + v_bearing_v + "',  '" + v_bearing_ch1 + "'  ,'" + v_ordertrace_a_real + "'  ,'" + v_ordertrace_h_real + "' ,'" + v_ordertrace_v_real + "',  '" + v_ordertrace_ch1_real + "'  ,   '" + v_ordertrace_a_image + "','" + v_ordertrace_h_image + "','" + v_ordertrace_v_image + "','" + v_ordertrace_ch1_image + "', '" + v_ordertrace_rpm + "'  ,  '" + v_time_a_X + "', '" + GetTimeData(ch2_x) + "', '" + GetTimeData(ch1_x) + "' ,'" + v_time_ch1_X + "' ,'" + v_power_a_X + "','" + v_power_h_X + "' ,'" + v_power_v_X + "','" + v_power_ch_X + "' ,'" + v_power_a1_X + "','" + v_power_h1_X + "' ,'" + v_power_v1_X + "' , '" + v_power_ch1_X + "'  ,'" + v_power2_a_X + "','" + v_power2_h_X + "','" + v_power2_v_X + "' ,'" + v_power2_ch1_X + "'  ,'" + v_power2_a1_X + "','" + v_power2_h1_X + "','" + v_power2_v1_X + "','" + v_power2_ch11_X + "','" + v_power3_a_X + "','" + v_power3_h_X + "', '" + v_power3_v_X + "', '" + v_power3_ch1_X + "' ,'" + v_power3_a1_X + "','" + v_power3_h1_X + "','" + v_power3_v1_X + "','" + v_power3_ch11_X + "' ,'" + v_cepstrum_a_X + "','" + v_cepstrum_h_X + "','" + v_cepstrum_v_X + "','" + v_cepstrum_ch1_X + "', '" + v_demodulate_a_X + "','" + v_demodulate_h_X + "','" + v_demodulate_v_X + "', '" + v_demodulate_ch1_X + "'  ,  '" + v_time_a_Y + "', '" + GetTimeData(ch2_y) + "', '" + GetTimeData(ch1_y) + "' ,'" + v_time_CH1_Y + "' ,'" + v_power_a_Y + "','" + v_power_h_Y + "' ,'" + v_power_v_Y + "','" + v_power_ch_Y + "' ,'" + v_power_a1_Y + "','" + v_power_h1_Y + "' ,'" + v_power_v1_Y + "' , '" + v_power_ch1_Y + "'  ,'" + v_power2_a_Y + "','" + v_power2_h_Y + "','" + v_power2_v_Y + "' ,'" + v_power2_ch1_Y + "'  ,'" + v_power2_a1_Y + "','" + v_power2_h1_Y + "','" + v_power2_v1_Y + "','" + v_power2_ch11_Y + "','" + v_power3_a_Y + "','" + v_power3_h_Y + "', '" + v_power3_v_Y + "', '" + v_power3_ch1_Y + "' ,'" + v_power3_a1_Y + "','" + v_power3_h1_Y + "','" + v_power3_v1_Y + "','" + v_power3_ch11_Y + "' ,'" + v_cepstrum_a_Y + "','" + v_cepstrum_h_Y + "','" + v_cepstrum_v_Y + "','" + v_cepstrum_ch1_Y + "', '" + v_demodulate_a_Y + "','" + v_demodulate_h_Y + "','" + v_demodulate_v_Y + "', '" + v_demodulate_ch1_Y + "'     ,  '" + v_temperature + "', '" + v_process + "','" + v_auto_measure + "','" + v_record_status + "' ,'" + v_Notes1 + "' ,'" + v_Notes2 + "',  '" + PublicClass.GetDatetime() + "' ,'" + v_Manual + "')  ");
                }
                catch { }


            }
            catch { }
        }


        public void insert_pointdatauff(int type, double[] specch1_x, double[] specch1_y, double[] specch2_x, double[] specch2_y, double[] specch3_x, double[] specch3_y, double[] specch4_x, double[] specch4_y, double[] timech1_x, double[] timech1_y, double[] timech2_x, double[] timech2_y, double[] timech3_x, double[] timech3_y, double[] timech4_x, double[] timech4_y)
        {
            try
            {
                DataTable dt = new DataTable();
                string v_Point_Type = Convert.ToString(type); 
               // string v_pr_id = Convert.ToString(type);
                string v_measure_time = PublicClass.GetDatetime();
                string v_accel_ch1 = "0";
                string v_accel_a = "0";
                string v_accel_h = "0";
                string v_accel_v = "0";
                string v_vel_ch1 = "0";
                string v_vel_a = "0";
                string v_vel_h = "0";
                string v_vel_v = "0";
                string v_displ_ch1 = "0";
                string v_displ_a = "0";
                string v_displ_h = "0";
                string v_displ_v = "0";
                string v_crest_factor_ch1 = "0";
                string v_crest_factor_a = "0";
                string v_crest_factor_h = "0";
                string v_crest_factor_v = "0";
                string v_bearing_ch1 = "0";
                string v_bearing_a = "0";
                string v_bearing_h = "0";
                string v_bearing_v = "0";
                string v_ordertrace_ch1_real = "0";
                string v_ordertrace_ch1_image = "0";
                string v_ordertrace_a_real = "0";
                string v_ordertrace_a_image = "0";
                string v_ordertrace_h_real = "0";
                string v_ordertrace_h_image = "0";
                string v_ordertrace_v_real = "0";
                string v_ordertrace_v_image = "0";
                string v_ordertrace_rpm = "0";
                string v_point_id = "0";
               // string v_measure_id = "0";
                string v_temperature = "0";
                string v_process = "0";
                string v_auto_measure = "0";
                string v_record_status = "0";
              //  string v_point_schedule = "0";
                string v_point_name = "";
                //string v_machine_id = "";
                string v_Notes1 = "";
                string v_Notes2 = "";
                string v_Manual = "";
                //-----variable-----//

                string Time = "Time_Band,Time_resolution";
                string v_time_ch1_X = null; string v_time_CH1_Y = null;
                string v_time_a_X = null; string v_time_a_Y = null;
                string v_time_h_X = null; string v_time_h_Y = null;
                string v_time_v_X = null; string v_time_v_Y = null;

                string Power = "power_band,power_resolution";
                string v_power_ch_X = null; string v_power_ch_Y = null;
                string v_power_a_X = null; string v_power_a_Y = null;
                string v_power_h_X = null; string v_power_h_Y = null;
                string v_power_v_X = null; string v_power_v_Y = null;

                string Power1 = "power_band1,power_resolution1";
                string v_power_ch1_X = "0|"; string v_power_ch1_Y = null;
                string v_power_a1_X = "0|"; string v_power_a1_Y = null;
                string v_power_h1_X = "0|"; string v_power_h1_Y = null;
                string v_power_v1_X = "0|"; string v_power_v1_Y = null;

                string Power2 = "power2_band,power2_resolution";
                string v_power2_ch1_X = "0|"; string v_power2_ch1_Y = null;
                string v_power2_a_X = "0|"; string v_power2_a_Y = null;
                string v_power2_h_X = "0|"; string v_power2_h_Y = null;
                string v_power2_v_X = "0|"; string v_power2_v_Y = null;

                string Power2_1 = "power2_band1,power2_resolution1";
                string v_power2_ch11_X = "0|"; string v_power2_ch11_Y = null;
                string v_power2_a1_X = "0|"; string v_power2_a1_Y = null;
                string v_power2_h1_X = "0|"; string v_power2_h1_Y = null;
                string v_power2_v1_X = "0|"; string v_power2_v1_Y = null;


                string Power3 = "power3_band,power3_resolution";
                string v_power3_ch1_X = "0|"; string v_power3_ch1_Y = null;
                string v_power3_a_X = "0|"; string v_power3_a_Y = null;
                string v_power3_h_X = "0|"; string v_power3_h_Y = null;
                string v_power3_v_X = "0|"; string v_power3_v_Y = null;

                string Power3_1 = "power3_band1,power3_resolution1";
                string v_power3_ch11_X = "0|"; string v_power3_ch11_Y = null;
                string v_power3_a1_X = "0|"; string v_power3_a1_Y = null;
                string v_power3_h1_X = "0|"; string v_power3_h1_Y = null;
                string v_power3_v1_X = "0|"; string v_power3_v1_Y = null;


                string cepstrum = "cepstrum_band,cepstrum_resolution";
                string v_cepstrum_ch1_X = "0|"; string v_cepstrum_ch1_Y = null;
                string v_cepstrum_a_X = "0|"; string v_cepstrum_a_Y = null;
                string v_cepstrum_h_X = "0|"; string v_cepstrum_h_Y = null;
                string v_cepstrum_v_X = "0|"; string v_cepstrum_v_Y = null;


                string demodulate = "demodulate_band,demodulate_resolution";
                string v_demodulate_ch1_X = "0|"; string v_demodulate_ch1_Y = null;
                string v_demodulate_a_X = "0|"; string v_demodulate_a_Y = null;
                string v_demodulate_h_X = "0|"; string v_demodulate_h_Y = null;
                string v_demodulate_v_X = "0|"; string v_demodulate_v_Y = null;

                try
                {
                    DbClass.executequery(CommandType.Text, " insert into point_data (Point_ID,Point_name, Point_Type,  Measure_time,  accel_a,  accel_h, accel_v,accel_ch1, vel_a,        vel_h, vel_v, vel_ch1,      displ_a,   displ_h,    displ_v, displ_ch1,crest_factor_a,    crest_factor_h,    crest_factor_v,   crest_factor_ch1 ,          bearing_a,       bearing_h,  bearing_v,  bearing_ch1,        ordertrace_a_real,   ordertrace_h_real,  ordertrace_v_real ,ordertrace_ch1_real ,     ordertrace_a_image,   ordertrace_h_image,    ordertrace_v_image, ordertrace_ch1_image,   ordertrace_rpm,    TimeA_X,     timeH_X,     timeV_X,timeCH1_X,       PA_X, PH_X,    PV_X,  PCH1_X,    P1A_X, P1H_X,  P1V_X,   P1CH1_X,   P2A_X,   P2H_X,   P2V_X,  P2CH1_X,     P21A_X,  P21H_X,  P21V_X,  P21CH1_X,  P3A_X,  P3H_X, P3V_X,  P3CH1_X,   P31A_X,   P31H_X,  P31V_X,  P31CH1_X,   CEPA_X,    CEPH_X,  CEPV_X, CEPCH1_X,    DEMA_X,   DEMH_X, DEMV_X, DEMCH1_X,      timeA_Y,        timeH_Y,     timeV_Y,    timeCH1_Y,     PA_Y,     PH_Y,    PV_Y,    PCH1_Y,P1A_Y,P1H_Y,P1V_Y,P1CH1_Y,P2A_Y,P2H_Y,P2V_Y,P2CH1_Y,P21A_Y,P21H_Y,P21V_Y,P21CH1_Y,P3A_Y,P3H_Y,P3V_Y,P3CH1_Y,P31A_Y,P31H_Y,P31V_Y,P31CH1_Y,CEPA_Y,CEPH_Y,CEPV_Y,CEPCH1_Y,DEMA_Y,DEMH_Y,DEMV_Y,DEMCH1_Y ,            temperature,    Process,   auto_measure,   record_status,    Notes1, Notes2,  IDateTime,   Manual) values       ( '" + v_point_id + "' ,'" + v_point_name + "', '" + v_Point_Type + "', '" + v_measure_time + "' , '" + v_accel_a + "' ,'" + v_accel_h + "','" + v_accel_v + "' ,'" + v_accel_ch1 + "' , '" + v_vel_a + "'   ,'" + v_vel_h + "' ,'" + v_vel_v + "'  ,'" + v_vel_ch1 + "' ,'" + v_displ_a + "' ,  '" + v_displ_h + "' , '" + v_displ_v + "' ,'" + v_displ_ch1 + "'  ,'" + v_crest_factor_a + "', '" + v_crest_factor_h + "'  ,'" + v_crest_factor_v + "' , '" + v_crest_factor_ch1 + "',  '" + v_bearing_a + "' ,'" + v_bearing_h + "', '" + v_bearing_v + "',  '" + v_bearing_ch1 + "'  ,'" + v_ordertrace_a_real + "'  ,'" + v_ordertrace_h_real + "' ,'" + v_ordertrace_v_real + "',  '" + v_ordertrace_ch1_real + "'  ,   '" + v_ordertrace_a_image + "','" + v_ordertrace_h_image + "','" + v_ordertrace_v_image + "','" + v_ordertrace_ch1_image + "', '" + v_ordertrace_rpm + "'  ,  '" + GetTimespecData(timech3_x) + "', '" + GetTimespecData(timech2_x) + "', '" + GetTimespecData(timech1_x) + "' ,'" + GetTimespecData(timech4_x) + "' ,'" + GetTimespecData(specch3_x) + "','" + GetTimespecData(specch2_x) + "' ,'" + GetTimespecData(specch1_x) + "','" + GetTimespecData(specch4_x) + "' ,'" + v_power_a1_X + "','" + v_power_h1_X + "' ,'" + v_power_v1_X + "' , '" + v_power_ch1_X + "'  ,'" + v_power2_a_X + "','" + v_power2_h_X + "','" + v_power2_v_X + "' ,'" + v_power2_ch1_X + "'  ,'" + v_power2_a1_X + "','" + v_power2_h1_X + "','" + v_power2_v1_X + "','" + v_power2_ch11_X + "','" + v_power3_a_X + "','" + v_power3_h_X + "', '" + v_power3_v_X + "', '" + v_power3_ch1_X + "' ,'" + v_power3_a1_X + "','" + v_power3_h1_X + "','" + v_power3_v1_X + "','" + v_power3_ch11_X + "' ,'" + v_cepstrum_a_X + "','" + v_cepstrum_h_X + "','" + v_cepstrum_v_X + "','" + v_cepstrum_ch1_X + "', '" + v_demodulate_a_X + "','" + v_demodulate_h_X + "','" + v_demodulate_v_X + "', '" + v_demodulate_ch1_X + "'  ,  '" + GetTimespecData(timech3_y) + "', '" + GetTimespecData(timech2_y) + "', '" + GetTimespecData(timech1_y) + "' ,'" + GetTimespecData(timech4_y) + "' ,'" + GetTimespecData(specch3_y) + "','" + GetTimespecData(specch2_y) + "' ,'" + GetTimespecData(specch1_y) + "','" + GetTimespecData(specch4_y) + "' ,'" + v_power_a1_Y + "','" + v_power_h1_Y + "' ,'" + v_power_v1_Y + "' , '" + v_power_ch1_Y + "'  ,'" + v_power2_a_Y + "','" + v_power2_h_Y + "','" + v_power2_v_Y + "' ,'" + v_power2_ch1_Y + "'  ,'" + v_power2_a1_Y + "','" + v_power2_h1_Y + "','" + v_power2_v1_Y + "','" + v_power2_ch11_Y + "','" + v_power3_a_Y + "','" + v_power3_h_Y + "', '" + v_power3_v_Y + "', '" + v_power3_ch1_Y + "' ,'" + v_power3_a1_Y + "','" + v_power3_h1_Y + "','" + v_power3_v1_Y + "','" + v_power3_ch11_Y + "' ,'" + v_cepstrum_a_Y + "','" + v_cepstrum_h_Y + "','" + v_cepstrum_v_Y + "','" + v_cepstrum_ch1_Y + "', '" + v_demodulate_a_Y + "','" + v_demodulate_h_Y + "','" + v_demodulate_v_Y + "', '" + v_demodulate_ch1_Y + "'     ,  '" + v_temperature + "', '" + v_process + "','" + v_auto_measure + "','" + v_record_status + "' ,'" + v_Notes1 + "' ,'" + v_Notes2 + "',  '" + PublicClass.GetDatetime() + "' ,'" + v_Manual + "')  ");
                }
                catch { }
            }
            catch { }
        }

        double[] m_arrKeys = null;
        private string GetTimeData(double[] btArgs)
        {            
            StringBuilder sbXValues = null;
            try
            {
                if (btArgs == null)
                {
                   // btArgs = "" 
                }
                sbXValues = new StringBuilder();
                int iLength = (btArgs.Length);
               // double[] dTimeImage = new double[iLength];
               // m_arrKeys = new double[dTimeImage.Length];               
                sbXValues.Append(0);
                sbXValues.Append("|");
                for (int iLoop = 0; iLoop < btArgs.Length - 1; iLoop++)
                {
                    sbXValues.Append(btArgs[iLoop]);
                    sbXValues.Append("|");
                }
                return sbXValues.ToString();
            }
            catch (Exception ex)
            {
                return sbXValues.ToString();
            }
        }

        private string GetTimespecData(double[] btArgs)
        {
            StringBuilder sbXValues = null;
            try
            {
                sbXValues = new StringBuilder();
                if (btArgs == null)
                {
                    btArgs = new double[1];
                }
                int iLength = (btArgs.Length);
                // double[] dTimeImage = new double[iLength];
                // m_arrKeys = new double[dTimeImage.Length];               
                sbXValues.Append(0);
                sbXValues.Append("|");
                for (int iLoop = 0; iLoop < btArgs.Length - 1; iLoop++)
                {
                    sbXValues.Append(btArgs[iLoop]);
                    sbXValues.Append("|");
                }
                return sbXValues.ToString();
            }
            catch (Exception ex)
            {
                return sbXValues.ToString();
            }
        }
    }
}
