using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX.Direct3D9;

namespace Graphics
{
    public static class DeviceManager
    {
        public static Device device;

        public static void CreateDevice(IntPtr ptr, int width, int height)
        {
            device = new Device(new Direct3D(), 0, DeviceType.Hardware, ptr,
                CreateFlags.HardwareVertexProcessing, new PresentParameters()
                {
                    BackBufferWidth = width,
                    BackBufferHeight = height
                });
        }
    }
}
