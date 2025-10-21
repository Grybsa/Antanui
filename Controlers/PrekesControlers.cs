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
    internal class PrekesControlers
    {
        PrekesRepository prekesRepository;
        PrekiuServices prekiuServices;
        public PrekesControlers()
        {
            prekesRepository = new PrekesRepository();
            prekiuServices   = new PrekiuServices(prekesRepository);
        }
        public void SkaitytiDuomenis(string duomenuFailas)
        {
            using (StreamReader skaitymas = new StreamReader(duomenuFailas))
            {
                string parduotuvesPavadinimas = skaitymas.ReadLine();
                prekesRepository.ImtiPrekes().DetiPavadinima(parduotuvesPavadinimas);
                string duomenuEilute;
                while ((duomenuEilute = skaitymas.ReadLine()) != null && prekesRepository.ImtiPrekes().ImtiPrekiuKieki() < Prekes.CmaxPrekiuKiekis)
                {
                    string[] eiluesDalys = duomenuEilute.Split(';');
                    string prekesPavadinimas = eiluesDalys[0].Trim();
                    double prekesKaina = double.Parse(eiluesDalys[1]);
                    int prekiuKiekisParduotuveje = int.Parse(eiluesDalys[2]);
                    prekesRepository.DetiPreke(new Preke(prekesPavadinimas, prekesKaina, prekiuKiekisParduotuveje));
                }
            }
        }
        public void SpausdintiDuomenis(string rezultatuFailas, string antraste)
        {
            using (StreamWriter rasymas = File.AppendText(rezultatuFailas))
            {
                rasymas.WriteLine();
                rasymas.WriteLine(antraste);
                rasymas.WriteLine(prekesRepository.ImtiPrekes().ImtiPavadinima());
                rasymas.WriteLine("-----------------------------------------------------------------");
                rasymas.WriteLine("|                   Pavadinimas            |  Kaina   |  Kiekis |");
                rasymas.WriteLine("-----------------------------------------------------------------");
                int prekiuKiekis = prekesRepository.ImtiPrekes().ImtiPrekiuKieki();
                for (int i = 0; i < prekiuKiekis; i++)
                {
                    Preke preke = prekesRepository.ImtiPrekes().ImtiNurodytaPreke(i);
                    rasymas.WriteLine("| {0, -40} | {1, 8:f2} | {2, 5}   |", preke.ImtiPavadinima(), preke.ImtiKaina(), preke.ImtiKieki());
                }
                rasymas.WriteLine("-----------------------------------------------------------------");
            }
        }
        public double PrekiuKainosSkaiciavimamsIvedimas()
        {
            Console.Write("Įveskite prekių kainą: ");
            return double.Parse(Console.ReadLine());
        }
        public void SuskaiciuotoPrekiuKiekioIsvedimas(string rezultatuFailas)
        {

            using (StreamWriter papildymas = File.AppendText(rezultatuFailas))
            {
                papildymas.Write("Prekiu su nurodyta kaina kiekis: ");
                papildymas.WriteLine(prekiuServices.NurodytosKainosPrekiuKiekis(PrekiuKainosSkaiciavimamsIvedimas()));
            }
        }
        public void IsvalytiFaila()
        {
            Constants constants = new Constants();
            File.Delete(constants.imtiRezultatuFailoPavadinima());
        }

    }
}
