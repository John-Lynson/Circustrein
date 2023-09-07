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
            Dier dier = new Dier { VoedselType = voedselType, Formaat = formaat};
            dieren.Add(dier);
        }

        public void BerekenWagons ()
        {
            dieren.Sort((a, b) => b.Punten.CompareTo(a.Punten));

            foreach (Dier dier in dieren)
            {
                bool added = false; 

                foreach (Wagon wagon in wagons)
                {
                    if (wagon.KanDierToevoegen(dier))
                    {
                        wagon.VoegDierToe(dier);
                        added = true;
                        break;

                    }
                }

                if (added!)
                {
                    Wagon newWagon = new Wagon();
                    newWagon.VoegDierToe(dier);
                    wagons.Add(newWagon);
                }
            }
        }     
    }
}
