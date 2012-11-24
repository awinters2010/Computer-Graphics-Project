using System;
using SlimDX.Direct3D9;
using SlimDX;

namespace Graphics
{
    public class MeshClass: IDisposable
    {
        public Texture[] CurrentTexture { get; set; }
        private Material[] material;
        public Mesh mesh;
        public Vector3 Position { get; set; }
        public Matrix World { get; set; }
        public Vector3 Roate { get; set; }
        VertexBuffer vBuffer;
        IndexBuffer iBuffer;
        public string Type { get; private set; }
        public string Name { get; set; }

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
        }

        public MeshClass(string type)
        {
            if (type == "cube")
            {
                //mesh = new Mesh(DeviceManager.LocalDevice, 100, 100, options, vDec);
            }
            else if (type == "triangle")
            {
                //mesh = new Mesh(DeviceManager.LocalDevice, faceCount, vertexCount, options, vDec);
            }
        }

        ~MeshClass()
        {
            Dispose();
        }

        public void Dispose()
        {
            for (int i = 0; i < CurrentTexture.Length; i++)
            {
                CurrentTexture[i].Dispose();
            }

            mesh.Dispose();
        }

        public void RenderMesh()
        {
            World = Matrix.Translation(Position);
            DeviceManager.LocalDevice.SetTransform(TransformState.World, World);

            foreach (var item in material)
            {
                DeviceManager.LocalDevice.Material = item;
            }

            foreach (var item in CurrentTexture)
            {
                DeviceManager.LocalDevice.SetTexture(0, item);
            }

            mesh.DrawSubset(0);
        }
    }
}
