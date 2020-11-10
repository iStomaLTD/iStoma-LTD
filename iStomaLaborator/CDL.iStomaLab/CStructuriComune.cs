using ILL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CDL.iStomaLab.CDefinitiiComune;

namespace CDL.iStomaLab
{
    public static class CStructuriComune
    {
        /// <summary>
        /// -1- Se deseneaza separatorul de coloane
        /// -2- Culoare Fundal antet
        /// -3- Culoare Text antet
        /// -4- Culoare fundal linie alternanta
        /// -5- Culoare text linie alternanta
        /// -6- Culoare text tabel 
        /// -7- Culoare trasare linii tabel
        /// </summary>
        public struct StructPaletaDGV : IPreferinteDGV
        {
            public System.Drawing.Color CuloareDGVFundal { get; set; }
            public System.Drawing.Color CuloareDGVLinie { get; set; }
            public System.Drawing.Color CuloareDGVTextLinieNormala { get; set; }
            public System.Drawing.Color CuloareDGVLinieAlernanta { get; set; }
            public System.Drawing.Color CuloareDGVTextLinieAlternanta { get; set; }
            public System.Drawing.Color CuloareDGVFundalLinieSelectata { get; set; }
            public System.Drawing.Color CuloareDGVTextLinieSelectata { get; set; }
            public System.Drawing.Color CuloareDGVTextAlerta { get { return Color.Red; } }
            public System.Drawing.Color CuloareDGVTextAlertaRandSelectat { get { return Color.Red; } }

            public bool AreValoare { get; private set; }
            public bool DeseneazaSeparatoriColoane { get; set; }
            public System.Drawing.Color CuloareFundalAntet { get; set; }
            public System.Drawing.Color CuloareTextAntet { get; set; }
            public System.Drawing.Color CuloareFundalLinieAlternanta { get; set; }
            public System.Drawing.Color CuloareTextLinieAlternanta { get; set; }
            public System.Drawing.Color CuloareTextTabel { get; set; }
            public System.Drawing.Color CuloareTrasareLiniiTabel { get; set; }
            public string Denumire { get; private set; }

            public string GetCuloareFundalAntet()
            {
                return System.Drawing.ColorTranslator.ToHtml(CuloareFundalAntet);
            }

            public string GetCuloareTextAntet()
            {
                return System.Drawing.ColorTranslator.ToHtml(CuloareTextAntet);
            }

            public string GetCuloareLiniiTabel()
            {
                return System.Drawing.ColorTranslator.ToHtml(CuloareTrasareLiniiTabel);
            }

            public override string ToString()
            {
                return this.Denumire;
            }

            public StructPaletaDGV(string pDenumire, bool pDeseneazaSeparatoriColoane, System.Drawing.Color pCuloareFundalAntet, System.Drawing.Color pCuloareTextAntet, System.Drawing.Color pCuloareFundalLinieAlternanta, System.Drawing.Color pCuloareTextLinieAlternanta, System.Drawing.Color pCuloareTextTabel, System.Drawing.Color pCuloareTrasareLiniiTabel, bool pAreValoare)
                : this()
            {
                this.Denumire = pDenumire;
                this.DeseneazaSeparatoriColoane = pDeseneazaSeparatoriColoane;
                this.CuloareFundalAntet = pCuloareFundalAntet;
                this.CuloareTextAntet = pCuloareTextAntet;
                this.CuloareFundalLinieAlternanta = pCuloareFundalLinieAlternanta;
                this.CuloareTextLinieAlternanta = pCuloareTextLinieAlternanta;
                this.CuloareTextTabel = pCuloareTextTabel;
                this.CuloareTrasareLiniiTabel = pCuloareTrasareLiniiTabel;
                this.AreValoare = pAreValoare;

                this.CuloareDGVFundal = Color.White;
                this.CuloareDGVLinie = Color.Black;
                this.CuloareDGVTextLinieNormala = Color.Black;
                this.CuloareDGVLinieAlernanta = Color.Black;
                this.CuloareDGVTextLinieAlternanta = Color.Black;
                this.CuloareDGVFundalLinieSelectata = Color.Gray;
                this.CuloareDGVTextLinieSelectata = Color.LightGray;
            }

