using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Model.Node
{
    public interface INode
    {
        IEnumerable<INodePropertry> Properties { get; }
        IEnumerable<INode> ConnectedNodes { get; set; }
        string NodeName { get; }
        ENodeType NodeType{ get; }
        //void RecivedInput(INodePropertry nodeSource, object result);
        //void DispatchOutput();
    }
}
