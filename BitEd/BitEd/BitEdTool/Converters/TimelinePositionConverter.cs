﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BitEdTool.Converters
{
    public class TimelinePositionConverter:IMultiValueConverter
    {
        /*
         * Value[0] - Frame (frame number to convert into cordinate)
         * Value[1] - Timeline scale
         * Value[2] - Timeline scroll/offset
         * Value[3] - Timeline width
         * */
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            foreach(object obj in values)
            {
                Debug.WriteLine("###Obj" + obj.GetType());
            }
            return values[0];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