            public StructPaletaDGV(string valComp, char pSeparator)
                : this()
            {
                string[] listaVal = valComp.Split(pSeparator);

                bool deseneazaSeparatorColoane = false;
                int temp = 0;
                System.Drawing.Color culFundalAntet = System.Drawing.Color.LightYellow;
                System.Drawing.Color culTextAntet = System.Drawing.Color.Black;
                System.Drawing.Color culFundalLinieAlternanta = System.Drawing.Color.White;
                System.Drawing.Color culTextLinieAlternanta = System.Drawing.Color.Black;
                System.Drawing.Color culTextTabel = System.Drawing.Color.Black;
                System.Drawing.Color culTrasareLiniiTabel = System.Drawing.Color.Black;

                bool.TryParse(listaVal[0], out deseneazaSeparatorColoane);
                if (listaVal.Length > 0 && int.TryParse(listaVal[1], out temp))
                    culFundalAntet = System.Drawing.Color.FromArgb(temp);
                if (listaVal.Length > 1 && int.TryParse(listaVal[2], out temp))
                    culTextAntet = System.Drawing.Color.FromArgb(temp);
                if (listaVal.Length > 2 && int.TryParse(listaVal[3], out temp))
                    culFundalLinieAlternanta = System.Drawing.Color.FromArgb(temp);
                if (listaVal.Length > 3 && int.TryParse(listaVal[4], out temp))
                    culTextLinieAlternanta = System.Drawing.Color.FromArgb(temp);
                if (listaVal.Length > 4 && int.TryParse(listaVal[5], out temp))
                    culTextTabel = System.Drawing.Color.FromArgb(temp);
                if (listaVal.Length > 5 && int.TryParse(listaVal[6], out temp))
                    culTrasareLiniiTabel = System.Drawing.Color.FromArgb(temp);

                this.DeseneazaSeparatoriColoane = deseneazaSeparatorColoane;
                this.CuloareFundalAntet = culFundalAntet;
                this.CuloareTextAntet = culTextAntet;
                this.CuloareFundalLinieAlternanta = culFundalLinieAlternanta;
                this.CuloareTextLinieAlternanta = culTextLinieAlternanta;
                this.CuloareTextTabel = culTextTabel;
                this.CuloareTrasareLiniiTabel = culTrasareLiniiTabel;

                listaVal = null;
            }

            public static StructPaletaDGV Empty { get { return new StructPaletaDGV("Gri", false, System.Drawing.Color.LightGray, System.Drawing.Color.Black, System.Drawing.Color.White, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, true); } }

            public static List<StructPaletaDGV> GetListaTemplate()
            {
                List<StructPaletaDGV> listaRetur = new List<StructPaletaDGV>();

                //Selectati un template
                listaRetur.Add(new StructPaletaDGV("Nedefinit", false, System.Drawing.Color.LightYellow, System.Drawing.Color.Black, System.Drawing.Color.White, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, false));

                //Gri
                listaRetur.Add(new StructPaletaDGV("Gri", false, System.Drawing.Color.LightGray, System.Drawing.Color.Black, System.Drawing.Color.White, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, true));

                //Galben
                listaRetur.Add(new StructPaletaDGV("Galben", false, System.Drawing.Color.LightYellow, System.Drawing.Color.Black, System.Drawing.Color.White, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Black, true));

                //Rosu
                listaRetur.Add(new StructPaletaDGV("Rosu", false, System.Drawing.Color.Red, System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.Pink, true));

                //Verde
                listaRetur.Add(new StructPaletaDGV("Verde", false, System.Drawing.Color.DarkGreen, System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.LightGreen, true));

                //Albastru
                listaRetur.Add(new StructPaletaDGV("Albastru", false, System.Drawing.Color.DarkBlue, System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, true));

                //Violet
                listaRetur.Add(new StructPaletaDGV("Violet", false, System.Drawing.Color.DarkMagenta, System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.Black, System.Drawing.Color.Black, System.Drawing.Color.LightPink, true));

                return listaRetur;
            }
        }

        public struct StructTipMoneda
        {

            #region Declaratii generale
            
            public EnumTipMoneda Id { get; set; }
            public string Nume { get; set; }
            public string Subunitate { get; private set; }
            public static StructTipMoneda Empty
            {
                get { return new StructTipMoneda(EnumTipMoneda.Nedefinit, string.Empty, string.Empty); }
            }

            public int IdInt
            {
                get { return Convert.ToInt32(this.Id); }
            }

            #endregion

            #region Constructori

