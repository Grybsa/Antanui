using Layers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Repository
{
    internal class PrekesRepository
    {
        Prekes prekes;
        public PrekesRepository() { prekes = new Prekes(); }
        public void DetiPreke(Preke preke)
        {
            prekes.DetiPreke(preke);
        }
        public Preke ImtiNurodytaPreke(int prekesIndeksas)
        {
            return prekes.ImtiNurodytaPreke(prekesIndeksas);
        }
        public Prekes ImtiPrekes()
        {
            return prekes;
        }
    }
}
