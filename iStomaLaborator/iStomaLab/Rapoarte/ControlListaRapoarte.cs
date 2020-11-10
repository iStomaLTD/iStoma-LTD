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

namespace iStomaLab.Rapoarte
{
    public partial class ControlListaRapoarte : UserControlPersonalizat
    {

        #region Declaratii generale

        private ControlRaportEtape ctrlRaportProdTehnicieni;
        private ControlRaportComenzi ctrlRaportComenzi;
        private ControlRaportClientiDatornici ctrlRaportClientiDatornici;
        private ControlRaportClientiNoi ctrlRaportClientiNoi;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlListaRapoarte()
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
            this.dgvListaRapoarte.SelectionChanged += DgvListaRapoarte_SelectionChanged;
        }

        private void initTextML()
        {

        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();

            ConstruiesteColoaneDGV();
            ConstruiesteRanduriDGV();

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void DgvListaRapoarte_SelectionChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.panelContainer.AscundeControaleleIncarcate();

                if (this.dgvListaRapoarte.SelectedRow != null)
                {
                    StructRapoarte raportSelectat = (StructRapoarte)this.dgvListaRapoarte.SelectedRow.Tag;

                    switch (raportSelectat.IdEnum)
                    {
                        case EnumRapoarte.ProductieTehnicieni:
                            creeazaControlRaportProdTehnicieni();
                            break;
                        case EnumRapoarte.Comenzi:
                            creeazaControlRaportComenzi();
                            break;
                        case EnumRapoarte.ClientiDatornici:
                            creeazaControlRaportClientiDatornici();
                            break;
                        case EnumRapoarte.ClientiNoi:
                            creeazaControlRaportClientiNoi();
                            break;
                    }
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
 
        private void creeazaControlRaportClientiNoi()
        {
            if (this.ctrlRaportClientiNoi == null)
            {
                this.ctrlRaportClientiNoi = new iStomaLab.Rapoarte.ControlRaportClientiNoi(); 
                this.ctrlRaportClientiNoi.Dock = System.Windows.Forms.DockStyle.Fill;
                this.ctrlRaportClientiNoi.Location = new System.Drawing.Point(0, 0);
                this.ctrlRaportClientiNoi.Name = "ctrlRaportClientiNoi";
                this.ctrlRaportClientiNoi.Size = new System.Drawing.Size(788, 583);

                this.panelContainer.Controls.Add(this.ctrlRaportClientiNoi);
            }

            this.ctrlRaportClientiNoi.Initializeaza();
            this.ctrlRaportClientiNoi.Visible = true;
        }

        #endregion

        #region Metode private

        private void creeazaControlRaportProdTehnicieni()
        {
            if (this.ctrlRaportProdTehnicieni == null)
            {
                this.ctrlRaportProdTehnicieni = new iStomaLab.Rapoarte.ControlRaportEtape();
                this.ctrlRaportProdTehnicieni.Dock = System.Windows.Forms.DockStyle.Fill;
                this.ctrlRaportProdTehnicieni.Location = new System.Drawing.Point(0, 0);
                this.ctrlRaportProdTehnicieni.Name = "ctrlRaportProdTehnicieni";
                this.ctrlRaportProdTehnicieni.Size = new System.Drawing.Size(788, 583);

                this.panelContainer.Controls.Add(this.ctrlRaportProdTehnicieni);
            }

            this.ctrlRaportProdTehnicieni.Initializeaza();
            this.ctrlRaportProdTehnicieni.Visible = true;
        }
        private void creeazaControlRaportComenzi()
        {
            if (this.ctrlRaportComenzi == null)
            {
                this.ctrlRaportComenzi = new iStomaLab.Rapoarte.ControlRaportComenzi();
                this.ctrlRaportComenzi.Dock = System.Windows.Forms.DockStyle.Fill;
                this.ctrlRaportComenzi.Location = new System.Drawing.Point(0, 0);
                this.ctrlRaportComenzi.Name = "ctrlRaportComenzi";
                this.ctrlRaportComenzi.Size = new System.Drawing.Size(788, 583);

                this.panelContainer.Controls.Add(this.ctrlRaportComenzi);
            }

            this.ctrlRaportComenzi.Initializeaza();
            this.ctrlRaportComenzi.Visible = true;
        }

        private void creeazaControlRaportClientiDatornici()
        {
            if (this.ctrlRaportClientiDatornici == null)
            {
                this.ctrlRaportClientiDatornici = new iStomaLab.Rapoarte.ControlRaportClientiDatornici();
                this.ctrlRaportClientiDatornici.Dock = System.Windows.Forms.DockStyle.Fill;
                this.ctrlRaportClientiDatornici.Location = new System.Drawing.Point(0, 0);
                this.ctrlRaportClientiDatornici.Name = "ctrlRaportClientiDatornici";
                this.ctrlRaportClientiDatornici.Size = new System.Drawing.Size(788, 583);

                this.panelContainer.Controls.Add(this.ctrlRaportClientiDatornici);
            }

            this.ctrlRaportClientiDatornici.Initializeaza();
            this.ctrlRaportClientiDatornici.Visible = true;
        }


        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaRapoarte.IncepeConstructieColoane();

            this.dgvListaRapoarte.AdaugaColoana(CCL.UI.DataGridViewPersonalizat.EnumTipColoana.Denumire);

            this.dgvListaRapoarte.FinalizeazaConstructieColoane();

            this.dgvListaRapoarte.AscundeHeader();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaRapoarte.IncepeContructieRanduri();

            var listaElem = StructRapoarte.GetList();

            //Incarcam lista
            foreach (var elem in listaElem)
            {
                incarcaRand(this.dgvListaRapoarte.AdaugaRandNou(), elem);
            }

            this.dgvListaRapoarte.FinalizeazaContructieRanduri();

        }

        private void incarcaRand(DataGridViewRow pRand, StructRapoarte pElem)
        {
            pRand.Tag = pElem;

            this.dgvListaRapoarte.InitCelulaDenumire(pRand, pElem.Nume);
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
