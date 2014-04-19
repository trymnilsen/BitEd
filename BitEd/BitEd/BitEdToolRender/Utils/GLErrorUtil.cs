using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdToolRender.Utils
{
    public static class GLErrorUtil
    {
        public static void CheckErrors()
        {
            ErrorCode GLErrorCode = GL.GetError();
            if(GLErrorCode!=ErrorCode.NoError)
            {
                throw new RenderException("Error Occured calling OpenGL", GLErrorCode);
            }
        }
    }
}
