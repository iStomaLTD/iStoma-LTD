using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CCL.UI
{
    public class LinkLabelPersonalizat : LinkLabel
    {

        #region Declaratii generale

        private bool lUtilizeazaToolTip = false;
        private string lMesajToolTip = string.Empty;
        private string lTitluToolTip = string.Empty;
        private ToolTipIcon lToolTipIcon = ToolTipIcon.Info;

        #endregion

        #region Proprietati

        [Description("Precizam daca se afiseaza tool-tip-ul cand mouse-ul este deasupra butonului")]
        [DefaultValue(false)]
        [Category("iDava")]
        public bool UtilizeazaToolTip
        {
            get { return this.lUtilizeazaToolTip; }
            set { this.lUtilizeazaToolTip = value; }
        }

        [Description("Iconita tool-tip-ului; Are sens doar daca se utilizeaza tool-tip-ul")]
        [Category("iDava")]
        public ToolTipIcon ToolTipIcon
        {
            get { return this.lToolTipIcon; }
            set { this.lToolTipIcon = value; }
        }

        [Description("Titlul tool-tip-ului; Are sens doar daca se utilizeaza tool-tip-ul")]
        [Category("iDava")]
        public string ToolTipTitle
        {
            get { return this.lTitluToolTip; }
            set { this.lTitluToolTip = value; }
        }

        [Description("Mesajul tool-tip-ului; Are sens doar daca se utilizeaza tool-tip-ul")]
        [Category("iDava")]
        public string ToolTipMessage
        {
            get { return this.lMesajToolTip; }
            set { this.lMesajToolTip = value; }
        }

        #endregion

        #region Constructori

        public LinkLabelPersonalizat()
        {
            SeteazaDoubleBuffer();
        }

        public LinkLabelPersonalizat(IContainer container)
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

        #region Evenimente supra-scrise

        protected override void OnMouseHover(EventArgs e)
        {
            if (this.lUtilizeazaToolTip)
            {
                ControaleCreateDinamic.AfiseazaToolTip(this, this.lToolTipIcon, this.lTitluToolTip, this.lMesajToolTip);
            }
            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (this.lUtilizeazaToolTip)
            {
                ControaleCreateDinamic.AscundeToolTip(this);
            }
            base.OnMouseLeave(e);
        }

        #endregion

    }
}
