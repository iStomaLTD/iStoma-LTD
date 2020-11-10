using BLL.iStomaLab;
using BLL.iStomaLab.Clienti;
using BLL.iStomaLab.Referinta;
using CCL.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.Generale
{
    public partial class FormCuPacienti : FormPersonalizat
    {

        #region Declaratii generale

        public BClienti lClient = null;
        public BClientiPacienti pPacient = null;
        private Setari.Liste.Pacienti.ControlListaPacienti lctrlListaPacienti = null;
        private int IdClient = 0;       
        private StructIdDenumire lPersoanaSauOrganizatie = StructIdDenumire.Empty;
        #endregion

        #region Enumerari si Structuri

        enum EnumTipLista
        {
            Tara = 0,
            Regiune = 1,
            Localitate = 2
        }

        #endregion

        #region Proprietati



        #endregion

        #region Constructor si Initializare

        private FormCuPacienti(BClienti pClient, BClientiPacienti pPacient)
        {
            this.lClient = pClient;
            this.DoubleBuffered = true;
            InitializeComponent();
            
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

            this.Text = "Lista Pacienti";            
            base.InitializeazaVariabileleGenerale();
            incepeIncarcarea();
          
            initControlListaPacienti();

            finalizeazaIncarcarea();          
        }

        public void InchideEcranul()
        {
            this.inchideEcranul();
        }

        #endregion

        #region Evenimente
        private void initControlListaPacienti()
        {
            if (this.lctrlListaPacienti == null)
            {
                this.lctrlListaPacienti = new Setari.Liste.Pacienti.ControlListaPacienti(this.lClient);  //revino aici LORE
                this.lctrlListaPacienti.Name = "ctrlListaPacienti";
                this.lctrlListaPacienti.Initializeaza();
                this.lctrlListaPacienti.Visible = true;
                this.lctrlListaPacienti.BringToFront();
            }
            else
            {
                MessageBox.Show("AICI");
            }
           
       
            finalizeazaIncarcarea();

        }

        private void Txt_TextChanged(object sender, EventArgs e)
        {

            if (this.lSeIncarca) return;
            try
            {
                incepeIncarcarea();

                EnumTipLista tipLista = (EnumTipLista)(sender as TextBoxPersonalizat).Tag;
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

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Enter)
            {
              
            }
            else if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                
            }
            return base.ProcessDialogKey(keyData);
        }

        #endregion

        #region Metode private

        #endregion

        #region Metode publice
     
        public static BClientiPacienti Afiseaza(Form pEcranPariente, BClienti pclienti, BClientiPacienti pPacient)
        {
            using (FormCuPacienti ecran = new FormCuPacienti(pclienti, pPacient))
            {
                ecran.AplicaPreferinteleUtilizatorului();
                CCL.UI.IHMUtile.DeschideEcran(pEcranPariente, ecran);               

                return ecran.pPacient;
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
