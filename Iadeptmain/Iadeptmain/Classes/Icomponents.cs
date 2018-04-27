using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Iadeptmain.Classes
{
    interface Icomponents
    {
        
        ArrayList AddComponentsForButton(string Name);

        void SetSubClasscombobox(DevComponents.DotNetBar.ButtonX _button);

        void SetSensorsetting(string SensorDirection);

        Mainforms.frmmachine _MainForm
        {
            set;
        }


        
    }
}
