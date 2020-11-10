using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CCL.UI
{
    public class PictureBoxPersonalizat : PictureBox
    {
        #region Declaratii Generale

        private string lContinutToolTip;
        private bool lUtilizamToolTip = false;
        private string lTitluToolTip = string.Empty;
        private ToolTipIcon lToolTipIcon = ToolTipIcon.Info;

        #endregion

        #region Proprietati

        [Description("Icoana informativa a ToolTip-ului")]
        [Category("iDava")]
        public ToolTipIcon IcoanaToolTip
        {
            get { return this.lToolTipIcon; }
            set { this.lToolTipIcon = value; }
        }

        [Description("Pentru a afisa ToolTip-ul la evenimentul de OnMouseOver")]
        [Category("iDava")]
        public bool UtilizamToolTip
        {
            get { return this.lUtilizamToolTip; }
            set { this.lUtilizamToolTip = value; }
        }

        [Description("Titlul pe care il va avea ToolTip-ul")]
        [Category("iDava")]
        public string TitluToolTip
        {
            get { return this.lTitluToolTip; }
            set { this.lTitluToolTip = value; }
        }

        [Description("Continutul pe care il va avea ToolTip-ul")]
        [Category("iDava")]
        public string ContinutToolTip
        {
            get { return this.lContinutToolTip; }
            set { this.lContinutToolTip = value; }
        }

        #endregion

        #region Constructori

        public PictureBoxPersonalizat()
        {
            SeteazaDoubleBuffer();
        }

        public PictureBoxPersonalizat(IContainer container):this()
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

        #region Evenimente Supra-scrise

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (this.lUtilizamToolTip)
            {
                ControaleCreateDinamic.AfiseazaToolTip(this, this.lToolTipIcon, this.lTitluToolTip, this.lContinutToolTip);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            ControaleCreateDinamic.AscundeToolTip(this);
            base.OnMouseLeave(e);
        }

        #endregion
    }
}
