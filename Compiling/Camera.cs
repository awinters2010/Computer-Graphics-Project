using SlimDX;
using SlimDX.Direct3D9;
using System;

namespace Graphics
{
    public class Camera
    {
        // where we are stationed at
        public Vector3 eye;
        // what we are looking at (location)
        public Vector3 lookAt;
        // which way is up
        public Vector3 up;
        // how far away are we from origin
        public float distanceFromCamera = 5f;
        // the actual view from eye, lookat, and up
        public Matrix view;

        // field of view how wide can we see
        public float fov;
        // how the screen is displayed such as wide screen
        public float aspectRatio;
        // how close to us ( camera ) are things drawn
        public float near;
        // how far away from us are things drawn
        public float far;
        // project ( what is actually being seen ) from fov, aspect, near, and far
        public Matrix projection;

        /// <summary>
        /// Constructor that sets basic values for view and projection
        /// </summary>
        public Camera()
        {
            DeviceManager.device.SetTransform(TransformState.World, Matrix.Identity);

            eye = new Vector3(0, 0, distanceFromCamera);
            lookAt = Vector3.Zero;
            up = Vector3.UnitY;

            view = Matrix.LookAtLH(eye, lookAt, up);
            DeviceManager.device.SetTransform(TransformState.View, view);

            fov = (float)Math.PI / 4.0f;
            aspectRatio = (float)DeviceManager.device.Viewport.Width / DeviceManager.device.Viewport.Height;
            near = 1.0f;
            far = 100.0f;

            projection = Matrix.PerspectiveFovLH(fov, aspectRatio,
                near, far);
            DeviceManager.device.SetTransform(TransformState.Projection,
                projection);
        }


        /// <summary>
        /// Sets a new view
        /// </summary>
        /// <param name="eye"> where are we</param>
        /// <param name="lookat"> what are we looking at</param>
        /// <param name="up"> which way is up</param>
        public void SetView(Vector3 eye, Vector3 lookat, Vector3 up)
        {
            this.eye = eye;
            this.lookAt = lookat;
            this.up = up;
            view = Matrix.LookAtLH(this.eye, lookAt, this.up);
            DeviceManager.device.SetTransform(TransformState.View, view);
            //System.Diagnostics.Debug.WriteLine(view.ToString());
        }

        /// <summary>
        /// Sets a new projection
        /// </summary>
        /// <param name="fov"> how wide do we see (in radians)</param>
        /// <param name="aspectRatio"> width/height</param>
        /// <param name="close"> how close do we draw objects</param>
        /// <param name="far"> how far away do we draw objects</param>
        public void SetProjection(float fov, float aspectRatio,
            float close, float far)
        {
            this.fov = fov;
            this.aspectRatio = aspectRatio;
            near = close;
            this.far = far;
            projection = Matrix.PerspectiveFovLH(this.fov, this.aspectRatio,
                near, this.far);
            DeviceManager.device.SetTransform(TransformState.Projection,
                projection);
        }

        public void RotateCameraX(float angle)
        {
            Matrix result;
            Matrix.RotationX(angle, out result);
            DeviceManager.device.SetTransform(TransformState.World, result);
        }

        public void RotateCameraY(float angle)
        {
            Matrix result;
            Matrix.RotationY(angle, out result);
            DeviceManager.device.SetTransform(TransformState.World, result);
        }

        public void RotateCameraZ(float angle)
        {
            Matrix result;
            Matrix.RotationZ(angle, out result);
            DeviceManager.device.SetTransform(TransformState.World, result);
        }

        public void MoveCameraX(float units)
        {
            eye.X += units;
            view = Matrix.Translation(eye);
            DeviceManager.device.SetTransform(TransformState.View, view);
        }

        public void MoveCameraZ(float units)
        {
            eye.Z += units;
            view = Matrix.Translation(eye);
            DeviceManager.device.SetTransform(TransformState.View, view);
        }

        public void ResetCamera()
        {
            eye = new Vector3(0, 0, -5);
            lookAt = Vector3.Zero;
            up = Vector3.UnitY;

            view = Matrix.LookAtLH(eye, lookAt, up);
            DeviceManager.device.SetTransform(TransformState.View, view);
        }
    }
}
