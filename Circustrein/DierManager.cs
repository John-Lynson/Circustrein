using System;
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
                    bestaanddier.Aantal++;
                }
                else
                {
                    Dier nieuwDier = new Dier
                    {
                        VoedselType = parsedVoedselType,
                        Formaat = parsedFormaat,
                        Aantal = 1
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
                Console.WriteLine($"Voedseltype: {dier.VoedselType}, Formaat: {dier.Formaat}, Aantal: {dier.Aantal}");
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
                    Console.WriteLine($"  - Voedseltype: {dier.VoedselType}, Formaat: {dier.Formaat}, Aantal: {dier.Aantal}");
                }

                wagonNummer++;
            }
        }

        public void BerekenWagons()
        {
            wagons.Clear();
            dieren.Sort((a, b) => b.Punten.CompareTo(a.Punten));

            foreach (Dier dier in dieren)
            {
                int overgeblevenAantal = dier.Aantal; // Gebruik van Aantal attribuut

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
