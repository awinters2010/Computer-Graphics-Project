using SlimDX.Direct3D9;
using System.Drawing;
using SlimDX;

namespace Graphics
{
    public class Cube : BasicShape
    {
        public short[] indices;
        public VertexUntransformed[] vertex;

        public Cube(Device device, Result r = new SlimDX.Result())
            : base(device)
        {
            SetUpTriangle();
        }

        private void SetUpTriangle()
        {
            vertices = new VertexBuffer(device, 8 * VertexUntransformed.VertexByteSize, Usage.WriteOnly, VertexUntransformed.format, Pool.Default);
            vertices.Lock(0, 0, LockFlags.Discard).WriteRange(new[] {
                new VertexUntransformed() { Color = Color.Red.ToArgb(), Position = new Vector3(-1f, 1f, -1f) },
                new VertexUntransformed() { Color = Color.Blue.ToArgb(), Position = new Vector3(1f, 1f, -1f) },
                new VertexUntransformed() { Color = Color.Blue.ToArgb(), Position = new Vector3(-1f, -1f, -1f) },
                new VertexUntransformed() { Color = Color.Red.ToArgb(), Position = new Vector3(1f, -1f, -1f) },
                new VertexUntransformed() { Color = Color.Red.ToArgb(), Position = new Vector3(-1f, 1f, 1f) },
                new VertexUntransformed() { Color = Color.Blue.ToArgb(), Position = new Vector3(1f, 1f, 1f) },
                new VertexUntransformed() { Color = Color.Blue.ToArgb(), Position = new Vector3(-1f, -1f, 1f) },
                new VertexUntransformed() { Color = Color.Red.ToArgb(), Position = new Vector3(1f, -1f, 1f) },

            });
            vertices.Unlock();

            short[] indices = new short[]
            {
                0,1,2,
                2,1,3,
                4,0,6,
                6,0,2,
                7,5,6,
                6,5,4,
                3,1,7,
                7,1,5,
                4,5,0,
                0,5,1,
                3,7,2,
                2,7,6,
            };

            index = new IndexBuffer(device, 36 * sizeof(short), Usage.WriteOnly, Pool.Default, true);
            index.Lock(0, 36 * sizeof(short), LockFlags.Discard).WriteRange(indices);
            index.Unlock();

            device.Indices = index;
            device.SetStreamSource(0, vertices, 0, VertexUntransformed.VertexByteSize);
            device.VertexDeclaration = VertexUntransformed.vertexDecl;

        }

        public override void Render()
        {
            device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 8, 0, 12);
            //device.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);
        }
    }
}