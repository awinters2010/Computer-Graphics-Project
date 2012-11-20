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
        public string Type { get; private set; }
        public Vector3 Scaling { get; set; }
        public Vector3 Rotation { get; set; }

        public Triangle()
        {
            ShapeVertices = new VertexUntransformed[] {
                    new VertexUntransformed() { Color = Color.Red.ToArgb(), Position = new Vector3(-2f, 0f, 1f) },
                    new VertexUntransformed() { Color = Color.Blue.ToArgb(), Position = new Vector3(2f, 0f, 1f) },
                    new VertexUntransformed() { Color = Color.Blue.ToArgb(), Position = new Vector3(-2f, 0f, -1f) },
                    new VertexUntransformed() { Color = Color.Red.ToArgb(), Position = new Vector3(2f, 0f, -1f) },

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

            Position = Vector3.Zero;
            World = Matrix.Translation(Position);
            Name = "Triangle";
            Selected = false;
            Type = "triangle";
            Scaling = new Vector3(1, 1, 1);
            Rotation = Vector3.Zero;
        }

        public void Rotate(float x, float y, float z)
        {
            Rotation = new Vector3(x, y, z);
        }

        public void Translate(float x, float y, float z)
        {
            Position = new Vector3(x, y, z);
        }

        public void Scale(Vector3 scale)
        {
            Scaling = scale;
        }

        public void Render()
        {
            World = Matrix.Translation(Position) * Matrix.RotationYawPitchRoll(Rotation.X, Rotation.Y, Rotation.Z) * Matrix.Scaling(Scaling);
            DeviceManager.LocalDevice.SetTransform(TransformState.World, World);
        }
    }
}