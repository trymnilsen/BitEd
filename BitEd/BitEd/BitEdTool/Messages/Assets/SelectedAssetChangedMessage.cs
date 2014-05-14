using BitEdTool.ViewModel.Asset;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.Messages.Assets
{
    internal class SelectedAssetChangedMessage
    {
        public AssetListEntryViewModel Item { get; set; }

        public SelectedAssetChangedMessage(AssetListEntryViewModel item)
        {
            this.Item = item;
        }
        public static void Send(AssetListEntryViewModel newSelectedItem)
        {
            Messenger.Default.Send<SelectedAssetChangedMessage>(new SelectedAssetChangedMessage(newSelectedItem));
        }
    }
}
