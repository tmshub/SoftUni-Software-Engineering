using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private const int minMuscleCarHorsePowerConst = 400;
        private const int maxMuscleCarHorsePowerConst = 600;
        private const int cubicMuscleCarCentimetersConst = 5000;

        private const int minSportCarHorsePowerConst = 250;
        private const int maxSportCarHorsePowerConst = 450;
        private const int cubicSportCarCentimetersConst = 3000;

        private IRepository<IDriver> drivers;
        private IRepository<IRace> races;
        private IRepository<ICar> cars;

        public ChampionshipController()
        {
            drivers = new DriverRepository();
            races = new RaceRepository();
            cars = new CarRepository();
        }

        public IRepository<IDriver> Drivers => drivers;
        public IRepository<IRace> Races => races;
        public IRepository<ICar> Cars => cars;
        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car; 

            if (drivers.GetByName(driverName) != null)
            {
                IDriver driver = drivers.GetByName(driverName);
                if (cars.GetByName(carModel) != null)
                {
                    car = cars.GetByName(carModel);
                }
                else
                {
                    throw new InvalidOperationException($"Car {carModel} could not be found.");
                }
                driver.AddCar(car);
            }
            else
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IDriver driver;
            IRace race;

            if(races.GetByName(raceName) != null)
            {
                race = races.GetByName(raceName);

               if (drivers.GetByName(driverName) != null)
               {
                   driver = drivers.GetByName(driverName);
               }
               else
               {
                   throw new InvalidOperationException($"Driver {driverName} could not be found.");
               }

               race.AddDriver(driver);
            }
            else
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (cars.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower, cubicMuscleCarCentimetersConst, minMuscleCarHorsePowerConst, maxMuscleCarHorsePowerConst);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower, cubicSportCarCentimetersConst, minSportCarHorsePowerConst, maxSportCarHorsePowerConst);
            }

            cars.Add(car);
            return $"{type} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);

            if (drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            drivers.Add(driver);

            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if(races.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            IRace race = new Race(name, laps);
            races.Add(race);
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            StringBuilder sb = new StringBuilder();
            IRace race;

            if (races.GetByName(raceName) != null)
            {
                race = races.GetByName(raceName);

                if(race.Drivers.Count >= 3)
                {
                    int laps = race.Laps;
                    var result = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(laps));
                    List<string> names = new List<string>();

                    foreach (var item in result)
                    {
                        names.Add(item.Name);
                    }

                    sb.AppendLine($"Driver {names[0]} wins {raceName} race.");
                    sb.AppendLine($"Driver {names[1]} is second in {raceName} race.");
                    sb.AppendLine($"Driver {names[2]} is third in {raceName} race.");

                    races.Remove(race);
                }
                else
                {
                    throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
                }
            }
            else
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
