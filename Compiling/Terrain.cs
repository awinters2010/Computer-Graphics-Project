using System;
using SlimDX.Direct3D9;
using SlimDX;
using System.Drawing;
using System.IO;

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
            FileStream fs = new FileStream("heightdata.raw", FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);
            rand = new Random();

            width = rand.Next(2, 100);//64;//rand.Next(2, 50);
            tall = rand.Next(2, 100);//64;//rand.Next(2, 50);

            height = new int[width, tall];

            var vertices = new CustomVertex.VertexPositionColor[width * tall];
            var indicies = new short[(width - 1) * (tall - 1) * 3];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < tall; j++)
                {
                    //height[width - 1 - j, tall - 1 - i] = (int)(r.ReadByte() / 50);
                    height[i, j] = rand.Next(0, 3);
                }
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < tall; j++)
                {
                    vertices[i + j * width].Position = new Vector3(i, height[i, j], j);
                    vertices[i + j * width].Color = Color.White.ToArgb();
                }
            }

            for (int i = 0; i < width - 1; i++)
            {
                for (int j = 0; j < tall - 1; j++)
                {
                    Console.WriteLine((i + 1) + (j + 1) * width);
                    indicies[(i + j * (width - 1)) * 3] = (short)((i + 1) + (j + 1) * width);
                    indicies[(i + j * (width - 1)) * 3 + 1] = (short)((i + 1) + j * width);
                    indicies[(i + j * (width - 1)) * 3 + 2] = (short)(i + j * width);
                }
            }

            
            mesh = new Mesh(DeviceManager.LocalDevice, indicies.Length, vertices.Length, 
                MeshFlags.Managed, CustomVertex.VertexPositionColor.Format);

            mesh.LockVertexBuffer(LockFlags.Discard).WriteRange<CustomVertex.VertexPositionColor>(vertices);
            mesh.UnlockVertexBuffer();

            mesh.LockIndexBuffer(LockFlags.Discard).WriteRange<short>(indicies);
            mesh.UnlockIndexBuffer();

            mesh.Optimize(MeshOptimizeFlags.AttributeSort | MeshOptimizeFlags.Compact);

            r.Dispose();
            fs.Dispose();
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

            Console.WriteLine("Terrian Disposed");
        }
    }
}
