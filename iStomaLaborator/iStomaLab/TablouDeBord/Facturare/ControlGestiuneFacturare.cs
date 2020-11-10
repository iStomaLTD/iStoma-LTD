using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iStomaLab.Generale;
using BLL.iStomaLab;
using CCL.UI;
using BLL.iStomaLab.Clienti;
using CDL.iStomaLab;
using CCL.iStomaLab;

namespace iStomaLab.TablouDeBord.Facturare
{
    public partial class ControlGestiuneFacturare : UserControlPersonalizat
    {

        #region Declaratii generale

        private EnumZonaActiva lZonaActiva = EnumZonaActiva.LucrariNefacturate;

        private TablouDeBord.Facturare.ControlListaLucrariNefacturate lctrlListaLucrariNefacturate = null;
        private TablouDeBord.Facturare.ControlListaFacturiEmise lctrlListaFacturiEmise = null;
        private TablouDeBord.Facturare.ControlListaIncasari lctrlListaIncasari = null;  

        #endregion

        #region Enumerari si Structuri

        private enum EnumZonaActiva
        {
            LucrariNefacturate,
            FacturiEmise,
            Incasari
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlGestiuneFacturare()
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
            this.mnuBtnFacturiEmise.Click += MnuBtnFacturare_Click;
            this.mnuBtnIncasari.Click += MnuBtnFacturare_Click;
            this.mnuBtnLucrariNefacturate.Click += MnuBtnFacturare_Click;
        }

        private void initTextML()
        {
            this.mnuBtnFacturiEmise.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.FacturiEmise);
            this.mnuBtnLucrariNefacturate.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.LucrariNefacturate);
            this.mnuBtnIncasari.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Incasari);
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            this.mnuBtnLucrariNefacturate.Tag = EnumZonaActiva.LucrariNefacturate;
            this.mnuBtnFacturiEmise.Tag = EnumZonaActiva.FacturiEmise;
            this.mnuBtnIncasari.Tag = EnumZonaActiva.Incasari;

            incarcaZonaSelectata(this.lZonaActiva);

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void MnuBtnFacturare_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                EnumZonaActiva zona = (EnumZonaActiva)(sender as ToolStripButton).Tag;

                incarcaZonaSelectata(zona);

                CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnFacturiEmise, this.lZonaActiva == EnumZonaActiva.FacturiEmise);
                CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnLucrariNefacturate, this.lZonaActiva == EnumZonaActiva.LucrariNefacturate);
                CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnIncasari, this.lZonaActiva == EnumZonaActiva.Incasari);
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

        private void incarcaZonaSelectata(EnumZonaActiva pZona)
        {
            this.lZonaActiva = pZona;
            if (this.lctrlListaLucrariNefacturate != null)
                this.lctrlListaLucrariNefacturate.Visible = false;
            if (this.lctrlListaFacturiEmise != null)
                this.lctrlListaFacturiEmise.Visible = false;

            switch (pZona)
            {
                case EnumZonaActiva.LucrariNefacturate:
                    initControlListaLucrariNefacturate();
                    break;
                case EnumZonaActiva.FacturiEmise:
                    initControlListaFacturiEmise();
                    break;
                case EnumZonaActiva.Incasari:
                    initControlListaIncasari();
                    break;
            }
        }

        private void initControlListaLucrariNefacturate()
        {
            if (this.lctrlListaLucrariNefacturate == null)
            {
                this.lctrlListaLucrariNefacturate = new ControlListaLucrariNefacturate();
                adaugaControlInZonaUtila(this.lctrlListaLucrariNefacturate);
            }

            this.lctrlListaLucrariNefacturate.Initializeaza();
            this.lctrlListaLucrariNefacturate.Visible = true;
            this.lctrlListaLucrariNefacturate.BringToFront();
        }

        private void initControlListaFacturiEmise()
        {
            if (this.lctrlListaFacturiEmise == null)
            {
                this.lctrlListaFacturiEmise = new ControlListaFacturiEmise();
                adaugaControlInZonaUtila(this.lctrlListaFacturiEmise);
            }

            this.lctrlListaFacturiEmise.Initializeaza();
            this.lctrlListaFacturiEmise.Visible = true;
            this.lctrlListaFacturiEmise.BringToFront();
        }

        private void initControlListaIncasari()
        {
            if (this.lctrlListaIncasari == null)
            {
                this.lctrlListaIncasari = new ControlListaIncasari();
                adaugaControlInZonaUtila(this.lctrlListaIncasari);
            }

            this.lctrlListaIncasari.Initializeaza();
            this.lctrlListaIncasari.Visible = true;
            this.lctrlListaIncasari.BringToFront();
        }


        private void adaugaControlInZonaUtila(Control pControl)
        {
            this.panelFacturare.Controls.Add(pControl);
            pControl.Size = this.panelFacturare.Size;
            pControl.Dock = DockStyle.Fill;
        }

        #endregion

        #region Metode publice



        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }

        #endregion

    }
}
