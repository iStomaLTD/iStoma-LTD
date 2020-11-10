using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.UI.Caramizi
{
    public class ControlGraficEvolutie : WebBrowserPersonalizat
    {
        public void Initializeaza(Dictionary<string, double> pDateGrafic, string pTextListaGoala)
        {
            StringBuilder html = new StringBuilder();
            html.Append("  <!DOCTYPE html>");
            html.Append(" <html>");
            html.Append(" <head>");
            html.Append(" </head>");
            html.Append(" <body style='width:90%; font: normal .80em 'trebuchet ms', arial, sans-serif;'>");

            if (pDateGrafic != null)
            {
                html.Append(" <table style='width:100%;'>");
                foreach (KeyValuePair<string, double> item in pDateGrafic)
                {
                    html.Append(" <tr>");
                    html.Append("       <td style='width:90px;height:25px;text-color:#5F635E'>");
                    html.Append(item.Key);
                    html.Append("       </td>");

                    html.Append("       <td>");

                    html.Append("<div style='position:relative;width:100%;min-height:100%;height:100%;border:1px solid #ADADAD;'>");
                    html.Append(string.Format("<div style='min-width:{0};width:{0};background-color:{1};'>", string.Format("{0}%", Math.Round(item.Value, 0)), getCuloareProcentaj((int)Math.Round(item.Value, 0))));
                    html.Append("</div>");
                    html.Append("<div style='position:absolute; float:left; top:0;left:0; text-align:center;width:100%;min-width:100%;'>");
                    html.Append(string.Format("{0}%", Math.Round(item.Value, 2)));
                    html.Append("</div>");
                    html.Append("</div>");

                    html.Append("       </td>");

                    html.Append(" </tr>");
                }
                html.Append(" </table>");
            }
            else
                html.Append(string.Concat("<p style='text-color:#5F635E;font: normal .80em 'trebuchet ms', arial, sans-serif;'>", pTextListaGoala, "</p>"));

            html.Append(" </body>");
            html.Append(" </html>");

            this.Initializeaza(html.ToString());
        }

        private static string getCuloareProcentaj(int pProcentaj)
        {
            return "#31B725";

            //if (pProcentaj >= 0 && pProcentaj < 10)
            //    return "#E0FFFF"; //Light Cyan
            //else
            //    if (pProcentaj >= 10 && pProcentaj < 20)
            //        return "#CFECEC"; //Light Cyan2
            //    else
            //        if (pProcentaj >= 20 && pProcentaj < 30)
            //            return "#00FFFF"; //Cyan
            //        else
            //            if (pProcentaj >= 30 && pProcentaj < 40)
            //                return "#52F3FF"; //Turquoise1
            //            else
            //                if (pProcentaj >= 40 && pProcentaj < 50)
            //                    return "#AFDCEC"; //Light Blue2
            //                else
            //                    if (pProcentaj >= 50 && pProcentaj < 60)
            //                        return "#82CAFA"; //Light Sky Blue
            //                    else
            //                        if (pProcentaj >= 60 && pProcentaj < 70)
            //                            return "#A0CFEC"; //Light Sky Blue2
            //                        else
            //                            if (pProcentaj >= 70 && pProcentaj < 80)
            //                                return "#82CAFF"; //Sky Blue
            //                            else
            //                                if (pProcentaj >= 80 && pProcentaj < 90)
            //                                    return "#79BAEC"; //Sky Blue2
            //return "#6698FF"; //Sky Blue
        }
    }
}
