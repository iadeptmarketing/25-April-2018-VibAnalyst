using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using com.iAM.chart2dnet;
using System.Collections;
using DevComponents.DotNetBar;
using System.Drawing.Drawing2D;

namespace Iadeptmain.BaseUserControl
{

    public partial class _PolarPlot : ChartView
    {
        public _PolarPlot()
        {
            InitializeComponent();
        }
      
        public void DrawPolarPlot(double mag1, double ang1)
        {
            try
            {
                double[] mag = new double[1];
                double[] ang = new double[1];
                mag[0] = mag1;
                ang[0] = ang1;
                DrawPolarPlot(mag, ang);
            }
            catch
            {
            }
        }
        ChartView chartVu;
        Font theFont;
        PolarCoordinates pPolarTransform;
        Color GraphBG1 = Color.White;
        Color GraphBG2 = Color.White;
        Color ChartBG1 = Color.White;
        Color ChartBG2 = Color.White;
        Color AxisColor = Color.Black;
        Color MainCursor = Color.Black;
        int GraphBGDir = 0;
        int ChartBGDir = 0;

        public Color _AxisColor
        {
            get
            {
                return AxisColor;
            }
            set
            {
                AxisColor = value;
            }
        }
        public Color _MainCursorColor
        {
            get
            {
                return MainCursor;
            }
            set
            {
                MainCursor = value;
            }
        }
        public Color _GraphBG1
        {
            get
            {
                return GraphBG1;
            }
            set
            {
                GraphBG1 = value;
            }
        }
        public Color _GraphBG2
        {
            get
            {
                return GraphBG2;
            }
            set
            {
                GraphBG2 = value;
            }
        }
        public int _GraphBGDir
        {
            get
            {
                return GraphBGDir;
            }
            set
            {
                GraphBGDir = value;
            }
        }
        public Color _ChartBG1
        {
            get
            {
                return ChartBG1;
            }
            set
            {
                ChartBG1 = value;
            }
        }
        public Color _ChartBG2
        {
            get
            {
                return ChartBG2;
            }
            set
            {
                ChartBG2 = value;
            }
        }
        public int _ChartBGDir
        {
            get
            {
                return ChartBGDir;
            }
            set
            {
                ChartBGDir = value;
            }
        }

