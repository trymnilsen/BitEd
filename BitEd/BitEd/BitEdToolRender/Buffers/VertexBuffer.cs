using BitEdToolRender.Utils;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdToolRender.Buffers
{
    public class VertexBuffer:IDisposable
    {
        /// <summary>
        /// The index given for this Vertexbuffer
        /// </summary>
        public int VertexBufferPtr { get; private set; }
        /// <summary>
        /// The size in bytes of this buffer
        /// </summary>
        public int Size { get; private set; }

        public VertexBuffer(float[] buffer, BufferUsageHint usage)
        {
            GenerateBuffer(buffer, usage);
        }
        /// <summary>
        /// Create a vertex buffer from an arry of vector
        /// </summary>
        /// <param name="data">An arry containing our data</param>
        /// <param name="usage"></param>
        public VertexBuffer(Vector3[] data, BufferUsageHint usage)
        {
            //Convert from the vector class to simple float array
            float[] strippedData = DataStripper.Vector3ToFloatArray(data);
            //Generate the buffer
            GenerateBuffer(strippedData, usage);
        }
        /// <summary>
        /// The method actually generating the shader
        /// </summary>
        /// <param name="data">The data to fill buffer with</param>
        /// <param name="usage"></param>
        private void GenerateBuffer(float[] data, BufferUsageHint usage)
        {
            Size = sizeof(float) * data.Length;
            //Generate it
            VertexBufferPtr = GL.GenBuffer();
            //Send it of
            BindBuffer();
            GL.BufferData<float>(BufferTarget.ArrayBuffer, (IntPtr)Size, data, usage);
            UnbindBuffer();
        }
        /// <summary>
        /// Binds this buffer for usage
        /// </summary>
        public void BindBuffer()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferPtr);
        }
        /// <summary>
        /// Unbindes this buffer
        /// </summary>
        public void UnbindBuffer()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
        /// <summary>
        /// Tells the gpu to not use this anymore if this instance is beeing garbadge collected
        /// </summary>
        public void Dispose()
        {
            UnbindBuffer();
            GL.DeleteBuffer(VertexBufferPtr);
        }
    }
}
