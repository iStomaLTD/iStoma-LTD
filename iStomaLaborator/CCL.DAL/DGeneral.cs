using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CDL.iStomaLab;
using CCL.iStomaLab;

namespace CCL.DAL
{
    public static class DGeneral
    {

        #region Generale


        public static string GetConnectionString()
        {
            return CCerereSQL.getConnectionString();
        }

        public static System.Data.SqlClient.SqlConnection GetConexiuneNoua()
        {
            return CCerereSQL.getConexiuneNoua();
        }

        public static void StartServiciuSQlServer(IDbConnection pConexiune)
        {
            CCerereSQL.startSQLService(pConexiune);
        }

        #endregion

        #region INSERT

        public static int Insert(string pNumeTabela, BColectieCorespondenteColoaneValori pColoaneValori, IDbTransaction pTranzactie)
        {
            return Insert(pNumeTabela, pColoaneValori, -1, false, string.Empty, -1, pTranzactie);
        }

        public static int Insert(string pNumeTabela, BColectieCorespondenteColoaneValori pColoaneValori, int pIdUtilizatorCreare, IDbTransaction pTranzactie)
        {
            return Insert(pNumeTabela, pColoaneValori, pIdUtilizatorCreare, false, string.Empty, -1, pTranzactie);
        }

        public static int Insert(string pNumeTabela, BColectieCorespondenteColoaneValori pColoaneValori, int pIdUtilizatorCreare, bool pDeterminaPozitie, string pNumeColoanaCalculPozitie, int pValoareColoanaCalculPozitie, IDbTransaction pTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            StringBuilder coloane = new StringBuilder();
            StringBuilder valori = new StringBuilder();

            if (pIdUtilizatorCreare > 0)
            {
                coloane.Append("xnUtilizatorCreare , dDataCreare , ");
                valori.Append("@xnUtilizatorCreare , getdate() , ");
                listaParametri.Add("@xnUtilizatorCreare", pIdUtilizatorCreare);
            }

            pColoaneValori.AppendForInsert(listaParametri, coloane, valori);

            string listaColoane = BColectieCorespondenteColoaneValori.GetFaraUltimaVirgula(coloane);
            string listaValori = BColectieCorespondenteColoaneValori.GetFaraUltimaVirgula(valori);

            string comanda = string.Empty;

            if (pDeterminaPozitie)
            {
                listaParametri.Add("@nIdLista", pValoareColoanaCalculPozitie);
                comanda = string.Format("DECLARE @Pozitie int; SET @Pozitie = (SELECT MAX(nPozitie) FROM {0} WHERE {1} = @nIdLista AND dDataInchidere IS NULL);IF @Pozitie IS NULL SET @Pozitie = 1 ELSE SET @Pozitie = @Pozitie + 1;", pNumeTabela, pNumeColoanaCalculPozitie);
                comanda += string.Format("INSERT INTO {0}({1},nPozitie) VALUES ({2}, @Pozitie); SELECT SCOPE_IDENTITY();", pNumeTabela, listaColoane, listaValori);
            }
            else
                comanda = string.Format("INSERT INTO {0}({1}) VALUES ({2}); SELECT SCOPE_IDENTITY();", pNumeTabela, listaColoane, listaValori);

            object idElement = CCerereSQL.GetScalarByComandaDirecta(comanda, listaParametri, pTranzactie);   //aici nu returneaza bine pt localitate

            listaParametri = null;

            if (idElement == null || idElement == DBNull.Value)
                return -1;

            return Convert.ToInt32(idElement);
        }

        #endregion

        #region UPDATE

        public static int UpdateColoanaVidaCuColoana(string pNumeTabela, string pColoanaDestinatie, string pColoanaSursa, IDbTransaction pTranzactie)
        {
            return Convert.ToInt32(CCerereSQL.ExecuteNonQuery(string.Format("UPDATE {0} SET {1}={2} WHERE {1} IS NULL OR {1} = ''", pNumeTabela, pColoanaDestinatie, pColoanaSursa), null, pTranzactie));
        }

        public static bool CloseById(string pNumeTabela, int pIdUtilizatorInchidere, bool pInchidere, string pMotivDeInchidere, string pNumeColoanaId, int pId, IDbTransaction pTranzactie)
        {
            return CloseById(pNumeTabela, pIdUtilizatorInchidere, pInchidere, pMotivDeInchidere, pNumeColoanaId, pId, false, pTranzactie);
        }

        public static bool CloseById(string pNumeTabela, int pIdUtilizatorInchidere, bool pInchidere, string pMotivDeInchidere, string pNumeColoanaId, int pId, bool pFaraMotivInchidere, IDbTransaction pTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            listaParametri.Add("@xnUtilizatorInchidere", pIdUtilizatorInchidere);
            listaParametri.Add(string.Concat("@", pNumeColoanaId), pId);

            string SET = string.Empty;
            if (pInchidere)
            {
                if (pFaraMotivInchidere)
                {
                    SET = "dDataInchidere = GETDATE(), xnUtilizatorInchidere = @xnUtilizatorInchidere";
                }
                else
                {
                    SET = "dDataInchidere = GETDATE(), xnUtilizatorInchidere = @xnUtilizatorInchidere, tMotivInchidere = @tMotivInchidere";
                    listaParametri.Add("@tMotivInchidere", pMotivDeInchidere);
                }
            }
            else
            {
                SET = "dDataInchidere = null, xnUtilizatorInchidere = @xnUtilizatorInchidere"; // e interesant sa stim cine a reactivat inregistrarea si care a fost motivul
            }

            string comanda = string.Format("UPDATE {0} SET {1} WHERE {2} = @{2}", pNumeTabela, SET, pNumeColoanaId);
            int lNumarOperatii = Convert.ToInt32(CCerereSQL.ExecuteNonQuery(comanda, listaParametri, pTranzactie));
            listaParametri = null;
            return lNumarOperatii > 0;
        }

        public static bool CloseByIds(string pNumeTabela, int pIdUtilizatorInchidere, bool pInchidere, string pMotivDeInchidere, BColectieCorespondenteColoaneValori pId, IDbTransaction pTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            StringBuilder comandaWHERE = new StringBuilder();

            //Utilizatorul care realizeaza operatia
            listaParametri.Add("@xnUtilizatorInchidere", pIdUtilizatorInchidere);

            //Completam partea de identificare a inregistraii si Adaugam parametrii ce corespund coloanelor de identificare a inregistrarii
            pId.AppendForConditie(listaParametri, comandaWHERE);

            string SET = string.Empty;
            if (pInchidere)
            {
                SET = "dDataInchidere = GETDATE(), xnUtilizatorInchidere = @xnUtilizatorInchidere, tMotivInchidere = @tMotivInchidere";
                listaParametri.Add("@tMotivInchidere", pMotivDeInchidere);
            }
            else
                SET = "dDataInchidere = null, xnUtilizatorInchidere = @xnUtilizatorInchidere, tMotivInchidere = null"; // e interesant sa stim cine a reactivat inregistrarea

            string WHERE = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

            string Comanda = string.Format("UPDATE {0} SET {1} WHERE {2}", pNumeTabela, SET, WHERE);
            int lNumarOperatii = Convert.ToInt32(CCerereSQL.ExecuteNonQuery(Comanda, listaParametri, pTranzactie));
            listaParametri = null;
            return lNumarOperatii > 0;
        }

        public static bool UpdateToNullById(string pNumeTabela,
                                     string pNumeColoana, int pValoareActuala,
                                     IDbTransaction pTranzactie)
        {
            string textComanda = string.Format("UPDATE {0} SET {1} = null WHERE {1} = {2}", pNumeTabela, pNumeColoana, pValoareActuala);

            int lNumarOperatii = Convert.ToInt32(CCerereSQL.ExecuteNonQuery(textComanda, null, pTranzactie));

            return lNumarOperatii > 0;
        }

