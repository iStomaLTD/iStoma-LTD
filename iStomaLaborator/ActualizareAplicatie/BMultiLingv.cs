using System;
using System.Collections.Generic;

namespace ActualizareAplicatie
{
    internal class BMultiLingv
    {
        private static EnumLimba _SLimba = EnumLimba.Nedefinit;
        private static Dictionary<EnumDictionar, string> _SDict = null;

        public enum EnumLimba
        {
            Nedefinit = 0,
            Romana = 1,
            Engleza = 2,
            Franceza = 3,
            Maghiara = 4,
            Bulgara = 5,
            Rusa = 6,
            Ucraineana = 7,
            Sarba = 8
        }

        public enum EnumDictionar
        {
            eroare = 1,
            conexiuneLaBazaDeDate = 2,
            informatiileIntroduseNuSuntCorecte = 3,
            bazaDeDate = 4,
            numeInstantaSQL = 5,
            parola = 6,
            server = 7,
            userSQL = 8,
            salveaza = 9,
            actualizari = 10,
            vaMultumim = 11,
            conectareLaServer = 12,
            vaRugamSaAsteptati = 13,
            seInitComunicareaCuServerulIStoma = 14,
            unProdus = 15,
            DetaliiIStoma = 16,
            inNouaVersiuneVetiAveaUrmatoarele = 17,
            actualizare = 18,
            deschideIStoma = 19,
            actiune = 20,
            actualizarileUlterioareDevinDispoDupaActualizare = 21,
            suntetiSigurCaNuDoritiActualizareaAplicatiei = 22,
            nuExistaActualizariDisponibile = 23,
            actualizarileNuSuntDisponibile = 24,
            nuAtiAchizitionatAcesteActualizari = 25,
            contactatiUnReprIDavaSolutionsPtMaiMDetalii = 26,
            recuperareaInfoReferitoaeLaVersiuneaActuala = 27,
            recuperareaNoilorFunctionalitati = 28,
            modificareaLibrariilorIStoma = 29,
            modificareaStructuriiDeDate = 30,
            actualizareInCurs = 31,
            vaRugamSaAsteptatiFinalizareaActualizarii = 32,
        }

        internal static EnumLimba GetLimba()
        {
            return GetLimbaSistemDeOperare();
        }

        internal static string GetById(EnumDictionar pId, int pTipAplicatie)
        {
            if (_SDict == null)
            {
                incarcaDictionarLimba(pTipAplicatie);
            }

            if (_SDict.ContainsKey(pId))
                return _SDict[pId];

            return string.Empty;
        }

