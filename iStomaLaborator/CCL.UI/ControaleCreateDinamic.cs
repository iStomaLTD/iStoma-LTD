using System;
using System.Drawing;
using System.Windows.Forms;
using CCL.UI.FormulareComune;

namespace CCL.UI
{
    public class ControaleCreateDinamic
    {
        private static ContextMenuStrip lMeniuContextualDinamic = null;
        private static IMembriComuniControalePersonalizate lControlTinta = null;

        internal static void AfiseazaToolTip(Control pControl, ToolTipIcon pIconita, string pTitlu, string pMesaj)
        {
            frmToolTip.Instanta.Afiseaza(pIconita, pTitlu, pMesaj);
        }

        internal static void AscundeToolTip(Control pControl)
        {
            frmToolTip.Instanta.Ascunde();
        }

        /// <summary>
        /// La deschiderea meniului contextual asociat unui control putem determina controlul tinta
        /// La folosirea unui shortcut nu avem nicio informatie referitoare la controlul tinta
        /// Cu ajutorul acestei metode la OnFocus pe un control il consideram o tinta potentiala
        /// Aceasta metoda trebuie apelata in metoda OnFocus pentru zonele editabile sau OnClick pentrul Label
        /// </summary>
        /// <param name="pControlTinta"></param>
        public static void SetControlTinta(IMembriComuniControalePersonalizate pControlTinta)
        {
            lControlTinta = pControlTinta;
        }

        public static ContextMenuStrip GetMeniuContextualZonaText()
        {
            if (lMeniuContextualDinamic == null)
            {
                lMeniuContextualDinamic = new ContextMenuStrip();
                ToolStripMenuItem tsDiacritice = new ToolStripMenuItem();
                ToolStripMenuItem tsCautaIn = new ToolStripMenuItem();
                ToolStripMenuItem tsAMareCaciula = new ToolStripMenuItem();
                ToolStripMenuItem tsAMicCacicula = new ToolStripMenuItem();
                ToolStripMenuItem tsAMareCircumflex = new ToolStripMenuItem();
                ToolStripMenuItem tsAMicCircumflex = new ToolStripMenuItem();
                ToolStripMenuItem tsIMareCircumflex = new ToolStripMenuItem();
                ToolStripMenuItem tsIMicCircumflex = new ToolStripMenuItem();
                ToolStripMenuItem tsSMareSedila = new ToolStripMenuItem();
                ToolStripMenuItem tsSMicSedila = new ToolStripMenuItem();
                ToolStripMenuItem tsTMareSedila = new ToolStripMenuItem();
                ToolStripMenuItem tsTMicSedila = new ToolStripMenuItem();
                ToolStripSeparator toolStripSeparator1 = new ToolStripSeparator();
                ToolStripSeparator toolStripSeparator2 = new ToolStripSeparator();
                ToolStripSeparator toolStripSeparator3 = new ToolStripSeparator();
                ToolStripSeparator toolStripSeparator4 = new ToolStripSeparator();
                ToolStripSeparator toolStripSeparator5 = new ToolStripSeparator();
                ToolStripSeparator toolStripSeparator6 = new ToolStripSeparator();
                ToolStripSeparator toolStripSeparator7 = new ToolStripSeparator();
                ToolStripMenuItem tsAnulati = new ToolStripMenuItem();
                ToolStripMenuItem tsGoogle = new ToolStripMenuItem();
                ToolStripMenuItem tsFacebook = new ToolStripMenuItem();
                ToolStripMenuItem tsWikipedia = new ToolStripMenuItem();
                ToolStripMenuItem tsDecupati = new ToolStripMenuItem();
                ToolStripMenuItem tsCopiati = new ToolStripMenuItem();
                ToolStripMenuItem tsInserati = new ToolStripMenuItem();
                ToolStripMenuItem tsMesaj = new ToolStripMenuItem(); //Pentru a putea insera un mesaj standard
                ToolStripMenuItem tsRefresh = new ToolStripMenuItem(); //Pentru a putea face refresh din meniul contextual al DGV-urilor
                ToolStripMenuItem tsVizibilitateColoane = new ToolStripMenuItem(); //Pentru a putea ascunde coloanele din meniul contextual al DGV-urilor
                ToolStripMenuItem tsRevenireLaAfisajulStandard = new ToolStripMenuItem(); //Pentru a putea reveni la afisajul initial al DGV-urilor
                ToolStripMenuItem tsSelectatiTot = new ToolStripMenuItem();
                ToolStripMenuItem tsDEX = new ToolStripMenuItem();
                ToolStripMenuItem tsCalculator = new ToolStripMenuItem();
                ToolStripMenuItem tsCautare = new ToolStripMenuItem();
                ToolStripSeparator tsSepPrintExport = new ToolStripSeparator();
                ToolStripMenuItem tsPrint = new ToolStripMenuItem();
                ToolStripMenuItem tsExport = new ToolStripMenuItem();
                ToolStripMenuItem tsEmail = new ToolStripMenuItem();
                ToolStripMenuItem tsFullScreen = new ToolStripMenuItem();

                // 
                // cmsMeniuContextual
                // 
                lMeniuContextualDinamic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                                                                                    tsDiacritice,                      //0
                                                                                                    toolStripSeparator7,               //1
                                                                                                    tsCautaIn,                         //2
                                                                                                    toolStripSeparator5,               //3
                                                                                                    tsAnulati,                         //4
                                                                                                    tsDecupati,                        //5
                                                                                                    tsCopiati,                         //6
                                                                                                    tsInserati,                        //7
                                                                                                    tsMesaj,                           //8
                                                                                                    toolStripSeparator6,               //9
                                                                                                    tsSelectatiTot,                    //10
                                                                                                    tsCalculator,                      //11
                                                                                                    tsCautare,                         //12
                                                                                                    tsSepPrintExport,                  //13
                                                                                                    tsPrint,                           //14
                                                                                                    tsExport,                          //15
                                                                                                    tsEmail,                           //16
                                                                                                    tsFullScreen,                      //17
                                                                                                    tsRefresh,                         //18
                                                                                                    tsVizibilitateColoane,             //19
                                                                                                    tsRevenireLaAfisajulStandard});    //20
                lMeniuContextualDinamic.Name = "contextMenuStrip1";
                lMeniuContextualDinamic.Size = new System.Drawing.Size(222, 214);
                lMeniuContextualDinamic.Opening += new System.ComponentModel.CancelEventHandler(cmsMeniuContextual_Opening);

