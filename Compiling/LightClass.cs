using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX.Direct3D9;
using SlimDX;
using System.Drawing;

namespace Graphics
{
    public class LightClass : IDisposable
    {
        private Light light;
        private Material material;
        private bool isLightEnabled;
        private Mesh mesh;
        private Matrix world;

        public string Type { get; private set; }
        public Vector3 Position { get; set; }
        public Vector3 Direction { get; set; }

        public LightClass(LightType type = LightType.Point)
        {
            if (type == LightType.Point)
            {
                light.Type = type;
                light.Diffuse = Color.White;
                light.Ambient = Color.White;
                light.Specular = Color.White;
                light.Position = Vector3.Zero;
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
            Type = type.ToString();
            Position = Vector3.Zero;
            Direction = Vector3.Zero;
            world = Matrix.Identity;
            mesh = Mesh.CreateSphere(DeviceManager.LocalDevice, .1f, 10, 10);
            mesh.ComputeNormals();

            material.Diffuse = new Color4(1, 1, 1, 1);
            material.Ambient = new Color4(1, 1, 1, 1);

            DeviceManager.LocalDevice.Material = material;
        }

        public void LightOnOff(int index)
        {
            isLightEnabled = isLightEnabled == true ? false : true;
            DeviceManager.LocalDevice.SetLight(index, light);
            DeviceManager.LocalDevice.EnableLight(index, isLightEnabled);
        }

        public void Render()
        {
            world = Matrix.Translation(Position);
            DeviceManager.LocalDevice.SetTransform(TransformState.World, world);

            mesh.DrawSubset(0);
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
        /// <param name="type"></param>
        public void GlobalLightTranslation(float x, float y, float z, LightType type)
        {
            Position = new Vector3(x, y, z);
            if (type == LightType.Point)
            {
                light.Position = Position;
            }
            else if (type == LightType.Directional)
            {
                light.Direction = Position;
            }
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