        public static bool UpdateAllById(string pNumeTabela,
                                     BColectieCorespondenteColoaneValori pModificari,
                                     string pNumeColoanaId, int pId,
                                     IDbTransaction pTranzactie)
        {
            return UpdateAllById(-1, pNumeTabela, pModificari, pNumeColoanaId, pId, CConstante.DataNula, pTranzactie);
        }

        public static bool UpdateAllById(int pIdUtilizatorModificare,
                                     string pNumeTabela,
                                     BColectieCorespondenteColoaneValori pModificari,
                                     string pNumeColoanaId, int pId, DateTime pDataUltimeiModificari,
                                     IDbTransaction pTranzactie)
        {
            if (pModificari.Count == 0) return true;

            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            StringBuilder ComandaSET = new StringBuilder();
            string textComanda = "UPDATE {0} SET {1} WHERE {2} = @{2}";

            //se gestioneaza informatiile legate de modificarea inregistrarii
            if (pIdUtilizatorModificare > 0)
            {
                textComanda = string.Concat(textComanda, " AND COALESCE([dDataUltimeiModificari], 0) = COALESCE(@dDataUltimeiModificari, 0) ");

                ComandaSET.Append("[dDataUltimeiModificari] = dateadd(ms,-datepart(ms,getdate()),getdate()) , [xnUtilizatorulUltimeiModificari] = @xnUtilizatorulUltimeiModificari , ");
                listaParametri.Add("@xnUtilizatorulUltimeiModificari", pIdUtilizatorModificare);
                listaParametri.Add("@dDataUltimeiModificari", pDataUltimeiModificari, true);
            }

            listaParametri.Add(string.Concat("@", pNumeColoanaId), pId);

            //Adaugam parametrii ce corespund coloanelor modificate
            pModificari.AppendForUpdate(listaParametri, ComandaSET);

            string SET = BColectieCorespondenteColoaneValori.GetFaraUltimaVirgula(ComandaSET);

            textComanda = string.Format(textComanda, pNumeTabela, SET, pNumeColoanaId);

            int lNumarOperatii = Convert.ToInt32(CCerereSQL.ExecuteNonQuery(textComanda, listaParametri, pTranzactie));
            listaParametri = null;
            return lNumarOperatii > 0;
        }

        public static void OptimizeazaBDD()
        {
            CCerereSQL.ExecuteNonQuery("exec spUtil_ReIndexDatabase_UpdateStats", null, null);
        }

        public static bool UpdateAllByIds(int pIdUtilizatorModificare,
                                     string pNumeTabela,
                                     BColectieCorespondenteColoaneValori pModificari,
                                     BColectieCorespondenteColoaneValori pId,
                                     IDbTransaction pTranzactie)
        {
            if (pModificari.Count == 0) return true;

            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            StringBuilder comandaSET = new StringBuilder();
            StringBuilder comandaWHERE = new StringBuilder();

            //Adaugam parametrii ce corespund coloanelor modificate
            pModificari.AppendForUpdate(listaParametri, comandaSET);

            //Completam partea de identificare a inregistraii si Adaugam parametrii ce corespund coloanelor de identificare a inregistrarii
            pId.AppendForConditie(listaParametri, comandaWHERE);

            string SET = BColectieCorespondenteColoaneValori.GetFaraUltimaVirgula(comandaSET);
            string WHERE = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

            string Comanda = string.Format("UPDATE {0} SET {1} WHERE {2}", pNumeTabela, SET, WHERE);
            int lNumarOperatii = Convert.ToInt32(CCerereSQL.ExecuteNonQuery(Comanda, listaParametri, pTranzactie));
            listaParametri = null;
            return lNumarOperatii > 0;
        }

        public static int UpdateAllByListaId(string pNumeTabela, string pNumeColoanaId, List<int> pListaId, string pColoanaUpdatata, int pIdPlata, IDbTransaction pTranzactie)
        {
            if (CUtil.EsteListaVida<int>(pListaId))
            {
                pListaId = new List<int>();
                pListaId.Add(0);
            }

            string comanda = string.Format("UPDATE {0} SET {3} = {4} WHERE {1} IN ({2})", pNumeTabela, pNumeColoanaId, CUtil.getListaCaText<int>(pListaId, ","), pColoanaUpdatata, (pIdPlata > 0 ? pIdPlata.ToString() : "NULL"));

            return CCerereSQL.ExecuteByComandaDirecta(comanda, null, pTranzactie);
        }

        #endregion

        #region SELECT

        public static int GetValoareMaxima(string pNumeTabela, string pColoanaValoareMaxima, IDbTransaction pTranzactie)
        {
            object rezultat = CCerereSQL.GetScalarByComandaDirecta(string.Format("SELECT max({0}) FROM {1}", pColoanaValoareMaxima, pNumeTabela), null, pTranzactie);

            if (rezultat != null && rezultat != DBNull.Value)
                return Convert.ToInt32(rezultat);

            return 0;
        }

        public static int GetValoareMaxima(string pNumeTabela, string pColoanaValoareMaxima, string pColoanaTest, int pValoareTest, bool pExistaLiniiInchise, IDbTransaction pTranzactie)
        {
            string comanda = string.Empty;

            if (pExistaLiniiInchise)
            {
                if (!string.IsNullOrEmpty(pColoanaTest) && pValoareTest > 0)
                    comanda = string.Format("SELECT max({0}) FROM {1} WHERE {2} = {3} AND dDataInchidere IS NULL",
                                            pColoanaValoareMaxima, pNumeTabela, pColoanaTest, pValoareTest);
                else
                    comanda = string.Format("SELECT max({0}) FROM {1} WHERE dDataInchidere IS NULL",
                                            pColoanaValoareMaxima, pNumeTabela);
            }
            else
            {
                if (!string.IsNullOrEmpty(pColoanaTest))
                    comanda = string.Format("SELECT max({0}) FROM {1} WHERE {2} = {3}",
                                                pColoanaValoareMaxima, pNumeTabela, pColoanaTest, pValoareTest);
                else
                    comanda = string.Format("SELECT max({0}) FROM {1}",
                                            pColoanaValoareMaxima, pNumeTabela);
            }

            object rezultat = CCerereSQL.GetScalarByComandaDirecta(comanda, null, pTranzactie);

            if (rezultat != null && rezultat != DBNull.Value)
                return Convert.ToInt32(rezultat);

            return 0;
        }

        public static int GetValoareMaxima(string pNumeTabela, string pColoanaValoareMaxima, string pColoanaTest, List<int> pValoareTest, bool pExistaLiniiInchise, string pNumeColoanaIdTest, int pId, IDbTransaction pTranzactie)
        {
            string comanda = string.Empty;

            if (pExistaLiniiInchise)
            {
                if (!string.IsNullOrEmpty(pColoanaTest) && !CUtil.EsteListaIntVida(pValoareTest))
                    comanda = string.Format("SELECT max({0}) FROM {1} WHERE {2} IN ({3}) AND dDataInchidere IS NULL",
                                                pColoanaValoareMaxima, pNumeTabela, pColoanaTest, CUtil.getListaCaText<int>(pValoareTest, ","));
                else
                    comanda = string.Format("SELECT max({0}) FROM {1} WHERE dDataInchidere IS NULL", pColoanaValoareMaxima, pNumeTabela);
            }
            else
                comanda = string.Format("SELECT max({0}) FROM {1} WHERE {2} IN ({3})",
                                            pColoanaValoareMaxima, pNumeTabela, pColoanaTest, CUtil.getListaCaText<int>(pValoareTest, ","));

            if (!string.IsNullOrEmpty(pNumeColoanaIdTest) && pId > 0)
                comanda = string.Concat(comanda, " AND ", pNumeColoanaIdTest, " = ", pId);

            object rezultat = CCerereSQL.GetScalarByComandaDirecta(comanda, null, pTranzactie);

            if (rezultat != null && rezultat != DBNull.Value)
                return Convert.ToInt32(rezultat);

            return 0;
        }

