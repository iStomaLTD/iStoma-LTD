using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace CCL.UI
{
    public class ListBoxPersonalizat : System.Windows.Forms.ListBox
    {

        #region Declaratii generale

        private bool lEsteInModModificare = true;

        private bool lUtilizeazaToolTip = false;
        private ToolTipIcon lToolTipIcon = ToolTipIcon.Info;

        #endregion

        #region Proprietati

        [Description("Indica daca lista este in modificare sau nu")]
        [Category("iDava")]
        [Browsable(false)]
        [DefaultValue(true)]
        public bool IsInModificationMode
        {
            get
            {
                return this.lEsteInModModificare;
            }
        }

        [Description("Precizam daca se afiseaza tool-tip-ul cand mouse-ul este deasupra butonului")]
        [DefaultValue(false)]
        [Category("iDava")]
        public bool UtilizeazaToolTip
        {
            get { return this.lUtilizeazaToolTip; }
            set { this.lUtilizeazaToolTip = value; }
        }

        #endregion

        #region Constructori

        public ListBoxPersonalizat()
        {
            SeteazaDoubleBuffer();
        }

        public ListBoxPersonalizat(IContainer container)
            : this()
        {
            container.Add(this);
        }

        private void SeteazaDoubleBuffer()
        {
            // this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        #endregion

        #region Metode Publice

        public void AllowModification(bool pControlInModificare)
        {
            this.lEsteInModModificare = pControlInModificare;
        }

        public void Incarca<T>(List<T> pListaElemente)
        {
            this.BeginUpdate();

            this.Items.Clear();

            foreach (T element in pListaElemente)
            {
                this.Items.Add(element);
            }

            this.ClearSelected();

            this.EndUpdate();
        }

        #endregion

        #region Evenimente

        protected override void OnMouseHover(EventArgs e)
        {
            if (this.lUtilizeazaToolTip && this.SelectedItem != null)
                ControaleCreateDinamic.AfiseazaToolTip(this, this.lToolTipIcon, string.Empty, this.SelectedItem.ToString());
            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            ControaleCreateDinamic.AscundeToolTip(this);
            base.OnMouseLeave(e);
        }

        #endregion

    }
}
