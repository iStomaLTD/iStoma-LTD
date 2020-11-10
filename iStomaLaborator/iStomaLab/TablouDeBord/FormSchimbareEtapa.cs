using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Preturi;
using CCL.iStomaLab;
using CCL.UI;
using CDL.iStomaLab;
using iStomaLab.Generale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static CDL.iStomaLab.CDefinitiiComune;

namespace iStomaLab.TablouDeBord
{
    public partial class FormSchimbareEtapa : FormPersonalizat
    {

        #region Declaratii generale

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormSchimbareEtapa()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.lgfEtapa.DeschideEcranCautare += LgfEtapa_DeschideEcranCautare;
            this.lgfTehnician.DeschideEcranCautare += LgfTehnician_DeschideEcranCautare;
            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;
            this.lblStare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stare);
            this.chkRefacere.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Refacere);
        }

        private void initTextML()
        {
            this.Text = string.Empty;
            this.lblTehnician.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician);
            this.lblEtapa.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Etapa);
            this.lblTermen.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Termen);
        }

        void _Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza();
                AllowModification(true);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.lgfEtapa.FolosesteToString = true;
            this.lgfTehnician.FolosesteToString = true;
            this.ctrlDataTermen.Initializeaza(DateTime.Now, CCL.UI.ComboBoxOra.EnumPas.JumatateDeOra);
            this.cboStare.DataSource = BClientiComenziEtape.StructStareEtapa.GetList();
            this.cboStare.DropDownStyle = ComboBoxStyle.DropDownList;

            this.lgfTehnician.Goleste();
            this.lgfEtapa.Goleste();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void LgfEtapa_DeschideEcranCautare(Control psender, object pxObiectExistent)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BEtape etapa = FormListaEtape.Afiseaza(this);
                if (etapa != null)
                {
                    this.lgfEtapa.ObiectCorespunzator = etapa;
                }
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

        private void LgfTehnician_DeschideEcranCautare(Control psender, object pxObiectExistent)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.lgfTehnician.ObiectCorespunzator = FormListaUtilizatori.Afiseaza(this, EnumRol.Tehnician);
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

        private void CtrlValidareAnulare_Validare(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.salveaza())
                    inchideEcranulOK();
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

        private bool verifica()
        {
            return this.lgfEtapa.IdObiectCorespunzator != 0;

            //if (!esteOk)
            //{
            //    CCL.UI.IHMEfecteSpeciale.AplicaEfectNU(this);
            //    CCL.UI.IHMEfecteSpeciale.SeteazaForeColorAlerta(this.lgfEtapa, this.lblEtapa);
            //}
            //return esteOk;
        }
        private bool salveaza()
        {
            if (!suntCompleteInformatiile())
            {
                seteazaAlerta();
                return false;
            }
            return true;
        }

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.AplicaEfectNU(this);

            if(!this.lgfEtapa.AreValoare())
                IHMEfecteSpeciale.SeteazaForeColorAlerta(this.lgfEtapa, this.lblEtapa);

            if (!this.lgfTehnician.AreValoare())
                IHMEfecteSpeciale.SeteazaForeColorAlerta(this.lgfTehnician, this.lblTehnician);
            seteazaFocus();
        }

        private bool suntCompleteInformatiile()
        {
            return this.lgfEtapa.AreValoare() && this.lgfTehnician.AreValoare();
        }

        private void seteazaFocus()
        {
            Control[] lstFocus = { this.lgfEtapa };
            foreach (var control in lstFocus)
            {
                if (string.IsNullOrEmpty(control.Text))
                {
                    control.Focus();
                    break;
                }
                else
                {
                    this.lgfEtapa.Focus();
                }
            }
        }

        #endregion

        #region Metode publice

        public static Tuple<int, int, DateTime, bool, int> Afiseaza(Form pEcranPariente)
        {
            using (FormSchimbareEtapa ecran = new FormSchimbareEtapa())
            {
                ecran.AplicaPreferinteleUtilizatorului();
                if (CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran) && ecran.verifica())
                {
                    if (ecran.verifica())
                        return new Tuple<int, int, DateTime, bool, int>(ecran.lgfEtapa.IdObiectCorespunzator, ecran.lgfTehnician.IdObiectCorespunzator, ecran.ctrlDataTermen.DataAfisata, ecran.chkRefacere.Checked, ecran.cboStare.SelectedIndex);
                }

            }

            return null;
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
