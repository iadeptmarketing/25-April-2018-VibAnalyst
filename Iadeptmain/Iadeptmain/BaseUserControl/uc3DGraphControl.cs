using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Iadeptmain.BaseUserControl;
using Iadeptmain.Mainforms;
using com.iAM.chart3dnet;

namespace Iadeptmain.BaseUserControl
{
    public partial class uc3DGraphControl : ChartView
    {

        SimpleDataset3D m_objFirstDataSet = null;
        SimpleDataset3D m_objSecondDataSet = null;
        SimpleDataset3D m_objThirdDataSet = null;
        SimpleDataset3D m_objFourthDataSet = null;
        SimpleDataset3D[] m_objDataSetArray = null;
        private frmValues m_objValuesWindow = null;
        C3DGraph m_obj3DGraph = null;
        string m_sUnits = null;
        private int m_iWaterFallCounter = 0;
        public delegate void GraphClickedHandler(MouseEventArgs e);
        public event GraphClickedHandler GraphClicked;
        private string m_sDataBaseName = null;
        private frmIAdeptMain m_objMainForm = null;
        private IadeptUserControl m_objMainControl = null;
        private frmgraphcontrol m_objBaseControl=null;
        public delegate void MouseMoveHandler(MouseEventArgs e);
        public event MouseMoveHandler ThisMouseMove;
        
        public int WaterFallCounter
        {
            set
            {
                m_iWaterFallCounter = value;
                if (m_obj3DGraph != null)
                    m_obj3DGraph.WaterFallCounter = value;
            }
        }

        public string DataBaseName
        {
            set
            {
                m_sDataBaseName = value;

            }
        }

        public frmValues ValuesWindow
        {
            set
            {
                m_objValuesWindow = value;
                if (m_obj3DGraph != null)
                {
                    m_obj3DGraph.ValuesWindow = m_objValuesWindow;
                }

            }
        }

        
        public frmIAdeptMain BaseMainForm
        {
            set
            {
                m_objMainForm = value;
                if (m_objMainForm != null && m_obj3DGraph != null)
                {
                    m_obj3DGraph.BaseMainForm = m_objMainForm;
                }
                    
            }
        }

        public frmgraphcontrol BaseControl
        {
            set
            {
                m_objBaseControl = value;
                if (m_obj3DGraph != null)
                {
                    m_obj3DGraph.BaseParentControl = m_objBaseControl;
                }

            }
        }

        public uc3DGraphControl()
        {
            InitializeComponent();
            m_obj3DGraph = new C3DGraph();
            lblNewValues.Text = "Values:";

        }

        public IadeptUserControl uc3dGraph
        {
            get { return m_objMainControl;}
            set { m_objMainControl = value; }
        }

