using BitEdLib.Model.Logic;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.ViewModel.Node
{
    public class BehaviourTypeViewModel:ViewModelBase
    {
        public Behaviour model;
        public string Name {get; private set;}
        public BehaviourTypeViewModel(Behaviour model)
        {
            this.model = model;
            Name = model.NodeName;
        }
    }
}
