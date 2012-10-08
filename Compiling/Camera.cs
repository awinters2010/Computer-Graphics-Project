using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX;

namespace Graphics
{
    public class Camera
    {
        public Vector3 position;
        public Vector3 lookAt;
        public Vector3 up;

        public Camera()
        {
            position = new Vector3(0, 0, 50f);
            lookAt = Vector3.Zero;
            up = new Vector3(0, 1, 0);
        }
    }
}
