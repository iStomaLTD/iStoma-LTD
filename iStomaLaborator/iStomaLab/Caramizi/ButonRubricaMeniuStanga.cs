﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BLL.iStomaLab.Utilizatori.BUtilizatorDrepturi;

namespace iStomaLab.Caramizi
{
    [DefaultEvent("CerereUpdate")]
    internal class ButonRubricaMeniuStanga : Button
    {

        private bool lEsteDisponibil = true;
        public bool Deschis { get; private set; }
        public EnumRubrica Rubrica { get; set; }

        public System.EventHandler CerereUpdate;

        private PanelOptiuniMeniuStanga lPanelOptiuni = null;

        public ButonRubricaMeniuStanga() : base()
        {
            initProprietatiStandard();
        }

        private void initProprietatiStandard()
        {
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Size = new System.Drawing.Size(144, 23);
            this.UseVisualStyleBackColor = true;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }
        
        internal void Initializeaza(string pText, EnumRubrica pRubrica, bool pDeschis, PanelOptiuniMeniuStanga pPanelOptiuni)
        {
            this.Deschis = pDeschis;
            this.Rubrica = pRubrica;

            this.lPanelOptiuni = pPanelOptiuni;

            if (!string.IsNullOrEmpty(pText))
                this.Text = pText;

            initImagine();
        }

        internal void Initializeaza(string pText, bool pDeschis, PanelOptiuniMeniuStanga pPanelOptiuni)
        {
            this.Deschis = pDeschis;

            this.lPanelOptiuni = pPanelOptiuni;

            if (!string.IsNullOrEmpty(pText))
                this.Text = pText;

            initImagineRubrica();
        }

        internal void SchimbaDeschiderea(bool pDeschis)
        {
            this.Deschis = pDeschis;
            initImagine();
        }

        protected override void OnClick(EventArgs e)
        {
            this.Deschis = !this.Deschis;
            initImagine();

            base.OnClick(e);
        }

        private void initImagine()
        {
            if (this.Deschis)
                this.Image = IHMUtile.GetImagineSageataJos();
            else
                this.Image = IHMUtile.GetImagineSageataDreapta();

            if (this.lPanelOptiuni != null)
            {
                this.lPanelOptiuni.Visible = this.Deschis;
            }
        }

        private void initImagineRubrica()
        {
            if (this.Deschis)
                this.Image = IHMUtile.GetImagineSageataJos();
            else
                this.Image = IHMUtile.GetImagineSageataDreapta();
           
        }

        internal void SetDisponibilitate(bool pVizibil)
        {
            this.lEsteDisponibil = pVizibil;
            this.Visible = pVizibil;
        }
        internal bool EsteDisponibil()
        {
            return this.lEsteDisponibil;
        }
    }
}
