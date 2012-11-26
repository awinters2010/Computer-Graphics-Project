using SlimDX;
using SlimDX.Direct3D9;
using System;

namespace Graphics
{
    public class Camera
    {
        private Vector3 eye;

        public Vector3 Eye
        {
            get
            {
                return eye;
            }
            private set
            {
                eye = value;
            }
        }
        // what we are looking at (location)
        private Vector3 LookAt;
        // which way is up
        private Vector3 Up;
        // the actual view from eye, lookat, and up
        public Matrix View;

        // field of view how wide can we see
        private float FOV;
        // how the screen is displayed such as wide screen
        private float AspectRatio;
        // how close to us ( camera ) are things drawn
        private float Near;
        // how far away from us are things drawn
        private float Far;
        // project ( what is actually being seen ) from fov, aspect, near, and far
        private Matrix Projection;

        private Vector3 cameraRotation;
        public Vector3 CameraRotation 
        {
            get
            {
                return cameraRotation;
            }

            set
            {
                cameraRotation = new Vector3(cameraRotation.X + value.X, cameraRotation.Y + value.Y, cameraRotation.Z + value.Z);
                Matrix result = Matrix.RotationYawPitchRoll(cameraRotation.Y, cameraRotation.X, cameraRotation.Z) * Matrix.Translation(eye);
                DeviceManager.LocalDevice.SetTransform(TransformState.View, result * View);
            }
        }

        /// <summary>
        /// Constructor that sets basic values for view and projection
        /// </summary>
        public Camera()
        {
            DeviceManager.LocalDevice.SetTransform(TransformState.World, Matrix.Identity);

            eye = new Vector3(0, 0, 3.5f);
            LookAt = Vector3.Zero;
            Up = Vector3.UnitY;

            View = Matrix.Translation(eye);
            DeviceManager.LocalDevice.SetTransform(TransformState.View, View);

            FOV = (float)Math.PI / 4.0f;
            AspectRatio = (float)DeviceManager.LocalDevice.Viewport.Width / DeviceManager.LocalDevice.Viewport.Height;
            Near = 1.0f;
            Far = 100.0f;

            Projection = Matrix.PerspectiveFovLH(FOV, AspectRatio,
                Near, Far);
            DeviceManager.LocalDevice.SetTransform(TransformState.Projection,
                Projection);

            cameraRotation = Vector3.Zero;
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
            this.LookAt = lookat;
            this.Up = up;
            View = Matrix.Translation(eye);
            DeviceManager.LocalDevice.SetTransform(TransformState.View, View);
            //System.Diagnostics.Debug.WriteLine(view.ToString());
        }

        /// <summary>
        /// Sets a new projection
        /// </summary>
        /// <param name="fov"> how wide do we see (in radians)</param>
        /// <param name="aspectRatio"> width/height</param>
        /// <param name="close"> how close do we draw objects</param>
        /// <param name="far"> how far away do we draw objects</param>
        public void SetProjection(float fov, float aspectRatio, float close, float far)
        {
            this.FOV = fov;
            this.AspectRatio = aspectRatio;
            Near = close;
            this.Far = far;
            Projection = Matrix.PerspectiveFovLH(this.FOV, this.AspectRatio,
                Near, this.Far);
            DeviceManager.LocalDevice.SetTransform(TransformState.Projection,
                Projection);
        }

        /// <summary>
        /// change what the camera is looking at
        /// </summary>
        /// <param name="eye">where the camera is located</param>
        /// <param name="lookAt">what you want the camera to look at</param>
        public void ChangeView(Vector3 eye, Vector3 lookAt)
        {
            this.eye = eye;
            this.LookAt = lookAt;
            View = Matrix.Translation(eye);
            DeviceManager.LocalDevice.SetTransform(TransformState.View, View);
        }

        /// <summary>
        /// move the camera along the axis by the specified amount
        /// </summary>
        /// <param name="units">number of units you want to move</param>
        public void MoveEye(float x = 0, float y = 0, float z = 0)
        {
            eye.X += x;
            eye.Y += y;
            eye.Z += z;

            View = Matrix.Translation(eye);
            DeviceManager.LocalDevice.SetTransform(TransformState.View, View);
        }

        /// <summary>
        /// Resets the Camera to look at the origin with a distance of 3.5 units from it
        /// </summary>
        public void ResetEye()
        {
            cameraRotation = Vector3.Zero;

            DeviceManager.LocalDevice.SetTransform(TransformState.World, Matrix.Identity);

            eye = new Vector3(0, 0, 3.5f);
            LookAt = Vector3.Zero;
            Up = Vector3.UnitY;

            View = Matrix.Translation(eye);
            DeviceManager.LocalDevice.SetTransform(TransformState.View, View);
        }

        /// <summary>
        /// Used to find which primitive object the mouse is currently hold over for selecting that object
        /// </summary>
        /// <param name="mousePosition">the mouses location</param>
        /// <param name="shape">the primitive that you wish to see if the mouse is currently hovering over</param>
        /// <param name="distance">the distance from the mouse to the shape</param>
        /// <returns>true is mouse is over that primitive; false otherwise</returns>
        public bool RayCalculation(Vector2 mousePosition, MeshClass mesh)
        {
            var mouseNear = new Vector3(mousePosition, 0.0f);
            var mouseFar = new Vector3(mousePosition, 1.0f);

            var mat = this.View * this.Projection * DeviceManager.LocalDevice.GetTransform(TransformState.World);

            Vector3.Unproject(ref mouseNear, DeviceManager.LocalDevice.Viewport.X, DeviceManager.LocalDevice.Viewport.Y,
                DeviceManager.LocalDevice.Viewport.Width, DeviceManager.LocalDevice.Viewport.Height, 0f, 1f, ref mat, out mouseNear);
            Vector3.Unproject(ref mouseFar, DeviceManager.LocalDevice.Viewport.X, DeviceManager.LocalDevice.Viewport.Y,
                DeviceManager.LocalDevice.Viewport.Width, DeviceManager.LocalDevice.Viewport.Height, 0f, 1f, ref mat, out mouseFar);

            var direction = mouseFar - mouseNear;
            var selectionRay = new Ray(mouseNear, direction);

            return mesh.ObjectMesh.Intersects(selectionRay);
        }
    }
}