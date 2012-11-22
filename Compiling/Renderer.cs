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
        public ObservableCollection<IShape> Shapes { get; set; }
        public int verticesCount { get; set; }
        public int indiciesCount { get; set; }
        public List<MeshClass> Meshes { get; set; }
        private VertexBuffer vBuffer;
        private IndexBuffer iBuffer;

        public Renderer()
        {
            shutdown = false;
            this.Shapes = new ObservableCollection<IShape>();
            Meshes = new List<MeshClass>();
            Shapes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Shapes_CollectionChanged);
        }

        public void RequestShutdown()
        {
            shutdown = true;
        }

        void Shapes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            verticesCount += Shapes[e.NewStartingIndex].ShapeVertices.Length;
            indiciesCount += Shapes[e.NewStartingIndex].ShapeIndices.Length;

            List<VertexUntransformed> v = new List<VertexUntransformed>();
            List<short> i = new List<short>();

            foreach (var item in Shapes)
            {
                v.AddRange(item.ShapeVertices);
                i.AddRange(item.ShapeIndices);
            }

            vBuffer = new VertexBuffer(DeviceManager.LocalDevice, verticesCount * VertexUntransformed.VertexByteSize, Usage.Dynamic, VertexUntransformed.format, Pool.Default);
            vBuffer.Lock(0, verticesCount * VertexUntransformed.VertexByteSize, LockFlags.Discard).WriteRange(v.ToArray());
            vBuffer.Unlock();

            iBuffer = new IndexBuffer(DeviceManager.LocalDevice, indiciesCount * sizeof(short), Usage.WriteOnly, Pool.Default, true);
            iBuffer.Lock(0, indiciesCount * sizeof(short), LockFlags.Discard).WriteRange(i.ToArray());
            iBuffer.Unlock();

            DeviceManager.LocalDevice.Indices = iBuffer;
            DeviceManager.LocalDevice.SetStreamSource(0, vBuffer, 0, VertexUntransformed.VertexByteSize);
            DeviceManager.LocalDevice.VertexDeclaration = VertexUntransformed.VertexDecl;

            Console.WriteLine(Environment.WorkingSet / 1048576);

            vBuffer.Dispose();
            iBuffer.Dispose();
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
