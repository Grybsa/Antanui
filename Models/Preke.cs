using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Models
{
    internal class Preke
    {
        string pavadinimas;
        double kaina;
        int kiekis;
        public Preke() { }
        public Preke(string pavadinimas, double kaina, int kiekis)
        {
            this.pavadinimas = pavadinimas;
            this.kaina = kaina;
            this.kiekis = kiekis;
        }
        public string ImtiPavadinima() { return pavadinimas; }
        public double ImtiKaina() { return kaina; }
        public int ImtiKieki() { return kiekis; }

    }
}
