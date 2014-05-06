using BitEdLib.Model.Transformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.Model.Entity
{
    public class EntityTransformation
    {
        public Vector2 Position { get; set; }
        public float Rotation {get; set;}
        public Vector2 Scale { get; set; }
        public EntityTransformation()
        {
            Position = new Vector2(0, 0);
            Rotation = 47;
            Scale = new Vector2(1, 1);
        }
    }
}
