namespace CCL.UI
{
    public enum EnumTipActiuneControl
    {
        Diacritice,
        Undo,
        Cautare,
        Decupare,
        Inserare,
        Export,
        Printare,
        CopiereTabel,
        SelectareText,
        Mesaj,
        ValidareCautare,
        FullScreen,
        Calculator,
        TrimitePeMail,
        Refresh,
        AscundeColoane,
        RevenireLaAfisajulStandard
    }

    public interface IMembriComuniControalePersonalizate
    {
        //Proprietati
        bool IsInModificationMode { get; }
        bool IsInReadOnlyMode { get; set; }
        string ProprietateCorespunzatoare { get; set; }
        string Text { get; set; }
        int SelectionStart { get; set; }
        int SelectionLength { get; set; }
        string SelectedText { get; set; }
        bool Focused { get; }
        bool HideSelection { get; set; }

        //Metode
        bool AcceptaActiunea(EnumTipActiuneControl pTipActiune); //pentru a afisa sau nu o actiune in meniul contextual
        void ExecutaActiunea(EnumTipActiuneControl pTipActiune); //lansam actiunea ceruta de meniul contextual
        void AnuntaIncepereActiune(EnumTipActiuneControl pTipActiune); //pentru a sti cand se incepe o anumita actiune
        void AnuntaFinalizareActiune(EnumTipActiuneControl pTipActiune); //pentru a sti cand se finalizeaza o anumita actiune

        void AllowModification(bool pbInModificationMode);
        System.Collections.Generic.List<int> Cauta(string pText);
        void SelecteazaLaPozitia(int pPozitie, int pLungimeText);
        void SelecteazaTextul();
        void Paste();
        void Undo();
        void Copy();
        void Cut();
        bool Focus();
        void InsereazaText(string pText);
    }
}
