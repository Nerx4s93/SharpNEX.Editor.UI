using System;
using System.Windows.Forms;

namespace SharpNEX.Editor.UI
{
    internal class TrackingFormActivity
    {
        private Control _control;
        private Form _form;
        private bool _formActive;

        public TrackingFormActivity(Control control, Form form)
        {
            _control = control;
            _form = form;
            _form.Activated += FormActivated;
            _form.Deactivate += FormDeactivate;
        }

        public bool IsFormActive => _formActive;

        private void FormActivated(object sender, EventArgs e)
        {
            _formActive = true;
            _control.Invalidate();
        }

        private void FormDeactivate(object sender, EventArgs e)
        {
            _formActive = false;
            _control.Invalidate();
        }
    }
}
