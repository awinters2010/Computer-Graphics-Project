using SlimDX.Direct3D9;
using System.Drawing;
using SlimDX;

namespace Graphics
{
    public class Cube : BasicShape
    {
        public Cube(ref Device device, Result r = new SlimDX.Result())
            : base(ref device)
        {
            SetUpTriangle();
        }

        private void SetUpTriangle()
        {
            var vertice = new VertexBuffer(device, 8 * VertexUntransformed.VertexByteSize, Usage.WriteOnly, VertexUntransformed.format, Pool.Default);
            vertice.Lock(0, 0, LockFlags.None).WriteRange(new[] {
                new VertexUntransformed() { Color = Color.Red.ToArgb(), Position = new Vector3(-1f, 1f, 0f) },
                new VertexUntransformed() { Color = Color.Blue.ToArgb(), Position = new Vector3(1f, 1f, 0f) },
                new VertexUntransformed() { Color = Color.Blue.ToArgb(), Position = new Vector3(-1f, -1f, 0f) },
                new VertexUntransformed() { Color = Color.Red.ToArgb(), Position = new Vector3(1f, -1f, 0f) },
                new VertexUntransformed() { Color = Color.Yellow.ToArgb(),Position = new Vector3(-1f, 1f, 1f) },
                new VertexUntransformed() { Color = Color.Orange.ToArgb(),Position = new Vector3(1f, 1f, 1f) },
                new VertexUntransformed() { Color = Color.Orange.ToArgb(),Position = new Vector3(-1f, -1f, 1f) },
                new VertexUntransformed() { Color = Color.Yellow.ToArgb(),Position = new Vector3(1f, -1f, 1f) }

            });
            vertice.Unlock();

            var vertexElems = new[] {
                        new VertexElement(0, 0, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position, 0),
                        new VertexElement(0, 12, DeclarationType.Color, DeclarationMethod.Default, DeclarationUsage.Color, 0),
                                VertexElement.VertexDeclarationEnd
                };

            var vertexDecl = new VertexDeclaration(device, vertexElems);

            device.SetStreamSource(0, vertice, 0, VertexUntransformed.VertexByteSize);
            device.VertexDeclaration = vertexDecl;
        }

        public override void Render()
        {
            device.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);
        }
    }
}
