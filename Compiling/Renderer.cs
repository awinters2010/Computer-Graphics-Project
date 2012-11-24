using System.Collections.ObjectModel;
using SlimDX.Direct3D9;
using System.Drawing;
using System.Collections.Generic;
using System;

namespace Graphics
{
    public class Renderer
    {
        private volatile bool shutdown;
        public int verticesCount { get; set; }
        public int indiciesCount { get; set; }
        public List<MeshClass> Meshes { get; set; }

        public Renderer()
        {
            shutdown = false;
            Meshes = new List<MeshClass>();
        }

        public void RequestShutdown()
        {
            shutdown = true;
        }

        public void RenderScene()
        {
            while (!shutdown)
            {
                DeviceManager.LocalDevice.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Black, 1.0f, 0);
                DeviceManager.LocalDevice.BeginScene();

                lock (Meshes)
                {
                    foreach (var item in Meshes)
                    {
                        item.RenderMesh();
                    }
                }

                DeviceManager.LocalDevice.EndScene();
                DeviceManager.LocalDevice.Present();
            }
        }
    }
}