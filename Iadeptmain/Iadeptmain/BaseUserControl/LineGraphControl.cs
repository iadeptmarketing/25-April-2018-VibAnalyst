using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using com.iAM.chart2dnet;
using System.Collections;
using System.Drawing.Drawing2D;
using DevExpress.XtraTreeList.Nodes;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;
using Iadeptmain;
using Iadeptmain.Mainforms;
using Iadeptmain.Images;
using Iadeptmain.GlobalClasses;
using Iadeptmain.Classes;
using System.Drawing.Printing;

namespace Iadeptmain.BaseUserControl
{
    public partial class LineGraphControl : ChartView
    {
        public LineGraphControl()
        {
            InitializeComponent();
            this.ThisMouseMove += new MouseMoveHandler(LineGraphControl_ThisMouseMove);
            this.GraphClicked += new GraphClickedHandler(LineGraphControl_GraphClicked);
            objlistimg.Images.Add(ImageResources.DarkRed);
            objlistimg.Images.Add(ImageResources.DarkGreen);
            objlistimg.Images.Add(ImageResources.DarkGoldenRod);
           // objlistimg.Images.Add(ImageResources.DarkVoilet);
            objlistimg.Images.Add(ImageResources.DarkBlue);
            objlistimg.Images.Add(ImageResources.DimGrey);
            objlistimg.Images.Add(ImageResources.Chocolate);
            objlistimg.Images.Add(ImageResources.DarkKhaki);
            objlistimg.Images.Add(ImageResources.Black);
            objlistimg.Images.Add(ImageResources.Orange);
            objlistimg.Images.Add(ImageResources.Cyan);
            objlistimg.Images.Add(ImageResources.AquaMarine);
            objlistimg.Images.Add(ImageResources.Bisque);
            objlistimg.Images.Add(ImageResources.Blue);
            objlistimg.Images.Add(ImageResources.BlueViolet);
            objlistimg.Images.Add(ImageResources.Coral);
            objlistimg.Images.Add(ImageResources.Darkmagenta);
            //objlistimg.Images.Add(ImageResources.DarkseaGreen);
            //objlistimg.Images.Add(ImageResources.DarkSlateBlue);
            //objlistimg.Images.Add(ImageResources.Deeppink);
            objlistimg.Images.Add(ImageResources.DodgerBlue);
            objlistimg.Images.Add(ImageResources.FireBrick);
            objlistimg.Images.Add(ImageResources.ForestGreen);
            objlistimg.Images.Add(ImageResources.GreenYellow);
            objlistimg.Images.Add(ImageResources.HotPink);
            objlistimg.Images.Add(ImageResources.IndianRed);
            objlistimg.Images.Add(ImageResources.Darkorange);
            objlistimg.Images.Add(ImageResources.Darkorchid);
            //objlistimg.Images.Add(ImageResources.DeepSkyBlue);
            objlistimg.Images.Add(ImageResources.SandyBrown);

        }
        ImageList objlistimg = new ImageList();
        string XLabel = "X Axis";
        string YLabel = "Y Axis";
        bool BearingFF = false;
        string BearingFFOverriddenRPM = null;
        LinearAxis xAxis2;
        LinearAxis yAxis2;
        Grid xgrid2;
        Grid ygrid2;
        NumericAxisLabels xAxisLab2;
        NumericAxisLabels yAxisLab2;
        AxisTitle yaxistitle2;
        AxisTitle xaxistitle2;
        frmGControls m_objGcontrol = null;
        Color GraphBG1 = Color.White;
        Color GraphBG2 = Color.White;
        Color ChartBG1 = Color.White;
        Color ChartBG2 = Color.White;
        Color AxisColor = Color.Black;
        Color FooterTextColor = Color.Black;
        int GraphBGDir = 0;
        int ChartBGDir = 0;
        ChartShape[] arrChartShape = null;
        ChartShape[] arrChartShape1 = null;
        Marker[] arrmarker = null;
        Marker[] arrmarkerCursor = null;
        ChartText[] arrChartText = null;
        ChartText[] arrChartTextCursor = new ChartText[0];
        ChartText[] arrChartTexthar = null;
        Marker FaultFrequencyMarkers = null;
        Marker m_objMarker = null;
        Marker m_objNewMarker = null;
        SimpleLinePlot m_objSelectedPlot = null;
        SimpleLinePlot m_objNewPlot = null;
        SimpleLinePlot m_objSelectedPlotForCursor = null;
        SimpleLinePlot m_objClickedPlot = null;
        SimpleLinePlot m_objOldSelectedPlot = null;
        public delegate void MouseMoveHandler(MouseEventArgs e);
        public event MouseMoveHandler ThisMouseMove;
        public delegate void GraphClickedHandler(MouseEventArgs e);
        public event GraphClickedHandler GraphClicked;
        DataCursor m_objDataCursor = null;
        public string SelectedCursor = null;
        SimpleDataset Dataset2;
        public  ChartView chartVu;
        ChartView[] arrchartvu;
        Font theFont = new Font("Arial", 8, FontStyle.Regular);
        SimpleLinePlot thePlot1;
        Background background;
        Background plotbackground;
        CartesianCoordinates pTransform1;
        int i;
        int j;
        ChartZoom zoomObj = null;
        Color MainCursor = Color.Black;
        ChartAttribute attrib2;
        string sColorTag = "7667712";
        bool bAreaFill = false;
        string ChartFooter = null;
        string ChartHeader = null;
        DataToolTip datatooltip = null;
        frmIAdeptMain MainForm = null;
        DataGridView objDataGridView = null;
        //DataGrid_Control objDatagridControl = null;
        bool _selectBandTrend = false;
        double OriginalYMaxscale = 0;
        ArrayList XYDATA = new ArrayList();
        SideBandTrend objTrend = null;
        DataGridViewX objDataGridView1 = null;
        int m_iCounter = 0;
        string[] xdatalabels = null;
        ResizeArray_Interface _ResizeArray = new ResizeArray_Control();
        frmDiagnostic objdiagnostic = null;



        public string _ChartHeader
        {
            get
            {
                return ChartHeader;
            }
            set
            {
                ChartHeader = value;
            }
        }
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
        public bool _AreaFill
        {
            get
            {
                return bAreaFill;
            }
            set
            {
                bAreaFill = value;
            }
        }
        
        public string _ColorTag
        {
            get
            {
                return sColorTag;
            }
            set
            {
                sColorTag = value;
            }
        }
        public Color _AxisColor
        {
            get
            {
                return AxisColor;
            }
            set
            {
                AxisColor = value;
                FooterTextColor = value;
            }
        }
        public Color _FooterColor
        {
            get
            {
                return FooterTextColor;
            }
            set
            {
                FooterTextColor = value;
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
        public string _XLabel
        {
            get
            {
                return XLabel;
            }
            set
            {
                XLabel = value;
            }
        }
        public string _YLabel
        {
            get
            {
                return YLabel;
            }
            set
            {
                YLabel = value;
            }
        }
        public string _BearingFFOverridenRPM
        {
            get
            {
                return BearingFFOverriddenRPM;
            }
            set
            {
                BearingFFOverriddenRPM = value;
            }
        }
        public bool _IsBearingFF
        {
            get
            {
                return BearingFF;
            }
            set
            {
                BearingFF = value;
            }
        }
        public ArrayList _XYDATA
        {
            get
            {
                return XYDATA;
            }
            set
            {
                XYDATA = value;
            }
        }
        public DataGridViewX DGVTrendNodes
        {
            get
            {
                return objDataGridView1;
            }
            set
            {
                objDataGridView1 = value;
            }
        }
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
        public bool SelectBandTrend
        {
            get
            {
                return _selectBandTrend;
            }
            set
            {
                _selectBandTrend = value;
            }
        }
        public DataGridView _DataGridView
        {
            get
            {
                return objDataGridView;
            }
            set
            {
                objDataGridView = value;
            }
        }
        
        public ChartView[] _Allchartviews
        {
            get
            {
                return arrchartvu;
            }
            set
            {
                arrchartvu = value;
            }
        }

        public ChartView LineChartView
        {
            get
            {
                return chartVu;
            }
            set
            {
                chartVu = value;
            }
        }



        public bool _ShowCursorVal
        {
            get
            {
                return MainForm._ShowCursorVal;
            }
            
        }

        internal ChartView DrawLineGraphDiag(ArrayList XYData, string[] ColorTag, string Xunit, string Yunit, string sPointID1, ArrayList FaultNameWithValue)
        {
            int[] ff = (int[])FaultNameWithValue[0];
            objdiagnostic = new frmDiagnostic();            
            RemovePreviousObjects();
            chartVu = this;
            bool InvertX = false;
            bool InvertY = false;
            try
            {
                SimpleDataset[] arrTestDataset = new SimpleDataset[0];
                for (int i = 0; i < XYData.Count / 2; i++)
                {
                    double[] testX = (double[])XYData[2 * i];
                    double[] testY = (double[])XYData[(2 * i) + 1];

                    if (Convert.ToDouble(testX[0].ToString()) > Convert.ToDouble(testX[testX.Length - 1].ToString()))
                    {
                        InvertX = true;
                    }

                    SimpleDataset testdataset = new SimpleDataset("Test", testX, testY);
                    try
                    {
                        testdataset.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, testX.Length, "Test");
                    }
                    catch
                    {
                    }
                    Array.Resize(ref arrTestDataset, arrTestDataset.Length + 1);
                    arrTestDataset[arrTestDataset.Length - 1] = testdataset;
                }

                pTransform1 = new CartesianCoordinates();
                pTransform1.AutoScale(arrTestDataset, ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_FAR);
                pTransform1.SetGraphBorderDiagonal(0.15, .15, .85, 0.85);
                if (InvertX)
                {
                    pTransform1.InvertScaleX();
                }
                if (InvertY)
                {
                    pTransform1.InvertScaleY();
                }
                plotbackground = new Background(pTransform1, ChartObj.PLOT_BACKGROUND, ChartBG1, ChartBG2, ChartBGDir);
                chartVu.AddChartObject(plotbackground);

                background = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND, GraphBG1, GraphBG2, GraphBGDir);
                chartVu.AddChartObject(background);


                xAxis2 = new LinearAxis(pTransform1, ChartObj.X_AXIS);
                xAxis2.SetColor(_AxisColor);
                xAxis2.SetAxisIntercept(0);
                chartVu.AddChartObject(xAxis2);

                yAxis2 = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                yAxis2.SetColor(_AxisColor);
                yAxis2.SetAxisIntercept(0);
                chartVu.AddChartObject(yAxis2);

                xgrid2 = new Grid(xAxis2, yAxis2, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                xgrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(xgrid2);

                ygrid2 = new Grid(xAxis2, yAxis2, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                ygrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(ygrid2);


                for (int i = 0; i < arrTestDataset.Length; i++)
                {
                    attrib2 = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[i])), 1, DashStyle.Solid, Color.FromArgb(150, Color.FromArgb(-Convert.ToInt32(ColorTag[i]))));
                    attrib2.SetLineColor(Color.FromArgb(-Convert.ToInt32(ColorTag[i])));
                    attrib2.SetFillFlag(_AreaFill);


                    thePlot1 = new SimpleLinePlot(pTransform1, arrTestDataset[i], attrib2);
                    chartVu.AddChartObject(thePlot1);
                }

                xAxisLab2 = new NumericAxisLabels(xAxis2);
                xAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(xAxisLab2);

                yAxisLab2 = new NumericAxisLabels(yAxis2);
                yAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(yAxisLab2);

                yaxistitle2 = new AxisTitle(yAxis2, theFont, Yunit);
                yaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(yaxistitle2);

                xaxistitle2 = new AxisTitle(xAxis2, theFont, Xunit);
                xaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(xaxistitle2);

                chartVu.SetResizeMode(ChartObj.NO_RESIZE_OBJECTS);

                Font toolTipFont = new Font("Arial", 10, FontStyle.Regular);
                DataToolTip datatooltip = new DataToolTip(chartVu);
                NumericLabel xValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                NumericLabel yValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                datatooltip.GetToolTipSymbol().SetColor(_AxisColor);
                datatooltip.SetXValueTemplate(xValueTemplate);
                datatooltip.SetYValueTemplate(yValueTemplate);
                datatooltip.SetDataToolTipFormat(ChartObj.DATA_TOOLTIP_XY_ONELINE);
                datatooltip.SetEnable(true);
                chartVu.SetCurrentMouseListener(datatooltip);
                chartVu.UpdateDraw();
                _XLabel = "Hz";
                chartVu = DrawMarkers(chartVu, ff);
            }
            catch (Exception ex)
            {
            }
            return chartVu;
        }

        public void DrawLineGraph(double[] Xdata, double[] Ydata, bool Areafill)
        {
            DrawLineGraph(Xdata, Ydata, _ColorTag, Areafill);
        }

        public void DrawLineGraphzoom(double[] Xdata, double[] Ydata, string ColorTag, bool Areafill)
        {
            RemovePreviousObjects();
            m_objSelectedPlot = null;
            m_objNewPlot = null;
            m_objSelectedPlotForCursor = null;
            m_objClickedPlot = null;
            PublicClass.chartscale = null;
            m_objOldSelectedPlot = null;
            chartVu = this;
            try
            {
                Dataset2 = new SimpleDataset("P/L", Xdata, Ydata);
                Dataset2.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, Ydata.Length - 1, "compressed");
                pTransform1 = new CartesianCoordinates();
                pTransform1.AutoScale(Dataset2, ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_FAR);
                pTransform1.SetGraphBorderDiagonal(0.15, .15, .85, 0.85);


                plotbackground = new Background(pTransform1, ChartObj.PLOT_BACKGROUND, ChartBG1, ChartBG2, ChartBGDir);
                chartVu.AddChartObject(plotbackground);

                background = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND, GraphBG1, GraphBG2, GraphBGDir);
                chartVu.AddChartObject(background);


                xAxis2 = new LinearAxis(pTransform1, ChartObj.X_AXIS);
                xAxis2.SetColor(_AxisColor);
                xAxis2.AxisTickSpace = 50.0;
                xAxis2.SetAxisIntercept(0);

                chartVu.AddChartObject(xAxis2);

                yAxis2 = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                yAxis2.AxisIntercept = 0;
                yAxis2.SetColor(_AxisColor);
                chartVu.AddChartObject(yAxis2);

