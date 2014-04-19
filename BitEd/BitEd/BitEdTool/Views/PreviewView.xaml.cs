using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenTK.Graphics.OpenGL4;
using BitEdToolRender.Buffers;
using BitEdToolRender.Shader;
using OpenTK;
using BitEdToolRender.Utils;
using System.Diagnostics;
using sysdraw = System.Drawing;
using System.IO;

namespace BitEdTool.Views
{
    /// <summary>
    /// Interaction logic for PreviewView.xaml
    /// </summary>
    public partial class PreviewView : UserControl
    {
        int pgmID;
        int vsID;
        int fsID;

        int attribute_vcol;
        int attribute_vpos;
        int uniform_mview;

        int vbo_position;
        int vbo_color;
        int vbo_mview;

        Vector3[] vertdata;
        Vector3[] coldata;
        Matrix4[] mviewdata;
        int[] indicedata;

        int ibo_elements;
        Stopwatch time = new Stopwatch();
        float rotate = 0f;

        public PreviewView()
        {
            rotate =(float) new Random().NextDouble() * 100;
            InitializeComponent();
        }

        private void GLElement_GLInitialized(object sender, EventArgs e)
        {
            //renderTarget.MakeCurrent();
            time.Start();
            initProgram();

            vertdata = new Vector3[] { new Vector3(-0.8f, -0.8f,  -0.8f),
                new Vector3(0.8f, -0.8f,  -0.8f),
                new Vector3(0.8f, 0.8f,  -0.8f),
                new Vector3(-0.8f, 0.8f,  -0.8f),
                new Vector3(-0.8f, -0.8f,  0.8f),
                new Vector3(0.8f, -0.8f,  0.8f),
                new Vector3(0.8f, 0.8f,  0.8f),
                new Vector3(-0.8f, 0.8f,  0.8f),
            };

            indicedata = new int[]{
                //front
                0, 7, 3,
                0, 4, 7,
                //back
                1, 2, 6,
                6, 5, 1,
                //left
                0, 2, 1,
                0, 3, 2,
                //right
                4, 5, 6,
                6, 7, 4,
                //top
                2, 3, 6,
                6, 3, 7,
                //bottom
                0, 1, 5,
                0, 5, 4
            };

            coldata = new Vector3[] { new Vector3(1f, 0f, 0f),
                new Vector3( 0f, 0f, 1f), 
                new Vector3( 0f,  1f, 0f),new Vector3(1f, 0f, 0f),
                new Vector3( 0f, 0f, 1f), 
                new Vector3( 0f,  1f, 0f),new Vector3(1f, 0f, 0f),
                new Vector3( 0f, 0f, 1f)};


            mviewdata = new Matrix4[]{
                Matrix4.Identity
            };
            OpenTK.Graphics.Color4 clearColor = new OpenTK.Graphics.Color4(69, 77, 94, 255);
            GL.ClearColor(clearColor);
            GL.PointSize(5f);
        }

        private void GLElement_GLRenderStarted(object sender, EventArgs e)
        {
            //renderTarget.MakeCurrent();
            //Update
            rotate += (float)time.ElapsedMilliseconds / 1000f;
            //Debug.WriteLine((float)time.ElapsedMilliseconds / 1000f);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_position);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, (IntPtr)(vertdata.Length * Vector3.SizeInBytes), vertdata, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(attribute_vpos, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_color);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, (IntPtr)(coldata.Length * Vector3.SizeInBytes), coldata, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(attribute_vcol, 3, VertexAttribPointerType.Float, true, 0, 0);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ibo_elements);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indicedata.Length * sizeof(int)), indicedata, BufferUsageHint.StaticDraw);

            mviewdata[0] = Matrix4.CreateRotationY(0.55f * rotate) * Matrix4.CreateRotationX(0.15f * rotate) * Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f) * Matrix4.CreatePerspectiveFieldOfView(1.3f, (float)ActualWidth / (float)ActualHeight, 1.0f, 40.0f);
            GL.UniformMatrix4(uniform_mview, false, ref mviewdata[0]);

            GL.UseProgram(pgmID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //Draw
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);


            GL.EnableVertexAttribArray(attribute_vpos);
            GL.EnableVertexAttribArray(attribute_vcol);

            GL.DrawElements(BeginMode.Triangles, indicedata.Length, DrawElementsType.UnsignedInt, 0);



            GL.DisableVertexAttribArray(attribute_vpos);
            GL.DisableVertexAttribArray(attribute_vcol);
            time.Restart();
        }


        void initProgram()
        {
            pgmID = GL.CreateProgram();
            loadShader("c:\\test.vert", ShaderType.VertexShader, pgmID, out vsID);
            loadShader("c:\\test.frag", ShaderType.FragmentShader, pgmID, out fsID);
            GL.LinkProgram(pgmID);
            Console.WriteLine(GL.GetProgramInfoLog(pgmID));

            attribute_vpos = GL.GetAttribLocation(pgmID, "vPosition");
            attribute_vcol = GL.GetAttribLocation(pgmID, "vColor");
            uniform_mview = GL.GetUniformLocation(pgmID, "modelview");

            if (attribute_vpos == -1 || attribute_vcol == -1 || uniform_mview == -1)
            {
                Console.WriteLine("Error binding attributes");
            }
            GL.GenBuffers(1, out ibo_elements);
            GL.GenBuffers(1, out vbo_position);
            GL.GenBuffers(1, out vbo_color);
            GL.GenBuffers(1, out vbo_mview);
        }
        void loadShader(String filename, ShaderType type, int program, out int address)
        {
            address = GL.CreateShader(type);
            using (StreamReader sr = new StreamReader(filename))
            {
                GL.ShaderSource(address, sr.ReadToEnd());
            }
            GL.CompileShader(address);
            GL.AttachShader(program, address);
            Console.WriteLine(GL.GetShaderInfoLog(address));
        }
        private void GLElement_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, (float)ActualWidth / (float)ActualHeight, 1.0f, 64.0f);
        }
    }
}
