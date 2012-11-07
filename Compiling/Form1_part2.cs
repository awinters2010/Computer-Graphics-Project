﻿using System.Collections.Generic;
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

                if (renderable.Count != 0 && renderThread.IsAlive)
                {
                    camera.RayCalculaton(new SlimDX.Vector2(MousePosition.X, MousePosition.Y), renderable[0]);
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
