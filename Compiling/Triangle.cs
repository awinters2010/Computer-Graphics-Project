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

        public Triangle()
        { 
            
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
