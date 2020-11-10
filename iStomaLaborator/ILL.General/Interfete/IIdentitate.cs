using System;
using CDL.iStomaLab;
using System.Data;
using static CDL.iStomaLab.CDefinitiiComune;
using ILL.iStomaLab;

namespace ILL.BLL.General
{
    public struct StructIdentitate
    {
        public string CNP { get; set; }
        public CDefinitiiComune.EnumNivelScolorizare Educatie { get; set; }
        public int NumarCopii { get; set; }
        public string Nume { get; set; }
        public string NumeDeFata { get; set; }
        public string Porecla { get; set; }
        public string Prenume { get; set; }
        public int Profesie { get; set; }
        public string DenumireProfesie { get; set; }
        public int Ocupatie { get; set; }
        public string DenumireOcupatie { get; set; }
        public string Scoala { get; set; }
        public CDefinitiiComune.EnumSex Sex { get; set; }
        public CDefinitiiComune.EnumStareCivila StareCivila { get; set; }
        public CDefinitiiComune.EnumTitulatura Titulatura { get; set; }
        private bool lEsteInitializat;
        public CDefinitiiComune.EnumTipObiect TipRecomandant { get; set; }
        public int IdRecomandant { get; set; }

        public string Telefon { get; set; }
        public string Email { get; private set; }
        public DateTime DataDeNastere { get; set; }

        public EnumTipActIdentitate TipActIdentitate { get; set; }
        public string SerieActIdentitate { get; set; }
        public string NumarActIdentitate { get; set; }
        public Tuple<string, string> ActIdentitate { get; set; }

        public static StructIdentitate Empty { get { return new StructIdentitate(true); } }

        public int Origine { get; set; }
        public int IdMedicApartinator { get; set; }
        public int IdSimptom { get; set; }
        public IAfisaj Recomandant { get; set; }

        public StructIdentitate(string pCNP, string pNume, string pPrenume) : this()
        {
            this.CNP = pCNP;
            this.Nume = pNume;
            this.Prenume = pPrenume;
            this.lEsteInitializat = true;
            this.DataDeNastere = CConstante.DataNula;
        }

        public StructIdentitate(string pCNP, string pNume, string pPrenume, string pTelefon, string pAdresaEmail, DateTime pDataDeNastere, CDefinitiiComune.EnumTipObiect pTipRecomandant, int pIdRecomandant)
            : this(pCNP, pNume, pPrenume, pTelefon, pAdresaEmail, pDataDeNastere, pTipRecomandant, pIdRecomandant, 0, 0, 0)
        {
        }

        public StructIdentitate(string pCNP, string pNume, string pPrenume, string pTelefon, string pAdresaEmail, DateTime pDataDeNastere, CDefinitiiComune.EnumTipObiect pTipRecomandant, int pIdRecomandant, int pOrigine, int pIdMedicApartinator, IAfisaj pRecomandant, int pIdSimptom)
            : this()
        {
            this.CNP = pCNP;
            this.Nume = pNume;
            this.Prenume = pPrenume;
            this.Telefon = pTelefon;
            this.Email = pAdresaEmail;
            this.DataDeNastere = pDataDeNastere;
            this.TipRecomandant = pTipRecomandant;
            this.IdRecomandant = pIdRecomandant;
            this.Origine = pOrigine;
            this.IdMedicApartinator = pIdMedicApartinator;
            this.Recomandant = pRecomandant;
            this.IdSimptom = pIdSimptom;

            this.lEsteInitializat = true;
        }

        public StructIdentitate(string pCNP, string pNume, string pPrenume, string pTelefon, string pAdresaEmail, DateTime pDataDeNastere, CDefinitiiComune.EnumTipObiect pTipRecomandant, int pIdRecomandant, int pOrigine, int pIdMedicApartinator, int pIdSimptom)
            : this()
        {
            this.CNP = pCNP;
            this.Nume = pNume;
            this.Prenume = pPrenume;
            this.Telefon = pTelefon;
            this.Email = pAdresaEmail;
            this.DataDeNastere = pDataDeNastere;
            this.TipRecomandant = pTipRecomandant;
            this.IdRecomandant = pIdRecomandant;
            this.Origine = pOrigine;
            this.IdMedicApartinator = pIdMedicApartinator;
            this.IdSimptom = pIdSimptom;

            this.lEsteInitializat = true;
        }

