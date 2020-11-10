using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ILL.BLL.General;
using CCL.DAL;
using ILL.iStomaLab;
using ILL.General.Interfete;
using CCL.iStomaLab;
using CDL.iStomaLab;
using BLL.iStomaLab.Utilizatori;
using BLL.iStomaLab.Locatii;
using DAL.iStomaLab.Locatii;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Comune;
using System.Drawing;
using System.IO;

namespace BLL.iStomaLab.Locatii
{
    [Serializable()]
    public sealed class BLocatii : BGestiuneCMI, IDisposable, ICheie, IProprietarDocumente, IAfisaj, IInchidere, ICreare
    {

        #region Declaratii generale


        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        #region StructCampuriTabela

        public struct StructCampuriTabela
        {
            public const int DenumireMaxLength = 100;
            public const int MotivInchidereMaxLength = 500;
            public const int TelefonMobilMaxLength = 50;
            public const int FaxMaxLength = 50;
            public const int ContSkypeMaxLength = 50;
            public const int ContYMMaxLength = 50;
            public const int AdresaMailMaxLength = 50;
            public const int PaginaWebMaxLength = 50;
            public const int InfoContactMaxLength = 500;
            public const int LogoMaxLength = 500;
            public const int DenumireFiscalaMaxLength = 100;
            public const int CodFiscalMaxLength = 20;
            public const int NumarInregistrareMaxLength = 30;
            public const int ContIBANMaxLength = 50;
            public const int DenumireBancaMaxLength = 50;
            public const int ReprezentantLegalMaxLength = 50;
            public const int CalitateReprezentantLegalMaxLength = 50;
            public const int SerieChitanteMaxLength = 10;
            public const int SerieFacturiMaxLength = 10;
            public const int InitialaLocatieMaxLength = 3;
        }

        #endregion // StructCampuriTabela

        public enum EnumTipLocatie
        {
            Nedefinit = 0,
            Sediu = 3
        }

        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("Id", true, 1)]
        [BIdentitate(true)]
        public int Id
        {
            get { return this.MyDataRowGetItemAsInteger(DLocatii.EnumCampuriTabela.nId.ToString()); }
        }

