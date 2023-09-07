using System;
using System.Collections.Generic;

namespace Circustrein
{
    class Program
    {
        static void Main(string[] args)
        {
            DierManager dierManager = new DierManager();

            while (true)
            {
                Console.WriteLine("Wilt u een dier toevoegen? (ja/nee)");
                string antwoord = Console.ReadLine().ToLower();

                if (antwoord != "ja")
                {
                    break;
                }

                Console.WriteLine("Voer het voedseltype van het dier in (vlees/planten)");
                string voedselType = Console.ReadLine().ToLower();

                Console.WriteLine("Voer het formaat van het dier in (klein/middelmatig/groot)");
                string formaat = Console.ReadLine().ToLower();

                dierManager.VoegDierToe(voedselType, formaat);
            }
            //
        }
    }
}