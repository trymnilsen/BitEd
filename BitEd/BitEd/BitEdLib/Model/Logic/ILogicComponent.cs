using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Model.Logic
{
    public interface ILogicComponent
    {
        string Name { get; set; }
        Dictionary<string, object> GetProperties { get; set; }
    }
}