        [BExport("Denumire", true, 1)]
        public string Denumire
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tDenumire.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tDenumire.ToString(), value); }
        }

        [BExport("TipLocatie", true, 1)]
        public EnumTipLocatie TipLocatie
        {
            get { return (EnumTipLocatie)this.MyDataRowGetItemAsIntegerNull(DLocatii.EnumCampuriTabela.nTipLocatie.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.nTipLocatie.ToString(), Convert.ToInt32(value)); }
        }

        [BExport("IdLocatieRadacina", true, 1)]
        public int IdLocatieRadacina
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DLocatii.EnumCampuriTabela.xnIdLocatieRadacina.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.xnIdLocatieRadacina.ToString(), value); }
        }

        [BExport("IdGrup", true, 1)]
        public int IdGrup
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DLocatii.EnumCampuriTabela.xnIdGrup.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.xnIdGrup.ToString(), value); }
        }

        [BExport("IdSediu", true, 1)]
        public int IdSediu
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DLocatii.EnumCampuriTabela.xnIdSediu.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.xnIdSediu.ToString(), value); }
        }

        [BExport("IdSectie", true, 1)]
        public int IdSectie
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DLocatii.EnumCampuriTabela.xnIdSectie.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.xnIdSectie.ToString(), value); }
        }

        [BExport("IdUnitateFunctionala", true, 1)]
        public int IdUnitateFunctionala
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DLocatii.EnumCampuriTabela.xnIdUnitateFunctionala.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.xnIdUnitateFunctionala.ToString(), value); }
        }

        [BExport("TelefonMobil", true, 1)]
        public string TelefonMobil
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tTelefonMobil.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tTelefonMobil.ToString(), value); }
        }

        [BExport("Fax", true, 1)]
        public string Fax
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tFax.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tFax.ToString(), value); }
        }


        [BExport("ContSkype", true, 1)]
        public string ContSkype
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tContSkype.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tContSkype.ToString(), value); }
        }


        [BExport("ContYM", true, 1)]
        public string ContYM
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tContYM.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tContYM.ToString(), value); }
        }


        [BExport("AdresaMail", true, 1)]
        public string AdresaMail
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tAdresaMail.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tAdresaMail.ToString(), value); }
        }


        [BExport("PaginaWeb", true, 1)]
        public string PaginaWeb
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tPaginaWeb.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tPaginaWeb.ToString(), value); }
        }

        [BExport("InfoContact", true, 1)]
        public string InfoContact
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tInfoContact.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tInfoContact.ToString(), value); }
        }

        [BExport("Logo", true, 1)]
        public string Logo
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tLogo.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tLogo.ToString(), value); }
        }

        [BExport("IdLocatieDetaliiFiscale", true, 1)]
        public int IdLocatieDetaliiFiscale
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DLocatii.EnumCampuriTabela.xnIdLocatieDetaliiFiscale.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.xnIdLocatieDetaliiFiscale.ToString(), value); }
        }


        [BExport("DenumireFiscala", true, 1)]
        public string DenumireFiscala
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tDenumireFiscala.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tDenumireFiscala.ToString(), value); }
        }


        [BExport("TipFiscalitate", true, 1)]
        public int TipFiscalitate
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DLocatii.EnumCampuriTabela.nTipFiscalitate.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.nTipFiscalitate.ToString(), value); }
        }


        [BExport("CodFiscal", true, 1)]
        public string CodFiscal
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tCodFiscal.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tCodFiscal.ToString(), value); }
        }


        [BExport("NumarInregistrare", true, 1)]
        public string NumarInregistrare
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tNumarInregistrare.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tNumarInregistrare.ToString(), value); }
        }


        [BExport("ContIBAN", true, 1)]
        public string ContIBAN
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tContIBAN.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tContIBAN.ToString(), value); }
        }


        [BExport("DenumireBanca", true, 1)]
        public string DenumireBanca
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tDenumireBanca.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tDenumireBanca.ToString(), value); }
        }


        [BExport("ReprezentantLegal", true, 1)]
        public string ReprezentantLegal
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tReprezentantLegal.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tReprezentantLegal.ToString(), value); }
        }


        [BExport("CalitateReprezentantLegal", true, 1)]
        public string CalitateReprezentantLegal
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tCalitateReprezentantLegal.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tCalitateReprezentantLegal.ToString(), value); }
        }


        [BExport("SerieChitante", true, 1)]
        public string SerieChitante
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tSerieChitante.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tSerieChitante.ToString(), value); }
        }


        [BExport("NumarUltimaChitanta", true, 1)]
        public int NumarUltimaChitanta
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DLocatii.EnumCampuriTabela.nNumarUltimaChitanta.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.nNumarUltimaChitanta.ToString(), value); }
        }


        [BExport("SerieFacturi", true, 1)]
        public string SerieFacturi
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tSerieFacturi.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tSerieFacturi.ToString(), value); }
        }


        [BExport("NumarUltimaFactura", true, 1)]
        public int NumarUltimaFactura
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DLocatii.EnumCampuriTabela.nNumarUltimaFactura.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.nNumarUltimaFactura.ToString(), value); }
        }

        [BExport("PlatitorDeTVA", true, 1)]
        public bool PlatitorDeTVA
        {
            get { return this.MyDataRowGetItemAsBooleanNull(DLocatii.EnumCampuriTabela.bPlatitorDeTVA.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.bPlatitorDeTVA.ToString(), value); }
        }


        [BExport("InitialaLocatie", true, 1)]
        public string InitialaLocatie
        {
            get { return this.MyDataRowGetItem(DLocatii.EnumCampuriTabela.tInitialaLocatie.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.tInitialaLocatie.ToString(), value); }
        }

        [BExport("SubTipLocatie", true, 1)]
        public int SubTipLocatie
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DLocatii.EnumCampuriTabela.nSubTipLocatie.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.nSubTipLocatie.ToString(), value); }
        }


        [BExport("Culoare", true, 1)]
        public int Culoare
        {
            get { return this.MyDataRowGetItemAsIntegerNull(DLocatii.EnumCampuriTabela.nCuloare.ToString()); }
            set { this.MyDataRowSetItem(DLocatii.EnumCampuriTabela.nCuloare.ToString(), value); }
        }


        /// <summary>
        /// Tipul listei de motive de inchidere
        /// </summary>
        public CDefinitiiComune.EnumTipLista ListaMotiveInchidere
        {
            get { return CDefinitiiComune.EnumTipLista.LocatiiMotivInchidere; }
        }

        public CDefinitiiComune.EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static CDefinitiiComune.EnumTipObiect TipObiectClasa
        {
            get { return CDefinitiiComune.EnumTipObiect.Locatie; }
        }

        public string DenumireAfisaj
        {
            get { return this.ToString(); }
        }

        #endregion //Proprietati

        #region Constructori

        public BLocatii(int pId)
        : this(pId, null)
        {
        }

        public BLocatii(int pId, IDbTransaction pTranzactie)
        {
            FillObjectWithDataRow<BLocatii>(GetDataRowForObjet(pId, pTranzactie), this);
        }

        public BLocatii(DataRow pMyRow)
        {
            FillObjectWithDataRow<BLocatii>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DLocatii
        /// </summary>
        /// <param name="pDenumire"></param>
        /// <param name="pTipClient"></param>
        /// <param name="pDenumireFiscala"></param>
        /// <param name="pCUI"></param>
        /// <param name="pRegCom"></param>
        /// <param name="pTelefonMobil"></param>
        /// <param name="pTelefonFix"></param>
        /// <param name="pFax"></param>
        /// <param name="pContSkype"></param>
        /// <param name="pAdresaMail"></param>
        /// <param name="pPaginaWeb"></param>
        /// <param name="pObservatii"></param>
        /// <param name="pTipRecomandant"></param>
        /// <param name="pIdRecomandant"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(string pDenumire, EnumTipLocatie pTipLocatie, int pIdLocatieRadacina, int pIdGrup, int pIdSediu, int pIdSectie, int pIdUnitateFunctionala, string pTelefonMobil, string pFax, string pContSkype, string pContYM, string pAdresaMail, string pPaginaWeb, string pInfoContact, string pLogo, int pIdLocatieDetaliiFiscale, string pDenumireFiscala, BDefinitiiGenerale.EnumTipFiscalitate pTipFiscalitate, string pCodFiscal, string pNumarInregistrare, string pContIBAN, string pDenumireBanca, string pReprezentantLegal, string pCalitateReprezentantLegal, string pSerieChitante, int pNumarUltimaChitanta, string pSerieFacturi, int pNumarUltimaFactura, bool pPlatitorDeTVA, string pInitialaLocatie, int pSubTipLocatie, int pCuloare, IDbTransaction pTranzactie)
        {
            int id = DLocatii.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pDenumire, Convert.ToInt32(pTipLocatie), pIdLocatieRadacina, pIdGrup, pIdSediu, pIdSectie, pIdUnitateFunctionala, pTelefonMobil, pFax, pContSkype, pContYM, pAdresaMail, pPaginaWeb, pInfoContact, pLogo, pIdLocatieDetaliiFiscale, pDenumireFiscala, Convert.ToInt32(pTipFiscalitate), pCodFiscal, pNumarInregistrare, pContIBAN, pDenumireBanca, pReprezentantLegal, pCalitateReprezentantLegal, pSerieChitante, pNumarUltimaChitanta, pSerieFacturi, pNumarUltimaFactura, pPlatitorDeTVA, pInitialaLocatie, pSubTipLocatie, pCuloare, pTranzactie);
            return id;
        }

        public static int Add(string pDenumire, IDbTransaction pTranzactie)
        {
            return DLocatii.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), pDenumire, pTranzactie);
        }

        public static bool SuntInformatiileNecesareCoerente(string pDenumire, int pTipLocatie)
        {
            return !string.IsNullOrEmpty(pDenumire) && pTipLocatie != 0;
        }

        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BLocatii
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieLocatii GetListByParam(CDefinitiiComune.EnumStare pStare, IDbTransaction pTranzactie)
        {
            BColectieLocatii lstDLocatii = new BColectieLocatii();
            using (DataSet ds = DLocatii.GetListByParam(pStare, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDLocatii.Add(new BLocatii(dr));
                }
            }
            return lstDLocatii;
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
                throw new IdentificareBazaImposibilaException("BLocatii");
            using (DataSet ds = DLocatii.GetById(pId, pTranzactie))
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    throw new IdentificareBazaImposibilaException("BLocatii");
            }
        }

        public static BColectieLocatii getByListaId(List<int> pListaId, IDbTransaction pTranzactie)
        {
            BColectieLocatii listaRetur = new BColectieLocatii();
            if (!CUtil.EsteListaIntVida(pListaId))
            {
                using (DataSet ds = DLocatii.GetByListId(pListaId, pTranzactie))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaRetur.Add(new BLocatii(dr));
                    }
                }
            }
            return listaRetur;
        }

        public static BLocatii GetLocatieCurenta()
        {
            return GetListByParam(CDefinitiiComune.EnumStare.Activa, null)[0];
        }

        #endregion //Metode de clasa

        #region Metode de instanta

        public void UpdateLogoSediu(FileInfo imagine, IDbTransaction pTranzactie)
        {
            if (imagine == null)
                return;

            BDocumenteInline docProfil = BDocumenteInline.GetLogoSediuMobileAPP(this.Id, pTranzactie);

            using (var stream = new FileStream(imagine.FullName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    if (docProfil != null)
                    {

                        docProfil.UpdateImagine(reader.ReadBytes((int)stream.Length), null);
                    }
                    else
                        BDocumenteInline.Add(BLocatii.TipObiectClasa, this.Id, BDocumenteInline.EnumTipDocumentInline.LogoSediu, reader.ReadBytes((int)stream.Length), string.Empty, pTranzactie);
                }
            }
        }

        public void StergeLogoSediu(IDbTransaction pTranzactie)
        {
            BDocumenteInline docProfil = BDocumenteInline.GetLogoSediuMobileAPP(this.Id, pTranzactie);

            if (docProfil != null)
                docProfil.Delete(pTranzactie);
        }

        public Image GetLogoSediu(IDbTransaction pTranzactie)
        {
            BDocumenteInline logoSediu = BDocumenteInline.GetLogoSediuMobileAPP(this.Id, pTranzactie);

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

        public BAdrese GetAdresa(IDbTransaction pTranzactie)
        {
            BAdrese adresa = BAdrese.GetListByParam(BAdrese.EnumTipAdresa.SediuSocial, TipObiectClasa, this.Id, CDefinitiiComune.EnumStare.Activa, pTranzactie).GetAdresaDeAfisatDinOficiu();

            if (adresa == null)
            {
                int idAdrAdaugata = BAdrese.Add(BAdrese.EnumTipAdresa.SediuSocial, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Referinta.BTari.ConstIDRomania, 0, 0, string.Empty, string.Empty, TipObiectClasa, this.Id, pTranzactie);

                adresa = new BAdrese(idAdrAdaugata, pTranzactie);
            }

            return adresa;
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
                bool succesModificare = DLocatii.UpdateById(getDictProprietatiModificate(), this.Id, Tranzactie);

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

                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tDenumire.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tMotivInchidere.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.nTipLocatie.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.xnIdLocatieRadacina.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.xnIdGrup.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.xnIdSediu.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.xnIdSectie.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.xnIdUnitateFunctionala.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tTelefonMobil.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tFax.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tContSkype.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tContYM.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tAdresaMail.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tPaginaWeb.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tInfoContact.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tLogo.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.xnIdLocatieDetaliiFiscale.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tDenumireFiscala.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.nTipFiscalitate.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tCodFiscal.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tNumarInregistrare.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tContIBAN.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tDenumireBanca.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tReprezentantLegal.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tCalitateReprezentantLegal.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tSerieChitante.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.nNumarUltimaChitanta.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tSerieFacturi.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.nNumarUltimaFactura.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.bPlatitorDeTVA.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tInitialaLocatie.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.nSubTipLocatie.ToString()) ||
                  this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.nCuloare.ToString());
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
                throw new IdentificareBazaImposibilaException("BLocatii");
            IDbTransaction Tranzactie = null;
            try
            {
                if (pTranzactie == null)
                    Tranzactie = CCerereSQL.GetTransactionOnConnection();
                else
                    Tranzactie = pTranzactie;
                //Inchidem obiectul in baza de date
                DLocatii.CloseById(BUtilizator.GetIdUtilizatorConectat(Tranzactie), this.Id, pInchidere, pMotivInchidere, Tranzactie);

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
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tDenumire.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tDenumire.ToString(), this.Denumire);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tMotivInchidere.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tMotivInchidere.ToString(), this.MotivInchidere);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.nTipLocatie.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.nTipLocatie.ToString(), Convert.ToInt32(this.TipLocatie));
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.xnIdLocatieRadacina.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.xnIdLocatieRadacina.ToString(), this.IdLocatieRadacina);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.xnIdGrup.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.xnIdGrup.ToString(), this.IdGrup);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.xnIdSediu.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.xnIdSediu.ToString(), this.IdSediu);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.xnIdSectie.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.xnIdSectie.ToString(), this.IdSectie);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.xnIdUnitateFunctionala.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.xnIdUnitateFunctionala.ToString(), this.IdUnitateFunctionala);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tTelefonMobil.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tTelefonMobil.ToString(), this.TelefonMobil);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tFax.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tFax.ToString(), this.Fax);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tContSkype.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tContSkype.ToString(), this.ContSkype);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tContYM.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tContYM.ToString(), this.ContYM);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tAdresaMail.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tAdresaMail.ToString(), this.AdresaMail);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tPaginaWeb.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tPaginaWeb.ToString(), this.PaginaWeb);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tInfoContact.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tInfoContact.ToString(), this.InfoContact);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tLogo.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tLogo.ToString(), this.Logo);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.xnIdLocatieDetaliiFiscale.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.xnIdLocatieDetaliiFiscale.ToString(), this.IdLocatieDetaliiFiscale);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tDenumireFiscala.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tDenumireFiscala.ToString(), this.DenumireFiscala);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.nTipFiscalitate.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.nTipFiscalitate.ToString(), this.TipFiscalitate);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tCodFiscal.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tCodFiscal.ToString(), this.CodFiscal);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tNumarInregistrare.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tNumarInregistrare.ToString(), this.NumarInregistrare);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tContIBAN.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tContIBAN.ToString(), this.ContIBAN);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tDenumireBanca.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tDenumireBanca.ToString(), this.DenumireBanca);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tReprezentantLegal.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tReprezentantLegal.ToString(), this.ReprezentantLegal);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tCalitateReprezentantLegal.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tCalitateReprezentantLegal.ToString(), this.CalitateReprezentantLegal);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tSerieChitante.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tSerieChitante.ToString(), this.SerieChitante);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.nNumarUltimaChitanta.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.nNumarUltimaChitanta.ToString(), this.NumarUltimaChitanta);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tSerieFacturi.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tSerieFacturi.ToString(), this.SerieFacturi);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.nNumarUltimaFactura.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.nNumarUltimaFactura.ToString(), this.NumarUltimaFactura);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.bPlatitorDeTVA.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.bPlatitorDeTVA.ToString(), this.PlatitorDeTVA);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.tInitialaLocatie.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.tInitialaLocatie.ToString(), this.InitialaLocatie);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.nSubTipLocatie.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.nSubTipLocatie.ToString(), this.SubTipLocatie);
            if (this.IsMyDataRowItemHasChanged(DLocatii.EnumCampuriTabela.nCuloare.ToString()))
                dictRezultat.Adauga(DLocatii.EnumCampuriTabela.nCuloare.ToString(), this.Culoare, false);
            return dictRezultat;
        }

        /// <summary>
        /// Metoda de instanta ce permite actualizarea obiectului prin informatiile ce ii corespund in baza de date
        /// </summary>
        /// <remarks>Exceptie daca nu se poate identifica obiectul datorita lipsei elementelor de identificare (identifiantului)</remarks>
        public void Refresh(IDbTransaction pTranzactie)
        {
            if (this.Id <= 0)
                throw new IdentificareBazaImposibilaException("BLocatii");

            FillObjectWithDataRow<BLocatii>(GetDataRowForObjet(this.Id, pTranzactie), this);
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
            myXmlDoc.LoadXml("<DLocatii></DLocatii>");

            //Adaugam elementele clasei BLocatii
            myXmlElem = myXmlDoc.CreateElement("ID");
            myXmlElem.InnerText = Convert.ToString(this.Id);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DENUMIRE");
            myXmlElem.InnerText = this.Denumire;
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

            myXmlElem = myXmlDoc.CreateElement("TIPLOCATIE");
            myXmlElem.InnerText = Convert.ToString(this.TipLocatie);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDLOCATIERADACINA");
            myXmlElem.InnerText = Convert.ToString(this.IdLocatieRadacina);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDGRUP");
            myXmlElem.InnerText = Convert.ToString(this.IdGrup);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDSEDIU");
            myXmlElem.InnerText = Convert.ToString(this.IdSediu);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDSECTIE");
            myXmlElem.InnerText = Convert.ToString(this.IdSectie);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDUNITATEFUNCTIONALA");
            myXmlElem.InnerText = Convert.ToString(this.IdUnitateFunctionala);
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

            myXmlElem = myXmlDoc.CreateElement("LOGO");
            myXmlElem.InnerText = this.Logo;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDLOCATIEDETALIIFISCALE");
            myXmlElem.InnerText = Convert.ToString(this.IdLocatieDetaliiFiscale);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DENUMIREFISCALA");
            myXmlElem.InnerText = this.DenumireFiscala;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("TIPFISCALITATE");
            myXmlElem.InnerText = Convert.ToString(this.TipFiscalitate);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CODFISCAL");
            myXmlElem.InnerText = this.CodFiscal;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMARINREGISTRARE");
            myXmlElem.InnerText = this.NumarInregistrare;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CONTIBAN");
            myXmlElem.InnerText = this.ContIBAN;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DENUMIREBANCA");
            myXmlElem.InnerText = this.DenumireBanca;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("REPREZENTANTLEGAL");
            myXmlElem.InnerText = this.ReprezentantLegal;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CALITATEREPREZENTANTLEGAL");
            myXmlElem.InnerText = this.CalitateReprezentantLegal;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("SERIECHITANTE");
            myXmlElem.InnerText = this.SerieChitante;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMARULTIMACHITANTA");
            myXmlElem.InnerText = Convert.ToString(this.NumarUltimaChitanta);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("SERIEFACTURI");
            myXmlElem.InnerText = this.SerieFacturi;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("NUMARULTIMAFACTURA");
            myXmlElem.InnerText = Convert.ToString(this.NumarUltimaFactura);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("PLATITORDETVA");
            myXmlElem.InnerText = Convert.ToString(this.PlatitorDeTVA);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("INITIALALOCATIE");
            myXmlElem.InnerText = this.InitialaLocatie;
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("SUBTIPLOCATIE");
            myXmlElem.InnerText = Convert.ToString(this.SubTipLocatie);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("CULOARE");
            myXmlElem.InnerText = Convert.ToString(this.Culoare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);



            //Recuperam textul XML
            sRet = myXmlDoc.InnerXml;

            //Distrugem obiectele folosite:
            myXmlElem = null;
            myXmlDoc = null;

            return sRet;
        }

        #endregion //Metode de instanta

        #region Metode de comparatie

        public static int ComparaDupaNume(BLocatii xElemLista1, BLocatii xElemLista2)
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
                    return xElemLista1.Denumire.CompareTo(xElemLista2.Denumire);
            }
        }

        #endregion //Metode de comparatie

    }
}
