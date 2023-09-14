﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class DierManager
    {
        private List<Dier> dieren = new List<Dier>();
        private List<Wagon> wagons = new List<Wagon>();

        public void VoegDierToe(string voedselType, string formaat)
        {
            VoedselType parsedVoedselType;
            Formaat parsedFormaat;

            if (Enum.TryParse(voedselType, true, out parsedVoedselType) && Enum.TryParse(formaat, true, out parsedFormaat))
            {
                Dier bestaanddier = dieren.FirstOrDefault(d => d.VoedselType == parsedVoedselType && d.Formaat == parsedFormaat);

                if (bestaanddier != null)
                {
                    bestaanddier.AantalVanDatDier++;
                }
                else
                {
                    Dier nieuwDier = new Dier
                    {
                        VoedselType = parsedVoedselType,
                        Formaat = parsedFormaat,
                        AantalVanDatDier = 1
                    };
                    dieren.Add(nieuwDier);
                }
            }
            else
            {
                // Ongeldige enum-waarde, eventueel een foutbericht hier
            }
        }

        public void ToonAlleDieren()
        {
            Console.WriteLine("Alle dieren:");
            foreach (Dier dier in dieren)
            {
                Console.WriteLine($"Voedseltype: {dier.VoedselType}, Formaat: {dier.Formaat}, Aantal: {dier.AantalVanDatDier}");
            }
        }

        public void ToonWagons()
        {
            Console.WriteLine("Wagons en hun dieren:");
            int wagonNummer = 1;
            foreach (Wagon wagon in wagons)
            {
                Console.WriteLine($"Wagon {wagonNummer}:");
                foreach (Dier dier in wagon.Dieren)
                {
                    Console.WriteLine($"  - Voedseltype: {dier.VoedselType}, Formaat: {dier.Formaat}, Aantal: {dier.AantalVanDatDier}");
                }

                wagonNummer++;
            }
        }

        public void BerekenWagons()
        {
            wagons.Clear();

            var gegroepeerdeDieren = dieren.GroupBy(d => new { d.VoedselType, d.Formaat })
                                           .OrderByDescending(g => g.Key.Formaat); 

            foreach (var groep in gegroepeerdeDieren)
            {
                Dier representatiefDier = groep.First();
                int overgeblevenAantal = groep.Sum(d => d.AantalVanDatDier); 

                foreach (Wagon wagon in wagons)
                {
                    while (wagon.KanDierToevoegen(representatiefDier) && overgeblevenAantal > 0)
                    {
                        wagon.VoegDierToe(representatiefDier);
                        overgeblevenAantal--;
                    }

                    if (overgeblevenAantal == 0)
                    {
                        break;
                    }
                }

                while (overgeblevenAantal > 0)
                {
                    Wagon nieuweWagon = new Wagon();
                    nieuweWagon.VoegDierToe(representatiefDier);
                    wagons.Add(nieuweWagon);
                    overgeblevenAantal--;
                }
            }
        }
    }
}
