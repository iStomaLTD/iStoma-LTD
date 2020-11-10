using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CDL.iStomaLab;

namespace iStomaLab.Caramizi
{
    [DefaultEvent("SexModificat")]
    public partial class ControlSex : CCL.UI.PanelPersonalizat
    {

        #region Declaratii generale

        public event System.EventHandler SexModificat;
        private bool lEcranInModificare = true;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlSex()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();
            }
        }

        private void adaugaHandlere()
        {
            this.chkSexF.CheckedChanged += chkSex_CheckedChanged;
            this.chkSexM.CheckedChanged += chkSex_CheckedChanged;
        }

        private void initTextML()
        {
            this.chkSexF.Text = "F";
            this.chkSexM.Text = "M";
        }

        public void Initializeaza(CDefinitiiComune.EnumSex pSex)
        {
            incepeIncarcarea();

            this.chkSexM.Checked = pSex == CDefinitiiComune.EnumSex.Barbatesc;
            this.chkSexF.Checked = pSex == CDefinitiiComune.EnumSex.Femeiesc;

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        void chkSex_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;

            try
            {
                incepeIncarcarea();

                if (sender == this.chkSexF &&  this.chkSexF.Checked)
                    this.chkSexM.Checked = false;
                else
                if (sender == this.chkSexM && this.chkSexM.Checked)
                    this.chkSexF.Checked = false;

                if (this.SexModificat != null)
                    SexModificat(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }
        }

        #endregion

        #region Metode private

        #endregion

        #region Metode publice

        public CDefinitiiComune.EnumSex GetSex()
        {
            if (this.chkSexM.Checked)
                return CDefinitiiComune.EnumSex.Barbatesc;

            if (this.chkSexF.Checked)
                return CDefinitiiComune.EnumSex.Femeiesc;

            return CDefinitiiComune.EnumSex.Nedefinit;
        }

        public void Goleste()
        {
            Initializeaza(CDefinitiiComune.EnumSex.Nedefinit);
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            this.chkSexM.AllowModification(this.lEcranInModificare);
            this.chkSexF.AllowModification(this.lEcranInModificare);
        }

        #endregion

    }
}
