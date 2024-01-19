using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class DierManager
    {
        private Dictionary<(VoedselType, Formaat), Dier> dierenDict = new Dictionary<(VoedselType, Formaat), Dier>();
        private List<Dier> dieren = new List<Dier>();
        private List<Wagon> wagons = new List<Wagon>();

        public bool VoegDierToe(string voedselType, string formaat)
        {
            if (Enum.TryParse(voedselType, true, out VoedselType parsedVoedselType) &&
                Enum.TryParse(formaat, true, out Formaat parsedFormaat))
            {
                var key = (parsedVoedselType, parsedFormaat);

                if (dierenDict.TryGetValue(key, out Dier bestaandDier))
                {
                    bestaandDier.AantalVanDatDier++;
                }
                else
                {
                    dierenDict[key] = new Dier { VoedselType = parsedVoedselType, Formaat = parsedFormaat, AantalVanDatDier = 1 };
                }
                return true;
            }
            return false;
        }

        public int AantalWagons()
        {
            return wagons.Count;
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

            var gegroepeerdeDieren = dierenDict.Values
                                               .OrderByDescending(d => d.Formaat);

            foreach (var dier in gegroepeerdeDieren)
            {
                int overgeblevenAantal = dier.AantalVanDatDier;

                foreach (Wagon wagon in wagons)
                {
                    while (wagon.KanDierToevoegen(dier) && overgeblevenAantal > 0)
                    {
                        wagon.VoegDierToe(dier);
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
                    nieuweWagon.VoegDierToe(dier);
                    wagons.Add(nieuweWagon);
                    overgeblevenAantal--;
                }
            }
        }
    }
}
