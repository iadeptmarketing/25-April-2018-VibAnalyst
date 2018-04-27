using System;
using System.Collections.Generic;
using System.Text;

using Iadeptmain.Mainforms;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using System.Drawing.Imaging;
using System.Threading;
using com.iAM.chart2dnet;
using Iadeptmain.GlobalClasses;
using Iadeptmain.Classes;
using System.Data;

namespace Iadeptmain.BaseUserControl
{
    class C2DGraphView
    {

        SimpleLinePlot m_objFirstLinePlot = null;
        SimpleLinePlot m_objSecondLinePlot = null;
        SimpleLinePlot m_objThirdLinePlot = null;
        SimpleLinePlot m_objFourthLinePlot = null;
        SimpleLinePlot m_objClickedPlot = null;
        SimpleLinePlot m_objPreviousLinePlot = null;
        ChartView m_objChartView = null;
        IadeptUserControl m_objMainControl = null;
        uc3DGraphControl m_obj3DGraphControl = null;
        SimpleLinePlot m_objOldSelectedPlot = null;
        SimpleLinePlot objStackedLinePlot = null;
        SimpleBarPlot m_objBarPlot = null;
        SimpleLinePlot thePlot1 = null;
        ChartAttribute attrStackedArea = null;
        GraphView m_obj2DGraphControl = null;
        CartesianCoordinates m_objCartesianCordinates = null;
        private frmValues m_objValuesWindow = null;
        private string m_sUnits = null;
        string m_sTimeAxis = null;
        Font m_objFont = null;
        ArrayList m_arlstDates = null;
        private int iWaterFallCounter = 0;
        CDataDaseWork m_obj3DGraphWork = null;
        private string m_sDataBaseName = null;
        private frmIAdeptMain m_objBaseMainForm;
        private frmgraphcontrol m_objMainGraphControl = null;
        private DataCursor m_objDataCursor = null;
        ChartAttribute attrib1 = null;
        Marker m_objMarker = null;
        private Marker m_objNewMarker = null;
        SimpleLinePlot m_objPlotForHandCursor = null;

        public C2DGraphView()
        {
            m_objPointsInData = new Dictionary<Point2D, Point2D>();
        }

        public IadeptUserControl MainBaseControl
        {
            set
            {
                m_objMainControl = value;
            }
        }

