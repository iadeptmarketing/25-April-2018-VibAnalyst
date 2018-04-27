using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using Iadeptmain.BaseUserControl;
using System.Drawing.Drawing2D;
using OpenNETCF;
using Iadeptmain.GlobalClasses;
using System.Data.Odbc;
using Iadeptmain.Classes;

namespace Iadeptmain.Mainforms
{
    public partial class frmGControls : DevExpress.XtraEditors.XtraForm
    {
       LineGraphControl _LineGraph = null;
       public frmIAdeptMain MainForm = null;
       public IadeptUserControl usercontrol = null;
        int OneFifty = 0;
        int TwoHundred = 0;
        int FourFifty = 0;
        int FourHundred = 0;
        int SixtyTwo = 0;
        int OneSixtyTwo = 0;
        int Thrghty = 0;
        int Fifteen = 0;
        int TwoPointFive = 0;
        int Fifty = 0;
        double MainYAxisInterval = 0;
        double MainXAxisInterval = 0.0;
        double[] OrbitXAxis = null;
        double[] OrbitYAxis = null;
        double[] XData = null;
        double[] YData = null;
        int Three = 0;
        public frmGControls()
        {
            InitializeComponent();
        }
        public void CallClearDataGridMain()
        {
            try
            {
                dataGridView2.Rows.Clear();
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    dataGridView2.Rows.RemoveAt(0);
                }

            }
            catch (Exception ex)
            {
            }
        }

        public IadeptUserControl uscontrol
        {
            get
            {
                return usercontrol;
            }
            set
            {
                usercontrol = value;
            }
        }

