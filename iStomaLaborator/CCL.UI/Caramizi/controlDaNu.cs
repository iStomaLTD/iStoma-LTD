using System;
using System.ComponentModel;
using EnumRaspuns = CDL.iStomaLab.CDefinitiiComune.EnumRaspuns;
using ILL.iStomaLab;
using CCL.iStomaLab;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("Raspuns")]
    public partial class controlDaNu : PanelContainerCCL, IAllowModification
    {

        #region Declaratii generale

        public event CEvenimente.RaspunsDelegate Raspuns;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public controlDaNu()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.chkDa.Text = CUtil.getText(1);
            this.chkNu.Text = CUtil.getText(2);
        }

        public void Initializeaza(EnumRaspuns pRaspuns)
        {
            this.lSeIncarca = true;
            this.chkDa.Checked = pRaspuns == EnumRaspuns.Da;
            this.chkNu.Checked = pRaspuns == EnumRaspuns.Nu;
            this.lSeIncarca = false;
        }

        #endregion

        #region Evenimente

        private void chkNu_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            this.lSeIncarca = true;
            if (this.chkNu.Checked)
                this.chkDa.Checked = false;
            anuntaNoulRaspuns();
            this.lSeIncarca = false;
        }

        private void chkDa_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            this.lSeIncarca = true;
            if (this.chkDa.Checked)
                this.chkNu.Checked = false;
            anuntaNoulRaspuns();
            this.lSeIncarca = false;
        }

        #endregion

        #region Metode private

        private void anuntaNoulRaspuns()
        {
            if (this.Raspuns != null)
            {
                EnumRaspuns noulRaspuns = EnumRaspuns.NuStiu;
                if (this.chkDa.Checked)
                    noulRaspuns = EnumRaspuns.Da;
                else
                    if (this.chkNu.Checked)
                        noulRaspuns = EnumRaspuns.Nu;
                Raspuns(this, noulRaspuns);
            }
        }

        #endregion

        #region Metode publice



        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.chkDa.AllowModification(this.lEcranInModificare);
            this.chkNu.AllowModification(this.lEcranInModificare);
        }

        #endregion
               
    }
}
