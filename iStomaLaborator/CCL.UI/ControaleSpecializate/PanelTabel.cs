using ILL.iStomaLab;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using CCL.iStomaLab;

namespace CCL.UI.ControaleSpecializate
{
    public class PanelTabel : PanelPersonalizat
    {
        protected List<float> lListaInaltimiColoane = new List<float>();
        protected int lNumarColoane = 2;

        [DefaultValue(false)]
        public bool SensInversDimensiuneLinii { get; set; }

        public PanelTabel()
        {

        }

        public PanelTabel(IContainer container)
            : this()
        {
            container.Add(this);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            Rectangle chenar = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            //Desenam chenarul
            g.DrawRectangle(Pens.DarkGray, chenar);

            //Desenam coloanele
            float latimeColoana = Convert.ToSingle(this.Width - 1) / this.lNumarColoane;
            float xColoana = 0;
            for (int i = 0; i < this.lNumarColoane - 1; i++)
            {
                xColoana = (i + 1) * latimeColoana;
                g.DrawLine(Pens.DarkGray, xColoana, 0, xColoana, this.Height);
            }

            //Desenam liniile
            if (!CUtil.EsteListaVida<float>(this.lListaInaltimiColoane))
            {
                float yActual = 0;
                if (this.SensInversDimensiuneLinii)
                {
                    yActual = this.Height;
                    for (int i = 0; i < this.lListaInaltimiColoane.Count - 1; i++)
                    {
                        yActual -= this.lListaInaltimiColoane[i] * CDefinitiiComune._FactorMultiplicareDPI_Y;
                        g.DrawLine(Pens.DarkGray, 0, yActual, this.Width, yActual);
                    }
                }
                else
                {
                    for (int i = 0; i < this.lListaInaltimiColoane.Count - 1; i++)
                    {
                        yActual += this.lListaInaltimiColoane[i] * CDefinitiiComune._FactorMultiplicareDPI_Y;
                        g.DrawLine(Pens.DarkGray, 0, yActual, this.Width, yActual);
                    }
                }
            }
        }
    }
}
