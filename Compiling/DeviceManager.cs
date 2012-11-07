using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX.Direct3D9;

namespace Graphics
{
    public static class DeviceManager
    {
        public static Device LocalDevice { get; set; }

        public static void CreateDevice(IntPtr ptr, int width, int height)
        {
            LocalDevice = new Device(new Direct3D(), 0, DeviceType.Hardware, ptr,
                CreateFlags.HardwareVertexProcessing, new PresentParameters()
                {
                    BackBufferWidth = width,
                    BackBufferHeight = height,
                    Windowed = true,
                    SwapEffect = SwapEffect.Discard,
                    BackBufferCount = 1,
                    EnableAutoDepthStencil = true,
                    AutoDepthStencilFormat = Format.D16,
                });
        }
    }
}