        public void DrawPolarPlot(double[] mag1, double[] ang1)
        {
            try
            {
                RemovePreviousObjects();
                chartVu = this;

                Font theLabelFont = new Font("Courier", 10, FontStyle.Regular);
                string[] sarrxlab = new string[mag1.Length];
                int nump1 = mag1.Length;

                for (int i = 0; i < nump1; i++)
                {
                    sarrxlab[i] = "Mag " + mag1[i].ToString() + ", Angle " + ang1[i].ToString();
                    ang1[i] = ChartSupport.ToRadians((double)ang1[i]);
                }
                theFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                chartVu = this;

                SimpleDataset Dataset1 = new SimpleDataset("First", mag1, ang1);
                pPolarTransform = new PolarCoordinates();
                pPolarTransform.SetGraphBorderDiagonal(0.25, .2, .75, 0.8);

                 background = new Background(pPolarTransform, ChartObj.GRAPH_BACKGROUND, GraphBG1, GraphBG2, GraphBGDir);
                chartVu.AddChartObject(background);

                plotbackground = new Background(pPolarTransform, ChartObj.PLOT_BACKGROUND, ChartBG1, ChartBG2, ChartBGDir);
                chartVu.AddChartObject(plotbackground);

                pPolarTransform.AutoScale(Dataset1);

                pPolarAxis = pPolarTransform.GetCompatibleAxes();
                pPolarAxis.SetColor(_AxisColor);
                chartVu.AddChartObject(pPolarAxis);

                pPolarGrid = new PolarGrid(pPolarAxis, PolarGrid.GRID_MAJOR);
                pPolarGrid.SetColor(_AxisColor);
                chartVu.AddChartObject(pPolarGrid);

                pPolarAxisLabels = (PolarAxesLabels)pPolarAxis.GetCompatibleAxesLabels();
                pPolarAxisLabels.SetColor(_AxisColor);
                chartVu.AddChartObject(pPolarAxisLabels);

                ChartAttribute attrib1 = new ChartAttribute(Color.Blue, 2, 0);

                ChartAttribute attrib2 = new ChartAttribute(Color.Red, .5, 0, Color.Red);
                attrib2.SetFillFlag(true);

                thePlot2 = new PolarScatterPlot(pPolarTransform, Dataset1, ChartObj.CIRCLE, attrib2);
                chartVu.AddChartObject(thePlot2);

                PolarLinePlot thePlot1 = new PolarLinePlot(pPolarTransform, Dataset1, attrib1);
                chartVu.AddChartObject(thePlot1);

                 findObj = new CustomFindObj1(chartVu, sarrxlab);
                findObj.SetDataToolTipFormat(ChartObj.DATA_TOOLTIP_CUSTOM);
                findObj.SetEnable(true);
                chartVu.SetCurrentMouseListener(findObj);

                if (_ChartFooter != null)
                {
                    ChartTitle footer = new ChartTitle(pPolarTransform, theFont, _ChartFooter);
                    footer.SetColor(Color.Black);
                    footer.SetTitleType(ChartObj.CHART_FOOTER);
                    footer.SetTitlePosition(ChartObj.CENTER_GRAPH);
                    footer.SetTitleOffset(8);
                    chartVu.AddChartObject(footer);
                }
                this.SetResizeMode(ChartObj.NO_RESIZE_OBJECTS);
            }
            catch (Exception ex)
            {
            }
        }
        string ChartFooter = null;
        public string _ChartFooter
        {
            get
            {
                return ChartFooter;
            }
            set
            {
                ChartFooter = value;
            }
        }        
        CustomFindObj1 findObj;
        PolarScatterPlot thePlot2;
        private void RemovePreviousObjects()
        {
            try
            {
                if (chartVu != null)
                {
                    ArrayList arrObjects = chartVu.GetChartObjectsArrayList();
                    int iCount = arrObjects.Count;
                    if (arrObjects != null)
                    {
                        for (int iCtr = 0; iCtr < iCount; iCtr++)
                        {
                            GraphObj objObject = (GraphObj)arrObjects[0];
                            Type obj = objObject.GetType();
                            chartVu.DeleteChartObject(objObject);
                        }
                    }
                    chartVu.UpdateDraw();
                }
            }
            catch (Exception ex)
            {
            }
        }
        internal void CopyGraph()
        {
            try
            {
                if (chartVu != null)
                {
                    BufferedImage objImage = new BufferedImage(chartVu);
                    Image GraphImage = (Image)objImage.GetBufferedImage();
                    Clipboard.SetImage((Image)GraphImage);
                    MessageBoxEx.Show("Polar Graph Copied on ClipBoard", "Graph");
                }
            }
            catch (Exception ex)
            {
            }
        }
        internal void StartZoom()
        {
            try
            {
                if (zoomObj == null)
                {
                    zoomObj = new ChartZoom(chartVu, pPolarTransform, true);
                    zoomObj.SetButtonMask(MouseButtons.Left);
                    zoomObj.SetZoomYEnable(true);
                    zoomObj.SetZoomXEnable(true);
                    zoomObj.SetZoomXRoundMode(ChartObj.AUTOAXES_EXACT);
                    zoomObj.SetZoomYRoundMode(ChartObj.AUTOAXES_EXACT);
                    zoomObj.InternalZoomStackProcesssing = true;
                    zoomObj.SetEnable(true);
                    thePlot2.SetShowDatapointValue(true);
                    NumericLabel modellabel = new NumericLabel();
                    modellabel.SetXJust(ChartObj.JUSTIFY_MIN);
                    modellabel.SetYJust(ChartObj.JUSTIFY_CENTER);
                    Font modellabelfont = new Font("Arial", 8, FontStyle.Regular);
                    modellabel.SetTextFont(modellabelfont);
                    modellabel.DecimalPos = 2;
                    modellabel.SetTextNudge(0, 5);
                    thePlot2.SetPlotLabelTemplate(modellabel);
                }
                chartVu.SetCurrentMouseListener(zoomObj);
                chartVu.UpdateDraw();
            }
            catch (Exception ex)
            {
            }
        }
        ChartZoom zoomObj = null;
        DataToolTip datatooltip;
        internal void StopZoom()
        {
            try
            {
                //int k= zoomObj.PushZoomStack();
                ChartZoom zoomObj1 = new ChartZoom(chartVu, pPolarTransform, true);
                zoomObj1.SetButtonMask(MouseButtons.None);
                zoomObj1.SetZoomYEnable(false);
                zoomObj1.SetZoomXEnable(false);
                zoomObj1.SetZoomXRoundMode(ChartObj.AUTOAXES_EXACT);
                zoomObj1.SetZoomYRoundMode(ChartObj.AUTOAXES_EXACT);
                zoomObj1.InternalZoomStackProcesssing = true;               
                chartVu.SetCurrentMouseListener(zoomObj1);
                chartVu.UpdateDraw();
            }
            catch (Exception ex)
            {
            }
        }
        public void Unzoom()
        {
            int iTest = 0;

            try
            {
                do
                {
                    if (zoomObj != null)
                    {
                        iTest = zoomObj.PopZoomStack();

                    }
                }
                while (iTest != 0);
                zoomObj = null;
                thePlot2.SetShowDatapointValue(false);
                chartVu.SetCurrentMouseListener(findObj);
                chartVu.UpdateDraw();
            }
            catch (Exception ex)
            {
            }
        }
        Background background;
        Background plotbackground;
        PolarAxes pPolarAxis;
        PolarGrid pPolarGrid;
        PolarAxesLabels pPolarAxisLabels;
        public void BackGroundChanges()
        {
            try
            {
                if (chartVu != null)
                {
                    ArrayList arrObjects = chartVu.GetChartObjectsArrayList();
                    int iCount = arrObjects.Count;
                    int iDel = 0;
                    if (arrObjects != null)
                    {
                        for (int iCtr = 0; iCtr < iCount; iCtr++)
                        {
                            GraphObj objObject = (GraphObj)arrObjects[iDel];

                            Type obj = objObject.GetType();
                            if (obj.Name == "PolarLinePlot" || obj.Name == "PolarScatterPlot")
                            {
                                iDel++;
                            }
                            else
                            {
                                chartVu.DeleteChartObject(objObject);
                            }
                        }
                    }

                    plotbackground = new Background(pPolarTransform, ChartObj.PLOT_BACKGROUND, ChartBG1, ChartBG2, ChartBGDir);
                    chartVu.AddChartObject(plotbackground);

                    background = new Background(pPolarTransform, ChartObj.GRAPH_BACKGROUND, GraphBG1, GraphBG2, GraphBGDir);
                    chartVu.AddChartObject(background);


                    pPolarAxis = pPolarTransform.GetCompatibleAxes();
                    pPolarAxis.SetColor(_AxisColor);                   
                    chartVu.AddChartObject(pPolarAxis);

                    pPolarGrid = new PolarGrid(pPolarAxis, PolarGrid.GRID_MAJOR);
                    pPolarGrid.SetColor(_AxisColor);
                    pPolarGrid.LineColor = _AxisColor;
                    chartVu.AddChartObject(pPolarGrid);


                    pPolarAxisLabels = (PolarAxesLabels)pPolarAxis.GetCompatibleAxesLabels();
                    pPolarAxisLabels.SetColor(_AxisColor);
                    chartVu.AddChartObject(pPolarAxisLabels);
   
                    if (_ChartFooter != null)
                    {
                        ChartTitle footer = new ChartTitle(pPolarTransform, theFont, _ChartFooter);
                        footer.SetColor(_AxisColor);
                        footer.SetTitleType(ChartObj.CHART_FOOTER);
                        footer.SetTitlePosition(ChartObj.CENTER_GRAPH);
                        footer.SetTitleOffset(8);
                        chartVu.AddChartObject(footer);
                    }
                    chartVu.Update();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
    class CustomFindObj1 : CustomDataToolTip
    {
        String[] labelarray;
        public CustomFindObj1(ChartView component, String[] labels)
            : base(component)
        {
            labelarray = labels;
        }
        override public void Draw(Graphics g2)
        {
            DefineCustomToolTipString(); 
            base.Draw(g2); 
        }
        public void DefineCustomToolTipString()
        {
            String tooltipstring = "";

            ChartPlot selectedPlot = (ChartPlot)GetSelectedPlotObj();
            if (selectedPlot != null)
            {

                int selectedindex = GetNearestPoint().GetNearestPointIndex();
                if ((selectedindex < labelarray.Length) && GetNearestPoint().GetNearestPointValid())
                {
                    tooltipstring = labelarray[selectedindex];
                }
            }

            this.CustomToolTipString = tooltipstring;
        }
    }
}
