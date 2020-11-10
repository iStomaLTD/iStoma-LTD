using BLL.iStomaLab.Utilizatori;
using CCL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.iStomaLab
{
    public abstract class BGestiuneCMI : BGeneral, IDisposable
    {

        #region Declaratii generale

        #endregion

        #region Proprietati

        /// <summary>
        /// Data de creare a inregistrarii
        /// </summary>
        [BExport("DataCreare", true, 1)]
        public System.DateTime DataCreare
        {
            get
            {
                return this.MyDataRowGetItemAsDateNull(EnumColoaneStandard.dDataCreare.ToString());
            }
        }

        /// <summary>
        /// Utilizatorul ce a creat inregistrarea
        /// </summary>
        [BExport("UtilizatorCreare", true, 1)]
        public int UtilizatorCreare
        {
            get
            {
                return this.MyDataRowGetItemAsIntegerNull(EnumColoaneStandard.xnUtilizatorCreare.ToString());
            }
        }

        /// <summary>
        /// In relatie cu proprietatea UtilizatorCreare
        /// Utilizatorul ce a creat inregistrarea
        /// </summary>
        public BUtilizator ObiectUtilizatorCreare
        {
            get
            {
                return BUtilizator.GetById(this.UtilizatorCreare, null);
            }
        }

        /// <summary>
        /// Data de inchidere
        /// </summary>
        [BExport("DataInchidere", true, 1)]
        public System.DateTime DataInchidere
        {
            get
            {
                return this.MyDataRowGetItemAsDateNull(EnumColoaneStandard.dDataInchidere.ToString());
            }
        }

        /// <summary>
        /// Utilizatorul ce a inchis inregistrarea
        /// </summary>
        [BExport("UtilizatorInchidere", true, 1)]
        public int UtilizatorInchidere
        {
            get
            {
                return this.MyDataRowGetItemAsIntegerNull(EnumColoaneStandard.xnUtilizatorInchidere.ToString());
            }
        }

        /// <summary>
        /// In relatie cu proprietatea UtilizatorInchidere
        /// Utilizatorul ce a inchis inregistrarea
        /// </summary>
        public BUtilizator ObiectUtilizatorInchidere
        {
            get
            {
                return BUtilizator.GetById(this.UtilizatorInchidere, null);
            }
        }

        /// <summary>
        /// Motivul de inchidere
        /// </summary>
        [BExport("MotivInchidere", true, 1)]
        public string MotivInchidere
        {
            get
            {
                return this.MyDataRowGetItem(EnumColoaneStandard.tMotivInchidere.ToString());
            }
            set
            {
                this.MyDataRowSetItem(EnumColoaneStandard.tMotivInchidere.ToString(), value);
            }
        }

        /// <summary>
        /// Data la care inregisrarea a fost modificata ultima oara
        /// </summary>
        [BExport("DataUltimeiModificari", true, 1)]
        public System.DateTime DataUltimeiModificari
        {
            get
            {
                return this.MyDataRowGetItemAsDateNull(EnumColoaneStandard.dDataUltimeiModificari.ToString());
            }
        }

        /// <summary>
        /// Utilizatorul ce a facut ultima modificare
        /// </summary>
        [BExport("UtilizatorulUltimeiModificari", true, 1)]
        public int UtilizatorulUltimeiModificari
        {
            get
            {
                return this.MyDataRowGetItemAsIntegerNull(EnumColoaneStandard.xnUtilizatorulUltimeiModificari.ToString());
            }
        }

        /// <summary>
        /// In relatie cu proprietatea UtilizatorCreare
        /// Utilizatorul ce a creat inregistrarea
        /// </summary>
        public BUtilizator ObiectUtilizatorModificare
        {
            get
            {
                return BUtilizator.GetById(this.UtilizatorulUltimeiModificari, null);
            }
        }

        [BExport("UtilizatorCreareNumeComplet", true, 1)]
        public string UtilizatorCreareNumeComplet
        {
            get
            {
                return BUtilizator.GetIdentitateById(this.UtilizatorCreare);
            }
        }

        [BExport("UtilizatorInchidereNumeComplet", true, 1)]
        public string UtilizatorInchidereNumeComplet
        {
            get
            {
                //if (this.MyDataRow.Table.Columns.Contains(EnumColoaneStandard.tIdentitateUserInchidere.ToString()))
                //    return this.MyDataRowGetItem(EnumColoaneStandard.tIdentitateUserInchidere.ToString());

                //if (this.ObiectUtilizatorInchidere != null)
                //    return this.ObiectUtilizatorInchidere.ToString();

                return BUtilizator.GetIdentitateById(this.UtilizatorInchidere);
            }
        }

        [BExport("Utilizator Modificare", true, 1)]
        public string UtilizatorModificareNumeComplet
        {
            get
            {
                return BUtilizator.GetIdentitateById(this.UtilizatorulUltimeiModificari);
            }
        }

        /// <summary>
        /// Precizare referitoare la starea inregistrarii
        /// </summary>
        [BExport("EsteActiv", true, 1)]
        public bool EsteActiv
        {
            get
            {
                return (this.DataInchidere == CConstante.DataNula);
            }
        }

        #endregion

        #region Metode

        public new void Dispose()
        {
            base.Dispose();
        }

        public override abstract bool UpdateAll(System.Data.IDbTransaction pTranzactie);

        /// <summary>
        /// Creat de X la data Y
        /// </summary>
        /// <returns></returns>
        public string GetInfoCreare()
        {
            return string.Format(string.Format("{0} {1} {2} {3}", BMultiLingv.getElementById(BMultiLingv.EnumDictionar.CreatDe), this.UtilizatorCreareNumeComplet, BMultiLingv.getElementById(BMultiLingv.EnumDictionar.LaData), this.DataCreare.ToString(CConstante.FORMAT_DATA_ORA)));
        }

        protected void adaugaModificare(string modificare, ref string pTextActual)
        {
            if (!string.IsNullOrEmpty(pTextActual))
                pTextActual += CConstante.LinieNoua;

            pTextActual += modificare;
        }

        #endregion

    }
}
