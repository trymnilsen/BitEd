using BitEdLib.Model.Assets.Sprite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Model.Assets
{
    public class AssetSprite:BaseAsset
    {
        public ObservableCollection<SpriteFrame> Frames { get; set; }
        public int FramesDuration { get; set; }
        public AssetSprite()
        {
            Frames = new ObservableCollection<SpriteFrame>();
        }
    }
}
