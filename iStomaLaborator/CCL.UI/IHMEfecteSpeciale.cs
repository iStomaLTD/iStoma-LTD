using CCL.iStomaLab;
using CCL.UI.Caramizi;
using CDL.iStomaLab;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCL.UI
{
    public class IHMEfecteSpeciale
    {

        #region Delaratii generale

        private static Form _SEcranEfect = null;

        #endregion

        #region Efect NU

        private static Timer _STemporizator = null;
        private static Timer _STemporizatorWAIT = null;
        private static int _SNumarRepetari = 0;
        private static Point _SPozitieInitiala = Point.Empty;

        public static void AplicaEfectNU(Form pEcranEfect)
        {
            AplicaEfectNU(pEcranEfect, null, null);
        }
        public static void AplicaEfectNU(Form pEcranEfect, Label pLblAlerta, Control pControlFocus)
        {
            if (pEcranEfect != null && _STemporizator == null)
            {
                _SEcranEfect = pEcranEfect;
                _SNumarRepetari = 0;
                _SPozitieInitiala = pEcranEfect.Location;
                _STemporizator = new Timer();
                _STemporizator.Interval = 60;
                _STemporizator.Tick += _STemporizator_Tick;
                _STemporizator.Start();
            }

            if (pLblAlerta != null)
                pLblAlerta.ForeColor = Color.Red;

            if (pControlFocus != null)
                pControlFocus.Focus();
        }

        private static void _STemporizator_Tick(object sender, EventArgs e)
        {
            try
            {
                _SNumarRepetari += 1;
                if (_SNumarRepetari == 4)
                {
                    _SNumarRepetari = 0;
                    _SEcranEfect.Location = _SPozitieInitiala;
                    _STemporizator.Stop();
                    _STemporizator.Dispose();
                    _STemporizator = null;
                }
                else
                {
                    if (_SNumarRepetari % 2 == 0)
                        _SEcranEfect.Left += 10;// = new Point(_SPozitieInitiala.X + 10, _SPozitieInitiala.Y);
                    else
                        _SEcranEfect.Left -= 10;// = new Point(_SPozitieInitiala.X - 10, _SPozitieInitiala.Y);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Efect WAIT

        private static int _SNumarSecundeWait = 3;
        private static int _SNumarSecundeScurse = 3;
        private static Label _SEtichetaTemporizare = null;
        public static void AplicaEfectWAIT(Form pEcranEfect, Label pEtichetaTemporizare, int pNumarSecundeWait)
        {
            if (pEcranEfect != null && _STemporizator == null)
            {
                _SEcranEfect = pEcranEfect;
                _SEtichetaTemporizare = pEtichetaTemporizare;
                _SNumarSecundeWait = pNumarSecundeWait;
                _SNumarSecundeScurse = 0;
                _STemporizatorWAIT = new Timer();
                _STemporizatorWAIT.Interval = 1000;
                _STemporizatorWAIT.Tick += _STemporizatorWAIT_Tick;
                _STemporizatorWAIT.Start();
            }
        }

        private static void _STemporizatorWAIT_Tick(object sender, EventArgs e)
        {
            try
            {
                _SNumarSecundeScurse += 1;

                if (_SEcranEfect != null && !_SEcranEfect.IsDisposed && !_SEcranEfect.Disposing)
                {
                    _SEtichetaTemporizare.Text = string.Format("{0} {1}", Math.Max(0, _SNumarSecundeWait - _SNumarSecundeScurse).ToString(), CUtil.getText(200));

                    if (_SNumarSecundeScurse > _SNumarSecundeWait)
                    {
                        _STemporizatorWAIT.Stop();
                        _STemporizatorWAIT.Dispose();
                        _STemporizatorWAIT = null;

                        if (_SEcranEfect != null && !_SEcranEfect.IsDisposed && !_SEcranEfect.Disposing)
                        {
                            _SEcranEfect.DialogResult = DialogResult.OK;
                            _SEcranEfect.Close();
                        }
                    }
                }
                else
                {
                    _STemporizatorWAIT.Stop();
                    _STemporizatorWAIT.Dispose();
                    _STemporizatorWAIT = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, IHMUtile.getText(605), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Efect Schimbare Culoare

        public static void SeteazaForeColorAlerta(TextBoxPersonalizat ptextBox, LabelPersonalizat pLabel)
        {
            if (string.IsNullOrEmpty(ptextBox.Text))
            {
                pLabel.ForeColor = Color.Red;
            }
            else
            {
                pLabel.ForeColor = Color.Black;
            }
        }

        public static void SeteazaForeColorAlerta(ControlDataOraGuma ptextBox, LabelPersonalizat pLabel)
        {
            if (!ptextBox.AreValoare)
            {
                pLabel.ForeColor = Color.Red;
            }
            else
            {
                pLabel.ForeColor = Color.Black;
            }
        }

        public static void SeteazaForeColorAlerta(LabelGumaFind ptextBox, LabelPersonalizat pLabel)
        {
            if (!ptextBox.AreValoare())
            {
                pLabel.ForeColor = Color.Red;
            }
            else
            {
                pLabel.ForeColor = Color.Black;
            }
        }

        public static void SeteazaForeColorAlerta(controlAlegeData ptextBox, LabelPersonalizat pLabel)
        {
            if (!ptextBox.AreData)
            {
                pLabel.ForeColor = Color.Red;
            }
            else
            {
                pLabel.ForeColor = Color.Black;
            }
        }

        public static void SeteazaForeColorAlerta(TextBoxGumaFind ptextBox, LabelPersonalizat pLabel)
        {
            if (string.IsNullOrEmpty(ptextBox.Text))
            {
                pLabel.ForeColor = Color.Red;
            }
            else
            {
                pLabel.ForeColor = Color.Black;
            }
        }

        public static void SeteazaForeColorAlerta(MaskedTextBoxPersonalizat ptextBox, LabelPersonalizat pLabel)
        {
            if (string.IsNullOrEmpty(ptextBox.Text))
            {
                pLabel.ForeColor = Color.Red;
            }
            else
            {
                pLabel.ForeColor = Color.Black;
            }
        }

        public static void SeteazaForeColorAlerta(MaskedTextBoxGuma ptextBox, LabelPersonalizat pLabel)
        {
            if (ptextBox.ValoareDouble <= 0)
            {
                pLabel.ForeColor = Color.Red;
            }
            else
            {
                pLabel.ForeColor = Color.Black;
            }
        }

        public static void SeteazaForeColorAlerta(ComboBoxPersonalizat pComboBox, LabelPersonalizat pLabel)
        {
            if (pComboBox.SelectedIndex == 0)
            {
                pLabel.ForeColor = Color.Red;
            }
            else
            {
                pLabel.ForeColor = Color.Black;
            }
        }

        public static void SeteazaForeColorAlerta(ComboBoxPersonalizat pComboBox, LabelPersonalizat pLabel, int pIndexDeInceput)
        {
            if (pComboBox.SelectedIndex < pIndexDeInceput)
            {
                pLabel.ForeColor = Color.Red;
            }
            else
            {
                pLabel.ForeColor = Color.Black;
            }
        }

        public static void SeteazaForeColorAlerta(int pIdObiectCorespunzator, LabelPersonalizat pLabel)
        {
            if (pIdObiectCorespunzator == 0)
            {
                pLabel.ForeColor = Color.Red;
            }
            else
            {
                pLabel.ForeColor = Color.Black;
            }
        }

        #endregion

    }
}