       public void ClearDatagrid()
        {
            try
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
               
            }
        }
       private void SetAxis()
       {
           try
           {
               Region rgn1 = new Region(panel1.Bounds);

               System.Drawing.Graphics der = panel1.CreateGraphics();

               der.Clip = rgn1;

               RectangleF pt = der.ClipBounds;

               OneFifty = (int)Math.Round((18.5643 * pt.Bottom) / 100, 0);
               TwoHundred = (int)Math.Round((24.7524 * pt.Bottom) / 100, 0);
               FourFifty = (int)Math.Round((55.6930 * pt.Bottom) / 100, 0);
               FourHundred = (int)Math.Round((49.5049 * pt.Bottom) / 100, 0);
               
               SixtyTwo = 62;
               OneSixtyTwo = (int)Math.Round((17.7631 * pt.Right) / 100, 0);
               Thrghty = (int)Math.Round((3.7128 * pt.Bottom) / 100, 0);
               Fifteen = (int)Math.Round((2.0833 * pt.Right) / 100, 0); 
               TwoPointFive = (int)Math.Round((.7127 * pt.Right) / 100, 0); 
               Fifty = (int)Math.Round((6.1881 * pt.Bottom) / 100, 0);
               Three = (int)Math.Round((.75 * pt.Right) / 100, 0);
           }
           catch (Exception ex)
           {
             
           }
       }

       double[] x = new double[0];
       double[] y = new double[0];
       private void DrawGrids()
       {
           Region Rgn = new Region(panel1.Bounds);
           Graphics ThreDee = panel1.CreateGraphics();
           
           ThreDee.Clip = Rgn;

           Pen BlkPen = new Pen(Color.Black, 1);
           BlkPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
           Pen BlkPenTwo = new Pen(Color.Black, 2);
           BlkPenTwo.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
           RectangleF Rect = ThreDee.ClipBounds;
           PointF pt1 = new PointF();
           PointF pt2 = new PointF();
           float ScreenLenth = Rect.Right;
           float ScreenHeight = Rect.Bottom;
           double TotalXAxis = (Convert.ToDouble(Rect.Right - Rect.Left)) - ((Rect.Left + SixtyTwo) + OneSixtyTwo);
           double TotalYAxis = (Convert.ToDouble(Rect.Bottom - Rect.Top)) - (TwoHundred + FourHundred);
           double MaxVal = 0;
           
           PointF Ptsn1 = new PointF();
           
           Font objFont = new Font("Roman", 7, FontStyle.Italic);
           Brush objBrush = Brushes.Black;
           int TestIntvrl = (x.Length - 1) / 4;
           try
           {
               for (int i = 0; i <= 2; i++)
               {
                   pt1 = new PointF((float)(Rect.Left + OneSixtyTwo), (float)(Rect.Top + TwoHundred + (i * 51)));
                   pt2 = new PointF((float)(Rect.Right - SixtyTwo), (float)(Rect.Top + TwoHundred + (i * 51)));
                   ThreDee.DrawLine(BlkPen, pt1, pt2);

                   pt1 = new PointF((float)(Rect.Left + SixtyTwo), (float)(Rect.Top + FourFifty + (i * 51)));
                   pt2 = new PointF((float)(Rect.Left + OneSixtyTwo), (float)(Rect.Top + TwoHundred + (i * 51)));
                   ThreDee.DrawLine(BlkPenTwo, pt1, pt2);
               }

               for (int i = 1; i <= 3; i++)
               {
                   pt1 = new PointF((float)(Rect.Right - SixtyTwo - (172 * i)), (float)(Rect.Bottom - FourFifty));
                   pt2 = new PointF((float)(Rect.Right - SixtyTwo - (172 * i)), (float)(Rect.Top + OneFifty));
                   ThreDee.DrawLine(BlkPen, pt1, pt2);
                   pt1 = new PointF((float)(Rect.Right - SixtyTwo - (172 * i)), (float)(Rect.Bottom - FourFifty));
                   pt2 = new PointF((float)(Rect.Right - (OneSixtyTwo) - (172 * i)), (float)(Rect.Bottom - TwoHundred));
                   ThreDee.DrawLine(BlkPenTwo, pt1, pt2);
                   ThreDee.DrawString(Convert.ToString(x[TestIntvrl * (4 - i)]), objFont, objBrush, pt2);

               }

           }
           catch (Exception ex)
           {
           }
       }
       public void DrawMultipleCursors(int Cursorcount)
       {
           try
           {
               dataGridView1.Rows.Clear();
               for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
               {
                   dataGridView1.Rows.RemoveAt(0);
               }
               dataGridView1.Rows.Add(Cursorcount);
               for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
               {
                   dataGridView1[0, i].Value = "Cursor " + (i + 1).ToString();
                   int colorIndex = i % 10;
                   switch (colorIndex)
                   {
                       case 0:
                           {
                               dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Black;
                               break;
                           }
                       case 1:
                           {
                               dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Blue;
                               break;
                           }
                       case 2:
                           {
                               dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Red;
                               break;
                           }
                       case 3:
                           {
                               dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Green;
                               break;
                           }
                       case 4:
                           {
                               dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Brown;
                               break;
                           }
                       case 5:
                           {
                               dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.DarkCyan;
                               break;
                           }
                       case 6:
                           {
                               dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.DarkOrange;
                               break;
                           }
                       case 7:
                           {
                               dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.DeepPink;
                               break;
                           }
                       case 8:
                           {
                               dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.DarkViolet;
                               break;
                           }
                       case 9:
                           {
                               dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.DarkGray;
                               break;
                           }
                   }
               }
              
           }
           catch (Exception ex)
           {
           }
       }

       int CtrSelectedCraph = -1;
       int CtrSelectedCraphPrvs = 0;
       private PointF[] Pts = null;
       private PointF[] Pts1 = null;
       private PointF[] Pts2 = null;
       private PointF[] Pts3 = null;
       private PointF[] Pts4 = null;
       private PointF[] Pts5 = null;
       private PointF[] Pts6 = null;
       private PointF[] Pts7 = null;
       private PointF[] PtsSelected = null;
       public void ThreeDeeRedraw()
       {
           SetAxis();
           Region Rgn = new Region(panel1.Bounds);
           Graphics ThreDee = panel1.CreateGraphics();
           ThreDee.Clip = Rgn;
           Pen BlkPen = new Pen(Color.Black, 1);
           RectangleF Rect = ThreDee.ClipBounds;
           PointF pt1 = new PointF();
           PointF pt2 = new PointF();
           float ScreenLenth = Rect.Right;
           float ScreenHeight = Rect.Bottom;
           double TotalXAxis = (Convert.ToDouble(Rect.Right - Rect.Left)) - (OneSixtyTwo + (Rect.Left + SixtyTwo));
           double TotalYAxis = (Convert.ToDouble(Rect.Bottom - Rect.Top)) - (FourHundred + TwoHundred);
           double MaxVal = 0;

           PointF Ptsn1 = new PointF();
           try
           {
               pt1 = new PointF((float)(Rect.Left + SixtyTwo), (float)(Rect.Bottom - TwoHundred));
               pt2 = new PointF((float)(Rect.Left + SixtyTwo), (float)(Rect.Top + FourHundred));
               ThreDee.DrawLine(BlkPen, pt1, pt2);
               pt1 = new PointF((float)(Rect.Left + OneSixtyTwo), (float)(Rect.Bottom - FourFifty));
               pt2 = new PointF((float)(Rect.Left + OneSixtyTwo), (float)(Rect.Top + OneFifty));
               ThreDee.DrawLine(BlkPen, pt1, pt2);
               pt1 = new PointF((float)(Rect.Left + SixtyTwo), (float)(Rect.Bottom - TwoHundred));
               pt2 = new PointF((float)(Rect.Left + OneSixtyTwo), (float)(Rect.Bottom - FourFifty));
               ThreDee.DrawLine(BlkPen, pt1, pt2);
               pt1 = new PointF((float)(Rect.Left + SixtyTwo), (float)(Rect.Top + FourHundred));
               pt2 = new PointF((float)(Rect.Left + OneSixtyTwo), (float)(Rect.Top + OneFifty));
               ThreDee.DrawLine(BlkPen, pt1, pt2);
               pt1 = new PointF((float)(Rect.Left + OneSixtyTwo), (float)(Rect.Bottom - FourFifty));
               pt2 = new PointF((float)(Rect.Right - SixtyTwo), (float)(Rect.Bottom - FourFifty));
               ThreDee.DrawLine(BlkPen, pt1, pt2);
               pt1 = new PointF((float)(Rect.Left + SixtyTwo), (float)(Rect.Bottom - TwoHundred));
               pt2 = new PointF((float)(Rect.Right - OneSixtyTwo), (float)(Rect.Bottom - TwoHundred));
               ThreDee.DrawLine(BlkPen, pt1, pt2);
               pt1 = new PointF((float)(Rect.Right - SixtyTwo), (float)(Rect.Bottom - FourFifty));
               pt2 = new PointF((float)(Rect.Right - OneSixtyTwo), (float)(Rect.Bottom - TwoHundred));
               ThreDee.DrawLine(BlkPen, pt1, pt2);


               pt1 = new PointF((float)(Rect.Left + OneSixtyTwo), (float)(Rect.Top + OneFifty));
               pt2 = new PointF((float)(Rect.Right - SixtyTwo), (float)(Rect.Top + OneFifty));
               ThreDee.DrawLine(BlkPen, pt1, pt2);


               pt1 = new PointF((float)(Rect.Right - SixtyTwo), (float)(Rect.Bottom - FourFifty));
               pt2 = new PointF((float)(Rect.Right - SixtyTwo), (float)(Rect.Top + OneFifty));
               ThreDee.DrawLine(BlkPen, pt1, pt2);

               DrawGrids();


               if (CtrSelectedCraph == 0)
               {
                   ThreDee.DrawCurve(new Pen(Color.DarkRed, (float)2), Pts, (float)0);
               }
               else if (Pts != null)
                   ThreDee.DrawCurve(new Pen(Color.DarkRed, (float).5), Pts, (float)0);
               if (CtrSelectedCraph == 1)
               {
                   ThreDee.DrawCurve(new Pen(Color.DarkGreen, (float)2), Pts1, (float)0);
               }
               else if (Pts1 != null)
                   ThreDee.DrawCurve(new Pen(Color.DarkGreen, (float).5), Pts1, (float)0);

               if (CtrSelectedCraph == 2)
               {
                   ThreDee.DrawCurve(new Pen(Color.DarkGoldenrod, (float)2), Pts2, (float)0);
               }
               else if (Pts2 != null)
                   ThreDee.DrawCurve(new Pen(Color.DarkGoldenrod, (float).5), Pts2, (float)0);

               if (CtrSelectedCraph == 3)
               {
                   ThreDee.DrawCurve(new Pen(Color.DarkViolet, (float)2), Pts3, (float)0);
               }
               else if (Pts3 != null)
                   ThreDee.DrawCurve(new Pen(Color.DarkViolet, (float).5), Pts3, (float)0);

               if (CtrSelectedCraph == 4)
               {
                   ThreDee.DrawCurve(new Pen(Color.DarkBlue, (float)2), Pts4, (float)0);
               }
               else if (Pts4 != null)
                   ThreDee.DrawCurve(new Pen(Color.DarkBlue, (float).5), Pts4, (float)0);

               if (CtrSelectedCraph == 5)
               {
                   ThreDee.DrawCurve(new Pen(Color.DimGray, (float)2), Pts5, (float)0);
               }
               else if (Pts5 != null)
                   ThreDee.DrawCurve(new Pen(Color.DimGray, (float).5), Pts5, (float)0);

               if (CtrSelectedCraph == 6)
               {
                   ThreDee.DrawCurve(new Pen(Color.Chocolate, (float)2), Pts6, (float)0);
               }
               else if (Pts6 != null)
                   ThreDee.DrawCurve(new Pen(Color.Chocolate, (float).5), Pts6, (float)0);
               if (CtrSelectedCraph == 7)
               {
                   ThreDee.DrawCurve(new Pen(Color.DarkKhaki, (float)2), Pts7, (float)0);
               }
               else if (Pts7 != null)
                   ThreDee.DrawCurve(new Pen(Color.DarkKhaki, (float).5), Pts7, (float)0);


               SetDatesOfThreeDee();


           }
           catch (Exception ex)
           {
           }
       }

       public void GenerateShaftCenterChange(double[] YAxis1, double[] YAxis2)
       {
           SetAxis();
           Region rgn1 = new Region(panel1.Bounds);
           System.Drawing.Graphics der = panel1.CreateGraphics();
           der.Clip = rgn1;
           Pen PenBlkB = new Pen(Color.Black, 1);
           Pen PenRed = new Pen(Color.Red, 2);
           RectangleF pt = der.ClipBounds;
           Pen BlkDash = new Pen(Color.Black, (float).5);
           BlkDash.DashCap = DashCap.Triangle;
           BlkDash.DashStyle = DashStyle.Dash;
           Point pt1 = new Point();
           Point pt2 = new Point();
           PointF Ptsn1 = new PointF();
           try
           {

               ////// Y axis
               double dYTopX = (double)(((double)panel1.Right) / 2);
               double dYTopY = (double)panel1.Top + OneFifty;

               double dYBottomX = (double)(((double)panel1.Right) / 2);
               double dYBottomY = (double)panel1.Bottom - ((double)panel1.Bottom / 10);

               double TotalYAxis = Math.Sqrt((double)(((double)(dYTopX - dYBottomX) * (double)(dYTopX - dYBottomX)) + ((double)(dYTopY - dYBottomY) * (double)(dYTopY - dYBottomY))));

               //////// X axis
               double dXLeftX = (double)(pt.Right - TotalYAxis) / 2;//(double)panel1.Left + dYTopX/2+SixtyTwo;
               double dXLeftY = (double)(((double)panel1.Bottom - ((double)panel1.Bottom / 10) - (double)panel1.Top + OneFifty) / 2);

               double dXRightX = dXLeftX + TotalYAxis;
               double dXRightY = (double)(((double)panel1.Bottom - ((double)panel1.Bottom / 10) - (double)panel1.Top + OneFifty) / 2);


               double TotalXAxis = Math.Sqrt((double)(((double)(dXLeftX - dXRightX) * (double)(dXLeftX - dXRightX)) + ((double)(dXLeftY - dXRightY) * (double)(dXLeftY - dXRightY))));

               ///////// Forward Diagnol
               double dXTopRightX = (double)dXRightX;
               double dXTopRightY = (double)panel1.Top + OneFifty;

               double dXBottomLeftX = (double)dXLeftX;
               double dXBottomLeftY = (double)panel1.Bottom - ((double)panel1.Bottom / 10);

               ////////// backward diagnol
               double dYTopLeftX = (double)dXLeftX;
               double dYTopLeftY = (double)panel1.Top + OneFifty;

               double dYBottomRightX = (double)dXRightX;
               double dYBottomRightY = (double)panel1.Bottom - ((double)panel1.Bottom / 10);



               ////Draw All Axis

               //Y Axis
               pt1 = new Point((int)dYTopX, (int)dYTopY);
               pt2 = new Point((int)dYBottomX, (int)dYBottomY);
               der.DrawLine(PenBlkB, pt1, pt2);

               //X Axis
               pt1 = new Point((int)dXLeftX, (int)dXLeftY);
               pt2 = new Point((int)dXRightX, (int)dXRightY);
               der.DrawLine(PenBlkB, pt1, pt2);

               //Forward Diagnol
               pt1 = new Point((int)dXTopRightX, (int)dXTopRightY);
               pt2 = new Point((int)dXBottomLeftX, (int)dXBottomLeftY);
               der.DrawLine(BlkDash, pt1, pt2);//BlkDash

               //backward diagnol
               pt1 = new Point((int)dYTopLeftX, (int)dYTopLeftY);
               pt2 = new Point((int)dYBottomRightX, (int)dYBottomRightY);
               der.DrawLine(BlkDash, pt1, pt2);


               der.DrawArc(PenBlkB, (float)dYTopLeftX, (float)dYTopLeftY, (float)TotalXAxis, (float)TotalYAxis, 0, 360);


               double rad = (double)(TotalXAxis / 4);


               Pts = new PointF[0];
               Font objFont = new Font("Roman", 10, FontStyle.Bold);
               Brush objBrush = Brushes.Black;
               for (int i = 0; i < 361; i++)
               {

                   Array.Resize(ref Pts, Pts.Length + 1);

                   double X = (double)(rad * Math.Cos(0.0174532925 * (360 - i))) + (double)(pt.Right / 2);
                   double Y = (double)(rad * Math.Sin(0.0174532925 * (360 - i))) + (double)((panel1.Bottom + OneFifty) / 2);

                   Ptsn1 = new PointF((float)X, (float)Y);

                   if (i == 0 || i == 45 || i == 90 || i == 135 || i == 180 || i == 225 || i == 270 || i == 315)
                   {
                       int degree = i + 90;
                       if (degree >= 360)
                       {
                           degree = degree - 360;
                       }
                       der.DrawString(degree.ToString() + "º", objFont, objBrush, Ptsn1);
                   }

                   Pts[i] = Ptsn1;
               }

               der.DrawCurve(BlkDash, Pts, (float)0);

               XData = YAxis1;
               YData = YAxis2;


               double MainYAxisInterval1 = 0;
               double MainYAxisInterval2 = 0;

               float HighestX = findHighestValue(XData);
               float HighestY = findHighestValue(YData);

               float MaxX = HighestX * 3;// *4;
               float MaxY = HighestY * 3;// *4;

               MainYAxisInterval1 = (double)(MaxX / (TotalXAxis / 2));
               MainYAxisInterval2 = (double)(MaxY / (TotalYAxis));
               Pts = new PointF[0];
               if (MainYAxisInterval1 != 0 && MainYAxisInterval2 != 0)
               {
                   for (int i = 0; i < XData.Length; i++)
                   {


                       Array.Resize(ref Pts, Pts.Length + 1);

                       Ptsn1 = new PointF((float)((dXLeftX + TotalXAxis / 2) + (float)(XData[i] / MainYAxisInterval1)), (float)(dYBottomY - (float)(YData[i] / MainYAxisInterval2)));

                       Pts[i] = Ptsn1;
                       der.FillRectangle(objBrush, Pts[i].X - 2, Pts[i].Y - 2, 4, 4);
                   }
                   der.DrawCurve(PenRed, Pts, (float)0);

               }


           }
           catch (Exception ex)
           {
           }

       }




       ArrayList DatesSelected = new ArrayList();
       public ArrayList SlctedDates
       {
           get
           {
               return DatesSelected;
           }
           set
           {
               DatesSelected = value;
           }

       }
       private void SetDatesOfThreeDee()
       {
           SetAxis();
           Region Rgn = new Region(panel1.Bounds);
           Graphics ThreDee = panel1.CreateGraphics();
           
           ThreDee.Clip = Rgn;

           Pen BlkPen = new Pen(Color.Black, 1);
           
           RectangleF Rect = ThreDee.ClipBounds;
           
           Font objFont = new Font("Roman", 7, FontStyle.Italic);
           Brush objBrush = Brushes.Black;
           int StartPosition = 0;

           try
           {
               if (SlctedDates.Count > 16)
               {
                   StartPosition = SlctedDates.Count - 16;
               }
               else
               {
                   StartPosition = 0;

               }
               PointF LstPoint = Pts[Pts.Length - 1];
               ThreDee.DrawString(SlctedDates[StartPosition].ToString(), objFont, objBrush, LstPoint.X + 0, LstPoint.Y);

               LstPoint = Pts1[Pts1.Length - 1];
               ThreDee.DrawString(SlctedDates[StartPosition + 1].ToString(), objFont, objBrush, LstPoint.X + 0, LstPoint.Y);

               LstPoint = Pts2[Pts2.Length - 1];
               ThreDee.DrawString(SlctedDates[StartPosition + 2].ToString(), objFont, objBrush, LstPoint.X + 0, LstPoint.Y);

               LstPoint = Pts3[Pts3.Length - 1];
               ThreDee.DrawString(SlctedDates[StartPosition + 3].ToString(), objFont, objBrush, LstPoint.X + 0, LstPoint.Y);

               LstPoint = Pts4[Pts4.Length - 1];
               ThreDee.DrawString(SlctedDates[StartPosition + 4].ToString(), objFont, objBrush, LstPoint.X + 0, LstPoint.Y);

               LstPoint = Pts5[Pts5.Length - 1];
               ThreDee.DrawString(SlctedDates[StartPosition + 5].ToString(), objFont, objBrush, LstPoint.X + 0, LstPoint.Y);

               LstPoint = Pts6[Pts6.Length - 1];
               ThreDee.DrawString(SlctedDates[StartPosition + 6].ToString(), objFont, objBrush, LstPoint.X + 0, LstPoint.Y);

               LstPoint = Pts7[Pts7.Length - 1];
               ThreDee.DrawString(SlctedDates[StartPosition + 7].ToString(), objFont, objBrush, LstPoint.X + 0, LstPoint.Y);
           }
           catch (Exception ex)
           {               
           }
       }

       public void DataGridSettingForPhase(bool MultipleCrsr)
       {
           try
           {
               if (MultipleCrsr)
               {
                   dataGridView1.Rows.Clear();
                   for (int i = 0; i < dataGridView1.Columns.Count; )
                   {
                       dataGridView1.Columns.RemoveAt(0);
                   }
                   if (PublicClass.checkphase == "true")
                   {
                       for (int i = 0; i < 4; i++)
                       {
                           switch (i)
                           {
                               case 0:
                                   {
                                       dataGridView1.Columns.Add("ColSrNo.", "Orders");
                                       break;
                                   }
                               case 1:
                                   {
                                       dataGridView1.Columns.Add("ColXValue", "CH1(Mag.&Phase)");
                                       break;
                                   }
                               case 2:
                                   {
                                       dataGridView1.Columns.Add("ColYValue", "CH2(Mag.&Phase)");
                                       break;
                                   }
                               case 3:
                                   {
                                       dataGridView1.Columns.Add("ColCrossph", "CrossPhase(Mag.&Phase)");
                                       break;
                                   }
                           }
                       }
                   }
                   else
                   {                      
                       for (int i = 0; i < 2; i++)
                       {
                           switch (i)
                           {
                               case 0:
                                   {
                                       dataGridView1.Columns.Add("ColXValue", "SR.No");
                                       break;
                                   }
                               case 1:
                                   {
                                       dataGridView1.Columns.Add("ColYValue", "Phase Value");
                                       break;
                                   }
                           }
                       }
                   }
               }
               else
               {
                   dataGridView1.Rows.Clear();
                   SetDatagridtoOriginal();
               }
           }
           catch
           { }
       }



       public void DataGridSettingForDifferenceCursor(bool MultipleCrsr)
       {
           try
           {
               if (MultipleCrsr)
               {
                   dataGridView1.Rows.Clear();
                   for (int i = 0; i < dataGridView1.Columns.Count; )
                   {
                       dataGridView1.Columns.RemoveAt(0);
                   }
                   for (int i = 0; i < 5; i++)
                   {
                       switch (i)
                       {
                           case 1:
                               {
                                   dataGridView1.Columns.Add("ColXValue", "X Value");
                                   break;
                               }
                           case 2:
                               {
                                   dataGridView1.Columns.Add("ColYValue", "Y Value");
                                   break;
                               }
                           case 0:
                               {
                                   dataGridView1.Columns.Add("ColColor", "Cursor&Color");
                                   break;
                               }
                           case 3:
                               {
                                   dataGridView1.Columns.Add("ColXDiff", "X Diff");
                                   break;
                               }
                           case 4:
                               {
                                   dataGridView1.Columns.Add("ColYDiff", "Y Diff");
                                   break;
                               }
                       }
                   }
               }
               else
               {
                   dataGridView1.Rows.Clear();
                   SetDatagridtoOriginal();
               }
           }
           catch (Exception ex)
           {
           }
       }
       
        public void redrawSCL()
        {
            Region rgn1 = new Region(panel1.Bounds);
            System.Drawing.Graphics der = panel1.CreateGraphics();
            der.Clip = rgn1;
            Pen PenBlkB = new Pen(Color.Black, 1);
            Pen PenRed = new Pen(Color.Red, 2);
            RectangleF pt = der.ClipBounds;
            Pen BlkDash = new Pen(Color.Black, (float).5);
            BlkDash.DashCap = DashCap.Triangle;
            BlkDash.DashStyle = DashStyle.Dash;
            Point pt1 = new Point();
            Point pt2 = new Point();
            PointF Ptsn1 = new PointF();
            PointF[] DegreePts = null;
            PointF[] directionPTS = new PointF[0];
            Brush objBrush = Brushes.Black;
            try
            {
               
                SetAxis();
                ////// Y axis
                double dYTopX = (double)(((double)panel1.Right) / 2);
                double dYTopY = (double)panel1.Top + OneFifty;

                double dYBottomX = (double)(((double)panel1.Right) / 2);
                double dYBottomY = (double)panel1.Bottom - ((double)panel1.Bottom / 10);

                double TotalYAxis = Math.Sqrt((double)(((double)(dYTopX - dYBottomX) * (double)(dYTopX - dYBottomX)) + ((double)(dYTopY - dYBottomY) * (double)(dYTopY - dYBottomY))));

                //////// X axis
                double dXLeftX = (double)(pt.Right - TotalYAxis) / 2;
                double dXLeftY = (double)(((double)panel1.Bottom - ((double)panel1.Bottom / 10) - (double)panel1.Top + OneFifty) / 2);

                double dXRightX = dXLeftX + TotalYAxis;
                double dXRightY = (double)(((double)panel1.Bottom - ((double)panel1.Bottom / 10) - (double)panel1.Top + OneFifty) / 2);


                double TotalXAxis = Math.Sqrt((double)(((double)(dXLeftX - dXRightX) * (double)(dXLeftX - dXRightX)) + ((double)(dXLeftY - dXRightY) * (double)(dXLeftY - dXRightY))));

                ///////// Forward Diagnol
                double dXTopRightX = (double)dXRightX;
                double dXTopRightY = (double)panel1.Top + OneFifty;

                double dXBottomLeftX = (double)dXLeftX;
                double dXBottomLeftY = (double)panel1.Bottom - ((double)panel1.Bottom / 10);

                ////////// backward diagnol
                double dYTopLeftX = (double)dXLeftX;
                double dYTopLeftY = (double)panel1.Top + OneFifty;

                double dYBottomRightX = (double)dXRightX;
                double dYBottomRightY = (double)panel1.Bottom - ((double)panel1.Bottom / 10);

                ////Draw All Axis

                //Y Axis
                pt1 = new Point((int)dYTopX, (int)dYTopY);
                pt2 = new Point((int)dYBottomX, (int)dYBottomY);
                der.DrawLine(PenBlkB, pt1, pt2);

                //X Axis
                pt1 = new Point((int)dXLeftX, (int)dXLeftY);
                pt2 = new Point((int)dXRightX, (int)dXRightY);
                der.DrawLine(PenBlkB, pt1, pt2);

                //Forward Diagnol
                pt1 = new Point((int)dXTopRightX, (int)dXTopRightY);
                pt2 = new Point((int)dXBottomLeftX, (int)dXBottomLeftY);
                der.DrawLine(BlkDash, pt1, pt2);//BlkDash

                //backward diagnol
                pt1 = new Point((int)dYTopLeftX, (int)dYTopLeftY);
                pt2 = new Point((int)dYBottomRightX, (int)dYBottomRightY);
                der.DrawLine(BlkDash, pt1, pt2);//BlkDash


                //Draw X Probe
                PointF[] temppointf = new PointF[4];
                pt1 = new Point((int)((double)(5 * Math.Cos(0.0174532925 * (360 - 135))) + dXTopRightX), (int)((double)(5 * Math.Sin(0.0174532925 * (360 - 135))) + dXTopRightY));                      //pt1 = new Point((int)dXTopRightX - 1, (int)dXTopRightY - 2);
                pt2 = new Point((int)((double)(5 * Math.Cos(0.0174532925 * (360 - 270))) + dXTopRightX), (int)((double)(5 * Math.Sin(0.0174532925 * (360 - 270))) + dXTopRightY));//new Point((int)dXTopRightX + 2, (int)dXTopRightY + 1);
                der.DrawLine(BlkDash, pt1, pt2);

                temppointf[0] = pt1;
                temppointf[1] = pt2;

                pt1 = new Point((int)((double)(5 * Math.Cos(0.0174532925 * (360 - 135))) + dXTopRightX + TotalXAxis / 20), (int)((double)(5 * Math.Sin(0.0174532925 * (360 - 135))) + dXTopRightY - TotalXAxis / 20));                      //pt1 = new Point((int)dXTopRightX - 1, (int)dXTopRightY - 2);
                pt2 = new Point((int)((double)(5 * Math.Cos(0.0174532925 * (360 - 270))) + dXTopRightX + TotalXAxis / 20), (int)((double)(5 * Math.Sin(0.0174532925 * (360 - 270))) + dXTopRightY - TotalXAxis / 20));//new Point((int)dXTopRightX + 2, (int)dXTopRightY + 1);

                der.DrawLine(BlkDash, pt1, pt2);

                temppointf[3] = pt1;
                temppointf[2] = pt2;


                der.FillPolygon(objBrush, temppointf);
                temppointf = new PointF[5];
                temppointf[0] = pt2;
                temppointf[1] = new PointF(pt2.X + 5, pt2.Y + 3);
                temppointf[2] = new PointF(pt2.X + 10, pt2.Y);
                temppointf[3] = new PointF(pt2.X + 15, pt2.Y - 3);
                temppointf[4] = new PointF(pt2.X + 20, pt2.Y - 10);
                der.DrawCurve(PenBlkB, temppointf);

                //Draw Y Probe+
                temppointf = new PointF[4];
                
                pt1 = new Point((int)((double)(5 * Math.Cos(0.0174532925 * (360 - 45))) + dYTopLeftX), (int)((double)(5 * Math.Sin(0.0174532925 * (360 - 45))) + dYTopLeftY));                      //pt1 = new Point((int)dXTopRightX - 1, (int)dXTopRightY - 2);
                pt2 = new Point((int)((double)(5 * Math.Cos(0.0174532925 * (360 - 225))) + dYTopLeftX), (int)((double)(5 * Math.Sin(0.0174532925 * (360 - 225))) + dYTopLeftY));//new Point((int)dXTopRightX + 2, (int)dXTopRightY + 1);

                der.DrawLine(BlkDash, pt1, pt2);

                temppointf[0] = pt1;
                temppointf[1] = pt2;

              
                pt1 = new Point((int)((double)(5 * Math.Cos(0.0174532925 * (360 - 45))) + dYTopLeftX - TotalXAxis / 20), (int)((double)(5 * Math.Sin(0.0174532925 * (360 - 45))) + dYTopLeftY - TotalXAxis / 20));                      //pt1 = new Point((int)dXTopRightX - 1, (int)dXTopRightY - 2);
                pt2 = new Point((int)((double)(5 * Math.Cos(0.0174532925 * (360 - 225))) + dYTopLeftX - TotalXAxis / 20), (int)((double)(5 * Math.Sin(0.0174532925 * (360 - 225))) + dYTopLeftY - TotalXAxis / 20));//new Point((int)dXTopRightX + 2, (int)dXTopRightY + 1);

                der.DrawLine(BlkDash, pt1, pt2);

                temppointf[3] = pt1;
                temppointf[2] = pt2;


                der.FillPolygon(objBrush, temppointf);

                temppointf = new PointF[5];
                temppointf[0] = pt2;
                temppointf[1] = new PointF(pt2.X - 5, pt2.Y + 3);
                temppointf[2] = new PointF(pt2.X - 10, pt2.Y);
                temppointf[3] = new PointF(pt2.X - 15, pt2.Y - 3);
                temppointf[4] = new PointF(pt2.X - 20, pt2.Y - 10);
                der.DrawCurve(PenBlkB, temppointf);

                der.DrawArc(PenBlkB, (float)dYTopLeftX, (float)dYTopLeftY, (float)TotalXAxis, (float)TotalYAxis, 0, 360);
                
                double rad = (double)(TotalXAxis / 4);
                double rad1 = (double)(TotalXAxis / 2);
                DegreePts = new PointF[0];
                Font objFont = new Font("Roman", 10, FontStyle.Bold);

                Brush objBrushRed = Brushes.Red;
                for (int i = 0; i < 361; i++)
                {

                    Array.Resize(ref DegreePts, DegreePts.Length + 1);
                    double X = (double)(rad * Math.Cos(0.0174532925 * (360 - i))) + (double)(pt.Right / 2);
                    double Y = (double)(rad * Math.Sin(0.0174532925 * (360 - i))) + (double)((panel1.Bottom + OneFifty - ((double)panel1.Bottom / 10)) / 2);

                    Ptsn1 = new PointF((float)X, (float)Y);

                    if (i == 0 || i == 45 || i == 90 || i == 135 || i == 180 || i == 225 || i == 270 || i == 315)
                    {
                        int degree = i + 90;
                        if (degree >= 360)
                        {
                            degree = degree - 360;
                        }
                        der.DrawString(degree.ToString(), objFont, objBrush, (float)((double)((rad1 + (rad) / 4) * Math.Cos(0.0174532925 * (360 - i))) + (double)(pt.Right / 2)), (float)((double)((rad1 + (rad) / 5) * Math.Sin(0.0174532925 * (360 - i))) + (double)((panel1.Bottom + OneFifty - ((double)panel1.Bottom / 10)) / 2)));//+ "º"
                    }
                    if (i > 70 && i < 110)
                    {
                        Array.Resize(ref directionPTS, directionPTS.Length + 1);
                        X = (double)((rad1 + (rad * 2) / 4) * Math.Cos(0.0174532925 * (360 - i))) + (double)(pt.Right / 2);
                        Y = (double)((rad1 + (rad * 2) / 4) * Math.Sin(0.0174532925 * (360 - i))) + (double)((panel1.Bottom + OneFifty) / 2);

                        directionPTS[directionPTS.Length - 1] = new PointF((float)X, (float)Y);
                        if (i == 109)
                        {
                            der.DrawLine(BlkDash, (float)X, (float)Y, (float)X + 5, (float)Y - 10);
                            der.DrawLine(BlkDash, (float)X, (float)Y, (float)X + 10, (float)Y + 5);
                        }
                    }

                    DegreePts[i] = Ptsn1;
                }

                der.DrawCurve(BlkDash, DegreePts, (float)0);

                der.DrawCurve(BlkDash, directionPTS, (float)0);


                der.DrawCurve(PenRed, Pts, (float)0);
                for (int i = 0; i < Pts.Length; i++)
                {
                    der.DrawString("X= " + Math.Round(XData[i], 3).ToString() + " Y=" + Math.Round(YData[i], 3).ToString(), objFont, objBrushRed, Pts[i]);
                    der.FillRectangle(objBrush, Pts[i].X - 2, Pts[i].Y - 2, 4, 4);
                }
                SetAxisMarks(XData, YData);
            }
            catch (Exception ex)
            {
            }
        }


        PointF[] Points1 = new PointF[0];
        PointF[] Points2 = new PointF[0];
        PointF[] PointsY1 = new PointF[0];
        PointF[] PointsY2 = new PointF[0];
        private bool CheckForTimeDataInAxisLines(double[] Target)
        {
            bool DtTime = false;
            try
            {
                for (int i = 0; i < Target.Length; i++)
                {
                    if (Target[i] < 0)
                    {
                        DtTime = true;
                    }
                    else if (Target[i] >= 0)
                        DtTime = false;
                    if (DtTime == true)
                        break;
                }
            }
            catch (Exception ex)
            {               
            }
            return DtTime;
        }

        private float findHighestValue(double[] Target)
        {
            double MaxVal = 0.0;
            double MinVal = 0.0;
            double FinalVal = 0.0;
            try
            {
                for (int i = 0; i < Target.Length; i++)
                {
                    if (Target[i] > MaxVal)
                        MaxVal = Target[i];
                    if (Target[i] < MinVal)
                        MinVal = Target[i];
                }
                MinVal = Math.Abs(MinVal);
                if (MaxVal >= MinVal)
                    FinalVal = MaxVal;
                else if (MinVal > MaxVal)
                    FinalVal = MinVal;



            }
            catch (Exception ex)
            {                
            }
            return (float)FinalVal;
        }
        ArrayList TmArr = null;

        public ArrayList TimeArr
        {
            get
            {
                return TmArr;
            }
            set
            {
                TmArr = value;
            }
        }
        string TrendType = null;
        double LesserVal = 0.0;
        int PointLenth = 0;
        int LastPointLenth = 0;
        int CtrPtS = 0;
        double DblPointVal = 0.0;
        bool SetValZero = false;
        double HighestValYAxis = 0.0;
        private void SetAxisMarks(double[] TargetX, double[] TargetY)
        {
            try
            {
                if (MainForm.GraphType != "Orbit" && MainForm.GraphType != "SCL" && MainForm.GraphType != "Octave")
                {
                    Points1 = new PointF[0];
                    Points2 = new PointF[0];
                    PointsY1 = new PointF[0];
                    PointsY2 = new PointF[0];
                    int DateCtrToDisplay = 0;
                    SetAxis();
                    Pen BlkDash = new Pen(Color.Black, (float).5);
                    BlkDash.DashCap = DashCap.Triangle;
                    BlkDash.DashStyle = DashStyle.Dash;
                    int ctrAxisLines = 0;
                    double IntervalXAxis = 0.0;
                    bool IfTmData = false;
                    Region objRegion = new Region(panel1.Bounds);
                    Graphics objGraphics = panel1.CreateGraphics();
                    objGraphics.Clip = objRegion;
                    RectangleF objPoint = objGraphics.ClipBounds;
                    IfTmData = CheckForTimeDataInAxisLines(TargetY);
                    double TotalYAxis = 0.0;
                    double TotalXAxis = (Convert.ToDouble(objPoint.Right - objPoint.Left)) - (objPoint.Left + SixtyTwo + OneSixtyTwo);
                    if (IfTmData == true)
                    {
                        TotalYAxis = (Convert.ToDouble(objPoint.Bottom - objPoint.Top)) - (FourHundred + TwoHundred);
                    }
                    else
                    {
                        TotalYAxis = (Convert.ToDouble(objPoint.Bottom - objPoint.Top)) - (TwoHundred);

                    }
                    double MaxVal1 = 0;
                    
                    PointF pt1 = new PointF();
                    PointF pt2 = new PointF();
                    PointF pt3 = new PointF();
                    
                    double HighestValXAxis = Convert.ToDouble(Math.Round(TargetX[TargetX.Length - 1], 5)) + LesserVal;
                    IntervalXAxis = (TotalXAxis / (TargetX.Length - 1));
                    int LineInterval = 0;
                    if (TrendType == "Trend")
                    {
                        LineInterval = (TargetX.Length - 2) / 2;
                    }
                    else
                        LineInterval = (TargetX.Length - 1) / 4;
                    int MiniLineInterval = LineInterval / 10;
                    int ctrMiniInterval = 1;
                    MaxVal1 = findHighestValue(TargetY);
                    double HighestValYAxis1 = Convert.ToDouble(Math.Round(MaxVal1, 5));
                    double LineYInterval = HighestValYAxis1 / 4;
                    double LineYAxisDistance = TotalYAxis / 4;
                    try
                    {
                        Font objFont = new Font("Roman", 10, FontStyle.Regular);
                        Font objFontDt = new Font("Roman", 7, FontStyle.Regular);
                        Brush objBrush = Brushes.Black;
                        if (IfTmData == true)
                        {
                            pt1 = new Point((int)(objPoint.Right - OneSixtyTwo), (int)(objPoint.Bottom - Fifty));
                            pt2 = new Point((int)(objPoint.Left + SixtyTwo), (int)(objPoint.Bottom - Fifty));
                            objGraphics.DrawLine(new Pen(Color.Black, (float)1), pt1, pt2);
                        }
                        
                        if (TrendType != "Trend")
                        {
                            pt2 = new Point((int)(objPoint.Left + SixtyTwo - 15), (int)(objPoint.Bottom - Fifty));
                            
                            objGraphics.DrawString(Convert.ToString(0), objFont, objBrush, pt2);
                        }
                        if (IfTmData == true && TrendType != "Trend")
                        {
                            pt2 = new Point((int)(objPoint.Left + SixtyTwo - 15), (int)(objPoint.Bottom - Fifty));
                            objGraphics.DrawString(Convert.ToString(0), objFont, objBrush, pt2);


                        }
                        else if (TrendType == "Trend")
                        {
                            pt2 = new Point((int)(objPoint.Left + SixtyTwo - 30), (int)(objPoint.Bottom - Fifty));
                            objGraphics.DrawString(Convert.ToString(TmArr[DateCtrToDisplay]), objFontDt, objBrush, pt2);
                            DateCtrToDisplay++;
                        }
                        ctrAxisLines++;
                        if (IfTmData == false)
                        {
                            for (int i = 1; i < TargetX.Length; i++)
                            {
                                if (ctrAxisLines == (MiniLineInterval * ctrMiniInterval) && (MiniLineInterval * ctrMiniInterval) != LineInterval)
                                {
                                    pt1 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty - 10)));//TwoHundred
                                    pt2 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty)));//TwoHundred
                                    pt3 = pt1;
                                    objGraphics.DrawLine(new Pen(Color.Black, (float).5), pt1, pt2);
                                    HighestValXAxis = Convert.ToDouble(Math.Round(TargetX[i], 5));

                                    
                                    ctrMiniInterval++;
                                }
                                else if (ctrAxisLines == LineInterval)
                                {
                                    pt1 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty - 20)));//TwoHundred
                                    pt2 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty)));//TwoHundred
                                    pt3 = pt1;
                                    objGraphics.DrawLine(new Pen(Color.Black, (float)1), pt1, pt2);
                                    HighestValXAxis = Convert.ToDouble(Math.Round(TargetX[i], 5));
                                    if (TrendType != "Trend")
                                    {
                                        objGraphics.DrawString(Convert.ToString(HighestValXAxis), objFont, objBrush, pt1);
                                    }
                                    else if (TrendType == "Trend")
                                    {
                                        
                                        if (DateCtrToDisplay % 2 == 0)
                                        {
                                            pt1 = new PointF((float)((objPoint.Left + SixtyTwo - 30) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty)));//TwoHundred
                                        }
                                        else
                                            pt1 = new PointF((float)((objPoint.Left + SixtyTwo - 30) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty + 20)));//TwoHundred

                                        
                                        objGraphics.DrawString(Convert.ToString(TmArr[DateCtrToDisplay]), objFontDt, objBrush, pt1);


                                    }

                                    pt1 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty)));//TwoHundred
                                    pt2 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)(objPoint.Top + OneFifty));//FourHundred
                                    objGraphics.DrawLine(BlkDash, pt1, pt2);


                                    Array.Resize(ref Points1, Points1.Length + 1);
                                    Array.Resize(ref Points2, Points2.Length + 1);
                                    Points1[Points1.Length - 1] = pt1;
                                    Points2[Points2.Length - 1] = pt2;



                                    ctrAxisLines = 0;
                                    ctrMiniInterval = 1;
                                    DateCtrToDisplay++;
                                }
                                else if (ctrAxisLines == (ctrMiniInterval))
                                {
                                    if (TrendType == "Trend")
                                    {
                                        if (DateCtrToDisplay % 2 == 0)
                                        {
                                            pt1 = new PointF((float)((objPoint.Left + SixtyTwo - 30) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty)));//TwoHundred
                                        }
                                        else
                                            pt1 = new PointF((float)((objPoint.Left + SixtyTwo - 30) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty + 20)));//TwoHundred
                                        
                                        objGraphics.DrawString(Convert.ToString(TmArr[DateCtrToDisplay]), objFontDt, objBrush, pt1);
                                        DateCtrToDisplay++;

                                    }
                                    
                                    ctrMiniInterval++;
                                }
                                ctrAxisLines++;
                            }
                        }
                        else if (IfTmData == true)
                        {
                            for (int i = 0; i < TargetX.Length; i++)
                            {
                                if (ctrAxisLines == (MiniLineInterval * ctrMiniInterval) && (MiniLineInterval * ctrMiniInterval) != LineInterval)
                                {
                                    pt1 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)((objPoint.Bottom - Fifty) + 10));//TwoHundred
                                    pt2 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)((objPoint.Bottom - Fifty)));//TwoHundred
                                    pt3 = pt1;
                                    objGraphics.DrawLine(new Pen(Color.Black, (float).5), pt1, pt2);
                                    HighestValXAxis = Convert.ToDouble(Math.Round(TargetX[i], 5));
                                    
                                    ctrMiniInterval++;
                                }
                                else if (ctrAxisLines == LineInterval)
                                {
                                    pt1 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)((objPoint.Bottom - Fifty) + 20));//TwoHundred
                                    pt2 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)((objPoint.Bottom - Fifty)));//TwoHundred
                                    pt3 = pt1;
                                    objGraphics.DrawLine(new Pen(Color.Black, (float)1), pt1, pt2);
                                    HighestValXAxis = Convert.ToDouble(Math.Round(TargetX[i], 5));
                                    objGraphics.DrawString(Convert.ToString(HighestValXAxis), objFont, objBrush, pt1);


                                    pt1 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)((objPoint.Bottom - Fifty)));//TwoHundred
                                    pt2 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)(objPoint.Top + OneFifty));//FourHundred
                                    objGraphics.DrawLine(BlkDash, pt1, pt2);


                                    ctrAxisLines = 0;
                                    ctrMiniInterval = 1;
                                }
                                ctrAxisLines++;
                            }
                        }

                        if (IfTmData == false)
                        {
                            int i = 1;
                            do
                            {


                                pt1 = new PointF((float)((objPoint.Left + SixtyTwo) - 20), (float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)((objPoint.Left + SixtyTwo)), (float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt3 = new PointF((float)((objPoint.Left)), (float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)));
                                objGraphics.DrawLine(new Pen(Color.Black, (float)1), pt1, pt2);
                                objGraphics.DrawString(Convert.ToString(Math.Round((LineYInterval * i), 3)), objFont, objBrush, pt3);

                                pt1 = new PointF((float)(objPoint.Left + SixtyTwo), (float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)(objPoint.Right - OneSixtyTwo), (float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)));//TwoHundred
                                objGraphics.DrawLine(BlkDash, pt1, pt2);


                                Array.Resize(ref PointsY1, PointsY1.Length + 1);
                                Array.Resize(ref PointsY2, PointsY2.Length + 1);
                                PointsY1[PointsY1.Length - 1] = pt1;
                                PointsY2[PointsY2.Length - 1] = pt2;



                                i++;
                                if (objPoint.X == 0 && objPoint.Y == 0 && objPoint.Width == 0 && objPoint.Height == 0)
                                {
                                    break;
                                }
                            } while ((float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)) >= (objPoint.Top + OneFifty));
                        }

                        if (IfTmData == true)
                        {
                            int i = 1;
                            do
                            {


                                pt1 = new PointF((float)((objPoint.Left + SixtyTwo) - 20), (float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)((objPoint.Left + SixtyTwo)), (float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt3 = new PointF((float)((objPoint.Left)), (float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)));
                                objGraphics.DrawLine(new Pen(Color.Black, (float)1), pt1, pt2);
                                objGraphics.DrawString(Convert.ToString(Math.Round((LineYInterval * i), 3)), objFont, objBrush, pt3);

                                pt1 = new PointF((float)(objPoint.Left + SixtyTwo), (float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)(objPoint.Right - OneSixtyTwo), (float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)));//TwoHundred
                                objGraphics.DrawLine(BlkDash, pt1, pt2);





                                pt1 = new PointF((float)((objPoint.Left + SixtyTwo) - 20), (float)(objPoint.Bottom - (TwoHundred + OneFifty) + (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)((objPoint.Left + SixtyTwo)), (float)(objPoint.Bottom - (TwoHundred + OneFifty) + (LineYAxisDistance * i)));//TwoHundred
                                pt3 = new PointF((float)((objPoint.Left)), (float)(objPoint.Bottom - (TwoHundred + OneFifty) + (LineYAxisDistance * i)));
                                objGraphics.DrawLine(new Pen(Color.Black, (float)1), pt1, pt2);
                                objGraphics.DrawString("-" + Convert.ToString(Math.Round((LineYInterval * i), 3)), objFont, objBrush, pt3);

                                pt1 = new PointF((float)(objPoint.Left + SixtyTwo), (float)(objPoint.Bottom - (TwoHundred + OneFifty) + (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)(objPoint.Right - OneSixtyTwo), (float)(objPoint.Bottom - (TwoHundred + OneFifty) + (LineYAxisDistance * i)));//TwoHundred
                                objGraphics.DrawLine(BlkDash, pt1, pt2);


                                i++;
                                if (objPoint.X == 0 && objPoint.Y == 0 && objPoint.Width == 0 && objPoint.Height == 0)
                                {
                                    break;
                                }
                            } while ((float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)) >= (objPoint.Top + OneFifty));
                        }




                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
                else if (MainForm.GraphType == "Orbit")
                {
                    int DateCtrToDisplay = 0;
                    SetAxis();
                    Pen BlkDash = new Pen(Color.Black, (float).5);
                    BlkDash.DashCap = DashCap.Triangle;
                    BlkDash.DashStyle = DashStyle.Dash;
                    int ctrAxisLines = 0;
                    double IntervalXAxis = 0.0;
                    bool IfTmData = false;
                    Region objRegion = new Region(panel1.Bounds);
                    Graphics objGraphics = panel1.CreateGraphics();
                    objGraphics.Clip = objRegion;
                    RectangleF objPoint = objGraphics.ClipBounds;
                    IfTmData = CheckForTimeDataInAxisLines(TargetY);
                    double TotalYAxis = 0.0;
                    double TotalXAxis = (Convert.ToDouble(objPoint.Right - objPoint.Left)) - (objPoint.Left + SixtyTwo + OneSixtyTwo);
                    if (IfTmData == true)
                    {
                        TotalYAxis = (Convert.ToDouble(objPoint.Bottom - objPoint.Top)) - (FourHundred + TwoHundred);
                    }
                    else
                    {
                        TotalYAxis = (Convert.ToDouble(objPoint.Bottom - objPoint.Top)) - (TwoHundred);

                    }
                    double MaxVal = 0;
                    
                    PointF pt1 = new PointF();
                    PointF pt2 = new PointF();
                    PointF pt3 = new PointF();
                    
                    double HighestValXAxis = (HighestValYAxis + (HighestValYAxis / 4));
                    IntervalXAxis = (TotalXAxis / (TargetX.Length - 1));

                    double lowestValXAxis = (-1) * (HighestValXAxis);
                    double[] orbitValXAxis = new double[4];
                    double diffX = HighestValXAxis - lowestValXAxis;
                    double diffXby4 = diffX / 4;
                    for (int i = 0; i < 4; i++)
                    {
                        orbitValXAxis[i] = Math.Round(((diffXby4 * (i + 1)) + lowestValXAxis), 3);
                    }


                    int LineInterval = 0;
                    if (TrendType == "Trend")
                    {
                        LineInterval = (TargetX.Length - 2) / 2;
                    }
                    else
                        LineInterval = (TargetX.Length - 1) / 4;
                    int MiniLineInterval = LineInterval / 10;
                    int ctrMiniInterval = 1;

                    double LineYInterval = HighestValYAxis / 4;
                    double LineYAxisDistance = TotalYAxis / 4;
                    try
                    {
                        Font objFont = new Font("Roman", 10, FontStyle.Bold);
                        Font objFontDt = new Font("Roman", 7, FontStyle.Bold);
                        Brush objBrush = Brushes.Black;
                        if (IfTmData == true)
                        {
                            pt1 = new Point((int)(objPoint.Right - OneSixtyTwo), (int)(objPoint.Bottom - Fifty));
                            pt2 = new Point((int)(objPoint.Left + SixtyTwo), (int)(objPoint.Bottom - Fifty));
                            objGraphics.DrawLine(new Pen(Color.Black, (float)1), pt1, pt2);
                        }
                        
                        if (TrendType != "Trend")
                        {
                            pt2 = new Point((int)(objPoint.Left + SixtyTwo - 15), (int)(objPoint.Bottom - Fifty));
                           
                        }
                        if (IfTmData == true && TrendType != "Trend")
                        {
                            pt2 = new Point((int)(objPoint.Left + SixtyTwo - 15), (int)(objPoint.Bottom - Fifty));
                            


                        }
                        else if (TrendType == "Trend")
                        {
                            pt2 = new Point((int)(objPoint.Left + SixtyTwo - 30), (int)(objPoint.Bottom - Fifty));
                            objGraphics.DrawString(Convert.ToString(TmArr[DateCtrToDisplay]), objFontDt, objBrush, pt2);
                            DateCtrToDisplay++;
                        }
                        ctrAxisLines++;
                        if (IfTmData == false)
                        {
                            for (int i = 1; i < TargetX.Length; i++)
                            {
                                if (ctrAxisLines == (MiniLineInterval * ctrMiniInterval) && (MiniLineInterval * ctrMiniInterval) != LineInterval)
                                {
                                    pt1 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty - 10)));//TwoHundred
                                    pt2 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty)));//TwoHundred
                                    pt3 = pt1;
                                    objGraphics.DrawLine(new Pen(Color.Black, (float).5), pt1, pt2);
                                    HighestValXAxis = Convert.ToDouble(Math.Round(TargetX[i], 5));

                                    
                                    ctrMiniInterval++;
                                }
                                else if (ctrAxisLines == LineInterval)
                                {
                                    pt1 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty - 20)));//TwoHundred
                                    pt2 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty)));//TwoHundred
                                    pt3 = pt1;
                                    objGraphics.DrawLine(new Pen(Color.Black, (float)1), pt1, pt2);
                                    HighestValXAxis = Convert.ToDouble(Math.Round(TargetX[i], 5));
                                    if (TrendType != "Trend")
                                    {
                                        objGraphics.DrawString(Convert.ToString(HighestValXAxis), objFont, objBrush, pt1);
                                    }
                                    else if (TrendType == "Trend")
                                    {
                                        
                                        if (DateCtrToDisplay % 2 == 0)
                                        {
                                            pt1 = new PointF((float)((objPoint.Left + SixtyTwo - 30) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty)));//TwoHundred
                                        }
                                        else
                                            pt1 = new PointF((float)((objPoint.Left + SixtyTwo - 30) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty + 20)));//TwoHundred

                                        
                                        objGraphics.DrawString(Convert.ToString(TmArr[DateCtrToDisplay]), objFontDt, objBrush, pt1);


                                    }

                                    pt1 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty)));//TwoHundred
                                    pt2 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)(objPoint.Top + OneFifty));//FourHundred
                                    objGraphics.DrawLine(BlkDash, pt1, pt2);
                                    ctrAxisLines = 0;
                                    ctrMiniInterval = 1;
                                    DateCtrToDisplay++;
                                }
                                else if (ctrAxisLines == (ctrMiniInterval))
                                {
                                    if (TrendType == "Trend")
                                    {
                                        if (DateCtrToDisplay % 2 == 0)
                                        {
                                            pt1 = new PointF((float)((objPoint.Left + SixtyTwo - 30) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty)));//TwoHundred
                                        }
                                        else
                                            pt1 = new PointF((float)((objPoint.Left + SixtyTwo - 30) + IntervalXAxis * i), (float)(objPoint.Bottom - (Fifty + 20)));//TwoHundred
                                        
                                        objGraphics.DrawString(Convert.ToString(TmArr[DateCtrToDisplay]), objFontDt, objBrush, pt1);
                                        DateCtrToDisplay++;

                                    }
                                    
                                    ctrMiniInterval++;
                                }
                                ctrAxisLines++;
                            }
                        }
                        else if (IfTmData == true)
                        {
                            int k = 0;
                            for (int i = 0; i < TargetX.Length; i++)
                            {
                                if (ctrAxisLines == (MiniLineInterval * ctrMiniInterval) && (MiniLineInterval * ctrMiniInterval) != LineInterval)
                                {
                                    pt1 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)((objPoint.Bottom - Fifty) + 10));//TwoHundred
                                    pt2 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)((objPoint.Bottom - Fifty)));//TwoHundred
                                    pt3 = pt1;
                                    
                                    ctrMiniInterval++;
                                }
                                else if (ctrAxisLines == LineInterval)
                                {
                                    pt1 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)((objPoint.Bottom - Fifty) + 20));//TwoHundred
                                    pt2 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)((objPoint.Bottom - Fifty)));//TwoHundred
                                    pt3 = pt1;
                                    
                                    objGraphics.DrawString(Convert.ToString(orbitValXAxis[k]), objFont, objBrush, pt1);
                                    k++;
                                    pt1 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)((objPoint.Bottom - Fifty)));//TwoHundred
                                    pt2 = new PointF((float)((objPoint.Left + SixtyTwo) + IntervalXAxis * i), (float)(objPoint.Top + OneFifty));//FourHundred
                                    


                                    ctrAxisLines = 0;
                                    ctrMiniInterval = 1;
                                }
                                ctrAxisLines++;
                            }
                        }

                        if (IfTmData == false)
                        {
                            int i = 1;
                            do
                            {


                                pt1 = new PointF((float)((objPoint.Left + SixtyTwo) - 20), (float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)((objPoint.Left + SixtyTwo)), (float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt3 = new PointF((float)((objPoint.Left + SixtyTwo) - 60), (float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)));
                                objGraphics.DrawLine(new Pen(Color.Black, (float)1), pt1, pt2);
                                objGraphics.DrawString(Convert.ToString(Math.Round((LineYInterval * i), 5)), objFont, objBrush, pt3);

                                pt1 = new PointF((float)(objPoint.Left + SixtyTwo), (float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)(objPoint.Right - OneSixtyTwo), (float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)));//TwoHundred
                                objGraphics.DrawLine(BlkDash, pt1, pt2);


                                i++;

                            } while ((float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)) >= (objPoint.Top + OneFifty));
                        }

                        if (IfTmData == true)
                        {
                            int i = 1;
                            do
                            {


                                pt1 = new PointF((float)((objPoint.Left + SixtyTwo) - 20), (float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)((objPoint.Left + SixtyTwo)), (float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt3 = new PointF((float)((objPoint.Left + SixtyTwo) - 60), (float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)));
                                
                                objGraphics.DrawString(Convert.ToString(Math.Round((LineYInterval * i), 5)), objFont, objBrush, pt3);
                                

                                pt1 = new PointF((float)(objPoint.Left + SixtyTwo), (float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)(objPoint.Right - OneSixtyTwo), (float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)));//TwoHundred
                              

                                pt1 = new PointF((float)((objPoint.Left + SixtyTwo) - 20), (float)(objPoint.Bottom - (TwoHundred + OneFifty) + (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)((objPoint.Left + SixtyTwo)), (float)(objPoint.Bottom - (TwoHundred + OneFifty) + (LineYAxisDistance * i)));//TwoHundred
                                pt3 = new PointF((float)((objPoint.Left + SixtyTwo) - 60), (float)(objPoint.Bottom - (TwoHundred + OneFifty) + (LineYAxisDistance * i)));
                                
                                objGraphics.DrawString("-" + Convert.ToString(Math.Round((LineYInterval * i), 5)), objFont, objBrush, pt3);
                                

                                pt1 = new PointF((float)(objPoint.Left + SixtyTwo), (float)(objPoint.Bottom - (TwoHundred + OneFifty) + (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)(objPoint.Right - OneSixtyTwo), (float)(objPoint.Bottom - (TwoHundred + OneFifty) + (LineYAxisDistance * i)));//TwoHundred
                                


                                i++;
                                if (objPoint.Height == objPoint.Width && objPoint.Width == 0)
                                {
                                    break;
                                }
                            } while ((float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)) >= (objPoint.Top + OneFifty));
                        }




                    }
                    catch (Exception ex)
                    {
                       
                    }
                }
                else if (MainForm.GraphType == "Octave")
                {
                    Points1 = new PointF[0];
                    Points2 = new PointF[0];
                    PointsY1 = new PointF[0];
                    PointsY2 = new PointF[0];
                    int DateCtrToDisplay = 0;
                    SetAxis();
                    Pen BlkDash = new Pen(Color.Black, (float).5);
                    BlkDash.DashCap = DashCap.Triangle;
                    BlkDash.DashStyle = DashStyle.Dash;
                    int ctrAxisLines = 0;
                    double IntervalXAxis = 0.0;
                    bool IfTmData = false;
                    Region objRegion = new Region(panel1.Bounds);
                    Graphics objGraphics = panel1.CreateGraphics();
                    objGraphics.Clip = objRegion;
                    RectangleF objPoint = objGraphics.ClipBounds;
                    IfTmData = CheckForTimeDataInAxisLines(TargetY);
                    double TotalYAxis = 0.0;
                    double TotalXAxis = (Convert.ToDouble(objPoint.Right - objPoint.Left)) - (objPoint.Left + SixtyTwo + OneSixtyTwo);
                    if (IfTmData == true)
                    {
                        TotalYAxis = (Convert.ToDouble(objPoint.Bottom - objPoint.Top)) - (FourHundred + TwoHundred);
                    }
                    else
                    {
                        TotalYAxis = (Convert.ToDouble(objPoint.Bottom - objPoint.Top)) - (TwoHundred);

                    }
                    double MaxVal1 = 0;
                    PointF pt1 = new PointF();
                    PointF pt2 = new PointF();
                    PointF pt3 = new PointF();
                    double HighestValXAxis = Convert.ToDouble(Math.Round(TargetX[TargetX.Length - 1], 5)) + LesserVal;
                    IntervalXAxis = (TotalXAxis / (TargetX.Length - 1));
                    int LineInterval = 0;
                    if (TrendType == "Trend")
                    {
                        LineInterval = (TargetX.Length - 2) / 2;
                    }
                    else
                        LineInterval = (TargetX.Length - 1) / 4;
                    int MiniLineInterval = LineInterval / 10;
                    int ctrMiniInterval = 1;
                    MaxVal1 = findHighestValue(TargetY);
                    double HighestValYAxis1 = Convert.ToDouble(Math.Round(MaxVal1, 5));
                    double LineYInterval = HighestValYAxis1 / 4;
                    double LineYAxisDistance = TotalYAxis / 4;
                    try
                    {
                        Font objFont = new Font("Roman", 10, FontStyle.Regular);
                        Font objFontDt = new Font("Roman", 7, FontStyle.Regular);
                        Brush objBrush = Brushes.Black;
                        if (IfTmData == true)
                        {
                            pt1 = new Point((int)(objPoint.Right - OneSixtyTwo), (int)(objPoint.Bottom - Fifty));
                            pt2 = new Point((int)(objPoint.Left + SixtyTwo), (int)(objPoint.Bottom - Fifty));
                            objGraphics.DrawLine(new Pen(Color.Black, (float)1), pt1, pt2);
                        }
                        ctrAxisLines++;
                        if (IfTmData == false)
                        {
                            int i = 1;
                            do
                            {


                                pt1 = new PointF((float)((objPoint.Left + SixtyTwo) - 20), (float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)((objPoint.Left + SixtyTwo)), (float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt3 = new PointF((float)((objPoint.Left)), (float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)));
                                objGraphics.DrawLine(new Pen(Color.Black, (float)1), pt1, pt2);
                                objGraphics.DrawString(Convert.ToString(Math.Round((LineYInterval * i), 3)), objFont, objBrush, pt3);

                                pt1 = new PointF((float)(objPoint.Left + SixtyTwo), (float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)(objPoint.Right - OneSixtyTwo), (float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)));//TwoHundred
                                objGraphics.DrawLine(BlkDash, pt1, pt2);


                                Array.Resize(ref PointsY1, PointsY1.Length + 1);
                                Array.Resize(ref PointsY2, PointsY2.Length + 1);
                                PointsY1[PointsY1.Length - 1] = pt1;
                                PointsY2[PointsY2.Length - 1] = pt2;



                                i++;
                                if (objPoint.X == 0 && objPoint.Y == 0 && objPoint.Width == 0 && objPoint.Height == 0)
                                {
                                    break;
                                }
                            } while ((float)(objPoint.Bottom - (Fifty) - (LineYAxisDistance * i)) >= (objPoint.Top + OneFifty));
                        }

                        if (IfTmData == true)
                        {
                            int i = 1;
                            do
                            {


                                pt1 = new PointF((float)((objPoint.Left + SixtyTwo) - 20), (float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)((objPoint.Left + SixtyTwo)), (float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt3 = new PointF((float)((objPoint.Left + SixtyTwo) - 60), (float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)));
                                objGraphics.DrawLine(new Pen(Color.Black, (float)1), pt1, pt2);
                                objGraphics.DrawString(Convert.ToString(Math.Round((LineYInterval * i), 5)), objFont, objBrush, pt3);

                                pt1 = new PointF((float)(objPoint.Left + SixtyTwo), (float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)(objPoint.Right - OneSixtyTwo), (float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)));//TwoHundred
                                objGraphics.DrawLine(BlkDash, pt1, pt2);





                                pt1 = new PointF((float)((objPoint.Left + SixtyTwo) - 20), (float)(objPoint.Bottom - (TwoHundred + OneFifty) + (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)((objPoint.Left + SixtyTwo)), (float)(objPoint.Bottom - (TwoHundred + OneFifty) + (LineYAxisDistance * i)));//TwoHundred
                                pt3 = new PointF((float)((objPoint.Left + SixtyTwo) - 60), (float)(objPoint.Bottom - (TwoHundred + OneFifty) + (LineYAxisDistance * i)));
                                objGraphics.DrawLine(new Pen(Color.Black, (float)1), pt1, pt2);
                                objGraphics.DrawString("-" + Convert.ToString(Math.Round((LineYInterval * i), 5)), objFont, objBrush, pt3);

                                pt1 = new PointF((float)(objPoint.Left + SixtyTwo), (float)(objPoint.Bottom - (TwoHundred + OneFifty) + (LineYAxisDistance * i)));//TwoHundred
                                pt2 = new PointF((float)(objPoint.Right - OneSixtyTwo), (float)(objPoint.Bottom - (TwoHundred + OneFifty) + (LineYAxisDistance * i)));//TwoHundred
                                objGraphics.DrawLine(BlkDash, pt1, pt2);


                                i++;
                                if (objPoint.X == 0 && objPoint.Y == 0 && objPoint.Width == 0 && objPoint.Height == 0)
                                {
                                    break;
                                }
                            } while ((float)(objPoint.Bottom - (TwoHundred + OneFifty) - (LineYAxisDistance * i)) >= (objPoint.Top + OneFifty));
                        }




                    }
                    catch (Exception ex)
                    {
                        
                    }
                }

            }
            catch (Exception ex)
            {
                
            }
        }
        private int n, nu;
        private Complex[] CalculateFFTComplexed(Complex[] invdata, double[] XARRAY)
        {
            Complex[] ValuetoReturn = null;            
            if (XARRAY.Length % 2 == 0)
            {
                n = XARRAY.Length;
            }
            else
            {
                n = XARRAY.Length - 1;
            }
            nu = (int)(Math.Log(n) / Math.Log(2));
            int n2 = n / 2;
            int nu1 = nu - 1;
            double[] xre = new double[n];
            double[] xim = new double[n];
            double[] mag = new double[n2];
            double tr, ti, p, arg, c, s;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    xre[i] = XARRAY[i];
                    xim[i] = 0.0f;
                }
                int k = 0;

                for (int l = 1; l <= nu; l++)
                {
                    while (k < n)
                    {
                        for (int i = 1; i <= n2; i++)
                        {
                            try
                            {
                                p = bitrev(k >> nu1);
                                arg = 2 * (double)Math.PI * p / n;
                                c = (double)Math.Cos(arg);
                                s = (double)Math.Sin(arg);
                                tr = xre[k + n2] * c + xim[k + n2] * s;
                                ti = xim[k + n2] * c - xre[k + n2] * s;
                                xre[k + n2] = xre[k] - tr;
                                xim[k + n2] = xim[k] - ti;
                                xre[k] += tr;
                                xim[k] += ti;
                                k++;
                            }
                            catch
                            {
                            }
                        }
                        k += n2;
                    }
                    k = 0;
                    nu1--;
                    n2 = n2 / 2;
                }
                k = 0;
                int r;
                while (k < n)
                {
                    r = bitrev(k);
                    if (r > k)
                    {
                        tr = xre[k];
                        ti = xim[k];
                        xre[k] = xre[r];
                        xim[k] = xim[r];
                        xre[r] = tr;
                        xim[r] = ti;
                    }
                    k++;
                }


                ValuetoReturn = new Complex[xre.Length];
                for (int i = 0; i < xre.Length; i++)
                {
                    ValuetoReturn[i].real = xre[i];
                    ValuetoReturn[i].imaginary = xim[i];
                }
            }
            catch (Exception ex)
            {             
            }
            return ValuetoReturn;
        }

        private int bitrev(int j)
        {

            int j2;
            int j1 = j;
            int k = 0;
            try
            {
                for (int i = 1; i <= nu; i++)
                {
                    j2 = j1 / 2;
                    k = 2 * k + j1 - 2 * j2;
                    j1 = j2;
                }
            }
            catch (Exception ex)
            {
                
            }
            return k;
        }

        public double[] CalculateCepstrumfromFFT(double[] fft, double[] XARRAY)
        {
            double[] ValueToReturn = null;
            try
            {
                Complex[] fftdata = new Complex[fft.Length * 2];
                for (int i = 0; i < fft.Length; i++)
                {
                    fftdata[i].real = fft[i];
                    fftdata[i].imaginary = 0;
                }
                int tempi = fft.Length - 1;
                for (int i = fft.Length; i < fftdata.Length; i++)
                {
                    fftdata[i].real = fft[tempi];
                    fftdata[i].imaginary = 0;
                    tempi--;
                }

                Complex[] magLog = new Complex[fftdata.Length];
                for (int i = 0; i < fft.Length; i++)
                {
                    if (Math.Round(fftdata[i].imaginary, 6) != 0)
                    {
                        magLog[i].imaginary = Math.Log(Math.Abs(fftdata[i].imaginary));
                    }
                    else
                    {
                        magLog[i].imaginary = 0;
                    }

                    if (Math.Round(fftdata[i].real, 6) != 0)
                    {
                        magLog[i].real = Math.Log(Math.Abs(fftdata[i].real));
                    }
                    else
                    {
                        magLog[i].real = 0;
                    }
                }

                Complex[] invdata = new Complex[magLog.Length];
                for (int i = 0; i < invdata.Length; i++)
                {
                    invdata[i].imaginary = magLog[i].real;
                    invdata[i].real = magLog[i].imaginary;
                }
                Complex[] invdataFFT = null;

                try
                {
                    invdataFFT = FFT.Calculate(invdata, false);
                }
                catch (Exception ex)
                {                    
                    invdataFFT = CalculateFFTComplexed(invdata, XARRAY);
                }
                Complex[] B = new Complex[invdataFFT.Length];
                for (int i = 0; i < invdataFFT.Length; i++)
                {
                    B[i].imaginary = invdataFFT[i].real;
                    B[i].real = invdataFFT[i].imaginary;
                }
                double[] magfftinv = new double[B.Length];
                for (int i = 0; i < B.Length; i++)
                {
                    magfftinv[i] = ((Math.Sqrt(Math.Pow(B[i].real, 2) + Math.Pow(B[i].imaginary, 2)))) / B.Length;
                }
                ValueToReturn = new double[magfftinv.Length * 2];
                for (int i = 0; i < magfftinv.Length; i++)
                {
                    ValueToReturn[i] = magfftinv[i];
                }
                tempi = magfftinv.Length - 1;


                for (int i = magfftinv.Length; i < magfftinv.Length * 2; i++)
                {
                    ValueToReturn[i] = magfftinv[tempi];
                    tempi--;
                }

            }
            catch (Exception ex)
            {

            }
            return ValueToReturn;
        }
        private double CalculateRMS(double[] _Ydata)
        {
            double SquaredSum = 0;
            double RMS = 0;
            try
            {
                for (int i = 0; i < _Ydata.Length; i++)
                {
                    SquaredSum += (double)_Ydata[i] * (double)_Ydata[i];
                }
                double Mean = SquaredSum / _Ydata.Length;
                RMS = Math.Sqrt(Mean);
            }
            catch (Exception ex)
            {
            }
            return RMS;
        }

        public double CalculateCrestFactor(double[] _Ydata)
        {
            double CrestFactor = 0;
            try
            {
                double RMS = CalculateRMS(_Ydata);
                double MaxPeak = (double)findHighestValue(_Ydata);
                CrestFactor = Math.Round((MaxPeak / RMS), 2);
            }
            catch (Exception ex)
            {
            }
            return CrestFactor;
        }


        public double[] CalculateCepstrumfromTime(double[] time, double[] XARRAY)
        {
            double[] ValueToReturn = null;
            try
            {
                Complex[] timedata = new Complex[time.Length];
                for (int i = 0; i < time.Length; i++)
                {
                    timedata[i].real = time[i];
                    timedata[i].imaginary = 0;
                }
                Complex[] data = null;
                try
                {
                    data = FFT.Calculate(timedata, false);
                }
                catch (Exception ex)
                {                    
                    data = CalculateFFTComplexed(timedata, XARRAY);
                }

                double[] magfft = new double[data.Length / 2];
                for (int i = 0; i < data.Length / 2; i++)
                {
                    magfft[i] = (2 * (Math.Sqrt(Math.Pow(data[i].real, 2) + Math.Pow(data[i].imaginary, 2)))) / data.Length;
                }
                Complex[] magLog = new Complex[data.Length];
                for (int i = 0; i < magfft.Length; i++)
                {
                    if (Math.Round(data[i].imaginary, 6) != 0)
                    {
                        magLog[i].imaginary = Math.Log(Math.Abs(data[i].imaginary));
                    }
                    else
                    {
                        magLog[i].imaginary = 0;
                    }

                    if (Math.Round(data[i].real, 6) != 0)
                    {
                        magLog[i].real = Math.Log(Math.Abs(data[i].real));
                    }
                    else
                    {
                        magLog[i].real = 0;
                    }
                }
                Complex[] invdata = new Complex[magLog.Length];
                for (int i = 0; i < invdata.Length; i++)
                {
                    invdata[i].imaginary = magLog[i].real;
                    invdata[i].real = magLog[i].imaginary;
                }
                Complex[] invdataFFT = FFT.Calculate(invdata, false);

                Complex[] B = new Complex[invdataFFT.Length];
                for (int i = 0; i < invdataFFT.Length; i++)
                {
                    B[i].imaginary = invdataFFT[i].real;
                    B[i].real = invdataFFT[i].imaginary;
                }
                double[] magfftinv = new double[B.Length];
                for (int i = 0; i < B.Length; i++)
                {
                    magfftinv[i] = ((Math.Sqrt(Math.Pow(B[i].real, 2) + Math.Pow(B[i].imaginary, 2)))) / B.Length;
                }
                ValueToReturn = magfftinv;
            }
            catch (Exception ex)
            {                
            }
            return ValueToReturn;
        }

       public string[] BandAlarmsPowerAxial = null;
       public string[] BandAlarmsPowerHorizontal = null;
       public string[] BandAlarmsPowerVerticle = null;
       public string[] BandAlarmsDemodulateAxial = null;
       public string[] BandAlarmsDemodulateHorizontal = null;
       public string[] BandAlarmsDemodulateVerticle = null;
        string[] BndAlrmsHigh = null;
        string[] BndAlrmsLow = null;
        string[] BndAlrmsFreq = null;

        public void GetBandAlarmData(string[] value)
        {            
            BndAlrmsHigh = new string[value.Length];
            BndAlrmsLow = new string[value.Length];
            BndAlrmsFreq = new string[value.Length];
            try
            {
                for (int i = 0; i < value.Length; i++)
                {
                    string[] AllValue = value[i].ToString().Split(new string[] { "!", "@" }, StringSplitOptions.RemoveEmptyEntries);
                    BndAlrmsFreq[i] = AllValue[0].ToString();
                    BndAlrmsHigh[i] = AllValue[1].ToString();
                    BndAlrmsLow[i] = AllValue[2].ToString();
                }
            }
            catch (Exception ex)
            {
            }
            
        }  
        public void ExtractBandAlarms()
        {
            string sPointID = PublicClass.SPointID;           
            BandAlarmsPowerAxial = new string[0];
            BandAlarmsPowerHorizontal = new string[0];
            BandAlarmsPowerVerticle = new string[0];
            BandAlarmsDemodulateAxial = new string[0];
            BandAlarmsDemodulateHorizontal = new string[0];
            BandAlarmsDemodulateVerticle = new string[0];

            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select bd.Freq,bd.X,bd.Y,bd.Axis_type from point pt inner join type_point tp on tp.ID=pt.PointType_ID left join bandalarm_data bdd on bdd.Bandalarmsgroup_id=tp.Band_ID left join band_data bd on bd.Group_ID=bdd.Bandalarmsgroup_id where pt.Point_ID='" + sPointID + "'");
                foreach (DataRow dr in dt.Rows)
                {

                    int AxisType = Convert.ToInt32(dr["axis_type"]);
                    switch (AxisType)
                    {
                        case 0:
                            {
                                Array.Resize(ref BandAlarmsPowerAxial, BandAlarmsPowerAxial.Length + 1);
                                BandAlarmsPowerAxial[BandAlarmsPowerAxial.Length - 1] = Convert.ToString(dr["Freq"]) + "!" + Convert.ToString(dr["X"]) + "@" + Convert.ToString(dr["Y"]);
                            }
                            break;
                        case 1:
                            {
                                Array.Resize(ref BandAlarmsPowerHorizontal, BandAlarmsPowerHorizontal.Length + 1);
                                BandAlarmsPowerHorizontal[BandAlarmsPowerHorizontal.Length - 1] = Convert.ToString(dr["Freq"]) + "!" + Convert.ToString(dr["X"]) + "@" + Convert.ToString(dr["Y"]);
                            }
                            break;
                        case 2:
                            {
                                Array.Resize(ref BandAlarmsPowerVerticle, BandAlarmsPowerVerticle.Length + 1);
                                BandAlarmsPowerVerticle[BandAlarmsPowerVerticle.Length - 1] = Convert.ToString(dr["Freq"]) + "!" + Convert.ToString(dr["X"]) + "@" + Convert.ToString(dr["Y"]);
                            }
                            break;
                        case 3:
                            {
                                Array.Resize(ref BandAlarmsDemodulateAxial, BandAlarmsDemodulateAxial.Length + 1);
                                BandAlarmsDemodulateAxial[BandAlarmsDemodulateAxial.Length - 1] = Convert.ToString(dr["Freq"]) + "!" + Convert.ToString(dr["X"]) + "@" + Convert.ToString(dr["Y"]);
                            }
                            break;
                        case 4:
                            {
                                Array.Resize(ref BandAlarmsDemodulateHorizontal, BandAlarmsDemodulateHorizontal.Length + 1);
                                BandAlarmsDemodulateHorizontal[BandAlarmsDemodulateHorizontal.Length - 1] = Convert.ToString(dr["Freq"]) + "!" + Convert.ToString(dr["X"]) + "@" + Convert.ToString(dr["Y"]);
                            }
                            break;
                        case 5:
                            {
                                Array.Resize(ref BandAlarmsDemodulateVerticle, BandAlarmsDemodulateVerticle.Length + 1);
                                BandAlarmsDemodulateVerticle[BandAlarmsDemodulateVerticle.Length - 1] = Convert.ToString(dr["Freq"]) + "!" + Convert.ToString(dr["X"]) + "@" + Convert.ToString(dr["Y"]);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        string HighAlValue = null;
        string LowAlValue = null;
        string Freq = null;
        string prevFreq = null;
        string displayed = null;
        double HighestPeakinArea = 0;
        double HighestPeakinAreaAt = 0;
        double TempPeakinArea = 0;

        public bool Datagrid3visible
        {
            set
            {
                dataGridView3.Visible = value;
                if (value == true)
                {
                    dataGridView2.Height = panel1.Height / 3;
                    dataGridView3.Height = panel1.Height / 3;
                }
                else
                {
                    dataGridView2.Height = panel1.Height / 2;
                    dataGridView3.Height = dataGridView1.Height;
                }
            }
        }

        public void DataGridSettingForBandAlarm(bool IsBandAlarm)
        {
            try
            {
                if (IsBandAlarm)
                {
                   MainForm.ClearCmbCursor();
                    ArrayList CursorItems = new ArrayList();
                    CursorItems.Add("Select Cursor");
                   MainForm. AddToCmbCursor(CursorItems);
                   string SelectedCursorItem = MainForm.cmbCurSors.Items[0].ToString();
                   MainForm.CmbCursorSelectedItem(SelectedCursorItem);

                    dataGridView1.Rows.Clear();

                    for (int i = 0; i < dataGridView1.Columns.Count; )
                    {
                        dataGridView1.Columns.RemoveAt(0);
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                {
                                    dataGridView1.Columns.Add("ColXValue", "X Value(Highest Peak)");
                                    break;
                                }
                            case 1:
                                {
                                    dataGridView1.Columns.Add("ColYValue", "Y Value(Highest Peak)");
                                    break;
                                }
                            case 2:
                                {
                                    dataGridView1.Columns.Add("ColBandHighValue", "HighValue");

                                    break;
                                }
                            case 3:
                                {
                                    dataGridView1.Columns.Add("ColBandLowerValue", "LowValue");
                                    break;
                                }
                            case 4:
                                {
                                    dataGridView1.Columns.Add("ColBandValue", "BandValue(Hz)");
                                    break;
                                }
                        }

                    }
                   
                    if (BndAlrmsFreq.Length > 0)
                    {
                        dataGridView1.Rows.Add(BndAlrmsFreq.Length);

                        for (int i = 0; i < BndAlrmsFreq.Length; i++)
                        {
                            ArrayList BandValuetoDisplay = new ArrayList();
                            Freq = BndAlrmsFreq[i].ToString();
                            if (MainForm.CurrentXLabel.ToString().Contains("CPM"))
                            {
                                Freq = (Convert.ToDouble(Freq) * 60).ToString();
                            }
                            HighAlValue = BndAlrmsHigh[i].ToString();
                            LowAlValue = BndAlrmsLow[i].ToString();
                            if (i == 0)
                            {
                                prevFreq = "0";
                            }
                            else
                            {
                                prevFreq = BndAlrmsFreq[i - 1].ToString();
                                if (MainForm.CurrentXLabel.ToString().Contains("CPM"))
                                {
                                    prevFreq = (Convert.ToDouble(prevFreq) * 60).ToString();
                                }
                            }
                            TempPeakinArea = 0;
                            HighestPeakinArea = 0;
                            HighestPeakinAreaAt = 0;

                            for (int j = 0; j <MainForm.yarrayNew.Length; j++)
                            {
                                if (Convert.ToDouble(MainForm.xarrayNew[j]) >= Convert.ToDouble(prevFreq))
                                {
                                    if (Convert.ToDouble(MainForm.xarrayNew[j]) <= Convert.ToDouble(Freq) && Convert.ToDouble(MainForm.xarrayNew[j]) <= Convert.ToDouble(MainForm.xarrayNew[MainForm.xarrayNew.Length - 2]))
                                    {
                                        if (Convert.ToDouble(MainForm.yarrayNew[j]) > Convert.ToDouble(LowAlValue))
                                        {


                                            TempPeakinArea = Convert.ToDouble(MainForm.yarrayNew[j]);
                                            if (j < MainForm.yarrayNew.Length - 1)
                                                if (TempPeakinArea > Convert.ToDouble(MainForm.yarrayNew[j - 1]) && TempPeakinArea > Convert.ToDouble(MainForm.yarrayNew[j + 1]))

                                                    if (TempPeakinArea > HighestPeakinArea)
                                                    {
                                                        HighestPeakinArea = TempPeakinArea;
                                                        HighestPeakinAreaAt = Convert.ToDouble(MainForm.xarrayNew[j]);
                                                    }

                                            if (i == 0)
                                            {
                                                prevFreq = "0";
                                            }
                                            else
                                            {
                                                prevFreq = BndAlrmsFreq[i - 1].ToString();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (HighestPeakinAreaAt != 0.0)
                                        {
                                            BandValuetoDisplay.Add(HighestPeakinAreaAt.ToString() + "//" + HighestPeakinArea.ToString());
                                        }
                                        break;
                                    }
                                }
                            }
                            if (BandValuetoDisplay.Count > 0)
                            {
                                string[] bandxy = BandValuetoDisplay[0].ToString().Split(new string[] { "//" }, StringSplitOptions.RemoveEmptyEntries);

                                dataGridView1.Rows[i].Cells[0].Value = bandxy[0];
                                dataGridView1.Rows[i].Cells[1].Value = bandxy[1];
                            }
                            dataGridView1.Rows[i].Cells[2].Value = BndAlrmsHigh[i].ToString();
                            dataGridView1.Rows[i].Cells[3].Value = BndAlrmsLow[i].ToString();
                            dataGridView1.Rows[i].Cells[4].Value = BndAlrmsFreq[i].ToString();
                        }
                    }
                }
                else
                {
                    dataGridView1.Rows.Clear();
                    bool IsTimeGraph =MainForm.CheckForTimeData(MainForm.yarrayNew);
                    if (IsTimeGraph)
                    {
                        MainForm.setCursorCombo("Time");
                    }
                    else
                    {
                       MainForm. setCursorCombo("FFT");
                    }
                    SetDatagridtoOriginal();
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void SetDatagridtoOriginal()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Columns.Count; )
                {
                    dataGridView1.Columns.RemoveAt(0);
                }
                for (int i = 0; i < 2; i++)
                {
                    switch (i)
                    {
                        case 0:
                            {
                                dataGridView1.Columns.Add("ColXValue", "X Value");
                                break;
                            }
                        case 1:
                            {
                                dataGridView1.Columns.Add("ColYValue", "Y Value");
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        int iclick = 0;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int aa = e.RowIndex;
                if (MainForm.wavnode != null)
                {
                    MainForm.wavdatagridcontent(aa);
                }
                else
                { MainForm.datagridcontent(aa); }
            }
            catch { }
        }
               
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int RowIndex = e.RowIndex;
                if (RowIndex < dataGridView1.Rows.Count-1)
                {
                    MainForm.SelectedRowIndex = RowIndex;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}