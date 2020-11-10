using BLL.iStomaLab.Comune;
using CCL.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BLL.iStomaLab.Comune.BComportamentAplicatie;

namespace iStomaLab.Caramizi
{
    class ButonFiltreOrizontala: ButtonPersonalizat
    {
        private EnumComportamentAplicatie lComportamentAsociat = EnumComportamentAplicatie.Nedefinit;

        public ButonFiltreOrizontala()
        {
            this.TipButon = EnumTipButon.GestiuneFiltreOrizontala;
        }

        public void Initializeaza(EnumComportamentAplicatie pComportament, bool pDefaultValue)
        {
            this.lComportamentAsociat = pComportament;

            this.Selectat = !BComportamentAplicatie.GetAsBool(this.lComportamentAsociat, pDefaultValue);
        }

        protected override void OnClick(EventArgs e)
        {
            if (this.lComportamentAsociat != EnumComportamentAplicatie.Nedefinit)
            {
                BComportamentAplicatie.SetAsBool(this.lComportamentAsociat, this.Selectat);
            }

            base.OnClick(e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ButonFiltreOrizontala
            // 
            this.Size = new System.Drawing.Size(35, 23);
            this.ResumeLayout(false);

        }
    }
}
