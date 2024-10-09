using System.Drawing;
using System.Windows.Forms;

namespace SharpNEX.Editor.UI
{
    public class TreeViewGameObjects : TreeView
    {
        public TreeViewGameObjects()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawText;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            var clickedNode = GetNodeAt(e.Location);

            if (clickedNode != null)
            {
                var nodeBounds = new Rectangle(0, clickedNode.Bounds.Y, ClientSize.Width, clickedNode.Bounds.Height);

                if (nodeBounds.Contains(e.Location))
                {
                    SelectedNode = clickedNode;
                }
            }
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            var nodeBounds = new Rectangle(e.Bounds.X, e.Bounds.Y, ClientSize.Width - e.Bounds.X, e.Bounds.Height);

            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, nodeBounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, Font, nodeBounds, SystemColors.HighlightText, TextFormatFlags.VerticalCenter);
            }
            else
            {
                e.Graphics.FillRectangle(SystemBrushes.Window, nodeBounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, Font, nodeBounds, SystemColors.WindowText, TextFormatFlags.VerticalCenter);
            }

            e.DrawDefault = false;
        }
    }
}
