using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xyz
{
    public static class zyx21352187123yye
    {
        private static int[] _CheieMica = new int[6] { 1, 5, 7, 0, 3, 4 };
        public static string get()
        {
            return desec(@"Ef{a#WpzychA9>53;239?.543aZQO616;_LWUTTA/555<;Lrjypao$Df{aoshBpSwsnfSTGMMF8336<zpd@mtyvmdhfrv;setx~ouh>693797@");
        }

        public static string get2()
        {
            return desec(@"Ef{a#WpzychA9>53;239?.543aZQO616;_LWUTTA/555<;Lrjypao$Df{aoshBpSwsnfSTGMMF8336<zpd@mtyvmdhfrv;setx~ouh>693797@");
        }

        private static string desec(string pIntrare)
        {
            if (string.IsNullOrEmpty(pIntrare)) return string.Empty;

            StringBuilder textRetur = new StringBuilder();

            int marime = _CheieMica.Length;

            for (int i = 0; i < pIntrare.Length; i++)
            {
                textRetur.Append(Char.ConvertFromUtf32(Convert.ToInt32(pIntrare[i]) - _CheieMica[i % marime]));
            }

            return textRetur.ToString();
        }
    }
}
