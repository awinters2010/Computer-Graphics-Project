using System.Collections.Generic;
using System.Threading;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Graphics
{
    public partial class Form1
    {
        List<BasicShape> renderable = new List<BasicShape>();

        public void renderScene()
        {
            while (true)
            {
                DeviceManager.device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Black, 1.0f, 0);
                DeviceManager.device.BeginScene();
                lock (renderable)
                {
                    foreach (var item in renderable)
                    {
                        item.Render();
                    }
                }
                DeviceManager.device.EndScene();
                DeviceManager.device.Present();

                System.Diagnostics.Debug.WriteLine(renderable.Count);
            }
        }


        public void init()
        {
            renderThread = new Thread(new ThreadStart(renderScene));
            renderThread.Start();
        }
    }
}
