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

        public Terrain Terrian { get; set; }
        public int verticesCount { get; set; }
        public int indiciesCount { get; set; }
        public List<MeshClass> Meshes { get; set; }
        public List<Lights> light { get; set; }

        public Renderer()
        {
            shutdown = false;
            Meshes = new List<MeshClass>();
            light = new List<Lights>();
            light.Add(new Lights());
            light[0].LightOnOff(0);
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

                lock (light)
                {
                    foreach (var item in light)
                    {
                        item.Render();
                    }
                }

                if (Terrian != null)
                {
                    Terrian.Render();
                }

                DeviceManager.LocalDevice.EndScene();
                DeviceManager.LocalDevice.Present();
            }
        }
    }
}