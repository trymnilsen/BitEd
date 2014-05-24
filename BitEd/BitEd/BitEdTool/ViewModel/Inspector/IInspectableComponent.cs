using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.ViewModel.Inspector
{
    public interface IInspectableComponent
    {
        string ComponentName { get; set; }
        bool ComponentActive { get; set; }
        IEnumerable<IInspectableComponentProperty> ComponentProperties { get; set; }
    }
}
