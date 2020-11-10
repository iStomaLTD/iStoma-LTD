using CCL.iStomaLab;
using CDL.iStomaLab;
using iStomaLab.Generale;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab
{
    static class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern Boolean GetLastInputInfo(ref tagLASTINPUTINFO plii);

        public struct tagLASTINPUTINFO
        {
            public uint cbSize;
            public Int32 dwTime;
        }

        public static int GetNrMinuteInactivitate()
        {
            tagLASTINPUTINFO LastInput = new tagLASTINPUTINFO();
            Int32 IdleTime = 0;
            LastInput.cbSize = (uint)Marshal.SizeOf(LastInput);
            LastInput.dwTime = 0;

            if (GetLastInputInfo(ref LastInput))
            {
                IdleTime = System.Environment.TickCount - LastInput.dwTime;
            }

            return IdleTime / 60000;
        }

        public static bool _SDeconectat = false;

        //private static EcranPrincipal _SMain = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool existaDejaInAceeasiSesiune = false;
            Process current = Process.GetCurrentProcess();
            bool esteMultiSesiune = false;
            if (!esteMultiSesiune)
            {
                //Pentru cazurile in care avem mai multe sesiuni (Windows Server)
                //Trebuie ca fiecare utilizator sa poata rula aplicatia o singura data
                if (Process.GetProcessesByName(current.ProcessName).Length > 1)
                {
                    Process[] runningProcesses = Process.GetProcesses();
                    var currentSessionID = Process.GetCurrentProcess().SessionId;

                    Process[] sameAsThisSession = (from c in runningProcesses where c.SessionId == currentSessionID select c).ToArray();

                    foreach (var process in sameAsThisSession)
                    {
                        //}

                        //foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                        //{
                        if (process.Id != current.Id)
                        {

                            SetForegroundWindow(process.MainWindowHandle);
                            ShowWindow(process.MainWindowHandle, (int)EnumWindowStates.SW_SHOWMAXIMIZED);

                            return;
                        }
                    }
                }
            }

            //ro-RO
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.CurrentCulture = new System.Globalization.CultureInfo("ro-RO");
            //Application.CurrentInputLanguage = InputLanguage.FromCulture(Application.CurrentCulture);
            Thread.CurrentThread.CurrentUICulture = Application.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = Application.CurrentCulture;

            //Trebuie sa ruleze cu prioritate
            current.PriorityClass = ProcessPriorityClass.High;
            current.PriorityBoostEnabled = true;

            EcranPrincipal _SMain = null;

            try
            {
                do
                {
                    //Afisam ecranul de asteptare pe care il inchidem dupa incarcarea ecranului principal (frmStoma)
                    //lEcranAstepare = new EcranAsteptare();
                    //lEcranAstepare.Show();

                    _SMain = new EcranPrincipal();
                    if (_SMain.IsDisposed == false)
                    {
                        try
                        {
                            URLSecurityZoneAPI.InternetSetFeatureEnabled(URLSecurityZoneAPI.InternetFeaturelist.DISABLE_NAVIGATION_SOUNDS, URLSecurityZoneAPI.SetFeatureOn.PROCESS, true);
                        }
                        catch (Exception)
                        {
                            //Nu este nicio problema daca nu reusim sa dezactivam sunetele de la IE
                        }

                        //Ca sa aiba toate functiile Internet Explorer
                        var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
                        SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, GetBrowserEmulationMode());

                        Application.Run(_SMain);
                    }
                    else
                    {
                        //lEcranAstepare.Close();
                    }
                } while (_SMain.InchideAplicatia != true);
            }
            catch (Exception ex)
            {
                if (_SMain != null)
                    _SMain.inchideEcranAsteptare();

                if (ex is InvalidOperationException || ex is SqlException)
                {
                    //Serverul nu este pornit
                    MessageBox.Show(string.Concat("Serverul nu este pornit", CConstante.LinieNoua, CUtil.GetTextCompletExceptie(ex)), "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Alta eroare
                    MessageBox.Show(CUtil.GetTextCompletExceptie(ex), "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //_SMain = new EcranPrincipal();
            //Application.Run(_SMain);
        }

        //[STAThread]
        //internal static void Deconectare(Form pMain)
        //{
        //    pMain.Close();
        //    _SMain.Close();
        //    _SMain.Dispose();
        //    _SMain = null;

        //    //_SMain = new EcranPrincipal();
        //    //Application.Restart();
        //    _SMain = new EcranPrincipal();
        //    Application.Run(_SMain);
        //}

        private static void SetBrowserFeatureControlKey(string feature, string appName, uint value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(
                String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
                RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
            }
        }

        private static UInt32 GetBrowserEmulationMode()
        {
            int browserVersion = 7;
            using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                RegistryKeyPermissionCheck.ReadSubTree,
                System.Security.AccessControl.RegistryRights.QueryValues))
            {
                var version = ieKey.GetValue("svcVersion");
                if (null == version)
                {
                    version = ieKey.GetValue("Version");
                    if (null == version)
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                }
                int.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }

            UInt32 mode = 11000; // Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 Standards mode. Default value for Internet Explorer 11.
            switch (browserVersion)
            {
                case 7:
                    mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. Default value for applications hosting the WebBrowser Control.
                    break;
                case 8:
                    mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. Default value for Internet Explorer 8
                    break;
                case 9:
                    mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode. Default value for Internet Explorer 9.
                    break;
                case 10:
                    mode = 10000; // Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 mode. Default value for Internet Explorer 10.
                    break;
                default:
                    // use IE11 mode by default
                    break;
            }

            return mode;
        }

        internal static void KillAll()
        {
            Process current = Process.GetCurrentProcess();
            Process[] ListaCuAcelasiNume = Process.GetProcessesByName(current.ProcessName);
            if (ListaCuAcelasiNume.Length > 1)
            {
                foreach (Process process in ListaCuAcelasiNume)
                {
                    if (process.Id != current.Id)
                    {
                        process.Kill();
                    }
                }
            }

            if (!current.HasExited)
                current.Kill();
        }
    }
}
