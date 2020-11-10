using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab
{
    public static class BMultiLingv
    {
        public enum EnumLimba
        {
            Nedefinit = 0,
            Romana = 1
        }

        public enum EnumDictionar
        {
            CreatDe = 1,
            LaData = 2,
            NuConteaza = 3,
            PanaIn = 4,
            Intre = 5,
            pesteCaInterval = 6,
            ImagineIdentitate = 7,
            ContractIndividualDeMunca = 8,
            ContractDeColaborare = 9,
            POS = 10,
            Cash = 11,
            Banca = 12,
            CEC = 13,
            Voucher = 14,
            Compensare = 15,
            Normal = 16,
            Mediu = 17,
            Mare = 18,
            Mic = 19,
            FoarteMic = 20,
            Semestrul1 = 21,
            Semestrul2 = 22,
            Trimestrul1 = 23,
            Trimestrul2 = 24,
            Trimestrul3 = 25,
            Trimestrul4 = 26,
            Email = 27,
            TelefonFix = 28,
            TelefonMobil = 29,
            Perioada = 30,
            PerioadaOrara = 31,
            DataUnica = 32,
            Confirmat = 33,
            Infirmat = 34,
            Nedeterminat = 35,
            Oricand = 36,
            PanaLaOra = 37,
            DupaOra = 38,
            SaptamanaAceasta = 39,
            saptamanaViitoare = 40,
            LunaAceasta = 41,
            LunaViitoare = 42,
            LunaTrecuta = 43,
            Capricorn = 44,
            Varsator = 45,
            Pesti = 46,
            Berbec = 47,
            Taur = 48,
            Gemeni = 49,
            Rac = 50,
            Leu = 51,
            Fecioara = 52,
            Balanta = 53,
            Scorpion = 54,
            Sagetator = 55,
            captionDa = 56,
            captionNu = 57,
            Decembrie = 58,
            Noiembrie = 59,
            Octombrie = 60,
            Septembrie = 61,
            August = 62,
            Iulie = 63,
            Iunie = 64,
            Mai = 65,
            Aprilie = 66,
            Martie = 67,
            Februarie = 68,
            Ianuarie = 69,
            Casatorit = 70,
            Concubinaj = 71,
            Divortat = 72,
            InCuplu = 73,
            Necasatorit = 74,
            StudiiSuperioare = 75,
            Superioare = 76,
            StudiiPostliceale = 77,
            Postliceala = 78,
            StudiiPostuniversitare = 79,
            Postuniversitare = 80,
            StudiiMediiLiceu = 81,
            Liceu = 82,
            StudiiElementare = 83,
            PrescurtareStudiiElementare = 84,
            Profesionala = 85,
            Dna = 86,
            Doamna = 87,
            Dr = 88,
            Doctor = 89,
            Dl = 90,
            Domnul = 91,
            Dsoara = 92,
            Domnisoara = 93,
            Pr = 94,
            Profesor = 95,
            ProfDr = 96,
            ProfesorDoctor = 97,
            As = 98,
            Asistent = 99,
            captionMasculin = 100,
            captionFeminin = 101,
            captionNedefinit = 102,
            PastreazaMaConectat = 103,
            Parola = 104,
            ContUtilizator = 105,
            Conectare = 106,
            iStoma = 107,
            TablouDeBord = 108,
            Rapoarte = 109,
            Setari = 110,
            ListaDePreturi = 111,
            Locatii = 112,
            Personal = 113,
            Diverse = 114,
            Nume = 115,
            Prenume = 116,
            ConfirmatiStergerea = 117,
            Stergere = 118,
            CNP = 119,
            DataNasterii = 120,
            Clienti = 121,
            CodFiscal = 122,
            NrInregistrare = 123,
            Denumire = 124,
            DenumireFiscala = 125,
            CUI = 126,
            RegistrulComertului = 127,
            PaginaWeb = 128,
            Fax = 129,
            Skype = 130,
            Observatii = 131,
            Prescurtare = 132,
            Cod = 133,
            Categorie = 134,
            Valoare = 135,
            RON = 136,
            EUR = 137,
            TermenMediu = 138,
            Zile = 139,
            Liste = 140,
            InformatiiGenerale = 141,
            Initiala = 142,
            Tip = 143,
            Locatie = 144,
            Culoare = 145,
            InfoContact = 146,
            ContYM = 147,
            InformatiiFiscale = 148,
            Logo = 149,
            DimensiuneLogo = 150,
            CMI = 151,
            SRL = 152,
            TVA = 153,
            IBAN = 154,
            ReprezentantLegal = 155,
            Calitate = 156,
            SerieChitante = 157,
            NrUltimaChitanta = 158,
            SerieFacturi = 159,
            NrUltimaFactura = 160,
            Supranume = 161,
            NumeDeFata = 162,
            Sex = 163,
            StareCivila = 164,
            NrCopii = 165,
            Serie = 166,
            Numar = 167,
            Educatie = 168,
            Scoala = 169,
            Profesie = 170,
            Nationalitate = 171,
            Tara = 172,
            Judet = 173,
            Localitate = 174,
            Rol = 175,
            DataAngajare = 176,
            Cont = 177,
            Profesii = 178,
            Tari = 179,
            Localitati = 180,
            Regiuni = 181,
            Total = 182,
            CodCOR = 183,
            Abreviere = 184,
            PrefixTelefonic = 185,
            Regiune = 186,
            NumeOficial = 187,
            Cetatenie = 188,
            Limba = 189,
            Date = 190,
            Reprezentanti = 191,
            Comenzi = 192,
            Plati = 193,
            MeniuStanga = 194,
            Pauza = 195,
            Deconectare = 196,
            Iesire = 197,
            Inchidere = 198,
            ConfirmareInchidere = 199,
            Secunde = 200,
            Client = 201,
            Lucrari = 202,
            ElementeGasite = 203,
            ElementGasit = 204,
            Sediu = 205,
            ExceptieDenumireClient = 206,
            Inbox = 207,
            Comunicare = 208,
            Sender = 209,
            Subiect = 210,
            Data = 211,
            DeLa = 212,
            Pentru = 213,
            Facturi = 214,
            Incasari = 215,
            Reprezentant = 216,
            Pacient = 217,
            DataPrimire = 218,
            DataLaGata = 219,
            SMTP = 220,
            Port = 221,
            IMAP = 222,
            User = 223,
            SSL = 224,
            AplicatieSeVaInchideAutomatIn = 225,
            Lucrare = 226,
            Pret = 227,
            Moneda = 228,
            ListaPreturi = 229,
            PretStandard = 230,
            PretClient = 231,
            Categorii = 232,
            Subcategorie = 233,
            Durata = 234,
            Minute = 235,
            Etape = 236,
            Financiar = 237,
            Concedii = 238,
            Pontaj = 239,
            Administrativ = 240,
            Manager = 241,
            PersonalTehnic = 242,
            Tehnician = 243,
            Utilizator = 244,
            Astazi = 245,
            CheckIn = 246,
            CheckOut = 247,
            Deplasare = 248,
            FinalPauza = 249,
            RevenireInClinica = 250,
            Strada = 251,
            Nr = 252,
            Interfon = 253,
            Bloc = 254,
            Scara = 255,
            Etaj = 256,
            Ap = 257,
            CP = 258,
            ZileNelucratoare = 259,
            Detalii = 260,
            Rezumat = 261,
            DeLaData = 262,
            PanaLaData = 263,
            Schimba = 264,
            AnulAcesta = 265,
            AnulTrecut = 266,
            SaptamanaTrecuta = 267,
            AnulViitor = 268,
            DataInceput = 269,
            DataSfarsit = 270,
            InformareSelectareUtilizator = 271,
            Adresa = 272,
            DataCreare = 273,
            MotivulInchiderii = 274,
            Acum = 275,
            Reactivare = 276,
            Principala = 277,
            Secundara = 278,
            DeVacanta = 279,
            DeFacturare = 280,
            SediuSocial = 281,
            Selecteaza = 282,
            ApartamentPrescurtat = 283,
            BlocPrescurtat = 284,
            DataVerificare = 285,
            EtajPrescurtat = 286,
            NumarPrescurtat = 287,
            ScaraPrescurtat = 288,
            TelefonFixPrescurtat = 289,
            Actuala = 290,
            mesajConfirmareInchidereX = 291,
            mesajConfirmareReactivareX = 292,
            Neprecizat = 293,
            TipulAdreseiEsteObligatoriu = 294,
            Eroare = 295,
            Recomandant = 296,
            AltePersoane = 297,
            PFA = 298,
            II = 299,
            AdaugaSubcategorie = 300,
            InfoIntroducereEmail = 301,
            ComenziInLucru = 302,
            TipContract = 303,
            NrOreNorma = 304,
            DataContract = 305,
            DataIncetareContract = 306,
            NrContract = 307,
            SMTPPunct = 308,
            ImapPunct = 309,
            Cabinete = 310,
            UltimaComanda = 311,
            TotalComenzi = 312,
            Cabinet = 313,
            AdaugaEtapa = 314,
            Spatiu = 315,
            ModificaTehnician = 316,
            InformareSelectareLinie = 317,
            InformatiiIncomplete = 318,
            Value = 319,
            Key = 320,
            DurataMinute = 321,
            Drafts = 322,
            Sent = 323,
            Trash = 324,
            ServerSMTP = 325,
            PortSMTP = 326,
            ServerIMAP = 327,
            PortIMAP = 328,
            AdresaEmail = 329,
            Banci = 330,
            InformatiiSuplimentare = 331,
            ConfirmatiInchidereaBancii = 332,
            BI = 333,
            CI = 334,
            Telefon = 335,
            EmisDe = 336,
            Valabilitate = 337,
            SeConecteaza = 338,
            OreNorma = 339,
            ZileConcediu = 340,
            ConfirmatiReactivarea = 341,
            Medici = 342,
            Medic = 343,
            Adauga = 344,
            AdaugaClinica = 345,
            AdaugaComanda = 346,
            AdaugaMedic = 347,
            Clinica = 348,
            Importa = 349,
            Imagine = 350,
            Documente = 351,
            MaterialAudio = 352,
            MaterialVideo = 353,
            Document = 354,
            Urgent = 355,
            NrElemente = 356,
            SelectatiOLucrareDinLista = 357,
            Toate = 358,
            Clinici = 359,
            EtapaCurenta = 360,
            zile = 361,
            ImportPersonal = 362,
            Etapa = 363,
            PreturiStandard = 364,
            PreturiClinici = 365,
            UltimaLucrare = 366,
            TotalLucrari = 367,
            lucrari = 368,
            Website = 369,
            RegCom = 370,
            InCalitateDe = 371,
            Administrator = 372,
            MedicTitular = 373,
            DateClinica = 374,
            TotalMedici = 375,
            PretClinica = 376,
            NumeMedic = 377,
            PrenumeMedic = 378,
            DenFisc = 379,
            Repr = 380,
            NrContr = 381,
            DataContr = 382,
            Facturare = 383,
            Factura = 384,
            ValabilitateAct = 385,
            BineAtiVenit = 386,
            admin = 387,
            IstomaLTD = 388,
            InLucru = 389,
            Trecute = 390,
            MesajEroareDataTermen = 391,
            ImportClienti = 392,
            ImportDate = 393,
            DataFinal = 394,
            SelectatiTehnicianul = 395,
            Unu = 396,
            ComenziTrecute = 397,
            DataTermen = 398,
            Termen = 399,
            SelectatiCelPutinOLucrareDinLista = 400,
            SchimbaEtapa = 401,
            NrElem = 402,
            Refacere = 403,
            Finalizata = 404,
            Livrata = 405,
            Stare = 406,
            VeziToateEtapele = 407,
            ObsEtapa = 408,
            ObsLucrare = 409,
            X = 410,
            Achita = 411,
            FacturiEmise = 412,
            LucrariNefacturate = 413,
            Acceptata = 414,
            PretNegociat = 415,
            Titlu = 416,
            CentrareInPagina = 417,
            AfiseazaNumarulPaginii = 418,
            PeFiecarePagina = 419,
            Deselecteaza = 420,
            Clasic = 421,
            FolosesteLogo = 422,
            Imprimare = 423,
            Coloane = 424,
            Separator = 425,
            Goleste = 426,
            SelectatiCelPutinClinicaSiLucrarea = 427,
            Factureaza = 428,
            SelectatiClinica = 429,
            SelectatiLucrarile = 430,
            Curs = 431,
            SerieNr = 432,
            Proforma = 433,
            PretUnitar = 434,
            DataEmiterii = 435,
            CelPutinOLinieTrebuieBifata = 436,
            AfiseazaLucrarileInFunctieDe = 437,
            Cauta = 438,
            Tot = 439,
            NuExistaLucrariDeLaAceastaClinica = 440,
            zi = 441,
            Luna = 442,
            An = 443,
            PretTotal = 444,
            PretFactura = 445,
            Nefacturate = 446,
            Facturate = 447,
            CursBNR = 448,
            EuAlegCursulDeSchimb = 449,
            CursSchimb = 450,
            Echipa = 451,
            Curier = 452,
            Receptie = 453,
            Agent = 454,
            Varsta = 455,
            ani = 456,
            xElementeGasite = 457,
            unElementGasit = 458,
            CodComanda = 459,
            Fiscalizeaza = 460,
            SelectatiLinia = 461,
            DeschideFisaClinicii = 462,
            AfiseazaLucrarea = 463,
            Achitat = 464,
            RestDePlata = 465,
            PretModificat = 466,
            ValoareInitiala = 467,
            Platit = 468,
            Incasare = 469,
            Suma = 470,
            Modalitate = 471,
            Sold = 472,
            ProductieTehnicieni = 473,
            ClientiDatornici = 474,
            UltimaFactura = 475,
            ClientiNoi = 476,
            LucrariFacturate = 477,
            TotalFacturi = 478,
            TotalIncasari = 479,
            LucrarileFacturateNuPotFiSterse = 480,
            Succes = 481,
            Licenta = 482,
            Contracte = 483,
            Consiliere = 484,
            Optimizeaza = 485,
            MasBucuraDacaPuncteDeSuspensie = 486,
            VersiuneBazaDeDate = 487,
            VersiuneAplicatie = 488,
            VaMultumim = 499,
            Sugestie = 500,
            ContactatiUnReprezentantIdavaSolutions = 502,
            NuExistaConexiuneLaInternet = 503,
            NouaParola = 504,
            ParolaTrebuieSaContinaMinimSaseCaractere = 505,
            Marketing = 506,
            Prospecti = 507,
            TrimitereEmail = 508,
            TrimitereSMS = 509,
            Comportament = 510,
            SchimbaParola = 511,
            Gestiune = 512,
            Furnizori = 513,
            Stocuri = 514,
            Drepturi = 515,
            SelectatiTara = 516,
            UtilizatorulAdminNuPoateFiSters = 517,
            ResurseUmane = 518,
            PiataStomatologica = 519,
            NuExistaSerieFacturaAlocataPeLocatie = 520,
            SalariuFix = 521,
            PretFixPeEtapa = 522,
            PrinteazaBarCode = 523,
            ScanatiCodulDeBare = 524,
            LucrareaNuAFostGasitaInSistem = 525,
            Venituri = 526,
            ProcentDinIncasarileProprii = 527,
            ProcentDinProfitulPropriu = 528,
            TipVenit = 529,
            PanaLa = 530,
            ValoareAnormala = 531,
            DataDeInceputNuEsteCoerenta = 532,
            PretLei = 533,
            Venit = 534,
            NuExistaInstalatSAPCrystalReports = 535
        }

        /// <summary>
        /// Folosim intotdeauna discritice
        /// Ă,ă, Â,â, Î,î, Ș,ș, Ț,ț
        /// </summary>
        /// <param name="pTermen"></param>
        /// <returns></returns>
        public static string getElementById(EnumDictionar pTermen)
        {
            switch (pTermen)
            {
                case EnumDictionar.NuExistaInstalatSAPCrystalReports:
                    return "Nu există instalat SAP Crystal Reports pe unitatea dumneavoastra. Pentru vizualizare/tipărire rapoarte, vă rugăm contactați colegii de la suport.";
                case EnumDictionar.Venit:
                    return "Venit";
                case EnumDictionar.PretLei:
                    return "Preț (Lei)";
                case EnumDictionar.DataDeInceputNuEsteCoerenta:
                    return "Data de început nu este coerentă";
                case EnumDictionar.ValoareAnormala:
                    return "Valoare anormală";
                case EnumDictionar.PanaLa:
                    return "Până la";
                case EnumDictionar.TipVenit:
                    return "Tip venit";
                case EnumDictionar.ProcentDinIncasarileProprii:
                    return "Procent din încasarile proprii";
                case EnumDictionar.ProcentDinProfitulPropriu:
                    return "Procent din profitul propriu";
                case EnumDictionar.Venituri:
                    return "Venituri";
                case EnumDictionar.LucrareaNuAFostGasitaInSistem:
                    return "Lucrarea nu a fost gasită în sistem";
                case EnumDictionar.ScanatiCodulDeBare:
                    return "Scanați codul de bare de pe etichetă";
                case EnumDictionar.PrinteazaBarCode:
                    return "Printează Barcode";
                case EnumDictionar.PretFixPeEtapa:
                    return "Preț fix pe etapă";
                case EnumDictionar.SalariuFix:
                    return "Salariu fix";
                case EnumDictionar.NuExistaSerieFacturaAlocataPeLocatie:
                    return "Nu există serie factură alocată pe locație";
                case EnumDictionar.PiataStomatologica:
                    return "Piața stomatologică";
                case EnumDictionar.ResurseUmane:
                    return "Resurse umane";
                case EnumDictionar.UtilizatorulAdminNuPoateFiSters:
                    return "Utilizatorul admin nu poate fi șters";
                case EnumDictionar.SelectatiTara:
                    return "Selectați țara";
                case EnumDictionar.Drepturi:
                    return "Drepturi";
                case EnumDictionar.Stocuri:
                    return "Stocuri";
                case EnumDictionar.Furnizori:
                    return "Furnizori";
                case EnumDictionar.Gestiune:
                    return "Gestiune";
                case EnumDictionar.SchimbaParola:
                    return "Schimbă parola";
                case EnumDictionar.Comportament:
                    return "Comportament iStoma";
                case EnumDictionar.TrimitereSMS:
                    return "Trimitere SMS";
                case EnumDictionar.TrimitereEmail:
                    return "Trimitere email";
                case EnumDictionar.Prospecti:
                    return "Prospecți";
                case EnumDictionar.Marketing:
                    return "Marketing și comunicare";
                case EnumDictionar.ParolaTrebuieSaContinaMinimSaseCaractere:
                    return "Parola trebuie să conțină minim 6 caractere";
                case EnumDictionar.NouaParola:
                    return "Noua parolă";
                case EnumDictionar.NuExistaConexiuneLaInternet:
                    return "Nu există conexiune la Internet";
                case EnumDictionar.ContactatiUnReprezentantIdavaSolutions:
                    return "Contactați un reprezentant Idava Solutions";
                case EnumDictionar.Sugestie:
                    return "Sugestie";
                case EnumDictionar.VaMultumim:
                    return "Vă mulțumim!";
                case EnumDictionar.VersiuneAplicatie:
                    return "Versiune aplicație";
                case EnumDictionar.VersiuneBazaDeDate:
                    return "Versiune bază de date";
                case EnumDictionar.MasBucuraDacaPuncteDeSuspensie:
                    return "M-aș bucura dacă...";
                case EnumDictionar.Optimizeaza:
                    return "Optimizează";
                case EnumDictionar.Consiliere:
                    return "Consiliere";
                case EnumDictionar.Contracte:
                    return "Contracte";
                case EnumDictionar.Licenta:
                    return "Licență";
                case EnumDictionar.Succes:
                    return "Succes";
                case EnumDictionar.LucrarileFacturateNuPotFiSterse:
                    return "Lucrările facturate nu pot fi șterse";
                case EnumDictionar.TotalIncasari:
                    return "Total încasări";
                case EnumDictionar.TotalFacturi:
                    return "Total facturi";
                case EnumDictionar.LucrariFacturate:
                    return "Lucrări facturate";
                case EnumDictionar.ClientiNoi:
                    return "Clienți noi";
                case EnumDictionar.UltimaFactura:
                    return "Ultima factură";
                case EnumDictionar.ClientiDatornici:
                    return "Clienți cu datorii";
                case EnumDictionar.ProductieTehnicieni:
                    return "Producție tehnicieni";
                case EnumDictionar.ValoareInitiala:
                    return "Valoare inițială";
                case EnumDictionar.PretModificat:
                    return "Preț modificat";
                case EnumDictionar.RestDePlata:
                    return "Rest de plată";
                case EnumDictionar.Achitat:
                    return "Achitat";
                case EnumDictionar.AfiseazaLucrarea:
                    return "Afișează lucrarea";
                case EnumDictionar.DeschideFisaClinicii:
                    return "Deschide fișa clinicii";
                case EnumDictionar.SelectatiLinia:
                    return "Selectați linia";
                case EnumDictionar.Fiscalizeaza:
                    return "Fiscalizează";
                case EnumDictionar.CodComanda:
                    return "Cod comandă";
                case EnumDictionar.ani:
                    return "ani";
                case EnumDictionar.Varsta:
                    return "Vârstă";
                case EnumDictionar.Agent:
                    return "Agent";
                case EnumDictionar.Receptie:
                    return "Recepție";
                case EnumDictionar.Curier:
                    return "Curier";
                case EnumDictionar.Echipa:
                    return "Echipa";
                case EnumDictionar.CursSchimb:
                    return "Curs schimb";
                case EnumDictionar.EuAlegCursulDeSchimb:
                    return "Eu aleg cursul de schimb";
                case EnumDictionar.CursBNR:
                    return "Curs BNR";
                case EnumDictionar.Facturate:
                    return "Facturate";
                case EnumDictionar.Nefacturate:
                    return "Nefacturate";
                case EnumDictionar.PretFactura:
                    return "Preț factură";
                case EnumDictionar.PretTotal:
                    return "Preț total";
                case EnumDictionar.An:
                    return "An";
                case EnumDictionar.Luna:
                    return "Lună";
                case EnumDictionar.zi:
                    return "Zi";
                case EnumDictionar.NuExistaLucrariDeLaAceastaClinica:
                    return "Nu există lucrări de la această clinică";
                case EnumDictionar.Tot:
                    return "Tot";
                case EnumDictionar.Cauta:
                    return "Caută";
                case EnumDictionar.AfiseazaLucrarileInFunctieDe:
                    return "Afișează lucrările în funcție de";
                case EnumDictionar.AplicatieSeVaInchideAutomatIn:
                    return "Aplicația se va închide automat în:";
                case EnumDictionar.CreatDe:
                    return "Creat de";
                case EnumDictionar.LaData:
                    return "La data";
                case EnumDictionar.NuConteaza:
                    return "Nu contează";
                case EnumDictionar.PanaIn:
                    return "Până în";
                case EnumDictionar.Intre:
                    return "Între";
                case EnumDictionar.pesteCaInterval:
                    return "Peste";
                case EnumDictionar.ImagineIdentitate:
                    return "Imagine identitate";
                case EnumDictionar.ContractIndividualDeMunca:
                    return "Contract individual de muncă";
                case EnumDictionar.ContractDeColaborare:
                    return "Contract de colaborare";
                case EnumDictionar.POS:
                    return "POS";
                case EnumDictionar.Cash:
                    return "Cash";
                case EnumDictionar.Banca:
                    return "Bancă";
                case EnumDictionar.CEC:
                    return "CEC";
                case EnumDictionar.Voucher:
                    return "Voucher";
                case EnumDictionar.Compensare:
                    return "Compensare";
                case EnumDictionar.Normal:
                    return "Normal";
                case EnumDictionar.Mediu:
                    return "Mediu";
                case EnumDictionar.Mare:
                    return "Mare";
                case EnumDictionar.Mic:
                    return "Mic";
                case EnumDictionar.FoarteMic:
                    return "Foarte mic";
                case EnumDictionar.Semestrul1:
                    return "Semestrul 1";
                case EnumDictionar.Semestrul2:
                    return "Semestrul 2";
                case EnumDictionar.Trimestrul1:
                    return "Trimestrul 1";
                case EnumDictionar.Trimestrul2:
                    return "Trimestrul 2";
                case EnumDictionar.Trimestrul3:
                    return "Trimestrul 3";
                case EnumDictionar.Trimestrul4:
                    return "Trimestrul 4";
                case EnumDictionar.Email:
                    return "Email";
                case EnumDictionar.TelefonFix:
                    return "Telefon fix";
                case EnumDictionar.TelefonMobil:
                    return "Mobil";
                case EnumDictionar.Perioada:
                    return "Perioadă";
                case EnumDictionar.PerioadaOrara:
                    return "Perioadă orară";
                case EnumDictionar.DataUnica:
                    return "Dată unică";
                case EnumDictionar.Confirmat:
                    return "Confirmat";
                case EnumDictionar.Infirmat:
                    return "Infirmat";
                case EnumDictionar.Nedeterminat:
                    return "Nedeterminat";
                case EnumDictionar.Oricand:
                    return "Oricând";
                case EnumDictionar.PanaLaOra:
                    return "Până la ora";
                case EnumDictionar.DupaOra:
                    return "După ora";
                case EnumDictionar.SaptamanaAceasta:
                    return "Săptămâna aceasta";
                case EnumDictionar.saptamanaViitoare:
                    return "Săptămâna viitoare";
                case EnumDictionar.LunaAceasta:
                    return "Luna aceasta";
                case EnumDictionar.LunaViitoare:
                    return "Luna viitoare";
                case EnumDictionar.LunaTrecuta:
                    return "Luna trecută";
                case EnumDictionar.Capricorn:
                    return "Capricorn";
                case EnumDictionar.Varsator:
                    return "Vărsător";
                case EnumDictionar.Pesti:
                    return "Pești";
                case EnumDictionar.Berbec:
                    return "Berbec";
                case EnumDictionar.Taur:
                    return "Taur";
                case EnumDictionar.Gemeni:
                    return "Gemeni";
                case EnumDictionar.Rac:
                    return "Rac";
                case EnumDictionar.Leu:
                    return "Leu";
                case EnumDictionar.Fecioara:
                    return "Fecioară";
                case EnumDictionar.Balanta:
                    return "Balanță";
                case EnumDictionar.Scorpion:
                    return "Scorpion";
                case EnumDictionar.Sagetator:
                    return "Săgetător";
                case EnumDictionar.captionDa:
                    return "Da";
                case EnumDictionar.captionNu:
                    return "Nu";
                case EnumDictionar.Decembrie:
                    return "Decembrie";
                case EnumDictionar.Noiembrie:
                    return "Noiembrie";
                case EnumDictionar.Octombrie:
                    return "Octombrie";
                case EnumDictionar.Septembrie:
                    return "Septembrie";
                case EnumDictionar.August:
                    return "August";
                case EnumDictionar.Iulie:
                    return "Iulie";
                case EnumDictionar.Iunie:
                    return "Iunie";
                case EnumDictionar.Mai:
                    return "Mai";
                case EnumDictionar.Aprilie:
                    return "Aprilie";
                case EnumDictionar.Martie:
                    return "Martie";
                case EnumDictionar.Februarie:
                    return "Februarie";
                case EnumDictionar.Ianuarie:
                    return "Ianuarie";
                case EnumDictionar.Casatorit:
                    return "Căsătorit";
                case EnumDictionar.Concubinaj:
                    return "Concubinaj";
                case EnumDictionar.Divortat:
                    return "Divorțat";
                case EnumDictionar.InCuplu:
                    return "În cuplu";
                case EnumDictionar.Necasatorit:
                    return "Necăsătorit";
                case EnumDictionar.StudiiSuperioare:
                    return "Studii superioare";
                case EnumDictionar.Superioare:
                    return "Superioare";
                case EnumDictionar.StudiiPostliceale:
                    return "Studii postliceale";
                case EnumDictionar.Postliceala:
                    return "Postliceală";
                case EnumDictionar.StudiiPostuniversitare:
                    return "Studii postuniversitare";
                case EnumDictionar.Postuniversitare:
                    return "Postuniversitare";
                case EnumDictionar.StudiiMediiLiceu:
                    return "Studii medii liceu";
                case EnumDictionar.Liceu:
                    return "Liceu";
                case EnumDictionar.StudiiElementare:
                    return "Studii elementare";
                case EnumDictionar.PrescurtareStudiiElementare:
                    return "Stud. elem.";
                case EnumDictionar.Profesionala:
                    return "Profesională";
                case EnumDictionar.Dna:
                    return "Dna.";
                case EnumDictionar.Doamna:
                    return "Doamna";
                case EnumDictionar.Dr:
                    return "Dr.";
                case EnumDictionar.Doctor:
                    return "Doctor";
                case EnumDictionar.Dl:
                    return "Dl.";
                case EnumDictionar.Domnul:
                    return "Domnul";
                case EnumDictionar.Dsoara:
                    return "Dșoara.";
                case EnumDictionar.Domnisoara:
                    return "Domnișoara";
                case EnumDictionar.Pr:
                    return "Pr.";
                case EnumDictionar.Profesor:
                    return "Profesor";
                case EnumDictionar.ProfDr:
                    return "Prof. Dr.";
                case EnumDictionar.ProfesorDoctor:
                    return "Profesor Doctor";
                case EnumDictionar.As:
                    return "As.";
                case EnumDictionar.Asistent:
                    return "Asistent";
                case EnumDictionar.captionMasculin:
                    return "M";
                case EnumDictionar.captionFeminin:
                    return "F";
                case EnumDictionar.captionNedefinit:
                    return "Nedefinit";
                case EnumDictionar.Conectare:
                    return "Conectare";
                case EnumDictionar.ContUtilizator:
                    return "Cont utilizator";
                case EnumDictionar.Parola:
                    return "Parola";
                case EnumDictionar.PastreazaMaConectat:
                    return "Păstrează-mă conectat";
                case EnumDictionar.iStoma:
                    return "iStoma";
                case EnumDictionar.TablouDeBord:
                    return "Tablou de bord";
                case EnumDictionar.Rapoarte:
                    return "Rapoarte";
                case EnumDictionar.Setari:
                    return "Setări";
                case EnumDictionar.ListaDePreturi:
                    return "Listă de prețuri";
                case EnumDictionar.Locatii:
                    return "Locații";
                case EnumDictionar.Personal:
                    return "Personal";
                case EnumDictionar.Diverse:
                    return "Diverse";
                case EnumDictionar.Nume:
                    return "Nume";
                case EnumDictionar.Prenume:
                    return "Prenume";
                case EnumDictionar.CNP:
                    return "CNP";
                case EnumDictionar.DataNasterii:
                    return "Data nașterii";
                case EnumDictionar.Clienti:
                    return "Clienți";
                case EnumDictionar.CodFiscal:
                    return "Cod fiscal";
                case EnumDictionar.NrInregistrare:
                    return "Nr înregistrare";
                case EnumDictionar.ConfirmatiStergerea:
                    return "Confirmați ștergerea?";
                case EnumDictionar.Denumire:
                    return "Denumire";
                case EnumDictionar.DenumireFiscala:
                    return "Denumire fiscală";
                case EnumDictionar.CUI:
                    return "CUI";
                case EnumDictionar.RegistrulComertului:
                    return "Reg. Com.";
                case EnumDictionar.PaginaWeb:
                    return "Pagină web";
                case EnumDictionar.Fax:
                    return "Fax";
                case EnumDictionar.Skype:
                    return "Skype";
                case EnumDictionar.Observatii:
                    return "Observații";
                case EnumDictionar.Prescurtare:
                    return "Prescurtare";
                case EnumDictionar.Cod:
                    return "Cod";
                case EnumDictionar.Categorie:
                    return "Categorie";
                case EnumDictionar.Valoare:
                    return "Valoare";
                case EnumDictionar.RON:
                    return "RON";
                case EnumDictionar.EUR:
                    return "EUR";
                case EnumDictionar.TermenMediu:
                    return "Termen mediu";
                case EnumDictionar.Zile:
                    return "Zile";
                case EnumDictionar.Liste:
                    return "Liste";
                case EnumDictionar.InformatiiGenerale:
                    return "Informații generale";
                case EnumDictionar.Initiala:
                    return "Inițială";
                case EnumDictionar.Tip:
                    return "Tip";
                case EnumDictionar.Locatie:
                    return "Locație";
                case EnumDictionar.Culoare:
                    return "Culoare";
                case EnumDictionar.InfoContact:
                    return "Informații contact";
                case EnumDictionar.ContYM:
                    return "Cont YM";
                case EnumDictionar.InformatiiFiscale:
                    return "Informații fiscale";
                case EnumDictionar.Logo:
                    return "Logo";
                case EnumDictionar.DimensiuneLogo:
                    return "90 x 90";
                case EnumDictionar.CMI:
                    return "CMI";
                case EnumDictionar.SRL:
                    return "SRL";
                case EnumDictionar.TVA:
                    return "TVA";
                case EnumDictionar.IBAN:
                    return "IBAN";
                case EnumDictionar.ReprezentantLegal:
                    return "Reprezentant legal";
                case EnumDictionar.Calitate:
                    return "Calitate";
                case EnumDictionar.SerieChitante:
                    return "Serie chitanțe";
                case EnumDictionar.NrUltimaChitanta:
                    return "Nr. ultima chitanță";
                case EnumDictionar.SerieFacturi:
                    return "Serie facturi";
                case EnumDictionar.NrUltimaFactura:
                    return "Nr. ultima factură";
                case EnumDictionar.Supranume:
                    return "Supranume";
                case EnumDictionar.NumeDeFata:
                    return "Nume de fată";
                case EnumDictionar.Sex:
                    return "Sex";
                case EnumDictionar.StareCivila:
                    return "Stare civilă";
                case EnumDictionar.NrCopii:
                    return "Nr. copii";
                case EnumDictionar.Serie:
                    return "Serie";
                case EnumDictionar.Numar:
                    return "Număr";
                case EnumDictionar.Educatie:
                    return "Educație";
                case EnumDictionar.Scoala:
                    return "Școală";
                case EnumDictionar.Profesie:
                    return "Profesie";
                case EnumDictionar.Nationalitate:
                    return "Naționalitate";
                case EnumDictionar.Tara:
                    return "Țară";
                case EnumDictionar.Judet:
                    return "Județ";
                case EnumDictionar.Localitate:
                    return "Localitate";
                case EnumDictionar.Rol:
                    return "Rol";
                case EnumDictionar.DataAngajare:
                    return "Dată angajare";
                case EnumDictionar.Cont:
                    return "Cont";
                case EnumDictionar.Profesii:
                    return "Profesii";
                case EnumDictionar.Tari:
                    return "Țări";
                case EnumDictionar.Localitati:
                    return "Localități";
                case EnumDictionar.Regiuni:
                    return "Regiuni";
                case EnumDictionar.Total:
                    return "Total";
                case EnumDictionar.CodCOR:
                    return "Cod COR";
                case EnumDictionar.Abreviere:
                    return "Abreviere";
                case EnumDictionar.PrefixTelefonic:
                    return "Prefix telefonic";
                case EnumDictionar.Regiune:
                    return "Regiune";
                case EnumDictionar.NumeOficial:
                    return "Nume oficial";
                case EnumDictionar.Cetatenie:
                    return "Cetățenie";
                case EnumDictionar.Limba:
                    return "Limba";
                case EnumDictionar.Date:
                    return "Date";
                case EnumDictionar.Reprezentanti:
                    return "Reprezentanți";
                case EnumDictionar.Comenzi:
                    return "Comenzi";
                case EnumDictionar.Plati:
                    return "Plăți";
                case EnumDictionar.MeniuStanga:
                    return "Meniu stânga";
                case EnumDictionar.Pauza:
                    return "Pauză";
                case EnumDictionar.Deconectare:
                    return "Deconectare";
                case EnumDictionar.Iesire:
                    return "Ieșire";
                case EnumDictionar.Inchidere:
                    return "Închidere";
                case EnumDictionar.ConfirmareInchidere:
                    return "Confirmați închiderea aplicației ?";
                case EnumDictionar.Secunde:
                    return " secunde";
                case EnumDictionar.Client:
                    return "Client";
                case EnumDictionar.Lucrari:
                    return "Lucrări";
                case EnumDictionar.ElementeGasite:
                    return " elemente găsite";
                case EnumDictionar.xElementeGasite:
                    return "{0} elemente găsite";
                case EnumDictionar.ElementGasit:
                    return " element găsit";
                case EnumDictionar.unElementGasit:
                    return "Un element găsit";
                case EnumDictionar.Sediu:
                    return "Sediu";
                case EnumDictionar.ExceptieDenumireClient:
                    return "Denumirea clientului este obligatorie!";
                case EnumDictionar.Inbox:
                    return "Inbox";
                case EnumDictionar.Comunicare:
                    return "Comunicare";
                case EnumDictionar.Sender:
                    return "Sender";
                case EnumDictionar.Subiect:
                    return "Subiect";
                case EnumDictionar.Data:
                    return "Data";
                case EnumDictionar.DeLa:
                    return "De la";
                case EnumDictionar.Pentru:
                    return "Pentru";
                case EnumDictionar.Facturi:
                    return "Facturi";
                case EnumDictionar.Incasari:
                    return "Încasări";
                case EnumDictionar.Reprezentant:
                    return "Reprezentant";
                case EnumDictionar.Pacient:
                    return "Pacient";
                case EnumDictionar.DataPrimire:
                    return "Dată primire";
                case EnumDictionar.DataLaGata:
                    return "Dată la gata";
                case EnumDictionar.SMTP:
                    return "SMTP";
                case EnumDictionar.Port:
                    return "Port";
                case EnumDictionar.IMAP:
                    return "Imap";
                case EnumDictionar.User:
                    return "User";
                case EnumDictionar.SSL:
                    return "SSL";
                case EnumDictionar.Lucrare:
                    return "Lucrare";
                case EnumDictionar.Pret:
                    return "Preț";
                case EnumDictionar.Moneda:
                    return "Monedă";
                case EnumDictionar.ListaPreturi:
                    return "Listă prețuri";
                case EnumDictionar.PretStandard:
                    return "Preț standard";
                case EnumDictionar.PretClient:
                    return "Preț client";
                case EnumDictionar.Categorii:
                    return "Categorii";
                case EnumDictionar.Subcategorie:
                    return "Subcategorie";
                case EnumDictionar.Durata:
                    return "Durată";
                case EnumDictionar.Minute:
                    return "minute";
                case EnumDictionar.Etape:
                    return "Etape";
                case EnumDictionar.Financiar:
                    return "Financiar";
                case EnumDictionar.Concedii:
                    return "Concedii";
                case EnumDictionar.Pontaj:
                    return "Pontaj";
                case EnumDictionar.Administrativ:
                    return "Administrativ";
                case EnumDictionar.Manager:
                    return "Manager";
                case EnumDictionar.PersonalTehnic:
                    return "Personal tehnic";
                case EnumDictionar.Tehnician:
                    return "Tehnician";
                case EnumDictionar.Utilizator:
                    return "Utilizator";
                case EnumDictionar.Astazi:
                    return "Astăzi";
                case EnumDictionar.CheckIn:
                    return "Check in";
                case EnumDictionar.CheckOut:
                    return "Check out";
                case EnumDictionar.Deplasare:
                    return "Deplasare în interes de serviciu";
                case EnumDictionar.FinalPauza:
                    return "Final pauză";
                case EnumDictionar.RevenireInClinica:
                    return "Revenire în clinică";
                case EnumDictionar.Strada:
                    return "Stradă";
                case EnumDictionar.Nr:
                    return "Nr";
                case EnumDictionar.Interfon:
                    return "Interfon";
                case EnumDictionar.Bloc:
                    return "Bloc";
                case EnumDictionar.Scara:
                    return "Scară";
                case EnumDictionar.Etaj:
                    return "Etaj";
                case EnumDictionar.Ap:
                    return "Ap";
                case EnumDictionar.CP:
                    return "CP";
                case EnumDictionar.ZileNelucratoare:
                    return "Zile nelucrătoare";
                case EnumDictionar.Detalii:
                    return "Detalii";
                case EnumDictionar.Rezumat:
                    return "Rezumat";
                case EnumDictionar.DeLaData:
                    return "de la";
                case EnumDictionar.PanaLaData:
                    return "până la";
                case EnumDictionar.Schimba:
                    return "Schimbă";
                case EnumDictionar.AnulAcesta:
                    return "Anul acesta";
                case EnumDictionar.AnulTrecut:
                    return "Anul trecut";
                case EnumDictionar.AnulViitor:
                    return "Anul viitor";
                case EnumDictionar.SaptamanaTrecuta:
                    return "Săptămâna trecută";
                case EnumDictionar.DataInceput:
                    return "Dată început";
                case EnumDictionar.DataSfarsit:
                    return "Dată sfârșit";
                case EnumDictionar.InformareSelectareUtilizator:
                    return "Selectați un utilizator";
                case EnumDictionar.Adresa:
                    return "Adresă";
                case EnumDictionar.DataCreare:
                    return "Dată creare";
                case EnumDictionar.MotivulInchiderii:
                    return "Motivul închiderii";
                case EnumDictionar.Acum:
                    return "Acum";
                case EnumDictionar.Reactivare:
                    return "Reactivare";
                case EnumDictionar.Principala:
                    return "Principală";
                case EnumDictionar.Secundara:
                    return "Secundară";
                case EnumDictionar.DeVacanta:
                    return "De vacanță";
                case EnumDictionar.DeFacturare:
                    return "De facturare";
                case EnumDictionar.SediuSocial:
                    return "Sediu social";
                case EnumDictionar.Selecteaza:
                    return "Selectează";
                case EnumDictionar.ApartamentPrescurtat:
                    return "Ap";
                case EnumDictionar.BlocPrescurtat:
                    return "Bl";
                case EnumDictionar.DataVerificare:
                    return "Dată verificare";
                case EnumDictionar.EtajPrescurtat:
                    return "Et";
                case EnumDictionar.NumarPrescurtat:
                    return "Nr";
                case EnumDictionar.ScaraPrescurtat:
                    return "Sc";
                case EnumDictionar.TelefonFixPrescurtat:
                    return "Tel fix";
                case EnumDictionar.Actuala:
                    return "Actuală";
                case EnumDictionar.mesajConfirmareInchidereX:
                    return "Mesaj confirmare";
                case EnumDictionar.mesajConfirmareReactivareX:
                    return "Mesaj reactivare";
                case EnumDictionar.Neprecizat:
                    return "Neprecizat";
                case EnumDictionar.TipulAdreseiEsteObligatoriu:
                    return "Tipul adresei este obligatoriu";
                case EnumDictionar.Eroare:
                    return "Eroare";
                case EnumDictionar.Recomandant:
                    return "Recomandant";
                case EnumDictionar.AltePersoane:
                    return "Alte persoane";
                case EnumDictionar.PFA:
                    return "PFA";
                case EnumDictionar.II:
                    return "II";
                case EnumDictionar.AdaugaSubcategorie:
                    return "Adaugă subcategorie";
                case EnumDictionar.InfoIntroducereEmail:
                    return "Pentru validarea datelor veți primi automat un email de test";
                case EnumDictionar.ComenziInLucru:
                    return "Comenzi în lucru";
                case EnumDictionar.TipContract:
                    return "Tip contract";
                case EnumDictionar.NrOreNorma:
                    return "Nr. ore normă";
                case EnumDictionar.DataContract:
                    return "Dată contract";
                case EnumDictionar.DataIncetareContract:
                    return "Dată incetare contract";
                case EnumDictionar.NrContract:
                    return "Nr. contract";
                case EnumDictionar.SMTPPunct:
                    return "smtp.";
                case EnumDictionar.ImapPunct:
                    return "imap.";
                case EnumDictionar.Cabinete:
                    return "Cabinete";
                case EnumDictionar.Cabinet:
                    return "Cabinet";
                case EnumDictionar.UltimaComanda:
                    return "Ultima comandă";
                case EnumDictionar.TotalComenzi:
                    return "Total comenzi";
                case EnumDictionar.AdaugaEtapa:
                    return "Adaugă etapă";
                case EnumDictionar.Spatiu:
                    return " ";
                case EnumDictionar.ModificaTehnician:
                    return "Modifică tehnician";
                case EnumDictionar.InformareSelectareLinie:
                    return "Cel puțin o linie trebuie selectată";
                case EnumDictionar.InformatiiIncomplete:
                    return "Informațiile introduse în tabel sunt incomplete ";
                case EnumDictionar.Value:
                    return "Value";
                case EnumDictionar.Key:
                    return "Key";
                case EnumDictionar.DurataMinute:
                    return "Durată (minute)";
                case EnumDictionar.Drafts:
                    return "Drafts";
                case EnumDictionar.Sent:
                    return "Sent";
                case EnumDictionar.Trash:
                    return "Trash";
                case EnumDictionar.ServerSMTP:
                    return "Server SMTP";
                case EnumDictionar.PortSMTP:
                    return "Port SMTP";
                case EnumDictionar.ServerIMAP:
                    return "Server IMAP";
                case EnumDictionar.PortIMAP:
                    return "Port IMAP";
                case EnumDictionar.AdresaEmail:
                    return "Adresă mail";
                case EnumDictionar.Banci:
                    return "Bănci";
                case EnumDictionar.InformatiiSuplimentare:
                    return "Informații suplimentare";
                case EnumDictionar.ConfirmatiInchidereaBancii:
                    return "Confirmați închiderea băncii ";
                case EnumDictionar.BI:
                    return "B.I.";
                case EnumDictionar.CI:
                    return "C.I.";
                case EnumDictionar.Telefon:
                    return "Telefon";
                case EnumDictionar.EmisDe:
                    return "Emis de";
                case EnumDictionar.Valabilitate:
                    return "Valabilitate";
                case EnumDictionar.SeConecteaza:
                    return "Se conectează";
                case EnumDictionar.OreNorma:
                    return "Ore normă";
                case EnumDictionar.ZileConcediu:
                    return "Zile concediu";
                case EnumDictionar.ConfirmatiReactivarea:
                    return "Confirmați reactivarea?";
                case EnumDictionar.Medici:
                    return "Medici";
                case EnumDictionar.Medic:
                    return "Medic";
                case EnumDictionar.Adauga:
                    return "Adaugă";
                case EnumDictionar.AdaugaClinica:
                    return "Adaugă clinică";
                case EnumDictionar.AdaugaComanda:
                    return "Adaugă comandă";
                case EnumDictionar.AdaugaMedic:
                    return "Adaugă medic";
                case EnumDictionar.Clinica:
                    return "Clinică";
                case EnumDictionar.Importa:
                    return "Importă";
                case EnumDictionar.Imagine:
                    return "Imagine";
                case EnumDictionar.Documente:
                    return "Documente";
                case EnumDictionar.MaterialVideo:
                    return "Material video";
                case EnumDictionar.MaterialAudio:
                    return "Material audio";
                case EnumDictionar.Document:
                    return "Document";
                case EnumDictionar.Urgent:
                    return "Urgent";
                case EnumDictionar.NrElemente:
                    return "Nr elemente";
                case EnumDictionar.SelectatiOLucrareDinLista:
                    return "Selectați o lucrare din listă!";
                case EnumDictionar.Toate:
                    return "Toate";
                case EnumDictionar.Clinici:
                    return "Clinici";
                case EnumDictionar.EtapaCurenta:
                    return "Etapă curentă";
                case EnumDictionar.zile:
                    return "zile";
                case EnumDictionar.ImportPersonal:
                    return "Import personal";
                case EnumDictionar.Etapa:
                    return "Etapă";
                case EnumDictionar.PreturiStandard:
                    return "Prețuri standard";
                case EnumDictionar.PreturiClinici:
                    return "Prețuri clinici";
                case EnumDictionar.UltimaLucrare:
                    return "Ultima lucrare";
                case EnumDictionar.TotalLucrari:
                    return "Total lucrări";
                case EnumDictionar.lucrari:
                    return " lucrări";
                case EnumDictionar.Website:
                    return "Website";
                case EnumDictionar.RegCom:
                    return "Reg. com.";
                case EnumDictionar.InCalitateDe:
                    return "În calitate de";
                case EnumDictionar.Administrator:
                    return "Administrator";
                case EnumDictionar.MedicTitular:
                    return "Medic titular";
                case EnumDictionar.DateClinica:
                    return "Date clinică";
                case EnumDictionar.TotalMedici:
                    return "Total medici:";
                case EnumDictionar.PretClinica:
                    return "Preț clinică";
                case EnumDictionar.NumeMedic:
                    return "Nume medic";
                case EnumDictionar.PrenumeMedic:
                    return "Prenume medic";
                case EnumDictionar.DenFisc:
                    return "Den. fisc.";
                case EnumDictionar.Repr:
                    return "Repr.";
                case EnumDictionar.NrContr:
                    return "Nr. contr.";
                case EnumDictionar.DataContr:
                    return "Dată contr.";
                case EnumDictionar.Facturare:
                    return "Facturare";
                case EnumDictionar.Factura:
                    return "Factură";
                case EnumDictionar.ValabilitateAct:
                    return "Valabilitate Act";
                case EnumDictionar.BineAtiVenit:
                    return "Bine ați venit ";
                case EnumDictionar.admin:
                    return "admin";
                case EnumDictionar.IstomaLTD:
                    return "iStoma LTD";
                case EnumDictionar.Trecute:
                    return "Trecute";
                case EnumDictionar.InLucru:
                    return "În lucru";
                case EnumDictionar.MesajEroareDataTermen:
                    return "Termenul etapei nu poate fi mai mic decât data primire!";
                case EnumDictionar.ImportDate:
                    return "Import date";
                case EnumDictionar.DataFinal:
                    return "Dată final";
                case EnumDictionar.SelectatiTehnicianul:
                    return "Selectați tehnicianul";
                case EnumDictionar.Unu:
                    return "1";
                case EnumDictionar.ComenziTrecute:
                    return "Comenzi trecute";
                case EnumDictionar.DataTermen:
                    return "Dată termen";
                case EnumDictionar.Termen:
                    return "Termen";
                case EnumDictionar.SelectatiCelPutinOLucrareDinLista:
                    return "Selectați cel puțin o lucrare din listă";
                case EnumDictionar.SchimbaEtapa:
                    return "Schimbă etapa";
                case EnumDictionar.NrElem:
                    return "Nr. elem.";
                case EnumDictionar.Refacere:
                    return "Refacere";
                case EnumDictionar.Finalizata:
                    return "Finalizată";
                case EnumDictionar.Livrata:
                    return "Livrată";
                case EnumDictionar.Stare:
                    return "Stare";
                case EnumDictionar.VeziToateEtapele:
                    return "Vezi toate etapele";
                case EnumDictionar.ObsEtapa:
                    return "Obs. etapă";
                case EnumDictionar.ObsLucrare:
                    return "Obs. lucrare";
                case EnumDictionar.X:
                    return "X";
                case EnumDictionar.Achita:
                    return "Achită";
                case EnumDictionar.LucrariNefacturate:
                    return "Lucrări nefacturate";
                case EnumDictionar.FacturiEmise:
                    return "Facturi emise";
                case EnumDictionar.Acceptata:
                    return "Acceptată";
                case EnumDictionar.PretNegociat:
                    return "Preț negociat";
                case EnumDictionar.Titlu:
                    return "Titlu";
                case EnumDictionar.CentrareInPagina:
                    return "Centrare în pagină";
                case EnumDictionar.AfiseazaNumarulPaginii:
                    return "Afișează numărul paginii";
                case EnumDictionar.PeFiecarePagina:
                    return "Pe fiecare pagină";
                case EnumDictionar.Deselecteaza:
                    return "Deselectează";
                case EnumDictionar.Clasic:
                    return "Clasic";
                case EnumDictionar.FolosesteLogo:
                    return "Folosește logo";
                case EnumDictionar.Imprimare:
                    return "Imprimare";
                case EnumDictionar.Coloane:
                    return "Coloane";
                case EnumDictionar.Separator:
                    return "Separator";
                case EnumDictionar.Goleste:
                    return "Golește";
                case EnumDictionar.SelectatiCelPutinClinicaSiLucrarea:
                    return "Selectați cel puțin clinica și lucrarea";
                case EnumDictionar.Factureaza:
                    return "Facturează";
                case EnumDictionar.SelectatiClinica:
                    return "Selectați clinica";
                case EnumDictionar.SelectatiLucrarile:
                    return "Selectați lucrările";
                case EnumDictionar.Curs:
                    return "Curs";
                case EnumDictionar.SerieNr:
                    return "Serie-Nr";
                case EnumDictionar.Proforma:
                    return "Proformă";
                case EnumDictionar.PretUnitar:
                    return "Preț unitar";
                case EnumDictionar.DataEmiterii:
                    return "Data emiterii";
                case EnumDictionar.Platit:
                    return "Plătit";
                case EnumDictionar.Incasare:
                    return "Încasare";
                case EnumDictionar.Suma:
                    return "Sumă";
                case EnumDictionar.Modalitate:
                    return "Modalitate";
                case EnumDictionar.Sold:
                    return "Sold";
            }

            return string.Empty;
        }

        internal static void DistrugeObiecteleStatice()
        {
            //throw new NotImplementedException();
        }
    }
}
