using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Circustrein
{
    class Program
    {
        static void Main(string[] args)
        {
            DierManager dierManager = new DierManager();

            while (true)
            {
                Console.WriteLine("kies een optie:");
                Console.WriteLine("1. Voeg een dier toe");
                Console.WriteLine("2. Toon alle dieren");
                Console.WriteLine("3. Bereken wagons");
                Console.WriteLine("4. Toon de wagons");
                Console.WriteLine("5. Stop de applicatie");

                string keuze = Console.ReadLine();

                switch (keuze)
                {
                    case "1": //OPTIE 1
                        VoegDierenToe(dierManager);
                        break;

                    case "2": //OPTIE 2
                        dierManager.ToonAlleDieren();
                        break;

                    case "3": //OPTIE 3
                        dierManager.BerekenWagons(); 
                        break;

                    case "4": //OPTIE 4
                        dierManager.ToonWagons();
                        break;

                    case "5": // OPTIE 5
                        Environment.Exit(0);
                        break; 
                }
            }
        }

        private static void VoegDierenToe(DierManager dierManager)
        {
            Console.WriteLine("Voer het voedseltype van het dier in (carnivoor/herbivoor)");
            string voedselType = Console.ReadLine().ToLower();

            Console.WriteLine("Voer het formaat van het dier in: Klein/medium/groot");
            string formaat = Console.ReadLine().ToLower();

            Console.WriteLine("Voer het aantal van dit type dier in");
            if (!int.TryParse(Console.ReadLine(), out int aantal))
            {
                Console.WriteLine("Ongeldige invoer voor het aantal, probeer opnieuw.");
                return;
            }

            for (int i = 0; i < aantal; i++)
            {
                dierManager.VoegDierToe(voedselType, formaat);
            }
        }
    }
}
