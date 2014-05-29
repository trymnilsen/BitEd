using BitEdLib.Application;
using BitEdTool.Messages.Assets;
using BitEdTool.ViewModel.Inspector;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace BitEdTool.ViewModel
{
    public class InspectorViewModel:ToolViewModel
    {
        private const string NO_ASSET_STRING = "No Asset Selected";

        private IInspectable activeInspectedItem;
        private string inspectedName;
        public string InspectedName
        {
            get
            {
                return activeInspectedItem!=null ? activeInspectedItem.InspectableName : NO_ASSET_STRING;
            }
            set
            {
                if (inspectedName == value) return;
                inspectedName = value;
                RaisePropertyChanged("InspectedName");
            }
        }
        public bool CanSetName
        {
            get { return activeInspectedItem != null && activeInspectedItem.InspectorCanSetName; }
        }
        public bool CanSetTag
        {
            get { return activeInspectedItem != null && activeInspectedItem.InspectorCanSetTag; }
        }
        public IEnumerable<IInspectableComponent> InspectableComponents
        {
            get 
            { 
                if(activeInspectedItem==null)
                {
                    return new IInspectableComponent[0];
                }
                return activeInspectedItem.InspectableComponents; 
            }
        }

        public RelayCommand SetNameCommand { get; set; }
        public ObservableCollection<IInspectableComponent> Components { get; set; }

        public InspectorViewModel(Application app)
            : base(app, "Inspector", "Inspector")
        {
            Messenger.Default.Register<InspectItemMessage>(this,InspectItem);
            SetNameCommand = new RelayCommand(SetInspectedName);
            Components = new ObservableCollection<IInspectableComponent>();
        }
        private void InspectItem(InspectItemMessage message)
        {
            activeInspectedItem = message.Item;
            RaisePropertyChanged("CanSetName");
            RaisePropertyChanged("InspectedName");
            RaisePropertyChanged("InspectableComponents");
        }
        private void SetInspectedName()
        {
            if (InspectedName == NO_ASSET_STRING || activeInspectedItem == null) return;
            if(activeInspectedItem.InspectorCanSetName)
                activeInspectedItem.InspectableName = InspectedName;
        }
    }
}
