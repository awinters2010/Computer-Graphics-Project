using System.Collections.Generic;
using System.Threading;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Graphics
{
    public partial class MainPage
    {
        List<IShape> renderable = new List<IShape>();

        public void RenderScene()
        {
            while (true)
            {
                DeviceManager.LocalDevice.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Black, 1.0f, 0);
                DeviceManager.LocalDevice.BeginScene();
                lock (renderable)
                {
                }
                DeviceManager.LocalDevice.EndScene();
                DeviceManager.LocalDevice.Present();

                if (renderable.Count != 0 && renderThread.IsAlive)
                {
                    camera.RayCalculation(new SlimDX.Vector2(MousePosition.X, MousePosition.Y), renderable[0]);
                }
            }
        }


        public void Init()
        {
            renderThread = new Thread(new ThreadStart(RenderScene));
            renderThread.Start();
        }
    }
}