        public GraphView TwoDGraphControl
        {
            set
            {
                m_obj2DGraphControl = value;
                if (m_obj2DGraphControl != null)
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
                if (m_obj2DGraphControl != null)
                {
                    m_obj2DGraphControl.GraphClicked -= new GraphView.GraphClickedHandler(m_obj2DGraphControl_GraphClicked);
                    m_obj2DGraphControl.GraphClicked += new GraphView.GraphClickedHandler(m_obj2DGraphControl_GraphClicked);
                    m_obj2DGraphControl.ThisMouseMove -= new GraphView.MouseMoveHandler(m_obj2DGraphControl_ThisMouseMove);
                    m_obj2DGraphControl.ThisMouseMove += new GraphView.MouseMoveHandler(m_obj2DGraphControl_ThisMouseMove);
                    ;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        SimpleLinePlot m_objSelectedPlot = null;
        SimpleLinePlot m_objNewPlot = null;
        SimpleLinePlot m_objSelectedPlotForCursor = null;
        int m_iCounter = 0;
        bool bOverall = false;

        public bool IsOverall
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
        


        internal void CopyMapToClipBoard()
        {
            try
            {
                Bitmap bmpScreenshot;
                Graphics gfxScreenshot;
                Size screenshotSize = new Size();
             
                BufferedImage objImage = new BufferedImage(m_objChartView);
                objImage.SaveImage(AppDomain.CurrentDomain.BaseDirectory + @"Benstone\Images\Copy.jpg");
                bmpScreenshot = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + @"Benstone\Images\Copy.jpg");
                
                Clipboard.SetImage(bmpScreenshot);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        void m_obj2DGraphControl_ThisMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            Point2D objClickedPoint = null;
            double dZValue = 0;
            Point2D objPoint3D = null;
            NearestPointData objNearestPoint = null;
            Point2D objLocationPoint = null;
            Point2D objGetPoint = null;
            String sDisplaytext = null;

            string inst = PublicClass.currentInstrument;

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
            SimpleDataset Dataset1 = null;

            try
            {

                Point2D objNewPoint = new Point2D();


                objNewPoint.SetLocation(e.X, e.Y);



                ChartObj objNewObject = m_objChartView.FindObj(objNewPoint, "SimpleLinePlot");

                if (objNewObject != null)
                {
                    m_objChartView.Cursor = Cursors.Hand;
                    m_objSelectedPlot = (SimpleLinePlot)objNewObject;
                    m_objNewPlot = (SimpleLinePlot)objNewObject;

                   
                }
                else
                {
                    m_objChartView.Cursor = Cursors.Arrow;
                    m_objSelectedPlot = null;
                }


                if (e.Button == MouseButtons.Left)
                {

                    if (m_objDataCursor != null)
                    {


                        if (m_objNewPlot != null)
                        {
                            m_objSelectedPlotForCursor = m_objNewPlot;


                            if (m_objClickedPlot != null && m_objClickedPlot.LineWidth == 2)
                            {
                                Dataset1 = m_objSelectedPlotForCursor.DisplayDataset;
                                Point2D objPoint = Dataset1.GetDataPoint(m_iCounter);


                                nearestPointObj1 = new NearestPointData();
                                objSecondNearestPoint = new NearestPointData();
                                textCoordsFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                                m_obj2DGraphControl.TriggerBaseMouseMove(e);
                                ptLocation = m_objDataCursor.Location;

                                bFirstPlot = m_objClickedPlot.CalcNearestPoint(ptLocation, 3, nearestPointObj1);


                                ptNewPoint = nearestPointObj1.GetNearestPoint();


                                if (m_objMarker != null)
                                {
                                    m_objChartView.DeleteChartObject(m_objMarker);                                 
                                    
                                    m_objChartView.DeleteChartObject(m_objDataCursor);

                                }


                                m_objMarker = new Marker(m_objCartesianCordinates, GraphObj.MARKER_BOX, ptNewPoint.GetX(), ptNewPoint.GetY(), 8, 1);


                                m_objMarker.FillColor = Color.Black;
                                m_objMarker.SetColor(Color.Black);


                                m_objChartView.AddChartObject(m_objMarker);


                                if (m_objMarker != null)
                                {


                                    if (bOverall)
                                    {
                                        double dtx = ptNewPoint.GetX();
                                        {
                                            if (inst == "DI-460")
                                            {
                                                
                                            }
                                            else if (inst == "Card Vibro Neo")
                                            {
                                                MessageBox.Show("Not Implemented");
                                            }
                                            else if (inst == "Impaq-Benstone"||inst=="Fieldpaq2")
                                            {
                                                m_obj2DGraphControl.SetLabelText("X Value:" + sarrTime[Convert.ToInt32(dtx) - 1] + "\n" + "Y Value:" + ptNewPoint.GetY());
                                            }
                                        }
                                       
                                    }
                                    else
                                    {
                                        m_obj2DGraphControl.SetLabelText("X Value:" + ptNewPoint.GetX() + "\n" + "Y Value:" + ptNewPoint.GetY());
                                    }

                                    m_objChartView.UpdateDraw();
                                    
                                }

                            }
                        }

                        m_iCounter++;

                        int iNumber = Dataset1.GetNumberDatapoints();
                        if (m_iCounter > iNumber)
                            m_iCounter = iNumber;
                    }
                    else
                    {
                        MessageBox.Show("Please select DataCursor", "Select Data Cursor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }





            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
            
        }

        SimpleScatterPlot m_objScatterPlot = null;


        internal void SaveReportingImage(string sCompletePointName)
        {
            try
            {
                BufferedImage objImage = new BufferedImage(m_objChartView);
                objImage.SaveImage(AppDomain.CurrentDomain.BaseDirectory + @"Benstone\Images\" + sCompletePointName + ".jpg");

            }
            catch (Exception ex)
            {
               
            }
        }

        internal void CopyValuesToClipBoardOutside()
        {
            try
            {
                if (m_objClickedPlot != null && m_objClickedPlot.LineWidth == 2)
                {
                    CopyValuestoClipBoard();
                }
                else
                {
                    MessageBox.Show("Select a graph to Copy its data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }
       
        private void CopyValuestoClipBoard()
        {
            DataTable dt = new DataTable();
            StringBuilder ydata = new StringBuilder();
            try
            {
                
                
                dt = DbClass.getdata(CommandType.Text, "select pp.PointName,mac.Name,tra.Name,area.Name,fac.Name from point pp inner join  machine_info mac on mac.Machine_ID=pp.Machine_ID left join train_info tra on tra.Train_ID=mac.TrainID left join area_info area on area.Area_ID=tra.Area_ID left join factory_info fac on fac.Factory_ID=area.FactoryID where pp.Point_ID='" + PublicClass.SPointID + "'");
                string sPointName = Convert.ToString(dt.Rows[0]["PointName"]);
                string sSubElementName = Convert.ToString(dt.Rows[0]["mac.Name"]);
                string sElementName = Convert.ToString(dt.Rows[0]["tra.Name"]);
                string sResourceName = Convert.ToString(dt.Rows[0]["area.Name"]);
                string sFactoryName = Convert.ToString(dt.Rows[0]["fac.Name"]);
                string Direction = m_objMainGraphControl.GraphDirection;
                string Type = m_objMainGraphControl.GraphType;
                string Time = m_objMainGraphControl.LabelTime;
                string sCompleteX = m_objMainGraphControl.CopiedX;
                string sCompletey = m_objMainGraphControl.CopiedY;
                
                
                double[] dXValues = ((SimpleDataset)m_objClickedPlot.GetDataset()).XData.DataBuffer;
                double[] dYValues = ((SimpleDataset)m_objClickedPlot.GetDataset()).YData.DataBuffer;

                
                
                ydata.Append(sFactoryName + "->" + sResourceName + "->" + sElementName + "->" + sSubElementName + "->" + sPointName + "\n" + "Direction: " + Direction + "\n" + "Type: " + Type + "\n");
                ydata.Append(Time + "\n");
                ydata.Append("X Values" + "\t");
                ydata.Append("Y Values" + "\n");


                string[] arrXValues = new string[dXValues.Length];
                string[] arrYValues = new string[dYValues.Length];
                for (int iCounter = 0; iCounter < dYValues.Length; iCounter++)
                {
                    arrXValues[iCounter] = dXValues[iCounter].ToString();
                    arrYValues[iCounter] = dYValues[iCounter].ToString();

                    ydata.Append(arrXValues[iCounter].ToString() + "\t" + "\t" + arrYValues[iCounter].ToString() + "\n");
                }

                Clipboard.SetText(ydata.ToString());

                MessageBox.Show("Copied to ClipBoard." + "\n" + "Click Paste in word/excel/notepad etc.");
            }
            catch (Exception ex)
            {
                
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


                    if (m_objClickedPlot != null)
                    {
                        ChartAttribute objAttribute = m_objClickedPlot.GetChartObjAttributes();

                        objAttribute.SetFillFlag(false);

                        m_objClickedPlot.ChartObjAttributes = objAttribute;
                        m_objChartView.UpdateDraw();
                    }
                 

                }
                else if (sText == "AreaPlot ")
                {

                    if (m_objClickedPlot != null)
                    {
                        ChartAttribute objAttribute = m_objClickedPlot.GetChartObjAttributes();
                        objAttribute.SetFillFlag(true);
                        objAttribute.SetFillColor(m_objClickedPlot.LineColor);
                        m_objClickedPlot.ChartObjAttributes = objAttribute;
                        m_objChartView.UpdateDraw();
                    }
                   

                }
                    m_objChartView.UpdateDraw();

            
                
            }
            catch (Exception ex)
            {
                

            }
        }

       
        void m_obj2DGraphControl_GraphClicked(System.Windows.Forms.MouseEventArgs e)
        {
            Point2D objPoint = null;
            Point2D obj2DPoint = null;
            double dImplicitZValue = 0;

            NearestPointData nearestPointObj1 = null;
            Font textCoordsFont = null;
            Point2D ptNewPoint = null;
            Point2D ptLocation = null;
            Point2D ptPointGot = null;
            IDictionaryEnumerator objEnumerator = null;

            try
            {
                
                if (e.Button == MouseButtons.Left)
                {
                    

                    if (m_objMarker != null && m_objNewMarker != null)
                    {
                       m_objChartView.DeleteChartObject(m_objNewMarker);
                       m_objChartView.DeleteChartObject(m_objMarker);
                    }

                    m_obj2DGraphControl.ParentForm.SetCounter = 0;
                    if (m_objSelectedPlot == null)
                    {
                    }

                    

                    else if (m_objSelectedPlot.LineWidth == 2 && m_objSelectedPlot != null)
                    {
                        if (m_objOldSelectedPlot != null)
                            m_objOldSelectedPlot.SetLineWidth(1);

                       
                        m_iCounter = 0;

                        m_obj2DGraphControl.SetLabelText(CValues.SCONSTXY);

                        m_objSelectedPlot.SetLineWidth(1);
                    }
                    else if (m_objOldSelectedPlot == null)
                    {
                        m_objSelectedPlot.SetLineWidth(2);
                        if (m_objOldSelectedPlot != null)
                        {
                            m_objOldSelectedPlot.SetLineWidth(1);
                        }

                        m_iCounter = 0;
                        m_obj2DGraphControl.SetLabelText(CValues.SCONSTXY);

                    }
                    else if (m_objOldSelectedPlot != null)
                    {
                        m_objOldSelectedPlot.SetLineWidth(1);
                        m_objSelectedPlot.SetLineWidth(2);

                        //Point2D objInitialPoint = m_objSelectedPlot.DisplayDataset.GetDataPoint(0);
                        //if (m_objNewMarker != null)
                        //{
                        //    m_objNewMarker.SetLocation(objInitialPoint);
                        //    m_objMarker.SetLocation(objInitialPoint);
                        //    chartVu.UpdateDraw();
                        //}
                        m_iCounter = 0;
                        m_obj2DGraphControl.SetLabelText(CValues.SCONSTXY);

                    }

                    m_objChartView.UpdateDraw();
                    if (m_objSelectedPlot != null)
                    {
                        m_objOldSelectedPlot = m_objSelectedPlot;
                    }
                    if (m_objSelectedPlot.LineWidth == 2)
                    {
                        NumericLabel objLabel = m_objSelectedPlot.PlotLabelTemplate;
                        Color clrClicked = m_objSelectedPlot.GetColor();
                        
                        m_obj2DGraphControl.ParentForm.LabelColor = clrClicked;


                    }

                    else if (m_objDataCursor != null)
                    {

                        if (m_objNewPlot != null && m_objNewPlot.LineWidth == 2)
                        {

                            objPoint = m_objSelectedPlot.DisplayDataset.GetDataPoint(m_iCounter);
                            
                            nearestPointObj1 = new NearestPointData();
                            textCoordsFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);

                            ptLocation = m_objDataCursor.Location;
                            m_objNewPlot.CalcNearestPoint(ptLocation, 3, nearestPointObj1);

                            ptNewPoint = nearestPointObj1.GetNearestPoint();


                            if (m_objMarker != null)
                            {
                                m_objChartView.DeleteChartObject(m_objMarker);
                            
                            }

                            m_objMarker.FillColor = Color.AliceBlue;

                            m_objChartView.AddChartObject(m_objMarker);


                            if (m_objMarker != null)
                            {
                                m_obj2DGraphControl.SetLabelText("X Value:" + ptNewPoint.GetX() + "\n" + "Y Value:" + ptNewPoint.GetY());

                                m_objChartView.UpdateDraw();
                            }
                            m_iCounter++;

                            int iNumber = m_objSelectedPlot.DisplayDataset.GetNumberDatapoints();
                            if (m_iCounter > iNumber)
                                m_iCounter = iNumber;
                        }

                    }

                    if (m_objSelectedPlot.LineWidth == 2)
                    {
                        switch (m_objSelectedPlot.DisplayDataset.DataName)
                        {
                            case "First":
                                m_obj2DGraphControl.ParentForm.SetForeColorDateTime = m_objSelectedPlot.LineColor;
                                m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[0];
                                m_obj2DGraphControl.ParentForm.FillOverAllValues((string)m_arlstDates[0]);
                                break;
                            case "Second":
                                m_obj2DGraphControl.ParentForm.SetForeColorDateTime = m_objSelectedPlot.LineColor;
                                m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[1];
                                m_obj2DGraphControl.ParentForm.FillOverAllValues((string)m_arlstDates[1]);
                               
                                break;
                            case "Third":
                                m_obj2DGraphControl.ParentForm.SetForeColorDateTime = m_objSelectedPlot.LineColor;
                                m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[2];
                                m_obj2DGraphControl.ParentForm.FillOverAllValues((string)m_arlstDates[2]);
                                break;
                            case "Four":
                                m_obj2DGraphControl.ParentForm.SetForeColorDateTime = m_objSelectedPlot.LineColor;
                                m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[3];
                                m_obj2DGraphControl.ParentForm.FillOverAllValues((string)m_arlstDates[3]);
                                break;
                            case "Five":
                                m_obj2DGraphControl.ParentForm.SetForeColorDateTime = m_objSelectedPlot.LineColor;
                                m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[4];
                                m_obj2DGraphControl.ParentForm.FillOverAllValues((string)m_arlstDates[4]);
                                break;
                            case "Six":
                                m_obj2DGraphControl.ParentForm.SetForeColorDateTime = m_objSelectedPlot.LineColor;
                                m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[5];
                                m_obj2DGraphControl.ParentForm.FillOverAllValues((string)m_arlstDates[5]);
                                break;
                            case "Seven":
                                m_obj2DGraphControl.ParentForm.SetForeColorDateTime = m_objSelectedPlot.LineColor;
                                m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[6];
                                m_obj2DGraphControl.ParentForm.FillOverAllValues((string)m_arlstDates[6]);
                                break;
                            case "Eight":
                                m_obj2DGraphControl.ParentForm.SetForeColorDateTime = m_objSelectedPlot.LineColor;
                                m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[7];
                                m_obj2DGraphControl.ParentForm.FillOverAllValues((string)m_arlstDates[7]);
                                break;
                            case "Ninth":
                                m_obj2DGraphControl.ParentForm.SetForeColorDateTime = m_objSelectedPlot.LineColor;
                                m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[8];
                                m_obj2DGraphControl.ParentForm.FillOverAllValues((string)m_arlstDates[8]);
                                break;
                            case "Tenth":
                                m_obj2DGraphControl.ParentForm.SetForeColorDateTime = m_objSelectedPlot.LineColor;
                                m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[9];
                                m_obj2DGraphControl.ParentForm.FillOverAllValues((string)m_arlstDates[9]);
                                break;
                        }
                    }

                }
                else if (e.Button == MouseButtons.Right)
                {
                    m_objSelectedPlot.SetLineWidth(1);

                    m_objChartView.UpdateDraw();
                }

                m_objClickedPlot = m_objSelectedPlot;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
            

        }
        bool bFirstPlot = false;

 
        ChartZoom m_objChartZoom = null;

        internal void SetZoom()
        {
            try
            {

                m_objChartZoom = new ChartZoom(m_objChartView,m_objCartesianCordinates,true);
                
                m_objChartZoom.SetButtonMask(MouseButtons.Left);
                m_objChartZoom.SetZoomYEnable(true);
                m_objChartZoom.SetZoomXEnable(true);
                m_objChartZoom.SetZoomXRoundMode(ChartObj.AUTOAXES_NEAR);
                m_objChartZoom.SetZoomYRoundMode(ChartObj.AUTOAXES_NEAR);
                m_objChartZoom.SetEnable(true);
                m_objChartZoom.SetZoomStackEnable(true);

                m_objChartView.SetCurrentMouseListener(m_objChartZoom);
                m_objChartView.UpdateDraw();

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
                if (m_objDataCursor != null)
                {
                    m_objChartView.DeleteChartObject(m_objDataCursor);
                    m_objChartView.UpdateDraw();
                }
                m_objDataCursor = new DataCursor(m_objChartView, m_objCartesianCordinates, GraphObj.MARKER_VLINE, 8.0);
                m_objDataCursor.SetColor(Color.Black);
                m_objDataCursor.SetEnable(true);
                m_objDataCursor.LineStyle = DashStyle.Solid;
                m_objDataCursor.SetLineStyle(DashStyle.Solid);
                m_objDataCursor.LineColor = Color.Black;
                m_objChartView.SetCurrentMouseListener(m_objDataCursor);
                m_objChartView.AddChartObject(m_objDataCursor);
                
                if (m_objMarker != null)
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


        internal void UnZoom()
        {
            int iTest = 0;

            try
            {

                do
                {
                    if (m_objChartZoom != null)
                    {
                        iTest = m_objChartZoom.PopZoomStack();
                    }
                }
                while (iTest != 0);
                
            }
            catch (Exception ex)
            {
            }

            finally
            {
                m_objDataCursor = null;
            }
        }


        void m_obj3DGraphControl_GraphClicked(System.Windows.Forms.MouseEventArgs e)
        {

            Point2D objPoint = null;
            Point2D obj2DPoint = null;
            double dImplicitZValue = 0;

            try
            {
                obj2DPoint = new Point2D(e.X, e.Y);

                objPoint = new Point2D(e.X, e.Y);
                m_objClickedPlot = (SimpleLinePlot)m_objChartView.FindObj(objPoint, "SimpleLinePlot");

                if (m_objClickedPlot != null && m_objClickedPlot.LineWidth == 0.5)
                {
                    m_objClickedPlot.SetLineWidth(1.5);
                    m_objMainGraphControl.LabelColor = m_objClickedPlot.GetColor();

                }

                if (m_objPreviousLinePlot != null && m_objPreviousLinePlot.DisplayDataset != m_objClickedPlot.DisplayDataset && m_objPreviousLinePlot.LineWidth == 1.5)
                {
                    m_objPreviousLinePlot.SetLineWidth(0.5);
                    
                }
                Point2D objLocationPoint = null;
                NearestPointData objNearestPoint = null;
                Point2D objGetPoint = null;


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
                            
                            m_objMarker = new Marker(m_objCartesianCordinates, GraphObj.MARKER_BOX, objLocationPoint.GetX(), objLocationPoint.GetY(), 8, 1);


                            m_objMarker.FillColor = Color.Black;
                            m_objMarker.SetColor(Color.Black);


                            m_objChartView.AddChartObject(m_objMarker);

                            string sDisplaytext = "X Value:" + objLocationPoint.GetX() + "\n" + "Y Value:" + objLocationPoint.GetY();
                            m_obj2DGraphControl.SetLabelText(sDisplaytext);
                         
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
            }//end(set)
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

        internal void RemoveChartObjects()
        {
            ArrayList arlstChartObjects = null;
            int iCountToRemove = 0;
            try
            {
                if (m_objChartView!= null)
                {
                    arlstChartObjects = m_objChartView.GetChartObjectsArrayList();
                    iCountToRemove = arlstChartObjects.Count;
                    for (int iCtr = 0; iCtr < iCountToRemove; iCtr++)
                    {
                        if (m_objDataCursor != null)
                            m_objDataCursor = null;
                        GraphObj objObjectsToRemove = (GraphObj)arlstChartObjects[0];

                        if (m_objChartView != null)
                            m_objChartView.DeleteChartObject(objObjectsToRemove);

                    }

                    m_objChartView.UpdateDraw();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
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
        Color m_objcolor;
        public Color SetBackColor
        {
            set
            {
                m_objcolor = value;
                objCBGND.SetColor(m_objcolor);
                m_objChartView.UpdateDraw();

            }
        }
        Background objCBGND = null;
        internal void CommonFunctionality(SimpleDataset[] arrSimpleDS)
        {
            int iCount = 0;
            objCBGND = null;
            ChartAttribute objWallAttribute = null;
            Grid xgrid = null;
            Grid ygrid = null;
           
            LinearAxis xAxis = null;
            LinearAxis yAxis = null;
            AxisTitle objXAxisTitle = null;
            AxisTitle objYAxisTitle = null;
            NumericAxisLabels XAxisLabel = null;
            StringAxisLabels x1AxisLab = null;
            NumericAxisLabels YAxisLabel = null;
            Grid xGrid = null;
            Grid yGrid = null;
            ChartAttribute objAttribute = null;


            try
            {
                iCount = arrSimpleDS.Length;
                
                if (m_obj2DGraphControl != null)
                    m_objChartView = m_obj2DGraphControl;


                m_objChartView.Height = m_obj2DGraphControl.buttonheight.Height;
                m_objChartView.Width = m_obj2DGraphControl.buttonheight.Width;
                if (m_sUnits == null)
                {
                    m_sUnits = "X,Y";
                }
                string[] sarrLabels = m_sUnits.Split(new char[] { ',' });
                m_sTimeAxis = sarrLabels[0];
                m_objFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

                m_objCartesianCordinates = new CartesianCoordinates();
                m_objCartesianCordinates.AutoScale(arrSimpleDS, ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_EXACT);

                objCBGND = new Background(m_objCartesianCordinates, ChartObj.GRAPH_BACKGROUND, Color.FromArgb(255, 255, 255));//Color.FromArgb(241, 241, 247));
                m_objChartView.AddChartObject(objCBGND);

                m_objCartesianCordinates.SetGraphBorderDiagonal(0.15, .15, .90, 0.75);

                xAxis = new LinearAxis(m_objCartesianCordinates, ChartObj.X_AXIS);
                xAxis.CalcAutoAxis();
                m_objChartView.AddChartObject(xAxis);


                if (bOverall)
                {
                    int itime = 0;
                    string[] test = new string[sarrTime.Count];
                    for (itime = 0; itime < sarrTime.Count; itime++)
                    {
                        string stemp = (string)sarrTime[itime];
                        string[] ssst = stemp.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        if (ssst.Length > 1)
                        {
                            test[itime] = ssst[0] + " " + ssst[1];
                        }
                        else if (ssst.Length == 1)
                        {
                            test[itime] = ssst[0];
                        }
                    }

                    x1AxisLab = new StringAxisLabels(xAxis);
                    x1AxisLab.SetTextFont(m_objFont);
                    x1AxisLab.SetAxisLabelsStrings(test, itime);

                    
                    x1AxisLab.SetAxisLabelsEnds(itime);
                    

                    x1AxisLab.SetTextRotation(90);
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
                    
                    x1AxisLab.SetOverlapLabelMode(ChartObj.OVERLAP_LABEL_DRAW);// setOverlapLabelMode();//ChartConstants.OVERLAP_LABEL_STAGGER);

                    m_objChartView.AddChartObject(x1AxisLab);

                }
                else
                {
                    if (xAxis.AxisTickSpace < 50.0 && (m_sTimeAxis == "Others" || m_sTimeAxis == "Hz"))
                    {
                        xAxis.AxisTickSpace = 50.0;
                    }
                    
                    XAxisLabel = new NumericAxisLabels(xAxis);
                    XAxisLabel.SetTextFont(m_objFont);
                    m_objChartView.AddChartObject(XAxisLabel);

                }



                switch (m_sTimeAxis)
                {
                    case "Sec":
                        objXAxisTitle = new AxisTitle(xAxis, m_objFont, "Sec");
                        m_objChartView.AddChartObject(objXAxisTitle);

                        break;
                    default:

                        objXAxisTitle = new AxisTitle(xAxis, m_objFont, sarrLabels[0]);
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
               
                xgrid = new Grid(xAxis, yAxis, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                m_objChartView.AddChartObject(xgrid);

                ygrid = new Grid(xAxis, yAxis, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                m_objChartView.AddChartObject(ygrid);

                

                switch (iCount)
                {
                    case 1:

                        objAttribute = new ChartAttribute(Color.DarkRed, 1, DashStyle.Solid);
                        m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                        m_objChartView.AddChartObject(m_objFirstLinePlot);

                        if (m_obj2DGraphControl != null)
                        {
                            m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.DarkRed;
                            m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[0];
                        }

                        break;
                    case 2:
                        objAttribute = new ChartAttribute(Color.DarkRed, 1, DashStyle.Solid);
                        m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                        m_objChartView.AddChartObject(m_objFirstLinePlot);

                        objAttribute = new ChartAttribute(Color.DarkGreen, 1, DashStyle.Solid);
                        m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                        m_objChartView.AddChartObject(m_objSecondLinePlot);

                        if (m_obj2DGraphControl != null)
                        {
                            m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.DarkGreen;
                            m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[1];
                        }


                        break;
                    case 3:

                        objAttribute = new ChartAttribute(Color.DarkRed, 1, DashStyle.Solid);
                        m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                        m_objChartView.AddChartObject(m_objFirstLinePlot);

                        objAttribute = new ChartAttribute(Color.DarkGreen, 1, DashStyle.Solid);
                        m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                        m_objChartView.AddChartObject(m_objSecondLinePlot);

                        objAttribute = new ChartAttribute(Color.DarkGoldenrod, 1, DashStyle.Solid);
                        m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                        m_objChartView.AddChartObject(m_objThirdLinePlot);

                        if (m_obj2DGraphControl != null)
                        {
                            m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.DarkGoldenrod;
                            m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[2];
                        }

                        break;
                    case 4:

                        objAttribute = new ChartAttribute(Color.DarkRed, 1, DashStyle.Solid);
                        m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                        m_objChartView.AddChartObject(m_objFirstLinePlot);

                        objAttribute = new ChartAttribute(Color.DarkGreen, 1, DashStyle.Solid);
                        m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                        m_objChartView.AddChartObject(m_objSecondLinePlot);

                        objAttribute = new ChartAttribute(Color.DarkGoldenrod, 1, DashStyle.Solid);
                        m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                        m_objChartView.AddChartObject(m_objThirdLinePlot);

                        objAttribute = new ChartAttribute(Color.DarkViolet, 1, DashStyle.Solid);
                        m_objFourthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[3], objAttribute);
                        m_objChartView.AddChartObject(m_objFourthLinePlot);

                        if (m_obj2DGraphControl != null)
                        {
                            m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.DarkGoldenrod;
                            m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[3];
                        }

                        break;
                    case 5:
                        CaseMultiOne(arrSimpleDS);
                        break;
                    case 6:
                        CaseMultiTwo(arrSimpleDS);
                        break;
                    case 7:
                        CaseMultiThree(arrSimpleDS);
                        break;
                    case 8:
                        CaseMultiFour(arrSimpleDS);
                        break;
                    case 9:
                        CaseMultiFive(arrSimpleDS);
                        break;
                    case 10:
                        CaseMultiSix(arrSimpleDS);
                        break;

                }

                if (m_objChartView != null)
                    m_objChartView.UpdateDraw();

                m_obj2DGraphControl.testingGraph3 = m_objChartView;
              
            }
            catch(Exception ex)
            {
                
            }
        }

        internal void CommonFunctionality(SimpleDataset[] arrSimpleDS,ArrayList ColorTag)
        {
            int iCount = 0;
            objCBGND = null;
            ChartAttribute objWallAttribute = null;
            Grid xgrid = null;
            Grid ygrid = null;
            
            LinearAxis xAxis = null;
            LinearAxis yAxis = null;
            AxisTitle objXAxisTitle = null;
            AxisTitle objYAxisTitle = null;
            NumericAxisLabels XAxisLabel = null;
            StringAxisLabels x1AxisLab = null;
            NumericAxisLabels YAxisLabel = null;
            Grid xGrid = null;
            Grid yGrid = null;
            ChartAttribute objAttribute = null;


            try
            {
                iCount = arrSimpleDS.Length;
                
                if (m_obj2DGraphControl != null)
                    m_objChartView = m_obj2DGraphControl;

                string[] sarrLabels = m_sUnits.Split(new char[] { ',' });

                m_objFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

                m_objCartesianCordinates = new CartesianCoordinates();
                m_objCartesianCordinates.AutoScale(arrSimpleDS, ChartObj.AUTOAXES_EXACT, ChartObj.AUTOAXES_EXACT);

                objCBGND = new Background(m_objCartesianCordinates, ChartObj.GRAPH_BACKGROUND, Color.FromArgb(241, 241, 247));
                m_objChartView.AddChartObject(objCBGND);

                m_objCartesianCordinates.SetGraphBorderDiagonal(0.15, .15, .90, 0.75);

                xAxis = new LinearAxis(m_objCartesianCordinates, ChartObj.X_AXIS);
                xAxis.CalcAutoAxis();
                m_objChartView.AddChartObject(xAxis);


                if (bOverall)
                {
                    int itime = 0;
                    string[] test = new string[sarrTime.Count];
                    for (itime = 0; itime < sarrTime.Count; itime++)
                    {
                        string stemp = (string)sarrTime[itime];
                        string[] ssst = stemp.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        test[itime] = ssst[0] + " " + ssst[1];
                    }

                    x1AxisLab = new StringAxisLabels(xAxis);
                    x1AxisLab.SetTextFont(m_objFont);
                    x1AxisLab.SetAxisLabelsStrings(test, itime);

                    
                    x1AxisLab.SetAxisLabelsEnds(itime);
                    

                    x1AxisLab.SetTextRotation(90);
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
                    
                    x1AxisLab.SetOverlapLabelMode(ChartObj.OVERLAP_LABEL_DRAW);// setOverlapLabelMode();//ChartConstants.OVERLAP_LABEL_STAGGER);

                    m_objChartView.AddChartObject(x1AxisLab);

                }
                else
                {
                    if (xAxis.AxisTickSpace < 50.0 && (m_sTimeAxis == "Others" || m_sTimeAxis == "Hz"))
                    {
                        xAxis.AxisTickSpace = 50.0;
                    }

                    XAxisLabel = new NumericAxisLabels(xAxis);
                    XAxisLabel.SetTextFont(m_objFont);
                    m_objChartView.AddChartObject(XAxisLabel);
                }



                switch (m_sTimeAxis)
                {
                    case "Sec":
                        objXAxisTitle = new AxisTitle(xAxis, m_objFont, "Sec");
                        m_objChartView.AddChartObject(objXAxisTitle);

                        break;
                   
                    default:
                        objXAxisTitle = new AxisTitle(xAxis, m_objFont, sarrLabels[0]);
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

                xgrid = new Grid(xAxis, yAxis, ChartObj.X_AXIS, ChartObj.GRID_MAJOR);
                m_objChartView.AddChartObject(xgrid);

                ygrid = new Grid(xAxis, yAxis, ChartObj.Y_AXIS, ChartObj.GRID_MAJOR);
                m_objChartView.AddChartObject(ygrid);

                switch (iCount)
                {
                    case 1:

                        objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[0])), 1, DashStyle.Solid);
                        m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                        m_objChartView.AddChartObject(m_objFirstLinePlot);

                        if (m_obj2DGraphControl != null)
                        {
                            m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.FromArgb(-Convert.ToInt32(ColorTag[0]));
                            m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[0];
                        }

                        break;
                    case 2:
                        objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[0])), 1, DashStyle.Solid);
                        m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                        m_objChartView.AddChartObject(m_objFirstLinePlot);

                        objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[1])), 1, DashStyle.Solid);
                        m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                        m_objChartView.AddChartObject(m_objSecondLinePlot);

                        if (m_obj2DGraphControl != null)
                        {
                            m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.FromArgb(-Convert.ToInt32(ColorTag[1]));
                            m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[1];
                        }


                        break;
                    case 3:

                        objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[0])), 1, DashStyle.Solid);
                        m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                        m_objChartView.AddChartObject(m_objFirstLinePlot);

                        objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[1])), 1, DashStyle.Solid);
                        m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                        m_objChartView.AddChartObject(m_objSecondLinePlot);

                        objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[2])), 1, DashStyle.Solid);
                        m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                        m_objChartView.AddChartObject(m_objThirdLinePlot);

                        if (m_obj2DGraphControl != null)
                        {
                            m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.FromArgb(-Convert.ToInt32(ColorTag[2]));
                            m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[2];
                        }

                        break;
                    case 4:

                        objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[0])), 1, DashStyle.Solid);
                        m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                        m_objChartView.AddChartObject(m_objFirstLinePlot);

                        objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[1])), 1, DashStyle.Solid);
                        m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                        m_objChartView.AddChartObject(m_objSecondLinePlot);

