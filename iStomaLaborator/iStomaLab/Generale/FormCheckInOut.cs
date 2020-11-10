using BLL.iStomaLab;
using BLL.iStomaLab.Utilizatori;
using CCL.iStomaLab;
using CCL.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.Generale
{
    public partial class FormCheckInOut : FormPersonalizat
    {

        #region Declaratii generale

        private BUtilizator lUtilizator = null;
        private BPontaj lPontaj = null;

        #endregion

        #region Enumerari si Structuri

        enum EnumColoaneDGV
        {
            colTip,
            colOra,
            colObservatii
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormCheckInOut()
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
            this.lblGasesteUtilizator.DeschideEcranCautare += LblGasesteUtilizator_DeschideEcranCautare;
            this.lblGasesteUtilizator.CerereUpdate += LblGasesteUtilizator_CerereUpdate;
            this.ctrlValidareAnulareCheck.Validare += CtrlValidareAnulareCheck_Validare;
        }

        private void initTextML()
        {
            this.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pontaj);
            this.lblUtilizator.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Utilizator);
            this.lblTip.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Tip);
            this.lblObservatii.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Observatii);
            this.lblAstazi.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Astazi);
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

            this.lblOraActuala.Text = getStringFromDate(DateTime.Now);
            this.panelDetaliiCheck.Visible = false;

            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void LblGasesteUtilizator_CerereUpdate(Control psender, string pNumeProprietate, object pNouaValoare)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();
                
                this.panelDetaliiCheck.Visible = false;
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

        private void LblGasesteUtilizator_DeschideEcranCautare(Control psender, object pxObiectExistent)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                //this.lUtilizator= 

                //if (FormListaUtilizatori.Afiseaza(this, this.Location.X, this.Location.Y))
                //{
                //    if (FormListaUtilizatori._SUtilizator != null)
                //    {
                //        this.lblGasesteUtilizator.Text = FormListaUtilizatori._SUtilizator.GetNumeCompletUtilizator();
                //        this.panelDetaliiCheck.Visible = true;

                //        BColectiePontaj listaElem = BPontaj.GetListByIdUtilizator(FormListaUtilizatori._SUtilizator.Id, null);

                //        if (listaElem.Count > 0)
                //        {
                //            getDataSourcePentruComboTip(listaElem);

                //            this.lblDurata.Visible = true;
                //            this.lblUltimulCheck.Visible = true;

                //            this.lblUltimulCheck.Text = BDefinitiiGenerale.StructCheckInOut.GetDenumireTip(listaElem[0].TipPontaj) + ": " + getStringFromDate(listaElem[0].DataPontaj);

                //            if (listaElem[listaElem.Count - 1].TipPontaj == 2)
                //            {
                //                this.lblDurata.Text = CUtil.GetTextDurataOreMinute(getNrMinuteZiTerminata(listaElem[0].DataPontaj, listaElem[listaElem.Count - 1].DataPontaj));
                //            }
                //            else
                //            {
                //                this.lblDurata.Text = CUtil.GetTextDurataOreMinute(getNrMinute(listaElem[0].DataPontaj));
                //            }

                //            ConstruiesteColoaneDGV();
                //            ConstruiesteRanduriDGV();

                //            this.dgvListaCheckAstazi.ColumnHeadersVisible = false;
                //        }
                //        else
                //        {
                //            this.cboTip.DataSource = BDefinitiiGenerale.StructCheckInOut.GetListCheckIn();
                            
                //            this.lblDurata.Visible = false;
                //            this.lblUltimulCheck.Visible = false;
                //        }
                //        this.cboTip.DropDownStyle = ComboBoxStyle.DropDownList;
                //    }

                //}
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

        private void CtrlValidareAnulareCheck_Validare(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                if (this.panelDetaliiCheck.Visible == false)
                {
                    CCL.UI.Mesaj.Afiseaza(this, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.InformareSelectareUtilizator));
                }
                else
                {
                    //    var listaElem = BPontaj.GetListByIdUtilizator(FormListaUtilizatori._SUtilizator.Id, null);

                    //    int tipPontaj = listaElem.Count > 0 ? listaElem[listaElem.Count - 1].TipPontaj : 0;

                    //    if (salveaza(tipPontaj))
                    //    {
                    //        inchideEcranulOK();
                    //    }
                    //}
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

        private long getNrMinute(DateTime pDataDeInceput)
        {
            long nrMinuteInceput = pDataDeInceput.Hour * 60 + pDataDeInceput.Minute;
            long nrMinuteActuale = DateTime.Now.Hour * 60 + DateTime.Now.Minute;
            return nrMinuteActuale - nrMinuteInceput;
        }

        private long getNrMinuteZiTerminata(DateTime pOraInceput, DateTime pOraSfarsit)
        {
            long nrMinuteInceput = pOraInceput.Hour * 60 + pOraInceput.Minute;
            long nrMinuteActuale = pOraSfarsit.Hour * 60 + pOraSfarsit.Minute;
            return nrMinuteActuale - nrMinuteInceput;
        }

        private void getDataSourcePentruComboTip(BColectiePontaj pListaElem)
        {
            if (pListaElem[pListaElem.Count - 1].TipPontaj == 1)
            {
                this.cboTip.DataSource = BDefinitiiGenerale.StructCheckInOut.GetListCheckOut();
            }
            else if (pListaElem[pListaElem.Count - 1].TipPontaj == 2)
            {
                this.cboTip.DataSource = BDefinitiiGenerale.StructCheckInOut.GetListCheckIn();
            }
            else if (pListaElem[pListaElem.Count - 1].TipPontaj == 3)
            {
                this.cboTip.DataSource = BDefinitiiGenerale.StructCheckInOut.GetListPauza();
            }
            else if (pListaElem[pListaElem.Count - 1].TipPontaj == 4)
            {
                this.cboTip.DataSource = BDefinitiiGenerale.StructCheckInOut.GetListDeplasare();
            }
            else if (pListaElem[pListaElem.Count - 1].TipPontaj == 5 || pListaElem[pListaElem.Count - 1].TipPontaj == 6)
            {
                this.cboTip.DataSource = BDefinitiiGenerale.StructCheckInOut.GetListCheckOut();
            }
        }

        private string getStringFromDate(DateTime pData)
        {
            return string.Format("{0:HH:mm}", pData);
        }

        private bool salveaza(int pTipPontaj)
        {
            //if (BPontaj.SuntInformatiileNecesareCoerente(1, FormListaUtilizatori._SUtilizator.Id))
            //{
            //    //daca nu avem check in
            //    if (pTipPontaj == 0)
            //    {
            //        BPontaj.Add(1, FormListaUtilizatori._SUtilizator.Id, DateTime.Now, 1, this.txtObservatii.Text, null);
            //    }
            //    //daca avem Check in
            //    if (pTipPontaj == 1)
            //    {
            //        BPontaj.Add(1, FormListaUtilizatori._SUtilizator.Id, DateTime.Now, this.cboTip.SelectedIndex + 2, this.txtObservatii.Text, null);
            //    }
            //    //daca avem check out
            //    else if (pTipPontaj == 2)
            //    {
            //        BPontaj.Add(1, FormListaUtilizatori._SUtilizator.Id, DateTime.Now, 1, this.txtObservatii.Text, null);
            //    }
            //    //daca avem Pauza
            //    else if (pTipPontaj == 3)
            //    {
            //        BPontaj.Add(1, FormListaUtilizatori._SUtilizator.Id, DateTime.Now, 5, this.txtObservatii.Text, null);
            //    }
            //    //daca avem deplasare
            //    else if (pTipPontaj == 4)
            //    {
            //        BPontaj.Add(1, FormListaUtilizatori._SUtilizator.Id, DateTime.Now, 6, this.txtObservatii.Text, null);
            //    }
            //    //daca avem finalPauza sau revenireInClincia
            //    else if (pTipPontaj == 5 || pTipPontaj == 6)
            //    {
            //        BPontaj.Add(1, FormListaUtilizatori._SUtilizator.Id, DateTime.Now, this.cboTip.SelectedIndex + 2, this.txtObservatii.Text, null);
            //    }

            //}
            //else
            //{
            //    IHMEfecteSpeciale.AplicaEfectNU(this);

            //}
            //return BPontaj.SuntInformatiileNecesareCoerente(1, FormListaUtilizatori._SUtilizator.Id);
            return true;
        }

        private void ConstruiesteColoaneDGV()
        {
            this.dgvListaCheckAstazi.IncepeConstructieColoane();

            this.dgvListaCheckAstazi.AdaugaColoanaText(EnumColoaneDGV.colTip.ToString(), null, 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaCheckAstazi.AdaugaColoanaText(EnumColoaneDGV.colOra.ToString(), null, 100, false, DataGridViewColumnSortMode.Automatic);

            this.dgvListaCheckAstazi.AdaugaColoanaText(EnumColoaneDGV.colObservatii.ToString(), null, 100, true, DataGridViewColumnSortMode.Automatic);

            this.dgvListaCheckAstazi.FinalizeazaConstructieColoane();
        }

        private void ConstruiesteRanduriDGV()
        {
            this.dgvListaCheckAstazi.IncepeContructieRanduri();

            //var listaElem = BPontaj.GetListByIdUtilizator(FormListaUtilizatori._SUtilizator.Id, null);

            //foreach (var elem in listaElem)
            //{
            //    incarcaRand(this.dgvListaCheckAstazi.Rows[this.dgvListaCheckAstazi.Rows.Add()], elem);
            //}

            this.dgvListaCheckAstazi.FinalizeazaContructieRanduri();
        }

        private void incarcaRand(DataGridViewRow pRand, BPontaj pElem)
        {
            pRand.Tag = pElem;

            pRand.Cells[EnumColoaneDGV.colTip.ToString()].Value = BDefinitiiGenerale.StructCheckInOut.GetDenumireTip(pElem.TipPontaj);
            pRand.Cells[EnumColoaneDGV.colOra.ToString()].Value = getStringFromDate(pElem.DataPontaj);
            pRand.Cells[EnumColoaneDGV.colObservatii.ToString()].Value = pElem.Observatii;
        }

        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente)
        {
            using (FormCheckInOut ecran = new FormCheckInOut())
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