        public static DataSet SelectSumByColoanaSiCheieNotNull(string pNumeTabela, string pNumeColoana, List<int> pListaValoriColoana, string pNumeColoanaCheieIsNotNull, string pNumeColoanaSum, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT {0}, SUM({4}) AS 'nTotal' FROM {1} WHERE {0} in ({3}) AND {2} IS NOT NULL AND dDataInchidere IS NULL GROUP BY {0}",
                                            pNumeColoana, pNumeTabela, pNumeColoanaCheieIsNotNull, CUtil.getListaCaTextBDD(pListaValoriColoana), pNumeColoanaSum);

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);
        }

        public static DataSet SelectSumByColoana(string pNumeTabela, string pNumeColoana, string pNumeColoanaSum, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT {0}, SUM({2}) AS 'nTotal' FROM {1} WHERE dDataInchidere IS NULL GROUP BY {0}",
                                            pNumeColoana, pNumeTabela, pNumeColoanaSum);

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);
        }

        public static DataSet SelectSumByColoanaSiCheie(string pNumeTabela, string pNumeColoana, string pNumeColoanaSum, int pIdColoanaCheie, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT {0}, SUM({2}) AS 'nTotal' FROM {1} WHERE dDataInchidere IS NULL AND {0} = {3} GROUP BY {0}",
                                            pNumeColoana, pNumeTabela, pNumeColoanaSum, pIdColoanaCheie);

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);
        }

        public static DataSet SelectSumByColoanaSiCheieWhereNotNull(string pNumeTabela, string pNumeColoana, string pNumeColoanaSum, int pIdColoanaCheie, string pColoanaNotNull, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT {0}, SUM({2}) AS 'nTotal' FROM {1} WHERE {4} IS NOT NULL AND dDataInchidere IS NULL AND {0} = {3} GROUP BY {0}",
                                            pNumeColoana, pNumeTabela, pNumeColoanaSum, pIdColoanaCheie, pColoanaNotNull);

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);
        }

        public static DataSet SelectCountByColoanaSiCheie(string pNumeTabela, string pNumeColoana, string pNumeColoanaCheie, int pValoareCheie, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT {0}, COUNT({0}) AS 'nNumar' FROM {1} WHERE {2} = {3} AND dDataInchidere IS NULL GROUP BY {0}",
                                            pNumeColoana, pNumeTabela, pNumeColoanaCheie, pValoareCheie);

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);
        }
        public static DataSet SelectCountByColoanaSiCheieNull(string pNumeTabela, string pNumeColoana, string pNumeColoanaCheieIsNull, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT {0}, COUNT({0}) AS 'nNumar' FROM {1} WHERE {2} IS NULL AND dDataInchidere IS NULL GROUP BY {0}",
                                            pNumeColoana, pNumeTabela, pNumeColoanaCheieIsNull);

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);
        }
        public static DataSet SelectCountByColoanaSiCheieNotNull(string pNumeTabela, string pNumeColoana, List<int> pListaValoriColoana, string pNumeColoanaCheieIsNull, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT {0}, COUNT({0}) AS 'nNumar' FROM {1} WHERE {0} in ({3}) AND {2} IS NOT NULL AND dDataInchidere IS NULL GROUP BY {0}",
                                            pNumeColoana, pNumeTabela, pNumeColoanaCheieIsNull, CUtil.getListaCaTextBDD(pListaValoriColoana));

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);
        }

        public static DataSet SelectCountByColoana(string pNumeTabela, string pNumeColoana, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT {0}, COUNT({0}) AS 'nNumar' FROM {1} WHERE dDataInchidere IS NULL GROUP BY {0}",
                                            pNumeColoana, pNumeTabela);

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);
        }

        public static int SelectCountByColoaneSiStare(string pNumeTabela, BColectieCorespondenteColoaneValori pTest, CDefinitiiComune.EnumStare pStare, IDbTransaction xTranzactie)
        {
            StringBuilder comandaWHERE = new StringBuilder();
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            //Completam partea de identificare a inregistrarii si adaugam parametrii ce corespund coloanelor de identificare a inregistrarii
            pTest.AppendForConditie(listaParametri, comandaWHERE);

            string WHERE = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

            string comanda = string.Format("SELECT COUNT(*) FROM {0} WHERE {1}",
                                            pNumeTabela, WHERE);

            switch (pStare)
            {
                case CDefinitiiComune.EnumStare.Activa:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NULL");
                    break;
                case CDefinitiiComune.EnumStare.Dezactiva:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NOT NULL");
                    break;
            }

            object rezultat = CCerereSQL.GetScalarByComandaDirecta(comanda, listaParametri, xTranzactie);

            if (rezultat != null && rezultat != DBNull.Value)
                return Convert.ToInt32(rezultat);

            return 0;
        }

        public static int SelectCountByColoane(string pNumeTabela, BColectieCorespondenteColoaneValori pTest, IDbTransaction xTranzactie)
        {
            StringBuilder comandaWHERE = new StringBuilder();
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            //Completam partea de identificare a inregistrarii si adaugam parametrii ce corespund coloanelor de identificare a inregistrarii
            pTest.AppendForConditie(listaParametri, comandaWHERE);

            string WHERE = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

            string comanda = string.Format("SELECT COUNT(*) FROM {0} WHERE {1}",
                                            pNumeTabela, WHERE);

            object rezultat = CCerereSQL.GetScalarByComandaDirecta(comanda, listaParametri, xTranzactie);

            if (rezultat != null && rezultat != DBNull.Value)
                return Convert.ToInt32(rezultat);

            return 0;
        }

        public static int SelectCount(string pNumeTabela, IDbTransaction xTranzactie)
        {
            StringBuilder comandaWHERE = new StringBuilder();
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            string comanda = string.Format("SELECT COUNT(*) FROM {0}",
                                            pNumeTabela);

            object rezultat = CCerereSQL.GetScalarByComandaDirecta(comanda, listaParametri, xTranzactie);

            if (rezultat != null && rezultat != DBNull.Value)
                return Convert.ToInt32(rezultat);

            return 0;
        }

        public static int GetNumarInregistrariActive(string pNumeTabela, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT COUNT(*) FROM {0} WHERE dDataInchidere IS NULL", pNumeTabela);

            object rezultat = CCerereSQL.GetScalarByComandaDirecta(comanda, null, xTranzactie);

            if (rezultat != null && rezultat != DBNull.Value)
                return Convert.ToInt32(rezultat);

            return 0;
        }

        public static int GetNumarInregistrari(string pNumeTabela, string pNumeColoanaTest, int pValoareColoanaTest, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT COUNT(*) FROM {0} WHERE {1} = {2}", pNumeTabela, pNumeColoanaTest, pValoareColoanaTest);

            object rezultat = CCerereSQL.GetScalarByComandaDirecta(comanda, null, xTranzactie);

            if (rezultat != null && rezultat != DBNull.Value)
                return Convert.ToInt32(rezultat);

            return 0;
        }

        public static DataSet SelectByListaIdSiCriteriiSiPerioada(string pNumeTabela, string pNumeColoanaId, List<int> pListaId, string pNumeColoanaId2, List<int> pListaId2, BColectieCorespondenteColoaneValori pColoaneValori,
            string pNumeColoanaDataInceput, DateTime pLimitaInferioara, string pNumeColoanaDataSfarsit, DateTime pLimitaSuperioara, CDefinitiiComune.EnumStare pStare, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParam = new BColectieParametriSQL();

            if (CUtil.EsteListaVida<int>(pListaId))
            {
                pListaId = new List<int>();
                pListaId.Add(0);
            }

            string comanda = string.Format("SELECT * FROM {0} WHERE {1} IN ({2}) AND {3} IN ({4}) ", pNumeTabela, pNumeColoanaId, CUtil.getListaCaText<int>(pListaId, ","), pNumeColoanaId2, CUtil.getListaCaText<int>(pListaId2, ","));

            switch (pStare)
            {
                case CDefinitiiComune.EnumStare.Activa:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NULL ");
                    break;
                case CDefinitiiComune.EnumStare.Dezactiva:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NOT NULL ");
                    break;
            }

            if (pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParam, comandaWHERE);

                string where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    comanda = string.Concat(comanda, " AND ", where);
                }
            }

            if (pLimitaInferioara != CConstante.DataNula)
            {
                comanda = string.Concat(comanda, string.Format(" AND {0} >= @dLimitaInferiara", pNumeColoanaDataInceput));
                listaParam.Add("@dLimitaInferiara", CUtil.GetPrimaOraDinData(pLimitaInferioara));
            }

            if (pLimitaSuperioara != CConstante.DataNula)
            {
                comanda = string.Concat(comanda, string.Format(" AND {0} <= @dLimitaSuperioara", pNumeColoanaDataSfarsit));
                listaParam.Add("@dLimitaSuperioara", CUtil.GetUltimaOraDinData(pLimitaSuperioara));
            }

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParam, xTranzactie);
        }

        public static DataSet SelectByListaIdSiCriteriiSiPerioada(string pNumeTabela, string pNumeColoanaId, List<int> pListaId, BColectieCorespondenteColoaneValori pColoaneValori,
            string pNumeColoanaDataInceput, DateTime pLimitaInferioara, string pNumeColoanaDataSfarsit, DateTime pLimitaSuperioara, CDefinitiiComune.EnumStare pStare, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParam = new BColectieParametriSQL();

            if (CUtil.EsteListaVida<int>(pListaId))
            {
                pListaId = new List<int>();
                pListaId.Add(0);
            }

            string comanda = string.Format("SELECT * FROM {0} WHERE {1} IN ({2})", pNumeTabela, pNumeColoanaId, CUtil.getListaCaText<int>(pListaId, ","));

            switch (pStare)
            {
                case CDefinitiiComune.EnumStare.Activa:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NULL ");
                    break;
                case CDefinitiiComune.EnumStare.Dezactiva:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NOT NULL ");
                    break;
            }

            if (pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParam, comandaWHERE);

                string where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    comanda = string.Concat(comanda, " AND ", where);
                }
            }

            if (pLimitaInferioara != CConstante.DataNula)
            {
                comanda = string.Concat(comanda, string.Format(" AND {0} >= @dLimitaInferiara", pNumeColoanaDataInceput));
                listaParam.Add("@dLimitaInferiara", CUtil.GetPrimaOraDinData(pLimitaInferioara));
            }

            if (pLimitaSuperioara != CConstante.DataNula)
            {
                comanda = string.Concat(comanda, string.Format(" AND {0} <= @dLimitaSuperioara", pNumeColoanaDataSfarsit));
                listaParam.Add("@dLimitaSuperioara", CUtil.GetUltimaOraDinData(pLimitaSuperioara));
            }

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParam, xTranzactie);
        }

        public static DataSet SelectByListaIdSiCriteriiSiPerioada(string pNumeTabela, string pNumeColoanaId, List<int> pListaId,
            BColectieCorespondenteColoaneValori pColoaneValori, string pNumeColoanaData, DateTime pLimitaInferioara, DateTime pLimitaSuperioara, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParam = new BColectieParametriSQL();

            if (CUtil.EsteListaVida<int>(pListaId))
            {
                pListaId = new List<int>();
                pListaId.Add(0);
            }

            string comanda = "SELECT * FROM {0} {1}";
            string where = string.Empty;

            if (pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParam, comandaWHERE);

                where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    where = string.Concat(" WHERE ", where);
                }
            }

            if (string.IsNullOrEmpty(where))
            {
                where = " WHERE ";
            }
            else
                where = string.Concat(where, " AND ");

            where = string.Concat(where, string.Format(" {0} <= @Sfarsit AND {0} >= @dInceput", pNumeColoanaData));
            listaParam.Add("@dInceput", CUtil.GetPrimaOraDinData(pLimitaInferioara));
            listaParam.Add("@Sfarsit", CUtil.GetUltimaOraDinData(pLimitaSuperioara));

            where = string.Concat(where, " AND ", string.Format("{0} IN ({1})", pNumeColoanaId, CUtil.getListaCaText<int>(pListaId, ",")));

            comanda = string.Format(comanda, pNumeTabela, where);

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParam, xTranzactie);
        }

        public static DataSet SelectByListaIdSiCriterii(string pNumeTabela, string pNumeColoanaId, List<int> pListaId,
            BColectieCorespondenteColoaneValori pColoaneValori, CDefinitiiComune.EnumStare pStare, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParam = new BColectieParametriSQL();

            if (CUtil.EsteListaVida<int>(pListaId))
            {
                pListaId = new List<int>();
                pListaId.Add(0);
            }

            string comanda = "SELECT * FROM {0} {1}";
            string where = string.Empty;

            if (pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParam, comandaWHERE);

                where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    where = string.Concat(" WHERE ", where);
                }
            }

            where = string.Concat(where, " AND ", string.Format("{0} IN ({1})", pNumeColoanaId, CUtil.getListaCaText<int>(pListaId, ",")));

            comanda = string.Format(comanda, pNumeTabela, where);

            switch (pStare)
            {
                case CDefinitiiComune.EnumStare.Activa:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NULL ");
                    break;
                case CDefinitiiComune.EnumStare.Dezactiva:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NOT NULL ");
                    break;
            }

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParam, xTranzactie);
        }

        public static DataSet SelectByListaIdSiCriterii(string pNumeTabela, string pNumeColoanaId, List<int> pListaId,
            BColectieCorespondenteColoaneValori pColoaneValori, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParam = new BColectieParametriSQL();

            if (CUtil.EsteListaVida<int>(pListaId))
            {
                pListaId = new List<int>();
                pListaId.Add(0);
            }

            string comanda = "SELECT * FROM {0} {1}";
            string where = string.Empty;

            if (pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParam, comandaWHERE);

                where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    where = string.Concat(" WHERE ", where);
                }
            }

            where = string.Concat(where, " AND ", string.Format("{0} IN ({1})", pNumeColoanaId, CUtil.getListaCaText<int>(pListaId, ",")));

            comanda = string.Format(comanda, pNumeTabela, where);

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParam, xTranzactie);
        }

        public static DataSet SelectActiveByListaIdSiCriterii(string pNumeTabela, string pNumeColoanaId, List<int> pListaId,
            BColectieCorespondenteColoaneValori pColoaneValori, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParam = new BColectieParametriSQL();

            if (CUtil.EsteListaVida<int>(pListaId))
            {
                pListaId = new List<int>();
                pListaId.Add(0);
            }

            string comanda = "SELECT * FROM {0} {1}";
            string where = string.Empty;

            if (pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParam, comandaWHERE);

                where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    where = string.Concat(" WHERE ", where);
                }
            }

            where = string.Concat(where, " AND ", string.Format("{0} IN ({1})", pNumeColoanaId, CUtil.getListaCaText<int>(pListaId, ",")), "  AND dDataInchidere IS NULL");

            comanda = string.Format(comanda, pNumeTabela, where);

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParam, xTranzactie);
        }

        public static DataSet SelectByListaIdSiPerioada(string pNumeTabela, string pNumeColoanaId, List<int> pListaId,
            string pNumeColoanaDataInceput, DateTime pLimitaInferioara, string pNumeColoanaDataSfarsit, DateTime pLimitaSuperioara, CDefinitiiComune.EnumStare pStare, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParam = new BColectieParametriSQL();

            if (CUtil.EsteListaVida<int>(pListaId))
            {
                pListaId = new List<int>();
                pListaId.Add(0);
            }

            string comanda = string.Format("SELECT * FROM {0} WHERE {1} IN ({2})", pNumeTabela, pNumeColoanaId, CUtil.getListaCaText<int>(pListaId, ","));

            switch (pStare)
            {
                case CDefinitiiComune.EnumStare.Activa:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NULL ");
                    break;
                case CDefinitiiComune.EnumStare.Dezactiva:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NOT NULL ");
                    break;
            }

            if (pLimitaInferioara != CConstante.DataNula)
            {
                comanda = string.Concat(comanda, string.Format(" AND {0} >= @dLimitaInferiara", pNumeColoanaDataInceput));
                listaParam.Add("@dLimitaInferiara", CUtil.GetPrimaOraDinData(pLimitaInferioara));
            }

            if (pLimitaSuperioara != CConstante.DataNula)
            {
                comanda = string.Concat(comanda, string.Format(" AND {0} <= @dLimitaSuperioara", pNumeColoanaDataSfarsit));
                listaParam.Add("@dLimitaSuperioara", CUtil.GetUltimaOraDinData(pLimitaSuperioara));
            }

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParam, xTranzactie);
        }


        public static DataSet SelectByListaIdSiPerioada(string pNumeTabela, string pNumeColoanaId, List<int> pListaId,
            string pNumeColoanaDataInceput, DateTime pLimitaInferioara, string pNumeColoanaDataSfarsit, DateTime pLimitaSuperioara, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParam = new BColectieParametriSQL();

            if (CUtil.EsteListaVida<int>(pListaId))
            {
                pListaId = new List<int>();
                pListaId.Add(0);
            }

            string comanda = string.Format("SELECT * FROM {0} WHERE {1} IN ({2})", pNumeTabela, pNumeColoanaId, CUtil.getListaCaText<int>(pListaId, ","));

            if (pLimitaInferioara != CConstante.DataNula)
            {
                comanda = string.Concat(comanda, string.Format(" AND {0} >= @dLimitaInferiara", pNumeColoanaDataInceput));
                listaParam.Add("@dLimitaInferiara", CUtil.GetPrimaOraDinData(pLimitaInferioara));
            }

            if (pLimitaSuperioara != CConstante.DataNula)
            {
                comanda = string.Concat(comanda, string.Format(" AND {0} <= @dLimitaSuperioara", pNumeColoanaDataSfarsit));
                listaParam.Add("@dLimitaSuperioara", CUtil.GetUltimaOraDinData(pLimitaSuperioara));
            }

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParam, xTranzactie);
        }

        public static DataSet SelectByListaIdSiAltCriteriu(string pNumeTabela, string pNumeColoanaId, List<int> pListaId, string pNumeColoanaCriteriu, string pCriteriu, IDbTransaction xTranzactie)
        {
            if (CUtil.EsteListaVida<int>(pListaId))
            {
                pListaId = new List<int>();
                pListaId.Add(0);
            }

            string comanda = string.Format("SELECT * FROM {0} WHERE {3} = {4} AND {1} IN ({2})", pNumeTabela, pNumeColoanaId, CUtil.getListaCaText<int>(pListaId, ","), pNumeColoanaCriteriu, pCriteriu);

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);
        }

        public static DataSet SelectByListaId(string pNumeTabela, string pNumeColoanaId, List<int> pListaId, IDbTransaction xTranzactie)
        {
            if (CUtil.EsteListaVida<int>(pListaId))
            {
                pListaId = new List<int>();
                pListaId.Add(0);
            }

            string comanda = string.Format("SELECT * FROM {0} WHERE {1} IN ({2})", pNumeTabela, pNumeColoanaId, CUtil.getListaCaText<int>(pListaId, ","));

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);
        }

        public static DataSet SelectById(string pNumeTabela, string pNumeColoanaId, int pId, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            listaParametri.Add(string.Concat("@", pNumeColoanaId), pId);

            string comanda = string.Format("SELECT * FROM {0} WHERE {1} = @{1}", pNumeTabela, pNumeColoanaId);

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectActive(string pNumeTabela, string pNumeColoanaOrderBy, bool pAscendent, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT * FROM {0} WHERE dDataInchidere IS NULL", pNumeTabela);

            if (!string.IsNullOrEmpty(pNumeColoanaOrderBy))
                comanda = string.Format("{0} ORDER BY {1} {2}", comanda, pNumeColoanaOrderBy, (pAscendent ? "ASC" : "DESC"));

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);

            return ds;
        }

        public static DataSet SelectActive(string pNumeTabela, List<string> pListaCampuriRetur, string pNumeColoanaOrderBy, bool pAscendent, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT {1} FROM {0} WHERE dDataInchidere IS NULL", pNumeTabela, CUtil.getListaCaText<string>(pListaCampuriRetur, ","));

            if (!string.IsNullOrEmpty(pNumeColoanaOrderBy))
                comanda = string.Format("{0} ORDER BY {1} {2}", comanda, pNumeColoanaOrderBy, (pAscendent ? "ASC" : "DESC"));

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);

            return ds;
        }

        public static DataSet SelectActiveWhereNull(string pNumeTabela, string pNumeColoanaValoareNula, string pNumeColoanaOrderBy, bool pAscendent, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT * FROM {0} WHERE ({1} IS NULL OR {1} = '') AND dDataInchidere IS NULL", pNumeTabela, pNumeColoanaValoareNula);

            if (!string.IsNullOrEmpty(pNumeColoanaOrderBy))
                comanda = string.Format("{0} ORDER BY {1} {2}", comanda, pNumeColoanaOrderBy, (pAscendent ? "ASC" : "DESC"));

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);

            return ds;
        }

        public static DataSet SelectActiveWhereIdNullAndIdNotNull(string pNumeTabela, string pNumeColoanaValoareNula, string pNumeColoanaValoareNeNula, string pNumeColoanaOrderBy, bool pAscendent, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT * FROM {0} WHERE ISNULL({1},0) = 0 AND {2} IS NOT NULL AND dDataInchidere IS NULL", pNumeTabela, pNumeColoanaValoareNula, pNumeColoanaValoareNeNula);

            if (!string.IsNullOrEmpty(pNumeColoanaOrderBy))
                comanda = string.Format("{0} ORDER BY {1} {2}", comanda, pNumeColoanaOrderBy, (pAscendent ? "ASC" : "DESC"));

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);

            return ds;
        }

        public static DataSet SelectWhereNull(string pNumeTabela, string pNumeColoanaValoareNula, string pNumeColoanaOrderBy, bool pAscendent, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT * FROM {0} WHERE ({1} IS NULL OR {1} = '') ", pNumeTabela, pNumeColoanaValoareNula);

            if (!string.IsNullOrEmpty(pNumeColoanaOrderBy))
                comanda = string.Format("{0} ORDER BY {1} {2}", comanda, pNumeColoanaOrderBy, (pAscendent ? "ASC" : "DESC"));

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);

            return ds;
        }

        public static DataSet SelectActiveById(string pNumeTabela, string pNumeColoanaId, int pId, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            listaParametri.Add(string.Concat("@", pNumeColoanaId), pId);

            string comanda = string.Format("SELECT * FROM {0} WHERE {1} = @{1} AND dDataInchidere IS NULL", pNumeTabela, pNumeColoanaId);

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectActiveByListaId(string pNumeTabela, string pNumeColoanaId, List<int> pListaId, IDbTransaction xTranzactie)
        {
            if (CUtil.EsteListaVida<int>(pListaId))
            {
                pListaId = new List<int>();
                pListaId.Add(0);
            }

            string comanda = string.Format("SELECT * FROM {0} WHERE {1} IN ({2}) AND dDataInchidere IS NULL", pNumeTabela, pNumeColoanaId, CUtil.getListaCaText<int>(pListaId, ","));

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);
        }

        public static DataSet SelectByIds(string pNumeTabela, BColectieCorespondenteColoaneValori pId, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            StringBuilder comandaWHERE = new StringBuilder();

            //Completam partea de identificare a inregistrarii si adaugam parametrii ce corespund coloanelor de identificare a inregistrarii
            pId.AppendForConditie(listaParametri, comandaWHERE);

            string WHERE = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

            string Comanda = string.Format("SELECT * FROM {0} WHERE {1}", pNumeTabela, WHERE);

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(Comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectByColoanaCuLike(string pNumeTabela, string pNumeColoana, string pValoareLike, IDbTransaction xTranzactie)
        {
            return CCerereSQL.GetDataSetByComandaDirecta(string.Format("SELECT * FROM {0} WHERE {1} LIKE '{2}'", pNumeTabela, pNumeColoana, pValoareLike), null, xTranzactie);
        }

        public static DataSet SelectByCriterii(string pNumeTabela, BColectieCorespondenteColoaneValori pColoaneValori, IDbTransaction xTranzactie)
        {
            return SelectByCriterii(pNumeTabela, pColoaneValori, string.Empty, true, CDefinitiiComune.EnumStare.Toate, xTranzactie);
        }

        public static DataSet SelectByCriteriiSiIntervalNumeric(string pNumeTabela, BColectieCorespondenteColoaneValori pColoaneValori,
           string pNumeColoanaData, long pDataInceput, long pDataSfarsit, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            string comanda = "SELECT * FROM {0} {1}";
            string where = string.Empty;

            if (pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParametri, comandaWHERE);

                where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    where = string.Concat(" WHERE ", where);
                }
            }

            if (string.IsNullOrEmpty(where))
            {
                where = " WHERE ";
            }
            else
                where = string.Concat(where, " AND ");

            where = string.Concat(where, string.Format(" {0} <= @Sfarsit AND {0} >= @dInceput", pNumeColoanaData));
            listaParametri.Add("@dInceput", pDataInceput);
            listaParametri.Add("@Sfarsit", pDataSfarsit);

            comanda = string.Format(comanda, pNumeTabela, where);

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectByCriteriiSiPerioada(string pNumeTabela, BColectieCorespondenteColoaneValori pColoaneValori,
            string pNumeColoanaData, DateTime pDataInceput, DateTime pDataSfarsit, string pColoanaOrderBy, bool pAscendent, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            string comanda = "SELECT * FROM {0} {1} ORDER BY {2} {3}";
            string where = string.Empty;

            if (pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParametri, comandaWHERE);

                where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    where = string.Concat(" WHERE ", where);
                }
            }

            if (pDataInceput != CConstante.DataNula && pDataSfarsit != CConstante.DataNula)
            {
                if (string.IsNullOrEmpty(where))
                    where = " WHERE ";
                else
                    where = string.Concat(where, " AND ");

                where = string.Concat(where, string.Format(" {0} <= @Sfarsit AND {0} >= @dInceput", pNumeColoanaData));
                listaParametri.Add("@dInceput", CUtil.GetPrimaOraDinData(pDataInceput));
                listaParametri.Add("@Sfarsit", CUtil.GetUltimaOraDinData(pDataSfarsit));
            }
            else
            {
                if (pDataInceput != CConstante.DataNula)
                {
                    if (string.IsNullOrEmpty(where))
                        where = " WHERE ";
                    else
                        where = string.Concat(where, " AND ");

                    where = string.Concat(where, string.Format(" {0} >= @dInceput", pNumeColoanaData));
                    listaParametri.Add("@dInceput", CUtil.GetPrimaOraDinData(pDataInceput));
                }
                else
                    if (pDataSfarsit != CConstante.DataNula)
                {
                    if (string.IsNullOrEmpty(where))
                        where = " WHERE ";
                    else
                        where = string.Concat(where, " AND ");

                    where = string.Concat(where, string.Format(" {0} <= @Sfarsit ", pNumeColoanaData));
                    listaParametri.Add("@Sfarsit", CUtil.GetUltimaOraDinData(pDataSfarsit));
                }
            }

            comanda = string.Format(comanda, pNumeTabela, where, pColoanaOrderBy, pAscendent ? "ASC" : "DESC");

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectByCriteriiSiPerioada(string pNumeTabela, BColectieCorespondenteColoaneValori pColoaneValori,
            string pNumeColoanaData, DateTime pDataInceput, DateTime pDataSfarsit, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            string comanda = "SELECT * FROM {0} {1}";
            string where = string.Empty;

            if (pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParametri, comandaWHERE);

                where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    where = string.Concat(" WHERE ", where);
                }
            }

            if (string.IsNullOrEmpty(where))
            {
                where = " WHERE ";
            }
            else
                where = string.Concat(where, " AND ");

            if (pDataInceput != CConstante.DataNula && pDataSfarsit != CConstante.DataNula)
            {
                where = string.Concat(where, string.Format(" {0} <= @Sfarsit AND {0} >= @dInceput", pNumeColoanaData));
                listaParametri.Add("@dInceput", CUtil.GetPrimaOraDinData(pDataInceput));
                listaParametri.Add("@Sfarsit", CUtil.GetUltimaOraDinData(pDataSfarsit));
            }
            else
            {
                if (pDataInceput != CConstante.DataNula)
                {
                    where = string.Concat(where, string.Format(" {0} >= @dInceput", pNumeColoanaData));
                    listaParametri.Add("@dInceput", CUtil.GetPrimaOraDinData(pDataInceput));
                }
                else
                    if (pDataSfarsit != CConstante.DataNula)
                {
                    where = string.Concat(where, string.Format(" {0} <= @Sfarsit ", pNumeColoanaData));
                    listaParametri.Add("@Sfarsit", CUtil.GetUltimaOraDinData(pDataSfarsit));
                }
            }

            comanda = string.Format(comanda, pNumeTabela, where);

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectByCriteriiSiPerioada(string pNumeTabela, BColectieCorespondenteColoaneValori pColoaneValori,
            string pNumeColoanaData, DateTime pDataInceput, DateTime pDataSfarsit, CDefinitiiComune.EnumStare pStare, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            string comanda = "SELECT * FROM {0} {1}";
            string where = string.Empty;

            if (pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParametri, comandaWHERE);

                where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    where = string.Concat(" WHERE ", where);
                }
            }

            if (string.IsNullOrEmpty(where))
            {
                where = " WHERE ";
            }
            else
                where = string.Concat(where, " AND ");

            where = string.Concat(where, string.Format(" {0} <= @Sfarsit AND {0} >= @dInceput", pNumeColoanaData));
            listaParametri.Add("@dInceput", CUtil.GetPrimaOraDinData(pDataInceput));
            listaParametri.Add("@Sfarsit", CUtil.GetUltimaOraDinData(pDataSfarsit));

            switch (pStare)
            {
                case CDefinitiiComune.EnumStare.Activa:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NULL");
                    break;
                case CDefinitiiComune.EnumStare.Dezactiva:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NOT NULL");
                    break;
            }

            comanda = string.Format(comanda, pNumeTabela, where);

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectByCriteriiSiPerioadaCuAltaDataISNULL(string pNumeTabela, BColectieCorespondenteColoaneValori pColoaneValori,
            string pNumeColoanaData, DateTime pDataInceput, DateTime pDataSfarsit, string pNumeColoanaDataAlternativa, CDefinitiiComune.EnumStare pStare, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            string comanda = "SELECT * FROM {0} {1}";
            string where = string.Empty;

            if (pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParametri, comandaWHERE);

                where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    where = string.Concat(" WHERE ", where);
                }
            }

            if (string.IsNullOrEmpty(where))
            {
                where = " WHERE ";
            }
            else
                where = string.Concat(where, " AND ");

            where = string.Concat(where, string.Format(" ISNULL({0},{1}) <= @Sfarsit AND ISNULL({0},{1}) >= @dInceput", pNumeColoanaData, pNumeColoanaDataAlternativa));
            listaParametri.Add("@dInceput", CUtil.GetPrimaOraDinData(pDataInceput));
            listaParametri.Add("@Sfarsit", CUtil.GetUltimaOraDinData(pDataSfarsit));

            switch (pStare)
            {
                case CDefinitiiComune.EnumStare.Activa:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NULL");
                    break;
                case CDefinitiiComune.EnumStare.Dezactiva:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NOT NULL");
                    break;
            }

            comanda = string.Format(comanda, pNumeTabela, where);

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectByCriteriiSiPerioadaWhereNull(string pNumeTabela, BColectieCorespondenteColoaneValori pColoaneValori,
            string pNumeColoanaData, DateTime pDataInceput, DateTime pDataSfarsit, CDefinitiiComune.EnumStare pStare, string pNumeColoanaNull, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            string comanda = "SELECT * FROM {0} {1}";
            string where = string.Empty;

            if (pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParametri, comandaWHERE);

                where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    where = string.Concat(" WHERE ", where);
                }
            }

            if (string.IsNullOrEmpty(where))
            {
                where = " WHERE ";
            }
            else
                where = string.Concat(where, " AND ");

            where = string.Concat(where, string.Format(" {0} <= @Sfarsit AND {0} >= @dInceput", pNumeColoanaData));
            listaParametri.Add("@dInceput", CUtil.GetPrimaOraDinData(pDataInceput));
            listaParametri.Add("@Sfarsit", CUtil.GetUltimaOraDinData(pDataSfarsit));

            where = string.Concat(where, " AND ", pNumeColoanaNull, " IS NULL ");

            switch (pStare)
            {
                case CDefinitiiComune.EnumStare.Activa:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NULL");
                    break;
                case CDefinitiiComune.EnumStare.Dezactiva:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NOT NULL");
                    break;
            }

            comanda = string.Format(comanda, pNumeTabela, where);

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectByCriteriiSiPerioadaWhereNotNull(string pNumeTabela, BColectieCorespondenteColoaneValori pColoaneValori,
            string pNumeColoanaData, DateTime pDataInceput, DateTime pDataSfarsit, CDefinitiiComune.EnumStare pStare, string pNumeColoanaNotNull, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            string comanda = "SELECT * FROM {0} {1}";
            string where = string.Empty;

            if (pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParametri, comandaWHERE);

                where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    where = string.Concat(" WHERE ", where);
                }
            }

            if (string.IsNullOrEmpty(where))
            {
                where = " WHERE ";
            }
            else
                where = string.Concat(where, " AND ");

            where = string.Concat(where, string.Format(" {0} <= @Sfarsit AND {0} >= @dInceput", pNumeColoanaData));
            listaParametri.Add("@dInceput", CUtil.GetPrimaOraDinData(pDataInceput));
            listaParametri.Add("@Sfarsit", CUtil.GetUltimaOraDinData(pDataSfarsit));

            where = string.Concat(where, " AND ", pNumeColoanaNotNull, " IS NOT NULL ");

            switch (pStare)
            {
                case CDefinitiiComune.EnumStare.Activa:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NULL");
                    break;
                case CDefinitiiComune.EnumStare.Dezactiva:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NOT NULL");
                    break;
            }

            comanda = string.Format(comanda, pNumeTabela, where);

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectByCriteriiSiPerioadaWhereNotNull(string pNumeTabela, BColectieCorespondenteColoaneValori pColoaneValori,
            string pNumeColoanaData, DateTime pDataInceput, DateTime pDataSfarsit, string pColoanaOrderBy, bool pAscendent, CDefinitiiComune.EnumStare pStare, string pNumeColoanaNotNull, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            string comanda = "SELECT * FROM {0} {1}";
            string where = string.Empty;

            if (pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParametri, comandaWHERE);

                where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    where = string.Concat(" WHERE ", where);
                }
            }

            if (string.IsNullOrEmpty(where))
            {
                where = " WHERE ";
            }
            else
                where = string.Concat(where, " AND ");

            where = string.Concat(where, string.Format(" {0} <= @Sfarsit AND {0} >= @dInceput", pNumeColoanaData));
            listaParametri.Add("@dInceput", CUtil.GetPrimaOraDinData(pDataInceput));
            listaParametri.Add("@Sfarsit", CUtil.GetUltimaOraDinData(pDataSfarsit));

            where = string.Concat(where, " AND ", pNumeColoanaNotNull, " IS NOT NULL ");

            switch (pStare)
            {
                case CDefinitiiComune.EnumStare.Activa:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NULL");
                    break;
                case CDefinitiiComune.EnumStare.Dezactiva:
                    comanda = string.Concat(comanda, " AND dDataInchidere IS NOT NULL");
                    break;
            }

            comanda = string.Format(comanda, pNumeTabela, where);

            if (!string.IsNullOrEmpty(pColoanaOrderBy))
            {
                comanda = string.Concat(comanda, " ORDER BY ", pColoanaOrderBy, (pAscendent) ? " ASC " : " DESC ");
            }

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectTop1ByCriterii(string pNumeTabela, BColectieCorespondenteColoaneValori pColoaneValori, string pColoanaOrderBy, bool pAscendent, CDefinitiiComune.EnumStare pStare, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            string comanda = "SELECT TOP 1 * FROM {0} {1}";
            string where = string.Empty;

            if (pColoaneValori != null && pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParametri, comandaWHERE);

                where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    where = string.Concat(" WHERE ", where);
                }
            }

            if (pStare != CDefinitiiComune.EnumStare.Toate)
            {
                if (!string.IsNullOrEmpty(where))
                {
                    where += " AND ";
                }
                else
                    where = " WHERE ";

                if (pStare == CDefinitiiComune.EnumStare.Activa)
                    where += "dDataInchidere IS NULL";
                else
                    where += "dDataInchidere IS NOT NULL";
            }

            comanda = string.Format(comanda, pNumeTabela, where);

            if (!string.IsNullOrEmpty(pColoanaOrderBy))
            {
                comanda = string.Concat(comanda, " ORDER BY ", pColoanaOrderBy, (pAscendent) ? " ASC " : " DESC ");
            }

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectByCriterii(string pNumeTabela, BColectieCorespondenteColoaneValori pColoaneValori, string pColoanaOrderBy, bool pAscendent, CDefinitiiComune.EnumStare pStare, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            string comanda = "SELECT * FROM {0} {1}";
            string where = string.Empty;

            if (pColoaneValori != null && pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParametri, comandaWHERE);

                where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    where = string.Concat(" WHERE ", where);
                }
            }

            if (pStare != CDefinitiiComune.EnumStare.Toate)
            {
                if (!string.IsNullOrEmpty(where))
                {
                    where += " AND ";
                }
                else
                    where = " WHERE ";

                if (pStare == CDefinitiiComune.EnumStare.Activa)
                    where += "dDataInchidere IS NULL";
                else
                    where += "dDataInchidere IS NOT NULL";
            }

            comanda = string.Format(comanda, pNumeTabela, where);

            if (!string.IsNullOrEmpty(pColoanaOrderBy))
            {
                comanda = string.Concat(comanda, " ORDER BY ", pColoanaOrderBy, (pAscendent) ? " ASC " : " DESC ");
            }

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectByCriteriiWhereNull(string pNumeTabela, string pColoanaNull, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            string comanda = string.Format("SELECT * FROM {0} WHERE {1} IS NULL", pNumeTabela, pColoanaNull);

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectLastActiveById(string pNumeView, string pNumeTabela, string pNumeColoanaId, string pNumeColoanaGroupBy, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            string comanda = string.Format("select * from {0} as DR inner join (select max({2}) as nIdMax from {1} where dDataInchidere is null group by {3}) DMAX on DR.{2} = DMAX.nIdMax", pNumeView, pNumeTabela, pNumeColoanaId, pNumeColoanaGroupBy);

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }
        public static DataSet SelectLastActiveById(string pNumeView, string pNumeTabela, string pNumeColoanaId, string pNumeColoanaGroupBy, List<int> pListaId, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            string comanda = string.Format("select * from {0} as DR inner join (select max({2}) as nIdMax from {1} where dDataInchidere is null and {3} in ({4}) group by {3}) DMAX on DR.{2} = DMAX.nIdMax", pNumeView, pNumeTabela, pNumeColoanaId, pNumeColoanaGroupBy, CUtil.getListaCaTextBDD(pListaId));

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectLastActiva(string pNumeView, string pNumeColoanaInteres, string pNumeColoanaTest, int pIdTest, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            string comanda = string.Empty;

            if (pIdTest > 0)
                comanda = string.Format("select Top 1 * from {0} where dDataInchidere is null and {1} = {2} order by {3} desc", pNumeView, pNumeColoanaTest, pIdTest, pNumeColoanaInteres);
            else
                comanda = string.Format("select Top 1 * from {0} where dDataInchidere is null order by {3} desc", pNumeView, pNumeColoanaTest, pIdTest, pNumeColoanaInteres);

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectByCriteriiWhereNull(string pNumeTabela, BColectieCorespondenteColoaneValori pColoaneValori, string pColoanaNull, string pColoanaOrderBy, bool pAscendent, CDefinitiiComune.EnumStare pStare, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            string comanda = "SELECT * FROM {0} {1}";
            string where = string.Empty;

            if (pColoaneValori != null && pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParametri, comandaWHERE);

                where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    where = string.Concat(" WHERE ", where);
                }
            }

            if (pStare != CDefinitiiComune.EnumStare.Toate)
            {
                if (!string.IsNullOrEmpty(where))
                {
                    where += " AND ";
                }
                else
                    where = " WHERE ";

                if (pStare == CDefinitiiComune.EnumStare.Activa)
                    where += "dDataInchidere IS NULL";
                else
                    where += "dDataInchidere IS NOT NULL";
            }

            if (string.IsNullOrEmpty(where))
                where = string.Format("WHERE {0} IS NULL", pColoanaNull);
            else
                where = string.Concat(where, string.Format(" AND {0} IS NULL", pColoanaNull));

            comanda = string.Format(comanda, pNumeTabela, where);

            if (!string.IsNullOrEmpty(pColoanaOrderBy))
            {
                comanda = string.Concat(comanda, " ORDER BY ", pColoanaOrderBy, (pAscendent) ? " ASC " : " DESC ");
            }

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectByCriteriiWhereNotNull(string pNumeTabela, BColectieCorespondenteColoaneValori pColoaneValori, string pColoanaNotNull, string pColoanaOrderBy, bool pAscendent, CDefinitiiComune.EnumStare pStare, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();

            string comanda = "SELECT * FROM {0} {1}";
            string where = string.Empty;

            if (pColoaneValori != null && pColoaneValori.Count > 0)
            {
                StringBuilder comandaWHERE = new StringBuilder();

                pColoaneValori.AppendForConditie(listaParametri, comandaWHERE);

                where = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

                if (!string.IsNullOrEmpty(where))
                {
                    where = string.Concat(" WHERE ", where);
                }
            }

            if (pStare != CDefinitiiComune.EnumStare.Toate)
            {
                if (!string.IsNullOrEmpty(where))
                {
                    where += " AND ";
                }
                else
                    where = " WHERE ";

                if (pStare == CDefinitiiComune.EnumStare.Activa)
                    where += "dDataInchidere IS NULL";
                else
                    where += "dDataInchidere IS NOT NULL";
            }

            if (string.IsNullOrEmpty(where))
                where = string.Format("WHERE {0} IS NOT NULL", pColoanaNotNull);
            else
                where = string.Concat(where, string.Format(" AND {0} IS NOT NULL", pColoanaNotNull));

            comanda = string.Format(comanda, pNumeTabela, where);

            if (!string.IsNullOrEmpty(pColoanaOrderBy))
            {
                comanda = string.Concat(comanda, " ORDER BY ", pColoanaOrderBy, (pAscendent) ? " ASC " : " DESC ");
            }

            DataSet ds = CCerereSQL.GetDataSetByComandaDirecta(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            return ds;
        }

        public static DataSet SelectListaCautare(string pNumeTabela, string pNumeColoanaId, string pNumeColoanaDenumire, string pValoareLikeDenumire, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT {0}, {1} FROM {3} WHERE {1} LIKE N'{2}' collate Latin1_General_BIN2 ORDER BY {1}", pNumeColoanaId, pNumeColoanaDenumire, pValoareLikeDenumire, pNumeTabela);

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);
        }

        public static DataSet SelectListaCautareActiva(string pNumeTabela, string pNumeColoanaId, string pNumeColoanaDenumire, string pValoareLikeDenumire, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT {0}, {1} FROM {3} WHERE {1} LIKE N'{2}' collate Latin1_General_BIN2 AND dDataInchidere IS NULL ORDER BY {1}", pNumeColoanaId, pNumeColoanaDenumire, pValoareLikeDenumire, pNumeTabela);

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);
        }

        public static DataSet SelectListaCautareActivaCuTest(string pNumeTabela, string pNumeColoanaId, string pNumeColoanaDenumire, string pValoareLikeDenumire, string pNumeColoanaTest, string pValoareTest, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT {0}, {1} FROM {3} WHERE {4}={5} AND {1} LIKE N'{2}' collate Latin1_General_BIN2 AND dDataInchidere IS NULL ORDER BY {1}", pNumeColoanaId, pNumeColoanaDenumire, pValoareLikeDenumire, pNumeTabela, pNumeColoanaTest, pValoareTest);

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);
        }

        public static DataSet SelectListaCautareByCriteriu(string pNumeTabela, string pNumeColoanaDenumirePrincipala, string pNumeColoanaCautareSecundara, string pNumeColoanaDenumire, string pValoareLikeDenumire, string pNumeCriteriu, string pValoareCriteriu, IDbTransaction xTranzactie)
        {
            string comanda = string.Format("SELECT {0}, {1} FROM {3} WHERE {4} = {5} AND ({1} LIKE N'{2}' collate Latin1_General_BIN2 OR {6} LIKE N'{2}' collate Latin1_General_BIN2)  ORDER BY {1}", pNumeColoanaDenumirePrincipala, pNumeColoanaDenumire, pValoareLikeDenumire, pNumeTabela, pNumeCriteriu, pValoareCriteriu, pNumeColoanaCautareSecundara);

            return CCerereSQL.GetDataSetByComandaDirecta(comanda, null, xTranzactie);
        }

        #endregion

        #region DELETE

        public static int DeleteById(string pNumeTabela, string pNumeColoanaId, int pId, IDbTransaction xTranzactie)
        {
            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            listaParametri.Add(string.Concat("@", pNumeColoanaId), pId);

            string comanda = string.Format("DELETE FROM {0} WHERE {1} = @{1}", pNumeTabela, pNumeColoanaId);

            object numarOperatii = CCerereSQL.ExecuteNonQuery(comanda, listaParametri, xTranzactie);
            listaParametri = null;

            if (numarOperatii == null)
                return 0;

            return Convert.ToInt32(numarOperatii);
        }

        public static int DeleteByListaId(string pNumeTabela, string pNumeColoanaId, List<int> pListaId, IDbTransaction xTranzactie)
        {
            if (CUtil.EsteListaVida<int>(pListaId)) return 0;

            string comanda = string.Format("DELETE FROM {0} WHERE {1} IN ({2})", pNumeTabela, pNumeColoanaId, CUtil.getListaCaTextBDD(pListaId));

            object numarOperatii = CCerereSQL.ExecuteNonQuery(comanda, null, xTranzactie);

            if (numarOperatii == null)
                return 0;

            return Convert.ToInt32(numarOperatii);
        }

        public static bool DeleteByIds(string pNumeTabela,
                                     BColectieCorespondenteColoaneValori pId,
                                     IDbTransaction pTranzactie)
        {

            BColectieParametriSQL listaParametri = new BColectieParametriSQL();
            StringBuilder comandaWHERE = new StringBuilder();

            //Completam partea de identificare a inregistraii si Adaugam parametrii ce corespund coloanelor de identificare a inregistrarii
            pId.AppendForConditie(listaParametri, comandaWHERE);

            string WHERE = BColectieCorespondenteColoaneValori.GetFaraUltimulAND(comandaWHERE);

            string Comanda = string.Format("DELETE FROM {0} WHERE {1}", pNumeTabela, WHERE);
            int lNumarOperatii = Convert.ToInt32(CCerereSQL.ExecuteNonQuery(Comanda, listaParametri, pTranzactie));
            listaParametri = null;
            return lNumarOperatii > 0;
        }

        #endregion

    }
}
