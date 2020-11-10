using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ILL.iStomaLab;
using CCL.UI.FormulareComune;
using CDL.iStomaLab;
using CCL.iStomaLab;

namespace CCL.UI
{
    public partial class frmControlBox : frmCuHeader
    {

        #region Declaratii generale

        private DateTime _dataAleasa = CConstante.DataNula;
        private DateTime lPragInferior = CConstante.DataNula;
        private DateTime lPragSuperior = CConstante.DataNula;
        private DateTime lDataInitializare = CConstante.DataNula;

        #endregion

        #region Enumerari

        private enum EnumPeste
        {
            Nedefinit = 0,
            oSaptamana = 1,
            douaSaptamani = 2,
            treiSaptamani = 3,
            oLuna = 4,
            douaLuni = 5,
            treiLuni = 6,
            patruLuni = 7,
            cinciLuni = 8,
            saseLuni = 9,
            sapteLuni = 10,
            optLuni = 11,
            nouaLuni = 13,
            zeceLuni = 14,
            unspeLuni = 15,
            unAn = 16,
            doiAni = 17,
            zeceZile = 18,
            saseSaptamani = 19,
            optSaptamani = 20,
            zeceSaptamani = 21,
            doisprezeceSaptamani = 22
        }

        private struct StructPeste
        {
            public EnumPeste IdEnum { get; set; }
            public string Denumire { get; set; }

            public static StructPeste Empty { get { return new StructPeste(EnumPeste.Nedefinit, string.Empty); } }

            public StructPeste(EnumPeste pIdEnum, string pDenumire)
                : this()
            {
                this.IdEnum = pIdEnum;
                this.Denumire = pDenumire;
            }

            public override string ToString()
            {
                return this.Denumire;
            }

            public static List<StructPeste> GetLista()
            {
                List<StructPeste> listaRetur = new List<StructPeste>();

                listaRetur.Add(GetStructByEnum(EnumPeste.Nedefinit));
                listaRetur.Add(GetStructByEnum(EnumPeste.zeceZile));
                listaRetur.Add(GetStructByEnum(EnumPeste.oSaptamana));
                listaRetur.Add(GetStructByEnum(EnumPeste.douaSaptamani));
                listaRetur.Add(GetStructByEnum(EnumPeste.treiSaptamani));
                listaRetur.Add(GetStructByEnum(EnumPeste.saseSaptamani));
                listaRetur.Add(GetStructByEnum(EnumPeste.optSaptamani));
                listaRetur.Add(GetStructByEnum(EnumPeste.zeceSaptamani));
                listaRetur.Add(GetStructByEnum(EnumPeste.doisprezeceSaptamani));
                listaRetur.Add(GetStructByEnum(EnumPeste.oLuna));
                listaRetur.Add(GetStructByEnum(EnumPeste.douaLuni));
                listaRetur.Add(GetStructByEnum(EnumPeste.treiLuni));
                listaRetur.Add(GetStructByEnum(EnumPeste.patruLuni));
                listaRetur.Add(GetStructByEnum(EnumPeste.cinciLuni));
                listaRetur.Add(GetStructByEnum(EnumPeste.saseLuni));
                listaRetur.Add(GetStructByEnum(EnumPeste.sapteLuni));
                listaRetur.Add(GetStructByEnum(EnumPeste.optLuni));
                listaRetur.Add(GetStructByEnum(EnumPeste.nouaLuni));
                listaRetur.Add(GetStructByEnum(EnumPeste.zeceLuni));
                listaRetur.Add(GetStructByEnum(EnumPeste.unspeLuni));
                listaRetur.Add(GetStructByEnum(EnumPeste.unAn));
                listaRetur.Add(GetStructByEnum(EnumPeste.doiAni));

                return listaRetur;
            }

