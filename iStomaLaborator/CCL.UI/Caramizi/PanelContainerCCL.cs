namespace CCL.UI.Caramizi
{
    public class PanelContainerCCL : PanelPersonalizat
    {
        public System.Drawing.SizeF AutoScaleDimensions { get; set; }
        public System.Windows.Forms.AutoScaleMode AutoScaleMode { get; set; }

        protected bool lSeIncarca = false;
        protected bool lEcranInModificare = true;

        protected void incepeIncarcarea()
        {
            this.lSeIncarca = true;
        }

        protected void finalizeazaIncarcarea()
        {
            this.lSeIncarca = false;
        }

        protected void InitializeazaVariabileleGenerale()
        {

        }
    }
}
