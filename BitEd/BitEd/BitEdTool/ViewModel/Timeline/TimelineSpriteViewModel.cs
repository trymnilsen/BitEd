using BitEdLib.Model.Assets.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdTool.ViewModel.Timeline
{
    public class TimelineSpriteViewModel
    {
        public SpriteFrame Model { get; set; }

        public TimelineSpriteViewModel(SpriteFrame model)
        {
            this.Model = model;
        }
    }
}
