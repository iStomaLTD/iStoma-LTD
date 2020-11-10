using iStomaLab.Generale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab
{
    static class Program
    {
        private static EcranPrincipal _SMain = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             _SMain = new EcranPrincipal();
            Application.Run(_SMain);
        }

        [STAThread]
        internal static void Deconectare(Form pMain)
        {
            pMain.Close();
            _SMain = new EcranPrincipal();
            Application.Restart();
        }
       
    }
}
