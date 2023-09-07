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

            if (Dieren.Any(w => w.VoedselType == "vlees" && w.Punten >= dier.Punten))
                return false;

            return true;
        }
    }
}
