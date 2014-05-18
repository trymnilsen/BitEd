using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitEdLib.Model.Node;

namespace BitEdLib.Model.Logic
{
    public class Event : INodePropertry
    {
        private string eventName;
        private string propertyType;
        private ENodeBindType bindType;

        public ENodeBindType BindType
        {
            get { return bindType; }
        }

       public string PropertyType
        {
            get { return propertyType; }
        }

        public string PropertyName
        {
            get { return eventName; }
        }
        
        public Event(string eventName, string propertyType)
        {
            this.eventName = eventName;
            this.propertyType = propertyType;
            this.bindType = ENodeBindType.Output;
        }
    }
}
