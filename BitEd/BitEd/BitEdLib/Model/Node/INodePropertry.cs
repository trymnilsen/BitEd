using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Model.Node
{
    public interface INodePropertry
    {
        ENodeBindType BindType { get; }
        //Enables ut to get type without having to call getType on value
        string PropertyType { get; }
        string PropertyName { get; }
    }
}
