using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Iadeptmain.Mainforms;

namespace Iadeptmain.Classes
{
    class buttonComponents : Icomponents
    {
        string[] SubClassMotor = { "AC", "AC, Induction", "AC, Induction-Fan", "AC, Induction, Polyphase", "AC, Induction, Polyphase, Squirrel Cage", "AC, Induction, Polyphase, Wound Rotor", "AC, Induction, Single Phase", "AC, Induction, Single Phase, Shaded Pole", "AC, Induction, Single Phase, Split Phase", "AC, Induction, Single Phase, Capacitor", "AC, Multispeed", "AC, Synchronous", "DC", "DC,Brushed", "DC,Brushed, Shunt Wound", "DC,Brushed, Series Wound", "DC,Brushed, Compound Wound", "DC,Brushed, Universal", "DC,Brushless", "DC,Brushless, Stepper", "DC, Conventional", "DC, Gearhead", "Linear", "Other" };
        string[] SubClassPump = { "Axial", "Axial, Single-stage", "Axial, Single-stage, Diffuser", "Axial, Single-stage, Volute", "Axial, Multistage", "Axial, Multistage, Diffuser", "Axial, Multistage, Volute", "Canned", "Centrifugal", "Centrifugal, Single-stage", "Centrifugal, Single-stage, Diffuser", "Centrifugal, Single-stage, Volute", "Centrifugal, Multistage", "Centrifugal, Multistage, Diffuser", "Centrifugal, Multistage, Volute", "Displacement", "Displacement, Reciprocating", "Displacement, Reciprocating, Piston", "Displacement, Reciprocating, Piston, Power", "Displacement, Reciprocating, Piston, Direct-acting", "Displacement, Rotory", "Displacement, Rotory, Circumferential Piston", "Displacement, Rotory, Flexible Member", "Displacement, Rotory, Flexible Member, Liner", "Displacement, Rotory, Flexible Member, Tube", "Displacement, Rotory, Flexible Member, Vane", "Displacement, Rotory, Gear", "Displacement, Rotory, Lobe", "Displacement, Rotory, Lobe, Single", "Displacement, Rotory, Lobe, Multiple", "Displacement, Rotory, Piston/Plunger", "Displacement, Rotory, Piston/Plunger, Axial", "Displacement, Rotory, Piston/Plunger, Radial", "Displacement, Rotory, Screw", "Displacement, Rotory, Vane", "Gear", "Mixed-Flow", "Mixed-Flow, Single-stage", "Mixed-Flow, Single-stage, Diffuser", "Mixed-Flow, Single-stage, Volute", "Mixed-Flow, Multistage", "Mixed-Flow, Multistage, Diffuser", "Mixed-Flow, Multistage, Volute", "Moyono", "Peristaltic", "Other" };
        string[] SubClassFan = { "Axial", "Axial, Multi-stage", "Axial, Single-stage", "Centrifugal", "Centrifugal, Air-solid", "Centrifugal, Overhung", "Centrifugal, Squirrel-cage", "Overhung", "Rotary", "Suspended", "Other" };
        string[] SubClassGearset = { "Bull-Pinion", "Inline", "Planetary", "Worm", "Other" };
        string[] SubClassBlank = { " " };

        Mainforms.frmmachine mainform = null;
        public Mainforms.frmmachine _MainForm
        {
            set
            {
                mainform = value;
            }
        }



        public ArrayList AddComponentsForButton(string ItemName)
        {
            Form_MotorDes Desc = new Form_MotorDes(ItemName);
            Desc.ShowDialog();
            ArrayList arlsttoreturn = null;
            if (Desc._AddItem)
            {
                arlsttoreturn = new ArrayList();
                arlsttoreturn.Add(Desc.ButtonName);
                arlsttoreturn.Add(Desc.SerialNo);
                arlsttoreturn.Add(Desc.Make);
                arlsttoreturn.Add(Desc.RPM);
                arlsttoreturn.Add(Desc.SensorType);
                arlsttoreturn.Add(Desc.SensorUnit);
                arlsttoreturn.Add(Desc.SensorDir);
                arlsttoreturn.Add(Desc.SensitivityX);
                arlsttoreturn.Add(Desc.SensitivityY);
                arlsttoreturn.Add(Desc.SensitivityZ);
                arlsttoreturn.Add(Desc.CBAxial);
                arlsttoreturn.Add(Desc.CBHor);
                arlsttoreturn.Add(Desc.CBVer);
                arlsttoreturn.Add(Desc.SenVal);
                arlsttoreturn.Add(Desc.SensorID);
            }
            return arlsttoreturn;
        }

        public void SetSubClasscombobox(DevComponents.DotNetBar.ButtonX _button)
        {            
        }
        
        public void SetSensorsetting(string SensorDirection)
        {
            if (SensorDirection == "uniaxial")
            {
            }
            else
            {

            }
        }
    }
}
