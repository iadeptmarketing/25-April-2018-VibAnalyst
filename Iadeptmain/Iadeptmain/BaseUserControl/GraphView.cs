using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using System.Collections;

using System.Data.SqlClient;


using System.Data.Odbc;
using System.Drawing.Imaging;
using System.IO;
using Iadeptmain.BaseUserControl;
using Iadeptmain.Mainforms;
using DevExpress.XtraEditors;
using com.iAM.chart2dnet;
using Iadeptmain.Classes;
using Iadeptmain.GlobalClasses;
namespace Iadeptmain.BaseUserControl
{
    
    public partial class GraphView : com.iAM.chart2dnet.ChartView
    {
        CartesianCoordinates m_objCoordinates = null;
        ChartView m_objChartView = null;
        SimpleDataset m_objSimpleDataSet = null;
        LinearAxis m_objLinearAxes = null;
        protected ChartTitle footer;
        protected ChartTitle mainTitle;
        public ChartView chartVu;
        SimpleLinePlot thePlot1 = null;
        SimpleBarPlot theBarPlot1 = null;
        SimpleDataset Dataset1 = null;
        SimpleDataset objDataSet = null;
        DataCursor m_objDataCursor = null;
        PointGeneral1 _objpoint = null;
        CartesianCoordinates pTransform1 = null;
        Marker objSecondLineMarker = null;
        SimpleLinePlot m_objSelectedPlot = null;
        SimpleLinePlot m_objOldSelectedPlot = null;
        
        SimpleLinePlot m_objSelectedPlotForCursor = null;
        C2DGraphView m_obj2DGraphView = null;
        SimpleLinePlot m_objNewPlot = null;

        ToolTip m_objToolTip = null;
        frmgraphcontrol m_objGraphControl = null;
        string m_sUnit = null;
        string m_sMeasureType = null;
        Font theFont;
        int ColorCounter = 0;
        Color m_objColor;
        Background background = null;
        bool m_bFill = false;
        ChartAttribute attrib1 = null;
        ChartAttribute attrStackedArea = null;
        SimpleLinePlot objStackedLinePlot = null;
        SimpleBarPlot m_objBarPlot = null;
        SimpleScatterPlot m_objScatterPlot = null;
       
        string sSelectedItem = null;
        int m_iSelectedIndex = 0;
        ChartZoom m_objChartZoom = null;
        Marker m_objMarker = null;

        Point m_objClickedPoint;
        DataCursor m_objSideBandCursor = null;
        Marker m_objSideBandMarker = null;
        Marker m_objNewMarker = null;
        int m_iCounter = 0;
        Marker m_objPreviousPointMarker = null;
        Dictionary<Point2D, Point2D> m_objPointsInData = null;
        double m_dCounterValue = 0;
        int x = 0;
        int z = 0;
        int i = 0;
        int j = 0;
        int iCo = 0;
        SimpleLinePlot m_objPlotTwo = null;
        SimpleLinePlot m_objPlotThree = null;
        SimpleLinePlot m_objPlotFour = null;
        SimpleLinePlot m_objPlotFive = null;
        SimpleLinePlot m_objPlotSix = null;
        SimpleLinePlot m_objPlotSeven = null;
        SimpleLinePlot m_objPlotEight = null;
        SimpleLinePlot m_objPlotNine = null;
        SimpleLinePlot m_objPlotTen = null;
       
       //private frmgraphcontrol m_objParentControl = null;

        SimpleDataset m_objFirstDataSet = null;
        SimpleDataset m_objSecondDataSet = null;
        SimpleDataset m_objThirdDataSet = null;
        SimpleDataset m_objFourthDataSet = null;
        SimpleDataset[] m_objDataSetArray = null;
        private frmValues m_objValuesWindow = null;
        C3DGraph m_obj3DGraph = null;
        string m_sUnits = null;
        private int m_iWaterFallCounter = 0;
        public delegate void GraphClickedHandler(MouseEventArgs e);
        public event GraphClickedHandler GraphClicked;
        private string m_sDataBaseName = null;
       
        private frmgraphcontrol m_objBaseControl = null;
        public delegate void MouseMoveHandler(MouseEventArgs e);
        public event MouseMoveHandler ThisMouseMove;

        private IadeptUserControl m_objMainControl = null;
        private frmIAdeptMain _objmain = null;

        public frmIAdeptMain maincontrol
        {
            set
            {
                _objmain = value;
            }
        }


        public IadeptUserControl usercontrol
        {
            set
            {
                m_objMainControl = value;
            }
        }

        public PointGeneral1 usercontrol1
        {
            set
            {
                _objpoint = value;
            }
        }
        public frmgraphcontrol ParentForm
        {
            get
            {
                return m_objGraphControl;
            }
            set
            {
                m_objGraphControl = value;
                if (m_obj2DGraphView != null)
                    m_obj2DGraphView.BaseParentControl = m_objGraphControl;
            }
        }

        private bool bClearItems = false;
        bool bOverall = false;

        public bool OverallTrend1
        {
            get
            {
                return bOverall;
            }
            set
            {
                bOverall = value;
            }
        }
        string sYAxis = null;
        public string YAxisValue1
        {
            get
            {
                return sYAxis;
            }
            set
            {
                sYAxis = value;
            }
        }
        ArrayList sarrTime = null;

        public ArrayList DateTimedata
        {
            get
            {
                return sarrTime;
            }
            set
            {
                sarrTime = value;
            }
        }

        public string LabelValues
        {
            set
            {
                this.lblValues.Text = value;
            }
        }
        public bool ClearItems
        {
            set
            {
                bClearItems = value;
                if (bClearItems)
                    ClearAllItems();
            }
        }

