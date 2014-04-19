using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdToolRender.Utils
{
    internal static class DataStripper
    {
        internal static float[] Vector3ToFloatArray(Vector3[] data)
        {
            float[] returnValues = new float[data.Length];
            for(int i=0, len=data.Length; i<len; ++i)
            {
                returnValues[i] = data[i].X;
                returnValues[i+1] = data[i].Y;
                returnValues[i + 2] = data[i].Z;
            }
            return returnValues;
        }
    }
}
