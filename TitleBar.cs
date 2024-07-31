using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#pragma warning disable CS0114

namespace SharpNEX.Editor.UI
{
    public class TitleBar : Control
    {
        private FormMover _formMover;

        public TitleBar()
        {
            DoubleBuffered = true;
            Dock = DockStyle.Top;
            BackColor = Color.FromArgb(31, 31, 31);
        }

        #region Свойства

        public DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            private set
            {
                base.Dock = value;
            }
        }

        #endregion

        protected override void CreateHandle()
        {
            base.CreateHandle();
            _formMover = new FormMover(this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var graphics = e.Graphics;
        }
    }
}
