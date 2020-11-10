namespace CCL.UI.ControalePersonalizate
{
    public class TimerPersonalizat : System.Windows.Forms.Timer
    {
        public TimerPersonalizat()
            : base()
        { base.Enabled = true; }

        public TimerPersonalizat(System.ComponentModel.IContainer container)
            : base(container)
        { base.Enabled = true; }

        private bool _Enabled;
        public override bool Enabled
        {
            get { return _Enabled; }
            set { _Enabled = value; }
        }

        protected override void OnTick(System.EventArgs e)
        { if (this.Enabled) base.OnTick(e); }
    }
}
