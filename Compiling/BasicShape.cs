using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX.D3DCompiler;
using SlimDX.Direct3D11;
using SlimDX;

namespace Graphics
{
    public class BasicShape
    {
        public ShaderBytecode byteCode;
        public ShaderSignature inputSignature;
        public VertexShader vertexShader;
        public PixelShader pixelShader;
        public DataStream vertices { get; set; }
        public Device device;
        public DeviceContext context;

        public BasicShape(Device device, DeviceContext context)
        {
            this.device = device;
            this.context = context;

            byteCode = ShaderBytecode.CompileFromFile("BasicShape.fx", "VShader", "vs_4_0",
                ShaderFlags.None, EffectFlags.None);
            inputSignature = ShaderSignature.GetInputSignature(byteCode);
            vertexShader = new VertexShader(device, byteCode);

            byteCode = ShaderBytecode.CompileFromFile("BasicShape.fx", "PShader", "ps_4_0",
                ShaderFlags.None, EffectFlags.None);
            pixelShader = new PixelShader(device, byteCode);
        }

        public virtual void Render() { }
    }
}
