using BitEdToolRender.Utils;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdToolRender.Shader
{
    public abstract class Shader : IDisposable
    {
        public string Code { get; private set; }
        /// <summary>
        /// Retrives what type of shader this is
        /// </summary>
        public abstract ShaderType Type { get;  }
        /// <summary>
        /// The name of this Shader
        /// </summary>
        public string ShaderSource { get; private set; }
        /// <summary>
        /// The pointer or index assigned by OpenGL to this shader
        /// </summary>
        public int ShaderPtr { get; private set; }
        public bool IsCompiled { get; private set; }

        
        public Shader(string file)
        {
            this.ShaderSource = file;
        }
        /// <summary>
        /// Loads the given shader for file and tries to compile it
        /// </summary>
        /// <exception cref="ShaderException">
        /// Thrown when there was an error compiling the shader code
        /// </exception>
        public void CompileShader()
        {
            int status_code = 1;
            string error_info = "";
            //Load it
            try
            {
                FileInfo shaderFile = new FileInfo(ShaderSource);
                using(StreamReader shaderStream = shaderFile.OpenText())
                {
                    Code = shaderStream.ReadToEnd();
                }
            }
            catch(Exception e)
            {
                throw new ShaderException(e);
            }
            try
            {
                //Create it
                ShaderPtr = GL.CreateShader(Type);
                //Try to compile it
                GL.ShaderSource(ShaderPtr, Code);
                GLErrorUtil.CheckErrors();
                Debug.Write("Debug Info shader code " + Code);
                GL.CompileShader(ShaderPtr);
                GLErrorUtil.CheckErrors();
                GL.GetShaderInfoLog(ShaderPtr, out error_info);
                GL.GetShader(ShaderPtr, ShaderParameter.CompileStatus, out status_code);
                GLErrorUtil.CheckErrors();
            }
            catch(ShaderException se)
            {
                var i = 2;
            }

            if (status_code != 1)
            {
                throw new ShaderException(ShaderSource + Environment.NewLine + error_info);
            }
            else
            {
                Debug.WriteLine("#Sucessfully compiled " + ShaderSource);
                //Successfully compiled
                IsCompiled = true;
            }
        }

        /// <summary>
        /// Tells the GPU to dont use this program anymore if we dispose of it
        /// </summary>
        public void Dispose()
        {
            GL.UseProgram(0);
        }
    }
    //Shader classes
    public class VertexShader:Shader
    {
        public override ShaderType Type { get { return ShaderType.VertexShader; } }
        public VertexShader(string file) : base(file) { }
    }
    public class GeometryShader : Shader
    {
        public override ShaderType Type { get { return ShaderType.GeometryShader; } }
        public GeometryShader(string file) : base(file) { }
    }
    public class FragmentShader : Shader
    {
        public override ShaderType Type { get { return ShaderType.FragmentShader; } }
        public FragmentShader(string file) : base(file) { }
    }
}
