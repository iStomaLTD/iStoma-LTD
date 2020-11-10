using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCL.UI;
using BLL.iStomaLab.Utilizatori;

namespace iStomaLab.Generale
{
    [DefaultEvent("ParolaCorecta")]
    public partial class ControlPauza : UserControlPersonalizat
    {

        #region Declaratii generale

        public event System.EventHandler ParolaCorecta;
        private String lParolaIntrodusa = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlPauza()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {
                adaugaHandlere();
                initTextML();
            }

            this.txtParolaPauza.Focus();
        }

        private void adaugaHandlere()
        {
            this.btnPauza.Click += BtnPauza_Click;
            this.txtParolaPauza.TextChanged += TxtParolaPauza_TextChanged;
        }
        
        private void initTextML()
        {
            
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();
            
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void TxtParolaPauza_TextChanged(object sender, EventArgs e)
        {
            if (verificaParolaIntrodusa())
            {
                anuntaParolaCorecta();
            }
        }

        private void BtnPauza_Click(object sender, EventArgs e)
        {
            lParolaIntrodusa = txtParolaPauza.Text;

            if (string.IsNullOrEmpty(lParolaIntrodusa))
            {

            }
            else
            {
                if (verificaParolaIntrodusa())
                {
                    anuntaParolaCorecta();
                }
            }
        }

        #endregion

        #region Metode private

        private bool verificaParolaIntrodusa()
        {
            BUtilizator user = BUtilizator.GetUtilizatorConectat();
            //   _UtilizatorConectat = getByUserSiPass(pUser, CCL.iStomaLab.Utile.CSecuritate.GetMd5Hash(pParola), pTranzactie);
           
            //aici e problema pauza
            if (BUtilizator.Conectare(user.ContStoma, this.txtParolaPauza.Text, BStatiiDeLucruUtilizatori.GetPreferinteUtilizatorConectat(user.Id, null).PastreazaConectat, null) != null)
            
             return true;
            return false;
        }

        private void anuntaParolaCorecta()
        {
            if (this.ParolaCorecta != null)
                ParolaCorecta(this, null);
        }
        
        #endregion

        #region Metode publice



        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }


        #endregion

       
    }
}
