using System;
using SlimDX.Direct3D9;
using SlimDX;
using System.Drawing;

namespace Graphics
{
    public class MeshClass : IDisposable
    {
        public Texture[] CurrentTexture { get; set; }
        private Material[] material;
        public Mesh mesh;
        public Vector3 Position { get; set; }
        public Matrix World { get; set; }
        public Vector3 Roate { get; set; }
        public string Type { get; private set; }
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        public MeshClass(string file, string fileName)
        {
            mesh = Mesh.FromFile(DeviceManager.LocalDevice, file, MeshFlags.SystemMemory);
            ExtendedMaterial[] m = mesh.GetMaterials();
            material = new Material[m.Length];
            CurrentTexture = new Texture[m.Length];

            for (int i = 0; i < m.Length; i++)
            {
                material[i] = m[i].MaterialD3D;
                material[i].Ambient = material[i].Diffuse;

                string s = file;
                int index = s.IndexOf(fileName);
                string tex = s.Remove(index);
                s = tex.Insert(index, m[i].TextureFileName);

                CurrentTexture[i] = Texture.FromFile(DeviceManager.LocalDevice, s);
            }

            Position = Vector3.Zero;
            World = Matrix.Identity;
            Name = fileName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public MeshClass(string type)
        {
            if (type == "cube")
            {
                mesh = Mesh.CreateBox(DeviceManager.LocalDevice, 1f, 1f, 1f);
            }
            else if (type == "triangle")
            {
                var ShapeVertices = new VertexUntransformed[] {
                    new VertexUntransformed() { Color = Color.Red.ToArgb(), Position = new Vector3(-2f, 0f, 1f) },
                    new VertexUntransformed() { Color = Color.Blue.ToArgb(), Position = new Vector3(2f, 0f, 1f) },
                    new VertexUntransformed() { Color = Color.Blue.ToArgb(), Position = new Vector3(-2f, 0f, -1f) },
                    new VertexUntransformed() { Color = Color.Red.ToArgb(), Position = new Vector3(2f, 0f, -1f) },

                    new VertexUntransformed() { Color = Color.Orange.ToArgb(), Position = new Vector3(0f, 1f, 0f) },
                };

                var ShapeIndices = new short[] {
                    0, 2, 1,    // base
                    1, 2, 3,
                    0, 1, 4,    // sides
                    1, 3, 4,
                    3, 2, 4,
                    2, 0, 4,
                };

                mesh = new Mesh(DeviceManager.LocalDevice, 100, 100, MeshFlags.WriteOnly, VertexUntransformed.VertexDecl.Elements);

                mesh.LockVertexBuffer(LockFlags.None).WriteRange<VertexUntransformed>(ShapeVertices);
                mesh.UnlockVertexBuffer();

                mesh.LockIndexBuffer(LockFlags.None).WriteRange<short>(ShapeIndices);
                mesh.UnlockIndexBuffer();

                //mesh = new Mesh(DeviceManager.LocalDevice, faceCount, vertexCount, options, vDec);
            }

            Position = Vector3.Zero;
            World = Matrix.Translation(Position);
            Name = type;
        }

        ~MeshClass()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (CurrentTexture != null)
            {
                for (int i = 0; i < CurrentTexture.Length; i++)
                {
                    CurrentTexture[i].Dispose();
                }
            }

            mesh.Dispose();
        }

        public void RenderMesh()
        {
            World = Matrix.Translation(Position);
            DeviceManager.LocalDevice.SetTransform(TransformState.World, World);

            if (material != null)
            {
                foreach (var item in material)
                {
                    DeviceManager.LocalDevice.Material = item;
                }
            }

            if (CurrentTexture != null)
            {
                foreach (var item in CurrentTexture)
                {
                    DeviceManager.LocalDevice.SetTexture(0, item);
                }
            }

            mesh.DrawSubset(0);
        }


    }
}