        public StructIdentitate(string pCNP, CDefinitiiComune.EnumNivelScolorizare pEducatie, int pNumarCopii,
            string pNume, string pNumeDeFata, string pPorecla, string pPrenume, int pProfesie, int pOcupatie,
            string pScoala, CDefinitiiComune.EnumSex pSex, CDefinitiiComune.EnumStareCivila pStareCivila,
            CDefinitiiComune.EnumTitulatura pTitulatura, EnumTipActIdentitate pTipActIdentitate,
            string pSerieActIdentitate, string pNumarActIdentitate)
            : this()
        {
            this.CNP = pCNP;
            this.Educatie = pEducatie;
            this.NumarCopii = pNumarCopii;
            this.Nume = pNume;
            this.NumeDeFata = pNumeDeFata;
            this.Porecla = pPorecla;
            this.Prenume = pPrenume;
            this.Profesie = pProfesie;
            this.Ocupatie = pOcupatie;
            this.Scoala = pScoala;
            this.Sex = pSex;
            this.StareCivila = pStareCivila;
            this.Titulatura = pTitulatura;
            this.TipActIdentitate = pTipActIdentitate;
            this.NumarActIdentitate = pNumarActIdentitate;
            this.SerieActIdentitate = pSerieActIdentitate;
            this.lEsteInitializat = true;
            this.DataDeNastere = CConstante.DataNula;
            this.TipRecomandant = CDefinitiiComune.EnumTipObiect.Nedefinit;
            this.IdRecomandant = 0;
        }

        public StructIdentitate(bool pOficiu)
            : this()
        {
            this.Educatie = CDefinitiiComune.EnumNivelScolorizare.Nedefinit;
            this.Sex = CDefinitiiComune.EnumSex.Nedefinit;
            this.StareCivila = CDefinitiiComune.EnumStareCivila.Nespecificat;
            this.Titulatura = CDefinitiiComune.EnumTitulatura.Nedefinit;
            this.NumarCopii = -1; //Nu presupunem nimic
            this.DataDeNastere = CConstante.DataNula;
            this.TipRecomandant = CDefinitiiComune.EnumTipObiect.Nedefinit;
            this.IdRecomandant = 0;
            this.lEsteInitializat = false;
        }

        public bool AreValoare()
        {
            return this.lEsteInitializat;
        }

        public void TransferaLa(IIdentitate pIdentitateDestinatie)
        {
            pIdentitateDestinatie.CNP = this.CNP;
            pIdentitateDestinatie.Educatie = this.Educatie;
            pIdentitateDestinatie.NumarCopii = this.NumarCopii;
            pIdentitateDestinatie.Nume = this.Nume;
            pIdentitateDestinatie.NumeDeFata = this.NumeDeFata;
            pIdentitateDestinatie.Porecla = this.Porecla;
            pIdentitateDestinatie.Prenume = this.Prenume;
            pIdentitateDestinatie.Profesie = this.Profesie;
            pIdentitateDestinatie.Ocupatie = this.Ocupatie;
            pIdentitateDestinatie.Scoala = this.Scoala;
            pIdentitateDestinatie.Sex = this.Sex;
            pIdentitateDestinatie.StareCivila = this.StareCivila;
            pIdentitateDestinatie.Titulatura = this.Titulatura;
            pIdentitateDestinatie.TipActIdentitate = this.TipActIdentitate;
            pIdentitateDestinatie.NumarActIdentitate = this.NumarActIdentitate;
            pIdentitateDestinatie.SerieActIdentitate = this.SerieActIdentitate;
            pIdentitateDestinatie.ActIdentitate = this.ActIdentitate;
        }

        public override string ToString()
        {
            string Rezultat = string.Empty;
            Rezultat = this.Nume;
            if (!string.IsNullOrEmpty(this.NumeDeFata))
                Rezultat += " [" + this.NumeDeFata + "]";

            Rezultat += " " + this.Prenume;

            if (!string.IsNullOrEmpty(this.Porecla))
                Rezultat += " (" + this.Porecla + ")";

            //NU FACE SENS
            //if (!string.IsNullOrEmpty(this.CNP))
            //    Rezultat += string.Format(" = CNP: {0} =", this.CNP);

            return Rezultat;
        }
    }

    public interface IIdentitate : IProprietar, ICheie
    {
        string CNP { get; set; }
        CDefinitiiComune.EnumNivelScolorizare Educatie { get; set; }
        int NumarCopii { get; set; }
        string Nume { get; set; }
        string NumeDeFata { get; set; }
        string Porecla { get; set; }
        string Prenume { get; set; }
        int Profesie { get; set; }
        string DenumireProfesie { get; }
        int Ocupatie { get; set; }
        string DenumireOcupatie { get; }
        string Scoala { get; set; }
        CDefinitiiComune.EnumSex Sex { get; set; }
        CDefinitiiComune.EnumStareCivila StareCivila { get; set; }
        CDefinitiiComune.EnumTitulatura Titulatura { get; set; }
        bool UpdateAll(IDbTransaction pTranzactie);
        bool SeGestioneazaNumarulCopiilor();
        EnumTipActIdentitate TipActIdentitate { get; set; }
        string SerieActIdentitate { get; set; }
        string NumarActIdentitate { get; set; }
        Tuple<string, string> ActIdentitate { get; set; }
        IAfisaj GetAdresa(System.Data.IDbTransaction pTranzactie);
    }
}
