using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDL.iStomaLab
{
    public class CDefinitiiComune
    {
        public static bool VerificaFormatAdresaMail(string pAdresaMail)
        {
            string sExpression = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            System.Text.RegularExpressions.Regex xRegex = new System.Text.RegularExpressions.Regex(sExpression);
            if ((xRegex.IsMatch(pAdresaMail)) || string.IsNullOrEmpty(pAdresaMail.Trim()))
                return true;
            else
                return false;
        }

        public static System.Drawing.Font _Font_DPI = null;
        public const int _DPI_DEV = 96;
        public static float _FactorMultiplicareDPI_X = 1F;
        public static float _FactorMultiplicareDPI_Y = 1F;
        public static System.Drawing.SizeF _FactorScalareDPI = new System.Drawing.SizeF(1, 1);
        public static float _DPI_X = 96;
        public static float _DPI_Y = 96;

        public static void setFactorMultiplicareDPI(System.Drawing.Graphics g, System.Drawing.Font pFont)
        {
            _Font_DPI = pFont;
            if (g.DpiX != _DPI_DEV)
            {
                _DPI_X = g.DpiX;
                _DPI_Y = g.DpiY;
                _FactorMultiplicareDPI_X = g.DpiX / _DPI_DEV;
                _FactorMultiplicareDPI_Y = g.DpiY / _DPI_DEV;

                _FactorScalareDPI = new System.Drawing.SizeF(_FactorMultiplicareDPI_X, _FactorMultiplicareDPI_Y);
            }
        }

        public delegate void DeschideObiectHandler(EnumTipObiect pTipObiect, long pIdObiect);
        public delegate void CautaObiectHandler(EnumTipObiect pTipObiect);
        public delegate void SelectieUnicaHandler<T>(T pElemSelectionat);
        public delegate void SelectieMultiplaHandler<T>(List<T> pListaSelectionata);

        /// <summary>
        /// Nedefinit = probono cand recuperam rezumatul PacientTratamentPlati_TD_GetValoriByPerioadaSiMoneda
        /// </summary>
        public enum EnumTipMoneda
        {
            Nedefinit = 0,
            /// <summary>
            /// Lei
            /// </summary>
            Lei = 1,
            /// <summary>
            /// Euro
            /// </summary>
            Euro = 2,
            Barter = 3
        }

        public enum EnumMarime
        {
            Small = 0,
            Medium = 1,
            Large = 2
        }

        public enum EnumRaspuns
        {
            NuStiu = 0,
            Nu = 2,
            Da = 1
        }

        public enum EnumModComunicare
        {
            Nedefinit = 0,
            Email = 1,
            SMS = 2,
            Skype = 3,
            YM = 4,
            Facebook = 5,
            Fax = 6,
            Telefonie = 7,
            PaginaWeb = 8,
            MesajIntern = 9,
            Manual = 10
        }

        public enum EnumTipColoanaDGV
        {
            Nedefinit = 0,
            Text = 1,
            Data = 2,
            CheckBox = 3,
            ValoareMonetara = 4,
            TextMultiline = 5
        }

        public enum EnumTipSelectie
        {
            FaraSelectie = 0,
            SelectieUnica = 1,
            SelectieMultipla = 2
        }

        public enum EnumStare
        {
            Activa = 0,
            Dezactiva = 1,
            Toate = 2
        }

        public enum EnumTipPerioada : int //valorile sunt inportamnte pentru agenda
        {
            Custom = 0,
            Zi = 1,
            PatruZile = 4,
            Saptamana = 7,
            Luna = 28,
            An = 365,
            Trimestru = 91,
            Semestru = 366
        }

        public enum Month : int
        {
            NotSet = 0,
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }

        public enum EnumTipText
        {
            Nedefinit = 0,
            HTML = 1,
            Simplu = 2,
            SMS = 3
        }

        public enum EnumSex
        {
            Nedefinit = 0,
            Barbatesc = 1,
            Femeiesc = 2,
            FaraSex = 3
        }

        public enum EnumRol
        {
            Nedefinit = 0,
            Tehnician = 1,
            Manager = 2,
            Administrativ = 3,
            PersonalTehnic = 4,
            Administrator = 5,
            MedicTitular = 6,
            CMI = 7,
            Curier = 8,
            Receptie = 9,
            Agent = 10
        }

        public enum EnumTitulatura
        {
            Nedefinit = 0,
            Domn = 1,
            Doamna = 2,
            Domnisoara = 3,
            Profesor = 4,
            Doctor = 5,
            ProfesorDoctor = 6,
            Asistent = 7
        }

        public enum EnumStareCivila
        {
            Nespecificat = 0,
            Casatorit = 1,
            Necasatorit = 2,
            Divortat = 3,
            Concubinaj = 4,
            InCuplu = 5
        }

        public enum EnumTipContract
        {
            Nespecificat = 0,
            CIM = 1,
            CC = 2
        }

        public enum EnumModComunicarePreferat
        {
            Nedefinit = 0,
            /// <summary>
            /// Telefon mobil
            /// </summary>
            TelefonMobil = 1,
            /// <summary>
            /// Telefon fix adresă principală
            /// </summary>
            TelefonFixAdresaPrincipala = 2,
            /// <summary>
            /// E-mail
            /// </summary>
            Mail = 3,
            /// <summary>
            /// Yahoo Messenger
            /// </summary>
            YM = 4,
            /// <summary>
            /// Skype
            /// </summary>
            Skype = 5
        }

        #region Tip Ecran

        public enum EnumTipEcran
        {
            Nedefinit = 0,
        }

        #endregion

        #region Tip Obiect

        public enum EnumTipObiect
        {
            Nedefinit = 0,
            Utilizator = 1,
            Locatie = 2,
            Pacient = 3,
            StructTipActIdentitate = 4,
            StructModalitatePlata = 5,
            ColectieStructTrimestru = 6,
            MultiLingv = 7,
            ColectieStructSemestru = 8,
            StructLunaAn = 9,
            ColectieStructLunileAnului = 10,
            StatiiDeLucru = 11,
            StatiiDeLucruUtilizatori = 12,
            Tari = 13,
            Regiuni = 14,
            Localitati = 15,
            ListeParametrabile = 16,
            Profesii = 17,
            Adrese = 18,
            ListaPreturiStandard = 19,
            ListaPreturiClienti = 20,
            Clienti = 21,
            ClientiReprezentanti = 22,
            ClientiComenzi = 23,
            Email = 24,
            Categorii = 25,
            Etape = 26,
            Pontaj = 27,
            LucrariEtape = 28,
            UtilizatorLucrariEtape = 29,
            EmailuriExtrase = 30,
            ClientiCabinete = 31,
            ClientiComenziEtape = 32,
            Banci = 33,
            ClientiPlati = 34,
            ClientiFacturi = 35,
            ClientiPlatiComenzi = 36,
            ListaAfisaj = 37,
            ListeAfisajColoane = 38,
            ComportamentAplicatie = 39,
            StructTipDocumentInline = 40,
            DocumenteInline = 41,
            EchipaISTOMA = 42,
            UtilizatorDrepturi = 43,
            DeInlocuit = 44,
        }

        #endregion

        public enum EnumTipLista
        {
            MotiveInchidereUtilizator = 0,
            TariMotiveInchidere = 1,
            RegiuniMotivInchidere = 2,
            LocalitatiMotivInchidere = 3,
            LocatiiMotivInchidere = 4,
            ListeParametrabileMotivInchidere = 5,
            ProfesiiMotiveInchidere = 6,
            AdreseMotiveInchidere = 7,
            ListaPreturiStandardMotiveInchidere = 8,
            ListaPreturiClientiMotiveInchidere = 9,
            ClientiMotiveInchidere = 10,
            ListaProfesii = 11,
            ListaTari = 12,
            ListaLocalitati = 13,
            ListaRegiuni = 14,
            ClientiReprezentantiMotiveInchidere = 15,
            ClientiComenziMotiveInchidere = 16,
            Nespecificat = 17,
            EmailMotiveInchidere = 18,
            CategoriiMotiveInchidere = 19,
            ListaCategorii = 20,
            EtapeMotiveInchidere = 21,
            Nedefinita = 22,
            AltePersoane = 23,
            ListaParametrabila = 24,
            ClientiCabineteMotiveInchidere = 25,
            ClientiComenziEtapeMotiveInchidere = 26,
            BanciMotiveInchidere = 27,
            ListaBanci = 28,
            ClientiPlatiMotiveInchidere = 29,
            ClientiFacturiMotiveInchidere = 30,
            ClientiPlatiComenziMotiveInchidere = 31
        }

        public enum EnumTipDosarClient
        {
            Date = 0,
            Comenzi = 2,
            Plati = 3,
            ListaPreturi = 4,
            Nespecificat = 6
        }

        public enum EnumTipActiune
        {

        }

        public enum EnumTipProprietarPostIT
        {
            Nedefinit = 0,
            /// <summary>
            /// Ecran principal
            /// </summary>
            EcranPrincipal = 1,
            /// <summary>
            /// Pacient
            /// </summary>
            Pacient = 2
        }

        public enum EnumTipProprietarDocumente
        {
            Nedefinit = 0,
            ImagineIdentitate = 1,
            ImagineComponentaArtificiala = 2,
            LogoLocatie = 3,
            LogoFiscalLocatie = 4,
            PlanTratamentImprimat = 5,
            DevizEstimativImprimat = 6
        }

        public enum EnumNivelScolorizare
        {
            Nedefinit = 0,
            StudiiElementare = 1,
            Profesionala = 2,
            StudiiMedii = 3,
            StudiiPostliceale = 4,
            StudiiSuperioare = 5,
            StudiiPostUniversitare = 6
        }

        public enum EnumModAfisareTelefonAgenda
        {
            GrupuriDouaSfCuPunct = 0,
            GrupuriDouaSfCuSpatiu = 1,
            PatruTreiTreiCuPunct = 2,
            PatruTreiTreiCuSpatiu = 3,
            FaraSeparare = 4
        }

        #region EnumTipActIdentitate

        //Structura se gaseste in BDefinitiiGenerale
        public enum EnumTipActIdentitate
        {
            Nedefinit = 0,
            /// <summary>
            /// C.I.
            /// </summary>
            CI = 1,
            /// <summary>
            /// B.I.
            /// </summary>
            BI = 2,
            Pasaport = 3
        }

        #endregion //EnumTipActIdentitate

        public enum EnumTipNotificare
        {
            Mesaj,
            PacientSosit,
            Conectare,
            Deconectare
        }

        public enum EnumTipLocatie
        {
            Nedefinit = 0,
            Sediu = 1
        }

    }
}
