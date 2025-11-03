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
        List<string> DraudziamuPrekiuSarasas = new List<string>();
        public PrekeRepository() {  }
        public void setPreke(Preke preke)
        {
           PrekiuSarasas.Add(preke); 
        }
        public void setDraudziamaPreke(string prekesPavadinimas)
        {
            DraudziamuPrekiuSarasas.Add(prekesPavadinimas);
        }
        public Preke getNurodytaPreke(int prekesIndeksas)
        {
            return PrekiuSarasas[prekesIndeksas];
        }
        public string getNurodytaDraudziamaPreke(int prekesIndeksas)
        {
            return DraudziamuPrekiuSarasas[prekesIndeksas];
        }
        public List<Preke> getPrekeList() 
        { 
            return PrekiuSarasas; 
        }
        public List<string> getDraudziamuPrekiuList()
        {
            return DraudziamuPrekiuSarasas;
        }
    }
}
