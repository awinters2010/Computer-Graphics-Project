using System;
using System.Windows.Forms;
using SlimDX;
using System.Threading;
using System.CodeDom.Compiler;
using System.Diagnostics;
using SlimDX.Direct3D9;

namespace Graphics
{
    public partial class Form1 : Form
    {
        //for compiling the code to XNA
        string output = "Out.exe";
        CompilerResults results;

        //the thread that the graphics will be running in so the UI doesn't lock up.
        private Thread renderThread;

        private Result r;

        private Thread status;

        private Camera camera;

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

            this.KeyPress += new KeyPressEventHandler(KeyBoard);
        }

        //the button to compile the code to XNA
        private void btnCompile_Click(object sender, EventArgs e)
        {
            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");

            Button buttonObject = (Button)sender;

            txtCompileErrors.Text = "";

            System.CodeDom.Compiler.CompilerParameters par = new CompilerParameters();

            //generate exe not dll
            par.GenerateExecutable = true;
            par.OutputAssembly = output;
            //Assembly a;
            par.ReferencedAssemblies.Add("C:/Program Files (x86)/Microsoft XNA/XNA Game Studio/v4.0/References/Windows/x86/Microsoft.Xna.Framework.dll");
            par.ReferencedAssemblies.Add("C:/Program Files (x86)/Microsoft XNA/XNA Game Studio/v4.0/References/Windows/x86/Microsoft.Xna.Framework.Game.dll");
            par.ReferencedAssemblies.Add("C:/Program Files (x86)/Microsoft XNA/XNA Game Studio/v4.0/References/Windows/x86/Microsoft.Xna.Framework.Graphics.dll");
            par.CompilerOptions = "/platform:x86";

            txtCompileErrors.Text = par.LinkedResources.ToString();

            results = codeProvider.CompileAssemblyFromSource(par, txtCode.Text);

            if (results.Errors.Count > 0)
            {
                txtCompileErrors.ForeColor = System.Drawing.Color.Red;

                foreach (CompilerError item in results.Errors)
                {
                    txtCompileErrors.Text = "line number " + item.Line +
                        ", error num" + item.ErrorNumber +
                        " , " + item.ErrorText + ";" +
                        Environment.NewLine + Environment.NewLine;
                }
            }
            else
            {
                //Successful Compile
                txtCompileErrors.ForeColor = System.Drawing.Color.Blue;
                txtCompileErrors.Text = "Success!";
                for (int i = 0; i < par.ReferencedAssemblies.Count; i++)
                {
                    txtCompileErrors.Text += par.ReferencedAssemblies[i].ToString();
                }
            }

        }

        //the button to run the compiled code
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (results.Errors.Count == 0)
            {
                //If we clicked run then launch our EXE
                Process.Start(output);
            }
        }

        #region Program Shutdown

        //on shutdown this method is called. it stoppeds the thread and releases the resources and graphics card
        public void shutDown()
        {
            status.Abort();
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
                renderable.Add(new Cube(ref DeviceManager.device, ref r));
            }
        }

        //adds a new triangle to the screen
        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (renderable)
            {
                renderable.Add(new Triangle(ref DeviceManager.device, ref r));
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
            RenderState s = RenderState.FillMode;
            DeviceManager.device.GetRenderState(s);
            FillMode f = (FillMode)s;
            if (e.KeyChar == (char)Keys.H)
            {
                if (f == FillMode.Solid)
                {
                    f = FillMode.Wireframe;
                }

            }

            if (e.KeyChar == (char)Keys.G)
            {
                txtCode.Clear();
            }

            DeviceManager.device.SetRenderState(RenderState.FillMode, f);
        }
    }
}