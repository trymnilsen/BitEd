using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitEdLib.Model.Assets;
using GalaSoft.MvvmLight.Messaging;

namespace BitEdTool.Messages.Assets
{
    public class RequestOpenAssetMessage
    {
        public BaseAsset Item { get; set; }

        private RequestOpenAssetMessage(BaseAsset item)
        {
            this.Item = item;
        }
        public static void Send(BaseAsset newSelectedItem)
        {
            Messenger.Default.Send<RequestOpenAssetMessage>(new RequestOpenAssetMessage(newSelectedItem));
        }
    }
}
