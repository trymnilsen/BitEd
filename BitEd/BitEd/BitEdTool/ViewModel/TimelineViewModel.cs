﻿using BitEdLib.Application;
using BitEdLib.Model.Assets;
using BitEdLib.Model.Assets.Sprite;
using BitEdTool.Messages.Assets;
using BitEdTool.ViewModel.Timeline;
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
       public AssetSprite _sprite;
       public AssetSprite Sprite {
           get { return _sprite; }
           set
           {
               if (_sprite != value)
               {
                   _sprite = value;
                   RaisePropertyChanged("Sprite");
               }
           }
        }
       public ObservableCollection<TimelineSpriteViewModel> SpriteElements { get; set; }

       public TimelineViewModel(Application app, string name, string paneName)
           :base(app, name, paneName)
       {
           Messenger.Default.Register<ActiveDocumentChangedMessage>(this,OnSelectedDocumentChanged);
       }
       private void OnSelectedDocumentChanged(ActiveDocumentChangedMessage message)
       {
           if (message.Item.Model is AssetSprite)
           {
               Debug.WriteLine("Timeline chaning to" + message.Item);
               RefillTimelineFromSprite(message.Item.Model as AssetSprite);
           }
       }
       private void RefillTimelineFromSprite(AssetSprite sprite)
       {
           foreach(SpriteFrame frame in sprite.Frames)
           {
               TimelineSpriteViewModel frameEntry = new TimelineSpriteViewModel(frame);
               SpriteElements.Add(frameEntry);
           }
       }
    }
}
