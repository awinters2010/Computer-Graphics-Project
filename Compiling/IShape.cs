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
        Vector3 Scaling { get; set; }
        Vector3 Rotation { get; set; }

        /// <summary>
        /// Rotate the object
        /// </summary>
        /// <param name="x">x unit to rotate</param>
        /// <param name="y">y unit to rotate</param>
        /// <param name="z">z unit to rotate</param>
        void Rotate(float x, float y, float z);

        /// <summary>
        /// Move the object
        /// </summary>
        /// <param name="x">x unit amount to move</param>
        /// <param name="y">y unit amount to move</param>
        /// <param name="z">z unit amount to move</param>
        void Translate(float x, float y, float z);

        /// <summary>
        /// Scale the object (change size)
        /// </summary>
        /// <param name="scale">for the three axis that can be scaled</param>
        void Scale(Vector3 scale);

        /// <summary>
        /// Set the translation, scale, and rotation for the device for the object
        /// </summary>
        void Render();
    }
}