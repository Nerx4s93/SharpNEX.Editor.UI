using System.Drawing;
using System.Windows.Forms;

namespace SharpNEX.Editor.UI
{
    public class ToolStripRenderer : ToolStripProfessionalRenderer
    {
        private readonly Color _foreColor;
        private readonly Color _fonColor;
        private readonly Color _itemSelectedColor;
        private readonly Color _itemPressedColor;

        public ToolStripRenderer(Color foreColot, Color fonColor, Color itemSelectedColor, Color itemPressedColor)
        {
            _foreColor = foreColot;
            _fonColor = fonColor;
            _itemSelectedColor = itemSelectedColor;
            _itemPressedColor = itemPressedColor;
        }

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

            item.ForeColor = _foreColor;

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
            e.TextColor = _foreColor;
            base.OnRenderItemText(e);
        }
    }
}
