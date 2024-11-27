using System.Windows.Forms;

namespace SharpNEX.Editor.UI
{
    public partial class CustomFromBaase : Form
    {
        public CustomFromBaase()
        {
            InitializeComponent();
        }

        private void CustomFromBaase_Shown(object sender, System.EventArgs e)
        {
            FormCustomizer.RoundEdges(this);
        }

        private void CustomFromBaase_Resize(object sender, System.EventArgs e)
        {
            FormCustomizer.RoundEdges(this);
        }
    }
}
