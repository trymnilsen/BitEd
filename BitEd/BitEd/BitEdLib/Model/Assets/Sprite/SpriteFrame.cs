using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Model.Assets.Sprite
{
    public class SpriteFrame
    {
        public int StartFrame { get; set; }
        public int EndFrame { get; set; }
        public SpriteFrame()
        {
            StartFrame = 2;
            EndFrame = 5;
        }
    }
}
