using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using SharpNEX.Editor.UI.Data;

namespace SharpNEX.Editor.UI.Components
{
    internal class TitleBarButtonsController
    {
        private const float _defaultHeight = 45;

        private readonly TitleBar _titleBar;
        private float _percentageSize;

        private readonly ButtonLines _buttonMinimize;
        private readonly ButtonLines _buttonMaximize;
        private readonly ButtonLines _buttonClose;

        public TitleBarButtonsController(TitleBar titleBar)
        {
            _titleBar = titleBar;
            _titleBar.Resize += TitleBarResize;
            _percentageSize = _titleBar.Size.Height / _defaultHeight;

            _buttonMinimize = new ButtonLines();
            _buttonMaximize = new ButtonLines();
            _buttonClose = new ButtonLines();

            _titleBar.Controls.Add(_buttonMinimize);
            _titleBar.Controls.Add(_buttonMaximize);
            _titleBar.Controls.Add(_buttonClose);

            AdjustButtonts();
        }

        private void TitleBarResize(object sender, EventArgs e)
        {
            _percentageSize = Convert.ToSingle(_titleBar.Size.Height) / _defaultHeight;
            AdjustButtonts();
        }

        private void Clear()
        {
            _buttonMinimize.Clear();
            _buttonMaximize.Clear();
            _buttonClose.Clear();
        }

        private void AdjustButtonMinimize(Size titleBarSize, int width, int height, int x1, int y1, int x2, int y2)
        {
            _buttonMinimize.Size = new Size(width, height);
            _buttonMinimize.AddLine(new Line(x1, (y1 + y2) / 2, x2, (y1 + y2) / 2));
            _buttonMinimize.Location = new Point(titleBarSize.Width - Convert.ToInt32(150 * _percentageSize), 0);
            _buttonMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _buttonMinimize.Click += ButtonMinimizeClick;
        }

        private void AdjustButtonMaximize(Size titleBarSize, int width, int height, int x1, int y1, int x2, int y2)
        {
            _buttonMaximize.Size = new Size(width, height);
            _buttonMaximize.AddLine(new Line(x1, y1, x2, y1));
            _buttonMaximize.AddLine(new Line(x2, y1, x2, y2));
            _buttonMaximize.AddLine(new Line(x2, y2, x1, y2));
            _buttonMaximize.AddLine(new Line(x1, y2, x1, y1));
            _buttonMaximize.Location = new Point(titleBarSize.Width - Convert.ToInt32(100 * _percentageSize), 0);
            _buttonMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _buttonMaximize.Click += ButtonMaximizeClick;
        }

        private void AdjustButtonClose(Size titleBarSize, int width, int height, int x1, int y1, int x2, int y2)
        {
            _buttonClose.Size = new Size(width, height);
            _buttonClose.AddLine(new Line(x1, y1, x2, y2));
            _buttonClose.AddLine(new Line(x2, y1, x1, y2));
            _buttonClose.Location = new Point(titleBarSize.Width - Convert.ToInt32(50 * _percentageSize), 0);
            _buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _buttonClose.Click += ButtonCloseClick;
        }

        private void AdjustButtonts()
        {
            Clear();

            var titleBarSize = _titleBar.Size;

            int width = Convert.ToInt32(50 * _percentageSize);
            int height = titleBarSize.Height;

            int x1 = Convert.ToInt32(19 * _percentageSize); int y1 = Convert.ToInt32(16 * _percentageSize);
            int x2 = Convert.ToInt32(31 * _percentageSize); int y2 = Convert.ToInt32(28 * _percentageSize);

            AdjustButtonMinimize(titleBarSize, width, height, x1, y1, x2, y2);
            AdjustButtonMaximize(titleBarSize, width, height, x1, y1, x2, y2);
            AdjustButtonClose(titleBarSize, width, height, x1, y1, x2, y2);
        }

        private void ButtonMinimizeClick(object sender, EventArgs e)
        {
            Form form = _titleBar.FindForm();
            form.WindowState = FormWindowState.Minimized;
        }

        private void ButtonMaximizeClick(object sender, EventArgs e)
        {
            Form form = _titleBar.FindForm();
            form.WindowState = FormWindowState.Maximized;
        }

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            Form form = _titleBar.FindForm();
            form.Close();
        }
    }
}