                // toolStripSeparator5
                toolStripSeparator5.Name = "toolStripSeparator5";
                toolStripSeparator5.Size = new System.Drawing.Size(218, 6);

                // tsCautare
                tsCautare.Name = "tsCautare";
                tsCautare.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
                tsCautare.Size = new System.Drawing.Size(221, 22);
                tsCautare.Text =  "Căutare";
                tsCautare.Click += new System.EventHandler(tsCautare_Click);

                // tsCalculator
                tsCalculator.Name = "tsCalculator";
                tsCalculator.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
                tsCalculator.Size = new System.Drawing.Size(221, 22);
                tsCalculator.Text = "Calculați";
                tsCalculator.Click += new System.EventHandler(tsCalculator_Click);

                // tsAnulati
                tsAnulati.Name = "tsAnulati";
                tsAnulati.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
                tsAnulati.Size = new System.Drawing.Size(221, 22);
                tsAnulati.Text = "Anulați/Refaceți";
                tsAnulati.Click += new System.EventHandler(tsAnulati_Click);

                // tsDecupati
                tsDecupati.Name = "tsDecupati";
                tsDecupati.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
                tsDecupati.Size = new System.Drawing.Size(221, 22);
                tsDecupati.Text = "Decupați";
                tsDecupati.Click += new System.EventHandler(tsDecupati_Click);

                // tsCopiati
                tsCopiati.Name = "tsCopiati";
                tsCopiati.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
                tsCopiati.Size = new System.Drawing.Size(221, 22);
                tsCopiati.Text = "Copiere";
                tsCopiati.Click += new System.EventHandler(tsCopiati_Click);

                // tsInserati
                tsInserati.Name = "tsInserati";
                tsInserati.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
                tsInserati.Size = new System.Drawing.Size(221, 22);
                tsInserati.Text = "Lipire";
                tsInserati.Click += new System.EventHandler(tsInserati_Click);

                // tsInserati
                tsMesaj.Name = "tsMesaj";
                tsMesaj.Size = new System.Drawing.Size(221, 22);
                tsMesaj.Text = "Mesaj"; //(mai ok text); [si mai ok template]
                tsMesaj.Click += new System.EventHandler(tsMesaj_Click);

