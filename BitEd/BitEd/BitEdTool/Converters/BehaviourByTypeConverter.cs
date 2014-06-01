using BitEdLib.Model.Logic;
using BitEdLib.Model.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BitEdTool.Converters
{
    class BehaviourByTypeConverter:IMultiValueConverter
    {
        //Returns a sub-collection of the given collection index 0, consiting of behaviours with nodeType index 1 
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //Check conformity
            if(values.Length!=2) 
                return Binding.DoNothing;
            //Set values
            var list = values[0] as IEnumerable<Behaviour>;
            var behaviourType = (ENodeType)values[1];
            //Check for casting errors
            if (list == null) 
                return Binding.DoNothing;
            //Return
            return list.Where(x => x.NodeType == behaviourType);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
