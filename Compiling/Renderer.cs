using System.Collections.ObjectModel;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Graphics
{
    public class Renderer
    {
        private volatile bool shutdown;
        public ObservableCollection<IShape> Shapes { get; set; }
        public int verticesCount { get; set; }
        public int indiciesCount { get; set; }

        public Renderer()
        {
            shutdown = false;
            this.Shapes = new ObservableCollection<IShape>();
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

                lock (Shapes)
                {
                    if (Shapes.Count != 0)
                    {
                        for (int i = 0; i < Shapes.Count; i++)
                        {
                            if (Shapes[i].Type == "cube")
                            {
                                Shapes[i].Render();
                                DeviceManager.LocalDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, verticesCount, 0, indiciesCount / 3);
                            }
                            else if (Shapes[i].Type == "triangle")
                            {
                                Shapes[i].Render();
                                DeviceManager.LocalDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, verticesCount, 0, indiciesCount / 3);
                            }
                        }

                    }
                }

                DeviceManager.LocalDevice.EndScene();
                DeviceManager.LocalDevice.Present();
            }
        }
    }
}
