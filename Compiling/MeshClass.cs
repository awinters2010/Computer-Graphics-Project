using System;
using SlimDX.Direct3D9;
using SlimDX;
using System.Drawing;

namespace Graphics
{
    public enum MeshType
    {
        Cube,
        Triangle,
        Cylinder,
        Cone,
        Teapot,
    }

    public class MeshClass : IDisposable
    {
        public Texture[] CurrentTexture { get; set; }
        public Vector3 ObjectPosition { get; set; }
        public Vector3 ObjectRotate { get; set; }
        public bool IsShapeObject { get; private set; }
        public string Name { get; set; }
        public Vector3 ObjectScale { get; set; }

        private Material[] material;
        private Mesh objectMesh;
        private Matrix world;

        public Mesh ObjectMesh
        {
            get
            {
                return objectMesh;
            }
        }

        public string MeshColor
        {
            get
            {
                if (material != null)
                {
                    return material[0].Ambient.ToString();
                }

                return "No Color";
            }
        }

        /// <summary>
        /// Create a mesh from a .x File
        /// </summary>
        /// <param name="filePath">The path of the file</param>
        /// <param name="fileName">The name of the file</param>
        public MeshClass(string filePath, string fileName)
        {
            objectMesh = Mesh.FromFile(DeviceManager.LocalDevice, filePath, MeshFlags.Managed);
            ExtendedMaterial[] externMaterial = objectMesh.GetMaterials();
            material = new Material[externMaterial.Length];
            CurrentTexture = new Texture[externMaterial.Length];

            for (int i = 0; i < externMaterial.Length; i++)
            {
                material[i] = externMaterial[i].MaterialD3D;
                material[i].Ambient = material[i].Diffuse;

                string s = filePath;
                int index = s.IndexOf(fileName);
                s = s.Remove(s.IndexOf(fileName));
                s = s.Insert(index, externMaterial[i].TextureFileName);

                CurrentTexture[i] = Texture.FromFile(DeviceManager.LocalDevice, s);
            }

            //objectMesh.Optimize(MeshOptimizeFlags.Compact | MeshOptimizeFlags.AttributeSort);

            ObjectPosition = Vector3.Zero;
            ObjectRotate = Vector3.Zero;
            ObjectScale = new Vector3(1, 1, 1);
            world = Matrix.Identity;
            Name = fileName;
            IsShapeObject = false;
        }

        /// <summary>
        /// For creating shape objects
        /// </summary>
        /// <param name="type">the name of the object you wish to create</param>
        public MeshClass(MeshType type)
        {
            if (type == MeshType.Cube)
            {
                objectMesh = Mesh.CreateBox(DeviceManager.LocalDevice, 1f, 1f, 1f);

                objectMesh.ComputeNormals();

                objectMesh.Optimize(MeshOptimizeFlags.Compact);

                ApplyColor(Color.White);
            }
            else if (type == MeshType.Triangle)
            {
                var ShapeVertices = new CustomVertex.VertexPositionColor[] {
                    new CustomVertex.VertexPositionColor() { Color = Color.White.ToArgb(), Position = new Vector3(-1f, 0f, 1f) },
                    new CustomVertex.VertexPositionColor() { Color = Color.White.ToArgb(), Position = new Vector3(1f, 0f, 1f) },
                    new CustomVertex.VertexPositionColor() { Color = Color.White.ToArgb(), Position = new Vector3(-1f, 0f, -1f) },
                    new CustomVertex.VertexPositionColor() { Color = Color.White.ToArgb(), Position = new Vector3(1f, 0f, -1f) },
                    new CustomVertex.VertexPositionColor() { Color = Color.White.ToArgb(), Position = new Vector3(0f, 1f, 0f) },
                };

                var ShapeIndices = new short[] {
                    0, 2, 1,    // base
                    1, 2, 3,
                    0, 1, 4,    // sides
                    1, 3, 4,
                    3, 2, 4,
                    2, 0, 4,
                };

                objectMesh = new Mesh(DeviceManager.LocalDevice, ShapeIndices.Length, ShapeVertices.Length, MeshFlags.Managed, VertexFormat.Position | VertexFormat.Diffuse);

                objectMesh.LockVertexBuffer(LockFlags.None).WriteRange<CustomVertex.VertexPositionColor>(ShapeVertices);
                objectMesh.UnlockVertexBuffer();

                objectMesh.LockIndexBuffer(LockFlags.None).WriteRange<short>(ShapeIndices);
                objectMesh.UnlockIndexBuffer();

                Mesh other = objectMesh.Clone(DeviceManager.LocalDevice, MeshFlags.Managed, objectMesh.VertexFormat | VertexFormat.Normal | VertexFormat.Texture2);
                objectMesh.Dispose();
                objectMesh = null;
                other.ComputeNormals();
                objectMesh = other.Clone(DeviceManager.LocalDevice, MeshFlags.Managed, other.VertexFormat);
                other.Dispose();

                objectMesh.Optimize(MeshOptimizeFlags.Compact);
            }

            ObjectPosition = Vector3.Zero;
            ObjectRotate = Vector3.Zero;
            ObjectScale = new Vector3(1, 1, 1);
            world = Matrix.Translation(ObjectPosition);
            Name = type.ToString();
            IsShapeObject = true;
        }

