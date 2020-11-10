using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ILL.BLL.General;
using CCL.DAL;
using DAL.iStomaLab.Utilizatori;
using CCL.iStomaLab;
using DAL.iStomaLab.Utilizatori.DAL.iStomaLab.Utilizatori;
using CDL.iStomaLab;
using ILL.iStomaLab;
using CCL.iStomaLab.Utile;
using static BLL.iStomaLab.BDefinitiiGenerale;
using System.IO;
using BLL.iStomaLab.Comune;
using System.Drawing;
using static CDL.iStomaLab.CDefinitiiComune;

namespace BLL.iStomaLab.Utilizatori
{
    /// <summary>
    /// Clasa pentru gestionarea utilizatorilor
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BUtilizator : BGestiuneCMI, IDisposable, ICheie, ILL.General.Interfete.IProprietarDocumente, IAfisaj, ICreare, IInchidere
    {

        #region Declaratii generale

        private static BUtilizator _UtilizatorConectat = null;
        private static BColectieUtilizator _ListaUtilizatoriBDD = null;

        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int NumeMaxLength = 50;
            public const int PrenumeMaxLength = 50;
            public const int CNPMaxLength = 20;
            public const int NumeDeFataMaxLength = 50;
            public const int PoreclaMaxLength = 50;
            public const int ScoalaMaxLength = 100;
            public const int ObservatiiMaxLength = 500;
            public const int TelefonFixMaxLength = 20;
            public const int TelefonMobilMaxLength = 20;
            public const int FaxMaxLength = 20;
            public const int ContSkypeMaxLength = 50;
            public const int ContYMMaxLength = 50;
            public const int AdresaMailMaxLength = 50;
            public const int PaginaWebMaxLength = 50;
            public const int InfoContactMaxLength = 500;
            public const int ContStomaMaxLength = 50;
            public const int ParolaStomaMaxLength = 50;
            public const int SerieActIdentitateMaxLength = 5;
            public const int NumarActIdentitateMaxLength = 20;
            public const int MotivInchidereMaxLength = 500;
            public const int EmisDeMaxLength = 40;
            public const int IbanMaxLength = 40;
        }

