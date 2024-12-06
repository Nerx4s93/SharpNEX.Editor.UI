using System.Windows.Forms;

namespace SharpNEX.Editor.UI
{
    public partial class CustomFromBaase : Form
    {
        public CustomFromBaase()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_SIZEBOX = 0x40000;
                var cp = base.CreateParams;
                cp.Style |= WS_SIZEBOX;
                return cp;
            }
        }
    }
}
