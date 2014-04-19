using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdToolRender.Shader
{
    public class ShaderException:Exception
    {
        /// <summary>
        /// Creates a shader exception based on another exception (Like IO error while reading etc)
        /// </summary>
        /// <param name="innerException">The exception that this exception should forward</param>
        public ShaderException(Exception innerException)
            : base("An error occured compiling the shader, see inner exception", innerException) { }
        public ShaderException(String error)
            : base("Shader compiling error" + Environment.NewLine + error) { }

    }
}
