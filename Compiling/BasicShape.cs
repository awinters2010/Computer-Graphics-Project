﻿using System;
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

    struct VertexUntransformed
    {
        public Vector3 Position { get; set; }
        public int Color { get; set; }

        public static VertexFormat format = VertexFormat.Position | VertexFormat.Diffuse;
        public const int VertexByteSize = 16;
    }

    /// <summary>
    /// Basic class for creating primitive shapes
    /// </summary>
    public class BasicShape
    {
        public Device device { get; set; }

        //static method for counting how many vertices are being created/drawn
        public static int VerticesCount = 0;

        protected VertexBuffer vertices;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="device">the current graphics device being used</param>
        public BasicShape(ref Device device)
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
