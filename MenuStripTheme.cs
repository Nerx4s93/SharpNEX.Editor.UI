using System.Drawing;
using System.Windows.Forms;

namespace SharpNEX.Editor.UI
{
    public class MenuStripTheme : MenuStrip
    {
        private ToolStripRenderer _darkStyleRenderer = new ToolStripRenderer(Color.White, Color.FromArgb(31, 31, 31), Color.FromArgb(61, 61, 61), Color.FromArgb(46, 46, 46));

        public MenuStripTheme()
        {
            Renderer = _darkStyleRenderer;
        }
    }
}
