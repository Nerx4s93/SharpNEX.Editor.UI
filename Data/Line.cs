using System.Drawing;

namespace SharpNEX.Editor.UI.Data
{
    internal class Line
    {
        public Point PointStart { get; set; } = Point.Empty;

        public Point PointEnd { get; set; } = Point.Empty;

        public Color Color { get; set; } = Color.White;

        public float Width { get; set; } = 1f;

        public void DrawLine(Graphics graphics)
        {
            using (var pen = new Pen(Color, Width))
            {
                graphics.DrawLine(pen, PointStart, PointEnd);
            }
        }
    }
}
