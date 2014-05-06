using BitEdLib.Model.Entity;
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
        public string Name { get; set; }
        public EntityTransformation Transformation { get; set; }

       // private Dictionary<SpriteBone, float> bones;

        public SpriteFrame()
        {
            Name = "Frame";
            StartFrame = 2;
            EndFrame = 5;
        }
    }
}
