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

            if (dier.VoedselType == VoedselType.Vlees && dier.Punten == 5)
            {
                return Dieren.Count == 0;
            }

            if (dier.VoedselType == VoedselType.Planten && dier.Punten == 5)
            {
                return !Dieren.Any(w => w.VoedselType == VoedselType.Vlees);
            }

            if (Dieren.Any(w => w.VoedselType == VoedselType.Vlees && w.Punten >= dier.Punten))
                return false;

            return true;
        }



        public void VoegDierToe(Dier dier)
        {
            Dier nieuwDier = new Dier
            {
                VoedselType = dier.VoedselType,
                Formaat = dier.Formaat,
                AantalVanDatDier = 1 
            };
            Dieren.Add(nieuwDier);
            TotaalPunten += nieuwDier.Punten;
        }
    }
}
