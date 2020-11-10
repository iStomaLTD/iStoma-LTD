using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ILL.iStomaLab;
using CDL.iStomaLab;
using System.Drawing;
using ILL.BLL.General;
using ILL.iStomaLab;
using static CDL.iStomaLab.CDefinitiiComune;
using CCL.iStomaLab;

namespace CCL.UI
{
    [DefaultEvent("SelectieUnicaEfectuata")]
    public partial class DataGridViewPersonalizat : DataGridView,
        CCL.UI.IMembriComuniControalePersonalizate
    {
        #region Declaratii Generale

        public event DataGridViewCellEventHandler SelectieUnicaEfectuata;
        public event SelectieMultiplaHandler SelectieMultiplaEfectuata;
        public event StergereHandler StergereLinie;
        public event StergereHandler EditareLinie;
        public event System.EventHandler CereRefresh;

        public delegate void StergereHandler(DataGridViewPersonalizat pDGVSender, int pIndexRand);
        public delegate void SelectieMultiplaHandler(DataGridViewPersonalizat pDGVSender, bool pToateSelectate);

        public static string lColoanaStergere = "colStergere";
        public static string lColoanaAdaugare = "colButonAdaugare";
        public static string lColoanaInchidere = "colInchisa";
        public static string lColoanaEditare = "colEditeaza";
        public static string lColoanaDeschideClasic = "colDeschideClasic";
        public static string lColoanaMotivInchidere = "colMotivInchidere";
        public static string lColoanaGestiuneDocumente = "colGestiuneDocumente";
        public static string lColoanaSelectieMultipla = "colSelectieMultipla";
        public static string lColoanaSelectieUnica = "colSelectieUnica";
        public static string lColoanaEmail = "colEmail";
        public const string _Coloana_Denumire = "colDenumire";

        public const int _SLatimeButonDeschidere = 40;

        public static bool _SecurizeazaDateContact = false;
        public static EnumModAfisareTelefonAgenda _ModAfisareTelefonAgenda = EnumModAfisareTelefonAgenda.GrupuriDouaSfCuPunct;

        public const string _Coloana_Telefon = "colTelefon";
        public const string _Coloana_Telefon2 = "colTelefon2";
        public const string _Coloana_AdresaMail = "colAdresaMail";
        public const string _Coloana_AdresaMailCC = "colAdresaMailCC";

        public static string _Header_Coloana_Telefon = "Mobil";
        public static string _Header_Coloana_AdresaMail = "Email";
        public static string _Header_Coloana_Telefon2 = "Fix";
        public static string _Header_Coloana_AdresaMailCC = "CC Email";

        private bool lPermiteSortarea = true;
        private bool lSePermiteMultiBifa = true;
        private bool lFullScreen = false;
        private bool lSeIncarca = false;
        private int lIndexColoanaSelectie = 0;
        private static Color _CuloareDinOficiu = Color.White;
        private bool lGestioneazaAlternantaLaSortare = false;

        private static string _HeaderDenumire = "Denumire";
        private static string _HeaderInchidere = "Închis";
        private static string _HeaderMotivInchidere = "Motiv închidere";
        private static string _ToolTipSelecteaza = "Selectează";

        private static string _ToolTipAccesDetalii = "Acces detalii";
        private static string _ToolTipDocumente = "Documente";
        private static string _HeaderStergere = "Stergere";
        private static string _HeaderEmail = "Email";

        private int lIndexUltimaLinieBifata = 0; //pentru a putea gestiona selectia cu SHIFT

        #endregion

        #region Enumerari si Structuri

        public enum EnumTipColoana
        {
            SelectieUnica = 1,
            SelectieMultipla = 2,
            Editare = 3,
            Inchidere = 4,
            MotivInchidere = 5,
            GestiuneDocumente = 6,
            Stergere = 7,
            Email = 8,
            Denumire = 9,
            Adaugare = 10,
            DeschideClasic = 11,
            Star = 12,
            Validare = 13
        }

        #endregion

        #region Proprietati

        public DataGridViewRow SelectedRow
        {
            get
            {
                if (this.SelectedRows.Count > 0) return this.SelectedRows[0];

                return null;
            }
        }

        [Browsable(false)]
        [DefaultValue(false)]
        public bool GestioneazaAlternantaLaSortare
        {
            get { return this.lGestioneazaAlternantaLaSortare; }
            set { this.lGestioneazaAlternantaLaSortare = value; }
        }

        [Browsable(false)]
        public bool SeIncarca
        {
            get { return this.lSeIncarca; }
            set { this.lSeIncarca = value; }
        }

        [Description("Numele coloanei de inchidere")]
        [Category("iDava")]
        [DefaultValue("colInchisa")]
        [Browsable(false)]
        public static string ColoanaInchidere
        {
            get { return lColoanaInchidere; }
            private set { lColoanaInchidere = value; }
        }

        [Description("Numele coloanei de editare")]
        [Category("iDava")]
        [DefaultValue("colEditeaza")]
        [Browsable(false)]
        public static string ColoanaEditare
        {
            get { return lColoanaEditare; }
            private set { lColoanaEditare = value; }
        }

        [Description("Numele coloanei ce contine motivul de inchidere")]
        [Category("iDava")]
        [DefaultValue("ColoanaMotivInchidere")]
        [Browsable(false)]
        public static string ColoanaMotivInchidere
        {
            get { return lColoanaMotivInchidere; }
            private set { lColoanaMotivInchidere = value; }
        }

        [Description("Textul zonei de text")]
        [Category("iDava")]
        public override string Text
        {
            get
            {
                if (this.CurrentCell != null)
                {
                    if (this.CurrentCell.IsInEditMode)
                        return Convert.ToString(this.CurrentCell.EditedFormattedValue);
                    else
                        return Convert.ToString(this.CurrentCell.Value);
                }
                else
                    return string.Empty;
            }
            set
            {
                if (this.CurrentCell != null)
                {
                    if (this.EditingControl != null)
                    {
                        ((DataGridViewTextBoxEditingControl)this.EditingControl).Text = value;

                    }
                    else
                        this.CurrentCell.Value = value;
                }
            }
        }

        public void ScrollToBottom()
        {
            if (this.RowCount > 5)
                this.FirstDisplayedScrollingRowIndex = this.RowCount - 1;
        }

        #endregion

        #region Constructor si Initializare

        public static void InitializeazaLimba(string pHeaderDenumire, string pHeaderInchidere, string pHeaderMotivInchidere,
            string pToolTipSelecteaza, string pToolTipAccesDetalii, string pToolTipDocumente, string pHeaderStergere,
            string pHeaderEmail, string pHeaderMobil, string pHeaderFix, string pHeaderAdresaEmail, string pHeaderCCEmail, bool pSecurizeazaDateContact, EnumModAfisareTelefonAgenda pModAfisareTelefonAgenda)
        {
            _HeaderDenumire = pHeaderDenumire;
            _HeaderInchidere = pHeaderInchidere;
            _HeaderMotivInchidere = pHeaderMotivInchidere;
            _ToolTipSelecteaza = pToolTipSelecteaza;
            _ToolTipAccesDetalii = pToolTipAccesDetalii;
            _ToolTipDocumente = pToolTipDocumente;
            _HeaderStergere = pHeaderStergere;
            _HeaderEmail = pHeaderEmail;
            _Header_Coloana_Telefon = pHeaderMobil;
            _Header_Coloana_Telefon2 = pHeaderFix;
            _Header_Coloana_AdresaMail = pHeaderAdresaEmail;
            _Header_Coloana_AdresaMailCC = pHeaderCCEmail;
            _SecurizeazaDateContact = pSecurizeazaDateContact;
            _ModAfisareTelefonAgenda = pModAfisareTelefonAgenda;
        }

        public DataGridViewPersonalizat()
        {
            SeteazaDoubleBuffer();

            SeteazaProprietatileStandard();

            AdaugaMeniuContextual();
        }

        public DataGridViewPersonalizat(IContainer container)
        {
            container.Add(this);

            SeteazaDoubleBuffer();

            SeteazaProprietatileStandard();

            AdaugaMeniuContextual();
        }

        public string GetTabelHTML(List<string> pListaColoane, string pTitlu, string pHeaderTabel, string pFooterTabel)
        {
            System.Text.StringBuilder textRetur = new System.Text.StringBuilder();

            textRetur.Append("<h2 style='text-align: center;'>");
            textRetur.Append(pTitlu);
            textRetur.Append("</h2>");

            textRetur.Append("<table cellpadding='2'>");

            textRetur.Append("<tr style='font-weight:bold;'>");
            foreach (string numeColoana in pListaColoane)
            {
                if (this.Columns[numeColoana] is DataGridViewCheckBoxColumn)
                    textRetur.Append(string.Concat("<td style='width:", this.Columns[numeColoana].Width, "px; text-align:center;'>"));
                else
                    textRetur.Append(string.Concat("<td style='width:", this.Columns[numeColoana].Width, "px;'>"));
                textRetur.Append(this.Columns[numeColoana].HeaderText);
                textRetur.Append("</td>");
            }
            textRetur.Append("</tr>");

            foreach (DataGridViewRow item in GetListaLiniiSelectate())
            {
                textRetur.Append("<tr>");

                foreach (string numeColoana in pListaColoane)
                {
                    if (this.Columns[numeColoana] is DataGridViewCheckBoxColumn)
                    {
                        textRetur.Append("<td style='text-align:center'>");
                        if (Convert.ToBoolean(item.Cells[numeColoana].FormattedValue))
                            textRetur.Append(CUtil.getText(1));
                        else
                            textRetur.Append(CUtil.getText(2));
                    }
                    else
                    {
                        textRetur.Append("<td>");
                        textRetur.Append(item.Cells[numeColoana].FormattedValue);
                    }

                    textRetur.Append("</td>");
                }

                textRetur.Append("</tr>");
            }

            textRetur.Append("</table>");

            return textRetur.ToString();
        }

        private void SeteazaProprietatileStandard()
        {
            //Setam proprietatile standard
            this.lFullScreen = false;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = false;
            this.AllowUserToResizeColumns = true;
            this.AllowUserToResizeRows = false;
            this.RowHeadersVisible = false;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BackgroundColor = _CuloareDinOficiu;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.MultiSelect = false;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            //this.AplicaFactorDPI();
        }

        public void AplicaFactorDPI()
        {
            //this.Location = new System.Drawing.Point(Convert.ToInt32(this.Location.X * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X), Convert.ToInt32(this.Location.Y * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_Y));
            this.Width = Convert.ToInt32(this.Width * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
            this.Height = Convert.ToInt32(this.Height * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_Y);
        }

        private void SeteazaDoubleBuffer()
        {
            // this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        #endregion

        #region Metode private

        private void simuleazaClickCelula(int pIndexColoana, int pIndexLinie)
        {
            //if (this.OnCellClick != null)
            OnCellMouseClick(new DataGridViewCellMouseEventArgs(pIndexColoana, pIndexLinie, MousePosition.X, MousePosition.Y,
                new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 2, MousePosition.X, MousePosition.Y, 0)));
        }

        private string getNumeColoanaByTip(EnumTipColoana pTipColoana)
        {
            switch (pTipColoana)
            {
                case EnumTipColoana.Adaugare:
                    return lColoanaAdaugare;
                case EnumTipColoana.SelectieUnica:
                    return lColoanaSelectieUnica;
                case EnumTipColoana.SelectieMultipla:
                    return lColoanaSelectieMultipla;
                case EnumTipColoana.Editare:
                    return lColoanaEditare;
                case EnumTipColoana.Inchidere:
                    return lColoanaInchidere;
                case EnumTipColoana.MotivInchidere:
                    return lColoanaMotivInchidere;
                case EnumTipColoana.GestiuneDocumente:
                    return lColoanaGestiuneDocumente;
                case EnumTipColoana.Email:
                    return lColoanaEmail;
                case EnumTipColoana.Stergere:
                    return lColoanaStergere;
            }
            return string.Empty;
        }

        private void AdaugaMeniuContextual()
        {
            //Adaugam meniul contextual
            this.ContextMenuStrip = ControaleCreateDinamic.GetMeniuContextualZonaText();
        }

        private string getTextDinTag()
        {
            if (this.Tag != null)
                return Convert.ToString(this.Tag);
            return string.Empty;
        }

        private bool cereStergereaLiniei(int pIndexLinie)
        {
            if (this.StergereLinie != null && pIndexLinie >= 0)
            {
                StergereLinie(this, pIndexLinie);

                return true;
            }

            return false;
        }

        private bool cereEditareaLiniei(int pIndexLinie)
        {
            if (this.EditareLinie != null && pIndexLinie >= 0)
            {
                EditareLinie(this, pIndexLinie);

                return true;
            }

            return false;
        }

        #endregion

        #region Metode publice

        public static DataGridViewTextBoxColumn CreazaColoana()
        {
            DataGridViewTextBoxColumn colValoare = new DataGridViewTextBoxColumn();
            colValoare.MinimumWidth = 100;

            //coloana pentru tostring-ul obiectului (in cazul in care nu avem proprietati cu acest atribut)
            colValoare.Name = "colValoare";
            colValoare.HeaderText = _HeaderDenumire;
            colValoare.ReadOnly = true;
            colValoare.SortMode = DataGridViewColumnSortMode.Automatic;
            colValoare.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            return colValoare;
        }

        private string lColoanaValoareNumerica = string.Empty;
        public void setColoanaValoareNumericaExport(string pNumeColoana)
        {
            this.lColoanaValoareNumerica = pNumeColoana;
        }

        public bool esteColoanaNumericaExport(string pNumeColoana)
        {
            return !string.IsNullOrEmpty(pNumeColoana) && this.lColoanaValoareNumerica.Equals(pNumeColoana);
        }

        private string lTitluDGV;
        private string lFooterDGV;
        private string lHeaderDGV;
        public string GetTitlu()
        {
            if (string.IsNullOrEmpty(this.lTitluDGV))
            {
                if (this.Tag != null)
                    return this.Tag.ToString();
            }

            return this.lTitluDGV;
        }

        public void SetTitlu(string pTitlu)
        {
            this.lTitluDGV = pTitlu;
        }

        public string GetFooter()
        {
            return this.lFooterDGV;
        }

        public void SetFooter(string pFooterDGV)
        {
            this.lFooterDGV = pFooterDGV;
        }

        public string GetHeader()
        {
            return this.lHeaderDGV;
        }

        public void SetHeader(string pHeaderDGV)
        {
            this.lHeaderDGV = pHeaderDGV;
        }

        public void Centreaza(string pNumeColoana)
        {
            this.Columns[pNumeColoana].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.Columns[pNumeColoana].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void MutaRandulSelectatInJos()
        {
            if (this.SelectedCells.Count <= 0) return;

            int totalRows = this.Rows.Count;
            // get index of the row for the selected cell
            int rowIndex = this.SelectedCells[0].OwningRow.Index;
            if (rowIndex == totalRows - 1)
                return;
            // get index of the column for the selected cell
            int colIndex = this.SelectedCells[0].OwningColumn.Index;
            DataGridViewRow selectedRow = this.Rows[rowIndex];
            this.Rows.Remove(selectedRow);
            this.Rows.Insert(rowIndex + 1, selectedRow);
            this.ClearSelection();
            this.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
        }

        public void MutaRandulSelectatInSus()
        {
            if (this.SelectedCells.Count <= 0) return;

            int totalRows = this.Rows.Count;
            // get index of the row for the selected cell
            int rowIndex = this.SelectedCells[0].OwningRow.Index;
            if (rowIndex == 0)
                return;
            // get index of the column for the selected cell
            int colIndex = this.SelectedCells[0].OwningColumn.Index;
            DataGridViewRow selectedRow = this.Rows[rowIndex];
            this.Rows.Remove(selectedRow);
            this.Rows.Insert(rowIndex - 1, selectedRow);
            this.ClearSelection();
            this.Rows[rowIndex - 1].Cells[colIndex].Selected = true;
        }

        public void SeteazaFontIngrosat(Font pFontNormal, string pNumeColoana)
        {
            if (this.Columns.Contains(pNumeColoana))
                SeteazaFontIngrosat(pFontNormal, this.Columns[pNumeColoana]);
        }

        public void SeteazaFontIngrosat(DataGridViewRow pRand, string pNumeColoana)
        {
            if (this.Columns.Contains(pNumeColoana))
            {
                pRand.Cells[pNumeColoana].Style.Font = GetFontBold();
            }
        }

        private Font lFontIngrosat = null;
        public Font GetFontBold()
        {
            if (this.lFontIngrosat == null)
                this.lFontIngrosat = new Font(this.Font, FontStyle.Bold);

            return this.lFontIngrosat;
        }

        private Font lFontItalic = null;
        public Font GetFontItalic()
        {
            if (this.lFontItalic == null)
                this.lFontItalic = new Font(this.Font, FontStyle.Italic);

            return this.lFontItalic;
        }

        private Font lFontTaiat = null;
        public Font GetFontTaiat()
        {
            if (this.lFontTaiat == null)
                this.lFontTaiat = new Font(this.Font, FontStyle.Strikeout);

            return this.lFontTaiat;
        }

        public static void SeteazaFontIngrosat(Font pFontNormal, DataGridViewColumn pColoana)
        {
            Font fontIgrosat = new Font(pFontNormal, FontStyle.Bold);
            pColoana.HeaderCell.Style.Font = fontIgrosat;
            pColoana.DefaultCellStyle.Font = fontIgrosat;
        }

        public bool ContineColoana(EnumTipColoana pTipColoana)
        {
            return ContineColoana(getNumeColoanaByTip(pTipColoana));
        }

        public bool ContineColoana(string pNumeColoana)
        {
            return this.Columns.Contains(pNumeColoana);
        }

        public void BifeazaCelula(DataGridViewRow pRand, EnumTipColoana pTipColoana)
        {
            BifeazaCelula(pRand, getNumeColoanaByTip(pTipColoana));
        }

        public void BifeazaCelula(DataGridViewRow pRand, string pNumeColoana)
        {
            if (!string.IsNullOrEmpty(pNumeColoana) && this.Columns.Contains(pNumeColoana))
                pRand.Cells[pNumeColoana].Value = true;
        }

        public void PermiteSortarea(bool pPermite)
        {
            this.lPermiteSortarea = pPermite;
        }

        /// <summary>
        /// La multiselect bifam sau nu
        /// </summary>
        /// <param name="pPermite"></param>
        public void SePermiteMultiBifa(bool pPermite)
        {
            this.lSePermiteMultiBifa = pPermite;
        }

        public void incepeIncarcare()
        {
            this.lSeIncarca = true;
        }

        public void finalizeazaIncarcare()
        {
            this.lSeIncarca = false;
        }

        public int FiltreazaDupaText(string pTextGeneral)
        {
            return FiltreazaDupaText(pTextGeneral, string.Empty);
        }

        public int FiltreazaDupaText(string pTextGeneral, string pNumeColoana)
        {
            bool areTextGeneral = !string.IsNullOrEmpty(pTextGeneral);

            bool randVizibil = false;
            int numarRandVizibil = 0;
            //IPreferinteDGV pref = IHMUtile.GetPreferinteUtilizatorConectat();
            Color culAlter = Color.WhiteSmoke;
            Color culLinieNormala = Color.White;
            for (int i = 0; i < this.Rows.Count; i++)
            {
                randVizibil = (!areTextGeneral || (areTextGeneral && DataGridViewPersonalizat.RandulContineValoarea(this.Rows[i], pTextGeneral, pNumeColoana)));

                this.Rows[i].Visible = randVizibil;
                if (randVizibil)
                {
                    numarRandVizibil++;
                    this.Rows[i].DefaultCellStyle.BackColor = (numarRandVizibil % 2 != 0) ? culLinieNormala : culAlter;
                }

                if (this.Columns.Contains(lColoanaSelectieMultipla))
                {
                    this.Rows[i].Cells[lColoanaSelectieMultipla].Value = false;
                }
            }
            return numarRandVizibil;
        }

        public void RemoveRowsAt(List<int> pListaIndecsiDeScos)
        {
            foreach (var index in pListaIndecsiDeScos)
            {
                this.Rows.RemoveAt(index);
            }
        }

        public void SelecteazaLinie(int pIndex)
        {
            if (pIndex > 0 && this.Rows.Count > pIndex)
            {
                this.FirstDisplayedScrollingRowIndex = pIndex;
                this.Rows[pIndex].Selected = true;
            }
        }

        public void SelecteazaLinie(bool pUrmatoarea)
        {
            if (this.Rows.Count > 0)
            {
                if (this.SelectedRows.Count == 1)
                {
                    int indexActual = this.SelectedRows[0].Index;

                    if (pUrmatoarea)
                    {
                        if (this.Rows.Count > indexActual + 1)
                        {
                            //Doar liniile vizibile pot fi selectate
                            for (int i = indexActual + 1; i < this.Rows.Count; i++)
                            {
                                if (this.Rows[i].Visible)
                                {
                                    this.ClearSelection();
                                    this.Rows[i].Selected = true;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (indexActual > 0)
                        {
                            //Doar liniile vizibile pot fi selectate
                            for (int i = indexActual - 1; i > 0; i--)
                            {
                                if (this.Rows[i].Visible)
                                {
                                    this.ClearSelection();
                                    this.Rows[i].Selected = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    //Doar liniile vizibile pot fi selectate
                    for (int i = 0; i < this.Rows.Count; i++)
                    {
                        if (this.Rows[i].Visible)
                        {
                            this.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }
        }

        public static void SeteazaAlerta(DataGridViewRow pRand)
        {
            pRand.DefaultCellStyle.ForeColor = IHMStilAplicatie._SDGVTextAlerta;// pPreferinte.CuloareDGVTextAlerta;
            pRand.DefaultCellStyle.SelectionForeColor = IHMStilAplicatie._SDGVTextAlerta; // pPreferinte.CuloareDGVTextAlertaRandSelectat;
        }

        public static void SeteazaAlerta(DataGridViewRow pRand, string pNumeColoana)
        {
            pRand.Cells[pNumeColoana].Style.ForeColor = IHMStilAplicatie._SDGVTextAlerta;
            pRand.Cells[pNumeColoana].Style.SelectionForeColor = IHMStilAplicatie._SDGVTextAlerta;
        }

        public static void SeteazaOK(DataGridViewRow pRand, string pNumeColoana)
        {
            pRand.Cells[pNumeColoana].Style.ForeColor = IHMStilAplicatie._SDGVTextOK;
            pRand.Cells[pNumeColoana].Style.SelectionForeColor = IHMStilAplicatie._SDGVTextOK;
        }

        public static void IndeparteazaAlerta(DataGridViewRow pRand, string pNumeColoana)
        {
            pRand.Cells[pNumeColoana].Style.ForeColor = pRand.DefaultCellStyle.ForeColor;
            pRand.Cells[pNumeColoana].Style.SelectionForeColor = pRand.DefaultCellStyle.ForeColor;
        }

        /// <summary>
        /// Nu are rost sa luam denumirea a mai mult de 5 parinti pentru a identifica unic o lista
        /// </summary>
        /// <returns></returns>
        public string GetDenumireUnica()
        {
            string nume = this.Name;

            Control parinte = this.Parent;
            int i = 0;
            while (parinte != null && i < 4)
            {
                if (!string.IsNullOrEmpty(parinte.Name))
                    nume = string.Concat(parinte.Name, "_", nume);
                else
                    nume = string.Concat(parinte.GetType().Name, "_", nume);

                parinte = parinte.Parent;

                i += 1;
            }

            return nume;
        }

        public event System.EventHandler IncepeActiune;
        public event System.EventHandler FinalizeazaActiune;
        public void AnuntaIncepereActiune(EnumTipActiuneControl pTipActiune)
        {
            try
            {
                if (IncepeActiune != null)
                    IncepeActiune(this, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AnuntaFinalizareActiune(EnumTipActiuneControl pTipActiune)
        {
            try
            {
                if (FinalizeazaActiune != null)
                    FinalizeazaActiune(this, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Contains(ICheie pObiect)
        {
            if (pObiect == null) return false;

            foreach (DataGridViewRow rand in this.Rows)
            {
                if (rand.Tag != null && rand.Tag.Equals(pObiect))
                    return true;
            }

            return false;
        }

        public void InitDoarToStringFaraHeader()
        {
            this.IncepeConstructieColoane();

            this.AdaugaColoanaText(_Coloana_Denumire, "", 100, true, DataGridViewColumnSortMode.NotSortable);

            this.FinalizeazaConstructieColoane();

            this.AscundeHeader();
        }

        public void ConstruiesteRanduriToString<T>(List<T> pLista)
        {
            InitDoarToStringFaraHeader();

            this.IncepeContructieRanduri();

            DataGridViewRow rand = null;
            foreach (T item in pLista)
            {
                rand = this.AdaugaRandNou();
                rand.Tag = item;
                rand.Cells[_Coloana_Denumire].Value = item.ToString();
            }

            this.FinalizeazaContructieRanduri();
        }

        public void Goleste()
        {
            if (this.Rows.Count > 0)
                this.Rows.Clear();
        }

        public void AscundeHeader()
        {
            this.ColumnHeadersVisible = false;
        }

        public void AscundeDataGridView()
        {
            this.Visible = false;
        }

        public bool AcceptaActiunea(EnumTipActiuneControl pTipActiune)
        {
            switch (pTipActiune)
            {
                case EnumTipActiuneControl.Diacritice:
                    return (this.CurrentCell != null && this.CurrentCell.IsInEditMode && this.CurrentCell.ValueType != typeof(Boolean));
                case EnumTipActiuneControl.Undo:
                    return false;
                case EnumTipActiuneControl.Cautare:
                    return true;
                case EnumTipActiuneControl.Decupare:
                    return this.CurrentCell != null && this.CurrentCell.IsInEditMode && this.CurrentCell.Value != null && this.CurrentCell.ValueType != typeof(Boolean);
                case EnumTipActiuneControl.Inserare:
                    return this.CurrentCell != null && this.CurrentCell.IsInEditMode && this.CurrentCell.ValueType != typeof(Boolean);
                case EnumTipActiuneControl.Export:
                case EnumTipActiuneControl.TrimitePeMail:
                    return true;
                case EnumTipActiuneControl.Printare:
                    return true;
                case EnumTipActiuneControl.CopiereTabel:
                    return true;
                case EnumTipActiuneControl.SelectareText:
                    return this.CurrentCell != null && this.CurrentCell.IsInEditMode;
                case EnumTipActiuneControl.ValidareCautare:
                    return true;
                case EnumTipActiuneControl.FullScreen:
                    return true;
                case EnumTipActiuneControl.Refresh:
                    return this.CereRefresh != null;
                case EnumTipActiuneControl.AscundeColoane:
                    return this.Columns.Count > 2; //Sa avem macar 3 coloane pentru a putea ascunde ceva - altfel nu are rost
                case EnumTipActiuneControl.RevenireLaAfisajulStandard:
                    return this.Columns.Count > 2 && this.lIdLista > 0; //Sa avem macar 3 coloane pentru a putea ascunde ceva - altfel nu are rost
            }
            return false;
        }

        public void ExecutaActiunea(EnumTipActiuneControl pTipActiune)
        {
            switch (pTipActiune)
            {
                case EnumTipActiuneControl.Refresh:
                    if (this.CereRefresh != null)
                        CereRefresh(this, null);
                    break;
                case EnumTipActiuneControl.AscundeColoane:
                    //if (CCL.UI.IHMUtile._ComunicareIHM.GestioneazaColoaneLista(this))
                    //    ExecutaActiunea(EnumTipActiuneControl.Refresh);
                    break;
                case EnumTipActiuneControl.RevenireLaAfisajulStandard:
                    //if (CCL.UI.IHMUtile._ComunicareIHM.RevenireLaAfisajulStandard(this.lIdLista))
                    //{
                    //    this.lIdLista = 0;
                    //    ExecutaActiunea(EnumTipActiuneControl.Refresh);
                    //}
                    break;
                case EnumTipActiuneControl.Export:
                    ExportToCSV();
                    break;
                case EnumTipActiuneControl.Printare:
                    PrintPreview();
                    break;
                case EnumTipActiuneControl.TrimitePeMail:
                    TrimitePeEmail();
                    break;
                case EnumTipActiuneControl.CopiereTabel:
                    CopiereTabel();
                    break;
                case EnumTipActiuneControl.ValidareCautare:
                    DataGridViewRow randSelectat = this.SelectedRow;
                    if (randSelectat != null)
                        OnCellDoubleClick(new DataGridViewCellEventArgs(0, randSelectat.Index));
                    break;
                case EnumTipActiuneControl.FullScreen:
                    //Maximizam sau minimizam
                    if (this.lFullScreen)
                    {
                        IHMUtile.InchideFormularParinte(this);
                        this.lFullScreen = false;
                    }
                    else
                    {
                        this.lFullScreen = true;
                        seteazaValoriPozitionareActuala();
                        IHMUtile.ShowFullScreen(this, Convert.ToString(this.Tag));
                        this.lFullScreen = false;
                    }
                    break;
            }
        }

        Point locatieInitiala = Point.Empty;
        Size marimeInitiala = Size.Empty;
        AnchorStyles ancorareInitiala = AnchorStyles.None;
        DockStyle docareInitiala = DockStyle.None;

        public void seteazaValoriPozitionareActuala()
        {
            this.locatieInitiala = this.Location;
            this.marimeInitiala = this.Size;
            this.ancorareInitiala = this.Anchor;
            this.docareInitiala = this.Dock;
        }

        public void revinoLaUltimeleSetariSalvate()
        {
            this.Location = this.locatieInitiala;
            this.Size = this.marimeInitiala;
            this.Anchor = this.ancorareInitiala;
            this.Dock = this.docareInitiala;
        }

        public void CopiereTabel()
        {

        }

        public void ExportToCSV()
        {
            if (IHMUtile._ComunicareIHM != null)
                IHMUtile._ComunicareIHM.ExportaDGV(this);
        }

        public void TrimitePeEmail()
        {
            if (IHMUtile._ComunicareIHM != null)
                IHMUtile._ComunicareIHM.TrimiteDGVPeEmail(this);
        }

        public void Print()
        {
            if (IHMUtile._ComunicareIHM != null)
                IHMUtile._ComunicareIHM.ImprimaDGV(this);
        }

        public void PrintPreview()
        {
            IHMUtile._ComunicareIHM.ImprimaDGV(this);
            //CCL.UI.IHMUtile.PrintPreviewDGV(this, getTextDinTag());
        }

        public void GestioneazaAlternanta(DataGridViewCellMouseEventArgs e)
        {
            if (this.Columns[e.ColumnIndex].SortMode != DataGridViewColumnSortMode.NotSortable)
            {
                GestioneazaAlternanta();
            }
        }

        public void GestioneazaAlternanta()
        {
            IPreferinteDGV pref = IHMUtile.getPreferinteUtilizatorConectat();

            Color culoareAlternanta = IHMStilAplicatie._SDGVFundalAlternant; //this.AlternatingRowsDefaultCellStyle.BackColor;
            Color culoareNormala = IHMStilAplicatie._SDGVFundalNormal; //this.DefaultCellStyle.BackColor;
            //if (pref != null)
            //{
            //    culoareAlternanta = pref.CuloareDGVLinieAlernanta;
            //    culoareNormala = pref.CuloareDGVLinie;
            //}

            int numarRandVizibil = 0;
            bool randVizibil = false;
            for (int i = 0; i < this.Rows.Count; i++)
            {
                randVizibil = this.Rows[i].Visible;
                if (randVizibil)
                {
                    numarRandVizibil++;
                    this.Rows[i].DefaultCellStyle.BackColor = (numarRandVizibil % 2 != 0) ? culoareNormala : culoareAlternanta;
                }
            }
        }

        public static void SeteazaCuloareFundal(DataGridViewRow pRand, Color pCuloareFundal)
        {
            pRand.DefaultCellStyle.BackColor = pCuloareFundal;
        }

        public static void SeteazaCuloareFundalCelula(DataGridViewRow pRand, string pNumeCelula, Color pCuloareFundal)
        {
            pRand.Cells[pNumeCelula].Style.BackColor = pCuloareFundal;
            pRand.Cells[pNumeCelula].Style.SelectionBackColor = pCuloareFundal;
        }

        public static void SeteazaCuloareTextCelula(DataGridViewRow pRand, string pNumeCelula, Color pCuloareText)
        {
            pRand.Cells[pNumeCelula].Style.ForeColor = pCuloareText;
            pRand.Cells[pNumeCelula].Style.SelectionForeColor = pCuloareText;
        }

        public static bool RandulContineValoarea(DataGridViewRow pRand, string pTextGeneral)
        {
            return RandulContineValoarea(pRand, pTextGeneral, string.Empty);
        }

        public static bool RandulContineValoarea(DataGridViewRow pRand, string pTextGeneral, string pNumeColoana)
        {
            pTextGeneral = CUtil.InlocuiesteDiacritice(pTextGeneral).ToUpper();

            if (string.IsNullOrEmpty(pNumeColoana))
            {
                foreach (DataGridViewCell Celula in pRand.Cells)
                {
                    if (CUtil.InlocuiesteDiacritice(Convert.ToString(Celula.Value)).ToUpper().Contains(pTextGeneral))
                        return true;
                }
            }
            else
            {
                if (pRand.DataGridView.Columns.Contains(pNumeColoana))
                {
                    if (CUtil.InlocuiesteDiacritice(Convert.ToString(pRand.Cells[pNumeColoana].Value)).ToUpper().Contains(pTextGeneral))
                        return true;
                }
            }

            return false;
        }

        public void ForteazaValoareaCelulei(int pRowIndex, int pColumnIndex, bool pValoarea)
        {
            this.EndEdit();
            this[pColumnIndex, pRowIndex].Value = pValoarea;
        }

        public void VizibilitateColoana(EnumTipColoana pTipColoana, bool pColoanaVizibila)
        {
            VizibilitateColoana(getNumeColoanaByTip(pTipColoana), pColoanaVizibila);

            if (pColoanaVizibila && this.Rows.Count > 0)
            {
                //incarcam celulele coloanei devenita vizibila
                if (pTipColoana == EnumTipColoana.SelectieUnica)
                {
                    InitColoanaSelectieUnica();
                }
            }
        }

        public void VizibilitateColoana(string pNumeColoana, bool pVizibila)
        {
            if (!string.IsNullOrEmpty(pNumeColoana) && this.Columns.Contains(pNumeColoana))
                this.Columns[pNumeColoana].Visible = pVizibila;
        }

        public void IncepeConstructieColoane(IPreferinteDGV xPreferinteUtilizator)
        {
            this.lSeIncarca = true;

            if (xPreferinteUtilizator != null)
            {
                this.IncepeConstructieColoane(xPreferinteUtilizator.CuloareDGVLinieAlernanta);
                this.BackgroundColor = IHMStilAplicatie._SDGVFundal;
                this.DefaultCellStyle.BackColor = IHMStilAplicatie._SDGVFundalNormal;
                this.DefaultCellStyle.ForeColor = IHMStilAplicatie._SDGVCuloareDGVTextLinieNormala;
                this.AlternatingRowsDefaultCellStyle.BackColor = IHMStilAplicatie._SDGVFundalAlternant;
                this.AlternatingRowsDefaultCellStyle.ForeColor = IHMStilAplicatie._SDGVCuloareDGVTextLinieAlternanta;
                this.RowsDefaultCellStyle.SelectionBackColor = IHMStilAplicatie._SDGVCuloareDGVFundalLinieSelectata;
                this.RowsDefaultCellStyle.SelectionForeColor = IHMStilAplicatie._SDGVCuloareDGVTextLinieSelectata;
                this.ForeColor = IHMStilAplicatie._SDGVCuloareDGVTextLinieNormala;
            }
            else
                this.IncepeConstructieColoane(IHMStilAplicatie._SDGVFundalAlternant);
        }

        public void IncepeConstructieColoane()
        {
            //if (IHMUtile._Translator != null)
            //    IncepeConstructieColoane(IHMUtile._Translator.getPreferinteUtilizatorConectat());
            //else
            IncepeConstructieColoane(IHMStilAplicatie._SDGVFundalAlternant);
        }

        internal void IncepeConstructieColoane(Color pCuloareLinieAlternant)
        {
            this.lSeIncarca = true;

            this.SuspendLayout();
            this.Columns.Clear();
            this.AranjeazaProprietati(pCuloareLinieAlternant);

            this.BackgroundColor = IHMStilAplicatie._SDGVFundal;
            this.DefaultCellStyle.BackColor = IHMStilAplicatie._SDGVFundalNormal;
            this.DefaultCellStyle.ForeColor = IHMStilAplicatie._SDGVCuloareDGVTextLinieNormala;
            this.AlternatingRowsDefaultCellStyle.BackColor = IHMStilAplicatie._SDGVFundalAlternant;
            this.AlternatingRowsDefaultCellStyle.ForeColor = IHMStilAplicatie._SDGVCuloareDGVTextLinieAlternanta;
            this.RowsDefaultCellStyle.SelectionBackColor = IHMStilAplicatie._SDGVCuloareDGVFundalLinieSelectata;
            this.RowsDefaultCellStyle.SelectionForeColor = IHMStilAplicatie._SDGVCuloareDGVTextLinieSelectata;
            this.ForeColor = IHMStilAplicatie._SDGVCuloareDGVTextLinieNormala;

            this.GestioneazaAlternantaLaSortare = true;
            this.AllowUserToResizeColumns = true;
            this.AllowUserToOrderColumns = true;

            this.lSeIncarca = false;
        }

        public void FinalizeazaConstructieColoane()
        {
            //Permitem selectia multipla si la nivelul randurilor -> rolul va fi de a bifa automat casuta de selectie multipla
            if (this.Columns.Contains(lColoanaSelectieMultipla) && this.Columns[lColoanaSelectieMultipla].Visible)
            {
                this.MultiSelect = true;
            }

            this.ResumeLayout();
        }

        private void bifeazaMultiSelect()
        {
            if (!this.lSePermiteMultiBifa) return;

            foreach (DataGridViewRow item in this.Rows)
            {
                if (!item.Cells[lColoanaSelectieMultipla].ReadOnly && Convert.ToBoolean(item.Cells[lColoanaSelectieMultipla].Value) != item.Selected)
                    item.Cells[lColoanaSelectieMultipla].Value = item.Selected;
            }

            //Pentru ca selectia sa fie vizibila
            this.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        public void IncepeContructieRanduri()
        {
            this.lSeIncarca = true;
            this.Visible = false;
            this.SuspendLayout();
            this.Rows.Clear();
        }

        public void IncepeContructieRanduri(bool pAfiseazaElemInchise)
        {
            IncepeContructieRanduri();

            this.VizibilitateColoana(EnumTipColoana.MotivInchidere, pAfiseazaElemInchise);
        }

        public void IncepeContructieRanduri(bool pSelectieMultipla, bool pPermiteSelectia)
        {
            IncepeContructieRanduri();

            this.VizibilitateColoana(EnumTipColoana.SelectieMultipla, pSelectieMultipla);
            this.VizibilitateColoana(EnumTipColoana.SelectieUnica, pPermiteSelectia);
        }

        public void IncepeContructieRanduri(bool pAfiseazaElemInchise, bool pSelectieMultipla, bool pPermiteSelectia)
        {
            IncepeContructieRanduri(pSelectieMultipla, pPermiteSelectia);

            this.VizibilitateColoana(EnumTipColoana.MotivInchidere, pAfiseazaElemInchise);
        }

        private int lIdLista = 0;
        public void FinalizeazaContructieRanduri()
        {
            //Salvam coloanele disponibile utilizatorului (doar pentru acestea se va putea modifica ordinea si vizibilitatea)
            listaColoaneDisponibile.Clear();
            foreach (DataGridViewColumn item in this.Columns)
            {
                if (item.Visible)
                {
                    if (poateFiColoanaAscunsa(item.Name))
                        listaColoaneDisponibile.Add(item.Name);
                }
            }

            string denumireUnica = GetDenumireUnica();

            if (CCL.UI.IHMUtile._ComunicareIHM != null)
            {
                try
                {
                    if (this.lPermiteSortarea)
                    {
                        //Se face sortarea dupa vreo coloana?
                        Tuple<string, int, int> colSortare = CCL.UI.IHMUtile._ComunicareIHM.GetColoanaSortare(denumireUnica);

                        //Facem sortarea doar daca coloana exista si este vizibila
                        if (colSortare != null)
                        {
                            this.lIdLista = colSortare.Item3;
                            if (this.Columns.Contains(colSortare.Item1) && this.Columns[colSortare.Item1].Visible)
                            {
                                this.Sort(this.Columns[colSortare.Item1], (ListSortDirection)colSortare.Item2);
                            }
                        }
                        else
                            this.lIdLista = 0;
                    }

                    ////Oare ascundem anumite coloane?
                    //List<string> listaColoaneAscunse = CCL.UI.IHMUtile._ComunicareIHM.GetListaColoaneAscunde(denumireUnica);

                    //if (!CUtil.EsteListaVida<string>(listaColoaneAscunse))
                    //{
                    //    foreach (string item in listaColoaneAscunse)
                    //    {
                    //        if (this.Columns.Contains(item))
                    //            this.Columns[item].Visible = false;
                    //    }
                    //}

                    //Care este ordinea de afisare a coloanelor
                    Dictionary<string, int> dictOrdineAfisare = CCL.UI.IHMUtile._ComunicareIHM.GetOrdineAfisareColoane(denumireUnica);

                    if (dictOrdineAfisare != null)
                    {
                        foreach (KeyValuePair<string, int> item in dictOrdineAfisare)
                        {
                            if (this.Columns.Contains(item.Key) && this.Columns[item.Key].Visible)
                            {
                                this.Columns[item.Key].DisplayIndex = item.Value;
                            }
                        }
                    }

                    //Care este latimea de afisare a coloanelor
                    Dictionary<string, int> dictLatimeAfisare = CCL.UI.IHMUtile._ComunicareIHM.GetLatimeColoane(denumireUnica);

                    if (dictLatimeAfisare != null)
                    {
                        foreach (KeyValuePair<string, int> item in dictLatimeAfisare)
                        {
                            if (this.Columns.Contains(item.Key) && this.Columns[item.Key].Visible)
                            {
                                this.Columns[item.Key].Width = item.Value;
                            }
                        }
                    }

                    dictLatimeAfisare = null;
                    dictOrdineAfisare = null;

                }
                catch (Exception)
                {
                    //Nu este grav daca nu reusim
                }
            }

            this.ClearSelection();
            this.ResumeLayout();
            this.Visible = true;
            this.lSeIncarca = false;
        }

        public List<string> GetColoaneAccesibile()
        {
            return this.listaColoaneDisponibile;
        }

        List<string> listaColoaneDisponibile = new List<string>();
        private bool poateFiColoanaAscunsa(string pNumeColoana)
        {
            return !lColoanaStergere.Equals(pNumeColoana) && !lColoanaEditare.Equals(pNumeColoana) && !lColoanaInchidere.Equals(pNumeColoana) && !lColoanaMotivInchidere.Equals(pNumeColoana) && !lColoanaSelectieMultipla.Equals(pNumeColoana) && !lColoanaSelectieUnica.Equals(pNumeColoana);
        }

        public static void InitSelectieSiEditare(DataGridViewRow pRand, bool pEcranInModificare, bool pPermiteSelectia)
        {
            InitCelulaSelectieUnica(pRand, pPermiteSelectia);
            InitCelulaEditare(pRand, pEcranInModificare);
        }

        public static void InitSelectieSiEditareSiDocumente(DataGridViewRow pRand, bool pEcranInModificare, bool pPermiteSelectia, bool pCuDocumente)
        {
            if (pPermiteSelectia)
                InitCelulaSelectieUnica(pRand, pPermiteSelectia);

            InitCelulaEditare(pRand, pEcranInModificare);

            InitCelulaDocumente(pRand, pCuDocumente);
        }

        public void InitColoanaEditare(bool pPermiteModificare)
        {
            foreach (DataGridViewRow rand in this.Rows)
            {
                InitCelulaEditare(rand, pPermiteModificare);
            }
        }

        public void InitColoanaSelectieUnica()
        {
            foreach (DataGridViewRow rand in this.Rows)
            {
                InitCelulaSelectieUnica(rand, true);
            }
        }

        public static void initCelulaDetaliu(DataGridViewRow pRand, string pNumeColoana)
        {
            ((DataGridViewImageButtonCell)pRand.Cells[pNumeColoana]).ImageNormal = Imagini.getImagineDeschideInPopUp();
        }

        public static void initCelulaDetaliuClasic(DataGridViewRow pRand, string pNumeColoana)
        {
            pRand.Cells[pNumeColoana].Value = "...";
        }

        public static void initCelulaImagine(DataGridViewRow pRand, string pNumeColoana, Image pImagine)
        {
            if (pImagine != null)
                ((DataGridViewImageCell)pRand.Cells[pNumeColoana]).Value = pImagine;
        }

        public static void initCelulaModificare(DataGridViewRow pRand, string pNumeColoana)
        {
            ((DataGridViewImageButtonCell)pRand.Cells[pNumeColoana]).ImageNormal = Imagini.getImagineEditare();
        }

        public void InitCelulaDenumire(DataGridViewRow pRand, string pText)
        {
            if (this.Columns.Contains(_Coloana_Denumire))
                pRand.Cells[_Coloana_Denumire].Value = pText;
        }

        public static void InitCelulaValoareMonetara(DataGridViewRow pRand, string pDenumireColoana, double pValoare)
        {
            pRand.Cells[pDenumireColoana].Value = CUtil.GetValoareMonetara(pValoare);
            pRand.Cells[pDenumireColoana].Tag = pValoare;
        }

        public static void InitCelulaValoareMonetara(DataGridViewRow pRand, string pDenumireColoana, double pValoare, CDefinitiiComune.EnumTipMoneda pMoneda)
        {
            pRand.Cells[pDenumireColoana].Value = CUtil.GetValoareMonetara(pValoare, pMoneda);
            pRand.Cells[pDenumireColoana].Tag = pValoare;
        }
        public static void InitCelulaValoareNumerica(DataGridViewRow pRand, string pNumeColoana, int pNrTotalRealizari)
        {
            InitCelulaValoareNumerica(pRand, pNumeColoana, pNrTotalRealizari, false);
        }

        public static void InitCelulaValoareNumerica(DataGridViewRow pRand, string pNumeColoana, double pNrTotalRealizari, bool pAlertaLaValoareNegativa)
        {
            pRand.Cells[pNumeColoana].Value = pNrTotalRealizari;
            pRand.Cells[pNumeColoana].Tag = pNrTotalRealizari;

            if (pAlertaLaValoareNegativa && pNrTotalRealizari < 0)
            {
                SeteazaAlerta(pRand, pNumeColoana);
            }
        }

        public static double GetValoareTagColoanaRand(DataGridViewRow pRand, string pDenumireColoana)
        {
            return CUtil.GetAsDouble(pRand.Cells[pDenumireColoana].Tag);
        }

        public static void InitCelulaEditare(DataGridViewRow pRand, bool pEcranInModificare)
        {
            if (pRand.DataGridView.Columns.Contains(lColoanaEditare))
                ((DataGridViewImageButtonCell)pRand.Cells[lColoanaEditare]).ImageNormal = Imagini.getImagineButonEditareElement(pEcranInModificare);
        }

        public static void InitCelulaAlerta(DataGridViewRow pRand, string pNumeColoana, bool pAlerta)
        {
            pRand.Cells[pNumeColoana].Value = pAlerta ? Imagini.getImagineAlerta() : Imagini.getImagineOK();
        }

        public static void InitCelulaDocumente(DataGridViewRow pRand, bool pCuDocumente)
        {
            ((DataGridViewImageButtonCell)pRand.Cells[lColoanaGestiuneDocumente]).ImageNormal = Imagini.getImagineMyDocuments(pCuDocumente);
        }

        public static void InitCelulaSelectieUnica(DataGridViewRow pRand, bool pPermiteSelectia)
        {
            if (pPermiteSelectia)
                ((DataGridViewImageButtonCell)pRand.Cells[lColoanaSelectieUnica]).ImageNormal = Imagini.getImagineSelectieUnica();
        }

        public static void InitCelulaAdaugare(DataGridViewRow pRand)
        {
            ((DataGridViewImageButtonCell)pRand.Cells[lColoanaAdaugare]).ImageNormal = Imagini.GetImagineAdauga();
        }

        public static void InitCelulaDeschideClasic(DataGridViewRow pRand)
        {
            pRand.Cells[lColoanaDeschideClasic].Value = "...";
        }

        public static void InitCelulaDeschideClasic(DataGridViewRow pRand, string pNumeColoana)
        {
            pRand.Cells[pNumeColoana].Value = "...";
        }

        public static void InitCelulaAdaugare(DataGridViewRow pRand, string pNumeColoana)
        {
            ((DataGridViewImageButtonCell)pRand.Cells[pNumeColoana]).ImageNormal = Imagini.GetImagineAdauga();
        }

        public static void InitCelulaVida(DataGridViewRow pRand, string pNumeColoana)
        {
            ((DataGridViewImageButtonCell)pRand.Cells[pNumeColoana]).ImageNormal = Imagini.getImagineVida();
        }

        public static void InitCelulaEmail(DataGridViewRow pRand)
        {
            ((DataGridViewImageButtonCell)pRand.Cells[lColoanaEmail]).ImageNormal = Imagini.getImagineEmailTrimise();
        }

        public static void InitGestiuneInchidere(DataGridViewRow pRand, IInchidere pElement, bool pSeAfiseazaMotivul)
        {
            InitCelulaInchidere(pRand, pElement.EsteActiv);
            if (pSeAfiseazaMotivul)
                InitCelulaMotivInchidere(pRand, pElement.MotivInchidere);
        }

        public static void InitCelulaStergere(DataGridViewRow pRand)
        {
            ((DataGridViewImageButtonCell)pRand.Cells[lColoanaStergere]).ImageNormal = Imagini.getImagineStergere();
        }

        public static void InitCelulaInchidere(DataGridViewRow pRand, bool pActiv)
        {
            pRand.Cells[ColoanaInchidere].Value = !pActiv;
        }

        public static void InitCelulaMotivInchidere(DataGridViewRow pRand, string pMotiv)
        {
            pRand.Cells[ColoanaMotivInchidere].Value = CUtil.PregatesteStringMultiLineDGV(pMotiv);
        }

        public void SetAccesibilitateColoana(string pNumeColoana, bool pAccesPermis)
        {
            foreach (DataGridViewRow Rand in this.Rows)
            {
                Rand.Cells[pNumeColoana].ReadOnly = !pAccesPermis;
            }
        }

        public void AllowModification(bool pPermiteModificarea)
        {
            bool contineColoanaInchidere = this.Columns.Contains(lColoanaInchidere);
            bool contineColoanaMotivInchidere = this.Columns.Contains(lColoanaMotivInchidere);
            bool contineColoanaEditare = this.Columns.Contains(lColoanaEditare);

            //ATENTIE la modificari; nu toate coloanele checkbox sunt editabile si nici toate cu butoane nu trebuiesc sa dispara in modul lectura
            if (contineColoanaInchidere)
                this.Columns[lColoanaInchidere].Visible = pPermiteModificarea;

            if (this.Columns.Contains(lColoanaStergere))
                this.Columns[lColoanaStergere].Visible = pPermiteModificarea;

            foreach (DataGridViewRow Rand in this.Rows)
            {
                if (contineColoanaEditare)
                {
                    if (((DataGridViewImageButtonCell)Rand.Cells[lColoanaEditare]).ImageNormal != null) // nu intotdeauna avem aceasta celula (mai ales in cazul TGV-urilor)
                        InitCelulaEditare(Rand, pPermiteModificarea);
                }

                if (contineColoanaMotivInchidere)
                    Rand.Cells[lColoanaMotivInchidere].ReadOnly = !pPermiteModificarea;
            }

            this.Invalidate();
        }

        public DataGridViewRow AdaugaRandNou(int pIndex)
        {
            this.Rows.Insert(pIndex, 1);

            return this.Rows[pIndex];
        }

        public DataGridViewRow AdaugaRandNou()
        {
            return this.Rows[this.Rows.Add()];
        }

        public void AdaugaColoanaText(string pNume, string pHeaderText, int pWidth)
        {
            AdaugaColoanaText(pNume, pHeaderText, pWidth, false, DataGridViewColumnSortMode.Automatic);
        }

        public void AdaugaColoanaText(string pNume, string pHeaderText, int pWidth, bool pFill, DataGridViewColumnSortMode pSortMode)
        {
            AdaugaColoanaText(pNume, pHeaderText, pWidth,
                pFill ? DataGridViewAutoSizeColumnMode.Fill : DataGridViewAutoSizeColumnMode.NotSet, false,
                pSortMode);
        }

        public void AdaugaColoanaText(string pNume, string pHeaderText, int pWidth, bool pFill, bool pFrozen, DataGridViewColumnSortMode pSortMode)
        {
            AdaugaColoanaText(pNume, pHeaderText, pWidth,
                pFill ? DataGridViewAutoSizeColumnMode.Fill : DataGridViewAutoSizeColumnMode.NotSet, pFrozen,
                pSortMode);
        }

        public void AdaugaColoanaTelefon()
        {
            this.AdaugaColoanaText(_Coloana_Telefon, _Header_Coloana_Telefon, 100, false, DataGridViewColumnSortMode.Automatic);
        }

        public void VizibilitateColoanaTelefon(bool pVizibil)
        {
            this.Columns[_Coloana_Telefon].Visible = pVizibil;
        }

        public static void InitCelulaTelefon(DataGridViewRow pRand, string pTelefon)
        {
            pRand.Cells[_Coloana_Telefon].Value = CUtil.GetNumarTelefonFormatat(pTelefon, _ModAfisareTelefonAgenda, _SecurizeazaDateContact);
            pRand.Cells[_Coloana_Telefon].ToolTipText = CUtil.GetNumarTelefonFormatat(pTelefon, _ModAfisareTelefonAgenda, false);
            pRand.Cells[_Coloana_Telefon].Tag = pTelefon;
        }

        public void AdaugaColoaneTelefonEmail()
        {
            this.AdaugaColoanaText(_Coloana_Telefon, _Header_Coloana_Telefon, 100, false, DataGridViewColumnSortMode.Automatic);
            this.AdaugaColoanaText(_Coloana_AdresaMail, _Header_Coloana_AdresaMail, 180, false, DataGridViewColumnSortMode.Automatic);
        }

        public void AdaugaColoaneTelefonEmail(int pWidth)
        {
            this.AdaugaColoanaText(_Coloana_Telefon, _Header_Coloana_Telefon, pWidth, false, DataGridViewColumnSortMode.Automatic);
            this.AdaugaColoanaText(_Coloana_AdresaMail, _Header_Coloana_AdresaMail, pWidth + 50, false, DataGridViewColumnSortMode.Automatic);
        }

        public void VizibilitateColoaneTelefonEmail(bool pVizibil)
        {
            this.Columns[_Coloana_Telefon].Visible = pVizibil;
            this.Columns[_Coloana_AdresaMail].Visible = pVizibil;
        }

        public static void InitCeluleTelefonEmail(DataGridViewRow pRand, string pTelefon, string pAdresaEmail)
        {
            pRand.Cells[_Coloana_Telefon].Value = CUtil.GetNumarTelefonFormatat(pTelefon, _ModAfisareTelefonAgenda, _SecurizeazaDateContact);
            pRand.Cells[_Coloana_Telefon].ToolTipText = CUtil.GetNumarTelefonFormatat(pTelefon, _ModAfisareTelefonAgenda, false);
            pRand.Cells[_Coloana_Telefon].Tag = pTelefon;

            pRand.Cells[_Coloana_AdresaMail].Value = CUtil.GetAdresaEmail(pAdresaEmail, _SecurizeazaDateContact);
            pRand.Cells[_Coloana_AdresaMail].ToolTipText = pAdresaEmail;
            pRand.Cells[_Coloana_AdresaMail].Tag = pAdresaEmail;
        }

        public void AdaugaColoaneTelefonEmailCompleteCuFixSiCC()
        {
            this.AdaugaColoanaText(_Coloana_Telefon, _Header_Coloana_Telefon, 100, false, DataGridViewColumnSortMode.Automatic);
            this.AdaugaColoanaText(_Coloana_Telefon2, _Header_Coloana_Telefon2, 100, false, DataGridViewColumnSortMode.Automatic);
            this.AdaugaColoanaText(_Coloana_AdresaMail, _Header_Coloana_AdresaMail, 180, false, DataGridViewColumnSortMode.Automatic);
            this.AdaugaColoanaText(_Coloana_AdresaMailCC, _Header_Coloana_AdresaMailCC, 180, false, DataGridViewColumnSortMode.Automatic);
        }

        public void VizibilitateColoaneTelefonEmailCompleteCuFixSiCC(bool pVizibil)
        {
            this.Columns[_Coloana_Telefon].Visible = pVizibil;
            this.Columns[_Coloana_Telefon2].Visible = pVizibil;
            this.Columns[_Coloana_AdresaMail].Visible = pVizibil;
            this.Columns[_Coloana_AdresaMailCC].Visible = pVizibil;
        }

        public static void InitCeluleTelefonEmail(DataGridViewRow pRand, string pTelefon, string pFix, string pAdresaEmail, string pAdresaEmailCC)
        {
            pRand.Cells[_Coloana_Telefon].Value = CUtil.GetNumarTelefonFormatat(pTelefon, _ModAfisareTelefonAgenda, _SecurizeazaDateContact);
            pRand.Cells[_Coloana_Telefon].ToolTipText = CUtil.GetNumarTelefonFormatat(pTelefon, _ModAfisareTelefonAgenda, false);
            pRand.Cells[_Coloana_Telefon].Tag = pTelefon;

            pRand.Cells[_Coloana_Telefon2].Value = CUtil.GetNumarTelefonFormatat(pFix, _ModAfisareTelefonAgenda, _SecurizeazaDateContact);
            pRand.Cells[_Coloana_Telefon2].ToolTipText = CUtil.GetNumarTelefonFormatat(pFix, _ModAfisareTelefonAgenda, false);
            pRand.Cells[_Coloana_Telefon2].Tag = pFix;

            pRand.Cells[_Coloana_AdresaMail].Value = CUtil.GetAdresaEmail(pAdresaEmail, _SecurizeazaDateContact);
            pRand.Cells[_Coloana_AdresaMail].ToolTipText = pAdresaEmail;
            pRand.Cells[_Coloana_AdresaMail].Tag = pAdresaEmail;

            pRand.Cells[_Coloana_AdresaMailCC].Value = CUtil.GetAdresaEmail(pAdresaEmailCC, _SecurizeazaDateContact);
            pRand.Cells[_Coloana_AdresaMailCC].ToolTipText = pAdresaEmailCC;
            pRand.Cells[_Coloana_AdresaMailCC].Tag = pAdresaEmailCC;
        }

        public void AdaugaColoanaText(string pNume, string pHeaderText, int pWidth, DataGridViewAutoSizeColumnMode pFill, bool pFrozen, DataGridViewColumnSortMode pSortMode)
        {
            DataGridViewTextBoxColumn colNume = new DataGridViewTextBoxColumn();
            colNume.Name = pNume;
            colNume.HeaderText = pHeaderText;
            if (pFill == DataGridViewAutoSizeColumnMode.Fill || pFill == DataGridViewAutoSizeColumnMode.AllCells)
            {
                if (pWidth > 0)
                {
                    colNume.Width = pWidth;
                    colNume.MinimumWidth = pWidth;
                    colNume.MinimumWidth = Convert.ToInt32(colNume.MinimumWidth * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
                }

                colNume.AutoSizeMode = pFill;// DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                //colNume.MinimumWidth = pWidth;
                colNume.Width = pWidth;
                colNume.AutoSizeMode = pFill;
                //colNume.MinimumWidth = Convert.ToInt32(colNume.MinimumWidth * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
            }

            colNume.Resizable = DataGridViewTriState.True;
            colNume.Width = Convert.ToInt32(colNume.Width * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);

            colNume.ReadOnly = true;
            colNume.SortMode = pSortMode;
            colNume.Frozen = pFrozen;
            this.Columns.Add(colNume);
            colNume = null;
        }

        public void AdaugaColoanaValoareMonetara(string pNume, string pHeaderText, int pWidth, DataGridViewColumnSortMode pSortMode)
        {
            DataGridViewTextBoxColumn colNume = new DataGridViewTextBoxColumn();
            colNume.Name = pNume;
            colNume.HeaderText = pHeaderText;
            //colNume.ValueType = System.Type.GetType("System.Decimal");
            colNume.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colNume.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            //if (pWidth > 0)
            //{
            //    colNume.MinimumWidth = pWidth;
            //    colNume.MinimumWidth = Convert.ToInt32(colNume.MinimumWidth * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
            //}

            colNume.Width = pWidth;
            colNume.Resizable = DataGridViewTriState.True;
            colNume.Width = Convert.ToInt32(colNume.Width * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
            colNume.ReadOnly = true;
            colNume.SortMode = pSortMode;
            this.Columns.Add(colNume);
            colNume = null;
        }

        public void AdaugaColoanaNumerica(string pNume, string pHeaderText, int pWidth, DataGridViewColumnSortMode pSortMode)
        {
            DataGridViewTextBoxColumn colNume = new DataGridViewTextBoxColumn();
            colNume.Name = pNume;
            colNume.HeaderText = pHeaderText;
            colNume.ValueType = System.Type.GetType("System.Int32");
            colNume.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //if (pWidth > 0)
            //{
            //    colNume.MinimumWidth = pWidth;
            //    colNume.MinimumWidth = Convert.ToInt32(colNume.MinimumWidth * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
            //}

            colNume.Width = pWidth;

            colNume.Width = Convert.ToInt32(colNume.Width * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
            colNume.Resizable = DataGridViewTriState.True;

            colNume.ReadOnly = true;
            colNume.SortMode = pSortMode;
            this.Columns.Add(colNume);
            colNume = null;
        }

        public void AdaugaColoanaLink(string pNume, string pHeaderText, int pWidth, bool pFill, DataGridViewColumnSortMode pSortMode)
        {
            DataGridViewLinkColumn colLink = new DataGridViewLinkColumn();
            colLink.Name = pNume;
            colLink.HeaderText = pHeaderText;
            if (pFill)
            {
                if (pWidth > 0)
                {
                    colLink.MinimumWidth = pWidth;
                    colLink.MinimumWidth = Convert.ToInt32(colLink.MinimumWidth * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
                }

                colLink.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
                colLink.Width = pWidth;

            colLink.Width = Convert.ToInt32(colLink.Width * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);

            colLink.ReadOnly = true;
            colLink.SortMode = pSortMode;
            this.Columns.Add(colLink);
            colLink = null;
        }

        public void AdaugaColoanaData(string pNume, string pHeaderText, int pWidth, bool pFill, DataGridViewColumnSortMode pSortMode)
        {
            AdaugaColoanaData(pNume, pHeaderText, pWidth, pFill, pSortMode, "dd/MM/yyyy HH:mm");
        }
        public void AdaugaColoanaData(string pNume, string pHeaderText, int pWidth, bool pFill, DataGridViewColumnSortMode pSortMode, string pFormatData)
        {
            DataGridViewTextBoxColumn colData = new DataGridViewTextBoxColumn();
            colData.Name = pNume;
            colData.HeaderText = pHeaderText;
            if (pFill)
            {
                colData.MinimumWidth = pWidth;
                colData.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colData.MinimumWidth = Convert.ToInt32(colData.MinimumWidth * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
            }
            else
                colData.Width = pWidth;

            colData.Width = Convert.ToInt32(colData.Width * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);

            colData.ReadOnly = true;
            colData.SortMode = pSortMode;
            colData.ValueType = System.Type.GetType("System.Date");
            colData.DefaultCellStyle.Format = pFormatData;
            this.Columns.Add(colData);
            colData = null;
        }

        public void AdaugaColoanaCheckBox(string pNume, string pHeaderText, int pWidth, bool pFill, DataGridViewColumnSortMode pSortMode)
        {
            DataGridViewDisableCheckBoxColumn colCheck = new DataGridViewDisableCheckBoxColumn();
            colCheck.Name = pNume;
            colCheck.HeaderText = pHeaderText;
            colCheck.SortMode = pSortMode;
            colCheck.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (pFill)
            {
                if (pWidth > 0)
                {
                    colCheck.MinimumWidth = pWidth;
                    colCheck.MinimumWidth = Convert.ToInt32(colCheck.MinimumWidth * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
                }
                colCheck.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                //if (pWidth > 0)
                //{
                //    colCheck.MinimumWidth = pWidth;
                //    colCheck.MinimumWidth = Convert.ToInt32(colCheck.MinimumWidth * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
                //}

                colCheck.Width = pWidth;
            }

            colCheck.Width = Convert.ToInt32(colCheck.Width * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
            colCheck.Resizable = DataGridViewTriState.True;

            colCheck.Width = pWidth;
            this.Columns.Add(colCheck);
            colCheck = null;
        }

        public void AdaugaColoanaComboBox(string pNume, string pHeaderText, int pWidth, bool pFill, DataGridViewColumnSortMode pSortMode)
        {
            AdaugaColoanaComboBox(pNume, pHeaderText, pWidth, pFill, pSortMode, null);
        }
        public void AdaugaColoanaComboBox(string pNume, string pHeaderText, int pWidth, bool pFill,
            DataGridViewColumnSortMode pSortMode, object pDataSource)
        {
            DataGridViewComboBoxColumn colCombo = new DataGridViewComboBoxColumn();
            colCombo.Name = pNume;
            colCombo.HeaderText = pHeaderText;
            colCombo.SortMode = pSortMode;
            if (pFill)
            {
                colCombo.MinimumWidth = pWidth;
                colCombo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colCombo.MinimumWidth = Convert.ToInt32(colCombo.MinimumWidth * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
            }
            else
                colCombo.Width = pWidth;
            colCombo.Width = pWidth;

            colCombo.Width = Convert.ToInt32(colCombo.Width * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);

            colCombo.DataSource = pDataSource;
            this.Columns.Add(colCombo);
            colCombo = null;
        }

        public void AdaugaColoanaButon(string pNume, string pHeaderText, int pWidth, bool pFill, DataGridViewColumnSortMode pSortMode)
        {
            DataGridViewImageButtonColumn colButon = new DataGridViewImageButtonColumn();
            colButon.Name = pNume;
            colButon.HeaderText = pHeaderText;
            colButon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (pWidth > 0)
                colButon.Width = pWidth;
            else
                colButon.Width = 22;

            colButon.Width = Convert.ToInt32(colButon.Width * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);

            colButon.ReadOnly = true;
            this.Columns.Add(colButon);
            colButon = null;
        }

        /// <summary>
        /// De tip Imagine
        /// </summary>
        /// <param name="pNume"></param>
        /// <param name="pHeaderText"></param>
        /// <param name="pToolTipText"></param>
        /// <param name="pWidth"></param>
        /// <param name="pFrozen"></param>
        public void AdaugaColoanaButonStandard(string pNume, string pHeaderText, string pToolTipText, int pWidth, bool pFrozen)
        {
            AdaugaColoanaButonStandard(pNume, pHeaderText, pToolTipText, pWidth, pFrozen, null);
        }

        /// <summary>
        /// De tip Buton Imagine
        /// </summary>
        /// <param name="pNume"></param>
        /// <param name="pHeaderText"></param>
        /// <param name="pToolTipText"></param>
        /// <param name="pWidth"></param>
        /// <param name="pFrozen"></param>
        /// <param name="pImagineButon"></param>
        public void AdaugaColoanaButonStandard(string pNume, string pHeaderText, string pToolTipText, int pWidth, bool pFrozen, Image pImagineButon)
        {
            DataGridViewImageButtonColumn colButon = new DataGridViewImageButtonColumn();
            colButon.Name = pNume;
            colButon.HeaderText = pHeaderText;
            colButon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (pWidth > 0)
                colButon.Width = pWidth;
            else
                colButon.Width = 22;

            colButon.Width = Convert.ToInt32(colButon.Width * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);

            colButon.ReadOnly = true;
            colButon.ToolTipText = pToolTipText;
            colButon.Frozen = pFrozen;

            if (this.lSeIncarca) return;

            this.Columns.Add(colButon);
            colButon = null;
        }

        /// <summary>
        /// De tip buton text
        /// </summary>
        /// <param name="pNume"></param>
        /// <param name="pHeaderText"></param>
        /// <param name="pToolTipText"></param>
        /// <param name="pWidth"></param>
        /// <param name="pFrozen"></param>
        public void AdaugaColoanaButonClasic(string pNume, string pHeaderText, string pToolTipText, int pWidth, bool pFrozen)
        {
            DataGridViewButtonColumn colButon = new DataGridViewButtonColumn();
            colButon.Name = pNume;
            colButon.HeaderText = pHeaderText;
            colButon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (pWidth > 0)
                colButon.Width = pWidth;
            else
                colButon.Width = 22;

            colButon.Width = Convert.ToInt32(colButon.Width * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);

            colButon.ReadOnly = true;
            colButon.ToolTipText = pToolTipText;
            colButon.Frozen = pFrozen;
            this.Columns.Add(colButon);
            colButon = null;
        }

        public void AdaugaColoanaImagine(string pNume, string pHeaderText, string pToolTipText, int pWidth, bool pFrozen)
        {
            DataGridViewImageColumn colImagine = new DataGridViewImageColumn();
            colImagine.Name = pNume;
            colImagine.HeaderText = pHeaderText;
            colImagine.ToolTipText = pToolTipText;

            if (pWidth > 0)
            {
                colImagine.MinimumWidth = pWidth;
                colImagine.MinimumWidth = Convert.ToInt32(colImagine.MinimumWidth * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
            }

            colImagine.Width = pWidth;
            colImagine.Width = Convert.ToInt32(colImagine.Width * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);

            colImagine.Frozen = pFrozen;
            this.Columns.Add(colImagine);
            colImagine = null;
        }

        public void AscundeColoana(EnumTipColoana pTipColoana)
        {
            AscundeColoana(getNumeColoanaByTip(pTipColoana));
        }

        public void AscundeColoana(string pNumeColoana)
        {
            if (!string.IsNullOrEmpty(pNumeColoana) && this.Columns.Contains(pNumeColoana))
                this.Columns[pNumeColoana].Visible = false;
        }

        public void AdaugaColoana(EnumTipColoana pTipColoana)
        {
            AdaugaColoana(pTipColoana, true);
        }

        public void AdaugaColoana(EnumTipColoana pTipColoana, bool pFrozen)
        {
            switch (pTipColoana)
            {
                case EnumTipColoana.Denumire:
                    AdaugaColoanaText(_Coloana_Denumire, _HeaderDenumire, 100, true, DataGridViewColumnSortMode.Automatic);
                    break;
                case EnumTipColoana.SelectieMultipla:
                    DatagridViewCheckBoxHeaderCell chkHeader = new DatagridViewCheckBoxHeaderCell();
                    DataGridViewDisableCheckBoxColumn colSelecteaza = new DataGridViewDisableCheckBoxColumn();
                    colSelecteaza.Name = lColoanaSelectieMultipla;
                    colSelecteaza.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    colSelecteaza.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    colSelecteaza.Width = Convert.ToInt32(20 * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X); ;
                    colSelecteaza.Frozen = pFrozen;
                    colSelecteaza.HeaderCell = chkHeader;
                    colSelecteaza.HeaderText = " ";
                    chkHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(colSelecteaza_OnCheckBoxClicked);
                    lIndexColoanaSelectie = this.Columns.Add(colSelecteaza);
                    colSelecteaza = null;
                    break;
                case EnumTipColoana.SelectieUnica:
                    AdaugaColoanaButonStandard(lColoanaSelectieUnica, string.Empty, _ToolTipSelecteaza, 35, pFrozen);
                    break;
                case EnumTipColoana.Adaugare:
                    AdaugaColoanaButonStandard(lColoanaAdaugare, string.Empty, _ToolTipSelecteaza, 35, false);
                    break;
                case EnumTipColoana.Editare:
                    AdaugaColoanaButonStandard(lColoanaEditare, string.Empty, _ToolTipAccesDetalii, 35, pFrozen);
                    break;
                case EnumTipColoana.DeschideClasic:
                    AdaugaColoanaButonClasic(lColoanaDeschideClasic, string.Empty, _ToolTipAccesDetalii, 35, pFrozen);
                    break;
                case EnumTipColoana.Star:
                    break;
                case EnumTipColoana.Inchidere:
                    DataGridViewDisableCheckBoxColumn colInchidere = new DataGridViewDisableCheckBoxColumn();
                    colInchidere.Name = lColoanaInchidere;
                    colInchidere.HeaderText = _HeaderInchidere;
                    colInchidere.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    colInchidere.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    colInchidere.Width = Convert.ToInt32(50 * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
                    this.Columns.Add(colInchidere);
                    colInchidere = null;
                    break;
                case EnumTipColoana.MotivInchidere:
                    DataGridViewTextBoxColumn colMotivInchidere = new DataGridViewTextBoxColumn();
                    colMotivInchidere.Name = lColoanaMotivInchidere;
                    colMotivInchidere.HeaderText = _HeaderMotivInchidere;
                    colMotivInchidere.MaxInputLength = 500;
                    colMotivInchidere.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    colMotivInchidere.Width = Convert.ToInt32(150 * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X); ;
                    colMotivInchidere.SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.Columns.Add(colMotivInchidere);
                    colMotivInchidere = null;
                    break;
                case EnumTipColoana.GestiuneDocumente:
                    AdaugaColoanaButonStandard(lColoanaGestiuneDocumente, string.Empty, _ToolTipDocumente, 30, false);
                    break;
                case EnumTipColoana.Stergere:
                    AdaugaColoanaButonStandard(lColoanaStergere, string.Empty, _HeaderStergere, 24, false);
                    break;
                case EnumTipColoana.Email:
                    AdaugaColoanaButonStandard(lColoanaEmail, string.Empty, _HeaderEmail, 36, false);
                    break;
                case EnumTipColoana.Validare:
                    AdaugaColoanaButonStandard(lColoanaEmail, string.Empty, _HeaderEmail, 36, false);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Selectam linia corespunzatoare id-ului unui obiect
        /// </summary>
        /// <param name="pIdElem"></param>
        public int SelecteazaElement(int pIdElem)
        {
            this.ClearSelection();
            int indexRandSelectat = -1;
            foreach (DataGridViewRow xRow in this.Rows)
            {
                if (xRow.Tag.Equals(pIdElem))
                {
                    if (xRow.Visible)
                    {
                        indexRandSelectat = xRow.Index;
                        this.FirstDisplayedScrollingRowIndex = xRow.Index;
                        if (!xRow.Cells[0].Visible)
                        {
                            if (xRow.Cells.Count > 1)
                            {
                                for (int i = 1; i < xRow.Cells.Count; i++)
                                {
                                    if (xRow.Cells[i].Visible)
                                    {
                                        this.CurrentCell = xRow.Cells[i];
                                        break;
                                    }
                                }
                            }
                        }
                        else
                            this.CurrentCell = xRow.Cells[0];

                        if (!xRow.Selected)
                        {
                            xRow.Selected = true;

                            //NU FACE NIMIC
                            ////Util la utilizatori -> celula de modificare a numarului de ordine nu pare selectata la initializare
                            //if (this.SelectionMode == DataGridViewSelectionMode.CellSelect)
                            //{
                            //    //Selectam toate celulele acestui rand
                            //    bool existaCurentCell = false;
                            //    for (int i = 1; i < xRow.Cells.Count; i++)
                            //    {
                            //        if (xRow.Cells[i].Visible)
                            //        {
                            //            xRow.Cells[i].Selected = true;

                            //            if (!existaCurentCell)
                            //            {
                            //                if (this.Columns[i].ReadOnly && !this.SeIgnoraColoanaLaImprimare(this.Columns[i].Name))
                            //                {
                            //                    this.CurrentCell = xRow.Cells[i];

                            //                    existaCurentCell = true;
                            //                }
                            //            }
                            //        }
                            //    }
                            //    if (existaCurentCell)
                            //        this.CurrentCell.Selected = true;
                            //}
                        }

                        this.EndEdit();
                    }

                    break;
                }
            }
            this.ResumeLayout(true);

            return indexRandSelectat;
        }

        public void SelecteazaElement(object pObiect)
        {
            if (pObiect != null)
            {
                this.ClearSelection();
                foreach (DataGridViewRow LinieDGV in this.Rows)
                {
                    if (LinieDGV.Tag.Equals(pObiect))
                    {
                        if (LinieDGV.Visible)
                        {
                            LinieDGV.Selected = true;
                            this.FirstDisplayedScrollingRowIndex = LinieDGV.Index;
                            this.EndEdit();
                        }
                        break;
                    }
                }
            }
            else
            {
                this.ClearSelection();
            }
        }

        public void RemoveRows<T>(List<T> listaDeSters) where T : class
        {
            List<int> listaIndecsiDeScos = new List<int>();
            foreach (DataGridViewRow LinieDGV in this.Rows)
            {
                if (listaDeSters.Contains(LinieDGV.Tag as T))
                    listaIndecsiDeScos.Add(LinieDGV.Index);
            }

            for (int i = 0; i < listaIndecsiDeScos.Count; i++)
            {
                this.Rows.RemoveAt(listaIndecsiDeScos[listaIndecsiDeScos.Count - (i + 1)]);
            }
        }

        public void DebifeazaElementele()
        {
            foreach (DataGridViewRow LinieDGV in this.Rows)
            {
                LinieDGV.Cells[lColoanaSelectieMultipla].Value = false;
            }
        }

        public void BifeazaElemente<T>(List<T> pListaObiecte)
        {
            //Doar daca avem coloana de selectie multipla
            if (pListaObiecte != null && pListaObiecte.Count > 0 && this.Columns.Contains(lColoanaSelectieMultipla) && this.Rows.Count > 0)
            {
                this.ClearSelection();
                int indexDisplay = 0;
                foreach (DataGridViewRow LinieDGV in this.Rows)
                {
                    foreach (var item in pListaObiecte)
                    {
                        if (LinieDGV.Tag.Equals(item))
                        {
                            LinieDGV.Cells[lColoanaSelectieMultipla].Value = true;

                            if (indexDisplay == 0)
                                indexDisplay = LinieDGV.Index;
                            break;
                        }
                    }
                }

                if (this.Rows.Count > indexDisplay && this.Rows[indexDisplay].Visible == true)
                {
                    this.Rows[indexDisplay].Selected = true;
                    this.FirstDisplayedScrollingRowIndex = indexDisplay;
                }
            }
            else
            {
                this.ClearSelection();
            }
        }

        /// <summary>
        /// Recuperam Id-ul obiectului ce se gaseste in Tag-ul liniei selectata
        /// </summary>
        /// <returns></returns>
        public int GetIdObiectLinieSelectata()
        {
            if (this.SelectedRows.Count > 0)
            {
                return ((ICheie)this.SelectedRows[0].Tag).Id;
            }
            else
            {
                return -1;
            }
        }

        public void SchimbaValoareColoana(int pIndexColoana, bool pSelectat)
        {
            SchimbaValoareColoana(pIndexColoana, pSelectat, false);
        }

        /// <summary>
        /// Schimbam starea tuturor celulelor dintr-o coloana
        /// </summary>
        /// <param name="pIndex"></param>
        /// <param name="pSelectat"></param>
        public void SchimbaValoareColoana(int pIndexColoana, bool pSelectat, bool pDoarDacaNuEsteReadOnly)
        {
            //this.ClearSelection();
            //this.BeginEdit(false);

            this.EndEdit(); //acum ar trebui sa mearga
            this.ClearSelection();
            this.Visible = false;

            foreach (DataGridViewRow LinieDGV in this.Rows)
            {
                if (pDoarDacaNuEsteReadOnly)
                {
                    //Nu modificam starea celulelor readonly
                    if (LinieDGV.Cells[pIndexColoana].ReadOnly)
                        continue;
                }

                //Aplicam selectia doar elementelor vizibile
                if (LinieDGV.Visible)
                    LinieDGV.Cells[pIndexColoana].Value = pSelectat;
                else
                    LinieDGV.Cells[pIndexColoana].Value = false;
            }

            //if (this.Rows.Count > 0 && this.Rows[0].Visible == true)
            //{
            //    this.Rows[0].Selected = true;
            //    this.FirstDisplayedScrollingRowIndex = 0;
            //}

            ////Altfel checkbox-ul primei linii, daca aceasta este selectata, nu isi schimba starea
            //if (this.SelectedRows.Count > 0 && this.SelectedRows[0].Cells.Count > 0)
            //{
            //    this.SelectedRows[0].Cells[1].Selected = true;
            //}
            //else
            //{
            //    this.EndEdit(); //acum ar trebui sa mearga
            //    //this.CommitEdit(DataGridViewDataErrorContexts.Commit);

            //    //this.ClearSelection();
            //}

            this.Visible = true;
        }

        /// <summary>
        /// Verificam daca toate celulele unei coloane sunt bifate
        /// </summary>
        /// <param name="pNumeColoana"></param>
        /// <returns></returns>
        public bool AreToateCeluleleColoaneiBifate(int pIndexColoana)
        {
            bool ToateCeluleleSuntBifate = true;
            foreach (DataGridViewRow LinieDGV in this.Rows)
            {
                if (Convert.ToBoolean(LinieDGV.Cells[pIndexColoana].Value) == false)
                {
                    ToateCeluleleSuntBifate = false;
                    break;
                }
            }
            return ToateCeluleleSuntBifate;
        }

        /// <summary>
        /// Prin intermediul acestei metode vom recupera liniile selectate de utilizator
        /// In cazul in care coloana de selectie multipla nu este vizibila sau daca nicio linie nu este bifata vom 
        /// considera toate liniile ca fiind selectate
        /// Daca cel putin o linie este bifata vom intoarce doar liniile bifate
        /// 
        /// DOAR LINIILE VIZIBILE SUNT LUATE IN CONSIDERARE
        /// </summary>
        /// <returns></returns>
        public List<DataGridViewRow> GetListaLiniiSelectate()
        {
            List<DataGridViewRow> listaLiniiBifate = new List<DataGridViewRow>();

            if (ExistaLiniiBifate())
            {
                listaLiniiBifate = GetListaLiniiBifate(getIndexColoanaSelectieMultipla());
            }

            if (CUtil.EsteListaVida<DataGridViewRow>(listaLiniiBifate) || listaLiniiBifate.Count == 1)
            {
                foreach (DataGridViewRow linieDGV in this.Rows)
                {
                    if (!linieDGV.Visible) continue;

                    listaLiniiBifate.Add(linieDGV);
                }
            }

            return listaLiniiBifate;
        }

        /// <summary>
        /// Nu toate coloanele sunt pretabile pentru export (printare)
        /// Coloane de selectie multipla de exemplu
        /// </summary>
        /// <param name="pNumeColoana">Numele coloanei pe care o verificam</param>
        /// <returns></returns>
        public bool SeIgnoraColoanaLaImprimare(string pNumeColoana)
        {
            return string.IsNullOrEmpty(pNumeColoana) || this.Columns[pNumeColoana].Visible == false || pNumeColoana.Equals(lColoanaEditare) ||
                    pNumeColoana.Equals(lColoanaEmail) ||
                    pNumeColoana.Equals(lColoanaGestiuneDocumente) ||
                    pNumeColoana.Equals(lColoanaSelectieMultipla) ||
                    pNumeColoana.Equals(lColoanaSelectieUnica) ||
                    pNumeColoana.Equals(lColoanaStergere) || this.Columns[pNumeColoana] is DataGridViewImageColumn || this.Columns[pNumeColoana] is DataGridViewButtonColumn;
        }

        public bool ExistaLiniiBifate()
        {
            if (!this.Columns.Contains(lColoanaSelectieMultipla)) return false;

            int indexColoanaSelectieMultipla = getIndexColoanaSelectieMultipla();

            foreach (DataGridViewRow linieDGV in this.Rows)
            {
                if (linieDGV.Visible && Convert.ToBoolean(linieDGV.Cells[indexColoanaSelectieMultipla].Value) == true)
                    return true; //nu are rost sa continuam verificare atata timp cat am gasit o linie bifata si ne-am indeplini scopul
            }

            return false;
        }

        private int getIndexColoanaSelectieMultipla()
        {
            return this.Columns[lColoanaSelectieMultipla].Index;
        }

        /// <summary>
        /// Recuperam lista liniilor bifate (in functie de indexul coloanei pe care o verificam)
        /// </summary>
        /// <param name="pNumeColoana">indexul coloanei pe care o verificam</param>
        /// <returns></returns>
        public List<DataGridViewRow> GetListaLiniiBifate(int pIndexColoana)
        {
            List<DataGridViewRow> lstLiniiBifate = new List<DataGridViewRow>();

            if (pIndexColoana < 0) return lstLiniiBifate; //lista vida

            foreach (DataGridViewRow LinieDGV in this.Rows)
            {
                if (!LinieDGV.Visible) continue;

                if (Convert.ToBoolean(LinieDGV.Cells[pIndexColoana].Value) == true)
                    lstLiniiBifate.Add(LinieDGV);
            }

            return lstLiniiBifate;
        }
        public L GetListaObiecteBifate<L, T>() where L : List<T>, new()
        {
            return GetListaObiecteBifate<L, T>(this.lIndexColoanaSelectie);
        }
        public L GetListaObiecteBifate<L, T>(int pIndexColoana) where L : List<T>, new()
        {
            L lstLiniiBifate = new L();

            foreach (DataGridViewRow LinieDGV in this.Rows)
            {
                if (Convert.ToBoolean(LinieDGV.Cells[pIndexColoana].Value) == true)
                    lstLiniiBifate.Add((T)LinieDGV.Tag);
            }

            return lstLiniiBifate;
        }

        public L GetListaObiecteBifateTagCelula<L, T>(string pNumeColoana) where L : List<T>, new()
        {
            L ListaRetur = new L();
            foreach (DataGridViewRow LinieDGV in this.Rows)
            {
                if (Convert.ToBoolean(LinieDGV.Cells[this.lIndexColoanaSelectie].Value) == true && LinieDGV.Cells[pNumeColoana].Tag is T)
                    ListaRetur.Add((T)LinieDGV.Cells[pNumeColoana].Tag);
            }
            return ListaRetur;
        }

        public T GetObiectLinieSelectata<T>()
        {
            if (this.SelectedRows.Count > 0)
            {
                return (T)this.SelectedRows[0].Tag;
            }
            return default(T);
        }

        public T GetPrimulObiectBifat<T>()
        {
            if (this.ContineColoana(lColoanaSelectieMultipla))
            {
                foreach (DataGridViewRow LinieDGV in this.Rows)
                {
                    if (Convert.ToBoolean(LinieDGV.Cells[lColoanaSelectieMultipla].Value))
                        return (T)LinieDGV.Tag;
                }
            }

            return default(T);
        }

        public L GetListaObiecte<L, T>() where L : List<T>, new()
        {
            L ListaRetur = new L();
            foreach (DataGridViewRow LinieDGV in this.Rows)
            {
                if (LinieDGV.Tag is T)
                    ListaRetur.Add((T)LinieDGV.Tag);
            }
            return ListaRetur;
        }

        public L GetListaObiecteLiniiSelectate<L, T>() where L : List<T>, new()
        {
            L ListaRetur = new L();
            foreach (DataGridViewRow LinieDGV in this.SelectedRows)
            {
                if (LinieDGV.Tag is T)
                    ListaRetur.Add((T)LinieDGV.Tag);
            }
            return ListaRetur;
        }

        public L GetListaObiecteTagCelula<L, T>(string pNumeColoana) where L : List<T>, new()
        {
            L ListaRetur = new L();
            foreach (DataGridViewRow LinieDGV in this.Rows)
            {
                if (LinieDGV.Cells[pNumeColoana].Tag is T)
                    ListaRetur.Add((T)LinieDGV.Cells[pNumeColoana].Tag);
            }
            return ListaRetur;
        }
        public DataGridViewRow GetRowByObject(object pObiect)
        {
            DataGridViewRow LinieGasita = null;
            foreach (DataGridViewRow LinieDGV in this.Rows)
            {
                if (LinieDGV.Tag.Equals(pObiect))
                {
                    LinieGasita = LinieDGV;
                    break;
                }
            }
            return LinieGasita;
        }
        public void AranjeazaProprietati(Color pCuloareDGVLinieAlernanta)
        {
            this.AlternatingRowsDefaultCellStyle.BackColor = pCuloareDGVLinieAlernanta;
        }

        public void PermiteAdaugareaSiEditareaLiniilor()
        {
            this.AllowUserToAddRows = true;
            this.EditMode = DataGridViewEditMode.EditOnEnter;
            this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.ReadOnly = false;

            if (this.Columns.Count > 0)
            {
                foreach (DataGridViewColumn coloana in this.Columns)
                {
                    coloana.ReadOnly = false;
                }
            }
        }

        public void ScoateLiniiDupaListaIndecsi(List<DataGridViewRow> listaRanduriDeScos)
        {
            foreach (DataGridViewRow indexRand in listaRanduriDeScos)
            {
                this.Rows.Remove(indexRand);
            }
        }

        #endregion

        #region IMembriComuniControalePersonalizate Members

        public bool IsInModificationMode
        {
            get { return this.CurrentCell != null && this.CurrentCell.IsInEditMode; }
        }

        public bool IsInReadOnlyMode
        {
            get
            {
                return this.ReadOnly;
            }
            set
            {
            }
        }

        public string ProprietateCorespunzatoare
        {
            get
            {
                return string.Empty;
            }
            set
            {
            }
        }

        public void InsereazaText(string pText)
        {
            int Pozitie = this.SelectionStart;
            string textRezultat = this.Text;
            if (!string.IsNullOrEmpty(this.SelectedText))
                textRezultat = string.Concat(textRezultat.Substring(0, Pozitie), pText, textRezultat.Substring(Pozitie + this.SelectionLength));
            else
                textRezultat = textRezultat.Insert(Pozitie, pText);

            this.Text = textRezultat;
            this.SelectionStart = Pozitie + pText.Length;
        }

        public int SelectionStart
        {
            get
            {
                if (this.EditingControl != null)
                {
                    return ((DataGridViewTextBoxEditingControl)this.EditingControl).SelectionStart;
                }
                else
                    return 0;
            }
            set
            {
                if (this.EditingControl != null)
                {
                    ((DataGridViewTextBoxEditingControl)this.EditingControl).SelectionStart = value;
                }
            }
        }

        public int SelectionLength
        {
            get
            {
                if (this.EditingControl != null)
                {
                    return ((DataGridViewTextBoxEditingControl)this.EditingControl).SelectionLength;
                }
                else
                    return 0;
            }
            set
            {
                if (this.EditingControl != null)
                {
                    ((DataGridViewTextBoxEditingControl)this.EditingControl).SelectionLength = value;
                }
            }
        }

        public string SelectedText
        {
            get
            {
                if (this.EditingControl != null)
                {
                    return ((DataGridViewTextBoxEditingControl)this.EditingControl).SelectedText;
                }
                else
                    return string.Empty;
            }
            set
            {
            }
        }

        [Description("Pentru a implementa interfata IMembriComuniControalePersonalitate. Nu are niciun alt rol")]
        [Category("iDava")]
        public bool HideSelection
        {
            get { return true; }
            set { }
        }

        public void SelecteazaTextul()
        {

        }

        public void Paste()
        {
            if (this.CurrentCell != null && CurrentCell.ValueType != typeof(Boolean))
            {
                InsereazaText(Clipboard.GetText());
            }
        }

        public void Undo()
        {
            if (this.CurrentCell != null && this.CurrentCell.IsInEditMode && this.CurrentCell.ValueType != typeof(Boolean))
                this.Text = Convert.ToString(this.CurrentCell.Value);
        }

        public void Copy()
        {
            if (this.CurrentCell != null && this.CurrentCell.IsInEditMode && this.CurrentCell.ValueType != typeof(Boolean))
                Clipboard.SetText(this.Text);
        }

        public void Cut()
        {
            if (this.CurrentCell != null && this.CurrentCell.IsInEditMode && this.CurrentCell.ValueType != typeof(Boolean))
            {
                string textRezultat = this.Text;
                if (this.SelectionLength > 0)
                {
                    int pozitie = this.SelectionStart;
                    Clipboard.SetText(textRezultat.Substring(pozitie, this.SelectionLength));
                    textRezultat = string.Concat(textRezultat.Substring(0, pozitie), textRezultat.Substring(pozitie + this.SelectionLength));
                    this.Text = textRezultat;
                    this.SelectionStart = pozitie;
                }
                else
                    Clipboard.SetText(string.Empty);
            }
        }

        public List<int> Cauta(string pText)
        {
            List<int> ListaAparitii = new List<int>();
            if (this.CurrentCell != null && this.CurrentCell.IsInEditMode)
            {
                //In modul editare cautam textul in celula curenta
                ListaAparitii = CUtil.ExtrageListaPozitiiAparente(this.Text, pText);
            }
            else
            {
                //Cautam un text in fiecare celula din DGV

                foreach (DataGridViewRow Rand in this.Rows)
                {
                    if (RandulContineValoarea(Rand, pText))
                    {
                        ListaAparitii.Add(Rand.Index);
                    }
                }
            }

            return ListaAparitii;
        }

        public void SelecteazaLaPozitia(int pPozitie, int pLungimeText)
        {
            if (this.CurrentCell != null && this.CurrentCell.IsInEditMode)
            {
                ((DataGridViewTextBoxEditingControl)this.EditingControl).HideSelection = false;
                this.SelectionStart = pPozitie;
                this.SelectionLength = pLungimeText;
            }
            else
            {
                this.Rows[pPozitie].Selected = true;
                if (this.Rows.Count > 5)
                {
                    if (pPozitie > 5)
                        this.FirstDisplayedScrollingRowIndex = pPozitie - 5;
                    else
                        this.FirstDisplayedScrollingRowIndex = pPozitie;
                }
            }
        }

        #endregion

        #region Evenimente

        public Form GetFormParinte()
        {
            return IHMUtile.GetFormParinte(this);
        }

        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            try
            {
                base.OnColumnHeaderMouseClick(e);
                if (this.lGestioneazaAlternantaLaSortare)
                    GestioneazaAlternanta(e);
            }
            catch (Exception)
            {
                this.lSeIncarca = false;
            }
        }

        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            base.OnEditingControlShowing(e);
            e.Control.ContextMenuStrip = this.ContextMenuStrip;
        }

        protected override void OnEnter(EventArgs e)
        {
            ControaleCreateDinamic.SetControlTinta(this);
            //COMENTAT PENTRU CA SELECTEAZA AIUREA PRIMA ETAPA LA PLAN DE TRATAMENT - ORICUM NU FOLOSIM ON ENTER PE NICAIERI
            //base.OnEnter(e);
        }

        private void colSelecteaza_OnCheckBoxClicked(bool pSelectat)
        {
            try
            {
                this.lSeIncarca = true;
                this.SchimbaValoareColoana(lIndexColoanaSelectie, pSelectat, true);
                this.lSeIncarca = false;

                if (this.SelectieMultiplaEfectuata != null)
                    SelectieMultiplaEfectuata(this, pSelectat);
            }
            catch (Exception)
            {
                this.lSeIncarca = false;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        protected override void OnCellDoubleClick(DataGridViewCellEventArgs e)
        {
            //ACEASTA ORDINE ESTE IMPORTANTA!!!
            //Daca o linie contine coloana de selectie unica si ca aceasta este vizibila atunci simulam selectia
            //Daca nu si linia contine coloana de deschidere atunci simulam deschiderea obiectului corespunzator liniei respective
            //Celula de motiv inchidere poate fi in editare iar dublu click inseamna inrarea in modul editare pentru aceasta celula
            //Celula de selectie multipla nu trebuie sa genereze selectia unica sau editarea ci doar sa modifice selectia multipla
            if (e.RowIndex >= 0)
            {
                string numeColoana = this.Columns[e.ColumnIndex].Name;
                if (!numeColoana.Equals(lColoanaMotivInchidere) && !numeColoana.Equals(lColoanaSelectieMultipla))
                {
                    if (this.Columns.Contains(lColoanaSelectieUnica) && this.Columns[lColoanaSelectieUnica].Visible)
                    {
                        if (this.SelectieUnicaEfectuata != null)
                            SelectieUnicaEfectuata(this.Rows[e.RowIndex].Tag, e);
                        else
                            simuleazaClickCelula(this.Columns[lColoanaSelectieUnica].Index, e.RowIndex);
                    }
                    else
                        if (this.Columns.Contains(lColoanaEditare))
                    {
                        if (!cereEditareaLiniei(e.RowIndex))
                            simuleazaClickCelula(this.Columns[lColoanaEditare].Index, e.RowIndex);
                    }
                }
            }
            try
            {
                base.OnCellDoubleClick(e);
            }
            catch (Exception)
            {
            }
        }

        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string numeColoana = this.Columns[e.ColumnIndex].Name;
                if (numeColoana.Equals(lColoanaSelectieUnica))
                {
                    if (this.SelectieUnicaEfectuata != null)
                    {
                        SelectieUnicaEfectuata(this.Rows[e.RowIndex].Tag, e);
                        return;
                    }
                }
                else
                {
                    if (numeColoana.Equals(lColoanaSelectieMultipla))
                    {
                        //Ca sa nu fie apelat si cand schimbam valoarea la schimbarea selectiei
                        if (!this.lSeIncarca)
                        {
                            this.lSeIncarca = true;

                            try
                            {

                                if (e.RowIndex != this.lIndexUltimaLinieBifata)
                                {
                                    if (ModifierKeys == Keys.Shift)
                                    {
                                        //bifam toate liniile de la ultima linie bifata pana la actuala
                                        int indexStart, indexStop;
                                        if (e.RowIndex > this.lIndexUltimaLinieBifata)
                                        {
                                            indexStart = this.lIndexUltimaLinieBifata + 1;
                                            indexStop = e.RowIndex;
                                        }
                                        else
                                        {
                                            indexStart = e.RowIndex;
                                            indexStop = this.lIndexUltimaLinieBifata - 1;
                                        }

                                        for (int i = indexStart; i <= indexStop; i++)
                                        {
                                            //Nu schimbam unde nu ar trebui
                                            if (this.Rows[i].Cells[lColoanaSelectieMultipla].ReadOnly) continue;

                                            this.Rows[i].Selected = !Convert.ToBoolean(this.Rows[i].Cells[lColoanaSelectieMultipla].Value);
                                            this.Rows[i].Cells[lColoanaSelectieMultipla].Value = !Convert.ToBoolean(this.Rows[i].Cells[lColoanaSelectieMultipla].Value);
                                        }
                                    }
                                    else
                                        this.Rows[e.RowIndex].Selected = !Convert.ToBoolean(this.Rows[e.RowIndex].Cells[lColoanaSelectieMultipla].Value);

                                    //salvam indexul ultimei linii bifate
                                    this.lIndexUltimaLinieBifata = e.RowIndex;
                                }
                            }
                            catch (Exception)
                            {
                            }
                            finally
                            {
                                this.lSeIncarca = false;
                            }
                        }
                    }
                    else
                        if (numeColoana.Equals(lColoanaStergere))
                    {
                        if (cereStergereaLiniei(e.RowIndex))
                        {
                            //Nu are sens sa continuam
                            return;
                        }
                    }
                    else
                        if (numeColoana.Equals(lColoanaEditare))
                    {
                        if (cereEditareaLiniei(e.RowIndex))
                        {
                            //Nu are sens sa continuam
                            return;
                        }
                    }
                    else
                        if (numeColoana.Equals(lColoanaDeschideClasic))
                    {
                        if (cereEditareaLiniei(e.RowIndex))
                        {
                            //Nu are sens sa continuam
                            return;
                        }
                    }
                }
            }

            base.OnCellClick(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //Daca avem o linie selectata si exista butonul de selectie unica atunci selectam acea linie
            if (this.SelectedRows.Count == 1 && e.KeyData == Keys.Enter)
            {
                if (this.Columns.Contains(lColoanaSelectieUnica) && this.Columns[lColoanaSelectieUnica].Visible)
                {
                    if (this.SelectieUnicaEfectuata != null)
                        SelectieUnicaEfectuata(this.SelectedRows[0].Tag, new DataGridViewCellEventArgs(this.Columns[lColoanaSelectieUnica].Index, this.SelectedRows[0].Index));
                    else
                        simuleazaClickCelula(this.Columns[lColoanaSelectieUnica].Index, this.SelectedRows[0].Index);
                }
                else
                    base.OnKeyDown(e);
            }
            else
                base.OnKeyDown(e);
        }

        protected override void OnSorted(EventArgs e)
        {
            //La TGV-uri trebuie folosit alt eveniment deoarece la adaugarea coloanelor este specificat express sa nu se faca sortare

            if (this.lSeIncarca) return;

            //Dupa sortare vom salva coloana folosita pentru a sorta lista in acelasi fel data viitoare
            string nume = GetDenumireUnica();

            if (!string.IsNullOrEmpty(nume))
            {
                string coloanaSortare = this.SortedColumn.Name;
                SortOrder ordineSortare = this.SortOrder;

                if (!string.IsNullOrEmpty(coloanaSortare) && ordineSortare != System.Windows.Forms.SortOrder.None)
                {
                    //Salvam modalitatea de sortare
                    if (CCL.UI.IHMUtile._ComunicareIHM != null)
                        CCL.UI.IHMUtile._ComunicareIHM.SeteazaColoanaSortare(nume, coloanaSortare, Convert.ToInt32(ordineSortare) - 1);
                }
            }

            base.OnSorted(e);
        }

        protected override void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
        {
            base.OnColumnWidthChanged(e);

            //Nu are rost sa salvam dimensiunea pentru ceva ce este autosize sau fill
            if (!this.lSeIncarca && this.lPosibilaSchimbareALatimii && (e.Column.AutoSizeMode == DataGridViewAutoSizeColumnMode.None || e.Column.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet))
            {
                if (IHMUtile._ComunicareIHM != null)
                    IHMUtile._ComunicareIHM.SeteazaLatimeColoana(GetDenumireUnica(), e.Column.Name, e.Column.Width);
            }
        }

        //protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        //{
        //    base.OnCellFormatting(e);

        //    //e.CellStyle.BackColor = IHMStilAplicatie._SDGVFundal;
        //    //e.CellStyle.ForeColor = IHMStilAplicatie._SDGVCuloareDGVTextLinieNormala;
        //}

        private bool lPosibilaSchimbareALatimii = false;
        protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
        {
            if (this.Columns[e.ColumnIndex].Name.Equals(lColoanaSelectieMultipla))
            {
                this.lSeIncarca = true;

                base.OnCellMouseDown(e);

                this.lSeIncarca = false;
            }
            else
            {
                base.OnCellMouseDown(e);
            }

            if (e.RowIndex < 0)
                this.lPosibilaSchimbareALatimii = true;
        }

        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseEnter(e);

            if (e.RowIndex < 0)
                this.lPosibilaSchimbareALatimii = true;
        }

        protected override void OnCellEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellEnter(e);

            if (e.RowIndex < 0)
                this.lPosibilaSchimbareALatimii = true;
        }

        protected override void OnCellMouseLeave(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseLeave(e);

            if (e.RowIndex < 0)
                this.lPosibilaSchimbareALatimii = false;
        }

        protected override void OnColumnDisplayIndexChanged(DataGridViewColumnEventArgs e)
        {
            base.OnColumnDisplayIndexChanged(e);

            if (!this.lSeIncarca)
            {
                if (IHMUtile._ComunicareIHM != null)
                    IHMUtile._ComunicareIHM.SeteazaIndexColoana(GetDenumireUnica(), e.Column.Name, e.Column.DisplayIndex);
            }
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            if (this.lSeIncarca) return;

            base.OnSelectionChanged(e);
            try
            {
                if (!this.lSeIncarca && this.Columns.Contains(lColoanaSelectieMultipla) && this.Columns[lColoanaSelectieMultipla].Visible && (this.CurrentCell == null || !this.Columns[this.CurrentCell.ColumnIndex].Name.Equals(lColoanaSelectieMultipla)))
                {
                    try
                    {
                        this.lSeIncarca = true;
                        bifeazaMultiSelect();
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        this.lSeIncarca = false;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

    }
}
