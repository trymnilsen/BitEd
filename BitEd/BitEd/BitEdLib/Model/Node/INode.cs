using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Model.Node
{
    interface INode
    {
        IEnumerable<INodePropertry> Properties { get; set; }
        IEnumerable<INode> Parents { get; set; }
        IEnumerable<INode> Children { get; set; }
        string NodeName { get; }
        //void RecivedInput(INodePropertry nodeSource, object result);
        //void DispatchOutput();
    }
}
