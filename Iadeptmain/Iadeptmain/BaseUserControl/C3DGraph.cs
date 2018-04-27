using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using Iadeptmain.BaseUserControl;
using System.Windows.Forms;
using Iadeptmain.Mainforms;
using Iadeptmain.Classes;
using Iadeptmain.GlobalClasess;
using com.iAM.chart3dnet;

namespace Iadeptmain.BaseUserControl
{
   
    public class C3DGraph
    {
        SimpleLinePlot m_objFirstLinePlot = null;
        SimpleLinePlot m_objSecondLinePlot = null;
        SimpleLinePlot m_objThirdLinePlot = null;
        SimpleLinePlot m_objFourthLinePlot = null;
        SimpleLinePlot m_objClickedPlot = null;
        SimpleLinePlot m_objPreviousLinePlot = null;
        ChartView m_objChartView = null;
        uc3DGraphControl m_obj3DGraphControl = null;
        CartesianCoordinates m_objCartesianCordinates = null;
        private frmValues m_objValuesWindow = null;
        private string m_sUnits = null;
        string m_sTimeAxis = null;
        Font m_objFont = null;
        ArrayList m_arlstDates = null;
        private int iWaterFallCounter = 0;
        CDataDaseWork m_obj3DGraphWork = null;
        private string m_sDataBaseName = null;
        private frmIAdeptMain m_objBaseMainForm = null;
        private frmgraphcontrol m_objMainGraphControl = null;
        private DataCursor m_objDataCursor = null;
        Marker m_objMarker = null;
        private Marker m_objNewMarker = null;
        SimpleLinePlot m_objPlotForHandCursor = null;

        public C3DGraph()
        {
            m_obj3DGraphWork = new CDataDaseWork();
        }


        public uc3DGraphControl ThreeDGraphControl
        {
            set
            {
                m_obj3DGraphControl = value;
                if (m_obj3DGraphControl != null)
                {
                    RegisterEvents();
                }
            }
        }

        public frmgraphcontrol BaseParentControl
        {
            set
            {
                m_objMainGraphControl = value;
               
            }
        }

        public string DataBaseName
        {
            set
            {
                m_sDataBaseName = value;
                if (m_obj3DGraphWork != null)
                    m_obj3DGraphWork.DataBaseName = m_sDataBaseName;
            }
        }


        public frmValues ValuesWindow
        {
            set
            {
                m_objValuesWindow = value;
            }
        }

        public frmIAdeptMain BaseMainForm
        {
            set
            {
                m_objBaseMainForm = value;
                if (m_obj3DGraphWork != null)
                    m_obj3DGraphWork.BaseMainForm = m_objBaseMainForm;
            }
        }

