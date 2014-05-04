using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitEdLib.Model.Assets;
using GalaSoft.MvvmLight.Messaging;
using BitEdTool.ViewModel.Asset;

namespace BitEdTool.Messages.Assets
{
    public class RequestOpenAssetMessage
    {
        public AssetListEntryViewModel Item { get; set; }

        private RequestOpenAssetMessage(AssetListEntryViewModel item)
        {
            this.Item = item;
        }
        public static void Send(AssetListEntryViewModel newSelectedItem)
        {
            Messenger.Default.Send<RequestOpenAssetMessage>(new RequestOpenAssetMessage(newSelectedItem));
        }
    }
}
