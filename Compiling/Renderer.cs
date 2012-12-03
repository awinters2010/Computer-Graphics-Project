using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SlimDX;
using SlimDX.Direct3D9;
using System.Diagnostics;

namespace Graphics
{
    public class Renderer
    {
        private volatile bool shutdown;

        public Terrain Terrian { get; set; }
        public List<MeshClass> Meshes { get; set; }
        public List<LightClass> Lights { get; set; }
        public bool IsGlobalLightOn { get; set; }
        private bool gravity;
        public bool Gravity {
            get
            {
                return gravity;
            }
            set
            {
                if (value)
                {
                    gravity = value;
                    gravityTimer.Start();
                    gravityTimer.Restart();
                }
                else
                {
                    gravityTimer.Reset();
                }
            }
        }

        private Stopwatch gravityTimer;

        public Renderer()
        {
            shutdown = false;
            Meshes = new List<MeshClass>();
            Lights = new List<LightClass>();
            IsGlobalLightOn = false;
            gravityTimer = new Stopwatch();
            Gravity = false;
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

                            if (Gravity)
                            {
                                float speed = (gravityTimer.ElapsedMilliseconds * .05f) / 1000;
                                float newPosition = item.ObjectPosition.Y - speed;

                                if (Terrian != null && item.ObjectPosition.X >= 0 && item.ObjectPosition.X < Terrian.Height.Length)
                                {
                                    float terrainHeight = Terrian.Height[(int)item.ObjectPosition.X, (int)item.ObjectPosition.Z] + (item.ObjectScale.Y / 2);
                                    newPosition = newPosition < terrainHeight ? terrainHeight : newPosition;
                                }
                                

                                item.Translate(item.ObjectPosition.X, newPosition, item.ObjectPosition.Z);
                            }
                        }
                    }

                    lock (Lights)
                    {
                        if (!IsGlobalLightOn)
                        {
                            foreach (var item in Lights)
                            {
                                item.Render();
                            }
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

                if (System.IO.File.Exists("error.txt"))
                {
                    System.IO.File.AppendAllText("error.txt", s);
                }
                else
                {
                    System.IO.File.WriteAllText("error.txt", s);
                }

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