using System;
using System.Windows.Forms;
using SlimDX;
using System.Threading;
using System.Text;
using System.Drawing;
using SlimDX.RawInput;
using SDX3D9 = SlimDX.Direct3D9;
using System.Collections.Generic;
using SlimDX.Direct3D9;
using System.Collections.ObjectModel;

namespace Graphics
{
    public partial class MainPage : Form
    {
        //the thread that the graphics will be running in so the UI doesn't lock up.
        private Thread renderThread;

        private Result errorResult;

        private Camera camera;

        //GUI colors
        private static Color GUIBackColor = System.Drawing.Color.FromArgb(162, 162, 162);
        private static Color GUISubWindowColor = System.Drawing.Color.FromArgb(194, 194, 194);
        private static Color GUISubWindowHeaderColor = System.Drawing.Color.FromArgb(218, 218, 218);
        private ObservableCollection<IShape> Shapes = new ObservableCollection<IShape>();

        private float xMovement = 0.0f;

        private VertexBuffer vBuffer;
        private IndexBuffer iBuffer;

        private int verticesCount = 0;
        private int indiciesCount = 0;

        public MainPage()
        {
            //don't touch this method. microsoft created
            InitializeComponent();

            //this method initializes the Device
            DeviceManager.CreateDevice(panel1.Handle,
                panel1.Width, panel1.Height);

            camera = new Camera();

            camera.SetView(new Vector3(0, 0, -3.5f), Vector3.Zero, Vector3.UnitY);

            DeviceManager.LocalDevice.SetRenderState(SDX3D9.RenderState.Lighting, false);

            //this method starts the thread that the graphics run on.
            Init();

            //set GUI control attributes
            SetGui();

            panel1.Focus();

            this.KeyPress += new KeyPressEventHandler(KeyBoard);

            Shapes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Shapes_CollectionChanged);
        }

        void Shapes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            verticesCount += Shapes[e.NewStartingIndex].ShapeVertices.Length;
            indiciesCount += Shapes[e.NewStartingIndex].ShapeIndices.Length;

            List<VertexUntransformed> v = new List<VertexUntransformed>();
            List<short> i = new List<short>();

            foreach (var item in Shapes)
            {
                v.AddRange(item.ShapeVertices);
                i.AddRange(item.ShapeIndices);
            }

            vBuffer = new VertexBuffer(DeviceManager.LocalDevice, verticesCount * VertexUntransformed.VertexByteSize, Usage.WriteOnly, VertexUntransformed.format, Pool.Default);
            vBuffer.Lock(0, verticesCount * VertexUntransformed.VertexByteSize, LockFlags.Discard).WriteRange(v.ToArray());
            vBuffer.Unlock();

            iBuffer = new IndexBuffer(DeviceManager.LocalDevice, indiciesCount * sizeof(short), Usage.WriteOnly, Pool.Default, true);
            iBuffer.Lock(0, indiciesCount * sizeof(short), LockFlags.Discard).WriteRange(i.ToArray());
            iBuffer.Unlock();

            DeviceManager.LocalDevice.Indices = iBuffer;
            DeviceManager.LocalDevice.SetStreamSource(0, vBuffer, 0, VertexUntransformed.VertexByteSize);
            DeviceManager.LocalDevice.VertexDeclaration = VertexUntransformed.VertexDecl;
        }

        public void RenderScene()
        {
            while (true)
            {
                DeviceManager.LocalDevice.Clear(SDX3D9.ClearFlags.Target | SDX3D9.ClearFlags.ZBuffer, Color.Black, 1.0f, 0);
                DeviceManager.LocalDevice.BeginScene();

                lock (Shapes)
                {
                    if (Shapes.Count != 0)
                    {
                        DeviceManager.LocalDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, verticesCount, 0, indiciesCount / 3);
                    }
                }

                DeviceManager.LocalDevice.EndScene();
                DeviceManager.LocalDevice.Present();
            }
        }


        public void Init()
        {
            renderThread = new Thread(new ThreadStart(RenderScene));
            renderThread.Start();
        }

        #region Program Shutdown

        //on shutdown this method is called. it stoppeds the thread and releases the resources and graphics card
        public void ShutDown()
        {
            while (renderThread.IsAlive)
            {
                renderThread.Abort();
            }
            if (vBuffer != null && iBuffer != null)
            {
                vBuffer.Dispose();
                vBuffer = null;
                iBuffer.Dispose();
                iBuffer = null;
            }
            VertexUntransformed.VertexDecl.Dispose();
            DeviceManager.LocalDevice.Dispose();
            System.Diagnostics.Debug.WriteLine("stuff disposed");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShutDown();
        }

        #endregion

        #region Shape Menu Drawing

        //adds a new cube to the screen
        private void CubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (Shapes)
            {
                Shapes.Add(new Cube());
            }
        }

        //adds a new triangle to the screen
        private void TriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (Shapes)
            {
                Shapes.Add(new Triangle());
            }
        }

        #endregion

        #region Memory and Vertices Display

        //for displaying how much memory we are currently using 
        private void LblUpdate(string text)
        {
            lblMemoryUsage.Text = text;

        }

        //displays the number of vertices on the screen
        private void OLblUpdate(string text)
        {
        }

        #endregion

        private void KeyBoard(object sender, KeyPressEventArgs e)
        {
            SDX3D9.FillMode fm = DeviceManager.LocalDevice.GetRenderState
                <SDX3D9.FillMode>(SDX3D9.RenderState.FillMode);

            if (e.KeyChar.ToString() == Keys.F.ToString().ToLower())
            {
                fm = fm == SDX3D9.FillMode.Solid ?
                    SDX3D9.FillMode.Wireframe : SDX3D9.FillMode.Solid;
            }

            DeviceManager.LocalDevice.SetRenderState(SDX3D9.RenderState.FillMode, fm);

            if (e.KeyChar.ToString() == Keys.X.ToString().ToLower())
            {
                xMovement++;
                camera.MoveCameraX(xMovement);
            }

            if (e.KeyChar.ToString() == Keys.Z.ToString().ToLower())
            {
                camera.MoveCameraZ(1f);
            }
        }

        /// <summary>
        /// Sets GUI Menu items and controls including width and colors
        /// </summary>
        private void SetGui()
        {
            //set colors

            //main form
            this.BackColor = GUIBackColor;

            //notification area
            plNotArea.BackColor = GUIBackColor;
            gbMemUsage.BackColor = GUISubWindowColor;

            //tab panel area
            tpRight1.BackColor = GUISubWindowColor;
            tpRight2.BackColor = GUISubWindowColor;

            //set control sizes
            plNotArea.Width = this.Width;
        }
    }
}