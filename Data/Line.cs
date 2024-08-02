using System.Drawing;

namespace SharpNEX.Editor.UI.Data
{
    public class Line
    {
        public Line()
        {

        }

        public Line(int x1, int y1, int x2, int y2)
        {
            PointStart = new Point(x1, y1);
            PointEnd = new Point(x2, y2);
        }

        public Point PointStart { get; set; } = Point.Empty;

        public Point PointEnd { get; set; } = Point.Empty;

        public Color Color { get; set; } = Color.FromArgb(203, 203, 203);

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
