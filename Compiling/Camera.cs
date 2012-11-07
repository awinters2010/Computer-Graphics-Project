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

        //for the ray for selecting objects
        private Ray ray;

        public Ray Ray
        {
            get { return ray; }
            set { ray = value; }
        }

        /// <summary>
        /// Constructor that sets basic values for view and projection
        /// </summary>
        public Camera()
        {
            DeviceManager.device.SetTransform(TransformState.World, Matrix.Identity);

            eye = new Vector3(0, 0, -5);
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

            ray = new Ray();
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

        /// <summary>
        /// change what the camera is looking at
        /// </summary>
        /// <param name="eye">where the camera is located</param>
        /// <param name="lookAt">what you want the camera to look at</param>
        public void ChangeView(Vector3 eye, Vector3 lookAt)
        {
            this.eye = eye;
            this.lookAt = lookAt;
            view = Matrix.LookAtLH(this.eye, this.lookAt, up);
            DeviceManager.device.SetTransform(TransformState.View, view);
        }

        /// <summary>
        /// rotate the camera around the x axis
        /// </summary>
        /// <param name="angle">the amount of the angle you want to rotate</param>
        public void RotateCameraX(float angle)
        {
            Matrix result;
            Matrix.RotationX(angle, out result);
            DeviceManager.device.SetTransform(TransformState.World, result);
        }

        /// <summary>
        /// rotate the camera around the y axis
        /// </summary>
        /// <param name="angle">the amount of the angle you want to rotate</param>
        public void RotateCameraY(float angle)
        {
            Matrix result;
            Matrix.RotationY(angle, out result);
            DeviceManager.device.SetTransform(TransformState.View, result * view);
        }

        /// <summary>
        /// rotate the camera around the z axis
        /// </summary>
        /// <param name="angle">the amount of the angle you want to rotate</param>
        public void RotateCameraZ(float angle)
        {
            Matrix result;
            Matrix.RotationZ(angle, out result);
            DeviceManager.device.SetTransform(TransformState.View, result * view);
        }

        /// <summary>
        /// move the camera along the x axis in x amount of units
        /// </summary>
        /// <param name="units">number of units you want to move</param>
        public void MoveCameraX(float units)
        {
            eye.X += units;
            view = Matrix.Translation(eye);
            DeviceManager.device.SetTransform(TransformState.View, view);
        }

        /// <summary>
        /// move the camera along the y axis in x amount of units
        /// </summary>
        /// <param name="units">number of units you want to move</param>
        public void MoveCameraY(float units)
        {
            eye.Y += units;
            Matrix.Translation(ref eye, out view);
            DeviceManager.device.SetTransform(TransformState.View, view);
        }

        /// <summary>
        /// move the camera along the z axis in x amount of units
        /// </summary>
        /// <param name="units">number of units you want to move</param>
        public void MoveCameraZ(float units)
        {
            eye.Z += units;
            view = Matrix.Translation(eye);
            DeviceManager.device.SetTransform(TransformState.View, view);
        }

        /// <summary>
        /// Resets the Camera to look at the origin with a distance of 5 units from it
        /// </summary>
        public void ResetCamera()
        {
            DeviceManager.device.SetTransform(TransformState.World, Matrix.Identity);

            eye = new Vector3(0, 0, -5);
            lookAt = Vector3.Zero;
            up = Vector3.UnitY;

            view = Matrix.LookAtLH(eye, lookAt, up);
            DeviceManager.device.SetTransform(TransformState.View, view);
        }

        public void RayCalculaton(Vector2 mousePosition, BasicShape shape)
        {
            Vector3 rayPos = new Vector3(mousePosition, 0.0f);
            Vector3 rayDir = new Vector3(mousePosition, 1.0f);

            Matrix objectMat = DeviceManager.device.GetTransform(TransformState.World | TransformState.View);

            Vector3.Unproject(ref rayPos, DeviceManager.device.Viewport.X, DeviceManager.device.Viewport.Y,
                DeviceManager.device.Viewport.Width, DeviceManager.device.Viewport.Height, 0f, 1f, ref objectMat, out rayPos);
            Vector3.Unproject(ref rayDir, DeviceManager.device.Viewport.X, DeviceManager.device.Viewport.Y,
                DeviceManager.device.Viewport.Width, DeviceManager.device.Viewport.Height, 0f, 1f, ref objectMat, out rayDir);

            rayDir -= rayPos;

            //Vector3.Normalize(ref rayPos, out rayPos);
            //Vector3.Normalize(ref rayDir, out rayDir);

            ray.Direction = rayDir;
            ray.Position = rayPos;

            /*
            Mesh m = new Mesh(DeviceManager.device, 36, 8, MeshFlags.DoNotClip, VertexUntransformed.vertexDecl.Elements);
            m.LockIndexBuffer(LockFlags.Discard).WriteRange(((Cube)shape).indices);
            m.UnlockIndexBuffer();
            m.LockVertexBuffer(LockFlags.Discard).WriteRange(((Cube)shape).vertex);
            m.UnlockIndexBuffer();

            Console.WriteLine(m.Intersects(ray));

            m.Dispose();
             * */
        }
    }
}