using BitEdTool.ViewModel.Asset;
using BitEdTool.ViewModel.Inspector;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.Messages.Assets
{
    internal class InspectItemMessage
    {
        public IInspectable Item { get; set; }

        public InspectItemMessage(IInspectable item)
        {
            this.Item = item;
        }
        public static void Send(IInspectable newSelectedItem)
        {
            Messenger.Default.Send<InspectItemMessage>(new InspectItemMessage(newSelectedItem));
        }
    }
}
