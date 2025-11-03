using Layers.Models;
using Layers.Repository;
using Layers.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.Controlers
{
    internal class PrekeControler
    {
        
        PrekeService prekiuServices;
        public PrekeControler()
        {
            prekiuServices = new PrekeService();
        }
        // skaito po eilutę iš .txt failo ir perduoda nuskaitytus duomenis apie vieną prekę servisui
        public void SkaitytiDuomenis(string duomenuFailas)
        {
            using (StreamReader skaitymas = new StreamReader(duomenuFailas))
            {    
                string duomenuEilute;
                while ((duomenuEilute = skaitymas.ReadLine()) != null)
                {
                    string[] eiluesDalys = duomenuEilute.Split(';');
                    string prekesPavadinimas = eiluesDalys[0].Trim();
                    double prekesKaina = double.Parse(eiluesDalys[1]);
                    int prekiuKiekisParduotuveje = int.Parse(eiluesDalys[2]);
                    if (prekiuServices.addPreke(prekesPavadinimas, prekesKaina, prekiuKiekisParduotuveje))
                        IsvestiDraudziamosPrekesPranesima(prekesPavadinimas);
                }
            }
        }
        public void SkaitytiDraudziamasPrekes(string duomenuFailas)
        {
            using (StreamReader skaitymas = new StreamReader(duomenuFailas))
            {
                string prekesPavadinimas;
                while ((prekesPavadinimas = skaitymas.ReadLine()) != null)
                {
                    prekiuServices.addDraudziamaPreke(prekesPavadinimas);
                }
            }
        }
        public void SpausdintiDuomenis(string rezultatuFailas, string antraste)
        {
            using (StreamWriter rasymas = File.AppendText(rezultatuFailas))
            {
                rasymas.WriteLine();
                rasymas.WriteLine(antraste);
                
                rasymas.WriteLine("-----------------------------------------------------------------");
                rasymas.WriteLine("|                   Pavadinimas            |  Kaina   |  Kiekis |");
                rasymas.WriteLine("-----------------------------------------------------------------");
                
                for (int i = 0; i < prekiuServices.prekiuKiekisSarase(); i++)
                {
                    Preke preke = prekiuServices.getPreke(i);
                    rasymas.WriteLine("| {0, -40} | {1, 8:f2} | {2, 5}   |", preke.ImtiPavadinima(), preke.ImtiKaina(), preke.ImtiKieki());
                }

                rasymas.WriteLine("-----------------------------------------------------------------");
            }
        }
        public double IvestiPrekiuKainaSkaiciavimams()
        {
            Console.Write("Įveskite prekių kainą: ");
            return double.Parse(Console.ReadLine());
        }
        public void IsvestiSuskaiciuotaPrekiuKieki(string rezultatuFailas)
        {

            using (StreamWriter papildymas = File.AppendText(rezultatuFailas))
            {
                papildymas.Write("Prekiu su nurodyta kaina kiekis: ");
                papildymas.WriteLine(prekiuServices.NurodytosKainosPrekiuKiekis(IvestiPrekiuKainaSkaiciavimams()));
            }
        }
        public void IsvestiDraudziamosPrekesPranesima(string prekesPavadinimas)
        {
            Console.WriteLine("Draudziama preke {0}", prekesPavadinimas);
        }
        public void IsvalytiFaila()
        {
            Constants constants = new Constants();
            File.Delete(constants.imtiRezultatuFailoPavadinima());
        }

    }
}
