using Layers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Repository
{
    internal class PrekeRepository
    {
        List<Preke> PrekiuSarasas = new List<Preke>();
        public PrekeRepository() {  }
        public void setPreke(Preke preke)
        {
           PrekiuSarasas.Add(preke); 
        }
        public Preke getNurodytaPreke(int prekesIndeksas)
        {
            return PrekiuSarasas[prekesIndeksas];
        }
        public int PrekiuKiekis()
        { 
            return PrekiuSarasas.Count;
        }
        public List<Preke> getPrekeList() 
        { 
            return PrekiuSarasas; 
        }
    }
}
