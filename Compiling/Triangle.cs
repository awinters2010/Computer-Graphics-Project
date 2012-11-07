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
        public Matrix World { get; set; }
        public short[] ShapeIndices { get; set; }
        public VertexUntransformed[] ShapeVertices { get; set; }

        private Result errorResult;
        private const int triangleVerticies = 3;

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
