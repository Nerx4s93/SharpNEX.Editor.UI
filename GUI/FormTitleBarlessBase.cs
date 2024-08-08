using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SharpNEX.Editor.UI.GUI
{
    public partial class FormTitleBarlessBase : Form
    {
        #region user32.dll

        [DllImport("user32.dll", SetLastError = true)]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        const int GWL_STYLE = -16;
        const int WS_CAPTION = 0x00C00000;

        #endregion

        public FormTitleBarlessBase()
        {
            InitializeComponent();
        }

        private void FormTitleBarlessBase_Load(object sender, EventArgs e)
        {
            IntPtr hwnd = Handle;
            int style = GetWindowLong(hwnd, GWL_STYLE);
            SetWindowLong(hwnd, GWL_STYLE, style & ~WS_CAPTION);

            Width += 1;
            Width -= 1;
        }
    }
}
