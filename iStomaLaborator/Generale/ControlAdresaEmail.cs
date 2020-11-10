using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.iStomaLab.Email;
using BLL.iStomaLab;
using iStomaLab.Caramizi;

namespace iStomaLab.Generale
{
    public partial class ControlAdresaEmail : UserControlPersonalizat
    {

        #region Declaratii generale
        
        public static BEmail _SEmail = null;
        private EnumRubricaEmail lRubricaSelectata = EnumRubricaEmail.Inbox;

        #endregion

        #region Enumerari si Structuri


        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        public ControlAdresaEmail()
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
            this.btnOptiuneInbox.Click += BtnOptiuneEmail_Click;
            this.btnAdresaEmail.Click += BtnAdresaEmail_Click;
        }
        
        private void initTextML()
        {

        }

        public void Initializeaza(BEmail pEmail)
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();
            _SEmail = pEmail;

            this.btnAdresaEmail.Initializeaza(_SEmail.AdresaMail, EnumRubricaEmail.Inbox, EnumRubricaEmail.Inbox == this.lRubricaSelectata, this.panelOptiuniEmail);

            this.btnOptiuneInbox.Initializeaza(BMultiLingv.getElementById(BMultiLingv.EnumDictionar.Inbox), EnumRubricaEmail.Inbox, EnumRubricaEmail.Inbox == this.lRubricaSelectata);
            this.btnOptiuneDrafts.Initializeaza("Drafts", EnumRubricaEmail.Drafts, EnumRubricaEmail.Drafts == this.lRubricaSelectata);
            this.btnOptiuneSent.Initializeaza("Sent", EnumRubricaEmail.Sent, EnumRubricaEmail.Sent == this.lRubricaSelectata);
            this.btnOptiuneTrash.Initializeaza("Trash", EnumRubricaEmail.Trash, EnumRubricaEmail.Trash == this.lRubricaSelectata);

            finalizeazaIncarcarea();
        }
        
        #endregion

        #region Evenimente

        private void BtnAdresaEmail_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();
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

        private void BtnOptiuneEmail_Click(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                schimbaOptiuneaActiva(sender as ButonOptiuneMeniuStanga);
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

        private void schimbaOptiuneaActiva(ButonOptiuneMeniuStanga pSender)
        {
            EnumRubricaEmail optiune = pSender.OptiuneAdresaEmail;

            //foreach (Control panelRubrica in this.flp.Controls)
            //{
            //    if (panelRubrica is PanelOptiuniMeniuStanga)
            //    {
            //        foreach (var butonOptiuni in panelRubrica.Controls)
            //        {
            //            if (butonOptiuni is ButonOptiuneMeniuStanga)
            //            {
            //                (butonOptiuni as ButonOptiuneMeniuStanga).SchimbaSelectia(butonOptiuni == pSender);
            //            }
            //        }
            //    }
            //}

            incarcaOptiuneaSelectata(optiune);
        }

        private void incarcaOptiuneaSelectata(EnumRubricaEmail pOptiune)
        {
            this.lRubricaSelectata = pOptiune;

            switch (pOptiune)
            {
                case EnumRubricaEmail.Inbox:
                    initInbox();
                    break;
            }

        }

        private void initInbox()
        {

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
