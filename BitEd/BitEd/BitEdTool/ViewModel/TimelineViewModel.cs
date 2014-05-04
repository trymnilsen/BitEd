using BitEdLib.Application;
using BitEdTool.Messages.Assets;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.ViewModel
{
   public class TimelineViewModel:ToolViewModel
    {
       public TimelineViewModel(Application app, string name, string paneName)
           :base(app, name, paneName)
       {
           Messenger.Default.Register<ActiveDocumentChangedMessage>(this,OnSelectedDocumentChanged);
       }
       private void OnSelectedDocumentChanged(ActiveDocumentChangedMessage message)
       {
           Debug.WriteLine("Timeline chaning to" + message.Item);
       }
    }
}
