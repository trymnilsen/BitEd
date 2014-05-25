using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.ViewModel.Inspector
{
    public class InspectorComponentViewModel:ViewModelBase, IInspectableComponent
    {
        private string name;
        private bool active;
        private ObservableCollection<IInspectableComponentProperty> properties;

        public string ComponentName
        {
            get
            {
                return name;
            }
            set
            {
                if(value!=name)
                {
                    name = value;
                    RaisePropertyChanged("ComponentName");
                }
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

        public IEnumerable<IInspectableComponentProperty> ComponentProperties
        {
            get
            {
                return properties;
            }
            set
            {
                if(properties!=value)
                {
                    ObservableCollection<IInspectableComponentProperty> list = value as ObservableCollection<IInspectableComponentProperty>;
                    if (list != null)
                    {
                        properties = (ObservableCollection<IInspectableComponentProperty>)value;
                        RaisePropertyChanged("ComponentsProperties");
                    }
                    else
                    {
                        throw new ArgumentException("IEnumerable not of type ObservableCollection<IInspectorComponentProperty");
                    }
                }
            }
        }

        public InspectorComponentViewModel(IInspectable parent)
        {

        }
    }
}
