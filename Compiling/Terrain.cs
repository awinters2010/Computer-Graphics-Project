using System;
using SlimDX.Direct3D9;
using SlimDX;
using System.Drawing;

namespace Graphics
{
    public class Terrain : IDisposable
    {
        private Mesh mesh;
        private int[,] height;
        private Random rand;
        private int width, tall;

        public Terrain()
        {
            rand = new Random();

            width = rand.Next(1, 50);
            tall = rand.Next(1, 50);

            height = new int[width, tall];

            var vertices = new CustomVertex.VertexPositionColor[width * tall];
            var indicies = new short[(width - 1) * (tall - 1) * 3];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < tall; j++)
                {
                    height[i, j] = rand.Next(0, 6);
                    vertices[i + j * width].Position = new Vector3(i, j, height[i,j]);
                    vertices[i + j * width].Color = Color.White.ToArgb();
                }
            }

            for (int i = 0; i < width - 1; i++)
            {
                for (int j = 0; j < tall - 1; j++)
                {
                    indicies[(i + j * (width - 1)) * 3] = (short)((i + 1) + (j + 1) * width);
                    indicies[(i + j * (width - 1)) * 3 + 1] = (short)((i + 1) + j * width);
                    indicies[(i + j * (width - 1)) * 3 + 2] = (short)(i + j * width);
                }
            }

            mesh = new Mesh(DeviceManager.LocalDevice, width * tall, width * tall, 
                MeshFlags.Managed, CustomVertex.VertexPositionColor.Format);

            mesh.LockVertexBuffer(LockFlags.Discard).WriteRange<CustomVertex.VertexPositionColor>(vertices);
            mesh.UnlockVertexBuffer();

            mesh.LockIndexBuffer(LockFlags.Discard).WriteRange<short>(indicies);
            mesh.UnlockIndexBuffer();

            mesh.Optimize(MeshOptimizeFlags.AttributeSort | MeshOptimizeFlags.Compact);
        }

        public void Render()
        {
            if (mesh != null)
            {
                mesh.DrawSubset(0);
            }
        }

        public void Dispose()
        {
            mesh.Dispose();
        }
    }
}
