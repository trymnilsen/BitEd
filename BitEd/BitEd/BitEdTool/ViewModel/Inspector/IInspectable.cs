using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.ViewModel.Inspector
{
    public interface IInspectable
    {
        string InspectableName { get; set; }
        string InspectableTag { get; set; }
        bool InspectorCanSetName { get; }
        bool InspectorCanSetTag { get; }
        IEnumerable<IInspectableComponent> InspectableComponents { get; set; }
    }
}
