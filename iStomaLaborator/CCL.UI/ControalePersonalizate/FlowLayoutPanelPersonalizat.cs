using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CCL.UI
{
    public class FlowLayoutPanelPersonalizat : FlowLayoutPanel
    {
        protected Form GetFormParinte()
        {
            return IHMUtile.GetFormParinte(this);
            //Control parinte = this.Parent;// this.Parent;

            //do
            //{
            //    if (parinte != null)
            //    {
            //        if (parinte is Form)
            //            return parinte as Form;
            //        else
            //            parinte = parinte.Parent;
            //    }

            //} while (parinte == null);

            //return null;
        }

        public FlowLayoutPanelPersonalizat()
        {
            SeteazaDoubleBuffer();
        }

        public FlowLayoutPanelPersonalizat(IContainer container)
            : this()
        {
            container.Add(this);
        }

        private void SeteazaDoubleBuffer()
        {
            // this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.Font = CDL.iStomaLab.CDefinitiiComune._Font_DPI;
            // this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private bool lPermiteFocusLaMouseHover = true;
        public void PermiteFocus(bool pPermite)
        {
            this.lPermiteFocusLaMouseHover = pPermite;
        }

        protected override void OnMouseHover(EventArgs e)
        {
            if (this.lPermiteFocusLaMouseHover)
                this.Focus();

            base.OnMouseHover(e);
        }

        public void IncepeIncarcarea()
        {
            this.SuspendLayout();
        }

        public void FinalizeazaIncarcarea()
        {
            this.ResumeLayout();
        }

        public void AplicaFactorDPI()
        {
            //this.Location = new System.Drawing.Point(Convert.ToInt32(this.Location.X * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X), Convert.ToInt32(this.Location.Y * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_Y));
            this.Width = Convert.ToInt32(this.Width * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
            this.Height = Convert.ToInt32(this.Height * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_Y);
        }

    }
}
