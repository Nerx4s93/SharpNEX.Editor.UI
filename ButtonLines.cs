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
