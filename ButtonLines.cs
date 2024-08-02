using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using SharpNEX.Editor.UI.Data;

namespace SharpNEX.Editor.UI
{
    [ToolboxItem(true)]
    public class ButtonLines : ButtonFlatBase
    {
        public ButtonLines()
        {
            DoubleBuffered = true;
        }

        #region Свойства

        public Line[] Lines { get; set; } = new Line[0];

        #endregion

        public void AddLine(Line line)
        {
            List<Line> listLines = Lines.ToList();
            listLines.Add(line);

            Lines = listLines.ToArray();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;

            foreach (Line line in Lines)
            {
                line.DrawLine(graphics);
            }
        }
    }
}
