using BLL.iStomaLab;
using BLL.iStomaLab.Comune;
using iStomaLab.Generale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iStomaLab.ServiciiExterne
{
    public partial class FormCursBNR : FormPersonalizat
    {

        #region Declaratii generale


        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormCursBNR()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.DeschideLaPozitiaMouseului = true;
                this.DeschidereMouseStangaJos();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
            this.chkEuAlegCursulDeSchimb.CerereUpdate += ChkEuAlegCursulDeSchimb_CerereUpdate;
            this.ctrlValidareAnulare.Validare += CtrlValidareAnulare_Validare;
        }

        private void CtrlValidareAnulare_Validare(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.chkEuAlegCursulDeSchimb.Checked)
                {
                    BComportamentAplicatie.SetCursBNR(this.txtCursSchimb.ValoareDouble);
                }

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

        private void initTextML()
        {
            this.Text = string.Empty;
            this.chkEuAlegCursulDeSchimb.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.EuAlegCursulDeSchimb);
            this.lblCursSchimb.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CursSchimb);
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

            this.chkEuAlegCursulDeSchimb.Checked = BComportamentAplicatie.GetSeFolosesteCursBNRSetatDeUser();
            this.txtCursSchimb.ValoareDouble = BComportamentAplicatie.GetCursBNR();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void ChkEuAlegCursulDeSchimb_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BComportamentAplicatie.SetSeFolosesteCursBNRSetatDeUser(this.chkEuAlegCursulDeSchimb.Checked);
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

        public static bool Afiseaza(Form pEcranPariente)
        {
            using (FormCursBNR ecran = new FormCursBNR())
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
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
