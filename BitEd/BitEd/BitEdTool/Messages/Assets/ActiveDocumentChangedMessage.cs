using BitEdTool.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.Messages.Assets
{
    internal class ActiveDocumentChangedMessage
    {
        public DocumentViewModel Item { get; set; }

        private ActiveDocumentChangedMessage(DocumentViewModel item)
        {
            this.Item = item;
        }
        public static void Send(DocumentViewModel newSelectedItem)
        {
            Messenger.Default.Send<ActiveDocumentChangedMessage>(new ActiveDocumentChangedMessage(newSelectedItem));
        }
    }
}