            public static StructPeste GetStructByEnum(EnumPeste pIdEnum)
            {
                switch (pIdEnum)
                {
                    case EnumPeste.zeceZile:
                        return new StructPeste(pIdEnum, string.Concat(10, " ", CUtil.getText(1042)));
                    case EnumPeste.oSaptamana:
                        return new StructPeste(pIdEnum, string.Concat(1, " ", CUtil.getText(1039)));
                    case EnumPeste.douaSaptamani:
                        return new StructPeste(pIdEnum, string.Concat(2, " ", CUtil.getText(1041)));
                    case EnumPeste.treiSaptamani:
                        return new StructPeste(pIdEnum, string.Concat(3, " ", CUtil.getText(1041)));
                    case EnumPeste.saseSaptamani:
                        return new StructPeste(pIdEnum, string.Concat(6, " ", CUtil.getText(1041)));
                    case EnumPeste.optSaptamani:
                        return new StructPeste(pIdEnum, string.Concat(8, " ", CUtil.getText(1041)));
                    case EnumPeste.zeceSaptamani:
                        return new StructPeste(pIdEnum, string.Concat(10, " ", CUtil.getText(1041)));
                    case EnumPeste.doisprezeceSaptamani:
                        return new StructPeste(pIdEnum, string.Concat(12, " ", CUtil.getText(1041)));
                    case EnumPeste.oLuna:
                        return new StructPeste(pIdEnum, string.Concat(1, " ", CUtil.getText(1031)));
                    case EnumPeste.douaLuni:
                        return new StructPeste(pIdEnum, string.Concat(2, " ", CUtil.getText(1030)));
                    case EnumPeste.treiLuni:
                        return new StructPeste(pIdEnum, string.Concat(3, " ", CUtil.getText(1030)));
                    case EnumPeste.patruLuni:
                        return new StructPeste(pIdEnum, string.Concat(4, " ", CUtil.getText(1030)));
                    case EnumPeste.cinciLuni:
                        return new StructPeste(pIdEnum, string.Concat(5, " ", CUtil.getText(1030)));
                    case EnumPeste.saseLuni:
                        return new StructPeste(pIdEnum, string.Concat(6, " ", CUtil.getText(1030)));
                    case EnumPeste.sapteLuni:
                        return new StructPeste(pIdEnum, string.Concat(7, " ", CUtil.getText(1030)));
                    case EnumPeste.optLuni:
                        return new StructPeste(pIdEnum, string.Concat(8, " ", CUtil.getText(1030)));
                    case EnumPeste.nouaLuni:
                        return new StructPeste(pIdEnum, string.Concat(9, " ", CUtil.getText(1030)));
                    case EnumPeste.zeceLuni:
                        return new StructPeste(pIdEnum, string.Concat(10, " ", CUtil.getText(1030)));
                    case EnumPeste.unspeLuni:
                        return new StructPeste(pIdEnum, string.Concat(11, " ", CUtil.getText(1030)));
                    case EnumPeste.unAn:
                        return new StructPeste(pIdEnum, string.Concat(12, " ", CUtil.getText(1030)));
                    case EnumPeste.doiAni:
                        return new StructPeste(pIdEnum, string.Concat(2, " ", CUtil.getText(1048)));
                }

                return Empty;
            }

            public static DateTime GetData(EnumPeste pIdEnum)
            {
                switch (pIdEnum)
                {
                    case EnumPeste.zeceZile:
                        return DateTime.Today.AddDays(10);
                    case EnumPeste.oSaptamana:
                        return DateTime.Today.AddDays(7);
                    case EnumPeste.douaSaptamani:
                        return DateTime.Today.AddDays(14);
                    case EnumPeste.treiSaptamani:
                        return DateTime.Today.AddDays(21);
                    case EnumPeste.saseSaptamani:
                        return DateTime.Today.AddDays(42);
                    case EnumPeste.optSaptamani:
                        return DateTime.Today.AddDays(56);
                    case EnumPeste.zeceSaptamani:
                        return DateTime.Today.AddDays(70);
                    case EnumPeste.doisprezeceSaptamani:
                        return DateTime.Today.AddDays(84);
                    case EnumPeste.oLuna:
                        return DateTime.Today.AddMonths(1);
                    case EnumPeste.douaLuni:
                        return DateTime.Today.AddMonths(2);
                    case EnumPeste.treiLuni:
                        return DateTime.Today.AddMonths(3);
                    case EnumPeste.patruLuni:
                        return DateTime.Today.AddMonths(4);
                    case EnumPeste.cinciLuni:
                        return DateTime.Today.AddMonths(5);
                    case EnumPeste.saseLuni:
                        return DateTime.Today.AddMonths(6);
                    case EnumPeste.sapteLuni:
                        return DateTime.Today.AddMonths(7);
                    case EnumPeste.optLuni:
                        return DateTime.Today.AddMonths(8);
                    case EnumPeste.nouaLuni:
                        return DateTime.Today.AddMonths(9);
                    case EnumPeste.zeceLuni:
                        return DateTime.Today.AddMonths(10);
                    case EnumPeste.unspeLuni:
                        return DateTime.Today.AddMonths(11);
                    case EnumPeste.unAn:
                        return DateTime.Today.AddMonths(12);
                    case EnumPeste.doiAni:
                        return DateTime.Today.AddYears(2);
                }

                return CConstante.DataNula;
            }
        }

