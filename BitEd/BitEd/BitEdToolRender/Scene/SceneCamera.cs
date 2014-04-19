using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace BitEdToolRender.Scene
{
    public class SceneCamera
    {
        public Matrix4 Transformation { get; set; }

        public void Translate(Vector3 translation)
        {
            Transformation *= Matrix4.CreateTranslation(translation);
        }
    }
}