        #endregion // StructCampuriTabela

        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DUtilizator.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("Nume", true, 1)]
        public string Nume
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tNume.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tNume.ToString(), value); }
        }

        [BExport("Prenume", true, 1)]
        public string Prenume
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tPrenume.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tPrenume.ToString(), value); }
        }

        [BExport("CNP", true, 1)]
        public string CNP
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tCNP.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tCNP.ToString(), value); }
        }

        [BExport("DataNastere", true, 1)]
        public DateTime DataNastere
        {
            get { return this.MyDataRowGetItemAsDateNull(DUtilizator.EnumCampuriTabela.dDataNastere.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.dDataNastere.ToString(), value); }
        }

        [BExport("Sex", true, 1)]
        public CDefinitiiComune.EnumSex Sex
        {
            get { return (CDefinitiiComune.EnumSex)this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.nSex.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.nSex.ToString(), value); }
        }
               

        [BExport("Titulatura", true, 1)]
        public CDefinitiiComune.EnumTitulatura Titulatura
        {
            get { return (CDefinitiiComune.EnumTitulatura)this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.nTitulatura.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.nTitulatura.ToString(), value); }
        }

        [BExport("NumeDeFata", true, 1)]
        public string NumeDeFata
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tNumeDeFata.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tNumeDeFata.ToString(), value); }
        }

        [BExport("Porecla", true, 1)]
        public string Porecla
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tPorecla.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tPorecla.ToString(), value); }
        }

        [BExport("StareCivila", true, 1)]
        public CDefinitiiComune.EnumStareCivila StareCivila
        {
            get { return (CDefinitiiComune.EnumStareCivila)this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.nStareCivila.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.nStareCivila.ToString(), value); }
        }

        [BExport("NumarCopii", true, 1)]
        public int NumarCopii
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.nNumarCopii.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.nNumarCopii.ToString(), value); }
        }

        [BExport("Educatie", true, 1)]
        public CDefinitiiComune.EnumNivelScolorizare Educatie
        {
            get { return (CDefinitiiComune.EnumNivelScolorizare)this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.nEducatie.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.nEducatie.ToString(), value); }
        }

        public bool EsteADMIN()
        {
            return this.UtilizatorCreare <= 0;
        }

        [BExport("Scoala", true, 1)]
        public string Scoala
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tScoala.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tScoala.ToString(), value); }
        }

        [BExport("IdNationalitate", true, 1)]
        public int IdNationalitate
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.xnIdNationalitate.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.xnIdNationalitate.ToString(), value); }
        }

        [BExport("IdTaraNastere", true, 1)]
        public int IdTaraNastere
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.xnIdTaraNastere.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.xnIdTaraNastere.ToString(), value); }
        }

        [BExport("IdJudetNastere", true, 1)]
        public int IdJudetNastere
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.xnIdJudetNastere.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.xnIdJudetNastere.ToString(), value); }
        }

        [BExport("IdLocalitateNastere", true, 1)]
        public int IdLocalitateNastere
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.xnIdLocalitateNastere.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.xnIdLocalitateNastere.ToString(), value); }
        }

        [BExport("Rol", true, 1)]
        public CDefinitiiComune.EnumRol Rol
        {
            get { return (CDefinitiiComune.EnumRol)this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.nRol.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.nRol.ToString(), Convert.ToInt32(value)); }
        }

        [BExport("IdProfesie", true, 1)]
        public int IdProfesie
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.xnIdProfesie.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.xnIdProfesie.ToString(), value); }
        }

        [BExport("Observatii", true, 1)]
        public string Observatii
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tObservatii.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tObservatii.ToString(), value); }
        }

        [BExport("TelefonFix", true, 1)]
        public string TelefonFix
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tTelefonFix.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tTelefonFix.ToString(), value); }
        }

        [BExport("TelefonMobil", true, 1)]
        public string TelefonMobil
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tTelefonMobil.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tTelefonMobil.ToString(), value); }
        }

        [BExport("Fax", true, 1)]
        public string Fax
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tFax.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tFax.ToString(), value); }
        }

        [BExport("ContSkype", true, 1)]
        public string ContSkype
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tContSkype.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tContSkype.ToString(), value); }
        }

        [BExport("ContYM", true, 1)]
        public string ContYM
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tContYM.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tContYM.ToString(), value); }
        }

        [BExport("AdresaMail", true, 1)]
        public string AdresaMail
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tAdresaMail.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tAdresaMail.ToString(), value); }
        }

        [BExport("PaginaWeb", true, 1)]
        public string PaginaWeb
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tPaginaWeb.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tPaginaWeb.ToString(), value); }
        }

        [BExport("InfoContact", true, 1)]
        public string InfoContact
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tInfoContact.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tInfoContact.ToString(), value); }
        }

        [BExport("IdImagineCurenta", true, 1)]
        public int IdImagineCurenta
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.xnIdImagineCurenta.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.xnIdImagineCurenta.ToString(), value); }
        }

        [BExport("ContStoma", true, 1)]
        public string ContStoma
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tContStoma.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tContStoma.ToString(), value); }
        }

        [BExport("ParolaStoma", true, 1)]
        public string ParolaStoma
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tParolaStoma.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tParolaStoma.ToString(), value); }
        }

        [BExport("UltimaOptiuneAccesata", true, 1)]
        public int UltimaOptiuneAccesata
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.nUltimaOptiuneAccesata.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.nUltimaOptiuneAccesata.ToString(), value); }
        }

        [BExport("Culoare", true, 1)]
        public int Culoare
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.nCuloare.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.nCuloare.ToString(), value); }
        }

        [BExport("TipActIdentitate", true, 1)]
        public int TipActIdentitate
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.nTipActIdentitate.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.nTipActIdentitate.ToString(), value); }
        }

        [BExport("SerieActIdentitate", true, 1)]
        public string SerieActIdentitate
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tSerieActIdentitate.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tSerieActIdentitate.ToString(), value); }
        }

        [BExport("NumarActIdentitate", true, 1)]
        public string NumarActIdentitate
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tNumarActIdentitate.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tNumarActIdentitate.ToString(), value); }
        }

        [BExport("NumarOrdine", true, 1)]
        public int NumarOrdine
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.nNumarOrdine.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.nNumarOrdine.ToString(), value); }
        }

        [BExport("DurataMinuteDeconectare", true, 1)]
        public int DurataMinuteDeconectare
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.nDurataMinuteDeconectare.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.nDurataMinuteDeconectare.ToString(), value); }
        }

        [BExport("NumarZileCOAgreate", true, 1)]
        public int NumarZileCOAgreate
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.nNumarZileCOAgreate.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.nNumarZileCOAgreate.ToString(), value); }
        }

        [BExport("DataAngajare", true, 1)]
        public DateTime DataAngajare
        {
            get { return this.MyDataRowGetItemAsDateNull(DUtilizator.EnumCampuriTabela.dDataAngajare.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.dDataAngajare.ToString(), value); }
        }

        [BExport("TipContract", true, 1)]
        public BDefinitiiGenerale.EnumTipContract TipContract
        {
            get { return (BDefinitiiGenerale.EnumTipContract)this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.nTipContract.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.nTipContract.ToString(), Convert.ToInt32(value)); }
        }

        [BExport("DataContract", true, 1)]
        public DateTime DataContract
        {
            get { return this.MyDataRowGetItemAsDateNull(DUtilizator.EnumCampuriTabela.dDataContract.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.dDataContract.ToString(), value); }
        }

        [BExport("DataIncetareContract", true, 1)]
        public DateTime DataIncetareContract
        {
            get { return this.MyDataRowGetItemAsDateNull(DUtilizator.EnumCampuriTabela.dDataIncetareContract.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.dDataIncetareContract.ToString(), value); }
        }

        [BExport("OreNorma", true, 1)]
        public int OreNorma
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.nOreNorma.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.nOreNorma.ToString(), value); }
        }

        [BExport("NumarContract", true, 1)]
        public int NumarContract
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.nNumarContract.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.nNumarContract.ToString(), value); }
        }

        [BExport("EmisDe", true, 1)]
        public string EmisDe
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tEmisDe.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tEmisDe.ToString(), value); }
        }

        [BExport("ValabilitateInceput", true, 1)]
        public DateTime ValabilitateInceput
        {
            get { return this.MyDataRowGetItemAsDateNull(DUtilizator.EnumCampuriTabela.dValabilitateInceput.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.dValabilitateInceput.ToString(), value); }
        }

        [BExport("ValabilitateSfarsit", true, 1)]
        public DateTime ValabilitateSfarsit
        {
            get { return this.MyDataRowGetItemAsDateNull(DUtilizator.EnumCampuriTabela.dValabilitateSfarsit.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.dValabilitateSfarsit.ToString(), value); }
        }

        [BExport("Iban", true, 1)]
        public string Iban
        {
            get { return this.MyDataRowGetItem(DUtilizator.EnumCampuriTabela.tIban.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.tIban.ToString(), value); }
        }

        [BExport("IdBanca", true, 1)]
        public int IdBanca
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.xnIdBanca.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.xnIdBanca.ToString(), value); }
        }

        [BExport("IdAdresa", true, 1)]
        public int IdAdresa
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DUtilizator.EnumCampuriTabela.xnIdAdresa.ToString()); }
            set { this.MyDataRowSetItem(DUtilizator.EnumCampuriTabela.xnIdAdresa.ToString(), value); }
        }

        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.MotiveInchidereUtilizator; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.Utilizator; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BUtilizator(int pId)
        : this(pId, null)
        {
        }

        public BUtilizator(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BUtilizator>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BUtilizator(DataRow pMyRow)
        {
            FillObjectWithDataRow<BUtilizator>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        public static int Add(string pCodClient, string pParola, string pNume, string pPrenume, string pCNP)
        {
            //pAdaugaDisclaimerML = cand migram datele catre istoma (din dento de ex) nu avem acces la multilingv
            //se adauga din serviciu
            int lIdUtilizatorCreat = 0;

            CDefinitiiComune.EnumSex lEnumSex = CDefinitiiComune.EnumSex.Nedefinit;
            CDefinitiiComune.EnumTitulatura lTitulatura = CDefinitiiComune.EnumTitulatura.Domn;
            DateTime dDataNasterii = CConstante.DataNula;
            int lIdLocalitateNastere = 0;
            bool bNascutInRomania = true;
            int lCodJudetNastere = 0;
            bool EroareFormatCNP = true;
            string MesajEroare = string.Empty;
            if (!string.IsNullOrEmpty(pCNP.Trim()))
            {
                //Daca CNP-ul a fost transmis atunci il verificam
                EroareFormatCNP = CUtil.ObtineInformatiiCNP(pCNP, ref MesajEroare, ref lEnumSex, ref dDataNasterii,
                                    ref lCodJudetNastere, ref lIdLocalitateNastere, ref lTitulatura, ref bNascutInRomania);
            }

            lIdUtilizatorCreat = DUtilizator.AdaugaUtilizator(-1, pNume, pPrenume, string.Empty, null);
            distrugeListaDinBDD();

            BUtilizator UserCreat = getDinBDD(lIdUtilizatorCreat, null);
            UserCreat.CNP = pCNP;
            UserCreat.ContStoma = pCodClient;
            UserCreat.ParolaStoma = CSecuritate.GetMd5Hash(pParola);

            if (bNascutInRomania)
            {
                UserCreat.Sex = lEnumSex;
                UserCreat.Titulatura = lTitulatura;
                UserCreat.DataNastere = dDataNasterii;
            }

            UserCreat.UpdateAll(null);

            if (_UtilizatorConectat == null)
                _UtilizatorConectat = UserCreat;

            return lIdUtilizatorCreat;
        }

        private static void distrugeListaDinBDD()
        {
            _ListaUtilizatoriBDD = null; //pentru a forta reinitializarea listei

            BUtilizator userConectat = GetUtilizatorConectat();
        }

        public static BUtilizator getDinBDD(int lId, IDbTransaction pTranzactie)
        {
            try
            {
                return new BUtilizator(GetDataRowForObjet(lId, pTranzactie));
            }
            catch (Exception)
            {
            }

            return null;
        }

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DUtilizator
        /// </summary>
        /// <param name="pNume"></param>
        /// <param name="pPrenume"></param>
        /// <param name="pCNP"></param>
        /// <param name="pDataNastere"></param>
        /// <param name="pSex"></param>
        /// <param name="pTitulatura"></param>
        /// <param name="pNumeDeFata"></param>
        /// <param name="pPorecla"></param>
        /// <param name="pStareCivila"></param>
        /// <param name="pNumarCopii"></param>
        /// <param name="pEducatie"></param>
        /// <param name="pScoala"></param>
        /// <param name="pIdNationalitate"></param>
        /// <param name="pIdTaraNastere"></param>
        /// <param name="pIdJudetNastere"></param>
        /// <param name="pIdLocalitateNastere"></param>
        /// <param name="pRol"></param>
        /// <param name="pIdProfesie"></param>
        /// <param name="pObservatii"></param>
        /// <param name="pTelefonFix"></param>
        /// <param name="pTelefonMobil"></param>
        /// <param name="pFax"></param>
        /// <param name="pContSkype"></param>
        /// <param name="pContYM"></param>
        /// <param name="pAdresaMail"></param>
        /// <param name="pPaginaWeb"></param>
        /// <param name="pInfoContact"></param>
        /// <param name="pIdImagineCurenta"></param>
        /// <param name="pContStoma"></param>
        /// <param name="pParolaStoma"></param>
        /// <param name="pCuloare"></param>
        /// <param name="pTipActIdentitate"></param>
        /// <param name="pSerieActIdentitate"></param>
        /// <param name="pNumarActIdentitate"></param>
        /// <param name="pNumarOrdine"></param>
        /// <param name="pNumarZileCOAgreate"></param>
        /// <param name="pDataAngajare"></param>
        /// <param name="pTipContract"></param>
        /// <param name="pDataContract"></param>
        /// <param name="pDataIncetareContract"></param>
        /// <param name="pOreNorma"></param>
        /// <param name="pNumarContract"></param>
        /// <param name="pEmisDe"></param>
        /// <param name="pValabilitateInceput"></param>
        /// <param name="pValabilitateSfarsit"></param>
        /// <param name="pIban"></param>
        /// <param name="pIdBanca"></param>
        /// <param name="pIdAdresa"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(string pNume, string pPrenume, string pCNP, DateTime pDataNastere, CDefinitiiComune.EnumSex pSex, CDefinitiiComune.EnumTitulatura pTitulatura, string pNumeDeFata, string pPorecla, CDefinitiiComune.EnumStareCivila pStareCivila, int pNumarCopii, int pEducatie, string pScoala, int pIdNationalitate, int pIdTaraNastere, int pIdJudetNastere, int pIdLocalitateNastere, CDefinitiiComune.EnumRol pRol, int pIdProfesie, string pObservatii, string pTelefonFix, string pTelefonMobil, string pFax, string pContSkype, string pContYM, string pAdresaMail, string pPaginaWeb, string pInfoContact, int pIdImagineCurenta, string pContStoma, string pParolaStoma, int pCuloare, int pTipActIdentitate, string pSerieActIdentitate, string pNumarActIdentitate, int pNumarOrdine, int pNumarZileCOAgreate, DateTime pDataAngajare, int pTipContract, DateTime pDataContract, DateTime pDataIncetareContract, int pOreNorma, int pNumarContract, string pEmisDe, DateTime pValabilitateInceput, DateTime pValabilitateSfarsit, string pIban, int pIdBanca, int pIdAdresa, IDbTransaction pTranzactie)
        {
            int id = DUtilizator.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pNume, pPrenume, pCNP, pDataNastere, Convert.ToInt32(pSex), Convert.ToInt32(pTitulatura), pNumeDeFata, pPorecla, Convert.ToInt32(pStareCivila), pNumarCopii, pEducatie, pScoala, pIdNationalitate, pIdTaraNastere, pIdJudetNastere, pIdLocalitateNastere, Convert.ToInt32(pRol), pIdProfesie, pObservatii, pTelefonFix, pTelefonMobil, pFax, pContSkype, pContYM, pAdresaMail, pPaginaWeb, pInfoContact, pIdImagineCurenta, pContStoma, CSecuritate.GetMd5Hash(pParolaStoma), pCuloare, pTipActIdentitate, pSerieActIdentitate, pNumarActIdentitate, pNumarOrdine, pNumarZileCOAgreate, pDataAngajare, pTipContract, pDataContract, pDataIncetareContract, pOreNorma, pNumarContract, pEmisDe, pValabilitateInceput, pValabilitateSfarsit, pIban, pIdBanca, pIdAdresa, pTranzactie);
            return id;
        }

        public static int Add(string pNume, string pPrenume, DateTime pDataNastere, string pTelefonMobil, IDbTransaction pTranzactie)
        {
            int id = DUtilizator.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pNume, pPrenume, string.Empty, pDataNastere, 0, 0, string.Empty, string.Empty, 0, 0, 0, string.Empty, 0, 0, 0, 0, 1, 0, string.Empty, string.Empty, pTelefonMobil, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty, string.Empty, 0, 0, string.Empty, string.Empty, 0, 0, CConstante.DataNula, 0, CConstante.DataNula, CConstante.DataNula, 0, 0, string.Empty, CConstante.DataNula, CConstante.DataNula, string.Empty, 0, 0, pTranzactie);
            return id;
        }

        public static int AddAdmin(IDbTransaction pTranzactie)
        {
            int id = DUtilizator.Add(1, "admin", "admin", string.Empty, CConstante.DataNula, 0, 0, string.Empty, string.Empty, 0, 0, 0, string.Empty, 0, 0, 0, 0, 1, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, "admin", CSecuritate.GetMd5Hash("admin"), 0, 0, string.Empty, string.Empty, 0, 0, CConstante.DataNula, 0, CConstante.DataNula, CConstante.DataNula, 0, 0, string.Empty, CConstante.DataNula, CConstante.DataNula, string.Empty, 0, 0, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(string pNume, EnumRol pRol)
        {
            return !string.IsNullOrEmpty(pNume) && pRol != EnumRol.Nedefinit;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BUtilizator
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieUtilizator GetListByParam(CDefinitiiComune.EnumStare pStare, CDefinitiiComune.EnumRol pRol, IDbTransaction pTranzactie)
        {
            BColectieUtilizator lstDUtilizator = new BColectieUtilizator();
            using (DataSet ds = DUtilizator.GetListByParam(pStare, Convert.ToInt32(pRol), pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDUtilizator.Add(new BUtilizator(dr));
                }
            }
            return lstDUtilizator;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea DataRow-ului corespunzator obiectului in baza de date
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Un DataRow ce contine informatiile corespunzatoare obiectului</returns>
        /// <remarks></remarks>
        private static DataRow GetDataRowForObjet(int pId, IDbTransaction pTranzactie)
        {
            if (pId <= 0)
                throw new IdentificareBazaImposibilaException("BUtilizator");
            using (DataSet ds = DUtilizator.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BUtilizator");
            }
        }

        public static BColectieUtilizator getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieUtilizator listaRetur = new BColectieUtilizator();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DUtilizator.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BUtilizator(dr));
                    }
                }
            }
            return listaRetur;
        }

        private static BUtilizator getByUserSiPass(string pUser, string pParola, IDbTransaction pTranzactie)
        {
            BUtilizator userRetur = null;
            if (!string.IsNullOrEmpty(pUser) && !string.IsNullOrEmpty(pParola))
            {
                using (DataSet ds = DUtilizator.GetByUserSiPass(pUser, pParola, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        userRetur = new BUtilizator(dr);
                        break;
                    }
                }
            }

            return userRetur;
        }

        public static BUtilizator Conectare(string pUser, string pParola, bool pPastreazaConexiunea, IDbTransaction pTranzactie)
        {
            _UtilizatorConectat = getByUserSiPass(pUser, CCL.iStomaLab.Utile.CSecuritate.GetMd5Hash(pParola), pTranzactie);

            if (!BStatiiDeLucruUtilizatori.SeteazaPreferinteStatie(_UtilizatorConectat, pPastreazaConexiunea, pTranzactie))
            {
                _UtilizatorConectat = null;
            }

            return _UtilizatorConectat;
        }

        public static void DeconecteazaUtilizatorConectat(IDbTransaction pTranzactie)
        {
            BStatiiDeLucruUtilizatori.DeconecteazaUtilizatorulConectat(pTranzactie);
            _UtilizatorConectat = null;
        }

        public static BUtilizator GetUtilizatorConectat()
        {
            return GetUtilizatorConectat(null);
        }

        public static BUtilizator GetUtilizatorConectat(IDbTransaction pTranzactie)
        {
            if (_UtilizatorConectat == null)
            {
                //BUtilizator user = BUtilizator.Conectare();                                               //aici nu ar trebui 1
                BStatiiDeLucruUtilizatori prefUserConectat = BStatiiDeLucruUtilizatori.GetPreferinteUtilizatorConectat(1, pTranzactie);  // //aici e problema pauza
                
                if (prefUserConectat != null)
                {
                    _UtilizatorConectat = new BUtilizator(prefUserConectat.IdUtilizator, pTranzactie);
                }
            }

            return _UtilizatorConectat;
        }

        public static int GetIdUtilizatorConectat(IDbTransaction pTranzactie)
        {
            BUtilizator user = GetUtilizatorConectat(pTranzactie);

            if (user != null)
                return user.Id;

            //admin
            return 1;
        }

        public static BUtilizator GetById(int pIdUtilizator, IDbTransaction pTranzactie)
        {
            return new BUtilizator(pIdUtilizator, pTranzactie);
        }

        public static BUtilizator GetUtilizatorISTOMA(IDbTransaction pTranzactie)
        {
            //Utilizatorul ISTOMA este adaugat in BDD la crearea acesteia si nu are creator
            BUtilizator userStoma = null;
            using (DataSet ds = DUtilizator.GetUtilizatorISTOMA(pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    userStoma = new BUtilizator(ds.Tables[0].Rows[0]);
            }

            if (userStoma != null && userStoma.UtilizatorCreare > 0)
                userStoma = null;

            return userStoma;
        }

        #endregion //Metode de clasa

        #region Metode de instanta

        public void UpdateDosarPozaPersonal(FileInfo imagine, IDbTransaction pTranzactie) 
        {
            if (imagine == null)
                return;

            BDocumenteInline docProfil = BDocumenteInline.GetImagineProfilUtilizator(this.Id, pTranzactie);

            using (var stream = new FileStream(imagine.FullName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    if (docProfil != null)
                    {

                        docProfil.UpdateImagine(reader.ReadBytes((int)stream.Length), null);
                    }
                    else
                        BDocumenteInline.Add(BUtilizator.TipObiectClasa, this.Id, BDocumenteInline.EnumTipDocumentInline.ImagineProfilMedic, reader.ReadBytes((int)stream.Length), string.Empty, pTranzactie);
                }
            }
        }

        public void StergeDosarPozaPersonal(IDbTransaction pTranzactie) 
        {
            BDocumenteInline docProfil = BDocumenteInline.GetImagineProfilUtilizator(this.Id, pTranzactie);

            if (docProfil != null)
                docProfil.Delete(pTranzactie);
        }

        public Image GetDosarPozaPersonal(IDbTransaction pTranzactie) 
        {
            BDocumenteInline logoSediu = BDocumenteInline.GetImagineProfilUtilizator(this.Id, pTranzactie);

            if (logoSediu == null || logoSediu.Imagine == null)
            {
                return null;
            }
            else
            {
                using (var ms = new MemoryStream(logoSediu.Imagine))
                {
                    return Image.FromStream(ms);
                }
            }
        }

        public void SchimbaParola(string pNouaParola)
        {
            this.ParolaStoma = pNouaParola;
            this.UpdateAll(null);
        }

        public string ToStringPoliticos()
        {
            return GetNumeCompletUtilizator();
        }

        public string GetRolEticheta()
        {
            return StructRol.getDenumireByEnum(this.Rol);
        }

        public string GetNumeCompletUtilizator()
        {
            return string.Format("{0} {1}", this.Nume, this.Prenume); 
        }

        internal static string GetIdentitateById(int utilizatorInchidere)
        {
            return BUtilizator.GetById(utilizatorInchidere, null).GetNumeCompletUtilizator();
            //return string.Empty;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea informatiilor din baza de date pentru a fi conforme cu informatiile actuale ale obiectului
        /// </summary>
        /// <remarks>Exceptie daca nu avem initializate proprietatile ce permit identificarea obiectului in baza</remarks>
        public bool UpdateAll()
        {
            return this.UpdateAll(null);
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea informatiilor din baza de date pentru a fi conforme cu informatiile actuale ale obiectului
        /// </summary>
        /// <param name="pTranzactie">Tranzactia</param>
        /// <returns>True daca inregistrarea a fost modificata; False in caz contrar</returns>
        /// <remarks>Exceptie daca nu avem initializate proprietatile ce permit identificarea obiectului in baza</remarks>
        public override bool UpdateAll(IDbTransaction pTranzactie)
        {

            if (!this.ExistaProprietatiModificate()) return true;

            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Facem actualizarea in baza
                bool succesModificare = DUtilizator.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

                if (pTranzactie == null)
                {
                    //Facem Comit tranzactiei doar daca aceasta nu a fost transmisa in parametru. Altfel comitul va fi gestionat de functia apelanta
                    CCerereSQL.CloseTransactionOnConnection(Tranzactie, true);
                }
                return succesModificare;
            }
            catch (Exception)
            {
                if ((pTranzactie == null) && (Tranzactie != null)) CCerereSQL.CloseTransactionOnConnection(Tranzactie, false);
                throw;
            }
            finally
            {
                //Reinitializam obiectul pentru a recupera, printre altele, data de actualizare generata de baza de date
                this.Refresh(pTranzactie);
            }
        }

        public bool ExistaProprietatiModificate()
        {
            return

                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tNume.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tPrenume.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tCNP.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.dDataNastere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nSex.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nTitulatura.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tNumeDeFata.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tPorecla.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nStareCivila.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nNumarCopii.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nEducatie.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tScoala.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.xnIdNationalitate.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.xnIdTaraNastere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.xnIdJudetNastere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.xnIdLocalitateNastere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nRol.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.xnIdProfesie.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tObservatii.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tTelefonFix.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tTelefonMobil.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tFax.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tContSkype.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tContYM.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tAdresaMail.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tPaginaWeb.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tInfoContact.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.xnIdImagineCurenta.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tContStoma.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tParolaStoma.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nUltimaOptiuneAccesata.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nCuloare.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nTipActIdentitate.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tSerieActIdentitate.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tNumarActIdentitate.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nNumarOrdine.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nDurataMinuteDeconectare.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nNumarZileCOAgreate.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.dDataAngajare.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tMotivInchidere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nTipContract.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.dDataContract.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.dDataIncetareContract.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nOreNorma.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nNumarContract.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tEmisDe.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.dValabilitateInceput.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.dValabilitateSfarsit.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tIban.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.xnIdBanca.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.xnIdAdresa.ToString());
        }

      
        /// <summary>
        /// Metoda de instanta ce permite inchiderea(dezactivarea) obiectului
        /// </summary>
        /// <param name="pInchidere">inchidem sau activam?</param>
        /// <param name="pMotivInchidere">Motivul inchiderii</param>
        /// <param name="pTranzactie">Tranzactia</param>
        /// <remarks>Exceptie daca nu se poate identifica obiectul</remarks>
        public void Close(bool pInchidere, string pMotivInchidere, IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BUtilizator");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DUtilizator.CloseById(GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

                if (pTranzactie == null)
                {
                    //Facem Comit tranzactiei doar daca aceasta nu a fost transmisa in parametru. Altfel comitul va fi gestionat de functia apelanta
                    CCerereSQL.CloseTransactionOnConnection(Tranzactie, true);
                }
            }
            catch (Exception)
            {
                if ((pTranzactie == null) && (Tranzactie != null)) CCerereSQL.CloseTransactionOnConnection(Tranzactie, false);
                throw;
            }
            finally
            {
                //Reinitializam obiectul pentru a recupera, printre altele, data de inchidere generata de baza de date
                this.Refresh(pTranzactie);
            }
        }

        private BColectieCorespondenteColoaneValori getDictProprietatiModificate()
        {
            BColectieCorespondenteColoaneValori dictRezultat = new BColectieCorespondenteColoaneValori();
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tNume.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tNume.ToString(), this.Nume);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tPrenume.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tPrenume.ToString(), this.Prenume);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tCNP.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tCNP.ToString(), this.CNP);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.dDataNastere.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.dDataNastere.ToString(), this.DataNastere);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nSex.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.nSex.ToString(), Convert.ToInt32(this.Sex));
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nTitulatura.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.nTitulatura.ToString(), Convert.ToInt32(this.Titulatura));
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tNumeDeFata.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tNumeDeFata.ToString(), this.NumeDeFata);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tPorecla.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tPorecla.ToString(), this.Porecla);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nStareCivila.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.nStareCivila.ToString(), Convert.ToInt32(this.StareCivila));
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nNumarCopii.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.nNumarCopii.ToString(), this.NumarCopii);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nEducatie.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.nEducatie.ToString(), Convert.ToInt32(this.Educatie));
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tScoala.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tScoala.ToString(), this.Scoala);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.xnIdNationalitate.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.xnIdNationalitate.ToString(), this.IdNationalitate);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.xnIdTaraNastere.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.xnIdTaraNastere.ToString(), this.IdTaraNastere);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.xnIdJudetNastere.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.xnIdJudetNastere.ToString(), this.IdJudetNastere);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.xnIdLocalitateNastere.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.xnIdLocalitateNastere.ToString(), this.IdLocalitateNastere);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nRol.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.nRol.ToString(), Convert.ToInt32(this.Rol));
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.xnIdProfesie.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.xnIdProfesie.ToString(), this.IdProfesie);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tObservatii.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tObservatii.ToString(), this.Observatii);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tTelefonFix.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tTelefonFix.ToString(), this.TelefonFix);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tTelefonMobil.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tTelefonMobil.ToString(), this.TelefonMobil);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tFax.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tFax.ToString(), this.Fax);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tContSkype.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tContSkype.ToString(), this.ContSkype);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tContYM.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tContYM.ToString(), this.ContYM);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tAdresaMail.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tAdresaMail.ToString(), this.AdresaMail);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tPaginaWeb.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tPaginaWeb.ToString(), this.PaginaWeb);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tInfoContact.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tInfoContact.ToString(), this.InfoContact);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.xnIdImagineCurenta.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.xnIdImagineCurenta.ToString(), this.IdImagineCurenta);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tContStoma.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tContStoma.ToString(), this.ContStoma);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tParolaStoma.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tParolaStoma.ToString(), this.ParolaStoma);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nUltimaOptiuneAccesata.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.nUltimaOptiuneAccesata.ToString(), this.UltimaOptiuneAccesata);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nCuloare.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.nCuloare.ToString(), this.Culoare, false);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nTipActIdentitate.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.nTipActIdentitate.ToString(), this.TipActIdentitate);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tSerieActIdentitate.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tSerieActIdentitate.ToString(), this.SerieActIdentitate);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tNumarActIdentitate.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tNumarActIdentitate.ToString(), this.NumarActIdentitate);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nNumarOrdine.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.nNumarOrdine.ToString(), this.NumarOrdine);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nDurataMinuteDeconectare.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.nDurataMinuteDeconectare.ToString(), this.DurataMinuteDeconectare);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nNumarZileCOAgreate.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.nNumarZileCOAgreate.ToString(), this.NumarZileCOAgreate);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.dDataAngajare.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.dDataAngajare.ToString(), this.DataAngajare);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nTipContract.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.nTipContract.ToString(), Convert.ToInt32(this.TipContract));
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.dDataContract.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.dDataContract.ToString(), this.DataContract);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.dDataIncetareContract.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.dDataIncetareContract.ToString(), this.DataIncetareContract);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nOreNorma.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.nOreNorma.ToString(), this.OreNorma);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.nNumarContract.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.nNumarContract.ToString(), this.NumarContract);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tEmisDe.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tEmisDe.ToString(), this.EmisDe);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.dValabilitateInceput.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.dValabilitateInceput.ToString(), this.ValabilitateInceput);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.dValabilitateSfarsit.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.dValabilitateSfarsit.ToString(), this.ValabilitateSfarsit);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.tIban.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.tIban.ToString(), this.Iban);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.xnIdBanca.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.xnIdBanca.ToString(), this.IdBanca);
            if (this.IsMyDataRowItemHasChanged(DUtilizator.EnumCampuriTabela.xnIdAdresa.ToString()))
                dictRezultat.Adauga(DUtilizator.EnumCampuriTabela.xnIdAdresa.ToString(), this.IdAdresa);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BUtilizator");

            FillObjectWithDataRow<BUtilizator>(GetDataRowForObjet(this.Id, pTranzactie), this);
        }

        /// <summary>
        /// Metoda pentru serializarea obiectului in flux XML
        /// </summary>
        /// <returns>Un sir de caractere ce reprezinta obiectul sub forma de flux XML</returns>
        /// <remarks></remarks>
        public new string ObjectToXMLString()
        {
            System.Xml.XmlDocument myXmlDoc = new System.Xml.XmlDocument();
            System.Xml.XmlElement myXmlElem;
            string sRet = string.Empty;

            //Cream documentul:
            myXmlDoc.LoadXml("<DUtilizator></DUtilizator>");

            //Adaugam elementele clasei BUtilizator
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUME");
            myXmlElem.InnerText = this.Nume;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PRENUME");
            myXmlElem.InnerText = this.Prenume;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CNP");
            myXmlElem.InnerText = this.CNP;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATANASTERE");
            myXmlElem.InnerText = Convert.ToString(this.DataNastere);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("SEX");
            myXmlElem.InnerText = Convert.ToString(this.Sex);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TITULATURA");
            myXmlElem.InnerText = Convert.ToString(this.Titulatura);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMEDEFATA");
            myXmlElem.InnerText = this.NumeDeFata;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PORECLA");
            myXmlElem.InnerText = this.Porecla;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("STARECIVILA");
            myXmlElem.InnerText = Convert.ToString(this.StareCivila);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMARCOPII");
            myXmlElem.InnerText = Convert.ToString(this.NumarCopii);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("EDUCATIE");
            myXmlElem.InnerText = Convert.ToString(this.Educatie);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("SCOALA");
            myXmlElem.InnerText = this.Scoala;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDNATIONALITATE");
            myXmlElem.InnerText = Convert.ToString(this.IdNationalitate);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDTARANASTERE");
            myXmlElem.InnerText = Convert.ToString(this.IdTaraNastere);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDJUDETNASTERE");
            myXmlElem.InnerText = Convert.ToString(this.IdJudetNastere);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDLOCALITATENASTERE");
            myXmlElem.InnerText = Convert.ToString(this.IdLocalitateNastere);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("ROL");
            myXmlElem.InnerText = Convert.ToString(this.Rol);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDPROFESIE");
            myXmlElem.InnerText = Convert.ToString(this.IdProfesie);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("OBSERVATII");
            myXmlElem.InnerText = this.Observatii;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TELEFONFIX");
            myXmlElem.InnerText = this.TelefonFix;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TELEFONMOBIL");
            myXmlElem.InnerText = this.TelefonMobil;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("FAX");
            myXmlElem.InnerText = this.Fax;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CONTSKYPE");
            myXmlElem.InnerText = this.ContSkype;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CONTYM");
            myXmlElem.InnerText = this.ContYM;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("ADRESAMAIL");
            myXmlElem.InnerText = this.AdresaMail;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PAGINAWEB");
            myXmlElem.InnerText = this.PaginaWeb;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("INFOCONTACT");
            myXmlElem.InnerText = this.InfoContact;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDIMAGINECURENTA");
            myXmlElem.InnerText = Convert.ToString(this.IdImagineCurenta);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CONTSTOMA");
            myXmlElem.InnerText = this.ContStoma;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PAROLASTOMA");
            myXmlElem.InnerText = this.ParolaStoma;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("ULTIMAOPTIUNEACCESATA");
            myXmlElem.InnerText = Convert.ToString(this.UltimaOptiuneAccesata);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CULOARE");
            myXmlElem.InnerText = Convert.ToString(this.Culoare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TIPACTIDENTITATE");
            myXmlElem.InnerText = Convert.ToString(this.TipActIdentitate);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("SERIEACTIDENTITATE");
            myXmlElem.InnerText = this.SerieActIdentitate;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMARACTIDENTITATE");
            myXmlElem.InnerText = this.NumarActIdentitate;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMARORDINE");
            myXmlElem.InnerText = Convert.ToString(this.NumarOrdine);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DURATAMINUTEDECONECTARE");
            myXmlElem.InnerText = Convert.ToString(this.DurataMinuteDeconectare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMARZILECOAGREATE");
            myXmlElem.InnerText = Convert.ToString(this.NumarZileCOAgreate);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATAANGAJARE");
            myXmlElem.InnerText = Convert.ToString(this.DataAngajare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATACREARE");
            myXmlElem.InnerText = Convert.ToString(this.DataCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("UTILIZATORCREARE");
            myXmlElem.InnerText = Convert.ToString(this.UtilizatorCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATAINCHIDERE");
            myXmlElem.InnerText = Convert.ToString(this.DataInchidere);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("UTILIZATORINCHIDERE");
            myXmlElem.InnerText = Convert.ToString(this.UtilizatorInchidere);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("MOTIVINCHIDERE");
            myXmlElem.InnerText = this.MotivInchidere;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TIPCONTRACT");
            myXmlElem.InnerText = Convert.ToString(this.TipContract);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATACONTRACT");
            myXmlElem.InnerText = Convert.ToString(this.DataContract);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATAINCETARECONTRACT");
            myXmlElem.InnerText = Convert.ToString(this.DataIncetareContract);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("ORENORMA");
            myXmlElem.InnerText = Convert.ToString(this.OreNorma);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMARCONTRACT");
            myXmlElem.InnerText = Convert.ToString(this.NumarContract);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("EMISDE");
            myXmlElem.InnerText = this.EmisDe;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("VALABILITATEINCEPUT");
            myXmlElem.InnerText = Convert.ToString(this.ValabilitateInceput);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("VALABILITATESFARSIT");
            myXmlElem.InnerText = Convert.ToString(this.ValabilitateSfarsit);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IBAN");
            myXmlElem.InnerText = this.Iban;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDBANCA");
            myXmlElem.InnerText = Convert.ToString(this.IdBanca);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDADRESA");
            myXmlElem.InnerText = Convert.ToString(this.IdAdresa);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            //Recuperam textul XML
            sRet = myXmlDoc.InnerXml;

            //Distrugem obiectele folosite:
            myXmlElem = null;
            myXmlDoc = null;

            return sRet;
        }

        public override string ToString()
        {
            return GetNumeCompletUtilizator();
        }

        #endregion //Metode de instanta

        #region Metode de comparatie

        public static int ComparaDupaNume(BUtilizator xElemLista1, BUtilizator xElemLista2)
        {
            if (xElemLista1 == null)
            {
                if (xElemLista2 == null)
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (xElemLista2 == null)
                    return 1;
                else
                    return xElemLista1.Nume.CompareTo(xElemLista2.Nume);
            }
        }

        #endregion //Metode de comparatie

    }

}