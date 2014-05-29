using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitEdLib.Model.Node;

namespace BitEdTool.ViewModel.Inspector
{
    public interface IInspectableComponent
    {
        string ComponentName { get; }
        bool ComponentActive { get; set; }
        IEnumerable<INodePropertry> ComponentProperties { get; }
    }
}
