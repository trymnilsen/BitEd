using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdToolRender.Utils
{
    public class RenderException : Exception
    {
        public ErrorCode RenderError { get; set; }
        public RenderException(string errorMessage, ErrorCode error)
            :base(errorMessage)
        {
            this.RenderError = error;
        }
    }
}