                xgrid2 = new Grid(xAxis2, yAxis2, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                xgrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(xgrid2);

                ygrid2 = new Grid(xAxis2, yAxis2, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                ygrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(ygrid2);



                attrib2 = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag)), 1, DashStyle.Solid, Color.FromArgb(150, Color.FromArgb(-Convert.ToInt32(ColorTag))));
                attrib2.SetLineColor(Color.FromArgb(-Convert.ToInt32(ColorTag)));
                attrib2.SetFillFlag(Areafill);


                thePlot1 = new SimpleLinePlot(pTransform1, Dataset2, attrib2);
                chartVu.AddChartObject(thePlot1);

                xAxisLab2 = new NumericAxisLabels(xAxis2);
                xAxisLab2.SetColor(_AxisColor);             
                xAxisLab2.BaseAxis.AxisMinorTicksPerMajor = 5;
                chartVu.AddChartObject(xAxisLab2);

                yAxisLab2 = new NumericAxisLabels(yAxis2);
                yAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(yAxisLab2);

                yaxistitle2 = new AxisTitle(yAxis2, theFont, _YLabel);
                yaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(yaxistitle2);

                xaxistitle2 = new AxisTitle(xAxis2, theFont, _XLabel);
                xaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(xaxistitle2);

                PublicClass.chartscale = pTransform1.ScaleStopX.ToString();
                if (PublicClass.Chart_Footer != null)
                {
                    ChartTitle footer = new ChartTitle(pTransform1, theFont, PublicClass.Chart_Footer);
                    footer.SetColor(_FooterColor);
                    footer.SetTitleType(ChartObj.CHART_FOOTER);
                    footer.SetTitlePosition(ChartObj.GRAPHAREA_LEFT);
                    footer.SetTitleOffset(8);
                    chartVu.AddChartObject(footer);

                }
                if (_ChartHeader != null)
                {
                    ChartTitle Header = new ChartTitle(pTransform1, theFont, _ChartHeader);
                    Header.SetColor(_FooterColor);
                    Header.SetTitleType(ChartObj.CHART_HEADER);
                    Header.SetTitlePosition(ChartObj.GRAPHAREA_LEFT);
                    Header.SetTitleOffset(8);
                    chartVu.AddChartObject(Header);
                }

                Font toolTipFont = new Font("Arial", 10, FontStyle.Regular);
                datatooltip = new DataToolTip(chartVu);
                NumericLabel xValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                NumericLabel yValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                datatooltip.GetToolTipSymbol().SetColor(_AxisColor);
                datatooltip.SetXValueTemplate(xValueTemplate);
                datatooltip.SetYValueTemplate(yValueTemplate);
                datatooltip.SetDataToolTipFormat(ChartObj.DATA_TOOLTIP_XY_ONELINE);
                datatooltip.SetEnable(true);
                chartVu.SetCurrentMouseListener(datatooltip);
                SetSelectedPlot(thePlot1);
                chartVu.SetResizeMode(ChartObj.ACTUAL_SIZE);
            }
            catch (Exception ex)
            {
            }
        }



        public void DrawLineGraph(double[] Xdata, double[] Ydata, string ColorTag, bool Areafill)
        {
            RemovePreviousObjects();
            m_objSelectedPlot = null;
            m_objNewPlot = null;
            m_objSelectedPlotForCursor = null;
            m_objClickedPlot = null;
            PublicClass.chartscale = null;
            m_objOldSelectedPlot = null;
            chartVu = this;
            try
            {
                Dataset2 = new SimpleDataset("P/L", Xdata, Ydata);
                Dataset2.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, Ydata.Length, "compressed");
                pTransform1 = new CartesianCoordinates();
                pTransform1.AutoScale(Dataset2, ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_FAR);
                pTransform1.SetGraphBorderDiagonal(0.15, .15, .85, 0.85);
               

                plotbackground = new Background(pTransform1, ChartObj.PLOT_BACKGROUND, ChartBG1, ChartBG2, ChartBGDir);
                chartVu.AddChartObject(plotbackground);

                background = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND, GraphBG1, GraphBG2, GraphBGDir);
                chartVu.AddChartObject(background);


                xAxis2 = new LinearAxis(pTransform1, ChartObj.X_AXIS);
                xAxis2.SetColor(_AxisColor);
                xAxis2.SetAxisIntercept(0);

                chartVu.AddChartObject(xAxis2);

                yAxis2 = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                yAxis2.AxisIntercept = 0;
                yAxis2.SetColor(_AxisColor);
                chartVu.AddChartObject(yAxis2);

                xgrid2 = new Grid(xAxis2, yAxis2, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                xgrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(xgrid2);

                ygrid2 = new Grid(xAxis2, yAxis2, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                ygrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(ygrid2);



                attrib2 = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag)), 1, DashStyle.Solid, Color.FromArgb(150, Color.FromArgb(-Convert.ToInt32(ColorTag))));
                attrib2.SetLineColor(Color.FromArgb(-Convert.ToInt32(ColorTag)));
                attrib2.SetFillFlag(Areafill);


                thePlot1 = new SimpleLinePlot(pTransform1, Dataset2, attrib2);
                chartVu.AddChartObject(thePlot1);
                xAxisLab2 = new NumericAxisLabels(xAxis2);
                xAxisLab2.SetColor(_AxisColor);
                if (xAxisLab2.BaseAxis.AxisMax < 11)
                {

                }
                xAxisLab2.BaseAxis.AxisMinorTicksPerMajor = 5;
                chartVu.AddChartObject(xAxisLab2);

                yAxisLab2 = new NumericAxisLabels(yAxis2);
                yAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(yAxisLab2);

                yaxistitle2 = new AxisTitle(yAxis2, theFont, _YLabel);
                yaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(yaxistitle2);

                xaxistitle2 = new AxisTitle(xAxis2, theFont, _XLabel);
                xaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(xaxistitle2);


                if (PublicClass.Chart_Footer != null)
                {
                    ChartTitle footer = new ChartTitle(pTransform1, theFont, PublicClass.Chart_Footer);
                    footer.SetColor(_FooterColor);
                    footer.SetTitleType(ChartObj.CHART_FOOTER);
                    footer.SetTitlePosition(ChartObj.GRAPHAREA_LEFT);
                    footer.SetTitleOffset(8);
                    chartVu.AddChartObject(footer);
                    PublicClass.chartscale = pTransform1.ScaleStopX.ToString();

                }
                if (_ChartHeader != null)
                {
                    ChartTitle Header = new ChartTitle(pTransform1, theFont, _ChartHeader);
                    Header.SetColor(_FooterColor);
                    Header.SetTitleType(ChartObj.CHART_HEADER);
                    Header.SetTitlePosition(ChartObj.CENTER_GRAPH);
                    Header.SetTitleOffset(8);
                    chartVu.AddChartObject(Header);
                }

                Font toolTipFont = new Font("Arial", 10, FontStyle.Regular);
                datatooltip = new DataToolTip(chartVu);
                NumericLabel xValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                NumericLabel yValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                datatooltip.GetToolTipSymbol().SetColor(_AxisColor);
                datatooltip.SetXValueTemplate(xValueTemplate);
                datatooltip.SetYValueTemplate(yValueTemplate);
                datatooltip.SetDataToolTipFormat(ChartObj.DATA_TOOLTIP_XY_ONELINE);
                datatooltip.SetEnable(true);               
                chartVu.SetCurrentMouseListener(datatooltip);
                SetSelectedPlot(thePlot1);
                chartVu.SetResizeMode(ChartObj.ACTUAL_SIZE);
            }
            catch (Exception ex)
            {
            }
        }
             
        
        public void DrawLineGraph(double[] Xdata, double[] Ydata, string ColorCode)
        {
            DrawLineGraph(Xdata, Ydata, ColorCode, _AreaFill);
        }
        public void DrawLineGraph(double[] Xdata, double[] YData)
        {
            try
            {
                DrawLineGraph(Xdata, YData, _AreaFill);
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawLineGraph(ArrayList XData, ArrayList YData)
        {
            try
            {
                string[] ColorCode = { "7667712", "16751616", "4684277", "7077677", "16777077", "9868951", "2987746", "4343957", "16777216", "23296", "16711681", "8388652", "6972", "16776961", "7722014", "32944", "7667573", "7357301", "12042869", "60269", "14774017", "5103070", "14513374", "5374161", "38476", "3318692", "29696", "6737204", "16728065", "744352" };
                DrawLineGraph(XData, YData, ColorCode);
            }
            catch (Exception ex)
            {
            }
        }

        public void DrawLineGraph(ArrayList XYData, string[] ColorTag)
        {
            RemovePreviousObjects();
            m_objSelectedPlot = null;
            m_objNewPlot = null;
            m_objSelectedPlotForCursor = null;
            m_objClickedPlot = null;
            m_objOldSelectedPlot = null;
            chartVu = this;
            bool InvertX = false;
            bool InvertY = false;

            try
            {
                SimpleDataset[] arrTestDataset = new SimpleDataset[0];
               
                for (int i = 0; i < XYData.Count / 2; i++)
                {
                    double[] testX = (double[])XYData[2 * i];
                    double[] testY = (double[])XYData[(2 * i) + 1];

                    if (Convert.ToDouble(testX[0].ToString()) > Convert.ToDouble(testX[testX.Length - 1].ToString()))
                    {
                        InvertX = true;
                    }
                    SimpleDataset testdataset = new SimpleDataset("Test", testX, testY);
                    try
                    {
                        testdataset.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, testX.Length, "Test");
                    }
                    catch
                    {
                    }
                    Array.Resize(ref arrTestDataset, arrTestDataset.Length + 1);
                    arrTestDataset[arrTestDataset.Length - 1] = testdataset;
                }

                pTransform1 = new CartesianCoordinates();
                pTransform1.AutoScale(arrTestDataset, ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_FAR);
                pTransform1.SetGraphBorderDiagonal(0.15, .15, .85, 0.85);
                if (InvertX)
                {
                    pTransform1.InvertScaleX();
                }
                if (InvertY)
                {
                    pTransform1.InvertScaleY();
                }
                plotbackground = new Background(pTransform1, ChartObj.PLOT_BACKGROUND, ChartBG1, ChartBG2, ChartBGDir);
                chartVu.AddChartObject(plotbackground);

                background = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND, GraphBG1, GraphBG2, GraphBGDir);
                chartVu.AddChartObject(background);


                xAxis2 = new LinearAxis(pTransform1, ChartObj.X_AXIS);
                xAxis2.SetColor(_AxisColor);
                xAxis2.SetAxisIntercept(0);
                chartVu.AddChartObject(xAxis2);

                yAxis2 = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                yAxis2.SetColor(_AxisColor);
                yAxis2.SetAxisIntercept(0);
                chartVu.AddChartObject(yAxis2);

                xgrid2 = new Grid(xAxis2, yAxis2, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                xgrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(xgrid2);

                ygrid2 = new Grid(xAxis2, yAxis2, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                ygrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(ygrid2);


                for (int i = 0; i < arrTestDataset.Length; i++)
                {
                    try
                    {
                        attrib2 = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[i])), 1, DashStyle.Solid, Color.FromArgb(150, Color.FromArgb(-Convert.ToInt32(ColorTag[i]))));
                        attrib2.SetLineColor(Color.FromArgb(-Convert.ToInt32(ColorTag[i])));
                        attrib2.SetFillFlag(_AreaFill);                       
                        thePlot1 = new SimpleLinePlot(pTransform1, arrTestDataset[i], attrib2);
                        chartVu.AddChartObject(thePlot1);
                    }
                    catch
                    { }                    
                }

                xAxisLab2 = new NumericAxisLabels(xAxis2);
                xAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(xAxisLab2);

                yAxisLab2 = new NumericAxisLabels(yAxis2);
                yAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(yAxisLab2);

                yaxistitle2 = new AxisTitle(yAxis2, theFont, _YLabel);
                yaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(yaxistitle2);

                xaxistitle2 = new AxisTitle(xAxis2, theFont, _XLabel);
                xaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(xaxistitle2);

                

                Font toolTipFont = new Font("Arial", 10, FontStyle.Regular);
                DataToolTip datatooltip = new DataToolTip(chartVu);
                NumericLabel xValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                NumericLabel yValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                datatooltip.GetToolTipSymbol().SetColor(_AxisColor);
                datatooltip.SetXValueTemplate(xValueTemplate);
                datatooltip.SetYValueTemplate(yValueTemplate);
                datatooltip.SetDataToolTipFormat(ChartObj.DATA_TOOLTIP_XY_ONELINE);
                datatooltip.SetEnable(true);
                chartVu.SetCurrentMouseListener(datatooltip);
                chartVu.UpdateDraw();
                 SelectNextPlot(Convert.ToInt32(ColorTag[0].ToString()));
                chartVu.SetResizeMode(ChartObj.ACTUAL_SIZE);
            }
            catch (Exception ex)
            {
            }
        }

        int itime = 0;
        internal void DrawLineGraph(double[] Xdata, double[] Ydata, string[] XDataLabels)
        {
            RemovePreviousObjects();
            m_objSelectedPlot = null;
            m_objNewPlot = null;
            m_objSelectedPlotForCursor = null;
            m_objClickedPlot = null;
            m_objOldSelectedPlot = null;
            chartVu = this;
            StringAxisLabels x1AxisLab = null;
            xdatalabels = XDataLabels;
            try
            {
                Dataset2 = new SimpleDataset("P/L", Xdata, Ydata);
                Dataset2.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, Ydata.Length + 1, "compressed");
                pTransform1 = new CartesianCoordinates();
                pTransform1.AutoScale(Dataset2, ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_FAR);
                pTransform1.SetGraphBorderDiagonal(0.15, .15, .85, 0.85);

                plotbackground = new Background(pTransform1, ChartObj.PLOT_BACKGROUND, ChartBG1, ChartBG2, ChartBGDir);
                chartVu.AddChartObject(plotbackground);

                background = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND, GraphBG1, GraphBG2, GraphBGDir);
                chartVu.AddChartObject(background);


                xAxis2 = new LinearAxis(pTransform1, ChartObj.X_AXIS);
                xAxis2.SetColor(_AxisColor);
                
                chartVu.AddChartObject(xAxis2);

                yAxis2 = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                
                yAxis2.SetColor(_AxisColor);
                chartVu.AddChartObject(yAxis2);

                xgrid2 = new Grid(xAxis2, yAxis2, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                xgrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(xgrid2);

                ygrid2 = new Grid(xAxis2, yAxis2, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                ygrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(ygrid2);

                attrib2 = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(_ColorTag)), 1, DashStyle.Solid, Color.FromArgb(150, Color.FromArgb(-Convert.ToInt32(_ColorTag))));
                attrib2.SetLineColor(Color.FromArgb(-Convert.ToInt32(_ColorTag)));
                attrib2.SetFillFlag(_AreaFill);


                thePlot1 = new SimpleLinePlot(pTransform1, Dataset2, attrib2);
                chartVu.AddChartObject(thePlot1);

                //------------//
                string[] test = new string[XDataLabels.Length];
                // test[0] = " ";
                for (itime = 0; itime < XDataLabels.Length; itime++)
                {
                    string stemp = (string)XDataLabels[itime];
                    string[] ssst = stemp.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (ssst.Length > 1)
                    {
                        test[itime] = ssst[0] + " " + ssst[1];
                    }
                    else
                    {
                        test[itime] = "No Date";
                    }
                }

                //------------------//



                x1AxisLab = new StringAxisLabels(xAxis2);
                x1AxisLab.SetColor(_AxisColor);
                x1AxisLab.SetAxisLabelsStrings(test, itime+1);

                //-----------//

                x1AxisLab.BaseAxis.AxisTickOrigin = 0;
                if ((int)x1AxisLab.BaseAxis.AxisMax < 21)
                {
                    if (20 % ((int)x1AxisLab.BaseAxis.AxisMax - 1) == 0)
                    {
                        x1AxisLab.BaseAxis.AxisMinorTicksPerMajor = 20 / ((int)x1AxisLab.BaseAxis.AxisMax - 1);
                    }
                    else
                    {
                        if (x1AxisLab.BaseAxis.AxisMax < 4)
                        {
                            x1AxisLab.BaseAxis.AxisMinorTicksPerMajor = 10;
                        }
                        else if (x1AxisLab.BaseAxis.AxisMax < 11)
                        {
                            x1AxisLab.BaseAxis.AxisMinorTicksPerMajor = 5;
                        }
                        else if (x1AxisLab.BaseAxis.AxisMax < 15)
                        {
                            x1AxisLab.BaseAxis.AxisMinorTicksPerMajor = 2;
                        }
                        else
                        {
                            x1AxisLab.BaseAxis.AxisMinorTicksPerMajor = 1;
                        }
                    }
                }
                else
                {
                    x1AxisLab.BaseAxis.AxisMinorTicksPerMajor = 1;
                }



                //--------///


                x1AxisLab.SetOverlapLabelMode(ChartObj.OVERLAP_LABEL_DRAW);

                x1AxisLab.SetTextRotation(45);
                chartVu.AddChartObject(x1AxisLab);

                yAxisLab2 = new NumericAxisLabels(yAxis2);
                yAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(yAxisLab2);

                yaxistitle2 = new AxisTitle(yAxis2, theFont, _YLabel);
                yaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(yaxistitle2);

                xaxistitle2 = new AxisTitle(xAxis2, theFont, _XLabel);
                xaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(xaxistitle2);

                
                if (_ChartFooter != null)
                {
                    ChartTitle footer = new ChartTitle(pTransform1, theFont, _ChartFooter);
                    footer.SetColor(_FooterColor);
                    footer.SetTitleType(ChartObj.CHART_FOOTER);
                    footer.SetTitlePosition(ChartObj.CENTER_GRAPH);
                    footer.SetTitleOffset(8);
                    chartVu.AddChartObject(footer);
                }

                Font toolTipFont = new Font("Arial", 10, FontStyle.Regular);
                datatooltip = new DataToolTip(chartVu);
                NumericLabel xValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                NumericLabel yValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                datatooltip.GetToolTipSymbol().SetColor(_AxisColor);
                datatooltip.SetXValueTemplate(xValueTemplate);
                datatooltip.SetYValueTemplate(yValueTemplate);
                datatooltip.SetDataToolTipFormat(ChartObj.DATA_TOOLTIP_XY_ONELINE);
                datatooltip.SetEnable(true);
                chartVu.SetCurrentMouseListener(datatooltip);

               
                SetSelectedPlot(thePlot1);
                
                chartVu.SetResizeMode(ChartObj.ACTUAL_SIZE);
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawLineGraph(ArrayList XData, ArrayList YData, string[] ColorTag)
        {
            RemovePreviousObjects();
            m_objSelectedPlot = null;
            m_objNewPlot = null;
            m_objSelectedPlotForCursor = null;
            m_objClickedPlot = null;
            m_objOldSelectedPlot = null;
            chartVu = this;
            try
            {
                SimpleDataset[] arrSimpleDataset = new SimpleDataset[YData.Count];
                for (i = 0; i < YData.Count; i++)
                {
                    double[] yy = (double[])YData[i];
                    Dataset2 = new SimpleDataset("P/L", (double[])XData[i], (double[])YData[i]);
                    Dataset2.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, yy.Length, "compressed");
                    arrSimpleDataset[i] = Dataset2;
                }
                pTransform1 = new CartesianCoordinates();
                pTransform1.AutoScale(arrSimpleDataset, ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_FAR);
                pTransform1.SetGraphBorderDiagonal(0.15, .15, .85, 0.85);

                plotbackground = new Background(pTransform1, ChartObj.PLOT_BACKGROUND, ChartBG1, ChartBG2, ChartBGDir);
                chartVu.AddChartObject(plotbackground);

                background = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND, GraphBG1, GraphBG2, GraphBGDir);
                chartVu.AddChartObject(background);


                xAxis2 = new LinearAxis(pTransform1, ChartObj.X_AXIS);
                xAxis2.SetColor(_AxisColor);
                xAxis2.SetAxisIntercept(0);
                chartVu.AddChartObject(xAxis2);

                yAxis2 = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                yAxis2.SetColor(_AxisColor);
                chartVu.AddChartObject(yAxis2);

                xgrid2 = new Grid(xAxis2, yAxis2, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                xgrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(xgrid2);

                ygrid2 = new Grid(xAxis2, yAxis2, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                ygrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(ygrid2);


                for (i = 0; i < YData.Count; i++)
                {
                    attrib2 = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[i])), 1, DashStyle.Solid, Color.FromArgb(150, Color.FromArgb(-Convert.ToInt32(ColorTag[i]))));
                    attrib2.SetLineColor(Color.FromArgb(-Convert.ToInt32(ColorTag[i])));
                    attrib2.SetFillFlag(_AreaFill);


                    thePlot1 = new SimpleLinePlot(pTransform1, arrSimpleDataset[i], attrib2);
                    chartVu.AddChartObject(thePlot1);
                }
                xAxisLab2 = new NumericAxisLabels(xAxis2);
                xAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(xAxisLab2);

                yAxisLab2 = new NumericAxisLabels(yAxis2);
                yAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(yAxisLab2);

                yaxistitle2 = new AxisTitle(yAxis2, theFont, _YLabel);
                yaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(yaxistitle2);

                xaxistitle2 = new AxisTitle(xAxis2, theFont, _XLabel);
                xaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(xaxistitle2);

                chartVu.SetResizeMode(ChartObj.NO_RESIZE_OBJECTS);

                Font toolTipFont = new Font("Arial", 10, FontStyle.Regular);
                DataToolTip datatooltip = new DataToolTip(chartVu);
                NumericLabel xValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                NumericLabel yValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                datatooltip.GetToolTipSymbol().SetColor(_AxisColor);
                datatooltip.SetXValueTemplate(xValueTemplate);
                datatooltip.SetYValueTemplate(yValueTemplate);
                datatooltip.SetDataToolTipFormat(ChartObj.DATA_TOOLTIP_XY_ONELINE);
                datatooltip.SetEnable(true);
                chartVu.SetCurrentMouseListener(datatooltip);
                SetSelectedPlot(thePlot1);
            }
            catch (Exception ex)
            {
            }

        }
        public void SetSelectedPlot(SimpleLinePlot plot)
        {
            try
            {
                m_objClickedPlot = plot;
                m_objSelectedPlot = plot;
                m_objNewPlot = plot;
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawLineOrbitGraph(ArrayList XYData, string[] ColorTag)
        {
            RemovePreviousObjects();
            m_objSelectedPlot = null;
            m_objNewPlot = null;
            m_objSelectedPlotForCursor = null;
            m_objClickedPlot = null;
            m_objOldSelectedPlot = null;
            chartVu = this;
           

            try
            {
                SimpleDataset[] arrTestDataset = new SimpleDataset[0];
                for (int i = 0; i < XYData.Count / 2; i++)
                {
                    double[] testX = (double[])XYData[2 * i];
                    double[] testY = (double[])XYData[(2 * i) + 1];
                    
                    SimpleDataset testdataset = new SimpleDataset("Test", testX, testY);
                    try
                    {
                        testdataset.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, testX.Length, "Test");
                    }
                    catch
                    {
                    }
                    Array.Resize(ref arrTestDataset, arrTestDataset.Length + 1);
                    arrTestDataset[arrTestDataset.Length - 1] = testdataset;
                }




                pTransform1 = new CartesianCoordinates();
                pTransform1.AutoScale(arrTestDataset, ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_FAR);
                pTransform1.SetGraphBorderDiagonal(0.15, .15, .85, 0.85);
                
                plotbackground = new Background(pTransform1, ChartObj.PLOT_BACKGROUND, ChartBG1, ChartBG2, ChartBGDir);
                chartVu.AddChartObject(plotbackground);

                background = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND, GraphBG1, GraphBG2, GraphBGDir);
                chartVu.AddChartObject(background);


                xAxis2 = new LinearAxis(pTransform1, ChartObj.X_AXIS);
                xAxis2.SetColor(_AxisColor);
                xAxis2.SetAxisIntercept(0);
                chartVu.AddChartObject(xAxis2);

                yAxis2 = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                yAxis2.SetColor(_AxisColor);
                yAxis2.SetAxisIntercept(0);
                chartVu.AddChartObject(yAxis2);

                xgrid2 = new Grid(xAxis2, yAxis2, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                xgrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(xgrid2);

                ygrid2 = new Grid(xAxis2, yAxis2, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                ygrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(ygrid2);


                for (int i = 0; i < arrTestDataset.Length; i++)
                {
                    attrib2 = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[i])), 1, DashStyle.Solid, Color.FromArgb(150, Color.FromArgb(-Convert.ToInt32(ColorTag[i]))));
                    attrib2.SetLineColor(Color.FromArgb(-Convert.ToInt32(ColorTag[i])));
                    attrib2.SetFillFlag(_AreaFill);


                    thePlot1 = new SimpleLinePlot(pTransform1, arrTestDataset[i], attrib2);
                    chartVu.AddChartObject(thePlot1);
                }

                xAxisLab2 = new NumericAxisLabels(xAxis2);
                xAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(xAxisLab2);

                yAxisLab2 = new NumericAxisLabels(yAxis2);
                yAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(yAxisLab2);

                yaxistitle2 = new AxisTitle(yAxis2, theFont, _YLabel);
                yaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(yaxistitle2);

                xaxistitle2 = new AxisTitle(xAxis2, theFont, _XLabel);
                xaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(xaxistitle2);

                chartVu.SetResizeMode(ChartObj.NO_RESIZE_OBJECTS);

                Font toolTipFont = new Font("Arial", 10, FontStyle.Regular);
                DataToolTip datatooltip = new DataToolTip(chartVu);
                NumericLabel xValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                NumericLabel yValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                datatooltip.GetToolTipSymbol().SetColor(_AxisColor);
                datatooltip.SetXValueTemplate(xValueTemplate);
                datatooltip.SetYValueTemplate(yValueTemplate);
                datatooltip.SetDataToolTipFormat(ChartObj.DATA_TOOLTIP_XY_ONELINE);
                datatooltip.SetEnable(true);
                chartVu.SetCurrentMouseListener(datatooltip);
                chartVu.UpdateDraw();
                SelectNextPlot(Convert.ToInt32(ColorTag[0].ToString()));
            }
            catch (Exception ex)
            {
            }
        }
        public void AddNode(string SelectedNodepath)
        {
            string[] ColorCode = { "7667712", "16751616", "4684277", "7077677", "16777077", "9868951", "2987746", "4343957", "16777216", "23296", "16711681", "8388652", "6972", "16776961", "7722014", "32944", "7667573", "7357301", "12042869", "60269", "14774017", "5103070", "14513374", "5374161", "38476", "3318692", "29696", "6737204", "16728065", "744352" };

            try
            {
                int trendValCtr = (DGVTrendNodes.Rows.Count - 1) % 30;
                DGVTrendNodes.Rows.Add(1);
                DGVTrendNodes.Rows[DGVTrendNodes.Rows.Count - 2].Cells[0].Value = SelectedNodepath;
                DGVTrendNodes.Rows[DGVTrendNodes.Rows.Count - 2].Cells[1].Value = "√";
                DGVTrendNodes.Rows[DGVTrendNodes.Rows.Count - 2].Cells[3].Value = objlistimg.Images[trendValCtr];
                DGVTrendNodes.Rows[DGVTrendNodes.Rows.Count - 2].Cells[3].Tag = ColorCode[trendValCtr].ToString();

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
                hScrollBar1.Visible = false;
                chartVu.SetCurrentMouseListener(datatooltip);
                
            }
            catch { }
        }
        public void ResetZoom()
        {
            try
            {
                zoomObj = null;

            }
            catch (Exception ex)
            {
            }
        }
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
                            if (obj.Name != "SimpleLinePlot")
                            {
                                chartVu.DeleteChartObject(objObject);
                            }
                            else
                            {
                                iDel++;
                            }

                        }
                    }

                    plotbackground = new Background(pTransform1, ChartObj.PLOT_BACKGROUND, ChartBG1, ChartBG2, ChartBGDir);
                    chartVu.AddChartObject(plotbackground);

                    background = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND, GraphBG1, GraphBG2, GraphBGDir);
                    chartVu.AddChartObject(background);


                    xAxis2 = new LinearAxis(pTransform1, ChartObj.X_AXIS);
                    xAxis2.SetColor(_AxisColor);
                    xAxis2.SetAxisIntercept(0);
                    chartVu.AddChartObject(xAxis2);

                    yAxis2 = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                    yAxis2.SetColor(_AxisColor);
                    yAxis2.SetAxisIntercept(0);
                    chartVu.AddChartObject(yAxis2);

                    xgrid2 = new Grid(xAxis2, yAxis2, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                    xgrid2.SetColor(_AxisColor);
                    chartVu.AddChartObject(xgrid2);

                    ygrid2 = new Grid(xAxis2, yAxis2, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                    ygrid2.SetColor(_AxisColor);
                    chartVu.AddChartObject(ygrid2);                   
                    if (MainForm._IsOverallTrend)
                    {

                        StringAxisLabels x1AxisLab = new StringAxisLabels(xAxis2);
                        x1AxisLab.SetColor(_AxisColor);
                        x1AxisLab.SetAxisLabelsStrings(xdatalabels, xdatalabels.Length);
                        x1AxisLab.SetTextRotation(45);
                        chartVu.AddChartObject(x1AxisLab);
                    }
                    else
                    {
                        xAxisLab2 = new NumericAxisLabels(xAxis2);
                        xAxisLab2.SetColor(_AxisColor);
                        chartVu.AddChartObject(xAxisLab2);
                    }
                    yAxisLab2 = new NumericAxisLabels(yAxis2);
                    yAxisLab2.SetColor(_AxisColor);
                    chartVu.AddChartObject(yAxisLab2);


                    yaxistitle2 = new AxisTitle(yAxis2, theFont, _YLabel);
                    yaxistitle2.SetColor(_AxisColor);
                    chartVu.AddChartObject(yaxistitle2);

                    xaxistitle2 = new AxisTitle(xAxis2, theFont, _XLabel);
                    xaxistitle2.SetColor(_AxisColor);
                    chartVu.AddChartObject(xaxistitle2);
                    if (PublicClass.Chart_Footer != null)
                    {
                        ChartTitle footer = new ChartTitle(pTransform1, theFont, _ChartFooter);
                        footer.SetColor(_FooterColor);
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
        public void SetCursorType(string Cursor)
        {
            try
            {
                if (m_objMarker != null)
                {
                    chartVu.DeleteChartObject(m_objMarker);
                    chartVu.DeleteChartObject(m_objDataCursor);

                }
                if (arrmarkerCursor != null)
                {
                    for (int i = 0; i < arrmarkerCursor.Length; i++)
                    {
                        chartVu.DeleteChartObject(arrmarkerCursor[i]);
                    }
                    arrmarkerCursor = new Marker[0];
                }

                if (arrChartTextCursor != null)
                {
                    for (int i1 = 0; i1 < arrChartTextCursor.Length; i1++)
                    {
                        chartVu.DeleteChartObject(arrChartTextCursor[i1]);

                    }
                    arrChartTextCursor = new ChartText[0];
                }
                if (arrchartvu != null)
                {
                    for (int ictr = 0; ictr < arrchartvu.Length; ictr++)
                    {
                        ChartView chartu = arrchartvu[ictr];
                        
                        if (chartu != null)
                        {
                            ArrayList arrObjects = chartu.GetChartObjectsArrayList();
                            int iCount = arrObjects.Count;
                            if (arrObjects != null)
                            {
                                for (int iCtr = 0; iCtr < iCount; iCtr++)
                                {
                                    GraphObj objObject = (GraphObj)arrObjects[iCtr];

                                    Type obj = objObject.GetType();
                                    if (obj.Name.ToString().Contains("Marker"))
                                    {
                                        chartu.DeleteChartObject(objObject);
                                        ictr--;
                                        iCount--;
                                    }
                                    if (obj.Name.ToString().Contains("ChartText"))
                                    {
                                        chartu.DeleteChartObject(objObject);
                                        ictr--;
                                        iCount--;
                                    }
                                    if (obj.Name.ToString().Contains("Cursor"))
                                    {
                                        chartu.DeleteChartObject(objObject);
                                        ictr--;
                                        iCount--;
                                    }
                                }
                            }
                        }
                    }
                }              
                chartVu.UpdateDraw();
                if (Cursor == "Select Cursor")
                {
                    SelectedCursor = null;
                    m_objDataCursor = null;
                }
                else
                {
                    SelectedCursor = Cursor;
                    try
                    {
                        if (m_objDataCursor != null)
                        {
                            //chartVu.DeleteChartObject(m_objMarker);
                            chartVu.DeleteChartObject(m_objDataCursor);
                            chartVu.UpdateDraw();
                        }
                        m_objDataCursor = new DataCursor(chartVu, pTransform1, GraphObj.MARKER, 8.0);
                        m_objDataCursor.SetColor(_MainCursorColor);
                        m_objDataCursor.SetEnable(true);
                        m_objDataCursor.LineStyle = DashStyle.Solid;
                        chartVu.SetCurrentMouseListener(m_objDataCursor);
                        chartVu.AddChartObject(m_objDataCursor);

                        if (m_objMarker != null)
                        {
                            chartVu.DeleteChartObject(m_objMarker);
                            chartVu.UpdateDraw();
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public ArrayList SelectNextPlot(int ColorValue)
        {
            ArrayList arlstToreturn = new ArrayList();
            try
            {
                SimpleLinePlot[] AllPlots = GetAllPlots();
                Color SelectPlotColor = Color.FromArgb(-Convert.ToInt32(ColorValue));
                for (int iplot = 0; iplot < AllPlots.Length; iplot++)
                {
                    if (AllPlots[iplot].LineColor == SelectPlotColor)
                    {
                        SetSelectedPlot((SimpleLinePlot)AllPlots[iplot]);
                        SimpleDataset TestDataset = ((SimpleLinePlot)AllPlots[iplot]).DisplayDataset;
                        arlstToreturn.Add(TestDataset.GetXData());
                        arlstToreturn.Add(TestDataset.GetYData());
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return arlstToreturn;
        }

        public ArrayList GetAllPlotDataSet()
        {
            ArrayList arlstToreturn = new ArrayList();
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
                            GraphObj objObject = (GraphObj)arrObjects[iCtr];

                            Type obj = objObject.GetType();
                            if (obj.Name.ToString().Contains("SimpleLinePlot"))
                            {
                                SimpleLinePlot TestPlot = (SimpleLinePlot)objObject;
                                SimpleDataset TestDataset = TestPlot.DisplayDataset;
                                
                                arlstToreturn.Add(TestDataset.GetXData());
                                arlstToreturn.Add(TestDataset.GetYData());
                            }
                        }
                    }
                    chartVu.UpdateDraw();
                }
            }
            catch (Exception ex)
            {
            }
            return arlstToreturn;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            try
            {
                if (SelectedCursor != null)
                {
                    if (msg.Msg == WM_KEYDOWN)
                    {
                        switch (keyData)
                        {
                            case Keys.Left:
                                {
                                    CheckKeyDown("Left", SelectedCursor);
                                    break;
                                }
                            case Keys.Right:
                                {
                                    CheckKeyDown("Right", SelectedCursor);                                    
                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            try
            {
                if (this.GraphClicked != null)
                    this.GraphClicked(e);
            }
            catch (Exception ex)
            {
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            Point2D ptNewPoint = null;
            Point2D ptLocation = null;
            Point2D ptSecondPoint = null;
            Point2D ptPointGot = null;
            IDictionaryEnumerator objEnumerator = null;
            NearestPointData objSecondNearestPoint = null;
            bool bFirstPlot = false;
            bool bSecondPlot = true;
            
            try
            {
                if (ThisMouseMove != null)
                {
                    base.OnMouseMove(e);
                    ThisMouseMove(e);
                }

            }
            catch (Exception ex)
            {
                
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            try
            {
                if ((e.Button & MouseButtons.Right) != 0)
                {
                    base.OnMouseUp(e);
                }
                else if ((e.Button & MouseButtons.Left) != 0)
                {
                    MouseEventArgs _MouseEvent = e;
                    bool ok = true;
                    if (zoomObj != null)
                    {
                        int mx = e.X;
                        int my = e.Y;
                        int starting = (int)(chartVu.Width * .15);
                        int ending = (int)(chartVu.Width * .85);
                        if (mx < starting)
                        {
                            _MouseEvent = new MouseEventArgs(MouseButtons.Left, 1, starting + 1, my, 0);
                            ok = false;
                        }
                        if (mx > ending)
                        {
                            _MouseEvent = new MouseEventArgs(MouseButtons.Left, 1, ending, my, 0);
                            ok = false;
                        }
                    }
                    if (ok)
                    {
                        base.OnMouseUp(e);
                    }
                    else
                    {
                        base.OnMouseUp(_MouseEvent);
                    }
                }
                else
                {
                    base.OnMouseUp(e);
                }

                double diff = 0;
               // PublicClass.zoom = false;
                diff = Math.Abs((double)(m_objClickedPlot.DisplayDataset.GetXDataValue(0) - m_objClickedPlot.DisplayDataset.GetXDataValue(1)));
                double Index = zoomObj.ChartObjScale.GetScaleStartX() / diff;
                PublicClass.XMin = Convert.ToString(zoomObj.ChartObjScale.ScaleMinX);
                PublicClass.XMax = Convert.ToString(zoomObj.ChartObjScale.ScaleMaxX);
                hScrollBar1.Value = (int)Index;
                //PublicClass.zoom = true;
            }
            catch (Exception ex)
            { }
        }

        protected override void OnMouseDown(MouseEventArgs mouseevent)
        {
            try
            {                
                if ((mouseevent.Button & MouseButtons.Right) != 0)
                {
                    base.OnMouseDown(mouseevent);
                }
                else if ((mouseevent.Button & MouseButtons.Left) != 0)
                {
                    bool ok = true;
                    if (zoomObj != null)
                    {
                        int mx = mouseevent.X;
                        int my = mouseevent.Y;
                        int starting = (int)(chartVu.Width * .15);
                        int ending = (int)(chartVu.Width * .85);
                        if (mx < starting)
                        {
                            ok = false;
                        }
                        if (mx > ending)
                        {
                            ok = false;
                        }
                    }
                    if (ok)
                    {
                        base.OnMouseDown(mouseevent);
                    }
                }
                else
                {
                    base.OnMouseDown(mouseevent);
                }
            }
            catch (Exception ex)
            {
            }
        }
        void LineGraphControl_GraphClicked(MouseEventArgs e)
        {
          
        }
        SimpleDataset Dataset1 = null;      
        void LineGraphControl_ThisMouseMove(MouseEventArgs e)
        {
            Point2D objClickedPoint = null;
            double dZValue = 0;
            Point2D objPoint3D = null;
            NearestPointData objNearestPoint = null;
            Point2D objLocationPoint = null;
            Point2D objGetPoint = null;
            String sDisplaytext = null;

            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            Point2D ptNewPoint = null;
            Point2D ptLocation = null;
            Point2D ptSecondPoint = null;
            Point2D ptPointGot = null;
            IDictionaryEnumerator objEnumerator = null;
            NearestPointData objSecondNearestPoint = null;
            bool bFirstPlot = false;
            bool bSecondPlot = true;
            
            Color DifferenceLineColor = Color.Black;
            try
            {
                Point2D objNewPoint = new Point2D();
                objNewPoint.SetLocation(e.X, e.Y);
                
                ChartObj objNewObject = chartVu.FindObj(objNewPoint, "SimpleLinePlot");

                if (objNewObject != null)
                {
                    chartVu.Cursor = Cursors.Hand;
                }
                else
                {
                    chartVu.Cursor = Cursors.Arrow;                    
                }
                if (e.Button == MouseButtons.Left)
                {
                    if (SelectedCursor != null)
                    {
                        if (m_objNewPlot != null)
                        {
                            m_objSelectedPlotForCursor = m_objNewPlot;

                            if (m_objClickedPlot != null)
                            {
                                Dataset1 = m_objSelectedPlotForCursor.DisplayDataset;
                                
                                nearestPointObj1 = new NearestPointData();
                                objSecondNearestPoint = new NearestPointData();
                                textCoordsFont = new Font("Arial", 8, FontStyle.Regular);
                                base.OnMouseMove(e);
                                if (m_objDataCursor != null)
                                {
                                    ptLocation = m_objDataCursor.Location;
                                    bFirstPlot = m_objClickedPlot.CalcNearestPoint(ptLocation, 3, nearestPointObj1);
                                }                                
                                ptNewPoint = nearestPointObj1.GetNearestPoint();
                                m_iCounter = nearestPointObj1.GetNearestPointIndex();
                                if (SelectedCursor == "Delta Cursors")
                                {
                                    DifferenceLineColor = selectLineColor();
                                    if (m_objMarker != null)
                                    {
                                        chartVu.DeleteChartObject(m_objMarker);                                       
                                        chartVu.DeleteChartObject(m_objDataCursor);
                                    }
                                    if (arrmarkerCursor != null)
                                    {                                        
                                        try
                                        {
                                            chartVu.DeleteChartObject(arrmarkerCursor[_MainForm._SelectedRowIndex]);
                                            chartVu.DeleteChartObject(m_objDataCursor);
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    if (arrChartTextCursor != null)
                                    {                                        
                                        try
                                        {
                                            chartVu.DeleteChartObject(arrChartTextCursor[_MainForm._SelectedRowIndex]);
                                        }
                                        catch
                                        {
                                        }
                                    }
                                }
                                else
                                {
                                    if (m_objMarker != null)
                                    {
                                        chartVu.DeleteChartObject(m_objMarker);                                        
                                        chartVu.DeleteChartObject(m_objDataCursor);
                                    }
                                    if (arrmarkerCursor != null)
                                    {
                                        for (int i = 0; i < arrmarkerCursor.Length; i++)
                                        {
                                            chartVu.DeleteChartObject(arrmarkerCursor[i]);
                                            chartVu.DeleteChartObject(m_objDataCursor);
                                        }
                                    }
                                    if (arrChartTextCursor != null)
                                    {
                                        for (int i1 = 0; i1 < arrChartTextCursor.Length; i1++)
                                        {
                                            chartVu.DeleteChartObject(arrChartTextCursor[i1]);
                                        }
                                    }
                                    arrChartTextCursor = new ChartText[0];

                                    m_objMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                                    if (_DataGridView != null)
                                    {
                                        _DataGridView.Rows.Clear();                                        
                                    }
                                    if (SelectedCursor == "Line1")
                                    {
                                        for (int ictr = 0; ictr < arrchartvu.Length; ictr++)
                                        {
                                            ChartView chartu = arrchartvu[ictr];
                                            
                                            if (chartu != null)
                                            {
                                                ArrayList arrObjects = chartu.GetChartObjectsArrayList();
                                                int iCount = arrObjects.Count;
                                                if (arrObjects != null)
                                                {
                                                    for (int iCtr = 0; iCtr < iCount; iCtr++)
                                                    {
                                                        GraphObj objObject = (GraphObj)arrObjects[iCtr];

                                                        Type obj = objObject.GetType();
                                                        if (obj.Name.ToString().Contains("Marker"))
                                                        {
                                                            chartu.DeleteChartObject(objObject);
                                                            ictr--;
                                                            iCount--;
                                                        }
                                                        if (obj.Name.ToString().Contains("ChartText"))
                                                        {
                                                            chartu.DeleteChartObject(objObject);
                                                            ictr--;
                                                            iCount--;
                                                        }
                                                        if (obj.Name.ToString().Contains("Cursor"))
                                                        {
                                                            chartu.DeleteChartObject(objObject);
                                                            ictr--;
                                                            iCount--;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        _DataGridView.Rows.Add(arrchartvu.Length);
                                    }
                                }                               
                                BearingFFOverriddenRPM = ptNewPoint.GetX().ToString();
                                switch (SelectedCursor)
                                {
                                    case "Delta Cursors":
                                        {
                                            if (arrmarkerCursor == null)
                                            {
                                                arrmarkerCursor = new Marker[_DataGridView.RowCount];
                                                arrChartTextCursor = new ChartText[_DataGridView.RowCount];
                                            }
                                            else if (arrmarkerCursor.Length != _DataGridView.RowCount)
                                            {
                                                arrmarkerCursor = new Marker[_DataGridView.RowCount];
                                                arrChartTextCursor = new ChartText[_DataGridView.RowCount];
                                            }

                                            Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                                            m_objMarker1.SetColor(DifferenceLineColor);
                                            arrmarkerCursor[_MainForm._SelectedRowIndex] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);
                                            ChartText CurrentLabel = null;
                                            if (_MainForm._IsOverallTrend)
                                            {
                                                CurrentLabel = new ChartText(pTransform1, theFont, xdatalabels[(int)ptNewPoint.GetX() - 1].ToString() + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                                _DataGridView[1, _MainForm._SelectedRowIndex].Value = xdatalabels[(int)ptNewPoint.GetX() - 1].ToString();
                                            }
                                            else
                                            {                                                
                                                CurrentLabel = new ChartText(pTransform1, theFont, ptNewPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                                _DataGridView[1, _MainForm._SelectedRowIndex].Value = ptNewPoint.GetX().ToString();
                                            }
                                            CurrentLabel.SetColor(DifferenceLineColor);
                                            if (_ShowCursorVal)
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[_MainForm._SelectedRowIndex] = CurrentLabel;
                                            chartVu.UpdateDraw();
                                            _DataGridView[2, _MainForm._SelectedRowIndex].Value = Convert.ToString(Math.Round(ptNewPoint.GetY(),5));

                                            for (int k = 0; k < _DataGridView.RowCount - 1; k++)
                                            {
                                                if (!string.IsNullOrEmpty((string)_DataGridView[1, k].Value))
                                                {
                                                    if (_XLabel == "Sec")
                                                    {
                                                        if (k != 0)
                                                        {
                                                            _DataGridView[3, k].Value = Convert.ToString(Convert.ToDouble(_DataGridView[1, k].Value.ToString()) - Convert.ToDouble(_DataGridView[1, 0].Value.ToString())) + "Sec / " + Convert.ToString(Math.Round(Convert.ToDouble(1 / (Convert.ToDouble(_DataGridView[1, k].Value.ToString()) - Convert.ToDouble(_DataGridView[1, 0].Value.ToString()))), 3)) + "Hz";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        _DataGridView[3, k].Value = Convert.ToDouble(_DataGridView[1, k].Value.ToString()) - Convert.ToDouble(_DataGridView[1, 0].Value.ToString());
                                                    }
                                                    _DataGridView[4, k].Value = Convert.ToDouble(_DataGridView[2, k].Value.ToString()) - Convert.ToDouble(_DataGridView[2, 0].Value.ToString());
                                                }
                                            }
                                            _DataGridView.Refresh();
                                            break;
                                        }
                                    case "PeekCursor":
                                        {
                                            double harmonicX = ptNewPoint.GetX();
                                            arrmarkerCursor = new Marker[1];
                                            arrChartTextCursor = new ChartText[1];
                                            double[] PeekXdata = FindAllPeaks((double[])Dataset1.XData.GetDataBuffer(), (double[])Dataset1.YData.GetDataBuffer());
                                            int MainIndex = Array.FindIndex(PeekXdata, delegate(double item) { return item == harmonicX; });
                                            if (MainIndex == -1)
                                            {
                                                if (harmonicX <= PeekXdata[PeekXdata.Length - 1])
                                                {
                                                    harmonicX = FindNearest(PeekXdata, harmonicX);
                                                    MainIndex = Array.FindIndex(PeekXdata, delegate(double item) { return item == harmonicX; });
                                                }
                                            }
                                            Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, harmonicX, Dataset1.YData.GetDataBuffer()[PeekIndex[MainIndex]], 8, 1);

                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[0] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);
                                            ChartText CurrentLabel = null;
                                            _DataGridView.Rows.Add(1);
                                            if (_MainForm._IsOverallTrend)
                                            {                                                
                                            }
                                            else
                                            {                                                
                                                CurrentLabel = new ChartText(pTransform1, theFont, harmonicX.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(Dataset1.YData.GetDataBuffer()[PeekIndex[MainIndex]]), 5)) + YLabel, harmonicX, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                                _DataGridView[0, 0].Value = harmonicX.ToString();
                                            }
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            if (_ShowCursorVal) 
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[0] = CurrentLabel;
                                            _DataGridView[1, 0].Value = Convert.ToString(Math.Round(Convert.ToDouble(Dataset1.YData.GetDataBuffer()[PeekIndex[MainIndex]]), 5));
                                            _DataGridView.Refresh();

                                            m_iCounter = MainIndex;
                                            break;
                                        }
                                    case "Kill Cursor":
                                        {
                                            arrmarkerCursor = new Marker[1];
                                            arrChartTextCursor = new ChartText[1];
                                            Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[0] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);
                                            ChartText CurrentLabel = null;
                                            _DataGridView.Rows.Add(1);
                                            if (_MainForm._IsOverallTrend)
                                            {                                                
                                                CurrentLabel = new ChartText(pTransform1, theFont, xdatalabels[(int)ptNewPoint.GetX() - 1].ToString() + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                                _DataGridView[0, 0].Value = xdatalabels[(int)ptNewPoint.GetX() - 1].ToString();
                                            }
                                            else
                                            {                                                
                                                CurrentLabel = new ChartText(pTransform1, theFont, ptNewPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                                _DataGridView[0, 0].Value = ptNewPoint.GetX().ToString();
                                            }
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            if (_ShowCursorVal)
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[0] = CurrentLabel;
                                            _DataGridView[1, 0].Value = ptNewPoint.GetY().ToString();
                                            _DataGridView.Refresh();
                                            break;
                                        }
                                    case "Line":
                                        {
                                            try
                                            {
                                                arrmarkerCursor = new Marker[1];
                                                arrChartTextCursor = new ChartText[1];
                                                Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, PublicClass.Xline, PublicClass.Yline, 8, 1);
                                                m_objMarker1.SetColor(_MainCursorColor);
                                                arrmarkerCursor[0] = m_objMarker1;
                                                chartVu.AddChartObject(m_objMarker1);
                                                ChartText CurrentLabel = null;
                                                _DataGridView.Rows.Add(1);
                                                if (_MainForm._IsOverallTrend)
                                                {
                                                    CurrentLabel = new ChartText(pTransform1, theFont, xdatalabels[(int)ptNewPoint.GetX() - 1].ToString() + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                                    _DataGridView[0, 0].Value = xdatalabels[(int)ptNewPoint.GetX() - 1].ToString();
                                                }
                                                else
                                                {
                                                    CurrentLabel = new ChartText(pTransform1, theFont, Convert.ToString(Math.Round(PublicClass.Xline, 3)) + XLabel + " / " + Convert.ToString(Math.Round(PublicClass.Yline, 5)) + YLabel, PublicClass.Xline, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                                    _DataGridView[0, 0].Value = Convert.ToString(PublicClass.Xline);
                                                }
                                                CurrentLabel.SetColor(_MainCursorColor);
                                                if (_ShowCursorVal)
                                                {
                                                    chartVu.AddChartObject(CurrentLabel);
                                                }
                                                arrChartTextCursor[0] = CurrentLabel;
                                                _DataGridView[1, 0].Value = Convert.ToString(Math.Round(PublicClass.Yline, 5));
                                                _DataGridView.Refresh();
                                            }
                                            catch { }
                                            break;
                                        }
                                    case "Line With SideBand":
                                        {
                                            arrmarkerCursor = new Marker[3];
                                            arrChartTextCursor = new ChartText[3];

                                            double fline = PublicClass.Xline;
                                            double flineMUL = 2 * fline;
                                            double FSynch = flineMUL / Convert.ToDouble(PublicClass.checkpole);
                                            double FSlip = FSynch - Convert.ToDouble(PublicClass.actualspeed / 60);

                                            double FPole = Convert.ToDouble(PublicClass.checkpole) * FSlip;


                                            string[] RatioExtractor = MainForm.TrendRatio.ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                                            int Pctg = Convert.ToInt32(FPole);//Convert.ToInt32(MainForm.SBValue.ToString()); //Convert.ToInt32(tbSideBandPercentage.Text.ToString());
                                            double LowerLimit = PublicClass.Xline - (PublicClass.Xline * Pctg / 100);
                                            double UpperLimit = PublicClass.Xline + (PublicClass.Xline * Pctg / 100);


                                            Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, PublicClass.Xline, PublicClass.Yline, 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[0] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);

                                            ChartText CurrentLabel = new ChartText(pTransform1, theFont, PublicClass.Xline + XLabel + " / " + Convert.ToString(Math.Round(PublicClass.Yline, 5)) + YLabel, PublicClass.Xline, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            if (_ShowCursorVal)
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[0] = CurrentLabel;

                                            _DataGridView.Rows.Add(1);
                                            _DataGridView[0, _DataGridView.Rows.Count - 2].Value = PublicClass.Xline;
                                            _DataGridView[1, _DataGridView.Rows.Count - 2].Value = Convert.ToString(Math.Round(PublicClass.Yline, 5));

                                            int MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                                            if (MainIndex == -1)
                                            {
                                                if (LowerLimit >= Dataset1.XData[0])
                                                {
                                                    LowerLimit = FindNearest(Dataset1.XData.GetDataBuffer(), LowerLimit);
                                                    MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                                                }
                                            }

                                            m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, LowerLimit, Dataset1.YData[MainIndex], 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[1] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);

                                            CurrentLabel = new ChartText(pTransform1, theFont, LowerLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(Dataset1.YData[MainIndex]), 5)) + YLabel, LowerLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            if (_ShowCursorVal)
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[1] = CurrentLabel;

                                            _DataGridView.Rows.Add(1);
                                            _DataGridView[0, _DataGridView.Rows.Count - 2].Value = LowerLimit.ToString();
                                            _DataGridView[1, _DataGridView.Rows.Count - 2].Value = Convert.ToString(Math.Round(Dataset1.YData[MainIndex], 5));

                                            MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                                            if (MainIndex == -1)
                                            {
                                                if (UpperLimit <= Dataset1.XData[Dataset1.XData.Length - 1])
                                                {
                                                    UpperLimit = FindNearest(Dataset1.XData.GetDataBuffer(), UpperLimit);
                                                    MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                                                }
                                            }

                                            m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, UpperLimit, Dataset1.YData[MainIndex], 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[2] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);

                                            CurrentLabel = new ChartText(pTransform1, theFont, UpperLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(Dataset1.YData[MainIndex]), 5)) + YLabel, UpperLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            if (_ShowCursorVal)
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[2] = CurrentLabel;

                                            _DataGridView.Rows.Add(1);
                                            _DataGridView[0, _DataGridView.Rows.Count - 2].Value = UpperLimit.ToString();
                                            _DataGridView[1, _DataGridView.Rows.Count - 2].Value = Convert.ToString(Math.Round(Dataset1.YData[MainIndex], 3));
                                            _DataGridView.Refresh();

                                            break;
                                        }
                                    case "Single":
                                        {
                                            arrmarkerCursor = new Marker[1];
                                            arrChartTextCursor = new ChartText[1];
                                            Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[0] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);
                                            ChartText CurrentLabel = null;
                                            _DataGridView.Rows.Add(1);
                                            if (_MainForm._IsOverallTrend)
                                            {                                                
                                                CurrentLabel = new ChartText(pTransform1, theFont, xdatalabels[(int)ptNewPoint.GetX() - 1].ToString() + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                                _DataGridView[0, 0].Value = xdatalabels[(int)ptNewPoint.GetX() - 1].ToString();
                                            }
                                            else
                                            {
                                                CurrentLabel = new ChartText(pTransform1, theFont, Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetX()), 3)) + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                                _DataGridView[0, 0].Value = ptNewPoint.GetX().ToString();
                                            }
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            if (_ShowCursorVal) 
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[0] = CurrentLabel;
                                            _DataGridView[1, 0].Value = Convert.ToString(Math.Round(ptNewPoint.GetY(),5));
                                            _DataGridView.Refresh();
                                            break;
                                        }
                                    case "Harmonic":
                                        {
                                            try
                                            {                                              
                                                if (MainForm.boolharmonic == "true")
                                                {
                                                   // MainForm.boolharmonic = false;
                                                    int counthar = MainForm.counthar;
                                                    if (counthar == 0)
                                                    {
                                                        MessageBox.Show(this, "Select Harmonic Value...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                        return;
                                                    }
                                                    double harmonicX = MainForm.countharval;
                                                    if (harmonicX == 0.0)
                                                    {
                                                        MessageBox.Show(this, "Enter Refrence Value...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                        return;
                                                    }
                                                    Dataset1 = m_objSelectedPlotForCursor.DisplayDataset;
                                                    //double harmonicX = ptNewPoint.GetX();
                                                    double lastx = Dataset1.XData[Dataset1.XData.Length - 1];
                                                    arrmarkerCursor = new Marker[0];
                                                    arrChartTextCursor = new ChartText[0];
                                                    //if (harmonicX <= (double)(lastx * .01))
                                                    //{
                                                    //    harmonicX = (double)(lastx * .01);
                                                    //}
                                                    double constantHarmonicX = harmonicX;
                                                    Random _random = new Random(_MainCursorColor.ToArgb());
                                                    //while (harmonicX <= lastx)
                                                    for (int i = 0; i < counthar; i++)
                                                    {
                                                        int MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == harmonicX; });
                                                        if (MainIndex == -1)
                                                        {
                                                            if (harmonicX <= Dataset1.XData[Dataset1.XData.Length - 1])
                                                            {
                                                                harmonicX = FindNearest(Dataset1.XData.GetDataBuffer(), harmonicX);
                                                                MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == harmonicX; });
                                                            }
                                                        }
                                                        Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, harmonicX, Dataset1.YData[MainIndex], 8, 1);

                                                        Array.Resize(ref arrmarkerCursor, arrmarkerCursor.Length + 1);
                                                        arrmarkerCursor[arrmarkerCursor.Length - 1] = m_objMarker1;


                                                        ChartText CurrentLabel = new ChartText(pTransform1, theFont, harmonicX.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(Dataset1.YData[MainIndex]), 5)) + YLabel, harmonicX, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                                        CurrentLabel.SetColor(_MainCursorColor);
                                                        if (_ShowCursorVal)
                                                        {
                                                            chartVu.AddChartObject(CurrentLabel);
                                                        }
                                                        Array.Resize(ref arrChartTextCursor, arrChartTextCursor.Length + 1);
                                                        arrChartTextCursor[arrChartTextCursor.Length - 1] = CurrentLabel;

                                                        arrmarkerhar = arrmarkerCursor;
                                                        arrChartTexthar = arrChartTextCursor;
                                                        Color NewColor = Color.FromArgb(-Convert.ToInt32(_random.Next()));
                                                        m_objMarker1.FillColor = NewColor;

                                                        m_objMarker1.SetColor(NewColor);
                                                        chartVu.AddChartObject(m_objMarker1);
                                                        _DataGridView.Rows.Add(1);
                                                        _DataGridView[0, _DataGridView.Rows.Count - 2].Value = Convert.ToDouble(harmonicX);
                                                        _DataGridView[1, _DataGridView.Rows.Count - 2].Value = Convert.ToString(Math.Round(Dataset1.YData[MainIndex],3));
                                                        _DataGridView.Refresh();
                                                        harmonicX += constantHarmonicX;
                                                        // MainForm.boolharmonic = null;
                                                    }
                                                }
                                                else
                                                { return;
                                                }
                                            }
                                            catch { }
                                            break;
                                        }
                                    case "Single With Square":
                                        {
                                            arrmarkerCursor = new Marker[2];
                                            arrChartTextCursor = new ChartText[1];
                                            Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_BOX, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[0] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);
                                            m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[1] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);
                                            ChartText CurrentLabel = null;
                                            _DataGridView.Rows.Add(1);
                                            if (_MainForm._IsOverallTrend)
                                            {
                                                CurrentLabel = new ChartText(pTransform1, theFont, xdatalabels[(int)ptNewPoint.GetX() - 1].ToString() + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                                _DataGridView[0, 0].Value = xdatalabels[(int)ptNewPoint.GetX() - 1].ToString();
                                            }
                                            else
                                            {
                                                CurrentLabel = new ChartText(pTransform1, theFont, ptNewPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                                _DataGridView[0, 0].Value = ptNewPoint.GetX().ToString();
                                            }
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            if (_ShowCursorVal) //cursor position View on/off
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[0] = CurrentLabel;

                                            _DataGridView[1, 0].Value = Convert.ToString(Math.Round(ptNewPoint.GetY(), 5));
                                            _DataGridView.Refresh();
                                            
                                            break;
                                        }
                                    case "Cross Hair":
                                        {
                                            arrmarkerCursor = new Marker[2];
                                            arrChartTextCursor = new ChartText[1];
                                            Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_HLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[0] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);
                                            m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[1] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);

                                            ChartText CurrentLabel = null;
                                            _DataGridView.Rows.Add(1);
                                            if (_MainForm._IsOverallTrend)
                                            {
                                                CurrentLabel = new ChartText(pTransform1, theFont, xdatalabels[(int)ptNewPoint.GetX() - 1].ToString() + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                                _DataGridView[0, 0].Value = xdatalabels[(int)ptNewPoint.GetX() - 1].ToString();
                                            }
                                            else
                                            {
                                                CurrentLabel = new ChartText(pTransform1, theFont, ptNewPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                                _DataGridView[0, 0].Value = ptNewPoint.GetX().ToString();
                                            }
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            if (_ShowCursorVal) 
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[0] = CurrentLabel;

                                            _DataGridView[1, 0].Value = Convert.ToString(Math.Round(ptNewPoint.GetY(), 5));
                                            _DataGridView.Refresh();
                                           
                                            break;
                                        }
                                    case "Sideband":
                                        {
                                            arrmarkerCursor = new Marker[3];
                                            arrChartTextCursor = new ChartText[3];

                                            string[] RatioExtractor = MainForm.TrendRatio.ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                                            int Pctg = Convert.ToInt32(MainForm.SBValue.ToString()); //Convert.ToInt32(tbSideBandPercentage.Text.ToString());
                                            double LowerLimit = ptNewPoint.GetX() - (ptNewPoint.GetX() * Pctg / 100);
                                            double UpperLimit = ptNewPoint.GetX() + (ptNewPoint.GetX() * Pctg / 100);

                                            
                                            Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[0] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);

                                            ChartText CurrentLabel = new ChartText(pTransform1, theFont, ptNewPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            if (_ShowCursorVal) 
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[0] = CurrentLabel;

                                            _DataGridView.Rows.Add(1);
                                            _DataGridView[0, _DataGridView.Rows.Count - 2].Value = ptNewPoint.GetX().ToString();
                                            _DataGridView[1, _DataGridView.Rows.Count - 2].Value = Convert.ToString(Math.Round(ptNewPoint.GetY(), 5));

                                            int MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                                            if (MainIndex == -1)
                                            {
                                                if (LowerLimit >= Dataset1.XData[0])
                                                {
                                                    LowerLimit = FindNearest(Dataset1.XData.GetDataBuffer(), LowerLimit);
                                                    MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                                                }
                                            }

                                            m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, LowerLimit, Dataset1.YData[MainIndex], 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[1] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);

                                            CurrentLabel = new ChartText(pTransform1, theFont, LowerLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(Dataset1.YData[MainIndex]), 5)) + YLabel, LowerLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            if (_ShowCursorVal) 
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[1] = CurrentLabel;

                                            _DataGridView.Rows.Add(1);
                                            _DataGridView[0, _DataGridView.Rows.Count - 2].Value = LowerLimit.ToString();
                                            _DataGridView[1, _DataGridView.Rows.Count - 2].Value = Convert.ToString(Math.Round(Dataset1.YData[MainIndex],5));

                                            MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                                            if (MainIndex == -1)
                                            {
                                                if (UpperLimit <= Dataset1.XData[Dataset1.XData.Length - 1])
                                                {
                                                    UpperLimit = FindNearest(Dataset1.XData.GetDataBuffer(), UpperLimit);
                                                    MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                                                }
                                            }

                                            m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, UpperLimit, Dataset1.YData[MainIndex], 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[2] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);

                                            CurrentLabel = new ChartText(pTransform1, theFont, UpperLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(Dataset1.YData[MainIndex]), 5)) + YLabel, UpperLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            if (_ShowCursorVal)
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[2] = CurrentLabel;

                                            _DataGridView.Rows.Add(1);
                                            _DataGridView[0, _DataGridView.Rows.Count - 2].Value = UpperLimit.ToString();
                                            _DataGridView[1, _DataGridView.Rows.Count - 2].Value = Convert.ToString(Math.Round(Dataset1.YData[MainIndex],3));
                                            _DataGridView.Refresh();
                                            break;
                                        }
                                    case "SidebandRatio":
                                        {
                                            arrmarkerCursor = new Marker[3];
                                            arrChartTextCursor = new ChartText[3];

                                            string[] RatioExtractor = MainForm.TrendRatio.ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                                            int Pctg = Convert.ToInt32(RatioExtractor[1]); //Convert.ToInt32(tbSideBandPercentage.Text.ToString());
                                            double LowerLimit = ptNewPoint.GetX() - (ptNewPoint.GetX() * 1 / Pctg);
                                            double UpperLimit = ptNewPoint.GetX() + (ptNewPoint.GetX() * 1 / Pctg);

                                            
                                            Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[0] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);

                                            ChartText CurrentLabel = new ChartText(pTransform1, theFont, ptNewPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            if (_ShowCursorVal) 
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[0] = CurrentLabel;

                                            _DataGridView.Rows.Add(3);
                                            _DataGridView[0, 0].Value = ptNewPoint.GetX().ToString();
                                            _DataGridView[1, 0].Value = Convert.ToString(Math.Round(ptNewPoint.GetY(), 5));

                                            int MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                                            if (MainIndex == -1)
                                            {
                                                if (LowerLimit >= Dataset1.XData[0])
                                                {
                                                    LowerLimit = FindNearest(Dataset1.XData.GetDataBuffer(), LowerLimit);
                                                    MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                                                }
                                            }

                                            m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, LowerLimit, Dataset1.YData[MainIndex], 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[1] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);

                                            CurrentLabel = new ChartText(pTransform1, theFont, LowerLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(Dataset1.YData[MainIndex]), 5)) + YLabel, LowerLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            if (_ShowCursorVal) 
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[1] = CurrentLabel;

                                            _DataGridView[0, 1].Value = LowerLimit.ToString();
                                            _DataGridView[1, 1].Value = Convert.ToString(Math.Round(Dataset1.YData[MainIndex], 5));

                                            MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                                            if (MainIndex == -1)
                                            {
                                                if (UpperLimit <= Dataset1.XData[Dataset1.XData.Length - 1])
                                                {
                                                    UpperLimit = FindNearest(Dataset1.XData.GetDataBuffer(), UpperLimit);
                                                    MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                                                }
                                            }
                                            m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, UpperLimit, Dataset1.YData[MainIndex], 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[2] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);

                                            CurrentLabel = new ChartText(pTransform1, theFont, UpperLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(Dataset1.YData[MainIndex]), 5)) + YLabel, UpperLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            if (_ShowCursorVal) 
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[2] = CurrentLabel;

                                            _DataGridView[0, 2].Value = UpperLimit.ToString();
                                            _DataGridView[1, 2].Value = Convert.ToString(Math.Round(Dataset1.YData[MainIndex], 5));
                                            _DataGridView.Refresh();
                                            break;
                                        }
                                    case "SideBandTrend":
                                        {
                                            arrmarkerCursor = new Marker[3];
                                            arrChartTextCursor = new ChartText[3];
                                            double TrendValue = 10;
                                            double TrendFreq = 100;
                                            double iConstSBTrendFreq = 0;
                                            if (objTrend != null)
                                            {
                                                TrendValue = Convert.ToDouble(objTrend._Value.ToString());
                                                TrendFreq = objTrend._Freq;
                                            }

                                            iConstSBTrendFreq = (TrendFreq * TrendValue) / 100;
                                            
                                            double LowerLimit = ptNewPoint.GetX() - iConstSBTrendFreq;
                                            double UpperLimit = ptNewPoint.GetX() + iConstSBTrendFreq;

                                            
                                            Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[0] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);

                                            ChartText CurrentLabel = new ChartText(pTransform1, theFont, ptNewPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            if (_ShowCursorVal) 
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[0] = CurrentLabel;

                                            _DataGridView.Rows.Add(1);
                                            _DataGridView[0, _DataGridView.Rows.Count - 2].Value = ptNewPoint.GetX().ToString();
                                            _DataGridView[1, _DataGridView.Rows.Count - 2].Value = Convert.ToString(Math.Round(ptNewPoint.GetY(), 5));

                                            int MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                                            if (MainIndex == -1)
                                            {
                                                if (LowerLimit >= Dataset1.XData[0])
                                                {
                                                    LowerLimit = FindNearest(Dataset1.XData.GetDataBuffer(), LowerLimit);
                                                    MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                                                }
                                            }

                                            m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, LowerLimit, Dataset1.YData[MainIndex], 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[1] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);

                                            CurrentLabel = new ChartText(pTransform1, theFont, LowerLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(Dataset1.YData[MainIndex]), 5)) + YLabel, LowerLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            if (_ShowCursorVal) 
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[1] = CurrentLabel;

                                            _DataGridView.Rows.Add(1);
                                            _DataGridView[0, _DataGridView.Rows.Count - 2].Value = LowerLimit.ToString();
                                            _DataGridView[1, _DataGridView.Rows.Count - 2].Value = Convert.ToString(Math.Round(Dataset1.YData[MainIndex], 5));

                                            MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                                            if (MainIndex == -1)
                                            {
                                                if (UpperLimit <= Dataset1.XData[Dataset1.XData.Length - 1])
                                                {
                                                    UpperLimit = FindNearest(Dataset1.XData.GetDataBuffer(), UpperLimit);
                                                    MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                                                }
                                            }

                                            m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, UpperLimit, Dataset1.YData[MainIndex], 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[2] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);

                                            CurrentLabel = new ChartText(pTransform1, theFont, UpperLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(Dataset1.YData[MainIndex]), 5)) + YLabel, UpperLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            if (_ShowCursorVal) 
                                            {
                                                chartVu.AddChartObject(CurrentLabel);
                                            }
                                            arrChartTextCursor[2] = CurrentLabel;

                                            _DataGridView.Rows.Add(1);
                                            _DataGridView[0, _DataGridView.Rows.Count - 2].Value = UpperLimit.ToString();
                                            _DataGridView[1, _DataGridView.Rows.Count - 2].Value = Convert.ToString(Math.Round(Dataset1.YData[MainIndex], 5));
                                            _DataGridView.Refresh();
                                            break;
                                        }
                                }
                                if (_IsBearingFF)
                                {
                                    MainForm.callBFF();
                                }
                                if (SelectedCursor != "Refrence Cursor")
                                {
                                    if (m_objMarker != null)
                                    {
                                        chartVu.UpdateDraw();
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        if (SelectBandTrend)
                        {
                            arrmarkerCursor = new Marker[1];
                            Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                            m_objMarker1.SetColor(_MainCursorColor);
                            arrmarkerCursor[0] = m_objMarker1;
                            chartVu.AddChartObject(m_objMarker1);
                            chartVu.UpdateDraw();

                            objTrend.FreqVal = ptNewPoint.GetX().ToString();
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        internal bool AreaGraph()
        {
            bool bToReturn = false;
            try
            {                
                {
                    if (m_objClickedPlot != null)
                    {
                        m_objClickedPlot.ChartObjAttributes.SetFillFlag(_AreaFill);
                        chartVu.UpdateDraw();
                        bToReturn = true;
                    }

                }
            }
            catch (Exception ex)
            {
            }
            return bToReturn;
        }
        internal bool DrawFaultFrequencies(bool p, string[] Frequencies, DataGridView _Datagrid)
        {
            arrmarkerCursor = new Marker[1];
            arrChartTextCursor = new ChartText[1];
            bool bToReturn = false;
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            NearestPointData objSecondNearestPoint = null;
            SimpleDataset Dataset1 = null;            
            try
            {
                if (p)
                {
                    _Datagrid.Rows.Clear();
                    if (arrmarker != null)
                    {
                        for (int i1 = 0; i1 < arrmarker.Length; i1++)
                        {
                            chartVu.DeleteChartObject(arrmarker[i1]);
                            chartVu.DeleteChartObject(m_objDataCursor);
                        }
                    }
                    arrmarker = new Marker[0];
                    if (arrChartText != null)
                    {
                        for (int i1 = 0; i1 < arrChartText.Length; i1++)
                        {
                            chartVu.DeleteChartObject(arrChartText[i1]);
                        }
                    }
                    arrChartText = new ChartText[0];
                    for (i = 0; i < Frequencies.Length; i++)
                    {
                        string[] ExtractFreqSingle = Frequencies[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                        double Comparator = Convert.ToDouble(ExtractFreqSingle[1]);
                        if (Comparator.ToString() == "NaN")
                        {
                            break;
                        }
                        if (_XLabel == "CPM")
                        {
                            Comparator = Comparator * 60;
                        }
                        if (m_objClickedPlot != null)
                        {
                            Dataset1 = m_objClickedPlot.DisplayDataset;
                            int MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == Comparator; });
                            if (MainIndex == -1)
                            {
                                if (Comparator <= Dataset1.XData[Dataset1.XData.Length - 1])
                                {
                                    Comparator = FindNearest(Dataset1.XData.GetDataBuffer(), Comparator);
                                    MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == Comparator; });
                                }
                            }

                            nearestPointObj1 = new NearestPointData();
                            objSecondNearestPoint = new NearestPointData();
                            textCoordsFont = new Font("Arial", 8, FontStyle.Regular);

                            Font theLabelFont = new Font("Arial", 8, FontStyle.Regular);
                            Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, Dataset1.XData[MainIndex], Dataset1.YData[MainIndex], 8, 1);
                            m_objMarker1.LineStyle = DashStyle.DashDotDot;

                            if (MainIndex != -1)
                            {

                                Array.Resize(ref arrmarker, arrmarker.Length + 1);
                                arrmarker[arrmarker.Length - 1] = m_objMarker1;

                                m_objMarker1.FillColor = Color.DarkCyan;
                                m_objMarker1.SetColor(Color.DarkCyan);


                                chartVu.AddChartObject(m_objMarker1);
                                ChartText CurrentLabel = new ChartText(pTransform1, theLabelFont, ExtractFreqSingle[0].ToString() + "->" + Convert.ToString(Math.Round(Dataset1.XData[MainIndex], 5)) + _XLabel + "/" + Convert.ToString(Math.Round(Dataset1.YData[MainIndex], 5)) + _YLabel, Dataset1.XData[MainIndex], pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                CurrentLabel.SetColor(Color.Black);
                                chartVu.AddChartObject(CurrentLabel);

                                Array.Resize(ref arrChartText, arrChartText.Length + 1);
                                arrChartText[arrChartText.Length - 1] = CurrentLabel;

                                arrmarkerCursor[0] = arrmarker[0];
                                arrChartTextCursor[0] = CurrentLabel;


                                _Datagrid.Rows.Add(1);
                                _Datagrid.Rows[_Datagrid.Rows.Count - 2].Cells[0].Value = ExtractFreqSingle[0].ToString();
                                _Datagrid.Rows[_Datagrid.Rows.Count - 2].Cells[1].Value = Convert.ToString(Math.Round(Dataset1.XData[MainIndex], 5));
                                _Datagrid.Rows[_Datagrid.Rows.Count - 2].Cells[2].Value = Convert.ToString(Math.Round(Dataset1.YData[MainIndex], 5));
                                
                                try
                                {
                                    _MainForm._ExactBearingFF[i] = Convert.ToDouble(_Datagrid.Rows[_Datagrid.Rows.Count - 2].Cells[1].Value.ToString());
                                }
                                catch (Exception ex)
                                {
                                }
                                bToReturn = true;
                            }

                            chartVu.UpdateDraw();
                        }
                    }
                }
                else
                {
                    if (arrmarker != null)
                    {
                        for (int i1 = 0; i1 < arrmarker.Length; i1++)
                        {
                            chartVu.DeleteChartObject(arrmarker[i1]);
                            chartVu.DeleteChartObject(m_objDataCursor);
                        }
                    }
                    if (arrChartText != null)
                    {
                        for (int i1 = 0; i1 < arrChartText.Length; i1++)
                        {
                            chartVu.DeleteChartObject(arrChartText[i1]);
                        }
                    }
                    chartVu.UpdateDraw();
                }
            }
            catch (Exception ex)
            {
            }
            return bToReturn;
        }



        internal ChartView DrawFaultFrequencies2(bool p, string[] Frequencies, ChartView PointCv)
        {
            xxz[0] = 0;
            xxz[1] = 0;
            xxz[2] = 0;
            xxz[3] = 0;
            xxz[4] = 0;

            yyz[0] = 0;
            yyz[1] = 0;
            yyz[2] = 0;
            yyz[3] = 0;
            yyz[4] = 0;

            bool bToReturn = false;
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            NearestPointData objSecondNearestPoint = null;
            SimpleDataset Dataset1 = null;
            try
            {
                if (p)
                {
                    
                    if (arrmarker != null)
                    {
                        for (int i1 = 0; i1 < arrmarker.Length; i1++)
                        {
                            PointCv.DeleteChartObject(arrmarker[i1]);
                            PointCv.DeleteChartObject(m_objDataCursor);
                        }
                    }
                    arrmarker = new Marker[0];
                    if (arrChartText != null)
                    {
                        for (int i1 = 0; i1 < arrChartText.Length; i1++)
                        {
                            PointCv.DeleteChartObject(arrChartText[i1]);
                        }
                    }
                    arrChartText = new ChartText[0];
                    for (i = 0; i < Frequencies.Length; i++)
                    {
                        string[] ExtractFreqSingle = Frequencies[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                        double Comparator = Convert.ToDouble(ExtractFreqSingle[1]);
                        if (Comparator.ToString() == "NaN")
                        {
                            break;
                        }
                        if (_XLabel == "CPM")
                        {
                            Comparator = Comparator * 60;
                        }
                        if (m_objClickedPlot != null)
                        {

                            Dataset1 = m_objClickedPlot.DisplayDataset;
                            int MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == Comparator; });
                            if (MainIndex == -1)
                            {
                                if (Comparator <= Dataset1.XData[Dataset1.XData.Length - 1])
                                {
                                    Comparator = FindNearest(Dataset1.XData.GetDataBuffer(), Comparator);
                                    MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == Comparator; });
                                }
                            }

                            nearestPointObj1 = new NearestPointData();
                            objSecondNearestPoint = new NearestPointData();
                            textCoordsFont = new Font("Arial", 8, FontStyle.Regular);

                            Font theLabelFont = new Font("Arial", 8, FontStyle.Regular);
                            Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, Dataset1.XData[MainIndex], Dataset1.YData[MainIndex], 8, 1);
                            xxz[i] = Convert.ToDouble(Dataset1.XData[MainIndex]);
                            yyz[i] = Convert.ToDouble(Dataset1.YData[MainIndex]);
                            m_objMarker1.LineStyle = DashStyle.DashDotDot;

                            if (MainIndex != -1)
                            {

                                Array.Resize(ref arrmarker, arrmarker.Length + 1);
                                arrmarker[arrmarker.Length - 1] = m_objMarker1;

                                m_objMarker1.FillColor = Color.DarkCyan;
                                m_objMarker1.SetColor(Color.DarkCyan);


                                PointCv.AddChartObject(m_objMarker1);
                                ChartText CurrentLabel = new ChartText(pTransform1, theLabelFont, ExtractFreqSingle[0].ToString() + " -> " + Convert.ToString(Math.Round(Dataset1.XData[MainIndex], 5)) + _XLabel + " / " + Convert.ToString(Math.Round(Dataset1.YData[MainIndex], 5)) + _YLabel, Dataset1.XData[MainIndex], pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                CurrentLabel.SetColor(Color.Black);
                                PointCv.AddChartObject(CurrentLabel);

                                Array.Resize(ref arrChartText, arrChartText.Length + 1);
                                arrChartText[arrChartText.Length - 1] = CurrentLabel;


                               
                                try
                                {
                                    _MainForm._ExactBearingFF[i] = Convert.ToDouble(Math.Round(Dataset1.XData[MainIndex], 5));
                                }
                                catch (Exception ex)
                                {
                                }
                                bToReturn = true;
                            }

                            chartVu.UpdateDraw();
                        }
                    }
                }
                else
                {
                    if (arrmarker != null)
                    {
                        for (int i1 = 0; i1 < arrmarker.Length; i1++)
                        {
                            PointCv.DeleteChartObject(arrmarker[i1]);
                            PointCv.DeleteChartObject(m_objDataCursor);
                        }
                    }
                    if (arrChartText != null)
                    {
                        for (int i1 = 0; i1 < arrChartText.Length; i1++)
                        {
                            PointCv.DeleteChartObject(arrChartText[i1]);
                        }
                    }
                    PointCv.UpdateDraw();
                }
            }
            catch (Exception ex)
            {
            }
            return PointCv;
        }



        public double[] xx1
        {
            get
            {
                return xxz;
            }
        }

        public double[] yy1
        {
            get
            {
                return yyz;
            }
        }



        internal bool DrawBandRegion(string[] BandData, DataGridViewX dataGridView1, bool IsBandAreaPlot)
        {
            bool bToReturn = false;
            try
            {
                if (IsBandAreaPlot)
                {
                    dataGridView1.Rows.Clear();
                    double xx = 0;
                    double yy = 0;
                    double ww = 0;
                    double hh = 0;
                    double REDxx = 0;
                    double REDyy = 0;
                    double REDww = 0;
                    double REDhh = 0;
                    arrChartShape = new ChartShape[0];
                    arrChartShape1 = new ChartShape[0];
                    Color alphaColor = Color.FromArgb(100, Color.Yellow);
                    ChartAttribute attrib2 = new ChartAttribute(alphaColor, 1, DashStyle.Solid, alphaColor);
                    attrib2.SetFillFlag(true);
                    Color alphaRedColor = Color.FromArgb(100, Color.Red);
                    ChartAttribute attribRed = new ChartAttribute(alphaRedColor, 1, DashStyle.Solid, alphaRedColor);
                    attribRed.SetFillFlag(true);
                    OriginalYMaxscale = pTransform1.ScaleMaxY;
                    for (int i = 0; i < BandData.Length; i++)
                    {


                        string[] splittedBandData = BandData[i].ToString().Split(new string[] { "!", "@" }, StringSplitOptions.RemoveEmptyEntries);

                        double sp0 = Convert.ToDouble(splittedBandData[0].ToString());
                        double sp1 = Convert.ToDouble(splittedBandData[1].ToString());
                        double sp2 = Convert.ToDouble(splittedBandData[2].ToString());
                        if (_XLabel == "CPM")
                        {
                            sp0 = sp0 * 60;
                        }
                        
                        {
                            xx += ww;
                        }
                        ww = sp0 - xx;
                        yy = sp2;
                        hh = sp1 - yy;
                        if (pTransform1.ScaleMaxY < (yy + hh))
                        {
                            pTransform1.SetScaleY(0, (yy + hh));
                            pTransform1.YScale.SetRangeFromStop(yy + hh);
                            chartVu.DeleteChartObject(yAxis2);
                            chartVu.DeleteChartObject(xgrid2);
                            chartVu.DeleteChartObject(ygrid2);
                            chartVu.DeleteChartObject(yAxisLab2);


                            yAxis2 = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                            yAxis2.SetColor(_AxisColor);
                            chartVu.AddChartObject(yAxis2);



                            xgrid2 = new Grid(xAxis2, yAxis2, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                            xgrid2.SetColor(_AxisColor);
                            chartVu.AddChartObject(xgrid2);

                            ygrid2 = new Grid(xAxis2, yAxis2, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                            ygrid2.SetColor(_AxisColor);
                            chartVu.AddChartObject(ygrid2);

                            yAxisLab2 = new NumericAxisLabels(yAxis2);
                            yAxisLab2.SetColor(_AxisColor);
                            chartVu.AddChartObject(yAxisLab2);

                        }
                        Rectangle2D linearRegionRect = new Rectangle2D(xx, yy, ww, hh);
                        GraphicsPath rectpath = new GraphicsPath();
                        rectpath.AddRectangle(linearRegionRect.GetRectangleF());
                        ChartShape linearRegionShape = new ChartShape(pTransform1, rectpath,
                            ChartObj.PHYS_POS, 0.0, 0.0, ChartObj.PHYS_POS, 0);
                        linearRegionShape.SetChartObjAttributes(attrib2);
                        chartVu.AddChartObject(linearRegionShape);
                        Array.Resize(ref arrChartShape, arrChartShape.Length + 1);
                        arrChartShape[arrChartShape.Length - 1] = linearRegionShape;

                        REDxx = xx;
                        REDyy = yy + hh;
                        REDww = ww;
                        REDhh = pTransform1.ScaleMaxY - REDyy;
                        if (REDhh > 0)
                        {
                            linearRegionRect = new Rectangle2D(REDxx, REDyy, REDww, REDhh);
                            rectpath = new GraphicsPath();
                            rectpath.AddRectangle(linearRegionRect.GetRectangleF());
                            linearRegionShape = new ChartShape(pTransform1, rectpath,
                                ChartObj.PHYS_POS, 0.0, 0.0, ChartObj.PHYS_POS, 0);
                            linearRegionShape.SetChartObjAttributes(attribRed);
                            chartVu.AddChartObject(linearRegionShape);
                            Array.Resize(ref arrChartShape1, arrChartShape1.Length + 1);
                            arrChartShape1[arrChartShape1.Length - 1] = linearRegionShape;
                        }
                        chartVu.UpdateDraw();
                        bToReturn = true;
                    }
                }
                else
                {
                    if (pTransform1.ScaleMaxY != OriginalYMaxscale)
                    {
                        pTransform1.SetScaleY(0, OriginalYMaxscale);
                        pTransform1.YScale.SetRangeFromStop(OriginalYMaxscale);

                        chartVu.DeleteChartObject(yAxis2);
                        chartVu.DeleteChartObject(yAxisLab2);

                        yAxis2 = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                        yAxis2.SetColor(_AxisColor);
                        chartVu.AddChartObject(yAxis2);



                        xgrid2 = new Grid(xAxis2, yAxis2, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                        xgrid2.SetColor(_AxisColor);
                        chartVu.AddChartObject(xgrid2);

                        ygrid2 = new Grid(xAxis2, yAxis2, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                        ygrid2.SetColor(_AxisColor);
                        chartVu.AddChartObject(ygrid2);


                        yAxisLab2 = new NumericAxisLabels(yAxis2);
                        yAxisLab2.SetColor(_AxisColor);

                        chartVu.AddChartObject(yAxisLab2);
                    }
                    if (arrChartShape != null)
                    {
                        for (int i1 = 0; i1 < arrChartShape.Length; i1++)
                        {
                            chartVu.DeleteChartObject(arrChartShape[i1]);
                        }
                    }
                    if (arrChartShape1 != null)
                    {
                        for (int i1 = 0; i1 < arrChartShape1.Length; i1++)
                        {
                            chartVu.DeleteChartObject(arrChartShape1[i1]);
                        }
                    }
                    chartVu.UpdateDraw();
                }

            }
            catch (Exception ex)
            {

            }
            return bToReturn;
        }
        
        Marker[] arrmarkerhar = new Marker[0];
        public void deletemarker()
        {
            try
            {
                if (arrmarkerhar != null)
                {
                    for (int i1 = 0; i1 < arrmarkerhar.Length; i1++)
                    {
                        chartVu.DeleteChartObject(arrmarkerhar[i1]);
                        chartVu.DeleteChartObject(m_objDataCursor);
                    }
                }
                if (arrChartTexthar != null)
                {
                    for (int i1 = 0; i1 < arrChartTexthar.Length; i1++)
                    {
                        chartVu.DeleteChartObject(arrChartTexthar[i1]);
                    }
                }
                chartVu.UpdateDraw();
            }
            catch { }
        }

        internal bool DrawRPMmarkers(bool p, double FinalFreq, DataGridView _Datagrid, int CountForRpm)
        {
            int markerCount = (int)(Convert.ToDouble(PublicClass.chartscale) / FinalFreq);
            arrmarkerCursor = new Marker[markerCount];
            arrChartTextCursor = new ChartText[markerCount];
            bool bToReturn = false;
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            NearestPointData objSecondNearestPoint = null;
            SimpleDataset Dataset1 = null;
            int PrvsMainIndex = 0;
            try
            {
                if (p)
                {
                    _Datagrid.Rows.Clear();
                    if (arrmarker != null)
                    {
                        for (int i1 = 0; i1 < arrmarker.Length; i1++)
                        {
                            chartVu.DeleteChartObject(arrmarker[i1]);
                            chartVu.DeleteChartObject(m_objDataCursor);
                        }
                    }
                    arrmarker = new Marker[CountForRpm];
                    if (arrChartText != null)
                    {
                        for (int i1 = 0; i1 < arrChartText.Length; i1++)
                        {
                            chartVu.DeleteChartObject(arrChartText[i1]);
                        }
                    }
                    arrChartText = new ChartText[0];

                    if (m_objClickedPlot != null)
                    {
                        Dataset1 = m_objClickedPlot.DisplayDataset;

                        for (int i = 0; i < CountForRpm; i++)
                        {
                            double FreqToCalc = FinalFreq * (1 + i);
                            if (_XLabel == "CPM")
                            {
                                FreqToCalc = FreqToCalc * 60;
                            }
                            if (FreqToCalc > (double)Dataset1.XData[Dataset1.XData.Length - 1])
                            {
                                break;
                            }
                            int MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == FreqToCalc; });

                            if (MainIndex == -1)
                            {
                                if (FreqToCalc <= Dataset1.XData[Dataset1.XData.Length - 1])
                                {
                                    FreqToCalc = FindNearest(Dataset1.XData.GetDataBuffer(), FreqToCalc);
                                    MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == FreqToCalc; });
                                }
                            }
                            nearestPointObj1 = new NearestPointData();
                            objSecondNearestPoint = new NearestPointData();
                            textCoordsFont = new Font("Arial", 8, FontStyle.Regular);
                           
                            if (PrvsMainIndex != MainIndex)
                            {
                                Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, Dataset1.XData[MainIndex], Dataset1.YData[MainIndex], 8, 1);
                                arrmarker[i] = m_objMarker1;
                                m_objMarker1.LineStyle = DashStyle.DashDot;
                                m_objMarker1.FillColor = Color.DarkKhaki;
                                m_objMarker1.SetColor(Color.DarkKhaki);
                                chartVu.AddChartObject(m_objMarker1);

                                Font theLabelFont = new Font("Arial", 8, FontStyle.Regular);
                                ChartText CurrentLabel = new ChartText(pTransform1, theLabelFont, Convert.ToString(i + 1) + "x RPM " + Dataset1.YData[MainIndex].ToString(), Dataset1.XData[MainIndex], pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_MIN, ChartObj.JUSTIFY_MIN, 270);
                                CurrentLabel.SetColor(Color.Black);
                                chartVu.AddChartObject(CurrentLabel);
                                Array.Resize(ref arrChartText, arrChartText.Length + 1);
                                arrChartText[arrChartText.Length - 1] = CurrentLabel;
                                                               

                                arrmarkerCursor[i] = m_objMarker1;
                                arrChartTextCursor[i] = CurrentLabel;

                                _Datagrid.Rows.Add(1);
                                _Datagrid.Rows[_Datagrid.Rows.Count - 2].Cells[0].Value = Convert.ToString(i + 1) + "x RPM";
                                _Datagrid.Rows[_Datagrid.Rows.Count - 2].Cells[1].Value = Convert.ToString(Math.Round(Dataset1.XData[MainIndex], 5));
                                _Datagrid.Rows[_Datagrid.Rows.Count - 2].Cells[2].Value = Convert.ToString(Math.Round(Dataset1.YData[MainIndex], 5));
                                PrvsMainIndex = MainIndex;
                                
                               
                            }
                            else
                                break;
                            bToReturn = true;
                            chartVu.UpdateDraw();
                        }
                    }
                }
                else
                {
                    if (arrmarker != null)
                    {
                        for (int i1 = 0; i1 < arrmarker.Length; i1++)
                        {
                            chartVu.DeleteChartObject(arrmarker[i1]);
                            chartVu.DeleteChartObject(m_objDataCursor);
                        }
                    }


                    if (arrChartText != null)
                    {
                        for (int i1 = 0; i1 < arrChartText.Length; i1++)
                        {
                            chartVu.DeleteChartObject(arrChartText[i1]);
                        }
                    }
                    chartVu.UpdateDraw();
                }
            }
            catch (Exception ex)
            {
            }
            return bToReturn;
        }


        internal ChartView DrawMarkers(ChartView Chart,int[] Freq, string multireport)
        {
            xxz[0] = 0;
            xxz[1] = 0;
            xxz[2] = 0;
            xxz[3] = 0;
            xxz[4] = 0;
            xxz[5] = 0;
            xxz[6] = 0;
            xxz[7] = 0;
            xxz[8] = 0;
            xxz[9] = 0;

            yyz[0] = 0;
            yyz[1] = 0;
            yyz[2] = 0;
            yyz[3] = 0;
            yyz[4] = 0;
            yyz[5] = 0;
            yyz[6] = 0;
            yyz[7] = 0;
            yyz[8] = 0;
            yyz[9] = 0;


            arrmarkerCursor = new Marker[30];
            arrChartTextCursor = new ChartText[30];
            bool bToReturn = false;
            bool p = true;
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            NearestPointData objSecondNearestPoint = null;
            SimpleDataset Dataset1 = null;
            int PrvsMainIndex = 0;
            try
            {
                if (p)
                {
                    if (arrmarker != null)
                    {
                        for (int i1 = 0; i1 < arrmarker.Length; i1++)
                        {
                            Chart.DeleteChartObject(arrmarker[i1]);
                            Chart.DeleteChartObject(m_objDataCursor);
                        }
                    }
                    arrmarker = new Marker[10];
                    if (arrChartText != null)
                    {
                        for (int i1 = 0; i1 < arrChartText.Length; i1++)
                        {
                            Chart.DeleteChartObject(arrChartText[i1]);
                        }
                    }
                    arrChartText = new ChartText[0];
                    SimpleLinePlot[] AllPlots = GetAllPlots();
                    if (AllPlots.Length > 0)
                    {
                        Dataset1 = AllPlots[0].DisplayDataset;

                        if (multireport == "Multi Overall and Multi Graph(Highest Peaks Based)")
                        {
                            for (int i = 0; i < 10; i++)
                            {                               
                                if (Freq[i] != 0)
                                {
                                    nearestPointObj1 = new NearestPointData();
                                    objSecondNearestPoint = new NearestPointData();
                                    textCoordsFont = new Font("Arial", 8, FontStyle.Regular);
                                   
                                    Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, Dataset1.XData[Freq[i]], Dataset1.YData[Freq[i]], 8, 1);
                                    xxz[i] = Convert.ToDouble(Dataset1.XData[Freq[i]]);
                                    yyz[i] = Convert.ToDouble(Dataset1.YData[Freq[i]]);
                                    arrmarker[i] = m_objMarker1;
                                    m_objMarker1.LineStyle = DashStyle.DashDot;
                                    m_objMarker1.FillColor = Color.DarkKhaki;
                                    m_objMarker1.SetColor(Color.DarkKhaki);
                                    Chart.AddChartObject(m_objMarker1);

                                    Font theLabelFont = new Font("Arial", 8, FontStyle.Regular);
                                    ChartText CurrentLabel = new ChartText(pTransform1, theLabelFont, Convert.ToString(i + 1) + " X HP" + Dataset1.YData[Freq[i]].ToString(), Dataset1.XData[Freq[i]], pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_MIN, ChartObj.JUSTIFY_MIN, 270);
                                    CurrentLabel.SetColor(Color.Black);
                                    Chart.AddChartObject(CurrentLabel);
                                    Array.Resize(ref arrChartText, arrChartText.Length + 1);
                                    arrChartText[arrChartText.Length - 1] = CurrentLabel;

                                    arrmarkerCursor[i] = m_objMarker1;
                                    arrChartTextCursor[i] = CurrentLabel;

                                }
                                bToReturn = true;
                                Chart.UpdateDraw();
                            }
                        }
                        else if (multireport == "Multi Overall and Multi Graph(Dominant Frequency Based)")
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                nearestPointObj1 = new NearestPointData();
                                objSecondNearestPoint = new NearestPointData();
                                textCoordsFont = new Font("Arial", 8, FontStyle.Regular);
                               
                                if ((Freq[0] * (i + 1)) < Dataset1.XData.Length)
                                {
                                    Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, Dataset1.XData[Freq[0] * (i + 1)], Dataset1.YData[Freq[0] * (i + 1)], 8, 1);
                                    xxz[i] = Convert.ToDouble(Dataset1.XData[Freq[0] * (i + 1)]);
                                    yyz[i] = Convert.ToDouble(Dataset1.YData[Freq[0] * (i + 1)]);
                                    arrmarker[i] = m_objMarker1;
                                    m_objMarker1.LineStyle = DashStyle.DashDot;
                                    m_objMarker1.FillColor = Color.DarkKhaki;
                                    m_objMarker1.SetColor(Color.DarkKhaki);
                                    Chart.AddChartObject(m_objMarker1);

                                    Font theLabelFont = new Font("Arial", 8, FontStyle.Regular);
                                    ChartText CurrentLabel = new ChartText(pTransform1, theLabelFont, Convert.ToString(i + 1) + " X DF" + Dataset1.YData[Freq[0] * (i + 1)].ToString(), Dataset1.XData[Freq[0] * (i + 1)], pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_MIN, ChartObj.JUSTIFY_MIN, 270);
                                    CurrentLabel.SetColor(Color.Black);
                                    Chart.AddChartObject(CurrentLabel);
                                    Array.Resize(ref arrChartText, arrChartText.Length + 1);
                                    arrChartText[arrChartText.Length - 1] = CurrentLabel;
                                    bToReturn = true;
                                    Chart.UpdateDraw();
                                }
                                else
                                {
                                    bToReturn = true;
                                    Chart.UpdateDraw();
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (arrmarker != null)
                    {
                        for (int i1 = 0; i1 < arrmarker.Length; i1++)
                        {
                            Chart.DeleteChartObject(arrmarker[i1]);
                            Chart.DeleteChartObject(m_objDataCursor);
                        }
                    }
                    if (arrChartText != null)
                    {
                        for (int i1 = 0; i1 < arrChartText.Length; i1++)
                        {
                            Chart.DeleteChartObject(arrChartText[i1]);
                        }
                    }
                    Chart.UpdateDraw();
                }
            }
            catch (Exception ex)
            {
            }
            return Chart;
        }

        internal ChartView DrawMarkers(ChartView Chart, int[] Freq)
        {
            xxz[0] = 0;
            xxz[1] = 0;
            xxz[2] = 0;
            xxz[3] = 0;
            xxz[4] = 0;

            yyz[0] = 0;
            yyz[1] = 0;
            yyz[2] = 0;
            yyz[3] = 0;
            yyz[4] = 0;

            string[] FaultName = (string[])MainForm.FaultNameWithValue[1];

            bool bToReturn = false;
            bool p = true;
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            NearestPointData objSecondNearestPoint = null;
            SimpleDataset Dataset1 = null;
            int PrvsMainIndex = 0;
            try
            {
                if (p)
                {
                    if (arrmarker != null)
                    {
                        for (int i1 = 0; i1 < arrmarker.Length; i1++)
                        {
                            Chart.DeleteChartObject(arrmarker[i1]);
                            Chart.DeleteChartObject(m_objDataCursor);
                        }
                    }
                    arrmarker = new Marker[5];
                    if (arrChartText != null)
                    {
                        for (int i1 = 0; i1 < arrChartText.Length; i1++)
                        {
                            Chart.DeleteChartObject(arrChartText[i1]);
                        }
                    }
                    arrChartText = new ChartText[0];
                    SimpleLinePlot[] AllPlots = GetAllPlots();
                    if (AllPlots.Length > 0)
                    {
                        Dataset1 = AllPlots[0].DisplayDataset;
                        for (int i = 0; i < 10; i++)
                        {

                            if (Freq[i] != 0)
                            {
                                nearestPointObj1 = new NearestPointData();
                                objSecondNearestPoint = new NearestPointData();
                                textCoordsFont = new Font("Arial", 8, FontStyle.Regular);

                                Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, Dataset1.XData[Freq[i]], Dataset1.YData[Freq[i]], 8, 1);
                                xxz[i] = Convert.ToDouble(Dataset1.XData[Freq[i]]);
                                yyz[i] = Convert.ToDouble(Dataset1.YData[Freq[i]]);
                                arrmarker[i] = m_objMarker1;
                                m_objMarker1.LineStyle = DashStyle.Solid;
                                m_objMarker1.FillColor = _MainCursorColor;
                                m_objMarker1.SetColor(_MainCursorColor);
                                Chart.AddChartObject(m_objMarker1);

                                Font theLabelFont = new Font("Arial", 8, FontStyle.Regular);
                                ChartText CurrentLabel = new ChartText(pTransform1, theLabelFont, Convert.ToString("") + FaultName[i] + Dataset1.YData[Freq[i]].ToString(), Dataset1.XData[Freq[i]], pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_MIN, ChartObj.JUSTIFY_MIN, 270);
                                CurrentLabel.SetColor(Color.Black);
                                Chart.AddChartObject(CurrentLabel);
                                Array.Resize(ref arrChartText, arrChartText.Length + 1);
                                arrChartText[arrChartText.Length - 1] = CurrentLabel;

                            }
                            bToReturn = true;
                            Chart.UpdateDraw();
                        }
                    }
                }
                else
                {
                    if (arrmarker != null)
                    {
                        for (int i1 = 0; i1 < arrmarker.Length; i1++)
                        {
                            Chart.DeleteChartObject(arrmarker[i1]);
                            Chart.DeleteChartObject(m_objDataCursor);
                        }
                    }
                    if (arrChartText != null)
                    {
                        for (int i1 = 0; i1 < arrChartText.Length; i1++)
                        {
                            Chart.DeleteChartObject(arrChartText[i1]);
                        }
                    }
                    Chart.UpdateDraw();
                }
            }
            catch (Exception ex)
            {
            }
            return Chart;
        }
        internal void SideBandTrendClicked()
        {
            try
            {
                objTrend = new SideBandTrend();
                objTrend.MainForm = MainForm;
                objTrend.ShowDialog();
                MainForm.TrendValue = objTrend._Value.ToString() + "/" + objTrend._Freq.ToString();
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
                    zoomObj = new ChartZoom(chartVu, pTransform1, true);

                    zoomObj.SetButtonMask(MouseButtons.Left);
                    zoomObj.SetZoomYEnable(false);
                    zoomObj.SetZoomXEnable(true);

                    zoomObj.SetZoomXRoundMode(ChartObj.ZOOM);
                    zoomObj.SetZoomYRoundMode(ChartObj.ZOOM);
                    zoomObj.InternalZoomStackProcesssing = true;

                    zoomObj.SetEnable(true);

                    hScrollBar1.Visible = true;
                    hScrollBar1.Maximum = m_objClickedPlot.DisplayDataset.GetNumberDatapoints();

                    double diff = 0;
                  //  PublicClass.zoom = false;
                    diff = Math.Abs((double)(m_objClickedPlot.DisplayDataset.GetXDataValue(0) - m_objClickedPlot.DisplayDataset.GetXDataValue(1)));
                    double Index = zoomObj.ChartObjScale.GetScaleStartX() / diff;
                    PublicClass.XMin = Convert.ToString(zoomObj.ChartObjScale.ScaleMinX);
                    PublicClass.XMax = Convert.ToString(zoomObj.ChartObjScale.ScaleMaxX);
                    hScrollBar1.Value = (int)Index;

                }
                chartVu.SetCurrentMouseListener(zoomObj);
                chartVu.UpdateDraw();
            }
            catch (Exception ex)
            {
            }
        }
        internal void StopZoom()
        {
            try
            {                
                ChartZoom zoomObj1 = new ChartZoom(chartVu, pTransform1, true);
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
        internal void CopyGraph()
        {
            try
            {
                if (chartVu != null)
                {
                    BufferedImage objImage = new BufferedImage(chartVu);
                    Image GraphImage = (Image)objImage.GetBufferedImage();
                    Bitmap bm = new Bitmap(GraphImage);
                    Clipboard.SetImage((Image)GraphImage);
                    DialogResult Drslt = MessageBox.Show("Press Yes to Print Graph" + "\n" + "Press NO to Copy Graph", "Copy", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (Drslt == DialogResult.Yes)
                    {
                        try
                        {
                            PrintBitmap(bm);
                        }
                        catch { }
                    }
                    else
                    { MessageBoxEx.Show("Graph Copied on ClipBoard", "Graph"); }
                }
            }
            catch (Exception ex)
            {
            }
        }

        void PrintBitmap(Bitmap bm)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += (s, ev) =>
            {
                ev.Graphics.DrawImage(bm, Point.Empty); // adjust this to put the image elsewhere                
                ev.HasMorePages = false;
            };
            doc.DefaultPageSettings.Landscape = true;
            doc.Print();
        }

        private Color selectLineColor()
        {
            Color ReturnColor = Color.Black;
            try
            {
                int SelectedRowIndex = _MainForm._SelectedRowIndex;
                int colorIndex = SelectedRowIndex % 10;
                switch (colorIndex)
                {
                    case 0:
                        {
                            ReturnColor = Color.Black;
                            break;
                        }
                    case 1:
                        {
                            ReturnColor = Color.Blue;
                            break;
                        }
                    case 2:
                        {
                            ReturnColor = Color.Red;
                            break;
                        }
                    case 3:
                        {
                            ReturnColor = Color.Green;
                            break;
                        }
                    case 4:
                        {
                            ReturnColor = Color.Brown;
                            break;
                        }
                    case 5:
                        {
                            ReturnColor = Color.DarkCyan;
                            break;
                        }
                    case 6:
                        {
                            ReturnColor = Color.DarkOrange;
                            break;
                        }
                    case 7:
                        {
                            ReturnColor = Color.DeepPink;
                            break;
                        }
                    case 8:
                        {
                            ReturnColor = Color.DarkViolet;
                            break;
                        }
                    case 9:
                        {
                            ReturnColor = Color.DarkGray;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
            }
            return ReturnColor;
        }
       
        public SimpleLinePlot[] GetAllPlots()
        {
            SimpleLinePlot[] plotlist = new SimpleLinePlot[0];
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
                            GraphObj objObject = (GraphObj)arrObjects[iCtr];

                            Type obj = objObject.GetType();
                            if (obj.Name.ToString().Contains("SimpleLinePlot"))
                            {
                                SimpleLinePlot TestPlot = (SimpleLinePlot)objObject;
                                Array.Resize(ref plotlist, plotlist.Length + 1);
                                plotlist[plotlist.Length - 1] = TestPlot;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return plotlist;
        }
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
        private void CheckKeyDown(string Direction, string SelectedCursor)
        {
            try
            {
                switch (SelectedCursor)
                {
                    case "Single":
                        {
                            CheckKeyDownSingle(Direction);
                            break;
                        }
                    //case "Harmonic":
                    //    {
                    //        CheckKeyDownHarmonic(Direction);
                    //        break;
                    //    }
                    case "Single With Square":
                        {
                            CheckKeyDownSingleWithSquare(Direction);
                            break;
                        }
                    case "Cross Hair":
                        {
                            CheckKeyDownCrossHair(Direction);
                            break;
                        }
                    case "Sideband":
                        {
                            CheckKeyDownSideBandValue(Direction);
                            break;
                        }
                    case "SidebandRatio":
                        {
                            CheckKeyDownSideBandRatio(Direction);
                            break;
                        }
                    case "SideBandTrend":
                        {
                            CheckKeyDownSideBandTrend(Direction);
                            break;
                        }
                    case "PeekCursor":
                        {
                            CheckKeydownPeekCursor(Direction);
                            break;
                        }
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void CheckKeydownPeekCursor(string sType)
        {
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            Point2D ptNewPoint = null;
            Point2D ptLocation = null;
            Point2D ptPreviousPoint = null;
            GraphObj objLine = null;
            SimpleLinePlot objClickedLine = null;
            SimpleDataset objDataSet = null;
            SimpleDataset objPreviousPointDataSet = null;

            try
            {
                _DataGridView.Rows.Clear();
                ArrayList arrObjects = chartVu.GetChartObjectsArrayList();

                if (m_objNewPlot == null)
                {

                    foreach (GraphObj objObject in arrObjects)
                    {
                        int iType = objObject.ChartObjType;

                        objLine = objObject;
                        if (iType == 1)
                        {
                            objClickedLine = (SimpleLinePlot)objLine;
                            break;
                        }
                    }
                }
                else
                {
                    objClickedLine = m_objNewPlot;
                }

                if (arrmarkerCursor != null)
                {
                    for (int i = 0; i < arrmarkerCursor.Length; i++)
                    {
                        chartVu.DeleteChartObject(arrmarkerCursor[i]);
                        chartVu.DeleteChartObject(m_objDataCursor);
                    }
                }
                if (arrChartTextCursor != null)
                {
                    for (int i1 = 0; i1 < arrChartTextCursor.Length; i1++)
                    {
                        chartVu.DeleteChartObject(arrChartTextCursor[i1]);
                    }
                }
                arrChartTextCursor = new ChartText[1];
                if (sType == "Right")
                {
                    {
                        m_iCounter++;
                        if (m_objDataCursor != null)
                            chartVu.DeleteChartObject(m_objDataCursor);

                        objDataSet = objClickedLine.DisplayDataset;
                        int iNumber = objDataSet.GetNumberDatapoints();

                        double[] PeekXdata = FindAllPeaks((double[])objDataSet.XData.GetDataBuffer(), (double[])objDataSet.YData.GetDataBuffer());
                        if (m_iCounter >= PeekXdata.Length)
                            m_iCounter = PeekXdata.Length - 1;
                        Point2D objPoint = new Point2D(PeekXdata[m_iCounter], objDataSet.YData.GetDataBuffer()[m_iCounter]); //objDataSet.GetDataPoint(m_iCounter);
                        ptPreviousPoint = objDataSet.GetDataPoint(m_iCounter - 1);
                        nearestPointObj1 = new NearestPointData();
                        textCoordsFont = new Font("Arial", 8, FontStyle.Regular);
                        
                        ptNewPoint = nearestPointObj1.GetNearestPoint();


                        if (m_objMarker != null)
                        {
                            chartVu.DeleteChartObject(m_objMarker);
                            chartVu.DeleteChartObject(m_objNewMarker);
                            if (m_objDataCursor != null)
                                chartVu.DeleteChartObject(m_objDataCursor);

                        }




                        double harmonicX = objPoint.GetX();
                        arrmarkerCursor = new Marker[1];
                        arrChartTextCursor = new ChartText[1];
                        int MainIndex = Array.FindIndex(PeekXdata, delegate(double item) { return item == harmonicX; });
                        if (MainIndex == -1)
                        {
                            if (harmonicX <= PeekXdata[PeekXdata.Length - 1])
                            {
                                harmonicX = FindNearest(PeekXdata, harmonicX);
                                MainIndex = Array.FindIndex(PeekXdata, delegate(double item) { return item == harmonicX; });
                            }
                        }
                        m_objMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, harmonicX, objDataSet.YData.GetDataBuffer()[PeekIndex[MainIndex]], 8, 1);



                        m_objMarker.SetColor(_MainCursorColor);
                        arrmarkerCursor[0] = m_objMarker;
                        chartVu.AddChartObject(m_objMarker);
                        ChartText CurrentLabel = null;
                        _DataGridView.Rows.Add(1);
                        if (_MainForm._IsOverallTrend)
                        {
                        }
                        else
                        {
                            CurrentLabel = new ChartText(pTransform1, theFont, harmonicX.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objDataSet.YData.GetDataBuffer()[PeekIndex[MainIndex]]), 5)) + YLabel, harmonicX, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                            _DataGridView[0, 0].Value = harmonicX.ToString();
                        }
                        CurrentLabel.SetColor(_MainCursorColor);
                        if (_ShowCursorVal) 
                        {
                            chartVu.AddChartObject(CurrentLabel);
                        }
                        arrChartTextCursor[0] = CurrentLabel;



                        _DataGridView[1, 0].Value = Convert.ToString(Math.Round(Convert.ToDouble(objDataSet.YData.GetDataBuffer()[PeekIndex[MainIndex]]), 5));
                        _DataGridView.Refresh();
                    }
                }
                else if (sType == "Left")
                {
                    m_iCounter--;
                    if (m_iCounter < 0)
                        m_iCounter = 0;
                    objPreviousPointDataSet = objClickedLine.DisplayDataset;

                    if (m_objDataCursor != null)
                        chartVu.DeleteChartObject(m_objDataCursor);
                    
                    double[] PeekXdata = FindAllPeaks((double[])objPreviousPointDataSet.XData.GetDataBuffer(), (double[])objPreviousPointDataSet.YData.GetDataBuffer());

                    Point2D objPoint = new Point2D(PeekXdata[m_iCounter], objPreviousPointDataSet.YData.GetDataBuffer()[m_iCounter]); //objDataSet.GetDataPoint(m_iCounter);

                    ptPreviousPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter + 1);
                    nearestPointObj1 = new NearestPointData();
                    textCoordsFont = new Font("Arial", 8, FontStyle.Regular);

                    ptNewPoint = nearestPointObj1.GetNearestPoint();

                    if (m_objMarker != null)
                    {
                        chartVu.DeleteChartObject(m_objMarker);
                        chartVu.DeleteChartObject(m_objNewMarker);
                    }


                    double harmonicX = objPoint.GetX();
                    arrmarkerCursor = new Marker[1];
                    arrChartTextCursor = new ChartText[1];
                    int MainIndex = Array.FindIndex(PeekXdata, delegate(double item) { return item == harmonicX; });
                    if (MainIndex == -1)
                    {
                        if (harmonicX <= PeekXdata[PeekXdata.Length - 1])
                        {
                            harmonicX = FindNearest(PeekXdata, harmonicX);
                            MainIndex = Array.FindIndex(PeekXdata, delegate(double item) { return item == harmonicX; });
                        }
                    }
                    m_objMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, harmonicX, objPreviousPointDataSet.YData.GetDataBuffer()[PeekIndex[MainIndex]], 8, 1);



                    m_objMarker.SetColor(_MainCursorColor);
                    arrmarkerCursor[0] = m_objMarker;
                    chartVu.AddChartObject(m_objMarker);
                    ChartText CurrentLabel = null;
                    _DataGridView.Rows.Add(1);
                    if (_MainForm._IsOverallTrend)
                    {
                      
                    }
                    else
                    {
                        
                        CurrentLabel = new ChartText(pTransform1, theFont, harmonicX.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPreviousPointDataSet.YData.GetDataBuffer()[PeekIndex[MainIndex]]), 5)) + YLabel, harmonicX, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                        _DataGridView[0, 0].Value = harmonicX.ToString();
                    }
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[0] = CurrentLabel;



                    _DataGridView[1, 0].Value = Convert.ToString(Math.Round(Convert.ToDouble(objPreviousPointDataSet.YData.GetDataBuffer()[PeekIndex[MainIndex]]), 5));
                    _DataGridView.Refresh();
                    

                }
                arrmarkerCursor = new Marker[1];
                arrmarkerCursor[0] = m_objMarker;
                chartVu.UpdateDraw();
            }
            catch (Exception ex)
            {
                
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void CheckKeyDownSideBandTrend(string sType)
        {
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            Point2D ptNewPoint = null;
            Point2D ptLocation = null;
            Point2D ptPreviousPoint = null;
            GraphObj objLine = null;
            SimpleLinePlot objClickedLine = null;
            SimpleDataset objDataSet = null;
            SimpleDataset objPreviousPointDataSet = null;

            try
            {
                _DataGridView.Rows.Clear();
                
                ArrayList arrObjects = chartVu.GetChartObjectsArrayList();

                foreach (GraphObj objObject in arrObjects)
                {
                    int iType = objObject.ChartObjType;

                    objLine = objObject;
                    if (iType == 1)
                    {
                        objClickedLine = (SimpleLinePlot)objLine;
                        break;
                    }
                }
                if (arrmarkerCursor != null)
                {
                    for (int i = 0; i < arrmarkerCursor.Length; i++)
                    {
                        chartVu.DeleteChartObject(arrmarkerCursor[i]);
                        chartVu.DeleteChartObject(m_objDataCursor);
                    }
                }
                if (arrChartTextCursor != null)
                {
                    for (int i1 = 0; i1 < arrChartTextCursor.Length; i1++)
                    {
                        chartVu.DeleteChartObject(arrChartTextCursor[i1]);
                    }
                }
                arrChartTextCursor = new ChartText[1];
                if (sType == "Right")
                {

                    m_iCounter++;
                    if (m_objDataCursor != null)
                        chartVu.DeleteChartObject(m_objDataCursor);

                    objDataSet = objClickedLine.DisplayDataset;
                    int iNumber = objDataSet.GetNumberDatapoints();
                    if (m_iCounter >= iNumber)
                        m_iCounter = iNumber - 1;
                    Point2D objPoint = objDataSet.GetDataPoint(m_iCounter);
                    ptPreviousPoint = objDataSet.GetDataPoint(m_iCounter - 1);
                    nearestPointObj1 = new NearestPointData();
                    textCoordsFont = new Font("Arial", 8, FontStyle.Regular);
                    
                    ptNewPoint = objPoint;


                    if (m_objMarker != null)
                    {
                        chartVu.DeleteChartObject(m_objMarker);
                        chartVu.DeleteChartObject(m_objNewMarker);
                        if (m_objDataCursor != null)
                            chartVu.DeleteChartObject(m_objDataCursor);

                    }

                    arrmarkerCursor = new Marker[3];
                    arrChartTextCursor = new ChartText[3];
                    double TrendValue = 10;
                    double TrendFreq = 100;
                    double iConstSBTrendFreq = 0;
                    if (objTrend != null)
                    {
                        TrendValue = Convert.ToDouble(objTrend._Value.ToString());
                        TrendFreq = objTrend._Freq;
                    }
                    iConstSBTrendFreq = (TrendFreq * TrendValue) / 100;
                    double LowerLimit = ptNewPoint.GetX() - iConstSBTrendFreq;
                    double UpperLimit = ptNewPoint.GetX() + iConstSBTrendFreq;


                    
                    Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[0] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                    ChartText CurrentLabel = new ChartText(pTransform1, theFont, ptNewPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[0] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = ptNewPoint.GetX().ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = ptNewPoint.GetY().ToString();

                    int MainIndex = Array.FindIndex(objDataSet.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                    if (MainIndex == -1)
                    {
                        if (LowerLimit >= objDataSet.XData[0])
                        {
                            LowerLimit = FindNearest(objDataSet.XData.GetDataBuffer(), LowerLimit);
                            MainIndex = Array.FindIndex(objDataSet.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                        }
                    }

                    m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, LowerLimit, objDataSet.YData[MainIndex], 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[1] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                    CurrentLabel = new ChartText(pTransform1, theFont, LowerLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objDataSet.YData[MainIndex]), 5)) + YLabel, LowerLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[1] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = LowerLimit.ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = objDataSet.YData[MainIndex].ToString();

                    MainIndex = Array.FindIndex(objDataSet.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                    if (MainIndex == -1)
                    {
                        if (UpperLimit <= objDataSet.XData[objDataSet.XData.Length - 1])
                        {
                            UpperLimit = FindNearest(objDataSet.XData.GetDataBuffer(), UpperLimit);
                            MainIndex = Array.FindIndex(objDataSet.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                        }
                    }

                    m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, UpperLimit, objDataSet.YData[MainIndex], 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[2] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                    CurrentLabel = new ChartText(pTransform1, theFont, UpperLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objDataSet.YData[MainIndex]), 5)) + YLabel, UpperLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) //cursor position View on/off
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[2] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = UpperLimit.ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = objDataSet.YData[MainIndex].ToString();
                    _DataGridView.Refresh();

                }
                else if (sType == "Left")
                {
                    m_iCounter--;
                    if (m_iCounter < 0)
                        m_iCounter = 0;
                    objPreviousPointDataSet = objClickedLine.DisplayDataset;

                    if (m_objDataCursor != null)
                        chartVu.DeleteChartObject(m_objDataCursor);
                    Point2D objPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter);
                    ptPreviousPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter + 1);
                    nearestPointObj1 = new NearestPointData();
                    textCoordsFont = new Font("Arial", 8, FontStyle.Regular);

                    ptNewPoint = objPoint;

                    if (m_objMarker != null)
                    {
                        chartVu.DeleteChartObject(m_objMarker);
                        chartVu.DeleteChartObject(m_objNewMarker);
                    }

                    arrmarkerCursor = new Marker[3];
                    arrChartTextCursor = new ChartText[3];
                    double TrendValue = 10;
                    double TrendFreq = 100;
                    double iConstSBTrendFreq = 0;
                    if (objTrend != null)
                    {
                        TrendValue = Convert.ToDouble(objTrend._Value.ToString());
                        TrendFreq = objTrend._Freq;
                    }
                    iConstSBTrendFreq = (TrendFreq * TrendValue) / 100;
                    double LowerLimit = ptNewPoint.GetX() - iConstSBTrendFreq;
                    double UpperLimit = ptNewPoint.GetX() + iConstSBTrendFreq;

                    Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[0] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                    ChartText CurrentLabel = new ChartText(pTransform1, theFont, ptNewPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[0] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = ptNewPoint.GetX().ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = ptNewPoint.GetY().ToString();

                    int MainIndex = Array.FindIndex(objPreviousPointDataSet.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                    if (MainIndex == -1)
                    {
                        if (LowerLimit >= objPreviousPointDataSet.XData[0])
                        {
                            LowerLimit = FindNearest(objPreviousPointDataSet.XData.GetDataBuffer(), LowerLimit);
                            MainIndex = Array.FindIndex(objPreviousPointDataSet.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                        }
                    }

                    m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, LowerLimit, objPreviousPointDataSet.YData[MainIndex], 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[1] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                    CurrentLabel = new ChartText(pTransform1, theFont, LowerLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPreviousPointDataSet.YData[MainIndex]), 5)) + YLabel, LowerLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[1] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = LowerLimit.ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = objPreviousPointDataSet.YData[MainIndex].ToString();

                    MainIndex = Array.FindIndex(objPreviousPointDataSet.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                    if (MainIndex == -1)
                    {
                        if (UpperLimit <= objPreviousPointDataSet.XData[objPreviousPointDataSet.XData.Length - 1])
                        {
                            UpperLimit = FindNearest(objPreviousPointDataSet.XData.GetDataBuffer(), UpperLimit);
                            MainIndex = Array.FindIndex(objPreviousPointDataSet.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                        }
                    }

                    m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, UpperLimit, objPreviousPointDataSet.YData[MainIndex], 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[2] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                    CurrentLabel = new ChartText(pTransform1, theFont, UpperLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPreviousPointDataSet.YData[MainIndex]), 5)) + YLabel, UpperLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[2] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = UpperLimit.ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = objPreviousPointDataSet.YData[MainIndex].ToString();
                    _DataGridView.Refresh();

                }
            }
            catch (Exception ex)
            {
                
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }
        private void CheckKeyDownSideBandRatio(string sType)
        {
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            Point2D ptNewPoint = null;
            Point2D ptLocation = null;
            Point2D ptPreviousPoint = null;
            GraphObj objLine = null;
            SimpleLinePlot objClickedLine = null;
            SimpleDataset objDataSet = null;
            SimpleDataset objPreviousPointDataSet = null;

            try
            {
                _DataGridView.Rows.Clear();
                
                ArrayList arrObjects = chartVu.GetChartObjectsArrayList();

                foreach (GraphObj objObject in arrObjects)
                {
                    int iType = objObject.ChartObjType;

                    objLine = objObject;
                    if (iType == 1)
                    {
                        objClickedLine = (SimpleLinePlot)objLine;
                        break;
                    }
                }
                if (arrmarkerCursor != null)
                {
                    for (int i = 0; i < arrmarkerCursor.Length; i++)
                    {
                        chartVu.DeleteChartObject(arrmarkerCursor[i]);
                        chartVu.DeleteChartObject(m_objDataCursor);
                    }
                }
                if (arrChartTextCursor != null)
                {
                    for (int i1 = 0; i1 < arrChartTextCursor.Length; i1++)
                    {
                        chartVu.DeleteChartObject(arrChartTextCursor[i1]);
                    }
                }
                arrChartTextCursor = new ChartText[1];
                if (sType == "Right")
                {

                    m_iCounter++;
                    if (m_objDataCursor != null)
                        chartVu.DeleteChartObject(m_objDataCursor);

                    objDataSet = objClickedLine.DisplayDataset;
                    int iNumber = objDataSet.GetNumberDatapoints();
                    if (m_iCounter >= iNumber)
                        m_iCounter = iNumber - 1;
                    Point2D objPoint = objDataSet.GetDataPoint(m_iCounter);
                    ptPreviousPoint = objDataSet.GetDataPoint(m_iCounter - 1);
                    nearestPointObj1 = new NearestPointData();
                    textCoordsFont = new Font("Arial", 8, FontStyle.Regular);
                    
                    ptNewPoint = objPoint;


                    if (m_objMarker != null)
                    {
                        chartVu.DeleteChartObject(m_objMarker);
                        chartVu.DeleteChartObject(m_objNewMarker);
                        if (m_objDataCursor != null)
                            chartVu.DeleteChartObject(m_objDataCursor);

                    }




                    arrmarkerCursor = new Marker[3];
                    arrChartTextCursor = new ChartText[3];

                    string[] RatioExtractor = MainForm.TrendRatio.ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                    int Pctg = Convert.ToInt32(RatioExtractor[1]); 
                    double LowerLimit = ptNewPoint.GetX() - (ptNewPoint.GetX() * 1 / Pctg);
                    double UpperLimit = ptNewPoint.GetX() + (ptNewPoint.GetX() * 1 / Pctg);


                    
                    Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[0] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                    ChartText CurrentLabel = new ChartText(pTransform1, theFont, ptNewPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[0] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = ptNewPoint.GetX().ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = ptNewPoint.GetY().ToString();

                    int MainIndex = Array.FindIndex(objDataSet.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                    if (MainIndex == -1)
                    {
                        if (LowerLimit >= objDataSet.XData[0])
                        {
                            LowerLimit = FindNearest(objDataSet.XData.GetDataBuffer(), LowerLimit);
                            MainIndex = Array.FindIndex(objDataSet.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                        }
                    }

                    m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, LowerLimit, objDataSet.YData[MainIndex], 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[1] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                    CurrentLabel = new ChartText(pTransform1, theFont, LowerLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objDataSet.YData[MainIndex]), 5)) + YLabel, LowerLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[1] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = LowerLimit.ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = objDataSet.YData[MainIndex].ToString();

                    MainIndex = Array.FindIndex(objDataSet.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                    if (MainIndex == -1)
                    {
                        if (UpperLimit <= objDataSet.XData[objDataSet.XData.Length - 1])
                        {
                            UpperLimit = FindNearest(objDataSet.XData.GetDataBuffer(), UpperLimit);
                            MainIndex = Array.FindIndex(objDataSet.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                        }
                    }

                    m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, UpperLimit, objDataSet.YData[MainIndex], 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[2] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                    CurrentLabel = new ChartText(pTransform1, theFont, UpperLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objDataSet.YData[MainIndex]), 5)) + YLabel, UpperLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[2] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = UpperLimit.ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = objDataSet.YData[MainIndex].ToString();
                    _DataGridView.Refresh();


                }
                else if (sType == "Left")
                {
                    m_iCounter--;
                    if (m_iCounter < 0)
                        m_iCounter = 0;
                    objPreviousPointDataSet = objClickedLine.DisplayDataset;

                    if (m_objDataCursor != null)
                        chartVu.DeleteChartObject(m_objDataCursor);
                    Point2D objPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter);
                    ptPreviousPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter + 1);
                    nearestPointObj1 = new NearestPointData();
                    textCoordsFont = new Font("Arial", 8, FontStyle.Regular);

                    ptNewPoint = objPoint;

                    if (m_objMarker != null)
                    {
                        chartVu.DeleteChartObject(m_objMarker);
                        chartVu.DeleteChartObject(m_objNewMarker);
                    }



                    arrmarkerCursor = new Marker[3];
                    arrChartTextCursor = new ChartText[3];

                    string[] RatioExtractor = MainForm.TrendRatio.ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                    int Pctg = Convert.ToInt32(RatioExtractor[1]); 
                    double LowerLimit = ptNewPoint.GetX() - (ptNewPoint.GetX() * 1 / Pctg);
                    double UpperLimit = ptNewPoint.GetX() + (ptNewPoint.GetX() * 1 / Pctg);

                    Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[0] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                    ChartText CurrentLabel = new ChartText(pTransform1, theFont, ptNewPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[0] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = ptNewPoint.GetX().ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = ptNewPoint.GetY().ToString();

                    int MainIndex = Array.FindIndex(objPreviousPointDataSet.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                    if (MainIndex == -1)
                    {
                        if (LowerLimit >= objPreviousPointDataSet.XData[0])
                        {
                            LowerLimit = FindNearest(objPreviousPointDataSet.XData.GetDataBuffer(), LowerLimit);
                            MainIndex = Array.FindIndex(objPreviousPointDataSet.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                        }
                    }

                    m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, LowerLimit, objPreviousPointDataSet.YData[MainIndex], 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[1] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                    CurrentLabel = new ChartText(pTransform1, theFont, LowerLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPreviousPointDataSet.YData[MainIndex]), 5)) + YLabel, LowerLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[1] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = LowerLimit.ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = objPreviousPointDataSet.YData[MainIndex].ToString();

                    MainIndex = Array.FindIndex(objPreviousPointDataSet.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                    if (MainIndex == -1)
                    {
                        if (UpperLimit <= objPreviousPointDataSet.XData[objPreviousPointDataSet.XData.Length - 1])
                        {
                            UpperLimit = FindNearest(objPreviousPointDataSet.XData.GetDataBuffer(), UpperLimit);
                            MainIndex = Array.FindIndex(objPreviousPointDataSet.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                        }
                    }

                    m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, UpperLimit, objPreviousPointDataSet.YData[MainIndex], 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[2] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                    CurrentLabel = new ChartText(pTransform1, theFont, UpperLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPreviousPointDataSet.YData[MainIndex]), 5)) + YLabel, UpperLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[2] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = UpperLimit.ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = objPreviousPointDataSet.YData[MainIndex].ToString();
                    _DataGridView.Refresh();

                }
            }
            catch (Exception ex)
            {
                
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }
        private void CheckKeyDownSideBandValue(string sType)
        {
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            Point2D ptNewPoint = null;
            Point2D ptLocation = null;
            Point2D ptPreviousPoint = null;
            GraphObj objLine = null;
            SimpleLinePlot objClickedLine = null;
            SimpleDataset objDataSet = null;
            SimpleDataset objPreviousPointDataSet = null;

            try
            {
                _DataGridView.Rows.Clear();
                
                ArrayList arrObjects = chartVu.GetChartObjectsArrayList();

                foreach (GraphObj objObject in arrObjects)
                {
                    int iType = objObject.ChartObjType;

                    objLine = objObject;
                    if (iType == 1)
                    {
                        objClickedLine = (SimpleLinePlot)objLine;
                        break;
                    }
                }
                if (arrmarkerCursor != null)
                {
                    for (int i = 0; i < arrmarkerCursor.Length; i++)
                    {
                        chartVu.DeleteChartObject(arrmarkerCursor[i]);
                        chartVu.DeleteChartObject(m_objDataCursor);
                    }
                }
                if (arrChartTextCursor != null)
                {
                    for (int i1 = 0; i1 < arrChartTextCursor.Length; i1++)
                    {
                        chartVu.DeleteChartObject(arrChartTextCursor[i1]);
                    }
                }
                arrChartTextCursor = new ChartText[1];
                if (sType == "Right")
                {

                    m_iCounter++;
                    if (m_objDataCursor != null)
                        chartVu.DeleteChartObject(m_objDataCursor);

                    objDataSet = objClickedLine.DisplayDataset;
                    int iNumber = objDataSet.GetNumberDatapoints();
                    if (m_iCounter >= iNumber)
                        m_iCounter = iNumber - 1;
                    Point2D objPoint = objDataSet.GetDataPoint(m_iCounter);
                    ptPreviousPoint = objDataSet.GetDataPoint(m_iCounter - 1);
                    nearestPointObj1 = new NearestPointData();
                    textCoordsFont = new Font("Arial", 8, FontStyle.Regular);
                    
                    ptNewPoint = objPoint;


                    if (m_objMarker != null)
                    {
                        chartVu.DeleteChartObject(m_objMarker);
                        chartVu.DeleteChartObject(m_objNewMarker);
                        if (m_objDataCursor != null)
                            chartVu.DeleteChartObject(m_objDataCursor);

                    }




                    arrmarkerCursor = new Marker[3];
                    arrChartTextCursor = new ChartText[3];
                    string[] RatioExtractor = MainForm.TrendRatio.ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                    int Pctg = Convert.ToInt32(MainForm.SBValue.ToString()); 
                    double LowerLimit = ptNewPoint.GetX() - (ptNewPoint.GetX() * Pctg / 100);
                    double UpperLimit = ptNewPoint.GetX() + (ptNewPoint.GetX() * Pctg / 100);

                    int MainIndex = Array.FindIndex(objDataSet.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                    if (MainIndex == -1)
                    {
                        if (LowerLimit >= objDataSet.XData[0])
                        {
                            LowerLimit = FindNearest(objDataSet.XData.GetDataBuffer(), LowerLimit);
                            MainIndex = Array.FindIndex(objDataSet.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                        }
                    }

                    Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, LowerLimit, objDataSet.YData[MainIndex], 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[1] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                    ChartText CurrentLabel = new ChartText(pTransform1, theFont, LowerLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objDataSet.YData[MainIndex]), 5)) + YLabel, LowerLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal)
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[1] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = LowerLimit.ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = objDataSet.YData[MainIndex].ToString();





                    //-----------//
                     m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[0] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                     CurrentLabel = new ChartText(pTransform1, theFont, ptNewPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[0] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = ptNewPoint.GetX().ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = ptNewPoint.GetY().ToString();

                    //------///

                   

                    ////-------------//////


                    MainIndex = Array.FindIndex(objDataSet.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                    if (MainIndex == -1)
                    {
                        if (UpperLimit <= objDataSet.XData[objDataSet.XData.Length - 1])
                        {
                            UpperLimit = FindNearest(objDataSet.XData.GetDataBuffer(), UpperLimit);
                            MainIndex = Array.FindIndex(objDataSet.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                        }
                    }

                    m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, UpperLimit, objDataSet.YData[MainIndex], 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[2] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                    CurrentLabel = new ChartText(pTransform1, theFont, UpperLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objDataSet.YData[MainIndex]), 5)) + YLabel, UpperLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[2] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = UpperLimit.ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = objDataSet.YData[MainIndex].ToString();
                    _DataGridView.Refresh();


                }
                else if (sType == "Left")
                {
                    m_iCounter--;
                    if (m_iCounter < 0)
                        m_iCounter = 0;
                    objPreviousPointDataSet = objClickedLine.DisplayDataset;

                    if (m_objDataCursor != null)
                        chartVu.DeleteChartObject(m_objDataCursor);
                    Point2D objPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter);
                    ptPreviousPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter + 1);
                    nearestPointObj1 = new NearestPointData();
                    textCoordsFont = new Font("Arial", 8, FontStyle.Regular);

                    ptNewPoint = objPoint;

                    if (m_objMarker != null)
                    {
                        chartVu.DeleteChartObject(m_objMarker);
                        chartVu.DeleteChartObject(m_objNewMarker);
                    }



                    arrmarkerCursor = new Marker[3];
                    arrChartTextCursor = new ChartText[3];
                    string[] RatioExtractor = MainForm.TrendRatio.ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                    int Pctg = Convert.ToInt32(MainForm.SBValue.ToString()); //Convert.ToInt32(tbSideBandPercentage.Text.ToString());
                    double LowerLimit = ptNewPoint.GetX() - (ptNewPoint.GetX() * Pctg / 100);
                    double UpperLimit = ptNewPoint.GetX() + (ptNewPoint.GetX() * Pctg / 100);

                    
                    Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[0] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                    ChartText CurrentLabel = new ChartText(pTransform1, theFont, ptNewPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[0] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = ptNewPoint.GetX().ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = ptNewPoint.GetY().ToString();

                    int MainIndex = Array.FindIndex(objPreviousPointDataSet.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                    if (MainIndex == -1)
                    {
                        if (LowerLimit >= objPreviousPointDataSet.XData[0])
                        {
                            LowerLimit = FindNearest(objPreviousPointDataSet.XData.GetDataBuffer(), LowerLimit);
                            MainIndex = Array.FindIndex(objPreviousPointDataSet.XData.GetDataBuffer(), delegate(double item) { return item == LowerLimit; });
                        }
                    }

                    m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, LowerLimit, objPreviousPointDataSet.YData[MainIndex], 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[1] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                    CurrentLabel = new ChartText(pTransform1, theFont, LowerLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPreviousPointDataSet.YData[MainIndex]), 5)) + YLabel, LowerLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[1] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = LowerLimit.ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = objPreviousPointDataSet.YData[MainIndex].ToString();

                    MainIndex = Array.FindIndex(objPreviousPointDataSet.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                    if (MainIndex == -1)
                    {
                        if (UpperLimit <= objPreviousPointDataSet.XData[objPreviousPointDataSet.XData.Length - 1])
                        {
                            UpperLimit = FindNearest(objPreviousPointDataSet.XData.GetDataBuffer(), UpperLimit);
                            MainIndex = Array.FindIndex(objPreviousPointDataSet.XData.GetDataBuffer(), delegate(double item) { return item == UpperLimit; });
                        }
                    }

                    m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, UpperLimit, objPreviousPointDataSet.YData[MainIndex], 8, 1);
                    m_objMarker1.SetColor(_MainCursorColor);
                    arrmarkerCursor[2] = m_objMarker1;
                    chartVu.AddChartObject(m_objMarker1);

                    CurrentLabel = new ChartText(pTransform1, theFont, UpperLimit.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPreviousPointDataSet.YData[MainIndex]), 5)) + YLabel, UpperLimit, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[2] = CurrentLabel;

                    _DataGridView.Rows.Add(1);
                    _DataGridView[0, _DataGridView.Rows.Count - 2].Value = UpperLimit.ToString();
                    _DataGridView[1, _DataGridView.Rows.Count - 2].Value = objPreviousPointDataSet.YData[MainIndex].ToString();
                    _DataGridView.Refresh();

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }
        private void CheckKeyDownHarmonic(string sType)
        {
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            Point2D ptNewPoint = null;
            Point2D ptLocation = null;
            Point2D ptPreviousPoint = null;
            GraphObj objLine = null;
            SimpleLinePlot objClickedLine = null;
            SimpleDataset objDataSet = null;
            SimpleDataset objPreviousPointDataSet = null;

            try
            {
                _DataGridView.Rows.Clear();
                ArrayList arrObjects = chartVu.GetChartObjectsArrayList();

                if (m_objNewPlot == null)
                {

                    foreach (GraphObj objObject in arrObjects)
                    {
                        int iType = objObject.ChartObjType;

                        objLine = objObject;
                        if (iType == 1)
                        {
                            objClickedLine = (SimpleLinePlot)objLine;
                            break;
                        }
                    }
                }
                else
                {
                    objClickedLine = m_objNewPlot;
                }

                if (arrmarkerCursor != null)
                {
                    for (int i = 0; i < arrmarkerCursor.Length; i++)
                    {
                        chartVu.DeleteChartObject(arrmarkerCursor[i]);
                        chartVu.DeleteChartObject(m_objDataCursor);
                    }
                }
                if (arrChartTextCursor != null)
                {
                    for (int i1 = 0; i1 < arrChartTextCursor.Length; i1++)
                    {
                        chartVu.DeleteChartObject(arrChartTextCursor[i1]);
                    }
                }
                arrChartTextCursor = new ChartText[0];
                if (sType == "Right")
                {
                    {

                        m_iCounter++;
                        if (m_objDataCursor != null)
                            chartVu.DeleteChartObject(m_objDataCursor);

                        objDataSet = objClickedLine.DisplayDataset;

                        int iNumber = objDataSet.GetNumberDatapoints();
                        if (m_iCounter >= iNumber)
                            m_iCounter = iNumber - 1;

                        double lastx = objDataSet.XData[objDataSet.XData.Length - 1];
                        if (m_iCounter < (int)((iNumber - 1) * .02))
                        {
                            m_iCounter = (int)((iNumber - 1) * .02);
                        }
                        Point2D objPoint = objDataSet.GetDataPoint(m_iCounter);
                        ptPreviousPoint = objDataSet.GetDataPoint(m_iCounter - 1);
                        nearestPointObj1 = new NearestPointData();
                        textCoordsFont = new Font("Arial", 8, FontStyle.Regular);
                        
                        ptNewPoint = nearestPointObj1.GetNearestPoint();

                        if (m_objMarker != null)
                        {
                            chartVu.DeleteChartObject(m_objMarker);
                            chartVu.DeleteChartObject(m_objNewMarker);
                            if (m_objDataCursor != null)
                                chartVu.DeleteChartObject(m_objDataCursor);

                        }



                        double harmonicX = objPoint.X;

                        arrmarkerCursor = new Marker[0];
                        if (harmonicX < (double)(lastx * .02))
                        {
                            harmonicX = (double)(lastx * .02);
                        }
                        double constantHarmonicX = harmonicX;
                        Random _random = new Random(_MainCursorColor.ToArgb());
                        while (harmonicX <= lastx)
                        {
                            int MainIndex = Array.FindIndex(objDataSet.XData.GetDataBuffer(), delegate(double item) { return item == harmonicX; });
                            if (MainIndex == -1)
                            {
                                if (harmonicX <= objDataSet.XData[objDataSet.XData.Length - 1])
                                {
                                    harmonicX = FindNearest(objDataSet.XData.GetDataBuffer(), harmonicX);
                                    MainIndex = Array.FindIndex(objDataSet.XData.GetDataBuffer(), delegate(double item) { return item == harmonicX; });
                                }
                            }

                            Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, harmonicX, objDataSet.YData[MainIndex], 8, 1);

                            Array.Resize(ref arrmarkerCursor, arrmarkerCursor.Length + 1);
                            arrmarkerCursor[arrmarkerCursor.Length - 1] = m_objMarker1;


                            Color NewColor = Color.FromArgb(-Convert.ToInt32(_random.Next()));
                            m_objMarker1.FillColor = NewColor;
                            m_objMarker1.SetColor(NewColor);

                          

                            chartVu.AddChartObject(m_objMarker1);

                            ChartText CurrentLabel = new ChartText(pTransform1, theFont, harmonicX.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objDataSet.YData[MainIndex]), 5)) + YLabel, harmonicX, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                            CurrentLabel.SetColor(_MainCursorColor);
                            if (_ShowCursorVal) 
                            {
                                chartVu.AddChartObject(CurrentLabel);
                            }
                            Array.Resize(ref arrChartTextCursor, arrChartTextCursor.Length + 1);
                            arrChartTextCursor[arrChartTextCursor.Length - 1] = CurrentLabel;


                            _DataGridView.Rows.Add(1);
                            _DataGridView[0, _DataGridView.Rows.Count - 2].Value = harmonicX.ToString();
                            _DataGridView[1, _DataGridView.Rows.Count - 2].Value = objDataSet.YData[MainIndex].ToString();
                            _DataGridView.Refresh();
                            
                            harmonicX += constantHarmonicX;
                        }
                        chartVu.UpdateDraw();
                       
                    }
                }
                else if (sType == "Left")
                {
                    m_iCounter--;
                    if (m_iCounter < 0)
                        m_iCounter = 0;
                    objPreviousPointDataSet = objClickedLine.DisplayDataset;
                    double lastx = objPreviousPointDataSet.XData[objPreviousPointDataSet.XData.Length - 1];
                    if (m_objDataCursor != null)
                        chartVu.DeleteChartObject(m_objDataCursor);
                    Point2D objPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter);
                    ptPreviousPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter + 1);
                    nearestPointObj1 = new NearestPointData();
                    textCoordsFont = new Font("Arial", 8, FontStyle.Regular);

                    ptNewPoint = nearestPointObj1.GetNearestPoint();

                    if (m_objMarker != null)
                    {
                        chartVu.DeleteChartObject(m_objMarker);
                        chartVu.DeleteChartObject(m_objNewMarker);
                    }


                    double harmonicX = objPoint.X;

                    arrmarkerCursor = new Marker[0];
                    if (harmonicX < (double)(lastx * .02))
                    {
                        harmonicX = (double)(lastx * .02);
                    }
                    double constantHarmonicX = harmonicX;
                    Random _random = new Random(_MainCursorColor.ToArgb());
                    while (harmonicX <= lastx)
                    {
                        int MainIndex = Array.FindIndex(objPreviousPointDataSet.XData.GetDataBuffer(), delegate(double item) { return item == harmonicX; });
                        if (MainIndex == -1)
                        {
                            if (harmonicX <= objPreviousPointDataSet.XData[objPreviousPointDataSet.XData.Length - 1])
                            {
                                harmonicX = FindNearest(objPreviousPointDataSet.XData.GetDataBuffer(), harmonicX);
                                MainIndex = Array.FindIndex(objPreviousPointDataSet.XData.GetDataBuffer(), delegate(double item) { return item == harmonicX; });
                            }
                        }

                        Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, harmonicX, objPreviousPointDataSet.YData[MainIndex], 8, 1);

                        Array.Resize(ref arrmarkerCursor, arrmarkerCursor.Length + 1);
                        arrmarkerCursor[arrmarkerCursor.Length - 1] = m_objMarker1;


                        Color NewColor = Color.FromArgb(-Convert.ToInt32(_random.Next()));
                        m_objMarker1.FillColor = NewColor;
                        m_objMarker1.SetColor(NewColor);


                        chartVu.AddChartObject(m_objMarker1);

                        ChartText CurrentLabel = new ChartText(pTransform1, theFont, harmonicX.ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPreviousPointDataSet.YData[MainIndex]), 5)) + YLabel, harmonicX, pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                        CurrentLabel.SetColor(_MainCursorColor);
                        if (_ShowCursorVal) 
                        {
                            chartVu.AddChartObject(CurrentLabel);
                        }

                        Array.Resize(ref arrChartTextCursor, arrChartTextCursor.Length + 1);
                        arrChartTextCursor[arrChartTextCursor.Length - 1] = CurrentLabel;

                        _DataGridView.Rows.Add(1);
                        _DataGridView[0, _DataGridView.Rows.Count - 2].Value = harmonicX.ToString();
                        _DataGridView[1, _DataGridView.Rows.Count - 2].Value = objPreviousPointDataSet.YData[MainIndex].ToString();
                        _DataGridView.Refresh();
                        
                        harmonicX += constantHarmonicX;
                    }
                    chartVu.UpdateDraw();







                    m_objMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, objPoint.X, objPoint.Y, 5, 1);
                    m_objMarker.SetColor(Color.Black);

                    chartVu.AddChartObject(m_objMarker);

                                
                }

            }
            catch (Exception ex)
            {
                //ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }
        private void CheckKeyDownSingle(string sType)
        {
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            Point2D ptNewPoint = null;
            Point2D ptLocation = null;
            Point2D ptPreviousPoint = null;
            GraphObj objLine = null;
            SimpleLinePlot objClickedLine = null;
            SimpleDataset objDataSet = null;
            SimpleDataset objPreviousPointDataSet = null;

            try
            {
                _DataGridView.Rows.Clear();
                ArrayList arrObjects = chartVu.GetChartObjectsArrayList();

              
                if (m_objNewPlot == null)
                {

                    foreach (GraphObj objObject in arrObjects)
                    {
                        int iType = objObject.ChartObjType;

                        objLine = objObject;
                        if (iType == 1)
                        {
                            objClickedLine = (SimpleLinePlot)objLine;
                            break;
                        }
                    }
                }
                else
                {
                    objClickedLine = m_objNewPlot;
                }

                if (arrmarkerCursor != null)
                {
                    for (int i = 0; i < arrmarkerCursor.Length; i++)
                    {
                        chartVu.DeleteChartObject(arrmarkerCursor[i]);
                        chartVu.DeleteChartObject(m_objDataCursor);
                    }
                }
                if (arrChartTextCursor != null)
                {
                    for (int i1 = 0; i1 < arrChartTextCursor.Length; i1++)
                    {
                        chartVu.DeleteChartObject(arrChartTextCursor[i1]);
                    }
                }
                arrChartTextCursor = new ChartText[1];
                if (sType == "Right")
                {
                    {
                        m_iCounter++;
                        if (m_objDataCursor != null)
                            chartVu.DeleteChartObject(m_objDataCursor);

                        objDataSet = objClickedLine.DisplayDataset;
                        int iNumber = objDataSet.GetNumberDatapoints();
                        if (m_iCounter >= iNumber)
                            m_iCounter = iNumber - 1;
                        Point2D objPoint = objDataSet.GetDataPoint(m_iCounter);
                        ptPreviousPoint = objDataSet.GetDataPoint(m_iCounter - 1);
                        nearestPointObj1 = new NearestPointData();
                        textCoordsFont = new Font("Arial", 8, FontStyle.Regular);
                        
                        ptNewPoint = nearestPointObj1.GetNearestPoint();
                                                

                        if (m_objMarker != null)
                        {
                            chartVu.DeleteChartObject(m_objMarker);
                            chartVu.DeleteChartObject(m_objNewMarker);
                            if (m_objDataCursor != null)
                                chartVu.DeleteChartObject(m_objDataCursor);

                        }

                        m_objMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, objPoint.X, objPoint.Y, 5, 1);
                        m_objMarker.SetColor(Color.Black);
                        chartVu.AddChartObject(m_objMarker);

                        ChartText CurrentLabel = null;
                        _DataGridView.Rows.Add(1);
                        if (_MainForm._IsOverallTrend)
                        {
                            CurrentLabel = new ChartText(pTransform1, theFont, xdatalabels[(int)objPoint.GetX() - 1].ToString() + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                            _DataGridView[0, 0].Value = xdatalabels[(int)objPoint.GetX() - 1].ToString();
                        }
                        else
                        {
                            CurrentLabel = new ChartText(pTransform1, theFont, objPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                            _DataGridView[0, 0].Value = objPoint.GetX().ToString();
                        }
                        CurrentLabel.SetColor(_MainCursorColor);
                        if (_ShowCursorVal) 
                        {
                            chartVu.AddChartObject(CurrentLabel);
                        }
                        arrChartTextCursor[0] = CurrentLabel;



                        _DataGridView[1, 0].Value = objPoint.GetY().ToString();
                        _DataGridView.Refresh();



                    }
                }
                else if (sType == "Left")
                {
                    m_iCounter--;
                    if (m_iCounter < 0)
                        m_iCounter = 0;
                    objPreviousPointDataSet = objClickedLine.DisplayDataset;

                    if (m_objDataCursor != null)
                        chartVu.DeleteChartObject(m_objDataCursor);
                    Point2D objPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter);
                    ptPreviousPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter + 1);
                    nearestPointObj1 = new NearestPointData();
                    textCoordsFont = new Font("Arial", 8, FontStyle.Regular);

                    ptNewPoint = nearestPointObj1.GetNearestPoint();

                    if (m_objMarker != null)
                    {
                        chartVu.DeleteChartObject(m_objMarker);
                        chartVu.DeleteChartObject(m_objNewMarker);
                    }

                    m_objMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, objPoint.X, objPoint.Y, 5, 1);
                    m_objMarker.SetColor(Color.Black);

                    chartVu.AddChartObject(m_objMarker);


                    ChartText CurrentLabel = null;
                    _DataGridView.Rows.Add(1);
                    if (_MainForm._IsOverallTrend)
                    {
                        CurrentLabel = new ChartText(pTransform1, theFont, xdatalabels[(int)objPoint.GetX() - 1].ToString() + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                        _DataGridView[0, 0].Value = xdatalabels[(int)objPoint.GetX() - 1].ToString();
                    }
                    else
                    {
                        CurrentLabel = new ChartText(pTransform1, theFont, objPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                        _DataGridView[0, 0].Value = objPoint.GetX().ToString();
                    }
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[0] = CurrentLabel;



                    _DataGridView[1, 0].Value = objPoint.GetY().ToString();
                    _DataGridView.Refresh();
         
                }
                arrmarkerCursor = new Marker[1];
                arrmarkerCursor[0] = m_objMarker;
                chartVu.UpdateDraw();
            }
            catch (Exception ex)
            {
                //ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }
        private void CheckKeyDownCrossHair(string sType)
        {
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            Point2D ptNewPoint = null;
            Point2D ptLocation = null;
            Point2D ptPreviousPoint = null;
            GraphObj objLine = null;
            SimpleLinePlot objClickedLine = null;
            SimpleDataset objDataSet = null;
            SimpleDataset objPreviousPointDataSet = null;

            try
            {
                _DataGridView.Rows.Clear();
                ArrayList arrObjects = chartVu.GetChartObjectsArrayList();

                if (m_objNewPlot == null)
                {

                    foreach (GraphObj objObject in arrObjects)
                    {
                        int iType = objObject.ChartObjType;

                        objLine = objObject;
                        if (iType == 1)
                        {
                            objClickedLine = (SimpleLinePlot)objLine;
                            break;
                        }
                    }
                }
                else
                {
                    objClickedLine = m_objNewPlot;
                }
                if (arrmarkerCursor != null)
                {
                    for (int i = 0; i < arrmarkerCursor.Length; i++)
                    {
                        chartVu.DeleteChartObject(arrmarkerCursor[i]);
                        chartVu.DeleteChartObject(m_objDataCursor);
                    }
                }
                if (arrChartTextCursor != null)
                {
                    for (int i1 = 0; i1 < arrChartTextCursor.Length; i1++)
                    {
                        chartVu.DeleteChartObject(arrChartTextCursor[i1]);
                    }
                }
                arrChartTextCursor = new ChartText[1];
                if (sType == "Right")
                {
                    {
                        m_iCounter++;
                        if (m_objDataCursor != null)
                            chartVu.DeleteChartObject(m_objDataCursor);

                        objDataSet = objClickedLine.DisplayDataset;
                        int iNumber = objDataSet.GetNumberDatapoints();
                        if (m_iCounter >= iNumber)
                            m_iCounter = iNumber - 1;
                        Point2D objPoint = objDataSet.GetDataPoint(m_iCounter);
                        ptPreviousPoint = objDataSet.GetDataPoint(m_iCounter - 1);
                        nearestPointObj1 = new NearestPointData();
                        textCoordsFont = new Font("Arial", 8, FontStyle.Regular);
                        
                        ptNewPoint = nearestPointObj1.GetNearestPoint();


                        if (m_objMarker != null)
                        {
                            chartVu.DeleteChartObject(m_objMarker);
                            chartVu.DeleteChartObject(m_objNewMarker);
                            if (m_objDataCursor != null)
                                chartVu.DeleteChartObject(m_objDataCursor);

                        }

                        m_objMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, objPoint.X, objPoint.Y, 5, 1);
                        m_objNewMarker = new Marker(pTransform1, GraphObj.MARKER_HLINE, objPoint.X, objPoint.Y, 8, 1);
                        m_objMarker.SetColor(Color.Black);
                        m_objNewMarker.SetColor(Color.Black);
                        chartVu.AddChartObject(m_objMarker);
                        chartVu.AddChartObject(m_objNewMarker);


                        ChartText CurrentLabel = null;
                        _DataGridView.Rows.Add(1);
                        if (_MainForm._IsOverallTrend)
                        {
                            CurrentLabel = new ChartText(pTransform1, theFont, xdatalabels[(int)objPoint.GetX() - 1].ToString() + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                            _DataGridView[0, 0].Value = xdatalabels[(int)objPoint.GetX() - 1].ToString();
                        }
                        else
                        {
                            CurrentLabel = new ChartText(pTransform1, theFont, objPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                            _DataGridView[0, 0].Value = objPoint.GetX().ToString();
                        }
                        CurrentLabel.SetColor(_MainCursorColor);
                        if (_ShowCursorVal) 
                        {
                            chartVu.AddChartObject(CurrentLabel);
                        }
                        arrChartTextCursor[0] = CurrentLabel;



                        _DataGridView[1, 0].Value = objPoint.GetY().ToString();
                        _DataGridView.Refresh();

                       
                    }
                }
                else if (sType == "Left")
                {
                    m_iCounter--;
                    if (m_iCounter < 0)
                        m_iCounter = 0;
                    objPreviousPointDataSet = objClickedLine.DisplayDataset;

                    if (m_objDataCursor != null)
                        chartVu.DeleteChartObject(m_objDataCursor);
                    Point2D objPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter);
                    ptPreviousPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter + 1);
                    nearestPointObj1 = new NearestPointData();
                    textCoordsFont = new Font("Arial", 8, FontStyle.Regular);

                    ptNewPoint = nearestPointObj1.GetNearestPoint();

                    if (m_objMarker != null)
                    {
                        chartVu.DeleteChartObject(m_objMarker);
                        chartVu.DeleteChartObject(m_objNewMarker);
                    }

                    m_objMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, objPoint.X, objPoint.Y, 5, 1);
                    m_objNewMarker = new Marker(pTransform1, GraphObj.MARKER_HLINE, objPoint.X, objPoint.Y, 8, 1);
                    m_objMarker.SetColor(Color.Black);
                    m_objNewMarker.SetColor(Color.Black);

                    chartVu.AddChartObject(m_objMarker);
                    chartVu.AddChartObject(m_objNewMarker);


                    ChartText CurrentLabel = null;
                    _DataGridView.Rows.Add(1);
                    if (_MainForm._IsOverallTrend)
                    {
                        CurrentLabel = new ChartText(pTransform1, theFont, xdatalabels[(int)objPoint.GetX() - 1].ToString() + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                        _DataGridView[0, 0].Value = xdatalabels[(int)objPoint.GetX() - 1].ToString();
                    }
                    else
                    {
                        CurrentLabel = new ChartText(pTransform1, theFont, objPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                        _DataGridView[0, 0].Value = objPoint.GetX().ToString();
                    }
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[0] = CurrentLabel;



                    _DataGridView[1, 0].Value = objPoint.GetY().ToString();
                    _DataGridView.Refresh();


                             
                }
                arrmarkerCursor = new Marker[2];
                arrmarkerCursor[0] = m_objMarker;
                arrmarkerCursor[1] = m_objNewMarker;
                chartVu.UpdateDraw();
            }
            catch (Exception ex)
            {
                
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }
        private void CheckKeyDownSingleWithSquare(string sType)
        {
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            Point2D ptNewPoint = null;
            Point2D ptLocation = null;
            Point2D ptPreviousPoint = null;
            GraphObj objLine = null;
            SimpleLinePlot objClickedLine = null;
            SimpleDataset objDataSet = null;
            SimpleDataset objPreviousPointDataSet = null;

            try
            {
                _DataGridView.Rows.Clear();
                ArrayList arrObjects = chartVu.GetChartObjectsArrayList();

                foreach (GraphObj objObject in arrObjects)
                {
                    int iType = objObject.ChartObjType;

                    objLine = objObject;
                    if (iType == 1)
                    {
                        objClickedLine = (SimpleLinePlot)objLine;
                        break;
                    }
                }
                if (arrmarkerCursor != null)
                {
                    for (int i = 0; i < arrmarkerCursor.Length; i++)
                    {
                        chartVu.DeleteChartObject(arrmarkerCursor[i]);
                        chartVu.DeleteChartObject(m_objDataCursor);
                    }
                }
                if (arrChartTextCursor != null)
                {
                    for (int i1 = 0; i1 < arrChartTextCursor.Length; i1++)
                    {
                        chartVu.DeleteChartObject(arrChartTextCursor[i1]);
                    }
                }
                arrChartTextCursor = new ChartText[1];
                if (sType == "Right")
                {
                    {
                        m_iCounter++;
                        if (m_objDataCursor != null)
                            chartVu.DeleteChartObject(m_objDataCursor);

                        objDataSet = objClickedLine.DisplayDataset;
                        int iNumber = objDataSet.GetNumberDatapoints();
                        if (m_iCounter >= iNumber)
                            m_iCounter = iNumber - 1;
                        Point2D objPoint = objDataSet.GetDataPoint(m_iCounter);
                        ptPreviousPoint = objDataSet.GetDataPoint(m_iCounter - 1);
                        nearestPointObj1 = new NearestPointData();
                        textCoordsFont = new Font("Arial", 8, FontStyle.Regular);
                        
                        ptNewPoint = nearestPointObj1.GetNearestPoint();


                        if (m_objMarker != null)
                        {
                            chartVu.DeleteChartObject(m_objMarker);
                            chartVu.DeleteChartObject(m_objNewMarker);
                            if (m_objDataCursor != null)
                                chartVu.DeleteChartObject(m_objDataCursor);

                        }

                        m_objMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, objPoint.X, objPoint.Y, 5, 1);
                        m_objNewMarker = new Marker(pTransform1, GraphObj.MARKER_BOX, objPoint.X, objPoint.Y, 8, 1);
                        m_objMarker.SetColor(Color.Black);
                        m_objNewMarker.SetColor(Color.Black);
                        chartVu.AddChartObject(m_objMarker);
                        chartVu.AddChartObject(m_objNewMarker);


                        ChartText CurrentLabel = null;
                        _DataGridView.Rows.Add(1);
                        if (_MainForm._IsOverallTrend)
                        {
                            CurrentLabel = new ChartText(pTransform1, theFont, xdatalabels[(int)objPoint.GetX() - 1].ToString() + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                            _DataGridView[0, 0].Value = xdatalabels[(int)objPoint.GetX() - 1].ToString();
                        }
                        else
                        {
                            CurrentLabel = new ChartText(pTransform1, theFont, objPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                            _DataGridView[0, 0].Value = objPoint.GetX().ToString();
                        }
                        CurrentLabel.SetColor(_MainCursorColor);
                        if (_ShowCursorVal) //cursor position View on/off
                        {
                            chartVu.AddChartObject(CurrentLabel);
                        }
                        arrChartTextCursor[0] = CurrentLabel;



                        _DataGridView[1, 0].Value = objPoint.GetY().ToString();
                        _DataGridView.Refresh();


                     
                    }
                }
                else if (sType == "Left")
                {
                    m_iCounter--;
                    if (m_iCounter < 0)
                        m_iCounter = 0;
                    objPreviousPointDataSet = objClickedLine.DisplayDataset;

                    if (m_objDataCursor != null)
                        chartVu.DeleteChartObject(m_objDataCursor);
                    Point2D objPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter);
                    ptPreviousPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter + 1);
                    nearestPointObj1 = new NearestPointData();
                    textCoordsFont = new Font("Arial", 8, FontStyle.Regular);

                    ptNewPoint = nearestPointObj1.GetNearestPoint();

                    if (m_objMarker != null)
                    {
                        chartVu.DeleteChartObject(m_objMarker);
                        chartVu.DeleteChartObject(m_objNewMarker);
                    }

                    m_objMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, objPoint.X, objPoint.Y, 5, 1);
                    m_objNewMarker = new Marker(pTransform1, GraphObj.MARKER_BOX, objPoint.X, objPoint.Y, 8, 1);
                    m_objMarker.SetColor(Color.Black);
                    m_objNewMarker.SetColor(Color.Black);

                    chartVu.AddChartObject(m_objMarker);
                    chartVu.AddChartObject(m_objNewMarker);


                    ChartText CurrentLabel = null;
                    _DataGridView.Rows.Add(1);
                    if (_MainForm._IsOverallTrend)
                    {
                        CurrentLabel = new ChartText(pTransform1, theFont, xdatalabels[(int)objPoint.GetX() - 1].ToString() + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                        _DataGridView[0, 0].Value = xdatalabels[(int)objPoint.GetX() - 1].ToString();
                    }
                    else
                    {
                        CurrentLabel = new ChartText(pTransform1, theFont, objPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                        _DataGridView[0, 0].Value = objPoint.GetX().ToString();
                    }
                    CurrentLabel.SetColor(_MainCursorColor);
                    if (_ShowCursorVal) 
                    {
                        chartVu.AddChartObject(CurrentLabel);
                    }
                    arrChartTextCursor[0] = CurrentLabel;



                    _DataGridView[1, 0].Value = objPoint.GetY().ToString();
                    _DataGridView.Refresh();


                               
                }
                arrmarkerCursor = new Marker[2];
                arrmarkerCursor[0] = m_objMarker;
                arrmarkerCursor[1] = m_objNewMarker;
                chartVu.UpdateDraw();
            }
            catch (Exception ex)
            {
                
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }
        private void LineGraphControl_DragEnter(object sender, DragEventArgs e)
        {
            if (this.AllowDrop)
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
       

        double[] PeekX = new double[0];
        int[] PeekIndex = new int[0];
        private double[] FindAllPeaks(double[] Xdata, double[] Ydata)
        {
            PeekIndex = new int[0];
            PeekX = new double[0];
            double Fst = 0;
            double Scnd = 0;
            double Thrd = 0;
            try
            {
                for (int i = 2; i < Ydata.Length; i++)
                {
                    Fst = Ydata[i - 2];
                    Scnd = Ydata[i - 1];
                    Thrd = Ydata[i];

                    if (Fst < Scnd && Scnd > Thrd)
                    {


                        Array.Resize(ref PeekIndex, PeekIndex.Length + 1);
                        PeekIndex[PeekIndex.Length - 1] = i - 1;
                        Array.Resize(ref PeekX, PeekX.Length + 1);
                        PeekX[PeekX.Length - 1] = Xdata[i - 1];
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return PeekX;
        }

        internal ChartView DrawReportGraph(ArrayList XYData, string[] ColorTag,string Xunit,string Yunit)
        {
            RemovePreviousObjects();
            
            chartVu = this;
            bool InvertX = false;
            bool InvertY = false;

            try
            {
                SimpleDataset[] arrTestDataset = new SimpleDataset[0];
                for (int i = 0; i < XYData.Count / 2; i++)
                {
                    double[] testX = (double[])XYData[2 * i];
                    double[] testY = (double[])XYData[(2 * i) + 1];
                    if (Convert.ToDouble(testX[0].ToString()) > Convert.ToDouble(testX[testX.Length - 1].ToString()))
                    {
                        InvertX = true;
                    }
                   
                    SimpleDataset testdataset = new SimpleDataset("Test", testX, testY);
                    try
                    {
                        testdataset.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, testX.Length, "Test");
                    }
                    catch
                    {
                    }
                    Array.Resize(ref arrTestDataset, arrTestDataset.Length + 1);
                    arrTestDataset[arrTestDataset.Length - 1] = testdataset;
                }




                pTransform1 = new CartesianCoordinates();
                pTransform1.AutoScale(arrTestDataset, ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_FAR);
                pTransform1.SetGraphBorderDiagonal(0.15, .15, .85, 0.85);
                if (InvertX)
                {
                    pTransform1.InvertScaleX();
                }
                if (InvertY)
                {
                    pTransform1.InvertScaleY();
                }
                plotbackground = new Background(pTransform1, ChartObj.PLOT_BACKGROUND, ChartBG1, ChartBG2, ChartBGDir);
                chartVu.AddChartObject(plotbackground);

                background = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND, GraphBG1, GraphBG2, GraphBGDir);
                chartVu.AddChartObject(background);


                xAxis2 = new LinearAxis(pTransform1, ChartObj.X_AXIS);
                xAxis2.SetColor(_AxisColor);
                xAxis2.SetAxisIntercept(0);
                chartVu.AddChartObject(xAxis2);

                yAxis2 = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                yAxis2.SetColor(_AxisColor);
                yAxis2.SetAxisIntercept(0);
                chartVu.AddChartObject(yAxis2);

                xgrid2 = new Grid(xAxis2, yAxis2, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                xgrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(xgrid2);

                ygrid2 = new Grid(xAxis2, yAxis2, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                ygrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(ygrid2);


                for (int i = 0; i < arrTestDataset.Length; i++)
                {
                    attrib2 = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[i])), 1, DashStyle.Solid, Color.FromArgb(150, Color.FromArgb(-Convert.ToInt32(ColorTag[i]))));
                    attrib2.SetLineColor(Color.FromArgb(-Convert.ToInt32(ColorTag[i])));
                    attrib2.SetFillFlag(_AreaFill);


                    thePlot1 = new SimpleLinePlot(pTransform1, arrTestDataset[i], attrib2);
                    chartVu.AddChartObject(thePlot1);
                }

                xAxisLab2 = new NumericAxisLabels(xAxis2);
                xAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(xAxisLab2);

                yAxisLab2 = new NumericAxisLabels(yAxis2);
                yAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(yAxisLab2);

                yaxistitle2 = new AxisTitle(yAxis2, theFont, Yunit);
                yaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(yaxistitle2);

                xaxistitle2 = new AxisTitle(xAxis2, theFont, Xunit);
                xaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(xaxistitle2);

                chartVu.SetResizeMode(ChartObj.NO_RESIZE_OBJECTS);

                Font toolTipFont = new Font("Arial", 10, FontStyle.Regular);
                DataToolTip datatooltip = new DataToolTip(chartVu);
                NumericLabel xValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                NumericLabel yValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                datatooltip.GetToolTipSymbol().SetColor(_AxisColor);
                datatooltip.SetXValueTemplate(xValueTemplate);
                datatooltip.SetYValueTemplate(yValueTemplate);
                datatooltip.SetDataToolTipFormat(ChartObj.DATA_TOOLTIP_XY_ONELINE);
                datatooltip.SetEnable(true);
                chartVu.SetCurrentMouseListener(datatooltip);
                chartVu.UpdateDraw();
               
            }
            catch (Exception ex)
            {
            }
            return chartVu;
        }

        internal ChartView DrawReportGraph2(ArrayList XYData, string[] ColorTag, string Xunit, string Yunit,double RPM,frmIAdeptMain frmIadeConRohit,string MultiReportType, string sPointID1)
        {
            _MainForm = frmIadeConRohit;
            RemovePreviousObjects();

            chartVu = this;
            bool InvertX = false;
            bool InvertY = false;

            try
            {
                SimpleDataset[] arrTestDataset = new SimpleDataset[0];
                for (int i = 0; i < XYData.Count / 2; i++)
                {
                    double[] testX = (double[])XYData[2 * i];
                    double[] testY = (double[])XYData[(2 * i) + 1];

                    if (Convert.ToDouble(testX[0].ToString()) > Convert.ToDouble(testX[testX.Length - 1].ToString()))
                    {
                        InvertX = true;
                    }
                   
                    SimpleDataset testdataset = new SimpleDataset("Test", testX, testY);
                    try
                    {
                        testdataset.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, testX.Length, "Test");
                    }
                    catch
                    {
                    }
                    Array.Resize(ref arrTestDataset, arrTestDataset.Length + 1);
                    arrTestDataset[arrTestDataset.Length - 1] = testdataset;
                }




                pTransform1 = new CartesianCoordinates();
                pTransform1.AutoScale(arrTestDataset, ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_FAR);
                pTransform1.SetGraphBorderDiagonal(0.15, .15, .85, 0.85);
                if (InvertX)
                {
                    pTransform1.InvertScaleX();
                }
                if (InvertY)
                {
                    pTransform1.InvertScaleY();
                }
                plotbackground = new Background(pTransform1, ChartObj.PLOT_BACKGROUND, ChartBG1, ChartBG2, ChartBGDir);
                chartVu.AddChartObject(plotbackground);

                background = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND, GraphBG1, GraphBG2, GraphBGDir);
                chartVu.AddChartObject(background);


                xAxis2 = new LinearAxis(pTransform1, ChartObj.X_AXIS);
                xAxis2.SetColor(_AxisColor);
                xAxis2.SetAxisIntercept(0);
                chartVu.AddChartObject(xAxis2);

                yAxis2 = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                yAxis2.SetColor(_AxisColor);
                yAxis2.SetAxisIntercept(0);
                chartVu.AddChartObject(yAxis2);

                xgrid2 = new Grid(xAxis2, yAxis2, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                xgrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(xgrid2);

                ygrid2 = new Grid(xAxis2, yAxis2, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                ygrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(ygrid2);


                for (int i = 0; i < arrTestDataset.Length; i++)
                {
                    attrib2 = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[i])), 1, DashStyle.Solid, Color.FromArgb(150, Color.FromArgb(-Convert.ToInt32(ColorTag[i]))));
                    attrib2.SetLineColor(Color.FromArgb(-Convert.ToInt32(ColorTag[i])));
                    attrib2.SetFillFlag(_AreaFill);


                    thePlot1 = new SimpleLinePlot(pTransform1, arrTestDataset[i], attrib2);
                    chartVu.AddChartObject(thePlot1);
                }

                xAxisLab2 = new NumericAxisLabels(xAxis2);
                xAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(xAxisLab2);

                yAxisLab2 = new NumericAxisLabels(yAxis2);
                yAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(yAxisLab2);

                yaxistitle2 = new AxisTitle(yAxis2, theFont, Yunit);
                yaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(yaxistitle2);

                xaxistitle2 = new AxisTitle(xAxis2, theFont, Xunit);
                xaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(xaxistitle2);

                chartVu.SetResizeMode(ChartObj.NO_RESIZE_OBJECTS);

                Font toolTipFont = new Font("Arial", 10, FontStyle.Regular);
                DataToolTip datatooltip = new DataToolTip(chartVu);
                NumericLabel xValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                NumericLabel yValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                datatooltip.GetToolTipSymbol().SetColor(_AxisColor);
                datatooltip.SetXValueTemplate(xValueTemplate);
                datatooltip.SetYValueTemplate(yValueTemplate);
                datatooltip.SetDataToolTipFormat(ChartObj.DATA_TOOLTIP_XY_ONELINE);
                datatooltip.SetEnable(true);
                chartVu.SetCurrentMouseListener(datatooltip);
                chartVu.UpdateDraw();
                _XLabel = "Hz";
                RPM = RPM / 60;

                if (MultiReportType == "Multi Overall and Multi Graph(RPM Based)" || MultiReportType == "RPM Report for User selected Machine")
                {
                    chartVu = DrawRPMmarkers(true, RPM, 5, chartVu);
                }
                else if (MultiReportType == "Multi Overall and Multi Graph(Fault Frequency Based)")
                {
                    string[] FaultFreq = ExtractFaultFrequencies(sPointID1);
                    DrawFaultFrequencies2(true, FaultFreq, chartVu);
                }
                else if (MultiReportType == "Multi Overall and Multi Graph(Highest Peaks Based)" || MultiReportType == "Multi Overall and Multi Graph(Dominant Frequency Based)")
                {
                    //chartVu = DrawMarkers(chartVu, ff, MultiReportType);
                }
                
            }
            catch (Exception ex)
            {
            }
            return chartVu;
        }

        public string[] ExtractFaultFrequencies(string sPointID)
        {
            string[] Frequencies = new string[0];
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select * from faultfreq_data ffd inner join point_faultfreq pff on pff.FaultFreq_ID=ffd.Pf_ID where pff.Point_ID='" + sPointID + "'");

                foreach (DataRow dr in dt.Rows)
                {                    
                    _ResizeArray.IncreaseArrayString(ref Frequencies, 1);
                    Frequencies[Frequencies.Length - 1] = (string)dr["pf_name"] + "=" + Convert.ToString(dr["pf_freq"]);
                }
            }
            catch{ }
            return Frequencies;
        }

        internal ChartView DrawReportGraph2(ArrayList XYData, string[] ColorTag, string Xunit, string Yunit, double RPM, frmIAdeptMain frmIadeConRohit, string MultiReportType, string sPointID1, int [] ff)
        {

            _MainForm = frmIadeConRohit;
            RemovePreviousObjects();

            chartVu = this;
            bool InvertX = false;
            bool InvertY = false;

            try
            {
                SimpleDataset[] arrTestDataset = new SimpleDataset[0];
                for (int i = 0; i < XYData.Count / 2; i++)
                {
                    double[] testX = (double[])XYData[2 * i];
                    double[] testY = (double[])XYData[(2 * i) + 1];

                    if (Convert.ToDouble(testX[0].ToString()) > Convert.ToDouble(testX[testX.Length - 1].ToString()))
                    {
                        InvertX = true;
                    }
                   
                    SimpleDataset testdataset = new SimpleDataset("Test", testX, testY);
                    try
                    {
                        testdataset.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, testX.Length, "Test");
                    }
                    catch
                    {
                    }
                    Array.Resize(ref arrTestDataset, arrTestDataset.Length + 1);
                    arrTestDataset[arrTestDataset.Length - 1] = testdataset;
                }




                pTransform1 = new CartesianCoordinates();
                pTransform1.AutoScale(arrTestDataset, ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_FAR);
                pTransform1.SetGraphBorderDiagonal(0.15, .15, .85, 0.85);
                if (InvertX)
                {
                    pTransform1.InvertScaleX();
                }
                if (InvertY)
                {
                    pTransform1.InvertScaleY();
                }
                plotbackground = new Background(pTransform1, ChartObj.PLOT_BACKGROUND, ChartBG1, ChartBG2, ChartBGDir);
                chartVu.AddChartObject(plotbackground);

                background = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND, GraphBG1, GraphBG2, GraphBGDir);
                chartVu.AddChartObject(background);


                xAxis2 = new LinearAxis(pTransform1, ChartObj.X_AXIS);
                xAxis2.SetColor(_AxisColor);
                xAxis2.SetAxisIntercept(0);
                chartVu.AddChartObject(xAxis2);

                yAxis2 = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                yAxis2.SetColor(_AxisColor);
                yAxis2.SetAxisIntercept(0);
                chartVu.AddChartObject(yAxis2);

                xgrid2 = new Grid(xAxis2, yAxis2, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                xgrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(xgrid2);

                ygrid2 = new Grid(xAxis2, yAxis2, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                ygrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(ygrid2);

                
                for (int i = 0; i < arrTestDataset.Length; i++)
                {
                    attrib2 = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[i])), 1, DashStyle.Solid, Color.FromArgb(150, Color.FromArgb(-Convert.ToInt32(ColorTag[i]))));
                    attrib2.SetLineColor(Color.FromArgb(-Convert.ToInt32(ColorTag[i])));
                    attrib2.SetFillFlag(_AreaFill);


                    thePlot1 = new SimpleLinePlot(pTransform1, arrTestDataset[i], attrib2);
                    chartVu.AddChartObject(thePlot1);
                }

                xAxisLab2 = new NumericAxisLabels(xAxis2);
                xAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(xAxisLab2);

                yAxisLab2 = new NumericAxisLabels(yAxis2);
                yAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(yAxisLab2);

                yaxistitle2 = new AxisTitle(yAxis2, theFont, Yunit);
                yaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(yaxistitle2);

                xaxistitle2 = new AxisTitle(xAxis2, theFont, Xunit);
                xaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(xaxistitle2);

                chartVu.SetResizeMode(ChartObj.NO_RESIZE_OBJECTS);

                Font toolTipFont = new Font("Arial", 10, FontStyle.Regular);
                DataToolTip datatooltip = new DataToolTip(chartVu);
                NumericLabel xValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                NumericLabel yValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                datatooltip.GetToolTipSymbol().SetColor(_AxisColor);
                datatooltip.SetXValueTemplate(xValueTemplate);
                datatooltip.SetYValueTemplate(yValueTemplate);
                datatooltip.SetDataToolTipFormat(ChartObj.DATA_TOOLTIP_XY_ONELINE);
                datatooltip.SetEnable(true);
                chartVu.SetCurrentMouseListener(datatooltip);
                chartVu.UpdateDraw();
                _XLabel = "Hz";
                RPM = RPM / 60;

                if (MultiReportType == "Multi Overall and Multi Graph(RPM Based)")
                {
                    chartVu = DrawRPMmarkers(true, RPM, 10, chartVu);
                }
                else if (MultiReportType == "Multi Overall and Multi Graph(Fault Frequency Based)")
                {
                    string[] FaultFreq = ExtractFaultFrequencies(sPointID1);
                    DrawFaultFrequencies2(true, FaultFreq, chartVu);
                }
                else if (MultiReportType == "Multi Overall and Multi Graph(Highest Peaks Based)" || MultiReportType == "Multi Overall and Multi Graph(Dominant Frequency Based)")
                {
                    chartVu = DrawMarkers(chartVu, ff, MultiReportType);
                }
                else
                {
                    MultiReportType = "Multi Overall and Multi Graph(Highest Peaks Based)";
                    chartVu = DrawMarkers(chartVu, ff, MultiReportType);
                    m_objClickedPlot = thePlot1;
                }

            }
            catch (Exception ex)
            {
            }
            return chartVu;
        }

        public ChartView DrawReportGraph(double[] Xdata, double[] Ydata, string[] XDataLabels)
        {
            RemovePreviousObjects();
            
            chartVu = this;
            StringAxisLabels x1AxisLab = null;
            xdatalabels = XDataLabels;
            try
            {


                Dataset2 = new SimpleDataset("P/L", Xdata, Ydata);
                Dataset2.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, Ydata.Length, "compressed");
                pTransform1 = new CartesianCoordinates();
                pTransform1.AutoScale(Dataset2, ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_FAR);
                pTransform1.SetGraphBorderDiagonal(0.15, .15, .85, 0.85);

                plotbackground = new Background(pTransform1, ChartObj.PLOT_BACKGROUND, ChartBG1, ChartBG2, ChartBGDir);
                chartVu.AddChartObject(plotbackground);

                background = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND, GraphBG1, GraphBG2, GraphBGDir);
                chartVu.AddChartObject(background);


                xAxis2 = new LinearAxis(pTransform1, ChartObj.X_AXIS);
                xAxis2.SetColor(_AxisColor);
                
                chartVu.AddChartObject(xAxis2);

                yAxis2 = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                
                yAxis2.SetColor(_AxisColor);
                chartVu.AddChartObject(yAxis2);

                xgrid2 = new Grid(xAxis2, yAxis2, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                xgrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(xgrid2);

                ygrid2 = new Grid(xAxis2, yAxis2, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                ygrid2.SetColor(_AxisColor);
                chartVu.AddChartObject(ygrid2);



                attrib2 = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(_ColorTag)), 1, DashStyle.Solid, Color.FromArgb(150, Color.FromArgb(-Convert.ToInt32(_ColorTag))));
                attrib2.SetLineColor(Color.FromArgb(-Convert.ToInt32(_ColorTag)));
                attrib2.SetFillFlag(_AreaFill);


                thePlot1 = new SimpleLinePlot(pTransform1, Dataset2, attrib2);
                chartVu.AddChartObject(thePlot1);

                x1AxisLab = new StringAxisLabels(xAxis2);
                x1AxisLab.SetColor(_AxisColor);
                x1AxisLab.SetAxisLabelsStrings(XDataLabels, XDataLabels.Length);
                x1AxisLab.SetTextRotation(45);
                chartVu.AddChartObject(x1AxisLab);

                yAxisLab2 = new NumericAxisLabels(yAxis2);
                yAxisLab2.SetColor(_AxisColor);
                chartVu.AddChartObject(yAxisLab2);

                yaxistitle2 = new AxisTitle(yAxis2, theFont, _YLabel);
                yaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(yaxistitle2);

                xaxistitle2 = new AxisTitle(xAxis2, theFont, _XLabel);
                xaxistitle2.SetColor(_AxisColor);
                chartVu.AddChartObject(xaxistitle2);

                chartVu.SetResizeMode(ChartObj.NO_RESIZE_OBJECTS);
                if (_ChartFooter != null)
                {
                    ChartTitle footer = new ChartTitle(pTransform1, theFont, _ChartFooter);
                    footer.SetColor(_FooterColor);
                    footer.SetTitleType(ChartObj.CHART_FOOTER);
                    footer.SetTitlePosition(ChartObj.CENTER_GRAPH);
                    footer.SetTitleOffset(8);
                    chartVu.AddChartObject(footer);
                }

                Font toolTipFont = new Font("Arial", 10, FontStyle.Regular);
                datatooltip = new DataToolTip(chartVu);
                NumericLabel xValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                NumericLabel yValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                datatooltip.GetToolTipSymbol().SetColor(_AxisColor);
                datatooltip.SetXValueTemplate(xValueTemplate);
                datatooltip.SetYValueTemplate(yValueTemplate);
                datatooltip.SetDataToolTipFormat(ChartObj.DATA_TOOLTIP_XY_ONELINE);
                datatooltip.SetEnable(true);
                chartVu.SetCurrentMouseListener(datatooltip);

               
            }
            catch (Exception ex)
            {
            }
            return chartVu;
        }
       public double[] xxz = new double[10];
       public double[] yyz = new double[10];

        public ChartView DrawRPMmarkers(bool p, double FinalFreq,  int CountForRpm,ChartView _CView)
        {
            xxz[0] = 0;
            xxz[1] = 0;
            xxz[2] = 0;
            xxz[3] = 0;
            xxz[4] = 0;
            xxz[5] = 0;
            xxz[6] = 0;
            xxz[7] = 0;
            xxz[8] = 0;
            xxz[9] = 0;

            yyz[0] = 0;
            yyz[1] = 0;
            yyz[2] = 0;
            yyz[3] = 0;
            yyz[4] = 0;
            yyz[5] = 0;
            yyz[6] = 0;
            yyz[7] = 0;
            yyz[8] = 0;
            yyz[9] = 0;

            bool bToReturn = false;
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            NearestPointData objSecondNearestPoint = null;
            SimpleDataset Dataset1 = null;
            int PrvsMainIndex = 0;
            chartVu = _CView;
            try
            {
                if (p)
                {
                    
                    if (arrmarker != null)
                    {
                        for (int i1 = 0; i1 < arrmarker.Length; i1++)
                        {
                            chartVu.DeleteChartObject(arrmarker[i1]);
                            chartVu.DeleteChartObject(m_objDataCursor);
                        }
                    }
                    arrmarker = new Marker[CountForRpm];
                    if (arrChartText != null)
                    {
                        for (int i1 = 0; i1 < arrChartText.Length; i1++)
                        {
                            chartVu.DeleteChartObject(arrChartText[i1]);
                        }
                    }
                    arrChartText = new ChartText[0];
                    SimpleLinePlot[] AllPlots = GetAllPlots();
                    if (AllPlots.Length>0)
                    {
                        Dataset1 = AllPlots[0].DisplayDataset;


                        for (int i = 0; i < CountForRpm; i++)
                        {
                            double FreqToCalc = FinalFreq * (1 + i);
                            if (_XLabel == "CPM")
                            {
                                FreqToCalc = FreqToCalc * 60;
                            }
                            if (FreqToCalc > (double)Dataset1.XData[Dataset1.XData.Length - 1])
                            {
                                break;
                            }
                            int MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == FreqToCalc; });

                            if (MainIndex == -1)
                            {
                                if (FreqToCalc <= Dataset1.XData[Dataset1.XData.Length - 1])
                                {
                                    FreqToCalc = FindNearest(Dataset1.XData.GetDataBuffer(), FreqToCalc);
                                    MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == FreqToCalc; });
                                }
                            }

                            nearestPointObj1 = new NearestPointData();
                            objSecondNearestPoint = new NearestPointData();
                            textCoordsFont = new Font("Arial", 8, FontStyle.Regular);
                           
                            if (PrvsMainIndex != MainIndex)
                            {
                                Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, Dataset1.XData[MainIndex], Dataset1.YData[MainIndex], 8, 1);
                                xxz[i] = Convert.ToDouble(Dataset1.XData[MainIndex]);
                                yyz[i] = Convert.ToDouble(Dataset1.YData[MainIndex]);
                                arrmarker[i] = m_objMarker1;
                                m_objMarker1.LineStyle = DashStyle.DashDot;
                                m_objMarker1.FillColor = Color.DarkKhaki;
                                m_objMarker1.SetColor(Color.DarkKhaki);
                                chartVu.AddChartObject(m_objMarker1);

                                Font theLabelFont = new Font("Arial", 8, FontStyle.Regular);
                                ChartText CurrentLabel = new ChartText(pTransform1, theLabelFont, Convert.ToString(i + 1) + "x RPM " + Dataset1.YData[MainIndex].ToString(), Dataset1.XData[MainIndex], pTransform1.YScale.ScaleStop, ChartObj.PHYS_POS, ChartObj.JUSTIFY_MIN, ChartObj.JUSTIFY_MIN, 270);
                                CurrentLabel.SetColor(Color.Black);
                                chartVu.AddChartObject(CurrentLabel);
                                Array.Resize(ref arrChartText, arrChartText.Length + 1);
                                arrChartText[arrChartText.Length - 1] = CurrentLabel;                                
                                PrvsMainIndex = MainIndex;
                            }
                            else
                                break;
                            bToReturn = true;
                            chartVu.UpdateDraw();
                        }
                    }
                }
                else
                {
                    if (arrmarker != null)
                    {
                        for (int i1 = 0; i1 < arrmarker.Length; i1++)
                        {
                            chartVu.DeleteChartObject(arrmarker[i1]);
                            chartVu.DeleteChartObject(m_objDataCursor);
                        }
                    }


                    if (arrChartText != null)
                    {
                        for (int i1 = 0; i1 < arrChartText.Length; i1++)
                        {
                            chartVu.DeleteChartObject(arrChartText[i1]);
                        }
                    }
                    chartVu.UpdateDraw();
                }
            }
            catch (Exception ex)
            {
            }
            return chartVu;
        }
        public void KillPoint(bool Kill)
        {
            bool bToReturn = false;
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            NearestPointData objSecondNearestPoint = null;
            SimpleDataset Dataset1 = null;
            int PrvsMainIndex = 0;
            
            try
            {
                if (arrmarker != null)
                {
                    for (int i1 = 0; i1 < arrmarker.Length; i1++)
                    {
                        chartVu.DeleteChartObject(arrmarker[i1]);
                        chartVu.DeleteChartObject(m_objDataCursor);
                    }
                }
                arrmarker = new Marker[0];
                if (arrChartText != null)
                {
                    for (int i1 = 0; i1 < arrChartText.Length; i1++)
                    {
                        chartVu.DeleteChartObject(arrChartText[i1]);
                    }
                }
                arrChartText = new ChartText[0];
                SimpleLinePlot[] AllPlots = GetAllPlots();
                if (AllPlots.Length > 0)
                {
                    Dataset1 = AllPlots[0].DisplayDataset;

                    {

                        Point2D _2dXY = arrmarkerCursor[0].GetLocation();
                        double FreqToCalc = _2dXY.GetX();
                        if (_XLabel == "CPM")
                        {
                            FreqToCalc = FreqToCalc * 60;
                        }
                      
                        int MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == FreqToCalc; });
                        if (MainIndex == -1)
                        {
                            if (FreqToCalc <= Dataset1.XData[Dataset1.XData.Length - 1])
                            {
                                FreqToCalc = FindNearest(Dataset1.XData.GetDataBuffer(), FreqToCalc);
                                MainIndex = Array.FindIndex(Dataset1.XData.GetDataBuffer(), delegate(double item) { return item == FreqToCalc; });
                            }
                        }

                        int PrevIndex = MainIndex - 1;
                        int NextIndex = MainIndex + 1;
                        double prevVal = Dataset1.YData[PrevIndex];
                        double nextval = Dataset1.YData[NextIndex];
                        double avgval = (prevVal + nextval) / 2;
                        Dataset1.YData[MainIndex] = avgval;



                        nearestPointObj1 = new NearestPointData();
                        objSecondNearestPoint = new NearestPointData();
                        textCoordsFont = new Font("Arial", 8, FontStyle.Regular);
                        
                        bToReturn = true;
                        chartVu.UpdateDraw();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public double FindNearest(double[] TargetArray, double ValueToBeFound)
        {
            double Value = 0.0;
            try
            {
                for (int i = 0; i < TargetArray.Length; i++)
                {
                    Value = TargetArray[i];
                    if (Value > ValueToBeFound)
                    {
                        if ((double)(Value - ValueToBeFound) > Math.Abs((double)(ValueToBeFound - (double)TargetArray[i - 1])))
                        {
                            Value = TargetArray[i - 1];
                        }
                        else
                        {
                            Value = TargetArray[i];
                        }

                        break;
                    }
                }
                return Value;
            }
            catch (Exception ex)
            {                
                return Value;
            }
        }

        private void LineGraphControl_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (MainForm.wavnode == "WAVFile" || MainForm.wavnode == "UFFFile")
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Right:
                            {
                                contextMenuStrip1.Show(this, new Point(e.X, e.Y));
                                break;
                            }
                    }
                    // visbilty(sNodeType);       
                }
            }
            catch { }
        }

        private void tssave_Click(object sender, EventArgs e)
        {
            if (MainForm.wavnode == "WAVFile" || MainForm.wavnode == "UFFFile")
            {
                DialogResult Drslt = MessageBox.Show(this, "Do you want to Save '"+MainForm.wavnode+"'?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Drslt == DialogResult.Yes)
                {
                    if (MainForm.wavnode == "WAVFile")
                    {
                        ClsCommon objcommon = new ClsCommon(); objcommon._MainForm = MainForm;
                        objcommon.ConvertPointType(PublicClass.SPointID);
                        objcommon.insert_pointdatawav(objcommon.untypeid, MainForm.Channel1WavX, MainForm.Channel1WavY, MainForm.Channel2WavX, MainForm.Channel2WavY);
                        MessageBox.Show(this, "Point Type Created Successfully", "Wav File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (MainForm.wavnode == "UFFFile")
                    {
                        ClsCommon objcommon = new ClsCommon(); objcommon._MainForm = MainForm;
                        objcommon.ConvertPointType(PublicClass.SPointID);
                        objcommon.insert_pointdatauff(objcommon.untypeid, MainForm.Specch1_x, MainForm.Specch1_y, MainForm.Specch2_x, MainForm.Specch2_y, MainForm.Specch3_x, MainForm.Specch3_y, MainForm.Specch4_x, MainForm.Specch4_y, MainForm.timech1_x, MainForm.timech1_y, MainForm.timech2_x, MainForm.timech2_y, MainForm.timech3_x, MainForm.timech3_y, MainForm.timech4_x, MainForm.timech4_y);
                        MessageBox.Show(this, "Point Type Created Successfully", "UFF File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else { }
                }
            }
        }

        private void LineGraphControl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //test1 test = new test1();
                //test.MainForm = MainForm;
                //test.abc();
                //test.Show();
            }
            catch { }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                UpdateXScaleAndAxes(hScrollBar1.Value);
            }
            catch { }
        }

        private void UpdateXScaleAndAxes(int index)
        {
            try
            {
                double startindex = index;
                double a = 0;
                a = Math.Abs((double)(m_objClickedPlot.DisplayDataset.GetXDataValue(0) - m_objClickedPlot.DisplayDataset.GetXDataValue(1)));
                startindex = startindex * a;
                double difference = zoomObj.ChartObjScale.GetScaleStopX() - zoomObj.ChartObjScale.GetScaleStartX();

                pTransform1.SetScaleStartX((double)startindex);
                pTransform1.SetScaleStopX((double)(startindex + difference));
                xAxis2.CalcAutoAxis();
                yAxis2.CalcAutoAxis();
                xAxisLab2.CalcAutoAxisLabels();
                yAxisLab2.CalcAutoAxisLabels();
                this.UpdateDraw();
            }
            catch 
            {
            }
        }

        
    }
}
