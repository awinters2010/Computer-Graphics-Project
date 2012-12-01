using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SlimDX;
using SlimDX.Direct3D9;

namespace Graphics
{
    public class Renderer
    {
        private volatile bool shutdown;

        public Terrain Terrian { get; set; }
        public List<MeshClass> Meshes { get; set; }
        public List<LightClass> Lights { get; set; }

        public Renderer()
        {
            shutdown = false;
            Meshes = new List<MeshClass>();
            Lights = new List<LightClass>();
            Lights.Add(new LightClass());
            Lights[0].LightOnOff(0);
        }

        public void RequestShutdown()
        {
            shutdown = true;
        }

        public void RenderScene()
        {
            while (!shutdown)
            {
                if (!IsDeviceLost())
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

                    lock (Lights)
                    {
                        foreach (var item in Lights)
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

        private bool IsDeviceLost()
        {
            Result result = DeviceManager.LocalDevice.TestCooperativeLevel();

            if (result == ResultCode.DeviceLost)
            {
                return true;
            }

            else if (result == ResultCode.DriverInternalError)
            {
                string s = "Error Code: " + result.Code + "\n";
                s += "Error Data: " + result.Data + "\n";
                s += "Error Description: " + result.Description + "\n";

                System.IO.File.WriteAllText("error.txt", s);
                MessageBox.Show("Interal Driver ERROR!!");
                Application.Exit();
                return true;
            }
            else if (result == ResultCode.DeviceNotReset)
            {
                DeviceManager.ResetDevice();
                return false;
            }

            return false;
        }
    }
}