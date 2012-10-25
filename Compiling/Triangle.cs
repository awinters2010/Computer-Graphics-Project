using System;
using System.Collections.Generic;
using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Graphics
{
    public class Triangle : BasicShape
    {
        Result r;

        public Triangle(ref Device device)
            : base(ref device)
        {
        }

        public Triangle(ref Device device, ref Result r)
            : base(ref device)
        {
            SetTriangle();
            this.r = r;
        }

        private void SetTriangle()
        {
            vertices = new VertexBuffer(device, 3 * 20, Usage.WriteOnly, VertexFormat.None, Pool.Default);
            vertices.Lock(0, 0, LockFlags.None).WriteRange(new[] {
                new VertexTransformed() { Color = Color.Red.ToArgb(), Position = new Vector4(200, 100.0f, 0.5f, 1.0f) },
                new VertexTransformed() { Color = Color.Blue.ToArgb(), Position = new Vector4(400, 500.0f, 0.5f, 1.0f) },
                new VertexTransformed() { Color = Color.Green.ToArgb(), Position = new Vector4(0, 500.0f, 0.5f, 1.0f) }
            });
            vertices.Unlock();

            var vertexElems = new[] {
                        new VertexElement(0, 0, DeclarationType.Float4, DeclarationMethod.Default, DeclarationUsage.PositionTransformed, 0),
                        new VertexElement(0, 16, DeclarationType.Color, DeclarationMethod.Default, DeclarationUsage.Color, 0),
                                VertexElement.VertexDeclarationEnd
                };

            var vertexDecl = new VertexDeclaration(device, vertexElems);

            r = device.SetStreamSource(0, vertices, 0, 20);
            device.VertexDeclaration = vertexDecl;

            BasicShape.VerticesCount += 3;
        }

        public override void Render()
        {
            r = device.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
        }
    }
}
