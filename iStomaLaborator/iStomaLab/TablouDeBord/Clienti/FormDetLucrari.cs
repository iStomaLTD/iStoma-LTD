using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Preturi;
using BLL.iStomaLab.Reprezentanti;
using BLL.iStomaLab.Utilizatori;
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

namespace iStomaLab.TablouDeBord.Clienti
{
    public partial class FormDetLucrari :Generale.FormPersonalizat
    {

        #region Declaratii generale   
            private BClienti pClient;
            private BListaPreturiStandard pLucrare;
            private List<Tuple<BListaPreturiStandard, BListaPreturiClienti>> lLucrareSelectata = null;
            private BClientiComenziHeader lComanda = null;
            private BClienti lClient = null;
        #endregion

        #region Constructor si Initializare

        public FormDetLucrari(BClientiComenzi pComanda, BClienti pClient, BListaPreturiStandard pLucrare)
        {
            this.pClient = pClient;
            this.pLucrare = pLucrare;
        
            this.DoubleBuffered = true;
            InitializeComponent();

           // this.lComanda = pComanda;
            this.lClient = pClient;           

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
            this.cboEtapaCurenta.SelectedIndexChanged += CboEtapaCurenta_SelectedIndexChanged;
            this.lgfTehnician.DeschideEcranCautare += TxtCautaTehnician_DeschideEcranCautare;
            this.btnVeziToateEtapele.Click += BtnVeziToateEtapele_Click;           
        }

