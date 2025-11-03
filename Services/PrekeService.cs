using Layers.Models;
using Layers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Layers.Services
{
    internal class PrekeService
    {
        PrekeRepository prekesRepository;
        public PrekeService() 
        {
            prekesRepository = new PrekeRepository();
        }
        public bool arPrekeYraDraudziama(string pavadinimas)
        {
            bool rastaDraudziamaPreke = false;
            for (int i = 0; i < draudziamuPrekiuKiekisSarase() && !rastaDraudziamaPreke; i++)
            {
                if (pavadinimas == prekesRepository.getNurodytaDraudziamaPreke(i))
                {
                    rastaDraudziamaPreke = true;
                }
            }
            return rastaDraudziamaPreke;
        }
        public bool addPreke(string pavadinimas, double kaina, int kiekis)
        {
            bool arPrekeDraudziama = arPrekeYraDraudziama(pavadinimas);
            if (!arPrekeDraudziama)
                prekesRepository.setPreke(new Preke(pavadinimas, kaina, kiekis));
            return arPrekeDraudziama;
        }
        public void addDraudziamaPreke(string pavadinimas)
        {
            prekesRepository.setDraudziamaPreke(pavadinimas);
        }
        public int NurodytosKainosPrekiuKiekis(double prekesKainaSkaiciavimams)
        {
            int skaiciuojamasPrekiuKiekis = 0;
            for (int i = 0; i < prekiuKiekisSarase(); i++)
                if (prekesRepository.getNurodytaPreke(i).ImtiKaina() == prekesKainaSkaiciavimams)
                    skaiciuojamasPrekiuKiekis = skaiciuojamasPrekiuKiekis + prekesRepository.getNurodytaPreke(i).ImtiKieki();
            return skaiciuojamasPrekiuKiekis;
        }
        
        public Preke getPreke(int indeksas)
        {
            return prekesRepository.getNurodytaPreke(indeksas);
        }
        public int prekiuKiekisSarase()
        {
            return getPrekeList().Count;
        }
        public List<Preke> getPrekeList()
        {
            return prekesRepository.getPrekeList();
        }
        public List<string> getDraudziamuPrekiuList()
        {
            return prekesRepository.getDraudziamuPrekiuList();
        }
        public int draudziamuPrekiuKiekisSarase()
        {
            return getDraudziamuPrekiuList().Count;
        }
    }
}
