using System;
using SlimDX.Direct3D9;

namespace Graphics
{
    public class MeshClass: IDisposable
    {
        public ExtendedMaterial[] m;
        public Texture[] t;
        public Material[] mat;
        public Mesh mesh;
        uint nummaterials = 0;

        public MeshClass(string file, string fileName)
        {
            mesh = Mesh.FromFile(DeviceManager.LocalDevice, file, MeshFlags.SystemMemory);
            m = mesh.GetMaterials();
            mat = new Material[m.Length];
            t = new Texture[m.Length];
            for (int i = 0; i < m.Length; i++)
            {
                mat[i] = m[i].MaterialD3D;
                mat[i].Ambient = mat[i].Diffuse;
                string s = file;
                Console.WriteLine(s.Length);
                int index = s.IndexOf(fileName);
                string tex = s.Remove(index);
                s = tex.Insert(index, m[i].TextureFileName);
                Console.WriteLine(s);
                Console.WriteLine(tex);
                
                t[i] = Texture.FromFile(DeviceManager.LocalDevice, s);
            }
        }

        ~MeshClass()
        {
            Dispose();
        }

        public void Dispose()
        {
            for (int i = 0; i < t.Length; i++)
            {
                t[i].Dispose();
            }

            mesh.Dispose();
        }

        public void RenderMesh()
        {
            for (int i = 0; i < mat.Length; ++i)
            {
                DeviceManager.LocalDevice.Material = mat[i];
            }

            for (int i = 0; i < t.Length; i++)
            {
                DeviceManager.LocalDevice.SetTexture(0, t[i]);
            }

            mesh.DrawSubset(0);
        }
    }
}
