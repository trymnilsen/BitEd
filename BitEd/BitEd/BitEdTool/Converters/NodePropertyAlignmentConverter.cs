using BitEdLib.Model.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace BitEdTool.Converters
{
    public class NodePropertyAlignmentConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(value is ENodeBindType)
            {
                if(value.Equals(ENodeBindType.Input))
                {
                    return HorizontalAlignment.Left;
                }
                else if(value.Equals(ENodeBindType.Output))
                {
                    return HorizontalAlignment.Right;
                }
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
