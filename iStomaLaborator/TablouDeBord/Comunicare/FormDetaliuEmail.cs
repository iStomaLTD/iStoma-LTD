using iStomaLab.Generale;
using MailKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.TablouDeBord.Comunicare
{
    public partial class FormDetaliuEmail : FormPersonalizat
    {

        #region Declaratii generale

        private BLLUtile.StructMailKitInbox lMailInbox = null;
        private IMailFolder lFolder=null;
        private UniqueId lId ;
        private BodyPart lBodyPart = null;


        #endregion

        #region Enumerari si Structuri



        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormDetaliuEmail(BLLUtile.StructMailKitInbox pMailInbox, IMailFolder pFolder, UniqueId pId, BodyPart pBodyPart)
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            this.lMailInbox = pMailInbox;
            this.lFolder = pFolder;
            this.lId = pId;
            this.lBodyPart = pBodyPart;

            if (!CCL.UI.IHMUtile.SuntemInDebug())
            {

                adaugaHandlere();
                initTextML();

                this.CentratCuDeplasare();
            }
        }

        private void adaugaHandlere()
        {
            this.Load += _Load;
        }

        private void initTextML()
        {
            this.Text = string.Empty;
        }

        void _Load(object sender, EventArgs e)
        {
            try
            {
                Initializeaza();
                AllowModification(true);
            }
            catch (Exception ex)
            {
                GestiuneErori.AfiseazaMesaj(this.GetFormParinte(), ex);
            }
        }

        public void Initializeaza()
        {
            base.InitializeazaVariabileleGenerale();

            incepeIncarcarea();
            this.ctrlDetaliuEmail.Initializeaza(this.lMailInbox, this.lFolder, this.lId, this.lBodyPart);
            finalizeazaIncarcarea();
        }

        #endregion

        #region Evenimente



        #endregion

        #region Metode private



        #endregion

        #region Metode publice

        public static bool Afiseaza(Form pEcranPariente, BLLUtile.StructMailKitInbox pMailInbox, IMailFolder pFolder, UniqueId pId, BodyPart pBodyPart)
        {
            using (FormDetaliuEmail ecran = new FormDetaliuEmail(pMailInbox, pFolder, pId, pBodyPart))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                return CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);
            }
        }

        #endregion

        #region IControlDava Members

        public void AllowModification(bool pPermiteModificarea)
        {
            this.lEcranInModificare = pPermiteModificarea;
        }

        #endregion


    }
}
