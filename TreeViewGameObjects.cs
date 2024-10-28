using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using SharpNEX.Engine;

namespace SharpNEX.Editor.UI
{
    public class TreeViewGameObjects : TreeView
    {
        public TreeViewGameObjects()
        {
            LabelEdit = true;
            DrawMode = TreeViewDrawMode.OwnerDrawText;
            LoadTreeView();
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
            else
            {
                SelectedNode = null;
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

        protected override void OnDoubleClick(EventArgs e)
        {
            SelectedNode?.BeginEdit();
        }

        protected override void OnAfterLabelEdit(NodeLabelEditEventArgs e)
        {
            var gameObject = e.Node.Tag as GameObject;
            gameObject.Name = e.Label;
        }

        public void LoadTreeView()
        {
            Nodes.Clear();

            var gameObjects = Game.Data.Scene?.GetGameObjects();

            if (gameObjects != null)
            {
                foreach (var gameObject in gameObjects)
                {
                    AddGameObjectToTreeView(gameObject);
                }
            }
        }

        public TreeNode AddGameObjectToTreeView(GameObject gameObject)
        {
            var treeNode = new TreeNode(gameObject.Name)
            {
                Tag = gameObject
            };

            if (gameObject.Parent == null)
            {
                Nodes.Add(treeNode);
            }
            else
            {
                var treeNodeList = GetAllNodes(this);

                var treeNodeParent = treeNodeList.Find(x => x.Tag as GameObject == gameObject.Parent);

                treeNodeParent.Nodes.Add(treeNode);
            }

            return treeNode;
        }

        public static List<TreeNode> GetAllNodes(TreeView treeView)
        {
            var result = new List<TreeNode>();
            foreach (TreeNode child in treeView.Nodes)
            {
                result.AddRange(GetAllNodes(child));
            }
            return result;
        }

        public static List<TreeNode> GetAllNodes(TreeNode treeNove)
        {
            var result = new List<TreeNode>();
            result.Add(treeNove);
            foreach (TreeNode child in treeNove.Nodes)
            {
                result.AddRange(GetAllNodes(child));
            }
            return result;
        }
    }
}
