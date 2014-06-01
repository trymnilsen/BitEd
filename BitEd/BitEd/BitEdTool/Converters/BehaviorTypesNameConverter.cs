using BitEdLib.Model.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BitEdTool.Converters
{
    class BehaviourTypesNameConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var list = value as IEnumerable<Behaviour>;
            if (list == null) return Binding.DoNothing;
            return list.Select(x => x.NodeType).Distinct();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
