using BitEdTool.ViewModel.Asset;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.Messages.Assets
{
    internal class AssetNameChangedMessage
    {
        public AssetListEntryViewModel Item { get; set; }

        private AssetNameChangedMessage(AssetListEntryViewModel item)
        {
            this.Item = item;
        }
        public static void Send(AssetListEntryViewModel newSelectedItem)
        {
            Messenger.Default.Send<AssetNameChangedMessage>(new AssetNameChangedMessage(newSelectedItem));
        }
    }
}
