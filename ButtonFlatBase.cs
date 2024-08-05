using System;
using System.Drawing;
using System.Windows.Forms;

namespace SharpNEX.Editor.UI
{
    internal class ButtonFlatBase : Control
    {
        private bool _mouseEnter;
        private bool _mouseDown;

        public ButtonFlatBase()
        {
            DoubleBuffered = true;
            BackColor = Color.FromArgb(31, 31, 31);
        }

        #region Свойства

        public Color BackColorOnMouseEnter { get; set; } = Color.FromArgb(61, 61, 61);

        public Color BackColorOnMouseDown { get; set; } = Color.FromArgb(56, 56, 56);

        #endregion

        protected override void OnMouseEnter(EventArgs e)
        {
            _mouseEnter = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _mouseEnter = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _mouseDown = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _mouseDown = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;

            var backColorMouseEnter = _mouseEnter ? BackColorOnMouseEnter : BackColor;
            var backColor = _mouseDown ? BackColorOnMouseDown : backColorMouseEnter;

            using (var brush = new SolidBrush(backColor))
            {
                graphics.FillRectangle(brush, 0, 0, Size.Width, Size.Height);
            }
        }
    }
}
