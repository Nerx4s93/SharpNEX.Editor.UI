using System;
using System.Drawing;
using System.Windows.Forms;

using SharpNEX.Editor.UI.Data;

namespace SharpNEX.Editor.UI.Components
{
    internal class TitleBarButtonsController
    {
        private readonly TitleBar _titleBar;

        private readonly ButtonLines _buttonMinimize;
        private readonly ButtonLines _buttonMaximize;
        private readonly ButtonLines _buttonClose;

        public TitleBarButtonsController(TitleBar titleBar)
        {
            _titleBar = titleBar;

            _buttonMinimize = new ButtonLines();
            _buttonMaximize = new ButtonLines();
            _buttonClose = new ButtonLines();
            AdjustButtonts();
        }

        private void AdjustButtonts()
        {
            int x1 = 19; int y1 = 16;
            int x2 = 31; int y2 = 28;
            var titleBarSize = _titleBar.Size;

            _buttonMinimize.Size = new Size(50, 45);
            _buttonMinimize.AddLine(new Line(x1, (y1 + y2) / 2, x2, (y1 + y2) / 2));
            _buttonMinimize.Location = new Point(titleBarSize.Width - 150, 0);
            _buttonMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _buttonMinimize.Click += ButtonMinimizeClick;

            _buttonMaximize.Size = new Size(50, 45);
            _buttonMaximize.AddLine(new Line(x1, y1, x2, y1));
            _buttonMaximize.AddLine(new Line(x2, y1, x2, y2));
            _buttonMaximize.AddLine(new Line(x2, y2, x1, y2));
            _buttonMaximize.AddLine(new Line(x1, y2, x1, y1));
            _buttonMaximize.Location = new Point(titleBarSize.Width - 100, 0);
            _buttonMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _buttonMaximize.Click += ButtonMaximizeClick;

            _buttonClose.Size = new Size(50, 45);
            _buttonClose.AddLine(new Line(x1, y1, x2, y2));
            _buttonClose.AddLine(new Line(x2, y1, x1, y2));
            _buttonClose.Location = new Point(titleBarSize.Width - 50, 0);
            _buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _buttonClose.Click += ButtonCloseClick;

            _titleBar.Controls.Add(_buttonMinimize);
            _titleBar.Controls.Add(_buttonMaximize);
            _titleBar.Controls.Add(_buttonClose);
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
