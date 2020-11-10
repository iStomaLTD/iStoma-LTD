using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILL.iStomaLab
{
    public interface IComunicareIHM
    {
        System.Drawing.Point GetLocation();
        System.Drawing.Size GetSize();

        //string getMesajParametrabil();
        void ImprimaDGV(object pDGV);
        void ExportaDGV(object pDGV);
        void TrimiteDGVPeEmail(object pDGV);
        //bool GestioneazaColoaneLista(object pDGV);
        //bool RevenireLaAfisajulStandard(int pIdLista);
        void SeteazaColoanaSortare(string pNumeLista, string pNumeColoana, int pOrdineSortare);
        void SeteazaIndexColoana(string pNumeLista, string pNumeColoana, int pDisplayIndex);
        void SeteazaLatimeColoana(string pNumeLista, string pNumeColoana, int pLatime);
        //List<string> GetListaColoaneAscunde(string pNumeLista);
        Tuple<string, int, int> GetColoanaSortare(string pNumeLista);
        Dictionary<string, int> GetOrdineAfisareColoane(string pNumeLista);
        Dictionary<string, int> GetLatimeColoane(string pNumeLista);
    }
}
