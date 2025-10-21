using Layers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Services
{
    internal class PrekiuServices
    {
        PrekesRepository prekesRepository;
        public PrekiuServices(PrekesRepository prekesRepository) 
        {
           this.prekesRepository = prekesRepository;
        }
        public int NurodytosKainosPrekiuKiekis(double prekesKainaSkaiciavimams)
        {
            int skaiciuojamasPrekiuKiekis = 0;
            for (int i = 0; i < prekesRepository.ImtiPrekes().ImtiPrekiuKieki(); i++)
                if (prekesRepository.ImtiNurodytaPreke(i).ImtiKaina() == prekesKainaSkaiciavimams)
                    skaiciuojamasPrekiuKiekis++;
            return skaiciuojamasPrekiuKiekis;
        }
    }
}
