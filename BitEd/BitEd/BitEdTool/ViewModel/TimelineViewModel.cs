using BitEdLib.Application;
using BitEdLib.Model.Assets;
using BitEdLib.Model.Assets.Sprite;
using BitEdTool.Messages.Assets;
using BitEdTool.ViewModel.Asset;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.ViewModel
{
   public class TimelineViewModel:ToolViewModel
    {
       //////////////
       //Backing values
       private SpriteViewModel sprite;
       private int timelineScale;
       private int timelineOffset;
       ///////////
       //Properties
       public SpriteViewModel Sprite {
           get { return sprite; }
           set
           {
               if (sprite != value)
               {
                   sprite = value;
                   RaisePropertyChanged("Sprite");
               }
           }
        }
       public int TimelineScale
       {
           get { return timelineScale; }
           set
           {
               if(timelineScale!=value)
               {
                   timelineScale = value;
                   RaisePropertyChanged("TimelineScale");
               }
           }
       }
       public int TimelineScroll
       {
           get { return timelineOffset; }
           set
           {
               if (timelineOffset != value)
               {
                   timelineOffset = value;
                   RaisePropertyChanged("TimelineScroll");
               }
           }
       }
       public ObservableCollection<SpriteFrameViewModel> SpriteElements { get; set; }

       /////////////
       //Commands
       public RelayCommand AddFrameCommand { get; set; }

       public TimelineViewModel(Application app, string name, string paneName)
           :base(app, name, paneName)
       {
           //RegistermessengerCallbacks
           Messenger.Default.Register<ActiveDocumentChangedMessage>(this,OnSelectedDocumentChanged);
           //Instanciate
           AddFrameCommand = new RelayCommand(AddFrame);
           SpriteElements = new ObservableCollection<SpriteFrameViewModel>();
       }
       //Messages
       private void OnSelectedDocumentChanged(ActiveDocumentChangedMessage message)
       {
           if (message.Item.Model is AssetSprite)
           {
               SpriteViewModel activeSprite = message.Item as SpriteViewModel; 
               Debug.WriteLine("Timeline changing to" + message.Item);
               Sprite = activeSprite;
           }
       }
       //Commands
       private void AddFrame()
       {
           if (Sprite != null)
           {
               App.AddFrame(sprite.Model as AssetSprite);
           }
       }
    }
}
