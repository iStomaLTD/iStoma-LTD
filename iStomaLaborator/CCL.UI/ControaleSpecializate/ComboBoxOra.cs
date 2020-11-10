using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace CCL.UI
{
    public partial class ComboBoxOra : ComboBoxPersonalizat
    {

        #region Declaratii generale

        private EnumPas lPas = EnumPas.CinciMinute;
        private EnumTipLista lTipLista = EnumTipLista.OreMinute;

        #endregion

        #region Enumerari si Structuri

        public struct StructPas
        {
            public EnumPas IdEnum { get; set; }
            public string Denumire { get; set; }
            public int Id { get { return Convert.ToInt32(this.IdEnum); } }

            public StructPas(EnumPas pIdEnum, string pDenumire) : this()
            {
                this.IdEnum = pIdEnum;
                this.Denumire = pDenumire;
            }

            public override string ToString()
            {
                return this.Denumire;
            }

            public override bool Equals(object obj)
            {
                if (obj is EnumPas || obj is int || obj is long)
                    return this.IdEnum.Equals((EnumPas)obj);

                if (obj is StructPas)
                    return this.IdEnum.Equals(((StructPas)obj).IdEnum);

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static List<StructPas> GetLista()
            {
                List<StructPas> listaRetur = new List<StructPas>();

                listaRetur.Add(GetStructByEnum(EnumPas.CinciMinute));
                listaRetur.Add(GetStructByEnum(EnumPas.SfertDeOra));
                listaRetur.Add(GetStructByEnum(EnumPas.JumatateDeOra));
                listaRetur.Add(GetStructByEnum(EnumPas.OraFixa));

                return listaRetur;
            }

            public static StructPas GetStructByEnum(EnumPas pIdEnum)
            {
                switch (pIdEnum)
                {
                    case EnumPas.OraFixa:
                        return new StructPas(pIdEnum, "60");
                    case EnumPas.JumatateDeOra:
                        return new StructPas(pIdEnum, "30");
                    case EnumPas.SfertDeOra:
                        return new StructPas(pIdEnum, "15");
                }

                return new StructPas(pIdEnum, "5");
            }
        }

        public enum EnumPas
        {
            OraFixa = 60,
            JumatateDeOra = 30,
            SfertDeOra = 15,
            CinciMinute = 5
        }

        private new enum EnumTipLista
        {
            OreMinute,
            Ore,
            DurataOreMinute
        }

        #endregion

        #region Proprietati

        public EnumPas Pas
        {
            get { return this.lPas; }
            set { this.lPas = value; }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                incepeIncarcarea();

                //if (this.DropDownStyle != ComboBoxStyle.DropDownList && this.SelectedItem != null)
                //    this.SelectedItem = null;

                this.BeginUpdate();

                base.setText(value);

                this.EndUpdate();

                finalizeazaIncarcarea();
            }
        }

        public void UpdateItems(DateTime pData)
        {
            UpdateItems(string.Format("{0:HH}:{0:mm}", pData));
        }

        /// <summary>
        /// Util pentru a avea ora selectata printre elem listei
        /// altfel textul nu poate fi setat cu ceva din afara listei
        /// </summary>
        /// <param name="value"></param>
        public void UpdateItems(string value)
        {
            this.BeginUpdate();

            if (!value.Equals("00:00"))
            {
                if (this.Items.Count > 0 && !this.Items[0].Equals("00:00"))
                {
                    this.Items.RemoveAt(0);
                }

                if (!this.Items.Contains(value))
                {
                    this.Items.Insert(0, value);
                }
            }

            this.EndUpdate();
        }

        [Browsable(false)]
        public DateTime TextCaData
        {
            get { return new DateTime(1, 1, 1, this.Ora, this.Minut, 0); }
            set { this.Text = string.Format("{0:00}:{1:00}", value.Hour, value.Minute); }
        }

        public int OraMinut
        {
            get { return this.Ora * 60 + this.Minut; }
        }

        public int Ora
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Text))
                {
                    if (this.Text.Length == 5)
                        return Convert.ToInt32(this.Text.Substring(0, 2));
                    else
                        if (this.Text.Length > 0)
                    {
                        try
                        {
                            return Convert.ToInt32(this.Text);
                        }
                        catch (Exception)
                        {
                        }

                        return 0;
                    }
                }
                return 0;
            }
        }

        public int Minut
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Text) && this.Text.Length == 5)
                {
                    return Convert.ToInt32(this.Text.Substring(3, 2));
                }
                return 0;
            }
        }

        public int DurataInMinute
        {
            get
            {
                int oraDinDurata = 0;
                int minutulDinDurata = 0;
                if (this.lTipLista == EnumTipLista.DurataOreMinute && this.SelectedItem != null)
                {
                    string textAfisat = this.SelectedItem.ToString();
                    int indexH = textAfisat.IndexOf("h");
                    oraDinDurata = Convert.ToInt32(textAfisat.Substring(0, indexH));
                    minutulDinDurata = Convert.ToInt32(textAfisat.Substring(indexH + 1, (textAfisat.IndexOf("m")) - (indexH + 1)));
                }

                return oraDinDurata * 60 + minutulDinDurata;
            }
        }

        #endregion

        #region Constructor si Initializare

        public ComboBoxOra()
        {
        }

        public ComboBoxOra(IContainer container)
            : base(container)
        {
        }

        public void Initializeaza(EnumPas pPas)
        {
            Initializeaza(pPas, true, 0, 23);
        }

        public void Initializeaza(EnumPas pPas, bool pAfiseazaMinutele, int pPrimaOra, int pUltimaOra)
        {
            this.lTipLista = (pAfiseazaMinutele) ? EnumTipLista.OreMinute : EnumTipLista.Ore;
            if (this.lPas != pPas || this.Items == null || this.Items.Count == 0)
            {
                this.lPas = pPas;
                this.Items.Clear();
                int ora = pPrimaOra;
                int minut = 0;
                for (int i = pPrimaOra; i <= pUltimaOra * (60 / (int)this.lPas); i++)
                {
                    this.Items.Add(string.Format(getFormatAfisaj(), ora, minut));
                    minut += (int)lPas;
                    if (minut >= 60)
                    {
                        minut = 0;
                        ora += 1;
                    }
                }
            }
        }

        public void Initializeaza(EnumPas pPas, int pDurataMaximaInMinute)
        {
            this.lPas = pPas;
            this.lTipLista = EnumTipLista.DurataOreMinute;
            int pas = (int)this.lPas;
            for (int i = pas; i <= pDurataMaximaInMinute; i += pas)
            {
                this.Items.Add(string.Format(getFormatAfisaj(), i / 60, i % 60));
            }
        }

        private string getFormatAfisaj()
        {
            switch (this.lTipLista)
            {
                case EnumTipLista.OreMinute:
                    return "{0:00}:{1:00}";
                case EnumTipLista.Ore:
                    return "{0}";
                case EnumTipLista.DurataOreMinute:
                    return "{0}h {1}m";
            }

            return "{0}";
        }

        public void SelecteazaElement(int pOra)
        {
            SelecteazaElement(pOra, false);
        }

        public void SelecteazaElement(int pOra, int pMinut)
        {
            this.SelectedItem = string.Format(getFormatAfisaj(), pOra, pMinut);
        }

        public void SelecteazaElement(int pOraMinut, bool pFormatOraMinut)
        {
            if (pFormatOraMinut)
            {
                int minut = pOraMinut % 60;
                int ora = (pOraMinut - minut) / 60;

                SelecteazaElement(ora, minut);
            }
            else
                SelecteazaElement(pOraMinut, -1);
        }

        #endregion

        #region Evenimente

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            try
            {
                //Daca nu avem o masca atunci vom accepta doar cifre
                if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ':')
                {
                    e.Handled = false;
                    if (this.Text.Length > 4 && this.SelectionLength <= 0)
                    {
                        //Permitem stergerea cu backspace
                        if (e.KeyChar != '\b')
                            e.Handled = true;
                    }
                    else
                    {
                        string noulText = string.Concat(this.Text.Substring(0, this.SelectionStart), e.KeyChar, this.Text.Substring(this.SelectionStart + this.SelectionLength));
                        int startSelectie = 0;
                        int lungimeSelectie = 0;

                        if (this.Text.Length - this.SelectionLength == 0)
                        {
                            if (Char.IsNumber(e.KeyChar))
                            {
                                if (Convert.ToInt32(e.KeyChar.ToString()) > 3)
                                {
                                    noulText = string.Concat("0", e.KeyChar, ":", "00");
                                    startSelectie = 3;
                                    lungimeSelectie = 2;
                                }
                                else
                                {
                                    noulText = string.Concat(e.KeyChar, "0", ":", "00");
                                    startSelectie = 1;
                                    lungimeSelectie = 4;
                                }

                            }
                        }
                        else
                        {
                            if (this.SelectionStart == 1)
                            {
                                noulText += ":00";
                                startSelectie = 3;
                                lungimeSelectie = 2;
                                e.Handled = true;
                            }
                            else
                            {
                                if (this.SelectionStart == 3)
                                {
                                    noulText += "0";
                                    startSelectie = 4;
                                    lungimeSelectie = 1;
                                    e.Handled = true;
                                }
                            }
                        }

                        this.Text = noulText;
                        this.SelectionStart = startSelectie;
                        this.SelectionLength = lungimeSelectie;

                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
                //In caz de eroare nu facem nik
            }
        }

        protected override void OnMouseHover(EventArgs e)
        {
            //if (this.DropDownStyle != ComboBoxStyle.DropDown)
            this.Focus();
            base.OnMouseHover(e);
        }

        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        public DateTime GetData(DateTime pDataSursa, int pMinuteDataReturMaiMicaDataSursa)
        {
            DateTime data = new DateTime(pDataSursa.Year, pDataSursa.Month, pDataSursa.Day, this.Ora, this.Minut, 0);

            if (data > pDataSursa)
                return data;

            return pDataSursa.AddMinutes(pMinuteDataReturMaiMicaDataSursa);
        }

        #endregion

    }
}