                // tsRefresh
                tsRefresh.Name = "tsRefresh";
                tsRefresh.ShortcutKeys = Keys.F5;
                tsRefresh.Size = new System.Drawing.Size(221, 22);
                tsRefresh.Text = "Refresh";
                tsRefresh.Image = CCL.UI.Properties.Resources.refresh;
                tsRefresh.Click += new System.EventHandler(tsRefresh_Click);

                // tsVizibilitateColoane
                tsVizibilitateColoane.Name = "tsVizibilitateColoane";
                tsVizibilitateColoane.ShortcutKeys = Keys.F1;
                tsVizibilitateColoane.Size = new System.Drawing.Size(221, 22);
                tsVizibilitateColoane.Text = "Vizibilitate coloane";
                tsVizibilitateColoane.Image = CCL.UI.Properties.Resources.edit16x16;
                tsVizibilitateColoane.Click += new System.EventHandler(tsVizibilitateColoane_Click);

                // tsRevenireLaAfisajulStandard
                tsRevenireLaAfisajulStandard.Name = "tsRevenireLaAfisajulStandard";
                tsRevenireLaAfisajulStandard.Size = new System.Drawing.Size(221, 22);
                tsRevenireLaAfisajulStandard.Text = "Revenire la afisajul initial";
                tsRevenireLaAfisajulStandard.Image = CCL.UI.Properties.Resources.undo_26;
                tsRevenireLaAfisajulStandard.Click += new System.EventHandler(tsRevenireLaAfisajulStandard_Click);

                // toolStripSeparator6
                toolStripSeparator6.Name = "toolStripSeparator6";
                toolStripSeparator6.Size = new System.Drawing.Size(218, 6);

                // tsSelectatiTot
                tsSelectatiTot.Name = "tsSelectatiTot";
                tsSelectatiTot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
                tsSelectatiTot.Size = new System.Drawing.Size(221, 22);
                tsSelectatiTot.Text ="Selectați tot";
                tsSelectatiTot.Click += new System.EventHandler(tsSelectatiTot_Click);

