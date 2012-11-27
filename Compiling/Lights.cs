using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX.Direct3D9;
using SlimDX;

namespace Graphics
{
    public class Lights
    {
        Light light;
        Material material;
        private Vector3 position = Vector3.Zero;
        public string Type { get; private set; }

        public Lights(LightType type)
        {
            if (type == LightType.Point)
            {
                light.Type = LightType.Point;
                light.Diffuse = new Color4(new Vector4(.5f, .5f, .5f, 1f));
                light.Position = position;
                light.Range = 100.0f;    // a range of 100
                light.Attenuation0 = 0.0f;    // no constant inverse attenuation
                light.Attenuation1 = 0.125f;    // only .125 inverse attenuation
                light.Attenuation2 = 0.0f;    // no square inverse attenuation
            }
            else if (type == LightType.Directional)
            {
                
            }

            Type = type.ToString();
        }

        public void Render()
        {
            DeviceManager.LocalDevice.SetLight(0, light);
            DeviceManager.LocalDevice.EnableLight(0, true);

            //DeviceManager.LocalDevice.s
        }
    }
}
