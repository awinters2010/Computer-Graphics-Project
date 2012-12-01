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

        private static PresentParameters presentationParameters;

        public static PresentParameters PresentationParameters
        {
            get
            {
                return presentationParameters;
            }
        }

        public static void CreateDevice(IntPtr ptr, int width, int height)
        {
            presentationParameters = new PresentParameters()
            {
                BackBufferWidth = width,
                BackBufferHeight = height,
                BackBufferFormat = Format.A8R8G8B8,
                BackBufferCount = 1,
                Multisample = MultisampleType.None,
                MultisampleQuality = 0,
                SwapEffect = SwapEffect.Discard,
                Windowed = true,
                DeviceWindowHandle = ptr,
                EnableAutoDepthStencil = true,
                AutoDepthStencilFormat = Format.D16,
                PresentFlags = PresentFlags.None,
                FullScreenRefreshRateInHertz = 0,
                PresentationInterval = PresentInterval.Default
            };

            LocalDevice = new Device(new Direct3D(), 0, DeviceType.Hardware, ptr,
                CreateFlags.HardwareVertexProcessing, presentationParameters);
        }

        public static void ResetDevice()
        {
            LocalDevice.Reset(presentationParameters);
        }
    }
}