        #endregion

        #region Constructori

        public frmControlBox(CEnumerariComune.EnumTipDeschidere pTipDeschidere)
        {
            InitializeComponent();

            SeteazaPozitia();

            this.cboPeste.DataSource = StructPeste.GetLista();
            this.cboPeste.SelectedItem = null;

            this.lblPeste.Text = CUtil.Capitalizeaza(CUtil.getText(1045));
        }

        #endregion

        #region Proprietati

        public DateTime DataAleasa
        {
            get { return _dataAleasa; }
        }

        [Description("Data sub care nu permitem selectia unei date")]
        [Category("iDava")]
        public DateTime PragInferior
        {
            get { return this.lPragInferior; }
            set
            {
                this.lPragInferior = value;
                if (this.lPragInferior != CConstante.DataNula)
                    this.calData.MinDate = this.lPragInferior;
                else
                    this.calData.MinDate = new DateTime(1800, 02, 13, 13, 13, 13); //Convert.ToDateTime("01.01.1753");
            }
        }

        [Description("Data peste care nu permitem selectia unei date")]
        [Category("iDava")]
        public DateTime PragSuperior
        {
            get { return this.lPragSuperior; }
            set
            {
                this.lPragSuperior = value;
                if (this.lPragSuperior != CConstante.DataNula)
                    this.calData.MaxDate = this.lPragSuperior;
                else
                    this.calData.MaxDate = new DateTime(3113, 02, 13, 13, 13, 13);// Convert.ToDateTime("31.12.9998");
            }
        }

        [Description("Data selectata")]
        [Category("iDava")]
        public DateTime DataInitializare
        {
            get { return this.lDataInitializare; }
            set
            {
                this.lDataInitializare = value;
                if (this.lDataInitializare != CConstante.DataNula)
                {
                    this.calData.SelectionStart = this.lDataInitializare;
                    this.calData.SelectionEnd = this.lDataInitializare;
                }
                else
                {
                    this.calData.SelectionStart = DateTime.Today;
                    this.calData.SelectionEnd = DateTime.Today;
                }
            }
        }

        #endregion

        #region Metode

        public static DateTime GetData(Form pEcranParinte, DateTime pData)
        {
            using (frmControlBox ecran = new frmControlBox(CEnumerariComune.EnumTipDeschidere.StangaJos))
            {
                if (IHMUtile.DeschideEcran(pEcranParinte, ecran))
                    return ecran._dataAleasa;
            }

            return CConstante.DataNula;
        }

        private void calData_DateSelected(object sender, DateRangeEventArgs e)
        {
            this._dataAleasa = calData.SelectionStart;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        private void calData_SizeChanged(object sender, EventArgs e)
        {
            this.Width = this.calData.Width + 3;

            SeteazaPozitia();
        }

        #region Evenimente

        private void cboPeste_CerereUpdate(object psender, string proprietate, object sNouaValoare)
        {
            if (this.cboPeste.SelectedItem != null)
            {
                StructPeste peste = (StructPeste)this.cboPeste.SelectedItem;
                if (peste.IdEnum != EnumPeste.Nedefinit)
                {
                    this._dataAleasa = StructPeste.GetData(peste.IdEnum);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        #endregion
    }
}
