using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using com.iAM.chart3dnet;
using System.Drawing.Drawing2D;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;
using Iadeptmain.Mainforms;
using Iadeptmain.Images;

namespace Iadeptmain.BaseUserControl
{
    public partial class _3DGraphControl : ChartView
    {
        public _3DGraphControl()
        {
            InitializeComponent();
            this.ThisMouseMove += new MouseMoveHandler(_3DGraphControl_ThisMouseMove);
            objlistimg.Images.Add(ImageResources.DarkRed);
            objlistimg.Images.Add(ImageResources.DarkGreen);
            objlistimg.Images.Add(ImageResources.DarkGoldenRod);
            //objlistimg.Images.Add(ImageResources.DarkVoilet);
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

        Marker[] arrmarkerCursor = null;
        double selectedZvalue = 0.0;
        int m_iCounter = 0;
        double[] arrZValues = null;
        ChartText[] arrChartTextCursor = null;
        SimpleLinePlot[] allPlots = null;
        protected override void OnMouseMove(MouseEventArgs e)
        {
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
                
            }
        }
        void _3DGraphControl_ThisMouseMove(MouseEventArgs e)
        {
            SimpleDataset Dataset1 = null;
            NearestPointData nearestPointObj1 = null;
            NearestPointData objSecondNearestPoint = null;
            Font textCoordsFont = null;
            Point3D ptLocation = null;
            bool bFirstPlot = false;
            Point3D ptNewPoint = null;

            try
            {
                Point3D objNewPoint = new Point3D();


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

                                ///////////////////BearingFFOverriddenRPM = ptNewPoint.GetX().ToString();
                                theFont = new Font("Arial", 8, FontStyle.Regular);
                                /////single cursor
                                switch (SelectedCursor)
                                {
                                    case "Line":
                                        {
                                            arrmarkerCursor = new Marker[allPlots.Length];
                                            arrChartTextCursor = new ChartText[allPlots.Length];
                                            for (int k = 0; k < allPlots.Length; k++)
                                            {
                                                Dataset1 = allPlots[k].DisplayDataset;
                                                if (m_objDataCursor != null)
                                                {
                                                    ptLocation = m_objDataCursor.Location;

                                                    bFirstPlot = allPlots[k].CalcNearestPoint(ptLocation, 3, nearestPointObj1);
                                                }
                                                ptNewPoint = nearestPointObj1.GetNearestPoint();


                                                Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_BOX, ptNewPoint.GetX(), ptNewPoint.GetY(), arrZValues[arrZValues.Length - (k + 1)], 8, 1);
                                                m_objMarker1.SetColor(allPlots[k].GetColor());
                                                arrmarkerCursor[k] = m_objMarker1;
                                                chartVu.AddChartObject(m_objMarker1);


                                                ChartText CurrentLabel = new ChartText(pTransform1, theFont, ptNewPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, arrZValues[arrZValues.Length - (k + 1)], ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                                CurrentLabel.SetColor(allPlots[k].GetColor());
                                                chartVu.AddChartObject(CurrentLabel);
                                                arrChartTextCursor[k] = CurrentLabel;

                                                _DataGridView.Rows.Add(1);
                                                _DataGridView[0, k].Value = ptNewPoint.GetX().ToString();
                                                _DataGridView[1, k].Value = ptNewPoint.GetY().ToString();
                                                _DataGridView[0, k].Style.ForeColor = allPlots[k].GetColor();
                                            }
                                            _DataGridView.Refresh();
                                            break;
                                        }
                                    case "Single":
                                        {
                                            arrmarkerCursor = new Marker[1];
                                            arrChartTextCursor = new ChartText[1];
                                            Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), selectedZvalue, 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[0] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);

                                            
                                            ChartText CurrentLabel = new ChartText(pTransform1, theFont, ptNewPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, selectedZvalue, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            chartVu.AddChartObject(CurrentLabel);
                                            arrChartTextCursor[0] = CurrentLabel;

                                            _DataGridView.Rows.Add(1);
                                            _DataGridView[0, 0].Value = ptNewPoint.GetX().ToString();
                                            _DataGridView[1, 0].Value = ptNewPoint.GetY().ToString();
                                            _DataGridView.Refresh();
                                            break;
                                        }
                                    case "Single With Square":
                                        {
                                            arrmarkerCursor = new Marker[2];
                                            arrChartTextCursor = new ChartText[1];
                                            Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_BOX, ptNewPoint.GetX(), ptNewPoint.GetY(), selectedZvalue, 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[0] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);
                                            m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_VLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), selectedZvalue, 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[1] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);

