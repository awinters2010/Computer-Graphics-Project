﻿using SlimDX.Direct3D9;
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
        public string Name { get; set; }
        public string Type { get; private set; }
        public Vector3 Scaling { get; set; }
        public Vector3 Rotation { get; set; }

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

            Position = Vector3.Zero;
            World = Matrix.Translation(Position);
            Name = "Cube";
            Selected = false;
            Type = "cube";
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