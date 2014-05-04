using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitEdTool.Messages.Assets;
using BitEdLib.Model.Assets;
using System.Diagnostics;

namespace BitEdTool.ViewModel.Asset
{
    public class AssetListEntryViewModel:DocumentViewModel
    {

        public RelayCommand RemoveCommand { get; private set; }
        public RelayCommand OpenCommand { get; private set; }

        public AssetListEntryViewModel(BaseAsset model)
            :base(model)
        {
            this.Model = model;
            OpenCommand = new RelayCommand(OpenAsset);
        }
        //Commands
        void OpenAsset()
        {
            Debug.WriteLine("Opening " + Model.Name);
            RequestOpenAssetMessage.Send(this);
        }
    }
}
