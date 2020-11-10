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

namespace iStomaLab.Setari.Lucrari
{
    public partial class ControlGestiuneListaDePreturi : UserControlPersonalizat
    {

        #region Declaratii generale

        private EnumZonaSelectata lZonaSelectata = EnumZonaSelectata.PreturiStandard;
        private Setari.Lucrari.ControlListaDePreturi lctrlListaDePreturi = null;
        private Setari.Lucrari.ControlListaDePreturiClienti lctrlListaDePreturiClienti = null;
        private Setari.Lucrari.ControlEtape lctrlEtape = null;

        #endregion

        #region Enumerari si Structuri

        private enum EnumZonaSelectata
        {
            PreturiStandard = 0,
            PreturiClienti = 1,
            Etape = 2
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlGestiuneListaDePreturi()
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
            this.mnuBtnPreturiStandard.Click += MnuBtn_Click;
            this.mnuBtnPreturiClienti.Click += MnuBtn_Click;
            this.mnuBtnEtape.Click += MnuBtn_Click;
        }

        private void initTextML()
        {

        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            this.mnuBtnEtape.Tag = EnumZonaSelectata.Etape;
            this.mnuBtnPreturiStandard.Tag = EnumZonaSelectata.PreturiStandard;
            this.mnuBtnPreturiClienti.Tag = EnumZonaSelectata.PreturiClienti;

            incepeIncarcarea();
            afiseazaZona(EnumZonaSelectata.PreturiStandard);
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente
        
        private void MnuBtn_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                EnumZonaSelectata zonaSelectata =(EnumZonaSelectata) (sender as ToolStripButton).Tag;
                afiseazaZona(zonaSelectata);
                
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

        private void afiseazaZona(EnumZonaSelectata pZona)
        {
            this.lZonaSelectata = pZona;

            if (this.lctrlListaDePreturi != null)
                this.lctrlListaDePreturi.Visible = false;
            if (this.lctrlListaDePreturiClienti != null)
                this.lctrlListaDePreturiClienti.Visible = false;
            if (this.lctrlEtape != null)
                this.lctrlEtape.Visible = false;

            switch (pZona)
            {
                case EnumZonaSelectata.PreturiStandard:
                    initControlListaPreturiStandard();
                    break;
                case EnumZonaSelectata.PreturiClienti:
                    initControlListaPreturiClienti();
                    break;
                case EnumZonaSelectata.Etape:
                    initControlListaEtape();
                    break;
            }
            
        }

        private void initControlListaPreturiStandard()
        {
            aplicaEfectVizual();

            if (this.lctrlListaDePreturi == null)
            {
                this.lctrlListaDePreturi = new ControlListaDePreturi();
                this.lctrlListaDePreturi.Name = "ctrlListaPreturiStandard";
                adaugaControlInZonaUtila(this.lctrlListaDePreturi);
            }

            this.lctrlListaDePreturi.Initializeaza();
            this.lctrlListaDePreturi.Visible = true;
            this.lctrlListaDePreturi.BringToFront();
        }

        private void initControlListaPreturiClienti()
        {
            aplicaEfectVizual();

            if (this.lctrlListaDePreturiClienti == null)
            {
                this.lctrlListaDePreturiClienti = new ControlListaDePreturiClienti();
                this.lctrlListaDePreturiClienti.Name = "ctrlListaPreturiClienti";
                adaugaControlInZonaUtila(this.lctrlListaDePreturiClienti);
            }

            this.lctrlListaDePreturiClienti.Initializeaza();
            this.lctrlListaDePreturiClienti.Visible = true;
            this.lctrlListaDePreturiClienti.BringToFront();
        }

        private void initControlListaEtape()
        {
            aplicaEfectVizual();

            if (this.lctrlEtape == null)
            {
                this.lctrlEtape = new ControlEtape();
                this.lctrlEtape.Name = "ctrlListaEtape";
                adaugaControlInZonaUtila(this.lctrlEtape);
            }

            this.lctrlEtape.Initializeaza();
            this.lctrlEtape.Visible = true;
            this.lctrlEtape.BringToFront();
        }

        private void aplicaEfectVizual()
        {
            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnPreturiStandard, this.lZonaSelectata == EnumZonaSelectata.PreturiStandard);

            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnPreturiClienti, this.lZonaSelectata == EnumZonaSelectata.PreturiClienti);

            CCL.UI.IHMStilAplicatie.AplicaStareButonMeniuSus(this.mnuBtnEtape, this.lZonaSelectata == EnumZonaSelectata.Etape);

        }

        private void adaugaControlInZonaUtila(Control pControl)
        {
            this.panelOptiunePret.Controls.Add(pControl);
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
