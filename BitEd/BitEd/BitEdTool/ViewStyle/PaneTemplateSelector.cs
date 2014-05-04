using BitEdTool.ViewModel;
using BitEdTool.ViewModel.Asset;
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
        private PaneTemplateCollection _toolTemplates = new PaneTemplateCollection();
        private PaneTemplateCollection _paneDocumentPanes = new PaneTemplateCollection();
        public PaneTemplateCollection PaneToolTemplates
        {
            get
            {
                return _toolTemplates;
            }
            set
            {
                _toolTemplates = value;
            }
        }

        public PaneTemplateCollection PaneDocumentTemplates
        {
            get
            {
                return _paneDocumentPanes;
            }
            set
            {
                _paneDocumentPanes = value;
            }
        }
       

        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            //If the item is a document we want to check the type of its model
            if(item is DocumentViewModel)
            {
                AssetListEntryViewModel vm = item as AssetListEntryViewModel;
                if(PaneDocumentTemplates.Exists(x=> x.Type == vm.Model.GetType()))
                {
                    return PaneDocumentTemplates.Find(x => x.Type == vm.Model.GetType()).Template;
                }
            }
            //if it is not lets select depending on it viewmodel/item
            else if(PaneToolTemplates.Exists(x => x.Type == item.GetType()))
            {
                return PaneToolTemplates.Find(x => x.Type == item.GetType()).Template;
            }
            return base.SelectTemplate(item, container);
        }
    }
    public class PaneTemplateCollection : List<PaneTemplate> { }
    public class PaneTemplate
    {
        public DataTemplate Template {get; set;}
        public Type Type {get; set;}

    }
}
