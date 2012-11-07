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
                DeviceManager.Device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Black, 1.0f, 0);
                DeviceManager.Device.BeginScene();
                lock (renderable)
                {
                    foreach (var item in renderable)
                    {
                        item.Render();
                    }
                }
                DeviceManager.Device.EndScene();
                DeviceManager.Device.Present();

                if (renderable.Count != 0 && renderThread.IsAlive)
                {
                    camera.RayCalculation(new SlimDX.Vector2(MousePosition.X, MousePosition.Y), renderable[0]);
                }
            }
        }


        public void init()
        {
            renderThread = new Thread(new ThreadStart(renderScene));
            renderThread.Start();
        }
    }
}
