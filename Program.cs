using Layers.Controlers;
using Layers.Models;
using Layers.Repository;
using Layers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           // PrekiuServices prekiuServices = new PrekiuServices();
            Constants constants = new Constants();

            PrekeControler prekesControler = new PrekeControler();

            string duomenuFailas = constants.imtiDuomenuFailoPavadinima();
            string rezultatuFailas = constants.imtiRezultatuFailoPavadinima();

            prekesControler.SkaitytiDuomenis(duomenuFailas);

            prekesControler.IsvalytiFaila();
            
            prekesControler.SpausdintiDuomenis(rezultatuFailas, "Pradiniai duomenys: ");

            prekesControler.SuskaiciuotoPrekiuKiekioIsvedimas(rezultatuFailas);

        }
    }
}
