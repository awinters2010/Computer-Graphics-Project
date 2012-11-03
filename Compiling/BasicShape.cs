using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Graphics
{
    /// <summary>
    /// The structure to draw vertices on the screen in transformed space (2D).
    /// </summary>
    struct VertexTransformed
    {
        public Vector4 Position { get; set; }
        public int Color { get; set; }

        public static VertexFormat s = VertexFormat.PositionRhw | VertexFormat.Diffuse;
    }

    /// <summary>
    /// Basic class for creating primitive shapes
    /// </summary>
    public abstract class BasicShape : IDisposable
    {
        public Device device { get; set; }

        //static method for counting how many vertices are being created/drawn
        public static int VerticesCount = 0;

        protected VertexBuffer vertices;

        protected IndexBuffer index;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="device">the current graphics device being used</param>
        public BasicShape(Device device)
        {
            this.device = device;
        }

        /// <summary>
        /// for rendering the shape on the screen
        /// </summary>
        public virtual void Render() { }

        public void Dispose()
        {
            vertices.Dispose();
        }
    }
}
