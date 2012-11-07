using System;
using System.Windows.Forms;
using SlimDX;
using System.Threading;
using System.Text;
using System.Drawing;
using SlimDX.RawInput;
using SDX3D9 = SlimDX.Direct3D9;

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

        float xMovement = 0.0f;

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
            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
            this.MouseClick += new MouseEventHandler(Form1_MouseClick);
        }

        void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Button.ToString());
        }

        void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Button.ToString());
            camera.MoveCameraZ(e.Delta / 120f);
        }

        #region Program Shutdown

        //on shutdown this method is called. it stoppeds the thread and releases the resources and graphics card
        public void ShutDown()
        {
            while (renderThread.IsAlive)
            {
                renderThread.Abort();
            }
            DeviceManager.LocalDevice.Dispose();
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
            lock (renderable)
            {
            }
        }

        //adds a new triangle to the screen
        private void TriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (renderable)
            {
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