using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using SharpNEX.Editor.UI.Components;

#pragma warning disable CS0114

namespace SharpNEX.Editor.UI
{
    public class TitleBar : Control
    {
        private FormMover _formMover;
        private TrackingFormActivity _trackingFormActivity;
        private TitleBarButtonsController _titleBarButtonsController;

        public TitleBar()
        {
            DoubleBuffered = true;
            base.Dock = DockStyle.Top;
            BackColor = Color.FromArgb(31, 31, 31);
            ForeColor = Color.White;
        }

        #region Свойства

        [Browsable(false)]
        public DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {

            }
        }

        public Color LogoColorFormNotActive { get; set; } = Color.Gray;

        public Color LogoColorFormActive { get; set; } = Color.White;

        public Color ForeColorFormActive { get; set; } = Color.White;

        #endregion

        protected override void CreateHandle()
        {
            base.CreateHandle();
            _formMover = new FormMover(this);
            _trackingFormActivity = new TrackingFormActivity(this, FindForm());
            _titleBarButtonsController = new TitleBarButtonsController(this);
        }

        private void DrawSvg(Graphics graphics)
        {
            var form = FindForm();

            var svgDocument = SvgController.GetSvgDocumentFromResourcesName("logo");

            var svgColor = _trackingFormActivity.IsFormActive ? LogoColorFormActive : LogoColorFormNotActive;
            SvgController.ChangeFillColor(svgDocument, svgColor);

            var image = SvgController.GetBitmapFromSvgDocument(svgDocument, new Size(Size.Height, Size.Height / 2));
            graphics.DrawImage(image, 0, Size.Height / 2 - Size.Height / 4);
        }

        private void DrawText(Graphics graphics)
        {
            var textSize = graphics.MeasureString(Text, Font);

            var textColor = _trackingFormActivity.IsFormActive ? ForeColorFormActive : ForeColor;
            using (var solidBrush = new SolidBrush(textColor))
            {
                float textLocationX = Size.Height + 15;
                float textLocationY = (Size.Height - textSize.Height) / 2;

                graphics.DrawString(Text, Font, solidBrush, new PointF(textLocationX, textLocationY));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;

            DrawSvg(graphics);
            DrawText(graphics);
        }
    }
}
