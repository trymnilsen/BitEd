using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Model.Entity
{
    class EntityObject
    {
        public List<EntityInstance> instances;
        public bool IsInstantiated
        {
            get { return instances.Count > 0; }
        }
    }
}