                // tsDiacritice
                tsDiacritice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            tsAMicCacicula,
            tsAMareCaciula,
            toolStripSeparator1,
            tsAMicCircumflex,
            tsAMareCircumflex,
            toolStripSeparator2,
            tsIMicCircumflex,
            tsIMareCircumflex,
            toolStripSeparator3,
            tsSMicSedila,
            tsSMareSedila,
            toolStripSeparator4,
            tsTMicSedila,
            tsTMareSedila});
                tsDiacritice.Image = global::CCL.UI.Properties.Resources.RomaniaIcon;
                tsDiacritice.Name = "tsDiacritice";
                tsDiacritice.Size = new System.Drawing.Size(221, 22);
                tsDiacritice.Text = "Diacritice";

                // tsAMicCacicula
                tsAMicCacicula.Name = "tsAMicCacicula";
                tsAMicCacicula.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
                tsAMicCacicula.Size = new System.Drawing.Size(179, 22);
                tsAMicCacicula.Text = "ă";
                tsAMicCacicula.Click += new System.EventHandler(LiteraRomaneasca_Click);

                // tsAMareCaciula
                tsAMareCaciula.Name = "tsAMareCaciula";
                tsAMareCaciula.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift)
                            | System.Windows.Forms.Keys.A)));
                tsAMareCaciula.Size = new System.Drawing.Size(179, 22);
                tsAMareCaciula.Text = "Ă";
                tsAMareCaciula.Click += new System.EventHandler(LiteraRomaneasca_Click);

                // toolStripSeparator1
                toolStripSeparator1.Name = "toolStripSeparator1";
                toolStripSeparator1.Size = new System.Drawing.Size(176, 6);

                // tsAMicCircumflex
                tsAMicCircumflex.Name = "tsAMicCircumflex";
                tsAMicCircumflex.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.A)));
                tsAMicCircumflex.Size = new System.Drawing.Size(179, 22);
                tsAMicCircumflex.Text = "â";
                tsAMicCircumflex.Click += new System.EventHandler(LiteraRomaneasca_Click);

                // tsAMareCircumflex
                tsAMareCircumflex.Name = "tsAMareCircumflex";
                tsAMareCircumflex.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.Shift)
                            | System.Windows.Forms.Keys.A)));
                tsAMareCircumflex.Size = new System.Drawing.Size(179, 22);
                tsAMareCircumflex.Text = "Â";
                tsAMareCircumflex.Click += new System.EventHandler(LiteraRomaneasca_Click);

                // toolStripSeparator2
                toolStripSeparator2.Name = "toolStripSeparator2";
                toolStripSeparator2.Size = new System.Drawing.Size(176, 6);

                // tsIMicCircumflex
                tsIMicCircumflex.Name = "tsIMicCircumflex";
                tsIMicCircumflex.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
                tsIMicCircumflex.Size = new System.Drawing.Size(179, 22);
                tsIMicCircumflex.Text = "î";
                tsIMicCircumflex.Click += new System.EventHandler(LiteraRomaneasca_Click);

                // tsIMareCircumflex
                tsIMareCircumflex.Name = "tsIMareCircumflex";
                tsIMareCircumflex.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift)
                            | System.Windows.Forms.Keys.I)));
                tsIMareCircumflex.Size = new System.Drawing.Size(179, 22);
                tsIMareCircumflex.Text = "Î";
                tsIMareCircumflex.Click += new System.EventHandler(LiteraRomaneasca_Click);

                // toolStripSeparator3
                toolStripSeparator3.Name = "toolStripSeparator3";
                toolStripSeparator3.Size = new System.Drawing.Size(176, 6);

                // tsSMicSedila
                tsSMicSedila.Name = "tsSMicSedila";
                tsSMicSedila.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
                tsSMicSedila.Size = new System.Drawing.Size(179, 22);
                tsSMicSedila.Text = "ș";
                tsSMicSedila.Click += new System.EventHandler(LiteraRomaneasca_Click);

                // tsSMareSedila
                tsSMareSedila.Name = "tsSMareSedila";
                tsSMareSedila.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift)
                            | System.Windows.Forms.Keys.S)));
                tsSMareSedila.Size = new System.Drawing.Size(179, 22);
                tsSMareSedila.Text = "Ș";
                tsSMareSedila.Click += new System.EventHandler(LiteraRomaneasca_Click);

                // toolStripSeparator4
                toolStripSeparator4.Name = "toolStripSeparator4";
                toolStripSeparator4.Size = new System.Drawing.Size(176, 6);

                // tsTMicSedila
                tsTMicSedila.Name = "tsTMicSedila";
                tsTMicSedila.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
                tsTMicSedila.Size = new System.Drawing.Size(179, 22);
                tsTMicSedila.Text = "ț";
                tsTMicSedila.Click += new System.EventHandler(LiteraRomaneasca_Click);

                // tsTMareSedila
                tsTMareSedila.Name = "tsTMareSedila";
                tsTMareSedila.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift)
                            | System.Windows.Forms.Keys.T)));
                tsTMareSedila.Size = new System.Drawing.Size(179, 22);
                tsTMareSedila.Text = "Ț";
                tsTMareSedila.Click += new System.EventHandler(LiteraRomaneasca_Click);


                // tsDiacritice
                tsCautaIn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            tsGoogle,
            tsWikipedia,
            tsFacebook,
                tsDEX});
                tsCautaIn.Image = global::CCL.UI.Properties.Resources.find;
                tsCautaIn.Name = "tsCauta";
                tsCautaIn.Size = new System.Drawing.Size(221, 22);
                tsCautaIn.Text = "Cauta in";

                // tsDEX
                tsDEX.Image = global::CCL.UI.Properties.Resources.RomaniaMare16;
                tsDEX.Name = "tsDEX";
                tsDEX.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
                tsDEX.Size = new System.Drawing.Size(221, 22);
                tsDEX.Text = "DEX";
                tsDEX.Click += new System.EventHandler(tsDEX_Click);

                // tsGoogle
                tsGoogle.Image = global::CCL.UI.Properties.Resources.google16;
                tsGoogle.Name = "tsGoogle";
                tsGoogle.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
                tsGoogle.Size = new System.Drawing.Size(221, 22);
                tsGoogle.Text = "Google";
                tsGoogle.Click += new System.EventHandler(tsGoogle_Click);

                // tsFacebook
                tsFacebook.Image = global::CCL.UI.Properties.Resources.FacebookLogo;
                tsFacebook.Name = "tsFacebook";
                tsFacebook.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | Keys.Alt | System.Windows.Forms.Keys.F)));
                tsFacebook.Size = new System.Drawing.Size(221, 22);
                tsFacebook.Text = "Facebook";
                tsFacebook.Click += new System.EventHandler(tsFacebook_Click);

                // tsWikipedia
                tsWikipedia.Image = global::CCL.UI.Properties.Resources.WikipediaLogo;
                tsWikipedia.Name = "tsWikipedia";
                tsWikipedia.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
                tsWikipedia.Size = new System.Drawing.Size(221, 22);
                tsWikipedia.Text = "Wikipedia";
                tsWikipedia.Click += new System.EventHandler(tsWikipedia_Click);

                // toolStripSeparator4
                tsSepPrintExport.Name = "tsSepPrintExport";
                tsSepPrintExport.Size = new System.Drawing.Size(176, 6);

                // tsPrint
                tsPrint.Image = global::CCL.UI.Properties.Resources.printer;
                tsPrint.Name = "tsPrint";
                tsPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
                tsPrint.Size = new System.Drawing.Size(221, 22);
                tsPrint.Text = "Imprimare";
                tsPrint.Tag = CCL.UI.EnumTipActiuneControl.Printare;
                tsPrint.Click += new System.EventHandler(ActiuneMeniu_Click);

                // tsExport
                tsExport.Image = CCL.UI.Imagini.getImagineExportCSV();
                tsExport.Name = "tsExport";
                tsExport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
                tsExport.Size = new System.Drawing.Size(221, 22);
                tsExport.Text = "Exportare";
                tsExport.Tag = CCL.UI.EnumTipActiuneControl.Export;
                tsExport.Click += new System.EventHandler(ActiuneMeniu_Click);

                // tsEmail
                tsEmail.Image = global::CCL.UI.Properties.Resources.email;
                tsEmail.Name = "tsEmail";
                tsEmail.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Space)));
                tsEmail.Size = new System.Drawing.Size(221, 22);
                tsEmail.Text = "Trimite pe mail";
                tsEmail.Tag = CCL.UI.EnumTipActiuneControl.TrimitePeMail;
                tsEmail.Click += new System.EventHandler(ActiuneMeniu_Click);

                //tsFullScreen
                initButonMeniuContextual(tsFullScreen,
                                         "tsFullScreen",
                                         "Maximizează",
                                         EnumTipActiuneControl.FullScreen,
                                         global::CCL.UI.Properties.Resources.zoomIn);
                tsFullScreen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            }
            return lMeniuContextualDinamic;
        }

        private static void initButonMeniuContextual(ToolStripMenuItem pButonMeniu,
                                                     string pNume, string pText,
                                                     CCL.UI.EnumTipActiuneControl pTipActiune,
                                                     Image pImagine)
        {
            pButonMeniu.Image = pImagine;
            pButonMeniu.Name = pNume;
            pButonMeniu.Size = new System.Drawing.Size(221, 22);
            pButonMeniu.Text = pText;
            pButonMeniu.Tag = pTipActiune;
            pButonMeniu.Click += new System.EventHandler(ActiuneMeniu_Click);
        }

        public static void ActiuneMeniu_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem optiune = sender as ToolStripItem;
                if (optiune != null && optiune.Tag != null)
                {
                    lControlTinta.ExecutaActiunea((EnumTipActiuneControl)optiune.Tag);
                }
                optiune = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void LiteraRomaneasca_Click(object sender, EventArgs e)
        {
            IMembriComuniControalePersonalizate ctrlAtasat = lControlTinta;// (IMembriComuniControalePersonalizate)((ToolStripMenuItem)sender).Tag;
            if (ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.Diacritice) && ctrlAtasat.IsInModificationMode)
            {
                ctrlAtasat.InsereazaText(sender.ToString());
                //int Pozitie = ctrlAtasat.SelectionStart;
                //ctrlAtasat.Text = ctrlAtasat.Text.Insert(Pozitie, sender.ToString());
                //ctrlAtasat.SelectionStart = Pozitie + 1;
            }
        }

        /// <summary>
        /// Deschidem meniul contextual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void cmsMeniuContextual_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                ContextMenuStrip Meniu = (ContextMenuStrip)sender;
                Control Sursa = Meniu.SourceControl;
                while (Sursa != null)
                {
                    if (Sursa is IMembriComuniControalePersonalizate)
                    {
                        lControlTinta = (IMembriComuniControalePersonalizate)Sursa;
                        break;
                    }
                    else
                    {
                        Sursa = Sursa.Parent;
                    }
                }

                IMembriComuniControalePersonalizate ctrlAtasat = lControlTinta;
                ctrlAtasat.Focus();

                bool SePoateFaceModificarea = ctrlAtasat.IsInModificationMode;
                string TextControl = GetTextDeCautat(ctrlAtasat);

                //tsDiacritice
                Meniu.Items[0].Visible = IHMUtile._LIMBA_ROMANA && ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.Diacritice) && SePoateFaceModificarea;
                Meniu.Items[0].Text = "Diacritice";

                //****************************************************************************
                //Separator
                Meniu.Items[1].Visible = Meniu.Items[0].Visible;

                //tsDEX + tsGoogle + tsFacebook + tsWikipedia
                Meniu.Items[2].Visible = !string.IsNullOrEmpty(TextControl);
                Meniu.Items[2].Text = "Caută pe";
                //Cautam in DEX doar daca avem limba romana
                (Meniu.Items[2] as ToolStripMenuItem).DropDownItems[3].Visible = IHMUtile._LIMBA_ROMANA;

                //Separator
                Meniu.Items[3].Visible = !string.IsNullOrEmpty(TextControl);

                //****************************************************************************
                //tsAnulati Refaceti
                Meniu.Items[4].Visible = SePoateFaceModificarea && ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.Undo);
                Meniu.Items[4].Text = "Anulați/Refaceți";

                //tsDecupati
                Meniu.Items[5].Visible = ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.Decupare) && SePoateFaceModificarea && !string.IsNullOrEmpty(TextControl);
                Meniu.Items[5].Text = "Decupați";

                //tsCopiati
                Meniu.Items[6].Visible = !string.IsNullOrEmpty(TextControl);
                Meniu.Items[6].Text = "Copiați";

                //tsInserati
                Meniu.Items[7].Visible = ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.Inserare) && SePoateFaceModificarea && Clipboard.ContainsText();
                Meniu.Items[7].Text = "Inserați";

                //tsMesaj
                Meniu.Items[8].Visible = ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.Mesaj) && SePoateFaceModificarea;
                Meniu.Items[8].Text = "Text predefinit";// (mai ok text); [si mai OK Template]

                //Separator
                Meniu.Items[9].Visible = Meniu.Items[7].Visible || Meniu.Items[8].Visible || Meniu.Items[9].Visible || Meniu.Items[10].Visible;

                //****************************************************************************

                //tsSelectatiTot
                Meniu.Items[10].Visible = ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.SelectareText);
                Meniu.Items[10].Text = "Selectați tot";

                //tsCalculati
                Meniu.Items[11].Visible = ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.Calculator);
                Meniu.Items[11].Text = "Calculați";

                //tsCautare
                Meniu.Items[12].Visible = ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.Cautare);
                Meniu.Items[12].Text =  "Căutare";

                //tsSepPrintExport           //13
                //tsPrint                    //14
                //tsExport                   //15
                //tsEmail                    //16
                //tsFullScreen               //17

                Meniu.Items[14].Text = "Imprimă";
                Meniu.Items[14].Visible = IHMUtile._DREPT_IMPRIMARE;
                Meniu.Items[15].Text = "Exportă";
                Meniu.Items[15].Visible = IHMUtile._DREPT_EXPORT;

                Meniu.Items[16].Visible = IHMUtile._DREPT_TRIMITERE_DGV_PE_MAIL && ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.TrimitePeMail);
                Meniu.Items[16].Text = "Trimite pe mail";
                Meniu.Items[17].Visible = ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.FullScreen);
                Meniu.Items[17].Text = "Maximizează";
                Meniu.Items[18].Visible = ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.Refresh);
                Meniu.Items[19].Text = "Ascunde coloane";
                Meniu.Items[19].Visible = ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.AscundeColoane);
                Meniu.Items[20].Text = "Revenire la afișajul inițial";
                Meniu.Items[20].Visible = ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.RevenireLaAfisajulStandard);
            }
            catch (Exception)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Anulam = Undo
        /// Refacem = Undo + Undo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void tsAnulati_Click(object sender, EventArgs e)
        {
            try
            {
                IMembriComuniControalePersonalizate ctrlAtasat = lControlTinta;// (IMembriComuniControalePersonalizate)((ToolStripMenuItem)sender).Tag;
                if (ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.Undo))
                    ctrlAtasat.Undo();
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// Cautam
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void tsCautare_Click(object sender, EventArgs e)
        {
            try
            {
                IMembriComuniControalePersonalizate ctrlAtasat = lControlTinta;// (IMembriComuniControalePersonalizate)((ToolStripMenuItem)sender).Tag;

                using (frmCautare Cautare = new frmCautare(ctrlAtasat))
                {
                    if (IHMUtile.DeschideEcran(IHMUtile.GetFormParinte(sender as Control), Cautare))
                    {
                        //TODO
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Calculam
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void tsCalculator_Click(object sender, EventArgs e)
        {
            try
            {
                IMembriComuniControalePersonalizate ctrlAtasat = lControlTinta;// (IMembriComuniControalePersonalizate)((ToolStripMenuItem)sender).Tag;
                string TextCalculator = string.Empty;
                if (!string.IsNullOrEmpty(ctrlAtasat.SelectedText))
                    TextCalculator = ctrlAtasat.SelectedText;

                using (frmCalculator Calc = new frmCalculator(TextCalculator))
                {
                    if (IHMUtile.DeschideEcran(IHMUtile.GetFormParinte(sender as Control), Calc))
                    {
                        ctrlAtasat.InsereazaText(Calc.Rezultat);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Cautam un text pe google
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void tsGoogle_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmWebBrowser Google = new frmWebBrowser())
                {
                    Google.CautaPeGoogle(GetTextDeCautat(lControlTinta));//(IMembriComuniControalePersonalizate)((ToolStripMenuItem)sender).Tag));
                    IHMUtile.DeschideEcran(IHMUtile.GetFormParinte(sender as Control), Google);

                    if (!Google.IsDisposed)
                        Google.Dispose();
                }
            }
            catch (Exception)
            {
            }
        }

        public static void tsFacebook_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmWebBrowser facebook = new frmWebBrowser())
                {
                    string textDeCautat = GetTextDeCautat(lControlTinta);
                    facebook.CautaPeFaceBook(textDeCautat, textDeCautat, false, false);
                    IHMUtile.DeschideEcran(IHMUtile.GetFormParinte(sender as Control), facebook);

                    if (!facebook.IsDisposed)
                        facebook.Dispose();
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Cautam un text pe Wikipedia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void tsWikipedia_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmWebBrowser Wiki = new frmWebBrowser())
                {
                    Wiki.CautarePeWikipedia(GetTextDeCautat(lControlTinta));//(IMembriComuniControalePersonalizate)((ToolStripMenuItem)sender).Tag));
                    IHMUtile.DeschideEcran(IHMUtile.GetFormParinte(sender as Control), Wiki);

                    if (!Wiki.IsDisposed)
                        Wiki.Dispose();
                }
            }
            catch (Exception)
            {
            }
        }

        public static void tsDecupati_Click(object sender, EventArgs e)
        {
            try
            {
                IMembriComuniControalePersonalizate ctrlAtasat = lControlTinta;// (IMembriComuniControalePersonalizate)((ToolStripMenuItem)sender).Tag;
                if (ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.Decupare))
                    ctrlAtasat.Cut();
            }
            catch (Exception)
            {
            }
        }

        public static void tsCopiati_Click(object sender, EventArgs e)
        {
            try
            {
                IMembriComuniControalePersonalizate ctrlAtasat = lControlTinta;// (IMembriComuniControalePersonalizate)((ToolStripMenuItem)sender).Tag;
                ctrlAtasat.Copy();
            }
            catch (Exception)
            {
            }
        }

        public static void tsInserati_Click(object sender, EventArgs e)
        {
            try
            {
                IMembriComuniControalePersonalizate ctrlAtasat = lControlTinta;// (IMembriComuniControalePersonalizate)((ToolStripMenuItem)sender).Tag;
                if (ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.Inserare))
                    ctrlAtasat.Paste();
            }
            catch (Exception)
            {
            }
        }

        public static void tsRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                IMembriComuniControalePersonalizate ctrlAtasat = lControlTinta;// (IMembriComuniControalePersonalizate)((ToolStripMenuItem)sender).Tag;
                if (ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.Refresh))
                {
                    ctrlAtasat.AnuntaIncepereActiune(EnumTipActiuneControl.Refresh);
                    ctrlAtasat.ExecutaActiunea(EnumTipActiuneControl.Refresh);
                    ctrlAtasat.AnuntaFinalizareActiune(EnumTipActiuneControl.Refresh);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void tsRevenireLaAfisajulStandard_Click(object sender, EventArgs e)
        {
            try
            {
                IMembriComuniControalePersonalizate ctrlAtasat = lControlTinta;// (IMembriComuniControalePersonalizate)((ToolStripMenuItem)sender).Tag;
                if (ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.RevenireLaAfisajulStandard))
                {
                    ctrlAtasat.AnuntaIncepereActiune(EnumTipActiuneControl.RevenireLaAfisajulStandard);
                    ctrlAtasat.ExecutaActiunea(EnumTipActiuneControl.RevenireLaAfisajulStandard);
                    ctrlAtasat.AnuntaFinalizareActiune(EnumTipActiuneControl.RevenireLaAfisajulStandard);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void tsVizibilitateColoane_Click(object sender, EventArgs e)
        {
            try
            {
                IMembriComuniControalePersonalizate ctrlAtasat = lControlTinta;// (IMembriComuniControalePersonalizate)((ToolStripMenuItem)sender).Tag;
                if (ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.AscundeColoane))
                {
                    ctrlAtasat.AnuntaIncepereActiune(EnumTipActiuneControl.AscundeColoane);
                    ctrlAtasat.ExecutaActiunea(EnumTipActiuneControl.AscundeColoane);
                    ctrlAtasat.AnuntaFinalizareActiune(EnumTipActiuneControl.AscundeColoane);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void tsMesaj_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    IMembriComuniControalePersonalizate ctrlAtasat = lControlTinta;// (IMembriComuniControalePersonalizate)((ToolStripMenuItem)sender).Tag;
            //    if (ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.Mesaj))
            //    {
            //        ctrlAtasat.AnuntaIncepereActiune(EnumTipActiuneControl.Mesaj);
            //        string mesaj = CCL.UI.IHMUtile._ComunicareIHM.getMesajParametrabil();
            //        if (!string.IsNullOrEmpty(mesaj.Trim()))
            //            ctrlAtasat.InsereazaText(mesaj);
            //        ctrlAtasat.AnuntaFinalizareActiune(EnumTipActiuneControl.Mesaj);
            //    }
            //}
            //catch (Exception)
            //{
            //}
        }

        public static void tsSelectatiTot_Click(object sender, EventArgs e)
        {
            try
            {
                IMembriComuniControalePersonalizate ctrlAtasat = lControlTinta;// (IMembriComuniControalePersonalizate)((ToolStripMenuItem)sender).Tag;
                if (ctrlAtasat.AcceptaActiunea(EnumTipActiuneControl.SelectareText))
                    ctrlAtasat.SelecteazaTextul();
            }
            catch (Exception)
            {
            }
        }

        public static void tsDEX_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmWebBrowser DEX = new frmWebBrowser())
                {
                    DEX.CautareInDEX(GetTextDeCautat(lControlTinta));//(IMembriComuniControalePersonalizate)((ToolStripMenuItem)sender).Tag));
                    IHMUtile.DeschideEcran(IHMUtile.GetFormParinte(sender as Control), DEX);

                    if (!DEX.IsDisposed)
                        DEX.Dispose();
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Recuperam textul pe care utilizatorul doreste sa il foloseasca la cautare
        /// Fie textul complet in cazul in care 
        /// </summary>
        /// <returns></returns>
        public static string GetTextDeCautat(IMembriComuniControalePersonalizate ctrlAtasat)
        {
            string TextCautare = string.Empty;

            if (ctrlAtasat is WebBrowserPersonalizat)
                TextCautare = ctrlAtasat.SelectedText; //treaba cu textul integral nu are sens la webbrowser
            else
            {
                TextCautare = ctrlAtasat.Text;
                if (ctrlAtasat.SelectionLength > 1)
                    TextCautare = ctrlAtasat.SelectedText;
            }
            return TextCautare;
        }
    }
}
