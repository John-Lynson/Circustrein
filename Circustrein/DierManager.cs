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
            Dier bestaanddier = dieren.FirstOrDefault(d => d.VoedselType == voedselType && d.Formaat == formaat);
            if (bestaanddier != null)
            {
                bestaanddier.Aantal++;
            }
            else
            {
                Dier nieuwDier = new Dier { VoedselType = voedselType, Formaat = formaat, Aantal = 1 };
                dieren.Add(nieuwDier);
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

        public void ToonWagons ()
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
                int overgeblevenAantal = dier.Aantal;

                foreach (Wagon wagon in wagons)
                {
                    while (wagon.KanDierToevoegen(dier) && overgeblevenAantal > 0)
                    {
                        wagon.VoegDierToe(dier);
                        overgeblevenAantal--;
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
