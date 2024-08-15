using System.Drawing;
using System.Windows.Forms;

namespace SharpNEX.Editor.UI
{
    public class DarkThemeToolStripRenderer : ToolStripProfessionalRenderer
    {
        private readonly Color ForeColor = Color.White;

        private readonly Color _fonColor = Color.FromArgb(31, 31, 31);
        private readonly Color _itemSelectedColor = Color.FromArgb(61, 61, 61);
        private readonly Color _itemPressedColor = Color.FromArgb(46, 46, 46);

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.FillRectangle(new SolidBrush(_fonColor), e.ToolStrip.Bounds);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBorder(e);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var graphics = e.Graphics;

            var item = e.Item;
            var size = item.Size;
            var bounds = new Rectangle(0, 0, size.Width, size.Height);

            item.ForeColor = ForeColor;

            if (e.Item.Selected)
            {
                var brush = new SolidBrush(_itemSelectedColor);
                graphics.FillRectangle(brush, bounds);
            }
            else if (e.Item.Pressed)
            {
                var brush = new SolidBrush(_itemPressedColor);
                graphics.FillRectangle(brush, bounds);
            }
            else
            {
                var brush = new SolidBrush(_fonColor);
                graphics.FillRectangle(brush, bounds);
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = ForeColor;
            base.OnRenderItemText(e);
        }
    }
}
