using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX.Direct3D9;
using SlimDX;
using System.Drawing;

namespace Graphics
{
    public class Lights
    {
        Light light;
        Material material;
        private Vector3 position = new Vector3(-12f,0f,30f);
        private Vector3 direction = new Vector3(0, 0, -1f);
        public string Type { get; private set; }

        public Lights(LightType type)
        {
            if (type == LightType.Point)
            {
                light.Type = LightType.Point;
                light.Diffuse = new Color4(new Vector4(.5f, .5f, .5f, 1f));
                light.Position = position;
                light.Direction = direction;
                light.Range = 100.0f;    // a range of 100
                light.Attenuation0 = 0.0f;    // no constant inverse attenuation
                light.Attenuation1 = 0.125f;    // only .125 inverse attenuation
                light.Attenuation2 = 0.0f;    // no square inverse attenuation
                light.Phi = 40f * ((float)Math.PI / 180f);
                light.Theta = 20f * ((float)Math.PI / 180f);
                light.Falloff = 1.0f;

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

            material.Diffuse = new Color4(1, 1, 1, 1);
            material.Ambient = new Color4(1, 1, 1, 1);

            DeviceManager.LocalDevice.Material = material;
        }
    }
}
