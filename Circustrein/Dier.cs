﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public enum VoedselType
    {
        Carnivoor,
        Herbivoor
    }

    public enum Formaat
    {
        Klein = 1,
        Medium = 3,
        Groot = 5,
    }

    public class Dier
    {
        public VoedselType VoedselType { get; set; }
        public Formaat Formaat { get; set; }
        public int AantalVanDatDier { get; set; }
        public int Punten => (int)Formaat;
    }
}    