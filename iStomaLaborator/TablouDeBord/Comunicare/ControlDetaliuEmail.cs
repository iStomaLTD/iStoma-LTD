using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iStomaLab.Generale;
using BLL.iStomaLab;
using iStomaLab.TablouDeBord.Email;
using MailKit;

namespace iStomaLab.TablouDeBord.Comunicare
{
    public partial class ControlDetaliuEmail : UserControlPersonalizat
    {

        #region Declaratii generale

        private BLLUtile.StructMailKitInbox lMailInbox = null;

        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlDetaliuEmail()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();
            }
        }

        private void adaugaHandlere()
        {
            this.btnEmailReply.Click += BtnEmailReply_Click;
        }
        
        private void initTextML()
        {
            this.lblDetaliiEmailDeLa.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.DeLa);
            this.lblDetaliiEmailSubiect.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Subiect);
            this.lblDetaliiEmailPentru.Text = BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Pentru);
        }

        public void Initializeaza(BLLUtile.StructMailKitInbox pMailInbox, IMailFolder pFolder, UniqueId pId, BodyPart pBodyPart)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();
            this.lMailInbox = pMailInbox;

            this.txtDetaliiEcranFrom.Text = lMailInbox.From.ToString();
            this.txtDetaliiEcranSubject.Text = lMailInbox.Subiect;
            this.txtDetaliiEcranTo.Text = lMailInbox.To;
            this.lblDetaliiEmailDataOra.Text = lMailInbox.Data;

            ControlInbox.Render(pFolder, pId, pBodyPart, this.wbDetaliiEmail);

            		
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente

        private void BtnEmailReply_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                FormScrieEmail.Afiseaza(this.GetFormParinte(), this.lMailInbox);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
            finally
            {
                finalizeazaIncarcarea();
            }

        }

        #endregion

        #region Metode private



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
