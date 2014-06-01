using BitEdLib.Model.Logic.Behaviours.Triggers;
using BitEdLib.Model.Node;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Model.Logic
{
    public abstract class Behaviour : INode
    {
        //public static const ReadOnlyCollection<Behaviour> AvailableBehavoirs = new ReadOnlyCollection<Behaviour>(new Behaviour[]{
        //    new InitializeTrigger()
        //});
        private List<INodePropertry> properties;
        private ObservableCollection<INode> connections;
        public IEnumerable<INodePropertry> Properties
        {
            get { return properties;}
        }

        public IEnumerable<INode> ConnectedNodes
        {
            get
            {
                return connections;
            }
            set
            {
                connections = value as ObservableCollection<INode>;
            }
        }

        public string NodeName { get; protected set; }

        public abstract ENodeType NodeType { get; }
        public Behaviour()
        {
            properties = new List<INodePropertry>();
        }
    }
}
