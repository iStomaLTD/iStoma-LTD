using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iStomaLab.Caramizi
{
    public partial class ControlCautareElement : Generale.UserControlPersonalizat
    {
        /// <summary>
        /// Enter si Esc au gestiune interna in acest control si nu trebuiesc interpretate de controlul parinte
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(System.Windows.Forms.Keys keyData)
        {
            if (keyData == System.Windows.Forms.Keys.Escape || keyData == System.Windows.Forms.Keys.Enter)
            {
                return true;
            }
            else
                return base.ProcessDialogKey(keyData);
        }
    }
}
