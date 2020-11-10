using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CCL.UI
{
    public class SplitContainerPersonalizat : SplitContainer
    {
        public SplitContainerPersonalizat()
        {
            SeteazaDoubleBuffer();
        }

        public SplitContainerPersonalizat(IContainer container)
            : this()
        {
            container.Add(this);
        }

        private void SeteazaDoubleBuffer()
        {
            // this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            this.Font = CDL.iStomaLab.CDefinitiiComune._Font_DPI;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    this.BorderStyle = System.Windows.Forms.BorderStyle.None;
        //    this.Panel1.BackColor = Color.Transparent;
        //    this.Panel2.BackColor = Color.Transparent;
        //    Graphics g = e.Graphics;

        //    g.DrawRectangle(IHMUtile.PENSULA_CHENAR, new Rectangle(0, 0, this.Width, this.Height));
        //    //g.DrawRectangle(IHMUtile.PENSULA_CHENAR, this.Panel1.DisplayRectangle);
        //    //g.DrawRectangle(IHMUtile.PENSULA_CHENAR, this.Panel2.DisplayRectangle);

        //    int latimeSplitter = 1;
        //    if (!this.IsSplitterFixed)
        //        latimeSplitter = 3;

        //    if (!this.Panel1Collapsed && !this.Panel2Collapsed)
        //        if (this.Orientation == System.Windows.Forms.Orientation.Vertical)
        //            g.DrawRectangle(IHMUtile.PENSULA_CHENAR, new Rectangle(this.SplitterDistance, 0, latimeSplitter, this.Height));
        //        else
        //            g.DrawRectangle(IHMUtile.PENSULA_CHENAR, new Rectangle(0, this.SplitterDistance, this.Width, latimeSplitter));

        //    base.OnPaint(e);
        //}

        public void AplicaFactorDPI()
        {
            if (this.Orientation == System.Windows.Forms.Orientation.Vertical)
                this.SplitterDistance = Convert.ToInt32(this.SplitterDistance * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_X);
            else
                this.SplitterDistance = Convert.ToInt32(this.SplitterDistance * CDL.iStomaLab.CDefinitiiComune._FactorMultiplicareDPI_Y);
        }
    }
}
