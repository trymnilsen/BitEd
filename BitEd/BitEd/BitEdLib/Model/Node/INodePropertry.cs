using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Model.Node
{
    interface INodePropertry
    {
        ENodeBindType BindType { get; set; }
        Type PropertyType { get; }
        object Value { get; set; }
    }
}
