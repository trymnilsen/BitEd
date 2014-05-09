using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Util
{
    public static class BitEdMath
    {
        /// <summary>
        /// Remaps a value within range one to range 2
        /// </summary>
        /// <param name="value">The value to remap</param>
        /// <param name="from1">Original Range start</param>
        /// <param name="to1">Original Range End</param>
        /// <param name="from2">New Range start</param>
        /// <param name="to2">New Range End</param>
        /// <returns>The remapped value</returns>
        public static double Remap(double value, double from1, double to1, double from2, double to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }
    }
}
