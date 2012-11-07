using SlimDX.Direct3D9;
using System.Drawing;
using SlimDX;
using System;

namespace Graphics
{
    public class Cube : IShape
    {
        public bool Selected { get; set; }
        public Vector3 Position { get; set; }
        public Matrix World { get; private set; }
        public short[] ShapeIndices { get; private set; }
        public VertexUntransformed[] ShapeVertices { get; private set; }

        public Cube()
        {
            ShapeVertices = new VertexUntransformed[] {
                    new VertexUntransformed() { Color = Color.Red.ToArgb(), Position = new Vector3(-1f, 1f, -1f) },
                    new VertexUntransformed() { Color = Color.Blue.ToArgb(), Position = new Vector3(1f, 1f, -1f) },
                    new VertexUntransformed() { Color = Color.Blue.ToArgb(), Position = new Vector3(-1f, -1f, -1f) },
                    new VertexUntransformed() { Color = Color.Red.ToArgb(), Position = new Vector3(1f, -1f, -1f) },
                    new VertexUntransformed() { Color = Color.Red.ToArgb(), Position = new Vector3(-1f, 1f, 1f) },
                    new VertexUntransformed() { Color = Color.Blue.ToArgb(), Position = new Vector3(1f, 1f, 1f) },
                    new VertexUntransformed() { Color = Color.Blue.ToArgb(), Position = new Vector3(-1f, -1f, 1f) },
                    new VertexUntransformed() { Color = Color.Red.ToArgb(), Position = new Vector3(1f, -1f, 1f) }
                };
            
            ShapeIndices = new short[] {
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