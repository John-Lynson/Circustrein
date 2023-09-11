using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Dier
    {
        public string VoedselType { get; set; }
        public string Formaat { get; set; }
        public int Aantal { get; set; } 
        public int Punten
        {
            get
            {
                switch (Formaat)
                {
                    case "klein":
                        return 1;
                    case "middelmatig":
                        return 3;
                    case "groot":
                        return 5;
                    default:
                        return 0;
                }
            }
        }
    }
}    