                                            ChartText CurrentLabel = new ChartText(pTransform1, theFont, ptNewPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, selectedZvalue, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            chartVu.AddChartObject(CurrentLabel);
                                            arrChartTextCursor[0] = CurrentLabel;

                                            _DataGridView.Rows.Add(1);
                                            _DataGridView[0, 0].Value = ptNewPoint.GetX().ToString();
                                            _DataGridView[1, 0].Value = ptNewPoint.GetY().ToString();
                                            _DataGridView.Refresh();
                                            break;
                                        }
                                    case "Cross Hair":
                                        {
                                            arrmarkerCursor = new Marker[1];
                                            arrChartTextCursor = new ChartText[1];
                                            Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_HVLINE, ptNewPoint.GetX(), ptNewPoint.GetY(), selectedZvalue, 8, 1);
                                            m_objMarker1.SetColor(_MainCursorColor);
                                            arrmarkerCursor[0] = m_objMarker1;
                                            chartVu.AddChartObject(m_objMarker1);

                                            
                                            ChartText CurrentLabel = new ChartText(pTransform1, theFont, ptNewPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(ptNewPoint.GetY()), 5)) + YLabel, ptNewPoint.GetX(), pTransform1.YScale.ScaleStop, selectedZvalue, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                                            CurrentLabel.SetColor(_MainCursorColor);
                                            chartVu.AddChartObject(CurrentLabel);
                                            arrChartTextCursor[0] = CurrentLabel;

