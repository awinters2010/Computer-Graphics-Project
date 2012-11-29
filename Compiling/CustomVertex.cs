using SlimDX;
using SlimDX.Direct3D9;

namespace Graphics
{
    public class CustomVertex
    {
        public struct VertexPositionColor
        {
            public Vector3 Position { get; set; }
            public int Color { get; set; }

            public static VertexFormat Format = VertexFormat.Position | VertexFormat.Diffuse;
            public static int VertexByteSize = 16;

            public static VertexDeclaration VertexDecl = new VertexDeclaration(DeviceManager.LocalDevice, new VertexElement[]
            {
                new VertexElement(0, 0, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position, 0),
                new VertexElement(0, 12, DeclarationType.Color, DeclarationMethod.Default, DeclarationUsage.Color, 0),
                VertexElement.VertexDeclarationEnd
            });
        }

        public struct VertexPositionNormalColor
        {
            public Vector3 Position { get; set; }
            public Vector3 Normals { get; set; }
            public int Color { get; set; }

            public static VertexFormat Format = VertexFormat.PositionNormal | VertexFormat.Diffuse;
            public static int VertexByteSize = 28;

            public static VertexDeclaration VertexDecl = new VertexDeclaration(DeviceManager.LocalDevice, new VertexElement[]
            {
                new VertexElement(0, 0, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position, 0),
                new VertexElement(0, 12, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Normal, 0),
                new VertexElement(0, 24, DeclarationType.Color, DeclarationMethod.Default, DeclarationUsage.Color, 0),
                VertexElement.VertexDeclarationEnd
            });
        }
    }
}