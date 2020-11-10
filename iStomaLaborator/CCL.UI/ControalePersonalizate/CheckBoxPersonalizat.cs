using System;
using System.ComponentModel;
using System.Windows.Forms;
using ILL.iStomaLab;

namespace CCL.UI
{
    public class CheckBoxPersonalizat : System.Windows.Forms.CheckBox, IAllowModification
    {
        #region Declaratii Generale

        private bool lIsInModificationMode = true;
        private bool lIsInReadOnlyMode = false;
        private string lProprietateCorespunzatoare; //utila pentru Reflection (initializare dinamica)

        public event CEvenimente.ZonaModificata CerereUpdate;

        #endregion

        #region Proprietati

        [Description("Precizam expres ca acest control este intotdeauna in mod ReadOnly (Metoda AllowModification nu va avea niciun efect)")]
        [Category("iDava")]
        public bool IsInReadOnlyMode
        {
            get { return this.lIsInReadOnlyMode; }
            set
            {
                this.lIsInReadOnlyMode = value;
                this.Enabled = !this.lIsInReadOnlyMode;
            }
        }

        [Description("Precizam numele proprietatii obiectului sursa ce contine valoarea cu care vom initializa textul acestei zone. Utila pentru utilizarea initializarii dinamice.")]
        [Category("iDava")]
        public string ProprietateCorespunzatoare
        {
            get { return this.lProprietateCorespunzatoare; }
            set
            {
                this.lProprietateCorespunzatoare = value;
            }
        }

        #endregion

        #region Constructori

        public CheckBoxPersonalizat()
        {
            SeteazaDoubleBuffer();
        }

        public CheckBoxPersonalizat(IContainer container)
            : this()
        {
            container.Add(this);
        }

        private void SeteazaDoubleBuffer()
        {
            //this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
           // this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        #endregion

        #region Metode

        public void Goleste()
        {
            base.Checked = false;
        }

        /// <summary>
        /// Trecem din mod modificare in mod lectura si invers
        /// </summary>
        /// <param name="pbInModificationMode"></param>
        public void AllowModification(bool pbInModificationMode)
        {
            this.lIsInModificationMode = pbInModificationMode && !this.lIsInReadOnlyMode;
            this.Enabled = this.lIsInModificationMode;
        }

        #endregion

        #region Evenimente

        protected override void OnCheckedChanged(EventArgs e)
        {
            if (this.CerereUpdate != null)
            {
                CerereUpdate(this, this.lProprietateCorespunzatoare, this.Checked);
            }
            base.OnCheckedChanged(e);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
        }

        #endregion

    }
}
