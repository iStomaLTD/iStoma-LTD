using CDL.iStomaLab;
using ILL.General.Interfete;

namespace ILL.BLL.General
{
    /// <summary>
    /// In modul creare controlul comunicare nu are un obiect pe care sa faca update
    /// Vom folosi in schimb aceasta structura
    /// </summary>
    public struct StructContact
    {
        public string AdresaMail { get; set; }
        public string AdresaMailParola { get; set; }
        public string ContSkype { get; set; }
        public string ContYM { get; set; }
        public string InfoContact { get; set; }
        public string PaginaWeb { get; set; }
        public int ReteaTelefonieMobila { get; set; }
        public string TelefonMobil { get; set; }
        public string Fax { get; set; }
        public CDefinitiiComune.EnumModComunicarePreferat ModComunicarePreferat { get; set; }
        private bool lExista;

        public static StructContact Empty { get { return new StructContact(false); } }

        public StructContact(bool pExista)
            : this()
        {
            this.lExista = pExista;
        }

        public StructContact(string pAdresaMail, string pParolaMail, string pContSkype, string pContYM,
            string pInfoContact, string pPaginaWeb, int pReteaTelefonieMobila,
            string pTelefonMobil, string pFax, CDefinitiiComune.EnumModComunicarePreferat pModComunicarePreferat)
            : this(true)
        {
            this.AdresaMail = pAdresaMail;
            this.AdresaMailParola = pParolaMail;
            this.ContSkype = pContSkype;
            this.ContYM = pContYM;
            this.InfoContact = pInfoContact;
            this.PaginaWeb = pPaginaWeb;
            this.ReteaTelefonieMobila = pReteaTelefonieMobila;
            this.TelefonMobil = pTelefonMobil;
            this.Fax = pFax;
            this.ModComunicarePreferat = pModComunicarePreferat;
        }

        public void TransferaLa(IContact pContactDestinatie)
        {
            pContactDestinatie.AdresaMail = this.AdresaMail;
            if (pContactDestinatie.GestiuneParolaAdresaDeMail)
                pContactDestinatie.AdresaMailParola = this.AdresaMailParola;
            pContactDestinatie.ContSkype = this.ContSkype;
            pContactDestinatie.ContYM = this.ContYM;
            pContactDestinatie.InfoContact = this.InfoContact;
            pContactDestinatie.PaginaWeb = this.PaginaWeb;
            pContactDestinatie.ReteaTelefonieMobila = this.ReteaTelefonieMobila;
            pContactDestinatie.TelefonMobil = this.TelefonMobil;
            pContactDestinatie.Fax = this.Fax;
            pContactDestinatie.ModComunicarePreferat = this.ModComunicarePreferat;
        }

        public bool AreValoare()
        {
            return this.lExista;
        }
    }

    public interface IContact : IProprietarDocumente
    {
        bool PoateTrimiteMesaje { get; }
        string AdresaMail { get; set; }
        string AdresaMailCC { get; set; }
        string AdresaMailParola { get; set; }
        string ParolaAdresaMail { get; }
        bool GestiuneParolaAdresaDeMail { get; }
        string ContSkype { get; set; }
        string ContYM { get; set; }
        string InfoContact { get; set; }
        string PaginaWeb { get; set; }
        int ReteaTelefonieMobila { get; set; }
        string TelefonMobil { get; set; }
        string Fax { get; set; }
        CDefinitiiComune.EnumModComunicarePreferat ModComunicarePreferat { get; set; }
        string ModComunicarePreferatCaText { get; }
        bool UpdateAll(System.Data.IDbTransaction pTranzactie);
    }
}
