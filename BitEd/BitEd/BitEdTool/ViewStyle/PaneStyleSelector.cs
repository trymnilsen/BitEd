using BitEdTool.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BitEdTool.ViewStyle
{
    public class PanesStyleSelector : StyleSelector
    {
        public Style ToolStyle
        {
            get;
            set;
        }

        public Style FileStyle
        {
            get;
            set;
        }

        public override System.Windows.Style SelectStyle(object item, System.Windows.DependencyObject container)
        {
            if (item is ScreenViewModel)
            {
                Debug.WriteLine("Screen name: " + (item as ScreenViewModel).model.Name);
                return FileStyle;
            }
            if(item is ToolViewModel)
            {
                return ToolStyle;
            }
            else if(item!=null)
            {
                Debug.WriteLine("Type was:" + item.GetType().ToString());
            }

            return base.SelectStyle(item, container);
        }
    }
}
