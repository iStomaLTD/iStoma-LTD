using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CCL.UI
{
    public class PanelPersonalizat : System.Windows.Forms.Panel
    {
        #region Declaratii generale

        private EnumTipPanel _lTipPanel = EnumTipPanel.Nespecificat;
        protected bool lSeIncarca = false;

        #endregion

        #region Enumerari si structuri

        public enum EnumTipPanel
        {
            Nespecificat = 1,
            MeniuStanga = 2,
            Tab = 3
        }

        #endregion

        #region Proprietati

        [Description("Tipul panelului. Poate fi util pentru aplicarea de skin (preferinte utilizator) sau operatii recursive cu controalele unui formular")]
        [Category("iDava")]
        public EnumTipPanel Tip
        {
            get { return this._lTipPanel; }
            set
            {
                this._lTipPanel = value;
                switch (this._lTipPanel)
                {
                    case EnumTipPanel.Nespecificat:
                        this.BackColor = System.Drawing.Color.White;
                        break;
                    case EnumTipPanel.MeniuStanga:
                        this.BackColor = System.Drawing.Color.White;
                        break;
                    case EnumTipPanel.Tab:
                        this.BackColor = System.Drawing.Color.White;
                        break;
                    default:
                        this.BackColor = System.Drawing.Color.White;
                        break;
                }
            }
        }

        #endregion

        #region Constructor

        public PanelPersonalizat()
        {
            SeteazaDoubleBuffer();
            InitializeazaPanel();
        }

        public PanelPersonalizat(IContainer container)
            : this()
        {
            container.Add(this);
        }

        private void SeteazaDoubleBuffer()
        {
            // this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.Font = CDL.iStomaLab.CDefinitiiComune._Font_DPI;
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        #endregion

        #region Metode

        protected Form GetFormParinte()
        {
            return IHMUtile.GetFormParinte(this);

            //Control parinte = this.Parent;

            //do
            //{
            //    if (parinte != null)
            //    {
            //        if (parinte is Form)
            //            return parinte as Form;
            //        else
            //            parinte = parinte.Parent;
            //    }

            //} while (parinte == null);

            //return null;
        }

        protected void incepeIncarcarea()
        {
            this.lSeIncarca = true;
        }

        protected void finalizeazaIncarcarea()
        {
            this.lSeIncarca = false;
        }

        private void InitializeazaPanel()
        {
            //this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            //this.BackColor = System.Drawing.Color.LightPink;
        }

        public void AscundeControaleleIncarcate()
        {
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Visible = false;
            }
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    if (this.BorderStyle == BorderStyle.FixedSingle)
        //        ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, this.Width - 1, this.Height - 1), Color.Red, ButtonBorderStyle.Solid);
        //}

        //protected override void OnResize(EventArgs eventargs)
        //{
        //    base.OnResize(eventargs);
        //    Refresh();
        //}

        #endregion

        public void AplicaFactorDPI()
        {
            //this.Location = new System.Drawing.Point(Convert.ToInt32(this.Location.X * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X), Convert.ToInt32(this.Location.Y * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_Y));
            this.Width = Convert.ToInt32(this.Width * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
            this.Height = Convert.ToInt32(this.Height * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_Y);
        }
    }
}
