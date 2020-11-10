using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("CerereUpdate")]
    public partial class ControlSelectieAn : PanelContainerCCL, ILL.iStomaLab.IAllowModification
    {

        #region Declaratii generale

        public event System.EventHandler CerereUpdate;
        private int lAnAfisat = 1983;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlSelectieAn()
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
            this.btnInainte.Click += BtnInainte_Click;
            this.btnInapoi.Click += BtnInapoi_Click;
        }

        private void initTextML()
        {
        }

        public void Initializeaza()
        {
            Initializeaza(DateTime.Now.Year);
        }

        public void Initializeaza(int pAn)
        {
            this.lAnAfisat = pAn;

            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            afiseazaAnul();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnInapoi_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.lAnAfisat += 1;

                afiseazaAnul();

                anuntaModificarea();
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(this.GetFormParinte(), ex.Message);
            }
            finally
            {
                finalizeazaIncarcarea();
            }
        }

        private void BtnInainte_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.lAnAfisat -= 1;

                afiseazaAnul();

                anuntaModificarea();
            }
            catch (Exception ex)
            {
                Mesaj.Eroare(this.GetFormParinte(), ex.Message);
            }
            finally
            {
                finalizeazaIncarcarea();
            }
        }

        #endregion

        #region Metode private

        private void anuntaModificarea()
        {
            if (this.CerereUpdate != null)
                this.CerereUpdate(this, null);
        }

        private void afiseazaAnul()
        {
            this.lblAn.Text = this.lAnAfisat.ToString();
        }

        #endregion

        #region Metode publice

        public DateTime GetDataInceput()
        {
            return new DateTime(this.lAnAfisat, 1, 1, 0, 0, 1);
        }

        public DateTime GetDataSfarsit()
        {
            return new DateTime(this.lAnAfisat, 12, 31, 23, 59, 59);
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }

        #endregion

    }
}
