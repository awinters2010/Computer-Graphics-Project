using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Graphics
{
    public interface IShape
    {
        bool Selected { get; set; }
        Vector3 Position { get; set; }
        Matrix World { get; }
        VertexUntransformed[] ShapeVertices { get; }
        short[] ShapeIndices { get; }

        void Rotate();
        void Translate();
        void Scale();
    }
}
