using BitEdTool.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.AvalonDock.Layout;

namespace BitEdTool.ViewStyle
{
    class LayoutInitializer:ILayoutUpdateStrategy
    {
        /// <summary>
        /// As we do not know what type anchorable we are dealing with simply by type.. (and it seems we do not have access to viewmodel) we create a mapping of title to paneName
        /// </summary>
        public void AfterInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableShown)
        {
        }

        public void AfterInsertDocument(LayoutRoot layout, LayoutDocument anchorableShown)
        {
        }

        public bool BeforeInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableToShow, ILayoutContainer destinationContainer)
        {
            //AD wants to add the anchorable into destinationContainer
            //just for test provide a new anchorablepane 
            //if the pane is floating let the manager go ahead
            LayoutAnchorablePane destPane = destinationContainer as LayoutAnchorablePane;
            if (destinationContainer != null &&
                destinationContainer.FindParent<LayoutFloatingWindow>() != null)
            {
                return false;
            }
            //is content null, so dont bother continue?
            if(anchorableToShow.Content==null)
            {
                return false;
            }

            ToolViewModel anchorableToolViewModel = anchorableToShow.Content as ToolViewModel;
            if (anchorableToolViewModel != null)
            {
                var toolsPane = layout.Descendents().OfType<LayoutAnchorablePane>().FirstOrDefault(d => d.Name == anchorableToolViewModel.StartPaneAreaName);
                if (toolsPane != null)
                {
                    toolsPane.Children.Add(anchorableToShow);
                    return true;
                }
            }
            return false;
        }

        public bool BeforeInsertDocument(LayoutRoot layout, LayoutDocument anchorableToShow, ILayoutContainer destinationContainer)
        {
            return false;
        }
    }
}
