using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SlimDX;
using SlimDX.Direct3D11;
using SlimDX.DXGI;
using System.Threading;
using System.CodeDom.Compiler;
using System.Diagnostics;
using SlimDX.D3DCompiler;

namespace Graphics
{
    public partial class Form1 : Form
    {
        string output = "Out.exe";

        CompilerResults results;

        public SlimDX.Direct3D11.Device device;
        public SwapChain swapChain;
        public SlimDX.Direct3D11.Viewport viewport;
        public RenderTargetView renderTarget;
        public DeviceContext context;
        Thread renderThread;

        Camera camera;
        Triangle triangle;

        public Form1()
        {
            //this.IsMdiContainer = true;
            InitializeComponent();
            createDeviceAndSwapChain(this);
            triangle = new Triangle(device, context);
            init();

            camera = new Camera();
            
        }

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

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (results.Errors.Count == 0)
            {
                //If we clicked run then launch our EXE
                Process.Start(output);
            }
        }

        private void dFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        #region initials and end

        public void shutDown()
        {
            triangle.Destroy();
            renderThread.Abort();
            renderTarget.Dispose();
            swapChain.Dispose();
            device.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            shutDown();
        }

        #endregion

        private void cubeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renderable.Add(triangle);
        }
    }
}