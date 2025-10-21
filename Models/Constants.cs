using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Models
{
    internal class Constants
    {
        const string CDuomenuFailoPavadinimas = "..\\..\\Duomenys.txt";
        const string CRezultatuFailoPavadinimas = "..\\..\\Rezultatai.txt";
        public string imtiDuomenuFailoPavadinima() 
        {
            return CDuomenuFailoPavadinimas;
        }
        public string imtiRezultatuFailoPavadinima()
        {
            return CRezultatuFailoPavadinimas;
        }
    }
}
