using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SharpNEX.Editor.UI.GUI
{
    public partial class FormTitleBarlessBase : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        const int GWL_STYLE = -16;
        const int WS_CAPTION = 0x00C00000;

        public FormTitleBarlessBase()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IntPtr hwnd = this.Handle;
            int style = GetWindowLong(hwnd, GWL_STYLE);
            SetWindowLong(hwnd, GWL_STYLE, style & ~WS_CAPTION);

            this.Width += 1;
            this.Width -= 1;
        }
    }
}
