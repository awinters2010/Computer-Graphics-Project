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
            /*
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
             * */

            VertexUntransformed[] vertex = 
            {
                new VertexUntransformed() { Position = new Vector3(0f, 1, 5), Color = Color.Orange.ToArgb() },
                new VertexUntransformed() { Position = new Vector3(1, -1, 5), Color = Color.Purple.ToArgb() },
                new VertexUntransformed() { Position = new Vector3(-1, -1, 5),Color = Color.Gray.ToArgb() },
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
