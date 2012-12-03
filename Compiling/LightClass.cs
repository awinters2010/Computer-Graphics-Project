﻿using System;
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
        public bool IsLightEnabled
        {
            get { return isLightEnabled; }
            private set { isLightEnabled = value; }
        }

        /// <summary>
        /// Constructor or added a new light to the scene
        /// </summary>
        /// <param name="type">the light type you wish to have or default of point</param>
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

        /// <summary>
        /// Turn the specific light light on/off
        /// </summary>
        /// <param name="index">the light in which you want to turn on or off</param>
        public void LightOnOff(int index)
        {
            isLightEnabled = isLightEnabled == true ? false : true;
            DeviceManager.LocalDevice.SetLight(index, light);
            DeviceManager.LocalDevice.EnableLight(index, isLightEnabled);
        }

        /// <summary>
        /// Render the location if global light is on
        /// </summary>
        public void Render()
        {
            world = Matrix.Translation(Position);
            DeviceManager.LocalDevice.SetTransform(TransformState.World, world);

            mesh.DrawSubset(0);
        }

        public void Dispose()
        {
            mesh.Dispose();
        }

        /// <summary>
        /// Positions the light (point) or Positions the direction (directional)
        /// </summary>
        /// <param name="position">vector 3 position</param>
        public void GlobalLightTranslation(Vector3 position)
        {
            Position = position;
            if (Type.Equals(LightType.Point.ToString()))
            {
                light.Position = Position;
            }
            else if (Type.Equals(LightType.Directional.ToString()))
            {
                light.Direction = Position;
            }
        }
    }
}
