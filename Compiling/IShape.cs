using SlimDX;

namespace Graphics
{
    public interface IShape
    {
        bool Selected { get; set; }
        Vector3 Position { get; set; }
        Matrix World { get; }
        VertexUntransformed[] ShapeVertices { get; }
        short[] ShapeIndices { get; }
        string Name { get; set; }
        string Type { get; }

        void Rotate();
        void Translate(float x, float y, float z);
        void Scale();
        void Render();
    }
}