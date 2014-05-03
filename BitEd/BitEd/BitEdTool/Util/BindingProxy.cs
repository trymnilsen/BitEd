using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BitEdTool.Util
{
    class BindingProxy : Freezable
    {
        public static readonly DependencyProperty DataProxyProperty = DependencyProperty.Register("ProxyData", typeof(object), typeof(BindingProxy), new UIPropertyMetadata());
        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }
        public object ProxyData
        {
            get
            {
                return GetValue(DataProxyProperty);
            }
            set
            {
                if (value != GetValue(DataProxyProperty))
                {
                    SetValue(DataProxyProperty, value);
                }
            }
        }
    }
}
