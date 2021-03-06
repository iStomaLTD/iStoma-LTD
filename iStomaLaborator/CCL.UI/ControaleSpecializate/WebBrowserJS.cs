﻿using System.ComponentModel;
using System.Windows.Forms;
using mshtml;

namespace CCL.UI.ControaleSpecializate
{
    public class WebBrowserJS : WebBrowserPersonalizat
    {
        public WebBrowserJS()
            : base()
        {
        }

        public WebBrowserJS(IContainer container)
            : base(container)
        {
        }

        protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e)
        {
            base.OnDocumentCompleted(e);

            //inseram JS pentru aceptare diacritice
            var doc = this.Document;
            if (doc != null)
            {
                var heads = doc.GetElementsByTagName(@"head");
                if (heads.Count > 0)
                {
                    var scriptEl = doc.CreateElement(@"script");
                    if (scriptEl != null)
                    {
                        var element = (IHTMLScriptElement)scriptEl.DomElement;
                        element.text = string.Concat(CCL.UI.IHMUtile.jQuery, CCL.UI.IHMUtile.jQueryUI, CCL.UI.IHMUtile.FunctiiJSStandard);

                        heads[0].AppendChild(scriptEl);
                        doc.InvokeScript(@"AdaugaSalvareId"); //pentru folosirea diacriticelor
                    }
                }
            }
        }
    }
}