        #region releasing resources

        public void Dispose()
        {
            Dispose(true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (CurrentTexture != null)
                {
                    foreach (var ct in CurrentTexture)
                    {
                        ct.Dispose();
                    }
                }

                objectMesh.Dispose();
            }

            CurrentTexture = null;
            objectMesh = null;
        }

        #endregion

        public void RenderMesh()
        {
            world = Matrix.RotationYawPitchRoll(ObjectRotate.Y, ObjectRotate.X, ObjectRotate.Z) * Matrix.Scaling(ObjectScale) * Matrix.Translation(ObjectPosition);
            DeviceManager.LocalDevice.SetTransform(TransformState.World, world);

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
        /// Apply a color to a mesh
        /// </summary>
        /// <param name="color">The color you wish you apply</param>
        public void ApplyColor(Color color)
        {
            material = new Material[1];
            material[0].Ambient = color;
            material[0].Diffuse = color;
            material[0].Specular = color;
            material[0].Emissive = Color.Black;
            material[0].Power = 50.0f;
        }

        /// <summary>
        /// To apply a user supplied texture to the object
        /// </summary>
        /// <param name="filePath">The string path of the file</param>
        /// <param name="fileName">The string name of the file</param>
        public void ApplyTextureMesh(string filePath, string fileName)
        {
            lock (objectMesh)
            {
                Mesh other = objectMesh.Clone(DeviceManager.LocalDevice, MeshFlags.UseHardwareOnly,
                    VertexFormat.Position | VertexFormat.Normal | VertexFormat.Texture0);
                lock (CurrentTexture)
                {
                }

                other.Dispose();
            }
        }

        /// <summary>
        /// Rotate the object
        /// </summary>
        /// <param name="x">x units to change</param>
        /// <param name="y">y units to change</param>
        /// <param name="z">z units to change</param>
        public void Rotate(float x, float y, float z)
        {
            ObjectRotate = new Vector3(x, y, z);
        }

        /// <summary>
        /// Translate the object
        /// </summary>
        /// <param name="x">x units to change</param>
        /// <param name="y">y units to change</param>
        /// <param name="z">z units to change</param>
        public void Translate(float x, float y, float z)
        {
            ObjectPosition = new Vector3(x, y, z);
        }

        /// <summary>
        /// Scale the object
        /// </summary>
        /// <param name="scale">vector 3 to change the scale</param>
        public void Scale(Vector3 scale)
        {
            ObjectScale = scale;
        }
    }
}