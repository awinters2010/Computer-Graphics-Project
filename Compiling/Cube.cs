using SlimDX.Direct3D9;
using System.Drawing;
using SlimDX;

namespace Graphics
{
    public class Cube : BasicShape
    {
        public Cube(ref Device device)
            : base(ref device)
        {
        }

        public Cube(ref Device device, ref Result r)
            : base(ref device)
        {
            SetUpTriangle();
        }

        private void SetUpTriangle()
        {
            var vertice = new VertexBuffer(device, 4 * 20, Usage.WriteOnly, VertexTransformed.s, Pool.Default);
            vertice.Lock(0, 0, LockFlags.None).WriteRange(new[] {
                new VertexTransformed() { Color = Color.Red.ToArgb(), Position = new Vector4(0, 100.0f, 0f, 1.0f) },
                new VertexTransformed() { Color = Color.Blue.ToArgb(), Position = new Vector4(200, 500.0f, 0f, 1.0f) },
                new VertexTransformed() { Color = Color.Green.ToArgb(), Position = new Vector4(0, 500.0f, 0f, 1.0f) },
                new VertexTransformed() { Color=Color.Yellow.ToArgb(), Position=new Vector4(200,100,0,1)}
            });
            vertice.Unlock();

            var vertexElems = new[] {
                        new VertexElement(0, 0, DeclarationType.Float4, DeclarationMethod.Default, DeclarationUsage.PositionTransformed, 0),
                        new VertexElement(0, 16, DeclarationType.Color, DeclarationMethod.Default, DeclarationUsage.Color, 0),
                                VertexElement.VertexDeclarationEnd
                };

            var vertexDecl = new VertexDeclaration(device, vertexElems);

            device.SetStreamSource(0, vertice, 0, 20);
            device.VertexDeclaration = vertexDecl;
        }

        public override void Render()
        {
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);
        }
    }
}
