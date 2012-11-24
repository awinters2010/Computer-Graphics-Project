using System;
using SlimDX.Direct3D9;
using SlimDX;
using System.Drawing;

namespace Graphics
{
    public class MeshClass : IDisposable
    {
        public Texture[] CurrentTexture { get; set; }
        public Vector3 ObjectPosition { get; set; }
        public Matrix World { get; set; }
        public Vector3 ObjectRotate { get; set; }
        public string Type { get; private set; }
        public string Name { get; set; }
        public Vector3 ObjectScale { get; set; }

        private Material[] material;
        private Mesh mesh;

        /// <summary>
        /// Create a mesh from a .x File
        /// </summary>
        /// <param name="filePath">The path of the file</param>
        /// <param name="fileName">The name of the file</param>
        public MeshClass(string filePath, string fileName)
        {
            mesh = Mesh.FromFile(DeviceManager.LocalDevice, filePath, MeshFlags.SystemMemory);
            ExtendedMaterial[] m = mesh.GetMaterials();
            material = new Material[m.Length];
            CurrentTexture = new Texture[m.Length];

            for (int i = 0; i < m.Length; i++)
            {
                material[i] = m[i].MaterialD3D;
                material[i].Ambient = material[i].Diffuse;

                string s = filePath;
                int index = s.IndexOf(fileName);
                string tex = s.Remove(index);
                s = tex.Insert(index, m[i].TextureFileName);

                CurrentTexture[i] = Texture.FromFile(DeviceManager.LocalDevice, s);
            }

            ObjectPosition = Vector3.Zero;
            ObjectRotate = Vector3.Zero;
            World = Matrix.Identity;
            Name = fileName;
        }

        /// <summary>
        /// For creating shape objects
        /// </summary>
        /// <param name="type">the name of the object you wish to create</param>
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
            }

            ObjectPosition = Vector3.Zero;
            ObjectRotate = Vector3.Zero;
            World = Matrix.Translation(ObjectPosition);
            Name = type;
        }

        #region releasing resources

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

        #endregion

        public void RenderMesh()
        {
            World = Matrix.Translation(ObjectPosition);
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

        /// <summary>
        /// To apply Color to the object
        /// </summary>
        /// <param name="ambient">The ambient color (color of the whole object)</param>
        public void ColorMesh(Color ambient)
        {
            this.material[0].Ambient = ambient;
            this.material[0].Diffuse = Color.White;
            this.material[0].Specular = Color.White;
            this.material[0].Emissive = Color.White;
            this.material[0].Power = 1.0f;
        }

        /// <summary>
        /// To apply Color to the object
        /// </summary>
        /// <param name="ambient">The ambient color (color of the whole object)</param>
        /// <param name="diffuse"></param>
        public void ColorMesh(Color ambient, Color diffuse)
        {
            this.material[0].Ambient = ambient;
            this.material[0].Diffuse = diffuse;
            this.material[0].Specular = Color.White;
            this.material[0].Emissive = Color.White;
            this.material[0].Power = 1.0f;
        }

        /// <summary>
        /// To apply Color to the object
        /// </summary>
        /// <param name="ambient">The ambient color (color of the whole object)</param>
        /// <param name="diffuse"></param>
        /// <param name="specular"></param>
        public void ColorMesh(Color ambient, Color diffuse, Color specular)
        {
            this.material[0].Ambient = ambient;
            this.material[0].Diffuse = diffuse;
            this.material[0].Specular = specular;
            this.material[0].Emissive = Color.White;
            this.material[0].Power = 1.0f;
        }

        /// <summary>
        /// To apply Color to the object
        /// </summary>
        /// <param name="ambient">The ambient color (color of the whole object)</param>
        /// <param name="diffuse"></param>
        /// <param name="specular"></param>
        /// <param name="emissive"></param>
        public void ColorMesh(Color ambient, Color diffuse, Color specular, Color emissive)
        {
            this.material[0].Ambient = ambient;
            this.material[0].Diffuse = diffuse;
            this.material[0].Specular = specular;
            this.material[0].Emissive = emissive;
            this.material[0].Power = 1.0f;
        }

        /// <summary>
        /// To apply Color to the object
        /// </summary>
        /// <param name="ambient">The ambient color (color of the whole object)</param>
        /// <param name="diffuse"></param>
        /// <param name="specular"></param>
        /// <param name="emissive"></param>
        /// <param name="power"></param>
        public void ColorMesh(Color ambient, Color diffuse, Color specular, Color emissive, float power)
        {
            this.material[0].Ambient = ambient;
            this.material[0].Diffuse = diffuse;
            this.material[0].Specular = specular;
            this.material[0].Emissive = emissive;
            this.material[0].Power = power;
        }

        /// <summary>
        /// To apply a user supplied texture to the object
        /// </summary>
        /// <param name="filePath">The string path of the file</param>
        /// <param name="fileName">The string name of the file</param>
        public void ApplyTextureMesh(string filePath, string fileName)
        {
            this.CurrentTexture[0] = Texture.FromFile(DeviceManager.LocalDevice, filePath);
        }


        public void Rotate(float x, float y, float z)
        {
            ObjectRotate = new Vector3(x, y, z);
        }

        public void Translate(float x, float y, float z)
        {
            ObjectPosition = new Vector3(x, y, z);
        }

        public void Scale(Vector3 scale)
        {
            ObjectScale = scale;
        }
    }
}