            public StructTipMoneda(EnumTipMoneda pId, string pNume, string pSubUnitate)
                : this()
            {
                this.Id = pId;
                this.Nume = pNume;
                this.Subunitate = pSubUnitate;
            }

            #endregion

            #region Metode suprascrise

            public override string ToString()
            {
                return this.Nume;
            }

            public override bool Equals(object obj)
            {
                bool Egalitate = base.Equals(obj);
                if (obj == null)
                    Egalitate = false;
                else
                    if (obj is EnumTipMoneda || obj is int || obj is long)
                    Egalitate = (this.Id == (EnumTipMoneda)obj);
                else
                        if (obj is StructTipMoneda)
                    Egalitate = (this.Id == ((StructTipMoneda)obj).Id);
                return Egalitate;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            #endregion

            #region Metode publice

            public StructTipMoneda getEmpty()
            {
                return Empty;
            }

            public List<StructTipMoneda> getLista()
            {
                return GetList();
            }

            public static List<StructTipMoneda> GetList()
            {
                List<StructTipMoneda> lstStruct = new List<StructTipMoneda>();
                lstStruct.Add(GetStructByEnum(EnumTipMoneda.Lei));
                lstStruct.Add(GetStructByEnum(EnumTipMoneda.Euro));
                return lstStruct;
            }

            public static EnumTipMoneda GetEnumByString(string pNume)
            {
                EnumTipMoneda lId = EnumTipMoneda.Nedefinit;
                foreach (StructTipMoneda xStruct in GetList())
                {
                    if (xStruct.Nume.Equals(pNume.Trim()))
                    {
                        lId = xStruct.Id;
                        break;
                    }
                }

                return lId;
            }

            public static string GetStringByEnum(EnumTipMoneda pId)
            {
                return GetStructByEnum(pId).Nume;
            }

            public static string GetSubunitateByEnum(EnumTipMoneda pTipMoneda)
            {
                return GetStructByEnum(pTipMoneda).Subunitate;
            }

            public static StructTipMoneda GetStructByEnum(EnumTipMoneda pId)
            {
                switch (pId)
                {
                    case EnumTipMoneda.Lei:
                        return new StructTipMoneda(EnumTipMoneda.Lei, "RON", "Bani");// "Lei");
                    case EnumTipMoneda.Euro:
                        return new StructTipMoneda(EnumTipMoneda.Euro, "EUR", "Cenți");// "Euro");
                }
                return Empty;
            }

            public bool Exista()
            {
                return this.Id != EnumTipMoneda.Nedefinit;
            }

            public static EnumTipMoneda GetCealaltaMoneda(EnumTipMoneda pMoneda)
            {
                if (pMoneda == EnumTipMoneda.Lei)
                    return EnumTipMoneda.Euro;
                else
                    return EnumTipMoneda.Lei;
            }

            #endregion

        }

        public struct StructIContact
        {
            public string Nume { get; set; }
            public string NumeDeFata { get; set; }
            public string Prenume { get; set; }
            public string Porecla { get; set; }
            public string TelefonMobil { get; set; }
            public string AdresaEmail { get; set; }
            public DateTime DataDeNastere { get; set; }
            public string IdG { get; set; }
            public string NumePrenume { get { return string.Format("{0} {1}", this.Nume, this.Prenume); } }
            public string ContSkype { get; set; }
            public string ContYM { get; set; }
            public string PaginaWeb { get; set; }
            public string InfoComplementare { get; set; }
            public string IdGGrup { get; set; }
            public bool EsteNull { get; set; }
        }


        public sealed class LegendaImagini : List<StructLegendaImagini>
        {
            public StructLegendaImagini Add(int pId, Image pImagine, string pSemnificatie, Color pCuloareText)
            {
                StructLegendaImagini ElementLegenda = new StructLegendaImagini(pId, pImagine, pSemnificatie, pCuloareText);
                this.Add(ElementLegenda);
                return ElementLegenda;
            }
        }

        public struct StructLegendaImagini
        {
            public int Id { get; set; }
            public Image Imagine { get; set; }
            public string Semnificatie { get; set; }
            public Color CuloareText { get; set; }

            public StructLegendaImagini(int pId, Image pImagine, string pSemnificatie, Color pCuloareText)
                : this()
            {
                this.Id = pId;
                this.Imagine = pImagine;
                this.Semnificatie = pSemnificatie;
                this.CuloareText = pCuloareText;
            }

            public override string ToString()
            {
                return this.Semnificatie;
            }
        }

    }
}
