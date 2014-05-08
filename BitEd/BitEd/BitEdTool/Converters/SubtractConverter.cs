using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BitEdTool.Converters
{
    /// <summary>
    /// Subtracts the param from the binding
    /// </summary>
    public class SubtractConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Double && parameter is String)
            {
                Double currentValue = System.Convert.ToDouble(value);
                //Paramter is treated as a string, parse it
                Double subtraction = Double.Parse(parameter as String);
                return currentValue - subtraction;
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
