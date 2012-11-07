using SlimDX;
using SlimDX.Direct3D9;

namespace Graphics
{
    public struct VertexUntransformed
    {
        public Vector3 Position { get; set; }
        public int Color { get; set; }

        public static VertexFormat format = VertexFormat.Position | VertexFormat.Diffuse;
        public const int VertexByteSize = 16;

        public static VertexDeclaration vertexDecl = new VertexDeclaration(DeviceManager.device, new VertexElement[]
        {
            new VertexElement(0, 0, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position, 0),
            new VertexElement(0, 12, DeclarationType.Color, DeclarationMethod.Default, DeclarationUsage.Color, 0),
            VertexElement.VertexDeclarationEnd
        });
    }
}