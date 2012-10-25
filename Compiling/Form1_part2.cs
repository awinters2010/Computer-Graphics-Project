using System.Collections.Generic;
using System.Threading;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Graphics
{
    public partial class Form1
    {
        List<BasicShape> renderable = new List<BasicShape>();

        /// <summary>
        /// Delegate to update things
        /// </summary>
        /// <param name="text">the upated text</param>
        private delegate void update(string text);

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

        private void UpdateText()
        {
            while (true)
            {
                lblMemoryUsage.Invoke(new update(this.LblUpdate),
                    new object[] { (System.Diagnostics.Process.GetCurrentProcess().PrivateMemorySize64 / 1048576).ToString() });
                lblMem.Invoke(new update(this.OLblUpdate),
                    new object[] { "Vertices: " + BasicShape.VerticesCount.ToString() });
            }
        }

        public void init()
        {
            renderThread = new Thread(new ThreadStart(renderScene));
            renderThread.Start();

            status = new Thread(new ThreadStart(UpdateText));
            status.Start();
        }
    }
}