        private void initTextML()
        {
            this.lblTehnician.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tehnician);           
            this.lblObservatiiEtapaCurenta.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);            
            this.lblEtapaCurenta.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Etapa);           
            this.lblTermen.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Termen);
            this.chkRefacere.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Refacere);
            this.lblStare.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stare);
            this.gbEtapaCurenta.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.EtapaCurenta);           
            this.btnVeziToateEtapele.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.VeziToateEtapele);            
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
          
            this.btnVeziToateEtapele.Visible = this.lComanda != null;
            this.lgfTehnician.FolosesteToString = true;
            this.lgfTehnician.AfiseazaButonGuma = false;
          //  ConstruiesteColoaneDGV();
          //  ConstruiesteRanduriDGV();

            if (this.lComanda == null)
            {
                this.lgfTehnician.Goleste();             
                this.ctrlDataOraTermen.Initializeaza(CConstante.DataNula, ComboBoxOra.EnumPas.JumatateDeOra);
              
            }
            else
            {
               // BColectieListaPreturiStandard lLucrareSelectata = BListaPreturiStandard.getById(this.lComanda.IdLucrare, null);

                /*if (this.lComanda.IdTehnician > 0)
                     this.lgfTehnician.ObiectCorespunzator = BUtilizator.GetById(this.lComanda.IdTehnician, null);
                 else
                     this.lgfTehnician.Goleste();


                     this.cboComandaReprezentant.SelectedValue = lComanda.IdReprezentantClient;
                     this.cboCabinet.SelectedValue = lComanda.IdCabinet;
                     this.txtObservatiiEtapaCurenta.Text = lComanda.ObservatiiEtapa;
                     this.ctrlDataOraTermen.Initializeaza(this.lComanda.DataSfarsitEtapa, ComboBoxOra.EnumPas.JumatateDeOra);
                     this.chkRefacere.Checked = this.lComanda.Refacere;*/
              
            }

            initListe();

            finalizeazaIncarcarea();
        }
        #endregion      

        #region Evenimente
        private void BtnVeziToateEtapele_Click(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                /* if (TablouDeBord.Clienti.FormLucrareListaEtapeRealizate.Afiseaza(this.GetFormParinte(), this.lComanda))
                 {
                     this.lComanda.Refresh(null);
                     Initializeaza();
                 }*/
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

        private void CboEtapaCurenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                this.chkRefacere.Checked = false;
                this.cboStare.SelectedIndex = 0;
                this.ctrlDataOraTermen.DataAfisata = CConstante.DataNula;
                this.txtObservatiiEtapaCurenta.Goleste();
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

        private void TxtCautaTehnician_DeschideEcranCautare(Control psender, object pxObiectExistent)
        {
            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                BUtilizator tehnician = FormListaUtilizatori.Afiseaza(this.GetFormParinte(), EnumRol.Tehnician);
                if (tehnician != null)
                    this.lgfTehnician.ObiectCorespunzator = tehnician;
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

        #region Metode publice      

        public static bool Afiseaza(Form pEcranPariente, BClientiComenzi pComanda, BClienti pClient, BListaPreturiStandard pLucrare)
        {
            using (FormDetLucrari ecran = new FormDetLucrari(pComanda, pClient, pLucrare))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        #endregion

        #region Metode private
        private void initListe()
        {
            Dictionary<int, string> lstReprezentanti = new Dictionary<int, string>();
            Dictionary<int, string> lstCabinete = new Dictionary<int, string>();

            lstReprezentanti.Add(0, string.Empty);
            lstCabinete.Add(0, string.Empty);

            if (this.lClient != null)
            {
                foreach (var elem in BClientiReprezentanti.GetListByIdClient(this.lClient.Id, CDL.iStomaLab.CDefinitiiComune.EnumStare.Activa, null))
                {
                    lstReprezentanti.Add(elem.Id, BClientiReprezentanti.getReprezentant(elem.Id, null).GetIdentitateReprezentant());
                }

                foreach (var elem in BClientiCabinete.GetListByIdClient(this.lClient.Id, CDefinitiiComune.EnumStare.Activa, null))
                {
                    lstCabinete.Add(elem.Id, elem.Denumire);
                }
            }

            this.cboStare.BeginUpdate();
            this.cboStare.DataSource = BClientiComenziEtape.StructStareEtapa.GetList();
            this.cboStare.EndUpdate();

            BColectieEtape listaEtape = new BColectieEtape();
            if (this.lLucrareSelectata != null)
            {                                                                        //this.lLucrareSelectata.id
                BColectieLucrariEtape etape = BLucrariEtape.GetListByParamIdLucrare( 0, EnumStare.Activa, null);
                if (etape.Count > 0)
                {
                    listaEtape = BEtape.getByListaId(etape.GetListaIdEtape(), null);
                }
                else
                {
                    listaEtape = BEtape.GetListByParam(EnumStare.Activa, null);

                }
              }

            this.cboEtapaCurenta.BeginUpdate();
            this.cboEtapaCurenta.DataSource = listaEtape;
            this.cboEtapaCurenta.EndUpdate();

           /* if (this.lComanda != null)
            {               
                 if (this.lComanda.IdEtapaSetari > 0)
                      this.cboEtapaCurenta.SelectedItem = this.lComanda.IdEtapaSetari;
                  else
                      this.cboEtapaCurenta.SelectedItem = null;
                  this.cboStare.SelectedIndex = Convert.ToInt32(this.lComanda.StatusEtapa);
            }*/

            this.cboEtapaCurenta.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboStare.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void seteazaAlerta()
        {
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.lgfLucrare, this.lblLucrare);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.txtNrElemente, this.lblNrElemente);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.ctrlComandaDataPrimire, this.lblComandaDataPrimire);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.ctrlDataOraTermen, this.lblTermen);
            IHMEfecteSpeciale.SeteazaForeColorAlerta(this.lgfTehnician, this.lblTehnician);
            IHMEfecteSpeciale.AplicaEfectNU(this.GetFormParinte());

            seteazaFocus();
        }

        private void seteazaFocus()
        {
            Control[] lstControale = { this.lgfLucrare, this.txtNrElemente, this.lgfTehnician, this.ctrlDataOraTermen, this.ctrlComandaDataPrimire };

            foreach (var control in lstControale)
            {
                if (string.IsNullOrEmpty(control.Text))
                {
                    control.Focus();
                    break;
                }
            }
        }
        
        private int getIdEtapaCurenta()
        {
            if (this.cboEtapaCurenta.SelectedItem == null)
                return 0;

            return (this.cboEtapaCurenta.SelectedItem as BEtape).Id;
        }

        private BClientiComenziEtape.EnumStareEtapa getStare()
        {
            if (this.cboStare.SelectedItem != null)
                return ((BClientiComenziEtape.StructStareEtapa)this.cboStare.SelectedItem).Id;

            return BClientiComenziEtape.EnumStareEtapa.Nedefinita;
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
