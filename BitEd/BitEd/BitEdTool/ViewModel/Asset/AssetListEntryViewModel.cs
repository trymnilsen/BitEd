using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitEdTool.Messages.Assets;
using BitEdLib.Model.Assets;

namespace BitEdTool.ViewModel.Asset
{
    public class AssetListEntryViewModel
    {
        public BaseAsset model { get; set; }

        public RelayCommand RemoveCommand { get; private set; }
        public RelayCommand OpenCommand { get; private set; }

        public AssetListEntryViewModel(BaseAsset model)
        {
            this.model = model;
        }
        //Commands
        void OpenAsset()
        {
            RequestOpenAssetMessage.Send(model);
        }
    }
}