        internal void SetLabelText(string sValue)
        {
            try
            {
                lblNewValues.Text = sValue;

            }
            catch (Exception ex)
            {
                
            }
        }

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
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {


            try
            {
                if (GraphClicked != null)
                {
                    base.OnMouseClick(e);
                    GraphClicked(e);

                }
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
                if (m_obj3DGraph != null)
                {
                    m_obj3DGraph.SetDataCursor();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }



        public void InitializeChart(ArrayList arlstValues, ArrayList arlstDateTime, ArrayList arlstCounter)
        {
            int iCount=0;

            try
            {
                iCount = arlstValues.Count;



                switch (iCount)
                {
                    case 1:

                        double[][] dFirstPlotArray = (double[][])arlstValues[0];
                        m_objFirstDataSet = new SimpleDataset3D("First", dFirstPlotArray[0], dFirstPlotArray[1], 0);
                        m_objFirstDataSet.CompressSimpleDataset3D(ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, ChartObj.DATACOMPRESS_MAX, 1, 0, 2060, "First");

                        m_objDataSetArray = new SimpleDataset3D[1];
                        m_objDataSetArray[0] = m_objFirstDataSet;
                        m_obj3DGraph.ThreeDGraphControl = this;
                        m_obj3DGraph.Dates = arlstDateTime;
                        m_obj3DGraph.CommonFunctionality(m_objDataSetArray);
                       

                        break;
                    case 2:

                        
                        double[][] dFPlotArry = (double[][])arlstValues[0];
                        double[][] dSPlotArry = (double[][])arlstValues[1];
                        m_objFirstDataSet = new SimpleDataset3D("First", dFPlotArry[0], dFPlotArry[1], 0.002);
                        m_objSecondDataSet=new SimpleDataset3D("Second",dSPlotArry[0],dSPlotArry[1],0);
                        
                        m_objDataSetArray = new SimpleDataset3D[2];
                        
                        m_objDataSetArray[0] = m_objFirstDataSet;
                        m_objDataSetArray[1] = m_objSecondDataSet;
                        m_obj3DGraph.ThreeDGraphControl = this;
                        m_obj3DGraph.Dates = arlstDateTime;
                        m_obj3DGraph.CommonFunctionality(m_objDataSetArray);
    

                        break;
                    case 3:

                        double[][] dFNewPlotArry = (double[][])arlstValues[0];
                        double[][] dSNewPlotArry = (double[][])arlstValues[1];
                        double[][] dTNewPlotArry = (double[][])arlstValues[2];

                        m_objFirstDataSet = new SimpleDataset3D("First", dFNewPlotArry[0], dFNewPlotArry[1], 0.0045);
                        m_objSecondDataSet = new SimpleDataset3D("Second", dSNewPlotArry[0], dSNewPlotArry[1], 0.0025);
                        m_objThirdDataSet = new SimpleDataset3D("Third", dTNewPlotArry[0], dTNewPlotArry[1], 0);

                        m_objDataSetArray = new SimpleDataset3D[3];

                        m_objDataSetArray[0] = m_objFirstDataSet;
                        m_objDataSetArray[1] = m_objSecondDataSet;
                        m_objDataSetArray[2] = m_objThirdDataSet;
                        m_obj3DGraph.ThreeDGraphControl = this;
                        m_obj3DGraph.Dates = arlstDateTime;
                        m_obj3DGraph.CommonFunctionality(m_objDataSetArray);


                        break;
                    case 4:

                        double[][] dFFirstPlotArry = (double[][])arlstValues[0];
                        double[][] dFSecondPlotArry = (double[][])arlstValues[1];
                        double[][] dFThirdPlotArry = (double[][])arlstValues[2];
                        double[][] dFFourthPlotArry = (double[][])arlstValues[3];

                        m_objFirstDataSet = new SimpleDataset3D("First", dFFirstPlotArry[0], dFFirstPlotArry[1], 0.0075);
                        m_objSecondDataSet = new SimpleDataset3D("Second", dFSecondPlotArry[0], dFSecondPlotArry[1], 0.0045);
                        m_objThirdDataSet = new SimpleDataset3D("Third", dFThirdPlotArry[0], dFThirdPlotArry[1], 0.002);
                        m_objFourthDataSet = new SimpleDataset3D("Fourth", dFFourthPlotArry[0], dFFourthPlotArry[1], 0);


                        m_objDataSetArray = new SimpleDataset3D[4];

                        m_objDataSetArray[0] = m_objFirstDataSet;
                        m_objDataSetArray[1] = m_objSecondDataSet;
                        m_objDataSetArray[2] = m_objThirdDataSet;
                        m_objDataSetArray[3] = m_objFourthDataSet;
                        m_obj3DGraph.ThreeDGraphControl = this;
                        m_obj3DGraph.Dates = arlstDateTime;
                        m_obj3DGraph.CommonFunctionality(m_objDataSetArray);

                        break;
                }
            }
            catch
            {
                throw;
            }
        }


    
#region IChart Members


public void  RemoveChartObjects(int iItems)
{
 	try
    {
        m_obj3DGraph.RemoveChartObjects(iItems);
    }
    catch
    {
        throw;
    }
}

public string  Units
{
    get 
	{
        return m_sUnits;
	}
	  set 
	{
        m_sUnits = value;
        if (m_obj3DGraph != null)
            m_obj3DGraph.Units = value;
	}
}

public string  TimeAxisValue
{
	set
    {
        if (m_obj3DGraph != null)
            m_obj3DGraph.TimeAxisValue = value;

    }
}

#endregion

private void lblNewValues_Click(object sender, EventArgs e)
{

}
}
}
