using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CCL.UI
{
    [DefaultEvent("ParametrageClick")]
    public partial class ControlLabelParam : LabelPersonalizat,
        CCL.UI.IMembriComuniControalePersonalizate
    {

        #region Declaratii generale

        public event System.EventHandler ParametrageClick;
        private ButtonPersonalizat _boutonParam;
        private ToolTip _xToolTipIntern = new ToolTip();

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        [Browsable(false)]
        public bool PermiteExport { get { return false; } }
        [Browsable(false)]
        public bool PermitePrintare { get { return false; } }
        [Browsable(false)]
        public bool PermiteCopiereTabel { get { return false; } }

        [Category("iDava")]
        public bool AfficheBoutonParam
        {
            get
            {
                if (this._boutonParam != null)
                {
                    return this._boutonParam.Visible;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (this._boutonParam != null)
                {
                    this._boutonParam.Visible = value;
                }
            }
        }

        #endregion

        #region Constructor si Initializare

        public ControlLabelParam()
        {
            AdaugaButonParametraj();
            AdaugaMeniuContextual();
        }

        public ControlLabelParam(IContainer container)
            : base(container)
        {
            AdaugaButonParametraj();
            AdaugaMeniuContextual();
        }

        #endregion

        #region Evenimente

        protected override void OnEnter(EventArgs e)
        {
            ControaleCreateDinamic.SetControlTinta(this);
            base.OnEnter(e);
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            //Me._labelParam.Top = Me.Height - Me._labelParam.Height
            this._boutonParam.Left = this.Width - this._boutonParam.Width;
            this._boutonParam.Height = this.Height - 3;
        }

        private void labelParam_Click(Object sender, System.EventArgs e)
        {
            if (this.ParametrageClick != null)
                ParametrageClick(sender, e);
        }

        #endregion

        #region Metode private

        private void AdaugaButonParametraj()
        {
            this._boutonParam = new ButtonPersonalizat();
            this._boutonParam.TipButon = ButtonPersonalizat.EnumTipButon.Parametraj;
            this._boutonParam.BackColor = System.Drawing.Color.FromArgb(255, 102, 102, 255); //Drawing.Color.Blue
            this._boutonParam.Width = 12;
            this._boutonParam.Text = "";
            this.Controls.Add(this._boutonParam);

            this._boutonParam.Top = 1;
            this._boutonParam.FlatStyle = FlatStyle.Popup;
            this._boutonParam.Click += new EventHandler(labelParam_Click);
        }

        #endregion

        #region Metode publice

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

        public new void AllowModification(bool pModificarePermisa)
        {
            this._boutonParam.Visible = pModificarePermisa;
            base.AllowModification(pModificarePermisa);
        }

        #endregion

    }
}
