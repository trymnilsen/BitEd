using BitEdLib.Model.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Model.Logic.Behaviours.Triggers
{
    public abstract class TriggerBehaviour:Behaviour
    {
        public override ENodeType NodeType
        {
            get { return ENodeType.Trigger; }
        }
        public TriggerBehaviour()
        {
            
        }
    }
}
