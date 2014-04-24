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
        public ToolViewModel(string name, string paneName)
        {
            this.Title = name;
            this.StartPaneAreaName = paneName;
        }
    }
}
