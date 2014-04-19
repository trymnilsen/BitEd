using BitEdToolRender.Utils;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdToolRender.Shader
{
    public class ShaderProgram:IDisposable
    {
        public int ProgramPtr {get; private set;}
        /// <summary>
        /// The vertex shader used by this program
        /// </summary>
        public VertexShader Vertex { get; protected set; }
        /// <summary>
        /// Geometry shader used by this program
        /// </summary>
        public GeometryShader Geometry { get; protected set; }
        /// <summary>
        /// Fragment shader used by this program
        /// </summary>
        public FragmentShader Fragment { get; protected set; }

        public ShaderProgram(VertexShader vertexShader, FragmentShader fragmentShader)
        {
            this.Vertex = vertexShader;
            this.Fragment = fragmentShader;
            //Allocate a program
            this.ProgramPtr = GL.CreateProgram();
        }
        public void LinkProgram()
        {
            Debug.WriteLine("#Linking shader");
            if(Vertex!=null)
            {
                //Check if compiled
                if (!Vertex.IsCompiled)
                    Vertex.CompileShader();

                GL.AttachShader(ProgramPtr, Vertex.ShaderPtr);
            }
            if(Geometry!=null)
            {
                //Check if compiled
                if (!Geometry.IsCompiled)
                    Geometry.CompileShader();

                GL.AttachShader(ProgramPtr, Geometry.ShaderPtr);
            }
            if(Fragment!=null)
            {
                //Check if compiled
                if (!Fragment.IsCompiled)
                    Fragment.CompileShader();

                GL.AttachShader(ProgramPtr, Fragment.ShaderPtr);
            }
            GLErrorUtil.CheckErrors();
            GL.LinkProgram(ProgramPtr);
        }
        public void Use()
        {
            GL.UseProgram(ProgramPtr);
        }
        public int AttributeIndex(string attributeName)
        {
            int attributeLocation = GL.GetAttribLocation(ProgramPtr, attributeName);
            if(attributeLocation<0)
            {
                Debug.WriteLine("Did not find atrib " + attributeName);
                throw new ShaderException("Attribute: " + attributeName + " not found in currentProgram");
            }
            return attributeLocation;
        }
        public int UniformIndex(string uniformName)
        {
            int uniformLocation = GL.GetUniformLocation(ProgramPtr, uniformName);
            if (uniformLocation < 0)
            {
                Debug.WriteLine("Did not find unform" + uniformName);
                throw new ShaderException("Uniform: " + uniformName + " not found in currentProgram");
            }
            return uniformLocation;
        }

        /// <summary>
        /// Tell GPU to not use this program if instance is disposed
        /// </summary>
        public void Dispose()
        {
            GL.UseProgram(0);
        }
    }
}