                                            _DataGridView.Rows.Add(1);
                                            _DataGridView[0, 0].Value = ptNewPoint.GetX().ToString();
                                            _DataGridView[1, 0].Value = ptNewPoint.GetY().ToString();
                                            _DataGridView.Refresh();
                                            break;
                                        }
                                }
                            }
                        }
                    }
                }
                chartVu.UpdateDraw();
            }
            catch (Exception ex)
            {
            }
        }
        ImageList objlistimg = new ImageList();

        string XLabel = "X Axis";
        string YLabel = "Y Axis";
        LinearAxis xAxis2;
        LinearAxis yAxis2;
        Grid xgrid2;
        Grid ygrid2;
        NumericAxisLabels xAxisLab2;
        NumericAxisLabels yAxisLab2;
        AxisTitle yaxistitle2;
        AxisTitle xaxistitle2;
        Color GraphBG1 = Color.White;
        Color GraphBG2 = Color.White;
        Color ChartBG1 = Color.White;
        Color ChartBG2 = Color.White;
        Color AxisColor = Color.Black;
        int GraphBGDir = 0;
        int ChartBGDir = 0;
        Marker[] arrmarker = null;
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
        string SelectedCursor = null;
        SimpleDataset Dataset2;
        ChartView chartVu;
        Font theFont;
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
        DataGridViewX objDataGridView1 = null;
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
        public void DrawWaterfallGraph(double[] Xdata, double[] Ydata, bool Areafill)
        {
            DrawWaterfallGraph(Xdata, Ydata, _ColorTag, Areafill);
        }
        public void DrawWaterfallGraph(double[] Xdata, double[] Ydata, string ColorTag, bool Areafill)
        {
            RemovePreviousObjects();
            m_objSelectedPlot = null;
            m_objNewPlot = null;
            m_objSelectedPlotForCursor = null;
            m_objClickedPlot = null;
            m_objOldSelectedPlot = null;
            chartVu = this;
            theFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            try
            {


                Dataset2 = new SimpleDataset("P/L", Xdata, Ydata);
                Dataset2.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, Ydata.Length, "compressed");

                pTransform1 = new CartesianCoordinates();
                pTransform1.AutoScale(Dataset2, ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_FAR);
                pTransform1.SetGraphBorderDiagonal(0.1, .1, .9, 0.9);

                plotbackground = new Background(pTransform1, ChartObj.PLOT_BACKGROUND, ChartBG1, ChartBG2, ChartBGDir);
                chartVu.AddChartObject(plotbackground);

                background = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND, GraphBG1, GraphBG2, GraphBGDir);
                chartVu.AddChartObject(background);

                ChartAttribute wallAttrib = new ChartAttribute(ChartBG1, 1, DashStyle.Solid, ChartBG2);
                Wall3D xyMinZWall = new Wall3D(pTransform1, ChartObj.XY_MAXZ_PLANE, 0.02, wallAttrib);
                chartVu.AddChartObject(xyMinZWall);
                Wall3D yzMinXWall = new Wall3D(pTransform1, ChartObj.YZ_MINX_PLANE, 0.02, wallAttrib);
                chartVu.AddChartObject(yzMinXWall);
                Wall3D xzMinYWall = new Wall3D(pTransform1, ChartObj.XZ_MINY_PLANE, 0.02, wallAttrib);
                chartVu.AddChartObject(xzMinYWall);

                xAxis2 = new LinearAxis(pTransform1, ChartObj.X_AXIS);
                xAxis2.SetColor(_AxisColor);
                xAxis2.SetAxisIntercept(0);
                chartVu.AddChartObject(xAxis2);

                yAxis2 = new LinearAxis(pTransform1, ChartObj.Y_AXIS);
                yAxis2.SetColor(_AxisColor);
                chartVu.AddChartObject(yAxis2);

                LinearAxis zAxis = new LinearAxis(pTransform1, ChartObj.Z_AXIS);
                zAxis.SetColor(_AxisColor);
                chartVu.AddChartObject(zAxis);

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

                Font toolTipFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                DataToolTip datatooltip = new DataToolTip(chartVu);
                NumericLabel xValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                NumericLabel yValueTemplate = new NumericLabel(ChartObj.DECIMALFORMAT, 3);
                datatooltip.GetToolTipSymbol().SetColor(_AxisColor);
                datatooltip.SetXValueTemplate(xValueTemplate);
                datatooltip.SetYValueTemplate(yValueTemplate);
                datatooltip.SetDataToolTipFormat(ChartObj.DATA_TOOLTIP_XY_ONELINE);
                datatooltip.SetEnable(true);
                chartVu.SetCurrentMouseListener(datatooltip);
                chartVu.Controls.Remove(rotatebutton);
                rotatebutton = new RotateButtonUserControl(pTransform1);
                rotatebutton.Size = new Size(32, 32);
                rotatebutton.Location = new Point(8, 8);
                chartVu.Controls.Add(rotatebutton);
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawWaterfallGraph(double[] Xdata, double[] Ydata, string ColorCode)
        {
            DrawWaterfallGraph(Xdata, Ydata, ColorCode, _AreaFill);
        }
        public void DrawWaterfallGraph(double[] Xdata, double[] YData)
        {
            try
            {
                DrawWaterfallGraph(Xdata, YData, _AreaFill);
            }
            catch (Exception ex)
            {
            }
        }
        public void DrawWaterfallGraph(ArrayList XData, ArrayList YData)
        {
            try
            {
                string[] ColorCode = { "7667712", "16751616", "4684277", "7077677", "16777077", "9868951", "2987746", "4343957", "16777216", "23296", "16711681", "8388652", "6972", "16776961", "7722014", "32944", "7667573", "7357301", "12042869", "60269", "14774017", "5103070", "14513374", "5374161", "38476", "3318692", "29696", "6737204", "16728065", "744352" };
                DrawWaterfallGraph(XData, YData, ColorCode);
            }
            catch (Exception ex)
            {
            }
        }


        public void DrawWaterfallGraph(ArrayList XData, ArrayList YData, string[] ColorTag)
        {
            RemovePreviousObjects();
            m_objSelectedPlot = null;
            m_objNewPlot = null;
            m_objSelectedPlotForCursor = null;
            m_objClickedPlot = null;
            m_objOldSelectedPlot = null;
            chartVu = this;
            theFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            arrZValues = new double[YData.Count];
            try
            {
                SimpleDataset[] arrSimpleDataset = new SimpleDataset[YData.Count];
                for (i = 0; i < YData.Count; i++)
                {
                    double[] yy = (double[])YData[i];
                    Dataset2 = new SimpleDataset("P/L", (double[])XData[i], (double[])YData[i]);                    
                    Dataset2.ImplicitZValue = (double)((double)1 / (double)YData.Count) * i;
                    Dataset2.CompressSimpleDataset(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, yy.Length, "compressed");
                    arrSimpleDataset[i] = Dataset2;
                    selectedZvalue = Dataset2.ImplicitZValue;
                    arrZValues[i] = selectedZvalue;
                }

                pTransform1 = new CartesianCoordinates();
                pTransform1.AutoScale(arrSimpleDataset, ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_FAR);
                pTransform1.SetGraphBorderDiagonal(0.1, .1, .9, 0.9);
                
                plotbackground = new Background(pTransform1, ChartObj.PLOT_BACKGROUND, ChartBG1, ChartBG2, ChartBGDir);
                chartVu.AddChartObject(plotbackground);

                background = new Background(pTransform1, ChartObj.GRAPH_BACKGROUND, GraphBG1, GraphBG2, GraphBGDir);
                chartVu.AddChartObject(background);

                pTransform1.AbsRotateCoordinateSystem(new Point3D(10, 20, 0));

                ChartAttribute wallAttrib = new ChartAttribute(Color.White, 1, DashStyle.Solid, Color.White);
                Wall3D xyMinZWall = new Wall3D(pTransform1, ChartObj.XY_MAXZ_PLANE, 0.02, wallAttrib);
                chartVu.AddChartObject(xyMinZWall);
                Wall3D yzMinXWall = new Wall3D(pTransform1, ChartObj.YZ_MINX_PLANE, 0.02, wallAttrib);
                chartVu.AddChartObject(yzMinXWall);
                Wall3D xzMinYWall = new Wall3D(pTransform1, ChartObj.XZ_MINY_PLANE, 0.02, wallAttrib);
                chartVu.AddChartObject(xzMinYWall);


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

                chartVu.SetResizeMode(ChartObj.ACTUAL_SIZE);

                // Define data tooltip mouse listener
                Font toolTipFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                DataToolTip datatooltip = new DataToolTip(chartVu);
                TimeLabel xValueTemplate = new TimeLabel(ChartObj.TIMEDATEFORMAT_MDY); 
                NumericLabel yValueTemplate = new NumericLabel(ChartObj.CURRENCYFORMAT, 2); 
                ChartSymbol toolTipSymbol = new ChartSymbol(null, ChartObj.SQUARE, new ChartAttribute(Color.Black));
                toolTipSymbol.SetSymbolSize(5.0);
                datatooltip.SetXValueTemplate(xValueTemplate);
                datatooltip.SetYValueTemplate(yValueTemplate);
                datatooltip.SetDataToolTipFormat(ChartObj.DATA_TOOLTIP_CUSTOM);
                datatooltip.SetToolTipSymbol(toolTipSymbol);
                datatooltip.SetEnable(true);
                chartVu.SetCurrentMouseListener(datatooltip);

                chartVu.Controls.Remove(rotatebutton);
                rotatebutton = new RotateButtonUserControl(pTransform1);
                rotatebutton.Size = new Size(32, 32);
                rotatebutton.Location = new Point(8, 8);
                chartVu.Controls.Add(rotatebutton);
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
        RotateButtonUserControl rotatebutton;



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
                        if (Cursor == "Line")
                        {
                            allPlots = GetAllPlots();
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
        private SimpleLinePlot[] GetAllPlots()
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
        DataGridView objDataGridView = null;
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

       
        ArrayList XYDATA = new ArrayList();
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

        private void _3DGraphControl_DragEnter(object sender, DragEventArgs e)
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
        public ArrayList SelectNextPlot(int ColorValue)
        {
            ArrayList arlstToreturn = new ArrayList();
            try
            {
                SimpleLinePlot[] AllPlots = GetAllPlots();
                Color SelectPlotColor = Color.FromArgb(-Convert.ToInt32(ColorValue));
                for (int iplot = 0; iplot < AllPlots.Length; iplot++)
                {
                    if (AllPlots[iplot].LineColor == SelectPlotColor)//Color.FromArgb(-Convert.ToInt32(arlstSColors[0]))
                    {
                        SetSelectedPlot((SimpleLinePlot)AllPlots[iplot]);

                        SimpleDataset TestDataset = ((SimpleLinePlot)AllPlots[iplot]).DisplayDataset;
                        arlstToreturn.Add(TestDataset.GetXData());
                        arlstToreturn.Add(TestDataset.GetYData());
                        selectedZvalue = TestDataset.ImplicitZValue;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return arlstToreturn;
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

                    ChartAttribute wallAttrib = new ChartAttribute(ChartBG1, 1, DashStyle.Solid, ChartBG2);
                    Wall3D xyMinZWall = new Wall3D(pTransform1, ChartObj.XY_MAXZ_PLANE, 0.02, wallAttrib);
                    chartVu.AddChartObject(xyMinZWall);
                    Wall3D yzMinXWall = new Wall3D(pTransform1, ChartObj.YZ_MINX_PLANE, 0.02, wallAttrib);
                    chartVu.AddChartObject(yzMinXWall);
                    Wall3D xzMinYWall = new Wall3D(pTransform1, ChartObj.XZ_MINY_PLANE, 0.02, wallAttrib);
                    chartVu.AddChartObject(xzMinYWall);

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

                    chartVu.Update();
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
                    MessageBoxEx.Show("3D Graph Copied on ClipBoard", "Graph");
                }
            }
            catch (Exception ex)
            {
            }
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
                    case "Line":
                        {
                            CheckKeyDownLine(Direction);
                            break;
                        }
                   
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void CheckKeyDownSingleWithSquare(string sType)
        {
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            Point3D ptNewPoint = null;
            Point3D ptLocation = null;
            Point3D ptPreviousPoint = null;
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
                        Point3D objPoint = objDataSet.GetDataPoint(m_iCounter);
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

                        m_objMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, objPoint.X, objPoint.Y, selectedZvalue, 5, 1);
                        m_objNewMarker = new Marker(pTransform1, GraphObj.MARKER_BOX, objPoint.X, objPoint.Y, selectedZvalue, 8, 1);
                        m_objMarker.SetColor(_MainCursorColor);
                        m_objNewMarker.SetColor(_MainCursorColor);
                        chartVu.AddChartObject(m_objMarker);
                        chartVu.AddChartObject(m_objNewMarker);

                        ChartText CurrentLabel = new ChartText(pTransform1, theFont, objPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, selectedZvalue, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                        CurrentLabel.SetColor(_MainCursorColor);
                        chartVu.AddChartObject(CurrentLabel);
                        arrChartTextCursor[0] = CurrentLabel;

                        if (m_objMarker != null)
                        {
                            _DataGridView.Rows.Add(1);
                            _DataGridView[0, 0].Value = objPoint.X.ToString();
                            _DataGridView[1, 0].Value = objPoint.Y.ToString();
                            _DataGridView.Refresh();
                            chartVu.UpdateDraw();

                        }


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
                    Point3D objPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter);
                    ptPreviousPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter + 1);
                    nearestPointObj1 = new NearestPointData();
                    textCoordsFont = new Font("Arial", 8, FontStyle.Regular);

                    ptNewPoint = nearestPointObj1.GetNearestPoint();

                    if (m_objMarker != null)
                    {
                        chartVu.DeleteChartObject(m_objMarker);
                        chartVu.DeleteChartObject(m_objNewMarker);
                    }

                    m_objMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, objPoint.X, objPoint.Y, selectedZvalue, 5, 1);
                    m_objNewMarker = new Marker(pTransform1, GraphObj.MARKER_BOX, objPoint.X, objPoint.Y, selectedZvalue, 8, 1);
                    m_objMarker.SetColor(_MainCursorColor);
                    m_objNewMarker.SetColor(_MainCursorColor);

                    chartVu.AddChartObject(m_objMarker);
                    chartVu.AddChartObject(m_objNewMarker);

                    ChartText CurrentLabel = new ChartText(pTransform1, theFont, objPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, selectedZvalue, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    chartVu.AddChartObject(CurrentLabel);
                    arrChartTextCursor[0] = CurrentLabel;

                    if (m_objMarker != null)
                    {
                        _DataGridView.Rows.Add(1);
                        _DataGridView[0, 0].Value = objPoint.X.ToString();
                        _DataGridView[1, 0].Value = objPoint.Y.ToString();
                        _DataGridView.Refresh();
                        chartVu.UpdateDraw();

                    }
                }
                arrmarkerCursor = new Marker[2];
                arrmarkerCursor[0] = m_objMarker;
                arrmarkerCursor[1] = m_objNewMarker;
            }
            catch (Exception ex)
            {
            }
        }
        private void CheckKeyDownLine(string sType)
        {
            
            Font textCoordsFont = null;
            
            GraphObj objLine = null;
            SimpleLinePlot objClickedLine = null;
            SimpleDataset objDataSet = null;
            SimpleDataset objPreviousPointDataSet = null;

            try
            {
                _DataGridView.Rows.Clear();
                ArrayList arrObjects = chartVu.GetChartObjectsArrayList();

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
                arrmarkerCursor = new Marker[allPlots.Length];
                arrChartTextCursor = new ChartText[allPlots.Length];
                if (sType == "Right")
                {


                    m_iCounter++;
                    if (m_objDataCursor != null)
                        chartVu.DeleteChartObject(m_objDataCursor);
                    for (int k = 0; k < allPlots.Length; k++)
                    {
                        objDataSet = allPlots[k].DisplayDataset;
                        int iNumber = objDataSet.GetNumberDatapoints();
                        if (m_iCounter >= iNumber)
                            m_iCounter = iNumber - 1;
                        Point3D objPoint = objDataSet.GetDataPoint(m_iCounter);

                        textCoordsFont = new Font("Arial", 8, FontStyle.Regular);

                        if (m_objMarker != null)
                        {
                            chartVu.DeleteChartObject(m_objMarker);
                            chartVu.DeleteChartObject(m_objNewMarker);
                            if (m_objDataCursor != null)
                                chartVu.DeleteChartObject(m_objDataCursor);

                        }

                        Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_BOX, objPoint.X, objPoint.Y, arrZValues[arrZValues.Length - (k + 1)], 8, 1);
                        m_objMarker1.SetColor(allPlots[k].GetColor());
                        chartVu.AddChartObject(m_objMarker1);
                        arrmarkerCursor[k] = m_objMarker1;

                        ChartText CurrentLabel = new ChartText(pTransform1, theFont, objPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, arrZValues[arrZValues.Length - (k + 1)], ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                        CurrentLabel.SetColor(allPlots[k].GetColor());
                        chartVu.AddChartObject(CurrentLabel);
                        arrChartTextCursor[k] = CurrentLabel;

                        if (m_objMarker != null)
                        {
                            _DataGridView.Rows.Add(1);
                            _DataGridView[0, k].Value = objPoint.X.ToString();
                            _DataGridView[1, k].Value = objPoint.Y.ToString();
                            _DataGridView[0, k].Style.ForeColor = allPlots[k].GetColor();
                            _DataGridView.Refresh();


                        }
                    }


                }
                else if (sType == "Left")
                {

                    m_iCounter--;
                    if (m_iCounter < 0)
                        m_iCounter = 0;
                    if (m_objDataCursor != null)
                        chartVu.DeleteChartObject(m_objDataCursor);
                    for (int k = 0; k < allPlots.Length; k++)
                    {
                        objDataSet = allPlots[k].DisplayDataset;

                        Point3D objPoint = objDataSet.GetDataPoint(m_iCounter);

                        textCoordsFont = new Font("Arial", 8, FontStyle.Regular);


                        if (m_objMarker != null)
                        {
                            chartVu.DeleteChartObject(m_objMarker);
                            chartVu.DeleteChartObject(m_objNewMarker);
                            if (m_objDataCursor != null)
                                chartVu.DeleteChartObject(m_objDataCursor);

                        }

                        Marker m_objMarker1 = new Marker(pTransform1, GraphObj.MARKER_BOX, objPoint.X, objPoint.Y, arrZValues[arrZValues.Length - (k + 1)], 8, 1);
                        m_objMarker1.SetColor(allPlots[k].GetColor());
                        chartVu.AddChartObject(m_objMarker1);
                        arrmarkerCursor[k] = m_objMarker1;

                        ChartText CurrentLabel = new ChartText(pTransform1, theFont, objPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, arrZValues[arrZValues.Length - (k + 1)], ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                        CurrentLabel.SetColor(allPlots[k].GetColor());
                        chartVu.AddChartObject(CurrentLabel);
                        arrChartTextCursor[k] = CurrentLabel;

                        if (m_objMarker != null)
                        {
                            _DataGridView.Rows.Add(1);
                            _DataGridView[0, k].Value = objPoint.X.ToString();
                            _DataGridView[1, k].Value = objPoint.Y.ToString();
                            _DataGridView[0, k].Style.ForeColor = allPlots[k].GetColor();
                            _DataGridView.Refresh();


                        }
                    }


                }
                chartVu.UpdateDraw();
            }
            catch (Exception ex)
            {
            }
        }
        private void CheckKeyDownSingle(string sType)
        {
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            Point3D ptNewPoint = null;
            Point3D ptLocation = null;
            Point3D ptPreviousPoint = null;
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
                        Point3D objPoint = objDataSet.GetDataPoint(m_iCounter);
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

                        m_objMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, objPoint.X, objPoint.Y, selectedZvalue, 5, 1);
                        m_objMarker.SetColor(_MainCursorColor);
                        chartVu.AddChartObject(m_objMarker);

                        ChartText CurrentLabel = new ChartText(pTransform1, theFont, objPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, selectedZvalue, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                        CurrentLabel.SetColor(_MainCursorColor);
                        chartVu.AddChartObject(CurrentLabel);
                        arrChartTextCursor[0] = CurrentLabel;

                        if (m_objMarker != null)
                        {
                            _DataGridView.Rows.Add(1);
                            _DataGridView[0, 0].Value = objPoint.X.ToString();
                            _DataGridView[1, 0].Value = objPoint.Y.ToString();
                            _DataGridView.Refresh();
                            chartVu.UpdateDraw();

                        }


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
                    Point3D objPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter);
                    ptPreviousPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter + 1);
                    nearestPointObj1 = new NearestPointData();
                    textCoordsFont = new Font("Arial", 8, FontStyle.Regular);

                    ptNewPoint = nearestPointObj1.GetNearestPoint();

                    if (m_objMarker != null)
                    {
                        chartVu.DeleteChartObject(m_objMarker);
                        chartVu.DeleteChartObject(m_objNewMarker);
                    }

                    m_objMarker = new Marker(pTransform1, GraphObj.MARKER_VLINE, objPoint.X, objPoint.Y, selectedZvalue, 5, 1);
                    m_objMarker.SetColor(_MainCursorColor);

                    chartVu.AddChartObject(m_objMarker);

                    ChartText CurrentLabel = new ChartText(pTransform1, theFont, objPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, selectedZvalue, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    chartVu.AddChartObject(CurrentLabel);
                    arrChartTextCursor[0] = CurrentLabel;

                    if (m_objMarker != null)
                    {
                        _DataGridView.Rows.Add(1);
                        _DataGridView[0, 0].Value = objPoint.X.ToString();
                        _DataGridView[1, 0].Value = objPoint.Y.ToString();
                        _DataGridView.Refresh();
                        chartVu.UpdateDraw();

                    }
                }
                arrmarkerCursor = new Marker[1];
                arrmarkerCursor[0] = m_objMarker;
            }
            catch (Exception ex)
            {
            }
        }
        private void CheckKeyDownCrossHair(string sType)
        {
            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            Point3D ptNewPoint = null;
            Point3D ptLocation = null;
            Point3D ptPreviousPoint = null;
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
                        Point3D objPoint = objDataSet.GetDataPoint(m_iCounter);
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

                        m_objMarker = new Marker(pTransform1, GraphObj.MARKER_HVLINE, objPoint.X, objPoint.Y, selectedZvalue, 5, 1);
                        m_objMarker.SetColor(_MainCursorColor);
                        chartVu.AddChartObject(m_objMarker);

                        ChartText CurrentLabel = new ChartText(pTransform1, theFont, objPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, selectedZvalue, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                        CurrentLabel.SetColor(_MainCursorColor);
                        chartVu.AddChartObject(CurrentLabel);
                        arrChartTextCursor[0] = CurrentLabel;

                        if (m_objMarker != null)
                        {
                            _DataGridView.Rows.Add(1);
                            _DataGridView[0, 0].Value = objPoint.X.ToString();
                            _DataGridView[1, 0].Value = objPoint.Y.ToString();
                            _DataGridView.Refresh();
                            chartVu.UpdateDraw();

                        }


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
                    Point3D objPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter);
                    ptPreviousPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter + 1);
                    nearestPointObj1 = new NearestPointData();
                    textCoordsFont = new Font("Arial", 8, FontStyle.Regular);

                    ptNewPoint = nearestPointObj1.GetNearestPoint();

                    if (m_objMarker != null)
                    {
                        chartVu.DeleteChartObject(m_objMarker);
                        chartVu.DeleteChartObject(m_objNewMarker);
                    }

                    m_objMarker = new Marker(pTransform1, GraphObj.MARKER_HVLINE, objPoint.X, objPoint.Y, selectedZvalue, 5, 1);
                    m_objMarker.SetColor(_MainCursorColor);

                    chartVu.AddChartObject(m_objMarker);

                    ChartText CurrentLabel = new ChartText(pTransform1, theFont, objPoint.GetX().ToString() + XLabel + " / " + Convert.ToString(Math.Round(Convert.ToDouble(objPoint.GetY()), 5)) + YLabel, objPoint.GetX(), pTransform1.YScale.ScaleStop, selectedZvalue, ChartObj.PHYS_POS, ChartObj.JUSTIFY_CENTER, ChartObj.JUSTIFY_MIN, 270);
                    CurrentLabel.SetColor(_MainCursorColor);
                    chartVu.AddChartObject(CurrentLabel);
                    arrChartTextCursor[0] = CurrentLabel;

                    if (m_objMarker != null)
                    {
                        _DataGridView.Rows.Add(1);
                        _DataGridView[0, 0].Value = objPoint.X.ToString();
                        _DataGridView[1, 0].Value = objPoint.Y.ToString();
                        _DataGridView.Refresh();
                        chartVu.UpdateDraw();

                    }
                }
                arrmarkerCursor = new Marker[1];
                arrmarkerCursor[0] = m_objMarker;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
