using BitEdLib.Model.Logic;
using BitEdLib.Model.Node;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Model.Assets
{
    public class AssetObject:BaseAsset,INode
    {
        public ObservableCollection<Event> Events { get; set; }
        public IEnumerable<INodePropertry> Properties
        {
            get
            {
                return Events;
            }
            set
            {
                this.Events = value as ObservableCollection<Event>;
            }
        }

        public IEnumerable<INode> Parents
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<INode> Children
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string NodeName
        {
            get { return this.Name; }
        }

        public AssetObject()
        {
            Events = new ObservableCollection<Event>();
            Events.Add(new Event("Draw", "DeltaTime"));
            Events.Add(new Event("Create", "Void"));
            Events.Add(new Event("Update", "Void"));
        }
    }
}
