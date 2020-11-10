using System;
using System.ComponentModel;

namespace CCL.UI
{
    public partial class ComboBoxNumeric : ComboBoxPersonalizat
    {
        #region Declaratii generale

        private int _lSolInferior = 0;
        private int _lSolSuperior = 10;
        private int _lTreapta = 1;

        #endregion

        #region Proprietati

        public int SolInferior
        {
            get { return this._lSolInferior; }
            set { this._lSolInferior = value; }
        }

        public int SolSuperior
        {
            get { return this._lSolSuperior; }
            set { this._lSolSuperior = value; }
        }

        public int Treapta
        {
            get { return this._lTreapta; }
            set { this._lTreapta = value; }
        }
        
        public int ValoareaIntrodusa
        {
            get {
                if (!string.IsNullOrEmpty(this.Text))
                    return Convert.ToInt32(this.Text);

                return this._lSolInferior;
            }
        }

        #endregion

        public ComboBoxNumeric()
        {
            for (int i = this._lSolInferior; i < this._lSolSuperior; i += this._lTreapta)
            {
                this.Items.Add(i);
            }
        }

        public ComboBoxNumeric(IContainer container)
            : base(container)
        {
        }
    }
}
