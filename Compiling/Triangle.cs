using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX.Direct3D11;
using SlimDX;
using SlimDX.DXGI;

namespace Graphics
{
    public class Triangle : BasicShape
    {

        public Triangle(SlimDX.Direct3D11.Device device, DeviceContext context)
            : base(device, context)
        {
            SetTriangle();
        }

        private void SetTriangle()
        {
            vertices = new DataStream(12 * 3, true, true);
            vertices.Write(new Vector3(0.0f, 0.5f, 0.5f));
            vertices.Write(new Vector3(0.5f, -0.5f, 0.5f));
            vertices.Write(new Vector3(-0.5f, -0.5f, 0.5f));
            vertices.Position = 0;

            // create the vertex layout and buffer
            var elements = new[] { new InputElement("POSITION", 0, Format.R32G32B32_Float, 0) };
            var layout = new InputLayout(device, inputSignature, elements);
            var vertexBuffer = new SlimDX.Direct3D11.Buffer(device, vertices, 12 * 3, ResourceUsage.Default, BindFlags.VertexBuffer, CpuAccessFlags.None, ResourceOptionFlags.None, 0);

            // configure the Input Assembler portion of the pipeline with the vertex data
            context.InputAssembler.InputLayout = layout;
            context.InputAssembler.PrimitiveTopology = PrimitiveTopology.TriangleList;
            context.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(vertexBuffer, 12, 0));

            // set the shaders
            context.VertexShader.Set(vertexShader);
            context.PixelShader.Set(pixelShader);
        }

        public override void Render()
        {
            context.Draw(3, 0);
        }

        public void Destroy()
        {
            vertices.Close();
            inputSignature.Dispose();
            vertexShader.Dispose();
            pixelShader.Dispose();
        }
    }
}
