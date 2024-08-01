using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#pragma warning disable CS0114

namespace SharpNEX.Editor.UI
{
    public class TitleBar : Control
    {
        private FormMover _formMover;
        private TrackingFormActivity _trackingFormActivity;

        public TitleBar()
        {
            DoubleBuffered = true;
            base.Dock = DockStyle.Top;
            BackColor = Color.FromArgb(31, 31, 31);
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

        public Color LogoColorFormNotActive { get; set; } = Color.Black;

        public Color LogoColorFormActive { get; set; } = Color.White;

        #endregion

        protected override void CreateHandle()
        {
            base.CreateHandle();
            _formMover = new FormMover(this);
            _trackingFormActivity = new TrackingFormActivity(this, FindForm());
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var graphics = e.Graphics;
            var form = FindForm();

            var svgDocument = SvgController.GetSvgDocumentFromResourcesName("logo");

            var svgColor = _trackingFormActivity.IsFormActive ? LogoColorFormActive : LogoColorFormNotActive;
            SvgController.ChangeFillColor(svgDocument, svgColor);

            var image = SvgController.GetBitmapFromSvgDocument(svgDocument, new Size(Size.Height, Size.Height / 2));
            graphics.DrawImage(image, -5, Size.Height / 2 - 20);
        }
    }
}