                        objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[2])), 1, DashStyle.Solid);
                        m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                        m_objChartView.AddChartObject(m_objThirdLinePlot);

                        objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[3])), 1, DashStyle.Solid);
                        m_objFourthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[3], objAttribute);
                        m_objChartView.AddChartObject(m_objFourthLinePlot);

                        if (m_obj2DGraphControl != null)
                        {
                            m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.FromArgb(-Convert.ToInt32(ColorTag[3]));
                            m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[3];
                        }

                        break;
                    case 5:
                        CaseMultiOne(arrSimpleDS, ColorTag);
                        break;
                    case 6:
                        CaseMultiTwo(arrSimpleDS, ColorTag);
                        break;
                    case 7:
                        CaseMultiThree(arrSimpleDS, ColorTag);
                        break;
                    case 8:
                        CaseMultiFour(arrSimpleDS, ColorTag);
                        break;
                    case 9:
                        CaseMultiFive(arrSimpleDS, ColorTag);
                        break;
                    case 10:
                        CaseMultiSix(arrSimpleDS, ColorTag);
                        break;
                }

                if (m_objChartView != null)
                    m_objChartView.UpdateDraw();
            }
            catch
            {
                throw;
            }
        }

        SimpleLinePlot m_objFifthLinePlot = null;
        SimpleLinePlot m_objSixthLinePlot = null;
        SimpleLinePlot m_objSeventhLinePlot = null;
        SimpleLinePlot m_objEighthLinePlot = null;
        SimpleLinePlot m_objNinthLinePlot = null;
        SimpleLinePlot m_objTenthLinePlot = null;

        private void CaseMultiOne(SimpleDataset[] arrSimpleDS)
        {
            ChartAttribute objAttribute = null;
            try
            {
                objAttribute = new ChartAttribute(Color.DarkRed, 1, DashStyle.Solid);
                m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                m_objChartView.AddChartObject(m_objFirstLinePlot);

                objAttribute = new ChartAttribute(Color.DarkGreen, 1, DashStyle.Solid);
                m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                m_objChartView.AddChartObject(m_objSecondLinePlot);

                objAttribute = new ChartAttribute(Color.DarkGoldenrod, 1, DashStyle.Solid);
                m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                m_objChartView.AddChartObject(m_objThirdLinePlot);

                objAttribute = new ChartAttribute(Color.DarkViolet, 1, DashStyle.Solid);
                m_objFourthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[3], objAttribute);
                m_objChartView.AddChartObject(m_objFourthLinePlot);


                objAttribute = new ChartAttribute(Color.DarkBlue, 1, DashStyle.Solid);
                m_objFifthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[4], objAttribute);
                m_objChartView.AddChartObject(m_objFifthLinePlot);
                
                if (m_obj2DGraphControl != null)
                {
                    m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.DarkBlue;
                    m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[4];
                }



            }
            catch (Exception ex)
            {

            }
        }

        private void CaseMultiTwo(SimpleDataset[] arrSimpleDS)
        {
            ChartAttribute objAttribute = null;
            try
            {
                objAttribute = new ChartAttribute(Color.DarkRed, 1, DashStyle.Solid);
                m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                m_objChartView.AddChartObject(m_objFirstLinePlot);

                objAttribute = new ChartAttribute(Color.DarkGreen, 1, DashStyle.Solid);
                m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                m_objChartView.AddChartObject(m_objSecondLinePlot);

                objAttribute = new ChartAttribute(Color.DarkGoldenrod, 1, DashStyle.Solid);
                m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                m_objChartView.AddChartObject(m_objThirdLinePlot);

                objAttribute = new ChartAttribute(Color.DarkViolet, 1, DashStyle.Solid);
                m_objFourthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[3], objAttribute);
                m_objChartView.AddChartObject(m_objFourthLinePlot);


                objAttribute = new ChartAttribute(Color.DarkBlue, 1, DashStyle.Solid);
                m_objFifthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[4], objAttribute);
                m_objChartView.AddChartObject(m_objFifthLinePlot);

                objAttribute = new ChartAttribute(Color.DimGray, 1, DashStyle.Solid);
                m_objSixthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[5], objAttribute);
                m_objChartView.AddChartObject(m_objSixthLinePlot);
                
                if (m_obj2DGraphControl != null)
                {
                    m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.DimGray;
                    m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[5];
                }



            }
            catch (Exception ex)
            {

            }
        }

        private void CaseMultiThree(SimpleDataset[] arrSimpleDS)
        {
            ChartAttribute objAttribute = null;
            try
            {
                objAttribute = new ChartAttribute(Color.DarkRed, 1, DashStyle.Solid);
                m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                m_objChartView.AddChartObject(m_objFirstLinePlot);

                objAttribute = new ChartAttribute(Color.DarkGreen, 1, DashStyle.Solid);
                m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                m_objChartView.AddChartObject(m_objSecondLinePlot);

                objAttribute = new ChartAttribute(Color.DarkGoldenrod, 1, DashStyle.Solid);
                m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                m_objChartView.AddChartObject(m_objThirdLinePlot);

                objAttribute = new ChartAttribute(Color.DarkViolet, 1, DashStyle.Solid);
                m_objFourthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[3], objAttribute);
                m_objChartView.AddChartObject(m_objFourthLinePlot);


                objAttribute = new ChartAttribute(Color.DarkBlue, 1, DashStyle.Solid);
                m_objFifthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[4], objAttribute);
                m_objChartView.AddChartObject(m_objFifthLinePlot);

                objAttribute = new ChartAttribute(Color.DimGray, 1, DashStyle.Solid);
                m_objSixthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[5], objAttribute);
                m_objChartView.AddChartObject(m_objSixthLinePlot);

                objAttribute = new ChartAttribute(Color.Chocolate, 1, DashStyle.Solid);
                m_objSeventhLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[6], objAttribute);
                m_objChartView.AddChartObject(m_objSeventhLinePlot);

                if (m_obj2DGraphControl != null)
                {
                    m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.Chocolate;
                    m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[6];
                }



            }
            catch (Exception ex)
            {

            }
        }

        private void CaseMultiFour(SimpleDataset[] arrSimpleDS)
        {
            ChartAttribute objAttribute = null;
            try
            {
                objAttribute = new ChartAttribute(Color.DarkRed, 1, DashStyle.Solid);
                m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                m_objChartView.AddChartObject(m_objFirstLinePlot);

                objAttribute = new ChartAttribute(Color.DarkGreen, 1, DashStyle.Solid);
                m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                m_objChartView.AddChartObject(m_objSecondLinePlot);

                objAttribute = new ChartAttribute(Color.DarkGoldenrod, 1, DashStyle.Solid);
                m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                m_objChartView.AddChartObject(m_objThirdLinePlot);

                objAttribute = new ChartAttribute(Color.DarkViolet, 1, DashStyle.Solid);
                m_objFourthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[3], objAttribute);
                m_objChartView.AddChartObject(m_objFourthLinePlot);


                objAttribute = new ChartAttribute(Color.DarkBlue, 1, DashStyle.Solid);
                m_objFifthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[4], objAttribute);
                m_objChartView.AddChartObject(m_objFifthLinePlot);

                objAttribute = new ChartAttribute(Color.DimGray, 1, DashStyle.Solid);
                m_objSixthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[5], objAttribute);
                m_objChartView.AddChartObject(m_objSixthLinePlot);

                objAttribute = new ChartAttribute(Color.Chocolate, 1, DashStyle.Solid);
                m_objSeventhLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[6], objAttribute);
                m_objChartView.AddChartObject(m_objSeventhLinePlot);

                objAttribute = new ChartAttribute(Color.DarkKhaki, 1, DashStyle.Solid);
                m_objEighthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[7], objAttribute);
                m_objChartView.AddChartObject(m_objEighthLinePlot);

                if (m_obj2DGraphControl != null)
                {
                    m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.DarkKhaki;
                    m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[7];
                }



            }
            catch (Exception ex)
            {

            }
        }

        private void CaseMultiFive(SimpleDataset[] arrSimpleDS)
        {
            ChartAttribute objAttribute = null;
            try
            {
                objAttribute = new ChartAttribute(Color.DarkRed, 1, DashStyle.Solid);
                m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                m_objChartView.AddChartObject(m_objFirstLinePlot);

                objAttribute = new ChartAttribute(Color.DarkGreen, 1, DashStyle.Solid);
                m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                m_objChartView.AddChartObject(m_objSecondLinePlot);

                objAttribute = new ChartAttribute(Color.DarkGoldenrod, 1, DashStyle.Solid);
                m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                m_objChartView.AddChartObject(m_objThirdLinePlot);

                objAttribute = new ChartAttribute(Color.DarkViolet, 1, DashStyle.Solid);
                m_objFourthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[3], objAttribute);
                m_objChartView.AddChartObject(m_objFourthLinePlot);


                objAttribute = new ChartAttribute(Color.DarkBlue, 1, DashStyle.Solid);
                m_objFifthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[4], objAttribute);
                m_objChartView.AddChartObject(m_objFifthLinePlot);

                objAttribute = new ChartAttribute(Color.DimGray, 1, DashStyle.Solid);
                m_objSixthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[5], objAttribute);
                m_objChartView.AddChartObject(m_objSixthLinePlot);

                objAttribute = new ChartAttribute(Color.Chocolate, 1, DashStyle.Solid);
                m_objSeventhLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[6], objAttribute);
                m_objChartView.AddChartObject(m_objSeventhLinePlot);

                objAttribute = new ChartAttribute(Color.DarkKhaki, 1, DashStyle.Solid);
                m_objEighthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[7], objAttribute);
                m_objChartView.AddChartObject(m_objEighthLinePlot);

                objAttribute = new ChartAttribute(Color.Black, 1, DashStyle.Solid);
                m_objNinthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[8], objAttribute);
                m_objChartView.AddChartObject(m_objNinthLinePlot);

                if (m_obj2DGraphControl != null)
                {
                    m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.Black;
                    m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[8];
                }



            }
            catch (Exception ex)
            {

            }
        }

        private void CaseMultiSix(SimpleDataset[] arrSimpleDS)
        {
            ChartAttribute objAttribute = null;

            try
            {
                objAttribute = new ChartAttribute(Color.DarkRed, 1, DashStyle.Solid);
                m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                m_objChartView.AddChartObject(m_objFirstLinePlot);

                objAttribute = new ChartAttribute(Color.DarkGreen, 1, DashStyle.Solid);
                m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                m_objChartView.AddChartObject(m_objSecondLinePlot);

                objAttribute = new ChartAttribute(Color.DarkGoldenrod, 1, DashStyle.Solid);
                m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                m_objChartView.AddChartObject(m_objThirdLinePlot);

                objAttribute = new ChartAttribute(Color.DarkViolet, 1, DashStyle.Solid);
                m_objFourthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[3], objAttribute);
                m_objChartView.AddChartObject(m_objFourthLinePlot);


                objAttribute = new ChartAttribute(Color.DarkBlue, 1, DashStyle.Solid);
                m_objFifthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[4], objAttribute);
                m_objChartView.AddChartObject(m_objFifthLinePlot);

                objAttribute = new ChartAttribute(Color.DimGray, 1, DashStyle.Solid);
                m_objSixthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[5], objAttribute);
                m_objChartView.AddChartObject(m_objSixthLinePlot);

                objAttribute = new ChartAttribute(Color.Chocolate, 1, DashStyle.Solid);
                m_objSeventhLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[6], objAttribute);
                m_objChartView.AddChartObject(m_objSeventhLinePlot);

                objAttribute = new ChartAttribute(Color.DarkKhaki, 1, DashStyle.Solid);
                m_objEighthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[7], objAttribute);
                m_objChartView.AddChartObject(m_objEighthLinePlot);

                objAttribute = new ChartAttribute(Color.Black, 1, DashStyle.Solid);
                m_objNinthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[8], objAttribute);
                m_objChartView.AddChartObject(m_objNinthLinePlot);

                objAttribute = new ChartAttribute(Color.Orange, 1, DashStyle.Solid);
                m_objTenthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[9], objAttribute);
                m_objChartView.AddChartObject(m_objTenthLinePlot);

                if (m_obj2DGraphControl != null)
                {
                    m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.Orange;
                    m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[9];
                }


            }
            catch (Exception ex)
            {

            }
        }

        private void CaseMultiOne(SimpleDataset[] arrSimpleDS,ArrayList ColorTag)
        {
            ChartAttribute objAttribute = null;
            try
            {
                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[0])), 1, DashStyle.Solid);
                m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                m_objChartView.AddChartObject(m_objFirstLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[1])), 1, DashStyle.Solid);
                m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                m_objChartView.AddChartObject(m_objSecondLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[2])), 1, DashStyle.Solid);
                m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                m_objChartView.AddChartObject(m_objThirdLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[3])), 1, DashStyle.Solid);
                m_objFourthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[3], objAttribute);
                m_objChartView.AddChartObject(m_objFourthLinePlot);


                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[4])), 1, DashStyle.Solid);
                m_objFifthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[4], objAttribute);
                m_objChartView.AddChartObject(m_objFifthLinePlot);
               
                if (m_obj2DGraphControl != null)
                {
                    m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.FromArgb(-Convert.ToInt32(ColorTag[4]));
                    m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[4];
                }



            }
            catch (Exception ex)
            {

            }
        }

        private void CaseMultiTwo(SimpleDataset[] arrSimpleDS, ArrayList ColorTag)
        {
            ChartAttribute objAttribute = null;
            try
            {
                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[0])), 1, DashStyle.Solid);
                m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                m_objChartView.AddChartObject(m_objFirstLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[1])), 1, DashStyle.Solid);
                m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                m_objChartView.AddChartObject(m_objSecondLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[2])), 1, DashStyle.Solid);
                m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                m_objChartView.AddChartObject(m_objThirdLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[3])), 1, DashStyle.Solid);
                m_objFourthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[3], objAttribute);
                m_objChartView.AddChartObject(m_objFourthLinePlot);


                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[4])), 1, DashStyle.Solid);
                m_objFifthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[4], objAttribute);
                m_objChartView.AddChartObject(m_objFifthLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[5])), 1, DashStyle.Solid);
                m_objSixthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[5], objAttribute);
                m_objChartView.AddChartObject(m_objSixthLinePlot);

                if (m_obj2DGraphControl != null)
                {
                    m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.FromArgb(-Convert.ToInt32(ColorTag[5]));
                    m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[5];
                }



            }
            catch (Exception ex)
            {

            }
        }

        private void CaseMultiThree(SimpleDataset[] arrSimpleDS, ArrayList ColorTag)
        {
            ChartAttribute objAttribute = null;
            try
            {
                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[0])), 1, DashStyle.Solid);
                m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                m_objChartView.AddChartObject(m_objFirstLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[1])), 1, DashStyle.Solid);
                m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                m_objChartView.AddChartObject(m_objSecondLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[2])), 1, DashStyle.Solid);
                m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                m_objChartView.AddChartObject(m_objThirdLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[3])), 1, DashStyle.Solid);
                m_objFourthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[3], objAttribute);
                m_objChartView.AddChartObject(m_objFourthLinePlot);


                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[4])), 1, DashStyle.Solid);
                m_objFifthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[4], objAttribute);
                m_objChartView.AddChartObject(m_objFifthLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[5])), 1, DashStyle.Solid);
                m_objSixthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[5], objAttribute);
                m_objChartView.AddChartObject(m_objSixthLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[6])), 1, DashStyle.Solid);
                m_objSeventhLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[6], objAttribute);
                m_objChartView.AddChartObject(m_objSeventhLinePlot);

                if (m_obj2DGraphControl != null)
                {
                    m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.FromArgb(-Convert.ToInt32(ColorTag[6]));
                    m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[6];
                }



            }
            catch (Exception ex)
            {

            }
        }

        private void CaseMultiFour(SimpleDataset[] arrSimpleDS, ArrayList ColorTag)
        {
            ChartAttribute objAttribute = null;
            try
            {
                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[0])), 1, DashStyle.Solid);
                m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                m_objChartView.AddChartObject(m_objFirstLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[1])), 1, DashStyle.Solid);
                m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                m_objChartView.AddChartObject(m_objSecondLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[2])), 1, DashStyle.Solid);
                m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                m_objChartView.AddChartObject(m_objThirdLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[3])), 1, DashStyle.Solid);
                m_objFourthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[3], objAttribute);
                m_objChartView.AddChartObject(m_objFourthLinePlot);


                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[4])), 1, DashStyle.Solid);
                m_objFifthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[4], objAttribute);
                m_objChartView.AddChartObject(m_objFifthLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[5])), 1, DashStyle.Solid);
                m_objSixthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[5], objAttribute);
                m_objChartView.AddChartObject(m_objSixthLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[6])), 1, DashStyle.Solid);
                m_objSeventhLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[6], objAttribute);
                m_objChartView.AddChartObject(m_objSeventhLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[7])), 1, DashStyle.Solid);
                m_objEighthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[7], objAttribute);
                m_objChartView.AddChartObject(m_objEighthLinePlot);

                if (m_obj2DGraphControl != null)
                {
                    m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.FromArgb(-Convert.ToInt32(ColorTag[7]));
                    m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[7];
                }



            }
            catch (Exception ex)
            {

            }
        }

        private void CaseMultiFive(SimpleDataset[] arrSimpleDS, ArrayList ColorTag)
        {
            ChartAttribute objAttribute = null;
            try
            {
                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[0])), 1, DashStyle.Solid);
                m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                m_objChartView.AddChartObject(m_objFirstLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[1])), 1, DashStyle.Solid);
                m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                m_objChartView.AddChartObject(m_objSecondLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[2])), 1, DashStyle.Solid);
                m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                m_objChartView.AddChartObject(m_objThirdLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[3])), 1, DashStyle.Solid);
                m_objFourthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[3], objAttribute);
                m_objChartView.AddChartObject(m_objFourthLinePlot);


                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[4])), 1, DashStyle.Solid);
                m_objFifthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[4], objAttribute);
                m_objChartView.AddChartObject(m_objFifthLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[5])), 1, DashStyle.Solid);
                m_objSixthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[5], objAttribute);
                m_objChartView.AddChartObject(m_objSixthLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[6])), 1, DashStyle.Solid);
                m_objSeventhLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[6], objAttribute);
                m_objChartView.AddChartObject(m_objSeventhLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[7])), 1, DashStyle.Solid);
                m_objEighthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[7], objAttribute);
                m_objChartView.AddChartObject(m_objEighthLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[8])), 1, DashStyle.Solid);
                m_objNinthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[8], objAttribute);
                m_objChartView.AddChartObject(m_objNinthLinePlot);

                if (m_obj2DGraphControl != null)
                {
                    m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.FromArgb(-Convert.ToInt32(ColorTag[8]));
                    m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[8];
                }



            }
            catch (Exception ex)
            {

            }
        }

        private void CaseMultiSix(SimpleDataset[] arrSimpleDS, ArrayList ColorTag)
        {
            ChartAttribute objAttribute = null;

            try
            {
                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[0])), 1, DashStyle.Solid);
                m_objFirstLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[0], objAttribute);
                m_objChartView.AddChartObject(m_objFirstLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[1])), 1, DashStyle.Solid);
                m_objSecondLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[1], objAttribute);
                m_objChartView.AddChartObject(m_objSecondLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[2])), 1, DashStyle.Solid);
                m_objThirdLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[2], objAttribute);
                m_objChartView.AddChartObject(m_objThirdLinePlot);


                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[3])), 1, DashStyle.Solid);
                m_objFourthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[3], objAttribute);
                m_objChartView.AddChartObject(m_objFourthLinePlot);


                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[4])), 1, DashStyle.Solid);
                m_objFifthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[4], objAttribute);
                m_objChartView.AddChartObject(m_objFifthLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[5])), 1, DashStyle.Solid);
                m_objSixthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[5], objAttribute);
                m_objChartView.AddChartObject(m_objSixthLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[6])), 1, DashStyle.Solid);
                m_objSeventhLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[6], objAttribute);
                m_objChartView.AddChartObject(m_objSeventhLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[7])), 1, DashStyle.Solid);
                m_objEighthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[7], objAttribute);
                m_objChartView.AddChartObject(m_objEighthLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[8])), 1, DashStyle.Solid);
                m_objNinthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[8], objAttribute);
                m_objChartView.AddChartObject(m_objNinthLinePlot);

                objAttribute = new ChartAttribute(Color.FromArgb(-Convert.ToInt32(ColorTag[9])), 1, DashStyle.Solid);
                m_objTenthLinePlot = new SimpleLinePlot(m_objCartesianCordinates, arrSimpleDS[9], objAttribute);
                m_objChartView.AddChartObject(m_objTenthLinePlot);

                if (m_obj2DGraphControl != null)
                {
                    m_obj2DGraphControl.ParentForm.SetForeColorDateTime = Color.FromArgb(-Convert.ToInt32(ColorTag[9]));
                    m_obj2DGraphControl.ParentForm.SetDateTime = (string)m_arlstDates[9];
                }


            }
            catch (Exception ex)
            {

            }
        }

        Dictionary<Point2D, Point2D> m_objPointsInData = null;
        Marker m_objPreviousPointMarker = null;

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

                ArrayList arrObjects = m_objChartView.GetChartObjectsArrayList();

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
                
                if (sType == "Right")
                {



                    if (objClickedLine.LineWidth == 2)
                    {

                        if (m_objDataCursor != null)
                            m_objChartView.DeleteChartObject(m_objDataCursor);

                        objDataSet = objClickedLine.DisplayDataset;
                        Point2D objPoint = objDataSet.GetDataPoint(m_iCounter);
                        ptPreviousPoint = objDataSet.GetDataPoint(m_iCounter - 1);
                        nearestPointObj1 = new NearestPointData();
                        textCoordsFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);

                        m_objPointsInData.Add(objPoint, objPoint);
                       


                        ptNewPoint = nearestPointObj1.GetNearestPoint();


                        if (m_objMarker != null)
                        {
                            m_objChartView.DeleteChartObject(m_objMarker);
                            m_objChartView.DeleteChartObject(m_objNewMarker);
                            m_objChartView.DeleteChartObject(m_objPreviousPointMarker);
                            if (m_objDataCursor != null)
                                m_objChartView.DeleteChartObject(m_objDataCursor);

                        }

                        m_objMarker = new Marker(m_objCartesianCordinates, GraphObj.MARKER_VLINE, objPoint.X, objPoint.Y, 5, 1);
                        m_objNewMarker = new Marker(m_objCartesianCordinates, GraphObj.MARKER_BOX, objPoint.X, objPoint.Y, 8, 1);
                        
                        m_objMarker.SetColor(Color.Black);
                        m_objNewMarker.SetColor(Color.Black);
                        

                        m_objChartView.AddChartObject(m_objMarker);
                        m_objChartView.AddChartObject(m_objNewMarker);
                        

                        if (m_objMarker != null)
                        {
                            if (bOverall)
                            {
                                m_obj2DGraphControl.SetLabelText("X Value:" + sarrTime[Convert.ToInt32(objPoint.X) - 1] + "\n" + "Y Value:" + objPoint.Y);
                             
                            }
                            else
                            {
                                m_obj2DGraphControl.SetLabelText("X Value:" + objPoint.X + "\n" + "Y Value:" + objPoint.Y);
                            }
                            m_objChartView.UpdateDraw();

                        }
                        m_iCounter++;

                        int iNumber = objDataSet.GetNumberDatapoints();
                        if (m_iCounter > iNumber)
                            m_iCounter = iNumber;
                    }



                }
                else if (sType == "Left")
                {

                    objPreviousPointDataSet = objClickedLine.DisplayDataset;

                    if (m_objDataCursor != null)
                        m_objChartView.DeleteChartObject(m_objDataCursor);
                    Point2D objPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter);
                    ptPreviousPoint = objPreviousPointDataSet.GetDataPoint(m_iCounter + 1);
                    nearestPointObj1 = new NearestPointData();
                    textCoordsFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);



                    ptNewPoint = nearestPointObj1.GetNearestPoint();

                    
                    if (m_objMarker != null)
                    {
                        m_objChartView.DeleteChartObject(m_objMarker);
                        m_objChartView.DeleteChartObject(m_objNewMarker);
                    }

                    m_objMarker = new Marker(m_objCartesianCordinates, GraphObj.MARKER_VLINE, objPoint.X, objPoint.Y, 5, 1);
                    m_objNewMarker = new Marker(m_objCartesianCordinates, GraphObj.MARKER_BOX, objPoint.X, objPoint.Y, 8, 1);
                    
                    m_objMarker.SetColor(Color.Black);
                    m_objNewMarker.SetColor(Color.Black);

                   m_objChartView.AddChartObject(m_objMarker);
                    m_objChartView.AddChartObject(m_objNewMarker);
                    

                    if (m_objMarker != null)
                    {
                        if (bOverall)
                        {
                            m_obj2DGraphControl.SetLabelText("X Value:" + sarrTime[Convert.ToInt32(objPoint.X) - 1] + "\n" + "Y Value:" + objPoint.Y);
                         
                        }
                        else
                        {
                           m_obj2DGraphControl.SetLabelText("X Value:" + objPoint.X + "\n" + "Y Value:" + objPoint.Y);
                        }
                        m_objChartView.UpdateDraw();

                    }
                    m_iCounter--;
                    if (m_iCounter < 0)
                        m_iCounter = 0;


                }


            }
            catch (Exception ex)
            {
                
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
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
