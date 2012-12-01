using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX.Direct3D9;
using SlimDX;
using System.Drawing;

namespace Graphics
{
    public class Lights : IDisposable
    {
        private Light light;
        private Material material;
        private bool isLightEnabled;
        private bool isGlobalLightOn;
        private Mesh mesh;
        private Matrix world;

        public string Type { get; private set; }
        public Vector3 Position { get; set; }
        public Vector3 Direction { get; set; }

        public Lights(LightType type = LightType.Point)
        {
            if (type == LightType.Point)
            {
                light.Type = type;
                light.Diffuse = new Color4(new Vector4(.5f, .5f, .5f, 1f));
                light.Position = new Vector3(0,0,30);
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
                light.Type = type;
                light.Direction = Vector3.Zero;
                light.Ambient = Color.PapayaWhip;
                light.Diffuse = Color.PapayaWhip;
                light.Specular = Color.PapayaWhip;
            }

            isLightEnabled = false;
            isGlobalLightOn = true;
            Type = type.ToString();
            Position = Vector3.Zero;
            Direction = Vector3.Zero;
            world = Matrix.Identity;
            mesh = Mesh.CreateSphere(DeviceManager.LocalDevice, .1f, 10, 10);

            material.Diffuse = new Color4(1, 1, 1, 1);
            material.Ambient = new Color4(1, 1, 1, 1);

            DeviceManager.LocalDevice.Material = material;
        }

        public void LightOnOff(int index)
        {
            isLightEnabled = isLightEnabled == true ? false : true;
            DeviceManager.LocalDevice.SetLight(index, light);
            DeviceManager.LocalDevice.EnableLight(index, isLightEnabled);
            isGlobalLightOn = false;
        }

        public void Render()
        {
            if (isGlobalLightOn)
            {
                world = Matrix.Translation(Position);
                DeviceManager.LocalDevice.SetTransform(TransformState.World, world);

                mesh.DrawSubset(0);
            }
        }

        public void Dispose()
        {
            mesh.Dispose();

            Console.WriteLine("object Removed " + Type + " Light");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void GlobalLightTranslation(float x, float y, float z)
        {
            Position = new Vector3(x, y, z);
        }

        public void GlobalLightOffPosition(Vector3 position)
        {
            if (Type.Equals(LightType.Point.ToString()))
            {
                light.Position = position;
            }
        }
    }
}
