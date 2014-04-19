using BitEdToolRender.Scene;
using BitEdToolRender.Utils;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace BitEdToolRender
{
    /// <summary>
    /// Interaction logic for GLElement.xaml
    /// </summary>
    public partial class GLElement : UserControl
    {
        private GLControl glControl;
        private DispatcherTimer renderLoopTimer;

        /// <summary>
        /// The camera used to render scene<
        /// /summary>
        public SceneCamera Camera
        {
            get { return (SceneCamera)GetValue(CameraProperty); }
            set { SetValue(CameraProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Camera. 
        public static readonly DependencyProperty CameraProperty =
            DependencyProperty.Register("Camera", typeof(float), typeof(GLElement), new UIPropertyMetadata(0f));

        /// <summary>
        /// Color used to clear the screen
        /// </summary>
        public Color ClearColor
        {
            get { return (Color)GetValue(ClearColorProperty); }
            set { 
                SetValue(ClearColorProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for ClearColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClearColorProperty =
            DependencyProperty.Register("ClearColor", typeof(Color), typeof(GLElement), new UIPropertyMetadata(Colors.Gray));


        /// <summary> Gets an interface to the underlying GraphicsContext used by the internal GLControl. </summary>
        public IGraphicsContext GraphicsContext
        {
            get { return glControl.Context; }
        } 

        public GLElement()
        {
            InitializeComponent();
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                GraphicsMode gm = GraphicsMode.Default;
                GraphicsMode graphicsmode = new GraphicsMode(
                    gm.ColorFormat,
                    gm.Depth,
                    gm.Stencil,
                    gm.Samples, // 4 // anti-alias
                    gm.AccumulatorFormat,
                    gm.Buffers,
                    gm.Stereo);
                glControl = new GLControl(gm);

                //glControl.VSync = false;
                windowsFormsHost1.Child = glControl;
            }
            // initialize timer
            renderLoopTimer = new DispatcherTimer(DispatcherPriority.Render);
            renderLoopTimer.Interval = TimeSpan.FromMilliseconds(10);
            renderLoopTimer.Tick += new EventHandler(RenderTick);

            System.Windows.Forms.Integration.WindowsFormsHost.EnableWindowsFormsInterop();
        }
               
        /// <summary>The control context is current and GL render calls can begin</summary>
        public event EventHandler GLRenderStarted;
        protected virtual void onGLRenderStarted()
        {
            EventHandler temp = GLRenderStarted;
            if (temp != null)
                temp(this, null);
        } 
        /// <summary>The GLcontext has been initialized and is current</summary>
        public event EventHandler GLInitialized;
        protected virtual void onGLInitialized()
        {
            InitializeGL();
            EventHandler temp = GLInitialized;
            if (temp != null)
                temp(this, null);
        } 
        private void Element_Loaded(object sender, RoutedEventArgs e)
        {
            SetupGLControl();
        }
        private void RenderTick(object sender, EventArgs e)
        {
            Render();
        }
        /// <summary>Initialize the scene, attach the GLControl events, and start the timer</summary>
        private void SetupGLControl()
        {
            if (glControl == null)
                return;

            glControl.MakeCurrent();
            onGLInitialized();

            glControl.Resize += new EventHandler(glControl_Resize);
            //glControl.MouseDown += new System.Windows.Forms.MouseEventHandler(GlControl_MouseDown);
            //glControl.MouseLeave += new EventHandler(GlControl_MouseLeave);
            //glControl.MouseMove += new System.Windows.Forms.MouseEventHandler(GlControl_MouseMove);
            //glControl.MouseUp += new System.Windows.Forms.MouseEventHandler(GlControl_MouseUp);
            //glControl.MouseWheel += new System.Windows.Forms.MouseEventHandler(GlControl_MouseWheel);
            //glControl.KeyDown += new System.Windows.Forms.KeyEventHandler(GlControl_KeyDown);
            //glControl.KeyUp += new System.Windows.Forms.KeyEventHandler(GlControl_KeyUp);

            renderLoopTimer.Start();
        }
        /// <summary>
        /// Reset the view whenever the size changes
        /// </summary>
        void glControl_Resize(object sender, EventArgs e)
        {
            InitializeView();
            Render();
        }
        /// <summary>
        /// Starts our rendering
        /// The real method, the best method
        /// </summary>
        private void Render()
        {
                onGLRenderStarted();
                glControl.SwapBuffers();
        }
        /// <summary>Setup the various GL crap</summary>
        private void InitializeGL()
        {
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Enable(EnableCap.PolygonSmooth);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);
            GL.Enable(EnableCap.CullFace);
            //Clear screen settings
            //float[] clearColors = new float[1];
            //try
            //{
            //    clearColors = ClearColor.GetNativeColorValues();
            //}
            //catch(Exception e)
            //{
            //    Debug.WriteLine(e.ToString());
            //}
            GL.ClearColor(0f,0.2f,0.5f,1f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GLErrorUtil.CheckErrors();
            //transformInner.Location = new Vector3(0, 0, -4);
            //transformInner.Scale = new Vector3(.8f, .8f, .8f);

            InitializeView();
        }
        /// <summary>Initialize the GL view</summary>
        public void InitializeView()
        {
            //TODO, prevent creating a controll with zero height/width
            GL.Viewport(0, 0, (int)this.ActualWidth, (int)this.ActualHeight);
            double ratio = ActualWidth / ActualHeight;
        }
        //Make the current control the active one
        public void MakeCurrent()
        {
            glControl.MakeCurrent();
        }
    }
}
