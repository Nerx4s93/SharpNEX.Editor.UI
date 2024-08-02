using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SharpNEX.Editor.UI.Components
{
    internal class FormMover
    {
        private Control _control;

        #region user32.dll

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        #endregion

        public FormMover(Control control)
        {
            _control = control;
            control.MouseDown += OnMouseDown;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var form = _control.Parent;
                ReleaseCapture();
                SendMessage(form.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}