        private void RegisterEvents()
        {
            try
            {
                if (m_obj3DGraphControl != null)
                {
                    m_obj3DGraphControl.GraphClicked -= new uc3DGraphControl.GraphClickedHandler(m_obj3DGraphControl_GraphClicked);
                    m_obj3DGraphControl.GraphClicked += new uc3DGraphControl.GraphClickedHandler(m_obj3DGraphControl_GraphClicked);
                    m_obj3DGraphControl.ThisMouseMove -= new uc3DGraphControl.MouseMoveHandler(m_obj3DGraphControl_ThisMouseMove);
                    
                    m_obj3DGraphControl.ThisMouseMove += new uc3DGraphControl.MouseMoveHandler(m_obj3DGraphControl_ThisMouseMove);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }
        bool bFirstPlot = false;

        void m_obj3DGraphControl_ThisMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            Point2D objClickedPoint = null;
            double dZValue = 0;
            Point3D objPoint3D = null;
            NearestPointData objNearestPoint = null;
            Point3D objLocationPoint = null;
            Point3D objGetPoint = null;
            String sDisplaytext = null;

            try
            {
                objClickedPoint = new Point2D();
                objClickedPoint.SetLocation(e.X, e.Y);

                dZValue = objClickedPoint.GetZ();

                objPoint3D = new Point3D(e.X, e.Y, dZValue);


                m_objPlotForHandCursor  = (SimpleLinePlot)m_objChartView.FindObj(objPoint3D, "SimpleLinePlot");


                if (m_objPlotForHandCursor != null)
                {
                    m_objChartView.Cursor = Cursors.Hand;
                }
                else
                    m_objChartView.Cursor = Cursors.Arrow;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        internal void SetDataCursor()
        {
            try
            {
                m_objDataCursor = new DataCursor(m_objChartView, m_objCartesianCordinates, GraphObj.MARKER_VLINE, 8.0);
                m_objDataCursor.SetColor(Color.Black);
                m_objDataCursor.SetEnable(true);
                m_objDataCursor.LineStyle = DashStyle.Solid;
                m_objDataCursor.SetLineStyle(DashStyle.Solid);
                m_objDataCursor.LineColor = Color.Black;
                m_objChartView.SetCurrentMouseListener(m_objDataCursor);
                m_objChartView.AddChartObject(m_objDataCursor);
             
                if (m_objMarker != null )
                {
                    m_objChartView.DeleteChartObject(m_objMarker);
                    
                    m_objChartView.UpdateDraw();
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
            finally
            {

            }
        }

        private Color m_objPreviousColor;

        void m_obj3DGraphControl_GraphClicked(System.Windows.Forms.MouseEventArgs e)
        {
            
            Point3D objPoint = null;
            Point2D obj2DPoint = null;
            double dImplicitZValue = 0;

            try
            {
                obj2DPoint = new Point2D(e.X, e.Y);

                double dZValue = obj2DPoint.GetZ();


                objPoint = new Point3D(e.X, e.Y,dZValue);
                m_objClickedPlot = (SimpleLinePlot)m_objChartView.FindObj(objPoint, "SimpleLinePlot");

                if (m_objClickedPlot!=null && m_objClickedPlot.LineWidth == 0.5)
                {
                    m_objClickedPlot.SetLineWidth(1.5);
                    m_objMainGraphControl.LabelColor = m_objClickedPlot.GetColor();
                    
                    
                }

                if (m_objPreviousLinePlot!=null && m_objPreviousLinePlot.DisplayDataset!=m_objClickedPlot.DisplayDataset  && m_objPreviousLinePlot.LineWidth==1.5)
                {
                    
                    
                    m_objPreviousLinePlot.SetLineWidth(0.5);
                    
                }

                dImplicitZValue=m_objClickedPlot.DisplayDataset.ImplicitZValue;


                Point3D objLocationPoint = null;
                NearestPointData objNearestPoint = null;
                Point3D objGetPoint = null;


                if (e.Button == MouseButtons.Left)
                {
                    if (m_objDataCursor != null)
                    {
                        objNearestPoint = new NearestPointData();
                      
                        objLocationPoint = m_objDataCursor.Location;
                        m_objDataCursor.SetColor(Color.Transparent);
                        m_objDataCursor.SetLocation(objLocationPoint);
                        
                        if (m_objClickedPlot != null)
                        {
                            bFirstPlot = m_objClickedPlot.CalcNearestPoint(objLocationPoint, 3, objNearestPoint);

                        
                            objGetPoint = objNearestPoint.GetNearestPoint();

                          
                            if (m_objMarker != null)
                            {
                                m_objChartView.DeleteChartObject(m_objMarker);
                                m_objChartView.DeleteChartObject(m_objDataCursor);
                            }
                         
                            m_objMarker = new Marker(m_objCartesianCordinates, GraphObj.MARKER_BOX, objLocationPoint.GetX(), objLocationPoint.GetY(), objLocationPoint.GetZ(), 8, 1);


                            m_objMarker.FillColor = Color.Black;
                            m_objMarker.SetColor(Color.Black);


                            m_objChartView.AddChartObject(m_objMarker);

                            string sDisplaytext = "X Value:" + objLocationPoint.GetX() + "\n" + "Y Value:" + objLocationPoint.GetY();
                            m_obj3DGraphControl.SetLabelText(sDisplaytext);
                            
                        }
                    }

                }



                m_objChartView.UpdateDraw();
            
               m_objPreviousLinePlot = m_objClickedPlot;
               m_objPreviousColor = m_objClickedPlot.GetColor();
            
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        public string Units
        {
            set
            {
                m_sUnits = value;
            }
        }

        public int WaterFallCounter
        {
            set
            {
                iWaterFallCounter = value;
            }
        }

        public string TimeAxisValue
        {
            set
            {
                m_sTimeAxis = value;
            }
        }

        public ArrayList Dates
        {
            set
            {
                m_arlstDates = value;
            }
        }


        internal void CommonFunctionality(SimpleDataset3D[] arrSimpleDS)
        {
            int iCount = 0;
            Background objCBGND = null;
            ChartAttribute objWallAttribute = null;
            Wall3D objxyMinZWall = null;

            Wall3D objyzMinXWall = null;
           
            Wall3D objxzMinYWall = null;
            LinearAxis xAxis = null;
            LinearAxis yAxis = null;
            AxisTitle objXAxisTitle = null;
            AxisTitle objYAxisTitle = null;
            NumericAxisLabels XAxisLabel = null;
            NumericAxisLabels YAxisLabel = null;
            Grid xGrid = null;
            Grid yGrid = null;
            ChartAttribute objAttribute = null;
                     

            try
            {
                iCount = arrSimpleDS.Length;
                m_objChartView = m_obj3DGraphControl;
                if (m_obj3DGraphControl != null)
                    m_objChartView = m_obj3DGraphControl;

                string[] sarrLabels = m_sUnits.Split(new char[] { ',' });

                m_objFont=new Font("Microsoft Sans Serif",5,FontStyle.Regular);

                m_objCartesianCordinates = new CartesianCoordinates();
                m_objCartesianCordinates.AutoScale(arrSimpleDS, ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_EXACT);


                m_objCartesianCordinates.AbsRotateCoordinateSystem(new Point3D(5, 3, 0));
                
                m_objChartView.SetFractionalZViewportDepth(4);

                objCBGND = new Background(m_objCartesianCordinates, ChartObj.GRAPH_BACKGROUND, Color.FromArgb(241, 241, 247));
                m_objChartView.AddChartObject(objCBGND);

                objWallAttribute = new ChartAttribute(Color.Beige, 0.5, DashStyle.Solid, Color.LightGray);
                objxyMinZWall = new Wall3D(m_objCartesianCordinates, ChartObj.XY_MAXZ_PLANE,0,objWallAttribute);
                m_objChartView.AddChartObject(objxyMinZWall);
                objyzMinXWall = new Wall3D(m_objCartesianCordinates, ChartObj.YZ_MINX_PLANE, 0, objWallAttribute);
                m_objChartView.AddChartObject(objyzMinXWall);
                objxzMinYWall = new Wall3D(m_objCartesianCordinates, ChartObj.XZ_MINY_PLANE, 0, objWallAttribute);
                m_objChartView.AddChartObject(objxzMinYWall);

                m_objCartesianCordinates.SetGraphBorderDiagonal(0.15, .15, .90, 0.75);

                xAxis = new LinearAxis(m_objCartesianCordinates, ChartObj.X_AXIS);
                xAxis.CalcAutoAxis();
                m_objChartView.AddChartObject(xAxis);

                XAxisLabel = new NumericAxisLabels(xAxis);
                XAxisLabel.SetTextFont(m_objFont);
                m_objChartView.AddChartObject(XAxisLabel);


                

                switch(m_sTimeAxis)
                {
                    case "Sec":
                        objXAxisTitle = new AxisTitle(xAxis, m_objFont, "Sec");
                        m_objChartView.AddChartObject(objXAxisTitle);

                        break;
                    case "Others":

                        objXAxisTitle = new AxisTitle(xAxis, m_objFont,sarrLabels[0] );
                        m_objChartView.AddChartObject(objXAxisTitle);
                        break;
                }

                yAxis = new LinearAxis(m_objCartesianCordinates, ChartObj.Y_AXIS);
                yAxis.CalcAutoAxis();
                m_objChartView.AddChartObject(yAxis);

                YAxisLabel = new NumericAxisLabels(yAxis);
                YAxisLabel.SetTextFont(m_objFont);
                m_objChartView.AddChartObject(YAxisLabel);


                objYAxisTitle = new AxisTitle(yAxis, m_objFont, sarrLabels[1]);
                m_objChartView.AddChartObject(objYAxisTitle);

                switch (iCount)
                {
                    case 1:

                        objAttribute=new ChartAttribute(Color.DarkRed,0.5,DashStyle.Solid);
                        m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                        m_objChartView.AddChartObject(m_objFirstLinePlot);

                        
                        ChartText objFirstText = new ChartText(m_objCartesianCordinates, m_objFont, (string)m_arlstDates[0], m_objFirstLinePlot.DisplayDataset.XData[m_objFirstLinePlot.DisplayDataset.XData.Length - 60], m_objFirstLinePlot.DisplayDataset.YData[m_objFirstLinePlot.DisplayDataset.YData.Length - 60], ChartObj.PHYS_POS);

                        m_objChartView.AddChartObject(objFirstText);

                        break;
                    case 2:
                        objAttribute = new ChartAttribute(Color.DarkRed, 0.5, DashStyle.Solid);
                        m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                        m_objChartView.AddChartObject(m_objFirstLinePlot);

                        ChartText objNewFirstText = new ChartText(m_objCartesianCordinates,m_objFont,(string) m_arlstDates[1], m_objFirstLinePlot.DisplayDataset.XData[m_objFirstLinePlot.DisplayDataset.XData.Length - 60], m_objFirstLinePlot.DisplayDataset.YData[m_objFirstLinePlot.DisplayDataset.YData.Length - 60],0.002,ChartObj.PHYS_POS);
                       
                        m_objChartView.AddChartObject(objNewFirstText);

                        objAttribute = new ChartAttribute(Color.DarkGreen, 0.5, DashStyle.Solid);
                        m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                        m_objChartView.AddChartObject(m_objSecondLinePlot);

                        ChartText objSecondText = new ChartText(m_objCartesianCordinates,m_objFont, (string)m_arlstDates[0], m_objSecondLinePlot.DisplayDataset.XData[m_objSecondLinePlot.DisplayDataset.XData.Length - 60], m_objSecondLinePlot.DisplayDataset.YData[m_objSecondLinePlot.DisplayDataset.YData.Length - 60], 0,ChartObj.PHYS_POS);
                        m_objChartView.AddChartObject(objSecondText);
                        

                        break;
                    case 3:

                        objAttribute = new ChartAttribute(Color.DarkRed, 0.5, DashStyle.Solid);
                        m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                        m_objChartView.AddChartObject(m_objFirstLinePlot);

                        ChartText objThirdFirstText = new ChartText(m_objCartesianCordinates,m_objFont, (string)m_arlstDates[2], m_objFirstLinePlot.DisplayDataset.XData[m_objFirstLinePlot.DisplayDataset.XData.Length - 60], m_objFirstLinePlot.DisplayDataset.YData[m_objFirstLinePlot.DisplayDataset.YData.Length - 60], 0.0045, ChartObj.PHYS_POS);

                        m_objChartView.AddChartObject(objThirdFirstText);

                        objAttribute = new ChartAttribute(Color.DarkGreen, 0.5, DashStyle.Solid);
                        m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                        m_objChartView.AddChartObject(m_objSecondLinePlot);

                        ChartText objThirdSecondText = new ChartText(m_objCartesianCordinates,m_objFont, (string)m_arlstDates[1], m_objSecondLinePlot.DisplayDataset.XData[m_objSecondLinePlot.DisplayDataset.XData.Length - 60], m_objSecondLinePlot.DisplayDataset.YData[m_objSecondLinePlot.DisplayDataset.YData.Length - 60], 0.0025, ChartObj.PHYS_POS);
                        m_objChartView.AddChartObject(objThirdSecondText);

                        objAttribute = new ChartAttribute(Color.DarkGoldenrod, 0.5, DashStyle.Solid);
                        m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                        m_objChartView.AddChartObject(m_objThirdLinePlot);

                        ChartText objThirdThirdText = new ChartText(m_objCartesianCordinates,m_objFont, (string)m_arlstDates[0], m_objThirdLinePlot.DisplayDataset.XData[m_objThirdLinePlot.DisplayDataset.XData.Length - 60], m_objThirdLinePlot.DisplayDataset.YData[m_objThirdLinePlot.DisplayDataset.YData.Length - 60], 0,ChartObj.PHYS_POS);
                        m_objChartView.AddChartObject(objThirdThirdText);



                        break;
                    case 4:

                        objAttribute = new ChartAttribute(Color.DarkRed, 0.5, DashStyle.Solid);
                        m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                        m_objChartView.AddChartObject(m_objFirstLinePlot);

                        ChartText objFourthFirstText = new ChartText(m_objCartesianCordinates,m_objFont, (string)m_arlstDates[3], m_objFirstLinePlot.DisplayDataset.XData[m_objFirstLinePlot.DisplayDataset.XData.Length - 60], m_objFirstLinePlot.DisplayDataset.YData[m_objFirstLinePlot.DisplayDataset.YData.Length - 60], 0.0075, ChartObj.PHYS_POS);

                        m_objChartView.AddChartObject(objFourthFirstText);

                        objAttribute = new ChartAttribute(Color.DarkGreen, 0.5, DashStyle.Solid);
                        m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                        m_objChartView.AddChartObject(m_objSecondLinePlot);

                        ChartText objFourthSecondText = new ChartText(m_objCartesianCordinates,m_objFont, (string)m_arlstDates[2], m_objSecondLinePlot.DisplayDataset.XData[m_objSecondLinePlot.DisplayDataset.XData.Length - 60], m_objSecondLinePlot.DisplayDataset.YData[m_objSecondLinePlot.DisplayDataset.YData.Length - 60], 0.0045, ChartObj.PHYS_POS);
                        m_objChartView.AddChartObject(objFourthSecondText);

                        objAttribute = new ChartAttribute(Color.DarkGoldenrod, 0.5, DashStyle.Solid);
                        m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                        m_objChartView.AddChartObject(m_objThirdLinePlot);

                        ChartText objFourthThirdText = new ChartText(m_objCartesianCordinates,m_objFont, (string)m_arlstDates[1], m_objThirdLinePlot.DisplayDataset.XData[m_objThirdLinePlot.DisplayDataset.XData.Length - 60], m_objThirdLinePlot.DisplayDataset.YData[m_objThirdLinePlot.DisplayDataset.YData.Length - 60],0.002 ,ChartObj.PHYS_POS);
                        m_objChartView.AddChartObject(objFourthThirdText);
                                             

                        objAttribute = new ChartAttribute(Color.DarkViolet, 0.5, DashStyle.Solid);
                        m_objFourthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[3], objAttribute);
                        m_objChartView.AddChartObject(m_objFourthLinePlot);


                        ChartText objFourthFourthText = new ChartText(m_objCartesianCordinates,m_objFont, (string)m_arlstDates[0], m_objFourthLinePlot.DisplayDataset.XData[m_objFourthLinePlot.DisplayDataset.XData.Length - 60], m_objFourthLinePlot.DisplayDataset.YData[m_objFourthLinePlot.DisplayDataset.YData.Length - 60],0 ,ChartObj.PHYS_POS);
                        m_objChartView.AddChartObject(objFourthFourthText);

                        break;
                }


            }
            catch
            {
                throw;
            }
        }








        internal void RemoveChartObjects(int iItems)
        {
            try
            {
                switch (iItems)
                {
                    case 1:

                        if (m_objFirstLinePlot != null)
                        {
                            m_objChartView.DeleteChartObject(m_objFirstLinePlot);
                            m_objChartView.UpdateDraw();

                        }


                        break;
                    case 2:
                        if (m_objFirstLinePlot != null && m_objSecondLinePlot != null)
                        {
                            m_objChartView.DeleteChartObject(m_objFirstLinePlot);
                            m_objChartView.DeleteChartObject(m_objSecondLinePlot);
                            m_objChartView.UpdateDraw();
                        }

                        break;
                    case 3:
                        if (m_objFirstLinePlot != null && m_objSecondLinePlot != null && m_objThirdLinePlot != null)
                        {
                            m_objChartView.DeleteChartObject(m_objFirstLinePlot);
                            m_objChartView.DeleteChartObject(m_objSecondLinePlot);
                            m_objChartView.DeleteChartObject(m_objThirdLinePlot);
                            m_objChartView.UpdateDraw();
                        }

                        break;
                    case 4:

                        if (m_objFirstLinePlot != null && m_objSecondLinePlot != null && m_objThirdLinePlot != null && m_objFourthLinePlot != null)
                        {
                            m_objChartView.DeleteChartObject(m_objFirstLinePlot);
                            m_objChartView.DeleteChartObject(m_objSecondLinePlot);
                            m_objChartView.DeleteChartObject(m_objThirdLinePlot);
                            m_objChartView.DeleteChartObject(m_objFourthLinePlot);
                            m_objChartView.UpdateDraw();
                        }

                        break;
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
