using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Models
{
    internal class Prekes
    {
        public const int CmaxPrekiuKiekis = 100;
        string pavadinimas;
        int prekiuKiekis;
        Preke[] prekes = new Preke[CmaxPrekiuKiekis];
        public Prekes() { prekiuKiekis = 0; }
        public string ImtiPavadinima() { return pavadinimas; }
        public int ImtiPrekiuKieki() { return prekiuKiekis; }
        public void DetiPavadinima(string pavadinimas)
        {
            this.pavadinimas = pavadinimas;
        }
        public void DetiPreke(Preke preke)
        {
            prekes[prekiuKiekis++] = preke;
        }
        public Preke ImtiNurodytaPreke(int prekesIndeksas)
        {
            return prekes[prekesIndeksas];
        }
    }
}
