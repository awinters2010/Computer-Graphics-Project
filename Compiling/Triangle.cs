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
        private const int triangleVerticies = 3;

        public Triangle(Device device, Result r = new SlimDX.Result())
            : base(device)
        {
            SetTriangle(Color.Red, Color.Blue, Color.Green);
            this.r = r;
        }

        public void SetTriangle(Color c1, Color c2, Color c3)
        {
            VertexUntransformed[] vertex = 
            {
                new VertexUntransformed() { Position = new Vector3(0f, 1, 5), Color = c1.ToArgb() },
                new VertexUntransformed() { Position = new Vector3(1, -1, 5), Color = c2.ToArgb() },
                new VertexUntransformed() { Position = new Vector3(-1, -1, 5),Color = c3.ToArgb() },
            };

            vertices = new VertexBuffer(device, triangleVerticies * VertexUntransformed.VertexByteSize, Usage.WriteOnly, VertexFormat.None, Pool.Default);
            vertices.Lock(0, 0, LockFlags.None).WriteRange(vertex);
            vertices.Unlock();

            var vertexElems = new[] {
                        new VertexElement(0, 0, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position, 0),
                        new VertexElement(0, 12, DeclarationType.Color, DeclarationMethod.Default, DeclarationUsage.Color, 0),
                                VertexElement.VertexDeclarationEnd
                };

            BasicShape.VerticesCount += triangleVerticies;

            var vertexDecl = new VertexDeclaration(device, vertexElems);

            r = device.SetStreamSource(0, vertices, 0, VertexUntransformed.VertexByteSize);
            device.VertexDeclaration = vertexDecl;
        }

        public override void Render()
        {
            r = device.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
        }
    }
}
