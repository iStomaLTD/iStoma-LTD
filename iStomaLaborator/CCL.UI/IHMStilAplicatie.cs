using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCL.UI
{
    public static class IHMStilAplicatie
    {
        public static Color _SMeniuSusButonSelectat = SystemColors.ControlLight;
        public static Color _SMeniuSusButonNeSelectat = SystemColors.Control;
        public static Color _SMeniuSusBaraOptiuniFundal = SystemColors.Control;
        public static Color _SMeniuSusBaraOptiuniMouseOver = SystemColors.ControlLight;
        public static Color _SMeniuSusTextButonSelectat = Color.Black;
        public static Color _SMeniuSusText = Color.Black;

        public static Color _SDGVFundal = Color.White;
        public static Color _SDGVFundalNormal = Color.White;
        public static Color _SDGVCuloareDGVTextLinieNormala = Color.Black;
        public static Color _SDGVFundalAlternant = SystemColors.Control;
        public static Color _SDGVCuloareDGVTextLinieAlternanta = Color.Black;
        public static Color _SDGVCuloareDGVFundalLinieSelectata = Color.LightGray;// Silver;
        public static Color _SDGVCuloareDGVTextLinieSelectata = Color.Black;

        public static Color _SDGVTextAlerta = Color.Red;
        public static Color _SDGVTextOK = Color.Green;

        public static void AplicaStareButonMeniuSus(ToolStripButton pBtnOptine, bool pSelectat)
        {
            pBtnOptine.Checked = pSelectat;
            pBtnOptine.BackColor = pSelectat ? _SMeniuSusButonSelectat : _SMeniuSusButonNeSelectat;
        }
    }
}
