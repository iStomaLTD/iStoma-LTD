using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.Caramizi
{
    [DefaultEvent("CerereUpdate")]
    internal class ButonOptiuneMeniuStanga : Button
    {
        public bool Selectat { get; private set; }
        public EnumOptiune Optiune { get; set; }
        public EnumRubricaEmail OptiuneAdresaEmail { get; set; }
        public System.EventHandler CerereUpdate;

        public ButonOptiuneMeniuStanga() : base()
        {
            initProprietatiStandard();
        }

        private void initProprietatiStandard()
        {
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Size = new System.Drawing.Size(130, 23);
            this.UseVisualStyleBackColor = true;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        internal void Initializeaza(string pText, EnumOptiune pOptiune, bool pSelectat)
        {
            this.Optiune = pOptiune;
            this.Selectat = pSelectat;

            if (!string.IsNullOrEmpty(pText))
                this.Text = pText;

            initImagine();
        }

        internal void Initializeaza(string pText, EnumRubricaEmail pOptiune, bool pSelectat)
        {
            this.OptiuneAdresaEmail = pOptiune;
            this.Selectat = pSelectat;

            if (!string.IsNullOrEmpty(pText))
                this.Text = pText;

            initImagine();
        }
        
        protected override void OnClick(EventArgs e)
        {
            this.Selectat = !this.Selectat;
            initImagine();

            if (this.CerereUpdate != null)
                CerereUpdate(this, null);
            else
                base.OnClick(e);
        }


        internal void SchimbaSelectia(bool pSelectat)
        {
            this.Selectat = pSelectat;
            initImagine();
        }

        private void initImagine()
        {
           
            if (this.Selectat)
                this.BackColor = System.Drawing.Color.LightGray;
            else
                this.BackColor = System.Drawing.Color.White;

        }
    }
}
