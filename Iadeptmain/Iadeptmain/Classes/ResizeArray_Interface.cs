using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iadeptmain.Classes
{
    interface ResizeArray_Interface
    {
        void IncreaseArrayString(ref string[] values, int increment);
        void IncreaseArrayInt(ref int[] values, int increment);
        void IncreaseArrayByte(ref byte[] values, int increment);
        void IncreaseArrayDouble(ref double[] values, int increment);
        void IncreaseArrayFloat(ref float[] values, int increment);
        void IncreaseArrayLong(ref long[] values, int increment);

    }
}
