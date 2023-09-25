using Xunit;
using Circustrein;
using System.Linq;

namespace UnitTest
{
    public class DierManagerTests
    {
        private DierManager _dierManager;

        public DierManagerTests()
        {
            _dierManager = new DierManager();
        }

        private void VoegDierenToe(string voedselType, string formaat, int aantal)
        {
            for (int i = 0; i < aantal; i++)
            {
                _dierManager.VoegDierToe(voedselType, formaat);
            }
        }

        [Fact]
            public void Scenario1_2Wagons()
            {
                VoegDierenToe("Carnivoor", "Klein", 1);
                VoegDierenToe("Herbivoor", "Medium", 3);
                VoegDierenToe("Herbivoor", "Groot", 2);

                _dierManager.BerekenWagons();

                Assert.Equal(2, _dierManager.AantalWagons());
            }

            [Fact]
            public void Scenario2_2Wagons()
            {
                VoegDierenToe("Carnivoor", "Klein", 1);
                VoegDierenToe("Herbivoor", "Klein", 5);
                VoegDierenToe("Herbivoor", "Medium", 2);
                VoegDierenToe("Herbivoor", "Groot", 1);

                _dierManager.BerekenWagons();

                Assert.Equal(2, _dierManager.AantalWagons());
            }

            [Fact]
            public void Scenario3_4Wagons()
            {
                VoegDierenToe("Carnivoor", "Klein", 1);
                VoegDierenToe("Carnivoor", "Medium", 1);
                VoegDierenToe("Carnivoor", "Groot", 1);
                VoegDierenToe("Herbivoor", "Klein", 1);
                VoegDierenToe("Herbivoor", "Medium", 1);
                VoegDierenToe("Herbivoor", "Groot", 1);

                _dierManager.BerekenWagons();

                Assert.Equal(4, _dierManager.AantalWagons());
            }

            [Fact]
            public void Scenario4_5Wagons()
            {
                VoegDierenToe("Carnivoor", "Klein", 2);
                VoegDierenToe("Carnivoor", "Medium", 1);
                VoegDierenToe("Carnivoor", "Groot", 1);
                VoegDierenToe("Herbivoor", "Klein", 1);
                VoegDierenToe("Herbivoor", "Medium", 5);
                VoegDierenToe("Herbivoor", "Groot", 1);

                _dierManager.BerekenWagons();

                Assert.Equal(5, _dierManager.AantalWagons());
            }

            [Fact]
            public void Scenario5_2Wagons()
            {
                VoegDierenToe("Carnivoor", "Klein", 1);
                VoegDierenToe("Herbivoor", "Klein", 1);
                VoegDierenToe("Herbivoor", "Medium", 1);
                VoegDierenToe("Herbivoor", "Groot", 2);

                _dierManager.BerekenWagons();

                Assert.Equal(2, _dierManager.AantalWagons());
            }

            [Fact]
            public void Scenario6_3Wagons()
            {
                VoegDierenToe("Carnivoor", "Klein", 3);
                VoegDierenToe("Herbivoor", "Medium", 2);
                VoegDierenToe("Herbivoor", "Groot", 3);

                _dierManager.BerekenWagons();

                Assert.Equal(3, _dierManager.AantalWagons());
            }

            [Fact]
            public void Scenario7_13Wagons()
            {
                VoegDierenToe("Carnivoor", "Klein", 7);
                VoegDierenToe("Carnivoor", "Medium", 3);
                VoegDierenToe("Carnivoor", "Groot", 3);
                VoegDierenToe("Herbivoor", "Medium", 5);
                VoegDierenToe("Herbivoor", "Groot", 6);

                _dierManager.BerekenWagons();

                Assert.Equal(13, _dierManager.AantalWagons());
            }

            [Fact]
            public void Scenario0_0Wagons()
            {
                _dierManager.BerekenWagons();

                Assert.Equal(0, _dierManager.AantalWagons());
            }
        }
    }