        private void ClearAllItems()
        {
            try
            {
                m_objDataCursor = null;
                lblValues.Text = "";
                m_objMarker = null;
                m_objNewMarker = null;

            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }//end(private void ClearAllItems())

        public GraphView(frmgraphcontrol objGraphControl)
        {
            InitializeComponent();
            m_obj2DGraphView = new C2DGraphView();
            m_obj2DGraphView.TwoDGraphControl = this;
           
            lblValues.Text = "Values:";
            m_objGraphControl = objGraphControl;
            m_arlstLinePlots = new ArrayList();
            GetPointValues();
            m_objToolTip = new ToolTip();
            m_objToolTip.BackColor = Color.DimGray;
            m_objToolTip.ForeColor = Color.White;
            //attrib1 = new ChartAttribute[10];
            this.KeyDown += new KeyEventHandler(GraphView_KeyDown);
            //this.MouseDown += new MouseEventHandler(GraphView_MouseDown);
            this.KeyPress += new KeyPressEventHandler(GraphView_KeyPress);
            lblValues.BackColor = Color.Transparent;
            lblValues.ForeColor = Color.Black;
            m_objPointsInData = new Dictionary<Point2D, Point2D>();

        }//end( public GraphView(ucGraphControl objGraphControl))

        void GraphView_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        public void CheckKeyDown(string sType)
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
                if (m_obj2DGraphView != null)
                    m_obj2DGraphView.CheckKeyDown(sType);

            }
            catch (Exception ex)
            {
            }
        }

  
        bool bmara = false;
        public bool _Mara
        {
            get
            {
                return bmara;
            }
        }
        public void RemovePreviousObjects()
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
                    x = 0;  
                }

                bmara = false;
            }
            catch (Exception ex)
            {
                bmara = true;
                ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
               
            }
        }

        void GraphView_KeyDown(object sender, KeyEventArgs e)
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

                ArrayList arrObjects = chartVu.GetChartObjectsArrayList();

                foreach (GraphObj objObject in arrObjects)
                {
                    int iType = objObject.ChartObjType;

                    objLine = objObject;
                    if (iType == 1 && objLine.LineWidth == 2)
                    {
                        objClickedLine = (SimpleLinePlot)objLine;
                        break;
                    }


                }
               
                if (e.KeyCode == Keys.NumPad6)
                {



                    if (objClickedLine.LineWidth == 2)
                    {

                        objDataSet = objClickedLine.DisplayDataset;
                        Point2D objPoint = objDataSet.GetDataPoint(m_iCounter);
                        ptPreviousPoint = Dataset1.GetDataPoint(m_iCounter - 1);
                        nearestPointObj1 = new NearestPointData();
                        textCoordsFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);


                        m_objPointsInData.Add(objPoint, objPoint);
                        if (m_objSideBandCursor != null)
                            chartVu.DeleteChartObject(m_objSideBandCursor);


                        ptNewPoint = nearestPointObj1.GetNearestPoint();


                        if (m_objMarker != null)
                        {
                            chartVu.DeleteChartObject(m_objMarker);
                            chartVu.DeleteChartObject(m_objNewMarker);
                            chartVu.DeleteChartObject(m_objPreviousPointMarker);
                            if (m_objDataCursor != null)
                                chartVu.DeleteChartObject(m_objDataCursor);

                        }

                        m_objMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, objPoint.X, objPoint.Y, 5, 1);
                        m_objNewMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, objPoint.X, objPoint.Y, 5, 1);
                       
                        m_objMarker.SetColor(Color.Black);
                        m_objNewMarker.SetColor(Color.Black);
                       

                        chartVu.AddChartObject(m_objMarker);
                        chartVu.AddChartObject(m_objNewMarker);
                       

                        if (m_objMarker != null)
                        {
                            lblValues.Text = "X Value:" + objPoint.X + "\n" + "Y Value:" + objPoint.Y;

                            chartVu.UpdateDraw();

                        }
                        m_iCounter++;

                        int iNumber = Dataset1.GetNumberDatapoints();
                        if (m_iCounter > iNumber)
                            m_iCounter = iNumber;
                    }

                }
                else if (e.KeyCode == Keys.NumPad4)
                {

                    objPreviousPointDataSet = objClickedLine.DisplayDataset;

                    if (m_objDataCursor != null)
                        chartVu.DeleteChartObject(m_objDataCursor);
                    Point2D objPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter);
                    ptPreviousPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter + 1);
                    nearestPointObj1 = new NearestPointData();
                    textCoordsFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);

                    if (m_objSideBandCursor != null)
                        chartVu.DeleteChartObject(m_objSideBandCursor);

                    ptNewPoint = nearestPointObj1.GetNearestPoint();

                    if (m_objMarker != null)
                    {
                        chartVu.DeleteChartObject(m_objMarker);
                        chartVu.DeleteChartObject(m_objNewMarker);

                    }

                    m_objMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, objPoint.X, objPoint.Y, 5, 1);
                    m_objNewMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, objPoint.X, objPoint.Y, 5, 1);

                    m_objMarker.SetColor(Color.Black);
                    m_objNewMarker.SetColor(Color.Black);

                    chartVu.AddChartObject(m_objMarker);
                    chartVu.AddChartObject(m_objNewMarker);


                    if (m_objMarker != null)
                    {
                        lblValues.Text = "X Value:" + objPoint.X + "\n" + "Y Value:" + objPoint.Y;
                        chartVu.UpdateDraw();

                    }

                    m_iCounter--;
                    if (m_iCounter < 0)
                        m_iCounter = 0;

                }


            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }

        }

        public Color SetLineColor
        {
            set
            {
                m_objColor = value;

                if (sSelectedItem == "LinePlot " || sSelectedItem == "")
                {
                    thePlot1.SetColor(m_objColor);
                }
                else if (sSelectedItem == "AreaPlot ")
                {
                    objStackedLinePlot.SetColor(m_objColor);
                }
                else if (sSelectedItem == "BarsPlot")
                {
                    m_objBarPlot.SetColor(m_objColor);
                }
                else if (sSelectedItem == "PointsPlot")
                {
                    m_objScatterPlot.SetColor(m_objColor);

                }

                chartVu.UpdateDraw();

            }
        }

        public bool ShowDataPointValues
        {
            set
            {

                thePlot1.ShowDatapointValue = value;
                chartVu.UpdateDraw();
            }
        }

        public Color SetBackColor
        {
            set
            {
                m_objColor = value;
                background.SetColor(m_objColor);
                chartVu.UpdateDraw();
                m_obj2DGraphView.SetBackColor = m_objColor;
            }
        }

        public Color SetToolTipBackColor
        {
            set
            {
                m_objColor = value;
                m_objToolTip.BackColor = m_objColor;
            }
        }

        public Color SetToolTipForeColor
        {
            set
            {
                m_objColor = value;
                m_objToolTip.ForeColor = m_objColor;

            }
        }

        public int MarkerType
        {
            set
            {
                m_iSelectedIndex = value;
                m_iSelectedIndex++;
                if (m_iSelectedIndex == 1 || m_iSelectedIndex == 2 || m_iSelectedIndex == 3 || m_iSelectedIndex == 4)
                {
                    m_objDataCursor.SetMarkerType((int)m_iSelectedIndex);

                }
            }
        }

        public void CreateSideBandCursor()
        {
            try
            {
                m_objSideBandCursor = new DataCursor(chartVu, pTransform1, GraphObj.MARKER_VLINE, 8.0);
                m_objSideBandCursor.SetColor(Color.Red);
                m_objSideBandCursor.SetEnable(true);
                m_objSideBandCursor.LineStyle = DashStyle.Solid;
                m_objSideBandCursor.SetLineStyle(DashStyle.Solid);
                m_objSideBandCursor.LineColor = Color.Red;
                chartVu.SetCurrentMouseListener(m_objSideBandCursor);
                chartVu.AddChartObject(m_objSideBandCursor);
                m_objSideBandCursor.SetColor(Color.White);
                m_objDataCursor = null;
                m_objMarker = null;


            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void GetPointValues()
        {
           

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            try
            {

                Point2D objPoint = new Point2D();
                objPoint.SetLocation(e.X, e.Y);

                base.OnMouseDown(e);
                ChartObj obj = chartVu.FindObj(objPoint, "GraphObj", 0);
            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
            finally
            {
                e = null;
            }



        }

        public void GetOverAllValues(double[] darrYValues)
        {
            try
            {
                double[] darrNewYValuesPeak = null;
                int iArrLength = darrYValues.Length / 10;
                darrNewYValuesPeak = new double[iArrLength];
                int k = 0;
                double temp = 0;
                for (int iCtr = 0, j = 0; iCtr < darrYValues.Length; iCtr++, j++)
                {
                    if (temp < darrYValues[iCtr])
                    {
                        temp = darrYValues[iCtr];
                    }
                    if (j == 10)
                    {
                        j = 0;
                        darrNewYValuesPeak[k] = temp;
                        temp = 0;
                        k++;
                    }

                }


            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);

            }
        }
      
        public string Units
        {
            get
            {
                return m_sUnits;
            }
            set
            {
                m_sUnits = value;
            }
        }
        Color sClColor;
        public Color ClickColor
        {
            get
            {
                return sClColor;
            }
            set
            {
                sClColor = value;
            }
        }
        private string m_sTimeAxis = null;
        public string TimeAxisValue
        {
            set
            {
                m_sTimeAxis = value;
            }
        }
    
        bool m_bAcknowledgement = false;

       public ChartView cvTest1 = new ChartView();
        ChartView cvTest2 = new ChartView();
        ChartView cvTest3 = new ChartView();
        ChartView cvTest4 = new ChartView();
        ChartView cvTest5 = new ChartView();
       
        ChartView cv4PowerGraph = new ChartView();
        ChartView cv5PowerGraph1 = new ChartView();
        ChartView cv6Power2Graph = new ChartView();
        ChartView cv7Power2Graph1 = new ChartView();
        ChartView cv8Power3Graph = new ChartView();
        ChartView cv9Power3Graph1 = new ChartView();

        public ChartView testing4powerGraph
        {
            get { return cv4PowerGraph; }
            set { cv4PowerGraph = value; }
        
        }

        public ChartView testing5powerGraph1
        {
            get
            {
                return cv5PowerGraph1;
            }
            set
            {
                cv5PowerGraph1 = value;

            }

        }

        public ChartView testing6power2Graph
        {
            get
            {
                return cv6Power2Graph;
            }
            set
            {
                cv6Power2Graph = value;

            }

        }
        public ChartView testing7power2Graph1
        {
            get
            {
                return cv7Power2Graph1;
            }
            set
            {
                cv7Power2Graph1 = value;

            }

        }
        public ChartView testing8power3Graph
        {
            get
            {
                return cv8Power3Graph;
            }
            set
            {
                cv8Power3Graph = value;

            }

        }
        public ChartView testing9power3Graph1
        {
            get
            {
                return cv9Power3Graph1;
            }
            set
            {
                cv9Power3Graph1 = value;

            }

        }

        public ChartView testingGraph1
        {
            get
            {
                return cvTest1;
            }
            set
            {
                cvTest1 = value;
            }

        }

        public ChartView testingGraph2
        {
            get
            {
                return cvTest2;
            }
            set
            {
                cvTest2 = value;
            }

        }

        public ChartView testingGraph3
        {
            get
            {
                return cvTest3;
            }
            set
            {
                cvTest3 = value;
                chartVu = value;
            }

        }
        public ChartView testingGraph4
        {
            get
            {
                return cvTest4;
            }
            set
            {
                cvTest4 = value;
            }
        }

        public ChartView testingGraph5
        {
            get
            {
                return cvTest5;
            }
            set
            {
                cvTest5 = value;
                chartVu = value;
            }

        }

        int igrphctr = 0;

        public void InitializeChart(ArrayList arrXValue, ArrayList arrYValue, string sDateAndTime, int ixctr)
        {
            SimpleDataset[] datasetarray = null;
            LinearAxis xAxis = null;
            LinearAxis yAxis = null;
            NumericAxisLabels xAxisLab = null;
            NumericAxisLabels yAxisLab = null;
            Grid xgrid = null;
            Grid ygrid = null;
            AxisTitle objXTitle = null;
            AxisTitle objYTitle = null;
            double[] NewObjXValue = new double[arrXValue.Count];
            double[] NewObjYValue = new double[arrXValue.Count];


            StringAxisLabels x1AxisLab = null;


            try
            {


                {
                    m_arlstLinePlots.Clear();
                    if (m_objPreviousPlot != null)
                        m_objPreviousPlot = null;
                    this.lblValues.Text = "X Value:0 \nY Value:0";
                 
                    datasetarray = new SimpleDataset[arrXValue.Count];
                  
                    chartVu = this;
                    chartVu.Height = 617;
                    chartVu.Width = 921;

                    theFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                   

                    for (int ii = 0; ii < arrXValue.Count; ii++)
                    {
                        Dataset1 = new SimpleDataset("First", (double[])arrXValue[ii], (double[])arrYValue[ii]);
                        double[] FindLength = (double[])arrXValue[ii];
                        datasetarray[ii] = Dataset1.CompressSimpleDataset(GraphObj.DATACOMPRESS_MAX, GraphObj.DATACOMPRESS_MAX, 1, 0, FindLength.Length - 1, "NewData");
                    }
                   
                    pTransform1 = new CartesianCoordinates();

                    pTransform1.AutoScale(datasetarray, ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_EXACT);
                    //pTransform1.SetCoordinateBounds(1000, -10, -1000, 10);
                    pTransform1.SetGraphBorderDiagonal(0.15, .175, .85, 0.75);
                    //}


                    Color objBackgroundColor = Color.FromArgb(241, 241, 247);
                    background = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND, objBackgroundColor);

                    chartVu.AddChartObject(background);


                    if (ixctr == 1)
                    {
                        cvTest1.AddChartObject(background);
                    }
                    else if (ixctr == 2)
                    {
                        cvTest2.AddChartObject(background);
                    }
                    else if (ixctr == 3)
                    {
                        cvTest3.AddChartObject(background);
                    }
                    else if (ixctr == 4)
                    {
                        cvTest4.AddChartObject(background);
                    }

                    else if (ixctr == 5)
                    {
                        cv5PowerGraph1.AddChartObject(background);
                    }
                    else if (ixctr == 6)
                    {
                        cv6Power2Graph.AddChartObject(background);
                    }
                    else if (ixctr == 7)
                    {
                        cv7Power2Graph1.AddChartObject(background);
                    }
                    else if (ixctr == 8)
                    {
                        cv8Power3Graph.AddChartObject(background);
                    }
                    else if (ixctr == 9)
                    {
                        cv9Power3Graph1.AddChartObject(background);
                    }



                    //if (x == 0)
                    {

                        string[] sarrLabels = m_sUnits.Split(new char[] { ',' });



                        xAxis = new LinearAxis(pTransform1, ChartObj.X_AXIS);
                        xAxis.CalcAutoAxis();
                        chartVu.AddChartObject(xAxis);

                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(xAxis);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(xAxis);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(xAxis);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(xAxis);
                        }

                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(xAxis);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(xAxis);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(xAxis);
                        }
                        else if (ixctr ==8)
                        {
                            cv8Power3Graph.AddChartObject(xAxis);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(xAxis);
                        }
                        

                        // if (m_sUnit == "Accel. G")
                        if (bOverall)
                        {

                            objXTitle = new AxisTitle(xAxis, theFont, "");
                            chartVu.AddChartObject(objXTitle);

                            if (ixctr == 4)
                            {
                                cvTest4.AddChartObject(objXTitle);
                            }

                        }
                        else
                        {
                            if (m_sTimeAxis == "Sec")
                            {
                                objXTitle = new AxisTitle(xAxis, theFont, "Sec");
                                chartVu.AddChartObject(objXTitle);


                                if (ixctr == 1)
                                {
                                    cvTest1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 2)
                                {
                                    cvTest2.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 3)
                                {
                                    cvTest3.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 5)
                                {
                                    cv5PowerGraph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 6)
                                {
                                    cv6Power2Graph.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 7)
                                {
                                    cv7Power2Graph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 8)
                                {
                                    cv8Power3Graph.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 9)
                                {
                                    cv9Power3Graph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 4)
                                {
                                    cvTest4.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 10)
                                {
                                    cvTest5.AddChartObject(objXTitle);
                                }

                            }
                            else if (m_sTimeAxis == "Others")
                            {
                                objXTitle = new AxisTitle(xAxis, theFont, sarrLabels[0]);
                                chartVu.AddChartObject(objXTitle);


                                if (ixctr == 1)
                                {
                                    cvTest1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 2)
                                {
                                    cvTest2.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 3)
                                {
                                    cvTest3.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 5)
                                {
                                    cv5PowerGraph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 6)
                                {
                                    cv6Power2Graph.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 7)
                                {
                                    cv7Power2Graph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 8)
                                {
                                    cv8Power3Graph.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 9)
                                {
                                    cv9Power3Graph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 4)
                                {
                                    cvTest4.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 10)
                                {
                                    cvTest5.AddChartObject(objXTitle);
                                }
                            }
                        }
                        //end(if (m_sUnit == "Accel. G"))



                        yAxis = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                        yAxis.CalcAutoAxis();
                        chartVu.AddChartObject(yAxis);

                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(yAxis);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(yAxis);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(yAxis);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(yAxis);
                        }

                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(yAxis);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(yAxis);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(yAxis);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(yAxis);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(yAxis);
                        }

                        // if (m_sUnit == "Accel. G")
                        {
                            objYTitle = new AxisTitle(yAxis, theFont, sarrLabels[1]);
                            chartVu.AddChartObject(objYTitle);

                            if (ixctr == 1)
                            {
                                cvTest1.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 2)
                            {
                                cvTest2.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 3)
                            {
                                cvTest3.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 5)
                            {
                                cv5PowerGraph1.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 6)
                            {
                                cv6Power2Graph.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 7)
                            {
                                cv7Power2Graph1.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 8)
                            {
                                cv8Power3Graph.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 9)
                            {
                                cv9Power3Graph1.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 4)
                            {
                                cvTest4.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 10)
                            {
                                cvTest5.AddChartObject(objYTitle);
                            }
                        }
                        int itime = 0;

                        if (bOverall)
                        {
                            string[] test = new string[sarrTime.Count];
                            // test[0] = " ";
                            for (itime = 0; itime < sarrTime.Count; itime++)
                            {
                                string stemp = (string)sarrTime[itime];
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



                            x1AxisLab = new StringAxisLabels(xAxis);
                            x1AxisLab.SetTextFont(theFont);
                            x1AxisLab.SetAxisLabelsStrings(test, itime + 1);

                            //x1AxisLab.SetAxisLabelsEnds(ChartObj.LABEL_ALL);

                            //x1AxisLab.SetAxisLabelsDecimalPos(10);
                            x1AxisLab.BaseAxis.AxisTickOrigin = 0;
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
                          
                            x1AxisLab.SetOverlapLabelMode(ChartObj.OVERLAP_LABEL_DRAW);
                            x1AxisLab.SetTextRotation(270);
                          

                            if (ixctr == 1)
                            {
                                cvTest1.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 2)
                            {
                                cvTest2.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 3)
                            {
                                cvTest3.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 4)
                            {
                                cvTest4.AddChartObject(x1AxisLab);
                            }

                            else if (ixctr == 5)
                            {
                                cv5PowerGraph1.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 6)
                            {
                                cv6Power2Graph.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 7)
                            {
                                cv7Power2Graph1.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 8)
                            {
                                cv8Power3Graph.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 9)
                            {
                                cv9Power3Graph1.AddChartObject(x1AxisLab);
                            }

                            chartVu.AddChartObject(x1AxisLab);

                        }
                        else
                        {

                            if (xAxis.AxisTickSpace < 50.0 && (m_sTimeAxis == "Others" || m_sTimeAxis == "Hz"))
                            {
                                xAxis.AxisTickSpace = 50.0;
                            }

                            xAxisLab = new NumericAxisLabels(xAxis);
                            xAxisLab.SetTextFont(theFont);
                            chartVu.AddChartObject(xAxisLab);


                            if (ixctr == 1)
                            {
                                cvTest1.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 2)
                            {
                                cvTest2.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 3)
                            {
                                cvTest3.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 5)
                            {
                                cv5PowerGraph1.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 6)
                            {
                                cv6Power2Graph.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 7)
                            {
                                cv7Power2Graph1.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 8)
                            {
                                cv8Power3Graph.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 9)
                            {
                                cv9Power3Graph1.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 4)
                            {
                                cvTest4.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 10)
                            {
                                cvTest5.AddChartObject(xAxisLab);
                            }
                        }

                   
                        yAxisLab = new NumericAxisLabels(yAxis);
                        yAxisLab.SetTextFont(theFont);
                        chartVu.AddChartObject(yAxisLab);

                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(yAxisLab);
                        }

                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(yAxisLab);
                        }
                        else if (ixctr ==6)
                        {
                            cv6Power2Graph.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(yAxisLab);
                        }

                        xgrid = new Grid(xAxis, yAxis, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                        chartVu.AddChartObject(xgrid);

                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(xgrid);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(xgrid);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(xgrid);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(xgrid);
                        }

                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(xgrid);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(xgrid);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(xgrid);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(xgrid);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(xgrid);
                        }


                        ygrid = new Grid(xAxis, yAxis, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                        chartVu.AddChartObject(ygrid);


                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(ygrid);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(ygrid);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(ygrid);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(ygrid);
                        }

                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(ygrid);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(ygrid);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(ygrid);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(ygrid);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(ygrid);
                        }
                    }


                    int iCount = arrXValue.Count;
                    NumericLabel objLabel=null;
                    switch (iCount)
                    {
                        case 1:
                            attrib1 = new ChartAttribute(Color.DarkRed, 1, DashStyle.Solid);
                            thePlot1 = new SimpleLinePlot(pTransform1, datasetarray[0], attrib1);

                            objLabel = new NumericLabel();
                            objLabel.SetNumericValue(ixctr);
                            thePlot1.SetPlotLabelTemplate(objLabel);

                            thePlot1.PlotLabelTemplate.SetTextBgMode(true);
                            thePlot1.PlotLabelTemplate.SetTextString(sDateAndTime);
                            m_objGraphControl.LabelTime = sDateAndTime;
                            m_objGraphControl.LabelColor = Color.DarkRed;
                            ClickColor = Color.DarkRed;
                            chartVu.AddChartObject(thePlot1);

                            //ColorCounter++;



                            if (ixctr == 1)
                            {
                                cvTest1.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 2)
                            {
                                cvTest2.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 3)
                            {
                                cvTest3.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 4)
                            {
                                cvTest4.AddChartObject(thePlot1);
                            }

                            else if (ixctr == 5)
                            {
                                cv5PowerGraph1.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 6)
                            {
                                cv6Power2Graph.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 7)
                            {
                                cv7Power2Graph1.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 8)
                            {
                                cv8Power3Graph.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 9)
                            {
                                cv9Power3Graph1.AddChartObject(thePlot1);
                            }



                            //objAttribute = new ChartAttribute(Color.DarkRed, 1, DashStyle.Solid);
                            //m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                            //m_objChartView.AddChartObject(m_objFirstLinePlot);



                            //ChartText objFirstText = new ChartText(m_objCartesianCordinates, m_objFont, (string)m_arlstDates[0], m_objFirstLinePlot.DisplayDataset.XData[m_objFirstLinePlot.DisplayDataset.XData.Length - 60], m_objFirstLinePlot.DisplayDataset.YData[m_objFirstLinePlot.DisplayDataset.YData.Length - 60], ChartObj.PHYS_POS);

                            //m_objChartView.AddChartObject(objFirstText);
                            
                                ParentForm.SetForeColorDateTime = Color.DarkRed;
                                ParentForm.SetDateTime = sDateAndTime;
                           

                            break;
                        case 2:
                            attrib1 = new ChartAttribute(Color.DarkRed, 1, DashStyle.Solid);
                            thePlot1 = new SimpleLinePlot(pTransform1, datasetarray[0], attrib1);

                              objLabel = new NumericLabel();
                            objLabel.SetNumericValue(ixctr);
                            thePlot1.SetPlotLabelTemplate(objLabel);

                            thePlot1.PlotLabelTemplate.SetTextBgMode(true);
                            thePlot1.PlotLabelTemplate.SetTextString(sDateAndTime);
                            m_objGraphControl.LabelTime = sDateAndTime;
                            m_objGraphControl.LabelColor = Color.DarkRed;
                            ClickColor = Color.DarkRed;
                            chartVu.AddChartObject(thePlot1);

                            //ColorCounter++;



                            if (ixctr == 1)
                            {
                                cvTest1.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 2)
                            {
                                cvTest2.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 3)
                            {
                                cvTest3.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 4)
                            {
                                cvTest4.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 5)
                            {
                                cv5PowerGraph1.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 6)
                            {
                                cv6Power2Graph.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 7)
                            {
                                cv7Power2Graph1.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 8)
                            {
                                cv8Power3Graph.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 9)
                            {
                                cv9Power3Graph1.AddChartObject(thePlot1);
                            }


                            attrib1 = new ChartAttribute(Color.DarkGreen, 1, DashStyle.Solid);
                            thePlot1 = new SimpleLinePlot(pTransform1, datasetarray[1], attrib1);

                             objLabel = new NumericLabel();
                            objLabel.SetNumericValue(ixctr);
                            thePlot1.SetPlotLabelTemplate(objLabel);

                            thePlot1.PlotLabelTemplate.SetTextBgMode(true);
                            thePlot1.PlotLabelTemplate.SetTextString(sDateAndTime);
                            m_objGraphControl.LabelTime = sDateAndTime;
                            m_objGraphControl.LabelColor = Color.DarkRed;
                            ClickColor = Color.DarkRed;
                            chartVu.AddChartObject(thePlot1);

                            //ColorCounter++;



                            if (ixctr == 1)
                            {
                                cvTest1.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 2)
                            {
                                cvTest2.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 3)
                            {
                                cvTest3.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 4)
                            {
                                cvTest4.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 5)
                            {
                                cv5PowerGraph1.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 6)
                            {
                                cv6Power2Graph.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 7)
                            {
                                cv7Power2Graph1.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 8)
                            {
                                cv8Power3Graph.AddChartObject(thePlot1);
                            }
                            else if (ixctr == 9)
                            {
                                cv9Power3Graph1.AddChartObject(thePlot1);
                            }
                                ParentForm.SetForeColorDateTime = Color.DarkGreen;
                                ParentForm.SetDateTime = sDateAndTime;
                            //}


                            break;
                      

                    }


                    chartVu.UpdateDraw();




                    if (ixctr == 1)
                    {
                        igrphctr = 1;
                        
                        cvTest1.UpdateDraw();
                    }
                    else if (ixctr == 2)
                    {
                        igrphctr = 2;
                   
                        cvTest2.UpdateDraw();

                    }
                    else if (ixctr == 3)
                    {
                        igrphctr = 3;
                      
                        cvTest3.UpdateDraw();

                    }
                    else if (ixctr == 4)
                    {
                        cvTest4.UpdateDraw();
                    }

                    else if (ixctr == 5)
                    {
                        igrphctr = 5;
                       
                        cv5PowerGraph1.UpdateDraw();

                    }
                    else if (ixctr == 6)
                    {
                        igrphctr = 6;
                      
                        cv6Power2Graph.UpdateDraw();

                    }
                    else if (ixctr == 7)
                    {
                        igrphctr = 7;
                       
                        cv7Power2Graph1.UpdateDraw();

                    }
                    else if (ixctr == 8)
                    {
                        igrphctr = 8;
                      
                        cv8Power3Graph.UpdateDraw();

                    }
                    else if (ixctr == 9)
                    {
                        igrphctr = 9;
                       
                        cv9Power3Graph1.UpdateDraw();

                    }
                    

                    x += 1;
                 
                    if (x == 9)
                    {
                        x = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
            finally
            {
                
            }

        }
        public void InitializeBarChart(double[] arrXValue, double[] arrYValue, string sDateAndTime, int ixctr)
        {


            SimpleDataset[] datasetarray = null;
            LinearAxis xAxis = null;
            LinearAxis yAxis = null;
            NumericAxisLabels xAxisLab = null;
            NumericAxisLabels yAxisLab = null;
            Grid xgrid = null;
            Grid ygrid = null;
            AxisTitle objXTitle = null;
            AxisTitle objYTitle = null;
            double[] NewObjXValue = new double[arrXValue.Length+1];
            double[] NewObjYValue = new double[arrXValue.Length+1];
            StringAxisLabels x1AxisLab = null;
            try
            {
                {
                    m_arlstLinePlots.Clear();
                    if (m_objPreviousPlot != null)
                        m_objPreviousPlot = null;
                    this.lblValues.Text = CValues.SCONSTXY;
                    
                    datasetarray = new SimpleDataset[1];
                    
                    chartVu = this;
                    chartVu.Height = 617;
                    chartVu.Width = 921;

                    theFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                  
                    Dataset1 = new SimpleDataset("First", arrXValue, arrYValue);
                    objDataSet = Dataset1.CompressSimpleDataset(GraphObj.DATACOMPRESS_MAX, GraphObj.DATACOMPRESS_MAX, 1, 0, arrXValue.Length - 1, "NewData");


                    datasetarray[0] = objDataSet;
                  
                    pTransform1 = new CartesianCoordinates();

                    pTransform1.AutoScale(datasetarray[0], ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_EXACT);
                    pTransform1.SetGraphBorderDiagonal(0.15, .175, .85, 0.75);
                    pTransform1.SetScaleY(0, pTransform1.ScaleMaxY);

                    Color objBackgroundColor = Color.FromArgb(241, 241, 247);
                    background = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND, objBackgroundColor);

                    chartVu.AddChartObject(background);


                    if (ixctr == 1)
                    {
                        cvTest1.AddChartObject(background);
                    }
                    else if (ixctr == 2)
                    {
                        cvTest2.AddChartObject(background);
                    }
                    else if (ixctr == 3)
                    {
                        cvTest3.AddChartObject(background);
                    }
                    else if (ixctr == 4)
                    {
                        cvTest4.AddChartObject(background);
                    }

                    else if (ixctr == 5)
                    {
                        cv5PowerGraph1.AddChartObject(background);
                    }
                    else if (ixctr ==6)
                    {
                        cv6Power2Graph.AddChartObject(background);
                    }
                    else if (ixctr == 7)
                    {
                        cv7Power2Graph1.AddChartObject(background);
                    }
                    else if (ixctr == 8)
                    {
                        cv8Power3Graph.AddChartObject(background);
                    }
                    else if (ixctr == 9)
                    {
                        cv9Power3Graph1.AddChartObject(background);
                    }


                    //if (x == 0)
                    {

                        string[] sarrLabels = m_sUnits.Split(new char[] { ',' });



                        xAxis = new LinearAxis(pTransform1, ChartObj.X_AXIS);
                        xAxis.CalcAutoAxis();
                        chartVu.AddChartObject(xAxis);

                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(xAxis);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(xAxis);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(xAxis);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(xAxis);
                        }
                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(xAxis);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(xAxis);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(xAxis);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(xAxis);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(xAxis);
                        }


                        // if (m_sUnit == "Accel. G")
                        if (bOverall)
                        {

                            objXTitle = new AxisTitle(xAxis, theFont, "");
                            chartVu.AddChartObject(objXTitle);

                            if (ixctr == 4)
                            {
                                cvTest4.AddChartObject(objXTitle);
                            }

                        }
                        else
                        {
                            if (m_sTimeAxis == "Sec")
                            {
                                objXTitle = new AxisTitle(xAxis, theFont, "Sec");
                                chartVu.AddChartObject(objXTitle);


                                if (ixctr == 1)
                                {
                                    cvTest1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 2)
                                {
                                    cvTest2.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 3)
                                {
                                    cvTest3.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 5)
                                {
                                    cv5PowerGraph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 6)
                                {
                                    cv6Power2Graph.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 7)
                                {
                                    cv7Power2Graph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 8)
                                {
                                    cv8Power3Graph.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 9)
                                {
                                    cv9Power3Graph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 4)
                                {
                                    cvTest4.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 10)
                                {
                                    cvTest5.AddChartObject(objXTitle);
                                }

                            }
                            else if (m_sTimeAxis == "Others")
                            {
                                objXTitle = new AxisTitle(xAxis, theFont, sarrLabels[0]);
                                chartVu.AddChartObject(objXTitle);


                                if (ixctr == 1)
                                {
                                    cvTest1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 2)
                                {
                                    cvTest2.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 3)
                                {
                                    cvTest3.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 5)
                                {
                                    cv5PowerGraph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 6)
                                {
                                    cv6Power2Graph.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 7)
                                {
                                    cv7Power2Graph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 8)
                                {
                                    cv8Power3Graph.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 9)
                                {
                                    cv9Power3Graph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 4)
                                {
                                    cvTest4.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 10)
                                {
                                    cvTest5.AddChartObject(objXTitle);
                                }
                            }
                        }
                        


                        yAxis = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                        yAxis.CalcAutoAxis();
                        chartVu.AddChartObject(yAxis);

                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(yAxis);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(yAxis);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(yAxis);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(yAxis);
                        }
                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(yAxis);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(yAxis);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(yAxis);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(yAxis);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(yAxis);
                        }
                        // if (m_sUnit == "Accel. G")
                        {
                            objYTitle = new AxisTitle(yAxis, theFont, sarrLabels[1]);
                            chartVu.AddChartObject(objYTitle);

                            if (ixctr == 1)
                            {
                                cvTest1.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 2)
                            {
                                cvTest2.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 3)
                            {
                                cvTest3.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 5)
                            {
                                cv5PowerGraph1.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 6)
                            {
                                cv6Power2Graph.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 7)
                            {
                                cv7Power2Graph1.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 8)
                            {
                                cv8Power3Graph.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 9)
                            {
                                cv9Power3Graph1.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 4)
                            {
                                cvTest4.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 10)
                            {
                                cvTest5.AddChartObject(objYTitle);
                            }

                        }
                        int itime = 0;

                        if (bOverall)
                        {
                            string[] test = new string[sarrTime.Count];
                            // test[0] = " ";
                            for (itime = 0; itime < sarrTime.Count; itime++)
                            {
                                string stemp = (string)sarrTime[itime];
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



                            x1AxisLab = new StringAxisLabels(xAxis);
                            x1AxisLab.SetTextFont(theFont);
                            x1AxisLab.SetAxisLabelsStrings(test, itime + 1);

                            x1AxisLab.BaseAxis.AxisTickOrigin = 0;
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
                           
                            x1AxisLab.SetOverlapLabelMode(ChartObj.OVERLAP_LABEL_DRAW);
                            x1AxisLab.SetTextRotation(270);
                          
                            if (ixctr == 1)
                            {
                                cvTest1.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 2)
                            {
                                cvTest2.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 3)
                            {
                                cvTest3.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 4)
                            {
                                cvTest4.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 5)
                            {
                                cv5PowerGraph1.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 6)
                            {
                                cv6Power2Graph.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 7)
                            {
                                cv7Power2Graph1.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 8)
                            {
                                cv8Power3Graph.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 9)
                            {
                                cv9Power3Graph1.AddChartObject(x1AxisLab);
                            }





                            chartVu.AddChartObject(x1AxisLab);

                        }
                        else
                        {

                            if (xAxis.AxisTickSpace < 50.0 && (m_sTimeAxis == "Others" || m_sTimeAxis == "Hz"))
                            {
                                xAxis.AxisTickSpace = 50.0;
                            }

                            xAxisLab = new NumericAxisLabels(xAxis);
                            xAxisLab.SetTextFont(theFont);
                            chartVu.AddChartObject(xAxisLab);


                            if (ixctr == 1)
                            {
                                cvTest1.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 2)
                            {
                                cvTest2.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 3)
                            {
                                cvTest3.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 5)
                            {
                                cv5PowerGraph1.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 6)
                            {
                                cv6Power2Graph.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 7)
                            {
                                cv7Power2Graph1.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 8)
                            {
                                cv8Power3Graph.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 9)
                            {
                                cv9Power3Graph1.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 4)
                            {
                                cvTest4.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 10)
                            {
                                cvTest5.AddChartObject(xAxisLab);
                            }
                        }
                        yAxisLab = new NumericAxisLabels(yAxis);
                        yAxisLab.SetTextFont(theFont);
                        chartVu.AddChartObject(yAxisLab);

                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(yAxisLab);
                        }
                        else if (ixctr ==6)
                        {
                            cv6Power2Graph.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(yAxisLab);
                        }

                        xgrid = new Grid(xAxis, yAxis, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                        chartVu.AddChartObject(xgrid);

                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(xgrid);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(xgrid);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(xgrid);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(xgrid);
                        }
                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(xgrid);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(xgrid);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(xgrid);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(xgrid);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(xgrid);
                        }


                        ygrid = new Grid(xAxis, yAxis, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                        chartVu.AddChartObject(ygrid);


                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(ygrid);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(ygrid);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(ygrid);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(ygrid);
                        }
                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(ygrid);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(ygrid);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(ygrid);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(ygrid);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(ygrid);
                        }
                    }
                    {
                        Random _random = new Random();
                        int _red = Math.Abs(_random.Next() * 33);
                        int _Blue =Math.Abs( _random.Next()* 77);
                        int _Green = Math.Abs(_random.Next() * 43);
                        if (_red > 255)
                        {
                            _red = _red % 255;
                        }
                        if (_Blue > 255)
                        {
                            _Blue = _Blue % 255;
                        }
                        if (_Green > 255)
                        {
                            _Green = _Green % 255;
                        }

                        attrib1 = new ChartAttribute(Color.FromArgb(_red, _Green, _Blue), 1, DashStyle.Solid, Color.FromArgb(_red, _Green, _Blue));
                        theBarPlot1 = new SimpleBarPlot(pTransform1);
                        theBarPlot1.DisplayDataset = datasetarray[0];
                        theBarPlot1.ChartObjAttributes = attrib1;

                        theBarPlot1 = new SimpleBarPlot(pTransform1, datasetarray[0], .5, 0.000, attrib1, ChartObj.JUSTIFY_CENTER);

                        

                        NumericLabel objLabel = new NumericLabel();
                        objLabel.SetNumericValue(ixctr);
                        theBarPlot1.SetPlotLabelTemplate(objLabel);

                        theBarPlot1.PlotLabelTemplate.SetTextBgMode(true);
                        theBarPlot1.PlotLabelTemplate.SetTextString(sDateAndTime);
                        m_objGraphControl.LabelTime = sDateAndTime;
                        m_objGraphControl.LabelColor = Color.DarkRed;
                        ClickColor = Color.DarkRed;
                        chartVu.AddChartObject(theBarPlot1);

                        ColorCounter = 0;



                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(theBarPlot1);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(theBarPlot1);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(theBarPlot1);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(theBarPlot1);
                        }
                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(theBarPlot1);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(theBarPlot1);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(theBarPlot1);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(theBarPlot1);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(theBarPlot1);
                        }

                    }
                  
                    chartVu.UpdateDraw();




                    if (ixctr == 1)
                    {
                        igrphctr = 1;
                       
                        cvTest1.UpdateDraw();
                    }
                    else if (ixctr == 2)
                    {
                        igrphctr = 2;
                       
                        cvTest2.UpdateDraw();

                    }
                    else if (ixctr == 3)
                    {
                        igrphctr = 3;
                       
                        cvTest3.UpdateDraw();

                    }
                    else if (ixctr == 4)
                    {
                        cvTest4.UpdateDraw();
                    }

                    else if (ixctr == 5)
                    {
                        igrphctr = 5;
                       
                        cv5PowerGraph1.UpdateDraw();

                    }
                    else if (ixctr == 6)
                    {
                        igrphctr = 6;
                       
                        cv6Power2Graph.UpdateDraw();

                    }
                    else if (ixctr == 7)
                    {
                        igrphctr = 7;
                      
                        cv7Power2Graph1.UpdateDraw();

                    }
                    else if (ixctr == 8)
                    {
                        igrphctr = 8;
                     
                        cv8Power3Graph.UpdateDraw();

                    }
                    else if (ixctr == 9)
                    {
                        igrphctr = 9;
                       
                        cv9Power3Graph1.UpdateDraw();

                    }
                   
                    x += 1;
                    if (x == 9)
                    {
                        x = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
            finally
            {
             
            }

        }
       
        public void InitializeChart(double[] arrXValue, double[] arrYValue, string sDateAndTime, int ixctr)
        {
            SimpleDataset[] datasetarray = null;
            LinearAxis xAxis = null;
            LinearAxis yAxis = null;
            NumericAxisLabels xAxisLab = null;
            NumericAxisLabels yAxisLab = null;
            Grid xgrid = null;
            Grid ygrid = null;
            AxisTitle objXTitle = null;
            AxisTitle objYTitle = null;
            double[] NewObjXValue = new double[arrXValue.Length];
            double[] NewObjYValue = new double[arrXValue.Length];
            StringAxisLabels x1AxisLab = null;
            try
            {
                {
                    m_arlstLinePlots.Clear();
                    if (m_objPreviousPlot != null)
                        m_objPreviousPlot = null;
                    this.lblValues.Text = "X Value:0 \nY Value:0";
                    GetOverAllValues(arrYValue);
                    //m_objGraphControl = new frmgraphcontrol();
                    datasetarray = new SimpleDataset[1];
                    chartVu = this;
                    chartVu.Height = 617;
                    chartVu.Width = 921;

                    theFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);                  
                    Dataset1 = new SimpleDataset("First", arrXValue, arrYValue);
                    objDataSet = Dataset1.CompressSimpleDataset(GraphObj.DATACOMPRESS_MAX, GraphObj.DATACOMPRESS_MAX, 1, 0, arrXValue.Length - 1, "NewData");
                    try
                    {
                        string aa = objDataSet.GetStackMode().ToString();
                    }
                    catch { }


                    datasetarray[0] = objDataSet;
                    
                    pTransform1 = new CartesianCoordinates();

                    pTransform1.AutoScale(datasetarray[0], ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_EXACT);
                    pTransform1.SetGraphBorderDiagonal(0.15, .175, .85, 0.75);
                    


                    Color objBackgroundColor = Color.FromArgb(241, 241, 247);
                    background = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND, objBackgroundColor);

                    chartVu.AddChartObject(background);


                    if (ixctr == 1)
                    {
                        cvTest1.AddChartObject(background);
                    }
                    else if (ixctr == 2)
                    {
                        cvTest2.AddChartObject(background);
                    }
                    else if (ixctr == 3)
                    {
                        cvTest3.AddChartObject(background);
                    }
                    else if (ixctr == 4)
                    {
                        cvTest4.AddChartObject(background);
                    }
                    else if (ixctr == 5)
                    {
                        cv5PowerGraph1.AddChartObject(background);
                    }
                    else if (ixctr == 6)
                    {
                        cv6Power2Graph.AddChartObject(background);
                    }
                    else if (ixctr == 7)
                    {
                        cv7Power2Graph1.AddChartObject(background);
                    }
                    else if (ixctr == 8)
                    {
                        cv8Power3Graph.AddChartObject(background);
                    }
                    else if (ixctr == 9)
                    {
                        cv9Power3Graph1.AddChartObject(background);
                    }
                    else if (ixctr == 10)
                    {
                        cvTest5.AddChartObject(background);
                    }

                    {
                        string[] sarrLabels = m_sUnits.Split(new char[] { ',' });
                        PublicClass.y_Unit = sarrLabels[1];                       
                        xAxis = new LinearAxis(pTransform1, ChartObj.X_AXIS);
                        xAxis.CalcAutoAxis();
                        chartVu.AddChartObject(xAxis);

                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(xAxis);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(xAxis);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(xAxis);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(xAxis);
                        }
                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(xAxis);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(xAxis);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(xAxis);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(xAxis);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(xAxis);
                        }
                        else if (ixctr == 10)
                        {
                            cvTest5.AddChartObject(xAxis);
                        }



                        
                        if (bOverall)
                        {

                            objXTitle = new AxisTitle(xAxis, theFont, "");
                            chartVu.AddChartObject(objXTitle);

                            if (ixctr == 4)
                            {
                                cvTest4.AddChartObject(objXTitle);
                            }

                        }
                        else
                        {
                            if (m_sTimeAxis == "Sec")
                            {
                                objXTitle = new AxisTitle(xAxis, theFont, "Sec");
                                chartVu.AddChartObject(objXTitle);


                                if (ixctr == 1)
                                {
                                    cvTest1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 2)
                                {
                                    cvTest2.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 3)
                                {
                                    cvTest3.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 5)
                                {
                                    cv5PowerGraph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 6)
                                {
                                    cv6Power2Graph.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 7)
                                {
                                    cv7Power2Graph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 8)
                                {
                                    cv8Power3Graph.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 9)
                                {
                                    cv9Power3Graph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 4)
                                {
                                    cvTest4.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 10)
                                {
                                    cvTest5.AddChartObject(objXTitle);
                                }

                            }
                            else if (m_sTimeAxis == "Others")
                            {
                                objXTitle = new AxisTitle(xAxis, theFont, sarrLabels[0]);
                                chartVu.AddChartObject(objXTitle);


                                if (ixctr == 1)
                                {
                                    cvTest1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 2)
                                {
                                    cvTest2.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 3)
                                {
                                    cvTest3.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 5)
                                {
                                    cv5PowerGraph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 6)
                                {
                                    cv6Power2Graph.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 7)
                                {
                                    cv7Power2Graph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 8)
                                {
                                    cv8Power3Graph.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 9)
                                {
                                    cv9Power3Graph1.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 4)
                                {
                                    cvTest4.AddChartObject(objXTitle);
                                }
                                else if (ixctr == 10)
                                {
                                    cvTest5.AddChartObject(objXTitle);
                                }
                            }
                        }

                        yAxis = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                        yAxis.CalcAutoAxis();
                        chartVu.AddChartObject(yAxis);

                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(yAxis);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(yAxis);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(yAxis);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(yAxis);
                        }
                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(yAxis);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(yAxis);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(yAxis);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(yAxis);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(yAxis);
                        }
                        else if (ixctr == 10)
                        {
                            cvTest5.AddChartObject(yAxis);
                        }


                        
                        {
                            objYTitle = new AxisTitle(yAxis, theFont, sarrLabels[1]);                            
                            chartVu.AddChartObject(objYTitle);

                            if (ixctr == 1)
                            {
                                cvTest1.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 2)
                            {
                                cvTest2.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 3)
                            {
                                cvTest3.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 5)
                            {
                                cv5PowerGraph1.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 6)
                            {
                                cv6Power2Graph.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 7)
                            {
                                cv7Power2Graph1.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 8)
                            {
                                cv8Power3Graph.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 9)
                            {
                                cv9Power3Graph1.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 4)
                            {
                                cvTest4.AddChartObject(objYTitle);
                            }
                            else if (ixctr == 10)
                            {
                                cvTest5.AddChartObject(objYTitle);
                            }

                        }

                        int itime = 0;

                        if (bOverall)
                        {
                            string[] test = new string[sarrTime.Count];
                            // test[0] = " ";
                            for (itime = 0; itime < sarrTime.Count; itime++)
                            {
                                string stemp = (string)sarrTime[itime];
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



                            x1AxisLab = new StringAxisLabels(xAxis);
                            x1AxisLab.SetTextFont(theFont);
                            x1AxisLab.SetAxisLabelsStrings(test, itime + 1);

                            //x1AxisLab.SetAxisLabelsEnds(ChartObj.LABEL_ALL);

                            
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
                           
                            x1AxisLab.SetOverlapLabelMode(ChartObj.OVERLAP_LABEL_DRAW);
                            x1AxisLab.SetTextRotation(45);
                           



                            if (ixctr == 1)
                            {
                                cvTest1.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 2)
                            {
                                cvTest2.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 3)
                            {
                                cvTest3.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 4)
                            {
                                cvTest4.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 5)
                            {
                                cv5PowerGraph1.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 6)
                            {
                                cv6Power2Graph.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 7)
                            {
                                cv7Power2Graph1.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 8)
                            {
                                cv8Power3Graph.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 9)
                            {
                                cv9Power3Graph1.AddChartObject(x1AxisLab);
                            }
                            else if (ixctr == 10)
                            {
                                cvTest5.AddChartObject(x1AxisLab);
                            }






                            chartVu.AddChartObject(x1AxisLab);

                        }
                        else
                        {

                            if (xAxis.AxisTickSpace < 50.0 && (m_sTimeAxis == "Others" || m_sTimeAxis == "Hz"))
                            {
                                xAxis.AxisTickSpace = 50.0;
                            }

                            xAxisLab = new NumericAxisLabels(xAxis);
                            xAxisLab.SetTextFont(theFont);
                            chartVu.AddChartObject(xAxisLab);


                            if (ixctr == 1)
                            {
                                cvTest1.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 2)
                            {
                                cvTest2.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 3)
                            {
                                cvTest3.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 5)
                            {
                                cv5PowerGraph1.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 6)
                            {
                                cv6Power2Graph.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 7)
                            {
                                cv7Power2Graph1.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 8)
                            {
                                cv8Power3Graph.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 9)
                            {
                                cv9Power3Graph1.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 4)
                            {
                                cvTest4.AddChartObject(xAxisLab);
                            }
                            else if (ixctr == 10)
                            {
                                cvTest5.AddChartObject(xAxisLab);
                            }
                        }

                        yAxisLab = new NumericAxisLabels(yAxis);
                        yAxisLab.SetTextFont(theFont);
                        chartVu.AddChartObject(yAxisLab);

                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(yAxisLab);
                        }
                        else if (ixctr == 10)
                        {
                            cvTest5.AddChartObject(yAxisLab);
                        }


                        xgrid = new Grid(xAxis, yAxis, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                        chartVu.AddChartObject(xgrid);

                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(xgrid);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(xgrid);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(xgrid);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(xgrid);
                        }
                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(xgrid);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(xgrid);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(xgrid);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(xgrid);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(xgrid);
                        }
                        else if (ixctr == 10)
                        {
                            cvTest5.AddChartObject(xgrid);
                        }



                        ygrid = new Grid(xAxis, yAxis, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                        chartVu.AddChartObject(ygrid);


                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(ygrid);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(ygrid);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(ygrid);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(ygrid);
                        }
                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(ygrid);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(ygrid);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(ygrid);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(ygrid);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(ygrid);
                        }
                        else if (ixctr == 10)
                        {
                            cvTest5.AddChartObject(ygrid);
                        }

                    }
                    if (ColorCounter == 0)
                    {
                        attrib1 = new ChartAttribute(Color.DarkRed, 1, DashStyle.Solid);
                        thePlot1 = new SimpleLinePlot(pTransform1, datasetarray[0], attrib1);

                        NumericLabel objLabel = new NumericLabel();
                        objLabel.SetNumericValue(ixctr);
                        thePlot1.SetPlotLabelTemplate(objLabel);

                        thePlot1.PlotLabelTemplate.SetTextBgMode(true);
                        thePlot1.PlotLabelTemplate.SetTextString(sDateAndTime);
                        m_objGraphControl.LabelTime = sDateAndTime;
                        m_objGraphControl.LabelColor = Color.DarkRed;
                        ClickColor = Color.DarkRed;
                        chartVu.AddChartObject(thePlot1);

                        ColorCounter++;



                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(thePlot1);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(thePlot1);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(thePlot1);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(thePlot1);
                        }
                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(thePlot1);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(thePlot1);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(thePlot1);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(thePlot1);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(thePlot1);
                        }
                        else if (ixctr == 10)
                        {
                            cvTest5.AddChartObject(thePlot1);
                        }


                    }
                    else if (ColorCounter == 1)
                    {
                        attrib1 = new ChartAttribute(Color.DarkGreen, 1, DashStyle.Solid);
                        m_objPlotTwo = new SimpleLinePlot(pTransform1, datasetarray[0], attrib1);

                        NumericLabel objLabel = new NumericLabel();
                        objLabel.SetNumericValue(ixctr);
                        m_objPlotTwo.SetPlotLabelTemplate(objLabel);
                        m_objGraphControl.LabelTime = sDateAndTime;
                        m_objGraphControl.LabelColor = Color.DarkGreen;
                        ClickColor = Color.DarkGreen;
                        chartVu.AddChartObject(m_objPlotTwo);
                        ColorCounter++;

                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(m_objPlotTwo);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(m_objPlotTwo);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(m_objPlotTwo);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(m_objPlotTwo);
                        }
                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(m_objPlotTwo);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(m_objPlotTwo);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(m_objPlotTwo);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(m_objPlotTwo);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(m_objPlotTwo);
                        }
                        else if (ixctr == 10)
                        {
                            cvTest5.AddChartObject(m_objPlotTwo);
                        }


                    }
                    else if (ColorCounter == 2)
                    {
                        attrib1 = new ChartAttribute(Color.DarkBlue, 1, DashStyle.Solid);
                        m_objPlotThree = new SimpleLinePlot(pTransform1, datasetarray[0], attrib1);

                        NumericLabel objLabel = new NumericLabel();
                        objLabel.SetNumericValue(ixctr);
                        m_objPlotThree.SetPlotLabelTemplate(objLabel);

                        m_objGraphControl.LabelTime = sDateAndTime;
                        m_objGraphControl.LabelColor = Color.DarkBlue;
                        ClickColor = Color.DarkBlue;
                        chartVu.AddChartObject(m_objPlotThree);

                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(m_objPlotThree);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(m_objPlotThree);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(m_objPlotThree);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(m_objPlotThree);
                        }
                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(m_objPlotThree);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(m_objPlotThree);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(m_objPlotThree);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(m_objPlotThree);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(m_objPlotThree);
                        }
                        else if (ixctr == 10)
                        {
                            cvTest5.AddChartObject(m_objPlotThree);
                        }

                        ColorCounter++;
                    }
                    else if (ColorCounter == 3)
                    {
                        attrib1 = new ChartAttribute(Color.Black, 1, DashStyle.Solid);
                        m_objPlotFour = new SimpleLinePlot(pTransform1, datasetarray[0], attrib1);

                        NumericLabel objLabel = new NumericLabel();
                        objLabel.SetNumericValue(ixctr);
                        m_objPlotFour.SetPlotLabelTemplate(objLabel);

                        m_objGraphControl.LabelTime = sDateAndTime;
                        m_objGraphControl.LabelColor = Color.Tomato;
                        ClickColor = Color.Tomato;

                        chartVu.AddChartObject(m_objPlotFour);


                        if (ixctr == 1)
                        {
                            cvTest1.AddChartObject(m_objPlotFour);
                        }
                        else if (ixctr == 2)
                        {
                            cvTest2.AddChartObject(m_objPlotFour);
                        }
                        else if (ixctr == 3)
                        {
                            cvTest3.AddChartObject(m_objPlotFour);
                        }
                        else if (ixctr == 4)
                        {
                            cvTest4.AddChartObject(m_objPlotFour);
                        }
                        else if (ixctr == 5)
                        {
                            cv5PowerGraph1.AddChartObject(m_objPlotFour);
                        }
                        else if (ixctr == 6)
                        {
                            cv6Power2Graph.AddChartObject(m_objPlotFour);
                        }
                        else if (ixctr == 7)
                        {
                            cv7Power2Graph1.AddChartObject(m_objPlotFour);
                        }
                        else if (ixctr == 8)
                        {
                            cv8Power3Graph.AddChartObject(m_objPlotFour);
                        }
                        else if (ixctr == 9)
                        {
                            cv9Power3Graph1.AddChartObject(m_objPlotFour);
                        }

                        else if (ixctr == 10)
                        {
                            cvTest5.AddChartObject(m_objPlotFour);
                        }
                        ColorCounter = 0;
                    }
                   

                    chartVu.UpdateDraw();




                    if (ixctr == 1)
                    {
                        igrphctr = 1;
                        cvTest1 = chartVu;
                        //cvTest1.UpdateDraw();
                    }
                    else if (ixctr == 2)
                    {
                        igrphctr = 2;
                       
                        cvTest2.UpdateDraw();

                    }
                    else if (ixctr == 3)
                    {
                        igrphctr = 3;
                       
                        cvTest3.UpdateDraw();

                    }
                    else if (ixctr == 4)
                    {
                        cvTest4.UpdateDraw();
                    }
                    else if (ixctr == 5)
                    {
                        igrphctr = 5;
                      
                        cv5PowerGraph1.UpdateDraw();

                    }
                    else if (ixctr == 6)
                    {
                        igrphctr = 6;
                        
                        cv6Power2Graph.UpdateDraw();

                    }
                    else if (ixctr == 7)
                    {
                        igrphctr = 7;
                       
                        cv7Power2Graph1.UpdateDraw();

                    }
                    else if (ixctr == 8)
                    {
                        igrphctr = 8;
                       
                        cv8Power3Graph.UpdateDraw();

                    }
                    else if (ixctr == 9)
                    {
                        igrphctr = 9;
                       
                        cv9Power3Graph1.UpdateDraw();

                    }
                    else if (ixctr == 10)
                    {
                        igrphctr = 10;
                      
                        cvTest5.UpdateDraw();

                    }
                    x += 1;
                    if (x == 4)
                    {
                        x = 0;
                    }
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {

            }

        }

        public void InitializeChart(ArrayList arlstValues, ArrayList arlstDateTime, ArrayList arlstCounter)
        {
            int iCount = 0;


            try
            {
                iCount = arlstValues.Count;
                //m_obj2DGraphView = new C2DGraphView();

                if (m_obj2DGraphView != null)
                    m_obj2DGraphView.RemoveChartObjects();
                switch (iCount)
                {
                    case 1:

                        double[][] dFirstPlotArray = (double[][])arlstValues[0];
                        m_objFirstDataSet = new SimpleDataset("First", dFirstPlotArray[0], dFirstPlotArray[1]);
                        m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");//, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                        m_objDataSetArray = new SimpleDataset[1];
                        m_objDataSetArray[0] = m_objFirstDataSet;
                        m_obj2DGraphView.MainBaseControl = m_objMainControl;
                        
                        m_obj2DGraphView.Dates = arlstDateTime;
                        m_obj2DGraphView.Units = m_sUnits;
                        m_obj2DGraphView.DateTimedata = sarrTime;
                        m_obj2DGraphView.IsOverall = bOverall;
                        m_obj2DGraphView.CommonFunctionality(m_objDataSetArray);


                        break;
                    case 2:


                        double[][] dFPlotArry = (double[][])arlstValues[0];
                        double[][] dSPlotArry = (double[][])arlstValues[1];
                        m_objFirstDataSet = new SimpleDataset("First", dFPlotArry[0], dFPlotArry[1]);
                        m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                        m_objSecondDataSet = new SimpleDataset("Second", dSPlotArry[0], dSPlotArry[1]);
                        m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                        m_objDataSetArray = new SimpleDataset[2];

                        m_objDataSetArray[0] = m_objFirstDataSet;
                        m_objDataSetArray[1] = m_objSecondDataSet;
                        //m_obj2DGraphView.TwoDGraphControl = this;
                        //m_obj2DGraphView.BaseParentControl = m_objBaseControl;
                        m_obj2DGraphView.MainBaseControl = m_objMainControl;
                        m_obj2DGraphView.Dates = arlstDateTime;
                        m_obj2DGraphView.Units = m_sUnits;
                        m_obj2DGraphView.CommonFunctionality(m_objDataSetArray);


                        break;
                    case 3:

                        double[][] dFNewPlotArry = (double[][])arlstValues[0];
                        double[][] dSNewPlotArry = (double[][])arlstValues[1];
                        double[][] dTNewPlotArry = (double[][])arlstValues[2];

                        m_objFirstDataSet = new SimpleDataset("First", dFNewPlotArry[0], dFNewPlotArry[1]);
                        m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                        m_objSecondDataSet = new SimpleDataset("Second", dSNewPlotArry[0], dSNewPlotArry[1]);
                        m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                        m_objThirdDataSet = new SimpleDataset("Third", dTNewPlotArry[0], dTNewPlotArry[1]);
                        m_objThirdDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Third");

                        m_objDataSetArray = new SimpleDataset[3];

                        m_objDataSetArray[0] = m_objFirstDataSet;
                        m_objDataSetArray[1] = m_objSecondDataSet;
                        m_objDataSetArray[2] = m_objThirdDataSet;
                        //m_obj2DGraphView.TwoDGraphControl = this;
                        //m_obj2DGraphView.BaseParentControl = m_objBaseControl;
                        m_obj2DGraphView.MainBaseControl = m_objMainControl;
                        m_obj2DGraphView.Dates = arlstDateTime;
                        m_obj2DGraphView.Units = m_sUnits;
                        m_obj2DGraphView.CommonFunctionality(m_objDataSetArray);


                        break;
                    case 4:

                        double[][] dFFirstPlotArry = (double[][])arlstValues[0];
                        double[][] dFSecondPlotArry = (double[][])arlstValues[1];
                        double[][] dFThirdPlotArry = (double[][])arlstValues[2];
                        double[][] dFFourthPlotArry = (double[][])arlstValues[3];

                        m_objFirstDataSet = new SimpleDataset("First", dFFirstPlotArry[0], dFFirstPlotArry[1]);
                        m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                        m_objSecondDataSet = new SimpleDataset("Second", dFSecondPlotArry[0], dFSecondPlotArry[1]);
                        m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                        m_objThirdDataSet = new SimpleDataset("Third", dFThirdPlotArry[0], dFThirdPlotArry[1]);
                        m_objThirdDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Third");

                        m_objFourthDataSet = new SimpleDataset("Fourth", dFFourthPlotArry[0], dFFourthPlotArry[1]);
                        m_objFourthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fourth");

                        m_objDataSetArray = new SimpleDataset[4];

                        m_objDataSetArray[0] = m_objFirstDataSet;
                        m_objDataSetArray[1] = m_objSecondDataSet;
                        m_objDataSetArray[2] = m_objThirdDataSet;
                        m_objDataSetArray[3] = m_objFourthDataSet;
                        //m_obj2DGraphView.TwoDGraphControl = this;
                        //m_obj2DGraphView.BaseParentControl = m_objBaseControl;
                        m_obj2DGraphView.MainBaseControl = m_objMainControl;
                        m_obj2DGraphView.Dates = arlstDateTime;
                        m_obj2DGraphView.Units = m_sUnits;
                        m_obj2DGraphView.CommonFunctionality(m_objDataSetArray);

                        break;
                    case 5:
                        CaseMultiOne(arlstValues, arlstDateTime, arlstCounter);
                        break;
                    case 6:
                        CaseMultiTwo(arlstValues, arlstDateTime, arlstCounter);
                        break;
                    case 7:
                        CaseMultiThree(arlstValues, arlstDateTime, arlstCounter);
                        break;
                    case 8:
                        CaseMultiFour(arlstValues, arlstDateTime, arlstCounter);
                        break;
                    case 9:
                        CaseMultiFive(arlstValues, arlstDateTime, arlstCounter);
                        break;
                    case 10:
                        CaseMultiSix(arlstValues, arlstDateTime, arlstCounter);
                        break;

                }
            }
            catch
            {
                throw;
            }
        }
        public void InitializeChart(ArrayList arlstValues, ArrayList arlstDateTime, ArrayList arlstCounter, ArrayList ColorTag)
        {
            int iCount = 0;


            try
            {
                iCount = arlstValues.Count;


                if (m_obj2DGraphView != null)
                    m_obj2DGraphView.RemoveChartObjects();
                switch (iCount)
                {
                    case 1:

                        double[][] dFirstPlotArray = (double[][])arlstValues[0];
                        m_objFirstDataSet = new SimpleDataset("First", dFirstPlotArray[0], dFirstPlotArray[1]);
                        m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");//, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                        m_objDataSetArray = new SimpleDataset[1];
                        m_objDataSetArray[0] = m_objFirstDataSet;
                        m_obj2DGraphView.MainBaseControl = m_objMainControl;
                       
                        m_obj2DGraphView.Dates = arlstDateTime;
                        m_obj2DGraphView.Units = m_sUnits;
                        m_obj2DGraphView.DateTimedata = sarrTime;
                        m_obj2DGraphView.IsOverall = bOverall;
                        m_obj2DGraphView.CommonFunctionality(m_objDataSetArray, ColorTag);


                        break;
                    case 2:


                        double[][] dFPlotArry = (double[][])arlstValues[0];
                        double[][] dSPlotArry = (double[][])arlstValues[1];
                        m_objFirstDataSet = new SimpleDataset("First", dFPlotArry[0], dFPlotArry[1]);
                        m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                        m_objSecondDataSet = new SimpleDataset("Second", dSPlotArry[0], dSPlotArry[1]);
                        m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                        m_objDataSetArray = new SimpleDataset[2];

                        m_objDataSetArray[0] = m_objFirstDataSet;
                        m_objDataSetArray[1] = m_objSecondDataSet;
                       
                        m_obj2DGraphView.MainBaseControl = m_objMainControl;
                        m_obj2DGraphView.Dates = arlstDateTime;
                        m_obj2DGraphView.Units = m_sUnits;
                        m_obj2DGraphView.CommonFunctionality(m_objDataSetArray, ColorTag);


                        break;
                    case 3:

                        double[][] dFNewPlotArry = (double[][])arlstValues[0];
                        double[][] dSNewPlotArry = (double[][])arlstValues[1];
                        double[][] dTNewPlotArry = (double[][])arlstValues[2];

                        m_objFirstDataSet = new SimpleDataset("First", dFNewPlotArry[0], dFNewPlotArry[1]);
                        m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                        m_objSecondDataSet = new SimpleDataset("Second", dSNewPlotArry[0], dSNewPlotArry[1]);
                        m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                        m_objThirdDataSet = new SimpleDataset("Third", dTNewPlotArry[0], dTNewPlotArry[1]);
                        m_objThirdDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Third");

                        m_objDataSetArray = new SimpleDataset[3];

                        m_objDataSetArray[0] = m_objFirstDataSet;
                        m_objDataSetArray[1] = m_objSecondDataSet;
                        m_objDataSetArray[2] = m_objThirdDataSet;
                       
                        m_obj2DGraphView.MainBaseControl = m_objMainControl;
                        m_obj2DGraphView.Dates = arlstDateTime;
                        m_obj2DGraphView.Units = m_sUnits;
                        m_obj2DGraphView.CommonFunctionality(m_objDataSetArray, ColorTag);


                        break;
                    case 4:

                        double[][] dFFirstPlotArry = (double[][])arlstValues[0];
                        double[][] dFSecondPlotArry = (double[][])arlstValues[1];
                        double[][] dFThirdPlotArry = (double[][])arlstValues[2];
                        double[][] dFFourthPlotArry = (double[][])arlstValues[3];

                        m_objFirstDataSet = new SimpleDataset("First", dFFirstPlotArry[0], dFFirstPlotArry[1]);
                        m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                        m_objSecondDataSet = new SimpleDataset("Second", dFSecondPlotArry[0], dFSecondPlotArry[1]);
                        m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                        m_objThirdDataSet = new SimpleDataset("Third", dFThirdPlotArry[0], dFThirdPlotArry[1]);
                        m_objThirdDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Third");

                        m_objFourthDataSet = new SimpleDataset("Fourth", dFFourthPlotArry[0], dFFourthPlotArry[1]);
                        m_objFourthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fourth");

                        m_objDataSetArray = new SimpleDataset[4];

                        m_objDataSetArray[0] = m_objFirstDataSet;
                        m_objDataSetArray[1] = m_objSecondDataSet;
                        m_objDataSetArray[2] = m_objThirdDataSet;
                        m_objDataSetArray[3] = m_objFourthDataSet;
                       
                        m_obj2DGraphView.MainBaseControl = m_objMainControl;
                        m_obj2DGraphView.Dates = arlstDateTime;
                        m_obj2DGraphView.Units = m_sUnits;
                        m_obj2DGraphView.CommonFunctionality(m_objDataSetArray, ColorTag);

                        break;
                    case 5:
                        CaseMultiOne(arlstValues, arlstDateTime, arlstCounter, ColorTag);
                        break;
                    case 6:
                        CaseMultiTwo(arlstValues, arlstDateTime, arlstCounter, ColorTag);
                        break;
                    case 7:
                        CaseMultiThree(arlstValues, arlstDateTime, arlstCounter, ColorTag);
                        break;
                    case 8:
                        CaseMultiFour(arlstValues, arlstDateTime, arlstCounter, ColorTag);
                        break;
                    case 9:
                        CaseMultiFive(arlstValues, arlstDateTime, arlstCounter, ColorTag);
                        break;
                    case 10:
                        CaseMultiSix(arlstValues, arlstDateTime, arlstCounter, ColorTag);
                        break;

                }
            }
            catch
            {
                throw;
            }
        }

        SimpleDataset m_objFifthDataSet = null;
        SimpleDataset m_objSixthDataSet = null;
        SimpleDataset m_objSeventhDataSet = null;
        SimpleDataset m_objEighthDataSet = null;
        SimpleDataset m_objNinthDataSet = null;
        SimpleDataset m_objTenthDataSet = null;

        private void CaseMultiOne(ArrayList arlstValues, ArrayList arlstDateTime, ArrayList arlstCounter)
        {
            try
            {

                double[][] dFFirstPlotArry = (double[][])arlstValues[0];
                double[][] dFSecondPlotArry = (double[][])arlstValues[1];
                double[][] dFThirdPlotArry = (double[][])arlstValues[2];
                double[][] dFFourthPlotArry = (double[][])arlstValues[3];
                double[][] dFFifthPlotArray = (double[][])arlstValues[4];

                m_objFirstDataSet = new SimpleDataset("First", dFFirstPlotArry[0], dFFirstPlotArry[1]);
                m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                m_objSecondDataSet = new SimpleDataset("Second", dFSecondPlotArry[0], dFSecondPlotArry[1]);
                m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                m_objThirdDataSet = new SimpleDataset("Third", dFThirdPlotArry[0], dFThirdPlotArry[1]);
                m_objThirdDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Third");

                m_objFourthDataSet = new SimpleDataset("Fourth", dFFourthPlotArry[0], dFFourthPlotArry[1]);
                m_objFourthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fourth");

                m_objFifthDataSet = new SimpleDataset("Fifth", dFFifthPlotArray[0], dFFifthPlotArray[1]);
                m_objFifthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fifth");
                m_objDataSetArray = new SimpleDataset[5];

                m_objDataSetArray[0] = m_objFirstDataSet;
                m_objDataSetArray[1] = m_objSecondDataSet;
                m_objDataSetArray[2] = m_objThirdDataSet;
                m_objDataSetArray[3] = m_objFourthDataSet;
                m_objDataSetArray[4] = m_objFifthDataSet;
                
                m_obj2DGraphView.MainBaseControl = m_objMainControl;
                m_obj2DGraphView.Dates = arlstDateTime;
                m_obj2DGraphView.Units = m_sUnits;
                m_obj2DGraphView.CommonFunctionality(m_objDataSetArray);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void CaseMultiTwo(ArrayList arlstValues, ArrayList arlstDateTime, ArrayList arlstCounter)
        {
            try
            {

                double[][] dFFirstPlotArry = (double[][])arlstValues[0];
                double[][] dFSecondPlotArry = (double[][])arlstValues[1];
                double[][] dFThirdPlotArry = (double[][])arlstValues[2];
                double[][] dFFourthPlotArry = (double[][])arlstValues[3];
                double[][] dFFifthPlotArray = (double[][])arlstValues[4];
                double[][] dFSixthPlotArray = (double[][])arlstValues[5];

                m_objFirstDataSet = new SimpleDataset("First", dFFirstPlotArry[0], dFFirstPlotArry[1]);
                m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                m_objSecondDataSet = new SimpleDataset("Second", dFSecondPlotArry[0], dFSecondPlotArry[1]);
                m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                m_objThirdDataSet = new SimpleDataset("Third", dFThirdPlotArry[0], dFThirdPlotArry[1]);
                m_objThirdDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Third");

                m_objFourthDataSet = new SimpleDataset("Fourth", dFFourthPlotArry[0], dFFourthPlotArry[1]);
                m_objFourthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fourth");

                m_objFifthDataSet = new SimpleDataset("Fifth", dFFifthPlotArray[0], dFFifthPlotArray[1]);
                m_objFifthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fifth");

                m_objSixthDataSet = new SimpleDataset("Sixth", dFSixthPlotArray[0], dFSixthPlotArray[1]);
                m_objSixthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Sixth");

                m_objDataSetArray = new SimpleDataset[6];

                m_objDataSetArray[0] = m_objFirstDataSet;
                m_objDataSetArray[1] = m_objSecondDataSet;
                m_objDataSetArray[2] = m_objThirdDataSet;
                m_objDataSetArray[3] = m_objFourthDataSet;
                m_objDataSetArray[4] = m_objFifthDataSet;
                m_objDataSetArray[5] = m_objSixthDataSet;
                
                m_obj2DGraphView.MainBaseControl = m_objMainControl;
                m_obj2DGraphView.Dates = arlstDateTime;
                m_obj2DGraphView.Units = m_sUnits;
                m_obj2DGraphView.CommonFunctionality(m_objDataSetArray);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void CaseMultiThree(ArrayList arlstValues, ArrayList arlstDateTime, ArrayList arlstCounter)
        {
            try
            {

                double[][] dFFirstPlotArry = (double[][])arlstValues[0];
                double[][] dFSecondPlotArry = (double[][])arlstValues[1];
                double[][] dFThirdPlotArry = (double[][])arlstValues[2];
                double[][] dFFourthPlotArry = (double[][])arlstValues[3];
                double[][] dFFifthPlotArray = (double[][])arlstValues[4];
                double[][] dFSixthPlotArray = (double[][])arlstValues[5];
                double[][] dFSeventhPlotArray = (double[][])arlstValues[6];

                m_objFirstDataSet = new SimpleDataset("First", dFFirstPlotArry[0], dFFirstPlotArry[1]);
                m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                m_objSecondDataSet = new SimpleDataset("Second", dFSecondPlotArry[0], dFSecondPlotArry[1]);
                m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                m_objThirdDataSet = new SimpleDataset("Third", dFThirdPlotArry[0], dFThirdPlotArry[1]);
                m_objThirdDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Third");

                m_objFourthDataSet = new SimpleDataset("Fourth", dFFourthPlotArry[0], dFFourthPlotArry[1]);
                m_objFourthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fourth");

                m_objFifthDataSet = new SimpleDataset("Fifth", dFFifthPlotArray[0], dFFifthPlotArray[1]);
                m_objFifthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fifth");

                m_objSixthDataSet = new SimpleDataset("Sixth", dFSixthPlotArray[0], dFSixthPlotArray[1]);
                m_objSixthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Sixth");

                m_objSeventhDataSet = new SimpleDataset("Seventh", dFSeventhPlotArray[0], dFSeventhPlotArray[1]);
                m_objSeventhDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Seventh");

                m_objDataSetArray = new SimpleDataset[7];

                m_objDataSetArray[0] = m_objFirstDataSet;
                m_objDataSetArray[1] = m_objSecondDataSet;
                m_objDataSetArray[2] = m_objThirdDataSet;
                m_objDataSetArray[3] = m_objFourthDataSet;
                m_objDataSetArray[4] = m_objFifthDataSet;
                m_objDataSetArray[5] = m_objSixthDataSet;
                m_objDataSetArray[6] = m_objSeventhDataSet;
                
                m_obj2DGraphView.MainBaseControl = m_objMainControl;
                m_obj2DGraphView.Dates = arlstDateTime;
                m_obj2DGraphView.Units = m_sUnits;
                m_obj2DGraphView.CommonFunctionality(m_objDataSetArray);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void CaseMultiFour(ArrayList arlstValues, ArrayList arlstDateTime, ArrayList arlstCounter)
        {
            try
            {

                double[][] dFFirstPlotArry = (double[][])arlstValues[0];
                double[][] dFSecondPlotArry = (double[][])arlstValues[1];
                double[][] dFThirdPlotArry = (double[][])arlstValues[2];
                double[][] dFFourthPlotArry = (double[][])arlstValues[3];
                double[][] dFFifthPlotArray = (double[][])arlstValues[4];
                double[][] dFSixthPlotArray = (double[][])arlstValues[5];
                double[][] dFSeventhPlotArray = (double[][])arlstValues[6];
                double[][] dFEighthPlotArray = (double[][])arlstValues[7];

                m_objFirstDataSet = new SimpleDataset("First", dFFirstPlotArry[0], dFFirstPlotArry[1]);
                m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                m_objSecondDataSet = new SimpleDataset("Second", dFSecondPlotArry[0], dFSecondPlotArry[1]);
                m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                m_objThirdDataSet = new SimpleDataset("Third", dFThirdPlotArry[0], dFThirdPlotArry[1]);
                m_objThirdDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Third");

                m_objFourthDataSet = new SimpleDataset("Fourth", dFFourthPlotArry[0], dFFourthPlotArry[1]);
                m_objFourthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fourth");

                m_objFifthDataSet = new SimpleDataset("Fifth", dFFifthPlotArray[0], dFFifthPlotArray[1]);
                m_objFifthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fifth");

                m_objSixthDataSet = new SimpleDataset("Sixth", dFSixthPlotArray[0], dFSixthPlotArray[1]);
                m_objSixthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Sixth");

                m_objSeventhDataSet = new SimpleDataset("Seventh", dFSeventhPlotArray[0], dFSeventhPlotArray[1]);
                m_objSeventhDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Seventh");

                m_objEighthDataSet = new SimpleDataset("Eighth", dFEighthPlotArray[0], dFEighthPlotArray[1]);
                m_objEighthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Eighth");

                m_objDataSetArray = new SimpleDataset[8];

                m_objDataSetArray[0] = m_objFirstDataSet;
                m_objDataSetArray[1] = m_objSecondDataSet;
                m_objDataSetArray[2] = m_objThirdDataSet;
                m_objDataSetArray[3] = m_objFourthDataSet;
                m_objDataSetArray[4] = m_objFifthDataSet;
                m_objDataSetArray[5] = m_objSixthDataSet;
                m_objDataSetArray[6] = m_objSeventhDataSet;
                m_objDataSetArray[7] = m_objEighthDataSet;
               
                m_obj2DGraphView.MainBaseControl = m_objMainControl;
                m_obj2DGraphView.Dates = arlstDateTime;
                m_obj2DGraphView.Units = m_sUnits;
                m_obj2DGraphView.CommonFunctionality(m_objDataSetArray);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void CaseMultiFive(ArrayList arlstValues, ArrayList arlstDateTime, ArrayList arlstCounter)
        {
            try
            {

                double[][] dFFirstPlotArry = (double[][])arlstValues[0];
                double[][] dFSecondPlotArry = (double[][])arlstValues[1];
                double[][] dFThirdPlotArry = (double[][])arlstValues[2];
                double[][] dFFourthPlotArry = (double[][])arlstValues[3];
                double[][] dFFifthPlotArray = (double[][])arlstValues[4];
                double[][] dFSixthPlotArray = (double[][])arlstValues[5];
                double[][] dFSeventhPlotArray = (double[][])arlstValues[6];
                double[][] dFEighthPlotArray = (double[][])arlstValues[7];
                double[][] dfNinthPlotArray = (double[][])arlstValues[8];

                m_objFirstDataSet = new SimpleDataset("First", dFFirstPlotArry[0], dFFirstPlotArry[1]);
                m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                m_objSecondDataSet = new SimpleDataset("Second", dFSecondPlotArry[0], dFSecondPlotArry[1]);
                m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                m_objThirdDataSet = new SimpleDataset("Third", dFThirdPlotArry[0], dFThirdPlotArry[1]);
                m_objThirdDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Third");

                m_objFourthDataSet = new SimpleDataset("Fourth", dFFourthPlotArry[0], dFFourthPlotArry[1]);
                m_objFourthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fourth");

                m_objFifthDataSet = new SimpleDataset("Fifth", dFFifthPlotArray[0], dFFifthPlotArray[1]);
                m_objFifthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fifth");

                m_objSixthDataSet = new SimpleDataset("Sixth", dFSixthPlotArray[0], dFSixthPlotArray[1]);
                m_objSixthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Sixth");

                m_objSeventhDataSet = new SimpleDataset("Seventh", dFSeventhPlotArray[0], dFSeventhPlotArray[1]);
                m_objSeventhDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Seventh");

                m_objEighthDataSet = new SimpleDataset("Eighth", dFEighthPlotArray[0], dFEighthPlotArray[1]);
                m_objEighthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Eighth");

                m_objNinthDataSet = new SimpleDataset("Ninth", dfNinthPlotArray[0], dfNinthPlotArray[1]);
                m_objNinthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Ninth");

                m_objDataSetArray = new SimpleDataset[9];

                m_objDataSetArray[0] = m_objFirstDataSet;
                m_objDataSetArray[1] = m_objSecondDataSet;
                m_objDataSetArray[2] = m_objThirdDataSet;
                m_objDataSetArray[3] = m_objFourthDataSet;
                m_objDataSetArray[4] = m_objFifthDataSet;
                m_objDataSetArray[5] = m_objSixthDataSet;
                m_objDataSetArray[6] = m_objSeventhDataSet;
                m_objDataSetArray[7] = m_objEighthDataSet;
                m_objDataSetArray[8] = m_objNinthDataSet;
               
                m_obj2DGraphView.MainBaseControl = m_objMainControl;
                m_obj2DGraphView.Dates = arlstDateTime;
                m_obj2DGraphView.Units = m_sUnits;
                m_obj2DGraphView.CommonFunctionality(m_objDataSetArray);


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void CaseMultiSix(ArrayList arlstValues, ArrayList arlstDateTime, ArrayList arlstCounter)
        {
            try
            {

                double[][] dFFirstPlotArry = (double[][])arlstValues[0];
                double[][] dFSecondPlotArry = (double[][])arlstValues[1];
                double[][] dFThirdPlotArry = (double[][])arlstValues[2];
                double[][] dFFourthPlotArry = (double[][])arlstValues[3];
                double[][] dFFifthPlotArray = (double[][])arlstValues[4];
                double[][] dFSixthPlotArray = (double[][])arlstValues[5];
                double[][] dFSeventhPlotArray = (double[][])arlstValues[6];
                double[][] dFEighthPlotArray = (double[][])arlstValues[7];
                double[][] dfNinthPlotArray = (double[][])arlstValues[8];
                double[][] dFTenthDataSet = (double[][])arlstValues[9];

                m_objFirstDataSet = new SimpleDataset("First", dFFirstPlotArry[0], dFFirstPlotArry[1]);
                m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                m_objSecondDataSet = new SimpleDataset("Second", dFSecondPlotArry[0], dFSecondPlotArry[1]);
                m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                m_objThirdDataSet = new SimpleDataset("Third", dFThirdPlotArry[0], dFThirdPlotArry[1]);
                m_objThirdDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Third");

                m_objFourthDataSet = new SimpleDataset("Fourth", dFFourthPlotArry[0], dFFourthPlotArry[1]);
                m_objFourthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fourth");

                m_objFifthDataSet = new SimpleDataset("Fifth", dFFifthPlotArray[0], dFFifthPlotArray[1]);
                m_objFifthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fifth");

                m_objSixthDataSet = new SimpleDataset("Sixth", dFSixthPlotArray[0], dFSixthPlotArray[1]);
                m_objSixthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Sixth");

                m_objSeventhDataSet = new SimpleDataset("Seventh", dFSeventhPlotArray[0], dFSeventhPlotArray[1]);
                m_objSeventhDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Seventh");

                m_objEighthDataSet = new SimpleDataset("Eighth", dFEighthPlotArray[0], dFEighthPlotArray[1]);
                m_objEighthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Eighth");

                m_objNinthDataSet = new SimpleDataset("Ninth", dfNinthPlotArray[0], dfNinthPlotArray[1]);
                m_objNinthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Ninth");

                m_objTenthDataSet = new SimpleDataset("Tenth", dFTenthDataSet[0], dFTenthDataSet[1]);
                m_objTenthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Tenth");

                m_objDataSetArray = new SimpleDataset[10];

                m_objDataSetArray[0] = m_objFirstDataSet;
                m_objDataSetArray[1] = m_objSecondDataSet;
                m_objDataSetArray[2] = m_objThirdDataSet;
                m_objDataSetArray[3] = m_objFourthDataSet;
                m_objDataSetArray[4] = m_objFifthDataSet;
                m_objDataSetArray[5] = m_objSixthDataSet;
                m_objDataSetArray[6] = m_objSeventhDataSet;
                m_objDataSetArray[7] = m_objEighthDataSet;
                m_objDataSetArray[8] = m_objNinthDataSet;
                m_objDataSetArray[9] = m_objTenthDataSet;
                
                m_obj2DGraphView.MainBaseControl = m_objMainControl;
                m_obj2DGraphView.Dates = arlstDateTime;
                m_obj2DGraphView.Units = m_sUnits;
                m_obj2DGraphView.CommonFunctionality(m_objDataSetArray);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }


        private void CaseMultiOne(ArrayList arlstValues, ArrayList arlstDateTime, ArrayList arlstCounter, ArrayList ColorTag)
        {
            try
            {

                double[][] dFFirstPlotArry = (double[][])arlstValues[0];
                double[][] dFSecondPlotArry = (double[][])arlstValues[1];
                double[][] dFThirdPlotArry = (double[][])arlstValues[2];
                double[][] dFFourthPlotArry = (double[][])arlstValues[3];
                double[][] dFFifthPlotArray = (double[][])arlstValues[4];

                m_objFirstDataSet = new SimpleDataset("First", dFFirstPlotArry[0], dFFirstPlotArry[1]);
                m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                m_objSecondDataSet = new SimpleDataset("Second", dFSecondPlotArry[0], dFSecondPlotArry[1]);
                m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                m_objThirdDataSet = new SimpleDataset("Third", dFThirdPlotArry[0], dFThirdPlotArry[1]);
                m_objThirdDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Third");

                m_objFourthDataSet = new SimpleDataset("Fourth", dFFourthPlotArry[0], dFFourthPlotArry[1]);
                m_objFourthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fourth");

                m_objFifthDataSet = new SimpleDataset("Fifth", dFFifthPlotArray[0], dFFifthPlotArray[1]);
                m_objFifthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fifth");
                m_objDataSetArray = new SimpleDataset[5];

                m_objDataSetArray[0] = m_objFirstDataSet;
                m_objDataSetArray[1] = m_objSecondDataSet;
                m_objDataSetArray[2] = m_objThirdDataSet;
                m_objDataSetArray[3] = m_objFourthDataSet;
                m_objDataSetArray[4] = m_objFifthDataSet;
               
                m_obj2DGraphView.MainBaseControl = m_objMainControl;
                m_obj2DGraphView.Dates = arlstDateTime;
                m_obj2DGraphView.Units = m_sUnits;
                m_obj2DGraphView.CommonFunctionality(m_objDataSetArray, ColorTag);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void CaseMultiTwo(ArrayList arlstValues, ArrayList arlstDateTime, ArrayList arlstCounter, ArrayList ColorTag)
        {
            try
            {

                double[][] dFFirstPlotArry = (double[][])arlstValues[0];
                double[][] dFSecondPlotArry = (double[][])arlstValues[1];
                double[][] dFThirdPlotArry = (double[][])arlstValues[2];
                double[][] dFFourthPlotArry = (double[][])arlstValues[3];
                double[][] dFFifthPlotArray = (double[][])arlstValues[4];
                double[][] dFSixthPlotArray = (double[][])arlstValues[5];

                m_objFirstDataSet = new SimpleDataset("First", dFFirstPlotArry[0], dFFirstPlotArry[1]);
                m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                m_objSecondDataSet = new SimpleDataset("Second", dFSecondPlotArry[0], dFSecondPlotArry[1]);
                m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                m_objThirdDataSet = new SimpleDataset("Third", dFThirdPlotArry[0], dFThirdPlotArry[1]);
                m_objThirdDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Third");

                m_objFourthDataSet = new SimpleDataset("Fourth", dFFourthPlotArry[0], dFFourthPlotArry[1]);
                m_objFourthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fourth");

                m_objFifthDataSet = new SimpleDataset("Fifth", dFFifthPlotArray[0], dFFifthPlotArray[1]);
                m_objFifthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fifth");

                m_objSixthDataSet = new SimpleDataset("Sixth", dFSixthPlotArray[0], dFSixthPlotArray[1]);
                m_objSixthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Sixth");

                m_objDataSetArray = new SimpleDataset[6];

                m_objDataSetArray[0] = m_objFirstDataSet;
                m_objDataSetArray[1] = m_objSecondDataSet;
                m_objDataSetArray[2] = m_objThirdDataSet;
                m_objDataSetArray[3] = m_objFourthDataSet;
                m_objDataSetArray[4] = m_objFifthDataSet;
                m_objDataSetArray[5] = m_objSixthDataSet;
                
                m_obj2DGraphView.MainBaseControl = m_objMainControl;
                m_obj2DGraphView.Dates = arlstDateTime;
                m_obj2DGraphView.Units = m_sUnits;
                m_obj2DGraphView.CommonFunctionality(m_objDataSetArray, ColorTag);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void CaseMultiThree(ArrayList arlstValues, ArrayList arlstDateTime, ArrayList arlstCounter, ArrayList ColorTag)
        {
            try
            {

                double[][] dFFirstPlotArry = (double[][])arlstValues[0];
                double[][] dFSecondPlotArry = (double[][])arlstValues[1];
                double[][] dFThirdPlotArry = (double[][])arlstValues[2];
                double[][] dFFourthPlotArry = (double[][])arlstValues[3];
                double[][] dFFifthPlotArray = (double[][])arlstValues[4];
                double[][] dFSixthPlotArray = (double[][])arlstValues[5];
                double[][] dFSeventhPlotArray = (double[][])arlstValues[6];

                m_objFirstDataSet = new SimpleDataset("First", dFFirstPlotArry[0], dFFirstPlotArry[1]);
                m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                m_objSecondDataSet = new SimpleDataset("Second", dFSecondPlotArry[0], dFSecondPlotArry[1]);
                m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                m_objThirdDataSet = new SimpleDataset("Third", dFThirdPlotArry[0], dFThirdPlotArry[1]);
                m_objThirdDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Third");

                m_objFourthDataSet = new SimpleDataset("Fourth", dFFourthPlotArry[0], dFFourthPlotArry[1]);
                m_objFourthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fourth");

                m_objFifthDataSet = new SimpleDataset("Fifth", dFFifthPlotArray[0], dFFifthPlotArray[1]);
                m_objFifthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fifth");

                m_objSixthDataSet = new SimpleDataset("Sixth", dFSixthPlotArray[0], dFSixthPlotArray[1]);
                m_objSixthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Sixth");

                m_objSeventhDataSet = new SimpleDataset("Seventh", dFSeventhPlotArray[0], dFSeventhPlotArray[1]);
                m_objSeventhDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Seventh");

                m_objDataSetArray = new SimpleDataset[7];

                m_objDataSetArray[0] = m_objFirstDataSet;
                m_objDataSetArray[1] = m_objSecondDataSet;
                m_objDataSetArray[2] = m_objThirdDataSet;
                m_objDataSetArray[3] = m_objFourthDataSet;
                m_objDataSetArray[4] = m_objFifthDataSet;
                m_objDataSetArray[5] = m_objSixthDataSet;
                m_objDataSetArray[6] = m_objSeventhDataSet;
               
                m_obj2DGraphView.MainBaseControl = m_objMainControl;
                m_obj2DGraphView.Dates = arlstDateTime;
                m_obj2DGraphView.Units = m_sUnits;
                m_obj2DGraphView.CommonFunctionality(m_objDataSetArray, ColorTag);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void CaseMultiFour(ArrayList arlstValues, ArrayList arlstDateTime, ArrayList arlstCounter, ArrayList ColorTag)
        {
            try
            {

                double[][] dFFirstPlotArry = (double[][])arlstValues[0];
                double[][] dFSecondPlotArry = (double[][])arlstValues[1];
                double[][] dFThirdPlotArry = (double[][])arlstValues[2];
                double[][] dFFourthPlotArry = (double[][])arlstValues[3];
                double[][] dFFifthPlotArray = (double[][])arlstValues[4];
                double[][] dFSixthPlotArray = (double[][])arlstValues[5];
                double[][] dFSeventhPlotArray = (double[][])arlstValues[6];
                double[][] dFEighthPlotArray = (double[][])arlstValues[7];

                m_objFirstDataSet = new SimpleDataset("First", dFFirstPlotArry[0], dFFirstPlotArry[1]);
                m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                m_objSecondDataSet = new SimpleDataset("Second", dFSecondPlotArry[0], dFSecondPlotArry[1]);
                m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                m_objThirdDataSet = new SimpleDataset("Third", dFThirdPlotArry[0], dFThirdPlotArry[1]);
                m_objThirdDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Third");

                m_objFourthDataSet = new SimpleDataset("Fourth", dFFourthPlotArry[0], dFFourthPlotArry[1]);
                m_objFourthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fourth");

                m_objFifthDataSet = new SimpleDataset("Fifth", dFFifthPlotArray[0], dFFifthPlotArray[1]);
                m_objFifthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fifth");

                m_objSixthDataSet = new SimpleDataset("Sixth", dFSixthPlotArray[0], dFSixthPlotArray[1]);
                m_objSixthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Sixth");

                m_objSeventhDataSet = new SimpleDataset("Seventh", dFSeventhPlotArray[0], dFSeventhPlotArray[1]);
                m_objSeventhDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Seventh");

                m_objEighthDataSet = new SimpleDataset("Eighth", dFEighthPlotArray[0], dFEighthPlotArray[1]);
                m_objEighthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Eighth");

                m_objDataSetArray = new SimpleDataset[8];

                m_objDataSetArray[0] = m_objFirstDataSet;
                m_objDataSetArray[1] = m_objSecondDataSet;
                m_objDataSetArray[2] = m_objThirdDataSet;
                m_objDataSetArray[3] = m_objFourthDataSet;
                m_objDataSetArray[4] = m_objFifthDataSet;
                m_objDataSetArray[5] = m_objSixthDataSet;
                m_objDataSetArray[6] = m_objSeventhDataSet;
                m_objDataSetArray[7] = m_objEighthDataSet;
              
                m_obj2DGraphView.MainBaseControl = m_objMainControl;
                m_obj2DGraphView.Dates = arlstDateTime;
                m_obj2DGraphView.Units = m_sUnits;
                m_obj2DGraphView.CommonFunctionality(m_objDataSetArray, ColorTag);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void CaseMultiFive(ArrayList arlstValues, ArrayList arlstDateTime, ArrayList arlstCounter, ArrayList ColorTag)
        {
            try
            {

                double[][] dFFirstPlotArry = (double[][])arlstValues[0];
                double[][] dFSecondPlotArry = (double[][])arlstValues[1];
                double[][] dFThirdPlotArry = (double[][])arlstValues[2];
                double[][] dFFourthPlotArry = (double[][])arlstValues[3];
                double[][] dFFifthPlotArray = (double[][])arlstValues[4];
                double[][] dFSixthPlotArray = (double[][])arlstValues[5];
                double[][] dFSeventhPlotArray = (double[][])arlstValues[6];
                double[][] dFEighthPlotArray = (double[][])arlstValues[7];
                double[][] dfNinthPlotArray = (double[][])arlstValues[8];

                m_objFirstDataSet = new SimpleDataset("First", dFFirstPlotArry[0], dFFirstPlotArry[1]);
                m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                m_objSecondDataSet = new SimpleDataset("Second", dFSecondPlotArry[0], dFSecondPlotArry[1]);
                m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                m_objThirdDataSet = new SimpleDataset("Third", dFThirdPlotArry[0], dFThirdPlotArry[1]);
                m_objThirdDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Third");

                m_objFourthDataSet = new SimpleDataset("Fourth", dFFourthPlotArry[0], dFFourthPlotArry[1]);
                m_objFourthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fourth");

                m_objFifthDataSet = new SimpleDataset("Fifth", dFFifthPlotArray[0], dFFifthPlotArray[1]);
                m_objFifthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fifth");

                m_objSixthDataSet = new SimpleDataset("Sixth", dFSixthPlotArray[0], dFSixthPlotArray[1]);
                m_objSixthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Sixth");

                m_objSeventhDataSet = new SimpleDataset("Seventh", dFSeventhPlotArray[0], dFSeventhPlotArray[1]);
                m_objSeventhDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Seventh");

                m_objEighthDataSet = new SimpleDataset("Eighth", dFEighthPlotArray[0], dFEighthPlotArray[1]);
                m_objEighthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Eighth");

                m_objNinthDataSet = new SimpleDataset("Ninth", dfNinthPlotArray[0], dfNinthPlotArray[1]);
                m_objNinthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Ninth");

                m_objDataSetArray = new SimpleDataset[9];

                m_objDataSetArray[0] = m_objFirstDataSet;
                m_objDataSetArray[1] = m_objSecondDataSet;
                m_objDataSetArray[2] = m_objThirdDataSet;
                m_objDataSetArray[3] = m_objFourthDataSet;
                m_objDataSetArray[4] = m_objFifthDataSet;
                m_objDataSetArray[5] = m_objSixthDataSet;
                m_objDataSetArray[6] = m_objSeventhDataSet;
                m_objDataSetArray[7] = m_objEighthDataSet;
                m_objDataSetArray[8] = m_objNinthDataSet;
               
                m_obj2DGraphView.MainBaseControl = m_objMainControl;
                m_obj2DGraphView.Dates = arlstDateTime;
                m_obj2DGraphView.Units = m_sUnits;
                m_obj2DGraphView.CommonFunctionality(m_objDataSetArray, ColorTag);


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void CaseMultiSix(ArrayList arlstValues, ArrayList arlstDateTime, ArrayList arlstCounter, ArrayList ColorTag)
        {
            try
            {

                double[][] dFFirstPlotArry = (double[][])arlstValues[0];
                double[][] dFSecondPlotArry = (double[][])arlstValues[1];
                double[][] dFThirdPlotArry = (double[][])arlstValues[2];
                double[][] dFFourthPlotArry = (double[][])arlstValues[3];
                double[][] dFFifthPlotArray = (double[][])arlstValues[4];
                double[][] dFSixthPlotArray = (double[][])arlstValues[5];
                double[][] dFSeventhPlotArray = (double[][])arlstValues[6];
                double[][] dFEighthPlotArray = (double[][])arlstValues[7];
                double[][] dfNinthPlotArray = (double[][])arlstValues[8];
                double[][] dFTenthDataSet = (double[][])arlstValues[9];

                m_objFirstDataSet = new SimpleDataset("First", dFFirstPlotArry[0], dFFirstPlotArry[1]);
                m_objFirstDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                m_objSecondDataSet = new SimpleDataset("Second", dFSecondPlotArry[0], dFSecondPlotArry[1]);
                m_objSecondDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Second");

                m_objThirdDataSet = new SimpleDataset("Third", dFThirdPlotArry[0], dFThirdPlotArry[1]);
                m_objThirdDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Third");

                m_objFourthDataSet = new SimpleDataset("Fourth", dFFourthPlotArry[0], dFFourthPlotArry[1]);
                m_objFourthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fourth");

                m_objFifthDataSet = new SimpleDataset("Fifth", dFFifthPlotArray[0], dFFifthPlotArray[1]);
                m_objFifthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Fifth");

                m_objSixthDataSet = new SimpleDataset("Sixth", dFSixthPlotArray[0], dFSixthPlotArray[1]);
                m_objSixthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Sixth");

                m_objSeventhDataSet = new SimpleDataset("Seventh", dFSeventhPlotArray[0], dFSeventhPlotArray[1]);
                m_objSeventhDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Seventh");

                m_objEighthDataSet = new SimpleDataset("Eighth", dFEighthPlotArray[0], dFEighthPlotArray[1]);
                m_objEighthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Eighth");

                m_objNinthDataSet = new SimpleDataset("Ninth", dfNinthPlotArray[0], dfNinthPlotArray[1]);
                m_objNinthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Ninth");

                m_objTenthDataSet = new SimpleDataset("Tenth", dFTenthDataSet[0], dFTenthDataSet[1]);
                m_objTenthDataSet.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "Tenth");

                m_objDataSetArray = new SimpleDataset[10];

                m_objDataSetArray[0] = m_objFirstDataSet;
                m_objDataSetArray[1] = m_objSecondDataSet;
                m_objDataSetArray[2] = m_objThirdDataSet;
                m_objDataSetArray[3] = m_objFourthDataSet;
                m_objDataSetArray[4] = m_objFifthDataSet;
                m_objDataSetArray[5] = m_objSixthDataSet;
                m_objDataSetArray[6] = m_objSeventhDataSet;
                m_objDataSetArray[7] = m_objEighthDataSet;
                m_objDataSetArray[8] = m_objNinthDataSet;
                m_objDataSetArray[9] = m_objTenthDataSet;
                
                m_obj2DGraphView.MainBaseControl = m_objMainControl;
                m_obj2DGraphView.Dates = arlstDateTime;
                m_obj2DGraphView.Units = m_sUnits;
                m_obj2DGraphView.CommonFunctionality(m_objDataSetArray, ColorTag);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }




        ArrayList m_arlstChartObjects = null;
        ArrayList m_arlstLinePlots = null;

        internal ArrayList GetChartObjects()
        {
            try
            {
                if (chartVu != null)
                {
                    m_arlstLinePlots.Clear();
                    m_arlstChartObjects = chartVu.GetChartObjectsArrayList();
                    for (int iCtr = 0; iCtr < m_arlstChartObjects.Count; iCtr++)
                    {
                        GraphObj objGraphObject = (GraphObj)m_arlstChartObjects[iCtr];

                        if (objGraphObject.ChartObjType == 1)
                        {
                            m_arlstLinePlots.Add(objGraphObject);
                        }

                        if (m_arlstLinePlots.Count > 1)
                        {
                            for (int iNewCtr = 0; iNewCtr < m_arlstLinePlots.Count; iNewCtr++)
                            {
                                if (((SimpleLinePlot)m_arlstLinePlots[iNewCtr]).LineWidth == 2)
                                    ((SimpleLinePlot)m_arlstLinePlots[iNewCtr]).SetLineWidth(1);
                                chartVu.UpdateDraw();
                            }
                        }

                    }
                }

                return m_arlstLinePlots;
            }
            catch (Exception ex)
            {
                return m_arlstLinePlots;
               
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            try
            {
                base.OnPaint(pe);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        public void SaveImage(string pnl)
        {
            try
            {
                Image img = null; Image imgNew = null;
                BufferedImage objImage = new BufferedImage(chartVu);              
                string path = Path.GetTempPath();
                switch (pnl)
                {
                    case "Time":
                        try
                        {
                            if (File.Exists(path + @"Time.jpg"))
                            {
                                File.Delete(path + @"Time.jpg");
                            }
                            else
                            { }
                            objImage.SaveImage(path + @"Time.jpg");
                            PublicClass.timeimage = path + @"Time.jpg";
                        }
                        catch
                        {
                        }
                        break;

                    case "Power":
                        try
                        {
                            if (File.Exists(path + @"Power.jpg"))
                            {
                                File.Delete(path + @"Power.jpg");
                            }
                            else
                            { }
                            objImage.SaveImage(path + @"Power.jpg");
                            PublicClass.powerimage = path + @"Power.jpg";
                        }

                        catch
                        {

                        }
                        break;

                    case "Power1":
                        try
                        {
                            if (File.Exists(path + @"Power1.jpg"))
                            {
                                File.Delete(path + @"Power1.jpg");
                            }
                            else
                            { }
                            objImage.SaveImage(path + @"Power1.jpg");
                            PublicClass.power1image = path + @"Power1.jpg";
                        }
                        catch { }

                        break;

                    case "Power2":
                        try
                        {
                            if (File.Exists(path + @"Power2.jpg"))
                            {
                                File.Delete(path + @"Power2.jpg");
                            }
                            else
                            { }
                            objImage.SaveImage(path + @"Power2.jpg");
                            PublicClass.power2image = path + @"Power2.jpg";
                        }
                        catch { }
                        break;

                    case "Power21":
                        try
                        {
                            if (File.Exists(path + @"Power21.jpg"))
                            {
                                File.Delete(path + @"Power21.jpg");
                            }
                            else
                            { }
                            objImage.SaveImage(path + @"Power21.jpg");
                            PublicClass.power21image = path + @"Power21.jpg";
                        }
                        catch
                        { }
                        break;

                    case "Power3":
                        try
                        {
                            if (File.Exists(path + @"Power3.jpg"))
                            {
                                File.Delete(path + @"Power3.jpg");
                            }
                            else
                            { }
                            objImage.SaveImage(path + @"Power3.jpg");
                            PublicClass.power3image = path + @"Power3.jpg";
                        }
                        catch { }
                        break;

                    case "Power31":
                        try
                        {
                            if (File.Exists(path + @"Power31.jpg"))
                            {
                                File.Delete(path + @"Power31.jpg");
                            }
                            else
                            { }
                            objImage.SaveImage(path + @"Power31.jpg");
                            PublicClass.power31image = path + @"Power31.jpg";
                        }
                        catch { }
                        break;

                    case "Demodulate":
                        try
                        {
                            if (File.Exists(path + @"Demodulate.jpg"))
                            {
                                File.Delete(path + @"Demodulate.jpg");
                            }
                            else
                            { }
                            objImage.SaveImage(path + @"Demodulate.jpg");
                            PublicClass.demoimage = path + @"Demodulate.jpg";
                        }
                        catch
                        { }
                        break;

                    case "Cepstrum":
                        try
                        {
                            if (File.Exists(path + @"Cepstrum.jpg"))
                            {
                                File.Delete(path + @"Cepstrum.jpg");
                            }
                            else
                            { }

                            objImage.SaveImage(path + @"Cepstrum.jpg");
                            PublicClass.cepimage = path + @"Cepstrum.jpg";
                        }
                        catch { }
                        break;

                    case "Trend":
                        try
                        {
                            if (File.Exists(path + @"Trend.jpg"))
                            {
                                File.Delete(path + @"Trend.jpg");
                            }
                            else
                            { }

                            objImage.SaveImage(path + @"Trend.jpg");
                            PublicClass.trendimage = path + @"Trend.jpg";
                        }
                        catch { }
                        break;
                }
            }
            catch (Exception ex)
            {
                //ErrorLogFile(ex);
                //System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }
        public void UnZoom()
        {
            int iTest = 0;
            try
            {
                if (m_obj2DGraphView != null)
                    m_obj2DGraphView.UnZoom();
            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
            finally
            {
                m_objDataCursor = null;
            }
        }

        public void SetPlots(string sText)
        {

            ChartAttribute attrBars = null;
            ChartAttribute attrPoints = null;

            try
            {
                if (sText == "" || sText == "LinePlot")
                {


                  
                    if (m_obj2DGraphView != null)
                        m_obj2DGraphView.SetPlots(sText);


                }
                else if (sText == "AreaPlot ")
                {

                    if (m_obj2DGraphView != null)
                        m_obj2DGraphView.SetPlots(sText);

                }
            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);

            }
        }

      
        public void SetZoom()
        {
            try
            {

                
                if (m_obj2DGraphView != null)
                    m_obj2DGraphView.SetZoom();

            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }

        }

      
        public void SetDataCursor()
        {
            try
            {
                if (m_obj2DGraphView != null)
                    m_obj2DGraphView.SetDataCursor();

            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
            finally
            {

            }
        }

        internal void SetLabelText(string sValue)
        {
            try
            {
                lblValues.Text = sValue;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
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
                ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
            finally
            {

            }

        }
        SimpleLinePlot m_objPreviousPlot = null;

        internal void SetLineWidth(SimpleLinePlot objLinePlot)
        {
            try
            {
                if (objLinePlot != null)
                {
                    if (m_objPreviousPlot != null && m_objPreviousPlot == objLinePlot && objLinePlot.LineWidth == 2)
                        objLinePlot.LineWidth = 1;
                    else if (m_objPreviousPlot != null && m_objPreviousPlot == objLinePlot && objLinePlot.LineWidth == 1)
                        objLinePlot.LineWidth = 2;

                    if (m_objPreviousPlot == null && objLinePlot.LineWidth == 1)
                        objLinePlot.LineWidth = 2;


                    if (m_objPreviousPlot != null && m_objPreviousPlot != objLinePlot && objLinePlot.LineWidth == 2)
                    {
                        objLinePlot.LineWidth = 1;
                        m_objPreviousPlot.LineWidth = 2;
                    }
                    else if (m_objPreviousPlot != null && m_objPreviousPlot != objLinePlot && objLinePlot.LineWidth == 1)
                    {
                        objLinePlot.LineWidth = 2;
                        m_objPreviousPlot.LineWidth = 1;
                    }
                  
                    m_objSelectedPlot = objLinePlot;
                    m_objNewPlot = objLinePlot;
                    NumericLabel objLabel = m_objSelectedPlot.PlotLabelTemplate;
                    Color clrClicked = m_objSelectedPlot.GetColor();

                    m_objGraphControl.LabelColor = clrClicked;


                }
                m_objPreviousPlot = objLinePlot;
                chartVu.UpdateDraw();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
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
            }//end(try)
            catch (Exception ex)
            {
                ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        internal void TriggerBaseMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        public void SaveReportingImage(string sCompletePointName)
        {
            try
            {
                if (m_obj2DGraphView != null)
                    m_obj2DGraphView.SaveReportingImage(sCompletePointName);
            }
            catch (Exception ex)
            {
            }
        }

        string sErrorLogPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
        FileStream aa = null;
        StreamWriter sw = null;


        private void ErrorLogFile(Exception ex)
        {
            try
            {

                if (ex.Message == "Exception of type 'System.OutOfMemoryException' was thrown.")
                {
                    MessageBox.Show("System Memory is low. Please Close Some Applications and Try again", "Low Memory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (!File.Exists(sErrorLogPath + "\\FMErrorLog.txt"))
                {
                    aa = new FileStream(sErrorLogPath + "\\FMErrorLog.txt", FileMode.Create, FileAccess.ReadWrite);
                }
                else
                {
                    aa = new FileStream(sErrorLogPath + "\\FMErrorLog.txt", FileMode.Append, FileAccess.Write);
                }
                sw = new StreamWriter(aa);
                sw.WriteLine(ex.Message + "      " + ex.StackTrace + "          " + System.DateTime.Now.ToString("MM/dd/yyyy HH:m:s"));
                sw.Close();

            }
            catch (Exception ex1)
            {
            }
        }


        public void copyMapToClipboard()
        {
            try
            {
                if (m_obj2DGraphView != null)
                    m_obj2DGraphView.CopyMapToClipBoard();
            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }
        bool bcontrol = false;

        public bool Control
        {
            get
            {
                return bcontrol;
            }
            set
            {
                bcontrol = value;
            }
        }
        private void GraphView_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control == true)
                {
                    Control = true;
                }
                else
                {
                    Control = false;
                }
            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }

        }

        private void GraphView_KeyPress_1(object sender, KeyPressEventArgs e)
        {
        }

        private void GraphView_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Control && e.KeyCode == Keys.C)
                {
                    copyMapToClipboard();

                }
            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }

        }

        internal void CopyGraphValues()
        {
            try
            {


                if (m_obj2DGraphView != null)
                    m_obj2DGraphView.CopyValuesToClipBoardOutside();


            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }

        }

  

        private void GraphView_Load(object sender, EventArgs e)
        {

        }

        public SplitGroupPanel buttonheight
        {
            get
            {
                return m_objGraphControl.buttonheight;
            }
        }

        private void GraphView_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
        private void GraphView_Click(object sender, EventArgs e)
        {
        }
    }
}
