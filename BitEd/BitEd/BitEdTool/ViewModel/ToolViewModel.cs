using BitEdLib.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.ViewModel
{
    public class ToolViewModel:PaneViewModel
    {
        public string StartPaneAreaName { get; set; }
        public Application App { get; private set; }
        public ToolViewModel(Application app, string name, string paneName)
        {
            this.App = app;
            this.Title = name;
            this.StartPaneAreaName = paneName;
        }
    }
}
