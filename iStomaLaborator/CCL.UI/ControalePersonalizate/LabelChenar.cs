using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CCL.UI.ControalePersonalizate
{
    public class LabelChenar : LabelPersonalizat, IDisposable
    {

        #region Declaratii generale

        //private Brush BRUSH_FUNDAL;
        //private Brush BRUSH_TEXT;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati

        public bool PermiteRedimensionarea { get; internal set; }

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                Initializeaza();
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                Initializeaza();
            }
        }

        #endregion

        #region Constructor si Initializare

        public LabelChenar()
            : base()
        {
            Initializeaza();
        }

        public LabelChenar(IContainer container)
            : base(container)
        {
            Initializeaza();
        }

        private void Initializeaza()
        {
            //this.BRUSH_FUNDAL = new LinearGradientBrush(this.DisplayRectangle, Color.Black, Color.DarkGray, LinearGradientMode.Vertical);// new SolidBrush(this.BackColor);
            //this.BRUSH_TEXT = Brushes.White; // new SolidBrush(base.ForeColor);
        }

        private Brush getBRUSH_TEXT()
        {
            return Brushes.White;
        }

        private Brush getBRUSH_FUNDAL()
        {
           return new LinearGradientBrush(this.DisplayRectangle, Color.Black, Color.DarkGray, LinearGradientMode.Vertical);
        }

        #endregion

        #region Evenimente

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle newRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y,
            ClientRectangle.Width, ClientRectangle.Height);

            SizeF textSize = g.MeasureString(this.Text, base.Font);
            int textX = (int)(base.Size.Width / 2) - (int)(textSize.Width / 2);
            int textY = (int)(base.Size.Height / 2) - (int)(textSize.Height / 2);

            g.SmoothingMode = SmoothingMode.HighQuality;

            using (Brush BRUSH_FUNDAL = getBRUSH_FUNDAL())
            {
                g.FillRectangle(BRUSH_FUNDAL, newRect);
                g.DrawRectangle(Pens.Black, newRect.X, newRect.Y, newRect.Width - 1, newRect.Height - 1);

                if (this.PermiteRedimensionarea)
                {
                    //Desenam zona de redimensionare a ecranului
                    g.DrawLine(IHMUtile.PENSULA_CHENAR, newRect.X + 2, newRect.Y + 2, newRect.X + 13, newRect.Y + 2);
                    g.DrawLine(IHMUtile.PENSULA_CHENAR, newRect.X + 2, newRect.Y + 2, newRect.X + 2, newRect.Y + 13);
                }

                if (!string.IsNullOrEmpty(this.Text))
                    g.DrawString(this.Text, base.Font, Brushes.White, textX, textY);
            }
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if (this.PermiteRedimensionarea)
            {
                //Daca suntem in zona de redimensionare semnalizam acest lucru
                if (e.Location.X < this.Location.X + 10 && e.Location.Y < this.Location.Y + 10)
                    this.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
                else
                    this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            base.OnMouseMove(e);
        }

        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        public new void Dispose()
        {
            //if (this.BRUSH_FUNDAL != null)
            //{
            //    this.BRUSH_FUNDAL.Dispose();
            //    this.BRUSH_FUNDAL = null;
            //}

            //if (this.BRUSH_TEXT != null)
            //{
            //    this.BRUSH_TEXT.Dispose();
            //    this.BRUSH_TEXT = null;
            //}

            base.Dispose();
        }

        #endregion

    }
}
