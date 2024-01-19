using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    internal class Wagon
    {
        public List<Dier> Dieren { get; private set; } = new List<Dier>();
       
        public int TotaalPunten { get; private set; } = 0;

        public bool KanDierToevoegen(Dier dier)
        {
            if (TotaalPunten + dier.Punten > 10)
                return false;

            if (dier.VoedselType == VoedselType.Carnivoor && dier.Punten == 5)
            {
                return Dieren.Count == 0;
            }

            if (dier.VoedselType == VoedselType.Herbivoor && dier.Punten == 5)
            {
                return !Dieren.Any(w => w.VoedselType == VoedselType.Carnivoor);
            }

            if (Dieren.Any(w => w.VoedselType == VoedselType.Carnivoor && w.Punten >= dier.Punten))
                return false;

            return true;
        }

        public void VoegDierToe(Dier dier)
        {
            if (!Dieren.Any(d => d.VoedselType == dier.VoedselType && d.Formaat == dier.Formaat))
            {
                Dieren.Add(dier);
            }
            else
            {
                var bestaandDier = Dieren.First(d => d.VoedselType == dier.VoedselType && d.Formaat == dier.Formaat);
                bestaandDier.AantalVanDatDier += dier.AantalVanDatDier;
            }

            TotaalPunten += dier.Punten;
        }
    }
}
