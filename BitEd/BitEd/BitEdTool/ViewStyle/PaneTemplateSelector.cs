using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock.Layout;

namespace BitEdTool.ViewStyle
{
    public class PaneTemplateSelector : DataTemplateSelector
    {
        private List<PaneTemplate> _paneDocuments = new List<PaneTemplate>(); 
        public DataTemplate DocumentTemplate { get; set; }
        public List<PaneTemplate> PaneTemplates
        {
            get
            {
                return _paneDocuments;
            }
            set
            {
                _paneDocuments = value;
            }
        }

        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if(PaneTemplates.Exists(x=>x.Type==item.GetType()))
            {
                return PaneTemplates.Find(x => x.Type == item.GetType()).Template;
            }
            return base.SelectTemplate(item, container);
        }
    }
    public class PaneTemplate
    {
        public DataTemplate Template {get; set;}
        public Type Type {get; set;}

    }
}
