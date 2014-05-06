using BitEdLib.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Model.Assets.Sprite
{
    public class SpriteBone
    {
        public SpriteBone Parent { get; set; }
        public EntityTransformation Transformation { get; set; }
    }
}
