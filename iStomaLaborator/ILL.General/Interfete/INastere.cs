using System;
using System.Data;
using CDL.iStomaLab;
namespace ILL.BLL.General
{

    public struct StructNastere
    {
        public DateTime DataNastere { get; set; }
        public DateTime DataDeces { get; set; }
        public int JudetNastere { get; set; }
        public int LocalitateNastere { get; set; }
        public int Nationalitate { get; set; }
        public int TaraNastere { get; set; }
        private bool lEsteInitializat;

        public static StructNastere Empty { get { return new StructNastere(true); } }

        public StructNastere(bool pOficiu)
            : this()
        {
            DataNastere = CConstante.DataNula;
            DataDeces = CConstante.DataNula;
            this.lEsteInitializat = false;
        }

        public bool AreValoare()
        {
            return this.lEsteInitializat;
        }

        public void TransferaLa(INastere pNastereDestinatie)
        {
            pNastereDestinatie.DataNastere = this.DataNastere;
            pNastereDestinatie.DataDeces = this.DataDeces;
            pNastereDestinatie.JudetNastere = this.JudetNastere;
            pNastereDestinatie.LocalitateNastere = this.LocalitateNastere;
            pNastereDestinatie.Nationalitate = this.Nationalitate;
            pNastereDestinatie.TaraNastere = this.TaraNastere;
        }
    }

    public interface INastere
    {
        DateTime DataNastere { get; set; }
        DateTime DataDeces { get; set; }
        int JudetNastere { get; set; }
        int LocalitateNastere { get; set; }
        int Nationalitate { get; set; }
        int TaraNastere { get; set; }
        bool UpdateAll(IDbTransaction pTranzactie);
        bool SeGestioneazaDecesul();
    }
}
