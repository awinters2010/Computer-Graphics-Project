using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Resource = SlimDX.Direct3D11.Resource;
using Device = SlimDX.Direct3D11.Device;
using SlimDX;
using SlimDX.Direct3D11;
using SlimDX.DXGI;
using System.Threading;
using System.CodeDom.Compiler;
using System.Diagnostics;
using SlimDX.Windows;
using SlimDX.D3DCompiler;

namespace Graphics
{
    public partial class Form1 : Form
    {
        string output = "Out.exe";

        CompilerResults results;

        public Device device;
        public SwapChain swapChain;
        public SlimDX.Direct3D11.Viewport viewport;
        public RenderTargetView renderTarget;
        public DeviceContext context;
        Thread renderThread;
        ShaderSignature inputSignature;
        VertexShader vertexShader;
        PixelShader pixelShader;
        DataStream vertices;
        SlimDX.Direct3D11.Buffer vertexBuffer;
        InputLayout layout;

        Camera camera;

        public Form1()
        {
            //this.IsMdiContainer = true;
            InitializeComponent();
            createDeviceAndSwapChain(this);
            trainagleSetup();
            init();

            camera = new Camera();

            //context.Draw(3, 0);
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
            var form = new RenderForm("test");

            //MessagePump.Run(form, () => { });

            form.Show();
        }

        private void trainagleSetup()
        {
            // load and compile the vertex shader
            using (var bytecode = ShaderBytecode.CompileFromFile("triangle.fx", "VShader", "vs_4_0", ShaderFlags.None, EffectFlags.None))
            {
                inputSignature = ShaderSignature.GetInputSignature(bytecode);
                vertexShader = new VertexShader(device, bytecode);
            }

            // load and compile the pixel shader
            using (var bytecode = ShaderBytecode.CompileFromFile("triangle.fx", "PShader", "ps_4_0", ShaderFlags.None, EffectFlags.None))
                pixelShader = new PixelShader(device, bytecode);

            // create test vertex data, making sure to rewind the stream afterward
            vertices = new DataStream(12 * 3, true, true);
            vertices.Write(new Vector3(0.0f, 0.5f, 0.5f));
            vertices.Write(new Vector3(0.5f, -0.5f, 0.5f));
            vertices.Write(new Vector3(-0.5f, -0.5f, 0.5f));
            vertices.Position = 0;

            // create the vertex layout and buffer
            var elements = new[] { new InputElement("POSITION", 0, Format.R32G32B32_Float, 0) };
            layout = new InputLayout(device, inputSignature, elements);
            vertexBuffer = new SlimDX.Direct3D11.Buffer(device, vertices, 12 * 3, ResourceUsage.Default, BindFlags.VertexBuffer, CpuAccessFlags.None, ResourceOptionFlags.None, 0);

            // configure the Input Assembler portion of the pipeline with the vertex data
            context.InputAssembler.InputLayout = layout;
            context.InputAssembler.PrimitiveTopology = PrimitiveTopology.TriangleList;
            context.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(vertexBuffer, 12, 0));

            // set the shaders
            context.VertexShader.Set(vertexShader);
            context.PixelShader.Set(pixelShader);
        }

        #region initials and end

        public void createDeviceAndSwapChain(System.Windows.Forms.Control form)
        {
            var description = new SwapChainDescription()
            {
                BufferCount = 1,
                Usage = Usage.RenderTargetOutput,
                OutputHandle = panel1.Handle,
                IsWindowed = true,
                ModeDescription = new ModeDescription(0, 0, new Rational(60, 1), Format.R8G8B8A8_UNorm),
                SampleDescription = new SampleDescription(1, 0),
                Flags = SwapChainFlags.AllowModeSwitch,
                SwapEffect = SwapEffect.Discard
            };
            Device.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.None, description, out device, out swapChain);

            // create a view of our render target, which is the backbuffer of the swap chain we just created
            using (var resource = Resource.FromSwapChain<SlimDX.Direct3D11.Texture2D>(swapChain, 0))
                renderTarget = new RenderTargetView(device, resource);

            // setting a viewport is required if you want to actually see anything
            context = device.ImmediateContext;
            viewport = new SlimDX.Direct3D11.Viewport(0.0f, 0.0f, panel1.ClientSize.Width, 
                panel1.ClientSize.Height);
            context.OutputMerger.SetTargets(renderTarget);
            context.Rasterizer.SetViewports(viewport);

            // prevent DXGI handling of alt+enter, which doesn't work properly with Winforms
            using (var factory = swapChain.GetParent<Factory>())
                factory.SetWindowAssociation(form.Handle, WindowAssociationFlags.IgnoreAltEnter);

            // handle alt+enter ourselves
            form.KeyDown += (o, e) =>
            {
                if (e.Alt && e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    swapChain.IsFullScreen = !swapChain.IsFullScreen;
                }
            };
        }

        public void renderScene()
        {
            while (true)
            {
                context.ClearRenderTargetView(renderTarget, new Color4(0.25f, 0.75f, 0.25f));
                context.Draw(3, 0);
                swapChain.Present(0, PresentFlags.None);
            }
        }

        public void init()
        {
            renderThread = new Thread(new ThreadStart(renderScene));
            renderThread.Start();
        }

        public void shutDown()
        {
            vertices.Close();
            vertexBuffer.Dispose();
            layout.Dispose();
            inputSignature.Dispose();
            vertexShader.Dispose();
            pixelShader.Dispose();
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
    }
}