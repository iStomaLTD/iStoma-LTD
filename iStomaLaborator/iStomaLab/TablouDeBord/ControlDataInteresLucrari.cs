using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iStomaLab.Generale;
using BLL.iStomaLab.Comune;
using BLL.iStomaLab;

namespace iStomaLab.TablouDeBord
{
    [DefaultEvent("CerereUpdate")]
    public partial class ControlDataInteresLucrari : UserControlPersonalizat
    {

        #region Declaratii generale

        public event System.EventHandler CerereUpdate;

        private BComportamentAplicatie.Enum_TablouDeBord_DataInteres lDataInteres = BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataPrimire;
        private bool lSalveazaComportamentul = true;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDataInteresLucrari()
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
            this.rbDataTermen.CheckedChanged += DataInteres_CheckedChanged;
            this.rbDataPrimire.CheckedChanged += DataInteres_CheckedChanged;
            this.rbDataLaGata.CheckedChanged += DataInteres_CheckedChanged;
            this.rbDataCreare.CheckedChanged += DataInteres_CheckedChanged;
        }

        private void initTextML()
        {
            this.rbDataTermen.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataTermen);
            this.rbDataPrimire.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataPrimire);
            this.rbDataLaGata.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataLaGata);
            this.rbDataCreare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DataCreare);
            this.lblAfiseazaLucrarileInFunctieDe.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.AfiseazaLucrarileInFunctieDe);
        }

        public void Initializeaza()
        {
            Initializeaza(true);
        }

        public void Initializeaza(bool pSalveazaComportamentul)
        {
            Initializeaza(BComportamentAplicatie.TablouDeBord_GetDataInteres(), pSalveazaComportamentul);
        }

        public void Initializeaza(BComportamentAplicatie.Enum_TablouDeBord_DataInteres pDataInteres, bool pSalveazaComportamentul)
        {
            base.InitializeazaVariabileleGenerale();

            this.lDataInteres = pDataInteres;
            this.lSalveazaComportamentul = pSalveazaComportamentul;

            incepeIncarcarea();

            initDataInteres();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void DataInteres_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if ((sender as RadioButton).Checked)
                {
                    if (this.lSalveazaComportamentul)
                    {
                        BComportamentAplicatie.TablouDeBord_SetDataInteres(GetDataInteres());
                    }

                    cereUpdate();
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

        #endregion

        #region Metode private

        private void initDataInteres()
        {
            switch (this.lDataInteres)
            {
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataCreare:
                    this.rbDataCreare.Checked = true;
                    break;
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataPrimire:
                    this.rbDataPrimire.Checked = true;
                    break;
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataLaGata:
                    this.rbDataLaGata.Checked = true;
                    break;
                case BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataTermen:
                    this.rbDataTermen.Checked = true;
                    break;
            }
        }

        private void cereUpdate()
        {
            if (this.CerereUpdate != null)
                CerereUpdate(this, null);
        }

        #endregion

        #region Metode publice

        public BComportamentAplicatie.Enum_TablouDeBord_DataInteres GetDataInteres()
        {
            if (this.rbDataCreare.Checked)
                return BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataCreare;

            if (this.rbDataPrimire.Checked)
                return BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataPrimire;

            if (this.rbDataTermen.Checked)
                return BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataTermen;

            if (this.rbDataLaGata.Checked)
                return BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataLaGata;

            return BComportamentAplicatie.Enum_TablouDeBord_DataInteres.DataCreare;
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
