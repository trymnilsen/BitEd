using BitEdLib.Application;
using BitEdTool.Messages.Assets;
using BitEdTool.ViewModel.Asset;
using BitEdTool.ViewModel.Inspector;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.ViewModel
{
    public class InspectorViewModel:ToolViewModel
    {
        private static readonly string NO_ASSET_STRING = "No Asset Selected";

        private IInspectable ActiveInspectedItem;
        private string assetName;
        public string InspectedName
        {
            get 
            {
                if(ActiveInspectedItem!=null)
                {
                    return ActiveInspectedItem.InspectableName;
                }
                return NO_ASSET_STRING;
            }
            set
            {
                if(assetName!=value)
                {
                    assetName = value;
                    RaisePropertyChanged("AssetName");
                }
            }
        }
        public bool CanSetName
        {
            get { return ActiveInspectedItem.InspectorCanSetName; }
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
            ActiveInspectedItem = message.Item;
            RaisePropertyChanged("AssetName");
        }
        private void SetInspectedName()
        {
            if(InspectedName!=NO_ASSET_STRING && ActiveInspectedItem!=null)
            {
                if(ActiveInspectedItem.InspectorCanSetName)
                    ActiveInspectedItem.InspectableName = InspectedName;
            }
        }
    }
}
