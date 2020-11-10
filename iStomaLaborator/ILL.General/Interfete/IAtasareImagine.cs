using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ILL.General.Interfete
{
    public interface IAtasareImagine
    {
        int AtaseazaImagine(System.Drawing.Image pImagine);
        int AtaseazaImagine(System.IO.FileInfo pImagine);
    }
}
