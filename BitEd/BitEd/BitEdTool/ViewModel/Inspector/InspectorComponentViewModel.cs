using BitEdLib.Model.Node;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitEdLib.Model.Logic;

namespace BitEdTool.ViewModel.Inspector
{
    public class InspectorComponentViewModel:ViewModelBase, IInspectableComponent
    {
        private string name;
        private bool active;
        private ILogicComponent model;
        private List<INodePropertry> properties;

        public string ComponentName
        {
            get
            {
                return model.Name;
            }
            set
            {
                if (value == model.Name) 
                    return;

                model.Name = value;
                RaisePropertyChanged("ComponentName");
            }
        }

        public bool ComponentActive
        {
            get
            {
                return active;
            }
            set
            {
                if(value!=active)
                {
                    active = value;
                    RaisePropertyChanged("ComponentActive");
                }
            }
        }

        public IEnumerable<INodePropertry> ComponentProperties
        {
            get {return properties;}
        }

        public ILogicComponent Model
        {
            get { return model; }
        }

        public InspectorComponentViewModel(ILogicComponent model)
        {
            properties = new List<INodePropertry>();
            this.model = model;
        }
    }
}
