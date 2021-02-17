using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }
        private List<Car> cars;

        private int capacity;

        public int Count
            => this.cars.Count;
        public string AddCar(Car car)
        {
            bool carExist = cars.Any(x => x.RegistrationNumber == car.RegistrationNumber);

            if (carExist)
            {
                return "Car with that registration number, already exists!";
            }

            bool parkingIsFull = cars.Count >= capacity;

            if (parkingIsFull)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            bool carExist = cars.Any(x => x.RegistrationNumber == registrationNumber);

            if (carExist)
            {
                foreach (var car in cars)
                {
                    if(car.RegistrationNumber == registrationNumber)
                    {
                        cars.Remove(car);
                    }
                }
            }
            else
            {
                return "Car with that registration number, doesn't exist!";

            }
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var car in cars)
            {
                foreach (var regNum in registrationNumbers)
                {
                    if(car.RegistrationNumber == regNum)
                    {
                        cars.Remove(car);
                    }
                }
            }
        }

    }
}
