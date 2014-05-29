using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Model.Logic.Components
{
    public class PropertiesComponent : ILogicComponent
    {
        public string Name
        {
            get
            {
                return "Properties";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Dictionary<string, object> GetProperties
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
    }
}
