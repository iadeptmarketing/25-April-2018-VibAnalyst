using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iadeptmain.Classes
{
    class ResizeArray_Control : ResizeArray_Interface
    {
        #region ResizeArray_Interface Members

        public void IncreaseArrayString(ref string[] values, int increment)
        {
            string[] array = new string[values.Length + increment];

            values.CopyTo(array, 0);

            values = array;

        }

        public void IncreaseArrayInt(ref int[] values, int increment)
        {
            int[] array = new int[values.Length + increment];

            values.CopyTo(array, 0);

            values = array;
        }

        public void IncreaseArrayByte(ref byte[] values, int increment)
        {
            byte[] array = new byte[values.Length + increment];

            values.CopyTo(array, 0);

            values = array;
        }

        public void IncreaseArrayDouble(ref double[] values, int increment)
        {
            double[] array = new double[values.Length + increment];

            values.CopyTo(array, 0);

            values = array;
        }


        public void IncreaseArrayFloat(ref float[] values, int increment)
        {
            float[] array = new float[values.Length + increment];

            values.CopyTo(array, 0);

            values = array;
        }



        public void IncreaseArrayLong(ref long[] values, int increment)
        {
            long[] array = new long[values.Length + increment];

            values.CopyTo(array, 0);

            values = array;
        }

        #endregion


    }
}
