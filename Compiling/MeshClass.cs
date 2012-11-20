using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX.Direct3D9;

namespace Graphics
{
    public class MeshClass
    {
        Material[] m;
        Texture[] t;
        Mesh mesh;
        uint nummaterials = 0;

        public MeshClass(string file)
        {
            mesh = Mesh.FromFile(DeviceManager.LocalDevice, file, MeshFlags.UseHardwareOnly);
        }
    }
}
