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

        public void VoegDierToe(string voedselType, string formaat)
        {
            Dier dier = new Dier { VoedselType = voedselType, Formaat = formaat};
            dieren.Add(dier);
        }

        // eventueel meer lociga.
    }
}
