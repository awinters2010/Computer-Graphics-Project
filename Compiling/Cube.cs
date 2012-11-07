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
        public Matrix World { get; set; }
        public short[] ShapeIndices { get; set; }
        public VertexUntransformed[] ShapeVertices { get; set; }


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