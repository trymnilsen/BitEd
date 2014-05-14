using BitEdLib.Application;
using BitEdTool.Messages.Assets;
using BitEdTool.ViewModel.Asset;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.ViewModel
{
    public class InspectorViewModel:ToolViewModel
    {
        private static readonly string NO_ASSET_STRING = "No Asset Selected";

        private AssetListEntryViewModel ActiveAsset;
        private string assetName;
        public string AssetName
        {
            get 
            {
                if(ActiveAsset!=null)
                {
                    return ActiveAsset.Model.Name;
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

        public RelayCommand SetNameCommand { get; set; }

        public InspectorViewModel(Application app)
            : base(app, "Inspector", "Inspector")
        {
            Messenger.Default.Register<SelectedAssetChangedMessage>(this,SelectedAsset);
            SetNameCommand = new RelayCommand(SetAssetName);
        }
        private void SelectedAsset(SelectedAssetChangedMessage message)
        {
            ActiveAsset = message.Item;
            RaisePropertyChanged("AssetName");
        }
        private void SetAssetName()
        {
            if(AssetName!=NO_ASSET_STRING && ActiveAsset!=null)
            {
                ActiveAsset.Model.Name = AssetName;
            }
        }
    }
}
