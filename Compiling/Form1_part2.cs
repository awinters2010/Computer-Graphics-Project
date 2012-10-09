using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX.DXGI;
using SlimDX;
using SlimDX.Direct3D11;
using System.Threading;

namespace Graphics
{
    public partial class Form1
    {
        List<BasicShape> renderable = new List<BasicShape>();

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
            SlimDX.Direct3D11.Device.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.None, description, out device, out swapChain);

            // create a view of our render target, which is the backbuffer of the swap chain we just created
            using (var resource = SlimDX.Direct3D11.Resource.FromSwapChain<SlimDX.Direct3D11.Texture2D>(swapChain, 0))
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
                foreach (var item in renderable)
                {
                    item.Render();
                }
                swapChain.Present(0, PresentFlags.None);
            }
        }

        public void init()
        {
            renderThread = new Thread(new ThreadStart(renderScene));
            renderThread.Start();
        }
    }
}
