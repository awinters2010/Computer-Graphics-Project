using System;
using System.Collections.Generic;
using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Graphics
{
    public class Triangle : IShape
    {
        public bool Selected { get; set; }
        public Vector3 Position { get; set; }
        public Matrix World { get; private set; }
        public short[] ShapeIndices { get; private set; }
        public VertexUntransformed[] ShapeVertices { get; private set; }
        public string Name { get; set; }

        public Triangle()
        {
            ShapeVertices = new VertexUntransformed[] {
                    new VertexUntransformed() { Color = Color.Red.ToArgb(), Position = new Vector3(-1f, 0f, 1f) },
                    new VertexUntransformed() { Color = Color.Blue.ToArgb(), Position = new Vector3(1f, 0f, 1f) },
                    new VertexUntransformed() { Color = Color.Blue.ToArgb(), Position = new Vector3(-1f, 0f, -1f) },
                    new VertexUntransformed() { Color = Color.Red.ToArgb(), Position = new Vector3(1f, 0f, -1f) },

                    new VertexUntransformed() { Color = Color.Orange.ToArgb(), Position = new Vector3(0f, 1f, 0f) },
                };

            ShapeIndices = new short[] {
                0, 2, 1,    // base
                1, 2, 3,
                0, 1, 4,    // sides
                1, 3, 4,
                3, 2, 4,
                2, 0, 4,
            };
        }

        public void Rotate()
        {
            throw new NotImplementedException();
        }

        public void Translate()
        {
            throw new NotImplementedException();
        }

        public void Scale()
        {
            throw new NotImplementedException();
        }
    }
}