        private static void incarcaDictionarLimba(int pTipAplicatie)
        {
            //Nume instanță SQL
            _SDict = new Dictionary<EnumDictionar, string>();
            switch (GetLimbaSistemDeOperare())
            {
                case EnumLimba.Romana:
                    _SDict.Add(EnumDictionar.eroare, "Eroare");
                    _SDict.Add(EnumDictionar.conexiuneLaBazaDeDate, "Conexiune la baza de date");
                    _SDict.Add(EnumDictionar.informatiileIntroduseNuSuntCorecte, "Informațiile introduse nu sunt corecte");
                    _SDict.Add(EnumDictionar.bazaDeDate, "Baza de date");
                    _SDict.Add(EnumDictionar.numeInstantaSQL, "Nume instanță SQL");
                    _SDict.Add(EnumDictionar.parola, "Parolă");
                    _SDict.Add(EnumDictionar.server, "Server");
                    _SDict.Add(EnumDictionar.userSQL, "User SQL");
                    _SDict.Add(EnumDictionar.salveaza, "Salvează");
                    _SDict.Add(EnumDictionar.actualizari, "Actualizări");
                    _SDict.Add(EnumDictionar.vaMultumim, "Vă mulțumim");
                    _SDict.Add(EnumDictionar.conectareLaServer, "Conectare la server");
                    _SDict.Add(EnumDictionar.vaRugamSaAsteptati, "Vă rugăm să așteptați");
                    _SDict.Add(EnumDictionar.seInitComunicareaCuServerulIStoma, "Se inițializează comunicarea cu serverul iStoma LTD");
                    _SDict.Add(EnumDictionar.unProdus, "Un produs");
                    _SDict.Add(EnumDictionar.DetaliiIStoma, "Detalii iStoma LTD");
                    _SDict.Add(EnumDictionar.inNouaVersiuneVetiAveaUrmatoarele, "În noua versiune veți avea următoarele:");
                    _SDict.Add(EnumDictionar.actualizare, "Actualizare");
                    _SDict.Add(EnumDictionar.deschideIStoma, "Deschide iStoma LTD");
                    _SDict.Add(EnumDictionar.actiune, "Acțiune");
                    _SDict.Add(EnumDictionar.actualizarileUlterioareDevinDispoDupaActualizare, "Actualizările ulterioare devin disponibile doar după ce aplicația este actualizată.");
                    _SDict.Add(EnumDictionar.suntetiSigurCaNuDoritiActualizareaAplicatiei, "Sunteți siguri că nu doriți actualizarea aplicației?");
                    _SDict.Add(EnumDictionar.nuExistaActualizariDisponibile, "Nu există actualizări disponibile");
                    _SDict.Add(EnumDictionar.actualizarileNuSuntDisponibile, "Actualizările nu sunt disponibile");
                    _SDict.Add(EnumDictionar.nuAtiAchizitionatAcesteActualizari, "Nu ați achiziționat aceste actualizări");
                    _SDict.Add(EnumDictionar.contactatiUnReprIDavaSolutionsPtMaiMDetalii, "Contactați un reprezentant iDava Solutions pentru mai multe detalii");
                    _SDict.Add(EnumDictionar.recuperareaInfoReferitoaeLaVersiuneaActuala, "Recuperarea informațiilor referitoare la versiunea actuală");
                    _SDict.Add(EnumDictionar.recuperareaNoilorFunctionalitati, "Recuperarea noilor funcționalități");
                    _SDict.Add(EnumDictionar.modificareaLibrariilorIStoma, "Actualizarea librăriilor iStoma LTD" );
                    _SDict.Add(EnumDictionar.modificareaStructuriiDeDate, "Actualizarea structurii de date");
                    _SDict.Add(EnumDictionar.actualizareInCurs, "Actualizare în curs");
                    _SDict.Add(EnumDictionar.vaRugamSaAsteptatiFinalizareaActualizarii, "Vă rugăm să așteptați finalizarea actualizării");
                    break;
                case EnumLimba.Franceza:
                    _SDict.Add(EnumDictionar.eroare, "Erreur");
                    _SDict.Add(EnumDictionar.conexiuneLaBazaDeDate, "Connexion à la base de données");
                    _SDict.Add(EnumDictionar.informatiileIntroduseNuSuntCorecte, "Les informations saisies ne sont pas valides");
                    _SDict.Add(EnumDictionar.bazaDeDate, "Base de données");
                    _SDict.Add(EnumDictionar.numeInstantaSQL, "Nom d'instance SQL");
                    _SDict.Add(EnumDictionar.parola, "Mot de passe");
                    _SDict.Add(EnumDictionar.server, "Serveur");
                    _SDict.Add(EnumDictionar.userSQL, "Utilisateur SQL");
                    _SDict.Add(EnumDictionar.salveaza, "Sauvegarder");
                    _SDict.Add(EnumDictionar.actualizari, "Mises à jour");
                    _SDict.Add(EnumDictionar.vaMultumim, "Nous vous remercions");
                    _SDict.Add(EnumDictionar.conectareLaServer, "Connexion au serveur");
                    _SDict.Add(EnumDictionar.vaRugamSaAsteptati, "S'il vous plaît patienter");
                    _SDict.Add(EnumDictionar.seInitComunicareaCuServerulIStoma, pTipAplicatie == 0 ? "Démarrage de la communication avec le serveur iStoma LTD" : "Démarrage de la communication avec le serveur iClinic");
                    _SDict.Add(EnumDictionar.unProdus, "Un produit");
                    _SDict.Add(EnumDictionar.DetaliiIStoma, pTipAplicatie == 0 ? "Détails iStoma LTD" : "Détails iClinic");
                    _SDict.Add(EnumDictionar.inNouaVersiuneVetiAveaUrmatoarele, "La nouvelle version aura le suivant:");
                    _SDict.Add(EnumDictionar.actualizare, "Mise à jour");
                    _SDict.Add(EnumDictionar.deschideIStoma, pTipAplicatie == 0 ? "Démarrer iStoma LTD" : "Démarrer iClinic");
                    _SDict.Add(EnumDictionar.actiune, "Action");
                    _SDict.Add(EnumDictionar.actualizarileUlterioareDevinDispoDupaActualizare, "Les mises à jour ultérieures ne sont disponibles qu'après l'application est mise à jour.");
                    _SDict.Add(EnumDictionar.suntetiSigurCaNuDoritiActualizareaAplicatiei, "Etes-vous sûr que vous ne voulez pas mettre à jour l'application?");
                    _SDict.Add(EnumDictionar.nuExistaActualizariDisponibile, "Il n'y a pas de mises à jour disponibles");
                    _SDict.Add(EnumDictionar.actualizarileNuSuntDisponibile, "Les mises à jour ne sont pas disponibles");
                    _SDict.Add(EnumDictionar.nuAtiAchizitionatAcesteActualizari, "Vous n'avez pas acheté ces mises à jour");
                    _SDict.Add(EnumDictionar.contactatiUnReprIDavaSolutionsPtMaiMDetalii, "Contactez un représentant iDava Solutions pour en savoir plus");
                    _SDict.Add(EnumDictionar.recuperareaInfoReferitoaeLaVersiuneaActuala, "Obtenir les détails de la version actuelle");
                    _SDict.Add(EnumDictionar.recuperareaNoilorFunctionalitati, "Obtenir les nouvelles fonctionnalités");
                    _SDict.Add(EnumDictionar.modificareaLibrariilorIStoma, pTipAplicatie == 0 ? "Mise à jour des fichiers iStoma LTD" : "Mise à jour des fichiers iClinic");
                    _SDict.Add(EnumDictionar.modificareaStructuriiDeDate, "Mise à jour de la base de données");
                    _SDict.Add(EnumDictionar.actualizareInCurs, "En cours de mise à jour");
                    _SDict.Add(EnumDictionar.vaRugamSaAsteptatiFinalizareaActualizarii, "S'il vous plaît attendre la finalisation de la mise à jour");
                    break;
                case EnumLimba.Engleza:
                case EnumLimba.Maghiara:
                case EnumLimba.Bulgara:
                case EnumLimba.Rusa:
                case EnumLimba.Ucraineana:
                case EnumLimba.Sarba:
                    _SDict.Add(EnumDictionar.eroare, "Error");
                    _SDict.Add(EnumDictionar.conexiuneLaBazaDeDate, "Database connection");
                    _SDict.Add(EnumDictionar.informatiileIntroduseNuSuntCorecte, "The entered information is invalid");
                    _SDict.Add(EnumDictionar.bazaDeDate, "Database");
                    _SDict.Add(EnumDictionar.numeInstantaSQL, "SQL instance name");
                    _SDict.Add(EnumDictionar.parola, "Password");
                    _SDict.Add(EnumDictionar.server, "Server");
                    _SDict.Add(EnumDictionar.userSQL, "SQL user");
                    _SDict.Add(EnumDictionar.salveaza, "Save");
                    _SDict.Add(EnumDictionar.actualizari, "Updates");
                    _SDict.Add(EnumDictionar.vaMultumim, "Thank you");
                    _SDict.Add(EnumDictionar.conectareLaServer, "Connect to server");
                    _SDict.Add(EnumDictionar.vaRugamSaAsteptati, "Please wait");
                    _SDict.Add(EnumDictionar.seInitComunicareaCuServerulIStoma, pTipAplicatie == 0 ? "Starting the communication with the iStoma LTD server" : "Starting the communication with the iClinic server");
                    _SDict.Add(EnumDictionar.unProdus, "By");
                    _SDict.Add(EnumDictionar.DetaliiIStoma, pTipAplicatie == 0 ? "iStoma LTD details" : "iClinic details");
                    _SDict.Add(EnumDictionar.inNouaVersiuneVetiAveaUrmatoarele, "The new version will have the following:");
                    _SDict.Add(EnumDictionar.actualizare, "Update");
                    _SDict.Add(EnumDictionar.deschideIStoma, pTipAplicatie == 0 ? "Open iStoma LTD" : "Open iClinic");
                    _SDict.Add(EnumDictionar.actiune, "Action");
                    _SDict.Add(EnumDictionar.actualizarileUlterioareDevinDispoDupaActualizare, "Future updates become available only after the application is updated.");
                    _SDict.Add(EnumDictionar.suntetiSigurCaNuDoritiActualizareaAplicatiei, "Are you sure you do not want to update the application?");
                    _SDict.Add(EnumDictionar.nuExistaActualizariDisponibile, "There are no updates available");
                    _SDict.Add(EnumDictionar.actualizarileNuSuntDisponibile, "The updates are not available");
                    _SDict.Add(EnumDictionar.nuAtiAchizitionatAcesteActualizari, "You have not bought these updates");
                    _SDict.Add(EnumDictionar.contactatiUnReprIDavaSolutionsPtMaiMDetalii, "Contact an iDava Solutions representative for more details");
                    _SDict.Add(EnumDictionar.recuperareaInfoReferitoaeLaVersiuneaActuala, "Getting the details of the current version");
                    _SDict.Add(EnumDictionar.recuperareaNoilorFunctionalitati, "Getting the new functionalities");
                    _SDict.Add(EnumDictionar.modificareaLibrariilorIStoma, pTipAplicatie == 0 ? "Updating iStoma LTD files" : "Updating iClinic files");
                    _SDict.Add(EnumDictionar.modificareaStructuriiDeDate, "Updating the database");
                    _SDict.Add(EnumDictionar.actualizareInCurs, "Update in progress");
                    _SDict.Add(EnumDictionar.vaRugamSaAsteptatiFinalizareaActualizarii, "Please wait until the update is completed");
                    break;
            }
        }

