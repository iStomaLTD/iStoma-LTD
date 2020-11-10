using System.Drawing;
using System.Windows.Forms;
using EnumTipText = CDL.iStomaLab.CDefinitiiComune.EnumTipText;

namespace CCL.UI.Caramizi
{
    public partial class controlGestiuneText : UserControl
    {

        #region Declaratii generale

        private bool lEcranInModificare = true;
        private EnumTipText lTipText = EnumTipText.Simplu;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public controlGestiuneText()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.ctrlEditorHTML.MinimumSize = Size.Empty;
            this.ctrlEditorHTML.AscundeButonSalvare();
            this.ctrlSMS.MinimumSize = Size.Empty;
        }

        public void Initializeaza(string pTextDeAfisat, EnumTipText pTipText)
        {
            Initializeaza(pTextDeAfisat, pTipText, 145);
        }

        public void Initializeaza(string pTextDeAfisat, EnumTipText pTipText, int pLungimeSMS)
        {
            this.SuspendLayout();

            this.lTipText = pTipText;
            switch (this.lTipText)
            {
                case EnumTipText.HTML:
                    this.ctrlEditorHTML.Initializeaza(pTextDeAfisat);
                    this.ctrlEditorHTML.Visible = true;
                    this.txtTextSimplu.Visible = false;
                    this.ctrlSMS.Visible = false;
                    break;
                case EnumTipText.SMS:
                    this.ctrlSMS.Initializeaza(pLungimeSMS, pTextDeAfisat);
                    this.ctrlSMS.Visible = true;
                    this.txtTextSimplu.Visible = false;
                    this.ctrlEditorHTML.Visible = false;
                    break;
                case EnumTipText.Simplu:
                    this.txtTextSimplu.Text = pTextDeAfisat;
                    this.txtTextSimplu.Visible = true;
                    this.ctrlEditorHTML.Visible = false;
                    this.ctrlSMS.Visible = false;
                    break;
            }

            this.ResumeLayout();
        }

        #endregion

        #region Evenimente



        #endregion

        #region Metode private



        #endregion

        #region Metode publice



        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
            switch (this.lTipText)
            {
                case EnumTipText.HTML:
                    this.ctrlEditorHTML.AllowModification(this.lEcranInModificare);
                    break;
                case EnumTipText.SMS:
                    this.ctrlSMS.AllowModification(this.lEcranInModificare);
                    break;
                case EnumTipText.Simplu:
                    this.txtTextSimplu.AllowModification(this.lEcranInModificare);
                    break;
            }
        }

        #endregion

    }
}
