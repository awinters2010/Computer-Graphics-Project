using System;
using System.Windows.Forms;
using SlimDX;
using System.Threading;
using System.CodeDom.Compiler;
using System.Diagnostics;
using SlimDX.Direct3D9;
using System.Text;
using System.Drawing;

namespace Graphics
{
    public partial class Form1 : Form
    {
        //the thread that the graphics will be running in so the UI doesn't lock up.
        private Thread renderThread;

        private Result r;

        private Camera camera;

        //GUI colors
        private static Color GUIBackColor = System.Drawing.Color.FromArgb(162, 162, 162);
        private static Color GUISubWindowColor = System.Drawing.Color.FromArgb(194, 194, 194);
        private static Color GUISubWindowHeaderColor = System.Drawing.Color.FromArgb(218, 218, 218);

        public Form1()
        {
            //don't touch this method. microsoft created
            InitializeComponent();

            //this method initializes the device
            DeviceManager.CreateDevice(panel1.Handle,
                panel1.Width, panel1.Height);

            camera = new Camera();

            camera.SetView(new Vector3(0, 0, -3.5f), Vector3.Zero, Vector3.UnitY);

            DeviceManager.device.SetRenderState(RenderState.Lighting, false);

            DeviceManager.device.VertexFormat = VertexUntransformed.format;

            //this method starts the thread that the graphics run on.
            init();

            this.KeyPress +=new KeyPressEventHandler(KeyBoard);

            //set GUI control attributes
            setGui();

            panel1.Focus();
        }

        #region Program Shutdown

        //on shutdown this method is called. it stoppeds the thread and releases the resources and graphics card
        public void shutDown()
        {
            while (renderThread.IsAlive)
            {
                renderThread.Abort();
            }
            DeviceManager.device.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            shutDown();
        }

        #endregion

        #region Shape Menu Drawing

        //adds a new cube to the screen
        private void cubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (renderable)
            {
                renderable.Add(new Cube(ref DeviceManager.device, r));
            }
        }

        //adds a new triangle to the screen
        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (renderable)
            {
                renderable.Add(new Triangle(ref DeviceManager.device, r));
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
            lblMem.Text = "Vertices: " + BasicShape.VerticesCount.ToString();
        }

        #endregion

        private void sixSidesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void KeyBoard(object sender, KeyPressEventArgs e)
        {
            FillMode fm = DeviceManager.device.GetRenderState<FillMode>(RenderState.FillMode);

            if (e.KeyChar.ToString() == Keys.F.ToString().ToLower())
            {
                fm = fm == FillMode.Solid ? FillMode.Wireframe : FillMode.Solid;
            }

            DeviceManager.device.SetRenderState(RenderState.FillMode, fm);
        }

        /// <summary>
        /// Sets GUI Menu items and controls including width and colors
        /// </summary>
        private void setGui()
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