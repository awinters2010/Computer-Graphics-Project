using SlimDX;
using SlimDX.Direct3D9;
using System;

namespace Graphics
{
    public class Camera
    {
        private Vector3 eye;
        public Vector3 Eye { get; private set;}
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

        private Vector3 eyeRotation;
        public Vector3 EyeRotation {
            get
            {
                return eyeRotation;
            }
            set
            {
                eyeRotation = new Vector3(eyeRotation.X + value.X, eyeRotation.Y + value.Y, eyeRotation.Z + value.Z);
                Matrix result = Matrix.RotationYawPitchRoll(eyeRotation.Y, eyeRotation.Z, eyeRotation.X);
                DeviceManager.LocalDevice.SetTransform(TransformState.View, result * View);
            }
        }

        /// <summary>
        /// Constructor that sets basic values for view and projection
        /// </summary>
        public Camera()
        {
            DeviceManager.LocalDevice.SetTransform(TransformState.World, Matrix.Identity);

            eye = new Vector3(0, 0, -5);
            LookAt = Vector3.Zero;
            Up = Vector3.UnitY;

            View = Matrix.LookAtLH(eye, LookAt, Up);
            DeviceManager.LocalDevice.SetTransform(TransformState.View, View);

            FOV = (float)Math.PI / 4.0f;
            AspectRatio = (float)DeviceManager.LocalDevice.Viewport.Width / DeviceManager.LocalDevice.Viewport.Height;
            Near = 1.0f;
            Far = 100.0f;

            Projection = Matrix.PerspectiveFovLH(FOV, AspectRatio,
                Near, Far);
            DeviceManager.LocalDevice.SetTransform(TransformState.Projection,
                Projection);

            eyeRotation = Vector3.Zero;
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
            View = Matrix.LookAtLH(this.eye, LookAt, this.Up);
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
            View = Matrix.LookAtLH(this.eye, this.LookAt, Up);
            DeviceManager.LocalDevice.SetTransform(TransformState.View, View);
        }      

        /// <summary>
        /// move the camera along the x axis in x amount of units
        /// </summary>
        /// <param name="units">number of units you want to move</param>
        public void MoveEyeX(float units)
        {
            eye.X += units;
            View = Matrix.Translation(eye);
            DeviceManager.LocalDevice.SetTransform(TransformState.View, View);
        }

        /// <summary>
        /// move the camera along the y axis in x amount of units
        /// </summary>
        /// <param name="units">number of units you want to move</param>
        public void MoveEyeY(float units)
        {
            eye.Y += units;
            Matrix.Translation(ref eye, out View);
            DeviceManager.LocalDevice.SetTransform(TransformState.View, View);
        }

        /// <summary>
        /// move the camera along the z axis in x amount of units
        /// </summary>
        /// <param name="units">number of units you want to move</param>
        public void MoveEyeZ(float units)
        {
            eye.Z += units;
            View = Matrix.Translation(eye);
            DeviceManager.LocalDevice.SetTransform(TransformState.View, View);
        }

        /// <summary>
        /// Resets the Camera to look at the origin with a distance of 5 units from it
        /// </summary>
        public void ResetCamera()
        {
            DeviceManager.LocalDevice.SetTransform(TransformState.World, Matrix.Identity);

            eye = new Vector3(0, 0, -5);
            LookAt = Vector3.Zero;
            Up = Vector3.UnitY;

            View = Matrix.LookAtLH(eye, LookAt, Up);
            DeviceManager.LocalDevice.SetTransform(TransformState.View, View);
        }

        /// <summary>
        /// Used to find which primitive object the mouse is currently hold over for selecting that object
        /// </summary>
        /// <param name="mousePosition">the mouses location</param>
        /// <param name="shape">the primitive that you wish to see if the mouse is currently hovering over</param>
        /// <param name="distance">the distance from the mouse to the shape</param>
        /// <returns>true is mouse is over that primitive; false otherwise</returns>
        public bool RayCalculation(Vector2 mousePosition, IShape shape, out float distance)
        {
            var mouseNear = new Vector3(mousePosition, 0.0f);
            var mouseFar = new Vector3(mousePosition, 1.0f);
            var box = new BoundingBox();

            var mat = this.View * this.Projection * DeviceManager.LocalDevice.GetTransform(TransformState.World);

            Vector3.Unproject(ref mouseNear, DeviceManager.LocalDevice.Viewport.X, DeviceManager.LocalDevice.Viewport.Y,
                DeviceManager.LocalDevice.Viewport.Width, DeviceManager.LocalDevice.Viewport.Height, 0f, 1f, ref mat, out mouseNear);
            Vector3.Unproject(ref mouseFar, DeviceManager.LocalDevice.Viewport.X, DeviceManager.LocalDevice.Viewport.Y,
                DeviceManager.LocalDevice.Viewport.Width, DeviceManager.LocalDevice.Viewport.Height, 0f, 1f, ref mat, out mouseFar);

            var direction = mouseFar - mouseNear;

            var selectionRay = new Ray(mouseNear, direction);

            foreach (var vertex in shape.ShapeVertices)
            {
                box.Minimum.X = Math.Min(vertex.Position.X, box.Minimum.X);
                box.Minimum.Y = Math.Min(vertex.Position.Y, box.Minimum.Y);
                box.Minimum.Z = Math.Min(vertex.Position.Z, box.Minimum.Z);

                box.Maximum.X = Math.Max(vertex.Position.X, box.Maximum.X);
                box.Maximum.Y = Math.Max(vertex.Position.Y, box.Maximum.Y);
                box.Maximum.Z = Math.Max(vertex.Position.Z, box.Maximum.Z);
            }

            return Ray.Intersects(selectionRay, box, out distance);
        }
    }
}