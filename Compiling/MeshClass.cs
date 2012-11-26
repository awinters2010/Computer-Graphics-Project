using System;
using SlimDX.Direct3D9;
using SlimDX;
using System.Drawing;

namespace Graphics
{
    public enum MeshType
    {
        cube,
        triangle,
        cylinder,
        cone,
        teapot,
    }

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
        private Mesh objectMesh;
        public Mesh ObjectMesh { 
            get {
                return objectMesh;
            } 
            private set 
            {
                objectMesh = value;
            }
        }

        private bool _dispose = false;
        
        /// <summary>
        /// Create a mesh from a .x File
        /// </summary>
        /// <param name="filePath">The path of the file</param>
        /// <param name="fileName">The name of the file</param>
        public MeshClass(string filePath, string fileName)
        {
            objectMesh = Mesh.FromFile(DeviceManager.LocalDevice, filePath, MeshFlags.SystemMemory);
            ExtendedMaterial[] externMaterial = objectMesh.GetMaterials();
            material = new Material[externMaterial.Length];
            CurrentTexture = new Texture[externMaterial.Length];

            for (int i = 0; i < externMaterial.Length; i++)
            {
                material[i] = externMaterial[i].MaterialD3D;
                material[i].Ambient = material[i].Diffuse;

                string s = filePath;
                int index = s.IndexOf(fileName);
                s = s.Remove(index);
                s = s.Insert(index, externMaterial[i].TextureFileName);

                CurrentTexture[i] = Texture.FromFile(DeviceManager.LocalDevice, s);
            }

            ObjectPosition = Vector3.Zero;
            ObjectRotate = Vector3.Zero;
            ObjectScale = new Vector3(1, 1, 1);
            World = Matrix.Identity;
            Name = fileName;
            Type = "loadedMesh";
        }

        /// <summary>
        /// For creating shape objects
        /// </summary>
        /// <param name="type">the name of the object you wish to create</param>
        public MeshClass(MeshType type)
        {
            if (type == MeshType.cube)
            {
                objectMesh = Mesh.CreateBox(DeviceManager.LocalDevice, 1f, 1f, 1f);
            }
            else if (type == MeshType.triangle)
            {
                var ShapeVertices = new VertexUntransformed[] {
                    new VertexUntransformed() { Color = Color.White.ToArgb(), Position = new Vector3(-1f, 0f, 1f) },
                    new VertexUntransformed() { Color = Color.White.ToArgb(), Position = new Vector3(1f, 0f, 1f) },
                    new VertexUntransformed() { Color = Color.White.ToArgb(), Position = new Vector3(-1f, 0f, -1f) },
                    new VertexUntransformed() { Color = Color.White.ToArgb(), Position = new Vector3(1f, 0f, -1f) },

                    new VertexUntransformed() { Color = Color.White.ToArgb(), Position = new Vector3(0f, 1f, 0f) },
                };

                var ShapeIndices = new short[] {
                    0, 2, 1,    // base
                    1, 2, 3,
                    0, 1, 4,    // sides
                    1, 3, 4,
                    3, 2, 4,
                    2, 0, 4,
                };

                objectMesh = new Mesh(DeviceManager.LocalDevice, 100, 100, MeshFlags.WriteOnly, VertexUntransformed.VertexDecl.Elements);

                objectMesh.LockVertexBuffer(LockFlags.None).WriteRange<VertexUntransformed>(ShapeVertices);
                objectMesh.UnlockVertexBuffer();

                objectMesh.LockIndexBuffer(LockFlags.None).WriteRange<short>(ShapeIndices);
                objectMesh.UnlockIndexBuffer();
            }

            ObjectPosition = Vector3.Zero;
            ObjectRotate = Vector3.Zero;
            ObjectScale = new Vector3(1, 1, 1);
            World = Matrix.Translation(ObjectPosition);
            Name = type.ToString();
            Type = "ShapeObject";
        }

        #region releasing resources

        ~MeshClass()
        {
            if (!_dispose)
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_dispose)
            {
                if (disposing)
                {
                    if (CurrentTexture != null)
                    {
                        for (int i = 0; i < CurrentTexture.Length; i++)
                        {
                            CurrentTexture[i].Dispose();
                        }
                    }

                    objectMesh.Dispose();

                    Console.WriteLine("objects disposed");
                }

                CurrentTexture = null;
                objectMesh = null;
                _dispose = true;
            }
        }

        #endregion

        public void RenderMesh()
        {
            World = Matrix.RotationYawPitchRoll(ObjectRotate.Y, ObjectRotate.X, ObjectRotate.Z) * Matrix.Scaling(ObjectScale) * Matrix.Translation(ObjectPosition);
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

            if (objectMesh != null)
            {
                objectMesh.DrawSubset(0);
            }
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