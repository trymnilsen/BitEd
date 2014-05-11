using BitEdLib.Model.Assets;
using BitEdLib.Model.Assets.Sprite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.ViewModel.Asset
{
    public class SpriteViewModel:AssetListEntryViewModel
    {
        public ObservableCollection<SpriteFrameViewModel> Frames { get; set; }
        public SpriteViewModel(AssetSprite model)
            :base(model)
        {
            Frames = new ObservableCollection<SpriteFrameViewModel>();
            model.Frames.CollectionChanged+=FramesInModelChanged;
            //Add existing frames
            foreach(SpriteFrame sf in model.Frames)
            {
                Frames.Add(new SpriteFrameViewModel(sf));
            }
        }

        private void FramesInModelChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            SpriteFrame entityAdded = e.NewItems[0] as SpriteFrame;
            if(!Frames.Any(x=>x.Model == entityAdded))
            {
                SpriteFrameViewModel frameVM = new SpriteFrameViewModel(entityAdded);
                Frames.Add(frameVM);
            }
        }
    }
}
