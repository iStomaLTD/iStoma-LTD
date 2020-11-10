using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("Schimba")]
    public partial class ControlStangaDreapta : UserControl
    {
        public event SchimbareHandler Schimba;
        public delegate void SchimbareHandler(bool pInainte);

        public ControlStangaDreapta()
        {
            InitializeComponent();
        }

        private void anuntaSchimbarea(bool pInainte)
        {
            if (Schimba != null)
                Schimba(pInainte);
        }

        private void btnStanga_Click(object sender, EventArgs e)
        {
            anuntaSchimbarea(false);
        }

        private void btnDreapta_Click(object sender, EventArgs e)
        {
            anuntaSchimbarea(true);
        }
    }
}
