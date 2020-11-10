
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ILL.BLL.General;
using CCL.DAL;
using DAL.iStomaLab.Utilizatori;
using CCL.iStomaLab;
using static CDL.iStomaLab.CDefinitiiComune;

namespace BLL.iStomaLab.Utilizatori
{
    /// <summary>
    /// Clasa pentru gestionarea drepturilor utilizatorului de acces la optiunile din meniu
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public sealed class BUtilizatorDrepturi : BGestiuneCMI, IDisposable
    {

        #region Declaratii generale


        #endregion //Declaratii Generale

        #region Enumerari si Structuri

        public enum EnumRubrica
        {
            Nedefinit = 0,
            TablouDeBord = 1,
            Rapoarte = 2,
            Setari = 3,
            Marketing = 4,
            Gestiune = 5,
            ResurseUmane = 6
        }

        public enum EnumOptiune
        {
            Nedefinit = 0,
            TablouDeBord = 1,
            Rapoarte = 2,
            SetariListaPreturi = 3,
            SetariLocatii = 4,
            SetariPersonal = 5,
            SetariDiverse = 6,
            Clienti = 7,
            SetariListe = 8,
            Facturare = 9,
            MarketingProspecti = 10,
            MarketingTrimitereEmail = 11,
            MarketingTrimitereSMS = 12,
            SetariComportament = 13,
            GestiuneFurnizori = 14,
            GestiuneStocuri = 15,
            GestiunePlati = 16,
            ResurseUmanePontaj = 17,
            ResurseUmaneConcedii = 18,
            ResurseUmanePiataStomatologica = 19,
            ResurseUmaneVenituri = 20
        }

        public sealed class ColectieStructOptiuni : List<StructOptiuni>
        {
            public int Id { get { return -1; } }
            public string DenumireAfisaj { get { return this.ToString(); } }

            public List<EnumRubrica> GetListaRubrici()
            {
                List<EnumRubrica> listaRetur = new List<EnumRubrica>();

                foreach (var item in this)
                {
                    if (!listaRetur.Contains(item.IdRubrica))
                        listaRetur.Add(item.IdRubrica);
                }

                return listaRetur;
            }

            public ColectieStructRubrici GetListaRubriciAsStruct()
            {
                ColectieStructRubrici listaRetur = new ColectieStructRubrici();

                foreach (var item in this)
                {
                    if (!listaRetur.Contains(item.IdRubrica))
                        listaRetur.Add(StructRubrici.getStructByEnum(item.IdRubrica));
                }

                listaRetur.SorteazaDupaRelevanta();

                return listaRetur;
            }

            public List<StructOptiuni> GetByRubricaAsStruct(EnumRubrica pRubrica)
            {
                List<StructOptiuni> listaRetur = new List<StructOptiuni>();

                foreach (var item in this)
                {
                    if (item.IdRubrica == pRubrica)
                        listaRetur.Add(item);
                }

                return listaRetur;
            }

            public List<EnumOptiune> GetByRubrica(EnumRubrica pRubrica)
            {
                List<EnumOptiune> listaRetur = new List<EnumOptiune>();

                foreach (var item in this)
                {
                    if (item.IdRubrica == pRubrica)
                        listaRetur.Add(item.Id);
                }

                return listaRetur;
            }

            public bool Contine(EnumOptiune pOptiuneSelectata)
            {
                foreach (var item in this)
                {
                    if (item.Id == pOptiuneSelectata)
                        return true;
                }

                return false;
            }

            public EnumOptiune GetPrimaByRubrica(EnumRubrica pRubricaSelectata)
            {
                foreach (var item in this)
                {
                    if (item.IdRubrica == pRubricaSelectata)
                        return item.Id;
                }

                return EnumOptiune.Nedefinit;
            }


        }


        public sealed class ColectieStructRubrici : List<StructRubrici>
        {
            public int Id { get { return -1; } }
            public string DenumireAfisaj { get { return this.ToString(); } }


            public bool Contine(EnumRubrica pRubricaSelectata)
            {
                foreach (var item in this)
                {
                    if (item.Id == pRubricaSelectata)
                        return true;
                }

                return false;
            }

            public bool Contains(EnumRubrica pRubricaSelectata)
            {
                return Contine(pRubricaSelectata);
            }

            public void SorteazaDupaRelevanta()
            {
                this.Sort(ComparaDupaNume);
            }

            public static int ComparaDupaNume(StructRubrici xElemLista1, StructRubrici xElemLista2)
            {
                if (xElemLista1.Id == EnumRubrica.Nedefinit)
                {
                    if (xElemLista2.Id == EnumRubrica.Nedefinit)
                    {
                        return 0;
                    }
                    return -1;
                }
                else
                {
                    if (xElemLista2.Id == EnumRubrica.Nedefinit)
                    {
                        return 1;
                    }
                    return xElemLista1.NumarOrdine.CompareTo(xElemLista2.NumarOrdine);
                }
            }

        }


        #region Optiuni

        public struct StructOptiuni
        {
            #region Declaratii generale

            private EnumOptiune lOptiune;
            private string sTitluLung;

            #endregion

            #region Proprietati

            public int IdInt
            {
                get { return Convert.ToInt32(this.lOptiune); }
            }

            public EnumOptiune Id
            {
                get { return this.lOptiune; }
            }

            public EnumRubrica IdRubrica { get; set; }

            public string Denumire
            {
                get { return this.sTitluLung; }
            }

            public static StructOptiuni Empty
            {
                get { return new StructOptiuni(EnumRubrica.Nedefinit, EnumOptiune.Nedefinit, string.Empty); } 
            }

            #endregion

            #region Constructori

            public StructOptiuni(EnumRubrica pIdRubrica, EnumOptiune lOptiune, string sTitluLung)
                : this()
            {
                this.IdRubrica = pIdRubrica;
                this.lOptiune = lOptiune;
                this.sTitluLung = sTitluLung;
            }

            #endregion

            #region Metode publice

            public static ColectieStructOptiuni GetList()
            {
                ColectieStructOptiuni lstStruct = new ColectieStructOptiuni();
                lstStruct.Add(getStructByEnum(EnumOptiune.TablouDeBord));
                lstStruct.Add(getStructByEnum(EnumOptiune.Rapoarte));
                lstStruct.Add(getStructByEnum(EnumOptiune.ResurseUmaneConcedii));
                lstStruct.Add(getStructByEnum(EnumOptiune.ResurseUmanePiataStomatologica));
                lstStruct.Add(getStructByEnum(EnumOptiune.ResurseUmanePontaj));
                lstStruct.Add(getStructByEnum(EnumOptiune.ResurseUmaneVenituri));
                lstStruct.Add(getStructByEnum(EnumOptiune.SetariListaPreturi));
                lstStruct.Add(getStructByEnum(EnumOptiune.SetariLocatii));
                lstStruct.Add(getStructByEnum(EnumOptiune.SetariPersonal));
                lstStruct.Add(getStructByEnum(EnumOptiune.SetariDiverse));
                lstStruct.Add(getStructByEnum(EnumOptiune.Clienti));
                lstStruct.Add(getStructByEnum(EnumOptiune.SetariListe));
                lstStruct.Add(getStructByEnum(EnumOptiune.Facturare));
                lstStruct.Add(getStructByEnum(EnumOptiune.MarketingTrimitereEmail));
                lstStruct.Add(getStructByEnum(EnumOptiune.MarketingProspecti));
                lstStruct.Add(getStructByEnum(EnumOptiune.MarketingTrimitereSMS));
                lstStruct.Add(getStructByEnum(EnumOptiune.SetariComportament));
                lstStruct.Add(getStructByEnum(EnumOptiune.GestiuneFurnizori));
                lstStruct.Add(getStructByEnum(EnumOptiune.GestiuneStocuri));
                lstStruct.Add(getStructByEnum(EnumOptiune.GestiunePlati));
                return lstStruct;
            }

            public static EnumOptiune GetEnumByString(string pNume)
            {
                EnumOptiune lId = EnumOptiune.TablouDeBord;
                foreach (StructOptiuni xStruct in GetList())
                {
                    if (xStruct.Denumire.Equals(pNume.Trim()))
                    {
                        lId = xStruct.Id;
                        break;
                    }
                }

                return lId;
            }

            public static StructOptiuni GetEnumStructByString(string pNume)
            {
                StructOptiuni lId = new StructOptiuni();
                foreach (StructOptiuni xStruct in GetList())
                {
                    if (xStruct.Denumire.Equals(pNume.Trim()))
                    {
                        lId = xStruct;
                        break;
                    }
                }

                return lId;
            }

            public static ColectieStructOptiuni GetListByString(string pNume)
            {
                ColectieStructOptiuni lstStruct = new ColectieStructOptiuni();
                lstStruct.Add(GetEnumStructByString(pNume));

                return lstStruct;
            }

            public static List<StructOptiuni> getListaOptiuni()
            {
                List<StructOptiuni> lstOptiune = new List<StructOptiuni>();
                lstOptiune.Add(getStructByEnum(EnumOptiune.TablouDeBord));
                lstOptiune.Add(getStructByEnum(EnumOptiune.Rapoarte));
                lstOptiune.Add(getStructByEnum(EnumOptiune.SetariListaPreturi));
                lstOptiune.Add(getStructByEnum(EnumOptiune.SetariLocatii));
                lstOptiune.Add(getStructByEnum(EnumOptiune.SetariPersonal));
                lstOptiune.Add(getStructByEnum(EnumOptiune.SetariDiverse));
                lstOptiune.Add(getStructByEnum(EnumOptiune.Clienti));
                lstOptiune.Add(getStructByEnum(EnumOptiune.SetariListe));
                lstOptiune.Add(getStructByEnum(EnumOptiune.Facturare));
                lstOptiune.Add(getStructByEnum(EnumOptiune.MarketingTrimitereEmail));
                lstOptiune.Add(getStructByEnum(EnumOptiune.MarketingProspecti));
                lstOptiune.Add(getStructByEnum(EnumOptiune.MarketingTrimitereSMS));
                lstOptiune.Add(getStructByEnum(EnumOptiune.SetariComportament));
                lstOptiune.Add(getStructByEnum(EnumOptiune.GestiuneFurnizori));
                lstOptiune.Add(getStructByEnum(EnumOptiune.GestiuneStocuri));
                lstOptiune.Add(getStructByEnum(EnumOptiune.GestiunePlati));
                lstOptiune.Add(getStructByEnum(EnumOptiune.ResurseUmaneConcedii));
                lstOptiune.Add(getStructByEnum(EnumOptiune.ResurseUmanePiataStomatologica));
                lstOptiune.Add(getStructByEnum(EnumOptiune.ResurseUmanePontaj));
                lstOptiune.Add(getStructByEnum(EnumOptiune.ResurseUmaneVenituri));

                return lstOptiune;
            }

            public static StructOptiuni GetByIdEnum(EnumOptiune pOptiune)
            {
                switch (pOptiune)
                {
                    case EnumOptiune.TablouDeBord:
                        return new StructOptiuni(EnumRubrica.TablouDeBord, EnumOptiune.TablouDeBord, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TablouDeBord));
                    case EnumOptiune.Rapoarte:
                        return new StructOptiuni(EnumRubrica.Rapoarte, EnumOptiune.Rapoarte, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Rapoarte));
                    case EnumOptiune.SetariListaPreturi:
                        return new StructOptiuni(EnumRubrica.Setari, EnumOptiune.SetariListaPreturi, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ListaDePreturi));
                    case EnumOptiune.SetariLocatii:
                        return new StructOptiuni(EnumRubrica.Setari, EnumOptiune.SetariLocatii, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Locatii));
                    case EnumOptiune.SetariPersonal:
                        return new StructOptiuni(EnumRubrica.Setari, EnumOptiune.SetariPersonal, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Personal));
                    case EnumOptiune.SetariDiverse:
                        return new StructOptiuni(EnumRubrica.Setari, EnumOptiune.SetariDiverse, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Diverse));
                    case EnumOptiune.Clienti:
                        return new StructOptiuni(EnumRubrica.TablouDeBord, EnumOptiune.Clienti, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Clienti));
                    case EnumOptiune.SetariListe:
                        return new StructOptiuni(EnumRubrica.Setari, EnumOptiune.SetariListe, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Liste));
                    case EnumOptiune.Facturare:
                        return new StructOptiuni(EnumRubrica.TablouDeBord, EnumOptiune.Facturare, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Facturare));
                    case EnumOptiune.MarketingTrimitereEmail:
                        return new StructOptiuni(EnumRubrica.Marketing, EnumOptiune.MarketingTrimitereEmail, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TrimitereEmail));
                    case EnumOptiune.MarketingProspecti:
                        return new StructOptiuni(EnumRubrica.Marketing, EnumOptiune.MarketingProspecti, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Prospecti));
                    case EnumOptiune.MarketingTrimitereSMS:
                        return new StructOptiuni(EnumRubrica.Marketing, EnumOptiune.MarketingTrimitereSMS, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TrimitereSMS));
                    case EnumOptiune.SetariComportament:
                        return new StructOptiuni(EnumRubrica.Setari, EnumOptiune.SetariComportament, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Comportament));
                    case EnumOptiune.GestiuneFurnizori:
                        return new StructOptiuni(EnumRubrica.Gestiune, EnumOptiune.GestiuneFurnizori, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Furnizori));
                    case EnumOptiune.GestiuneStocuri:
                        return new StructOptiuni(EnumRubrica.Gestiune, EnumOptiune.GestiuneStocuri, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Stocuri));
                    case EnumOptiune.GestiunePlati:
                        return new StructOptiuni(EnumRubrica.Gestiune, EnumOptiune.GestiunePlati, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Plati));
                    case EnumOptiune.ResurseUmanePontaj:
                        return new StructOptiuni(EnumRubrica.ResurseUmane, EnumOptiune.ResurseUmanePontaj, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pontaj));
                    case EnumOptiune.ResurseUmaneConcedii:
                        return new StructOptiuni(EnumRubrica.ResurseUmane, EnumOptiune.ResurseUmaneConcedii, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Concedii));
                    case EnumOptiune.ResurseUmanePiataStomatologica:
                        return new StructOptiuni(EnumRubrica.ResurseUmane, EnumOptiune.ResurseUmanePiataStomatologica, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.PiataStomatologica));
                    case EnumOptiune.ResurseUmaneVenituri:
                        return new StructOptiuni(EnumRubrica.ResurseUmane, EnumOptiune.ResurseUmaneVenituri, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Venituri));
                }

                return Empty;
            }


            public static string getDenumireByEnum(EnumOptiune pOptiune)
            {
                return getStructByEnum(pOptiune).Denumire;
            }

            public static StructOptiuni getStructByEnum(EnumOptiune pOptiune)
            {
                return GetByIdEnum(pOptiune);
            }

            #endregion

            #region Metode suprascrise

            public override string ToString()
            {
                return this.sTitluLung;
            }

            public override bool Equals(object obj)
            {
                if (obj is EnumOptiune || obj is int || obj is long)
                    return ((EnumOptiune)obj).Equals(this.Id);
                else
                    if (obj is StructOptiuni || obj is int || obj is long)
                    return ((StructOptiuni)obj).Equals(this.Id);
                else
                        if (obj is string)
                    return (Convert.ToString(obj).Equals(this.Denumire));

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }



            #endregion
        }

        #endregion

        #region Rubrici

        public struct StructRubrici
        {
            #region Declaratii generale

            private EnumRubrica lRubrica;
            private string sTitluLung;

            #endregion

            #region Proprietati

            public int IdInt
            {
                get { return Convert.ToInt32(this.lRubrica); }
            }

            public EnumRubrica Id
            {
                get { return this.lRubrica; }
            }


            public string Denumire
            {
                get { return this.sTitluLung; }
            }
            public int NumarOrdine { get; private set; }

            public static StructRubrici Empty
            {
                get { return new StructRubrici(EnumRubrica.Nedefinit, string.Empty, 666); }
            }

            #endregion

            #region Constructori

            public StructRubrici(EnumRubrica pIdRubrica, string sTitluLung, int pNumarOrdine)
                : this()
            {
                this.lRubrica = pIdRubrica;
                this.sTitluLung = sTitluLung;
                this.NumarOrdine = pNumarOrdine;
            }

            #endregion

            #region Metode publice

            public static ColectieStructRubrici GetList()
            {
                ColectieStructRubrici lstStruct = new ColectieStructRubrici();
                lstStruct.Add(getStructByEnum(EnumRubrica.TablouDeBord));
                lstStruct.Add(getStructByEnum(EnumRubrica.Rapoarte));
                lstStruct.Add(getStructByEnum(EnumRubrica.ResurseUmane));
                lstStruct.Add(getStructByEnum(EnumRubrica.Setari));
                lstStruct.Add(getStructByEnum(EnumRubrica.Marketing));
                lstStruct.Add(getStructByEnum(EnumRubrica.Gestiune));
                return lstStruct;
            }

            public static EnumRubrica GetEnumByString(string pNume)
            {
                EnumRubrica lId = EnumRubrica.TablouDeBord;
                foreach (StructRubrici xStruct in GetList())
                {
                    if (xStruct.Denumire.Equals(pNume.Trim()))
                    {
                        lId = xStruct.Id;
                        break;
                    }
                }

                return lId;
            }

            public static StructRubrici GetEnumStructByString(string pNume)
            {
                StructRubrici lId = new StructRubrici();
                foreach (StructRubrici xStruct in GetList())
                {
                    if (xStruct.Denumire.Equals(pNume.Trim()))
                    {
                        lId = xStruct;
                        break;
                    }
                }

                return lId;
            }

            public static ColectieStructRubrici GetListByString(string pNume)
            {
                ColectieStructRubrici lstStruct = new ColectieStructRubrici();
                lstStruct.Add(GetEnumStructByString(pNume));

                return lstStruct;
            }

            public static List<StructRubrici> getListaRubrici()
            {
                List<StructRubrici> lstRubrica = new List<StructRubrici>();
                lstRubrica.Add(getStructByEnum(EnumRubrica.TablouDeBord));
                lstRubrica.Add(getStructByEnum(EnumRubrica.Rapoarte));
                lstRubrica.Add(getStructByEnum(EnumRubrica.ResurseUmane));
                lstRubrica.Add(getStructByEnum(EnumRubrica.Setari));
                lstRubrica.Add(getStructByEnum(EnumRubrica.Marketing));
                lstRubrica.Add(getStructByEnum(EnumRubrica.Gestiune));
                return lstRubrica;
            }

            public static StructRubrici GetByIdEnum(EnumRubrica pRubrica)
            {
                switch (pRubrica)
                {
                    case EnumRubrica.TablouDeBord:
                        return new StructRubrici(EnumRubrica.TablouDeBord, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.TablouDeBord), 1);
                    case EnumRubrica.Rapoarte:
                        return new StructRubrici(EnumRubrica.Rapoarte, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Rapoarte), 2);
                    case EnumRubrica.ResurseUmane:
                        return new StructRubrici(EnumRubrica.ResurseUmane, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.ResurseUmane), 3);
                    case EnumRubrica.Marketing:
                        return new StructRubrici(EnumRubrica.Marketing, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Marketing), 4);
                    case EnumRubrica.Gestiune:
                        return new StructRubrici(EnumRubrica.Gestiune, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Gestiune), 5);
                    case EnumRubrica.Setari:
                        return new StructRubrici(EnumRubrica.Setari, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Setari), 6);
                }

                return Empty;
            }

            public static string getDenumireByEnum(EnumRubrica pRubrica)
            {
                return getStructByEnum(pRubrica).Denumire;
            }

            public static StructRubrici getStructByEnum(EnumRubrica pRubrica)
            {
                return GetByIdEnum(pRubrica);
            }

            #endregion

            #region Metode suprascrise

            public override string ToString()
            {
                return this.sTitluLung;
            }

            public override bool Equals(object obj)
            {
                if (obj is EnumRubrica || obj is int || obj is long)
                    return ((EnumRubrica)obj).Equals(this.Id);
                else
                    if (obj is StructRubrici || obj is int || obj is long)
                    return ((StructRubrici)obj).Equals(this.Id);
                else
                        if (obj is string)
                    return (Convert.ToString(obj).Equals(this.Denumire));

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            #endregion
        }

        #endregion

        #endregion //Enumerari si Structuri

        #region Proprietati

        [BExport("IdRubrica", true, 1)]
        public EnumRubrica IdRubrica
        {
            get { return (EnumRubrica)this.MyDataRowGetItemAsInteger(DUtilizatorDrepturi.EnumCampuriTabela.nIdRubrica.ToString()); }
            set { this.MyDataRowSetItem(DUtilizatorDrepturi.EnumCampuriTabela.nIdRubrica.ToString(), Convert.ToInt32(value)); }
        }

        [BExport("IdOptiune", true, 1)]
        public EnumOptiune IdOptiune
        {
            get { return (EnumOptiune)this.MyDataRowGetItemAsInteger(DUtilizatorDrepturi.EnumCampuriTabela.nIdOptiune.ToString()); }
            set { this.MyDataRowSetItem(DUtilizatorDrepturi.EnumCampuriTabela.nIdOptiune.ToString(), Convert.ToInt32(value)); }
        }

        [BExport("IdUtilizator", true, 1)]
        public int IdUtilizator
        {
            get { return this.MyDataRowGetItemAsInteger(DUtilizatorDrepturi.EnumCampuriTabela.xnIdUtilizator.ToString()); }
            set { this.MyDataRowSetItem(DUtilizatorDrepturi.EnumCampuriTabela.xnIdUtilizator.ToString(), value); }
        }

        public EnumTipObiect TipObiect
        {
            get { return TipObiectClasa; }
        }

        public static EnumTipObiect TipObiectClasa
        {
            get { return EnumTipObiect.UtilizatorDrepturi; }
        }

        public string DenumireAfisaj
        {
            get { return StructOptiuni.getDenumireByEnum(this.IdOptiune); }
        }

        #endregion //Proprietati

        #region Constructori

        public BUtilizatorDrepturi(DataRow pMyRow)
        {
            FillObjectWithDataRow<BUtilizatorDrepturi>(pMyRow, this);
        }

        #endregion //Constructori

        #region Metode de clasa

        public static bool Add(int pIdUser, List<StructOptiuni> pListaOptiuni, IDbTransaction pTranzactie)
        {
            if (!CUtil.EsteListaVida<StructOptiuni>(pListaOptiuni))
            {
                //recuperam ce are
                List<EnumOptiune> listaDrepturiExistente = GetListByParam(EnumRubrica.Nedefinit, EnumOptiune.Nedefinit, pIdUser, pTranzactie).GetListaIdOptiuni();

                foreach (var item in pListaOptiuni)
                {
                    if (!listaDrepturiExistente.Contains(item.Id))
                        Add(item.IdRubrica, item.Id, pIdUser, pTranzactie);
                }

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Metoda de clasa ce permite adaugarea unui obiect de tip DUtilizatorDrepturi
        /// </summary>
        /// <param name="pIdRubrica"></param>
        /// <param name="pIdOptiune"></param>
        /// <param name="pIdUtilizator"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Add(EnumRubrica pIdRubrica, EnumOptiune pIdOptiune, int pIdUtilizator, IDbTransaction pTranzactie)
        {
            int id = DUtilizatorDrepturi.Add(BUtilizator.GetIdUtilizatorConectat(pTranzactie), Convert.ToInt32(pIdRubrica), Convert.ToInt32(pIdOptiune), pIdUtilizator, pTranzactie);
            return id;
        }

        public static bool SuntInformatiileNecesareCoerente(ref string pMesajRetur, int pIdRubrica, int pIdOptiune, int pIdUtilizator)
        {
            bool esteOK = true;

            return esteOK;
        }
        /// <summary>
        /// Metoda de clasa pentru obtinerea unei liste de obiecte de tipul BUtilizatorDrepturi
        /// </summary>
        /// <returns>Lista ce corespunde parametrilor</returns>
        /// <remarks></remarks>
        public static BColectieUtilizatorDrepturi GetListByParam(EnumRubrica pIdRubrica, EnumOptiune pIdOptiune, int pIdUtilizator, IDbTransaction pTranzactie)
        {
            BColectieUtilizatorDrepturi lstDUtilizatorDrepturi = new BColectieUtilizatorDrepturi();
            using (DataSet ds = DUtilizatorDrepturi.GetListByParam(Convert.ToInt32(pIdRubrica), Convert.ToInt32(pIdOptiune), pIdUtilizator, pTranzactie))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lstDUtilizatorDrepturi.Add(new BUtilizatorDrepturi(dr));
                }
            }
            return lstDUtilizatorDrepturi;
        }

        public static ColectieStructOptiuni GetByUserConectat(IDbTransaction pTranzactie)
        {
            BColectieUtilizatorDrepturi listaDrepturi = GetListByParam(EnumRubrica.Nedefinit, EnumOptiune.Nedefinit, BUtilizator.GetIdUtilizatorConectat(pTranzactie), pTranzactie);

            return listaDrepturi.GetAsColectieStructOptiuni();
        }


        #endregion //Metode de clasa

        #region Metode de instanta

        public StructOptiuni GetAsStructOptiuni()
        {
            return StructOptiuni.getStructByEnum(this.IdOptiune);
        }

        public bool Delete(IDbTransaction pTranzactie)
        {
            return DUtilizatorDrepturi.Delete(Convert.ToInt32(this.IdRubrica), Convert.ToInt32(this.IdOptiune), this.IdUtilizator, pTranzactie);
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
                bool succesModificare = true;// DUtilizatorDrepturi.UpdateById(getDictProprietatiModificate(), this.IdRubrica, this.IdOptiune, this.IdUtilizator, Tranzactie);

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
                //this.Refresh(pTranzactie);
            }
        }

        public bool ExistaProprietatiModificate()
        {
            return false;// this.IsMyDataRowItemHasChanged(DUtilizatorDrepturi.EnumCampuriTabela.nIdRubrica.ToString()) ||
                         //this.IsMyDataRowItemHasChanged(DUtilizatorDrepturi.EnumCampuriTabela.xnIdUtilizator.ToString());
        }

        private BColectieCorespondenteColoaneValori getDictProprietatiModificate()
        {
            BColectieCorespondenteColoaneValori dictRezultat = new BColectieCorespondenteColoaneValori();

            return dictRezultat;
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
            myXmlDoc.LoadXml("<DUtilizatorDrepturi></DUtilizatorDrepturi>");

            //Adaugam elementele clasei BUtilizatorDrepturi
            myXmlElem = myXmlDoc.CreateElement("IDRUBRICA");
            myXmlElem.InnerText = Convert.ToString(this.IdRubrica);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDOPTIUNE");
            myXmlElem.InnerText = Convert.ToString(this.IdOptiune);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("IDUTILIZATOR");
            myXmlElem.InnerText = Convert.ToString(this.IdUtilizator);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("DATACREARE");
            myXmlElem.InnerText = Convert.ToString(this.DataCreare);
            myXmlDoc.DocumentElement.AppendChild(myXmlElem);

            myXmlElem = myXmlDoc.CreateElement("UTILIZATORCREARE");
            myXmlElem.InnerText = Convert.ToString(this.UtilizatorCreare);
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
            return this.DenumireAfisaj;
        }

        #endregion //Metode de instanta

        #region Metode de comparatie

        #endregion //Metode de comparatie

    }

}