        private static int GetLimbaRegistri()
        {
            Microsoft.Win32.RegistryKey cheie = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\iStomaLTD");
            if (cheie == null)
                cheie = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\iStomaLTD");

            try
            {
                if (cheie.GetValue("LIMBA") != null)
                    return Convert.ToInt32(cheie.GetValue("LIMBA"));
            }
            catch (Exception)
            {
            }

            return -1;
        }

        private static EnumLimba GetLimbaSistemDeOperare()
        {
            if (_SLimba != EnumLimba.Nedefinit) return _SLimba;

            int idLimba = GetLimbaRegistri();
            if (idLimba > 0)
            {
                EnumLimba lmb = (EnumLimba)idLimba;
                if (lmb == EnumLimba.Romana)
                    return EnumLimba.Romana;
                else
                    if (lmb == EnumLimba.Franceza)
                    return EnumLimba.Franceza;

                return EnumLimba.Engleza;
            }

            string limba = System.Globalization.CultureInfo.InstalledUICulture.TwoLetterISOLanguageName.ToLower();

            if (limba.Contains("ro") || limba.Contains("md"))
                return EnumLimba.Romana;
            else
                if (limba.Contains("fr"))
                return EnumLimba.Franceza;

            return EnumLimba.Engleza;
        }

    }
}
