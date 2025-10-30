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
        public void addPreke(string pavadinimas, double kaina, int kiekis)
        {
            // Preke NaujaPreke = new Preke(pavadinimas, kaina, kiekis);
            prekesRepository.setPreke(new Preke(pavadinimas, kaina, kiekis));
        }
        public int NurodytosKainosPrekiuKiekis(double prekesKainaSkaiciavimams)
        {
            int skaiciuojamasPrekiuKiekis = 0;
            for (int i = 0; i < prekesRepository.PrekiuKiekis() ; i++)
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
    }
}
