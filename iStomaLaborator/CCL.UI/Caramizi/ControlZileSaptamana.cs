using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace CCL.UI.Caramizi
{
    [DefaultEvent("SelectieSchimbata")]
    public partial class ControlZileSaptamana : Panel
    {

        #region Declaratii generale

        public event System.EventHandler SelectieSchimbata;
        private bool lSeIncarca = false;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlZileSaptamana()
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
            this.chkLuni.CheckedChanged += chkZi_CheckedChanged;
            this.chkMarti.CheckedChanged += chkZi_CheckedChanged;
            this.chkMiercuri.CheckedChanged += chkZi_CheckedChanged;
            this.chkJoi.CheckedChanged += chkZi_CheckedChanged;
            this.chkVineri.CheckedChanged += chkZi_CheckedChanged;
            this.chkSambata.CheckedChanged += chkZi_CheckedChanged;
            this.chkDuminica.CheckedChanged += chkZi_CheckedChanged;
        }

        private void initTextML()
        {
            this.lblLuni.Text = CDL.iStomaLab.CConstante.ZileDinDouaLitere.Substring(0, 2);
            this.lblMarti.Text = CDL.iStomaLab.CConstante.ZileDinDouaLitere.Substring(2, 2);
            this.lblMiercuri.Text = CDL.iStomaLab.CConstante.ZileDinDouaLitere.Substring(4, 2);
            this.lblJoi.Text = CDL.iStomaLab.CConstante.ZileDinDouaLitere.Substring(6, 2);
            this.lblVineri.Text = CDL.iStomaLab.CConstante.ZileDinDouaLitere.Substring(8, 2);
            this.lblSambata.Text = CDL.iStomaLab.CConstante.ZileDinDouaLitere.Substring(10, 2);
            this.lblDuminica.Text = CDL.iStomaLab.CConstante.ZileDinDouaLitere.Substring(12, 2);
        }

        public void Initializeaza(int pZileBifate)
        {
            incepeIncarcarea();
            if (pZileBifate > 0)
            {
                int verif = pZileBifate & 1;
                this.chkLuni.Checked = (verif == 1);

                verif = pZileBifate & 2;
                this.chkMarti.Checked = verif == 2;

                verif = pZileBifate & 4;
                this.chkMiercuri.Checked = verif == 4;

                verif = pZileBifate & 8;
                this.chkJoi.Checked = verif == 8;

                verif = pZileBifate & 16;
                this.chkVineri.Checked = verif == 16;

                verif = pZileBifate & 32;
                this.chkSambata.Checked = verif == 32;

                verif = pZileBifate & 64;
                this.chkDuminica.Checked = verif == 64;
            }
            else
            {
                this.chkLuni.Checked = true;
                this.chkMarti.Checked = true;
                this.chkMiercuri.Checked = true;
                this.chkJoi.Checked = true;
                this.chkVineri.Checked = true;
                this.chkSambata.Checked = false;
                this.chkDuminica.Checked = false;
            }
            finalizeazaIncarcarea();
        }

        public void Initializeaza(DayOfWeek pZiBifata)
        {
            List<DayOfWeek> listaZile = new List<DayOfWeek>();
            listaZile.Add(pZiBifata);
            Initializeaza(listaZile);
        }

        public void Initializeaza(List<DayOfWeek> pListaZileBifate)
        {
            incepeIncarcarea();

            if (pListaZileBifate == null)
            {
                this.chkLuni.Checked = true;
                this.chkMarti.Checked = true;
                this.chkMiercuri.Checked = true;
                this.chkJoi.Checked = true;
                this.chkVineri.Checked = true;
                this.chkSambata.Checked = false;
                this.chkDuminica.Checked = false;
            }
            else
            {
                this.chkLuni.Checked = pListaZileBifate.Contains(DayOfWeek.Monday);
                this.chkMarti.Checked = pListaZileBifate.Contains(DayOfWeek.Tuesday);
                this.chkMiercuri.Checked = pListaZileBifate.Contains(DayOfWeek.Wednesday);
                this.chkJoi.Checked = pListaZileBifate.Contains(DayOfWeek.Thursday);
                this.chkVineri.Checked = pListaZileBifate.Contains(DayOfWeek.Friday);
                this.chkSambata.Checked = pListaZileBifate.Contains(DayOfWeek.Saturday);
                this.chkDuminica.Checked = pListaZileBifate.Contains(DayOfWeek.Sunday);
            }

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        void chkZi_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;

            if (SelectieSchimbata != null)
                SelectieSchimbata(sender, e);
        }

        #endregion

        #region Metode private

        private void incepeIncarcarea()
        {
            this.lSeIncarca = true;
        }

        private void finalizeazaIncarcarea()
        {
            this.lSeIncarca = false;
        }

        #endregion

        #region Metode publice

        public List<DayOfWeek> GetZileBifate()
        {
            List<DayOfWeek> listaRetur = new List<DayOfWeek>();

            if (this.chkLuni.Checked)
                listaRetur.Add(DayOfWeek.Monday);

            if (this.chkMarti.Checked)
                listaRetur.Add(DayOfWeek.Tuesday);

            if (this.chkMiercuri.Checked)
                listaRetur.Add(DayOfWeek.Wednesday);

            if (this.chkJoi.Checked)
                listaRetur.Add(DayOfWeek.Thursday);

            if (this.chkVineri.Checked)
                listaRetur.Add(DayOfWeek.Friday);

            if (this.chkSambata.Checked)
                listaRetur.Add(DayOfWeek.Saturday);

            if (this.chkDuminica.Checked)
                listaRetur.Add(DayOfWeek.Sunday);

            return listaRetur;
        }

        #endregion

    }
}
